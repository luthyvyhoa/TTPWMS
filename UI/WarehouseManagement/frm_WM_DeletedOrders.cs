using Common.Process;
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
    public partial class frm_WM_DeletedOrders : Common.Controls.frmBaseForm
    {
        private DataTable _tbOrders;
        private bool _isRO;

        public frm_WM_DeletedOrders()
        {
            InitializeComponent();
            this._tbOrders = new DataTable();
            this._isRO = true;
        }

        private void frm_WM_DeletedOrders_Load(object sender, EventArgs e)
        {
            Wait.Start(this);
            this._tbOrders = FileProcess.LoadTable("STDeletedOrderView @Flag = 0, @CustomerID = null, @varStoreID = " + AppSetting.StoreID);
            InitCustomer();
            LoadOrders();
            SetEvents();
            Wait.Close();
        }

        private void SetEvents()
        {
           // this.rpi_btn_Detail.Click += Rpi_btn_Detail_Click;
            this.lkeCustomer.CloseUp += LkeCustomer_CloseUp;
            this.chkAll.EditValueChanging += ChkAll_EditValueChanging;
            this.chkCustomer.EditValueChanging += ChkCustomer_EditValueChanging;
            this.chkDO.EditValueChanging += ChkDO_EditValueChanging;
            this.chkRO.EditValueChanging += ChkRO_EditValueChanging;
            this.chkAll.CheckedChanged += ChkAll_CheckedChanged;
            this.chkCustomer.CheckedChanged += ChkCustomer_CheckedChanged;
            this.chkRO.CheckedChanged += ChkRO_CheckedChanged;
            this.chkDO.CheckedChanged += ChkDO_CheckedChanged;
        }

        private void Rpi_btn_Detail_Click(object sender, EventArgs e)
        {
            int orderID = Convert.ToInt32(this.grvOrders.GetFocusedRowCellValue("OrderID"));

            if(this._isRO)
            {
                frm_WM_ReceivingOrders.Instance.ReceivingOrderIDFind = orderID;
                frm_WM_ReceivingOrders.Instance.Show();
            }
            else
            {
                var frmDispatching = frm_WM_DispatchingOrders.GetInstance(orderID);
                if (frmDispatching.Visible)
                {
                    frmDispatching.ReloadData();
                }
                frmDispatching.Show();
            }
        }

        private void LkeCustomer_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            this.lkeCustomer.EditValue = e.Value;
            FilterChanged();
        }

        private void ChkAll_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (!Convert.ToBoolean(e.NewValue))
            {
                if (Convert.ToInt32(this.chkAll.Tag) > 0)
                {
                    e.Cancel = true;
                }
            }
        }

        private void ChkCustomer_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if(!Convert.ToBoolean(e.NewValue))
            {
                if(Convert.ToInt32(this.chkCustomer.Tag) > 0)
                {
                    e.Cancel = true;
                }
            }
        }

        private void ChkDO_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (!Convert.ToBoolean(e.NewValue))
            {
                if (!this._isRO)
                {
                    e.Cancel = true;
                }
            }
        }

        private void ChkRO_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if(!Convert.ToBoolean(e.NewValue))
            {
                if(this._isRO)
                {
                    e.Cancel = true;
                }
            }
        }

        private void ChkAll_CheckedChanged(object sender, EventArgs e)
        {
            if(this.chkAll.Checked)
            {
                this.chkCustomer.Tag = 0;
                this.chkAll.Tag = 1;
                this.chkCustomer.Checked = false;
                FilterChanged();
            }
        }

        private void ChkCustomer_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkAll.Checked)
            {
                this.chkAll.Tag = 0;
                this.chkCustomer.Tag = 1;
                this.chkAll.Checked = false;
                this.lkeCustomer.ReadOnly = false;
                this.lkeCustomer.Focus();
                this.lkeCustomer.ShowPopup();
            }
            else
            {
                this.lkeCustomer.ReadOnly = true;
            }
        }

        private void ChkDO_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDO.Checked)
            {
                this._isRO = false;
                this.chkRO.Checked = false;
                FilterChanged();
            }
        }

        private void ChkRO_CheckedChanged(object sender, EventArgs e)
        {
            if(chkRO.Checked)
            {
                this._isRO = true;
                this.chkDO.Checked = false;
                FilterChanged();
            }
        }

        #region Load Data
        private void LoadOrders()
        {
            this.grdOrders.DataSource = this._tbOrders;
        }

        private void InitCustomer()
        {
            this.lkeCustomer.Properties.DataSource = AppSetting.CustomerList;
            this.lkeCustomer.Properties.ValueMember = "CustomerID";
            this.lkeCustomer.Properties.DisplayMember = "CustomerNumber";
        }
        #endregion

        private void FilterChanged()
        {
            Wait.Start(this);
            if (this.chkAll.Checked)
            {
                if (this._isRO)
                {
                    this._tbOrders = FileProcess.LoadTable("STDeletedOrderView @Flag = 0, @CustomerID = null, @varStoreID = " + AppSetting.StoreID);
                }
                else
                {
                    this._tbOrders = FileProcess.LoadTable("STDeletedOrderView @Flag = 1, @CustomerID = null, @varStoreID = " + AppSetting.StoreID);
                }
            }
            else
            {
                if (this.lkeCustomer.EditValue == null)
                {
                    this.lkeCustomer.Focus();
                    this.lkeCustomer.ShowPopup();
                    return;
                }


                if (this._isRO)
                {
                    this._tbOrders = FileProcess.LoadTable("STDeletedOrderView @Flag = 0, @CustomerID = " + Convert.ToInt32(this.lkeCustomer.EditValue) + ", @varStoreID = " + AppSetting.StoreID);
                }
                else
                {
                    this._tbOrders = FileProcess.LoadTable("STDeletedOrderView @Flag = 1, @CustomerID = " + Convert.ToInt32(this.lkeCustomer.EditValue) + ", @varStoreID = " + AppSetting.StoreID);
                }
            }
            Wait.Close();
            LoadOrders();
        }

        private void rpi_hpl_Detail_Click(object sender, EventArgs e)
        {
            int orderID = Convert.ToInt32(this.grvOrders.GetFocusedRowCellValue("OrderID"));

            if (this._isRO)
            {
                frm_WM_ReceivingOrders.Instance.ReceivingOrderIDFind = orderID;
                frm_WM_ReceivingOrders.Instance.Show();
            }
            else
            {
                var frmDispatching = frm_WM_DispatchingOrders.GetInstance(orderID);
                if (frmDispatching.Visible)
                {
                    frmDispatching.ReloadData();
                }
                frmDispatching.Show();
            }
        }
    }
}
