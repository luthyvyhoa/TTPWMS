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
    
    public partial class STReceivingCartonReport_Result
    {
        public int ReceivingOrderID { get; set; }
        public string ReceivingOrderNumber { get; set; }
        public Nullable<System.DateTime> ReceivingOrderDate { get; set; }
        public string CustomerNumber { get; set; }
        public int ReceivingOrderDetailID { get; set; }
        public string ProductNumber { get; set; }
        public string ProductName { get; set; }
        public string CartonNumber { get; set; }
        public string CartonDescription { get; set; }
        public bool Dispatched { get; set; }
        public Nullable<int> DispatchingProductID { get; set; }
        public Nullable<int> DataRangeFrom { get; set; }
        public Nullable<int> DatarangeTo { get; set; }
        public Nullable<System.DateTime> ProductionDate { get; set; }
        public string CustomerName { get; set; }
    }
}
