using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public partial class QCMaster
    {
        public int PackageTypeID { get; set; }
        public string PackageName { get; set; }
        public Nullable<decimal> Value1 { get; set; }
        public Nullable<decimal> Value2 { get; set; }
        public Nullable<int> MeasureID { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedTime { get; set; }
    }
}
