using DA;
using DevExpress.XtraEditors;
using DevExpress.XtraPivotGrid;
using System;
using System.Collections;
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
using DevExpress.XtraEditors.Repository;
using UI.ReportFile;

namespace UI.ReportForm
{
    public partial class frm_BR_StockByLocationPivot : Form
    {
        private frm_WM_PalletInfo palletInfo = null;
        DataTable dataSource = null;
        private urc_BR_IncorrectOrders IncorrectOrders = null;
        private urc_BR_InccorectLocations InccorectLocations = null;

        public frm_BR_StockByLocationPivot(DateTime FromDate, DateTime ToDate, int CustomerID)
        {
            InitializeComponent();
            this.txtFromDate.DateTime = FromDate.AddDays(-1);
            this.txtToDate.DateTime = ToDate.AddDays(1);

            this.lke_Customer.Properties.DataSource = FileProcess.LoadTable("STcomboCustomerID " + AppSetting.StoreID);
            this.lke_Customer.Properties.DisplayMember = "CustomerNumber";
            this.lke_Customer.Properties.ValueMember = "CustomerID";
            this.lke_Customer.EditValue = CustomerID;

            //this.dataSource = FileProcess.LoadTable("STStockByLocationHistory " + AppSetting.StoreID + "," + CustomerID + ",'" + FromDate.ToString("yyyy-MM-dd") + "', '" + ToDate.ToString("yyyy-MM-dd") + "',1");
            string strDatasource = "STStockByLocationHistory " + AppSetting.StoreID + "," + CustomerID + ",'" + FromDate.AddDays(-1).ToString("yyyy-MM-dd") + "', '" + ToDate.AddDays(1).ToString("yyyy-MM-dd") + "', 0";
            this.pvgdStockByLocationHistory.DataSource = FileProcess.LoadTable(strDatasource);
        }

        public frm_BR_StockByLocationPivot()
        {
            InitializeComponent();
            this.checkMainCustomer.Checked = true;
            this.txtFromDate.EditValue = DateTime.Now.AddDays(-30).ToShortDateString();
            this.txtToDate.EditValue = DateTime.Now.ToShortDateString();
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            var pivotExportOptions = new DevExpress.XtraPivotGrid.PivotXlsxExportOptions();
            pivotExportOptions.ExportType = DevExpress.Export.ExportType.DataAware;
            SaveFileDialog sfd = new SaveFileDialog();
            //sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            sfd.Filter = "Excel 97-2003 (*.xls)|*.xls|Excel 07-2010 (*.xlsx)|*.xlsx";

            DialogResult dr = sfd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                pvgdStockByLocationHistory.ExportToXlsx(sfd.FileName, pivotExportOptions);
                try
                {
                    System.Diagnostics.Process.Start("Excel", sfd.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            sfd.Dispose();
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            string dateFrom = Convert.ToDateTime(txtFromDate.EditValue).Date.ToString("yyyy-MM-dd");
            string dateTo = Convert.ToDateTime(txtToDate.EditValue).Date.ToString("yyyy-MM-dd");
            string CustomerID = this.lke_Customer.EditValue.ToString();
            if (this.checkMainCustomer.Checked == true)
            {
                this.dataSource = FileProcess.LoadTable("STStockByLocationHistory " + AppSetting.StoreID + "," + CustomerID + ",'" + dateFrom + "', '" + dateTo + "',1");
                this.pvgdStockByLocationHistory.DataSource = this.dataSource;
            }
            else
            {
                this.dataSource = FileProcess.LoadTable("STStockByLocationHistory " + AppSetting.StoreID + "," + CustomerID + ",'" + dateFrom + "', '" + dateTo + "',0");
                this.pvgdStockByLocationHistory.DataSource = this.dataSource;
            }
            //DataProcess<STBillingDetailNoFee_Result> billingNoFeeDA = new DataProcess<STBillingDetailNoFee_Result>();
            //string qry = "STBillingDetailAllOrders " + this.lke_Customer.EditValue.ToString() + ",'" + dateFrom + "','" + dateTo + "'";
            //this.grdBillingNoFee.DataSource = billingNoFeeDA.Executing(qry);

            //this.grcStockMovementReport.DataSource = FileProcess.LoadTable("STStockMovementReport1Customer @varFromDate='" + dateFrom + "', @varTodate='" + dateTo + "', @varCustomerID='" + CustomerID + "', @ByWeight=" + 0);
        }

        private void checkMainCustomer_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkMainCustomer.Checked == true)
            {
                this.lke_Customer.Properties.DataSource = FileProcess.LoadTable("STcomboCustomerMainID " + AppSetting.StoreID);
                this.lke_Customer.Properties.DisplayMember = "CustomerNumber";
                this.lke_Customer.Properties.ValueMember = "CustomerMainID";
            }
            else
            {
                this.lke_Customer.Properties.DataSource = FileProcess.LoadTable("STcomboCustomerID " + AppSetting.StoreID);
                this.lke_Customer.Properties.DisplayMember = "CustomerNumber";
                this.lke_Customer.Properties.ValueMember = "CustomerID";
            }
            this.txtCustomerName.Text = null;
        }

