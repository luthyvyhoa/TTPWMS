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

namespace UI.MasterSystemSetup
{
    public partial class frm_MSS_EmployeeChanged : frmBaseForm
    {
        private int employeeID = 0;
        private int indexRow;
        private Employees currentEmployee = null;
        private DataProcess<EmployeeChangeHistory> dataProcess = new DataProcess<EmployeeChangeHistory>();
        private EmployeeChangeHistory currentEmhis = null;
        public frm_MSS_EmployeeChanged(int employeeID)
        {
            InitializeComponent();
            this.employeeID = employeeID;
            this.IniEvents();
            this.InitData();
        }

        private void InitData()
        {
            this.Init_Education();
            this.Init_Shift();
            this.Init_Department();
            this.Init_Stores();
            this.Init_Position();
            Init_DepartmentTeams();
            this.LoadHistoryChangedList();
            this.BindingData();
        }

        private void IniEvents()
        {
            this.btnApproved.Click += BtnApproved_Click;
            this.btnCancel.Click += BtnCancel_Click;
            this.btnDelete.Click += BtnDelete_Click;
            this.btnEdit.Click += BtnEdit_Click;
            this.btnNote.Click += BtnNote_Click;
            this.btnOk.Click += BtnOk_Click;
            this.grvHistoryChangedList.RowCellClick += GrvHistoryChangedList_RowCellClick;
        }

        private void GrvHistoryChangedList_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {

            if (e.RowHandle < 0) return;
            int employeeHisID = Convert.ToInt32(this.grvHistoryChangedList.GetFocusedRowCellValue("EmployeeChangeHistoryID"));
            if (employeeHisID <= 0) return;
            this.currentEmhis = this.dataProcess.Select(em => em.EmployeeChangeHistoryID == employeeHisID).FirstOrDefault();
            if (currentEmhis == null) return;
            this.txtEmployeeID.Text = currentEmhis.EmployeeID.ToString();
            this.txtEmployeeName.Text = AppSetting.EmployessList.Where(em => em.EmployeeID == currentEmhis.EmployeeID).FirstOrDefault().VietnamName;
            this.txtCreatedBy.Text = currentEmhis.CreatedBy;
            this.dCreatedTime.Text = currentEmhis.CreatedTime.ToString();
            this.mmDescriptions.Text = currentEmhis.Description;
            this.txtAllowance.Text = currentEmhis.SalaryAllowance;
            this.txtApprovedBy.Text = currentEmhis.ApprovedBy;
            this.txtResponsibility.Text = currentEmhis.SalaryResponsibility;
            this.txtSalary.Text = currentEmhis.Salary;
            this.txtSeniority.Text = currentEmhis.SalarySeniority;
            this.dApprovedTime.EditValue = currentEmhis.ApprovedTime;
            this.dEffectiveDate.EditValue = currentEmhis.EffectiveDate;
            this.dImplementationDate.EditValue = currentEmhis.ImplementationDate;
            this.dPeriodOfTime.EditValue = currentEmhis.PeriodOfTime;
            this.lkeFromDepartment.EditValue = currentEmhis.OldDepartmentID;
            this.lkeFromEducation.EditValue = currentEmhis.OldEducation;
            this.lkeFromPosition.EditValue = currentEmhis.OldPositionID;
            this.lkeFromShift.EditValue = currentEmhis.OldShiftID;
            this.lkeFromStore.EditValue = currentEmhis.OldStoreID;
            this.chkFromPermanent.Checked = (bool)currentEmhis.OldContractPermanent;

            LoadLkeToTeam(Convert.ToInt32(currentEmhis.DepartmentID));
            // old
            this.lkeToDepartment.EditValue = Convert.ToInt32(currentEmhis.DepartmentID);
            this.lkeToEducation.EditValue = currentEmhis.Education;
            this.lkeToPosition.EditValue = currentEmhis.PositionID;
            this.lkeToShift.EditValue = currentEmhis.ShiftID;
            this.lkeToStore.EditValue = currentEmhis.StoreID;
            this.lkeToTeam.EditValue = Convert.ToInt32(currentEmhis.DepartmentTeamID);
            this.chkToPermanent.Checked = (bool)currentEmhis.ContractPermanent;
            this.btnEdit.Enabled = true;
            this.btnDelete.Enabled = true;
            indexRow = grvHistoryChangedList.FocusedRowHandle;
        }

