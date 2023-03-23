using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DA;
using UI.Helper;
using System.Linq;

namespace UI.ReportFile
{
    public partial class rptLoadingReports : DevExpress.XtraReports.UI.XtraReport
    {
        public rptLoadingReports()
        {
        }

        public rptLoadingReports(int dispatchingOrderID)
        {
            InitializeComponent();
            this.xrPictureBox1.Image = UI.Properties.Resources.ImageCompany;
        }

        private void rptLoadingReports_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {


        }

        private void xrLabel12_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            DataProcess<Employees> empDA = new DataProcess<Employees>();
            var fullname = empDA.Select(a => a.EmployeeID == AppSetting.CurrentUser.EmployeeID).FirstOrDefault().FullName;
            this.xrLabel12.Text = fullname;
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
