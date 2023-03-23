using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace UI.ReportFile
{
    public partial class rptLandingReport : DevExpress.XtraReports.UI.XtraReport
    {
        public rptLandingReport(string loginName)
        {
            InitializeComponent();
            this.xrLabel49.Text = "by " + loginName;
        }

    }
}
