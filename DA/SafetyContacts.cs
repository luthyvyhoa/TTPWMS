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
    
    public partial class SafetyContacts
    {
        public int SafetyContactID { get; set; }
        public System.DateTime SafetyContactDate { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedTime { get; set; }
        public string SafetyContactDescription { get; set; }
        public string EmployeeID { get; set; }
        public string SafetyCommiteeResponse { get; set; }
        public string TaskAssignedTo { get; set; }
        public Nullable<System.DateTime> TaskPlannedDate { get; set; }
        public bool TaskCompleted { get; set; }
        public bool Confirmed { get; set; }
        public Nullable<System.DateTime> ConfirmedTime { get; set; }
        public string ConfirmedBy { get; set; }
        public string ManagementResponse { get; set; }
    }
}