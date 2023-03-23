using UI.Helper;

namespace UI.ReportFile
{
    public partial class rptPalletInfoHistory : DevExpress.XtraReports.UI.XtraReport
    {
        public rptPalletInfoHistory()
        {
            InitializeComponent();
            this.xrLabel33.Text = "by [" + AppSetting.CurrentUser.LoginName + "]";
        }

    }
}
