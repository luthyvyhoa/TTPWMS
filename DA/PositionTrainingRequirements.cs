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
    
    public partial class PositionTrainingRequirements
    {
        public int PositionTrainingRequirementID { get; set; }
        public Nullable<int> PositionID { get; set; }
        public Nullable<int> TrainingDefinitionID { get; set; }
        public Nullable<short> Frequence { get; set; }
        public string DefaultTrainingLocation { get; set; }
        public string Remark { get; set; }
        public Nullable<int> EmployeeSafetyTeamID { get; set; }
        public Nullable<int> StoreID { get; set; }
    }
}