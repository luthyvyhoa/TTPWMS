using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;

namespace UI.ReportFile
{
    public partial class rptDispatchingPlanA4New_pcs : DevExpress.XtraReports.UI.XtraReport
    {
        public rptDispatchingPlanA4New_pcs()
        {
            InitializeComponent();
        }

        private void xrKetoan_BeforePrint(object sender, CancelEventArgs e)
        {
            this.xrKetoan.Text = "Kế toán: " + AppSetting.CurrentUser.LoginName + " " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss tt"); ;
        }

    }
}
