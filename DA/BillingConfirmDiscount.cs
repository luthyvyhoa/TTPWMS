using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
   public partial class BillingConfirmDiscount
    {
        public int ID { get; set; }
        public int ServiceID { get; set; }
        public int BillingDetailID { get; set; }
        public Nullable<decimal> Persent { get; set; }
        public Nullable<decimal> DiscountValue { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedTime { get; set; }
        public string UpdateBy { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
    }
}
