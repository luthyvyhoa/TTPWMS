using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;

namespace UI.ReportFile
{
    public partial class rptQAWeeklyReport : DevExpress.XtraReports.UI.XtraReport
    {
        public rptQAWeeklyReport()
        {
            InitializeComponent();
            this.xrLabel6.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm tt");
            this.xrLabel55.Text = "by " + AppSetting.CurrentUser.LoginName;
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;

        }

        private void rptQAWeeklyReport_DataSourceDemanded(object sender, EventArgs e)
        {
            this.GroupHeader2.GroupFields.Add(new GroupField("ProductGroupDescription"));

            this.xrLabel44.DataBindings.Add("Text", this.DataSource, "SumOfAfterDPQuantity");
            this.xrLabel45.DataBindings.Add("Text", this.DataSource, "RemainUnits");
            this.xrLabel46.DataBindings.Add("Text", this.DataSource, "RemainWeight");

            this.sumRemainWeight.DataSource = this.DataSource;
            this.sumRemainWeight.DataMember = this.DataMember;
            this.sumUnit.DataSource = this.DataSource;
            this.sumUnit.DataMember = this.DataMember;
            this.sumWeight.DataSource = this.DataSource;
            this.sumWeight.DataMember = this.DataMember;
        }
    }
}
