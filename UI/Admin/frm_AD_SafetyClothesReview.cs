using DA;
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

namespace UI.Admin
{
    public partial class frm_AD_SafetyClothesReview : Form
    {
        private int propertyID = 0;
        public frm_AD_SafetyClothesReview()
        {
            InitializeComponent();
            LoadControlData();
            this.deFromDate.DateTime = DateTime.Today.AddDays(-90);
            this.deToDate.DateTime = DateTime.Today;
            LoadStore();
            this.lkeEmployeeName.Properties.DataSource = FileProcess.LoadTable("SELECT EmployeeID, VietnamName FROM Employees WHERE StoreID = " + AppSetting.CurrentUser.StoreID 
                + " AND Active = 1 ORDER BY EmployeeID" );
            this.lkeEmployeeName.Properties.ValueMember = "EmployeeID";
            this.lkeEmployeeName.Properties.DisplayMember = "VietnamName";
        }


        public frm_AD_SafetyClothesReview(int PropertyID)
        {
            InitializeComponent();
            LoadControlData();
            propertyID = PropertyID;
            this.deFromDate.DateTime = DateTime.Today.AddDays(-90);
            this.deToDate.DateTime = DateTime.Today;
            LoadStore();
            LoadGrids();
            
        }

        private void LoadStore()
        {
            DataProcess<Stores> storeDA = new DataProcess<Stores>();
            this.lke_MSS_StoreList.Properties.DataSource = storeDA.Select();
            this.lke_MSS_StoreList.Properties.ValueMember = "StoreID";
            this.lke_MSS_StoreList.Properties.DisplayMember = "StoreDescription";
            this.lke_MSS_StoreList.EditValue = AppSetting.CurrentUser.StoreID;
        }

        private void LoadControlData()
        {

            this.lkeProperty.Properties.DataSource = FileProcess.LoadTable("SELECT Parts.PartID, Parts.PartName, Parts.CategoryID FROM  Parts " +
                "WHERE (((Parts.CategoryID)=6 Or (Parts.CategoryID)=19)) ORDER BY Parts.PartName;");
            this.lkeProperty.Properties.ValueMember = "PartID";
            this.lkeProperty.Properties.DisplayMember = "PartName";
            this.lkeProperty.EditValue = propertyID;

        }

        private void LoadGrids()
        {
            int storeID = 0;
            storeID = Convert.ToInt32(this.lke_MSS_StoreList.EditValue);
            if (storeID == 0) storeID = 1; 

            using (PlantDBContext context = new PlantDBContext())
            {

                string yyy = "SP_ItemReview " + propertyID + ",'PO'," + storeID + ",'" +
                    this.deFromDate.DateTime.ToString("yyyy-MM-dd") + "','" + this.deToDate.DateTime.ToString("yyyy-MM-dd") + "'";
                this.grcItemReview_PO.DataSource = context.GetComboStoreNo(yyy);
            }

            using (PlantDBContext context2 = new PlantDBContext())
            {
                string xxx = "SP_SafetyClothesEnquirySummary " + propertyID + "," + storeID + ",'" +
                    this.deFromDate.DateTime.ToString("yyyy-MM-dd") + "','" + this.deToDate.DateTime.ToString("yyyy-MM-dd") + "'";
                this.grcItemReview_Enquiry.DataSource = context2.GetComboStoreNo(xxx);
            }
        }
        private void lkeProperty_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            propertyID = Convert.ToInt32(this.lkeProperty.EditValue);
            LoadGrids();
        }

        private void hle_CashID_Click(object sender, EventArgs e)
        {
            int pettycashID = Convert.ToInt32(this.grvItemReview_Cash.GetFocusedRowCellValue("PettyCashID"));
            frm_AD_PettyCash frm = new frm_AD_PettyCash(pettycashID);
            frm.Show();
            frm.BringToFront();
        }

        private void hle_PurchasingOrderID_Click(object sender, EventArgs e)
        {
            int purchasingOrderID = Convert.ToInt32(this.grvItemReview_PO.GetFocusedRowCellValue("PurchasingOrderID"));
            frm_AD_PurchasingOrders frm = new frm_AD_PurchasingOrders(purchasingOrderID);
            frm.Show();
            frm.BringToFront();
        }

        private void hle_EnquiryID_Click(object sender, EventArgs e)
        {
            int SCEnquiryID = Convert.ToInt32(this.grvItemReview_Cash.GetFocusedRowCellValue("SafetyClothesEnquiryID"));
            frm_AD_SafetyClothes frm = new frm_AD_SafetyClothes(SCEnquiryID);
            frm.Show();
            frm.BringToFront();
        }

        private void lke_MSS_StoreList_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            LoadGrids();
            this.lkeEmployeeName.Properties.DataSource = FileProcess.LoadTable("SELECT EmployeeID, VietnamName FROM Employees WHERE StoreID = " + AppSetting.CurrentUser.StoreID
    + " AND Active = 1 ORDER BY EmployeeID");
        }

        private void lkeEmployeeName_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            LoadGridByEmployee();

        }
        private void LoadGridByEmployee()
        {
            using (PlantDBContext context2 = new PlantDBContext())
            {
                string xxx = "SP_SafetyClothesEnquiryByEmployeeID " + this.lkeEmployeeName.EditValue + ",'" +
                    this.deFromDate.DateTime.ToString("yyyy-MM-dd") + "','" + this.deToDate.DateTime.ToString("yyyy-MM-dd") + "'";
                this.grcItemReview_Enquiry.DataSource = context2.GetComboStoreNo(xxx);
            }
        }
    }
}
