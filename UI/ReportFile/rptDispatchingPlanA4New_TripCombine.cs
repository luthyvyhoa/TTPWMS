using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DA;

namespace UI.ReportFile
{
    public partial class rptDispatchingPlanA4New_TripCombine : DevExpress.XtraReports.UI.XtraReport
    {
        public rptDispatchingPlanA4New_TripCombine(int TripID)
        {
            InitializeComponent();
            this.pvgTripDispatchingPlanSummary.DataSource = FileProcess.LoadTable("STTripPickingList " + TripID);
        }

    }
}
