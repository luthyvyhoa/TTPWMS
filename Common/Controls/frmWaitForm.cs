using DevExpress.XtraWaitForm;
using System;

namespace Common.Controls
{
    public partial class frmWaitForm : WaitForm
    {
        public frmWaitForm()
        {
            InitializeComponent();
            this.progressPanel1.AutoHeight = true;
            this.ShowOnTopMode = ShowFormOnTopMode.AboveParent;
            this.BringToFront();
            SetCaption("Please Wait");
            SetDescription("Loading...");
        }

        #region Overrides

        public override void SetCaption(string caption)
        {
            base.SetCaption(caption);
            this.progressPanel1.Caption = caption;
        }
        public override void SetDescription(string description)
        {
            base.SetDescription(description);
            this.progressPanel1.Description = description;
        }
        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum WaitFormCommand
        {
        }
    }
}