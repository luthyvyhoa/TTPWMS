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
    
    public partial class CustomerServiceCostingDetails
    {
        public int CustomerServiceCostingDetailID { get; set; }
        public int CustomerServiceCostingID { get; set; }
        public string ItemDescription { get; set; }
        public float ItemQuantity { get; set; }
        public string ItemUnitOfMeasure { get; set; }
        public float ItemUnitRate { get; set; }
        public string ItemRemark { get; set; }
    
        public virtual CustomerServiceCosting CustomerServiceCosting { get; set; }
    }
}
