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
using DevExpress.XtraGrid;

namespace UI.Supperviors
{
    public partial class frm_S_PCO_Dialog_PayrollViewByEmployee : Common.Controls.frmBaseForm
    {
        private DataTable _tablePayroll;
        private int _employeeID;
        private int payRollMonthlyID=0;
        private Employees currentEmployee = null;

        public frm_S_PCO_Dialog_PayrollViewByEmployee(int employeeID,int payRollMonthlyID=0)
        {
            InitializeComponent();
            this._tablePayroll = new DataTable();
            this._employeeID = employeeID;
            this.payRollMonthlyID = payRollMonthlyID;
            this.simpleLabelItem1.Text = this._employeeID.ToString();
        }

        private void frm_S_PCO_Dialog_PayrollViewByEmployee_Load(object sender, EventArgs e)
        {
            DataProcess<Employees> dataProcess = new DataProcess<Employees>();
            this.currentEmployee = dataProcess.Select(em => em.EmployeeID == this._employeeID).FirstOrDefault();
            this.simpleLabelItem1.Text = this.currentEmployee.FullName;
            this.simpleLabelItem2.Text = this.currentEmployee.EmployeeID.ToString();
            this.simpleLabelItem3.Text = this.currentEmployee.Position;
            if (this.payRollMonthlyID <= 0) this.btnDelete.Enabled = false;

            InitPlace();
            SetEvents();
            LoadPayroll();
            InitMonth();
        }

        private void SetEvents()
        {
            this.rpi_hpl_PayrollDate.DoubleClick += Rpi_hpl_PayrollDate_DoubleClick;
            this.btnUpdateTime.Click += BtnUpdateTime_Click;
            this.btnViewProposal.Click += BtnViewProposal_Click;
            this.lkeMonth.EditValueChanged += LkeMonth_EditValueChanged;
            this.grvPayrollView.CellValueChanged += GrvPayrollView_CellValueChanged;
            this.grvPayrollView.CustomSummaryCalculate += GrvPayrollView_CustomSummaryCalculate;
            this.grvPayrollView.RowCellStyle += GrvPayrollView_RowCellStyle;
            this.rpi_btn_Propose.Click += rpi_btn_Propose_Click;
        }

