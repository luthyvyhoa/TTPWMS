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
    public partial class frm_WR_OperationPlanning_OrderReview : Form
    {
        private frm_WM_TripsManagement frmTrip = null;

        public frm_WR_OperationPlanning_OrderReview()

        {
            InitializeComponent();
            this.dateEditReportDate.EditValue = DateTime.Now.ToShortDateString();
            this.lke_WarehouseID.Properties.DataSource = FileProcess.LoadTable("SELECT WarehouseID, WarehouseDescription From Warehouses WHERE StoreID = " + AppSetting.StoreID);
            this.lke_WarehouseID.Properties.ValueMember = "WarehouseID";
            this.lke_WarehouseID.Properties.DisplayMember = "WarehouseDescription";
            this.lke_WarehouseID.ItemIndex = 0;
            //this.grcOrderReview.DataSource = FileProcess.LoadTable("STOperationPLanning_ReviewOrders " + AppSetting.StoreID + ",'" + Convert.ToDateTime(DateTime.Now).Date.ToString("yyyy-MM-dd") + "'");

        }

        private void rhl_Order_Click(object sender, EventArgs e)
        {
            //Open form RO/DO/Trip


            // Detected current order is Dispatching or Trip
            string orderNo = Convert.ToString(this.grvOrderReview.GetRowCellValue(this.grvOrderReview.FocusedRowHandle, "OrderNumber"));
            if (string.IsNullOrEmpty(orderNo)) return;
            string orderNumber = orderNo.Substring(0, 2);
            int orderID = Convert.ToInt32(orderNo.Substring(3, orderNo.Length-3));
            //int receivingOrderID = Convert.ToInt32(this.grvOrderReview.GetRowCellValue(this.grvOrderReview.FocusedRowHandle, "OrderID").ToString());
            if (orderNumber.ToUpper().Equals("RO"))
            {
                frm_WM_ReceivingOrders receivingOrder = frm_WM_ReceivingOrders.Instance;
                receivingOrder.ReceivingOrderIDFind = orderID;
                receivingOrder.Show();
                receivingOrder.WindowState = FormWindowState.Maximized;
                receivingOrder.BringToFront();
                return;
            }

            if (orderNumber.ToUpper().Equals("DO"))
            {
                // Display disptching order
                frm_WM_DispatchingOrders dispatchingOrder = frm_WM_DispatchingOrders.GetInstance(orderID);
                if (dispatchingOrder.Visible)
                {
                    dispatchingOrder.ReloadData();
                }
                dispatchingOrder.Show();
                dispatchingOrder.WindowState = FormWindowState.Maximized;
                dispatchingOrder.BringToFront();
            }
            else
            {
                // Display trip managerment
                if (this.frmTrip == null)
                {
                    this.frmTrip = new frm_WM_TripsManagement(orderID);
                }
                else
                {
                    this.frmTrip.ReloadData(orderID);
                }
                this.frmTrip.Show();
                this.frmTrip.WindowState = FormWindowState.Maximized;
                this.frmTrip.BringToFront();
            }
        }

        private void dateEditReportDate_EditValueChanged(object sender, EventArgs e)
        {
            UpdateData();
        }
        private void UpdateData()
        {
            this.grcOrderReview.DataSource = FileProcess.LoadTable("STOperationPLanning_ReviewOrders " + AppSetting.StoreID + ",'" + Convert.ToDateTime(dateEditReportDate.EditValue).Date.ToString("yyyy-MM-dd") + "'," + lke_WarehouseID.EditValue);
            this.chartTimeSlotReview.DataSource = FileProcess.LoadTable("STOperationPLanning_ReviewOrderSummary " + AppSetting.StoreID + ",'" + Convert.ToDateTime(dateEditReportDate.EditValue).Date.ToString("yyyy-MM-dd") + "'," + lke_WarehouseID.EditValue);
        }

        private void lke_WarehouseID_EditValueChanged(object sender, EventArgs e)
        {
            UpdateData();
        }
    }
}
