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
    
    public partial class Gate_WorkerRegularInOut
    {
        public int WorkerRegularInOutID { get; set; }
        public int WorkerID { get; set; }
        public Nullable<System.DateTime> TimeIn1 { get; set; }
        public Nullable<System.DateTime> TimeOut1 { get; set; }
        public Nullable<System.DateTime> TimeIn2 { get; set; }
        public Nullable<System.DateTime> TimeOut2 { get; set; }
        public Nullable<bool> CheckOut { get; set; }
        public Nullable<byte> Gate { get; set; }
        public string Remark { get; set; }
        public Nullable<short> UniformReflectedLight { get; set; }
    
        public virtual Gate_Workers Gate_Workers { get; set; }
    }
}
