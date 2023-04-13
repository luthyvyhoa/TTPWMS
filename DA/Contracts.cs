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
    
    public partial class Contracts
    {
        public Contracts()
        {
            this.ContractDetails = new HashSet<ContractDetails>();
        }

        public int ContractID { get; set; }
        public string ContractNumber { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<System.DateTime> ContractDate { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string ContractRemark { get; set; }
        public Nullable<int> ContractType { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedTime { get; set; }
        public string UpdateBy { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
        public string ContractAccountingNumber { get; set; }
        public Nullable<byte> BillingCycle { get; set; }
        public Nullable<System.DateTime> ReviewDate { get; set; }
        public string InsuranceUnit { get; set; }
        public Nullable<decimal> InsuranceUnitValue { get; set; }
        public Nullable<decimal> ProductMaxValue { get; set; }
        public byte ContractProgressStatus { get; set; }
        public Nullable<int> ContractMainID { get; set; }
        public Nullable<System.DateTime> ReturnedDate { get; set; }
        public string AppendixNumber { get; set; }
        public Nullable<System.DateTime> AppendixDate { get; set; }
        public string CustomerSignGender { get; set; }
        public string CustomerSignRepresentative { get; set; }
        public string CustomerSignPositionEnglish { get; set; }
        public string CustomerSignPositionVietnam { get; set; }
        public string CustomerSignEmail { get; set; }
        public Nullable<int> PaymentTerms { get; set; }
        public Nullable<int> QuotationID { get; set; }
        public Nullable<bool> IsAttachment { get; set; }
        public bool AccountingSystemUpdated { get; set; }
        public Nullable<System.DateTime> AccountingSystemUpdatedTime { get; set; }
        public Nullable<byte> AccountingStatus { get; set; }
        public string AccountingStatusNote { get; set; }
        public string AccountingUpdateBy { get; set; }
        public Nullable<System.DateTime> AccountingUpdateTime { get; set; }
        public virtual ICollection<ContractDetails> ContractDetails { get; set; }
        public string AccountingCustomerMainID { get; set; }
        public string ContractAccountingNumberEX { get; set; }
        public Nullable<System.DateTime> AccountingEndDate { get; set; }
        public string ContractRemarkAccounting { get; set; }
        public string CurrencyUnit { get; set; }
        public string ConNumber { get; set; }
        public Nullable<System.DateTime> OldEndDate { get; set; }
    }
}
