using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;

namespace UI.ReportFile
{
    public partial class rptWorkExplanationReport : DevExpress.XtraReports.UI.XtraReport
    {
        public rptWorkExplanationReport(string month, string fromDate, string toDate)
        {
            InitializeComponent();
            this.xrLabel3.Text = month;
            this.xrLabel5.Text = fromDate;
            this.xrLabel8.Text = toDate;
            this.xrLabel37.Text = AppSetting.CurrentUser.LoginName;
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;
        }

        private void rptWorkExplanationReport_DataSourceDemanded(object sender, EventArgs e)
        {
            this.GroupHeader2.GroupFields.Add(new GroupField("ServiceID"));
            this.xrLabel32.DataBindings.Add("Text", this.DataSource, "Quantity");
            this.xrLabel33.DataBindings.Add("Text", this.DataSource, "Work_Quantity");
        }
    }
}
