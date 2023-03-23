using Common.Controls;
using System.Linq;
using UI.Helper;
using DA;
using DevExpress.XtraEditors;
using System.Collections.Generic;
using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel;
using System.Data;

namespace UI.Management
{
    public partial class frm_M_UserAccount : frmBaseForm
    {

        /// <summary>
        /// Declare current user
        /// </summary>
        private BindingList<UserApplicationDefinition> applicationDefinitionList = null;
        private BindingList<ST_WMS_LoadAllUserRole_Result> roleDefinitionList = null;
        private UserAccount currentUserSelected = null;
        private IEnumerable<ST_WMS_LoadUserAccount_Result> listUserAccounts = null;
        private IEnumerable<ST_WMS_LoadApplicationByUser_Result> userApplicationList = null;
        private IEnumerable<UserApplicationRole> userApplicationRoleList = null;
        private ST_WMS_LoadApplicationByUser_Result userApplicationSelected = null;

        /// <summary>
        /// Add comment
        /// </summary>
        public frm_M_UserAccount()
        {
            InitializeComponent();

            // Load all user account list
            this.LoadUserAccounts();

            // Set control active
            this.ActiveControl(true);

            // Init data on control
            this.InitData();

            // Load All definition data
            this.LoadAllApplication();

            // load all role definition
            this.LoadAllRoleList();

            // Load employee list
            this.LoadEmployeeList();

            // Load store list
            this.LoadStore();

            // Load Warehouse list
            this.LoadWareHouse();
        }

        private void btn_M_Close_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void frm_M_UserAccount_Load(object sender, System.EventArgs e)
        {
            // Select all user is active
            this.radgFilter.SelectedIndex = 1;
        }

        /// <summary>
        /// Load employee list
        /// </summary>
        private void LoadEmployeeList()
        {
            this.lke_M_EmployeeList.Properties.DataSource = AppSetting.EmployessList.Where(e => e.Active == true).ToList();
            this.lke_M_EmployeeList.Properties.ValueMember = "EmployeeID";
            this.lke_M_EmployeeList.Properties.DisplayMember = "FullName";
        }

        private void LoadUserAccounts()
        {
            DataProcess<ST_WMS_LoadUserAccount_Result> userAccountDA = new DataProcess<ST_WMS_LoadUserAccount_Result>();
            this.listUserAccounts = userAccountDA.Executing("ST_WMS_LoadUserAccount");
            this.grd_M_UserList.DataSource = this.listUserAccounts;
        }

        private void LoadStore()
        {
            DataProcess<Stores> storeDA = new DataProcess<Stores>();
            this.lke_M_StoreList.Properties.DataSource = storeDA.Select();
            this.lke_M_StoreList.Properties.ValueMember = "StoreID";
            this.lke_M_StoreList.Properties.DisplayMember = "StoreDescription";
        }

        private void LoadWareHouse()
        {
            DataProcess<Warehouses> warehouseDA = new DataProcess<Warehouses>();
            this.lke_M_WarehouseList.Properties.DataSource = warehouseDA.Select();
            this.lke_M_WarehouseList.Properties.ValueMember = "WarehouseID";
            this.lke_M_WarehouseList.Properties.DisplayMember = "WarehouseDescription";
        }

