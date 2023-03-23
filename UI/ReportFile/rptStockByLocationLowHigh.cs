using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;

namespace UI.ReportFile
{
    public partial class rptStockByLocationLowHigh : DevExpress.XtraReports.UI.XtraReport
    {
        public rptStockByLocationLowHigh()
        {
            InitializeComponent();
            this.xrLabel6.Text = DateTime.Now.ToString("dd/MM/yyyy");
            this.xrLabel31.Text = AppSetting.CurrentUser.LoginName;
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;
        }

        private void rptStockByLocationLowHigh_DataSourceDemanded(object sender, EventArgs e)
        {
            this.GroupHeader1.GroupFields.Add(new GroupField("Low"));
            this.GroupHeader3.GroupFields.Add(new GroupField("LocationNumber"));
            this.GroupHeader2.GroupFields.Add(new GroupField("VeryLowHigh"));
            //this.xrLabel21.DataBindings.Add("Text", this.DataSource, "QtyOfLocations");
        }
    }
}