        private void LoadHistoryChangedList()
        {
            this.grdHistoryChangedList.DataSource = this.dataProcess.Select(e => e.EmployeeID == this.employeeID);
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            EmployeeChangeHistory newChange = new EmployeeChangeHistory();
            newChange.ContractPermanent = chkToPermanent.Checked;
            newChange.CreatedBy = AppSetting.CurrentUser.LoginName;
            newChange.CreatedTime = DateTime.Now;
            
            newChange.Description =  this.mmDescriptions.Text;
           
            newChange.EffectiveDate = dEffectiveDate.DateTime;
            newChange.EmployeeID = this.employeeID;
            newChange.ImplementationDate = this.dImplementationDate.DateTime;
            newChange.OldContractPermanent = chkFromPermanent.Checked;
            newChange.OldDepartmentID = Convert.ToByte(this.lkeFromDepartment.EditValue);
            newChange.OldEducation = Convert.ToString(this.lkeFromEducation.EditValue);
            newChange.OldPositionID = Convert.ToInt32(this.lkeFromPosition.EditValue);
            newChange.OldShiftID = Convert.ToByte(this.lkeFromShift.EditValue);
            newChange.OldStoreID = Convert.ToInt32(this.lkeFromStore.EditValue);
            newChange.OldDepartmentTeamID = Convert.ToByte(this.lkeFromTeam.EditValue);

            newChange.PeriodOfTime = this.dPeriodOfTime.DateTime;
            
            newChange.PositionID = Convert.ToInt32(this.lkeToPosition.EditValue) != 0 ?  Convert.ToInt32(this.lkeToPosition.EditValue):  Convert.ToInt32(this.lkeFromPosition.EditValue);
            newChange.DepartmentID = Convert.ToByte(this.lkeToDepartment.EditValue) != 0 ? Convert.ToByte(this.lkeToDepartment.EditValue) : Convert.ToByte(this.lkeFromDepartment.EditValue);
            newChange.DepartmentTeamID = Convert.ToByte(this.lkeToTeam.EditValue) != 0 ? Convert.ToByte(this.lkeToTeam.EditValue) : Convert.ToByte(this.lkeFromTeam.EditValue);
            newChange.Education = Convert.ToString(this.lkeToEducation.EditValue) != "" ? Convert.ToString(this.lkeToEducation.EditValue) : Convert.ToString(this.lkeFromEducation.EditValue);
            newChange.ShiftID = Convert.ToByte(this.lkeToShift.EditValue)!=0? Convert.ToByte(this.lkeToShift.EditValue): Convert.ToByte(this.lkeFromShift.EditValue);
            newChange.StoreID = Convert.ToInt32(this.lkeToStore.EditValue)!=0? Convert.ToInt32(this.lkeToStore.EditValue): Convert.ToInt32(this.lkeFromStore.EditValue);
            newChange.ContractPermanent = Convert.ToBoolean(this.chkToPermanent.EditValue);

            newChange.Salary = this.txtSalary.Text;
            newChange.SalaryAllowance = this.txtAllowance.Text;
            newChange.SalaryResponsibility = this.txtResponsibility.Text;
            newChange.SalarySeniority = this.txtSeniority.Text;
           
          

            int result= this.dataProcess.Insert(newChange);
            if (newChange.EmployeeChangeHistoryID > 0)
            {
                this.currentEmhis = this.dataProcess.Select(his => his.EmployeeChangeHistoryID == newChange.EmployeeChangeHistoryID).FirstOrDefault();
                this.LoadHistoryChangedList();

                // Update employee
                this.UpdateEmployee();
            }
        }

        private void UpdateEmployee()
        {
            if (this.currentEmhis == null) return;
            var currentEmployee = AppSetting.EmployessList.Where(em => em.EmployeeID == this.currentEmhis.EmployeeID).FirstOrDefault();
            currentEmployee.Department = this.currentEmhis.DepartmentID;
            currentEmployee.ShiftID = this.currentEmhis.ShiftID;
            currentEmployee.StoreID = this.currentEmhis.StoreID;
            currentEmployee.PositionID = Convert.ToInt32(this.currentEmhis.PositionID);
            currentEmployee.ContractPermanent = Convert.ToBoolean(this.currentEmhis.ContractPermanent);
            currentEmployee.Education = this.currentEmhis.Education;
            currentEmployee.DepartmentTeamID = this.currentEmhis.DepartmentTeamID;
            DataProcess<Positions> positionDA = new DataProcess<Positions>();
            Positions position = new Positions();
            position=positionDA.Select(n=>n.PositionID== currentEmployee.PositionID).FirstOrDefault();
            currentEmployee.Position = position.PositionDescription;
            currentEmployee.VietnamPosition = position.PositionVietnam;
            DataProcess<Employees> employeeDa = new DataProcess<Employees>();
            int result =employeeDa.Update(currentEmployee);
            this.btnEdit.Enabled = false;
        }

