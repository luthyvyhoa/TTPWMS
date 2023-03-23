﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;

namespace UI.ReportFile
{
    public partial class rptStockByLocationLocationDetailWeightInners_ByProduct : DevExpress.XtraReports.UI.XtraReport
    {
        public rptStockByLocationLocationDetailWeightInners_ByProduct()
        {
            InitializeComponent();
            this.xrLabel6.Text = DateTime.Now.ToString("dd/MM/yyyy");
            this.xrLabel31.Text = AppSetting.CurrentUser.LoginName;
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;
        }

        private void rptStockByLocationLocationDetailWeightInners_ByProduct_DataSourceDemanded(object sender, EventArgs e)
        {
            this.GroupHeader2.GroupFields.Add(new GroupField("LocationNumber"));
            this.GroupHeader3.GroupFields.Add(new GroupField("ID"));
        }
    }
}
