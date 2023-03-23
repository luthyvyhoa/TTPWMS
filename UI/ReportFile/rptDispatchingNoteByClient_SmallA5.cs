using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;

namespace UI.ReportFile
{
    public partial class rptDispatchingNoteByClient_SmallA5 : DevExpress.XtraReports.UI.XtraReport
    {
        public rptDispatchingNoteByClient_SmallA5()
        {
            InitializeComponent();
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;
        }

        private void rptDispatchingNoteByClient_SmallA5_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //this.DefaultPrinterSettingsUsing.UseLandscape = false;
			// add comment

            //rptPickingslipA4.PaperKind = System.Drawing.Printing.PaperKind.A5Extra;
            this.Landscape = true;
        }
    }
}
