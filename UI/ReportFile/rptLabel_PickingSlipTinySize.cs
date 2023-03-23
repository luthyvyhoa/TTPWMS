﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Text;
using UI.Helper;

namespace UI.ReportFile
{
    public partial class rptLabel_PickingSlipTinySize : DevExpress.XtraReports.UI.XtraReport
    {
        public rptLabel_PickingSlipTinySize()
        {
            InitializeComponent();
        }

        private void xrLabel3_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string proDate = Convert.ToString(this.GetCurrentColumnValue("ProductionDate"));
            string expDate = Convert.ToString(this.GetCurrentColumnValue("UseByDate"));
            var remark = this.GetCurrentColumnValue("CustomerRef");
            StringBuilder stringCombine = new StringBuilder();
            stringCombine.Append(string.IsNullOrEmpty(proDate) ? null : (Convert.ToDateTime(proDate).ToString("dd/MM/yyyy")));
            stringCombine.Append("~");
            stringCombine.Append(string.IsNullOrEmpty(expDate) ? null : (Convert.ToDateTime(expDate).ToString("dd/MM/yyyy")));
            stringCombine.Append("~");
            stringCombine.Append(remark);
            this.xrLabel3.Text = stringCombine.ToString();
        }

        private void xrLabel20_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrLabel20.Text = "by :" + AppSetting.CurrentUser.LoginName;
        }

    }
}
