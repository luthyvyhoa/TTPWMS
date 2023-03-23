using Common.Controls;
using DA;
using DA.Management;
using DA.Warehouse;
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
using UI.ReportFile;
using UI.WarehouseManagement;

namespace UI.Admin
{
    public partial class frm_AD_SafetyClothes : frmBaseForm
    {

        private List<SafetyClothes> SCList;
        private int storeID;
        private int SCID;
        private SafetyClothes currentSC;
        private SafetyClothes saveCurrentSC;
        private List<SafetyClotheDetail> SCDetailsList;
        private DataTable safeSource = null;
        private int savePsosition = 0;
        private int currentSafetyID = 0;
        private int safetyIDFind = 0;
        public frm_AD_SafetyClothes()
        {
            this.safetyIDFind = 0;
            InitializeComponent();
            LoadStore();
            LoadEmployee();
            LoadParts();
            ClothesEnquiryList();
        }

        public frm_AD_SafetyClothes(int SCEnquiryID)
        {
            this.safetyIDFind = SCEnquiryID;
            InitializeComponent();
            LoadStore();
            LoadEmployee();
            LoadParts();
            ClothesEnquiryList();
            //Load SafetyClothEnquiryID here
        }
        private void LoadStore()
        {
            DataProcess<Stores> storeDA = new DataProcess<Stores>();
            this.lke_stores.Properties.DataSource = storeDA.Select();
            this.lke_stores.Properties.ValueMember = "StoreID";
            this.lke_stores.Properties.DisplayMember = "StoreDescription";
            this.lke_stores.EditValue = AppSetting.CurrentUser.StoreID;

            this.lke_OperatingCostMonthlyID.Properties.DataSource = FileProcess.LoadTable("ST_WMS_LoadOperatingCostMonth");
            this.lke_OperatingCostMonthlyID.Properties.ValueMember = "OperatingCostMonthlyID";
            this.lke_OperatingCostMonthlyID.Properties.DisplayMember = "MonthDescription";
        }
        private void ClothesEnquiryList()
        {
            using (PlantDBContext context = new PlantDBContext())
            {
                this.safeSource = context.GetComboStoreNo("SP_SafetyClothesEnquiryList " + AppSetting.StoreID);
                if (this.safeSource == null || this.safeSource.Rows.Count <= 0) return;

                int resourceFindIndex = 0;
                if (this.safetyIDFind > 0)
                {
                    var dataFind = this.safeSource.Select("SafetyClothesEnquiryID=" + this.safetyIDFind).FirstOrDefault();
                    if (dataFind != null) resourceFindIndex = this.safeSource.Rows.IndexOf(dataFind);
                }
                this.dtngSafetyClothes.DataSource = this.safeSource;
                this.dtngSafetyClothes.Position = resourceFindIndex;

                var currentRecord = this.safeSource.Rows[this.dtngSafetyClothes.Position];
                this.currentSafetyID = Convert.ToInt32(currentRecord["SafetyClothesEnquiryID"]);
                this.txtSCRecordNumber.EditValue = currentRecord["SafetyClothesEnquiryNumber"];// currentRecord["SafetyClothesEnquiryID"];
                this.txtOrderBy.EditValue = currentRecord["CreatedBy"];
                this.lke_stores.EditValue = currentRecord["StoreID"];
                this.lke_employees.EditValue = currentRecord["EmployeeID"];
                this.txt_employeeName.Text = lke_employees.EditValue.ToString();

                this.txt_createdBy.EditValue = currentRecord["CreatedBy"];
                this.txt_createdTime.EditValue = currentRecord["CreatedTime"];
                this.lke_date.EditValue = currentRecord["EnquiryDate"];
                this.mm_remark.EditValue = currentRecord["EnquiryRemark"];
                this.txt_transactionID.EditValue = currentRecord["SafetyClothesEnquiryID"];
                SCID = Convert.ToInt32(this.txt_transactionID.Text);
                // Load sagfety details
                this.ClothesEnquiryDetail(this.currentSafetyID);
                //dtngSafetyClothes.Position = ((IList<SafetyClothes>)dtngSafetyClothes.DataSource).Count;

            }
        }

