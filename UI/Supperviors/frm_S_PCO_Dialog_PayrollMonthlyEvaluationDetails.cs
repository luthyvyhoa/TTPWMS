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
using DevExpress.XtraEditors;
using UI.Helper;

namespace UI.Supperviors
{
    public partial class frm_S_PCO_Dialog_PayrollMonthlyEvaluationDetails : Common.Controls.frmBaseForm
    {
        private int _employeeID;
        private int _monthlyID;
        private DateTime _from;
        private DateTime _to;
        private ST_WMS_LoadEvaluationDetail_Result _detail;

        public frm_S_PCO_Dialog_PayrollMonthlyEvaluationDetails(int employeeID, int monthlyID, DateTime from, DateTime to)
        {
            InitializeComponent();
            this._employeeID = employeeID;
            this._monthlyID = monthlyID;
            this._from = from;
            this._to = to;
            this._detail = new ST_WMS_LoadEvaluationDetail_Result();
            DataProcess<PayrollMonthlyDetails> dataProcess = new DataProcess<PayrollMonthlyDetails>();
            DataProcess<PayrollMonth> payrollData = new DataProcess<PayrollMonth>();
            var currentPayrollDetail = dataProcess.Select(p => p.PayRollMonthlyID == monthlyID).FirstOrDefault();
            var currentPayroll = payrollData.Select(p => p.PayRollMonthID == currentPayrollDetail.PayRollMonthID).FirstOrDefault();
            if (currentPayroll != null)
            {
                if (currentPayroll.PayrollMonthConfirm)
                {
                    this.cbxABC.Properties.ReadOnly = true;
                    this.cbxABC1.Properties.ReadOnly = true;
                }
            }
        }

        private void frm_S_PCO_PayrollMonthlyEvaluationDetails_Load(object sender, EventArgs e)
        {
            InitMarks();
            LoadDetail();
            LoadDescription();
            SetEvents();
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
                this.cbxABC.Enabled = false;
            }
            else
            {
                this.cbxABC.Enabled = true;
            }
        }

        private void SetEvents()
        {
            this.cbxABC.EditValueChanged += CbxABC_EditValueChanged;
            this.cbxABC1.EditValueChanged += CbxABC1_EditValueChanged;
            this.cbxAttitude.EditValueChanged += CbxAttitude_EditValueChanged;
            this.cbxPerformance.EditValueChanged += CbxPerformance_EditValueChanged;
            this.cbxProfession.EditValueChanged += CbxProfession_EditValueChanged;
            this.cbxSafety.EditValueChanged += CbxSafety_EditValueChanged;
            this.cbxTime.EditValueChanged += CbxTime_EditValueChanged;
            this.mmeSupervisorUser.TextChanged += MmeSupervisorUser_TextChanged;
            this.mmeSupervisorRemark.Leave += MmeSupervisorRemark_Leave;
            this.mmeSupervisorRemark.TextChanged += MmeSupervisorRemark_TextChanged;
            this.btnClear.Click += BtnClear_Click;
            this.btnSave.Click += BtnSave_Click;
            this.btnClose.Click += BtnClose_Click;
        }

        private void SetUserPermission()
        {
            // This function define Group that user belong to:
            // 1: Manager
            // 2: Personnel
            // 3: Safety
            // 4: Supervisor
            // 5: Assistant Manager
            // 6: User not allowed
        }

        private void MmeSupervisorUser_TextChanged(object sender, EventArgs e)
        {
            this._detail.SupervisorUser = this.mmeSupervisorUser.Text;
        }

        private void MmeSupervisorRemark_TextChanged(object sender, EventArgs e)
        {
            this._detail.SupervisorRemark = this.mmeSupervisorRemark.Text;
        }

        private void MmeSupervisorRemark_Leave(object sender, EventArgs e)
        {
            if (this.mmeSupervisorRemark.IsModified && !String.IsNullOrEmpty(this.mmeSupervisorRemark.Text))
            {
                this.mmeSupervisorUser.Text = AppSetting.CurrentUser.LoginName + "-" + DateTime.Now.ToString("dd/MM/yy HH:mm");
            }
        }

        private void CbxTime_EditValueChanged(object sender, EventArgs e)
        {
            this._detail.EvaluationTime = this.cbxTime.Text;
        }

        private void CbxSafety_EditValueChanged(object sender, EventArgs e)
        {
            this._detail.EvaluationSafety = this.cbxSafety.Text;
        }

        private void CbxProfession_EditValueChanged(object sender, EventArgs e)
        {
            this._detail.EvaluationCreative = this.cbxProfession.Text;
        }

