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
    
    public partial class TransportTripOutsourceDetail
    {
        public int TransportTripOutsourcedServiceID { get; set; }
        public int TransportTripID { get; set; }
        public int ServiceID { get; set; }
        public Nullable<decimal> TransportTripOutsourcedServiceQuantity { get; set; }
        public string TransportTripOutsourcedServiceRemark { get; set; }
        public System.DateTime CreatedTime { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<int> OtherServiceDetailID { get; set; }
    
        public virtual TransportTrip TransportTrip { get; set; }
    }
}
