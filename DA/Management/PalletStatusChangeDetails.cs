using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Management
{
    public class PalletStatusChangeDetails
    {
        public int PalletStatusChangeDetailID { get; set; }
        public int PalletStatusChangeID { get; set; }
        public int PalletID { get; set; }
        public byte OldStatus { get; set; }
        public byte NewStatus { get; set; }
        public string PalletStatusChangeDetailRemark { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public int CurrentQuantity { get; set; }
    }
}
