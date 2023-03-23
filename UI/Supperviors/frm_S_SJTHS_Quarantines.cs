using Common.Controls;
using Common.Process;
using DA;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Helper;
using UI.ReportFile;
using UI.WarehouseManagement;

namespace UI.Supperviors
{
    public partial class frm_S_SJTHS_Quarantines : frmBaseForm
    {
        private DataProcess<ST_WMS_LoadQuarantineByDate_Result> loadQuarantineByDateDataProcess = new DataProcess<ST_WMS_LoadQuarantineByDate_Result>();
        private DataProcess<STQuarantineNewProduct_Result> quarantineNewProductDataProcess = new DataProcess<STQuarantineNewProduct_Result>();
        private DataProcess<PalletStatu> palletStatusDataProcess = new DataProcess<PalletStatu>();
        private DataProcess<Quarantines> quarantinesDataProcess = new DataProcess<Quarantines>();
        private DataProcess<QuarantineDetails> quarantineDetailsDataProcess = new DataProcess<QuarantineDetails>();
        private DataProcess<STQuarantineNote_Result> quarantineNoteDataProcess = new DataProcess<STQuarantineNote_Result>();
        DataProcess<STQuarantineReleaseReport_Result> quarantineReleaseReportDA = new DataProcess<STQuarantineReleaseReport_Result>();
        private IList<ST_WMS_LoadQuarantineByDate_Result> quarantineList = null;
        private ST_WMS_LoadQuarantineByDate_Result currentQuarantine = new ST_WMS_LoadQuarantineByDate_Result();
        private bool isAddNew = false;
        private int quarantineID = -1;
        public frm_S_SJTHS_Quarantines(int quarantineParam = -1)
        {
            InitializeComponent();
            this.quarantineID = quarantineParam;

            setClickEvent(this.Controls);

            // Init data for all controls
            InitData();
        }

        private void setClickEvent(Control.ControlCollection coll)
        {
            foreach (Control c in coll)
            {
                c.MouseClick += (sender, e) =>
                {
                    /* handle the click here  */
                    Control control = (Control)sender;   // Sender gives you which control is clicked.
                    string name = control.Name.ToString();
                    // Click outside product lookupEdit to hide this combobox
                    if (name != "lkeNewProduct" && name != "layoutControlOfProduct" && layoutControlOfProduct.ContentVisible)
                    {
                        layoutControlOfProduct.ContentVisible = false;
                    }
                };
                // initControlsRecursive(c.Controls);
            }
        }

        private void BindData()
        {
            // Set value for all Textbox and DateEdit
            if (currentQuarantine == null) return;
            txtCustomerName.Text = currentQuarantine.CustomerName;
            dtDate.EditValue = currentQuarantine.QuarantineDate;
            txtQuarantineID.Text = currentQuarantine.QuarantineID.ToString();
            txtUser.Text = currentQuarantine.UserName.ToString();
            dtCreatedTime.EditValue = currentQuarantine.CreatedTime.ToString();
            if (currentQuarantine.QuarantineRemark == null)
            {
                txtRemark.Text = "";
            }
            else
            {
                txtRemark.Text = currentQuarantine.QuarantineRemark.ToString();
            }

            // Set value for lkeCustomerID
            lkeCustomerID.EditValue = currentQuarantine.CustomerID.ToString();

            // Set value for lkePalletStatus
            lkePalletStatus.EditValue = currentQuarantine.PalletStatus.ToString();
            lkePalletStatus.Text = currentQuarantine.PalletStatus.ToString();

            // Set default option for combobox
            int typeValue = 0;
            if (this.currentQuarantine.QuarantineType) typeValue = 1;
            radgQuarantineType.SelectedIndex = typeValue;
            this.radRO.Checked = true;
            this.lke_ROList.Properties.DataSource = FileProcess.LoadTable("STReceivingOrderDetailQuarantined @CustomerID=" + Convert.ToInt32(lkeCustomerID.EditValue)); ;
            this.lke_ROList.Properties.DisplayMember = "ReceivingOrderID";
            this.lke_ROList.Properties.ValueMember = "ReceivingOrderID";
        }

