using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;

namespace UI.ReportFile
{
    public partial class rptLocationByRoom : DevExpress.XtraReports.UI.XtraReport
    {
        public rptLocationByRoom()
        {
            InitializeComponent();
            this.xrLabel19.Text = AppSetting.CurrentUser.LoginName;
        }

        private void rptLocationByRoom_DataSourceDemanded(object sender, EventArgs e)
        {
            this.xrCheckBox1.DataBindings.Add("Checked", this.DataSource, "Top");

            CalculatedField countLocation = new CalculatedField();
            countLocation.Name = "countLocation";
            countLocation.DisplayName = "countLocation";
            countLocation.DataSource = this.DataSource;
            countLocation.DataMember = this.DataMember;
            countLocation.Expression = "Count()";
            this.CalculatedFields.Add(countLocation);
        }
    }
}
