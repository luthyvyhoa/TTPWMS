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
using DA;
using UI.Helper;
using UI.ReportFile;
using UI.MasterSystemSetup;
using DevExpress.XtraEditors;
using DevExpress.XtraReports;
using DevExpress.XtraReports.UI;
using DevExpress.SpreadsheetSource.Implementation;
using Common.Process;
using UI.WarehouseManagement;

namespace UI.ReportForm
{
    public partial class frm_WR_StockOnHandByLotReport : frmBaseForm
    {
        //private DataProcess<STStockOnHandByLotListProducts_Result> _productDA;
        private DataTable _reportSource;

        public frm_WR_StockOnHandByLotReport()
        {
            InitializeComponent();
            this.IsFixHeightScreen = false;
            //this._productDA = new DataProcess<STStockOnHandByLotListProducts_Result>();
            this._reportSource = new DataTable();
        }

        private void frm_WR_StockOnHandByLotReport_Load(object sender, EventArgs e)
        {
            InitCustomer();

            SetEvents();
        }

        private void frm_WR_StockOnHandByLotReport_Shown(object sender, EventArgs e)
        {
            this.lkeCustomers.Focus();
            this.lkeCustomers.ShowPopup();
        }

        private void SetEvents()
        {
            this.lkeCustomers.KeyDown += lkeCustomers_KeyDown;
            this.lkeCustomers.CloseUp += LkeCustomers_CloseUp;
            this.btnClose.Click += btnClose_Click;
            this.btnByExpiryAll.Click += btnByExpiryAll_Click;
            this.btnByProductionDate.Click += btnByProductionDate_Click;
            this.btnByRO.Click += btnByRO_Click;

            this.btnDetailedByAge.Click += btnDetailedByAge_Click;
            this.btnOnHold.Click += btnOnHold_Click;
            this.btnQADetailWeekly.Click += btnQADetailWeekly_Click;
            this.btnQAWeekly.Click += btnQAWeekly_Click;
            this.btnQAWeeklyExcel.Click += btnQAWeeklyExcel_Click;
            this.btnReportQuarantined.Click += btnReportQuarantined_Click;
            this.btnStockByAge.Click += btnStockByAge_Click;
            this.btnViewReport.Click += btnViewReport_Click;
            this.btnKGR.Click += btnKGR_Click;
        }

        private void LkeCustomers_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.Value == null) return;
            this.lkeCustomers.EditValue = e.Value;
            this.txtCustomerName.Text = Convert.ToString(this.lkeCustomers.GetColumnValue("CustomerName"));

            if (this.lkeCustomers.GetColumnValue("CustomerType").Equals(CustomerTypeEnum.RANDOM_WEIGHT))
            {
                this.chkByWeight.Checked = true;
            }

