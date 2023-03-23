using System;
using System.Linq;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;
using DA;

namespace UI.ReportFile
{
    public partial class rptMonthlyLunchRecordingByPlaces : DevExpress.XtraReports.UI.XtraReport
    {
        public rptMonthlyLunchRecordingByPlaces()
        {
            InitializeComponent();
            string employeeName = AppSetting.CurrentEmployee.FullName;
            this.xrLabel150.Text = employeeName;
            this.xrLabel3.Text = AppSetting.CurrentUser.LoginName;
            this.xrPictureBox1.Image = UI.Properties.Resources.ImageCompany;
        }

        private void rptMonthlyLunchRecordingByPlaces_DataSourceDemanded(object sender, EventArgs e)
        {
            this.GroupHeader1.GroupFields.Add(new GroupField("PlaceDescription"));
            this.xrLabel128.DataBindings.Add("Text", this.DataSource, "26");
            this.xrLabel129.DataBindings.Add("Text", this.DataSource, "27");
            this.xrLabel130.DataBindings.Add("Text", this.DataSource, "28");
            this.xrLabel131.DataBindings.Add("Text", this.DataSource, "29");
            this.xrLabel132.DataBindings.Add("Text", this.DataSource, "30");
            this.xrLabel133.DataBindings.Add("Text", this.DataSource, "31");
            this.xrLabel134.DataBindings.Add("Text", this.DataSource, "01");
            this.xrLabel135.DataBindings.Add("Text", this.DataSource, "02");
            this.xrLabel136.DataBindings.Add("Text", this.DataSource, "03");
            this.xrLabel137.DataBindings.Add("Text", this.DataSource, "04");
            this.xrLabel138.DataBindings.Add("Text", this.DataSource, "05");
            this.xrLabel139.DataBindings.Add("Text", this.DataSource, "06");
            this.xrLabel140.DataBindings.Add("Text", this.DataSource, "07");
            this.xrLabel141.DataBindings.Add("Text", this.DataSource, "08");
            this.xrLabel142.DataBindings.Add("Text", this.DataSource, "09");
            this.xrLabel143.DataBindings.Add("Text", this.DataSource, "10");
            this.xrLabel144.DataBindings.Add("Text", this.DataSource, "11");
            this.xrLabel145.DataBindings.Add("Text", this.DataSource, "12");
            this.xrLabel146.DataBindings.Add("Text", this.DataSource, "13");
            this.xrLabel115.DataBindings.Add("Text", this.DataSource, "14");
            this.xrLabel116.DataBindings.Add("Text", this.DataSource, "15");
            this.xrLabel117.DataBindings.Add("Text", this.DataSource, "16");
            this.xrLabel118.DataBindings.Add("Text", this.DataSource, "17");
            this.xrLabel119.DataBindings.Add("Text", this.DataSource, "18");
            this.xrLabel120.DataBindings.Add("Text", this.DataSource, "19");
            this.xrLabel121.DataBindings.Add("Text", this.DataSource, "20");
            this.xrLabel122.DataBindings.Add("Text", this.DataSource, "21");
            this.xrLabel123.DataBindings.Add("Text", this.DataSource, "22");
            this.xrLabel124.DataBindings.Add("Text", this.DataSource, "23");
            this.xrLabel125.DataBindings.Add("Text", this.DataSource, "24");
            this.xrLabel126.DataBindings.Add("Text", this.DataSource, "25");
            this.xrLabel127.DataBindings.Add("Text", this.DataSource, "Total");
        }
    }
}
