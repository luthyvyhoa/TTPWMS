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
    
    public partial class STGate_VehicleInOutRemainByGate_Result
    {
        public int VehicleInOutID { get; set; }
        public string VehicleNumber { get; set; }
        public string CustomerName { get; set; }
        public string ProductQty { get; set; }
        public Nullable<System.DateTime> TimeIn { get; set; }
        public Nullable<System.DateTime> TimeOut { get; set; }
        public Nullable<byte> Gate { get; set; }
        public string UserOut { get; set; }
        public Nullable<bool> UserCheckOut { get; set; }
        public string VehicleType { get; set; }
        public string OrderNumber { get; set; }
        public string R { get; set; }
        public string DockNumber { get; set; }
        public Nullable<byte> Electricity { get; set; }
    }
}
