using DA;
using DevExpress.XtraEditors;
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
    public partial class frm_S_PCO_PayrollMonthlyEvaluation : Common.Controls.frmBaseForm
    {
        private DataProcess<PayrollMonth> _payrollDA;
        private List<PayrollMonth> _listPayroll;
        private PayrollMonth _currentPayroll;
        private DataTable _tableEvaluation;
        private bool isNSMHL = false;

        public frm_S_PCO_PayrollMonthlyEvaluation()
        {
            InitializeComponent();
            this._tableEvaluation = new DataTable();
            this._payrollDA = new DataProcess<PayrollMonth>();
            this._listPayroll = new List<PayrollMonth>();
            this._currentPayroll = new PayrollMonth();
            this.SetEvents();
        }

        private void frm_S_PCO_PayrollMonthlyEvaluation_Load(object sender, EventArgs e)
        {
            LoadEvaluation();
            LoadEvaluationDetail();
            InitDepartment();
            InitPosition();
            this.LoadStore();
        }

        private void SetEvents()
        {
            this.dataNavigatorEvaluation.PositionChanged += DataNavigatorEvaluation_PositionChanged;
            this.chkAll.CheckedChanged += ChkAll_CheckedChanged;
            this.chkDepartment.CheckedChanged += ChkDepartment_CheckedChanged;
            this.chkNotCheck.CheckedChanged += ChkNotCheck_CheckedChanged;
            this.chkPosition.CheckedChanged += ChkPosition_CheckedChanged;
            this.lkePosition.EditValueChanged += LkePosition_EditValueChanged;
            this.lkeDepartment.EditValueChanged += LkeDepartment_EditValueChanged;

            this.chkDeptAll.CheckedChanged += ChkDeptAll_CheckedChanged;
            this.chkDeptDay.CheckedChanged += ChkDeptDay_CheckedChanged;
            this.chkDeptNight.CheckedChanged += ChkDeptNight_CheckedChanged;

            this.rpi_hpl_EmployeeID.Click += Rpi_hpl_EmployeeID_DoubleClick;
            this.rpi_hpl_SupervisorUser.Click += Rpi_hpl_SupervisorUser_DoubleClick;

            this.btnRefresh.Click += BtnRefresh_Click;
            this.btnCheckAll.Click += BtnCheckAll_Click;
            this.btnViewReport.Click += BtnViewReport_Click;

            this.txtHoliday.Leave += TxtHoliday_Leave;
            this.grvEvaluationDetail.RowCellStyle += GrvEvaluationDetail_RowCellStyle;
        }

        private void GrvEvaluationDetail_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle < 0) return;
            string tempValue = Convert.ToString(this.grvEvaluationDetail.GetRowCellValue(e.RowHandle, "ABCtemp"));
            switch (e.Column.FieldName)
            {
                case "EvaluationTime":
                case "ABC":
                case "EvaluationAttitude":
                case "EvaluationSafety":
                case "EvaluationPerformance":
                case "EvaluationCreative":
                case "ABC1":
                    if (string.IsNullOrEmpty(tempValue)) return;
                    string currentValue = Convert.ToString(e.CellValue);
                    if (!currentValue.Equals(tempValue))
                    {
                        e.Appearance.ForeColor = Color.Red;
                    }
                    break;
                case "TT":
                    int totalValue = Convert.ToInt16(e.CellValue);
                    if (totalValue.Equals(0)) return;
                    if (totalValue <= 10)
                    {
                        e.Appearance.BackColor = Color.Yellow;
                    }
                    else if (totalValue > 10 && totalValue <= 20)
                    {
                        e.Appearance.BackColor = Color.PeachPuff;
                    }
                    else
                    {
                        e.Appearance.BackColor = Color.Tomato;
                    }
                    break;
            }
        }

        private void TxtHoliday_Leave(object sender, EventArgs e)
        {
            if (this.txtHoliday.IsModified)
            {
                this._currentPayroll.PayableHoliday = Convert.ToInt32(this.txtHoliday.Text);
                int result = this._payrollDA.ExecuteNoQuery("Update PayrollMonth Set PayableHoliday = {0} Where PayRollMonthID = {1}", this._currentPayroll.PayableHoliday, this._currentPayroll.PayRollMonthID);

                if (result != -2)
                {
                    BindData();
                }
                else
                {
                    XtraMessageBox.Show("Unexpected Error !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LoadEvaluation();
                }

            }
        }

        private void BtnViewReport_Click(object sender, EventArgs e)
        {
            rptPayrollMonthlyEvaluation rpt = new rptPayrollMonthlyEvaluation(this.txtMonth.Text);
            rpt.DataSource = this._tableEvaluation;
            ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
            tool.ShowPreview();
        }

        private void BtnCheckAll_Click(object sender, EventArgs e)
        {
            switch (XtraMessageBox.Show("Click Yes for Check All, No for Uncheck All or Cancel to quit", "TPWMS", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    {
                        if (XtraMessageBox.Show("Confirm to Check All employees for the current month ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            int result = this._payrollDA.ExecuteNoQuery("STPayrollMonthlyCheckAll @PayRollMonthID = {0}, @UserName = {1}", this._currentPayroll.PayRollMonthID, AppSetting.CurrentUser.LoginName);
                            RefreshEvaluationDetail();
                        }
                        break;
                    }
                case DialogResult.No:
                    {
                        if (XtraMessageBox.Show("Confirm to Uncheck All employees for the current month ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            int result = this._payrollDA.ExecuteNoQuery("STPayrollMonthlyCheckAll @PayRollMonthID = {0}, @UserName = {1}, @Flag = 1", this._currentPayroll.PayRollMonthID, AppSetting.CurrentUser.LoginName);
                            RefreshEvaluationDetail();
                        }
                        break;
                    }
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            RefreshEvaluationDetail();
        }

        private void Rpi_hpl_SupervisorUser_DoubleClick(object sender, EventArgs e)
        {
            //open frmPayrollMonthlyEvaluationDetails
            int payRollMonthlyID = Convert.ToInt32(this.grvEvaluationDetail.GetFocusedRowCellValue("PayRollMonthlyID"));
            int employeeID = Convert.ToInt32(this.grvEvaluationDetail.GetFocusedRowCellValue("EmployeeID"));

            frm_S_PCO_Dialog_PayrollMonthlyEvaluationDetails frm = new frm_S_PCO_Dialog_PayrollMonthlyEvaluationDetails(employeeID, payRollMonthlyID, this.dtFromDate.DateTime, this.dtToDate.DateTime);
            DialogResult rst = frm.ShowDialog();

            if (rst == DialogResult.OK)
            {
                this._tableEvaluation = FileProcess.LoadTable("STPayrollMonthlyEvaluation @PayRollMonthID = " + this._currentPayroll.PayRollMonthID + ", @PositionID = null, @DepartmentID = null, @Shift = null, @Flag = null, @varStoreID = " + AppSetting.StoreID);
                LoadEvaluationDetail();
            }
        }

        private void Rpi_hpl_EmployeeID_DoubleClick(object sender, EventArgs e)
        {
            int employeeID = Convert.ToInt32(this.grvEvaluationDetail.GetFocusedRowCellValue("EmployeeID"));
            int payRollMonthlyID = Convert.ToInt32(this.grvEvaluationDetail.GetFocusedRowCellValue("PayRollMonthlyID"));

            frm_S_PCO_Dialog_PayrollViewByEmployee frm = new frm_S_PCO_Dialog_PayrollViewByEmployee(employeeID, payRollMonthlyID);
            frm.Show();
        }

        private void ChkDeptNight_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDeptNight.Checked)
            {
                this.chkDeptDay.Checked = false;
                this.chkDeptAll.Checked = false;
                this._tableEvaluation = FileProcess.LoadTable("STPayrollMonthlyEvaluation @PayRollMonthID = " + this._currentPayroll.PayRollMonthID + ", @PositionID = null, @DepartmentID = " + Convert.ToInt32(this.lkeDepartment.EditValue) + ", @Shift = 2, @Flag = null, @varStoreID = " + AppSetting.StoreID);
                LoadEvaluationDetail();
            }
        }

        private void ChkDeptDay_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkDeptDay.Checked)
            {
                this.chkDeptAll.Checked = false;
                this.chkDeptNight.Checked = false;
                this._tableEvaluation = FileProcess.LoadTable("STPayrollMonthlyEvaluation @PayRollMonthID = " + this._currentPayroll.PayRollMonthID + ", @PositionID = null, @DepartmentID = " + Convert.ToInt32(this.lkeDepartment.EditValue) + ", @Shift = 1, @Flag = null, @varStoreID = " + AppSetting.StoreID);
                LoadEvaluationDetail();
            }
        }

        private void ChkDeptAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkDeptAll.Checked)
            {
                this.chkDeptDay.Checked = false;
                this.chkDeptNight.Checked = false;
                this._tableEvaluation = FileProcess.LoadTable("STPayrollMonthlyEvaluation @PayRollMonthID = " + this._currentPayroll.PayRollMonthID + ", @PositionID = null, @DepartmentID = " + Convert.ToInt32(this.lkeDepartment.EditValue) + ", @Shift = null, @Flag = null, @varStoreID = " + AppSetting.StoreID);
                LoadEvaluationDetail();
            }
        }

        private void LkeDepartment_EditValueChanged(object sender, EventArgs e)
        {
            this._tableEvaluation = FileProcess.LoadTable("STPayrollMonthlyEvaluation @PayRollMonthID = " + this._currentPayroll.PayRollMonthID + ", @PositionID = null, @DepartmentID = " + Convert.ToInt32(this.lkeDepartment.EditValue) + ", @Shift = null, @Flag = null, @varStoreID = " + AppSetting.StoreID);
            this.layoutControlGroup3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            LoadEvaluationDetail();
        }

        private void LkePosition_EditValueChanged(object sender, EventArgs e)
        {
            this._tableEvaluation = FileProcess.LoadTable("STPayrollMonthlyEvaluation @PayRollMonthID = " + this._currentPayroll.PayRollMonthID + ", @PositionID = " + Convert.ToInt32(this.lkePosition.EditValue) + ", @DepartmentID = null, @Shift = null, @Flag = null, @varStoreID = " + AppSetting.StoreID);
            LoadEvaluationDetail();
        }

        private void ChkPosition_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPosition.Checked)
            {
                this.chkDepartment.Checked = false;
                this.chkNotCheck.Checked = false;
                this.chkAll.Checked = false;
                this.lkePosition.ReadOnly = false;
                this.lkePosition.Focus();
                this.lkePosition.ShowPopup();
            }
            else
            {
                this.lkePosition.ReadOnly = true;

            }
        }

        private void ChkNotCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNotCheck.Checked)
            {
                this.chkDepartment.Checked = false;
                this.chkAll.Checked = false;
                this.chkPosition.Checked = false;
                this._tableEvaluation = FileProcess.LoadTable("STPayrollMonthlyEvaluation @PayRollMonthID = " + this._currentPayroll.PayRollMonthID + ", @PositionID = null, @DepartmentID = null, @Shift = null, @Flag = null, @varStoreID = " + AppSetting.StoreID);
                LoadEvaluationDetail();
            }
        }

        private void ChkDepartment_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDepartment.Checked)
            {
                this.chkAll.Checked = false;
                this.chkNotCheck.Checked = false;
                this.chkPosition.Checked = false;
                this.lkeDepartment.ReadOnly = false;
                this.lkeDepartment.Focus();
                this.lkeDepartment.ShowPopup();
            }
            else
            {
                this.lkeDepartment.ReadOnly = true;
                this.layoutControlGroup3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        private void ChkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked)
            {
                this.chkDepartment.Checked = false;
                this.chkNotCheck.Checked = false;
                this.chkPosition.Checked = false;
                this._tableEvaluation = FileProcess.LoadTable("STPayrollMonthlyEvaluation @PayRollMonthID = " + this._currentPayroll.PayRollMonthID + ", @PositionID = null, @DepartmentID = null, @Shift = null, @Flag = null, @varStoreID = " + AppSetting.StoreID);
                LoadEvaluationDetail();
            }
        }

        private void DataNavigatorEvaluation_PositionChanged(object sender, EventArgs e)
        {
            this._currentPayroll = this._listPayroll[this.dataNavigatorEvaluation.Position];
            BindData();
            this.RefreshEvaluationDetail();
        }

        #region Events

        #endregion

        #region Load Data
        private void LoadEvaluation()
        {
            DateTime conditionDate = new DateTime(2011, 12, 26);
            this._listPayroll = this._payrollDA.Select(p => p.FromDate >= conditionDate).ToList();

            this.dataNavigatorEvaluation.DataSource = this._listPayroll;
            this.dataNavigatorEvaluation.Position = this._listPayroll.Count - 1;
        }

        private void LoadEvaluationDetail()
        {
            this.grdEvaluationDetail.DataSource = this._tableEvaluation;
        }
        private void LoadStore()
        {
            DataProcess<Stores> dataProcess = new DataProcess<Stores>();
            this.lkeStores.Properties.DataSource = dataProcess.Select();
        }

        private void InitPosition()
        {
            DataProcess<Positions> positionDA = new DataProcess<Positions>();

            this.lkePosition.Properties.DataSource = positionDA.Select(p => p.PositionID == 16 || p.PositionID == 26 || p.PositionID == 6 || p.PositionID == 34 || p.PositionID == 10 || p.PositionID == 5 || p.PositionID == 43 || p.PositionID == 28 || p.PositionID == 18 || p.PositionID == 7 || p.PositionID == 8 || p.PositionID == 27 || p.PositionID == 19 || p.PositionID == 17);
            this.lkePosition.Properties.ValueMember = "PositionID";
            this.lkePosition.Properties.DisplayMember = "PositionDescription";
        }

        private void InitDepartment()
        {
            DataProcess<Departments> departmentDA = new DataProcess<Departments>();

            this.lkeDepartment.Properties.DataSource = departmentDA.Select(d => d.DepartmentID != 5);
            this.lkeDepartment.Properties.ValueMember = "DepartmentID";
            this.lkeDepartment.Properties.DisplayMember = "DepartmentName";
        }

        private void BindData()
        {
            if (this._currentPayroll.PayrollMonthConfirm)
            {
                this.grcABC.OptionsColumn.ReadOnly = true;
                this.grcABC.OptionsColumn.AllowEdit = false;
                this.grcABC1.OptionsColumn.ReadOnly = true;
                this.grcABC1.OptionsColumn.AllowEdit = false;
            }
            else
            {
                this.grcABC.OptionsColumn.ReadOnly = false;
                this.grcABC.OptionsColumn.AllowEdit = true;
                this.grcABC1.OptionsColumn.ReadOnly = false;
                this.grcABC1.OptionsColumn.AllowEdit = true;
            }
            this.txtMonthID.Text = this._currentPayroll.PayRollMonthID.ToString();
            this.txtMonth.Text = this._currentPayroll.PayRollMonth1;
            this.txtCreated.Text = this._currentPayroll.CreatedBy;
            this.dtFromDate.EditValue = this._currentPayroll.FromDate;
            this.dtToDate.EditValue = this._currentPayroll.ToDate;
            this.txtSunday.Text = this._currentPayroll.SundayHoliday.ToString();
            this.txtHoliday.Text = this._currentPayroll.PayableHoliday.ToString();
            this.txtWorkingDays.Text = ((dtToDate.DateTime - dtFromDate.DateTime).Days + 1 - this._currentPayroll.SundayHoliday - this._currentPayroll.PayableHoliday).ToString();
            this.btnComfirm.Enabled = !this._currentPayroll.PayrollMonthLock;
            if (!this.btnComfirm.Enabled) this.btnAccept.Enabled = false;
            else
            {
                this.btnAccept.Enabled = true;
                if (this._currentPayroll.PayrollMonthConfirm) this.btnAccept.Text = "Un-Accept";
                else this.btnAccept.Text = "Accept";
            }
            
            if (this._currentPayroll.NSMHL != null) this.isNSMHL = Convert.ToBoolean(this._currentPayroll.NSMHL);
            if (this.isNSMHL)
            {
                this.btnUpdateHandlingWeight.Text = "De. Handling W";
                this.btnUpdateHandlingWeight.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Critical;
            }
            else
            {
                this.btnUpdateHandlingWeight.Text = "Up. Handling W";
                this.btnUpdateHandlingWeight.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            }
        }
        #endregion

        private void RefreshEvaluationDetail()
        {
            if (this.chkAll.Checked)
            {
                this._tableEvaluation = FileProcess.LoadTable("STPayrollMonthlyEvaluation @PayRollMonthID = " + this._currentPayroll.PayRollMonthID + ", @PositionID = null, @DepartmentID = null, @Shift = null, @Flag = null, @varStoreID = " + AppSetting.StoreID);
            }
            else
            {
                if (this.chkDepartment.Checked)
                {
                    if (chkDeptAll.Checked)
                    {
                        this._tableEvaluation = FileProcess.LoadTable("STPayrollMonthlyEvaluation @PayRollMonthID = " + this._currentPayroll.PayRollMonthID + ", @PositionID = null, @DepartmentID = " + Convert.ToInt32(this.lkeDepartment.EditValue) + ", @Shift = null, @Flag = null, @varStoreID = " + AppSetting.StoreID);
                    }
                    else
                    {
                        if (chkDeptDay.Checked)
                        {
                            this._tableEvaluation = FileProcess.LoadTable("STPayrollMonthlyEvaluation @PayRollMonthID = " + this._currentPayroll.PayRollMonthID + ", @PositionID = null, @DepartmentID = " + Convert.ToInt32(this.lkeDepartment.EditValue) + ", @Shift = 1, @Flag = null, @varStoreID = " + AppSetting.StoreID);
                        }
                        else
                        {
                            this._tableEvaluation = FileProcess.LoadTable("STPayrollMonthlyEvaluation @PayRollMonthID = " + this._currentPayroll.PayRollMonthID + ", @PositionID = null, @DepartmentID = " + Convert.ToInt32(this.lkeDepartment.EditValue) + ", @Shift = 2, @Flag = null, @varStoreID = " + AppSetting.StoreID);
                        }
                    }
                }
                else
                {
                    if (this.chkPosition.Checked)
                    {
                        this._tableEvaluation = FileProcess.LoadTable("STPayrollMonthlyEvaluation @PayRollMonthID = " + this._currentPayroll.PayRollMonthID + ", @PositionID = " + Convert.ToInt32(this.lkePosition.EditValue) + ", @DepartmentID = null, @Shift = null, @Flag = null, @varStoreID = " + AppSetting.StoreID);
                    }
                    else
                    {
                        this._tableEvaluation = FileProcess.LoadTable("STPayrollMonthlyEvaluation @PayRollMonthID = " + this._currentPayroll.PayRollMonthID + ", @PositionID = null, @DepartmentID = null, @Shift = null, @Flag = null, @varStoreID = " + AppSetting.StoreID);
                    }
                }
            }
            LoadEvaluationDetail();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            string fileName = "\\ExportEmployee_" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + ".xlsx";
            String path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + fileName;
            this.grvEvaluationDetail.ExportToXlsx(path);
            System.Diagnostics.Process.Start("explorer.exe", path);
        }

        private void btnComfirm_Click(object sender, EventArgs e)
        {
            if (!this._currentPayroll.PayrollMonthConfirm)
            {
                MessageBox.Show("Ban phai Accept truoc khi confirm!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var dl = MessageBox.Show("Sau khi confirm ban khong the nha!", "TPWMS", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dl.Equals(DialogResult.Cancel)) return;
            DataProcess<PayrollMonth> dataProcess = new DataProcess<PayrollMonth>();
            dataProcess.ExecuteNoQuery("STPayrollMonthlyLockOrderUpdate @FromDate={0},@ToDate={1}", dtFromDate.DateTime.ToString("yyyy-MM-dd"), this.dtToDate.DateTime.ToString("yyyy-MM-dd"));
            dataProcess.ExecuteNoQuery("STPayRollMonthlyPersonnelInsert @PayrollMonthID={0},@CreatedBy={1}", this._currentPayroll.PayRollMonthID, AppSetting.CurrentUser.LoginName);
            this.LoadEvaluation();
        }

        private void btnPersonnelView_Click(object sender, EventArgs e)
        {
            var dataSource = FileProcess.LoadTable("Select count(*) as total from MonthlyPayRollQuantity Where PayRollMonthID=" + this._currentPayroll.PayRollMonthID);
            if (dataSource == null || Convert.ToInt32(dataSource.Rows[0]["total"]) <= 0)
            {
                MessageBox.Show("Month " + this._currentPayroll.PayRollMonth1 + " 's monthly personnel report was uncreated !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frm_S_AO_MonthlyPersonnel frm = new frm_S_AO_MonthlyPersonnel(this._currentPayroll.PayRollMonthID);
            frm.ShowDialog();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            if (this.lkeStores.EditValue == null)
            {
                this.lkeStores.Focus();
                this.lkeStores.ShowPopup();
                return;
            }
            var dataSource = FileProcess.LoadTable("STEmployeeWorkingAdvanceList @PayRollMonthID=" + this._currentPayroll.PayRollMonthID + ",@varStoreID=" + this.lkeStores.EditValue);
            rptPayrollMonthlyAdvance rpt = new rptPayrollMonthlyAdvance();
            rpt.RequestParameters = false;
            rpt.Parameters["paramTitle"].Value = this.txtMonth.Text;
            rpt.DataSource = dataSource;

            ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
            tool.ShowPreviewDialog();

        }

        private void btnUpdatePerformance_Click(object sender, EventArgs e)
        {
            Common.Process.Wait.Start(this);
            DataProcess<PayrollMonth> dataProcess = new DataProcess<PayrollMonth>();
            dataProcess.ExecuteNoQuery("STEmployeeWorkingUpdate @FromDate={0},@ToDate={1}", dtFromDate.DateTime.ToString("yyyy-MM-dd"), this.dtToDate.DateTime.ToString("yyyy-MM-dd"));
            dataProcess.ExecuteNoQuery("STEmployeeEvalMonthlyInsert @PayRollMonthID={0}", this._currentPayroll.PayRollMonthID);
            dataProcess.ExecuteNoQuery("STPayRollMonthlyPerformanceAverageUpdate @PayRollMonthID={0}", this._currentPayroll.PayRollMonthID);
            string updateBy = AppSetting.CurrentUser.LoginName + " - " + DateTime.Now.ToString("dd/MM/yy HH:mm");
            dataProcess.ExecuteNoQuery("STPayRollMonthlyUpdateAll @varPayRollMonthID={0},@UpdatedBy={1}", this._currentPayroll.PayRollMonthID, updateBy);
            Common.Process.Wait.Close();
        }

        private void btnMonthOfBirth_Click(object sender, EventArgs e)
        {
            if (this.lkeStores.EditValue == null)
            {
                this.lkeStores.Focus();
                this.lkeStores.ShowPopup();
                return;
            }
            var dataSource = FileProcess.LoadTable("STPayRollMonthlyBirthdayReport @PayRollMonthID=" + this._currentPayroll.PayRollMonthID + ",@varStoreID=" + this.lkeStores.EditValue);
            rptPayrollMonthlyOfBirth rpt = new rptPayrollMonthlyOfBirth();
            rpt.RequestParameters = false;
            rpt.Parameters["paramMonth"].Value = this.txtMonth.Text;
            string title = "TEMPORARY EMPLOYEES";
            if (dataSource != null && dataSource.Rows.Count > 0 && Convert.ToBoolean(dataSource.Rows[0]["ContractPermanent"])) title = "PERMANENT EMPLOYEES";
            rpt.Parameters["paramTitle"].Value = title;
            rpt.Parameters["paramWorkingDay"].Value = this._currentPayroll.WorkingDays;
            rpt.DataSource = dataSource;

            ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
            tool.ShowPreviewDialog();
        }

        private void btnDateRerport_Click(object sender, EventArgs e)
        {
            if (this.lkeStores.EditValue == null)
            {
                this.lkeStores.Focus();
                this.lkeStores.ShowPopup();
                return;
            }
            var dataSource = FileProcess.LoadTable("STPayRollMonthlyByDateReport @PayRollMonthID=" + this._currentPayroll.PayRollMonthID + ",@ContractPermanent=1,@StoreID=" + this.lkeStores.EditValue);

            string pathSaveFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string fileExport = pathSaveFile + "\\" + "PayRollByDateReport" + DateTime.Now.ToString("dd_MM_yy") + ".xlsx";
            this.ExportExel(fileExport, dataSource);
        }

        private void btnDateTemp_Click(object sender, EventArgs e)
        {
            if (this.lkeStores.EditValue == null)
            {
                this.lkeStores.Focus();
                this.lkeStores.ShowPopup();
                return;
            }
            var dataSource = FileProcess.LoadTable("STPayRollMonthlyByDateReport @PayRollMonthID=" + this._currentPayroll.PayRollMonthID + ",@ContractPermanent=0,@StoreID=" + this.lkeStores.EditValue);
            string pathSaveFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string fileExport = pathSaveFile + "\\" + "PayRollByDateTempReport" + DateTime.Now.ToString("dd_MM_yy") + ".xlsx";
            this.ExportExel(fileExport, dataSource);
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

        private void btnView_Click(object sender, EventArgs e)
        {
            if (this.lkeStores.EditValue == null)
            {
                this.lkeStores.Focus();
                this.lkeStores.ShowPopup();
                return;
            }
            if (!this._currentPayroll.PayrollMonthLock)
            {
                var dl = MessageBox.Show("Ban co muon update du lieu truoc khi in khong ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dl.Equals(DialogResult.Yes))
                {
                    btnUpdatePerformance_Click(sender, e);
                }
            }
            var dataSource = FileProcess.LoadTable("STPayRollMonthlyReport @PayRollMonthID=" + this._currentPayroll.PayRollMonthID + ",@Flag=NULL,@StoreID=" + this.lkeStores.EditValue);
            // Dispalay report
            //rptPayrollMonthly rpt = new rptPayrollMonthly();
            rptPayrollMonthlyNew rpt = new rptPayrollMonthlyNew();
            rpt.RequestParameters = false;
            rpt.Parameters["paramMonth"].Value = this.txtMonth.Text;
            string title = "TEMPORARY EMPLOYEES";
            if (dataSource != null && dataSource.Rows.Count > 0 && Convert.ToBoolean(dataSource.Rows[0]["ContractPermanent"])) title = "PERMANENT EMPLOYEES";
            rpt.Parameters["paramTitle"].Value = title;
            rpt.Parameters["paramWorkingDay"].Value = this._currentPayroll.WorkingDays;
            rpt.DataSource = dataSource;

            ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
            tool.ShowPreviewDialog();
        }

        private void btnRWorkers_Click(object sender, EventArgs e)
        {
            if (this.lkeStores.EditValue == null)
            {
                this.lkeStores.Focus();
                this.lkeStores.ShowPopup();
                return;
            }

            var dataSource = FileProcess.LoadTable("STPayRollMonthlyReport @PayRollMonthID=" + this._currentPayroll.PayRollMonthID + ",@Flag=1,@StoreID=" + this.lkeStores.EditValue);
            //rptPayrollMonthly rpt = new rptPayrollMonthly();
            rptPayrollMonthlyNew rpt = new rptPayrollMonthlyNew();
            rpt.RequestParameters = false;
            rpt.Parameters["paramMonth"].Value = this.txtMonth.Text;
            string title = "TEMPORARY EMPLOYEES";
            if (dataSource != null && dataSource.Rows.Count > 0 && Convert.ToBoolean(dataSource.Rows[0]["ContractPermanent"])) title = "PERMANENT EMPLOYEES";
            rpt.Parameters["paramTitle"].Value = title;
            rpt.Parameters["paramWorkingDay"].Value = this._currentPayroll.WorkingDays;
            rpt.DataSource = dataSource;

            ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
            tool.ShowPreviewDialog();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {            
            int managerChecked = 0;
            DataProcess<PayrollMonthlyDetails> dataProcess = new DataProcess<PayrollMonthlyDetails>();
            managerChecked = dataProcess.Select(p => p.PayRollMonthID == this._currentPayroll.PayRollMonthID && p.ManagerCheck == false).Count();
            if (managerChecked > 0)
            {
                MessageBox.Show("Can not Accept, because Manager don't check!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //Phan quyen Nhan su moi duoc edit
            var levelDepartmentTb = FileProcess.LoadTable("SELECT count(UserRoleDefinitions.LevelDepartment) as LevelDepartment" +
            " FROM UserAccounts INNER JOIN" +
                         " UserApplications ON UserAccounts.LoginName = UserApplications.UserId INNER JOIN" +
                         " UserApplicationRoles ON UserApplications.UserApplicationId = UserApplicationRoles.UserApplicationId INNER JOIN" +
                         " UserRoleDefinitions ON UserApplicationRoles.RoleId = UserRoleDefinitions.RoleId" +
                         " WHERE UserDepartmentDefinitionID = 7 and UserAccounts.LoginName = '" + AppSetting.CurrentUser.LoginName + "'");


            int levelDepartment = Convert.ToInt32(levelDepartmentTb.Rows[0]["LevelDepartment"].ToString());
            if (levelDepartment == 0)
            {
                MessageBox.Show("Permission denied!", "WMS_2017", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this._currentPayroll.PayrollMonthConfirm = !this._currentPayroll.PayrollMonthConfirm;


            if (this._currentPayroll.PayrollMonthConfirm) this.btnAccept.Text = "Un-Accept";
            else this.btnAccept.Text = "Accept";
            this._listPayroll[this.dataNavigatorEvaluation.Position].PayrollMonthConfirm = this._currentPayroll.PayrollMonthConfirm;
            string updateBy = AppSetting.CurrentUser.LoginName + " - " + DateTime.Now.ToString("dd/MM/yy HH:mm");
            dataProcess.ExecuteNoQuery("STPayRollMonthlyUpdateAll @varPayRollMonthID={0},@UpdatedBy={1}", this._currentPayroll.PayRollMonthID, updateBy);
            dataProcess.ExecuteNoQuery("STEmployeeEvalMonthlyInsert @PayRollMonthID={0}", this._currentPayroll.PayRollMonthID);
            dataProcess.ExecuteNoQuery("STPayRollMonthlyPerformanceAverageUpdate @PayRollMonthID={0}", this._currentPayroll.PayRollMonthID);

            if (this._currentPayroll.PayrollMonthConfirm) this._currentPayroll.AcceptBy = updateBy;
            else
                this._currentPayroll.AcceptBy = "Cancel by " + updateBy;
            dataProcess.ExecuteNoQuery("Update PayrollMonth set AcceptBy={0},PayrollMonthConfirm={1} where PayRollMonthID={2}", this._currentPayroll.AcceptBy, this._currentPayroll.PayrollMonthConfirm, this._currentPayroll.PayRollMonthID);
        }

        private void btnUpdateHandlingWeight_Click(object sender, EventArgs e)
        {
            var levelDepartmentTb = FileProcess.LoadTable("SELECT count(UserRoleDefinitions.LevelDepartment) as LevelDepartment" +
            " FROM UserAccounts INNER JOIN" +
                         " UserApplications ON UserAccounts.LoginName = UserApplications.UserId INNER JOIN" +
                         " UserApplicationRoles ON UserApplications.UserApplicationId = UserApplicationRoles.UserApplicationId INNER JOIN" +
                         " UserRoleDefinitions ON UserApplicationRoles.RoleId = UserRoleDefinitions.RoleId" +
                         " WHERE UserDepartmentDefinitionID = 7 and UserAccounts.LoginName = '" + AppSetting.CurrentUser.LoginName + "'");


            int levelDepartment = Convert.ToInt32(levelDepartmentTb.Rows[0]["LevelDepartment"].ToString());
            if (levelDepartment == 0)
            {
                MessageBox.Show("Permission denied!", "WMS_2017", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.btnUpdatePerformance_Click(sender, e);
            DataProcess<object> dataProcess = new DataProcess<object>();
            if (!this.isNSMHL)
            {
                // INSERT
                dataProcess.ExecuteNoQuery("STEmployeeWorkingHandlingWeightInsert @PayRollMonthID={0},@CreatedBy={1}",
                   this._currentPayroll.PayRollMonthID, AppSetting.CurrentUser.LoginName + " - " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
            }
            else
            {
                //DELETE
                dataProcess.ExecuteNoQuery("STEmployeeWorkingHandlingWeightInsert @PayRollMonthID={0},@CreatedBy={1},@Flag={2}",
                    this._currentPayroll.PayRollMonthID, "No_Need", 1);
            }
            dataProcess.ExecuteNoQuery("Update PayrollMonth set NSMHL={0} where PayRollMonthID={1}", !this.isNSMHL, this._currentPayroll.PayRollMonthID);
            this.LoadEvaluation();
        }

        private void btnViewPriceDetail_Click(object sender, EventArgs e)
        {
            var levelDepartmentTb = FileProcess.LoadTable("SELECT count(UserRoleDefinitions.LevelDepartment) as LevelDepartment" +
            " FROM UserAccounts INNER JOIN" +
                         " UserApplications ON UserAccounts.LoginName = UserApplications.UserId INNER JOIN" +
                         " UserApplicationRoles ON UserApplications.UserApplicationId = UserApplicationRoles.UserApplicationId INNER JOIN" +
                         " UserRoleDefinitions ON UserApplicationRoles.RoleId = UserRoleDefinitions.RoleId" +
                         " WHERE UserDepartmentDefinitionID = 7 and UserAccounts.LoginName = '" + AppSetting.CurrentUser.LoginName + "'");


            int levelDepartment = Convert.ToInt32(levelDepartmentTb.Rows[0]["LevelDepartment"].ToString());
            if (levelDepartment == 0)
            {
                MessageBox.Show("Permission denied!", "WMS_2017", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this.lkeStores.EditValue == null)
            {
                this.lkeStores.Focus();
                this.lkeStores.ShowPopup();
                return;
            }
            //var dataSource = FileProcess.LoadTable("STEmployeeWorkingAdvanceList @PayRollMonthID=" + this._currentPayroll.PayRollMonthID + ",@varStoreID=" + this.lkeStores.EditValue);
            var dataSource = FileProcess.LoadTable("STEmployeeWorkingByJobCrosstapReport_SendEmail @PayRollMonthID=" + this._currentPayroll.PayRollMonthID
                + ",@ContractPermanent = 'Temporary', @Productivity='BY PRODUCTIVITY'"
                + ",@varStoreID=" + this.lkeStores.EditValue
                + ",@flatCrossTap=1");
            rptSummaryPrices rpt = new rptSummaryPrices();

            rpt.RequestParameters = false;
            //rpt.Parameters["paramTitle"].Value = this.txtMonth.Text;
            rpt.DataSource = dataSource;

            ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
            tool.ShowPreviewDialog();
        }
    }
}
