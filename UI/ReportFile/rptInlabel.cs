using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;

namespace UI.ReportFile
{
    public partial class rptInlabel : DevExpress.XtraReports.UI.XtraReport
    {
        public rptInlabel()
        {
            InitializeComponent();
            this.PrinterName = AppSetting.PrinterBarcodeName;
        }
    }
}
