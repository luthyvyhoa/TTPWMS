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
    
    public partial class STContainerCheckingReport_Result
    {
        public string Gate { get; set; }
        public string ContainerNum { get; set; }
        public string ContainerType { get; set; }
        public string Reason { get; set; }
        public Nullable<System.DateTime> TimeIn { get; set; }
        public Nullable<bool> CheckOut { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public string DockNumber { get; set; }
        public string UserOut { get; set; }
        public string CustomerName { get; set; }
        public string ProductQty { get; set; }
    }
}