        /// <summary>
        /// INit data on to display
        /// </summary>
        private void InitData()
        {
            if (currentUserSelected != null)
            {
                this.txt_M_UserName.Text = this.currentUserSelected.LoginName;
                this.txt_M_Password.Text = this.currentUserSelected.Password;
                this.txt_M_PasswordRep.Text = this.currentUserSelected.Password;
                this.txt_M_CreateBy.Text = this.currentUserSelected.CreatedBy;
                this.txt_M_CreateTime.Text = this.currentUserSelected.CreatedTime.ToString();
                this.txt_M_DeviceNumber.Text = this.currentUserSelected.DeviceNumber;
                this.chk_M_IsActive.Checked = (bool)(this.currentUserSelected.UserActive == null ? false : this.currentUserSelected.UserActive);
                this.chk_M_IsAllowEDI.Checked = (bool)this.currentUserSelected.IsAllowEDI;
                this.chk_M_IsAllowOutsite.Checked = (bool)(this.currentUserSelected.IsAllowOutside == null ? false : this.currentUserSelected.IsAllowOutside);
                this.chk_M_IsOnline.Checked = (bool)(this.currentUserSelected.IsOnline == null ? false : this.currentUserSelected.IsOnline);
                this.lke_M_StoreList.EditValue = this.currentUserSelected.StoreID;
                this.lke_M_EmployeeList.EditValue = this.currentUserSelected.EmployeeID;
                this.lke_M_WarehouseList.EditValue = this.currentUserSelected.WarehouseID;
            }
            else
            {
                // Clear data
                this.txt_M_UserName.Text = string.Empty;
                this.txt_M_Password.Text = string.Empty;
                this.txt_M_PasswordRep.Text = string.Empty;
                this.txt_M_CreateBy.Text = AppSetting.CurrentUser.LoginName;
                this.txt_M_CreateTime.Text = DateTime.Now.ToShortDateString();
                this.txt_M_DeviceNumber.Text = string.Empty;
                this.chk_M_IsActive.Checked = false;
                this.chk_M_IsAllowEDI.Checked = false;
                this.chk_M_IsAllowOutsite.Checked = false;
                this.chk_M_IsOnline.Checked = false;

                this.lke_M_StoreList.EditValue = null;
                this.lke_M_StoreList.EditValue = null;
                this.lke_M_WarehouseList.EditValue = null;
            }
        }

        private void GetDataInfo()
        {
            if (currentUserSelected == null)
                currentUserSelected = new UserAccount();
            this.currentUserSelected.LoginName = this.txt_M_UserName.Text;
            this.currentUserSelected.CreatedBy = this.txt_M_CreateBy.Text;
            this.currentUserSelected.CreatedTime = string.IsNullOrEmpty(this.txt_M_CreateTime.Text) ? DateTime.Now : Convert.ToDateTime(this.txt_M_CreateTime.Text);
            this.currentUserSelected.DeviceNumber = this.txt_M_DeviceNumber.Text;
            this.currentUserSelected.UserActive = this.chk_M_IsActive.Checked;
            this.currentUserSelected.IsAllowEDI = this.chk_M_IsAllowEDI.Checked;
            this.currentUserSelected.IsAllowOutside = this.chk_M_IsAllowOutsite.Checked;
            this.currentUserSelected.IsOnline = this.chk_M_IsOnline.Checked;
            this.currentUserSelected.VietnamName = this.lke_M_EmployeeList.Text;
            if (this.currentUserSelected.Password == null || this.currentUserSelected.Password != this.txt_M_Password.Text)
            {
                this.currentUserSelected.Password = this.txt_M_Password.Text;
            }

            if (this.lke_M_WarehouseList.EditValue != null)
            {
                this.currentUserSelected.WarehouseID = Convert.ToByte(this.lke_M_WarehouseList.EditValue);
            }

            if (this.lke_M_StoreList.EditValue != null)
            {
                this.currentUserSelected.WarehouseID = Convert.ToByte(this.lke_M_StoreList.EditValue);
            }

            if (this.lke_M_StoreList.EditValue != null)
            {
                this.currentUserSelected.StoreID = (int)this.lke_M_StoreList.EditValue;
            }

            if (this.lke_M_EmployeeList.EditValue != null)
            {
                this.currentUserSelected.EmployeeID = (int)this.lke_M_EmployeeList.EditValue;
            }
        }

        private void LoadAllApplication()
        {
            DataProcess<UserApplicationDefinition> applicationDA = new DataProcess<UserApplicationDefinition>();
            this.applicationDefinitionList = new BindingList<UserApplicationDefinition>(applicationDA.Select().ToList());
            this.grd_M_ApplicationsList.DataSource = this.applicationDefinitionList;
        }

