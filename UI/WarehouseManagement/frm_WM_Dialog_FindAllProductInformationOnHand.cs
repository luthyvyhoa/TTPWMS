using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors;
using DA;
using DevExpress.XtraBars;
using System.Data;
using System.Linq;
using System.Data.Entity.Core.Objects;
using DevExpress.XtraEditors.DXErrorProvider;
using UI.WarehouseManagement;
using Common.Process;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_Dialog_FindAllProductInformationOnHand : Common.Controls.frmBaseForm
    {
        int m_CustomerID = 0;
        public frm_WM_Dialog_FindAllProductInformationOnHand()
        {
            InitializeComponent();

            SetEvent();
        }

        public frm_WM_Dialog_FindAllProductInformationOnHand(int customerID)
        {
            InitializeComponent();

            this.m_CustomerID = customerID;

            SetEvent();
        }
        void Frm_WM_Dialog_FindAllProductInformationOnHand_Load(object sender, EventArgs e)
        {
            string v_Caption = "";

            try
            {
                v_Caption = UI.Helper.AppSetting.CustomerList.Where(a => a.CustomerID == this.m_CustomerID).ToList().FirstOrDefault().CustomerName;
            }
            catch { }

            if (v_Caption != "")
            {
                this.Text = "Find All Products Of [" + v_Caption + "]";
            }
            else
            {
                this.Text = "Find All Products Of One Customer";
            }

            LoadData();
        }

        void SetEvent()
        {
            this.Load += Frm_WM_Dialog_FindAllProductInformationOnHand_Load;

            repItemHyperLinkEdit_Label.Click += RepItemHyperLinkEdit_Label_DoubleClick;
            repItemHyperLinkEdit_PalletID.Click += RepItemHyperLinkEdit_PalletID_DoubleClick;
            repItemHyperLinkEdit_ReceivingOrderID.Click += RepItemHyperLinkEdit_ReceivingOrderID_DoubleClick;
            repItemHyperLinkEdit_Remark.Click += RepItemHyperLinkEdit_Remark_DoubleClick;

            repItemButtonEdit_BreakPallets.Click += RepItemButtonEdit_BreakPallets_DoubleClick;
            repItemButtonEdit_StockMovement.Click += RepItemButtonEdit_StockMovement_DoubleClick;

            repItemCheckEdit_OnHold.Click += RepItemCheckEdit_Hold_DoubleClick;
        }

        #region Link
        void RepItemHyperLinkEdit_Remark_DoubleClick(object sender, EventArgs e)
        {

            string v_Remark = "";
            string v_ret = "";
            int v_PalletID = 0;

            try
            {
                v_Remark = Convert.ToString(bandedGridViewProductInfor.GetRowCellValue(bandedGridViewProductInfor.FocusedRowHandle, "Remark"));
                v_PalletID = Convert.ToInt32(bandedGridViewProductInfor.GetRowCellValue(bandedGridViewProductInfor.FocusedRowHandle, "PalletID"));
            }
            catch { }

            v_ret = XtraInputBox.Show("Please enter Remark :", "WMS", v_Remark);

            if (!v_Remark.Equals(v_ret))
            {
                string v_StrSQL = " UPDATE Pallets SET Remark = '" + v_ret + "' WHERE (PalletID = " + v_PalletID + " )";

                DA.Warehouse.PalletDA da = new DA.Warehouse.PalletDA();

                int result = da.ExecSQLString(v_StrSQL);

                LoadData();
            }
        }
        void RepItemButtonEdit_StockMovement_DoubleClick(object sender, EventArgs e)
        {
            int locationid = Convert.ToInt32(bandedGridViewProductInfor.GetRowCellValue(bandedGridViewProductInfor.FocusedRowHandle, "LocationID"));
            UI.StockTake.frm_ST_StockMovementNew frm = new UI.StockTake.frm_ST_StockMovementNew(locationid);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowInTaskbar = true;
            frm.Show();
        }

        void RepItemCheckEdit_Hold_DoubleClick(object sender, EventArgs e)
        {
            var HoldingDescription = "";
            HoldingDescription = XtraInputBox.Show("Please enter the reason :", "WMS", "Dan tem / Hu hong / mau...");
            if (string.IsNullOrEmpty(Convert.ToString(HoldingDescription)))
            {
                XtraMessageBox.Show("This entry is not correct !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {

                int v_PalletID = 0;
                try
                {
                    v_PalletID = Convert.ToInt32(bandedGridViewProductInfor.GetRowCellValue(bandedGridViewProductInfor.FocusedRowHandle, "PalletID"));
                }
                catch { }

                object v_Value = bandedGridViewProductInfor.GetRowCellValue(bandedGridViewProductInfor.FocusedRowHandle, "OnHold");

                if (v_Value.Equals(true))
                {
                    DA.Warehouse.PalletDA v_Da = new DA.Warehouse.PalletDA();
                    int v_Ret = v_Da.STQuarantineUpdate1Pallet(v_PalletID, 0, HoldingDescription, UI.Helper.AppSetting.CurrentUser.LoginName);
                    if (v_Ret >= 0)
                    {
                        bandedGridViewProductInfor.SetRowCellValue(bandedGridViewProductInfor.FocusedRowHandle, "OnHold", false);
                    }
                }
                else
                {
                    DA.Warehouse.PalletDA v_Da = new DA.Warehouse.PalletDA();
                    int v_Ret = v_Da.STQuarantineUpdate1Pallet(v_PalletID, 1, HoldingDescription, UI.Helper.AppSetting.CurrentUser.LoginName);

                    if (v_Ret >= 0)
                    {
                        bandedGridViewProductInfor.SetRowCellValue(bandedGridViewProductInfor.FocusedRowHandle, "OnHold", true);
                    }
                }
            }
        }
        void RepItemHyperLinkEdit_ReceivingOrderID_DoubleClick(object sender, EventArgs e)
        {
            int v_ReceivingOrderID = 0;
            try
            {
                v_ReceivingOrderID = Convert.ToInt32(bandedGridViewProductInfor.GetRowCellValue(bandedGridViewProductInfor.FocusedRowHandle, "ReceivingOrderID"));
            }
            catch { }

            WarehouseManagement.frm_WM_ReceivingOrders frm = frm_WM_ReceivingOrders.Instance;
            frm.ReceivingOrderIDFind = v_ReceivingOrderID;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowInTaskbar = false;
            frm.Show();
        }
        void RepItemHyperLinkEdit_Label_DoubleClick(object sender, EventArgs e)
        {
            int v_LocationID = 0;
            try
            {
                v_LocationID = Convert.ToInt32(bandedGridViewProductInfor.GetRowCellValue(bandedGridViewProductInfor.FocusedRowHandle, "LocationID"));
            }
            catch { }

            WarehouseManagement.frm_WM_Dialog_LocationDetail frm = new frm_WM_Dialog_LocationDetail(v_LocationID,3,false);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowInTaskbar = false;
            frm.Show(this);
        }
        void RepItemHyperLinkEdit_PalletID_DoubleClick(object sender, EventArgs e)
        {
            int v_PalletID = 0;

            try
            {
                v_PalletID = Convert.ToInt32(bandedGridViewProductInfor.GetRowCellValue(bandedGridViewProductInfor.FocusedRowHandle, "PalletID"));
            }
            catch { }

            WarehouseManagement.frm_WM_Dialog_PalletHistories frm = new frm_WM_Dialog_PalletHistories(v_PalletID);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowInTaskbar = false;
            frm.Show(this);

        }
        void RepItemButtonEdit_BreakPallets_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int v_palletID = Convert.ToInt32(bandedGridViewProductInfor.GetRowCellDisplayText(bandedGridViewProductInfor.FocusedRowHandle, bandedGridViewProductInfor.Columns["PalletID"]));
                int v_afterDPQuantity = Convert.ToInt32(bandedGridViewProductInfor.GetRowCellDisplayText(bandedGridViewProductInfor.FocusedRowHandle, bandedGridViewProductInfor.Columns["AfterDPQuantity"]));
                int v_currentQuantity = Convert.ToInt32(bandedGridViewProductInfor.GetRowCellDisplayText(bandedGridViewProductInfor.FocusedRowHandle, bandedGridViewProductInfor.Columns["CurrentQuantity"]));

                if (v_afterDPQuantity == v_currentQuantity)
                {
                    UI.WarehouseManagement.frm_WM_Dialog_BreakPallet frm = new frm_WM_Dialog_BreakPallet(v_afterDPQuantity, v_palletID);
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowInTaskbar = false;
                    frm.Show(this);
                }
                else
                {
                    XtraMessageBox.Show("This product is during dispatching process. Please break later !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch
            { }
        }

        #endregion Link

        #region Loaddata
        private void LoadData()
        {
            if (m_CustomerID > 0)
            {

                gridControlProducts.DataSource = (new DataProcess<STPalletInfoAll1Customer_Result>()).Executing("STPalletInfoAll1Customer @CustomerID = {0}", m_CustomerID);
            }
            else
            {
                gridControlProducts.DataSource = null;
            }
        }

        #endregion Loaddata

        private void bandedGridViewProductInfor_CustomDrawFooterCell(object sender, DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs e)
        {
            e.Appearance.DrawString(e.Cache, e.Info.DisplayText, e.Bounds);
            e.Handled = true;
        }
    }
}