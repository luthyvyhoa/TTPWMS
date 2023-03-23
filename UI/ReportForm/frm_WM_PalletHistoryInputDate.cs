using Common.Controls;
using DA;
using System;
using System.Windows.Forms;
using UI.WarehouseManagement;
using DA;
using DevExpress.XtraGrid.Views.Grid;

namespace UI.ReportForm
{
    public partial class frm_WM_PalletHistoryInputDate : frmBaseForm
    {
        private int productID = 0;
        public frm_WM_PalletHistoryInputDate(int productIDSelected)
        {
            InitializeComponent();
            this.dInputDate.EditValue = DateTime.Now;
            this.productID = productIDSelected;

            // Init date default
            this.dInputDate.DateTime = DateTime.Now.AddDays(-30);

            // Init data source
            this.InitData();
        }

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            if (this.dInputDate.EditValue == null) ;
            this.grvPalletHistoryDataTableView.ShowPrintPreview();
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void InitData()
        {
            string orderDate = this.dInputDate.DateTime.ToString("yyyy-MM-dd");
            var dataSource = FileProcess.LoadTable("STPalletInforReportHistory @varProductID=" + productID + ",@ReceivingOrderDate='" + orderDate + "'");

            this.grcPalletHistoryData.DataSource = dataSource;
            this.grcProductInformationHistoryOrders.DataSource = FileProcess.LoadTable("WebProductInformationInOut @ProductID=" + productID + ", @varFromDate='" + orderDate + "'");
        }

        private void dInputDate_EditValueChanged(object sender, EventArgs e)
        {
            this.InitData();
        }

        private void dInputDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.KeyCode.Equals(Keys.Enter)) return;
            this.InitData();
        }

        private void rp_hle_DispatchingOrderID_Click(object sender, EventArgs e)
        {
            int handleIndex = this.grvPalletHistoryDataTableView.FocusedRowHandle;
            int DispatchingOrderID = Convert.ToInt32(grvPalletHistoryDataTableView.GetRowCellValue(handleIndex, "DispatchingOrderID").ToString());
            frm_WM_DispatchingOrders form = frm_WM_DispatchingOrders.GetInstance(DispatchingOrderID);
            form.Show();
            form.WindowState = FormWindowState.Maximized;
            form.BringToFront();
        }

        private void rp_hle_ReceivingOrderID_Click(object sender, EventArgs e)
        {
            int handleIndex = this.grvPalletHistoryDataTableView.FocusedRowHandle;
            int ReceivingOrderID = Convert.ToInt32(grvPalletHistoryDataTableView.GetRowCellValue(handleIndex, "ReceivingOrderID").ToString());
            frm_WM_ReceivingOrders form = frm_WM_ReceivingOrders.Instance;
            form.ReceivingOrderIDFind = ReceivingOrderID;
            form.Show();
        }

        private void checkShowAllRemainingPallets_CheckedChanged(object sender, EventArgs e)
        {
                 string orderDate = this.dInputDate.DateTime.ToString("yyyy-MM-dd");
            if (this.checkShowAllRemainingPallets.Checked)
            {

                this.grcPalletHistoryData.DataSource = FileProcess.LoadTable("STPalletInforReportHistory @varProductID=" + productID + ",@ReceivingOrderDate='" + orderDate + "'");
            }
            else
            {
                this.grcPalletHistoryData.DataSource = FileProcess.LoadTable("STPalletInforReportHistory @varProductID=" + productID);
            }
        }

        private void grvPalletHistoryDataTableView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName != "RO_Remain_Kgs") return;
            GridView view = (GridView)sender;
            int firstRowHandle = view.GroupCount == 0 ? 0 : view.GetChildRowHandle(view.GetParentRowHandle(e.GroupRowHandle), 0);
            decimal qta = Convert.ToInt32(view.GetRowCellValue(0, colRO_kgs));
            for (int i = firstRowHandle; i <= e.GroupRowHandle; i++)
                qta = qta - Convert.ToInt32(view.GetRowCellValue(i, colDO_Kgs));
            e.DisplayText = qta.ToString();
        }

        private void repositoryItemHyperLinkEdit1_Click(object sender, EventArgs e)
        {
            string orderNo = Convert.ToString(this.grvProductHistoryOrders.GetRowCellValue(this.grvProductHistoryOrders.FocusedRowHandle, "OrderNumber"));
            if (string.IsNullOrEmpty(orderNo)) return;
            string orderNumber = orderNo.Substring(0, 2);
            string idOrder = orderNo.Substring(3);
            int receivingOrderID = Convert.ToInt32(idOrder.ToString());
            if (orderNumber.ToUpper().Equals("DO"))
            {
                // Display disptching order
                frm_WM_DispatchingOrders dispatchingOrder = frm_WM_DispatchingOrders.GetInstance(receivingOrderID);
                if (dispatchingOrder.Visible)
                {
                    dispatchingOrder.ReloadData();
                }
                dispatchingOrder.Show();
                dispatchingOrder.WindowState = FormWindowState.Maximized;
                dispatchingOrder.BringToFront();
            }
            if (orderNumber.ToUpper().Equals("RO"))
            {
                // Display Reciving order
                frm_WM_ReceivingOrders receivingOrder = frm_WM_ReceivingOrders.Instance;
                receivingOrder.ReceivingOrderIDFind = receivingOrderID;
                receivingOrder.Show();
                receivingOrder.WindowState = FormWindowState.Maximized;
                receivingOrder.BringToFront();
            }
        }
    }
}
