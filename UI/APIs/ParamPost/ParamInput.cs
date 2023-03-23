using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.APIs.ParamPost
{
    /// <summary>
    /// Class define param input for API SmartLog
    /// </summary>
    public class ParamInput
    {
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string CarNumber { get; set; }
        public string ProviderName { get; set; }
        public string CreatedBy { get; set; }
    }
}
