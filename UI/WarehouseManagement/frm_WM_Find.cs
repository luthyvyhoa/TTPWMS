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
using UI.Helper;
using UI.MasterSystemSetup;
using UI.StockTake;
using DevExpress.XtraEditors;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_Find : frmBaseForm
    {
        private urc_WM_FindCustomer _urcCustomer;
        private urc_WM_FindLocation _urcLocation;
        private urc_WM_FindProduct _urcProduct;
        private urc_WM_FindRO _urcReceive;
        private urc_WM_FindDO _urcDispatch;
        private urc_WM_FindMovement _urcMovement;
        private urc_WM_FindEmployee _urcEmployee;
        private urc_WM_FindPallet _urcPallet;
        private urc_WM_FindStock _urcStock;
        private int _pageIndex;

        public frm_WM_Find()
        {
            InitializeComponent();
            this.IsFixHeightScreen = false;
            this._urcCustomer = new urc_WM_FindCustomer();
            this._urcLocation = new urc_WM_FindLocation();
            this._urcProduct = new urc_WM_FindProduct();
            this._urcReceive = new urc_WM_FindRO();
            this._urcDispatch = new urc_WM_FindDO();
            this._urcProduct = new urc_WM_FindProduct();
            this._urcMovement = new urc_WM_FindMovement();
            this._urcEmployee = new urc_WM_FindEmployee();
            this._urcPallet = new urc_WM_FindPallet();
            this._urcStock = new urc_WM_FindStock();
            this._pageIndex = 1;
        }

        private void frm_WM_Find_Load(object sender, EventArgs e)
        {
            this.tabCustomers.Controls.Add(this._urcCustomer);
            SetEvents();
        }

        private void SetEvents()
        {
            this.tabControlFind.SelectedPageChanged += tabControlFind_SelectedPageChanged;
            this.btnFind.Click += btnFind_Click;
        }

        #region Events
        private void btnFind_Click(object sender, EventArgs e)
        {
            switch(_pageIndex)
            {
                case 1:
                    {
                        FindByCustomer();
                        break;
                    }
                case 2:
                    {
                        FindLocation();
                        break;
                    }
                case 3:
                    {
                        FindProduct();
                        break;
                    }
                case 4:
                    {
                        FindRO();
                        break;
                    }
                case 5:
                    {
                        FindDO();
                        break;
                    }
                case 6:
                    {
                        FindStockMovement();
                        break;
                    }
                case 7:
                    {
                        FindEmployee();
                        break;
                    }
                case 8:
                    {
                        FindPallet();
                        break;
                    }
                case 9:
                    {
                        FindStock();
                        break;
                    }
            }
        }

        private void tabControlFind_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            switch(e.Page.Name)
            {
                case "tabCustomers":
                    {
                        if(this.tabCustomers.Controls.Count <= 0)
                        {
                            this.tabCustomers.Controls.Add(this._urcCustomer);
                        }
                        this._pageIndex = 1;
                        break;
                    }
                case "tabLocations":
                    {
                        if(this.tabLocations.Controls.Count <= 0)
                        {
                            this.tabLocations.Controls.Add(this._urcLocation);
                        }
                        this._pageIndex = 2;
                        break;
                    }
                case "tabProducts":
                    {
                        if(this.tabProducts.Controls.Count <= 0)
                        {
                            this.tabProducts.Controls.Add(this._urcProduct);
                        }
                        this._pageIndex = 3;
                        break;
                    }
                case "tabReceive":
                    {
                        if(this.tabReceive.Controls.Count <= 0)
                        {
                            this.tabReceive.Controls.Add(this._urcReceive);
                        }
                        this._pageIndex = 4;
                        break;
                    }
                case "tabDispatch":
                    {
                        if (this.tabDispatch.Controls.Count <= 0)
                        {
                            this.tabDispatch.Controls.Add(this._urcDispatch);
                        }
                        this._pageIndex = 5;
                        break;
                    }
                case "tabMovement":
                    {
                        if(this.tabMovement.Controls.Count <= 0)
                        {
                            this.tabMovement.Controls.Add(this._urcMovement);
                        }
                        this._pageIndex = 6;
                        break;
                    }
                case "tabEmployees":
                    {
                        if (this.tabEmployees.Controls.Count <= 0)
                        {
                            this.tabEmployees.Controls.Add(this._urcEmployee);
                        }
                        this._pageIndex = 7;
                        break;
                    }
                case "tabPallets":
                    {
                        if (this.tabPallets.Controls.Count <= 0)
                        {
                            this.tabPallets.Controls.Add(this._urcPallet);
                        }
                        this._pageIndex = 8;
                        break;
                    }
                case "tabStock":
                    {
                        if (this.tabStock.Controls.Count <= 0)
                        {
                            this.tabStock.Controls.Add(this._urcStock);
                        }
                        this._pageIndex = 9;
                        break;
                    }
            }
        }
        #endregion

        #region Find methods
        private void FindByCustomer()
        {
            if(this._urcCustomer.SelectedCustomer.CustomerID <= 0)
            {
                return;
            }
            else
            {
                frm_MSS_Customers frm = MasterSystemSetup.frm_MSS_Customers.Instance;
                frm.CurrentCustomers = this._urcCustomer.SelectedCustomer;
                frm.WindowState = FormWindowState.Normal;
                frm.BringToFront();
                frm.Show();
            }
        }

        private void FindLocation()
        {
            int locationID = this._urcLocation.LocationID;

            if(locationID <= 0)
            {
                return;
            }
            else
            {
                frm_WM_Dialog_LocationDetail frm = new frm_WM_Dialog_LocationDetail(locationID, 3,false);
                frm.Show();
            }
        }

        private void FindProduct()
        {
            string filter = "";

            if (this._urcProduct.lkeCustomers.EditValue == null && String.IsNullOrEmpty(this._urcProduct.txtProductID.Text) && String.IsNullOrEmpty(this._urcProduct.txtProductName.Text))
            {
                XtraMessageBox.Show("Please enter condition to find !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(this._urcProduct.lkeCustomers.EditValue == null)
            {
                filter = filter + "CustomerID = " + this._urcProduct.txtProductID.Text;
            }

            if(!String.IsNullOrEmpty(this._urcProduct.txtProductID.Text))
            {
                filter = String.IsNullOrEmpty(filter) ? filter + "ProductNumber LIKE " + this._urcProduct.txtProductID.Text : filter + "AND ProductNumber LIKE " + this._urcProduct.txtProductID.Text;
            }

            if(!String.IsNullOrEmpty(this._urcProduct.txtProductName.Text))
            {
                filter = String.IsNullOrEmpty(filter) ? filter + "ProductName LIKE " + this._urcProduct.txtProductName.Text : filter + "And ProductName LIKE " + this._urcProduct.txtProductName.Text;
            }

            if(this._urcProduct.chkStockOnHand.Checked && !String.IsNullOrEmpty(this._urcProduct.txtProductID.Text))
            {
                frm_ST_StockOnHandOneCustomer frm = new frm_ST_StockOnHandOneCustomer(Convert.ToInt32(this._urcProduct.lkeCustomers.EditValue));
                frm.ProductID = Convert.ToInt32(this._urcProduct.txtProductID.Text);
                frm.Show();
                return;
            }
            
            if(this._urcProduct.chkNameOnHand.Checked && !String.IsNullOrEmpty(this._urcProduct.txtProductName.Text))
            {
                frm_ST_StockOnHandOneCustomer frm = new frm_ST_StockOnHandOneCustomer(Convert.ToInt32(this._urcProduct.lkeCustomers.EditValue));
                frm.ProductNameFilter = this._urcProduct.txtProductName.Text;
                frm.Show();
                return;
            }

            this._urcProduct.chkStockOnHand.Checked = false;
            this._urcProduct.chkNameOnHand.Checked = false;
            frm_MSS_Products frmProduct =  frm_MSS_Products.Instance;
            frmProduct.Show();
            
        }

        private void FindRO()
        {
            if(this._urcReceive.ReceivingOrderID <= 0)
            {
                if (this._urcReceive.CustomerID <= 0)
                {

                }
                else
                {

                }
            }
            else
            {
                frm_WM_ReceivingOrders.Instance.ReceivingOrderIDFind = this._urcReceive.ReceivingOrderID;
                frm_WM_ReceivingOrders.Instance.Show();
            }
        }

        private void FindDO()
        {
            if(this._urcDispatch.IsEDI)
            {
                frm_WM_EDIOrders frmEDI = new frm_WM_EDIOrders();
                frmEDI.Show();
                return;
            }

            if(this._urcDispatch.DispatchingOrderID <= 0)
            {
                if (this._urcDispatch.CustomerID <= 0)
                {

                }
                else
                {

                }
            }
            else
            {
                var frmDispatching = frm_WM_DispatchingOrders.GetInstance(this._urcDispatch.DispatchingOrderID);
                if (frmDispatching.Visible)
                {
                    frmDispatching.ReloadData();
                }
                frmDispatching.Show();
            }

        }

        private void FindStockMovement()
        {

        }

        private void FindEmployee()
        {
            this._urcEmployee.Find();
        }

        private void FindPallet()
        {
            this._urcPallet.Find();
        }

        private void FindStock()
        {
            this._urcStock.Find();
        }
        #endregion
    }
}
