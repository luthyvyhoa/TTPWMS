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
    public partial class frm_AD_ItemReview : Form
    {
        private int propertyID = 0;
        public frm_AD_ItemReview()
        {
            InitializeComponent();
            LoadControlData();
        }

        public frm_AD_ItemReview(int PropertyID)
        {
            InitializeComponent();
            LoadControlData();
            propertyID = PropertyID;
            LoadGrids();
            this.lkeProperty.EditValue = PropertyID;
        }

        private void LoadControlData()
        {
            DataProcess<Stores> storeDA = new DataProcess<Stores>();
            this.lke_MSS_StoreList.Properties.DataSource = storeDA.Select();
            this.lke_MSS_StoreList.Properties.ValueMember = "StoreID";
            this.lke_MSS_StoreList.Properties.DisplayMember = "StoreDescription";
            this.lke_MSS_StoreList.EditValue = AppSetting.CurrentUser.StoreID;

            this.lkeProperty.Properties.DataSource = FileProcess.LoadTable("ST_WMS_LoadPlantDBParts");
            this.lkeProperty.Properties.ValueMember = "PartID";
            this.lkeProperty.Properties.DisplayMember = "PartName";
            this.lkeProperty.EditValue = propertyID;

        }

        private void LoadGrids()
        {
            int storeID = 0;
            storeID = Convert.ToInt32(this.lke_MSS_StoreList.EditValue);

            using (PlantDBContext context = new PlantDBContext())
            {

                this.grcItemReview_PO.DataSource = context.GetComboStoreNo("SP_ItemReview " + propertyID + ",'PO'," + storeID);

                
            }

            using (PlantDBContext context2 = new PlantDBContext())
            {

                this.grcItemReview_Cash.DataSource = context2.GetComboStoreNo("SP_ItemReview " + propertyID + ",'CP'," + storeID);
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
    }
}
