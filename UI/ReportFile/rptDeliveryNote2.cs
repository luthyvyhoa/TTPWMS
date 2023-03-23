using DevExpress.XtraReports.UI;
using System;
using System.Linq;
using UI.Helper;

namespace UI.ReportFile
{
    public partial class rptDeliveryNote2 : DevExpress.XtraReports.UI.XtraReport
    {
        public rptDeliveryNote2()
        {
            InitializeComponent();
            string employeeName = AppSetting.EmployessList.FirstOrDefault(e => e.EmployeeID == AppSetting.CurrentUser.EmployeeID).VietnamName;
            this.xrLabel72.Text = AppSetting.CurrentUser.LoginName;
            this.xrLabel58.Text = employeeName;
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;
        }

        private void rptDeliveryNote2_DataSourceDemanded(object sender, EventArgs e)
        {
            CreateCalculatedFields();
        }

        private void CreateCalculatedFields()
        {
            CalculatedField sumQty = new CalculatedField(this.DataSource, this.DataMember);
            sumQty.Name = "sumQty";
            sumQty.DisplayName = "sumQty";
            sumQty.Expression = "Sum([OrderUnitQuantity])";

            CalculatedField sumCarton = new CalculatedField(this.DataSource, this.DataMember);
            sumCarton.Name = "sumCarton";
            sumCarton.DisplayName = "sumCarton";
            sumCarton.Expression = "Sum([PlanQuantity])";

            CalculatedField sumInners = new CalculatedField(this.DataSource, this.DataMember);
            sumInners.Name = "sumInners";
            sumInners.DisplayName = "sumInners";
            sumInners.Expression = "Sum([OddPieceQuantity])";

            CalculatedField sumWeight = new CalculatedField(this.DataSource, this.DataMember);
            sumWeight.Name = "sumWeight";
            sumWeight.DisplayName = "sumWeight";
            sumWeight.Expression = "Sum([TotalNetWeight])";

            this.CalculatedFields.Add(sumQty);
            this.CalculatedFields.Add(sumCarton);
            this.CalculatedFields.Add(sumInners);
            this.CalculatedFields.Add(sumWeight);
        }
    }
}
