using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DA;
using DevExpress.XtraEditors.Controls;
using UI.Helper;
using UI.MasterSystemSetup;
using Common.Process;
using System.Threading;
using System.Globalization;
using UI.ReportFile;
using DevExpress.XtraReports.UI;
using DevExpress.XtraEditors;
using DevExpress.Export;
using DevExpress.XtraPrinting;
using UI.WarehouseManagement;

namespace UI.ReportForm
{
    public partial class frm_WR_StockReceivedReport : Common.Controls.frmBaseForm
    {
        public frm_WR_StockReceivedReport()
        {
            InitializeComponent();
        }

        private void frm_WR_StockReceivedReport_Load(object sender, EventArgs e)
        {
            this.InitData();
        }

        /// <summary>
        /// Init data to load report
        /// </summary>
        public void InitData()
        {
            dte_FromDateValue.EditValue = DateTime.Now;
            dte_ToDateValue.EditValue = DateTime.Now;
            LoadComboboxCustomer();
        }

        private void LoadComboboxCustomer()
        {
            DataProcess<STcomboCustomerID_Result> process = new DataProcess<STcomboCustomerID_Result>();
            List<STcomboCustomerID_Result> data = process.Executing("STcomboCustomerID @varStoreID={0}", AppSetting.StoreID).ToList();
            lke_CustomerIDValue.Properties.DataSource = data;
            lke_CustomerIDValue.Properties.DisplayMember = "CustomerNumber";
            lke_CustomerIDValue.Properties.ValueMember = "CustomerID";
            lke_CustomerIDValue.Properties.BestFit();
            if (data.Count >= 20)
                lke_CustomerIDValue.Properties.DropDownRows = 20;
            else
                lke_CustomerIDValue.Properties.DropDownRows = data.Count;
        }

        private void lke_CustomerIDValue_EditValueChanged(object sender, EventArgs e)
        {
            STcomboCustomerID_Result selectedItem = (STcomboCustomerID_Result)this.lke_CustomerIDValue.GetSelectedDataRow();
            if (selectedItem != null)
            {
                txt_CustomerName.Text = selectedItem.CustomerName;
                chk_ProductRemain.Checked = false;
                DataProcess<STComboProductIDList_Result> process = new DataProcess<STComboProductIDList_Result>();
                grd_ProductList.DataSource = process.Executing("STComboProductIDList @CustomerID={0}", selectedItem.CustomerID);
                if (selectedItem.CustomerType.ToUpper().Equals(CustomerTypeEnum.RANDOM_WEIGHT.ToUpper()))
                    chk_ByWeightInner.Checked = true;
                else
                    chk_ByWeightInner.Checked = false;
            }
            gv_ProductList.ClearSelection();
        }

        private void btn_GoCustomer_Click(object sender, EventArgs e)
        {
            STcomboCustomerID_Result selectedItem = (STcomboCustomerID_Result)this.lke_CustomerIDValue.GetSelectedDataRow();
            if (selectedItem != null)
            {
                frm_MSS_Customers frm = MasterSystemSetup.frm_MSS_Customers.Instance;
                frm.CurrentCustomers = AppSetting.CustomerList.Where(c => c.CustomerID == selectedItem.CustomerID).FirstOrDefault();
                frm.WindowState = FormWindowState.Normal;
                frm.BringToFront();
                frm.Show();
            }
        }