        /// <summary>
        /// Change filter data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radgFilter_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            RadioGroup edit = sender as RadioGroup;
            IEnumerable<ST_WMS_LoadUserAccount_Result> listFilter = null;
            switch (edit.SelectedIndex)
            {
                case 0:
                    this.grd_M_UserList.DataSource = this.listUserAccounts;
                    break;
                case 1:
                    listFilter = this.listUserAccounts.Where(u => u.UserActive == true);
                    this.grd_M_UserList.DataSource = listFilter;
                    break;
                case 2:
                    listFilter = this.listUserAccounts.Where(u => u.UserActive == false);
                    this.grd_M_UserList.DataSource = listFilter;
                    break;
                default:
                    break;
            }
        }

        private void btn_M_Save_Click(object sender, System.EventArgs e)
        {
            bool hasChangeStore = false;
            if (this.lke_M_StoreList.EditValue != null && AppSetting.CurrentUser.LoginName.Equals(this.currentUserSelected.LoginName))
            {
                int newStoreID = (int)this.lke_M_StoreList.EditValue;
                if (AppSetting.StoreID != newStoreID)
                {
                    hasChangeStore = true;
                }
            }
            if (hasChangeStore)
            {
                //Check forms has open
                if (Application.OpenForms.Count > 2)
                {
                    var dl = MessageBox.Show("The system has detected you are working on some a screen.\nDo you want save it before change store?", "TPWMS",
                          MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dl == DialogResult.Yes) return;
                    this.CloseAllFormHasOpened();
                }
            }

            DataProcess<UserAccount> userAccountDA = new DataProcess<UserAccount>();
            bool result = false;

            var accountLookup = userAccountDA.Select(u => u.LoginName == this.currentUserSelected.LoginName);
            this.GetDataInfo();
            if (accountLookup != null && accountLookup.Count() > 0)
            {
                // Update account was exist

                result = this.UpdateAccount();
            }
            else
            {
                // Insert new account
                result = this.InsertAccount();
            }

            if (result)
            {
                //MessageBox.Show("Successful", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.LoadUserAccounts();
                if (hasChangeStore)
                {
                    frmMain.Instance.RefreshLocalData();
                }
            }
        }

