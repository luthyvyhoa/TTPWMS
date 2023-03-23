using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DA;
using System.Collections.Generic;
using System.Linq;

namespace UI.ReportFile
{
    public partial class rptDispatchingPlanA4New : DevExpress.XtraReports.UI.XtraReport
    {
        private int totalQTY = 0;
        public rptDispatchingPlanA4New()
        {
            InitializeComponent();
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;
        }

        private void GroupFooter2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            int totalPackage = Convert.ToInt32(xrSumQtyOfPackage.Summary.GetResult());
            e.Cancel = (this.totalQTY == totalPackage);
        }

        private void xrhSumQtyOfPackage_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            this.totalQTY = 0;
            for (int i = 0; i < e.CalculatedValues.Count; i++)
            {
                this.totalQTY += Convert.ToInt32(e.CalculatedValues[i]);
            }
        }
    }
}
