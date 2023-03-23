using System;
using System.Linq;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;

namespace UI.ReportFile
{
    public partial class rptBillingByCustomerByGross : DevExpress.XtraReports.UI.XtraReport
    {
        public rptBillingByCustomerByGross(DateTime fromDate, DateTime toDate)
        {
            InitializeComponent();
            string employee = AppSetting.EmployessList.FirstOrDefault(x => x.EmployeeID == AppSetting.CurrentUser.EmployeeID).FullName;
            this.xrLabel48.Text = employee;
            this.xrLabel51.Text = AppSetting.CurrentUser.LoginName;
            this.xrLabel4.Text = fromDate.ToString("dd/MM/yyyy");
            this.xrLabel8.Text = toDate.ToString("dd/MM/yyyy");
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;
        }

        private void rptBillingByCustomerByGross_DataSourceDemanded(object sender, EventArgs e)
        {
            CreateCalculatedFields();
            this.xrLabel31.DataBindings.Add("Text", this.DataSource, "BeginC");
            this.xrLabel32.DataBindings.Add("Text", this.DataSource, "BeginGrossW");
            this.xrLabel33.DataBindings.Add("Text", this.DataSource, "InC");
            this.xrLabel34.DataBindings.Add("Text", this.DataSource, "InGrossW");
            this.xrLabel35.DataBindings.Add("Text", this.DataSource, "OutC");
            this.xrLabel36.DataBindings.Add("Text", this.DataSource, "OutGrossW");
            this.xrLabel37.DataBindings.Add("Text", this.DataSource, "CloseC");
            this.xrLabel38.DataBindings.Add("Text", this.DataSource, "CloseGrossW");
            this.xrLabel45.DataBindings.Add("Text", this.DataSource, "InC");
            this.xrLabel44.DataBindings.Add("Text", this.DataSource, "InGrossW");
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
            sumW.Expression = "Sum([BeginGrossW] + [InGrossW])";

            this.CalculatedFields.Add(sumW);
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
