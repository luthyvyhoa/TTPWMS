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
    
    public partial class Attachments
    {
        public int AttachmentID { get; set; }
        public string OrderNumber { get; set; }
        public string AttachmentDescription { get; set; }
        public string AttachmentFile { get; set; }
        public System.DateTime AttachmentDate { get; set; }
        public string AttachmentUser { get; set; }
        public byte[] TS { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<int> AttachmentFileSize { get; set; }
        public Nullable<int> ConfidentialLevel { get; set; }
        public string OriginalFileName { get; set; }
        public Nullable<byte> PrintStatus { get; set; }
    }
}