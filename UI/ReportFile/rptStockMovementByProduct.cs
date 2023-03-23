using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;

namespace UI.ReportFile
{
    public partial class rptStockMovementByProduct : DevExpress.XtraReports.UI.XtraReport
    {
        public rptStockMovementByProduct(DateTime fromDate, DateTime toDate)
        {
            InitializeComponent();
            this.xrLabel28.Text = "by " + AppSetting.CurrentUser.LoginName;
            this.xrLabel6.Text = "From : " + fromDate.ToString("dd/MM/yyyy");
            this.xrLabel7.Text = "To : " + toDate.ToString("dd/MM/yyyy");
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;
        }

    }
}
