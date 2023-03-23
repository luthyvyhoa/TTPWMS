using System;
using System.Linq;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;
using System.Data.Entity.Core.Objects;

namespace UI.ReportFile
{
    public partial class rptDeliveryNote : DevExpress.XtraReports.UI.XtraReport
    {
        public rptDeliveryNote()
        {
            InitializeComponent();
            string employeeName = AppSetting.EmployessList.FirstOrDefault(e => e.EmployeeID == AppSetting.CurrentUser.EmployeeID).VietnamName;
            this.xrLabel72.Text = AppSetting.CurrentUser.LoginName;
            this.xrLabel58.Text = employeeName;
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;
        }

        private void rptDeliveryNote_DataSourceDemanded(object sender, EventArgs e)
        {
            CreateCalculatedFields();
        }

        private void CreateCalculatedFields()
        {
            CalculatedField sumQty = new CalculatedField(this.DataSource, this.DataMember);
            sumQty.Name = "sumQty";
            sumQty.DisplayName = "sumQty";
            sumQty.Expression = "Sum([OrderUnitQuantity])";

            CalculatedField sumDiscount = new CalculatedField(this.DataSource, this.DataMember);
            sumDiscount.Name = "sumDiscount";
            sumDiscount.DisplayName = "sumDiscount";
            sumDiscount.Expression = "Sum([TotalPayment]*[DiscountAmount])+[DiscountAdditional]";

            CalculatedField sumVAT = new CalculatedField(this.DataSource, this.DataMember);
            sumVAT.Name = "sumVAT";
            sumVAT.DisplayName = "sumVAT";
            sumVAT.Expression = "(Sum([TotalAmount])-[DiscountAdditional])*0.1";

            CalculatedField sumAmount = new CalculatedField(this.DataSource, this.DataMember);
            sumAmount.Name = "sumAmount";
            sumAmount.DisplayName = "sumAmount";
            sumAmount.Expression = "(Sum([TotalAmount])-[DiscountAdditional])*1.1";

            CalculatedField sumTotal = new CalculatedField(this.DataSource, this.DataMember);
            sumTotal.Name = "sumTotal";
            sumTotal.DisplayName = "sumTotal";
            sumTotal.Expression = "Sum([TotalAmount])-[DiscountAdditional]";

            CalculatedField sumWeight = new CalculatedField(this.DataSource, this.DataMember);
            sumWeight.Name = "sumWeight";
            sumWeight.DisplayName = "sumWeight";
            sumWeight.Expression = "Sum([TotalNetWeight])";

            this.CalculatedFields.Add(sumAmount);
            this.CalculatedFields.Add(sumDiscount);
            this.CalculatedFields.Add(sumQty);
            this.CalculatedFields.Add(sumTotal);
            this.CalculatedFields.Add(sumVAT);
            this.CalculatedFields.Add(sumWeight);
        }

        private void xrLabel50_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            string number = this.xrLabel48.Text.Replace(",", "");
            int varNumber = Convert.ToInt32(number);
            ObjectParameter text = new ObjectParameter("varText", typeof(string));

            DA.Warehouse.TripDA tripDA = new DA.Warehouse.TripDA();
            tripDA.STNumberToText(varNumber, text);
            this.xrLabel50.Text = Convert.ToString(text.Value);
        }
    }
}
