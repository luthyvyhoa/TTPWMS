using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Controls;
using DA;
using UI.Helper;
using DevExpress.XtraLayout.Utils;
using log4net;
using UI.WarehouseManagement;
using UI.Supperviors;
using UI.ReportFile;
using DevExpress.XtraEditors;

namespace UI.MasterSystemSetup
{
    public partial class frm_MSS_Employees : frmBaseForm
    {
        // Declare log
        private static readonly ILog log = LogManager.GetLogger(typeof(frm_MSS_Employees));
        private DataProcess<Employees> employeeDA = new DataProcess<Employees>();
        private DataProcess<STEmployeeFamilyMembers_Result> familyMemberDA = new DataProcess<STEmployeeFamilyMembers_Result>();
        private DataProcess<ST_WMS_LoadReportToManagementLevel_Result> loadSuitableManagementLevel = new DataProcess<ST_WMS_LoadReportToManagementLevel_Result>();
        private BindingSource employeesBindingSource = new BindingSource();
        private BindingList<STEmployeeFamilyMembers_Result> employeeFamilyList = null;
        // Specify exactly how to interpret the string.  
        private IFormatProvider culture = new System.Globalization.CultureInfo("fr-FR", true);
        private int sf_employeesID = 0;
        private bool isExpand = true;
        private bool isMemberFamilyChange = false;

        public frm_MSS_Employees()
        {
            Init_Gender();
            Init_Education();
            Init_Shift();
            Init_Department();
            Init_Stores();
            Init_LunchPlace();
            Init_Position();
            Init_provinces();
            Init_DepartmentTeams(this.sf_employeesID);
            this.layoutControlItem32.Visibility = LayoutVisibility.Never;
            this.btn_MSS_Expand.Caption = "Expand";
        }
        public frm_MSS_Employees(int empID)
        {
            InitializeComponent();
            Init_Gender();
            Init_Education();
            Init_Shift();
            Init_Department();
            Init_Stores();
            Init_LunchPlace();
            Init_Position();
            Init_provinces();
            Init_DepartmentTeams(empID);
            setEnableDisableControl(true);
            this.sf_employeesID = empID;
            this.txt_MMS_LastName.Font = new Font(txt_MMS_LastName.Font, FontStyle.Bold);
            this.txt_MMS_FirstName.Font = new Font(txt_MMS_FirstName.Font, FontStyle.Bold);
            this.txt_MMS_ChucVu.Font = new Font(txt_MMS_ChucVu.Font, FontStyle.Bold);
            this.lke_MMS_Store.Font = new Font(lke_MMS_Store.Font, FontStyle.Bold);
            this.txt_MMS_HoVaTen.Font = new Font(txt_MMS_HoVaTen.Font, FontStyle.Bold);
            //this.layoutControlItem32.Visibility = LayoutVisibility.Never;
            //this.btn_MSS_Expand.Caption = "Expand";
        }

        void setEnableDisableControl(bool enable)
        {
            this.txt_MMS_ID.ReadOnly = enable;
            this.da_MMS_Birthday.ReadOnly = enable;
            this.mm_MMS_addressIDCard.ReadOnly = enable;
            this.lke_MMS_Education.ReadOnly = enable;
            this.lke_MMS_Gender.ReadOnly = enable;
            this.lke_MMS_Department.ReadOnly = enable;
            this.lke_MMS_Shift.ReadOnly = enable;
            this.lke_MMS_Store.ReadOnly = enable;
            this.da_MMS_EntryDate.ReadOnly = enable;
            this.ckb_MMS_PerformanceStatus.ReadOnly = enable;
            this.ckb_MMS_Pay_RollActive.ReadOnly = enable;
            this.ckb_MMS_Permanent.ReadOnly = enable;
            this.ckb_MMS_Leave.ReadOnly = enable;
            this.da_MMS_ContractDate.ReadOnly = enable;
            this.txt_MMS_ContractNo.ReadOnly = enable;
            this.da_MMS_LeaveDate.ReadOnly = enable;
            this.txt_MMS_BankAccountNo.ReadOnly = enable;
            this.txt_MMS_WorkdayID.ReadOnly = enable;
            this.da_MMS_ContractFirst.ReadOnly = enable;
            this.ckb_MMS_Advance.ReadOnly = enable;
            this.txt_MMS_Advance.ReadOnly = true;
            this.lke_MMS_LunchPlace.ReadOnly = enable;
            this.txt_MMS_TaxCode.ReadOnly = enable;
            this.lke_MMS_ReportTo.ReadOnly = enable;
            this.txt_MMS_FirstName.ReadOnly = enable;
            this.txt_MMS_LastName.ReadOnly = enable;
            this.txt_MMS_EnglishName.ReadOnly = enable;
            this.mm_MMS_AddressNow.ReadOnly = enable;
            this.txt_MMS_HoVaTen.ReadOnly = enable;
            this.txt_MMS_ChucVu.ReadOnly = enable;
            this.lke_MMS_Position.ReadOnly = enable;
            this.ckb_MMS_BikeUse.ReadOnly = enable;
            this.txt_MMS_BikeNumber.ReadOnly = enable;
            this.txt_MMS_Mobile.ReadOnly = enable;
            this.txtPLUCode.ReadOnly = enable;
            this.txt_MMS_Phone.ReadOnly = enable;
            this.txt_MMS_Grade.ReadOnly = enable;
            this.txt_MMS_IDCardNo.ReadOnly = enable;
            this.da_MMS_IDDate.ReadOnly = enable;
            this.lkePlace.ReadOnly = enable;
            this.txt_MMS_InOutCard.ReadOnly = enable;
            this.txt_MMS_Email.ReadOnly = enable;
            this.mm_MMS_Remark.ReadOnly = enable;
            this.lke_MMS_DepartmentTeamID.ReadOnly = enable;
            this.txt_MMS_ContractWorkingDays.ReadOnly = enable;
            this.txt_MMS_DepartmentShortName.ReadOnly = enable;
            btn_MSS_Edit.Enabled = enable;
            btn_MSS_Update.Enabled = !enable;
        }
        private void frm_MSS_Employees_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {

            // TODO: This line of code loads data into the 'swireDBDataSet.EmployeeFamilyMembers' table. You can move, or remove it, as needed.
            this.layoutControlItem32.Visibility = LayoutVisibility.Never;
            this.isExpand = false;
            this.Location = new Point(this.Location.X, 10);
            this.ResizeHeightControl();
            var listEmployees = employeeDA.Select().ToList();
            this.dataNavigatorEmployees.DataSource = listEmployees;
            this.dataNavigatorEmployees.Position = -1;
            if (this.sf_employeesID > 0)
            {
                var emSelected = employeeDA.Select(x => x.EmployeeID == this.sf_employeesID).FirstOrDefault();
                var index = listEmployees.FindIndex(x=>x.EmployeeID == emSelected.EmployeeID);
                if (index == 0) this.dataNavigatorEmployees.Position = 1;
                this.dataNavigatorEmployees.Position = index;
            }
            else
            {
                var empnow = new Employees();
                //empnow.EmployeeID = employeeDA.Select().OrderByDescending(em => em.EmployeeID).FirstOrDefault().EmployeeID + 1;
                if (AppSetting.StoreID == 3)
                {
                    empnow.EmployeeID = employeeDA.Select(x => x.StoreID == AppSetting.StoreID).OrderByDescending(em => em.EmployeeID).FirstOrDefault().EmployeeID + 1;
                    empnow.StoreID = AppSetting.StoreID;
                }
                else
                {
                    var maxIDtb = FileProcess.LoadTable("SELECT top 1 EmployeeID" +
                         " FROM Employees" +
                         " WHERE Employees.StoreID in (1,2) Order by EmployeeID desc");
                    int eID = Convert.ToInt32(maxIDtb.Rows[0]["EmployeeID"].ToString());
                    empnow.EmployeeID = eID + 1;
                    empnow.StoreID = AppSetting.StoreID;
                }
                this.BindingData(empnow);
                setEnableDisableControl(false);
            }
        }

