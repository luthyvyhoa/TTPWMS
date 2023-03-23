using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;
using System.Linq;

namespace UI.ReportFile
{
    public partial class rptPickingSlipA4_RandomWeight : DevExpress.XtraReports.UI.XtraReport
    {
        public rptPickingSlipA4_RandomWeight()
        {
            InitializeComponent();
        }
        private void xrLabel44_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            try
            {
                e.Result = Convert.ToDouble(xrLabel39.Summary.GetResult()) / Convert.ToDouble(xrLabel4.Text);
                e.Handled = true;
            }
            catch (Exception)
            {
            }
        }

        private void xrLabel30_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

            var lbl = (XRLabel)sender;
            string productNo = Convert.ToString(this.GetCurrentColumnValue("ProductNumber"));
            var proInfo = AppSetting.ProductList.Where(p => p.ProductNumber == productNo).FirstOrDefault();
            if (proInfo == null) return;
            if (proInfo.Packages == "KGR")
                lbl.Visible = false;
            else
                lbl.Visible = true;

        }

        private void xrLabel32_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var lbl = (XRLabel)sender;
            string productNo = Convert.ToString(this.GetCurrentColumnValue("ProductNumber"));
            var proInfo = AppSetting.ProductList.Where(p => p.ProductNumber == productNo).FirstOrDefault();
            if (proInfo == null) return;
            if (proInfo.Packages == "KGR")
            {
                lbl.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
                lbl.Visible = true;
            }
            else
            {
                lbl.Visible = false;
                lbl.Font = new System.Drawing.Font("Arial", 8F);
            }
                
        }

        private void xrLabel48_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
         
        }
    }
}
