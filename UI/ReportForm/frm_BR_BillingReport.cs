using DA;
using DA.Master;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Filtering.Templates;
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
using UI.MasterSystemSetup;
using UI.ReportFile;

namespace UI.ReportForm
{
    public partial class frm_BR_BillingReport : Common.Controls.frmBaseForm
    {
        private Customers _currCustomer;
        private DataTable _tbCustomers;
        private frm_BR_Dialog_BillingDetails frmBillingDetail = null;
        private frm_MSS_Contracts frmContracts = null;

        public frm_BR_BillingReport()
        {
            InitializeComponent();
            this._tbCustomers = new DataTable();
            this.dtFromDate.EditValue = FirstDayOfPreviousMonth();
            this.dtToDate.EditValue = LastDayOfPreviousMonth();
        }

        private void frm_BR_BillingReport_Load(object sender, EventArgs e)
        {
            this.chkActiveCustomer.Checked = true;
            this._tbCustomers = FileProcess.LoadTable("SELECT * FROM CustomerListBillings INNER JOIN Customers ON CustomerListBillings.CustomerID = Customers.CustomerID WHERE(((Customers.StoreID) = " + AppSetting.StoreID + ")) ORDER BY CustomerListBillings.CustomerNumber; ");
            LoadCustomers();
            SetEvents();
            this.layoutControlItem23.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }
        public void RefreshGrid()
        {
            //dataGridView1.DataSource = empControl.SelectAll(); //Works great
            this._tbCustomers = FileProcess.LoadTable("ST_WMS_LoadDistributionServicesCustomers " + AppSetting.StoreID + ",'" + dtFromDate.DateTime.ToString("yyyy-MM-dd") + "','" + dtToDate.DateTime.ToString("yyyy-MM-dd") + "'");
            this.grdCustomers.DataSource = this._tbCustomers;
            this.grvCustomers.ClearSelection();
        }
        private void SetEvents()
        {
            this.btnCurrent.Click += BtnCurrent_Click;
            this.btnPrevious.Click += BtnPrevious_Click;
            this.chkActiveCustomer.CheckedChanged += ChkActiveCustomer_CheckedChanged;
            this.chkByPallet.CheckedChanged += ChkByPallet_CheckedChanged;
            this.chkNotBilled.CheckedChanged += ChkNotBilled_CheckedChanged;
            this.chkRandomWeight.CheckedChanged += ChkRandomWeight_CheckedChanged;
            this.chkAll.CheckedChanged += ChkAll_CheckedChanged;
            this.btnClose.Click += BtnClose_Click;
            this.btnByOvertime.Click += BtnByOvertime_Click;
            this.btnViewAll.Click += BtnViewAll_Click;
            this.btnNewByCustomer.Click += BtnNewByCustomer_Click;
            this.btnJoinedCustomer.Click += BtnJoinedCustomer_Click;
            this.btnViewPrevious.Click += BtnViewPrevious_Click;
            this.btnByProduct.Click += BtnByProduct_Click;
        }

