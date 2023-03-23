using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public class STExCustomerClientRuleInsert_Result
    {
        public int CustomerID { get; set; }
        public string CreatedBy { get; set; }
        public string ProductName { get; set; }
        public string ProductNumber { get; set; }
        public int ClientID { get; set; }
        public int RuleID { get; set; }
        public bool IsClientGroup { get; set; }

    }
}
