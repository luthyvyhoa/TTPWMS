using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace UI.ReportFile
{
    public partial class rptReceivingAdvice_pcs : DevExpress.XtraReports.UI.XtraReport
    {
        public rptReceivingAdvice_pcs()
        {
            InitializeComponent();
        }

        private void GroupFooter1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                decimal rowcount = Math.Round((Convert.ToDecimal(this.xrLabel25.Summary.GetResult()) / this.RowCount) * 100, 2, MidpointRounding.ToEven);
                this.xrLabel37.Text = rowcount + "%";
            }
            catch (Exception)
            {
                this.xrLabel37.Text = "%";
            }
        }

    }
}
