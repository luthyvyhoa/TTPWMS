using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Controls;
using DA;
using UI.ReportForm;
using UI.MasterSystemSetup;
using UI.WarehouseManagement;
using DevExpress.XtraEditors;

namespace UI.Helper
{
    public partial class frmSearchResult : frmBaseForm
    {
        private DataProcess<STSearchAllDatabase_Result> _searchDA = new DataProcess<STSearchAllDatabase_Result>();
        private string _condition;
        private int _moreFlag;
        private bool _isModified;
        private static frmSearchResult _instance;
        private frm_WM_TripsManagement frmTripDetail = new frm_WM_TripsManagement(0);

        public string Condition
        {
            get
            {
                return _condition;
            }
            set
            {
                _condition = value;
                this._isModified = true;
                this.LoadSearchData();
            }
        }

        public static frmSearchResult Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new frmSearchResult();
                }
                return _instance;
            }
        }

        private frmSearchResult()
        {
            InitializeComponent();
            this.IsFixHeightScreen = false;
            this._searchDA = new DataProcess<STSearchAllDatabase_Result>();
            this._moreFlag = 0;
            this._isModified = true;
        }

        private void frmSearchResult_Load(object sender, EventArgs e)
        {
            SetEvents();
        }

        private void SetEvents()
        {
        }

        private void LoadSearchData()
        {
            if (this._isModified)
            {
                this.grdSearchResult.DataSource = this._searchDA.Executing("STSearchAllDatabase @SearchString ={0},@varStoreID={1}", this._condition, AppSetting.StoreID);
                this._isModified = false;
            }
        }

        #region Events
        private void rpi_btn_More_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (this._moreFlag == 0)
            {
                string code = this.grvSearchResult.GetFocusedRowCellValue("OperationCode").ToString();
                this.grdSearchResult.DataSource = this._searchDA.Executing("STSearchAllDatabase @SearchString = {0}, @OperationCode = {1}", this._condition, code);
                this._moreFlag = 1;
            }
            else
            {
                LoadSearchData();
            }
        }

        private void rpi_btn_OpenReference_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string code = this.grvSearchResult.GetFocusedRowCellValue("OperationCode").ToString();

            switch (code)
            {
                case "RO": //Receiving Order
                    {
                        int roID = Convert.ToInt32(this.grvSearchResult.GetFocusedRowCellValue("ReferenceID"));
                        frm_WM_ReceivingOrders.Instance.ReceivingOrderIDFind = roID;
                        frm_WM_ReceivingOrders.Instance.Show();
                        break;
                    }
                case "DO": //Dispatching Order
                    {
                        int doID = Convert.ToInt32(this.grvSearchResult.GetFocusedRowCellValue("ReferenceID"));
                        var frmDispatching = frm_WM_DispatchingOrders.GetInstance(doID);
                        if (frmDispatching.Visible)
                        {
                            frmDispatching.ReloadData();
                        }
                        frmDispatching.Show();
                        break;
                    }
                case "PD": //Warning
                    {
                        break;
                    }
                case "LO": //Location
                    {
                        int palletID = Convert.ToInt32(this.grvSearchResult.GetFocusedRowCellValue("ReferenceID"));
                        frm_WM_Dialog_LocationDetail frmLocationDetail = new frm_WM_Dialog_LocationDetail(palletID, 3,false);
                        frmLocationDetail.Show();
                        break;
                    }
                case "EM": //Employee
                    {
                        int employeeID = Convert.ToInt32(this.grvSearchResult.GetFocusedRowCellValue("ReferenceID"));
                        frm_MSS_Employees frmEmployee = new frm_MSS_Employees(employeeID);
                        frmEmployee.Show();
                        break;
                    }
                case "CU": //Customer
                    {
                        Customers customer = AppSetting.CustomerList.Where(c => c.CustomerID == Convert.ToInt32(this.grvSearchResult.GetFocusedRowCellValue("ReferenceID"))).FirstOrDefault();
                        frm_MSS_Customers frmCustomer = MasterSystemSetup.frm_MSS_Customers.Instance;
                        frmCustomer.CurrentCustomers = customer;
                        frmCustomer.WindowState = FormWindowState.Normal;
                        frmCustomer.BringToFront();
                        frmCustomer.Show();
                        break;
                    }
                case "PA": //PalletID
                    {
                        int palletID = Convert.ToInt32(this.grvSearchResult.GetFocusedRowCellValue("ReferenceID"));
                        frm_WM_Dialog_LocationDetail frmLocationDetail = new frm_WM_Dialog_LocationDetail(palletID, 0,true);
                        frmLocationDetail.Show();
                        break;
                    }
                case "ART": //ProductID
                    {
                        int productID = Convert.ToInt32(this.grvSearchResult.GetFocusedRowCellValue("ReferenceID"));
                        frm_MSS_Products frmProduct = frm_MSS_Products.Instance;
                        frmProduct.ProductIDLookup = productID;
                        frmProduct.Show();
                        break;
                    }
                case "PR": //Product
                    {
                        int productID = Convert.ToInt32(this.grvSearchResult.GetFocusedRowCellValue("ReferenceID"));
                        frm_MSS_Products frmProduct = frm_MSS_Products.Instance;
                        frmProduct.ProductIDLookup = productID;
                        frmProduct.Show();
                        break;
                    }
                case "OS": //Other service
                    {
                        int serviceID = Convert.ToInt32(this.grvSearchResult.GetFocusedRowCellValue("ReferenceID"));
                        frm_BR_OtherServices frm = new frm_BR_OtherServices();
                        frm.OtherServiceIDFind = serviceID;
                        frm.Show();
                        break;
                    }
                default:
                    {
                        XtraMessageBox.Show("Wrong Operation Code !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
            }
        }
        #endregion

        private void frmSearchResult_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void frmSearchResult_Shown(object sender, EventArgs e)
        {
        }

        private void frmSearchResult_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                LoadSearchData();
            }
        }

        private void rhl_OpenReference_Click(object sender, EventArgs e)
        {
            string code = this.grvSearchResult.GetFocusedRowCellValue("OperationCode").ToString();

            switch (code)
            {
                case "RO": //Receiving Order
                    {
                        int roID = Convert.ToInt32(this.grvSearchResult.GetFocusedRowCellValue("ReferenceID"));
                        frm_WM_ReceivingOrders.Instance.ReceivingOrderIDFind = roID;
                        frm_WM_ReceivingOrders.Instance.Show();
                        break;
                    }
                case "DO": //Dispatching Order
                    {
                        int doID = Convert.ToInt32(this.grvSearchResult.GetFocusedRowCellValue("ReferenceID"));
                        var frmDispatching = frm_WM_DispatchingOrders.GetInstance(doID);
                        if (frmDispatching.Visible)
                        {
                            frmDispatching.ReloadData();
                        }
                        frmDispatching.Show();
                        break;
                    }
                case "PD": //Warning
                    {
                        break;
                    }
                case "LO": //Location
                    {
                        int palletID = Convert.ToInt32(this.grvSearchResult.GetFocusedRowCellValue("ReferenceID"));
                        frm_WM_Dialog_LocationDetail frmLocationDetail = new frm_WM_Dialog_LocationDetail(palletID, 3,false);
                        frmLocationDetail.Show();
                        break;
                    }
                case "EM": //Employee
                    {
                        int employeeID = Convert.ToInt32(this.grvSearchResult.GetFocusedRowCellValue("ReferenceID"));
                        frm_MSS_Employees frmEmployee = new frm_MSS_Employees(employeeID);
                        frmEmployee.Show();
                        break;
                    }
                case "CU": //Customer
                    {
                        Customers customer = AppSetting.CustomerList.Where(c => c.CustomerID == Convert.ToInt32(this.grvSearchResult.GetFocusedRowCellValue("ReferenceID"))).FirstOrDefault();
                        frm_MSS_Customers frmCustomer = MasterSystemSetup.frm_MSS_Customers.Instance;
                        frmCustomer.CurrentCustomers = customer;
                        frmCustomer.WindowState = FormWindowState.Normal;
                        frmCustomer.BringToFront();
                        frmCustomer.Show();
                        break;
                    }
                case "PA": //PalletID
                    {
                        int palletID = Convert.ToInt32(this.grvSearchResult.GetFocusedRowCellValue("ReferenceID"));
                        frm_WM_Dialog_LocationDetail frmLocationDetail = new frm_WM_Dialog_LocationDetail(palletID, 0,true);
                        frmLocationDetail.Show();
                        break;
                    }
                case "ART": //ProductID
                    {
                        int productID = Convert.ToInt32(this.grvSearchResult.GetFocusedRowCellValue("ReferenceID"));
                        frm_MSS_Products frmProduct = frm_MSS_Products.Instance;
                        frmProduct.ProductIDLookup = productID;
                        frmProduct.Show();
                        break;
                    }
                case "PR": //Product
                    {
                        int productID = Convert.ToInt32(this.grvSearchResult.GetFocusedRowCellValue("ReferenceID"));
                        frm_MSS_Products frmProduct = frm_MSS_Products.Instance;
                        frmProduct.ProductIDLookup = productID;
                        frmProduct.Show();
                        break;
                    }
                case "OS": //Other service
                    {
                        int serviceID = Convert.ToInt32(this.grvSearchResult.GetFocusedRowCellValue("ReferenceID"));
                        frm_BR_OtherServices frm = new frm_BR_OtherServices();
                        frm.OtherServiceIDFind = serviceID;
                        frm.Show();
                        break;
                    }
                case "TW": //Other service
                    {
                        int tripID = Convert.ToInt32(this.grvSearchResult.GetFocusedRowCellValue("ReferenceID"));
                        this.frmTripDetail.ReloadData(tripID);
                        this.frmTripDetail.Show();
                        this.frmTripDetail.TopLevel = true;
                        this.frmTripDetail.WindowState = FormWindowState.Normal;
                        this.frmTripDetail.BringToFront();
                        this.frmTripDetail.Focus();
                        break;
                    }
                default:
                    {
                        XtraMessageBox.Show("Wrong Operation Code !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
            }
        }

        private void rhl_More_Click(object sender, EventArgs e)
        {
            if (this._moreFlag == 0)
            {
                string code = this.grvSearchResult.GetFocusedRowCellValue("OperationCode").ToString();
                this.grdSearchResult.DataSource = this._searchDA.Executing("STSearchAllDatabase @SearchString = {0}, @OperationCode = {1}", this._condition, code);
                this._moreFlag = 1;
            }
            else
            {
                LoadSearchData();
            }
        }
    }
}
