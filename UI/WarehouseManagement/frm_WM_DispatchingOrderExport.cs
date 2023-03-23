using Common.Controls;
using DA;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using UI.Helper;
using UI.MasterSystemSetup;
namespace UI.WarehouseManagement
{
    public partial class frm_WM_DispatchingOrderExport : frmBaseForm
    {
        int _DOID = -1;
        DateTime _DODate = DateTime.MinValue;
        int _CusID = -1;
        string _DORemark;
        int _ProductID;
        int _DODetailCount;
        int customerFind = 0;
        List<STComboProductID_Result> _ComboProduct = new List<STComboProductID_Result>();
        BindingList<ST_WMS_LoadDispatchingProductsExport_Result> bdListData = null;
        public frm_WM_DispatchingOrderExport()
        {
            InitializeComponent();
            lke_MSS_StoreList.Visible = false;
            LoadStore();
        }

        public frm_WM_DispatchingOrderExport(int DispatchingOrderID, DateTime DispatchingOrderDate, int CustomerID, string DispatchingOrderRemark, int DORecord)
        {
            InitializeComponent();
            _DOID = DispatchingOrderID;
            _DODate = DispatchingOrderDate;
            _CusID = CustomerID;
            this.customerFind = CustomerID;
            _DORemark = DispatchingOrderRemark;
            _DODetailCount = DORecord;
        }
        public bool HasExport { get; private set; }
        private void radgr_RO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radgr_RO.SelectedIndex == 1)
            {
                lci_ROList.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lk_RO.Visible = true;
            }
            else
            {
                lci_ROList.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                lk_RO.Visible = false;
            }
        }

        private void LoadStore()
        {
            DataProcess<Stores> storeDA = new DataProcess<Stores>();
            this.lke_MSS_StoreList.Properties.DataSource = storeDA.Select();
            this.lke_MSS_StoreList.Properties.ValueMember = "StoreID";
            this.lke_MSS_StoreList.Properties.DisplayMember = "StoreDescription";
            this.lke_MSS_StoreList.EditValue = AppSetting.CurrentUser.StoreID;
        }

        private void radgr_Customer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radgr_Customer.SelectedIndex == 1)
            {
                lci_CustomerList.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lk_Customer.Visible = true;
                lke_MSS_StoreList.Visible = true;
                btn_CreateProduct.Enabled = true;
                this._CusID = 0;
            }
            else
            {
                lci_CustomerList.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                lk_Customer.Visible = false;
                lke_MSS_StoreList.Visible = false;
                this._CusID = this.customerFind;
                LoadDO();
                btn_CreateProduct.Enabled = false;
            }
        }

        private void frm_WM_DispatchingOrderExport_Load(object sender, EventArgs e)
        {
            lke_MSS_StoreList.Visible = false;
            LoadStore();
            LoadDO();
            LoadComboboxCustomer();
            LoadComboboxRO();
            DataProcess<DispatchingOrders> process = new DataProcess<DispatchingOrders>();
            List<DispatchingOrders> result = process.Executing("Select * from DispatchingOrders where DispatchingOrderID ={0}", _DOID).ToList();
            if (result.Count > 0)
            {
                if (result[0].Status || _DODetailCount <= 1)
                {
                    lci_btnBreakDO.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    btn_BreakDO.Visible = false;
                }
                else
                {
                    lci_btnBreakDO.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    btn_BreakDO.Visible = true;
                }
            }
        }

        private void LoadDO()
        {
            if (_DOID > 0)
            {
                DataProcess<object> processobj = new DataProcess<object>();
                int a = processobj.ExecuteNoQuery("STDispatchingOrderExportCreateTemp @DispatchingOrderID={0}", _DOID);
                DataProcess<ST_WMS_LoadDispatchingProductsExport_Result> process = new DataProcess<ST_WMS_LoadDispatchingProductsExport_Result>();
                List<ST_WMS_LoadDispatchingProductsExport_Result> result = process.Executing("ST_WMS_LoadDispatchingProductsExport  @DispatchingOrderID=" + _DOID.ToString()).ToList();
                this.bdListData = new BindingList<ST_WMS_LoadDispatchingProductsExport_Result>(result);
                grd_Dsach.DataSource = this.bdListData;
                _ProductID = result[0].ProductID;
            }
        }

        private void LoadComboboxCustomer()
        {
            //DataProcess<STcomboCustomerID_Result> process = new DataProcess<STcomboCustomerID_Result>();
            //LookUpColumnInfo _cusID = new LookUpColumnInfo("CustomerID", "ID");
            //_cusID.Width = 10;
            //lk_Customer.Properties.Columns.Add(_cusID);
            //lk_Customer.Properties.Columns.Add(new LookUpColumnInfo("CustomerName", "Name"));
            lk_Customer.Properties.DataSource = FileProcess.LoadTable("STcomboCustomerID " + this.lke_MSS_StoreList.EditValue);
            lk_Customer.Properties.DisplayMember = "CustomerNumber";
            lk_Customer.Properties.ValueMember = "CustomerID";
        }

        private void LoadComboboxRO()
        {
            LookUpColumnInfo _roID = new LookUpColumnInfo("ReceivingOrderID", "ID");
            _roID.Width = 20;
            lk_RO.Properties.Columns.Add(_roID);
            LookUpColumnInfo _roDate = new LookUpColumnInfo("ReceivingOrderDate", "Date");
            _roDate.Width = 30;
            _roDate.FormatString = "dd/MM/yyyy";
            lk_RO.Properties.Columns.Add(_roDate);
            LookUpColumnInfo _roSR = new LookUpColumnInfo("SpecialRequirement", "Special Requirement");
            _roSR.Width = 80;
            lk_RO.Properties.Columns.Add(_roSR);
            DataProcess<ReceivingOrders> receivingOrderDA = new DataProcess<ReceivingOrders>();
            var lstRecevingExist = receivingOrderDA.Select(r => (r.ReceivingOrderDate >= _DODate && r.ReceivingOrderDate <= _DODate.AddDays(4)) && r.Status == false);
            lk_RO.Properties.DataSource = lstRecevingExist;
            lk_RO.Properties.DisplayMember = "ReceivingOrderID";
            lk_RO.Properties.ValueMember = "ReceivingOrderID";
            if (lstRecevingExist!=null && lstRecevingExist.Count() > 20)
            {
                lk_RO.Properties.DropDownRows = 20;
            }
            else
            {
                lk_RO.Properties.DropDownRows = lstRecevingExist.Count();
            }
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            int customerId = -1;
            byte framepalletallocation;
            if (radgr_Customer.SelectedIndex == 0)
            {
                customerId = _CusID;
            }
            else
            {
                customerId = Convert.ToInt32(lk_Customer.EditValue);
            }
            if (radgr_Location.SelectedIndex == 0)
                framepalletallocation = 1;
            else
                framepalletallocation = 2;
            DataProcess<object> process = new DataProcess<object>();
            int result;
            frm_WM_ReceivingOrders frmReceiving = null;
            if (radgr_RO.SelectedIndex == 0)
            {
                //Same RO
                result = process.ExecuteNoQuery("STDispatchingOrderExportProcess  @varDispatchingOrderID = {0}, @DispatchingOrderRemark = {1}, @varUser = {2}, @PalletAllocation={3},@CustomerID={4}",
                    _DOID, _DORemark, AppSetting.CurrentUser.LoginName, framepalletallocation, _CusID);
                frmReceiving = frm_WM_ReceivingOrders.Instance;
            }
            else
            {
                result = process.ExecuteNoQuery("STDispatchingOrderExportProcess  @varDispatchingOrderID = {0}, @DispatchingOrderRemark = {1}, @varUser = {2}, @PalletAllocation={3},@CustomerID={4},@existReceivingOrderID={5}",
                    _DOID, _DORemark, AppSetting.CurrentUser.LoginName, framepalletallocation, _CusID, Convert.ToInt32(lk_RO.EditValue));
                frmReceiving = frm_WM_ReceivingOrders.Instance;

            }
            this.Close();
            frmReceiving.WindowState = FormWindowState.Maximized;
            frmReceiving.BringToFront();
            frmReceiving.Show();
            HasExport = true;
        }

        private void btn_Labelling_Click(object sender, EventArgs e)
        {
            frm_WM_QualityCheckings frmcheck = new frm_WM_QualityCheckings();
            DataProcess<object> process = new DataProcess<object>();
            int result = process.ExecuteNoQuery("STQualityCheckingExportProcess @Flag={0}, @OrderID = {1}, @ReportDate={2}, @CreatedBy={3}", 2, _DOID, DateTime.Now, AppSetting.CurrentUser.LoginName);
            frmcheck.Show();
        }

        private void btn_CreateProduct_Click(object sender, EventArgs e)
        {
            frm_MSS_Products frmpro = frm_MSS_Products.Instance;
            frmpro.ProductIDLookup = _ProductID;
            frmpro.Show();
        }

        private void btn_BreakDO_Click(object sender, EventArgs e)
        {
            if (this.gv_DispatchingOrderResult.RowCount == _DODetailCount)
                MessageBox.Show("Can not break the Dispatching Order !");
            else
            {
                if (MessageBox.Show("Are you sure to break those (" + gv_DispatchingOrderResult.RowCount.ToString() + ") products into new Dispatching Order ?", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    DataProcess<DispatchingOrders> process = new DataProcess<DispatchingOrders>();
                    int result = process.ExecuteNoQuery("STDispatchingOrderBreak @DispatchingOrderID={0}", _DOID);
                    List<DispatchingOrders> listDO = process.Executing("Select top 1 * from DispatchingOrders Order By DispatchingOrderID DESC").ToList();
                    int doID = 0;
                    if (listDO.Count > 0) doID = listDO[0].DispatchingOrderID;
                    frm_WM_DispatchingOrders frm = frm_WM_DispatchingOrders.GetInstance(doID);
                    if (frm.Visible)
                    {
                        frm.ReloadData();
                    }
                    frm.Show();
                    this.Close();
                }
            }
        }

        private void lk_Customer_EditValueChanged(object sender, EventArgs e)
        {
            DataProcess<object> processobj = new DataProcess<object>();
            processobj.ExecuteNoQuery("UPDATE tmpDispatchingProductExport SET NewProductID = 75454, NewProductNumber = 'TES-XXXXXXXXXX', NewProductName = 'No Product - Hàng không su dung trong he thong' WHERE DispatchingOrderID ={0}", _DOID);
            DataProcess<STComboProductID_Result> process = new DataProcess<STComboProductID_Result>();
            int customerID = Convert.ToInt32(lk_Customer.EditValue);
            _ComboProduct = process.Executing("STComboProductID @CustomerID={0}", customerID).ToList();
            rpi_lke_NewProduct.DataSource = _ComboProduct;
            rpi_lke_NewProduct.DisplayMember = "Product";
            rpi_lke_NewProduct.ValueMember = "ProductID";
            this._CusID = customerID;
            for (int rowIndex = 0; rowIndex < this.gv_DispatchingOrderResult.RowCount; rowIndex++)
            {
                gv_DispatchingOrderResult.SetRowCellValue(rowIndex, gridC_NewProductID, "TES-XXXXXXXXXX");
                gv_DispatchingOrderResult.SetRowCellValue(rowIndex, gridC_NewProductName, "No Product - Hàng không su dung trong he thong");
            }
        }

        private void editproduct_EditValueChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.LookUpEdit editor = (sender as DevExpress.XtraEditors.LookUpEdit);
            if (_ComboProduct.Count > 0)
            {
                string proid = editor.EditValue.ToString();
                STComboProductID_Result item = _ComboProduct.Where(x => x.ProductID == Convert.ToInt32(proid)).ToList()[0];
                gv_DispatchingOrderResult.SetRowCellValue(gv_DispatchingOrderResult.FocusedRowHandle, gridC_NewProductID, item.ProductNumber);
                gv_DispatchingOrderResult.SetRowCellValue(gv_DispatchingOrderResult.FocusedRowHandle, gridC_NewProductName, item.Name);
                gv_DispatchingOrderResult.SetRowCellValue(gv_DispatchingOrderResult.FocusedRowHandle, gridC_NewWeightPerPackage, item.WeightPerPackage);
            }
        }

        private void rpi_lke_NewProduct_EditValueChanged(object sender, EventArgs e)
        {
            object productIDSelected = (sender as DevExpress.XtraEditors.LookUpEdit).EditValue;
            var productSelected = (STComboProductID_Result)this.rpi_lke_NewProduct.GetDataSourceRowByKeyValue(productIDSelected);
            if (productSelected == null)
            {
                return;
            }

            int id = Convert.ToInt32(gv_DispatchingOrderResult.GetFocusedRowCellValue("ID"));
            DataProcess<object> processobj = new DataProcess<object>();
            processobj.ExecuteNoQuery("UPDATE tmpDispatchingProductExport SET NewProductID = " + productSelected.ProductID
                + ", NewProductNumber = '" + productSelected.ProductNumber + "', NewProductName = N'" +
                productSelected.Name + "',NewWeightPerPackage=" + productSelected.WeightPerPackage + " WHERE ID ={0}", id);

            gv_DispatchingOrderResult.SetFocusedRowCellValue(gridC_NewProductID, productSelected.ProductNumber);
            gv_DispatchingOrderResult.SetFocusedRowCellValue(gridC_NewProductName, productSelected.Name);
            gv_DispatchingOrderResult.SetFocusedRowCellValue(gridC_NewWeightPerPackage, productSelected.WeightPerPackage);
            gv_DispatchingOrderResult.FocusedColumn = gridC_NewProduct;
        }

        private void lk_Customer_CustomDisplayText(object sender, CustomDisplayTextEventArgs e)
        {
            RepositoryItemLookUpEdit edit;
            if (sender is LookUpEdit)
                edit = (sender as LookUpEdit).Properties;
            else
                edit = sender as RepositoryItemLookUpEdit;
            if (edit != null)
            {
                STcomboCustomerID_Result view = edit.GetDataSourceRowByKeyValue(e.Value) as STcomboCustomerID_Result;
                if (view != null)
                {
                    e.DisplayText = view.CustomerNumber + "      " + view.CustomerName;
                }
            }
        }

        private void gv_DispatchingOrderResult_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (!this.gv_DispatchingOrderResult.FocusedColumn.FieldName.Equals("NewProductNumber")) return;
            this.gv_DispatchingOrderResult.FocusedColumn = this.gridC_NewProduct;
            this.gv_DispatchingOrderResult.ShowEditor();
        }

        private void gv_DispatchingOrderResult_ShownEditor(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            if (view.ActiveEditor is LookUpEdit)
            {
                ((LookUpEdit)view.ActiveEditor).ShowPopup();
                //throw new DevExpress.Utils.HideException();
            }
        }

        private void gv_DispatchingOrderResult_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.KeyCode.Equals(Keys.Delete)) return;
            if (this.gv_DispatchingOrderResult.SelectedRowsCount <= 0) return;
            DataProcess<object> process = new DataProcess<object>();
            foreach (var index in this.gv_DispatchingOrderResult.GetSelectedRows())
            {
                // Delete row in DB
                int doID = Convert.ToInt32(this.gv_DispatchingOrderResult.GetRowCellValue(index, "DispatchingOrderID"));
                int doProductID = Convert.ToInt32(this.gv_DispatchingOrderResult.GetRowCellValue(index, "DispatchingProductID"));
                int result = process.ExecuteNoQuery("Delete tmpDispatchingProductExport Where DispatchingOrderID=" + doID + " And DispatchingProductID =" + doProductID);
            }
            // Delete row on GUI
            this.gv_DispatchingOrderResult.DeleteSelectedRows();
        }

        private void lke_MSS_StoreList_EditValueChanged(object sender, EventArgs e)
        {
            LoadComboboxCustomer();
        }

        private void btn_ExportTrasfer_Click(object sender, EventArgs e)
        {
            int customerId = -1;            
            if (radgr_Customer.SelectedIndex == 0)
            {
                customerId = _CusID;
            }
            else
            {
                customerId = Convert.ToInt32(lk_Customer.EditValue);
            }
            //if (radgr_Location.SelectedIndex == 0)
            //    framepalletallocation = 1;
            //else
            //    framepalletallocation = 2;
            DataProcess<object> process = new DataProcess<object>();
            int result;
            frm_WM_ReceivingOrders frmReceiving = null;
            
            result = process.ExecuteNoQuery("STDispatchingOrderExportProductTransferProcess  @varDispatchingOrderID = {0}, @varUser = {1},@CustomerID={2}",
                _DOID, AppSetting.CurrentUser.LoginName, _CusID);
            frmReceiving = frm_WM_ReceivingOrders.Instance;
            
           
            this.Close();
            frmReceiving.WindowState = FormWindowState.Maximized;
            frmReceiving.BringToFront();
            frmReceiving.Show();
            HasExport = true;
        }
    }
}

