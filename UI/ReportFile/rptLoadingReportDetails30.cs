using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;
using DA;
using System.Linq;
using System.Drawing.Printing;

namespace UI.ReportFile
{
    public partial class rptLoadingReportDetails30 : DevExpress.XtraReports.UI.XtraReport
    {
        public rptLoadingReportDetails30(int varDispatchingOrderID)
        {
            InitializeComponent();
            this.varDispatchingOrderID.Value = varDispatchingOrderID;
            DataProcess<Employees> dataProcess = new DataProcess<Employees>();
            var fullInfoEmployees = dataProcess.Select(em => em.EmployeeID == AppSetting.CurrentUser.EmployeeID).FirstOrDefault();
            xrLabel129.Text = fullInfoEmployees.FullName;
            this.xrLabel128.Text ="By: "+ AppSetting.CurrentUser.LoginName;
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

        private void rptLoadingReportDetails_BeforePrint(object sender, CancelEventArgs e)
        {
        }

        private void rptLoadingReportDetails_PrintProgress(object sender, DevExpress.XtraPrinting.PrintProgressEventArgs e)
        {
        }
    }
}
