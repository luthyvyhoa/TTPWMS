using DA;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
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
    public partial class frm_S_PCO_Dialog_EmployeeInOut : Common.Controls.frmBaseForm
    {
        private DataTable _listEmployeeInOut;
        private DateTime _currentDate;

        public frm_S_PCO_Dialog_EmployeeInOut(DateTime currentDate)
        {
            InitializeComponent();
            this._listEmployeeInOut = new DataTable();
            this._currentDate = currentDate;
        }

        private void frm_S_PCO_Dialog_EmployeeInOut_Load(object sender, EventArgs e)
        {
            try
            {
                this._listEmployeeInOut = FileProcess.LoadTable("STGate_EmployeeInOutByDateWMS @ReportDate = '" + this._currentDate.ToString("yyyy-MM-dd")
                    + "', @flag = 1, @DepartmentID = 0,@varStoreID=" + AppSetting.StoreID);
                this.chkAll.Checked = true;
                InitDepartments();
                LoadData();

                SetEvents();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SetEvents()
        {
            this.chkAll.CheckedChanged += ChkAll_CheckedChanged;
            this.chkByDepartment.CheckedChanged += ChkByDepartment_CheckedChanged;
            this.chkMorning.CheckedChanged += ChkMorning_CheckedChanged;
            this.chkAfternoon.CheckedChanged += ChkAfternoon_CheckedChanged;
            this.lkeDepartment.EditValueChanged += LkeDepartment_EditValueChanged;
        }

        #region Events
        private void LkeDepartment_EditValueChanged(object sender, EventArgs e)
        {
            this._listEmployeeInOut = this._listEmployeeInOut = FileProcess.LoadTable("STGate_EmployeeInOutByDateWMS @ReportDate = '" + this._currentDate.ToString("yyyy-MM-dd") + "', @flag = 1, @DepartmentID = " + Convert.ToInt16(this.lkeDepartment.EditValue));
            LoadData();
        }

        private void ChkAfternoon_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAfternoon.Checked)
            {
                this.chkAll.Checked = false;
                this.chkByDepartment.Checked = false;
                this.chkMorning.Checked = false;
                this._listEmployeeInOut = this._listEmployeeInOut = FileProcess.LoadTable("STGate_EmployeeInOutByDateWMS @ReportDate = '" + this._currentDate.ToString("yyyy-MM-dd") + "', @flag = 3, @DepartmentID = 0");
                LoadData();
            }
        }

        private void ChkMorning_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMorning.Checked)
            {
                this.chkAfternoon.Checked = false;
                this.chkByDepartment.Checked = false;
                this.chkAll.Checked = false;
                this._listEmployeeInOut = this._listEmployeeInOut = FileProcess.LoadTable("STGate_EmployeeInOutByDateWMS @ReportDate = '" + this._currentDate.ToString("yyyy-MM-dd") + "', @flag = 2, @DepartmentID = 0");
                LoadData();
            }
        }

        private void ChkByDepartment_CheckedChanged(object sender, EventArgs e)
        {
            if (chkByDepartment.Checked)
            {
                this.chkAfternoon.Checked = false;
                this.chkAll.Checked = false;
                this.chkMorning.Checked = false;
                this.lkeDepartment.ReadOnly = false;
                this.lkeDepartment.Focus();
                this.lkeDepartment.ShowPopup();
            }
            else
            {
                this.lkeDepartment.ReadOnly = true;
            }
        }

        private void ChkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked)
            {
                this.chkAfternoon.Checked = false;
                this.chkByDepartment.Checked = false;
                this.chkMorning.Checked = false;
                this._listEmployeeInOut = this._listEmployeeInOut = FileProcess.LoadTable("STGate_EmployeeInOutByDateWMS @ReportDate = '" + this._currentDate.ToString("yyyy-MM-dd") + "', @flag = 1, @DepartmentID = 0");
                LoadData();

            }
        }
        #endregion

        #region Load Data
        private void LoadData()
        {
            this.grdEmployeeInOut.DataSource = this._listEmployeeInOut;
            CalculateSummary();
        }

        private void InitDepartments()
        {
            DataProcess<Departments> departmentDA = new DataProcess<Departments>();

            this.lkeDepartment.Properties.DataSource = departmentDA.Select();
            this.lkeDepartment.Properties.DisplayMember = "DepartmentName";
            this.lkeDepartment.Properties.ValueMember = "DepartmentID";
        }

        private void CalculateSummary()
        {
            int remain = 0;
            int totalCheckOut = 0;

            this.txtTotalRegistered.Text = this._listEmployeeInOut.Rows.Count.ToString();

            foreach (DataRow item in this._listEmployeeInOut.Rows)
            {
                if (Convert.ToBoolean(item["CheckOut"]))
                {
                    totalCheckOut += 1;
                }
            }

            remain = this._listEmployeeInOut.Rows.Count - totalCheckOut;
            this.txtRemain.Text = remain.ToString();
        }
        #endregion
    }
}
