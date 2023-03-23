using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;

namespace UI.ReportFile
{
    public partial class rptDockDoorLabelDecal : DevExpress.XtraReports.UI.XtraReport
    {
        public rptDockDoorLabelDecal()
        {
            InitializeComponent();
            this.PrinterName = AppSetting.PrinterBarcodeName;
        }
    }
}
