using Common.Controls;
using DA;
using DA.Warehouse;
using DevExpress.XtraEditors;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UI.Helper;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_DispatchingProduct : frmBaseForm
    {

        // Declare log
        private static readonly ILog log = LogManager.GetLogger(typeof(frm_WM_DispatchingProduct));
        private DispatchingProducts _dp;
        private DataProcess<ST_WMS_LoadDPProductData_Result> _dpProduct;
        private BindingList<ST_WMS_LoadDPProductData_Result> listDispatchingLocation;
        //private DataProcess<ST_WMS_LoadDODetailsData_Result> _doDetailsData;
        private DispatchingOrderDetailsDA _doDetails;
        private DispatchingLocationDA _dlData;
        private BindingList<DispatchingOrderDetails> _listDODetails;
        private urc_WM_DOLocations locationControl = null;
        private urc_WM_DODetail palletControl = null;
        urc_WM_DispatchingCartons dispatchingCarton = null;
        private string customerType = string.Empty;
        private string customerNumber = string.Empty;
        private DataTable expiredDateLocationSource = null;
        private DataTable expiredDateDispatchingDetailSource = null;

        private int _locationID;
        private int _dispatchingLocationID;
        private int maxQtyPalletAvailable = 0;
        private int oldQtyPallet = 0;
        private int innerValue = 0;
        private bool isLocation = false;
        private bool isKGR = false;
        private int status;
        public delegate void SetActivegrvDispatchingOrderDetail(bool obj, EventArgs e);

        public event EventHandler SetActivegrvDispatchingOrderDetailEvent = null;
        // Create instance (null)
        // public PassControl passControl;
        protected virtual void OnEventDisable(bool active, EventArgs e)
        {
            EventHandler handler = this.SetActivegrvDispatchingOrderDetailEvent;
            if (handler != null)
            {
                handler(active, e);
            }
        }

        public frm_WM_DispatchingProduct(DispatchingProducts dp, string customerType, string customerNumber, object status)
        {
            InitializeComponent();
            this._dp = dp;
            this._dpProduct = new DataProcess<ST_WMS_LoadDPProductData_Result>();
            //this._doDetailsData = new DataProcess<ST_WMS_LoadDODetailsData_Result>();
            this._doDetails = new DispatchingOrderDetailsDA();
            this._dlData = new DispatchingLocationDA();
            this.customerType = customerType;
            this.customerNumber = customerNumber;
            this.btnCopyRemark.Enabled = false;

            EventArgs e = null;

            // Init data
            if (this.locationControl == null)
            {
                this.locationControl = new urc_WM_DOLocations(this._dp);
                this.locationControl.LocationIDChanged(this._locationID);
            }

            // Init pallet control
            if (this.palletControl == null)
            {
                this.palletControl = new urc_WM_DODetail(this._dp);
                this.palletControl.ReloadData += palletControl_ReloadData;
            }

            InitTemperature();
            SetEvents();
            setColorButtonAccept(status, e);

        }

        public void InitData(DispatchingProducts dp, string customerType, string customerNumber, object status)
        {
            this.status = Convert.ToInt16(status);
            this._dp = dp;
            this.customerType = customerType;
            this.customerNumber = customerNumber;
            // set default column edit on column location is textedit
            this.grcDispatchingLocationLabel.ColumnEdit = null;
            this.grcDODetailsRONumber.ColumnEdit = null;

            if (dp.Temperature == null)
            {
                this.cbxTemper.SelectedIndex = -1;
            }
            else
            {
                this.cbxTemper.SelectedItem = Convert.ToInt32(dp.Temperature);
            }

            // Check current product has package KGR
            var currentPro = AppSetting.ProductList.Where(p => p.ProductID == _dp.ProductID).FirstOrDefault();
            if (currentPro != null && currentPro.Packages.Equals("KGR")) this.isKGR = true;
            else this.isKGR = false;

            // Set permission control
            this.SetActiveControl(true);
            this.SetPermissionControls();
            LoadDispatchingLocationLabel();
            SetTextBoxValue();

            this._locationID = Convert.ToInt32(this.grvDPProduct.GetRowCellValue(this.grvDPProduct.FocusedRowHandle, "LocationID"));
            this._dispatchingLocationID = Convert.ToInt32(this.grvDPProduct.GetRowCellValue(this.grvDPProduct.FocusedRowHandle, "DispatchingLocationID"));

            // Get inner data of current product
            if (currentPro != null && currentPro.Inners != null)
                this.innerValue = (int)currentPro.Inners;

            // Set location Control to tab 1
            this.locationControl.Parent = this.xtraTabPage1;
            this.LoadDispatchingLocation();
            LoadDODetailsCarton();
            EventArgs e = null;
            setColorButtonAccept(status, e);
        }


        private void frm_WM_DispatchingProduct_Load(object sender, System.EventArgs e)
        {

            this.InitData(this._dp, this.customerType, this.customerNumber, this.status);

        }

        /// <summary>
        ///  Reload location data when checkbox on Pallet form changed
        /// </summary>
        /// <param name="sender">obj</param>
        /// <param name="e">EventArgs</param>
        void palletControl_ReloadData(object sender, EventArgs e)
        {
            if (sender == null) return;
            this.LoadDODetailsCarton();
        }

        private void SetEvents()
        {
            this.xtraTabControl1.Selected += xtraTabControl1_Selected;
            this.grvDPProduct.CellValueChanged += grvDPProduct_CellValueChanged;
            this.rpi_btn_DODetailDelete.Click += rpi_btn_DODetailDelete_Click;
            this.rpi_btn_DODetailsPalletBreak.Click += rpi_btn_DODetailsPalletBreak_Click;
            this.rpi_btn_DLDelete.Click += rpi_btn_DLDelete_Click;
            this.rpi_lke_LocationLabel.EditValueChanged += rpi_lke_LocationLabel_EditValueChanged;
            this.btnUpdate.ItemClick += btnUpdate_ItemClick;
        }

        #region Load Data
        private void LoadDispatchingLocation()
        {
            this.listDispatchingLocation = new BindingList<ST_WMS_LoadDPProductData_Result>(this._dpProduct.Executing("ST_WMS_LoadDPProductData @ProductID = {0}", this._dp.DispatchingProductID).ToList());
            this.listDispatchingLocation.AddNew();
            this.grdDPProduct.DataSource = listDispatchingLocation;
            this.LoadDataExpiredDateLocation(this._dp.DispatchingProductID, 1);
        }

        public void LoadDODetailsCarton()
        {
            _listDODetails = new BindingList<DispatchingOrderDetails>(this._doDetails.Select(x => x.DispatchingLocationID == this._dispatchingLocationID).ToList());
            this.grdDispatchingOrderDetail.DataSource = _listDODetails;
            this.LoadDataExpiredDateDispatchingDetails(this._dispatchingLocationID, 2);
        }

        private void LoadPalletTab()
        {
            this.xtraTabPage2.Controls.Add(this.palletControl);
        }

        private void SetTextBoxValue()
        {
            this.txtProductName.Text = this._dp.ProductName;
            this.txtProductNumber.Text = this._dp.ProductNumber;
            this.txtWeightPerPackage.Text = Decimal.Parse(this._dp.WeightPerPackage.ToString(), System.Globalization.NumberStyles.Float).ToString();
            this.txtUnitPerPackage.Text = this._dp.UnitPerPackage.ToString();
        }

        private void InitTemperature()
        {
            this.cbxTemper.Properties.Items.Add(-18);
            this.cbxTemper.Properties.Items.Add(5);
        }
        #endregion

        #region Events
        private void xtraTabControl1_Selected(object sender, DevExpress.XtraTab.TabPageEventArgs e)
        {
            this.btn_WM_BreakMakeNewDO.Enabled = false;
            this.btn_WM_BreakSameDO.Enabled = false;
            setColorButton();
            switch (e.Page.Text)
            {
                case "BREAK PALLETS":
                    SetDODetailsProperties(true);
                    LoadPalletTab();
                    this.btn_WM_BreakMakeNewDO.Enabled = true;
                    this.btn_WM_BreakSameDO.Enabled = true;
                    setColorButton();
                    break;

                case "STOCK IN STORE":
                    SetDODetailsProperties(false);
                    break;

                case "LOCATION":
                    urc_WM_DispatchingDetailProduct dispatchingProduct = new urc_WM_DispatchingDetailProduct(this._locationID);
                    dispatchingProduct.Parent = this.ProductTab;
                    break;

                case "CARTON WEIGHT":
                    //// Only process when customer type has in array limited
                    //IList<string> customerTypeList = new List<string> { CustomerTypeEnum.RANDOM_WEIGHT };
                    //if (!customerTypeList.Contains(this.customerType)) return;

                    //// Just only product has "Weight Required" then must display carton form
                    //var currentPro = AppSetting.ProductList.Where(p => p.ProductID == this._dp.ProductID).FirstOrDefault();
                    //if (currentPro == null || currentPro.IsWeightingRequire == null || !Convert.ToBoolean(currentPro.IsWeightingRequire)) return;
                    //bool isCreate = false;

                    //if (this._dp.TotalPackages > 100)
                    //{
                    //    var dl = XtraMessageBox.Show("Quantity > 100ctns. Do you want to create?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    //    if (dl.Equals(DialogResult.Yes))
                    //    {
                    //        isCreate = true;
                    //    }
                    //}
                    //else
                    //{
                    //    isCreate = true;
                    //}

                    //// Just only total weight perpackage<100 and total weight perpackage is allow by user then must process this code bellow
                    //if (!isCreate) return;
                    if (!this.isLocation)
                    {
                        // Load carton by productID
                        if (this.dispatchingCarton == null)
                        {
                            this.dispatchingCarton = new urc_WM_DispatchingCartons(this._dp, this._dp.DispatchingProductID, (float)this._dp.TotalPackages);
                            this.dispatchingCarton.RefreshDispatchingProductEvent += dispatchingCarton_RefreshDispatchingProductEvent;
                            dispatchingCarton.Dock = DockStyle.Fill;
                            dispatchingCarton.Parent = this.tabCarton;
                        }
                        else
                        {
                            this.dispatchingCarton.InitData(this._dp, this._dp.DispatchingProductID, (float)this._dp.TotalPackages);
                        }
                    }
                    else
                    {
                        // Load carton by dispatching location id
                        if (this.dispatchingCarton == null)
                        {
                            this.dispatchingCarton = new urc_WM_DispatchingCartons(this._dp, this._dispatchingLocationID, (float)this._dp.TotalPackages, true);
                            this.dispatchingCarton.RefreshDispatchingProductEvent += dispatchingCarton_RefreshDispatchingProductEvent;
                            dispatchingCarton.Dock = DockStyle.Fill;
                            dispatchingCarton.Parent = this.tabCarton;
                        }
                        else
                        {
                            this.dispatchingCarton.InitData(this._dp, this._dispatchingLocationID, (float)this._dp.TotalPackages, true);
                        }
                    }

                    //this.ShowCartonForm();
                    break;
            }
        }

        /// <summary>
        /// Refresh dispatching product when dispatching carton is completed update data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void dispatchingCarton_RefreshDispatchingProductEvent(object sender, EventArgs e)
        {
            this.LoadDODetailsCarton();
        }

        private void rpi_btn_DODetailDelete_Click(object sender, EventArgs e)
        {
            this.DeleteDetails();

        }

        private void DeleteDetails()
        {
            bool hasSendNavi = Convert.ToBoolean(this.grvDispatchingOrderDetail.GetFocusedRowCellValue("IsSendNavi"));
            if (hasSendNavi)
            {
                XtraMessageBox.Show("Pallets had sync with WareNavi, you couldn't delete it!", "TWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dlrs = MessageBox.Show("Are you sure to do delete this pallet?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlrs.Equals(DialogResult.No)) return;

            if (this.grvDispatchingOrderDetail.RowCount > 2)
            {
                int doDetailID = Convert.ToInt32(this.grvDispatchingOrderDetail.GetRowCellValue(this.grvDispatchingOrderDetail.FocusedRowHandle, "DispatchingOrderDetailID"));
                short quantity = Convert.ToInt16(this.grvDispatchingOrderDetail.GetRowCellValue(this.grvDispatchingOrderDetail.FocusedRowHandle, "QuantityOfPackages"));
                this._doDetails.STDispatchingOrderDetailsDelete(doDetailID, quantity);
                LoadDODetailsCarton();
            }
            else
            {
                XtraMessageBox.Show("Quantity can not be zero, please select correct quantity!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rpi_btn_DODetailsPalletBreak_Click(object sender, EventArgs e)
        {
            var result = XtraInputBox.Show("Please enter the required Quantity to break the pallet:", "TPWMS", "0");
            int quantity = 0;
            if (this._dp.Status >= 2) return;

            if (!int.TryParse(result, out quantity))
            {
                XtraMessageBox.Show("Wrong Number!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                short qty = Convert.ToInt16(this.grvDispatchingOrderDetail.GetRowCellValue(this.grvDispatchingOrderDetail.FocusedRowHandle, "QuantityOfPackages"));
                if (quantity < 1 || quantity >= qty)
                {
                    XtraMessageBox.Show("Wrong Number!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int hasSendNavi = Convert.ToInt32(FileProcess.LoadTable("STCheckIsSendNaviByLocation @DispatchingLocationID=" + this._dispatchingLocationID).Rows[0]["DifferenceQty"]);
                    if (hasSendNavi > 0)
                    {
                        int hasDataSyncRespond = this._listDODetails.Count(doDetail => doDetail.NaviPalletID != null);
                        if (hasDataSyncRespond < this._listDODetails.Count(doDetail => doDetail.DispatchingOrderDetailID > 0))
                        {
                            XtraMessageBox.Show("This location had sync with WareNavi, you couldn't delete it!", "TWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    int doDetailID = Convert.ToInt32(this.grvDispatchingOrderDetail.GetRowCellValue(this.grvDispatchingOrderDetail.FocusedRowHandle, "DispatchingOrderDetailID"));
                    decimal weightPerPackage = Convert.ToDecimal(this.txtWeightPerPackage.Text);
                    short inner = Convert.ToInt16(this.txtUnitPerPackage.Text);
                    this._doDetails.STDispatchingOrderDetailBreakLine(doDetailID, (short)quantity, AppSetting.CurrentUser.LoginName, weightPerPackage, inner);
                    LoadDODetailsCarton();
                    this.palletControl.ReloadDOBreaks();
                }
            }
        }

        private void rpi_btn_DLDelete_Click(object sender, EventArgs e)
        {
            var dlrs = MessageBox.Show("Are you sure to do delete this location?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlrs.Equals(DialogResult.No)) return;
            this.DeleteLocation();
        }

        private void DeleteLocation()
        {
            int hasSendNavi = Convert.ToInt32(FileProcess.LoadTable("STCheckIsSendNaviByLocation @DispatchingLocationID=" + this._dispatchingLocationID).Rows[0]["DifferenceQty"]);
            if (hasSendNavi > 0)
            {
                XtraMessageBox.Show("This location had sync with WareNavi, you couldn't delete it!", "TWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int status = 0;
            if (this._dp != null)
            {
                status = Convert.ToInt16(this._dp.Status);
                if (status > 0)
                {
                    MessageBox.Show("Can not delete accepted or confirmed products!", "TPWMS");
                    return;
                }
                else
                {
                    this._dlData.STDispatchingLocationDelete(this._dispatchingLocationID);
                    this.LoadDispatchingLocation();
                    this.LoadDODetailsCarton();
                }
            }
        }

        private void btnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadDODetailsCarton();
            LoadDispatchingLocation();
            this.palletControl.ReloadDOBreaks();
            this.locationControl.ReloadData();
        }

        private void rpi_lke_LocationLabel_EditValueChanged(object sender, EventArgs e)
        {
            // Validate location was selected
            var selectedValue = (DevExpress.XtraEditors.LookUpEdit)sender;
            //var dispatchingLocationData = (STComboLocationIDDOProductsLO_Result)this.rpi_lke_LocationLabel.GetDataSourceRowByKeyValue(selectedValue.Text);

            if (this.rpi_lke_LocationLabel.GetDataSourceRowByKeyValue(selectedValue.Text) == null) return;
            int varLocationID = Convert.ToInt32(selectedValue.GetColumnValue("LocationID"));
            string varLocation = selectedValue.GetColumnValue("Location").ToString();


            //if (dispatchingLocationData == null) return;
            if (!selectedValue.IsDisplayTextValid || string.IsNullOrEmpty(selectedValue.Text)) return;

            // Check customer type is valid and execute query by customer
            DataProcess<DispatchingLocations> dispatchingLocationDA = new DataProcess<DispatchingLocations>();
            DispatchingLocations newDispatchingLocation = new DispatchingLocations();
            newDispatchingLocation.DispatchingProductID = this._dp.DispatchingProductID;
            //newDispatchingLocation.LocationID = dispatchingLocationData.LocationID;
            //newDispatchingLocation.Label = dispatchingLocationData.Location;

            newDispatchingLocation.LocationID = varLocationID;
            newDispatchingLocation.Label = varLocation;
            dispatchingLocationDA.Insert(newDispatchingLocation);

            if (this.customerType.Equals(CustomerTypeEnum.RANDOM_WEIGHT))
            {
                dispatchingLocationDA.ExecuteNoQuery("STDispatchingLocationUpdateWeightInners " +
                    " @varDispatchingLocationID={0}," +
                    " @varDispatchingProductID={1}," +
                    " @varLocationID={2}," +
                    " @varProductID={3}", newDispatchingLocation.DispatchingLocationID, this._dp.DispatchingProductID, varLocationID, this._dp.ProductID);
            }
            else
            {
                dispatchingLocationDA.ExecuteNoQuery("STDispatchingLocationUpdate " +
                   " @varDispatchingLocationID={0}," +
                   " @varDispatchingProductID={1}," +
                   " @varLocationID={2}," +
                   " @varProductID={3}", newDispatchingLocation.DispatchingLocationID, this._dp.DispatchingProductID, varLocationID, this._dp.ProductID);
            }

            // Update dispatching location on grid
            this.grvDPProduct.SetRowCellValue(this.grvDPProduct.FocusedRowHandle, "DispatchingLocationID", newDispatchingLocation.DispatchingLocationID);
            SendKeys.Send("\t");
        }

        private void grvDPProduct_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName.Equals("Label"))
            {
                //STComboLocationIDDOProductsLO_Result locationLabelSelected = (STComboLocationIDDOProductsLO_Result)this.rpi_lke_LocationLabel.GetDataSourceRowByKeyValue(e.Value);
                //if (locationLabelSelected == null) return;
                //this.grvDPProduct.SetRowCellValue(e.RowHandle, "QuantityOfPackages", locationLabelSelected.Qty);
                //this.grvDPProduct.SetRowCellValue(e.RowHandle, "DispatchingRemark", locationLabelSelected.Ref);

                if (this.rpi_lke_LocationLabel.GetDataSourceRowByKeyValue(e.Value) == null) return;
                int varIndex = this.rpi_lke_LocationLabel.GetDataSourceRowIndex("Location", e.Value);
                int varQty = Convert.ToInt32(this.rpi_lke_LocationLabel.GetDataSourceValue("Qty", varIndex));
                string varRef = this.rpi_lke_LocationLabel.GetDataSourceValue("Ref", varIndex).ToString();
                //if (selectedValue.GetColumnValue("LocationID") == null) return;
                //int varQty = Convert.ToInt32(selectedValue.GetColumnValue("Qty"));
                //string varRef = selectedValue.GetColumnValue("Ref").ToString();
                this.grvDPProduct.SetRowCellValue(e.RowHandle, "QuantityOfPackages", varQty);
                this.grvDPProduct.SetRowCellValue(e.RowHandle, "DispatchingRemark", varRef);

                int countEmptyRow = this.listDispatchingLocation.Where(l => string.IsNullOrEmpty(l.Label)).Count();
                if (countEmptyRow <= 0)
                {
                    this.listDispatchingLocation.AddNew();
                    this.grvDPProduct.FocusedRowHandle = e.RowHandle;
                    this.grvDPProduct.FocusedColumn = this.grcDispatchingLocationRemark;
                    this.grvDPProduct.ShowEditor();
                }
            }

            if (e.Column.FieldName.Equals("DispatchingLocationRemark"))
            {
                // Get dispatching location ID is current selected
                int dispatchingLocationID = (Int32)this.grvDPProduct.GetRowCellValue(this.grvDPProduct.FocusedRowHandle, "DispatchingLocationID");
                if (dispatchingLocationID <= 0) return;
                DataProcess<DispatchingLocations> dispatchingLocationDA = new DataProcess<DispatchingLocations>();
                DispatchingLocations newDispatchingLocation = dispatchingLocationDA.Select(dpl => dpl.DispatchingLocationID == dispatchingLocationID).FirstOrDefault();
                newDispatchingLocation.DispatchingLocationRemark = Convert.ToString(this.grvDPProduct.GetRowCellValue(this.grvDPProduct.FocusedRowHandle, "DispatchingLocationRemark"));
                dispatchingLocationDA.Update(newDispatchingLocation);
            }
        }
        #endregion

        private void SetDODetailsProperties(bool isDisplayColumnButton)
        {
            this.grcDODetailsPalletBreak.Visible = isDisplayColumnButton;
            this.grcDODetailDelete.Visible = !isDisplayColumnButton;
        }

        public void btn_WM_Update_Click(object sender, EventArgs e)
        {
            LoadDODetailsCarton();
            LoadDispatchingLocation();
            this.palletControl.ReloadDOBreaks();
            this.locationControl.ReloadData();
            this.SetActiveControl(true);
            this.OnEventDisable(true, e);
            this.grdDPProduct.Enabled = true;
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btn_WM_Close_Click(object sender, EventArgs e)
        {
            this.grdDPProduct.Enabled = true;
            this.grdDispatchingOrderDetail.Enabled = true;
            OnEventDisable(true, e);
            this.Close();
        }

        /// <summary>
        /// Load all location free on current dispatching order selected
        /// </summary>
        private void LoadDispatchingLocationLabel()
        {
            DataProcess<STComboLocationIDDOProductsLO_Result> dispatchingLocationLableDA = new DataProcess<STComboLocationIDDOProductsLO_Result>();
            var dataSource = dispatchingLocationLableDA.Executing("STComboLocationIDDOProductsLO @ProductID={0}", this._dp.ProductID);

            DataProcess<object> dataProcess = new DataProcess<object>();
            var dataSource2 = dataProcess.Executing("STComboLocationIDDOProductsLO_ShelfLife @ProductID={0}", this._dp.ProductID);

            this.rpi_lke_LocationLabel.DataSource = FileProcess.LoadTable("STComboLocationIDDOProductsLO_ShelfLife @ProductID= " + this._dp.ProductID);

            //this.rpi_lke_LocationLabel.DataSource = dataSource
            this.rpi_lke_LocationLabel.ValueMember = "Location";
            this.rpi_lke_LocationLabel.DisplayMember = "Location";
        }

        private void rpi_chk_DODetailsBreak_CheckedChanged(object sender, EventArgs e)
        {
            int currentDODetailID = Convert.ToInt32(this.grvDispatchingOrderDetail.GetRowCellValue(this.grvDispatchingOrderDetail.FocusedRowHandle, "DispatchingOrderDetailID"));
            DispatchingOrderDetails doDetails = this._listDODetails.Where(d => d.DispatchingOrderDetailID == currentDODetailID).FirstOrDefault();
            doDetails.CheckBreak = ((DevExpress.XtraEditors.CheckEdit)sender).Checked;
            this._doDetails.Update(doDetails);
            this.palletControl.ReloadDOBreaks();
            this.xtraTabPage2.Update();
            this.xtraTabPage2.Refresh();
        }

        /// <summary>
        /// Get max quantity value of current pallet
        /// </summary>
        /// <param name="palletID">int</param>
        private void GetMaxQtyCurrentPallet(int palletID)
        {
            DataProcess<Pallets> palletsDA = new DataProcess<Pallets>();
            var currentPallet = palletsDA.Select(pl => pl.PalletID == palletID).FirstOrDefault();
            this.maxQtyPalletAvailable = currentPallet.AfterDPQuantity + this.oldQtyPallet;
        }

        private void grvDispatchingOrderDetail_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.grvDispatchingOrderDetail.OptionsNavigation.EnterMoveNextColumn = true;

            DataProcess<DispatchingOrderDetails> dispatchingProductDA = new DataProcess<DispatchingOrderDetails>();
            int dispatchingOrderDetail = Convert.ToInt32(this.grvDispatchingOrderDetail.GetRowCellValue(e.RowHandle, "DispatchingOrderDetailID"));

            // Get dispatching Order Details by current DispatchingOrderDetailID selected
            var dispatchingOrderDetailSelected = dispatchingProductDA.Select(d => d.DispatchingOrderDetailID == dispatchingOrderDetail).FirstOrDefault();
            if (dispatchingOrderDetailSelected == null) return;

            // Definition current process with correctsponding column
            switch (e.Column.FieldName)
            {
                case "QuantityOfPackages":
                    if (Convert.ToBoolean(dispatchingOrderDetailSelected.IsSendNavi)) return;
                    // Get current quantity was changed
                    int newQuantity = Convert.ToInt32(this.grvDispatchingOrderDetail.GetRowCellValue(e.RowHandle, "QuantityOfPackages"));
                    int dispatchingOrderDetailID = Convert.ToInt32(this.grvDispatchingOrderDetail.GetRowCellValue(e.RowHandle, "DispatchingOrderDetailID"));

                    if (dispatchingOrderDetailID > 0)
                    {
                        int palletIDSelected = Convert.ToInt32(this.grvDispatchingOrderDetail.GetRowCellValue(e.RowHandle, "PalletID"));
                        // Get current quantity of pallet selected
                        this.oldQtyPallet = dispatchingOrderDetailSelected.QuantityOfPackages;
                        this.GetMaxQtyCurrentPallet(palletIDSelected);

                        // Check customer type
                        if (this.customerType.Equals(CustomerTypeEnum.RANDOM_WEIGHT))
                        {
                            if (newQuantity > this.maxQtyPalletAvailable || newQuantity < 0)
                            {
                                MessageBox.Show("Wrong entry !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                this.grvDispatchingOrderDetail.OptionsNavigation.EnterMoveNextColumn = false;
                                return;
                            }
                        }
                        else
                        {
                            if (newQuantity > this.maxQtyPalletAvailable || newQuantity <= 0)
                            {
                                MessageBox.Show("Wrong entry !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                this.grvDispatchingOrderDetail.OptionsNavigation.EnterMoveNextColumn = false;
                                return;
                            }
                        }

                        // New quantity is valid, update data
                        int quantityUpdate = newQuantity - this.oldQtyPallet;

                        dispatchingOrderDetailSelected.QuantityOfPackages = (short)newQuantity;

                        if (this.customerType.Equals(CustomerTypeEnum.RANDOM_WEIGHT) && this.isKGR)
                        {
                            //// Code cho nay chua co implement, can kiem tra lai logic cho truong hop nay @Hung 
                            //// Hien tai doan code nay la dua tam vao theo logic cu 
                            //dispatchingOrderDetailSelected.UnitQuantity = newQuantity * this.innerValue;
                            //dispatchingOrderDetailSelected.PalletWeight = (float)(newQuantity * Convert.ToDecimal(txtWeightPerPackage.Text));
                            //  urc_WM_DispatchingCartons ct = new urc_WM_DispatchingCartons();
                            // dispatchingOrderDetailSelected.PalletWeight = 1;

                        }
                        else
                        {
                            dispatchingOrderDetailSelected.UnitQuantity = newQuantity * this.innerValue;
                            dispatchingOrderDetailSelected.PalletWeight = (float)(newQuantity * Convert.ToDecimal(txtWeightPerPackage.Text));
                        }
                        dispatchingProductDA.Update(dispatchingOrderDetailSelected);

                        dispatchingProductDA.ExecuteNoQuery("STDispatchingOrderDetailUpdateQty @varDispatchingOrderDetailID={0},@varDispatchingQuantity={1}",
                            dispatchingOrderDetail, quantityUpdate);




                        // Reload details dispatching location
                        this.LoadDODetailsCarton();
                        this.btn_WM_Update.Focus();
                    }

                    break;

                case "DispatchingOrderDetailRemark":
                    string remark = Convert.ToString(this.grvDispatchingOrderDetail.GetRowCellValue(e.RowHandle, "DispatchingOrderDetailRemark"));
                    dispatchingOrderDetailSelected.DispatchingOrderDetailRemark = remark;
                    dispatchingProductDA.Update(dispatchingOrderDetailSelected);
                    break;

                case "UnitQuantity":
                    if (Convert.ToBoolean(dispatchingOrderDetailSelected.IsSendNavi)) return;
                    int unit = Convert.ToInt32(this.grvDispatchingOrderDetail.GetRowCellValue(e.RowHandle, "UnitQuantity"));
                    dispatchingOrderDetailSelected.UnitQuantity = unit;
                    dispatchingProductDA.Update(dispatchingOrderDetailSelected);
                    break;

                case "PalletWeight":
                    if (Convert.ToBoolean(dispatchingOrderDetailSelected.IsSendNavi)) return;
                    float weight = float.Parse(this.grvDispatchingOrderDetail.GetRowCellValue(e.RowHandle, "PalletWeight").ToString());
                    dispatchingOrderDetailSelected.PalletWeight = weight;
                    dispatchingProductDA.Update(dispatchingOrderDetailSelected);

                    break;
            }
        }

        private void LoadAllPalletAddNew(int location, int productID)
        {
            DataProcess<ST_WMS_DispatchingOrderDetailCboPallet_Result> dispatchingOrderDetailPallet = new DataProcess<ST_WMS_DispatchingOrderDetailCboPallet_Result>();
            this.rpi_lke_DispatchingOrderPallets.DataSource = dispatchingOrderDetailPallet.Executing("ST_WMS_DispatchingOrderDetailCboPallet @LocationID={0},@ProductID={1}", location, productID);
            this.rpi_lke_DispatchingOrderPallets.ValueMember = "ReceivingOrder";
            this.rpi_lke_DispatchingOrderPallets.DisplayMember = "ReceivingOrder";
        }

        private void rpi_lke_DispatchingOrderPallets_EditValueChanged(object sender, EventArgs e)
        {
            var selectedValue = (DevExpress.XtraEditors.LookUpEdit)sender;
            int rowHandle = this.grvDispatchingOrderDetail.FocusedRowHandle;
            var dispatchingPallet = (ST_WMS_DispatchingOrderDetailCboPallet_Result)this.rpi_lke_DispatchingOrderPallets.GetDataSourceRowByKeyValue(selectedValue.Text);
            if (dispatchingPallet == null) return;

            // Calculating total unit and pallet weight
            decimal totalUnit = dispatchingPallet.CurrentQuantity * this.innerValue;
            decimal palletWeight = dispatchingPallet.CurrentQuantity * Convert.ToDecimal(this.txtWeightPerPackage.Text);
            this.grvDispatchingOrderDetail.SetRowCellValue(rowHandle, "QuantityOfPackages", dispatchingPallet.CurrentQuantity);
            this.grvDispatchingOrderDetail.SetRowCellValue(rowHandle, "PalletID", dispatchingPallet.PalletID);
            this.grvDispatchingOrderDetail.SetRowCellValue(rowHandle, "UnitQuantity", totalUnit);
            this.grvDispatchingOrderDetail.SetRowCellValue(rowHandle, "PalletWeight", palletWeight);

            // Declare Dispatching Order Details DA
            DataProcess<DispatchingOrderDetails> dispatchingOrderDetailDA = new DataProcess<DispatchingOrderDetails>();
            var newDispatchingOrderDetail = new DispatchingOrderDetails();
            newDispatchingOrderDetail.QuantityOfPackages = dispatchingPallet.CurrentQuantity;
            newDispatchingOrderDetail.PalletID = dispatchingPallet.PalletID;
            newDispatchingOrderDetail.PalletWeight = (float)palletWeight;
            newDispatchingOrderDetail.ReceivingOrderNumber = dispatchingPallet.ReceivingOrder;
            newDispatchingOrderDetail.UnitQuantity = (int)totalUnit;
            newDispatchingOrderDetail.DispatchingLocationID = this._dispatchingLocationID;
            dispatchingOrderDetailDA.Insert(newDispatchingOrderDetail);


            DataProcess<object> dispatchingOrderDetailsPalletDA = new DataProcess<object>();
            dispatchingOrderDetailsPalletDA.Executing("STDispatchingOrderDetailInsert " +
                " @varDispatchingOrderDetailID={0}, " +
                "@varPalletID={1}, " +
                "@varReceivingOrderNumber={2}, " +
                "@varDispatchingQuantity={3}, " +
                "@varDispatchingLocationID={4} ", null, dispatchingPallet.PalletID, dispatchingPallet.ReceivingOrder, dispatchingPallet.CurrentQuantity, this._dispatchingLocationID);

            // Reload data
            this.LoadDODetailsCarton();

        }



        private void grvDispatchingOrderDetail_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            this.isLocation = false;
            bool hasSendData = Convert.ToBoolean(this.grvDispatchingOrderDetail.GetFocusedRowCellValue("IsSendNavi"));
            if (hasSendData) return;

            //this.ShowCartonForm();
            if (!this.isLocation)
            {
                int doDetailID = Convert.ToInt32(this.grvDispatchingOrderDetail.GetFocusedRowCellValue("DispatchingOrderDetailID"));
                // Load carton by productID
                if (this.dispatchingCarton == null)
                {
                    this.dispatchingCarton = new urc_WM_DispatchingCartons(this._dp, this._dp.DispatchingProductID, (float)this._dp.TotalPackages, false, doDetailID, Convert.ToInt32(grvDispatchingOrderDetail.GetFocusedRowCellValue("QuantityOfPackages")));
                    this.dispatchingCarton.RefreshDispatchingProductEvent += dispatchingCarton_RefreshDispatchingProductEvent;
                    dispatchingCarton.Dock = DockStyle.Fill;
                    this.SetActivegrvDispatchingOrderDetailEvent += dispatchingCarton.setEvent;
                    dispatchingCarton.Parent = this.tabCarton;
                    if (this.status == 2)
                    {
                        OnEventDisable(false, e);
                    }
                }
                else
                {
                    this.dispatchingCarton.InitData(this._dp, this._dp.DispatchingProductID, (float)this._dp.TotalPackages, false, doDetailID, Convert.ToInt32(grvDispatchingOrderDetail.GetFocusedRowCellValue("QuantityOfPackages")));
                    this.SetActivegrvDispatchingOrderDetailEvent += dispatchingCarton.setEvent;
                    if (this.status == 2)
                    {
                        OnEventDisable(false, e);
                    }
                }
            }
            else
            {
                // Load carton by dispatching location id
                if (this.dispatchingCarton == null)
                {
                    this.dispatchingCarton = new urc_WM_DispatchingCartons(this._dp, this._dispatchingLocationID, (float)this._dp.TotalPackages, true);
                    this.dispatchingCarton.RefreshDispatchingProductEvent += dispatchingCarton_RefreshDispatchingProductEvent;
                    this.SetActivegrvDispatchingOrderDetailEvent += dispatchingCarton.setEvent;
                    dispatchingCarton.Dock = DockStyle.Fill;
                    dispatchingCarton.Parent = this.tabCarton;
                }
                else
                {
                    this.dispatchingCarton.InitData(this._dp, this._dispatchingLocationID, (float)this._dp.TotalPackages, true);
                }
            }


            switch (this.grvDispatchingOrderDetail.FocusedColumn.FieldName)
            {
                // Show pallet list to add new
                case "ReceivingOrderNumber":
                    string receivingOrderNumberSelected = Convert.ToString(this.grvDispatchingOrderDetail.GetRowCellValue(e.RowHandle, "ReceivingOrderNumber"));

                    // Check is new row
                    if (string.IsNullOrEmpty(receivingOrderNumberSelected))
                    {
                        int locationID = Convert.ToInt32(this.grvDPProduct.GetRowCellValue(this.grvDPProduct.FocusedRowHandle, "LocationID"));
                        int productID = this._dp.ProductID;
                        this.LoadAllPalletAddNew(locationID, productID);
                        this.grcDODetailsRONumber.OptionsColumn.ReadOnly = false;
                        this.grcDODetailsRONumber.ColumnEdit = this.rpi_lke_DispatchingOrderPallets;
                        DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
                        view.ShowEditor();
                        if (view.ActiveEditor is LookUpEdit)
                        {
                            ((LookUpEdit)view.ActiveEditor).ShowPopup();
                            //throw new DevExpress.Utils.HideException();
                        }

                    }
                    else
                    {
                        this.grcDODetailsRONumber.ColumnEdit = null;
                        this.grcDODetailsRONumber.OptionsColumn.ReadOnly = true;
                    }
                    break;
            }

            // Delete this detail
            if (e.Column.Name.Equals("grcDODetailDelete"))
            {
                this.DeleteDetails();
            }

            // Disable other button when does not yet Update button click
            if (this.btn_WM_Remark.Enabled)
            {
                this.SetActiveControl(false);
            }
        }

        private void grvDPProduct_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.RowHandle < 0) return;
            this._locationID = Convert.ToInt32(this.grvDPProduct.GetRowCellValue(e.RowHandle, this.grvDPProduct.Columns["LocationID"]));
            this._dispatchingLocationID = Convert.ToInt32(this.grvDPProduct.GetRowCellValue(e.RowHandle, "DispatchingLocationID"));
            string lableSelected = Convert.ToString(this.grvDPProduct.GetRowCellValue(e.RowHandle, this.grvDPProduct.Columns["Label"]));
            this.isLocation = true;
            //this.ShowCartonForm();

            if (!this.isLocation)
            {
                // Load carton by productID
                if (this.dispatchingCarton == null)
                {
                    this.dispatchingCarton = new urc_WM_DispatchingCartons(this._dp, this._dp.DispatchingProductID, (float)this._dp.TotalPackages);
                    this.dispatchingCarton.RefreshDispatchingProductEvent += dispatchingCarton_RefreshDispatchingProductEvent;
                    this.dispatchingCarton.SetActiveParentControlsEvent += DispatchingCarton_SetActiveParentControlsEvent;

                    dispatchingCarton.Dock = DockStyle.Fill;
                    dispatchingCarton.Parent = this.tabCarton;

                }
                else
                {
                    this.dispatchingCarton.InitData(this._dp, this._dp.DispatchingProductID, (float)this._dp.TotalPackages);



                }
            }
            else
            {
                // Load carton by dispatching location id
                if (this.dispatchingCarton == null)
                {
                    this.dispatchingCarton = new urc_WM_DispatchingCartons(this._dp, this._dispatchingLocationID, (float)this._dp.TotalPackages, true, this._dispatchingLocationID);
                    this.dispatchingCarton.RefreshDispatchingProductEvent += dispatchingCarton_RefreshDispatchingProductEvent;
                    this.dispatchingCarton.SetActiveParentControlsEvent += DispatchingCarton_SetActiveParentControlsEvent;
                    this.SetActivegrvDispatchingOrderDetailEvent += dispatchingCarton.setEvent;
                    dispatchingCarton.Dock = DockStyle.Fill;

                    dispatchingCarton.Parent = this.tabCarton;
                    if (this.status == 2)
                    {
                        OnEventDisable(false, e);
                    }


                }
                else
                {
                    this.dispatchingCarton.InitData(this._dp, this._dispatchingLocationID, (float)this._dp.TotalPackages, true, this._dispatchingLocationID);
                    this.SetActivegrvDispatchingOrderDetailEvent += dispatchingCarton.setEvent;
                    if (this.status == 2)
                    {
                        OnEventDisable(false, e);
                    }

                }
            }

            // Check is new row
            if (string.IsNullOrEmpty(lableSelected))
            {
                this.LoadDispatchingLocationLabel();
                this.grcDispatchingLocationLabel.OptionsColumn.ReadOnly = false;
                this.grcDispatchingLocationLabel.ColumnEdit = this.rpi_lke_LocationLabel;
                this.rpi_lke_LocationLabel.AllowFocused = true;
                this.rpi_lke_LocationLabel.ImmediatePopup = true;
                DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
                view.ShowEditor();
                if (view.ActiveEditor is LookUpEdit)
                {
                    ((LookUpEdit)view.ActiveEditor).ShowPopup();
                    //throw new DevExpress.Utils.HideException();
                }
            }
            else
            {
                this.grcDispatchingLocationLabel.ColumnEdit = null;
                this.grcDispatchingLocationLabel.OptionsColumn.ReadOnly = true;
                this.locationControl.LocationIDChanged(this._locationID);
                LoadDODetailsCarton();
            }

            // Delete location is selected
            if (e.Column.Name.Equals("grcDispatchingLocationDelete"))
            {
                this.DeleteLocation();
            }

            if (this.grvDPProduct.FocusedRowHandle >= 0)
            {
                this.btnCopyRemark.Enabled = true;
            }
            else
            {
                this.btnCopyRemark.Enabled = false;
            }
        }

        private void DispatchingCarton_SetActiveParentControlsEvent(object sender, EventArgs e)
        {
            bool isActive = Convert.ToBoolean(sender);
            this.SetActiveParentControls(isActive);
        }

        /// <summary>
        /// Set active control when Update button click
        /// </summary>
        /// <param name="isActive">bool</param>
        private void SetActiveControl(bool isActive)
        {
            this.btn_WM_Update.Enabled = !isActive;
            this.btn_WM_Combine.Enabled = isActive;
            this.btn_WM_Break.Enabled = isActive;
            this.btn_WM_Remark.Enabled = isActive;
            this.btn_WM_Reference.Enabled = isActive;
            this.btn_WM_Close.Enabled = isActive;
            this.btn_WM_Accept.Enabled = isActive;
            this.btn_WM_Accept.Focus();
            //  this.grdDPProduct.Enabled = isActive;
            // this.grdDispatchingOrderDetail.Enabled = isActive;
            setColorButton();
        }

        /// <summary>
        /// Set permission control when dispatching product accept
        /// </summary>
        /// <param name="isActive">bool</param>
        private void SetPermissionControls()
        {
            int status = 0;
            if (this._dp != null)
            {
                status = Convert.ToInt16(this._dp.Status);
            }

            bool isActive = status >= 1 ? false : true;
            this.btn_WM_Update.Enabled = isActive;
            this.btn_WM_Combine.Enabled = isActive;
            this.btn_WM_Break.Enabled = isActive;
            this.btn_WM_Remark.Enabled = isActive;
            this.btn_WM_Reference.Enabled = isActive;
            this.btn_WM_Accept.Focus();
            setColorButton();
            if (status > 0)
            {
                this.grvDPProduct.OptionsBehavior.ReadOnly = true;
                this.grvDispatchingOrderDetail.OptionsBehavior.ReadOnly = true;
            }
            else
            {
                this.grvDPProduct.OptionsBehavior.ReadOnly = false;
                this.grvDispatchingOrderDetail.OptionsBehavior.ReadOnly = false;
            }

            if (!isActive)
            {
                //this.btn_WM_Accept.LookAndFeel.UseDefaultLookAndFeel = false;
                //this.btn_WM_Accept.LookAndFeel.SkinName = "Office 2010 Black";
                //this.btn_WM_Accept.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;

                //this.btn_WM_Accept.Appearance.BackColor = Color.Gray;
            }
            else
            {
                // this.btn_WM_Accept.LookAndFeel.UseDefaultLookAndFeel = true;
                //  this.btn_WM_Accept.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning;
            }

            // Has confirm
            if (status.Equals(2))
            {
                this.btn_WM_Accept.Enabled = false;
            }

            if ((this.customerType.Equals(CustomerTypeEnum.RANDOM_WEIGHT)) && this.isKGR)
            {
                this.colUnit.OptionsColumn.ReadOnly = false;
                this.colWeight.OptionsColumn.ReadOnly = false;
            }
            else
            {
                this.colUnit.OptionsColumn.ReadOnly = true;
                this.colWeight.OptionsColumn.ReadOnly = true;
            }
        }

        /// <summary>
        /// Update Dispatching Remark
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_WM_Remark_Click(object sender, EventArgs e)
        {
            DataProcess<object> dispatchingUpdateRemarkDA = new DataProcess<object>();
            dispatchingUpdateRemarkDA.ExecuteNoQuery("STDispatchingProductUpdateRemark @DispatchingProductID={0},@Flag={1}", this._dp.DispatchingProductID, 1);
            this.LoadDispatchingLocation();
        }

        /// <summary>
        /// Update Dispatching Reference
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_WM_Reference_Click(object sender, EventArgs e)
        {
            DataProcess<object> dispatchingUpdateRemarkDA = new DataProcess<object>();
            dispatchingUpdateRemarkDA.ExecuteNoQuery("STDispatchingProductUpdateRemark @DispatchingProductID={0},@Flag={1}", this._dp.DispatchingProductID, 0);
            this.LoadDispatchingLocation();
        }

        /// <summary>
        /// Accept to export dispatching order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_WM_Accept_Click(object sender, EventArgs e)
        {
            DataProcess<object> dispatchingOrderCartonDA = new DataProcess<object>();

            if (this.customerType.Equals(CustomerTypeEnum.RANDOM_WEIGHT))
            {
                dispatchingOrderCartonDA.ExecuteNoQuery("STDispatchingCartonWeightUpdate @DispatchingProductID={0}", this._dp.DispatchingProductID);
            }

            // Dispatching product state is empty
            if (Convert.ToInt16(this._dp.Status).Equals(0))
            {
                dispatchingOrderCartonDA.ExecuteNoQuery("STTransactionInsert @varOrderDetailID={0},@varOrderNumber={1},@varUserID={2},@varCustomerNumber={3}",
                    this._dp.DispatchingProductID, this._dp.DispatchingOrderNumber, AppSetting.CurrentUser.LoginName, this.customerNumber);
                this.Close();
            }
            else
            {
                // Dispatching product state is accept
                dispatchingOrderCartonDA.ExecuteNoQuery("STTransactionDelete @varOrderDetailID={0},@varTransactionID={1},@varTransactionType={2},@UserID={3}",
                    this._dp.DispatchingProductID, this._dp.TransactionID, false, AppSetting.CurrentUser.LoginName);
                this._dp.Status = 0;
                this.btn_WM_Accept.LookAndFeel.UseDefaultLookAndFeel = true;
                SetPermissionControls();
            }
        }

        private void btn_WM_Break_Click(object sender, EventArgs e)
        {
            if (this._dp.Status > 1) return;
            int hasSendNavi = Convert.ToInt32(FileProcess.LoadTable("STCheckIsSendNaviByDispatchingProductID @DispatchingProductID=" + this._dp.DispatchingProductID).Rows[0]["DifferenceQty"]);
            if (hasSendNavi > 0)
            {
                int hasDataSyncRespond = this._listDODetails.Count(doDetail => doDetail.NaviPalletID != null);
                if (hasDataSyncRespond < this._listDODetails.Count(doDetail => doDetail.DispatchingOrderDetailID > 0))
                {
                    XtraMessageBox.Show("Pallets had sync with WareNavi, you couldn't modify it!", "TWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            var dl = MessageBox.Show("You want to break this dispatching product down to many separated lines for each RO click Yes, to split details checked to new line click No?", "TPWMS", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            if (dl.Equals(DialogResult.Cancel)) return;

            if (dl.Equals(DialogResult.Yes))
            {
                DataProcess<object> breakDispatchingPalletDA = new DataProcess<object>();
                breakDispatchingPalletDA.ExecuteNoQuery("STDispatchingProductBreakdown @DispatchingProductID={0}", this._dp.DispatchingProductID);
                this.Close();

            }
            if (dl.Equals(DialogResult.No))
            {
                int v_DetailID = 0;
                foreach (var index in this.grvDPProduct.GetSelectedRows())
                {
                    try
                    {
                        v_DetailID = Convert.ToInt32(this.grvDPProduct.GetRowCellDisplayText(index, "DispatchingLocationID"));
                    }
                    catch (Exception ex)
                    {
                        log.Error("==> Error is unexpected");
                        log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                    }
                    DataProcess<object> dataProcess = new DataProcess<object>();

                    int result = dataProcess.ExecuteNoQuery("Update DispatchingLocations set IsMoving={0}  where DispatchingLocationID={1}", 1, v_DetailID);

                }
                int OrderID = Convert.ToInt32(this._dp.DispatchingProductID);
                if (OrderID <= 0) return;
                DataProcess<object> dataProcess1 = new DataProcess<object>();
                int resultProcess = dataProcess1.ExecuteNoQuery("ST_WMS_SplitDispatchingLocations " + OrderID + ", '" + AppSetting.CurrentUser.LoginName + "'");
                if (resultProcess < 0)
                {
                    MessageBox.Show("Process Split Fail", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Split Ok", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDODetailsCarton();
                LoadDispatchingLocation();
                this.palletControl.ReloadDOBreaks();
                this.locationControl.ReloadData();
            }
        }

        private void btnExpand_Click(object sender, EventArgs e)
        {
            this.SuspendLayout();
            if (this.btnExpand.Text.Equals("Expand"))
            {
                this.layoutControlItem8.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                this.btnExpand.Text = "Collapse";
                this.Location = new Point(10, 45);
                this.Height = 962;

            }
            else
            {
                this.layoutControlItem8.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                this.btnExpand.Text = "Expand";
                this.Location = new Point(10, 227);
                this.Height = 692;
            }

            this.ResumeLayout();
        }

        private void btn_WM_Combine_Click(object sender, EventArgs e)
        {
            if (this._dp.Status > 1) return;
            DialogResult dl = MessageBox.Show("Are you sure to combine the products " + this.txtProductName.Text + " from this DO ?", "WMS-2022", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dl.Equals(DialogResult.Yes))
            {
                DataProcess<object> dispatchingProductCombine = new DataProcess<object>();
                dispatchingProductCombine.ExecuteNoQuery("STDispatchingProductCombine @DispatchingProductID={0}", this._dp.DispatchingProductID);
                this.Close();
            }
        }

        private void btn_WM_BreakSameDO_Click(object sender, EventArgs e)
        {
            if (this._dp.Status > 1) return;
            DialogResult dl = MessageBox.Show("Are you sure to break this product to new line ?", "WMS-2022", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dl.Equals(DialogResult.Yes))
            {
                DataProcess<object> dispatchingOrderDetailBreakDA = new DataProcess<object>();
                dispatchingOrderDetailBreakDA.ExecuteNoQuery("STDispatchingOrderDetailBreak @DispatchingOrderID={0},@CurrentUser={1}", this._dp.DispatchingOrderID, AppSetting.CurrentUser.LoginName);
                this.Close();
            }
        }

        private void btn_WM_BreakMakeNewDO_Click(object sender, EventArgs e)
        {
            if (this._dp.Status > 1) return;
            DialogResult dl = MessageBox.Show("Are you sure to break this Pallet and make new DO ?", "WMS-2022", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dl.Equals(DialogResult.Yes))
            {
                using (var context = new SwireDBEntities())
                {
                    var dipatchingOrderIdOutput = new System.Data.Entity.Core.Objects.ObjectParameter("returnDispatchingOrderID", -1);
                    context.STDispatchingOrderDetailBreakMakeDO(this._dp.DispatchingOrderID, AppSetting.CurrentUser.LoginName, dipatchingOrderIdOutput);
                    frm_WM_DispatchingOrders.GetInstance((int)dipatchingOrderIdOutput.Value);
                    this.Close();
                }
            }
        }

        private void grvDispatchingOrderDetail_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            switch (this.grvDispatchingOrderDetail.FocusedColumn.FieldName)
            {
                case "QuantityOfPackages":
                case "UnitQuantity":
                case "PalletWeight":

                    int qty = Convert.ToInt32(this.grvDispatchingOrderDetail.GetFocusedRowCellValue("QuantityOfPackages"));
                    int unt = Convert.ToInt32(this.grvDispatchingOrderDetail.GetFocusedRowCellValue("UnitQuantity"));
                    decimal weight = Convert.ToDecimal(this.grvDispatchingOrderDetail.GetFocusedRowCellValue("PalletWeight"));
                    switch (this.grvDispatchingOrderDetail.FocusedColumn.FieldName)
                    {
                        case "QuantityOfPackages":
                            qty = Convert.ToInt32(e.Value);
                            break;
                        case "UnitQuantity":
                            unt = Convert.ToInt32(e.Value);
                            break;
                        case "PalletWeight":
                            weight = Convert.ToDecimal(e.Value);
                            int palletID = Convert.ToInt32(this.grvDispatchingOrderDetail.GetFocusedRowCellValue("PalletID"));
                            int doDetailID = Convert.ToInt32(this.grvDispatchingOrderDetail.GetFocusedRowCellValue("DispatchingOrderDetailID"));
                            DataProcess<Pallets> dataProcessPA = new DataProcess<Pallets>();
                            var currentPalelt = dataProcessPA.Select(p => p.PalletID == palletID).FirstOrDefault();
                            if (currentPalelt == null) return;
                            DataProcess<ViewTotalDispatchingOrderDetails> allDoDetail = new DataProcess<ViewTotalDispatchingOrderDetails>();
                            decimal sumPalletWeightDO = Convert.ToDecimal(allDoDetail.Select(v => v.PalletID == palletID && v.DispatchingOrderDetailID != doDetailID).Sum(p => p.PalletWeight));
                            var palletWeightStock = (decimal)currentPalelt.PalletWeight - sumPalletWeightDO;
                            if (palletWeightStock < weight)
                            {
                                e.Valid = false;
                                e.ErrorText = "Pallet Weight input is invalid, current pallet weight on stock is [" + palletWeightStock + "]";
                                return;
                            }
                            break;
                    }
                    if (qty <= 0 && unt <= 0 && weight <= 0)
                    {
                        e.Valid = false;
                        e.ErrorText = "Quantity input is invalid";
                        return;
                    }

                    // Get current quantity was changed
                    // Only process when customer type has in array limited
                    IList<string> customerTypeList = new List<string> { CustomerTypeEnum.RANDOM_WEIGHT };
                    if (customerTypeList.Contains(this.customerType)) return;

                    int newQuantity = Convert.ToInt32(e.Value);
                    if (newQuantity < 1)
                    {
                        e.Valid = false;
                        e.ErrorText = "Quantity input is invalid";
                    }
                    break;
            }
        }

        private void frm_WM_DispatchingProduct_Shown(object sender, EventArgs e)
        {
            this.btn_WM_Accept.Focus();
        }

        private void btnCopyRemark_Click(object sender, EventArgs e)
        {
            if (this.grvDPProduct.FocusedRowHandle < 0)
            {
                MessageBox.Show("Please select row has remark to need copy !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string remark = Convert.ToString(this.grvDPProduct.GetFocusedRowCellValue("DispatchingLocationRemark"));
            DataProcess<DispatchingProducts> dispatchingProductDA = new DataProcess<DispatchingProducts>();
            int result = dispatchingProductDA.ExecuteNoQuery(" Update DispatchingProducts Set Remark=N'" + remark + "' Where DispatchingProductID=" + this._dp.DispatchingProductID);
            this.btnCopyRemark.Enabled = false;
        }

        private void cbxTemper_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.cbxTemper.IsModified == false) return;
            if (this._dp.Status > 0) return;
            this._dp.Temperature = (int)this.cbxTemper.SelectedItem;
            DataProcess<DispatchingProducts> dispatchingProductDA = new DataProcess<DispatchingProducts>();
            int result = dispatchingProductDA.ExecuteNoQuery(" Update DispatchingProducts Set Temperature=" + this.cbxTemper.SelectedItem + " Where DispatchingProductID=" + this._dp.DispatchingProductID);
        }

        private void grdDPProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.KeyCode.Equals(Keys.Delete)) return;
            var dlrs = MessageBox.Show("Are you sure to do delete this location?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlrs.Equals(DialogResult.No)) return;
            int status = 0;
            if (this._dp != null)
            {
                status = Convert.ToInt16(this._dp.Status);
                if (status > 0)
                {
                    MessageBox.Show("Can not delete accepted or confirmed products!", "TPWMS");
                    return;
                }
                else
                {
                    foreach (var index in this.grvDPProduct.GetSelectedRows())
                    {
                        int dispatchingLocationID = Convert.ToInt32(this.grvDPProduct.GetRowCellValue(index, "DispatchingLocationID"));
                        this._dlData.STDispatchingLocationDelete(dispatchingLocationID);
                    }
                    LoadDispatchingLocation();
                }
            }
        }

        private void grvDPProduct_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle < 0) return;
            if (this.expiredDateLocationSource == null || this.expiredDateLocationSource.Rows.Count <= 0) return;
            int orderID = Convert.ToInt32(this.grvDPProduct.GetRowCellValue(e.RowHandle, "DispatchingLocationID"));
            int countExp = this.expiredDateLocationSource.Select("OrderID = " + orderID).Count();
            if (countExp <= 0) return;
            e.Appearance.BackColor = Color.Red;
        }

        /// <summary>
        /// Load list product has been expires date
        /// Flat =0 DispatchingOrderID
        /// Flat =1 DispatchingProductID
        /// Flat =2 DispatchingLocationID
        /// </summary>
        /// <param name="orderID">int</param>
        /// <param name="flag">int</param>
        private void LoadDataExpiredDateLocation(int orderID, int flag)
        {
            this.expiredDateLocationSource = FileProcess.LoadTable("STCheckUseByDateProduct @OrderID=" + orderID + ",@Flat=" + flag);
        }

        /// <summary>
        /// Load list product has been expires date
        /// Flat =0 DispatchingOrderID
        /// Flat =1 DispatchingProductID
        /// Flat =2 DispatchingLocationID
        /// </summary>
        /// <param name="orderID">int</param>
        /// <param name="flag">int</param>
        private void LoadDataExpiredDateDispatchingDetails(int orderID, int flag)
        {
            this.expiredDateDispatchingDetailSource = FileProcess.LoadTable("STCheckUseByDateProduct @OrderID=" + orderID + ",@Flat=" + flag);
        }

        private void grvDispatchingOrderDetail_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle < 0) return;
            if (this.expiredDateDispatchingDetailSource == null || this.expiredDateDispatchingDetailSource.Rows.Count <= 0) return;
            int orderID = Convert.ToInt32(this.grvDPProduct.GetRowCellValue(e.RowHandle, "DispatchingOrderDetailID"));
            int countExp = this.expiredDateDispatchingDetailSource.Select("OrderID = " + orderID).Count();
            if (countExp <= 0) return;
            e.Appearance.BackColor = Color.Red;
        }

        private void rpi_btn_UpdateCartonUnit_Click(object sender, EventArgs e)
        {
            //if (this.receivingOrderDetail == null) return;
            frm_WM_UpdateCartonPallet frmUpdate = new frm_WM_UpdateCartonPallet();
            frmUpdate.ShowDialog();
        }

        private void simpleCreateCartons_Click(object sender, EventArgs e)
        {


        }

        private void SetButtonGridOrderDetail(bool isActive)
        {
            this.btn_WM_Update.Enabled = !isActive;
            this.btn_WM_Combine.Enabled = isActive;
            this.btn_WM_Break.Enabled = isActive;
            this.btn_WM_Remark.Enabled = isActive;
            this.btn_WM_Reference.Enabled = isActive;
            this.btn_WM_Accept.Enabled = isActive;
            this.grdDPProduct.Enabled = isActive;
            setColorButton();
        }

        private void grvDispatchingOrderDetail_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "QuantityOfPackages")
            {
                SetButtonGridOrderDetail(false);
                this.OnEventDisable(false, e);
            }
        }
        // disable when changing data Urc_DispatchingCarton 
        private void SetActiveParentControls(bool isActive)
        {
            this.grdDPProduct.Enabled = isActive;
            this.grdDispatchingOrderDetail.Enabled = isActive;
            this.btn_WM_Update.Enabled = isActive;
            this.btn_WM_Combine.Enabled = isActive;
            this.btn_WM_Break.Enabled = isActive;
            this.btn_WM_Remark.Enabled = isActive;
            this.btn_WM_Reference.Enabled = isActive;
            this.btn_WM_Accept.Enabled = isActive;
            setColorButton();
        }


        private void setColorButton()
        {
            btn_WM_Reference.Appearance.BackColor = (btn_WM_Reference.Enabled) ? DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning : Color.Gray;
            btn_WM_Update.Appearance.BackColor = (btn_WM_Update.Enabled) ? DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning : Color.Gray;
            btn_WM_Combine.Appearance.BackColor = (btn_WM_Combine.Enabled) ? DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning : Color.Gray;
            btn_WM_Remark.Appearance.BackColor = (btn_WM_Remark.Enabled) ? DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning : Color.Gray;
            btn_WM_Break.Appearance.BackColor = (btn_WM_Break.Enabled) ? DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning : Color.Gray;
            btn_WM_BreakSameDO.Appearance.BackColor = (btn_WM_BreakSameDO.Enabled) ? DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning : Color.Gray;
            btn_WM_BreakMakeNewDO.Appearance.BackColor = (btn_WM_BreakMakeNewDO.Enabled) ? DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning : Color.Gray;
        }
        private void setColorButtonAccept(object status, EventArgs e)
        {
            this.status = Convert.ToInt16(status);
            if (Convert.ToInt16(status) == 1)
            {
                setColorButton();
                btn_WM_Accept.Appearance.BackColor = Color.Gray;

            }
            else if (Convert.ToInt16(status) == 2)
            {
                setColorButton();
                btn_WM_Accept.Appearance.BackColor = Color.Gray;

                OnEventDisable(false, e);



            }
            else if (Convert.ToInt16(status) == 0)
            {
                setColorButton();
                btn_WM_Accept.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning;
            }
            else
            {

            }
        }



        private void rpi_btnDoWeight_Click(object sender, EventArgs e)
        {
            bool hasSendNavi = Convert.ToBoolean(this.grvDispatchingOrderDetail.GetFocusedRowCellValue("IsSendNavi"));
            if (hasSendNavi)
            {
                XtraMessageBox.Show("Pallets had sync with WareNavi, you couldn't modify it!", "TWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var t = AppSetting.ProductList.Where(c => c.ProductNumber == this._dp.ProductNumber).FirstOrDefault();
            if (t == null) return;
            if (t.Packages == "KGR")
            {
                DataProcess<Object> da = new DataProcess<object>();
                int fouseRow = this.grvDispatchingOrderDetail.FocusedRowHandle;
                if (fouseRow > -1)
                {
                    int doDetailID = Convert.ToInt32(this.grvDispatchingOrderDetail.GetRowCellValue(this.grvDispatchingOrderDetail.FocusedRowHandle, "DispatchingOrderDetailID"));
                    decimal weightAvg = Convert.ToDecimal(this.txtWeightPerPackage.Text) * Convert.ToDecimal(grvDispatchingOrderDetail.GetFocusedRowCellValue("QuantityOfPackages"));
                    int result = da.ExecuteNoQuery("Update DispatchingOrderDetails set PalletWeight={0} where DispatchingOrderDetailID={1}", weightAvg, doDetailID);
                    if (result > 0)
                    {
                        grvDispatchingOrderDetail.SetFocusedRowCellValue("PalletWeight", weightAvg);
                    }
                }
            }

        }

        private void grvDispatchingOrderDetail_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            bool isSyncNavi = Convert.ToBoolean(this.grvDispatchingOrderDetail.GetRowCellValue(e.RowHandle, "IsSyncNavi"));
            if (e.RowHandle < 0 || !isSyncNavi) return;
            int qtyReceived = Convert.ToInt32(this.grvDispatchingOrderDetail.GetRowCellValue(e.RowHandle, "QuantityOfPackages"));
            int AReceived = Convert.ToInt32(this.grvDispatchingOrderDetail.GetRowCellValue(e.RowHandle, "NaviQty"));
            if (isSyncNavi)
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
            if (this.grvDispatchingOrderDetail.SelectedRowsCount <= 0)
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
            int totalPallet = this.grvDispatchingOrderDetail.SelectedRowsCount;
            int index = 1;
            int palletIDSelected = 0;
            string qtyNaviStr = "";
            foreach (var palletIndex in this.grvDispatchingOrderDetail.GetSelectedRows())
            {
                int AReceived = Convert.ToInt32(this.grvDispatchingOrderDetail.GetRowCellValue(palletIndex, "NaviQty"));
                palletIDSelected = Convert.ToInt32(this.grvDispatchingOrderDetail.GetRowCellValue(palletIndex, "DispatchingOrderDetailID"));
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
            int resultSync = palletsDA.ExecuteNoQuery("STSyncQtyDODetailByPalletID @DODetailIDDStr='" + sqlClause.ToString() + "'");
            if (resultSync > 0)
            {
                XtraMessageBox.Show("SYNC SUCCESSFUL!", "TWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDODetailsCarton();
            }
            else
            {
                XtraMessageBox.Show("SYNC FAIL!", "TWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
