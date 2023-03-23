using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common.Controls
{
    public partial class frmBaseFormNormal : Form
    {
        public frmBaseFormNormal()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Load icon form
            this.Icon = Properties.CommonResource.Emergent;
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
    }
}
