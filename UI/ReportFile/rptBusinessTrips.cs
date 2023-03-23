using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;
using DA;
using System.Linq;
namespace UI.ReportFile
{
    public partial class rptBusinessTrips : DevExpress.XtraReports.UI.XtraReport
    {
        public rptBusinessTrips()
        {
            InitializeComponent();
            DataProcess<Employees> dataProcess = new DataProcess<Employees>();
            var fullInfoEmployees = dataProcess.Select(em => em.EmployeeID == AppSetting.CurrentUser.EmployeeID).FirstOrDefault();
            xrLabel129.Text = fullInfoEmployees.FullName;
            this.xrLabel29.Text = "By: " + AppSetting.CurrentUser.LoginName;
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;
        }
        
    }
}
