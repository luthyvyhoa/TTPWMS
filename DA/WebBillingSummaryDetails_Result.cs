//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DA
{
    using System;
    
    public partial class WebBillingSummaryDetails_Result
    {
        public int BillingID { get; set; }
        public string ServiceNumber { get; set; }
        public string ServiceName { get; set; }
        public string Measure { get; set; }
        public Nullable<decimal> ServiceQuantity { get; set; }
        public Nullable<bool> ManualUpdate { get; set; }
        public int CustomerID { get; set; }
        public string CustomerNumber { get; set; }
        public string CustomerName { get; set; }
        public System.DateTime BillingFromDate { get; set; }
        public System.DateTime BillingToDate { get; set; }
    }
}
