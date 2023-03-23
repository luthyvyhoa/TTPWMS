using System;
using System.Linq;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;
using DA;

namespace UI.ReportFile
{
    public partial class rptStockOnHandAverageByCustomer : DevExpress.XtraReports.UI.XtraReport
    {
        public rptStockOnHandAverageByCustomer(DateTime fromDate, DateTime toDate)
        {
            InitializeComponent();
            string employeeName = AppSetting.CurrentEmployee.FullName;
            this.xrLabel3.Text = fromDate.ToString("dd/MM/yyyy");
            this.xrLabel5.Text = toDate.ToString("dd/MM/yyyy");
            this.xrLabel28.Text = AppSetting.CurrentUser.LoginName;
            this.xrLabel35.Text = "Prepared by : " + employeeName ;
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;
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
