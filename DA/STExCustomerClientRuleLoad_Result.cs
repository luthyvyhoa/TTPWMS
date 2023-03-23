using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public class STExCustomerClientRuleLoad_Result
    {
        public string ProductName { get; set; }
        public string ProductNumber { get; set; }
        public Nullable<bool> IsClientGroup { get; set; }
        public string CustomerName { get; set; }
        public string CustomerNumber { get; set; }
        public string CustomerClientCode { get; set; }
        public string CustomerClientName { get; set; }
        public string CustomerDispatchMethod { get; set; }
        public Nullable<long> No { get; set; }
        public int ExClientRuleID { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedTime { get; set; }

    }
}
