using UI.Helper;

namespace UI.ReportFile
{
    public partial class rptPalletInfoA4 : DevExpress.XtraReports.UI.XtraReport
    {
        public rptPalletInfoA4()
        {
            InitializeComponent();
            this.xrLabel33.Text = "by [" + AppSetting.CurrentUser.LoginName + "]";
        }

    }
}
