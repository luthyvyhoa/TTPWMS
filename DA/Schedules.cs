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
    
    public partial class Schedules
    {
        public int ID { get; set; }
        public Nullable<int> EmployeeID { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> Status { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public Nullable<int> Label { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
        public string Location { get; set; }
        public Nullable<bool> AllDay { get; set; }
        public Nullable<int> EventType { get; set; }
        public string RecurrenceInfo { get; set; }
        public string ReminderInfo { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string ContactInfo { get; set; }
    }
}