        /// <summary>
        /// Get image path
        /// </summary>
        public string ImagePath
        {
            get
            {
                string employeeImagePath = string.Empty;
                if (!string.IsNullOrEmpty(AppSetting.PathEmployeePicture))
                {
                    employeeImagePath = AppSetting.PathEmployeePicture + this.txt_MMS_ID.Text + ".jpg";

                    // Check image path has exist in folder
                    if (!System.IO.File.Exists(employeeImagePath))
                    {
                        employeeImagePath = string.Empty;
                    }
                }


                return employeeImagePath;
            }
        }

        /// <summary>
        /// Init combobox Education "9/12"; "12/12"; "High School"; "College"; "University"; "Master"
        /// </summary>
        private void Init_Education()
        {
            using (var tbEducation = new System.Data.DataTable())
            {
                tbEducation.Columns.Add("Name");
                // Other row
                var nRow = tbEducation.NewRow();
                nRow["Name"] = "9/12";
                var tRow = tbEducation.NewRow();
                tRow["Name"] = "12/12";
                var hRow = tbEducation.NewRow();
                hRow["Name"] = "High School";
                var eRow = tbEducation.NewRow();
                eRow["Name"] = "Elementary Occupations";
                var cRow = tbEducation.NewRow();
                cRow["Name"] = "College";
                var uRow = tbEducation.NewRow();
                uRow["Name"] = "University";
                // Other row
                var mRow = tbEducation.NewRow();
                mRow["Name"] = "Master";
                // Add row
                tbEducation.Rows.Add(nRow);
                tbEducation.Rows.Add(tRow);
                tbEducation.Rows.Add(hRow);
                tbEducation.Rows.Add(eRow);
                tbEducation.Rows.Add(cRow);
                tbEducation.Rows.Add(uRow);
                tbEducation.Rows.Add(mRow);

                this.lke_MMS_Education.Properties.DataSource = tbEducation;
                this.lke_MMS_Education.Properties.ValueMember = "Name";
                this.lke_MMS_Education.Properties.DisplayMember = "Name";
            }
        }

        private void LoadEmployeeFamilyMember()
        {
            var lisFamilyMember = familyMemberDA.Executing("STEmployeeFamilyMembers @EmployeeID=" + this.sf_employeesID);
            this.employeeFamilyList = new BindingList<STEmployeeFamilyMembers_Result>(lisFamilyMember.ToList());
            this.grdEmployeeFamilyMembers.DataSource = this.employeeFamilyList;
            this.employeeFamilyList.Add(new STEmployeeFamilyMembers_Result());
        }
        private void LoadProductivity()
        {
            var productivityList = FileProcess.LoadTable("STOutsourcedJobListByEmployee @employeeID=" + this.sf_employeesID);
            this.grdOutsourceJobs.DataSource = productivityList;
        }