        private void CbxPerformance_EditValueChanged(object sender, EventArgs e)
        {
            this._detail.EvaluationPerformance = this.cbxPerformance.Text;
        }

        private void CbxAttitude_EditValueChanged(object sender, EventArgs e)
        {
            this._detail.EvaluationAttitude = this.cbxAttitude.Text;
        }

        private void CbxABC1_EditValueChanged(object sender, EventArgs e)
        {
            this._detail.ABC1 = this.cbxABC1.Text;
            this.mmeSupervisorUser.Text = AppSetting.CurrentUser.LoginName + " - " + DateTime.Now.ToString("dd/MM/yy HH:mm");
        }

        private void CbxABC_EditValueChanged(object sender, EventArgs e)
        {
            this._detail.ABC = this.cbxABC.Text;
            this._detail.PersonnelUser = AppSetting.CurrentUser.LoginName + " - " + DateTime.Now.ToString("dd/MM/yy HH:mm");
            this.mmeUserCheckTime.Text = AppSetting.CurrentUser.LoginName + " - " + DateTime.Now.ToString("dd/MM/yy HH:mm");
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Ban co muon clear danh gia nhan vien nay khong ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.mmeSupervisorRemark.Text = String.Empty;
                this.mmeSupervisorUser.Text = String.Empty;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            UpdateDetail();
            this.Close();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Load Data
        private void LoadDetail()
        {
            DataProcess<ST_WMS_LoadEvaluationDetail_Result> da = new DataProcess<ST_WMS_LoadEvaluationDetail_Result>();

            this._detail = da.Executing("ST_WMS_LoadEvaluationDetail @EmployeeID = {0}, @PayRollMonthlyID = {1}", this._employeeID, this._monthlyID).FirstOrDefault();
            BindData();
        }

        private void LoadDescription()
        {
            this.grdDescription.DataSource = FileProcess.LoadTable("STPayrollMonthlyEvaluationEvents @EmployeeID = " + this._employeeID + ", @FromDate = '" + this._from.ToString("yyyy-MM-dd") + "', @ToDate = '" + this._to.ToString("yyyy-MM-dd") + "'");
        }

        private void InitMarks()
        {
            List<string> listMarks = new List<string>();

            listMarks.Add("A");
            listMarks.Add("B+");
            listMarks.Add("B");
            listMarks.Add("B-");
            listMarks.Add("C");

            this.cbxABC.Properties.Items.AddRange(listMarks);
            this.cbxABC1.Properties.Items.AddRange(listMarks);
            this.cbxAttitude.Properties.Items.AddRange(listMarks);
            this.cbxPerformance.Properties.Items.AddRange(listMarks);
            this.cbxProfession.Properties.Items.AddRange(listMarks);
            this.cbxSafety.Properties.Items.AddRange(listMarks);
            this.cbxTime.Properties.Items.AddRange(listMarks);
        }

        private void BindData()
        {
            this.simpleLabelItem1.Text = this._detail.VietnamName;
            this.simpleLabelItem2.Text = this._detail.EmployeeID.ToString();
            this.txtOTH.Text = this._detail.OTH.ToString();
            this.txtOTN.Text = this._detail.OTN.ToString();
            this.txtOTS.Text = this._detail.OTS.ToString();
            this.txtOTNN.Text = this._detail.OTNN.ToString();
            this.txtOTNNN.Text = this._detail.OTNN_.ToString();
            this.txtOTSN.Text = this._detail.OTSN.ToString();
            this.txtOTHN.Text = this._detail.OTHN.ToString();
            this.txtPercent.Text = this._detail.PerformancePercent.ToString();
            this.txtPerformance.Text = this._detail.Performance.ToString();
            this.txtSick.Text = this._detail.Sick.ToString();
            this.txtABC.Text = this._detail.ABCtemp;
            this.txtHaft.Text = this._detail.Haft.ToString();
            this.txtLeave.Text = this._detail.Leave.ToString();
            this.txtOff.Text = this._detail.Off.ToString();
            this.cbxABC.Text = this._detail.ABC;
            this.cbxABC1.Text = this._detail.ABC1;
            this.cbxAttitude.Text = this._detail.EvaluationAttitude;
            this.cbxProfession.Text = this._detail.EvaluationCreative;
            this.cbxPerformance.Text = this._detail.EvaluationPerformance;
            this.cbxSafety.Text = this._detail.EvaluationSafety;
            this.cbxTime.Text = this._detail.EvaluationTime;
            this.mmeManagerCheckUser.Text = this._detail.ManagerCheckUser;
            this.mmeManagerRemark.Text = this._detail.ManagerRemark;
            this.mmePersonnelRemark.Text = this._detail.PersonnelRemark;
            this.mmeSafetyCheckTime.Text = this._detail.SafetyCheckTime.ToString();
            this.mmeSafetyRemark.Text = this._detail.SafetyRemark;
            this.mmeSupervisorRemark.Text = this._detail.SupervisorRemark;
            this.mmeSupervisorUser.Text = this._detail.SupervisorUser;
            this.mmeUserCheckTime.Text = this._detail.PersonnelUser + "\n" + this._detail.PersonnelCheckTime;
            this.chkManagerCheck.Checked = (bool)this._detail.ManagerCheck;
            this.chkPersonnelCheck.Checked = (bool)this._detail.PersonnelCheck;
            this.chkSafetyCheck.Checked = (bool)this._detail.SafetyCheck;
        }
        #endregion

        private void UpdateDetail()
        {
            DataProcess<PayrollMonthlyDetails> monthlyDA = new DataProcess<PayrollMonthlyDetails>();
            PayrollMonthlyDetails detail = new PayrollMonthlyDetails();
            detail.ABC = this._detail.ABC;
            detail.ABC1 = this._detail.ABC1;
            detail.ABCtemp = this._detail.ABCtemp;
            detail.Active = this._detail.Active;
            detail.Advance = this._detail.Advance;
            detail.AllowUpdated = this._detail.AllowUpdated;
            detail.ContractPermanent = this._detail.ContractPermanent;
            detail.DepartmentID = this._detail.DepartmentID;
            detail.EmployeeID = this._detail.EmployeeID;
            detail.EvaluationAttitude = this._detail.EvaluationAttitude;
            detail.EvaluationCreative = this._detail.EvaluationCreative;
            detail.EvaluationPerformance = this._detail.EvaluationPerformance;
            detail.EvaluationSafety = this._detail.EvaluationSafety;
            detail.EvaluationTime = this._detail.EvaluationTime;
            detail.Haft = this._detail.Haft;
            detail.IsBirthday = this._detail.IsBirthday;
            detail.Leave = this._detail.Leave;
            detail.ManagerCheck = this.chkManagerCheck.Checked;
            detail.ManagerCheckUser = this._detail.ManagerCheckUser;
            detail.ManagerRemark = this.mmeManagerRemark.Text;
            detail.Off = this._detail.Off;
            detail.OTH = this._detail.OTH;
            detail.OTHN = this._detail.OTHN;
            detail.OTH_ = this._detail.OTH_;
            detail.OTN = this._detail.OTN;
            detail.OTNN = this._detail.OTNN;
            detail.OTNN_ = this._detail.OTNN_;
            detail.OTS = this._detail.OTS;
            detail.OTSN = this._detail.OTSN;
            detail.PayRollMonthID = this._detail.PayRollMonthID;
            detail.PayRollMonthlyID = this._detail.PayRollMonthlyID;
            detail.PayRollMonthlyRemark = this._detail.PayRollMonthlyRemark;
            detail.Performance = this._detail.Performance;
            detail.PerformanceAverage = this._detail.PerformanceAverage;
            detail.PerformancePercent = this._detail.PerformancePercent;
            detail.PerformanceStatus = this._detail.PerformanceStatus;
            detail.PersonnelCheck = this.chkPersonnelCheck.Checked;
            detail.PersonnelCheckTime = this._detail.PersonnelCheckTime;
            detail.PersonnelRemark = this.mmePersonnelRemark.Text;
            detail.PersonnelUser = this._detail.PersonnelUser;
            detail.Position = this._detail.Position;
            detail.PositionID = this._detail.PositionID;
            detail.SafetyCheck = this.chkSafetyCheck.Checked;
            detail.SafetyCheckTime = this._detail.SafetyCheckTime;
            detail.SafetyRemark = this.mmeSafetyRemark.Text;
            detail.ShiftID = this._detail.ShiftID;
            detail.Sick = this._detail.Sick;
            detail.SupervisorRemark = this.mmeSupervisorRemark.Text;
            detail.SupervisorUser = this._detail.SupervisorUser;
            detail.User = this._detail.User;
            detail.WorkingDayHoliday = this._detail.WorkingDayHoliday;
            detail.WorkingDayNightShift = this._detail.WorkingDayNightShift;
            detail.WorkingDays = this._detail.WorkingDays;

            int result = monthlyDA.Update(detail);
        }
    }
}
