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

namespace UI.StockTake
{
    public partial class frm_ST_StockOnHandOneCustomerKGRCheck : Form
    {
        //private int varCustomerID = 0;
        public frm_ST_StockOnHandOneCustomerKGRCheck(int CustomerID)
        {
            InitializeComponent();

            this.lkeCustomerNumber.Properties.DataSource = FileProcess.LoadTable("STComboCustomerIDRandomWeight " + AppSetting.StoreID);

            this.lkeCustomerNumber.Properties.DisplayMember = "CustomerNumber";
            this.lkeCustomerNumber.Properties.ValueMember = "CustomerID";
            this.lkeCustomerNumber.EditValue = CustomerID;
            this.deTripDate.EditValue = DateTime.Today;

            //if (lkeCustomerNumber.GetColumnValue("CustomerName") != null)
            //    teCustomerName.Text = lkeCustomerNumber.GetColumnValue("CustomerName").ToString();
            if (CustomerID == 0)
                return;
            refreshGrid();
        }

        private void refreshGrid()
        {
            string reportDate = Convert.ToDateTime(deTripDate.EditValue).Date.ToString("yyyy-MM-dd 00:00:00");
            this.grcStockOnHandKGRCheck.DataSource = FileProcess.LoadTable("STStockOnHandOneCustomerKGRCheck " + this.lkeCustomerNumber.EditValue);
            this.grcOrderByDate.DataSource = FileProcess.LoadTable("STStockDispatchedKGRCheck " + this.lkeCustomerNumber.EditValue + ",'" + reportDate + "'");
        }

        private void rpe_hle_PalletID_Click(object sender, EventArgs e)
        {
            int v_ProductID = 0;
            int v_CustomerID = 0;

            try
            {
                v_CustomerID = Convert.ToInt32(this.grvStockOnHandKGRCheck.GetFocusedRowCellValue("CustomerID"));
            }
            catch { }

            try
            {
                v_ProductID = Convert.ToInt32(this.grvStockOnHandKGRCheck.GetFocusedRowCellValue("ProductID"));
            }
            catch { }

            UI.WarehouseManagement.frm_WM_PalletInfo frm = new UI.WarehouseManagement.frm_WM_PalletInfo(v_CustomerID, v_ProductID);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowInTaskbar = false;
            frm.Show(this);
        }

        private void rpe_hle_ROID_Click(object sender, EventArgs e)
        {
            int receivingOrderID = Convert.ToInt32(this.grvStockOnHandKGRCheck.GetFocusedRowCellValue("ReceivingOrderID"));
            frm_WM_ReceivingOrders receivingOrder = frm_WM_ReceivingOrders.Instance;
            receivingOrder.ReceivingOrderIDFind = receivingOrderID;
            receivingOrder.Show();
            receivingOrder.WindowState = FormWindowState.Maximized;
            receivingOrder.BringToFront();
        }

        private void rpe_hle_ProductID_Click(object sender, EventArgs e)
        {
            int v_ProductID = 0;

            try
            {
                v_ProductID = Convert.ToInt32(this.grvStockOnHandKGRCheck.GetFocusedRowCellValue("ProductID"));
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

        private void lkeCustomerNumber_EditValueChanged(object sender, EventArgs e)
        {
            if (lkeCustomerNumber.GetColumnValue("CustomerName") != null)
                teCustomerName.Text = lkeCustomerNumber.GetColumnValue("CustomerName").ToString();
            refreshGrid();
        }

        private void deTripDate_EditValueChanged(object sender, EventArgs e)
        {
            string reportDate = Convert.ToDateTime(deTripDate.EditValue).Date.ToString("yyyy-MM-dd 00:00:00");
            this.grcOrderByDate.DataSource = FileProcess.LoadTable("STStockDispatchedKGRCheck " + this.lkeCustomerNumber.EditValue + ",'" + reportDate + "'");
        }

        private void rpe_DispatchingOrderID_Click(object sender, EventArgs e)
        {
            if (this.grvOrderByDate.GetFocusedRowCellValue("DispatchingOrderID") == null)
                return;

            string DispatchingOrderID = this.grvOrderByDate.GetFocusedRowCellValue("DispatchingOrderID").ToString();
            frm_WM_DispatchingOrders DispatchingOrdersForm = frm_WM_DispatchingOrders.GetInstance(int.Parse(DispatchingOrderID));
            if (DispatchingOrdersForm.Visible)
            {
                DispatchingOrdersForm.ReloadData();
            }
            DispatchingOrdersForm.Show();
        }

        private void rpe_PalletID_Click(object sender, EventArgs e)
        {
            int v_ProductID = 0;
            int v_CustomerID = 0;

            try
            {
                v_CustomerID = Convert.ToInt32(this.grvStockOnHandKGRCheck.GetFocusedRowCellValue("CustomerID"));
            }
            catch { }

            try
            {
                v_ProductID = Convert.ToInt32(this.grvStockOnHandKGRCheck.GetFocusedRowCellValue("ProductID"));
            }
            catch { }

            UI.WarehouseManagement.frm_WM_PalletInfo frm = new UI.WarehouseManagement.frm_WM_PalletInfo(v_CustomerID, v_ProductID);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowInTaskbar = false;
            frm.Show(this);
        }
    }
}
