using DA;
using DevExpress.XtraEditors;
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
using UI.MasterSystemSetup;
using UI.WarehouseManagement;
using DA;

namespace UI.ReportForm
{
    public partial class frm_WR_OvertimeOrders : Form
    {
        public frm_WR_OvertimeOrders()
        {
            InitializeComponent();

            this.dateEditFromDate.EditValue = DateTime.Now.AddDays(-2);
            this.dateEditToDate.EditValue = DateTime.Now;

            string dateFrom = Convert.ToDateTime(dateEditFromDate.EditValue).Date.ToString("yyyy-MM-dd");
            string dateTo = Convert.ToDateTime(dateEditToDate.EditValue).Date.ToString("yyyy-MM-dd");
            //this.lke_Customer.Properties.DataSource = FileProcess.LoadTable("STcomboCustomerMainID " + AppSetting.StoreID);
            //this.lke_Customer.Properties.ValueMember = "CustomerID";
            //this.lke_Customer.Properties.DisplayMember = "CustomerNumber";
            this.grdOvertimeOrders.DataSource = FileProcess.LoadTable("STOvertimeOrders @FromDate='" + dateFrom + "',@ToDate='" + dateTo + "', @StoreID = " + AppSetting.StoreID);
        }

        private void rpe_OrderID_Click(object sender, EventArgs e)
        {
            string orderNo = Convert.ToString(this.grvOvertimeOrdersTableView.GetRowCellValue(this.grvOvertimeOrdersTableView.FocusedRowHandle, "OrderNumber"));
            if (string.IsNullOrEmpty(orderNo)) return;
            string orderNumber = orderNo.Substring(0, 2);
            int OrderID = Convert.ToInt32(this.grvOvertimeOrdersTableView.GetRowCellValue(this.grvOvertimeOrdersTableView.FocusedRowHandle, "OrderID").ToString());
            if (orderNumber.ToUpper().Equals("DO"))
            {
                // Display disptching order
                frm_WM_DispatchingOrders dispatchingOrder = frm_WM_DispatchingOrders.GetInstance(OrderID);
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
                // Display Receiving Order
                frm_WM_ReceivingOrders receivingOrder = frm_WM_ReceivingOrders.Instance;
                receivingOrder.ReceivingOrderIDFind = OrderID;
                receivingOrder.Show();
                receivingOrder.WindowState = FormWindowState.Maximized;
                receivingOrder.BringToFront();
            }
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            string dateFrom = Convert.ToDateTime(dateEditFromDate.EditValue).Date.ToString("yyyy-MM-dd");

            string dateTo = Convert.ToDateTime(dateEditToDate.EditValue).Date.ToString("yyyy-MM-dd");
            //this.grdOvertimeOrders.DataSource = DA.FileProcess.LoadTable("STOvertimeOrders @FromDate='" + dateFrom + "',@ToDate='" + dateTo + "', @StoreID = " + AppSetting.StoreID + "', @CustomerID = " + this.lke_Customer.EditValue);
            this.grdOvertimeOrders.DataSource = DA.FileProcess.LoadTable("STOvertimeOrders @FromDate='" + dateFrom + "',@ToDate='" + dateTo + "', @StoreID = " + AppSetting.StoreID);
        }

        private void rpe_CustomerID_Click(object sender, EventArgs e)
        {
            int CustomerID = Convert.ToInt32(grvOvertimeOrdersTableView.GetRowCellValue(this.grvOvertimeOrdersTableView.FocusedRowHandle, "CustomerID").ToString());
            if (CustomerID <= 0) return;
            frm_MSS_Contracts frm = frm_MSS_Contracts.GetInstance(CustomerID);
            frm.InitData(CustomerID);
            frm.Show();
        }

        private void grvOvertimeOrdersTableView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Column.FieldName)) return;
            int customerID = Convert.ToInt32(this.grvOvertimeOrdersTableView.GetFocusedRowCellValue("CustomerID"));
            DateTime orderDate = Convert.ToDateTime(this.grvOvertimeOrdersTableView.GetFocusedRowCellValue("OrderDate"));
            DataProcess<STVSServicesDefinitionListForLookup_Result> cc = new DataProcess<STVSServicesDefinitionListForLookup_Result>();
            var list = cc.Executing("STVSServicesDefinitionListForLookup @CustomerID = {0},@OrderDate={1}", customerID, orderDate);
            this.rpi_lke_Services.DataSource = list;
            this.rpi_lke_Services.DisplayMember = "ServiceNumber";
            this.rpi_lke_Services.ValueMember = "ServiceID";
            this.grvOvertimeOrdersTableView.ShowEditor();
            if (grvOvertimeOrdersTableView.ActiveEditor != null)
                ((LookUpEdit)grvOvertimeOrdersTableView.ActiveEditor).ShowPopup();
        }

        private void rpi_lke_Services_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.Value == null) return;
            string orderNumber = Convert.ToString(this.grvOvertimeOrdersTableView.GetFocusedRowCellValue("OrderNumber"));
            if (string.IsNullOrEmpty(orderNumber)) return;

            var currentService = (STVSServicesDefinitionListForLookup_Result)rpi_lke_Services.GetDataSourceRowByKeyValue(e.Value);
            if (currentService == null) return;
            DataProcess<object> dataProcess = new DataProcess<object>();
            string orderType = orderNumber.Split('-')[0];
            int orderID = Convert.ToInt32(orderNumber.Split('-')[1]);
            switch (orderType)
            {
                case "RO":
                    dataProcess.ExecuteNoQuery("Update ReceivingOrders Set HandlingOvertimeCategoryID={0} Where ReceivingOrderID={1}", currentService.ServiceID, orderID);
                    break;
                case "DO":
                    dataProcess.ExecuteNoQuery("Update DispatchingOrders Set HandlingOvertimeCategoryID={0} Where DispatchingOrderID={1}", currentService.ServiceID, orderID);
                    break;
            }
            var dataSource = (DataTable)this.grdOvertimeOrders.DataSource;
            dataSource.Columns["ServiceNumber"].ReadOnly = false;
            dataSource.Columns["ServiceName"].ReadOnly = false;
            this.grvOvertimeOrdersTableView.SetFocusedRowCellValue("ServiceNumber", currentService.ServiceNumber);
            this.grvOvertimeOrdersTableView.SetFocusedRowCellValue("ServiceName", currentService.ServiceName);
            this.grvOvertimeOrdersTableView.RefreshData();
        }
    }
}
