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
    
    public partial class News
    {
        public int CompanyNewID { get; set; }
        public Nullable<System.DateTime> NewDate { get; set; }
        public string NewDescriptions { get; set; }
        public string NewHeadline { get; set; }
        public string ImageName { get; set; }
        public Nullable<byte> NewType { get; set; }
        public string NavigateURL { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedTime { get; set; }
        public bool NewsConfirmed { get; set; }
    }
}
