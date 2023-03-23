using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;

namespace UI.ReportFile
{
    public partial class rptProblem_InternalAuditFDTD : DevExpress.XtraReports.UI.XtraReport
    {
        public rptProblem_InternalAuditFDTD(DateTime from, DateTime to)
        {
            InitializeComponent();
            xrLabel72.Text = AppSetting.CurrentUser.LoginName;
            this.xrLabel7.Text = from.ToString("dd/MM/yyyy");
            this.xrLabel8.Text = to.ToString("dd/MM/yyyy");
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;
        }

        private void rptProblem_InternalAuditFDTD_DataSourceDemanded(object sender, EventArgs e)
        {
            this.GroupHeader2.GroupFields.Add(new GroupField("DepartmentName"));
            this.GroupHeader1.GroupFields.Add(new GroupField("ProblemCategoryDescription"));
            xrCheckBox1.DataBindings.Add("Checked", this.DataSource, "Complained");
        }
    }
}
