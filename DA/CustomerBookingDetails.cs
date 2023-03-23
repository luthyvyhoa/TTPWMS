using System;

namespace DA
{
    public partial class CustomerBookingDetails
    {
        public int CustomerBookingDetailsID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public string LotNo { get; set; }
        public Nullable<decimal> Weights { get; set; }
        public Nullable<int> Cartons { get; set; }
        public Nullable<decimal> Pallet { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedTime { get; set; }
        public System.Guid CustomerBookingID { get; set; }
        public string Email { get; set; }
        public string ProductNumber { get; set; }
        public string ProductName { get; set; }
        public Nullable<int> Quantity { get; set; }
        public bool FIFO { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<int> FoundProductID { get; set; }
        public Nullable<int> QuantityMax { get; set; }
        public Nullable<System.DateTime> ProductionDate { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        public Nullable<float> WeightPerPackage { get; set; }
        public string ProductRemark { get; set; }
        public string CustomerRef { get; set; }
        public Nullable<int> ReceivingOrderID { get; set; }
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
        public Nullable<decimal> PlannedQuantity { get; set; }
        public Nullable<decimal> PlannedWeights { get; set; }
        public string CustomerRemark { get; set; }
        public string CustomerLocationCode { get; set; }
        public string CustomerLocationCodeNew { get; set; }
        public string CustomerPalletID { get; set; }
    }
}
