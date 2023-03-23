using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public partial class ST_WMS_LoadCustomerRequirements_Result
    {
        public int CustomerRequirementID { get; set; }
        public string RequirementDetails { get; set; }
        public string UpdateBy { get; set; }
        public System.DateTime UpdateTime { get; set; }
        public Nullable<bool> RequirementConfirmed { get; set; }
        public string ApprovedBy { get; set; }
        public string RequirementCategory { get; set; }
    }
}
