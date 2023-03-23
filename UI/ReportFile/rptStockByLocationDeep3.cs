using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;
using System.Collections.Generic;
using DA;

namespace UI.ReportFile
{
    public partial class rptStockByLocationDeep3 : DevExpress.XtraReports.UI.XtraReport
    {


        public rptStockByLocationDeep3()
        {
            InitializeComponent();
            this.xrLabel17.Text = DateTime.Now.ToString("dd/MM/yyyy");
            this.xrLabel28.Text = AppSetting.CurrentUser.LoginName;
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;
        }

        private void rptStockByLocationDeep3_DataSourceDemanded(object sender, EventArgs e)
        {
            this.GroupHeader2.GroupFields.Add(new GroupField("LocationNumber"));
            this.GroupHeader1.GroupFields.Add(new GroupField("ID"));
            this.countLocation.DataSource = this.DataSource;
            this.countLocation.DataMember = this.DataMember;
            this.sumQty.DataSource = this.DataSource;
            this.sumQty.DataMember = this.DataMember;
        }
    }
}
