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
    
    public partial class STNFC_CustomerSalesInvoicesPalletViewAll_Result
    {
        public int PalletID { get; set; }
        public string PalletRemark { get; set; }
        public bool OnHold { get; set; }
        public Nullable<System.DateTime> ProductionDate { get; set; }
        public Nullable<System.DateTime> UseByDate { get; set; }
        public string ReceivingOrderNumber { get; set; }
        public Nullable<float> SelfLifePercentage { get; set; }
        public string LocationNumber { get; set; }
        public short AfterDPQuantity { get; set; }
        public string CustomerRef { get; set; }
        public Nullable<System.DateTime> ReceivingOrderDate { get; set; }
    }
}
