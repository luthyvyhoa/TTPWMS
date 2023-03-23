using Common.Controls;
using DA;
using DA.Master;
using DevExpress.Data;
using DevExpress.Utils.Win;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraGrid;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UI.Helper;
namespace UI.WarehouseManagement
{
    public partial class frm_WM_Dialog_DOSelectPallets : frmBaseForm
    {
        // Declare log
        private static readonly ILog log = LogManager.GetLogger(typeof(frm_WM_Dialog_DOSelectPallets));
        private int _selectedSum;
        private int _selectedCount;
        private string _fieldName = "DOQty";
        int customerID = 0;
        string customerNumber = "";
        string customerType = "";
        string dispatchingOrderNumber = "";
        Int32 dispatchingOrderID = 0;
        private int productIDSelected = -1;
        private bool isShowDetail = false;
        private bool acceptValue = true;
        IList<STComboProductIDDO_Result> productList = null;

        public frm_WM_Dialog_DOSelectPallets()
        {
            InitializeComponent();

            // Check current customer is experity date
            this.CheckCustomerIsExpityDate();
        }

        public frm_WM_Dialog_DOSelectPallets(string dONumber, Int32 dOID, int custID, string custNumber, string custType)
        {
            InitializeComponent();
            dispatchingOrderNumber = dONumber;
            dispatchingOrderID = dOID;
            customerID = custID;
            customerNumber = custNumber;
            customerType = custType;
            this.Text = "Select Product for " + dONumber;
        }

        /// <summary>
        /// Get product ID selected
        /// </summary>
        public int ProductIDSelected
        {
            get
            {
                return this.productIDSelected;
            }
        }

        /// <summary>
        /// Get status to show detail dispatching product
        /// </summary>
        public bool IsShowDetail
        {
            get
            {
                return this.isShowDetail;
            }
        }

        /// <summary>
        /// Check current customer selected is expiry date
        /// </summary>
        /// <returns>bool</returns>
        private void CheckCustomerIsExpityDate()
        {
            DataProcess<Customers> customerDA = new DataProcess<Customers>();
            this.txt_WM_ExperityDate.Visible = (bool)customerDA.Select(cus => cus.CustomerID == this.customerID).FirstOrDefault().CustomerByExpiryDate;
        }

        private void dlgDOSelectPallets_Load(object sender, EventArgs e)
        {
            ListCustomerByMainID();
            this.lookUpEditProductID.Focus();
            this.lookUpEditProductID.ShowPopup();
        }

        private void LoadERPPackage(int productID)
        {
            DataProcess<ProductPackage> customerDA = new DataProcess<ProductPackage>();
            lkeERPPackage.Properties.DataSource = customerDA.Select(p => p.ProductID == productID).ToList();
            lkeERPPackage.Properties.DisplayMember = "ERP";
            lkeERPPackage.Properties.ValueMember = "ProductPackageID";
        }
        private void ListCustomerByMainID()
        {
            try
            {
                int mainCustomerID = (int)AppSetting.CustomerList.Where(c => c.CustomerID == this.customerID).FirstOrDefault().CustomerMainID;
                lookUpEditCustomerMainID.Properties.DataSource = AppSetting.CustomerList.Where(c => c.CustomerMainID == mainCustomerID && c.CustomerDiscontinued == false).ToList();
                lookUpEditCustomerMainID.EditValue = customerID;
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
            }
        }

        private void lookUpEditCustomerMainID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                InitLookupProducts();
                this.lookUpEditProductID.Focus();
                this.lookUpEditProductID.ShowPopup();
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);

