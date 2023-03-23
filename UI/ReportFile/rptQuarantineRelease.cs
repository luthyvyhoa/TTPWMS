using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;
using DA;

namespace UI.ReportFile
{
    public partial class rptQuarantineRelease : DevExpress.XtraReports.UI.XtraReport
    {
        public rptQuarantineRelease(string fullName)
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
