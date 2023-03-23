using Common.Data;
using Common.Process;
using DA;
using DA.API;
using DA.Warehouse;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Windows.Forms;
using UI.APIs;
using UI.Helper;
using UI.Management;
using UI.MasterSystemSetup;
using UI.ReportFile;
using UI.StockTake;


namespace UI.WarehouseManagement
{
    public partial class frm_WM_ReceivingOrders : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        // Declare log
        DataProcess<STLabelPalletCartonWeight> multilabel = new DataProcess<STLabelPalletCartonWeight>();
        private static readonly ILog log = LogManager.GetLogger(typeof(frm_WM_ReceivingOrders));
        private static frm_WM_ReceivingOrders instance = null;
        int customerMainIDISO = 0;
        bool boflag = false;
        Employees fullInfoEmployees = null;
        string userName = AppSetting.CurrentUser.LoginName;
        BindingList<ReceivingOrders> listReceivingOrders = null;
        BindingList<ReceivingOrderDetails> listOrderDetail = new BindingList<ReceivingOrderDetails>();
        DataProcess<ReceivingOrders> receivingDa = new DataProcess<ReceivingOrders>();
        DataProcess<ReceivingOrderDetails> recevingOrderDetailDA = new DataProcess<ReceivingOrderDetails>();
        DataProcess<CustomerSupplier> customerDA = new DataProcess<CustomerSupplier>();
        IEnumerable<Customers> listCustomer;
        IList<ST_WMS_ExportROToDO_Result> resultExport;
        bool isFirstLoad = true;
        bool isUpdate = false;
        private int receivingOrderFind = -1;
        private ReceivingOrdersDA _roDA;
        private bool _isReload = false;
        private DateTime orderTraceDate = DateTime.Now;
        private bool isTruckModified = false;
        private frm_WM_ROSetLocations location = null;
        private frm_WM_PalletInfo palletInfo = null;
        private frm_WM_ReceivingProductNew frmAddNewProducts = null;
        private int rowIndexFocused = 0;
        private IDictionary<Control, bool> validateList = new Dictionary<Control, bool>();
        private bool isLockOrder = false;
        private urc_WM_Notes viewNotes = null;
        private urc_WM_EmployeeInfo viewEmployee = null;
        private urc_WM_Vehicle viewVehicle = null;
        private urc_WM_OtherService viewService = null;
        private IList<string> listRoDetailIsWeighting = new List<string>();
        private ST_WMS_LoadOtherServices_Result _currentService;
        private OtherServiceDetails otherServiceDetails;
        private Timer timerNetWork = new Timer();
        private bool sleeptime = false;

