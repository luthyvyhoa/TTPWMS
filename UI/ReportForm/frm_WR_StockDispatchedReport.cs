using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Controls;
using UI.Helper;
using DA;
using UI.MasterSystemSetup;
using UI.ReportFile;
using DevExpress.XtraReports.UI;
using DevExpress.XtraEditors;
using DevExpress.Export;
using DevExpress.XtraPrinting;

namespace UI.ReportForm
{
    public partial class frm_WR_StockDispatchedReport : frmBaseForm
    {
        public frm_WR_StockDispatchedReport()
        {
            InitializeComponent();
            IsFixHeightScreen = false;

        }

        private void frm_WR_StockDispatchedReport_Shown(object sender, EventArgs e)
        {
            lkeCustomerNumber.Focus();
            lkeCustomerNumber.ShowPopup();
        }

        private void frm_WR_StockDispatchedReport_Load(object sender, EventArgs e)
        {
            lkeCustomerNumber.Properties.DataSource = AppSetting.CustomerList;
            int lkeCUstomerNumberRows = ((IList<Customers>)lkeCustomerNumber.Properties.DataSource).Count;
            if (lkeCUstomerNumberRows > 20)
                lkeCustomerNumber.Properties.DropDownRows = 20;
            else
                lkeCustomerNumber.Properties.DropDownRows = lkeCUstomerNumberRows;
            lkeCustomerNumber.Properties.DisplayMember = "CustomerNumber";
            lkeCustomerNumber.Properties.ValueMember = "CustomerID";

            deFromDate.EditValue = DateTime.Now;
            deToDate.EditValue = DateTime.Now;

        }

        #region Events
        private void lkeCustomerNumber_EditValueChanged(object sender, EventArgs e)
        {
            if (lkeCustomerNumber.EditValue != null)
            {
                txtCustomerName.EditValue = lkeCustomerNumber.GetColumnValue("CustomerName").ToString();

                int selectedCustomerID = Convert.ToInt32(lkeCustomerNumber.GetColumnValue("CustomerID"));
                DataProcess<STCustomerClients_Result> stCustomerClientsDA = new DataProcess<STCustomerClients_Result>();
                lkeCustomerClientID.Properties.DataSource = stCustomerClientsDA.Executing("STCustomerClients @CustomerID={0}", selectedCustomerID);
                int lkeCustomerClientIDRows = ((IList<STCustomerClients_Result>)lkeCustomerClientID.Properties.DataSource).Count;
                if (lkeCustomerClientIDRows > 20)
                    lkeCustomerClientID.Properties.DropDownRows = 20;
                else
                    lkeCustomerClientID.Properties.DropDownRows = lkeCustomerClientIDRows;
                lkeCustomerClientID.Properties.DisplayMember = "CustomerClientCode";
                lkeCustomerClientID.Properties.ValueMember = "CustomerClientID";

                ckeWithProduct.Checked = false;

                DataProcess<STComboProductIDList_Result> stComboProdcutIDListDA = new DataProcess<STComboProductIDList_Result>();
                grcProducts.DataSource = stComboProdcutIDListDA.Executing("STComboProductIDList @CustomerID={0}", selectedCustomerID);

                string selectedCustomerType = lkeCustomerNumber.GetColumnValue("CustomerType").ToString();
                if (selectedCustomerType.ToUpper().Equals(CustomerTypeEnum.RANDOM_WEIGHT.ToUpper()))
                    ckeByWeightInner.Checked = true;
                else
                    ckeByWeightInner.Checked = false;

                this.grvProducts.ClearSelection();
                //this.pvgStockDispatchedReport.DataSource = FileProcess.LoadTable("STStockDispatchedReport "+ selectedCustomerID);
            }
        }

        private void ckeByClient_CheckedChanged(object sender, EventArgs e)
        {
            lkeCustomerClientID.Focus();
            lkeCustomerClientID.ShowPopup();
        }

