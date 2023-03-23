using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace UI.ReportFile
{
    public partial class rptPickingSlipManyOrders_Landscape : DevExpress.XtraReports.UI.XtraReport
    {
        public rptPickingSlipManyOrders_Landscape()
        {
            InitializeComponent();
        }

        private void xrLabel34_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            try
            {
                e.Result = Convert.ToDouble(xrLabel65.Summary.GetResult()) / Convert.ToDouble(xrLabel45.Text);
                e.Handled = true;
            }
            catch (Exception)
            {
            }
        }

    }
}
