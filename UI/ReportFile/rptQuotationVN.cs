using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;
using DA;
using System.Linq;

namespace UI.ReportFile
{
    public partial class rptQuotationVN : DevExpress.XtraReports.UI.XtraReport
    {
        public rptQuotationVN()
        {
            InitializeComponent();
            this.xrPictureBox1.Image = UI.Properties.Resources.ImageCompany;
        }

        private void xrLabel44_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.xrLabel44.Text = AppSetting.CurrentEmployee.FullName;
        }

        private void xrPictureBox2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string imagePath = AppSetting.PathSignature + AppSetting.CurrentUser.EmployeeID + ".jpg";
            if (System.IO.File.Exists(imagePath))
            {
                this.xrPictureBox2.Image = Image.FromFile(imagePath);
            }
        }
    }
}
