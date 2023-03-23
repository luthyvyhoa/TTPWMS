using System.Windows.Forms;
using Common.Controls;
using DA;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Data;
using UI.Helper;
using System;
using System.Reflection;

namespace UI.Management
{
    /// <summary>
    /// Definition role for user
    /// </summary>
    public partial class frm_M_RoleDefinition : frmBaseForm
    {
        private BindingList<UserGroupDefinition> groupList = null;
        private BindingList<UserFunctionDefinition> functionList = null;
        private BindingList<UserActionDefinition> actionList = null;
        private IEnumerable<UserApplicationRoleGroup> userRoleGroup = null;
        private IEnumerable<UserApplicationRoleGroupFunction> userRoleGroupFunction = null;
        private IEnumerable<UserApplicationRoleGroupFunctionAction> userRoleGroupFunctionAction = null;
        private List<int> lstGroupId = new List<int>();
        private List<int> lstUserApplicationRoleGroupId = new List<int>();

        /// <summary>
        /// Constructor
        /// </summary>
        public frm_M_RoleDefinition()
        {
            InitializeComponent();

            //Load all department
            this.LoadDepartment();

            // Load all role 
            this.LoadAllRole();

            // Load all groups
            this.LoadAllGroup();

            // Load all actions
            this.LoadAllActions();

            // Set active button
            this.btn_M_Save.Enabled = false;
        }

        private void LoadAllRole()
        {
            DataProcess<ST_WMS_LoadAllUserRole_Result> userRoleDA = new DataProcess<ST_WMS_LoadAllUserRole_Result>();
            this.grd_M_RoleList.DataSource = userRoleDA.Executing("ST_WMS_LoadAllUserRole");
        }

