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
    
    public partial class ReceivingCartons
    {
        public int ReceivingCartonID { get; set; }
        public int ReceivingOrderDetailID { get; set; }
        public string CartonNumber { get; set; }
        public string CartonDescription { get; set; }
        public bool Dispatched { get; set; }
        public Nullable<int> DispatchingProductID { get; set; }
        public Nullable<int> DataRangeFrom { get; set; }
        public Nullable<int> DatarangeTo { get; set; }
        public Nullable<System.DateTime> ProductionDate { get; set; }
        public byte[] ts { get; set; }
        public Nullable<System.DateTime> CreatedTime { get; set; }
        public string CreatedBy { get; set; }
        public string CartonManufacturingBarcode { get; set; }
    }
}
