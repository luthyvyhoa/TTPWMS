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
    
    public partial class ST_WMS_LoadEDIDetailsByID_Result
    {
        public int EDI_OrderDetailID { get; set; }
        public Nullable<int> EDI_OrderID { get; set; }
        public string ProductNumber { get; set; }
        public string ProductName { get; set; }
        public Nullable<int> Quantity { get; set; }
        public bool FIFO { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<int> FoundProductID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public Nullable<int> QuantityMax { get; set; }
        public Nullable<System.DateTime> ProductionDate { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        public Nullable<float> WeightPerPackage { get; set; }
        public string ProductRemark { get; set; }
        public string CustomerRef { get; set; }
        public Nullable<int> ReceivingOrderID { get; set; }
        public Nullable<decimal> Weights { get; set; }
        public string Packages { get; set; }
        public Nullable<int> Units { get; set; }
        public string ClientCode { get; set; }
        public Nullable<decimal> COD { get; set; }
        public Nullable<int> DispatchingProductID { get; set; }
        public Nullable<int> Pcs { get; set; }
        public string UOM { get; set; }
        public Nullable<decimal> FOC { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> DiscAmount { get; set; }
        public Nullable<decimal> DiscPercent { get; set; }
        public Nullable<decimal> VATPercent { get; set; }
        public Nullable<decimal> VATAmount { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
        public short TotalPackages { get; set; }
        public bool IsDiffEXP { get; set; } = false;

      //  public Nullable<int> CustomerID { get; set; }

    }
}
