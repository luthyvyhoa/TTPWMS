using Common.Data;
using Common.Process;
using DA;
using DA.API;
using DA.Master;
using DA.Warehouse;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraReports.UI;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using UI.APIs;
using UI.Helper;
using UI.Management;
using UI.MasterSystemSetup;
using UI.ReportFile;
using UI.ReportForm;
using UI.StockTake;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_DispatchingOrders : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        // Declare log

        private static readonly ILog log = LogManager.GetLogger(typeof(frm_WM_DispatchingOrders));
        private static frm_WM_DispatchingOrders instance = null;
        BindingList<DispatchingOrders> listDispatchingOrders = null;
        BindingList<DispatchingProducts> listOrderDetail = new BindingList<DispatchingProducts>();
        List<STComboProductIDDO_Result> listProduct;
        private BindingList<ST_WMS_LoadDPProductData_Result> listDispatchingLocation;

        DispatchingProducts objSelected = null;
        private frm_WM_Dialog_DispatchingOrderDetails frmQtyDetail = null;
        DataProcess<Customers> customerDA = new DataProcess<Customers>();
        DataProcess<DispatchingOrders> dispatchingOrderDA = new DataProcess<DispatchingOrders>();
        Employees fullInfoEmployees = null;
        Customers customer = null;
        string customerType = "";
        bool dispatchingByClient = false;
        bool isUpdate = false;
        private DispatchingProductsDA dispatchingProductDA = new DispatchingProductsDA();
        bool isFirstLoad = true;
        bool isAddNewRecord = false;
        private int productIDToDisplayDetail = -1;
        private static bool hasLoadedDataParent = false;
        private DateTime orderTraceDate = DateTime.Now;
        int qtyPrint = 0;
        private bool isTruckModified = false;
        private frm_WM_PalletInfo palletInfo = null;
        private frm_WM_DispatchingProduct frmDispatchingProduct = null;
        private int rowIndexFocused = 0;
        private static Object locker = new Object();
        private IDictionary<Control, bool> validateList = new Dictionary<Control, bool>();
        private urc_WM_Notes viewNotes = null;
        private urc_WM_EmployeeInfo viewEmployee = null;
        private urc_WM_Vehicle viewVehicle = null;
        private urc_WM_OtherService viewService = null;
        private urc_WM_LoadingReport viewLoadingReport = null;
        private static int dispatchingOrderIDInput = 0;
        private bool isLockOrder = false;
        private static bool hasShowExportForm = false;
        private DataTable expiredDateSource = null;
        DataProcess<STLabelPalletCartonWeight> multilabel = new DataProcess<STLabelPalletCartonWeight>();
        private Timer timerNetWork = new Timer();
        private bool sleeptime = false;

        /// <summary>
        /// Constructor
        /// </summary>
        protected frm_WM_DispatchingOrders(int dispatchingOrderID)
        {
            // Init controls to designer
            InitializeComponent();

            // Validate function permission of user
            if (!this.ValidateActiveForm())
            {
                this.Enabled = false;
            }


            // Load data
            this.LoadTimeSlots();
            this.InitWorkType();

            // Init data to load form
            System.Threading.Tasks.Task.Run(() =>
            {
                this.InitLookup();
                this.LoadData();
            });

            this.dataNavigatorDispatchingOrders.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            fullInfoEmployees = AppSetting.CurrentEmployee;
            RefreshData.ReloadDataEvent += RefreshData_ReloadDataEvent;
            this.lookUpEditCustomerID.EditValueChanged += this.lookUpEditCustomerID_EditValueChanged;

            this.timerNetWork.Interval = 500;
            this.timerNetWork.Tick += TimerNetWork_Tick;
            this.timerNetWork.Start();

            this.SetEvent();
        }

        private void TimerNetWork_Tick(object sender, EventArgs e)
        {
            System.Threading.Tasks.Task.Run(() =>
            {
                Image imgDisplay = null;
                if (NetworkHelper.IsConnectedToInternet())
                    imgDisplay = Properties.Resources.On;
                else
                    imgDisplay = Properties.Resources.Off;

                if (this.sleeptime)
                    this.ribbonGalleryBarItem1.ImageOptions.Image = imgDisplay;
                else
                    this.ribbonGalleryBarItem1.ImageOptions.Image = Properties.Resources.Empty;
                this.sleeptime = !sleeptime;
            });
        }
        /// <summary>
        /// reload order detail when product has modified
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        void RefreshData_ReloadDataEvent(object sender, EventArgs e)
        {
            if (!sender.GetType().Name.Equals("Products")) return;
            int dispatchingOrderID = Convert.ToInt32(this.textEditOrderID.Tag);
            if (dispatchingOrderID <= 0) return;
            this.LoadDataDetail(dispatchingOrderID);
        }

        public static frm_WM_DispatchingOrders GetInstance(int dispatchingOrderID = 0, bool isShowExportForm = false)
        {
            dispatchingOrderIDInput = dispatchingOrderID;
            hasShowExportForm = isShowExportForm;
            if (instance == null)
            {
                instance = new frm_WM_DispatchingOrders(dispatchingOrderID);
            }

            return instance;
        }

        /// <summary>
        /// Validate function permission of current user
        /// </summary>
        private bool ValidateActiveForm()
        {

            return true;
            // If doesn't any function in list then disable form
            if (UserPermissionData.FunctionsPermisstionList == null)
            {
                return false;
            }

            // Get current form name
            string formName = this.ToString().Split(',')[0].Split('.')[2];

            // Detect current form has exist in function list
            foreach (System.Data.DataRow funtionName in UserPermissionData.FunctionsPermisstionList.Rows)
            {
                if (funtionName["FunctionName"].ToString().Trim().Equals(formName))
                {
                    // Validate action permission
                    this.SetPermissionControl(formName);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Set permission control
        /// </summary>
        private void SetPermissionControl(string functionName)
        {
            var actionsList = FileProcess.LoadTable("ST_WMS_LoadAllActionsByFuntion @FuntionName='" + functionName + "'");
            foreach (System.Data.DataRow actionName in actionsList.Rows)
            {
                ActionsPermisstionEnum actionCurrent = (ActionsPermisstionEnum)Enum.Parse(typeof(ActionsPermisstionEnum), actionName["ActionName"].ToString().Trim());
                switch (actionCurrent)
                {
                    case ActionsPermisstionEnum.AddNew:
                        this.btn_WM_NewAllProducts.Enabled = true;
                        this.btn_WM_NewProduct.Enabled = true;
                        break;
                    case ActionsPermisstionEnum.Edit:
                        break;
                    case ActionsPermisstionEnum.Update:
                        break;
                    case ActionsPermisstionEnum.Delete:
                        break;
                    case ActionsPermisstionEnum.View:
                        break;
                    case ActionsPermisstionEnum.Accept:
                        break;
                    case ActionsPermisstionEnum.UnAccept:
                        break;
                    case ActionsPermisstionEnum.Confirm:
                        break;
                    case ActionsPermisstionEnum.UnConfirm:
                        break;
                    case ActionsPermisstionEnum.Break:
                        break;
                    case ActionsPermisstionEnum.Export:
                        break;
                    case ActionsPermisstionEnum.Import:
                        break;
                }
            }
        }

        /// <summary>
        /// Load all time slots
        /// </summary>
        private void LoadTimeSlots()
        {
            this.lke_TimeSlotID.Properties.DataSource = AppSetting.TimeSlots;
            this.lke_TimeSlotID.Properties.DisplayMember = "TimeSlot";
            this.lke_TimeSlotID.Properties.ValueMember = "TimeSlotID";
        }

        private void frmDispatchingOrders_Load(object sender, EventArgs e)
        {

            Wait.Start(this);
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            try
            {
                while (!hasLoadedDataParent)
                {
                    log.Info("==> Waiting to load DispatchingOrder data...");
                    Application.DoEvents();
                }
                this.isFirstLoad = false;

                dataNavigatorDispatchingOrders.DataSource = listDispatchingOrders;
                Common.Process.RefreshData.Refresh(textEditOrderID, () =>
                 {
                     textEditOrderID.DataBindings.Add("EditValue", dataNavigatorDispatchingOrders.DataSource, "DispatchingOrderNumber", true, DataSourceUpdateMode.OnPropertyChanged, "");
                     textEditOrderID.DataBindings.Add("Tag", dataNavigatorDispatchingOrders.DataSource, "DispatchingOrderID", true, DataSourceUpdateMode.OnPropertyChanged, 0);
                     memoEditTruckAndDetail.DataBindings.Add("Tag", dataNavigatorDispatchingOrders.DataSource, "SpecialRequirement", true, DataSourceUpdateMode.OnPropertyChanged, "");
                     lookUpEditCustomerID.DataBindings.Add("Tag", dataNavigatorDispatchingOrders.DataSource, "CustomerID", true, DataSourceUpdateMode.OnPropertyChanged, 0);
                     lookUpEditCustomerClientID.DataBindings.Add("Tag", dataNavigatorDispatchingOrders.DataSource, "CustomerClientID", true, DataSourceUpdateMode.OnPropertyChanged, 0);
                     lke_TimeSlotID.DataBindings.Add("Tag", dataNavigatorDispatchingOrders.DataSource, "TimeSlotID", true, DataSourceUpdateMode.OnPropertyChanged, 0);
                     dateEditDispatchingOrderDate.DataBindings.Add("EditValue", dataNavigatorDispatchingOrders.DataSource, "DispatchingOrderDate", true, DataSourceUpdateMode.OnPropertyChanged, DateTime.Now.Date);
                     spinEditTemperature.DataBindings.Add("Tag", dataNavigatorDispatchingOrders.DataSource, "Temperature", true, DataSourceUpdateMode.OnPropertyChanged);
                     textEditDispatchingCreatedTime.DataBindings.Add("Tag", dataNavigatorDispatchingOrders.DataSource, "DispatchingCreatedTime", true, DataSourceUpdateMode.OnPropertyChanged, DateTime.Now, "dd/MM/yyyy HH:mm:ss");
                     textEditDispatchingCreatedBy.DataBindings.Add("Tag", dataNavigatorDispatchingOrders.DataSource, "Owner", true, DataSourceUpdateMode.OnPropertyChanged, "");
                     textEditSealNumber.DataBindings.Add("Tag", dataNavigatorDispatchingOrders.DataSource, "SealNumber", true, DataSourceUpdateMode.OnPropertyChanged, "");
                     textEditDispatchingOrderProgress.DataBindings.Add("EditValue", dataNavigatorDispatchingOrders.DataSource, "DispatchingOrderProgress", true, DataSourceUpdateMode.OnPropertyChanged, null);
                     textEditInernalRemark.DataBindings.Add("Tag", dataNavigatorDispatchingOrders.DataSource, "InternalRemark", true, DataSourceUpdateMode.OnPropertyChanged, "");
                     timeEditStartTime.DataBindings.Add("Tag", dataNavigatorDispatchingOrders.DataSource, "StartTime", true, DataSourceUpdateMode.OnPropertyChanged, null);
                     timeEditEndTime.DataBindings.Add("Tag", dataNavigatorDispatchingOrders.DataSource, "EndTime", true, DataSourceUpdateMode.OnPropertyChanged, null);
                     lookUpEditHandlingOvertimeCategoryID.DataBindings.Add("Tag", dataNavigatorDispatchingOrders.DataSource, "HandlingOvertimeCategoryID", true, DataSourceUpdateMode.OnPropertyChanged, 0);
                     textEditVehicleNumber.DataBindings.Add("Tag", dataNavigatorDispatchingOrders.DataSource, "VehicleNumber", true, DataSourceUpdateMode.Never, "");
                     textEditCustomerOrderNumber.DataBindings.Add("Tag", dataNavigatorDispatchingOrders.DataSource, "CustomerOrderNumber", true, DataSourceUpdateMode.Never, "");
                     textEditCustomerOrderNumber2.DataBindings.Add("Tag", dataNavigatorDispatchingOrders.DataSource, "CustomerOrderNumber2", true, DataSourceUpdateMode.Never, "");
                     txtPickingPercent.DataBindings.Add("Tag", dataNavigatorDispatchingOrders.DataSource, "PickingPercentage", true, DataSourceUpdateMode.Never, 0);
                     txtProcessStatus.DataBindings.Add("Tag", dataNavigatorDispatchingOrders.DataSource, "ProcessingStatus", true, DataSourceUpdateMode.Never, 0);
                     txtEDIMessageSentTime.DataBindings.Add("Tag", dataNavigatorDispatchingOrders.DataSource, "EDIMessageSentTime", true, DataSourceUpdateMode.Never, "");
                     dataNavigatorDispatchingOrders.Position = listDispatchingOrders.Count;
                     this.Text = textEditOrderID.Text.Trim() + " " + lookUpEditCustomerID.Text.Trim();
                 });
                if (listDispatchingOrders.Count <= 0)
                {
                    dataNavigatorDispatchingOrders.Position = listDispatchingOrders.Count;
                    textEditOrderID.Text = "DO-New *";
                    textEditOrderID.Tag = 0;
                    memoEditTruckAndDetail.Text = "";
                    memoEditTruckAndDetail.Tag = "";
                    dateEditDispatchingOrderDate.EditValue = null;
                    timeEditStartTime.Tag = timeEditStartTime.EditValue = null; // DateTime.Now;
                    timeEditEndTime.Tag = timeEditEndTime.EditValue = null; // DateTime.Now;
                    spinEditTemperature.Tag = spinEditTemperature.EditValue = null;
                    textEditSealNumber.Tag = textEditSealNumber.Text = "";
                    this.textEditDispatchingOrderProgress.EditValue = null;
                    this.lkeDockNumber.EditValue = null;
                    this.textEditVehicleNumber.Tag = this.textEditVehicleNumber.Text = string.Empty;
                    this.textEditCustomerOrderNumber.Tag = this.textEditCustomerOrderNumber.Text = string.Empty;
                    this.textEditCustomerOrderNumber2.Tag = this.textEditCustomerOrderNumber2.Text = string.Empty;
                    this.txtPickingPercent.Tag = null;
                    this.txtPickingPercent.Text = string.Empty;
                    this.txtProcessStatus.Tag = null;
                    this.txtProcessStatus.Text = string.Empty;
                    txtEDIMessageSentTime.Tag = null;
                    txtEDIMessageSentTime.Text = string.Empty;
                    textEditInernalRemark.Tag = textEditInernalRemark.Text = "";
                    lookUpEditCustomerID.Tag = lookUpEditCustomerID.EditValue = null;
                    lookUpEditCustomerID.ReadOnly = false;
                    lookUpEditCustomerID.Focus();
                    lookUpEditCustomerID.EditValue = lookUpEditCustomerID.Properties.GetDataSourceValue(lookUpEditCustomerID.Properties.ValueMember, 0);
                    lookUpEditCustomerID.ShowPopup();
                    listOrderDetail.Clear();
                }

                // Remove duplicate record add new 
                if (this.isAddNewRecord)
                {
                    listDispatchingOrders.RemoveAt(0);
                    this.isAddNewRecord = false;
                }
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                Wait.Close();
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Wait.Close();
        }

        #region Load Data
        /// <summary>
        /// Load DispatchingOrder data
        /// </summary>
        private void LoadData()
        {
            try
            {
                Wait.Start(this);

                if (this.listDispatchingOrders != null)
                {
                    this.listDispatchingOrders.Clear();
                }
                IList<DispatchingOrders> dispatchingOrderList;

                // If ReceivingOrder ID has data then get Receiving order Detail by it
                if (dispatchingOrderIDInput > 0)
                {
                    // Load receiving order detail by id selected
                    dispatchingOrderList = dispatchingOrderDA.Executing("select DispatchingOrders.* from DispatchingOrders " +
                                                                       " inner join Customers on Customers.CustomerID=DispatchingOrders.CustomerID " +
                                                                       " where DispatchingOrderID=" + dispatchingOrderIDInput + " and Customers.StoreID=" + AppSetting.StoreID + " order by DispatchingOrderID").ToList();
                }
                else
                {
                    // Load dispatchig order detail of 2 date previous
                    dispatchingOrderList = dispatchingOrderDA.Executing("select DispatchingOrders.* from DispatchingOrders " +
                                                                        " inner join Customers on Customers.CustomerID=DispatchingOrders.CustomerID " +
                                                                        " where DispatchingOrderDate>=getdate()-2 and Customers.StoreID=" + AppSetting.StoreID + " order by DispatchingOrderID").ToList();
                }

                // Add new record to datasource
                if (dispatchingOrderList.Count == 1)
                {
                    dispatchingOrderList.Add(dispatchingOrderList[0]);
                    this.isAddNewRecord = true;
                }

                if (this.listDispatchingOrders == null)
                {
                    listDispatchingOrders = new BindingList<DispatchingOrders>(dispatchingOrderList);
                }
                else
                {
                    foreach (var item in dispatchingOrderList)
                    {
                        this.listDispatchingOrders.Add(item);
                    }
                }

                if (dispatchingOrderList.Count == 0)
                {
                    this.btnNew_Click(null, null);
                }

                listDispatchingOrders.AllowNew = true;
                hasLoadedDataParent = true;
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                Wait.Close();
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Wait.Close();
        }

        /// <summary>
        /// Load dispatching Order Details by current Dispatching Order selected
        /// </summary>
        /// <param name="DispatchingOrderID">int</param>
        public void LoadDataDetail(int DispatchingOrderID)
        {
            try
            {
                listOrderDetail.Clear();

                Common.Process.RefreshData.Refresh(gridControlOrderDetail, () =>
                {
                    gridControlOrderDetail.DataSource = null;
                    DataProcess<DispatchingProducts> daProducts = new DataProcess<DispatchingProducts>();
                    List<DispatchingProducts> lst = daProducts.Select(dp=>dp.DispatchingOrderID==DispatchingOrderID).ToList();
                    foreach (DispatchingProducts x in lst)
                    {
                        listOrderDetail.Add(x);
                    }
                    if (lst.Count <= 0)
                    {
                        listOrderDetail = new BindingList<DispatchingProducts>();
                    }
                    listOrderDetail.AllowNew = listOrderDetail.AllowRemove = true;
                    gridControlOrderDetail.DataSource = listOrderDetail.OrderBy(order => order.CreatedTime);
                    this.gridViewOrderDetail.FocusedRowHandle = this.rowIndexFocused;

                    if (listOrderDetail.Count > 0)
                    {
                        this.lookUpEditCustomerID.ReadOnly = true;
                    }
                    else
                    {
                        this.lookUpEditCustomerID.ReadOnly = false;
                    }
                });
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void InitLookup()
        {
            try
            {
                var listCustomer = AppSetting.CustomerList.Where(a => a.CustomerDiscontinued == false).ToList();

                // Update data on control by other thread
                lookUpEditCustomerID.Properties.DataSource = listCustomer;
                lookUpEditCustomerID.Properties.DisplayMember = "CustomerNumber";
                lookUpEditCustomerID.Properties.ValueMember = "CustomerID";
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);

            }
        }

        private void InitLookupServices(int customerID)
        {
            try
            {
                if (this.dataNavigatorDispatchingOrders.Position < 0) return;
                var roInfo = this.listDispatchingOrders[this.dataNavigatorDispatchingOrders.Position];
                DataProcess<STVSServicesDefinitionListForLookup_Result> cc = new DataProcess<STVSServicesDefinitionListForLookup_Result>();
                List<STVSServicesDefinitionListForLookup_Result> list = cc.Executing("STVSServicesDefinitionListForLookup @CustomerID = {0},@OrderDate={1}", customerID, roInfo.DispatchingOrderDate).ToList();
                var listFilter = list.Where(s => !s.ServiceNumber.Contains("HDI")).ToList();
                lookUpEditHandlingOvertimeCategoryID.Properties.DataSource = listFilter;
                lookUpEditHandlingOvertimeCategoryID.Properties.DropDownRows = listFilter.Count;
                this.lookUpEditHandlingOvertimeCategoryID.Properties.DisplayMember = "ServiceNumber";
                this.lookUpEditHandlingOvertimeCategoryID.Properties.ValueMember = "ServiceID";
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
            }
        }

        private void InitWorkType()
        {
            DataProcess<WorkTypeDefinition> cc = new DataProcess<WorkTypeDefinition>();
            IEnumerable<WorkTypeDefinition> list = cc.Select();
            lkeWorkType.Properties.DataSource = list;
            this.lkeWorkType.Properties.DisplayMember = "WorkTypeName";
            this.lkeWorkType.Properties.ValueMember = "WorkTypeCode";
        }

        private void LoadDockDoor(string orderNumber)
        {
            DataProcess<STcomboDockDoorID_Result> dockDoorDA = new DataProcess<STcomboDockDoorID_Result>();
            this.lkeDockNumber.Properties.DataSource = dockDoorDA.Executing(" STcomboDockDoorID @OrderNumber={0}", orderNumber);
            this.lkeDockNumber.Properties.ValueMember = "DockDoorID";
            this.lkeDockNumber.Properties.DisplayMember = "DockNumber";
        }
        private void InitLookupProducts(int customerID)
        {
            try
            {
                DataProcess<STComboProductIDDO_Result> pc = new DataProcess<STComboProductIDDO_Result>();
                listProduct = pc.Executing("STComboProductIDDO @CustomerID = {0}, @SortProduct = {1}", customerID, 0).ToList();
                repositoryItemLookUpEditProductID.DataSource = repositoryItemLookUpEditProductName.DataSource = listProduct;
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
            }
        }

        private void InitCustomerClients()
        {
            try
            {
                int customerID = Convert.ToInt32(lookUpEditCustomerID.EditValue);
                DataProcess<STCustomerClients_Result> cc = new DataProcess<STCustomerClients_Result>();
                List<STCustomerClients_Result> listCustomers = cc.Executing("STCustomerClientNameWithClientCodes @CustomerID = {0}", customerID).ToList();
                this.lookUpEditCustomerClientID.Properties.ValueMember = "CustomerClientID";
                this.lookUpEditCustomerClientID.Properties.DisplayMember = "CustomerClientName";
                lookUpEditCustomerClientID.Properties.DataSource = listCustomers;
                //lookUpEditCustomerClientID.EditValue = listCustomers[0].CustomerClientID;
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
            }
        }
        #endregion

        #region Events
        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void frmDispatchingOrders_FormClosing(object sender, FormClosingEventArgs e)
        {
            //foreach (var controlValidate in this.validateList)
            //{
            //    if (controlValidate.Value)
            //    {
            //        controlValidate.Key.Focus();
            //        e.Cancel = true;
            //        return;
            //    }
            //}

            this.Hide();
            e.Cancel = true;
        }

        private void lookUpEditCustomerID_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            dateEditDispatchingOrderDate.Focus();
        }

        private void iCloseDispatchingOrder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void dataNavigatorDispatchingOrders_PositionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataNavigatorDispatchingOrders.Position >= 0)
                {
                    if (!string.IsNullOrEmpty(textEditOrderID.Tag.ToString()) || lookUpEditCustomerID.Tag != null)
                    {
                        var dispatchingOrderSelected = this.listDispatchingOrders[this.dataNavigatorDispatchingOrders.Position];
                        isUpdate = false;
                        isLockOrder = dispatchingOrderSelected.Status;

                        // Check the controls is allow active
                        this.CheckLockControls();
                        lookUpEditCustomerID.EditValue = dispatchingOrderSelected.CustomerID;
                        this.lkeWorkType.EditValue = dispatchingOrderSelected.WorkTypeCode;
                        this.dateEditDispatchingOrderDate.DateTime = dispatchingOrderSelected.DispatchingOrderDate;
                        lookUpEditCustomerClientID.EditValue = dispatchingOrderSelected.CustomerClientID;
                        lke_TimeSlotID.EditValue = dispatchingOrderSelected.TimeSlotID;
                        this.orderTraceDate = this.dateEditDispatchingOrderDate.DateTime;
                        if (!string.IsNullOrEmpty(Convert.ToString(spinEditTemperature.Tag)))
                        {
                            spinEditTemperature.EditValue = Convert.ToSingle(spinEditTemperature.Tag);
                        }
                        else
                        {
                            this.spinEditTemperature.EditValue = null;
                        }

                        textEditDispatchingCreatedTime.Text = Convert.IsDBNull(textEditDispatchingCreatedTime.Tag) ? string.Empty : Convert.ToDateTime(textEditDispatchingCreatedTime.Tag).ToString("dd/MM/yyyy HH:mm");
                        textEditDispatchingCreatedBy.Text = Convert.ToString(textEditDispatchingCreatedBy.Tag);

                        textEditSealNumber.Text = Convert.ToString(textEditSealNumber.Tag);
                        this.textEditVehicleNumber.Text = Convert.ToString(this.textEditVehicleNumber.Tag);
                        this.textEditCustomerOrderNumber.Text = Convert.ToString(this.textEditCustomerOrderNumber.Tag);
                        this.textEditCustomerOrderNumber2.Text = Convert.ToString(this.textEditCustomerOrderNumber2.Tag);
                        this.txtPickingPercent.Text = Convert.ToString(this.txtPickingPercent.Tag);
                        this.txtProcessStatus.Text = Convert.ToString(this.txtProcessStatus.Tag);
                        txtEDIMessageSentTime.Text = Convert.ToString(this.txtEDIMessageSentTime.Tag);
                        textEditInernalRemark.Text = Convert.ToString(textEditInernalRemark.Tag);
                        memoEditTruckAndDetail.Text = Convert.ToString(memoEditTruckAndDetail.Tag);
                        if (timeEditStartTime.Tag == null || timeEditStartTime.Tag.ToString().Trim() == "")
                            timeEditStartTime.EditValue = null;
                        else
                            timeEditStartTime.EditValue = Convert.ToDateTime(timeEditStartTime.Tag);

                        if (timeEditEndTime.Tag == null || timeEditEndTime.Tag.ToString().Trim() == "")
                            timeEditEndTime.EditValue = null;
                        else
                            timeEditEndTime.EditValue = Convert.ToDateTime(timeEditEndTime.Tag);
                        if (dispatchingOrderSelected.HandlingOvertimeCategoryID != null)
                        {
                            lookUpEditHandlingOvertimeCategoryID.EditValue = (int)dispatchingOrderSelected.HandlingOvertimeCategoryID;
                        }

                        isUpdate = true;

                        // Load dock door
                        this.LoadDockDoor(dispatchingOrderSelected.DispatchingOrderNumber);
                        this.lkeDockNumber.EditValue = dispatchingOrderSelected.DockDoorID;

                        // Load detail data
                        LoadDataDetail(dispatchingOrderSelected.DispatchingOrderID);

                        // Detect data type will load on UI
                        this.ReLoadSubData();

                        this.LoadDataExpiredDate(dispatchingOrderSelected.DispatchingOrderID, 0);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
            }
        }

        private void lookUpEditCustomerID_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpEditCustomerID.ItemIndex < 0) return;
            try
            {
                int customerID = Convert.ToInt32(lookUpEditCustomerID.EditValue);

                string customerName = lookUpEditCustomerID.Properties.GetDataSourceValue("CustomerName", lookUpEditCustomerID.ItemIndex).ToString();
                customerType = lookUpEditCustomerID.Properties.GetDataSourceValue("CustomerType", lookUpEditCustomerID.ItemIndex).ToString();
                dispatchingByClient = Convert.ToBoolean(lookUpEditCustomerID.Properties.GetDataSourceValue("DispatchingByClient", lookUpEditCustomerID.ItemIndex));

                textEditCustomerName.Text = customerName;
                InitLookupServices(customerID);
                InitLookupProducts(customerID);
                InitCustomerClients();
                this.Text = textEditOrderID.Text.Trim() + " " + lookUpEditCustomerID.Text.Trim();
                if (isUpdate || textEditOrderID.Text.Equals("DO-New *"))
                {
                    UpdateDO();
                }
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                textEditCustomerName.Text = "";
            }
        }

        private void lookUpEditHandlingOvertimeCategoryID_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpEditHandlingOvertimeCategoryID.ItemIndex < 0) return;
            try
            {
                this.textEditServiceName.Text = string.Empty;
                if (lookUpEditHandlingOvertimeCategoryID.EditValue != null)
                {
                    string serviceName = lookUpEditHandlingOvertimeCategoryID.Properties.GetDataSourceValue("ServiceName", lookUpEditHandlingOvertimeCategoryID.ItemIndex).ToString();
                    textEditServiceName.Text = serviceName;
                    if (isUpdate)
                    {
                        if (this.lookUpEditHandlingOvertimeCategoryID.EditValue != null && Convert.ToInt32(this.lookUpEditHandlingOvertimeCategoryID.EditValue) == 346)
                        {
                            var msgConfirm = MessageBox.Show("Chọn dịch vụ không tính phí sẽ được gửi thông tin đến giám sát, bạn có muốn chọn dịch vụ này ?", "TWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (msgConfirm.Equals(DialogResult.No))
                            {
                                this.lookUpEditHandlingOvertimeCategoryID.EditValue = null;
                                this.textEditServiceName.Text = string.Empty;
                                return;
                            }
                            // Send email
                            System.Text.StringBuilder txtBody = new System.Text.StringBuilder();
                            txtBody.Append("Phiếu Xuất: ");
                            txtBody.Append(this.textEditOrderID.Text);
                            txtBody.Append(Environment.NewLine);
                            txtBody.Append("Khách Hàng: ");
                            txtBody.Append(lookUpEditCustomerID.Text);
                            txtBody.Append(" - ");
                            txtBody.Append(textEditCustomerName.Text);
                            txtBody.Append(Environment.NewLine);
                            txtBody.Append("Được chỉ đinh dịch vụ không tính phí");
                            txtBody.Append(Environment.NewLine);
                            txtBody.Append("Mã dịch vụ: ");
                            txtBody.Append(this.lookUpEditHandlingOvertimeCategoryID.EditValue);
                            txtBody.Append(" - ");
                            txtBody.Append("Tên dịch vụ: ");
                            txtBody.Append(serviceName);
                            txtBody.Append(Environment.NewLine);
                            txtBody.Append("Người Tạo:");
                            txtBody.Append(AppSetting.CurrentEmployee.VietnamName);
                            txtBody.Append(Environment.NewLine);
                            txtBody.Append("Thời gian tạo:");
                            txtBody.Append(DateTime.Now);
                            string body = this.textEditCustomerOrderNumber.Text + " ";
                            IList<string> attach = new List<string>();
                            Common.Process.DataTransfer.SendMail("thetrung@necs.vn;", "TWMS Thay đổi dịch vụ không tính phí", txtBody.ToString(), attach.ToArray());
                            UpdateDO();
                        }
                        else
                        {
                            UpdateDO();
                        }

                    }
                }
                else
                {
                    textEditServiceName.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                textEditServiceName.Text = "";
            }
        }

        private void repositoryItemLookUpEditProductID_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            gridViewOrderDetail.PostEditor();
            gridViewOrderDetail.UpdateSummary();
        }

        private void gridViewOrderDetail_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            try
            {
                if (e.Value != null && gridViewOrderDetail.FocusedColumn.FieldName == "ProductID")
                {
                    int _pID = Convert.ToInt32(e.Value);
                    if (_pID > 0)
                    {
                        STComboProductIDDO_Result _p = listProduct.FirstOrDefault(p => p.tmpProductRemainID == _pID);
                        gridViewOrderDetail.SetFocusedRowCellValue(gridViewOrderDetail.Columns["ProductName"], _p.tmpProductRemainName);

                        gridViewOrderDetail.SetFocusedRowCellValue(gridViewOrderDetail.Columns["ProductNumber"], _p.tmpProductRemainNumber);

                        gridViewOrderDetail.SetFocusedRowCellValue(gridViewOrderDetail.Columns["ProductID"], _pID);
                        gridViewOrderDetail.SetFocusedRowCellValue(gridViewOrderDetail.Columns["WeightPerPackage"], _p.tmpWeightPerPackage);
                        int _qty = Convert.ToInt32(gridViewOrderDetail.GetFocusedRowCellValue(gridViewOrderDetail.Columns["TotalPackages"]));
                        //gridViewOrderDetail.SetFocusedRowCellValue(gridViewOrderDetail.Columns["TotalUnits"], _qty * _p.Inners);
                        gridViewOrderDetail.SetFocusedRowCellValue(gridViewOrderDetail.Columns["TotalWeight"], _qty * _p.tmpWeightPerPackage);
                        gridViewOrderDetail.SetFocusedRowCellValue(gridViewOrderDetail.Columns["UserName"], AppSetting.CurrentUser.LoginName);
                        string _remark = "";
                        if (gridViewOrderDetail.GetFocusedRowCellValue(gridViewOrderDetail.Columns["Remark"]) != null)
                            _remark = gridViewOrderDetail.GetFocusedRowCellValue(gridViewOrderDetail.Columns["Remark"]).ToString();
                        _remark = _remark.Replace("~Cân Gross!!!", "");
                        //if (_p.GrossWeightPerPackage == null || _p.GrossWeightPerPackage == 0)
                        //{
                        //    _remark += "~Cân Gross!!!";
                        //}
                        gridViewOrderDetail.SetFocusedRowCellValue(gridViewOrderDetail.Columns["Remark"], _remark);

                        gridViewOrderDetail.FocusedColumn = gridViewOrderDetail.Columns["TotalPackages"];
                        gridViewOrderDetail.PostEditor();
                        gridViewOrderDetail.UpdateSummary();
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

        private void repositoryItemSpinEditTotalPackages_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Return))
            {
                QuantityUpdate();
                SendKeys.Send("{TAB}");
            }
        }

        private void repositoryItemSpinEditTotalPackages_Leave(object sender, EventArgs e)
        {
            QuantityUpdate();
        }

        private void gridViewOrderDetail_DoubleClick(object sender, EventArgs e)
        {
            this.rowIndexFocused = this.gridViewOrderDetail.FocusedRowHandle;
            this.objSelected = (DispatchingProducts)this.gridViewOrderDetail.GetFocusedRow();
            GridHitInfo hi = gridViewOrderDetail.CalcHitInfo(gridControlOrderDetail.PointToClient(MousePosition));
            if (hi.InRowCell)
            {
                switch (hi.Column.Name)
                {
                    case "gridColumnProductID":
                        try
                        {
                            if (gridViewOrderDetail.GetFocusedRowCellValue(gridViewOrderDetail.Columns["ProductID"]) != null && gridViewOrderDetail.GetFocusedRowCellValue(gridViewOrderDetail.Columns["ProductID"]).ToString() != "0")
                            {
                                int _pID = Convert.ToInt32(gridViewOrderDetail.GetFocusedRowCellValue(gridViewOrderDetail.Columns["ProductID"]));
                                if (_pID > 0)
                                {
                                    frm_MSS_Products frmProducts = frm_MSS_Products.Instance;
                                    if (!frmProducts.Enabled) return;
                                    frmProducts.ProductIDLookup = _pID;
                                    frmProducts.ShowDialog();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            log.Error("==> Error is unexpected");
                            log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                            XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case "gridColumnProductNameText":
                    case "gridColumnProductName":
                        //try
                        //{
                        //    if (new dlgChangeProduct(Convert.ToInt32(lookUpEditCustomerID.EditValue), objSelected.ProductID, objSelected.DispatchingOrderDetailID, "TestUser").ShowDialog() == DialogResult.OK)
                        //    {
                        //        LoadDataDetail(Convert.ToInt32(textEditOrderID.Tag));
                        //    }
                        //}
                        //catch
                        //{
                        //}
                        break;
                    case "gridColumnHold":
                        XtraMessageBox.Show("Show dialog Hold Status for this Product ID.\r\nComing soon...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case "gridColumnStatus":
                        byte status = Convert.ToByte(gridViewOrderDetail.GetRowCellValue(gridViewOrderDetail.FocusedRowHandle, gridViewOrderDetail.Columns["Status"]));
                        if (status != 1 || this.isLockOrder) return;

                        if (this.lke_TimeSlotID.EditValue == null || Convert.ToInt32(lke_TimeSlotID.EditValue) <= 0)
                        {
                            MessageBox.Show("Please update time slot before confirm !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.lke_TimeSlotID.Focus();
                            this.lke_TimeSlotID.ShowPopup();
                            return;
                        }

                        // 1. Check start time
                        DataProcess<Gate_TruckInOut> truckInOutDA = new DataProcess<Gate_TruckInOut>();
                        var listTruck = truckInOutDA.Select(t => t.OrderNumber.Equals(this.textEditOrderID.Text)).ToList();
                        if (listTruck == null && listTruck.Count() > 0)
                        {
                            var truckSelected = listTruck.OrderByDescending(p => p.TruckInOutID).FirstOrDefault();
                            if (truckSelected != null)
                            {
                                if (truckSelected.TimeIn != null)
                                {
                                    if (truckSelected.TimeIn > DateTime.Now)
                                    {
                                        System.Text.StringBuilder msgContent = new System.Text.StringBuilder();
                                        msgContent.Append("Start Time or Time In is not correct! ");
                                        msgContent.Append(Environment.NewLine);
                                        msgContent.Append("Start time must be later time in! ");
                                        msgContent.Append(Environment.NewLine);
                                        msgContent.Append("- Time In: ");
                                        msgContent.Append(truckSelected.TimeIn);
                                        msgContent.Append(Environment.NewLine);
                                        msgContent.Append("- Start time: ");
                                        msgContent.Append(DateTime.Now.ToShortDateString());

                                        MessageBox.Show(msgContent.ToString(), "TPWMS");
                                    }
                                }
                            }
                        }

                        // 1.Check customer was billed
                        // 2. Check hold product
                        var currentCustomer = AppSetting.CustomerList.Where(c => c.Hold == true && c.CustomerID == Convert.ToInt32(lookUpEditCustomerID.Tag)).FirstOrDefault();
                        if (currentCustomer != null)
                        {
                            if ((bool)currentCustomer.Hold)
                            {
                                if (!this.CheckPermission())
                                {
                                    //MsgBox ("Can not confirm because this customer is on hold"), vbCritical, "WMS-2022"
                                    MessageBox.Show("Can not confirm because this customer is on hold", "TPWMS");
                                    return;
                                }
                                else
                                {
                                    MessageBox.Show("This customer is on hold, be careful! ", "TPWMS");
                                }
                            }
                        }
                        int dispatchingProductID = Convert.ToInt32(this.gridViewOrderDetail.GetFocusedRowCellValue("DispatchingProductID"));
                        // Check Qty sync with wareNavi is equal with qty RODetail send
                        int qtyDiff = Convert.ToInt32(FileProcess.LoadTable("STCheckDOQTYSyncBeforeConfirm @DispatchingProductID=" + dispatchingProductID).Rows[0]["DifferenceQty"]);
                        if (qtyDiff > 0)
                        {
                            XtraMessageBox.Show("Qty booking and Qty actual is invalid! Please check it before confirm", "TWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (XtraMessageBox.Show("Are you sure to confirm this Dispatching Product ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            ObjectParameter hasDifference = new ObjectParameter("hasDifference", false);
                            DispatchingOrderDetailsDA dispatchingOrderDetailDA = new DA.Warehouse.DispatchingOrderDetailsDA();
                            dispatchingOrderDetailDA.STDispatchingCartonScanCheck(Convert.ToInt32(objSelected.DispatchingOrderID), Convert.ToInt32(objSelected.TransactionID), hasDifference);

                            TransactionDAC tc = new TransactionDAC();
                            tc.STConfirmOne(Convert.ToInt32(objSelected.TransactionID), 2, AppSetting.CurrentUser.LoginName);
                            gridViewOrderDetail.SetFocusedRowCellValue(gridViewOrderDetail.Columns["Status"], 2);
                            gridViewOrderDetail.SetFocusedRowCellValue(gridViewOrderDetail.Columns["ComfirmedTime"], DateTime.Now);
                        }

                        break;
                    case "gridColumnTotalPackages":
                        {
                            int dispatchedProductID = Convert.ToInt32(this.gridViewOrderDetail.GetFocusedRowCellValue("DispatchingProductID"));
                            if (this.frmQtyDetail == null || this.frmQtyDetail.IsDisposed)
                                this.frmQtyDetail = new frm_WM_Dialog_DispatchingOrderDetails(dispatchedProductID);
                            else
                                this.frmQtyDetail.InitData(dispatchedProductID);
                            frmQtyDetail.Show();
                            break;
                        }
                    case "gridColumn13":
                        {
                            var currentDip = (DispatchingProducts)this.gridViewOrderDetail.GetFocusedRow();
                            this.LoadDispatchingOrderDetail(currentDip);
                            break;
                        }
                    //SetLocation();
                    case "gridColumnPallets":
                        PalletInfo();
                        break;
                }
            }
        }

        /// <summary>
        ///  Check permission of current user
        /// </summary>
        /// <returns>bool</returns>
        private bool CheckPermission()
        {
            return true;
        }

        private void gridViewOrderDetail_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            int rOID = UpdateDO();
        }

        private void iPalletInfo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PalletInfo();
        }

        private void textEditOrderID_EditValueChanged(object sender, EventArgs e)
        {
            this.Text = textEditOrderID.Text.Trim() + " " + lookUpEditCustomerID.Text.Trim();
        }

        private void lookUpEditCustomerID_DoubleClick(object sender, EventArgs e)
        {
            Customers currentCustomer = AppSetting.CustomerList.Where(c => c.CustomerID == Convert.ToInt32(this.lookUpEditCustomerID.EditValue)).FirstOrDefault();
            frm_MSS_Customers frmCustomer = MasterSystemSetup.frm_MSS_Customers.Instance;
            if (!frmCustomer.Enabled) return;
            frmCustomer.CurrentCustomers = currentCustomer;
            frmCustomer.WindowState = FormWindowState.Normal;
            frmCustomer.BringToFront();
            frmCustomer.Show();
        }

        private void textEditCustomerName_DoubleClick(object sender, EventArgs e)
        {
            Customers currentCustomer = AppSetting.CustomerList.Where(c => c.CustomerID == Convert.ToInt32(this.lookUpEditCustomerID.EditValue)).FirstOrDefault();
            frm_MSS_Customers frmCustomer = MasterSystemSetup.frm_MSS_Customers.Instance;
            if (!frmCustomer.Enabled) return;
            frmCustomer.CurrentCustomers = currentCustomer;
            frmCustomer.WindowState = FormWindowState.Normal;
            frmCustomer.BringToFront();
            frmCustomer.Show();
        }

        private void timeEditStartTime_Enter(object sender, EventArgs e)
        {
            if (timeEditStartTime.Text.Trim() == "")
                timeEditStartTime.EditValue = DateTime.Now;
        }

        private void timeEditEndTime_Enter(object sender, EventArgs e)
        {
            if (timeEditEndTime.Text.Trim() == "")
                timeEditEndTime.EditValue = DateTime.Now;
        }

        private void iAcceptAllLocations_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DialogResult ans = XtraMessageBox.Show("Click:\r\nYes for accept\r\nNo for unaccept\r\nCancel to quit.", "Accept", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                {
                    if (ans == DialogResult.Yes || ans == DialogResult.No)
                    {
                        TransactionDAC tc = new TransactionDAC();
                        switch (ans)
                        {
                            case DialogResult.Yes:
                                tc.STTransactionInsertAll(Convert.ToInt32(textEditOrderID.Tag), textEditOrderID.Text.Trim(), AppSetting.CurrentUser.LoginName, lookUpEditCustomerID.Text.Trim());
                                gridControlOrderDetail.DataSource = listOrderDetail;

                                break;
                            case DialogResult.No:
                                tc.STTransactionDeleteAll(Convert.ToInt32(textEditOrderID.Tag), false, AppSetting.CurrentUser.LoginName);
                                gridControlOrderDetail.DataSource = listOrderDetail;

                                break;
                        }
                        LoadDataDetail(Convert.ToInt32(textEditOrderID.Tag));
                        this.LoadDockDoor(this.textEditOrderID.Text);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
            }
        }

        private void iSelectProductQuickly_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (textEditOrderID.Tag != null)
            {
                bool requireClient = Convert.ToBoolean(lookUpEditCustomerID.Properties.GetDataSourceValue("DispatchingByClient", lookUpEditCustomerID.ItemIndex));
                if (requireClient)
                {
                    int clientValue = Convert.ToInt32(this.lookUpEditCustomerClientID.EditValue);
                    if (clientValue != 0)
                    {
                        var frm = new frm_WM_Dialog_DOSelectProductQuickly(textEditOrderID.Text, Convert.ToInt32(textEditOrderID.Tag), Convert.ToInt32(lookUpEditCustomerID.EditValue), lookUpEditCustomerID.Text);
                        if (!frm.Enabled) return;
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            LoadDataDetail(Convert.ToInt32(textEditOrderID.Tag));
                        }
                    }
                    else
                    {
                        MessageBox.Show("This customer requires Input Client", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.lookUpEditCustomerClientID.Focus();
                        this.lookUpEditCustomerClientID.ShowPopup();
                        this.lookUpEditCustomerClientID.GetPopupEditForm();
                    }
                }
                else
                {
                    var frm = new frm_WM_Dialog_DOSelectProductQuickly(textEditOrderID.Text, Convert.ToInt32(textEditOrderID.Tag), Convert.ToInt32(lookUpEditCustomerID.EditValue), lookUpEditCustomerID.Text);
                    if (!frm.Enabled) return;
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        LoadDataDetail(Convert.ToInt32(textEditOrderID.Tag));
                    }
                }

            }

            this.LoadDockDoor(this.textEditOrderID.Text);
            this.LoadDataExpiredDate(Convert.ToInt32(textEditOrderID.Tag), 0);
        }

        private void iSelectPallet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (textEditOrderID.Tag != null)
            {
                bool requireClient = Convert.ToBoolean(lookUpEditCustomerID.Properties.GetDataSourceValue("DispatchingByClient", lookUpEditCustomerID.ItemIndex));
                if (requireClient)
                {
                    int clientValue = Convert.ToInt32(this.lookUpEditCustomerClientID.EditValue);
                    if (clientValue > 1)
                    {
                        NewProduct();
                    }
                    else
                    {
                        MessageBox.Show("This customer requires Input Client", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.lookUpEditCustomerClientID.Focus();
                        this.lookUpEditCustomerClientID.ShowPopup();
                        this.lookUpEditCustomerClientID.GetPopupEditForm();
                        return;
                    }
                }
                else
                {
                    NewProduct();
                }
            }
            this.LoadDataExpiredDate(Convert.ToInt32(textEditOrderID.Tag), 0);
            this.lookUpEditCustomerID.Focus();
        }
        private void NewProduct()
        {
            var frmSelectPallet = new frm_WM_Dialog_DOSelectPallets(textEditOrderID.Text, Convert.ToInt32(textEditOrderID.Tag), Convert.ToInt32(lookUpEditCustomerID.EditValue), lookUpEditCustomerID.Text, customerType);
            if (!frmSelectPallet.Enabled) return;
            frmSelectPallet.ShowDialog();
            if (!frmSelectPallet.IsShowDetail) return;

            this.productIDToDisplayDetail = frmSelectPallet.ProductIDSelected;
            LoadDataDetail(Convert.ToInt32(textEditOrderID.Tag));
            this.objSelected = this.listOrderDetail.Where(p => p.ProductID == frmSelectPallet.ProductIDSelected).OrderByDescending(p => p.DispatchingProductID).FirstOrDefault();
            int index = this.gridViewOrderDetail.FindRow(this.objSelected);
            this.gridViewOrderDetail.FocusedRowHandle = index;
            this.LoadDispatchingOrderDetail(this.objSelected);
            this.LoadDockDoor(this.textEditOrderID.Text);
            this.gridViewOrderDetail.FocusedRowHandle = index;
        }
        private void LoadDispatchingOrderDetail(DispatchingProducts objectProducts)
        {
            customerType = lookUpEditCustomerID.Properties.GetDataSourceValue("CustomerType", lookUpEditCustomerID.ItemIndex).ToString();
            var currentDispatchingProduct = this.listOrderDetail.Where(d => d.DispatchingProductID == objectProducts.DispatchingProductID).FirstOrDefault();

            var currentDO = dispatchingOrderDA.Select(dis => dis.DispatchingOrderID == currentDispatchingProduct.DispatchingOrderID).FirstOrDefault();
            if (currentDO != null && currentDO.Status)
            {
                MessageBox.Show("This DO has locked, could not view DO detail", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this.frmDispatchingProduct == null)
            {
                this.frmDispatchingProduct = new frm_WM_DispatchingProduct(objectProducts, customerType, lookUpEditCustomerID.Text.Trim(), this.gridViewOrderDetail.GetFocusedRowCellValue("Status"));
            }
            else
            {
                this.frmDispatchingProduct.InitData(objectProducts, customerType, lookUpEditCustomerID.Text.Trim(), this.gridViewOrderDetail.GetFocusedRowCellValue("Status"));
            }
            if (!this.frmDispatchingProduct.Enabled) return;
            this.frmDispatchingProduct.ShowDialog();
            this.LoadDataDetail(Convert.ToInt32(this.textEditOrderID.Tag));

            // Set focused to NewProduct button on main menu
            btn_WM_NewProduct.ItemAppearance.Normal.BackColor = Color.FromArgb(153, 180, 209);
            btn_WM_NewProduct.Links[0].Focus();
        }

        private void memoEditTruckAndDetail_EditValueChanged(object sender, EventArgs e)
        {
            this.isTruckModified = true;
            if (memoEditTruckAndDetail.Text.Trim() == "")
            {
                btn_WM_NewProduct.Enabled = btn_WM_NewAllProducts.Enabled = false;
            }
            else
            {
                btn_WM_NewProduct.Enabled = btn_WM_NewAllProducts.Enabled = true;
            }
        }

        private void lookUpEditCustomerClientID_EditValueChanged(object sender, EventArgs e)
        {
            if (isUpdate && this.lookUpEditCustomerClientID.EditValue != null)
            {
                UpdateDO();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            //dataNavigatorDispatchingOrders.Buttons.DoClick(dataNavigatorDispatchingOrders.Buttons.Append);
            while (this.listDispatchingOrders == null)
            {
                Application.DoEvents();
            }
            Common.Process.RefreshData.Refresh(textEditOrderID, () =>
            {
                listOrderDetail.Clear();
                this.LoadDataDetail(0);
                dataNavigatorDispatchingOrders.Position = listDispatchingOrders.Count;
                textEditOrderID.Text = "DO-New *";
                textEditOrderID.Tag = 0;
                memoEditTruckAndDetail.Text = "";
                textEditDispatchingCreatedTime.Text = DateTime.Now.ToString("dd/MM/yyyy");
                memoEditTruckAndDetail.Tag = string.Empty;
                dateEditDispatchingOrderDate.EditValue = DateTime.Now.Date;
                timeEditStartTime.Tag = timeEditStartTime.EditValue = null; // DateTime.Now;
                timeEditEndTime.Tag = timeEditEndTime.EditValue = null; // DateTime.Now;
                spinEditTemperature.Tag = spinEditTemperature.EditValue = null;
                textEditSealNumber.Tag = textEditSealNumber.Text = "";
                this.textEditDispatchingOrderProgress.EditValue = null;
                this.lkeDockNumber.EditValue = null;
                this.textEditVehicleNumber.Tag = this.textEditVehicleNumber.Text = string.Empty;
                this.textEditCustomerOrderNumber.Tag = this.textEditCustomerOrderNumber.Text = string.Empty;
                this.textEditCustomerOrderNumber2.Tag = this.textEditCustomerOrderNumber2.Text = string.Empty;
                this.txtPickingPercent.Tag = null;
                this.txtPickingPercent.Text = string.Empty;
                this.txtProcessStatus.Tag = null;
                this.txtProcessStatus.Text = string.Empty;
                this.txtEDIMessageSentTime.Tag = null;
                this.txtEDIMessageSentTime.Text = string.Empty;

                textEditInernalRemark.Tag = textEditInernalRemark.Text = "";
                lookUpEditCustomerID.Tag = lookUpEditCustomerID.EditValue = null;
                this.lookUpEditHandlingOvertimeCategoryID.EditValue = null;
                this.lookUpEditCustomerClientID.EditValue = null;
                this.lke_TimeSlotID.EditValue = null;
                this.textEditServiceName.Text = string.Empty;
                this.comboBoxEdit1.EditValue = null;
                lookUpEditCustomerID.ReadOnly = false;
                lookUpEditCustomerID.Focus();
                lookUpEditCustomerID.ShowPopup();
            });
        }
        #endregion

        private void QuantityUpdate()
        {
            try
            {
                gridViewOrderDetail.PostEditor();
                int _qty = 0;
                int _pID;
                _qty = Convert.ToInt32(gridViewOrderDetail.GetFocusedRowCellValue(gridViewOrderDetail.Columns["TotalPackages"]));
                if (gridViewOrderDetail.GetFocusedRowCellValue(gridViewOrderDetail.Columns["ProductID"]) != null && gridViewOrderDetail.GetFocusedRowCellValue(gridViewOrderDetail.Columns["ProductID"]).ToString() != "0")
                {
                    _pID = Convert.ToInt32(gridViewOrderDetail.GetFocusedRowCellValue(gridViewOrderDetail.Columns["ProductID"]));
                    if (_pID > 0)
                    {
                        STComboProductIDDO_Result _p = listProduct.FirstOrDefault(p => p.tmpProductRemainID == _pID);
                        //gridViewOrderDetail.SetFocusedRowCellValue(gridViewOrderDetail.Columns["TotalUnits"], _qty * _p.Inners);
                        //gridViewOrderDetail.SetFocusedRowCellValue(gridViewOrderDetail.Columns["TotalWeight"], _qty * _p.WeightPerPackage);
                    }
                }
                else
                {
                    gridViewOrderDetail.SetFocusedRowCellValue(gridViewOrderDetail.Columns["TotalUnits"], 0);
                    gridViewOrderDetail.SetFocusedRowCellValue(gridViewOrderDetail.Columns["TotalWeight"], 0);

                }
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void DoRowDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRowCell)
            {
                switch (info.Column.Name)
                {
                    case "gridColumnProductID":
                        try
                        {
                            if (gridViewOrderDetail.GetFocusedRowCellValue(gridViewOrderDetail.Columns["ProductID"]) != null && gridViewOrderDetail.GetFocusedRowCellValue(gridViewOrderDetail.Columns["ProductID"]).ToString() != "0")
                            {
                                int _pID = Convert.ToInt32(gridViewOrderDetail.GetFocusedRowCellValue(gridViewOrderDetail.Columns["ProductID"]));
                                if (_pID > 0)
                                {
                                    frm_MSS_Products frmProducts = frm_MSS_Products.Instance;
                                    frmProducts.ProductIDLookup = _pID;
                                    if (!frmProducts.Enabled) return;
                                    frmProducts.Show();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            log.Error("==> Error is unexpected");
                            log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                            XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case "gridColumnProductNameText":
                        break;
                    case "gridColumnHold":
                        XtraMessageBox.Show("Show dialog Hold Status for this Product ID.\r\nComing soon...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case "gridColumnStatus":
                        byte status = Convert.ToByte(gridViewOrderDetail.GetRowCellValue(gridViewOrderDetail.FocusedRowHandle, gridViewOrderDetail.Columns["Status"]));
                        if (status == 1)
                            if (XtraMessageBox.Show("Are you sure to confirm this Dispatching Product ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                TransactionDAC tc = new TransactionDAC();
                                //int transactionID = Convert.ToInt32(gridViewOrderDetail.GetRowCellValue(gridViewOrderDetail.FocusedRowHandle, gridViewOrderDetail.Columns["TransactionID"]));
                                tc.STConfirmOne(Convert.ToInt32(objSelected.TransactionID), 1, AppSetting.CurrentUser.LoginName);
                                gridViewOrderDetail.SetFocusedRowCellValue(gridViewOrderDetail.Columns["Status"], 2);
                            }
                        break;
                    case "gridColumnTotalPackages":
                    case "gridColumn13":
                        {
                            var currentDip = (DispatchingProducts)this.gridViewOrderDetail.GetFocusedRow();
                            this.LoadDispatchingOrderDetail(currentDip);
                            break;
                        }
                    case "gridColumnPallets":
                        PalletInfo();
                        break;
                }
            }
        }

        private void PalletInfo()
        {
            try
            {
                int customerID = Convert.ToInt32(lookUpEditCustomerID.EditValue);
                int productID = Convert.ToInt32(gridViewOrderDetail.GetRowCellValue(gridViewOrderDetail.FocusedRowHandle, gridViewOrderDetail.Columns["ProductID"]));
                if (this.palletInfo == null)
                {
                    this.palletInfo = new frm_WM_PalletInfo(customerID, productID);
                }
                else
                {
                    this.palletInfo.InitData(customerID, productID);
                }
                this.palletInfo.Show();
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
            }
        }

        private int UpdateDO()
        {
            int rOID = 0;
            bool isNew = false;
            if (dxValidationProviderRO.Validate())
            {
                DispatchingOrders dO = new DispatchingOrders();
                if (textEditOrderID.Tag == null || Convert.IsDBNull(textEditOrderID.Tag) || Convert.ToInt32(textEditOrderID.Tag) == 0)
                {
                    isNew = true;
                    dO.DispatchingOrderDate = dateEditDispatchingOrderDate.DateTime.Date;
                    dO.CustomerID = Convert.ToInt32(lookUpEditCustomerID.EditValue);
                    if (dO.CustomerID <= 0)
                    {
                        MessageBox.Show("Lỗi rồi ['CustomerID<=0'], dừng lại và gọi ngay IT xem trường hợp này", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return 0;
                    }
                    if (this.lke_TimeSlotID.EditValue != null) dO.TimeSlotID = Convert.ToInt32(this.lke_TimeSlotID.EditValue);
                    dO.CustomerClientID = Convert.ToInt32(lookUpEditCustomerClientID.EditValue);
                    dO.Status = false;
                    if (timeEditStartTime.EditValue != null)
                        dO.StartTime = timeEditStartTime.DateTime;
                    else
                        dO.StartTime = null;
                    if (timeEditEndTime.EditValue != null)
                        dO.EndTime = timeEditEndTime.DateTime;
                    else
                        dO.EndTime = null;
                    dO.SpecialRequirement = memoEditTruckAndDetail.Text;
                    dO.Temperature = Convert.ToString(spinEditTemperature.EditValue);
                    dO.SealNumber = textEditSealNumber.Text.Trim();
                    if (this.textEditDispatchingOrderProgress.EditValue != null) dO.DispatchingOrderProgress = Convert.ToByte(this.textEditDispatchingOrderProgress.EditValue);
                    if (this.lkeDockNumber.EditValue != null) dO.DockDoorID = Convert.ToInt32(this.lkeDockNumber.EditValue);

                    dO.VehicleNumber = this.textEditVehicleNumber.Text;
                    dO.CustomerClientID = 1;// default value =1
                    dO.CustomerOrderNumber = this.textEditCustomerOrderNumber.Text;
                    dO.CustomerOrderNumber2 = this.textEditCustomerOrderNumber2.Text;
                    //dO.PickingPercentage = Convert.ToDouble(this.txtPickingPercent.EditValue);
                    //dO.ProcessingStatus = Convert.ToByte(this.txtProcessStatus.EditValue);
                    dO.HandlingOvertimeCategoryID = Convert.ToInt16(lookUpEditHandlingOvertimeCategoryID.EditValue);
                    dO.InternalRemark = textEditInernalRemark.Text.Trim();
                    dO.DispatchingCreatedTime = DateTime.Now;
                    dO.Owner = AppSetting.CurrentUser.LoginName;
                    dO.CustomerNumber = lookUpEditCustomerID.Text.Trim();
                    if (this.lkeWorkType.EditValue != null)
                        dO.WorkTypeCode = Convert.ToInt32(this.lkeWorkType.EditValue);
                    //dO = dOc.Create(dO);
                    dispatchingOrderDA.Insert(dO);
                    textEditOrderID.Text = dO.DispatchingOrderNumber = "DO-" + dO.DispatchingOrderID;
                    rOID = dO.DispatchingOrderID;
                    listDispatchingOrders.Insert(listDispatchingOrders.Count, dO);
                }
                else
                {
                    rOID = Convert.ToInt32(textEditOrderID.Tag);
                    dO = dispatchingOrderDA.Select(dis => dis.DispatchingOrderID == rOID).FirstOrDefault();
                    if (dO != null && dO.Status) return -1;
                    dO.DispatchingOrderID = rOID;
                    dO.DispatchingOrderNumber = "DO-" + dO.DispatchingOrderID;
                    dO.DispatchingOrderDate = dateEditDispatchingOrderDate.DateTime.Date;
                    dO.CustomerID = Convert.ToInt32(lookUpEditCustomerID.EditValue);
                    if (dO.CustomerID <= 0)
                    {
                        MessageBox.Show("Lỗi rồi ['CustomerID<=0'], dừng lại và gọi ngay IT xem trường hợp này", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return 0;
                    }
                    if (lookUpEditCustomerClientID.EditValue == null)
                    {
                        // Set default client is not specificed
                        lookUpEditCustomerClientID.EditValue = 1;
                    }

                    if (this.lke_TimeSlotID.EditValue != null) dO.TimeSlotID = Convert.ToInt32(this.lke_TimeSlotID.EditValue);
                    dO.CustomerClientID = Convert.ToInt32(lookUpEditCustomerClientID.EditValue);

                    dO.Temperature = Convert.ToString(spinEditTemperature.EditValue);
                    dO.Status = false;
                    if (timeEditStartTime.EditValue != null)
                        dO.StartTime = timeEditStartTime.DateTime;
                    else
                        dO.StartTime = null;
                    if (timeEditEndTime.EditValue != null)
                        dO.EndTime = timeEditEndTime.DateTime;
                    else
                        dO.EndTime = null;
                    dO.SpecialRequirement = memoEditTruckAndDetail.Text;
                    dO.SealNumber = textEditSealNumber.Text.Trim();
                    if (this.textEditDispatchingOrderProgress.EditValue != null) dO.DispatchingOrderProgress = Convert.ToByte(this.textEditDispatchingOrderProgress.EditValue);
                    if (this.lkeDockNumber.EditValue != null) dO.DockDoorID = Convert.ToInt32(this.lkeDockNumber.EditValue);
                    dO.VehicleNumber = this.textEditVehicleNumber.Text;
                    dO.CustomerOrderNumber = this.textEditCustomerOrderNumber.Text;
                    dO.CustomerOrderNumber2 = this.textEditCustomerOrderNumber2.Text;
                    //dO.PickingPercentage = Convert.ToDouble(this.txtPickingPercent.EditValue);
                    //dO.ProcessingStatus = Convert.ToByte(this.txtProcessStatus.EditValue);
                    dO.HandlingOvertimeCategoryID = Convert.ToInt16(lookUpEditHandlingOvertimeCategoryID.EditValue);
                    dO.InternalRemark = textEditInernalRemark.Text.Trim();
                    dO.CustomerNumber = lookUpEditCustomerID.Text.Trim();
                    if (this.lkeWorkType.EditValue != null)
                        dO.WorkTypeCode = Convert.ToInt32(this.lkeWorkType.EditValue);
                    dispatchingOrderDA.Update(dO);
                    textEditOrderID.Text = dO.DispatchingOrderNumber = "DO-" + dO.DispatchingOrderID;
                    listDispatchingOrders[dataNavigatorDispatchingOrders.Position] = dO;
                }
                if (isNew)
                    dataNavigatorDispatchingOrders.Position = listDispatchingOrders.Count;
            }
            return rOID;
        }

        private void GetObjectInfo(int selectedIndex)
        {
            try
            {
                objSelected = (DispatchingProducts)gridViewOrderDetail.GetFocusedRow();
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
            }
        }

        public void ShowPopupCustomer()
        {
            this.btnNew_Click(null, null);
        }

        public void ReloadData()
        {
            this.frm_WM_DispatchingOrders_VisibleChanged(null, null);
        }

        private void frm_WM_DispatchingOrders_VisibleChanged(object sender, EventArgs e)
        {
            if (!this.isFirstLoad && this.Visible)
            {
                this.InitLookup();
                this.InitWorkType();

                // Change location start to center screen
                this.StartPosition = FormStartPosition.CenterScreen;

                // Load list dispatching order detail
                this.LoadData();

                dataNavigatorDispatchingOrders.DataSource = this.listDispatchingOrders;
                dataNavigatorDispatchingOrders.Position = this.listDispatchingOrders.Count;

                if (isAddNewRecord)
                {
                    this.listDispatchingOrders.RemoveAt(0);
                    this.isAddNewRecord = false;
                }

                // Refresh sub data on dock panel
                this.ReLoadSubData();
            }

            /// When form is close then clear receiving Order ID
            if (!this.Visible)
            {
                dispatchingOrderIDInput = -1;
                this.rowIndexFocused = 0;
            }
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();

            if (this.Visible && dispatchingOrderIDInput <= 0)
            {
                this.btnNew_Click(sender, e);
            }

            // Show export form
            if (hasShowExportForm)
            {
                this.barButtonItem63_ItemClick(sender, null);
                hasShowExportForm = false;
            }
        }

        private void ReLoadSubData()
        {
            // Just only to refresh data for the dockpanel is visible
            // Vehicle data
            if (this.dockPanelVehicle.Visibility.Equals(DevExpress.XtraBars.Docking.DockVisibility.Visible))
            {
                this.RefreshVehicleData();
            }

            // Employee
            if (this.dockPanelEmployees.Visibility.Equals(DevExpress.XtraBars.Docking.DockVisibility.Visible))
            {
                this.RefreshEmployeeData();
            }

            // Service
            if (this.dockPanelservice.Visibility.Equals(DevExpress.XtraBars.Docking.DockVisibility.Visible))
            {
                if (this.listDispatchingOrders.Count > 0)
                {
                    this.viewService.DispatchingOrderInfo = listDispatchingOrders[this.dataNavigatorDispatchingOrders.Position];
                }
                this.viewService.InitData(this.textEditOrderID.Text);
            }
            // Loading report
            if (this.dockPanelLandingReport.Visibility.Equals(DevExpress.XtraBars.Docking.DockVisibility.Visible))
            {
                this.RefreshLoadingReportData();
            }
        }

        private void barButtonItem63_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_WM_DispatchingOrderExport frm = null;
            if (!string.IsNullOrEmpty(this.textEditOrderID.Text))
            {
                int _DOrderID = Convert.ToInt32(this.textEditOrderID.Text.Split('-')[1]);
                int _CusID = Convert.ToInt32(lookUpEditCustomerID.EditValue);
                frm = new frm_WM_DispatchingOrderExport(_DOrderID, dateEditDispatchingOrderDate.DateTime, _CusID, textEditInernalRemark.Text, gridViewOrderDetail.RowCount);
                if (!frm.Enabled) return;
                frm.ShowDialog();
            }
            if (frm != null && frm.HasExport)
            {
                this.SendToBack();
            }
        }

        /// <summary>
        /// Delete dispatching product seleceted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem64_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.txtEDIMessageSentTime.Text.Length > 0)
            {
                XtraMessageBox.Show("This DO already sent EDI , can not delete!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this.gridViewOrderDetail.RowCount > 0)
            {
                XtraMessageBox.Show("Please delete all products !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dl = MessageBox.Show("Do you want to delete this Dispatching order? When all products was deleted ", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dl.Equals(DialogResult.Yes))
            {
                this.DeleteDispatchingOrder();
                dispatchingOrderIDInput = 0;
                this.frm_WM_DispatchingOrders_VisibleChanged(null, null);
            }
        }

        private void ResetData()
        {
            this.listOrderDetail.Clear();
            this.lookUpEditCustomerID.ReadOnly = false;
            this.textEditDispatchingCreatedTime.Text = DateTime.Now.ToString();
            this.textEditDispatchingCreatedTime.Tag = DateTime.Now.ToString();
            this.memoEditTruckAndDetail.Text = string.Empty;
            this.dateEditDispatchingOrderDate.DateTime = DateTime.Now;
            this.spinEditTemperature.EditValue = null;
            this.textEditSealNumber.Text = string.Empty;
            this.textEditDispatchingOrderProgress.EditValue = null;
            this.lkeDockNumber.EditValue = null;
            this.timeEditStartTime.EditValue = null;
            this.timeEditEndTime.EditValue = null;
            this.lookUpEditHandlingOvertimeCategoryID.EditValue = null;
            this.lookUpEditCustomerClientID.Text = string.Empty;
            this.lke_TimeSlotID.EditValue = null;
            this.textEditVehicleNumber.Tag = this.textEditVehicleNumber.Text = string.Empty;
            this.textEditCustomerOrderNumber.Tag = this.textEditCustomerOrderNumber.Text = string.Empty;
            this.textEditCustomerOrderNumber2.Tag = this.textEditCustomerOrderNumber2.Text = string.Empty;
            this.txtPickingPercent.Tag = null;
            this.txtPickingPercent.Text = string.Empty;
            this.txtProcessStatus.Tag = null;
            this.txtProcessStatus.Text = string.Empty;

            this.txtEDIMessageSentTime.Tag = null;
            this.txtEDIMessageSentTime.Text = string.Empty;

            this.comboBoxEdit1.EditValue = null;
            this.textEditInernalRemark.Text = string.Empty;
            this.textEditServiceName.Text = string.Empty;
        }

        private void CheckLockControls()
        {
            bool isReadOnly = true;
            // Check the controls on form is allow active
            if (!this.isLockOrder)
            {
                isReadOnly = false;
            }

            this.lookUpEditCustomerID.Properties.ReadOnly = isReadOnly;
            this.memoEditTruckAndDetail.ReadOnly = isReadOnly;
            this.dateEditDispatchingOrderDate.ReadOnly = isReadOnly;
            this.spinEditTemperature.ReadOnly = isReadOnly;
            this.textEditSealNumber.ReadOnly = isReadOnly;
            this.textEditDispatchingOrderProgress.ReadOnly = isReadOnly;
            this.lkeDockNumber.ReadOnly = isReadOnly;
            this.timeEditStartTime.ReadOnly = isReadOnly;
            this.timeEditEndTime.ReadOnly = isReadOnly;
            this.textEditVehicleNumber.ReadOnly = isReadOnly;
            this.textEditCustomerOrderNumber.ReadOnly = isReadOnly;
            this.textEditCustomerOrderNumber2.ReadOnly = isReadOnly;
            this.txtPickingPercent.ReadOnly = true;
            this.txtProcessStatus.ReadOnly = true;
            this.txtEDIMessageSentTime.ReadOnly = true;

            this.lookUpEditHandlingOvertimeCategoryID.ReadOnly = isReadOnly;
            this.lookUpEditCustomerClientID.ReadOnly = isReadOnly;
            this.lke_TimeSlotID.ReadOnly = isReadOnly;
            this.comboBoxEdit1.ReadOnly = true;
            this.textEditInernalRemark.ReadOnly = isReadOnly;
            this.textEditServiceName.ReadOnly = isReadOnly;
            //this.gridViewOrderDetail.OptionsBehavior.ReadOnly = isReadOnly;
            this.gridColumnProductID.OptionsColumn.ReadOnly = isReadOnly;
            this.gridColumnProductName.OptionsColumn.ReadOnly = isReadOnly;
            this.gridColumn2.OptionsColumn.ReadOnly = isReadOnly;
            this.gridColumnUW.OptionsColumn.ReadOnly = isReadOnly;
            this.gridColumnPallets.OptionsColumn.ReadOnly = isReadOnly;
            this.gridColumnTotalPackages.OptionsColumn.ReadOnly = isReadOnly;
            this.gridColumn5.OptionsColumn.ReadOnly = isReadOnly;
            this.gridColumn11.OptionsColumn.ReadOnly = isReadOnly;
            this.gridColumn13.OptionsColumn.ReadOnly = isReadOnly;
            this.gridColumnStatus.OptionsColumn.ReadOnly = isReadOnly;
            this.gridColumn1.OptionsColumn.ReadOnly = isReadOnly;
            this.btn_WM_NewAllProducts.Enabled = !isReadOnly;
            this.btn_WM_NewProduct.Enabled = !isReadOnly;
            this.iAcceptAllLocations.Enabled = !isReadOnly;
            this.iConfirm.Enabled = !isReadOnly;
        }

        private void DeleteDispatchingOrder()
        {
            DataProcess<object> dispatchingOrderDA = new DataProcess<object>();
            dispatchingOrderDA.ExecuteNoQuery("STOrdersDelete @OrderNumber={0}", this.textEditOrderID.Text);
            DispatchingOrders dispatchingSelected = this.listDispatchingOrders.Where(d => d.DispatchingOrderID == Convert.ToInt32(textEditOrderID.Tag)).FirstOrDefault();
            this.listDispatchingOrders.Remove(dispatchingSelected);
            this.dataNavigatorDispatchingOrders.Position = this.listDispatchingOrders.Count();
        }

        private void btn_WM_InOutView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_WM_InOutViewByDate.Instance.ViewRODOData(Convert.ToInt32(lookUpEditCustomerID.Tag), false);
            frmMain.Instance.BringToFront();
        }

        private void rpi_hpl_ProductInfo_DoubleClick(object sender, EventArgs e)
        {
            int productID = -1;
            Int32.TryParse(this.gridViewOrderDetail.GetRowCellValue(this.gridViewOrderDetail.FocusedRowHandle, "ProductID").ToString(), out productID);
            frm_MSS_Products frmproduct = frm_MSS_Products.Instance;
            frmproduct.ProductIDLookup = productID;
            frmproduct.Show();
        }

        private void frm_WM_DispatchingOrders_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                if (!this.textEditOrderID.Text.Equals("DO-New*"))
                {
                    frm_WM_Attachments.Instance.OrderNumber = this.textEditOrderID.Text;
                    frm_WM_Attachments.Instance.CustomerID = Convert.ToInt32(this.lookUpEditCustomerID.EditValue);
                    if (!frm_WM_Attachments.Instance.Enabled) return;
                    frm_WM_Attachments.Instance.ShowDialog();
                }
            }

            else if (e.KeyCode == Keys.F12)
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

        private void printPlanA4_ExpDate(bool isPreview)
        {
            rptDispatchingPlanA4ByExpDate dPlanA4 = new rptDispatchingPlanA4ByExpDate();
            dPlanA4.Parameters["varDispatchingOrderID"].Value = Convert.ToInt32(textEditOrderID.Tag);
            Customers cus = AppSetting.CustomerList.Where(c => c.CustomerID == Convert.ToInt32(lookUpEditCustomerID.EditValue)).FirstOrDefault();
            DataProcess<CustomerRequirements> customerR = new DataProcess<CustomerRequirements>();
            CustomerRequirements customerRequired = customerR.Executing("SELECT * FROM  CustomerRequirements WHERE (CustomerMainID = " + cus.CustomerMainID + ") AND (RequirementConfirmed = 1) And(RequirementCategory=2) ORDER BY UpdateTime ASC").FirstOrDefault();
            var dataSource = FileProcess.LoadTable("STDispatchingPlanReportNew  @varDispatchingOrderID=" + Convert.ToInt32(textEditOrderID.Tag));
            dPlanA4.DataSource = dataSource;
            dPlanA4.RequestParameters = false;
            if (customerRequired != null)
            {
                dPlanA4.Parameters["varCustomerRequired"].Value = customerRequired.RequirementDetails.ToString();
            }
            dPlanA4.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;

            // get source report
            string strDO = string.Empty;
            if (dataSource != null && dataSource.Rows.Count > 0)
            {
                strDO = Convert.ToString(dataSource.Rows[0]["DispatchingOrderID_Barcode"]);
            }
            dPlanA4.bcDispatching.Text = strDO;
            ReportPrintToolWMS printTool = new ReportPrintToolWMS(dPlanA4);
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

        private void printPlanA4_Temperature(bool isPreview)
        {
            rptDispatchingPlanA4New dPlanA4 = new rptDispatchingPlanA4New();
            dPlanA4.Parameters["varDispatchingOrderID"].Value = Convert.ToInt32(textEditOrderID.Tag);
            Customers cus = AppSetting.CustomerList.Where(c => c.CustomerID == Convert.ToInt32(lookUpEditCustomerID.EditValue)).FirstOrDefault();
            var customerRequired = FileProcess.LoadTable("STCustomerRequirementPrint @CustomerMainID=" + cus.CustomerMainID + ",@Flag=2");

            var dataSource = FileProcess.LoadTable("STDispatchingPlanReportNew  @varDispatchingOrderID=" + Convert.ToInt32(textEditOrderID.Tag));
            dPlanA4.DataSource = dataSource;
            dPlanA4.RequestParameters = false;
            if (customerRequired != null)
            {
                System.Text.StringBuilder requirementContents = new System.Text.StringBuilder();
                int count = 1;
                foreach (System.Data.DataRow item in customerRequired.Rows)
                {
                    requirementContents.Append(item["RequirementDetails"]);
                    if (count < customerRequired.Rows.Count)
                    {
                        requirementContents.Append(Environment.NewLine);
                    }
                    count++;
                }

                dPlanA4.Parameters["varCustomerRequired"].Value = requirementContents.ToString() + "-" + this.textEditVehicleNumber.Text;
            }
            dPlanA4.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
            // hide header report
            dPlanA4.xrPalletID.Visible = false;
            dPlanA4.xrUnit.Visible = false;
            dPlanA4.xrWeight.Visible = false;
            dPlanA4.xrCtnPcs.Visible = false;
            dPlanA4.xrPro_.Visible = false;
            dPlanA4.xrExp.Visible = false;
            // hide group header
            dPlanA4.xrhWeigth.Visible = false;
            // invisible ctn
            dPlanA4.xrhKgCtn.Visible = false;
            dPlanA4.xrhWeightPerPackage.Visible = false;
            // dPlanA4.xrhUseByDate.Visible = false;
            dPlanA4.xrhSumWeightPerPackage.Visible = false;
            dPlanA4.xrhSumPalletWeight.Visible = false;
            // hide colum detail
            dPlanA4.xrdQtyPackageModInner.Visible = false;
            dPlanA4.xrdQtyPackageQuotieInner.Visible = false;
            dPlanA4.xrdPalletWeight.Visible = false;

            // move postion and resize xrlabel
            dPlanA4.xrProductName.WidthF = dPlanA4.xrProductName.WidthF + 100;
            dPlanA4.xrdDispatchingLocationRemark.WidthF = 160F;
            dPlanA4.xrdPalletID.WidthF = dPlanA4.xrdPalletID.WidthF + 10;
            dPlanA4.xrdPalletID.LocationF = new PointF(dPlanA4.xrdPalletID.LocationF.X + 70, dPlanA4.xrdPalletID.LocationF.Y);
            dPlanA4.xrdQtyOfPackage.LocationF = new PointF(dPlanA4.xrdQtyOfPackage.LocationF.X + 60, dPlanA4.xrdQtyOfPackage.LocationF.Y);
            dPlanA4.xrdProductDate.LocationF = new PointF(dPlanA4.xrdProductDate.LocationF.X + 70, dPlanA4.xrdProductDate.LocationF.Y);
            dPlanA4.xrdUseByDate.LocationF = new PointF(dPlanA4.xrdUseByDate.LocationF.X + 50, dPlanA4.xrdUseByDate.LocationF.Y);

            string strDO = string.Empty;
            if (dataSource != null && dataSource.Rows.Count > 0)
            {
                strDO = Convert.ToString(dataSource.Rows[0]["DispatchingOrderID_Barcode"]);
            }
            dPlanA4.bcDispatching.Text = strDO;
            ReportPrintToolWMS printTool = new ReportPrintToolWMS(dPlanA4);
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

        private void printPlanA4_New(bool isPreview)
        {
            rptDispatchingPlanA4New dPlanA4 = new rptDispatchingPlanA4New();
            dPlanA4.Parameters["varDispatchingOrderID"].Value = Convert.ToInt32(textEditOrderID.Tag);
            Customers cus = AppSetting.CustomerList.Where(c => c.CustomerID == Convert.ToInt32(lookUpEditCustomerID.EditValue)).FirstOrDefault();
            var customerRequired = FileProcess.LoadTable("STCustomerRequirementPrint @CustomerMainID=" + cus.CustomerMainID + ",@Flag=2");
            var dataSource = FileProcess.LoadTable("STDispatchingPlanReportNew  @varDispatchingOrderID=" + Convert.ToInt32(textEditOrderID.Tag));
            dPlanA4.DataSource = dataSource;
            dPlanA4.RequestParameters = false;
            if (customerRequired != null)
            {
                System.Text.StringBuilder requirementContents = new System.Text.StringBuilder();
                int count = 1;
                foreach (System.Data.DataRow item in customerRequired.Rows)
                {
                    requirementContents.Append(item["RequirementDetails"]);
                    if (count < customerRequired.Rows.Count)
                    {
                        requirementContents.Append(Environment.NewLine);
                    }
                    count++;
                }

                dPlanA4.Parameters["varCustomerRequired"].Value = requirementContents.ToString();
            }
            dPlanA4.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
            dPlanA4.xrnhietDo.Visible = false;
            dPlanA4.xrTemperature.Visible = false;
            // hide header report
            dPlanA4.xrPalletID.Visible = false;
            dPlanA4.xrUnit.Visible = false;
            dPlanA4.xrWeight.Visible = false;
            dPlanA4.xrCtnPcs.Visible = false;
            dPlanA4.xrPro_.Visible = false;
            dPlanA4.xrExp.Visible = false;
            // hide group header
            dPlanA4.xrhWeigth.Visible = false;
            // invisible ctn
            dPlanA4.xrhKgCtn.Visible = false;
            dPlanA4.xrhWeightPerPackage.Visible = false;
            // dPlanA4.xrhUseByDate.Visible = false;
            dPlanA4.xrhSumWeightPerPackage.Visible = false;
            dPlanA4.xrhSumPalletWeight.Visible = false;
            // hide colum detail
            dPlanA4.xrdQtyPackageModInner.Visible = false;
            dPlanA4.xrdQtyPackageQuotieInner.Visible = false;
            dPlanA4.xrdPalletWeight.Visible = false;
            dPlanA4.xrSumQtyOfPackage.Visible = true;
            dPlanA4.xrTotalProductName.Visible = true;
            // move postion and resize xrlabel
            dPlanA4.xrfcalculateField1.LocationF = new PointF(dPlanA4.xrfcalculateField1.LocationF.X - 70, dPlanA4.xrdPalletID.LocationF.Y);
            dPlanA4.xrdDispatchingLocationRemark.WidthF = 160F;
            dPlanA4.xrProductName.WidthF = 320F;
            dPlanA4.xrdPalletID.WidthF = dPlanA4.xrdPalletID.WidthF + 10;
            dPlanA4.xrdRemark.WidthF = dPlanA4.xrdRemark.WidthF + 50;
            dPlanA4.xrdRemark.LocationF = new PointF(dPlanA4.xrdRemark.LocationF.X - 50, dPlanA4.xrdRemark.LocationF.Y);
            dPlanA4.xrdPalletID.LocationF = new PointF(dPlanA4.xrdPalletID.LocationF.X + 80, dPlanA4.xrdPalletID.LocationF.Y);
            dPlanA4.xrdQtyOfPackage.LocationF = new PointF(dPlanA4.xrdQtyOfPackage.LocationF.X + 70, dPlanA4.xrdQtyOfPackage.LocationF.Y);
            dPlanA4.xrdProductDate.LocationF = new PointF(dPlanA4.xrdProductDate.LocationF.X + 60, dPlanA4.xrdProductDate.LocationF.Y);
            dPlanA4.xrdUseByDate.LocationF = new PointF(dPlanA4.xrdUseByDate.LocationF.X + 20, dPlanA4.xrdUseByDate.LocationF.Y);
            dPlanA4.GroupFooter1.Visible = false;
            string strDO = string.Empty;
            if (dataSource != null && dataSource.Rows.Count > 0)
            {
                strDO = Convert.ToString(dataSource.Rows[0]["DispatchingOrderID_Barcode"]);
            }
            dPlanA4.bcDispatching.Text = strDO;
            ReportPrintToolWMS printTool = new ReportPrintToolWMS(dPlanA4);
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

        private void printPlanA4_Pcs(bool isPreview)
        {
            //  rptDispatchingPlanA4New dPlanA4 = new rptDispatchingPlanA4New();
            rptDispatchingPlanA4New dPlanA4 = new rptDispatchingPlanA4New();
            dPlanA4.Parameters["varDispatchingOrderID"].Value = Convert.ToInt32(textEditOrderID.Tag);
            Customers cus = AppSetting.CustomerList.Where(c => c.CustomerID == Convert.ToInt32(lookUpEditCustomerID.EditValue)).FirstOrDefault();
            var customerRequired = FileProcess.LoadTable("STCustomerRequirementPrint @CustomerMainID=" + cus.CustomerMainID + ",@Flag=2");
            var dataSource = FileProcess.LoadTable("STDispatchingPlanReportNew  @varDispatchingOrderID=" + Convert.ToInt32(textEditOrderID.Tag));
            dPlanA4.DataSource = dataSource;
            dPlanA4.RequestParameters = false;
            if (customerRequired != null)
            {
                System.Text.StringBuilder requirementContents = new System.Text.StringBuilder();
                int count = 1;
                foreach (System.Data.DataRow item in customerRequired.Rows)
                {
                    requirementContents.Append(item["RequirementDetails"]);
                    if (count < customerRequired.Rows.Count)
                    {
                        requirementContents.Append(Environment.NewLine);
                    }
                    count++;
                }

                dPlanA4.Parameters["varCustomerRequired"].Value = requirementContents.ToString();
            }
            dPlanA4.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
            dPlanA4.xrPalletID.Visible = false;
            dPlanA4.xrKgs.Visible = false;
            dPlanA4.xrUnit.Visible = true;
            dPlanA4.xrWeight.Visible = false;
            dPlanA4.xrCtnPcs.Visible = true;
            dPlanA4.xrPro_.Visible = false;
            dPlanA4.xrExp.Visible = true;
            // hide group header
            dPlanA4.xrhWeigth.Visible = false;
            // visible ctn
            dPlanA4.xrhKgCtn.Visible = false;
            dPlanA4.xrhWeightPerPackage.Visible = false;
            // dPlanA4.xrhUseByDate.Visible = false;
            dPlanA4.xrhSumWeightPerPackage.Visible = false;
            dPlanA4.xrhSumPalletWeight.Visible = false;
            // show colum detail
            dPlanA4.xrdQtyPackageModInner.Visible = true;
            dPlanA4.xrdQtyPackageQuotieInner.Visible = true;
            dPlanA4.xrdPalletWeight.Visible = false;
            // unboild calculateField1 chua biet


            // move postion and resize xrh & xrd
            dPlanA4.xrhKgCtn.LocationF = new PointF(dPlanA4.xrhKgCtn.LocationF.X + 20, dPlanA4.xrhKgCtn.LocationF.Y);
            dPlanA4.xrUnit.LocationF = new PointF(dPlanA4.xrUnit.LocationF.X + 50, dPlanA4.xrUnit.LocationF.Y);
            dPlanA4.xrExp.LocationF = new PointF(dPlanA4.xrExp.LocationF.X + 30, dPlanA4.xrExp.LocationF.Y);
            dPlanA4.xrdQtyPackageModInner.LocationF = new PointF(dPlanA4.xrdQtyPackageModInner.LocationF.X + 20, dPlanA4.xrdQtyPackageModInner.LocationF.Y);
            dPlanA4.xrdQtyPackageQuotieInner.LocationF = new PointF(dPlanA4.xrdQtyPackageQuotieInner.LocationF.X + 20, dPlanA4.xrdQtyPackageQuotieInner.LocationF.Y);

            dPlanA4.xrdDispatchingLocationRemark.WidthF = 130F;
            dPlanA4.xrdPalletID.WidthF = dPlanA4.xrdPalletID.WidthF + 10;
            dPlanA4.xrdPalletID.LocationF = new PointF(dPlanA4.xrdPalletID.LocationF.X + 50, dPlanA4.xrdPalletID.LocationF.Y);
            dPlanA4.xrhKgCtn.LocationF = new PointF(dPlanA4.xrhKgCtn.LocationF.X - 20, dPlanA4.xrhKgCtn.LocationF.Y);
            dPlanA4.xrdQtyPackageModInner.LocationF = new PointF(dPlanA4.xrdQtyPackageModInner.LocationF.X - 20, dPlanA4.xrdQtyPackageModInner.LocationF.Y);
            dPlanA4.xrdQtyPackageQuotieInner.LocationF = new PointF(dPlanA4.xrdQtyPackageQuotieInner.LocationF.X - 10, dPlanA4.xrdQtyPackageQuotieInner.LocationF.Y);

            dPlanA4.xrdQtyOfPackage.LocationF = new PointF(dPlanA4.xrdQtyOfPackage.LocationF.X + 60, dPlanA4.xrdQtyOfPackage.LocationF.Y);
            dPlanA4.xrdProductDate.LocationF = new PointF(dPlanA4.xrdProductDate.LocationF.X + 50, dPlanA4.xrdProductDate.LocationF.Y);
            dPlanA4.xrdUseByDate.LocationF = new PointF(dPlanA4.xrdUseByDate.LocationF.X + 50, dPlanA4.xrdUseByDate.LocationF.Y);

            // get source report
            string strDO = string.Empty;
            if (dataSource != null && dataSource.Rows.Count > 0)
            {
                strDO = Convert.ToString(dataSource.Rows[0]["DispatchingOrderID_Barcode"]);
            }
            dPlanA4.bcDispatching.Text = strDO;
            ReportPrintToolWMS printTool = new ReportPrintToolWMS(dPlanA4);
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

        private void printPlanA4_UnitWeight(bool isPreview)
        {
            rptDispatchingPlanA4New_UnitWeight dPlanA4 = new rptDispatchingPlanA4New_UnitWeight();
            dPlanA4.Parameters["varDispatchingOrderID"].Value = Convert.ToInt32(textEditOrderID.Tag);
            Customers cus = AppSetting.CustomerList.Where(c => c.CustomerID == Convert.ToInt32(lookUpEditCustomerID.EditValue)).FirstOrDefault();
            var customerRequired = FileProcess.LoadTable("STCustomerRequirementPrint @CustomerMainID=" + cus.CustomerMainID + ",@Flag=2");
            var dataSource = FileProcess.LoadTable("STDispatchingPlanReportNew  @varDispatchingOrderID=" + Convert.ToInt32(textEditOrderID.Tag));
            dPlanA4.DataSource = dataSource;
            dPlanA4.RequestParameters = false;
            if (customerRequired != null)
            {
                System.Text.StringBuilder requirementContents = new System.Text.StringBuilder();
                int count = 1;
                foreach (System.Data.DataRow item in customerRequired.Rows)
                {
                    requirementContents.Append(item["RequirementDetails"]);
                    if (count < customerRequired.Rows.Count)
                    {
                        requirementContents.Append(Environment.NewLine);
                    }
                    count++;
                }

                dPlanA4.Parameters["varCustomerRequired"].Value = requirementContents.ToString();
            }
            dPlanA4.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
            Font ft = new Font("Tahoma", 9, FontStyle.Bold);
            Font ft1 = new Font("Tahoma", 9, FontStyle.Regular);
            dPlanA4.xrdPalletWeight.Font = ft1;
            dPlanA4.xrdUnitQty.Font = ft1;
            dPlanA4.xrdQtyOfPackage.Font = ft;

            // get source report
            string strDO = string.Empty;
            if (dataSource != null && dataSource.Rows.Count > 0)
            {
                strDO = Convert.ToString(dataSource.Rows[0]["DispatchingOrderID_Barcode"]);
            }

            ReportPrintToolWMS printTool = new ReportPrintToolWMS(dPlanA4);
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

        private void PickingSlipPrint()
        {
            printPickingSlipA4ByRemark(true);
        }

        private void btnPlanA4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.PlanA4Combine(false);
        }

        private void barButtonItem57_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.PlanA4Combine(true);
        }

        private void PlanA4Combine(bool isPreview)
        {
            planA4();
            Customers cus = AppSetting.CustomerList.Where(c => c.CustomerID == Convert.ToInt32(lookUpEditCustomerID.EditValue)).FirstOrDefault();
            int customerID = Convert.ToInt32(lookUpEditCustomerID.EditValue);
            int dispatchingOrderID = Convert.ToInt32(textEditOrderID.Tag);
            //  if (this.gridViewOrderDetail.dataso > 0)
            if (this.gridViewOrderDetail.DataRowCount <= 0)
            {
                return;
            }
            if (cus.CustomerType.Equals(CustomerTypeEnum.RANDOM_WEIGHT))
            {
                printPlanA4_UnitWeight(isPreview);
            }
            else if (customerType.Equals(CustomerTypeEnum.PCS))
            {
                printPlanA4_Pcs(isPreview);
            }
            else
            {
                if (cus.CustomerMainID == 816)
                {
                    printPlanA4_Temperature(isPreview);
                }
                else
                {
                    printPlanA4_New(isPreview);
                }
            }
        }
        private void planA4()
        {
            int customerClientID = Convert.ToInt32(lookUpEditCustomerClientID.EditValue);
            int customerID = Convert.ToInt32(lookUpEditCustomerID.EditValue);
            dispatchingByClient = Convert.ToBoolean(lookUpEditCustomerID.Properties.GetDataSourceValue("DispatchingByClient", lookUpEditCustomerID.ItemIndex));
            if (dispatchingByClient)
            {
                if (customerClientID == 1)
                {
                    MessageBox.Show("This Customer requires Client Input !");
                    DataProcess<STCustomerClients_Result> customerClients = new DataProcess<STCustomerClients_Result>();
                    lookUpEditCustomerClientID.Properties.DataSource = customerClients.Executing("STCustomerClients @CustomerID={0}", customerID);
                    lookUpEditCustomerClientID.Focus();
                    lookUpEditCustomerClientID.ShowPopup();
                    return;
                }
            }
        }

        private void btn_mnu_PreviewPick_Plan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.printPickOrPlan(true);
        }

        private void btn_mnu_PreviewPickingSlipA4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Customers cus = AppSetting.CustomerList.Where(c => c.CustomerID == Convert.ToInt32(lookUpEditCustomerID.EditValue)).FirstOrDefault();
            //  Products cusProduct = AppSetting.ProductList.Where(n => n.)
            int customerID = Convert.ToInt32(lookUpEditCustomerID.EditValue);
            int dispatchingOrderID = Convert.ToInt32(textEditOrderID.Tag);
            //  if (this.gridViewOrderDetail.dataso > 0)
            if (this.gridViewOrderDetail.DataRowCount <= 0)
            {
                return;
            }
            if (cus.CustomerType.Equals(CustomerTypeEnum.RANDOM_WEIGHT))
            {
                printPickingSlipA4_RandomWeight(true);
            }
            else
            {
                this.printPickingSlipA4(true);
            }

        }

        private void btn_mnu_PreviewPickingSlipA5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.printPickingSlipA5(true);
        }

        private void btn_mnu_PreviewPickingSlipProductA4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            Customers cus = AppSetting.CustomerList.Where(c => c.CustomerID == Convert.ToInt32(lookUpEditCustomerID.EditValue)).FirstOrDefault();
            int customerID = Convert.ToInt32(lookUpEditCustomerID.EditValue);
            int dispatchingOrderID = Convert.ToInt32(textEditOrderID.Tag);

            if (this.gridViewOrderDetail.DataRowCount <= 0)
            {
                return;
            }
            if (cus.CustomerType.Equals(CustomerTypeEnum.RANDOM_WEIGHT))
            {
                printPickingSlipProductA4_RandomWeight(true);
            }
            else
            {
                this.printPickingSlipProductA4(true);
            }


        }

        private void btn_mnu_PreviewPickingSlipRemarkA4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Customers cus = AppSetting.CustomerList.Where(c => c.CustomerID == Convert.ToInt32(lookUpEditCustomerID.EditValue)).FirstOrDefault();
            int customerID = Convert.ToInt32(lookUpEditCustomerID.EditValue);
            int dispatchingOrderID = Convert.ToInt32(textEditOrderID.Tag);

            if (this.gridViewOrderDetail.DataRowCount <= 0)
            {
                return;
            }
            if (cus.CustomerType.Equals(CustomerTypeEnum.RANDOM_WEIGHT))
            {
                printPickingSlipA4ByRemark_RandomWeight(true);
            }
            else
            {
                printPickingSlipA4ByRemark(true);
            }
            // printPickingSlipA4ByRemark(true);

        }

        private void printPickingSlipA4ByRemark_RandomWeight(bool isPreview)
        {
            if (isPreview) this.pickingSlipPrint(isPreview);
            DataProcess<STPickingSlipWithPalletID_Result> pickingSlip = new DataProcess<STPickingSlipWithPalletID_Result>();
            rptPickingSlipA4ByRemark_RandomWeight rptPickingslipA4 = new rptPickingSlipA4ByRemark_RandomWeight();
            rptPickingslipA4.Parameters["varDispatchingOrderID"].Value = Convert.ToInt32(textEditOrderID.Tag);
            rptPickingslipA4.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
            rptPickingslipA4.RequestParameters = false;
            rptPickingslipA4.DataSource = FileProcess.LoadTable("STPickingSlipWithPalletID @varDispatchingOrderID=" + Convert.ToInt32(textEditOrderID.Tag));
            ReportPrintToolWMS printTool = new ReportPrintToolWMS(rptPickingslipA4);
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


        private void btn_mnu_PreviewNote_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            printDispatchingNote(true);
        }

        private void btn_mnu_PreviewNoteClient_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            printDispatchingNoteClient(true);
        }
        private void btn_mnu_PreviewNoteDetail_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            printDispatchingNoteDetail(true);
        }

        private void btnPickPlan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // this.printPickingSlipA4(true);
            // this.printPlanA4_New(true);
            this.printPickOrPlan(false);

        }
        private void printPickOrPlan(bool isPreview)
        {
            DataProcess<STPickingSlipWithPalletID_Result> pickingSlip = new DataProcess<STPickingSlipWithPalletID_Result>();

            // var dataSource = pickingSlip.Executing("STPickingSlipWithPalletID @varDispatchingOrderID={0}", Convert.ToInt32(textEditOrderID.Tag));
            var dataSource = FileProcess.LoadTable("STPickingSlipWithPalletID @varDispatchingOrderID=" + Convert.ToInt32(textEditOrderID.Tag));
            rptPickingSlipA4 rptPickingslipA4 = null;
            //if (customerType.Equals(CustomerTypeEnum.RANDOM_WEIGHT))
            //{
            //     rptPickingslipA4 = new rptPickingSlipA4(true);
            //}
            //else
            //{
            rptPickingslipA4 = new rptPickingSlipA4();
            //}
            rptPickingSlipA4_pcs rptPickingslipA4_pcs = new rptPickingSlipA4_pcs();

            if (customerType.Equals(CustomerTypeEnum.PCS))
            {
                rptDispatchingPlanA4New_pcs dPlanA4pcs = new rptDispatchingPlanA4New_pcs();

                Customers cus = AppSetting.CustomerList.Where(c => c.CustomerID == Convert.ToInt32(lookUpEditCustomerID.EditValue)).FirstOrDefault();
                DataProcess<CustomerRequirements> customerR = new DataProcess<CustomerRequirements>();
                CustomerRequirements customerRequired = customerR.Executing("SELECT * FROM  CustomerRequirements WHERE (CustomerMainID = " + cus.CustomerMainID + ") AND (RequirementConfirmed = 1) And(RequirementCategory=2) ORDER BY UpdateTime ASC").FirstOrDefault();
                var dataSourceReport = FileProcess.LoadTable("STDispatchingPlanReportNew  @varDispatchingOrderID=" + Convert.ToInt32(textEditOrderID.Tag));
                dPlanA4pcs.DataSource = dataSourceReport;
                dPlanA4pcs.RequestParameters = false;
                if (customerRequired != null)
                {
                    dPlanA4pcs.Parameters["varCustomerRequired"].Value = customerRequired.RequirementDetails.ToString();
                }

                rptPickingslipA4_pcs.Parameters["varDispatchingOrderID"].Value = Convert.ToInt32(textEditOrderID.Tag);
                rptPickingslipA4_pcs.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
                rptPickingslipA4_pcs.Parameters["parameter1"].Value = 1;
                rptPickingslipA4_pcs.RequestParameters = false;
                rptPickingslipA4_pcs.DataSource = dataSource;
                rptPickingslipA4_pcs.xrSubreport1.ReportSource = dPlanA4pcs;
                ReportPrintToolWMS printTool = new ReportPrintToolWMS(rptPickingslipA4_pcs);
                printTool.AutoShowParametersPanel = false;
                if (isPreview)
                {
                    printTool.ShowPreviewDialog();
                }
                else
                {
                    printTool.Print();
                }
            }
            // n edit
            //else if (customerType.Equals(CustomerTypeEnum.RANDOM_WEIGHT))
            //{
            //    printPickingSlipA4ByRemark_RandomWeight(true);
            //}

            else
            {
                rptDispatchingPlanA4New dPlanA4 = new rptDispatchingPlanA4New();
                dPlanA4.Parameters["varDispatchingOrderID"].Value = Convert.ToInt32(textEditOrderID.Tag);
                dPlanA4.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
                Customers cus = AppSetting.CustomerList.Where(c => c.CustomerID == Convert.ToInt32(lookUpEditCustomerID.EditValue)).FirstOrDefault();
                DataProcess<CustomerRequirements> customerR = new DataProcess<CustomerRequirements>();
                CustomerRequirements customerRequired = customerR.Executing("SELECT * FROM  CustomerRequirements WHERE (CustomerMainID = " + cus.CustomerMainID + ") AND (RequirementConfirmed = 1) And(RequirementCategory=2) ORDER BY UpdateTime ASC").FirstOrDefault();
                var dataSourceReport = FileProcess.LoadTable("STDispatchingPlanReportNew  @varDispatchingOrderID=" + Convert.ToInt32(textEditOrderID.Tag));
                dPlanA4.DataSource = dataSourceReport;
                dPlanA4.RequestParameters = false;
                if (customerRequired != null)
                {
                    dPlanA4.Parameters["varCustomerRequired"].Value = customerRequired.RequirementDetails.ToString();
                }

                dPlanA4.xrnhietDo.Visible = false;
                dPlanA4.xrTemperature.Visible = false;
                // hide header report
                dPlanA4.xrPalletID.Visible = false;
                dPlanA4.xrUnit.Visible = false;
                dPlanA4.xrWeight.Visible = false;
                dPlanA4.xrCtnPcs.Visible = false;
                dPlanA4.xrPro_.Visible = false;
                dPlanA4.xrExp.Visible = false;
                // hide group header
                dPlanA4.xrhWeigth.Visible = false;
                // invisible ctn
                dPlanA4.xrhKgCtn.Visible = false;
                dPlanA4.xrhWeightPerPackage.Visible = false;
                // dPlanA4.xrhUseByDate.Visible = false;
                dPlanA4.xrhSumWeightPerPackage.Visible = false;
                dPlanA4.xrhSumPalletWeight.Visible = false;
                // hide colum detail
                dPlanA4.xrdQtyPackageModInner.Visible = false;
                dPlanA4.xrdQtyPackageQuotieInner.Visible = false;

                string strDO = string.Empty;
                if (dataSourceReport != null && dataSourceReport.Rows.Count > 0)
                {
                    strDO = Convert.ToString(dataSourceReport.Rows[0]["DispatchingOrderID_Barcode"]);
                }
                dPlanA4.bcDispatching.Text = strDO;
                dPlanA4.xrdPalletWeight.Visible = false;
                dPlanA4.xrSumQtyOfPackage.Visible = false;
                dPlanA4.xrTotalProductName.Visible = false;
                // move postion and resize xrlabel
                dPlanA4.xrfcalculateField1.LocationF = new PointF(dPlanA4.xrfcalculateField1.LocationF.X - 70, dPlanA4.xrdPalletID.LocationF.Y);
                // move postion and resize xrlabel
                dPlanA4.xrdDispatchingLocationRemark.WidthF = 160F;
                dPlanA4.xrdPalletID.WidthF = dPlanA4.xrdPalletID.WidthF + 10;
                dPlanA4.xrdPalletID.LocationF = new PointF(dPlanA4.xrdPalletID.LocationF.X + 70, dPlanA4.xrdPalletID.LocationF.Y);
                dPlanA4.xrdQtyOfPackage.LocationF = new PointF(dPlanA4.xrdQtyOfPackage.LocationF.X + 60, dPlanA4.xrdQtyOfPackage.LocationF.Y);
                dPlanA4.xrdRemark.WidthF = dPlanA4.xrdRemark.WidthF + 50;
                dPlanA4.xrdRemark.LocationF = new PointF(dPlanA4.xrdRemark.LocationF.X - 50, dPlanA4.xrdRemark.LocationF.Y);
                dPlanA4.xrdProductDate.LocationF = new PointF(dPlanA4.xrdProductDate.LocationF.X + 50, dPlanA4.xrdProductDate.LocationF.Y);
                dPlanA4.xrdUseByDate.LocationF = new PointF(dPlanA4.xrdUseByDate.LocationF.X + 50, dPlanA4.xrdUseByDate.LocationF.Y);
                rptPickingslipA4.Parameters["varDispatchingOrderID"].Value = Convert.ToInt32(textEditOrderID.Tag);
                rptPickingslipA4.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
                rptPickingslipA4.Parameters["parameter1"].Value = 1;
                rptPickingslipA4.RequestParameters = false;
                rptPickingslipA4.DataSource = dataSource;
                rptPickingslipA4.xrSubreport1.ReportSource = dPlanA4;
                ReportPrintToolWMS printTool = new ReportPrintToolWMS(rptPickingslipA4);
                printTool.AutoShowParametersPanel = false;
                if (isPreview)
                {
                    printTool.ShowPreviewDialog();
                }
                else
                {
                    printTool.Print();
                }
                // Print label ton
                this.pickingSlipPrint(true);
            }
        }
        private void btnPickingSlipRemarkA4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            printPickingSlipA4ByRemark(false);
        }

        private void btnPickingSlipProductA4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            printPickingSlipProductA4(false);
        }

        private void btnPickingSlipA4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            printPickingSlipA4(false);
        }

        private void printPickingSlipA5(bool isPreview)
        {
            dispatchingByClient = Convert.ToBoolean(lookUpEditCustomerID.Properties.GetDataSourceValue("DispatchingByClient", lookUpEditCustomerID.ItemIndex));
            int customerClientID = Convert.ToInt32(lookUpEditCustomerClientID.EditValue);
            int customerID = Convert.ToInt32(lookUpEditCustomerID.EditValue);
            int dispatchingOrderID = Convert.ToInt32(textEditOrderID.Tag);
            customerType = lookUpEditCustomerID.Properties.GetDataSourceValue("CustomerType", lookUpEditCustomerID.ItemIndex).ToString();
            if (dispatchingByClient)
            {
                if (customerClientID == 1)
                {
                    MessageBox.Show("This Customer requires Client Input !");
                    DataProcess<STCustomerClients_Result> customerClients = new DataProcess<STCustomerClients_Result>();
                    lookUpEditCustomerClientID.Properties.DataSource = customerClients.Executing("STCustomerClients @CustomerID={0}", customerID);
                    lookUpEditCustomerClientID.Focus();
                    lookUpEditCustomerClientID.ShowPopup();
                    return;
                }
            }
            DataProcess<STLabelRemainPickingSlip_Result> labelRemainPickingSlip = new DataProcess<STLabelRemainPickingSlip_Result>();
            var varLabelRemainPickingSlip = labelRemainPickingSlip.Executing("STLabelRemainPickingSlip @DispatchingOrderID={0}", dispatchingOrderID);
            if (varLabelRemainPickingSlip.Distinct().Count() > 0)
            {
                rptLabelA4Short_Barcode labelA4Short_Barcode = new rptLabelA4Short_Barcode();
                labelA4Short_Barcode.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
                labelA4Short_Barcode.RequestParameters = false;
                labelA4Short_Barcode.DataSource = varLabelRemainPickingSlip;
                ReportPrintToolWMS printTool = new ReportPrintToolWMS(labelA4Short_Barcode);
                if (isPreview)
                {
                    printTool.ShowPreview();
                }
                else
                {
                    printTool.Print();
                }
            }

            DataProcess<STPickingSlipWithPalletID_Result> pickingSlip = new DataProcess<STPickingSlipWithPalletID_Result>();
            rptPickingSlipA4 rptPickingslipA4 = new rptPickingSlipA4();
            rptPickingslipA4.PaperKind = System.Drawing.Printing.PaperKind.A5Extra;
            rptPickingslipA4.Landscape = true;
            rptPickingslipA4.Parameters["varDispatchingOrderID"].Value = Convert.ToInt32(textEditOrderID.Tag);
            rptPickingslipA4.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
            rptPickingslipA4.Parameters["parameter1"].Value = 1;
            rptPickingslipA4.RequestParameters = false;
            var dataSource = FileProcess.LoadTable("STPickingSlipWithPalletID @varDispatchingOrderID=" + Convert.ToInt32(textEditOrderID.Tag));
            //rptPickingslipA4.DataSource = pickingSlip.Executing("STPickingSlipWithPalletID @varDispatchingOrderID={0}", Convert.ToInt32(textEditOrderID.Tag));
            rptPickingslipA4.DataSource = dataSource;
            ReportPrintToolWMS printTool2 = new ReportPrintToolWMS(rptPickingslipA4);
            printTool2.AutoShowParametersPanel = false;
            if (isPreview)
            {
                printTool2.ShowPreview();
            }
            else
            {
                printTool2.Print();
            }
        }

        private void printPickingSlipA4(bool isPreview)
        {

            DataProcess<STPickingSlipWithPalletID_Result> pickingSlip = new DataProcess<STPickingSlipWithPalletID_Result>();
            rptPickingSlipA4 rptPickingslipA4 = new rptPickingSlipA4();
            rptPickingslipA4.Parameters["varDispatchingOrderID"].Value = Convert.ToInt32(textEditOrderID.Tag);
            rptPickingslipA4.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
            rptPickingslipA4.RequestParameters = false;
            // visible report footer = false
            rptPickingslipA4.ReportFooter.Visible = false;
            var dataSource = FileProcess.LoadTable("STPickingSlipWithPalletID @varDispatchingOrderID=" + Convert.ToInt32(textEditOrderID.Tag));
            //rptPickingslipA4.DataSource = pickingSlip.Executing("STPickingSlipWithPalletID @varDispatchingOrderID={0}", Convert.ToInt32(textEditOrderID.Tag));
            rptPickingslipA4.DataSource = dataSource;
            ReportPrintToolWMS printTool = new ReportPrintToolWMS(rptPickingslipA4);
            printTool.AutoShowParametersPanel = false;
            if (isPreview)
            {
                printTool.ShowPreview();
            }
            else
            {
                printTool.Print();
            }
            this.pickingSlipPrint(true);
        }

        private void printPickingSlipA4_RandomWeight(bool isPreview)
        {

            DataProcess<STPickingSlipWithPalletID_Result> pickingSlip = new DataProcess<STPickingSlipWithPalletID_Result>();
            rptPickingSlipA4_RandomWeight rptPickingslipA4_RW = new rptPickingSlipA4_RandomWeight();
            rptPickingslipA4_RW.Parameters["varDispatchingOrderID"].Value = Convert.ToInt32(textEditOrderID.Tag);
            rptPickingslipA4_RW.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
            rptPickingslipA4_RW.RequestParameters = false;
            //visible report footer = false

            rptPickingslipA4_RW.ReportFooter.Visible = false;

            var dataSource = FileProcess.LoadTable("STPickingSlipWithPalletID @varDispatchingOrderID=" + Convert.ToInt32(textEditOrderID.Tag));
            // rptPickingslipA4_RW.DataSource = pickingSlip.Executing("STPickingSlipWithPalletID @varDispatchingOrderID={0}", Convert.ToInt32(textEditOrderID.Tag));
            rptPickingslipA4_RW.DataSource = dataSource;
            ReportPrintToolWMS printTool = new ReportPrintToolWMS(rptPickingslipA4_RW);
            printTool.AutoShowParametersPanel = false;
            if (isPreview)
            {
                printTool.ShowPreview();
            }
            else
            {
                printTool.Print();
            }
            this.pickingSlipPrint(true);
        }

        private void printPickingSlipA4ByRemark(bool isPreview)
        {
            if (isPreview) this.pickingSlipPrint(isPreview);
            DataProcess<STPickingSlipWithPalletID_Result> pickingSlip = new DataProcess<STPickingSlipWithPalletID_Result>();
            rptPickingSlipA4ByRemark rptPickingslipA4 = new rptPickingSlipA4ByRemark();
            rptPickingslipA4.Parameters["varDispatchingOrderID"].Value = Convert.ToInt32(textEditOrderID.Tag);
            rptPickingslipA4.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
            rptPickingslipA4.RequestParameters = false;
            //  var dataSource = 
            var dataSource = FileProcess.LoadTable("STPickingSlipWithPalletID @varDispatchingOrderID=" + Convert.ToInt32(textEditOrderID.Tag));
            //rptPickingslipA4.DataSource = pickingSlip.Executing("STPickingSlipWithPalletID @varDispatchingOrderID={0}", Convert.ToInt32(textEditOrderID.Tag));
            rptPickingslipA4.DataSource = dataSource;
            ReportPrintToolWMS printTool = new ReportPrintToolWMS(rptPickingslipA4);
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

        private void printPickingSlipProductA4(bool isPreview)
        {
            if (isPreview) this.pickingSlipPrint(isPreview);
            DataProcess<STPickingSlipWithPalletID_Result> pickingSlip = new DataProcess<STPickingSlipWithPalletID_Result>();
            rptPickingSlipA4ByProduct rptPickingslipA4 = new rptPickingSlipA4ByProduct();
            rptPickingslipA4.Parameters["varDispatchingOrderID"].Value = Convert.ToInt32(textEditOrderID.Tag);
            rptPickingslipA4.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
            rptPickingslipA4.RequestParameters = false;
            var dataSource = FileProcess.LoadTable("STPickingSlipWithPalletID @varDispatchingOrderID=" + Convert.ToInt32(textEditOrderID.Tag));
            //rptPickingslipA4.DataSource = pickingSlip.Executing("STPickingSlipWithPalletID @varDispatchingOrderID={0}", Convert.ToInt32(textEditOrderID.Tag));
            rptPickingslipA4.DataSource = dataSource;
            ReportPrintToolWMS printTool = new ReportPrintToolWMS(rptPickingslipA4);
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
        private void printPickingSlipProductA4_RandomWeight(bool isPreview)
        {
            if (isPreview) this.pickingSlipPrint(isPreview);
            DataProcess<STPickingSlipWithPalletID_Result> pickingSlip = new DataProcess<STPickingSlipWithPalletID_Result>();
            rptPickingSlipA4ByProduct rptPickingslipA4 = new rptPickingSlipA4ByProduct(true);
            rptPickingslipA4.Parameters["varDispatchingOrderID"].Value = Convert.ToInt32(textEditOrderID.Tag);
            rptPickingslipA4.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
            rptPickingslipA4.RequestParameters = false;
            rptPickingslipA4.DataSource = FileProcess.LoadTable("STPickingSlipWithPalletID @varDispatchingOrderID=" + Convert.ToInt32(textEditOrderID.Tag));
            ReportPrintToolWMS printTool = new ReportPrintToolWMS(rptPickingslipA4);
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

        private void printDispatchingNote(bool isPreview)
        {
            int customerID = Convert.ToInt32(lookUpEditCustomerID.EditValue);
            int dispatchingOrderID = Convert.ToInt32(textEditOrderID.Tag);
            string orderNumber = textEditOrderID.Text;
            if (handlingOvertimeCheck(customerID) > 0 && Convert.ToInt32(lookUpEditHandlingOvertimeCategoryID.EditValue) == 0)
            {
                labelServiceOvertime(orderNumber, customerID);
            }
            else if (handlingOvertimeCheck(customerID) == 0 && (Convert.ToInt32(lookUpEditHandlingOvertimeCategoryID.EditValue) != 346 && lookUpEditHandlingOvertimeCategoryID.EditValue != null))
            {
                MessageBox.Show("Please check services of this customer!");
            }
            else
            {
                if ((handlingOvertimeCheck(customerID) == 0 && lookUpEditHandlingOvertimeCategoryID.EditValue == null))
                {
                    lookUpEditHandlingOvertimeCategoryID.Focus();
                    lookUpEditHandlingOvertimeCategoryID.ShowPopup();
                }
            }
            customerType = lookUpEditCustomerID.Properties.GetDataSourceValue("CustomerType", lookUpEditCustomerID.ItemIndex).ToString();
            if (customerType.Equals(CustomerTypeEnum.RANDOM_WEIGHT))
            {
                DataProcess<object> customerByOvertimeCheckingTime = new DataProcess<object>();
                int result = customerByOvertimeCheckingTime.ExecuteNoQuery("STDispatchingOrderCartonWeightUpdate @DispatchingOrderID= {0}", dispatchingOrderID);

                var datasource = FileProcess.LoadTable("STDispatchingNote @varDispatchingOrderID=" + dispatchingOrderID);
                rptDispatchingNote_UnitWeight rptDispatchingNoteUnitWeight = new ReportFile.rptDispatchingNote_UnitWeight();
                rptDispatchingNoteUnitWeight.Parameters["varDispatchingOrderID"].Value = dispatchingOrderID;
                rptDispatchingNoteUnitWeight.Parameters["varCurrentUser"].Value = fullInfoEmployees.FullName;
                rptDispatchingNoteUnitWeight.Parameters["Barcode"].Value = "DO" + dispatchingOrderID.ToString("D9");
                rptDispatchingNoteUnitWeight.DataSource = datasource;
                rptDispatchingNoteUnitWeight.RequestParameters = false;
                //calculateSumDetailField(rptDispatchingNoteUnitWeight);
                ReportPrintToolWMS printTool = new ReportPrintToolWMS(rptDispatchingNoteUnitWeight, customerID);
                printTool.AutoShowParametersPanel = false;
                if (isPreview)
                {
                    printTool.ShowPreview();
                }
                else
                {
                    printTool.Print();
                    printTool.Print();
                }

            }
            else
            {
                rptDispatchingNote rptDispatchingNote = new rptDispatchingNote();
                rptDispatchingNote.Parameters["varDispatchingOrderID"].Value = dispatchingOrderID;
                rptDispatchingNote.Parameters["varCurrentUser"].Value = fullInfoEmployees.FullName;
                rptDispatchingNote.Parameters["Barcode"].Value = "DO" + dispatchingOrderID.ToString("D9");
                rptDispatchingNote.RequestParameters = false;
                rptDispatchingNote.DataSource = FileProcess.LoadTable("STDispatchingNote @varDispatchingOrderID=" + dispatchingOrderID);
                ReportPrintToolWMS printTool = new ReportPrintToolWMS(rptDispatchingNote, customerID);
                printTool.AutoShowParametersPanel = false;
                if (isPreview)
                {
                    printTool.ShowPreview();
                }
                else
                {
                    printTool.Print();
                    printTool.Print();
                }
            }
        }

        private void printDispatchingNoteClient(bool isPreview)
        {
            customerType = lookUpEditCustomerID.Properties.GetDataSourceValue("CustomerType", lookUpEditCustomerID.ItemIndex).ToString();
            int customerID = Convert.ToInt32(lookUpEditCustomerID.EditValue);
            int dispatchingOrderID = Convert.ToInt32(textEditOrderID.Tag);
            string orderNumber = textEditOrderID.Text;
            if (handlingOvertimeCheck(customerID) > 0 && lookUpEditHandlingOvertimeCategoryID.EditValue == null)
            {
                labelServiceOvertime(orderNumber, customerID);
                lookUpEditHandlingOvertimeCategoryID.Focus();
                lookUpEditHandlingOvertimeCategoryID.ShowPopup();
            }
            else if (handlingOvertimeCheck(customerID) == 0 && Convert.ToInt32(lookUpEditHandlingOvertimeCategoryID.EditValue) != 346 && lookUpEditHandlingOvertimeCategoryID.EditValue != null)
            {
                MessageBox.Show("Please check services of this customer!");
            }
            else
            {
                if (handlingOvertimeCheck(customerID) == 0 && lookUpEditHandlingOvertimeCategoryID.EditValue == null)
                {
                    lookUpEditHandlingOvertimeCategoryID.Focus();
                    lookUpEditHandlingOvertimeCategoryID.ShowPopup();
                }
                dispatchingByClient = Convert.ToBoolean(lookUpEditCustomerID.Properties.GetDataSourceValue("DispatchingByClient", lookUpEditCustomerID.ItemIndex));
                if (dispatchingByClient)
                {
                    int CustomerClientID = Convert.ToInt32(lookUpEditCustomerClientID.EditValue);
                    if (CustomerClientID == 1)
                    {
                        MessageBox.Show("This Customer requires Client Input !");
                        DataProcess<STCustomerClients_Result> customerClients = new DataProcess<STCustomerClients_Result>();
                        List<STCustomerClients_Result> listcustomerClients = (List<STCustomerClients_Result>)customerClients.Executing("STCustomerClients @CustomerID={0}", customerID);
                        lookUpEditCustomerClientID.Properties.DataSource = listcustomerClients;
                        lookUpEditCustomerClientID.Focus();
                        lookUpEditCustomerClientID.ShowPopup();
                        return;
                    }
                }
                if (customerType.Equals(CustomerTypeEnum.RANDOM_WEIGHT))
                {
                    DataProcess<object> customerByOvertimeCheckingTime = new DataProcess<object>();
                    int result = customerByOvertimeCheckingTime.ExecuteNoQuery("STDispatchingOrderCartonWeightUpdate @DispatchingOrderID= {0}", dispatchingOrderID);
                    DataProcess<STDispatchingNote_Client_Result> dispatchingNoteClient = new DataProcess<STDispatchingNote_Client_Result>();
                    rptDispatchingNoteByClient_UnitWeight rptDispatchingNoteClient = new rptDispatchingNoteByClient_UnitWeight();
                    rptDispatchingNoteClient.Parameters["varDispatchingOrderID"].Value = Convert.ToInt32(textEditOrderID.Tag);
                    rptDispatchingNoteClient.Parameters["varCurrentUser"].Value = fullInfoEmployees.FullName;
                    rptDispatchingNoteClient.Parameters["varLoginUser"].Value = AppSetting.CurrentUser.LoginName;
                    rptDispatchingNoteClient.Parameters["Barcode"].Value = "DO" + dispatchingOrderID.ToString("D9");
                    rptDispatchingNoteClient.RequestParameters = false;
                    rptDispatchingNoteClient.DataSource = dispatchingNoteClient.Executing("STDispatchingNote_Client @varDispatchingOrderID={0}", Convert.ToInt32(textEditOrderID.Tag));
                    ReportPrintToolWMS printTool = new ReportPrintToolWMS(rptDispatchingNoteClient, customerID);
                    printTool.AutoShowParametersPanel = false;
                    if (isPreview)
                    {
                        printTool.ShowPreview();
                    }
                    else
                    {
                        printTool.Print();
                        printTool.Print();
                    }
                }
                else if (customerType.Equals(CustomerTypeEnum.PCS))
                {
                    MessageBox.Show("There is not Note for PCS customers!");
                }
                else
                {
                    DataProcess<STDispatchingNote_Client_Result> dispatchingNoteClient = new DataProcess<STDispatchingNote_Client_Result>();
                    rptDispatchingNoteByClient rptDispatchingNoteClient = new rptDispatchingNoteByClient();
                    rptDispatchingNoteClient.Parameters["varDispatchingOrderID"].Value = Convert.ToInt32(textEditOrderID.Tag);
                    rptDispatchingNoteClient.Parameters["varCurrentUser"].Value = fullInfoEmployees.FullName;
                    rptDispatchingNoteClient.Parameters["varLoginUser"].Value = AppSetting.CurrentUser.LoginName;
                    rptDispatchingNoteClient.Parameters["Barcode"].Value = "DO" + dispatchingOrderID.ToString("D9");
                    rptDispatchingNoteClient.RequestParameters = false;
                    rptDispatchingNoteClient.DataSource = dispatchingNoteClient.Executing("STDispatchingNote_Client @varDispatchingOrderID={0}", Convert.ToInt32(textEditOrderID.Tag));
                    ReportPrintToolWMS printTool = new ReportPrintToolWMS(rptDispatchingNoteClient, customerID);
                    printTool.AutoShowParametersPanel = false;
                    if (isPreview)
                    {
                        printTool.ShowPreview();
                    }
                    else
                    {
                        printTool.Print();
                        printTool.Print();
                    }
                }
            }

        }

        private void printDispatchingNoteClientSmall(bool isPreview)
        {
            customerType = lookUpEditCustomerID.Properties.GetDataSourceValue("CustomerType", lookUpEditCustomerID.ItemIndex).ToString();
            int customerID = Convert.ToInt32(lookUpEditCustomerID.EditValue);
            int dispatchingOrderID = Convert.ToInt32(textEditOrderID.Tag);
            string orderNumber = textEditOrderID.Text;
            if (handlingOvertimeCheck(customerID) > 0 && lookUpEditHandlingOvertimeCategoryID.EditValue == null)
            {
                labelServiceOvertime(orderNumber, customerID);
            }
            else if (handlingOvertimeCheck(customerID) == 0 && Convert.ToInt32(lookUpEditHandlingOvertimeCategoryID.EditValue) != 346 && lookUpEditHandlingOvertimeCategoryID.EditValue != null)
            {
                MessageBox.Show("Please check services of this customer!");
            }
            else
            {
                if (handlingOvertimeCheck(customerID) == 0 && lookUpEditHandlingOvertimeCategoryID.EditValue == null)
                {
                    lookUpEditHandlingOvertimeCategoryID.Focus();
                    lookUpEditHandlingOvertimeCategoryID.ShowPopup();
                }
                dispatchingByClient = Convert.ToBoolean(lookUpEditCustomerID.Properties.GetDataSourceValue("DispatchingByClient", lookUpEditCustomerID.ItemIndex));
                if (dispatchingByClient)
                {
                    int CustomerClientID = Convert.ToInt32(lookUpEditCustomerClientID.EditValue);
                    if (CustomerClientID == 1)
                    {
                        MessageBox.Show("This Customer requires Client Input !");
                        DataProcess<STCustomerClients_Result> customerClients = new DataProcess<STCustomerClients_Result>();
                        List<STCustomerClients_Result> listcustomerClients = (List<STCustomerClients_Result>)customerClients.Executing("STCustomerClients @CustomerID={0}", customerID);
                        lookUpEditCustomerClientID.Properties.DataSource = listcustomerClients;
                        lookUpEditCustomerClientID.Focus();
                        lookUpEditCustomerClientID.ShowPopup();
                        return;
                    }
                }
                if (customerType.Equals(CustomerTypeEnum.RANDOM_WEIGHT))
                {
                    DataProcess<object> customerByOvertimeCheckingTime = new DataProcess<object>();
                    int result = customerByOvertimeCheckingTime.ExecuteNoQuery("STDispatchingOrderCartonWeightUpdate @DispatchingOrderID= {0}", dispatchingOrderID);
                    DataProcess<STDispatchingNote_Client_Result> dispatchingNoteClient = new DataProcess<STDispatchingNote_Client_Result>();
                    rptDispatchingNoteByClient_UnitWeight rptDispatchingNoteClient = new rptDispatchingNoteByClient_UnitWeight();
                    rptDispatchingNoteClient.Parameters["varDispatchingOrderID"].Value = Convert.ToInt32(textEditOrderID.Tag);
                    rptDispatchingNoteClient.Parameters["varCurrentUser"].Value = fullInfoEmployees.FullName;
                    rptDispatchingNoteClient.Parameters["varLoginUser"].Value = AppSetting.CurrentUser.LoginName;
                    rptDispatchingNoteClient.Parameters["Barcode"].Value = "DO" + dispatchingOrderID.ToString("D9");
                    rptDispatchingNoteClient.RequestParameters = false;
                    rptDispatchingNoteClient.DataSource = dispatchingNoteClient.Executing("STDispatchingNote_Client @varDispatchingOrderID={0}", Convert.ToInt32(textEditOrderID.Tag));
                    ReportPrintToolWMS printTool = new ReportPrintToolWMS(rptDispatchingNoteClient, customerID);
                    printTool.AutoShowParametersPanel = false;
                    if (isPreview)
                    {
                        printTool.ShowPreview();
                    }
                    else
                    {
                        printTool.Print();
                        printTool.Print();
                    }
                }
                else if (customerType.Equals(CustomerTypeEnum.PCS))
                {
                    MessageBox.Show("There is not Note for PCS customers!");
                }
                else
                {
                    DataProcess<STDispatchingNote_Client_Result> dispatchingNoteClient = new DataProcess<STDispatchingNote_Client_Result>();
                    rptDispatchingNoteByClient_SmallA5 rptDispatchingNoteByClient_SmallA5 = new rptDispatchingNoteByClient_SmallA5();
                    rptDispatchingNoteByClient_SmallA5.Parameters["varDispatchingOrderID"].Value = Convert.ToInt32(textEditOrderID.Tag);
                    rptDispatchingNoteByClient_SmallA5.Parameters["varCurrentUser"].Value = fullInfoEmployees.FullName;
                    rptDispatchingNoteByClient_SmallA5.Parameters["varLoginUser"].Value = AppSetting.CurrentUser.LoginName;
                    rptDispatchingNoteByClient_SmallA5.RequestParameters = false;
                    rptDispatchingNoteByClient_SmallA5.DataSource = dispatchingNoteClient.Executing("STDispatchingNote_Client @varDispatchingOrderID={0}", Convert.ToInt32(textEditOrderID.Tag));
                    ReportPrintToolWMS printTool = new ReportPrintToolWMS(rptDispatchingNoteByClient_SmallA5, customerID);
                    printTool.AutoShowParametersPanel = false;
                    if (isPreview)
                    {
                        printTool.ShowPreview();
                    }
                    else
                    {
                        printTool.Print();
                        printTool.Print();
                    }
                }
            }

        }

        private void printDispatchingNoteDetail(bool isPreview)
        {
            int customerID = Convert.ToInt32(lookUpEditCustomerID.EditValue);
            int dispatchingOrderID = Convert.ToInt32(textEditOrderID.Tag);
            string orderNumber = textEditOrderID.Text;
            var currentCustomer = AppSetting.CustomerList.Where(c => c.CustomerID == customerID).FirstOrDefault();
            customerType = lookUpEditCustomerID.Properties.GetDataSourceValue("CustomerType", lookUpEditCustomerID.ItemIndex).ToString();
            var DPNoteDetail = new object();
            if (handlingOvertimeCheck(customerID) > 0 && Convert.ToInt32(lookUpEditHandlingOvertimeCategoryID.EditValue) == 0)
            {
                labelServiceOvertime(orderNumber, customerID);
                lookUpEditHandlingOvertimeCategoryID.Focus();
                lookUpEditHandlingOvertimeCategoryID.ShowPopup();
            }
            else if (handlingOvertimeCheck(customerID) == 0 && (Convert.ToInt32(lookUpEditHandlingOvertimeCategoryID.EditValue) != 346 && lookUpEditHandlingOvertimeCategoryID.EditValue != null))
            {
                MessageBox.Show("Please check services of this customer!");
            }
            else
            {
                DateTime doDate = Convert.ToDateTime(dateEditDispatchingOrderDate.EditValue);
                if (doDate > DateTime.Now.Date.AddDays(-7))
                {
                    DataProcess<STDispatchingNote_Pcs_Result> dispatchingNoteDetail = new DataProcess<STDispatchingNote_Pcs_Result>();
                    DPNoteDetail = FileProcess.LoadTable("STDispatchingNote_Pcs @varDispatchingOrderID=" + dispatchingOrderID);
                }
                else
                {
                    DPNoteDetail = FileProcess.LoadTable("STDispatchingNote_OldDetails @varDispatchingOrderID=" + dispatchingOrderID);
                }

                if (customerType.Equals(CustomerTypeEnum.PCS))
                {
                    rptDispatchingNote_pcs rptDispatching = new ReportFile.rptDispatchingNote_pcs();
                    rptDispatching.Parameters["varDispatchingOrderID"].Value = Convert.ToInt32(textEditOrderID.Tag);
                    rptDispatching.Parameters["varCurrentUser"].Value = fullInfoEmployees.FullName;
                    rptDispatching.Parameters["varLoginUser"].Value = AppSetting.CurrentUser.LoginName;
                    rptDispatching.Parameters["Barcode"].Value = "DO" + dispatchingOrderID.ToString("D9");
                    rptDispatching.RequestParameters = false;
                    rptDispatching.DataSource = DPNoteDetail;
                    ReportPrintToolWMS printTool = new ReportPrintToolWMS(rptDispatching, customerID);
                    if (isPreview)
                    {
                        printTool.ShowPreview();
                    }
                    else
                    {
                        printTool.Print();
                        printTool.Print();
                    }
                }
                else if (customerType.Equals(CustomerTypeEnum.RANDOM_WEIGHT))
                {
                    DataProcess<object> customerByOvertimeCheckingTime = new DataProcess<object>();
                    int result = customerByOvertimeCheckingTime.ExecuteNoQuery("STDispatchingOrderCartonWeightUpdate @DispatchingOrderID= {0}", dispatchingOrderID);

                    rptDispatchingNoteDetails rptDispatchingNoteDetail = new rptDispatchingNoteDetails((int)currentCustomer.CustomerMainID);
                    rptDispatchingNoteDetail.Parameters["varDispatchingOrderID"].Value = Convert.ToInt32(textEditOrderID.Tag);
                    rptDispatchingNoteDetail.Parameters["varCurrentUser"].Value = fullInfoEmployees.FullName;
                    rptDispatchingNoteDetail.Parameters["varLoginUser"].Value = AppSetting.CurrentUser.LoginName;
                    rptDispatchingNoteDetail.Parameters["Barcode"].Value = "DO" + dispatchingOrderID.ToString("D9");
                    rptDispatchingNoteDetail.RequestParameters = false;
                    rptDispatchingNoteDetail.DataSource = DPNoteDetail;
                    ReportPrintToolWMS printTool = new ReportPrintToolWMS(rptDispatchingNoteDetail, customerID);
                    printTool.AutoShowParametersPanel = false;
                    if (isPreview)
                    {
                        printTool.ShowPreview();
                    }
                    else
                    {
                        printTool.Print();
                        printTool.Print();
                    }
                }
                else
                {
                    rptDispatchingNoteDetails rptDispatchingNoteDetail = new rptDispatchingNoteDetails((int)currentCustomer.CustomerMainID);
                    rptDispatchingNoteDetail.Parameters["varDispatchingOrderID"].Value = Convert.ToInt32(textEditOrderID.Tag);
                    rptDispatchingNoteDetail.Parameters["varCurrentUser"].Value = fullInfoEmployees.FullName;
                    rptDispatchingNoteDetail.Parameters["varLoginUser"].Value = AppSetting.CurrentUser.LoginName;
                    rptDispatchingNoteDetail.Parameters["Barcode"].Value = "DO" + dispatchingOrderID.ToString("D9");
                    rptDispatchingNoteDetail.RequestParameters = false;
                    rptDispatchingNoteDetail.DataSource = DPNoteDetail;
                    ReportPrintToolWMS printTool = new ReportPrintToolWMS(rptDispatchingNoteDetail, customerID);
                    printTool.AutoShowParametersPanel = false;
                    if (isPreview)
                    {
                        printTool.ShowPreview();
                    }
                    else
                    {
                        printTool.Print();
                        printTool.Print();
                    }
                }
            }
        }

        private void pickingSlipPrint(bool isPreview)
        {
            dispatchingByClient = Convert.ToBoolean(lookUpEditCustomerID.Properties.GetDataSourceValue("DispatchingByClient", lookUpEditCustomerID.ItemIndex));
            int customerClientID = Convert.ToInt32(lookUpEditCustomerClientID.EditValue);
            int customerID = Convert.ToInt32(lookUpEditCustomerID.EditValue);
            int dispatchingOrderID = Convert.ToInt32(textEditOrderID.Tag);
            customerType = Convert.ToString(lookUpEditCustomerID.Properties.GetDataSourceValue("CustomerType", lookUpEditCustomerID.ItemIndex));
            if (dispatchingByClient)
            {
                if (customerClientID == 1)
                {
                    MessageBox.Show("This Customer requires Client Input !");
                    DataProcess<STCustomerClients_Result> customerClients = new DataProcess<STCustomerClients_Result>();
                    lookUpEditCustomerClientID.Properties.DataSource = customerClients.Executing("STCustomerClients @CustomerID={0}", customerID);
                    lookUpEditCustomerClientID.Focus();
                    lookUpEditCustomerClientID.ShowPopup();
                    return;
                }
            }
            // Remove condition check customer by expiryDate follow anh Buu
            //customer = AppSetting.CustomerList.Where(c => c.CustomerID == customerID).FirstOrDefault();
            //if (customer.CustomerByExpiryDate!=null && (bool)customer.CustomerByExpiryDate)
            //{
            DataProcess<STLabelRemainPickingSlip_Result> labelRemainPickingSlip = new DataProcess<STLabelRemainPickingSlip_Result>();
            var varLabelRemainPickingSlip = labelRemainPickingSlip.Executing("STLabelRemainPickingSlip @DispatchingOrderID={0}", dispatchingOrderID);
            if (varLabelRemainPickingSlip.Distinct().Count() > 0)
            {
                if (customerType.Equals(CustomerTypeEnum.PCS))
                {
                    rptLabelA4Short_Barcode_pcs labelA4Short_Barcode_pcs = new rptLabelA4Short_Barcode_pcs();
                    //  labelA4Short_Barcode_pcs.bcPalletID.Text = "*" + varLabelRemainPickingSlip.FirstOrDefault().PalletID_Barcode + "*";
                    labelA4Short_Barcode_pcs.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
                    labelA4Short_Barcode_pcs.Parameters["parameter1"].Value = 3;
                    labelA4Short_Barcode_pcs.RequestParameters = false;
                    labelA4Short_Barcode_pcs.DataSource = varLabelRemainPickingSlip;
                    ReportPrintToolWMS printTool = new ReportPrintToolWMS(labelA4Short_Barcode_pcs);
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
                else if (customerID == 22)
                {
                    rptLabelA4Short_Barcode labelA4Short_Barcode = new rptLabelA4Short_Barcode();
                    // labelA4Short_Barcode.bcPalletID.Text = "*" + varLabelRemainPickingSlip.FirstOrDefault().PalletID_Barcode + "*";
                    labelA4Short_Barcode.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
                    labelA4Short_Barcode.RequestParameters = false;
                    labelA4Short_Barcode.DataSource = varLabelRemainPickingSlip;
                    ReportPrintToolWMS printTool = new ReportPrintToolWMS(labelA4Short_Barcode);
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
                    rptLabelA4Short_Barcode labelA4Short_Barcode = new rptLabelA4Short_Barcode();
                    // labelA4Short_Barcode.bcPalletID.Text = "*" + varLabelRemainPickingSlip.FirstOrDefault().PalletID_Barcode + "*";
                    labelA4Short_Barcode.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
                    labelA4Short_Barcode.RequestParameters = false;
                    labelA4Short_Barcode.DataSource = varLabelRemainPickingSlip;
                    ReportPrintToolWMS printTool = new ReportPrintToolWMS(labelA4Short_Barcode);
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
                //}
            }
        }

        private int handlingOvertimeCheck(int customerID)
        {
            using (var context = new SwireDBEntities())
            {
                ObjectParameter outputParams = new ObjectParameter("ServiceQty", 0);
                context.STCustomerBillingByOvertime(customerID, outputParams);
                return Convert.ToInt32(outputParams.Value);
            }
        }

        private void labelServiceOvertime(string orderNumber, int customerID)
        {
            int handlingOvertimeCategoryID = 0;
            using (var context = new SwireDBEntities())
            {
                ObjectParameter outputValue = new ObjectParameter("HW_OT_CatID", 0);
                context.STCustomerByOvertimeCheckingTime(orderNumber, customerID, outputValue);
                handlingOvertimeCategoryID = Convert.ToInt32(outputValue.Value);
            }

            DataProcess<STComboServiceOvertime_Result> comboServiceOvertime = new DataProcess<STComboServiceOvertime_Result>();
            List<STComboServiceOvertime_Result> listcomboServiceOvertime = new List<STComboServiceOvertime_Result>();
            if (handlingOvertimeCategoryID == 208)
            {
                listcomboServiceOvertime = (List<STComboServiceOvertime_Result>)comboServiceOvertime.Executing("STComboServiceOvertime @CustomerID={0}, @ServiceName={1}", customerID, "Normal");
            }
            else if (handlingOvertimeCategoryID == 209)
            {
                listcomboServiceOvertime = (List<STComboServiceOvertime_Result>)comboServiceOvertime.Executing("STComboServiceOvertime @CustomerID={0}, @ServiceName={1}", customerID, "Sunday");
            }
            else if (handlingOvertimeCategoryID == 210)
            {
                listcomboServiceOvertime = (List<STComboServiceOvertime_Result>)comboServiceOvertime.Executing("STComboServiceOvertime @CustomerID={0}, @ServiceName={1}", customerID, "Holiday");
            }
            else if (handlingOvertimeCategoryID == 0)
            {
                listcomboServiceOvertime = (List<STComboServiceOvertime_Result>)comboServiceOvertime.Executing("STComboServiceOvertime @CustomerID={0}", customerID);
            }
            lookUpEditHandlingOvertimeCategoryID.Properties.DataSource = listcomboServiceOvertime;
        }

        private void btnNote_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            printDispatchingNote(false);
        }

        private void btnNoteClient_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            printDispatchingNoteClient(false);
        }

        private void btnNoteDetail_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            printDispatchingNoteDetail(false);
        }

        private void layoutControlItem52_DoubleClick(object sender, EventArgs e)
        {
            frm_ST_StockOnHandOneCustomer stockForm = new frm_ST_StockOnHandOneCustomer(Convert.ToInt32(this.lookUpEditCustomerID.EditValue));
            if (!stockForm.Enabled) return;
            stockForm.ShowDialog();
        }

        private void btnPlanA4ByExp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            printPlanA4_ExpDate(true);
        }

        private void iConfirm_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DateTime timeIn = DateTime.Now;

            // Check start time and time in
            if (this.timeEditEndTime.EditValue != null)
            {
                // Get laste time in
                DataProcess<Gate_TruckInOut> gateTrucInOutDA = new DataProcess<Gate_TruckInOut>();
                var gatetruckList = gateTrucInOutDA.Select(g => g.OrderNumber == this.textEditOrderID.Text);
                if (gatetruckList != null && gatetruckList.Count() > 0)
                {
                    timeIn = (DateTime)gatetruckList.OrderByDescending(g => g.OrderNumber).FirstOrDefault().TimeIn;
                    if (timeIn != null)
                    {
                        if (timeIn > this.timeEditStartTime.DateTime)
                        {
                            System.Text.StringBuilder msgContents = new System.Text.StringBuilder();
                            msgContents.Append("Start Time or Time In is not correct! ");
                            msgContents.Append(Environment.NewLine);
                            msgContents.Append("Start time must be later time in!");
                            msgContents.Append(Environment.NewLine);
                            msgContents.Append(" - Time In: " + timeIn.ToLongDateString() + " " + Environment.NewLine);
                            msgContents.Append(" - Start time: " + this.timeEditStartTime.DateTime.ToLongDateString());
                            MessageBox.Show(msgContents.ToString(), "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

            }

            var createdOrder = Convert.ToDateTime(this.dateEditDispatchingOrderDate.EditValue);
            var dateLimiter = Convert.ToDateTime(createdOrder.AddDays(1).ToString("yyyy-MM-dd 00:30:00"));

            // Validate confirm soon
            if (DateTime.Now.CompareTo(dateLimiter) > 0)
            {
                MessageBox.Show("Can not confirm, confirmation time was expired more than 30 minutes !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (timeIn > DateTime.Now.AddDays(1))
            {
                MessageBox.Show("Can not confirm, incorrect date !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.lke_TimeSlotID.EditValue == null || Convert.ToInt32(lke_TimeSlotID.EditValue) <= 0)
            {
                MessageBox.Show("Please update time slot before confirm !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.lke_TimeSlotID.Focus();
                this.lke_TimeSlotID.ShowPopup();
                return;
            }

            // Check send data before confirm
            int roID = Convert.ToInt32(this.textEditOrderID.Tag);
            int totalPalletNotSend = Convert.ToInt32(FileProcess.LoadTable("STCheckDODataHadSendBeforConfirm @DOID=" + roID).Rows[0]["totalPalletNotSend"]);
            if (totalPalletNotSend > 0)
            {
                var msgConfirm = MessageBox.Show("There are some pallets not yet post to Warenavi!\nYou need to post them before confirm this DO?", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool hasQtyInvalid = false;
            foreach (var item in this.listOrderDetail)
            {
                // Check Qty sync with wareNavi is equal with qty RODetail send
                int qtyDiff = Convert.ToInt32(FileProcess.LoadTable("STCheckDOQTYSyncBeforeConfirm @DispatchingProductID=" + item.DispatchingProductID).Rows[0]["DifferenceQty"]);
                if (qtyDiff > 0)
                {
                    hasQtyInvalid = true;
                    return;
                }
            }
            if (hasQtyInvalid)
            {
                XtraMessageBox.Show("Qty booking and Qty actual is invalid! Please check it before confirm", "TWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check customer was billed
            DataProcess<Billings> billingDA = new DataProcess<Billings>();
            int customerID = Convert.ToInt32(this.lookUpEditCustomerID.EditValue);
            var billings = billingDA.Select(b => b.IsDeleted == false && b.CustomerID == customerID);

            DateTime dispatchingOrdate = this.dateEditDispatchingOrderDate.DateTime;
            if (billings != null && billings.Count() > 0)
            {
                DateTime billMaxDate = billings.Max(b => b.BillingToDate);
                if (dispatchingOrdate <= billMaxDate)
                {
                    MessageBox.Show("This customer is billed! Can not confirm, please contact your Manager!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Check customer hold
            bool ishold = (bool)AppSetting.CustomerList.Where(c => c.CustomerID == Convert.ToInt32(this.lookUpEditCustomerID.EditValue)).FirstOrDefault().Hold;
            if (ishold)
            {
                MessageBox.Show("Can not confirm because this customer is on hold", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check destination port
            // Check customer client
            bool isRequirementClient = Convert.ToBoolean(lookUpEditCustomerID.Properties.GetDataSourceValue("DispatchingByClient", lookUpEditCustomerID.ItemIndex));
            if (isRequirementClient)
            {
                if (this.lookUpEditCustomerClientID.EditValue != null)
                {
                    if (Convert.ToInt32(this.lookUpEditCustomerClientID.EditValue) == 1)
                    {
                        MessageBox.Show("This Customer requires client input !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        // reload customer client
                        DataProcess<STCustomerClients_Result> customerClientDA = new DataProcess<STCustomerClients_Result>();
                        this.lookUpEditCustomerClientID.Properties.DataSource = customerClientDA.Executing("STCustomerClients @CustomerID={0}", Convert.ToInt32(this.lookUpEditCustomerID.EditValue));
                        this.lookUpEditCustomerClientID.Properties.ValueMember = "CustomerClientID";
                        this.lookUpEditCustomerClientID.Properties.DisplayMember = "CustomerClientName";
                        return;
                    }
                }
            }

            if (this.lookUpEditHandlingOvertimeCategoryID.EditValue == null || this.lookUpEditHandlingOvertimeCategoryID.EditValue.Equals(0))
            {
                this.lookUpEditHandlingOvertimeCategoryID.Focus();
                this.lookUpEditHandlingOvertimeCategoryID.ShowPopup();
                return;
            }

            if (this.lkeDockNumber.EditValue == null)
            {
                this.lkeDockNumber.Focus();
                this.lkeDockNumber.ShowPopup();
                return;
            }

            // check if DO has carton 0 kg before confrim:
            string sql = "ST_WMS_CheckCartonBeforeConfirm " + Convert.ToInt32(this.textEditOrderID.Tag);
            DataTable dttb = FileProcess.LoadTable(sql);
            if (Convert.ToInt32(dttb.Rows[0]["checkCartonInvalid"]) > 0)
            {
                MessageBox.Show("THERE ARE CARTON = 0 KG IN DO , PLEASE RE-CHECK !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            //DataProcess<STBarcodeScan_Order_Results_Result> sTBarcodeScan_Order_ResultsDA = new DataProcess<STBarcodeScan_Order_Results_Result>();
            //sTBarcodeScan_Order_ResultsDA.Executing("STBarcodeScan_Order_Results @DispatchingOrderID={0},@OrderType={1}", Convert.ToInt32(this.textEditOrderID.Tag), "DO");
            //sTBarcodeScan_Order_ResultsDA.Executing("STTransaction @OrderNumber={0}", this.textEditOrderID.Text);

            DataProcess<Customers> customerDA = new DataProcess<Customers>();
            int customerIDLookup = Convert.ToInt32(this.lookUpEditCustomerID.EditValue);
            var currentCustomer = customerDA.Select(c => c.CustomerID == customerIDLookup).FirstOrDefault();
            bool isSendNoteMail = Convert.ToBoolean(currentCustomer.SendNote);
            frm_WM_ConfirmationOne frmConfirm = new frm_WM_ConfirmationOne(Convert.ToInt32(this.textEditOrderID.Tag), this.textEditOrderID.Text, isSendNoteMail, Convert.ToInt32(this.lookUpEditCustomerID.EditValue));
            if (!frmConfirm.Enabled) return;
            frmConfirm.ShowDialog();
            this.LoadDataDetail(Convert.ToInt32(this.textEditOrderID.Tag));

        }

        private void textEditSealNumber_Leave(object sender, EventArgs e)
        {
            if (textEditSealNumber.Text.Length > 30)
            {
                textEditSealNumber.Text = String.Empty;
                XtraMessageBox.Show("Seal must be <= 30 characters !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.textEditSealNumber.Focus();
                return;
            }
            if (textEditSealNumber.IsModified)
            {
                UpdateDO();
            }
        }

        private void timeEditEndTime_Leave(object sender, EventArgs e)
        {
            if (timeEditEndTime != null && timeEditEndTime.DateTime.Year >= 2016)
            {
                timeEditEndTime.DateTime = new DateTime(timeEditEndTime.DateTime.Year, timeEditEndTime.DateTime.Month, timeEditEndTime.DateTime.Day, timeEditEndTime.DateTime.Hour, timeEditEndTime.DateTime.Minute, 0, timeEditEndTime.DateTime.Kind);
                if (timeEditStartTime != null)
                {
                    timeEditStartTime.DateTime = timeEditStartTime.DateTime.AddMilliseconds(-timeEditStartTime.DateTime.Second);

                    if (Convert.ToDateTime(timeEditStartTime.DateTime) > Convert.ToDateTime(timeEditEndTime.DateTime))
                    {
                        XtraMessageBox.Show("Start time <= End time", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.timeEditEndTime.Focus();
                    }
                }
                else
                {
                    XtraMessageBox.Show("Enter Start time", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void rpi_hpl_Remark_DoubleClick(object sender, EventArgs e)
        {
            var currentDip = (DispatchingProducts)this.gridViewOrderDetail.GetFocusedRow();
            this.LoadDispatchingOrderDetail(currentDip);
        }

        private void gridViewOrderDetail_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.RowHandle < 0) return;
            GridView view = sender as GridView;
            if (e.RowHandle == view.FocusedRowHandle)
                e.Appearance.BackColor = Color.Gainsboro;

            if (this.isLockOrder) return;
            if (this.expiredDateSource == null || this.expiredDateSource.Rows.Count <= 0) return;
            int orderID = Convert.ToInt32(this.gridViewOrderDetail.GetRowCellValue(e.RowHandle, "DispatchingProductID"));
            int countExp = this.expiredDateSource.Select("OrderID = " + orderID).Count();
            if (countExp <= 0) return;
            e.Appearance.BackColor = Color.Red;
        }

        private void lookUpEditCustomerID_Click(object sender, EventArgs e)
        {
            this.lookUpEditCustomerID.Focus();
            this.lookUpEditCustomerID.SelectAll();
        }

        private void textEditOrderID_DoubleClick(object sender, EventArgs e)
        {

            frm_WM_QuantitiesOfPrint frm = new frm_WM_QuantitiesOfPrint();
            frm.ShowDialog();
            qtyPrint = frm.Qty;
            if (qtyPrint == 0) return;

            rptDOSpecialRequirementPrint rp = new rptDOSpecialRequirementPrint();

            rp.txtCustomerNumber.Text = lookUpEditCustomerID.Text;
            rp.txtCustomerName.Text = textEditCustomerName.Text;
            rp.txtDispatchingOrderDate.Text = dateEditDispatchingOrderDate.Text;
            rp.txtDispatchingOrderNumber.Text = textEditOrderID.Text;
            rp.txtSpecialRequirement.Text = memoEditTruckAndDetail.Text;
            rp.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
            rp.RequestParameters = false;
            rp.CreateDocument();

            for (int i = 0; i < qtyPrint - 1; i++)
            {
                rptDOSpecialRequirementPrint rptmp = new rptDOSpecialRequirementPrint();
                rptmp.txtCustomerNumber.Text = lookUpEditCustomerID.Text;
                rptmp.txtCustomerName.Text = textEditCustomerName.Text;
                rptmp.txtDispatchingOrderDate.Text = dateEditDispatchingOrderDate.Text;
                rptmp.txtDispatchingOrderNumber.Text = textEditOrderID.Text;
                rptmp.txtSpecialRequirement.Text = memoEditTruckAndDetail.Text;
                rptmp.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
                rptmp.CreateDocument();
                rp.Pages.AddRange(rptmp.Pages);
            }

            // Reset all page numbers in the resulting document. 
            rp.PrintingSystem.ContinuousPageNumbering = true;
            rp.Print();
        }

        private void textEditInernalRemark_Leave(object sender, EventArgs e)
        {
            if (textEditInernalRemark.IsModified)
            {
                UpdateDO();
                this.orderTraceDate = this.dateEditDispatchingOrderDate.DateTime;
            }
        }

        private void mnu_btn_Copy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string productNumberSelected = this.gridViewOrderDetail.GetFocusedDisplayText();
            if (string.IsNullOrEmpty(productNumberSelected)) return;
            productNumberSelected = productNumberSelected.Split('-')[1];
            Clipboard.Clear();
            Clipboard.SetText(productNumberSelected);
        }

        private void gridViewOrderDetail_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.Column == null || e.HitInfo.InRow == false) return;
            switch (e.HitInfo.Column.FieldName)
            {
                case "ProductNumber":
                case "ProductName":
                    this.popupOptionsCell.ShowPopup(Control.MousePosition);
                    break;
                default:
                    break;
            }
        }

        private void memoEditTruckAndDetail_MouseLeave(object sender, EventArgs e)
        {
            if (this.isTruckModified)
            {
                if (memoEditTruckAndDetail.Text.Trim() != "" && (memoEditTruckAndDetail.Tag != null && memoEditTruckAndDetail.Text.Trim() != memoEditTruckAndDetail.Tag.ToString()))
                {
                    UpdateDO();
                    this.isTruckModified = false;
                }
            }
        }

        /// <summary>
        /// Close form when ESC key press
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                this.Hide();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void gridViewOrderDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Delete))
            {

                if (this.txtEDIMessageSentTime.Text.Length > 0)
                {
                    XtraMessageBox.Show("This DO already sent EDI , can not delete!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DispatchingProducts dispatchingProductSelected = null;
                DataProcess<object> deleteDispatchingProductDA = new DataProcess<object>();
                foreach (var rowIndex in this.gridViewOrderDetail.GetSelectedRows())
                {
                    dispatchingProductSelected = (DispatchingProducts)this.gridViewOrderDetail.GetRow(rowIndex);
                    if (dispatchingProductSelected.Status > 0)
                    {
                        MessageBox.Show("Can not delete accepted or confirmed dispatching product !", "TPWMS");
                        this.gridViewOrderDetail.SelectRow(rowIndex);
                        return;
                    }
                    else
                    {
                        deleteDispatchingProductDA.ExecuteNoQuery("STDispatchingProductDelete @varDispatchingProductID={0},@varUser={1}", dispatchingProductSelected.DispatchingProductID, AppSetting.CurrentUser.LoginName);
                    }
                }

                this.LoadDataDetail(Convert.ToInt32(this.textEditOrderID.Tag));
            }
        }

        private void SetEvent()
        {
            this.btnDelete.ItemClick += BtnDelete_ItemClick;
            this.btnPreviewNote.ItemClick += BtnPreviewNote_ItemClick;
            this.btnPrintNote.ItemClick += BtnPrintNote_ItemClick;
            this.btnConfirmed.ItemClick += BtnConfirmed_ItemClick;
        }

        private void BtnConfirmed_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.viewNotes.ConfirmNote(AppSetting.CurrentUser.LoginName);
            this.barEditItem1.EditValue = AppSetting.CurrentUser.LoginName;
            // this.barEditItem2.EditValue = DateTime.Now;
            this.btnConfirmed.Enabled = false;
            this.btnDelete.Enabled = false;
        }

        private void BtnPrintNote_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.viewNotes.PreviewReport(false);
        }

        private void BtnPreviewNote_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.viewNotes.PreviewReport(true);
        }

        private void BtnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.viewNotes.DeleteNote();
        }

        private void timeEditStartTime_Validating(object sender, CancelEventArgs e)
        {
            if (!this.timeEditStartTime.IsModified) return;
            if (timeEditStartTime != null && timeEditStartTime.DateTime.Year >= 2016)
            {
                timeEditStartTime.DateTime = new DateTime(timeEditStartTime.DateTime.Year, timeEditStartTime.DateTime.Month, timeEditStartTime.DateTime.Day, timeEditStartTime.DateTime.Hour, timeEditStartTime.DateTime.Minute, 0, timeEditStartTime.DateTime.Kind);
                if (timeEditEndTime != null && timeEditEndTime.DateTime.Year >= 2016)
                {
                    if (this.timeEditStartTime.DateTime < DateTime.Now.AddDays(-2))
                    {
                        XtraMessageBox.Show("Invalid date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        e.Cancel = true;
                        this.timeEditStartTime.Focus();
                        this.validateList[timeEditStartTime] = true;
                        return;
                    }
                    timeEditEndTime.DateTime = new DateTime(timeEditEndTime.DateTime.Year, timeEditEndTime.DateTime.Month, timeEditEndTime.DateTime.Day, timeEditEndTime.DateTime.Hour, timeEditEndTime.DateTime.Minute, 0, timeEditEndTime.DateTime.Kind);
                    if (Convert.ToDateTime(timeEditStartTime.DateTime) > Convert.ToDateTime(timeEditEndTime.DateTime))
                    {
                        XtraMessageBox.Show("Start time <= End time", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.timeEditStartTime.Focus();
                        this.validateList[timeEditStartTime] = true;
                        e.Cancel = true;
                        return;
                    }
                }
            }
        }

        private void timeEditEndTime_Validating(object sender, CancelEventArgs e)
        {
            if (!this.timeEditEndTime.IsModified) return;
            e.Cancel = false;
            this.validateList[timeEditEndTime] = false;
            if (timeEditEndTime != null && timeEditEndTime.DateTime.Year >= 2016)
            {
                timeEditEndTime.DateTime = new DateTime(timeEditEndTime.DateTime.Year, timeEditEndTime.DateTime.Month, timeEditEndTime.DateTime.Day, timeEditEndTime.DateTime.Hour, timeEditEndTime.DateTime.Minute, 0, timeEditEndTime.DateTime.Kind);
                if (timeEditStartTime != null)
                {
                    if (this.timeEditEndTime.DateTime > DateTime.Now)
                    {
                        XtraMessageBox.Show("Invalid date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        e.Cancel = true;
                        this.validateList[timeEditEndTime] = true;
                        this.timeEditEndTime.Focus();
                        return;
                    }
                    timeEditStartTime.DateTime = timeEditStartTime.DateTime.AddMilliseconds(-timeEditStartTime.DateTime.Second);

                    if (Convert.ToDateTime(timeEditStartTime.DateTime) > Convert.ToDateTime(timeEditEndTime.DateTime))
                    {
                        XtraMessageBox.Show("Start time <= End time", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        e.Cancel = true;
                        this.validateList[timeEditEndTime] = true;
                        this.timeEditEndTime.Focus();
                        return;
                    }
                }
                else
                {
                    XtraMessageBox.Show("Enter Start time", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Cancel = true;
                    this.timeEditStartTime.Focus();
                    this.validateList[timeEditStartTime] = true;
                    return;
                }
            }
        }

        private void timeEditStartTime_EditValueChanged(object sender, EventArgs e)
        {
            if (timeEditStartTime != null && timeEditEndTime != null && (Convert.ToDateTime(timeEditStartTime.EditValue) <= Convert.ToDateTime(timeEditEndTime.EditValue)))
            {
                if (timeEditStartTime != null && timeEditStartTime.DateTime.Year >= 2016)
                {
                    timeEditStartTime.DateTime = new DateTime(timeEditStartTime.DateTime.Year, timeEditStartTime.DateTime.Month, timeEditStartTime.DateTime.Day, timeEditStartTime.DateTime.Hour, timeEditStartTime.DateTime.Minute, 0, timeEditStartTime.DateTime.Kind);
                    if (timeEditEndTime != null && timeEditEndTime.DateTime.Year >= 2016)
                    {
                        if (this.timeEditStartTime.DateTime < DateTime.Now.AddDays(-2))
                        {
                            return;
                        }
                        timeEditEndTime.DateTime = new DateTime(timeEditEndTime.DateTime.Year, timeEditEndTime.DateTime.Month, timeEditEndTime.DateTime.Day, timeEditEndTime.DateTime.Hour, timeEditEndTime.DateTime.Minute, 0, timeEditEndTime.DateTime.Kind);
                        if (Convert.ToDateTime(timeEditStartTime.DateTime) > Convert.ToDateTime(timeEditEndTime.DateTime))
                        {
                            return;
                        }
                    }
                }
                if (isUpdate && timeEditStartTime.IsModified)
                {
                    UpdateDO();
                }
            }
        }

        private void timeEditEndTime_EditValueChanged(object sender, EventArgs e)
        {
            if (timeEditStartTime != null && timeEditEndTime != null && (Convert.ToDateTime(timeEditStartTime.EditValue) <= Convert.ToDateTime(timeEditEndTime.EditValue)))
            {
                if (timeEditEndTime != null && timeEditEndTime.DateTime.Year >= 2016)
                {
                    timeEditEndTime.DateTime = new DateTime(timeEditEndTime.DateTime.Year, timeEditEndTime.DateTime.Month, timeEditEndTime.DateTime.Day, timeEditEndTime.DateTime.Hour, timeEditEndTime.DateTime.Minute, 0, timeEditEndTime.DateTime.Kind);
                    if (timeEditStartTime != null)
                    {
                        if (this.timeEditEndTime.DateTime > DateTime.Now)
                        {
                            return;
                        }
                        timeEditStartTime.DateTime = timeEditStartTime.DateTime.AddMilliseconds(-timeEditStartTime.DateTime.Second);

                        if (Convert.ToDateTime(timeEditStartTime.DateTime) > Convert.ToDateTime(timeEditEndTime.DateTime))
                        {
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }
                }

                if (isUpdate && timeEditEndTime.IsModified)
                {
                    UpdateDO();
                }
            }
        }

        private void dateEditDispatchingOrderDate_Validating(object sender, CancelEventArgs e)
        {
            if (this.dateEditDispatchingOrderDate.EditValue == null) return;
            if (!this.dateEditDispatchingOrderDate.IsModified) return;
            if (this.dateEditDispatchingOrderDate.DateTime.Date < DateTime.Now.AddDays(-1).Date
                || this.dateEditDispatchingOrderDate.DateTime.Date > DateTime.Now.AddDays(2).Date)
            {
                this.dateEditDispatchingOrderDate.EditValue = this.orderTraceDate;
                e.Cancel = true;
            }

            if (e.Cancel == false && isUpdate && dateEditDispatchingOrderDate.IsModified)
            {
                UpdateDO();
                this.orderTraceDate = this.dateEditDispatchingOrderDate.DateTime;
            }
        }

        private void btnPickingSlipData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int dispatchingOrderID = Convert.ToInt32(textEditOrderID.Tag);
            frm_WM_Dialog_PickingSlip Pick = new frm_WM_Dialog_PickingSlip(dispatchingOrderID, "DO");
            Pick.Show();
        }

        private void dockPanelVehicle_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            string orderNumber = this.textEditOrderID.Text;
            string qty = Convert.ToString(this.gridColumnTotalPackages.SummaryItem.SummaryValue);
            if (this.viewVehicle == null)
            {
                this.viewVehicle = new urc_WM_Vehicle(Convert.ToInt32(this.lookUpEditCustomerID.Tag), this.textEditCustomerName.Text, this.textEditVehicleNumber.Text, orderNumber, "Nhap", this.textEditSealNumber.Text, this.lkeDockNumber.Text, qty);
                this.viewVehicle.Parent = this.dockPanelVehicle;
            }
            else
            {
                this.RefreshVehicleData();
            }
        }

        private void dockPanelEmployees_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            decimal totalPallet = Convert.ToDecimal(this.gridColumnPallets.SummaryItem.SummaryValue);
            decimal totalWeight = Convert.ToDecimal(this.gridColumn5.SummaryItem.SummaryValue);
            decimal totalCartons = Convert.ToDecimal(this.gridColumnTotalPackages.SummaryItem.SummaryValue);
            if (this.viewEmployee == null)
            {
                this.viewEmployee = new urc_WM_EmployeeInfo(textEditOrderID.Text, totalPallet, totalWeight, totalCartons);
                this.viewEmployee.Parent = this.dockPanelEmployees;
            }
            else
            {
                this.RefreshEmployeeData();
            }
        }

        /// <summary>
        /// Refresh vehicle data
        /// </summary>
        private void RefreshVehicleData()
        {
            string qty = Convert.ToString(this.gridColumnTotalPackages.SummaryItem.SummaryValue);
            string orderNumber = this.textEditOrderID.Text;
            this.viewVehicle.UpdateParam(Convert.ToInt32(this.lookUpEditCustomerID.Tag), this.textEditCustomerName.Text, this.textEditVehicleNumber.Text, this.textEditSealNumber.Text, this.lkeDockNumber.Text);
            this.viewVehicle.InitData(orderNumber, qty);
            this.viewVehicle.Update();
            this.viewVehicle.Refresh();
        }

        /// <summary>
        /// Refresh employee data
        /// </summary>
        private void RefreshEmployeeData()
        {
            decimal totalPallet = Convert.ToDecimal(this.gridColumnPallets.SummaryItem.SummaryValue);
            decimal totalWeight = Convert.ToDecimal(this.gridColumn5.SummaryItem.SummaryValue);
            decimal totalCartons = Convert.ToDecimal(this.gridColumnTotalPackages.SummaryItem.SummaryValue);
            this.viewEmployee.UpdateParameter(totalCartons, totalPallet, totalWeight);
            this.viewEmployee.LoadEmployeeWorking(this.textEditOrderID.Text);
            this.viewEmployee.Update();
            this.viewEmployee.Refresh();
        }



        private void dockPanelservice_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            if (this.viewService == null)
            {
                this.viewService = new urc_WM_OtherService(textEditOrderID.Text);
                if (this.listDispatchingOrders.Count > 0)
                {
                    this.viewService.DispatchingOrderInfo = listDispatchingOrders[this.dataNavigatorDispatchingOrders.Position];
                }
                this.viewService.Parent = this.dockPanelservice;
            }
            else
            {
                if (this.listDispatchingOrders.Count > 0)
                {
                    this.viewService.DispatchingOrderInfo = listDispatchingOrders[this.dataNavigatorDispatchingOrders.Position];
                }
                this.viewService.InitData(this.textEditOrderID.Text);
            }
        }

        private void textEditVehicleNumber_EditValueChanged(object sender, EventArgs e)
        {
            if (this.isUpdate && this.textEditVehicleNumber.IsModified)
            {
                this.UpdateDO();
            }
        }

        private void textEditCustomerOrderNumber_EditValueChanged(object sender, EventArgs e)
        {
            if (this.isUpdate && this.textEditCustomerOrderNumber.IsModified)
            {
                this.UpdateDO();
            }
        }

        private void spinEditTemperature_Leave(object sender, EventArgs e)
        {
            if (spinEditTemperature.IsModified)
            {
                UpdateDO();
                this.orderTraceDate = this.dateEditDispatchingOrderDate.DateTime;
            }
        }

        private void lookUpEditCustomerID_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.KeyCode.Equals(Keys.Enter)) return;
            if (this.btn_WM_NewProduct.Enabled && this.lookUpEditCustomerID.ReadOnly)
            {
                this.btn_WM_NewProduct.PerformClick();
            }
        }

        private void lke_TimeSlotID_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.Value == null) return;
            this.lke_TimeSlotID.EditValue = e.Value;
            if (this.isUpdate) this.UpdateDO();
            btn_WM_NewProduct.ItemAppearance.Normal.BackColor = Color.FromArgb(153, 180, 209);
            btn_WM_NewProduct.Links[0].Focus();
        }

        private void btnNoteClientSmall_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            printDispatchingNoteClientSmall(false);
        }

        private void btnNoteSmallView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            printDispatchingNoteClientSmall(true);
        }

        private void gridViewOrderDetail_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle < 0) return;
            int productID = Convert.ToInt32(this.gridViewOrderDetail.GetFocusedRowCellValue("DispatchingProductID"));
            if (productID <= 0) return;
            switch (e.Column.FieldName)
            {
                case "Remark":
                    this.dispatchingOrderDA.ExecuteNoQuery("Update DispatchingProducts Set Remark=N'" + e.Value + "' Where DispatchingProductID=" + productID);
                    break;
                case "CustomerRef":
                    this.dispatchingOrderDA.ExecuteNoQuery("Update DispatchingProducts Set CustomerRef=N'" + e.Value + "' Where DispatchingProductID=" + productID);
                    break;
            }
        }

        private void repositoryItemSpinEditTotalPackages_Click(object sender, EventArgs e)
        {
            int dispatchingProductID = Convert.ToInt32(this.gridViewOrderDetail.GetFocusedRowCellValue("DispatchingProductID"));
            var frm = new frm_WM_Dialog_DispatchingProductDetails(dispatchingProductID);
            frm.ShowDialog();
        }

        private void lkeDockNumber_EditValueChanged(object sender, EventArgs e)
        {
            if (this.lkeDockNumber.EditValue == null) return;
            if (this.lkeDockNumber.IsModified)
            {
                int dispatchingOrderID = Convert.ToInt32(this.textEditOrderID.Tag);
                this.dispatchingOrderDA.ExecuteNoQuery("Update DispatchingOrders Set DockDoorID=" + this.lkeDockNumber.EditValue + " Where DispatchingOrderID=" + dispatchingOrderID);
            }
        }

        private void btnDelivery_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int doID = Convert.ToInt32(textEditOrderID.Tag);
            DataProcess<object> process = new DataProcess<object>();
            process.ExecuteNoQuery("STDeliveryOrderInsert @DispatchingOrderID={0},@CreatedBy={1}", doID, AppSetting.CurrentUser.LoginName);
            frm_WM_DeliveryOrder deliveryForm = new frm_WM_DeliveryOrder();
            deliveryForm.Show();
        }

        private void btnNoteCarton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int doID = Convert.ToInt32(textEditOrderID.Tag);
            int customerID = this.lookUpEditCustomerID.EditValue == null ? -1 : (int)this.lookUpEditCustomerID.EditValue;
            var dataSource = FileProcess.LoadTable("STDispatchingNoteByCarton @varDispatchingOrderID=" + doID);
            customerType = lookUpEditCustomerID.Properties.GetDataSourceValue("CustomerType", lookUpEditCustomerID.ItemIndex).ToString();
            if (customerType.Equals(CustomerTypeEnum.RANDOM_WEIGHT) && customerID != 1054)
            {
                rptDispatchingNoteByCarton rpt = new rptDispatchingNoteByCarton();
                rpt.RequestParameters = false;
                rpt.Parameters["varLoginUser"].Value = AppSetting.CurrentUser.LoginName;
                rpt.Parameters["varCurrentUser"].Value = fullInfoEmployees.FullName;
                rpt.Parameters["Barcode"].Value = "DO" + doID.ToString("D9");
                rpt.DataSource = dataSource;
                ReportPrintToolWMS reportPrintTool = new ReportPrintToolWMS(rpt);
                reportPrintTool.AutoShowParametersPanel = false;
                reportPrintTool.ShowPreviewDialog();
            }
            else
            {
                rptDispatchingNoteByCartonGS rpt = new rptDispatchingNoteByCartonGS();
                rpt.RequestParameters = false;
                rpt.Parameters["varLoginUser"].Value = AppSetting.CurrentUser.LoginName;
                rpt.Parameters["varCurrentUser"].Value = fullInfoEmployees.FullName;
                rpt.Parameters["Barcode"].Value = "DO" + doID.ToString("D9");
                rpt.DataSource = dataSource;
                ReportPrintToolWMS reportPrintTool = new ReportPrintToolWMS(rpt);
                reportPrintTool.AutoShowParametersPanel = false;
                reportPrintTool.ShowPreviewDialog();
            }

        }

        /// <summary>
        /// Load list product has been expires date
        /// Flat =0 DispatchingOrderID
        /// Flat =1 DispatchingProductID
        /// Flat =2 DispatchingLocationID
        /// </summary>
        /// <param name="orderID">int</param>
        /// <param name="flag">int</param>
        private void LoadDataExpiredDate(int orderID, int flag)
        {
            this.expiredDateSource = FileProcess.LoadTable("STCheckUseByDateProduct @OrderID=" + orderID + ",@Flat=" + flag);
        }

        private void barButtonUpdateReference_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Are you sure to copy remark from Location to reference Dispatching Product ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            int dispatchingOrderID = Convert.ToInt32(this.textEditOrderID.Tag);
            if (dispatchingOrderID <= 0) return;

            dispatchingOrderDA.ExecuteNoQuery("STDispatchingOrderUpdateReference @OrderID={0}", dispatchingOrderID);
            this.LoadDataDetail(dispatchingOrderID);
        }

        private void rpi_hpl_productPackages_DoubleClick(object sender, EventArgs e)
        {
            if (this.isLockOrder) return;
            string package = Convert.ToString(this.gridViewOrderDetail.GetFocusedRowCellValue("Packages"));
            int proID = Convert.ToInt32(this.gridViewOrderDetail.GetFocusedRowCellValue("ProductID"));
            if (string.IsNullOrEmpty(package)) return;
            frm_WM_UpdateProductPackage frmChange = new frm_WM_UpdateProductPackage(proID, package);
            frmChange.ShowDialog();
            this.gridViewOrderDetail.SetFocusedRowCellValue("Packages", frmChange.NewPackage);
            this.gridViewOrderDetail.SetFocusedRowCellValue("Pcs", frmChange.NewPcs);
            int doProductID = Convert.ToInt32(this.gridViewOrderDetail.GetFocusedRowCellValue("DispatchingProductID"));
            this.dispatchingOrderDA.ExecuteNoQuery("Update DispatchingProducts Set Packages=N'" + frmChange.NewPackage + "',Pcs=" + frmChange.NewPcs + " Where DispatchingProductID=" + doProductID);
        }

        private void textEditCustomerOrderNumber_DoubleClick(object sender, EventArgs e)
        {
            rptTemClientByDOBC rptTem = new rptTemClientByDOBC();
            rptTemClientByDOMM rptTemMM = new rptTemClientByDOMM();
            //rptTote.Parameters["parameter1"].Value = 3;
            //rptTote.DataSource = "";// dataSourceTote;
            //rptTote.RequestParameters = false; 
            int dispatchingOrderID = Convert.ToInt32(textEditOrderID.Tag);
            var DPNoteDetail = new object();
            //DataProcess<STDispatchingNote_Pcs_Result> dispatchingNoteDetail = new DataProcess<STDispatchingNote_Pcs_Result>();
            //DPNoteDetail = dispatchingNoteDetail.Executing("STDispatchingNote_Pcs @varDispatchingOrderID={0}", dispatchingOrderID);
            DPNoteDetail = FileProcess.LoadTable("STTemClientByDO @DispatchingOrderID=" + dispatchingOrderID);
            rptTem.DataSource = DPNoteDetail;

            ReportPrintToolWMS printTool = new ReportPrintToolWMS(rptTem);
            printTool.AutoShowParametersPanel = false;
            printTool.ShowPreview();

            rptTemMM.DataSource = DPNoteDetail;
            ReportPrintToolWMS printToolMM = new ReportPrintToolWMS(rptTemMM);
            printToolMM.AutoShowParametersPanel = false;
            printToolMM.ShowPreview();
        }

        private void textEditDispatchingOrderProgress_Leave(object sender, EventArgs e)
        {
            if (this.textEditDispatchingOrderProgress.IsModified)
            {
                this.UpdateDO();
            }
        }

        private void memoEditTruckAndDetail_Leave(object sender, EventArgs e)
        {
            if (this.lke_TimeSlotID.EditValue == null || Convert.ToInt32(lke_TimeSlotID.EditValue) <= 0)
            {
                //MessageBox.Show("Please update time slot before confirm !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.lke_TimeSlotID.Focus();
                this.lke_TimeSlotID.ShowPopup();
            }
        }

        private void lke_TimeSlotID_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.KeyCode.Equals(Keys.Tab)) return;
            btn_WM_NewProduct.ItemAppearance.Normal.BackColor = Color.FromArgb(153, 180, 209);
            btn_WM_NewProduct.Links[0].Focus();
        }

        private void btnCreateCartons_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dx = FileProcess.LoadTable("STDispatchingCartonWeightInsertDO " + this.textEditOrderID.Tag + ",'" + AppSetting.CurrentUser.LoginName + "'");
            if (dx == null || dx.Rows.Count <= 0)
            {
                MessageBox.Show("Can not Create Empty Cartons for this Dispatching Order !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string vQty = Convert.ToString(dx.Rows[0]["QtyCtns"]);
                MessageBox.Show("Created " + vQty + " Ctns for the Order !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void barButtonSplitOrder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dl = MessageBox.Show("Are you sure to split details to new DO?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dl.Equals(DialogResult.No)) return;
            int v_DetailID = 0;
            foreach (var index in this.gridViewOrderDetail.GetSelectedRows())
            {
                try
                {
                    v_DetailID = Convert.ToInt32(this.gridViewOrderDetail.GetRowCellDisplayText(index, "DispatchingProductID"));
                }
                catch (Exception ex)
                {
                    log.Error("==> Error is unexpected");
                    log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                }
                DataProcess<object> dataProcess = new DataProcess<object>();

                int result = dataProcess.ExecuteNoQuery("Update DispatchingProducts set IsMoving={0}  where DispatchingProductID={1}", 1, v_DetailID);

            }
            int dispatchingOrderID = Convert.ToInt32(this.textEditOrderID.Tag);
            if (dispatchingOrderID <= 0) return;
            DataProcess<object> dataProcess1 = new DataProcess<object>();
            int resultProcess = dataProcess1.ExecuteNoQuery("ST_WMS_SplitDetailDO " + dispatchingOrderID + ",'" + AppSetting.CurrentUser.LoginName + "'");
            if (resultProcess < 0)
            {
                MessageBox.Show("Process Split Fail", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Split Ok", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.LoadDataDetail(dispatchingOrderID);
        }

        private void textEditCustomerOrderNumber2_EditValueChanged(object sender, EventArgs e)
        {
            if (this.isUpdate && this.textEditCustomerOrderNumber2.IsModified)
            {
                this.UpdateDO();
            }
        }

        private void barButtonReverseDO_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Are You Sure to Reverse this Dispatching Order  ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            int dispatchingOrderID = Convert.ToInt32(textEditOrderID.Tag);
            DA.DataProcess<object> DP = new DataProcess<object>();
            string sql = "STDispatchingOrderReverseUnAccept " + dispatchingOrderID + ", '" + AppSetting.CurrentUser.LoginName + "'";
            DataTable dt = FileProcess.LoadTable(sql);
            int PCID = Convert.ToInt32(dt.Rows[0]["ProductCheckingID"]);


            frm_M_ProductCheckingByRequest frm = new frm_M_ProductCheckingByRequest();
            frm.ProductCheckingIDFind = PCID;
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront();
            //if (v_Ret > 0)
            //{
            //    XtraMessageBox.Show("Dispatching Orders is reversed", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    //Code to go to productChecking
            //}

            //else
            //    XtraMessageBox.Show("Error Reversing Dispathching Orders", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btn_UnConfirmDO_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                objSelected = (DispatchingProducts)gridViewOrderDetail.GetFocusedRow();
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
            }
        }

        private void rpi_chk_IsWeighting_Click(object sender, EventArgs e)
        {


        }

        private void rpi_chk_IsWeighting_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DispatchingProducts DODetail = (DispatchingProducts)gridViewOrderDetail.GetFocusedRow();
                var chk = (CheckEdit)sender;
                string doDetailID = DODetail.DispatchingProductID.ToString();
                DataProcess<ST_WMS_LoadDPProductData_Result> dpProduct = new DataProcess<ST_WMS_LoadDPProductData_Result>();

                if (chk.Checked)
                {
                    /*
                     * Tạo OrderSerive MCT
                     * Câp nhập check 
                     * Cập nhât ID Serive
                     */
                    var data = dpProduct.Executing("ST_WMS_LoadDPProductDataAllPallet @ProductID = {0}", doDetailID).ToList();
                    this.grdDPProduct.DataSource = data;


                    //Tạo service 

                    OtherService service = new OtherService();
                    service.ServiceDate = DateTime.Now;
                    service.ServiceRemark = memoEditTruckAndDetail.Text;
                    service.Status = 0;

                    service.LockStatus = false;
                    service.CreatedBy = AppSetting.CurrentUser.LoginName;
                    service.CreatedTime = DateTime.Now;
                    service.CustomerID = Convert.ToInt32(lookUpEditCustomerID.EditValue);
                    service.EmployeeID = AppSetting.CurrentUser.EmployeeID;

                    DataProcess<OtherService> serviceDA = new DataProcess<OtherService>();
                    int IDService = serviceDA.Insert(service);


                    OtherServiceDetails detail = new OtherServiceDetails();
                    detail.ServiceID = 5510;
                    detail.OtherServiceID = service.OtherServiceID;
                    detail.OrderNumber = textEditOrderID.Text;
                    detail.Quantity = DODetail.TotalUnits;
                    detail.Invoiced = false;
                    detail.CreatedBy = AppSetting.CurrentUser.LoginName;
                    detail.CreatedTime = DateTime.Now;
                    detail.Description = "Automatic - " + DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                    //MCT 5510
                    DataProcess<OtherServiceDetails> detailDA = new DataProcess<OtherServiceDetails>();
                    detailDA.Insert(detail);

                    int result = dpProduct.ExecuteNoQuery("update DispatchingProducts set IsWeighting = " + 1 + ",OtherServiceID=" + service.OtherServiceID + " where DispatchingProductID=" + DODetail.DispatchingProductID);




                }
                else
                {
                    if (DODetail.OtherServiceID > 0)
                    {
                        int resultDeleteService = dpProduct.ExecuteNoQuery("ST_DeleteOrderService @OtherServiceID={0}", DODetail.OtherServiceID);
                        int result = dpProduct.ExecuteNoQuery("update DispatchingProducts set IsWeighting = " + 0 + ",OtherServiceID=" + 0 + " where DispatchingProductID=" + DODetail.DispatchingProductID);

                    }
                    this.grdDPProduct.DataSource = null;
                    this.grdPalletCartonDetails.DataSource = null;

                    //if (this.listRoDetailIsWeighting.Contains(roDetailID))
                    //{
                    //    this.listRoDetailIsWeighting.Remove(roDetailID);
                    //}
                }
                RefreshData_ReloadDataEvent(sender, e);
                //string roDetailIDs = string.Join(",", this.listRoDetailIsWeighting.ToArray());
                //LoadDataIsWeighting(roDetailIDs);
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
            }
        }

        private void gridViewOrderDetail_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {

        }

        private void gridViewOrderDetail_RowClick(object sender, RowClickEventArgs e)
        {

        }
        private void LoadGridLocation()
        {
            DispatchingProducts DODetail = (DispatchingProducts)gridViewOrderDetail.GetFocusedRow();
            if (DODetail != null)
            {
                string doDetailID = DODetail.DispatchingProductID.ToString();
                DataProcess<ST_WMS_LoadDPProductDataAllPallet_Result> dpProduct = new DataProcess<ST_WMS_LoadDPProductDataAllPallet_Result>();
                if (Convert.ToBoolean(DODetail.IsWeighting))
                {
                    /*
                     * Tạo OrderSerive MCT
                     * Câp nhập check 
                     * Cập nhât ID Serive
                     */
                    var data = dpProduct.Executing("ST_WMS_LoadDPProductDataAllPallet @ProductID = {0}", doDetailID).ToList();
                    this.grdDPProduct.DataSource = data;

                }
                else
                {

                    this.grdDPProduct.DataSource = null;
                    this.grdPalletCartonDetails.DataSource = null;

                }
            }

        }

        private void gridViewOrderDetail_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadGridLocation();

        }

        private void grvDPProduct_RowClick(object sender, RowClickEventArgs e)
        {
            if (grvDPProduct.FocusedRowHandle < 0) return;
            int palletID = Convert.ToInt32(this.grvDPProduct.GetFocusedRowCellValue("PalletID"));
            this.grdPalletCartonDetails.DataSource = FileProcess.LoadTable("STCartonDetails @OrderID=" + palletID + ",@Type=1");
        }

        private void btnPrintCartonDetails_Click(object sender, EventArgs e)
        {
            log.Debug("==> frm_WM_DispachingOrders chạy hàm PrintCartonDetail");
            int palletID = Convert.ToInt32(this.grvDPProduct.GetFocusedRowCellValue("PalletID"));
            rptInlabel lb = new rptInlabel();
            lb.DataSource = multilabel.Executing("STLabelPalletCartonWeight @PalletID={0}", palletID);
            IList<STLabelPalletCartonWeight> getCartonIDBarcode = (IList<STLabelPalletCartonWeight>)lb.DataSource;
            lb.bcCartonID.Text = getCartonIDBarcode.Select(obj => obj.CartonID.ToString()).FirstOrDefault();
            lb.RequestParameters = false;
            ReportPrintToolWMS printTool = new ReportPrintToolWMS(lb);
            printTool.AutoShowParametersPanel = false;
            printTool.ShowPreview();
        }

        private void btnSyncNavi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //
            int receivingOrderID = Convert.ToInt32(this.textEditOrderID.Tag);
            if (receivingOrderID <= 0 || this.listOrderDetail.Count <= 0) return;
            if (!NetworkHelper.IsConnectedToInternet())
            {
                MessageBox.Show("Không thể kết nối với Warenavi ! vui lòng kiểm tra đường truyền !", "TWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Co product nao da accept chua
            int hasRoDetailAccept = this.listOrderDetail.Count(r => r.Status == 1);
            if (hasRoDetailAccept <= 0)
            {
                MessageBox.Show("Chưa có sản phẩm nào được accept, vui lòng kiểm tra lại !", "TWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int resultInsert = this.dispatchingOrderDA.ExecuteNoQuery("STSendDOToNavi @DOID={0}", receivingOrderID);
            // Call API to post 
            APIProcess api = new APIProcess();
            string url = ConfigurationManager.AppSettings["RetrievalPlanData_Navi"];
            if (!string.IsNullOrEmpty(url))
            {
                string jsonRespond = api.Post(url, "");
                Navi_ACKRespond navi_ACKRespond = JsonConvert.DeserializeObject<Navi_ACKRespond>(jsonRespond);
                if (navi_ACKRespond == null || string.IsNullOrEmpty(navi_ACKRespond.Status))
                {
                    MessageBox.Show("Sync data to Navi is FAIL", "TWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    int statusRespond = Convert.ToInt32(navi_ACKRespond.Status);
                    if (statusRespond == 1)
                    {
                        MessageBox.Show("Sync data to Navi is OK", "TWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Sync data to Navi is FAIL", "TWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void dockPanelNotes_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            int roID = Convert.ToInt32(this.textEditOrderID.Text.Substring(3));
            string orderType = "DO";
            int customerID = this.lookUpEditCustomerID.EditValue == null ? -1 : (int)this.lookUpEditCustomerID.EditValue;
            if (this.viewNotes == null)
            {
                this.viewNotes = new urc_WM_Notes(orderType, roID, customerID);
                this.viewNotes.CustomerNumber = this.lookUpEditCustomerID.GetColumnValue("CustomerNumber").ToString();
                this.viewNotes.NoteDescription = this.textEditVehicleNumber.Text + " | " + this.memoEditTruckAndDetail.Text;
                this.viewNotes.VehicleNumber = this.textEditVehicleNumber.Text;
                this.viewNotes.Parent = this.dockPanelNotes;
            }
            else
            {
                this.RefreshNoteData();
            }
        }
        /// <summary>
        /// Refresh note report data
        /// </summary>
        private void RefreshNoteData()
        {
            int roID = Convert.ToInt32(this.textEditOrderID.Text.Substring(3));
            string orderType = "DO";
            int customerID = this.lookUpEditCustomerID.EditValue == null ? -1 : (int)this.lookUpEditCustomerID.EditValue;
            this.viewNotes.LoadData(orderType, roID, customerID);
            this.viewNotes.Update();
            this.viewNotes.Refresh();
        }

        private void dockPanelLandingReport_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            if (this.viewLoadingReport == null)
            {
                int dispatchingOrderID = Convert.ToInt32(this.textEditOrderID.Tag);
                this.viewLoadingReport = new urc_WM_LoadingReport(dispatchingOrderID);
                this.viewLoadingReport.Parent = this.dockPanelLandingReport;
            }
            else
            {
                this.RefreshLoadingReportData();
            }
        }
        /// <summary>
        /// Refresh loading report data
        /// </summary>
        private void RefreshLoadingReportData()
        {
            int dispatchingOrderID = Convert.ToInt32(this.textEditOrderID.Tag);
            this.viewLoadingReport.InitData(dispatchingOrderID);
            this.viewLoadingReport.Update();
            this.viewLoadingReport.Refresh();
        }

        private void lkeWorkType_EditValueChanged(object sender, EventArgs e)
        {
            if (this.isUpdate && this.lkeWorkType.IsModified)
            {
                this.UpdateDO();
            }
        }
    }
}
