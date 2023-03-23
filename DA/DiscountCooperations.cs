using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public partial class DiscountCooperations
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public int ContractID { get; set; }
        public Nullable<bool> CooperationTime { get; set; }
        public Nullable<int> Month { get; set; }
        public Nullable<decimal> DiscountValue { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedTime { get; set; }
        public string UpdateBy { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
    }
}
