using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DA;
using DevExpress.XtraReports.UI;
using UI.WarehouseManagement;
using Common.Process;
using DevExpress.XtraEditors.Controls;
using UI.Helper;
using UI.ReportForm;
using log4net;
using DevExpress.XtraBars;
using DevExpress.Utils.Menu;
using UI.Management;
using System.Data.SqlClient;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_PalletInfo : Common.Controls.frmBaseForm
    {
        // Declare log
        private static readonly ILog log = LogManager.GetLogger(typeof(frm_WM_PalletInfo));
        private string searchLocationText = string.Empty;
        private int searchLocationID = 0;
        class CActionForm
        {
            public static int LoadForm = 1;
            public static int Edit = 4;
            public static int Cancel = 6;
        }

        bool m_ShowRO = false;
        bool m_ShowDO = false;
        bool m_ShowDetail = false;
        bool m_FormLoad = false;

        int m_CustomerID = 0;
        int m_ProductID = 0;

        private DXMenuItem filterPupopMenu_Contain;
        private DXMenuItem filterPupopMenu_NotContain;
        DevExpress.XtraGrid.Views.Grid.GridView grvFilter = null;

        public frm_WM_PalletInfo()
        {
            InitializeComponent();
            this.KeyPreview = true;
            // Init default data 
            LoadData2repItemLookUpEdit_Location_PalletStatus();
            LoadData2lookUpEdit_CustomerID();
            LoadData2lookUpEdit_LocationID();
            this.InitFilterPupopMenu();
            SetEvent();
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }

        private void InitFilterPupopMenu()
        {
            // Create instance
            this.filterPupopMenu_Contain = new DXMenuItem();
            this.filterPupopMenu_NotContain = new DXMenuItem();

            // Init events
            this.filterPupopMenu_Contain.Click += FilterPupopMenu_Contain_Click; ;
            this.filterPupopMenu_NotContain.Click += FilterPupopMenu_Contain_Click;
        }

        private void FilterPupopMenu_Contain_Click(object sender, EventArgs e)
        {
            string equalString = "Contains([";
            string filter = grvFilter.ActiveFilterString;
            string value = (sender as DXMenuItem).Caption.Split('\'')[1];
            string filterType = (sender as DXMenuItem).Caption.Split('\'')[0];
            if (filterType.Contains("Filter by not contains "))
            {
                equalString = "Not Contains([";
            }
            string newFilterString = equalString + grvFilter.FocusedColumn.FieldName + "], '" + value + "')";

            if (filter == String.Empty)
                grvFilter.ActiveFilterString = newFilterString;
            else
                grvFilter.ActiveFilterString += "And " + newFilterString;
        }

        public frm_WM_PalletInfo(int i_CustomerID, int i_ProductID)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
            this.m_CustomerID = i_CustomerID;
            this.m_ProductID = i_ProductID;

            // Init default data 
            LoadData2repItemLookUpEdit_Location_PalletStatus();
            LoadData2lookUpEdit_CustomerID();
            LoadData2lookUpEdit_LocationID();
            this.InitFilterPupopMenu();
            SetEvent();
        }

        public void InitData(int i_CustomerID, int i_ProductID)
        {
            this.m_CustomerID = i_CustomerID;
            this.m_ProductID = i_ProductID;
            m_FormLoad = true;
            splitContainerControl_PnMain.PanelVisibility = SplitPanelVisibility.Panel1;
            splitContainerControl_PnLocationOrder.PanelVisibility = SplitPanelVisibility.Panel1;
            if (this.m_ProductID <= 0)
            {
                this.checkEdit_OnHand.Checked = true;
            }
            else
            {
                this.checkEdit_OnHand.Checked = false;
            }

            this.lke_WM_Customer.EditValue = this.m_CustomerID;

            if (this.m_CustomerID > 0)
            {
                STcomboCustomerID_Result v_Item = ((IList<STcomboCustomerID_Result>)lke_WM_Customer.Properties.DataSource).Where(c => c.CustomerID == this.m_CustomerID).FirstOrDefault();
                if (v_Item == null) return;
                HyperLinkEdit_CustomerName.Text = v_Item.CustomerName; ;
            }
            else
            {
                HyperLinkEdit_CustomerName.Text = "";
            }

            LoadData2lookUpEdit_ProductID(Convert.ToInt32(lke_WM_Customer.EditValue));
            this.lke_WM_Products.EditValue = this.m_ProductID;

            if (this.m_ProductID > 0)
            {
                Products v_Item = (new DataProcess<Products>()).Select(c => c.ProductID == this.m_ProductID).FirstOrDefault();

                HyperLinkEdit_ProductName.Text = v_Item.ProductName;
                spinEdit_WeightPerPackage.Value = Convert.ToDecimal(v_Item.WeightPerPackage);
                this.LoadLocations(this.m_ProductID);
            }
            else
            {
                HyperLinkEdit_ProductName.Text = "";
                spinEdit_WeightPerPackage.Value = 0;
            }

            SetEnableButton(CActionForm.LoadForm);

            m_FormLoad = false;
        }
        void Frm_WM_PalletInfo_Load(object sender, EventArgs e)
        {
            this.InitData(this.m_CustomerID, this.m_ProductID);
        }
        void SetEvent()
        {
            this.btnMove.Visibility = BarItemVisibility.Never;

            this.Load += Frm_WM_PalletInfo_Load;
            this.FormClosing += frm_WM_PalletInfo_FormClosing;

            btn_Change.ItemClick += Btn_Change_ItemClick;
            btn_MovementHistory.ItemClick += Btn_MovementHistory_ItemClick;
            btn_OnHand.ItemClick += Btn_OnHand_ItemClick;
            this.btnMove.ItemClick += Btn_Move_Click;
            btn_FindAllProductInformationOnHand.Click += Btn_FindAllProductInformationOnHand_Click;

            btn_ShowDetail.ItemClick += Btn_ShowDetail_ItemClick;
            btn_ShowRO.ItemClick += Btn_ShowRO_ItemClick;
            btn_ShowDO.ItemClick += Btn_ShowDO_ItemClick;

            btn_ReportA4.ItemClick += Btn_ReportA4_ItemClick;
            btn_ReportA4byRO.ItemClick += Btn_ReportA4byRO_ItemClick;
            btn_ReportA5.ItemClick += Btn_ReportA5_ItemClick;
            btn_ReportA5Filter.ItemClick += Btn_ReportA5Filter_ItemClick;
            btn_ReportDispatched.ItemClick += Btn_ReportDispatched_ItemClick;
            btn_ReportHistory.ItemClick += Btn_ReportHistory_ItemClick;

            btn_Close.ItemClick += Btn_Close_ItemClick;

            lke_WM_Customer.EditValueChanged += SearchLookUpEdit_CustomerID_EditValueChanged;
            lke_WM_Customer.Closed += SearchLookUpEdit_CustomerID_Closed;
            this.lke_WM_Products.EditValueChanged += this.lke_WM_Products_EditValueChanged;
            this.lkeSeachLocation.EditValueChanging += SearchLookUpEdit_LocationID_EditValueChanged;
            this.lkeSeachLocation.CloseUp += LkeSeachLocation_CloseUp;

            gridViewLocations.CellValueChanged += GridViewLocations_CellValueChanged;
            gridViewLocations.RowCellStyle += gridViewLocations_RowCellStyle;
            gridViewLocations.CustomDrawFooterCell += gridViewLocations_CustomDrawFooterCell;
            gridViewLocations.ShownEditor += GridViewLocations_ShownEditor;
            gridViewLocations.FocusedRowChanged += GridViewLocations_FocusedRowChanged;

            gridViewRO.FocusedRowChanged += GridViewRO_FocusedRowChanged;
            gridViewDO.FocusedRowChanged += GridViewDO_FocusedRowChanged;
            gridViewDO.FocusedColumnChanged += GridViewDO_FocusedColumnChanged;
            gridViewRO.FocusedColumnChanged += GridViewRO_FocusedColumnChanged;
            gridViewRO.ShownEditor += GridViewLocations_ShownEditor;
            gridViewDO.ShownEditor += GridViewLocations_ShownEditor;

            HyperLinkEdit_CustomerName.Click += HyperLinkEdit_CustomerName_DoubleClick;
            HyperLinkEdit_ProductName.Click += HyperLinkEdit_ProductName_DoubleClick;

            checkEdit_OnHand.CheckedChanged += CheckEdit_OnHand_CheckedChanged;
            repItemHyperLinkEdit_ReceivingOrderID.Click += RepItemHyperLinkEdit_RO_ReceivingOrderID_DoubleClick;
            repItemHyperLinkEdit_DispatchingOrderID.Click += RepItemHyperLinkEdit_DispatchingOrderID_DoubleClick;

            //repItemButtonEdit_Location_BreakPallet.Click += RepItemButtonEdit_Location_BreakPallet_DoubleClick;
            //repItemButtonEdit_Location_StockMovement.Click += RepItemButtonEdit_Location_StockMovement_DoubleClick;

            repItemCheckEdit_Location_CanNotAdd.Click += RepItemCheckEdit_Location_CanNotAdd_DoubleClick;

            repItemHyperLinkEdit_Location_ReceivingOrderID.Click += RepItemHyperLinkEdit_Location_ReceivingOrderID_DoubleClick;
            repItemHyperLinkEdit_Location_Label.Click += RepItemHyperLinkEdit_Location_Label_DoubleClick;
            repItemHyperLinkEdit_Location_PalletID.Click += RepItemHyperLinkEdit_Location_PalletID_DoubleClick;
            repItemHyperLinkEdit_Location_Remark.Click += RepItemHyperLinkEdit_Location_Remark_DoubleClick;

            repItemHyperLinkEdit_RO_CustomerRef.Click += RepItemHyperLinkEdit_RO_CustomerRef_DoubleClick;
            repItemTextEdit_RO_ProductionDate.Click += RepItemTextEdit_RO_ProductionDate_DoubleClick;
            repItemTextEdit_RO_UseByDate.Click += RepItemTextEdit_RO_UseByDate_DoubleClick;
        }

        private void LkeSeachLocation_CloseUp(object sender, CloseUpEventArgs e)
        {
            DevExpress.XtraEditors.LookUpEdit edit;
            edit = sender as DevExpress.XtraEditors.LookUpEdit;
            edit.EditValue = e.Value;
            if (edit.EditValue == null) return;
            this.searchLocationText = edit.Text;
            this.searchLocationID = (int)edit.EditValue;
        }

        private void GridViewLocations_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.grvFilter = this.gridViewLocations;
        }

        private void GridViewLocations_ShownEditor(object sender, EventArgs e)
        {
            var editor = this.grvFilter.ActiveEditor as TextEdit;
            if (editor == null) return;
            editor.Properties.BeforeShowMenu += Properties_BeforeShowMenuDO;
        }

        private void Properties_BeforeShowMenuDO(object sender, DevExpress.XtraEditors.Controls.BeforeShowMenuEventArgs e)
        {
            string textDO = (sender as TextEdit).SelectedText;

            if (textDO != String.Empty)
            {
                this.filterPupopMenu_Contain.Caption = "Filter by contains '" + textDO + "'";
                this.filterPupopMenu_NotContain.Caption = "Filter by not contains '" + textDO + "'";
                this.filterPupopMenu_Contain.Visible = true;
                this.filterPupopMenu_NotContain.Visible = true;
                if (e.Menu.Items.Count > 6)
                {
                    int redundancyCount = e.Menu.Items.Count - 6;
                    for (int i = 0; i < redundancyCount; i++)
                    {
                        e.Menu.Items.RemoveAt(6);
                    }
                }
                e.Menu.Items.Add(this.filterPupopMenu_Contain);
                e.Menu.Items.Add(this.filterPupopMenu_NotContain);
            }
        }

        void frm_WM_PalletInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        //=======================================================================================================
        void RepItemCheckEdit_Location_CanNotAdd_DoubleClick(object sender, EventArgs e)
        {
            int v_PalletID = 0;
            try
            {
                v_PalletID = Convert.ToInt32(gridViewLocations.GetRowCellValue(gridViewLocations.FocusedRowHandle, "PalletID"));
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
            }

            object v_Value = gridViewLocations.GetRowCellValue(gridViewLocations.FocusedRowHandle, "CanNotAdd");

            if (v_Value.Equals(true))
            {
                string v_StrSQL = "Update Pallets SET CanNotAdd = 0 WHERE PalletID = " + v_PalletID + " ";
                DA.Warehouse.PalletDA v_Da = new DA.Warehouse.PalletDA();
                int v_Ret = v_Da.ExecSQLString(v_StrSQL);
                if (v_Ret >= 0)
                {
                    gridViewLocations.SetRowCellValue(gridViewLocations.FocusedRowHandle, "CanNotAdd", false);
                }
            }
            else
            {
                string v_StrSQL = "Update Pallets SET CanNotAdd = 1 WHERE PalletID = " + v_PalletID + " ";
                DA.Warehouse.PalletDA v_Da = new DA.Warehouse.PalletDA();
                int v_Ret = v_Da.ExecSQLString(v_StrSQL);
                if (v_Ret >= 0)
                {
                    gridViewLocations.SetRowCellValue(gridViewLocations.FocusedRowHandle, "CanNotAdd", true);
                }
            }
        }

        void RepItemButtonEdit_Location_StockMovement_DoubleClick(object sender, EventArgs e)
        {
            int locationid = Convert.ToInt32(gridViewLocations.GetRowCellValue(gridViewLocations.FocusedRowHandle, "LocationID"));
            UI.StockTake.frm_ST_StockMovementNew frm = new StockTake.frm_ST_StockMovementNew(locationid);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowInTaskbar = true;
            frm.Show();
        }
        void RepItemButtonEdit_Location_BreakPallet_DoubleClick(object sender, EventArgs e)
        {
            int v_PalletID = 0;
            int v_afterDPQuantity = 0;
            int v_currentQuantity = 0;

            try
            {
                v_PalletID = Convert.ToInt32(gridViewLocations.GetRowCellDisplayText(gridViewLocations.FocusedRowHandle, gridViewLocations.Columns["PalletID"]));
            }
            catch { }
            try
            {
                v_afterDPQuantity = Convert.ToInt32(gridViewLocations.GetRowCellDisplayText(gridViewLocations.FocusedRowHandle, gridViewLocations.Columns["AfterDPQuantity"]));
            }
            catch { }
            try
            {
                v_currentQuantity = Convert.ToInt32(gridViewLocations.GetRowCellDisplayText(gridViewLocations.FocusedRowHandle, gridViewLocations.Columns["CurrentQuantity"]));
            }
            catch { }

            if (v_afterDPQuantity == v_currentQuantity)
            {
                frm_WM_Dialog_BreakPallet breakPalletForm = new frm_WM_Dialog_BreakPallet(v_afterDPQuantity, v_PalletID);
                if (!breakPalletForm.Enabled) return;
                if (breakPalletForm.ShowDialog(this) == DialogResult.OK)
                {

                    int v_ProductID = 0;

                    try
                    {
                        v_ProductID = Convert.ToInt32(this.lke_WM_Products.EditValue);
                    }
                    catch { }

                    LoadLocations(v_ProductID);
                }
            }
            else
            {
                XtraMessageBox.Show("This product is during dispatching process, please break later !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        void RepItemHyperLinkEdit_Location_PalletID_DoubleClick(object sender, EventArgs e)
        {
            int v_PalletID = 0;

            try
            {
                v_PalletID = Convert.ToInt32(gridViewLocations.GetRowCellValue(gridViewLocations.FocusedRowHandle, "PalletID"));
            }
            catch { }

            WarehouseManagement.frm_WM_Dialog_PalletHistories frm = new frm_WM_Dialog_PalletHistories(v_PalletID);
            if (!frm.Enabled) return;
            frm.StartPosition = FormStartPosition.CenterScreen;
            //frm.ShowInTaskbar = false;
            frm.ShowDialog();
        }
        void RepItemHyperLinkEdit_Location_Label_DoubleClick(object sender, EventArgs e)
        {
            int v_LocationID = 0;
            try
            {
                v_LocationID = Convert.ToInt32(gridViewLocations.GetRowCellValue(gridViewLocations.FocusedRowHandle, "LocationID"));
            }
            catch { }

            WarehouseManagement.frm_WM_Dialog_LocationDetail frm = new frm_WM_Dialog_LocationDetail(v_LocationID, 3, false);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowInTaskbar = false;
            frm.Show(this);
        }
        void RepItemHyperLinkEdit_Location_ReceivingOrderID_DoubleClick(object sender, EventArgs e)
        {
            int v_ReceivingOrderID = 0;

            try
            {
                v_ReceivingOrderID = Convert.ToInt32(gridViewLocations.GetRowCellValue(gridViewLocations.FocusedRowHandle, "ReceivingOrderID"));
            }
            catch { }

            WarehouseManagement.frm_WM_ReceivingOrders frm = frm_WM_ReceivingOrders.Instance;
            frm.ReceivingOrderIDFind = v_ReceivingOrderID;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowInTaskbar = false;
            frm.Show();
        }
        void RepItemHyperLinkEdit_Location_Remark_DoubleClick(object sender, EventArgs e)
        {
            string v_Remark = "";
            int v_PalletID = 0;

            try
            {
                v_Remark = Convert.ToString(gridViewLocations.GetRowCellValue(gridViewLocations.FocusedRowHandle, "Remark"));
                v_PalletID = Convert.ToInt32(gridViewLocations.GetRowCellValue(gridViewLocations.FocusedRowHandle, "PalletID"));
            }
            catch { }

            string v_RetRemark = XtraInputBox.Show("Please enter Remark :", "WMS - " + Convert.ToString(v_PalletID), v_Remark);
            if (string.IsNullOrEmpty(v_RetRemark)) return;

            string v_StrSQL = " UPDATE Pallets SET Remark = '" + v_RetRemark + "' WHERE (PalletID = " + v_PalletID + " )";

            DA.Warehouse.PalletDA da = new DA.Warehouse.PalletDA();

            int result = da.ExecSQLString(v_StrSQL);

            int v_ProductID = 0;

            try
            {
                v_ProductID = Convert.ToInt32(this.lke_WM_Products.EditValue);
            }
            catch { }

            LoadLocations(v_ProductID);

        }

        void RepItemHyperLinkEdit_DispatchingOrderID_DoubleClick(object sender, EventArgs e)
        {
            int v_DispatchingOrderID = 0;
            try
            {
                v_DispatchingOrderID = Convert.ToInt32(gridViewDO.GetRowCellValue(gridViewDO.FocusedRowHandle, "DispatchingOrderID"));
            }
            catch { }

            WarehouseManagement.frm_WM_DispatchingOrders frm = frm_WM_DispatchingOrders.GetInstance(v_DispatchingOrderID);
            if (frm.Visible)
            {
                frm.ReloadData();
            }
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowInTaskbar = false;
            frm.Show();
            frm.BringToFront();
        }

        void RepItemHyperLinkEdit_RO_ReceivingOrderID_DoubleClick(object sender, EventArgs e)
        {
            int v_ReceivingOrderID = 0;
            try
            {
                v_ReceivingOrderID = Convert.ToInt32(gridViewRO.GetRowCellValue(gridViewRO.FocusedRowHandle, "ReceivingOrderID"));
            }
            catch
            { }

            WarehouseManagement.frm_WM_ReceivingOrders frm = frm_WM_ReceivingOrders.Instance;
            frm.ReceivingOrderIDFind = v_ReceivingOrderID;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowInTaskbar = false;
            frm.Show();
            frm.BringToFront();
        }
        void RepItemHyperLinkEdit_RO_CustomerRef_DoubleClick(object sender, EventArgs e)
        {
            string v_CustomerRef = "";
            int v_ReceivingOrderID = 0;
            int v_ReceivingOrderDetailID = 0;

            try
            {
                v_CustomerRef = Convert.ToString(gridViewRO.GetRowCellValue(gridViewRO.FocusedRowHandle, "CustomerRef"));
                v_ReceivingOrderID = Convert.ToInt32(gridViewRO.GetRowCellValue(gridViewRO.FocusedRowHandle, "ReceivingOrderID"));
                v_ReceivingOrderDetailID = Convert.ToInt32(gridViewRO.GetRowCellValue(gridViewRO.FocusedRowHandle, "ReceivingOrderDetailID"));
            }
            catch { }

            string v_RetCustomerRef = XtraInputBox.Show("Please enter new Customer Reference", "WMS - " + Convert.ToString(v_ReceivingOrderID), (string.IsNullOrEmpty(v_CustomerRef) ? "..." : v_CustomerRef));

            if (string.IsNullOrEmpty(v_RetCustomerRef))
            {
                //XtraMessageBox.Show("Wrong entry !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                try
                {
                    v_RetCustomerRef = v_RetCustomerRef.Substring(0, 30);
                }
                catch (Exception ex)
                {
                    log.Error("==> Error is unexpected");
                    log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                }

                string v_StrSQL = " UPDATE ReceivingOrderDetails SET CustomerRef = '" + v_RetCustomerRef + "' WHERE (ReceivingOrderDetailID = " + v_ReceivingOrderDetailID + " )";

                DA.Warehouse.PalletDA da = new DA.Warehouse.PalletDA();

                int result = da.ExecSQLString(v_StrSQL);

                int v_ProductID = 0;

                try
                {
                    v_ProductID = Convert.ToInt32(this.lke_WM_Products.EditValue);
                }
                catch { }

                LoadRO(v_ProductID);
            }
        }
        void RepItemTextEdit_RO_ProductionDate_DoubleClick(object sender, EventArgs e)
        {
            DateTime productionDate = DateTime.Now;
            int receivingOrderID = 0;
            int receivingOrderDetailID = 0;
            int v_TotalPackages = 0;
            DateTime receivingOrderDate = DateTime.Now;

            try
            {
                productionDate = Convert.ToDateTime(gridViewRO.GetRowCellValue(gridViewRO.FocusedRowHandle, "ProductionDate"));
                receivingOrderID = Convert.ToInt32(gridViewRO.GetRowCellValue(gridViewRO.FocusedRowHandle, "ReceivingOrderID"));
                receivingOrderDetailID = Convert.ToInt32(gridViewRO.GetRowCellValue(gridViewRO.FocusedRowHandle, "ReceivingOrderDetailID"));
                v_TotalPackages = Convert.ToInt32(gridViewRO.GetRowCellValue(gridViewRO.FocusedRowHandle, "TotalPackages"));
                receivingOrderDate = Convert.ToDateTime(gridViewRO.GetRowCellValue(gridViewRO.FocusedRowHandle, "ReceivingOrderDate"));
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
            }

            var canChangeDate = this.CheckRoleUser(receivingOrderDate);
            if (!canChangeDate)
            {
                XtraMessageBox.Show("Product is Confirmed, only Supervisor can do the change !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int v_AfterDPQuantity = ((new DataProcess<Pallets>()).Select(c => c.ReceivingOrderDetailID == receivingOrderDetailID)).Sum(c => c.AfterDPQuantity);
            if (v_TotalPackages != v_AfterDPQuantity)
            {
                XtraMessageBox.Show("Product is dispatched !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            {
                var changeProductDateFrm = new frm_WM_ChangeProductDate(productionDate);
                // Handle call back action after user click Accept button on frm_WM_ChangeProductDate
                changeProductDateFrm.OnAcceptCallbackAction = (newDate, reason) =>
                {
                    this.HandleProductDateChanged(newDate, reason, receivingOrderID, receivingOrderDetailID, productionDate, "ProductionDate");
                };
                changeProductDateFrm.ShowDialog();

                var productID = 0;
                int.TryParse(this.lke_WM_Products.EditValue.ToString(), out productID);

                // Reload data after update
                LoadRO(productID);
            }
        }

        void RepItemTextEdit_RO_UseByDate_DoubleClick(object sender, EventArgs e)
        {
            DateTime v_UseByDate = DateTime.Now;
            int receivingOrderID = 0;
            int receivingOrderDetailID = 0;
            int rotalPackages = 0;
            DateTime receivingOrderDate = DateTime.Now;
            try
            {
                receivingOrderDate = Convert.ToDateTime(gridViewRO.GetRowCellValue(gridViewRO.FocusedRowHandle, "ReceivingOrderDate"));
                v_UseByDate = Convert.ToDateTime(gridViewRO.GetRowCellValue(gridViewRO.FocusedRowHandle, "UseByDate"));
                receivingOrderID = Convert.ToInt32(gridViewRO.GetRowCellValue(gridViewRO.FocusedRowHandle, "ReceivingOrderID"));
                receivingOrderDetailID = Convert.ToInt32(gridViewRO.GetRowCellValue(gridViewRO.FocusedRowHandle, "ReceivingOrderDetailID"));
                rotalPackages = Convert.ToInt32(gridViewRO.GetRowCellValue(gridViewRO.FocusedRowHandle, "TotalPackages"));
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
            }

            var canChangeDate = this.CheckRoleUser(receivingOrderDate);
            if (!canChangeDate)
            {
                XtraMessageBox.Show("Product is Confirmed, can't do the change !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int v_AfterDPQuantity = ((new DataProcess<Pallets>()).Select(c => c.ReceivingOrderDetailID == receivingOrderDetailID)).Sum(c => c.AfterDPQuantity);
            if (rotalPackages != v_AfterDPQuantity)
            {
                XtraMessageBox.Show("Product is dispatched !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            {
                var changeProductDateFrm = new frm_WM_ChangeProductDate(v_UseByDate);
                changeProductDateFrm.OnAcceptCallbackAction = (newDate, reason) =>
                {
                    this.HandleProductDateChanged(newDate, reason, receivingOrderID, receivingOrderDetailID, v_UseByDate, "UseByDate");
                };

                changeProductDateFrm.ShowDialog();

                var productID = 0;
                int.TryParse(this.lke_WM_Products.EditValue.ToString(), out productID);

                // Reload data after update
                LoadRO(productID);
            }
        }

        void HyperLinkEdit_ProductName_DoubleClick(object sender, EventArgs e)
        {
            int v_ProductID = 0;
            try
            {
                v_ProductID = Convert.ToInt32(this.lke_WM_Products.EditValue);
            }
            catch { }

            if (v_ProductID > 0)
            {

                MasterSystemSetup.frm_MSS_Products frm = MasterSystemSetup.frm_MSS_Products.Instance;
                frm.ProductIDLookup = v_ProductID;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowInTaskbar = false;
                frm.Show();
            }
        }
        void HyperLinkEdit_CustomerName_DoubleClick(object sender, EventArgs e)
        {
            int v_CustomerID = 0;

            try
            {
                v_CustomerID = Convert.ToInt32(lke_WM_Customer.EditValue);
            }
            catch { }

            if (v_CustomerID > 0)
            {
                var currentCustomer = AppSetting.CustomerList.Where(c => c.CustomerID == v_CustomerID).FirstOrDefault();
                MasterSystemSetup.frm_MSS_Customers frm = MasterSystemSetup.frm_MSS_Customers.Instance;
                frm.CurrentCustomers = currentCustomer;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.WindowState = FormWindowState.Normal;
                frm.BringToFront();
                frm.ShowInTaskbar = false;
                frm.Show();
            }
        }
        void CheckEdit_OnHand_CheckedChanged(object sender, EventArgs e)
        {
            int v_CustomerID = 0;
            try
            {
                v_CustomerID = (int)lke_WM_Customer.EditValue;
            }
            catch { }

            LoadData2lookUpEdit_ProductID(v_CustomerID);

            this.lke_WM_Products.Focus();
            this.lke_WM_Products.ShowPopup();
        }
        void GridViewRO_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            try
            {
                GetROInfo();
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
            }
        }
        void GridViewDO_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            try
            {
                GetDOInfo();
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
            }
        }
        void GridViewDO_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                this.grvFilter = this.gridViewDO;
                GetDOInfo();
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
            }
        }
        void GridViewRO_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                this.grvFilter = this.gridViewRO;
                GetROInfo();
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
            }
        }
        void GridViewLocations_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName.ToUpper().Equals("PalletStatus".ToUpper()))
            {
                int v_PalletID = 0;
                byte v_PalletStatus = 0;

                try
                {
                    v_PalletID = Convert.ToInt32(gridViewLocations.GetRowCellValue(gridViewLocations.FocusedRowHandle, "PalletID"));
                }
                catch { }

                try
                {
                    v_PalletStatus = Convert.ToByte(gridViewLocations.GetRowCellValue(gridViewLocations.FocusedRowHandle, "PalletStatus"));
                }
                catch { }


                DA.Warehouse.PalletDA da = new DA.Warehouse.PalletDA();

                int result = da.STPalletInfo_Locations_UpdatePalletStatus(v_PalletID, v_PalletStatus, UI.Helper.AppSetting.CurrentUser.LoginName);

                int v_ProductID = 0;

                try
                {
                    v_ProductID = Convert.ToInt32(this.lke_WM_Products.EditValue);
                }
                catch { }

                LoadLocations(v_ProductID);

            }

        }
        void SearchLookUpEdit_LocationID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.btnMove.Visibility = BarItemVisibility.Always;
            }
            catch
            {
                this.btnMove.Visibility = BarItemVisibility.Never;
            }
        }
        void lke_WM_Products_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string v_ProductID = Convert.ToString(this.lke_WM_Products.EditValue);
                if (!string.IsNullOrEmpty(v_ProductID) && !v_ProductID.Equals("0"))
                {
                    int productID = Convert.ToInt32(this.lke_WM_Products.EditValue);
                    decimal weightPerPackage = 0;
                    string name = string.Empty;
                    if (this.checkEdit_OnHand.Checked)
                    {
                        var view = (ST_WMS_tmpProductRemains_Result)this.lke_WM_Products.GetSelectedDataRow();
                        if (view != null)
                        {
                            weightPerPackage = (decimal)view.WeightPerPackage;
                            name = view.Name;
                            this.Text = view.Product + " - " + view.Name;
                        }
                        else
                        {
                            HyperLinkEdit_ProductName.Text = "";
                            spinEdit_WeightPerPackage.Value = 0;
                        }
                    }
                    else
                    {
                        var view = (STComboProductID_Result)this.lke_WM_Products.GetSelectedDataRow();
                        if (view != null)
                        {
                            weightPerPackage = (decimal)view.WeightPerPackage;
                            name = view.Name;
                        }
                        else
                        {
                            HyperLinkEdit_ProductName.Text = "";
                            spinEdit_WeightPerPackage.Value = 0;
                        }
                    }
                    if (productID > 0)
                    {
                        HyperLinkEdit_ProductName.Text = name;
                        spinEdit_WeightPerPackage.Value = weightPerPackage;
                    }
                    else
                    {
                        HyperLinkEdit_ProductName.Text = "";
                        spinEdit_WeightPerPackage.Value = 0;
                    }

                    LoadLocations(productID);
                    LoadRO(productID);
                    LoadDO(productID);
                }
                else
                {
                    HyperLinkEdit_ProductName.Text = "";
                    spinEdit_WeightPerPackage.Value = 0;
                    gridControlLocations.DataSource = null;
                    gridControlRO.DataSource = null;
                    gridControlDO.DataSource = null;
                    gridControlRODO.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);

                HyperLinkEdit_ProductName.Text = "";
                spinEdit_WeightPerPackage.Value = 0;
            }
        }
        void SearchLookUpEdit_CustomerID_EditValueChanged(object sender, EventArgs e)
        {
            if (m_FormLoad) return;

            try
            {
                int v_CustomerID = (int)lke_WM_Customer.EditValue;
                HyperLinkEdit_CustomerName.Text = lke_WM_Customer.GetColumnValue("CustomerName").ToString();

                LoadData2lookUpEdit_ProductID(v_CustomerID);
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);

                HyperLinkEdit_CustomerName.Text = "";
            }
        }
        void SearchLookUpEdit_CustomerID_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            this.lke_WM_Products.Focus();
            this.lke_WM_Products.ShowPopup();
        }
        void Btn_ReportA5Filter_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var filteredText = this.gridViewLocations.FilterPanelText;
            var palletIDList = new List<int>();
            for (int i = 0; i < this.gridViewLocations.RowCount; i++)
            {
                var rowData = this.gridViewLocations.GetRow(i) as ST_WMS_PalletInfo_Locations_NotRO_Result;
                if (rowData != null)
                {
                    palletIDList.Add(rowData.PalletID);
                }
            }
            var condition = string.Join(",", palletIDList);
            var dataSource = FileProcess.LoadTable("STPalletInforReport @CustomerID = " + Convert.ToInt32(this.lke_WM_Customer.EditValue) + ", @ProductID = " + Convert.ToInt32(this.lke_WM_Products.EditValue));
            var filteredRows = dataSource.Select($"PalletID IN ({condition})");
            var filteredDataSource = dataSource.Clone(); // Just clone table structure, no copy table data

            foreach (var row in filteredRows)
            {
                var addingRow = filteredDataSource.NewRow();

                for (int i = 0; i < row.ItemArray.Length; i++)
                {
                    addingRow[i] = row[i];
                }

                filteredDataSource.Rows.Add(addingRow);
            }

            var rpt = new UI.ReportFile.rptPalletInfoA5Filter();
            rpt.DataSource = filteredDataSource;
            rpt.xrLabelFilterFor.Text = filteredText;
            rpt.RequestParameters = false;
            var designer = new ReportPrintToolWMS(rpt);
            designer.ShowPreview();
        }
        void Btn_ReportA5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (lke_WM_Customer.EditValue == null) return;
            if (lke_WM_Products.EditValue == null) return;
            var dataSource = FileProcess.LoadTable("STPalletInforReport @CustomerID=" + (int)this.lke_WM_Customer.EditValue + ", @ProductID=" + (int)this.lke_WM_Products.EditValue);
            var rpt = new UI.ReportFile.rptPalletInfoA4();
            rpt.PaperKind = System.Drawing.Printing.PaperKind.A5;
            rpt.Landscape = true;
            rpt.DataSource = dataSource;
            rpt.Print();
        }
        void Btn_ReportA4byRO_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (lke_WM_Customer.EditValue == null) return;
            if (lke_WM_Products.EditValue == null) return;
            var dataSource = FileProcess.LoadTable("STPalletInforReport @CustomerID=" + (int)this.lke_WM_Customer.EditValue + ", @ProductID=" + (int)this.lke_WM_Products.EditValue);
            var rpt = new UI.ReportFile.rptPalletInfoA4ByRO();
            rpt.DataSource = dataSource;
            rpt.Print();
        }
        void Btn_ReportA4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (lke_WM_Customer.EditValue == null) return;
            if (lke_WM_Products.EditValue == null) return;
            var dataSource = FileProcess.LoadTable("STPalletInforReport @CustomerID=" + (int)this.lke_WM_Customer.EditValue + ", @ProductID=" + (int)this.lke_WM_Products.EditValue);
            var rpt = new UI.ReportFile.rptPalletInfoA4();
            rpt.DataSource = dataSource;
            rpt.Print();
        }
        void Btn_ReportDispatched_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (lke_WM_Customer.EditValue == null) return;
            if (lke_WM_Products.EditValue == null) return;
            var dataSource = FileProcess.LoadTable("STPalletInforReport @CustomerID=" + (int)this.lke_WM_Customer.EditValue + ", @ProductID=" + (int)this.lke_WM_Products.EditValue);
            var rpt = new UI.ReportFile.rptPalletInfoA4();
            rpt.DataSource = dataSource;
            rpt.Print();
        }
        void Btn_ReportHistory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (lke_WM_Products.EditValue == null) return;
            int productID = Convert.ToInt32(lke_WM_Products.EditValue);
            frm_WM_PalletHistoryInputDate orderDate = new frm_WM_PalletHistoryInputDate(productID);
            if (!orderDate.Enabled) return;
            orderDate.ShowDialog();
        }

        void Btn_ShowDO_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (m_ShowDO == false)
            {
                this.btn_ShowDO.ImageOptions.LargeImage = global::UI.Properties.Resources.Next_32x32;
                m_ShowDO = true;
            }
            else
            {
                this.btn_ShowDO.ImageOptions.LargeImage = global::UI.Properties.Resources.Previous_32x32;
                m_ShowDO = false;
            }


            if (m_ShowDO == true && m_ShowRO == true)
            {
                splitContainerControl_PnLocationOrder.PanelVisibility = SplitPanelVisibility.Both;
                splitContainerControl_PnOrder.PanelVisibility = SplitPanelVisibility.Both;
            }
            else if (m_ShowDO == true && m_ShowRO == false)
            {
                splitContainerControl_PnLocationOrder.PanelVisibility = SplitPanelVisibility.Both;
                splitContainerControl_PnOrder.PanelVisibility = SplitPanelVisibility.Panel2;
            }
            else if (m_ShowDO == false && m_ShowRO == true)
            {
                splitContainerControl_PnLocationOrder.PanelVisibility = SplitPanelVisibility.Both;
                splitContainerControl_PnOrder.PanelVisibility = SplitPanelVisibility.Panel1;
            }
            else if (m_ShowDO == false && m_ShowRO == false)
            {
                splitContainerControl_PnLocationOrder.PanelVisibility = SplitPanelVisibility.Panel1;
            }

        }
        void Btn_ShowRO_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (m_ShowRO == false)
            {
                this.btn_ShowRO.ImageOptions.LargeImage = global::UI.Properties.Resources.Next_32x32;
                m_ShowRO = true;
            }
            else
            {
                this.btn_ShowRO.ImageOptions.LargeImage = global::UI.Properties.Resources.Previous_32x32;
                m_ShowRO = false;
            }

            if (m_ShowDO == true && m_ShowRO == true)
            {
                splitContainerControl_PnLocationOrder.PanelVisibility = SplitPanelVisibility.Both;
                splitContainerControl_PnOrder.PanelVisibility = SplitPanelVisibility.Both;
            }
            else if (m_ShowDO == true && m_ShowRO == false)
            {
                splitContainerControl_PnLocationOrder.PanelVisibility = SplitPanelVisibility.Both;
                splitContainerControl_PnOrder.PanelVisibility = SplitPanelVisibility.Panel2;
            }
            else if (m_ShowDO == false && m_ShowRO == true)
            {
                splitContainerControl_PnLocationOrder.PanelVisibility = SplitPanelVisibility.Both;
                splitContainerControl_PnOrder.PanelVisibility = SplitPanelVisibility.Panel1;
            }
            else if (m_ShowDO == false && m_ShowRO == false)
            {
                splitContainerControl_PnLocationOrder.PanelVisibility = SplitPanelVisibility.Panel1;
            }
        }
        void Btn_ShowDetail_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (m_ShowDetail == false)
            {
                splitContainerControl_PnMain.PanelVisibility = SplitPanelVisibility.Both;
                this.btn_ShowDetail.ImageOptions.LargeImage = global::UI.Properties.Resources.Next_32x32;
                m_ShowDetail = true;
            }
            else
            {
                splitContainerControl_PnMain.PanelVisibility = SplitPanelVisibility.Panel1;
                this.btn_ShowDetail.ImageOptions.LargeImage = global::UI.Properties.Resources.Previous_32x32;
                m_ShowDetail = false;
            }
        }

        void Btn_FindAllProductInformationOnHand_Click(object sender, EventArgs e)
        {
            int v_CustomerID = 0;

            try
            {
                v_CustomerID = Convert.ToInt32(lke_WM_Customer.EditValue);
            }
            catch
            { }

            UI.WarehouseManagement.frm_WM_Dialog_FindAllProductInformationOnHand frm = new UI.WarehouseManagement.frm_WM_Dialog_FindAllProductInformationOnHand(v_CustomerID);
            frm.ShowInTaskbar = false;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show(this);
        }
        void Btn_Move_Click(object sender, EventArgs e)
        {
            // get text
            if (XtraMessageBox.Show("Are you sure to move all the pallets to new location " + this.searchLocationText + " ? ", "WMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int v_LocationID = 0;
                int v_ProductID = 0;
                string v_LocationNumber = "";

                try
                {
                    v_LocationID = this.searchLocationID;
                }
                catch { }

                try
                {
                    v_ProductID = Convert.ToInt32(this.lke_WM_Products.EditValue);
                }
                catch { }

                try
                {
                    v_LocationNumber = this.searchLocationText;
                }
                catch { }

                if (v_LocationID <= 0 || string.IsNullOrEmpty(v_LocationNumber)) return;
                string v_StrSQL = "";
                v_StrSQL += " UPDATE Pallets ";
                v_StrSQL += " SET LocationID = " + v_LocationID + " ";
                v_StrSQL += " , Label = '" + v_LocationNumber + "' ";
                v_StrSQL += " , Remark = ISNULL(Pallets.Remark, '') + Locations.LocationNumber ";
                v_StrSQL += " FROM Pallets INNER JOIN ReceivingOrderDetails ON Pallets.ReceivingOrderDetailID = ReceivingOrderDetails.ReceivingOrderDetailID ";
                v_StrSQL += " INNER JOIN Locations ON Pallets.LocationID = Locations.LocationID ";
                v_StrSQL += " WHERE(ReceivingOrderDetails.ProductID = " + v_ProductID + ") AND(Pallets.CurrentQuantity > 0) ";

                DA.Master.ProductDA da = new DA.Master.ProductDA();

                int result = da.ExecSQLString(v_StrSQL);

                LoadLocations(v_ProductID);

                this.lke_WM_Products.Focus();
                this.blke_SearchLocation.EditValue = 0;
                this.btnMove.Visibility = BarItemVisibility.Never;
            }
            else
            {
                this.lke_WM_Products.Focus();
                this.blke_SearchLocation.EditValue = 0;
                this.btnMove.Visibility = BarItemVisibility.Never;
            }
        }
        void Btn_MovementHistory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int v_PalletID = 0;

            try
            {
                v_PalletID = Convert.ToInt32(gridViewLocations.GetRowCellValue(gridViewLocations.FocusedRowHandle, "PalletID"));
            }
            catch { }
            if (v_PalletID > 0)
            {
                frm_WM_Dialog_StockMovementReview frm = new frm_WM_Dialog_StockMovementReview(v_PalletID);
                if (!frm.Enabled) return;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowInTaskbar = false;
                frm.ShowDialog();
            }
        }
        void Btn_Change_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MessageBox.Show("Chức năng này tạm thời bị khoá!", "TWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;

            int v_CustomerID = 0;
            int v_ProductID = 0;
            decimal v_WeightPerPackage = 0;

            try
            {
                v_CustomerID = Convert.ToInt32(lke_WM_Customer.EditValue);
            }
            catch { }

            try
            {
                v_ProductID = Convert.ToInt32(this.lke_WM_Products.EditValue);
            }
            catch { }

            try
            {
                v_WeightPerPackage = spinEdit_WeightPerPackage.Value;
            }
            catch { }

            frm_WM_Dialog_ChangeProductPalletInfo frm = new frm_WM_Dialog_ChangeProductPalletInfo(v_CustomerID, v_ProductID, v_WeightPerPackage);
            if (!frm.Enabled) return;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowInTaskbar = false;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                int v_NewProductID = 0;

                try
                {
                    v_NewProductID = Convert.ToInt32(frm.lookUpEdit_ProductID.EditValue);
                }
                catch { }

                LoadData2lookUpEdit_ProductID(v_CustomerID);
                this.lke_WM_Products.EditValue = v_NewProductID;

                if (checkEdit_OnHand.Checked == true)
                {
                    ST_WMS_tmpProductRemains_Result proOld = ((List<ST_WMS_tmpProductRemains_Result>)this.lke_WM_Products.Properties.DataSource).First(p => p.ProductID == v_NewProductID);
                    HyperLinkEdit_ProductName.Text = proOld.Name;
                    spinEdit_WeightPerPackage.Value = Convert.ToDecimal(proOld.WeightPerPackage);
                }
                else
                {
                    STComboProductID_Result proOld = ((List<STComboProductID_Result>)this.lke_WM_Products.Properties.DataSource).First(p => p.ProductID == v_NewProductID);
                    HyperLinkEdit_ProductName.Text = proOld.Name;
                    spinEdit_WeightPerPackage.Value = Convert.ToDecimal(proOld.WeightPerPackage);
                }
            }
        }
        void Btn_OnHand_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (lke_WM_Customer.EditValue == null || (int)lke_WM_Customer.EditValue <= 0) return;
            int v_CustomerID = Convert.ToInt32(lke_WM_Customer.EditValue);
            UI.StockTake.frm_ST_StockOnHandOneCustomer frm = new StockTake.frm_ST_StockOnHandOneCustomer(v_CustomerID);
            frm.ShowInTaskbar = false;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show(this);
        }
        void Btn_Close_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        void LoadLocations(int i_ProductID)
        {
            if (i_ProductID > 0)
            {
                //gridControlLocations.DataSource = FileProcess.LoadTable("ST_WMS_PalletInfo_Locations_NotRO " + i_ProductID);
                gridControlLocations.DataSource = (new DataProcess<ST_WMS_PalletInfo_Locations_NotRO_Result>()).Executing("ST_WMS_PalletInfo_Locations_NotRO @ProductID = {0}", i_ProductID).ToList();
            }
            else
            {
                gridControlLocations.DataSource = null;
            }
        }
        void LoadRO(int i_ProductID)
        {
            if (i_ProductID > 0)
            {
                gridControlRO.DataSource = (new DataProcess<STPalletInfo_RO_Result>()).Executing("STPalletInfo_RO @ProductID={0}", i_ProductID).ToList();
            }
            else
            {
                gridControlRO.DataSource = null;
            }
        }
        void LoadDO(int i_ProductID)
        {
            if (i_ProductID > 0)
            {
                gridControlDO.DataSource = (new DataProcess<STPalletInfo_DO_Result>()).Executing("STPalletInfo_DO @ProductID = {0}", i_ProductID).ToList();
            }
            else
            {
                gridControlDO.DataSource = null;
            }
        }

        void LoadData2lookUpEdit_LocationID()
        {
            try
            {
                Wait.Start(this);
                this.lkeSeachLocation.DataSource = UI.Helper.AppSetting.LocationList.Where(a => a.StoreID == AppSetting.StoreID && a.Used == 1).ToList();
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);

                Wait.Close();
                MessageBox.Show(ex.Message, "Error is unexpected");
            }
            Wait.Close();
        }
        void LoadData2lookUpEdit_CustomerID()
        {
            lke_WM_Customer.Properties.DataSource = (new DataProcess<STcomboCustomerID_Result>()).Executing("STcomboCustomerID @varStoreID={0}", AppSetting.StoreID).ToList();
            lke_WM_Customer.Properties.Columns.Add(new LookUpColumnInfo("CustomerNumber"));
            lke_WM_Customer.Properties.Columns.Add(new LookUpColumnInfo("CustomerName"));
            this.lke_WM_Customer.Properties.ValueMember = "CustomerID";
            this.lke_WM_Customer.Properties.DisplayMember = "CustomerNumber";
        }
        void LoadData2lookUpEdit_ProductID(int i_CustomerID)
        {
            if (i_CustomerID > 0)
            {
                if (checkEdit_OnHand.Checked == true)
                {
                    this.lke_WM_Products.Properties.DataSource = (new DataProcess<ST_WMS_tmpProductRemains_Result>()).Executing("ST_WMS_tmpProductRemains @CustomerID = {0}", i_CustomerID).ToList();
                    this.lke_WM_Products.Properties.Columns["tmpRemainQuantity"].Visible = true;
                    this.lke_WM_Products.Properties.Columns["Discontinue"].Visible = false;
                }
                else
                {
                    this.lke_WM_Products.Properties.DataSource = (new DataProcess<STComboProductID_Result>()).Executing("STComboProductID @CustomerID = {0}", i_CustomerID).ToList();
                    this.lke_WM_Products.Properties.Columns["tmpRemainQuantity"].Visible = false;
                    this.lke_WM_Products.Properties.Columns["Discontinue"].Visible = true;
                }

                int v_ProductID = 0;

                try
                {
                    v_ProductID = Convert.ToInt32(this.lke_WM_Products.EditValue);
                }
                catch { }


                if (v_ProductID > 0)
                {
                    object test = this.lke_WM_Products.GetSelectedDataRow();
                    if (checkEdit_OnHand.Checked == true)
                    {
                        var view = (ST_WMS_tmpProductRemains_Result)this.lke_WM_Products.GetSelectedDataRow();
                        if (view != null)
                        {
                            HyperLinkEdit_ProductName.Text = Convert.ToString(view.Name);
                            spinEdit_WeightPerPackage.Value = Convert.ToDecimal(view.WeightPerPackage);
                        }
                        else
                        {
                            HyperLinkEdit_ProductName.Text = "";
                            spinEdit_WeightPerPackage.Value = 0;
                        }
                    }
                    else
                    {
                        var view = (STComboProductID_Result)this.lke_WM_Products.GetSelectedDataRow();
                        if (view != null)
                        {
                            HyperLinkEdit_ProductName.Text = Convert.ToString(view.Name);
                            spinEdit_WeightPerPackage.Value = Convert.ToDecimal(view.WeightPerPackage);
                        }
                        else
                        {
                            HyperLinkEdit_ProductName.Text = "";
                            spinEdit_WeightPerPackage.Value = 0;
                        }
                    }
                }
                else
                {
                    HyperLinkEdit_ProductName.Text = "";
                    spinEdit_WeightPerPackage.Value = 0;
                }
            }
            else
            {
                this.lke_WM_Products.Properties.DataSource = null;
            }
        }
        void LoadData2repItemLookUpEdit_Location_PalletStatus()
        {
            try
            {
                DataProcess<PalletStatu> v_da = new DataProcess<PalletStatu>();
                IList<PalletStatu> v_List = v_da.Select().OrderBy(c => c.PalletStatus).ToList();

                repItemLookUpEdit_Location_PalletStatus.DataSource = v_List;
                repItemLookUpEdit_Location_PalletStatus.DropDownRows = v_List.Count;
                repItemLookUpEdit_Location_PalletStatus.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
                repItemLookUpEdit_Location_PalletStatus.DisplayMember = "PalletStatus";
                repItemLookUpEdit_Location_PalletStatus.ValueMember = "PalletStatus";

            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);

                repItemLookUpEdit_Location_PalletStatus.DataSource = null;
            }
        }

        void GetROInfo()
        {
            try
            {
                int orderID = 0;
                object objSelected = gridViewRO.GetFocusedRow();
                if (objSelected != null && objSelected.GetType() != typeof(object))
                {
                    orderID = (Int32)gridViewRO.GetFocusedRowCellValue("ReceivingOrderID");
                }
                LoadRODOPaletInfo(orderID, false);
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);

                gridControlRODO.DataSource = null;
            }
        }
        void GetDOInfo()
        {
            try
            {
                int orderID = 0;
                object objSelected = gridViewDO.GetFocusedRow();
                if (objSelected != null && objSelected.GetType() != typeof(object))
                {
                    orderID = (Int32)gridViewDO.GetFocusedRowCellValue("DispatchingOrderID");
                }
                else
                {
                    orderID = 0;
                }
                LoadRODOPaletInfo(orderID, true);
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);

                gridControlRODO.DataSource = null;
            }
        }

        void SetEnableButton(int i_ActionControlForm)
        {
            if (i_ActionControlForm.Equals(CActionForm.LoadForm))
            {
                btn_Change.Enabled = true;
                btn_MovementHistory.Enabled = true;
                btn_OnHand.Enabled = true;

                btn_ReportA4.Enabled = true;
                btn_ReportA4byRO.Enabled = true;
                btn_ReportA5.Enabled = true;
                btn_ReportA5Filter.Enabled = true;
            }
        }

        void LoadRODOPaletInfo(int i_OrderID, bool i_TypeOrder)
        {
            if (i_OrderID > 0)
            {
                gridControlRODO.DataSource = (new DataProcess<STInOutView_Details_Result>()).Executing("STInOutView_Details @OrderID ={0},@Flag = {1}", i_OrderID, i_TypeOrder).ToList();
            }
            else
            {
                gridControlRODO.DataSource = null;
            }
        }

        private void gridViewLocations_CustomDrawFooterCell(object sender, FooterCellCustomDrawEventArgs e)
        {
            e.Appearance.BorderColor = Color.FromArgb(255, 255, 255);
            e.Appearance.Options.UseBorderColor = false;
            e.Appearance.DrawString(e.Cache, e.Info.DisplayText, e.Bounds);
            e.Handled = true;
        }

        private void gridViewLocations_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.RowHandle < 0) return;
            int qty = Convert.ToInt32(gridViewLocations.GetRowCellValue(e.RowHandle, "CurrentQuantity"));
            int afterPick = Convert.ToInt32(gridViewLocations.GetRowCellValue(e.RowHandle, "AfterDPQuantity"));
            if (qty != afterPick)
            {
                e.Appearance.BackColor = Color.LightYellow;
            }
        }

        private void repositoryItemHyperLinkEditbreakPallet_Click(object sender, EventArgs e)
        {
            int v_PalletID = 0;
            int v_afterDPQuantity = 0;
            int v_currentQuantity = 0;

            try
            {
                v_PalletID = Convert.ToInt32(gridViewLocations.GetRowCellDisplayText(gridViewLocations.FocusedRowHandle, gridViewLocations.Columns["PalletID"]));
            }
            catch { }
            try
            {
                v_afterDPQuantity = Convert.ToInt32(gridViewLocations.GetRowCellDisplayText(gridViewLocations.FocusedRowHandle, gridViewLocations.Columns["AfterDPQuantity"]));
            }
            catch { }
            try
            {
                v_currentQuantity = Convert.ToInt32(gridViewLocations.GetRowCellDisplayText(gridViewLocations.FocusedRowHandle, gridViewLocations.Columns["CurrentQuantity"]));
            }
            catch { }

            if (v_afterDPQuantity == v_currentQuantity)
            {
                frm_WM_Dialog_BreakPallet breakPalletForm = new frm_WM_Dialog_BreakPallet(v_afterDPQuantity, v_PalletID);
                if (!breakPalletForm.Enabled) return;
                if (breakPalletForm.ShowDialog(this) == DialogResult.OK)
                {

                    int v_ProductID = 0;

                    try
                    {
                        v_ProductID = Convert.ToInt32(this.lke_WM_Products.EditValue);
                    }
                    catch { }

                    LoadLocations(v_ProductID);
                }
            }
            else
            {
                XtraMessageBox.Show("This product is during dispatching process, please break later !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void repositoryItemHyperLinkEditMovePallet_Click(object sender, EventArgs e)
        {
            int locationid = Convert.ToInt32(gridViewLocations.GetRowCellValue(gridViewLocations.FocusedRowHandle, "LocationID"));
            UI.StockTake.frm_ST_StockMovementNew frm = new StockTake.frm_ST_StockMovementNew(locationid);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowInTaskbar = true;
            frm.Show();
        }

        private void btnViewAllPallets_Click(object sender, EventArgs e)
        {
            if (this.btnViewAllPallets.Text == "View All")
            {
                this.btnViewAllPallets.Text = "Return";
                int i_ProductID = Convert.ToInt32(this.lke_WM_Products.EditValue);
                gridControlLocations.DataSource = FileProcess.LoadTable("ST_WMS_PalletInfo_Locations_AllHistory " + i_ProductID);
            }
            else
            {
                this.btnViewAllPallets.Text = "View All";
                this.lke_WM_Products_EditValueChanged(sender, e);
            }
        }

        private void repositoryItemHyperLinkDO_Click(object sender, EventArgs e)
        {
            int v_DispatchingOrderID = 0;
            try
            {
                v_DispatchingOrderID = Convert.ToInt32(gridViewLocations.GetFocusedRowCellValue("DispatchingOrderID"));
            }
            catch { }

            WarehouseManagement.frm_WM_DispatchingOrders frm = frm_WM_DispatchingOrders.GetInstance(v_DispatchingOrderID);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowInTaskbar = false;
            frm.Show();
            frm.BringToFront();
        }

        private void frm_WM_PalletInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                if (this.Modal)
                {
                    return;
                }

                FormCollection openforms = Application.OpenForms;
                bool isOpen = false;
                foreach (Form frms in openforms)
                {
                    if (frms.Name == "frmScanInput")
                    {
                        frms.BringToFront();
                        isOpen = true;
                    }

                }
                if (!isOpen)
                {
                    UI.Helper.frmScanInput inputDialog = new frmScanInput();
                    inputDialog.Show();
                    inputDialog.BringToFront();
                }

            }



        }

        private void btnViewWeightUnit_ItemClick(object sender, ItemClickEventArgs e)
        {
            int productID = 0;
            if (this.lke_WM_Products.EditValue == null) return;
            productID = Convert.ToInt32(this.lke_WM_Products.EditValue);

            if (productID > 0)
            {
                if (this.btnViewWeightUnit.Caption.Contains("View Weight"))
                {
                    this.btnViewWeightUnit.Caption = "Return";
                    gridControlLocations.DataSource = (new DataProcess<STPalletInfo_LocationsWeightInners_Result>()).Executing("STPalletInfo_LocationsWeightInners @ProductID = {0}", productID).ToList();
                }
                else
                {
                    this.btnViewWeightUnit.Caption = "View Weight" + Environment.NewLine + "Unit Remain";
                    this.LoadLocations(productID);
                }
            }
            else
            {
                gridControlLocations.DataSource = null;
            }
        }

        private void btnCartonDetails_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.lke_WM_Products.EditValue == null) return;
            int productID = Convert.ToInt32(lke_WM_Products.EditValue);
            int customerID = Convert.ToInt32(this.lke_WM_Customer.EditValue);
            frm_WM_PalletCartonDetails frmDetail = new frm_WM_PalletCartonDetails(productID, 2, customerID);
            frmDetail.Show();
        }

        private void rpi_lke_CartonDetails_Click(object sender, EventArgs e)
        {
            int v_PalletID = 0;
            try
            {
                v_PalletID = Convert.ToInt32(gridViewLocations.GetRowCellValue(gridViewLocations.FocusedRowHandle, "PalletID"));
                int customerID = Convert.ToInt32(this.lke_WM_Customer.EditValue);
                frm_WM_PalletCartonDetails frmDetail = new frm_WM_PalletCartonDetails(v_PalletID, 1, customerID);
                frmDetail.Show();
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
            }
        }

        /// <summary>
        /// Checks the role user.
        /// </summary>
        /// <param name="receivingOrderDate">The receiving order date.</param>
        /// <returns></returns>
        private bool CheckRoleUser(DateTime receivingOrderDate)
        {
            var isExistApplication = FileProcess.LoadTable("ST_WMS_LoadApplicationByUser @LoginName='" + AppSetting.CurrentUser.LoginName + "',@ApplicationName='" + Application.ProductName + "'");
            if (isExistApplication == null || isExistApplication.Rows.Count <= 0)
            {
                return false;
            }

            int userApplicationID = (int)isExistApplication.Rows[0]["UserApplicationId"];
            var datasource = FileProcess.LoadTable("ST_WMS_LoadAllRoleByUser @LoginName='" + AppSetting.CurrentUser.LoginName + "' ,@UserApplicationID=" + userApplicationID);

            // Checking current user has level of accounting , if user is accounting then not allow change weight
            var departmentRole = datasource.Select("UserDepartmentDefinitionID=4");
            if (departmentRole == null || departmentRole.Count() <= 0)
            {
                return false;
            }

            TimeSpan interval = DateTime.Now.Subtract(receivingOrderDate);
            // this product has created recently then allow edit it
            if (interval.Days <= 7)
            {
                return true;
            }

            if (interval.Days > 30)
            {
                // Product has created more than 30 days then can not change weight value
                this.spinEdit_WeightPerPackage.ReadOnly = true;
                return false;
            }

            foreach (var row in departmentRole)
            {
                int level = Convert.ToInt32(row["LevelDepartment"]);
                if (level > 2)
                {
                    //this.curre
                    return true;
                }
            }
            // Account has level less more than or equal is User in Operation department then can not change weight value
            this.spinEdit_WeightPerPackage.ReadOnly = true;
            return false;
        }

        /// <summary>
        /// Handles the product date changed.
        /// </summary>
        /// <param name="newDate">The new date.</param>
        /// <param name="reason">The reason.</param>
        /// <param name="roID">The ro identifier.</param>
        /// <param name="roDetailID">The ro detail identifier.</param>
        /// <param name="oldDate">The old date.</param>
        /// <param name="fieldName">Name of the field.</param>
        private void HandleProductDateChanged(DateTime newDate, string reason, int roID, int roDetailID, DateTime oldDate, string fieldName)
        {
            try
            {
                // Update change date + reason
                if (newDate != null && !string.IsNullOrEmpty(reason))
                {
                    string newProductDate = newDate.Date.ToString("yyyy-MM-dd");
                    string updateSqlQuery = $"UPDATE ReceivingOrderDetails SET {fieldName} = '" + newProductDate + "' WHERE (ReceivingOrderDetailID = " + roDetailID + " )";
                    var da = new DataProcess<object>();
                    da.ExecuteNoQuery(updateSqlQuery);

                    // Tracking changed history to display on View Changes form
                    var trackingHistoryTask = new Task(() =>
                    {
                        log.Info("RepItemTextEdit_RO_ProductionDate_DoubleClick - Start tracking change product date history...");
                        var changeDate = DateTime.Now.Date;
                        var changeBy = AppSetting.CurrentUser.LoginName;
                        var changeDescription = $"RO-{roID} - Change Product {fieldName} from {oldDate.ToString("yyyy-MM-dd")} to {newDate.ToString("yyyy-MM-dd")}. Reason: {reason}";
                        var referenceID = roID;

                        // Build SQL update query
                        var updateProductChangeSql = $"INSERT INTO ProductChanging (ChangeDate, ChangeBy, ChangeDescription, ReferenceID) " +
                        $"VALUES ('{changeDate.ToString("yyyy-MM-dd")}', N'{changeBy}', N'{changeDescription}', {referenceID})";

                        var dataProcessInst = new DataProcess<object>();
                        dataProcessInst.ExecuteNoQuery(updateProductChangeSql);

                        log.Info("RepItemTextEdit_RO_ProductionDate_DoubleClick - Tracking change product date history...DONE");
                    });
                    trackingHistoryTask.Start();
                }
            }
            catch (Exception ex)
            {
                log.Error("HandleProductDateChanged - Error occurs: ", ex);
                XtraMessageBox.Show($"Failed when change product date, detail error(s):\n {ex.Message}", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void repItemLookUpEdit_Location_PalletStatus_CloseUp(object sender, CloseUpEventArgs e)
        {
            if (e.Value == null) return;
            int v_PalletID = Convert.ToInt32(gridViewLocations.GetRowCellValue(gridViewLocations.FocusedRowHandle, "PalletID"));
            frm_WM_HoldAll frm = new frm_WM_HoldAll("PL", "PI", (byte)e.Value, v_PalletID);
            frm.ShowDialog();
            if (frm.currentPalletSeleceted == null)
            {
                e.AcceptValue = false;
            }

            else
            {
                e.Value = frm.currentPalletSeleceted;
                this.gridViewLocations.SetFocusedRowCellValue("PalletStatus", frm.currentPalletSeleceted.PalletStatus);
            }
        }

        private void gridControlLocations_Click(object sender, EventArgs e)
        {

        }

        private void bbtn_CreateCustomerStockTakes_ItemClick(object sender, ItemClickEventArgs e)
        {

            SqlConnection conn = new SqlConnection(new SwireDBEntities().Database.Connection.ConnectionString);
            SqlCommand cmd = new SqlCommand("STCustomerStockTake_CreateOrderProduct", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter varCustomerID = cmd.Parameters.Add("@CustomerID", SqlDbType.Int);
            varCustomerID.Value = this.lke_WM_Customer.EditValue;

            SqlParameter varProductID = cmd.Parameters.Add("@ProductID", SqlDbType.Int);
            varProductID.Value = Convert.ToInt32(this.lke_WM_Products.EditValue);
            SqlParameter CurrentUser = cmd.Parameters.Add("@CurrentUser", SqlDbType.VarChar);
            CurrentUser.Value = Convert.ToString(AppSetting.CurrentUser);
            SqlParameter varCustomerStockTakeID = cmd.Parameters.Add("@CustomerStockTakeID", SqlDbType.Int);
            varCustomerStockTakeID.Direction = ParameterDirection.Output;
            conn.Open();
            int result = cmd.ExecuteNonQuery();

            // reader is closed/disposed after exiting the using statement


            //MessageBox.Show(this.grvStockTakeAllDataTabelView.ActiveFilterString);

            //process the Checking Order here
            frm_WM_CustomerStockTakes frm = new frm_WM_CustomerStockTakes(Convert.ToInt32(varCustomerStockTakeID.Value));
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
        }

        private void gridViewLocations_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (e.RowHandle < 0) return;

            int currenQty = Convert.ToInt32(this.gridViewLocations.GetRowCellValue(e.RowHandle, "CurrentQuantity"));
            if (Convert.IsDBNull(this.gridViewLocations.GetRowCellValue(e.RowHandle, "NaviStorageQty"))) return;
            int naviQty = Convert.ToInt32(this.gridViewLocations.GetRowCellValue(e.RowHandle, "NaviStorageQty"));
            int status = Convert.ToInt32(this.gridViewLocations.GetRowCellValue(e.RowHandle, "Status"));
            string naviLocation = Convert.ToString(this.gridViewLocations.GetRowCellValue(e.RowHandle, "NaviLocationNo"));
            string wmsLocation = Convert.ToString(this.gridViewLocations.GetRowCellValue(e.RowHandle, "Label"));
            if (string.IsNullOrEmpty(naviLocation) || status < 2) return;

            if (naviLocation != wmsLocation)
            {
                e.Appearance.BackColor = Color.Yellow;
                e.HighPriority = true;
            }

            if (currenQty != naviQty)
            {
                if (naviLocation != wmsLocation)
                {
                    e.Appearance.BackColor = Color.Red;
                    e.Appearance.BackColor2 = Color.Yellow;
                }
                else
                {
                    e.Appearance.BackColor = Color.Red;
                }
                e.HighPriority = true;
            }
        }
    }
}
