using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using UI.Helper;

namespace UI.ReportFile
{
    public partial class rptStockOneLocation : DevExpress.XtraReports.UI.XtraReport
    {
        public rptStockOneLocation()
        {
            InitializeComponent();
            this.xrLabel19.Text = "by " + AppSetting.CurrentUser.LoginName;
        }

        private void rptStockOneLocation_DataSourceDemanded(object sender, EventArgs e)
        {
            this.GroupHeader2.GroupFields.Add(new GroupField("ProductNumber"));
        }
    }
}
