using Common.Controls;
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
using UI.Helper;
using UI.ReportFile;

namespace UI.MasterSystemSetup
{
    public partial class frm_MSS_AnnualLeaveReview : frmBaseForm
    {
        public frm_MSS_AnnualLeaveReview()
        {
            this.Enabled = true;
            InitializeComponent();

            this.InitData();
            this.radAll.Checked = true;
        }


        private void InitData()
        {
            // Load payRoll year
            DataProcess<PayRollYear> dataProcessYear = new DataProcess<PayRollYear>();
            this.lkeYears.Properties.DataSource = dataProcessYear.Select();
            this.lkeYears.EditValue = DateTime.Now.Year;

            // Load department
            DataProcess<Departments> dataProcessDepartment = new DataProcess<Departments>();
            this.lkeDepartments.Properties.DataSource = dataProcessDepartment.Select();
            this.lkeDepartments.EditValue = 1;

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAnnualEvaluation_Click(object sender, EventArgs e)
        {
            if (this.lkeYears.EditValue == null)
            {
                MessageBox.Show("Please enter From Date Or To Date", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var dataSource = FileProcess.LoadTable("STEmployeeEvaluationAnnual @FromDate='" + this.dFrom.DateTime.ToString("yyyy-MM-dd")
                + "',@ToDate='" + this.dTo.DateTime.ToString("yyyy-MM-dd") + "',@PayRollYearID=" + this.lkeYears.EditValue + ",@StoreID=" + AppSetting.StoreID);

            // Display report
            rptEmployeeEvaluationAnnual rpt = new rptEmployeeEvaluationAnnual();
            rpt.DataSource = dataSource;
            rpt.RequestParameters = false;
            rpt.Parameters["paramFromDate"].Value = this.dFrom.EditValue ;
            rpt.Parameters["paramToDate"].Value = this.dTo.EditValue;

            rptEmployeeEvaluationAnnualNew rptNew = new rptEmployeeEvaluationAnnualNew();
            rptNew.DataSource = dataSource;
            rptNew.RequestParameters = false;
            rptNew.Parameters["paramFromDate"].Value = this.dFrom.EditValue;
            rptNew.Parameters["paramToDate"].Value = this.dTo.EditValue;

            ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
            tool.ShowPreviewDialog();

            ReportPrintToolWMS tool1 = new ReportPrintToolWMS(rptNew);
            tool1.ShowPreviewDialog();
        }

        private void btnPayRollAnnualReport_Click(object sender, EventArgs e)
        {
            if (this.lkeYears.EditValue == null)
            {
                this.lkeYears.Focus();
                this.lkeYears.ShowPopup();
                return;
            }

            var datasource = FileProcess.LoadTable("STPayrollAnnualSummaryReport ");
            rptPayRollAnnualSummary rpt = new rptPayRollAnnualSummary();
            rpt.DataSource = datasource;
            ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
            tool.ShowPreviewDialog();

            this.btnUpdate_Click(sender, e);
            datasource= FileProcess.LoadTable("STPayrollAnnualSummaryReport ");
            rptPayRollAnnualSummaryNew rptNew = new rptPayRollAnnualSummaryNew();
            rptNew.DataSource = datasource;
            ReportPrintToolWMS tool1 = new ReportPrintToolWMS(rptNew);
            tool1.ShowPreviewDialog();
        }

        private void btnOFFDaysSummary_Click(object sender, EventArgs e)
        {
            if (this.lkeYears.EditValue == null)
            {
                MessageBox.Show("Please enter From Date Or To Date", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var dataSource = FileProcess.LoadTable("STEmployeeOFFDaySummary @Year=" + this.lkeYears.EditValue+ ",@DayStatus='O'");
            string attachPath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + DateTime.Now.ToString("dd_MM_yyyy") + "OFFDaysSummary.xlsx";
            this.ExportExel(attachPath, dataSource);
        }

        private void btnSickDaysSummary_Click(object sender, EventArgs e)
        {
            if (this.lkeYears.EditValue == null)
            {
                MessageBox.Show("Please enter From Date Or To Date", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var dataSource = FileProcess.LoadTable("STEmployeeOFFDaySummary @Year=" + this.lkeYears.EditValue + ",@DayStatus='S'");
            string attachPath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + DateTime.Now.ToString("dd_MM_yyyy") + "SickDaysSummary.xlsx";
            this.ExportExel(attachPath, dataSource);
        }

        private void ExportExel(string fileExport, DataTable dataSource)
        {
            DevExpress.XtraGrid.GridControl grdReport = new DevExpress.XtraGrid.GridControl();
            DevExpress.XtraGrid.Views.Grid.GridView grvReport = new DevExpress.XtraGrid.Views.Grid.GridView(grdReport);
            grdReport.MainView = grvReport;
            grdReport.ForceInitialize();
            grdReport.BindingContext = new BindingContext();
            grdReport.DataSource = dataSource;
            grvReport.PopulateColumns();

            // Export data to excel file
            grvReport.ExportToXlsx(fileExport);
            System.Diagnostics.Process.Start(fileExport);
        }

        private void lkeYears_EditValueChanged(object sender, EventArgs e)
        {
           
            if (this.lkeYears.EditValue == null) return;
            try
            {
                int payRollID = Convert.ToInt32(this.lkeYears.EditValue);
                DataProcess<PayRollYear> dataProcessYear = new DataProcess<PayRollYear>();
                var payRollYear = dataProcessYear.Select(p => p.PayRollYearID == payRollID).FirstOrDefault();
                this.dFrom.EditValue = payRollYear.FromDate;
                this.dTo.EditValue = payRollYear.ToDate;
            }
            catch { }
        }

        private void lkeDepartments_EditValueChanged(object sender, EventArgs e)
        {
            if (this.lkeDepartments.EditValue == null) return;
            this.LoadData();
        }

        private void LoadData()
        {
            var dataprocess = new DataProcess<STPayrollAnnualLeaveByDepartment_Result>();
            this.grdAnnualLeaveDetails.DataSource = dataprocess.Executing("STPayrollAnnualLeaveByDepartment @DepartmentID={0},@FromDate={1},@ToDate={2}",
                this.lkeDepartments.EditValue, this.dFrom.DateTime.ToString("yyyy-MM-dd"), this.dTo.DateTime.ToString("yyyy-MM-dd"));
        }

        private void radAll_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.radAll.Checked) return;
            var dataprocess = new DataProcess<STPayrollAnnualLeaveByDepartment_Result>();
            this.grdAnnualLeaveDetails.DataSource = dataprocess.Executing("STPayrollAnnualLeaveByDepartment");
        }

        private void radTemp_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.radTemp.Checked) return;
        }

        private void rpi_btn_Details_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int employeeID = Convert.ToInt32(this.grvAnnualLeaveDetails.GetFocusedRowCellValue("EmployeeID"));
            string fromDate = this.dFrom.DateTime.ToString("yyyy-MM-dd");
            string toDate = this.dTo.DateTime.ToString("yyyy-MM-dd");
            frm_MSS_EmployeeAnnualDetails frm = new frm_MSS_EmployeeAnnualDetails(employeeID,fromDate,toDate);
            frm.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (this.lkeYears.EditValue == null)
            {
                this.lkeYears.Focus();
                this.lkeYears.ShowPopup();
                return;
            }
            DataProcess<object> dataProcess = new DataProcess<object>();
            dataProcess.ExecuteNoQuery("STPayrollAnnualSummaryInsert @FromDate={0},@Todate={1},@PayRollYearID={2}", this.dFrom.EditValue, this.dTo.EditValue, this.lkeYears.EditValue);
            this.LoadData();
        }
    }
}
