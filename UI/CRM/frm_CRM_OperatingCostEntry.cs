using Common.Controls;
using DA;
using DA.CRM;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Helper;

namespace UI.CRM
{
    public partial class frm_CRM_OperatingCostEntry : frmBaseForm
    {

        DataProcess<OperatingCostMonthlyDetails> dataProcessOperatingCostMonthlyDetails = new DataProcess<OperatingCostMonthlyDetails>();
        DataProcess<OperatingCostDetailByCustomers> dataProcessOperatingCostDetailByCustomers = new DataProcess<OperatingCostDetailByCustomers>();
        private int costMonthID = 0;
        private int storeID = 0;
        private int detailID = 0;
        public List<OperatingCostInsertDetails> EDList = new List<OperatingCostInsertDetails>();
        public frm_CRM_OperatingCostEntry()
        {
            InitializeComponent();
            this.lke_OperatingCostMonthlyID.Properties.DataSource = FileProcess.LoadTable("ST_WMS_LoadOperatingCostMonth");
            this.lke_OperatingCostMonthlyID.Properties.ValueMember = "OperatingCostMonthlyID";
            this.lke_OperatingCostMonthlyID.Properties.DisplayMember = "MonthDescription";
            
            DataProcess<Stores> storeDA = new DataProcess<Stores>();
            this.lke_MSS_StoreList.Properties.DataSource = storeDA.Select();
            this.lke_MSS_StoreList.Properties.ValueMember = "StoreID";
            this.lke_MSS_StoreList.Properties.DisplayMember = "StoreDescription";
            this.lke_MSS_StoreList.EditValue = AppSetting.CurrentUser.StoreID;

            btn_ImportFile.Enabled = false;
            this.lke_OperatingCostMonthlyID.EditValue = AppSetting.LastOperationMonthID - 1;
            refreshMaingrid();
        }
        public frm_CRM_OperatingCostEntry(int varOperatingCostMonthlyID, int varStoreID)
        {
            InitializeComponent();
            this.costMonthID = varOperatingCostMonthlyID;
            this.storeID = varStoreID;
            this.lke_OperatingCostMonthlyID.Properties.DataSource = FileProcess.LoadTable("ST_WMS_LoadOperatingCostMonth");
            this.lke_OperatingCostMonthlyID.Properties.ValueMember = "OperatingCostMonthlyID";
            this.lke_OperatingCostMonthlyID.Properties.DisplayMember = "MonthDescription";
            this.lke_OperatingCostMonthlyID.EditValue = varOperatingCostMonthlyID;

            DataProcess<Stores> storeDA = new DataProcess<Stores>();
            this.lke_MSS_StoreList.Properties.DataSource = storeDA.Select();
            this.lke_MSS_StoreList.Properties.ValueMember = "StoreID";
            this.lke_MSS_StoreList.Properties.DisplayMember = "StoreDescription";
            this.lke_MSS_StoreList.EditValue = varStoreID;

            this.grcOperatingCostDetails.DataSource = FileProcess.LoadTable("OperatingCostMonthly_ViewDetails " + varOperatingCostMonthlyID + "," + varStoreID);
        }
        private void rpe_hlk_ViewByCustomer_Click(object sender, EventArgs e)
        {
            int MonthID = Convert.ToInt32(this.lke_OperatingCostMonthlyID.EditValue.ToString());
            int StoreID = Convert.ToInt32(this.lke_MSS_StoreList.EditValue.ToString());
            int CustomerID = Convert.ToInt32(this.grvOperatingCostByCustomer.GetFocusedRowCellValue("CustomerID").ToString());
            frm_CRM_OperatingCostViewByCustomer frm = new frm_CRM_OperatingCostViewByCustomer(MonthID, StoreID, CustomerID);
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront();
        }

        private void btnRefreshGrid_Click(object sender, EventArgs e)
        {
            refreshMaingrid();

        }

        private void refreshMaingrid()
        {
            if (this.lke_OperatingCostMonthlyID.EditValue != null && this.lke_MSS_StoreList.EditValue != null)
            {
                this.grcOperatingCostDetails.DataSource = FileProcess.LoadTable("OperatingCostMonthly_ViewDetails " + this.lke_OperatingCostMonthlyID.EditValue + "," + this.lke_MSS_StoreList.EditValue);
                this.grcOperatingCostDetailByCustomer.DataSource = null;
            }
        }

