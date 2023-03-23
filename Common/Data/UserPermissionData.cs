using DA;
using System.Data;
namespace Common.Data
{
    /// <summary>
    /// Contain all list data permission of current user
    /// </summary>
    public static class UserPermissionData
    {

        /// <summary>
        /// Get or set all roles of current user
        /// </summary>
        public static DataTable RolesPermissionList { get; set; }

        /// <summary>
        /// Get or set all groups function user has permission
        /// </summary>
        public static DataTable GroupsPermissionList { get; set; }

        /// <summary>
        /// Get or set all functions user has permission
        /// </summary>
        public static DataTable FunctionsPermisstionList { get; set; }

    }
}
