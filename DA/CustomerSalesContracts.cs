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
    using System.Xml.Serialization;
    
    public partial class CustomerSalesContracts
    {
        public CustomerSalesContracts()
        {
            this.CustomerSalesContractDetails = new HashSet<CustomerSalesContractDetails>();
            this.CustomerSalesInvoices = new HashSet<CustomerSalesInvoices>();
        }
    
        public int CustomerSalesContractID { get; set; }
        public string CustomerSalesContractNumber { get; set; }
        public int CustomerID { get; set; }
        public int CustomerClientID { get; set; }
        public Nullable<System.DateTime> SalesContractDate { get; set; }
        public Nullable<System.DateTime> SalesContractFromDate { get; set; }
        public Nullable<System.DateTime> SalesContractToDate { get; set; }
        public string SalesContractRemark { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedTime { get; set; }
        public string ConfirmedBy { get; set; }
        public Nullable<System.DateTime> ConfirmedTime { get; set; }
        public byte[] ts { get; set; }
        public Nullable<float> DiscountPercentage { get; set; }
        public Nullable<bool> CustomerSalesContractConfirmed { get; set; }
        public Nullable<bool> Stamp { get; set; }
    
        public virtual CustomerClients CustomerClients { get; set; }
        public virtual Customers Customers { get; set; }
         [XmlIgnoreAttribute]
        public virtual ICollection<CustomerSalesContractDetails> CustomerSalesContractDetails { get; set; }
         [XmlIgnoreAttribute]
        public virtual ICollection<CustomerSalesInvoices> CustomerSalesInvoices { get; set; }
    }
}