        private void GrvPayrollView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle < 0) return;
            bool isSunday = Convert.ToBoolean(this.grvPayrollView.GetRowCellValue(e.RowHandle, "SunHol"));
            if (isSunday)
            {
                e.Appearance.BackColor = Color.DarkSalmon;
                e.Appearance.ForeColor = Color.Black;
            }
        }

        private void LkeMonth_EditValueChanged(object sender, EventArgs e)
        {
            LoadPayrollByMonth();
        }

        void rpi_btn_Propose_Click(object sender, EventArgs e)
        {
            //Open frm frmEmployeeOTNew
            int employeeID = Convert.ToInt32(this.simpleLabelItem2.Text);
            string workDate = this.grvPayrollView.GetFocusedRowCellValue("PayrollDate").ToString();
            frm_S_PCO_EmployeeOTNew frmOT = new frm_S_PCO_EmployeeOTNew(employeeID, workDate);
            if (!frmOT.Enabled) return;
            frmOT.ShowDialog();
        }

        #region Events
        private void Rpi_hpl_PayrollDate_DoubleClick(object sender, EventArgs e)
        {
            frm_S_SJTHS_EmployeeWorkingCheck frm = new frm_S_SJTHS_EmployeeWorkingCheck();
            frm.Show();
        }

        private void GrvPayrollView_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            // Get the summary ID.  
            int summaryID = Convert.ToInt32((e.Item as GridSummaryItem).Tag);
            int total = 0;

            if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Start)
            {
                total = 0;
            }

            if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
            {
                if (summaryID == 1)
                {
                    if (String.IsNullOrEmpty(Convert.ToString(e.FieldValue)))
                    {
                        total += 1;
                    }
                }
            }

            if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
            {
                e.TotalValue = total;
            }
        }

        private void GrvPayrollView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DataProcess<object> payrollDA = new DataProcess<object>();
            int payrollDetailID = Convert.ToInt32(this.grvPayrollView.GetRowCellValue(e.RowHandle, "PayrollDetailID"));
            int result = -2;

            switch (e.Column.FieldName)
            {
                case "Lunch":
                    {
                        result = payrollDA.ExecuteNoQuery("Update PayRollDetails Set Lunch = {0} Where PayrollDetailID = {1}", Convert.ToInt16(e.Value), payrollDetailID);
                        break;
                    }
                case "Noodles":
                    {
                        result = payrollDA.ExecuteNoQuery("Update PayRollDetails Set Noodles = {0} Where PayrollDetailID = {1}", Convert.ToInt16(e.Value), payrollDetailID);
                        break;
                    }
                case "NightShift":
                    {
                        result = payrollDA.ExecuteNoQuery("Update PayRollDetails Set NightShift = {0} Where PayrollDetailID = {1}", Convert.ToBoolean(e.Value), payrollDetailID);
                        break;
                    }
                case "LunchCompensate":
                    {
                        result = payrollDA.ExecuteNoQuery("Update PayRollDetails Set LunchCompensate = {0} Where PayrollDetailID = {1}", Convert.ToBoolean(e.Value), payrollDetailID);
                        break;
                    }
                case "LunchPlace":
                    {
                        result = payrollDA.ExecuteNoQuery("Update PayRollDetails Set LunchPlace = {0} Where PayrollDetailID = {1}", Convert.ToString(e.Value), payrollDetailID);
                        break;
                    }
                case "PayrollRemark":
                    {
                        result = payrollDA.ExecuteNoQuery("Update PayRollDetails Set PayrollRemark = {0} Where PayrollDetailID = {1}", Convert.ToString(e.Value), payrollDetailID);
                        break;
                    }
                case "SunHol":
                    {
                        //int eID = this._employeeID;
                        //if (eID.ToString().Length==6)
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
                        result = payrollDA.ExecuteNoQuery("Update PayRollDetails Set SunHol = {0} Where PayrollDetailID = {1}", Convert.ToBoolean(e.Value), payrollDetailID);
                        break;
                    }
                case "NightShiftHours":
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
                        result = payrollDA.ExecuteNoQuery("Update PayRollDetails Set NightShiftHours = {0} Where PayrollDetailID = {1}", Convert.ToDouble(e.Value), payrollDetailID);
                        break;
                    }
            }

            if (result != -2)
            {
                string user = Convert.ToString(this.grvPayrollView.GetRowCellValue(e.RowHandle, "User")) + "~" + AppSetting.CurrentUser.LoginName + "-" + DateTime.Now.ToString("dd/MM hh:mm");
                result = payrollDA.ExecuteNoQuery("Update PayRollDetails Set [User] = {0} Where PayrollDetailID = {1}", user, payrollDetailID);
                if (result != -2)
                {
                    this.grvPayrollView.SetRowCellValue(e.RowHandle, "User", user);
                }
            }
            else
            {
                if (this.lkeMonth.EditValue != null)
                {
                    LoadPayrollByMonth();
                }
                else
                {
                    LoadPayroll();
                }
            }
        }

        private void BtnViewProposal_Click(object sender, EventArgs e)
        {
            frm_S_PCO_EmployeeOTNew frm = new frm_S_PCO_EmployeeOTNew();
            frm.Show();
        }

        private void BtnUpdateTime_Click(object sender, EventArgs e)
        {
            if (this.lkeMonth.EditValue == null)
            {
                this.lkeMonth.Focus();
                this.lkeMonth.ShowPopup();
            }
            else
            {
                DataProcess<PayrollMonth> monthDA = new DataProcess<PayrollMonth>();

                DateTime selectedDate = Convert.ToDateTime(this.lkeMonth.GetColumnValue("FromDate"));
                DateTime minDate = (DateTime)monthDA.Select(m => m.PayrollMonthConfirm == false).Min(m => m.FromDate);

                if (selectedDate >= minDate)
                {
                    int result = monthDA.ExecuteNoQuery("STPayrollDetailsUpdateTimeWorkByEmployeeID @varEmployeeID = {0}, @varPayrollDate = {1}", this._employeeID, selectedDate);
                    if (result != -2)
                    {
                        XtraMessageBox.Show("Updated successfully !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadPayrollByMonth();
                    }
                    else
                    {
                        XtraMessageBox.Show("Unexpected Error !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Can not update, data is confirmed !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        #endregion

        #region Load Data
        private void LoadPayroll()
        {
            this._tablePayroll = FileProcess.LoadTable("SELECT PayRollDetails.PayrollDetailID, PayRollDetails.PayrollDate, PayRollDetails.OTS, PayRollDetails.OTN, "
                                                        + " PayRollDetails.Sick, PayRollDetails.Leave, PayRollDetails.[Off], PayRollDetails.PayrollRemark, PayRollDetails.TimeWork, "
                                                        + " PayRollDetails.SunHol, Employees.LastName, Employees.FirstName, Employees.Position, PayRollDetails.Haft, Employees.EmployeeID, "
                                                        + " PayRollDetails.[User], PayRollDetails.Lunch, PayRollDetails.Noodles, PayRollDetails.LunchCompensate, PayRollDetails.OTH,"
                                                        + " PayRollDetails.NightShift, PayRollDetails.NightShiftHours, PayRollDetails.HolidayDay, PayRollDetails.LunchPlace,PayRollDetails.OTNN, PayRollDetails.[OTNN+], PayRollDetails.OTSN, PayRollDetails.OTHN"
                                                        + " FROM Employees INNER JOIN PayRollDetails ON Employees.EmployeeID = PayRollDetails.EmployeeID"
                                                        + " WHERE(((PayRollDetails.PayrollDate) >= GETDATE() - 35 And(PayRollDetails.PayrollDate) <= GETDate() + 7)) AND Employees.EmployeeID = " + this._employeeID
                                                        + " ORDER BY PayRollDetails.PayrollDate");

            this.grdPayrollView.DataSource = this._tablePayroll;
        }

        private void LoadPayrollByMonth()
        {
            this._tablePayroll = FileProcess.LoadTable("SELECT PayRollDetails.PayrollDetailID, PayRollDetails.PayrollDate, PayRollDetails.OTS, PayRollDetails.OTN, "
                                                        + " PayRollDetails.Sick, PayRollDetails.Leave, PayRollDetails.[Off], PayRollDetails.PayrollRemark, PayRollDetails.TimeWork, "
                                                        + " PayRollDetails.SunHol, Employees.LastName, Employees.FirstName, Employees.Position, PayRollDetails.Haft, Employees.EmployeeID, "
                                                        + " PayRollDetails.[User], PayRollDetails.Lunch, PayRollDetails.Noodles, PayRollDetails.LunchCompensate, PayRollDetails.OTH,"
                                                        + " PayRollDetails.NightShift, PayRollDetails.NightShiftHours, PayRollDetails.HolidayDay, PayRollDetails.LunchPlace,PayRollDetails.OTNN, PayRollDetails.[OTNN+], PayRollDetails.OTSN, PayRollDetails.OTHN"
                                                        + " FROM Employees INNER JOIN PayRollDetails ON Employees.EmployeeID = PayRollDetails.EmployeeID"
                                                        + " WHERE Employees.EmployeeID = " + this._employeeID + " AND PayRollDetails.PayrollDate Between '" + Convert.ToDateTime(this.lkeMonth.GetColumnValue("FromDate")).ToString("yyyy-MM-dd") + "' And '" + Convert.ToDateTime(this.lkeMonth.GetColumnValue("ToDate")).ToString("yyyy-MM-dd") + "'"
                                                        + " ORDER BY PayRollDetails.PayrollDate");

            this.grdPayrollView.DataSource = this._tablePayroll;
        }

        private void InitMonth()
        {
            var dataSource = FileProcess.LoadTable("SELECT TOP 36 PayrollMonth.PayRollMonthID, PayrollMonth.PayRollMonth, PayrollMonth.FromDate, PayrollMonth.ToDate FROM PayrollMonth ORDER BY PayrollMonth.PayRollMonthID DESC");
            this.lkeMonth.Properties.DataSource = dataSource;
            this.lkeMonth.Properties.DisplayMember = "PayRollMonth";
            this.lkeMonth.Properties.ValueMember = "PayRollMonthID";
            if (dataSource != null && dataSource.Rows.Count > 0)
            {
                this.lkeMonth.EditValue = dataSource.Rows[0]["PayRollMonthID"];
                LoadPayrollByMonth();
            }
        }

        private void InitPlace()
        {
            DataProcess<LunchPlaces> lunchPlaceDA = new DataProcess<LunchPlaces>();

            this.rpi_lke_LunchPlace.DataSource = lunchPlaceDA.Select();
            this.rpi_lke_LunchPlace.ValueMember = "LunchPlaceID";
            this.rpi_lke_LunchPlace.DisplayMember = "LunchPlaceID";
        }
        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rpi_hpl_EmployeeWorkingChecking_Click(object sender, EventArgs e)
        {
            int employeeID = Convert.ToInt32(this.grvPayrollView.GetFocusedRowCellValue("EmployeeID"));
            string date = Convert.ToDateTime(this.grvPayrollView.GetFocusedRowCellValue("PayrollDate")).ToString("yyyy-MM-dd");
            frm_S_SJTHS_EmployeeWorkingCheck frm = new frm_S_SJTHS_EmployeeWorkingCheck(employeeID, date);
            frm.Show();
        }

        private void rpi_btnEditTimeWork_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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
            if (this.lkeMonth.EditValue == null)
            {
                this.lkeMonth.ShowPopup();
                return;
            }
            int employeeID = Convert.ToInt32(this.grvPayrollView.GetFocusedRowCellValue("EmployeeID"));
            string fromDate = Convert.ToDateTime(this.lkeMonth.GetColumnValue("FromDate")).ToString("yyyy-MM-dd");
            string toDate = Convert.ToDateTime(this.lkeMonth.GetColumnValue("ToDate")).ToString("yyyy-MM-dd");
            frm_S_AO_GateEmployeeInOutAdjust frm = new frm_S_AO_GateEmployeeInOutAdjust(employeeID, fromDate, toDate);
            frm.ShowDialog();
            this.LoadPayrollByMonth();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.currentEmployee.Active)
            {
                MessageBox.Show("Nhan vien nay chua OFF trong WMS!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DataProcess<PayRollDetails> dataProcess = new DataProcess<PayRollDetails>();
            var fromDate = Convert.ToDateTime(this.lkeMonth.GetColumnValue("FromDate"));
            var toDate = Convert.ToDateTime(this.lkeMonth.GetColumnValue("ToDate"));
            var workList = dataProcess.Select(p => p.PayrollDate >= fromDate && p.PayrollDate <= toDate && p.EmployeeID == this._employeeID).ToList();
            if (workList != null && workList.Count > 0)
            {
                int totalWorks = 0;
                foreach (var item in workList)
                {
                    if (!string.IsNullOrEmpty(item.TimeWork)) totalWorks++;
                }
                if (totalWorks > 0)
                {
                    var dl = MessageBox.Show("Nhân viên này có ra vào công ty trong tháng này. Ban co chac chan muon xoa khong ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dl.Equals(DialogResult.No)) return;
                    this.DeleteEmployee();
                    this.LoadPayrollByMonth();
                }
                else
                {
                    var dl = MessageBox.Show("Ban co chac chan muon xoa khong?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dl.Equals(DialogResult.No)) return;
                    this.DeleteEmployee();
                    this.LoadPayrollByMonth();
                }
            }
            else
            {
                var dl = MessageBox.Show("Ban co chac chan muon xoa khong?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dl.Equals(DialogResult.No)) return;
                this.DeleteEmployee();
                this.LoadPayrollByMonth();
            }

        }
        private void DeleteEmployee()
        {
            int payRollMonthlyDetailID = Convert.ToInt32(this.grvPayrollView.GetFocusedRowCellValue(""));
            DataProcess<PayRollDetails> dataProcess = new DataProcess<PayRollDetails>();
            int result = dataProcess.ExecuteNoQuery("STPayrollMonthlyDetailDelete @PayRollMonthlyDetailID={0}",this.payRollMonthlyID);
            MessageBox.Show("Done.", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
