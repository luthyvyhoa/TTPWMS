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
    using System.Collections.Generic;
    
    public partial class tmpBillingRunByDispatchingOrders
    {
        public int RecordID { get; set; }
        public int ReceivingOrderID { get; set; }
        public string ReceivingOrderNumber { get; set; }
        public Nullable<System.DateTime> ReceivingOrderDate { get; set; }
        public string RORemark { get; set; }
        public string DispatchingOrderNumber { get; set; }
        public System.DateTime DispatchingOrderDate { get; set; }
        public Nullable<short> ReceivedQty { get; set; }
        public string ProductNumber { get; set; }
        public string ProductName { get; set; }
        public string CustomerRef { get; set; }
        public string SpecialRequirement { get; set; }
        public short DispatchingOrderQty { get; set; }
        public string CustomerNumber { get; set; }
        public int DispatchingProductID { get; set; }
        public Nullable<float> WeightPerPackage { get; set; }
        public string CustomerName { get; set; }
        public int DispatchingOrderID { get; set; }
        public Nullable<System.DateTime> ProductionDate { get; set; }
        public Nullable<System.DateTime> UseByDate { get; set; }
    }
}
