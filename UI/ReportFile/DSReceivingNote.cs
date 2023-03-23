using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI;


namespace SCSVN.Report
{
    public partial class DSReceivingNote : DevExpress.XtraReports.UI.XtraReport
    {
        public DSReceivingNote(string varOrderNumber, string varUserName, string varPic_Sign_Url)
        {
            InitializeComponent();

            this.parameter1.Value = varOrderNumber;// DateTime.Today;
            this.parameter2.Value = varUserName;// DateTime.Today;
            this.xrPictureBoxSignature.ImageUrl = varPic_Sign_Url;
            this.xrPictureBox1.Image = UI.Properties.Resources.ImageCompany;
        }

    }
}
