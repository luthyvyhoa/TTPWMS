using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;
using System.Linq;

namespace UI.ReportFile
{
    public partial class rptPickingSlipManyOrders_Summary : DevExpress.XtraReports.UI.XtraReport
    {
        public rptPickingSlipManyOrders_Summary()
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

        private void xrLabel19_BeforePrint(object sender, CancelEventArgs e)
        {
            var lbl = (XRLabel)sender;
            string productNo = Convert.ToString(this.GetCurrentColumnValue("Packages"));
           
           
            if (productNo == "KGR")
            {
                lbl.Visible = true;  
            }

            else
            {
                lbl.Visible = false;
            }
        }

        private void xrLabel37_BeforePrint(object sender, CancelEventArgs e)
        {
            var lbl = (XRLabel)sender;
            string productNo = Convert.ToString(this.GetCurrentColumnValue("Packages"));


            if (productNo == "KGR")
            {
                lbl.Visible = false;
            }

            else
            {
                lbl.Visible = true;
            }
        }

        private void xrLabel38_BeforePrint(object sender, CancelEventArgs e)
        {
            var lbl = (XRLabel)sender;
            string productNo = Convert.ToString(this.GetCurrentColumnValue("Packages"));


            if (productNo == "KGR")
            {
                lbl.Visible = false;
            }

            else
            {
                lbl.Visible = true;
            }
        }

        private void xrLabel39_BeforePrint(object sender, CancelEventArgs e)
        {
            var lbl = (XRLabel)sender;
            string productNo = Convert.ToString(this.GetCurrentColumnValue("Packages"));


            if (productNo == "KGR")
            {
                lbl.Visible = false;
            }

            else
            {
                lbl.Visible = true;
            }
        }
    }
}