        private void ClothesEnquiryList(int po)
        {
            using (PlantDBContext context = new PlantDBContext())
            {
                this.safeSource = context.GetComboStoreNo("SP_SafetyClothesEnquiryList " + AppSetting.StoreID);
                this.dtngSafetyClothes.DataSource = this.safeSource;


                this.dtngSafetyClothes.Position = po;
                //dtngSafetyClothes.Position = ((IList<SafetyClothes>)dtngSafetyClothes.DataSource).Count;

            }
        }

        private void ClothesEnquiryDetail(int safetyID)
        {
            using (PlantDBContext context = new PlantDBContext())
            {
                this.grcSafetyClotheDetail.DataSource = context.GetComboStoreNo("ST_LoadSafetyDetailByID @SafetyID=" + safetyID);
            }
        }

        private void LoadParts()
        {
            using (PlantDBContext context = new PlantDBContext())
            {
                this.rpi_lke_part.DataSource = context.GetComboStoreNo("SELECT DISTINCT Parts.PartID, Parts.PartName FROM Parts ORDER BY Parts.PartName");
                this.rpi_lke_part.DropDownRows = 20;
                this.rpi_lke_part.DisplayMember = "PartID";
                this.rpi_lke_part.ValueMember = "PartID";
            }
        }

        private void LoadEmployee()
        {

            DataProcess<Employees> dataProcess = new DataProcess<Employees>();
            //this.lkeAccountingStatus.Properties.DataSource = dataProcess.Select();
            this.lke_employees.Properties.DataSource = FileProcess.LoadTable("ST_WMS_LoadEmployees " + AppSetting.StoreID);
            this.lke_employees.Properties.ValueMember = "EmployeeID";
            this.lke_employees.Properties.DisplayMember = "VietnamName";
            lke_employees.Properties.DropDownRows = 20;

            //lke_employees.Properties.DataSource = AppSetting.EmployessList;
            //int employeeCount = AppSetting.EmployessList.Count();
            //if (employeeCount > 20)
            //    lke_employees.Properties.DropDownRows = 20;
            //else
            //    lke_employees.Properties.DropDownRows = employeeCount;
            //lke_employees.Properties.DisplayMember = "VietnamName";
            //lke_employees.Properties.ValueMember = "EmployeeID";

            lke_employees.EditValue = AppSetting.CurrentUser.EmployeeID;

        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {

        }

        private void btn_confirm_Click(object sender, EventArgs e)
        {

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            var confirmMsg = MessageBox.Show("Do you want to delete this SafetyClothes?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmMsg.Equals(DialogResult.No)) return;
            using (PlantDBContext context = new PlantDBContext())
            {
                int po = this.dtngSafetyClothes.Position;
                int h = context.Delete("delete SafetyClothesEnquiry where SafetyClothesEnquiryID= " + SCID);
                ClothesEnquiryList(po - 1);
                //this.dtngSafetyClothes.Position = po;
            }
        }
        private void dtngSafetyClothes_PositionChanged(object sender, EventArgs e)
        {
            if (this.dtngSafetyClothes.Position < 0) return;
            var currentRecord = this.safeSource.Rows[this.dtngSafetyClothes.Position];

            this.currentSafetyID = Convert.ToInt32(currentRecord["SafetyClothesEnquiryID"]);
            this.txtSCRecordNumber.EditValue = currentRecord["SafetyClothesEnquiryNumber"];
            this.txtOrderBy.EditValue = currentRecord["CreatedBy"];
            this.lke_stores.EditValue = currentRecord["StoreID"];
            this.lke_employees.EditValue = currentRecord["EmployeeID"];
            this.txt_employeeName.Text = lke_employees.EditValue.ToString();

            this.txt_createdBy.EditValue = currentRecord["CreatedBy"];
            this.txt_createdTime.EditValue = currentRecord["CreatedTime"];
            this.lke_date.EditValue = currentRecord["EnquiryDate"];
            this.mm_remark.EditValue = currentRecord["EnquiryRemark"];
            this.txt_transactionID.EditValue = currentRecord["SafetyClothesEnquiryID"];
            SCID = Convert.ToInt32(this.txt_transactionID.Text);
            // Load sagfety details
            this.ClothesEnquiryDetail(this.currentSafetyID);
        }
        private void btn_NewSC_Click(object sender, EventArgs e)
        {
            //grcPODetail.DataSource = new BindingList<PurchasingOrderDetail>(new List<PurchasingOrderDetail>());
            //txtPORecordNumber.Text = "";
            //this.lkeSupplier.Focus();
            //this.lkeSupplier.ShowPopup();
            using (PlantDBContext context = new PlantDBContext())
            {
                int po = this.dtngSafetyClothes.Position;
                int h = context.Delete("insert into SafetyClothesEnquiry(EmployeeID,EnquiryDate,CreatedBy,CreatedTime,StoreID) values (" +
                    AppSetting.CurrentUser.EmployeeID + ",'" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + AppSetting.CurrentUser.LoginName + "','"
                    + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "'," + AppSetting.StoreID + ")");
                //if (h<0)
                //{

                //}
                ClothesEnquiryList(po + 1);
            }
        }
        //private void AddNewRow()
        //{
        //    var newSafetyClotheDetail = new SafetyClotheDetail();
        //    newSafetyClotheDetail.SafetyClothesEnquiryID = Convert.ToInt32(this.txt_transactionID);
        //    newSafetyClotheDetail.SafetyClothesEnquiryDetailID = 0;
        //    this.clients.Add(newSafetyClotheDetail);

        //}
        private void grvSafetyClotheDetails_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int SafetyClothesEnquiryDetailID = 0;
            SafetyClothesEnquiryDetailID = Convert.ToInt32(this.grvSafetyClotheDetails.GetFocusedRowCellValue("SafetyClothesEnquiryDetailID"));
            string name = Convert.ToString(this.grvSafetyClotheDetails.GetFocusedRowCellValue("PartName"));
            if (name != null & name != "")
            //if (SafetyClothesEnquiryDetailID > 0)
            {
                DataProcess<SafetyClotheDetail> SafetyClotheDetailDA = new DataProcess<SafetyClotheDetail>();
                string query = string.Format(" Update SafetyClothesEnquiryDetails Set {0}=N'{1}' Where SafetyClothesEnquiryDetailID={2}", e.Column.FieldName, e.Value, SafetyClothesEnquiryDetailID);
                SafetyClotheDetailDA.ExecuteNoQuery(query);
            }
            else
            {
                int PartID = Convert.ToInt32(this.grvSafetyClotheDetails.GetFocusedRowCellValue("PartID"));
                //string PartName = Convert.ToString(this.grvSafetyClotheDetails.GetFocusedRowCellValue("PartName"));
                if (PartID < 0) return;
                using (PlantDBContext context = new PlantDBContext())
                {
                    int h = context.Delete("insert into SafetyClothesEnquiryDetails(PartID,SafetyClothesEnquiryID) values (" + PartID + "," + SCID + ")");
                    //if (h<0)
                    //{

                    //}

                }
            }
            this.ClothesEnquiryDetail(SCID);
        }

        private void grvSafetyClotheDetails_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void grvSafetyClotheDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.KeyCode.Equals(Keys.Delete)) return;
            if (this.grvSafetyClotheDetails.SelectedRowsCount <= 0) return;



