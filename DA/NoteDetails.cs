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
    
    public partial class NoteDetails
    {
        public int NoteDetailID { get; set; }
        public int NoteID { get; set; }
        public int ProductID { get; set; }
        public string ProductNumber { get; set; }
        public string ProductName { get; set; }
        public Nullable<double> WeightPerPackage { get; set; }
        public Nullable<int> OriginalQuantity { get; set; }
        public Nullable<int> ActualQuantity { get; set; }
        public string OriginalState { get; set; }
        public string ActualState { get; set; }
        public string Remark { get; set; }
    }
}
