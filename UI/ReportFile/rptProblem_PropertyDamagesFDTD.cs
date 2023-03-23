using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace UI.ReportFile
{
    public partial class rptProblem_PropertyDamagesFDTD : DevExpress.XtraReports.UI.XtraReport
    {
        public rptProblem_PropertyDamagesFDTD()
        {
            InitializeComponent();
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;
        }

    }
}
