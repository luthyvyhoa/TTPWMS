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
    
    public partial class OperatingCostElectricityDetails
    {
        public int OperatingCostElectrictyDetailID { get; set; }
        public int CustomerID { get; set; }
        public decimal ElectricityAmount { get; set; }
        public decimal DriverRate { get; set; }
        public Nullable<decimal> ElectricityAmountAdjusted { get; set; }
        public int OperatingCostElectricityID { get; set; }
    
        public virtual OperatingCostElectricty OperatingCostElectricty { get; set; }
    }
}
