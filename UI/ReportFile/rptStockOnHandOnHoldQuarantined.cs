using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;

namespace UI.ReportFile
{
    public partial class rptStockOnHandOnHoldQuarantined : DevExpress.XtraReports.UI.XtraReport
    {
        public rptStockOnHandOnHoldQuarantined()
        {
            InitializeComponent();
            this.xrLabel50.Text = "by " + AppSetting.CurrentUser.LoginName;
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;
        }

        private void rptStockOnHandOnHoldQuarantined_DataSourceDemanded(object sender, EventArgs e)
        {
            try
            {
                this.getStatus.DataSource = this.DataSource;
                this.getStatus.DataMember = this.DataMember;

                this.GroupHeader5.GroupFields.Add(new GroupField("ReceivingOrderNumber"));
                this.GroupHeader4.GroupFields.Add(new GroupField("ProductNumber"));
                this.xrLabel16.DataBindings.Add("Text", this.DataSource, "LocationNumber");
                this.xrLabel15.DataBindings.Add("Text", this.DataSource, "CurrentQuantity");
                this.xrLabel57.DataBindings.Add("Text", this.DataSource, "CurrentQuantity");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
