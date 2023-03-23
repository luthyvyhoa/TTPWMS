using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public partial class Discounts
    {
        public int DiscountID { get; set; }
        public string DiscountNumber { get; set; }
        public string Description { get; set; }
        public int CustomerID { get; set; }
        public int ContractID { get; set; }
        public string Measure { get; set; }
        public string MeasureVietnam { get; set; }
        public Nullable<decimal> FromValue { get; set; }
        public Nullable<decimal> ToValue { get; set; }
        public Nullable<decimal> Persent { get; set; }
        public Nullable<System.DateTime> FromDate { get; set; }
        public Nullable<System.DateTime> ToDate { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedTime { get; set; }
        public string UpdateBy { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
        public string ConfirmBy { get; set; }
        public Nullable<System.DateTime> ConfirmTime { get; set; }
        public bool IsModified { get; set; }
    }
}
