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
using UI.ReportFile;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using UI.WarehouseManagement;
using UI.MasterSystemSetup;
using UI.Management;

namespace UI.ReportForm
{
    public partial class frm_BR_OtherServices : frmBaseForm
    {
        private DataProcess<ST_WMS_LoadOtherServices_Result> _otherServiceDA;
        private DataProcess<ST_WMS_LoadOtherServiceDetails_Result> _serviceDetailDA;
        private BindingList<ST_WMS_LoadOtherServices_Result> _listServices;
        private BindingList<ST_WMS_LoadOtherServiceDetails_Result> _listDetails;
        private ST_WMS_LoadOtherServices_Result _currentService;
        private OrderTypeEnum orderType = OrderTypeEnum.RO;
        private string orderNumber = string.Empty;
        private int orderID = 0;
        private bool _isAddNew;
        private int _customerIDFind;
        private int _otherServiceIDFind;
        private int _customerID;
        private urc_WM_ServicesWorksRecent RecentWS = null;
        private urc_WM_OutsourcedJobLinked OJLinked = null;
        private urc_WM_BillingContracts Billing = null;
        private frm_WM_TripsManagement frmTrip = null;
        private Dictionary<int, string> traceOrderNumber = null;
        public frm_BR_OtherServices()
        {
            InitializeComponent();
            this._currentService = new ST_WMS_LoadOtherServices_Result();
            this._listServices = new BindingList<ST_WMS_LoadOtherServices_Result>();
            this._listDetails = new BindingList<ST_WMS_LoadOtherServiceDetails_Result>();
            this._otherServiceDA = new DataProcess<ST_WMS_LoadOtherServices_Result>();
            this._serviceDetailDA = new DataProcess<ST_WMS_LoadOtherServiceDetails_Result>();
            this._isAddNew = false;
            this._customerIDFind = -1;
            this._otherServiceIDFind = -1;
        }

        public frm_BR_OtherServices(int otherServiceFiID)
        {
            InitializeComponent();
            this._currentService = new ST_WMS_LoadOtherServices_Result();
            this._listServices = new BindingList<ST_WMS_LoadOtherServices_Result>();
            this._listDetails = new BindingList<ST_WMS_LoadOtherServiceDetails_Result>();
            this._otherServiceDA = new DataProcess<ST_WMS_LoadOtherServices_Result>();
            this._serviceDetailDA = new DataProcess<ST_WMS_LoadOtherServiceDetails_Result>();
            this._isAddNew = false;
            this._customerIDFind = -1;
            this._otherServiceIDFind = otherServiceFiID;
        }

        public frm_BR_OtherServices(OrderTypeEnum orderType, int orderID, string orderNumber, int customerID)
        {
            InitializeComponent();
            this._currentService = new ST_WMS_LoadOtherServices_Result();
            this._listServices = new BindingList<ST_WMS_LoadOtherServices_Result>();
            this._listDetails = new BindingList<ST_WMS_LoadOtherServiceDetails_Result>();
            this._otherServiceDA = new DataProcess<ST_WMS_LoadOtherServices_Result>();
            this._serviceDetailDA = new DataProcess<ST_WMS_LoadOtherServiceDetails_Result>();
            this._isAddNew = false;
            this.orderNumber = orderNumber;
            this.orderID = orderID;
            this._customerIDFind = -1;
            this._otherServiceIDFind = -1;
            this.orderType = orderType;
            this._customerID = customerID;
            this.traceOrderNumber = new Dictionary<int, string>();
            this.traceOrderNumber.Add(customerID, orderNumber);
        }

        public int CustomerIDFind
        {
            get
            {
                return _customerIDFind;
            }

            set
            {
                _customerIDFind = value;
                this.LoadServices();
                this.LoadServiceDetail();
            }
        }

        public int OtherServiceIDFind
        {
            get
            {
                return _otherServiceIDFind;
            }

            set
            {
                _otherServiceIDFind = value;
                this.LoadServices();
                this.LoadServiceDetail();
            }
        }

        private void frm_BR_OtherServices_Load(object sender, EventArgs e)
        {
            InitCustomer();
            InitEmployee();
            LoadServices();
            SetEvents();
            if (!string.IsNullOrEmpty(this.orderNumber))
            {
                this.AssignOtherInfoByOrder();
            }
        }

