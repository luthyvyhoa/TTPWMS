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
    
    public partial class UserApplicationRoleGroupFunction
    {
        public UserApplicationRoleGroupFunction()
        {
            this.UserApplicationRoleGroupFunctionActions = new HashSet<UserApplicationRoleGroupFunctionAction>();
        }
    
        public int UserApplicationRoleGroupFunctionId { get; set; }
        public int UserApplicationRoleGroupId { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedTime { get; set; }
        public int FunctionId { get; set; }
    
        public virtual ICollection<UserApplicationRoleGroupFunctionAction> UserApplicationRoleGroupFunctionActions { get; set; }
        public virtual UserApplicationRoleGroup UserApplicationRoleGroup { get; set; }
    }
}