        private void BtnByProduct_Click(object sender, EventArgs e)
        {
            if (dtFromDate.DateTime > dtToDate.DateTime)
            {
                XtraMessageBox.Show("Date is not correct !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this.grvCustomers.SelectedRowsCount <= 0)
            {
                XtraMessageBox.Show("Please select customer !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataProcess<object> tmpCustomersDA = new DataProcess<object>();

            int result = tmpCustomersDA.ExecuteNoQuery("Delete From tmpCustomers");
            int[] rowHandles = this.grvCustomers.GetSelectedRows();
            System.Text.StringBuilder condition = new StringBuilder();
            condition.Append("0");

            for (int i = 0; i < rowHandles.Count(); i++)
            {
                int customerID = Convert.ToInt32(this.grvCustomers.GetRowCellValue(rowHandles[i], "CustomerID"));
                result = tmpCustomersDA.ExecuteNoQuery("Insert into tmpCustomers (CustomerID) Values ({0})", customerID);
                condition.Append(",");
                condition.Append(customerID);
            }
            //frmBillingByProduct
            string query = " SELECT DISTINCT Products.ProductID, substring(Products.ProductNumber,5,10) AS XXX, Products.ProductName, Products.WeightPerPackage " +
                           " FROM Products " +
                           " where Products.CustomerID in (" + condition.ToString() + ") " +
                           " ORDER BY substring(Products.ProductNumber,5,10)";

            frm_BR_Dialog_BillingByProduct frm = new frm_BR_Dialog_BillingByProduct(this.dtFromDate.DateTime, this.dtToDate.DateTime, query);
            frm.ShowDialog();
        }

        private void BtnViewPrevious_Click(object sender, EventArgs e)
        {
            if (this.grvCustomers.SelectedRowsCount <= 0)
            {
                XtraMessageBox.Show("Please select customer !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int[] rowHandles = this.grvCustomers.GetSelectedRows();
            int customerID = Convert.ToInt32(this.grvCustomers.GetRowCellValue(rowHandles.FirstOrDefault(), "CustomerID"));
            if (this.frmBillingDetail == null || this.frmBillingDetail.IsDisposed)
            {
                this.frmBillingDetail = new frm_BR_Dialog_BillingDetails(customerID, dtFromDate.DateTime, dtToDate.DateTime);
            }
            else
            {
                this.frmBillingDetail.InitData(customerID, dtFromDate.DateTime, dtToDate.DateTime);
            }

            this.frmBillingDetail.Show();
        }

        private void BtnJoinedCustomer_Click(object sender, EventArgs e)
        {
            if (this.grvCustomers.SelectedRowsCount <= 0)
            {
                XtraMessageBox.Show("Please select customer !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int[] rowHandles = this.grvCustomers.GetSelectedRows();
            int customerID = Convert.ToInt32(this.grvCustomers.GetRowCellValue(rowHandles.FirstOrDefault(), "CustomerID"));

            if (dtFromDate.DateTime > dtToDate.DateTime)
            {
                XtraMessageBox.Show("Date is not correct !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataProcess<object> billingDA = new DataProcess<object>();
            string condition = GetCustomerID();

            billingDA.ExecuteNoQuery("STBillingRunByCustomer @varFromDate = {0}, @varTodate = {1}, @varCustomerString = {2}, @ByPallet = {3}, @DefaultPalletQuantity = {4}, @EmployeeID = {5}, @RandomWeight = {6}", this.dtFromDate.DateTime.ToString("yyyy-MM-dd"), this.dtToDate.DateTime.ToString("yyyy-MM-dd"), condition, 0, 0, AppSetting.CurrentUser.EmployeeID, null);

            if (this.frmBillingDetail == null)
            {
                this.frmBillingDetail = new frm_BR_Dialog_BillingDetails(customerID, dtFromDate.DateTime, dtToDate.DateTime);
            }
            else
            {
                this.frmBillingDetail.InitData(customerID, dtFromDate.DateTime, dtToDate.DateTime);
            }

            frmBillingDetail.Show();

            // Display constract form
            if (this.frmContracts == null)
            {
                if (customerID <= 0) return;
                this.frmContracts = frm_MSS_Contracts.GetInstance(customerID);
                this.frmContracts.InitData(customerID);
            }
            else
            {
                if (customerID <= 0) return;
                this.frmContracts.InitData(customerID);
            }
            frmContracts.Show();
        }

        private void BtnNewByCustomer_Click(object sender, EventArgs e)
        {
            if (this.grvCustomers.SelectedRowsCount <= 0)
            {
                XtraMessageBox.Show("Please select customer !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int[] rowHandles = this.grvCustomers.GetSelectedRows();
            int customerID = Convert.ToInt32(this.grvCustomers.GetRowCellValue(rowHandles.FirstOrDefault(), "CustomerID"));
            Customers customer = AppSetting.CustomerList.Where(c => c.CustomerID == customerID).FirstOrDefault();

            if ((customer.CustomerType.Equals(CustomerTypeEnum.RANDOM_WEIGHT)) && !chkRandomWeight.Checked)
            {
                if (XtraMessageBox.Show("This customer is Random Weight. Do you want to bill by Random Weight?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.chkRandomWeight.Checked = true;
                }
                else
                {
                    this.chkRandomWeight.Checked = false;
                }
            }
            else
            {
                if ((!customer.CustomerType.Equals(CustomerTypeEnum.RANDOM_WEIGHT)) && chkRandomWeight.Checked)
                {
                    if (XtraMessageBox.Show("This customer is not Random Weight. Are you sure you want to bill by Random Weight?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.chkRandomWeight.Checked = true;
                    }
                    else
                    {
                        this.chkRandomWeight.Checked = false;
                    }
                }
            }


            if (dtFromDate.DateTime > dtToDate.DateTime)
            {
                XtraMessageBox.Show("Date is not correct !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataProcess<object> billingDA = new DataProcess<object>();
            string condition = GetCustomerID();

            if (this.chkRandomWeight.Checked)
            {
                billingDA.ExecuteNoQuery("STBillingRunByCustomer @varFromDate = {0}, @varTodate = {1}, @varCustomerString = {2}, @ByPallet = {3}, @DefaultPalletQuantity = {4}, @EmployeeID = {5}, @RandomWeight = {6}", this.dtFromDate.DateTime.ToString("yyyy-MM-dd"), this.dtToDate.DateTime.ToString("yyyy-MM-dd"), condition, 0, 0, AppSetting.CurrentUser.EmployeeID, true);
            }
            else
            {
                billingDA.ExecuteNoQuery("STBillingRunByCustomer @varFromDate = {0}, @varTodate = {1}, @varCustomerString = {2}, @ByPallet = {3}, @DefaultPalletQuantity = {4}, @EmployeeID = {5}", this.dtFromDate.DateTime.ToString("yyyy-MM-dd"), this.dtToDate.DateTime.ToString("yyyy-MM-dd"), condition, 0, 0, AppSetting.CurrentUser.EmployeeID);
            }

            if (this.frmBillingDetail == null)
            {
                this.frmBillingDetail = new frm_BR_Dialog_BillingDetails(customerID, dtFromDate.DateTime, dtToDate.DateTime);
            }
            else
            {
                this.frmBillingDetail.InitData(customerID, dtFromDate.DateTime, dtToDate.DateTime);
            }

            frmBillingDetail.Show();

            // Display constract form
            // Trung - 20/02/18 Disable viewing the contract form because the Billing details includes autohide dock to show contract data
            //if (this.frmContracts == null)
            //{
            //    this.frmContracts = new frm_MSS_Contracts(customerID);
            //}
            //else
            //{
            //    this.frmContracts.InitData(customerID);
            //}
            //frmContracts.Show();
        }

        private void BtnViewAll_Click(object sender, EventArgs e)
        {
            if (this.grvCustomers.SelectedRowsCount <= 0)
            {
                XtraMessageBox.Show("Please select Customer !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int[] rowHandles = this.grvCustomers.GetSelectedRows();
            DataProcess<STBillingByOvertimeReport_Result> billingDA = new DataProcess<STBillingByOvertimeReport_Result>();

            int id = Convert.ToInt32(this.grvCustomers.GetRowCellValue(rowHandles.FirstOrDefault(), "CustomerID"));
            rptOtherServiceHWByOvertimes rpt = new rptOtherServiceHWByOvertimes(0);
            try
            {
                rpt.DataSource = billingDA.Executing("STBillingByOvertimeReport @CustomerID = {0}, @FromDate = {1}, @ToDate = {2}, @Flag = {3}", id, dtFromDate.DateTime, dtToDate.DateTime, 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt, id);
            tool.ShowPreview();
        }

        private void BtnByOvertime_Click(object sender, EventArgs e)
        {
            if (this.grvCustomers.SelectedRowsCount <= 0)
            {
                XtraMessageBox.Show("Please select Customer !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int[] rowHandles = this.grvCustomers.GetSelectedRows();
            DataProcess<STBillingByOvertimeReport_Result> billingDA = new DataProcess<STBillingByOvertimeReport_Result>();

            int id = Convert.ToInt32(this.grvCustomers.GetRowCellValue(rowHandles.FirstOrDefault(), "CustomerID"));
            rptOtherServiceHWByOvertimes rpt = new rptOtherServiceHWByOvertimes(-1);
            try
            {
                rpt.DataSource = billingDA.Executing("STBillingByOvertimeReport @CustomerID = {0}, @FromDate = {1}, @ToDate = {2}, @Flag = {3}", id, dtFromDate.DateTime, dtToDate.DateTime, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            try
            {
                ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt, id);
                tool.ShowPreview();

                this.grdOvertimeReport.DataSource = billingDA.Executing("STBillingByOvertimeReport @CustomerID = {0}, @FromDate = {1}, @ToDate = {2}, @Flag = {3}", id, dtFromDate.DateTime, dtToDate.DateTime, 0);
                this.grvOvertimeReport.PopulateColumns();

                string pathSaveFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string fileName = pathSaveFile + "\\" + "BillingByOvertimeReport_" + DateTime.Now.ToString("dd_MM_yy") + ".xlsx";

                this.grvOvertimeReport.ExportToXlsx(fileName);

                System.Diagnostics.Process.Start(fileName);
            }
            catch (Exception)
            {
            }

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkAll.Checked)
            {
                this.chkActiveCustomer.EditValue = false;
                this.chkByPallet.EditValue = false;
                this.chkNotBilled.EditValue = false;
                this.chkRandomWeight.EditValue = false;
                this.chkDistributionServices.EditValue = false;
                this._tbCustomers = FileProcess.LoadTable("SELECT Customers.CustomerID,Customers.CustomerName,Customers.CustomerNumber, " +
                                                         " CustomerListBillings.FromDate,CustomerListBillings.ToDate, Customers.CustomerType " +
                                                         " FROM CustomerListBillings INNER JOIN Customers ON CustomerListBillings.CustomerID = Customers.CustomerID WHERE Customers.StoreID = " + AppSetting.StoreID
                                                         + "ORDER BY CustomerListBillings.CustomerNumber; ");
                LoadCustomers();
            }
        }

        private void ChkRandomWeight_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkRandomWeight.Checked)
            {
                this.chkActiveCustomer.EditValue = false;
                this.chkByPallet.EditValue = false;
                this.chkNotBilled.EditValue = false;
                this.chkAll.EditValue = false;
                this.chkDistributionServices.EditValue = false;
                //this._tbCustomers = FileProcess.LoadTable("STBillingRunCustomerList @FromDate = '" + this.dtFromDate.DateTime.ToString("yyyy-MM-dd") + "', @ToDate = '" + this.dtToDate.DateTime.ToString("yyyy-MM-dd") + "', @Flag = 0");
                //LoadCustomers();
            }
        }

        private void ChkNotBilled_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkNotBilled.Checked)
            {
                this.chkActiveCustomer.EditValue = false;
                this.chkByPallet.EditValue = false;
                this.chkAll.EditValue = false;
                this.chkRandomWeight.EditValue = false;
                this.chkDistributionServices.EditValue = false;
                this._tbCustomers = FileProcess.LoadTable("STBillingRunCustomerList @FromDate = '"
                    + this.dtFromDate.DateTime.ToString("yyyy-MM-dd") + "', @ToDate = '"
                    + this.dtToDate.DateTime.ToString("yyyy-MM-dd") + "', @Flag = 2"
                    + ",@varStoreID=" + AppSetting.StoreID);
                LoadCustomers();
            }
        }

        private void ChkByPallet_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkByPallet.Checked)
            {
                this.chkActiveCustomer.EditValue = false;
                this.chkAll.EditValue = false;
                this.chkNotBilled.EditValue = false;
                this.chkRandomWeight.EditValue = false;
                this.chkDistributionServices.EditValue = false;
                this._tbCustomers = FileProcess.LoadTable("STBillingRunCustomerList @FromDate = '"
                    + this.dtFromDate.DateTime.ToString("yyyy-MM-dd") + "', @ToDate = '"
                    + this.dtToDate.DateTime.ToString("yyyy-MM-dd") + "', @Flag = 1"
                    + ",@varStoreID=" + AppSetting.StoreID);
                LoadCustomers();
            }
        }

        private void ChkActiveCustomer_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkActiveCustomer.Checked)
            {
                this.chkAll.EditValue = false;
                this.chkByPallet.EditValue = false;
                this.chkNotBilled.EditValue = false;
                this.chkRandomWeight.EditValue = false;
                this.chkDistributionServices.EditValue = false;
                this._tbCustomers = FileProcess.LoadTable("STBillingRunCustomerList @FromDate = '"
                    + this.dtFromDate.DateTime.ToString("yyyy-MM-dd") + "', @ToDate = '"
                    + this.dtToDate.DateTime.ToString("yyyy-MM-dd") + "', @Flag = 0"
                    + ",@varStoreID=" + AppSetting.StoreID);
                LoadCustomers();
            }
        }

        private void BtnPrevious_Click(object sender, EventArgs e)
        {
            if (this.checkEdit25.Checked)
            {
                if (DateTime.Now.Month == 1)
                {
                    this.dtFromDate.EditValue = new DateTime(DateTime.Now.Year - 1, 11, 26);
                    this.dtToDate.EditValue = new DateTime(DateTime.Now.Year - 1, 12, 25);
                }
                else
                {
                    if (DateTime.Now.Month == 2)
                    {
                        this.dtFromDate.EditValue = new DateTime(DateTime.Now.Year - 1, 12, 26);
                        this.dtToDate.EditValue = new DateTime(DateTime.Now.Year, 1, 25);
                    }
                    else
                    {
                        this.dtFromDate.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 2, 26);
                        this.dtToDate.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, 25);
                    }
                }

            }
            else
            {
                if (DateTime.Now.Month != 1)
                {
                    this.dtFromDate.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, 1);
                    this.dtToDate.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month - 1));
                }
                else
                {
                    this.dtFromDate.EditValue = new DateTime(DateTime.Now.Year - 1, 12, 1);
                    this.dtToDate.EditValue = new DateTime(DateTime.Now.Year - 1, 12, 31);
                }

            }
        }

        private void BtnCurrent_Click(object sender, EventArgs e)
        {
            if (this.checkEdit25.Checked)
            {
                if (DateTime.Now.Month != 1)
                    this.dtFromDate.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, 26);
                else
                    this.dtFromDate.EditValue = new DateTime(DateTime.Now.Year - 1, 12, 26);
                this.dtToDate.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 25);
            }
            else
            {
                this.dtFromDate.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                this.dtToDate.EditValue = DateTime.Now;
            }
        }

        #region Load Data
        private void LoadCustomers()
        {
            this.grdCustomers.DataSource = this._tbCustomers;
            this.grvCustomers.ClearSelection();
        }
        #endregion

        private DateTime FirstDayOfPreviousMonth()
        {
            DateTime date;

            if (DateTime.Now.Day > 27) // Cuối tháng
            {
                date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            }
            else
            {
                if (DateTime.Now.Day > 5) // Trong tháng
                {
                    date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                }
                else // Đầu tháng
                {
                    if (DateTime.Now.Month == 1)
                    {
                        date = new DateTime(DateTime.Now.Year - 1, 12, 1);
                    }
                    else
                    {
                        date = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, 1);
                    }
                }
            }

            return date;
        }

        private DateTime LastDayOfPreviousMonth()
        {
            DateTime date;
            if (DateTime.Now.Day > 27) // Cuối tháng
            {
                DateTime temp = new DateTime(DateTime.Now.AddDays(5).Year, DateTime.Now.AddDays(5).Month, 1);
                date = temp.AddDays(-1);
            }
            else
            {
                if (DateTime.Now.Day > 5) // Trong tháng
                {
                    date = DateTime.Now;
                }
                else // Đầu tháng
                {
                    DateTime temp = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    date = temp.AddDays(-1);
                }
            }
            return date;
        }

        private string GetCustomerID()
        {
            string condition = "(";
            int[] rows = this.grvCustomers.GetSelectedRows();
            int count = this.grvCustomers.SelectedRowsCount;

            for (int i = 0; i < count; i++)
            {
                if (i == count - 1)
                {
                    condition = condition + Convert.ToInt32(this.grvCustomers.GetRowCellValue(rows[i], "CustomerID")) + ")";
                }
                else
                {
                    condition = condition + Convert.ToInt32(this.grvCustomers.GetRowCellValue(rows[i], "CustomerID")) + ", ";
                }
            }

            return condition;
        }

        private void grdCustomers_Click(object sender, EventArgs e)
        {

        }

        private void checkEdit25_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkEdit25.Checked)
            {
                if (DateTime.Now.Month != 1)
                    this.dtFromDate.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, 26);
                else
                {
                    this.dtFromDate.EditValue = new DateTime(DateTime.Now.Year - 1, 12, 26);
                }
                this.dtToDate.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 25);
            }
            else
            {
                this.dtFromDate.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                this.dtToDate.EditValue = DateTime.Now;
            }
        }

        private void checkEdit123_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkEdit123.Checked)
            {
                this.chkActiveCustomer.Checked = true;
                this._tbCustomers = FileProcess.LoadTable("SELECT * FROM CustomerListBillings INNER JOIN Customers ON CustomerListBillings.CustomerID = Customers.CustomerID WHERE(((Customers.StoreID) = " + AppSetting.StoreID + ") and Warehouse=1) ORDER BY CustomerListBillings.CustomerNumber; ");
                LoadCustomers();
                SetEvents();
            }
            else
            {
                this.chkActiveCustomer.Checked = true;
                this._tbCustomers = FileProcess.LoadTable("SELECT * FROM CustomerListBillings INNER JOIN Customers ON CustomerListBillings.CustomerID = Customers.CustomerID WHERE(((Customers.StoreID) = " + AppSetting.StoreID + ")) ORDER BY CustomerListBillings.CustomerNumber; ");
                LoadCustomers();
                SetEvents();

            }
        }

