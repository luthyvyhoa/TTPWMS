using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DA;
using UI.Helper;

namespace UI.WarehouseManagement
{
    public partial class urc_WM_ROAllocateTo1Location : UserControl
    {
        private int productID = 0;
        private int roID = 0;
        public urc_WM_ROAllocateTo1Location(int productID, int roID)
        {
            InitializeComponent();
            this.productID = productID;
            this.roID = roID;

            // Init data
            this.InitData();
            //Set datasource of the LookupEdit based on the first product of the list ProductID
        }

        /// <summary>
        /// Pallet will change to
        /// </summary>
        public STVSPalletAllocation_Result PalletTarget
        {
            get;
            private set;
        }

        private void InitData()
        {
            // Get first product
            var product = AppSetting.ProductList.Where(c => c.ProductID == this.productID).FirstOrDefault();
            if (product != null)
            {
                var palletAllLocationDA = new DA.DataProcess<DA.STVSPalletAllocation_Result>();
                var listLocation = (List<STVSPalletAllocation_Result>)palletAllLocationDA.Executing("STVSPalletAllocation @ReceivingOrderID={0},@ProductID={1},@HomeRoom1={2},@HomeRoom2={3},@Type={4},@StoreID={5}",
                      this.roID, this.productID, product.HomeRoom1, product.HomeRoom2, "A", AppSetting.StoreID);
                this.lke_LocationID.Properties.DataSource = listLocation;
                this.lke_LocationID.Properties.DisplayMember = "LocationID";
                this.lke_LocationID.Properties.ValueMember = "LocationID";
            }
        }


        private void lke_LocationID_EditValueChanged(object sender, EventArgs e)
        {
            STVSPalletAllocation_Result dataSelected = (STVSPalletAllocation_Result)this.lke_LocationID.GetSelectedDataRow();
            if (dataSelected == null) return;
            this.textEditLocationNumber.Text = dataSelected.LocationNumber;
            this.PalletTarget = dataSelected;
        }
    }
}
