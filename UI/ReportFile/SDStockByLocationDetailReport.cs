﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace SCSVN.Report
{
    public partial class SDStockByLocationDetailReport : DevExpress.XtraReports.UI.XtraReport
    {
        public SDStockByLocationDetailReport(int varCustomerID)
        {
            InitializeComponent();
            this.parameter1.Value = varCustomerID;
            this.xrPictureBox1.Image = UI.Properties.Resources.ImageCompany;
        }

    }
}
