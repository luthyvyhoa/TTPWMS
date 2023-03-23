using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public partial class ExCustomerClientRule
    {
        public int ExClientRuleID { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public string ProductNumber { get; set; }
        public string ProductName { get; set; }
        public Nullable<int> ClientID { get; set; }
        public Nullable<int> RuleID { get; set; }
        public Nullable<bool> IsClientGroup { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedTime { get; set; }
    }
}
