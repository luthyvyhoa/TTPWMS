using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Management
{
    public class PettyCash
    {
        public int PettyCashID { get; set; }
        public string PettyCashNumber { get; set; }
        public Nullable<System.DateTime> ActionDate { get; set; }
        public string ClearStatus { get; set; }
        public int ClearBy { get; set; }
        public System.DateTime AdvanceDate { get; set; }
        public int AdvanceAmount { get; set; }
        public string AdvanceRemark { get; set; }
        public string Currency { get; set; }
        public string Remark { get; set; }
        public string OrderBy { get; set; }
        public Nullable<System.Int32> PettyCashOldID { get; set; }
        public Nullable<System.DateTime> CreatedTime { get; set; }
        public string ts { get; set; }
        public Nullable<System.Int32> StoreID { get; set; }

        public int PaymentTo { get; set; }

        public string PaymentMethod { get; set; }
    }
}