        private void btn_M_Edit_Click(object sender, System.EventArgs e)
        {
            if (this.btn_M_Edit.Text.Trim().Equals("Edit"))
            {
                // Edit data
                this.btn_M_Edit.Text = "Update";
                this.ActiveControl(false);
            }
            else
            {
                this.btn_M_Edit.Text = "Edit";
                this.ActiveControl(true);

                // Update account info
                this.GetDataInfo();
                bool result = this.UpdateAccount();
                if (result)
                {
                    MessageBox.Show("Successful", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.LoadUserAccounts();
                }
            }
        }

        private void btn_M_Delete_Click(object sender, System.EventArgs e)
        {
            // Update account info
            DataProcess<UserAccount> userAccountDA = new DataProcess<UserAccount>();
            int result = userAccountDA.ExecuteNoQuery("Delete UserAccounts where EmployeeID=" + this.currentUserSelected.EmployeeID);
            if (result > 0)
            {
                MessageBox.Show("Successful", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.LoadUserAccounts();
            }
        }

        private void btn_M_Lock_Click(object sender, System.EventArgs e)
        {
            // Update account info
            DataProcess<UserAccount> userAccountDA = new DataProcess<UserAccount>();
            this.currentUserSelected.UserActive = false;
            int result = userAccountDA.Update(this.currentUserSelected);
            if (result > 0)
            {
                MessageBox.Show("Successful", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.LoadUserAccounts();
            }
        }

        private void btn_M_Clear_Click(object sender, System.EventArgs e)
        {
            this.ActiveControl(false);
            this.txt_M_UserName.Text = string.Empty;
            this.txt_M_Password.Text = string.Empty;
            this.txt_M_PasswordRep.Text = string.Empty;
            this.txt_M_CreateBy.Text = AppSetting.CurrentUser.LoginName;
            this.txt_M_CreateTime.Text = DateTime.Now.ToString();
            this.txt_M_DeviceNumber.Text = string.Empty;
            this.chk_M_IsActive.Checked = true;
            this.chk_M_IsAllowEDI.Checked = true;
            this.chk_M_IsAllowOutsite.Checked = true;
            this.chk_M_IsOnline.Checked = true;
            this.lke_M_Department.EditValue = null;
            this.lke_M_StoreList.EditValue = null;
            this.lke_M_WarehouseList.EditValue = null;
            this.lke_M_EmployeeList.EditValue = null;
            this.lke_M_EmployeeList.ShowPopup();
            this.lke_M_EmployeeList.Focus();
        }

        /// <summary>
        /// Set active control 
        /// </summary>
        /// <param name="isActive"></param>
        private void ActiveControl(bool isActive)
        {
            this.txt_M_Password.ReadOnly = isActive;
            this.txt_M_PasswordRep.ReadOnly = isActive;
            this.txt_M_DeviceNumber.ReadOnly = isActive;

            this.chk_M_IsActive.ReadOnly = isActive;
            this.chk_M_IsAllowEDI.ReadOnly = isActive;
            this.chk_M_IsAllowOutsite.ReadOnly = isActive;
            this.chk_M_IsOnline.ReadOnly = isActive;

            this.lke_M_Department.ReadOnly = isActive;
            this.lke_M_StoreList.ReadOnly = isActive;
            this.lke_M_WarehouseList.ReadOnly = isActive;
            this.lke_M_EmployeeList.ReadOnly = isActive;

            if (this.currentUserSelected != null && !isActive)
            {
                this.grv_M_ApplicationList.OptionsBehavior.ReadOnly = isActive;
                this.grv_M_RoleList.OptionsBehavior.ReadOnly = isActive;
            }


            this.btn_M_Save.Enabled = !isActive;
            this.btn_M_Edit.Enabled = isActive;
            this.btn_M_Lock.Enabled = isActive;
            this.btn_M_Delete.Enabled = isActive;

            if (this.currentUserSelected == null)
            {
                this.txt_M_UserName.ReadOnly = isActive;
            }
            else
            {
                if (string.IsNullOrEmpty(this.currentUserSelected.LoginName))
                {
                    this.txt_M_UserName.ReadOnly = isActive;
                }
                else
                {
                    this.txt_M_UserName.ReadOnly = true;
                }
            }
        }


        /// <summary>
        /// Lookup login name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_M_SearchUser_Click(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(radgFilter.EditValue))
            {
                case 1:
                    var listLookup = this.listUserAccounts.Where(u => u.LoginName.ToUpper().Contains(this.txt_M_SearchUserName.Text.ToUpper()));
                    this.grd_M_UserList.DataSource = listLookup;
                    break;
                case 2:
                    var listLookup2 = this.listUserAccounts.Where(u => u.LoginName.ToUpper().Contains(this.txt_M_SearchUserName.Text.ToUpper()) && u.UserActive == true);
                    this.grd_M_UserList.DataSource = listLookup2;
                    break;
                case 3:
                    var listLookup3 = this.listUserAccounts.Where(u => u.LoginName.ToUpper().Contains(this.txt_M_SearchUserName.Text.ToUpper()) && u.UserActive == false);
                    this.grd_M_UserList.DataSource = listLookup3;
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Load application by user
        /// </summary>
        private void LoadApplicationByUser(string loginName)
        {
            if (this.applicationDefinitionList == null) return;
            DataProcess<ST_WMS_LoadApplicationByUser_Result> applicationDA = new DataProcess<ST_WMS_LoadApplicationByUser_Result>();
            this.userApplicationList = applicationDA.Executing("ST_WMS_LoadApplicationByUser @LoginName={0},@ApplicationName={1}", loginName, Application.ProductName);
            foreach (var application in this.applicationDefinitionList)
            {
                application.IsSelected = false;
                if (this.userApplicationList.Where(a => a.ApplicationId == application.ApplicationId).Count() > 0)
                {
                    application.IsSelected = true;
                }
            }

            this.grv_M_ApplicationList.RefreshData();
        }

        private void LoadAllRoleList()
        {
            DataProcess<ST_WMS_LoadAllUserRole_Result> userRoleDA = new DataProcess<ST_WMS_LoadAllUserRole_Result>();
            this.roleDefinitionList = new BindingList<ST_WMS_LoadAllUserRole_Result>(userRoleDA.Executing("ST_WMS_LoadAllUserRole").ToList());
            this.grd_M_RoleList.DataSource = this.roleDefinitionList;
        }

        private void grv_M_ApplicationList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0) return;
            if (this.userApplicationList == null) return;
            int applicationID = (int)this.grv_M_ApplicationList.GetRowCellValue(e.FocusedRowHandle, "ApplicationId");
            this.userApplicationSelected = this.userApplicationList.Where(u => u.ApplicationId == applicationID).FirstOrDefault();

            // Load all Application role by ApplicationID
            this.LoadAllApplicationRoleByUser();

            // Set caption edit button
            this.btn_M_Edit.Text = "Edit";
        }

        private void LoadAllApplicationRoleByUser()
        {
            if (this.userApplicationSelected == null)
            {
                foreach (var role in this.roleDefinitionList)
                {
                    role.IsSelected = false;
                }
            }
            else
            {
                DataProcess<UserApplicationRole> userApplicationRoleDA = new DataProcess<UserApplicationRole>();
                this.userApplicationRoleList = userApplicationRoleDA.Select(r => r.UserApplicationId == this.userApplicationSelected.UserApplicationId);
                foreach (var role in this.roleDefinitionList)
                {
                    role.IsSelected = false;
                    if (this.userApplicationRoleList.Where(a => a.RoleId == role.RoleId).Count() > 0)
                    {
                        role.IsSelected = true;
                    }
                }
            }

            this.grv_M_RoleList.RefreshData();
        }

        private void grv_M_RoleList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            // Set caption edit button
            this.btn_M_Edit.Text = "Edit";
        }

        private void btn_M_RoleDefinition_Click(object sender, EventArgs e)
        {
            frm_M_RoleDefinition roleForm = new frm_M_RoleDefinition();
            roleForm.Show();
        }

        /// <summary>
        /// Insert new account
        /// </summary>
        /// <returns></returns>
        private bool InsertAccount()
        {
            DataProcess<UserAccount> userAccountDA = new DataProcess<UserAccount>();
            bool IsAllowOutside = Convert.ToBoolean(this.currentUserSelected.IsAllowOutside == true ? 1 : 0);
            bool IsAllowEDI = Convert.ToBoolean(this.currentUserSelected.IsAllowEDI == true ? 1 : 0);
            System.Data.Entity.Core.Objects.ObjectParameter returnStatus = new System.Data.Entity.Core.Objects.ObjectParameter("returnStatus", "");
            int resultInsert = STAndroid_Login_Register(currentUserSelected.LoginName, currentUserSelected.Password, txt_M_PasswordRep.Text, (byte)currentUserSelected.WarehouseID,
                IsAllowOutside, AppSetting.CurrentUser.LoginName, returnStatus, currentUserSelected.StoreID, currentUserSelected.DeviceNumber, IsAllowEDI, Convert.ToInt32(lke_M_EmployeeList.EditValue));
            string resultStatus = returnStatus.Value.ToString();
            if (resultInsert > 0)
            {
                MessageBox.Show(resultStatus);
                return true;
            }
            else
            {
                MessageBox.Show(resultStatus);
                return false;
            }
        }

        /// <summary>
        /// Update account was exist
        /// </summary>
        /// <returns></returns>
        private bool UpdateAccount()
        {
            DataProcess<UserAccount> userAccountDA = new DataProcess<UserAccount>();
            int isIsAllowChangeStore = 0;
            string vietNamName = this.currentUserSelected.VietnamName, newPassword, LoginName, DeviceNumber = "";
            int employeesID, WarehouseID = 0;
            bool result = false;
            DataTable dt = FileProcess.LoadTable("select top 1 * from UserAccounts where LoginName='" + this.currentUserSelected.LoginName + "'");
            if (dt.Rows.Count > 0)
            {
                isIsAllowChangeStore = Convert.ToBoolean(dt.Rows[0]["IsAllowChangeStore"]) == true ? 1 : 0;
                vietNamName = dt.Rows[0]["VietnamName"].ToString();

            }
            employeesID = Convert.ToInt32(dt.Rows[0]["EmployeeID"]);
            //newPassword = "HashBytes('SHA1', '" + this.txt_M_Password.Text.Trim() + "')";
            newPassword = this.txt_M_Password.Text.Trim();
            LoginName = this.currentUserSelected.LoginName;
            DeviceNumber = this.currentUserSelected.DeviceNumber;

            int IsAllowEDI = this.currentUserSelected.IsAllowEDI == true ? 1 : 0;
            int UserActive = this.currentUserSelected.UserActive == true ? 1 : 0;
            int StoreID = this.currentUserSelected.StoreID;
            if (dt.Rows[0]["WarehouseID"] != null && dt.Rows[0]["WarehouseID"].ToString() != "")
                WarehouseID = Convert.ToInt32(dt.Rows[0]["WarehouseID"]);
            int IsAllowOutside = this.currentUserSelected.IsAllowOutside == true ? 1 : 0;

            if (this.txt_M_Password.Text.Trim().Equals(dt.Rows[0]["password"].ToString()))
            {
                // Update other values not update password
                DataProcess<object> updateNoPass = new DataProcess<object>();
                var haha = updateNoPass.ExecuteNoQuery("UPDATE UserAccounts " +
                                                      " SET IsAllowEDI =" + IsAllowEDI +
                                                         " ,UserActive =" + UserActive +
                                                         " ,StoreID = " + StoreID +
                                                         " ,WarehouseID =" + (byte)lke_M_WarehouseList.EditValue +
                                                         " ,DeviceNumber ='" + DeviceNumber + "'" +
                                                         " ,IsAllowOutside =" + IsAllowOutside +
                                                         " ,IsAllowChangeStore =" + isIsAllowChangeStore +
                                                         " ,VietnamName ='" + vietNamName + "'" +
                                                         " ,EmployeeID =" + employeesID +
                                                   "  WHERE LoginName ='" + LoginName + "'");
                if (haha > 0)
                {
                    MessageBox.Show("Update thành công!");
                    result = true;
                }
                else
                {
                    MessageBox.Show("Update không thành công");
                }
            }
            else
            {
                // Update all values
                System.Data.Entity.Core.Objects.ObjectParameter ResultReturn = new System.Data.Entity.Core.Objects.ObjectParameter("ResultReturn", "");
                int resultInsert = STUserAccountUpdate(ResultReturn, LoginName, Convert.ToBoolean(IsAllowEDI), Convert.ToBoolean(UserActive),
                    StoreID, (byte)lke_M_WarehouseList.EditValue, DeviceNumber, Convert.ToBoolean(IsAllowOutside),
                    Convert.ToBoolean(isIsAllowChangeStore), vietNamName, employeesID, newPassword);
                string returnResultReturn = ResultReturn.Value.ToString();
                if (resultInsert > 0)
                {
                    MessageBox.Show(returnResultReturn);
                    result = true;
                }
                else
                {
                    MessageBox.Show(returnResultReturn);
                }
            }
            return result;
        }

        public int STUserAccountUpdate(System.Data.Entity.Core.Objects.ObjectParameter ResultReturn, string UserName, bool IsAllowEDI, bool UserActive, int StoreID,
                                        int WarehouseID, string DeviceNumber, bool IsAllowOutside, bool IsAllowChangeStore, string VietnamName, int EmployeeID, string NewPassword)
        {
            using (var context = new SwireDBEntities())
            {
                return context.STUserAccountUpdate(ResultReturn, UserName, IsAllowEDI, UserActive,
            StoreID, (byte)WarehouseID, DeviceNumber, IsAllowOutside, IsAllowChangeStore, VietnamName, EmployeeID, NewPassword);
            }
        }
        public int STAndroid_Login_Register(string newUserName, string newPassword, string newPasswordConfirm, int WarehouseID, bool IsAllowOutside, string UserName,
           System.Data.Entity.Core.Objects.ObjectParameter returnStatus, int StoreID, string DeviceNumber, bool IsAllowEDI, int EmployeeID)
        {
            using (var context = new SwireDBEntities())
            {
                return context.STAndroid_Login_Register(newUserName, newPassword, newPasswordConfirm, WarehouseID,
            IsAllowOutside, UserName, returnStatus, StoreID, DeviceNumber, IsAllowEDI, EmployeeID);
            }
        }
        private void txt_M_SearchUserName_Enter(object sender, EventArgs e)
        {
            this.btn_M_SearchUser_Click(sender, e);
        }

        private void rpi_chk_ApplicationIsSelected_CheckStateChanged(object sender, EventArgs e)
        {
            DataProcess<UserApplication> userApplicationDA = new DataProcess<UserApplication>();
            int applicationID = (int)this.grv_M_ApplicationList.GetRowCellValue(this.grv_M_ApplicationList.FocusedRowHandle, "ApplicationId");

            var countApplication = this.userApplicationList.Where(a => a.ApplicationId == applicationID).ToList();
            int result = -1;

            if (countApplication.Count() <= 0)
            {
                // Add user application
                UserApplication newApplication = new UserApplication();
                newApplication.ApplicationId = (byte)applicationID;
                newApplication.CreateDate = DateTime.Now;
                newApplication.CreatedBy = AppSetting.CurrentUser.LoginName;
                newApplication.CreatedTime = DateTime.Now;
                newApplication.UserId = this.currentUserSelected.LoginName;
                var result2 = FileProcess.LoadTable("insert into ZZZ_WMS_Users(UserId, EmployeeID, Password, CreatedTime) values('"
                    + this.currentUserSelected.LoginName + "', '" + currentUserSelected.EmployeeID + "', '" + currentUserSelected.Password + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')");
                result = userApplicationDA.Insert(newApplication);
                this.LoadApplicationByUser(this.currentUserSelected.LoginName);
                this.userApplicationSelected = this.userApplicationList.Where(u => u.ApplicationId == applicationID).FirstOrDefault();
                this.LoadAllApplicationRoleByUser();
            }
            else
            {
                // Delete user application
                int resultDeleteRole = userApplicationDA.ExecuteNoQuery("delete UserApplicationRoles where UserApplicationId=" + countApplication.FirstOrDefault().UserApplicationId);
                result = userApplicationDA.ExecuteNoQuery("Delete UserApplications where UserApplicationID=" + countApplication.FirstOrDefault().UserApplicationId);
            }
        }

        private void rpi_chk_RoleIsSelected_CheckStateChanged(object sender, EventArgs e)
        {
            if (this.userApplicationRoleList == null) return;
            DataProcess<UserApplicationRole> userApplicationRoleDA = new DataProcess<UserApplicationRole>();
            int roleID = (int)this.grv_M_RoleList.GetRowCellValue(this.grv_M_RoleList.FocusedRowHandle, "RoleId");

            var countRole = this.userApplicationRoleList.Where(r => r.RoleId == roleID).ToList();
            int result = -1;
            if (countRole.Count() <= 0)
            {
                // Add user application role
                UserApplicationRole newRole = new UserApplicationRole();
                newRole.CreatedBy = AppSetting.CurrentUser.LoginName;
                newRole.CreatedTime = DateTime.Now;
                newRole.RoleId = roleID;
                newRole.UserApplicationId = this.userApplicationSelected.UserApplicationId;
                result = userApplicationRoleDA.Insert(newRole);
            }
            else
            {
                // Delete user application role
                result = userApplicationRoleDA.ExecuteNoQuery("Delete UserApplicationRoles where UserApplicationRoleId=" + countRole.FirstOrDefault().UserApplicationRoleId);
            }
        }

        private void txt_M_SearchUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                this.btn_M_SearchUser_Click(sender, e);
            }
        }

