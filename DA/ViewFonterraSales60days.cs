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
    using System.Collections.Generic;
    
    public partial class ViewFonterraSales60days
    {
        public int CustomerSalesInvoiceID { get; set; }
        public System.DateTime CustomerSalesInvoiceDate { get; set; }
        public string CustomerClientCode { get; set; }
        public string CustomerClientName { get; set; }
        public Nullable<int> CustomerClientMainID { get; set; }
        public Nullable<int> CustomerClientCodeFBV { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public Nullable<float> OrderQuantity { get; set; }
        public Nullable<int> OrderUnitQuanity { get; set; }
        public Nullable<int> DispatchedQuantity { get; set; }
        public float InvoiceQuantity { get; set; }
        public Nullable<System.DateTime> ConfirmedTime { get; set; }
        public Nullable<bool> CustomerSalesInvoiceConfirmed { get; set; }
        public string CustomerClientMain { get; set; }
        public int CustomerSalesInvoiceDetailID { get; set; }
        public int CustomerClientID { get; set; }
        public string MainClientName { get; set; }
    }
}
