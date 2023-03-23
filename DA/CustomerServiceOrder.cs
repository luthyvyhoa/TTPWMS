using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public partial class CustomerServiceOrder
    {
        public int CustomerServiceOrderID { get; set; }
        public string CustomerServiceOrderNumber { get; set; }
        public int CustomerID { get; set; }
        public string CustomerServiceOrderRemark { get; set; }
        public string FunctionReferenceNumber { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedTime { get; set; }
        public string ConfirmedBy { get; set; }
        public Nullable<System.DateTime> ConfirmedTime { get; set; }
        public string RequestedBy { get; set; }
        public Nullable<System.DateTime> RequestedTime { get; set; }
        public Nullable<System.DateTime> ExpectedCompleteTime { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
        public string LabourRequirements { get; set; }
    }
}
