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
    
    public partial class ST_WMS_LoadStockOnHandAverageByCustomer_Result
    {
        public int CustomerID { get; set; }
        public System.DateTime ReportDate { get; set; }
        public Nullable<int> Pallets { get; set; }
        public Nullable<double> Weight { get; set; }
        public Nullable<long> Cartons { get; set; }
        public Nullable<int> PalletLow { get; set; }
        public Nullable<int> PalletVeryLow { get; set; }
        public Nullable<int> PalletVeryHigh { get; set; }
        public Nullable<int> PalletHigh { get; set; }
        public string CustomerNumber { get; set; }
        public string CustomerName { get; set; }
    }
}
