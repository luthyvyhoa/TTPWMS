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
    
    public partial class Releases
    {
        public Releases()
        {
            this.ReleaseDetails = new HashSet<ReleaseDetails>();
        }
    
        public int ReleaseID { get; set; }
        public System.DateTime ReleaseDate { get; set; }
        public string UserName { get; set; }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string ReleaseRemark { get; set; }
        public bool ReleaseConfirm { get; set; }
        public byte ReleaseType { get; set; }
        public Nullable<System.DateTime> CreatedTime { get; set; }
        public string ReleaseConfirmedBy { get; set; }
    
        public virtual ICollection<ReleaseDetails> ReleaseDetails { get; set; }
    }
}
