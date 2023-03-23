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

namespace UI.Management
{
    public partial class frm_M_GO_EmployeeWorkingCheck : Common.Controls.frmBaseForm
    {
        private int _currentPercentage; // 0 = > 100%, 1 => All, 2 => Summary 
        private int _currentOrder; // 0 => RO+DO, 1 => OJ, 2 => Customer
        private bool _isReCheck;

        public frm_M_GO_EmployeeWorkingCheck()
        {
            InitializeComponent();
            this._currentOrder = 0;
            this._currentPercentage = 0;
            this._isReCheck = false;
        }

        private void frm_M_GO_EmployeeWorkingCheck_Load(object sender, EventArgs e)
        {
            InitMonth();
            InitCustomer();
            this.chkPercent.Checked = true;
            this.chkRODO.Checked = true;
            SetEvents();
        }

        private void SetEvents()
        {
            this.btnISO.Click += BtnISO_Click;
            this.btnView.Click += BtnView_Click;
            this.btnABABigC.Click += BtnABABigC_Click;
            this.btnProductionEvaluation.Click += BtnProductionEvaluation_Click;
            this.btnCustomerEvaluation.Click += BtnCustomerEvaluation_Click;
            this.chkAll.CheckedChanged += PercentageTypeChanged;
            this.chkPercent.CheckedChanged += PercentageTypeChanged;
            this.chkSummary.CheckedChanged += PercentageTypeChanged;
            this.chkRODO.CheckedChanged += OrderTypeChanged;
            this.chkCustomer.CheckedChanged += OrderTypeChanged;
            this.chkOtherJob.CheckedChanged += OrderTypeChanged;
            this.lkeMonth.CloseUp += LkeMonth_CloseUp;
            this.lkeCustomer.CloseUp += LkeCustomer_CloseUp;
        }

        private void BtnISO_Click(object sender, EventArgs e)
        {
            this.grdReports.DataSource = FileProcess.LoadTable("STISOQuantityOfRecordRODO @FromDate = '" + this.dtFrom.DateTime.ToString("yyyy-MM-dd")+ "', @ToDate = '"+this.dtTo.DateTime.ToString("yyyy-MM-dd")+"'");
            this.grvReports.Columns.Clear();
            this.grvReports.PopulateColumns();

            string pathSaveFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string fileName = pathSaveFile + "\\" + "ISORecordOfRODO_" + DateTime.Now.ToString("dd_MM_yy") + ".xlsx";

            this.grvReports.ExportToXlsx(fileName);

            System.Diagnostics.Process.Start(fileName);
        }

        private void BtnView_Click(object sender, EventArgs e)
        {
            if(this._currentPercentage == 2)
            {
                this.grdReports.DataSource = FileProcess.LoadTable("STEmployeeWorkingProductionQtySummaryCheck @FromDate = '" + this.dtFrom.DateTime.ToString("yyyy-MM-dd") + "', @ToDate = '" + this.dtTo.DateTime.ToString("yyyy-MM-dd") + "'");
            }
            else
            {
                if(this._currentOrder == 2)
                {
                    this.grdReports.DataSource = FileProcess.LoadTable("STEmployeeWorkingProductionQtyCheck @FromDate = '" + this.dtFrom.DateTime.ToString("yyyy-MM-dd") + "', @ToDate = '" + this.dtTo.DateTime.ToString("yyyy-MM-dd") + "', @Flag = " + this._currentOrder + ", @CustomerMainID = " + Convert.ToInt32(this.lkeCustomer.EditValue) + ", @FlagPercentage = " + this._currentPercentage);
                }
                else
                {
                    this.grdReports.DataSource = FileProcess.LoadTable("STEmployeeWorkingProductionQtyCheck @FromDate = '" + this.dtFrom.DateTime.ToString("yyyy-MM-dd") + "', @ToDate = '" + this.dtTo.DateTime.ToString("yyyy-MM-dd") + "', @Flag = " + this._currentOrder + ", @CustomerMainID = 0, @FlagPercentage = " + this._currentPercentage);
                }
            }

            this.grvReports.Columns.Clear();
            this.grvReports.PopulateColumns();

            string pathSaveFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string fileName = pathSaveFile + "\\" + "GeneralHandPercent_" + DateTime.Now.ToString("dd_MM_yy") + ".xlsx";

            this.grvReports.ExportToXlsx(fileName);

            System.Diagnostics.Process.Start(fileName);
        }

        private void BtnABABigC_Click(object sender, EventArgs e)
        {
            if (this._currentOrder == 2)
            {
                if (this.lkeCustomer.EditValue == null)
                {
                    this.lkeCustomer.Focus();
                    this.lkeCustomer.ShowPopup();
                }
                else
                {
                    this.grdReports.DataSource = FileProcess.LoadTable("STCustomerEvaluationAndAnalyzingABA @CustomerMainID = "+Convert.ToInt32(this.lkeCustomer.EditValue)+", @varFromdate = '"+ this.dtFrom.DateTime.ToString("yyyy-MM-dd") + "', @varTodate = '"+this.dtTo.DateTime.ToString("yyyy-MM-dd")+"'");
                    this.grvReports.Columns.Clear();
                    this.grvReports.PopulateColumns();

                    string pathSaveFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    string fileName = pathSaveFile + "\\" + "GeneralHandPercent_" + DateTime.Now.ToString("dd_MM_yy") + ".xlsx";

                    this.grvReports.ExportToXlsx(fileName);

                    System.Diagnostics.Process.Start(fileName);
                }
            }
        }

