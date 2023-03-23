using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.WarehouseManagement;

namespace UI.ReportForm
{
    public partial class frm_BR_Dialog_BillingDateOrders : Form
    {
        /// <summary>
        /// Flag=1 : load data STBillingDateOrders
        /// Flag=2 : STBillingDateOrdersByBreakdownID
        /// </summary>
        /// <param name="BillingDateID">int</param>
        /// <param name="CustomerID">int</param>
        /// <param name="flag">int</param>
        /// 
        private frm_WM_TripsManagement frmTrip = null;
        public frm_BR_Dialog_BillingDateOrders(int BillingDateID, int CustomerID, int flag = 1)
        {
            InitializeComponent();
            if (flag == 1)
            {
                string qry = "STBillingDateOrders @BillingDateID=" + BillingDateID + ",@CustomerID = " + CustomerID;
                this.grdOvertimeOrders.DataSource = DA.FileProcess.LoadTable(qry);
            }
            else
            {
                string qry = "STBillingDateOrdersByBreakdownID @BillingDetailBreakdownID=" + BillingDateID + ",@CustomerID = " + CustomerID;
                this.grdOvertimeOrders.DataSource = DA.FileProcess.LoadTable(qry);
            }

        }

        private void rpe_OrderID_DoubleClick(object sender, EventArgs e)
        {
            int index = this.grvOvertimeOrdersTableView.FocusedRowHandle;
            string test1 = Convert.ToString(this.grvOvertimeOrdersTableView.GetGroupRowValue(index));
            string test2 = Convert.ToString(this.grvOvertimeOrdersTableView.GetGroupRowDisplayText(1));
           
            string orderNo = Convert.ToString(this.grvOvertimeOrdersTableView.GetRowCellValue(this.grvOvertimeOrdersTableView.FocusedRowHandle, "OrderType"));
            if (string.IsNullOrEmpty(orderNo)) return;
            string orderNumber = orderNo.Substring(0, 2);
            int receivingOrderID = Convert.ToInt32(this.grvOvertimeOrdersTableView.GetRowCellValue(this.grvOvertimeOrdersTableView.FocusedRowHandle, "OrderID").ToString());
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
            else
            {
                  //int receivingOrderID = Convert.ToInt32(this.grV_WM_ControlRO.GetRowCellValue(this.grV_WM_ControlRO.FocusedRowHandle, "ReceivingOrderID").ToString());
                  frm_WM_ReceivingOrders receivingOrder = frm_WM_ReceivingOrders.Instance;
                  receivingOrder.ReceivingOrderIDFind = receivingOrderID;
                  receivingOrder.Show();
                  receivingOrder.WindowState = FormWindowState.Maximized;
                  receivingOrder.BringToFront();
            }
        }
    }
}
