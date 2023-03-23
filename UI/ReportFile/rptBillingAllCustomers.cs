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
    public partial class rptBillingAllCustomers : DevExpress.XtraReports.UI.XtraReport
    {
        public rptBillingAllCustomers(DateTime fromDate, DateTime toDate)
        {
            InitializeComponent();
            string employee = AppSetting.EmployessList.FirstOrDefault(x => x.EmployeeID == AppSetting.CurrentUser.EmployeeID).FullName;
            this.xrLabel48.Text = employee;
            this.xrLabel51.Text = AppSetting.CurrentUser.LoginName;
            this.xrLabel4.Text = fromDate.ToString("dd/MM/yyyy");
            this.xrLabel8.Text = toDate.ToString("dd/MM/yyyy");
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;
        }

        private void rptBillingAllCustomers_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            CreateCalculatedFields();
            this.xrLabel31.DataBindings.Add("Text", this.DataSource, "BeginC");
            this.xrLabel32.DataBindings.Add("Text", this.DataSource, "BeginW");
            this.xrLabel33.DataBindings.Add("Text", this.DataSource, "InC");
            this.xrLabel34.DataBindings.Add("Text", this.DataSource, "InW");
            this.xrLabel35.DataBindings.Add("Text", this.DataSource, "OutC");
            this.xrLabel36.DataBindings.Add("Text", this.DataSource, "OutW");
            this.xrLabel37.DataBindings.Add("Text", this.DataSource, "CloseC");
            this.xrLabel38.DataBindings.Add("Text", this.DataSource, "CloseW");
            this.xrLabel45.DataBindings.Add("Text", this.DataSource, "InC");
            this.xrLabel44.DataBindings.Add("Text", this.DataSource, "InW");

            subrptBillingAllCustomerJoined rpt = new subrptBillingAllCustomerJoined();
            rpt.DataSource = FileProcess.LoadTable("SELECT Customers.CustomerNumber, Customers.CustomerName, tmpBillingCustomerJoined.EmployeeID"
                                                   + " FROM Customers INNER JOIN tmpBillingCustomerJoined ON Customers.CustomerID = tmpBillingCustomerJoined.CustomerID"
                                                   + " WHERE(((tmpBillingCustomerJoined.EmployeeID) = "+AppSetting.CurrentUser.EmployeeID+"))"
                                                   + " ORDER BY Customers.CustomerNumber; ");
            this.xrSubreport1.ReportSource = rpt;
        }

        private void CreateCalculatedFields()
        {
            CalculatedField sumC = new CalculatedField();
            sumC.DataSource = this.DataSource;
            sumC.DataMember = this.DataMember;
            sumC.Name = "sumC";
            sumC.DisplayName = "sumC";
            sumC.Expression = "Sum([BeginC] + [InC])";

            this.CalculatedFields.Add(sumC);

            CalculatedField sumW = new CalculatedField();
            sumW.DataSource = this.DataSource;
            sumW.DataMember = this.DataMember;
            sumW.Name = "sumW";
            sumW.DisplayName = "sumW";
            sumW.Expression = "Sum([BeginW] + [InW])";

            this.CalculatedFields.Add(sumW);
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
