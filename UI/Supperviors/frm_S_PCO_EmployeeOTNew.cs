using Common.Controls;
using DA;
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

namespace UI.Supperviors
{
    public partial class frm_S_PCO_EmployeeOTNew : frmBaseForm
    {
        private SwireDBEntities context = new SwireDBEntities();
        /// <summary>
        /// Shift Name=2,3 => workHourse=8
        /// Shift Name=1   => workHourse=9
        /// </summary>
        private int workHourse = 9;
        private int currentEmployeeID = 0;
        private string workDate = string.Empty;
        public frm_S_PCO_EmployeeOTNew(int employeeID = 0, string workDate = null)
        {
            InitializeComponent();

            // Set param value
            this.currentEmployeeID = employeeID;
            this.workDate = workDate;

            // Init data
            InitDataForEmployeeNameCombobox();
            this.GetWorkHourse();
            InitData();
        }

        public void InitData()
        {
            this.ClearData();
            SetCurrentDate();
            SetDefaultItemsForQtyCombobox();
            InitDataForGrid();
        }

        private void ClearData()
        {
            this.txtEmployeeID.Text = "0";
            this.lkeEmployeeName.EditValue = null;
            this.dtDate.DateTime = DateTime.Now;
            this.chkManyDate.CheckState = CheckState.Unchecked;
            this.dtToDate.DateTime = DateTime.Now;
            this.dTimeIn.EditValue = null;
            this.dTimeOut.EditValue = null;
            this.txtHours.Text = string.Empty;
            this.lkeCheck.EditValue = null;
            this.txtRemark.Text = string.Empty;
            this.txtLeaveDay.Text = string.Empty;
            this.txtOTThisYear.Text = string.Empty;
            this.txtOTThisMonth.Text = string.Empty;
        }

        private void GetWorkHourse()
        {
            var workhourse = FileProcess.LoadTable("select Shifts.WorkingHours from employees "
                                                + " inner join Shifts on Shifts.ShiftID=employees.ShiftID where EmployeeID=" + AppSetting.CurrentUser.EmployeeID);
            if (workhourse != null && workhourse.Rows.Count > 0)
            {
                this.workHourse = Int32.Parse(Convert.ToString(workhourse.Rows[0][0]));
            }
        }

        private void InitDataForGrid()
        {
            // Execute STEmployeeWorkingDetailOverTimes 0,'08 Aug 2017'
            DataProcess<STEmployeeWorkingDetailOverTimes_Result> employeeWorkingDetailOverTimesDataProcess = new DataProcess<STEmployeeWorkingDetailOverTimes_Result>();
            int employeeID = Convert.ToInt32(txtEmployeeID.Text);
            DateTime dateTimeFind = dtDate.DateTime;
            grdJobDetails.DataSource = employeeWorkingDetailOverTimesDataProcess.Executing("STEmployeeWorkingDetailOverTimes @EmployeeID = {0}, @OrderDate = {1}", employeeID, dateTimeFind.ToString("yyyy-MM-dd")).ToList();
            this.grcEmployeePerformanceOne.DataSource = FileProcess.LoadTable("STEmployeeWorkingDailyPerformanceDetails '" + dateTimeFind.ToString("yyyy-MM-dd") + "'," + employeeID);
        }

        private void SetDefaultItemsForQtyCombobox()
        {
            // Set items for lkeCheck
            lkeCheck.Properties.DropDownRows = 12;
            var list = new List<string>();
            list.Add("OTS");
            list.Add("OTSN");
            list.Add("OTN");
            list.Add("OTNN");
            list.Add("OTNN+");
            list.Add("OTH");
            list.Add("OTHN");
            list.Add("H");
            list.Add("S");
            list.Add("L");
            list.Add("O");
            list.Add("XXX");
            list.Add("SL");
            list.Add("C");
            list.Add("IL");
            list.Add("LO");
            list.Add("LWP");
            list.Add("MI");
            list.Add("ML");
            list.Add("PA");
            list.Add("PL");
            list.Add("WRA");
            lkeCheck.Properties.DataSource = list;
        }

        private void SetToDate()
        {

        }

        private void SetCurrentDate()
        {
            dtDate.EditValue = DateTime.Now;
            dtToDate.EditValue = DateTime.Now.AddDays(1);
        }

        private void InitDataForEmployeeNameCombobox()
        {
            lkeEmployeeName.Properties.DataSource = AppSetting.EmployessList.OrderBy(e => e.VietnamName);
        }

