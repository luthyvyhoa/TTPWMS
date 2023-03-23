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
    public partial class rptBillingEstimations : DevExpress.XtraReports.UI.XtraReport
    {
        
        public rptBillingEstimations(DateTime dtFromDate, DateTime dtToDate)
        {
            InitializeComponent();
            xrLabel7.Text = dtFromDate.ToString("dd/MM/yyyy");
            xrLabel8.Text = dtToDate.ToString("dd/MM/yyyy");


            this.xrLabel43.Text = "Kỷ Nguyên Mới | Printed "+ DateTime.Now.ToString("dd/MM/yyyy HH:mm") +" by: " + AppSetting.CurrentUser.LoginName;

        }

    }
}
