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
    
    public partial class OperatingCostElectricty
    {
        public OperatingCostElectricty()
        {
            this.OperatingCostElectricityDetails = new HashSet<OperatingCostElectricityDetails>();
        }
    
        public int OperatingCostElectricityID { get; set; }
        public string RoomID { get; set; }
        public decimal ElectricityAmount { get; set; }
        public long ElectricityKwh { get; set; }
        public int OperatingCostMonthlyID { get; set; }
    
        public virtual ICollection<OperatingCostElectricityDetails> OperatingCostElectricityDetails { get; set; }
        public virtual OperatingCostMonths OperatingCostMonths { get; set; }
    }
}
