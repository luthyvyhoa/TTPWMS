using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace UI.ReportFile
{
    public partial class rptFreeLocationByRoom : DevExpress.XtraReports.UI.XtraReport
    {
        public rptFreeLocationByRoom(int count)
        {
            InitializeComponent();
            this.xrCount.Text = count.ToString();
            this.xrLabel29.Text = "By :" + Helper.AppSetting.CurrentUser.LoginName;
        }

    }
}
