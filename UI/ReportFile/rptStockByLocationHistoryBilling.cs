using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;
using System.Linq;
using DA;

namespace UI.ReportFile
{
    public partial class rptStockByLocationHistoryBilling : DevExpress.XtraReports.UI.XtraReport
    {
        public rptStockByLocationHistoryBilling(DateTime fromDate, DateTime toDate)
        {
            InitializeComponent();
            DataProcess<Employees> emDA = new DataProcess<Employees>();
            string employee = emDA.Select(x => x.EmployeeID == AppSetting.CurrentUser.EmployeeID).FirstOrDefault().FullName;
            this.xrLabel48.Text = employee;
            this.xrLabel51.Text = AppSetting.CurrentUser.LoginName;
            this.xrLabel4.Text = fromDate.ToString("dd/MM/yyyy");
            this.xrLabel8.Text = toDate.ToString("dd/MM/yyyy");
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