        private void btn_M_Save_Click(object sender, System.EventArgs e)
        {
            if (this.lke_M_Departments.EditValue == null)
            {
                MessageBox.Show("Department is invalid", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.lke_M_Departments.Focus();
                return;
            }

            DataProcess<UserRoleDefinition> userRoleDA = new DataProcess<UserRoleDefinition>();
            var currentRole = this.GetUserRoleInfo();
            int resultInsert = userRoleDA.ExecuteNoQuery("Insert into UserRoleDefinitions(RoleName,Description,UserDepartmentDefinitionID,LevelDepartment) " +
                " Values ('" + currentRole.RoleName + "','" + currentRole.Description + "'," + currentRole.UserDepartmentDefinitionID + "," + 0 + ") ");
            if (resultInsert > -1)
            {
                MessageBox.Show("Successful", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btn_M_Clear_Click(sender, e);
                this.LoadAllRole();
            }
        }

        private void btn_M_Edit_Click(object sender, System.EventArgs e)
        {
            if (this.lke_M_Departments.EditValue == null) return;
            DataProcess<UserRoleDefinition> userRoleDA = new DataProcess<UserRoleDefinition>();

            UserRoleDefinition userRole = this.GetUserRoleInfo();
            userRole.RoleId = (int)this.grv_M_RoleList.GetRowCellValue(this.grv_M_RoleList.FocusedRowHandle, "RoleId");
            int resultInsert = userRoleDA.Update(userRole);
            if (resultInsert > -1)
            {
                MessageBox.Show("Successful", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.LoadAllRole();
            }
        }

        private void btn_M_Delete_Click(object sender, System.EventArgs e)
        {
            DataProcess<UserRoleDefinition> userRoleDA = new DataProcess<UserRoleDefinition>();
            UserRoleDefinition userRole = this.GetUserRoleInfo();
            userRole.RoleId = (int)this.grv_M_RoleList.GetRowCellValue(this.grv_M_RoleList.FocusedRowHandle, "RoleId");
            int resultInsert = userRoleDA.ExecuteNoQuery("ST_WMS_DeleteRoleDefinition @RoleID =" + userRole.RoleId);
            if (resultInsert > -1)
            {
                MessageBox.Show("Successful", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.LoadAllRole();
            }
        }

        private void btn_M_Clear_Click(object sender, System.EventArgs e)
        {
            // Set active control
            this.btn_M_Save.Enabled = true;
            this.btn_M_Edit.Enabled = false;
            this.btn_M_Delete.Enabled = false;

            this.txt_M_Name.Text = string.Empty;
            this.txt_M_Description.Text = string.Empty;
            this.lke_M_Departments.EditValue = null;
            this.txt_M_Name.Focus();
        }

        private void btn_M_Close_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void grv_M_RoleList_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.RowHandle < 0) return;

            // Get role data at row selected
            ST_WMS_LoadAllUserRole_Result roleSelected = (ST_WMS_LoadAllUserRole_Result)this.grv_M_RoleList.GetRow(e.RowHandle);

            // Set data details
            this.txt_M_Name.Text = roleSelected.RoleName;
            this.txt_M_Description.Text = roleSelected.Description;
            this.lke_M_Departments.EditValue = roleSelected.DepartmentID;

            // Set active control
            this.btn_M_Save.Enabled = false;
            this.btn_M_Edit.Enabled = true;
            this.btn_M_Delete.Enabled = true;

            // Get user role group
            DataProcess<UserApplicationRoleGroup> userRoleGroupsDA = new DataProcess<UserApplicationRoleGroup>();
            this.userRoleGroup = userRoleGroupsDA.Select(rg => rg.RoleId == roleSelected.RoleId);
            lstUserApplicationRoleGroupId = new List<int>();
            lstGroupId = new List<int>();
            if (this.userRoleGroup == null)
            {
                foreach (var groupsSelected in this.groupList)
                {
                    groupsSelected.IsSelected = false;
                }
            }
            else
            {
                // Get all group by role selected
                foreach (var groupsSelected in this.groupList)
                {
                    groupsSelected.IsSelected = false;
                    var lstUserRoleGroup = this.userRoleGroup.Where(rg => rg.GroupId == groupsSelected.GroupId);
                    if (lstUserRoleGroup.Count() > 0)
                    {
                        groupsSelected.IsSelected = true;
                        lstGroupId.Add(groupsSelected.GroupId);
                        lstUserApplicationRoleGroupId.Add(lstUserRoleGroup.FirstOrDefault().UserApplicationRoleGroupId);
                    }
                }
            }
            this.grv_M_Groups.RefreshData();
            LoadAllFunctions();
        }

        /// <summary>
        /// Get UserRole infor
        /// </summary>
        /// <returns></returns>
        private UserRoleDefinition GetUserRoleInfo()
        {
            if (this.lke_M_Departments.EditValue == null) return null;
            UserRoleDefinition userRole = new UserRoleDefinition();
            userRole.RoleName = this.txt_M_Name.Text;
            userRole.Description = this.txt_M_Description.Text;
            userRole.UserDepartmentDefinitionID = (int)this.lke_M_Departments.EditValue;
            return userRole;
        }

        /// <summary>
        /// Load all department
        /// </summary>
        private void LoadDepartment()
        {
            this.lke_M_Departments.Properties.DataSource = FileProcess.LoadTable("Select * from UserDepartmentDefinitions");
            this.lke_M_Departments.Properties.ValueMember = "UserDepartmentDefinitionID";
            this.lke_M_Departments.Properties.DisplayMember = "UserDepartmentDefinitionName";
        }

        /// <summary>
        /// Load all group has defined
        /// </summary>
        private void LoadAllGroup()
        {
            DataProcess<UserGroupDefinition> departmentDA = new DataProcess<UserGroupDefinition>();
            this.groupList = new BindingList<UserGroupDefinition>(departmentDA.Select().ToList());
            this.grd_M_Groups.DataSource = this.groupList;
        }

        /// <summary>
        /// Load all functions has defined
        /// </summary>
        private void LoadAllFunctions()
        {
            if(this.grv_M_Groups.FocusedRowHandle<0)return;
            var groupId = (int)this.grv_M_Groups.GetRowCellValue(this.grv_M_Groups.FocusedRowHandle, "GroupId");
            DataProcess<UserFunctionDefinition> departmentDA = new DataProcess<UserFunctionDefinition>();
            var dataSourceFunction = departmentDA.Select().Where(x =>x.GroupId==groupId).ToList();
            this.functionList = new BindingList<UserFunctionDefinition>(dataSourceFunction);

            // Get user role group function
            DataProcess<UserApplicationRoleGroupFunction> userRoleGroupsFunctionDA = new DataProcess<UserApplicationRoleGroupFunction>();
            this.userRoleGroupFunction = userRoleGroupsFunctionDA.Select(gf => lstUserApplicationRoleGroupId.Contains(gf.UserApplicationRoleGroupId));
            if (this.userRoleGroupFunction == null)
            {
                foreach (var functionSelected in this.functionList)
                {
                    functionSelected.IsSelected = false;
                }
            }
            else
            {
                // Get all function by role selected
                foreach (var functionSelected in this.functionList)
                {
                    functionSelected.IsSelected = false;
                    if (this.userRoleGroupFunction.Where(rg => rg.FunctionId == functionSelected.FunctionId).Count() > 0)
                    {
                        functionSelected.IsSelected = true;
                    }
                }
            }

            
            this.grd_M_Functions.DataSource = this.functionList;
        }

        /// <summary>
        /// Load all Actions has defined
        /// </summary>
        private void LoadAllActions()
        {
            if (this.grv_M_Functions.FocusedRowHandle < 0) return;
            int functionID =Convert.ToInt32 (this.grv_M_Functions.GetFocusedRowCellValue("FunctionId"));
            DataProcess<UserActionDefinition> departmentDA = new DataProcess<UserActionDefinition>();
            this.actionList = new BindingList<UserActionDefinition>(departmentDA.Select(a => a.FunctionID == functionID).ToList());
            this.grd_M_Actions.DataSource = this.actionList;
        }

        private void LoadGroupByRoleId()
        {
            // DataProcess<UserApplicationRoleGroup> roleGroupDA = new DataProcess<UserApplicationRoleGroup>();
            //  var listRoleGroup=roleGroupDA.Select(r=>r.r)
        }

        private void grv_M_Groups_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0) return;
            if (this.userRoleGroup == null) return;
            this.LoadAllFunctions();
        }

