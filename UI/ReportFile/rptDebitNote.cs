using System;
using DA;
using UI.Helper;
using System.Linq;
using System.Drawing;

namespace UI.ReportFile
{
    public partial class rptDebitNote : DevExpress.XtraReports.UI.XtraReport
    {
        private int _InvoiceID;

        public rptDebitNote(int invoiceID)
        {
            DataProcess<Employees> empDA = new DataProcess<Employees>();
            InitializeComponent();
            this._InvoiceID = invoiceID;
            var employeeFind = DA.FileProcess.LoadTable("select VietnamName from Employees where employeeID=" + AppSetting.CurrentUser.EmployeeID);
            string employeeName = Convert.ToString(employeeFind.Rows[0]["VietnamName"]);
            string employeePosition = empDA.Select(m => m.EmployeeID == AppSetting.CurrentUser.EmployeeID).FirstOrDefault().Position;
            this.xrLabel30.Text = employeeName;
            this.xrLabel28.Text = employeePosition;
            this.xrLabel43.Text = AppSetting.CurrentUser.LoginName;
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
