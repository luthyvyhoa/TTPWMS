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
    
    public partial class BusinessTripPrices
    {
        public int BusinessTripPriceID { get; set; }
        public System.DateTime BusinessTripPriceDate { get; set; }
        public float PetrolPrice { get; set; }
        public Nullable<float> LunchPrice { get; set; }
        public float ParkPrice { get; set; }
        public string RequiredDescription { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedTime { get; set; }
        public Nullable<bool> Locked { get; set; }
        public Nullable<float> DieselPrice { get; set; }
    }
}
