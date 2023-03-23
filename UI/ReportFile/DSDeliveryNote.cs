using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI;
using UI.Helper;

namespace SCSVN.Report
{
    public partial class DSDeliveryNote : DevExpress.XtraReports.UI.XtraReport
    {
        public DSDeliveryNote(string varOrderNumber, string varUserName, string varPic_Sign_Url)
        {
            InitializeComponent();

            this.parameter1.Value = varOrderNumber;// DateTime.Today;
            this.parameter2.Value = varUserName;
            this.xrPictureBoxSignature.ImageUrl = varPic_Sign_Url;
            this.xrPictureBox1.Image = UI.Properties.Resources.ImageCompany;
        }

        private void xrName_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.xrName.Text = AppSetting.CurrentUser.LoginName;
        }
    }
}
