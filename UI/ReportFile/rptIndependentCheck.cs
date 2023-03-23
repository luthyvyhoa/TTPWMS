using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;

namespace UI.ReportFile
{
    public partial class rptIndependentCheck : DevExpress.XtraReports.UI.XtraReport
    {
        public rptIndependentCheck()
        {
            InitializeComponent();

            this.xrLabel40.Text = "Created by " + AppSetting.CurrentUser.LoginName;
        }

    }
}
