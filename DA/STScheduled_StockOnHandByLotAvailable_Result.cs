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
    
    public partial class STScheduled_StockOnHandByLotAvailable_Result
    {
        public string CustomerNumber { get; set; }
        public int ProductID { get; set; }
        public string ProductNumber { get; set; }
        public string ProductName { get; set; }
        public string ReceivingOrderNumber { get; set; }
        public Nullable<System.DateTime> ReceivingOrderDate { get; set; }
        public string CustomerRef { get; set; }
        public byte Status { get; set; }
        public Nullable<int> AvailableQty { get; set; }
        public Nullable<int> HoldQty { get; set; }
        public Nullable<int> Quarantined { get; set; }
        public string Remark { get; set; }
        public string Vehicle { get; set; }
        public Nullable<System.DateTime> ProductionDate { get; set; }
        public Nullable<System.DateTime> UseByDate { get; set; }
        public byte PalletStatus { get; set; }
        public string PalletStatusDescriptionVietnam { get; set; }
        public decimal WeightPerPackage { get; set; }
    }
}