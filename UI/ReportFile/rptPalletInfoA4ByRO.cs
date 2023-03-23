using DevExpress.XtraReports.UI;
using UI.Helper;

namespace UI.ReportFile
{
    public partial class rptPalletInfoA4ByRO : DevExpress.XtraReports.UI.XtraReport
    {
        public rptPalletInfoA4ByRO()
        {
            InitializeComponent();
            this.xrLabel33.Text = "by [" + AppSetting.CurrentUser.LoginName + "]";
        }

        private void rptPalletInfoA4ByRO_DataSourceDemanded(object sender, System.EventArgs e)
        {
            this.GroupHeader1.GroupFields.Add(new GroupField("ReceivingOrderID"));
        }

    }
}
