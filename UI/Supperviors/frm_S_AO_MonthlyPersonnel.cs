using Common.Controls;
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
using UI.ReportFile;

namespace UI.Supperviors
{
    public partial class frm_S_AO_MonthlyPersonnel : frmBaseForm
    {
        private bool isLoad = true;
        private int payrollmonthID = 0;
        private MonthlyPayRollSummary currentSummary = null;
        public frm_S_AO_MonthlyPersonnel(int payrollmonthID)
        {
            this.payrollmonthID = payrollmonthID;

            InitializeComponent();
            this.Enabled = true;

            // Init data
            this.InitData();
        }

        private void InitData()
        {
            // Load months 
            this.LoadMonths();

            // Load departments
            this.LoadDepartments();

            // Load pay summary
            this.LoadMonthlyPayRollSummary();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadMonths()
        {
            DataProcess<PayrollMonth> dataProcess = new DataProcess<PayrollMonth>();
            this.lkeMonths.Properties.DataSource = dataProcess.Select().OrderByDescending(p => p.PayRollMonthID).ToList();
            this.lkeMonths.Properties.DisplayMember = "PayRollMonth1";
            this.lkeMonths.Properties.ValueMember = "PayRollMonthID";
            this.lkeMonths.EditValue = this.payrollmonthID;
        }

        private void LoadDepartments()
        {
            DataProcess<Departments> dataProcess = new DataProcess<Departments>();
            this.grdDepartments.DataSource = dataProcess.Select().OrderBy(d => d.DepartmentName).ToList();
        }
        private void LoadPaymonthDetails(string condition = " And 1=1 ", string orderBy = " ORDER BY Departments.DepartmentName, Positions.ManagementLevel")
        {
            this.grdPaymonthDetails.DataSource = FileProcess.LoadTable("ST_WMS_MonthlyPayRollQuantityOnCurrent @ConditionStr='" + condition + "',@OrderBy='" + orderBy + "'");
        }

        private void LoadMonthlyPayRollSummary()
        {
            this.isLoad = true;
            DataProcess<MonthlyPayRollSummary> dataProcess = new DataProcess<MonthlyPayRollSummary>();
            this.currentSummary = dataProcess.Select(p => p.PayRollMonthID == this.payrollmonthID).FirstOrDefault();
            if (this.currentSummary == null)
            {
                this.txtWorkingDays.EditValue = null;
                this.txtWorkingDaysChanged.EditValue = null;
                this.txtWorkingDaysLastMonth.EditValue = null;
                this.txtOTS.EditValue = null;
                this.txtOTSChange.EditValue = null;
                this.txtOTSLastMonth.EditValue = null;
                this.txtOTN.EditValue = null;
                this.txtOTNChange.EditValue = null;
                this.txtOTNLastMonth.EditValue = null;
                this.txtTotalWorkerHour.EditValue = null;
                this.txtTotalWorkerHourChange.EditValue = null;
                this.txtTotalWorkerHourLastMonth.EditValue = null;
                this.txtAccidents.EditValue = null;
                this.txtAccidentsChange.EditValue = null;
                this.txtAccidentsLastMonth.EditValue = null;
                this.txtAccidentLeave.EditValue = null;
                this.txtAccidentLeaveChange.EditValue = null;
                this.txtAccidentLeaveLastMonth.EditValue = null;

                this.txtSickLeave.EditValue = null;
                this.txtSickLeaveChange.EditValue = null;
                this.txtSickLeaveLastMonth.EditValue = null;
                this.txtLeave3Days.EditValue = null;
                this.txtLeave3DaysChange.EditValue = null;
                this.txtLeave3DaysLastMonth.EditValue = null;
                this.txtTotalWorkerHour.EditValue = null;
                this.txtEmployeeTemporaryQty.EditValue = null;
                return;
            }

            this.txtWorkingDays.EditValue = currentSummary.WorkingDays;
            this.txtWorkingDaysChanged.EditValue = currentSummary.WorkingDaysChange;
            this.txtWorkingDaysLastMonth.EditValue = currentSummary.WorkingDays - currentSummary.WorkingDaysChange;

            this.txtOTS.EditValue = currentSummary.OTS;
            this.txtOTSChange.EditValue = currentSummary.OTSChange;
            this.txtOTSLastMonth.EditValue = currentSummary.OTS - currentSummary.OTSChange;

            this.txtOTN.EditValue = currentSummary.OTN;
            this.txtOTNChange.EditValue = currentSummary.OTNChange;
            this.txtOTNLastMonth.EditValue = currentSummary.OTN - currentSummary.OTNChange;

            this.txtTotalWorkerHour.EditValue = currentSummary.TotalWorkerHour;
            this.txtTotalWorkerHourChange.EditValue = currentSummary.TotalWorkerHourChange;
            this.txtTotalWorkerHourLastMonth.EditValue = currentSummary.TotalWorkerHour - currentSummary.TotalWorkerHourChange;

            this.txtAccidents.EditValue = currentSummary.Accidents;
            this.txtAccidentsChange.EditValue = currentSummary.AccidentsChange;
            this.txtAccidentsLastMonth.EditValue = currentSummary.Accidents - currentSummary.AccidentsChange;

            this.txtAccidentLeave.EditValue = currentSummary.AccidentLeave;
            this.txtAccidentLeaveChange.EditValue = currentSummary.AccidentLeaveChange;
            this.txtAccidentLeaveLastMonth.EditValue = currentSummary.AccidentLeave - currentSummary.AccidentLeaveChange;

            this.txtSickLeave.EditValue = currentSummary.SickLeave;
            this.txtSickLeaveChange.EditValue = currentSummary.SickLeavechange;
            this.txtSickLeaveLastMonth.EditValue = currentSummary.SickLeave - currentSummary.SickLeavechange;

            this.txtLeave3Days.EditValue = currentSummary.LeaveMoreThan3Days;
            this.txtLeave3DaysChange.EditValue = currentSummary.LeaveMoreThan3DayChange;
            this.txtLeave3DaysLastMonth.EditValue = currentSummary.LeaveMoreThan3Days - currentSummary.LeaveMoreThan3DayChange;

            this.txtTotalWorkerHour.EditValue = currentSummary.TotalWorkerHourSCS;

            this.txtEmployeeTemporaryQty.EditValue = currentSummary.EmployeeTemporaryQty;
            this.isLoad = false;
        }

        private void lkeMonths_EditValueChanged(object sender, EventArgs e)
        {
            if (this.lkeMonths.EditValue == null) return;
            this.payrollmonthID = Convert.ToInt32(this.lkeMonths.EditValue);
            this.LoadPaymonthDetails(" And PayrollMonth.PayRollMonthID=" + this.lkeMonths.EditValue);
            this.LoadMonthlyPayRollSummary();
        }

        private void grvDepartments_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.RowHandle < 0) return;
            int departmentID = Convert.ToInt32(this.grvDepartments.GetFocusedRowCellValue("DepartmentID"));
            string condition = " And PayrollMonth.PayRollMonthID=" + this.lkeMonths.EditValue + " And Departments.DepartmentID=" + departmentID;
            string orderBy = "ORDER BY Positions.ManagementLevel, Positions.PositionDescription";
            this.LoadPaymonthDetails(condition, orderBy);
        }

