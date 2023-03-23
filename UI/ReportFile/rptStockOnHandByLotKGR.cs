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
    public partial class rptStockOnHandByLotKGR : DevExpress.XtraReports.UI.XtraReport
    {
        public rptStockOnHandByLotKGR()
        {
            InitializeComponent();
            this.xrLabel40.Text = "by " + AppSetting.CurrentUser.LoginName;
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;
        }

        private void rptStockOnHandByLotKGR_DataSourceDemanded(object sender, EventArgs e)
        {
            CreateCalculatedField();
            this.GroupHeader1.GroupFields.Add(new GroupField("ProductNumber"));
            this.xrLabel31.DataBindings.Add("Text", this.DataSource, "SumOfAfterDPQuantity");
            this.xrLabel32.DataBindings.Add("Text", this.DataSource, "calAfterWeight");
            this.xrLabel36.DataBindings.Add("Text", this.DataSource, "ProductNumber");
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

            CalculatedField sumAfterWeight = new CalculatedField();
            sumAfterWeight.DataSource = this.DataSource;
            sumAfterWeight.DataMember = this.DataMember;
            sumAfterWeight.Name = "sumAfterWeight";
            sumAfterWeight.DisplayName = "sumAfterWeight";
            sumAfterWeight.Expression = "Sum([SumOfAfterDPQuantity]*[WeightPerPackage])";

            this.CalculatedFields.Add(sumAfterWeight);

            CalculatedField countProducts = new CalculatedField();
            countProducts.DataSource = this.DataSource;
            countProducts.DataMember = this.DataMember;
            countProducts.Name = "countProducts";
            countProducts.DisplayName = "countProducts";
            countProducts.Expression = "Count()";

            this.CalculatedFields.Add(countProducts);

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

        private void xrFullName_BeforePrint(object sender, CancelEventArgs e)
        {
            DataProcess<Employees> empDA = new DataProcess<Employees>();
            var fullname = empDA.Select(a => a.EmployeeID == AppSetting.CurrentUser.EmployeeID).FirstOrDefault()?.FullName;
            this.xrFullName.Text = fullname;
        }
    }
}
