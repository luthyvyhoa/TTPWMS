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
    
    public partial class ViewTripDispatchingPlan
    {
        public string TripNumber { get; set; }
        public System.DateTime TripDate { get; set; }
        public string ProductNumber { get; set; }
        public string ProductName { get; set; }
        public short TotalPackages { get; set; }
        public Nullable<decimal> TotalWeight { get; set; }
        public Nullable<int> TotalUnits { get; set; }
        public string OrderNumber { get; set; }
        public string CustomerNumber { get; set; }
        public Nullable<int> TripTotalCtns { get; set; }
    }
}