        private void txtWorkingDays_EditValueChanged(object sender, EventArgs e)
        {
            if (this.isLoad) return;
            var txt = (TextEdit)sender;
            if (txt.EditValue == null) return;
            string fieldName = Convert.ToString(txt.Tag);
            if (string.IsNullOrEmpty(fieldName)) return;
            DataProcess<MonthlyPayRollSummary> dataProcess = new DataProcess<MonthlyPayRollSummary>();
            dataProcess.ExecuteNoQuery("Update MonthlyPayRollSummary set {0}={1} Where PayRollMonthID={2}", fieldName, txt.EditValue, this.payrollmonthID);
            switch (fieldName)
            {
                case "WorkingDays":
                case "WorkingDaysChange":
                    this.txtWorkingDaysLastMonth.EditValue = Convert.ToInt32(this.txtWorkingDays.EditValue) - Convert.ToInt32(this.txtWorkingDaysChanged.EditValue);
                    break;

                case "OTS":
                case "OTSChange":
                    this.txtOTSLastMonth.EditValue = Convert.ToInt32(this.txtOTS.EditValue) - Convert.ToInt32(this.txtOTSChange.EditValue);
                    break;

                case "OTN":
                case "OTNChange":
                    this.txtOTNLastMonth.EditValue = Convert.ToInt32(this.txtOTN.EditValue) - Convert.ToInt32(this.txtOTNChange.EditValue);
                    break;

                case "TotalWorkerHour":
                case "TotalWorkerHourChange":
                    this.txtTotalWorkerHourLastMonth.EditValue = Convert.ToInt32(this.txtTotalWorkerHour.EditValue) - Convert.ToInt32(this.txtTotalWorkerHourChange.EditValue);
                    break;

                case "Accidents":
                case "AccidentsChange":
                    this.txtAccidentsLastMonth.EditValue = Convert.ToInt32(this.txtAccidents.EditValue) - Convert.ToInt32(this.txtAccidentsChange.EditValue);
                    break;

                case "AccidentLeave":
                case "AccidentLeaveChange":
                    this.txtAccidentLeaveLastMonth.EditValue = Convert.ToInt32(this.txtAccidentLeave.EditValue) - Convert.ToInt32(this.txtAccidentLeaveChange.EditValue);
                    break;

                case "SickLeave":
                case "SickLeavechange":
                    this.txtSickLeaveLastMonth.EditValue = Convert.ToInt32(this.txtSickLeave.EditValue) - Convert.ToInt32(this.txtSickLeaveChange.EditValue);
                    break;

                case "LeaveMoreThan3Days":
                case "LeaveMoreThan3DayChange":
                    this.txtLeave3DaysLastMonth.EditValue = Convert.ToInt32(this.txtLeave3Days.EditValue) - Convert.ToInt32(this.txtLeave3DaysChange.EditValue);
                    break;
                default:
                    break;
            }
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            DataProcess<MonthlyPayRollSummary> dataProcess = new DataProcess<MonthlyPayRollSummary>();

            rptMonthlyPersonnel rpt = new rptMonthlyPersonnel();
            rpt.Parameters["paramMonth"].Value = this.lkeMonths.Text;
            rpt.RequestParameters = false;

            var currentSummary = dataProcess.Select(p => p.PayRollMonthID == this.payrollmonthID).FirstOrDefault();
            rptSubMonthlyPersonnelQuantity rptQuantity = new rptSubMonthlyPersonnelQuantity();
            rptQuantity.Parameters["paramEmployeePermanentQty"].Value = currentSummary.EmployeePermanentQty;
            rptQuantity.Parameters["paramEmployeeTemporaryQty"].Value = currentSummary.EmployeeTemporaryQty;
            rpt.RequestParameters = false;
            rptQuantity.DataSource = FileProcess.LoadTable("ST_WMS_MonthlyPayRollQuantityReport @PayRollMonthID=" + this.payrollmonthID);
            rpt.xrSubreportQuantity.ReportSource = rptQuantity;
            rpt.CreateDocument();

            rptSubMonthlyPersonnelSummary rptSummary = new rptSubMonthlyPersonnelSummary();
            rptSummary.DataSource = FileProcess.LoadTable("Select * from MonthlyPayRollSummary where PayRollMonthID="+this.payrollmonthID);
            rpt.xrSubreportSummary.ReportSource = rptSummary;
            rpt.CreateDocument();

            ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
            tool.ShowPreviewDialog();
        }

        private void txtWorkingDaysLastMonth_EditValueChanged(object sender, EventArgs e)
        {
            if (this.isLoad) return;
            var txt = (TextEdit)sender;
            if (txt.EditValue == null) return;
            string fieldName = Convert.ToString(txt.Tag);
            if (string.IsNullOrEmpty(fieldName)) return;
            DataProcess<MonthlyPayRollSummary> dataProcess = new DataProcess<MonthlyPayRollSummary>();
            dataProcess.ExecuteNoQuery("Update MonthlyPayRollSummary set {0}={1} Where PayRollMonthID={2}", fieldName, txt.EditValue, this.payrollmonthID);
        }
    }
}
