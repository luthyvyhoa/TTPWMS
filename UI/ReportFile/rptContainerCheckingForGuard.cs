using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;

namespace UI.ReportFile
{
    public partial class rptContainerCheckingForGuard : DevExpress.XtraReports.UI.XtraReport
    {
        public rptContainerCheckingForGuard()
        {
            InitializeComponent();
            this.xrPageInfo2.Format = AppSetting.CurrentUser.LoginName + " {0:dd/MM/yyyy HH:mm tt}";
        }

        private void rptContainerCheckingForGuard_DataSourceDemanded(object sender, EventArgs e)
        {
            this.GroupHeader1.GroupFields.Add(new GroupField("Gate"));
        }
    }
}
