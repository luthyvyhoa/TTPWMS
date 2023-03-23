using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;
using DA;
using System.Collections.Generic;
using DevExpress.DataAccess.Native.Data;
using System.Data;
using System.Linq;

namespace UI.ReportFile
{
    public partial class rptBillingSummary : DevExpress.XtraReports.UI.XtraReport
    {
        private int allConfirm = 0;
        private int unConfirm = 0;

        public rptBillingSummary(DataRowCollection list, BillingSummary billingSummary, string fullName, int allConfirm, int unconfirm)
        {
            InitializeComponent();

            this.allConfirm = allConfirm;
            this.unConfirm = unconfirm;
            InitData(list, billingSummary, fullName);
            this.xrPictureBox1.Image = UI.Properties.Resources.ImageCompany;
        }

        private void InitData(DataRowCollection list, BillingSummary billingSummary, string fullName)
        {
            lblUsernameFooter.Text = "by " + AppSetting.CurrentUser.LoginName;
            lblPeriod.Text = billingSummary.Period;
            lblFrom.Text = billingSummary.FromDate.ToString("dd/MM/yyyy");
            lblTo.Text = billingSummary.ToDate.ToString("dd/MM/yyyy");

            lblTotal1.Text = this.allConfirm.ToString();
            lblTotal2.Text = this.unConfirm.ToString();
            lblTotal3.Text = (this.allConfirm - this.unConfirm).ToString();
        }

        private void xrLabel9_BeforePrint(object sender, CancelEventArgs e)
        {
            DataProcess<Employees> empDA = new DataProcess<Employees>();
            var fullname = empDA.Select(a => a.EmployeeID == AppSetting.CurrentUser.EmployeeID).FirstOrDefault().FullName;
            this.xrLabel9.Text = fullname;
        }

        private void xrPictureBox2_BeforePrint(object sender, CancelEventArgs e)
        {
            string imagePath = AppSetting.PathSignature + AppSetting.CurrentUser.EmployeeID + ".jpg";
            if (System.IO.File.Exists(imagePath))
            {
                this.xrPictureBox2.Image = Image.FromFile(imagePath);
            }
        }
    }
}
