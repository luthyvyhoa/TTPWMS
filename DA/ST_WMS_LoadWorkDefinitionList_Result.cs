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

    public partial class ST_WMS_LoadWorkDefinitionList_Result
    {
        public int MHLWorkDefinitionID { get; set; }
        public Nullable<int> CustomerMainID { get; set; }
        public string JobName { get; set; }
        public string Description { get; set; }
        public Nullable<float> UnitPrice { get; set; }
        public string Unit { get; set; }
        public Nullable<int> ServiceID { get; set; }
        public string MHLWorkDefinitionNumber { get; set; }
        public string ServiceNumber { get; set; }
        public string ServiceName { get; set; }
        public bool IsModified { get; set; }
        public bool Discontinued { get; set; }
    }
}