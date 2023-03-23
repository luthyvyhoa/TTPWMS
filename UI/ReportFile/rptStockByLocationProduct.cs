using System;
using System.Linq;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;
using DA;

namespace UI.ReportFile
{
    public partial class rptStockByLocationProduct : DevExpress.XtraReports.UI.XtraReport
    {
        public rptStockByLocationProduct()
        {
            InitializeComponent();
            string employeeName = AppSetting.CurrentEmployee.FullName;
            this.xrLabel31.Text = "by " + AppSetting.CurrentUser.LoginName;
            this.xrLabel40.Text = employeeName;
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;
            //this.xrLabel6.Text = ToString("dd/MM/yyyy");
        }

        private void rptStockByLocationProduct_DataSourceDemanded(object sender, EventArgs e)
        {
            this.GroupHeader2.GroupFields.Add(new GroupField("ID"));
            this.GroupHeader1.GroupFields.Add(new GroupField("ID"));
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