            LoadProducts();
        }

        void lkeCustomers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                this.txtCustomerName.Text = Convert.ToString(this.lkeCustomers.GetColumnValue("CustomerName"));

                if (this.lkeCustomers.GetColumnValue("CustomerType").Equals(CustomerTypeEnum.RANDOM_WEIGHT))
                {
                    this.chkByWeight.Checked = true;
                }

                LoadProducts();
            }
        }

        #region Load Data
        private void LoadProducts()
        {
            if (this.checkEditMainCustomer.Checked)
            {
                this.grdProducts.DataSource = FileProcess.LoadTable("STStockOnHandByLotListProductsMainCustomer " + this.lkeCustomers.EditValue);
            }
            else
            {
                this.grdProducts.DataSource = FileProcess.LoadTable("STStockOnHandByLotListProducts " + this.lkeCustomers.EditValue);
            }
            this.grvProducts.ClearSelection();
        }

        private void InitCustomer()
        {
            this.lkeCustomers.Properties.DataSource = AppSetting.CustomerList;
            this.lkeCustomers.Properties.ValueMember = "CustomerID";
            this.lkeCustomers.Properties.DisplayMember = "CustomerNumber";
        }
        #endregion

        #region Events

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            if (this.lkeCustomers.EditValue == null) return;
            int customerID = Convert.ToInt32(this.lkeCustomers.EditValue);

            UpdateSQL();

            if (this._reportSource == null || this._reportSource.Rows.Count <= 0)
            {
                XtraMessageBox.Show("No data to print!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            XtraReport rpt;

            if (chkByWeight.Checked)
            {
                rpt = new rptStockOnHandByLotWeightInners();
                rpt.DataSource = this._reportSource;
            }
            else
            {
                rpt = new rptStockOnHandByLot();
                rpt.DataSource = this._reportSource;
            }

            ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt,customerID);
            tool.ShowPreview();
        }

        private void btnStockByAge_Click(object sender, EventArgs e)
        {
            if (this.lkeCustomers.EditValue == null) return;
            int customerID = Convert.ToInt32(this.lkeCustomers.EditValue);

            DataProcess<WebChartStockOnHandByAge_Result> chartDA = new DataProcess<WebChartStockOnHandByAge_Result>();

            rptStockOnHandByAgeSummary rpt = new rptStockOnHandByAgeSummary();
            var dataSource = chartDA.Executing("WebChartStockOnHandByAge @CustomerMainID = {0}", Convert.ToInt32(this.lkeCustomers.EditValue));
            if (dataSource == null || dataSource.Count() <= 0)
            {
                MessageBox.Show("No data to print!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            rpt.DataSource = dataSource;
            ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt,customerID);
            tool.ShowPreview();
        }

        private void btnReportQuarantined_Click(object sender, EventArgs e)
        {
            if (this.lkeCustomers.EditValue == null) return;
            int customerID = Convert.ToInt32(this.lkeCustomers.EditValue);

            rptStockOnHandOnHoldQuarantined rpt = new rptStockOnHandOnHoldQuarantined();
            var dataSource = FileProcess.LoadTable("STStockOnHandByCustomerOnHoldQuaratined @CustomerID =" + Convert.ToInt32(this.lkeCustomers.EditValue));
            if (dataSource == null || dataSource.Rows.Count <= 0)
            {
                MessageBox.Show("No data to print!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            rpt.DataSource = dataSource;
            ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt,customerID);
            tool.ShowPreview();
        }

        private void btnQAWeeklyExcel_Click(object sender, EventArgs e)
        {
            if (this.lkeCustomers.EditValue == null)
            {
                this.lkeCustomers.Focus();
                this.lkeCustomers.ShowPopup();
            }
            else
            {
                try
                {
                    Wait.Start(this);
                    DevExpress.XtraGrid.GridControl grdReport = new DevExpress.XtraGrid.GridControl();
                    DevExpress.XtraGrid.Views.Grid.GridView grvReport = new DevExpress.XtraGrid.Views.Grid.GridView(grdReport);
                    grdReport.MainView = grvReport;
                    grdReport.ForceInitialize();
                    grdReport.BindingContext = new BindingContext();
                    grdReport.DataSource = FileProcess.LoadTable("STQAWeeklyReport @CustomerID = " + Convert.ToInt32(this.lkeCustomers.EditValue));
                    grvReport.PopulateColumns();

                    // Export data to excel file
                    string pathSaveFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    string fileName = pathSaveFile + "\\" + "QAGeneralReport_" + DateTime.Now.ToString("dd_MM_yy") + ".xlsx";

                    grvReport.ExportToXlsx(fileName);

                    System.Diagnostics.Process.Start(fileName);
                    Wait.Close();
                }
                catch (Exception ex)
                {
                    Wait.Close();
                    XtraMessageBox.Show(ex.Message, "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnQAWeekly_Click(object sender, EventArgs e)
        {
            if (this.lkeCustomers.EditValue == null) return;
            int customerID = Convert.ToInt32(this.lkeCustomers.EditValue);

            DataProcess<STQAWeeklyReport_Result> qaWeekly = new DataProcess<STQAWeeklyReport_Result>();
            List<STQAWeeklyReport_Result> dataSource = qaWeekly.Executing("STQAWeeklyReport @CustomerID = {0}", Convert.ToInt32(this.lkeCustomers.EditValue)).ToList();

            rptQAWeeklyReport rpt = new rptQAWeeklyReport();
            if (dataSource == null || dataSource.Count() <= 0)
            {
                MessageBox.Show("No data to print!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            rpt.DataSource = dataSource;
            ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt,customerID);
            tool.ShowPreview();
        }

        private void btnQADetailWeekly_Click(object sender, EventArgs e)
        {
            if (this.lkeCustomers.EditValue == null)
            {
                this.lkeCustomers.Focus();
                this.lkeCustomers.ShowPopup();
            }
            else
            {
                try
                {
                    Wait.Start(this);
                    DevExpress.XtraGrid.GridControl grdReport = new DevExpress.XtraGrid.GridControl();
                    DevExpress.XtraGrid.Views.Grid.GridView grvReport = new DevExpress.XtraGrid.Views.Grid.GridView(grdReport);
                    grdReport.MainView = grvReport;
                    grdReport.ForceInitialize();
                    grdReport.BindingContext = new BindingContext();
                    grdReport.DataSource = FileProcess.LoadTable("STQADetailWeeklyReport @CustomerID = " + Convert.ToInt32(this.lkeCustomers.EditValue));
                    grvReport.PopulateColumns();

                    // Export data to excel file
                    string pathSaveFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    string fileName = pathSaveFile + "\\" + "QADetailWeekly_" + DateTime.Now.ToString("dd_MM_yy") + ".xlsx";

                    grvReport.ExportToXlsx(fileName);

                    System.Diagnostics.Process.Start(fileName);
                    Wait.Close();
                }
                catch (Exception ex)
                {
                    Wait.Close();
                    XtraMessageBox.Show(ex.Message, "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnOnHold_Click(object sender, EventArgs e)
        {
            if (this.lkeCustomers.EditValue == null) return;
            int customerID = Convert.ToInt32(this.lkeCustomers.EditValue);

            rptStockOnHandOnHold rpt = new rptStockOnHandOnHold();
            var dataSource = FileProcess.LoadTable("STStockOnHandByCustomerOnHold @varCustomerID =" + Convert.ToInt32(this.lkeCustomers.EditValue));
            if (dataSource == null || dataSource.Rows.Count <= 0)
            {
                MessageBox.Show("No data to print!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            rpt.DataSource = dataSource;

            ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt,customerID);
            tool.ShowPreview();
        }

        private void btnDetailedByAge_Click(object sender, EventArgs e)
        {
            if (this.checkEditAllCustomer.Checked)
            {                
                rptStockOnHandByAge rpt = new rptStockOnHandByAge();
                var dataSource = FileProcess.LoadTable("STStockOnHandByAgeByCustomer @CustomerID = 0");
                if (dataSource == null || dataSource.Rows.Count <= 0)
                {
                    MessageBox.Show("No data to print!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                rpt.DataSource = dataSource;
                ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt, 0);
                tool.ShowPreview();
            }
            else
            {
                if (this.lkeCustomers.EditValue == null) return;
                int customerID = Convert.ToInt32(this.lkeCustomers.EditValue);

                rptStockOnHandByAge rpt = new rptStockOnHandByAge();
                var dataSource = FileProcess.LoadTable("STStockOnHandByAgeByCustomer @CustomerID = " + Convert.ToInt32(this.lkeCustomers.EditValue));
                if (dataSource == null || dataSource.Rows.Count <= 0)
                {
                    MessageBox.Show("No data to print!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                rpt.DataSource = dataSource;
                ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt, customerID);
                tool.ShowPreview();
            }
        }

        private void btnCustomerInfo_Click(object sender, EventArgs e)
        {
            Customers customer = AppSetting.CustomerList.Where(c => c.CustomerID == Convert.ToInt32(this.lkeCustomers.EditValue)).FirstOrDefault();

            frm_MSS_Customers frmCustomer = MasterSystemSetup.frm_MSS_Customers.Instance;
            frmCustomer.CurrentCustomers = customer;
            frmCustomer.WindowState = FormWindowState.Normal;
            frmCustomer.BringToFront();
            frmCustomer.Show();
        }

        private void btnByRO_Click(object sender, EventArgs e)
        {
            if (this.lkeCustomers.EditValue == null) return;
            int customerID = Convert.ToInt32(this.lkeCustomers.EditValue);

            UpdateSQL();

            if (this._reportSource == null || this._reportSource.Rows.Count <= 0)
            {
                XtraMessageBox.Show("No data to print!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            rptStockOnHandByLotByRO rpt = new rptStockOnHandByLotByRO();
            rpt.DataSource = this._reportSource;
            ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt,customerID);
            tool.ShowPreview();
        }

        private void btnByProductionDate_Click(object sender, EventArgs e)
        {
            if (this.lkeCustomers.EditValue == null) return;
            int customerID = Convert.ToInt32(this.lkeCustomers.EditValue);

            DataProcess<STStockOnHandByProDateByCustomer_Result> prodDateByCustomer = new DataProcess<STStockOnHandByProDateByCustomer_Result>();
            rptStockOnHandByAge rpt = new rptStockOnHandByAge();
            var dataSource = FileProcess.LoadTable("STStockOnHandByProDateByCustomer @CustomerID=" + Convert.ToInt32(this.lkeCustomers.EditValue));
            if (dataSource == null || dataSource.Rows.Count <= 0)
            {
                MessageBox.Show("No data to print!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            rpt.DataSource = dataSource;
            ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt,customerID);
            tool.ShowPreview();
        }

        private void btnByExpiryAll_Click(object sender, EventArgs e)
        {
            try
            {
                Wait.Start(this);
                DevExpress.XtraGrid.GridControl grdReport = new DevExpress.XtraGrid.GridControl();
                DevExpress.XtraGrid.Views.Grid.GridView grvReport = new DevExpress.XtraGrid.Views.Grid.GridView(grdReport);
                grdReport.MainView = grvReport;
                grdReport.ForceInitialize();
                grdReport.BindingContext = new BindingContext();
                grdReport.DataSource = FileProcess.LoadTable("STStockOnHandByProductAllCustomerByExpiry "+AppSetting.CurrentUser.StoreID);
                grvReport.PopulateColumns();

                // Export data to excel file
                string pathSaveFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string fileName = pathSaveFile + "\\" + "ByExpiryAllByCustomer_" + DateTime.Now.ToString("dd_MM_yy") + ".xlsx";

                grvReport.ExportToXlsx(fileName);

                System.Diagnostics.Process.Start(fileName);
                Wait.Close();
            }
            catch (Exception ex)
            {
                Wait.Close();
                XtraMessageBox.Show(ex.Message, "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            string condition = "(";
            if (this.grvProducts.SelectedRowsCount <= 0)
            {
                condition = "(SELECT ProductID FROM Products WHERE CustomerID = " + this.lkeCustomers.EditValue + ")";
            }
            else
            {
                int productIDSelected = 0;
                int i = 0;
                foreach (int rowIndex in this.grvProducts.GetSelectedRows())
                {
                    productIDSelected = Convert.ToInt32(this.grvProducts.GetRowCellValue(rowIndex, "ProductID"));
                    if (i == this.grvProducts.SelectedRowsCount - 1)
                    {
                        condition = condition + productIDSelected + ")";
                    }
                    else
                    {
                        condition = condition + productIDSelected + ", ";
                    }
                }
            }

            return condition;
        }

        private void UpdateSQL()
        {
            this._reportSource.Clear();
            string condition = "";

            if (this.grvProducts.SelectedRowsCount <= 0)
            {
                condition = GetAllProductID();
            }
            else
            {
                condition = GetSelectedProductID();
            }

            if (chkByWeight.Checked)
            {
                this._reportSource = FileProcess.LoadTable("STStockOnHandByLotReportWeightInners @varCondition='" + condition + "'");
            }
            else
            {
                this._reportSource = FileProcess.LoadTable("STStockOnHandByLotReport @varCondition='" + condition + "'");
            }
            if (this._reportSource == null)
            {
                this._reportSource = new DataTable();
            }

        }

        /// <summary>
        /// Handles the Click event of the btnKGR control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <exception cref="NotImplementedException"></exception>
        private void btnKGR_Click(object sender, EventArgs e)
        {
            // TODO: Query data + display report - KGR
            // Need to using other Stored Proc from A.Hung to display data
            if (this.lkeCustomers.EditValue == null) return;
            int customerID = Convert.ToInt32(this.lkeCustomers.EditValue);

            UpdateSQL();
                
            if (this._reportSource == null || this._reportSource.Rows.Count <= 0)
            {
                XtraMessageBox.Show("No data to print!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            XtraReport rpt;
            rpt = new rptStockOnHandByLotKGR
            {
                DataSource = this._reportSource
            };

            ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt, customerID);
            tool.ShowPreview();
        }

        private void txtCustomerName_Click(object sender, EventArgs e)
        {
            Customers customer = AppSetting.CustomerList.Where(c => c.CustomerID == Convert.ToInt32(this.lkeCustomers.EditValue)).FirstOrDefault();

            frm_MSS_Customers frmCustomer = MasterSystemSetup.frm_MSS_Customers.Instance;
            frmCustomer.CurrentCustomers = customer;
            frmCustomer.WindowState = FormWindowState.Normal;
            frmCustomer.BringToFront();
            frmCustomer.Show();
        }

        private void checkEditMainCustomer_CheckedChanged(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void rpe_productID_Click(object sender, EventArgs e)
        {
            frm_WM_PalletInfo frm = new frm_WM_PalletInfo(Convert.ToInt32(this.lkeCustomers.EditValue.ToString()), Convert.ToInt32(this.grvProducts.GetFocusedRowCellValue("ProductID").ToString()));
            frm.Show();
            frm.BringToFront();
            frm.WindowState = FormWindowState.Maximized;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadProducts();
        }
    }
}
