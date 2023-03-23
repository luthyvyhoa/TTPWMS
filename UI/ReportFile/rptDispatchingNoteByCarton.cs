using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;

namespace UI.ReportFile
{
    public partial class rptDispatchingNoteByCarton : DevExpress.XtraReports.UI.XtraReport
    {
        public rptDispatchingNoteByCarton()
        {
            InitializeComponent();
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;

        }

        private void xrPictureBox1_BeforePrint(object sender, CancelEventArgs e)
        {
            string imagePath = AppSetting.PathSignature + AppSetting.CurrentUser.EmployeeID + ".jpg";
            if (System.IO.File.Exists(imagePath))
            {
                this.xrPictureBox1.Image = Image.FromFile(imagePath);
            }
        }
    }
}
