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
using DA;
using DevExpress.XtraCharts;
using UI.WarehouseManagement;

namespace UI.Supperviors
{
    public partial class frm_S_EmployeeDailyPerformance : Form
    {
        private int EID = 0;
        public frm_S_EmployeeDailyPerformance()
        {
            InitializeComponent();

            //lkeEmployeeID.Properties.DataSource = AppSetting.EmployessList;
            //int employeeCount = AppSetting.EmployessList.Count();
            //if (employeeCount > 20)
            //    lkeEmployeeID.Properties.DropDownRows = 20;
            //else
            //    lkeEmployeeID.Properties.DropDownRows = employeeCount;
            //lkeEmployeeID.Properties.DisplayMember = "EmployeeID";
            //lkeEmployeeID.Properties.ValueMember = "EmployeeID";
            //lkeEmployeeID.Enabled = true;


            DataProcess<Stores> storeDA = new DataProcess<Stores>();
            this.lke_MSS_StoreList.Properties.DataSource = storeDA.Select();
            this.lke_MSS_StoreList.Properties.ValueMember = "StoreID";
            this.lke_MSS_StoreList.Properties.DisplayMember = "StoreDescription";
            this.lke_MSS_StoreList.EditValue = AppSetting.StoreID;

            this.txtReportDate.EditValue = DateTime.Today;
            string rptDate = DateTime.Today.ToString("yyyy-MM-dd");

            this.grcEmployeePerformanceAll.DataSource = FileProcess.LoadTable("STEmployeeWorkingDailyPerformanceAll '" + rptDate + "'," + this.lke_MSS_StoreList.EditValue);
            
        }

        private void grvEmployeePerformanceAll_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
           // if (this.grvEmployeePerformanceAll.GetFocusedRowCellValue("EmployeeID") == null) return;
            int varEmployeeID = Convert.ToInt16(this.grvEmployeePerformanceAll.GetFocusedRowCellValue("EmployeeID"));
            string rptDate = Convert.ToDateTime(txtReportDate.EditValue).Date.ToString("yyyy-MM-dd");
            this.grcEmployeePerformanceOne.DataSource = FileProcess.LoadTable("STEmployeeWorkingDailyPerformanceDetails '" + rptDate + "'," + varEmployeeID);
            this.chartEmployeePerformanceOne.DataSource = FileProcess.LoadTable("STEmployeeWorkingDailyPerformanceOne '" + rptDate + "'," + varEmployeeID);
            this.grcEmployeeeWorkingOrders.DataSource = FileProcess.LoadTable("STEmployeeWorkingDailyPerformanceOrders '" + rptDate + "'," + varEmployeeID);

            //int varEmployeeID = Convert.ToInt16(value: lkeEmployeeID.GetColumnValue("EmployeeID").ToString());
            this.EID = varEmployeeID;
            this.grcEmployeePerformanceByID.DataSource = FileProcess.LoadTable("STEmployeeWorkingDailyPerformanceByID  " + varEmployeeID);
        }