        private void InitData()
        {
            InitCustomer();
            InitHoldCategory();
            LoadQuarantineList();
            LoadQuarantineDetail();
            BindData();
            AlwaysInvisible();
            EnableOrNot();
            InitEvents();
        }

        private void AlwaysInvisible()
        {
            lkeCustomerID.Enabled = false;
            txtCustomerName.Enabled = false;
            //radgQuarantineType.Enabled = false;
            txtUser.Enabled = false;
            dtCreatedTime.Enabled = false;
            txtQuarantineID.Enabled = false;
        }

        private void EnableOrNot()
        {
            if (currentQuarantine == null) return;
            if (currentQuarantine.QuarantineConfirm == true)
            {
                // Confirmed, can't edit
                dtDate.Enabled = false;
                txtRemark.Enabled = false;
                lkePalletStatus.Enabled = false;
                this.radRO.Enabled = false;
                this.radProductID.Enabled = false;
                rpi_btn_Delete.Buttons[0].Enabled = false;
                btnConfirm.Enabled = false;
                btnDelete.Enabled = false;
                btnAddNewProduct.Enabled = false;
            }
            else
            {
                // Not confirm yet, can edit
                this.dtDate.Enabled = true;
                this.txtRemark.Enabled = true;
                this.lkePalletStatus.Enabled = true;
                this.radRO.Enabled = true;
                this.radProductID.Enabled = true;
                this.rpi_btn_Delete.Buttons[0].Enabled = true;
                this.btnConfirm.Enabled = true;
                this.btnDelete.Enabled = true;
                this.btnAddNewProduct.Enabled = true;
            }
        }

        private void InitHoldCategory()
        {
            // Set items for lkePalletStatus
            lkePalletStatus.Properties.DataSource = palletStatusDataProcess.Select();
            lkePalletStatus.Properties.DisplayMember = "PalletStatus";
            lkePalletStatus.Properties.ValueMember = "PalletStatus";
        }

        private void LoadROLost()
        {
            string query = " STReleaseOrQuarantineRO @customerID=" + lkeCustomerID.EditValue + ",@status=" + this.radgQuarantineType.EditValue;
            var dataSource = FileProcess.LoadTable(query);
            if (dataSource.Rows.Count >= 20)
            {
                this.lke_ROList.Properties.DropDownRows = 20;
            }
            else
            {
                this.lke_ROList.Properties.DropDownRows = dataSource.Rows.Count;
            }
            this.lke_ROList.Properties.DataSource = dataSource;
            this.lke_ROList.Properties.DisplayMember = "ReceivingOrderID";
            this.lke_ROList.Properties.ValueMember = "ReceivingOrderID";
        }

        private void InitCustomer()
        {
            // Set items for lkeCustomerID
            lkeCustomerID.Properties.DataSource = AppSetting.CustomerList;
            lkeCustomerID.Properties.DisplayMember = "CustomerNumber";
            lkeCustomerID.Properties.ValueMember = "CustomerID";
        }

        private void InitEvents()
        {
            this.lkeCustomerID.EditValueChanged += LkeCustomerID_EditValueChanged;
            this.radRO.CheckedChanged += RadRO_CheckedChanged;
            this.radProductID.CheckedChanged += RadProductID_CheckedChanged;
            this.lke_ROList.CloseUp += Lke_ROList_CloseUp;
            this.txtRemark.TextChanged += TxtRemark_TextChanged;
        }

        private void TxtRemark_TextChanged(object sender, EventArgs e)
        {
            if (!this.txtRemark.IsModified) return;
            if (isAddNew)
            {
                if (this.lkeCustomerID.EditValue == null) return;
                AddNewQurantine();
                isAddNew = false;
            }
            else
            {
                quarantinesDataProcess.ExecuteNoQuery("Update Quarantines set QuarantineRemark=N'" + this.txtRemark.Text
                    + "' Where QuarantineID=" + this.currentQuarantine.QuarantineID);
            }
        }

        private void Lke_ROList_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            this.lke_ROList.EditValue = e.Value;
            if (lke_ROList.EditValue == null) return;

