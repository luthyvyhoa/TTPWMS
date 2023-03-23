using System;
using System.Linq;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;

namespace UI.ReportFile
{
    public partial class rptQualityCheckingFDTD : DevExpress.XtraReports.UI.XtraReport
    {
        public rptQualityCheckingFDTD(DateTime from, DateTime to)
        {
            InitializeComponent();
            string employeeName = AppSetting.EmployessList.FirstOrDefault(e => e.EmployeeID == AppSetting.CurrentUser.EmployeeID).FullName;
            this.xrLabel4.Text = from.ToString("dd/MM/yyyy");
            this.xrLabel5.Text = to.ToString("dd/MM/yyyy");
            this.xrLabel26.Text = "Prepared by :  " + employeeName;
            this.xrLabel51.Text = AppSetting.CurrentUser.LoginName;
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;

        }

        private void rptQualityCheckingFDTD_DataSourceDemanded(object sender, EventArgs e)
        {
            this.GroupHeader1.GroupFields.Add(new GroupField("CustomerNumber"));
            this.GroupHeader2.GroupFields.Add(new GroupField("QualityCheckingDate"));
            this.xrLabel15.DataBindings.Add("Text", this.DataSource, "QuantityOfPackages");
            this.xrLabel17.DataBindings.Add("Text", this.DataSource, "TotalUnits");
            this.xrLabel18.DataBindings.Add("Text", this.DataSource, "TotalWeight");
            this.xrLabel19.DataBindings.Add("Text", this.DataSource, "CheckingQuantity");
            this.xrLabel24.DataBindings.Add("Text", this.DataSource, "QuantityOfPackages");
            this.xrLabel23.DataBindings.Add("Text", this.DataSource, "TotalUnits");
            this.xrLabel22.DataBindings.Add("Text", this.DataSource, "TotalWeight");
            this.xrLabel21.DataBindings.Add("Text", this.DataSource, "CheckingQuantity");
        }
    }
}
