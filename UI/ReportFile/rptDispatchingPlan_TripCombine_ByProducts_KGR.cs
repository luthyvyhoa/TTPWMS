using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace UI.ReportFile
{
    public partial class rptDispatchingPlan_TripCombine_ByProducts_KGR : DevExpress.XtraReports.UI.XtraReport
    {
        public rptDispatchingPlan_TripCombine_ByProducts_KGR()
        {
            InitializeComponent();
        }

        private void xrdQtyOfPackage_BeforePrint(object sender, CancelEventArgs e)
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

        private void xrLabel55_BeforePrint(object sender, CancelEventArgs e)
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

        private void xrdUnitQty_BeforePrint(object sender, CancelEventArgs e)
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

        private void xrdPalletWeight_BeforePrint(object sender, CancelEventArgs e)
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
    }
}