        private void grv_M_Functions_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0) return;
            if (this.userRoleGroupFunction == null) return;
            this.LoadAllActions();
            // Get function selected
            UserFunctionDefinition functionSelected = (UserFunctionDefinition)this.grv_M_Functions.GetRow(e.FocusedRowHandle);

            // Get group function selected
            UserApplicationRoleGroupFunction roleGroupFunctionSelected = userRoleGroupFunction.Where(gf => gf.FunctionId == functionSelected.FunctionId).FirstOrDefault();
            if (roleGroupFunctionSelected == null)
            {
                foreach (var actionSelected in this.actionList)
                {
                    actionSelected.IsSelected = false;
                }
                this.grv_M_Actions.RefreshData();
                return;
            }

            // Get user role group function action by function selected
            DataProcess<UserApplicationRoleGroupFunctionAction> userRoleGroupsFunctionActionDA = new DataProcess<UserApplicationRoleGroupFunctionAction>();
            this.userRoleGroupFunctionAction = userRoleGroupsFunctionActionDA.Select(gf => gf.UserApplicationRoleGroupFunctionId == roleGroupFunctionSelected.UserApplicationRoleGroupFunctionId);

            foreach (var actionSelected in this.actionList)
            {
                actionSelected.IsSelected = false;
                if (this.userRoleGroupFunctionAction.Where(fg => fg.ActionId == actionSelected.ActionId).Count() > 0)
                {
                    actionSelected.IsSelected = true;
                }
            }

