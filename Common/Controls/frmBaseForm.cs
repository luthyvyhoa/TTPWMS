using System.Windows.Forms;
using Common.Data;
using System;
using System.Data;
using DA;
//using Microsoft.VisualBasic;
//using UI;
namespace Common.Controls
{
    public partial class frmBaseForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private bool isFixHeightScreen = true;
        protected bool IsAccessGranted = false;
        protected DataTable actionsList = null;
        private string functionName = string.Empty;
        private int UserApplicationRoleGroupFunctionId = 0;


        public frmBaseForm()
        {
            // Init controls to designer
            InitializeComponent();

            // Validate function permission of user
            if (!this.ValidateActiveForm())
            {
                this.Enabled = false;
            }
        }

        /// <summary>
        /// Definition height form alway aqual height screen
        /// </summary>
        public bool IsFixHeightScreen
        {
            get
            {
                return this.isFixHeightScreen;
            }
            set
            {
                this.isFixHeightScreen = value;
            }
        }

        /// <summary>
        /// Validate function permission of current user
        /// </summary>
        private bool ValidateActiveForm()
        {
            // If doesn't any function in list then disable form
            if (UserPermissionData.FunctionsPermisstionList == null)
            {
                return false;
            }

            // Get current form name
            string formName = this.ToString().Split(',')[0].Split('.')[2];
            this.IsAccessGranted = true;
            // Detect current form has exist in function list
            foreach (System.Data.DataRow funtionName in UserPermissionData.FunctionsPermisstionList.Rows)
            {
                this.IsAccessGranted = true;
                if (funtionName["FunctionName"].ToString().Trim().Equals(formName))
                {
                    this.IsAccessGranted = true;
                    this.functionName = formName;
                    this.UserApplicationRoleGroupFunctionId = Convert.ToInt32(funtionName["UserApplicationRoleGroupFunctionId"]);
                    return true;
                }
            }
            //return false;
            return true;
        }

        private void ValidateActionForm()
        {
            if (this.UserApplicationRoleGroupFunctionId <= 0) return;
            var tbActionAllow = FileProcess.LoadTable("ST_WMS_LoadApplicationRoleGroupsFunctionActionByUser @UserApplicationRoleGroupFunctionId=" + this.UserApplicationRoleGroupFunctionId);
            if (tbActionAllow == null || tbActionAllow.Rows.Count <= 0) return;

            // Load all action in form
            if (this.actionsList == null || this.actionsList.Rows.Count <= 0) return;

            // Disactive all control in form
            foreach (DataRow actionName in this.actionsList.Rows)
            {
                // Find action has exist then disable it
                string currentControlName = Convert.ToString(actionName["ControlName"]);
                Control[] controls= this.Controls.Find(currentControlName,true);
                if (controls == null || controls.Length <= 0) continue;
                else
                    controls[0].Enabled = false;
            }

            // Active controls is allow active
            foreach (DataRow actionName in tbActionAllow.Rows)
            {
                // Find action is allow active
                string currentControlName = Convert.ToString(actionName["ControlName"]);
                Control[] controls = this.Controls.Find(currentControlName, true);
                if (controls == null || controls.Length <= 0) continue;
                else
                    controls[0].Enabled = true;
            }

        }

        /// <summary>
        /// Check actions permission when load form
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (this.IsAccessGranted)
            {
                this.SetPermissionControl();

                // Load icon form
                this.Icon = Properties.CommonResource.Emergent;
            }
        }

        /// <summary>
        /// Set permission control
        /// </summary>
        protected virtual void SetPermissionControl()
        {
            this.actionsList = FileProcess.LoadTable("ST_WMS_LoadAllActionsByFuntion @FuntionName='" + functionName + "'");

            // Validate action permission of user
            //this.ValidateActionForm();
        }

        /// <summary>
        /// Close form when ESC key press
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        /// <summary>
        /// Executes the on UI thread.
        /// </summary>
        /// <param name="action">The action.</param>
        public virtual void ExecuteOnUIThread(Action action)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(action);
            }
            else
            {
                action?.Invoke();
            }
        }

        protected override bool ProcessCmdKey(ref Message message, Keys keys)
        {
            if (this.Modal)
            {
                return false;
            }

            switch (keys)
            {
                case Keys.F12 | Keys.F11:
                    //Microsoft.VisualBasic.Interaction.InputBox("Question?", "Title", "Default Text");
                    ShowMyDialogBox();
                    return false;
            }

            return false;
        }
        public void ShowMyDialogBox()
        {
            //UI.Helper.frmScanInput textDialog = new frmScanInput();
            //textDialog.Show();
            //textDialog.BringToFront();
            // Show testDialog as a modal dialog and determine if DialogResult = OK.
            //if (testDialog.ShowDialog(this) == DialogResult.OK)
            //{
            //    // Read the contents of testDialog's TextBox.
            //    this.textResult.Text = testDialog.textResult.Text;
            //}
            //else
            //{
            //    this.textResult.Text = "Cancelled";
            //}
            //testDialog.Dispose();
        }

    }
}