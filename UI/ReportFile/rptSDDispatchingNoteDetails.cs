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
    public partial class rptSDDispatchingNoteDetails : DevExpress.XtraReports.UI.XtraReport
    {
        public rptSDDispatchingNoteDetails(string customerNumber, string customerName, DateTime fromDate, DateTime toDate)
        {
            InitializeComponent();
            string employeeName = AppSetting.CurrentEmployee.FullName;
            this.xrLabel2.Text = "Customer:  " + customerNumber;
            this.xrLabel3.Text = "From:    " + fromDate.ToString("dd/MM/yyyy");
            this.xrLabel4.Text = customerName;
            this.xrLabel5.Text = "To:     " + toDate.ToString("dd/MM/yyyy");
            this.xrLabel43.Text = "by " + AppSetting.CurrentUser.LoginName;
            this.xrLabel41.Text = employeeName;
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;
        }

    }
}
