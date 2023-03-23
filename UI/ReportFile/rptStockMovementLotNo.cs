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
    public partial class rptStockMovementLotNo : DevExpress.XtraReports.UI.XtraReport
    {
        public rptStockMovementLotNo()
        {
            InitializeComponent();
            this.xrLabel36.Text = AppSetting.CurrentEmployee.FullName;
            this.xrLabel3.Text = "by: "+AppSetting.CurrentUser.LoginName;
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

        private void rptStockMovementLotNo_DataSourceDemanded(object sender, EventArgs e)
        {
            this.GroupHeader1.GroupFields.Add(new GroupField("CustomerNumber"));
        }

        private void xrLabel36_BeforePrint(object sender, CancelEventArgs e)
        {

        }
    }
}
