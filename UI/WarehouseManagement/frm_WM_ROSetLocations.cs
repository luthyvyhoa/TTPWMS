using DA;
using DA.Warehouse;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UI.Helper;
using UI.MasterSystemSetup;
using UI.ReportFile;
namespace UI.WarehouseManagement
{
    public partial class frm_WM_ROSetLocations : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        // Declare log
        private static readonly ILog log = LogManager.GetLogger(typeof(frm_WM_ROSetLocations));
        ReceivingOrderDetails receivingOrderDetail;
        BindingList<ST_WMS_LoadAllPalletsByReceivingOrderID_Result> listPallet = new BindingList<ST_WMS_LoadAllPalletsByReceivingOrderID_Result>();
        BindingList<ST_WMS_LoadAllPalletsByReceivingOrderID_Result> roDetailList = null;
        DataProcess<STLabel1ReceivingOrderDetail_Result> multilabel = new DataProcess<STLabel1ReceivingOrderDetail_Result>();
        List<STVSPalletAllocation_Result> listLocation;
        IList<Pallets> listPalletsUpdate = new List<Pallets>();
        IList<Pallets> listPalletsInsert = new List<Pallets>();
        DataProcess<STVSPalletAllocation_Result> palletAllLocationDA = null;
        DataProcess<Pallets> dataProcessPallet = new DataProcess<Pallets>();
        Products product;
        Employees fullInfoEmployees = null;
        string homeRoom1 = "";
        string homeRoom2 = "";
        string receivingOrderNumber = "";
        string customererNumber = "";
        bool isUpdate = false;
        bool _isQuantityUpdated = false;
        bool _isModified = false;
        private bool _isRandomWeight = false;
        private bool _isLoaded = false;
        private readonly object lockObj = new object();
        private bool isKGR = false;
        private int status;
        /// <summary>
        /// The receiving order detail Data access
        /// </summary>
        DataProcess<object> recevingOrderDetailDA = new DataProcess<object>();

        public frm_WM_ROSetLocations()
        {
            InitializeComponent();

            // Init size formspKg
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Location = new System.Drawing.Point(this.Location.X, 0);
            log.Debug("==> ROSetLocations Bắt đầu mở giao diện");
        }

        public frm_WM_ROSetLocations(ReceivingOrderDetails rODetail, string rONumber, string custNumber, bool isRandomWeight, int status)
        {
            InitializeComponent();
            this.status = status;
            // Init data
            this.InitData(rODetail, rONumber, custNumber, isRandomWeight, status);
            log.Debug("==> ROSetLocations Bắt đầu mở giao diện với tham số khởi tạo");
        }

        public void InitData(ReceivingOrderDetails rODetail, string rONumber, string custNumber, bool isRandomWeight, int status)
        {
            this.status = status;
            receivingOrderDetail = rODetail;
            receivingOrderNumber = rONumber;
            customererNumber = custNumber;
            this._isRandomWeight = isRandomWeight;
            this.spKg.EditValue = null;
            this.gridViewPallet.ClearSorting();
            this.gridViewPallet.ClearColumnsFilter();

            // Check current product has package KGR
            DataProcess<Products> proDA = new DataProcess<Products>();
            var currentPro = proDA.Select(p => p.ProductID == rODetail.ProductID).FirstOrDefault();
            if (currentPro != null && currentPro.Packages.Equals("KGR")) this.isKGR = true;
            else this.isKGR = false;

            LoadStatus();
            LoadData();
            this.LoadAllPalletsStatus();
            this.CheckWeightInput();

            this._isLoaded = true;
            log.Debug("==> ROSetLocations Chạy hàm khởi tạo dự liệu");
        }

        private void CheckWeightInput()
        {
            log.Debug("==> ROSetLocations chạy hàm CheckWeightInput");
            var hasWeigh = FileProcess.LoadTable("STPalletCartonCheckExist @ReceivingOrderDetailID=" + receivingOrderDetail.ReceivingOrderDetailID);
            if (hasWeigh != null && hasWeigh.Rows.Count > 0)
            {
                spinEditTotalWeight.ReadOnly = true;
                speRejectPercentage.ReadOnly = true;
            }
            else
            {
                spinEditTotalWeight.ReadOnly = false;
                speRejectPercentage.ReadOnly = false;
            }
        }

        void btnLabel_Click(object sender, EventArgs e)
        {
            log.Debug("==> ROSetLocations click sự kiện btnLabel_Click");
            string strPalettID = this.gridViewPallet.GetRowCellValue(this.gridViewPallet.FocusedRowHandle, "PalletID").ToString();
            int palletID = Convert.ToInt32(strPalettID);
            string customerType = AppSetting.CustomerList.FirstOrDefault(cus => cus.CustomerNumber == this.customererNumber)?.CustomerType;
            DataProcess<STLabel1Label_Result> label = new DataProcess<STLabel1Label_Result>();

            if (customerType == CustomerTypeEnum.PCS)
            {
                rptLabel_Barcode_pcs lb = new rptLabel_Barcode_pcs();
                lb.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
                lb.Parameters["parameter1"].Value = 3;
                lb.DataSource = label.Executing("STLabel1Label @PalletID={0}", palletID);
                lb.RequestParameters = false;
                ReportPrintToolWMS printTool = new ReportPrintToolWMS(lb);
                printTool.AutoShowParametersPanel = false;
                printTool.Print();
            }
            else
            {
                rptLabel_Barcode lb = new rptLabel_Barcode();
                lb.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
                lb.DataSource = label.Executing("STLabel1Label @PalletID={0}", palletID);
                lb.Parameters["parameter1"].Value = 3;
                lb.RequestParameters = false;
                ReportPrintToolWMS printTool = new ReportPrintToolWMS(lb);
                printTool.AutoShowParametersPanel = false;
                printTool.Print();
            }
        }

        private void LoadAllPalletsStatus()
        {
            log.Debug("==> ROSetLocations chạy hàm LoadAllPalletsStatus");
            DataProcess<PalletStatu> palletStatusDA = new DA.DataProcess<DA.PalletStatu>();
            this.rpilkHold.DataSource = palletStatusDA.Select();
            this.rpilkHold.ValueMember = "PalletStatus";
        }

