﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;

namespace UI.ReportFile
{
    public partial class rptStockReceivedSummary : DevExpress.XtraReports.UI.XtraReport
    {
        public rptStockReceivedSummary()
        {
            InitializeComponent();
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;
        }

        private void xrPictureBox1_BeforePrint(object sender, CancelEventArgs e)
        {
            string imagePath = AppSetting.PathSignature + AppSetting.CurrentUser.EmployeeID + ".jpg";
            if (System.IO.File.Exists(imagePath))
            {
                this.xrPictureBox1.Image = Image.FromFile(imagePath);
            }
        }

      

        private void xrLabel11_BeforePrint(object sender, CancelEventArgs e)
        {
            this.xrLabel11.Text = "Kỷ Nguyên Mới | printed " + DateTime.Now.ToString("dd/MM/yyyy h:mm") + " by " + AppSetting.CurrentUser.LoginName;
        }

    }
}
