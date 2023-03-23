using System;
using DA;
using UI.Helper;
using System.Linq;
using System.Drawing;

namespace UI.ReportFile
{
    public partial class rptBillingByCustomerPeriodAllPriced : DevExpress.XtraReports.UI.XtraReport
    {
        private int _billingID;
        private string cus_type;

        public rptBillingByCustomerPeriodAllPriced(int billingID, string customerType = null)
        {
            DataProcess<Employees> empDA = new DataProcess<Employees>();
            InitializeComponent();
            this._billingID = billingID;
            var employeeFind = DA.FileProcess.LoadTable("select VietnamName from Employees where employeeID=" + AppSetting.CurrentUser.EmployeeID);
            string employeeName = Convert.ToString(employeeFind.Rows[0]["VietnamName"]);
            string employeePosition = empDA.Select(m => m.EmployeeID == AppSetting.CurrentUser.EmployeeID).FirstOrDefault().Position;
            this.xrLabel30.Text = employeeName;
            this.xrLabel28.Text = employeePosition;
            this.xrLabel43.Text = AppSetting.CurrentUser.LoginName;
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;
            cus_type = customerType;
        }

        private void rptBillingByCustomerPeriodAll_DataSourceDemanded(object sender, EventArgs e)
        {
            //check here if the Customer is for Distribution Services or Transport Services

            if (cus_type == "Distribution Service" || cus_type == "Transport")
            {
                //doing nothing about the subreport
                this.xrSubreport1 = null;
            }
            else
            {
                subrptBillingDetailBreakdown rpt = new subrptBillingDetailBreakdown();
                rpt.DataSource = FileProcess.LoadTable("STBillingDetailBreakdownByBillingID @BillingID= " + this._billingID +"");
                this.xrSubreport1.ReportSource = rpt;
            } 
        }

        private void xrPictureBox1_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string imagePath = AppSetting.PathSignature + AppSetting.CurrentUser.EmployeeID + ".jpg";
            if (System.IO.File.Exists(imagePath))
            {
                this.xrPictureBox1.Image = Image.FromFile(imagePath);
            }
        }
    }
}