        private void txt_M_PasswordRep_Leave(object sender, EventArgs e)
        {
            if (!this.txt_M_Password.Text.Trim().Equals(this.txt_M_PasswordRep.Text.Trim()))
            {
                this.dxErrorProvider1.SetError(this.txt_M_PasswordRep, "Re-password is inconsistency");
                this.txt_M_PasswordRep.SelectAll();
                this.txt_M_PasswordRep.Focus();
            }
            else
                this.dxErrorProvider1.ClearErrors();
        }

        private void grv_M_UserList_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (this.grv_M_UserList.FocusedRowHandle < 0) return;
            string loginNameSelected = Convert.ToString(this.grv_M_UserList.GetRowCellValue(this.grv_M_UserList.FocusedRowHandle, "LoginName"));
            DataProcess<UserAccount> userAccountLookup = new DataProcess<UserAccount>();
            this.currentUserSelected = userAccountLookup.Select(u => u.LoginName == loginNameSelected).FirstOrDefault();

            // Display userAccount info on UI
            this.InitData();

            // Set active control
            this.ActiveControl(true);

            // Load application by user
            this.LoadApplicationByUser(currentUserSelected.LoginName);

            // Load all role list
            this.LoadAllRoleList();

            // Set caption edit button
            this.btn_M_Edit.Text = "Edit";
        }

        private void txt_M_Password_Leave(object sender, EventArgs e)
        {
            if (this.txt_M_Password.Text.Trim().Length < 6)
            {
                this.dxErrorProvider1.SetError(this.txt_M_Password, "The password is at least 6 character");
                this.txt_M_Password.SelectAll();
                this.txt_M_Password.Focus();
            }
            else
                this.dxErrorProvider1.ClearErrors();
        }

        private void lke_M_EmployeeList_Leave(object sender, EventArgs e)
        {
            if (this.lke_M_EmployeeList.EditValue == null)
            {
                this.dxErrorProvider1.SetError(this.lke_M_EmployeeList, "Please select the Employees");
                this.lke_M_EmployeeList.SelectAll();
                this.lke_M_EmployeeList.Focus();
            }
            else
                this.dxErrorProvider1.ClearErrors();
        }

        private void lke_M_StoreList_EditValueChanged(object sender, EventArgs e)
        {
            if (this.lke_M_StoreList.EditValue == null) return;
            DataProcess<Warehouses> dataProcess = new DataProcess<Warehouses>();
            this.lke_M_WarehouseList.Properties.DataSource = dataProcess.Select(w => w.StoreID == (int)this.lke_M_StoreList.EditValue);
            this.lke_M_WarehouseList.Properties.ValueMember = "WarehouseID";
            this.lke_M_WarehouseList.Properties.DisplayMember = "WarehouseDescription";
        }

        private void lke_M_EmployeeList_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            this.lke_M_EmployeeList.EditValue = e.Value;

            //Validate data input
            if (this.lke_M_EmployeeList.EditValue == null) return;

            // Get employeeID
            int employeeID = (int)this.lke_M_EmployeeList.EditValue;

            DataProcess<UserAccount> userAccountLookup = new DataProcess<UserAccount>();
            this.currentUserSelected = userAccountLookup.Select(u => u.EmployeeID == employeeID).FirstOrDefault();

            // Set data on controls
            this.InitData();

            // Set active control
            if (this.currentUserSelected == null)
            {
                this.currentUserSelected = new UserAccount();
                this.currentUserSelected.CreatedBy = AppSetting.CurrentUser.LoginName;
                this.currentUserSelected.CreatedTime = DateTime.Now;
                this.txt_M_UserName.ReadOnly = false;
            }
            else
            {
                if (string.IsNullOrEmpty(this.currentUserSelected.LoginName))
                {
                    this.txt_M_UserName.ReadOnly = false;
                }
                else
                {
                    this.txt_M_UserName.ReadOnly = true;
                }
            }
        }

        private void lke_M_EmployeeList_EditValueChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Close all form has opended extend main, change store form
        /// </summary>
        /// <returns></returns>
        private void CloseAllFormHasOpened()
        {
            FormCollection fc = Application.OpenForms;
            IList<Form> openForms = new List<Form>();
            foreach (Form frm in fc)
            {
                if (frm.Name != "frm_M_UserAccount" && frm.Name != "frmMain")
                    openForms.Add(frm);
            }
            foreach (var frm in openForms)
            {
                frm.Close();
            }
        }
    }
}
