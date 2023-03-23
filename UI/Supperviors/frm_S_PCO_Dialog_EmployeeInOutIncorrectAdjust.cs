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
    public partial class frm_S_PCO_Dialog_EmployeeInOutIncorrectAdjust : Common.Controls.frmBaseForm
    {
        private STGate_EmployeeInOutIncorrect_Result _employeeInOut;

        public frm_S_PCO_Dialog_EmployeeInOutIncorrectAdjust(STGate_EmployeeInOutIncorrect_Result employeeInOut)
        {
            InitializeComponent();
            this._employeeInOut = employeeInOut;
        }

        private void frm__S_PCO_Dialog_EmployeeInOutIncorrectAdjust_Load(object sender, EventArgs e)
        {
            this.txtEmployeeID.Text = this._employeeInOut.EmployeeID.ToString();
            this.txtEmployeeName.Text = this._employeeInOut.VietnamName;
            this.dtTimeIn.EditValue = this._employeeInOut.TimeIn;
            this.dtTimeOut.EditValue = this._employeeInOut.TimeOut;
            SetEvents();
        }

        private void SetEvents()
        {
            this.btnUpdate.Click += btnUpdate_Click;
            this.btnCancel.Click += btnCancel_Click;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(this.txtRemark.Text))
            {
                XtraMessageBox.Show("Please input reason !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtRemark.Focus();
            }
            else
            {
                if(this.dtTimeOut.EditValue == null)
                {
                    XtraMessageBox.Show("Please input new Time out !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.dtTimeOut.Focus();
                    this.dtTimeOut.ShowPopup();
                }
                else
                {
                    DataProcess<object> employeeInOutDA = new DataProcess<object>();

                    int result = employeeInOutDA.ExecuteNoQuery("STGate_EmployeeInOutIncorrectUpdate @EmployeeInOutID = {0}, @newTimeOut = {1}, @CreatedBy = {2}, @Remark = {3}, @newTimeIn = {4}", this._employeeInOut.EmployeeInOutID, this.dtTimeOut.DateTime, AppSetting.CurrentUser.LoginName, this.txtRemark.Text, this.dtTimeIn.DateTime);

                    if(result == -2)
                    {
                        XtraMessageBox.Show("Unexpected Error !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.btnUpdate.DialogResult = DialogResult.Cancel;
                    }
                }
            }
        }
    }
}
