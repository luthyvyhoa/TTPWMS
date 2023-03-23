using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;

namespace UI.ReportFile
{
    public partial class rptPickingSlipManyOrdersByProduct : DevExpress.XtraReports.UI.XtraReport
    {
        public rptPickingSlipManyOrdersByProduct()
        {
            InitializeComponent();
        }

        private void GroupFooter1_BeforePrint(object sender, CancelEventArgs e)
        {
            try
            {
                decimal rowcount = Math.Round((Convert.ToDecimal(this.xrLabel20.Summary.GetResult()) / this.RowCount) * 100, 2, MidpointRounding.ToEven);
                this.xrLabel21.Text = rowcount + "%";
            }
            catch (Exception)
            {
                this.xrLabel21.Text = "%";
            }
        }

        private void xrLabel24_BeforePrint(object sender, CancelEventArgs e)
        {
            xrLabel24.Text = "Kỷ Nguyên Mới | Printed: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss by ") + AppSetting.CurrentUser.LoginName;
        }
    }
}