        private void BtnProductionEvaluation_Click(object sender, EventArgs e)
        {
            if (this._currentOrder == 2)
            {
                if (this.lkeCustomer.EditValue == null)
                {
                    this.lkeCustomer.Focus();
                    this.lkeCustomer.ShowPopup();
                }
                else
                {
                    this.grdReports.DataSource = FileProcess.LoadTable("STCustomerEvaluationAndAnalyzing @CustomerMainID = " + Convert.ToInt32(this.lkeCustomer.EditValue) + ", @varFromdate = '" + this.dtFrom.DateTime.ToString("yyyy-MM-dd") + "', @varTodate = '" + this.dtTo.DateTime.ToString("yyyy-MM-dd") + "'");
                    this.grvReports.Columns.Clear();
                    this.grvReports.PopulateColumns();

                    string pathSaveFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    string fileName = pathSaveFile + "\\" + "GeneralHandPercent_" + DateTime.Now.ToString("dd_MM_yy") + ".xlsx";

                    this.grvReports.ExportToXlsx(fileName);

                    System.Diagnostics.Process.Start(fileName);
                }
            }
        }

        private void BtnCustomerEvaluation_Click(object sender, EventArgs e)
        {
            if(this._currentOrder == 2)
            {
                if(this.lkeCustomer.EditValue == null)
                {
                    this.lkeCustomer.Focus();
                    this.lkeCustomer.ShowPopup();
                }
                else
                {
                    this.grdReports.DataSource = FileProcess.LoadTable("STCustomerEvaluationAndAnalyzingSummary @CustomerMainID = " + Convert.ToInt32(this.lkeCustomer.EditValue) + ", @FD = '" + this.dtFrom.DateTime.ToString("yyyy-MM-dd") + "', @TD = '" + this.dtTo.DateTime.ToString("yyyy-MM-dd") + "'");
                    this.grvReports.Columns.Clear();
                    this.grvReports.PopulateColumns();

                    string pathSaveFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    string fileName = pathSaveFile + "\\" + "GeneralHandPercent_" + DateTime.Now.ToString("dd_MM_yy") + ".xlsx";

                    this.grvReports.ExportToXlsx(fileName);

                    System.Diagnostics.Process.Start(fileName);
                }
            }
        }

        private void OrderTypeChanged(object sender, EventArgs e)
        {
            CheckEdit edit = sender as CheckEdit;
            if (edit.Checked)
            {
                switch (this._currentOrder)
                {
                    case 0:
                        {
                            this.chkRODO.Checked = false;
                            break;
                        }
                    case 1:
                        {
                            this.chkOtherJob.Checked = false;
                            break;
                        }
                    case 2:
                        {
                            this.chkCustomer.Checked = false;
                            this.lkeCustomer.ReadOnly = true;
                            break;
                        }
                }
                this._currentOrder = Convert.ToInt32(edit.Tag);

                if(this._currentOrder == 2)
                {
                    this.lkeCustomer.ReadOnly = false;
                    this.lkeCustomer.Focus();
                    this.lkeCustomer.ShowPopup();
                }
            }
            else
            {
                this._isReCheck = true;
                edit.Checked = true;
            }
        }

        private void PercentageTypeChanged(object sender, EventArgs e)
        {
            CheckEdit edit = sender as CheckEdit;
            if(edit.Checked)
            {
                switch (this._currentPercentage)
                {
                    case 0:
                        {
                            this.chkPercent.Checked = false;
                            break;
                        }
                    case 1:
                        {
                            this.chkAll.Checked = false;
                            break;
                        }
                    case 2:
                        {
                            this.chkSummary.Checked = false;
                            break;
                        }
                }
                this._currentPercentage = Convert.ToInt32(edit.Tag);
            }
        }

        private void LkeCustomer_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            this.lkeCustomer.EditValue = e.Value;
            this.txtCustomerName.Text = Convert.ToString(this.lkeCustomer.GetColumnValue("CustomerName"));
        }

        private void LkeMonth_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            this.lkeMonth.EditValue = e.Value;
            this.dtFrom.EditValue = this.lkeMonth.GetColumnValue("FromDate");
            this.dtTo.EditValue = this.lkeMonth.GetColumnValue("ToDate");
            LoadEmployeePerformance();
        }

        #region Load Data
        private void LoadEmployeePerformance()
        {
            this.grdEmployeePerformance.DataSource = FileProcess.LoadTable("STEmployeeWorkingPerformanceAnalyzing @FromDate = '"+this.dtFrom.DateTime.ToString("yyyy-MM-dd")+ "', @ToDate = '"+this.dtTo.DateTime.ToString("yyyy-MM-dd")+"'");
        }

        private void InitCustomer()
        {
            this.lkeCustomer.Properties.DataSource = FileProcess.LoadTable("STcomboCustomerMainID @varStoreID = " + AppSetting.StoreID);
            this.lkeCustomer.Properties.ValueMember = "CustomerMainID";
            this.lkeCustomer.Properties.DisplayMember = "CustomerNumber";
        }

        private void InitMonth()
        {
            this.lkeMonth.Properties.DataSource = FileProcess.LoadTable("SELECT TOP 50 PayrollMonth.PayRollMonthID, PayrollMonth.PayRollMonth, PayrollMonth.FromDate, PayrollMonth.ToDate"
                                                                        + " FROM PayrollMonth"
                                                                        + " WHERE(((PayrollMonth.PayRollMonthID) > 74))"
                                                                        + " ORDER BY PayrollMonth.PayRollMonthID DESC; ");
            this.lkeMonth.Properties.ValueMember = "PayRollMonthID";
            this.lkeMonth.Properties.DisplayMember = "PayRollMonth";
        }
        #endregion
    }
}
