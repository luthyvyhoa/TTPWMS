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
    
    public partial class OperatingCostMonths
    {
        public OperatingCostMonths()
        {
            this.OperatingCostElectricty = new HashSet<OperatingCostElectricty>();
            this.OperatingCostLabours = new HashSet<OperatingCostLabours>();
            this.OperatingCostMonthlyDetails = new HashSet<OperatingCostMonthlyDetails>();
            this.OperationCostMonthlyParameters = new HashSet<OperationCostMonthlyParameters>();
        }
    
        public int OperatingCostMonthlyID { get; set; }
        public string MonthDescription { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedTime { get; set; }
        public string OperatingCostMonthlyRemark { get; set; }
        public System.DateTime FromDate { get; set; }
        public System.DateTime Todate { get; set; }
        public byte NumberOfSundays { get; set; }
        public byte NumberOfHollidays { get; set; }
        public Nullable<System.DateTime> PersonnelFromDate { get; set; }
        public Nullable<System.DateTime> PersonnelTodate { get; set; }
        public bool ProcessData { get; set; }
        public Nullable<System.DateTime> ProcessDataTime { get; set; }
        public bool Confirmed { get; set; }
        public Nullable<System.DateTime> ConfirmedTime { get; set; }
    
        public virtual ICollection<OperatingCostElectricty> OperatingCostElectricty { get; set; }
        public virtual ICollection<OperatingCostLabours> OperatingCostLabours { get; set; }
        public virtual ICollection<OperatingCostMonthlyDetails> OperatingCostMonthlyDetails { get; set; }
        public virtual ICollection<OperationCostMonthlyParameters> OperationCostMonthlyParameters { get; set; }
    }
}
