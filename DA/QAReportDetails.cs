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
    
    public partial class QAReportDetails
    {
        public int QAReportDetailID { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedTime { get; set; }
        public string OrderNumber { get; set; }
        public int ReceivingOrderDetailID { get; set; }
        public string Origin { get; set; }
        public string Manufactured { get; set; }
        public string CustomNo { get; set; }
        public string ContainerNo { get; set; }
        public string Note { get; set; }
        public Nullable<int> SupplierID { get; set; }
        public string SupplierName { get; set; }
        public Nullable<int> StoreNumber { get; set; }
        public byte[] ts { get; set; }
    }
}
