using DA;
using System;
using System.Drawing;
using System.Windows.Forms;
using UI.Helper;
using Common.Controls;


namespace UI.WarehouseManagement
{
    public partial class frm_WM_EDIOrdersViewListDetails : frmBaseForm
    {

        public frm_WM_EDIOrdersViewListDetails()
        {
            InitializeComponent();
            this.dateEditFromDate.EditValue = DateTime.Now.AddDays(-2).ToShortDateString();
            this.dateEditToDate.EditValue = DateTime.Now.ToShortDateString();
            string dateFrom = Convert.ToDateTime(dateEditFromDate.EditValue).Date.ToString("yyyy-MM-dd");
            string dateTo = Convert.ToDateTime(dateEditToDate.EditValue).Date.ToString("yyyy-MM-dd");
            this.lke_Customer.Properties.DataSource = FileProcess.LoadTable("STcomboCustomerID " + AppSetting.StoreID);
            this.lke_Customer.Properties.ValueMember = "CustomerID";
            this.lke_Customer.Properties.DisplayMember = "CustomerNumber";
            this.dateEditFromDate.DateTime = DateTime.Now;
            this.dateEditToDate.DateTime = DateTime.Now;

        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            if (this.lke_Customer.EditValue == null) return;
            //this.grdEDIOrderList.Visible = true;

            string dateFrom = Convert.ToDateTime(dateEditFromDate.EditValue).Date.ToString("yyyy-MM-dd");
            string dateTo = Convert.ToDateTime(dateEditToDate.EditValue).Date.ToString("yyyy-MM-dd");
            this.grdEDIOrderList.DataSource = FileProcess.LoadTable("STEDIOrderViewListDetails @FromDate='" + dateFrom + "',@ToDate='" + dateTo + "', @CustomerID = " + this.lke_Customer.EditValue.ToString());
        }

        private void lke_Customer_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            this.lke_Customer.EditValue = e.Value;
            txtCustomerName.Text = Convert.ToString(lke_Customer.Properties.GetDataSourceValue("CustomerName", lke_Customer.ItemIndex));
        }

        private void repositoryItemHyperLinkEditOrderID_Click(object sender, EventArgs e)
        {
            // Open form RO, DO
            string orderNo = Convert.ToString(this.grvEDIOrderViewList.GetFocusedRowCellValue("ProcessingOrderNumber"));
            if (string.IsNullOrEmpty(orderNo)) return;
            string orderNumber = orderNo.Substring(0, 2);
            int OrderID = Convert.ToInt32(this.grvEDIOrderViewList.GetFocusedRowCellValue("ProcessingOrderNumber").ToString().Substring(3));
            if (orderNumber.ToUpper().Equals("DO"))
            {
                // Display dispatching order
                frm_WM_DispatchingOrders dispatchingOrder = frm_WM_DispatchingOrders.GetInstance(OrderID);
                if (dispatchingOrder.Visible)
                {
                    dispatchingOrder.ReloadData();
                }
                dispatchingOrder.Show();
                dispatchingOrder.Size = new Size(800, 500); // Adjust size of Form to smaller
                dispatchingOrder.WindowState = FormWindowState.Normal;
                dispatchingOrder.StartPosition = FormStartPosition.CenterScreen;
                dispatchingOrder.BringToFront();
            }
            else
            {
                // Display Receiving Order
                frm_WM_ReceivingOrders receivingOrder = frm_WM_ReceivingOrders.Instance;
                receivingOrder.ReceivingOrderIDFind = OrderID;
                receivingOrder.Show();
                receivingOrder.Size = new Size(800, 500); // Adjust size of Form to smaller
                receivingOrder.WindowState = FormWindowState.Normal;
                receivingOrder.StartPosition = FormStartPosition.CenterScreen;
                receivingOrder.BringToFront();
            }
        }

        private void repositoryItemHyperLinkEditEDI_ID_Click(object sender, EventArgs e)
        {
            int ediID = Convert.ToInt32(this.grvEDIOrderViewList.GetFocusedRowCellValue("EDI_OrderID"));
            frm_WM_EDIOrders frm = new frm_WM_EDIOrders(ediID);
            frm.Show();
            frm.WindowState = FormWindowState.Normal;

        }
    }   

        
        

}
