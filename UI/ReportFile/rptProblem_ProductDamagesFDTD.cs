using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;

namespace UI.ReportFile
{
    public partial class rptProblem_ProductDamagesFDTD : DevExpress.XtraReports.UI.XtraReport
    {
        public rptProblem_ProductDamagesFDTD(DateTime from, DateTime to)
        {
            InitializeComponent();
            this.xrLabel4.Text = from.ToString("dd/MM/yyyy");
            this.xrLabel8.Text = to.ToString("dd/MM/yyyy");
            this.xrLabel51.Text = AppSetting.CurrentUser.LoginName;
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;
        }

        private void rptProblem_ProductDamagesFDTD_DataSourceDemanded(object sender, EventArgs e)
        {
            CalculatedField sumVL = new CalculatedField();
            sumVL.Name = "sumVL";
            sumVL.DisplayName = "sumVL";
            sumVL.DataSource = this.DataSource;
            sumVL.DataMember = this.DataMember;
            sumVL.Expression = "Sum([EstimatedValueLost])";

            this.CalculatedFields.Add(sumVL);
        }
    }
}
