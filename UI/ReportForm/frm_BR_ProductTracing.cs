using Common.Controls;
using DA;
using DevExpress.XtraReports.UI;
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
using UI.ReportFile;

namespace UI.ReportForm
{
    public partial class frm_BR_ProductTracing : frmBaseForm
    {
        private DataProcess<ReceivingOrders> receivingOrdersDP = new DataProcess<ReceivingOrders>();
        private DataProcess<Customers> customersDP = new DataProcess<Customers>();
        private DataProcess<STProductTracingCustomerDetails_Result> productTracingCustomerDetailsDP = new DataProcess<STProductTracingCustomerDetails_Result>();
        private DataProcess<STProductTracingReport_Result> productTracingReportDP = new DataProcess<STProductTracingReport_Result>();
        private List<STProductTracingReport_Result> currentReportList;
        public frm_BR_ProductTracing()
        {
            InitializeComponent();

            InitData();
        }

        private void InitData()
        {
            SetDefaultValueForDateEdit();
            InitDataForLookupEdit();
        }

        private void InitDataForLookupEdit()
        {
            lkeCustomerID.Properties.DataSource = AppSetting.CustomerList;
        }

        private void SetDefaultValueForDateEdit()
        {
            dtFromDate.EditValue = DateTime.Now.AddDays(-30);
            dtToDate.EditValue = DateTime.Now;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void lkeReceivingOrder_EditValueChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        int receivingOrderID = Convert.ToInt32(lkeReceivingOrder.EditValue);
        //        ReceivingOrders receivingOrder = receivingOrdersDP.Select(r => r.ReceivingOrderID == receivingOrderID).FirstOrDefault();
        //        txtReceivingDate.Text = Convert.ToDateTime(receivingOrder.ReceivingOrderDate).ToString("M/dd/yyyy");
        //        txtRemark.Text = receivingOrder.SpecialRequirement;
        //        // Execute store STProductTracingRODetails
        //        var result = productTracingRODetailsDP.Executing("STProductTracingRODetails @ReceivingOrderID = {0}", receivingOrderID);
        //        if (result != null)
        //        {
        //            grdProductTracing.DataSource = result.ToList();
        //        }
        //        else
        //        {
        //            string queryString = "SELECT ReceivingOrderDetailID, ProductNumber, ProductName, CustomerRef AS Reference, Plts, TotalPackages AS Qty, WeightPerPackage AS Weight, "
        //            + "ProductionDate AS [Pro.Date], UseByDate AS [Exp.Date] "
        //            + "FROM ReceivingOrderDetails "
        //            + "WHERE ReceivingOrderID = '" + receivingOrderID + "' "
        //            + "ORDER BY ProductNumber";
        //            grdProductTracing.DataSource = FileProcess.LoadTable(queryString);
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            if (this.grvProductTracing.RowCount < 0) return;
            UpdateSQL();
            int customerID = Convert.ToInt32(lkeCustomerID.EditValue);
            var orderNumber = this.grvProductTracing.GetFocusedRowCellValue("ReceivingOrderNumber");
            var orderDate = this.grvProductTracing.GetFocusedRowCellValue("ReceivingOrderDate");
            var orderRemark = this.grvProductTracing.GetFocusedRowCellValue("SpecialRequirement");
            var roInfo = orderNumber + "    " + Convert.ToDateTime(orderDate).ToString("dd/MM/yyyy") + "    " + orderRemark;
            rptProductTracing rpt = new rptProductTracing(roInfo);
            rpt.DataSource = currentReportList;
            rpt.LoginName = AppSetting.CurrentUser.LoginName;
            rpt.Customer = customersDP.Select(c => c.CustomerID == customerID) != null &&
                customersDP.Select(c => c.CustomerID == customerID).Count() > 0 ?
                customersDP.Select(c => c.CustomerID == customerID).FirstOrDefault() : new Customers();
            ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
            tool.ShowPreview();
        }

        private void UpdateSQL()
        {
            string strCondition;
            if (grvProductTracing.SelectedRowsCount == 0)
            {
                MessageBox.Show("Please select lot !", "WMS-2022",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                strCondition = "1";
                for (int i = 0; i < grvProductTracing.SelectedRowsCount; i++)
                {
                    int index = grvProductTracing.GetSelectedRows()[i];
                    int receivingOrderDetailID = Convert.ToInt32(grvProductTracing.GetRowCellValue(index, "ReceivingOrderDetailID"));
                    strCondition += "," + receivingOrderDetailID;
                }
                strCondition = "(" + strCondition + ")";
            }
            currentReportList = productTracingReportDP.Executing("STProductTracingReport @varCondition = {0}", strCondition).ToList();
        }

        private void frm_BR_ProductTracing_Shown(object sender, EventArgs e)
        {
            lkeCustomerID.Focus();
            lkeCustomerID.ShowPopup();
        }
        private void lkeCustomerID_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            try
            {
                int customerID = Convert.ToInt32(lkeCustomerID.EditValue);
                txtCustomerName.Text = customersDP.Select(c => c.CustomerID == customerID).FirstOrDefault().CustomerName;
                // Execute store STProductTracingRO
                DateTime from = Convert.ToDateTime(dtFromDate.EditValue);
                DateTime to = Convert.ToDateTime(dtToDate.EditValue);
                var result = productTracingCustomerDetailsDP.Executing("STProductTracingCustomerDetails @FromDate = {0}, @ToDate = {1}, @CustomerID = {2}", from, to, customerID);

                //var result = productTracingRODP.Executing("STProductTracingCustomerDetails @FromDate = {0}, @ToDate = {1}, @CustomerID = {2}", from, to, customerID);
                if (result != null)
                {
                    grdProductTracing.DataSource = result.ToList();
                }
                else
                {
                    string queryString = "SELECT ReceivingOrderDetails.ReceivingOrderDetailID, ReceivingOrderDetails.ProductNumber, ReceivingOrderDetails.ProductName, ReceivingOrderDetails.CustomerRef AS Reference, ReceivingOrderDetails.Plts, "
                  + " ReceivingOrderDetails.TotalPackages AS Qty, ReceivingOrderDetails.WeightPerPackage AS Weight, ReceivingOrderDetails.ProductionDate AS[Pro.Date], ReceivingOrderDetails.UseByDate AS[Exp.Date], ReceivingOrderDetails.Remark, "
                  + "ReceivingOrders.ReceivingOrderNumber, ReceivingOrders.ReceivingOrderDate, ReceivingOrders.SpecialRequirement FROM     ReceivingOrderDetails INNER JOIN ReceivingOrders ON ReceivingOrderDetails.ReceivingOrderID = ReceivingOrders.ReceivingOrderID "
                  + "WHERE(ReceivingOrders.CustomerID = " + customerID + " AND(ReceivingOrders.ReceivingOrderDate BETWEEN '" + from + "' AND  '" + to + "') ORDER BY ReceivingOrders.ReceivingOrderID, ReceivingOrderDetails.ProductNumber";

                    //"SELECT ReceivingOrderDetailID, ProductNumber, ProductName, CustomerRef AS Reference, Plts, TotalPackages AS Qty, WeightPerPackage AS Weight, "
                    //+ "ProductionDate AS [Pro.Date], UseByDate AS [Exp.Date] "
                    //+ "FROM ReceivingOrderDetails "
                    //+ "WHERE ReceivingOrderID = 1";


                    grdProductTracing.DataSource = FileProcess.LoadTable(queryString);
                }

                //lkeReceivingOrder.Focus();
                //lkeReceivingOrder.ShowPopup();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
