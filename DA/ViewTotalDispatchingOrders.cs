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
    
    public partial class ViewTotalDispatchingOrders
    {
        public int DispatchingOrderID { get; set; }
        public string DispatchingOrderNumber { get; set; }
        public string CustomerNumber { get; set; }
        public int CustomerID { get; set; }
        public System.DateTime DispatchingOrderDate { get; set; }
        public string SpecialRequirement { get; set; }
        public bool Status { get; set; }
        public Nullable<System.DateTime> DispatchingCreatedTime { get; set; }
        public string Owner { get; set; }
        public string Temperature { get; set; }
        public Nullable<int> CustomerClientID { get; set; }
    }
}
