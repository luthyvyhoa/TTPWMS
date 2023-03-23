using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public partial class QCSP
    {
        public int ProductPackageTypeID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public Nullable<int> PackageTypeID { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedTime { get; set; }
    }
}
