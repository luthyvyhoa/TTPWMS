using System.Windows.Forms;
using Common.Controls;
using DA;
using UI.Helper;
using System.Data;
namespace UI.MasterSystemSetup
{
    public partial class frm_MSS_ChangePass : frmBaseForm
    {
        private string password = string.Empty;
        private bool isValid = false;
        public frm_MSS_ChangePass()
        {
            InitializeComponent();
        }

        private void txtReNewPassword_Leave(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtNewPassword.Text) || string.IsNullOrEmpty(this.txtReNewPassword.Text)) return;
            if (!this.txtNewPassword.Text.Trim().Equals(this.txtReNewPassword.Text.Trim()))
            {
                MessageBox.Show("New password is inconsistency", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtReNewPassword.SelectAll();
                this.txtReNewPassword.Focus();
            }
            else
            {
                this.password = this.txtNewPassword.Text.Trim();
                this.isValid = true;
            }
        }

        private void txtCurrentPassword_Leave(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtCurrentPassword.Text))
            {
                this.txtCurrentPassword.Focus();
                return;
            }

            string pass = this.txtCurrentPassword.Text.Trim();
            var listUser = FileProcess.LoadTable("STUserAccountLogin @UserName='" + AppSetting.CurrentUser.LoginName + "', @Password='" + txtCurrentPassword.Text + "'");
            if (listUser == null || listUser.Rows.Count <= 0)
            {
                MessageBox.Show("This password is incorrect", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtCurrentPassword.SelectAll();
                this.txtCurrentPassword.Focus();
            }
            else
            {
                this.txtNewPassword.ReadOnly = false;
                this.txtReNewPassword.ReadOnly = false;
            }
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtNewPassword.Text.Trim()) || !this.isValid)
            {
                MessageBox.Show("Invalid password", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            System.Data.Entity.Core.Objects.ObjectParameter returnStatus = new System.Data.Entity.Core.Objects.ObjectParameter("ResultReturn", "");
            DataProcess<object> obj = new DataProcess<object>();
            int userUpdate = STUserAccountChangePassword(returnStatus, AppSetting.CurrentUser.LoginName, txtCurrentPassword.Text, txtNewPassword.Text);
            string resultStatus = returnStatus.Value.ToString();
            if (userUpdate > 0)
            {
                MessageBox.Show(resultStatus);
                this.isValid = false;
            }
            else
            {
                MessageBox.Show(resultStatus);
            }
        }
        public int STUserAccountChangePassword(System.Data.Entity.Core.Objects.ObjectParameter ResultReturn, string UserName, string Password, string NewPassword)
        {
            using (var context = new SwireDBEntities())
            {
                return context.STUserAccountChangePassword(ResultReturn, UserName, Password, NewPassword);
            }
        }

        private void txtNewPassword_Leave(object sender, System.EventArgs e)
        {
            if (this.txtNewPassword.Text.Trim().Length < 6)
            {
                this.dxErrorProvider1.SetError(this.txtNewPassword, "The password is at least 6 character");
                this.txtNewPassword.SelectAll();
                this.txtNewPassword.Focus();
            }
            else
                this.dxErrorProvider1.ClearErrors();
        }
    }
}
