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
    
    public partial class ST_WMS_FindUserLogin_Result
    {
        public int EmployeeID { get; set; }
        public string LoginName { get; set; }
        public string LevelOfAuthorization { get; set; }
        public int Gate { get; set; }
        public Nullable<int> DefaultCustomer { get; set; }
        public bool IsAllowEDI { get; set; }
        public Nullable<bool> UserActive { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedTime { get; set; }
        public int StoreID { get; set; }
        public string Password { get; set; }
        public Nullable<byte> WarehouseID { get; set; }
        public string DeviceNumber { get; set; }
        public Nullable<bool> IsOnline { get; set; }
        public Nullable<bool> IsAllowOutside { get; set; }
        public Nullable<System.DateTime> LastActivityDate { get; set; }
        public byte[] TS { get; set; }
    }
}
