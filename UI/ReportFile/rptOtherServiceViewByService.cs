using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DA;
using UI.Helper;

namespace UI.ReportFile
{
    public partial class rptOtherServiceViewByService : DevExpress.XtraReports.UI.XtraReport
    {
        public rptOtherServiceViewByService(DateTime from, DateTime to, ServicesDefinition serviceID, string fullName)
        {
            InitializeComponent();

            InitData(from, to, serviceID, fullName);
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;
        }

        public rptOtherServiceViewByService(DateTime from, DateTime to, int customerID, string customerNumber, string customerName)
        {
            InitializeComponent();
            lblFrom.Text = from.ToString("dd/MM/yyyy");
            lblTo.Text = to.ToString("dd/MM/yyyy");
            lblEmployeeName.Text = AppSetting.CurrentUser.VietnamName ;
            lblUsernameFooter.Text = "Kỷ Nguyên Mới - Printed by " + AppSetting.CurrentUser.LoginName + " - ";
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;
        }

        private void InitData(DateTime from, DateTime to, ServicesDefinition serviceID, string fullName)
        {
            lblFrom.Text = from.ToString("dd/MM/yyyy");
            lblTo.Text = to.ToString("dd/MM/yyyy");
            lblServiceNumber.Text = serviceID.ServiceNumber.ToString();
            lblServiceName.Text = serviceID.ServiceName;
            lblEmployeeName.Text = fullName;
            lblUsernameFooter.Text = "Kỷ Nguyên Mới - Printed by " + AppSetting.CurrentUser.LoginName + " - ";
        }

        private void xrPictureBox1_BeforePrint(object sender, CancelEventArgs e)
        {
            string imagePath = AppSetting.PathSignature + AppSetting.CurrentUser.EmployeeID + ".jpg";
            if (System.IO.File.Exists(imagePath))
            {
                this.xrPictureBox1.Image= Image.FromFile(imagePath);
            }
        }


    }
}
