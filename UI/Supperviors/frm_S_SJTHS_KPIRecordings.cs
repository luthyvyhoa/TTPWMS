using Common.Process;
using DA;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Supperviors
{
    public partial class frm_S_SJTHS_KPIRecordings : Common.Controls.frmBaseForm
    {
        private DataProcess<PayrollMonth> _payrollDA;
        private BindingList<PayrollMonth> _listPayrolls;
        private PayrollMonth _currentPayroll;

        public frm_S_SJTHS_KPIRecordings()
        {
            InitializeComponent();
            this._payrollDA = new DataProcess<PayrollMonth>();
            this._currentPayroll = new PayrollMonth();
        }

        private void frm_S_SJTHS_KPIRecordings_Load(object sender, EventArgs e)
        {
            LoadPayrolls();
            SetEvents();
        }

        private void SetEvents()
        {
            this.grvKPI.FocusedColumnChanged += GrvKPI_FocusedColumnChanged;
            this.grvKPI.CellValueChanged += GrvKPI_CellValueChanged;
            this.nvtKPI.PositionChanged += NvtKPI_PositionChanged;
            this.btnConfirm.CheckedChanged += BtnConfirm_CheckedChanged;
            this.btnInsert.Click += BtnInsert_Click;
            this.btnDelete.Click += BtnDelete_Click;
            this.btnNote.Click += BtnNote_Click;
            this.btnSummary.Click += BtnSummary_Click;
            this.btnKPIDefinition.Click += BtnKPIDefinition_Click;
            this.btnClose.Click += BtnClose_Click;
        }

        private void GrvKPI_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if(e.PrevFocusedColumn.FieldName.Equals("KPIScore123Day") || e.PrevFocusedColumn.FieldName.Equals("KPIScore45Day") || e.PrevFocusedColumn.FieldName.Equals("KPIScore12345Afternoon") || e.PrevFocusedColumn.FieldName.Equals("KPIScoreShift3"))
            {
                decimal score;
                bool isParsed = Decimal.TryParse(Convert.ToString(this.grvKPI.GetFocusedRowCellValue(e.PrevFocusedColumn.FieldName)), out score);

                if(!isParsed)
                {
                    XtraMessageBox.Show("Value not valid !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.grvKPI.FocusedColumn = e.PrevFocusedColumn;
                }
            }
        }

        private void GrvKPI_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int kpiID = Convert.ToInt32(this.grvKPI.GetFocusedRowCellValue("KPIID"));
            int result = -2;

            switch(e.Column.FieldName)
            {
                case "KPIScore123Day":
                    {
                        float score123 = (float)Convert.ToDecimal(this.grvKPI.GetFocusedRowCellValue("KPIScore123Day"));
                        result = this._payrollDA.ExecuteNoQuery("Update KPIRecordings Set KPIScore123Day = {0} Where KPIID = {1}", score123, kpiID);
                        break;
                    }
                case "KPIScore45Day":
                    {
                        float score45 = (float)Convert.ToDecimal(this.grvKPI.GetFocusedRowCellValue("KPIScore45Day"));
                        result = this._payrollDA.ExecuteNoQuery("Update KPIRecordings Set KPIScore45Day = {0} Where KPIID = {1}", score45, kpiID);
                        break;
                    }
                case "KPIScore12345Afternoon":
                    {
                        float scoreAfternoon = (float)Convert.ToDecimal(this.grvKPI.GetFocusedRowCellValue("KPIScore12345Afternoon"));
                        result = this._payrollDA.ExecuteNoQuery("Update KPIRecordings Set KPIScore12345Afternoon = {0} Where KPIID = {1}", scoreAfternoon, kpiID);
                        break;
                    }
                case "KPIScoreShift3":
                    {
                        float scoreShift3 = (float)Convert.ToDecimal(this.grvKPI.GetFocusedRowCellValue("KPIScoreShift3"));
                        result = this._payrollDA.ExecuteNoQuery("Update KPIRecordings Set KPIScoreShift3 = {0} Where KPIID = {1}", scoreShift3, kpiID);
                        break;
                    }
                case "KPIComment":
                    {
                        result = this._payrollDA.ExecuteNoQuery("Update KPIRecordings Set KPIComment = {0} Where KPIID = {1}", Convert.ToString(this.grvKPI.GetFocusedRowCellValue("KPIComment")), kpiID);
                        break;
                    }
            }
        }

        private void NvtKPI_PositionChanged(object sender, EventArgs e)
        {
            this._currentPayroll = this._listPayrolls[this.nvtKPI.Position];
            BindData();
            LoadKPI();
        }

        private void BtnConfirm_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void BtnInsert_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Are you sure to Insert Data this month ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int result = this._payrollDA.ExecuteNoQuery("STKPIRecordingInsert @PayRollMonthID = {0}, @Flag = {1}", this._currentPayroll.PayRollMonthID, 0);
                LoadKPI();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if(XtraMessageBox.Show("Are you sure to delete KPI ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int result = this._payrollDA.ExecuteNoQuery("STKPIRecordingInsert @PayRollMonthID = {0}, @Flag = {1}", this._currentPayroll.PayRollMonthID, 1);
                LoadKPI();
            }
        }

        private void BtnNote_Click(object sender, EventArgs e)
        {
        }

        private void BtnSummary_Click(object sender, EventArgs e)
        {
            try
            {
                Wait.Start(this);
                GridControl grdReport = new GridControl();
                GridView grvReport = new GridView(grdReport);
                grdReport.MainView = grvReport;
                grdReport.ForceInitialize();
                grdReport.BindingContext = new BindingContext();
                grdReport.DataSource = FileProcess.LoadTable("STKPIDataSummary @FromDate = '"+this.dtFrom.DateTime.ToString("yyyy-MM-dd")+ "', @ToDate = '" + this.dtTo.DateTime.ToString("yyyy-MM-dd") + "'");
                grvReport.PopulateColumns();

                // Export data to excel file
                string pathSaveFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string fileName = pathSaveFile + "\\" + "TrainingDefinitions_" + DateTime.Now.ToString("dd_MM_yy") + ".xlsx";

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

        private void BtnKPIDefinition_Click(object sender, EventArgs e)
        {
            try
            {
                Wait.Start(this);
                DataProcess<KPIDefinitions> kpiDA = new DataProcess<KPIDefinitions>();

                GridControl grdReport = new GridControl();
                GridView grvReport = new GridView(grdReport);
                grdReport.MainView = grvReport;
                grdReport.ForceInitialize();
                grdReport.BindingContext = new BindingContext();
                grdReport.DataSource = kpiDA.Select();
                grvReport.PopulateColumns();

                // Export data to excel file
                string pathSaveFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string fileName = pathSaveFile + "\\" + "KPIDefinitions_" + DateTime.Now.ToString("dd_MM_yy") + ".xlsx";

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

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadPayrolls()
        {
            DateTime conditionDate = DateTime.Now.AddDays(-730);
            this._listPayrolls = new BindingList<PayrollMonth>(this._payrollDA.Select().Where(p => p.FromDate > conditionDate).ToList());

            this.nvtKPI.DataSource = this._listPayrolls;
            this.nvtKPI.Position = this._listPayrolls.Count;
            this._currentPayroll = this._listPayrolls[this.nvtKPI.Position];
            BindData();
            LoadKPI();
        }

        private void LoadKPI()
        {
            this.grdKPI.DataSource = FileProcess.LoadTable("SELECT KPIRecordings.*, KPIDefinitions.KPIDefinitionDescription, KPIDefinitions.KPICategory " +
                                                           "FROM KPIRecordings INNER JOIN KPIDefinitions ON KPIRecordings.KPIDefinitionID = KPIDefinitions.KPIDefinitionID " +
                                                           "WHERE KPIRecordings.PayRollMonthID = " + this._currentPayroll.PayRollMonthID);
        }

        private void BindData()
        {
            this.txtPayrollMonthID.Text = this._currentPayroll.PayRollMonthID.ToString();
            this.txtPayrollMonth.Text = this._currentPayroll.PayRollMonth1;
            this.dtFrom.EditValue = this._currentPayroll.FromDate;
            this.dtTo.EditValue = this._currentPayroll.ToDate;
        }
    }
}
