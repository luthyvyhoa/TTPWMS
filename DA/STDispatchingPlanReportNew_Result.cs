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
    
    public partial class STDispatchingPlanReportNew_Result
    {
        public string DispatchingOrderID_Barcode { get; set; }
        public int DispatchingOrderID { get; set; }
        public string DispatchingOrderNumber { get; set; }
        public string CustomerNumber { get; set; }
        public System.DateTime DispatchingOrderDate { get; set; }
        public string CustomerName { get; set; }
        public string PP { get; set; }
        public string ProductName { get; set; }
        public int RemainByProductLocation { get; set; }
        public Nullable<int> QtyRemainAtLocation { get; set; }
        public string DispatchingLocationRemark { get; set; }
        public string Label { get; set; }
        public string SpecialRequirement { get; set; }
        public string ProductNumber { get; set; }
        public Nullable<int> ManyProducts { get; set; }
        public int LocationID { get; set; }
        public Nullable<int> Remain { get; set; }
        public decimal WeightPerPackage { get; set; }
        public short QuantityOfPackages { get; set; }
        public Nullable<System.DateTime> ProductionDate { get; set; }
        public Nullable<System.DateTime> UseByDate { get; set; }
        public string RODetails_Remark { get; set; }
        public string Pallets_remark { get; set; }
        public int PalletID { get; set; }
        public Nullable<short> Inners { get; set; }
        public Nullable<int> UnitQuantity { get; set; }
        public Nullable<float> PalletWeight { get; set; }
        public Nullable<float> PalletWeightAverage { get; set; }
        public string ProductNumberRemarkGroup { get; set; }
        public string DispatchingOrderDetailRemark { get; set; }
        public int DispatchingOrderDetailID { get; set; }
        public string Temperature { get; set; }
        public decimal QtyCtns { get; set; }
        public decimal QtyPcs { get; set; }
        public string VehicleNumber { get; set; }
    }
}
