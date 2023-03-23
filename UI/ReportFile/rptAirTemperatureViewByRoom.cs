using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;

namespace UI.ReportFile
{
    public partial class rptAirTemperatureViewByRoom : DevExpress.XtraReports.UI.XtraReport
    {
        public rptAirTemperatureViewByRoom()
        {
            InitializeComponent();
            this.xrPictureCompany.Image = UI.Properties.Resources.ImageCompany;
        }

        /// <summary>
        /// Handles the BeforePrint event of the xrPictureBox1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Drawing.Printing.PrintEventArgs"/> instance containing the event data.</param>
        private void xrPictureBox1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string imagePath = AppSetting.PathSignature + AppSetting.CurrentUser.EmployeeID + ".jpg";
            if (System.IO.File.Exists(imagePath))
            {
                this.xrPictureEmployeeSign.Image = Image.FromFile(imagePath);
            }
        }

        /// <summary>
        /// Sets from to date information.
        /// </summary>
        /// <param name="from">From.</param>
        /// <param name="to">To.</param>
        public void SetFromToDateInfo(string from, string to)
        {
            this.xrLblFromDate.Text = from;
            this.xrLblToDate.Text = to;
        }
    }
}
