using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public partial class WorkTypeDefinition
    {
        public int WorkTypeID { get; set; }
        public Nullable<int> WorkTypeCode { get; set; }
        public string WorkTypeName { get; set; }
        public string OrderType { get; set; }
        public string Descriptions { get; set; }
    }
}