        protected frm_WM_ReceivingOrders()
        {
            // Validate function permission of user
            if (!this.ValidateActiveForm())
            {
                this.Enabled = false;
            }

            // Init designer
            InitializeComponent();

            this.timerNetWork.Interval = 500;
            this.timerNetWork.Tick += TimerNetWork_Tick;
            this.timerNetWork.Start();

            this._roDA = new ReceivingOrdersDA();

            this.LoadHoldList();
            this.LoadTimeSlots();
            this.InitWorkType();

            // Init data 
            System.Threading.Tasks.Task.Run(() =>
            {
                this.InitLookup();
                this.LoadData();
            });
            this.dataNavigatorReceivingOrders.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            this.SetEvents();
            this._currentService = new ST_WMS_LoadOtherServices_Result();
            this.otherServiceDetails = new OtherServiceDetails();
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
        /// Get instance of receiving order form
        /// </summary>
        public static frm_WM_ReceivingOrders Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new frm_WM_ReceivingOrders();
                }
                return instance;
            }
        }

        /// <summary>
        /// Get or set Receiving Order ID to display or lookup
        /// </summary>
        public int ReceivingOrderIDFind
        {
            get { return receivingOrderFind; }
            set
            {
                receivingOrderFind = value;
                if (this.Visible)
                {
                    this.frm_WM_ReceivingOrders_VisibleChanged(null, null);
                }
                else
                {
                    this.Visible = true;
                }
                if (!this.isFirstLoad)
                {
                    this.OrderNumberChanged();
                }

                if (this.Visible && this.receivingOrderFind < 0 && !isFirstLoad)
                {
                    this.btnNew_Click(null, null);
                }
            }
        }
        private void frmReceivingOrders_Load(object sender, EventArgs e)
        {
            try
            {
                this.isFirstLoad = false;
                this.Text = textEditOrderID.Text.Trim() + " " + lookUpEditCustomerID.Text.Trim();
                DataProcess<Employees> dataProcess = new DataProcess<Employees>();
                fullInfoEmployees = dataProcess.Select(em => em.EmployeeID == AppSetting.CurrentUser.EmployeeID).FirstOrDefault();

                while (listReceivingOrders == null)
                {
                    log.Info("==> Waiting to load Receiving Order data...");
                    Application.DoEvents();
                }
                if (listReceivingOrders != null && listReceivingOrders.Count <= 0)
                {
                    dataNavigatorReceivingOrders.Position = listReceivingOrders.Count;
                    this.btn_WM_NewAllProduct.Enabled = false;
                    textEditOrderID.Text = "RO-New *";
                    textEditOrderID.Tag = 0;
                    memoEditTruckAndDetail.Text = "";
                    timeEditStartTime.Tag = timeEditStartTime.EditValue = null; // DateTime.Now;
                    timeEditEndTime.Tag = timeEditEndTime.EditValue = null; // DateTime.Now;
                    spinEditTemperature.Tag = spinEditTemperature.EditValue = null;
                    textEditSealNumber.Tag = textEditSealNumber.Text = "";
                    this.textEditReceivingOrderProgress.EditValue = null;
                    this.lkeDockNumber.EditValue = null;
                    this.textEditVehicleNumber.Text = string.Empty;
                    this.textEditCustomerOrderNumber.Text = string.Empty;
                    this.textEditCustomerOrderNumber2.Text = string.Empty;
                    this.txtPutAwayPercent.Text = string.Empty;
                    this.txtProcessStatus.Text = string.Empty;
                    this.txtEDIMessageSentTime.Text = string.Empty;
                    textEditInernalRemark.Tag = textEditInernalRemark.Text = "";
                    lookUpEditCustomerID.Tag = lookUpEditCustomerID.EditValue = null;
                    lke_WM_Supplier.Tag = lke_WM_Supplier.EditValue = null;
                    this.lke_TimeSlotID.Tag = lke_TimeSlotID.EditValue = null;
                    lookUpEditCustomerID.ReadOnly = false;
                    lookUpEditCustomerID.Focus();
                    lookUpEditCustomerID.ShowPopup();
                    listOrderDetail.Clear();
                }
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                MessageBox.Show(ex.Message, "Error is unexpected");
            }
        }

        /// <summary>
        /// Validate function permission of current user
        /// </summary>
        private bool ValidateActiveForm()
        {
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
                    return true;
                }
            }
            //return false;
            return true;
        }

        /// <summary>
        /// Set permission control
        /// </summary>
        private void SetPermissionControl(string functionName)
        {
            var actionsList = FileProcess.LoadTable("STGetGrantActionOnFunctionByUser @LoginName='" + AppSetting.CurrentUser.LoginName + "',@FormName='"+ functionName + "'");
            foreach (Control item in frm_WM_ReceivingOrders.Instance.ReivingOrderRibon.Items)
            {
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

        private void LoadData()
        {
            try
            {
                Wait.Start(this);
                //Load receiving order detail by orderID
                // Reload to data
                List<ReceivingOrders> lst = null;
                bool isAddNewRecord = false;
                if (this.listReceivingOrders != null)
                {
                    listReceivingOrders.Clear();
                }


                // If ReceivingOrder ID has data then get Receiving order Detail by it
                if (ReceivingOrderIDFind > -1)
                {
                    // Load receiving order detail by id selected
                    lst = receivingDa.Executing(" select ReceivingOrders.* from ReceivingOrders inner join Customers on Customers.CustomerID=ReceivingOrders.CustomerID " +
                        "where ReceivingOrderID=" + ReceivingOrderIDFind + " and Customers.StoreID=" + AppSetting.StoreID + " order by ReceivingOrderID").ToList();
                }
                else
                {
                    // Load receiving order detail of 2 date previous
                    lst = receivingDa.Executing(" select ReceivingOrders.* from ReceivingOrders inner join Customers on Customers.CustomerID=ReceivingOrders.CustomerID " +
                        "where ReceivingOrderDate>=GETDATE()-2 and Customers.StoreID=" + AppSetting.StoreID + " order by ReceivingOrderID").ToList();
                }

                if (lst.Count == 1)
                {
                    lst.Add(lst[0]);
                    isAddNewRecord = true;
                }

                this.listReceivingOrders = new BindingList<ReceivingOrders>(lst);



                if (!this._isReload)
                {
                    // Set binding control
                    Common.Process.RefreshData.Refresh(this.dataNavigatorReceivingOrders, () =>
                    {
                        this.dataNavigatorReceivingOrders.DataSource = this.listReceivingOrders;
                        textEditOrderID.DataBindings.Add("EditValue", dataNavigatorReceivingOrders.DataSource, "ReceivingOrderNumber", true, DataSourceUpdateMode.Never, "");
                        textEditOrderID.DataBindings.Add("Tag", dataNavigatorReceivingOrders.DataSource, "ReceivingOrderID", true, DataSourceUpdateMode.Never, 0);
                        lookUpEditCustomerID.DataBindings.Add("Tag", dataNavigatorReceivingOrders.DataSource, "CustomerID", true, DataSourceUpdateMode.Never, 0);
                        dateEditReceivingOrderDate.DataBindings.Add("Tag", dataNavigatorReceivingOrders.DataSource, "ReceivingOrderDate", true, DataSourceUpdateMode.Never, DateTime.Now.Date);
                        spinEditTemperature.DataBindings.Add("Tag", dataNavigatorReceivingOrders.DataSource, "Temperature", true, DataSourceUpdateMode.Never);
                        textEditReceivingCreatedTime.DataBindings.Add("Tag", dataNavigatorReceivingOrders.DataSource, "ReceivingCreatedTime", true, DataSourceUpdateMode.Never, DateTime.Now, "dd/MM/yyyy HH:mm:ss");
                        textEditReceivingCreatedBy.DataBindings.Add("Tag", dataNavigatorReceivingOrders.DataSource, "Owner", true, DataSourceUpdateMode.Never, "");
                        textEditSealNumber.DataBindings.Add("Tag", dataNavigatorReceivingOrders.DataSource, "SealNumber", true, DataSourceUpdateMode.Never, "");
                        this.textEditReceivingOrderProgress.DataBindings.Add("EditValue", dataNavigatorReceivingOrders.DataSource, "ReceivingOrderProgress", true, DataSourceUpdateMode.Never, null);
                        textEditInernalRemark.DataBindings.Add("Tag", dataNavigatorReceivingOrders.DataSource, "InternalRemark", true, DataSourceUpdateMode.Never, "");
                        timeEditStartTime.DataBindings.Add("Tag", dataNavigatorReceivingOrders.DataSource, "StartTime", true, DataSourceUpdateMode.Never, null);
                        timeEditEndTime.DataBindings.Add("Tag", dataNavigatorReceivingOrders.DataSource, "EndTime", true, DataSourceUpdateMode.Never, null);
                        lookUpEditHandlingOvertimeCategoryID.DataBindings.Add("Tag", dataNavigatorReceivingOrders.DataSource, "HandlingOvertimeCategoryID", true, DataSourceUpdateMode.Never, 0);
                        lke_WM_Supplier.DataBindings.Add("Tag", dataNavigatorReceivingOrders.DataSource, "CustomerSupplierID", true, DataSourceUpdateMode.Never, null);
                        lke_TimeSlotID.DataBindings.Add("Tag", dataNavigatorReceivingOrders.DataSource, "TimeSlotID", true, DataSourceUpdateMode.Never, null);
                        memoEditTruckAndDetail.DataBindings.Add("Tag", dataNavigatorReceivingOrders.DataSource, "SpecialRequirement", true, DataSourceUpdateMode.Never, "");
                        textEditVehicleNumber.DataBindings.Add("Tag", dataNavigatorReceivingOrders.DataSource, "VehicleNumber", true, DataSourceUpdateMode.Never, "");
                        textEditCustomerOrderNumber.DataBindings.Add("Tag", dataNavigatorReceivingOrders.DataSource, "CustomerOrderNumber", true, DataSourceUpdateMode.Never, "");
                        textEditCustomerOrderNumber2.DataBindings.Add("Tag", dataNavigatorReceivingOrders.DataSource, "CustomerOrderNumber2", true, DataSourceUpdateMode.Never, "");
                        txtPutAwayPercent.DataBindings.Add("Tag", dataNavigatorReceivingOrders.DataSource, "PutAwayPercentage", true, DataSourceUpdateMode.Never, 0);
                        txtProcessStatus.DataBindings.Add("Tag", dataNavigatorReceivingOrders.DataSource, "ProcessingStatus", true, DataSourceUpdateMode.Never, 0);
                        txtEDIMessageSentTime.DataBindings.Add("Tag", dataNavigatorReceivingOrders.DataSource, "EDIMessageSentTime", true, DataSourceUpdateMode.Never, "");
                        this.dataNavigatorReceivingOrders.Position = listReceivingOrders.Count;

                        // remove duplicate data 
                        if (isAddNewRecord)
                        {
                            this.listReceivingOrders.RemoveAt(1);
                        }
                    });
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

        public void LoadDataDetail(int receivingOrderID)
        {
            try
            {
                listOrderDetail.Clear();
                gridControlOrderDetail.DataSource = null;
                IEnumerable<ReceivingOrderDetails> lst = recevingOrderDetailDA.Select(a => a.ReceivingOrderID == receivingOrderID);
                foreach (ReceivingOrderDetails x in lst)
                {
                    listOrderDetail.Add(x);
                }
                if (lst.Count() <= 0)
                {
                    listOrderDetail = new BindingList<ReceivingOrderDetails>();
                }

                gridControlOrderDetail.DataSource = listOrderDetail.OrderBy(order => order.ReceivingOrderDetailID);
                lookUpEditCustomerID.ReadOnly = (listOrderDetail.Count > 0);
                this.gridViewOrderDetail.FocusedRowHandle = this.rowIndexFocused;
                this.listRoDetailIsWeighting = new List<string>();
                foreach (ReceivingOrderDetails obj in listOrderDetail)
                {
                    if (obj.IsWeighting == true)
                    {
                        if (!this.listRoDetailIsWeighting.Contains(obj.ReceivingOrderDetailID.ToString()))
                        {
                            this.listRoDetailIsWeighting.Add(obj.ReceivingOrderDetailID.ToString());
                        }
                    }
                    else
                    {
                        if (this.listRoDetailIsWeighting.Contains(obj.ReceivingOrderDetailID.ToString()))
                        {
                            this.listRoDetailIsWeighting.Remove(obj.ReceivingOrderDetailID.ToString());
                        }
                    }
                }
                string roDetailIDs = string.Join(",", this.listRoDetailIsWeighting.ToArray());
                LoadDataIsWeighting(roDetailIDs);
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                MessageBox.Show(ex.Message, "Error is unexpected");
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
        private void InitLookup()
        {
            try
            {
                Wait.Start(this);
                Common.Process.RefreshData.Refresh(this.lookUpEditCustomerID, () =>
                {
                    lookUpEditCustomerID.Properties.DataSource = AppSetting.CustomerList.Where(a => a.CustomerDiscontinued == false);
                    lookUpEditCustomerID.Properties.ValueMember = "CustomerID";
                    lookUpEditCustomerID.Properties.DisplayMember = "CustomerNumber";
                    this.listCustomer = (IEnumerable<Customers>)lookUpEditCustomerID.Properties.DataSource;
                });
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

        private void LoadDockDoor(string orderNumber)
        {
            DataProcess<STcomboDockDoorID_Result> dockDoorDA = new DataProcess<STcomboDockDoorID_Result>();
            this.lkeDockNumber.Properties.DataSource = dockDoorDA.Executing(" STcomboDockDoorID @OrderNumber={0}", orderNumber);
            this.lkeDockNumber.Properties.ValueMember = "DockDoorID";
            this.lkeDockNumber.Properties.DisplayMember = "DockNumber";
        }

        private void InitLookupServices(int customerID)
        {
            DataProcess<STVSServicesDefinitionListForLookup_Result> serviceDifinitionDa = new DataProcess<STVSServicesDefinitionListForLookup_Result>();
            List<STVSServicesDefinitionListForLookup_Result> list = (List<STVSServicesDefinitionListForLookup_Result>)serviceDifinitionDa.Executing("STVSServicesDefinitionListForLookup @CustomerID={0},@OrderDate={1}", customerID, dateEditReceivingOrderDate.DateTime);
            var listFilter = list.Where(s => !s.ServiceNumber.Contains("HDO")).ToList();
            lookUpEditHandlingOvertimeCategoryID.Properties.DataSource = listFilter;
        }

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void lookUpEditCustomerID_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.lookUpEditCustomerID.Text)) return;
            this.memoEditTruckAndDetail.Focus();
            //dateEditReceivingOrderDate.Focus();
        }

        private void iCloseReceivingOrder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (var controlValidate in this.validateList)
            {
                if (controlValidate.Value)
                {
                    controlValidate.Key.Focus();
                    return;
                }
            }
            this.Hide();
        }

        private void dataNavigatorReceivingOrders_PositionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataNavigatorReceivingOrders.Position > -1)
                {
                    isLockOrder = false;
                    isUpdate = false;
                    if (textEditOrderID.Tag != null)
                    {
                        isLockOrder = this.listReceivingOrders[this.dataNavigatorReceivingOrders.Position].Status;
                        int timeSlotID = Convert.ToInt32(this.listReceivingOrders[this.dataNavigatorReceivingOrders.Position].TimeSlotID);

                        // Check the controls is allow active
                        this.CheckLockControls();

                        int customerID = Convert.ToInt32(lookUpEditCustomerID.Tag);
                        lookUpEditCustomerID.EditValue = customerID;
                        this.lkeWorkType.EditValue = this.listReceivingOrders[this.dataNavigatorReceivingOrders.Position].WorkTypeCode;
                        dateEditReceivingOrderDate.EditValue = Convert.ToDateTime(dateEditReceivingOrderDate.Tag);
                        this.orderTraceDate = this.dateEditReceivingOrderDate.DateTime;
                        string customerName = lookUpEditCustomerID.Properties.GetDataSourceValue("CustomerName", lookUpEditCustomerID.ItemIndex).ToString();
                        string customerSupplierID = Convert.ToString(this.listReceivingOrders[this.dataNavigatorReceivingOrders.Position].CustomerSupplierID);
                        textEditCustomerName.Text = customerName;
                        InitLookupServices(customerID);
                        int customerMainID = 0;
                        var cusSelected = AppSetting.CustomerList.Where(c => c.CustomerID == customerID).FirstOrDefault();
                        if (cusSelected != null)
                            customerMainID = cusSelected.CustomerMainID;
                        this.LoadCustomerSupplierData(customerMainID, customerSupplierID);
                        if (!string.IsNullOrEmpty(Convert.ToString(spinEditTemperature.Tag)))
                        {
                            spinEditTemperature.EditValue = Convert.ToSingle(spinEditTemperature.Tag);
                        }
                        else
                        {
                            spinEditTemperature.EditValue = null;
                        }

                        if (!string.IsNullOrEmpty(textEditReceivingCreatedTime.Tag.ToString()))
                        {
                            textEditReceivingCreatedTime.Text = Convert.ToDateTime(textEditReceivingCreatedTime.Tag).ToString("dd/MM/yyyy HH:mm");
                        }

                        textEditReceivingCreatedBy.Text = Convert.ToString(textEditReceivingCreatedBy.Tag);


                        textEditSealNumber.Text = Convert.ToString(textEditSealNumber.Tag);
                        this.textEditVehicleNumber.Text = Convert.ToString(this.textEditVehicleNumber.Tag);
                        this.textEditCustomerOrderNumber.Text = Convert.ToString(this.textEditCustomerOrderNumber.Tag);
                        this.textEditCustomerOrderNumber2.Text = Convert.ToString(this.textEditCustomerOrderNumber2.Tag);
                        this.txtPutAwayPercent.Text = Convert.ToString(this.txtPutAwayPercent.Tag);
                        this.txtProcessStatus.Text = Convert.ToString(this.txtProcessStatus.Tag);
                        txtEDIMessageSentTime.Text = Convert.ToString(this.txtEDIMessageSentTime.Tag);
                        textEditInernalRemark.Text = Convert.ToString(textEditInernalRemark.Tag);
                        if (!string.IsNullOrEmpty(memoEditTruckAndDetail.Tag.ToString()))
                        {
                            memoEditTruckAndDetail.Text = Convert.ToString(memoEditTruckAndDetail.Tag);
                        }
                        else
                        {
                            memoEditTruckAndDetail.Text = string.Empty;
                        }

                        if (timeEditStartTime.Tag == null || timeEditStartTime.Tag.ToString().Trim() == "")
                            timeEditStartTime.EditValue = null;
                        else
                            timeEditStartTime.EditValue = Convert.ToDateTime(timeEditStartTime.Tag);

                        if (timeEditEndTime.Tag == null || timeEditEndTime.Tag.ToString().Trim() == "")
                            timeEditEndTime.EditValue = null;
                        else
                            timeEditEndTime.EditValue = Convert.ToDateTime(timeEditEndTime.Tag);
                        lookUpEditHandlingOvertimeCategoryID.EditValue = Convert.ToInt32(lookUpEditHandlingOvertimeCategoryID.Tag);
                        this.lke_TimeSlotID.EditValue = timeSlotID;

                        this.OrderNumberChanged();

                        // Load DookDoor
                        this.LoadDockDoor(this.textEditOrderID.Text.Trim());
                        this.lkeDockNumber.EditValue = this.listReceivingOrders[this.dataNavigatorReceivingOrders.Position].DockDoorID;

                        // Load detail data
                        LoadDataDetail(Convert.ToInt32(textEditOrderID.Tag));

                        // Detect data type will load on UI
                        this.ReLoadSubData();
                    }

                    isUpdate = true;
                }
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                Wait.Close();
            }
            Wait.Close();
        }
        private void lookUpEditHandlingOvertimeCategoryID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (lookUpEditHandlingOvertimeCategoryID.ItemIndex < 0)
                {
                    this.textEditServiceName.Text = string.Empty;
                    return;
                }
                string serviceName = lookUpEditHandlingOvertimeCategoryID.Properties.GetDataSourceValue("ServiceName", lookUpEditHandlingOvertimeCategoryID.ItemIndex).ToString();
                textEditServiceName.Text = serviceName;
                if (isUpdate)
                {// Send email notify when user change service to Internal Movement Free
                    if (this.lookUpEditHandlingOvertimeCategoryID.EditValue != null && Convert.ToInt32(this.lookUpEditHandlingOvertimeCategoryID.EditValue) == 346)
                    {
                        var msgConfirm=MessageBox.Show("Chọn dịch vụ không tính phí sẽ được gửi thông tin đến giám sát, bạn có muốn chọn dịch vụ này ?", "TWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (msgConfirm.Equals(DialogResult.No))
                        {
                            this.lookUpEditHandlingOvertimeCategoryID.EditValue = null;
                            this.textEditServiceName.Text = string.Empty;
                            return;
                        }
                        // Send email
                        System.Text.StringBuilder txtBody = new StringBuilder();
                        txtBody.Append("Phiếu Nhập: ");
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
                        string body =this.textEditCustomerOrderNumber.Text  +" ";
                        IList<string> attach = new List<string>();
                        Common.Process.DataTransfer.SendMail("thetrung@necs.vn;", "TWMS Thay đổi dịch vụ không tính phí", txtBody.ToString(), attach.ToArray());
                        UpdateRO();
                    }
                    else
                    {
                        UpdateRO();
                    }
                }

                
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                Wait.Close();
                textEditServiceName.Text = "";
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            this.lookUpEditCustomerID.EditValue = null;
            this.btn_WM_NewAllProduct.Enabled = false;
            dataNavigatorReceivingOrders.Position = listReceivingOrders.Count;
            textEditOrderID.Text = "RO-New *";
            textEditOrderID.Tag = 0;
            memoEditTruckAndDetail.Text = "";
            textEditCustomerName.Text = string.Empty;
            textEditReceivingCreatedBy.Text = AppSetting.CurrentUser.LoginName;
            dateEditReceivingOrderDate.Tag = dateEditReceivingOrderDate.EditValue = DateTime.Now.Date;
            timeEditStartTime.Tag = timeEditStartTime.EditValue = null; // DateTime.Now;
            timeEditEndTime.Tag = timeEditEndTime.EditValue = null; // DateTime.Now;
            spinEditTemperature.Tag = spinEditTemperature.EditValue = null;
            textEditSealNumber.Tag = textEditSealNumber.Text = "";
            this.textEditReceivingOrderProgress.EditValue = null;
            this.lkeDockNumber.EditValue = null;
            this.textEditVehicleNumber.Tag = this.textEditVehicleNumber.Text = string.Empty;
            this.textEditCustomerOrderNumber.Tag = this.textEditCustomerOrderNumber.Text = string.Empty;
            this.textEditCustomerOrderNumber2.Tag = this.textEditCustomerOrderNumber2.Text = string.Empty;
            this.txtPutAwayPercent.Tag = null;
            this.txtPutAwayPercent.Text = string.Empty;
            this.txtProcessStatus.Tag = null;
            this.txtProcessStatus.Text = string.Empty;
            this.txtEDIMessageSentTime.Tag = null;
            this.txtEDIMessageSentTime.Text = string.Empty;
            textEditInernalRemark.Tag = textEditInernalRemark.Text = "";
            lookUpEditCustomerID.Tag = lookUpEditCustomerID.EditValue = null;
            lookUpEditCustomerID.ReadOnly = false;
            this.lookUpEditHandlingOvertimeCategoryID.EditValue = null;
            this.lke_WM_Supplier.EditValue = null;
            this.lke_TimeSlotID.EditValue = null;
            this.gridControlOrderDetail.DataSource = null;
            listOrderDetail.Clear();
            lookUpEditCustomerID.Focus();
            lookUpEditCustomerID.ShowPopup();
        }

        private int UpdateRO()
        {
            int rOID = 0;
            bool isNew = false;
            ReceivingOrders rO = new ReceivingOrders();
            if (this.lookUpEditCustomerID.EditValue == null) return 0;
            if (textEditOrderID.Tag == null || Convert.ToInt32(textEditOrderID.Tag) == 0)
            {

                isNew = true;
                dateEditReceivingOrderDate.Tag = rO.ReceivingOrderDate = dateEditReceivingOrderDate.DateTime.Date;
                lookUpEditCustomerID.Tag = rO.CustomerID = Convert.ToInt32(lookUpEditCustomerID.EditValue);
                if (rO.CustomerID <= 0)
                {
                    MessageBox.Show("Lỗi rồi ['CustomerID<=0'], dừng lại và gọi ngay IT xem trường hợp này", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }
                rO.Status = false;
                if (timeEditStartTime.EditValue != null)
                    rO.StartTime = timeEditStartTime.DateTime;
                else
                    rO.StartTime = null;
                if (timeEditEndTime.EditValue != null)
                    rO.EndTime = timeEditEndTime.DateTime;
                else
                    rO.EndTime = null;
                rO.SpecialRequirement = memoEditTruckAndDetail.Text.Trim();
                if (spinEditTemperature.EditValue != null)
                {
                    spinEditTemperature.Tag = rO.Temperature = Convert.ToSingle(spinEditTemperature.EditValue);
                }

                if (this.textEditReceivingOrderProgress.EditValue != null) rO.ReceivingOrderProgress = Convert.ToByte(this.textEditReceivingOrderProgress.EditValue);
                rO.SealNumber = textEditSealNumber.Text.Trim();
                if (this.lkeDockNumber.EditValue != null) rO.DockDoorID = Convert.ToInt32(this.lkeDockNumber.EditValue);
                rO.VehicleNumber = this.textEditVehicleNumber.Text;
                rO.CustomerOrderNumber = this.textEditCustomerOrderNumber.Text;
                rO.CustomerOrderNumber2 = this.textEditCustomerOrderNumber2.Text;
                //rO.PutAwayPercentage = Convert.ToDouble(this.txtPutAwayPercent.EditValue);
                //rO.ProcessingStatus = Convert.ToByte(this.txtProcessStatus.EditValue);
                rO.HandlingOvertimeCategoryID = Convert.ToInt16(lookUpEditHandlingOvertimeCategoryID.EditValue);
                rO.InternalRemark = textEditInernalRemark.Text.Trim();
                rO.ReceivingCreatedTime = DateTime.Now;
                rO.Owner = this.userName;
                rO.CustomerNumber = lookUpEditCustomerID.Text.Trim();
                if (this.lke_TimeSlotID.EditValue != null) rO.TimeSlotID = Convert.ToInt32(this.lke_TimeSlotID.EditValue);
                if (this.lke_WM_Supplier.EditValue != null)
                {
                    rO.CustomerSupplierID = Convert.ToInt32(this.lke_WM_Supplier.EditValue);
                }
                if (this.lkeWorkType.EditValue != null)
                    rO.WorkTypeCode = Convert.ToInt32(this.lkeWorkType.EditValue);

                this.receivingDa.Insert(rO);
                textEditOrderID.Text = rO.ReceivingOrderNumber = "RO-" + rO.ReceivingOrderID;
                rOID = rO.ReceivingOrderID;
                listReceivingOrders.Insert(listReceivingOrders.Count, rO);
            }
            else
            {
                rOID = Convert.ToInt32(textEditOrderID.Tag);
                rO = this.receivingDa.Select(r => r.ReceivingOrderID == rOID).FirstOrDefault();

                // If this order is lock then return
                if (rO != null && rO.Status) return -1;
                rO.ReceivingOrderID = rOID;
                rO.ReceivingOrderNumber = "RO-" + rO.ReceivingOrderID;
                rO.ReceivingOrderDate = dateEditReceivingOrderDate.DateTime.Date;
                lookUpEditCustomerID.Tag = rO.CustomerID = Convert.ToInt32(lookUpEditCustomerID.EditValue);
                if (rO.CustomerID <= 0)
                {
                    MessageBox.Show("Lỗi rồi ['CustomerID<=0'], dừng lại và gọi ngay IT xem trường hợp này", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }
                rO.Status = false;
                if (timeEditStartTime.EditValue != null)
                    rO.StartTime = timeEditStartTime.DateTime;
                else
                    rO.StartTime = null;
                if (timeEditEndTime.EditValue != null)
                    rO.EndTime = timeEditEndTime.DateTime;
                else
                    rO.EndTime = null;
                rO.SpecialRequirement = memoEditTruckAndDetail.Text.Trim();
                if (spinEditTemperature.EditValue != null)
                {
                    rO.Temperature = Convert.ToSingle(spinEditTemperature.EditValue);
                }
                if (this.textEditReceivingOrderProgress.EditValue != null) rO.ReceivingOrderProgress = Convert.ToByte(this.textEditReceivingOrderProgress.EditValue);
                rO.SealNumber = textEditSealNumber.Text.Trim();
                rO.VehicleNumber = this.textEditVehicleNumber.Text;
                rO.CustomerOrderNumber = this.textEditCustomerOrderNumber.Text;
                rO.CustomerOrderNumber2 = this.textEditCustomerOrderNumber2.Text;
                //rO.PutAwayPercentage = Convert.ToDouble(this.txtPutAwayPercent.EditValue);
                //rO.ProcessingStatus = Convert.ToByte(this.txtProcessStatus.EditValue);
                if (this.lkeDockNumber.EditValue != null) rO.DockDoorID = Convert.ToInt32(this.lkeDockNumber.EditValue);
                rO.HandlingOvertimeCategoryID = Convert.ToInt16(lookUpEditHandlingOvertimeCategoryID.EditValue);
                rO.InternalRemark = textEditInernalRemark.Text.Trim();
                rO.CustomerNumber = lookUpEditCustomerID.Text.Trim();
                if (this.lke_TimeSlotID.EditValue != null) rO.TimeSlotID = Convert.ToInt32(this.lke_TimeSlotID.EditValue);
                if (this.lke_WM_Supplier.EditValue != null)
                {
                    rO.CustomerSupplierID = Convert.ToInt32(this.lke_WM_Supplier.EditValue);
                }
                if (this.lkeWorkType.EditValue != null)
                    rO.WorkTypeCode = Convert.ToInt32(this.lkeWorkType.EditValue);
                this.receivingDa.Update(rO);
                textEditOrderID.Text = rO.ReceivingOrderNumber = "RO-" + rO.ReceivingOrderID;
                listReceivingOrders[dataNavigatorReceivingOrders.Position] = rO;
            }
            if (isNew)
                dataNavigatorReceivingOrders.Position = listReceivingOrders.Count;
            return rOID;
        }
        private void gridViewOrderDetail_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {
                ////Wait.Start(this);
                int rOID = UpdateRO();
                if (rOID > 0)
                {
                    ReceivingOrderDetails rODetail;
                    rODetail = e.Row as ReceivingOrderDetails;
                    if (rODetail.ReceivingOrderDetailID == 0)
                    {
                        rODetail.CreatedBy = this.userName;
                        rODetail.CreatedTime = DateTime.Now;
                        rODetail.ReceivingOrderID = rOID;
                        rODetail.ReceivingOrderNumber = textEditOrderID.Text;
                        rODetail.Status = 0;

                        this.recevingOrderDetailDA.Insert(rODetail);
                    }
                    else
                    {
                        using (var context = new SwireDBEntities())
                        {
                            context.ReceivingOrderDetails.Attach(rODetail);
                            context.Entry(rODetail).State = System.Data.Entity.EntityState.Modified;
                        }
                        this.recevingOrderDetailDA.Update(rODetail);
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

        private void iPalletInfo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PalletInfo();
        }

        private void PalletInfo()
        {
            try
            {
                ReceivingOrderDetails rODetail = (ReceivingOrderDetails)gridViewOrderDetail.GetFocusedRow();
                if (rODetail == null) return;

                int customerID = Convert.ToInt32(lookUpEditCustomerID.EditValue);
                int productID = Convert.ToInt32(gridViewOrderDetail.GetRowCellValue(gridViewOrderDetail.FocusedRowHandle, "ProductID"));
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

        private void textEditOrderID_EditValueChanged(object sender, EventArgs e)
        {
            this.Text = textEditOrderID.Text.Trim() + " " + lookUpEditCustomerID.Text.Trim();
        }

        private void iChangeRoom_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                int _customerID = Convert.ToInt32(lookUpEditCustomerID.EditValue);
                Customers _c = listCustomer.FirstOrDefault(c => c.CustomerID == _customerID);
                if (_c != null)
                {
                    if (_c.HomeLocationChange == false)
                    {
                        XtraMessageBox.Show("You can not change room for this customer!", "Can not change room, HomeLocationChange = false", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        frm_WM_ChangeRoom frm = new frm_WM_ChangeRoom(_customerID);
                        if (!frm.Enabled) return;
                        frm.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
            }
        }

        private void iSetLocation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SetLocation();
        }

        private void SetLocation()
        {
            try
            {
                ReceivingOrderDetails rODetail = (ReceivingOrderDetails)gridViewOrderDetail.GetFocusedRow();
                if (rODetail == null) return;

                var currentRO = this.receivingDa.Select(r => r.ReceivingOrderID == rODetail.ReceivingOrderID).FirstOrDefault();
                if (currentRO != null && currentRO.Status)
                {
                    MessageBox.Show("This RO has locked, could not view RO detail", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Just working when roDetail has data
                //Customers currentCustomers = this.listCustomer.Where(c => c.CustomerID == Convert.ToInt32(this.lookUpEditCustomerID.EditValue)).FirstOrDefault();
                Customers currentCustomers = this.listCustomer.Where(c => c.CustomerID == Convert.ToInt32(currentRO.CustomerID)).FirstOrDefault();

                bool isRandomWeight = false;
                if (currentCustomers.CustomerType.Equals(CustomerTypeEnum.RANDOM_WEIGHT))
                {
                    isRandomWeight = true;
                }
                if (this.location == null)
                {
                    this.location = new frm_WM_ROSetLocations(rODetail, textEditOrderID.Text.Trim(), lookUpEditCustomerID.Text.Trim(), isRandomWeight, Convert.ToInt32(this.gridViewOrderDetail.GetFocusedRowCellValue("Status")));
                }
                else
                {
                    this.location.InitData(rODetail, textEditOrderID.Text.Trim(), lookUpEditCustomerID.Text.Trim(), isRandomWeight, Convert.ToInt32(this.gridViewOrderDetail.GetFocusedRowCellValue("Status")));
                }

                if (!this.location.Enabled) return;
                this.location.ShowDialog();
                // Rodetail confrimed 
                if (rODetail.Status > 1) return;
                DataProcess<STVSPalletSUMByReceivingOrderDetailID_Result> sumByReceivingOrderDA = new DataProcess<STVSPalletSUMByReceivingOrderDetailID_Result>();
                STVSPalletSUMByReceivingOrderDetailID_Result rs = sumByReceivingOrderDA.Executing("STVSPalletSUMByReceivingOrderDetailID @ReceivingOrderDetailID={0} ", rODetail.ReceivingOrderDetailID).FirstOrDefault();
                var roDetailsUpdate = this.recevingOrderDetailDA.Select(x => x.ReceivingOrderDetailID == rODetail.ReceivingOrderDetailID).FirstOrDefault();
                roDetailsUpdate.TotalPackages = (short)rs.OriginalQuantity;
                roDetailsUpdate.TotalWeight = (decimal)rs.PalletWeight;
                roDetailsUpdate.TotalUnits = rs.UnitQuantity;
                this.recevingOrderDetailDA.Update(roDetailsUpdate);
                this.LoadDataDetail(rODetail.ReceivingOrderID);
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                        TransactionDAC trans = new TransactionDAC();
                        switch (ans)
                        {
                            case DialogResult.Yes:
                                trans.STTransactionInsertAll(Convert.ToInt32(textEditOrderID.Tag), textEditOrderID.Text.Trim(), this.userName, lookUpEditCustomerID.Text.Trim());
                                gridControlOrderDetail.DataSource = listOrderDetail;

                                break;
                            case DialogResult.No:
                                trans.STTransactionDeleteAll(Convert.ToInt32(textEditOrderID.Tag), true, this.userName);
                                gridControlOrderDetail.DataSource = listOrderDetail;

                                break;
                        }
                        LoadDataDetail(Convert.ToInt32(textEditOrderID.Tag));
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
            }
        }

        private void memoEditTruckAndDetail_EditValueChanged(object sender, EventArgs e)
        {
            this.isTruckModified = true;
            if (memoEditTruckAndDetail.Text.Trim() == "")
            {
                gridControlOrderDetail.Enabled = false;
            }
            else
            {
                gridControlOrderDetail.Enabled = true;
            }

            if (this.memoEditTruckAndDetail.Text.Length > 0)
            {
                this.btn_WM_NewAllProduct.Enabled = true;
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
                if (isUpdate)
                {
                    UpdateRO();
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

                if (isUpdate)
                {
                    UpdateRO();
                }
            }
        }

        private void barButtonItem73_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ViewAdviceReport(false);
        }

        private void ViewAdviceReport(bool isPreview)
        {
            try
            {
                string customerType = lookUpEditCustomerID.GetColumnValue("CustomerType").ToString();
                if (customerType == "Pcs")
                {
                    printReceivingAdvice_Pcs(isPreview);
                }
                else
                {
                    printReceivingAdvice(isPreview);
                }
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
            }
        }

        private void iConfirm_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DateTime timeIn = DateTime.Now;

                // Validate confirm soon
                if (DateTime.Now > timeIn.AddMinutes(30))
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

                // Check input employee for this order before confirmed
                if (!CheckInputEmployee(this.textEditOrderID.Text))
                {
                    var confirmMsg = MessageBox.Show("This order not yet enter employee, please re-check it!", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (confirmMsg.Equals(DialogResult.Yes))
                    {
                        this.dockPanelEmployees.Show();
                        return;
                    }
                }
                // Check send data before confirm
                int receivingOrderID = Convert.ToInt32(this.textEditOrderID.Tag);
                int totalPalletNotSend = Convert.ToInt32(FileProcess.LoadTable("STCheckDataHadSendBeforConfirm @ROID=" + receivingOrderID).Rows[0]["totalPalletNotSend"]);
                if (totalPalletNotSend > 0)
                {
                    var msgConfirm = MessageBox.Show("There are some pallets not yet post to Warenavi!\nYou need to post them before confirm this RO?", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool hasQtyInvalid = false;
                foreach (var item in this.listOrderDetail)
                {
                    // Check Qty sync with wareNavi is equal with qty RODetail send
                    int qtyDiff = Convert.ToInt32(FileProcess.LoadTable("STCheckQTYSyncBeforeConfirm @RODetailID=" + item.ReceivingOrderID).Rows[0]["DifferenceQty"]);
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

                if (lookUpEditCustomerID.EditValue == null)
                {
                    lookUpEditCustomerID.Focus();
                    lookUpEditCustomerID.ShowPopup();
                    return;
                }

                if (this.lookUpEditHandlingOvertimeCategoryID.EditValue == null)
                {
                    this.lookUpEditHandlingOvertimeCategoryID.Focus();
                    this.lookUpEditHandlingOvertimeCategoryID.ShowPopup();
                    return;
                }

                DataProcess<Billings> billingDA = new DataProcess<Billings>();
                var listBill = billingDA.Select(b => b.IsDeleted == false && b.CustomerID == (int)this.lookUpEditCustomerID.EditValue);
                if (listBill != null && listBill.Count() > 0)
                {
                    DateTime billMaxDate = listBill.Max(b => b.BillingToDate);
                    DateTime roDate = this.dateEditReceivingOrderDate.DateTime;
                    if (roDate <= billMaxDate)
                    {
                        XtraMessageBox.Show("This customer is billed! Can not confirm, please contact your Manager!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                if (this.gridViewOrderDetail.RowCount > 0)
                {
                    DataProcess<Customers> customerDA = new DataProcess<Customers>();
                    bool isSendNoteMail = (bool)customerDA.Select(c => c.CustomerID == (int)this.lookUpEditCustomerID.EditValue).FirstOrDefault().SendNote;
                    frm_WM_ConfirmationOne frmConfirm = new frm_WM_ConfirmationOne((int)this.textEditOrderID.Tag, this.textEditOrderID.Text, isSendNoteMail, (int)this.lookUpEditCustomerID.EditValue);
                    if (!frmConfirm.Enabled) return;
                    frmConfirm.ShowDialog();
                    this.LoadDataDetail((int)this.textEditOrderID.Tag);
                }
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
            }
        }

        private void lookUpEditCustomerID_QueryCloseUp(object sender, CancelEventArgs e)
        {

        }

        private void CheckLockControls()
        {
            bool isReadOnly = true;
            // Check the controls on form is allow active
            if (!this.isLockOrder)
            {
                isReadOnly = false;

            }

            this.lookUpEditCustomerID.ReadOnly = isReadOnly;
            this.memoEditTruckAndDetail.ReadOnly = isReadOnly;
            this.dateEditReceivingOrderDate.ReadOnly = isReadOnly;
            this.timeEditStartTime.ReadOnly = isReadOnly;
            this.timeEditEndTime.ReadOnly = isReadOnly;
            this.lkeDockNumber.ReadOnly = isReadOnly;
            this.spinEditTemperature.ReadOnly = isReadOnly;
            this.comboBoxEdit1.ReadOnly = isReadOnly;
            this.textEditReceivingOrderProgress.ReadOnly = isReadOnly;
            this.textEditSealNumber.ReadOnly = isReadOnly;
            this.textEditVehicleNumber.ReadOnly = isReadOnly;
            this.textEditCustomerOrderNumber.ReadOnly = isReadOnly;
            this.textEditCustomerOrderNumber2.ReadOnly = isReadOnly;
            this.txtPutAwayPercent.ReadOnly = isReadOnly;
            this.txtProcessStatus.ReadOnly = isReadOnly;
            this.txtEDIMessageSentTime.ReadOnly = isReadOnly;
            this.lookUpEditHandlingOvertimeCategoryID.ReadOnly = isReadOnly;
            this.lke_WM_Supplier.ReadOnly = isReadOnly;
            this.lke_TimeSlotID.ReadOnly = isReadOnly;
            this.textEditInernalRemark.ReadOnly = isReadOnly;

            //this.gridControlOrderDetail.OptionsBehavior.ReadOnly = isReadOnly;
            this.gridColumnProductID.OptionsColumn.ReadOnly = isReadOnly;
            //this.gridColumnProductName.OptionsColumn.ReadOnly = isReadOnly;
            this.gridColumn2.OptionsColumn.ReadOnly = isReadOnly;
            this.gridColumnUW.OptionsColumn.ReadOnly = isReadOnly;
            this.colProDate.OptionsColumn.ReadOnly = isReadOnly;
            this.colExpDate.OptionsColumn.ReadOnly = isReadOnly;
            this.colNumExp.OptionsColumn.ReadOnly = isReadOnly;
            this.gridColumnPallets.OptionsColumn.ReadOnly = isReadOnly;
            this.gridColumnTotalPackages.OptionsColumn.ReadOnly = isReadOnly;
            this.gridColumn5.OptionsColumn.ReadOnly = isReadOnly;
            this.gridColumn6.OptionsColumn.ReadOnly = isReadOnly;
            //this.gridColumnRemark.OptionsColumn.ReadOnly = isReadOnly;
            this.gridColumn11.OptionsColumn.ReadOnly = isReadOnly;
            this.gridColumn13.OptionsColumn.ReadOnly = isReadOnly;
            this.gridColumnStatus.OptionsColumn.ReadOnly = isReadOnly;
            this.gridColumnHold.OptionsColumn.ReadOnly = isReadOnly;
            this.gridColumn1.OptionsColumn.ReadOnly = isReadOnly;

            this.btn_WM_NewAllProduct.Enabled = !isReadOnly;
            this.iSetLocation.Enabled = !isReadOnly;
            this.iAcceptAllLocations.Enabled = !isReadOnly;
            this.iConfirm.Enabled = !isReadOnly;
            this.iChangeRoom.Enabled = !isReadOnly;
        }

        private void frm_WM_ReceivingOrders_VisibleChanged(object sender, EventArgs e)
        {
            if (!this.isFirstLoad && this.Visible)
            {
                this.InitLookup();
                this.InitWorkType();

                // Change location start to center screen
                Instance.StartPosition = FormStartPosition.CenterScreen;

                // Load list receiving order detail
                this.GetDataToLoad();

                // Refresh sub data on dock panel
                this.ReLoadSubData();

                // Set action permission
                //this.SetPermissionControl(this.Name);
            }

            /// When form is close then clear receiving Order ID
            if (!this.Visible)
            {
                receivingOrderFind = -1;
                this.rowIndexFocused = 0;
                this.bEditHold.EditValue = null;
            }

            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
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
            if (this.dockPanelService.Visibility.Equals(DevExpress.XtraBars.Docking.DockVisibility.Visible))
            {
                if (this.listReceivingOrders.Count > 0)
                {
                    this.viewService.RecevingOrderInfo = listReceivingOrders[this.dataNavigatorReceivingOrders.Position];
                }
                this.viewService.InitData(this.textEditOrderID.Text);
            }
        }


        /// <summary>
        /// Load all supplier by customerID selected
        /// </summary>
        /// <param name="customerID"></param>
        private void LoadCustomerSupplierData(int customerID, string customerSupplierID)
        {
            if (customerID < 0) return;
            this.lke_WM_Supplier.EditValue = 0;
            var dataSource = this.customerDA.Select(c => c.CustomerID == customerID).OrderBy(s => s.CustomerSupplierCode).ToList();
            this.lke_WM_Supplier.Properties.DataSource = dataSource;
            this.lke_WM_Supplier.Properties.DisplayMember = "CustomerSupplierName";
            this.lke_WM_Supplier.Properties.ValueMember = "CustomerSupplierID";
            if (!string.IsNullOrEmpty(customerSupplierID))
            {
                this.lke_WM_Supplier.EditValue = Convert.ToInt32(customerSupplierID);
            }
        }

        /// <summary>
        /// Load receiving order detail by current orderID
        /// </summary>
        private void GetDataToLoad()
        {
            try
            {
                // Reload to data
                List<ReceivingOrders> lst = null;
                bool isAddNewRecord = false;
                DateTime fromDate = receivingDa.GetDate().AddDays(-2);
                if (this.listReceivingOrders != null)
                {
                    listReceivingOrders.Clear();
                }

                // If ReceivingOrder ID has data then get Receiving order Detail by it
                if (ReceivingOrderIDFind > -1)
                {
                    // Load receiving order detail by id selected
                    lst = receivingDa.Executing(" select ReceivingOrders.* from ReceivingOrders inner join Customers on Customers.CustomerID=ReceivingOrders.CustomerID " +
                        "where ReceivingOrderID=" + ReceivingOrderIDFind + " and Customers.StoreID=" + AppSetting.StoreID + " order by ReceivingOrderID").ToList();
                }
                else
                {
                    // Load receiving order detail of 2 date previous
                    lst = receivingDa.Executing(" select ReceivingOrders.* from ReceivingOrders inner join Customers on Customers.CustomerID=ReceivingOrders.CustomerID " +
                        "where ReceivingOrderDate>=GETDATE()-2 and Customers.StoreID=" + AppSetting.StoreID + " order by ReceivingOrderID").ToList();
                }

                if (lst.Count == 1)
                {
                    lst.Add(lst[0]);
                    isAddNewRecord = true;
                }

                foreach (ReceivingOrders x in lst)
                {
                    listReceivingOrders.Add(x);
                }

                Common.Process.RefreshData.Refresh(this.dataNavigatorReceivingOrders, () =>
                {
                    dataNavigatorReceivingOrders.DataSource = listReceivingOrders;
                    dataNavigatorReceivingOrders.Position = this.listReceivingOrders.Count;
                });

                if (isAddNewRecord)
                {
                    listReceivingOrders.RemoveAt(1);
                }

                // If not found order current selected then create new order
                if (this.listReceivingOrders.Count == 0)
                {
                    this.btnNew_Click(null, null);
                }
                else
                {
                    btn_WM_NewAllProduct.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
            }

        }

        private void frm_WM_ReceivingOrders_FormClosing(object sender, FormClosingEventArgs e)
        {

            foreach (var controlValidate in this.validateList)
            {
                if (controlValidate.Value)
                {
                    controlValidate.Key.Focus();
                    return;
                }
            }
            this.Hide();
            e.Cancel = true;
        }

        private void btn_WM_NewAllProduct_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.textEditOrderID.Equals("RO-New*") || String.IsNullOrEmpty(this.memoEditTruckAndDetail.Text))
            {
                XtraMessageBox.Show("Please type in Truck and Detail before add new product !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int customerID = Convert.ToInt32(lookUpEditCustomerID.EditValue);
            int receivingOrderID = Convert.ToInt32(this.textEditOrderID.Tag);
            if (this.frmAddNewProducts == null)
            {
                this.frmAddNewProducts = new frm_WM_ReceivingProductNew(customerID, this.memoEditTruckAndDetail.Text, receivingOrderID);
            }
            else
            {
                this.frmAddNewProducts.InitData(customerID, this.memoEditTruckAndDetail.Text, receivingOrderID);
            }

            if (!frmAddNewProducts.Enabled) return;
            frmAddNewProducts.ShowDialog();
            this.LoadDataDetail(receivingOrderID);
            this.LoadDockDoor(this.textEditOrderID.Text);

            // Reset state on this button
            this.spinEditTemperature.Focus();
            this.btn_WM_NewAllProduct.ItemAppearance.Normal.Reset();
        }

        private void rpihpl_ReceivingOrderDetail_DoubleClick(object sender, EventArgs e)
        {
            this.SetLocation();
        }

        private void rpihpl_PalletInfo_DoubleClick(object sender, EventArgs e)
        {
            this.PalletInfo();
        }

        private void rpihl_ProductChange_DoubleClick(object sender, EventArgs e)
        {
            // if (this.isLockOrder) return;

            int customerID = Convert.ToInt32(lookUpEditCustomerID.EditValue);
            int productID = Convert.ToInt32(this.gridViewOrderDetail.GetRowCellValue(this.gridViewOrderDetail.FocusedRowHandle, "ProductID").ToString());
            int receivingOrderDetailID = Convert.ToInt32(this.gridViewOrderDetail.GetRowCellValue(this.gridViewOrderDetail.FocusedRowHandle, "ReceivingOrderDetailID").ToString());

            // Comment this code, always show dialog. frm_MSS_ChangeProduct will handle Validate condition
            //DataProcess<Pallets> palletDA = new DataProcess<Pallets>();
            //double sumAfterDPQuantity = palletDA.Select(p => p.ReceivingOrderDetailID == receivingOrderDetailID).Sum(p => p.AfterDPQuantity);
            //int quantity = Convert.ToInt32(this.gridViewOrderDetail.GetRowCellValue(this.gridViewOrderDetail.FocusedRowHandle, "TotalPackages").ToString());

            //if (sumAfterDPQuantity.Equals(quantity))
            //{
            //frm_MSS_ChangeProduct changeProduct = new frm_MSS_ChangeProduct(customerID, productID, receivingOrderDetailID, this.userName);
            //if (!changeProduct.Enabled) return;
            //changeProduct.ShowDialog();
            //this.LoadDataDetail((int)this.textEditOrderID.Tag);
            //}
            //else
            //{
            //    MessageBox.Show("Product is dispatched, can not change !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            MessageBox.Show("Chức năng này tạm thời bị khoá!", "TWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
            frm_MSS_ChangeProduct changeProduct = new frm_MSS_ChangeProduct(customerID, productID, receivingOrderDetailID, this.userName);
            if (!changeProduct.Enabled) return;
            changeProduct.ShowDialog();
            this.LoadDataDetail((int)this.textEditOrderID.Tag);
        }

        private void rpihpl_ProductInfo_DoubleClick(object sender, EventArgs e)
        {
            int productID = -1;
            Int32.TryParse(this.gridViewOrderDetail.GetRowCellValue(this.gridViewOrderDetail.FocusedRowHandle, "ProductID").ToString(), out productID);
            frm_MSS_Products frmproduct = frm_MSS_Products.Instance;
            frmproduct.ProductIDLookup = productID;
            if (!frmproduct.Enabled) return;
            frmproduct.ShowDialog();
        }

        private void textEditSealNumber_Leave(object sender, EventArgs e)
        {
            if (textEditSealNumber.Text.Length > 40)
            {
                textEditSealNumber.Text = String.Empty;
                XtraMessageBox.Show("Seal must be <= 40 characters !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.textEditSealNumber.Focus();
                return;
            }

            if (isUpdate)
            {
                UpdateRO();
            }
        }

        private void barButtonItem61_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int receivingOrderID = Convert.ToInt32(this.textEditOrderID.Tag);
            int customerID = Convert.ToInt32(lookUpEditCustomerID.Tag);
            string strcustomerID = customerID.ToString();
            if (string.IsNullOrEmpty(strcustomerID))
            {
                lookUpEditCustomerID.Focus();
                return;
            }
            Customers customerSelected = AppSetting.CustomerList.FirstOrDefault(x => x.CustomerID == customerID);
            int customerMainID = (int)customerSelected.CustomerMainID;
            if (customerMainID == 119 || customerMainID == 121 || customerMainID == 538 ||
                customerMainID == 51 || customerMainID == 126 || customerMainID == 139 || customerMainID == 655 || customerMainID == 43 || customerMainID == 2021)
            {
                bool isPrint = true;
                DataProcess<STReceivingAdvice_Result> recevingAdviceDA = new DataProcess<STReceivingAdvice_Result>();
                rptReceivingAdviceDetails_HDE reportBill = new rptReceivingAdviceDetails_HDE();
                reportBill.Parameters["varReceivingOrderID"].Value = receivingOrderID;
                reportBill.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
                reportBill.RequestParameters = false;

                reportBill.DataSource = recevingAdviceDA.Executing("STReceivingAdvice @varReceivingOrderID={0}", receivingOrderID);
                ReportPrintToolWMS printTool = new ReportPrintToolWMS(reportBill);
                printTool.AutoShowParametersPanel = false;
                printTool.ShowPreview();
                if (isPrint)
                {
                    printTool.Print();
                }
            }
            else
            {
                this.PrintAdViceDetailReport();
            }
        }

        /// <summary>
        /// Print Advice report
        /// </summary>
        /// <param name="isPrint"></param>
        private void PrintAdViceDetailReport(bool isPrint = false)
        {
            int receivingIDReport = Convert.ToInt32(textEditOrderID.Tag);
            if (receivingIDReport <= 0) return;

            DataProcess<STReceivingAdvice_Result> recevingAdviceDA = new DataProcess<STReceivingAdvice_Result>();
            rptReceivingAdviceDetails reportBill = new rptReceivingAdviceDetails();
            reportBill.Parameters["varReceivingOrderID"].Value = receivingIDReport;
            reportBill.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
            reportBill.RequestParameters = false;

            reportBill.DataSource = recevingAdviceDA.Executing("STReceivingAdvice @varReceivingOrderID={0}", Convert.ToInt32(textEditOrderID.Tag)); ;
            ReportPrintToolWMS printTool = new ReportPrintToolWMS(reportBill);
            printTool.AutoShowParametersPanel = false;
            printTool.ShowPreview();
            if (isPrint)
            {
                printTool.Print();
            }
        }

        private void barButtonItem63_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataProcess<ST_WMS_ExportROToDO_Result> objt = new DataProcess<ST_WMS_ExportROToDO_Result>();
            CultureInfo provider = CultureInfo.InvariantCulture;
            int receivingID = Convert.ToInt32(textEditOrderID.Tag);
            resultExport = (IList<ST_WMS_ExportROToDO_Result>)objt.Executing("ST_WMS_ExportROToDO @ReceivingOrderID={0}", receivingID);
            int customerID = Convert.ToInt32(lookUpEditCustomerID.EditValue);
            string customerType = lookUpEditCustomerID.GetColumnValue("CustomerType").ToString();
            frm_WM_DispatchingFromRO frm = new frm_WM_DispatchingFromRO(this.resultExport, customerID, dateEditReceivingOrderDate.DateTime, receivingID, memoEditTruckAndDetail.Text.Trim(), lookUpEditCustomerID.Text.Trim(), customerType);
            if (!frm.Enabled) return;
            frm.ShowDialog();
            if (frm.IsShowDispatching)
            {
                var frmDispatching = frm_WM_DispatchingOrders.GetInstance(frm.DispatchingOrderID);
                if (frmDispatching.Visible)
                {
                    frmDispatching.ReloadData();
                }
                frmDispatching.BringToFront();
                frmDispatching.Show();
            }
        }

        #region Tab Notes
        private void SetEvents()
        {
            this.btn_WM_NewAllProduct.ItemClick += btn_WM_NewAllProduct_ItemClick;
            RefreshData.ReloadDataEvent += RefreshData_ReloadDataEvent;
        }

        /// <summary>
        /// Reload order detail when product has modified
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        void RefreshData_ReloadDataEvent(object sender, EventArgs e)
        {
            if (!sender.GetType().Name.Equals("Products")) return;
            int receivingOrderID = Convert.ToInt32(this.textEditOrderID.Tag);
            if (receivingOrderID <= 0) return;
            this.LoadDataDetail(receivingOrderID);
        }

        private void btnPreviewNote_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnPrintNote_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        #endregion

        private void barButtonItem98_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

        #region Tab QAReport
        private void btnPreviewQA_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnDeleteQA_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnConfirmQA_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        #endregion

        private void OrderNumberChanged()
        {
            try
            {
                this.Text = this.textEditOrderID.Text + " " + Convert.ToString(this.lookUpEditCustomerID.GetColumnValue("CustomerNumber"));
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                this.Text = this.textEditOrderID.Text;
            }
        }

        private void gridViewOrderDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                bool isDelete = false;
                int result = -1;
                int[] selectRows = this.gridViewOrderDetail.GetSelectedRows();
                if (selectRows.Count() <= 0) return;

                if (XtraMessageBox.Show("Are you sure to delete products ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                for (int i = 0; i < selectRows.Count(); ++i)
                {
                    if (Convert.ToInt16(this.gridViewOrderDetail.GetRowCellValue(selectRows[i], "Status")) == 0)
                    {
                        int id = Convert.ToInt32(this.gridViewOrderDetail.GetRowCellValue(selectRows[i], "ReceivingOrderDetailID"));
                        result = this._roDA.STReceivingOrderDetailDelete(id, AppSetting.CurrentUser.LoginName);
                        isDelete = true;
                    }
                    else
                    {
                        XtraMessageBox.Show("RO had confirmed!,You couldn't delete it", "TPWMS",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //if user then return
                        //if AppSetting.CurrentUser.LevelOfAuthorization
                        //bool isSupervisor = UserPermission.CheckSupervisorByDepartment(AppSetting.CurrentUser.LoginName, 4);
                        //if (!isSupervisor)
                        //{
                        //    XtraMessageBox.Show("You are Supevisor to delete", "TPWMS",
                        //    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //    return;
                        //}

                        //if (XtraMessageBox.Show("Are you sure to delete this confimed product ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        //{
                        //    int id = Convert.ToInt32(this.gridViewOrderDetail.GetRowCellValue(selectRows[i], "ReceivingOrderDetailID"));
                        //    result = this._roDA.STReceivingOrderDetailDelete(id, AppSetting.CurrentUser.LoginName);
                        //    isDelete = true;
                        //}
                    }
                }

                if (isDelete)
                {
                    this.LoadDataDetail(Convert.ToInt32(textEditOrderID.Tag));
                }
            }
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

        private void btnInOutView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (lookUpEditCustomerID.Tag == null) return;
            frm_WM_InOutViewByDate.Instance.ViewRODOData((int)lookUpEditCustomerID.Tag, true);
            frmMain.Instance.BringToFront();
        }


        /// <summary>
        /// Delete Receiving Order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem64_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.listOrderDetail.Count > 0)
            {
                XtraMessageBox.Show("Please delete all products !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var dl = MessageBox.Show("Are you sure to delete this order?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dl.Equals(DialogResult.No)) return;

                this._roDA.STOrderDelete(this.textEditOrderID.Text);
                if (this.listReceivingOrders.Count > 1)
                {
                    this.receivingOrderFind = -1;
                    GetDataToLoad();
                }
                else
                {
                    dataNavigatorReceivingOrders.Position = listReceivingOrders.Count;
                    textEditOrderID.Text = "RO-New *";
                    textEditOrderID.Tag = 0;
                    memoEditTruckAndDetail.Text = "";
                    dateEditReceivingOrderDate.Tag = dateEditReceivingOrderDate.EditValue = DateTime.Now.Date;
                    timeEditStartTime.Tag = timeEditStartTime.EditValue = null; // DateTime.Now;
                    timeEditEndTime.Tag = timeEditEndTime.EditValue = null; // DateTime.Now;
                    spinEditTemperature.Tag = spinEditTemperature.EditValue = null;
                    textEditSealNumber.Tag = textEditSealNumber.Text = "";
                    this.textEditReceivingOrderProgress.EditValue = null;
                    this.lkeDockNumber.EditValue = null;
                    textEditInernalRemark.Tag = textEditInernalRemark.Text = "";
                    lookUpEditCustomerID.Tag = lookUpEditCustomerID.EditValue = null;
                    this.textEditVehicleNumber.Tag = this.textEditVehicleNumber.Text = string.Empty;
                    this.textEditCustomerOrderNumber.Tag = this.textEditCustomerOrderNumber.Text = string.Empty;
                    this.textEditCustomerOrderNumber2.Tag = this.textEditCustomerOrderNumber2.Text = string.Empty;
                    this.txtPutAwayPercent.Tag = null;
                    this.txtPutAwayPercent.Text = string.Empty;
                    this.txtProcessStatus.Tag = null;
                    this.txtProcessStatus.Text = string.Empty;
                    this.txtEDIMessageSentTime.Tag = null;
                    this.txtEDIMessageSentTime.Text = string.Empty;
                    lookUpEditCustomerID.ReadOnly = false;
                    listOrderDetail.Clear();
                    lookUpEditCustomerID.Focus();
                    lookUpEditCustomerID.ShowPopup();
                }
            }
        }

        private void barButtonItem56_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {


        }

        private void btnAdviceByLocation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int receivingOrderID = Convert.ToInt32(this.textEditOrderID.Tag);
            rptReceivingAdviceByProduct rpt = new rptReceivingAdviceByProduct();
            DataProcess<STReceivingAdvice_Result> receivingAdviceDA = new DataProcess<STReceivingAdvice_Result>();
            rpt.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
            rpt.Parameters["varReceivingOrderID"].Value = receivingOrderID;
            rpt.DataSource = receivingAdviceDA.Executing("STReceivingAdvice @varReceivingOrderID={0}", receivingOrderID);
            rpt.RequestParameters = false;
            ReportPrintToolWMS printTool = new ReportPrintToolWMS(rpt);
            printTool.AutoShowParametersPanel = false;
            printTool.ShowPreview();
        }

        /// <summary>
        /// Split RO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem69_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraMessageBoxArgs args = new XtraMessageBoxArgs();
            //args.AutoCloseOptions.Delay = 5000;
            args.Caption = "Split Receiving Order";
            args.Text = "Please Select Action to Split the Current Receiving Order : " + Environment.NewLine +
                "- Yes: Split Quantity of the current Product" + Environment.NewLine + "- No: Split the Selected Product to New RO" + Environment.NewLine + "- OK: Auto Split to new RO by Account"
                + Environment.NewLine + "- Cancel to exit";
            args.Buttons = new DialogResult[] { DialogResult.Yes, DialogResult.No, DialogResult.OK, DialogResult.Cancel };
            switch (XtraMessageBox.Show(args).ToString())
            {
                case ("Yes"): //Split quantiy of a receiving order Detail
                    DataProcess<Pallets> palletDA = new DataProcess<Pallets>();
                    int roDetailID = Convert.ToInt32(this.gridViewOrderDetail.GetFocusedRowCellValue("ReceivingOrderDetailID"));

                    if (roDetailID <= 0)
                    {
                        return;
                    }

                    Customers customer = this.listCustomer.Where(c => c.CustomerID == Convert.ToInt32(this.lookUpEditCustomerID.EditValue)).FirstOrDefault();
                    byte status = Convert.ToByte(this.gridViewOrderDetail.GetFocusedRowCellValue("Status"));
                    short quantity = Convert.ToInt16(this.gridViewOrderDetail.GetFocusedRowCellValue("TotalPackages"));
                    short totalAfterDPQty = 0;
                    List<Pallets> listPallets = palletDA.Select(x => x.ReceivingOrderDetailID == roDetailID).ToList();

                    foreach (Pallets item in listPallets)
                    {
                        totalAfterDPQty = (short)(totalAfterDPQty + item.AfterDPQuantity);
                    }

                    if (status < 2)
                    {
                        //CurrentCustomer = cusDA.Select(c => c.CustomerID == customerID).FirstOrDefault();
                        if (customer.isAllowDataIntegration != true)
                        {
                            XtraMessageBox.Show("This Order is not confirmed yet, Please confirm the order before split !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                    }

                    if (customer.CustomerType.Equals(CustomerTypeEnum.RANDOM_WEIGHT))
                    {
                        XtraMessageBox.Show("This Customer is not allowed to split the order !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var defaultRespond = XtraInputBox.Show("Please enter the required quantity to break the order :", "TPWMS", "0");
                    if (string.IsNullOrEmpty(defaultRespond)) return;
                    short breakQty = Convert.ToInt16(defaultRespond);

                    if (breakQty > totalAfterDPQty || breakQty < 1)
                    {
                        XtraMessageBox.Show("Wrong Number !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (breakQty == totalAfterDPQty && breakQty == quantity)
                        {
                            XtraMessageBox.Show("Wrong Number !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            int result = this._roDA.STReceivingOrderDetailBreak(roDetailID, breakQty, AppSetting.CurrentUser.LoginName);
                            LoadDataDetail(Convert.ToInt32(textEditOrderID.Tag));
                        }
                    }
                    break;

                case ("No"): // Split the selected ReceivingOrderDetails to another RO
                    int v_DetailID = 0;
                    foreach (var index in this.gridViewOrderDetail.GetSelectedRows())
                    {
                        try
                        {
                            v_DetailID = Convert.ToInt32(this.gridViewOrderDetail.GetRowCellDisplayText(index, "ReceivingOrderDetailID"));
                        }
                        catch (Exception ex)
                        {
                            log.Error("==> Error is unexpected");
                            log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                        }
                        DataProcess<object> dataProcess = new DataProcess<object>();

                        int result = dataProcess.ExecuteNoQuery("Update ReceivingOrderDetails set IsMoving={0}  where ReceivingOrderDetailID={1}", 1, v_DetailID);

                    }
                    int OrderID = Convert.ToInt32(this.textEditOrderID.Tag);
                    if (OrderID <= 0) return;
                    DataProcess<object> dataProcess1 = new DataProcess<object>();
                    int resultProcess = dataProcess1.ExecuteNoQuery("ST_WMS_SplitDetailRO " + OrderID + ",'" + AppSetting.CurrentUser.LoginName + "'");
                    if (resultProcess < 0)
                    {
                        MessageBox.Show("Process Split Fail", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    MessageBox.Show("Split Ok", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.LoadDataDetail(OrderID);
                    break;

                case ("OK"): // Split auto to many RO depending on the Customer Accounts that the product belonging to
                    int rOrderID = Convert.ToInt32(this.textEditOrderID.Tag);
                    if (rOrderID <= 0) return;
                    DataProcess<object> dp = new DataProcess<object>();
                    int res = dp.ExecuteNoQuery("ST_WMS_SplitAccountRO " + rOrderID + ",'" + AppSetting.CurrentUser.LoginName + "'");
                    if (res < 0)
                    {
                        MessageBox.Show("Process Split Fail", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    MessageBox.Show("Split Ok", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.LoadDataDetail(rOrderID);

                    break;
                case ("Cancel"):
                    return;

            }

            //return;
        }

        private void frm_WM_ReceivingOrders_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                if (this.textEditOrderID.Equals("RO-New*"))
                {
                    return;
                }
                else
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

        private void btnAdvice_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.AdviceReport(false);
        }

        private void AdviceReport(bool isPreview)
        {
            string customerID = lookUpEditCustomerID.Tag.ToString();
            if (string.IsNullOrEmpty(customerID))
            {
                lookUpEditCustomerID.Focus();
                return;
            }
            string customerType = lookUpEditCustomerID.GetColumnValue("CustomerType").ToString();
            if (customerType == "Pcs")
            {
                printReceivingAdvice_Pcs(isPreview);
            }
            else
            {
                printReceivingAdvice(isPreview);
            }
        }
        private void printReceivingAdvice(bool isPreview)
        {
            int receivingOrderID = Convert.ToInt32(this.textEditOrderID.Tag);
            DataProcess<STReceivingAdvice_Result> receivingAdviceDA = new DataProcess<STReceivingAdvice_Result>();
            rptReceivingAdvice RA = new rptReceivingAdvice();
            RA.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
            RA.Parameters["varReceivingOrderID"].Value = receivingOrderID;
            RA.DataSource = receivingAdviceDA.Executing("STReceivingAdvice @varReceivingOrderID={0}", receivingOrderID);
            RA.RequestParameters = false;
            RA.PaperKind = System.Drawing.Printing.PaperKind.A4;
            ReportPrintToolWMS printTool = new ReportPrintToolWMS(RA);
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

        private void printtReceivingAdvice_Lanscape(bool isPreview)
        {
            int receivingOrderID = Convert.ToInt32(this.textEditOrderID.Tag);
            DataProcess<STReceivingAdvice_Result> receivingAdviceDA = new DataProcess<STReceivingAdvice_Result>();
            rptReceivingAdvice_Lanscape RA = new rptReceivingAdvice_Lanscape();
            RA.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
            RA.Parameters["varReceivingOrderID"].Value = receivingOrderID;
            RA.DataSource = receivingAdviceDA.Executing("STReceivingAdvice @varReceivingOrderID={0}", receivingOrderID);
            RA.RequestParameters = false;
            ReportPrintToolWMS printTool = new ReportPrintToolWMS(RA);
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

        private void printReceivingAdvice_Pcs(bool isPreview)
        {
            int receivingOrderID = Convert.ToInt32(this.textEditOrderID.Tag);
            DataProcess<STReceivingAdvice_Result> receivingAdviceDA = new DataProcess<STReceivingAdvice_Result>();
            rptReceivingAdvice_pcs RA = new rptReceivingAdvice_pcs();
            RA.Parameters["CurrentUser"].Value = AppSetting.CurrentUser.LoginName;
            RA.Parameters["varReceivingOrderID"].Value = receivingOrderID;
            RA.DataSource = receivingAdviceDA.Executing("STReceivingAdvice @varReceivingOrderID={0}", receivingOrderID);
            RA.RequestParameters = false;
            ReportPrintToolWMS printTool = new ReportPrintToolWMS(RA);
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

        private void btnPrintISO_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ISOReport();
        }

        /// <summary>
        /// Definition ISO report will print or preview
        /// </summary>
        /// <param name="isPrint"></param>
        private void ISOReport(bool isPrint = true)
        {
            DataProcess<STCustomerRequirementPrint_Result> printISO = new DataProcess<STCustomerRequirementPrint_Result>();
            int receivingOrderID = Convert.ToInt32(this.textEditOrderID.Tag);
            int customerID = Convert.ToInt32(lookUpEditCustomerID.Tag);

            Customers customerSelected = AppSetting.CustomerList.Where(x => x.CustomerID == customerID).FirstOrDefault();
            int customerMainIDISO = (int)customerSelected.CustomerMainID;
            // init datasource
            List<STCustomerRequirementPrint_Result> dataPrintISOList = printISO.Executing("STCustomerRequirementPrint @CustomerMainID={0}, @Flag={1}, @ReceivingOrderID={2}", customerMainIDISO, 1, receivingOrderID).ToList();
            dataPrintISOList = dataPrintISOList.OrderByDescending(a => a.CustomerRequirementID).ToList();
            STCustomerRequirementPrint_Result dataPrintISO = dataPrintISOList.FirstOrDefault();
            Customers customer = listCustomer.FirstOrDefault(c => c.CustomerID == customerID);
            StringBuilder strRequirementDetails = new StringBuilder();
            foreach (var item in dataPrintISOList)
            {
                strRequirementDetails.Append(item.RequirementDetails + Environment.NewLine);
            }
            ReportPrintToolWMS printTool = null;

            if ((int)customer.CustomerCategory == 14)
            {
                // call report rptReceivingProductQualityCheckingDG 
                rptReceivingProductQualityCheckingDG ReceivingProductQualityCheckingDG = new rptReceivingProductQualityCheckingDG();
                ReceivingProductQualityCheckingDG.bcPalletID.Text = dataPrintISO.ReceivingOrderID_Barcode.ToString();
                ReceivingProductQualityCheckingDG.Parameters["varReceivingOrderNumber"].Value = textEditOrderID.Text;
                ReceivingProductQualityCheckingDG.Parameters["varCustomerName"].Value = textEditCustomerName.Text;
                ReceivingProductQualityCheckingDG.Parameters["varSpecialRequired"].Value = this.textEditVehicleNumber.Text;
                ReceivingProductQualityCheckingDG.Parameters["varCurrentUser"].Value = fullInfoEmployees.FullName;
                ReceivingProductQualityCheckingDG.Parameters["varReceivingOrderID_Barcode"].Value = dataPrintISO.ReceivingOrderID_Barcode;
                ReceivingProductQualityCheckingDG.Parameters["varRequirementDetail"].Value = strRequirementDetails;
                ReceivingProductQualityCheckingDG.RequestParameters = false;
                ReceivingProductQualityCheckingDG.DataSource = printISO.Executing("STCustomerRequirementPrint @CustomerMainID={0}, @Flag={1}, @ReceivingOrderID={2}", customerMainIDISO, 1, receivingOrderID);
                printTool = new ReportPrintToolWMS(ReceivingProductQualityCheckingDG);
            }
            else
            {
                // call report rptReceivingProductQualityChecking
                rptReceivingProductQualityChecking ReceivingProductQualityChecking = new rptReceivingProductQualityChecking();
                ReceivingProductQualityChecking.bcPalletID.Text = dataPrintISO.ReceivingOrderID_Barcode.ToString();
                ReceivingProductQualityChecking.Parameters["varReceivingOrderNumber"].Value = textEditOrderID.Text;
                ReceivingProductQualityChecking.Parameters["varCustomerName"].Value = textEditCustomerName.Text;
                ReceivingProductQualityChecking.Parameters["varSpecialRequired"].Value = this.textEditVehicleNumber.Text;
                ReceivingProductQualityChecking.Parameters["varCurrentUser"].Value = fullInfoEmployees.FullName;
                ReceivingProductQualityChecking.Parameters["varReceivingOrderID_Barcode"].Value = dataPrintISO.ReceivingOrderID_Barcode;
                ReceivingProductQualityChecking.Parameters["varRequirementDetail"].Value = strRequirementDetails;
                ReceivingProductQualityChecking.RequestParameters = false;
                ReceivingProductQualityChecking.DataSource = printISO.Executing("STCustomerRequirementPrint @CustomerMainID={0}, @Flag={1}, @ReceivingOrderID={2}", customerMainIDISO, 1, receivingOrderID);
                printTool = new ReportPrintToolWMS(ReceivingProductQualityChecking);
            }

            printTool.AutoShowParametersPanel = false;
            if (isPrint)
            {
                printTool.Print();
            }
            else
            {
                printTool.ShowPreview();
            }
        }

        private void btnAdviceLabelA4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.AdviceLabelA4Report(false);
        }

        private void AdviceLabelA4Report(bool isPreview)
        {
            string customerType = lookUpEditCustomerID.GetColumnValue("CustomerType").ToString();
            if (customerType == "Pcs")
            {
                printReceivingAdvice_Pcs(isPreview);
                printlabelA4short_pcs(isPreview);
            }
            else
            {
                printReceivingAdvice(isPreview);
                printLabelA4short(isPreview);
            }
        }

        private void PrintLabelDecal(bool isPreview)
        {
            DataProcess<STLabel1RO_Result> multilabel = new DataProcess<STLabel1RO_Result>();
            rptLabelDecal lb = new rptLabelDecal();
            ReceivingOrderDetails rODetail = (ReceivingOrderDetails)gridViewOrderDetail.GetFocusedRow();
            int receivingOrderID = Convert.ToInt32(this.textEditOrderID.Tag);
            if (rODetail == null) return;
            lb.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
            lb.Parameters["varReceivingOrderID"].Value = receivingOrderID;
            lb.Parameters["parameter1"].Value = 4;
            lb.xrLabelRO.Text = rODetail.ReceivingOrderNumber;
            lb.DataSource = multilabel.Executing("STLabel1RO @varReceivingOrderID={0}", rODetail.ReceivingOrderID);
            lb.RequestParameters = false;
            //  IList<STLabel1ReceivingOrderDetail_Result> getPalletIDBarcode = (IList<STLabel1ReceivingOrderDetail_Result>)lb.DataSource;
            //  lb.bcPalletID.Text = getPalletIDBarcode.Select(obj => obj.PalletID_Barcode).FirstOrDefault();

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

        private void btnAdviceLabelDecal_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.AdviceLabelDecalReport(false);
        }

        private void AdviceLabelDecalReport(bool isPreview)
        {
            string customerType = lookUpEditCustomerID.GetColumnValue("CustomerType").ToString();
            if (customerType == "Pcs") // Pices
            {
                printReceivingAdvice_Pcs(isPreview);
                printlabelA4short_pcs(isPreview);
            }
            else
            {
                printReceivingAdvice(isPreview);
                PrintLabelDecal(isPreview);
            }
        }

        private void printlabelA4short_pcs(bool isPreview)
        {
            int receivingOrderID = Convert.ToInt32(this.textEditOrderID.Tag);
            //DataProcess<STLabel1RO_Result> label1RO = new DataProcess<STLabel1RO_Result>();
            rptLabelA4Short_Barcode_pcs reportA4ShortPcs = new rptLabelA4Short_Barcode_pcs();
            //reportA4ShortPcs.bcPalletID.Text = "*" + receivingOrderID.ToString() + "*";
            reportA4ShortPcs.Parameters["varReceivingOrderID"].Value = receivingOrderID;
            reportA4ShortPcs.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
            reportA4ShortPcs.Parameters["parameter1"].Value = 3;
            reportA4ShortPcs.RequestParameters = false;
            reportA4ShortPcs.DataSource = FileProcess.LoadTable("STLabel1RO " + receivingOrderID);
            ReportPrintToolWMS printToolA4 = new ReportPrintToolWMS(reportA4ShortPcs);
            printToolA4.AutoShowParametersPanel = false;
            if (isPreview)
            {
                printToolA4.ShowPreview();
            }
            else
            {
                printToolA4.Print();
            }

        }

        private void printLabelA4short(bool isPreview)
        {
            int receivingOrderID = Convert.ToInt32(this.textEditOrderID.Tag);
            //DataProcess<STLabel1RO_Result> multilabel = new DataProcess<STLabel1RO_Result>();
            rptLabelA4Short_Barcode lb = new rptLabelA4Short_Barcode();
            lb.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
            lb.Parameters["parameter1"].Value = 3;
            lb.DataSource = FileProcess.LoadTable("STLabel1RO " + receivingOrderID);
            lb.RequestParameters = false;
            //  lb.bcPalletID.Text = "*" + receivingOrderID.ToString() + "*";

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

        //private void btnViewAdviceLandscape_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    printtReceivingAdvice_Lanscape(true);
        //}

        private void btn_mnu_PreviewISO_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ISOReport(false);
        }

        private void btn_mnu_PreviewAdvice_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.AdviceReport(true);
        }

        private void btn_mnu_PreviewAdviceLabelDecal_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.AdviceLabelDecalReport(true);
        }

        private void btn_mnu_PreviewViewAdvice_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ViewAdviceReport(true);
        }

        private void btn_mnu_PreviewNoteDetail_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            printReceivingNoteDetail(true);
        }

        private void btn_mnu_PreviewNote_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            printNote(true);
        }

        private void btnNoteReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            printNote(false);
        }
        private void printReceivingNoteDetail(bool isPreview)
        {
            int customerID = (int)lookUpEditCustomerID.EditValue;
            int receivingOrderID = (int)textEditOrderID.Tag;
            string orderNumber = textEditOrderID.Text;
            DataProcess<STReceivingNote_Result> receivingNote = new DataProcess<STReceivingNote_Result>();
            string customerType = lookUpEditCustomerID.Properties.GetDataSourceValue("CustomerType", lookUpEditCustomerID.ItemIndex).ToString();
            var vareceivingNote = new object();
            if (handlingOvertimeCheck(customerID) > 0 && lookUpEditHandlingOvertimeCategoryID.EditValue == null)
            {
                labelServiceOvertime(orderNumber, customerID);
            }
            else if (handlingOvertimeCheck(customerID) == 0 && ((int)lookUpEditHandlingOvertimeCategoryID.EditValue != 346 && lookUpEditHandlingOvertimeCategoryID.EditValue != null))
            {
                MessageBox.Show("Please check services of this customer!");
            }
            else
            {
                if (lookUpEditCustomerID.EditValue == null)
                {
                    lookUpEditCustomerID.Focus();
                    return;
                }
                int flag = 0;
                if (boflag) flag = 1;
                vareceivingNote = FileProcess.LoadTable(string.Format("STReceivingNote @varReceivingOrderID={0}, @Flag={1} ", receivingOrderID, flag));
                if (customerType.Equals(CustomerTypeEnum.PCS))
                {
                    rptReceivingNoteDetails_Pcs rptNoteDetailPCs = new ReportFile.rptReceivingNoteDetails_Pcs();
                    rptNoteDetailPCs.Parameters["varCurrentUser"].Value = fullInfoEmployees.FullName;
                    rptNoteDetailPCs.Parameters["varLoginUser"].Value = AppSetting.CurrentUser.LoginName;
                    rptNoteDetailPCs.Parameters["Barcode"].Value = "RO" + receivingOrderID.ToString("D9");
                    rptNoteDetailPCs.RequestParameters = false;
                    rptNoteDetailPCs.DataSource = vareceivingNote;
                    //print rptReceivingNoteDetails_Pcs
                    ReportPrintToolWMS printTool = new ReportPrintToolWMS(rptNoteDetailPCs, customerID);
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
                else if (customerType.Equals(CustomerTypeEnum.RANDOM_WEIGHT))
                {
                    DataProcess<object> customerByOvertimeCheckingTime = new DataProcess<object>();
                    int result = customerByOvertimeCheckingTime.ExecuteNoQuery("STReceivingOrderPalletCartonWeightUpdate @ReceivingOrderID= {0}", receivingOrderID);
                    rptReceivingNoteDetails ReceivingNoteDetails = new rptReceivingNoteDetails();
                    //ReceivingNoteDetails.Parameters["varDispatchingOrderID"].Value = (int)textEditOrderID.Tag;
                    ReceivingNoteDetails.Parameters["varCurrentUser"].Value = fullInfoEmployees.FullName;
                    ReceivingNoteDetails.Parameters["varLoginUser"].Value = AppSetting.CurrentUser.LoginName;
                    ReceivingNoteDetails.Parameters["Barcode"].Value = "RO" + receivingOrderID.ToString("D9");
                    ReceivingNoteDetails.RequestParameters = false;
                    ReceivingNoteDetails.DataSource = vareceivingNote;
                    ReportPrintToolWMS printTool = new ReportPrintToolWMS(ReceivingNoteDetails, customerID);
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
                    rptReceivingNoteDetails ReceivingNoteDetails = new rptReceivingNoteDetails();
                    //ReceivingNoteDetails.Parameters["varDispatchingOrderID"].Value = (int)textEditOrderID.Tag;
                    ReceivingNoteDetails.Parameters["varCurrentUser"].Value = fullInfoEmployees.FullName;
                    ReceivingNoteDetails.Parameters["varLoginUser"].Value = AppSetting.CurrentUser.LoginName;
                    ReceivingNoteDetails.Parameters["Barcode"].Value = "RO" + receivingOrderID.ToString("D9");
                    ReceivingNoteDetails.RequestParameters = false;
                    ReceivingNoteDetails.DataSource = vareceivingNote;
                    ReportPrintToolWMS printTool = new ReportPrintToolWMS(ReceivingNoteDetails, customerID);
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
        private void printNote(bool isPreview)
        {
            DataProcess<STReceivingNote_Result> receivingNote = new DataProcess<STReceivingNote_Result>();
            int customerID = Convert.ToInt32(lookUpEditCustomerID.Tag);
            int receivingOrderID = (int)textEditOrderID.Tag;
            string orderNumber = textEditOrderID.Text;
            var vareceivingNote = new object();
            if (handlingOvertimeCheck(customerID) > 0 && lookUpEditHandlingOvertimeCategoryID.EditValue == null)
            {
                labelServiceOvertime(orderNumber, customerID);
            }
            else if (handlingOvertimeCheck(customerID) == 0 && ((int)lookUpEditHandlingOvertimeCategoryID.EditValue != 346 && lookUpEditHandlingOvertimeCategoryID.EditValue != null))
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
                if (lookUpEditCustomerID.EditValue == null)
                {
                    lookUpEditCustomerID.Focus();
                    return;
                }
                int flag = 0;
                if (boflag) flag = 1;
                vareceivingNote = FileProcess.LoadTable(string.Format("STReceivingNote @varReceivingOrderID={0}, @Flag={1} ", receivingOrderID, flag));
                Customers currentCustomers = this.listCustomer.Where(c => c.CustomerID == Convert.ToInt32(this.lookUpEditCustomerID.EditValue)).FirstOrDefault();

                if (currentCustomers.CustomerType.Equals(CustomerTypeEnum.RANDOM_WEIGHT))
                {
                    DataProcess<object> customerByOvertimeCheckingTime = new DataProcess<object>();
                    int result = customerByOvertimeCheckingTime.ExecuteNoQuery("STReceivingOrderPalletCartonWeightUpdate @ReceivingOrderID= {0}", receivingOrderID);
                    rptReceivingNote_UnitWeight RNUnit = new rptReceivingNote_UnitWeight();
                    RNUnit.Parameters["varCurrentUser"].Value = fullInfoEmployees.FullName;
                    RNUnit.Parameters["Barcode"].Value = "RO" + receivingOrderID.ToString("D9");
                    //RNUnit.Parameters["varLoginUser"].Value = AppSetting.CurrentUser.LoginName;
                    RNUnit.DataSource = vareceivingNote;
                    RNUnit.RequestParameters = false;
                    ReportPrintToolWMS printTool = new ReportPrintToolWMS(RNUnit, customerID);
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
                else if (currentCustomers.CustomerType.Equals(CustomerTypeEnum.PCS))
                {
                    rptReceivingNote_pcs RNPCS = new rptReceivingNote_pcs();
                    RNPCS.Parameters["varCurrentUser"].Value = fullInfoEmployees.FullName;
                    // RNPCS.Parameters["varLoginUser"].Value = AppSetting.CurrentUser.LoginName;
                    RNPCS.Parameters["Barcode"].Value = "RO" + receivingOrderID.ToString("D9");
                    RNPCS.DataSource = vareceivingNote;
                    RNPCS.RequestParameters = false;
                    ReportPrintToolWMS printTool = new ReportPrintToolWMS(RNPCS, customerID);
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
                    rptReceivingNote RN = new rptReceivingNote();
                    RN.Parameters["varCurrentUser"].Value = fullInfoEmployees.FullName;
                    RN.Parameters["varLoginUser"].Value = AppSetting.CurrentUser.LoginName;
                    RN.Parameters["Barcode"].Value = "RO" + receivingOrderID.ToString("D9");
                    RN.DataSource = vareceivingNote;
                    RN.RequestParameters = false;
                    ReportPrintToolWMS printTool = new ReportPrintToolWMS(RN, customerID);
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
        private void btnDetailNoteReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            printReceivingNoteDetail(false);
        }

        private void btn_mnu_PreviewAdviceLabelA4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.AdviceLabelA4Report(true);
        }

        /// <summary>
        /// Display Stock on hand by customer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void layoutControlItem30_DoubleClick(object sender, EventArgs e)
        {
            if (this.lookUpEditCustomerID.EditValue == null) return;
            frm_ST_StockOnHandOneCustomer stockForm = new frm_ST_StockOnHandOneCustomer((int)this.lookUpEditCustomerID.EditValue);
            if (!stockForm.Enabled) return;
            stockForm.ShowDialog();
        }

        private void lookUpEditCustomerID_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpEditCustomerID.ItemIndex < 0) return;
            string customerName = lookUpEditCustomerID.Properties.GetDataSourceValue("CustomerName", lookUpEditCustomerID.ItemIndex).ToString();
            textEditCustomerName.Text = customerName;
            this.Text = "RO-" + customerName;
            if (isUpdate || this.textEditOrderID.Text.Equals("RO-New *") || this.textEditOrderID.Text.Trim().Equals("RO-0"))
            {
                this.UpdateRO();
            }
        }

        private void btnNoteByCarton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int flag = 0;
            if (boflag) flag = 1;

            int customerID = (int)lookUpEditCustomerID.EditValue;
            string customerType = lookUpEditCustomerID.Properties.GetDataSourceValue("CustomerType", lookUpEditCustomerID.ItemIndex).ToString();
            if (customerType.Equals(CustomerTypeEnum.RANDOM_WEIGHT))
            {
                DataProcess<object> customerByOvertimeCheckingTime = new DataProcess<object>();
                int result = customerByOvertimeCheckingTime.ExecuteNoQuery("STReceivingOrderPalletCartonWeightUpdate @ReceivingOrderID= {0}", (int)textEditOrderID.Tag);
            }



            rptReceivingNoteByCarton rp = new rptReceivingNoteByCarton();
            var STReceivingNoteByCartonList = FileProcess.LoadTable("STReceivingNoteByCarton @varReceivingOrderID=" + (int)textEditOrderID.Tag + ", @Flag=" + flag);
            //int customerID = Convert.ToInt32(lookUpEditCustomerID.Tag);
            if (STReceivingNoteByCartonList.Rows.Count > 0)
            {
                rp.DataSource = STReceivingNoteByCartonList;
                rp.RequestParameters = false;
                rp.Parameters["varLoginUser"].Value = AppSetting.CurrentUser.LoginName;
                rp.Parameters["varCurrentUser"].Value = fullInfoEmployees.FullName;
                rp.Parameters["Barcode"].Value = "RO" + ((int)textEditOrderID.Tag).ToString("D9");
                ReportPrintToolWMS printTool = new ReportPrintToolWMS(rp, customerID);
                printTool.AutoShowParametersPanel = false;
                printTool.ShowPreview();
            }
            else
            {
                MessageBox.Show("Nothing to print");
            }


        }
        private int handlingOvertimeCheck(int customerID)
        {
            DataProcess<object> serviceQty = new DataProcess<object>();
            ObjectParameter outParams = new ObjectParameter("serviceQty", 0);
            using (var context = new SwireDBEntities())
            {
                context.STCustomerBillingByOvertime(customerID, outParams);
            }
            return Convert.ToInt32(outParams.Value);
        }
        private void labelServiceOvertime(string orderNumber, int customerID)
        {
            int handlingOvertimeCategoryID = 0;
            using (var context = new SwireDBEntities())
            {
                ObjectParameter outParams = new ObjectParameter("HW_OT_CatID", 0);
                context.STCustomerByOvertimeCheckingTime(orderNumber, customerID, outParams);
                handlingOvertimeCategoryID = Convert.ToInt16(outParams.Value);
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

        private void textEditDockNumber_Leave(object sender, EventArgs e)
        {
            if (isUpdate)
            {
                UpdateRO();
            }
        }

        private void gridViewOrderDetail_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle < 0) return;
            if (e.Column.FieldName.Equals("Remark"))
            {
                ReceivingOrderDetails rODetail = this.gridViewOrderDetail.GetRow(e.RowHandle) as ReceivingOrderDetails;

                using (var context = new SwireDBEntities())
                {
                    context.ReceivingOrderDetails.Attach(rODetail);
                    context.Entry(rODetail).State = System.Data.Entity.EntityState.Modified;
                }
                this.recevingOrderDetailDA.Update(rODetail);
            }
            else if (e.Column.FieldName.Equals("NumExp"))
            {
                var proDate = this.gridViewOrderDetail.GetRowCellValue(this.gridViewOrderDetail.FocusedRowHandle, "ProductionDate");
                if (proDate == null)
                {
                    return;
                }
                var prodateValue = Convert.ToDateTime(proDate);
                var useDateValue = prodateValue.AddDays(Convert.ToInt32(e.Value));
                this.gridViewOrderDetail.SetFocusedRowCellValue("UseByDate", useDateValue);
                ReceivingOrderDetails rODetail = this.gridViewOrderDetail.GetRow(e.RowHandle) as ReceivingOrderDetails;

                using (var context = new SwireDBEntities())
                {
                    context.ReceivingOrderDetails.Attach(rODetail);
                    context.Entry(rODetail).State = System.Data.Entity.EntityState.Modified;
                }
                this.recevingOrderDetailDA.Update(rODetail);
            }
        }

        private void gridViewOrderDetail_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            DevExpress.XtraGrid.Columns.GridColumn colProDate = this.gridViewOrderDetail.Columns["ProductionDate"];
            DevExpress.XtraGrid.Columns.GridColumn colUseDate = this.gridViewOrderDetail.Columns["UseByDate"];

            var proDate = this.gridViewOrderDetail.GetRowCellValue(this.gridViewOrderDetail.FocusedRowHandle, "ProductionDate");
            var useDate = this.gridViewOrderDetail.GetRowCellValue(this.gridViewOrderDetail.FocusedRowHandle, "UseByDate");
            if (proDate == null || useDate == null)
            {
                return;
            }

            if (DateTime.Compare((DateTime)proDate, (DateTime)useDate) > 0)
            {
                this.gridViewOrderDetail.SetColumnError(colProDate, "[Prodate]<=[Exdate]");
                e.Valid = false;
                return;
            }

            ReceivingOrderDetails rODetail = this.gridViewOrderDetail.GetRow(e.RowHandle) as ReceivingOrderDetails;

            using (var context = new SwireDBEntities())
            {
                context.ReceivingOrderDetails.Attach(rODetail);
                context.Entry(rODetail).State = System.Data.Entity.EntityState.Modified;
            }
            this.recevingOrderDetailDA.Update(rODetail);
        }

        private void gridViewOrderDetail_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void lookUpEditCustomerID_Click(object sender, EventArgs e)
        {
            this.lookUpEditCustomerID.SelectAll();
        }

        private void dateEditReceivingOrderDate_Leave(object sender, EventArgs e)
        {
            if (this.dateEditReceivingOrderDate.EditValue == null) return;
            if (!this.dateEditReceivingOrderDate.IsModified) return;
            if (this.dateEditReceivingOrderDate.DateTime.Date < DateTime.Now.Date || this.dateEditReceivingOrderDate.DateTime.Date > DateTime.Now.AddDays(1).Date ||
                (this.dateEditReceivingOrderDate.DateTime - this.orderTraceDate).TotalDays > 3 || this.dateEditReceivingOrderDate.DateTime.Date == this.orderTraceDate.Date)
            {
                this.dateEditReceivingOrderDate.EditValue = this.orderTraceDate;
                return;
            }

            if (isUpdate)
            {
                UpdateRO();
                this.orderTraceDate = this.dateEditReceivingOrderDate.DateTime;
            }
        }

        private void gridViewOrderDetail_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle == view.FocusedRowHandle)
                e.Appearance.BackColor = Color.Gainsboro;
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
                if (isUpdate)
                {
                    UpdateRO();
                    this.isTruckModified = false;
                }
            }
        }

        private void memoEditTruckAndDetail_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void rpi_dProdate_Validating(object sender, CancelEventArgs e)
        {
            int hasConfirm = Convert.ToInt32(this.gridViewOrderDetail.GetRowCellValue(this.gridViewOrderDetail.FocusedRowHandle, "Status"));
            if (hasConfirm >= 2)
            {
                e.Cancel = true;
                return;
            }
            var prodate = (DevExpress.XtraEditors.DateEdit)sender;
            DevExpress.XtraGrid.Columns.GridColumn colProDate = this.gridViewOrderDetail.Columns["ProductionDate"];
            var useDate = this.gridViewOrderDetail.GetRowCellValue(this.gridViewOrderDetail.FocusedRowHandle, "UseByDate");
            if (DateTime.Compare(prodate.DateTime, DateTime.Now) > 0)
            {
                this.gridViewOrderDetail.SetColumnError(colProDate, "[Prodate]<=current date");
                e.Cancel = true;
                return;
            }

            string numberExp = Convert.ToString(this.gridViewOrderDetail.GetFocusedRowCellValue("NumExp"));
            if (string.IsNullOrEmpty(numberExp)) return;
            var prodateValue = Convert.ToDateTime(prodate.DateTime);
            var useDateValue = prodateValue.AddDays(Convert.ToInt32(numberExp));
            this.gridViewOrderDetail.SetFocusedRowCellValue("UseByDate", useDateValue);

            if (useDate == null)
            {
                return;
            }

            if (DateTime.Compare(prodate.DateTime, (DateTime)useDate) > 0)
            {
                this.gridViewOrderDetail.SetColumnError(colProDate, "[Prodate]<=[Exdate]");
                e.Cancel = true;
                return;
            }


        }

        private void rpi_dExpdate_Validating(object sender, CancelEventArgs e)
        {
            int hasConfirm = Convert.ToInt32(this.gridViewOrderDetail.GetRowCellValue(this.gridViewOrderDetail.FocusedRowHandle, "Status"));
            if (hasConfirm >= 2)
            {
                e.Cancel = true;
                return;
            }
            var expdate = (DevExpress.XtraEditors.DateEdit)sender;
            DevExpress.XtraGrid.Columns.GridColumn colProDate = this.gridViewOrderDetail.Columns["ProductionDate"];
            var proDate = this.gridViewOrderDetail.GetRowCellValue(this.gridViewOrderDetail.FocusedRowHandle, "ProductionDate");
            if (proDate == null)
            {
                return;
            }

            if (DateTime.Compare((DateTime)proDate, expdate.DateTime) > 0)
            {
                this.gridViewOrderDetail.SetColumnError(colProDate, "[Prodate]<=[Exdate]");
                e.Cancel = true;
                return;
            }

            if (DateTime.Compare(DateTime.Now, expdate.DateTime) > 0)
            {
                this.gridViewOrderDetail.SetColumnError(colProDate, "invalid date");
                e.Cancel = true;
                return;
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

        private void timeEditStartTime_Validating(object sender, CancelEventArgs e)
        {
            if (!this.timeEditStartTime.IsModified) return;
            e.Cancel = false;
            this.validateList[timeEditStartTime] = false;
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

        private void spinEditTemperature_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
            int temperature = Convert.ToInt32(this.spinEditTemperature.EditValue);
            if (temperature < -25 || temperature > 25)
            {
                XtraMessageBox.Show("Please re-enter the correct temperature(-25 <= t°C <= 25)", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.spinEditTemperature.Focus();
                e.Cancel = true;
            }
        }

        private void LoadHoldList()
        {
            DataProcess<PalletStatu> palletStatusDA = new DataProcess<PalletStatu>();
            List<PalletStatu> list = (List<PalletStatu>)palletStatusDA.Select();
            this.rpi_lke_HoldList.DataSource = list;
            this.rpi_lke_HoldList.DisplayMember = "PalletStatusDescription";
            this.rpi_lke_HoldList.ValueMember = "PalletStatus";
        }

        private void rpi_lke_HoldList_EditValueChanged(object sender, EventArgs e)
        {

        }


        private void bEditHold_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            //this.bEditHold.ShownEditor();
        }

        private void btn_View_Advice_Landscape_RO_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            printtReceivingAdvice_Lanscape(true);
        }

        private void lke_WM_Supplier_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            this.lke_WM_Supplier.EditValue = e.Value;
            if (this.isUpdate)
            {
                this.UpdateRO();
            }
        }

        private void btnAdviceData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int receivingOrderID = Convert.ToInt32(this.textEditOrderID.Tag);
            frm_WM_Dialog_ReceivingAdvice Advice = new frm_WM_Dialog_ReceivingAdvice(receivingOrderID);
            Advice.Show();
        }

        /// <summary>
        /// Refresh vehicle data
        /// </summary>
        private void RefreshVehicleData()
        {
            string orderNumber = this.textEditOrderID.Text;
            this.viewVehicle.UpdateParam(Convert.ToInt32(this.lookUpEditCustomerID.Tag), this.textEditCustomerName.Text, this.textEditVehicleNumber.Text, this.textEditSealNumber.Text, this.lkeDockNumber.Text);
            this.viewVehicle.InitData(orderNumber);
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


        private void dockPanelVehicle_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            string orderNumber = this.textEditOrderID.Text;
            if (this.viewVehicle == null)
            {
                this.viewVehicle = new urc_WM_Vehicle(Convert.ToInt32(this.lookUpEditCustomerID.Tag), this.textEditCustomerName.Text, this.textEditVehicleNumber.Text, orderNumber, "Nhap", this.textEditSealNumber.Text, this.lkeDockNumber.Text);
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

        private void dockPanelService_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            if (this.viewService == null)
            {
                this.viewService = new urc_WM_OtherService(textEditOrderID.Text);
                if (this.listReceivingOrders.Count > 0)
                {
                    this.viewService.RecevingOrderInfo = listReceivingOrders[this.dataNavigatorReceivingOrders.Position];
                }
                this.viewService.Parent = this.dockPanelService;
            }
            else
            {
                if (this.listReceivingOrders.Count > 0)
                {
                    this.viewService.RecevingOrderInfo = listReceivingOrders[this.dataNavigatorReceivingOrders.Position];
                }
                this.viewService.InitData(this.textEditOrderID.Text);
            }
        }

        private void textEditVehicleNumber_EditValueChanged(object sender, EventArgs e)
        {
            if (isUpdate && this.textEditVehicleNumber.IsModified)
            {
                UpdateRO();
            }
        }

        private void textEditCustomerOrderNumber_EditValueChanged(object sender, EventArgs e)
        {
            if (isUpdate && this.textEditCustomerOrderNumber.IsModified)
            {
                UpdateRO();
            }
        }

        private void btnTo1Location_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.gridViewOrderDetail.FocusedRowHandle < 0) return;
            int productID = Convert.ToInt32(this.gridViewOrderDetail.GetFocusedRowCellValue("ProductID"));
            int roID = Convert.ToInt32(this.textEditOrderID.Tag);
            urc_WM_ROAllocateTo1Location urcOneLocation = new urc_WM_ROAllocateTo1Location(productID, roID);
            if (DevExpress.XtraEditors.XtraDialog.Show(urcOneLocation, "Allocate All Pallets To 1 Location", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                //Chú ý kiểm tra kỹ StoreProc STReceivingOrderAllocateTo1Location trên database test
                //Code to update all the locations of this ReceivingOrder to 1 Location, using the StoredProc STReceivingOrderAllocateTo1Location(@ReceivingOrderID int, @LocationID int, @Label varchar(20))
                DataProcess<object> dataProcess = new DataProcess<object>();
                int result = dataProcess.ExecuteNoQuery("STReceivingOrderAllocateTo1Location @ReceivingOrderID={0},@LocationID={1},@Label={2}",
                      roID, urcOneLocation.PalletTarget.LocationID, urcOneLocation.PalletTarget.LocationNumber);
            }
        }

        private void lke_TimeSlotID_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.Value == null) return;
            this.lke_TimeSlotID.EditValue = e.Value;
            if (this.isUpdate) this.UpdateRO();
            btn_WM_NewAllProduct.ItemAppearance.Normal.BackColor = Color.FromArgb(153, 180, 209);
            btn_WM_NewAllProduct.Links[0].Focus();
        }

        private void btnChangeProduct_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            rpihl_ProductChange_DoubleClick(sender, e);
        }

        private void rpihpl_DispatchInfo_Click(object sender, EventArgs e)
        {
            int dispatchingProductID = Convert.ToInt32(this.gridViewOrderDetail.GetFocusedRowCellValue("ReceivingOrderDetailID"));
            frm_WM_Dialog_DispatchingProductDetails frm = new frm_WM_Dialog_DispatchingProductDetails(dispatchingProductID);
            frm.ShowDialog();
        }

        private void gridViewOrderDetail_Click(object sender, EventArgs e)
        {
            var location = (MouseEventArgs)e;
            this.rowIndexFocused = this.gridViewOrderDetail.FocusedRowHandle;
            DevExpress.XtraGrid.Views.Base.ViewInfo.BaseHitInfo baseHI = this.gridViewOrderDetail.CalcHitInfo(location.Location);
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo gridHI = baseHI as DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo;
            if (gridHI.RowHandle < 0) return;
            switch (this.gridViewOrderDetail.FocusedColumn.FieldName)
            {

                case "gridColumnHold":
                    XtraMessageBox.Show("Show dialog Hold Status for this Product ID.\r\nComing soon...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case "Status":
                    if (this.isLockOrder) return;

                    if (this.lke_TimeSlotID.EditValue == null || Convert.ToInt32(lke_TimeSlotID.EditValue) <= 0)
                    {
                        MessageBox.Show("Please update time slot before confirm !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.lke_TimeSlotID.Focus();
                        this.lke_TimeSlotID.ShowPopup();
                        return;
                    }

                    // Detect this is last row confirm
                    var allRowConfirm = this.listOrderDetail.Count(rd => rd.Status == 2);
                    if (allRowConfirm == this.listOrderDetail.Count() - 1)
                    {
                        // Check input employee for this order before confirmed
                        if (!CheckInputEmployee(this.textEditOrderID.Text))
                        {
                            var confirmMsg = MessageBox.Show("This order not yet enter employee, please re-check it!", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (confirmMsg.Equals(DialogResult.Yes))
                            {
                                this.dockPanelEmployees.Show();
                                return;
                            }
                        }
                    }
                    int roDetailID = Convert.ToInt32(this.gridViewOrderDetail.GetFocusedRowCellValue("ReceivingOrderDetailID"));
                    // Check Qty sync with wareNavi is equal with qty RODetail send
                    int qtyDiff = Convert.ToInt32(FileProcess.LoadTable("STCheckQTYSyncBeforeConfirm @RODetailID=" + roDetailID).Rows[0]["DifferenceQty"]);
                    if (qtyDiff > 0)
                    {
                        XtraMessageBox.Show("Qty booking and Qty actual is invalid! Please check it before confirm", "TWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string userName = Convert.ToString(gridViewOrderDetail.GetRowCellValue(gridViewOrderDetail.FocusedRowHandle, gridViewOrderDetail.Columns["UserName"]));
                    byte status = Convert.ToByte(gridViewOrderDetail.GetRowCellValue(gridViewOrderDetail.FocusedRowHandle, gridViewOrderDetail.Columns["Status"]));
                    if (status == 1)
                        if (XtraMessageBox.Show("Are you sure to confirm this Receiving Product ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            TransactionDAC trans = new TransactionDAC();
                            var rODetail = this.gridViewOrderDetail.GetRow(this.gridViewOrderDetail.FocusedRowHandle) as ReceivingOrderDetails;
                            trans.STConfirmOne((int)rODetail.TransactionID, 1, this.userName);
                            gridViewOrderDetail.SetFocusedRowCellValue(gridViewOrderDetail.Columns["Status"], 2);
                            gridViewOrderDetail.SetFocusedRowCellValue(gridViewOrderDetail.Columns["UserName"], userName + "-" + AppSetting.CurrentUser.LoginName);
                            gridViewOrderDetail.SetFocusedRowCellValue(gridViewOrderDetail.Columns["ConfirmedTime"], DateTime.Now);
                        }
                    break;

                // Display Set location form
                case "UserName":
                    this.rpihpl_ReceivingOrderDetail_DoubleClick(sender, e);
                    break;

                // Display product info
                case "ProductNumber":
                    this.rpihpl_ProductInfo_DoubleClick(sender, e);
                    break;

                // Display pallet info
                case "Plts":
                    this.PalletInfo();
                    break;

                // Display dispatching details
                case "TotalPackages":
                    this.rpihpl_DispatchInfo_Click(sender, e);
                    break;
            }

        }

        private void lkeDockNumber_EditValueChanged(object sender, EventArgs e)
        {
            if (this.lkeDockNumber.EditValue == null) return;
            if (this.lkeDockNumber.IsModified)
            {
                int receivingOrderID = Convert.ToInt32(this.textEditOrderID.Tag);
                this.receivingDa.ExecuteNoQuery("Update ReceivingOrders Set DockDoorID=" + this.lkeDockNumber.EditValue + " Where ReceivingOrderID=" + receivingOrderID);
            }
        }

        private void lookUpEditCustomerID_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            try
            {
                this.lookUpEditCustomerID.EditValue = e.Value;
                int customerID = Convert.ToInt32(lookUpEditCustomerID.EditValue);
                string customerName = Convert.ToString(lookUpEditCustomerID.Properties.GetDataSourceValue("CustomerName", lookUpEditCustomerID.ItemIndex));
                textEditCustomerName.Text = customerName;
                InitLookupServices(customerID);
                this.Text = textEditOrderID.Text.Trim() + " " + lookUpEditCustomerID.Text.Trim();

                // Load Customer requirements
                Customers customerSelected = AppSetting.CustomerList.Where(x => x.CustomerID == customerID).FirstOrDefault();
                int customerMainID = 0;
                if (customerSelected != null) customerMainID = (int)customerSelected.CustomerMainID;
                customerMainIDISO = customerMainID;
                // load supplier
                this.LoadCustomerSupplierData(customerMainID, "");
                // Check new customer to order
                ReceivingOrders newOrderCustomer = this.receivingDa.Select(x => x.CustomerID == customerSelected.CustomerID).OrderByDescending(r => r.ReceivingOrderID).FirstOrDefault();

                // If current customer is new customer then set message is "Khach hang moi"
                if (newOrderCustomer.ReceivingOrderDate == null)
                {
                    this.memoEditTruckAndDetail.Text = "!!!!!!!!!!!   Khach hang moi   !!!!!!!!!!!";
                }
                else
                {
                    // Check customer has most transaction recently, if time transaction more than 3 month then show message
                    TimeSpan timeLimited = DateTime.Now.Subtract((DateTime)newOrderCustomer.ReceivingOrderDate);
                    if (timeLimited.Days >= 92)
                    {
                        // Show warning message
                        System.Text.StringBuilder msgContent = new System.Text.StringBuilder();
                        msgContent.Append("This customer had not any transaction last 3 months ");
                        msgContent.Append(Environment.NewLine);
                        msgContent.Append(Environment.NewLine);
                        msgContent.Append("");
                        msgContent.Append(Environment.NewLine);
                        msgContent.Append(Environment.NewLine);
                        msgContent.Append("Please press OK to close this message and do your work as normal!");
                        MessageBox.Show(this, msgContent.ToString(), "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        // Set truck and detail content
                        this.memoEditTruckAndDetail.Text = "!!!!!!!!!!!   Bao PKD lam HD moi   !!!!!!!!!!!";
                    }
                    else
                    {
                        if (String.IsNullOrEmpty(this.memoEditTruckAndDetail.Text))
                        {
                            this.memoEditTruckAndDetail.Text = string.Empty;
                        }
                    }
                }

                frm_MSS_CustomerRequirementView frmCustomerRequirement = new frm_MSS_CustomerRequirementView(customerMainID);
                if (!frmCustomerRequirement.Enabled) return;
                if (frmCustomerRequirement.IsDisplay)
                {
                    frmCustomerRequirement.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                Wait.Close();
                textEditCustomerName.Text = "";
            }
            Wait.Close();
        }

        private void gridControlOrderDetail_Click(object sender, EventArgs e)
        {

        }

        private void btnLabelDecal_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (this.gridViewOrderDetail.RowCount < 0) return;
            DataProcess<ST_WMS_LoadAllPalletsByReceivingOrderID_Result> palletDA = new DataProcess<ST_WMS_LoadAllPalletsByReceivingOrderID_Result>();
            DataProcess<STLabel1Label_Result> label = new DataProcess<STLabel1Label_Result>();
            IList<STLabel1Label_Result> rerportSource = new List<STLabel1Label_Result>();
            string customerType = AppSetting.CustomerList.Where(cus => cus.CustomerNumber == this.lookUpEditCustomerID.Text).FirstOrDefault().CustomerType;
            foreach (var roDetail in this.listOrderDetail)
            {
                var palletList = palletDA.Executing("ST_WMS_LoadAllPalletsByReceivingOrderID @ReceivingOrderID={0}", roDetail.ReceivingOrderDetailID);
                foreach (var pallet in palletList)
                {
                    for (int i = 0; i < pallet.OriginalQuantity; i++)
                    {
                        if (customerType == CustomerTypeEnum.PCS)// CustomerTypeEnum.PCS)
                        {
                            var source = label.Executing("STLabel1Label @PalletID={0}", pallet.PalletID).ToList();
                            rerportSource.Add(source.FirstOrDefault());
                        }
                        else
                        {
                            var source = label.Executing("STLabel1Label @PalletID={0}", pallet.PalletID).ToList();
                            rerportSource.Add(source.FirstOrDefault());
                        }
                    }
                }
            }

            if (customerType == CustomerTypeEnum.PCS)// CustomerTypeEnum.PCS)
            {
                rptLabel_Barcode_pcs lb = new rptLabel_Barcode_pcs();
                lb.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
                lb.Parameters["parameter1"].Value = 1;
                lb.DataSource = rerportSource;
                lb.RequestParameters = false;
                lb.xrBarCodeID2.Text = "*" + rerportSource.Select(obj => obj.PalletID_Barcode).FirstOrDefault() + "*";
                ReportPrintToolWMS printTool = new ReportPrintToolWMS(lb);
                printTool.AutoShowParametersPanel = false;
                printTool.ShowPreviewDialog();
            }
            else
            {
                rptLabelDecal lb = new rptLabelDecal();
                lb.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
                lb.Parameters["parameter1"].Value = 1;
                lb.xrLabelRO.Text = this.textEditOrderID.Text;
                lb.RequestParameters = false;
                lb.DataSource = rerportSource;
                ReportPrintToolWMS printTool = new ReportPrintToolWMS(lb);
                printTool.AutoShowParametersPanel = false;
                printTool.ShowPreviewDialog();
            }
        }

        private void btnHoldProcess_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(this.textEditOrderID.Text)) return;
            int receivingOrderID = Convert.ToInt32(this.textEditOrderID.Tag);
            DialogResult dlResult = DialogResult.No;
            int palletStatusChangeID = 0;
            dlResult = MessageBox.Show("Are You Sure to Create Pallet Status Change for this Order ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlResult.Equals(DialogResult.No)) return;
            var r = FileProcess.LoadTable("STPalletStatusChangeRO " + receivingOrderID + ",'" + AppSetting.CurrentUser.LoginName + "'");
            if (r == null)
                MessageBox.Show("Error Create New Pallet Status Change Order !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                palletStatusChangeID = Convert.ToInt32(r.Rows[0]["PalletStatusChangeID"]);
                if (palletStatusChangeID == 0)
                    MessageBox.Show("No remaining Stock - Error Create New Pallet Status Change Order !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    frm_WM_PalletStatusChange frm = new frm_WM_PalletStatusChange();
                    frm.Show();
                    frm.BringToFront();
                }
            }

        }
        private void rpi_hpl_ChangedProductPackage_DoubleClick(object sender, EventArgs e)
        {
            if (this.isLockOrder) return;
            string package = Convert.ToString(this.gridViewOrderDetail.GetFocusedRowCellValue("Packages"));
            int proID = Convert.ToInt32(this.gridViewOrderDetail.GetFocusedRowCellValue("ProductID"));
            if (string.IsNullOrEmpty(package)) return;
            frm_WM_UpdateProductPackage frmChange = new frm_WM_UpdateProductPackage(proID, package);
            frmChange.ShowDialog();
            this.gridViewOrderDetail.SetFocusedRowCellValue("Packages", frmChange.NewPackage);
            this.gridViewOrderDetail.SetFocusedRowCellValue("Pcs", frmChange.NewPcs);
        }

        /// <summary>
        /// Check this order has input employee?
        /// True: has input
        /// False: not input
        /// </summary>
        /// <returns>bool</returns>
        private static bool CheckInputEmployee(string orderNumber)
        {
            bool hasInput = false;
            var tbInfo = FileProcess.LoadTable("select Count(*) as Count from EmployeeWorkings where OrderNumber='" + orderNumber + "'");
            var count = Convert.ToInt32(tbInfo.Rows[0]["Count"]);
            if (count > 0) hasInput = true;
            return hasInput;
        }

        private void bbuttonEDICheck_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int receivingOrderID = Convert.ToInt32(this.textEditOrderID.Tag);
            if (receivingOrderID <= 0) return;

            frm_WM_EDIOrder_CheckRO frm = new frm_WM_EDIOrder_CheckRO(receivingOrderID);
            frm.ShowDialog();
        }

        private void btnPalletDetail_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int flag = 0;
            if (boflag) flag = 1;

            int customerID = (int)lookUpEditCustomerID.EditValue;
            string customerType = lookUpEditCustomerID.Properties.GetDataSourceValue("CustomerType", lookUpEditCustomerID.ItemIndex).ToString();

            if (customerType.Equals(CustomerTypeEnum.RANDOM_WEIGHT))
            {
                DataProcess<object> customerByOvertimeCheckingTime = new DataProcess<object>();
                int result = customerByOvertimeCheckingTime.ExecuteNoQuery("STReceivingOrderPalletCartonWeightUpdate @ReceivingOrderID= {0}", (int)textEditOrderID.Tag);
            }
            rptPalletCartonDetail rp = new rptPalletCartonDetail();
            var STReceivingNoteByCartonList = FileProcess.LoadTable("STReceivingNoteByCarton @varReceivingOrderID=" + (int)textEditOrderID.Tag + ", @Flag=" + flag);
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

        private void textEditReceivingOrderProgress_Leave(object sender, EventArgs e)
        {
            if (isUpdate)
            {
                UpdateRO();
            }
        }

        private void memoEditTruckAndDetail_Leave(object sender, EventArgs e)
        {
            this.lke_TimeSlotID.Focus();
            this.lke_TimeSlotID.ShowPopup();
        }

        private void lke_TimeSlotID_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.KeyCode.Equals(Keys.Tab)) return;
            btn_WM_NewAllProduct.ItemAppearance.Normal.BackColor = Color.FromArgb(153, 180, 209);
            btn_WM_NewAllProduct.Links[0].Focus();
        }

        private void lookUpEditCustomerID_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.KeyCode.Equals(Keys.Tab)) return;
            this.memoEditTruckAndDetail.Focus();
        }

        private void btnDispatchingClientAssignment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_WM_DispatchingByClientAssignment frm = new frm_WM_DispatchingByClientAssignment(Convert.ToInt32(this.lookUpEditCustomerID.EditValue), true, (int)textEditOrderID.Tag);
            frm.Show();
            frm.BringToFront();
        }

        private void textEditCustomerOrderNumber2_EditValueChanged(object sender, EventArgs e)
        {
            if (isUpdate && this.textEditCustomerOrderNumber2.IsModified)
            {
                UpdateRO();
            }
        }

        private void bbuttonUpdateProDate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataProcess<object> proDate = new DataProcess<object>();
            proDate.ExecuteNoQuery("STReceivingOrderProDateAutoUpdate " + (int)textEditOrderID.Tag + ",'" + AppSetting.CurrentUser.LoginName + "'");
            LoadDataDetail((int)textEditOrderID.Tag);
        }

        private void rpi_chk_IsWeighting_CheckedChanged(object sender, EventArgs e)
        {
            ReceivingOrderDetails rODetail = (ReceivingOrderDetails)gridViewOrderDetail.GetFocusedRow();
            var chk = (CheckEdit)sender;
            string roDetailID = rODetail.ReceivingOrderDetailID.ToString();
            DataProcess<OtherServiceDetails> otherServiceDetailsDA = new DataProcess<OtherServiceDetails>();
            if (this.otherServiceDetails != null && this.otherServiceDetails.OtherServiceID == 0)
            {
                this.otherServiceDetails = otherServiceDetailsDA.Select(x => x.OrderNumber == this.textEditOrderID.Text).FirstOrDefault();
            }
            if (chk.Checked)
            {
                if (!this.listRoDetailIsWeighting.Contains(roDetailID))
                {
                    this.listRoDetailIsWeighting.Add(roDetailID);
                }
                if (otherServiceDetails == null)
                {
                    this.AddNewService();
                    this.AddNewServiceDetail();
                }
                else
                {
                    this.otherServiceDetails.Quantity += Convert.ToDecimal(this.gridViewOrderDetail.GetRowCellValue(gridViewOrderDetail.FocusedRowHandle, "WeightPerPackage"));
                    otherServiceDetailsDA.Update(this.otherServiceDetails);
                }
            }
            else
            {
                if (this.listRoDetailIsWeighting.Contains(roDetailID))
                {
                    this.listRoDetailIsWeighting.Remove(roDetailID);
                }
                if (otherServiceDetails != null)
                {
                    this.otherServiceDetails.Quantity -= Convert.ToDecimal(this.gridViewOrderDetail.GetRowCellValue(gridViewOrderDetail.FocusedRowHandle, "WeightPerPackage"));
                    otherServiceDetailsDA.Update(this.otherServiceDetails);
                }
            }
            string roDetailIDs = string.Join(",", this.listRoDetailIsWeighting.ToArray());
            LoadDataIsWeighting(roDetailIDs);

            rODetail.IsWeighting = chk.Checked;
            this.recevingOrderDetailDA.Update(rODetail);
        }

        private void LoadDataIsWeighting(string roDetailIDs)
        {
            try
            {
                if (listRoDetailIsWeighting.Count <= 0)
                {
                    gridControlPallet.DataSource = null;
                    gridViewPallet.RefreshData();
                    return;
                }
                DataProcess<ST_WMS_LoadAllPalletsIsWeighting_Result> palletsDA = new DA.DataProcess<DA.ST_WMS_LoadAllPalletsIsWeighting_Result>();
                var dataSource = palletsDA.Executing("ST_WMS_LoadAllPalletsIsWeighting @RODetailIDs={0}", roDetailIDs);
                gridControlPallet.DataSource = dataSource;
                gridViewPallet.RefreshData();
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
            }
        }

        private void gridViewPallet_RowClick(object sender, RowClickEventArgs e)
        {
            if (gridViewPallet.FocusedRowHandle < 0) return;
            int palletID = Convert.ToInt32(this.gridViewPallet.GetFocusedRowCellValue("PalletID"));
            this.grdPalletCartonDetails.DataSource = FileProcess.LoadTable("STCartonDetails @OrderID=" + palletID + ",@Type=1");
        }

        private void rpi_btn_PalletCarton_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            log.Debug("==> ROSetLocations sự kiện rpi_hle_PalletCartonDetails_DoubleClick");
            if (gridViewPallet.FocusedRowHandle < 0) return;
            int palletID = Convert.ToInt32(this.gridViewPallet.GetFocusedRowCellValue("PalletID"));
            var countPalletCartonInsert = FileProcess.LoadTable("SELECT COUNT(PalletCartons.PalletCartonID) as Count " +
                " FROM  PalletCartons " +
                " INNER JOIN Pallets ON PalletCartons.PalletID = Pallets.PalletID " +
                " WHERE(Pallets.PalletID = " + palletID + ")");
            int count = Convert.ToInt32(countPalletCartonInsert.Rows[0]["Count"]);
            int roDetailID = Convert.ToInt32(this.gridViewPallet.GetFocusedRowCellValue("ReceivingOrderDetailID"));
            var currentDoDetails = this.recevingOrderDetailDA.Select(p => p.ReceivingOrderDetailID == roDetailID).FirstOrDefault();
            if (currentDoDetails == null) return;
            short quantity = (short)this.gridViewPallet.GetRowCellValue(this.gridViewPallet.FocusedRowHandle, "OriginalQuantity");
            if (currentDoDetails.Status != 2)
            {
                if (count <= 0)
                {
                    var confirmMsg = MessageBox.Show("Do you want to create new [" + quantity + "] cartons ID?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (confirmMsg.Equals(DialogResult.Yes))
                    {
                        DataProcess<object> insertPalletCarton = new DataProcess<object>();
                        int insertResult = insertPalletCarton.ExecuteNoQuery("STPalletCartonWeightInsert @PalletID={0},@OriginalQuantity={1},@Status={2},@CreatedBy={3}",
                            palletID, quantity, currentDoDetails.Status, AppSetting.CurrentUser.LoginName);
                    }
                }
            }


            int totalOriginalQuantity = Convert.ToInt32(this.gridColumnOriginalQuantity.SummaryItem.SummaryValue);
            DataProcess<Products> obj_ProductDA = new DataProcess<Products>();
            var intProductId = Convert.ToInt32(this.gridViewOrderDetail.GetFocusedRowCellValue("ProductID"));
            var objProduct = obj_ProductDA.Select(x => x.ProductID == intProductId).FirstOrDefault();
            decimal net = objProduct.WeightPerPackage;
            decimal? gross = objProduct.GrossWeightPerPackage;
            frm_WM_PalletCartons palletCarton = new frm_WM_PalletCartons(palletID, currentDoDetails.Status,
                quantity, currentDoDetails.PackagingWeight, currentDoDetails.RejectPercentage, currentDoDetails.ReceivingOrderDetailID, net, gross);
            if (!palletCarton.Enabled) return;
            palletCarton.ShowDialog();
            this.grdPalletCartonDetails.DataSource = FileProcess.LoadTable("STCartonDetails @OrderID=" + palletID + ",@Type=1");
        }

        private void btnPrintCartonDetails_Click(object sender, EventArgs e)
        {
            PrintCartonDetail(true);
        }

        private void PrintCartonDetail(bool isPreview)
        {
            log.Debug("==> frm_WM_ReceivingOrders chạy hàm PrintCartonDetail");
            int palletID = Convert.ToInt32(this.gridViewPallet.GetFocusedRowCellValue("PalletID"));
            rptInlabel lb = new rptInlabel();
            lb.DataSource = multilabel.Executing("STLabelPalletCartonWeight @PalletID={0}", palletID);
            IList<STLabelPalletCartonWeight> getCartonIDBarcode = (IList<STLabelPalletCartonWeight>)lb.DataSource;
            lb.bcCartonID.Text = getCartonIDBarcode.Select(obj => obj.CartonID.ToString()).FirstOrDefault();
            lb.RequestParameters = false;
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

        private void AddNewService()
        {
            try
            {
                DataProcess<OtherService> serviceDA = new DataProcess<OtherService>();
                OtherService service = GetOtherService();
                serviceDA.Insert(service);
                this._currentService.OtherServiceID = service.OtherServiceID;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private OtherService GetOtherService()
        {
            OtherService service = new OtherService();
            service.ServiceDate = DateTime.Now;
            service.ServiceRemark = memoEditTruckAndDetail.Text.Trim();
            service.Status = 0;
            service.LockStatus = false;
            service.CreatedBy = AppSetting.CurrentUser.LoginName;
            service.CreatedTime = DateTime.Now;
            service.CustomerID = Convert.ToInt32(lookUpEditCustomerID.EditValue);
            service.CustomerRep = textEditInernalRemark.Text.Trim();
            service.EmployeeID = AppSetting.CurrentUser.EmployeeID;
            service.ConfirmedBy = AppSetting.CurrentUser.LoginName;
            service.ConfirmedTime = DateTime.Now;
            return service;
        }

        private void AddNewServiceDetail()
        {
            try
            {
                DataProcess<ServicesDefinition> servicesDefinitionDA = new DataProcess<ServicesDefinition>();
                ServicesDefinition servicesDefinition = servicesDefinitionDA.Select(x => x.ServiceNumber == "MCT").FirstOrDefault();

                OtherServiceDetails serviceDetail = new OtherServiceDetails();
                serviceDetail.OtherServiceDetailID = 0;
                serviceDetail.ServiceID = servicesDefinition.ServiceID;
                serviceDetail.OtherServiceID = this._currentService.OtherServiceID;
                serviceDetail.OrderNumber = this.textEditOrderID.Text;
                serviceDetail.Quantity = Convert.ToDecimal(this.gridViewOrderDetail.GetRowCellValue(gridViewOrderDetail.FocusedRowHandle, "WeightPerPackage"));
                serviceDetail.Invoiced = false;
                serviceDetail.Manual = Convert.ToBoolean(0);
                serviceDetail.CreatedBy = AppSetting.CurrentUser.LoginName;
                serviceDetail.CreatedTime = DateTime.Now;
                serviceDetail.Description = Convert.ToString("Manual-" + AppSetting.CurrentUser.LoginName + "-" + DateTime.Now.ToString("dd/MM/yyyy"));
                if (serviceDetail.ServiceID <= 0) return;

                DataProcess<OtherServiceDetails> detailDA = new DataProcess<OtherServiceDetails>();
                detailDA.Insert(serviceDetail);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSyncNavi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
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

            int resultInsert = this.receivingDa.ExecuteNoQuery("STSendROToNavi @ROID={0}", receivingOrderID);
            // Call API to post 
            APIProcess api = new APIProcess();
            string url = ConfigurationManager.AppSettings["StoragePlanData_Navi"];
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
            string orderType = "RO";
            int customerID = this.lookUpEditCustomerID.EditValue == null ? -1 : (int)this.lookUpEditCustomerID.EditValue;
            if (this.viewNotes == null)
            {
                this.viewNotes = new urc_WM_Notes(orderType, roID, customerID);
                this.viewNotes.CustomerNumber = this.lookUpEditCustomerID.GetColumnValue("CustomerNumber").ToString();
                this.viewNotes.NoteDescription = this.memoEditTruckAndDetail.Text;
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
            string orderType = "RO";
            int customerID = this.lookUpEditCustomerID.EditValue == null ? -1 : (int)this.lookUpEditCustomerID.EditValue;
            this.viewNotes.CustomerNumber = this.lookUpEditCustomerID.GetColumnValue("CustomerNumber").ToString();
            this.viewNotes.NoteDescription = this.textEditVehicleNumber.Text + " | " + this.memoEditTruckAndDetail.Text;
            this.viewNotes.VehicleNumber = this.textEditVehicleNumber.Text;
            this.viewNotes.LoadData(orderType, roID, customerID);
            this.viewNotes.Update();
            this.viewNotes.Refresh();
        }

        private void lkeWorkType_EditValueChanged(object sender, EventArgs e)
        {
            if (this.isUpdate && this.lkeWorkType.IsModified)
            {
                this.UpdateRO();
            }
        }
    }

}
