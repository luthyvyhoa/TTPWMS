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
    
    public partial class QualityCheckingDetails
    {
        public int QualityCheckingDetailID { get; set; }
        public int QualityCheckingID { get; set; }
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        public int QuantityOfPackages { get; set; }
        public int TotalUnits { get; set; }
        public float TotalWeight { get; set; }
        public string CheckingDetailRemark { get; set; }
        public bool CheckingPassed { get; set; }
        public string ReferenceNumber { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedTime { get; set; }
        public Nullable<int> CheckingQuantity { get; set; }
        public string CheckedBy { get; set; }
        public string CustomerRef { get; set; }
    
        public virtual QualityCheckings QualityCheckings { get; set; }
    }
}
