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
    
    public partial class Replenishments
    {
        public int ReplenishmentID { get; set; }
        public System.DateTime ReplenishmentDate { get; set; }
        public int DispatchingOrderID { get; set; }
        public int PalletID { get; set; }
        public int SourceLocation { get; set; }
        public int DestinationLocation { get; set; }
    }
}
