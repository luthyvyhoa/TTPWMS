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
    
    public partial class STPalletInfo_RODO_Find_Result
    {
        public string OrderNumber { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public string CustomerNumber { get; set; }
        public string Orderremark { get; set; }
        public string ProductNumber { get; set; }
        public string ProductName { get; set; }
        public string CustomerRef { get; set; }
        public Nullable<short> OriginalQuantity { get; set; }
        public Nullable<short> DetailedQuantity { get; set; }
        public Nullable<short> AfterDPQuantity { get; set; }
        public int PalletID { get; set; }
        public Nullable<bool> CanNotAdd { get; set; }
        public Nullable<bool> OnHold { get; set; }
        public Nullable<byte> Status { get; set; }
        public string Label { get; set; }
        public Nullable<int> UnitQuantity { get; set; }
        public Nullable<float> PalletWeight { get; set; }
        public Nullable<System.DateTime> ProductionDate { get; set; }
        public Nullable<System.DateTime> UseByDate { get; set; }
        public Nullable<int> LocationID { get; set; }
        public int CustomerID { get; set; }
    }
}
