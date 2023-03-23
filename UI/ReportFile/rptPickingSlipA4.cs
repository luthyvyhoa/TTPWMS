using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace UI.ReportFile
{
    public partial class rptPickingSlipA4 : DevExpress.XtraReports.UI.XtraReport
    {
        public rptPickingSlipA4(bool isRandomWeight = false)
        {
            InitializeComponent();
            if (!isRandomWeight) return;
            this.lblUnit.ExpressionBindings.Clear();
            this.lblQty.ExpressionBindings.Clear();
            var qtyBd = new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[QtyCtns]");
            this.lblQty.ExpressionBindings.Add(qtyBd);
            var qUnitBd = new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[QtyPcs]");
            this.lblUnit.ExpressionBindings.Add(qUnitBd);

        }

        private void xrLabel44_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            try
            {
                e.Result = Convert.ToDouble(xrLabel39.Summary.GetResult()) / Convert.ToDouble(xrLabel4.Text);
                e.Handled = true;
            }
            catch (Exception)
            {
            }
        }
    }
}
