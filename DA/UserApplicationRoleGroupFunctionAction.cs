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
    
    public partial class UserApplicationRoleGroupFunctionAction
    {
        public int UserApplicationRoleGroupFunctionActionId { get; set; }
        public int UserApplicationRoleGroupFunctionId { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedTime { get; set; }
        public int ActionId { get; set; }
    
        public virtual UserApplicationRoleGroupFunction UserApplicationRoleGroupFunction { get; set; }
    }
}
