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
    public partial class rptBillingByProduct : DevExpress.XtraReports.UI.XtraReport
    {
        public rptBillingByProduct(DateTime fromDate, DateTime toDate)
        {
            InitializeComponent();
            this.xrLabel51.Text = AppSetting.CurrentUser.LoginName;
            this.xrLabel4.Text = fromDate.ToString("dd/MM/yyyy");
            this.xrLabel8.Text = toDate.ToString("dd/MM/yyyy");
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;
        }

        private void rptBillingByProduct_DataSourceDemanded(object sender, EventArgs e)
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
            this.xrLabel62.DataBindings.Add("Text", this.DataSource, "BeginP");
            this.xrLabel61.DataBindings.Add("Text", this.DataSource, "InP");
            this.xrLabel60.DataBindings.Add("Text", this.DataSource, "OutP");
            this.xrLabel59.DataBindings.Add("Text", this.DataSource, "CloseP");


            var customerSource = FileProcess.LoadTable("SELECT Products.ProductNumber, Products.ProductName, tmpProducts.EmployeeID " +
                " FROM Products INNER JOIN tmpProducts ON Products.ProductID = tmpProducts.ProductID " +
                " WHERE tmpProducts.EmployeeID=" + AppSetting.CurrentUser.EmployeeID + " ORDER BY Products.ProductNumber;");
            if (customerSource.Rows.Count > 0)
            {
                this.lblProductName.Text = Convert.ToString(customerSource.Rows[0]["ProductNumber"])+"              " + Convert.ToString(customerSource.Rows[0]["ProductName"]);
            }
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

            CalculatedField sumP = new CalculatedField();
            sumP.DataSource = this.DataSource;
            sumP.DataMember = this.DataMember;
            sumP.Name = "sumW";
            sumP.DisplayName = "sumW";
            sumP.Expression = "Sum([BeginP] + [InP])";

            this.CalculatedFields.Add(sumP);
        }



        private void xrPictureBox1_BeforePrint(object sender, CancelEventArgs e)
        {
            string imagePath = AppSetting.PathSignature + AppSetting.CurrentUser.EmployeeID + ".jpg";
            if (System.IO.File.Exists(imagePath))
            {
                this.xrPictureBox1.Image = Image.FromFile(imagePath);
            }
        }

        private void xrLabel3_BeforePrint(object sender, CancelEventArgs e)
        {
            DataProcess<Employees> empDA = new DataProcess<Employees>();
            var fullname = empDA.Select(a => a.EmployeeID == AppSetting.CurrentUser.EmployeeID).FirstOrDefault().VietnamName;
            this.xrLabel3.Text = fullname;
        }
    }
}
