using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public partial class ST_WMS_LoadDPProductDataAllPallet_Result
    {
        public int DispatchingLocationID { get; set; }
        public int DispatchingProductID { get; set; }
        public int LocationID { get; set; }
        public int PalletID { get; set; }

        public string Label { get; set; }
        public short QuantityOfPackages { get; set; }
        public string DispatchingLocationRemark { get; set; }
        public string ReceivingScannedBy { get; set; }
        public Nullable<System.DateTime> ReceivingScannedTime { get; set; }
        public string PutAwayScannedBy { get; set; }
        public Nullable<System.DateTime> PutAwayScannedTime { get; set; }
        public Nullable<float> PalletWeight { get; set; }
    }
}
