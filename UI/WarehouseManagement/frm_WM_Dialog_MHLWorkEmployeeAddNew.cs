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
using DevExpress.XtraEditors;
using Common.Process;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_Dialog_MHLWorkEmployeeAddNew : frmBaseForm
    {
        private int _workID;
        private bool _isAddNew;
        private bool _isValueChanged;

        public frm_WM_Dialog_MHLWorkEmployeeAddNew(int workID)
        {
            InitializeComponent();
            this.IsFixHeightScreen = false;
            this._workID = workID;
            this._isAddNew = true;
            this._isValueChanged = false;
            InitEmployee();
            InitRemark();
            SetEvents();
        }

        public int WorkID
        {
            get
            {
                return this._workID;
            }
            set
            {
                this._workID = value;

            }
        }

        private void frm_WM_Dialog_MHLWorkEmployeeAddNew_Load(object sender, EventArgs e)
        {
            this.txtEmployeeID.Focus();
            this.ActiveControl = this.txtEmployeeID;
        }

        private void SetEvents()
        {
            this.txtEmployeeID.KeyDown += txtEmployeeID_KeyDown;
            this.lkeEmployee.EditValueChanged += lkeEmployee_EditValueChanged;
            this.lkeEmployee.LostFocus += lkeEmployee_LostFocus;
            this.btnOK.Click += btnOK_Click;
            this.btnCancel.Click += btnCancel_Click;
            this.FormClosing += frm_WM_Dialog_MHLWorkEmployeeAddNew_FormClosing;
        }

        void frm_WM_Dialog_MHLWorkEmployeeAddNew_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        void txtEmployeeID_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.KeyCode.Equals(Keys.Enter)) return;
            if (!string.IsNullOrEmpty(this.txtEmployeeID.Text))
            {
                // There is employeeID
                Employees employee = null;
                if (this._isAddNew)
                {
                    try
                    {
                        var currentEmployee = AppSetting.EmployessList.Where(em => em.EmployeeID == Convert.ToInt32(this.txtEmployeeID.Text) && em.PerformanceStatus == true && em.Active == true).FirstOrDefault();
                         employee = currentEmployee;
                    }
                    catch (Exception)
                    {
                        XtraMessageBox.Show("Please enter correct Employee ID, please check Active and Performance Status", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.txtEmployeeID.SelectAll();
                        this.txtEmployeeID.Focus();
                        return;
                    }


                    string remark = "";
                    if (employee == null)
                    {
                        XtraMessageBox.Show("Please enter correct Employee ID, please check Active and Performance Status", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.txtEmployeeID.SelectAll();
                        this.txtEmployeeID.Focus();
                    }
                    else
                    {
                        SetPosition(employee.EmployeeID, ref remark);
                        this._isAddNew = false;
                        this.lkeEmployee.EditValue = employee.VietnamName;
                        this.cbxRemark.Text = remark;
                        this._isAddNew = true;
                        this.speQuantity.Focus();
                        this.speQuantity.SelectAll();
                    }
                }
                this._isValueChanged = false;
            }
            else
            {
                //There is not employee 
                this.btnCancel.Focus();
            }
        }

        #region Load Data
        private void InitRemark()
        {
            //"Boc xep"; "Tai xe"; "Kiem hang"; "Pallet"; "Komatsu"; "Training"; "Picker"
            var listRemarkSource = new List<string> { "Boc xep", "Tai xe", "Kiem hang", "Pallet", "Komatsu", "Training", "Picker" };
            this.cbxRemark.Properties.Items.AddRange(listRemarkSource);
        }

        private void InitEmployee()
        {
            this.lkeEmployee.Properties.DataSource = AppSetting.EmployessList.Where(e => e.PerformanceStatus == true && e.Active == true && e.Department != 5);
            this.lkeEmployee.Properties.ValueMember = "VietnamName";
            this.lkeEmployee.Properties.DisplayMember = "VietnamName";
        }
        #endregion

        #region Events
        private void lkeEmployee_EditValueChanged(object sender, EventArgs e)
        {
            if (this._isAddNew)
            {
                string remark = "";

                SetPosition(Convert.ToInt32(this.lkeEmployee.GetColumnValue("EmployeeID")), ref remark);
                this._isAddNew = false;
                this.txtEmployeeID.Text = Convert.ToString(this.lkeEmployee.GetColumnValue("EmployeeID"));
                this.cbxRemark.Text = remark;
                this._isAddNew = true;
            }
        }

        private void lkeEmployee_LostFocus(object sender, EventArgs e)
        {
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtEmployeeID.Text) || this.lkeEmployee.EditValue == null)
            {
                XtraMessageBox.Show("Please enter correct employee !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    string remark = "N'" + this.cbxRemark.Text;
                    DataProcess<object> workDA = new DataProcess<object>();
                    int result = workDA.ExecuteNoQuery("STMHLWorkDetailExecute @MHLWorkID = {0}, @Flag = {1}, @EmployeeID = {2}, @Quantity = {3}, @DetailRemark = {4}, @CreatedBy = {5}", this._workID, 1, Convert.ToInt32(this.txtEmployeeID.Text), this.speQuantity.Value, remark, AppSetting.CurrentUser.LoginName);

                    this._isAddNew = false;
                    this.txtEmployeeID.Text = "";
                    this.lkeEmployee.EditValue = null;
                    this.cbxRemark.EditValue = null;
                    this._isAddNew = true;
                    this.txtEmployeeID.SelectAll();
                    this.txtEmployeeID.Focus();
                    Common.Process.RefreshData.OnReloadData(new ST_WMS_LoadWorkDetails_Result(), null);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        private void SetPosition(int employeeID, ref string remark)
        {
            int positionID = AppSetting.EmployessList.Where(e => e.EmployeeID == employeeID).FirstOrDefault().PositionID;
            int managementLevel = AppSetting.EmployessList.Where(e => e.EmployeeID == employeeID).FirstOrDefault().ManagementLevel;

            if (managementLevel <= 30)
            {
                remark = "Supervisor";
                return;
            }

            if (managementLevel <= 42)
            {
                if (positionID == 60)
                {
                    remark = "Komatsu";
                    return;
                }
                else
                {
                    remark = "Tai xe";
                    return;
                }
            }

            if (managementLevel < 50)
            {
                remark = "Kiem hang";
                return;
            }

            if (managementLevel == 50)
            {
                remark = "Pallet";
                return;
            }

            if (managementLevel > 50)
            {
                remark = "Boc xep";
                return;
            }
        }

        private void speQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.KeyCode.Equals(Keys.Enter)) return;
            this.btnOK.Focus();
        }
    }
}
