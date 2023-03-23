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
    public partial class rptBillingByCustomerFull : DevExpress.XtraReports.UI.XtraReport
    {
        private int sumInC;
        private double sumInW;
        private int sumInP;

        public rptBillingByCustomerFull(DateTime fromDate, DateTime toDate)
        {
            InitializeComponent();
            this.xrLabel7.Text = fromDate.ToString("dd/MM/yyyy");
            this.xrLabel8.Text = toDate.ToString("dd/MM/yyyy");
            this.xrLabel72.Text = AppSetting.CurrentUser.LoginName;
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;
        }

        private void rptBillingByCustomerFull_DataSourceDemanded(object sender, EventArgs e)
        {
            this.GroupHeader1.GroupFields.Add(new GroupField("CustomerID"));
            CreateCalculatedFields();
            this.xrLabel47.DataBindings.Add("Text", this.DataSource, "BeginC");
            this.xrLabel48.DataBindings.Add("Text", this.DataSource, "BeginW");
            this.xrLabel49.DataBindings.Add("Text", this.DataSource, "InC");
            this.xrLabel50.DataBindings.Add("Text", this.DataSource, "InW");
            this.xrLabel51.DataBindings.Add("Text", this.DataSource, "OutC");
            this.xrLabel52.DataBindings.Add("Text", this.DataSource, "OutW");
            this.xrLabel53.DataBindings.Add("Text", this.DataSource, "CloseC");
            this.xrLabel54.DataBindings.Add("Text", this.DataSource, "CloseW");
            this.xrLabel56.DataBindings.Add("Text", this.DataSource, "BeginP");
            this.xrLabel57.DataBindings.Add("Text", this.DataSource, "InP");
            this.xrLabel58.DataBindings.Add("Text", this.DataSource, "OutP");
            this.xrLabel59.DataBindings.Add("Text", this.DataSource, "CloseP");
        }

        private void CreateCalculatedFields()
        {
            CalculatedField sumOver = new CalculatedField();
            sumOver.DataSource = this.DataSource;
            sumOver.DataMember = this.DataMember;
            sumOver.Name = "sumOver";
            sumOver.DisplayName = "sumOver";
            sumOver.Expression = "Iif([BeginW]- 0 +[InW] < 0, 0, [BeginW] - 0 + [InW])";

            this.CalculatedFields.Add(sumOver);

            CalculatedField sumTotalOver = new CalculatedField();
            sumTotalOver.DataSource = this.DataSource;
            sumTotalOver.DataMember = this.DataMember;
            sumTotalOver.Name = "sumTotalOver";
            sumTotalOver.DisplayName = "sumTotalOver";
            sumTotalOver.Expression = "Sum([sumOver])";

            this.CalculatedFields.Add(sumTotalOver);

            CalculatedField sumOverP = new CalculatedField();
            sumOverP.DataSource = this.DataSource;
            sumOverP.DataMember = this.DataMember;
            sumOverP.Name = "sumOverP";
            sumOverP.DisplayName = "sumOverP";
            sumOverP.Expression = "Iif([BeginP]-0+[InP]<0,0,[BeginP]-0+[InP])";

            this.CalculatedFields.Add(sumOverP);

            CalculatedField sumTotalOverP = new CalculatedField();
            sumTotalOverP.DataSource = this.DataSource;
            sumTotalOverP.DataMember = this.DataMember;
            sumTotalOverP.Name = "sumTotalOverP";
            sumTotalOverP.DisplayName = "sumTotalOverP";
            sumTotalOverP.Expression = "Sum([sumOverP])";

            this.CalculatedFields.Add(sumTotalOverP);

            CalculatedField sumC = new CalculatedField();
            sumC.DataSource = this.DataSource;
            sumC.DataMember = this.DataMember;
            sumC.Name = "sumC";
            sumC.DisplayName = "sumC";
            sumC.Expression = "Sum([BeginC] + [InC])";

            this.CalculatedFields.Add(sumC);

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

        private void rptBillingByCustomerFull_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void rptBillingByCustomerFull_AfterPrint(object sender, EventArgs e)
        {
        }

        private void xrLabel63_AfterPrint(object sender, EventArgs e)
        {
            
        }

        private void xrLabel63_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
        }

        private void xrLabel49_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
        }

        private void xrLabel73_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            DataProcess<Employees> empDA = new DataProcess<Employees>();
            var fullname = empDA.Select(a => a.EmployeeID == AppSetting.CurrentUser.EmployeeID).FirstOrDefault().FullName;
            this.xrLabel73.Text = fullname;
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
