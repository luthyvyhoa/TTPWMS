using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;

namespace UI.ReportFile
{
    public partial class rptEmployeeCurrentInWharehouse : DevExpress.XtraReports.UI.XtraReport
    {
        public rptEmployeeCurrentInWharehouse()
        {
            InitializeComponent();
            this.xrLabel22.Text = AppSetting.CurrentUser.LoginName;
        }

    }
}
