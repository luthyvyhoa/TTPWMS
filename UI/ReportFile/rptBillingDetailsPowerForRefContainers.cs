using System;
using System.Linq;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;

namespace UI.ReportFile
{
    public partial class rptBillingDetailsPowerForRefContainers : DevExpress.XtraReports.UI.XtraReport
    {
        public rptBillingDetailsPowerForRefContainers(DateTime fromDate, DateTime toDate)
        {
            InitializeComponent();
            var employeeFind = DA.FileProcess.LoadTable("select VietnamName from Employees where employeeID=" + AppSetting.CurrentUser.EmployeeID);
            string employeeName = Convert.ToString(employeeFind.Rows[0]["VietnamName"]);
            this.xrLabel7.Text = fromDate.ToString("dd/MM/yyyy");
            this.xrLabel8.Text = toDate.ToString("dd/MM/yyyy");
            this.xrLabel19.Text = employeeName;
            this.xrLabel43.Text = AppSetting.CurrentUser.LoginName;
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;
        }

        private void rptBillingDetailsPowerForRefContainers_DataSourceDemanded(object sender, EventArgs e)
        {
            this.xrLabel20.DataBindings.Add("Text", this.DataSource, "Quantity");
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
