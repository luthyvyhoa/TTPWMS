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
    
    public partial class CustomerProductGroups
    {
        public CustomerProductGroups()
        {
            this.ReleaseDetails = new HashSet<ReleaseDetails>();
        }
    
        public int ProductGroupID { get; set; }
        public string ProductGroupDescription { get; set; }
        public int CustomerID { get; set; }
        public bool ISDefault { get; set; }
    
        public virtual ICollection<ReleaseDetails> ReleaseDetails { get; set; }
    }
}