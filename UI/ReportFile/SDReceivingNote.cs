using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace SCSVN.Report
{
    public partial class SDReceivingNote : DevExpress.XtraReports.UI.XtraReport
    {
        public SDReceivingNote()
        {
            InitializeComponent();
            this.xrPictureBox1.Image = UI.Properties.Resources.ImageCompany;
        }

    }
}
