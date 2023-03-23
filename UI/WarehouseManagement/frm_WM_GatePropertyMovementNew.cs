using Common.Controls;
using DA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Helper;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_GatePropertyMovementNew : frmBaseForm
    {
        private DataProcess<Gate_Properties> gatePropertiesDA;
        private DataProcess<Gate_PropertyMovements> gatePropertiesMovementsDA;
        public frm_WM_GatePropertyMovementNew()
        {
            InitializeComponent();

            initData();

            this.LoadCustomerList();
        }

        private void initData()
        {
            this.txtSoLuong.Text = "1";
            this.txtGhiChu.Text = "Không ghi chú";
            // Load asset list
            this.loadAssetList();

        }

        private void loadAssetList()
        {
            gatePropertiesDA = new DataProcess<Gate_Properties>();
            var gatePropertiesList = gatePropertiesDA.Select();
            lkeLoaiTaiSan.Properties.DataSource = gatePropertiesList;
            lkeLoaiTaiSan.Properties.ValueMember = "PropertyID";
            lkeLoaiTaiSan.Properties.DisplayMember = "PropertyName";
            lkeLoaiTaiSan.EditValue = 3;
        }

        /// <summary>
        /// Load customer list
        /// </summary>
        private void LoadCustomerList()
        {
            lkeKhachHang.Properties.DataSource = AppSetting.CustomerList;
            lkeKhachHang.Properties.ValueMember = "CustomerID";
            lkeKhachHang.Properties.DisplayMember = "CustomerNumber";
        }

        private void btHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            if (this.lkeKhachHang.EditValue == null || this.lkeLoaiTaiSan.EditValue == null) return;

            if (lkeKhachHang.Text == null)
            {
                this.lkeKhachHang.Focus();
                this.lkeKhachHang.ShowPopup();
                return;
            }

            if (Int32.Parse(txtSoLuong.Text) < 1)
            {
                MessageBox.Show("So lieu nhap chua dung !", "TPWMS",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.gatePropertiesMovementsDA == null)
            {
                this.gatePropertiesMovementsDA = new DataProcess<Gate_PropertyMovements>();
            }

            Customers customerSelected = (Customers)this.lkeKhachHang.GetSelectedDataRow();

            Gate_PropertyMovements objProperyMovement = new Gate_PropertyMovements();
            objProperyMovement.AuthorizedBy = AppSetting.CurrentUser.LoginName + "-" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
            objProperyMovement.CustomerID = customerSelected.CustomerID;
            objProperyMovement.CustomerName = customerSelected.CustomerName;
            objProperyMovement.Gate = 1;
            if (AppSetting.CurrentUser.StoreID==2)
            {
                objProperyMovement.Gate = 3;

            }            
            objProperyMovement.PropertyID = (int)this.lkeLoaiTaiSan.EditValue;
            //objProperyMovement.PropertyMovementDate = DateTime.Now;
            objProperyMovement.Quantity = double.Parse(this.txtSoLuong.Text);
            objProperyMovement.Remark = this.txtGhiChu.Text;
            int result = gatePropertiesMovementsDA.Insert(objProperyMovement);
            if (result > 0)
            {
                this.Close();
            }
        }

        private void rbcbase_Click(object sender, EventArgs e)
        {

        }

        private void lkeKhachHang_EditValueChanged(object sender, EventArgs e)
        {
            if (this.lkeKhachHang.EditValue == null)
            {
                this.txtCustomerName.Text = string.Empty;
                return;
            }
            string customerName = Convert.ToString(this.lkeKhachHang.GetColumnValue("CustomerName"));
            this.txtCustomerName.Text = customerName;
        }
    }
}
