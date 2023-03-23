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
    public partial class rptDispatchingNote_Trip : DevExpress.XtraReports.UI.XtraReport
    {
        public rptDispatchingNote_Trip()
        {
            InitializeComponent();
            string employeeName = AppSetting.CurrentEmployee.VietnamName;
            this.xrLabel51.Text = employeeName;
            this.xrLabel46.Text = AppSetting.CurrentUser.LoginName;
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

        private void rptDispatchingNote_Trip_DataSourceDemanded(object sender, EventArgs e)
        {
            this.GroupHeader2.GroupFields.Add(new GroupField("DispatchingOrderNumber"));
            this.GroupHeader1.GroupFields.Add(new GroupField("CustomerName"));
        }
    }
}
