using System;
using System.Linq;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;

namespace UI.ReportFile
{
    public partial class rptTrainingRequirementFutureReport : DevExpress.XtraReports.UI.XtraReport
    {
        public rptTrainingRequirementFutureReport()
        {
            InitializeComponent();
            string employeeName = AppSetting.EmployessList.FirstOrDefault(e => e.EmployeeID == AppSetting.CurrentUser.EmployeeID).FullName;
            this.xrLabel30.Text = employeeName;
            this.xrLabel51.Text = AppSetting.CurrentUser.LoginName;
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;
        }

        private void rptTrainingRequirementFutureReport_DataSourceDemanded(object sender, EventArgs e)
        {
            this.GroupHeader1.GroupFields.Add(new GroupField("TrainingDefinitionID"));
            //this.xrLabel22.DataBindings.Add("Text", this.DataSource, "TrainingExpiryDate", "dd/MM/yyyy");
        }

        private void DetailBeforePrint(object sender, CancelEventArgs e)
        {
            XRLabel label = sender as XRLabel;
            DateTime expiryDate = this.GetCurrentColumnValue("TrainingExpiryDate") == null || this.GetCurrentColumnValue("TrainingExpiryDate").Equals("") ? DateTime.Now : Convert.ToDateTime(this.GetCurrentColumnValue("TrainingExpiryDate"));

            if (expiryDate <= DateTime.Now)
            {
                label.BackColor = Color.Violet;
            }
            else
            {
                if (expiryDate <= DateTime.Now.AddDays(7))
                {
                    label.BackColor = Color.Yellow;
                }
                else
                {
                    if (expiryDate <= DateTime.Now.AddDays(31))
                    {
                        label.BackColor = Color.PaleGreen;
                    }
                    else
                    {
                        label.BackColor = Color.Transparent;
                    }
                }
            }
        }

        private void rptTrainingRequirementFutureReport_BeforePrint(object sender, CancelEventArgs e)
        {
            this.Detail.SortFields.Add(new GroupField("TrainingExpiryDate", XRColumnSortOrder.Ascending));
        }
    }
}
