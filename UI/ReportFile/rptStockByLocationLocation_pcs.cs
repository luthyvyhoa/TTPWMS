using System;
using System.Linq;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;

namespace UI.ReportFile
{
    public partial class rptStockByLocationLocation_pcs : DevExpress.XtraReports.UI.XtraReport
    {
        public rptStockByLocationLocation_pcs()
        {
            InitializeComponent();
            string employeeName = AppSetting.EmployessList.FirstOrDefault(e => e.EmployeeID == AppSetting.CurrentUser.EmployeeID).FullName;
            xrLabel40.Text = employeeName;
            this.xrLabel31.Text = AppSetting.CurrentUser.LoginName.ToUpper() + " - " + DateTime.Now.ToString("dddd, d MMMM, yyyy h:mm:ss tt");
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;
        }

        private void rptStockByLocationLocation_pcs_DataSourceDemanded(object sender, EventArgs e)
        {
            this.GroupHeader1.GroupFields.Add(new GroupField("LocationNumber"));
            this.GroupHeader2.GroupFields.Add(new GroupField("ID"));
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