        private void chk_ProductRemain_CheckedChanged(object sender, EventArgs e)
        {
            STcomboCustomerID_Result selectedItem = (STcomboCustomerID_Result)this.lke_CustomerIDValue.GetSelectedDataRow();
            if (selectedItem != null)
            {
                if (chk_ProductRemain.Checked)
                {
                    DataProcess<STStockOnHandByLotListProducts_Result> process = new DataProcess<STStockOnHandByLotListProducts_Result>();
                    grd_ProductList.DataSource = process.Executing("STStockOnHandByLotListProducts @varCustomerID={0}", selectedItem.CustomerID);
                    grdCol_WeightPerPackage.Visible = false;
                    grdCol_Name.Visible = false;
                    grdCol_ProductName.Visible = true;
                    grdCol_Qty.Visible = true;
                }
                else
                {
                    DataProcess<STComboProductIDList_Result> process = new DataProcess<STComboProductIDList_Result>();
                    grd_ProductList.DataSource = process.Executing("STComboProductIDList @CustomerID={0}", selectedItem.CustomerID);
                    grdCol_Qty.Visible = false;
                    grdCol_ProductName.Visible = false;
                    grdCol_Name.Visible = true;
                    grdCol_WeightPerPackage.Visible = true;
                }
            }
            gv_ProductList.ClearSelection();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Tính năng này
        private void btn_FaxReport_Click(object sender, EventArgs e)
        {
            STcomboCustomerID_Result selectedItem = (STcomboCustomerID_Result)this.lke_CustomerIDValue.GetSelectedDataRow();
            if (selectedItem != null)
            {
                string sql = UpdateSQL();
                //if (DataTransfer.Send2faxServer(selectedItem.CustomerID, "rptStockReceived", sql, dte_FromDateValue.DateTime, dte_ToDateValue.DateTime, AppSetting.CurrentUser.LoginName))
                //    MessageBox.Show("Report sent to fax server !", "WMS-2022", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //else
                //    MessageBox.Show("Error sending fax !", "WMS-2022", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string UpdateSQL()
        {
            string strCondition = string.Empty;
            string sql;
            STcomboCustomerID_Result selectedItem = (STcomboCustomerID_Result)this.lke_CustomerIDValue.GetSelectedDataRow();
            List<int> selectedposition = gv_ProductList.GetSelectedRows().ToList();
            if (selectedposition.Count == 0)
            {
                strCondition = "(SELECT ProductID From Products WHERE CustomerID = " + selectedItem.CustomerID + ")";
            }
            else
            {
                strCondition = "1";
                foreach (int i in selectedposition)
                {
                    if (!chk_ProductRemain.Checked)
                    {
                        STComboProductIDList_Result row = gv_ProductList.GetRow(i) as STComboProductIDList_Result;
                        strCondition = strCondition + "," + row.ProductID.ToString();
                    }
                    else
                    {
                        STStockOnHandByLotListProducts_Result row = gv_ProductList.GetRow(i) as STStockOnHandByLotListProducts_Result;
                        strCondition = strCondition + "," + row.ProductID.ToString();
                    }
                }
                strCondition = "(" + strCondition + ")";
            }
            DataProcess<object> process = new DataProcess<object>();
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            if (chk_WithPallets.Checked)
            {
                sql = String.Format("STStockReceivedReportWithPallet '{0}','{1}','{2}'", dte_FromDateValue.DateTime.ToString("dd MMMM yyyy"), dte_ToDateValue.DateTime.ToString("dd MMMM yyyy"), strCondition);
            }
            else
            {
                sql = String.Format("STStockReceivedReport '{0}','{1}','{2}'", dte_FromDateValue.DateTime.ToString("dd MMMM yyyy"), dte_ToDateValue.DateTime.ToString("dd MMMM yyyy"), strCondition);
            }
            if (chk_ByWeightInner.Checked)
            {
                sql = String.Format("STStockReceivedReportWeightInner '{0}','{1}',{2}", dte_FromDateValue.DateTime.ToString("dd MMMM yyyy"), dte_ToDateValue.DateTime.ToString("dd MMMM yyyy"), strCondition);
            }
            return sql;
        }
        #endregion

        private void btn_SumByDate_Click(object sender, EventArgs e)
        {
            int customerID = (int)this.lke_CustomerIDValue.EditValue;
            var customerSelected = AppSetting.CustomerList.Where(c => c.CustomerID == customerID).FirstOrDefault();
            DataProcess<Employees> emp = new DataProcess<Employees>();
            var employees = emp.Select(em => em.EmployeeID == AppSetting.CurrentUser.EmployeeID).FirstOrDefault();

            rptStockReceivedSummary receiviedReportSummary = new rptStockReceivedSummary();
            receiviedReportSummary.Parameters["CustomerNumber"].Value = customerSelected.CustomerNumber;
            receiviedReportSummary.Parameters["CustomerName"].Value = customerSelected.CustomerName;
            receiviedReportSummary.Parameters["FromDate"].Value = this.dte_FromDateValue.DateTime;
            receiviedReportSummary.Parameters["ToDate"].Value = this.dte_ToDateValue.DateTime;
            receiviedReportSummary.Parameters["LoginName"].Value = employees.FullName;
            receiviedReportSummary.Parameters["GetDate"].Value = DateTime.Now;
            receiviedReportSummary.Parameters["CustomerNumber"].Visible = false;
            receiviedReportSummary.Parameters["CustomerName"].Visible = false;
            receiviedReportSummary.Parameters["FromDate"].Visible = false;
            receiviedReportSummary.Parameters["ToDate"].Visible = false;
            receiviedReportSummary.Parameters["LoginName"].Visible = true;
            receiviedReportSummary.Parameters["GetDate"].Visible = false;
            receiviedReportSummary.RequestParameters = false;

            string strCondition = string.Empty;
            string sql;
            STcomboCustomerID_Result selectedItem = (STcomboCustomerID_Result)this.lke_CustomerIDValue.GetSelectedDataRow();
            List<int> selectedposition = gv_ProductList.GetSelectedRows().ToList();
            if (selectedposition.Count == 0)
            {
                strCondition = "(SELECT ProductID From Products WHERE CustomerID = " + selectedItem.CustomerID + ")";
            }
            else
            {
                strCondition = "1";
                foreach (int i in selectedposition)
                {
                    if (!chk_ProductRemain.Checked)
                    {
                        STComboProductIDList_Result row = gv_ProductList.GetRow(i) as STComboProductIDList_Result;
                        strCondition = strCondition + "," + row.ProductID.ToString();
                    }
                    else
                    {
                        STStockOnHandByLotListProducts_Result row = gv_ProductList.GetRow(i) as STStockOnHandByLotListProducts_Result;
                        strCondition = strCondition + "," + row.ProductID.ToString();
                    }
                }
                strCondition = "(" + strCondition + ")";
            }
            DataProcess<object> process = new DataProcess<object>();
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            if (chk_WithPallets.Checked)
            {
                sql = String.Format("STStockReceivedReportWithPallet @varFromDate='" + dte_FromDateValue.DateTime.ToString("dd MMMM yyyy") + "',@varTodate='" + dte_ToDateValue.DateTime.ToString("dd MMMM yyyy") + "',@varCondition='" + strCondition + "'");
            }
            else
            {
                sql = String.Format("STStockReceivedReport @varFromDate='" + dte_FromDateValue.DateTime.ToString("dd MMMM yyyy") + "',@varToDate='" + dte_ToDateValue.DateTime.ToString("dd MMMM yyyy") + "',@varCondition='" + strCondition + "'");
            }
            if (chk_ByWeightInner.Checked)
            {
                sql = String.Format("STStockReceivedReportWeightInner @varFromDate='" + dte_FromDateValue.DateTime.ToString("dd MMMM yyyy") + "',@varTodate='" + dte_ToDateValue.DateTime.ToString("dd MMMM yyyy") + "',@varCondition='" + strCondition + "'");
            }

            var listSource = FileProcess.LoadTable(sql);
            if (listSource == null || listSource.Rows.Count <= 0)
            {
                XtraMessageBox.Show("No data to print !");
                return;
            }
            GroupHeaderBand ghBand = new GroupHeaderBand();
            receiviedReportSummary.Bands.Add(ghBand);
            GroupField groupField = new GroupField("ReceivingOrderDate");
            ghBand.GroupFields.Add(groupField);

            receiviedReportSummary.DataSource = listSource;
            receiviedReportSummary.xrcOrderDate.DataBindings.Add("Text", listSource, "ReceivingOrderDate", "{0:dd/MM/yyyy}");
            receiviedReportSummary.xrcPallets.DataBindings.Add("Text", listSource, "Plts"); //= listSource.Compute("Sum(Plts)", string.Empty).ToString();
            receiviedReportSummary.xrcCtns.DataBindings.Add("Text", listSource, "SumOfTotalPackages", "{0:n0}");
            receiviedReportSummary.xrcUnits.DataBindings.Add("Text", listSource, "TotalUnits");
            receiviedReportSummary.xrcNet.DataBindings.Add("Text", listSource, "TotalWeight");
            receiviedReportSummary.xrcGross.DataBindings.Add("Text", listSource, "GrossWeight");
            receiviedReportSummary.xrcSumPallet.Text = listSource.Compute("Sum(Plts)", string.Empty).ToString();
            receiviedReportSummary.xrcSumCtns.Text = String.Format("{0:n0}", Convert.ToDecimal(listSource.Compute("Sum(SumOfTotalPackages)", string.Empty).ToString()));
            var sumUnit = listSource.Compute("Sum(TotalUnits)", string.Empty);
            receiviedReportSummary.xrcSumUnits.Text = String.Format("{0:n1}", Convert.ToDecimal(sumUnit));
            receiviedReportSummary.xrcSumNet.DataBindings.Add("Text", listSource, "TotalWeight");//.Text = listSource.Compute("Sum(TotalWeight)", string.Empty).ToString();
            if (listSource.Columns.Contains("GrossWeight"))
                receiviedReportSummary.xrcSumGross.DataBindings.Add("Text", listSource, "GrossWeight");//.Text = listSource.Compute("Sum(GrossWeight)", string.Empty).ToString();
            else
                receiviedReportSummary.xrcSumGross.Text = "";
            ReportPrintToolWMS printTool = new ReportPrintToolWMS(receiviedReportSummary, customerID);
            printTool.AutoShowParametersPanel = false;
            printTool.ShowPreview();
        }

        private void btn_ViewReport_Click(object sender, EventArgs e)
        {
            try
            {
                int customerID = (int)this.lke_CustomerIDValue.EditValue;
                var customerSelected = AppSetting.CustomerList.FirstOrDefault(c => c.CustomerID == customerID);
                if (customerSelected == null)
                {
                    return;
                }

                DataProcess<Employees> emp = new DataProcess<Employees>();
                var employee = emp.Select(em => em.EmployeeID == AppSetting.CurrentUser.EmployeeID).FirstOrDefault();
                rptStockReceived receiviedReport = new rptStockReceived();
                this.ConfigParameterForReport(receiviedReport, customerSelected, employee);

                var listSource = this.UpdateDataForReport();
                if (listSource == null || listSource.Rows.Count <= 0)
                {
                    XtraMessageBox.Show("No data to print !");
                    return;
                }

                if (listSource == null || listSource.Rows.Count <= 0)
                {
                    XtraMessageBox.Show("No data to print !");
                    return;
                }
                receiviedReport.DataSource = listSource;
                GroupHeaderBand ghBand = new GroupHeaderBand();
                receiviedReport.Bands.Add(ghBand);
                GroupField groupField = new GroupField("ReceivingOrderNumber");
                ghBand.GroupFields.Add(groupField);
                string totalUnitReport = String.Empty;
                string totalWeightReport = String.Empty;
                string totalQtyReport = String.Empty;
                receiviedReport.xrcOrderNo.DataBindings.Add("Text", listSource, "ReceivingOrderNumber");
                receiviedReport.xrcOrderDate.DataBindings.Add("Text", listSource, "ReceivingOrderDate", "{0:dd/MM/yyyy}");
                receiviedReport.xrcSpecialRequirement.DataBindings.Add("Text", listSource, "SpecialRequirement");
                receiviedReport.xrcProductNumber.DataBindings.Add("Text", listSource, "ProductNumber");
                receiviedReport.xrcProductName.DataBindings.Add("Text", listSource, "ProductName");
                receiviedReport.xrcWPP.DataBindings.Add("Text", listSource, "WeightPerPackage", "{0:n3}");
                receiviedReport.xrcRef.DataBindings.Add("Text", listSource, "CustomerRef");
                receiviedReport.xrcPlts.DataBindings.Add("Text", listSource, "Plts");
                receiviedReport.xrcSumOfPackage.DataBindings.Add("Text", listSource, "SumOfTotalPackages");
                receiviedReport.xrcUnit.DataBindings.Add("Text", listSource, "TotalUnits", "{0:n1}");
                receiviedReport.xrcWeight.DataBindings.Add("Text", listSource, "TotalWeight", "{0:n1}");
                receiviedReport.xrcPro.DataBindings.Add("Text", listSource, "ProductionDate", "{0:dd/MM/yy}");
                receiviedReport.xrcExp.DataBindings.Add("Text", listSource, "UseByDate", "{0:dd/MM/yy}");
                receiviedReport.xrcSumPallet.DataBindings.Add("Text", listSource, "Plts");
                receiviedReport.xrcSumQty.DataBindings.Add("Text", listSource, "SumOfTotalPackages", "{0:n1}");
                receiviedReport.xrcSumUnits.DataBindings.Add("Text", listSource, "TotalUnits", "{0:n1}");
                receiviedReport.xrcSumWPP.DataBindings.Add("Text", listSource, "TotalWeight", "{0:n1}");
                receiviedReport.xrcTotalSumPlts.Text = listSource.Compute("Sum(Plts)", string.Empty).ToString();
                if (listSource.Columns.Contains("SumOfTotalPackages"))
                {
                    totalQtyReport = listSource.Compute("Sum(SumOfTotalPackages)", string.Empty).ToString();
                    receiviedReport.xrcTotalSumQty.Text = String.Format("{0:n0}", Convert.ToInt32(totalQtyReport));
                }

                if (listSource.Columns.Contains("TotalUnits"))
                {
                    totalUnitReport = listSource.Compute("Sum(TotalUnits)", string.Empty).ToString();

                    receiviedReport.xrcTotalSumUnit.Text = String.Format("{0:n1}", Convert.ToInt32(totalUnitReport));
                }
                else
                {
                    receiviedReport.xrcTotalSumUnit.Visible = false;
                    receiviedReport.xrcSumUnits.Visible = false;
                }
                if (listSource.Columns.Contains("TotalWeight"))
                {
                    totalWeightReport = listSource.Compute("Sum(TotalWeight)", string.Empty).ToString();
                    //double fl = Convert.ToDouble(totalWeightReport);
                    receiviedReport.xrcTotalSumWPP.Text = String.Format("{0:n1}", Convert.ToDecimal(totalWeightReport));
                }
                else
                {
                    receiviedReport.xrcTotalSumWPP.Visible = false;
                    receiviedReport.xrcSumWPP.Visible = false;
                }

                // Update XLXS format for Report model
                ExportSettings.DefaultExportType = ExportType.DataAware;

                ReportPrintToolWMS printTool = new ReportPrintToolWMS(receiviedReport, customerID);

                printTool.AutoShowParametersPanel = false;
                printTool.ShowPreview();
            }
            catch (Exception ex)
            {
                // TODO
            }
        }

        private void frm_WR_StockReceivedReport_Shown(object sender, EventArgs e)
        {
            this.lke_CustomerIDValue.Focus();
            this.lke_CustomerIDValue.ShowPopup();
        }

        private void lke_CustomerIDValue_Popup(object sender, EventArgs e)
        {
            int count = (this.lke_CustomerIDValue.Properties.DataSource as IList<STcomboCustomerID_Result>).Count;
            if (count >= 20)
                this.lke_CustomerIDValue.Properties.DropDownItemHeight = 20;
            else
                this.lke_CustomerIDValue.Properties.DropDownItemHeight = count;
        }

        private void txt_CustomerName_DoubleClick(object sender, EventArgs e)
        {
            STcomboCustomerID_Result selectedItem = (STcomboCustomerID_Result)this.lke_CustomerIDValue.GetSelectedDataRow();
            if (selectedItem != null)
            {
                frm_MSS_Customers frm = MasterSystemSetup.frm_MSS_Customers.Instance;
                frm.CurrentCustomers = AppSetting.CustomerList.Where(c => c.CustomerID == selectedItem.CustomerID).FirstOrDefault();
                frm.WindowState = FormWindowState.Normal;
                frm.BringToFront();
                frm.Show();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnViewKGR control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnViewKGR_Click(object sender, EventArgs e)
        {
            // TODO: Query data + display report - KGR
            // Need to using other Stored Proc from A.Hung to display data
            try
            {
                int customerID = (int)this.lke_CustomerIDValue.EditValue;
                var customerSelected = AppSetting.CustomerList.FirstOrDefault(c => c.CustomerID == customerID);
                if (customerSelected == null)
                {
                    return;
                }

                DataProcess<Employees> emp = new DataProcess<Employees>();
                var employee = emp.Select(em => em.EmployeeID == AppSetting.CurrentUser.EmployeeID).FirstOrDefault();
                rptStockReceivedKGR receiviedReport = new rptStockReceivedKGR();
                this.ConfigParameterForReport(receiviedReport, customerSelected, employee);

                var listSource = this.UpdateDataForReport();
                if (listSource == null || listSource.Rows.Count <= 0)
                {
                    XtraMessageBox.Show("No data to print !");
                    return;
                }

                receiviedReport.DataSource = listSource;
                GroupHeaderBand ghBand = new GroupHeaderBand();
                receiviedReport.Bands.Add(ghBand);
                GroupField groupField = new GroupField("ReceivingOrderNumber");
                ghBand.GroupFields.Add(groupField);
                string totalUnitReport = string.Empty;
                string totalWeightReport = string.Empty;
                string totalQtyReport = string.Empty;
                receiviedReport.xrcOrderNo.DataBindings.Add("Text", listSource, "ReceivingOrderNumber");
                receiviedReport.xrcOrderDate.DataBindings.Add("Text", listSource, "ReceivingOrderDate", "{0:dd/MM/yyyy}");
                receiviedReport.xrcSpecialRequirement.DataBindings.Add("Text", listSource, "SpecialRequirement");
                receiviedReport.xrcProductNumber.DataBindings.Add("Text", listSource, "ProductNumber");
                receiviedReport.xrcProductName.DataBindings.Add("Text", listSource, "ProductName");
                receiviedReport.xrcWPP.DataBindings.Add("Text", listSource, "WeightPerPackage", "{0:n3}");
                receiviedReport.xrcRef.DataBindings.Add("Text", listSource, "CustomerRef");
                receiviedReport.xrcPlts.DataBindings.Add("Text", listSource, "Plts");
                receiviedReport.xrcSumOfPackage.DataBindings.Add("Text", listSource, "SumOfTotalPackages");
                receiviedReport.xrcUnit.DataBindings.Add("Text", listSource, "TotalUnits", "{0:n1}");
                receiviedReport.xrcWeight.DataBindings.Add("Text", listSource, "TotalWeight", "{0:n1}");
                receiviedReport.xrcPro.DataBindings.Add("Text", listSource, "ProductionDate", "{0:dd/MM/yy}");
                receiviedReport.xrcExp.DataBindings.Add("Text", listSource, "UseByDate", "{0:dd/MM/yy}");
                receiviedReport.xrcSumPallet.DataBindings.Add("Text", listSource, "Plts");
                receiviedReport.xrcSumQty.DataBindings.Add("Text", listSource, "SumOfTotalPackages", "{0:n1}");
                receiviedReport.xrcSumUnits.DataBindings.Add("Text", listSource, "TotalUnits", "{0:n1}");
                receiviedReport.xrcSumWPP.DataBindings.Add("Text", listSource, "TotalWeight", "{0:n1}");
                receiviedReport.xrcTotalSumPlts.Text = listSource.Compute("Sum(Plts)", string.Empty).ToString();

                if (listSource.Columns.Contains("SumOfTotalPackages"))
                {
                    totalQtyReport = listSource.Compute("Sum(SumOfTotalPackages)", string.Empty).ToString();
                    receiviedReport.xrcTotalSumQty.Text = String.Format("{0:n0}", Convert.ToInt32(totalQtyReport));
                }

                if (listSource.Columns.Contains("TotalUnits"))
                {
                    totalUnitReport = listSource.Compute("Sum(TotalUnits)", string.Empty).ToString();

                    receiviedReport.xrcTotalSumUnit.Text = String.Format("{0:n1}", Convert.ToInt32(totalUnitReport));
                }
                else
                {
                    receiviedReport.xrcTotalSumUnit.Visible = false;
                    receiviedReport.xrcSumUnits.Visible = false;
                }
                if (listSource.Columns.Contains("TotalWeight"))
                {
                    totalWeightReport = listSource.Compute("Sum(TotalWeight)", string.Empty).ToString();
                    //double fl = Convert.ToDouble(totalWeightReport);
                    receiviedReport.xrcTotalSumWPP.Text = String.Format("{0:n1}", Convert.ToDecimal(totalWeightReport));
                }
                else
                {
                    receiviedReport.xrcTotalSumWPP.Visible = false;
                    receiviedReport.xrcSumWPP.Visible = false;
                }

                // Update XLXS format for Report model
                ExportSettings.DefaultExportType = ExportType.DataAware;

                ReportPrintToolWMS printTool = new ReportPrintToolWMS(receiviedReport, customerID);

                printTool.AutoShowParametersPanel = false;
                printTool.ShowPreview();
            }
            catch (Exception ex)
            {
                // TODO
            }
        }

        /// <summary>
        /// Configurations the parameter for report.
        /// </summary>
        /// <param name="receiviedReport">The receivied report.</param>
        /// <param name="customerSelected">The customer selected.</param>
        /// <param name="employee">The employee.</param>
        private void ConfigParameterForReport(XtraReport receiviedReport, Customers customerSelected, Employees employee)
        {
            receiviedReport.Parameters["CustomerNumber"].Value = customerSelected.CustomerNumber;
            receiviedReport.Parameters["CustomerName"].Value = customerSelected.CustomerName;
            receiviedReport.Parameters["FromDate"].Value = this.dte_FromDateValue.DateTime;
            receiviedReport.Parameters["ToDate"].Value = this.dte_ToDateValue.DateTime;
            receiviedReport.Parameters["LoginName"].Value = AppSetting.CurrentUser.LoginName;
            receiviedReport.Parameters["GetDate"].Value = DateTime.Now;
            receiviedReport.Parameters["CustomerNumber"].Visible = false;
            receiviedReport.Parameters["CustomerName"].Visible = false;
            receiviedReport.Parameters["FromDate"].Visible = false;
            receiviedReport.Parameters["ToDate"].Visible = false;
            receiviedReport.Parameters["LoginName"].Value = employee.FullName;
            receiviedReport.Parameters["GetDate"].Visible = false;
            receiviedReport.RequestParameters = false;
        }

        /// <summary>
        /// Updates the data for report.
        /// </summary>
        /// <returns></returns>
        private DataTable UpdateDataForReport()
        {

            string strCondition = string.Empty;
            string sql;
            STcomboCustomerID_Result selectedItem = (STcomboCustomerID_Result)this.lke_CustomerIDValue.GetSelectedDataRow();
            List<int> selectedposition = gv_ProductList.GetSelectedRows().ToList();
            if (selectedposition.Count == 0)
            {
                strCondition = "(SELECT ProductID From Products WHERE CustomerID = " + selectedItem.CustomerID + ")";
            }
            else
            {
                strCondition = "1";
                foreach (int i in selectedposition)
                {
                    if (!chk_ProductRemain.Checked)
                    {
                        STComboProductIDList_Result row = gv_ProductList.GetRow(i) as STComboProductIDList_Result;
                        strCondition = strCondition + "," + row.ProductID.ToString();
                    }
                    else
                    {
                        STStockOnHandByLotListProducts_Result row = gv_ProductList.GetRow(i) as STStockOnHandByLotListProducts_Result;
                        strCondition = strCondition + "," + row.ProductID.ToString();
                    }
                }
                strCondition = "(" + strCondition + ")";
            }

            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            if (chk_WithPallets.Checked)
            {
                sql = String.Format("STStockReceivedReportWithPallet @varFromDate='" + dte_FromDateValue.DateTime.ToString("dd MMMM yyyy") + "',@varTodate='" + dte_ToDateValue.DateTime.ToString("dd MMMM yyyy") + "',@varCondition='" + strCondition + "'");
            }
            else
            {
                sql = String.Format("STStockReceivedReport @varFromDate='" + dte_FromDateValue.DateTime.ToString("dd MMMM yyyy") + "',@varToDate='" + dte_ToDateValue.DateTime.ToString("dd MMMM yyyy") + "',@varCondition='" + strCondition + "'");
            }
            if (chk_ByWeightInner.Checked)
            {
                sql = String.Format("STStockReceivedReportWeightInner @varFromDate='" + dte_FromDateValue.DateTime.ToString("dd MMMM yyyy") + "',@varTodate='" + dte_ToDateValue.DateTime.ToString("dd MMMM yyyy") + "',@varCondition='" + strCondition + "'");
            }

            DataTable listSource = FileProcess.LoadTable(sql);
            foreach (DataRow row in listSource.Rows)
            {
                if (row["ProductNumber"] != null)
                    row["ProductNumber"] = row["ProductNumber"].ToString().Split('-')[1].Trim();
            }

            return listSource;
        }

        private void checkShowAllInOutProducts_Properties_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkShowAllInOutProducts.Checked)
            {
                this.grcInOutAllProducts.DataSource = FileProcess.LoadTable("STStockMovementInOutAllProducts @FromDate='" + this.dte_FromDateValue.DateTime.ToString("yyyy-MM-dd") + "', @Todate='" + this.dte_ToDateValue.DateTime.ToString("yyyy-MM-dd") + "', @CustomerID=" + Convert.ToInt32(this.lke_CustomerIDValue.EditValue));
            }
            else
            {
                this.grcInOutAllProducts.DataSource = null;
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            ExportSettings.DefaultExportType = ExportType.DataAware;
            var options = new XlsxExportOptionsEx();
            SaveFileDialog sfd = new SaveFileDialog();
            //sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            sfd.Filter = "Excel 97-2003 (*.xls)|*.xls|Excel 07-2010 (*.xlsx)|*.xlsx";

            DialogResult dr = sfd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                this.grcInOutAllProducts.ExportToXlsx(sfd.FileName, options);
                try
                {
                    System.Diagnostics.Process.Start(sfd.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            sfd.Dispose();
        }

        private void rpe_hle_OrderID_Click(object sender, EventArgs e)
        {
            string orderNumber = Convert.ToString(this.grvInOutProducts.GetFocusedRowCellValue("OrderNumber"));
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

        private void checkMain1_CheckedChanged(object sender, EventArgs e)
        {
            //int customerID = (int)this.lkeCustomer.EditValue;
            //if (customerID == 0) return;
            if (this.checkMain1.Checked)
            {
                this.grcInOutAllProducts.DataSource = FileProcess.LoadTable("STStockMovementInOutAllProducts @FromDate='" + this.dte_FromDateValue.DateTime.ToString("yyyy-MM-dd") + "', @Todate='" + this.dte_ToDateValue.DateTime.ToString("yyyy-MM-dd") + "', @CustomerID=" + Convert.ToInt32(this.lke_CustomerIDValue.EditValue) + " , @CheckMain = 1");
                grvInOutProducts.Columns["CustomerID"].Visible = true;
                grvInOutProducts.Columns["CustomerID"].Width = 80;
                grvInOutProducts.Columns["CustomerID"].VisibleIndex = 0;
            }
            else
            {
                this.grcInOutAllProducts.DataSource = null;
                grvInOutProducts.Columns["CustomerID"].Visible = false;
            }
        }

        private void btnLotNo_Click(object sender, EventArgs e)
        {
            try
            {
                int customerID = (int)this.lke_CustomerIDValue.EditValue;
                var customerSelected = AppSetting.CustomerList.FirstOrDefault(c => c.CustomerID == customerID);
                if (customerSelected == null)
                {
                    return;
                }

                DataProcess<Employees> emp = new DataProcess<Employees>();
                var employee = emp.Select(em => em.EmployeeID == AppSetting.CurrentUser.EmployeeID).FirstOrDefault();
                rptStockReceivedLotNo receiviedReport = new rptStockReceivedLotNo();
                this.ConfigParameterForReport(receiviedReport, customerSelected, employee);

                var listSource = this.UpdateDataForReportLotNo();
                if (listSource == null || listSource.Rows.Count <= 0)
                {
                    XtraMessageBox.Show("No data to print !");
                    return;
                }

                if (listSource == null || listSource.Rows.Count <= 0)
                {
                    XtraMessageBox.Show("No data to print !");
                    return;
                }
                receiviedReport.DataSource = listSource;
                GroupHeaderBand ghBand = new GroupHeaderBand();
                receiviedReport.Bands.Add(ghBand);
                GroupField groupField = new GroupField("ReceivingOrderNumber");
                ghBand.GroupFields.Add(groupField);
                string totalUnitReport = String.Empty;
                string totalWeightReport = String.Empty;
                string totalQtyReport = String.Empty;
                receiviedReport.xrcOrderNo.DataBindings.Add("Text", listSource, "ReceivingOrderNumber");
                receiviedReport.xrcOrderDate.DataBindings.Add("Text", listSource, "ReceivingOrderDate", "{0:dd/MM/yyyy}");
                receiviedReport.xrcSpecialRequirement.DataBindings.Add("Text", listSource, "SpecialRequirement");
                receiviedReport.xrcWPP.DataBindings.Add("Text", listSource, "WeightPerPackage", "{0:n3}");
                receiviedReport.xrcRef.DataBindings.Add("Text", listSource, "CustomerRef");
                receiviedReport.xrcPlts.DataBindings.Add("Text", listSource, "Plts");
                receiviedReport.xrcSumOfPackage.DataBindings.Add("Text", listSource, "SumOfTotalPackages");
                receiviedReport.xrcUnit.DataBindings.Add("Text", listSource, "TotalUnits", "{0:n1}");
                receiviedReport.xrcWeight.DataBindings.Add("Text", listSource, "TotalWeight", "{0:n1}");
                receiviedReport.xrcPro.DataBindings.Add("Text", listSource, "ProductionDate", "{0:dd/MM/yy}");
                receiviedReport.xrcExp.DataBindings.Add("Text", listSource, "UseByDate", "{0:dd/MM/yy}");
                receiviedReport.xrcSumPallet.DataBindings.Add("Text", listSource, "Plts");
                receiviedReport.xrcSumQty.DataBindings.Add("Text", listSource, "SumOfTotalPackages", "{0:n1}");
                receiviedReport.xrcSumUnits.DataBindings.Add("Text", listSource, "TotalUnits", "{0:n1}");
                receiviedReport.xrcSumWPP.DataBindings.Add("Text", listSource, "TotalWeight", "{0:n1}");
                receiviedReport.xrcTotalSumPlts.Text = listSource.Compute("Sum(Plts)", string.Empty).ToString();
                if (listSource.Columns.Contains("SumOfTotalPackages"))
                {
                    totalQtyReport = listSource.Compute("Sum(SumOfTotalPackages)", string.Empty).ToString();
                    receiviedReport.xrcTotalSumQty.Text = String.Format("{0:n0}", Convert.ToInt32(totalQtyReport));
                }

                if (listSource.Columns.Contains("TotalUnits"))
                {
                    totalUnitReport = listSource.Compute("Sum(TotalUnits)", string.Empty).ToString();

                    receiviedReport.xrcTotalSumUnit.Text = String.Format("{0:n1}", Convert.ToInt32(totalUnitReport));
                }
                else
                {
                    receiviedReport.xrcTotalSumUnit.Visible = false;
                    receiviedReport.xrcSumUnits.Visible = false;
                }
                if (listSource.Columns.Contains("TotalWeight"))
                {
                    totalWeightReport = listSource.Compute("Sum(TotalWeight)", string.Empty).ToString();
                    //double fl = Convert.ToDouble(totalWeightReport);
                    receiviedReport.xrcTotalSumWPP.Text = String.Format("{0:n1}", Convert.ToDecimal(totalWeightReport));
                }
                else
                {
                    receiviedReport.xrcTotalSumWPP.Visible = false;
                    receiviedReport.xrcSumWPP.Visible = false;
                }

                // Update XLXS format for Report model
                ExportSettings.DefaultExportType = ExportType.DataAware;

                ReportPrintToolWMS printTool = new ReportPrintToolWMS(receiviedReport, customerID);

                printTool.AutoShowParametersPanel = false;
                printTool.ShowPreview();
            }
            catch (Exception ex)
            {
                // TODO
            }
        }

        private DataTable UpdateDataForReportLotNo()
        {

            string strCondition = string.Empty;
            string sql;
            STcomboCustomerID_Result selectedItem = (STcomboCustomerID_Result)this.lke_CustomerIDValue.GetSelectedDataRow();
            List<int> selectedposition = gv_ProductList.GetSelectedRows().ToList();
            if (selectedposition.Count == 0)
            {
                strCondition = "(SELECT ProductID From Products WHERE CustomerID = " + selectedItem.CustomerID + ")";
            }
            else
            {
                strCondition = "1";
                foreach (int i in selectedposition)
                {
                    if (!chk_ProductRemain.Checked)
                    {
                        STComboProductIDList_Result row = gv_ProductList.GetRow(i) as STComboProductIDList_Result;
                        strCondition = strCondition + "," + row.ProductID.ToString();
                    }
                    else
                    {
                        STStockOnHandByLotListProducts_Result row = gv_ProductList.GetRow(i) as STStockOnHandByLotListProducts_Result;
                        strCondition = strCondition + "," + row.ProductID.ToString();
                    }
                }
                strCondition = "(" + strCondition + ")";
            }

            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            if (chk_WithPallets.Checked)
            {
                sql = String.Format("STStockReceivedReportWithPalletLotNo @varFromDate='" + dte_FromDateValue.DateTime.ToString("dd MMMM yyyy") + "',@varTodate='" + dte_ToDateValue.DateTime.ToString("dd MMMM yyyy") + "',@varCondition='" + strCondition + "'");
            }
            else
            {
                sql = String.Format("STStockReceivedReportLotNo @varFromDate='" + dte_FromDateValue.DateTime.ToString("dd MMMM yyyy") + "',@varToDate='" + dte_ToDateValue.DateTime.ToString("dd MMMM yyyy") + "',@varCondition='" + strCondition + "'");
            }
            if (chk_ByWeightInner.Checked)
            {
                sql = String.Format("STStockReceivedReportWeightInnerLotNo @varFromDate='" + dte_FromDateValue.DateTime.ToString("dd MMMM yyyy") + "',@varTodate='" + dte_ToDateValue.DateTime.ToString("dd MMMM yyyy") + "',@varCondition='" + strCondition + "'");
            }

            DataTable listSource = FileProcess.LoadTable(sql);
            foreach (DataRow row in listSource.Rows)
            {
                if (row["ProductNumber"] != null)
                    row["ProductNumber"] = row["ProductNumber"].ToString().Split('-')[1].Trim();
            }

            return listSource;
        }
    }
}
