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
    
    public partial class STPalletInforReportBeforeDispatch_Result
    {
        public int PalletID { get; set; }
        public short quantity { get; set; }
        public string CustomerRef { get; set; }
        public string ReceivingOrderNumber { get; set; }
        public bool OnHold { get; set; }
        public string LocationNumber { get; set; }
        public byte Status { get; set; }
        public string CustomerNumber { get; set; }
        public string CustomerName { get; set; }
        public string Remark { get; set; }
        public string ProductNumber { get; set; }
        public string ProductName { get; set; }
        public Nullable<System.DateTime> ReceivingOrderDate { get; set; }
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        public Nullable<int> Total { get; set; }
        public int ReceivingOrderID { get; set; }
        public short CurrentQuantity { get; set; }
        public Nullable<byte> PalletStatus { get; set; }
    }
}