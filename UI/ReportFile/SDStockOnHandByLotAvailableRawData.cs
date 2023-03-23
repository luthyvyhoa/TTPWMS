using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace SCSVN.Report
{
    public partial class SDStockOnHandByLotAvailableRawData : DevExpress.XtraReports.UI.XtraReport
    {
        public SDStockOnHandByLotAvailableRawData(int varCustomerID)
        {
            InitializeComponent();
            this.parameter1.Value = varCustomerID;
        }

    }
}
