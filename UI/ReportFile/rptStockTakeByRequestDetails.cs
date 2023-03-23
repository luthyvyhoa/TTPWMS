using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;

namespace UI.ReportFile
{
    public partial class rptStockTakeByRequestDetails : DevExpress.XtraReports.UI.XtraReport
    {
        public rptStockTakeByRequestDetails()
        {
            InitializeComponent();
            this.xrLabel40.Text = $"by {AppSetting.CurrentUser.LoginName}";
        }

        /// <summary>
        /// Handles the BeforePrint event of the LocationNumber value.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Drawing.Printing.PrintEventArgs"/> instance containing the event data.</param>
        private void xrLabel17_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
           
        }
    }
}