                textEditProductName.Text = "";
            }
        }

        private void LoadData()
        {
            try
            {
                int proID = Convert.ToInt32(lookUpEditProductID.EditValue);
                DataProcess<STDispatchingProductNewListRO_Result> dpc = new DataProcess<STDispatchingProductNewListRO_Result>();
                if (this.txt_WM_ExperityDate.Visible)
                {
                    gridControlProduct.DataSource = dpc.Executing("STDispatchingProductNewListRO @Flag={0},@varProductID={1},@FlagSort={2}", 1, proID, 1);
                }
                else
                {
                    gridControlProduct.DataSource = dpc.Executing("STDispatchingProductNewListRO @Flag={0},@varProductID={1},@FlagSort={2}", 0, proID, 0).ToList();
                }
                if (Convert.ToBoolean(this.checkShowSelfLife.EditValue))
                {
                    gridControlProduct.DataSource = FileProcess.LoadTable("STDispatchingProductNewListRO 1, " + proID + ", 5");
                }

                this.gridViewProduct.ClearSelection();
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);

                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridViewProduct_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            var item = e.Item as GridColumnSummaryItem;
            if (item != null && item.FieldName == "DOQty")
            {
                if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                    e.TotalValue = _selectedSum;
            }

            if (item != null && item.FieldName == "Location")
            {
                if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                    e.TotalValue = _selectedCount;
            }
            this.btn_WM_Accept.Enabled = (_selectedSum > 0);
        }

        private void gridViewProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            gridViewProduct.UpdateTotalSummary();
        }

        private void gridViewProduct_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            _selectedSum = 0;
            _selectedCount = 0;
            var column = gridViewProduct.Columns[_fieldName];
            foreach (var rowHandle in gridViewProduct.GetSelectedRows())
            {
                _selectedSum += (int)gridViewProduct.GetRowCellValue(rowHandle, column);
                _selectedCount += 1;
            }
            gridViewProduct.UpdateTotalSummary();
        }

        private void textEditOptionText_EditValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void gridViewProduct_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            try
            {
                if (e.Value != null && gridViewProduct.FocusedColumn.FieldName == "DOQty")
                {
                    Int32 dOQty = Convert.ToInt32(e.Value);
                    Int32 qty = Convert.ToInt32(gridViewProduct.GetFocusedRowCellValue(gridViewProduct.Columns["Qty"]));

                    if (dOQty < 0)
                    {
                        gridViewProduct.SetFocusedRowCellValue(gridViewProduct.Columns["DOQty"], 0);
                        gridViewProduct.PostEditor();
                        gridViewProduct.UpdateSummary();
                    }
                    else
                    {
                        if (dOQty > qty)
                        {
                            gridViewProduct.SetFocusedRowCellValue(gridViewProduct.Columns["DOQty"], qty);
                            gridViewProduct.PostEditor();
                            gridViewProduct.UpdateSummary();
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

        private void InitLookupProducts(bool isUpdateList = false)
        {
            try
            {
                int custID = Convert.ToInt32(lookUpEditCustomerMainID.EditValue);
                DataProcess<STComboProductIDDO_Result> pc = new DataProcess<STComboProductIDDO_Result>();

                if (isUpdateList)
                {
                    pc.ExecuteNoQuery("STtmpProductRemainUpdate @varCustomerID = {0}", custID);
                }
                this.productList = pc.Executing("STComboProductIDDO @CustomerID = {0}, @SortProduct = {1}", custID, 0).ToList();
                lookUpEditProductID.Properties.DataSource = this.productList;
                if (this.productList == null || this.productList.Count <= 0) return;
                if (this.productList.Count >= 20)
                {
                    lookUpEditProductID.Properties.DropDownRows = 20;
                }
                else
                {
                    lookUpEditProductID.Properties.DropDownRows = this.productList.Count;
                }

                lookUpEditProductID.EditValue = this.productList[0].tmpProductRemainID;

            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
            }
        }

        private void btn_WM_Accept_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridViewProduct.SelectedRowsCount <= 0)
                {
                    this.gridViewProduct.SelectAll();
                }

                if (this.spinEditQty.Value <= 0)
                {
                    XtraMessageBox.Show("ERROR: Quantity not correct!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int quantitySelected = 0;
                StringBuilder roIDlist = new StringBuilder();
                roIDlist.Append("(");
                int count = 0;
                foreach (int i in gridViewProduct.GetSelectedRows())
                {
                    var stDispatchingSelected = (STDispatchingProductNewListRO_Result)gridViewProduct.GetRow(i);
                    quantitySelected += (int)stDispatchingSelected.Quantity;
                    roIDlist.Append(stDispatchingSelected.ReceivingOrderDetailID);
                    if (count < gridViewProduct.GetSelectedRows().Count() - 1)
                    {
                        roIDlist.Append(",");
                        count++;
                    }
                }
                roIDlist.Append(")");

                // Check limited range
                if (this.spinEditQty.Value <= 0 && this.spinEditQty.Value > 3200)
                {
                    //"ERROR: Total of Packages must be greater than 0 and less than 32,000." & Chr(13) & " Please re-enter", vbCritical, "WMS-2022"
                    MessageBox.Show("ERROR: Total of Packages must be greater than 0 and less than 32,000.\n Please re-enter", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check quantity export
                if (this.spinEditQty.Value > quantitySelected)
                {
                    MessageBox.Show("ERROR: There are " + quantitySelected + " package(s).\n Not enough package(s) of this product to dispatch " + this.spinEditQty.Value + " package(s).", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.spinEditQty.Focus();
                    this.spinEditQty.SelectAll();
                    this.spinEditQty.Value = quantitySelected;
                    return;
                }

                // Get package and pcs 
                int proID = Convert.ToInt32(this.lookUpEditProductID.EditValue);
                var currentPro = AppSetting.ProductList.Where(p => p.ProductID == proID).FirstOrDefault();

                DataProcess<object> dpc = new DataProcess<object>();
                string condition = "True";
                if (!this.txt_WM_ExperityDate.Visible)
                {
                    condition = "False";
                }
                int qtyErp = Convert.ToInt32(this.spinEditQty.Value);
                if (lkeERPPackage.EditValue != null)
                {
                    var listErp = ((List<ProductPackage>)(this.lkeERPPackage.Properties.DataSource)).OrderBy(erp => erp.Levels);
                    int productPackSelected = Convert.ToInt32(this.lkeERPPackage.EditValue);
                    var currentLevel = listErp.Where(erp => erp.ProductPackageID == productPackSelected).FirstOrDefault();
                    qtyErp = 1;
                    foreach (var item in listErp)
                    {
                        if (currentLevel.Levels <=Convert.ToInt32(item.Levels))
                        {
                            qtyErp = qtyErp * Convert.ToInt32(item.HS);
                        }
                    }
                    qtyErp = qtyErp * Convert.ToInt32(this.spinEditQty.EditValue);

                }
                if (customerType == CustomerTypeEnum.RANDOM_WEIGHT)
                {
                    dpc.ExecuteNoQuery("STDispatchingProductInsertRandomWeight " +
                    " @varDispatchingOrderID={0}," +
                    " @varProductID={1}," +
                    " @varTotalQuantity={2}," +
                    " @varWeightPerPackage={3}," +
                    " @varDispatchingOrderNumer={4}," +
                    " @varCondition={5}," +
                    " @DispatchingMethod={6}," +
                    " @DispatchingProductRemark={7}," +
                    " @DispatchingProductReference={8}," +
                    " @UserID={9}," +
                    " @varPackages={10}," +
                    " @varPcs={11}",
                    dispatchingOrderID,
                    this.lookUpEditProductID.EditValue,
                    qtyErp,
                    this.spinEditWeightPerPackage.Value,
                    dispatchingOrderNumber,
                    roIDlist.ToString(),
                    condition,
                    string.Empty,
                    string.Empty,
                    AppSetting.CurrentUser.LoginName, currentPro.Packages, currentPro.Pcs);
                }
                else
                {

                    dpc.ExecuteNoQuery("STDispatchingProductInsert_New " +
                    " @varDispatchingOrderID={0}," +
                    " @varProductID={1}," +
                    " @varTotalQuantity={2}," +
                    " @varWeightPerPackage={3}," +
                    " @varDispatchingOrderNumer={4}," +
                    " @varCondition={5}," +
                    " @DispatchingMethod={6}," +
                    " @DispatchingProductRemark={7}," +
                    " @DispatchingProductReference={8}," +
                    " @UserID={9}," +
                    " @varPackages={10}," +
                    " @varPcs={11}",
                    dispatchingOrderID,
                    this.lookUpEditProductID.EditValue,
                    qtyErp,
                    this.spinEditWeightPerPackage.Value,
                    dispatchingOrderNumber,
                    roIDlist.ToString(),
                    condition,
                    string.Empty,
                    string.Empty,
                    AppSetting.CurrentUser.LoginName, currentPro.Packages, currentPro.Pcs);
                }
                this.isShowDetail = true;
                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);

                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_WM_Close_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btn_WM_SelectLocation_Click(object sender, EventArgs e)
        {
            if (this.lookUpEditProductID.EditValue == null) return;
            int productID = (Int32)this.lookUpEditProductID.EditValue;
            frm_WM_DispatchingLocationSelect selectLocation = new frm_WM_DispatchingLocationSelect(productID, this.customerType,
                this.dispatchingOrderID, this.spinEditWeightPerPackage.Value, this.dispatchingOrderNumber);
            if (!selectLocation.Enabled) return;
            selectLocation.ShowDialog();
            this.isShowDetail = selectLocation.IsShowDetail;
            if (!selectLocation.HasSelectedValue) return;
            this.Close();
        }

        private void btn_WM_UpdateList_Click(object sender, EventArgs e)
        {
            if ((int)(this.lookUpEditCustomerMainID.EditValue) == 0 || this.lookUpEditCustomerMainID.EditValue == null)
            {
                this.lookUpEditCustomerMainID.Focus();
                this.lookUpEditCustomerMainID.ShowPopup();
            }
            else
            {
                this.InitLookupProducts(true);
                this.lookUpEditProductID.ShowPopup();
            }

        }

        private void LoadProductData()
        {

            try
            {
                string productName = lookUpEditProductID.Properties.GetDataSourceValue("tmpProductRemainName", lookUpEditProductID.ItemIndex).ToString();
                decimal weightPerPackage = Convert.ToDecimal(lookUpEditProductID.Properties.GetDataSourceValue("tmpWeightPerPackage", lookUpEditProductID.ItemIndex));
                decimal totalPackage = Convert.ToDecimal(lookUpEditProductID.Properties.GetDataSourceValue("tmpRemainQuantity", lookUpEditProductID.ItemIndex));
                this.productIDSelected = Convert.ToInt32(lookUpEditProductID.Properties.GetDataSourceValue("tmpProductRemainID", lookUpEditProductID.ItemIndex));

                this.textEditProductName.Text = productName;
                this.spinEditWeightPerPackage.Value = weightPerPackage;
                this.spinEditQty.Value = totalPackage;
                LoadData();
                this.spinEditQty.Focus();
                this.spinEditQty.SelectAll();
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);

                textEditProductName.Text = "";
            }
        }

        private void lookUpEditProductID_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
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
            LoadERPPackage(Convert.ToInt32(e.Value));
            this.LoadProductData();
            //SendKeys.Send("{TAB}");
        }

        private void lookUpEditProductID_Click(object sender, EventArgs e)
        {
            this.lookUpEditProductID.Focus();
            this.lookUpEditProductID.SelectAll();
        }

        private void hideContainerRight_Click(object sender, EventArgs e)
        {

        }

        private void lookUpEditProductID_Validating(object sender, CancelEventArgs e)
        {
            this.acceptValue = true;
            LookUpEdit edit = sender as LookUpEdit;
            if (edit.AccessibilityObject.Value == null)
            {
                e.Cancel = true;
                edit.EditValue = 0;
                this.gridControlProduct.DataSource = null;
                this.acceptValue = false;
                this.spinEditQty.EditValue = 0;
                this.spinEditWeightPerPackage.EditValue = 0;
                this.textEditProductName.Text = string.Empty;
            }
            else
            {
                string remainNumber = edit.AccessibilityObject.Value;
                int checkOutSum = this.productList.Where(p => p.tmpProductRemainNumber.Equals(remainNumber)).Count();
                if (checkOutSum <= 0)
                {
                    e.Cancel = true;
                    edit.Text = edit.AccessibilityObject.Value;
                    this.acceptValue = false;
                    edit.EditValue = 0;
                    this.gridControlProduct.DataSource = null;
                    this.spinEditQty.EditValue = 0;
                    this.spinEditWeightPerPackage.EditValue = 0;
                    this.textEditProductName.Text = string.Empty;
                }
            }
        }

        private void btn_WM_CreatePlannedOrder_Click(object sender, EventArgs e)
        {
            DataProcess<object> dataProcess = new DataProcess<object>();
            dataProcess.ExecuteNoQuery("STDispatchingProductPlannedCreateNew @DispatchingOrderID={0},@ProductID={1},@PlannedTotalPackages={2},@PlannedTotalWeight={3},@DispatchingProductRemark={4},@UserID={5}",
                this.dispatchingOrderID, this.lookUpEditProductID.EditValue, this.txtPlannedTotalPackages.EditValue, this.txtPlannedTotalWeight.EditValue, this.txtRemark.Text, AppSetting.CurrentUser.LoginName);
            this.Close();
        }

        private void txtPlannedTotalPackages_EditValueChanged(object sender, EventArgs e)
        {
            if (this.lookUpEditProductID.EditValue == null) return;
            decimal weighPerPackage = this.spinEditWeightPerPackage.Value;
            decimal carton = Convert.ToDecimal(this.txtPlannedTotalPackages.Text);
            decimal totalSum = Math.Round(carton / weighPerPackage);
            if (totalSum.Equals(this.txtPlannedTotalWeight.EditValue)) return;
            this.txtPlannedTotalWeight.EditValue = Math.Round(carton / weighPerPackage);
            this.btn_WM_CreatePlannedOrder.Enabled = true;
        }

        private void txtPlannedTotalWeight_EditValueChanged(object sender, EventArgs e)
        {
            if (this.lookUpEditProductID.EditValue == null) return;
            decimal weighPerPackage = this.spinEditWeightPerPackage.Value;
            decimal weight = Convert.ToDecimal(this.txtPlannedTotalWeight.Text);
            decimal totalSum = weight * weighPerPackage;
            if (totalSum.Equals(this.txtPlannedTotalPackages.EditValue)) return;
            this.txtPlannedTotalPackages.EditValue = totalSum;
            this.btn_WM_CreatePlannedOrder.Enabled = true;
        }

        private void checkEdit1_Properties_CheckedChanged(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}