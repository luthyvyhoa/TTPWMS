using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DA;
using UI.Helper;
using System.Linq;

namespace UI.ReportFile
{
    public partial class rptMHLWorkMultiNote : DevExpress.XtraReports.UI.XtraReport
    {
        public rptMHLWorkMultiNote()
        {
            InitializeComponent();
           
            string employeeName = AppSetting.CurrentEmployee.FullName;
            this.xrLabel32.Text = employeeName;
            this.xrLabel40.Text = "by " + AppSetting.CurrentUser.LoginName;
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;
        }

        private void xrPictureBox1_BeforePrint(object sender, CancelEventArgs e)
        {
            string imagePath = AppSetting.PathSignature + AppSetting.CurrentUser.EmployeeID + ".jpg";
            if (System.IO.File.Exists(imagePath))
            {
                this.xrPictureBox1.Image = Image.FromFile(imagePath);
            }
        }

        private void rptMHLWorkMultiNote_DataSourceDemanded(object sender, EventArgs e)
        {
            //this.sumQty.DataSource = this.DataSource;
            //this.sumQty.DataMember = this.DataMember;
            //this.sumTotal.DataSource = this.DataSource;
            //this.sumTotal.DataMember = this.DataMember;
        }

    }
}
