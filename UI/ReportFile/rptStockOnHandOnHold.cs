using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;
using System.Linq;
using DA;

namespace UI.ReportFile
{
    public partial class rptStockOnHandOnHold : DevExpress.XtraReports.UI.XtraReport
    {
        private DataProcess<Employees> employeeDA = new DataProcess<Employees>();
        public rptStockOnHandOnHold()
        {
            InitializeComponent();
            string employeeName = AppSetting.CurrentEmployee.FullName;
            this.xrLabel30.Text = employeeName;
            this.xrLabel33.Text = "by " + AppSetting.CurrentUser.LoginName;
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;
        }

        private void rptStockOnHandOnHold_DataSourceDemanded(object sender, EventArgs e)
        {
            this.sumAvail.DataSource = this.DataSource;
            this.sumAvail.DataMember = this.DataMember;
            this.sumAvailWeight.DataSource = this.DataSource;
            this.sumAvailWeight.DataMember = this.DataMember;
            this.sumHold.DataSource = this.DataSource;
            this.sumHold.DataMember = this.DataMember;
            this.sumQty.DataSource = this.DataSource;
            this.sumQty.DataMember = this.DataMember;
            this.sumQuarant.DataSource = this.DataSource;
            this.sumQuarant.DataMember = this.DataMember;
            this.sumWeight.DataSource = this.DataSource;
            this.sumWeight.DataMember = this.DataMember;
        }
    }
}
