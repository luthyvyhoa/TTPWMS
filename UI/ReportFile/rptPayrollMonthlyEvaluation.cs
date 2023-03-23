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
    public partial class rptPayrollMonthlyEvaluation : DevExpress.XtraReports.UI.XtraReport
    {
        public rptPayrollMonthlyEvaluation(string payrollMonth)
        {
            InitializeComponent();
            string employeeName = AppSetting.CurrentEmployee.FullName;
            this.xrLabel3.Text = payrollMonth;
            this.xrLabel39.Text = AppSetting.CurrentUser.LoginName;
            this.xrLabel36.Text = employeeName;
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;

        }

        private void rptPayrollMonthlyEvaluation_DataSourceDemanded(object sender, EventArgs e)
        {
            this.GroupHeader2.GroupFields.Add(new GroupField("DepartmentName"));
        }
    }
}
