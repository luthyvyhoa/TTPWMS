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
    public partial class rptOtherService : DevExpress.XtraReports.UI.XtraReport
    {
        public rptOtherService()
        {
            InitializeComponent();
            string employeeName = AppSetting.CurrentEmployee.FullName;
            string employeePosition = AppSetting.CurrentEmployee.Position;
            this.xrLabel34.Text = employeeName;
            this.xrLabel35.Text = employeePosition;
            this.xrLabel37.Text = "by " + AppSetting.CurrentUser.LoginName;
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;
        }

        private void rptOtherService_DataSourceDemanded(object sender, EventArgs e)
        {
            this.sumQuantity.DataSource = this.DataSource;
            this.sumQuantity.DataMember = this.DataMember;
        }

        private void xrPictureBox1_BeforePrint(object sender, CancelEventArgs e)
        {
            string imagePath = AppSetting.PathSignature + AppSetting.CurrentUser.EmployeeID + ".jpg";
            if (System.IO.File.Exists(imagePath))
            {
                this.xrPictureBox1.Image = Image.FromFile(imagePath);
            }
        }
    }
}
