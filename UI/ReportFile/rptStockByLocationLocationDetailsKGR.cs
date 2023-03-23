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
    public partial class rptStockByLocationLocationDetailsKGR : DevExpress.XtraReports.UI.XtraReport
    {
        public rptStockByLocationLocationDetailsKGR()
        {
            InitializeComponent();
            string employeeName = AppSetting.CurrentEmployee.VietnamName;
            this.xrLabel6.Text = DateTime.Now.ToString("dd/MM/yyyy");
            this.xrLabel40.Text = employeeName;
            this.xrLabel31.Text = DateTime.Now.ToString("dd/MM/yyyy h:mm:ss tt ") + "by " + AppSetting.CurrentUser.LoginName;
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;
        }

        private void rptStockByLocationLocationDetailsKGR_DataSourceDemanded(object sender, EventArgs e)
        {
            this.GroupHeader2.GroupFields.Add(new GroupField("LocationNumber"));
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
