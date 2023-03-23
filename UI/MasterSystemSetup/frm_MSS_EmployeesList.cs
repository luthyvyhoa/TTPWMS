using DA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using UI.Helper;

namespace UI.MasterSystemSetup
{
    public partial class frm_MSS_EmployeesList : Common.Controls.frmBaseForm
    {
        private DataProcess<Employees> empDA = new DataProcess<Employees>();
        public frm_MSS_EmployeesList()
        {
            InitializeComponent();
            LoadEmployeesList();
            Init_Position();
            Init_Department();
            Init_Stores();
            Init_Shift();
            Init_Position();
            Init_SafeTeam();
            setevent();
           
        }

        public frm_MSS_EmployeesList(string filterCondition)
        {
            InitializeComponent();
            LoadEmployeesList();
            Init_Position();
            Init_Department();
            Init_Stores();
            Init_Shift();
            Init_SafeTeam();
            setevent();
            this.gv_EmployeesList.ApplyFindFilter(filterCondition);
        }

        void setevent()
        {
            hpl_VietNamName.Click += Hpl_VietNamName_DoubleClick;
        }

        void Hpl_VietNamName_DoubleClick(object sender, EventArgs e)
        {
            int employessID = 0;
            employessID = Convert.ToInt32(this.gv_EmployeesList.GetRowCellValue(this.gv_EmployeesList.FocusedRowHandle, "EmployeeID"));
            frm_MSS_Employees frmEmpDetail = new frm_MSS_Employees(employessID);
            if (!frmEmpDetail.Enabled) return;
            frmEmpDetail.StartPosition = FormStartPosition.CenterScreen;
            frmEmpDetail.WindowState = FormWindowState.Maximized;
            frmEmpDetail.BringToFront();
            frmEmpDetail.ShowDialog();
            
        }

        private void LoadEmployeesList()
        {
            DataProcess<Employees> dataProcess = new DataProcess<Employees>();
            grd_EmployeesList.DataSource = dataProcess.Select();
            bool isSupervisor = UserPermission.CheckSupervisorByDepartment(AppSetting.CurrentUser.LoginName, 4);
            gv_EmployeesList.OptionsBehavior.ReadOnly = isSupervisor?false:true;
            
        }
        private void Init_Shift()
        {
            DataProcess<Shifts> loadShiftInfo = new DataProcess<Shifts>();
            var shiftInfo = loadShiftInfo.Select();
            this.lke_MMS_Shift.DataSource = shiftInfo;
            this.lke_MMS_Shift.ValueMember = "ShiftID";
            this.lke_MMS_Shift.DisplayMember = "ShiftValue";
        }
        private void Init_Department()
        {
            DataProcess<Departments> loadDepartment = new DataProcess<Departments>();
            this.lke_MMS_Department.DataSource = loadDepartment.Select();
            this.lke_MMS_Department.ValueMember = "DepartmentID";
            this.lke_MMS_Department.DisplayMember = "DepartmentName";
        }
        private void Init_Stores()
        {
            DataProcess<Stores> loadStoreInfo = new DataProcess<Stores>();
            this.lke_MMS_Store.DataSource = loadStoreInfo.Select();
            this.lke_MMS_Store.ValueMember = "StoreID";
            this.lke_MMS_Store.DisplayMember = "StoreDescription";
        }
        private void Init_Position()
        {
            DataProcess<Positions> loadPosition = new DataProcess<Positions>();
            this.lke_MMS_Position.DataSource = loadPosition.Select();
            this.lke_MMS_Position.ValueMember = "PositionID";
            this.lke_MMS_Position.DisplayMember = "PositionDescription";
        }
        private void Init_SafeTeam()
        {
            DataProcess<EmployeeSafetyTeam> loadSafeTeam = new DataProcess<EmployeeSafetyTeam>();
            this.lke_MMS_SafeTeam.DataSource = loadSafeTeam.Select();
            this.lke_MMS_SafeTeam.ValueMember = "EmployeeSafetyTeamID";
            this.lke_MMS_SafeTeam.DisplayMember = "SafetyTeamDescription";
        }
       

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.grd_EmployeesList.SuspendLayout();

