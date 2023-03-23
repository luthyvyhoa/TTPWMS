using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace UI.ReportFile
{
    public partial class rptPickingSlipA4ByRemark_RandomWeight : DevExpress.XtraReports.UI.XtraReport
    {
        public rptPickingSlipA4ByRemark_RandomWeight()
        {
            InitializeComponent();
        }
        private void rptPickingSlipA4ByRemark_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void xrLabel34_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = Convert.ToDouble(xrLabel65.Summary.GetResult()) / Convert.ToDouble(xrLabel45.Text);
            e.Handled = true; 
        }

    }
}
