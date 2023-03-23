using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;

namespace UI.ReportFile
{
    public partial class rptStockOnHandDailySummary : DevExpress.XtraReports.UI.XtraReport
    {
        private double _sumWeight;
        private int _sumPallets;

        public rptStockOnHandDailySummary(DateTime from, DateTime to)
        {
            InitializeComponent();
            this.xrLabel4.Text = from.ToString("dd/MM/yyyy");
            this.xrLabel8.Text = to.ToString("dd/MM/yyyy");
            this.xrLabel51.Text = AppSetting.CurrentUser.LoginName;
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;
        }

        private void rptStockOnHandDailySummary_DataSourceDemanded(object sender, EventArgs e)
        {
            this.GroupHeader1.GroupFields.Add(new GroupField("DateID"));
            InitCalculatedFields();
            this.xrLabel13.DataBindings.Add("Text", this.DataSource, "Cartons");
            this.xrLabel14.DataBindings.Add("Text", this.DataSource, "Pallets");
            this.xrLabel15.DataBindings.Add("Text", this.DataSource, "Weight");
            this.xrLabel16.DataBindings.Add("Text", this.DataSource, "divWP");
            this.xrLabel17.DataBindings.Add("Text", this.DataSource, "ProductLines");
            this.xrLabel18.DataBindings.Add("Text", this.DataSource, "ProductLines");
            this.xrLabel22.DataBindings.Add("Text", this.DataSource, "Cartons");
        }

        private void InitCalculatedFields()
        {
            CalculatedField sumW = new CalculatedField();
            sumW.DataSource = this.DataSource;
            sumW.DataMember = this.DataMember;
            sumW.Name = "sumW";
            sumW.DisplayName = "sumW";
            sumW.Expression = "Sum([Weight])";
            sumW.GetValue += (s, e) =>
            {
                this._sumWeight = Convert.ToDouble(e.Value);
            };

            this.CalculatedFields.Add(sumW);

            CalculatedField sumP = new CalculatedField();
            sumP.DataSource = this.DataSource;
            sumP.DataMember = this.DataMember;
            sumP.Name = "sumP";
            sumP.DisplayName = "sumP";
            sumP.Expression = "Sum([Pallets])";
            sumP.GetValue += (s, e) =>
            {
                this._sumPallets = Convert.ToInt32(e.Value);
            };

            this.CalculatedFields.Add(sumP);

            CalculatedField divWP = new CalculatedField();
            divWP.DataSource = this.DataSource;
            divWP.DataMember = this.DataMember;
            divWP.Name = "divWP";
            divWP.DisplayName = "divWP";
            divWP.Expression = "[Weight] / [Pallets]";

            this.CalculatedFields.Add(divWP);

            CalculatedField sumdivWP = new CalculatedField();
            sumdivWP.DataSource = this.DataSource;
            sumdivWP.DataMember = this.DataMember;
            sumdivWP.Name = "sumdivWP";
            sumdivWP.DisplayName = "sumdivWP";
            sumdivWP.Expression = "Sum([divWP])";

            this.CalculatedFields.Add(sumdivWP);
        }

        private void xrLabel19_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            //double divWP = this._sumWeight / this._sumPallets;
            //this.xrLabel19.Text = divWP.ToString("n0");
        }

        private void xrLabel19_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            double weight = Convert.ToDouble(this.xrLabel20.Text);
            double pallets = Convert.ToDouble(this.xrLabel21.Text);
            double divWP = weight / pallets;
            this.xrLabel19.Text = divWP.ToString("n0");
        }
    }
}
