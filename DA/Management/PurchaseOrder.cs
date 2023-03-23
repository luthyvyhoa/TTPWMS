using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Management
{
    public class PurchaseOrder
    {
        


        public int PurchasingOrderID { get; set; }
        public string SupplierName { get; set; }
        public string PurchasingOrderNumber { get; set; }
        public System.DateTime PuchasingDate { get; set; }
        public int SupplierID { get; set; }
        public Nullable<System.Int32> OrderEmployeeID { get; set; }
        public Nullable<System.DateTime> DeliveryDate { get; set; }
        public string DeliveryAddress { get; set; }
        public string OrderBy { get; set; }
        public string OrderConfirmed { get; set; }
        public string PurchasingRemark { get; set; }
        public string DepartmentCategoryID { get; set; }
        public string Currency { get; set; }
        public Nullable<System.Decimal> ExchangeRate { get; set; }
        public string InvoiceNumber { get; set; }
        public string UsedPeriod { get; set; }
        public string StrategicSupplier { get; set; }
        public string SupplierAddress { get; set; }
        public string SupplierContactName { get; set; }
        public string SupplierTitle { get; set; }
        public string SupplierPhone { get; set; }
        public string SupplierFax { get; set; }
        public string SupplierEmail { get; set; }
        public string SupplierRemark { get; set; }
        public string SupplierFullName { get; set; }
        public Nullable<System.DateTime> FinalPaymentDate { get; set; }
        public Nullable<System.DateTime> AdvancePaymentDate { get; set; }
        public string RiskAssessmentRequired { get; set; }
        public string CompetitivePricingRequired { get; set; }
        public string ContractNumber { get; set; }
        public Nullable<System.DateTime> ContractDate { get; set; }
        public Nullable<System.DateTime> ContractExpiredDate { get; set; }
        public string ContractRequired { get; set; }
        public string DocumentFileScan { get; set; }
        public string SpecialRequirement { get; set; }
        public string StoreNumber { get; set; }
        public string StoreDescription { get; set; }
        public Nullable<System.Int32> StoreID { get; set; }
        public string CreatedBy { get; set; }
        public string PONumberM3 { get; set; }



    }
}
