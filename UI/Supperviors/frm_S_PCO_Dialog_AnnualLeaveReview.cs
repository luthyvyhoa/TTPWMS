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

namespace UI.Supperviors
{
    public partial class frm_S_PCO_Dialog_AnnualLeaveReview : Common.Controls.frmBaseForm
    {
        private DataTable _tableLeave;
        private short _filterMode;

        public frm_S_PCO_Dialog_AnnualLeaveReview()
        {
            InitializeComponent();
            this.IsFixHeightScreen = false;
            this._tableLeave = new DataTable();
            this._filterMode = 0;           
        }

        private void frm_S_PCO_Dialog_AnnualLeaveReview_Load(object sender, EventArgs e)
        {
            this._tableLeave = FileProcess.LoadTable("WebPayrollAnnualLeaveAll");
            this.chkAll.Checked = true;
            LoadData();
            InitDepartment();
            InitYear();
            SetEvents();
        }

        private void SetEvents()
        {
            this.lkeYear.EditValueChanged += LkeYear_EditValueChanged;
            this.lkeDepartment.EditValueChanged += LkeDepartment_EditValueChanged;
            this.chkAll.CheckedChanged += ChkAll_CheckedChanged;
            this.chkByDepartment.CheckedChanged += ChkByDepartment_CheckedChanged;
            this.chkTemp.CheckedChanged += ChkTemp_CheckedChanged;
            this.btnRefresh.Click += BtnRefresh_Click;
            this.btnClose.Click += BtnClose_Click;
            this.rpi_btn_ViewDetail.Click += Rpi_btn_ViewDetail_Click;
        }

        private void Rpi_btn_ViewDetail_Click(object sender, EventArgs e)
        {
            int employeeID = Convert.ToInt32(this.grvAnnualLeave.GetFocusedRowCellValue("EmployeeID"));
            string employeeName = Convert.ToString(this.grvAnnualLeave.GetFocusedRowCellValue("VietnamName"));
            string fromDate, toDate;

            if(dtFrom.EditValue == null)
            {
                fromDate = String.Empty;
                toDate = String.Empty;
            }
            else
            {
                fromDate = dtFrom.DateTime.ToString("yyyy-MM-dd");
                toDate = dtTo.DateTime.ToString("yyyy-MM-dd");
            }

            frm_S_PCO_Dialog_PayrollDetail frm = new frm_S_PCO_Dialog_PayrollDetail(employeeID, employeeName, fromDate, toDate);
            frm.ShowDialog();
        }

        #region Load Data
        private void LoadData()
        {
            this.grdAnnualLeave.DataSource = this._tableLeave;
        }

        private void InitDepartment()
        {
            DataProcess<Departments> departDA = new DataProcess<Departments>();

            this.lkeDepartment.Properties.DataSource = departDA.Select();
            this.lkeDepartment.Properties.ValueMember = "DepartmentID";
            this.lkeDepartment.Properties.DisplayMember = "DepartmentName";
        }

        private void InitYear()
        {
            DataProcess<PayRollYear> payrollDA = new DataProcess<PayRollYear>();
            List<PayRollYear> listPayRoll = payrollDA.Select().ToList();

            if (listPayRoll.Count < 20)
            {
                this.lkeYear.Properties.DropDownRows = listPayRoll.Count;
            }
            else
            {
                this.lkeYear.Properties.DropDownRows = 20;
            }

            this.lkeYear.Properties.DataSource = listPayRoll;
            this.lkeYear.Properties.ValueMember = "PayRollYearID";
            this.lkeYear.Properties.DisplayMember = "PayRollYearID";
        }
        #endregion

        #region Events
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            switch (this._filterMode)
            {
                case 0:
                    {
                        this._tableLeave = FileProcess.LoadTable("WebPayrollAnnualLeaveAll");
                        break;
                    }
                case 1:
                    {
                        break;
                    }
                case 2:
                    {
                        this._tableLeave = FileProcess.LoadTable("STPayrollAnnualLeaveByDepartment");
                        break;
                    }
            }
        }

        private void ChkTemp_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkTemp.Checked)
            {
                this.chkByDepartment.Checked = false;
                this.chkAll.Checked = false;
                this._filterMode = 2;
                this._tableLeave = FileProcess.LoadTable("STPayrollAnnualLeaveByDepartment");
                LoadData();
            }
        }

        private void ChkByDepartment_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkByDepartment.Checked)
            {
                this.chkAll.Checked = false;
                this.chkTemp.Checked = false;
                this._filterMode = 1;
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
            if (this.chkAll.Checked)
            {
                this.chkByDepartment.Checked = false;
                this.chkTemp.Checked = false;
                this._filterMode = 0;
                this._tableLeave = FileProcess.LoadTable("WebPayrollAnnualLeaveAll");
                LoadData();
            }
        }

        private void LkeDepartment_EditValueChanged(object sender, EventArgs e)
        {
            if (this.dtFrom.EditValue == null)
            {
                this.lkeYear.Focus();
                this.lkeYear.ShowPopup();
            }
            else
            {
                this._tableLeave = FileProcess.LoadTable("STPayrollAnnualLeaveByDepartment @DepartmentID = " + Convert.ToInt32(this.lkeDepartment.EditValue) + ", @FromDate = '" + this.dtFrom.DateTime.ToString("yyyy-MM-dd") + "', @ToDate = '" + this.dtTo.DateTime.ToString("yyyy-MM-dd") + "'");
                LoadData();
            }
        }

        private void LkeYear_EditValueChanged(object sender, EventArgs e)
        {
            this.dtFrom.EditValue = Convert.ToDateTime(this.lkeYear.GetColumnValue("FromDate"));
            this.dtTo.EditValue = Convert.ToDateTime(this.lkeYear.GetColumnValue("ToDate"));
        }
        #endregion
    }
}
