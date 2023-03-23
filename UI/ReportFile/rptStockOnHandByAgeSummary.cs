using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;

namespace UI.ReportFile
{
    public partial class rptStockOnHandByAgeSummary : DevExpress.XtraReports.UI.XtraReport
    {
        public rptStockOnHandByAgeSummary()
        {
            InitializeComponent();
            this.xrLabel33.Text = AppSetting.CurrentUser.LoginName;
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;
        }

        private void rptStockOnHandByAgeSummary_DataSourceDemanded(object sender, EventArgs e)
        {
            CreateCalculatedFields();
            this.xrChart1.Series[0].SetDataMembers("ReceivedMonth", "TotalWeight");
            this.xrChart1.Series[0].Label.TextPattern = "{A:MMMM yyyy}\n{VP:0%}";
        }

        private void CreateCalculatedFields()
        {
            CalculatedField sumWeight = new CalculatedField();
            sumWeight.DataSource = this.DataSource;
            sumWeight.DataMember = this.DataMember;
            sumWeight.DisplayName = "sumWeight";
            sumWeight.Name = "sumWeight";
            sumWeight.Expression = "Sum([TotalWeight])";

            this.CalculatedFields.Add(sumWeight);
        }
    }
}
