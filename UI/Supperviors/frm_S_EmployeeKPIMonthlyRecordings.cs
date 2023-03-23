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
using UI.MasterSystemSetup;

namespace UI.Supperviors
{
    public partial class frm_S_EmployeeKPIMonthlyRecordings : Form
    {
        public string varDepartmentID;
        private bool isChangeForeignFooterCell = false;
        private bool isChangeForeignDeptFooterCell = false;
        public frm_S_EmployeeKPIMonthlyRecordings()
        {
            InitializeComponent();
            this.InitEvents();
            InitMonth();
            this.InitDepartment();
            this.InitPosition();
            this.InitData();
        }

        private void InitData()
        {
            //AppSetting.CurrentUser.DepartmentCategoryID
            this.grd_EmployeesList.DataSource = FileProcess.LoadTable("STEmployeeKPIRecordingMonhtlyEmployeeList " + AppSetting.CurrentUser.EmployeeID);

            var DepartmentData = FileProcess.LoadTable("SELECT DepartmentName, DepartmentID FROM Departments INNER JOIN Employees ON Departments.DepartmentID = Employees.Department WHERE EmployeeID = " + AppSetting.CurrentUser.EmployeeID);
            if (DepartmentData != null && DepartmentData.Rows.Count > 0)
            {
                //Allow Department Change for Managers
                varDepartmentID = Convert.ToString(DepartmentData.Rows[0]["DepartmentID"]);
                this.lke_Department.EditValue = varDepartmentID;

            }
            this.grcDepartmentKPI.DataSource = FileProcess.LoadTable("STEmployeeKPIRecordingDepartmentKPI " + varDepartmentID);
            this.grcEmployeeKPI.DataSource = FileProcess.LoadTable("STEmployeeKPIRecordingEmployeeKPI " + AppSetting.CurrentUser.EmployeeID);
        }

        private void InitEvents()
        {
            this.lke_Department.CloseUp += Lke_Department_CloseUp;
            this.gv_EmployeesList.RowCellClick += Gv_EmployeesList_RowCellClick;
        }

