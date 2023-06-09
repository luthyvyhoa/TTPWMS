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
    using System.Xml.Serialization;

    public partial class DailyChecks
    {
        public DailyChecks()
        {
            this.DailyCheckDetails = new HashSet<DailyCheckDetails>();
        }

        public int DailyCheckID { get; set; }
        public int SupervisorID { get; set; }
        public byte ShiftID { get; set; }
        public Nullable<byte> DepartmentID { get; set; }
        public string DailyCheckRemark { get; set; }
        public System.DateTime DailyCheckDate { get; set; }
        public System.DateTime DailyCheckCreateDate { get; set; }
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
        public bool MHE { get; set; }
        public string MHERemark { get; set; }
        public bool Products { get; set; }
        public string ProductRemark { get; set; }
        public bool Yard { get; set; }
        public string YardRemark { get; set; }
        public bool ReadStatus { get; set; }
        public string ReadBy { get; set; }
        public string ReadComment { get; set; }
        public bool DailyCheckConfirmed { get; set; }
        public Nullable<System.DateTime> ConfirmedTime { get; set; }
        [XmlIgnoreAttribute]
        public virtual ICollection<DailyCheckDetails> DailyCheckDetails { get; set; }
        public virtual Employees Employees { get; set; }
        public virtual Shifts Shifts { get; set; }
    }
}
