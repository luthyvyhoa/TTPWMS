using System;

namespace DA.Stock
{
    public partial class STStockByLocationReport
    {
        public string ID { get; set; }
        public string ProductName { get; set; }
        public string LocationNumber { get; set; }
        public short Qty { get; set; }
        public string CustomerNumber { get; set; }
        public string CustomerName { get; set; }
        public int ReceivingOrderID { get; set; }
        public string CustomerRef { get; set; }
        public Nullable<System.DateTime> ReceivingOrderDate { get; set; }
        public short Deep { get; set; }
        public string ReceivingOrderNumber { get; set; }
        public Nullable<int> TotalAfterDPQuantity { get; set; }
        public int PalletID { get; set; }
        public Nullable<System.DateTime> ProductionDate { get; set; }
        public Nullable<System.DateTime> UseByDate { get; set; }
        public int CustomerID { get; set; }
        public bool Low { get; set; }
        public decimal WeightPerPackage { get; set; }
        public Nullable<short> Inners { get; set; }
        public byte Status { get; set; }
        public bool OnHold { get; set; }
        public short PackagesPerPallet { get; set; }
        public string RoomID { get; set; }
        public short AfterDPQuantity { get; set; }
        public Nullable<decimal> GrossWeightPerPackage { get; set; }
        public Nullable<decimal> TotalGrossWeight { get; set; }
        public Nullable<int> Total { get; set; }
        public string Remark { get; set; }
        public int CustomerID_ORD { get; set; }
        public Nullable<byte> PalletStatus { get; set; }
        public Nullable<decimal> NetWeight { get; set; }
        public Nullable<decimal> GrossWeight { get; set; }
        public string PalletStatusDescriptionVietnam { get; set; }
        public float Temperature { get; set; }

        public int UnitQuantity { get; set; }
        public decimal PalletWeight { get; set; }
        
    }
}