        private void LoadStatus()
        {
            log.Debug("==> ROSetLocations chạy hàm LoadStatus");
            isUpdate = false;
            textEditProductNumber.Text = receivingOrderDetail.ProductNumber;
            textEditProductName.Text = receivingOrderDetail.ProductName;
            if (receivingOrderDetail.ProductionDate != null)
                dateEditProductionDate.EditValue = receivingOrderDetail.ProductionDate;
            else
                dateEditProductionDate.EditValue = null;

            if (receivingOrderDetail.UseByDate != null)
                dateEditUseByDate.EditValue = receivingOrderDetail.UseByDate;
            else
                dateEditUseByDate.EditValue = null;
            //spinEditTotalPackages.Text = Convert.ToString(receivingOrderDetail.TotalPackages);
            if (receivingOrderDetail.PackagingWeight != null)
            {
                spinEditTotalWeight.Text = string.Format("{0:0.00}", receivingOrderDetail.PackagingWeight);
            }
            else
            {
                spinEditTotalWeight.Text = string.Empty;
            }

            if (receivingOrderDetail.RejectPercentage != null)
            {
                this.speRejectPercentage.Text = string.Format("{0:0.00}", receivingOrderDetail.RejectPercentage);
            }
            else
            {
                this.speRejectPercentage.Text = string.Empty;
            }

            var currentPr = AppSetting.ProductList.Where(p => p.ProductID == receivingOrderDetail.ProductID).FirstOrDefault();
            if (currentPr != null)
            {
                this.chkWeighingRequired.EditValue = currentPr.IsWeightingRequire;
            }
            spinEditWeightPerPackage.Text = Convert.ToString(receivingOrderDetail.WeightPerPackage);

            textEditCustomerRef.Text = receivingOrderDetail.CustomerRef;
            textEditOrigin.Text = receivingOrderDetail.Origin;
            textEditRemark.Text = receivingOrderDetail.Remark;

            // Get first product
            DataProcess<Products> productDA = new DA.DataProcess<DA.Products>();
            product = productDA.Select(c => c.ProductID == receivingOrderDetail.ProductID).FirstOrDefault();
            if (product != null)
            {
                homeRoom1 = product.HomeRoom1;
                homeRoom2 = product.HomeRoom2;
            }

            switch (receivingOrderDetail.Status)
            {
                case 1:
                    this.btnAccept.Enabled = true;
                    this.btnAccept.Checked = true;
                    this.btnAllocate.Enabled = false;
                    gridColumnPallet.Visible = false;
                    gridColumnOriginalQuantity.OptionsColumn.AllowEdit = false;
                    gridColumnOriginalQuantity.OptionsColumn.AllowFocus = false;
                    gridColumnUnitQuantity.OptionsColumn.AllowEdit = false;
                    gridColumnUnitQuantity.OptionsColumn.AllowFocus = false;
                    gridColumnPalletWeight.OptionsColumn.AllowEdit = false;
                    gridColumnPalletWeight.OptionsColumn.AllowFocus = false;
                    textEditCustomerRef.ReadOnly = true;
                    dateEditProductionDate.ReadOnly = true;
                    dateEditUseByDate.ReadOnly = true;
                    break;
                case 0:
                    this.btnAccept.Enabled = true;
                    this.btnAccept.Checked = false;
                    this.btnAllocate.Enabled = true;
                    gridColumnPallet.Visible = true;
                    gridColumnOriginalQuantity.OptionsColumn.AllowEdit = true;
                    gridColumnOriginalQuantity.OptionsColumn.AllowFocus = true;

                    //if (this._isRandomWeight && this.isKGR)
                    if (this._isRandomWeight)
                    {
                        gridColumnUnitQuantity.OptionsColumn.AllowEdit = true;
                        gridColumnPalletWeight.OptionsColumn.AllowEdit = true;
                    }
                    else
                    {
                        gridColumnUnitQuantity.OptionsColumn.AllowEdit = false;
                        gridColumnPalletWeight.OptionsColumn.AllowEdit = false;
                    }
                    gridColumnPalletWeight.OptionsColumn.AllowFocus = true;
                    gridColumnUnitQuantity.OptionsColumn.AllowFocus = true;
                    textEditCustomerRef.ReadOnly = false;
                    dateEditProductionDate.ReadOnly = false;
                    dateEditUseByDate.ReadOnly = false;
                    break;
                case 2:
                case 4:
                    this.btnAccept.Enabled = false;
                    this.btnAccept.Checked = true;
                    this.btnAllocate.Enabled = false;
                    gridColumnPallet.Visible = false;
                    gridColumnOriginalQuantity.OptionsColumn.AllowEdit = false;
                    gridColumnOriginalQuantity.OptionsColumn.AllowFocus = false;
                    gridColumnUnitQuantity.OptionsColumn.AllowEdit = false;
                    gridColumnUnitQuantity.OptionsColumn.AllowFocus = false;
                    gridColumnPalletWeight.OptionsColumn.AllowEdit = false;
                    gridColumnPalletWeight.OptionsColumn.AllowFocus = false;
                    textEditCustomerRef.ReadOnly = true;
                    dateEditProductionDate.ReadOnly = true;
                    dateEditUseByDate.ReadOnly = true;
                    break;
            }
            if (receivingOrderDetail.Status == 0)
            {
                //listPallet.AllowNew = true;
                this.AddNewRow();
            }
            else
            {
                listPallet.AllowNew = false;
                gridViewPallet.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
            }
            isUpdate = true;
        }
        private void LoadData()
        {
            try
            {
                log.Debug("==> ROSetLocations chạy hàm LoadData");
                DataProcess<ST_WMS_LoadAllPalletsByReceivingOrderID_Result> palletsDA = new DA.DataProcess<DA.ST_WMS_LoadAllPalletsByReceivingOrderID_Result>();
                var dataSource = palletsDA.Executing("ST_WMS_LoadAllPalletsByReceivingOrderID @ReceivingOrderID={0}", receivingOrderDetail.ReceivingOrderDetailID);
                this.roDetailList = new BindingList<ST_WMS_LoadAllPalletsByReceivingOrderID_Result>(dataSource.ToList());
                gridControlPallet.DataSource = this.roDetailList;

                if (receivingOrderDetail.Status == 0)
                {
                    //listPallet.AllowNew = true;
                    this.AddNewRow();
                }
                else
                {
                    listPallet.AllowNew = false;
                    gridViewPallet.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                }

                this.gridViewPallet.Columns["Date"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                gridViewPallet.RefreshData();
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
            }
        }
        private void iClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            log.Debug("==> ROSetLocations đóng màn hình");
            DialogResult = DialogResult.OK;
            this.Close();
        }


        //<summary>
        //Update existed pallet or insert new pallet
        //</summary>
        private void UpdatePallets(int rowHandle)
        {
            try
            {
                if (this._isModified)
                {
                    log.Debug("==> ROSetLocations chạy hàm UpdatePallets");
                    ReceivingOrdersDA receivingOrderDa = new ReceivingOrdersDA();
                    DataProcess<Pallets> palletInfo = new DA.DataProcess<Pallets>();

                    // Update receiving order detail
                    receivingOrderDa.UpdateQuantityReceivingOrderDetail(this.receivingOrderDetail.ReceivingOrderDetailID);

                    var pallet = (ST_WMS_LoadAllPalletsByReceivingOrderID_Result)this.gridViewPallet.GetRow(rowHandle);

                    if (pallet == null)
                    {
                        return;
                    }
                    // Get resource was modify
                    this.ConvertToPalletInfo(pallet);

                    // Check resource update
                    if (this.listPalletsUpdate.Count > 0)
                    {
                        if (this.listPalletsUpdate.Where(p => p.ReceivingOrderDetailID != this.receivingOrderDetail.ReceivingOrderDetailID).Count() > 0)
                        {
                            MessageBox.Show($"PalletID này sẽ được cập nhật sang một RO Detail khác, cần liên hệ ngay với IT để giải quyết, tránh gây lỗi hệ thống !");
                            log.ErrorFormat("==> Error is unexpected : PalletID update new ReceivingOrderDetailID");
                        }

                        int result = palletInfo.Update(this.listPalletsUpdate.ToArray());
                        this.listPalletsUpdate.Clear();
                    }

                    // Check resource add new
                    if (this.listPalletsInsert.Count > 0)
                    {
                        if (this.listPalletsInsert.Where(p => p.ReceivingOrderDetailID != this.receivingOrderDetail.ReceivingOrderDetailID).Count() > 0)
                        {
                            MessageBox.Show($"PalletID này sẽ được cập nhật sang một RO Detail khác, cần liên hệ ngay với IT để giải quyết, tránh gây lỗi hệ thống !");
                            log.ErrorFormat("==> Error is unexpected : PalletID update new ReceivingOrderDetailID");
                        }

                        int result = palletInfo.Insert(this.listPalletsInsert.ToArray());
                        this.gridViewPallet.SetRowCellValue(rowHandle, "PalletID", this.listPalletsInsert[0].PalletID);
                        this.gridViewPallet.SetRowCellValue(rowHandle, "PalletStatus", this.listPalletsInsert[0].PalletStatus);
                        this.listPalletsInsert.Clear();
                    }
                    this._isModified = false;
                }
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);

                XtraMessageBox.Show(ex.Message, "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void AddNewRow()
        {
            if (this.gridControlPallet.DataSource == null) return;
            log.Debug("==> ROSetLocations chạy hàm AddNewRow");
            var source = (IList<ST_WMS_LoadAllPalletsByReceivingOrderID_Result>)this.gridControlPallet.DataSource;
            var newPallet = new ST_WMS_LoadAllPalletsByReceivingOrderID_Result();
            newPallet.IsModify = true;
            source.Add(newPallet);
            this.gridViewPallet.RefreshData();
            this.gridViewPallet.SetRowCellValue(this.gridViewPallet.GetRowHandle(this.gridViewPallet.RowCount - 1), "Date", DateTime.Now);
        }

        private void RemoveRowEmpty()
        {
            if (this.gridControlPallet.DataSource == null) return;
            log.Debug("==> ROSetLocations chạy hàm RemoveRowEmpty");
            var source = (IList<DA.ST_WMS_LoadAllPalletsByReceivingOrderID_Result>)this.gridControlPallet.DataSource;
            var listRemove = source.Where(x => x.LocationID == 0).ToList();
            if (listRemove.Count <= 0) return;
            foreach (ST_WMS_LoadAllPalletsByReceivingOrderID_Result itemRemove in (IEnumerable<DA.ST_WMS_LoadAllPalletsByReceivingOrderID_Result>)listRemove)
            {
                source.Remove(itemRemove);
            }
        }

        private void frmROSetLocations_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        private void repositoryItemButtonEditF_Click(object sender, EventArgs e)
        {
            log.Debug("==> ROSetLocations chạy sự kiện repositoryItemButtonEditF_Click");
            this.GetAllLocation("F");
        }

        private void repositoryItemButtonEditB_Click(object sender, EventArgs e)
        {
            log.Debug("==> ROSetLocations chạy sự kiện repositoryItemButtonEditB_Click");
            this.GetAllLocation("B");
        }

        private void gridViewPallet_ShownEditor(object sender, EventArgs e)
        {
            log.Debug("==> ROSetLocations gridViewPallet_ShownEditor");
            GridView view = sender as GridView;
            if (view.ActiveEditor is LookUpEdit)
            {
                ((LookUpEdit)view.ActiveEditor).ShowPopup();
            }
        }

        private void gridViewPallet_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            try
            {
                if (e.Value != null)
                {
                    switch (this.gridViewPallet.FocusedColumn.ColumnEditName)
                    {
                        case "repositoryItemLookUpEditLocationID":
                            {
                                int _pID = (int)(e.Value);
                                if (_pID > 0)
                                {
                                    log.Debug("==> ROSetLocations chạy sự kiện gridViewPallet_ValidatingEditor");
                                    STVSPalletAllocation_Result location = listLocation.FirstOrDefault(p => p.LocationID == _pID);
                                    gridViewPallet.SetFocusedRowCellValue(gridColumnLocationID, _pID);
                                    gridViewPallet.SetFocusedRowCellValue(gridColumnLabel, location.LocationNumber);
                                    gridViewPallet.PostEditor();
                                    gridViewPallet.FocusedColumn = gridViewPallet.Columns["OriginalQuantity"];
                                }
                                break;
                            }
                        case "repositoryItemCalcEditPalletWeight":
                            {
                                if (Convert.ToInt32(e.Value) < 0)
                                {
                                    e.Value = 0;
                                    //gridViewPallet.PostEditor();
                                }
                                break;
                            }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);

                XtraMessageBox.Show(ex.Message);
            }
        }

        private void repositoryItemLookUpEditLocationID_EditValueChanged(object sender, EventArgs e)
        {
            log.Debug("==> ROSetLocations chạy sự kiện repositoryItemLookUpEditLocationID_EditValueChanged");
            gridViewPallet.PostEditor();
            this._isModified = true;
        }

        private void gridViewPallet_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            log.Debug("==> ROSetLocations chạy sự kiện gridViewPallet_FocusedRowChanged");
            gridColumnPallet.OptionsColumn.AllowFocus = false;
            if (e.FocusedRowHandle == this.gridViewPallet.GetVisibleRowHandle(this.gridViewPallet.RowCount - 1))
            {
                if (this.gridViewPallet.GetFocusedRowCellValue(this.gridViewPallet.Columns["LocationID"]).ToString().Equals("0"))
                {
                    this.gridColumnOriginalQuantity.OptionsColumn.AllowEdit = false;
                    this.gridColumnPalletWeight.OptionsColumn.AllowEdit = false;
                    this.gridColumnUnitQuantity.OptionsColumn.AllowEdit = false;
                }
            }
            else
            {
                this.gridColumnOriginalQuantity.OptionsColumn.AllowEdit = true;

                if (this._isRandomWeight)
                {
                    this.gridColumnPalletWeight.OptionsColumn.AllowEdit = true;
                    this.gridColumnUnitQuantity.OptionsColumn.AllowEdit = true;
                }

            }

            //var labelCurrentRow =Convert.ToString( this.gridViewPallet.GetRowCellValue(e.PrevFocusedRowHandle, "Label"));
            //if (string.IsNullOrEmpty(labelCurrentRow)) return;

            //if (this._isQuantityUpdated)
            //{
            //    //this.spinEditTotalPackages.Text = Convert.ToDecimal(this.gridColumnOriginalQuantity.SummaryItem.SummaryValue).ToString();
            //    this._isQuantityUpdated = false;
            //}
            //if (this.status < 2)
            //{
            //    UpdatePallets(e.PrevFocusedRowHandle);
            //}


        }

        private void repositoryItemButtonEditA_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            log.Debug("==> ROSetLocations chạy sự kiện repositoryItemButtonEditA_ButtonClick");
        }