        private void lke_Customer_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {

        }

        private void rph_OrderID_Click(object sender, EventArgs e)
        {
            string orderNumber = Convert.ToString(this.grvBillingNoFee.GetFocusedRowCellValue("ReceivingOrderNumber"));
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

        private void rp_hle_ProductID_Click(object sender, EventArgs e)
        {
            try
            {
                int customerID = Convert.ToInt32(this.grvStockMovementReportView.GetFocusedRowCellValue("CustomerID"));
                int productID = Convert.ToInt32(this.grvStockMovementReportView.GetFocusedRowCellValue("ProductID"));
                if (this.palletInfo == null)
                {
                    this.palletInfo = new frm_WM_PalletInfo(customerID, productID);
                }
                else
                {
                    this.palletInfo.InitData(customerID, productID);
                }
                this.palletInfo.Show();
            }
            catch
            {
                return;
            }
        }

        private void pvgdStockByLocationHistory_CellClick(object sender, PivotCellEventArgs e)
        {
            if (e.DataField.FieldName.Equals("BillingComments") ||
                e.DataField.FieldName.Equals("BillingCalculated"))
            {
                if (e.RowIndex >= this.dataSource.Rows.Count) return;
                int stockOnHandDetailPalletID = Convert.ToInt32(this.dataSource.Rows[e.RowIndex]["StockOnHandDetailPalletID"]);
                string comments = Convert.ToString(this.dataSource.Rows[e.RowIndex]["BillingComments"]);
                bool isBilled = Convert.ToBoolean(this.dataSource.Rows[e.RowIndex]["BillingCalculated"]);
                frm_BR_OnHandDailyDetailPalletsEdit frmEditForm = new frm_BR_OnHandDailyDetailPalletsEdit(stockOnHandDetailPalletID, comments, isBilled);
                frmEditForm.ShowDialog();
                this.btn_Refresh_Click(sender, e);
            }
            else
            {

            }


        }

        private void dockPanelAllOrders_Click(object sender, EventArgs e)
        {

        }

        private void dockPanelStockMovement_Click(object sender, EventArgs e)
        {

        }

        private void dockPanelAllOrders_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            string dateFrom = Convert.ToDateTime(txtFromDate.EditValue).Date.ToString("yyyy-MM-dd");
            string dateTo = Convert.ToDateTime(txtToDate.EditValue).Date.ToString("yyyy-MM-dd");
            string CustomerID = this.lke_Customer.EditValue.ToString();
            DataProcess<STBillingDetailNoFee_Result> billingNoFeeDA = new DataProcess<STBillingDetailNoFee_Result>();
            string qry = "STBillingDetailAllOrders " + this.lke_Customer.EditValue.ToString() + ",'" + dateFrom + "','" + dateTo + "'";
            this.grdBillingNoFee.DataSource = FileProcess.LoadTable(qry);
        }

        private void dockPanelStockMovement_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            string dateFrom = Convert.ToDateTime(txtFromDate.EditValue).Date.ToString("yyyy-MM-dd");
            string dateTo = Convert.ToDateTime(txtToDate.EditValue).Date.ToString("yyyy-MM-dd");
            string CustomerID = this.lke_Customer.EditValue.ToString();
            this.grcStockMovementReport.DataSource = FileProcess.LoadTable("STStockMovementReport1Customer @varFromDate='" + dateFrom + "', @varTodate='" + dateTo + "', @varCustomerID='" + CustomerID + "', @ByWeight=" + 0);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            rptStockByLocationHistoryBilling rpt = new rptStockByLocationHistoryBilling(txtFromDate.DateTime, txtToDate.DateTime);
            rpt.DataSource = pvgdStockByLocationHistory.DataSource;
            ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
            tool.ShowPreview();
        }

        private void dockPanelIncorrectOrders_Click(object sender, EventArgs e)
        {
            if (this.lke_Customer.EditValue == null)
                return;
            else
            { 
                this.IncorrectOrders = new urc_BR_IncorrectOrders(Convert.ToInt32(this.lke_Customer.EditValue),txtFromDate.DateTime, txtToDate.DateTime);
                this.IncorrectOrders.Parent = this.dockPanelIncorrectOrders;
            }
        }

        private void dockPanelIncorrectLocations_Click(object sender, EventArgs e)
        {
            if (this.lke_Customer.EditValue == null)
                return;
            else
            {
                this.InccorectLocations = new urc_BR_InccorectLocations(Convert.ToInt32(this.lke_Customer.EditValue),txtFromDate.DateTime,txtToDate.DateTime);
                this.InccorectLocations.Parent = this.dockPanelIncorrectLocations;
            }
        }

        private void lke_Customer_EditValueChanged(object sender, EventArgs e)
        {
            //this.txtCustomerName.Text = this.lke_Customer.GetColumnValue("CustomerName").ToString();
        }
    }
}