            var confirmMsg = MessageBox.Show("Do you want to delete this part?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmMsg.Equals(DialogResult.No)) return;

            int SafetyClothesEnquiryDetailID = 0;
            SafetyClothesEnquiryDetailID = Convert.ToInt32(this.grvSafetyClotheDetails.GetFocusedRowCellValue("SafetyClothesEnquiryDetailID"));
            using (PlantDBContext context = new PlantDBContext())
            {
                //var SafetyClotheDetail = (SafetyClotheDetail)this.grvSafetyClotheDetails.GetFocusedRow();
                //if (SafetyClotheDetail == null) return;
                int h = context.Delete("delete SafetyClothesEnquiryDetails where SafetyClothesEnquiryDetailID= " + SafetyClothesEnquiryDetailID);
                //if (h<0)
                //{

                //}

            }
            this.ClothesEnquiryDetail(SCID);
        }

        private void mm_remark_EditValueChanged(object sender, EventArgs e)
        {
            if (mm_remark.IsModified)
            {
                using (PlantDBContext context = new PlantDBContext())
                {
                    int po = this.dtngSafetyClothes.Position;
                    int h = context.Delete("update SafetyClothesEnquiry set EnquiryRemark= N'" + mm_remark.Text + "' where SafetyClothesEnquiryID= " + SCID);
                    ClothesEnquiryList(po);
                    //this.dtngSafetyClothes.Position = po;
                }
            }
        }

