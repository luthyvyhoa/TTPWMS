using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Management
{
    public class ManualInvoices
    {
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string TaxCode { get; set; }
        public string InvCurrency { get; set; }
        public string PaymentTerms { get; set; }
        public string InvPeriod { get; set; }
        public string ServiceCode { get; set; }
        public string ServiceName { get; set; }
        public string UOM { get; set; }
        public string ServiceQuantity { get; set; }
        public string ServicePrice { get; set; }
        public string VATPercentage { get; set; }
        public string PLUCode { get; set; }
    }
}
