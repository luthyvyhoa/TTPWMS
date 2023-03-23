using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Helper;
using DevExpress.XtraEditors;
using UI.ReportForm;
using DA;

namespace UI.WarehouseManagement
{
    public partial class urc_WM_FindStock : UserControl
    {
        private int _filterMode;
        private DataProcess<Customers> daCustomer = new DataProcess<Customers>();
        public urc_WM_FindStock()
        {
            InitializeComponent();
            this._filterMode = 0;
        }

        private void urc_WM_FindStock_Load(object sender, EventArgs e)
        {
            InitCustomers();
            SetEvents();
        }

        private void SetEvents()
        {
            this.chkProductCode.CheckedChanged += chkProductCode_CheckedChanged;
            this.chkProductName.CheckedChanged += chkProductName_CheckedChanged;
            this.chkReference.CheckedChanged += chkReference_CheckedChanged;
            this.chkUseByDate.CheckedChanged += chkUseByDate_CheckedChanged;
            this.chkVehicleNumber.CheckedChanged += chkVehicleNumber_CheckedChanged;
            this.chkProDate.CheckedChanged += chkProDate_CheckedChanged;
            lkeCustomers.EditValueChanged += LkeCustomers_EditValueChanged;
        }

        private void LkeCustomers_EditValueChanged(object sender, EventArgs e)
        {
            
            int idCus = Convert.ToInt32(lkeCustomers.EditValue);
            txtCustomerName.EditValue = daCustomer.Select(n=>n.CustomerID== idCus).FirstOrDefault().CustomerName;
        }

        #region Events
        private void chkProDate_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkProDate.Checked)
            {
                this.chkProductCode.Checked = false;
                this.chkProductName.Checked = false;
                this.chkReference.Checked = false;
                this.chkUseByDate.Checked = false;
                this.chkVehicleNumber.Checked = false;
                this.dtProDate.ReadOnly = false;
                this.dtProDate.Focus();
                this._filterMode = 5;
            }
            else
            {
                this.dtProDate.ReadOnly = true;
            }
        }

        private void chkVehicleNumber_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkVehicleNumber.Checked)
            {
                this.chkProductCode.Checked = false;
                this.chkProductName.Checked = false;
                this.chkReference.Checked = false;
                this.chkUseByDate.Checked = false;
                this.chkProDate.Checked = false;
                this.txtVehicle.ReadOnly = false;
                this.txtVehicle.Focus();
                this._filterMode = 3;
            }
            else
            {
                this.txtVehicle.ReadOnly = true;
            }
        }

        private void chkUseByDate_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkUseByDate.Checked)
            {
                this.chkProductCode.Checked = false;
                this.chkProductName.Checked = false;
                this.chkReference.Checked = false;
                this.chkVehicleNumber.Checked = false;
                this.chkProDate.Checked = false;
                this.dtUseByDate.ReadOnly = false;
                this.dtUseByDate.Focus();
                this._filterMode = 6;
            }
            else
            {
                this.dtUseByDate.ReadOnly = true;
            }
        }

        private void chkReference_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkReference.Checked)
            {
                this.chkProductCode.Checked = false;
                this.chkProductName.Checked = false;
                this.chkUseByDate.Checked = false;
                this.chkVehicleNumber.Checked = false;
                this.chkProDate.Checked = false;
                this.txtReference.ReadOnly = false;
                this.txtReference.Focus();
                this._filterMode = 4;
            }
            else
            {
                this.txtReference.ReadOnly = true;
            }
        }

        private void chkProductName_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkProductName.Checked)
            {
                this.chkProductCode.Checked = false;
                this.chkReference.Checked = false;
                this.chkUseByDate.Checked = false;
                this.chkVehicleNumber.Checked = false;
                this.chkProDate.Checked = false;
                this.txtProductName.ReadOnly = false;
                this.txtProductName.Focus();
                this._filterMode = 2;
            }
            else
            {
                this.txtProductName.ReadOnly = true;
            }
        }

        private void chkProductCode_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkProductCode.Checked)
            {
                this.chkProductName.Checked = false;
                this.chkReference.Checked = false;
                this.chkUseByDate.Checked = false;
                this.chkVehicleNumber.Checked = false;
                this.chkProDate.Checked = false;
                this.txtProductCode.ReadOnly = false;
                this.txtProductCode.Focus();
                this._filterMode = 1;
            }
            else
            {
                this.txtProductCode.ReadOnly = true;
            }
        }
        #endregion

        private void InitCustomers()
        {
            this.lkeCustomers.Properties.DataSource = AppSetting.CustomerList;
            this.lkeCustomers.Properties.ValueMember = "CustomerID";
            this.lkeCustomers.Properties.DisplayMember = "CustomerNumber";
        }

        public void Find()
        {
            if(this.lkeCustomers.EditValue == null)
            {
                XtraMessageBox.Show("Please enter Customer to find !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (String.IsNullOrEmpty(txtProductCode.Text) && String.IsNullOrEmpty(this.txtProductName.Text) && String.IsNullOrEmpty(this.txtReference.Text) && String.IsNullOrEmpty(txtVehicle.Text) && this.dtProDate.EditValue == null && this.dtUseByDate.EditValue == null)
            {
                XtraMessageBox.Show("Please enter condition to find !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            switch(this._filterMode)
            {
                case 1:
                    {
                        frm_WM_DialogFindStock frm = new frm_WM_DialogFindStock(Convert.ToInt32(lkeCustomers.EditValue), txtReference.EditValue.ToString(), 1);
                        frm.Show();
                        frm.WindowState = FormWindowState.Maximized;
                        break;
                    }
                case 2:
                    {
                        frm_WM_DialogFindStock frm = new frm_WM_DialogFindStock(Convert.ToInt32(lkeCustomers.EditValue), txtReference.EditValue.ToString(), 2);
                        frm.Show();
                        frm.WindowState = FormWindowState.Maximized;
                        break;
                    }
                case 3:
                    {
                        frm_WM_DialogFindStock frm = new frm_WM_DialogFindStock(Convert.ToInt32(lkeCustomers.EditValue), txtReference.EditValue.ToString(), 3);
                        frm.Show();
                        frm.WindowState = FormWindowState.Maximized;
                        break;
                    }
                case 4:
                    {
                        frm_WM_DialogFindStock frm = new frm_WM_DialogFindStock(Convert.ToInt32(lkeCustomers.EditValue), txtReference.EditValue.ToString(),4);
                        frm.Show();
                        frm.WindowState = FormWindowState.Maximized;
                        break;
                    }
                case 5:
                    {
                        frm_WM_DialogFindStock frm = new frm_WM_DialogFindStock(Convert.ToInt32(lkeCustomers.EditValue), txtReference.EditValue.ToString(), 5);
                        frm.Show();
                        frm.WindowState = FormWindowState.Maximized;
                        break;
                    }
                case 6:
                    {
                        frm_WM_DialogFindStock frm = new frm_WM_DialogFindStock(Convert.ToInt32(lkeCustomers.EditValue), txtReference.EditValue.ToString(), 6);
                        frm.Show();
                        frm.WindowState = FormWindowState.Maximized;
                        break;
                    }
            }
        }
    }
}
