using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace SCSVN.Report
{
    public partial class SDStockMovementDetailReport : DevExpress.XtraReports.UI.XtraReport
    {
        public SDStockMovementDetailReport(int varCustomerID)
        {
            InitializeComponent();
            //this.parameter1.Value =  DateTime.Today;
            //this.parameter2.Value = DateTime.Today;
            this.parameter1.Value = DateTime.Today.AddDays(-1);
            this.parameter2.Value = DateTime.Today.AddDays(-1);
            this.parameter3.Value = varCustomerID;
            this.parameter4.Value = 0;
            this.xrPictureBox1.Image = UI.Properties.Resources.ImageCompany;
        }

    }
}
