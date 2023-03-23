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
    public partial class rptBillingByDispatchingOrders : DevExpress.XtraReports.UI.XtraReport
    {
        public rptBillingByDispatchingOrders()
        {
            InitializeComponent();
            this.xrLabel43.Text = AppSetting.CurrentUser.LoginName;
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;
        }

        private void rptBillingByDispatchingOrders_DataSourceDemanded(object sender, EventArgs e)
        {
            this.GroupHeader4.GroupFields.Add(new GroupField("DispatchingOrderNumber"));
            this.GroupHeader3.GroupFields.Add(new GroupField("ProductNumber"));
            this.fieldDays.DataSource = this.DataSource;
            this.fieldDays.DataMember = this.DataMember;
            this.fieldNonWeight.DataSource = this.DataSource;
            this.fieldNonWeight.DataMember = this.DataMember;
            this.fieldWeight.DataSource = this.DataSource;
            this.fieldWeight.DataMember = this.DataMember;
            this.xrLabel31.DataBindings.Add("Text", this.DataSource, "ReceivedQty");
            this.xrLabel32.DataBindings.Add("Text", this.DataSource, "fieldNonWeight");
            this.xrLabel33.DataBindings.Add("Text", this.DataSource, "fieldWeight");
            this.xrLabel36.DataBindings.Add("Text", this.DataSource, "fieldNonWeight");
            this.xrLabel37.DataBindings.Add("Text", this.DataSource, "fieldWeight");
        }

        private void xrLabel44_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.xrLabel44.Text = AppSetting.CurrentEmployee.FullName;
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
