using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace UI.ReportFile
{
    public partial class subrptBillingCombinedBillingNo : DevExpress.XtraReports.UI.XtraReport
    {
        public subrptBillingCombinedBillingNo()
        {
            InitializeComponent();
        }

        private void subrptBillingCombinedBillingNo_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.PageSize = new Size(360, 100);
        }
    }
}
