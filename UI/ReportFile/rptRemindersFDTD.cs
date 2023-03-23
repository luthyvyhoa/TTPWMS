using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;
using DA;
using System.Data;

namespace UI.ReportFile
{
    public partial class rptRemindersFDTD : DevExpress.XtraReports.UI.XtraReport
    {
        public rptRemindersFDTD()
        {
            InitializeComponent();

            InitData();
        }

        private void InitData()
        {
            //xrLabel3.Text = DateTime.Now.AddDays(-30).ToString("M/dd/yyyy");
            //xrLabel5.Text = DateTime.Now.ToString("M/dd/yyyy");
            this.xrLabel37.Text = "by " + AppSetting.CurrentUser.LoginName;
        }

        private void rptRemindersFDTD_DataSourceDemanded(object sender, EventArgs e)
        {
            //string queryString = "SELECT EmployeeReminders.ReminderID, EmployeeReminders.RoomID, EmployeeReminders.EmployeeID,"
            //+ "EmployeeReminders.ReminderDescription, FORMAT(EmployeeReminders.ReminderDate, 'dd/MM/yyyy') as 'ReminderDate', EmployeeReminders.ReminderAcknowledged, "
            //+ "EmployeeReminders.AcknowledgedTime, EmployeeReminders.ReminderedBy, EmployeeReminders.AcknowledgedBy, Employees.VietnamName "
            //+ "FROM Employees RIGHT JOIN EmployeeReminders ON Employees.EmployeeID = EmployeeReminders.EmployeeID "
            //+ "WHERE EmployeeReminders.ReminderDate Between GETDATE()-30 And GETDATE()"
            //+ "ORDER BY Employees.EmployeeID";

            //this.DataSource = FileProcess.LoadTable(queryString);
        }
    }
}
