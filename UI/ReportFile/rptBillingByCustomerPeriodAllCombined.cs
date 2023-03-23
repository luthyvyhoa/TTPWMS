using System;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;
using System.Linq;
using DA;

namespace UI.ReportFile
{
    public partial class rptBillingByCustomerPeriodAllCombined : DevExpress.XtraReports.UI.XtraReport
    {
        private int _customerMainID;

        public rptBillingByCustomerPeriodAllCombined(int customerMainID)
        {
            InitializeComponent();
            this._customerMainID = customerMainID;
            var employeeFind = DA.FileProcess.LoadTable("select VietnamName,Position from Employees where employeeID=" + AppSetting.CurrentUser.EmployeeID);
            string employeeName = Convert.ToString(employeeFind.Rows[0]["VietnamName"]);
            string employeePosition = Convert.ToString(employeeFind.Rows[0]["Position"]);
            this.xrLabel30.Text = employeeName;
            this.xrLabel28.Text = employeePosition;
            this.xrLabel43.Text = AppSetting.CurrentUser.LoginName;
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;
        }

        private void rptBillingByCustomerPeriodAllCombined_DataSourceDemanded(object sender, EventArgs e)
        {
            DataProcess<STBillingConfirmationCombinedDetailReport_Result> billingDetailDA = new DataProcess<STBillingConfirmationCombinedDetailReport_Result>();
            DataProcess<STBillingConfirmationCombinedBiilingNo_Result> billingNoDA = new DataProcess<STBillingConfirmationCombinedBiilingNo_Result>();

            subrptBillingDetailBreakdown rptDetail = new subrptBillingDetailBreakdown();
            List<STBillingConfirmationCombinedDetailReport_Result> listBillingDetail = billingDetailDA.Executing("STBillingConfirmationCombinedDetailReport @CustomerMainID = {0}, @UserID = {1}", this._customerMainID, AppSetting.CurrentUser.LoginName).ToList();
            if(listBillingDetail.Count > 0)
            {
                rptDetail.DataSource = listBillingDetail;
                this.xrSubreport1.ReportSource = rptDetail;
            }
           
            subrptBillingCombinedBillingNo rptNo = new subrptBillingCombinedBillingNo();
            rptNo.DataSource = billingNoDA.Executing("STBillingConfirmationCombinedBiilingNo @CustomerMainID = {0}, @UserID = {1}", this._customerMainID, AppSetting.CurrentUser.LoginName);
            this.xrSubreport2.ReportSource = rptNo;
        }

        private void xrSubreport2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.xrSubreport2.SizeF = new SizeF(360, 100);
            this.xrSubreport2.SuspendLayout();
        }

        private void xrSubreport2_AfterPrint(object sender, EventArgs e)
        {
        }

        private void xrPictureBox1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string imagePath = AppSetting.PathSignature + AppSetting.CurrentUser.EmployeeID + ".jpg";
            if (System.IO.File.Exists(imagePath))
            {
                this.xrPictureBox1.Image = Image.FromFile(imagePath);
            }
        }
    }
}
