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
                    return true;
                }
            }
            //return false;
            return true;
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