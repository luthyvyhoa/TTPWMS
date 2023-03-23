using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;

namespace UI.ReportFile
{
    public partial class rptWarnings : DevExpress.XtraReports.UI.XtraReport
    {
        public rptWarnings()
        {
            InitializeComponent();
            this.xrLabel28.Text = AppSetting.CurrentUser.LoginName;
            this.xrPictureBox1.Image = UI.Properties.Resources.ImageCompany;
        }

        private void rptWarnings_BeforePrint(object sender, CancelEventArgs e)
        {
            try
            {
                bool isWarning = (bool)this.GetCurrentColumnValue("Official");
                if (isWarning)
                {
                    this.lblTitle.Text = "OFFICIAL WARNING - CẢNH CÁO CHÍNH THỨC";
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
