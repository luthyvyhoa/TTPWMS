using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace UI.ReportFile
{
    public partial class rptStockByLocationGrossWeightReport : DevExpress.XtraReports.UI.XtraReport
    {
        public rptStockByLocationGrossWeightReport()
        {
            InitializeComponent();
        }

        private void rptStockByLocationGrossWeightReport_DataSourceDemanded(object sender, EventArgs e)
        {
            this.GroupHeader1.GroupFields.Add(new GroupField("RoomID"));
            this.xrLabel18.DataBindings.Add("Text", this.DataSource, "ProductNumber");
        }
    }
}
