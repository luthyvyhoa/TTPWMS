using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DA;

namespace UI.ReportFile
{
    public partial class rptWavePickingSummary : DevExpress.XtraReports.UI.XtraReport
    {
        public rptWavePickingSummary()
        {
            InitializeComponent();
            this.pvgTripDispatchingPlanSummary.DataSource = FileProcess.LoadTable("STPickingSlipManyOrderReport");
        }

    }
}
