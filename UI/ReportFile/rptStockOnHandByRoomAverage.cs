using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;
using System.Linq;
using System.Collections.Generic;

namespace UI.ReportFile
{
    public partial class rptStockOnHandByRoomAverage : DevExpress.XtraReports.UI.XtraReport
    {
        private DateTime fromDate = DateTime.Now;
        private DateTime ToDate = DateTime.Now;
        private int capacityValue = 0;
        public rptStockOnHandByRoomAverage(DateTime fromDate, DateTime toDate)
        {
            InitializeComponent();
            this.xrDateFrom.Text = fromDate.ToString("dd/MM/yyyy");
            this.xrDateTo.Text = toDate.ToString("dd/MM/yyyy");
            this.xrDateNumber.Text = (toDate.Date.Day - fromDate.Date.Day) + 1 + "";
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;
        }

        private void rptStockOnHandByRoomAverage_BeforePrint(object sender, CancelEventArgs e)
        {
            this.xrLabel33.Text = "by [" + AppSetting.CurrentUser.LoginName + "]";
        }

        private void xrLabel16_SummaryCalculated(object sender, TextFormatEventArgs e)
        {
            try
            {
                if (this.capacityValue <= 0)
                {
                    lblOccurpancyPercen.Text = string.Empty;
                    return;
                }
                lblOccurpancyPercen.Text = Math.Round(((decimal)e.Value / this.capacityValue) * 100, 2) + "%";
            }
            catch (Exception)
            {
                lblOccurpancyPercen.Text = string.Empty;
            }
        }

        private void xrLabel15_BeforePrint(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(((DevExpress.XtraReports.UI.XRLabel)sender).Text))
            {
                this.capacityValue = (int)this.GetCurrentColumnValue("Capacity");
            }
        }
    }
}
