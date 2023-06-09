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

    public partial class BlastFreezers
    {
        public BlastFreezers()
        {
            this.BlastFreezerDetails = new HashSet<BlastFreezerDetails>();
        }

        public int BlastFreezerID { get; set; }
        public string BlastFreezerRecordNumber { get; set; }
        public System.DateTime DateIn { get; set; }
        public string CustomerName { get; set; }
        public int BlastFreezerRoomID { get; set; }
        public Nullable<System.DateTime> BlastFreezerCreateTime { get; set; }
        public Nullable<System.DateTime> StartLoadingTime { get; set; }
        public Nullable<System.DateTime> EndLoadingTime { get; set; }
        public Nullable<System.DateTime> BlastFreezerUloadingTime { get; set; }
        public string BlastFreezerLoadingBy { get; set; }
        public string ProductDetailsRemark { get; set; }
        public Nullable<double> TempIn { get; set; }
        public Nullable<double> TempOut { get; set; }
        public Nullable<short> ProductQty { get; set; }
        public string UserName { get; set; }
        public bool BlastFreezerConfirm { get; set; }
        public Nullable<System.DateTime> StartRunTime { get; set; }
        public Nullable<System.DateTime> EndRunTime { get; set; }
        public string StartRunUser { get; set; }
        public string EndRunUser { get; set; }
        public string BlastFreezerRunningRemark { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<bool> IsAttachment { get; set; }

        public string ReceivingOrder { get; set; }
        public Nullable<double> Qty { get; set; }
        public Nullable<double> Weight { get; set; }
        public Nullable<System.DateTime> TimeProductIn { get; set; }
        public Nullable<System.DateTime> TimeProductOut { get; set; }
        public virtual ICollection<BlastFreezerDetails> BlastFreezerDetails { get; set; }
    }
}
