using System;
using System.Linq;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;
using DA;

namespace UI.ReportFile
{
    public partial class rptMonthlyNoodleRecordingByPlaces : DevExpress.XtraReports.UI.XtraReport
    {
        public rptMonthlyNoodleRecordingByPlaces()
        {
            InitializeComponent();
            string employeeName = AppSetting.CurrentEmployee.FullName;
            this.xrLabel150.Text = employeeName;
            this.xrLabel3.Text = AppSetting.CurrentUser.LoginName;
            this.xrPictureBox1.Image = UI.Properties.Resources.ImageCompany;
        }

        private void rptMonthlyNoodleRecordingByPlaces_DataSourceDemanded(object sender, EventArgs e)
        {
            this.GroupHeader1.GroupFields.Add(new GroupField("PlaceDescription"));
            this.xrLabel127.DataBindings.Add("Text", this.DataSource, "Total");
        }
    }
}
