using Common.Controls;
using DA;
using DA.Management;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Helper;
using UI.ReportFile;
using UI.WarehouseManagement;

namespace UI.Management
{
    public partial class frm_M_ProductCheckingByRequest : frmBaseFormNormal
    {
        private int productCheckingOrderFind = -1;
        private List<ProductCheckings> productCheckingList;
        private ProductCheckings currentProductChecking;
        private ProductCheckings saveCurrentProductChecking;
        private static frm_M_ProductCheckingByRequest _instance;
        DataProcess<Customers> daCustomer = new DataProcess<Customers>();
        private urc_WM_OtherService viewService = null;
        private urc_WM_Notes viewNotes = null;
        private urc_WM_EmployeeInfo viewEmployee = null;
        private bool isCreateNew = false;
        private IDictionary<Control, bool> validateList = new Dictionary<Control, bool>();

        public frm_M_ProductCheckingByRequest()
        {
            InitializeComponent();
            //this.KeyPreview = true;
            //IsFixHeightScreen = false;
            this.LoadTimeSlots();
            Init();
        }

        public int ProductCheckingIDFind
        {
            get { return productCheckingOrderFind; }
            set
            {
                productCheckingOrderFind = value;
                this.Init();
            }
        }
        public static frm_M_ProductCheckingByRequest GetInstance()
        {

            if (_instance == null)
            {
                _instance = new frm_M_ProductCheckingByRequest();
            }
            return _instance;

        }
        private void LoadTimeSlots()
        {
            this.lke_TimeSlotID.Properties.DataSource = AppSetting.TimeSlots;
            this.lke_TimeSlotID.Properties.DisplayMember = "TimeSlot";
            this.lke_TimeSlotID.Properties.ValueMember = "TimeSlotID";
        }
        private void Init()
        {

            //lkeCustomerNumber.Properties.DataSource = daCustomer.Executing("SELECT * FROM dbo.Customers WHERE StoreID=" + AppSetting.CurrentUser.StoreID);
            lkeCustomerNumber.Properties.DataSource = AppSetting.CustomerList;
            int customerCount = AppSetting.CustomerList.Count();
            if (customerCount > 20)
                lkeCustomerNumber.Properties.DropDownRows = 20;
            else
                lkeCustomerNumber.Properties.DropDownRows = customerCount;
            lkeCustomerNumber.Properties.DisplayMember = "CustomerNumber";
            lkeCustomerNumber.Properties.ValueMember = "CustomerID";


            DataProcess<ProductCheckings> productCheckingDA = new DataProcess<ProductCheckings>();

            try
            {
                this.productCheckingList = productCheckingDA.Executing("SELECT ProductChecking.*,StoreID FROM dbo.ProductChecking Left JOIN Customers ON ProductChecking.CustomerID=Customers.CustomerID WHERE ProductCheckingDate > GETDATE() - 31 and StoreID= "
                                        + (int)AppSetting.CurrentUser.StoreID).ToList();
                //this.productCheckingList = productCheckingDA.Executing("SELECT ProductChecking.*,StoreID FROM dbo.ProductChecking Left JOIN Customers ON ProductChecking.CustomerID=Customers.CustomerID WHERE ProductCheckingDate > GETDATE() - 31 ").ToList();
                dtngProductChecking.DataSource = productCheckingList;
                // open form from a  PC id
                int position = productCheckingList.Count - 1;
                if (this.productCheckingOrderFind > 0)
                {
                    for (int i = 0; i < productCheckingList.Count; i++)
                    {
                        if (productCheckingList.ElementAt(i).ProductCheckingID == productCheckingOrderFind)
                        {
                            position = i;
                            break;
                        }

                    }
                }
                if (productCheckingList.Count <= 1)
                {
                    productCheckingList.Add(new ProductCheckings());
                }
                dtngProductChecking.Position = position;
                this.grdListPalletByRequest.DataSource = FileProcess.LoadTable("ST_WMS_ProductCheckingByRequestDetails " + this.productCheckingList.ElementAt(position).ProductCheckingID);
            }
            catch
            {

            }
            //this.grdListPalletByRequest.DataSource = FileProcess.LoadTable("ST_WMS_ProductCheckingByRequestDetails " + productCheckingList.ElementAt(0).ProductCheckingID);
            if (this.txt_RelatedOrders.Text != "")
                this.layoutDeleteDO.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            else
                this.layoutDeleteDO.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }

