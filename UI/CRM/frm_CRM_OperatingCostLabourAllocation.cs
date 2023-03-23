using Common.Controls;
using DA;
using DA.CRM;
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
    public partial class frm_CRM_OperatingCostLabourAllocation : frmBaseForm
    {
        public List<OperatingCostInsertDetails> EDList = new List<OperatingCostInsertDetails>();
        public frm_CRM_OperatingCostLabourAllocation(int MonthID, int StoreID, int EmployeeID)
        {
            InitializeComponent();


            this.lke_OperatingCostMonthlyID.Properties.DataSource = FileProcess.LoadTable("ST_WMS_LoadOperatingCostMonth");
            this.lke_OperatingCostMonthlyID.Properties.ValueMember = "OperatingCostMonthlyID";
            this.lke_OperatingCostMonthlyID.Properties.DisplayMember = "MonthDescription";
            this.lke_OperatingCostMonthlyID.EditValue = MonthID;

            DataProcess<Stores> storeDA = new DataProcess<Stores>();
            this.lke_MSS_StoreList.Properties.DataSource = storeDA.Select();
            this.lke_MSS_StoreList.Properties.ValueMember = "StoreID";
            this.lke_MSS_StoreList.Properties.DisplayMember = "StoreDescription";
            this.lke_MSS_StoreList.EditValue = StoreID;

            
            this.lke_Position.Properties.DataSource = FileProcess.LoadTable("ST_WMS_LoadPositions");
            this.lke_Position.Properties.ValueMember = "PositionID";
            this.lke_Position.Properties.DisplayMember = "PositionDescription";

            int PositionID = -1;
            //var currentEm = AppSetting.CurrentEmployee;
            //PositionID = currentEm.PositionID;

            this.lke_Position.EditValue = PositionID;
            var dataSource = FileProcess.LoadTable("OperatingCostLabourViewByPosition " + MonthID + "," + PositionID + "," + StoreID);
            this.grcEmployeeListByDepartment.DataSource = dataSource;
            var emRow = dataSource.Select("EmployeeID=" + EmployeeID).FirstOrDefault();
            if (emRow != null)
            {
                int index = dataSource.Rows.IndexOf(emRow);
                this.grvEmployeeList.FocusedRowHandle = index;
            }

            this.grcOperatingCostLabourByCustomer.DataSource = FileProcess.LoadTable("OperatingCostLabourViewByEmployeeID " + MonthID + "," + EmployeeID);
        }
        public frm_CRM_OperatingCostLabourAllocation()
        {
            InitializeComponent();


            this.lke_OperatingCostMonthlyID.Properties.DataSource = FileProcess.LoadTable("ST_WMS_LoadOperatingCostMonth");
            this.lke_OperatingCostMonthlyID.Properties.ValueMember = "OperatingCostMonthlyID";
            this.lke_OperatingCostMonthlyID.Properties.DisplayMember = "MonthDescription";
            this.lke_OperatingCostMonthlyID.EditValue = AppSetting.LastOperationMonthID;

            DataProcess<Stores> storeDA = new DataProcess<Stores>();
            this.lke_MSS_StoreList.Properties.DataSource = storeDA.Select();
            this.lke_MSS_StoreList.Properties.ValueMember = "StoreID";
            this.lke_MSS_StoreList.Properties.DisplayMember = "StoreDescription";
            this.lke_MSS_StoreList.EditValue = AppSetting.CurrentUser.StoreID;

            this.lke_Position.Properties.DataSource = FileProcess.LoadTable("ST_WMS_LoadPositions");
            this.lke_Position.Properties.ValueMember = "PositionID";
            this.lke_Position.Properties.DisplayMember = "PositionDescription";
            this.lke_Position.EditValue = 0;

        }

        private void rpe_hlk_ViewByCustomer_Click(object sender, EventArgs e)
        {
            int MonthID = Convert.ToInt32(this.lke_OperatingCostMonthlyID.EditValue.ToString());
            int StoreID = Convert.ToInt32(this.lke_MSS_StoreList.EditValue.ToString());
            int CustomerID = Convert.ToInt32(this.grvLabourCostDetailByCustomer.GetFocusedRowCellValue("CustomerID").ToString());
            frm_CRM_OperatingCostViewByCustomer frm = new frm_CRM_OperatingCostViewByCustomer(MonthID, StoreID, CustomerID);
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront();
        }

        private void btnRefreshGrid_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("OperatingCostLabourViewByPosition " + this.lke_OperatingCostMonthlyID.EditValue + "," + this.lke_Position.EditValue + "," + this.lke_MSS_StoreList.EditValue);
            this.grcEmployeeListByDepartment.DataSource = FileProcess.LoadTable("OperatingCostLabourViewByPosition " + this.lke_OperatingCostMonthlyID.EditValue + "," + this.lke_Position.EditValue + "," + this.lke_MSS_StoreList.EditValue);

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.grcOperatingCostLabourByCustomer.DataSource = FileProcess.LoadTable("OperatingCostLabourViewByEmployeeID " + this.lke_OperatingCostMonthlyID.EditValue.ToString() + "," + this.grvEmployeeList.GetFocusedRowCellValue("EmployeeID"));
        }

        private void lke_Position_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {

        }

        private void lke_Position_EditValueChanged(object sender, EventArgs e)
        {
            this.grcEmployeeListByDepartment.DataSource = FileProcess.LoadTable("OperatingCostLabourViewByPosition " + this.lke_OperatingCostMonthlyID.EditValue + "," + this.lke_Position.EditValue + "," + this.lke_MSS_StoreList.EditValue);
        }

        private void lke_MSS_StoreList_EditValueChanged(object sender, EventArgs e)
        {
            this.grcEmployeeListByDepartment.DataSource = FileProcess.LoadTable("OperatingCostLabourViewByPosition " + this.lke_OperatingCostMonthlyID.EditValue + "," + this.lke_Position.EditValue + "," + this.lke_MSS_StoreList.EditValue);
        }

        private void lke_OperatingCostMonthlyID_Properties_EditValueChanged(object sender, EventArgs e)
        {
            this.grcEmployeeListByDepartment.DataSource = FileProcess.LoadTable("OperatingCostLabourViewByPosition " + this.lke_OperatingCostMonthlyID.EditValue + "," + this.lke_Position.EditValue + "," + this.lke_MSS_StoreList.EditValue);
        }
        DataProcess<OperatingCostLabours> dataProcessoperatingCostLabours = new DataProcess<DA.OperatingCostLabours>();
        private void btn_ImportFile_Click(object sender, EventArgs e)
        {
            frmImportExcelFile frmImport = new frmImportExcelFile();
            frmImport.ShowDialog();
            if (frmImport.ExcelImportSource == null) return;
            this.CreateDataImport(frmImport.ExcelImportSource);
        }
        private void CreateDataImport(DataTable tbSource)
        {
            
            int monthlyID = Convert.ToInt32(this.lke_OperatingCostMonthlyID.EditValue);
            
            DataRow[] listDataExcel = tbSource.Select();
            OperatingCostLabours operatingCostLabours = new OperatingCostLabours();

            //add data colunm remark
            // DataTable remarkList = FileProcess.LoadTable("OperatingCostMonthly_ViewDetails " + monthlyID + "," + this.lke_MSS_StoreList.EditValue.ToString());
            foreach (DataRow row in listDataExcel)
            {
                // kiem tra row trong excel = rong
                if (Convert.IsDBNull(row[0]))
                {
                    LoadData();
                    return;
                }
                operatingCostLabours.EmployeeID = Convert.ToInt32(row[0]);
                operatingCostLabours.OperatingCostMonthlyID = monthlyID;
                operatingCostLabours.LabourCostAmount = Convert.ToDecimal(row[1]);

                int result = dataProcessoperatingCostLabours.Insert(operatingCostLabours);

                if (result < 0)
                {
                    MessageBox.Show("Cannot Insert Data Excel  !", "TPWMS",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                LoadData();
            }
        }
        private void LoadData()
        {
            this.grcEmployeeListByDepartment.DataSource = FileProcess.LoadTable("OperatingCostLabourViewByPosition " + this.lke_OperatingCostMonthlyID.EditValue + "," + this.lke_Position.EditValue + "," + this.lke_MSS_StoreList.EditValue);
        }

        private void grcEmployeeListByDepartment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("You are about to delete a Employee .\n"
              + "If you click Yes, you won't be able to undo this Delete operation.\n"
              + "Do you sure to delete these records ?", "TPWMS",
              MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                 == DialogResult.Yes)
                {
                    

                    int index = this.grvEmployeeList.FocusedRowHandle;
                    int result = dataProcessoperatingCostLabours.ExecuteNoQuery("delete from OperatingCostLabours where EmployeeID={0} and OperatingCostMonthlyID={1} ", Convert.ToInt32(this.grvEmployeeList.GetRowCellValue(index, "EmployeeID")), this.lke_OperatingCostMonthlyID.EditValue);

                    if (result < 0)
                    {
                        MessageBox.Show("Cannot Delete Customer!", "TPWMS",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                LoadData();

            }
        }

        private void grvEmployeeList_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
         
                //int index = this.grvEmployeeList.FocusedRowHandle;
                //int monthID = Convert.ToInt32(this.lke_OperatingCostMonthlyID.EditValue);
                //int idEmployee = Convert.ToInt32(this.grvEmployeeList.GetRowCellValue(index, "EmployeeID"));
                //OperatingCostLabours operatingCostLabours = dataProcessoperatingCostLabours.Select(n => n.EmployeeID == idEmployee && n.OperatingCostMonthlyID== monthID).FirstOrDefault();
                //operatingCostLabours.LabourCostAmount=Convert.ToDecimal(this.grvEmployeeList.GetRowCellValue(index, "LabourCostAmount"));
                //int result = dataProcessoperatingCostLabours.Update(operatingCostLabours);
                //if (result < 0)
                //{
                //    MessageBox.Show("Cannot Update Amount !", "TPWMS",
                //              MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
                //else
                //{
                //    this.grvEmployeeList.SetFocusedRowCellValue("LabourCostAmount", operatingCostLabours.LabourCostAmount);
                //    return;
                //}
            
        }

        private void grvEmployeeList_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            int index = this.grvEmployeeList.FocusedRowHandle;
            int monthID = Convert.ToInt32(this.lke_OperatingCostMonthlyID.EditValue);
            int idEmployee = Convert.ToInt32(this.grvEmployeeList.GetRowCellValue(index, "EmployeeID"));
            OperatingCostLabours operatingCostLabours = dataProcessoperatingCostLabours.Select(n => n.EmployeeID == idEmployee && n.OperatingCostMonthlyID == monthID).FirstOrDefault();
            operatingCostLabours.LabourCostAmount = Convert.ToDecimal(this.grvEmployeeList.GetRowCellValue(index, "LabourCostAmount"));
            int result = dataProcessoperatingCostLabours.Update(operatingCostLabours);
            if (result < 0)
            {
                MessageBox.Show("Cannot Update Amount !", "TPWMS",
                          MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.grvEmployeeList.SetFocusedRowCellValue("LabourCostAmount", operatingCostLabours.LabourCostAmount);
                return;
            }
        }

        private void btnDataEntry_Click(object sender, EventArgs e)
        {
            if (this.btnDataEntry.Text == "Data Entry")
            {
                this.layoutControlDataEntry.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                this.btnDataEntry.Text = "Insert Data";
                this.wmsGridView1.OptionsClipboard.PasteMode = DevExpress.Export.PasteMode.Append;
                EDList.Clear();
                this.grcPasteData.DataSource = new BindingList<OperatingCostInsertDetails>(EDList);
            }

            else
            {

                //Check data validation grid: grcPasteData

                
                //Import Data to the Table


                string varOperatingCostMonthlyID = Convert.ToString(this.lke_OperatingCostMonthlyID.EditValue);
                //string varEmployeeID = "";// assign the value of the CustomerID
                //string varRemark = ""; // assign the value of the Remark
                //string varQuantity = "";
                //string strSql = "OperatingCostLabour_InsertData " + varOperatingCostMonthlyID + "," + varEmployeeID + "," + varQuantity + ",'" + varRemark +
                //    "','" + AppSetting.CurrentUser.LoginName + "'";

                //DataProcess<Stores> ParameterDA = new DataProcess<Stores>();
                //ParameterDA.ExecuteNoQuery(strSql);

                DataProcess<object> dataProcess = new DataProcess<object>();
                foreach (OperatingCostInsertDetails ED in EDList)
                {
                    if (ED.ID.Length > 0 && ED.GrossAmount.Length > 0 && IsDigitsOnly(ED.GrossAmount))
                    {

                        string strSql = "OperatingCostLabour_InsertData " + varOperatingCostMonthlyID + "," + ED.ID + "," + ED.GrossAmount + ",'" + ED.Remark +
                                            "','" + AppSetting.CurrentUser.LoginName + "'";
                        dataProcess.ExecuteNoQuery(strSql);
                    }
                    else
                    {
                        MessageBox.Show("Data error : " + ED.ID + " | " +
                                                    ED.GrossAmount + " | " +
                                                    ED.Remark, "WMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        continue;
                    }
                }



                this.layoutControlDataEntry.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                this.btnDataEntry.Text = "Data Entry";
                LoadData();
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

        private void btnReAllocate_Click(object sender, EventArgs e)
        {
            DataProcess<object> dataProcess = new DataProcess<object>();
            string varOperatingCostMonthlyID = Convert.ToString(this.lke_OperatingCostMonthlyID.EditValue);
            string strSql = "OperatingCostLabour_CreateUpdateDetails " + varOperatingCostMonthlyID + "," + this.lke_MSS_StoreList.EditValue;
            dataProcess.ExecuteNoQuery(strSql);
        }
    }
}
