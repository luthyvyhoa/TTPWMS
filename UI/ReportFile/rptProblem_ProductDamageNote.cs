using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;

namespace UI.ReportFile
{
    public partial class rptProblem_ProductDamageNote : DevExpress.XtraReports.UI.XtraReport
    {
        public rptProblem_ProductDamageNote()
        {
            InitializeComponent();
            this.xrLabel51.Text = AppSetting.CurrentUser.LoginName;
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;
        }
    }
}