        private void loadCustomerList()
        {
            //this.grcChoosePallet.DataSource = FileProcess.LoadTable("ST_WMS_ProductCheckingByRequestTreeListProducts " + this.lkeCustomerNumber.EditValue);

            if (lkeCustomerNumber.EditValue != null && lkeCustomerNumber.GetColumnValue("CustomerName") != null
                && lkeCustomerNumber.GetColumnValue("CustomerID") != null)
            {
                txtCustomerName.EditValue = lkeCustomerNumber.GetColumnValue("CustomerName").ToString();

                //this.grdListPalletByRequest.DataSource = FileProcess.LoadTable("ST_WMS_ProductCheckingByRequestDetails " + this.currentProductChecking.ProductCheckingID);
                //this.grcChoosePallet.DataSource = FileProcess.LoadTable("ST_WMS_ProductCheckingByRequestTreeListProducts " 
                //                                   + this.lkeCustomerNumber.EditValue);

            }
        }

        private void lkeCustomerNumber_EditValueChanged(object sender, EventArgs e)
        {
            loadCustomerList();
            btn_UpdatePC_Click(sender, e);
        }

        private void dockPanelServices_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
        }

        //string choosenPallets = "";
        private void btn_Pick_Click(object sender, EventArgs e)
        {
            frm_M_ProductCheckingByRequestDetail frm = new frm_M_ProductCheckingByRequestDetail(Convert.ToInt32(this.lkeCustomerNumber.EditValue), this.currentProductChecking.ProductCheckingID, 0);
            frm.FormClosing += new FormClosingEventHandler(this.frm_M_ProductCheckingByRequest_FormClosing);
            frm.ShowDialog();

        }

        private void dtngProductChecking_PositionChanged(object sender, EventArgs e)
        {
            currentProductChecking = productCheckingList.ElementAt(dtngProductChecking.Position);
            saveCurrentProductChecking = currentProductChecking;
            UpdateControlsBy(currentProductChecking);
            UpdateControlStatus();
        }

        private void UpdateControlsBy(ProductCheckings yourcurrentProductChecking)
        {
            currentProductChecking = yourcurrentProductChecking;

            txtProductCheckingRecordNumber.EditValue = currentProductChecking.ProductCheckingNumber;

            Customers selectedCustomer = ((List<Customers>)lkeCustomerNumber.Properties.DataSource).Where(c => c.CustomerID == currentProductChecking.CustomerID).SingleOrDefault();
            if (selectedCustomer != null)
            {
                lkeCustomerNumber.EditValue = selectedCustomer.CustomerID;
                txtCustomerName.EditValue = selectedCustomer.CustomerName;
            }
            else
            {
                lkeCustomerNumber.EditValue = "";
            }
            if (currentProductChecking.Status == 1)
            {
                this.btn_Confirm_ProductChecking.Enabled = false;
            }
            else
                this.btn_Confirm_ProductChecking.Enabled = true;
            this.lke_TimeSlotID.EditValue = currentProductChecking.TimeSlot;
            textPCCreatedBy.EditValue = currentProductChecking.CreatedBy;
            textPCCreatedTime.EditValue = currentProductChecking.CreatedTime;
            this.meRemark.EditValue = currentProductChecking.Remark;
            this.txt_RelatedOrders.EditValue = currentProductChecking.FromDO;
            deDateIn.EditValue = currentProductChecking.ProductCheckingDate;
            timeEditEndTime.EditValue = currentProductChecking.EndTime;
            timeEditStartTime.EditValue = currentProductChecking.StartTime;
            this.grdListPalletByRequest.DataSource = FileProcess.LoadTable("ST_WMS_ProductCheckingByRequestDetails "
                + this.currentProductChecking.ProductCheckingID);

        }

        private void UpdateControlStatus()
        {

            if (btn_Confirm_ProductChecking.Enabled == true)
            {
                lkeCustomerNumber.Enabled = true;
                txtCustomerName.Enabled = true;
                deDateIn.Enabled = true;
                btn_Pick.Enabled = true;
                btn_Confirm_ProductChecking.Appearance.BackColor = DXSkinColors.FillColors.Warning;
                btn_Confirm_ProductChecking.Appearance.Options.UseBackColor = true;
            }
            else
            {
                lkeCustomerNumber.Enabled = false;
                txtCustomerName.Enabled = false;
                deDateIn.Enabled = false;
                btn_Pick.Enabled = false;
                //this.grdListPalletByRequest.Enabled = false;
                btn_Confirm_ProductChecking.Appearance.BackColor = Color.DarkGray;
                btn_Confirm_ProductChecking.Appearance.Options.UseBackColor = true;
            }
            //this.gridColumn12.OptionsColumn.ReadOnly = false;
        }


