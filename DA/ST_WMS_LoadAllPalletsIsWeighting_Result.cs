using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public partial class ST_WMS_LoadAllPalletsIsWeighting_Result
    {
        public string ProductNumber { get; set; }
        public string ProductName { get; set; }
        public int PalletID { get; set; }
        public string Label { get; set; }
        public short OriginalQuantity { get; set; }
        public short AfterDPQuantity { get; set; }
        public short CurrentQuantity { get; set; }
        public bool OnHold { get; set; }
        public int ReceivingOrderDetailID { get; set; }
        public int LocationID { get; set; }
        public byte status { get; set; }
        public bool CanMove { get; set; }
        public string Remark { get; set; }
        public bool CanNotAdd { get; set; }
        public byte[] TS { get; set; }
        public Nullable<int> UnitQuantity { get; set; }
        public Nullable<float> PalletWeight { get; set; }
        public Nullable<byte> PalletStatus { get; set; }
        public string ReceivingScannedBy { get; set; }
        public Nullable<System.DateTime> ReceivingScannedTime { get; set; }
        public string PutAwayScannedBy { get; set; }
        public Nullable<System.DateTime> PutAwayScannedTime { get; set; }
        public int OriginalPalletID { get; set; }
    }
}
