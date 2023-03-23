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
using UI.Helper;

namespace UI.MasterSystemSetup
{
    public partial class frm_MSS_ChangeStore : frmBaseForm
    {
        public frm_MSS_ChangeStore()
        {
            InitializeComponent();

            // Init data
            this.InitData();
        }

        private void InitData()
        {
            this.LoadStore();
            this.LoadWareHouse();
        }

        private void LoadStore()
        {
            DataProcess<Stores> storeDA = new DataProcess<Stores>();
            this.lke_MSS_StoreList.Properties.DataSource = storeDA.Select();
            this.lke_MSS_StoreList.Properties.ValueMember = "StoreID";
            this.lke_MSS_StoreList.Properties.DisplayMember = "StoreDescription";
            this.lke_MSS_StoreList.EditValue = AppSetting.CurrentUser.StoreID;
        }

        private void LoadWareHouse()
        {
            DataProcess<DA.Warehouses> warehouseDA = new DataProcess<Warehouses>();
            this.lke_MSS_WarehouseList.Properties.DataSource = warehouseDA.Select(w => w.StoreID == AppSetting.StoreID);
            this.lke_MSS_WarehouseList.Properties.ValueMember = "WarehouseID";
            this.lke_MSS_WarehouseList.Properties.DisplayMember = "WarehouseDescription";
            this.lke_MSS_WarehouseList.EditValue = AppSetting.CurrentUser.WarehouseID;
        }

        private void lke_M_StoreList_EditValueChanged(object sender, EventArgs e)
        {
            if (this.lke_MSS_StoreList.EditValue == null) return;
            DataProcess<Warehouses> dataProcess = new DataProcess<Warehouses>();
            this.lke_MSS_WarehouseList.Properties.DataSource = dataProcess.Select(w => w.StoreID == (int)this.lke_MSS_StoreList.EditValue);
            this.lke_MSS_WarehouseList.Properties.ValueMember = "WarehouseID";
            this.lke_MSS_WarehouseList.Properties.DisplayMember = "WarehouseDescription";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.lke_MSS_StoreList.EditValue == null ||
                this.lke_MSS_WarehouseList.EditValue == null)
            {
                MessageBox.Show("Data change is invalid, please re-check it!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int newStoreID = (int)this.lke_MSS_StoreList.EditValue;
            int newWarehouse = Convert.ToInt32(lke_MSS_WarehouseList.EditValue);
            if (AppSetting.StoreID != newStoreID)
            {
                // update store for useraccount is loging
                DataProcess<UserAccount> refreshCurrentUser = new DataProcess<UserAccount>();
                UserAccount currentAccount = refreshCurrentUser.Select(u => u.LoginName == AppSetting.CurrentUser.LoginName).FirstOrDefault();
                currentAccount.StoreID = newStoreID;
                currentAccount.WarehouseID = (byte)newWarehouse;
                int resultUpdate = refreshCurrentUser.ExecuteNoQuery("UPDATE UserAccounts SET StoreID={0},WarehouseID={1} WHERE LoginName={2}",
                    currentAccount.StoreID, currentAccount.WarehouseID, currentAccount.LoginName);
                if (resultUpdate > 0)
                {
                    this.btnOK.Enabled = false;
                    this.Close();

                    // Reload local data by store selected
                    frmMain.Instance.RefreshLocalData();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
                if(frm.Name!= "frm_MSS_ChangeStore" && frm.Name != "frmMain")
                openForms.Add(frm);
            }
            foreach (var frm in openForms)
            {
                frm.Close();
            }
        }
    }
}
