using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;
using System.Linq;

namespace UI.ReportFile
{
    public partial class rptDispatchingPlanA4New_UnitWeight : DevExpress.XtraReports.UI.XtraReport
    {
        public rptDispatchingPlanA4New_UnitWeight()
        {
           InitializeComponent();
        }

     

        private void xrdPalletWeight_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var lbl = (XRLabel)sender;
            string productNo = Convert.ToString(this.GetCurrentColumnValue("ProductNumber"));
            var proInfo = AppSetting.ProductList.Where(p => p.ProductNumber == productNo).FirstOrDefault();
            if (proInfo == null) return;
            if (proInfo.Packages == "KGR")
            {
                lbl.Visible = true;
                lbl.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            }
               
            else
            {
                lbl.Visible = false;
                lbl.Font = new System.Drawing.Font("Arial", 10F);
            }
                  

        }

        private void xrdQtyOfPackage_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
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
    }
}