            if (MessageBox.Show("Do you want accept with this RO?", "WMS-2022", MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.No)
            { return;
            }

            string orderNumber = Convert.ToString(lke_ROList.GetColumnValue("ReceivingOrderNumber"));
            int orderID = Convert.ToInt32(lke_ROList.GetColumnValue("ReceivingOrderID"));
            string remark = this.txtRemark.Text + " ~~ Process all " + orderNumber;
            this.txtRemark.Text = remark;
            var listOrderDetail = FileProcess.LoadTable("SELECT ReceivingOrderDetails.ReceivingOrderDetailID from ReceivingOrderDetails WHERE ReceivingOrderDetails.ReceivingOrderID = " + orderID);
            DataProcess<object> quaratineDA = new DataProcess<object>();
            int quarantineIDSelected = Int32.Parse(txtQuarantineID.Text);

            for (int rowIndex = 0; rowIndex < listOrderDetail.Rows.Count; rowIndex++)
            {
                var receivingOrderDetailID = Convert.ToInt32(listOrderDetail.Rows[rowIndex]["ReceivingOrderDetailID"]);
                // Quarantine
                if (this.radgQuarantineType.SelectedIndex.Equals(0))
                {
                    quaratineDA.ExecuteNoQuery("STQuarantineUpdatePallets @QuarantineID={0},@ReceivingOrderDetailID={1},@Flag={2},@QuarantineDetailID={3},@CurrentUser={4}",
                        quarantineIDSelected, receivingOrderDetailID, 1, 0, AppSetting.CurrentUser.LoginName);
                }
                else
                {
                    // Release
                    quaratineDA.ExecuteNoQuery("STQuarantineUpdatePallets @QuarantineID={0},@ReceivingOrderDetailID={1},@Flag={2},@QuarantineDetailID={3},@CurrentUser={4}",
                        quarantineIDSelected, receivingOrderDetailID, 2, 0, AppSetting.CurrentUser.LoginName);
                }
            }


            Quarantines updateQuarantine = quarantinesDataProcess.Select(q => q.QuarantineID == quarantineIDSelected).FirstOrDefault();
            if (updateQuarantine != null)
            {
                // Set update filed values
                updateQuarantine.QuarantineDate = Convert.ToDateTime(dtDate.Text);
                updateQuarantine.PalletStatus = Convert.ToByte(lkePalletStatus.EditValue);
                updateQuarantine.QuarantineRemark = remark;
                updateQuarantine.QuarantineConfirm = true;
                int result = quarantinesDataProcess.Update(updateQuarantine);
            }
            this.LoadQuarantineDetail();
        }

        private void RadProductID_CheckedChanged(object sender, EventArgs e)
        {
            this.lke_ROList.Enabled = false;
        }

