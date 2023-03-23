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
    public partial class rptStockOnHandByLotByRO : DevExpress.XtraReports.UI.XtraReport
    {
        public rptStockOnHandByLotByRO()
        {
            InitializeComponent();
            this.xrLabel6.Text = DateTime.Now.ToString("dd/MM/yyyy");
            this.xrLabel50.Text = "by " + AppSetting.CurrentUser.LoginName;
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;
        }

        private void rptStockOnHandByLotByRO_DataSourceDemanded(object sender, EventArgs e)
        {
            CreateCalculatedField();
            this.GroupHeader1.GroupFields.Add(new GroupField("ReceivingOrderNumber"));
            this.xrLabel37.DataBindings.Add("Text", this.DataSource, "TotalPackages");
            this.xrLabel38.DataBindings.Add("Text", this.DataSource, "SumOfAfterDPQuantity");
            this.xrLabel39.DataBindings.Add("Text", this.DataSource, "calAfterWeight");
        }

        private void CreateCalculatedField()
        {
            CalculatedField sumAfter = new CalculatedField();
            sumAfter.DataSource = this.DataSource;
            sumAfter.DataMember = this.DataMember;
            sumAfter.Name = "sumAfter";
            sumAfter.DisplayName = "sumAfter";
            sumAfter.Expression = "Sum([SumOfAfterDPQuantity])";

            this.CalculatedFields.Add(sumAfter);

            CalculatedField sumTotal = new CalculatedField();
            sumTotal.DataSource = this.DataSource;
            sumTotal.DataMember = this.DataMember;
            sumTotal.Name = "sumPackage";
            sumTotal.DisplayName = "sumPackage";
            sumTotal.Expression = "Sum([TotalPackages])";

            this.CalculatedFields.Add(sumTotal);

            CalculatedField sumAfterWeight = new CalculatedField();
            sumAfterWeight.DataSource = this.DataSource;
            sumAfterWeight.DataMember = this.DataMember;
            sumAfterWeight.Name = "sumAfterWeight";
            sumAfterWeight.DisplayName = "sumAfterWeight";
            sumAfterWeight.Expression = "Sum([SumOfAfterDPQuantity]*[WeightPerPackage])";

            this.CalculatedFields.Add(sumAfterWeight);

            CalculatedField calAfterWeight = new CalculatedField();
            calAfterWeight.DataSource = this.DataSource;
            calAfterWeight.DataMember = this.DataMember;
            calAfterWeight.Name = "calAfterWeight";
            calAfterWeight.DisplayName = "calAfterWeight";
            calAfterWeight.Expression = "[SumOfAfterDPQuantity]*[WeightPerPackage]";

            this.CalculatedFields.Add(calAfterWeight);
        }

        private void xrPictureBox1_BeforePrint(object sender, CancelEventArgs e)
        {
            string imagePath = AppSetting.PathSignature + AppSetting.CurrentUser.EmployeeID + ".jpg";
            if (System.IO.File.Exists(imagePath))
            {
                this.xrPictureBox1.Image = Image.FromFile(imagePath);
            }
        }

        private void xrLabel34_BeforePrint(object sender, CancelEventArgs e)
        {
            DataProcess<Employees> empDA = new DataProcess<Employees>();
            var fullname = empDA.Select(a => a.EmployeeID == AppSetting.CurrentUser.EmployeeID).FirstOrDefault().FullName;
            this.xrLabel34.Text = fullname;
        }
    }
}
