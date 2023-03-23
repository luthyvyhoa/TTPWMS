using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace UI.ReportFile
{
    public partial class rptReceivingAdvice_Lanscape : DevExpress.XtraReports.UI.XtraReport
    {
        public rptReceivingAdvice_Lanscape()
        {
            InitializeComponent();
        }

        private void GroupFooter2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                decimal rowcount = Math.Round((Convert.ToDecimal(this.xrLabel25.Summary.GetResult()) / this.RowCount) * 100, 2, MidpointRounding.ToEven);
                this.xrLabel24.Text = rowcount + "%";
            }
            catch (Exception)
            {
                this.xrLabel24.Text = "%";
            }
        }

    }
}
