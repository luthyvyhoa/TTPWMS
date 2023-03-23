using System.Windows.Forms;
using System;
using DA;
using System.Collections.Generic;
using Common.Process;
using System.Linq;
using UI.StockTake;
using UI.Helper;
using UI.MasterSystemSetup;
using log4net;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.Utils.Menu;
using System.Text;
using UI.Management;
using System.Data.Entity.Core.Objects;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_InOutViewByDate : UserControl
    {
        // Declare log
        private static readonly ILog log = LogManager.GetLogger(typeof(frm_WM_InOutViewByDate));

        /// <summary>
        /// Default load data by current user login
        /// </summary>
        private InOutViewCaseEnum loadCase = InOutViewCaseEnum.Me;

        // Declare instance 
        private static frm_WM_InOutViewByDate instance = null;

        private frm_WM_TripsManagement frmTrip = null;

        /// <summary>
        /// Definition current user doing select on RO
        /// </summary>
        private bool isRo = true;

        /// <summary>
        /// Set state is first load data
        /// </summary>
        private bool isFirstLoad = true;

        private bool isFindCustomer = false;
        private bool isShowRoAttachment = true;
        DXMenuItem containItemDO;
        DXMenuItem notContainItemDO;
        DXMenuItem containItemRO;
        DXMenuItem notContainItemRO;
        protected frm_WM_InOutViewByDate()
        {
            // Init control for designer
            this.InitializeComponent();
            //this.KeyPreview = true;
            // Set default value
            this.checkEditMain.Checked = true;
            this.checkEditMe.Checked = true;
            this.dateEditDateTo.EditValue = DateTime.Now;
            this.dateEditDateFrom.EditValue = DateTime.Now;

            // Load customer
            this.InitCustomer();

            // Load all Rooms
            this.LoadAllRooms();

            // Load all warehouses
            this.LoadWarehouseStore();

            // Load main data
            this.LoadRODO();

            // Set first load state is false
            this.isFirstLoad = false;

            containItemDO = new DXMenuItem();
            containItemDO.Click += ContainItemDO_Click;
            notContainItemDO = new DXMenuItem();
            notContainItemDO.Click += NotContainItemDO_Click;
            //RepositoryItemDateEdit dateEdit = new RepositoryItemDateEdit();
            containItemRO = new DXMenuItem();
            containItemRO.Click += ContainItemRO_Click;
            notContainItemRO = new DXMenuItem();
            notContainItemRO.Click += NotContainItemRO_Click;
            //RepositoryItemDateEdit dateEdit = new RepositoryItemDateEdit();
            grV_WM_ControlRO.ShownEditor += grv_WM_ControlRO_ShownEditor;
            grv_WM_ControlDO.ShownEditor += grv_WM_ControlDO_ShownEditor;
            //this.textEditCustomerName
        }

        /// <summary>
        /// Get InoutView instance form
        /// </summary>
        public static frm_WM_InOutViewByDate Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new frm_WM_InOutViewByDate();
                }

                return instance;
            }
        }

        private void LoadRODO()
        {
            Wait.Start(this);
            try
            {
                // Get date time
                string dateFrom = Convert.ToDateTime(dateEditDateFrom.EditValue).Date.ToString("yyyy-MM-dd");
                string dateTo = Convert.ToDateTime(dateEditDateTo.EditValue).Date.ToString("yyyy-MM-dd");

                // Get Customer ID
                int customerID = 0;

                // Set create wave picking menu is not visible
                this.mnu_btn_CreateWavePicking.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                //Detect state to load data
                switch (this.loadCase)
                {
                    // Get all data
                    case InOutViewCaseEnum.All:
                        grd_WM_ControlRO.DataSource = FileProcess.LoadTable("STInOutViewRO" + " @FromDate='" + dateFrom + "',@ToDate='" + dateTo + "', @varCustomerID=" + customerID + ",@varStoreID=" + AppSetting.StoreID);
                        grd_WM_ControlDO.DataSource = FileProcess.LoadTable("STInOutViewDO" + " @FromDate='" + dateFrom + "',@ToDate='" + dateTo + "', @varCustomerID=" + customerID + ",@varStoreID=" + AppSetting.StoreID);
                        break;

                    // Load data by WarehouseID
                    case InOutViewCaseEnum.WareHouse:
                        int warehouseID = Convert.ToInt32(this.lk_WM_Warehouse.EditValue.ToString());
                        grd_WM_ControlRO.DataSource = FileProcess.LoadTable("STInOutViewRO_W" + " @FromDate='" + dateFrom + "',@ToDate='" + dateTo + "', @WarehouseID=" + warehouseID + ",@varStoreID=" + AppSetting.StoreID);
                        grd_WM_ControlDO.DataSource = FileProcess.LoadTable("STInOutViewDO_W" + " @FromDate='" + dateFrom + "',@ToDate='" + dateTo + "', @WarehouseID=" + warehouseID + ",@varStoreID=" + AppSetting.StoreID);
                        break;

                    // Get data by current employee login
                    case InOutViewCaseEnum.Me:
                        int employeeID = AppSetting.CurrentUser.EmployeeID;
                        grd_WM_ControlRO.DataSource = FileProcess.LoadTable("STInOutViewRO_Me" + " @FromDate='" + dateFrom + "',@ToDate='" + dateTo + "', @EmployeeID=" + employeeID + ",@varStoreID=" + AppSetting.StoreID);
                        grd_WM_ControlDO.DataSource = FileProcess.LoadTable("STInOutViewDO_Me" + " @FromDate='" + dateFrom + "',@ToDate='" + dateTo + "', @EmployeeID=" + employeeID + ",@varStoreID=" + AppSetting.StoreID);
                        break;

                    // Load data by customer selected
                    case InOutViewCaseEnum.Customer:
                        this.mnu_btn_CreateWavePicking.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        customerID = Convert.ToInt32(lookUpEditCustomerID.EditValue);
                        grd_WM_ControlRO.DataSource = FileProcess.LoadTable("STInOutViewRO" + " @FromDate='" + dateFrom + "',@ToDate='" + dateTo + "', @varCustomerID=" + customerID + ",@varStoreID=" + AppSetting.StoreID);
                        grd_WM_ControlDO.DataSource = FileProcess.LoadTable("STInOutViewDO" + " @FromDate='" + dateFrom + "',@ToDate='" + dateTo + "', @varCustomerID=" + customerID + ",@varStoreID=" + AppSetting.StoreID);
                        break;

                    // Load data by customer selected and main value
                    case InOutViewCaseEnum.Main:
                        this.mnu_btn_CreateWavePicking.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        int customerMainID = Convert.ToInt32(this.lookUpEditCustomerID.GetColumnValue("CustomerMainID"));
                        grd_WM_ControlRO.DataSource = FileProcess.LoadTable("STInOutViewRO_Main" + " @FromDate='" + dateFrom + "',@ToDate='" + dateTo + "', @varCustomerID=" + customerMainID + ",@varStoreID=" + AppSetting.StoreID);
                        grd_WM_ControlDO.DataSource = FileProcess.LoadTable("STInOutViewDO_Main" + " @FromDate='" + dateFrom + "',@ToDate='" + dateTo + "', @varCustomerID=" + customerMainID + ",@varStoreID=" + AppSetting.StoreID);
                        break;

                    // Load data by room 
                    case InOutViewCaseEnum.Room:
                        grd_WM_ControlRO.DataSource = FileProcess.LoadTable("STInOutViewRO_R @FromDate='" + dateFrom + "',@ToDate='" + dateTo + "', @RoomID =" + this.lk_WM_Rooms.EditValue + ",@varStoreID=" + AppSetting.StoreID);
                        grd_WM_ControlDO.DataSource = FileProcess.LoadTable("STInOutViewDO_R @FromDate='" + dateFrom + "',@ToDate='" + dateTo + "', @RoomID =" + this.lk_WM_Rooms.EditValue + ",@varStoreID=" + AppSetting.StoreID);
                        break;

                    // Load data unFinish
                    case InOutViewCaseEnum.UnFinish:
                        grd_WM_ControlRO.DataSource = FileProcess.LoadTable("STInOutViewRO_T @FromDate='" + dateFrom + "',@ToDate='" + dateTo + "',@varStoreID=" + AppSetting.StoreID);
                        grd_WM_ControlDO.DataSource = FileProcess.LoadTable("STInOutViewDO_T @FromDate='" + dateFrom + "',@ToDate='" + dateTo + "',@varStoreID=" + AppSetting.StoreID);
                        break;

                    case InOutViewCaseEnum.Me0:
                        grd_WM_ControlRO.DataSource = FileProcess.LoadTable("STInOutViewRO_Me_0" + " @FromDate='" + dateFrom + "',@ToDate='" + dateTo + "', @EmployeeID=" + AppSetting.CurrentUser.EmployeeID + ",@varStoreID=" + AppSetting.StoreID);
                        grd_WM_ControlDO.DataSource = FileProcess.LoadTable("STInOutViewDO_Me_0" + " @FromDate='" + dateFrom + "',@ToDate='" + dateTo + "', @EmployeeID=" + AppSetting.CurrentUser.EmployeeID + ",@varStoreID=" + AppSetting.StoreID);
                        break;

                    // Load summary Data of all Customers
                    case InOutViewCaseEnum.Summary:
                        grd_WM_ControlRO.DataSource = FileProcess.LoadTable("STInOutViewRO_Summary" + " @FromDate='" + dateFrom + "',@ToDate='" + dateTo + "', @varStoreID=" + AppSetting.StoreID);
                        grd_WM_ControlDO.DataSource = FileProcess.LoadTable("STInOutViewDO_Summary" + " @FromDate='" + dateFrom + "',@ToDate='" + dateTo + "', @varStoreID=" + AppSetting.StoreID);
                        break;

                    default:
                        grd_WM_ControlRO.DataSource = FileProcess.LoadTable("STInOutViewRO" + " @FromDate='" + dateFrom + "',@ToDate='" + dateTo + "', @varCustomerID=" + customerID + ",@varStoreID=" + AppSetting.StoreID);
                        grd_WM_ControlDO.DataSource = FileProcess.LoadTable("STInOutViewDO" + " @FromDate='" + dateFrom + "',@ToDate='" + dateTo + "', @varCustomerID=" + customerID + ",@varStoreID=" + AppSetting.StoreID);
                        break;
                }

                // Display sum kilogam value
                if (this.colDOTotalWeight.SummaryItem.SummaryValue != null)
                {
                    double total = double.Parse(this.colDOTotalWeight.SummaryItem.SummaryValue.ToString()) + double.Parse(this.colTotalWeight.SummaryItem.SummaryValue.ToString());
                    this.gridColumnDOSpecialRequirement.SummaryItem.SetSummary(DevExpress.Data.SummaryItemType.Custom, "Σ:" + total.ToString("N"));
                }
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

        /// <summary>
        /// Load warehouse data
        /// </summary>
        private void LoadWarehouseStore()
        {
            this.lk_WM_Warehouse.Properties.DataSource = FileProcess.LoadTable("Select * from Warehouses where StoreID=" + AppSetting.StoreID);
            this.lk_WM_Warehouse.Properties.ValueMember = "WarehouseID";
            this.lk_WM_Warehouse.Properties.DisplayMember = "WarehouseDescription";
        }

        /// <summary>
        /// Init data source customer
        /// </summary>
        private void InitCustomer()
        {
            // Load customer
            if (AppSetting.CustomerList == null) return;
            lookUpEditCustomerID.Properties.DataSource = AppSetting.CustomerList.Where(a => a.StoreID == AppSetting.StoreID && a.CustomerDiscontinued == false); ;
            lookUpEditCustomerID.Properties.ValueMember = "CustomerID";
            lookUpEditCustomerID.Properties.DisplayMember = "CustomerNumber";
        }

        /// <summary>
        /// Load all rooms
        /// </summary>
        private void LoadAllRooms()
        {
            var listRoom = FileProcess.LoadTable("Select * from Rooms where StoreID=" + AppSetting.StoreID);
            this.lk_WM_Rooms.Properties.DataSource = listRoom;
            this.lk_WM_Rooms.Properties.ValueMember = "RoomID";
            this.lk_WM_Rooms.Properties.DisplayMember = "RoomDescription";
            if (listRoom.Rows.Count >= 20)
            {
                this.lk_WM_Rooms.Properties.DropDownRows = 20;
            }
            else
            {
                this.lk_WM_Rooms.Properties.DropDownRows = listRoom.Rows.Count;
            }

        }

        /// <summary>
        /// Set customer controls to display by state check
        /// </summary>
        /// <param name="isDisplay">bool</param>
        private void SetCustomerControlsDisplay(bool isDisplay = false)
        {
            this.lookUpEditCustomerID.EditValue = null;
            this.lookUpEditCustomerID.Enabled = isDisplay;
            this.textEditCustomerName.Enabled = isDisplay;
        }

        private void checkEditCustomer_CheckedChanged(object sender, EventArgs e)
        {
            lookUpEditCustomerID.Enabled = checkEditCustomer.Checked;
            if (this.isFindCustomer)
            {
                this.isFindCustomer = false;
                return;
            }

            // Load customer
            if (AppSetting.CustomerList == null) return;
            lookUpEditCustomerID.Properties.DataSource = AppSetting.CustomerList.Where(a => a.StoreID == AppSetting.StoreID && a.CustomerDiscontinued == false); ;
            lookUpEditCustomerID.Properties.ValueMember = "CustomerID";
            lookUpEditCustomerID.Properties.DisplayMember = "CustomerNumber";

            if (lookUpEditCustomerID.Enabled)
            {
                // Set display customer controls to display
                this.SetCustomerControlsDisplay(true);
                lookUpEditCustomerID.Focus();

                lookUpEditCustomerID.ShowPopup();
            }
            else
            {
                if (lookUpEditCustomerID.Enabled)
                {
                    // Definition load case is customer 
                    this.loadCase = InOutViewCaseEnum.Customer;

                    LoadRODO();
                }

                // Set comtomer control is disable
                this.SetCustomerControlsDisplay();
            }
        }

        private void lookUpEditCustomerID_EditValueChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    this.checkEditMain.Checked = true;
            //    if (this.lookUpEditCustomerID.EditValue == null)
            //    {
            //        textEditCustomerName.Text = string.Empty;
            //        return;
            //    }

            //    int customerID = Convert.ToInt32(lookUpEditCustomerID.EditValue);
            //    string customerName = Convert.ToString(lookUpEditCustomerID.GetColumnValue("CustomerName"));
            //    textEditCustomerName.Text = customerName;

            //    if (this.checkEditMain.Checked)
            //    {
            //        this.loadCase = InOutViewCaseEnum.Main;
            //    }
            //    else
            //    {
            //        // Definition load case is customer 
            //        this.loadCase = InOutViewCaseEnum.Customer;
            //    }

            //    LoadRODO();
            //}
            //catch (Exception ex)
            //{
            //    log.Error("==> Error is unexpected");
            //    log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);

            //    textEditCustomerName.Text = "";
            //    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        /// <summary>
        /// View RO-DO result on inoutview form with current customer selected
        /// RO -> isRO=true
        /// DO -> isRO=false
        /// </summary>
        /// <param name="customerID">int</param>
        /// <param name="isRO">bool</param>
        public void ViewRODOData(int customerID, bool isRO)
        {
            // Definition load case is customer 
            this.loadCase = InOutViewCaseEnum.Customer;
            this.checkEditCustomer.Checked = true;
            this.dateEditDateFrom.Text = DateTime.Now.ToShortDateString();
            this.dateEditDateTo.Text = DateTime.Now.ToShortDateString();
            var customerSelected = AppSetting.CustomerList.Where(c => c.CustomerID == customerID).FirstOrDefault();
            this.lookUpEditCustomerID.Text = customerSelected.CustomerNumber;
            this.textEditCustomerName.Text = customerSelected.CustomerName;
            this.lookUpEditCustomerID.ClosePopup();
            string date = DateTime.Now.ToString("yyyy-MM-dd");

            if (isRO)
            {
                grd_WM_ControlRO.DataSource = FileProcess.LoadTable("STInOutViewRO" + " @FromDate='" + date + "',@ToDate='" + date + "', @varCustomerID=" + customerID + ",@varStoreID=" + AppSetting.StoreID);
            }
            else
            {
                grd_WM_ControlDO.DataSource = FileProcess.LoadTable("STInOutViewDO" + " @FromDate='" + date + "',@ToDate='" + date + "', @varCustomerID=" + customerID + ",@varStoreID=" + AppSetting.StoreID);
            }
        }

        private void simpleButton7Plus_Click(object sender, EventArgs e)
        {
            dateEditDateFrom.DateTime = dateEditDateFrom.DateTime.AddDays(7);
            dateEditDateTo.DateTime = dateEditDateTo.DateTime.AddDays(7);
        }

        private void simpleButton1Plus_Click(object sender, EventArgs e)
        {
            dateEditDateFrom.DateTime = dateEditDateFrom.DateTime.AddDays(1);
            dateEditDateTo.DateTime = dateEditDateTo.DateTime.AddDays(1);
            KeyEventArgs enterKey = new KeyEventArgs(Keys.Enter);
            this.dateEditDateFrom_KeyDown(this.dateEditDateFrom, enterKey);
        }

        private void simpleButton1Minus_Click(object sender, EventArgs e)
        {
            dateEditDateFrom.DateTime = dateEditDateFrom.DateTime.AddDays(-1);
            dateEditDateTo.DateTime = dateEditDateTo.DateTime.AddDays(-1);
            KeyEventArgs enterKey = new KeyEventArgs(Keys.Enter);
            this.dateEditDateFrom_KeyDown(this.dateEditDateFrom, enterKey);
        }

        private void simpleButton7Minus_Click(object sender, EventArgs e)
        {
            dateEditDateFrom.DateTime = dateEditDateFrom.DateTime.AddDays(-7);
            dateEditDateTo.DateTime = dateEditDateTo.DateTime.AddDays(-7);
        }

        private void btn_WM_Today_Click(object sender, EventArgs e)
        {
            dateEditDateTo.DateTime = DateTime.Now;
            dateEditDateFrom.DateTime = DateTime.Now;
            this.rad_WM_All.Enabled = true;
            this.LoadRODO();
        }

        private void checkEditMain_CheckedChanged(object sender, EventArgs e)
        {
            if (this.isFirstLoad) return;
            if (this.checkEditMain.Checked)
            {
                // Definition load case is main 
                this.loadCase = InOutViewCaseEnum.Main;

                this.LoadRODO();
            }
            else
            {
                this.loadCase = InOutViewCaseEnum.Customer;
                this.LoadRODO();
            }
        }

        private void checkEditMe_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkEditMe.Checked)
            {
                // Definition load case is Me 
                this.loadCase = InOutViewCaseEnum.Me;

                this.LoadRODO();
            }
        }

        private void rad_WM_All_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rad_WM_All.Checked)
            {
                // Definition load case is All 
                this.loadCase = InOutViewCaseEnum.All;
                this.LoadRODO();
            }
        }

        private void chk_WM_UnFinish_CheckedChanged(object sender, EventArgs e)
        {
            Wait.Start(this);
            if (this.chk_WM_UnFinish.Checked)
            {
                // Definition load case is customer 
                this.loadCase = InOutViewCaseEnum.UnFinish;

                this.LoadRODO();
            }
            else
            {
                // Definition load case is customer 
                this.loadCase = InOutViewCaseEnum.All;

                this.LoadRODO();
            }
            Wait.Close();
        }

        private void btn_WM_Stock_Click(object sender, EventArgs e)
        {
            Wait.Start(this);
            int customerIDSelected = Int32.Parse(this.lookUpEditCustomerID.EditValue.ToString());
            frm_ST_StockOnHandOneCustomer frmStock = new frm_ST_StockOnHandOneCustomer(customerIDSelected);
            frmStock.Show();
            Wait.Close();
        }

        private void rpihle_WM_ReceivingOrderInfo_DoubleClick(object sender, EventArgs e)
        {
            string orderType = (Convert.ToString(this.grV_WM_ControlRO.GetRowCellValue(this.grV_WM_ControlRO.FocusedRowHandle, "ReceivingOrderNumber"))).Substring(0, 2);
            int receivingOrderID = Convert.ToInt32(this.grV_WM_ControlRO.GetRowCellValue(this.grV_WM_ControlRO.FocusedRowHandle, "ReceivingOrderID").ToString());
            if (orderType.ToUpper().Equals("PC"))
            {
                //frm_M_ProductCheckingByRequest pc = frm_M_ProductCheckingByRequest.GetInstance();
                //pc.ProductCheckingIDFind = receivingOrderID;
                //pc.Show();
                //pc.WindowState = FormWindowState.Maximized;
                //pc.BringToFront();


                frm_M_ProductCheckingByRequest frm = new frm_M_ProductCheckingByRequest();
                frm.ProductCheckingIDFind = receivingOrderID;
                frm.Show();
                frm.WindowState = FormWindowState.Maximized;
                frm.BringToFront();
            }
            else if (orderType.ToUpper().Equals("RO"))
            {
                frm_WM_ReceivingOrders receivingOrder = frm_WM_ReceivingOrders.Instance;
                receivingOrder.ReceivingOrderIDFind = receivingOrderID;
                receivingOrder.Show();
                receivingOrder.WindowState = FormWindowState.Maximized;
                receivingOrder.BringToFront();
            }
            else if (orderType.ToUpper().Equals("TW"))
            {
                // Display trip managerment
                if (this.frmTrip == null)
                {
                    this.frmTrip = new frm_WM_TripsManagement(receivingOrderID);
                }
                else
                {
                    this.frmTrip.ReloadData(receivingOrderID);
                }
                this.frmTrip.Show();
                this.frmTrip.WindowState = FormWindowState.Maximized;
                this.frmTrip.BringToFront();
            }

        }

        private void rpihle_WM_DispachingOrderInfo_DoubleClick(object sender, EventArgs e)
        {
            // Detected current order is Dispatching or Trip
            string orderNo = Convert.ToString(this.grv_WM_ControlDO.GetRowCellValue(this.grv_WM_ControlDO.FocusedRowHandle, "DispatchingOrderNumber"));
            if (string.IsNullOrEmpty(orderNo)) return;
            string orderNumber = orderNo.Substring(0, 2);
            int receivingOrderID = Convert.ToInt32(this.grv_WM_ControlDO.GetRowCellValue(this.grv_WM_ControlDO.FocusedRowHandle, "DispatchingOrderID").ToString());
            if (orderNumber.ToUpper().Equals("DO"))
            {
                // Display disptching order
                frm_WM_DispatchingOrders dispatchingOrder = frm_WM_DispatchingOrders.GetInstance(receivingOrderID);
                if (dispatchingOrder.Visible)
                {
                    dispatchingOrder.ReloadData();
                }
                try
                {
                    dispatchingOrder.Show();
                    dispatchingOrder.WindowState = FormWindowState.Maximized;
                    dispatchingOrder.BringToFront();
                }
                catch
                {

                }
            }
            else if (orderNumber.ToUpper().Equals("TW"))
            {
                // Display trip managerment
                if (this.frmTrip == null)
                {
                    this.frmTrip = new frm_WM_TripsManagement(receivingOrderID);
                }
                else
                {
                    this.frmTrip.ReloadData(receivingOrderID);
                }
                this.frmTrip.Show();
                this.frmTrip.WindowState = FormWindowState.Maximized;
                this.frmTrip.BringToFront();
            }
        }

        /// <summary>
        /// Find RO-DO by warehouse ID is current selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lk_WM_Warehouse_EditValueChanged(object sender, EventArgs e)
        {
            this.loadCase = InOutViewCaseEnum.WareHouse;
            LoadRODO();
        }

        /// <summary>
        /// Find RO-DO by current Room Name selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lk_WM_Rooms_EditValueChanged(object sender, EventArgs e)
        {
            this.loadCase = InOutViewCaseEnum.Room;
            LoadRODO();
        }

        /// <summary>
        /// View RO, DO by Date
        /// </summary>
        public void ViewRODOByDate(DateTime date)
        {
            this.dateEditDateFrom.EditValue = date;
            this.dateEditDateTo.EditValue = date;
            string dateFormat = date.ToString("yyyy-MM-dd");

            int employeeID = AppSetting.CurrentUser.EmployeeID;
            grd_WM_ControlRO.DataSource = FileProcess.LoadTable("STInOutViewRO_Me" + " @FromDate='" + dateFormat + "',@ToDate='" + dateFormat + "', @EmployeeID=" + employeeID + ",@varStoreID=" + AppSetting.StoreID);
            grd_WM_ControlDO.DataSource = FileProcess.LoadTable("STInOutViewDO_Me" + " @FromDate='" + dateFormat + "',@ToDate='" + dateFormat + "', @EmployeeID=" + employeeID + ",@varStoreID=" + AppSetting.StoreID);
        }

        private void mnu_btn_Copy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string productNumberSelected = string.Empty;
            if (this.isRo)
            {
                productNumberSelected = this.grV_WM_ControlRO.GetFocusedDisplayText();
            }
            else
            {
                productNumberSelected = this.grv_WM_ControlDO.GetFocusedDisplayText();
            }

            if (string.IsNullOrEmpty(productNumberSelected)) return;
            Clipboard.Clear();
            Clipboard.SetText(productNumberSelected);
        }

        private void grV_WM_ControlRO_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            this.isRo = true;
            //this.mnu_btn_CreateTrip.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.mnu_btn_CreateTrip.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            this.ShowPopupOptionsCellMenu(sender, e);
        }

        private void grv_WM_ControlDO_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            this.isRo = false;
            this.mnu_btn_CreateTrip.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            this.ShowPopupOptionsCellMenu(sender, e);
        }

        /// <summary>
        /// Show Options Cell menu when right mouse click on OrderNumber
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowPopupOptionsCellMenu(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (!e.HitInfo.InRow || e.HitInfo.Column == null) return;
            if (e.HitInfo.Column.FieldName.Equals("SpecialRequirement")) return;
            this.popupOptionsCell.ShowPopup(Control.MousePosition);
        }

        private void textEditCustomerName_DoubleClick(object sender, EventArgs e)
        {
            if (lookUpEditCustomerID.EditValue == null)
            {
                return;
            }
            int customerID = Convert.ToInt32(lookUpEditCustomerID.EditValue);
            Customers customer = AppSetting.CustomerList.FirstOrDefault(c => c.CustomerID == customerID);
            frm_MSS_Customers.Instance.CurrentCustomers = customer;
            frm_MSS_Customers.Instance.Show();
        }

        private void dateEditDateFrom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                var dateFrom = (DevExpress.XtraEditors.DateEdit)sender;
                this.dateEditDateFrom.DateTime = dateFrom.DateTime;
                if (dateFrom.DateTime > this.dateEditDateTo.DateTime) this.dateEditDateTo.DateTime = dateFrom.DateTime;
                double dateLimiter = (this.dateEditDateTo.DateTime - dateFrom.DateTime).TotalDays;
                if (dateLimiter > 7)
                {
                    this.rad_WM_All.Enabled = false;
                    this.checkEditCustomer.Checked = true;
                }
                else
                {
                    this.rad_WM_All.Enabled = true;
                }

                LoadRODO();
            }
        }

        private void dateEditDateTo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                var dateTo = (DevExpress.XtraEditors.DateEdit)sender;
                dateEditDateTo.DateTime = dateTo.DateTime;
                double dateLimiter = (dateTo.DateTime - this.dateEditDateFrom.DateTime).TotalDays;
                if (this.dateEditDateFrom.DateTime > dateTo.DateTime) this.dateEditDateFrom.DateTime = dateTo.DateTime;
                if (dateLimiter > 7)
                {
                    this.rad_WM_All.Enabled = false;
                    this.checkEditCustomer.Checked = true;
                }
                else
                {
                    this.rad_WM_All.Enabled = true;
                }

                LoadRODO();
            }
        }

        private void rpi_hpl_ROCustomer_Click(object sender, EventArgs e)
        {
            int customerID = Convert.ToInt32(this.grV_WM_ControlRO.GetFocusedRowCellValue("CustomerID"));
            int customerIDLookUp = Convert.ToInt32(this.lookUpEditCustomerID.EditValue);
            if (customerID.Equals(customerIDLookUp)) return;
            this.isFindCustomer = true;
            this.checkEditCustomer.Checked = true;
            this.lookUpEditCustomerID.EditValue = customerID;
            UpdateCustomer(customerID);
        }

        private void rpi_hpl_DO_Customer_Click(object sender, EventArgs e)
        {
            int customerID = Convert.ToInt32(this.grv_WM_ControlDO.GetFocusedRowCellValue("CustomerID"));
            int customerIDLookUp = Convert.ToInt32(this.lookUpEditCustomerID.EditValue);
            if (customerID.Equals(customerIDLookUp)) return;
            this.isFindCustomer = true;
            this.checkEditCustomer.Checked = true;
            this.lookUpEditCustomerID.EditValue = customerID;
            UpdateCustomer(customerID);
        }

        private void grd_WM_ControlRO_Click(object sender, EventArgs e)
        {
            
        }

        private void grV_WM_ControlRO_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.isShowRoAttachment = true;
        }

        private void grv_WM_ControlDO_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.isShowRoAttachment = false;
        }

        private void rpi_chk_DO_Attachment_Click(object sender, EventArgs e)
        {
            int customerID = Convert.ToInt32(this.grv_WM_ControlDO.GetFocusedRowCellValue("CustomerID"));
            string orderNumber = Convert.ToString(this.grv_WM_ControlDO.GetRowCellValue(this.grv_WM_ControlDO.FocusedRowHandle, "DispatchingOrderNumber"));
            ShowAttachment(orderNumber, customerID);
        }

        private void rpi_chk_RO_Attachment_Click(object sender, EventArgs e)
        {
            int customerID = Convert.ToInt32(this.grV_WM_ControlRO.GetFocusedRowCellValue("CustomerID"));
            string orderNumber = Convert.ToString(this.grV_WM_ControlRO.GetRowCellValue(this.grV_WM_ControlRO.FocusedRowHandle, "ReceivingOrderNumber"));
            ShowAttachment(orderNumber, customerID);
        }

        private void grd_WM_ControlRO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                //if (this.Modal)
                //{
                //    return;
                //}

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

        private static void ShowAttachment(string order, int customerID)
        {
            if (string.IsNullOrEmpty(order)) return;
            frm_WM_Attachments.Instance.OrderNumber = order;
            frm_WM_Attachments.Instance.CustomerID = customerID;
            if (!frm_WM_Attachments.Instance.Enabled) return;
            frm_WM_Attachments.Instance.ShowDialog();
        }

        private void grd_WM_ControlRO_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F3))
            {
                int customerID = Convert.ToInt32(this.grV_WM_ControlRO.GetFocusedRowCellValue("CustomerID"));
                string orderNumber = Convert.ToString(this.grV_WM_ControlRO.GetRowCellValue(this.grV_WM_ControlRO.FocusedRowHandle, "ReceivingOrderNumber"));
                ShowAttachment(orderNumber, customerID);
            }
        }

        private void grd_WM_ControlDO_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F3))
            {
                int customerID = Convert.ToInt32(this.grv_WM_ControlDO.GetFocusedRowCellValue("CustomerID"));
                string orderNumber = Convert.ToString(this.grv_WM_ControlDO.GetRowCellValue(this.grv_WM_ControlDO.FocusedRowHandle, "DispatchingOrderNumber"));
                ShowAttachment(orderNumber, customerID);
            }
        }

        private void radMe0_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rad_WM_Me0.Checked)
            {
                // Load all data or current user is not yet confirm 
                this.loadCase = InOutViewCaseEnum.Me0;
                this.LoadRODO();
            }
        }

        private void bn_WM_Summary_Click(object sender, EventArgs e)
        {
            // Load all data or current user is not yet confirm 
            this.loadCase = InOutViewCaseEnum.Summary;
            this.LoadRODO();
        }


        private void NotContainItemDO_Click(object sender, EventArgs e)
        {
            string filter = grv_WM_ControlDO.ActiveFilterString;
            string value = (sender as DXMenuItem).Caption.Split('\'')[1];
            string newFilterString = "Not Contains([" + grv_WM_ControlDO.FocusedColumn.FieldName + "], '" + value + "')";

            if (filter == String.Empty)
                grv_WM_ControlDO.ActiveFilterString = newFilterString;
            else
                grv_WM_ControlDO.ActiveFilterString += "And " + newFilterString;
        }

        private void ContainItemDO_Click(object sender, EventArgs e)
        {
            string filter = grv_WM_ControlDO.ActiveFilterString;
            string value = (sender as DXMenuItem).Caption.Split('\'')[1];
            string newFilterString = "Contains([" + grv_WM_ControlDO.FocusedColumn.FieldName + "], '" + value + "')";

            if (filter == String.Empty)
                grv_WM_ControlDO.ActiveFilterString = newFilterString;
            else
                grv_WM_ControlDO.ActiveFilterString += "And " + newFilterString;
        }

        private void grv_WM_ControlDO_ShownEditor(object sender, EventArgs e)
        {
            var editor = grv_WM_ControlDO.ActiveEditor as TextEdit;
            if (editor == null) return;
            editor.Properties.BeforeShowMenu += Properties_BeforeShowMenuDO;
        }
        void ClearMenuDO(DXPopupMenu menu)
        {
            foreach (DXMenuItem item in menu.Items)
                if (item.Caption.Contains("Filter by"))
                    item.Visible = false;
        }

        bool initializeMenuDO = true;
        private void Properties_BeforeShowMenuDO(object sender, DevExpress.XtraEditors.Controls.BeforeShowMenuEventArgs e)
        {
            ClearMenuDO(e.Menu);
            string textDO = (sender as TextEdit).SelectedText;

            if (textDO != String.Empty)
            {
                containItemDO.Caption = "Filter by contains '" + textDO + "'";
                notContainItemDO.Caption = "Filter by not contains '" + textDO + "'";
                containItemDO.Visible = true;
                notContainItemDO.Visible = true;
                if (initializeMenuDO)
                {
                    initializeMenuDO = false;
                    e.Menu.Items.Add(containItemDO);
                    e.Menu.Items.Add(notContainItemDO);
                }
            }
        }
        private void NotContainItemRO_Click(object sender, EventArgs e)
        {
            string filter = grV_WM_ControlRO.ActiveFilterString;
            string value = (sender as DXMenuItem).Caption.Split('\'')[1];
            string newFilterString = "Not Contains([" + grV_WM_ControlRO.FocusedColumn.FieldName + "], '" + value + "')";

            if (filter == String.Empty)
                grV_WM_ControlRO.ActiveFilterString = newFilterString;
            else
                grV_WM_ControlRO.ActiveFilterString += "And " + newFilterString;
        }

        private void ContainItemRO_Click(object sender, EventArgs e)
        {
            string filter = grV_WM_ControlRO.ActiveFilterString;
            string value = (sender as DXMenuItem).Caption.Split('\'')[1];
            string newFilterString = "Contains([" + grV_WM_ControlRO.FocusedColumn.FieldName + "], '" + value + "')";

            if (filter == String.Empty)
                grV_WM_ControlRO.ActiveFilterString = newFilterString;
            else
                grV_WM_ControlRO.ActiveFilterString += "And " + newFilterString;
        }

        private void grv_WM_ControlRO_ShownEditor(object sender, EventArgs e)
        {
            var editor = grV_WM_ControlRO.ActiveEditor as TextEdit;
            if (editor == null) return;
            editor.Properties.BeforeShowMenu += Properties_BeforeShowMenuRO;
        }

        void ClearMenuRO(DXPopupMenu menu)
        {
            foreach (DXMenuItem item in menu.Items)
                if (item.Caption.Contains("Filter by"))
                    item.Visible = false;
        }

        bool initializeMenuRO = true;
        private void Properties_BeforeShowMenuRO(object sender, DevExpress.XtraEditors.Controls.BeforeShowMenuEventArgs e)
        {
            ClearMenuRO(e.Menu);
            string textRO = (sender as TextEdit).SelectedText;

            if (textRO != String.Empty)
            {
                containItemRO.Caption = "Filter by contains '" + textRO + "'";
                notContainItemRO.Caption = "Filter by not contains '" + textRO + "'";
                containItemRO.Visible = true;
                notContainItemRO.Visible = true;
                if (initializeMenuRO)
                {
                    initializeMenuRO = false;
                    e.Menu.Items.Add(containItemRO);
                    e.Menu.Items.Add(notContainItemRO);
                }
            }
        }

        private void mnu_btn_CreateWavePicking_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_WM_WavePicking frmWave = null;
            StringBuilder orderNumber = new StringBuilder();
            int customerID = Convert.ToInt32(this.lookUpEditCustomerID.EditValue);
            string fromDate = this.dateEditDateFrom.DateTime.ToString("yyyy-MM-dd");
            string toDate = this.dateEditDateTo.DateTime.ToString("yyyy-MM-dd");
            int count = 0;
            if (this.isRo)
            {
                foreach (int rowIndex in this.grV_WM_ControlRO.GetSelectedRows())
                {
                    orderNumber.Append(this.grV_WM_ControlRO.GetRowCellValue(rowIndex, "ReceivingOrderID"));
                    if (count < this.grV_WM_ControlRO.SelectedRowsCount - 1)
                    {
                        orderNumber.Append(",");
                        count++;
                    }
                }
                frmWave = new frm_WM_WavePicking("RO", orderNumber.ToString(), customerID, fromDate, toDate);
            }
            else
            {
                foreach (int rowIndex in this.grv_WM_ControlDO.GetSelectedRows())
                {
                    orderNumber.Append(this.grv_WM_ControlDO.GetRowCellValue(rowIndex, "DispatchingOrderID"));
                    if (count < this.grv_WM_ControlDO.SelectedRowsCount - 1)
                    {
                        orderNumber.Append(",");
                        count++;
                    }
                }
                frmWave = new frm_WM_WavePicking("DO", orderNumber.ToString(), customerID, fromDate, toDate);
            }
            frmWave.Show();
        }

        private string ValidationDOValid()
        {
            string orderInvalid = string.Empty;
            DataProcess<DispatchingOrders> dataProcess = new DataProcess<DispatchingOrders>();
            int doID = 0;
            DispatchingOrders currentDO = null;
            string orderNumber = string.Empty;
            foreach (int index in this.grv_WM_ControlDO.GetSelectedRows())
            {
                orderNumber = Convert.ToString(this.grv_WM_ControlDO.GetRowCellValue(index, "DispatchingOrderNumber"));
                if (string.IsNullOrEmpty(orderNumber)) continue;
                if (!orderNumber.Substring(0, 2).Equals("DO"))
                {
                    orderInvalid += orderNumber + ",";
                }
                else
                {
                    doID = Convert.ToInt32(this.grv_WM_ControlDO.GetRowCellValue(index, "DispatchingOrderID"));
                    // Validate DO has accept
                    currentDO = dataProcess.Select(d => d.DispatchingOrderID == doID).FirstOrDefault();
                    if (currentDO.DispatchingOrderProgress < 1 || currentDO.DispatchingOrderProgress > 2)
                    {
                        orderInvalid += orderNumber + ",";
                    }
                }
            }
            return orderInvalid;
        }

        private void mnu_btn_CreateTrip_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.isRo)
            {
                StringBuilder orders = new StringBuilder();
                orders.Append("(");
                int count = 0;

                foreach (int rowIndex in this.grV_WM_ControlRO.GetSelectedRows())
                {
                    orders.Append(this.grV_WM_ControlRO.GetRowCellValue(rowIndex, "ReceivingOrderID"));
                    if (count < this.grV_WM_ControlRO.SelectedRowsCount - 1)
                    {
                        orders.Append(",");
                    }
                    count++;
                }
                orders.Append(")");
                if (String.IsNullOrEmpty(lookUpEditCustomerID.Text))
                {
                    MessageBox.Show("Please! Select Customer", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    checkEditCustomer.Checked = true;
                    lookUpEditCustomerID.Focus();
                    lookUpEditCustomerID.ShowPopup();
                    return;
                }
                // Insert new trip
                int tripID = 0;
                using (var context = new SwireDBEntities())
                {
                    ObjectParameter outTripID = new ObjectParameter("returnTripID", 0);
                    context.STTripInsertRO(Convert.ToInt32(lookUpEditCustomerID.EditValue),
                        AppSetting.CurrentUser.LoginName,
                        orders.ToString(),
                       0, outTripID);
                    tripID = Convert.ToInt32(outTripID.Value);
                }

                // Display new trip on form
                if (tripID <= 0) return;
                // Display trip managerment
                if (this.frmTrip == null)
                {
                    this.frmTrip = new frm_WM_TripsManagement(tripID);
                }
                else
                {
                    this.frmTrip.ReloadData(tripID);
                }
                this.frmTrip.Show();
                this.frmTrip.WindowState = FormWindowState.Maximized;
                this.frmTrip.BringToFront();
            }
            else
            {
                // Validate DO is valid
                //string orderInvalid = this.ValidationDOValid();
                //if (!string.IsNullOrEmpty(orderInvalid))
                //{
                //    MessageBox.Show("The orders [" + orderInvalid + "] are not valid, please un-selected it when create new trip", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}

                // Get all DO selected
                StringBuilder orders = new StringBuilder();
                orders.Append("(");
                int count = 0;

                foreach (var index in this.grv_WM_ControlDO.GetSelectedRows())
                {
                    orders.Append(this.grv_WM_ControlDO.GetRowCellValue(index, "DispatchingOrderID"));
                    if (count < this.grv_WM_ControlDO.SelectedRowsCount - 1)
                    {
                        orders.Append(",");
                    }
                    count++;
                }
                orders.Append(")");
                if (String.IsNullOrEmpty(lookUpEditCustomerID.Text))
                {
                    MessageBox.Show("Please! Select Customer", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    checkEditCustomer.Checked = true;
                    lookUpEditCustomerID.Focus();
                    lookUpEditCustomerID.ShowPopup();
                    return;
                }
                // Insert new trip
                int tripID = 0;
                using (var context = new SwireDBEntities())
                {
                    ObjectParameter outTripID = new ObjectParameter("returnTripID", 0);
                    context.STTripInsert(Convert.ToInt32(lookUpEditCustomerID.EditValue),
                        AppSetting.CurrentUser.LoginName,
                        orders.ToString(),
                       0, outTripID);
                    tripID = Convert.ToInt32(outTripID.Value);
                }

                // Display new trip on form
                if (tripID <= 0) return;
                // Display trip managerment
                if (this.frmTrip == null)
                {
                    this.frmTrip = new frm_WM_TripsManagement(tripID);
                }
                else
                {
                    this.frmTrip.ReloadData(tripID);
                }
                this.frmTrip.Show();
                this.frmTrip.WindowState = FormWindowState.Maximized;
                this.frmTrip.BringToFront();
            }
        }

        private void lookUpEditCustomerID_Click(object sender, EventArgs e)
        {
            this.lookUpEditCustomerID.SelectAll();
        }

        private void lookUpEditCustomerID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                this.lookUpEditCustomerID.SelectAll();
            }
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            if (this.lookUpEditCustomerID.EditValue == null) return;
            int customerID = Convert.ToInt32(this.lookUpEditCustomerID.EditValue);
            frm_ST_StockOnHandOneCustomer frm = new frm_ST_StockOnHandOneCustomer(customerID);
            frm.Show();
        }

        private void labelDOTripFilter_Click(object sender, EventArgs e)
        {
            ColumnView view = this.grv_WM_ControlDO;
            view.ActiveFilter.Clear();
            switch (this.labelDOTripFilter.Text)
            {
                case "DO":

                    view.ActiveFilter.Add(view.Columns["DispatchingOrderNumber"], new ColumnFilterInfo("[DispatchingOrderNumber] LIKE 'DO%'"));
                    //this.grv_WM_ControlDO.Columns["DispatchingOrderNumber"].FilterInfo = new ColumnFilterInfo("[DispatchingOrderNumber] LIKE 'DO%'");
                    this.labelDOTripFilter.Text = "Trip";
                    break;
                case "Trip":

                    view.ActiveFilter.Add(view.Columns["DispatchingOrderNumber"], new ColumnFilterInfo("[DispatchingOrderNumber] LIKE 'TW%'"));
                    //this.grv_WM_ControlDO.Columns["DispatchingOrderNumber"].FilterInfo = new ColumnFilterInfo("[DispatchingOrderNumber] LIKE 'TW%'");
                    this.labelDOTripFilter.Text = "All";
                    break;
                case "All":
                    this.labelDOTripFilter.Text = "DO";
                    break;

            }
            this.grv_WM_ControlDO.Columns["DispatchingOrderNumber"].FilterInfo = new ColumnFilterInfo("[DispatchingOrderNumber] LIKE 'DO%'");

        }

        private void lookUpEditCustomerID_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            try
            {
                this.checkEditMain.Checked = true;
                this.lookUpEditCustomerID.EditValue = e.Value;
                if (this.lookUpEditCustomerID.EditValue == null)
                {
                    textEditCustomerName.Text = string.Empty;
                    return;
                }

                int customerID = Convert.ToInt32(lookUpEditCustomerID.EditValue);
                string customerName = Convert.ToString(lookUpEditCustomerID.GetColumnValue("CustomerName"));
                textEditCustomerName.Text = customerName;

                if (this.checkEditMain.Checked)
                {
                    this.loadCase = InOutViewCaseEnum.Main;
                }
                else
                {
                    // Definition load case is customer 
                    this.loadCase = InOutViewCaseEnum.Customer;
                }

                LoadRODO();
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);

                textEditCustomerName.Text = "";
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateCustomer(int customerID)
        {
            try
            {
                
                string customerName = Convert.ToString(lookUpEditCustomerID.GetColumnValue("CustomerName"));
                textEditCustomerName.Text = customerName;

                if (this.checkEditMain.Checked)
                {
                    this.loadCase = InOutViewCaseEnum.Main;
                }
                else
                {
                    // Definition load case is customer 
                    this.loadCase = InOutViewCaseEnum.Customer;
                }

                LoadRODO();
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);

                textEditCustomerName.Text = "";
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnContract_Click(object sender, EventArgs e)
        {
            if (this.lookUpEditCustomerID.EditValue == null) return;
            int customerID = Convert.ToInt32(this.lookUpEditCustomerID.EditValue);
            if (customerID <= 0) return;
            frm_MSS_Contracts contract = frm_MSS_Contracts.GetInstance(customerID);
            contract.InitData(customerID, 0);
            contract.Show();
        }

        private void frm_WM_InOutViewByDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                //if (this.Modal)
                //{
                //    return;
                //}

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

        private void grd_WM_ControlDO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                //if (this.Modal)
                //{
                //    return;
                //}

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
    }
}