        private void repositoryItemButtonEditA_Click(object sender, EventArgs e)
        {
            log.Debug("==> ROSetLocations chạy sự kiện repositoryItemButtonEditA_Click");
            this.GetAllLocation("A");
        }

        private void repositoryItemButtonEditH_Click(object sender, EventArgs e)
        {
            log.Debug("==> ROSetLocations chạy sự kiện repositoryItemButtonEditH_Click");
            this.GetAllLocation("FH");
        }

        private void repositoryItemButtonEdit3_Click(object sender, EventArgs e)
        {
            log.Debug("==> ROSetLocations chạy sự kiện repositoryItemButtonEdit3_Click");
            this.GetAllLocation("3");
        }

        private void repositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
            log.Debug("==> ROSetLocations chạy sự kiện repositoryItemButtonEdit1_Click");
            this.GetAllLocation("1");
        }

        private void QuantityUpdate()
        {
            try
            {
                log.Debug("==> ROSetLocations chạy hàm QuantityUpdate");
                int palletID = Convert.ToInt32(gridViewPallet.GetFocusedRowCellValue("PalletID"));
                var roDetaiInfo = this.roDetailList.Where(rd => rd.PalletID == palletID).FirstOrDefault();
                int index = this.roDetailList.IndexOf(roDetaiInfo);
                roDetaiInfo.UnitQuantity = roDetaiInfo.OriginalQuantity * product.Inners;
                roDetaiInfo.PalletWeight = (float)(roDetaiInfo.OriginalQuantity * product.WeightPerPackage);
                this.roDetailList[index] = roDetaiInfo;
                UpdatePallets(this.gridViewPallet.FocusedRowHandle);
                this._isQuantityUpdated = true;
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);

                XtraMessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Get all location by type
        /// </summary>
        /// <param name="type">string</param>
        private void GetAllLocation(string type)
        {
            try
            {
                log.Debug("==> ROSetLocations chạy hàm GetAllLocation với type [" + type + "]");
                bool hasSyncNavi = Convert.ToBoolean(this.gridViewPallet.GetFocusedRowCellValue("IsSendNavi"));
                if (hasSyncNavi)
                {
                    XtraMessageBox.Show("Pallets had sync with WareNavi, you couldn't modify it!", "TWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                palletAllLocationDA = new DA.DataProcess<DA.STVSPalletAllocation_Result>();
                listLocation = (List<STVSPalletAllocation_Result>)palletAllLocationDA.Executing("STVSPalletAllocation @ReceivingOrderID={0},@ProductID={1},@HomeRoom1={2},@HomeRoom2={3},@Type={4},@StoreID={5}",
                    receivingOrderDetail.ReceivingOrderID, receivingOrderDetail.ProductID, homeRoom1, homeRoom2, type, AppSetting.StoreID);
                if (listLocation.Count > 0)
                {
                    if (this.gridViewPallet.RowCount.Equals(this.gridViewPallet.FocusedRowHandle + 1) && !btnAccept.Checked)
                    {
                        this.AddNewRow();
                    }

                    repositoryItemLookUpEditLocationID.DataSource = listLocation;
                    repositoryItemLookUpEditLocationID.AutoHeight = true;
                    gridColumnPallet.OptionsColumn.AllowFocus = true;
                    gridViewPallet.FocusedColumn = gridColumnPallet;
                    gridViewPallet.SetFocusedRowCellValue(gridColumnPallet, listLocation[0].LocationID);
                    gridViewPallet.ShowEditor();
                }
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);

                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private Pallets ConvertToPallet(ST_WMS_LoadAllPalletsByReceivingOrderID_Result PalletData)
        {
            DataProcess<Pallets> palletDA = new DataProcess<Pallets>();
            Pallets pallectObj = null;
            if (PalletData.PalletID > 0)
                pallectObj = palletDA.Select(p => p.PalletID == PalletData.PalletID).FirstOrDefault();
            else
                pallectObj = new Pallets();
            pallectObj.AfterDPQuantity = PalletData.OriginalQuantity;
            pallectObj.CanMove = PalletData.CanMove;
            pallectObj.CanNotAdd = PalletData.CanNotAdd;
            pallectObj.CurrentQuantity = PalletData.OriginalQuantity;
            pallectObj.Label = PalletData.Label;
            pallectObj.LocationID = PalletData.LocationID;
            pallectObj.OnHold = PalletData.OnHold;
            pallectObj.OriginalQuantity = PalletData.OriginalQuantity;
            pallectObj.PalletID = PalletData.PalletID;
            pallectObj.PalletStatus = PalletData.PalletStatus;
            pallectObj.PalletWeight = PalletData.PalletWeight;
            pallectObj.ReceivingOrderDetailID = receivingOrderDetail.ReceivingOrderDetailID;
            pallectObj.Remark = PalletData.Remark;
            pallectObj.status = PalletData.status;
            pallectObj.TS = PalletData.TS;
            pallectObj.UnitQuantity = PalletData.UnitQuantity;
            return pallectObj;
        }

        private void gridViewPallet_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {
                Pallets pallet = new Pallets();
                DataProcess<Pallets> palletDA = new DataProcess<Pallets>();

                pallet = ConvertToPallet(e.Row as ST_WMS_LoadAllPalletsByReceivingOrderID_Result);
                if (Convert.ToBoolean(pallet.IsSendNavi)) return;
                if (pallet != null)
                {
                    log.Debug("==> ROSetLocations chạy sự kiện gridViewPallet_RowUpdated");
                    if (pallet.ReceivingOrderDetailID == 0)
                    {
                        pallet.AfterDPQuantity = pallet.OriginalQuantity;
                        pallet.CurrentQuantity = pallet.OriginalQuantity;
                        pallet.PalletStatus = 0;
                        pallet.ReceivingOrderDetailID = receivingOrderDetail.ReceivingOrderDetailID;

                        palletDA.Insert(pallet);
                    }
                    else
                    {
                        if (pallet.ReceivingOrderDetailID != receivingOrderDetail.ReceivingOrderDetailID)
                        {
                            MessageBox.Show($"PalletID này sẽ được cập nhật sang một RO Detail khác, cần liên hệ ngay với IT để giải quyết, tránh gây lỗi hệ thống !");
                            log.ErrorFormat("==> Error is unexpected : PalletID update new  ReceivingOrderDetailID with palletID=[{0}] and ReceivingOrderDetailID=[{1}]",
                                pallet.PalletID, pallet.ReceivingOrderDetailID);
                        }
                        palletDA.Update(pallet);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);

                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridViewPallet_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int _productID = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, gridViewPallet.Columns["LocationID"]));
                int _qtyID = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, gridViewPallet.Columns["OriginalQuantity"]));

                if (_productID <= 0)
                {
                    e.Valid = false;
                    view.SetColumnError(gridColumnOriginalQuantity, "Select Location");
                }

                if (_qtyID <= 0)
                {
                    e.Valid = false;
                    view.SetColumnError(gridColumnOriginalQuantity, "Qty > 0");
                }
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);

                e.Valid = false;
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void gridViewPallet_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void gridViewPallet_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (e.Column.FieldName.Equals("PalletStatus") || e.Column.FieldName.Equals("PalletStatusDescription"))
            {
                log.Debug("==> ROSetLocations chạy sự kiện gridViewPallet_RowCellClick");
                this.rpilkHold.BestFitMode = BestFitMode.BestFitResizePopup;
                gridColumn1.OptionsColumn.AllowFocus = true;
                gridViewPallet.FocusedColumn = gridColumn1;
                gridViewPallet.ShowEditor();
            }
        }

        private void ConvertToPalletInfo(ST_WMS_LoadAllPalletsByReceivingOrderID_Result PalletData)
        {
            Pallets pallectObj = null;

            log.Debug("==> ROSetLocations chạy hàm ConvertToPalletInfo");
            if (PalletData.PalletID > 0)
                pallectObj = this.dataProcessPallet.Select(p => p.PalletID == PalletData.PalletID).FirstOrDefault();
            else
                pallectObj = new Pallets();
            pallectObj.AfterDPQuantity = PalletData.OriginalQuantity;
            pallectObj.CanMove = PalletData.CanMove;
            pallectObj.CanNotAdd = PalletData.CanNotAdd;
            pallectObj.CurrentQuantity = PalletData.OriginalQuantity;
            pallectObj.Label = PalletData.Label;
            if (string.IsNullOrEmpty(pallectObj.Label))
            {
                MessageBox.Show("Label is null or emplty, please contract with IT now");
                log.ErrorFormat("==> Error is unexpected : Label is null or emplty with palletID=[{0}]", pallectObj.PalletID);
            }
            pallectObj.LocationID = PalletData.LocationID;
            pallectObj.OnHold = PalletData.OnHold;
            pallectObj.OriginalQuantity = PalletData.OriginalQuantity;
            pallectObj.PalletID = PalletData.PalletID;
            pallectObj.PalletStatus = PalletData.PalletStatus;
            pallectObj.PalletWeight = PalletData.PalletWeight;
            pallectObj.ReceivingOrderDetailID = receivingOrderDetail.ReceivingOrderDetailID;
            pallectObj.Remark = PalletData.Remark;
            pallectObj.status = PalletData.status;
            pallectObj.TS = PalletData.TS;
            pallectObj.UnitQuantity = PalletData.UnitQuantity;


            // Check pallet is update or is add new
            if (pallectObj.PalletID.Equals(0))
            {
                // Add new
                if (pallectObj.PalletStatus == null)
                {
                    pallectObj.PalletStatus = 0;
                }

                if (pallectObj.ReceivingOrderDetailID != receivingOrderDetail.ReceivingOrderDetailID)
                {
                    MessageBox.Show($"PalletID này sẽ được cập nhật sang một RO Detail khác, cần liên hệ ngay với IT để giải quyết, tránh gây lỗi hệ thống !");
                    log.ErrorFormat("==> Error is unexpected : PalletID update new  ReceivingOrderDetailID with palletID=[{0}] and ReceivingOrderDetailID=[{1}]",
                        pallectObj.PalletID, pallectObj.ReceivingOrderDetailID);
                }

                listPalletsInsert.Add(pallectObj);
            }
            else
            {
                if (pallectObj.ReceivingOrderDetailID != receivingOrderDetail.ReceivingOrderDetailID)
                {
                    MessageBox.Show($"PalletID này sẽ được cập nhật sang một RO Detail khác, cần liên hệ ngay với IT để giải quyết, tránh gây lỗi hệ thống !");
                    log.ErrorFormat("==> Error is unexpected : PalletID update new  ReceivingOrderDetailID with palletID=[{0}] and ReceivingOrderDetailID=[{1}]",
                        pallectObj.PalletID, pallectObj.ReceivingOrderDetailID);
                }

                // Update
                listPalletsUpdate.Add(pallectObj);
            }
        }

        private void gridViewPallet_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            log.Debug("==> ROSetLocations sự kiện gridViewPallet_CellValueChanging");
            this.gridViewPallet.SetRowCellValue(e.RowHandle, "IsModify", true);
        }

        private void rpibtn_LocationDetails_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            log.Debug("==> ROSetLocations sự kiện rpibtn_LocationDetails_ButtonClick");
            int locationID = (int)this.gridViewPallet.GetRowCellValue(this.gridViewPallet.FocusedRowHandle, "LocationID");
            frm_WM_Dialog_LocationDetail locationDetail = new frm_WM_Dialog_LocationDetail(locationID, 3, false);
            locationDetail.Show();
        }

        private void rpi_hle_PalletCartonDetails_DoubleClick(object sender, EventArgs e)
        {
            log.Debug("==> ROSetLocations sự kiện rpi_hle_PalletCartonDetails_DoubleClick");
            // Get customer type of current customer is order
            string customerType = AppSetting.CustomerList.Where(cus => cus.CustomerNumber == this.customererNumber).FirstOrDefault().CustomerType;

            // Only process when customer type has in array limited
            //IList<string> customerTypeList = new List<string> { CustomerTypeEnum.RANDOM_WEIGHT, CustomerTypeEnum.PCS };
            //if (!customerTypeList.Contains(customerType)) return;

            // Just only product has "Weight Required" then must display carton form
            var currentPro = AppSetting.ProductList.Where(p => p.ProductID == this.receivingOrderDetail.ProductID).FirstOrDefault();
            //if (currentPro == null || currentPro.IsWeightingRequire == null || !Convert.ToBoolean(currentPro.IsWeightingRequire)) return;
            //if (this.status == 2) return;
            if (this.gridColumn2.SummaryItem.SummaryValue != null)
            {
                // Get total quantity
                double totalQuantity = (double)this.gridColumn2.SummaryItem.SummaryValue;
                if (totalQuantity > 100)
                {
                    DialogResult dlResult = MessageBox.Show("Quantity > 100 ctns. Do you want to creating?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlResult.Equals(DialogResult.No))
                    {
                        return;
                    }
                }
            }

            int rowIndex = this.gridViewPallet.FocusedRowHandle;
            int palletID = (int)this.gridViewPallet.GetRowCellValue(rowIndex, "PalletID");
            if (palletID <= 0) return;

            var countPalletCartonInsert = FileProcess.LoadTable("SELECT COUNT(PalletCartons.PalletCartonID) as Count " +
                " FROM  PalletCartons " +
                " INNER JOIN Pallets ON PalletCartons.PalletID = Pallets.PalletID " +
                " WHERE(Pallets.PalletID = " + palletID + ")");
            int count = Convert.ToInt32(countPalletCartonInsert.Rows[0]["Count"]);
            short quantity = (short)this.gridViewPallet.GetRowCellValue(rowIndex, "OriginalQuantity");
            if (this.status != 2)
            {
                if (count <= 0)
                {
                    var confirmMsg = MessageBox.Show("Do you want to create new [" + quantity + "] cartons ID?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (confirmMsg.Equals(DialogResult.Yes))
                    {
                        DataProcess<object> insertPalletCarton = new DataProcess<object>();
                        int insertResult = insertPalletCarton.ExecuteNoQuery("STPalletCartonWeightInsert @PalletID={0},@OriginalQuantity={1},@Status={2},@CreatedBy={3}",
                            palletID, quantity, receivingOrderDetail.Status, AppSetting.CurrentUser.LoginName);
                    }
                }
            }


            int totalOriginalQuantity = Convert.ToInt32(this.gridColumnOriginalQuantity.SummaryItem.SummaryValue);
            frm_WM_PalletCartons palletCarton = new frm_WM_PalletCartons(palletID, this.receivingOrderDetail.Status,
                quantity, this.receivingOrderDetail.PackagingWeight, this.receivingOrderDetail.RejectPercentage, this.receivingOrderDetail.ReceivingOrderID);
            if (!palletCarton.Enabled) return;
            palletCarton.ShowDialog();
            LoadData();
        }

        private void gridViewPallet_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            log.Debug("==> ROSetLocations sự kiện gridViewPallet_CellValueChanged");
            var currentRoDetail = this.roDetailList[e.RowHandle];
            var currenPallet = this.dataProcessPallet.Select(p => p.PalletID == currentRoDetail.PalletID).FirstOrDefault();
            switch (e.Column.FieldName)
            {
                case "Label":
                    if (Convert.ToBoolean(currenPallet.IsSendNavi)) return;
                    this.gridColumnOriginalQuantity.OptionsColumn.AllowEdit = true;
                    UpdatePallets(this.gridViewPallet.FocusedRowHandle);
                    break;
                case "OriginalQuantity":
                    if (Convert.ToBoolean(currenPallet.IsSendNavi)) return;
                    this.QuantityUpdate();
                    break;
                case "UnitQuantity":
                    if (Convert.ToBoolean(currenPallet.IsSendNavi)) return;
                    currenPallet.UnitQuantity = Convert.ToInt32(e.Value);
                    this.dataProcessPallet.Update(currenPallet);
                    break;
                case "PalletWeight":
                    if (Convert.ToBoolean(currenPallet.IsSendNavi)) return;
                    currenPallet.PalletWeight = (float)e.Value;
                    this.dataProcessPallet.Update(currenPallet);
                    break;
                case "ProductionDate":
                    if (Convert.ToDateTime(e.Value) >= DateTime.Now)
                    {
                        XtraMessageBox.Show("Please re-enter correct date", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.gridViewPallet.FocusedColumn = e.Column;
                    }
                    break;
                case "UseByDate":
                    if (Convert.ToDateTime(e.Value) < Convert.ToDateTime(this.gridViewPallet.GetFocusedRowCellValue("ProductionDate")))
                    {
                        XtraMessageBox.Show("ProDate > ExpDate", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.gridViewPallet.FocusedColumn = e.Column;
                    }
                    break;
                case "Remark":
                    string palletIDSelected = this.gridViewPallet.GetFocusedRowCellValue("PalletID").ToString();
                    if (string.IsNullOrEmpty(palletIDSelected) || palletIDSelected.Equals("0")) return;
                    DataProcess<Object> Da = new DataProcess<object>();
                    int resualt = Da.ExecuteNoQuery("UPDATE Pallets SET Remark='" + gridViewPallet.GetFocusedRowCellValue("Remark") + "' WHERE PalletID=" + palletIDSelected);
                    //if (this.status==2)
                    //{
                    //    DataProcess<Object> Da = new DataProcess<object>();
                    //    int resualt = Da.ExecuteNoQuery("UPDATE Pallets SET Remark='" + gridViewPallet.GetFocusedRowCellValue("Remark") + "' WHERE PalletID=" + palletIDSelected);
                    //}
                    //else
                    //{
                    //     UpdatePallets(this.gridViewPallet.FocusedRowHandle);
                    //}

                    break;
            }
            this._isModified = true;
        }

        private void gridViewPallet_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    {
                        if (!btnAccept.Checked)
                        {
                            log.Debug("==> ROSetLocations sự kiện gridViewPallet_KeyDown với phím Keys.Delete");
                            if (btnAccept.Checked)
                            {
                                XtraMessageBox.Show("Can not delete accepted or confirmed products !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }

                            DataProcess<Pallets> palletDA = new DataProcess<Pallets>();
                            int[] selectedRows = this.gridViewPallet.GetSelectedRows();
                            int id = 0;
                            int result = -2;

                            if (XtraMessageBox.Show("Are you sure to delete pallets ?", "TPWMS", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                            {
                                return;
                            }

                            for (int i = 0; i < selectedRows.Count(); i++)
                            {
                                id = Convert.ToInt32(this.gridViewPallet.GetRowCellValue(selectedRows[i], "PalletID"));
                                bool hasSyncNavi = Convert.ToBoolean(this.gridViewPallet.GetFocusedRowCellValue("IsSendNavi"));
                                if (!hasSyncNavi)
                                    result = palletDA.ExecuteNoQuery("Delete From Pallets Where PalletID = {0}", id);
                            }

                            if (result != -2)
                            {
                                this.LoadData();
                            }
                        }
                        break;
                    }
                case Keys.Escape:
                    {
                        int palletID = Convert.ToInt32(this.gridViewPallet.GetFocusedRowCellValue("PalletID"));
                        bool hasSyncNavi = Convert.ToBoolean(this.gridViewPallet.GetFocusedRowCellValue("IsSendNavi"));
                        log.Debug("==> ROSetLocations sự kiện gridViewPallet_KeyDown với phím Keys.Escape");
                        if (palletID <= 0 && !hasSyncNavi)
                        {
                            this.gridViewPallet.DeleteSelectedRows();
                        }
                        break;
                    }
            }
        }

        private void btnLabelA4_Click(object sender, EventArgs e)
        {
            log.Debug("==> ROSetLocations sự kiện btnLabelA4_Click");
            PrintLabelA4(true);
        }

        private void PrintLabelA4(bool isPreview)
        {
            log.Debug("==> ROSetLocations chạy hàm PrintLabelA4");
            XtraReport labelA4Report = null;
            var currentUser = AppSetting.CustomerList.FirstOrDefault(c => string.Equals(c.CustomerNumber, this.customererNumber));
            if (string.Equals(currentUser.CustomerType, CustomerTypeEnum.PCS))
            {
                labelA4Report = new rptLabelA4Short_Barcode_pcs();
            }
            else
            {
                labelA4Report = new rptLabelA4Short_Barcode();
            }

            labelA4Report.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
            labelA4Report.Parameters["parameter1"].Value = 3;
            labelA4Report.DataSource = FileProcess.LoadTable($"STLabel1ReceivingOrderDetail @varReceivingOrderDetailID={this.receivingOrderDetail.ReceivingOrderDetailID}");
            labelA4Report.RequestParameters = false;

            ReportPrintToolWMS printTool = new ReportPrintToolWMS(labelA4Report);
            printTool.AutoShowParametersPanel = false;

            if (isPreview)
            {
                printTool.ShowPreview();
            }
            else
            {
                printTool.Print();
            }
        }

        private void PrintLabelDecal(bool isPreview)
        {
            log.Debug("==> ROSetLocations chạy hàm PrintLabelDecal");
            rptLabelDecal lb = new rptLabelDecal();
            lb.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
            lb.Parameters["varReceivingOrderID"].Value = (int)this.receivingOrderDetail.ReceivingOrderID;
            lb.DataSource = multilabel.Executing("STLabel1ReceivingOrderDetail @varReceivingOrderDetailID={0}", this.receivingOrderDetail.ReceivingOrderDetailID);
            lb.xrLabelRO.Text = this.receivingOrderNumber;
            lb.RequestParameters = false;
            IList<STLabel1ReceivingOrderDetail_Result> getPalletIDBarcode = (IList<STLabel1ReceivingOrderDetail_Result>)lb.DataSource;
            lb.bcPalletID.Text = getPalletIDBarcode.Select(obj => obj.PalletID_Barcode).FirstOrDefault();

            ReportPrintToolWMS printTool = new ReportPrintToolWMS(lb);
            printTool.AutoShowParametersPanel = false;

            if (isPreview)
            {
                printTool.ShowPreview();
            }
            else
            {
                printTool.Print();
            }
        }

        private void PrintLabelA5(bool isPreview)
        {
            log.Debug("==> ROSetLocations chạy hàm PrintLabelA5");
            List<STLabel1Label_Result> dataSource = new List<STLabel1Label_Result>();
            DataProcess<STLabel1Label_Result> labelDP = new DataProcess<STLabel1Label_Result>();
            //List<object> dataSource = new List<object>();
            //DataProcess<object> labelDP = new DataProcess<object>();
            foreach (var palletItem in this.roDetailList)
            {
                var lbResult = labelDP.Executing("STLabel1Label @PalletID={0}", palletItem.PalletID).FirstOrDefault();
                if (lbResult != null)
                {
                    dataSource.Add(lbResult);
                }
            }

            XtraReport report = null;
            var currentUser = AppSetting.CustomerList.FirstOrDefault(c => string.Equals(c.CustomerNumber, this.customererNumber));
            if (string.Equals(currentUser.CustomerType, CustomerTypeEnum.PCS))
            {
                report = new rptLabel_Barcode_pcs();
            }
            else
            {
                report = new rptLabel_Barcode();
            }

            report.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
            report.Parameters["parameter1"].Value = 1;
            report.DataSource = dataSource;
            report.RequestParameters = false;
            report.PaperKind = System.Drawing.Printing.PaperKind.A5;

            var printTool = new ReportPrintToolWMS(report)
            {
                AutoShowParametersPanel = false
            };

            if (isPreview)
            {
                printTool.ShowPreview();
            }
            else
            {
                printTool.Print();
            }
        }

        private void btnPrintA4_Click(object sender, EventArgs e)
        {
            PrintLabelA4(false);
        }

        private void btnLabelA5_Click(object sender, EventArgs e)
        {
            PrintLabelA5(true);
        }

        private void btnPrintA5_Click(object sender, EventArgs e)
        {
            PrintLabelA5(false);
        }

        private void btnLabelDecal_Click(object sender, EventArgs e)
        {
            PrintLabelDecal(true);
        }

        private void btnPrintDecal_Click(object sender, EventArgs e)
        {
            log.Debug("==> ROSetLocations chạy sự kiện btnPrintDecal_Click");
            bool isPreview = true;
            string strPalettID = this.gridViewPallet.GetRowCellValue(this.gridViewPallet.FocusedRowHandle, "PalletID").ToString();
            int palletID = Convert.ToInt32(strPalettID);
            string customerType = AppSetting.CustomerList.Where(cus => cus.CustomerNumber == this.customererNumber).FirstOrDefault().CustomerType;
            if (customerType == CustomerTypeEnum.PCS)// CustomerTypeEnum.PCS)
            {
                DataProcess<STLabel1Label_Result> label = new DataProcess<STLabel1Label_Result>();
                rptLabel_Barcode_pcs lb = new rptLabel_Barcode_pcs();
                lb.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
                lb.Parameters["parameter1"].Value = 1;
                lb.DataSource = label.Executing("STLabel1Label @PalletID={0}", palletID);
                lb.RequestParameters = false;
                IList<STLabel1Label_Result> getPalletIDBarcode = (IList<STLabel1Label_Result>)lb.DataSource;
                lb.xrBarCodeID2.Text = "*" + getPalletIDBarcode.Select(obj => obj.PalletID_Barcode).FirstOrDefault() + "*";
                ReportPrintToolWMS printTool = new ReportPrintToolWMS(lb);
                printTool.AutoShowParametersPanel = false;

                if (isPreview)
                {
                    printTool.ShowPreview();
                }
                else
                {
                    printTool.Print();
                }

            }
            else
            {
                PrintLabelDecal(true);
            }

        }

        private void btnAllocate_Click(object sender, EventArgs e)
        {
            log.Debug("==> ROSetLocations chạy sự kiện btnAllocate_Click");
            int hasSyncNavi = this.roDetailList.Count(p => Convert.ToBoolean(p.IsSendNavi));
            if (hasSyncNavi > 0)
            {
                XtraMessageBox.Show("Pallets had sync with WareNavi, you couldn't modify it!", "TWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frm_WM_ReceivingProductAllocation allocation = new frm_WM_ReceivingProductAllocation(this.receivingOrderDetail);
            if (!allocation.Enabled) return;
            allocation.ShowDialog();
            this.LoadData();
        }

        private void btnHoldAll_Click(object sender, EventArgs e)
        {
            try
            {
                log.Debug("==> ROSetLocations chạy sự kiện btnHoldAll_Click");
                PalletStatu palletStatusChange = null;
                frm_WM_HoldAll holdAll = new frm_WM_HoldAll(this.receivingOrderNumber, "RS", 0, this.receivingOrderDetail.ReceivingOrderDetailID);
                if (!holdAll.Enabled) return;
                holdAll.ShowDialog();
                palletStatusChange = holdAll.currentPalletSeleceted;
                if (!string.IsNullOrEmpty(palletStatusChange.PalletStatusDescription))
                {
                    for (int rowIndex = 0; rowIndex < this.gridViewPallet.RowCount; rowIndex++)
                    {
                        int palletID = Int32.Parse(this.gridViewPallet.GetRowCellValue(rowIndex, "PalletID").ToString());
                        if (palletID <= 0) continue;

                        this.gridViewPallet.SetRowCellValue(rowIndex, "PalletStatus", palletStatusChange.PalletStatus);
                        this.gridViewPallet.SetRowCellValue(rowIndex, "PalletStatusDescription", palletStatusChange.PalletStatusDescription);
                        this.gridViewPallet.SetRowCellValue(rowIndex, "IsModify", true);
                        this.UpdatePallets(rowIndex);
                    }
                    this.gridViewPallet.RefreshData();
                }
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);

                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAccept_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (isUpdate == true)
                {

                    TransactionDAC trans = new TransactionDAC();
                    DataProcess<ReceivingOrderDetails> receivingOrderDetailsDA = new DA.DataProcess<DA.ReceivingOrderDetails>();
                    if (receivingOrderDetail.Status == 0)
                    {
                        log.Debug("==> ROSetLocations chạy sự kiện btnAccept_CheckedChanged với trạng thái Insert");
                        trans.STTransactionInsert(receivingOrderDetail.ReceivingOrderDetailID, receivingOrderNumber, AppSetting.CurrentUser.LoginName, customererNumber);
                        receivingOrderDetailsDA.ExecuteNoQuery("STReceivingOrderDetailUpdateQty @varReceivingOrderDetailID={0}", receivingOrderDetail.ReceivingOrderDetailID);
                        receivingOrderDetail = receivingOrderDetailsDA.Select(c => c.ReceivingOrderDetailID == receivingOrderDetail.ReceivingOrderDetailID).FirstOrDefault();
                        this.Close();
                    }
                    else
                    {
                        log.Debug("==> ROSetLocations chạy sự kiện btnAccept_CheckedChanged với trạng thái Delete");
                        trans.STTransactionDelete(receivingOrderDetail.ReceivingOrderDetailID, Convert.ToInt32(receivingOrderDetail.TransactionID), true, AppSetting.CurrentUser.LoginName);
                        receivingOrderDetail = receivingOrderDetailsDA.Select(c => c.ReceivingOrderDetailID == receivingOrderDetail.ReceivingOrderDetailID).FirstOrDefault();
                    }
                    this.LoadStatus();

                }
                //this.RemoveRowEmpty();
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);

                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            log.Debug("==> ROSetLocations chạy sự kiện Đóng Form btnClose_Click");
            this.Close();
        }

        private void gridViewPallet_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if (this._isLoaded)
            {
                if (e.PrevFocusedColumn != null && e.PrevFocusedColumn.FieldName != null)
                    switch (e.PrevFocusedColumn.FieldName)
                    {
                        case "OriginalQuantity":
                            {
                                log.Debug("==> ROSetLocations chạy sự kiện gridViewPallet_FocusedColumnChanged");
                                int qty = Convert.ToInt32(this.gridViewPallet.GetFocusedRowCellValue("OriginalQuantity"));
                                int locationID = Convert.ToInt32(this.gridViewPallet.GetFocusedRowCellValue(this.gridViewPallet.Columns["LocationID"]));
                                if (qty <= 0 && locationID > 0)
                                {
                                    this.gridViewPallet.FocusedColumn = this.gridColumnOriginalQuantity;
                                }
                                break;
                            }
                    }
            }
        }

        private void repositoryItemButtonEditDecal_Click(object sender, EventArgs e)
        {
            log.Debug("==> ROSetLocations chạy sự kiện repositoryItemButtonEditDecal_Click");
            bool isPreview = true;
            string strPalettID = this.gridViewPallet.GetRowCellValue(this.gridViewPallet.FocusedRowHandle, "PalletID").ToString();
            int palletID = Convert.ToInt32(strPalettID);
            string customerType = AppSetting.CustomerList.Where(cus => cus.CustomerNumber == this.customererNumber).FirstOrDefault().CustomerType;
            if (customerType == CustomerTypeEnum.PCS)// CustomerTypeEnum.PCS)
            {
                DataProcess<STLabel1Label_Result> label = new DataProcess<STLabel1Label_Result>();
                rptLabel_Barcode_pcs lb = new rptLabel_Barcode_pcs();
                lb.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
                lb.Parameters["parameter1"].Value = 1;
                lb.DataSource = label.Executing("STLabel1Label @PalletID={0}", palletID);
                lb.RequestParameters = false;
                IList<STLabel1Label_Result> getPalletIDBarcode = (IList<STLabel1Label_Result>)lb.DataSource;
                lb.xrBarCodeID2.Text = "*" + getPalletIDBarcode.Select(obj => obj.PalletID_Barcode).FirstOrDefault() + "*";
                ReportPrintToolWMS printTool = new ReportPrintToolWMS(lb);
                printTool.AutoShowParametersPanel = false;

                if (isPreview)
                {
                    printTool.Print();
                }
                else
                {
                    printTool.Print();
                }

            }
            else
            {
                isPreview = true;

                DataProcess<STLabel1Label_Result> label = new DataProcess<STLabel1Label_Result>();
                rptLabelDecal lb = new rptLabelDecal();
                lb.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
                lb.Parameters["parameter1"].Value = 1;
                lb.xrLabelRO.Text = receivingOrderNumber;
                lb.RequestParameters = false;
                lb.DataSource = label.Executing("STLabel1Label @PalletID={0}", palletID);
                ReportPrintToolWMS printTool = new ReportPrintToolWMS(lb);
                printTool.AutoShowParametersPanel = false;

                if (isPreview)
                {
                    printTool.Print();
                }
                else
                {
                    printTool.Print();
                }
            }
        }

        private void rpi_btn_PalletCarton_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            this.rpi_hle_PalletCartonDetails_DoubleClick(sender, e);
        }

        private void dateEditProductionDate_Validating(object sender, CancelEventArgs e)
        {
            log.Debug("==> ROSetLocations chạy sự kiện dateEditProductionDate_Validating");
            if (this.dateEditProductionDate.DateTime > DateTime.Now) e.Cancel = true;
            if (this.dateEditUseByDate.EditValue != null)
            {
                if (this.dateEditUseByDate.DateTime < this.dateEditProductionDate.DateTime)
                {
                    e.Cancel = true;
                }
            }

            DataProcess<object> dispatchingOrderDetailDA = new DataProcess<object>();
            if (this.dateEditProductionDate.DateTime.Equals(DateTime.MinValue))
            {
                dispatchingOrderDetailDA.ExecuteNoQuery("Update ReceivingOrderDetails set ProductionDate=NULL Where  ReceivingOrderDetailID=" + this.receivingOrderDetail.ReceivingOrderDetailID);
                return;
            }


            dispatchingOrderDetailDA.ExecuteNoQuery("Update ReceivingOrderDetails set ProductionDate='" + this.dateEditProductionDate.DateTime.ToString("yyyy-MM-dd")
                + "' Where  ReceivingOrderDetailID=" + this.receivingOrderDetail.ReceivingOrderDetailID);
        }

        private void dateEditUseByDate_Validating(object sender, CancelEventArgs e)
        {
            log.Debug("==> ROSetLocations chạy sự kiện dateEditUseByDate_Validating");
            if (this.dateEditUseByDate.DateTime < DateTime.Now) e.Cancel = true;
            if (this.dateEditProductionDate.EditValue != null)
            {
                if (!this.dateEditUseByDate.DateTime.Equals(DateTime.MinValue) && this.dateEditUseByDate.DateTime < this.dateEditProductionDate.DateTime)
                {
                    e.Cancel = true;
                }
            }

            DataProcess<object> dispatchingOrderDetailDA = new DataProcess<object>();
            if (this.dateEditUseByDate.DateTime.Equals(DateTime.MinValue))
            {
                dispatchingOrderDetailDA.ExecuteNoQuery("Update ReceivingOrderDetails set UseByDate=NULL Where  ReceivingOrderDetailID=" + this.receivingOrderDetail.ReceivingOrderDetailID);
                e.Cancel = false;
                return;
            }

            dispatchingOrderDetailDA.ExecuteNoQuery("Update ReceivingOrderDetails set UseByDate='" + this.dateEditUseByDate.DateTime.ToString("yyyy-MM-dd")
                + "' Where  ReceivingOrderDetailID=" + this.receivingOrderDetail.ReceivingOrderDetailID);
        }

        private void speRejectPercentage_EditValueChanged(object sender, EventArgs e)
        {
            log.Debug("==> ROSetLocations chạy sự kiện speRejectPercentage_EditValueChanged");
            if (string.IsNullOrEmpty(Convert.ToString(this.speRejectPercentage.EditValue))) return;
            decimal rejectPercentage = Convert.ToDecimal(this.speRejectPercentage.EditValue);
            DataProcess<object> dispatchingOrderDetailDA = new DataProcess<object>();
            dispatchingOrderDetailDA.ExecuteNoQuery("Update ReceivingOrderDetails set RejectPercentage=" + rejectPercentage
                + " Where  ReceivingOrderDetailID=" + this.receivingOrderDetail.ReceivingOrderDetailID);
        }

        private void spinEditTotalWeight_EditValueChanged(object sender, EventArgs e)
        {
            log.Debug("==> ROSetLocations chạy sự kiện spinEditTotalWeight_EditValueChanged");
            if (string.IsNullOrEmpty(Convert.ToString(this.spinEditTotalWeight.EditValue))) return;
            decimal packagingWeight = Convert.ToDecimal(this.spinEditTotalWeight.EditValue);
            DataProcess<object> dispatchingOrderDetailDA = new DataProcess<object>();
            dispatchingOrderDetailDA.ExecuteNoQuery("Update ReceivingOrderDetails set PackagingWeight=" + packagingWeight
                + " Where  ReceivingOrderDetailID=" + this.receivingOrderDetail.ReceivingOrderDetailID);
        }

        private void textEditRemark_EditValueChanged(object sender, EventArgs e)
        {
            if (this.textEditRemark.IsModified)
            {
                log.Debug("==> ROSetLocations chạy sự kiện textEditRemark_EditValueChanged");
                DataProcess<object> dispatchingOrderDetailDA = new DataProcess<object>();
                dispatchingOrderDetailDA.ExecuteNoQuery("Update ReceivingOrderDetails set Remark=N'" + this.textEditRemark.Text
                    + "' Where  ReceivingOrderDetailID=" + this.receivingOrderDetail.ReceivingOrderDetailID);
            }
        }

        private void btnBreakRODetail_Click(object sender, EventArgs e)
        {
            if (this.gridViewPallet.SelectedRowsCount <= 0)
            {
                MessageBox.Show("Please selected rows to break.", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var dl = MessageBox.Show("Do you want to break the rows selected to new Receiving Order details?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dl.Equals(DialogResult.No)) return;

            log.Debug("==> ROSetLocations chạy sự kiện btnBreakRODetail_Click");

            //Break the Receiving Order Detail code here
            //Trí giúp test code này trên database test kỹ trước khi đưa vào thực hiện. Chú ý có StoredProc này mới : STReceivingOrderDetailPalletBreak

            StringBuilder PalletIDString = new StringBuilder();
            PalletIDString.Append("");
            int count = 0;
            string palletHasSyncNavi = "";
            string palletID = "";
            bool isSendNavi = false;
            foreach (int rowIndex in this.gridViewPallet.GetSelectedRows())
            {
                isSendNavi = Convert.ToBoolean(this.gridViewPallet.GetRowCellValue(rowIndex, "IsSendNavi"));
                palletID = Convert.ToString(this.gridViewPallet.GetRowCellValue(rowIndex, "PalletID"));
                // Get pallet has sync with navi
                if (isSendNavi) palletHasSyncNavi += palletID + ",";
                PalletIDString.Append(palletID);
                if (count < this.gridViewPallet.SelectedRowsCount - 1)
                {
                    PalletIDString.Append(",");
                    count++;
                }
            }
            PalletIDString.Append("");

            // Check pallet has sync with navi
            if (!string.IsNullOrEmpty(palletHasSyncNavi))
            {
                int totalPalletHasSync = this.roDetailList.Count(p => p.NaviPalletID != null);
                if (totalPalletHasSync < roDetailList.Count)
                {
                    MessageBox.Show($"This PalletIDs [{palletHasSyncNavi}] had sync with WareNavi you couldn't modify it!\nPlease uncheck it before process ", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            using (var context = new SwireDBEntities())
            {
                ObjectParameter newReceivingOrderDetailID = new ObjectParameter("NewReceivingOrderDetailID", 0);
                context.STReceivingOrderDetailPalletBreak(this.receivingOrderDetail.ReceivingOrderDetailID,
                    PalletIDString.ToString(), AppSetting.CurrentUser.LoginName, newReceivingOrderDetailID);

                int newRODetailID = Convert.ToInt32(newReceivingOrderDetailID.Value);

                //Set current receivingDetailID=new ID
                // comment doan code nay, chua biet y nghia no lam gi (tri 25/02/2022 kiem tra loi chuyen nham pallet cho RoDetailID khac)
                //this.receivingOrderDetail.ReceivingOrderDetailID = newRODetailID;
            }
            this.LoadData();
            //
            //    Sau đó clear data của form frm_WM_SetLocations, rồi load lại data của @NewReceivingOrderDetailID mới
        }

        private void speRejectPercentage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                this.spinEditTotalWeight.SelectAll();
            }
        }
        private bool alreadyExist(string _text, ref char KeyChar)
        {
            if (_text.IndexOf('.') > -1)
            {
                KeyChar = '.';
                return true;
            }
            if (_text.IndexOf(',') > -1)
            {
                KeyChar = ',';
                return true;
            }
            return false;
        }

        private void speRejectPercentage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                    && !char.IsDigit(e.KeyChar)
                    && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            //check if '.' , ',' pressed
            char sepratorChar = 's';
            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                // check if it's in the beginning of text not accept
                if (speRejectPercentage.Text.Length == 0) e.Handled = true;
                // check if it's in the beginning of text not accept
                if (speRejectPercentage.SelectionStart == 0) e.Handled = true;
                // check if there is already exist a '.' , ','
                if (alreadyExist(speRejectPercentage.Text, ref sepratorChar)) e.Handled = true;
                //check if '.' or ',' is in middle of a number and after it is not a number greater than 99
                if (speRejectPercentage.SelectionStart != speRejectPercentage.Text.Length && e.Handled == false)
                {
                    // '.' or ',' is in the middle
                    string AfterDotString = speRejectPercentage.Text.Substring(speRejectPercentage.SelectionStart);

                    if (AfterDotString.Length > 2)
                    {
                        e.Handled = true;
                    }
                }
            }
            //check if a number pressed

            if (Char.IsDigit(e.KeyChar))
            {
                //check if a coma or dot exist
                if (alreadyExist(speRejectPercentage.Text, ref sepratorChar))
                {
                    int sepratorPosition = speRejectPercentage.Text.IndexOf(sepratorChar);
                    string afterSepratorString = speRejectPercentage.Text.Substring(sepratorPosition + 1);
                    if (speRejectPercentage.SelectionStart > sepratorPosition && afterSepratorString.Length > 1)
                    {
                        e.Handled = true;
                    }
                }
            }

            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void spinEditTotalWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                 && !char.IsDigit(e.KeyChar)
                 && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            //check if '.' , ',' pressed
            char sepratorChar = 's';
            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                // check if it's in the beginning of text not accept
                if (spinEditTotalWeight.Text.Length == 0) e.Handled = true;
                // check if it's in the beginning of text not accept
                if (spinEditTotalWeight.SelectionStart == 0) e.Handled = true;
                // check if there is already exist a '.' , ','
                if (alreadyExist(spinEditTotalWeight.Text, ref sepratorChar)) e.Handled = true;
                //check if '.' or ',' is in middle of a number and after it is not a number greater than 99
                if (spinEditTotalWeight.SelectionStart != spinEditTotalWeight.Text.Length && e.Handled == false)
                {
                    // '.' or ',' is in the middle
                    string AfterDotString = spinEditTotalWeight.Text.Substring(spinEditTotalWeight.SelectionStart);

                    if (AfterDotString.Length > 2)
                    {
                        e.Handled = true;
                    }
                }
            }
            //check if a number pressed

            if (Char.IsDigit(e.KeyChar))
            {
                //check if a coma or dot exist
                if (alreadyExist(spinEditTotalWeight.Text, ref sepratorChar))
                {
                    int sepratorPosition = spinEditTotalWeight.Text.IndexOf(sepratorChar);
                    string afterSepratorString = spinEditTotalWeight.Text.Substring(sepratorPosition + 1);
                    if (spinEditTotalWeight.SelectionStart > sepratorPosition && afterSepratorString.Length > 1)
                    {
                        e.Handled = true;
                    }
                }
            }

            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void textEditRemark_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void spinEdit1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        /// <summary>
        /// Handles the EditValueChanged event of the textEditCustomerRef control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void textEditCustomerRef_EditValueChanged(object sender, EventArgs e)
        {
            // Lock => To avoid continuous event coming - Sequence handle event
            lock (this.lockObj)
            {
                log.Debug("==> ROSetLocations chạy sự kiện textEditCustomerRef_EditValueChanged");
                if (this.textEditCustomerRef.EditValue == null) return;
                var editingValue = this.textEditCustomerRef.EditValue.ToString();
                // Update CustomRef value to ReceivingOrderDetails

                this.receivingOrderDetail.CustomerRef = editingValue;
                var sqlUpdateCusRefQuery = $"UPDATE ReceivingOrderDetails SET CustomerRef = N'{editingValue}' WHERE ReceivingOrderDetailID = {this.receivingOrderDetail.ReceivingOrderDetailID}";
                this.recevingOrderDetailDA.ExecuteNoQuery(sqlUpdateCusRefQuery);
            }
        }

        private void rpilkHold_CloseUp(object sender, CloseUpEventArgs e)
        {
            try
            {
                log.Debug("==> ROSetLocations chạy sự kiện rpilkHold_CloseUp");
                DataProcess<object> da = new DataProcess<object>();
                int palletIDSelected = Convert.ToInt32(this.gridViewPallet.GetFocusedRowCellValue("PalletID"));
                if (palletIDSelected <= 0) return;
                frm_WM_HoldAll frm = new frm_WM_HoldAll(this.receivingOrderNumber, "PI", (byte)e.Value, palletIDSelected);
                frm.ShowDialog();
                if (frm.currentPalletSeleceted == null)
                {
                    e.AcceptValue = false;
                    return;
                }
                int index = frm.currentPalletSeleceted.PalletStatus;
                var rowSelected = frm.currentPalletSeleceted.PalletStatusDescription;
                bool isHold = false;
                if (index > 0)
                {
                    isHold = true;
                }
                var currentPallet = this.roDetailList.Where(p => p.PalletID.Equals(palletIDSelected)).FirstOrDefault();
                var indexPallet = this.roDetailList.IndexOf(currentPallet);
                currentPallet.OnHold = isHold;
                currentPallet.PalletStatusDescription = rowSelected;
                currentPallet.PalletStatus = (byte)index;
                this.roDetailList[indexPallet] = currentPallet;

                DataProcess<object> palletsDA = new DataProcess<object>();
                int result = palletsDA.ExecuteNoQuery("STPalletInfo_Locations_UpdatePalletStatus @PalletID={0},@PalletStatus={1},@ProcessUser={2}",
                     Convert.ToInt32(palletIDSelected), index, AppSetting.CurrentUser.LoginName);
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);

                XtraMessageBox.Show(ex.Message, "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void repositoryItemButtonEditCarton_ButtonClick(object sender, ButtonPressedEventArgs e)
        {

            log.Debug("==> ROSetLocations chạy sự kiện repositoryItemButtonEditCarton_ButtonClick");
            int customerID = Convert.ToInt32(customererNumber.Substring(4));
            //this.InitData(rODetail, rONumber, custNumber, isRandomWeight, status);
            DataProcess<Employees> dataProcess = new DataProcess<Employees>();
            fullInfoEmployees = dataProcess.Select(em => em.EmployeeID == AppSetting.CurrentUser.EmployeeID).FirstOrDefault();

            rptPalletCartonDetail rp = new rptPalletCartonDetail();
            var STReceivingNoteByCartonList = FileProcess.LoadTable("ST_WMS_LoadDetailPalletCarton @varReceivingOrderID=" + receivingOrderDetail.ReceivingOrderID + ", @varPalletID=" + Convert.ToInt32(gridViewPallet.GetFocusedRowCellValue("PalletID")));
            //int customerID = Convert.ToInt32(lookUpEditCustomerID.Tag);
            if (STReceivingNoteByCartonList.Rows.Count > 0)
            {
                rp.DataSource = STReceivingNoteByCartonList;
                rp.RequestParameters = false;
                rp.Parameters["varLoginUser"].Value = AppSetting.CurrentUser.LoginName;
                rp.Parameters["varCurrentUser"].Value = fullInfoEmployees.FullName;
                ReportPrintToolWMS printTool = new ReportPrintToolWMS(rp, customerID);
                printTool.AutoShowParametersPanel = false;
                printTool.ShowPreview();
            }
            else
            {
                MessageBox.Show("Nothing to print");
            }

        }

        private void gridViewPallet_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (e.RowHandle < 0) return;

            int qtyReceived = Convert.ToInt32(this.gridViewPallet.GetRowCellValue(e.RowHandle, "OriginalQuantity"));
            int AReceived = Convert.ToInt32(this.gridViewPallet.GetRowCellValue(e.RowHandle, "NaviROQty"));
            string naviPalletID = Convert.ToString(this.gridViewPallet.GetRowCellValue(e.RowHandle, "NaviROPalletID"));
            if (!string.IsNullOrEmpty(naviPalletID))
            {
                if (qtyReceived == AReceived)
                {
                    e.Appearance.BackColor = Color.FromArgb(143, 208, 202);
                    e.HighPriority = true;
                }
                else
                {
                    e.Appearance.BackColor = Color.Red;
                    e.HighPriority = true;
                }

            }
        }

        private void btnSyncQtyNavi_Click(object sender, EventArgs e)
        {
            if (this.gridViewPallet.SelectedRowsCount <= 0)
            {
                XtraMessageBox.Show("Please select pallets you want to sync quantity!", "TWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            };
            // Only process when status=1
            if (this.status != 1)
            {
                XtraMessageBox.Show("Only handle pallets with a status equal to 1!", "TWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (XtraMessageBox.Show("Are you sure to sync quantity for this pallets?", "TWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            StringBuilder sqlClause = new StringBuilder();
            sqlClause.Append("(");
            int totalPallet = this.gridViewPallet.SelectedRowsCount;
            int index = 1;
            int palletIDSelected = 0;
            string qtyNaviStr = "";
            foreach (var palletIndex in this.gridViewPallet.GetSelectedRows())
            {
                int AReceived = Convert.ToInt32(this.gridViewPallet.GetRowCellValue(palletIndex, "NaviROQty"));
                palletIDSelected = Convert.ToInt32(this.gridViewPallet.GetRowCellValue(palletIndex, "PalletID"));
                sqlClause.Append(palletIDSelected);
                if (AReceived <= 0)
                    qtyNaviStr += palletIDSelected + ",";
                if (index < totalPallet)
                    sqlClause.Append(",");
            }
            sqlClause.Append(")");
            if (!string.IsNullOrEmpty(qtyNaviStr))
            {
                XtraMessageBox.Show($"This pallets =[{qtyNaviStr}] not yet send to navi!", "TWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataProcess<Pallets> palletsDA = new DataProcess<Pallets>();
            int resultSync = palletsDA.ExecuteNoQuery("STSyncQtyPalletByPalletID @PalletIDStr='" + sqlClause.ToString() + "'");
            if (resultSync > 0)
            {
                XtraMessageBox.Show("SYNC SUCCESSFUL!", "TWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
            {
                XtraMessageBox.Show("SYNC FAIL!", "TWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnSetStation_Click(object sender, EventArgs e)
        {
            int[] selectedRows = this.gridViewPallet.GetSelectedRows();
            if (selectedRows.Count() == 0)
            {
                MessageBox.Show("No Pallets selected, please select it!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            palletAllLocationDA = new DA.DataProcess<DA.STVSPalletAllocation_Result>();
            var lstLocation = (List<STVSPalletAllocation_Result>)palletAllLocationDA.Executing("STVSPalletAllocation @ReceivingOrderID={0},@ProductID={1},@HomeRoom1={2},@HomeRoom2={3},@Type={4},@StoreID={5}",
                    receivingOrderDetail.ReceivingOrderID, receivingOrderDetail.ProductID, homeRoom1, homeRoom2, "F", AppSetting.StoreID);
            if (lstLocation.Count == 0)
            {
                MessageBox.Show("No location!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int id = 0;
            List<int> lstPalletId = new List<int>();
            for (int i = 0; i < selectedRows.Count(); i++)
            {
                id = Convert.ToInt32(this.gridViewPallet.GetRowCellValue(selectedRows[i], "PalletID"));
                lstPalletId.Add(id);
            }
            frm_WM_ROSetStation frm = new frm_WM_ROSetStation();
            frm.lstPalletId = lstPalletId;
            frm.listLocation = lstLocation;
            frm.receivingOrderNumber = this.receivingOrderNumber;
            frm.ShowDialog();
            DataTable dtStation = FileProcess.LoadTable("SELECT * FROM dbo.LocationStations Where ReceivingOrderNumber = '" + this.receivingOrderNumber + "'");
            DataProcess<Pallets> palletDA = new DataProcess<Pallets>();
            foreach (DataRow dr in dtStation.Rows)
            {
                var palletID = Convert.ToInt32(dr["PalletID"].ToString());
                Pallets pallet = palletDA.Select(x => x.PalletID == palletID).FirstOrDefault();
                pallet.LocationID = Convert.ToInt32(dr["LocationID"].ToString());
                pallet.Label = dr["LocationNumber"].ToString();
                palletDA.Update(pallet);
            }

            SqlConnection conn = new SqlConnection(new SwireDBEntities().Database.Connection.ConnectionString);
            SqlCommand cmd = new SqlCommand("ST_WMS_DeleteLocationStations", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter ReceivingOrderNumber = cmd.Parameters.Add("@ReceivingOrderNumber", SqlDbType.NVarChar);
            ReceivingOrderNumber.Value = this.receivingOrderNumber;

            conn.Open();
            cmd.ExecuteNonQuery();

            LoadData();
        }
    }
}