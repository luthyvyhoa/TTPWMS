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
    
    public partial class STProblem_InternalAuditReport_Result
    {
        public int InternalAuditID { get; set; }
        public string ProblemEmployees { get; set; }
        public Nullable<int> DepartmentID { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public string ProblemDescription { get; set; }
        public string PreventativeAction { get; set; }
        public string CorrectiveResult { get; set; }
        public Nullable<System.DateTime> InternalAuditDate { get; set; }
        public Nullable<bool> InternalAuditConfirmed { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedTime { get; set; }
        public string ConfirmedBy { get; set; }
        public Nullable<System.DateTime> ConfirmedTime { get; set; }
        public string ManagerFeedback { get; set; }
        public string CorrectiveAction { get; set; }
        public string CustomerName { get; set; }
        public string DepartmentName { get; set; }
        public string CustomerNumber { get; set; }
        public Nullable<int> ResolvedEmployeeID { get; set; }
        public string InternalAuditStatus { get; set; }
        public string ResolvedEmployee { get; set; }
        public string CorrectiveActionBy { get; set; }
        public string PreventativeActionBy { get; set; }
        public string ProblemCategoryDescription { get; set; }
        public Nullable<bool> Complained { get; set; }
    }
}