        private void Init_Shift()
        {
            DataProcess<Shifts> loadShiftInfo = new DataProcess<Shifts>();
            var shiftInfo = loadShiftInfo.Select();
            this.lke_MMS_Shift.Properties.DataSource = shiftInfo;
            this.lke_MMS_Shift.Properties.ValueMember = "ShiftID";
            this.lke_MMS_Shift.Properties.DisplayMember = "ShiftValue";
        }
        private void Init_Gender()
        {
            this.lke_MMS_Gender.Properties.DataSource = UI.Helper.AppSetting.GetGender();
            this.lke_MMS_Gender.Properties.ValueMember = "ID";
            this.lke_MMS_Gender.Properties.DisplayMember = "Sex";
        }
        private void Init_Department()
        {
            DataProcess<Departments> loadDepartment = new DataProcess<Departments>();
            this.lke_MMS_Department.Properties.DataSource = loadDepartment.Select();
            this.lke_MMS_Department.Properties.ValueMember = "DepartmentID";
            this.lke_MMS_Department.Properties.DisplayMember = "DepartmentName";
        }
        private void Init_Stores()
        {
            DataProcess<Stores> loadStoreInfo = new DataProcess<Stores>();
            this.lke_MMS_Store.Properties.DataSource = loadStoreInfo.Select();
            this.lke_MMS_Store.Properties.ValueMember = "StoreID";
            this.lke_MMS_Store.Properties.DisplayMember = "StoreDescription";
        }
        private void Init_LunchPlace()
        {
            DataProcess<LunchPlaces> loadLunchPlace = new DataProcess<LunchPlaces>();
            this.lke_MMS_LunchPlace.Properties.DataSource = loadLunchPlace.Select();
            this.lke_MMS_LunchPlace.Properties.ValueMember = "LunchPlaceID";
            this.lke_MMS_LunchPlace.Properties.DisplayMember = "PlaceDescription";
        }
        private void Init_ReportTo(int managementLevel)
        {
            this.lke_MMS_ReportTo.Properties.DataSource = loadSuitableManagementLevel.Executing("ST_WMS_LoadReportToManagementLevel @ManagementLevel={0}", managementLevel);
            this.lke_MMS_ReportTo.Properties.ValueMember = "EmployeeID";
            this.lke_MMS_ReportTo.Properties.DisplayMember = "VietnamName";
        }
        private void Init_Position()
        {
            DataProcess<Positions> loadPosition = new DataProcess<Positions>();
            this.lke_MMS_Position.Properties.DataSource = loadPosition.Select().OrderBy(x => x.PositionDescription);
            this.lke_MMS_Position.Properties.ValueMember = "PositionID";
            this.lke_MMS_Position.Properties.DisplayMember = "PositionDescription";
        }
        private void Init_provinces()
        {
            this.lkePlace.Properties.DataSource = FileProcess.LoadTable("select * from CustomerClientAddressProvinces");
            this.lkePlace.Properties.ValueMember = "ProvinceNameEmployee";
            this.lkePlace.Properties.DisplayMember = "ProvinceNameEmployee";
        }
        private void Init_DepartmentTeams(int empID)
        {
            Employees emp = null;
            this.sf_employeesID = empID;
            if (this.sf_employeesID > 0)
            {
                emp = employeeDA.Select(x => x.EmployeeID == this.sf_employeesID).FirstOrDefault();
            }
            else
            {
                emp = new Employees();
                //emp.EmployeeID = employeeDA.Select().OrderByDescending(em => em.EmployeeID).FirstOrDefault().EmployeeID + 1;                
                if (AppSetting.StoreID == 3)
                {
                    emp.EmployeeID = employeeDA.Select(x => x.StoreID == AppSetting.StoreID).OrderByDescending(em => em.EmployeeID).FirstOrDefault().EmployeeID + 1;
                    emp.StoreID = AppSetting.StoreID;
                }
                else
                {
                    emp.EmployeeID = employeeDA.Select(x => x.StoreID != 3).OrderByDescending(em => em.EmployeeID).FirstOrDefault().EmployeeID + 1;
                    emp.StoreID = AppSetting.StoreID;
                }
            }

            DataProcess<object> loadDepartmentTeams = new DataProcess<object>();
            this.lke_MMS_DepartmentTeamID.Properties.DataSource = FileProcess.LoadTable("ST_WMS_LoadDepartmentTeams @departmentID=" + emp.Department);
            this.lke_MMS_DepartmentTeamID.Properties.ValueMember = "DepartmentTeamID";
            this.lke_MMS_DepartmentTeamID.Properties.DisplayMember = "TeamName";
        }


