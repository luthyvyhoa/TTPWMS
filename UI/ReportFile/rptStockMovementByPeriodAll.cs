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
    public partial class rptStockMovementByPeriodAll : DevExpress.XtraReports.UI.XtraReport
    {
        public rptStockMovementByPeriodAll()
        {
            InitializeComponent();
            this.xrLabel3.Text = "by " + AppSetting.CurrentUser.LoginName;
            this.xrLabel39.Text = AppSetting.CurrentEmployee.FullName;
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
