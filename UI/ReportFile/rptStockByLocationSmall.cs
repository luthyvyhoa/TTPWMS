﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;

namespace UI.ReportFile
{
    public partial class rptStockByLocationSmall : DevExpress.XtraReports.UI.XtraReport
    {
        public rptStockByLocationSmall()
        {
            InitializeComponent();
            this.xrLabel31.Text = "Printed by " + AppSetting.CurrentUser.LoginName.ToUpper() + " - " + DateTime.Now.ToString("dddd, d MMMM, yyyy h:mm:ss tt");
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;
        }

        private void rptStockByLocationSmall_DataSourceDemanded(object sender, EventArgs e)
        {
            this.GroupHeader1.GroupFields.Add(new GroupField("LocationNumber"));
        }
    }
}
