using DA;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Data;
using Common.Data;
using log4net;
using System;

namespace UI.Helper
{
    /// <summary>
    /// Get permission of current user login
    /// </summary>
    public static class UserPermission
    {
        private static DataTable rolesList = null;
        private static DataTable groupsList = null;
        private static DataTable functionList = null;

        // Declare log
        private static readonly ILog log = LogManager.GetLogger(typeof(UserPermission));

        /// <summary>
        /// Check user has permission with app
        /// </summary>
        /// <returns>bool</returns>
        public static bool CheckUserApplicationPermission()
        {
            try
            {
                DataProcess<ST_WMS_LoadApplicationByUser_Result> userApplicationDa = new DataProcess<ST_WMS_LoadApplicationByUser_Result>();

                // Validate UserApplication
                var isExistApplication = FileProcess.LoadTable("ST_WMS_LoadApplicationByUser @LoginName='" + AppSetting.CurrentUser.LoginName + "',@ApplicationName='" + Application.ProductName + "'");
                if (isExistApplication == null || isExistApplication.Rows.Count <= 0)
                {
                    return false;
                }

                Task.Run(() =>
                {
                    int userApplicationID = (int)isExistApplication.Rows[0]["UserApplicationId"];
                    // Get roles and groups of current user
                    CheckUserApplicationRole(userApplicationID);
                });
                return true;

            }
            catch (System.Exception ex)
            {
                log.Error("==> CheckUserApplicationPermission is error");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                return false;
            }
        }

        /// <summary>
        /// Get all roles and groups of current user
        /// </summary>
        /// <param name="userApplication">ST_WMS_LoadApplicationByUser_Result</param>
        /// <returns></returns>
        public static async Task CheckUserApplicationRole(int userApplicationID)
        {
            try
            {
                await Task.Run(() =>
                {
                    // Get all roles list
                    rolesList = FileProcess.LoadTable("ST_WMS_LoadAllRoleByUserPermisstion @LoginName='" + AppSetting.CurrentUser.LoginName + "' ,@UserApplicationID=" + userApplicationID);

                    // Get all groups list
                    groupsList = FileProcess.LoadTable("ST_WMS_LoadAllGroupByUserPermisstion @LoginName='" + AppSetting.CurrentUser.LoginName + "' ,@UserApplicationID=" + userApplicationID);

                    // Get all function list
                    functionList = FileProcess.LoadTable("ST_WMS_LoadAllFunctionByUserPermisstion @LoginName='" + AppSetting.CurrentUser.LoginName + "' ,@UserApplicationID=" + userApplicationID);

                    // Set active group function on app
                    frmMain.Instance.SetActiveGroup(groupsList);

                    // Set roles and groups permission info
                    UserPermissionData.RolesPermissionList = rolesList;
                    UserPermissionData.GroupsPermissionList = groupsList;
                    UserPermissionData.FunctionsPermisstionList = functionList;
                });
            }
            catch (System.Exception ex)
            {
                log.Error("==> CheckUserApplicationRole is error");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
            }
        }

        /// <summary>
        /// Checks the role user.
        /// </summary>
        /// <param name="receivingOrderDate">The receiving order date.</param>
        /// <returns></returns>
        public static bool CheckSupervisorByDepartment(string userName, int departmentDefinitionID)
        {
            var isExistApplication = FileProcess.LoadTable("ST_WMS_LoadApplicationByUser @LoginName='" + userName + "',@ApplicationName='" + Application.ProductName + "'");
            if (isExistApplication == null || isExistApplication.Rows.Count <= 0)
            {
                return false;
            }

            int userApplicationID = (int)isExistApplication.Rows[0]["UserApplicationId"];
            var datasource = FileProcess.LoadTable("ST_WMS_LoadAllRoleByUser @LoginName='" + userName + "' ,@UserApplicationID=" + userApplicationID);

            // Checking current user has level of accounting , if user is accounting then not allow change weight
            var departmentRole = datasource.Select("UserDepartmentDefinitionID=" + departmentDefinitionID);
            if (departmentRole == null || !departmentRole.Any())
            {
                return false;
            }

            foreach (var row in departmentRole)
            {
                int level = Convert.ToInt32(row["LevelDepartment"]);
                if (level > 3) // User is Supper User
                {
                    return true;
                }
            }

            // Account has level less more than or equal is User in Operation department then can not change weight value
            return false;
        }

        public static bool CheckBillingOperator(string userName, int departmentDefinitionID)
        {
            var isExistApplication = FileProcess.LoadTable("ST_WMS_LoadApplicationByUser @LoginName='" + userName + "',@ApplicationName='" + Application.ProductName + "'");
            if (isExistApplication == null || isExistApplication.Rows.Count <= 0)
            {
                return false;
            }

            int userApplicationID = (int)isExistApplication.Rows[0]["UserApplicationId"];
            var datasource = FileProcess.LoadTable("ST_WMS_LoadAllRoleByUser @LoginName='" + userName + "' ,@UserApplicationID=" + userApplicationID);

            // Checking current user has level of accounting , if user is accounting then not allow change weight
            var departmentRole = datasource.Select("UserDepartmentDefinitionID=" + departmentDefinitionID);
            if (departmentRole == null || !departmentRole.Any())
            {
                return false;
            }

            foreach (var row in departmentRole)
            {
                string rolename = row["RoleName"].ToString();
                if (rolename == "Billing Operator") // User is Supper User
                {
                    return true;
                }
            }

            // Account has level less more than or equal is User in Operation department then can not change weight value
            return false;
        }

        public static bool CheckAdminDepartment(string userName)
        {
            var isExistApplication = FileProcess.LoadTable("ST_WMS_LoadApplicationByUser @LoginName='" + userName + "',@ApplicationName='" + Application.ProductName + "'");
            if (isExistApplication == null || isExistApplication.Rows.Count <= 0)
            {
                return false;
            }

            int userApplicationID = (int)isExistApplication.Rows[0]["UserApplicationId"];
            var datasource = FileProcess.LoadTable("ST_WMS_LoadAllRoleByUser @LoginName='" + userName + "' ,@UserApplicationID=" + userApplicationID);

            // Checking current user has level of accounting , if user is accounting then not allow change weight
           

            foreach (var row in datasource.Select())
            {
                int level = Convert.ToInt32(row["LevelDepartment"]);
                if (level == 6) // User is manager
                {
                    return true;
                }
            }

            // Account has level less more than or equal is User in Operation department then can not change weight value
            return false;
        }
    }
}
