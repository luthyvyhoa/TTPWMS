using Common.Controls;
using DA;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using UI.Helper;
using UI.MasterSystemSetup;
using System.Text;
using DevExpress.Utils.Win;
using DevExpress.XtraEditors.Popup;
using log4net;
using Common.Process;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_ReceivingProductNew : frmBaseForm
    {
        // Declare log
        private static readonly ILog log = LogManager.GetLogger(typeof(frm_WM_ReceivingProductNew));
        private int customerIDSelected = -1;
        private IList<ReceivingOrderDetails> receivingOrderList = null;
        private IList<Products> productList = null;
        private string tructDetail = string.Empty;
        private IList<ReceivingOrderDetails> productsAddNew;
        private bool _isFirstLoad = true;
        private bool _isNew = true;
        private int _orderID;
        private IList<int> indexListRowselected = null;
        private bool isAddAll = false;
        private bool acceptValue = true;

        public frm_WM_ReceivingProductNew(int customerID, string tructDetail, int orderID)
        {
            InitializeComponent();
            this.IsFixHeightScreen = false;
            RefreshData.ReloadDataEvent += RefreshData_ReloadDataEvent;

            // Get current customer selected
            this.customerIDSelected = customerID;
            this.tructDetail = tructDetail;
            this._orderID = orderID;

            // Init data
            this.chk_WM_UseTab1.Checked = false;
            this.checkSearchAllColumns.Checked = false;
            this.InitData(customerID, tructDetail, orderID);
        }
        /// <summary>
        /// Reload order detail when product has modified
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        void RefreshData_ReloadDataEvent(object sender, EventArgs e)
        {
            if (!sender.GetType().Name.Equals("ReceivingOrderDetails")) return;
            // Load all product by customer current selected
            this.LoadProductDataByCustomer();
        }

        /// <summary>
        /// Get products list to add new
        /// </summary>
        public IList<ReceivingOrderDetails> ProductsAddNew
        {
            get
            {
                return this.productsAddNew;
            }
        }

        /// <summary>
        /// Get is to picking location for all product
        /// </summary>
        public bool IsToPickingLocation
        {
            get
            {
                return this.chk_WM_ToPickingLocation1.Checked;
            }
        }

        /// <summary>
        /// Get whether there any new row update
        /// </summary>
        public bool IsNew
        {
            get
            {
                return this._isNew;
            }
            set
            {
                this._isNew = value;
            }
        }

        public void InitData(int customerID, string tructDetail, int orderID)
        {
            // Get current customer selected
            this.customerIDSelected = customerID;
            this.tructDetail = tructDetail;
            this._orderID = orderID;

            // Init data
            this.chk_WM_UseTab1.Checked = false;

            // Init product list
            this.receivingOrderList = new List<ReceivingOrderDetails>();

            // Load all product by customer current selected
            this.LoadProductDataByCustomer();

            // Set focused first row in grid
            this.AddNewRowProductList();

            this._isFirstLoad = false;

            this.indexListRowselected = new List<int>();
        }

        private void LoadProductDataByCustomer()
        {
            this.productList = AppSetting.ProductList.Where(x => (x.CustomerID == this.customerIDSelected) && (x.Discontinue == false)).OrderBy(c => c.ProductNumber).ToList();
            this.rpilkProducts.DataSource = this.productList;
            this.rpilkProducts.ValueMember = "ProductID";
            this.rpilkProducts.DisplayMember = "ProductNumberEx";
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            return true;
        }

        /// <summary>
        /// Add new row on product list
        /// </summary>
        private void AddNewRowProductList()
        {
            ReceivingOrderDetails newProduct = new ReceivingOrderDetails();
            this.receivingOrderList.Add(newProduct);
            this.grd_WM_Products.DataSource = this.receivingOrderList;
            this.grv_WM_Products.RefreshData();
        }

        /// <summary>
        /// Call product detail
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rpibtnCallProduct_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int productID = Convert.ToInt32(this.grv_WM_Products.GetRowCellValue(this.grv_WM_Products.FocusedRowHandle, "ProductID").ToString());
            if (productID <= 0) return;
            frm_MSS_Products frmProduct = frm_MSS_Products.Instance;
            frmProduct.ProductIDLookup = productID;
            frmProduct.Show();
        }

        private void rpilkProducts_EditValueChanged(object sender, EventArgs e)
        {


        }

        private void UpdateReceivingProduct()
        {
            DataProcess<ReceivingOrderDetails> receivingOrderDetailDA = new DataProcess<ReceivingOrderDetails>();

            foreach (var receivingItem in this.receivingOrderList)
            {
                if (receivingItem.TotalPackages == null || receivingItem.ProductID <= 0 || receivingItem.TotalPackages <= 0) continue;
                receivingItem.TotalUnits = receivingItem.TotalPackages * receivingItem.UnitPerPackage;
                receivingItem.TotalWeight = (decimal)(receivingItem.TotalPackages * receivingItem.WeightPerPackage);
                receivingItem.UserName = AppSetting.CurrentUser.LoginName;

                // Insert into Db
                receivingItem.CreatedBy = AppSetting.CurrentUser.LoginName;
                receivingItem.CreatedTime = DateTime.Now;
                receivingItem.ReceivingOrderID = this._orderID;
                receivingItem.ReceivingOrderNumber = "RO-" + this._orderID;
                receivingItem.ProductNumber = AppSetting.ProductList.Where(p => p.ProductID == receivingItem.ProductID).FirstOrDefault().ProductNumber;
                receivingItem.Status = 0;

                // Insert into Db
                int result = receivingOrderDetailDA.ExecuteNoQuery("STReceivingOrderDetailInsert " +
                   " @ReceivingOrderID ={0}," +
                   " @ReceivingOrderNumber={1}," +
                   " @ProductNumber={2}," +
                   " @ProductName={3}," +
                   " @ProductID={4}," +
                   " @PackagePerPallet={5}," +
                   " @Quantity={6}," +
                   " @WeightPerPackage={7}," +
                   " @CustomerRef={8}," +
                   " @CurrentUser={9}," +
                   " @ToPickingLocation={10}," +
                   " @ProductionDate={11}," +
                   " @UseByDate={12}," +
                   " @varRemark={13}," +
                   " @varPackages={14}," +
                   " @varPcs={15}", this._orderID, receivingItem.ReceivingOrderNumber, receivingItem.ProductNumber, receivingItem.ProductName, receivingItem.ProductID,
                   receivingItem.PackagesPerPallet, receivingItem.TotalPackages, receivingItem.WeightPerPackage, receivingItem.CustomerRef, AppSetting.CurrentUser.LoginName,
                   IsToPickingLocation, receivingItem.ProductionDate, receivingItem.UseByDate, receivingItem.Remark, receivingItem.Packages, receivingItem.Pcs);
            }

        }

        private void rpilkProducts_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode.Equals(System.Windows.Forms.Keys.Enter))
            {
                if (this.chk_WM_UseTab1.Checked)
                {
                    this.grv_WM_Products.FocusedColumn = this.gridColumn8;
                }
                else
                {
                    this.grv_WM_Products.FocusedColumn = this.gridColumn6;
                }
            }
        }

        private void grv_WM_Products_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void grv_WM_Products_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            GridView view = sender as GridView;
            switch (view.FocusedColumn.FieldName)
            {
                case "ProductID":
                    {
                        if(!this.checkSearchAllColumns.Checked)
                        {
                            if (!this._isFirstLoad)
                            {
                                if (this.grv_WM_Products.GetFocusedRowCellValue("ProductID").ToString().Equals("0"))
                                {
                                    if (!chk_WM_UseTab1.Checked)
                                    {
                                        this.grv_WM_Products.Columns["ProductionDate"].OptionsColumn.AllowFocus = true;
                                        this.grv_WM_Products.Columns["UseByDate"].OptionsColumn.AllowFocus = true;
                                    }
                                }
                            }
                            this.grv_WM_Products.ShowEditor();
                            if (grv_WM_Products.ActiveEditor != null)
                                ((LookUpEdit)grv_WM_Products.ActiveEditor).ShowPopup();
                        }
                        else
                        {
                            if (grv_WM_Products.ActiveEditor != null)
                                ((SearchLookUpEdit)grv_WM_Products.ActiveEditor).ShowPopup();
                        }
                        break;
                    }

                case "CustomerRef":
                    if (this.grv_WM_Products.GetFocusedRowCellValue("ProductID").ToString().Equals("0")) return;
                    var customerRefValue = view.GetRowCellValue(view.FocusedRowHandle, e.FocusedColumn.FieldName);
                    if (customerRefValue == null || customerRefValue.ToString().Trim() == string.Empty)
                    {
                        DevExpress.XtraGrid.Columns.GridColumn refColumn = this.grv_WM_Products.Columns["CustomerRef"];
                        view.SetColumnError(refColumn, "Customer requirements is not empty");

                        // Don't move next cell if customer reference is not input
                        this.grv_WM_Products.Columns["TotalPackages"].OptionsColumn.AllowFocus = false;
                        this.grv_WM_Products.Columns["NumExp"].OptionsColumn.AllowFocus = false;
                        if (!chk_WM_UseTab1.Checked)
                        {
                            this.grv_WM_Products.Columns["ProductionDate"].OptionsColumn.AllowFocus = false;
                            this.grv_WM_Products.Columns["UseByDate"].OptionsColumn.AllowFocus = false;
                            this.grv_WM_Products.UpdateCurrentRow();
                        }
                    }
                    else
                    {
                        this.grv_WM_Products.Columns["TotalPackages"].OptionsColumn.AllowFocus = true;
                    }
                    break;

                case "TotalPackages":
                    if (!this._isFirstLoad)
                    {
                        if (this.grv_WM_Products.GetFocusedRowCellValue("ReceivingOrderDetailID").ToString().Equals("0"))
                        {
                            if (!chk_WM_UseTab1.Checked)
                            {
                                this.grv_WM_Products.Columns["ProductionDate"].OptionsColumn.AllowFocus = false;
                                this.grv_WM_Products.Columns["UseByDate"].OptionsColumn.AllowFocus = false;
                            }
                        }
                    }
                    var qtyValue = view.GetRowCellValue(view.FocusedRowHandle, e.FocusedColumn.FieldName);
                    if (qtyValue == null || (short)qtyValue <= 0)
                    {
                        DevExpress.XtraGrid.Columns.GridColumn refColumn = this.grv_WM_Products.Columns["TotalPackages"];
                        view.SetColumnError(refColumn, "Quantity is must more than >0");
                    }
                    break;

                case "UseByDate":
                    var productidSelected = this.grv_WM_Products.GetFocusedRowCellValue(this.grv_WM_Products.Columns["ProductID"]);
                    if (chk_WM_UseTab1.Checked)
                    {
                        if (productidSelected == null || (int)productidSelected == 0)
                        {
                            this.grv_WM_Products.ClearSelection();
                            SendKeys.Send("{TAB}");
                            this.btn_WM_Ok1.Focus();
                        }
                    }

                    break;
                default:
                    break;
            }
        }

        private void grv_WM_Products_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Value == null)
            {
                return;
            }

            DataProcess<object> roDetailDA = new DataProcess<object>();
            int roDetailID = Convert.ToInt32(this.grv_WM_Products.GetFocusedRowCellValue("ReceivingOrderDetailID"));
            //DateTime prodate = Convert.ToDateTime(this.grv_WM_Products.GetFocusedRowCellValue("ProductionDate"));
            
            //if (e.Column.Caption == "M" &&  prodate != null)
            //{
            //    int exMonth = Convert.ToInt16(e.Value.ToString());
            //    string exDate = Convert.ToDateTime(e.Value).AddMonths(exMonth).ToString("yyyy/MM/dd");
            //    this.grv_WM_Products.SetRowCellValue(e.RowHandle, this.grv_WM_Products.Columns["UseByDate"], exDate);
            //}
            

            switch (e.Column.FieldName)
            {
                case "NumExp":
                    var proDateSelected = Convert.ToDateTime(this.grv_WM_Products.GetFocusedRowCellValue("ProductionDate"));
                    if (proDateSelected != null)
                    {
                        var expDate = proDateSelected.AddMonths(Convert.ToInt16(e.Value));
                        this.grv_WM_Products.SetFocusedRowCellValue("UseByDate", expDate);
                        if (!this._isNew)
                        {
                            roDetailDA.ExecuteNoQuery("Update ReceivingOrderDetails Set NumExp = " + e.Value + " Where ReceivingOrderDetailID = " + roDetailID);
                        }
                    }
                    break;
                case "TotalPackages":
                    {
                        int qty = Convert.ToInt32(e.Value);
                        if (qty <= 0)
                        {
                            this.grv_WM_Products.FocusedColumn = e.Column;
                            return;
                        }
                        else
                        {
                            if (!this._isNew)
                            {
                                roDetailDA.ExecuteNoQuery("Update ReceivingOrderDetails Set ReceivingOrderDetails.TotalPackages = " + qty + " Where ReceivingOrderDetailID = " + roDetailID);
                            }
                            this.grv_WM_Products.Columns["NumExp"].OptionsColumn.AllowFocus = true;
                        }
                        break;
                    }
                case "ProductionDate":
                    {
                        if (Convert.ToDateTime(this.grv_WM_Products.GetFocusedRowCellValue("ProductionDate")) == DateTime.Now)
                        {
                            XtraMessageBox.Show("Please Re-enter correct date", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.grv_WM_Products.FocusedColumn = e.Column;
                        }
                        else
                        {
                            if (!this._isNew)
                            {
                                string proDate = Convert.ToDateTime(e.Value).ToString("yyyy-MM-dd");
                                roDetailDA.ExecuteNoQuery("Update ReceivingOrderDetails Set ReceivingOrderDetails.ProductionDate = '" + proDate + "' Where ReceivingOrderDetailID = " + roDetailID);
                            }
                        }
                        break;
                    }
                case "UseByDate":
                    {
                        if (Convert.ToDateTime(this.grv_WM_Products.GetFocusedRowCellValue("UseByDate")) < Convert.ToDateTime(this.grv_WM_Products.GetFocusedRowCellValue("ProductionDate")))
                        {
                            this.grv_WM_Products.FocusedColumn = e.Column;
                        }
                        else
                        {
                            if (!this._isNew)
                            {
                                string expDate = Convert.ToDateTime(e.Value).ToString("yyyy-MM-dd");
                                roDetailDA.ExecuteNoQuery("Update ReceivingOrderDetails Set ReceivingOrderDetails.UseByDate = '" + expDate + "' Where ReceivingOrderDetailID = " + roDetailID);
                            }
                        }
                        break;
                    }
                case "CustomerRef":
                    {
                        if (String.IsNullOrEmpty(Convert.ToString(e.Value)))
                        {
                            this.grv_WM_Products.FocusedColumn = e.Column;
                            this.grv_WM_Products.Columns["TotalPackages"].OptionsColumn.AllowFocus = false;
                        }
                        else
                        {
                            if (!this._isNew)
                            {
                                roDetailDA.ExecuteNoQuery("Update ReceivingOrderDetails Set ReceivingOrderDetails.CustomerRef = '" + Convert.ToString(e.Value) + "' Where ReceivingOrderDetailID = " + roDetailID);
                            }
                            this.grv_WM_Products.Columns["TotalPackages"].OptionsColumn.AllowFocus = true;
                        }

                        break;
                    }
                case "ProductID":
                    {
                        if (e.RowHandle == this.grv_WM_Products.GetVisibleRowHandle(this.grv_WM_Products.RowCount - 1))
                        {
                            this._isNew = true;
                            var productSelected = (Products)this.rpilkProducts.GetDataSourceRowByKeyValue(e.Value);
                            if (productSelected == null)
                            {
                                return;
                            }

                            //this.grv_WM_Products.SetFocusedRowCellValue("ProductID", productSelected.ProductID);
                            this.grv_WM_Products.SetFocusedRowCellValue("ProductName", productSelected.ProductName);
                            this.grv_WM_Products.SetFocusedRowCellValue("PackagesPerPallet", productSelected.PackagesPerPallet);
                            this.grv_WM_Products.SetFocusedRowCellValue("WeightPerPackage", productSelected.WeightPerPackage);
                            this.grv_WM_Products.SetFocusedRowCellValue("UnitPerPackage", productSelected.Inners);
                            this.grv_WM_Products.SetFocusedRowCellValue("ProductNumber", productSelected.ProductNumber);
                        }
                        else
                        {
                            if (!this._isNew)
                            {
                                roDetailDA.ExecuteNoQuery("Update ReceivingOrderDetails Set ReceivingOrderDetails.ProductID = " + Convert.ToInt32(e.Value) + " Where ReceivingOrderDetailID = " + roDetailID);
                                roDetailDA.ExecuteNoQuery("Update ReceivingOrderDetails Set ReceivingOrderDetails.ProductName = '" + Convert.ToString(this.grv_WM_Products.GetFocusedRowCellValue("ProductName")) + "' Where ReceivingOrderDetailID = " + roDetailID);
                                roDetailDA.ExecuteNoQuery("Update ReceivingOrderDetails Set ReceivingOrderDetails.ProductNumber = '" + Convert.ToString(this.grv_WM_Products.GetFocusedRowCellValue("ProductNumber")) + "' Where ReceivingOrderDetailID = " + roDetailID);
                            }
                        }
                        break;
                    }
            }

            var customerRefValue = this.grv_WM_Products.GetRowCellValue(this.grv_WM_Products.FocusedRowHandle, "CustomerRef");
            var qtyValue = this.grv_WM_Products.GetRowCellValue(this.grv_WM_Products.FocusedRowHandle, "TotalPackages");
            var productNameValue = this.grv_WM_Products.GetRowCellValue(this.grv_WM_Products.FocusedRowHandle, "ProductName");
            if (customerRefValue == null || qtyValue == null || productNameValue == null) return;
            if (customerRefValue.ToString().Trim() != string.Empty && (short)qtyValue > 0)
            {
                if (this.grv_WM_Products.FocusedRowHandle == this.grv_WM_Products.RowCount - 1)
                {
                    // Add new row
                    this.AddNewRowProductList();
                }
            }
        }

        private void frm_WM_ReceivingProductNew_Shown(object sender, EventArgs e)
        {
            this.rpilkProducts.AllowFocused = true;
            this.rpilkProducts.ImmediatePopup = true;
            this.grv_WM_Products.FocusedRowHandle = 0;
            this.grv_WM_Products.FocusedColumn = this.grv_WM_Products.Columns["ProductID"];
            this.grv_WM_Products.ShowEditor();
            if (!this.checkSearchAllColumns.Checked)
                ((LookUpEdit)this.grv_WM_Products.ActiveEditor).ShowPopup();
            else
                ((SearchLookUpEdit)this.grv_WM_Products.ActiveEditor).ShowPopup();
        }

        private void btn_WM_AllProducts1_Click(object sender, EventArgs e)
        {
            ReceivingOrderDetails receivingOrderAdd = null;
            this.receivingOrderList.Clear();
            foreach (var pro in this.productList)
            {
                receivingOrderAdd = new ReceivingOrderDetails();
                receivingOrderAdd.ProductID = pro.ProductID;
                receivingOrderAdd.ProductNumber = pro.ProductNumber;
                receivingOrderAdd.ProductName = pro.ProductName;
                receivingOrderAdd.PackagesPerPallet = (short)pro.PackagesPerPallet;
                receivingOrderAdd.WeightPerPackage = (float)pro.WeightPerPackage;
                receivingOrderAdd.CustomerRef = this.tructDetail;
                receivingOrderAdd.TotalPackages = 0;
                receivingOrderAdd.UnitPerPackage = pro.Inners;
                receivingOrderAdd.Status = (byte)this.chk_WM_ToPickingLocation1.CheckState;
                this.receivingOrderList.Add(receivingOrderAdd);
            }
            this.grv_WM_Products.RefreshData();
            gridColumn7.OptionsColumn.AllowFocus = true;
            this.grv_WM_Products.FocusedColumn = this.gridColumn7;
            this.isAddAll = true;
        }

        private void btn_WM_Ok1_Click(object sender, EventArgs e)
        {
            if (this.grv_WM_Products.RowCount <= 0)
            {
                XtraMessageBox.Show("Please select Product!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.grd_WM_Products.DataSource == null || ((IList<ReceivingOrderDetails>)this.grd_WM_Products.DataSource).Count <= 0)
            {
                System.Windows.Forms.MessageBox.Show("Please select Product!");
                return;
            }

            var listProductSelected = this.receivingOrderList.Where(p => p.TotalPackages > 0);
            if (listProductSelected.Count() <= 0)
            {
                System.Windows.Forms.MessageBox.Show("Please input quantity for products want select!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //Trung add this code to allow user save record when click OK button
            this.grd_WM_Products.EmbeddedNavigator.Buttons.DoClick(this.grd_WM_Products.EmbeddedNavigator.Buttons.Append);

            this.UpdateReceivingProduct();
            this.btn_WM_Ok1.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_WN_Cancel1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chk_WM_UseTab1_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_WM_UseTab1.Checked)
            {
                this.grv_WM_Products.Columns["CustomerRef"].VisibleIndex = 7;
                this.grv_WM_Products.Columns["TotalPackages"].VisibleIndex = 8;
                this.grv_WM_Products.Columns["ProductionDate"].VisibleIndex = 5;
                this.grv_WM_Products.Columns["NumExp"].VisibleIndex = 6;
                this.grv_WM_Products.Columns["UseByDate"].VisibleIndex = 7;
                this.grv_WM_Products.Columns["ProductionDate"].OptionsColumn.AllowFocus = true;
                this.grv_WM_Products.Columns["UseByDate"].OptionsColumn.AllowFocus = true;
            }
            else
            {
                this.grv_WM_Products.Columns["CustomerRef"].VisibleIndex = 5;
                this.grv_WM_Products.Columns["TotalPackages"].VisibleIndex = 6;
                this.grv_WM_Products.Columns["ProductionDate"].VisibleIndex = 7;
                this.grv_WM_Products.Columns["UseByDate"].VisibleIndex = 8;
                this.grv_WM_Products.Columns["NumExp"].VisibleIndex = 9;
                this.grv_WM_Products.Columns["ProductionDate"].OptionsColumn.AllowFocus = false;
                this.grv_WM_Products.Columns["UseByDate"].OptionsColumn.AllowFocus = false;
            }

            this.grv_WM_Products.RefreshData();
            this.grv_WM_Products.FocusedRowHandle = this.grv_WM_Products.FocusedRowHandle;
            this.grv_WM_Products.FocusedColumn = this.grv_WM_Products.Columns["ProductID"];
        }

        private void grv_WM_Products_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (!_isFirstLoad)
            {

                DataProcess<ReceivingOrderDetails> receivingOrderDetailDA = new DataProcess<ReceivingOrderDetails>();

                ReceivingOrderDetails receivingItem = (ReceivingOrderDetails)this.grv_WM_Products.GetRow(e.PrevFocusedRowHandle);
                if (receivingItem == null) return;

                if (receivingItem.ProductID <= 0)
                {
                    gridColumn7.OptionsColumn.AllowFocus = true;
                    return;
                }
                else
                {
                    if (!this.isAddAll)
                    {
                        gridColumn7.OptionsColumn.AllowFocus = false;
                    }
                }

                if (receivingItem.TotalPackages <= 0)
                {
                    if (grv_WM_Products.FocusedColumn.FieldName.Equals("Qty"))
                    {
                        XtraMessageBox.Show("Please enter correct Quantity !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    //this.grv_WM_Products.FocusedRowHandle = e.PrevFocusedRowHandle;
                    //this.grv_WM_Products.FocusedColumn = this.gridColumn6;
                    return;
                }

                if (!this._isNew)
                {
                    return;
                }

                this._isNew = false;
                if (this.indexListRowselected.Contains(e.FocusedRowHandle)) return;
                this.indexListRowselected.Add(e.FocusedRowHandle);

                if (!this.isAddAll)
                {
                    if (this.grv_WM_Products.RowCount <= 0) return;
                    this.grv_WM_Products.FocusedRowHandle = this.grv_WM_Products.RowCount - 1;
                    this.grv_WM_Products.FocusedColumn = this.grv_WM_Products.VisibleColumns[1];
                    this.grv_WM_Products.ShowEditor();
                    if (this.checkSearchAllColumns.Checked)
                        ((SearchLookUpEdit)grv_WM_Products.ActiveEditor).ShowPopup();
                    else
                        ((LookUpEdit)grv_WM_Products.ActiveEditor).ShowPopup();
                }
            }
        }

        private void grv_WM_Products_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DataProcess<ReceivingOrderDetails> roDetail = new DataProcess<ReceivingOrderDetails>();

                int[] selectedRows = this.grv_WM_Products.GetSelectedRows();
                int id = 0;
                int result = -2;

                if (XtraMessageBox.Show("Are you sure to delete products ?", "TPWMS", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                {
                    return;
                }

                for (int i = 0; i < selectedRows.Count(); i++)
                {
                    ReceivingOrderDetails detail = (ReceivingOrderDetails)this.grv_WM_Products.GetRow(selectedRows[i]);
                    id = Convert.ToInt32(this.grv_WM_Products.GetRowCellValue(selectedRows[i], "ReceivingOrderDetailID"));
                    result = roDetail.ExecuteNoQuery("Delete From ReceivingOrderDetails Where ReceivingOrderDetailID = {0}", id);
                    this.receivingOrderList.Remove(detail);
                }

                this.grv_WM_Products.RefreshData();
            }

            if (e.KeyCode.Equals(Keys.Escape) && this.grv_WM_Products.FocusedColumn.FieldName.Equals("CustomerRef"))
            {
                string customerRef = Convert.ToString(this.grv_WM_Products.GetFocusedRowCellValue("CustomerRef"));
            }
        }

        private void rpilkProducts_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (!this.acceptValue)
            {
                e.AcceptValue = this.acceptValue;
                e.Value = 0;
                this.acceptValue = true;
                return;
            }
            LookUpEdit edit = sender as LookUpEdit;
            IPopupControl popup = sender as IPopupControl;
            PopupLookUpEditForm f = popup.PopupWindow as PopupLookUpEditForm;
            var currentValue = f.CurrentValue;
            edit.EditValue = currentValue;
            var proInfo = (Products)this.rpilkProducts.GetDataSourceRowByKeyValue(currentValue);
            this.grv_WM_Products.SetFocusedRowCellValue("ProductID", currentValue);
            if (proInfo != null)
            {
                this.grv_WM_Products.SetFocusedRowCellValue("Packages", proInfo.Packages);
                this.grv_WM_Products.SetFocusedRowCellValue("Pcs", proInfo.Pcs);
            }
            SendKeys.Send("{TAB}");
        }

        private void frm_WM_ReceivingProductNew_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.isAddAll = false;
            this.Hide();
            e.Cancel = true;
        }

        private void grv_WM_Products_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (this.grv_WM_Products.FocusedColumn.FieldName.Equals("UseByDate"))
            {
                DateTime expDate = (DateTime)e.Value;
                if (this.grv_WM_Products.GetFocusedRowCellValue("ProductionDate") == null)
                {
                    if (expDate.CompareTo(DateTime.Now) < 0)
                    {
                        e.Valid = false;
                        return;
                    }
                    e.Valid = true;
                    return;
                }
                DateTime proDate = (DateTime)this.grv_WM_Products.GetFocusedRowCellValue("ProductionDate");

                if (proDate.CompareTo(expDate) > 0)
                {
                    e.Valid = false;
                    e.ErrorText = "Invalid date";
                }
            }
            else if (this.grv_WM_Products.FocusedColumn.FieldName.Equals("ProductionDate"))
            {
                if (e.Value != null)
                {
                    DateTime proDate = (DateTime)e.Value;
                    if (proDate > DateTime.Now)
                    {
                        e.Valid = false;
                        e.ErrorText = "Invalid date";
                    }
                }
            }
        }

        private void rpilkProducts_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {

        }

        private void grv_WM_Products_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (e.RowHandle < 0) return;
            switch (e.Column.FieldName)
            {
                case "ProductionDate":
                    this.grv_WM_Products.Columns["ProductionDate"].OptionsColumn.AllowFocus = true;
                    break;
                case "UseByDate":
                    this.grv_WM_Products.Columns["UseByDate"].OptionsColumn.AllowFocus = true;
                    break;
                case "Pcs":
                    this.grv_WM_Products.Columns["Pcs"].OptionsColumn.AllowFocus = true;
                    break;
                case "Packages":
                    this.grv_WM_Products.Columns["Packages"].OptionsColumn.AllowFocus = true;
                    break;
                default:
                    break;
            }
            this.grv_WM_Products.ShowEditForm();
            this.grv_WM_Products.ShowEditor();
        }

        private void rpilkProducts_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.acceptValue = true;
            LookUpEdit edit = sender as LookUpEdit;
            if (edit.AccessibilityObject.Value == null)
            {
                e.Cancel = true;
                edit.EditValue = 0;
                this.grv_WM_Products.SetFocusedRowCellValue("ProductID", 0);
                this.grv_WM_Products.SetFocusedRowCellValue("ProductName", string.Empty);
                this.grv_WM_Products.SetFocusedRowCellValue("PackagesPerPallet", 0);
                this.grv_WM_Products.SetFocusedRowCellValue("WeightPerPackage", 0);
                this.acceptValue = false;
            }
            else
            {
                string productNunberEx = edit.AccessibilityObject.Value;
                int checkOutSum = this.productList.Where(p => p.ProductNumberEx.Equals(productNunberEx)).Count();
                if (checkOutSum <= 0)
                {
                    e.Cancel = true;
                    edit.Text = edit.AccessibilityObject.Value;
                    this.acceptValue = false;
                    edit.EditValue = 0;
                    this.grv_WM_Products.SetFocusedRowCellValue("ProductID", 0);
                    this.grv_WM_Products.SetFocusedRowCellValue("ProductName", string.Empty);
                    this.grv_WM_Products.SetFocusedRowCellValue("PackagesPerPallet", 0);
                    this.grv_WM_Products.SetFocusedRowCellValue("WeightPerPackage", 0);
                    this.grv_WM_Products.SetFocusedRowCellValue("CustomerRef", string.Empty);

                }
            }
        }

        private void checkSearchAllColumns_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkSearchAllColumns.Checked)
            {
                //this.rpilkProducts.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
                this.rpiSearchProducts.DataSource = this.productList;
                //this.productList = AppSetting.ProductList.Where(x => (x.CustomerID == this.customerIDSelected) && (x.Discontinue == false)).OrderBy(c => c.ProductNumber).ToList();

                this.rpiSearchProducts.ValueMember = "ProductID";
                this.rpiSearchProducts.DisplayMember = "ProductNumberEx";
                this.gridColumn2.ColumnEdit = this.rpiSearchProducts;
            }

            else
                this.gridColumn2.ColumnEdit = this.rpilkProducts;
        }

        private void rpiSearchProducts_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {

            if (!this.acceptValue)
            {
                e.AcceptValue = this.acceptValue;
                e.Value = 0;
                this.acceptValue = true;
                return;
            }
            //LookUpEdit edit = sender as LookUpEdit;
            //IPopupControl popup = sender as IPopupControl;
            //PopupLookUpEditForm f = popup.PopupWindow as PopupLookUpEditForm;
            //var currentValue = f.CurrentValue;
            //edit.EditValue = currentValue;
            string xx = this.searchlookupView.GetFocusedRowCellDisplayText("ProductID") + " | " + this.searchlookupView.GetFocusedRowCellDisplayText("Pcs");
            this.grv_WM_Products.SetFocusedRowCellValue("ProductID", this.searchlookupView.GetFocusedRowCellDisplayText("ProductID"));

            this.grv_WM_Products.SetFocusedRowCellValue("Packages", "Ctns");
            this.grv_WM_Products.SetFocusedRowCellValue("Pcs", this.searchlookupView.GetFocusedRowCellDisplayText("Pcs"));
            //if (proInfo != null)
            //{
            //    this.grv_WM_Products.SetFocusedRowCellValue("Packages", proInfo.Packages);
            //    this.grv_WM_Products.SetFocusedRowCellValue("Pcs", proInfo.Pcs);
            //}
            SendKeys.Send("{TAB}");
        }
    }
}
