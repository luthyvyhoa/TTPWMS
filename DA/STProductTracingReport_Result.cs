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
    
    public partial class STProductTracingReport_Result
    {
        public int ReceivingOrderID { get; set; }
        public string ReceivingOrderNumber { get; set; }
        public int ReceivingOrderDetailID { get; set; }
        public string ProductNumber { get; set; }
        public string ProductName { get; set; }
        public string CustomerRef { get; set; }
        public short RODetailQty { get; set; }
        public float WeightPerPackage { get; set; }
        public string DispatchingOrderNumber { get; set; }
        public Nullable<System.DateTime> DispatchingOrderDate { get; set; }
        public string SpecialRequirement { get; set; }
        public string CustomerNumber { get; set; }
        public string CustomerName { get; set; }
        public Nullable<int> DODetailQty { get; set; }
        public string DPRemark { get; set; }
        public Nullable<int> CustomerClientID { get; set; }
        public string CustomerClientCode { get; set; }
        public string CustomerClientName { get; set; }
        public Nullable<System.DateTime> ProductionDate { get; set; }
        public Nullable<System.DateTime> UseByDate { get; set; }

        public Nullable<double> DODetailWeight { get; set; }

        public Nullable<int> CurrentQty { get; set; }
        public Nullable<double> CurrentWeight { get; set; }

        public string RODRemark { get; set; }
    }
}