        private void RadRO_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radRO.Checked)
            {
                this.lke_ROList.Enabled = true;
                this.lke_ROList.Properties.DataSource = FileProcess.LoadTable("STReceivingOrderDetailQuarantined @CustomerID=" + Convert.ToInt32(lkeCustomerID.EditValue));
                this.lke_ROList.Properties.DisplayMember = "ReceivingOrderID";
                this.lke_ROList.Properties.ValueMember = "ReceivingOrderID";
                this.lke_ROList.ShowPopup();
            }
        }

        private void LkeCustomerID_EditValueChanged(object sender, EventArgs e)
        {
            if (this.lkeCustomerID.EditValue == null)
            {
                this.txtCustomerName.Text = string.Empty;
                return;
            }
            string customerName = Convert.ToString(this.lkeCustomerID.GetColumnValue("CustomerName"));
            this.txtCustomerName.Text = customerName;
        }

        private void LoadQuarantineDetail()
        {
            if (currentQuarantine == null) return;
            // Set data for grid
            string queryString = "SELECT QuarantineDetails.*, ReceivingOrderDetails.ReceivingOrderNumber "
            + "FROM QuarantineDetails "
            + "INNER JOIN ReceivingOrderDetails ON QuarantineDetails.ReceivingOrderDetailID = ReceivingOrderDetails.ReceivingOrderDetailID "
            + "WHERE QuarantineDetails.QuarantineID = " + currentQuarantine.QuarantineID + " ";

            DataTable dataSource = FileProcess.LoadTable(queryString);
            DataColumn weight = new System.Data.DataColumn("Weight", typeof(float));
            weight.DefaultValue = 0;
            dataSource.Columns.Add(weight);

            foreach (DataRow row in dataSource.Rows)
            {
                float weightPerPackage;
                int totalPackages;
                if (float.TryParse(row["WeightPerPackage"].ToString(), out weightPerPackage) && Int32.TryParse(row["TotalPackages"].ToString(), out totalPackages))
                {
                    // success! Use weightPerPackage, totalPackages here
                    row["Weight"] = weightPerPackage * totalPackages;
                }
                else
                {
                    // If fail
                    row["Weight"] = 0;
                }
            }
            grdSubRODetailsToExport.DataSource = dataSource;
        }

        private void LoadQuarantineList()
        {
            // Execute ST_WMS_LoadQuarantineByDate
            quarantineList = loadQuarantineByDateDataProcess.Executing("ST_WMS_LoadQuarantineByDate").ToList();
            dtNavigatorService.DataSource = quarantineList;

            if (this.quarantineID > 0)
            {
                currentQuarantine = quarantineList.Where(q => q.QuarantineID == this.quarantineID).FirstOrDefault();
            }
            else
            {
                currentQuarantine = quarantineList.FirstOrDefault();
            }
            dtNavigatorService.Position = quarantineList.Count;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (isAddNew)
            {
                if (lkeCustomerID != null && lkeCustomerID.Text != "")
                {
                    // Run addNewQurantine function
                    AddNewQurantine();
                    isAddNew = false;
                }
                else
                {
                    MessageBox.Show("Please select customer ID!", "WMS-2022",
                         MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            if (!isAddNew)
            {
                if (grvSubRODetailsToExport.RowCount > 0)
                {
                    MessageBox.Show("Please delete details!", "WMS-2022",
                         MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (MessageBox.Show("Do you want delete this quarantine?", "WMS-2022",
                         MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                         == DialogResult.Yes)
                    {
                        AcCmdDeleteRecord();
                    }
                }
            }
        }

        private void AcCmdDeleteRecord()
        {
            int quarantineID = Int32.Parse(txtQuarantineID.Text);
            string queryString = "DELETE FROM Quarantines WHERE QuarantineID = " + quarantineID;
            int result = quarantinesDataProcess.ExecuteNoQuery(queryString);
            if (result <= 0)
            {
                MessageBox.Show("Cannot delete this quarantine!", "WMS-2022",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Refresh data navigator
                LoadQuarantineList();
            }
        }

        private void btnAddNewProduct_Click(object sender, EventArgs e)
        {
            if (isAddNew)
            {
                if (lkeCustomerID != null && lkeCustomerID.Text != "")
                {
                    // Run addNewQurantine function
                    AddNewQurantine();
                    isAddNew = false;
                }
                else
                {
                    MessageBox.Show("Please select customer ID!", "WMS-2022",
                         MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            if (!isAddNew)
            {
                if (Int32.Parse(lkePalletStatus.Text) > 0 && radgQuarantineType.SelectedIndex == 1)
                {
                    MessageBox.Show("Wrong Type", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (Int32.Parse(lkePalletStatus.Text) == 0 && radgQuarantineType.SelectedIndex == 0)
                {
                    MessageBox.Show("Wrong Type", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (txtRemark.Text == null || txtRemark.Text == "")
                {
                    MessageBox.Show("Please enter the reference for this quarantine !", "WMS-2022", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Default value
                bool flag = true;
                bool flagSorting = true;

                if (radgQuarantineType.SelectedIndex == 0)
                {
                    flag = false;
                }

                if (this.radRO.Checked)
                {
                    flagSorting = false;
                }

                // Execute STQuarantineNewProduct
                IList<STQuarantineNewProduct_Result> result = quarantineNewProductDataProcess.Executing("STQuarantineNewProduct @CustomerID = {0}, @Flag = {1}, @FlagSorting = {2}", Int32.Parse(lkeCustomerID.EditValue.ToString()), flag, flagSorting).ToList();
                layoutControlOfProduct.ContentVisible = true;
                lkeNewProduct.Properties.DataSource = result;
                lkeNewProduct.Focus();
                lkeNewProduct.ShowPopup();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtNavigatorService_PositionChanged(object sender, EventArgs e)
        {
            currentQuarantine = quarantineList[dtNavigatorService.Position];
            BindData();
            EnableOrNot();
            LoadQuarantineDetail();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {

            if (grvSubRODetailsToExport.RowCount == 0)
            {
                MessageBox.Show("Can not confirm empty order !", "WMS-2022", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            txtRemark.Focus();
            form_Current();
            CommandEmailNote();

        }

        private void AddNewQurantine()
        {
            Quarantines newQuarantine = new Quarantines();
            newQuarantine.QuarantineDate = this.dtDate.DateTime;
            newQuarantine.UserName = txtUser.Text;
            newQuarantine.CustomerID = Int32.Parse(lkeCustomerID.EditValue.ToString());
            if (txtRemark == null)
            {
                newQuarantine.QuarantineRemark = "";
            }
            else
            {
                newQuarantine.QuarantineRemark = txtRemark.Text;
            }
            newQuarantine.QuarantineConfirm = false;
            newQuarantine.QuarantineType = radgQuarantineType.SelectedIndex == 0 ? false : true;
            newQuarantine.CreatedTime = string.IsNullOrEmpty(dtCreatedTime.Text) ? DateTime.Now : Convert.ToDateTime(dtCreatedTime.Text);
            newQuarantine.PalletStatus = lkePalletStatus.EditValue == null ? new byte() : Convert.ToByte(lkePalletStatus.EditValue.ToString());
            int result = quarantinesDataProcess.Insert(newQuarantine);
            if (result > 0)
            {
                // Refresh new item informations
                this.txtQuarantineID.Text = Convert.ToString(newQuarantine.QuarantineID);
                this.quarantineID = newQuarantine.QuarantineID;
                LoadQuarantineList();
            }
            else
            {
                MessageBox.Show("Insert fail !", "WMS-2022", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CommandEmailNote()
        {
            int customerID = Int32.Parse(lkeCustomerID.EditValue.ToString());
            Customers customer = AppSetting.CustomerList.Where(c => c.CustomerID == customerID).FirstOrDefault();
            if (customer == null || customer.Email == null || customer.Email == "")
            {
                MessageBox.Show("This Customer does not have e-mail address !", "WMS-2022", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string varDestination = customer.Email;
            if (MessageBox.Show("Send report to the address : " + varDestination, "WMS-2022",
                         MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                         == DialogResult.Yes)
            {
                // Execute store STQuarantineNote
                DataProcess<STQuarantineNote_Result> quarantineNoteDataProcess = new DataProcess<STQuarantineNote_Result>();
                int quarantineID = Int32.Parse(txtQuarantineID.Text);
                IList<STQuarantineNote_Result> result = quarantineNoteDataProcess.Executing("STQuarantineNote @QuarantineID = {0}", quarantineID).ToList();
                // FIXME: handle result after executing store STQuarantineNote
                int employeeID = AppSetting.CurrentUser.EmployeeID;
                DataProcess<Employees> dataProcess = new DataProcess<Employees>();
                Employees currentUser = dataProcess.Select(em => em.EmployeeID == employeeID).FirstOrDefault();
                string fullName = "unknown";
                string body = "Please find the attached report";
                if (currentUser != null)
                {
                    fullName = currentUser.VietnamName;
                }
                // Get path file to export
                string attachPath = AppSetting.PathEmailAttach + DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss") + "-Quarantine Report-" + customer.CustomerNumber + ".rtf";
                rptQuarantineNote rpt = new rptQuarantineNote(fullName);
                rpt.DataSource = result;
                // Export current report to rich text file
                rpt.ExportToRtf(attachPath);

                try
                {
                    DataTransfer.SendMail(varDestination, "SCS VN Report - Quarantine Note - " + txtCustomerName.Text + " : No. " + txtQuarantineID.Text, body, attachPath);
                    MessageBox.Show("E-mail sent !", "WMS-2022", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Can not send e-mail with reason: " + ex.StackTrace + "!", "WMS-2022", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void form_Current()
        {
            int quarantineID = Int32.Parse(txtQuarantineID.Text);
            Quarantines updateQuarantine = new Quarantines();
            updateQuarantine = quarantinesDataProcess.Select(q => q.QuarantineID == quarantineID).FirstOrDefault();
            // Set update filed values
            updateQuarantine.QuarantineDate = Convert.ToDateTime(dtDate.EditValue);
            updateQuarantine.PalletStatus = Convert.ToByte(lkePalletStatus.EditValue);
            updateQuarantine.QuarantineRemark = txtRemark.Text;
            updateQuarantine.QuarantineConfirm = true;
            int result = quarantinesDataProcess.Update(updateQuarantine);
            if (result <= 0)
            {
                MessageBox.Show("Cannot confirm this quarantine!", "WMS-2022",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Refresh control values
                int currentPos = dtNavigatorService.Position;
                // ST_WMS_LoadQuarantineByDate_Result backupQuarantine = currentQuarantine;
                LoadQuarantineList();
                dtNavigatorService.Position = currentPos;
                // currentQuarantine = backupQuarantine;
            }
        }

        private void rpi_btn_Delete_Click(object sender, EventArgs e)
        {
            string productID = grvSubRODetailsToExport.GetRowCellValue(grvSubRODetailsToExport.FocusedRowHandle, "ProductID").ToString();
            DeleteProductDetail(productID);
        }

        private void DeleteProductDetail(string productID)
        {
            // Execute store STQuarantineUpdatePallets @QuarantineID, @ReceivingOrderDetailID, @Flag, @QuarantineDetailID, @CurrentUser, @PalletStatus
            SwireDBEntities context = new SwireDBEntities();
            int selectedIndex = grvSubRODetailsToExport.GetSelectedRows()[0];
            DataRow dataRow = grvSubRODetailsToExport.GetDataRow(selectedIndex);
            int receivingOrderDetailID = Int32.Parse(dataRow["ReceivingOrderDetailID"].ToString());
            int quarantineDetailID = Int32.Parse(dataRow["QuarantineDetailID"].ToString());
            byte palletStatus = Convert.ToByte(lkePalletStatus.EditValue);

            int result = -1;
            if (radgQuarantineType.SelectedIndex == 0)
            {
                result = context.STQuarantineUpdatePallets(Int32.Parse(txtQuarantineID.Text), receivingOrderDetailID, 0, quarantineDetailID, AppSetting.CurrentUser.LoginName, palletStatus);
            }
            else
            {
                result = context.STQuarantineUpdatePallets(Int32.Parse(txtQuarantineID.Text), receivingOrderDetailID, 3, quarantineDetailID, AppSetting.CurrentUser.LoginName, palletStatus);
            }

            if (result <= 0)
            {
                MessageBox.Show("Cannot delete this quarantine!", "WMS-2022",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Refresh detail grid
                LoadQuarantineDetail();
            }
        }

        private void btnPalletInfo_Click(object sender, EventArgs e)
        {
            try
            {
                int customerID = Convert.ToInt32(lkeCustomerID.EditValue);
                string productNo = grvSubRODetailsToExport.GetRowCellValue(grvSubRODetailsToExport.FocusedRowHandle, grvSubRODetailsToExport.Columns[0]).ToString();
                Products found = AppSetting.ProductList.Where(p => p.ProductNumber == productNo).FirstOrDefault();
                if (found == null)
                {
                    MessageBox.Show("Cannot find this product!", "WMS-2022",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                int productID = found.ProductID;
                new frm_WM_PalletInfo(customerID, productID).Show();
            }
            catch (Exception ex)
            {
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {                       
            int quarantineID = Int32.Parse(txtQuarantineID.Text);
            int employeeID = AppSetting.CurrentUser.EmployeeID;
            DataProcess<Employees> dataProcess = new DataProcess<Employees>();
            Employees currentUser = dataProcess.Select(em => em.EmployeeID == employeeID).FirstOrDefault();
            string fullName = "unknown";
            if (currentUser != null)
            {
                fullName = currentUser.VietnamName;
            }
            rptQuarantineRelease rpt = new rptQuarantineRelease(fullName);
            rpt.DataSource = quarantineReleaseReportDA.Executing("STQuarantineReleaseReport @QuarantineID = {0}", quarantineID);
            CalculateAndAddFieldForReport(rpt);
            ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
            tool.ShowPreview();
        }

        private void CalculateAndAddFieldForReport(XtraReport report)
        {
            CalculatedField sumAfterDPQuantity = new CalculatedField();
            sumAfterDPQuantity.DataSource = report.DataSource;
            sumAfterDPQuantity.DataMember = report.DataMember;
            sumAfterDPQuantity.DisplayName = "sumAfterDPQuantity";
            sumAfterDPQuantity.Name = "sumAfterDPQuantity";
            sumAfterDPQuantity.Expression = "Sum([AfterDPQuantity])";

            report.CalculatedFields.Add(sumAfterDPQuantity);

            CalculatedField sumPalletWeight = new CalculatedField();
            sumPalletWeight.DataSource = report.DataSource;
            sumPalletWeight.DataMember = report.DataMember;
            sumPalletWeight.DisplayName = "sumPalletWeight";
            sumPalletWeight.Name = "sumPalletWeight";
            sumPalletWeight.Expression = "Sum([PalletWeight])";

            report.CalculatedFields.Add(sumPalletWeight);
        }



        private void btnNote_Click(object sender, EventArgs e)
        {
            if (currentQuarantine.QuarantineConfirm == false)
            {
                MessageBox.Show("Printing Note requires the Quarantine to be confirmed !", "WMS-2022",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int employeeID = AppSetting.CurrentUser.EmployeeID;
            DataProcess<Employees> dataProcess = new DataProcess<Employees>();
            Employees currentUser = dataProcess.Select(em => em.EmployeeID == employeeID).FirstOrDefault();
            string fullName = "unknown";
            if (currentUser != null)
            {
                fullName = currentUser.VietnamName;
            }
            rptQuarantineNote rpt = new rptQuarantineNote(fullName);
            int quarantineID = Int32.Parse(txtQuarantineID.Text);
            rpt.DataSource = quarantineNoteDataProcess.Executing("STQuarantineNote @QuarantineID = {0}", quarantineID);
            CalculateAndAddFieldForNoteReport(rpt);
            ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
            tool.Print();
        }

        private void CalculateAndAddFieldForNoteReport(XtraReport report)
        {
            CalculatedField sumTotalPackages = new CalculatedField();
            sumTotalPackages.DataSource = report.DataSource;
            sumTotalPackages.DataMember = report.DataMember;
            sumTotalPackages.DisplayName = "sumTotalPackages";
            sumTotalPackages.Name = "sumTotalPackages";
            sumTotalPackages.Expression = "Sum([TotalPackages])";
            report.CalculatedFields.Add(sumTotalPackages);

            CalculatedField sumWeightPerPackageAndTotalPackages = new CalculatedField();
            sumWeightPerPackageAndTotalPackages.DataSource = report.DataSource;
            sumWeightPerPackageAndTotalPackages.DataMember = report.DataMember;
            sumWeightPerPackageAndTotalPackages.DisplayName = "sumWeightPerPackageAndTotalPackages";
            sumWeightPerPackageAndTotalPackages.Name = "sumWeightPerPackageAndTotalPackages";
            sumWeightPerPackageAndTotalPackages.Expression = "Sum([WeightPerPackage]*[TotalPackages])";
            report.CalculatedFields.Add(sumWeightPerPackageAndTotalPackages);
        }

        private void AcCmdSaveRecord()
        {
            // Save new product
            object row = lkeNewProduct.Properties.GetDataSourceRowByKeyValue(lkeNewProduct.EditValue);
            Type myType = row.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

            if (row != null)
            {
                QuarantineDetails newProduct = new QuarantineDetails();
                newProduct.QuarantineID = Int32.Parse(txtQuarantineID.Text);
                newProduct.CreatedTime = DateTime.Now;
                foreach (PropertyInfo pInfo in props)
                {
                    // Gets the name of the property
                    string propertyName = pInfo.Name;

                    if (propertyName == "ProductNumber")
                    {
                        newProduct.ProductNumber = pInfo.GetValue(row, null).ToString();
                    }
                    //if (propertyName == "ProductID")
                    //{
                    //    newProduct.ProductID = Int32.Parse(pInfo.GetValue(row, null).ToString());
                    //}
                    if (propertyName == "ProductName")
                    {
                        newProduct.ProductName = pInfo.GetValue(row, null).ToString();
                    }
                    if (propertyName == "ReceivingOrderDetailID")
                    {
                        newProduct.ReceivingOrderDetailID = Int32.Parse(pInfo.GetValue(row, null).ToString());
                    }
                    if (propertyName == "TotalPackages")
                    {
                        newProduct.TotalPackages = Int32.Parse(pInfo.GetValue(row, null).ToString());
                    }
                    if (propertyName == "WeightPerPackage")
                    {
                        newProduct.WeightPerPackage = float.Parse(pInfo.GetValue(row, null).ToString());
                    }
                    if (propertyName == "Remark")
                    {
                        if (pInfo.GetValue(row, null) == null)
                        {
                            newProduct.QuarantineDetailRemark = "";
                        }
                        else
                        {
                            newProduct.QuarantineDetailRemark = pInfo.GetValue(row, null).ToString();
                        }
                    }
                }

                int result = quarantineDetailsDataProcess.Insert(newProduct);
                if (result <= 0)
                {
                    MessageBox.Show("Cannot add new product!", "WMS-2022",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Refresh grid
                    LoadQuarantineDetail();
                }
            }
        }

        private void lkeNewProduct_EditValueChanged(object sender, EventArgs e)
        {
            AcCmdSaveRecord();
            layoutControlOfProduct.ContentVisible = false;
        }

        private void ResetDataForInsert()
        {
            isAddNew = true;
            lkeCustomerID.Enabled = true;
            radgQuarantineType.Enabled = true;
            txtQuarantineID.Text = "";
            this.grdSubRODetailsToExport.DataSource = null;
            this.grvSubRODetailsToExport.RefreshData();
            ST_WMS_LoadQuarantineByDate_Result newQuarantine = new ST_WMS_LoadQuarantineByDate_Result();
            newQuarantine.QuarantineConfirm = false;
            newQuarantine.QuarantineDate = DateTime.Now;
            newQuarantine.CreatedTime = DateTime.Now;
            newQuarantine.PalletStatus = palletStatusDataProcess.Select().ToList()[1].PalletStatus;
            newQuarantine.UserName = AppSetting.CurrentUser.LoginName;
            quarantineList.Add(newQuarantine);
            currentQuarantine = newQuarantine;
            dtNavigatorService.Position = this.quarantineList.Count;
            lkeCustomerID.Focus();
            lkeCustomerID.ShowPopup();
        }

        private void btnNewQurantine_Click(object sender, EventArgs e)
        {
            ResetDataForInsert();
        }

        private void lkePalletStatus_EditValueChanged(object sender, EventArgs e)
        {
            int customerID = Int32.Parse(lkeCustomerID.EditValue.ToString());
            Customers findByID = AppSetting.CustomerList.Where(q => q.CustomerID == customerID).FirstOrDefault();
            if (findByID != null)
            {
                txtCustomerName.Text = findByID.CustomerName;
            }

        }

        private void grdSubRODetailsToExport_Click(object sender, EventArgs e)
        {

        }

        private void radgQuarantineType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if(radgQuarantineType.SelectedIndex == 1)
            //{
            //    this.lke_ROList.Properties.DataSource = FileProcess.LoadTable("STReceivingOrderDetailQuarantined @CustomerID=" + Convert.ToInt32(lkeCustomerID.EditValue)); ;
            //    this.lke_ROList.Properties.DisplayMember = "ReceivingOrderID";
            //    this.lke_ROList.Properties.ValueMember = "ReceivingOrderID";
            //    //this.lke_ROList.ShowPopup();
            //}
            //else
            //{
            //LoadROLost();
            //this.lke_ROList.ShowPopup();
            //}
        }
    }
}