        private void ckb_MMS_Advance_Click(object sender, EventArgs e)
        {

        }
        private void pe_MSS_ImageEmployeeID_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.ImagePath)) return;
            Image img = Image.FromFile(this.ImagePath);
            frm_MSS_ShowImage imgView = new frm_MSS_ShowImage(img);
            if (!imgView.Enabled) return;
            imgView.ShowDialog();
        }
        private void btn_MMS_Allocation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_MSS_EmployeeAllocations frmAllocation = new frm_MSS_EmployeeAllocations();
            frmAllocation.Show();
        }
        private void btn_MSS_Update_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //int idEmp = Convert.ToInt32(txt_MMS_ID.Text);
            //int isExsistEmp = employeeDA.Select(n => n.EmployeeID == idEmp).Count();

            if (!ValidateInputData()) return;

            if (string.IsNullOrEmpty(txt_MMS_ID.Text) || Convert.IsDBNull(txt_MMS_ID.Text))
            {
                int result = this.employeeDA.Insert(currentEmployees());
                if (result != -2)
                    MessageBox.Show("Add new Ok!", "WMS_2017", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Add new error!", "WMS_2017", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                Employees employees = currentEmployees();

                if (employees.EmployeeID > 0)
                {
                    int re = this.employeeDA.Update(employees);
                    if (re != -2)
                        MessageBox.Show("Update Ok!", "WMS_2017", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Update error!", "WMS_2017", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    employees.EmployeeID = Convert.ToInt32(this.txt_MMS_ID.Text);
                    int result = this.employeeDA.Insert(employees);
                    if (result != -2)
                        MessageBox.Show("Insert Ok!", "WMS_2017", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Insert error!", "WMS_2017", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            this.setEnableDisableControl(true);
        }

        private bool ValidateInputData()
        {
            bool v_ret = true;

            if (string.IsNullOrEmpty(txt_MMS_LastName.Text))
            {
                XtraMessageBox.Show("Last / First Name please !", "WMS");
                txt_MMS_LastName.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txt_MMS_FirstName.Text))
            {
                XtraMessageBox.Show("Last / First Name please !", "WMS");
                txt_MMS_FirstName.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txt_MMS_HoVaTen.Text))
            {
                XtraMessageBox.Show("Full VN / E Name please !", "WMS");
                txt_MMS_HoVaTen.Focus();
                return false;
            }
            else if (lke_MMS_Position.EditValue == null || lke_MMS_Position.EditValue.ToString() == "0")
            {
                XtraMessageBox.Show("English Position please !", "WMS");
                lke_MMS_Position.Focus();
                return false;
            }

            return v_ret;

        }
        private Employees currentEmployees()
        {
            Employees currentEmployees = null;
            
            if (string.IsNullOrEmpty(this.txt_MMS_ID.Text) || this.txt_MMS_ID.Text.Equals("0"))
            {
                currentEmployees = new Employees();
                return currentEmployees;
            }
            else
            {
                int employeeID = Convert.ToInt32(this.txt_MMS_ID.Text);
                currentEmployees = this.employeeDA.Select(e => e.EmployeeID == employeeID).FirstOrDefault();
                if (currentEmployees == null)
                {
                    currentEmployees = new Employees();
                }
            }
            if (!string.IsNullOrEmpty(this.da_MMS_Birthday.Text)) currentEmployees.DateOfBirth = Convert.ToDateTime(this.da_MMS_Birthday.EditValue);
            currentEmployees.Address = this.mm_MMS_addressIDCard.Text;
            //hung 19/04/2019
            currentEmployees.AddressNow = this.mm_MMS_AddressNow.Text;
            currentEmployees.BankAccountNumber = this.txt_MMS_BankAccountNo.Text;

            //department Teams
            if (this.lke_MMS_DepartmentTeamID.EditValue != null)
                currentEmployees.DepartmentTeamID = Convert.ToInt32(this.lke_MMS_DepartmentTeamID.EditValue);

            currentEmployees.ContractNumber = this.txt_MMS_ContractNo.Text;

            if (this.lke_MMS_Gender.EditValue != null)
                currentEmployees.Sex = (bool)this.lke_MMS_Gender.EditValue;
            int position = Convert.ToInt32(this.lke_MMS_Position.EditValue);
            if (currentEmployees.PositionID != position)
            {
                this.employeeDA.ExecuteNoQuery("STEmployeeHistoriesInsert @EmployeeID={0},@CreatedBy={1},@BeforeDataChanged={2},@AfterDataChanged={3},@HistoryDescription={4}",
                    currentEmployees.EmployeeID, AppSetting.CurrentUser.LoginName, currentEmployees.PositionID, position, "Change Position");
            }
            currentEmployees.PositionID = position;
            currentEmployees.Education = Convert.ToString(this.lke_MMS_Education.EditValue);
            int convertShift = Convert.ToInt32(this.lke_MMS_Shift.EditValue);
            currentEmployees.ShiftID = (byte)convertShift;
            int convertDepartment = Convert.ToInt32(this.lke_MMS_Department.EditValue);
            int convertAdvance = 0;
            if (this.txt_MMS_Advance.EditValue != null && this.txt_MMS_Advance.EditValue.ToString() != "")
            {
                convertAdvance = Convert.ToInt32(this.txt_MMS_Advance.EditValue);
            }

            string nameEmp = Convert.ToString(txt_MMS_HoVaTen.Text);
            if (currentEmployees.Department != convertDepartment)
            {
                this.employeeDA.ExecuteNoQuery("STEmployeeHistoriesInsert @EmployeeID={0},@CreatedBy={1},@BeforeDataChanged={2},@AfterDataChanged={3},@HistoryDescription={4}",
                    currentEmployees.EmployeeID, AppSetting.CurrentUser.LoginName, currentEmployees.Department, convertDepartment, "Change department");
            }
            if (currentEmployees.ShiftID != convertShift)
            {
                this.employeeDA.ExecuteNoQuery("STEmployeeHistoriesInsert @EmployeeID={0},@CreatedBy={1},@BeforeDataChanged={2},@AfterDataChanged={3},@HistoryDescription={4}",
                    currentEmployees.EmployeeID, AppSetting.CurrentUser.LoginName, currentEmployees.ShiftID, convertShift, "Change Shift");
            }
            if (currentEmployees.MonthlyAdvanceAmount != convertAdvance)
            {
                this.employeeDA.ExecuteNoQuery("STEmployeeHistoriesInsert @EmployeeID={0},@CreatedBy={1},@BeforeDataChanged={2},@AfterDataChanged={3},@HistoryDescription={4}",
                    currentEmployees.EmployeeID, AppSetting.CurrentUser.LoginName, currentEmployees.MonthlyAdvanceAmount, convertAdvance, "Change Advance Amount");
            }
            if (nameEmp != null && nameEmp != "")
            {
                if (currentEmployees.VietnamName != null)
                {
                    if (!currentEmployees.Equals(nameEmp))
                    {
                        this.employeeDA.ExecuteNoQuery("STEmployeeHistoriesInsert @EmployeeID={0},@CreatedBy={1},@BeforeDataChanged={2},@AfterDataChanged={3},@HistoryDescription={4}",
                            currentEmployees.EmployeeID, AppSetting.CurrentUser.LoginName, currentEmployees.VietnamName, nameEmp, "Change Name");
                    }
                }


            }
            currentEmployees.Department = (byte)convertDepartment;
            if (!string.IsNullOrEmpty(Convert.ToString(this.da_MMS_EntryDate.EditValue)))
                //currentEmployees.DateOfEntry = DateTime.Parse(Convert.ToString(this.da_MMS_EntryDate.EditValue), this.culture);
                currentEmployees.DateOfEntry = Convert.ToDateTime(this.da_MMS_EntryDate.EditValue).Date;
            currentEmployees.PerformanceStatus = (bool)this.ckb_MMS_PerformanceStatus.EditValue;
            currentEmployees.Active = (bool)this.ckb_MMS_Pay_RollActive.EditValue;
            currentEmployees.ContractPermanent = (bool)this.ckb_MMS_Permanent.EditValue;
            currentEmployees.IsLeave = (bool)this.ckb_MMS_Leave.EditValue;
            currentEmployees.IsOutsourcing = this.chkIsOutsourcing.Checked;
            if (!string.IsNullOrEmpty(this.da_MMS_ContractDate.Text))
            {
                currentEmployees.ContractDate = Convert.ToDateTime(this.da_MMS_ContractDate.EditValue).Date;
            }

            //hung 18/05/2019
            if (!string.IsNullOrEmpty(this.da_MMS_ContractFirst.Text))
            {
                currentEmployees.ContractDateFirst = Convert.ToDateTime(this.da_MMS_ContractFirst.EditValue).Date;
            }

            if (this.lke_MMS_Store.EditValue != null)
                currentEmployees.StoreID = (int)this.lke_MMS_Store.EditValue;
            else
                currentEmployees.StoreID = 1;
            if (this.lke_MMS_LunchPlace.EditValue != null)
                currentEmployees.LunchPlace = this.lke_MMS_LunchPlace.EditValue.ToString();
            // Set edit value for report to
            if (lke_MMS_ReportTo.EditValue != null)
                currentEmployees.ReportTo = (int)this.lke_MMS_ReportTo.EditValue;
            currentEmployees.FirstName = this.txt_MMS_FirstName.Text;
            currentEmployees.LastName = this.txt_MMS_LastName.Text;
            currentEmployees.VietnamName = this.txt_MMS_HoVaTen.Text;
            currentEmployees.EnglishName = this.txt_MMS_EnglishName.Text;
            currentEmployees.Position = this.lke_MMS_Position.Text;
            currentEmployees.MonthlyAdvanceRequired = this.ckb_MMS_Advance.Checked;
            //hung 20/04/2019
            if (!string.IsNullOrEmpty(this.txt_MMS_Advance.Text))
            {
                currentEmployees.MonthlyAdvanceAmount = Convert.ToInt32(this.txt_MMS_Advance.Text);
            }
            //
            currentEmployees.PositionID = Convert.ToInt32(this.lke_MMS_Position.EditValue);
            currentEmployees.ManagementLevel = Convert.ToInt32(this.lke_MMS_Position.GetColumnValue("ManagementLevel"));
            currentEmployees.VietnamPosition = this.txt_MMS_ChucVu.Text;
            if (this.da_MMS_LeaveDate.EditValue != null)
            {
                currentEmployees.LeaveDate = this.da_MMS_LeaveDate.DateTime;
                this.employeeDA.ExecuteNoQuery("STEmployeeHistoriesInsert @EmployeeID={0},@CreatedBy={1},@BeforeDataChanged={2},@AfterDataChanged={3},@HistoryDescription={4}",
                   currentEmployees.EmployeeID, AppSetting.CurrentUser.LoginName, currentEmployees.LeaveDate, this.da_MMS_LeaveDate.DateTime, "Change Leave Date");
            }
            if (this.ckb_MMS_BikeUse.Text != "")
                currentEmployees.BikeUse = (bool)this.ckb_MMS_BikeUse.EditValue;

            if (this.txt_MMS_BikeNumber.Text != "")
                currentEmployees.BikeNumber = this.txt_MMS_BikeNumber.Text;
            if (this.txt_MMS_Mobile.Text != "")
                currentEmployees.Mobile = this.txt_MMS_Mobile.Text;
            currentEmployees.PLUCode = this.txtPLUCode.Text;
            if (this.txt_MMS_Phone.Text != "")
                currentEmployees.Phone = this.txt_MMS_Phone.Text;
            if (this.txt_MMS_Grade.Text != "")
            {
                int grade = Convert.ToInt32(this.txt_MMS_Grade.Text);
                currentEmployees.Grade = (byte)grade;
            }
            currentEmployees.IDCardNumber = this.txt_MMS_IDCardNo.Text;
            if (this.da_MMS_IDDate.Text != "")
                currentEmployees.IDCardIssueDate = Convert.ToDateTime(this.da_MMS_IDDate.EditValue);
            currentEmployees.IDCardIssuePlace = this.lkePlace.Text;
            if (this.txt_MMS_InOutCard.Text != "")
                currentEmployees.InOutCardNumber = this.txt_MMS_InOutCard.Text;
            if (this.txt_MMS_Email.Text != "")
                currentEmployees.Email = this.txt_MMS_Email.Text;
            if (this.txt_MMS_WorkdayID.Text != "")
                currentEmployees.WorkdayEmployeeID = this.txt_MMS_WorkdayID.Text;
            if (this.mm_MMS_Remark.Text != "")
                currentEmployees.Remark = this.mm_MMS_Remark.Text;

            if (this.txt_MMS_ContractWorkingDays.Text != "")
                currentEmployees.ContractWorkingDays = Convert.ToInt32(this.txt_MMS_ContractWorkingDays.EditValue);

            return currentEmployees;

        }

        private void lke_MMS_Position_EditValueChanged(object sender, EventArgs e)
        {
            txt_MMS_ChucVu.EditValue = lke_MMS_Position.GetColumnValue("PositionVietnam");
        }

        private void btn_MSS_Edit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
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

            Employees currentEmployees = (Employees)this.currentEmployees();
            setEnableDisableControl(false);
            if (currentEmployees.ManagementLevel <= 0)
            {
                Init_ReportTo(1000);
            }
            else
            {
                Init_ReportTo(currentEmployees.ManagementLevel);
            }
        }
        private void ckb_MMS_Advance_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_MMS_Advance.Checked)
            {
                txt_MMS_Advance.Text = "1000000";
            }
            else
            {
                txt_MMS_Advance.Text = "0";
            }
        }

        private void btn_MMS_Position_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_MSS_PositionSystem positionForm = new frm_MSS_PositionSystem();
            positionForm.Show();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btn_MSS_History_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_MSS_EmployeeHistory employeeHistory = new frm_MSS_EmployeeHistory(this.sf_employeesID);
            employeeHistory.Show();
        }
        private void btn_MSS_Expand_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (this.btn_MSS_Expand.Caption == "Expand Detailed Data")
            {
                this.layoutControlItem32.Visibility = LayoutVisibility.Always;
                this.isExpand = true;
                this.btn_MSS_Expand.Caption = "Collapse";
                loadSupportingTabs();


            }
            else
            {
                this.layoutControlItem32.Visibility = LayoutVisibility.Never;
                this.isExpand = false;
                this.btn_MSS_Expand.Caption = "Expand Detailed Data";
            }

            this.ResizeHeightControl();
        }

        /// <summary>
        /// Resize height form when Visibility layout detail
        /// </summary>
        private void ResizeHeightControl()
        {
            if (this.isExpand == false)
            {
                this.Height = 500;
            }
            else
            {
                this.Height = 1000;
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.F3)
            {
                string employeeID = "EI-" + this.txt_MMS_ID.Text;
                frm_WM_Attachments.Instance.OrderNumber = employeeID;
                frm_WM_Attachments.Instance.CustomerID = 0;
                if (frm_WM_Attachments.Instance.Enabled)
                {
                    frm_WM_Attachments.Instance.ShowDialog();
                }

            }
            return base.ProcessDialogKey(keyData);
        }

        private void grvEmployeeFamilyMembers_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.isMemberFamilyChange = true;
            if (e.Column.FieldName.Equals("Relationship"))
            {
                int employeeFamilyID = Convert.ToInt32(this.grvEmployeeFamilyMembers.GetRowCellValue(e.RowHandle, "EmployeeFamilyMemberID"));
                if (this.grvEmployeeFamilyMembers.RowCount.Equals(e.RowHandle + 1) && employeeFamilyID > 0)
                {
                    // Add new row
                    this.employeeFamilyList.Add(new STEmployeeFamilyMembers_Result());
                }
            }
        }

        private void LoadRelationShip()
        {
            IList<string> relationShipList = new List<string> { "Wife", "Husband", "Children", "Father", "Mother", "Brother", "Sister", "Other" };
            this.rpi_lke_Relationship.DataSource = relationShipList;
        }

        private void rpi_btnDelete_Click(object sender, EventArgs e)
        {
            var dl = MessageBox.Show("Do you want to delete this record?", "WM-2017", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dl.Equals(DialogResult.No)) return;

            //Insert
            int employeeFamilyID = Convert.ToInt32(this.grvEmployeeFamilyMembers.GetRowCellValue(this.grvEmployeeFamilyMembers.FocusedRowHandle, "EmployeeFamilyMemberID"));
            DataProcess<object> employeeFaminlyDA = new DataProcess<object>();
            employeeFaminlyDA.ExecuteNoQuery("STEmployeeFamilyMemberInsert @Flag ={0},@EmployeeFamilyMemberID={1}", 2, employeeFamilyID);
            // load EmployeeFamilyMembers
            this.LoadEmployeeFamilyMember();
        }

        private void grvEmployeeFamilyMembers_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            // If does not any cell value is modified then return
            if (!this.isMemberFamilyChange) return;

            // If current selected row is has value then return
            int rowHandle = this.grvEmployeeFamilyMembers.FocusedRowHandle;
            if (rowHandle < 0) return;
            string fullName = Convert.ToString(this.grvEmployeeFamilyMembers.GetRowCellValue(rowHandle, "FullName"));
            DateTime dateOfBirth = Convert.ToDateTime(this.grvEmployeeFamilyMembers.GetRowCellValue(rowHandle, "DateOfBirth"));
            bool sex = Convert.ToBoolean(this.grvEmployeeFamilyMembers.GetRowCellValue(rowHandle, "Sex"));
            string relation = Convert.ToString(this.grvEmployeeFamilyMembers.GetRowCellValue(rowHandle, "Relationship"));
            string mobile = Convert.ToString(this.grvEmployeeFamilyMembers.GetRowCellValue(rowHandle, "Mobile"));
            string remark = Convert.ToString(this.grvEmployeeFamilyMembers.GetRowCellValue(rowHandle, "Remark"));
            this.grvEmployeeFamilyMembers.SetFocusedRowCellValue("EmployeeID", this.sf_employeesID);

            // Check employee family id has exist in DB
            int employeeFamilyID = Convert.ToInt32(this.grvEmployeeFamilyMembers.GetRowCellValue(rowHandle, "EmployeeFamilyMemberID"));
            if (employeeFamilyID > 0)
            {
                // Update
                DataProcess<object> employeeFaminlyDA = new DataProcess<object>();
                employeeFaminlyDA.ExecuteNoQuery("STEmployeeFamilyMemberInsert @FullName={0},@DateOfBirth={1},@Sex={2},@Relationship={3},@Mobile={4},@Remark={5},@EmployeeID={6},@Flag={7},@EmployeeFamilyMemberID={8}",
                    fullName, dateOfBirth, sex, relation, mobile, remark, this.sf_employeesID, 1, employeeFamilyID);
            }
            else
            {
                //Insert
                DataProcess<object> employeeFaminlyDA = new DataProcess<object>();
                int result = employeeFaminlyDA.ExecuteNoQuery("STEmployeeFamilyMemberInsert @FullName={0},@DateOfBirth={1},@Sex={2},@Relationship={3},@Mobile={4},@Remark={5},@EmployeeID={6},@Flag={7}",
                        fullName, dateOfBirth, sex, relation, mobile, remark, this.sf_employeesID, 0);

                // Select current family memberID
                if (result > 0)
                {
                    var familyMemberInfo = FileProcess.LoadTable("select top 1 employeeFamilyMemberID from EmployeeFamilyMembers where EmployeeID=" + this.sf_employeesID + " order by employeeFamilyMemberID DESC");
                    if (familyMemberInfo != null && familyMemberInfo.Rows.Count > 0)
                    {
                        int familyMemberID = Convert.ToInt32(familyMemberInfo.Rows[0][0]);
                        this.grvEmployeeFamilyMembers.SetFocusedRowCellValue("EmployeeFamilyMemberID", familyMemberID);
                    }
                }
            }

            // reset state cell change
            this.isMemberFamilyChange = false;
        }

        private void grvEmployeeFamilyMembers_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            // If does not any cell value is modified then return
            if (!this.isMemberFamilyChange) return;

            // If current selected row is has value then return
            int rowHandle = e.PrevFocusedRowHandle;
            if (rowHandle < 0) return;
            string fullName = Convert.ToString(this.grvEmployeeFamilyMembers.GetRowCellValue(rowHandle, "FullName"));
            DateTime dateOfBirth = Convert.ToDateTime(this.grvEmployeeFamilyMembers.GetRowCellValue(rowHandle, "DateOfBirth"));
            bool sex = Convert.ToBoolean(this.grvEmployeeFamilyMembers.GetRowCellValue(rowHandle, "Sex"));
            string relation = Convert.ToString(this.grvEmployeeFamilyMembers.GetRowCellValue(rowHandle, "Relationship"));
            string mobile = Convert.ToString(this.grvEmployeeFamilyMembers.GetRowCellValue(rowHandle, "Mobile"));
            string remark = Convert.ToString(this.grvEmployeeFamilyMembers.GetRowCellValue(rowHandle, "Remark"));
            this.grvEmployeeFamilyMembers.SetFocusedRowCellValue("EmployeeID", this.sf_employeesID);

            // Check employee family id has exist in DB
            int employeeFamilyID = Convert.ToInt32(this.grvEmployeeFamilyMembers.GetRowCellValue(rowHandle, "EmployeeFamilyMemberID"));
            if (employeeFamilyID > 0)
            {
                // Update
                DataProcess<object> employeeFaminlyDA = new DataProcess<object>();
                employeeFaminlyDA.ExecuteNoQuery("STEmployeeFamilyMemberInsert @FullName={0},@DateOfBirth={1},@Sex={2},@Relationship={3},@Mobile={4},@Remark={5},@EmployeeID={6},@Flag={7},@EmployeeFamilyMemberID={8}",
                    fullName, dateOfBirth, sex, relation, mobile, remark, this.sf_employeesID, 1, employeeFamilyID);
            }

            // reset state cell change
            this.isMemberFamilyChange = false;
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {

        }

        private void rpsWorkID_Click(object sender, EventArgs e)
        {
            int workID = Convert.ToInt32(this.grvOutsourceJobsTableView.GetFocusedRowCellValue("MHLWorkID"));
            frm_WM_MHLWorks form = frm_WM_MHLWorks.Instance;
            form.MHLWorkID = workID;
            form.Show();
        }

        private void rhe_RelatedKPI_Click(object sender, EventArgs e)
        {
            //code open form here
        }

        private void btnEmployeeChanged_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int employeeID = Convert.ToInt32(this.txt_MMS_ID.Text);
            frm_MSS_EmployeeChanged frmChange = new frm_MSS_EmployeeChanged(employeeID);
            if (frmChange.Enabled == false)
            {
                MessageBox.Show("Permission denied!", "WMS_2017", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmChange.ShowDialog();
            LoadData();

        }

        private void btn_MSS_PresentEmployee_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dataSource = FileProcess.LoadTable("STEmployeeCurrentInWharehouse @varStoreID=" + AppSetting.StoreID);
            rptEmployeeCurrentInWharehouse rpt = new rptEmployeeCurrentInWharehouse();
            rpt.DataSource = dataSource;
            rpt.RequestParameters = false;
            ReportPrintToolWMS printTool = new ReportPrintToolWMS(rpt);
            printTool.ShowPreviewDialog();
        }

        private void dataNavigatorEmployees_PositionChanged(object sender, EventArgs e)
        {
            if (this.dataNavigatorEmployees.Position < 0) return;
            Employees empnow = employeeDA.Select().ToList()[this.dataNavigatorEmployees.Position];
            this.sf_employeesID = empnow.EmployeeID;
            this.BindingData(empnow);
            Init_ReportTo(empnow.ManagementLevel);
            this.isExpand = false;
            ResizeHeightControl();
            this.layoutControlItem32.Visibility = LayoutVisibility.Never;
            this.btn_MSS_Expand.Caption = "Expand Detailed Data";
            //if (this.isExpand == false) return;
            //loadSupportingTabs();


        }

        private void loadSupportingTabs()
        {
            // load training employees
            DataProcess<STEmployeeHistoryViewByEmployee_Result> employeeHistory = new DataProcess<STEmployeeHistoryViewByEmployee_Result>();
            this.grdTraining.DataSource = (new DataProcess<STEmployeeHistoryViewByEmployee_Result>()).
                Executing("STEmployeeHistoryViewByEmployee @EmployeeID = {0}", this.sf_employeesID);

            DataProcess<Gate_EmployeeInOut> empInOut = new DataProcess<Gate_EmployeeInOut>();
            this.grdHistory.DataSource = empInOut.Select(eio => eio.EmployeeID == this.sf_employeesID).OrderByDescending(x => x.TimeIn);

            DataProcess<EmployeeWorkings> empWorking = new DataProcess<EmployeeWorkings>();
            this.grdEmployeesWorking.DataSource = empWorking.Select(eio => eio.EmployeeID == this.sf_employeesID).OrderByDescending(x => x.OrderDate);

            // load EmployeeFamilyMembers
            this.LoadEmployeeFamilyMember();

            // Load replation ship data
            this.LoadRelationShip();

            // Load productivity recording
            this.LoadProductivity();
        }
        /// <summary>
        /// Binding data to controls
        /// </summary>
        /// <param name="emInfo">Employees</param>
        private void BindingData(Employees emInfo)
        {
            this.lke_MMS_Gender.EditValue = emInfo.Sex;
            this.lke_MMS_Education.EditValue = emInfo.Education;
            this.lke_MMS_Shift.EditValue = emInfo.ShiftID;
            this.lke_MMS_Department.EditValue = Convert.ToInt32(emInfo.Department);
            this.lke_MMS_Store.EditValue = emInfo.StoreID;
            this.lke_MMS_LunchPlace.EditValue = emInfo.LunchPlace;
            //DepartmentTeam
            this.lke_MMS_DepartmentTeamID.EditValue = emInfo.DepartmentTeamID;
            // position
            this.lke_MMS_Position.EditValue = emInfo.PositionID;
            // Set edit value for report to
            this.lke_MMS_ReportTo.EditValue = Convert.ToInt32(emInfo.ReportTo);
            this.txt_MMS_ID.Text = Convert.ToString(emInfo.EmployeeID);
            this.da_MMS_EntryDate.EditValue = emInfo.DateOfEntry;
            this.ckb_MMS_PerformanceStatus.Checked = emInfo.PerformanceStatus;
            this.ckb_MMS_Pay_RollActive.Checked = emInfo.Active;
            this.ckb_MMS_Permanent.Checked = emInfo.ContractPermanent;
            this.ckb_MMS_Leave.Checked = Convert.ToBoolean(emInfo.IsLeave);
            this.da_MMS_LeaveDate.EditValue = emInfo.LeaveDate;
            this.txt_MMS_ContractNo.Text = emInfo.ContractNumber;
            this.da_MMS_ContractDate.EditValue = emInfo.ContractDate;
            this.txt_MMS_BankAccountNo.Text = emInfo.BankAccountNumber;
            this.txt_MMS_WorkdayID.Text = emInfo.WorkdayEmployeeID;
            this.da_MMS_ContractFirst.EditValue = emInfo.ContractDateFirst;
            this.ckb_MMS_Advance.Checked = emInfo.MonthlyAdvanceRequired;
            //hung 20/04/2019
            this.txt_MMS_Advance.Text = Convert.ToString(emInfo.MonthlyAdvanceAmount);

            this.txt_MMS_TaxCode.Text = emInfo.PersonnalTaxCode;
            this.txt_MMS_LastName.Text = emInfo.LastName;
            this.txt_MMS_FirstName.Text = emInfo.FirstName;
            this.txt_MMS_EnglishName.Text = emInfo.EnglishName;
            this.mm_MMS_addressIDCard.EditValue = emInfo.Address;
            this.da_MMS_Birthday.EditValue = emInfo.DateOfBirth;
            this.mm_MMS_AddressNow.Text = emInfo.AddressNow;
            this.txt_MMS_HoVaTen.Text = emInfo.VietnamName;
            this.txt_MMS_ChucVu.Text = emInfo.VietnamPosition;
            this.ckb_MMS_BikeUse.Checked = emInfo.BikeUse;
            this.txt_MMS_BikeNumber.Text = emInfo.BikeNumber;
            this.txt_MMS_Grade.Text = Convert.ToString(emInfo.Grade);
            this.txt_MMS_Phone.Text = emInfo.Phone;
            this.txt_MMS_Mobile.Text = emInfo.Mobile;
            this.txtPLUCode.Text = emInfo.PLUCode;
            this.txt_MMS_IDCardNo.Text = emInfo.IDCardNumber;
            this.da_MMS_IDDate.EditValue = emInfo.IDCardIssueDate;
            this.lkePlace.EditValue = emInfo.IDCardIssuePlace;
            this.txt_MMS_InOutCard.Text = emInfo.InOutCardNumber;
            this.txt_MMS_Email.Text = emInfo.Email;
            this.mm_MMS_Remark.Text = emInfo.Remark;
            this.chkIsOutsourcing.EditValue = emInfo.IsOutsourcing;

            this.txt_MMS_ContractWorkingDays.EditValue = emInfo.ContractWorkingDays;
            // Load employee image
            if (!string.IsNullOrEmpty(this.ImagePath))
            {
                this.pe_MSS_ImageEmployeeID.Image = Image.FromFile(this.ImagePath);
            }
            else
            {
                this.pe_MSS_ImageEmployeeID.Image = null;
            }
        }

        private void lke_MMS_Department_EditValueChanged(object sender, EventArgs e)
        {
            this.txt_MMS_DepartmentShortName.EditValue = this.lke_MMS_Department.GetColumnValue("DepartmentNameShort");
        }
    }
}

