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
    
    public partial class TripDetails
    {
        public int TripDetailID { get; set; }
        public int TripID { get; set; }
        public bool CheckDelete { get; set; }
        public Nullable<int> TotalPackages { get; set; }
        public Nullable<decimal> TotalWeight { get; set; }
        public byte[] ts { get; set; }
        public string OrderNumber { get; set; }
        public string TripDetailRemark { get; set; }
        public string CustomerNumber { get; set; }
        public Nullable<int> TotalPallets { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedTime { get; set; }
        public Nullable<int> CustomerClientID { get; set; }
        public Nullable<byte> TripStatus { get; set; }
        public Nullable<System.DateTime> ExpectedDeliveryTime { get; set; }
        public Nullable<decimal> CashCollectionAmount { get; set; }
        public Nullable<bool> IsRejected { get; set; }
        public string RejectedOrderNumber { get; set; }
        public string RejectedRemark { get; set; }
        public string CustomerOrderNumber { get; set; }
        public string CustomerComments { get; set; }
    }
}
