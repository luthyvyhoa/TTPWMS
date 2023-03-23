using System.Windows.Forms;
using Common.Controls;
using DA;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.XtraGrid;
using System;
using UI.Helper;

namespace UI.MasterSystemSetup
{
    public partial class frm_MSS_PositionSystem : frmBaseForm
    {
        public frm_MSS_PositionSystem()
        {
            InitializeComponent();
            this.LoadData();
        }

        #region Variables
        BindingList<Positions> Lst_Main = null;
        Positions Ob_Positions = null;
        int iAction_ = 0; // 0: None, 1: Insert, 2: Update. 3: Delete
        #endregion

        #region Function

        public void LoadData()
        {
            if (this.Lst_Main == null)
            {
                var Lst_ = (List<Positions>)new DataProcess<Positions>().Select(n=>n.Active==true);
                this.Lst_Main = new BindingList<Positions>(Lst_);
            }
            this.grd_MSS_PositionSystem.DataSource = this.Lst_Main;
            this.rpi_cbx_CustomerAllocationMethod.Items.AddRange(this.GetCustomerAllocation());
        }
        public void LoadData(bool reload)
        {

            if (this.Lst_Main == null || reload)
            {
                var Lst_ = (List<Positions>)new DataProcess<Positions>().Select(n => n.Active == true);
                this.Lst_Main = new BindingList<Positions>(Lst_);
            }
            this.grd_MSS_PositionSystem.DataSource = this.Lst_Main;
            this.rpi_cbx_CustomerAllocationMethod.Items.AddRange(this.GetCustomerAllocation());
        }
        public string[] GetCustomerAllocation()
        {
            return new string[] { "ByCustomer", "LocationInOut", "OccupiedLocations", "Transactions" };
        }
        public bool InsertData(Positions positions)
        {
            if (positions.ManagementLevel == null) positions.ManagementLevel = 0;
            if (positions.CreatedBy == null) positions.CreatedBy = AppSetting.CurrentUser.LoginName;
            if (positions.CreatedTime == null) positions.CreatedTime = DateTime.Now;
            int i = new DataProcess<Positions>().Insert(positions);
            return i > 0;
        }
        public bool UpdateData(Positions positions)
        {
            if (positions.ManagementLevel == null) positions.ManagementLevel = 0;
            int i = new DataProcess<Positions>().Update(positions);
            int updateEmployeeManagerlevel = new DataProcess<Employees>().
                ExecuteNoQuery("Update Employees set ManagementLevel={0}, Position=N'{1}' where PositionID={2}",
                positions.ManagementLevel, positions.PositionDescription, positions.PositionID);
            return i > 0;
        }
        public bool DeleteData(Positions positions)
        {
            int i = new DataProcess<Positions>().Delete(positions);
            return i > 0;
        }
        public void SetControl(bool _new, bool _edit, bool _close)
        {
            this.btnNew.Enabled = _new;
            this.btnEdit.Enabled = _edit;
            this.btnClose.Enabled = _close;
        }
        #endregion

