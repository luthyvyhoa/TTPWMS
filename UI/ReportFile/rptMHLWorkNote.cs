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
    public partial class rptMHLWorkNote : DevExpress.XtraReports.UI.XtraReport
    {
        public rptMHLWorkNote()
        {
            InitializeComponent();
            string employeeName = AppSetting.CurrentEmployee.FullName;

            this.xrLabel32.Text = employeeName;
            this.xrLabel40.Text = "by " + AppSetting.CurrentUser.LoginName;
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;
        }

        private void rptMHLWorkNote_DataSourceDemanded(object sender, EventArgs e)
        {
            this.sumQty.DataSource = this.DataSource;
            this.sumQty.DataMember = this.DataMember;
            this.sumTotal.DataSource = this.DataSource;
            this.sumTotal.DataMember = this.DataMember;
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