        private void BtnNote_Click(object sender, EventArgs e)
        {
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (this.currentEmhis == null) return;
            this.currentEmhis.DepartmentID = Convert.ToByte(this.lkeToDepartment.EditValue);
            this.currentEmhis.Description = this.mmDescriptions.Text;
            this.currentEmhis.Education = Convert.ToString(this.lkeToEducation.EditValue);
            this.currentEmhis.EffectiveDate = dEffectiveDate.DateTime;
            this.currentEmhis.ImplementationDate = this.dImplementationDate.DateTime;
            this.currentEmhis.PeriodOfTime = this.dPeriodOfTime.DateTime;
            this.currentEmhis.PositionID = Convert.ToInt32(this.lkeToPosition.EditValue);
            this.currentEmhis.Salary = this.txtSalary.Text;
            this.currentEmhis.SalaryAllowance = this.txtAllowance.Text;
            this.currentEmhis.SalaryResponsibility = this.txtResponsibility.Text;
            this.currentEmhis.SalarySeniority = this.txtSeniority.Text;
            this.currentEmhis.ShiftID = Convert.ToByte(this.lkeToShift.EditValue);
            this.currentEmhis.StoreID = Convert.ToInt32(this.lkeToStore.EditValue);
            this.dataProcess.Update(this.currentEmhis);
            this.UpdateEmployee();
            SelectRowHistories();
        }
        private void SelectRowHistories()
        {
            this.grdHistoryChangedList.DataSource = null;
            this.LoadHistoryChangedList();
            this.grvHistoryChangedList.Focus();
            this.grvHistoryChangedList.ClearSelection();
            this.grvHistoryChangedList.FocusedRowHandle = indexRow;
            this.grvHistoryChangedList.SelectRow(indexRow);

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (this.currentEmhis == null) return;
            var dl = MessageBox.Show("Do you want to delete this history?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dl.Equals(DialogResult.No)) return;
            this.dataProcess.ExecuteNoQuery("Delete EmployeeChangeHistories where EmployeeChangeHistoryID=" + this.currentEmhis.EmployeeChangeHistoryID);
            this.LoadHistoryChangedList();
            this.btnDelete.Enabled = false;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnApproved_Click(object sender, EventArgs e)
        {
            if (this.currentEmhis == null) return;
            this.txtApprovedBy.Text = AppSetting.CurrentUser.LoginName;
            this.dApprovedTime.Text = DateTime.Now.ToString();
            this.currentEmhis.ApprovedBy = AppSetting.CurrentUser.LoginName;
            this.currentEmhis.ApprovedTime = DateTime.Now;
            this.dataProcess.Update(this.currentEmhis);
        }

        private void BindingData()
        {
            if (this.employeeID <= 0) return;
            this.currentEmployee = AppSetting.EmployessList.Where(e => e.EmployeeID == this.employeeID).FirstOrDefault();
            this.txtEmployeeID.Text = currentEmployee.EmployeeID.ToString();
            this.txtEmployeeName.Text = currentEmployee.VietnamName;
            this.txtCreatedBy.Text = AppSetting.CurrentUser.LoginName;
            this.dCreatedTime.Text = DateTime.Now.ToString();
            this.lkeFromDepartment.EditValue = currentEmployee.Department;//10
            this.lkeFromEducation.EditValue = currentEmployee.Education;//9/12
            this.lkeFromPosition.EditValue = currentEmployee.PositionID;//81
            this.lkeFromShift.EditValue = currentEmployee.ShiftID;//1
            this.lkeFromStore.EditValue = currentEmployee.StoreID;//2
            this.chkFromPermanent.Checked = currentEmployee.PerformanceStatus;//true
            this.lkeFromTeam.EditValue = currentEmployee.DepartmentTeamID;//1
        }

        private void Init_Shift()
        {
            DataProcess<Shifts> loadShiftInfo = new DataProcess<Shifts>();
            var shiftInfo = loadShiftInfo.Select();
            this.lkeFromShift.Properties.DataSource = shiftInfo;
            this.lkeFromShift.Properties.ValueMember = "ShiftID";
            this.lkeFromShift.Properties.DisplayMember = "ShiftValue";

            this.lkeToShift.Properties.DataSource = shiftInfo;
            this.lkeToShift.Properties.ValueMember = "ShiftID";
            this.lkeToShift.Properties.DisplayMember = "ShiftValue";
        }

        private void Init_Department()
        {
            DataProcess<Departments> loadDepartment = new DataProcess<Departments>();
            this.lkeFromDepartment.Properties.DataSource = loadDepartment.Select();
            this.lkeFromDepartment.Properties.ValueMember = "DepartmentID";
            this.lkeFromDepartment.Properties.DisplayMember = "DepartmentName";

            this.lkeToDepartment.Properties.DataSource = loadDepartment.Select();
            this.lkeToDepartment.Properties.ValueMember = "DepartmentID";
            this.lkeToDepartment.Properties.DisplayMember = "DepartmentName";
        }
        private void Init_Stores()
        {
            DataProcess<Stores> loadStoreInfo = new DataProcess<Stores>();
            this.lkeFromStore.Properties.DataSource = loadStoreInfo.Select();
            this.lkeFromStore.Properties.ValueMember = "StoreID";
            this.lkeFromStore.Properties.DisplayMember = "StoreDescription";

            this.lkeToStore.Properties.DataSource = loadStoreInfo.Select();
            this.lkeToStore.Properties.ValueMember = "StoreID";
            this.lkeToStore.Properties.DisplayMember = "StoreDescription";
        }

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

                this.lkeFromEducation.Properties.DataSource = tbEducation;
                this.lkeFromEducation.Properties.ValueMember = "Name";
                this.lkeFromEducation.Properties.DisplayMember = "Name";

                this.lkeToEducation.Properties.DataSource = tbEducation;
                this.lkeToEducation.Properties.ValueMember = "Name";
                this.lkeToEducation.Properties.DisplayMember = "Name";
            }
        }

