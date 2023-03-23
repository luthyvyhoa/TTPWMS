using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace UI.ReportFile
{
    public partial class subrptBillingDetailBreakdown : DevExpress.XtraReports.UI.XtraReport
    {
        public subrptBillingDetailBreakdown()
        {
            InitializeComponent();
        }

        private void subrptBillingDetailBreakdown_DataSourceDemanded(object sender, EventArgs e)
        {
            this.xrLabel32.DataBindings.Add("Text", this.DataSource, "BeginC");
            this.xrLabel33.DataBindings.Add("Text", this.DataSource, "BeginW");
            this.xrLabel34.DataBindings.Add("Text", this.DataSource, "BeginP");
            this.xrLabel35.DataBindings.Add("Text", this.DataSource, "InC");
            this.xrLabel36.DataBindings.Add("Text", this.DataSource, "InW");
            this.xrLabel37.DataBindings.Add("Text", this.DataSource, "InP");
            this.xrLabel38.DataBindings.Add("Text", this.DataSource, "OutC");
            this.xrLabel39.DataBindings.Add("Text", this.DataSource, "OutW");
            this.xrLabel49.DataBindings.Add("Text", this.DataSource, "OutP");
            this.xrLabel46.DataBindings.Add("Text", this.DataSource, "InC");
            this.xrLabel47.DataBindings.Add("Text", this.DataSource, "InW");
            this.xrLabel48.DataBindings.Add("Text", this.DataSource, "InP");
            this.xrLabel53.DataBindings.Add("Text", this.DataSource, "InPNofeeS");
            this.xrLabel55.DataBindings.Add("Text", this.DataSource, "InCNofeeS");
            this.xrLabel57.DataBindings.Add("Text", this.DataSource, "InWNofeeS");
            CreateCalculatedField();
        }

        private void CreateCalculatedField()
        {
            CalculatedField sumC = new CalculatedField();
            sumC.DataSource = this.DataSource;
            sumC.DataMember = this.DataMember;
            sumC.Name = "sumC";
            sumC.DisplayName = "sumC";
            sumC.Expression = "Sum([BeginC] + [InC] - [InCNofeeS])";

            this.CalculatedFields.Add(sumC);

            CalculatedField sumW = new CalculatedField();
            sumW.DataSource = this.DataSource;
            sumW.DataMember = this.DataMember;
            sumW.Name = "sumW";
            sumW.DisplayName = "sumW";
            sumW.Expression = "Sum([BeginW] + [InW] - [InWNofeeS])";

            this.CalculatedFields.Add(sumW);

            CalculatedField sumP = new CalculatedField();
            sumP.DataSource = this.DataSource;
            sumP.DataMember = this.DataMember;
            sumP.Name = "sumP";
            sumP.DisplayName = "sumP";
            sumP.Expression = "Sum([BeginP] + [InP] - [InPNofeeS])";

            this.CalculatedFields.Add(sumP);
        }

        private void Detail_BeforePrint(object sender, CancelEventArgs e)
        {

        }
    }
}
