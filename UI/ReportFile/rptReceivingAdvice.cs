﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace UI.ReportFile
{
    public partial class rptReceivingAdvice : DevExpress.XtraReports.UI.XtraReport
    {
        public rptReceivingAdvice()
        {
            InitializeComponent();
        }

        private void GroupFooter1_BeforePrint(object sender, CancelEventArgs e)
        {
            try
            {
                decimal rowcount = Math.Round((Convert.ToDecimal(this.xrLabel20.Summary.GetResult()) / this.RowCount) * 100, 2, MidpointRounding.ToEven);
                this.xrLabel21.Text = rowcount + "%";
            }
            catch (Exception)
            {
                this.xrLabel21.Text = "%";
            }
        }

    }
}