        private void chkManyDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkManyDate.Checked == true)
            {
                dtToDate.ReadOnly = false;
                dtToDate.Enabled = true;
                // Set items for lkeCheck
                lkeCheck.Properties.DropDownRows = 12;
                var list = new List<string>();
                list.Add("S");
                list.Add("L");
                list.Add("O");
                list.Add("XXX");
                list.Add("C");
                list.Add("IL");
                list.Add("LO");
                list.Add("LWP");
                list.Add("MI");
                list.Add("ML");
                list.Add("PA");
                list.Add("PL");
                list.Add("WRA");
                lkeCheck.Properties.DataSource = list;
                lkeCheck.EditValue = "S";
                txtHours.Text = "0";
                txtRemark.Text = "Nghi om";
                dtToDate.Focus();
            }
            else
            {
                dtToDate.ReadOnly = true;
                dtToDate.Enabled = false;
                TextDate_AfterUpdate();
            }
        }

        private void TextDate_AfterUpdate()
        {
            OverTimeCalculation();
            this.InitDataForGrid();
        }

        private void OverTimeCalculation()
        {
            dTimeIn.EditValue = null;
            dTimeOut.EditValue = null;
            txtHours.Text = string.Empty;
            this.InitDataForGrid();
            if (txtEmployeeID.Text == null || txtEmployeeID.Text == "")
            {
                return;
            }
            int employeeID = Convert.ToInt32(txtEmployeeID.Text);
            DateTime dateTimeFind = Convert.ToDateTime(dtDate.EditValue);
            int day = dateTimeFind.Day;
            int month = dateTimeFind.Month;
            int year = dateTimeFind.Year;
            var timeSelected = FileProcess.LoadTable("select top 1 TimeIn,TimeOut from Gate_EmployeeInOut where EmployeeID=" + employeeID
                + " and day(TimeIn)=" + day + " and MONTH(TimeIn)=" + month + " and YEAR(TimeIn)=" + year);
            if (timeSelected != null && timeSelected.Rows.Count > 0)
            {
                int isFullTime = 0;
                if (!string.IsNullOrEmpty(timeSelected.Rows[0]["TimeIn"].ToString()))
                {
                    DateTime timeIn = Convert.ToDateTime(timeSelected.Rows[0]["TimeIn"].ToString());
                    dTimeIn.DateTime = timeIn;
                    isFullTime += 1;
                }
                if (!string.IsNullOrEmpty(timeSelected.Rows[0]["TimeOut"].ToString()))
                {
                    DateTime timeOut = Convert.ToDateTime(timeSelected.Rows[0]["TimeOut"].ToString());
                    dTimeOut.DateTime = timeOut;
                    isFullTime += 1;
                }

                if (isFullTime > 1)
                {
                    // calculate time work
                    TimeSpan timeWork = dTimeIn.DateTime.Subtract(dTimeOut.DateTime);
                    txtHours.Text = timeWork.TotalHours.ToString();
                }
            }

            // Find DLast
            if (getLastHolidayFollowConditions(dateTimeFind))
            {
                // Set items for lkeCheck
                lkeCheck.Properties.DropDownRows = 4;
                var list = new List<string>();
                list.Add("OTH");
                list.Add("OTHN");
                list.Add("S");
                list.Add("XXX");
                lkeCheck.Properties.DataSource = list;
                lkeCheck.EditValue = "OTH";
                if (this.dTimeOut.EditValue == null)
                {
                    this.txtHours.Text = string.Empty;
                }
                else
                {
                    txtHours.Text = Math.Round(dTimeOut.DateTime.Subtract(dTimeIn.DateTime).TotalHours, 1).ToString();
                }

                txtRemark.ForeColor = Color.FromArgb(16711680);
                txtRemark.BackColor = Color.FromArgb(8454016);
                txtRemark.Font = new Font(txtRemark.Font, FontStyle.Bold);
            }
            else if (getFirstSunHolOfPayRollDetailsFollowConditions(employeeID, dateTimeFind))
            {
                // Set items for lkeCheck
                lkeCheck.Properties.DropDownRows = 3;
                var list = new List<string>();
                list.Add("OTS");
                list.Add("OTSN");
                list.Add("XXX");
                lkeCheck.Properties.DataSource = list;
                lkeCheck.EditValue = "OTS";
                txtRemark.ForeColor = Color.FromArgb(255);
                txtRemark.BackColor = Color.FromArgb(16777215);
                txtRemark.Font = new Font(txtRemark.Font, FontStyle.Bold);
                if (this.dTimeOut.EditValue == null)
                {
                    this.txtHours.Text = string.Empty;
                }
                else
                {
                    txtHours.Text = Math.Round(dTimeOut.DateTime.Subtract(dTimeIn.DateTime).TotalHours, 1).ToString();
                }
            }
            else
            {
                // Set items for lkeCheck
                lkeCheck.Properties.DropDownRows = 12;
                var list = new List<string>();
                list.Add("OTN");
                list.Add("OTNN");
                list.Add("H");
                list.Add("S");
                list.Add("L");
                list.Add("O");
                list.Add("XXX");
                list.Add("C");
                list.Add("IL");
                list.Add("LO");
                list.Add("LWP");
                list.Add("MI");
                list.Add("ML");
                list.Add("PA");
                list.Add("PL");
                list.Add("WRA");
                lkeCheck.Properties.DataSource = list;
                lkeCheck.EditValue = "OTN";
                txtRemark.ForeColor = Color.FromArgb(0);
                txtRemark.BackColor = Color.FromArgb(16777215);
                txtRemark.Font = new Font(txtRemark.Font, FontStyle.Regular);
                if (this.dTimeOut.EditValue == null)
                {
                    this.txtHours.Text = string.Empty;
                }
                else
                {
                    txtHours.Text = Math.Round(dTimeOut.DateTime.Subtract(dTimeIn.DateTime).TotalHours - this.workHourse, 1).ToString();
                }
            }

            try
            {
                if ((string)lkeCheck.EditValue == "H")
                {
                    txtHours.Text = "0";
                    txtHours.Enabled = false;
                }

                if (lkeCheck.EditValue == "L")
                {
                    txtHours.Text = "0";
                    txtHours.Enabled = false;

                    // Execute STEmployeeOTLeaveRemainDay
                    EmployeeOTLeaveRemainDaytmp dlastEmployeeOTLeaveRemainDaytmp = ExecuteSTEmployeeOTLeaveRemainDay(employeeID);
                    if (dlastEmployeeOTLeaveRemainDaytmp != null)
                    {
                        txtLeaveDay.Text = dlastEmployeeOTLeaveRemainDaytmp.LEA.ToString();
                        txtWorkingYear.Text = dlastEmployeeOTLeaveRemainDaytmp.Workingyear.ToString();

                        //hung 18/05/2019
                        var leaveAllowanceTb =FileProcess.LoadTable("select top 1 LeaveAllowance from tmpPayrollAnnualLeaveAll where EmployeeID=" + employeeID);
                        int leaveAllowance = Convert.ToInt32(leaveAllowanceTb.Rows[0]["LeaveAllowance"].ToString());
                        txtRemainLeave.Text = (leaveAllowance - dlastEmployeeOTLeaveRemainDaytmp.LEA).ToString();

                        //if (dlastEmployeeOTLeaveRemainDaytmp.Workingyear >= 20)
                        //{
                        //    txtRemainLeave.Text = (18 - dlastEmployeeOTLeaveRemainDaytmp.LEA).ToString();
                        //}
                        //else if (dlastEmployeeOTLeaveRemainDaytmp.Workingyear >= 15)
                        //{
                        //    txtRemainLeave.Text = (17 - dlastEmployeeOTLeaveRemainDaytmp.LEA).ToString();
                        //}

                        //else if (dlastEmployeeOTLeaveRemainDaytmp.Workingyear >= 10)
                        //{
                        //    txtRemainLeave.Text = (16 - dlastEmployeeOTLeaveRemainDaytmp.LEA).ToString();
                        //}

                        //else if (dlastEmployeeOTLeaveRemainDaytmp.Workingyear >= 5)
                        //{
                        //    txtRemainLeave.Text = (15 - dlastEmployeeOTLeaveRemainDaytmp.LEA).ToString();
                        //}
                        //else if ((dlastEmployeeOTLeaveRemainDaytmp.Workingyear < 5) && (dlastEmployeeOTLeaveRemainDaytmp.Workingyear >= 1))
                        //{
                        //    txtRemainLeave.Text = (14 - dlastEmployeeOTLeaveRemainDaytmp.LEA).ToString();
                        //}
                        //else
                        //{
                        //    //Xu li them: lay LeaveAllowance tu bang tmpPayrollAnnualLeaveAll
                        //    txtRemainLeave.Text = (leaveAllowance - dlastEmployeeOTLeaveRemainDaytmp.LEA).ToString();
                        //}

                        if (Convert.ToInt32(txtRemainLeave) == 0)
                        {
                            lkeCheck.Focus();
                            // Set items for lkeCheck
                            lkeCheck.Properties.DropDownRows = 12;
                            var list = new List<string>();
                            list.Add("OTS");
                            list.Add("OTN");
                            list.Add("H");
                            list.Add("S");
                            list.Add("L");
                            list.Add("O");
                            list.Add("XXX");
                            list.Add("C");
                            list.Add("IL");
                            list.Add("LO");
                            list.Add("LWP");
                            list.Add("MI");
                            list.Add("ML");
                            list.Add("PA");
                            list.Add("PL");
                            list.Add("WRA");
                            lkeCheck.Properties.DataSource = list;
                            MessageBox.Show("Nhan vien nay da nghi het phep !", "WMS",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (Convert.ToInt32(txtRemainLeave) == 1)
                        {
                            MessageBox.Show("Ngay phep cuoi cua nhan vien nay !", "WMS",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtRemark.Text = "Ngay phep cuoi cung :" + Convert.ToDateTime(txtLeaveDay).AddDays(1).ToString();
                            // Set items for lkeCheck
                            lkeCheck.Properties.DropDownRows = 12;
                            var list = new List<string>();
                            list.Add("OTS");
                            list.Add("OTSN");
                            list.Add("OTN");
                            list.Add("OTNN");
                            list.Add("H");
                            list.Add("S");
                            list.Add("L");
                            list.Add("O");
                            list.Add("XXX");
                            list.Add("C");
                            list.Add("IL");
                            list.Add("LO");
                            list.Add("LWP");
                            list.Add("MI");
                            list.Add("ML");
                            list.Add("PA");
                            list.Add("PL");
                            list.Add("WRA");
                            lkeCheck.Properties.DataSource = list;
                        }
                    }
                }

                if (lkeCheck.EditValue == "O")
                {
                    txtHours.Text = "0";
                    txtHours.Enabled = false;
                }

                if (lkeCheck.EditValue == "S")
                {
                    txtHours.Text = "0";
                    txtHours.Enabled = false;
                }

                if (lkeCheck.EditValue == "OTN" || lkeCheck.EditValue =="OTNN")
                {
                    txtHours.Enabled = true;
                }

                if (lkeCheck.EditValue == "XXX")
                {
                    txtHours.Text = "0";
                    txtRemark.Focus();
                }
            }
            catch
            {

            }
        }

        private static bool getLastHolidayFollowConditions(DateTime dateFind)
        {
            var holidayFound = FileProcess.LoadTable("select top 1 holidayDate from HolidayDate " +
                " where Day(holidayDate)=" + dateFind.Day + " and MONTH(HolidayDate)=" + dateFind.Month + " and Year(HolidayDate)=" + dateFind.Year + " order by holidayDate DESC");
            if (holidayFound != null && holidayFound.Rows.Count > 0) return true;
            return false;
        }

        private EmployeeOTLeaveRemainDaytmp ExecuteSTEmployeeOTLeaveRemainDay(int ID)
        {
            int result = context.STEmployeeOTLeaveRemainDay(ID, this.dtDate.DateTime, this.dtDate.DateTime);
            DataProcess<EmployeeOTLeaveRemainDaytmp> employeeOTLeaveRemainDaytmpDA = new DataProcess<EmployeeOTLeaveRemainDaytmp>();
            EmployeeOTLeaveRemainDaytmp dlastEmployeeOTLeaveRemainDaytmp = employeeOTLeaveRemainDaytmpDA.Select(e => e.EmployeeID == ID).FirstOrDefault();
            return dlastEmployeeOTLeaveRemainDaytmp;
        }

        private bool getFirstSunHolOfPayRollDetailsFollowConditions(int employeeID, DateTime findDate)
        {
            var payrollMonth = FileProcess.LoadTable("select top 1 SunHol from PayRollDetails where EmployeeID=" + employeeID
                + " and Day(PayrollDate)=" + findDate.Day + " and Month(PayrollDate)=" + findDate.Month + " and Year(PayrollDate)=" + findDate.Year);
            if (payrollMonth != null && payrollMonth.Rows.Count > 0)
            {
                int value = Convert.ToInt32(payrollMonth.Rows[0][0]);
                if (value == 1)
                    return true;
            }
            return false;
        }

        private int getDayOfWeek(DateTime check)
        {
            check = new DateTime(2017, 8, 20);
            // VBA-Sunday returns 1 but C#-Sunday returns 0
            return (int)check.DayOfWeek + 1;
        }

        private bool ValidateEmployeeID(string checkString)
        {
            bool valid = false;
            // Check String
            int value;
            valid = int.TryParse(checkString, out value);
            if (valid)
            {
                Employees found = AppSetting.EmployessList.Where(e => e.EmployeeID == value).FirstOrDefault();
                if (found != null)
                {
                    return valid;
                }
                return !valid;
            }
            return valid;
        }

        private void lkeEmployeeName_EditValueChanged(object sender, EventArgs e)
        {
            if (this.lkeEmployeeName.EditValue == null) return;
            txtEmployeeID.Text = lkeEmployeeName.EditValue.ToString();

            int currentYear =Int32.Parse(DateTime.Now.Year.ToString());
            int currentMonth = Int32.Parse(DateTime.Now.Month.ToString());

            string sql = "STCheckOTHourByEmployeeByMonth @d= '"+ DateTime.Now.Date.ToString("yyyy-MM-dd") + "'" +
                " ,@e=" + lkeEmployeeName.EditValue.ToString() + ", @OT='OT', @y = "+currentYear+", @m = "+ currentMonth;
            var dts = FileProcess.LoadTable(sql);
            int hy = Convert.ToInt32(dts.Rows[0]["TotalHourYear"]);
            int hm = Convert.ToInt32(dts.Rows[0]["TotalHourMonth"]);

            if(hm > 40)
            {
                txtOTThisMonth.BackColor = Color.Red;
            }
            else
            {
                txtOTThisMonth.BackColor = Color.Gray;
            }
            if(hy > 300)
            {
                txtOTThisYear.BackColor = Color.Red;
            }
            else
            {
                txtOTThisYear.BackColor = Color.Gray;
            }
            txtOTThisMonth.Text = hm.ToString();
            txtOTThisYear.Text = hy.ToString();
        }

        private void lkeCheck_EditValueChanged(object sender, EventArgs e)
        {
            // Set data in controls into variables
            int employeeID = Convert.ToInt32(txtEmployeeID.Text);
            DateTime toDate = Convert.ToDateTime(dtToDate.EditValue);
            DateTime currentDate = Convert.ToDateTime(dtDate.EditValue);
            int day = currentDate.Day;
            int month = currentDate.Month;
            int year = currentDate.Year;

            if (txtEmployeeID.Text == null || txtEmployeeID.Text == "")
            {
                txtEmployeeID.Focus();
                return;
            }

            try
            {
                if (lkeCheck.EditValue == "H")
                {
                    if (getFirstSunHolOfPayRollDetailsFollowConditions(employeeID, currentDate))
                    {
                        MessageBox.Show("Cham bu Chu nhat hoac Le !", "Cham cong nhan vien",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lkeCheck.EditValue = "OTS";
                        return;
                    }
                    else
                    {
                        txtRemark.Text = "Nghi nua ngay";
                        txtHours.Text = "0";
                        txtHours.Enabled = false;
                    }
                    chkManyDate.Checked = false;
                    dtToDate.Enabled = false;
                }

                if (lkeCheck.EditValue == "L")
                {
                    txtHours.Text = "0";
                    txtHours.Enabled = false;
                    if (getFirstSunHolOfPayRollDetailsFollowConditions(employeeID, currentDate))
                    {
                        MessageBox.Show("Cham bu Chu nhat hoac Le !", "Cham cong nhan vien",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lkeCheck.EditValue = "OTS";
                        return;
                    }
                    else
                    {
                        txtRemark.Text = "Nghi phep";
                        // Execute store STEmployeeOTLeaveRemainDay
                        EmployeeOTLeaveRemainDaytmp dlastEmployeeOTLeaveRemainDaytmp = ExecuteSTEmployeeOTLeaveRemainDay(employeeID);
                        if (dlastEmployeeOTLeaveRemainDaytmp != null)
                        {
                            txtLeaveDay.Text = dlastEmployeeOTLeaveRemainDaytmp.LEA.ToString();
                            txtWorkingYear.Text = dlastEmployeeOTLeaveRemainDaytmp.Workingyear.ToString();

                            txtLeaveDay1.Text = dlastEmployeeOTLeaveRemainDaytmp.LEA.ToString();
                            txtWorkingYear1.Text = dlastEmployeeOTLeaveRemainDaytmp.Workingyear.ToString();

                            var leaveAllowanceTb = FileProcess.LoadTable("select top 1 LeaveAllowance from tmpPayrollAnnualLeaveAll where EmployeeID=" + employeeID);
                            int leaveAllowance = Convert.ToInt32(leaveAllowanceTb.Rows[0]["LeaveAllowance"].ToString());
                            txtRemainLeave.Text = (leaveAllowance - dlastEmployeeOTLeaveRemainDaytmp.LEA).ToString();


                            //if (dlastEmployeeOTLeaveRemainDaytmp.Workingyear < 5)
                            //{
                            //    txtRemainLeave.Text = (14 - dlastEmployeeOTLeaveRemainDaytmp.LEA).ToString();
                            //}
                            //else if (dlastEmployeeOTLeaveRemainDaytmp.Workingyear >= 5 && dlastEmployeeOTLeaveRemainDaytmp.Workingyear < 10)
                            //{
                            //    txtRemainLeave.Text = (15 - dlastEmployeeOTLeaveRemainDaytmp.LEA).ToString();
                            //}
                            //else if (dlastEmployeeOTLeaveRemainDaytmp.Workingyear >= 10)
                            //{
                            //    txtRemainLeave.Text = (16 - dlastEmployeeOTLeaveRemainDaytmp.LEA).ToString();
                            //}
                            //else if (dlastEmployeeOTLeaveRemainDaytmp.Workingyear >= 15)
                            //{
                            //    txtRemainLeave.Text = (17 - dlastEmployeeOTLeaveRemainDaytmp.LEA).ToString();
                            //}
                            //else if (dlastEmployeeOTLeaveRemainDaytmp.Workingyear >= 20)
                            //{
                            //    txtRemainLeave.Text = (18 - dlastEmployeeOTLeaveRemainDaytmp.LEA).ToString();
                            //}
                            //else if (dlastEmployeeOTLeaveRemainDaytmp.Workingyear >= 25)
                            //{
                            //    txtRemainLeave.Text = (19 - dlastEmployeeOTLeaveRemainDaytmp.LEA).ToString();
                            //}

                            if (Convert.ToInt32(txtRemainLeave.Text) == 0)
                            {
                                lkeCheck.Focus();
                                // Set items for lkeCheck
                                lkeCheck.Properties.DropDownRows = 12;
                                var list = new List<string>();
                                list.Add("OTS");
                                list.Add("OTN");
                                list.Add("H");
                                list.Add("S");
                                list.Add("L");
                                list.Add("O");
                                list.Add("XXX");
                                list.Add("C");
                                list.Add("IL");
                                list.Add("LO");
                                list.Add("LWP");
                                list.Add("MI");
                                list.Add("ML");
                                list.Add("PA");
                                list.Add("PL");
                                list.Add("WRA");
                                lkeCheck.Properties.DataSource = list;
                                MessageBox.Show("Nhan vien nay da nghi het phep !", "WMS",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else if (Convert.ToInt32(txtRemainLeave.Text) == 1)
                            {
                                MessageBox.Show("Ngay phep cuoi cua nhan vien nay !", "WMS",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtRemark.Text = "Ngay phep cuoi :" + Convert.ToDateTime(txtLeaveDay.Text).AddDays(1);
                                // Set items for lkeCheck
                                lkeCheck.Properties.DropDownRows = 12;
                                var list = new List<string>();
                                list.Add("OTS");
                                list.Add("OTN");
                                list.Add("H");
                                list.Add("S");
                                list.Add("L");
                                list.Add("O");
                                list.Add("XXX");
                                list.Add("C");
                                list.Add("IL");
                                list.Add("LO");
                                list.Add("LWP");
                                list.Add("MI");
                                list.Add("ML");
                                list.Add("PA");
                                list.Add("PL");
                                list.Add("WRA");
                                lkeCheck.Properties.DataSource = list;
                            }
                        }
                    }
                }

                if (lkeCheck.EditValue == "O")
                {
                    if (getFirstSunHolOfPayRollDetailsFollowConditions(employeeID, currentDate))
                    {
                        MessageBox.Show("Cham bu Chu nhat hoac Le !", "Cham cong nhan vien",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lkeCheck.EditValue = "OTS";
                        return;
                    }
                    else
                    {
                        txtRemark.Text = "Nghi khong luong";
                        txtHours.Text = "0";
                        txtHours.Enabled = false;
                    }
                }

                if (lkeCheck.EditValue == "S")
                {
                    if (getFirstSunHolOfPayRollDetailsFollowConditions(employeeID, currentDate))
                    {
                        MessageBox.Show("Cham bu Chu nhat hoac Le !", "Cham cong nhan vien",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lkeCheck.EditValue = "OTS";
                        return;
                    }
                    else
                    {
                        txtRemark.Text = "Nghi om";
                        txtHours.Text = "0";
                        txtHours.Enabled = false;
                    }
                }

                if (lkeCheck.EditValue == "OTN" || lkeCheck.EditValue == "OTNN")
                {
                    chkManyDate.Checked = false;
                    dtToDate.Enabled = false;
                    if (getFirstSunHolOfPayRollDetailsFollowConditions(employeeID, currentDate))
                    {
                        MessageBox.Show("Cham bu Chu nhat hoac Le !", "Cham cong nhan vien",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lkeCheck.EditValue = "OTS";
                        return;
                    }
                    else
                    {
                        txtRemark.Text = "";
                        txtHours.Text = "0";
                        txtHours.Enabled = true;
                    }
                }

                if (lkeCheck.EditValue == "OTS")
                {
                    chkManyDate.Checked = false;
                    dtToDate.Enabled = false;
                    if (getFirstSunHolOfPayRollDetailsFollowConditions(employeeID, currentDate))
                    {
                        txtRemark.Text = "";
                    }
                    else
                    {
                        if (getDayOfWeek(currentDate) != 1)
                        {
                            MessageBox.Show("Ngay " + dtDate.Text + " khong phai la ngay Chu nhat!", "Cham cong nhan vien",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                            lkeCheck.EditValue = "";
                            lkeCheck.Focus();
                            lkeCheck.ShowPopup();
                            txtRemark.Text = "";
                            return;
                        }
                        else
                        {
                            txtHours.Text = "0";
                            txtHours.Enabled = true;
                        }
                    }
                }

                if (lkeCheck.EditValue == "OTH")
                {
                    chkManyDate.Checked = false;
                    dtToDate.Enabled = false;
                    if (!getLastHolidayFollowConditions(currentDate))
                    {
                        MessageBox.Show("Ngay " + currentDate + " khong phai la ngay Le!", "Cham cong nhan vien",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lkeCheck.EditValue = "";
                        lkeCheck.ShowPopup();
                        return;
                    }
                    else
                    {
                        txtRemark.Text = "";
                        txtHours.Enabled = true;
                    }
                }

                if (lkeCheck.EditValue == "XXX")
                {
                    txtHours.Text = "0";
                    txtRemark.Focus();
                }
            }
            catch
            {

            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtEmployeeID.Text == "0" || txtEmployeeID.Text == "")
            {
                return;
            }

            // Set data in controls into variables
            int employeeID = Convert.ToInt32(txtEmployeeID.Text);
            DateTime toDate = Convert.ToDateTime(dtToDate.EditValue);
            DateTime currentDate = Convert.ToDateTime(dtDate.EditValue);
            int day = currentDate.Day;
            int month = currentDate.Month;
            int year = currentDate.Year;

            DataProcess<EmployeeOTSupervisors> employeeOTSupervisorsDataProcess = new DataProcess<EmployeeOTSupervisors>();
            int varCount = employeeOTSupervisorsDataProcess.Select(em => em.EmployeeID == employeeID && em.EmployeeOTSupervisorDate.Day == day && em.EmployeeOTSupervisorDate.Month == month && em.EmployeeOTSupervisorDate.Year == year).ToList().Count;
            if (varCount >= 2)
            {
                MessageBox.Show("Khong duoc cham 3 lan cho 1 ngay !", "WMS-2015",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.dTimeOut.EditValue != null)
            {
                DateTime endOTN = this.dTimeOut.DateTime.Date.AddHours(22.5);
                DateTime endOTNN = this.dTimeOut.DateTime.Date.AddHours(6);
                if (this.dTimeOut.DateTime.Ticks >= endOTN.Ticks || this.dTimeOut.DateTime.Ticks <= endOTNN.Ticks)
                {
                    if (lkeCheck.EditValue != "OTNN" && lkeCheck.EditValue != "OTSN" && lkeCheck.EditValue != "OTHN")
                    {
                        MessageBox.Show("De nghi xem xet cham ngoai gio ca dem!", "WMS-2015",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

            if (lkeCheck.EditValue == "OTS")
            {
                if (getFirstSunHolOfPayRollDetailsFollowConditions(employeeID, currentDate))
                {
                    
                }
                else
                {
                    MessageBox.Show("Ban da cham khong hop le! Ngay " + currentDate + " khong phai Chu nhat!", "Cham cong nhan vien",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lkeCheck.Focus();
                    lkeCheck.ShowPopup();
                    return;
                    //if (getDayOfWeek(currentDate) != 1)
                    //{
                    //    MessageBox.Show("Ban da cham khong hop le! Ngay " + currentDate + " khong phai Chu nhat!", "Cham cong nhan vien",
                    //    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    lkeCheck.Focus();
                    //    lkeCheck.ShowPopup();
                    //    return;
                    //}
                }
            }

            if (getFirstSunHolOfPayRollDetailsFollowConditions(employeeID, currentDate))
            {
                if (lkeCheck.EditValue != "OTS" && lkeCheck.EditValue != "OTSN" && lkeCheck.EditValue != "OTH" && lkeCheck.EditValue != "OTHN" && lkeCheck.EditValue != "XXX")
                {
                    MessageBox.Show("Cham bu Chu nhat!", "Cham cong nhan vien",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lkeCheck.EditValue = "OTS";
                    return;
                }
            }

            if (txtEmployeeID.Text == null || txtEmployeeID.Text == "0")
            {
                MessageBox.Show("Vui long nhap EmployeeID !", "WMS",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmployeeID.Focus();
            }

            if (lkeCheck.EditValue == "OTN" || lkeCheck.EditValue == "OTS" || lkeCheck.EditValue == "OTH" || lkeCheck.EditValue == "OTNN" || lkeCheck.EditValue == "OTSN" || lkeCheck.EditValue == "OTHN" || lkeCheck.EditValue == "XXX" || lkeCheck.EditValue == "O")
            {
                if (txtRemark.Text == "" || txtRemark.Text == null)
                {
                    MessageBox.Show("Vui long nhap ghi chu !", "Cham cong nhan vien",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtRemark.Focus();
                    return;
                }
            }

            string varDayStatus = string.Empty;
            var getLeaveDate = FileProcess.LoadTable("select TOP 1 [DayStatus] from EmployeeOTSupervisors "
                                                + " where employeeid=" + Convert.ToInt32(this.txtEmployeeID.Text) + " and EmployeeOTSupervisorDate='" + this.dtDate.DateTime.ToString("yyyy-MM-dd")
                                                + "' order by [EmployeeOTSupervisorID] DESC");
            if (getLeaveDate != null && getLeaveDate.Rows.Count > 0)
            {
                varDayStatus = Convert.ToString(getLeaveDate.Rows[0][0]).Trim();
            }

            if (varDayStatus == "S" || varDayStatus == "L" || varDayStatus == "O" || varDayStatus == "H" || varDayStatus == "XXX")
            {
                MessageBox.Show("Nhan vien nay da nhap " + varDayStatus + " roi ! ", "WMS-2022",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmployeeID.Focus();
                return;
            }
            else if (varDayStatus == "OTN" && (lkeCheck.EditValue == "OTN" || lkeCheck.EditValue == "OTS" || lkeCheck.EditValue == "OTSN" || lkeCheck.EditValue == "OTH" || lkeCheck.EditValue == "OTHN" || lkeCheck.EditValue == "S" || lkeCheck.EditValue == "L" || lkeCheck.EditValue == "O" || lkeCheck.EditValue == "H" || lkeCheck.EditValue == "XXX"))
            {
                MessageBox.Show("Nhan vien nay da nhap OTN roi ! ", "WMS-2022",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmployeeID.Focus();
                return;
            }
            else if (varDayStatus == "OTS" && (lkeCheck.EditValue == "OTS" || lkeCheck.EditValue == "OTN" || lkeCheck.EditValue == "OTNN" || lkeCheck.EditValue == "OTH" || lkeCheck.EditValue == "OTHN" || lkeCheck.EditValue == "S" || lkeCheck.EditValue == "L" || lkeCheck.EditValue == "O" || lkeCheck.EditValue == "H" || lkeCheck.EditValue == "XXX"))
            {
                MessageBox.Show("Nhan vien nay da nhap OTS roi ! ", "WMS-2022",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmployeeID.Focus();
                return;
            }
            else if (varDayStatus == "OTH" && (lkeCheck.EditValue == "OTH" || lkeCheck.EditValue == "OTN" || lkeCheck.EditValue == "OTNN" || lkeCheck.EditValue == "OTS" || lkeCheck.EditValue == "OTSN" || lkeCheck.EditValue == "S" || lkeCheck.EditValue == "L" || lkeCheck.EditValue == "O" || lkeCheck.EditValue == "H" || lkeCheck.EditValue == "XXX"))
            {
                MessageBox.Show("Nhan vien nay da nhap OTH roi ! ", "WMS-2022",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmployeeID.Focus();
                return;
            }
            else if (varDayStatus == "OTNN" && (lkeCheck.EditValue == "OTNN" || lkeCheck.EditValue == "OTH" || lkeCheck.EditValue == "OTHN" || lkeCheck.EditValue == "OTS" || lkeCheck.EditValue == "OTSN" || lkeCheck.EditValue == "S" || lkeCheck.EditValue == "L" || lkeCheck.EditValue == "O" || lkeCheck.EditValue == "H" || lkeCheck.EditValue == "XXX"))
            {
                MessageBox.Show("Nhan vien nay da nhap OTNN roi ! ", "WMS-2022",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmployeeID.Focus();
                return;
            }
            else if (varDayStatus == "OTSN" && (lkeCheck.EditValue == "OTSN" || lkeCheck.EditValue == "OTN" || lkeCheck.EditValue == "OTNN" || lkeCheck.EditValue == "OTH" || lkeCheck.EditValue == "OTHN" || lkeCheck.EditValue == "S" || lkeCheck.EditValue == "L" || lkeCheck.EditValue == "O" || lkeCheck.EditValue == "H" || lkeCheck.EditValue == "XXX"))
            {
                MessageBox.Show("Nhan vien nay da nhap OTSN roi ! ", "WMS-2022",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmployeeID.Focus();
                return;
            }
            else if (varDayStatus == "OTHN" && (lkeCheck.EditValue == "OTHN" || lkeCheck.EditValue == "OTS" || lkeCheck.EditValue == "OTSN" || lkeCheck.EditValue == "OTN" || lkeCheck.EditValue == "OTNN" || lkeCheck.EditValue == "S" || lkeCheck.EditValue == "L" || lkeCheck.EditValue == "O" || lkeCheck.EditValue == "H" || lkeCheck.EditValue == "XXX"))
            {
                MessageBox.Show("Nhan vien nay da nhap OTHN roi ! ", "WMS-2022",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmployeeID.Focus();
                return;
            }
            else
            {
                if (varDayStatus == "OTN" && lkeCheck.EditValue == "OTNN")
                {
                    lkeCheck.EditValue = "OTNN+";
                }

                if (txtEmployeeID.Text == null || txtEmployeeID.Text == "0" || dtDate.EditValue == "" || lkeCheck.EditValue == "")
                {
                    MessageBox.Show("Vui long nhap du thong tin !", "WMS-2022",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEmployeeID.Focus();
                }
                else
                {

                    if (string.IsNullOrEmpty(txtHours.Text))
                    {
                        MessageBox.Show("Vui long nhap so gio!", "Khong co gio!",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else if (Convert.ToDecimal(txtHours.Text) < 0)
                    {
                        MessageBox.Show("Ban khong duoc phep cham so am!", "Loi cham gio am!",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        string author = AppSetting.CurrentUser.LoginName + "-" + DateTime.Now.ToString("dd/MM HH:mm");
                        if (txtHours.Text.Length > 4)
                        {
                            MessageBox.Show("Ban phai nhap lai so gio, so gio khong duoc nhieu hon 1 so thap phan!", "Cham cong",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (txtHours.Text.Length > 1)
                            {
                                if (Convert.ToDecimal(txtHours.Text) >= 10 && txtHours.Text.Length == 2)
                                {

                                    var dtm = FileProcess.LoadTable("STCheckOTHourByEmployeeByMonth @d='" + Convert.ToDateTime(dtDate.EditValue).ToString("yyyy-MM-dd") + "',@e=" + txtEmployeeID.Text + ", @OT='" + lkeCheck.EditValue + "'");
                                    var h = Convert.ToInt32(dtm.Rows[0]["TotalHour"]);
                                    if (h + Convert.ToDecimal(txtHours.Text) > 40)
                                    {
                                        var confirm = MessageBox.Show("Tong so gio OT nhan vien nay trong thang > 40! [" + h + " + " + Convert.ToDecimal(txtHours.Text) + "], tiep tuc?", "Cham cong",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                        if (confirm.Equals(DialogResult.No)) return;
                                    }
                                    var hy = Convert.ToInt32(dtm.Rows[0]["TotalHourYear"]);
                                    if (hy + Convert.ToDecimal(txtHours.Text) > 300)
                                    {
                                        var confirm = MessageBox.Show("Tong so gio OT nhan vien nay trong nam > 300! [" + h + " + " + Convert.ToDecimal(txtHours.Text) + "], tiep tuc?", "Cham cong",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                        if (confirm.Equals(DialogResult.No)) return;
                                    }


                                    var dtd = FileProcess.LoadTable("STCheckOTHourByEmployeeByDay @d='" + Convert.ToDateTime(dtDate.EditValue).ToString("yyyy-MM-dd") + "',@e=" + txtEmployeeID.Text + ", @OT='" + lkeCheck.EditValue + "'");
                                    var hd = Convert.ToInt32(dtd.Rows[0]["TotalHour"]);
                                    if (hd + Convert.ToDecimal(txtHours.Text) > 4)
                                    {
                                        var confirmd = MessageBox.Show("Tong so gio OT nhan vien nay trong ngay > 4! [" + hd + " + " + Convert.ToDecimal(txtHours.Text) + "], tiep tuc?", "Cham cong",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                        if (confirmd.Equals(DialogResult.No)) return;
                                    }


                                    // Execute store STEmployeeOTSupervisorsInsert
                                    context.STEmployeeOTSupervisorsInsert(employeeID, currentDate, toDate, (float)Convert.ToDecimal(txtHours.Text), lkeCheck.EditValue.ToString(), author, txtRemark.Text, chkManyDate.Checked);
                                    // FIXME
                                    // Form_frmEmployeeOTSupervisors.Requery
                                    txtHours.Text = "";
                                    lkeCheck.EditValue = "";
                                    txtEmployeeID.Focus();
                                }
                                else if (Convert.ToDecimal(txtHours.Text) >= 10 && txtHours.Text.Length >= 4)
                                {
                                    if (Convert.ToDecimal(txtHours.Text.Substring(txtHours.Text.Length - 1)) == 0 || Convert.ToDecimal(txtHours.Text.Substring(txtHours.Text.Length - 1)) == 5)
                                    {

                                        var dtm = FileProcess.LoadTable("STCheckOTHourByEmployeeByMonth @d='" + Convert.ToDateTime(dtDate.EditValue).ToString("yyyy-MM-dd") + "',@e=" + txtEmployeeID.Text + ", @OT='" + lkeCheck.EditValue + "'");
                                        var h = Convert.ToInt32(dtm.Rows[0]["TotalHour"]);
                                        if (h + Convert.ToDecimal(txtHours.Text) > 40)
                                        {
                                            var confirm = MessageBox.Show("Tong so gio OT nhan vien nay trong thang > 40! [" + h + " + " + Convert.ToDecimal(txtHours.Text) + "], tiep tuc?", "Cham cong",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                            if (confirm.Equals(DialogResult.No)) return;
                                        }

                                        var hy = Convert.ToInt32(dtm.Rows[0]["TotalHourYear"]);
                                        if (hy + Convert.ToDecimal(txtHours.Text) > 300)
                                        {
                                            var confirm = MessageBox.Show("Tong so gio OT nhan vien nay trong nam > 300! [" + h + " + " + Convert.ToDecimal(txtHours.Text) + "], tiep tuc?", "Cham cong",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                            if (confirm.Equals(DialogResult.No)) return;
                                        }

                                        var dtd = FileProcess.LoadTable("STCheckOTHourByEmployeeByDay @d='" + Convert.ToDateTime(dtDate.EditValue).ToString("yyyy-MM-dd") + "',@e=" + txtEmployeeID.Text + ", @OT='" + lkeCheck.EditValue + "'");
                                        var hd = Convert.ToInt32(dtd.Rows[0]["TotalHour"]);
                                        if (hd + Convert.ToDecimal(txtHours.Text) > 4)
                                        {
                                            var confirmd = MessageBox.Show("Tong so gio OT nhan vien nay trong ngay > 4! [" + hd + " + " + Convert.ToDecimal(txtHours.Text) + "], tiep tuc?", "Cham cong",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                            if (confirmd.Equals(DialogResult.No)) return;
                                        }
                                        // Execute store STEmployeeOTSupervisorsInsert
                                        context.STEmployeeOTSupervisorsInsert(employeeID, currentDate, toDate, (float)Convert.ToDecimal(txtHours.Text), lkeCheck.EditValue.ToString(), author, txtRemark.Text, chkManyDate.Checked);
                                        // FIXME
                                        // Form_frmEmployeeOTSupervisors.Requery
                                        txtHours.Text = "";
                                        lkeCheck.EditValue = "";
                                        txtEmployeeID.Focus();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Ban da cham gio khong hop le, khong duoc cham so le!", "Loi cham gio le!",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        txtHours.Focus();
                                        return;
                                    }
                                }
                                else
                                {
                                    if (Convert.ToDecimal(txtHours.Text.Substring(txtHours.Text.Length - 1)) == 0 || Convert.ToDecimal(txtHours.Text.Substring(txtHours.Text.Length - 1)) == 5)
                                    {
                                        var dtm = FileProcess.LoadTable("STCheckOTHourByEmployeeByMonth @d='" + Convert.ToDateTime(dtDate.EditValue).ToString("yyyy-MM-dd") + "',@e=" + txtEmployeeID.Text + ", @OT='" + lkeCheck.EditValue + "'");
                                        var h = Convert.ToInt32(dtm.Rows[0]["TotalHour"]);
                                        if (h + Convert.ToDecimal(txtHours.Text) > 40)
                                        {
                                            var confirm = MessageBox.Show("Tong so gio OT nhan vien nay trong thang > 40! [" + h + " + " + Convert.ToDecimal(txtHours.Text) + "], tiep tuc?", "Cham cong",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                            if (confirm.Equals(DialogResult.No)) return;
                                        }

                                        var hy = Convert.ToInt32(dtm.Rows[0]["TotalHourYear"]);
                                        if (hy + Convert.ToDecimal(txtHours.Text) > 300)
                                        {
                                            var confirm = MessageBox.Show("Tong so gio OT nhan vien nay trong nam > 300! [" + h + " + " + Convert.ToDecimal(txtHours.Text) + "], tiep tuc?", "Cham cong",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                            if (confirm.Equals(DialogResult.No)) return;
                                        }

                                        var dtd = FileProcess.LoadTable("STCheckOTHourByEmployeeByDay @d='" + Convert.ToDateTime(dtDate.EditValue).ToString("yyyy-MM-dd") + "',@e=" + txtEmployeeID.Text + ", @OT='" + lkeCheck.EditValue + "'");
                                        var hd = Convert.ToInt32(dtd.Rows[0]["TotalHour"]);
                                        if (hd + Convert.ToDecimal(txtHours.Text) > 4)
                                        {
                                            var confirmd = MessageBox.Show("Tong so gio OT nhan vien nay trong ngay > 4! [" + hd + " + " + Convert.ToDecimal(txtHours.Text) + "], tiep tuc?", "Cham cong",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                            if (confirmd.Equals(DialogResult.No)) return;
                                        }
                                        // Execute store STEmployeeOTSupervisorsInsert
                                        context.STEmployeeOTSupervisorsInsert(employeeID, currentDate, toDate, (float)Convert.ToDecimal(txtHours.Text), lkeCheck.EditValue.ToString(), author, txtRemark.Text, chkManyDate.Checked);
                                        // FIXME
                                        // Form_frmEmployeeOTSupervisors.Requery
                                        txtHours.Text = "";
                                        lkeCheck.EditValue = "";
                                        txtEmployeeID.Focus();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Ban da cham gio khong hop le, khong duoc cham so le!", "Loi cham gio le!",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        txtHours.Focus();
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                //var confirm = MessageBox.Show("Has [" + hasExist + "] accounts of this customer is not yet billing,\nDo you want to create report for this billing?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                //if (confirm.Equals(DialogResult.No)) return;

                                var dtm = FileProcess.LoadTable("STCheckOTHourByEmployeeByMonth @d='" + Convert.ToDateTime(dtDate.EditValue).ToString("yyyy-MM-dd") + "',@e=" + txtEmployeeID.Text + ", @OT='" + lkeCheck.EditValue+"'");
                                var h = Convert.ToInt32(dtm.Rows[0]["TotalHour"]);
                                if (h + Convert.ToDecimal(txtHours.Text) > 40)
                                {
                                    var confirm = MessageBox.Show("Tong so gio OT nhan vien nay trong thang > 40! [" + h + " + " + Convert.ToDecimal(txtHours.Text) + "], tiep tuc?", "Cham cong",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                    if (confirm.Equals(DialogResult.No)) return;
                                }

                                var hy = Convert.ToInt32(dtm.Rows[0]["TotalHourYear"]);
                                if (hy + Convert.ToDecimal(txtHours.Text) > 300)
                                {
                                    var confirm = MessageBox.Show("Tong so gio OT nhan vien nay trong nam > 300! [" + h + " + " + Convert.ToDecimal(txtHours.Text) + "], tiep tuc?", "Cham cong",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                    if (confirm.Equals(DialogResult.No)) return;
                                }

                                var dtd = FileProcess.LoadTable("STCheckOTHourByEmployeeByDay @d='" + Convert.ToDateTime(dtDate.EditValue).ToString("yyyy-MM-dd") + "',@e=" + txtEmployeeID.Text + ", @OT='" + lkeCheck.EditValue + "'");
                                var hd = Convert.ToInt32(dtd.Rows[0]["TotalHour"]);
                                if (hd + Convert.ToDecimal(txtHours.Text) > 4)
                                {
                                    var confirmd = MessageBox.Show("Tong so gio OT nhan vien nay trong ngay > 4! [" + hd + " + " + Convert.ToDecimal(txtHours.Text)+ "], tiep tuc?", "Cham cong",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                    if (confirmd.Equals(DialogResult.No)) return;
                                }
                                // Execute store STEmployeeOTSupervisorsInsert
                                context.STEmployeeOTSupervisorsInsert(employeeID, currentDate, toDate, (float)Convert.ToDouble(txtHours.Text), lkeCheck.EditValue.ToString(), author, txtRemark.Text, chkManyDate.Checked);
                                // FIXME
                                // Form_frmEmployeeOTSupervisors.Requery
                                txtHours.Text = "";
                                lkeCheck.EditValue = "";
                                txtEmployeeID.Focus();
                            }
                        }
                    }
                }
            }
            
            }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtEmployeeID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (txtEmployeeID.Text == null || txtEmployeeID.Text == "")
                {
                    txtEmployeeID.Focus();
                    return;
                }
                // Validate EmployeeID
                if (ValidateEmployeeID(txtEmployeeID.Text))
                {
                    lkeEmployeeName.EditValue = Convert.ToInt32(txtEmployeeID.Text);
                }
                else
                {
                    MessageBox.Show("Please enter correct Employee ID!", "WMS-2022",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (dtToDate.EditValue == null)
                {
                    dtDate.EditValue = DateTime.Now;
                }

                OverTimeCalculation();

                if (lkeEmployeeName.EditValue == null)
                {
                    lkeEmployeeName.Focus();
                    return;
                }
                else
                {
                    this.dtDate.Focus();
                }
            }
        }

        private void dtDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                OverTimeCalculation();
            }
        }

        private void btnPreviousDay_Click(object sender, EventArgs e)
        {
            this.dtDate.DateTime = this.dtDate.DateTime.AddDays(-1);
            this.OverTimeCalculation();
        }

        private void btnNextDay_Click(object sender, EventArgs e)
        {
            this.dtDate.DateTime = this.dtDate.DateTime.AddDays(1);
            this.OverTimeCalculation();
        }

        private void frm_S_PCO_EmployeeOTNew_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void frm_S_PCO_EmployeeOTNew_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.workDate))
            {
                txtEmployeeID.Text = this.currentEmployeeID.ToString();
                dtDate.DateTime = Convert.ToDateTime(this.workDate);
                KeyEventArgs events = new KeyEventArgs(Keys.Enter);
                this.txtEmployeeID_KeyDown(null, events);
            }
        }

        private void dtDate_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            dtDate.EditValue = e.Value;
            OverTimeCalculation();
        }

        private void dtDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtHours_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void lkeCheck_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtRemark_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                this.btnOK.Focus();
            }
        }
    }
}