        private void txtCustomerName_DoubleClick(object sender, EventArgs e)
        {
            int selectedCustomerID = Convert.ToInt32(lkeCustomerNumber.GetColumnValue("CustomerID"));
            if (selectedCustomerID > 0)
            {

                Customers selectedCustomer = AppSetting.CustomerList.Where(c => c.CustomerID == selectedCustomerID).SingleOrDefault();
                if (selectedCustomer != null)
                {
                    frm_MSS_Customers frm = MasterSystemSetup.frm_MSS_Customers.Instance;
                    frm.CurrentCustomers = selectedCustomer;
                    frm.WindowState = FormWindowState.Normal;
                    frm.BringToFront();
                    frm.Show();
                }
                else
                    MessageBox.Show("Can't found out Customer", "WMS-2022", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ckeWithProduct_CheckedChanged(object sender, EventArgs e)
        {
            if (ckeWithProduct.Checked)
            {
                int selectedCustomerID = Convert.ToInt32(lkeCustomerNumber.GetColumnValue("CustomerID"));
                if (selectedCustomerID > 0)
                {
                    this.grcProduct.Visible = false;
                    this.grcName.Visible = false;
                    this.grcWeightPerPackage.Visible = false;

                    this.grcProductRemain.Visible = true;
                    this.grcNameRemain.Visible = true;
                    this.grcQtyRemain.Visible = true;

                    this.grcProductRemain.VisibleIndex = 0;
                    this.grcNameRemain.VisibleIndex = 1;
                    this.grcQtyRemain.VisibleIndex = 2;

                    DataProcess<STStockOnHandByLotListProducts_Result> stStockOnHandByLotListProductsDA = new DataProcess<STStockOnHandByLotListProducts_Result>();
                    grcProducts.DataSource = stStockOnHandByLotListProductsDA.Executing("STStockOnHandByLotListProducts @varCustomerID={0}", selectedCustomerID);
                    grvProducts.RefreshData();
                }
            }
            else
            {
                int selectedCustomerID = Convert.ToInt32(lkeCustomerNumber.GetColumnValue("CustomerID"));
                if (selectedCustomerID > 0)
                {
                    this.grcProductRemain.Visible = false;
                    this.grcNameRemain.Visible = false;
                    this.grcQtyRemain.Visible = false;

                    this.grcWeightPerPackage.Visible = true;
                    this.grcProduct.Visible = true;
                    this.grcName.Visible = true;

                    this.grcProduct.VisibleIndex = 0;
                    this.grcName.VisibleIndex = 1;
                    this.grcWeightPerPackage.VisibleIndex = 2;


                    DataProcess<STComboProductIDList_Result> stComboProductIDListDA = new DataProcess<STComboProductIDList_Result>();
                    grcProducts.DataSource = stComboProductIDListDA.Executing("STComboProductIDList @CustomerID={0}", selectedCustomerID);
                    grvProducts.RefreshData();
                }
            }
        }

        private void lkeCustomerClientID_EditValueChanged(object sender, EventArgs e)
        {
            if (lkeCustomerClientID.EditValue != null)
                txtCustomerClientName.EditValue = lkeCustomerClientID.GetColumnValue("CustomerClientName");
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            string condition = "";
            DataTable data = new DataTable();
            var toDate = this.deToDate.DateTime.ToString("yyyy-MM-dd");
            var fromDate = this.deFromDate.DateTime.ToString("yyyy-MM-dd");

            if (this.grvProducts.SelectedRowsCount <= 0)
            {
                condition = GetAllProductID();
            }
            else
            {
                condition = GetSelectedProductID();
            }

            if (this.lkeCustomerClientID.EditValue == null || (int)this.lkeCustomerClientID.EditValue <= 0)
            {
                if (this.ckeByWeightInner.Checked)
                {
                    data = FileProcess.LoadTable(" STStockDispatchedReportWeightInner @varFromDate='" + fromDate
                                + "', @varTodate='" + toDate + "' ,  @varCondition='" + condition + "'");
                }
                else
                {
                    data = FileProcess.LoadTable(" STStockDispatchedReport @varFromDate='" + fromDate
                                    + "', @varTodate='" + toDate + "' ,  @varCondition='" + condition + "'");
                }
            }
            else
            {
                if (this.ckeByWeightInner.Checked)
                {
                    data = FileProcess.LoadTable(" STStockDispatchedReportWeightInner @varFromDate='" + fromDate
                                + "', @varTodate='" + toDate + "' ,  @varCondition='" + condition + "', @CustomerClientID=" + Convert.ToInt32(this.lkeCustomerClientID.EditValue));

                }
                else
                {
                    data = FileProcess.LoadTable(" STStockDispatchedReport @varFromDate='" + fromDate
                                    + "', @varTodate='" + toDate + "' ,  @varCondition='" + condition + "', @CustomerClientID=" + Convert.ToInt32(this.lkeCustomerClientID.EditValue));
                }
            }

            OpenStockDispatchedReport(data);
            //Call UpdateSQL --Update storeprocedure truyen vao report
            //rptStockDispatched rpt = new rptStockDispatched();
            //ReportPrintToolWMS printTool = new ReportPrintToolWMS(rpt);
            //printTool.ShowPreviewDialog();
        }

        private void btnByClient_Click(object sender, EventArgs e)
        {
            if (this.lkeCustomerNumber.EditValue == null)
            {
                XtraMessageBox.Show("Please select customer !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Call UpdateSQL --Update storeprocedure truyen vao report
            string condition = "";
            DataTable data = new DataTable();
            var toDate = this.deToDate.DateTime.ToString("yyyy-MM-dd");
            var fromDate = this.deFromDate.DateTime.ToString("yyyy-MM-dd");

            if (this.grvProducts.SelectedRowsCount <= 0)
            {
                condition = GetAllProductID();
            }
            else
            {
                condition = GetSelectedProductID();
            }

            if (this.lkeCustomerClientID.EditValue == null)
            {
                if (this.ckeByWeightInner.Checked)
                {
                    data = FileProcess.LoadTable(" STStockDispatchedReportWeightInner @varFromDate='" + fromDate
                                + "', @varTodate='" + toDate + "' ,  @varCondition='" + condition + "'");
                }
                else
                {
                    data = FileProcess.LoadTable(" STStockDispatchedReport @varFromDate='" + fromDate
                                    + "', @varTodate='" + toDate + "' ,  @varCondition='" + condition + "'");
                }
            }
            else
            {
                if (this.ckeByWeightInner.Checked)
                {
                    data = FileProcess.LoadTable(" STStockDispatchedReportWeightInner @varFromDate='" + fromDate
                                + "', @varTodate='" + toDate + "' ,  @varCondition='" + condition + "', @CustomerClientID=" + Convert.ToInt32(this.lkeCustomerClientID.EditValue));

                }
                else
                {
                    data = FileProcess.LoadTable(" STStockDispatchedReport @varFromDate='" + fromDate
                                    + "', @varTodate='" + toDate + "' ,  @varCondition='" + condition + "', @CustomerClientID=" + Convert.ToInt32(this.lkeCustomerClientID.EditValue));
                }
            }

            OpenStockDispatchedByClientReport(data);
        }

        private void btnByDetails_Click(object sender, EventArgs e)
        {
            string condition = "";
            DataTable data = new DataTable();
            var toDate = this.deToDate.DateTime.ToString("yyyy-MM-dd");
            var fromDate = this.deFromDate.DateTime.ToString("yyyy-MM-dd");

            if (this.grvProducts.SelectedRowsCount <= 0)
            {
                condition = GetAllProductID();
            }
            else
            {
                condition = GetSelectedProductID();
            }

            data = FileProcess.LoadTable("STStockDispatchedDetailReport @varFromDate='" + fromDate + "', @varTodate='" + toDate + "', @varCondition='" + condition + "'");
            OpenStockDispatchedDetailReport(data);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        #endregion

        private string GetSelectedProductID()
        {
            string listProductID = "(1, ";
            int[] rowHandles = this.grvProducts.GetSelectedRows();

            for (int i = 0; i < rowHandles.Count(); i++)
            {
                if (i == rowHandles.Count() - 1)
                {
                    listProductID = listProductID + this.grvProducts.GetRowCellValue(rowHandles[i], "ProductID") + ")";
                }
                else
                {
                    listProductID = listProductID + this.grvProducts.GetRowCellValue(rowHandles[i], "ProductID") + ", ";
                }
            }
            return listProductID;
        }

        private string GetAllProductID()
        {
            int customerID = (int)this.lkeCustomerNumber.EditValue;
            string condition = "(SELECT ProductID From Products WHERE CustomerID = " + customerID + ")";
            return condition;
        }

        private string GetAllProductOfMainCustomer()
        {
            int customerID = (int)this.lkeCustomerNumber.EditValue;
            string condition = "(SELECT ProductID From Products WHERE CustomerID in (SELECT CustomerID From Customers Where CustomerMainID = (Select CustomerMainID from Customers where CustomerID = "+ customerID + ")))";
            return condition;
        }

        private void OpenStockDispatchedReport(DataTable dataSource)
        {
            if (this.lkeCustomerNumber.EditValue == null) return;
            int customerID = Convert.ToInt32(this.lkeCustomerNumber.EditValue);

            if (dataSource == null || dataSource.Rows.Count <= 0)
            {
                XtraMessageBox.Show("No data to print !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                rptStockDispatched report = new rptStockDispatched(Convert.ToString(this.lkeCustomerNumber.GetColumnValue("CustomerNumber")), this.txtCustomerName.Text, this.deFromDate.DateTime, this.deToDate.DateTime);
                report.DataSource = dataSource;
                CreateSDReportFields(report);

                GroupField groupField = new GroupField("DispatchingOrderNumber");
                report.GroupHeader2.GroupFields.Add(groupField);

                report.xrLabel29.DataBindings.Add("Text", dataSource, "SumOfTotalPackages");
                report.xrLabel30.DataBindings.Add("Text", dataSource, "TotalUnits");
                report.xrLabel31.DataBindings.Add("Text", dataSource, "Plts");
                report.xrLabel32.DataBindings.Add("Text", dataSource, "TW", "{0:n2}");
                ReportPrintToolWMS tool = new ReportPrintToolWMS(report,customerID);
                tool.ShowPreview();
            }
        }

        private void OpenStockDispatchedByClientReport(DataTable dataSource)
        {
            if (this.lkeCustomerNumber.EditValue == null) return;
            int customerID = Convert.ToInt32(this.lkeCustomerNumber.EditValue);

            if (dataSource == null || dataSource.Rows.Count <= 0)
            {
                XtraMessageBox.Show("No data to print !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                rptStockDispatchedByClient report = new rptStockDispatchedByClient(Convert.ToString(this.lkeCustomerNumber.GetColumnValue("CustomerNumber")), this.txtCustomerName.Text, this.deFromDate.DateTime, this.deToDate.DateTime);
                report.DataSource = dataSource;
                CreateSDReportFields(report);

                GroupHeaderBand ghBand = new GroupHeaderBand();
                report.Bands.Add(ghBand);
                GroupField groupField = new GroupField("DispatchingOrderNumber");
                ghBand.GroupFields.Add(groupField);
                report.xrLabel29.DataBindings.Add("Text", dataSource, "SumOfTotalPackages");
                report.xrLabel30.DataBindings.Add("Text", dataSource, "TotalUnits");
                report.xrLabel31.DataBindings.Add("Text", dataSource, "Plts");
                report.xrLabel32.DataBindings.Add("Text", dataSource, "TW", "{0:#,#.00}");


                ReportPrintToolWMS tool = new ReportPrintToolWMS(report,customerID);
                tool.ShowPreview();
            }
        }

        private void OpenStockDispatchedDetailReport(DataTable dataSource)
        {
            if (this.lkeCustomerNumber.EditValue == null) return;
            int customerID = Convert.ToInt32(this.lkeCustomerNumber.EditValue);

            if (dataSource == null || dataSource.Rows.Count <= 0)
            {
                XtraMessageBox.Show("No data to print !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var customerNumber = this.lkeCustomerNumber.GetColumnValue("CustomerNumber")?.ToString();
                var customerFullInfo = AppSetting.CustomerList.FirstOrDefault(c => c.CustomerNumber.Equals(customerNumber));
                if (customerFullInfo == null)
                {
                    return;
                }
                var customerType = customerFullInfo.CustomerType;
                if (string.Equals(customerType, CustomerTypeEnum.RANDOM_WEIGHT))
                {
                    rptStockDispatchedDetailsKGR report = new rptStockDispatchedDetailsKGR(customerNumber, this.txtCustomerName.Text, this.deFromDate.DateTime, this.deToDate.DateTime);
                    report.DataSource = dataSource;
                    CreateSDDetailField(report);

                    GroupField groupField = new GroupField("DispatchingOrderNumber");
                    report.GroupHeader1.GroupFields.Add(groupField);

                    report.xrLabel32.DataBindings.Add("Text", dataSource, "QuantityOfPackages");
                    report.xrLabel30.DataBindings.Add("Text", dataSource, "TotalUnits");
                    report.xrLabel31.DataBindings.Add("Text", dataSource, "Plts");
                    report.xrLabel34.DataBindings.Add("Text", dataSource, "TotalWeight", "{0:#,#.00}");
                    ReportPrintToolWMS tool = new ReportPrintToolWMS(report, customerID);
                    tool.ShowPreview();
                }
                else
                {
                    rptStockDispatchedDetails report = new rptStockDispatchedDetails(Convert.ToString(this.lkeCustomerNumber.GetColumnValue("CustomerNumber")), this.txtCustomerName.Text, this.deFromDate.DateTime, this.deToDate.DateTime);
                    report.DataSource = dataSource;
                    CreateSDDetailField(report);

                    GroupField groupField = new GroupField("DispatchingOrderNumber");
                    report.GroupHeader1.GroupFields.Add(groupField);

                    report.xrLabel32.DataBindings.Add("Text", dataSource, "QuantityOfPackages");
                    report.xrLabel30.DataBindings.Add("Text", dataSource, "TotalUnits");
                    report.xrLabel31.DataBindings.Add("Text", dataSource, "Plts");
                    report.xrLabel34.DataBindings.Add("Text", dataSource, "TotalWeight", "{0:#,#.00}");
                    ReportPrintToolWMS tool = new ReportPrintToolWMS(report, customerID);
                    tool.ShowPreview();
                }
            }
        }


        /// <summary>
        /// Create calculated field for rptStockDispatched and rptStockDispatchedByClient
        /// </summary>
        /// <param name="report"></param>
        private void CreateSDReportFields(XtraReport report)
        {
            CalculatedField sumPackage = new CalculatedField();
            sumPackage.DataSource = report.DataSource;
            sumPackage.DataMember = report.DataMember;
            sumPackage.Name = "sumPackage";
            sumPackage.DisplayName = "sumPackage";
            sumPackage.Expression = "Sum([SumOfTotalPackages])";

            report.CalculatedFields.Add(sumPackage);

            CalculatedField sumPlts = new CalculatedField();
            sumPlts.DataSource = report.DataSource;
            sumPlts.DataMember = report.DataMember;
            sumPlts.Name = "sumPlts";
            sumPlts.DisplayName = "sumPlts";
            sumPlts.Expression = "Sum([Plts])";

            report.CalculatedFields.Add(sumPlts);

            CalculatedField sumUnit = new CalculatedField();
            sumUnit.DataSource = report.DataSource;
            sumUnit.DataMember = report.DataMember;
            sumUnit.Name = "sumUnit";
            sumUnit.DisplayName = "sumUnit";
            sumUnit.Expression = "Sum([TotalUnits])";

            report.CalculatedFields.Add(sumUnit);

            CalculatedField sumTW = new CalculatedField();
            sumTW.DataSource = report.DataSource;
            sumTW.DataMember = report.DataMember;
            sumTW.Name = "sumTW";
            sumTW.DisplayName = "sumTW";
            sumTW.Expression = "Sum([TW])";

            report.CalculatedFields.Add(sumTW);
        }

        /// <summary>
        /// Create calculated field for rptStockDispatchedDetail
        /// </summary>
        /// <param name="report"></param>
        private void CreateSDDetailField(XtraReport report)
        {
            CalculatedField sumPackage = new CalculatedField();
            sumPackage.DataSource = report.DataSource;
            sumPackage.DataMember = report.DataMember;
            sumPackage.Name = "sumPackage";
            sumPackage.DisplayName = "sumPackage";
            sumPackage.Expression = "Sum([QuantityOfPackages])";

            report.CalculatedFields.Add(sumPackage);

            CalculatedField sumPlts = new CalculatedField();
            sumPlts.DataSource = report.DataSource;
            sumPlts.DataMember = report.DataMember;
            sumPlts.Name = "sumPlts";
            sumPlts.DisplayName = "sumPlts";
            sumPlts.Expression = "Sum([Plts])";

            report.CalculatedFields.Add(sumPlts);

            CalculatedField sumUnit = new CalculatedField();
            sumUnit.DataSource = report.DataSource;
            sumUnit.DataMember = report.DataMember;
            sumUnit.Name = "sumUnit";
            sumUnit.DisplayName = "sumUnit";
            sumUnit.Expression = "Sum([TotalUnits])";

            report.CalculatedFields.Add(sumUnit);

            CalculatedField sumTW = new CalculatedField();
            sumTW.DataSource = report.DataSource;
            sumTW.DataMember = report.DataMember;
            sumTW.Name = "sumTW";
            sumTW.DisplayName = "sumTW";
            sumTW.Expression = "Sum([TotalWeight])";

            report.CalculatedFields.Add(sumTW);
        }

        private void btnRefreshPivot_Click(object sender, EventArgs e)
        {
            string condition = "";
            DataTable data = new DataTable();
            var toDate = this.deToDate.DateTime.ToString("yyyy-MM-dd");
            var fromDate = this.deFromDate.DateTime.ToString("yyyy-MM-dd");

            if (this.grvProducts.SelectedRowsCount <= 0)
            {
                condition = GetAllProductID();
            }
            else
            {
                condition = GetSelectedProductID();
            }

            if (this.lkeCustomerClientID.EditValue == null || (int)this.lkeCustomerClientID.EditValue <= 0)
            {
                if (this.ckeByWeightInner.Checked)
                {
                    data = FileProcess.LoadTable(" STStockDispatchedReportWeightInner @varFromDate='" + fromDate
                                + "', @varTodate='" + toDate + "' ,  @varCondition='" + condition + "'");
                }
                else
                {
                    data = FileProcess.LoadTable(" STStockDispatchedReport @varFromDate='" + fromDate
                                    + "', @varTodate='" + toDate + "' ,  @varCondition='" + condition + "'");
                }
            }
            else
            {
                if (this.ckeByWeightInner.Checked)
                {
                    data = FileProcess.LoadTable(" STStockDispatchedReportWeightInner @varFromDate='" + fromDate
                                + "', @varTodate='" + toDate + "' ,  @varCondition='" + condition + "', @CustomerClientID=" + Convert.ToInt32(this.lkeCustomerClientID.EditValue));

                }
                else
                {
                    data = FileProcess.LoadTable(" STStockDispatchedReport @varFromDate='" + fromDate
                                    + "', @varTodate='" + toDate + "' ,  @varCondition='" + condition + "', @CustomerClientID=" + Convert.ToInt32(this.lkeCustomerClientID.EditValue));
                }
            }

            this.pvgStockDispatchedReport.DataSource= data;
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
            string condition = "";
            DataTable data = new DataTable();
            var toDate = this.deToDate.DateTime.ToString("yyyy-MM-dd");
            var fromDate = this.deFromDate.DateTime.ToString("yyyy-MM-dd");

            if (this.grvProducts.SelectedRowsCount <= 0)
            {
                condition = GetAllProductID();
            }
            else
            {
                condition = GetSelectedProductID();
            }

            data = FileProcess.LoadTable("STStockDispatchedDetailReport @varFromDate='" + fromDate + "', @varTodate='" + toDate + "', @varCondition='" + condition + "'");
            OpenStockDispatchedDetailReport(data);
        }

        private void checkShowAllInOutProducts_Properties_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkShowAllInOutProducts.Checked)
            {
                string condition = "";
                DataTable data = new DataTable();
                var toDate = this.deToDate.DateTime.ToString("yyyy-MM-dd");
                var fromDate = this.deFromDate.DateTime.ToString("yyyy-MM-dd");

                if (this.grvProducts.SelectedRowsCount <= 0)
                {
                    condition = GetAllProductID();
                }
                else
                {
                    condition = GetSelectedProductID();
                }

                int selectedCustomerID = Convert.ToInt32(lkeCustomerNumber.GetColumnValue("CustomerID"));
                this.pvgStockDispatchedReport.DataSource = FileProcess.LoadTable("STStockDispatchedDetailReport @varFromDate='" + fromDate + "', @varTodate='" + toDate + "', @varCondition='" + condition + "'");
            }
            else
            {
                this.pvgStockDispatchedReport.DataSource = null;
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
                this.pvgStockDispatchedReport.ExportToXlsx(sfd.FileName, options);
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

        private void pvgStockDispatchedReport_CellClick(object sender, DevExpress.XtraPivotGrid.PivotCellEventArgs e)
        {
            Form form = new Form();
            form.Text = "Records";
            // Place a DataGrid control on the form.
            DataGridView grid = new DataGridView();
            grid.Parent = form;
            grid.Dock = DockStyle.Fill;
            // Get the recrd set associated with the current cell and bind it to the grid.
            grid.DataSource = e.CreateDrillDownDataSource();
            form.Bounds = new Rectangle(100, 100, 1000, 400);
            // Display the form.
            form.ShowDialog();
            form.Dispose();
        }

        private void checkMain1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkMain1.Checked)
            {
                string condition = GetAllProductOfMainCustomer();
                DataTable data = new DataTable();
                var toDate = this.deToDate.DateTime.ToString("yyyy-MM-dd");
                var fromDate = this.deFromDate.DateTime.ToString("yyyy-MM-dd");


                int selectedCustomerID = Convert.ToInt32(lkeCustomerNumber.GetColumnValue("CustomerID"));
                this.pvgStockDispatchedReport.DataSource = FileProcess.LoadTable("STStockDispatchedDetailReport @varFromDate='" + fromDate + "', @varTodate='" + toDate + "', @varCondition='" + condition + "'");
                pivotGridField12.Visible = true;
            }
            else
            {
                this.pvgStockDispatchedReport.DataSource = null;
                pivotGridField12.Visible = false;
            }
        }

        private void btnLotNo_Click(object sender, EventArgs e)
        {
            string condition = "";
            DataTable data = new DataTable();
            var toDate = this.deToDate.DateTime.ToString("yyyy-MM-dd");
            var fromDate = this.deFromDate.DateTime.ToString("yyyy-MM-dd");

            if (this.grvProducts.SelectedRowsCount <= 0)
            {
                condition = GetAllProductID();
            }
            else
            {
                condition = GetSelectedProductID();
            }

            if (this.lkeCustomerClientID.EditValue == null || (int)this.lkeCustomerClientID.EditValue <= 0)
            {
                if (this.ckeByWeightInner.Checked)
                {
                    data = FileProcess.LoadTable(" STStockDispatchedReportWeightInnerLotNo @varFromDate='" + fromDate
                                + "', @varTodate='" + toDate + "' ,  @varCondition='" + condition + "'");
                }
                else
                {
                    data = FileProcess.LoadTable(" STStockDispatchedReportLotNo @varFromDate='" + fromDate
                                    + "', @varTodate='" + toDate + "' ,  @varCondition='" + condition + "'");
                }
            }
            else
            {
                if (this.ckeByWeightInner.Checked)
                {
                    data = FileProcess.LoadTable(" STStockDispatchedReportWeightInnerLotNo @varFromDate='" + fromDate
                                + "', @varTodate='" + toDate + "' ,  @varCondition='" + condition + "', @CustomerClientID=" + Convert.ToInt32(this.lkeCustomerClientID.EditValue));

                }
                else
                {
                    data = FileProcess.LoadTable(" STStockDispatchedReportLotNo @varFromDate='" + fromDate
                                    + "', @varTodate='" + toDate + "' ,  @varCondition='" + condition + "', @CustomerClientID=" + Convert.ToInt32(this.lkeCustomerClientID.EditValue));
                }
            }

            OpenStockDispatchedReportLotNo(data);
        }


        private void OpenStockDispatchedReportLotNo(DataTable dataSource)
        {
            if (this.lkeCustomerNumber.EditValue == null) return;
            int customerID = Convert.ToInt32(this.lkeCustomerNumber.EditValue);

            if (dataSource == null || dataSource.Rows.Count <= 0)
            {
                XtraMessageBox.Show("No data to print !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                rptStockDispatchedLotNo report = new rptStockDispatchedLotNo(Convert.ToString(this.lkeCustomerNumber.GetColumnValue("CustomerNumber")), this.txtCustomerName.Text, this.deFromDate.DateTime, this.deToDate.DateTime);
                report.DataSource = dataSource;
                CreateSDReportFields(report);

                GroupField groupField = new GroupField("DispatchingOrderNumber");
                report.GroupHeader2.GroupFields.Add(groupField);

                report.xrLabel29.DataBindings.Add("Text", dataSource, "SumOfTotalPackages");
                report.xrLabel30.DataBindings.Add("Text", dataSource, "TotalUnits");
                report.xrLabel31.DataBindings.Add("Text", dataSource, "Plts");
                report.xrLabel32.DataBindings.Add("Text", dataSource, "TW", "{0:n2}");
                ReportPrintToolWMS tool = new ReportPrintToolWMS(report, customerID);
                tool.ShowPreview();
            }
        }
    }
}
