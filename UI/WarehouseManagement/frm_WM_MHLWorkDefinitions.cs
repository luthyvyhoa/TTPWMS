using Common.Controls;
using DA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Helper;
using DevExpress.XtraEditors;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_MHLWorkDefinitions : frmBaseForm
    {
        private int WorkDefinitionID = 0;
        private BindingList<ST_WMS_LoadWorkDefinitionWithCustomer_Result> dataSource = null;
        private DataProcess<ST_WMS_LoadWorkDefinitionWithCustomer_Result> mhlWorkCustomerServiveDataProcess = new DataProcess<ST_WMS_LoadWorkDefinitionWithCustomer_Result>();
        private DataProcess<STMHLWorkComboMonth_Result> mhlWorkComboMothDataProcess = new DataProcess<STMHLWorkComboMonth_Result>();
        private DataProcess<MHLWorkDefinitions> mhlWorkDataProcess = new DataProcess<MHLWorkDefinitions>();
        private const string EMPTY_STRING = "";
        private bool isEditing = false;
        private frm_WM_MHLWorkDefinitionList frmWorkDifinitionList = null;
        private ST_WMS_LoadWorkDefinitionWithCustomer_Result currentItem = null;
        public frm_WM_MHLWorkDefinitions(int WorkDefinition)
        {
            InitializeComponent();

            initData(WorkDefinition);
            this.layoutControlItemUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            this.layoutControlSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

        }

        public void initData(int workDefinitionID)
        {
            try
            {
                this.WorkDefinitionID = workDefinitionID;
                IList<ST_WMS_LoadWorkDefinitionWithCustomer_Result> sourceList = null;
                if (workDefinitionID <= 0)
                {
                    sourceList = mhlWorkCustomerServiveDataProcess.Executing("ST_WMS_LoadWorkDefinitionWithCustomer").ToList();


                }
                else
                {
                    sourceList = mhlWorkCustomerServiveDataProcess.Executing("ST_WMS_LoadWorkDefinitionWithCustomer").Where(w => w.MHLWorkDefinitionID == this.WorkDefinitionID).ToList();
                }
                this.dataSource = new BindingList<ST_WMS_LoadWorkDefinitionWithCustomer_Result>(sourceList.ToList());
                this.dtNavigatorWorks.DataSource = dataSource;
                //this.dtNavigatorWorks.
                this.dtNavigatorWorks.Position = dataSource.Count - 1;

                ST_WMS_LoadWorkDefinitionWithCustomer_Result item = this.dataSource[this.dtNavigatorWorks.Position];
                currentItem = item;

                // Set value for textbox
                txtMHLWorkDefinitionID.Text = item.MHLWorkDefinitionID.ToString();
                this.textWorkDefinitionRemark.Text = item.MHLWorkDefinitionRemark;
                this.WorkDefinitionID = item.MHLWorkDefinitionID;
                if (item.MHLWorkDefinitionNumber != null)
                {
                    txtMHLWorkDefinitionNumber.Text = item.MHLWorkDefinitionNumber.ToString();
                }
                else { txtMHLWorkDefinitionNumber.Text = ""; }

                if (item.JobName != null)
                {
                    txtJobName.Text = item.JobName.ToString();
                }
                else { txtJobName.Text = ""; }

                if (item.UnitPrice != null)
                {
                    txtUnitPrice.Text = string.Format("{0:n0}", item.UnitPrice);
                }
                else { txtUnitPrice.Text = ""; }

                if (item.Unit != null)
                {
                    txtUnit.Text = item.Unit.ToString();
                }
                else { txtUnit.Text = ""; }

                if (item.UpdatedBy != null)
                {
                    txtUpdatedBy.Text = item.UpdatedBy.ToString();
                }
                else { txtUpdatedBy.Text = ""; }

                if (item.CustomerName != null)
                {
                    txtCustomerName.Text = item.CustomerName.ToString();
                }
                else { txtCustomerName.Text = ""; }

                if (item.ServiceNumber != null)
                {
                    txtServiceNumber.Text = item.ServiceNumber.ToString();
                }
                else { txtServiceNumber.Text = ""; }

                if (item.ServiceName != null)
                {
                    txtServiceName.Text = item.ServiceName.ToString();
                }
                else { txtServiceName.Text = ""; }

                if (item.Description != null)
                {
                    txtDescription.Text = item.Description.ToString();
                }
                else { txtDescription.Text = ""; }

                if (item.MHLWorkDefinitionRemark != null)
                {
                    textWorkDefinitionRemark.Text = item.MHLWorkDefinitionRemark.ToString();
                }
                else { textWorkDefinitionRemark.Text = ""; }

                chkDiscontinued.Checked = (bool)item.Discontinued;
                // Set data for combobox

                // FIXME group by & order by
                IList<Customers> list = AppSetting.CustomerList.Where(c => c.CustomerDiscontinued == false && c.CustomerMainID == c.CustomerID).ToList();
                lkeCustomerMainID.Properties.DataSource = list;
                lkeCustomerMainID.Properties.DisplayMember = "CustomerNumber";
                lkeCustomerMainID.Properties.ValueMember = "CustomerID";
                try
                {
                    lkeCustomerMainID.EditValue = (int)item.CustomerMainID;
                }
                catch
                {
                    lkeCustomerMainID.EditValue = 0;
                }
                lkeCustomerMainID.Focus();
            }
            catch
            {

            }

        }

        private void btnCmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private MHLWorkDefinitions acCmdSaveRecord(MHLWorkDefinitions obj)
        {
            obj.MHLWorkDefinitionRemark = textWorkDefinitionRemark.Text;
            try
            {
                obj.MHLWorkDefinitionNumber = txtMHLWorkDefinitionNumber.Text;
            }
            catch {
            }
            obj.JobName = txtJobName.Text;
            obj.Description = txtDescription.Text;

            float floatNumber;
            bool isFloat = float.TryParse(txtUnitPrice.Text, out floatNumber);
            if (isFloat)
            {
                obj.UnitPrice = float.Parse(txtUnitPrice.Text, CultureInfo.InvariantCulture);
            }

            obj.Unit = txtUnit.Text;
            int integerNumber;
            bool isInteger = int.TryParse(lkeCustomerMainID.EditValue.ToString(), out integerNumber);
            if (isInteger)
            {
                obj.CustomerMainID = Int32.Parse(lkeCustomerMainID.EditValue.ToString());
            }
            obj.Discontinued = chkDiscontinued.Checked;
            //obj.CreatedTime = DateTime.Now;
            obj.UpdatedBy = AppSetting.CurrentUser.LoginName;            
            return obj;
        }
        private void btncmdUpdate_Click(object sender, EventArgs e)
        {
            updateWork();
            btnCmdClose.Focus();
            Enable_DisableColor(false);
            //this.WorkDefinitionID = 0;
            this.initData(this.WorkDefinitionID);
            // FIXME
            // Me.txtUpdatedBy = CurrentUser() & " - " & Format(Now(), "dd/mm/yy hh:nn") & ""
            this.layoutControlItemUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            this.layoutControlSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            this.layoutControlItemEdit.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
        }
        private void btnCmdEdit_Click(object sender, EventArgs e)
        {
            btnCmdClose.Focus();
            Enable_DisableColor(true);
            btncmdUpdate.Enabled = true;
            isEditing = true;

            this.layoutControlItemUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            this.layoutControlSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            newWork();
            btnCmdClose.Focus();
            Enable_DisableColor(false);
            // After to create a new work successfully, back to information of current item
            initData(this.WorkDefinitionID);
            btnSave.Enabled = false;
            this.layoutControlItemUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            this.layoutControlSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            this.layoutControlItemEdit.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
        }
        private void Enable_DisableColor(bool enabled)
        {
            if (enabled)
            {
                txtMHLWorkDefinitionNumber.ReadOnly = false;
                txtJobName.ReadOnly = false;
                txtDescription.ReadOnly = false;
                txtUnitPrice.ReadOnly = false;
                txtUnit.ReadOnly = false;
                lkeCustomerMainID.ReadOnly = false;
                chkDiscontinued.ReadOnly = false;
            }
            else
            {
                txtMHLWorkDefinitionNumber.ReadOnly = true;
                txtJobName.ReadOnly = true;
                txtDescription.ReadOnly = true;
                txtUnitPrice.ReadOnly = true;
                txtUnit.ReadOnly = true;
                lkeCustomerMainID.ReadOnly = true;
                chkDiscontinued.ReadOnly = true;
            }
        }

        private void emptyAllControl()
        {
            txtMHLWorkDefinitionNumber.Text = EMPTY_STRING;
            txtJobName.Text = EMPTY_STRING;
            txtDescription.Text = EMPTY_STRING;
            txtUnitPrice.Text = EMPTY_STRING;
            txtUnit.Text = EMPTY_STRING;
            //lkeCustomerMainID.EditValue = currentItem.CustomerMainID.ToString();
            lkeCustomerMainID.Focus();
            chkDiscontinued.Checked = false;
        }

        private void btnCommandViewList_Click(object sender, EventArgs e)
        {
            // Work list is available
            if (this.frmWorkDifinitionList == null)
            {
                this.frmWorkDifinitionList = new frm_WM_MHLWorkDefinitionList();
            }
            this.frmWorkDifinitionList.ShowDialog();
        }

        private void btnCommandUpdatetoOrder_Click(object sender, EventArgs e)
        {
            if (layoutControlItem1.ContentVisible == false)
            {
                layoutControlItem1.ContentVisible = true;
                lkeMHLWorkMonth.Properties.DataSource = mhlWorkComboMothDataProcess.Executing("STMHLWorkComboMonth @MHLWorkDefinitionID = {0}", txtMHLWorkDefinitionID.Text).ToList();
                lkeMHLWorkMonth.Focus();
                lkeMHLWorkMonth.ShowPopup();
            }
            else if (lkeMHLWorkMonth.Text == "" || lkeMHLWorkMonth.Text == null)
            {
                lkeMHLWorkMonth.Focus();
                lkeMHLWorkMonth.ShowPopup();
                return;
            }
            else
            {
                // Execute STMHLWorkUnitPriceUpdate
                int varMessageOut = mhlWorkDataProcess.ExecuteNoQuery("STMHLWorkUnitPriceUpdate @PayRollMonthID = {0}, @UnitPrice = {1}, @MHLWorkDefinitionID = {2}", lkeMHLWorkMonth.Text, txtUnitPrice.Text, txtMHLWorkDefinitionID.Text);
                if (varMessageOut > 0)
                {
                    MessageBox.Show("Ban da update thanh cong !", "Admin-2012",
                         MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ban phai nha confirm tat ca cac phieu cua cong viec nay trong thang nay !", "Admin-2012",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCmdDelete_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Are you sure to delete Work?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            //Phan quyen Nhan su moi duoc edit
            var levelDepartmentTb = FileProcess.LoadTable("SELECT count(UserRoleDefinitions.LevelDepartment) as LevelDepartment" +
            " FROM UserAccounts INNER JOIN" +
                         " UserApplications ON UserAccounts.LoginName = UserApplications.UserId INNER JOIN" +
                         " UserApplicationRoles ON UserApplications.UserApplicationId = UserApplicationRoles.UserApplicationId INNER JOIN" +
                         " UserRoleDefinitions ON UserApplicationRoles.RoleId = UserRoleDefinitions.RoleId" +
                         " WHERE UserDepartmentDefinitionID = 7 and UserAccounts.LoginName = '" + AppSetting.CurrentUser.LoginName + "'");


            int levelDepartment = Convert.ToInt32(levelDepartmentTb.Rows[0]["LevelDepartment"].ToString());
            if (levelDepartment == 0)
            {
                MessageBox.Show("Permission denied!", "WMS_2017", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.WorkDefinitionID <= 0) return;
            MHLWorkDefinitions deleteObject = mhlWorkDataProcess.Select(w => w.MHLWorkDefinitionID == this.WorkDefinitionID).FirstOrDefault();
            int result = mhlWorkDataProcess.Delete(deleteObject);
            if (result <= 0)
            {
                MessageBox.Show("Cannot delete this work !", "Admin-2012",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.WorkDefinitionID = 0;
            this.initData(this.WorkDefinitionID);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            btnCmdClose.Focus();
            Enable_DisableColor(true);
            // Set empty value for all controls to enter information
            newWork();
            //this.initData(this.WorkDefinitionID+1);
            //emptyAllControl();
            this.Close();
            //btnSave.Enabled = true;
        }



        private void newWork()
        {
            MHLWorkDefinitions newObject = acCmdSaveRecord(new MHLWorkDefinitions());
            newObject.CreatedTime = DateTime.Now;
            newObject.MHLWorkDefinitionNumber = "NEW-WORK";
            int result = mhlWorkDataProcess.Insert(newObject);
            if (result > 0)
            {
                MessageBox.Show("Insert new work successfully !", "Admin-2012",
                         MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cannot insert new work !", "Admin-2012",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateWork()
        {
            MHLWorkDefinitions oldUpdateObject = mhlWorkDataProcess.Select(w => w.MHLWorkDefinitionID == this.WorkDefinitionID).FirstOrDefault();
            MHLWorkDefinitions newUpdateObject = acCmdSaveRecord(oldUpdateObject);
            mhlWorkDataProcess.Update(newUpdateObject);
            this.dataSource[this.dtNavigatorWorks.Position].MHLWorkDefinitionRemark = newUpdateObject.MHLWorkDefinitionRemark;
        }

        private void frm_WM_MHLWorkDefinitions_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void dtNavigatorWorks_PositionChanged(object sender, EventArgs e)
        {

            ST_WMS_LoadWorkDefinitionWithCustomer_Result item = this.dataSource[this.dtNavigatorWorks.Position];
            currentItem = item;

            // Set value for textbox
            txtMHLWorkDefinitionID.Text = item.MHLWorkDefinitionID.ToString();
            this.textWorkDefinitionRemark.Text = item.MHLWorkDefinitionRemark;
            this.WorkDefinitionID = item.MHLWorkDefinitionID;
            if (item.MHLWorkDefinitionNumber != null)
            {
                txtMHLWorkDefinitionNumber.Text = item.MHLWorkDefinitionNumber.ToString();
            }
            else { txtMHLWorkDefinitionNumber.Text = ""; }

            if (item.JobName != null)
            {
                txtJobName.Text = item.JobName.ToString();
            }
            else { txtJobName.Text = ""; }

            if (item.UnitPrice != null)
            {
                txtUnitPrice.Text = string.Format("{0:n0}", item.UnitPrice);
            }
            else { txtUnitPrice.Text = ""; }

            if (item.Unit != null)
            {
                txtUnit.Text = item.Unit.ToString();
            }
            else { txtUnit.Text = ""; }

            if (item.UpdatedBy != null)
            {
                txtUpdatedBy.Text = item.UpdatedBy.ToString();
            }
            else { txtUpdatedBy.Text = ""; }

            if (item.CustomerName != null)
            {
                txtCustomerName.Text = item.CustomerName.ToString();
            }
            else { txtCustomerName.Text = ""; }

            if (item.ServiceNumber != null)
            {
                txtServiceNumber.Text = item.ServiceNumber.ToString();
            }
            else { txtServiceNumber.Text = ""; }

            if (item.ServiceName != null)
            {
                txtServiceName.Text = item.ServiceName.ToString();
            }
            else { txtServiceName.Text = ""; }

            if (item.Description != null)
            {
                txtDescription.Text = item.Description.ToString();
            }
            else { txtDescription.Text = ""; }

            if (item.MHLWorkDefinitionRemark != null)
            {
                textWorkDefinitionRemark.Text = item.MHLWorkDefinitionRemark.ToString();
            }
            else { textWorkDefinitionRemark.Text = ""; }

            chkDiscontinued.Checked = (bool)item.Discontinued;
            // Set data for combobox

            // FIXME group by & order by
            IList<Customers> list = AppSetting.CustomerList.Where(c => c.CustomerDiscontinued == false && c.CustomerMainID == c.CustomerID).ToList();
            lkeCustomerMainID.Properties.DataSource = list;
            lkeCustomerMainID.Properties.DisplayMember = "CustomerNumber";
            lkeCustomerMainID.Properties.ValueMember = "CustomerID";
            try
            {
                lkeCustomerMainID.EditValue = (int)item.CustomerMainID;
            }
            catch
            {
                lkeCustomerMainID.EditValue = 0;
            }
            lkeCustomerMainID.Focus();
        }
    }
}
