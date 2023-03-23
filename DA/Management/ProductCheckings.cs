using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Management
{
    public partial class ProductCheckings
    {
        public int ProductCheckingID { get; set; }
        public string ProductCheckingNumber { get; set; }
        public System.DateTime ProductCheckingDate { get; set; }
        public int CustomerID { get; set; }
        public Nullable<byte> Status { get; set; }
        public string Remark { get; set; }
        public Nullable<System.DateTime> CreatedTime { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
        public string DockNumber { get; set; }
        public Nullable<System.Int32> TimeSlot { get; set; }
        public string FromDO { get; set; }
        public string ConfirmedBy { get; set; }
        public Nullable<System.DateTime> ConfirmedTime { get; set; }
    }
}