        /// <summary>
        /// Assign other service info from order info
        /// </summary>
        private void AssignOtherInfoByOrder()
        {
            this._currentService = new ST_WMS_LoadOtherServices_Result();
            switch (this.orderType)
            {
                case OrderTypeEnum.RO:
                    DataProcess<ReceivingOrders> roDA = new DataProcess<ReceivingOrders>();
                    var receivingOrderInfo = roDA.Select(r => r.ReceivingOrderID == this.orderID).FirstOrDefault();

                    // Get receiving order info and assign it for current other service
                    this._currentService.CreatedBy = AppSetting.CurrentUser.LoginName;
                    this._currentService.CreatedTime = DateTime.Now;
                    this._currentService.CustomerID = receivingOrderInfo.CustomerID;
                    this._currentService.EmployeeID = AppSetting.CurrentUser.EmployeeID;
                    this.lkeCustomers.EditValue = receivingOrderInfo.CustomerID;
                    this.lkeEmployee.EditValue = AppSetting.CurrentUser.EmployeeID;
                    this._currentService.CustomerMainID = Convert.ToInt32(this.lkeCustomers.GetColumnValue("CustomerMainID"));
                    this._currentService.CustomerName = Convert.ToString(this.lkeCustomers.GetColumnValue("CustomerName"));
                    this._currentService.CustomerNumber = receivingOrderInfo.CustomerNumber;
                    this._currentService.CustomerRep = receivingOrderInfo.InternalRemark;
                    this._currentService.ServiceDate = Convert.ToDateTime(receivingOrderInfo.ReceivingOrderDate);
                    this._currentService.ServiceRemark = receivingOrderInfo.SpecialRequirement;
                    break;
                case OrderTypeEnum.DO:
                    DataProcess<DispatchingOrders> doDA = new DataProcess<DispatchingOrders>();
                    var dispatchingOrderInfo = doDA.Select(r => r.DispatchingOrderID == this.orderID).FirstOrDefault();

                    // Get dispatching order info and assign it for current other service
                    this._currentService.CreatedBy = AppSetting.CurrentUser.LoginName;
                    this._currentService.CreatedTime = DateTime.Now;
                    this._currentService.EmployeeID = AppSetting.CurrentUser.EmployeeID;
                    this._currentService.CustomerID = dispatchingOrderInfo.CustomerID;
                    this.lkeCustomers.EditValue = dispatchingOrderInfo.CustomerID;
                    this.lkeEmployee.EditValue = AppSetting.CurrentUser.EmployeeID;
                    this._currentService.CustomerMainID = Convert.ToInt32(this.lkeCustomers.GetColumnValue("CustomerMainID"));
                    this._currentService.CustomerName = Convert.ToString(this.lkeCustomers.GetColumnValue("CustomerName"));
                    this._currentService.CustomerNumber = dispatchingOrderInfo.CustomerNumber;
                    this._currentService.CustomerRep = dispatchingOrderInfo.InternalRemark;
                    this._currentService.ServiceDate = Convert.ToDateTime(dispatchingOrderInfo.DispatchingOrderDate);
                    this._currentService.ServiceRemark = dispatchingOrderInfo.SpecialRequirement;
                    break;
                case OrderTypeEnum.TW:
                    DataProcess<Trips> twDA = new DataProcess<Trips>();
                    var tripsInfo = twDA.Select(r => r.TripID == this.orderID).FirstOrDefault();

                    // Get dispatching order info and assign it for current other service
                    this._currentService.CreatedBy = AppSetting.CurrentUser.LoginName;
                    this._currentService.CreatedTime = DateTime.Now;
                    this._currentService.EmployeeID = AppSetting.CurrentUser.EmployeeID;
                    this.lkeEmployee.EditValue = AppSetting.CurrentUser.EmployeeID;
                    this._currentService.CustomerID = Convert.ToInt32(tripsInfo.CustomerID);
                    this.lkeCustomers.EditValue = tripsInfo.CustomerID;
                    this._currentService.CustomerMainID = Convert.ToInt32(this.lkeCustomers.GetColumnValue("CustomerMainID"));
                    this._currentService.CustomerName = Convert.ToString(this.lkeCustomers.GetColumnValue("CustomerName"));
                    this._currentService.CustomerNumber = tripsInfo.CustomerOrderNumber;
                    this._currentService.CustomerRep = tripsInfo.InternalRemark;
                    this._currentService.ServiceDate = Convert.ToDateTime(tripsInfo.TripDate);
                    this._currentService.ServiceRemark = tripsInfo.TripRemark;
                    break;

                case OrderTypeEnum.TB:
                    //DataProcess<Trips> twDA = new DataProcess<Trips>();
                    //var tripsInfo = twDA.Select(r => r.TripID == this.orderID).FirstOrDefault();
                    DataTable bcTr = FileProcess.LoadTable("SELECT TripID, TripNumber, TripDate, TripRemarks FROM BigC_Trips WHERE TripID = " + this.orderID);
                    if (bcTr != null && bcTr.Rows.Count > 0)
                    {
                        var cusID = bcTr.Rows[0][0];

                        // Get BigC_Trip info and assign it for current other service
                        var cusInfo = AppSetting.CustomerListAll.Where(c => c.CustomerID == this._customerID).FirstOrDefault();
                        this._currentService.CreatedBy = AppSetting.CurrentUser.LoginName;
                        this._currentService.CreatedTime = DateTime.Now;
                        this._currentService.EmployeeID = AppSetting.CurrentUser.EmployeeID;
                        this.lkeEmployee.EditValue = AppSetting.CurrentUser.EmployeeID;
                        this._currentService.CustomerID = this._customerID;
                        this.lkeCustomers.EditValue = this._customerID;
                        this._currentService.CustomerMainID = cusInfo.CustomerMainID;
                        this._currentService.CustomerName = cusInfo.CustomerName;
                        this._currentService.CustomerNumber = cusInfo.CustomerNumber;
                        this._currentService.CustomerRep = "";
                        this._currentService.ServiceDate = Convert.ToDateTime(bcTr.Rows[0][2]);
                        this._currentService.ServiceRemark = Convert.ToString(bcTr.Rows[0][3]);

                    }

                    break;

            }
            this.AddNewService();
            this._listDetails[0].OrderNumber = orderNumber;
        }

