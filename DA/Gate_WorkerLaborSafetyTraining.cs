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
    
    public partial class Gate_WorkerLaborSafetyTraining
    {
        public int LaborSafetyTrainID { get; set; }
        public string LaborSafetyTrainBy { get; set; }
        public Nullable<System.DateTime> LaborSafetyTrainDate { get; set; }
        public string Description { get; set; }
        public int WorkerID { get; set; }
    
        public virtual Gate_Workers Gate_Workers { get; set; }
    }
}
