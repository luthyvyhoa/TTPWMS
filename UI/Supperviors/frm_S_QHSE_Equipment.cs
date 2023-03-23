using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Controls;
using DA;
using DevExpress.XtraEditors;
using UI.Helper;
using UI.WarehouseManagement;

namespace UI.Supperviors
{
    public partial class frm_S_QHSE_Equipment : frmBaseFormNormal
    {
        private BindingList<QHSE_Equipments> bindingSource;
        public frm_S_QHSE_Equipment()
        {
            InitializeComponent();

            // Load departments
            this.LoadDepartments();

            // Load Equipment
            this.LoadEquipmentCategory();

            // Load stores
            this.LoadStore();
            this.lkeStore.EditValue = AppSetting.StoreID;
            
            this.LoadDataDetails(AppSetting.StoreID);
        }

        private void LoadStore()
        {
            DataProcess<Stores> dataProcess = new DataProcess<Stores>();
            this.lkeStore.Properties.DataSource = dataProcess.Select();
            this.lkeStore.Properties.DisplayMember = "StoreDescription";
            this.lkeStore.Properties.ValueMember = "StoreID";
        }

        private void LoadDepartments()
        {
            DataProcess<Departments> de = new DataProcess<Departments>();
            this.rpi_lke_Departments.DataSource = de.Select();
            this.rpi_lke_Departments.DisplayMember = "DepartmentNameVietnam";
            this.rpi_lke_Departments.ValueMember = "DepartmentID";
        }

        private void LoadEquipmentCategory()
        {
            using (var context = new SwireDBEntities())
            {
                this.rpi_lke_EquipmentCategory.DataSource = context.Database.SqlQuery<QHSE_EquipmentCategories>("SELECT * from QHSE_EquipmentCategories").ToList();
                this.rpi_lke_EquipmentCategory.DisplayMember = "CategoryDescription";
                this.rpi_lke_EquipmentCategory.ValueMember = "QHSE_EquipmentCategoryID";
            }
        }

        private void lkeStore_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.Value == null) return;
            var storeIDSelected = Convert.ToInt32(e.Value);
            this.LoadDataDetails(storeIDSelected);
        }

        private void LoadDataDetails(int storeID)
        {
            DataProcess<QHSE_Equipments> de = new DataProcess<QHSE_Equipments>();
            var dataSource = de.Select(q => q.StoreID == storeID && q.IsDeleted == false);
            this.bindingSource = new BindingList<QHSE_Equipments>(dataSource.ToList());
            this.grcQHSEEquipment.DataSource = this.bindingSource;
            this.AddNewRow();
        }

        private void AddNewRow()
        {
            QHSE_Equipments newRow = new QHSE_Equipments();
            newRow.CalibratingDate = DateTime.Now;
            newRow.Confirmed = false;
            newRow.CreatedBy = AppSetting.CurrentUser.LoginName;
            newRow.CreatedTime = DateTime.Now;
            newRow.DepartmentID = 0;
            newRow.IsDeleted = false;
            newRow.StoreID = AppSetting.StoreID;
            this.bindingSource.Insert(0, newRow);
            //this.bindingSource.Add(newRow);
            this.grvQHSEEquipment.RefreshData();
        }

        private void rpi_btn_Del_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (this.grvQHSEEquipment.FocusedRowHandle < 0) return;
            var dlConfirm = XtraMessageBox.Show("Are you sure to delete this Equipment!", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlConfirm.Equals(DialogResult.No)) return;

            int currentEquipmentID = Convert.ToInt32(this.grvQHSEEquipment.GetFocusedRowCellValue("QHSE_EquipmentID"));

            // Validate current Equipment has config
            if (this.bindingSource.Where(b => b.QHSE_EquipmentID == currentEquipmentID).FirstOrDefault().Confirmed)
            {
                XtraMessageBox.Show("This Equipment has confirmed!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataProcess<QHSE_Equipments> de = new DataProcess<QHSE_Equipments>();
            de.ExecuteNoQuery($"Update QHSE_Equipments set IsDeleted=1 where QHSE_EquipmentID={currentEquipmentID}");
            this.LoadDataDetails(Convert.ToInt32(this.lkeStore.EditValue));
        }

        private void grvQHSEEquipment_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (this.grvQHSEEquipment.FocusedRowHandle < 0) return;
            int currentEquipmentID = Convert.ToInt32(this.grvQHSEEquipment.GetFocusedRowCellValue("QHSE_EquipmentID"));
            if (currentEquipmentID <= 0)
            {
                // insert
                var currentEquipmentInfo = this.bindingSource.Where(b => b.QHSE_EquipmentID == currentEquipmentID).FirstOrDefault();
                DataProcess<QHSE_Equipments> de = new DataProcess<QHSE_Equipments>();
                int result = de.Insert(currentEquipmentInfo);
                if (result > 0)
                {
                    this.bindingSource[0].QHSE_EquipmentNumber = "QE-" + currentEquipmentInfo.QHSE_EquipmentID;

                    // Add new row
                    this.AddNewRow();
                }
            }
            else
            {
                // update
                var currentEquipmentInfo = this.bindingSource.Where(b => b.QHSE_EquipmentID == currentEquipmentID).FirstOrDefault();
                DataProcess<QHSE_Equipments> de = new DataProcess<QHSE_Equipments>();
                int result = de.Update(currentEquipmentInfo);
            }
        }

        private void rpi_chk_Confirm_CheckedChanged(object sender, EventArgs e)
        {
            if (this.grvQHSEEquipment.FocusedRowHandle < 0) return;
            int currentEquipmentID = Convert.ToInt32(this.grvQHSEEquipment.GetFocusedRowCellValue("QHSE_EquipmentID"));
            var currentEquipmentInfo = this.bindingSource.Where(b => b.QHSE_EquipmentID == currentEquipmentID).FirstOrDefault();
            currentEquipmentInfo.Confirmed = Convert.ToBoolean(rpi_chk_Confirm.ValueChecked);
            DataProcess<QHSE_Equipments> de = new DataProcess<QHSE_Equipments>();
            int result = de.Update(currentEquipmentInfo);
        }

        private void rpi_ice_IsAttachment_Click(object sender, EventArgs e)
        {
            if (this.grvQHSEEquipment.FocusedRowHandle < 0) return;
            string orderNumber = Convert.ToString(this.grvQHSEEquipment.GetFocusedRowCellValue("QHSE_EquipmentNumber"));
            frm_WM_Attachments.Instance.OrderNumber = orderNumber;
            if (frm_WM_Attachments.Instance.Enabled) frm_WM_Attachments.Instance.ShowDialog();
        }

        private void grvQHSEEquipment_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F3))
            {
                if (this.grvQHSEEquipment.FocusedRowHandle < 0) return;
                string orderNumber = Convert.ToString(this.grvQHSEEquipment.GetFocusedRowCellValue("QHSE_EquipmentNumber"));
                frm_WM_Attachments.Instance.OrderNumber = orderNumber;
                if (frm_WM_Attachments.Instance.Enabled) frm_WM_Attachments.Instance.ShowDialog();
            }
        }
    }
}
