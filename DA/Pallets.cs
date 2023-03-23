//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DA
{
    using System;
    using System.Collections.Generic;

    public partial class Pallets
    {
        public Pallets()
        {
            this.DispatchingOrderDetails = new HashSet<DispatchingOrderDetails>();
        }

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
        public string NaviPalletID { get; set; }
        public string NaviReceivingDate { get; set; }
        public string NaviLocationNo { get; set; }
        public Nullable<int> NaviStorageQty { get; set; }
        public string NaviLotNo { get; set; }
        public bool IsModified { get; set; }
        public string NaviROPalletID { get; set; }
        public string NaviRODate { get; set; }
        public string NaviROLocationNo { get; set; }
        public Nullable<int> NaviROQty { get; set; }
        public Nullable<bool> IsSendNavi { get; set; }

        public virtual ICollection<DispatchingOrderDetails> DispatchingOrderDetails { get; set; }
        public virtual ReceivingOrderDetails ReceivingOrderDetails { get; set; }
    }
}
