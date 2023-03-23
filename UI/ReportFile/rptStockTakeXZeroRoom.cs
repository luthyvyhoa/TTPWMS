using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;

namespace UI.ReportFile
{
    public partial class rptStockTakeXZeroRoom : DevExpress.XtraReports.UI.XtraReport
    {
        public rptStockTakeXZeroRoom()
        {
            InitializeComponent();
            this.xrLabel40.Text = $"by {AppSetting.CurrentUser.LoginName}";
        }

    }
}
