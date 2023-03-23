using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Management
{
    public class PettyCashDetails
    {
        public int PettyCashDetailID { get; set; }
        public int PartID { get; set; }
        public string PartName { get; set; }
        public int Quantity { get; set; }
        public string Net { get; set; }
        public string VAT { get; set; }
        public string ExpenseAmount { get; set; }
        public System.DateTime ExpensesDate { get; set; }
        public string ItemRemark { get; set; }
        public string DocumentNumber { get; set; }
        public string ExpenseCategory { get; set; }
    }
}
