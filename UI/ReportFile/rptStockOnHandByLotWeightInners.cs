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
    public partial class rptStockOnHandByLotWeightInners : DevExpress.XtraReports.UI.XtraReport
    {
        public rptStockOnHandByLotWeightInners()
        {
            InitializeComponent();
            //this.xrLabel6.Text = DateTime.Now.ToString("dd/MM/yyyy");
            this.xrLabel50.Text = "by " + AppSetting.CurrentUser.LoginName;
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;
        }

        private void rptStockOnHandByLotWeightInners_DataSourceDemanded(object sender, EventArgs e)
        {
            CreateCalculatedField();
            this.GroupHeader1.GroupFields.Add(new GroupField("ProductNumber"));
            this.xrLabel40.DataBindings.Add("Text", this.DataSource, "TotalPackages");
            this.xrLabel37.DataBindings.Add("Text", this.DataSource, "SumOfAfterDPQuantity");
            this.xrLabel38.DataBindings.Add("Text", this.DataSource, "UnitQuantityRemain");
            this.xrLabel39.DataBindings.Add("Text", this.DataSource, "PalletWeightRemain");
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

            CalculatedField sumUnit = new CalculatedField();
            sumUnit.DataSource = this.DataSource;
            sumUnit.DataMember = this.DataMember;
            sumUnit.Name = "sumUnit";
            sumUnit.DisplayName = "sumUnit";
            sumUnit.Expression = "Sum([UnitQuantityRemain])";

            this.CalculatedFields.Add(sumUnit);

            CalculatedField sumPallet = new CalculatedField();
            sumPallet.DataSource = this.DataSource;
            sumPallet.DataMember = this.DataMember;
            sumPallet.Name = "sumPallet";
            sumPallet.DisplayName = "sumPallet";
            sumPallet.Expression = "Sum([PalletWeightRemain])";

            this.CalculatedFields.Add(sumPallet);
        }

        private void xrPictureBox1_BeforePrint(object sender, CancelEventArgs e)
        {
            string imagePath = AppSetting.PathSignature + AppSetting.CurrentUser.EmployeeID + ".jpg";
            if (System.IO.File.Exists(imagePath))
            {
                this.xrPictureBox1.Image = Image.FromFile(imagePath);
            }
        }

        private void xrLabel6_BeforePrint(object sender, CancelEventArgs e)
        {
            DataProcess<Employees> empDA = new DataProcess<Employees>();
            var fullname = empDA.Select(a => a.EmployeeID == AppSetting.CurrentUser.EmployeeID).FirstOrDefault().FullName;
            this.xrLabel6.Text = fullname;
        }
    }
}
