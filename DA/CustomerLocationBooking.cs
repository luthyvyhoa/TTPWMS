using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public partial class CustomerLocationBooking
    {
        public int LocationBookingID { get; set; }
        public Nullable<System.Guid> CustomerBookingID { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<int> CustomerBookingDetailsID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public Nullable<int> RoomID { get; set; }
        public Nullable<int> Ailse { get; set; }
        public Nullable<int> LocationQty { get; set; }
        public Nullable<System.DateTime> CreatedTime { get; set; }
        public string CreatedBy { get; set; }
    }
}
