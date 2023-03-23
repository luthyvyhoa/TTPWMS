using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;

namespace UI.ReportFile
{
    public partial class rptProblem_CustomerComplainsFDTD : DevExpress.XtraReports.UI.XtraReport
    {
        public rptProblem_CustomerComplainsFDTD(DateTime from, DateTime to)
        {
            InitializeComponent();
            this.xrLabel4.Text = from.ToString("dd/MM/yyyy");
            this.xrLabel8.Text = to.ToString("dd/MM/yyyy");
            this.xrLabel51.Text = AppSetting.CurrentUser.LoginName;
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;
        }

    }
}
