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
    
    public partial class STDispatchingProductSelectLocation_Order_Result
    {
        public int PalletID { get; set; }
        public string Location { get; set; }
        public short Qty { get; set; }
        public string Ref { get; set; }
        public string Remark { get; set; }
        public string RO { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public int ReceivingOrderID { get; set; }
        public Nullable<System.DateTime> ProductionDate { get; set; }
        public Nullable<System.DateTime> UseByDate { get; set; }
        public string RODetailRemark { get; set; }
        public string Packages { get; set; }
        public Nullable<short> Pcs { get; set; }
    }
}
