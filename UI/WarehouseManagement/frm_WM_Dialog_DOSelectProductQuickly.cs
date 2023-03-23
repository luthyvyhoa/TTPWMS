using Common.Controls;
using DA;
using DA.Master;
using DevExpress.Data;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using UI.Helper;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_Dialog_DOSelectProductQuickly : frmBaseForm
    {
        // Declare log
        private static readonly ILog log = LogManager.GetLogger(typeof(frm_WM_Dialog_DOSelectProductQuickly));
        private int _selectedSum;
        private int _selectedCount;
        private string _fieldName = "DOQty";
        int customerID = 0;
        string customerNumber = "";
        string dispatchingOrderNumber = "";
        Int32 dispatchingOrderID = 0;
        BindingList<WMSDOSelectProductQuickly> listProduct = new BindingList<WMSDOSelectProductQuickly>();

        public frm_WM_Dialog_DOSelectProductQuickly()
        {
            InitializeComponent();
        }

        public frm_WM_Dialog_DOSelectProductQuickly(string dONumber, Int32 dOID, int custID, string custNumber)
        {
            InitializeComponent();
            dispatchingOrderNumber = dONumber;
            dispatchingOrderID = dOID;
            customerID = custID;
            customerNumber = custNumber;
            textEditDispatchingOrderNumber.Text = dispatchingOrderNumber;
            textEditCustomerNumber.Text = customerNumber;
        }

        private void dlgDOSelectProductQuickly_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            var column = gridViewProduct.Columns[_fieldName];
            column.SummaryItem.SummaryType = SummaryItemType.Custom;
            ListCustomerByMainID();
            LoadData();
        }

        private void ListCustomerByMainID()
        {
            try
            {
                DataProcess<STVSCustomerListByMainID_Result> cc = new DataProcess<STVSCustomerListByMainID_Result>();
                var currentCustomer = AppSetting.CustomerList.Where(c => c.CustomerID == customerID).FirstOrDefault();
                List<STVSCustomerListByMainID_Result> listCustomers = cc.Executing("STVSCustomerListByMainID @CustomerMainID = {0}, @CustomerDiscontinued = {1}", currentCustomer.CustomerMainID, 0).ToList();
                lookUpEditCustomerMainID.Properties.DataSource = listCustomers;
                lookUpEditCustomerMainID.EditValue = customerID;
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
            }
        }


        private void LoadData()
        {
            try
            {
                if (textEditOptionText.Text.ToString() != "")
                {
                    LoadDataFilter();
                }
                else
                {
                    int custID = Convert.ToInt32(lookUpEditCustomerMainID.EditValue);
                    DataProcess<STDispatchingProductNewAllListProducts_Result> dpc = new DataProcess<STDispatchingProductNewAllListProducts_Result>();
                    listProduct.Clear();

                    List<STDispatchingProductNewAllListProducts_Result> lst = dpc.Executing("STDispatchingProductNewAllListProducts @varCustomerID = {0}", custID).ToList();
                    WMSDOSelectProductQuickly productSelected = new WMSDOSelectProductQuickly();
                    foreach (STDispatchingProductNewAllListProducts_Result productNew in lst)
                    {
                        productSelected = new WMSDOSelectProductQuickly();
                        productSelected.ProductID = productNew.ProductID;
                        productSelected.ProductNumber = productNew.ProductNumber;
                        productSelected.ProductName = productNew.ProductName;
                        productSelected.CustomerRef = productNew.CustomerRef;
                        productSelected.Qty = (short)productNew.Qty;
                        productSelected.DOQty = (int)productNew.Qty;
                        productSelected.WeightPerPackage = productNew.WeightPerPackage;
                        productSelected.PackagesPerPallet = productNew.PackagesPerPallet;
                        productSelected.ReceivingOrderDetailID = 0;
                        productSelected.ReceivingOrderNumber = productNew.ReceivingOrderNumber;
                        productSelected.ReceivingOrderDate = productNew.ReceivingOrderDate;
                        productSelected.SpecialRequirement = productNew.SpecialRequirement;
                        productSelected.PalletStatus = productNew.PalletStatus;
                        productSelected.Remark = productNew.Remark;
                        productSelected.OnHold = productNew.OnHold;
                        productSelected.ProductionDate = productNew.ProductionDate;
                        productSelected.UseByDate = productNew.UseByDate;
                        productSelected.PalletStatusDescription = productNew.PalletStatusDescription;
                        productSelected.Plts = productNew.Plts;
                        productSelected.Packages = productNew.Packages;
                        productSelected.Pcs = productNew.Pcs;

                        listProduct.Add(productSelected);
                    }
                    gridControlProduct.DataSource = listProduct;
                }
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);

                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDataFilter()
        {
            try
            {
                DataProcess<STDispatchingProductNewAllFilter_Result> rc = new DataProcess<STDispatchingProductNewAllFilter_Result>();
                listProduct.Clear();

                List<STDispatchingProductNewAllFilter_Result> lst = rc.Executing("STDispatchingProductNewAllFilter @varCustomerID = {0}, @FilterCriteria = {1}", Convert.ToInt32(lookUpEditCustomerMainID.EditValue), textEditOptionText.Text.Trim()).ToList();
                WMSDOSelectProductQuickly o = new WMSDOSelectProductQuickly();
                foreach (STDispatchingProductNewAllFilter_Result x in lst)
                {
                    o = new WMSDOSelectProductQuickly();
                    o.ProductID = x.ProductID;
                    o.ProductNumber = x.ProductNumber;
                    o.ProductName = x.ProductName;
                    o.CustomerRef = x.CustomerRef;
                    o.Qty = (short)x.Qty;
                    o.DOQty = (int)x.Qty;
                    o.WeightPerPackage = x.WeightPerPackage;
                    o.PackagesPerPallet = x.PackagesPerPallet;
                    o.ReceivingOrderDetailID = x.ReceivingOrderDetailID;

                    listProduct.Add(o);
                }
                gridControlProduct.DataSource = listProduct;
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

            if (item != null && item.FieldName == "ProductName")
            {
                if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                    e.TotalValue = _selectedCount;
            }
            this.btn_WM_OK.Enabled = (_selectedSum > 0);
        }

        private void gridViewProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var column = gridViewProduct.Columns[_fieldName];

            switch (e.Action)
            {
                case CollectionChangeAction.Add:
                    _selectedSum += (int)gridViewProduct.GetRowCellValue(e.ControllerRow, column);
                    _selectedCount += 1;
                    break;
                case CollectionChangeAction.Remove:
                    _selectedSum -= (int)gridViewProduct.GetRowCellValue(e.ControllerRow, column);
                    _selectedCount -= 1;
                    break;
                case CollectionChangeAction.Refresh:

                    _selectedSum = 0;
                    _selectedCount = 0;

                    foreach (var rowHandle in gridViewProduct.GetSelectedRows())
                    {
                        _selectedSum += (int)gridViewProduct.GetRowCellValue(rowHandle, column);
                        _selectedCount += 1;
                    }

                    break;
            }

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
            switch (e.Column.FieldName)
            {
                case "DOQty":
                    this.listProduct[e.RowHandle].DOQty = Convert.ToInt32(e.Value);
                    break;
            }
        }

        private void comboBoxEditOptionSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxEditOptionSelect.EditValue.ToString())
            {
                case "Auto Select Pallets By Reference":
                    LoadData();
                    break;
                default:
                    LoadData();
                    break;
            }
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

        private void btn_WM_OK_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridViewProduct.SelectedRowsCount <= 0)
                {
                    DialogResult = DialogResult.Cancel;
                    this.Close();
                }

                WMSDOSelectProductQuickly pr;
                DispatchingProductsDA dpc = new DispatchingProductsDA();
                int proID = 0;
                foreach (int rowIndex in this.gridViewProduct.GetSelectedRows())
                {
                    proID = Convert.ToInt32(this.gridViewProduct.GetRowCellValue(rowIndex, "ProductID"));
                    pr = listProduct.Where(p=>p.ProductID==proID).FirstOrDefault();
                    if (pr.ReceivingOrderDetailID > 0)
                    {
                        dpc.STDispatchingProductInsert1RODetails(dispatchingOrderID, (int)pr.ProductID, pr.DOQty, pr.ProductNumber, pr.ProductName, (float)pr.WeightPerPackage, dispatchingOrderNumber, pr.ReceivingOrderDetailID, pr.CustomerRef, null, AppSetting.CurrentUser.LoginName);
                    }
                    else
                    {
                        dpc.STDispatchingProductInsert_New(dispatchingOrderID, (int)pr.ProductID, pr.DOQty, (float)pr.WeightPerPackage, dispatchingOrderNumber, "NONEED", "False", null, null, AppSetting.CurrentUser.LoginName);
                    }
                }

                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
            }
        }

        private void btn_WM_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void gridControlProduct_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode.Equals(Keys.Delete))
            {
                // Check rows selected to deleted
                if (this.gridViewProduct.SelectedRowsCount <= 0) return;

                // Show message confirm
                DialogResult dl = MessageBox.Show("Are you about to delete " + this.gridViewProduct.SelectedRowsCount + " record(s)", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dl.Equals(DialogResult.Yes))
                {
                    WMSDOSelectProductQuickly pr;
                    foreach (int i in gridViewProduct.GetSelectedRows())
                    {
                        pr = (WMSDOSelectProductQuickly)gridViewProduct.GetRow(i);
                        this.listProduct.Remove(pr);
                    }
                }
            }
        }

        private void lookUpEditCustomerMainID_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            try
            {
                int custID = Convert.ToInt32(lookUpEditCustomerMainID.EditValue);
                string customerName = lookUpEditCustomerMainID.Properties.GetDataSourceValue("CustomerName", lookUpEditCustomerMainID.ItemIndex).ToString();
                textEditCustomerName.Text = customerName;
                LoadData();
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);

                textEditCustomerName.Text = "";
            }
        }

        private void gridViewProduct_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle < 0) return;
            bool rowChecked = Convert.ToBoolean(this.gridViewProduct.GetRowCellValue(e.RowHandle, "Checked"));
            if (rowChecked)
            {
                e.Appearance.BackColor = Color.LightBlue;
            }

            if (e.Column.FieldName.Equals("DOQty"))
            {
                e.Appearance.BackColor = Color.LightGoldenrodYellow;
            }
        }

        private void gridControlProduct_Click(object sender, EventArgs e)
        {

        }

        private void btn_SelectByPallets_Click(object sender, EventArgs e)
        {
            this.btn_SelectByPallets.Enabled = false;
            this.colLocationNumber.Visible = true;
            this.colPalletID.Visible = true;
            this.gridViewProduct.Columns["PalletID"].VisibleIndex = 3;
            this.gridViewProduct.Columns["LocationNumber"].VisibleIndex = 4;

            DataProcess<STDispatchingProductNewAllListProductByPallet_Result> allProductDA = new DataProcess<STDispatchingProductNewAllListProductByPallet_Result>();
            var lst = allProductDA.Executing("STDispatchingProductNewAllListProductByPallet @varCustomerID={0}", this.customerID);
            WMSDOSelectProductQuickly productSelected = new WMSDOSelectProductQuickly();
            foreach (STDispatchingProductNewAllListProductByPallet_Result productNew in lst)
            {
                productSelected = new WMSDOSelectProductQuickly();
                productSelected.ProductID = (int)productNew.ProductID;
                productSelected.ProductNumber = productNew.ProductNumber;
                productSelected.ProductName = productNew.ProductName;
                productSelected.CustomerRef = productNew.CustomerRef;
                productSelected.Qty = (short)productNew.Qty;
                productSelected.DOQty = (int)productNew.Qty;
                productSelected.WeightPerPackage = (decimal)productNew.WeightPerPackage;
                productSelected.PackagesPerPallet = (short)productNew.PackagesPerPallet;
                productSelected.ReceivingOrderDetailID = 0;
                productSelected.ReceivingOrderNumber = productNew.ReceivingOrderNumber;
                productSelected.ReceivingOrderDate = productNew.ReceivingOrderDate;
                productSelected.SpecialRequirement = productNew.SpecialRequirement;
                productSelected.PalletStatus = productNew.PalletStatus;
                productSelected.Remark = productNew.Remark;
                productSelected.OnHold = (bool)productNew.OnHold;
                productSelected.ProductionDate = productNew.ProductionDate;
                productSelected.UseByDate = productNew.UseByDate;
                productSelected.PalletStatusDescription = productNew.PalletStatusDescription;
                productSelected.Plts = (int)productNew.Plts;
                productSelected.PalletID = productNew.PalletID;
                productSelected.LocationNumber = productNew.LocationNumber;
                listProduct.Add(productSelected);
            }
            gridControlProduct.DataSource = listProduct;
        }
        private void LoadDataPallets()
        {
            try
            {
                if (textEditOptionText.Text.ToString() != "")
                {
                    LoadDataFilter();
                }
                else
                {
                    int custID = Convert.ToInt32(lookUpEditCustomerMainID.EditValue);
                    DataProcess<STDispatchingProductNewAllListProducts_Result> dpc = new DataProcess<STDispatchingProductNewAllListProducts_Result>();
                    listProduct.Clear();

                    List<STDispatchingProductNewAllListProducts_Result> lst = dpc.Executing("STDispatchingProductNewAllListProducts @varCustomerID = {0}", custID).ToList();
                    WMSDOSelectProductQuickly productSelected = new WMSDOSelectProductQuickly();
                    foreach (STDispatchingProductNewAllListProducts_Result productNew in lst)
                    {
                        productSelected = new WMSDOSelectProductQuickly();
                        productSelected.ProductID = productNew.ProductID;
                        productSelected.ProductNumber = productNew.ProductNumber;
                        productSelected.ProductName = productNew.ProductName;
                        productSelected.CustomerRef = productNew.CustomerRef;
                        productSelected.Qty = (short)productNew.Qty;
                        productSelected.DOQty = (int)productNew.Qty;
                        productSelected.WeightPerPackage = productNew.WeightPerPackage;
                        productSelected.PackagesPerPallet = productNew.PackagesPerPallet;
                        productSelected.ReceivingOrderDetailID = 0;
                        productSelected.ReceivingOrderNumber = productNew.ReceivingOrderNumber;
                        productSelected.ReceivingOrderDate = productNew.ReceivingOrderDate;
                        productSelected.SpecialRequirement = productNew.SpecialRequirement;
                        productSelected.PalletStatus = productNew.PalletStatus;
                        productSelected.Remark = productNew.Remark;
                        productSelected.OnHold = productNew.OnHold;
                        productSelected.ProductionDate = productNew.ProductionDate;
                        productSelected.UseByDate = productNew.UseByDate;
                        productSelected.PalletStatusDescription = productNew.PalletStatusDescription;
                        productSelected.Plts = productNew.Plts;


                        listProduct.Add(productSelected);
                    }
                    gridControlProduct.DataSource = listProduct;
                }
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);

                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            this.gridViewProduct.BeginDataUpdate();
            if (this.btnCheckAll.Text.Equals("All"))
            {
                this.listProduct.Select(p => { p.Checked = true; return p; }).ToList();
                this.btnCheckAll.Text = "Un-Check";
            }
            else
            {
                this.listProduct.Select(p => { p.Checked = false; return p; }).ToList();
                this.btnCheckAll.Text = "All";
            }
            this.gridViewProduct.EndDataUpdate();
        }
    }
}