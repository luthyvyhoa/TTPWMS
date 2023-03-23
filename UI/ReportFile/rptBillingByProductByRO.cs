using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;
using DA;
using System.Linq;
using System.Collections.Generic;

namespace UI.ReportFile
{
    public partial class rptBillingByProductByRO : DevExpress.XtraReports.UI.XtraReport
    {

        public rptBillingByProductByRO(DateTime fromDate, DateTime toDate, string receivingOrderNumber,
            string recevingDate, string requirements)
        {
            InitializeComponent();
            this.xrLabel51.Text = AppSetting.CurrentUser.LoginName;
            this.xrLabel4.Text = fromDate.ToString("dd/MM/yyyy");
            this.xrLabel8.Text = toDate.ToString("dd/MM/yyyy");
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;

            // Set value
            this.lblRecevingOrderNumber.Text = receivingOrderNumber;
            this.lblRecevingOrderDate.Text = recevingDate;
            this.lblTruckNo.Text = requirements;
            //var query = " SELECT Products.ProductNumber, Products.ProductName, tmpProductsSQL.EmployeeID " +
            //             " FROM Products INNER JOIN tmpProductsSQL ON Products.ProductID = tmpProductsSQL.ProductID " +
            //             " WHERE tmpProductsSQL.EmployeeID=" + AppSetting.CurrentUser.EmployeeID +
            //             " ORDER BY Products.ProductNumber ";
            //// Load receiving order info
            //var dataSouce = FileProcess.LoadTable(query);
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


            CalculatedField sumOverP = new CalculatedField();
            sumOverP.DataSource = this.DataSource;
            sumOverP.DataMember = this.DataMember;
            sumOverP.Name = "sumOverP";
            sumOverP.DisplayName = "sumOverP";
            //sumOverP.Expression = "Iif([BeginP]-0+[InP]<0,0,[BeginP]-0+[InP])"; công thức củ
            sumOverP.Expression = "Sum(Iif(([BeginP]+[InP])<0,0,([BeginP]+[InP])))"; // công thức chỉnh sửa
            this.CalculatedFields.Add(sumOverP);
        }

        private void xrLabel3_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            DataProcess<Employees> empDA = new DataProcess<Employees>();
            var fullname = empDA.Select(a => a.EmployeeID == AppSetting.CurrentUser.EmployeeID).FirstOrDefault().VietnamName;
            this.xrLabel3.Text = fullname;
        }

        private void xrPictureBox1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string imagePath = AppSetting.PathSignature + AppSetting.CurrentUser.EmployeeID + ".jpg";
            if (System.IO.File.Exists(imagePath))
            {
                this.xrPictureBox1.Image = Image.FromFile(imagePath);
            }
        }

        private void rptBillingByProductByRO_DataSourceDemanded(object sender, EventArgs e)
        {
            CreateCalculatedFields();
            this.xrLabel41.DataBindings.Add("Text", this.DataSource, "BeginC");
            this.xrLabel64.DataBindings.Add("Text", this.DataSource, "BeginP");
            this.xrLabel40.DataBindings.Add("Text", this.DataSource, "BeginW");
            this.xrLabel39.DataBindings.Add("Text", this.DataSource, "InC");
            this.xrLabel63.DataBindings.Add("Text", this.DataSource, "InP");
            this.xrLabel34.DataBindings.Add("Text", this.DataSource, "InW");
            this.xrLabel35.DataBindings.Add("Text", this.DataSource, "OutC");
            this.xrLabel62.DataBindings.Add("Text", this.DataSource, "OutP");
            this.xrLabel36.DataBindings.Add("Text", this.DataSource, "OutW");
            this.xrLabel37.DataBindings.Add("Text", this.DataSource, "CloseC");
            this.xrLabel61.DataBindings.Add("Text", this.DataSource, "CloseP");
            this.xrLabel38.DataBindings.Add("Text", this.DataSource, "CloseW");
        }
    }
}
