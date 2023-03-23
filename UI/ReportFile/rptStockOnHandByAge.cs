using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;

namespace UI.ReportFile
{
    public partial class rptStockOnHandByAge : DevExpress.XtraReports.UI.XtraReport
    {
        public rptStockOnHandByAge()
        {
            InitializeComponent();
            this.xrLabel33.Text = "by " + AppSetting.CurrentUser.LoginName;
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;
        }

        private void rptStockOnHandByAge_DataSourceDemanded(object sender, EventArgs e)
        {
            this.mulQty.DataSource = this.DataSource;
            this.mulQty.DataMember = this.DataMember;
        }
    }
}
