using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Controls;
using System.Windows.Forms;
using DA;
using UI.Helper;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_PalletCartonDetails : frmBaseForm
    {
        /// <summary>
        /// Flag:1=>palletID,2=>productID
        /// 
        /// </summary>
        /// <param name="orderID">int</param>
        /// <param name="flag">int</param>
        public frm_WM_PalletCartonDetails(int orderID, int flag, int customerID)
        {
            InitializeComponent();
            this.lke_Products.Properties.DataSource = AppSetting.ProductList.Where(p => p.CustomerID == customerID);
            this.lke_Products.Properties.DisplayMember = "ProductNumber";
            this.lke_Products.Properties.ValueMember = "ProductID";
            this.grdPalletCartonDetails.DataSource = FileProcess.LoadTable("STCartonDetails @OrderID=" + orderID + ",@Type=" + flag);
        }

        private void rpi_lke_DO_Click(object sender, EventArgs e)
        {
            int v_DispatchingOrderID = 0;
            try
            {
                v_DispatchingOrderID = Convert.ToInt32(grvPalletCartonDetails.GetRowCellValue(grvPalletCartonDetails.FocusedRowHandle, "DispatchingOrderID"));
            }
            catch { }

            WarehouseManagement.frm_WM_DispatchingOrders frm = frm_WM_DispatchingOrders.GetInstance(v_DispatchingOrderID);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowInTaskbar = false;
            frm.Show();
            frm.BringToFront();
        }

        private void rpi_lke_RO_Click(object sender, EventArgs e)
        {
            int v_ReceivingOrderID = 0;

            try
            {
                v_ReceivingOrderID = Convert.ToInt32(grvPalletCartonDetails.GetRowCellValue(grvPalletCartonDetails.FocusedRowHandle, "ReceivingOrderID"));
            }
            catch { }

            WarehouseManagement.frm_WM_ReceivingOrders frm = frm_WM_ReceivingOrders.Instance;
            frm.ReceivingOrderIDFind = v_ReceivingOrderID;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowInTaskbar = false;
            frm.Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (this.lke_Products.EditValue == null) return;
            this.grdPalletCartonDetails.DataSource = FileProcess.LoadTable("STCartonDetails " + this.lke_Products.EditValue + ",2");
        }

        private void rpi_lke_PalletID_Click(object sender, EventArgs e)
        {
            int v_PalletID = 0;

            try
            {
                v_PalletID = Convert.ToInt32(grvPalletCartonDetails.GetRowCellValue(grvPalletCartonDetails.FocusedRowHandle, "PalletID"));
            }
            catch { }
            if (v_PalletID > 0)
            {
                frm_WM_Dialog_StockMovementReview frm = new frm_WM_Dialog_StockMovementReview(v_PalletID);
                if (!frm.Enabled) return;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowInTaskbar = false;
                frm.ShowDialog();
            }
        }
    }
}
