using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace UI.ReportFile
{
    public partial class rptDispatchingPlanManyOrders_KGR : DevExpress.XtraReports.UI.XtraReport
    {
        public rptDispatchingPlanManyOrders_KGR()
        {
            InitializeComponent();
          
        }
        public decimal _sumWeight=0;
        public int _sumCtns=0;
        public int temp = 0;
            
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

        private void xrLabel27_BeforePrint(object sender, CancelEventArgs e)
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

        private void xrLabel73_AfterPrint(object sender, EventArgs e)
        {

        }

        private void xrLabel73_BeforePrint(object sender, CancelEventArgs e)
        {
            //ctns
            var lbl = (XRLabel)sender;
            string productNo = Convert.ToString(this.GetCurrentColumnValue("Packages"));
            temp +=1;
            if (productNo != "KGR")
            {
               // temp = 0;
                lbl.Visible = false;
            }
           

           
        }

        private void xrLabel87_BeforePrint(object sender, CancelEventArgs e)
        {

            var lbl = (XRLabel)sender;
            string productNo = Convert.ToString(this.GetCurrentColumnValue("Packages"));


            if (productNo == "KGR")
            {
                lbl.Visible = true;
            }

          
        }
    }
}
