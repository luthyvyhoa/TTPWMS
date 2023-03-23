using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;

namespace UI.ReportFile
{
    public partial class rptQuarantineNote : DevExpress.XtraReports.UI.XtraReport
    {
        public rptQuarantineNote(string fullName)
        {
            InitializeComponent();

            InitData(fullName);
        }

        private void InitData(string fullName)
        {
            lblUsernameFooter.Text = "by " + AppSetting.CurrentUser.LoginName;
            lblVietnameseName.Text = fullName;
        }
    }
}
