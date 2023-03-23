using Common.Controls;
using DA;
using DA.API;
using DA.Warehouse;
using DevExpress.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using log4net;
using Newtonsoft.Json;
using SCSVN.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UI.APIs;
using UI.Helper;
using UI.Management;
using UI.ReportFile;
//using System.IO.Compression;



namespace UI.WarehouseManagement
{
    public partial class frm_WM_TripsManagement : frmBaseForm
    {
        private IEnumerable<ST_WMS_LoadTripsManagement_Result> currentTripList;
        private ST_WMS_LoadTripsManagement_Result currentTrip;
        Employees fullInfoEmployees = new DataProcess<Employees>().Select(em => em.EmployeeID == AppSetting.CurrentUser.EmployeeID).FirstOrDefault();
        private int tripID;
        private int selected;
        private bool isNewTrip;
        private urc_WM_EmployeeInfo viewEmployee = null;
        private urc_WM_Vehicle viewVehicle = null;
        private urc_WM_OtherService otherService = null;
        private IList<ST_WMS_LoadTripManagementDetails_Result> tripDetailsList;
        private bool isCheckedAll = false;
        private DateTime tripDateNew = DateTime.Now;

        private IEnumerable<STDestinationPorts_Result> destinationPortsList;

        private IEnumerable<STComboServiceOvertime_Result> serviceOvertimeList;

        private IEnumerable<STCustomerClients_Result> customerClientList;

        private IEnumerable<STTripDO_Result> tripDOList;

        int qtyPrint = 0;

        bool isSupervisor;
        /// <summary>
        /// The logger
        /// </summary>
        private static ILog logger = LogManager.GetLogger(typeof(frm_WM_TripsManagement));

        public frm_WM_TripsManagement(int tripId = 0)
        {
            InitializeComponent();
            this.IsFixHeightScreen = false;
            this.tripID = tripId;
            this.LoadDocumentStatus();
            this.currentTrip = new ST_WMS_LoadTripsManagement_Result();
            isSupervisor = UserPermission.CheckSupervisorByDepartment(AppSetting.CurrentUser.LoginName, 4);
        }

        public void ReloadData(int tripId, Nullable<DateTime> tripDateNew = null)
        {
            this.tripID = tripId;
            if (tripDateNew != null)
            {
                this.tripDateNew = Convert.ToDateTime(tripDateNew);
            }
            InitCustomer();
            this.LoadTransportList();
            this.LoadDocumentStatus();

            // Check current tripID has exist
            var tripSelectedHasExit = FileProcess.LoadTable("Select count(*) from trips where tripID=" + this.tripID);
            if (Convert.ToInt32(tripSelectedHasExit.Rows[0][0]) > 0)
            {
                LoadTripsInit();
                LoadTripDetails();
                LoadEmployeeWorking();

                InitControls();
            }
            else
            {
                this.CleanData();
                InitNewTrip();
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

        private void LoadDocumentStatus()
        {
            this.rpi_lke_DocumentStatus.DataSource = FileProcess.LoadTable("Select * from DocumentStatus ");
            this.rpi_lke_DocumentStatus.ValueMember = "DocumentStatusID";
            this.rpi_lke_DocumentStatus.DisplayMember = "DocumentStatusDescription";
        }

        private void LoadDockDoor(string orderNumber)
        {
            DataProcess<STcomboDockDoorID_Result> dockDoorDA = new DataProcess<STcomboDockDoorID_Result>();
            this.lkeDockNumber.Properties.DataSource = dockDoorDA.Executing(" STcomboDockDoorID @OrderNumber={0}", orderNumber);
            this.lkeDockNumber.Properties.ValueMember = "DockDoorID";
            this.lkeDockNumber.Properties.DisplayMember = "DockNumber";
        }

        private void LoadTransportList()
        {
            this.lke_Transporter.Properties.DataSource = FileProcess.LoadTable("  Select * from ViewSupplierTransporters ");
            this.lke_Transporter.Properties.DisplayMember = "SupplierName";
            this.lke_Transporter.Properties.ValueMember = "SupplierID";
        }

        private void frm_WM_TripsManagement_Load(object sender, EventArgs e)
        {
            this.LoadTimeSlots();
            this.RepositoryItemButtonP.Click += RepositoryItemButtonP_Click;
            this.ReloadData(this.tripID);
        }

        private void CleanData()
        {
            this.lkeCustomerNumber.EditValue = null;
            this.lkeServiceNumber.EditValue = null;
            this.lkeOneClient.EditValue = null;
            this.lkeDockNumber.EditValue = null;
            this.deTripDate.EditValue = null;
            this.lke_TimeSlotID.EditValue = null;
            this.dtStartTime.EditValue = null;
            this.dtEndTime.EditValue = null;
            this.memoTruckAndDetails.Text = string.Empty;
            this.teTripID.Text = string.Empty;
            this.teCreateBy.Text = string.Empty;
            this.teCreateAt.Text = string.Empty;
            this.teSeal.Text = string.Empty;
            this.textEditTripOrderProgress.EditValue = null;
            this.txtVehicleNumber.Text = string.Empty;
            this.deRoadEnd.EditValue = null;
            this.deRoadStart.EditValue = null;
            this.lke_Transporter.EditValue = null;
            this.teTemp.Text = string.Empty;
            this.teServiceName.Text = string.Empty;
            this.teInternal.Text = string.Empty;
            this.teCustomerName.Text = string.Empty;
            this.lookUpEditRouteID.EditValue = null;
            this.grcTripDetails.DataSource = null;
        }

        void RepositoryItemButtonP_Click(object sender, EventArgs e)
        {
            printButtonP(true);
        }

        private void InitNewTrip()
        {
            SetReadOnly(false);
            this.isNewTrip = true;
            this.teCreateBy.Text = AppSetting.CurrentUser.LoginName;
            this.teCreateAt.Text = DateTime.Now.ToString("dd/MM/yyyy");
            this.deTripDate.EditValue = this.tripDateNew;
            this.lkeCustomerNumber.Focus();
            this.lkeCustomerNumber.ShowPopup();
        }

        private void SetReadOnly(bool isReadOnly)
        {
            lkeCustomerNumber.ReadOnly = isReadOnly;
            deTripDate.ReadOnly = isReadOnly;
            this.lke_Transporter.ReadOnly = isReadOnly;
            teServiceName.ReadOnly = isReadOnly;
            deTripDate.ReadOnly = isReadOnly;
        }

        private void SetButtonEnable(bool isEnable)
        {
            bbtnDeleteTrip.Enabled = isEnable;
            bbtnDeleteRecord.Enabled = isEnable;
            bbtnConfirm.Enabled = isEnable;
            bbtnAddAll.Enabled = isEnable;
            bbtnSplitTrip.Enabled = isEnable;
            bbtnUpdateAll.Enabled = isEnable;
        }

        #region Load Data
        private void LoadTripsInit()
        {
            DataProcess<ST_WMS_LoadTripsManagement_Result> tripManagementDA = new DataProcess<ST_WMS_LoadTripsManagement_Result>();
            this.currentTripList = tripManagementDA.Executing("ST_WMS_LoadTripsManagement @TripDate = {0}, @TripID = {1}", DateTime.Now.AddDays(-10), tripID);

            // DataTable dt = FileProcess.LoadTable("ST_WMS_LoadTripsManagement @TripDate ='" + DateTime.Now.AddDays(-10) + "',@TripID = " + tripID);
            this.currentTrip = currentTripList.Where(t => t.TripID == this.tripID).FirstOrDefault();

            this.LoadTripStatus();
            InitOneClient();
            InitCustomerClientCode();
            InitOrderNumber();
            InitService();
            LoadRoutes();
            this.LoadOJByTrip();
            BindData();
        }

        // Load Route look up edit for the Trip
        private void LoadRoutes()
        {
            this.lookUpEditRouteID.Properties.DataSource = FileProcess.LoadTable("STCustomerAddressRoutes @CustomerID=" + Convert.ToInt32(this.lkeCustomerNumber.EditValue));
            this.lookUpEditRouteID.Properties.DisplayMember = "RouteCode";
            this.lookUpEditRouteID.Properties.ValueMember = "CustomerDeliveryRouteID";
            this.lookUpEditRouteID.EditValue = 1;
        }

        private void LoadOJByTrip()
        {
            this.grdOJList.DataSource = FileProcess.LoadTable("STMHLWorksByTripNumber @TripNumber='" + this.currentTrip.TripNumber + "'");
        }
        private void LoadTripStatus()
        {
            DataProcess<TripDetailStatu> tripStatusDA = new DataProcess<TripDetailStatu>();
            this.rpi_lke_TripStatus.DataSource = tripStatusDA.Select();
            this.rpi_lke_TripStatus.DisplayMember = "TripStatusDescriptions";
            this.rpi_lke_TripStatus.ValueMember = "TripStatus";
        }
        private void LoadTripDetails()
        {
            DataProcess<ST_WMS_LoadTripManagementDetails_Result> tripDetailsDA = new DataProcess<ST_WMS_LoadTripManagementDetails_Result>();
            tripDetailsList = (IList<ST_WMS_LoadTripManagementDetails_Result>)tripDetailsDA.Executing("ST_WMS_LoadTripManagementDetails @TripID={0}", currentTrip.TripID);
            tripDetailsList.Add(new ST_WMS_LoadTripManagementDetails_Result());
            this.grcTripDetails.DataSource = tripDetailsList;
            int rowCount = tripDetailsList.Count - 1;
            this.grdcolDelete.SummaryItem.SetSummary(SummaryItemType.Custom, rowCount.ToString());
            this.grdcolRemark.SummaryItem.SetSummary(SummaryItemType.Custom, string.Format("Total Order: {0}", rowCount));
            int index = 0;
            foreach (var item in this.tripDetailsList)
            {
                if (item.CheckDelete)
                {
                    this.grvTripDetails.SelectRow(index);
                }
                index++;
            }
        }

        private void LoadEmployeeWorking()
        {
            //decimal TotalPallets = Convert.ToDecimal(grdcolPallet.SummaryItem.SummaryValue);
            //decimal TotalWeight = Convert.ToDecimal(grdcolWeight.SummaryItem.SummaryValue);
            //decimal TotalCartons = Convert.ToDecimal(grdcolCtns.SummaryItem.SummaryValue);
            //string tripNumber = Convert.ToString(teTripID.EditValue);

            //if (this.viewEmployee == null)
            //{
            //    this.viewEmployee = new urc_WM_EmployeeInfo(tripNumber, TotalPallets, TotalWeight, TotalCartons);
            //    this.viewEmployee.Parent = this.dockPanelEmployees;
            //}
            //else
            //{
            //    this.viewEmployee.UpdateParameter(TotalPallets, TotalCartons, TotalWeight);
            //    this.viewEmployee.LoadEmployeeWorking(tripNumber);
            //    this.viewEmployee.Update();
            //    this.viewEmployee.Refresh();
            //}

            //int customerID = Convert.ToInt32(currentTrip.CustomerID);
            //string totalPackage = this.grdcolCtns.SummaryItem.SummaryValue.ToString();

            //if (this.viewVehicle == null)
            //{
            //    this.viewVehicle = new urc_WM_Vehicle(customerID, currentTrip.CustomerName, txtVehicleNumber.Text, currentTrip.TripNumber, memoTruckAndDetails.Text, teSeal.Text, this.lkeDockNumber.Text, totalPackage);
            //    this.viewVehicle.Parent = this.dockPanelVehicle;
            //}
            //else
            //{
            //    this.viewVehicle.UpdateParam(customerID, currentTrip.CustomerName, txtVehicleNumber.Text, teSeal.Text, this.lkeDockNumber.Text);
            //    this.viewVehicle.InitData(currentTrip.TripNumber, totalPackage);
            //    this.viewVehicle.Update();
            //    this.viewVehicle.Refresh();
            //}
            //string orderNumber = Convert.ToString(this.grvTripDetails.GetFocusedRowCellValue("OrderNumber"));
            //if (this.otherService == null)
            //{

            //    this.otherService = new urc_WM_OtherService(orderNumber);
            //    this.otherService.Parent = this.dockPanelService;
            //}
            //else
            //{
            //    this.otherService.InitData(orderNumber);
            //}
        }

        #region Init LookUpEdit data
        private void InitCustomer()
        {
            this.lkeCustomerNumber.Properties.DataSource = AppSetting.CustomerList;

            if (AppSetting.CustomerList.Count() < 20)
                this.lkeCustomerNumber.Properties.DropDownRows = AppSetting.CustomerList.Count();
            else
                this.lkeCustomerNumber.Properties.DropDownRows = 20;

            this.lkeCustomerNumber.Properties.DisplayMember = "CustomerNumber";
            this.lkeCustomerNumber.Properties.ValueMember = "CustomerID";
            this.lkeCustomerNumber.EditValue = currentTrip.CustomerID;
        }

        private void InitService()
        {
            DataProcess<STComboServiceOvertime_Result> serviceOvertimeDA = new DataProcess<STComboServiceOvertime_Result>();
            this.serviceOvertimeList = serviceOvertimeDA.Executing("STComboServiceOvertime @CustomerID={0}", currentTrip.CustomerID);

            this.lkeServiceNumber.Properties.DataSource = serviceOvertimeList;
            this.lkeServiceNumber.Properties.PopulateColumns();

            if (this.serviceOvertimeList.Count() < 20)
                this.lkeServiceNumber.Properties.DropDownRows = serviceOvertimeList.Count();
            else
                this.lkeServiceNumber.Properties.DropDownRows = 20;

            this.lkeServiceNumber.Properties.DisplayMember = "ServiceNumber";
            this.lkeServiceNumber.Properties.ValueMember = "ServiceID";
        }

        private void InitOneClient()
        {
            //LookUpEdit OneClient
            DataProcess<STCustomerClients_Result> customerClientDA = new DataProcess<STCustomerClients_Result>();
            this.customerClientList = customerClientDA.Executing("STCustomerClients @CustomerID={0}", currentTrip.CustomerID);

            this.lkeOneClient.Properties.DataSource = customerClientList;

            if (this.customerClientList.Count() < 20)
                this.lkeOneClient.Properties.DropDownRows = customerClientList.Count();
            else
                this.lkeOneClient.Properties.DropDownRows = 20;

            this.lkeOneClient.Properties.DisplayMember = "CustomerClientCode";
            this.lkeOneClient.Properties.ValueMember = "CustomerClientID";
            //this.lkeOneClient.EditValue=this.currentTrip.cust
        }

        private void InitCustomerClientCode()
        {
            //LookUpEdit CustomerClientCode
            this.ri_lke_CustomerClientID.DataSource = this.customerClientList;

            if (this.customerClientList.Count() < 20)
                this.ri_lke_CustomerClientID.DropDownRows = this.customerClientList.Count();
            else
                this.ri_lke_CustomerClientID.DropDownRows = 20;

            this.ri_lke_CustomerClientID.DisplayMember = "CustomerClientCode";
            this.ri_lke_CustomerClientID.ValueMember = "CustomerClientID";
        }

        private void InitOrderNumber()
        {
            //LookUpEdit StripDO
            DataProcess<STTripDO_Result> tripDO_DA = new DataProcess<STTripDO_Result>();
            tripDOList = tripDO_DA.Executing("STTripDO @CustomerMainID={0},@TripDate={0}", currentTrip.CustomerMainID, currentTrip.TripDate);
            ri_lke_OrderNumber.DataSource = tripDOList;
            if (tripDOList.Count() < 20)
                ri_lke_OrderNumber.DropDownRows = tripDOList.Count();
            else
                ri_lke_OrderNumber.DropDownRows = 20;
            ri_lke_OrderNumber.DisplayMember = "DispatchingOrderNumber";
            ri_lke_OrderNumber.ValueMember = "DispatchingOrderNumber";
        }
        #endregion

        private void BindData()
        {
            this.LoadDockDoor(currentTrip.TripNumber);
            this.lkeCustomerNumber.EditValue = currentTrip.CustomerID;
            this.teCustomerName.EditValue = currentTrip.CustomerName;
            this.teCreateBy.Text = currentTrip.CreatedBy;
            this.teCreateAt.Text = currentTrip.CreatedTime.ToString();
            this.teTripID.Text = currentTrip.TripNumber;
            this.deTripDate.EditValue = currentTrip.TripDate;
            this.teTemp.Text = currentTrip.Temperature;
            this.lkeDockNumber.EditValue = currentTrip.DockDoorID;
            this.teSeal.Text = currentTrip.SealNumber;
            this.textEditTripOrderProgress.EditValue = currentTrip.TripOrderProgress;
            this.txtVehicleNumber.Text = currentTrip.VehicleNumber;
            this.deRoadStart.EditValue = currentTrip.OnRoadStartTime;
            this.deRoadEnd.EditValue = currentTrip.OnRoadEndTime;
            this.memoTruckAndDetails.EditValue = currentTrip.TripRemark;
            if (currentTrip.HandlingOvertimeCategoryID != null)
            {
                this.lkeServiceNumber.EditValue = Convert.ToInt32(currentTrip.HandlingOvertimeCategoryID);
            }
            else
            {
                this.lkeServiceNumber.EditValue = null;
            }
            this.lke_Transporter.EditValue = this.currentTrip.TransporterID;
            this.teServiceName.EditValue = currentTrip.ServiceName;
            this.teInternal.EditValue = currentTrip.InternalRemark;
            this.dtStartTime.EditValue = currentTrip.StartWorkingTime;
            this.dtEndTime.EditValue = currentTrip.EndWorkingTime;
            if (currentTrip.RouteID != null) this.lookUpEditRouteID.EditValue = currentTrip.RouteID;
            this.lke_TimeSlotID.EditValue = currentTrip.TimeSlotID;

            SetReadOnly(this.currentTrip.TripConfirmed);
        }

        private void InitControls()
        {
            //Load trạng thái mặc định của form
            if (currentTrip.TripConfirmed)
            {
                bbtnDeleteTrip.Enabled = false;
                bbtnDeleteRecord.Enabled = false;
                lkeCustomerNumber.ReadOnly = true;
                bbtnConfirm.Enabled = false;
                deTripDate.ReadOnly = true;
                bbtnAddAll.Enabled = false;
                bbtnSplitTrip.Enabled = false;
                bbtnUpdateAll.Enabled = false;
                this.lke_Transporter.ReadOnly = true;
                teServiceName.ReadOnly = true;
                barButtonItem3.Enabled = false;
                deTripDate.ReadOnly = true;
                if (isSupervisor)
                {
                    lkeServiceNumber.Enabled = true;
                }
                else
                {
                    lkeServiceNumber.Enabled = false;
                }
            }
            else
            {
                if (tripDetailsList != null && tripDetailsList.Count() > 1)
                {
                    lkeCustomerNumber.ReadOnly = true;
                    bbtnDeleteTrip.Enabled = true;
                    bbtnDeleteRecord.Enabled = true;
                }
                else
                {
                    lkeCustomerNumber.ReadOnly = false;
                    bbtnDeleteTrip.Enabled = true;
                    bbtnDeleteRecord.Enabled = false;
                }
                bbtnConfirm.Enabled = true;
                deTripDate.ReadOnly = false;
                bbtnAddAll.Enabled = true;
                bbtnSplitTrip.Enabled = true;
                bbtnUpdateAll.Enabled = true;
                lkeServiceNumber.Enabled = true;
                if (currentTrip.DestinationPortID != 1)
                    lkeServiceNumber.ReadOnly = false;
                teServiceName.ReadOnly = false;
                barButtonItem3.Enabled = true;
            }
        }
        #endregion

        #region Events
        private void bbtnBarcodeChecking_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_WM_BarcodeScan_Result_DO BarcodeForm = new frm_WM_BarcodeScan_Result_DO(currentTrip.TripID);
            BarcodeForm.Show();
        }

        private void RepositoryItemHyperLinkOrderNumber_DoubleClick(object sender, EventArgs e)
        {
            string SelectedOrderNumber = grvTripDetails.GetFocusedRowCellValue("OrderNumber").ToString();
            if (!String.IsNullOrEmpty(SelectedOrderNumber))
            {
                if (SelectedOrderNumber.Substring(0, 2).ToUpper() == "DO")
                {
                    string DispatchingOrderID = SelectedOrderNumber.Substring(3);
                    frm_WM_DispatchingOrders DispatchingOrdersForm = frm_WM_DispatchingOrders.GetInstance(int.Parse(DispatchingOrderID));
                    if (DispatchingOrdersForm.Visible)
                    {
                        DispatchingOrdersForm.ReloadData();
                    }
                    DispatchingOrdersForm.Show();
                }
                if (SelectedOrderNumber.Substring(0, 2).ToUpper() == "RO")
                {
                    string ReceivingOrderID = SelectedOrderNumber.Substring(3);
                    frm_WM_ReceivingOrders receivingOrder = frm_WM_ReceivingOrders.Instance;
                    receivingOrder.ReceivingOrderIDFind = (int.Parse(ReceivingOrderID));
                    receivingOrder.Show();
                    receivingOrder.WindowState = FormWindowState.Maximized;
                    receivingOrder.BringToFront();
                }
            }
        }

        private void lkeServiceNumber_EditValueChanged(object sender, EventArgs e)
        {
            if (lkeServiceNumber.GetColumnValue("ServiceName") != null)
                teServiceName.Text = lkeServiceNumber.GetColumnValue("ServiceName").ToString();
            this.currentTrip.HandlingOvertimeCategoryID = Convert.ToInt16(this.lkeServiceNumber.EditValue);
        }

        private void repositoryItemButtonN_Click(object sender, EventArgs e)
        {
        }
        private void printButtonP(bool isPreview)
        {

            string SelectedOrderNumber = grvTripDetails.GetFocusedRowCellValue("OrderNumber").ToString();
            if (!String.IsNullOrEmpty(SelectedOrderNumber))
            {
                if (SelectedOrderNumber.Substring(0, 2).ToUpper() == "DO")
                {
                    int DispatchingOrderID = Convert.ToInt32(SelectedOrderNumber.Substring(3));
                    var Result = new object();
                    //processing...
                    string CustomerType = AppSetting.CustomerList.Where(Customer => Customer.CustomerID == currentTrip.CustomerID).SingleOrDefault().CustomerType;
                    if (CustomerType == CustomerTypeEnum.RANDOM_WEIGHT)
                    {
                        DataProcess<STCustomerRequirementPrint_Result> cusRequireDA = new DataProcess<STCustomerRequirementPrint_Result>();
                        rptDispatchingPlanA4New dPlanA4 = new rptDispatchingPlanA4New();
                        dPlanA4.Parameters["varDispatchingOrderID"].Value = (int)DispatchingOrderID;

                        DataTable customerRequired = FileProcess.LoadTable("STCustomerRequirementPrint @CustomerMainID=" + currentTrip.CustomerMainID + ",@Flag=2, @ReceivingOrderID=null");
                        string customerRequire = "";
                        foreach (DataRow row in customerRequired.Rows)
                        {
                            customerRequire += row["RequirementDetails"].ToString();
                        }
                        var dataSource = FileProcess.LoadTable("STDispatchingPlanReportNew  @varDispatchingOrderID=" + (int)DispatchingOrderID);
                        dPlanA4.DataSource = dataSource;
                        dPlanA4.RequestParameters = false;
                        if (customerRequired != null)
                        {
                            dPlanA4.Parameters["varCustomerRequired"].Value = customerRequire;
                        }
                        dPlanA4.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
                        dPlanA4.xrPalletID.Visible = true;
                        dPlanA4.xrKgs.Visible = false;
                        dPlanA4.xrUnit.Visible = true;
                        dPlanA4.xrWeight.Visible = true;
                        dPlanA4.xrCtnPcs.Visible = true;
                        dPlanA4.xrPro_.Visible = false;
                        dPlanA4.xrExp.Visible = false;
                        dPlanA4.xrTon.Visible = false;
                        dPlanA4.xrSoLuong.Visible = false;
                        dPlanA4.xrhCtn.Visible = true;
                        dPlanA4.xrhUn.Visible = true;
                        // hide group header
                        dPlanA4.xrhSumPalletWeight.Visible = true;
                        dPlanA4.xrhSumUnitQty.Visible = true;
                        dPlanA4.xrhWeigth.Visible = false;
                        // visible ctn
                        dPlanA4.xrhKgCtn.Visible = true;
                        dPlanA4.xrhWeightPerPackage.Visible = false;
                        dPlanA4.xrhSumWeightPerPackage.Visible = false;
                        // show colum detail
                        dPlanA4.xrdQtyPackageModInner.Visible = false;
                        dPlanA4.xrdQtyPackageQuotieInner.Visible = false;
                        dPlanA4.xrdPalletWeight.Visible = true;
                        dPlanA4.xrdPalletWeightAvg.Visible = true;
                        dPlanA4.xrdProductDate.Visible = true;
                        dPlanA4.xrdUseByDate.Visible = true;
                        dPlanA4.xrhTon.Visible = true;
                        dPlanA4.xrdUnitQty.Visible = true;
                        dPlanA4.xrhWeigth.Visible = true;
                        dPlanA4.xrhWeightPerPackage.Visible = false;
                        dPlanA4.xrLine40.Visible = false;
                        dPlanA4.xrnhietDo.Visible = false;
                        dPlanA4.xrTemperature.Visible = false;
                        dPlanA4.xrhRemain.Visible = false;
                        dPlanA4.xrLine39.Visible = false;
                        dPlanA4.xrhKgs.Visible = true;
                        // rename text
                        dPlanA4.xrCtnPcs.Text = "Ctn";

                        // move postion and resize xrh & xrd
                        dPlanA4.xrhKgCtn.LocationF = new PointF(dPlanA4.xrhKgCtn.LocationF.X + 20, dPlanA4.xrhKgCtn.LocationF.Y);
                        dPlanA4.xrUnit.LocationF = new PointF(dPlanA4.xrUnit.LocationF.X + 100, dPlanA4.xrUnit.LocationF.Y);
                        dPlanA4.xrExp.LocationF = new PointF(dPlanA4.xrExp.LocationF.X + 30, dPlanA4.xrExp.LocationF.Y);
                        dPlanA4.xrCtnPcs.LocationF = new PointF(dPlanA4.xrCtnPcs.LocationF.X - 20, dPlanA4.xrCtnPcs.LocationF.Y);
                        dPlanA4.xrPalletID.LocationF = new PointF(dPlanA4.xrPalletID.LocationF.X + 50, dPlanA4.xrPalletID.LocationF.Y);
                        dPlanA4.xrWeight.LocationF = new PointF(dPlanA4.xrWeight.LocationF.X + 130, dPlanA4.xrWeight.LocationF.Y);
                        dPlanA4.xrdPalletWeight.LocationF = new PointF(dPlanA4.xrdPalletWeight.LocationF.X + 30, dPlanA4.xrdPalletWeight.LocationF.Y);
                        dPlanA4.xrdDispatchingLocationRemark.WidthF = 150F;

                        dPlanA4.xrdQtyPackageModInner.LocationF = new PointF(dPlanA4.xrdQtyPackageModInner.LocationF.X + 20, dPlanA4.xrdQtyPackageModInner.LocationF.Y);
                        dPlanA4.xrdQtyPackageQuotieInner.LocationF = new PointF(dPlanA4.xrdQtyPackageQuotieInner.LocationF.X + 20, dPlanA4.xrdQtyPackageQuotieInner.LocationF.Y);

                        //product date, usebydate
                        dPlanA4.xrdProductDate.LocationF = new PointF(dPlanA4.xrdProductDate.LocationF.X + 140, dPlanA4.xrdProductDate.LocationF.Y);
                        dPlanA4.xrdUseByDate.LocationF = new PointF(dPlanA4.xrdProductDate.LocationF.X + 60, dPlanA4.xrdProductDate.LocationF.Y);

                        dPlanA4.xrProductName.WidthF = 280F;
                        dPlanA4.xrProductName.LocationF = new PointF(dPlanA4.xrProductName.LocationF.X - 10, dPlanA4.xrProductName.LocationF.Y);
                        dPlanA4.xrdPalletID.LocationF = new PointF(dPlanA4.xrdPalletID.LocationF.X + 50, dPlanA4.xrdPalletID.LocationF.Y);

                        dPlanA4.xrhCtn.LocationF = new PointF(dPlanA4.xrhCtn.LocationF.X - 70, dPlanA4.xrhCtn.LocationF.Y);
                        dPlanA4.xrhSumUnitQty.WidthF = dPlanA4.xrhSumUnitQty.WidthF + 10;
                        dPlanA4.xrhSumUnitQty.LocationF = new PointF(dPlanA4.xrhSumUnitQty.LocationF.X - 70, dPlanA4.xrhSumUnitQty.LocationF.Y);
                        dPlanA4.xrhWeightPPackage.LocationF = new PointF(dPlanA4.xrhWeightPPackage.LocationF.X - 30, dPlanA4.xrhWeightPPackage.LocationF.Y);

                        dPlanA4.xrhUn.LocationF = new PointF(dPlanA4.xrhUn.LocationF.X - 50, dPlanA4.xrhUn.LocationF.Y);
                        dPlanA4.xrhKgCtn.LocationF = new PointF(dPlanA4.xrhKgCtn.LocationF.X - 20, dPlanA4.xrhKgCtn.LocationF.Y);
                        dPlanA4.GroupHeader1.LocationF = new PointF(dPlanA4.GroupHeader1.LocationF.X, dPlanA4.GroupHeader1.LocationF.Y + 20);

                        dPlanA4.xrdRemark.WidthF = dPlanA4.xrdRemark.WidthF + 50;
                        dPlanA4.xrdQtyOfPackage.LocationF = new PointF(dPlanA4.xrdQtyOfPackage.LocationF.X + 40, dPlanA4.xrdQtyOfPackage.LocationF.Y);
                        dPlanA4.xrdRemainByProduct.LocationF = new PointF(dPlanA4.xrdRemainByProduct.LocationF.X + 10, dPlanA4.xrdRemainByProduct.LocationF.Y);
                        dPlanA4.xrdUnitQty.LocationF = new PointF(dPlanA4.xrdUnitQty.LocationF.X - 140, dPlanA4.xrdUnitQty.LocationF.Y);
                        dPlanA4.xrhSumQtyOfPackage.LocationF = new PointF(dPlanA4.xrhSumQtyOfPackage.LocationF.X - 90, dPlanA4.xrhSumQtyOfPackage.LocationF.Y);
                        dPlanA4.xrdRemark.LocationF = new PointF(dPlanA4.xrdRemark.LocationF.X + 25, dPlanA4.xrdRemark.LocationF.Y);

                        // get source report
                        string strDO = string.Empty;
                        if (dataSource != null && dataSource.Rows.Count > 0)
                        {
                            strDO = Convert.ToString(dataSource.Rows[0]["DispatchingOrderID_Barcode"]);
                        }

                        dPlanA4.bcDispatching.Text = "*" + strDO + "*";
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
                    else
                    {
                        DataProcess<STCustomerRequirementPrint_Result> cusRequireDA = new DataProcess<STCustomerRequirementPrint_Result>();
                        rptDispatchingPlanA4New dPlanA4 = new rptDispatchingPlanA4New();
                        dPlanA4.Parameters["varDispatchingOrderID"].Value = (int)DispatchingOrderID;

                        DataTable customerRequired = FileProcess.LoadTable("STCustomerRequirementPrint @CustomerMainID=" + currentTrip.CustomerMainID + ",@Flag=2, @ReceivingOrderID=null");
                        string customerRequire = "";
                        foreach (DataRow row in customerRequired.Rows)
                        {
                            customerRequire += row["RequirementDetails"].ToString();
                        }
                        var dataSource = FileProcess.LoadTable("STDispatchingPlanReportNew  @varDispatchingOrderID=" + (int)DispatchingOrderID);
                        dPlanA4.DataSource = dataSource;
                        dPlanA4.RequestParameters = false;
                        if (customerRequired != null)
                        {
                            dPlanA4.Parameters["varCustomerRequired"].Value = customerRequire;
                        }
                        dPlanA4.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
                        dPlanA4.GroupFooter1.Visible = false;
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
                        dPlanA4.xrhWeightPPackage.Visible = false;
                        dPlanA4.xrdQtyPackageQuotieInner.Visible = false;
                        dPlanA4.xrdPalletWeight.Visible = false;
                        dPlanA4.xrPalletWeighAvg.Visible = true;
                        dPlanA4.xrProductName.WidthF = 290F;
                        Font newfontPalletID = new System.Drawing.Font("Lato", 9, FontStyle.Bold);
                        Font newfontKgsTon = new System.Drawing.Font("Lato", 8, FontStyle.Regular);
                        dPlanA4.xrdPalletID.Font = newfontPalletID;
                        dPlanA4.xrPalletWeighAvg.Font = dPlanA4.xrhRemain.Font = newfontKgsTon;

                        // move postion and resize xrlabel
                        dPlanA4.xrhSumQtyOfPackage.Font = dPlanA4.xrLabel22.Font;
                        dPlanA4.xrdRemark.TextAlignment = TextAlignment.TopRight;
                        dPlanA4.xrdDispatchingLocationRemark.WidthF = 160F;
                        dPlanA4.xrdPalletID.WidthF = dPlanA4.xrdPalletID.WidthF + 10;
                        dPlanA4.xrdPalletID.LocationF = new PointF(dPlanA4.xrdPalletID.LocationF.X + 80, dPlanA4.xrdPalletID.LocationF.Y);
                        dPlanA4.xrLabel22.LocationF = new PointF(dPlanA4.xrLabel22.LocationF.X + 30, dPlanA4.xrLabel22.LocationF.Y);
                        dPlanA4.xrfcalculateField1.LocationF = new PointF(dPlanA4.xrfcalculateField1.LocationF.X + 30, dPlanA4.xrfcalculateField1.LocationF.Y);
                        dPlanA4.xrTenHang.LocationF = new PointF(dPlanA4.xrTenHang.LocationF.X + 10, dPlanA4.xrTenHang.LocationF.Y);
                        dPlanA4.xrdQtyOfPackage.LocationF = new PointF(dPlanA4.xrdQtyOfPackage.LocationF.X + 60, dPlanA4.xrdQtyOfPackage.LocationF.Y);
                        dPlanA4.xrdProductDate.LocationF = new PointF(dPlanA4.xrdProductDate.LocationF.X + 70, dPlanA4.xrdProductDate.LocationF.Y);
                        dPlanA4.xrdUseByDate.LocationF = new PointF(dPlanA4.xrdUseByDate.LocationF.X + 50, dPlanA4.xrdUseByDate.LocationF.Y);
                        // get source report
                        string strDO = string.Empty;
                        if (dataSource != null && dataSource.Rows.Count > 0)
                        {
                            strDO = Convert.ToString(dataSource.Rows[0]["DispatchingOrderID_Barcode"]);
                        }

                        dPlanA4.bcDispatching.Text = "*" + strDO + "*";
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

                }
            }
        }

        private void bbtnDeleteTrip_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (currentTrip.TripID <= 0)
                MessageBox.Show("TripID value is null or wrong !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (grvTripDetails.DataRowCount > 1)
                MessageBox.Show(string.Format("You must delete all details before delete this {0} !", currentTrip.TripNumber), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (this.HasSendNavi())
                {
                    MessageBox.Show("This trip has send to Navi, you could't modify data !", "TWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Are you sure to delete?", "TPWMS", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    DataProcess<Object> stStripDeleteUpdateDA = new DataProcess<object>();
                    int queryResult = stStripDeleteUpdateDA.ExecuteNoQuery("STTripDeleteUpdate @TripID={0},@Flag={1}", currentTrip.TripID, 0);
                    this.currentTrip = new ST_WMS_LoadTripsManagement_Result();
                    this.BindData();
                    this.InitNewTrip();
                    this.LoadEmployeeWorking();
                }
            }
        }

        private void bbtnAddAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Are you sure to add all", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!currentTrip.TripConfirmed)
                {
                    DataProcess<object> STTripInsertAll_Process = new DataProcess<object>();
                    int STTripInsertAll_Result = STTripInsertAll_Process.ExecuteNoQuery("STTripInsertAll @TripID={0},@CustomerMainID={1},@TripDate={2},@UserName={3}",
                        currentTrip.TripID, currentTrip.CustomerMainID, currentTrip.TripDate.ToString("yyyy-MM-dd"), currentTrip.CreatedBy);
                    this.LoadTripDetails();
                }
            }
        }

        private void deTripDate_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            this.ChangeTripDate((DateTime)e.Value);
        }

        private void bbtnViewMultiNote_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataProcess<STDispatchingNote_Client_Trip_Result> DispatchingNoteClientTripProcess = new DataProcess<STDispatchingNote_Client_Trip_Result>();
            IEnumerable<STDispatchingNote_Client_Trip_Result> DispatchingNoteClientTripData = DispatchingNoteClientTripProcess.Executing("STDispatchingNote_Client_Trip @TripID={0}", currentTrip.TripID);
            DataProcess<Customers> customerDa = new DataProcess<Customers>();
            string CustomerType = customerDa.Select(c => c.CustomerID == currentTrip.CustomerID).FirstOrDefault().CustomerType;
            if (CustomerType == CustomerTypeEnum.RANDOM_WEIGHT)
            {
                rptDispatchingNote_Trip report = new rptDispatchingNote_Trip();
                report.DataSource = DispatchingNoteClientTripData;
                report.Parameters["Barcode"].Value = "DO" + DispatchingNoteClientTripData.ElementAt(0).DispatchingOrderID.ToString("D9");
                ReportPrintToolWMS PrintTool = new ReportPrintToolWMS(report);
                PrintTool.ShowPreview();
            }
            printMultiNote(true);
        }