        #region Event
        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.btnNew.Caption.Equals("New"))
            {
                this.btnNew.Caption = "Disable";
                this.grcPositionDesc.OptionsColumn.AllowEdit = true;
                this.grcManagementLevel.OptionsColumn.AllowEdit = true;
                this.grcPositionVietNam.OptionsColumn.AllowEdit = true;
                this.grcCustomerAllocationMethod.OptionsColumn.AllowEdit = true;
                this.grcIsProductivity.OptionsColumn.AllowEdit = true;

                this.iAction_ = 1;
                this.grv_MSS_PositionSystem.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
                this.grv_MSS_PositionSystem.FocusedRowHandle = GridControl.NewItemRowHandle;
                this.Lst_Main.Clear();
                this.grv_MSS_PositionSystem.RefreshData();
                this.SetControl(true, false, true);
            }
            else
            {
                this.btnNew.Caption = "New";
                this.grcPositionDesc.OptionsColumn.AllowEdit = false;
                this.grcManagementLevel.OptionsColumn.AllowEdit = false;
                this.grcPositionVietNam.OptionsColumn.AllowEdit = false;
                this.grcCustomerAllocationMethod.OptionsColumn.AllowEdit = false;
                this.grcIsProductivity.OptionsColumn.AllowEdit = false;

                this.iAction_ = 0;
                this.grv_MSS_PositionSystem.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                this.LoadData(true);
                this.SetControl(true, true, true);
            }
        }
        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.btnEdit.Caption.Equals("Edit"))
            {
                this.btnEdit.Caption = "Disable";
                this.grcPositionDesc.OptionsColumn.AllowEdit = true;
                this.grcManagementLevel.OptionsColumn.AllowEdit = true;
                this.grcPositionVietNam.OptionsColumn.AllowEdit = true;
                this.grcCustomerAllocationMethod.OptionsColumn.AllowEdit = true;
                this.grcIsProductivity.OptionsColumn.AllowEdit = true;

                this.iAction_ = 2;
                this.SetControl(false, true, true);

            }
            else
            {
                this.btnEdit.Caption = "Edit";
                this.grcPositionDesc.OptionsColumn.AllowEdit = false;
                this.grcManagementLevel.OptionsColumn.AllowEdit = false;
                this.grcPositionVietNam.OptionsColumn.AllowEdit = false;
                this.grcCustomerAllocationMethod.OptionsColumn.AllowEdit = false;
                this.grcIsProductivity.OptionsColumn.AllowEdit = false;

                this.iAction_ = 0;
                this.SetControl(true, true, true);
            }

        }
        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.iAction_ != 0)
                this.grv_MSS_PositionSystem_FocusedRowChanged(new object(),
                    new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(this.grv_MSS_PositionSystem.FocusedRowHandle, -1));
            this.Close();
        }
        private void frm_MSS_PositionSystem_Load(object sender, System.EventArgs e)
        {
            //this.LoadData();
        }
        private void frm_MSS_PositionSystem_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.iAction_ != 0)
                this.grv_MSS_PositionSystem_FocusedRowChanged(new object(),
                    new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(this.grv_MSS_PositionSystem.FocusedRowHandle, -1));
        }
        private void grv_MSS_PositionSystem_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            this.Ob_Positions = this.grv_MSS_PositionSystem.GetRow(e.RowHandle) as Positions;
        }
        private void grv_MSS_PositionSystem_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.Ob_Positions = this.grv_MSS_PositionSystem.GetRow(e.RowHandle) as Positions;
        }
        private void grv_MSS_PositionSystem_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (this.Ob_Positions == null || this.iAction_ == 0) return;

            if (this.Ob_Positions.PositionID == 0)
            {
                //Insert
                if (!this.InsertData(this.Ob_Positions))
                {
                    MessageBox.Show("Error: insert data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                //Update
                if (!this.UpdateData(this.Ob_Positions))
                {
                    MessageBox.Show("Error: update data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            this.Ob_Positions = null;
        }
        private void grc_btn_Xoa_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Positions position = this.grv_MSS_PositionSystem.GetRow(this.grv_MSS_PositionSystem.FocusedRowHandle) as Positions;
            if (position == null) return;

            string msg = string.Format("Delete {0}: {1} \nAre you sure ?", "position ID", position.PositionID);
            DialogResult dia = MessageBox.Show(msg, "Infomation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dia == DialogResult.No) return;

            if (!this.DeleteData(position))
            {
                //error
                MessageBox.Show("Error!", "Waring", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Lst_Main.Remove(position);
            }
        }


        #endregion

        private void simpleButton3_Click(object sender, System.EventArgs e)
        {
            if (this.btnNew.Caption.Equals("New"))
            {
                this.btnNew.Caption = "Disable";
                this.grcPositionDesc.OptionsColumn.AllowEdit = true;
                this.grcManagementLevel.OptionsColumn.AllowEdit = true;
                this.grcPositionVietNam.OptionsColumn.AllowEdit = true;
                this.grcCustomerAllocationMethod.OptionsColumn.AllowEdit = true;
                this.grcIsProductivity.OptionsColumn.AllowEdit = true;

                this.iAction_ = 1;
                this.grv_MSS_PositionSystem.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
                this.grv_MSS_PositionSystem.FocusedRowHandle = GridControl.NewItemRowHandle;
                this.Lst_Main.Clear();
                this.grv_MSS_PositionSystem.RefreshData();
                this.SetControl(true, false, true);
            }
            else
            {
                this.btnNew.Caption = "New";
                this.grcPositionDesc.OptionsColumn.AllowEdit = false;
                this.grcManagementLevel.OptionsColumn.AllowEdit = false;
                this.grcPositionVietNam.OptionsColumn.AllowEdit = false;
                this.grcCustomerAllocationMethod.OptionsColumn.AllowEdit = false;
                this.grcIsProductivity.OptionsColumn.AllowEdit = false;

                this.iAction_ = 0;
                this.grv_MSS_PositionSystem.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                this.LoadData(true);
                this.SetControl(true, true, true);
            }
        }

        private void btn_Close_PossitionSytem_Click(object sender, System.EventArgs e)
        {
            if (this.iAction_ != 0)
                this.grv_MSS_PositionSystem_FocusedRowChanged(new object(),
                    new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(this.grv_MSS_PositionSystem.FocusedRowHandle, -1));
            this.Close();
        }

        private void btn_Edit_PositionSystem_Click(object sender, System.EventArgs e)
        {
            if (this.btnEdit.Caption.Equals("Edit"))
            {
                this.btnEdit.Caption = "Disable";
                this.grcPositionDesc.OptionsColumn.AllowEdit = true;
                this.grcManagementLevel.OptionsColumn.AllowEdit = true;
                this.grcPositionVietNam.OptionsColumn.AllowEdit = true;
                this.grcCustomerAllocationMethod.OptionsColumn.AllowEdit = true;
                this.grcIsProductivity.OptionsColumn.AllowEdit = true;

                this.iAction_ = 2;
                this.SetControl(false, true, true);

            }
            else
            {
                this.btnEdit.Caption = "Edit";
                this.grcPositionDesc.OptionsColumn.AllowEdit = false;
                this.grcManagementLevel.OptionsColumn.AllowEdit = false;
                this.grcPositionVietNam.OptionsColumn.AllowEdit = false;
                this.grcCustomerAllocationMethod.OptionsColumn.AllowEdit = false;
                this.grcIsProductivity.OptionsColumn.AllowEdit = false;

                this.iAction_ = 0;
                this.SetControl(true, true, true);
            }

        }

        private void rpi_Active_Click(object sender, System.EventArgs e)
        {
            var chk = (DevExpress.XtraEditors.CheckEdit)sender;

            DataProcess<object> dataProcess = new DataProcess<object>();


            // User doing confirm
            if (!chk.Checked)
            {
                DialogResult result1 = MessageBox.Show("Do you want to change Active ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result1 == DialogResult.No)
                {
                    chk.Checked = false;
                    return;
                }
             
                chk.Checked = true;
             //   int isConfirm = chk.Checked ? 1 : 0;
                int positionID = Convert.ToInt32(this.grv_MSS_PositionSystem.GetFocusedRowCellValue("PositionID"));
                dataProcess.ExecuteNoQuery("UPDATE dbo.Positions SET Active=1 WHERE  PositionID = {0}", positionID);
              //  chk.ReadOnly = true;
            }
            // Do nothing when checkbox is already checked
            else
            {
                DialogResult result1 = MessageBox.Show("Do you want to change Active ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result1 == DialogResult.No)
                {
                    chk.Checked = true;
                    return;
                }
                chk.Checked = false;
                //int isConfirm = chk.Checked ? 1 : 0;
                int positionID = Convert.ToInt32(this.grv_MSS_PositionSystem.GetFocusedRowCellValue("PositionID"));
                dataProcess.ExecuteNoQuery("UPDATE dbo.Positions SET Active=0 WHERE  PositionID = {0}", positionID);
               // chk.ReadOnly = true;
                //return;
            }
        }

        private void btn_AllPosition_Click(object sender, EventArgs e)
        {
            if(btn_AllPosition.Text.Equals("All Position"))
            {
                Lst_Main = null;
                var Lst_ = (List<Positions>)new DataProcess<Positions>().Select();
                this.Lst_Main = new BindingList<Positions>(Lst_);
                this.grd_MSS_PositionSystem.DataSource = this.Lst_Main;
                this.rpi_cbx_CustomerAllocationMethod.Items.AddRange(this.GetCustomerAllocation());
                btn_AllPosition.Text = "Active Position";
            }
            else if (btn_AllPosition.Text.Equals("Active Position"))
            {
                Lst_Main = null;
                var Lst_ = (List<Positions>)new DataProcess<Positions>().Select(n=>n.Active==true);
                this.Lst_Main = new BindingList<Positions>(Lst_);
                this.grd_MSS_PositionSystem.DataSource = this.Lst_Main;
                this.rpi_cbx_CustomerAllocationMethod.Items.AddRange(this.GetCustomerAllocation());
                btn_AllPosition.Text = "UnActive Position";
            }
            else 
            {
                Lst_Main = null;
                var Lst_ = (List<Positions>)new DataProcess<Positions>().Select(n => n.Active == false);
                this.Lst_Main = new BindingList<Positions>(Lst_);
                this.grd_MSS_PositionSystem.DataSource = this.Lst_Main;
                this.rpi_cbx_CustomerAllocationMethod.Items.AddRange(this.GetCustomerAllocation());
                btn_AllPosition.Text = "All Position";
            }
        }
    }
}
