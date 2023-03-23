using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Management
{
    public class AdvanceDetail
    {
        public int AdvanceID { get; set; }
        public string OrderNumber { get; set; }   
        public System.DateTime AdvanceDate { get; set; }
        public decimal AdvanceAmount { get; set; }
        public string AdvanceRemark { get; set; }
        public System.DateTime PayByDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedTime { get; set; }
    }
}
