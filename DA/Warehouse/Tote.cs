using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Warehouse
{
  
    public partial class Tote
    {
        public int ToteID { get; set; }
        public string CreateBy { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public string Remark { get; set; }
        public string ToteNumber { get; set; }
    }
}
