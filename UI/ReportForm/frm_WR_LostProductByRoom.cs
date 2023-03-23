using DA;
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
using UI.WarehouseManagement;

namespace UI.ReportForm
{
    public partial class frm_WR_LostProductByRoom : Form
    {
        public frm_WR_LostProductByRoom()
        {
            InitializeComponent();
            this.grcLostProductByRoom.DataSource = FileProcess.LoadTable("STLostProductByRoom " + AppSetting.StoreID.ToString() + ",'ALL'");
        }

        private void rph_LocationDetails_Click(object sender, EventArgs e)
        {
            WarehouseManagement.frm_WM_Dialog_LocationDetail frm = new WarehouseManagement.frm_WM_Dialog_LocationDetail(Convert.ToInt32(this.grvLostProductByRoom.GetFocusedRowCellValue("PalletID").ToString()), 0,true);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowInTaskbar = false;
            frm.Show(this);
        }

        private void rph_ReceivingOrders_Click(object sender, EventArgs e)
        {
            int receivingOrderID = Convert.ToInt32(this.grvLostProductByRoom.GetFocusedRowCellValue("ReceivingOrderID").ToString());
            frm_WM_ReceivingOrders receivingOrder = frm_WM_ReceivingOrders.Instance;
            receivingOrder.ReceivingOrderIDFind = receivingOrderID;
            receivingOrder.Show();
            receivingOrder.WindowState = FormWindowState.Maximized;
            receivingOrder.BringToFront();
        }

        private void rph_PalletInfo_Click(object sender, EventArgs e)
        {
            int v_CustomerID = 0;
            int v_ProductID = 0;

            try
            {
                v_CustomerID = Convert.ToInt32(grvLostProductByRoom.GetFocusedRowCellValue("CustomerID"));
            }
            catch { }

            try
            {
                v_ProductID = Convert.ToInt32(grvLostProductByRoom.GetFocusedRowCellValue("ProductID"));
            }
            catch { }

            UI.WarehouseManagement.frm_WM_PalletInfo frm = new WarehouseManagement.frm_WM_PalletInfo(v_CustomerID, v_ProductID);
            frm.ShowInTaskbar = false;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show(this);
        }
    }
}
