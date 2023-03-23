using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public partial class SPLoadLocationBooking_Result
    {
        public string RoomName { get; set; }
        public Nullable<int> Aisle { get; set; }
        public Nullable<int> QtyFree { get; set; }
        public Nullable<decimal> Occupancy { get; set; }
        public Nullable<int> QtyBooking { get; set; }
        public Nullable<int> LocationBookingID { get; set; }
    }
}
