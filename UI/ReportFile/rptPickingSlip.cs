using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace UI.ReportFile
{
    public partial class rptPickingSlip : DevExpress.XtraReports.UI.XtraReport
    {
        public rptPickingSlip()
        {
            InitializeComponent();
        }

        private void rptPickingSlip_DataSourceDemanded(object sender, EventArgs e)
        {
            this.GroupHeader3.GroupFields.Add(new GroupField("RoomID"));
            this.GroupHeader2.GroupFields.Add(new GroupField("Label"));
            this.GroupHeader3.GroupFields.Add(new GroupField("ProductNumber"));
        }
    }
}
