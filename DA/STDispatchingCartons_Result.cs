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
    
    public partial class STDispatchingCartons_Result
    {
        public string CartonNumber { get; set; }
        public Nullable<System.DateTime> ProductionDate { get; set; }
        public Nullable<int> DataRangeFrom { get; set; }
        public Nullable<int> DatarangeTo { get; set; }
        public bool Dispatched { get; set; }
        public string CartonDescription { get; set; }
        public int DispatchingProductID { get; set; }
        public int ReceivingOrderDetailID { get; set; }
        public int ReceivingCartonID { get; set; }
    }
}
