using Common.Process;
using DA;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
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

namespace UI.Supperviors
{
    public partial class frm_S_PCO_EmployeeEvents : Common.Controls.frmBaseForm
    {
        private DataTable _tableEvents;
        private bool _isFilter;
        private bool _isReportByPlace;

        public frm_S_PCO_EmployeeEvents()
        {
            InitializeComponent();
            this._tableEvents = new DataTable();
            this._isFilter = false;
            this._isReportByPlace = false;
            this.WindowState = FormWindowState.Maximized;
        }

        private void frm_S_PCO_EmployeeEvents_Load(object sender, EventArgs e)
        {
            this.dtCurrentDate.EditValue = DateTime.Now;
            this.chkAll.Checked = true;
            this.chkReportAll.Checked = true;
            SetEvents();
            LoadEmployeeEvents();
            InitMonth();
            InitPlace();
            InitDepartment();
        }

        private void SetEvents()
        {
            this.lkeDepartment.EditValueChanged += LkeDepartment_EditValueChanged;
            this.rpi_txt_Lunch.DoubleClick += rpi_txt_Lunch_DoubleClick;
            this.rpi_txt_Noodles.DoubleClick += rpi_txt_Noodles_DoubleClick;
            this.rpi_txt_PayrollRemark.DoubleClick += rpi_txt_PayrollRemark_DoubleClick;
            this.rpi_btn_Propose.Click += rpi_btn_Propose_Click;
            this.rpi_hpl_EmployeeID.Click += rpi_hpl_EmployeeID_Click;
            this.btnAdjustTime.Click += btnAdjustTime_Click;
            this.btnClose.Click += btnClose_Click;
            this.btnDetail.Click += btnDetail_Click;
            this.btnLeave.Click += btnLeave_Click;
            this.btnLunchDetail.Click += btnLunchDetail_Click;
            this.btnLunchSummary.Click += btnLunchSummary_Click;
            this.btnNextDate.Click += btnNextDate_Click;
            this.btnNoodles.Click += btnNoodles_Click;
            this.btnPreviousDate.Click += btnPreviousDate_Click;
            this.btnProblemCheck.Click += btnProblemCheck_Click;
            this.btnProposal.Click += btnProposal_Click;
            this.btnToday.Click += btnToday_Click;
            this.btnUpdateTime.Click += btnUpdateTime_Click;
            this.chkAll.CheckedChanged += chkAll_CheckedChanged;
            this.chkPlace.CheckedChanged += chkPlace_CheckedChanged;
            this.chkReportAll.CheckedChanged += chkReportAll_CheckedChanged;
            this.grvEmployeeEvents.CustomSummaryCalculate += grvEmployeeEvents_CustomSummaryCalculate;
        }



        #region Load Data
        private void LoadEmployeeEvents(int department = 0)
        {
            Wait.Start(this);
            this._tableEvents = FileProcess.LoadTable("STEmployeeEventView @ReportDate = '" + this.dtCurrentDate.DateTime.ToString("yyyy-MM-dd") + "', @Department = " + department + ", @varStoreID = " + AppSetting.StoreID);

            this.grdEmployeeEvents.DataSource = this._tableEvents;
            this._isFilter = false;
            Wait.Close();
        }
        private void InitDepartment()
        {
            DataProcess<Departments> departmentDA = new DataProcess<Departments>();

            this.lkeDepartment.Properties.DataSource = departmentDA.Select(d => d.DepartmentID != 5);
            this.lkeDepartment.Properties.ValueMember = "DepartmentID";
            this.lkeDepartment.Properties.DisplayMember = "DepartmentName";
        }

        private void LoadFoundEvents(DataTable source)
        {
            this.grdEmployeeEvents.DataSource = this._tableEvents;
            this._isFilter = true;
        }

        private void LoadPayrollProblem()
        {
            DataProcess<STPayrollMonthlyProblemCheck_Result> payrollDA = new DataProcess<STPayrollMonthlyProblemCheck_Result>();

            this.grdProblemCheck.DataSource = payrollDA.Executing("STPayrollMonthlyProblemCheck @varPayRollMonthID = {0}", Convert.ToInt32(this.lkeMonth.EditValue));
        }

        private void InitMonth()
        {
            this.lkeMonth.Properties.DataSource = FileProcess.LoadTable("SELECT TOP 50 PayrollMonth.PayRollMonthID, PayrollMonth.PayRollMonth, PayrollMonth.FromDate, PayrollMonth.ToDate FROM PayrollMonth WHERE(((PayrollMonth.PayRollMonthID) > 74)) ORDER BY PayrollMonth.PayRollMonthID DESC; ");
            this.lkeMonth.Properties.DisplayMember = "PayRollMonth";
            this.lkeMonth.Properties.ValueMember = "PayRollMonthID";
        }

