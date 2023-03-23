using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;

namespace UI.ReportFile
{
    public partial class rptPayrollMonthlyOvertimeByDept : DevExpress.XtraReports.UI.XtraReport
    {
        public rptPayrollMonthlyOvertimeByDept(DateTime from, DateTime to, string fullName)
        {
            InitializeComponent();

            InitData(from, to, fullName);
        }

        private void InitData(DateTime from, DateTime to, string fullName)
        {
            lblFrom.Text = from.ToString("M/dd/yyyy");
            lblTo.Text = to.ToString("M/dd/yyyy");
            lblCreated.Text = fullName;
            lblFooterName.Text = "by " + AppSetting.CurrentUser.LoginName;
        }
    }
}
