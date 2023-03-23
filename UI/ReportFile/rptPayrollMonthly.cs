using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;

namespace UI.ReportFile
{
    public partial class rptPayrollMonthly : DevExpress.XtraReports.UI.XtraReport
    {
        public rptPayrollMonthly()
        {
            InitializeComponent();
            this.xrPageInfo1.Format = AppSetting.CurrentUser.LoginName + " - {0:dd/MM/yyyy HH:mm tt}";
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;
            this.xrEmployeeName.Text = AppSetting.CurrentEmployee.VietnamName;
        }
    }
}
