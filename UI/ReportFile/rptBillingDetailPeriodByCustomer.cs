using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DA;
using UI.Helper;

namespace UI.ReportFile
{
    public partial class rptBillingDetailPeriodByCustomer : DevExpress.XtraReports.UI.XtraReport
    {
        public rptBillingDetailPeriodByCustomer(DateTime from, DateTime to, Customers customer, Employees employee)
        {
            InitializeComponent();
            InitData(from, to, customer, employee);
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;
        }

        private void InitData(DateTime from, DateTime to, Customers customer, Employees employee)
        {
            InitDataForGrid(from, to, customer);
            lblPeriod.Text = "From: " + from.ToString("dd/MM/yyyy") + " - To: " + to.ToString("dd/MM/yyyy");
            lblCustomerNumber.Text = customer.CustomerNumber;
            lblCustomerName.Text = customer.CustomerName;
            lblEmployeeName.Text = employee.FullName;
            lblUsernameFooter.Text = "Kỷ Nguyên Mới | Printed by " + AppSetting.CurrentUser.LoginName + " - ";
            lblPhone1.Text = customer.Phone1;
            lblFax.Text = customer.Fax;
            lblEmployeeName.Text = employee.VietnamName;
            lblEmployeePosition.Text = employee.Position;
        }

        private void InitDataForGrid(DateTime from, DateTime to, Customers customer)
        {
            string queryString = "SELECT ServicesDefinition.ServiceNumber, ServicesDefinition.ServiceName, OtherService.ServiceDate, OtherService.ServiceRemark, OtherServiceDetails.ServiceID, OtherServiceDetails.Quantity, OtherService.OtherServiceID, OtherService.CustomerID, OtherService.LockStatus, OtherServiceDetails.Description, Customers.CustomerNumber, Customers.CustomerName, Customers.Address, Customers.Phone1, Customers.Fax, ServicesDefinition.Measure "
            + "FROM (ServicesDefinition INNER JOIN (OtherService INNER JOIN OtherServiceDetails ON OtherService.OtherServiceID = OtherServiceDetails.OtherServiceID) ON ServicesDefinition.ServiceID = OtherServiceDetails.ServiceID) INNER JOIN Customers ON OtherService.CustomerID = Customers.CustomerID "
            + "WHERE (OtherService.ServiceDate Between '" + from.ToString("M/dd/yyyy") + "' And '" + to.ToString("M/dd/yyyy") + "') AND (OtherService.CustomerID = '" + customer.CustomerID + "') "
            + "ORDER BY OtherService.ServiceDate DESC , OtherService.OtherServiceID DESC";
            var dataSource = FileProcess.LoadTable(queryString);
            DataSource = dataSource;
        }

        private void rptBillingDetailPeriodByCustomer_DataSourceDemanded(object sender, EventArgs e)
        {
            this.GroupHeader4.GroupFields.Add(new GroupField("ServiceNumber"));
            this.xrLabel31.DataBindings.Add("Text", this.DataSource, "Quantity");
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