        private void Init_Position()
        {
            DataProcess<Positions> loadPosition = new DataProcess<Positions>();
            var dataSource = loadPosition.Select().OrderBy(x => x.PositionDescription);
            this.lkeFromPosition.Properties.DataSource = dataSource;
            this.lkeFromPosition.Properties.ValueMember = "PositionID";
            this.lkeFromPosition.Properties.DisplayMember = "PositionDescription";

            this.lkeToPosition.Properties.DataSource = dataSource;
            this.lkeToPosition.Properties.ValueMember = "PositionID";
            this.lkeToPosition.Properties.DisplayMember = "PositionDescription";
        }
        private void Init_DepartmentTeams()
        {


            DataProcess<object> loadDepartmentTeams = new DataProcess<object>();
            Employees curEmp = AppSetting.EmployessList.Where(e => e.EmployeeID == this.employeeID).FirstOrDefault();
            this.lkeFromTeam.Properties.DataSource = FileProcess.LoadTable("ST_WMS_LoadDepartmentTeams @departmentID=" + curEmp.Department);
            this.lkeFromTeam.Properties.ValueMember = "DepartmentTeamID";
            this.lkeFromTeam.Properties.DisplayMember = "TeamName";

            this.lkeToTeam.Properties.DataSource = FileProcess.LoadTable("ST_WMS_LoadDepartmentTeams @departmentID=" + curEmp.Department);
            this.lkeToTeam.Properties.ValueMember = "DepartmentTeamID";
            this.lkeToTeam.Properties.DisplayMember = "TeamName";
        }

        private void lkeToDepartment_EditValueChanged(object sender, EventArgs e)
        {
            LoadLkeToTeam(Convert.ToInt32(lkeToDepartment.EditValue));
        }
        private void LoadLkeToTeam(int departmentID)
        {
            this.lkeToTeam.Properties.DataSource = FileProcess.LoadTable("ST_WMS_LoadDepartmentTeams @departmentID=" + departmentID);
            this.lkeToTeam.Properties.ValueMember = "DepartmentTeamID";
            this.lkeToTeam.Properties.DisplayMember = "TeamName";
        }

        private void lkeToDepartment_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            
        }
    }
}