        private void txtReportDate_Properties_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            
            ////string rptDate = Convert.ToDateTime(txtReportDate.EditValue).Date.ToString("yyyy-MM-dd");
            //this.grcEmployeePerformanceAll.DataSource = FileProcess.LoadTable("STEmployeeWorkingDailyPerformanceAll '" + rptDate + "'," + AppSetting.StoreID);
        }

        private void txtReportDate_EditValueChanged(object sender, EventArgs e)
        {
            string rptDate = Convert.ToDateTime(txtReportDate.EditValue).Date.ToString("yyyy-MM-dd");
            this.grcEmployeePerformanceAll.DataSource = FileProcess.LoadTable("STEmployeeWorkingDailyPerformanceAll '" + rptDate + "'," + this.lke_MSS_StoreList.EditValue);
        }

        private void rpe_hle_OrderID_Click(object sender, EventArgs e)
        {
            string orderNumber = Convert.ToString(this.grvEmployeePerformanceOne.GetFocusedRowCellValue("OrderNumber"));
            var orderType = orderNumber.Split('-');
            int orderID = Convert.ToInt32(orderType[1]);
            switch (orderType[0])
            {
                case "RO":
                    frm_WM_ReceivingOrders receivingOrder = frm_WM_ReceivingOrders.Instance;
                    receivingOrder.ReceivingOrderIDFind = orderID;
                    receivingOrder.Show();
                    receivingOrder.WindowState = FormWindowState.Maximized;
                    receivingOrder.BringToFront();
                    break;
                case "DO":
                    // Display disptching order
                    frm_WM_DispatchingOrders dispatchingOrder = frm_WM_DispatchingOrders.GetInstance(orderID);
                    if (dispatchingOrder.Visible)
                    {
                        dispatchingOrder.ReloadData();
                    }
                    dispatchingOrder.Show();
                    dispatchingOrder.WindowState = FormWindowState.Maximized;
                    dispatchingOrder.BringToFront();
                    break;
                default:
                    break;
            }
        }

        private void rpe_hle_OrderID2_Click(object sender, EventArgs e)
        {
            string orderNumber = Convert.ToString(this.grvEmplyeeWorkingOrders.GetFocusedRowCellValue("OrderNumber"));
            var orderType = orderNumber.Split('-');
            int orderID = Convert.ToInt32(orderType[1]);
            switch (orderType[0])
            {
                case "RO":
                    frm_WM_ReceivingOrders receivingOrder = frm_WM_ReceivingOrders.Instance;
                    receivingOrder.ReceivingOrderIDFind = orderID;
                    receivingOrder.Show();
                    receivingOrder.WindowState = FormWindowState.Maximized;
                    receivingOrder.BringToFront();
                    break;
                case "DO":
                    // Display disptching order
                    frm_WM_DispatchingOrders dispatchingOrder = frm_WM_DispatchingOrders.GetInstance(orderID);
                    if (dispatchingOrder.Visible)
                    {
                        dispatchingOrder.ReloadData();
                    }
                    dispatchingOrder.Show();
                    dispatchingOrder.WindowState = FormWindowState.Maximized;
                    dispatchingOrder.BringToFront();
                    break;
                default:
                    break;
            }
        }

        private void btnViewPerformanceSummary_Click(object sender, EventArgs e)
        {
            frm_S_EmployeeDailyPerformanceSummary frm = new frm_S_EmployeeDailyPerformanceSummary();
            frm.Show();
            frm.WindowState = FormWindowState.Normal;
        }

        private void lke_MSS_StoreList_Properties_EditValueChanged(object sender, EventArgs e)
        {
            string rptDate = Convert.ToDateTime(txtReportDate.EditValue).Date.ToString("yyyy-MM-dd");
            this.grcEmployeePerformanceAll.DataSource = FileProcess.LoadTable("STEmployeeWorkingDailyPerformanceAll '" + rptDate + "'," + this.lke_MSS_StoreList.EditValue);
        }

        private void lkeEmployeeID_EditValueChanged(object sender, EventArgs e)
        {
            //if (lkeEmployeeID.EditValue != null && lkeEmployeeID.GetColumnValue("VietnamName") != null)
            //    txtEmployeeName.Text = lkeEmployeeID.GetColumnValue("VietnamName").ToString();

            //int varEmployeeID = Convert.ToInt16(value: lkeEmployeeID.GetColumnValue("EmployeeID").ToString());
            //this.grcEmployeePerformanceByID.DataSource = FileProcess.LoadTable("STEmployeeWorkingDailyPerformanceByID  " + varEmployeeID );
        }

        private void btn_updateEndtime_Click(object sender, EventArgs e)
        {
            DataProcess<Object> DA = new DataProcess<object>();
            int result = DA.ExecuteNoQuery("ST_Update_EndtimeScan_Daily");
            MessageBox.Show("Update Done!", "WMS");
            //if (result < 0)
            //{
            //    MessageBox.Show("Error", "WMS");
            //}
            //else
            //{
            //    MessageBox.Show("Update Done!", "WMS");
            //}
        }

        private void grvEmployeePerformanceByID_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //int varEmployeeID = Convert.ToInt16(value: lkeEmployeeID.GetColumnValue("EmployeeID").ToString());
            //string rptDate = Convert.ToDateTime(this.grvEmployeePerformanceByID.GetFocusedRowCellValue("ScanDate")).Date.ToString("yyyy-MM-dd");

            int varEmployeeID = this.EID;
            if (this.grvEmployeePerformanceByID.GetFocusedRowCellValue("ScanDate") is null)
            {

                this.grcEmployeePerformanceOne.DataSource = null;
                this.chartEmployeePerformanceOne.DataSource = null;
                this.grcEmployeeeWorkingOrders.DataSource = null;
            }
            else
            {
                string rptDate = Convert.ToDateTime(this.grvEmployeePerformanceByID.GetFocusedRowCellValue("ScanDate")).Date.ToString("yyyy-MM-dd");
                this.grcEmployeePerformanceOne.DataSource = FileProcess.LoadTable("STEmployeeWorkingDailyPerformanceDetails '" + rptDate + "'," + varEmployeeID);
                this.chartEmployeePerformanceOne.DataSource = FileProcess.LoadTable("STEmployeeWorkingDailyPerformanceOne '" + rptDate + "'," + varEmployeeID);
                this.grcEmployeeeWorkingOrders.DataSource = FileProcess.LoadTable("STEmployeeWorkingDailyPerformanceOrders '" + rptDate + "'," + varEmployeeID);
            }
            
        }

        private void checkAll_CheckedChanged(object sender, EventArgs e)
        {
            string flag = "";
            if (this.checkAll.Checked)
            {
                flag = " , @CheckAll = 1";
                
            }
            
            string rptDate = Convert.ToDateTime(txtReportDate.EditValue).Date.ToString("yyyy-MM-dd");
            this.grcEmployeePerformanceAll.DataSource = FileProcess.LoadTable("STEmployeeWorkingDailyPerformanceAll @Date ='" + rptDate + "'," + " @StoreID =" + this.lke_MSS_StoreList.EditValue + flag);
        }
    }
}