        private void checkEdit45_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkEdit45.Checked)
            {
                this.chkActiveCustomer.Checked = true;
                this._tbCustomers = FileProcess.LoadTable("SELECT * FROM CustomerListBillings INNER JOIN Customers ON CustomerListBillings.CustomerID = Customers.CustomerID WHERE(((Customers.StoreID) = " + AppSetting.StoreID + ") and Warehouse=2) ORDER BY CustomerListBillings.CustomerNumber; ");
                LoadCustomers();
                SetEvents();
            }
            else
            {
                this.chkActiveCustomer.Checked = true;
                this._tbCustomers = FileProcess.LoadTable("SELECT * FROM CustomerListBillings INNER JOIN Customers ON CustomerListBillings.CustomerID = Customers.CustomerID WHERE(((Customers.StoreID) = " + AppSetting.StoreID + ")) ORDER BY CustomerListBillings.CustomerNumber; ");
                LoadCustomers();
                SetEvents();

            }
        }

        private void rpi_hpl_CustomerNumber_Click(object sender, EventArgs e)
        {
            int customerID = Convert.ToInt32(this.grvCustomers.GetRowCellValue(this.grvCustomers.FocusedRowHandle, "CustomerID"));
            this._currCustomer = AppSetting.CustomerListAll.Where(c => c.CustomerID == customerID).FirstOrDefault();
            frm_MSS_Customers frm = MasterSystemSetup.frm_MSS_Customers.Instance;
            frm.CurrentCustomers = this._currCustomer;
            frm.Show();
            frm.BringToFront();
            frm.WindowState = FormWindowState.Normal;
        }

        private void checkContactBillings_CheckedChanged(object sender, EventArgs e)
        {
            UpdateBillingContracts();
        }

        private void UpdateBillingContracts()
        {
            if (this.checkContactBillings.Checked == true)
            {
                int _customerID = Convert.ToInt32(this.grvCustomers.GetFocusedRowCellValue("CustomerID"));
                if (_customerID <= 0) return;
                this.pvg6MonthsBillingData.DataSource = FileProcess.LoadTable("STBillingConfirmationViewPrevious " + _customerID);
                this.gridControlContractDetails.DataSource = FileProcess.LoadTable("STBillingContractDetails " + _customerID);
                DataProcess<Customers> customerDA = new DataProcess<Customers>();
                this._currCustomer = customerDA.Select(c => c.CustomerID == _customerID).FirstOrDefault();
                this.txtBillingInstructions.Text = _currCustomer.BillingInstructions;
                this.layoutControlItembtnEdit.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                this.layoutGridContract.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                this.layoutPvGridBillings.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
                this.layoutControlItembtnEdit.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                this.layoutGridContract.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                this.layoutPvGridBillings.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }

        }
        private void grvCustomers_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            UpdateBillingContracts();
        }

        private void btnUpdateBillingInstructions_Click(object sender, EventArgs e)
        {
            if (this.btnUpdateBillingInstructions.Text == "Edit Instructions")
            {
                this.txtBillingInstructions.ReadOnly = false;
                this.btnUpdateBillingInstructions.Text = "Update Change";
            }
            else
            {
                //Code to update Billing Instructions here
                CustomerDA customerDA = new CustomerDA();
                this._currCustomer.BillingInstructions = this.txtBillingInstructions.Text;
                this._currCustomer.BillingInstructionUpdateTime = DateTime.Now;
                customerDA.Update(this._currCustomer);

                this.btnUpdateBillingInstructions.Text = "Edit Instructions";
                this.txtBillingInstructions.ReadOnly = true;
            }
        }

        private void chkDistributionServices_CheckedChanged(object sender, EventArgs e)
        {

            if (this.chkDistributionServices.Checked)
            {
                this.chkAll.EditValue = false;
                this.chkByPallet.EditValue = false;
                this.chkNotBilled.EditValue = false;
                this.chkRandomWeight.EditValue = false;
                this.chkActiveCustomer.EditValue = false;

                this._tbCustomers = FileProcess.LoadTable("ST_WMS_LoadDistributionServicesCustomers " + AppSetting.StoreID + ",'" + dtFromDate.DateTime.ToString("yyyy-MM-dd") + "','" + dtToDate.DateTime.ToString("yyyy-MM-dd") + "'");
                LoadCustomers();
                this.layoutControlItem23.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
                this.layoutControlItem23.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }


        }

        private void btnDistributionServices_Click(object sender, EventArgs e)
        {
            var dl = MessageBox.Show("You want to run bill with BillingWeight click YES, run bill with old function click NO!", "TPWMS", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            if (dl.Equals(DialogResult.Cancel)) return;

            if (dl.Equals(DialogResult.No))
            {
                //Code to open form DistributionServices
                int cusID = Convert.ToInt32(this.grvCustomers.GetFocusedRowCellValue("CustomerID"));
                string cusNum = this.grvCustomers.GetFocusedRowCellValue("CustomerNumber").ToString();
                string cusName = this.grvCustomers.GetFocusedRowCellValue("CustomerName").ToString();
                //Check if the Customr is alrady billed ?
                DateTime lastBillDate = Convert.ToDateTime(this.grvCustomers.GetFocusedRowCellValue("ToDate"));

                if (this.dtFromDate.DateTime < lastBillDate)
                {
                    frm_BR_BillingDistributionServices frm = new frm_BR_BillingDistributionServices(cusID, cusNum, cusName, this.dtFromDate.DateTime, this.dtToDate.DateTime, 0, 0, 1);
                    frm.Show();
                    frm.BringToFront();
                }

                else
                {
                    frm_BR_BillingDistributionServices frm = new frm_BR_BillingDistributionServices(cusID, cusNum, cusName, this.dtFromDate.DateTime, this.dtToDate.DateTime, 0, 0, 0);
                    frm.Show();
                    frm.BringToFront();
                }
            }

            if (dl.Equals(DialogResult.Yes))
            {
                //Code to open form DistributionServices
                int cusID = Convert.ToInt32(this.grvCustomers.GetFocusedRowCellValue("CustomerID"));
                string cusNum = this.grvCustomers.GetFocusedRowCellValue("CustomerNumber").ToString();
                string cusName = this.grvCustomers.GetFocusedRowCellValue("CustomerName").ToString();
                //Check if the Customr is alrady billed ?
                DateTime lastBillDate = Convert.ToDateTime(this.grvCustomers.GetFocusedRowCellValue("ToDate"));

                if (this.dtFromDate.DateTime < lastBillDate)
                {
                    frm_BR_BillingDistributionServices frm = new frm_BR_BillingDistributionServices(cusID, cusNum, cusName, this.dtFromDate.DateTime, this.dtToDate.DateTime, 0, 0, 1);
                    frm.Show();
                    frm.BringToFront();
                }

                else
                {
                    frm_BR_BillingDistributionServices frm = new frm_BR_BillingDistributionServices(cusID, cusNum, cusName, this.dtFromDate.DateTime, this.dtToDate.DateTime, 0, 0, 0, 1);
                    frm.Show();
                    frm.BringToFront();
                }
            }

        }

        private void btnEstimateData_Click(object sender, EventArgs e)
        {
            //string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            //string fileExport = path + "_" + System.DateTime.Now.ToString("yyMMddHHmmss") + ".xlsx";
            ////var datasource = FileProcess.LoadTable("SPBillingEstimationsSelectFromDateToDate  @FromDate='" + this.dtFromDate.DateTime.ToString() + "', @ToDate='" + this.dtToDate.DateTime.ToString() + "'");
            ////hieu fix
            //var datasource = FileProcess.LoadTable("SPBillingEstimationsSelectFromDateToDate  @FromDate='" + this.dtFromDate.DateTime.ToString("yyyy-M-dd") + "', @ToDate='" + this.dtToDate.DateTime.ToString("yyyy-M-dd") + "'");
            //DevExpress.XtraGrid.GridControl grdReport = new DevExpress.XtraGrid.GridControl();
            //DevExpress.XtraGrid.Views.Grid.GridView grvReport = new DevExpress.XtraGrid.Views.Grid.GridView(grdReport);
            //grdReport.MainView = grvReport;
            //grdReport.ForceInitialize();
            //grdReport.BindingContext = new BindingContext();
            //grdReport.DataSource = datasource;
            //grvReport.PopulateColumns();
            //// Export data to excel file
            //grvReport.ExportToXlsx(fileExport);
            //System.Diagnostics.Process.Start(fileExport);

            string customerSelect = "";
            int[] rowHandles = this.grvCustomers.GetSelectedRows();

            for (int i = 0; i < rowHandles.Count(); i++)
            {
                customerSelect += "'"+this.grvCustomers.GetRowCellValue(rowHandles[i], "CustomerNumber")+"'";
                if (i < rowHandles.Count() - 1)
                    customerSelect += ",";
            }

            ReportForm.frm_BR_Estimate_Data frm = new ReportForm.frm_BR_Estimate_Data(this.dtFromDate.DateTime, this.dtToDate.DateTime, customerSelect);
            frm.Show(); frm.BringToFront();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            rptBillingEstimations rpt = new rptBillingEstimations(this.dtFromDate.DateTime, this.dtToDate.DateTime);
            rpt.DataSource = FileProcess.LoadTable("SPBillingEstimationsSelectFromDateToDate  @FromDate='" + dtFromDate.DateTime.ToString("yyyy-M-dd") + "', @ToDate='" + dtToDate.DateTime.ToString("yyyy-M-dd") + "'");
            //rpt.DataSource = FileProcess.LoadTable("SPBillingEstimationsSelectFromDateToDate  @FromDate='" + dtFromDate+ "', @ToDate='" + dtToDate+ "'");

            ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
            tool.ShowPreview();
        }
    }
}
