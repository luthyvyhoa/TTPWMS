using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;
using System.Linq;

namespace UI.ReportFile
{
    public partial class rptDispatchingNoteDetails : DevExpress.XtraReports.UI.XtraReport
    {
        public rptDispatchingNoteDetails(int customerID)
        {
            InitializeComponent();
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;
            if (customerID == 2024)
            {
                this.xrLabel49.TextFormatString = "{0:MM/yyyy}";
                this.xrLabel50.TextFormatString = "{0:MM/yyyy}";
            }
        }

        private void xrPictureBox1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string imagePath = AppSetting.PathSignature + AppSetting.CurrentUser.EmployeeID + ".jpg";
            if (System.IO.File.Exists(imagePath))
            {
                this.xrPictureBox1.Image = Image.FromFile(imagePath);
            }
        }
    }
}
