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
    
    public partial class STCustomerForecastHistoryData_Result
    {
        public int CustomerID { get; set; }
        public string CustomerNumber { get; set; }
        public string CustomerName { get; set; }
        public Nullable<decimal> LocationInout { get; set; }
        public Nullable<decimal> LocationOccupied { get; set; }
        public Nullable<decimal> WeightInOut { get; set; }
        public Nullable<decimal> WeightInStoreNet { get; set; }
        public Nullable<decimal> WeightInOutAdjusted { get; set; }
        public Nullable<decimal> WeightInStoreGross { get; set; }
        public Nullable<decimal> NumberOfTransactions { get; set; }
        public Nullable<decimal> Index_LocationInOut { get; set; }
        public Nullable<decimal> Index_Transactions { get; set; }
        public Nullable<decimal> LocationInOutActual { get; set; }
        public Nullable<decimal> TransactionActual { get; set; }
        public string MonthDescription { get; set; }
        public System.DateTime FromDate { get; set; }
        public System.DateTime Todate { get; set; }
    }
}
