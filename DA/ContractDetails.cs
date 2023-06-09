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
    
    public partial class ContractDetails
    {
        public int ContractDetailID { get; set; }
        public Nullable<int> ContractID { get; set; }
        public Nullable<int> ServiceID { get; set; }
        public Nullable<decimal> ContractServicePrice { get; set; }
        public string ContractDetailRemark { get; set; }
        public string CurrencyUnit { get; set; }
        public Nullable<double> CheckingQuantity { get; set; }
        public Nullable<double> CheckingQuantity2 { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
        public string ScopeOfWork { get; set; }
        public string ScopeOFWorkVietnam { get; set; }
        public string CalculatedSQL { get; set; }
        public bool IsModified { get; set; }
        public Nullable<int> LineNumber { get; set; }
        public Nullable<byte> VATPercentage { get; set; }
        public string MCServiceID { get; set; }
        public string ServiceNameInvoiced { get; set; }

        public virtual Contracts Contracts { get; set; }
        public virtual ServicesDefinition ServicesDefinition { get; set; }

        
    }
}
