using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public partial class ErrorLogs
    {
        public int ErrorLogsID { get; set; }
        public string ContentsError { get; set; }
        public string InnerException { get; set; }
        public string StackTrace { get; set; }
        public string UserName { get; set; }
        public Nullable<System.DateTime> CreatedTime { get; set; }
    }
}
