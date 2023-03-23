using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;

namespace UI.ReportFile
{
    public partial class rptPayRollAnnualSummary : DevExpress.XtraReports.UI.XtraReport
    {
        public rptPayRollAnnualSummary()
        {
            InitializeComponent();
            string employeeName = AppSetting.CurrentEmployee.FullName;
            this.xrLabel59.Text = employeeName;
            this.xrLabel45.Text = AppSetting.CurrentUser.LoginName;
            this.xrPictureBox1.Image = UI.Properties.Resources.ImageCompany;
        }

    }
}
