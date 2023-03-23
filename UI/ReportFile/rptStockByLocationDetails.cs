using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;

namespace UI.ReportFile
{
    public partial class rptStockByLocationDetails : DevExpress.XtraReports.UI.XtraReport
    {
        private string _customerRef;
        private double totalQty = 0;

        public rptStockByLocationDetails()
        {
            InitializeComponent();
            this.xrLabel6.Text = DateTime.Now.ToString("dd/MM/yyyy");
            this.xrLabel42.Text ="by: "+ AppSetting.CurrentUser.LoginName;
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;
        }

        public rptStockByLocationDetails(string customerRef)
        {
            InitializeComponent();
            this._customerRef = customerRef;
        }

        private void rptStockByLocationDetails_DataSourceDemanded(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this._customerRef))
            {
                this.xrLabel32.Text = this._customerRef;
            }
            this.groupHeaderID.GroupFields.Add(new GroupField("ID"));
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
