using System;
using System.Collections.Generic;
using System.Linq;
using Common.Controls;
using DA;
using UI.Helper;
using System.Drawing;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_ConfirmationAll : frmBaseForm
    {
        private DataProcess<STConfirmationAll_Result> _data;
        private List<STConfirmationAll_Result> _listData;
        private int _preFilterType;

        public frm_WM_ConfirmationAll()
        {
            InitializeComponent();
            this._data = new DataProcess<STConfirmationAll_Result>();
            this.rdgFilterType.EditValue = 0;
            this._preFilterType = 0;
        }

        private void frm_WM_ConfirmationAll_Load(object sender, EventArgs e)
        {
            LoadConfirmationData();
            SetEvents();
        }

        private void SetEvents()
        {
            this.rdgFilterType.EditValueChanged += rdgFilterType_EditValueChanged;
            this.btnClose.Click += btnClose_Click;
            this.btnRefresh.Click += btnRefresh_Click;
            this.btnCloseStock.Click += btnCloseStock_Click;
            this.rpi_hpl_OrderNumber.Click += rpi_hpl_OrderNumber_DoubleClick;
        }

        #region Load Data
        private void LoadConfirmationData()
        {
            this._listData = _data.Executing("STConfirmationAll @varStoreID={0}", AppSetting.StoreID).ToList();
            this.grdConfirmationAll.DataSource = this._listData;
        }
        #endregion

        #region Events
        private void rdgFilterType_EditValueChanged(object sender, EventArgs e)
        {
            FilterType(Convert.ToInt16(this.rdgFilterType.EditValue));
        }
        #endregion

        private void FilterType(int type)
        {
            switch (type)
            {
                case 1: //Filter by user
                    {
                        if (this._preFilterType != 0)
                        {
                            LoadConfirmationData();
                        }
                        this.grcOrderID.FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(this.grcUserName, (object)AppSetting.CurrentUser.LoginName);
                        this._preFilterType = 1;
                        break;
                    }
                case 2: //Filter by 123
                    {
                        this.grdConfirmationAll.DataSource = _data.Executing("STConfirmationAll @LoginName = {0}, @WarehouseID = {1},@varStoreID={2}", null, 1, AppSetting.StoreID);
                        this.grcOrderID.FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo();
                        this._preFilterType = 2;
                        break;
                    }
                case 3: //Filter by 45
                    {
                        this.grdConfirmationAll.DataSource = _data.Executing("STConfirmationAll @LoginName = {0}, @WarehouseID = {1},@varStoreID={2}", null, 2, AppSetting.StoreID);
                        this.grcOrderID.FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo();
                        this._preFilterType = 3;
                        break;
                    }
                default:
                    {
                        if (this._preFilterType > 1)
                        {
                            LoadConfirmationData();
                        }
                        this.grcOrderID.FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo();
                        this._preFilterType = 0;
                        break;
                    }
            }
        }

        private void btnCloseStock_Click(object sender, EventArgs e)
        {
            frm_WM_CloseStock frm = new frm_WM_CloseStock(this._listData);
            frm.Show();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            int orderType = Convert.ToInt32(this.grvConfirmationAll.GetRowCellValue(this.grvConfirmationAll.FocusedRowHandle, "ordertype"));
            if (orderType == 1)
            {
                frm_WM_ReceivingOrders.Instance.ReceivingOrderIDFind = Convert.ToInt32(this.grvConfirmationAll.GetRowCellValue(this.grvConfirmationAll.FocusedRowHandle, "ID"));
                frm_WM_ReceivingOrders.Instance.Show();
            }
            else
            {
                int orderID = Convert.ToInt32(this.grvConfirmationAll.GetRowCellValue(this.grvConfirmationAll.FocusedRowHandle, "ID"));
                var frmDispatching = frm_WM_DispatchingOrders.GetInstance(orderID);
                if (frmDispatching.Visible)
                {
                    frmDispatching.ReloadData();
                }
                frmDispatching.Show();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadConfirmationData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void rpi_hpl_OrderNumber_DoubleClick(object sender, EventArgs e)
        {
            int orderType = Convert.ToInt32(this.grvConfirmationAll.GetRowCellValue(this.grvConfirmationAll.FocusedRowHandle, "ordertype"));
            if (orderType == 1)
            {
                frm_WM_ReceivingOrders.Instance.ReceivingOrderIDFind = Convert.ToInt32(this.grvConfirmationAll.GetRowCellValue(this.grvConfirmationAll.FocusedRowHandle, "ID"));
                frm_WM_ReceivingOrders.Instance.Show();
            }
            else
            {
                var frmDispatching = frm_WM_DispatchingOrders.GetInstance(Convert.ToInt32(this.grvConfirmationAll.GetRowCellValue(this.grvConfirmationAll.FocusedRowHandle, "ID")));
                if (frmDispatching.Visible)
                {
                    frmDispatching.ReloadData();
                }
                frmDispatching.Show();
            }
        }

        private void grvConfirmationAll_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            DateTime orderDate = Convert.ToDateTime(this.grvConfirmationAll.GetRowCellValue(e.RowHandle, "OrderDate"));
            DateTime currentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            if (orderDate<currentDate)
            {
                e.Appearance.BackColor = Color.LightPink;
                //e.Appearance.ForeColor = Color.White;
            }
        }
    }
}