        private void dtngProductChecking_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Left)
                dtngProductChecking.Position = dtngProductChecking.Position - 1;
            else if (e.KeyData == Keys.Right)
                dtngProductChecking.Position = dtngProductChecking.Position + 1;
            else if (e.KeyData == Keys.Up)
                dtngProductChecking.Position = 0;
            else if (e.KeyData == Keys.Down)
                dtngProductChecking.Position = ((IList<ProductCheckings>)dtngProductChecking.DataSource).Count;
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            //int receivingOrderID = Convert.ToInt32(this.textEditOrderID.Tag);
            rptProductCheckingByPallet rpt = new rptProductCheckingByPallet();
            //DataProcess<STReceivingAdvice_Result> receivingAdviceDA = new DataProcess<STReceivingAdvice_Result>();
            rpt.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
            //rpt.Parameters["varReceivingOrderID"].Value = receivingOrderID;
            //rpt.DataSource = receivingAdviceDA.Executing("STReceivingAdvice @varReceivingOrderID={0}", receivingOrderID);
            rpt.DataSource = FileProcess.LoadTable("ST_WMS_ProductCheckingPrintReport " + this.currentProductChecking.ProductCheckingID);
            rpt.RequestParameters = false;
            ReportPrintToolWMS printTool = new ReportPrintToolWMS(rpt);
            printTool.AutoShowParametersPanel = false;
            printTool.ShowPreview();

            printReportByLocation_pcs();
            string customerType = lkeCustomerNumber.GetColumnValue("CustomerType").ToString();
            if (customerType == "Pcs")
            {
                printlabelA4short_pcs();
            }
            else
            {
                printLabelA4short();
            }


        }

        private void printReportByLocation_pcs()
        {
            int customerID = Convert.ToInt32(this.lkeCustomerNumber.GetColumnValue("CustomerID"));
            rptPCByLocationLocationDetails rpt = new rptPCByLocationLocationDetails();
            rpt.lblafterpick.Visible = true;
            //rpt.lblTotalDetails.Visible = true;
            rpt.lblQtyLocationDetailsReport.Visible = true;

            rpt.DataSource = FileProcess.LoadTable("ST_WMS_ProductCheckingPrintReportByLocation " + this.currentProductChecking.ProductCheckingID);
            //CreateLocationDetailsField(rpt);

            ReportPrintToolWMS printTool = new ReportPrintToolWMS(rpt, customerID);
            printTool.ShowPreview();


        }
        private void printlabelA4short_pcs()
        {
            int varProductCheckingID = currentProductChecking.ProductCheckingID;
            DataProcess<STLabel1RO_Result> label1RO = new DataProcess<STLabel1RO_Result>();
            rptLabelA4Short_Barcode_pcs reportA4ShortPcs = new rptLabelA4Short_Barcode_pcs();
            //reportA4ShortPcs.bcPalletID.Text = "*" + receivingOrderID.ToString() + "*";
            reportA4ShortPcs.Parameters["varReceivingOrderID"].Value = "";
            reportA4ShortPcs.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
            reportA4ShortPcs.Parameters["parameter1"].Value = 3;
            reportA4ShortPcs.RequestParameters = false;
            reportA4ShortPcs.DataSource = label1RO.Executing("STLabel1PC @varProductCheckingID={0}", varProductCheckingID);
            ReportPrintToolWMS printToolA4 = new ReportPrintToolWMS(reportA4ShortPcs);
            printToolA4.AutoShowParametersPanel = false;

            printToolA4.ShowPreview();


        }

        private void printLabelA4short()
        {
            int varProductCheckingID = currentProductChecking.ProductCheckingID;
            DataProcess<STLabel1RO_Result> multilabel = new DataProcess<STLabel1RO_Result>();
            rptLabelA4Short_Barcode lb = new rptLabelA4Short_Barcode();
            lb.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
            lb.Parameters["parameter1"].Value = 3;
            lb.DataSource = multilabel.Executing("STLabel1PC @varProductCheckingID={0}", varProductCheckingID);
            lb.RequestParameters = false;
            ReportPrintToolWMS printTool = new ReportPrintToolWMS(lb);
            printTool.AutoShowParametersPanel = false;

            printTool.ShowPreview();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_M_ProductCheckingByRequest_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                if (this.txtProductCheckingRecordNumber.Text.ToString().Equals("PC-New*"))
                {
                    return;
                }
                else
                {
                    frm_WM_Attachments.Instance.OrderNumber = this.txtProductCheckingRecordNumber.Text;
                    frm_WM_Attachments.Instance.CustomerID = Convert.ToInt32(this.lkeCustomerNumber.EditValue);
                    if (!frm_WM_Attachments.Instance.Enabled) return;
                    frm_WM_Attachments.Instance.ShowDialog();
                }
            }

            else if (e.KeyCode == Keys.F12)
            {
                if (this.Modal)
                {
                    return;
                }
                FormCollection openforms = Application.OpenForms;
                bool isOpen = false;
                foreach (Form frms in openforms)
                {
                    if (frms.Name == "frmScanInput")
                    {
                        frms.BringToFront();
                        isOpen = true;
                    }

                }
                if (!isOpen)
                {
                    UI.Helper.frmScanInput inputDialog = new frmScanInput();
                    inputDialog.Show();
                    inputDialog.BringToFront();
                }
            }
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (this.txtProductCheckingRecordNumber.Text.ToString().Equals("PC-New*"))
            {
                return base.ProcessDialogKey(keyData);
            }
            else
            {
                string CustomerNumber = txtProductCheckingRecordNumber.Text;
                Int16 CustomerID = Convert.ToInt16(this.lkeCustomerNumber.EditValue);
                if (keyData == Keys.F3)
                {
                    frm_WM_Attachments.Instance.OrderNumber = CustomerNumber;
                    frm_WM_Attachments.Instance.CustomerID = CustomerID;
                    if (frm_WM_Attachments.Instance.Enabled) frm_WM_Attachments.Instance.ShowDialog();
                    this.Init();
                }
                return base.ProcessDialogKey(keyData);
            }
        }

        private void dockPanel3_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {

        }

        /// <summary>
        /// Refresh note report data
        /// </summary>
        private void RefreshNoteData()
        {
            int roID = this.currentProductChecking.ProductCheckingID;
            string orderType = "PC";
            int customerID = this.lkeCustomerNumber.EditValue == null ? -1 : (int)this.lkeCustomerNumber.EditValue;
            this.viewNotes.CustomerNumber = this.lkeCustomerNumber.GetColumnValue("CustomerNumber").ToString();
            //this.viewNotes.NoteDescription = this.memoEditTruckAndDetail.Text;
            //this.viewNotes.VehicleNumber = this.textEditVehicleNumber.Text;
            this.viewNotes.LoadData(orderType, roID, customerID);
            this.viewNotes.Update();
            this.viewNotes.Refresh();
        }

        private void dockPanel2_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
        }

        private void RefreshEmployeeData()
        {
            decimal totalPallet = 0;// Convert.ToDecimal(this.gridColumnPallets.SummaryItem.SummaryValue);
            decimal totalWeight = 0;// Convert.ToDecimal(this.gridColumn5.SummaryItem.SummaryValue);
            decimal totalCartons = 0;// Convert.ToDecimal(this.gridColumnTotalPackages.SummaryItem.SummaryValue);
            this.viewEmployee.UpdateParameter(totalCartons, totalPallet, totalWeight);
            this.viewEmployee.LoadEmployeeWorking(this.txtProductCheckingRecordNumber.Text);
            this.viewEmployee.Update();
            this.viewEmployee.Refresh();
        }

        private void CheckLockControls()
        {

        }

        private void grvListPalletByRequest_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle < 0) return;
            if (e.Column.FieldName.Equals("Remark"))
            {
                //ReceivingOrderDetails rODetail = this.grvListPalletByRequest.GetRow(e.RowHandle) as ReceivingOrderDetails;
                //using (var context = new SwireDBEntities())
                //{
                //    context.ReceivingOrderDetails.Attach(rODetail);
                //    context.Entry(rODetail).State = System.Data.Entity.EntityState.Modified;
                //}
                //this.recevingOrderDetailDA.Update(rODetail);
                string strRemark = this.grvListPalletByRequest.GetRowCellValue(e.RowHandle, "Remark").ToString();
                string strPCDID = this.grvListPalletByRequest.GetRowCellValue(e.RowHandle, "ProductCheckingDetailID").ToString();
                DataProcess<object> dataProcess = new DataProcess<object>();
                dataProcess.ExecuteNoQuery("Update ProductCheckingDetails set Remark = N'" + strRemark + "' where ProductCheckingDetailID = " + strPCDID);
            }
        }

        private void btn_ExportDO_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Are you sure to Export DO ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            if (grvListPalletByRequest.SelectedRowsCount <= 0)
            {
                XtraMessageBox.Show("Please select rows beforce export", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string cellValues = "";
            int[] selectedRows = grvListPalletByRequest.GetSelectedRows();
            foreach (int rowHandle in selectedRows)
            {
                if (rowHandle >= 0)
                {
                    if (cellValues.Length > 0)
                        cellValues = cellValues + " , " + grvListPalletByRequest.GetRowCellValue(rowHandle, "ProductCheckingDetailID").ToString();
                    else
                        cellValues = grvListPalletByRequest.GetRowCellValue(rowHandle, "ProductCheckingDetailID").ToString();
                }
            }
            //choosenPallets = cellValues;

            //Excute Store to Export DO ,then get the DO id 
            int DO_ID = 0;
            using (var context = new SwireDBEntities())
            {
                using (var connection = context.Database.Connection)
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "STProductCheckingExportDO";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter paramstrProductCheckingID = new SqlParameter("@strProductCheckingID", SqlDbType.VarChar, 5000);
                        paramstrProductCheckingID.Value = cellValues;
                        command.Parameters.Add(paramstrProductCheckingID);

                        SqlParameter paramCurrentUSer = new SqlParameter("@CurrentUSer", SqlDbType.VarChar, 50);
                        paramCurrentUSer.Value = AppSetting.CurrentUser.LoginName.ToString();
                        command.Parameters.Add(paramCurrentUSer);

                        SqlParameter varDispatchingOrderID = new SqlParameter("@varDispatchingOrderID", SqlDbType.Int);
                        varDispatchingOrderID.Direction = ParameterDirection.Output;
                        command.Parameters.Add(varDispatchingOrderID);

                        connection.Open();
                        //var dataSoure = new DataTable();
                        //dataSoure.Load(command.ExecuteReader());
                        command.ExecuteNonQuery();
                        DO_ID = Convert.ToInt32(command.Parameters["@varDispatchingOrderID"].Value);
                        connection.Close();
                    }
                }

            }
            if (DO_ID != 0)
            {
                frm_WM_DispatchingOrders dispatchingOrder = frm_WM_DispatchingOrders.GetInstance(DO_ID);
                if (dispatchingOrder.Visible)
                {
                    dispatchingOrder.ReloadData();
                }
                dispatchingOrder.Show();
                dispatchingOrder.WindowState = FormWindowState.Maximized;
                dispatchingOrder.BringToFront();
            }
            else
                MessageBox.Show("Export DO is failed", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //DataProcess<object> dataProcess = new DataProcess<object>();
            //dataProcess.ExecuteNoQuery("STProductCheckingExportDO @strProductCheckingID = '"+ cellValues + "' , @CurrentUSer= '" + AppSetting.CurrentUser.LoginName.ToString() + "'");

        }


        private void BtnWmNewPC_Click(object sender, EventArgs e)
        {
            txtProductCheckingRecordNumber.EditValue = null;
            txtCustomerName.EditValue = null;
            deDateIn.EditValue = DateTime.Now;
            textPCCreatedBy.EditValue = AppSetting.CurrentUser.LoginName;
            meRemark.EditValue = "";
            txt_RelatedOrders.EditValue = "";
            textPCCreatedTime.EditValue = DateTime.Now;
            timeEditStartTime.EditValue = null;
            timeEditEndTime.EditValue = null;
            this.lke_TimeSlotID.EditValue = null;
            timeEditEndTime.EditValue = null;
            timeEditStartTime.EditValue = null;

            grdListPalletByRequest.DataSource = null;
            grvListPalletByRequest.RefreshData();
            lkeCustomerNumber.Enabled = true;
            txtCustomerName.Enabled = true;
            deDateIn.Enabled = true;
            isCreateNew = true;
            lkeCustomerNumber.Focus();
            lkeCustomerNumber.ShowPopup();
        }

        private void timeEditStartTime_Enter(object sender, EventArgs e)
        {
            if (timeEditStartTime.Text.Trim() == "")
                timeEditStartTime.EditValue = DateTime.Now;
        }

        private void timeEditEndTime_Enter(object sender, EventArgs e)
        {
            if (timeEditEndTime.Text.Trim() == "")
                timeEditEndTime.EditValue = DateTime.Now;
        }

        private void timeEditStartTime_Validating(object sender, CancelEventArgs e)
        {

        }

        private void timeEditEndTime_Validating(object sender, CancelEventArgs e)
        {

        }

        private void timeEditStartTime_EditValueChanged(object sender, EventArgs e)
        {
            if (!timeEditStartTime.IsModified) return;
            if (timeEditStartTime != null && timeEditEndTime != null && (Convert.ToDateTime(timeEditStartTime.EditValue) <= Convert.ToDateTime(timeEditEndTime.EditValue)))
            {
                if (timeEditStartTime != null && timeEditStartTime.DateTime.Year >= 2016)
                {
                    timeEditStartTime.DateTime = new DateTime(timeEditStartTime.DateTime.Year, timeEditStartTime.DateTime.Month, timeEditStartTime.DateTime.Day, timeEditStartTime.DateTime.Hour, timeEditStartTime.DateTime.Minute, 0, timeEditStartTime.DateTime.Kind);
                    if (timeEditEndTime != null && timeEditEndTime.DateTime.Year >= 2016)
                    {
                        if (this.timeEditStartTime.DateTime < DateTime.Now.AddDays(-2))
                        {
                            return;
                        }
                        timeEditEndTime.DateTime = new DateTime(timeEditEndTime.DateTime.Year, timeEditEndTime.DateTime.Month, timeEditEndTime.DateTime.Day, timeEditEndTime.DateTime.Hour, timeEditEndTime.DateTime.Minute, 0, timeEditEndTime.DateTime.Kind);
                        if (Convert.ToDateTime(timeEditStartTime.DateTime) > Convert.ToDateTime(timeEditEndTime.DateTime))
                        {
                            return;
                        }

                        string strStartTime = this.timeEditStartTime.DateTime.ToString("yyyy-MM-dd hh:mm");
                        string strendTime = this.timeEditEndTime.DateTime.ToString("yyyy-MM-dd hh:mm");
                        DataProcess<object> dataProcess = new DataProcess<object>();
                        dataProcess.ExecuteNoQuery("Update ProductChecking set  StartTime='" + strStartTime + "' where ProductCheckingID = " + currentProductChecking.ProductCheckingID);

                        currentProductChecking.StartTime = this.timeEditStartTime.DateTime;
                        currentProductChecking.EndTime = this.timeEditEndTime.DateTime;
                    }
                }
                //if (isUpdate)
                //{
                //    UpdateRO();
                //}
            }
        }

        private void timeEditEndTime_EditValueChanged(object sender, EventArgs e)
        {
            if (!timeEditEndTime.IsModified) return;
            if (timeEditStartTime != null && timeEditEndTime != null && (Convert.ToDateTime(timeEditStartTime.EditValue) <= Convert.ToDateTime(timeEditEndTime.EditValue)))
            {
                if (timeEditEndTime != null && timeEditEndTime.DateTime.Year >= 2016)
                {
                    timeEditEndTime.DateTime = new DateTime(timeEditEndTime.DateTime.Year, timeEditEndTime.DateTime.Month, timeEditEndTime.DateTime.Day, timeEditEndTime.DateTime.Hour, timeEditEndTime.DateTime.Minute, 0, timeEditEndTime.DateTime.Kind);
                    if (timeEditStartTime != null)
                    {
                        if (this.timeEditEndTime.DateTime > DateTime.Now)
                        {
                            return;
                        }
                        timeEditStartTime.DateTime = timeEditStartTime.DateTime.AddMilliseconds(-timeEditStartTime.DateTime.Second);

                        if (Convert.ToDateTime(timeEditStartTime.DateTime) > Convert.ToDateTime(timeEditEndTime.DateTime))
                        {
                            return;
                        }
                        DateTime strStartTime = Convert.ToDateTime(timeEditStartTime.EditValue);
                        DateTime strendTime = Convert.ToDateTime(timeEditEndTime.EditValue);
                        DataProcess<object> dataProcess = new DataProcess<object>();
                        dataProcess.ExecuteNoQuery("Update ProductChecking set EndTime='" + strendTime.ToString("yyyy-MM-dd hh:mm") + "'" +
                            " where ProductCheckingID = " + currentProductChecking.ProductCheckingID);

                        currentProductChecking.StartTime = strStartTime;
                        currentProductChecking.EndTime = strendTime;
                    }
                    else
                    {
                        return;
                    }
                }

                //if (isUpdate)
                //{
                //    UpdateRO();
                //}
            }


        }

        private void frm_M_ProductCheckingByRequest_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.currentProductChecking == null) return;
            this.grdListPalletByRequest.DataSource = FileProcess.LoadTable("ST_WMS_ProductCheckingByRequestDetails "
                + this.currentProductChecking.ProductCheckingID);
        }

        private void btn_Confirm_ProductChecking_Click(object sender, EventArgs e)
        {
            DataProcess<object> dataProcess = new DataProcess<object>();
            dataProcess.ExecuteNoQuery("Update ProductChecking Set Status=1 Where ProductCheckingID= " + currentProductChecking.ProductCheckingID);
            reloadDataListPC(dtngProductChecking.Position);
        }

        private void btn_UpdatePC_Click(object sender, EventArgs e)
        {
            if (isCreateNew)
            {
                ProductCheckings newPC = new ProductCheckings()
                {
                    ProductCheckingID = 0,
                    ProductCheckingDate = deDateIn.DateTime,
                    CustomerID = Convert.ToInt32(this.lkeCustomerNumber.EditValue),
                    CreatedBy = textPCCreatedBy.EditValue.ToString(),
                    Status = 0
                };
                DataProcess<ProductCheckings> productCheckingDA = new DataProcess<ProductCheckings>();
                int resultInsert = productCheckingDA.Insert(newPC);
                if (resultInsert > 0)
                {
                    isCreateNew = false;

                    //Loại lại dữ liệu cho form
                    productCheckingList = productCheckingDA.Executing("SELECT ProductChecking.*,StoreID FROM dbo.ProductChecking Left JOIN Customers ON ProductChecking.CustomerID=Customers.CustomerID WHERE ProductCheckingDate > GETDATE() - 31 and StoreID= "
                                        + (int)AppSetting.CurrentUser.StoreID).ToList();

                    dtngProductChecking.DataSource = productCheckingList;
                    dtngProductChecking.Position = productCheckingList.Count;
                    currentProductChecking = productCheckingList.ElementAt(productCheckingList.Count - 1);


                }
                else
                    MessageBox.Show("Creating new product checking is failed", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            string strStartTime = timeEditStartTime.DateTime.ToString("yyyy-MM-dd hh:mm");
            string strendTime = timeEditEndTime.DateTime.ToString("yyyy-MM-dd hh:mm");
            string strRemark = this.meRemark.Text.ToString();
            //string slot = this.lke_TimeSlotID.GetColumnValue("TimeSlotID").ToString();
            //string strPCDID = this.grvListPalletByRequest.GetRowCellValue(e.RowHandle, "ProductCheckingDetailID").ToString();
            if (currentProductChecking != null)
            {
                DataProcess<object> dataProcess = new DataProcess<object>();
                dataProcess.ExecuteNoQuery("Update ProductChecking set Remark = N'" + strRemark + "', StartTime='" + strStartTime + "',EndTime='" + strendTime + "'" +
                    " where ProductCheckingID = " + currentProductChecking.ProductCheckingID);
            }

            reloadDataListPC(dtngProductChecking.Position);
        }

        public void reloadDataListPC(int position)
        {
            DataProcess<ProductCheckings> productCheckingDA = new DataProcess<ProductCheckings>();
            //DateTime comparedTimeValue = DateTime.Now.AddDays(-31);
            productCheckingList = productCheckingDA.Executing("SELECT ProductChecking.*,StoreID FROM dbo.ProductChecking Left JOIN Customers ON ProductChecking.CustomerID=Customers.CustomerID WHERE ProductCheckingDate > GETDATE() - 31 and StoreID= "
                                        + (int)AppSetting.CurrentUser.StoreID).ToList();
            //productCheckingsDA.Update(productCheckingList);
            dtngProductChecking.DataSource = productCheckingList;
            dtngProductChecking.Position = position;
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (this.grvListPalletByRequest.DataRowCount > 0)
            {
                XtraMessageBox.Show("Please delete all palletss !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var dl = MessageBox.Show("Are you sure to delete this order?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dl.Equals(DialogResult.No)) return;

                DataProcess<object> dataProcess = new DataProcess<object>();
                dataProcess.ExecuteNoQuery("DELETE FROM ProductChecking WHERE ProductCheckingID = " + currentProductChecking.ProductCheckingID);

                if (this.productCheckingList.Count > 1)
                {
                    reloadDataListPC(productCheckingList.Count);
                }
                else
                {

                }
            }
        }

        private void grvListPalletByRequest_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                bool isDelete = false;
                //int result = -1;
                int[] selectRows = this.grvListPalletByRequest.GetSelectedRows();
                if (selectRows.Count() <= 0) return;

                if (XtraMessageBox.Show("Are you sure to delete pallets ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                DataProcess<object> dataProcess = new DataProcess<object>();
                for (int i = 0; i < selectRows.Count(); ++i)
                {
                    int id = Convert.ToInt32(this.grvListPalletByRequest.GetRowCellValue(selectRows[i], "ProductCheckingDetailID"));
                    dataProcess.ExecuteNoQuery("DELETE FROM ProductCheckingDetails WHERE ProductCheckingDetailID = " + id);
                    isDelete = true;

                }

                if (isDelete)
                {
                    this.grdListPalletByRequest.DataSource = FileProcess.LoadTable("ST_WMS_ProductCheckingByRequestDetails "
                        + this.currentProductChecking.ProductCheckingID);
                    grvListPalletByRequest.RefreshData();
                }
            }
        }

        private void btnViewList_Click(object sender, EventArgs e)
        {
            frm_WM_ProductCheckingList frm = new frm_WM_ProductCheckingList();
            frm.Show();
            frm.BringToFront();
        }

        private void meRemark_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (currentProductChecking != null)
                {
                    string strRemark = this.meRemark.Text.ToString();
                    //string strPCDID = this.grvListPalletByRequest.GetRowCellValue(e.RowHandle, "ProductCheckingDetailID").ToString();
                    DataProcess<object> dataProcess = new DataProcess<object>();
                    dataProcess.ExecuteNoQuery("Update ProductChecking set Remark = N'" + strRemark + "' where ProductCheckingID = " + currentProductChecking.ProductCheckingID);
                    currentProductChecking.Remark = strRemark;
                }

            }
            catch (NullReferenceException ex1)
            {
                //XtraMessageBox.Show(ex1.Message, "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void rpe_hle_PalletID_Click(object sender, EventArgs e)
        {
            int v_ProductID = 0;
            int v_CustomerID = 0;

            try
            {
                v_CustomerID = Convert.ToInt32(this.lkeCustomerNumber.EditValue);
            }
            catch { }

            try
            {
                v_ProductID = Convert.ToInt32(this.grvListPalletByRequest.GetFocusedRowCellValue("ProductID"));
            }
            catch { }

            UI.WarehouseManagement.frm_WM_PalletInfo frm = new UI.WarehouseManagement.frm_WM_PalletInfo(v_CustomerID, v_ProductID);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowInTaskbar = false;
            frm.Show(this);
        }

        private void rpe_hle_ProductID_Click(object sender, EventArgs e)
        {
            int v_ProductID = 0;

            try
            {
                v_ProductID = Convert.ToInt32(this.grvListPalletByRequest.GetFocusedRowCellValue("ProductID"));
            }
            catch { }

            UI.MasterSystemSetup.frm_MSS_Products frm = MasterSystemSetup.frm_MSS_Products.Instance;
            frm.ProductIDLookup = v_ProductID;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.WindowState = FormWindowState.Normal;
            frm.BringToFront();
            frm.ShowInTaskbar = false;
            frm.Show();
        }

        private void dockPanelService_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            if (this.viewService == null)
            {
                this.viewService = new urc_WM_OtherService(txtProductCheckingRecordNumber.Text);
                this.viewService.Parent = this.dockPanelService;
            }
        }

        private void dockPanelEmployee_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            decimal totalPallet = 0;// Convert.ToDecimal(this.gridColumnPallets.SummaryItem.SummaryValue);
            decimal totalWeight = 0;// Convert.ToDecimal(this.gridColumn5.SummaryItem.SummaryValue);
            decimal totalCartons = 0;// Convert.ToDecimal(this.gridColumnTotalPackages.SummaryItem.SummaryValue);
            if (this.viewEmployee == null)
            {
                this.viewEmployee = new urc_WM_EmployeeInfo(txtProductCheckingRecordNumber.Text, totalPallet, totalWeight, totalCartons);
                this.viewEmployee.Parent = this.dockPanelEmployee;
            }
            else
            {
                this.RefreshEmployeeData();
            }
        }

        private void dockPanelNote_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            int roID = this.currentProductChecking.ProductCheckingID;
            string orderType = "PC";
            int customerID = this.lkeCustomerNumber.EditValue == null ? -1 : (int)this.lkeCustomerNumber.EditValue;
            if (this.viewNotes == null)
            {
                this.viewNotes = new urc_WM_Notes(orderType, roID, customerID);
                this.viewNotes.CustomerNumber = this.lkeCustomerNumber.GetColumnValue("CustomerNumber").ToString();
                //this.viewNotes.NoteDescription = this.memoEditTruckAndDetail.Text;
                //this.viewNotes.VehicleNumber = this.textEditVehicleNumber.Text;
                this.viewNotes.Parent = this.dockPanelNote;
            }
            else
            {
                this.RefreshNoteData();
            }
        }

        private void lke_TimeSlotID_EditValueChanged(object sender, EventArgs e)
        {


            if (currentProductChecking != null && this.lke_TimeSlotID.GetColumnValue("TimeSlotID") != null)
            {
                string slot = this.lke_TimeSlotID.GetColumnValue("TimeSlotID").ToString();
                DataProcess<object> dataProcess = new DataProcess<object>();
                dataProcess.ExecuteNoQuery("Update ProductChecking set TimeSlot = " + slot + " where ProductCheckingID = " + currentProductChecking.ProductCheckingID);
                currentProductChecking.TimeSlot = Convert.ToInt16(slot);
            }


        }

        private void btnDeleteDO_Click(object sender, EventArgs e)
        {
            if (this.txt_RelatedOrders.Text == "" || this.txt_RelatedOrders.Text.Substring(0, 7) == "DELETED")
                return;
            if (XtraMessageBox.Show("Are You Sure to Confirm and Delete Related Dispatching Order  ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            DA.DataProcess<object> DP = new DataProcess<object>();
            string sql = "STProductChecking_DODelete " + this.currentProductChecking.ProductCheckingID + ", '" + AppSetting.CurrentUser.LoginName + "' , 'Reverse Dispatching Order'";
            int v_Ret2 = DP.ExecuteNoQuery(sql);
            //if (v_Ret2 > 0)
            //{
            //    XtraMessageBox.Show("Dispatching Orders are Deleted", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    btnDeleteDO.Enabled = false;
            //    btnDeleteDO.Appearance.BackColor = Color.DarkGray;
            //    btnDeleteDO.Appearance.Options.UseBackColor = true;
            //    reloadDataListPC(dtngProductChecking.Position);
            //}

            //else
            //    XtraMessageBox.Show("Error Deleting Dispathching Orders", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            XtraMessageBox.Show("Dispatching Orders are Deleted", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnDeleteDO.Enabled = false;
            btnDeleteDO.Appearance.BackColor = Color.DarkGray;
            btnDeleteDO.Appearance.Options.UseBackColor = true;
            reloadDataListPC(dtngProductChecking.Position);
        }

        private void lkeCustomerNumber_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
        }
    }
}
