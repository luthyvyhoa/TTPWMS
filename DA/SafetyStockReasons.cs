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
    
    public partial class SafetyStockReasons
    {
        public int SafetyStockReasonID { get; set; }
        public Nullable<int> ProductID6 { get; set; }
        public string Reason { get; set; }
        public Nullable<System.DateTime> ReasonTime { get; set; }
        public string Owner { get; set; }
        public Nullable<int> ProductID6_Stock { get; set; }
        public Nullable<int> ProductIDPack_Stock { get; set; }
        public Nullable<int> ProductID2_Stock { get; set; }
        public Nullable<bool> IsCurrent { get; set; }
    }
}
