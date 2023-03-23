using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;

namespace UI.ReportFile
{
    public partial class rptLabel_BarcodeRandom : DevExpress.XtraReports.UI.XtraReport
    {
        public rptLabel_BarcodeRandom()
        {
            InitializeComponent();
            this.PrinterName = AppSetting.PrinterBarcodeName;
        }
    }
}