            // Visible all column in gridview control
            Dictionary<string, string> listComlumnToDisable = new Dictionary<string, string>();
            foreach (DevExpress.XtraGrid.Columns.GridColumn columnItem in gv_EmployeesList.Columns)
            {
                if (!columnItem.Visible)
                {
                    listComlumnToDisable.Add(columnItem.Name, columnItem.Name);
                    columnItem.Visible = true;
                }
            }

            // Export data to excel file
            string pathSaveFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string fileName = pathSaveFile + "\\" + "Employees_" + DateTime.Now.ToString("dd_MM_yy") + ".xlsx";

            this.gv_EmployeesList.ExportToXlsx(fileName);

            // Refresh gridview control to root
            foreach (DevExpress.XtraGrid.Columns.GridColumn columnDisable in this.gv_EmployeesList.Columns)
            {
                if (!listComlumnToDisable.ContainsKey(columnDisable.Name)) continue;
                if (columnDisable.Name == listComlumnToDisable[columnDisable.Name])
                {
                    columnDisable.Visible = false;
                }
            }

            this.grd_EmployeesList.ResumeLayout();
            System.Diagnostics.Process.Start(fileName);
        }

        private void gv_EmployeesList_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                this.ppmnu_WM_Options.ShowPopup(Control.MousePosition);
            }
        }

        private void btn_mnu_WM_ExportEmployees_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.grd_EmployeesList.SuspendLayout();

            // Visible all column in gridview control
            Dictionary<string, string> listComlumnToDisable = new Dictionary<string, string>();
            foreach (DevExpress.XtraGrid.Columns.GridColumn columnItem in gv_EmployeesList.Columns)
            {
                if (!columnItem.Visible)
                {
                    listComlumnToDisable.Add(columnItem.Name, columnItem.Name);
                    columnItem.Visible = true;
                }
            }

            // Export data to excel file
            string pathSaveFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string fileName = pathSaveFile + "\\" + "Employees_" + DateTime.Now.ToString("dd_MM_yy") + ".xlsx";

            this.gv_EmployeesList.ExportToXlsx(fileName);

            // Refresh gridview control to root
            foreach (DevExpress.XtraGrid.Columns.GridColumn columnDisable in this.gv_EmployeesList.Columns)
            {
                if (!listComlumnToDisable.ContainsKey(columnDisable.Name)) continue;
                if (columnDisable.Name == listComlumnToDisable[columnDisable.Name])
                {
                    columnDisable.Visible = false;
                }
            }

            this.grd_EmployeesList.ResumeLayout();
            System.Diagnostics.Process.Start(fileName);
        }

        private void btn_mnu_WM_NewEmployee_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_MSS_Employees employee = new frm_MSS_Employees(-1);
            employee.Show();
            employee.BringToFront();
        }

        private void gv_EmployeesList_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if(e.Column.FieldName== "EmployeeSafetyTeamID")
            {
               
            }
        }

        private void lke_MMS_SafeTeam_EditValueChanged(object sender, EventArgs e)
        {
            
            var lke_Safeteam = (DevExpress.XtraEditors.LookUpEdit)sender;
            int empID = Convert.ToInt32(gv_EmployeesList.GetFocusedRowCellValue("EmployeeID"));
            int result = empDA.ExecuteNoQuery("Update Employees set EmployeeSafetyTeamID={0} where EmployeeID={1}", lke_Safeteam.EditValue, empID);
            if (result < 0)
            {
                MessageBox.Show("Error Update SafeTeam", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            this.LoadEmployeesList();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frm_MSS_Employees employee = new frm_MSS_Employees(-1);
            employee.Show();
            employee.BringToFront();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Frm_MSS_RoomSetupEmployee employee = new Frm_MSS_RoomSetupEmployee();
            employee.Show();
            employee.BringToFront();
        }
    }
}
