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
    
    public partial class tmpAccounting_Revenues
    {
        public string InvoiceNo { get; set; }
        public Nullable<System.DateTime> InvoiceDate { get; set; }
        public Nullable<System.DateTime> InvoiceFromDate { get; set; }
        public Nullable<System.DateTime> InvoiceToDate { get; set; }
        public string BillingNo { get; set; }
        public string CustomerID { get; set; }
        public string ServiceNumber { get; set; }
        public string ServiceName { get; set; }
        public string UOM { get; set; }
        public Nullable<double> ServiceQuantity { get; set; }
        public Nullable<double> CuryPrice { get; set; }
        public string curyID { get; set; }
        public string Category { get; set; }
        public int RecordID { get; set; }
        public string BillType { get; set; }
    }
}