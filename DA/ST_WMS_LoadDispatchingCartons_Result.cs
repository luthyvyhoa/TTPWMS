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
    
    public partial class ST_WMS_LoadDispatchingCartons_Result
    {
        public int DispatchingCartonID { get; set; }
        public int DispatchingOrderDetailID { get; set; }
        public Nullable<float> CartonWeight { get; set; }
        public string DispatchingRemark { get; set; }
        public string Label { get; set; }
        public int DispatchingProductID { get; set; }
        public string ReceivingOrderNumber { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<int> CartonUnits { get; set; }
        public Nullable<float> PalletWeight { get; set; }
        public Nullable<int> PalletCartonID { get; set; }
        public Nullable<bool> CheckDelete { get; set; }
    }
}
