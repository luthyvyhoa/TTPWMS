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
    
    public partial class CustomerSalesPromotionProducts
    {
        public int CustomerSalesPromotionProductID { get; set; }
        public int CustomerSalesPromotionDetailID { get; set; }
        public int ProductID { get; set; }
        public string CustomerSalesPromotionProductRemark { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedTime { get; set; }
        public byte[] ts { get; set; }
        public Nullable<float> ProductDiscountPercentage { get; set; }
        public Nullable<short> BuyingUnitQuantity { get; set; }
        public Nullable<short> PromotionUnitQuantity { get; set; }
        public string SalesProductName { get; set; }
        public string ProductCode { get; set; }
        public Nullable<int> CustomerSalesContractDetailID { get; set; }
    
        public virtual CustomerSalesPromotionDetails CustomerSalesPromotionDetails { get; set; }
    }
}