            this.grv_M_Actions.RefreshData();
        }

        private void rpi_chk_GroupIsSelected_CheckedChanged(object sender, System.EventArgs e)
        {
            if (this.userRoleGroup == null) return;
            DataProcess<UserApplicationRoleGroup> roleGroupDA = new DataProcess<UserApplicationRoleGroup>();
            var groupId = (int)this.grv_M_Groups.GetRowCellValue(this.grv_M_Groups.FocusedRowHandle, "GroupId");
            var roleDefinitionID = (int)this.grv_M_RoleList.GetRowCellValue(this.grv_M_RoleList.FocusedRowHandle, "RoleId");
            UserApplicationRoleGroup roleGroupSelected = this.userRoleGroup.Where(rg => rg.GroupId == groupId).FirstOrDefault();
            int result = -1;
            if (roleGroupSelected == null)
            {
                // Add new group into this role
                UserApplicationRoleGroup newRoleGroup = new UserApplicationRoleGroup();
                newRoleGroup.GroupId = groupId;
                newRoleGroup.RoleId = roleDefinitionID;
                newRoleGroup.CreatedBy = AppSetting.CurrentUser.LoginName;
                newRoleGroup.CreatedTime = DateTime.Now;
                result = roleGroupDA.Insert(newRoleGroup);
                lstGroupId.Add(groupId);
                var lst = this.userRoleGroup.ToList();
                lst.Add(newRoleGroup);
                this.userRoleGroup = lst.AsEnumerable();
            }
            else
            {
                // Delete group in this role
                result = roleGroupDA.ExecuteNoQuery("ST_WMS_DeleteUserApplicationRoleGroup @UserApplicationRoleGroupId =" + roleGroupSelected.UserApplicationRoleGroupId);
                lstGroupId.Remove(groupId);
            }
            LoadAllFunctions();
        }

        private void rpi_chk_FunctionIsSelected_CheckedChanged(object sender, EventArgs e)
        {
            int functionId = (int)this.grv_M_Functions.GetRowCellValue(this.grv_M_Functions.FocusedRowHandle, "FunctionId");
            int groupId = Convert.ToInt32(this.functionList.FirstOrDefault(x => x.FunctionId == functionId).GroupId);
            var userApplicationRoleGroupSelected = this.userRoleGroup.Where(rg => rg.GroupId == groupId).FirstOrDefault();
            if (userApplicationRoleGroupSelected == null)
            {
                MessageBox.Show("Please first check on [Group],before re-check on [Function]", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ((DevExpress.XtraEditors.CheckEdit)sender).Reset();
                return;
            }
            DataProcess<UserApplicationRoleGroupFunction> roleGroupFunctionDA = new DataProcess<UserApplicationRoleGroupFunction>();
            UserApplicationRoleGroupFunction roleGroupFunctionSelected = this.userRoleGroupFunction == null ? null : this.userRoleGroupFunction.Where(gf => gf.FunctionId == functionId && gf.UserApplicationRoleGroupId == userApplicationRoleGroupSelected.UserApplicationRoleGroupId).FirstOrDefault();
            int result = -1;
            if (roleGroupFunctionSelected == null)
            {
                // Add new function into this group
                UserApplicationRoleGroupFunction newRoleGroupFunction = new UserApplicationRoleGroupFunction();
                newRoleGroupFunction.FunctionId = functionId;
                newRoleGroupFunction.UserApplicationRoleGroupId = userApplicationRoleGroupSelected.UserApplicationRoleGroupId;
                newRoleGroupFunction.CreatedBy = AppSetting.CurrentUser.LoginName;
                newRoleGroupFunction.CreatedTime = DateTime.Now;
                result = roleGroupFunctionDA.Insert(newRoleGroupFunction);
                var lst = this.userRoleGroupFunction.ToList();
                lst.Add(newRoleGroupFunction);
                this.userRoleGroupFunction = lst.AsEnumerable();
            }
            else
            {
                // Delete function in this group
                result = roleGroupFunctionDA.ExecuteNoQuery("Delete UserApplicationRoleGroupFunctions where userApplicationRoleGroupFunctionId=" + roleGroupFunctionSelected.UserApplicationRoleGroupFunctionId);
                // Delete actions in this group
                result = roleGroupFunctionDA.ExecuteNoQuery("Delete UserApplicationRoleGroupFunctionActions where userApplicationRoleGroupFunctionId=" + roleGroupFunctionSelected.UserApplicationRoleGroupFunctionId);
                foreach (var actionSelected in this.actionList)
                {
                    actionSelected.IsSelected = false;
                }
                this.grv_M_Actions.RefreshData();
            }
        }

        private void rpi_chk_ActionIsSelected_CheckedChanged(object sender, EventArgs e)
        {
            if (this.userRoleGroupFunctionAction == null) return;
            var actionDefinitionID = (int)this.grv_M_Actions.GetRowCellValue(this.grv_M_Actions.FocusedRowHandle, "ActionId");
            var functionDefinitionID = (int)this.grv_M_Functions.GetRowCellValue(this.grv_M_Functions.FocusedRowHandle, "FunctionId");
            UserApplicationRoleGroupFunction userApplicationRoleFunctionSelected = this.userRoleGroupFunction.Where(rg => rg.FunctionId == functionDefinitionID).FirstOrDefault();
            if (userApplicationRoleFunctionSelected == null)
            {
                MessageBox.Show("Please first check on [Function],before re-check on [Action]", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ((DevExpress.XtraEditors.CheckEdit)sender).Reset();
                return;
            }
            DataProcess <UserApplicationRoleGroupFunctionAction> roleGroupFunctionActionDA = new DataProcess<UserApplicationRoleGroupFunctionAction>();
            UserApplicationRoleGroupFunctionAction roleGroupFunctionActionSelected = this.userRoleGroupFunctionAction.Where(gf => gf.ActionId == actionDefinitionID && gf.UserApplicationRoleGroupFunctionId == userApplicationRoleFunctionSelected.UserApplicationRoleGroupFunctionId).FirstOrDefault();
            int result = -1;
            if (roleGroupFunctionActionSelected == null)
            {
                // Add new action into this function
                UserApplicationRoleGroupFunctionAction newRoleGroupFunctionAction = new UserApplicationRoleGroupFunctionAction();
                newRoleGroupFunctionAction.ActionId = (int)this.grv_M_Actions.GetRowCellValue(this.grv_M_Actions.FocusedRowHandle, "ActionId");
                newRoleGroupFunctionAction.UserApplicationRoleGroupFunctionId = userApplicationRoleFunctionSelected.UserApplicationRoleGroupFunctionId;
                newRoleGroupFunctionAction.CreatedBy = AppSetting.CurrentUser.LoginName;
                newRoleGroupFunctionAction.CreatedTime = DateTime.Now;
                result = roleGroupFunctionActionDA.Insert(newRoleGroupFunctionAction);
            }
            else
            {
                // Delete action in this function
                result = roleGroupFunctionActionDA.ExecuteNoQuery("Delete UserApplicationRoleGroupFunctionActions where UserApplicationRoleGroupFunctionActionId=" + roleGroupFunctionActionSelected.UserApplicationRoleGroupFunctionActionId);
            }
        }

        private void btnGetAction_Click(object sender, EventArgs e)
        {
            ActionListByApp actionListByApp = new ActionListByApp();
            actionListByApp.Show();
            actionListByApp.BringToFront();
        }
    }
}
