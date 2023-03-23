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
    
    public partial class BillingSummary
    {
        public BillingSummary()
        {
            this.BillingSummaryDetails = new HashSet<BillingSummaryDetails>();
        }
    
        public int BillingSummaryID { get; set; }
        public System.DateTime FromDate { get; set; }
        public System.DateTime ToDate { get; set; }
        public string Period { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedTime { get; set; }
        public bool Confirmed { get; set; }
        public Nullable<int> TotalCustomerCount { get; set; }
        public Nullable<int> NonBilledCustomerCount { get; set; }
        public string ConfirmedBy { get; set; }
        public Nullable<System.DateTime> ConfirmTime { get; set; }
    
        public virtual ICollection<BillingSummaryDetails> BillingSummaryDetails { get; set; }
    }
}