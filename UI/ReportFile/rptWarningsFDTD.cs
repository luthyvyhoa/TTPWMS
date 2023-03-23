using UI.Helper;

namespace UI.ReportFile
{
    public partial class rptWarningsFDTD : DevExpress.XtraReports.UI.XtraReport
    {
        public rptWarningsFDTD(string fromDate, string toDate)
        {
            InitializeComponent();
            this.xrLabel28.Text = AppSetting.CurrentUser.LoginName;
            this.lblFromDate.Text = fromDate;
            this.lblToDate.Text = toDate;
            this.xrPictureBox1.Image = UI.Properties.Resources.ImageCompany;
        }

    }
}
