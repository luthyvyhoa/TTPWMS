﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;

namespace UI.ReportFile
{
    public partial class rptMonthlyPersonnel : DevExpress.XtraReports.UI.XtraReport
    {
        public rptMonthlyPersonnel()
        {
            InitializeComponent();
            this.xrPageInfo1.Format = AppSetting.CurrentUser.LoginName + " - {0:dd/MM/yyyy HH:mm tt}";
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;
        }

    }
}
