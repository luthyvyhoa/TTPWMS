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
    
    public partial class ST_WMS_LoadListProductByCustomer_Result
    {
        public int ProductID { get; set; }
        public string ProductNumber { get; set; }
        public int CustomerID { get; set; }
        public string ProductName { get; set; }
        public decimal WeightPerPackage { get; set; }
        public int HomeLocation1 { get; set; }
        public int HomeLocation2 { get; set; }
        public short PackagesPerPallet { get; set; }
        public int ProductCategory { get; set; }
        public Nullable<short> PackagesPerPallet2 { get; set; }
        public Nullable<bool> Discontinue { get; set; }
        public Nullable<short> Inners { get; set; }
        public string Packages { get; set; }
        public Nullable<decimal> GrossWeightPerPackage { get; set; }
        public Nullable<short> WarningDaysBeforeExpiry { get; set; }
        public Nullable<decimal> CBM { get; set; }
        public Nullable<System.DateTime> CreatedTime { get; set; }
        public short pcs { get; set; }
        public Nullable<float> TemperatureRequire { get; set; }
        public Nullable<int> SafetyStock { get; set; }
        public int CustomerMainID { get; set; }
        public string ProductGroupDescription { get; set; }
        public string Initial { get; set; }
        public string ERPUnit { get; set; }
        public Nullable<int> SelfLifeDays { get; set; }
        public Nullable<bool> HasSyncNavi { get; set; }
        public Nullable<decimal> Net { get; set; }
    }
}
