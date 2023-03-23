using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;

namespace UI.ReportFile
{
    public partial class rptStockTakeByRequest_NewForWall : DevExpress.XtraReports.UI.XtraReport
    {
        public rptStockTakeByRequest_NewForWall()
        {
            InitializeComponent();
            this.xrLabel40.Text = $"by {AppSetting.CurrentUser.LoginName}";
        }

    }
}
