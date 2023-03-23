using DA;
using DevExpress.XtraReports.UI;
using System;
using System.Linq;
using UI.Helper;

namespace UI.ReportFile
{
    public partial class rptDeliveryNoteGoodFood : DevExpress.XtraReports.UI.XtraReport
    {
        public rptDeliveryNoteGoodFood()
        {
            InitializeComponent();
            string employeeName = AppSetting.CurrentEmployee.VietnamName;
            this.xrLabel72.Text = AppSetting.CurrentUser.LoginName;
            this.xrLabel58.Text = employeeName;
            //this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;
        }

        private void rptDeliveryNote2_DataSourceDemanded(object sender, EventArgs e)
        {
        }

    }
}
