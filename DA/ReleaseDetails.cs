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
    
    public partial class ReleaseDetails
    {
        public int ReleaseDetailID { get; set; }
        public int ReleaseID { get; set; }
        public int CustomerProductGroupID { get; set; }
        public string CustomerProductGroupName { get; set; }
        public Nullable<int> ReleaseTotalPackages { get; set; }
        public float ReleaseTotalWeight { get; set; }
        public string ReleaseDetailRemark { get; set; }
        public string ICUser { get; set; }
        public Nullable<System.DateTime> CreatedTime { get; set; }
    
        public virtual CustomerProductGroups CustomerProductGroups { get; set; }
        public virtual Releases Releases { get; set; }
    }
}
