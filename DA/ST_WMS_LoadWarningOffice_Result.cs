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
    
    public partial class ST_WMS_LoadWarningOffice_Result
    {
        public int WarningID { get; set; }
        public Nullable<System.DateTime> WarningDate { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<int> EmployeeID { get; set; }
        public Nullable<int> Department { get; set; }
        public string WrongDoingDescription { get; set; }
        public Nullable<System.DateTime> OccuringTime { get; set; }
        public string OccurringLocation { get; set; }
        public string EmployeeFeedback { get; set; }
        public string ConfirmedBy { get; set; }
        public Nullable<System.DateTime> ConfirmTime { get; set; }
        public bool Confirmed { get; set; }
        public string ManagerFeedback { get; set; }
        public byte[] TS { get; set; }
        public bool Official { get; set; }
        public string VietnamName { get; set; }
        public string DepartmentName { get; set; }
        public string VietnamPosition { get; set; }
        public Nullable<int> StoreID { get; set; }
        public Nullable<int> EmployeeKPIDefinitionID { get; set; }
    }
}
