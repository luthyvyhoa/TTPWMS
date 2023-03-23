using UI.Helper;
using System.Linq;

namespace UI.ReportFile
{
    public partial class rptQualityCheckingNote : DevExpress.XtraReports.UI.XtraReport
    {
        public rptQualityCheckingNote()
        {
            InitializeComponent();
            string employeeName = AppSetting.EmployessList.FirstOrDefault(e => e.EmployeeID == AppSetting.CurrentUser.EmployeeID).FullName;
            this.xrLabel28.Text = "Prepared by :  " + employeeName;
            this.xrLabel51.Text = AppSetting.CurrentUser.LoginName;
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;
        }

        private void rptQualityCheckingNote_DataSourceDemanded(object sender, System.EventArgs e)
        {
            this.GroupHeader1.GroupFields.Add(new DevExpress.XtraReports.UI.GroupField("CustomerNumber"));
            this.xrLabel26.DataBindings.Add("Text", this.DataSource, "QuantityOfPackages");
            this.xrLabel25.DataBindings.Add("Text", this.DataSource, "TotalUnits");
            this.xrLabel27.DataBindings.Add("Text", this.DataSource, "TotalWeight");
        }
    }
}
