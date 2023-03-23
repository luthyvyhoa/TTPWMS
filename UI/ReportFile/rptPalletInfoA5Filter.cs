using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;

namespace UI.ReportFile
{
    public partial class rptPalletInfoA5Filter : DevExpress.XtraReports.UI.XtraReport
    {
        public rptPalletInfoA5Filter()
        {
            InitializeComponent();
            this.xrLabel31.Text = AppSetting.CurrentUser.LoginName;
        }

        private void rptPalletInfoA5Filter_DataSourceDemanded(object sender, EventArgs e)
        {
            this.GroupHeader1.GroupFields.Add(new GroupField("LocationNumber"));
            CreateCalculatedFields();
            this.xrCheckBox1.DataBindings.Add("Checked", this.DataSource, "OnHold");
        }

        private void CreateCalculatedFields()
        {
            CalculatedField countPallets = new CalculatedField(this.DataSource, this.DataMember);
            countPallets.Expression = "Count()";
            countPallets.Name = "countPallets";
            countPallets.DisplayName = "countPallets";

            this.CalculatedFields.Add(countPallets);

            CalculatedField sumQty = new CalculatedField(this.DataSource, this.DataMember);
            sumQty.Expression = "Sum([quantity])";
            sumQty.Name = "sumQty";
            sumQty.DisplayName = "sumQty";

            this.CalculatedFields.Add(sumQty);
        }
    }
}
