using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace UI.ReportFile
{
    public partial class subrptQuotationScoreOfWork : DevExpress.XtraReports.UI.XtraReport
    {
        public subrptQuotationScoreOfWork()
        {
            InitializeComponent();
            this.xrPictureBox1.Image = UI.Properties.Resources.ImageCompany;
        }

        private void subrptQuotationScoreOfWork_DataSourceDemanded(object sender, EventArgs e)
        {
            // Create a group field and assign it to the group header band.
            GroupField groupField = new GroupField("LineNumber");
            GroupHeader1.GroupFields.Add(groupField);
        }
    }
}
