using System;
using System.Linq;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DA;
using UI.Helper;

namespace UI.ReportFile
{
    public partial class rptNotes : DevExpress.XtraReports.UI.XtraReport
    {
        Employees currentEmployee = null;
        public rptNotes()
        {
            InitializeComponent();
            currentEmployee = AppSetting.CurrentEmployee;
            this.xrLabel20.Text = currentEmployee.VietnamName;
            this.xrLabel22.Text = AppSetting.CurrentUser.LoginName;
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

        private void xrLabel19_BeforePrint(object sender, CancelEventArgs e)
        {
            int supervisorID = Convert.ToInt32(this.GetCurrentColumnValue("SupervisorID"));
            if (supervisorID > 0)
            {
                DataProcess<Employees> dataProcess = new DataProcess<Employees>();
                var employeeInfo = dataProcess.Select(em => em.EmployeeID == AppSetting.CurrentUser.EmployeeID).FirstOrDefault();
                string supervisorName = employeeInfo.VietnamName;
                this.xrLabel19.Text = supervisorName;
            }
        }

        private void xrLabel4_BeforePrint(object sender, CancelEventArgs e)
        {
            this.xrLabel4.Text = "Họ và tên: " + currentEmployee.VietnamName;
        }

        private void xrLabel5_BeforePrint(object sender, CancelEventArgs e)
        {
            this.xrLabel5.Text = "Chức vụ:    " + currentEmployee.VietnamPosition;
        }
    }
}
