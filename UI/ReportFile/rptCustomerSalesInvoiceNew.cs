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
    public partial class rptCustomerSalesInvoiceNew : DevExpress.XtraReports.UI.XtraReport
    {
        private decimal _discount;
        private decimal _subTotal;
        private decimal _tax;
        private decimal _total;
        private byte _step;

        public rptCustomerSalesInvoiceNew()
        {
            InitializeComponent();
            string employeeName = AppSetting.EmployessList.FirstOrDefault(e => e.EmployeeID == AppSetting.CurrentUser.EmployeeID).VietnamName;
            this.xrLabel74.Text = employeeName;
            this.xrLabel75.Text = employeeName;
            this._discount = 0;
            this._subTotal = 0;
            this._tax = 0;
            this._total = 0;
            this._step = 0;
        }

        private void rptCustomerSalesInvoiceNew_DataSourceDemanded(object sender, EventArgs e)
        {
            CreateCalculatedFields();
            this.GroupHeader1.GroupFields.Add(new GroupField("PageDescription"));
            this.xrLabel56.DataBindings.Add("Text", this.DataSource, "InvoicePrice");
            this.xrLabel57.DataBindings.Add("Text", this.DataSource, "InvoicePrice");
            this.xrLabel58.DataBindings.Add("Text", this.DataSource, "InvoicePrice");
            this.xrLabel59.DataBindings.Add("Text", this.DataSource, "InvoicePrice");
        }

        private void CreateCalculatedFields()
        {
            CalculatedField price = new CalculatedField(this.DataSource, this.DataMember);
            price.Name = "price";
            price.DisplayName = "price";
            price.Expression = "[InvoicePrice]*(1-[ProductDiscountPercentage])";

            CalculatedField cost = new CalculatedField(this.DataSource, this.DataMember);
            cost.Name = "cost";
            cost.DisplayName = "cost";
            cost.Expression = "[InvoiceQuantity]*[InvoicePrice]*(1-[ProductDiscountPercentage])";

            CalculatedField symbol = new CalculatedField(this.DataSource, this.DataMember);
            symbol.Name = "symbol";
            symbol.DisplayName = "symbol";
            symbol.Expression = "Substring([InvoiceOfficialSerieName], Len([InvoiceOfficialSerieName]) - 2 , 2)";

            this.CalculatedFields.Add(price);
            this.CalculatedFields.Add(cost);
            this.CalculatedFields.Add(symbol);
        }
        
        //xrLabel56: calculate summary value Discount;
        private void xrLabel56_SummaryReset(object sender, EventArgs e)
        {
                this._discount = 0;
        }

        private void xrLabel56_SummaryRowChanged(object sender, EventArgs e)
        {
            decimal additional = Convert.IsDBNull(this.GetCurrentColumnValue("DiscountAdditional")) ? 0 : Convert.ToDecimal(this.GetCurrentColumnValue("DiscountAdditional"));
            this._discount += Convert.ToDecimal(this.GetCurrentColumnValue("cost")) * Convert.ToDecimal(this.GetCurrentColumnValue("DiscountAmount")) + additional;
        }

        private void xrLabel56_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = this._discount;
            e.Handled = true;
        }

        private void xrLabel56_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
        }

        //xrLabel57: calculate summary value subTotal;
        private void xrLabel57_SummaryReset(object sender, EventArgs e)
        {
            this._subTotal = 0;
        }

        private void xrLabel57_SummaryRowChanged(object sender, EventArgs e)
        {
            decimal additional = Convert.IsDBNull(this.GetCurrentColumnValue("DiscountAdditional")) ? 0 : Convert.ToDecimal(this.GetCurrentColumnValue("DiscountAdditional"));
            this._subTotal += Convert.ToDecimal(this.GetCurrentColumnValue("cost")) * (1 - Convert.ToDecimal(this.GetCurrentColumnValue("DiscountAmount"))) - additional;
        }

        private void xrLabel57_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = this._subTotal;
            e.Handled = true;
        }

        //xrLabel78: calculate summary value tax;
        private void xrLabel58_SummaryReset(object sender, EventArgs e)
        {
                this._tax = 0;
        }

        private void xrLabel58_SummaryRowChanged(object sender, EventArgs e)
        {
            decimal additional = Convert.IsDBNull(this.GetCurrentColumnValue("DiscountAdditional")) ? 0 : Convert.ToDecimal(this.GetCurrentColumnValue("DiscountAdditional"));
            this._tax += (Convert.ToDecimal(this.GetCurrentColumnValue("cost")) * (1 - Convert.ToDecimal(this.GetCurrentColumnValue("DiscountAmount"))) - additional) * 0.1m;
        }

        private void xrLabel58_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = this._tax;
            e.Handled = true;
        }

        private void xrLabel59_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            
        }

        private void xrLabel59_SummaryReset(object sender, EventArgs e)
        {
            this._step++;
            if(this._step <= 3)
            {
                this._total = 0;
            }
        }

        private void xrLabel59_SummaryRowChanged(object sender, EventArgs e)
        {
            decimal additional = Convert.IsDBNull(this.GetCurrentColumnValue("DiscountAdditional")) ? 0 : Convert.ToDecimal(this.GetCurrentColumnValue("DiscountAdditional"));
            this._total += (Convert.ToDecimal(this.GetCurrentColumnValue("cost")) * (1 - Convert.ToDecimal(this.GetCurrentColumnValue("DiscountAmount"))) - additional) + ((Convert.ToDecimal(this.GetCurrentColumnValue("cost")) * (1 - Convert.ToDecimal(this.GetCurrentColumnValue("DiscountAmount"))) - additional) * 0.1m);
        }

        private void xrLabel59_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = this._total;
            e.Handled = true;
        }

        private void xrLabel60_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            int totalAmount = Convert.ToInt32(this.xrLabel59.Summary.GetResult());
            if(totalAmount <= 0)
            {
                return;
            }
            ObjectParameter text = new ObjectParameter("varText", typeof(string));

            DA.Warehouse.TripDA tripDA = new DA.Warehouse.TripDA();
            tripDA.STNumberToText(totalAmount, text);
            this.xrLabel60.Text = Convert.ToString(text.Value);
        }
    }
}
