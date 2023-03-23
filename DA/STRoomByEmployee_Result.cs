using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public partial class STRoomByEmployee_Result
    {
        public Nullable<long> STT { get; set; }
        public Nullable<int> EmployeeAreaID { get; set; }
        public string AreaRemark { get; set; }
        public string RoomID { get; set; }
        public bool IsActive { get; set; }

    }
}
