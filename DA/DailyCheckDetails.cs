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
    
    public partial class DailyCheckDetails
    {
        public int DailyCheckDetailID { get; set; }
        public int DailyCheckID { get; set; }
        public bool ColdRooms { get; set; }
        public string ColdRoomRemark { get; set; }
        public bool Doors { get; set; }
        public string DoorRemark { get; set; }
        public bool AmenitiesRooms { get; set; }
        public string AmenitiesRoomsRemark { get; set; }
        public bool RepackingRooms { get; set; }
        public string RepackingRoomsRemark { get; set; }
        public bool Annex { get; set; }
        public string AnnexRemark { get; set; }
    
        public virtual DailyChecks DailyChecks { get; set; }
    }
}