        private void InitPlace()
        {
            DataProcess<LunchPlaces> lunchDA = new DataProcess<LunchPlaces>();

            this.lkePlace.Properties.DataSource = lunchDA.Select();
            this.lkePlace.Properties.DisplayMember = "LunchPlaceID";
            this.lkePlace.Properties.ValueMember = "LunchPlaceID";
        }
        #endregion

        #region Events
        private void rpi_hpl_EmployeeID_Click(object sender, EventArgs e)
        {
            //Open frm PayrollViewByEmployee
            int employeeID = Convert.ToInt32(this.grvEmployeeEvents.GetFocusedRowCellValue("EmployeeID"));

            frm_S_PCO_Dialog_PayrollViewByEmployee frm = new frm_S_PCO_Dialog_PayrollViewByEmployee(employeeID);
            frm.Show();
        }
        private void LkeDepartment_EditValueChanged(object sender, EventArgs e)
        {
            int departmentID = (int)this.lkeDepartment.EditValue;
            LoadEmployeeEvents(departmentID);
        }
        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked)
            {
                LoadEmployeeEvents();
            }
        }

        private void grvEmployeeEvents_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            GridView view = sender as GridView;
            // Get the summary ID.  
            int summaryID = Convert.ToInt32((e.Item as GridSummaryItem).Tag);

            int total = 0;

            if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Start)
            {
                total = 0;
            }

            if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
            {
                switch (summaryID)
                {
                    case 1:
                        {
                            bool isHaft = Convert.ToBoolean(e.FieldValue);
                            if (isHaft)
                            {
                                total += 1;
                            }
                            break;
                        }
                    case 2:
                        {
                            bool isSick = Convert.ToBoolean(e.FieldValue);
                            if (isSick)
                            {
                                total += 1;
                            }
                            break;
                        }
                    case 3:
                        {
                            bool isLeave = Convert.ToBoolean(e.FieldValue);
                            if (isLeave)
                            {
                                total += 1;
                            }
                            break;
                        }
                    case 4:
                        {
                            bool isOff = Convert.ToBoolean(e.FieldValue);
                            if (isOff)
                            {
                                total += 1;
                            }
                            break;
                        }
                }
            }

            if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
            {
                e.TotalValue = total;
            }
        }

        private void chkReportAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkReportAll.Checked)
            {
                this.chkPlace.Checked = false;
            }
        }

        private void chkPlace_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkPlace.Checked)
            {
                this.chkReportAll.Checked = false;
                this._isReportByPlace = true;
                this.lkePlace.ReadOnly = false;
                this.lkePlace.Focus();
                this.lkePlace.ShowPopup();
            }
            else
            {
                this._isReportByPlace = false;
                this.lkePlace.ReadOnly = true;
            }
        }

        private void btnUpdateTime_Click(object sender, EventArgs e)
        {
            DataProcess<object> payrollDA = new DataProcess<object>();

            int result = payrollDA.ExecuteNoQuery("STPayrollDetailsUpdateTimeWork");

            if (result != -2)
            {
                this.btnUpdateTime.Enabled = false;
            }
            else
            {
                XtraMessageBox.Show("Unexpected Error !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            this.dtCurrentDate.EditValue = DateTime.Now;
            LoadEmployeeEvents();
        }

        private void btnProposal_Click(object sender, EventArgs e)
        {
            frm_S_PCO_EmployeeOTSupervisors frm = new frm_S_PCO_EmployeeOTSupervisors();
            frm.Show();
        }

        private void btnProblemCheck_Click(object sender, EventArgs e)
        {
            if (this.lkeMonth.EditValue == null)
            {
                this.lkeMonth.Focus();
                this.lkeMonth.ShowPopup();
            }
            else
            {
                LoadPayrollProblem();

                string pathSaveFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string fileName = pathSaveFile + "\\" + "PayrollMonthlyProblemCheck_" + DateTime.Now.ToString("dd_MM_yy") + ".xlsx";
                this.grdProblemCheck.ExportToXlsx(fileName);

                System.Diagnostics.Process.Start(fileName);
            }
        }

        private void btnPreviousDate_Click(object sender, EventArgs e)
        {
            this.dtCurrentDate.EditValue = this.dtCurrentDate.DateTime.AddDays(-1);
            LoadEmployeeEvents();
        }

        private void btnNoodles_Click(object sender, EventArgs e)
        {
            if (this.lkeMonth.EditValue == null)
            {
                this.lkeMonth.Focus();
                this.lkeMonth.ShowPopup();
                return;
            }

            if (this._isReportByPlace)
            {
                if (this.lkePlace.EditValue == null)
                {
                    this.lkePlace.Focus();
                    this.lkePlace.ShowPopup();
                    return;
                }
            }
            if (Convert.ToInt32(this.lkeMonth.EditValue) <= 212 || Convert.ToInt32(this.lkeMonth.EditValue) >= 221)
            {
                rptMonthlyNoodleRecordingByPlaces rpt = new rptMonthlyNoodleRecordingByPlaces();
                rpt.DataSource = FileProcess.LoadTable("WebPayRollMonthlyRecordingLunchPlaces @PayRollMonthID = " + Convert.ToInt32(this.lkeMonth.EditValue) + ", @LunchPlace = '" + Convert.ToString(this.lkePlace.EditValue) + "', @Flag = " + this._isReportByPlace + ", @FlagNoodle = 1, @varStoreID = " + AppSetting.StoreID);
                ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
                tool.ShowPreview();
            }
            else
            {
                rptMonthlyNoodleRecordingByPlacesNew rpt = new rptMonthlyNoodleRecordingByPlacesNew();
                rpt.DataSource = FileProcess.LoadTable("WebPayRollMonthlyRecordingLunchPlaces @PayRollMonthID = " + Convert.ToInt32(this.lkeMonth.EditValue) + ", @LunchPlace = '" + Convert.ToString(this.lkePlace.EditValue) + "', @Flag = " + this._isReportByPlace + ", @FlagNoodle = 1, @varStoreID = " + AppSetting.StoreID);
                ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
                tool.ShowPreview();
            }
            
        }

        private void btnNextDate_Click(object sender, EventArgs e)
        {
            this.dtCurrentDate.EditValue = this.dtCurrentDate.DateTime.AddDays(1);
            LoadEmployeeEvents();
        }

        private void btnLunchSummary_Click(object sender, EventArgs e)
        {
            if (this.lkeMonth.EditValue == null)
            {
                this.lkeMonth.Focus();
                this.lkeMonth.ShowPopup();
                return;
            }

            if (this._isReportByPlace)
            {
                if (this.lkePlace.EditValue == null)
                {
                    this.lkePlace.Focus();
                    this.lkePlace.ShowPopup();
                    return;
                }
            }

            rptMonthlyLunchSummary rpt = new rptMonthlyLunchSummary();
            rpt.DataSource = FileProcess.LoadTable("STMonthlyLunchSummary @PayRollMonthID = " + Convert.ToInt32(this.lkeMonth.EditValue) + ", @varStoreID = " + AppSetting.StoreID);
            ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
            tool.ShowPreview();

        }

        private void btnLunchDetail_Click(object sender, EventArgs e)
        {
            if (this.lkeMonth.EditValue == null)
            {
                this.lkeMonth.Focus();
                this.lkeMonth.ShowPopup();
                return;
            }

            if (this._isReportByPlace)
            {
                if (this.lkePlace.EditValue == null)
                {
                    this.lkePlace.Focus();
                    this.lkePlace.ShowPopup();
                    return;
                }
            }

            rptMonthlyLunchRecordingByPlaces rpt = new rptMonthlyLunchRecordingByPlaces();
            rpt.DataSource = FileProcess.LoadTable("WebPayRollMonthlyRecordingLunchPlaces @PayRollMonthID = " + Convert.ToInt32(this.lkeMonth.EditValue) + ", @LunchPlace = '" + Convert.ToString(this.lkePlace.EditValue) + "', @Flag = " + this._isReportByPlace + ", @FlagNoodle = null, @varStoreID = " + AppSetting.StoreID);
            ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
            tool.ShowPreview();
        }

        private void btnLeave_Click(object sender, EventArgs e)
        {
            //Open frm AnnualLeaveReview
            frm_S_PCO_Dialog_AnnualLeaveReview frm = new frm_S_PCO_Dialog_AnnualLeaveReview();
            frm.Show();
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            //Open frm EmployeeInOut
            frm_S_PCO_Dialog_EmployeeInOut frm = new frm_S_PCO_Dialog_EmployeeInOut(this.dtCurrentDate.DateTime);
            frm.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAdjustTime_Click(object sender, EventArgs e)
        {
            //Open frm EmployeeInOutInCorrect
            frm_S_PCO_Dialog_EmployeeInOutIncorrect frm = new frm_S_PCO_Dialog_EmployeeInOutIncorrect();
            frm.Show();
        }

        private void rpi_btn_Propose_Click(object sender, EventArgs e)
        {
            //Open frm frmEmployeeOTNew
            int employeeID = (int)this.grvEmployeeEvents.GetFocusedRowCellValue("EmployeeID");
            string workDate = dtCurrentDate.DateTime.ToString();
            frm_S_PCO_EmployeeOTNew frmOT = new frm_S_PCO_EmployeeOTNew(employeeID, workDate);
            if (!frmOT.Enabled) return;
            frmOT.ShowDialog();
        }

        private void rpi_txt_PayrollRemark_DoubleClick(object sender, EventArgs e)
        {
            DataProcess<object> payrollDA = new DataProcess<object>();
            string currentRemark = Convert.ToString(this.grvEmployeeEvents.GetFocusedRowCellValue("PayrollRemark"));
            int id = Convert.ToInt32(this.grvEmployeeEvents.GetFocusedRowCellValue("PayrollDetailID"));
            string inputRemark = XtraInputBox.Show("Please input remark: ", "TPWMS", currentRemark);
            string newRemark = "";

            if (String.IsNullOrEmpty(currentRemark))
            {
                newRemark = "~" + inputRemark + " / " + AppSetting.CurrentUser.LoginName + "-" + DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                newRemark = currentRemark + "~" + inputRemark + " / " + AppSetting.CurrentUser.LoginName + "-" + DateTime.Now.ToString("dd/MM/yyyy");
            }

            int result = payrollDA.ExecuteNoQuery("STGate_EmployeeInOutRemarkUpdate @PayrollDetailID = {0}, @PayrollRemark = {1}", id, newRemark);

            if (this._isFilter)
            {
                LoadFoundEvents(this._tableEvents);
            }
            else
            {
                LoadEmployeeEvents();
            }
        }

        private void rpi_txt_Noodles_DoubleClick(object sender, EventArgs e)
        {
            DataProcess<object> lunchDA = new DataProcess<object>();
            byte currentNoodle = Convert.IsDBNull(this.grvEmployeeEvents.GetFocusedRowCellValue("Noodles")) ? (byte)4 : Convert.ToByte(this.grvEmployeeEvents.GetFocusedRowCellValue("Noodles"));
            int id = Convert.ToInt32(this.grvEmployeeEvents.GetFocusedRowCellValue("PayrollDetailID"));
            byte newNoodle = 0;

            if (currentNoodle == 0)
            {
                newNoodle = 1;
            }
            else
            {
                if (currentNoodle == 1)
                {
                    newNoodle = 2;
                }
                if (currentNoodle == 4)
                {
                    newNoodle = 0;
                }
            }

            if (newNoodle == 2)
            {
                int result = lunchDA.ExecuteNoQuery("UPDATE PayrollDetails SET Noodles = 2, LunchCompensate = 1 WHERE PayrollDetailID = {0}", id);
            }
            else
            {
                int result = lunchDA.ExecuteNoQuery("UPDATE PayrollDetails SET Noodles = {0}, LunchCompensate = 0 WHERE PayrollDetailID = {1}", newNoodle, id);
            }

            if (this._isFilter)
            {
                LoadFoundEvents(this._tableEvents);
            }
            else
            {
                LoadEmployeeEvents();
            }
        }

        private void rpi_txt_Lunch_DoubleClick(object sender, EventArgs e)
        {
            DataProcess<object> lunchDA = new DataProcess<object>();
            byte currentLunch = Convert.IsDBNull(this.grvEmployeeEvents.GetFocusedRowCellValue("Lunch")) ? (byte)4 : Convert.ToByte(this.grvEmployeeEvents.GetFocusedRowCellValue("Lunch"));
            int id = Convert.ToInt32(this.grvEmployeeEvents.GetFocusedRowCellValue("PayrollDetailID"));
            byte newLunch = 0;

            if (currentLunch == 0)
            {
                newLunch = 1;
            }
            else
            {
                if (currentLunch == 1)
                {
                    newLunch = 2;
                }
                else
                {
                    if (currentLunch == 2)
                    {
                        newLunch = 3;
                    }
                    else
                    {
                        if (currentLunch == 4)
                        {
                            newLunch = 0;
                        }
                    }
                }
            }

            int result = lunchDA.ExecuteNoQuery("UPDATE PayrollDetails SET Lunch = {0} WHERE PayrollDetailID = {1}", newLunch, id);

            if (this._isFilter)
            {
                LoadFoundEvents(this._tableEvents);
            }
            else
            {
                LoadEmployeeEvents();
            }
        }
        #endregion

        private void dtCurrentDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                LoadEmployeeEvents();
            }
        }
    }
}
