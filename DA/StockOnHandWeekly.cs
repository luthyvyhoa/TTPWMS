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
    
    public partial class StockOnHandWeekly
    {
        public int WeekID { get; set; }
        public Nullable<System.DateTime> FromDate { get; set; }
        public System.DateTime ToDate { get; set; }
        public string WeekRemarks { get; set; }
        public bool WeekConfirm { get; set; }
    }
}