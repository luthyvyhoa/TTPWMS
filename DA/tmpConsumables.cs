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
    
    public partial class tmpConsumables
    {
        public int ConsumableID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public string ProductNumber { get; set; }
        public string ProductName { get; set; }
        public Nullable<decimal> WeightPerpackage { get; set; }
        public Nullable<short> PackagesPerPallet { get; set; }
        public string CustomerNumber { get; set; }
        public string OrderNumber { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public Nullable<short> BeginQty { get; set; }
        public Nullable<short> RemainQty { get; set; }
        public string Remark { get; set; }
    }
}