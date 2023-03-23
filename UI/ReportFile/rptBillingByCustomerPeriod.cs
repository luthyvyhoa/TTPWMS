using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;
using System.Linq;

namespace UI.ReportFile
{
    public partial class rptBillingByCustomerPeriod : DevExpress.XtraReports.UI.XtraReport
    {
        public rptBillingByCustomerPeriod()
        {
            InitializeComponent();
            var employeeFind = DA.FileProcess.LoadTable("select VietnamName,Position from Employees where employeeID=" + AppSetting.CurrentUser.EmployeeID);
            string employeeName = Convert.ToString(employeeFind.Rows[0]["VietnamName"]);
            string employeePosition = Convert.ToString(employeeFind.Rows[0]["Position"]);
            this.xrLabel25.Text = employeeName;
            this.xrLabel23.Text = employeePosition;
            this.xrLabel43.Text = AppSetting.CurrentUser.LoginName;
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;
        }

        private void xrPictureBox1_BeforePrint(object sender, CancelEventArgs e)
        {
            string imagePath = AppSetting.PathSignature + AppSetting.CurrentUser.EmployeeID + ".jpg";
            if (System.IO.File.Exists(imagePath))
            {
                this.xrPictureBox1.Image = Image.FromFile(imagePath);
            }
        }

    }
}
