using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;

namespace UI.ReportFile
{
    public partial class rptStockTakeDailyCheckSplitPallets : DevExpress.XtraReports.UI.XtraReport
    {
        public rptStockTakeDailyCheckSplitPallets()
        {
            InitializeComponent();
            this.xrLbUser.Text = "by " + AppSetting.CurrentUser.LoginName;
        }

    }
}
