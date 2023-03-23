using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;
using DA;
using System.Linq;

namespace UI.ReportFile
{
    public partial class rptBillingAllCustomersPallets : DevExpress.XtraReports.UI.XtraReport
    {
        public rptBillingAllCustomersPallets(DateTime fromDate, DateTime toDate)
        {
            InitializeComponent();
            this.xrLabel7.Text = fromDate.ToString("dd/MM/yyyy");
            this.xrLabel8.Text = toDate.ToString("dd/MM/yyyy");
            this.xrLabel72.Text = AppSetting.CurrentUser.LoginName;
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;
        }

        private void rptBillingAllCustomersPallets_DataSourceDemanded(object sender, EventArgs e)
        {
            CreateCalculatedFields();
            subrptBillingAllCustomers rpt = new subrptBillingAllCustomers();
            rpt.DataSource = FileProcess.LoadTable("SELECT Customers.CustomerNumber, Customers.CustomerName, tmpBillingCustomers.EmployeeID"
                                                   + " FROM Customers INNER JOIN tmpBillingCustomers ON Customers.CustomerID = tmpBillingCustomers.CustomerID"
                                                   + " WHERE(((tmpBillingCustomers.EmployeeID) = "+AppSetting.CurrentUser.EmployeeID+"))"
                                                   + " ORDER BY Customers.CustomerNumber");
            this.xrSubreport1.ReportSource = rpt;
            this.xrLabel48.DataBindings.Add("Text", this.DataSource, "BeginC");
            this.xrLabel47.DataBindings.Add("Text", this.DataSource, "BeginW");
            this.xrLabel46.DataBindings.Add("Text", this.DataSource, "BeginP");
            this.xrLabel45.DataBindings.Add("Text", this.DataSource, "InC");
            this.xrLabel44.DataBindings.Add("Text", this.DataSource, "InW");
            this.xrLabel43.DataBindings.Add("Text", this.DataSource, "InP");
            this.xrLabel42.DataBindings.Add("Text", this.DataSource, "OutC");
            this.xrLabel41.DataBindings.Add("Text", this.DataSource, "OutW");
            this.xrLabel40.DataBindings.Add("Text", this.DataSource, "OutP");
            this.xrLabel39.DataBindings.Add("Text", this.DataSource, "CloseC");
            this.xrLabel38.DataBindings.Add("Text", this.DataSource, "CloseW");
            this.xrLabel37.DataBindings.Add("Text", this.DataSource, "CloseP");
        }

        private void CreateCalculatedFields()
        {
            CalculatedField sumOver = new CalculatedField();
            sumOver.DataSource = this.DataSource;
            sumOver.DataMember = this.DataMember;
            sumOver.Name = "sumOver";
            sumOver.DisplayName = "sumOver";
            sumOver.Expression = "Sum(Iif([BeginP]- 0 +[InP] < 0, 0, [BeginP] - 0 + [InP]))";

            this.CalculatedFields.Add(sumOver);

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

            CalculatedField sumInC = new CalculatedField();
            sumInC.DataSource = this.DataSource;
            sumInC.DataMember = this.DataMember;
            sumInC.Name = "sumInC";
            sumInC.DisplayName = "sumInC";
            sumInC.Expression = "Sum([InC])";

            this.CalculatedFields.Add(sumInC);

            CalculatedField sumInP = new CalculatedField();
            sumInP.DataSource = this.DataSource;
            sumInP.DataMember = this.DataMember;
            sumInP.Name = "sumInP";
            sumInP.DisplayName = "sumInP";
            sumInP.Expression = "Sum([InP])";

            this.CalculatedFields.Add(sumInP);

            CalculatedField sumInW = new CalculatedField();
            sumInW.DataSource = this.DataSource;
            sumInW.DataMember = this.DataMember;
            sumInW.Name = "sumInW";
            sumInW.DisplayName = "sumInW";
            sumInW.Expression = "Sum([InW])";

            this.CalculatedFields.Add(sumInW);
        }

        private void rptBillingAllCustomersPallets_AfterPrint(object sender, EventArgs e)
        {
        }

        private void xrLabel50_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            DataProcess<Employees> empDA = new DataProcess<Employees>();
            var fullname = empDA.Select(a => a.EmployeeID == AppSetting.CurrentUser.EmployeeID).FirstOrDefault().FullName;
            this.xrLabel50.Text = fullname;
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
