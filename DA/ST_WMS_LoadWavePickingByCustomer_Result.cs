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
    
    public partial class ST_WMS_LoadWavePickingByCustomer_Result
    {
        public int WavePickingID { get; set; }
        public System.DateTime WavePickingDate { get; set; }
        public System.DateTime CreatedTime { get; set; }
        public string CreatedBy { get; set; }
        public string WavePickingRemark { get; set; }
        public string WavePickingNumber { get; set; }
        public Nullable<bool> WaveConfirmed { get; set; }
        public Nullable<System.DateTime> StartWorkingTime { get; set; }
        public Nullable<System.DateTime> EndWorkingTime { get; set; }
        public string CustomerNumber { get; set; }
        public string CustomerName { get; set; }
    }
}
