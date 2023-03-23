using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace UI.ReportFile
{
    public partial class rptDispatchingPlanPick : DevExpress.XtraReports.UI.XtraReport
    {
        public rptDispatchingPlanPick()
        {
            InitializeComponent();
        }

        private void rptDispatchingPlanPick_DataSourceDemanded(object sender, EventArgs e)
        {

        }
    }
}