        private void bbtnMultiNote_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            printMultiNote(false);
        }

        private void printMultiNote(bool isPreview)
        {
            int cusID = Convert.ToInt32(currentTrip.CustomerID);
            if ((HandlingOvertimeCheck(cusID) > 0) && (currentTrip.HandlingOvertimeCategoryID == null))
            {
                lkeServiceNumber.ShowPopup();
            }
            else if ((HandlingOvertimeCheck(cusID) == 0) && (currentTrip.HandlingOvertimeCategoryID != 346) && (currentTrip.HandlingOvertimeCategoryID != null))
            {
                MessageBox.Show("Please check services of this customer!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else if ((HandlingOvertimeCheck(cusID) == 0) && (currentTrip.HandlingOvertimeCategoryID == null))
            {
                lkeServiceNumber.ShowPopup();
            }

            if (currentTrip.TripID <= 0)
                MessageBox.Show("An error was encountered. Please return to the close form and try again.", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (grvTripDetails.RowCount <= 0)
                MessageBox.Show("No data. Please enter details!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                //tripDetailsList.RemoveAt(tripDetailsList.Count - 1);
                foreach (var element in tripDetailsList)
                {
                    if (element.TripDetailID <= 0 || string.IsNullOrEmpty(element.OrderNumber)) continue;
                    if (element.OrderNumber.Substring(0, 2).ToUpper() == "DO")
                    {
                        int DispatchingOrderID = int.Parse(element.OrderNumber.Substring(3));

                        using (SwireDBEntities db = new SwireDBEntities())
                        {
                            var Result = FileProcess.LoadTable("STDispatchingNote @varDispatchingOrderID=" + DispatchingOrderID);
                            string CustomerType = AppSetting.CustomerList.Where(Customer => Customer.CustomerID == currentTrip.CustomerID).SingleOrDefault().CustomerType;
                            if (CustomerType == CustomerTypeEnum.RANDOM_WEIGHT)
                            {
                                rptDispatchingNote_UnitWeight report = new rptDispatchingNote_UnitWeight();
                                report.Parameters["varCurrentUser"].Value = fullInfoEmployees.FullName;
                                report.Parameters["Barcode"].Value = "DO" + DispatchingOrderID.ToString("D9");
                                report.RequestParameters = false;
                                report.DataSource = Result;
                                ReportPrintToolWMS printTool = new ReportPrintToolWMS(report);
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
                                rptDispatchingNote report = new rptDispatchingNote();
                                report.DataSource = Result;
                                report.Parameters["varCurrentUser"].Value = fullInfoEmployees.FullName;
                                report.Parameters["Barcode"].Value = "DO" + DispatchingOrderID.ToString("D9");
                                report.RequestParameters = false;
                                ReportPrintToolWMS printTool = new ReportPrintToolWMS(report);
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
                        }
                    }
                }
            }
        }

        private void bbtnNoteDetails_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            printNoteDetail(false);
        }

        private void printNoteDetail(bool isPreview)
        {
            var currentCustomer = AppSetting.CustomerList.Where(c => c.CustomerID == currentTrip.CustomerID).FirstOrDefault();
            //Kiểm tra KH đã bill
            using (SwireDBEntities db = new SwireDBEntities())
            {
                var billFinds = db.Billings.Where(Billing => Billing.IsDeleted == false && Billing.CustomerID == currentTrip.CustomerID).ToList();
                if (billFinds != null && billFinds.Count() > 0)
                {
                    var billingtoDate = billFinds.Max(Billing => Billing.BillingToDate);
                    if (billingtoDate != null)
                    {
                        int ComparingResult = currentTrip.TripDate.CompareTo(billingtoDate);
                        if (ComparingResult <= 0)
                        {
                            MessageBox.Show("This customer is billed! Can not confirm !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }
            }
            //Kết thúc "kiểm tra KH đã bill"

            //Kiểm tra quyền hạn của người dùng
            Customers ValidCustomer = AppSetting.CustomerList.Where(Customer => Customer.Hold == true && Customer.CustomerMainID == currentTrip.CustomerMainID).SingleOrDefault();

            //Xử lý thông tin, store procedure, report
            int cusID = Convert.ToInt32(currentTrip.CustomerID);
            if ((HandlingOvertimeCheck(cusID) > 0) && (currentTrip.HandlingOvertimeCategoryID == null))
                lkeServiceNumber.ShowPopup();
            else if ((HandlingOvertimeCheck(cusID) == 0) && (currentTrip.HandlingOvertimeCategoryID != 346) && (currentTrip.HandlingOvertimeCategoryID != null))
            {
                MessageBox.Show("Please check services of this customer!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if ((HandlingOvertimeCheck(cusID) == 0) && (currentTrip.HandlingOvertimeCategoryID == null))
            {
                lkeServiceNumber.ShowPopup();
                return;
            }

            if (currentTrip.TripID <= 0)
            {
                MessageBox.Show("An error was encountered. Please return to the close form and try again.", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else if (tripDetailsList.Count() == 0)
                MessageBox.Show("No data. Please enter details!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                IList<ST_WMS_LoadTripManagementDetails_Result> TripDetailsOrderByOrderNumber = tripDetailsList.OrderBy(TripDetails => TripDetails.OrderNumber).ToList();
                TripDetailsOrderByOrderNumber.Remove(TripDetailsOrderByOrderNumber.FirstOrDefault());
                foreach (var element in TripDetailsOrderByOrderNumber)
                {
                    if (element.OrderNumber.Substring(0, 2).ToUpper() == "DO")
                    {
                        int DispatchingOrderID = int.Parse(element.OrderNumber.Substring(3));
                        int ComparingResult = currentTrip.TripDate.Date.CompareTo(DateTime.Now.Date.AddDays(-7));
                        var Result = new object();
                        if (ComparingResult > 0)
                        {
                            Result = FileProcess.LoadTable("STDispatchingNote_Pcs @varDispatchingOrderID=" + DispatchingOrderID);

                        }
                        else
                        {
                            Result = FileProcess.LoadTable("STDispatchingNote_OldDetails @varDispatchingOrderID=" + DispatchingOrderID);
                        }
                        string CustomerType = AppSetting.CustomerList.Where(Customer => Customer.CustomerID == currentTrip.CustomerID).FirstOrDefault().CustomerType;
                        //if (CustomerType == CustomerTypeEnum.RANDOM_WEIGHT)
                        //{
                        //    rptDispatchingNote_UnitWeight report = new rptDispatchingNote_UnitWeight();
                        //    report.Parameters["varCurrentUser"].Value = fullInfoEmployees.FullName;
                        //    report.Parameters["varLoginUser"].Value = AppSetting.CurrentUser.LoginName;
                        //    report.RequestParameters = false;
                        //    report.DataSource = Result;
                        //    ReportPrintToolWMS printTool = new ReportPrintToolWMS(report);
                        //    if (isPreview)
                        //    {
                        //        printTool.ShowPreview();
                        //    }
                        //    else
                        //    {
                        //        printTool.Print();
                        //    }
                        //}
                        //else 
                        if (CustomerType == CustomerTypeEnum.PCS)
                        {
                            rptDispatchingNote_pcs report = new rptDispatchingNote_pcs();
                            report.Parameters["varCurrentUser"].Value = fullInfoEmployees.FullName;
                            report.Parameters["varLoginUser"].Value = AppSetting.CurrentUser.LoginName;
                            report.Parameters["Barcode"].Value = "DO" + DispatchingOrderID.ToString("D9");
                            report.RequestParameters = false;
                            report.DataSource = Result;
                            ReportPrintToolWMS printTool = new ReportPrintToolWMS(report);
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
                            rptDispatchingNoteDetails report = new rptDispatchingNoteDetails((int)currentCustomer.CustomerMainID);
                            report.Parameters["varCurrentUser"].Value = fullInfoEmployees.FullName;
                            report.Parameters["varLoginUser"].Value = AppSetting.CurrentUser.LoginName;
                            report.Parameters["Barcode"].Value = "DO" + DispatchingOrderID.ToString("D9");
                            report.RequestParameters = false;
                            report.DataSource = Result;
                            ReportPrintToolWMS printTool = new ReportPrintToolWMS(report);
                            if (isPreview)
                            {
                                printTool.ShowPreview();
                            }
                            else
                            {
                                printTool.Print();
                            }
                        }
                    }
                }
            }
        }

        private void bbtnMultiPlan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            printMultiPlan(false);
        }

        private void printMultiPlan(bool isPreview)
        {

            if (currentTrip.TripID <= 0)
                MessageBox.Show("An error was encountered. Please return to the close form and try again.", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (tripDetailsList.Count() == 0)
                MessageBox.Show("No data. Please enter details!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                IList<ST_WMS_LoadTripManagementDetails_Result> TripDetailsOrderByOrderNumber = tripDetailsList.OrderBy(TripDetails => TripDetails.OrderNumber).ToList();
                TripDetailsOrderByOrderNumber.Remove(TripDetailsOrderByOrderNumber.FirstOrDefault());
                foreach (ST_WMS_LoadTripManagementDetails_Result element in TripDetailsOrderByOrderNumber)
                {
                    if (element.OrderNumber.Substring(0, 2).ToUpper() == "DO")
                    {
                        int DispatchingOrderID = int.Parse(element.OrderNumber.Substring(3));

                        using (SwireDBEntities db = new SwireDBEntities())
                        {
                            var Result = new object();
                            Result = FileProcess.LoadTable("STDispatchingPlanReportNew @varDispatchingOrderID=" + DispatchingOrderID);
                            DataProcess<STCustomerRequirementPrint_Result> cusRequireDA = new DataProcess<STCustomerRequirementPrint_Result>();
                            DataTable customerRequired = FileProcess.LoadTable("STCustomerRequirementPrint @CustomerMainID=" + currentTrip.CustomerMainID + ",@Flag=2, @ReceivingOrderID=null");
                            string customerRequire = "";
                            string CustomerType = AppSetting.CustomerList.Where(Customer => Customer.CustomerID == currentTrip.CustomerID).SingleOrDefault().CustomerType;
                            foreach (DataRow row in customerRequired.Rows)
                            {
                                customerRequire += row["RequirementDetails"].ToString();
                            }
                            if (CustomerType == CustomerTypeEnum.RANDOM_WEIGHT)
                            {

                                rptDispatchingPlanA4New dPlanA4 = new rptDispatchingPlanA4New();
                                dPlanA4.DataSource = Result;
                                if (customerRequired != null)
                                {
                                    dPlanA4.Parameters["varCustomerRequired"].Value = customerRequire;
                                }
                                #region
                                //dPlanA4.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
                                //dPlanA4.xrPalletID.Visible = true;
                                //dPlanA4.xrKgs.Visible = false;
                                //dPlanA4.xrUnit.Visible = true;
                                //dPlanA4.xrWeight.Visible = true;
                                //dPlanA4.xrCtnPcs.Visible = true;
                                //dPlanA4.xrPro_.Visible = false;
                                //dPlanA4.xrExp.Visible = false;
                                //dPlanA4.xrTon.Visible = false;
                                //dPlanA4.xrSoLuong.Visible = false;
                                //dPlanA4.xrhCtn.Visible = true;
                                //dPlanA4.xrhUn.Visible = true;
                                //// hide group header
                                //dPlanA4.xrhSumPalletWeight.Visible = true;
                                //dPlanA4.xrhSumUnitQty.Visible = true;
                                //dPlanA4.xrhWeigth.Visible = false;
                                //// visible ctn
                                //dPlanA4.xrhKgCtn.Visible = true;
                                //dPlanA4.xrhWeightPerPackage.Visible = false;
                                //// dPlanA4.xrhUseByDate.Visible = false;
                                //dPlanA4.xrhSumWeightPerPackage.Visible = false;
                                //// show colum detail
                                //dPlanA4.xrdQtyPackageModInner.Visible = false;
                                //dPlanA4.xrdQtyPackageQuotieInner.Visible = false;
                                //dPlanA4.xrdPalletWeight.Visible = true;
                                //dPlanA4.xrdPalletWeightAvg.Visible = true;
                                //dPlanA4.xrdProductDate.Visible = true;
                                //dPlanA4.xrdUseByDate.Visible = true;
                                //dPlanA4.xrhTon.Visible = true;
                                //dPlanA4.xrdUnitQty.Visible = true;
                                //dPlanA4.xrhWeigth.Visible = true;
                                //dPlanA4.xrhWeightPerPackage.Visible = false;
                                //dPlanA4.xrLine40.Visible = false;
                                //dPlanA4.xrnhietDo.Visible = false;
                                //dPlanA4.xrTemperature.Visible = false;
                                //dPlanA4.xrhRemain.Visible = false;
                                //dPlanA4.xrLine39.Visible = false;
                                //dPlanA4.xrhKgs.Visible = true;
                                //// rename text
                                //dPlanA4.xrCtnPcs.Text = "Ctn";

                                //// move postion and resize xrh & xrd
                                //dPlanA4.xrhKgCtn.LocationF = new PointF(dPlanA4.xrhKgCtn.LocationF.X + 20, dPlanA4.xrhKgCtn.LocationF.Y);
                                //dPlanA4.xrUnit.LocationF = new PointF(dPlanA4.xrUnit.LocationF.X + 100, dPlanA4.xrUnit.LocationF.Y);
                                //dPlanA4.xrExp.LocationF = new PointF(dPlanA4.xrExp.LocationF.X + 30, dPlanA4.xrExp.LocationF.Y);
                                //dPlanA4.xrCtnPcs.LocationF = new PointF(dPlanA4.xrCtnPcs.LocationF.X - 20, dPlanA4.xrCtnPcs.LocationF.Y);
                                //dPlanA4.xrPalletID.LocationF = new PointF(dPlanA4.xrPalletID.LocationF.X + 50, dPlanA4.xrPalletID.LocationF.Y);
                                //dPlanA4.xrWeight.LocationF = new PointF(dPlanA4.xrWeight.LocationF.X + 130, dPlanA4.xrWeight.LocationF.Y);
                                //dPlanA4.xrdPalletWeight.LocationF = new PointF(dPlanA4.xrdPalletWeight.LocationF.X + 30, dPlanA4.xrdPalletWeight.LocationF.Y);
                                //dPlanA4.xrdDispatchingLocationRemark.WidthF = 150F;

                                //dPlanA4.xrdQtyPackageModInner.LocationF = new PointF(dPlanA4.xrdQtyPackageModInner.LocationF.X + 20, dPlanA4.xrdQtyPackageModInner.LocationF.Y);
                                //dPlanA4.xrdQtyPackageQuotieInner.LocationF = new PointF(dPlanA4.xrdQtyPackageQuotieInner.LocationF.X + 20, dPlanA4.xrdQtyPackageQuotieInner.LocationF.Y);

                                ////product date, usebydate
                                //dPlanA4.xrdProductDate.LocationF = new PointF(dPlanA4.xrdProductDate.LocationF.X + 140, dPlanA4.xrdProductDate.LocationF.Y);
                                //dPlanA4.xrdUseByDate.LocationF = new PointF(dPlanA4.xrdProductDate.LocationF.X + 60, dPlanA4.xrdProductDate.LocationF.Y);

                                //dPlanA4.xrProductName.WidthF = 250F;
                                //dPlanA4.xrProductName.LocationF = new PointF(dPlanA4.xrProductName.LocationF.X - 10, dPlanA4.xrProductName.LocationF.Y);
                                //dPlanA4.xrdPalletID.LocationF = new PointF(dPlanA4.xrdPalletID.LocationF.X + 50, dPlanA4.xrdPalletID.LocationF.Y);


                                //dPlanA4.xrhCtn.LocationF = new PointF(dPlanA4.xrhCtn.LocationF.X - 70, dPlanA4.xrhCtn.LocationF.Y);
                                //dPlanA4.xrhSumUnitQty.WidthF = dPlanA4.xrhSumUnitQty.WidthF + 10;
                                //dPlanA4.xrhSumUnitQty.LocationF = new PointF(dPlanA4.xrhSumUnitQty.LocationF.X - 70, dPlanA4.xrhSumUnitQty.LocationF.Y);
                                //dPlanA4.xrhWeightPPackage.LocationF = new PointF(dPlanA4.xrhWeightPPackage.LocationF.X - 30, dPlanA4.xrhWeightPPackage.LocationF.Y);

                                //dPlanA4.xrhUn.LocationF = new PointF(dPlanA4.xrhUn.LocationF.X - 50, dPlanA4.xrhUn.LocationF.Y);
                                //dPlanA4.xrhKgCtn.LocationF = new PointF(dPlanA4.xrhKgCtn.LocationF.X - 20, dPlanA4.xrhKgCtn.LocationF.Y);
                                //dPlanA4.GroupHeader1.LocationF = new PointF(dPlanA4.GroupHeader1.LocationF.X, dPlanA4.GroupHeader1.LocationF.Y + 20);

                                //dPlanA4.xrdRemark.WidthF = dPlanA4.xrdRemark.WidthF + 50;
                                //dPlanA4.xrdQtyOfPackage.LocationF = new PointF(dPlanA4.xrdQtyOfPackage.LocationF.X + 40, dPlanA4.xrdQtyOfPackage.LocationF.Y);
                                //dPlanA4.xrdRemainByProduct.LocationF = new PointF(dPlanA4.xrdRemainByProduct.LocationF.X + 10, dPlanA4.xrdRemainByProduct.LocationF.Y);
                                //dPlanA4.xrdUnitQty.LocationF = new PointF(dPlanA4.xrdUnitQty.LocationF.X - 140, dPlanA4.xrdUnitQty.LocationF.Y);
                                //dPlanA4.xrhSumQtyOfPackage.LocationF = new PointF(dPlanA4.xrhSumQtyOfPackage.LocationF.X - 90, dPlanA4.xrhSumQtyOfPackage.LocationF.Y);
                                //dPlanA4.xrdRemark.LocationF = new PointF(dPlanA4.xrdRemark.LocationF.X + 25, dPlanA4.xrdRemark.LocationF.Y);
                                #endregion

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
                                // get source report
                                DataTable dt = new DataTable();
                                dt = (DataTable)Result;
                                string strDO = dt.Rows[0][0].ToString();
                                dPlanA4.RequestParameters = false;
                                //nghia 04/05/2019
                                dPlanA4.bcDispatching.Text = strDO;
                                // dPlanA4.bcDispatching.Text = "*" + strDO + "*";
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
                            else
                            {
                                rptDispatchingPlanA4New dPlanA4 = new rptDispatchingPlanA4New();
                                dPlanA4.RequestParameters = false;
                                if (customerRequired != null)
                                {
                                    dPlanA4.Parameters["varCustomerRequired"].Value = customerRequire;
                                }
                                dPlanA4.DataSource = Result;
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
                                dPlanA4.xrhSumWeightPerPackage.Visible = false;
                                dPlanA4.xrhSumPalletWeight.Visible = false;

                                // hide colum detail
                                dPlanA4.xrdQtyPackageModInner.Visible = false;
                                dPlanA4.xrdQtyPackageQuotieInner.Visible = false;
                                dPlanA4.xrdPalletWeight.Visible = false;

                                // move postion and resize xrlabel
                                dPlanA4.xrdDispatchingLocationRemark.WidthF = 160F;
                                dPlanA4.xrdPalletID.WidthF = dPlanA4.xrdPalletID.WidthF + 10;
                                dPlanA4.xrdPalletID.LocationF = new PointF(dPlanA4.xrdPalletID.LocationF.X + 70, dPlanA4.xrdPalletID.LocationF.Y);
                                dPlanA4.xrdQtyOfPackage.LocationF = new PointF(dPlanA4.xrdQtyOfPackage.LocationF.X + 60, dPlanA4.xrdQtyOfPackage.LocationF.Y);
                                dPlanA4.xrdProductDate.LocationF = new PointF(dPlanA4.xrdProductDate.LocationF.X + 50, dPlanA4.xrdProductDate.LocationF.Y);
                                dPlanA4.xrdUseByDate.LocationF = new PointF(dPlanA4.xrdUseByDate.LocationF.X + 50, dPlanA4.xrdUseByDate.LocationF.Y);

                                DataTable dt = new DataTable();
                                string strDO = string.Empty;
                                dt = (DataTable)Result;
                                if (dt != null && dt.Rows.Count > 0)
                                {
                                    strDO = dt.Rows[0][0].ToString();
                                }

                                dPlanA4.RequestParameters = false;
                                //dPlanA4.bcDispatching.Text = "*" + strDO + "*";
                                //nghia 04/05/2019
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
                        }
                    }
                }
            }
        }

        private void bbtnMultiPickOrPlan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ProcessPintPickOrPlan(false);
        }

        private void ProcessPintPickOrPlan(bool isPreview)
        {
            if (currentTrip.TripID <= 0)
                MessageBox.Show("An error was encountered. Please return to the close form and try again.", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (tripDetailsList.Count() == 0)
                MessageBox.Show("No data. Please enter details!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                IList<ST_WMS_LoadTripManagementDetails_Result> TripDetailsOrderByOrderNumber = tripDetailsList.OrderBy(TripDetails => TripDetails.OrderNumber).ToList();
                foreach (ST_WMS_LoadTripManagementDetails_Result element in TripDetailsOrderByOrderNumber)
                {
                    if (element.OrderNumber == null) continue;
                    if (element.OrderNumber.Substring(0, 2).ToUpper() == "DO")
                    {
                        int DispatchingOrderID = int.Parse(element.OrderNumber.Substring(3));
                        //If Not Me.ToggleConfirm Then
                        //    DoCmd.RunCommand acCmdSaveRecord
                        //End If
                        using (SwireDBEntities db = new SwireDBEntities())
                        {
                            bool? CustomerByExpiryDate = AppSetting.CustomerList.Where(Customer => Customer.CustomerID == currentTrip.CustomerMainID).FirstOrDefault().CustomerByExpiryDate;
                            if (CustomerByExpiryDate == true)
                            {
                                DataTable qryLabel1RO = FileProcess.LoadTable("STLabelRemainPickingSlip @DispatchingOrderID =" + DispatchingOrderID);
                                if (qryLabel1RO.Rows.Count > 0)
                                {
                                    rptLabelA4Short_Barcode report = new rptLabelA4Short_Barcode();
                                    report.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
                                    report.Parameters["parameter1"].Value = 2;
                                    report.DataSource = qryLabel1RO;
                                    //  report.bcPalletID.Text = "*" + qryLabel1RO.Rows[0][0].ToString() + "*";
                                    ReportPrintToolWMS PrintTool = new ReportPrintToolWMS(report);
                                }
                                this.printPickOrPlan(isPreview, DispatchingOrderID);
                            }
                        }
                    }
                }
            }
        }

        private void printPickOrPlan(bool isPreview, int dispatchingOrderID)
        {
            Customers cus = AppSetting.CustomerList.Where(c => c.CustomerID == (int)lkeCustomerNumber.EditValue).FirstOrDefault();
            DataProcess<CustomerRequirements> customerR = new DataProcess<CustomerRequirements>();
            CustomerRequirements customerRequired = customerR.Executing("SELECT * FROM  CustomerRequirements WHERE (CustomerMainID = " + cus.CustomerMainID + ") AND (RequirementConfirmed = 1) And(RequirementCategory=2) ORDER BY UpdateTime ASC").FirstOrDefault();
            DataProcess<STPickingSlipWithPalletID_Result> pickingSlip = new DataProcess<STPickingSlipWithPalletID_Result>();
            var dataSoure = pickingSlip.Executing("STPickingSlipWithPalletID @varDispatchingOrderID={0}", dispatchingOrderID);

            rptPickingSlipA4 rptPickingslipA4 = new rptPickingSlipA4();
            rptPickingslipA4.Parameters["varDispatchingOrderID"].Value = dispatchingOrderID;
            rptPickingslipA4.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
            rptPickingslipA4.Parameters["parameter1"].Value = 1;
            rptPickingslipA4.RequestParameters = false;
            rptPickingslipA4.DataSource = dataSoure;

            rptDispatchingPlanA4New dPlanA4 = new rptDispatchingPlanA4New();
            dPlanA4.Parameters["varDispatchingOrderID"].Value = dispatchingOrderID;
            dPlanA4.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;

            var dataSource = FileProcess.LoadTable("STDispatchingPlanReportNew  @varDispatchingOrderID=" + dispatchingOrderID);// loi 
            dPlanA4.DataSource = dataSource;
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
            dPlanA4.xrdPalletWeight.Visible = false;

            // move postion and resize xrlabel
            dPlanA4.xrdDispatchingLocationRemark.WidthF = 160F;
            dPlanA4.xrdPalletID.WidthF = dPlanA4.xrdPalletID.WidthF + 10;
            dPlanA4.xrdPalletID.LocationF = new PointF(dPlanA4.xrdPalletID.LocationF.X + 70, dPlanA4.xrdPalletID.LocationF.Y);
            dPlanA4.xrdQtyOfPackage.LocationF = new PointF(dPlanA4.xrdQtyOfPackage.LocationF.X + 60, dPlanA4.xrdQtyOfPackage.LocationF.Y);
            dPlanA4.xrdProductDate.LocationF = new PointF(dPlanA4.xrdProductDate.LocationF.X + 50, dPlanA4.xrdProductDate.LocationF.Y);
            dPlanA4.xrdUseByDate.LocationF = new PointF(dPlanA4.xrdUseByDate.LocationF.X + 50, dPlanA4.xrdUseByDate.LocationF.Y);

            if (dataSource == null || dataSource.Rows.Count <= 0)
            {
                MessageBox.Show("No data to print!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string strDO = Convert.ToString(dataSource.Rows[0]["DispatchingOrderID_Barcode"]);
            dPlanA4.bcDispatching.Text = "*" + strDO + "*";
            //dPlanA4.bcDispatching.Text = strDO;// dasua 
            dPlanA4.CreateDocument();
            rptPickingslipA4.CreateDocument();
            rptPickingslipA4.Pages.AddRange(dPlanA4.Pages);
            rptPickingslipA4.PrintingSystem.ContinuousPageNumbering = true;
            ReportPrintToolWMS printTool = null;
            if (cus.CustomerType.Equals(CustomerTypeEnum.PCS))
            {
                rptPickingSlipA4_pcs dPlanA4pcs = new rptPickingSlipA4_pcs();
                dPlanA4pcs.Parameters["varDispatchingOrderID"].Value = dispatchingOrderID;
                dPlanA4pcs.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
                dPlanA4pcs.Parameters["parameter1"].Value = 1;
                dPlanA4pcs.RequestParameters = false;
                dPlanA4pcs.DataSource = dataSoure;

                dPlanA4pcs.CreateDocument();
                dPlanA4pcs.Pages.AddRange(dPlanA4.Pages);
                dPlanA4pcs.PrintingSystem.ContinuousPageNumbering = true;
                printTool = new ReportPrintToolWMS(dPlanA4pcs);
            }
            else
            {
                printTool = new ReportPrintToolWMS(rptPickingslipA4);
            }


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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            isNewTrip = true;
            bbtnDeleteTrip.Enabled = true;
            bbtnDeleteRecord.Enabled = true;
            bbtnConfirm.Enabled = true;
            bbtnAddAll.Enabled = true;
            bbtnSplitTrip.Enabled = true;
            lkeOneClient.ReadOnly = false;
            this.lke_Transporter.ReadOnly = false;
            lkeServiceNumber.ReadOnly = false;
            teServiceName.ReadOnly = false;
            lkeCustomerNumber.ReadOnly = false;
            teCustomerName.ReadOnly = false;
            teTripID.EditValue = "";

            deTripDate.EditValue = DateTime.Now.Date;
            teCreateBy.EditValue = AppSetting.CurrentUser.LoginName;
            teTemp.EditValue = null;
            teSeal.EditValue = null;
            this.textEditTripOrderProgress.EditValue = null;
            this.lkeDockNumber.EditValue = null;
            this.txtVehicleNumber.Text = string.Empty;
            this.deRoadStart.EditValue = null;
            this.deRoadEnd.EditValue = null;
            memoTruckAndDetails.EditValue = null;
            teInternal.EditValue = null;

            lkeCustomerNumber.ShowPopup();
            this.lkeCustomerNumber.Focus();
        }

        private void grvTripDetails_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            switch (e.Column.FieldName)
            {
                case "OrderNumber":
                    string selectedOrderNumber = Convert.ToString(this.grvTripDetails.GetRowCellValue(this.grvTripDetails.FocusedRowHandle, "OrderNumber"));

                    // Check is new row
                    if (string.IsNullOrEmpty(selectedOrderNumber))
                    {
                        DataProcess<STTripDO_Result> tripDO_DA = new DataProcess<STTripDO_Result>();
                        var dataSource = tripDO_DA.Executing("STTripDO @CustomerMainID={0},@TripDate={1}", currentTrip.CustomerMainID, currentTrip.TripDate.Date);
                        ri_lke_OrderNumber.DataSource = dataSource;
                        ri_lke_OrderNumber.DisplayMember = "DispatchingOrderNumber";
                        ri_lke_OrderNumber.ValueMember = "DispatchingOrderNumber";
                        ri_lke_OrderNumber.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
                        ri_lke_OrderNumber.PopupSizeable = true;
                        ri_lke_OrderNumber.PopupWidthMode = PopupWidthMode.UseEditorWidth;
                        ri_lke_OrderNumber.ShowHeader = false;
                        ri_lke_OrderNumber.ShowFooter = false;
                        ri_lke_OrderNumber.PopupWidth = 600;
                        if (dataSource.Count() > 20)
                        {
                            ri_lke_OrderNumber.DropDownRows = 20;
                        }
                        else
                        {
                            ri_lke_OrderNumber.DropDownRows = dataSource.Count();
                        }
                        this.colDispatchingOrderList.OptionsColumn.AllowFocus = true;
                        this.grvTripDetails.FocusedColumn = this.colDispatchingOrderList;
                        this.grvTripDetails.ShowEditor();
                    }
                    break;
            }
        }

        private void grvTripDetails_DoubleClick(object sender, EventArgs e)
        {

        }

        private void lkeServiceNumber_DoubleClick(object sender, EventArgs e)
        {
            if (lkeServiceNumber.ReadOnly) return;
            using (SwireDBEntities DatabaseContext = new SwireDBEntities())
            {
                ObjectParameter HW_OT_CatID = new ObjectParameter("HW_OT_CatID", typeof(int));
                int STCustomerByOvertimeCheckingTime_Result = DatabaseContext.STCustomerByOvertimeCheckingTime(currentTrip.TripNumber, currentTrip.CustomerID, HW_OT_CatID);
                if (HW_OT_CatID.Value != null)
                {
                    int HW_OT_CatIDValue = Convert.ToInt32(HW_OT_CatID.Value);
                    DataProcess<STComboServiceOvertime_Result> serviceOvertimeDA = new DataProcess<STComboServiceOvertime_Result>();
                    if (HW_OT_CatIDValue == 208)
                        serviceOvertimeList = serviceOvertimeDA.Executing("STComboServiceOvertime @CustomerID={0},@ServiceName=Normal", currentTrip.CustomerID);
                    else if (HW_OT_CatIDValue == 209)
                        serviceOvertimeList = serviceOvertimeDA.Executing("STComboServiceOvertime @CustomerID={0},@ServiceName=Sunday", currentTrip.CustomerID);
                    else if (HW_OT_CatIDValue == 210)
                        serviceOvertimeList = serviceOvertimeDA.Executing("STComboServiceOvertime @CustomerID={0},@ServiceName=Holiday", currentTrip.CustomerID);
                    else if (HW_OT_CatIDValue == 0)
                        serviceOvertimeList = serviceOvertimeDA.Executing("STComboServiceOvertime @CustomerID={0},@ServiceName=HN", currentTrip.CustomerID);
                }
            }
            lkeServiceNumber.Properties.DataSource = serviceOvertimeList;
            this.lkeServiceNumber.Properties.PopulateColumns();
            if (serviceOvertimeList.Count() < 20)
                lkeServiceNumber.Properties.DropDownRows = serviceOvertimeList.Count();
            else
                lkeServiceNumber.Properties.DropDownRows = 20;
            lkeServiceNumber.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
            lkeServiceNumber.Properties.DisplayMember = "ServiceNumber";
            lkeServiceNumber.Properties.ValueMember = "ServiceID";
            lkeServiceNumber.ShowPopup();
        }

        private void lkeCustomerNumber_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            if (e.CloseMode == PopupCloseMode.Normal)
            {
                byte processOrder = 0;
                if (this.textEditTripOrderProgress.EditValue != null) processOrder = Convert.ToByte(textEditTripOrderProgress.EditValue);
                //Nếu click NEW để tạo trip mới thì sẽ chạy code này
                if (isNewTrip)
                {
                    int selectedCustomerID = Convert.ToInt32(lkeCustomerNumber.GetColumnValue("CustomerID"));
                    //Sau khi dữ liệu thay đổi ở lkeCustomer. Xác nhận tạo 1 TRIP.
                    Trips newTrip = new Trips();
                    newTrip.TripID = 0;
                    newTrip.TripDate = deTripDate.DateTime;
                    newTrip.TripConfirmed = false;
                    newTrip.CreatedBy = AppSetting.CurrentUser.LoginName;
                    newTrip.CreatedTime = DateTime.Now;
                    newTrip.RouteID = null;
                    newTrip.TripConfirmedTime = null;
                    newTrip.TripRemark = memoTruckAndDetails.EditValue == null ? "" : Convert.ToString(memoTruckAndDetails.EditValue);
                    newTrip.SealNumber = teSeal.EditValue == null ? "" : Convert.ToString(teSeal.EditValue);
                    newTrip.TripOrderProgress = processOrder;
                    newTrip.TS = null;
                    newTrip.StartWorkingTime = null;
                    newTrip.EndWorkingTime = null;
                    newTrip.DockDoorID = this.lkeDockNumber.EditValue == null ? 0 : Convert.ToInt32(this.lkeDockNumber.EditValue);
                    newTrip.HandlingOvertimeCategoryID = null;
                    newTrip.CustomerID = selectedCustomerID;
                    newTrip.Temperature = teTemp.EditValue == null ? "" : Convert.ToString(teTemp.EditValue);
                    newTrip.InternalRemark = teInternal.EditValue == null ? "" : Convert.ToString(teInternal.EditValue);
                    newTrip.DispatchingOrderProgress = null;
                    newTrip.VehicleNumber = this.txtVehicleNumber.Text;
                    if (this.deRoadEnd.EditValue != null) newTrip.OnRoadStartTime = this.deRoadEnd.DateTime;
                    if (this.deRoadStart.EditValue != null) newTrip.OnRoadEndTime = this.deRoadStart.DateTime;
                    DataProcess<Trips> tripsDA = new DataProcess<Trips>();
                    int insertedResult = tripsDA.Insert(newTrip);
                    if (insertedResult > 0)
                    {
                        isNewTrip = false; //Kết thúc tạo TRIP mới
                        this.tripID = newTrip.TripID;
                        LoadTripsInit();
                        LoadTripDetails();
                        LoadEmployeeWorking();

                        InitControls();
                    }
                    else if (insertedResult == 0)
                        MessageBox.Show("Nothing is inserted to database !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                        MessageBox.Show("Inserting new trip to database failed !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    // Update new customer
                    DataProcess<object> tripDA = new DataProcess<object>();
                    int selectedCustomerID = Convert.ToInt32(lkeCustomerNumber.GetColumnValue("CustomerID"));
                    tripDA.ExecuteNoQuery("Update Trips Set Trips.CustomerID = {0} Where Trips.TripID = {1}", selectedCustomerID, currentTrip.TripID);
                }

            }
        }

        private void lkeCustomerNumber_EditValueChanged(object sender, EventArgs e)
        {
            if (lkeCustomerNumber.GetColumnValue("CustomerName") != null)
                teCustomerName.Text = lkeCustomerNumber.GetColumnValue("CustomerName").ToString();
        }

        private void ri_lke_OrderNumber_EditValueChanged(object sender, EventArgs e)
        {
            var selectedValue = (DevExpress.XtraEditors.LookUpEdit)sender;
            int rowHandle = grvTripDetails.FocusedRowHandle;
            if (rowHandle < 0) return;
            STTripDO_Result stTripDO = (STTripDO_Result)this.ri_lke_OrderNumber.GetDataSourceRowByKeyValue(selectedValue.Text);
            if (stTripDO == null) return;
            grvTripDetails.SetRowCellValue(rowHandle, grdcolOrderNumber, stTripDO.DispatchingOrderNumber);
            grvTripDetails.SetRowCellValue(rowHandle, grdcolCustomer, stTripDO.CustomerNumber);
            grvTripDetails.SetRowCellValue(rowHandle, grdcolPallet, stTripDO.TotalPallets);
            grvTripDetails.SetRowCellValue(rowHandle, grdcolCtns, stTripDO.TotalPackages);
            grvTripDetails.SetRowCellValue(rowHandle, grdcolWeight, stTripDO.TotalWeight);
            grvTripDetails.SetRowCellValue(rowHandle, grdcolRemark, stTripDO.SpecialRequirement);
            grvTripDetails.SetRowCellValue(rowHandle, grdcolClient, stTripDO.CustomerClientID);
            grvTripDetails.SetRowCellValue(rowHandle, grdcolUser, AppSetting.CurrentUser.LoginName);
            grvTripDetails.SetRowCellValue(rowHandle, "CustomerOrderNumber", stTripDO.CustomerOrderNumber);
            grvTripDetails.SetRowCellValue(rowHandle, "CustomerClientID", stTripDO.CustomerClientID);
            grvTripDetails.SetRowCellValue(rowHandle, "TripStatus", 0);

            TripDetails newTripDetails = new TripDetails()
            {
                TripDetailID = 0,
                TripID = currentTrip.TripID,
                CheckDelete = false,
                TotalPackages = stTripDO.TotalPackages,
                TotalPallets = stTripDO.TotalPallets,
                TotalWeight = stTripDO.TotalWeight,
                OrderNumber = stTripDO.DispatchingOrderNumber,
                CustomerOrderNumber = stTripDO.CustomerOrderNumber,
                TripStatus = 0,
                TripDetailRemark = Convert.ToString(this.grvTripDetails.GetRowCellValue(rowHandle, "TripDetailRemark")),
                CustomerNumber = stTripDO.CustomerNumber,
                CreatedBy = AppSetting.CurrentUser.LoginName,
                CreatedTime = DateTime.Now,
                CustomerClientID = stTripDO.CustomerClientID
            };
            DataProcess<TripDetails> tripDetailsDA = new DataProcess<TripDetails>();
            int insertResult = tripDetailsDA.Insert(newTripDetails);

            // reload datasource
            DataProcess<STTripDO_Result> tripDO_DA = new DataProcess<STTripDO_Result>();
            var dataSource = tripDO_DA.Executing("STTripDO @CustomerMainID={0},@TripDate={1}", currentTrip.CustomerMainID, currentTrip.TripDate.Date);
            ri_lke_OrderNumber.DataSource = dataSource;
            ri_lke_OrderNumber.DisplayMember = "DispatchingOrderNumber";
            ri_lke_OrderNumber.ValueMember = "DispatchingOrderNumber";
            ri_lke_OrderNumber.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            ri_lke_OrderNumber.ShowHeader = false;
            ri_lke_OrderNumber.ShowFooter = false;
            if (dataSource.Count() > 20)
            {
                ri_lke_OrderNumber.DropDownRows = 20;
            }
            else
            {
                ri_lke_OrderNumber.DropDownRows = dataSource.Count();
            }

            //**GridView chính nên cần tạo một dòng để cho người dùng thêm dữ liệu.
            DataProcess<ST_WMS_LoadTripManagementDetails_Result> st_WMS_LoadTripManagementDetailsDA = new DataProcess<ST_WMS_LoadTripManagementDetails_Result>();
            tripDetailsList = (IList<ST_WMS_LoadTripManagementDetails_Result>)st_WMS_LoadTripManagementDetailsDA.Executing("ST_WMS_LoadTripManagementDetails @TripID={0}", currentTrip.TripID);
            tripDetailsList.Add(new ST_WMS_LoadTripManagementDetails_Result());
            this.LoadDockDoor(newTripDetails.OrderNumber);
            this.grcTripDetails.DataSource = tripDetailsList;
            this.lkeCustomerNumber.ReadOnly = true;
            this.tripDetailsList[tripDetailsList.Count - 1].TripStatus = 0;
        }

        private int HandlingOvertimeCheck(int customerID)
        {
            int result = 0;
            using (var context = new SwireDBEntities())
            {
                ObjectParameter outPram = new ObjectParameter("ServiceQty", 0);
                context.STCustomerBillingByOvertime(customerID, outPram);
                result = Convert.ToInt32(outPram.Value);
            }
            return result;
        }

        private void bbtnConfirm_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.currentTrip.TripID <= 0) return;
            if (this.lke_Transporter.EditValue == null)
            {
                MessageBox.Show("Please check Transporter of this Trip!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.lke_Transporter.Focus();
                this.lke_Transporter.ShowPopup();
                return;
            }
            if (this.lke_TimeSlotID.EditValue == null || Convert.ToInt32(lke_TimeSlotID.EditValue) <= 0)
            {
                MessageBox.Show("Please update time slot before confirm !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.lke_TimeSlotID.Focus();
                this.lke_TimeSlotID.ShowPopup();
                return;
            }
            if (DOConfirmChecking(currentTrip.TripDate))
            {
                if (MessageBox.Show("Please check before confirm this Trip!", "TPWMS", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                    return;

                int cusID = Convert.ToInt32(currentTrip.CustomerID);
                if (this.lkeServiceNumber.EditValue == null || this.lkeServiceNumber.EditValue.Equals(0))
                {
                    this.lkeServiceNumber.Focus();
                    this.lkeServiceNumber.ShowPopup();
                    return;
                }

                //1.Check overtime
                if (HandlingOvertimeCheck(cusID) > 0 && currentTrip.HandlingOvertimeCategoryID == null)
                {
                    MessageBox.Show("Please check services/Overtime of this customer!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //2.Check overtime is difference 346
                else if (HandlingOvertimeCheck(cusID) == 0 && currentTrip.HandlingOvertimeCategoryID != 346 && currentTrip.HandlingOvertimeCategoryID != null)
                {
                    MessageBox.Show("Please check services/Overtime of this customer!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (HandlingOvertimeCheck(cusID) == 0 && currentTrip.HandlingOvertimeCategoryID == null)
                {
                    lkeServiceNumber.ShowPopup();
                    lkeServiceNumber.Focus();
                }

                // Check Qty sync with wareNavi is equal with qty RODetail send
                int qtyDiff = Convert.ToInt32(FileProcess.LoadTable("STCheckTripQTYSyncBeforeConfirm @TripID=" + this.tripID).Rows[0]["DifferenceQty"]);
                if (qtyDiff > 0)
                {
                    XtraMessageBox.Show("Qty booking and Qty actual is invalid! Please check it before confirm", "TWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                bool? dispatchingByClient = AppSetting.CustomerList.FirstOrDefault(customer => customer.CustomerMainID == currentTrip.CustomerMainID).DispatchingByClient;
                if (dispatchingByClient == true)
                {
                    DataProcess<TripDetails> tripDetailsDA = new DataProcess<TripDetails>();
                    //IList<TripDetails> tripDetailsList = (List<TripDetails>)tripDetailsDA.Select();
                    //TripDetails tripDetail = tripDetailsList.FirstOrDefault(element => element.CustomerClientID == 1 && element.TripID == currentTrip.TripID);

                    var listDetails = tripDetailsDA.Select(a => a.CustomerClientID == 1 && a.TripID == currentTrip.TripID).FirstOrDefault();
                    //if (listDetails == null) return;

                    if (listDetails != null)
                    {
                        MessageBox.Show("This Customer requires Input Client !", "TPWMS");
                        return;
                    }
                }

                //

                int cusmain = AppSetting.CustomerList.Where(c => c.CustomerID == cusID).FirstOrDefault().CustomerMainID;
                var ds = FileProcess.LoadTable("select StartWorkingTime,EndWorkingTime,TripCategory from Trips where TripID =" + this.currentTrip.TripID);
                int tc = Convert.ToInt32(ds.Rows[0]["TripCategory"]);

                if (tc == 0)
                {
                    var ds2 = FileProcess.LoadTable("select DispatchWorkingTime from CustomerWorkingTimeLimits where CustomerMainID =" + cusmain);
                    var dwt = 0;
                    try
                    {
                        dwt = Convert.ToInt32(ds2.Rows[0]["DispatchWorkingTime"]);
                    }
                    catch
                    {
                        dwt = 0;
                    }
                    TimeSpan t = new TimeSpan();
                    if (!string.IsNullOrEmpty(ds.Rows[0]["EndWorkingTime"].ToString()) && !string.IsNullOrEmpty(ds.Rows[0]["StartWorkingTime"].ToString()))
                    {
                        t = Convert.ToDateTime(ds.Rows[0]["EndWorkingTime"]) - Convert.ToDateTime(ds.Rows[0]["StartWorkingTime"]);
                    }
                    double diff = t.TotalMinutes;
                    if (diff > dwt && dwt != 0)
                    {
                        DialogResult q = XtraMessageBox.Show("Please check Dispatch Working Time, It is " + diff + " minutes, but the Customer requires finish in " + dwt + " minutes !" +
                            Environment.NewLine + "Please Inform your Supervisors ! Click No to Cancel the Confirmation Process", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);

                    }

                }
                if (tc == 1)
                {
                    var ds2 = FileProcess.LoadTable("select ReceivingWorkingTime from CustomerWorkingTimeLimits where CustomerMainID =" + cusmain);
                    var rwt = 0;
                    try
                    {
                        rwt = Convert.ToInt32(ds2.Rows[0]["ReceivingWorkingTime"]);
                    }
                    catch
                    {
                        rwt = 0;
                    }

                    TimeSpan t = new TimeSpan();
                    if (!string.IsNullOrEmpty(ds.Rows[0]["EndWorkingTime"].ToString()) && !string.IsNullOrEmpty(ds.Rows[0]["StartWorkingTime"].ToString()))
                    {
                        t = Convert.ToDateTime(ds.Rows[0]["EndWorkingTime"]) - Convert.ToDateTime(ds.Rows[0]["StartWorkingTime"]);
                    }

                    double diff = t.TotalMinutes;
                    if (diff > rwt && rwt != 0)
                    {
                        DialogResult q = XtraMessageBox.Show("Please check Dispatch Working Time, It is " + diff + " minutes, but the Customer requires finish in " + rwt + " minutes !" +
                            Environment.NewLine + "Please Inform your Supervisors ! Click No to Cancel the Confirmation Process", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);

                    }

                }



                DataProcess<object> st_TripDOConfirmAllDA = new DataProcess<object>();
                int spResult = st_TripDOConfirmAllDA.ExecuteNoQuery("STTripDOConfirmAll @TripID={0},@UserName={1}", currentTrip.TripID, AppSetting.CurrentUser.LoginName);

                DataProcess<Trips> tripDA = new DataProcess<Trips>();
                var tripInfo = tripDA.Select(t => t.TripID == currentTrip.TripID).FirstOrDefault();
                tripInfo.TripConfirmed = true;
                tripDA.Update(tripInfo);

                // Update all vehicle number on all DO
                if (!string.IsNullOrEmpty(this.txtVehicleNumber.Text))
                {
                    DataProcess<object> dataProcess = new DataProcess<object>();
                    foreach (var item in this.tripDetailsList)
                    {
                        int result = dataProcess.ExecuteNoQuery("Update DispatchingOrders set VehicleNumber='" + this.txtVehicleNumber.Text
                                            + "' where DispatchingOrderNumber='" + item.OrderNumber + "'");
                    }
                }

                LoadTripsInit();
                LoadTripDetails();
                LoadEmployeeWorking();
                InitControls();
                string ini = AppSetting.CustomerList.Where(c => c.CustomerID == cusID).FirstOrDefault().Initial;
                if (ini != "MCD") return;
                //DialogResult qu = XtraMessageBox.Show("Do you want send mail outlook DO on this Trip?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //if (qu == DialogResult.No) return;
                int orderID = -1;
                string orderNumber = "DO";
                foreach (var item in this.tripDetailsList)
                {
                    try
                    {
                        try
                        {
                            orderNumber = Convert.ToString(item.OrderNumber);
                            orderID = Convert.ToInt32(orderNumber.ToString().Substring(3, orderNumber.Length - 3));
                        }
                        catch
                        {
                            XtraMessageBox.Show("Error ! Order number is null !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        //'Import Dispatching Orders
                        if (orderNumber.ToString().Substring(0, 2) == "DO")
                        {
                            var d = FileProcess.LoadTable("select CustomerClientID from DispatchingOrders where DispatchingOrderID =" + orderID);
                            var cc = Convert.ToInt32(d.Rows[0]["CustomerClientID"]);
                            if (String.IsNullOrEmpty(Convert.ToString(cc)))
                            {
                                XtraMessageBox.Show("This DO does not choose client !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            var d2 = FileProcess.LoadTable("select CustomerClientEmail, CustomerClientCode from CustomerClients where CustomerClientID =" + cc);
                            var clientcode = Convert.ToString(d2.Rows[0]["CustomerClientCode"]);
                            var dataSource = FileProcess.LoadTable("STDispatchingOrderData " + orderID);

                            string ReportName = "DispatchingOrders_" + clientcode + "_" + orderNumber + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
                            string ReportFullFileName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + ReportName + ".xlsx";

                            DevExpress.XtraGrid.GridControl grdReport = new DevExpress.XtraGrid.GridControl();
                            DevExpress.XtraGrid.Views.Grid.GridView grvReport = new DevExpress.XtraGrid.Views.Grid.GridView(grdReport);
                            grdReport.MainView = grvReport;
                            grdReport.ForceInitialize();
                            grdReport.BindingContext = new BindingContext();
                            grdReport.DataSource = dataSource;
                            grvReport.PopulateColumns();

                            grvReport.ExportToXlsx(ReportFullFileName);


                            frm_WM_Attachments.Instance.OrderNumber = orderNumber;
                            if (!frm_WM_Attachments.Instance.Enabled) return;
                            frm_WM_Attachments.Instance.SaveAttachFile(ReportFullFileName, ReportName);

                            SendEmailAllAttachments(orderID, orderNumber);
                        }
                        //'Import Receiving Orders

                    }
                    catch (Exception ex)
                    {

                    }
                }


            }

        }
        private void SendEmailAllAttachments(int orderID, string orderNumber)
        {
            //Check the email of the Customer
            var d = FileProcess.LoadTable("select CustomerClientID from DispatchingOrders where DispatchingOrderID =" + orderID);
            var cc = Convert.ToInt32(d.Rows[0]["CustomerClientID"]);
            if (String.IsNullOrEmpty(Convert.ToString(cc)))
            {
                XtraMessageBox.Show("This DO does not choose client !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var d2 = FileProcess.LoadTable("select CustomerClientEmail, CustomerClientCode from CustomerClients where CustomerClientID =" + cc);
            var email = Convert.ToString(d2.Rows[0]["CustomerClientEmail"]);
            var clientcode = Convert.ToString(d2.Rows[0]["CustomerClientCode"]);
            if (String.IsNullOrEmpty(email))
            {
                XtraMessageBox.Show("This client does not have e-mail address !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            XtraMessageBox.SmartTextWrap = true;
            DialogResult result = XtraMessageBox.Show("Send report to the address : " + email + " ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

                string subject = "KNM DispatchingOrder Report - " + orderNumber;
                string boby = "DispatchingOrder Report From KNM  Logistics Vietnam";

                IList<String> attachments = new List<String>();

                try
                {
                    // Get all attachment of billing
                    DataProcess<Attachments> dataProcess = new DataProcess<Attachments>();
                    var allAttachDB = dataProcess.Select(a => a.OrderNumber == orderNumber && a.IsDeleted == false).OrderByDescending(a => a.AttachmentDate);
                    foreach (var item in allAttachDB)
                    {
                        string attPath = ConfigurationManager.AppSettings["PathPasteFile"] + "\\" + item.AttachmentFile;
                        if (!attachments.Contains(attPath))
                            attachments.Add(attPath);
                    }
                    Common.Process.DataTransfer.SendMailOutlook2(email, subject, boby, attachments.ToArray());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error sending email : " + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace, "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void bbtnUpdateAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (tripDetailsList.Count != 0 && !currentTrip.TripConfirmed)
            {
                if(this.HasSendNavi())
                {
                    MessageBox.Show("This trip has send to Navi, you could't modify data !", "TWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DataProcess<object> stTripDOUpdateAllDA = new DataProcess<object>();
                int queryResult = stTripDOUpdateAllDA.ExecuteNoQuery("STTripDOUpdateAll @TripID={0}", currentTrip.TripID);
                InitControls();
                this.bbtnUpdateAll.Enabled = false;
            }
        }

        private void bbtnSplitTrip_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Convert.ToInt32(grdcolDelete.SummaryItem.DisplayFormat) == 0)
                MessageBox.Show("You must select records to move new trip ?", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (MessageBox.Show("Are you sure to move selected records to new trip ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                int tripIDNew = 0;
                using (var context = new SwireDBEntities())
                {
                    ObjectParameter outPram = new ObjectParameter("TripIDNew", 0);
                    context.STTripSplit(currentTrip.TripID, AppSetting.CurrentUser.LoginName, outPram);
                    tripIDNew = Convert.ToInt32(outPram.Value);
                }
                LoadTripDetails();


                frm_WM_TripsManagement trip = new frm_WM_TripsManagement(tripIDNew);
                trip.WindowState = FormWindowState.Maximized;
                trip.BringToFront();
                trip.Show();
            }
        }

        private void bbtnDeleteRecord_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataProcess<TripDetails> tripDetailsDA = new DataProcess<TripDetails>();
            IList<TripDetails> tripDetails = (IList<TripDetails>)tripDetailsDA.Select(element => element.TripID == currentTrip.TripID && element.CheckDelete == true);
            if (tripDetails.Count == 0)
                MessageBox.Show("Please select DO!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (MessageBox.Show("Are you sure you want to delete records selected!", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (this.HasSendNavi())
                {
                    MessageBox.Show("This trip has send to Navi, you could't modify data !", "TWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataProcess<Object> stStripDeleteUpdate = new DataProcess<object>();
                int spResult = stStripDeleteUpdate.ExecuteNoQuery("STTripDeleteUpdate @TripID={0},@Flag={1}", currentTrip.TripID, 1);
                if (spResult > 0)
                {
                    DataProcess<ST_WMS_LoadTripManagementDetails_Result> st_WMS_LoadTripManagementDetailsDA = new DataProcess<ST_WMS_LoadTripManagementDetails_Result>();
                    tripDetailsList = (IList<ST_WMS_LoadTripManagementDetails_Result>)st_WMS_LoadTripManagementDetailsDA.Executing("ST_WMS_LoadTripManagementDetails @TripID={0}", currentTrip.TripID);
                    tripDetailsList.Add(new ST_WMS_LoadTripManagementDetails_Result());
                    this.grcTripDetails.DataSource = tripDetailsList;
                }
            }
        }

        private void bbtnCreatBooking_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataProcess<CustomerBookings> customerBookingsDA = new DataProcess<CustomerBookings>();
            IEnumerable<CustomerBookings> customerBookings = customerBookingsDA.Select(element => element.OrderNumber == currentTrip.TripNumber);
            if (customerBookings != null)
            {
                if (customerBookings.Count() > 0)
                {
                    MessageBox.Show("The booking was created!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frm_WM_CustomerBookingEntry customerBookingEntryForm = new frm_WM_CustomerBookingEntry();
                    if (!customerBookingEntryForm.Enabled) return;
                    customerBookingEntryForm.ShowDialog();
                }
                else if (MessageBox.Show("Are you sure to create a booking for this trip ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DataProcess<object> stCustomerBookingInsertFromTripDA = new DataProcess<object>();
                    int spResult = stCustomerBookingInsertFromTripDA.ExecuteNoQuery("STCustomerBookingInsertFromTrip @OrderNumber={0},@CreatedBy={1}", currentTrip.TripNumber, AppSetting.CurrentUser.LoginName);
                }
            }
        }
        #endregion

        public bool DOConfirmChecking(DateTime OrderDate)
        {
            //Select Case UserPermission(CurrentUser())
            //    Case 1, 5
            //        Exit Function
            // End Select
            //if(UserPermission.GetLevel().Equals(LevelAuthorizationEnum.Manager) || UserPermission.GetLevel().Equals(LevelAuthorizationEnum.Assistant))
            //{
            //    return false;
            //}

            //if (DateTime.Now.Subtract(OrderDate).Minutes > 30)
            //{
            //    MessageBox.Show("Can not confirm, confirmation time was expired more than 30 minutes !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return false;
            //}
            //else if (OrderDate.CompareTo(DateTime.Now.AddDays(1)) >= 0)
            //{
            //    MessageBox.Show("Can not confirm, incorrect date !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return false;
            //}
            return true;
        }

        private string combineOrder()
        {
            string numberorderlist = "";
            if (tripDetailsList.Select(t => t.CheckDelete == true).Distinct().Count() == 0 && tripDetailsList.Where(e => e.TripID == currentTrip.TripID).Count() == 0)
            {
                MessageBox.Show("You must select at least one order to print !" + " Ban phai chon it nhat 1 dong de in !");
                return "";
            }
            if (tripDetailsList.Count > 0)
            {
                tripDetailsList.OrderBy(t => t.OrderNumber);

                foreach (var item in tripDetailsList)
                {
                    if (item.TripID != 0)
                        numberorderlist += (item.OrderNumber).Substring(3) + ",";
                }
                numberorderlist = numberorderlist.Substring(0, numberorderlist.Length - 1);
            }
            return numberorderlist;
        }

        private void btnDepatchingLabelDecal_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            printLabelDecal(false);
        }

        private void printLabelDecal(bool isPreview)
        {
            string numberOrderlist = combineOrder();
            DataProcess<object> STPickingSlipManyOrders = new DataProcess<object>();
            DataProcess<STPickingSlipManyOrderReport_Result> STPickingSlipManyOrderReport = new DataProcess<STPickingSlipManyOrderReport_Result>();
            if (numberOrderlist != "")
            {
                STPickingSlipManyOrders.ExecuteNoQuery("STPickingSlipManyOrders @p_str={0}", numberOrderlist);
            }
            rptLabelDecal_Dispatching report = new rptLabelDecal_Dispatching();
            report.DataSource = STPickingSlipManyOrderReport.Executing("STPickingSlipManyOrderReport");
            report.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
            report.Parameters["parameter1"].Value = 4;
            report.RequestParameters = false;
            ReportPrintToolWMS printTool = new ReportPrintToolWMS(report);
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

        private void printInvoiceAndDelivery(int number, bool isPreview)
        {

            int cusID = Convert.ToInt32(currentTrip.CustomerID);
            if ((HandlingOvertimeCheck(cusID) > 0) && (currentTrip.HandlingOvertimeCategoryID == null))
                lkeServiceNumber.ShowPopup();
            else if ((HandlingOvertimeCheck(cusID) == 0) && (currentTrip.HandlingOvertimeCategoryID != 346) && (currentTrip.HandlingOvertimeCategoryID != null))
                MessageBox.Show("Please check services of this customer!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                if ((HandlingOvertimeCheck(cusID) == 0) && (currentTrip.HandlingOvertimeCategoryID == null))
                    lkeServiceNumber.ShowPopup();
                if (currentTrip.TripID <= 0)
                {
                    MessageBox.Show("An error was encountered. Please return to the close form and try again.", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (tripDetailsList.Count() == 0)
                {
                    MessageBox.Show("No data. Please enter details!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                else
                {
                    DataProcess<object> cusInvoice = new DataProcess<object>();
                    DataTable dt_CustomerSalesInvoiceTrips = null;
                    int customerInvoiceID = 0;
                    dt_CustomerSalesInvoiceTrips = FileProcess.LoadTable("STNFC_CustomerSalesInvoiceTrips @TripID=" + currentTrip.TripID);
                    if (dt_CustomerSalesInvoiceTrips.Rows.Count == 0)
                    {
                        MessageBox.Show("You must select at least one order to print !\r \n Ban phai chon it nhat 1 dong de in !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    switch (number)
                    {
                        case 1:
                            foreach (DataRow item in dt_CustomerSalesInvoiceTrips.Rows)
                            {
                                DataProcess<STNFC_CustomerSalesInvoiceReport_new_Result> STNFC_CustomerSalesInvoiceReport_new = new DataProcess<STNFC_CustomerSalesInvoiceReport_new_Result>();
                                customerInvoiceID = Convert.ToInt32(item["CustomerSalesInvoiceID"].ToString());
                                cusInvoice.ExecuteNoQuery("STNFC_CustomerSalesInvoiceReportInsert" + customerInvoiceID);
                                //rptCustomerSalesInvoiceNew report = new rptCustomerSalesInvoiceNew();
                                //report.DataSource = STNFC_CustomerSalesInvoiceReport_new.Executing("STNFC_CustomerSalesInvoiceReport_new @CustomerSalesInvoiceID={0}", customerInvoiceID);
                            }
                            break;
                        case 2:
                            foreach (DataRow item in dt_CustomerSalesInvoiceTrips.Rows)
                            {
                                DataProcess<STNFC_CustomerSalesDeliveryNote_Result> STNFC_CustomerSalesDeliveryNote = new DataProcess<STNFC_CustomerSalesDeliveryNote_Result>();
                                customerInvoiceID = Convert.ToInt32(item["CustomerSalesInvoiceID"].ToString());
                                //rptDeliveryNote report = new rptDeliveryNote();
                                //report.DataSource = STNFC_CustomerSalesDeliveryNote.Executing("STNFC_CustomerSalesDeliveryNote @CustomerSalesInvoiceID={0}", customerInvoiceID);
                            }
                            break;
                        case 3:
                            foreach (DataRow item in dt_CustomerSalesInvoiceTrips.Rows)
                            {
                                DataProcess<STNFC_CustomerSalesDeliveryNote_Result> STNFC_CustomerSalesDeliveryNote = new DataProcess<STNFC_CustomerSalesDeliveryNote_Result>();
                                customerInvoiceID = Convert.ToInt32(item["CustomerSalesInvoiceID"].ToString());
                                //rptDeliveryNote2 report = new rptDeliveryNote2();
                                //report.DataSource = STNFC_CustomerSalesDeliveryNote.Executing("STNFC_CustomerSalesDeliveryNote @CustomerSalesInvoiceID={0}", customerInvoiceID);
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        private void bbtnMultiPickingSlipCombine_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            printmultiPickingSlipCombine(false);

            Customers customer;
            string numberOrderlist = combineOrder();
            customer = AppSetting.CustomerList.Where(c => c.CustomerID == currentTrip.CustomerID).FirstOrDefault();
            DataProcess<object> STPickingSlipManyOrders = new DataProcess<object>();
            // DataProcess<STPickingSlipManyOrderReport_Result> STPickingSlipManyOrderReport = new DataProcess<STPickingSlipManyOrderReport_Result>();
            STPickingSlipManyOrders.ExecuteNoQuery("STPickingSlipManyOrders @p_str={0}", numberOrderlist);
            rptPickingSlipManyOrders_Summary report = new rptPickingSlipManyOrders_Summary();
            report.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
            report.Parameters["varTripID"].Value = teTripID.EditValue;
            report.Parameters["varNote"].Value = memoTruckAndDetails.EditValue;
            report.Parameters["varVehicle"].Value = txtVehicleNumber.EditValue;
            report.Parameters["varDate"].Value = deTripDate.EditValue;
            report.xrLabel3.Text = numberOrderlist;
            report.RequestParameters = false;
            report.DataSource = FileProcess.LoadTable("STPickingSlipManyOrderReport");
            ReportPrintToolWMS printTool2 = new ReportPrintToolWMS(report);
            printTool2.AutoShowParametersPanel = false;

            printTool2.Print();

        }

        private void printmultiPickingSlipCombine(bool isPreview)
        {
            Customers customer;
            string numberOrderlist = combineOrder();
            customer = AppSetting.CustomerList.Where(c => c.CustomerID == currentTrip.CustomerID).FirstOrDefault();
            if (numberOrderlist != "")
            {
                DataProcess<STLabelPickingSlipManyOrders_Result> STLabelPickingSlipManyOrders = new DataProcess<STLabelPickingSlipManyOrders_Result>();
                List<STLabelPickingSlipManyOrders_Result> STLabelPickingSlipManyOrders_Result = new List<STLabelPickingSlipManyOrders_Result>();
                STLabelPickingSlipManyOrders_Result = (List<STLabelPickingSlipManyOrders_Result>)STLabelPickingSlipManyOrders.Executing("STLabelPickingSlipManyOrders @p_str={0}", numberOrderlist);
                if (STLabelPickingSlipManyOrders_Result.Count > 0)
                {
                    if (customer.CustomerType.Equals(CustomerTypeEnum.PCS))
                    {
                        rptLabelA4Short_Barcode_pcs labelA4Short_Barcode_pcs = new rptLabelA4Short_Barcode_pcs();
                        //  labelA4Short_Barcode_pcs.bcPalletID.Text = "*" + varLabelRemainPickingSlip.FirstOrDefault().PalletID_Barcode + "*";
                        labelA4Short_Barcode_pcs.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
                        labelA4Short_Barcode_pcs.Parameters["parameter1"].Value = 3;
                        labelA4Short_Barcode_pcs.RequestParameters = false;
                        labelA4Short_Barcode_pcs.DataSource = STLabelPickingSlipManyOrders_Result;
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
                    else
                    {
                        rptLabelDecal labelDecal = new rptLabelDecal();
                        //labelDecal.bcPalletID.Text = "*" + varLabelRemainPickingSlip.FirstOrDefault().PalletID_Barcode + "*";
                        labelDecal.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
                        labelDecal.Parameters["parameter1"].Value = 4;
                        labelDecal.RequestParameters = false;
                        labelDecal.DataSource = STLabelPickingSlipManyOrders_Result;
                        ReportPrintToolWMS printTool = new ReportPrintToolWMS(labelDecal);
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
                }
                DataProcess<object> STPickingSlipManyOrders = new DataProcess<object>();
                DataProcess<STPickingSlipManyOrderReport_Result> STPickingSlipManyOrderReport = new DataProcess<STPickingSlipManyOrderReport_Result>();
                STPickingSlipManyOrders.ExecuteNoQuery("STPickingSlipManyOrders @p_str={0}", numberOrderlist);
                rptPickingSlipManyOrders_Landscape report = new rptPickingSlipManyOrders_Landscape();
                report.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
                report.xrLabel3.Text = numberOrderlist;
                report.RequestParameters = false;
                report.DataSource = STPickingSlipManyOrderReport.Executing("STPickingSlipManyOrderReport");
                ReportPrintToolWMS printTool2 = new ReportPrintToolWMS(report);
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
        }

        private void bbtnMultiPlanA4Combine_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            printMultiPlanA4Combine(false);
        }
        private void printMultiPlanA4Combine(bool isPreview)
        {
            string numberOrderlist = combineOrder();
            if (numberOrderlist != "")
            {
                DataProcess<object> STDispatchingPlanManyOrders = new DataProcess<object>();
                DataProcess<STDispatchingPlanManyOrderReport_Result> STDispatchingPlanManyOrderReport = new DataProcess<STDispatchingPlanManyOrderReport_Result>();
                var result = STDispatchingPlanManyOrders.ExecuteNoQuery("STDispatchingPlanManyOrders @p_str={0}", numberOrderlist);
                if (result == -2)
                {
                    MessageBox.Show("Error when view report", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Customers customer;
                customer = AppSetting.CustomerList.Where(c => c.CustomerID == currentTrip.CustomerID).FirstOrDefault();
                if (customer.CustomerType.Equals(CustomerTypeEnum.RANDOM_WEIGHT))
                {
                    // rptDispatchingPlanManyOrders report = new rptDispatchingPlanManyOrders();
                    rptDispatchingPlanManyOrders_KGR report = new rptDispatchingPlanManyOrders_KGR();

                    report.RequestParameters = false;
                    //var dataSource = FileProcess.LoadTable("STDispatchingPlanManyOrderReport");
                    var dataSource = FileProcess.LoadTable("ST_WMS_DispatchingPlanManyOrderReportKGR @TripID=" + currentTrip.TripID);
                    //dataSource.DefaultView.Sort = columnSoft;
                    //dataSource = dataSource.DefaultView.ToTable();
                    report.DataSource = dataSource;
                    report.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
                    ReportPrintToolWMS printTool = new ReportPrintToolWMS(report);
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
                    rptDispatchingPlanManyOrders report = new rptDispatchingPlanManyOrders();


                    report.RequestParameters = false;
                    var dataSource = FileProcess.LoadTable("STDispatchingPlanManyOrderReport @TripID=" + currentTrip.TripID);
                    //  var dataSource = FileProcess.LoadTable("ST_WMS_DispatchingPlanManyOrderReportKGR @TripID=" + currentTrip.TripID);
                    //dataSource.DefaultView.Sort = columnSoft;
                    //dataSource = dataSource.DefaultView.ToTable();
                    report.DataSource = dataSource;
                    report.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
                    ReportPrintToolWMS printTool = new ReportPrintToolWMS(report);
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
                ReportPrintToolWMS printTS;
                rptLabel_PickingSlipTinySize rptTS = new rptLabel_PickingSlipTinySize();
                var labelSource = FileProcess.LoadTable("STPickingSlipManyOrderReportByTrip '" + numberOrderlist + "'");
                rptTS.DataSource = labelSource;
                rptTS.RequestParameters = false;
                printTS = new ReportPrintToolWMS(rptTS);
                printTS.AutoShowParametersPanel = false;
                printTS.ShowPreview();
            }
        }

        private void labelPickTrip()
        {
            StringBuilder orderNumber = new StringBuilder();
            for (int i = 0; i < grvTripDetails.DataRowCount; i++)
            {
                orderNumber.Append(this.grvTripDetails.GetRowCellValue(i, "OrderNumber").ToString().Substring(3));
                if (i < this.grvTripDetails.SelectedRowsCount - 1)
                {
                    orderNumber.Append(",");
                }
            }
            ReportPrintToolWMS printTS;
            rptLabel_PickingSlipTinySize rptTS = new rptLabel_PickingSlipTinySize();
            var labelSource = FileProcess.LoadTable("STPickingSlipManyOrderReportByTrip '" + orderNumber + "'");
            rptTS.DataSource = labelSource;
            rptTS.RequestParameters = false;
            printTS = new ReportPrintToolWMS(rptTS);
            printTS.AutoShowParametersPanel = false;
            printTS.ShowPreview();
        }

        private void btnViewMultiNoteComebineDetail_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            viewMultiNodeCombineDetail(true, true);
        }
        private void viewMultiNodeCombine(bool isPreview, bool isDetail)
        {
            Customers customer;
            customer = AppSetting.CustomerList.Where(c => c.CustomerID == currentTrip.CustomerID).FirstOrDefault();
            if (customer.CustomerType.Equals(CustomerTypeEnum.RANDOM_WEIGHT))
            {
                rptDispatchingNote_TripCombine report = new rptDispatchingNote_TripCombine();
                //rptDispatchingNote_TripCombine_Details report = new rptDispatchingNote_TripCombine_Details();

                var dataSource = FileProcess.LoadTable("STDispatchingNote_Client_Trip @TripID=" + currentTrip.TripID + ", @pcs=NULL");
                report.DataSource = dataSource;
                report.RequestParameters = false;
                report.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
                ReportPrintToolWMS printTool = new ReportPrintToolWMS(report);
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
            else if (customer.CustomerType.Equals(CustomerTypeEnum.PCS))
            {
                // print rptDispatchingNote_TripCombine_pcs
                rptDispatchingNote_TripCombine_pcs report = new rptDispatchingNote_TripCombine_pcs();
                report.Parameters["varLoginUser"].Value = AppSetting.CurrentUser.LoginName;
                report.Parameters["varCurrentUser"].Value = fullInfoEmployees.FullName;
                report.Parameters["Barcode"].Value = "TW" + tripID.ToString("D9");
                report.RequestParameters = false;
                var dataSource = FileProcess.LoadTable("STDispatchingNote_Client_Trip @TripID=" + currentTrip.TripID + ", @pcs=0");
                report.DataSource = dataSource;
                ReportPrintToolWMS printTool = new ReportPrintToolWMS(report);
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
                DevExpress.XtraReports.UI.XtraReport report = null;
                DataTable dataSource = null;
                if (isDetail)
                {
                    report = new rptDispatchingNote_TripCombine_Details();
                    report.Parameters["varLoginUser"].Value = AppSetting.CurrentUser.LoginName;
                    report.Parameters["Barcode"].Value = "TW" + tripID.ToString("D9");
                    dataSource = FileProcess.LoadTable("STDispatchingNote_Client_Trip @TripID=" + currentTrip.TripID + ", @pcs=0");
                }
                else
                {
                    report = new rptDispatchingNote_TripCombine();
                    report.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
                    dataSource = FileProcess.LoadTable("STDispatchingNote_Client_Trip @TripID=" + currentTrip.TripID);
                }


                if (dataSource != null)
                {
                    report.DataSource = dataSource;

                    report.RequestParameters = false;
                    ReportPrintToolWMS printTool = new ReportPrintToolWMS(report);
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
                    MessageBox.Show("No data to print!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void viewMultiNodeCombineDetail(bool isPreview, bool isDetail)
        {
            Customers customer;
            customer = AppSetting.CustomerList.FirstOrDefault(c => c.CustomerID == currentTrip.CustomerID);

            if (customer == null)
            {
                logger.WarnFormat("viewMultiNodeCombineDetail - Can not find customer with ID={0}", currentTrip.CustomerID);
                return;
            }

            if (string.Equals(customer.CustomerType, CustomerTypeEnum.RANDOM_WEIGHT))
            {
                // Customer type is : RANDOM_WEIGHT or RANDOM_WEIGHT_TEST or RANDOM_WEIGHT_CARTON
                rptDispatchingNote_TripCombine_Details report = new rptDispatchingNote_TripCombine_Details();

                var dataSource = FileProcess.LoadTable("STDispatchingNote_Client_Trip @TripID=" + currentTrip.TripID + ", @pcs=0");
                report.DataSource = dataSource;
                report.RequestParameters = false;
                report.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
                report.Parameters["Barcode"].Value = "TW" + tripID.ToString("D9");
                ReportPrintToolWMS printTool = new ReportPrintToolWMS(report)
                {
                    AutoShowParametersPanel = false
                };

                if (isPreview)
                {
                    printTool.ShowPreview();
                }
                else
                {
                    printTool.Print();
                }
            }
            else if (customer.CustomerType.Equals(CustomerTypeEnum.PCS))
            {
                // print rptDispatchingNote_TripCombine_pcs
                rptDispatchingNote_TripCombine_pcs report = new rptDispatchingNote_TripCombine_pcs();
                report.Parameters["varLoginUser"].Value = AppSetting.CurrentUser.LoginName;
                report.Parameters["varCurrentUser"].Value = fullInfoEmployees.FullName;
                report.Parameters["Barcode"].Value = "TW" + tripID.ToString("D9");
                report.RequestParameters = false;
                var dataSource = FileProcess.LoadTable("STDispatchingNote_Client_Trip @TripID=" + currentTrip.TripID + ", @pcs=0");
                report.DataSource = dataSource;
                ReportPrintToolWMS printTool = new ReportPrintToolWMS(report);
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
                DevExpress.XtraReports.UI.XtraReport report = null;
                DataTable dataSource = null;
                if (isDetail)
                {
                    report = new rptDispatchingNote_TripCombine_Details();
                    report.Parameters["varLoginUser"].Value = AppSetting.CurrentUser.LoginName;
                    report.Parameters["Barcode"].Value = "TW" + tripID.ToString("D9");
                    dataSource = FileProcess.LoadTable("STDispatchingNote_Client_Trip @TripID=" + currentTrip.TripID + ", @pcs=0");
                }
                else
                {
                    report = new rptDispatchingNote_TripCombine();
                    report.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
                    dataSource = FileProcess.LoadTable("STDispatchingNote_Client_Trip @TripID=" + currentTrip.TripID);
                }


                if (dataSource != null)
                {
                    report.DataSource = dataSource;

                    report.RequestParameters = false;
                    ReportPrintToolWMS printTool = new ReportPrintToolWMS(report);
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
                    MessageBox.Show("No data to print!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void grvTripDetails_ShownEditor(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            if (view.ActiveEditor is LookUpEdit)
            {
                ((LookUpEdit)view.ActiveEditor).ShowPopup();
            }
        }

        private void bbtnViewMultiNoteCombine_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.viewMultiNodeCombineDetail(true, false);
        }

        private void btnMultiInvoices_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MultiReports(false, 1);
        }

        private void btnDeliveryNote_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MultiReports(false, 2);
        }

        private void btnDeliveryNote2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MultiReports(false, 3);
        }

        private void MultiReports(bool isPreview, int report)
        {
            if (HandlingOvertimeCheck((int)currentTrip.CustomerID) > 0 && this.lkeServiceNumber.EditValue == null)
            {
                this.lkeServiceNumber.Focus();
                this.lkeServiceNumber.ShowPopup();
            }
            else
            {
                if (HandlingOvertimeCheck((int)currentTrip.CustomerID) == 0 && this.lkeServiceNumber.EditValue != null && Convert.ToInt32(this.lkeServiceNumber.GetColumnValue("ServiceID")) != 346)
                {
                    XtraMessageBox.Show("Please check services of this customer !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (HandlingOvertimeCheck((int)currentTrip.CustomerID) == 0 && this.lkeServiceNumber.EditValue == null)
                    {
                        this.lkeServiceNumber.Focus();
                        this.lkeServiceNumber.ShowPopup();
                        return;
                    }

                    if (String.IsNullOrEmpty(this.teTripID.Text))
                    {
                        XtraMessageBox.Show("An error was encountered. Please return to the close form and try again.", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (this.grvTripDetails.RowCount <= 0)
                    {
                        XtraMessageBox.Show("No data. Please enter details !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var source = FileProcess.LoadTable("STNFC_CustomerSalesInvoiceTrips @TripID = 11395");

                    if (source.Rows.Count <= 0)
                    {
                        XtraMessageBox.Show("You must select at least one order to print !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    foreach (DataRow row in source.Rows)
                    {
                        DataProcess<object> invoiceDA = new DataProcess<object>();
                        int invoiceID = Convert.ToInt32(row["CustomerSalesInvoiceID"]);
                        int result = -2;
                        XtraReport rpt = new XtraReport();

                        switch (report)
                        {
                            case 1:
                                {
                                    result = invoiceDA.ExecuteNoQuery("STNFC_CustomerSalesInvoiceReportInsert @CustomerSalesInvoiceID = " + invoiceID);
                                    rpt = new rptCustomerSalesInvoiceNew();
                                    rpt.DataSource = FileProcess.LoadTable("STNFC_CustomerSalesInvoiceReport_new @CustomerSalesInvoiceID = " + invoiceID);
                                    break;
                                }
                            case 2:
                                {
                                    rpt = new rptDeliveryNote();
                                    rpt.DataSource = FileProcess.LoadTable("STNFC_CustomerSalesDeliveryNote @CustomerSalesInvoiceID = " + invoiceID);
                                    break;
                                }
                            case 3:
                                {
                                    rpt = new rptDeliveryNote2();
                                    rpt.DataSource = FileProcess.LoadTable("STNFC_CustomerSalesDeliveryNote @CustomerSalesInvoiceID = " + invoiceID);
                                    break;
                                }
                        }

                        ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
                        if (isPreview)
                        {
                            tool.ShowPreview();
                        }
                        else
                        {
                            tool.Print();
                        }

                    }
                }
            }
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void memoTruckAndDetails_Leave(object sender, EventArgs e)
        {
            if (this.memoTruckAndDetails.IsModified)
            {
                DataProcess<object> tripDA = new DataProcess<object>();
                tripDA.ExecuteNoQuery("Update Trips Set Trips.TripRemark = {0} Where Trips.TripID = {1}", this.memoTruckAndDetails.Text, currentTrip.TripID);
            }
            this.lke_TimeSlotID.Focus();
            this.lke_TimeSlotID.ShowPopup();
        }

        private void memoTruckAndDetails_EditValueChanged(object sender, EventArgs e)
        {
            this.currentTrip.TripRemark = this.memoTruckAndDetails.Text;
        }

        private void teDock_EditValueChanged(object sender, EventArgs e)
        {
            if (this.lkeDockNumber.EditValue == null) return;
            if (this.lkeDockNumber.IsModified)
            {
                this.currentTrip.DockNumber = Convert.ToString(this.lkeDockNumber.EditValue);
                DataProcess<object> tripDA = new DataProcess<object>();
                tripDA.ExecuteNoQuery("Update Trips Set Trips.DockDoorID = {0} Where Trips.TripID = {1}", this.lkeDockNumber.EditValue, currentTrip.TripID);
                foreach (var item in this.tripDetailsList)
                {
                    int result = tripDA.ExecuteNoQuery("Update DispatchingOrders set DockDoorID='" + this.lkeDockNumber.EditValue
                                        + "' where DispatchingOrderNumber='" + item.OrderNumber + "'");
                    int resultRO = tripDA.ExecuteNoQuery("Update ReceivingOrders set DockDoorID='" + this.lkeDockNumber.EditValue
                                        + "' where ReceivingOrderNumber='" + item.OrderNumber + "'");
                }
            }

        }

        private void teSeal_EditValueChanged(object sender, EventArgs e)
        {
            this.currentTrip.SealNumber = this.teSeal.Text;
        }

        private void teSeal_Leave(object sender, EventArgs e)
        {
            if (this.teSeal.IsModified)
            {
                DataProcess<object> tripDA = new DataProcess<object>();
                tripDA.ExecuteNoQuery("Update Trips Set Trips.SealNumber = {0} Where Trips.TripID = {1}", this.teSeal.Text, currentTrip.TripID);
            }
        }

        private void teInternal_EditValueChanged(object sender, EventArgs e)
        {
            this.currentTrip.InternalRemark = this.teInternal.Text;
        }

        private void teInternal_Leave(object sender, EventArgs e)
        {
            if (this.teInternal.IsModified)
            {
                DataProcess<object> tripDA = new DataProcess<object>();
                tripDA.ExecuteNoQuery("Update Trips Set Trips.InternalRemark = {0} Where Trips.TripID = {1}", this.teInternal.Text, currentTrip.TripID);
            }
        }

        private void dtStartTime_EditValueChanged(object sender, EventArgs e)
        {
            this.currentTrip.StartWorkingTime = this.dtStartTime.DateTime;
            if (this.dtStartTime.IsModified)
            {
                if (dtStartTime.DateTime > DateTime.Now.AddDays(-4) && dtStartTime.DateTime < DateTime.Now)
                {
                    DataProcess<object> tripDA = new DataProcess<object>();
                    tripDA.ExecuteNoQuery("Update Trips Set Trips.StartWorkingTime = '" + this.dtStartTime.DateTime.ToString("yyyy-MM-dd HH:mm") + "' Where Trips.TripID = " + this.currentTrip.TripID);
                    foreach (var item in this.tripDetailsList)
                    {
                        int result = tripDA.ExecuteNoQuery("Update DispatchingOrders set StartTime='" + this.dtStartTime.DateTime.ToString("yyyy-MM-dd HH:mm")
                                            + "' where DispatchingOrderNumber='" + item.OrderNumber + "'");
                        int resultRO = tripDA.ExecuteNoQuery("Update ReceivingOrders set StartTime='" + this.dtStartTime.DateTime.ToString("yyyy-MM-dd HH:mm")
                                            + "' where ReceivingOrderNumber='" + item.OrderNumber + "'");
                    }
                }
            }
        }

        private void dtStartTime_Leave(object sender, EventArgs e)
        {
            if (this.dtStartTime.IsModified)
            {
                if (dtStartTime.DateTime > DateTime.Now.AddDays(-4) && dtStartTime.DateTime < DateTime.Now)
                {
                    DataProcess<object> tripDA = new DataProcess<object>();
                    tripDA.ExecuteNoQuery("Update Trips Set Trips.StartWorkingTime = '" + this.dtStartTime.DateTime.ToString("yyyy-MM-dd HH:mm") + "' Where Trips.TripID = " + this.currentTrip.TripID);
                }
            }
        }

        private void dtEndTime_EditValueChanged(object sender, EventArgs e)
        {
            this.currentTrip.EndWorkingTime = this.dtEndTime.DateTime;
            if (this.dtEndTime.IsModified)
            {
                if (dtEndTime.EditValue != null && dtEndTime.DateTime >= dtStartTime.DateTime)
                {
                    DataProcess<object> tripDA = new DataProcess<object>();
                    tripDA.ExecuteNoQuery("Update Trips Set Trips.EndWorkingTime = '" + this.dtEndTime.DateTime.ToString("yyyy-MM-dd HH:mm") + "' Where Trips.TripID = " + this.currentTrip.TripID);
                    foreach (var item in this.tripDetailsList)
                    {
                        int result = tripDA.ExecuteNoQuery("Update DispatchingOrders set EndTime='" + this.dtEndTime.DateTime.ToString("yyyy-MM-dd HH:mm")
                                            + "' where DispatchingOrderNumber='" + item.OrderNumber + "'");
                        int resultRO = tripDA.ExecuteNoQuery("Update ReceivingOrders set EndTime='" + this.dtEndTime.DateTime.ToString("yyyy-MM-dd HH:mm")
                                            + "' where ReceivingOrderNumber='" + item.OrderNumber + "'");
                    }
                }
            }
        }

        private void dtEndTime_Leave(object sender, EventArgs e)
        {
            if (this.dtEndTime.IsModified)
            {
                if (dtEndTime.EditValue != null && dtEndTime.DateTime >= dtStartTime.DateTime)
                {
                    DataProcess<object> tripDA = new DataProcess<object>();
                    tripDA.ExecuteNoQuery("Update Trips Set Trips.EndWorkingTime = '" + this.dtEndTime.DateTime.ToString("yyyy-MM-dd HH:mm") + "' Where Trips.TripID = " + this.currentTrip.TripID);
                }
            }
        }

        private void teTemp_EditValueChanged(object sender, EventArgs e)
        {
            this.currentTrip.Temperature = this.teTemp.Text;
        }

        private void teTemp_Leave(object sender, EventArgs e)
        {
            if (this.teTemp.IsModified)
            {
                DataProcess<object> tripDA = new DataProcess<object>();
                tripDA.ExecuteNoQuery("Update Trips Set Trips.Temperature = {0} Where Trips.TripID = {1}", this.currentTrip.Temperature, currentTrip.TripID);
            }
        }

        private void dtStartTime_Enter(object sender, EventArgs e)
        {
            if (this.dtStartTime.EditValue == null)
            {
                this.dtStartTime.EditValue = DateTime.Now;
            }
        }

        private void dtEndTime_Enter(object sender, EventArgs e)
        {
            if (this.dtEndTime.EditValue == null)
            {
                this.dtEndTime.EditValue = DateTime.Now;
            }
        }

        private void lkeOneClient_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.Value == null)
            {
                e.AcceptValue = false;
            }
            else
            {
                this.lkeOneClient.EditValue = e.Value;
                if (XtraMessageBox.Show("Are you sure you want to update this client to all DO(s) ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DataProcess<object> tripDA = new DataProcess<object>();
                    tripDA.ExecuteNoQuery("STTripCustomerClientUpdate @TripID = {0}, @CustomerClientID = {1}", this.currentTrip.TripID, Convert.ToInt32(this.lkeOneClient.EditValue));
                    this.LoadTripDetails();
                    //STTripCustomerClientUpdate
                }
            }
        }

        private void lkeServiceNumber_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.Value == null) return;
            this.lkeServiceNumber.EditValue = e.Value;
            DataProcess<object> tripDA = new DataProcess<object>();
            int result1 = tripDA.ExecuteNoQuery("Update Trips Set Trips.HandlingOvertimeCategoryID = {0} Where Trips.TripID = {1}", Convert.ToInt32(this.lkeServiceNumber.EditValue), this.currentTrip.TripID);
            foreach (var item in this.tripDetailsList)
            {
                int result = tripDA.ExecuteNoQuery("Update DispatchingOrders set HandlingOvertimeCategoryID=" + e.Value
                                    + " where DispatchingOrderNumber='" + item.OrderNumber + "'");
                int resultRO = tripDA.ExecuteNoQuery("Update ReceivingOrders set HandlingOvertimeCategoryID=" + e.Value
                                    + " where ReceivingOrderNumber='" + item.OrderNumber + "'");
            }
        }

        private void grvTripDetails_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            // Get the summary ID. 
            int summaryID = Convert.ToInt32((e.Item as DevExpress.XtraGrid.GridSummaryItem).Tag);

            if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Start)
            {
                this.selected = 0;
            }

            if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
            {
                bool checkDelete = Convert.ToBoolean(this.grvTripDetails.GetRowCellValue(e.RowHandle, "CheckDelete"));
                if (summaryID == 1)
                {
                    if (checkDelete)
                    {
                        this.selected++;
                    }
                }
            }

            if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
            {
                if (summaryID == 1)
                {
                    e.TotalValue = this.selected;
                }
            }
        }

        private void RepositoryItemCheckDelete_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void RepositoryItemCheckDelete_EditValueChanged(object sender, EventArgs e)
        {

        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.F3)
            {
                frm_WM_Attachments.Instance.OrderNumber = this.teTripID.Text;
                frm_WM_Attachments.Instance.CustomerID = (int)currentTrip.CustomerID;
                if (frm_WM_Attachments.Instance.Enabled)
                {
                    frm_WM_Attachments.Instance.ShowDialog();
                }
            }
            return base.ProcessDialogKey(keyData);
        }

        private void ChangeTripDate(DateTime newDate)
        {
            int FirstCondition = newDate.Date.CompareTo(DateTime.Now.AddDays(-1).Date);
            int SecondCondition = newDate.Date.CompareTo(DateTime.Now.AddDays(2).Date);
            if (newDate == null)
                MessageBox.Show("TripDate can't null value !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (FirstCondition < 0 & SecondCondition > 0)
            {
                string ErrorMessage = string.Format("Please re-enter the correct date.\nTripdate must later than {0} and earlier than {1}", DateTime.Now.AddDays(-1).Date, DateTime.Now.AddDays(2).Date);
                MessageBox.Show(ErrorMessage, "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (SwireDBEntities db = new SwireDBEntities())
                {
                    int Result = db.STTripDateChange(currentTrip.TripID, newDate);
                    MessageBox.Show("All related orders have been updated with new Date !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.LoadTripsInit();
                    this.LoadTripDetails();
                }
            }
        }

        private void deTripDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                this.ChangeTripDate((DateTime)this.deTripDate.EditValue);
            }
        }

        private void frm_WM_TripsManagement_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void bbtnViewMultiNoteCombine_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.viewMultiNodeCombine(true, false);
        }

        private void btn_ViewMultiNoteCombineDetail_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            viewMultiNodeCombineDetail(true, true);
        }

        private void grvTripDetails_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.Column == null || e.HitInfo.InRow == false) return;
            switch (e.HitInfo.Column.FieldName)
            {
                case "OrderNumber":
                    this.popupOptionsCell.ShowPopup(Control.MousePosition);
                    break;
                default:
                    break;
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string productNumberSelected = this.grvTripDetails.GetFocusedDisplayText();
            if (string.IsNullOrEmpty(productNumberSelected)) return;
            Clipboard.Clear();
            Clipboard.SetText(productNumberSelected);
        }

        private void btn_WM_btnViewNoteDetail_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            printNoteDetail(true);
        }

        private void btnPickSummary_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_WM_Dialog_Trip_PickSummary frm = new frm_WM_Dialog_Trip_PickSummary(tripID);
            frm.Show();
        }

        private void btn_Preview_MultiPlan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            printMultiPlan(true);
        }

        private void btn_Preview_MultiPickPlan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ProcessPintPickOrPlan(true);
        }

        private void btn_Preview_MultiPlanA4Combine_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            printMultiPlanA4Combine(true);
        }

        private void btn_Preview_MultiPickingSlipCombine_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            printmultiPickingSlipCombine(true);
        }

        private void btn_Preview_DispatchingLabelDecal_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            printLabelDecal(true);
        }

        private void btn_Preview_MultiInvoices_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MultiReports(true, 1);
        }

        private void btn_Preview_DeliveryNote_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MultiReports(true, 2);
        }

        private void btn_Preview_DeliveryNote2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MultiReports(true, 3);
        }

        private void dockPanelEmployees_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            if (this.currentTrip.TripID <= 0) return;
            decimal TotalPallets = Convert.ToDecimal(grdcolPallet.SummaryItem.SummaryValue);
            decimal TotalWeight = Convert.ToDecimal(grdcolWeight.SummaryItem.SummaryValue);
            decimal TotalCartons = Convert.ToDecimal(grdcolCtns.SummaryItem.SummaryValue);
            string tripNumber = Convert.ToString(teTripID.EditValue);

            if (this.viewEmployee == null)
            {
                this.viewEmployee = new urc_WM_EmployeeInfo(tripNumber, TotalPallets, TotalWeight, TotalCartons);
                this.viewEmployee.Parent = this.dockPanelEmployees;
            }

            this.viewEmployee.UpdateParameter(TotalPallets, TotalCartons, TotalWeight);
            this.viewEmployee.LoadEmployeeWorking(tripNumber);
            this.viewEmployee.Update();
            this.viewEmployee.Refresh();
        }

        private void dockPanelVehicle_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            if (this.currentTrip.TripID <= 0) return;
            int customerID = Convert.ToInt32(currentTrip.CustomerID);
            string totalPackage = Convert.ToString(this.grdcolCtns.SummaryItem.SummaryValue);

            if (this.viewVehicle == null)
            {
                this.viewVehicle = new urc_WM_Vehicle(customerID, currentTrip.CustomerName, txtVehicleNumber.Text, currentTrip.TripNumber, memoTruckAndDetails.Text, teSeal.Text, this.lkeDockNumber.Text, totalPackage);
                this.viewVehicle.Parent = this.dockPanelVehicle;
            }

            this.viewVehicle.UpdateParam(customerID, currentTrip.CustomerName, txtVehicleNumber.Text, teSeal.Text, this.lkeDockNumber.Text);
            this.viewVehicle.InitData(currentTrip.TripNumber, totalPackage);
            this.viewVehicle.Update();
            this.viewVehicle.Refresh();
        }

        private void hideContainerRight_Click(object sender, EventArgs e)
        {

        }

        private void btn_NewRoute_Click(object sender, EventArgs e)
        {
            //Open form to Create new Routes
            frm_WM_Dialog_Routes frmR = new frm_WM_Dialog_Routes(Convert.ToInt32(this.lkeCustomerNumber.EditValue));
            frmR.ShowDialog();

            // reload routes 
            this.LoadRoutes();
        }

        private void lookUpEditRouteID_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.Value == null) return;
            this.lookUpEditRouteID.EditValue = e.Value;
            DataProcess<Trips> tripDA = new DataProcess<Trips>();
            var tripInfo = tripDA.Select(t => t.TripID == currentTrip.TripID).FirstOrDefault();
            tripInfo.RouteID = Convert.ToInt32(this.lookUpEditRouteID.EditValue);
            tripDA.Update(tripInfo);
        }

        private void txtVehicleNumber_EditValueChanged(object sender, EventArgs e)
        {
            if (this.txtVehicleNumber.IsModified)
            {
                DataProcess<object> tripDA = new DataProcess<object>();
                tripDA.ExecuteNoQuery("Update Trips Set Trips.VehicleNumber = {0} Where Trips.TripID = {1}", this.txtVehicleNumber.Text, currentTrip.TripID);
                foreach (var item in this.tripDetailsList)
                {
                    int result = tripDA.ExecuteNoQuery("Update DispatchingOrders set VehicleNumber='" + this.txtVehicleNumber.Text
                                        + "' where DispatchingOrderNumber='" + item.OrderNumber + "'");
                    int resultRO = tripDA.ExecuteNoQuery("Update ReceivingOrders set VehicleNumber='" + this.txtVehicleNumber.Text
                                        + "' where ReceivingOrderNumber='" + item.OrderNumber + "'");
                }
            }
        }

        private void dockPanelService_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {

            string orderNumber = currentTrip.TripNumber; // Convert.ToString(this.grvTripDetails.GetFocusedRowCellValue("OrderNumber"));
            if (this.otherService == null)
            {

                this.otherService = new urc_WM_OtherService(orderNumber);
                this.otherService.Parent = this.dockPanelService;
            }

            this.otherService.InitData(orderNumber);
            //Trung 22/01/2020 : Use Trip Number as OrderNumber for other Service
            //if (this.otherService != null)
            //{
            //    if (this.grvTripDetails.FocusedRowHandle < 0) return;
            //    string orderNumber = Convert.ToString(this.grvTripDetails.GetFocusedRowCellValue("OrderNumber"));
            //    this.otherService.InitData(orderNumber);
            //};
        }

        private void lke_TimeSlotID_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.Value == null) return;
            this.lke_TimeSlotID.EditValue = e.Value;
            DataProcess<object> tripDA = new DataProcess<object>();
            tripDA.ExecuteNoQuery("Update Trips Set Trips.TimeSlotID = {0} Where Trips.TripID = {1}", e.Value, currentTrip.TripID);
            foreach (var item in this.tripDetailsList)
            {
                int result = tripDA.ExecuteNoQuery("Update DispatchingOrders set TimeSlotID='" + lke_TimeSlotID.EditValue
                                    + "' where DispatchingOrderNumber='" + item.OrderNumber + "'");
                int resultRO = tripDA.ExecuteNoQuery("Update ReceivingOrders set TimeSlotID='" + lke_TimeSlotID.EditValue
                                    + "' where ReceivingOrderNumber='" + item.OrderNumber + "'");
            }
        }

        private void frm_WM_TripsManagement_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                if (!this.teTripID.Text.Equals("TW-New*"))
                {
                    frm_WM_Attachments.Instance.OrderNumber = this.teTripID.Text;
                    frm_WM_Attachments.Instance.CustomerID = Convert.ToInt32(this.lkeCustomerNumber.EditValue);
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

        private void grvTripDetails_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            bool isUpdate = false;
            switch (e.Column.FieldName)
            {
                case "CashCollectionAmount":
                case "RejectedOrderNumber":
                case "ExpectedDeliveryTime":
                case "RejectedRemark":
                case "IsRejected":
                case "DeliveredBy":
                case "DeliveredTime":
                    isUpdate = true;
                    break;
            }

            if (!isUpdate) return;
            int tripDetailID = Convert.ToInt32(this.grvTripDetails.GetFocusedRowCellValue("TripDetailID"));
            DataProcess<object> tripDetailDA = new DataProcess<object>();
            tripDetailDA.ExecuteNoQuery("Update TripDetails Set " + e.Column.FieldName + " = {0} Where TripDetailID = {1}", e.Value, tripDetailID);
        }

        private void grvTripDetails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int tripDetailID = Convert.ToInt32(this.grvTripDetails.GetFocusedRowCellValue("TripDetailID"));
            DataProcess<object> tripDetailDA = new DataProcess<object>();
            switch (e.Action)
            {
                case CollectionChangeAction.Add:
                    tripDetailDA.ExecuteNoQuery("Update TripDetails Set TripDetails.CheckDelete = {0} Where TripDetailID = {1}", true, tripDetailID);
                    break;
                case CollectionChangeAction.Remove:
                    tripDetailDA.ExecuteNoQuery("Update TripDetails Set TripDetails.CheckDelete = {0} Where TripDetailID = {1}", false, tripDetailID);
                    break;
                case CollectionChangeAction.Refresh:
                    this.isCheckedAll = !isCheckedAll;
                    foreach (var item in tripDetailsList)
                    {
                        tripDetailDA.ExecuteNoQuery("Update TripDetails Set TripDetails.CheckDelete = {0} Where TripDetailID = {1}", this.isCheckedAll, item.TripDetailID);
                    }
                    break;
            }
        }

        private void rpi_lke_TripStatus_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.Value == null) return;
            int tripStatus = Convert.ToInt32(e.Value);
            // Checking trip is confirmed
            if (this.currentTrip.TripConfirmed)
            {
                if (tripStatus <= 1 && tripStatus != 12 && tripStatus != 13)
                {
                    MessageBox.Show("This Trip has confirmed, please changed to other status", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.AcceptValue = false;
                    return;
                }
            }
            else
            {
                if (tripStatus > 1 && tripStatus != 12 && tripStatus != 13)
                {
                    MessageBox.Show("This Trip not confirmed, please changed to other status", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.AcceptValue = false;
                    return;
                }
            }

            int tripDetailID = Convert.ToInt32(this.grvTripDetails.GetFocusedRowCellValue("TripDetailID"));
            var currentUser = AppSetting.CurrentUser.LoginName;
            var tripStatusNew = e.Value;
            DataProcess<object> tripDetailDA = new DataProcess<object>();
            tripDetailDA.ExecuteNoQuery("Update TripDetails Set TripDetails.TripStatus = {0} Where TripDetailID = {1}", e.Value, tripDetailID);
            // Tracking who change this status
            tripDetailDA.ExecuteNoQuery($"STTripDetailUpdateStatus @TripDetailID = {tripDetailID}, @UpdateBy = {currentUser}, @TripStatusNew = {tripStatusNew}");

            // Update value on grid UI
            this.tripDetailsList[this.grvTripDetails.FocusedRowHandle].TripStatus = Convert.ToByte(tripStatus);


            //Kho nhận lại 1 phần
            //Kho nhận lại toàn bộ
            if (tripStatus == 12 || tripStatus == 13)
            {
                string orderNumber = this.tripDetailsList[this.grvTripDetails.FocusedRowHandle].OrderNumber;
                if (string.IsNullOrEmpty(orderNumber)) return;
                int orderID = Convert.ToInt32(orderNumber.Split('-')[1]);
                frm_WM_DispatchingOrders DispatchingOrdersForm = frm_WM_DispatchingOrders.GetInstance(orderID, true);
                if (DispatchingOrdersForm.Visible)
                {
                    DispatchingOrdersForm.ReloadData();
                }
                DispatchingOrdersForm.Show();
            }
        }

        private void lke_Transporter_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.Value == null) return;
            DataProcess<object> tripDetailDA = new DataProcess<object>();
            tripDetailDA.ExecuteNoQuery("Update Trips Set Trips.TransporterID = {0} Where Trips.TripID = {1}", e.Value, currentTrip.TripID);
            this.currentTrip.TransporterID = (int)e.Value;
        }

        private void btnNewOj_Click(object sender, EventArgs e)
        {
            if (this.currentTrip == null) return;
            frm_WM_MHLWorks form = frm_WM_MHLWorks.Instance;
            form.Show();
            form.AddNewTrip(this.currentTrip.TripNumber, (int)this.currentTrip.CustomerID);
        }

        private void rpi_lke_DocumentStatus_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.Value == null) return;
            string valueName = Convert.ToString(e.Value);
            if (valueName.Equals("System.Object")) return;

            int tripDetailID = Convert.ToInt32(this.grvTripDetails.GetFocusedRowCellValue("TripDetailID"));
            DataProcess<object> tripDetailDA = new DataProcess<object>();
            tripDetailDA.ExecuteNoQuery("Update TripDetails Set TripDetails.DocumentStatus = {0} Where TripDetailID = {1}", e.Value, tripDetailID);
            this.tripDetailsList[this.grvTripDetails.FocusedRowHandle].DocumentStatus = Convert.ToByte(e.Value);
        }

        private void btnPickingConfirmByRoomA5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            rptPickingConfirmationByRoomA5 rpt = new rptPickingConfirmationByRoomA5();
            var dataSource = FileProcess.LoadTable("STTripPickingListByRoom @TripID=" + tripID);
            rpt.DataSource = dataSource;
            ReportPrintToolWMS printTool = new ReportPrintToolWMS(rpt);
            printTool.ShowPreviewDialog();
        }

        private void btn_Preview_PickingSlipSummary_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Customers customer;
            string numberOrderlist = combineOrder();
            customer = AppSetting.CustomerList.Where(c => c.CustomerID == currentTrip.CustomerID).FirstOrDefault();


            DataProcess<object> STPickingSlipManyOrders = new DataProcess<object>();
            // DataProcess<STPickingSlipManyOrderReport_Result> STPickingSlipManyOrderReport = new DataProcess<STPickingSlipManyOrderReport_Result>();
            STPickingSlipManyOrders.ExecuteNoQuery("STPickingSlipManyOrders @p_str={0}", numberOrderlist);
            rptPickingSlipManyOrders_Summary report = new rptPickingSlipManyOrders_Summary();
            report.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
            report.Parameters["varTripID"].Value = teTripID.EditValue;
            report.Parameters["varNote"].Value = memoTruckAndDetails.EditValue;
            report.Parameters["varVehicle"].Value = txtVehicleNumber.EditValue;
            report.Parameters["varDate"].Value = deTripDate.EditValue;
            report.xrLabel3.Text = numberOrderlist;
            report.RequestParameters = false;
            report.DataSource = FileProcess.LoadTable("STPickingSlipManyOrderReport");
            ReportPrintToolWMS printTool2 = new ReportPrintToolWMS(report);
            printTool2.AutoShowParametersPanel = false;

            printTool2.ShowPreview();
        }

        private void grvTripDetails_EndSorting(object sender, EventArgs e)
        {
            //var view = (Common.Controls.WMSGridView)sender;
            //var softInfo = (DevExpress.XtraGrid.Columns.GridColumnSortInfoCollection)view.SortInfo;
            //if (softInfo.Count > 0)
            //{
            //    var datasource = this.tripDetailsList;
            //    switch (softInfo[0].SortOrder)
            //    {
            //        case ColumnSortOrder.None:
            //            this.columnSoft = "[" + softInfo[0].Column.FieldName + "]";
            //            break;
            //        case ColumnSortOrder.Ascending:
            //            this.columnSoft = "[" + softInfo[0].Column.FieldName + "] ASC";
            //            break;
            //        case ColumnSortOrder.Descending:
            //            this.columnSoft = "[" + softInfo[0].Column.FieldName + "] DESC";
            //            break;
            //    }
            //    switch (this.columnSoft)
            //    {
            //        case "OrderNumber": datasource.OrderBy(x => x.OrderNumber); break;
            //        case "CustomerOrderNumber": datasource.OrderBy(x => x.CustomerOrderNumber); break;
            //        case "CustomerNumber": datasource.OrderBy(x => x.CustomerNumber); break;
            //        case "TotalPackages": datasource.OrderBy(x => x.TotalPackages); break;
            //        case "TotalWeight": datasource.OrderBy(x => x.TotalWeight); break;
            //        case "TripDetailRemark": datasource.OrderBy(x => x.TripDetailRemark); break;
            //        case "CustomerClientID": datasource.OrderBy(x => x.CustomerClientID); break;
            //        case "CreatedBy": datasource.OrderBy(x => x.CreatedBy); break;
            //        case "TripStatus": datasource.OrderBy(x => x.TripStatus); break;
            //        case "DeliveredBy": datasource.OrderBy(x => x.DeliveredBy); break;
            //        case "DeliveredTime": datasource.OrderBy(x => x.DeliveredTime); break;
            //        case "CashCollectionAmount": datasource.OrderBy(x => x.CashCollectionAmount); break;
            //        case "CustomerComments": datasource.OrderBy(x => x.CustomerComments); break;
            //        case "ExpectedDeliveryTime": datasource.OrderBy(x => x.ExpectedDeliveryTime); break;
            //        case "IsRejected": datasource.OrderBy(x => x.IsRejected); break;
            //        case "RejectedOrderNumber": datasource.OrderBy(x => x.RejectedOrderNumber); break;
            //        case "RejectedRemark": datasource.OrderBy(x => x.RejectedRemark); break;
            //        case "DocumentStatus":
            //            datasource.OrderBy(x => x.DocumentStatus);
            //            break;
            //    }
            //    this.tripDetailsList = datasource;
            //}
        }
        private void btnNewTransportServices_Click(object sender, EventArgs e)
        {
            if (this.lkeCustomerNumber.EditValue == null) return;
            int customerID = Convert.ToInt32(this.lkeCustomerNumber.EditValue);
            frm_WM_NewMHLWork frmNew = new frm_WM_NewMHLWork(customerID);
            frmNew.ShowDialog();
            this.LoadOJByTrip();
            //Nhờ Trí Code để nhập employees và OJ trong 1 form duy nhất. Form này chỉ có các control là ServiceDefinitionID,EmployeeID, Quantity, WMHLWorkRemark, MHLWorkDetailRemark 
            // Service: Chỉ có những Service có ServiceDescription có chữ 'Transport' và có trong Contract hiện hành với khách hàng
            // Employees: Chỉ có những employee Có Supplier > 0
            //WMS sẽ tự động:
            //   1. insert 1 Record và Bảng MHLWorks với dịch vụ và Customer vừa chọn
            //   2. INsert vào bảng MHLWorkDetaisl với Employees đã chọn
        }

        private void btn_WM_btnViewNoteByProduct_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Customers customer;
            customer = AppSetting.CustomerList.FirstOrDefault(c => c.CustomerID == currentTrip.CustomerID);

            if (customer == null)
            {
                return;
            }

            if (string.Equals(customer.CustomerType, CustomerTypeEnum.RANDOM_WEIGHT))
            {
                // Customer type is : RANDOM_WEIGHT or RANDOM_WEIGHT_TEST or RANDOM_WEIGHT_CARTON
                rptDispatchingNote_TripCombine_ByProducts report = new rptDispatchingNote_TripCombine_ByProducts();

                var dataSource = FileProcess.LoadTable("STDispatchingNote_TripCombine_ByProducts @TripID=" + currentTrip.TripID + ", @pcs=0");
                report.DataSource = dataSource;
                report.RequestParameters = false;
                report.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
                report.Parameters["Barcode"].Value = "TW" + tripID.ToString("D9");
                ReportPrintToolWMS printTool = new ReportPrintToolWMS(report)
                {
                    AutoShowParametersPanel = false
                };


                printTool.ShowPreview();
            }
        }

        private void btn_Preview_MultiPlan_Combined_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int PCS = 0;
            if (currentTrip.TripID <= 0)
                MessageBox.Show("An error was encountered. Please return to the close form and try again.", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (tripDetailsList.Count() == 0)
                MessageBox.Show("No data. Please enter details!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                int bcTripID = Convert.ToInt32(Convert.ToString(teTripID.EditValue).Substring(3));
                var bcTrip = "TW" + String.Format("{0:D9}", bcTripID);
                DataProcess<CustomerRequirements> customerR = new DataProcess<CustomerRequirements>();
                CustomerRequirements customerRequired = customerR.Executing("SELECT * FROM  CustomerRequirements WHERE (CustomerMainID = " + currentTrip.CustomerMainID + ") AND (RequirementConfirmed = 1) And(RequirementCategory=2) ORDER BY UpdateTime ASC").FirstOrDefault();
                Customers cus = AppSetting.CustomerList.Where(c => c.CustomerID == Convert.ToInt32(lkeCustomerNumber.EditValue)).FirstOrDefault();
                if (cus.CustomerType.Equals(CustomerTypeEnum.RANDOM_WEIGHT))
                {
                    rptDispatchingPlan_TripCombine_ByProducts_KGR dPlan = new rptDispatchingPlan_TripCombine_ByProducts_KGR();
                    PCS = 1;
                    dPlan.RequestParameters = false;
                    dPlan.DataSource = FileProcess.LoadTable("STDispatchingNote_TripCombine_ByProducts @TripID=" + currentTrip.TripID + ", @pcs=" + PCS);
                    if (customerRequired != null)
                    {
                        dPlan.Parameters["varCustomerRequired"].Value = customerRequired.RequirementDetails;
                    }
                    dPlan.Parameters["varTripBarCode"].Value = bcTrip;

                    dPlan.Parameters["varTripID"].Value = teTripID.EditValue;
                    dPlan.Parameters["varNote"].Value = memoTruckAndDetails.EditValue;
                    dPlan.Parameters["varVehicle"].Value = txtVehicleNumber.EditValue;
                    dPlan.Parameters["varDate"].Value = deTripDate.EditValue;
                    dPlan.Parameters["varCustomerNumber"].Value = lkeCustomerNumber.EditValue;
                    dPlan.Parameters["varCustomerName"].Value = teCustomerName.EditValue;

                    dPlan.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
                    ReportPrintToolWMS printTool = new ReportPrintToolWMS(dPlan)
                    {
                        AutoShowParametersPanel = false
                    };


                    printTool.ShowPreview();

                }
                else
                {
                    rptDispatchingPlan_TripCombine_ByProducts dPlan = new rptDispatchingPlan_TripCombine_ByProducts();
                    PCS = 0;
                    dPlan.RequestParameters = false;
                    dPlan.DataSource = FileProcess.LoadTable("STDispatchingNote_TripCombine_ByProducts @TripID=" + currentTrip.TripID + ", @pcs=" + PCS);
                    if (customerRequired != null)
                    {
                        dPlan.Parameters["varCustomerRequired"].Value = customerRequired.RequirementDetails;
                    }
                    dPlan.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
                    ReportPrintToolWMS printTool = new ReportPrintToolWMS(dPlan)
                    {
                        AutoShowParametersPanel = false
                    };


                    printTool.ShowPreview();
                }






            }

        }

        private void btnPickingListData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_WM_Dialog_PickingSlip Pick = new frm_WM_Dialog_PickingSlip(tripID, "TW");
            Pick.Show();
        }

        private void bbutonAcceptAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Code here to accept all the Orders within the Trip 
            if (this.lkeCustomerNumber.EditValue == null ||
                this.currentTrip == null ||
                this.currentTrip.TripID <= 0 ||
                this.currentTrip.TripConfirmed) return;
            TransactionDAC tc = new TransactionDAC();
            int orderID = 0;
            foreach (ST_WMS_LoadTripManagementDetails_Result tripItem in this.tripDetailsList)
            {
                if (tripItem == null || string.IsNullOrEmpty(tripItem.OrderNumber)) continue;
                orderID = Convert.ToInt32(tripItem.OrderNumber.Split('-')[1]);
                tc.STTransactionInsertAll(orderID, tripItem.OrderNumber, AppSetting.CurrentUser.LoginName, this.currentTrip.CustomerNumber);
            }
            MessageBox.Show("Successful", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bbtnDipatchingPlanSummary_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataTable customerRequired = FileProcess.LoadTable("STCustomerRequirementPrint @CustomerMainID=" + currentTrip.CustomerMainID + ",@Flag=2, @ReceivingOrderID=null");
            string customerRequire = "";
            foreach (DataRow row in customerRequired.Rows)
            {
                customerRequire += row["RequirementDetails"].ToString();
            }

            rptDispatchingPlanA4New_TripSummary rpt = new rptDispatchingPlanA4New_TripSummary();
            //rptDispatchingNote_Trip report = new rptDispatchingNote_Trip();
            rpt.DataSource = FileProcess.LoadTable("STTripPickingList " + this.tripID);

            rpt.RequestParameters = false;
            if (customerRequired != null)
            {
                rpt.Parameters["varCustomerRequired"].Value = customerRequire;
            }
            rpt.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
            ReportPrintToolWMS PrintTool = new ReportPrintToolWMS(rpt);
            PrintTool.ShowPreview();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // int TripID = Convert.ToInt32(teTripID.Text.Substring(3));
            DataProcess<Object> DA = new DataProcess<object>();
            int result = DA.ExecuteNoQuery("ST_WMS_RefreshTrip  @TripID={0}", this.tripID);
            if (result < 0)
            {
                MessageBox.Show("Error", "WMS");
            }
            else
            {
                this.ReloadData(this.tripID);
                MessageBox.Show("Refresh Done", "WMS");
            }
        }

        private void teTripID_DoubleClick(object sender, EventArgs e)
        {
            //Delete all DO in trip, and delete trip

            if (XtraMessageBox.Show("Are you sure you want to delete all DO(s) in this Trip on WMS ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataProcess<Object> DA = new DataProcess<object>();
                int result = DA.ExecuteNoQuery("STDeleteDOByTripID " + this.tripID + ", '" + AppSetting.CurrentUser.LoginName + "'");
                if (result < 0)
                {
                    MessageBox.Show("Error", "WMS");
                }
                else
                {
                    this.ReloadData(this.tripID);
                    MessageBox.Show("Deleted", "WMS");
                }
            }

        }

        private void btn_PreviewDO_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            rptPickingConfirmationByRoomA5 rpt = new rptPickingConfirmationByRoomA5(true);
            var dataSource = FileProcess.LoadTable("STTripPickingListByRoom @TripID=" + tripID);
            rpt.DataSource = dataSource;

            ReportPrintToolWMS printTool = new ReportPrintToolWMS(rpt);
            printTool.ShowPreviewDialog();
        }

        private void btn_print_trucknumber_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_WM_QuantitiesOfPrint frm = new frm_WM_QuantitiesOfPrint();
            frm.ShowDialog();
            qtyPrint = frm.Qty;
            if (qtyPrint == 0) return;

            rptDOSpecialRequirementPrint rp = new rptDOSpecialRequirementPrint();

            rp.txtCustomerNumber.Text = lkeCustomerNumber.Text;
            rp.txtCustomerName.Text = teCustomerName.Text;
            rp.txtDispatchingOrderDate.Text = deTripDate.Text;
            rp.txtDispatchingOrderNumber.Text = teTripID.Text;
            rp.txtSpecialRequirement.Text = memoTruckAndDetails.Text;
            rp.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
            rp.RequestParameters = false;
            rp.CreateDocument();

            for (int i = 0; i < qtyPrint - 1; i++)
            {
                rptDOSpecialRequirementPrint rptmp = new rptDOSpecialRequirementPrint();
                rptmp.txtCustomerNumber.Text = lkeCustomerNumber.Text;
                rptmp.txtCustomerName.Text = teCustomerName.Text;
                rptmp.txtDispatchingOrderDate.Text = deTripDate.Text;
                rptmp.txtDispatchingOrderNumber.Text = teTripID.Text;
                rptmp.txtSpecialRequirement.Text = memoTruckAndDetails.Text;
                rptmp.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
                rptmp.CreateDocument();
                rp.Pages.AddRange(rptmp.Pages);
            }

            // Reset all page numbers in the resulting document. 
            rp.PrintingSystem.ContinuousPageNumbering = true;
            rp.Print();
        }

        private void textEditTripOrderProgress_Leave(object sender, EventArgs e)
        {
            if (this.textEditTripOrderProgress.IsModified)
            {
                DataProcess<object> tripDA = new DataProcess<object>();
                tripDA.ExecuteNoQuery("Update Trips Set Trips.TripOrderProgress = {0} Where Trips.TripID = {1}", this.textEditTripOrderProgress.EditValue, currentTrip.TripID);
                this.currentTrip.TripOrderProgress = Convert.ToByte(this.textEditTripOrderProgress.EditValue);
            }
        }

        private void btn_PrintTruckNote_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_WM_QuantitiesOfPrint frm = new frm_WM_QuantitiesOfPrint();
            frm.ShowDialog();
            qtyPrint = frm.Qty;
            if (qtyPrint == 0) return;

            rptDOSpecialRequirementPrint rp = new rptDOSpecialRequirementPrint();

            rp.txtCustomerNumber.Text = lkeCustomerNumber.Text;
            rp.txtCustomerName.Text = teCustomerName.Text;
            rp.txtDispatchingOrderDate.Text = deTripDate.Text;
            rp.txtDispatchingOrderNumber.Text = teTripID.Text;
            rp.txtSpecialRequirement.Text = memoTruckAndDetails.Text;
            rp.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
            rp.RequestParameters = false;
            rp.CreateDocument();

            for (int i = 0; i < qtyPrint - 1; i++)
            {
                rptDOSpecialRequirementPrint rptmp = new rptDOSpecialRequirementPrint();
                rptmp.txtCustomerNumber.Text = lkeCustomerNumber.Text;
                rptmp.txtCustomerName.Text = teCustomerName.Text;
                rptmp.txtDispatchingOrderDate.Text = deTripDate.Text;
                rptmp.txtDispatchingOrderNumber.Text = teTripID.Text;
                rptmp.txtSpecialRequirement.Text = memoTruckAndDetails.Text;
                rptmp.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
                rptmp.CreateDocument();
                rp.Pages.AddRange(rptmp.Pages);
            }

            // Reset all page numbers in the resulting document. 
            rp.PrintingSystem.ContinuousPageNumbering = true;
            rp.Print();
        }

        private void deRoadEnd_EditValueChanged(object sender, EventArgs e)
        {
            if (this.deRoadEnd.IsModified)
            {
                DataProcess<object> tripDA = new DataProcess<object>();
                tripDA.ExecuteNoQuery("Update Trips Set Trips.OnRoadEndTime = '" + this.deRoadEnd.DateTime.ToString("yyyy-MM-dd HH:mm")
                    + "' Where Trips.TripID = " + currentTrip.TripID);
            }
        }

        private void deRoadStart_EditValueChanged(object sender, EventArgs e)
        {
            if (this.deRoadStart.IsModified)
            {
                DataProcess<object> tripDA = new DataProcess<object>();
                tripDA.ExecuteNoQuery("Update Trips Set Trips.OnRoadStartTime = '" + this.deRoadStart.DateTime.ToString("yyyy-MM-dd HH:mm")
                    + "' Where Trips.TripID = " + currentTrip.TripID);
            }
        }

        private void deRoadStart_DoubleClick(object sender, EventArgs e)
        {
            if (this.dtEndTime.Text != "")
            {
                this.deRoadStart.Text = this.dtEndTime.Text;
                //DataProcess<object> tripDA = new DataProcess<object>();
                //tripDA.ExecuteNoQuery("Update Trips Set Trips.OnRoadStartTime = '" + this.deRoadEnd.DateTime.ToString("yyyy-MM-dd HH:mm")
                //    + "' Where Trips.TripID = " + currentTrip.TripID);
            }

        }

        private void btn_Preview_DeliveryNoteGF_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Customers customer;
            customer = AppSetting.CustomerList.FirstOrDefault(c => c.CustomerID == currentTrip.CustomerID);

            if (customer == null)
            {
                return;
            }

            rptDeliveryNoteGoodFood report = new rptDeliveryNoteGoodFood();


            var dataSource = FileProcess.LoadTable("STDispatchingNote_TripCombine_ByProducts @TripID=" + currentTrip.TripID + ", @pcs=2");
            report.DataSource = dataSource;
            report.RequestParameters = false;
            ReportPrintToolWMS printTool = new ReportPrintToolWMS(report)
            {
                AutoShowParametersPanel = false
            };


            printTool.ShowPreview();
        }

        private void btnReceivingAdviceCombined_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.AdviceLabelA4Report(true);
        }

        private void AdviceLabelA4Report(bool isPreview)
        {
            string customerType = this.lkeCustomerNumber.GetColumnValue("CustomerType").ToString();
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
        private void printReceivingAdvice(bool isPreview)
        {
            int tripID = Convert.ToInt32(currentTrip.TripID);
            rptReceivingAdvice RA = new rptReceivingAdvice();
            RA.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
            RA.Parameters["varReceivingOrderID"].Value = tripID;
            RA.DataSource = FileProcess.LoadTable("STReceivingAdviceTrip " + tripID);
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
            int tripID = Convert.ToInt32(currentTrip.TripID);
            rptReceivingAdvice_Lanscape RA = new rptReceivingAdvice_Lanscape();
            RA.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
            RA.Parameters["varReceivingOrderID"].Value = tripID;
            RA.DataSource = FileProcess.LoadTable("STReceivingAdviceTrip " + tripID);
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
            int tripID = Convert.ToInt32(currentTrip.TripID);
            rptReceivingAdvice_pcs RA = new rptReceivingAdvice_pcs();
            RA.Parameters["CurrentUser"].Value = AppSetting.CurrentUser.LoginName;
            RA.Parameters["varReceivingOrderID"].Value = tripID;
            RA.DataSource = FileProcess.LoadTable("STReceivingAdviceTrip " + tripID);
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
        private void printLabelA4short(bool isPreview)
        {
            int tripID = Convert.ToInt32(currentTrip.TripID);
            rptLabelA4Short_Barcode lb = new rptLabelA4Short_Barcode();
            lb.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
            lb.Parameters["parameter1"].Value = 3;
            lb.DataSource = FileProcess.LoadTable("STLabel1ROTrip " + tripID);
            lb.RequestParameters = false;
            //  lb.bcPalletID.Text = "*" + tripID.ToString() + "*";

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
        private void printlabelA4short_pcs(bool isPreview)
        {
            int tripID = Convert.ToInt32(currentTrip.TripID);
            rptLabelA4Short_Barcode_pcs reportA4ShortPcs = new rptLabelA4Short_Barcode_pcs();
            reportA4ShortPcs.Parameters["varReceivingOrderID"].Value = tripID;
            reportA4ShortPcs.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
            reportA4ShortPcs.Parameters["parameter1"].Value = 3;
            reportA4ShortPcs.RequestParameters = false;
            reportA4ShortPcs.DataSource = FileProcess.LoadTable("STLabel1ROTrip " + tripID);
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

        private void btnTestMultipleReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //rptDispatchingNote rptDispatchingNote = new rptDispatchingNote();
            //string savedPath = "D:\\WMS-2017\\Attachments\\PaySlips\\";
            //String orderNumber = "";
            //for (int i = 0; i < grvTripDetails.DataRowCount -1; i++)
            //{
            //    orderNumber = Convert.ToString(this.grvTripDetails.GetRowCellValue(i, "OrderNumber"));
            //    if (orderNumber.Length == 0) break;
            //    int dispatchingOrderID = Convert.ToInt32(orderNumber.Substring(3));
            //    rptDispatchingNote.Parameters["varDispatchingOrderID"].Value = dispatchingOrderID;
            //    rptDispatchingNote.Parameters["varCurrentUser"].Value = fullInfoEmployees.FullName;
            //    rptDispatchingNote.Parameters["Barcode"].Value = orderNumber;
            //    rptDispatchingNote.RequestParameters = false;
            //    rptDispatchingNote.DataSource = FileProcess.LoadTable("STDispatchingNote @varDispatchingOrderID=" + dispatchingOrderID);
            //    rptDispatchingNote.ExportToPdf(savedPath + "DispatchingNote" + orderNumber + ".pdf");
            //}
            //var pdfFiles = Directory.EnumerateFiles(savedPath, "*.pdf", SearchOption.TopDirectoryOnly);
            //string zfileName = savedPath + "CombinedDispatchingNote_" + currentTrip.TripNumber + ".zip";
            //var zip =  ZipFile.Open(zfileName, ZipArchiveMode.Create);
            //foreach (var file in pdfFiles)
            //{
            //    zip.CreateEntryFromFile(file, Path.GetFileName(file), CompressionLevel.Optimal);
            //}
            //zip.Dispose();

        }

        private void btnLockEDI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {



            // This action will send EDI, Lock Order but not confirm. The USers will have to confirm it again
            DataProcess<object> tripEDI = new DataProcess<object>();
            int cusID = Convert.ToInt32(this.lkeCustomerNumber.EditValue);

            Customers cus = AppSetting.CustomerList.Where(c => c.CustomerID == cusID).FirstOrDefault();

            if (this.currentTrip.TripRemark != null && this.currentTrip.TripRemark.Length > 10)
                if (this.currentTrip.TripRemark.Contains("EDI Sent"))
                {
                    if (MessageBox.Show("Already send EDI before, do you want to send again?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                }


            if (cus.CustomerNumber.ToUpper().Contains("BEL"))
            {
                //foreach (var item in tripDetailsList)
                //{
                //    tripEDI.ExecuteNoQuery("STConfirmAllLockSendEDI " + (item.OrderNumber).Substring(3) + " , 0 , '" + AppSetting.CurrentUser.LoginName + "'");
                //}


                //foreach (var item in tripDetailsList)
                //{
                //    tripEDI.ExecuteNoQuery("ST_BEL_EDIExportDO_Lot1 " + (item.OrderNumber).Substring(3) + ",'" + AppSetting.CurrentUser.LoginName + "'");
                //}

                int type = 0;
                foreach (var item in tripDetailsList)
                {
                    if (item != null && item.OrderNumber != null)
                    {
                        if (item.OrderNumber.Contains("RO"))
                            type = 1;
                        else
                            type = 0;

                        string sql = "STEDI_SendRODO  " + (item.OrderNumber).Substring(3) + ", " + type + " ,'" + AppSetting.CurrentUser.LoginName + "'";
                        tripEDI.ExecuteNoQuery(sql);
                    }
                }

                this.memoTruckAndDetails.Text = "EDI Sent to Customer | " + DateTime.Now.ToString() + " | " + this.currentTrip.TripRemark;
            }


            //tripEDI.ExecuteNoQuery("STEDI_SendTripDONoConfirm " + currentTrip.TripID + ",'" + AppSetting.CurrentUser.LoginName + "'");
            //this.currentTrip.TripRemark = "EDI Sent to Customer | " + this.currentTrip.TripRemark;
        }

        private void btn_ViewMultiNoteCombineWeighted_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            rptDispatchingNote_TripPlannedWeight report = new rptDispatchingNote_TripPlannedWeight();
            //report.Parameters["varLoginUser"].Value = AppSetting.CurrentUser.LoginName;
            report.Parameters["varCurrentUser"].Value = fullInfoEmployees.FullName;
            //report.Parameters["Barcode"].Value = "TW" + tripID.ToString("D9");
            report.RequestParameters = false;
            var dataSource = FileProcess.LoadTable("STDispatchingNote_Client_Trip @TripID=" + currentTrip.TripID);
            report.DataSource = dataSource;
            ReportPrintToolWMS printTool = new ReportPrintToolWMS(report);
            printTool.AutoShowParametersPanel = false;

            printTool.ShowPreview();
        }

        private void btnSyncNavi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!NetworkHelper.IsConnectedToInternet())
            {
                MessageBox.Show("Không thể kết nối với Warenavi ! vui lòng kiểm tra đường truyền !", "TWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this.tripDetailsList == null || this.tripDetailsList.Count <= 0)
            {
                MessageBox.Show("Dữ liệu không hợp lệ !", "TWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string url = ConfigurationManager.AppSettings["RetrievalPlanData_Navi"];
            // Co product nao da accept chua
            int hasRoDetailAccept = Convert.ToInt32(FileProcess.LoadTable("STCheckTripHasAccept @TripID=" + this.tripID).Rows[0]["HasAccept"]);
            if (hasRoDetailAccept <= 0)
            {
                MessageBox.Show("Trip chưa được accept vui lòng accept trước khi gửi sang Navi !", "TWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataProcess<Object> DA = new DataProcess<object>();
            int resultInsert = DA.ExecuteNoQuery("STSendTripToNavi @TripID={0}", this.tripID);
            if (resultInsert > 0)
            {
                // Call API to post 
                APIProcess api = new APIProcess();

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
        }

        /// <summary>
        /// Check this trip has send navi
        /// </summary>
        /// <returns></returns>
        private bool HasSendNavi()
        {
            bool hasSend = false;
            int totalSend = Convert.ToInt32(FileProcess.LoadTable("STCheckTripHasSendNavi @TripID=" + this.tripID).Rows[0]["HasSendNavi"]);
            if (totalSend > 0) hasSend = true;
            return hasSend;
        }
    }
}