        private void frm_BR_OtherServices_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("TAB");
            }
        }

        private void SetEvents()
        {
            this.dtNavigatorService.PositionChanged += dtNavigatorService_PositionChanged;

            #region Button Events
            this.btnBilled.CheckedChanged += btnBilled_CheckedChanged;
            this.btnClose.Click += btnClose_Click;
            this.btnDelete.Click += btnDelete_Click;
            this.btnHWByOvertime.Click += btnHWByOvertime_Click;
            this.btnPrintNote.Click += btnPrintNote_Click;
            this.btnViewNote.Click += btnViewNote_Click;
            this.btnNewService.Click += btnNewService_Click;
            this.rpi_btn_Delete.Click += rpi_btn_Delete_Click;
            this.rpi_hpl_OrderNumber.DoubleClick += rpi_hpl_OrderNumber_DoubleClick;
            this.txtServiceID.Click += TxtServiceID_Click;
            #endregion

            #region Value Changed Events
            this.txtCustomerRep.TextChanged += txtCustomerRep_TextChanged;
            this.lkeEmployee.EditValueChanged += lkeEmployee_EditValueChanged;
            this.lkeCustomers.EditValueChanged += lkeCustomers_EditValueChanged;
            this.lkeCustomers.CloseUp += LkeCustomers_CloseUp;
            this.rpi_lke_OrderList.CloseUp += Rpi_lke_OrderList_CloseUp;
            this.dtServiceDate.EditValueChanged += dtServiceDate_EditValueChanged;
            this.mmeRemark.TextChanged += mmeRemark_TextChanged;
            this.rpi_lke_Services.EditValueChanged += rpi_lke_Services_EditValueChanged;
            this.rpi_lke_Services.CloseUp += Rpi_lke_Services_CloseUp;
            #endregion

            #region Lost Focus Events
            this.txtCustomerRep.LostFocus += LostFocusEvent;
            this.mmeRemark.LostFocus += mmeRemark_LostFocus; ;
            this.lkeCustomers.LostFocus += LostFocusEvent;
            this.lkeEmployee.LostFocus += LostFocusEvent;
            #endregion

            #region GridView Events
            this.grvOtherServiceDetail.CellValueChanged += GrvOtherServiceDetail_CellValueChanged;
            #endregion
        }

        private void Rpi_lke_OrderList_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.Value == null) return;
            this.grvOtherServiceDetail.SetFocusedRowCellValue("OrderNumber", e.Value);
        }

        private void LkeCustomers_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.Value == null) return;
            this.LoadOrders(Convert.ToInt32(e.Value));
        }

        private void Rpi_lke_Services_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            SendKeys.Send("{TAB}");
        }

        private void TxtServiceID_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtServiceID.Text)) return;
            int serviceID = Convert.ToInt32(this.txtServiceID.Text);
            frm_WM_MHLWorks form = frm_WM_MHLWorks.Instance;
            form.LoadAllWorksByOtherServiceID(serviceID);
            form.Show();
        }

        #region Load Data
        private void LoadServices()
        {
            if (this._customerIDFind > 0)
            {
                this._listServices = new BindingList<ST_WMS_LoadOtherServices_Result>(this._otherServiceDA.Executing("ST_WMS_LoadOtherServicesByCustomerID @CustomerID={0}, @StoreID = {1}", this._customerIDFind, AppSetting.StoreID).Where(m => m.CustomerID == this._customerIDFind).ToList());
            }
            else
            {
                if (this._otherServiceIDFind > 0)
                {
                    this._listServices = new BindingList<ST_WMS_LoadOtherServices_Result>(this._otherServiceDA.Executing("ST_WMS_LoadOtherServicesByOtherServiceID @OtherServiceID = {0}", this._otherServiceIDFind).ToList());
                }
                else
                {
                    this._listServices = new BindingList<ST_WMS_LoadOtherServices_Result>(this._otherServiceDA.Executing("ST_WMS_LoadOtherServices @StoreID = {0}", AppSetting.StoreID).ToList());
                }
            }

            if (this._listServices.Count <= 0)
            {
                this._currentService = new ST_WMS_LoadOtherServices_Result();
                this._currentService.ServiceDate = DateTime.Now;
                this._currentService.EmployeeID = AppSetting.CurrentUser.EmployeeID;
                this._listServices.Add(this._currentService);
                this._isAddNew = true;
            }

            this.dtNavigatorService.DataSource = this._listServices;
            this._currentService = this._listServices.Last();
            this.dtNavigatorService.Position = this._listServices.Count;
            InitService();
            BindData();
            LoadServiceDetail();
        }

        private void LoadOrders(int customerID)
        {
            //string quer = "SELECT ReceivingOrderNumber as OrderNumber, ReceivingORderDate as OrderDate, LEFT(SpecialRequirement,30) AS SR " +
            //    " from ReceivingOrders WHERE CustomerID =" + customerID + " and ReceivingOrderDate > Getdate()-30 " +
            //    " UNION ALL " +
            //    " SELECT DispatchingOrderNumber as OrderNumber, DispatchingOrderDate as OrderDate, " +
            //    " Left(SpecialRequirement, 30) AS SR " +
            //    " From DispatchingOrders " +
            //    " WHERE CustomerID = " + customerID + " AND DispatchingOrderDate > Getdate() - 30 Order By OrderDate, OrderNumber";
            this.rpi_lke_OrderList.DataSource = FileProcess.LoadTable("STOtherServiceLinkedOrderList " + customerID);
            this.rpi_lke_OrderList.DisplayMember = "OrderNumber";
            this.rpi_lke_OrderList.ValueMember = "OrderNumber";


            var svDate = this.dtServiceDate.EditValue != null ? this.dtServiceDate.DateTime : this._currentService.ServiceDate;
            DataProcess<STComboServiceContractDetails_Result> serviceDetailDa = new DataProcess<STComboServiceContractDetails_Result>();

            this.rpi_lke_Services.DataSource = serviceDetailDa.Executing("STComboServiceContractDetails @CustomerID = {0}, @ServiceDate = {1}", customerID, svDate);
            this.rpi_lke_Services.ValueMember = "ServiceID";
            this.rpi_lke_Services.DisplayMember = "ServiceNumber";
        }
        private void LoadServiceDetail()
        {
            this._listDetails = new BindingList<ST_WMS_LoadOtherServiceDetails_Result>(this._serviceDetailDA.Executing("ST_WMS_LoadOtherServiceDetails @OtherServiceID = {0}", this._currentService.OtherServiceID).ToList());
            var newServiceDetail = new ST_WMS_LoadOtherServiceDetails_Result();
            if (this.traceOrderNumber != null && this.traceOrderNumber.ContainsKey(this._currentService.CustomerID))
                newServiceDetail.OrderNumber = this.orderNumber;
            this._listDetails.Add(newServiceDetail);
            this.grdOtherServiceDetail.DataSource = this._listDetails;
        }

        private void InitEmployee()
        {
            this.lkeEmployee.Properties.DataSource = AppSetting.EmployessList;
            this.lkeEmployee.Properties.ValueMember = "EmployeeID";
            this.lkeEmployee.Properties.DisplayMember = "FullName";
        }

        private void InitCustomer()
        {
            this.lkeCustomers.Properties.DataSource = AppSetting.CustomerList.Where(a => a.StoreID == AppSetting.StoreID);
            this.lkeCustomers.Properties.ValueMember = "CustomerID";
            this.lkeCustomers.Properties.DisplayMember = "CustomerNumber";
        }

        private void InitService()
        {
            if (this._currentService.CustomerID == 0)
            {
                return;
            }
            var svDate = this._currentService.ServiceDate;
            DataProcess<STComboServiceContractDetails_Result> serviceDetailDa = new DataProcess<STComboServiceContractDetails_Result>();

            this.rpi_lke_Services.DataSource = serviceDetailDa.Executing("STComboServiceContractDetails @CustomerID = {0}, @ServiceDate = {1}", this._currentService.CustomerID, svDate);
            this.rpi_lke_Services.ValueMember = "ServiceID";
            this.rpi_lke_Services.DisplayMember = "ServiceNumber";
        }

        private void BindData()
        {
            this.txtServiceID.Text = this._currentService.BillingID.ToString();
            this.txtBillingID.Text = this._currentService.OtherServiceID.ToString();
            this.txtCreatedBy.Text = this._currentService.CreatedBy;
            this.txtCustomerName.Text = this._currentService.CustomerName;
            this.txtCustomerRep.Text = this._currentService.CustomerRep;
            this.txtStatus.Text = this._currentService.Status.ToString();
            this.dtCreatedTime.EditValue = this._currentService.CreatedTime;
            this.dtServiceDate.EditValue = this._currentService.ServiceDate;
            this.mmeRemark.Text = this._currentService.ServiceRemark;
            this.chkIsAdjust.Checked = this._currentService.isBillingAdjustment;
            this.lkeEmployee.EditValue = this._currentService.EmployeeID;
            this.lkeCustomers.EditValue = this._currentService.CustomerID;
            this.btnBilled.Checked = this._currentService.LockStatus;
            this.txtConfirmedBy.Text = this._currentService.ConfirmedBy;
            this.txtConfirmedTime.EditValue = this._currentService.ConfirmedTime;

            if (this._currentService.BillingID != null)
            {
                this.btnBilled.Enabled = false;
            }
            else
            {
                this.btnBilled.Enabled = true;
                if (this.btnBilled.Checked)
                {
                    this.btnBilled.BackColor = Color.Green;
                }
                else
                {
                    this.btnBilled.BackColor = Color.Transparent;
                }
            }
            if (this._currentService.LockStatus)
            {
                SetEditable(false);
            }
            else
            {
                if (!string.IsNullOrEmpty(this._currentService.ConfirmedBy))
                {
                    SetEditable(false);
                }
                else
                    SetEditable(true);
            }

            if (this.lkeCustomers.EditValue == null) return;
            int customerID = Convert.ToInt32(this.lkeCustomers.EditValue);
            this.LoadOrders(customerID);
        }
        #endregion

        #region Events

        #region Buttons

        private void rpi_btn_Delete_Click(object sender, EventArgs e)
        {
            int detailID = Convert.ToInt32(this.grvOtherServiceDetail.GetFocusedRowCellValue("OtherServiceDetailID"));
            DataProcess<object> detailDA = new DataProcess<object>();

            if (Convert.ToInt32(this.grvOtherServiceDetail.GetFocusedRowCellValue("ServiceID")) == 15) //PRC
            {
                DialogResult result = XtraMessageBox.Show("This is PRC Service. Are you sure to delete this ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {

                    int qryResult = detailDA.ExecuteNoQuery("STElectricityConsumptionUpdate @OtherServiceDetailID = {0}", detailID);
                    LoadServiceDetail();
                }
                else
                {
                    return;
                }
            }
            else
            {
                DialogResult result = XtraMessageBox.Show("Are you sure to delete this service?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {

                    int qryResult = detailDA.ExecuteNoQuery("STBillingByOvertimeDetailDelete @OtherServiceDetailID = {0}", detailID);
                    LoadServiceDetail();
                }
                else
                {
                    return;
                }
            }

            string deleteDescription = Convert.ToString(this.grvOtherServiceDetail.GetFocusedRowCellValue("ServiceName")) + " - " + Convert.ToDecimal(this.grvOtherServiceDetail.GetFocusedRowCellValue("Quantity"));

            DataProcess<ProductChanging> prdChangingDA = new DataProcess<ProductChanging>();
            ProductChanging changing = new ProductChanging();
            changing.ChangeBy = AppSetting.CurrentUser.LoginName;
            changing.ChangeDate = DateTime.Now;
            changing.ChangeDescription = "Service: " + this._currentService.CustomerNumber + " - Delete: " + deleteDescription;
            changing.ReferenceID = this._currentService.CustomerID;
            prdChangingDA.Insert(changing);
        }

        private void btnNewService_Click(object sender, EventArgs e)
        {
            ResetDataForInsert();
        }

        private void btnViewNote_Click(object sender, EventArgs e)
        {
            DataProcess<ST_WMS_LoadOtherServiceReport_Result> reportDA = new DataProcess<ST_WMS_LoadOtherServiceReport_Result>();

            rptOtherService rpt = new rptOtherService();
            rpt.DataSource = reportDA.Executing("ST_WMS_LoadOtherServiceReport @OtherService = {0}", this._currentService.OtherServiceID);
            ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
            tool.ShowPreview();
        }

        private void btnPrintNote_Click(object sender, EventArgs e)
        {
            DataProcess<ST_WMS_LoadOtherServiceReport_Result> reportDA = new DataProcess<ST_WMS_LoadOtherServiceReport_Result>();

            rptOtherService rpt = new rptOtherService();
            rpt.DataSource = reportDA.Executing("ST_WMS_LoadOtherServiceReport @OtherService = {0}", this._currentService.OtherServiceID);
            ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
            tool.Print();
        }

        private void btnHWByOvertime_Click(object sender, EventArgs e)
        {
            DataProcess<STBillingByOvertimeDetailReport_Result> reportDA = new DataProcess<STBillingByOvertimeDetailReport_Result>();

            rptOtherServiceHWByOvertimes rpt = new rptOtherServiceHWByOvertimes(-1);
            rpt.DataSource = reportDA.Executing("STBillingByOvertimeDetailReport @OtherServiceID = {0}", this._currentService.OtherServiceID);
            ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
            tool.ShowPreview();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtBillingID.Text))
            {
                return;
            }

            if (this.btnBilled.Checked)
            {
                XtraMessageBox.Show("You can't delete !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this.grvOtherServiceDetail.RowCount <= 1)
            {

                DataProcess<object> db = new DataProcess<object>();

                int result = db.ExecuteNoQuery("Delete From OtherService Where OtherServiceID = {0}", this._currentService.OtherServiceID);
                XtraMessageBox.Show("Deleted!", "TPWMS");

                if (result != -2)
                {
                    LoadServices();
                }
                else
                {
                    XtraMessageBox.Show("Unexpected Error !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                XtraMessageBox.Show("You must delete all details before delete this service !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCreateNew_Click(object sender, EventArgs e)
        {
            if (this.lkeCustomers.EditValue == null || this.grvOtherServiceDetail.RowCount > 0)
            {
                XtraMessageBox.Show("Please create new Service and Select Customer !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //   DoCmd.OpenForm "frmOtherServiceCreateFromOrders", acNormal
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnBilled_CheckedChanged(object sender, EventArgs e)
        {
            if (btnBilled.Checked)
            {
                this._currentService.LockStatus = true;
                SetEditable(false);
            }
            else
            {
                this._currentService.LockStatus = false;
                SetEditable(true);
            }

            UpdateService();
        }

        private void rpi_hpl_OrderNumber_DoubleClick(object sender, EventArgs e)
        {
            string orderNumber = Convert.ToString(this.grvOtherServiceDetail.GetFocusedRowCellValue("OrderNumber"));
            if (string.IsNullOrEmpty(orderNumber)) return;
            string orderType = Convert.ToString(orderNumber.Split('-')[0]);
            int orderID = Convert.ToInt32(orderNumber.Split('-')[1]);
            switch (orderType)
            {
                case "DO":
                    frm_WM_DispatchingOrders dispatchingOrder = frm_WM_DispatchingOrders.GetInstance(orderID);
                    if (dispatchingOrder.Visible)
                    {
                        dispatchingOrder.ReloadData();
                    }
                    dispatchingOrder.Show();
                    dispatchingOrder.WindowState = FormWindowState.Maximized;
                    dispatchingOrder.BringToFront();
                    break;
                case "RO":
                    frm_WM_ReceivingOrders receivingOrder = frm_WM_ReceivingOrders.Instance;
                    receivingOrder.ReceivingOrderIDFind = orderID;
                    receivingOrder.Show();
                    receivingOrder.WindowState = FormWindowState.Maximized;
                    receivingOrder.BringToFront();
                    break;
                case "PC":
                    frm_M_ProductCheckingByRequest productChecking1 = new frm_M_ProductCheckingByRequest();
                    productChecking1.ProductCheckingIDFind = orderID;
                    productChecking1.Show();
                    productChecking1.WindowState = FormWindowState.Maximized;
                    productChecking1.BringToFront();
                    break;
                case "TW":
                    if (this.frmTrip == null)
                    {
                        this.frmTrip = new frm_WM_TripsManagement(orderID);
                    }
                    else
                    {
                        this.frmTrip.ReloadData(orderID);
                    }
                    this.frmTrip.Show();
                    this.frmTrip.WindowState = FormWindowState.Maximized;
                    this.frmTrip.BringToFront();
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region ValueChanged
        private void lkeCustomers_EditValueChanged(object sender, EventArgs e)
        {
            if (this.lkeCustomers.EditValue == null || Convert.ToInt32(this.lkeCustomers.EditValue) == 0) return;
            this._currentService.CustomerID = Convert.ToInt32(this.lkeCustomers.EditValue);
            this.txtCustomerName.Text = Convert.ToString(this.lkeCustomers.GetColumnValue("CustomerName"));
        }

        private void mmeRemark_TextChanged(object sender, EventArgs e)
        {
            if (this.mmeRemark.IsModified)
            {
                this._otherServiceDA.ExecuteNoQuery("Update otherService set ServiceRemark=N'" + this.mmeRemark.Text
                    + "' Where otherServiceID=" + this._currentService.OtherServiceID);
                this._currentService.ServiceRemark = this.mmeRemark.Text;
            }
        }

        private void dtServiceDate_EditValueChanged(object sender, EventArgs e)
        {
            this._currentService.ServiceDate = this.dtServiceDate.DateTime;
            if (this.dtServiceDate.IsModified)
            {
                UpdateService();
            }
        }

        private void lkeEmployee_EditValueChanged(object sender, EventArgs e)
        {
            this._currentService.EmployeeID = Convert.ToInt32(this.lkeEmployee.EditValue);
        }

        private void txtCustomerRep_TextChanged(object sender, EventArgs e)
        {
            this._currentService.CustomerRep = this.txtCustomerRep.Text;
        }

        private void rpi_lke_Services_EditValueChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.LookUpEdit editor = (sender as DevExpress.XtraEditors.LookUpEdit);
            STComboServiceContractDetails_Result row = editor.Properties.GetDataSourceRowByKeyValue(editor.EditValue) as STComboServiceContractDetails_Result;
            if (row != null)
            {
                string serviceName = row.ServiceName;
                string measure = row.Measure;
                string serviceNumber = row.ServiceNumber;
                this.grvOtherServiceDetail.SetFocusedRowCellValue("ServiceName", serviceName);
                this.grvOtherServiceDetail.SetFocusedRowCellValue("Measure", measure);
                this.grvOtherServiceDetail.SetFocusedRowCellValue("ServiceNumber", row.ServiceID);
            }
        }
        #endregion

        #region Lost Focus
        private void LostFocusEvent(object sender, EventArgs e)
        {
            if (!this._isAddNew)
            {
                UpdateService();
            }
        }

        private void mmeRemark_LostFocus(object sender, EventArgs e)
        {
            if (this._isAddNew)
            {
                this.AddNewService();
            }
        }
        #endregion

        private void dtNavigatorService_PositionChanged(object sender, EventArgs e)
        {
            this._currentService = this._listServices[this.dtNavigatorService.Position];
            InitService();
            if (!this._isAddNew)
            {
                LoadServiceDetail();
            }
            else
            {
                this.grdOtherServiceDetail.DataSource = null;
                this._currentService.CreatedBy = AppSetting.CurrentUser.LoginName;
                this._currentService.ServiceDate = DateTime.Now;
                this._currentService.CreatedTime = DateTime.Now;
                this._currentService.EmployeeID = AppSetting.CurrentUser.EmployeeID;
            }
            BindData();
        }

        private void GrvOtherServiceDetail_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle < 0) return;
            switch (e.Column.FieldName)
            {
                case "Quantity":
                    int serviceID = Convert.ToInt32(this.grvOtherServiceDetail.GetFocusedRowCellValue("ServiceID"));
                    if (serviceID <= 0) return;
                    this.grvOtherServiceDetail.SetFocusedRowCellValue("CreatedBy", AppSetting.CurrentUser.LoginName);
                    this.grvOtherServiceDetail.SetFocusedRowCellValue("CreatedTime", DateTime.Now);
                    //  int lastRowHandle = this.grvOtherServiceDetail.GetRowHandle(this._listDetails.Count - 1);
                    int lastRowHandle = this.grvOtherServiceDetail.GetRowHandle(grvOtherServiceDetail.FocusedRowHandle);
                    AddNewServiceDetail(lastRowHandle);
                    this.grvOtherServiceDetail.SetFocusedRowCellValue("Description", "Manual-" + AppSetting.CurrentUser.LoginName + "-" + DateTime.Now.ToString("dd/MM/yyyy"));
                    break;
                case "Description":
                    int otherServiceDetailID = Convert.ToInt32(this.grvOtherServiceDetail.GetFocusedRowCellValue("OtherServiceDetailID"));
                    string decription = Convert.ToString(this.grvOtherServiceDetail.GetFocusedRowCellValue("Description"));
                    FileProcess.LoadTable("update OtherServiceDetails set Description= N'" + decription + "'where OtherServiceDetailID=" + otherServiceDetailID);
                    break;
                case "OrderNumber":
                    UpdateServiceDetail(e.RowHandle);
                    break;
            }
        }

        #endregion

        private void SetEditable(bool isEditable)
        {
            this.btnDelete.Enabled = isEditable;
            this.grvOtherServiceDetail.OptionsBehavior.ReadOnly = !isEditable;
            this.lkeCustomers.ReadOnly = !isEditable;
            this.lkeEmployee.ReadOnly = !isEditable;
            this.dtServiceDate.ReadOnly = !isEditable;
            this.txtCustomerRep.ReadOnly = !isEditable;
            this.mmeRemark.ReadOnly = !isEditable;
            this.btnBilled.Enabled = isEditable;
            this.btnConfirm.Enabled = isEditable;
            this.chkIsAdjust.Enabled = isEditable;
            if (!this._currentService.LockStatus && !string.IsNullOrEmpty(this._currentService.ConfirmedBy))
            {
                this.btnBilled.Enabled = true;
            }

            if (!this._currentService.LockStatus)
            {
                bool isSupervisor = UserPermission.CheckSupervisorByDepartment(AppSetting.CurrentUser.LoginName, 4);
                if (isSupervisor) this.btnConfirm.Enabled = true;
            }
            if (string.IsNullOrEmpty(this._currentService.ConfirmedBy))
            {
                // Not confirm
                this.btnConfirm.Text = "Confirm";
            }
            else
            {
                // Confirmed
                this.btnConfirm.Text = "Confirmed/Locked";
            }
        }

        private OtherService GetOtherService()
        {
            OtherService service = new OtherService();
            service.OtherServiceID = this._currentService.OtherServiceID;
            service.ServiceDate = Convert.ToDateTime(this._currentService.ServiceDate.ToShortDateString());
            service.ServiceRemark = this._currentService.ServiceRemark;
            service.Status = this._currentService.Status;
            service.MHLBillingDate = this._currentService.MHLBillingDate;
            service.MHLBillingConfirm = this._currentService.MHLBillingConfirm;
            service.LockStatus = this._currentService.LockStatus;
            service.BillingID = this._currentService.BillingID;
            service.CreatedBy = this._currentService.CreatedBy;
            service.CreatedTime = this._currentService.CreatedTime;
            service.CustomerID = this._currentService.CustomerID;
            service.CustomerRep = this._currentService.CustomerRep;
            service.EmployeeID = this._currentService.EmployeeID;
            service.ConfirmedBy = this._currentService.ConfirmedBy;
            service.ConfirmedTime = this._currentService.ConfirmedTime;
            if (this._currentService.OtherServiceID <= 0)
            {
                service.CreatedBy = AppSetting.CurrentUser.LoginName;
                service.CreatedTime = DateTime.Now;
                service.Status = 0;
            }
            return service;
        }

        private void UpdateService()
        {
            try
            {
                DataProcess<OtherService> serviceDA = new DataProcess<OtherService>();
                int result = serviceDA.Update(GetOtherService());
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddNewService()
        {
            try
            {
                DataProcess<OtherService> serviceDA = new DataProcess<OtherService>();
                OtherService service = GetOtherService();
                if (service.OtherServiceID > 0)
                {
                    serviceDA.Update(service);
                }
                else
                {
                    serviceDA.Insert(service);
                    this.CustomerIDFind = 0;
                    //this._otherServiceIDFind = service.OtherServiceID;
                }

                this._isAddNew = false;
                LoadServices();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetDataForInsert()
        {
            this._isAddNew = true;
            var newOtherService = new ST_WMS_LoadOtherServices_Result();
            newOtherService.CreatedBy = AppSetting.CurrentUser.LoginName;
            newOtherService.CreatedTime = DateTime.Now;
            this._listServices.Add(newOtherService);
            this.dtNavigatorService.Position = this._listServices.Count;

            this.lkeCustomers.Focus();
            this.lkeCustomers.ShowPopup();
        }

        private void AddNewServiceDetail(int rowHandle)
        {
            try
            {
                DataProcess<OtherServiceDetails> detailDA = new DataProcess<OtherServiceDetails>();
                OtherServiceDetails serviceDetail = GetOtherServiceDetail(rowHandle);
                if (serviceDetail.ServiceID <= 0) return;
                if (serviceDetail.OtherServiceDetailID > 0)
                {
                    detailDA.Update(serviceDetail);
                }
                else
                {
                    detailDA.Insert(serviceDetail);
                    this.grvOtherServiceDetail.SetRowCellValue(rowHandle, "OtherServiceDetailID", serviceDetail.OtherServiceDetailID);
                    var newServiceDetail = new ST_WMS_LoadOtherServiceDetails_Result();
                    newServiceDetail.OrderNumber = this.orderNumber;
                    this._listDetails.Add(newServiceDetail);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateServiceDetail(int rowHandle)
        {
            try
            {
                DataProcess<OtherServiceDetails> detailDA = new DataProcess<OtherServiceDetails>();

                int result = detailDA.Update(GetOtherServiceDetail(rowHandle));
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private OtherServiceDetails GetOtherServiceDetail(int rowHandle)
        {
            OtherServiceDetails detail = new OtherServiceDetails();
            detail.OtherServiceDetailID = this.grvOtherServiceDetail.GetRowCellValue(rowHandle, "OtherServiceDetailID") == null ? 0 : Convert.ToInt32(this.grvOtherServiceDetail.GetRowCellValue(rowHandle, "OtherServiceDetailID"));
            detail.ServiceID = Convert.ToInt32(this.grvOtherServiceDetail.GetRowCellValue(rowHandle, "ServiceID"));
            detail.OtherServiceID = this._currentService.OtherServiceID;
            detail.OrderNumber = Convert.ToString(this.grvOtherServiceDetail.GetRowCellValue(rowHandle, "OrderNumber"));
            detail.Quantity = Convert.ToDecimal(this.grvOtherServiceDetail.GetRowCellValue(rowHandle, "Quantity"));
            detail.Invoiced = false;
            detail.Manual = Convert.ToBoolean(this.grvOtherServiceDetail.GetRowCellValue(rowHandle, "Manual"));
            detail.CreatedBy = Convert.ToString(this.grvOtherServiceDetail.GetRowCellValue(rowHandle, "CreatedBy"));
            detail.CreatedTime = Convert.ToDateTime(this.grvOtherServiceDetail.GetRowCellValue(rowHandle, "CreatedTime"));
            detail.Description = Convert.ToString(this.grvOtherServiceDetail.GetRowCellValue(rowHandle, "Description"));
            return detail;
        }

        private void btn_BR_btnNewService_Click(object sender, EventArgs e)
        {
            ResetDataForInsert();
        }

        private void btnRefreshOtherList_Click(object sender, EventArgs e)
        {
            if (this.lkeCustomers.EditValue == null) return;
            int customerID = Convert.ToInt32(this.lkeCustomers.EditValue);
            this.LoadOrders(customerID);
        }

        private void rpi_btn_CreateNewMHLWork_Click(object sender, EventArgs e)
        {
            int detailID = Convert.ToInt32(this.grvOtherServiceDetail.GetFocusedRowCellValue("OtherServiceDetailID"));
            DataProcess<MHLWorks> mhlDA = new DataProcess<MHLWorks>();
            DataProcess<MHLWorkDetails> mhlDetailsDA = new DataProcess<MHLWorkDetails>();
            var newMHL = new MHLWorks();
            newMHL.CreatedBy = AppSetting.CurrentUser.LoginName + " - " + DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            newMHL.CustomerMainID = this._currentService.CustomerMainID;
            newMHL.MHLWorkDate = DateTime.Now;
            newMHL.MHLWorkDefinitionID = 18;
            newMHL.FromTime = DateTime.Now.AddHours(-1);
            newMHL.ToTime = DateTime.Now;
            newMHL.OtherServiceDetailID = detailID;
            newMHL.Remark = this._currentService.ServiceRemark;
            mhlDA.Insert(newMHL);

            if (newMHL.MHLWorkID <= 0) return;

            // Work details
            var newDetailMHL = new MHLWorkDetails();
            newDetailMHL.MHLWorkID = newMHL.MHLWorkID;
            newDetailMHL.EmployeeID = AppSetting.CurrentUser.EmployeeID;
            newDetailMHL.CreatedBy = AppSetting.CurrentUser.LoginName;
            newDetailMHL.CreatedTime = DateTime.Now;
            newDetailMHL.CheckDelete = false;
            newDetailMHL.Quantity = 0;
            mhlDetailsDA.Insert(newDetailMHL);
            MessageBox.Show("Created new WO!", "WMS_2017", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Open from frm_WM_MHLWorks
            frm_WM_MHLWorks form = frm_WM_MHLWorks.Instance;
            form.MHLWorkID = newMHL.MHLWorkID;
            form.Show();

        }

        private void dtServiceDate_Validating(object sender, CancelEventArgs e)
        {
            //var createTime = (DateTime)this._listServices[this.dtNavigatorService.Position].CreatedTime;
            //var otherDate = this.dtServiceDate.DateTime;
            //if (createTime.Year > otherDate.Year
            //    || (createTime.Year == otherDate.Year && createTime.Month > otherDate.Month))
            //    e.Cancel = true;
        }

        private void btnContracts_Click(object sender, EventArgs e)
        {
            int customerID = Convert.ToInt32(this.lkeCustomers.EditValue);
            if (customerID <= 0) return;
            frm_MSS_Contracts contract = frm_MSS_Contracts.GetInstance(customerID);
            contract.InitData(customerID);
            contract.Show();
        }

        private void dockPanelRecentWorksServices_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            if (this.RecentWS == null)
            {
                RecentWS = new urc_WM_ServicesWorksRecent(this._currentService.CustomerID);
            }
            RecentWS.Parent = this.dockPanelRecentWorksServices;
        }

        private void dockPanelServiceOJ_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            if (this.OJLinked == null)
            {
                OJLinked = new urc_WM_OutsourcedJobLinked(this._currentService.CustomerID);
            }
            OJLinked.Parent = this.dockPanelServiceOJ;
        }

        private void dockPanelActiveServices_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            if (this.Billing == null)
            {
                Billing = new urc_WM_BillingContracts(this._currentService.CustomerID);
            }
            Billing.Parent = this.dockPanelActiveServices;
        }

        private void txtCustomerName_Click(object sender, EventArgs e)
        {
            if (this.lkeCustomers.EditValue == null) return;
            int customerID = Convert.ToInt32(this.lkeCustomers.EditValue);
            var currentCustomer = AppSetting.CustomerListAll.Where(c => c.CustomerID == customerID).FirstOrDefault();
            frm_MSS_Customers frmCustomer = frm_MSS_Customers.Instance;
            frmCustomer.CurrentCustomers = currentCustomer;
            frmCustomer.Show();
        }


        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (this.txtConfirmedBy.Text == "")
            {
                bool isSupervisor = UserPermission.CheckSupervisorByDepartment(AppSetting.CurrentUser.LoginName, 4);
                if (!isSupervisor)
                {
                    XtraMessageBox.Show("You are Supevisor to confirm this", "TPWMS",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Confirmed
                DialogResult result = XtraMessageBox.Show("Are you sure to confirm this service ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                if (result == DialogResult.Yes)
                {
                    FileProcess.LoadTable("UPDATE OtherService SET ConfirmedBy = '" + AppSetting.CurrentUser.LoginName + "', ConfirmedTime = GETDATE() WHERE OtherServiceID = " + this._currentService.OtherServiceID);
                    this._listServices[this.dtNavigatorService.Position].ConfirmedBy = AppSetting.CurrentUser.LoginName;
                    this._listServices[this.dtNavigatorService.Position].ConfirmedTime = DateTime.Now;
                    this.txtConfirmedBy.Text = AppSetting.CurrentUser.LoginName;
                    this.txtConfirmedTime.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm");

                    this.btnConfirm.Enabled = false;
                    this.btnConfirm.Text = "Confirmed/Locked";
                    //Code here to refresh the form data
                    SetEditable(false);
                }
            }
            else
            {
                // Un-Confirmed
                DialogResult result = XtraMessageBox.Show("Are you sure to Un-confirm this service ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    FileProcess.LoadTable("UPDATE OtherService SET ConfirmedBy = NULL, ConfirmedTime = NULL WHERE OtherServiceID = " + this._currentService.OtherServiceID);
                    this._listServices[this.dtNavigatorService.Position].ConfirmedBy = "";
                    this._listServices[this.dtNavigatorService.Position].ConfirmedTime = null;
                    this.txtConfirmedBy.Text = "";
                    this.txtConfirmedTime.Text = "";

                    this.btnConfirm.Enabled = true;
                    this.btnConfirm.Text = "Confirmed";
                    //Code here to refresh the form data
                    SetEditable(false);
                }
            }
        }

        private void chkIsAdjust_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkIsAdjust.IsModified &&
                this.chkIsAdjust.CheckState != CheckState.Indeterminate)
            {
                var hasChecked = (int)this.chkIsAdjust.CheckState;
                this._otherServiceDA.ExecuteNoQuery("Update otherService set isBillingAdjustment=" + hasChecked
                    + " Where otherServiceID=" + this._currentService.OtherServiceID);
                this._currentService.isBillingAdjustment = this.chkIsAdjust.Checked;
            }
        }
    }
}