        private void lke_date_EditValueChanged(object sender, EventArgs e)
        {
            if (lke_date.IsModified)
            {
                using (PlantDBContext context = new PlantDBContext())
                {
                    int po = this.dtngSafetyClothes.Position;
                    var d = lke_date.DateTime.ToString("yyyy-MM-dd");
                    int h = context.Delete("update SafetyClothesEnquiry set EnquiryDate= '" + d + "' where SafetyClothesEnquiryID= " + SCID);
                    ClothesEnquiryList(po);
                    //this.dtngSafetyClothes.Position = po;
                }
            }
        }

        private void lke_employees_EditValueChanged(object sender, EventArgs e)
        {
            if (lke_employees.IsModified)
            {
                this.txt_employeeName.Text = lke_employees.EditValue.ToString();
                using (PlantDBContext context = new PlantDBContext())
                {
                    int po = this.dtngSafetyClothes.Position;
                    int h = context.Delete("update SafetyClothesEnquiry set EmployeeID=" + Convert.ToInt32(lke_employees.EditValue) + " where SafetyClothesEnquiryID= " + SCID);
                    ClothesEnquiryList(po);
                    //this.dtngSafetyClothes.Position = po;
                }
            }
        }

        private void btnReview_Click(object sender, EventArgs e)
        {
            frm_AD_SafetyClothesReview frm = new frm_AD_SafetyClothesReview(this.currentSafetyID);
            frm.Show();
            frm.BringToFront();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            showMovementReport();
        }

        private void lke_OperatingCostMonthlyID_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {


        }
        private void showMovementReport()
        {
            if (this.deFromDate.DateTime == null || this.deToDate.DateTime == null)
                return;

            rptSafetyClothesStockMovement rpt2 = new rptSafetyClothesStockMovement();
            //rpt2.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
            using (PlantDBContext context = new PlantDBContext())
            {
                string stt = "SP_SafetyClothesMovementReport '" + this.deFromDate.DateTime.ToString("yyyy-MM-dd") + "','" +
                    this.deToDate.DateTime.ToString("yyyy-MM-dd") + "'," + this.lke_stores.EditValue;
                rpt2.DataSource = context.GetComboStoreNo(stt);
                rpt2.RequestParameters = false;
            }

            ReportPrintToolWMS printTool2 = new ReportPrintToolWMS(rpt2);
            printTool2.AutoShowParametersPanel = false;
            printTool2.ShowPreview();

        }

        private void lke_OperatingCostMonthlyID_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            this.deFromDate.DateTime = Convert.ToDateTime(this.lke_OperatingCostMonthlyID.Properties.GetDataSourceValue("FromDate", lke_OperatingCostMonthlyID.ItemIndex));
            this.deToDate.DateTime = Convert.ToDateTime(this.lke_OperatingCostMonthlyID.Properties.GetDataSourceValue("Todate", lke_OperatingCostMonthlyID.ItemIndex));

            //string tt = this.lke_OperatingCostMonthlyID.GetColumnValue("FromDate").ToString();
            showMovementReport();
        }

        // attchment
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.F3)
            {
                frm_WM_Attachments.Instance.OrderNumber = this.txtSCRecordNumber.Text;
                if (frm_WM_Attachments.Instance.Enabled) frm_WM_Attachments.Instance.ShowDialog();
            }
            return base.ProcessDialogKey(keyData);
        }
    }
}
