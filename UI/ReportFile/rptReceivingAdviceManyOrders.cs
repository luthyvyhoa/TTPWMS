using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;

namespace UI.ReportFile
{
    public partial class rptReceivingAdviceManyOrders : DevExpress.XtraReports.UI.XtraReport
    {
        public rptReceivingAdviceManyOrders()
        {
            InitializeComponent();
        }

        private void xrLabel18_BeforePrint(object sender, CancelEventArgs e)
        {
            this.xrLabel18.Text = "Kỷ Nguyên Mới | Printed: " + DateTime.Now.ToString("0:dd/MM/yyyy HH:mm") + " by " + AppSetting.CurrentUser.LoginName;
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

    }
}
