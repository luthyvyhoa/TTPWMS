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
    
    public partial class tmpPayrollMonthlyDetails
    {
        public int tmpPayRollMonthlyID { get; set; }
        public int PayRollMonthID { get; set; }
        public int EmployeeID { get; set; }
        public bool ContractPermanent { get; set; }
        public Nullable<float> WorkingDays { get; set; }
        public Nullable<float> OTS { get; set; }
        public Nullable<float> OTN { get; set; }
        public Nullable<float> OTH { get; set; }
        public Nullable<float> Sick { get; set; }
        public Nullable<float> Leave { get; set; }
        public Nullable<float> Haft { get; set; }
        public Nullable<float> Off { get; set; }
        public string ABC { get; set; }
        public float Performance { get; set; }
        public float PerformanceAverage { get; set; }
        public bool PerformanceStatus { get; set; }
        public string SupervisorABC { get; set; }
        public string SupervisorRemark { get; set; }
        public bool PersonnelCheck { get; set; }
        public string PersonnelRemark { get; set; }
        public Nullable<System.DateTime> PersonnelCheckTime { get; set; }
        public bool SafetyCheck { get; set; }
        public string SafetyRemark { get; set; }
        public Nullable<System.DateTime> SafetyCheckTime { get; set; }
        public bool ManagerCheck { get; set; }
        public string ManagerRemark { get; set; }
        public Nullable<System.DateTime> ManagerCheckTime { get; set; }
        public bool MonthConfirm { get; set; }
        public byte[] TS { get; set; }
    }
}