        private void Gv_EmployeesList_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.RowHandle < 0) return;
            int employeeID = Convert.ToInt32(this.gv_EmployeesList.GetFocusedRowCellValue("EmployeeID"));
            this.grcEmployeeKPI.DataSource = FileProcess.LoadTable("STEmployeeKPIRecordingEmployeeKPI " + employeeID);
        }

        private void Lke_Department_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.Value == null) return;
            int departmentID = Convert.ToInt32(e.Value);
            this.grcDepartmentKPI.DataSource = FileProcess.LoadTable("STEmployeeKPIRecordingDepartmentKPI " + departmentID);
            DataProcess<Employees> employeeDA = new DataProcess<Employees>();
            this.grd_EmployeesList.DataSource = FileProcess.LoadTable("Select  [EmployeeID],[VietnamName],[ManagementLevel],[PositionID],[Position] as PositionDescription,[VietnamPosition] as DepartmentNameShort from Employees where Active = 1 And Department=" + departmentID);
        }

        private void hyperlink_EmployeeID_Click(object sender, EventArgs e)
        {
            frm_MSS_Employees frm_Employee = new frm_MSS_Employees(Convert.ToInt32(this.gv_EmployeesList.GetFocusedRowCellValue("EmployeeID").ToString()));
            frm_Employee.Show();
        }

        private void layoutControl1_Click(object sender, EventArgs e)
        {

        }
        private void InitMonth()
        {
            this.lke_ReportMonth.Properties.DataSource = FileProcess.LoadTable("SELECT PayRollMonthID, PayRollMonth FROM PayrollMonth WHERE(FromDate > GETDATE() - 400) ORDER BY PayRollMonthID DESC");
            this.lke_ReportMonth.Properties.ValueMember = "PayRollMonthID";
            this.lke_ReportMonth.Properties.DisplayMember = "PayRollMonth";
        }
        private void InitDepartment()
        {
            this.lke_Department.Properties.DataSource = FileProcess.LoadTable("SELECT DepartmentID, DepartmentName FROM Departments");
            this.lke_Department.Properties.ValueMember = "DepartmentID";
            this.lke_Department.Properties.DisplayMember = "DepartmentName";
        }

        private void InitPosition()
        {
            this.rpi_lke_Positions.DataSource = FileProcess.LoadTable("SELECT PositionID, PositionDescription,PositionVietnam FROM Positions");
            this.rpi_lke_Positions.ValueMember = "PositionDescription";
            this.rpi_lke_Positions.DisplayMember = "PositionDescription";
        }

        private void btn_UpdateEmployeeKPI_Click(object sender, EventArgs e)
        {
            // code to update employee KPI
            this.grcEmployeeKPI.RefreshDataSource();
        }

        private void btn_UpdateDepartmentKPI_Click(object sender, EventArgs e)
        {
            // code to update Department KPI
            this.grcDepartmentKPI.RefreshDataSource();
        }

        private void grvEmployeeKPI_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            this.isChangeForeignFooterCell = false;
            int targetResult = Convert.ToInt32(this.colTarget.SummaryItem.SummaryValue);
            int actualResult = Convert.ToInt32(this.colActual.SummaryItem.SummaryValue);
            string pointResult = string.Empty;
            if (actualResult > 100)
            {
                pointResult = "A";
                this.isChangeForeignFooterCell = true;
            }
            else if (actualResult >= 90 && actualResult <= 100)
            {
                pointResult = "A";
            }
            else if (actualResult >= 80 && actualResult < 90)
            {
                pointResult = "B+";
            }
            else if (actualResult >= 70 && actualResult < 79)
            {
                pointResult = "B";
            }
            else if (actualResult >= 60 && actualResult < 70)
            {
                pointResult = "B-";
            }
            else if (actualResult < 60)
            {
                pointResult = "C";
            }
            this.colResult.SummaryItem.SetSummary(DevExpress.Data.SummaryItemType.Custom, "Kết Quả:" + pointResult);
        }

        private void grvEmployeeKPI_CustomDrawFooterCell(object sender, DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs e)
        {
            if (!e.Column.FieldName.Equals("EmployeeKPIRecordRemark")) return;
            if (this.isChangeForeignFooterCell)
            {
                e.Appearance.ForeColor = Color.Green;
            }
            else
            {
                e.Appearance.ForeColor = Color.Black;
            }
        }

        private void grvDepartmentKPI_CustomDrawFooterCell(object sender, DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs e)
        {
            if (!e.Column.FieldName.Equals("EmployeeKPIRecordRemark")) return;
            if (this.isChangeForeignDeptFooterCell)
            {
                e.Appearance.ForeColor = Color.Green;
            }
            else
            {
                e.Appearance.ForeColor = Color.Black;
            }
        }

        private void grvDepartmentKPI_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            this.isChangeForeignDeptFooterCell = false;
            int targetResult = Convert.ToInt32(this.colDepTarget.SummaryItem.SummaryValue);
            int actualResult = Convert.ToInt32(this.colDepActual.SummaryItem.SummaryValue);
            string pointResult = string.Empty;
            if (actualResult > 100)
            {
                pointResult = "A";
                this.isChangeForeignDeptFooterCell = true;
            }
            else if (actualResult >= 90 && actualResult <= 100)
            {
                pointResult = "A";
            }
            else if (actualResult >= 80 && actualResult < 90)
            {
                pointResult = "B+";
            }
            else if (actualResult >= 70 && actualResult < 79)
            {
                pointResult = "B";
            }
            else if (actualResult >= 60 && actualResult < 70)
            {
                pointResult = "B-";
            }
            else if (actualResult < 60)
            {
                pointResult = "C";
            }
            this.colDepResult.SummaryItem.SetSummary(DevExpress.Data.SummaryItemType.Custom, "Kết Quả:" + pointResult);
        }
    }
}
