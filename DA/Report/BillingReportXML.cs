using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Report
{
    public class BillingReportXML
    {


        [StringLength(2, MinimumLength = 1, ErrorMessage = "InvoiceType missing or incorrect. Maximum 2 characters")]
        public string InvoiceType { get; set; }

        [StringLength(2, MinimumLength = 1, ErrorMessage = "StateCode missing or incorrect. Maximum 2 characters")]
        public string StateCode { get; set; }

        [StringLength(3, MinimumLength = 1, ErrorMessage = "CompanyCode missing or incorrect. Maximum 3 characters")]
        public string CompanyCode { get; set; }

        

        [StringLength(20, MinimumLength = 1, ErrorMessage = "InvoiceNumber missing or incorrect. Maximum 20 characters")]
        public string InvoiceNumber { get; set; }

        [StringLength(17, MinimumLength = 1, ErrorMessage = "InvoiceValue missing or incorrect. Maximum 17 characters")]
        public string InvoiceValue { get; set; }

        [StringLength(30, MinimumLength = 1, ErrorMessage = "WeekEndDate missing or incorrect. Maximum 30 characters")]
        public string WeekEndDate { get; set; }

        [StringLength(10, MinimumLength = 1, ErrorMessage = "CustomerNumber missing or incorrect. Maximum 10 characters")]
        public string CustomerNumber { get; set; }

        [StringLength(3, MinimumLength = 1, ErrorMessage = "CurrencyCode missing or incorrect. Maximum 3 characters")]
        public string CurrencyCode { get; set; }

        [StringLength(2, ErrorMessage = "CategoryCode Maximum 2 characters")]
        public string CategoryCode { get; set; }

        [StringLength(30,  ErrorMessage = "CategoryDesc Maximum 30 characters")]
        public string CategoryDesc { get; set; }

        [StringLength(30, MinimumLength = 1, ErrorMessage = "Amount missing or incorrect. Maximum 30 characters")]
        public string Amount { get; set; }

        [StringLength(3, MinimumLength = 1, ErrorMessage = "WarehouseCode missing or incorrect. Maximum 3 characters")]
        public string WarehouseCode { get; set; }

        [StringLength(50, MinimumLength = 1, ErrorMessage = "TransactionDesc missing or incorrect. Maximum 50 characters")]
        public string TransactionDesc { get; set; }

        [StringLength(15, MinimumLength = 1, ErrorMessage = "Quantity missing or incorrect. Maximum 15 characters")]
        public string Quantity { get; set; }

        [StringLength(17, MinimumLength = 1, ErrorMessage = "Rate missing or incorrect. Maximum 17 characters")]
        public string Rate { get; set; }

        [StringLength(10, MinimumLength = 1, ErrorMessage = "OM missing or incorrect. Maximum 10 characters")]
        public string OM { get; set; }

        [StringLength(3, MinimumLength = 1, ErrorMessage = "TransactionCode missing or incorrect. Maximum 3 characters")]
        public string TransactionCode { get; set; }
        //public string UserName { get; set; }
    }
}
