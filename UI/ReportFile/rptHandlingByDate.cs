using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;

namespace UI.ReportFile
{
    public partial class rptHandlingByDate : DevExpress.XtraReports.UI.XtraReport
    {
        public rptHandlingByDate(DateTime fromDate, DateTime toDate)
        {
            InitializeComponent();
            this.xrPageInfo1.Format = AppSetting.CurrentUser.LoginName + " - {0:dd/MM/yyyy HH:mm tt}";
            this.xrLabel4.Text = fromDate.ToString("dd/MM/yyyy");
            this.xrLabel8.Text = toDate.ToString("dd/MM/yyyy");
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;
        }

        private void rptHandlingByDate_BeforePrint(object sender, CancelEventArgs e)
        {
            this.xrLabel16.DataBindings.Add("Text", this.DataSource, "TotalWeightIn");
            this.xrLabel15.DataBindings.Add("Text", this.DataSource, "TotalWeightOut");
            this.xrLabel14.DataBindings.Add("Text", this.DataSource, "TotalInOut");
        }
    }
}
