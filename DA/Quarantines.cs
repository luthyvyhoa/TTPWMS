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
    
    public partial class Quarantines
    {
        public int QuarantineID { get; set; }
        public System.DateTime QuarantineDate { get; set; }
        public string UserName { get; set; }
        public int CustomerID { get; set; }
        public string QuarantineRemark { get; set; }
        public bool QuarantineConfirm { get; set; }
        public bool QuarantineType { get; set; }
        public Nullable<System.DateTime> CreatedTime { get; set; }
        public Nullable<byte> PalletStatus { get; set; }
    }
}
