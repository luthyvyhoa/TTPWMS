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
    
    public partial class PropertyDamages
    {
        public int PropertyDamageID { get; set; }
        public Nullable<System.DateTime> DamageDate { get; set; }
        public Nullable<System.DateTime> CreatedTime { get; set; }
        public string CreatedBy { get; set; }
        public string DamagedPropeties { get; set; }
        public string DamageDescription { get; set; }
        public string Location { get; set; }
        public Nullable<int> Department { get; set; }
        public Nullable<int> EstimatedValueLost { get; set; }
        public string CurrencyUnit { get; set; }
        public string ProposedSolution { get; set; }
        public string ActionTakenBy { get; set; }
        public string DamageConfirmedBy { get; set; }
        public Nullable<System.DateTime> ConfirmTime { get; set; }
        public string ManagerFeedback { get; set; }
        public bool DamageConfirmed { get; set; }
        public Nullable<int> EmployeeID { get; set; }
        public string ExpensesCoverBy { get; set; }
        public string DocumentFolder { get; set; }
        public byte[] TS { get; set; }
        public Nullable<System.DateTime> ActionDate { get; set; }
    }
}