        private void grvOperatingCostDetails_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0) return;
            rowChange();
        }

        private void rowChange()
        {

            this.grcOperatingCostDetailByCustomer.DataSource = FileProcess.LoadTable("OperatingCostMonthly_ViewByOperatingCostMonthlyDetailID " + this.grvOperatingCostDetails.GetFocusedRowCellValue("OperatingCostMonthlyDetailID").ToString());
            btn_ImportFile.Enabled = true;
            if (Convert.ToBoolean(this.grvOperatingCostDetails.GetRowCellValue(this.grvOperatingCostDetails.FocusedRowHandle, "Confirmed")) == true)
            {
                EnableOrNot(false);
            }
            else
            {
                EnableOrNot(true);
            }
            detailID = Convert.ToInt32(this.grvOperatingCostDetails.GetFocusedRowCellValue("OperatingCostMonthlyDetailID"));
        }

        private void btnReAllocate_Click(object sender, EventArgs e)
        {
            DataProcess<object> ParameterDA = new DataProcess<object>();
            int result = -2;
            int varOperatingCostMonthlyID = Convert.ToInt32(this.lke_OperatingCostMonthlyID.EditValue);
            int varStoreID = Convert.ToInt32(this.lke_MSS_StoreList.EditValue);
            result = ParameterDA.ExecuteNoQuery("OperatingCostExpenses_Allocate @OperatingCostMonthlyID = {0}, @StoreID = {1}, @CurrentUser = {2}", varOperatingCostMonthlyID, varStoreID, AppSetting.CurrentUser.LoginName);
            this.grcOperatingCostDetailByCustomer.DataSource = FileProcess.LoadTable("OperatingCostMonthly_ViewByOperatingCostMonthlyDetailID " + this.grvOperatingCostDetails.GetFocusedRowCellValue("OperatingCostMonthlyDetailID").ToString());
        }
        private void LoadOperatingCostDetailByCustomer()
        {
            //if (this.grvOperatingCostDetails.FocusedRowHandle < 0) return;
            //int monthDetailID = Convert.ToInt32(this.grvOperatingCostDetails.GetFocusedRowCellValue("OperatingCostMonthlyDetailID"));
            //this.grcOperatingCostDetailByCustomer.DataSource = FileProcess.LoadTable("OperatingCostMonthly_ViewByOperatingCostMonthlyDetailID " + monthDetailID);
            rowChange();
        }
        private void SetEvent()
        {
            //  btn_ImportFile.Click += Btn_ImportFile_Click;
        }
        void Btn_ImportFile_Click(object sender, EventArgs e)
        {
            // UI.CRM.frm_CRM_OperatingCostEntry_ImportFile frm = new frm_CRM_OperatingCostEntry_ImportFile();
            // if (!frm.Enabled) return;
            //// frm.MyGetEDI_Order = new frm_WM_EDIImportFiles.GetEDI_Orders(GetEDI_Orders);
            // frm.StartPosition = FormStartPosition.CenterScreen;
            // frm.ShowInTaskbar = false;
            // frm.ShowDialog();
            //// LoadData_EDI_Order();
        }
        // private FileTypeImportEnum fileType = FileTypeImportEnum.CustomerClient;
        private void btn_ImportFile_Click_1(object sender, EventArgs e)
        {
            // Code thay the
            frmImportExcelFile frmImport = new frmImportExcelFile();
            frmImport.ShowDialog();

            // sau khi form da dong bam nut create data
            if (frmImport.ExcelImportSource == null) return;

            // co import excel
            this.CreateDataImport(frmImport.ExcelImportSource);

            // update footer
            this.updateAmount();
        }

        private void CreateDataImport(DataTable tbSource)
        {
            //id cua cot ID
            int id = Convert.ToInt32(this.grvOperatingCostDetails.GetFocusedRowCellValue("OperatingCostMonthlyDetailID"));
            int monthlyID = Convert.ToInt32(this.lke_OperatingCostMonthlyID.EditValue);
            int operatingCostID = Convert.ToInt32(this.grvOperatingCostDetails.GetFocusedRowCellValue("OperatingCostID"));
            DataRow[] listDataExcel = tbSource.Select();
            OperatingCostDetailByCustomers operatingCostDetailByCustomers = new OperatingCostDetailByCustomers();
            //add data colunm rate 
            DataTable monlyParmeter = FileProcess.LoadTable("OperatingCostMonthly_ViewParameterByCustomer " + monthlyID + "," + this.lke_MSS_StoreList.EditValue.ToString());

            //add data colunm remark
            DataTable remarkList = FileProcess.LoadTable("OperatingCostMonthly_ViewDetails " + monthlyID + "," + this.lke_MSS_StoreList.EditValue.ToString());

            //add data colunm OperatingCostDetailByCustomerQuantityAdjusted

            switch (operatingCostID)
            {
                case 10:
                    operatingCostDetailByCustomers.OperatingCostDetailByCustomerRemark = "Carton boxes & Transportation";
                    break;
                case 11:
                    operatingCostDetailByCustomers.OperatingCostDetailByCustomerRemark = "Forwarding Expenses";
                    break;
                case 15:
                    operatingCostDetailByCustomers.OperatingCostDetailByCustomerRemark = "Excess";
                    break;
                case 30:
                    operatingCostDetailByCustomers.OperatingCostDetailByCustomerRemark = "Electricity";
                    break;
                default:
                    operatingCostDetailByCustomers.OperatingCostDetailByCustomerRemark = "Clear Data";
                    break;
            }

            foreach (DataRow row in listDataExcel)
            {
                if (Convert.IsDBNull(row[0])) {
                    LoadOperatingCostDetailByCustomer();
                    return;
                }   
                operatingCostDetailByCustomers.CustomerID = Convert.ToInt32(row[0]);
                operatingCostDetailByCustomers.OperatingCostMonthlyDetailID = id;
                operatingCostDetailByCustomers.OperatingCostDetailByCustomerQuantity = Convert.ToDecimal(row[1]);
                //DataRow[] rate = monlyParmeter.Select(string.Format("CustomerID ='{0}' ", Convert.ToInt32(row[0])));
                //foreach (DataRow rowRate in rate)// nếu cái này không có giá trị  mặc định bằng bao nhiêu
                //{
                //    operatingCostDetailByCustomers.OperatingCostDriverRate = Convert.ToDecimal(rowRate[13]);
                //}
                operatingCostDetailByCustomers.OperatingCostDriverRate = 1;
                decimal quantityAdjusted = Convert.ToDecimal(row[1]) * operatingCostDetailByCustomers.OperatingCostDriverRate;
                operatingCostDetailByCustomers.OperatingCostDetailByCustomerQuantityAdjusted = quantityAdjusted;
                int result = dataProcessOperatingCostDetailByCustomers.Insert(operatingCostDetailByCustomers);

                if (result < 0)
                {
                    MessageBox.Show("Cannot Insert Data Excel  !", "TPWMS",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            LoadOperatingCostDetailByCustomer();
        }

        //delete grvOperatingCostCustumer
        private void grvOperatingCostByCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (Convert.ToBoolean(this.grvOperatingCostDetails.GetRowCellValue(this.grvOperatingCostDetails.FocusedRowHandle, "Confirmed")) == false)
            {
                DataProcess<object> dataProcess = new DataProcess<object>();
                string strSQL = "";
                if (e.KeyCode == Keys.Delete)
                {
                    if (MessageBox.Show("Are you sure to delete the expenses ?", "TPWMS",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                     == DialogResult.Yes)
                    {
                        int[] keyValues = grvOperatingCostByCustomer.GetSelectedRows();
                        foreach (int i in keyValues)
                        {
                            strSQL = "DELETE FROM OperatingCostDetailByCustomers WHERE OperatingCostDetailByCustomerID = " + this.grvOperatingCostByCustomer.GetRowCellValue(i, "OperatingCostDetailByCustomerID");
                            dataProcess.ExecuteNoQuery(strSQL);
                            Console.WriteLine(i);
                            //if (result < 0)
                            //{
                            //    MessageBox.Show("Cannot Delete OperatingCostByCustomer!", "TPWMS",
                            //              MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //}
                        }
                    }
                    LoadOperatingCostDetailByCustomer();
                }
            }

        }
        //update grvOperatingCostCustumer
        private void grvOperatingCostByCustomer_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            int idCostCustomer = Convert.ToInt32(this.grvOperatingCostByCustomer.GetFocusedRowCellValue("OperatingCostDetailByCustomerID"));
            OperatingCostDetailByCustomers operatingCostDetailByCustomers = dataProcessOperatingCostDetailByCustomers.Select(n => n.OperatingCostDetailByCustomerID == idCostCustomer).FirstOrDefault();
            SetValueUpdateCustomer(operatingCostDetailByCustomers);
            int result = dataProcessOperatingCostDetailByCustomers.Update(operatingCostDetailByCustomers);
            if (result < 0)
            {
                MessageBox.Show("Cannot Update OperatingCostMonthlyDetails !", "TPWMS",
                          MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.grvOperatingCostByCustomer.SetFocusedRowCellValue("OperatingCostMonthlyDetailRemark", operatingCostDetailByCustomers.OperatingCostDetailByCustomerRemark);
                this.grvOperatingCostByCustomer.SetFocusedRowCellValue("OperatingCostDetailByCustomerQuantityAdjusted", operatingCostDetailByCustomers.OperatingCostDetailByCustomerQuantityAdjusted);
                this.grvOperatingCostByCustomer.SetFocusedRowCellValue("OperatingCostQuantity", operatingCostDetailByCustomers.OperatingCostDetailByCustomerQuantity);
            }
        }
        //update grvOperatingCostDetails

        private void grvOperatingCostDetails_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            int idCostMonthlyDetail = Convert.ToInt32(this.grvOperatingCostDetails.GetFocusedRowCellValue("OperatingCostMonthlyDetailID"));
            OperatingCostMonthlyDetails operatingCostMonthlyDetails = dataProcessOperatingCostMonthlyDetails.Select(n => n.OperatingCostMonthlyDetailID == idCostMonthlyDetail).FirstOrDefault();
            SetValueUpdateDetails(operatingCostMonthlyDetails);
            int result = dataProcessOperatingCostMonthlyDetails.Update(operatingCostMonthlyDetails);
            if (result < 0)
            {
                MessageBox.Show("Cannot Update OperatingCostMonthlyDetails !", "TPWMS",
                          MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.grvOperatingCostDetails.SetFocusedRowCellValue("OperatingCostMonthlyDetailRemark", operatingCostMonthlyDetails.OperatingCostMonthlyDetailRemark);
                this.grvOperatingCostDetails.SetFocusedRowCellValue("OperatingCostQuantity", operatingCostMonthlyDetails.OperatingCostQuantity);

            }
        }

        //set value
        private void SetValueUpdateDetails(OperatingCostMonthlyDetails operatingCostMonthlyDetails)
        {

            operatingCostMonthlyDetails.OperatingCostMonthlyDetailRemark = Convert.ToString(this.grvOperatingCostDetails.GetFocusedRowCellValue("OperatingCostMonthlyDetailRemark"));
            operatingCostMonthlyDetails.OperatingCostQuantity = Convert.ToDecimal(this.grvOperatingCostDetails.GetFocusedRowCellValue("OperatingCostQuantity"));
        }
        private void SetValueUpdateCustomer(OperatingCostDetailByCustomers operatingCostDetailByCustomers)
        {
            decimal quantityAdjusted = Convert.ToDecimal(this.grvOperatingCostByCustomer.GetFocusedRowCellValue("OperatingCostDriverRate")) * Convert.ToDecimal(this.grvOperatingCostByCustomer.GetFocusedRowCellValue("OperatingCostDetailByCustomerQuantity"));
            operatingCostDetailByCustomers.OperatingCostDetailByCustomerQuantityAdjusted = quantityAdjusted;
            operatingCostDetailByCustomers.OperatingCostDetailByCustomerRemark = Convert.ToString(this.grvOperatingCostByCustomer.GetFocusedRowCellValue("OperatingCostDetailByCustomerRemark"));
            operatingCostDetailByCustomers.OperatingCostDetailByCustomerQuantity = Convert.ToDecimal(this.grvOperatingCostByCustomer.GetFocusedRowCellValue("OperatingCostDetailByCustomerQuantity"));
        }

        private void EnableOrNot(Boolean isActive)
        {
            grvOperatingCostByCustomer.OptionsBehavior.ReadOnly = !isActive;
            btn_ImportFile.Enabled = isActive;
            grvOperatingCostByCustomer.OptionsSelection.MultiSelect = isActive;
        }
        //update when footer change
        private void grvOperatingCostByCustomer_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName.Equals("OperatingCostDetailByCustomerQuantity"))
            {
                updateAmount();
            }
        }
        public void updateAmount()
        {
            var dataSource = (DataTable)this.grcOperatingCostDetailByCustomer.DataSource;
            var sum = Convert.ToDecimal(dataSource.Compute("SUM(OperatingCostDetailByCustomerQuantity)", string.Empty));
            int idCostMonthlyDetail = Convert.ToInt32(this.grvOperatingCostDetails.GetFocusedRowCellValue("OperatingCostMonthlyDetailID"));
            OperatingCostMonthlyDetails operatingCostMonthlyDetails = dataProcessOperatingCostMonthlyDetails.Select(n => n.OperatingCostMonthlyDetailID == idCostMonthlyDetail).FirstOrDefault();
            operatingCostMonthlyDetails.OperatingCostQuantity = sum;
            int result = dataProcessOperatingCostMonthlyDetails.Update(operatingCostMonthlyDetails);
            if (result < 0)
            {
                MessageBox.Show("Cannot Update OperatingCostMonthlyDetails !", "TPWMS",
                          MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.grvOperatingCostDetails.SetFocusedRowCellValue("OperatingCostQuantity", operatingCostMonthlyDetails.OperatingCostQuantity);
            }
        }

        private void rpe_ce_Confirmed_Click(object sender, EventArgs e)
        {
            CheckEdit ck = sender as CheckEdit;
            if (MessageBox.Show("You are comfirm?", "TPWMS",
           MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            == DialogResult.Yes)
            {

                if (!ck.Checked)
                {
                    Confirm_D();
                    ck.Checked = true;
                    ck.ReadOnly = true;
                    EnableOrNot(false);
                    return;
                }
                else
                {
                    ck.Checked = false;
                    return;
                }
            }
        }

        private void grvOperatingCostDetails_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (Convert.ToInt32(this.grvOperatingCostDetails.GetRowCellValue(this.grvOperatingCostDetails.FocusedRowHandle, "Confirmed")) == 1)// chua confirm 
            {
                e.Cancel = true;
            }
        }
        //    DataProcess<OperatingCostDefinitions> operatingCostDefinitions = new DataProcess<OperatingCostDefinitions>();
        private void Confirm_D()
        {
            int idCostMonthlyDetail = Convert.ToInt32(this.grvOperatingCostDetails.GetFocusedRowCellValue("OperatingCostMonthlyDetailID"));
            OperatingCostMonthlyDetails operatingCostMonthlyDetails = dataProcessOperatingCostMonthlyDetails.Select(n => n.OperatingCostMonthlyDetailID == idCostMonthlyDetail).FirstOrDefault();
            operatingCostMonthlyDetails.ConfirmedBy = AppSetting.CurrentUser.LoginName;
            operatingCostMonthlyDetails.ConfirmTime = DateTime.Now;
            int result = dataProcessOperatingCostMonthlyDetails.Update(operatingCostMonthlyDetails);
            if (result < 0)
            {
                MessageBox.Show("Cannot Confirm OperatingCostMonthlyDetails !", "TPWMS",
                          MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCreateData_Click(object sender, EventArgs e)
        {
            var result = XtraInputBox.Show("Enter code to process : ", "TPWMS", "0");
            if (!Convert.ToString(result).Equals("210172")) return;
            var source=FileProcess.LoadTable("OperatingCostMonthly_ViewDetails " + this.lke_OperatingCostMonthlyID.EditValue + "," + this.lke_MSS_StoreList.EditValue);
            if(source.Rows.Count>0)
            {
                //MessageBox.Show("Datasource is empty", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //return;
                MessageBox.Show("Can not process; have to input data first", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.costMonthID = (int)this.lke_OperatingCostMonthlyID.EditValue;
            //var findSource = source.Select("OperatingCostQuantity is NULL OR OperatingCostQuantity=0");
            //var find = source.Select();
            //if (findSource.Length > 0)
            //{
            //    MessageBox.Show("Can not process; have to input data first", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            this.dataProcessOperatingCostMonthlyDetails.ExecuteNoQuery("OperatingCostExpenses_CreateData  @OperatingCostMonthlyID={0}", this.lke_OperatingCostMonthlyID.EditValue);
            this.dataProcessOperatingCostMonthlyDetails.ExecuteNoQuery("OperatingCostExpenses_CreateData_2  @OperatingCostMonthlyID={0}", this.lke_OperatingCostMonthlyID.EditValue);
            this.lke_OperatingCostMonthlyID.Properties.DataSource = FileProcess.LoadTable("ST_WMS_LoadOperatingCostMonth");
            this.lke_OperatingCostMonthlyID.Properties.ValueMember = "OperatingCostMonthlyID";
            this.lke_OperatingCostMonthlyID.Properties.DisplayMember = "MonthDescription";
            this.lke_OperatingCostMonthlyID.EditValue = this.costMonthID;

            if (this.lke_OperatingCostMonthlyID.EditValue != null && this.lke_MSS_StoreList.EditValue != null)
            {
                this.grcOperatingCostDetails.DataSource = FileProcess.LoadTable("OperatingCostMonthly_ViewDetails " + this.lke_OperatingCostMonthlyID.EditValue + "," + this.lke_MSS_StoreList.EditValue);
                this.grcOperatingCostDetailByCustomer.DataSource = null;
            }
        }

        private void grvOperatingCostDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (Convert.ToBoolean(this.grvOperatingCostDetails.GetRowCellValue(this.grvOperatingCostDetails.FocusedRowHandle, "Confirmed")) == false)
            {
                DataProcess<object> dataProcess = new DataProcess<object>();
                if (e.KeyCode == Keys.Delete)
                {
                    if (MessageBox.Show("You are about to delete ? .\n"
                  + "If you click Yes, you won't be able to undo this Delete operation.\n"
                  + "Do you sure to delete these records ?", "TPWMS",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                     == DialogResult.Yes)
                    {
                        int[] keyValues = grvOperatingCostDetails.GetSelectedRows();
                        foreach (int i in keyValues)
                        {
                            int result = dataProcess.ExecuteNoQuery("delete from OperatingCostMonthlyDetails where OperatingCostMonthlyDetailID={0}", Convert.ToInt32(this.grvOperatingCostDetails.GetFocusedRowCellValue("OperatingCostMonthlyDetailID")));
                            Console.WriteLine(i);
                            if (result < 0)
                            {
                                MessageBox.Show("Cannot Delete OperatingCostMonthlyDetail!", "TPWMS",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }                            
                        }
                    }
                    if (this.lke_OperatingCostMonthlyID.EditValue != null && this.lke_MSS_StoreList.EditValue != null)
                    {
                        this.grcOperatingCostDetails.DataSource = FileProcess.LoadTable("OperatingCostMonthly_ViewDetails " + this.lke_OperatingCostMonthlyID.EditValue + "," + this.lke_MSS_StoreList.EditValue);
                        this.grcOperatingCostDetailByCustomer.DataSource = null;
                    }
                    LoadOperatingCostDetailByCustomer();
                }
            }
        }

        private void btnDataEntry_Click(object sender, EventArgs e)
        {
            if (this.btnCopyData.Text == "Data Entry")
            {
                this.layoutControlDataEntry.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                this.btnCopyData.Text = "Insert Data";
                this.wmsGridView1.OptionsClipboard.PasteMode = DevExpress.Export.PasteMode.Append;
                EDList.Clear();
                this.grcPasteData.DataSource = new BindingList<OperatingCostInsertDetails>(EDList);
            }

            else
            {

                //Check data validation in the grid  grcPasteData 

                //Import Data to the Table
                //string varOperatingCostDetailID = Convert.ToString(this.grvOperatingCostDetails.GetFocusedRowCellValue("OperatingCostDetailID"));
                //string varCustomerID = "";// assign the value of the CustomerID
                //string varRemark = ""; // assign the value of the Remark
                //string varQuantity = ""; 
                //string strSql = "OperatingCostExpenseByCustomer_InsertData " + varOperatingCostDetailID + "," + varCustomerID + "," + varQuantity + ",'" + varRemark + 
                //    "','" + AppSetting.CurrentUser.LoginName + "'";

                //DataProcess<Stores> ParameterDA = new DataProcess<Stores>();
                //ParameterDA.ExecuteNoQuery(strSql);

                DataProcess<object> dataProcess = new DataProcess<object>();
                foreach (OperatingCostInsertDetails ED in EDList)
                {
                    if (ED.ID.Length > 0  && ED.GrossAmount.Length > 0 && IsDigitsOnly(ED.GrossAmount))
                    {
                        
                        string strSql = "OperatingCostExpenseByCustomer_InsertData " + detailID + "," + ED.ID + "," + ED.GrossAmount + ",'" + ED.Remark +
                                            "','" + AppSetting.CurrentUser.LoginName + "'";
                        dataProcess.ExecuteNoQuery(strSql);
                    }
                    else
                    {
                        MessageBox.Show("Data error : " + ED.ID + " | " +
                                                    ED.GrossAmount + " | " +
                                                    ED.Remark , "WMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        continue;
                    }
                }




                //Change the text of the button and hide the import data grid
                this.layoutControlDataEntry.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                this.btnCopyData.Text = "Data Entry";
                rowChange();
            }
        }

        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        private void grvOperatingCostDetails_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName.Equals("OperatingCostQuantity") || e.Column.FieldName.Equals("OperatingCostMonthlyDetailRemark"))
            {
                DataProcess<Stores> ParameterDA = new DataProcess<Stores>();
                string varOperatingCostDetailID = Convert.ToString(this.grvOperatingCostDetails.GetRowCellValue(e.RowHandle,"OperatingCostDetailID"));
                string varQty = Convert.ToString(this.grvOperatingCostDetails.GetRowCellValue(e.RowHandle, "OperatingCostDetailQuantity"));
                string varRemark = Convert.ToString(this.grvOperatingCostDetails.GetRowCellValue(e.RowHandle, "OperatingCostDetailRemark"));
                ParameterDA.ExecuteNoQuery("OperatingCostExpenses_UpdateDetailData " + varQty + ",'" + varRemark + "','" + AppSetting.CurrentUser.LoginName + "'");
            }
        }

        private void btnElecAllocate_Click(object sender, EventArgs e)
        {
            DataProcess<object> Elec = new DataProcess<object>();
            int result = -2;
            int varOperatingCostMonthlyID = Convert.ToInt32(this.lke_OperatingCostMonthlyID.EditValue);
            int varStoreID = Convert.ToInt32(this.lke_MSS_StoreList.EditValue);
            result = Elec.ExecuteNoQuery("OperatingCostExpenses_AllocateElectricity @OperatingCostMonthlyID = {0}, @StoreID = {1}, @CurrentUser = {2}", varOperatingCostMonthlyID, varStoreID, AppSetting.CurrentUser.LoginName);
            MessageBox.Show("Electricity Cost Allocated !");
            //this.grcOperatingCostDetailByCustomer.DataSource = FileProcess.LoadTable("OperatingCostMonthly_ViewByOperatingCostMonthlyDetailID " + this.grvOperatingCostDetails.GetFocusedRowCellValue("OperatingCostMonthlyDetailID").ToString());
            refreshMaingrid();
        }

        private void btnAllocateTransport_Click(object sender, EventArgs e)
        {
            DataProcess<object> Trns = new DataProcess<object>();
            int result = -2;
            int varOperatingCostMonthlyID = Convert.ToInt32(this.lke_OperatingCostMonthlyID.EditValue);
            int varStoreID = Convert.ToInt32(this.lke_MSS_StoreList.EditValue);
            result = Trns.ExecuteNoQuery("OperatingCostExpenses_AllocateTransport @OperatingCostMonthlyID = {0}, @StoreID = {1}, @CurrentUser = {2}", varOperatingCostMonthlyID, varStoreID, AppSetting.CurrentUser.LoginName);
            MessageBox.Show("Transport Labour and Contractor Cost are Allocated !");
            refreshMaingrid();
            //this.grcOperatingCostDetailByCustomer.DataSource = FileProcess.LoadTable("OperatingCostMonthly_ViewByOperatingCostMonthlyDetailID " + this.grvOperatingCostDetails.GetFocusedRowCellValue("OperatingCostMonthlyDetailID").ToString());
        }

        private void lke_MSS_StoreList_EditValueChanged(object sender, EventArgs e)
        {
            refreshMaingrid();
        }

        private void lke_OperatingCostMonthlyID_EditValueChanged(object sender, EventArgs e)
        {
            refreshMaingrid();
        }
    }
}
