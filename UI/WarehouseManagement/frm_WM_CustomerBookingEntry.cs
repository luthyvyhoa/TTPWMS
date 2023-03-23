using DA;
using DA.Warehouse;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Helper;
using UI.ReportForm;
using log4net;
using UI.MasterSystemSetup;
using UI.Management;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_CustomerBookingEntry : Common.Controls.frmBaseForm
    {

        private CustomerBookingDA _bookingDA;
        private DataTable _tbBookings;
        private DataRow _currentBooking;
        private bool _isAddNew;
        private bool _isModified;
        private int _isBookingBlast;
        private string _bookingNumber;
        private DataProcess<Products> pData = new DataProcess<Products>();
        private DataProcess<CustomerBookingDetails> CustomerBookingDetailsDA = new DataProcess<CustomerBookingDetails>();
        private static readonly log4net.ILog log = LogManager.GetLogger(typeof(frm_WM_CustomerBookingEntry));
        string m_userName = AppSetting.CurrentUser.LoginName;
        public bool IsAddNew
        {
            get
            {
                return this._isAddNew;
            }
            set
            {
                this._isAddNew = value;
            }
        }

        public string BookingNumber
        {
            get
            {
                return this._bookingNumber;
            }
            set
            {
                this._bookingNumber = value;
            }
        }

        public frm_WM_CustomerBookingEntry(int isBookingBlast = 0)
        {
            InitializeComponent();
            this._bookingDA = new CustomerBookingDA();
            this._tbBookings = new DataTable();
            this._isAddNew = false;
            this._isModified = false;
            this._bookingNumber = String.Empty;
            this._isBookingBlast = isBookingBlast;

            if (dtBookingDate.EditValue == null)
            {
                dtBookingDate.EditValue = DateTime.Now;
            }

            InitWarehouse();
            InitCustomers();
            InitStatus();
            InitVehicleTypes();
            InitOrderType();
            InitTimeSlot();
            SetEvents();
            if (isBookingBlast == 0)
            {
                btn_ProcessBlast.Enabled = false;
            }
            else
            {
                btn_ProcessBlast.Enabled = true;
            }
        }

        private void frm_WM_CustomerBookingEntry_Load(object sender, EventArgs e)
        {

            LoadBookings();
        }

        private void SetEvents()
        {
            this.lkeTimeSlot.CloseUp += LkeTimeSlot_CloseUp;
            this.lkeCustomers.CloseUp += LkeCustomers_CloseUp;
            this.lkeOrderType.CloseUp += LkeOrderType_CloseUp;
            this.lkeStatus.CloseUp += LkeStatus_CloseUp;
            this.lkeStore.CloseUp += LkeStore_CloseUp;
            this.lkeVehicleType.CloseUp += LkeVehicleType_CloseUp;
            this.txtCartons.TextChanged += TxtCartons_TextChanged;
            this.txtOrderNumber.TextChanged += TxtOrderNumber_TextChanged;
            this.txtPallets.TextChanged += TxtPallets_TextChanged;
            this.txtUnit.TextChanged += TxtUnit_TextChanged;
            this.txtVehicleNumber.TextChanged += TxtVehicleNumber_TextChanged;
            this.txtWeight.TextChanged += TxtWeight_TextChanged;
            this.mmeRequestDescription.TextChanged += MmeRequestDescription_TextChanged;
            this.mmeResponsedDescription.TextChanged += MmeResponsedDescription_TextChanged;
            this.dtBookingDate.EditValueChanged += DtBookingDate_EditValueChanged;
            this.txtOrderNumber.DoubleClick += TxtOrderNumber_DoubleClick;
            this.nvtBookings.PositionChanged += NvtBookings_PositionChanged;
            this.nvtBookings.ButtonClick += NvtBookings_ButtonClick;
            this.btnConfirm.Click += BtnConfirm_Click;
            this.btnMakeOrder.Click += BtnMakeOrder_Click;
            this.btnMail.Click += BtnMail_Click;
            this.btnDelete.Click += BtnDelete_Click;
            this.btnClose.Click += BtnClose_Click;
            this.FormClosing += frm_WM_CustomerBookingEntry_FormClosing;
        }

        void frm_WM_CustomerBookingEntry_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        #region Events
        private void DtBookingDate_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.IsDBNull(this._currentBooking["BookingDate"])) return;
            this._currentBooking["BookingDate"] = this.dtBookingDate.DateTime;

            if (!this.IsAddNew)
            {
                this._isModified = true;
            }

        }

        private void MmeResponsedDescription_TextChanged(object sender, EventArgs e)
        {
            this._currentBooking["ResponsedDescription"] = mmeResponsedDescription.Text;
            if (!this.IsAddNew)
            {
                this._isModified = true;
            }
        }

        private void MmeRequestDescription_TextChanged(object sender, EventArgs e)
        {
            this._currentBooking["RequestDescription"] = mmeRequestDescription.Text;
            if (!this.IsAddNew)
            {
                this._isModified = true;
            }
        }

        private void TxtWeight_TextChanged(object sender, EventArgs e)
        {
            
            if (!this.IsAddNew)
            {
                this._isModified = true;
                this._currentBooking["Weights"] = Convert.ToDecimal(txtWeight.Text);
            }
            
        }

        private void TxtVehicleNumber_TextChanged(object sender, EventArgs e)
        {
            this._currentBooking["VehicleNumber"] = txtVehicleNumber.Text;
            if (!this.IsAddNew)
            {
                this._isModified = true;
            }
        }

        private void TxtUnit_TextChanged(object sender, EventArgs e)
        {
            this._currentBooking["Units"] = Convert.ToInt32(txtUnit.Text);
            if (!this.IsAddNew)
            {
                this._isModified = true;
            }
        }

        private void TxtPallets_TextChanged(object sender, EventArgs e)
        {
            this._currentBooking["Pallets"] = Convert.ToInt32(txtPallets.Text);
            if (!this.IsAddNew)
            {
                this._isModified = true;
            }
        }

        private void TxtOrderNumber_TextChanged(object sender, EventArgs e)
        {
            this._currentBooking["OrderNumber"] = txtOrderNumber.Text;
            if (!this.IsAddNew)
            {
                this._isModified = true;
            }
        }

        private void TxtCartons_TextChanged(object sender, EventArgs e)
        {
            var carton = txtCartons.Text;
            this._currentBooking["Cartons"] = Convert.ToInt32(carton.Replace(",", ""));
            if (!this.IsAddNew)
            {
                this._isModified = true;
            }
        }

        private void LkeVehicleType_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            this._currentBooking["VehicleType"] = Convert.ToString(e.Value);
            if (!this.IsAddNew)
            {
                this._isModified = true;
            }
        }

        private void LkeStore_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            this._currentBooking["WarehouseID"] = Convert.ToByte(e.Value);
            if (!this.IsAddNew)
            {
                this._isModified = true;
            }
        }

        private void LkeStatus_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            this._currentBooking["Status"] = Convert.ToString(e.Value);
            if (!this.IsAddNew)
            {
                this._isModified = true;
            }
        }

        private void LkeOrderType_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            this._currentBooking["OrderType"] = Convert.ToString(e.Value);
            if (!this.IsAddNew)
            {
                this._isModified = true;
            }
        }

        private void LkeTimeSlot_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            this.lkeTimeSlot.EditValue = e.Value;
            this._currentBooking["TimeSlotID"] = Convert.ToInt32(e.Value);
            if (this.lkeTimeSlot.EditValue == null) return;
            if (this.IsAddNew || string.IsNullOrEmpty(this.txtBookingNumber.Text))
            {
                CustomerBookings booking = new CustomerBookings();
                booking.BookingID = (Guid)this._currentBooking["BookingID"];
                booking.CustomerID = Convert.ToInt32(this.lkeCustomers.EditValue);
                booking.CreatedBy = this.txtCreatedBy.Text;
                booking.CreatedTime = DateTime.Now;
                booking.BookingDate = this.dtBookingDate.EditValue == null ? (DateTime?)null : Convert.ToDateTime(this.dtBookingDate.DateTime.ToString("yyyy-MM-dd"));
                booking.Cartons = Convert.IsDBNull(this._currentBooking["Cartons"]) ? (int?)null : Convert.ToInt32(this._currentBooking["Cartons"]);
                booking.IsDeleted = false;
                booking.OrderType = this.lkeOrderType.EditValue == null ? null : Convert.ToString(this._currentBooking["OrderType"]);
                booking.Pallets = Convert.IsDBNull(this._currentBooking["Pallets"]) ? (int?)null : Convert.ToInt32(this._currentBooking["Pallets"]);
                booking.RequestDescription = String.IsNullOrEmpty(this.mmeRequestDescription.Text) ? null : Convert.ToString(this._currentBooking["RequestDescription"]);
                booking.ResponsedDescription = String.IsNullOrEmpty(this.mmeResponsedDescription.Text) ? null : Convert.ToString(this._currentBooking["ResponsedDescription"]);
                booking.Status = this.lkeStatus.EditValue == null ? null : Convert.ToString(this._currentBooking["Status"]);
                booking.TimeSlotID = this.lkeTimeSlot.EditValue == null ? (int?)null : Convert.ToInt32(this._currentBooking["TimeSlotID"]);
                booking.Units = Convert.IsDBNull(this._currentBooking["Units"]) ? (int?)null : Convert.ToInt32(this._currentBooking["Units"]);
                booking.VehicleNumber = String.IsNullOrEmpty(this.txtVehicleNumber.Text) ? null : Convert.ToString(this._currentBooking["VehicleNumber"]);
                booking.VehicleType = this.lkeVehicleType.EditValue == null ? null : Convert.ToString(this._currentBooking["VehicleType"]);
                booking.WarehouseID = this.lkeStore.EditValue == null ? (byte?)null : Convert.ToByte(this._currentBooking["WarehouseID"]);
                booking.Weights = Convert.IsDBNull(this._currentBooking["Weights"]) ? (decimal?)null : Convert.ToDecimal(this._currentBooking["Weights"]);

                int result = this._bookingDA.Insert(booking);
                if (result == -2)
                {
                    XtraMessageBox.Show("Error");
                }
                else
                {
                    this.IsAddNew = false;
                    LoadBookings();
                }
            }
            else
            {
                this._isModified = true;
            }
        }

        private void LkeCustomers_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            this.lkeCustomers.EditValue = e.Value;
            this._currentBooking["CustomerID"] = Convert.ToInt32(e.Value);
            this.txtCustomerName.Text = Convert.ToString(this.lkeCustomers.GetColumnValue("CustomerName"));
            if (this.IsAddNew)
            {
                this.lkeTimeSlot.Focus();
                this.lkeTimeSlot.ShowPopup();
            }
            else
            {
                this._isModified = true;
            }
        }

        private void TxtOrderNumber_DoubleClick(object sender, EventArgs e)
        {
            if (this.txtOrderNumber.Text.Substring(0, 2).Equals("RO"))
            {
                frm_WM_ReceivingOrders.Instance.ReceivingOrderIDFind = Convert.ToInt32(this.txtOrderNumber.Text.Substring(3));
                this.UpdateReceivingProduct(frm_WM_ReceivingOrders.Instance.ReceivingOrderIDFind);
                frm_WM_ReceivingOrders.Instance.Show();
            }
            else
            {
                int orderID = Convert.ToInt32(this.txtOrderNumber.Text.Substring(3));
                var frmDispatching = frm_WM_DispatchingOrders.GetInstance(orderID);
                if (frmDispatching.Visible)
                {
                    frmDispatching.ReloadData();
                }
                frmDispatching.Show();
            }
        }

        private void NvtBookings_PositionChanged(object sender, EventArgs e)
        {
            this._currentBooking = this._tbBookings.Rows[this.nvtBookings.Position];
            BindData();
        }

        private void NvtBookings_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            switch (e.Button.ButtonType)
            {
                case NavigatorButtonType.Append:
                    {
                        this.IsAddNew = true;
                        this._currentBooking = this._tbBookings.NewRow();
                        this._currentBooking["BookingID"] = Guid.NewGuid();
                        this._currentBooking["CreatedBy"] = AppSetting.CurrentUser.LoginName;
                        this._currentBooking["Status"] = "Processing";
                        this._currentBooking["WarehouseID"] = 1;
                        this._currentBooking["CustomerID"] = 0;
                        this._currentBooking["TimeSlotID"] = 0;
                        this._currentBooking["TimeSlot"] = "0";
                        this._currentBooking["CreatedTime"] = DateTime.Now;
                        this._tbBookings.Rows.Add(this._currentBooking);

                        this.nvtBookings.DataSource = this._tbBookings;
                        this.nvtBookings.Position = this._tbBookings.Rows.Count;
                        this._currentBooking = this._tbBookings.Rows[this.nvtBookings.Position];
                        BindData();
                        this.lkeCustomers.Focus();
                        this.lkeCustomers.ShowPopup();
                        e.Handled = true;
                        break;
                    }
                default:
                    {
                        if (this._isModified)
                        {
                            if (string.IsNullOrEmpty(this.txtBookingNumber.Text)) return;
                            CustomerBookings booking = this._bookingDA.Select().FirstOrDefault(b => b.BookingNumber.Equals(this.txtBookingNumber.Text));
                            booking.CustomerID = Convert.ToInt32(this._currentBooking["CustomerID"]);
                            booking.BookingDate = this.dtBookingDate.EditValue == null ? (DateTime?)null : Convert.ToDateTime(this.dtBookingDate.DateTime.ToString("yyyy-MM-dd"));
                            booking.Cartons = Convert.IsDBNull(this._currentBooking["Cartons"]) ? (int?)null : Convert.ToInt32(this._currentBooking["Cartons"]);
                            booking.OrderType = this.lkeOrderType.EditValue == null ? null : Convert.ToString(this._currentBooking["OrderType"]);
                            booking.Pallets = Convert.IsDBNull(this._currentBooking["Pallets"]) ? (int?)null : Convert.ToInt32(this._currentBooking["Pallets"]);
                            booking.RequestDescription = String.IsNullOrEmpty(this.mmeRequestDescription.Text) ? null : Convert.ToString(this._currentBooking["RequestDescription"]);
                            booking.ResponsedDescription = String.IsNullOrEmpty(this.mmeResponsedDescription.Text) ? null : Convert.ToString(this._currentBooking["ResponsedDescription"]);
                            booking.Status = this.lkeStatus.EditValue == null ? null : Convert.ToString(this._currentBooking["Status"]);
                            booking.TimeSlotID = this.lkeTimeSlot.EditValue == null ? (int?)null : Convert.ToInt32(this._currentBooking["TimeSlotID"]);
                            booking.Units = Convert.IsDBNull(this._currentBooking["Units"]) ? (int?)null : Convert.ToInt32(this._currentBooking["Units"]);
                            booking.VehicleNumber = String.IsNullOrEmpty(this.txtVehicleNumber.Text) ? null : Convert.ToString(this._currentBooking["VehicleNumber"]);
                            booking.VehicleType = this.lkeVehicleType.EditValue == null ? null : Convert.ToString(this._currentBooking["VehicleType"]);
                            booking.WarehouseID = this.lkeStore.EditValue == null ? (byte?)null : Convert.ToByte(this._currentBooking["WarehouseID"]);
                            booking.Weights = Convert.IsDBNull(this._currentBooking["Weights"]) ? (decimal?)null : Convert.ToDecimal(this._currentBooking["Weights"]);

                            int result = this._bookingDA.Update(booking);
                            if (result == -2)
                            {
                                XtraMessageBox.Show("Error");
                            }
                            //this._isModified = false;
                            e.Handled = false;
                        }
                        break;
                    }
            }
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            Guid customerBookingID = (Guid)this._currentBooking["BookingID"];
            var detailOld = this.CustomerBookingDetailsDA.Select(x => x.CustomerBookingID == customerBookingID);
            if (detailOld != null)
            {
                foreach (var objOld in detailOld)
                {
                    this.CustomerBookingDetailsDA.Delete(objOld);
                }
            }
            var detail = (List<CustomerBookingDetails>)this.grdDetails.DataSource;
            if (detail != null)
            {
                this.CustomerBookingDetailsDA.Insert(detail.ToArray());
            }
            CustomerBookings booking = this._bookingDA.Select().FirstOrDefault(b => b.BookingNumber.Equals(this.txtBookingNumber.Text));
            booking.CustomerID = Convert.ToInt32(this._currentBooking["CustomerID"]);
            booking.BookingDate = this.dtBookingDate.EditValue == null ? (DateTime?)null : Convert.ToDateTime(this.dtBookingDate.DateTime.ToString("yyyy-MM-dd"));
            booking.Cartons = Convert.IsDBNull(this._currentBooking["Cartons"]) ? (int?)null : Convert.ToInt32(this._currentBooking["Cartons"]);
            booking.OrderType = this.lkeOrderType.EditValue == null ? null : Convert.ToString(this._currentBooking["OrderType"]);
            booking.Pallets = Convert.IsDBNull(this._currentBooking["Pallets"]) ? (int?)null : Convert.ToInt32(this._currentBooking["Pallets"]);
            booking.RequestDescription = String.IsNullOrEmpty(this.mmeRequestDescription.Text) ? null : Convert.ToString(this._currentBooking["RequestDescription"]);
            booking.ResponsedDescription = String.IsNullOrEmpty(this.mmeResponsedDescription.Text) ? null : Convert.ToString(this._currentBooking["ResponsedDescription"]);
            booking.Status = this.lkeStatus.EditValue == null ? null : Convert.ToString(this._currentBooking["Status"]);
            booking.TimeSlotID = this.lkeTimeSlot.EditValue == null ? (int?)null : Convert.ToInt32(this._currentBooking["TimeSlotID"]);
            booking.Units = Convert.IsDBNull(this._currentBooking["Units"]) ? (int?)null : Convert.ToInt32(this._currentBooking["Units"]);
            booking.VehicleNumber = String.IsNullOrEmpty(this.txtVehicleNumber.Text) ? null : Convert.ToString(this._currentBooking["VehicleNumber"]);
            booking.VehicleType = this.lkeVehicleType.EditValue == null ? null : Convert.ToString(this._currentBooking["VehicleType"]);
            booking.WarehouseID = this.lkeStore.EditValue == null ? (byte?)null : Convert.ToByte(this._currentBooking["WarehouseID"]);
            booking.Weights = Convert.IsDBNull(this._currentBooking["Weights"]) ? (decimal?)null : Convert.ToDecimal(this._currentBooking["Weights"]);
            int result = this._bookingDA.Update(booking);
            if (result == -2)
            {
                XtraMessageBox.Show("Error");
            }
        }

        private void BtnMakeOrder_Click(object sender, EventArgs e)
        {
            if (this.lkeCustomers.EditValue == null)
            {
                return;
            }

            if (!String.IsNullOrEmpty(this.txtOrderNumber.Text))
            {
                return;
            }

            //DataProcess<EDI_Orders> v_Da = new DataProcess<EDI_Orders>();
            //DateTime v_fromDate = v_Da.GetDate().AddDays(-7);
            //DateTime v_toDate = v_Da.GetDate().AddDays(+7);
            //DateTime v_OrderDate = this.dtBookingDate.EditValue == null ? DateTime.Now : this.dtBookingDate.DateTime;
            //DataProcess<object> dataProcess = new DataProcess<object>();
            //if ((v_OrderDate > v_toDate) || (v_OrderDate < v_fromDate))
            //{
            //    XtraMessageBox.Show("Booking date is not correct!!!", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    dtBookingDate.Focus();
            //    return;
            //}
            //int v_Index = this.nvtBookings.Position;
            //if (Convert.ToString(this._currentBooking["Status"]) == "Processing")
            //{
            //    Guid v_BookingID = (Guid)this._currentBooking["BookingID"];
            //    DA.Warehouse.CustomerBookingDA v_DaStandard = new CustomerBookingDA();
            //    if (this._currentBooking["OrderType"].ToString() == "Dispatching")
            //    {
            //        dataProcess.ExecuteNoQuery("STBooking_ProcessDispatchingOrder_Main '" + v_BookingID + "','" + this.m_userName + "'" + ",1");
            //        LoadBookings();
            //        BindData();

            //        this.nvtBookings.Position = v_Index;
            //        string orderNumber = this._tbBookings.Rows[v_Index]["OrderNumber"].ToString();
            //        int orderID = 0;
            //        if (string.IsNullOrEmpty(orderNumber) == false && orderNumber.Length > 3)
            //        {
            //            orderID = Convert.ToInt32(orderNumber.Substring(3, orderNumber.Length - 3));
            //        }


            //        var frmDispatching = frm_WM_DispatchingOrders.GetInstance(orderID);
            //        if (frmDispatching.Visible)
            //        {
            //            frmDispatching.ReloadData();
            //        }
            //        frmDispatching.StartPosition = FormStartPosition.CenterScreen;
            //        frmDispatching.ShowInTaskbar = true;
            //        frmDispatching.Show();

            //    }
            //    else if (this._currentBooking["OrderType"].ToString() == "Receiving")
            //    {
            //        dataProcess.ExecuteNoQuery("STBooking_ProcessReceivingOrder '" + v_BookingID + "','" + this.m_userName + "'");
            //        LoadBookings();
            //        BindData();
            //        this.nvtBookings.Position = v_Index;
            //        string orderNumber = this._tbBookings.Rows[v_Index]["OrderNumber"].ToString();
            //        int orderID = 0;
            //        if (string.IsNullOrEmpty(orderNumber) == false && orderNumber.Length > 3)
            //        {
            //            orderID = Convert.ToInt32(orderNumber.Substring(3, orderNumber.Length - 3));
            //        }
            //        if (orderID == 0)
            //        {
            //            XtraMessageBox.Show("RO is not correct!!!", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            return;
            //        }
            //        UI.WarehouseManagement.frm_WM_ReceivingOrders frm = frm_WM_ReceivingOrders.Instance;
            //        frm.ReceivingOrderIDFind = orderID;
            //        frm.StartPosition = FormStartPosition.CenterScreen;
            //        frm.ShowInTaskbar = false;
            //        frm.Show();
            //    }
            //    else
            //    {
            //        dataProcess.ExecuteNoQuery("STBooking_ProcessReceivingOrder '" + v_BookingID + "','" + this.m_userName + "'");
            //        LoadBookings();
            //        BindData();
            //        this.nvtBookings.Position = v_Index;
            //        string orderNumber = this._tbBookings.Rows[v_Index]["OrderNumber"].ToString();
            //        int orderID = 0;
            //        if (string.IsNullOrEmpty(orderNumber) == false && orderNumber.Length > 3)
            //        {
            //            orderID = Convert.ToInt32(orderNumber.Substring(3, orderNumber.Length - 3));
            //        }
            //        if (orderID == 0)
            //        {
            //            XtraMessageBox.Show("SC is not correct!!!", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            return;
            //        }
            //        frm_WM_PalletStatusChange frmSC = new frm_WM_PalletStatusChange();
            //        frmSC.PalletStatusChangeIDFind = orderID;
            //        frmSC.Show();
            //        frmSC.WindowState = FormWindowState.Maximized;
            //        frmSC.BringToFront();
            //    }
            //}
            //create EDI
            int v_CustomerID = Convert.ToInt32(this.lkeCustomers.EditValue);
            if (v_CustomerID <= 0)
            {
                XtraMessageBox.Show("You must select Customer !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            #region Create Common

            try
            {
                List<ST_WMS_EDI_PickingListsMain_Result> v_ListPicKing = (new DataProcess<ST_WMS_EDI_PickingListsMain_Result>()).Executing("ST_WMS_EDI_PickingListsMain").ToList();
                DataProcess<EDI_Orders> v_DaEDIOrder = new DataProcess<EDI_Orders>();
                foreach (var v_Item in v_ListPicKing)
                {
                    string v_varProcessOrderNum = "";
                    int v_varCustomerID = 0;

                    v_varProcessOrderNum = v_Item.lot_no;
                    try
                    {
                        v_varCustomerID = Convert.ToInt32(v_Item.CustomerID);
                    }
                    catch { }

                    EDI_Orders v_ObjEDIOrder = new EDI_Orders();

                    v_ObjEDIOrder.CustomerOrderNumber = v_Item.lot_no;
                    v_ObjEDIOrder.CustomerOrderNumber2 = v_Item.CustomerOrderNumber2;
                    v_ObjEDIOrder.CustomerClientCode = v_Item.ClientCode;
                    v_ObjEDIOrder.OrderDate = Convert.ToDateTime(v_Item.Pick_date);
                    v_ObjEDIOrder.CustomerReference = v_Item.Truck_no;
                    v_ObjEDIOrder.Client_Name = v_Item.Client_Name;
                    v_ObjEDIOrder.Address = v_Item.Address;
                    v_ObjEDIOrder.CustomerID = v_varCustomerID;
                    v_ObjEDIOrder.OrderType = this._currentBooking["OrderType"].ToString() == "Dispatching" ? 3 :
                        this._currentBooking["OrderType"].ToString() == "Receiving" ? 2 : 4;
                    v_ObjEDIOrder.ProcessingStatus = 1;
                    v_ObjEDIOrder.FileUploaded = false;
                    v_ObjEDIOrder.TotalQuantity = 0;
                    v_ObjEDIOrder.CreatedBy = m_userName;
                    v_ObjEDIOrder.CreatedTime = DateTime.Now;
                    if (v_varCustomerID == 24 || v_varCustomerID == 23 || v_varCustomerID == 767 || v_varCustomerID == 808)
                    {
                        v_ObjEDIOrder.CustomerClientCode = v_Item.ClientCode;
                        var dispatchingType = AppSetting.CustomerListAll.Where(c => c.CustomerID == v_varCustomerID).FirstOrDefault().CustomerDispatchType;
                        v_ObjEDIOrder.CustomerDispatchType = dispatchingType;
                    }
                    else if (v_varCustomerID == 1917 || v_varCustomerID == 1992 || v_varCustomerID == 1993 || v_varCustomerID == 1996)
                    {
                        v_ObjEDIOrder.CustomerClientCode = v_Item.ClientCode;
                        v_ObjEDIOrder.CustomerOrderNumber = v_Item.CustomerOrderNumber;
                    }
                    int v_ret = v_DaEDIOrder.Insert(v_ObjEDIOrder);
                    int indexSpecialChr = v_Item.Truck_no.IndexOf('\'');
                    if (indexSpecialChr > 0)
                    {
                        string convertStr = v_Item.Truck_no.Replace('\'', ' ');
                        v_Item.Truck_no = convertStr;
                    }

                    string v_StrSQL = "";
                    v_StrSQL = " Insert Into EDI_OrderDetails (";
                    v_StrSQL += " EDI_OrderID";
                    v_StrSQL += " ,ProductID ";
                    v_StrSQL += " ,ProductNumber ";
                    v_StrSQL += " ,ProductName ";
                    v_StrSQL += " ,Quantity";
                    v_StrSQL += " ,Status";
                    v_StrSQL += " , ProductRemark ";
                    v_StrSQL += " , ExpiryDate";
                    v_StrSQL += " , ProductionDate";
                    v_StrSQL += " , ReceivingOrderID";
                    v_StrSQL += " , Weights";
                    v_StrSQL += " , Units";
                    v_StrSQL += " , ClientCode";
                    v_StrSQL += " , CustomerRef";
                    v_StrSQL += " , CustomerLocationCode )";

                    v_StrSQL += " SELECT " + v_ObjEDIOrder.EDI_OrderID + "";
                    v_StrSQL += " ,0";
                    v_StrSQL += " ,PickingLists.[ART_NO]";
                    v_StrSQL += " ,LEFT(PickingLists.[DESCR],100)";
                    v_StrSQL += " , PickingLists.Quantity";
                    v_StrSQL += " , 0";
                    v_StrSQL += " , PickingLists.ProductRemark";
                    v_StrSQL += " , PickingLists.ExpiryDate";
                    v_StrSQL += " , PickingLists.ProductionDate";
                    v_StrSQL += " , PickingLists.ReceivingOrderID";
                    v_StrSQL += " , PickingLists.Weights";
                    v_StrSQL += " , PickingLists.Units";
                    v_StrSQL += " , PickingLists.ClientCode";
                    v_StrSQL += " , PickingLists.CustomerRef";
                    v_StrSQL += " , PickingLists.CustomerLocationCode";

                    v_StrSQL += " FROM PickingLists WHERE PickingLists.[lot_no]= N'" + v_varProcessOrderNum + "' ";
                    v_StrSQL += " AND PickingLists.[Truck_no]= N'" + v_Item.Truck_no + "' ";
                    v_StrSQL += " AND PickingLists.[UserCurrent] = N'" + m_userName + "'";

                    int result = v_DaEDIOrder.ExecuteNoQuery(v_StrSQL);
                }
                //
                string v_StrSQL1 = "";
                v_StrSQL1 = "Update EDI_OrderDetails Set Quantity= dbo.FT_CalculatorCartonFromWeightByProductID(Products.ProductID,EDI_OrderDetails.Weights)";
                v_StrSQL1 += " From EDI_OrderDetails inner join EDI_Orders on EDI_OrderDetails.EDI_OrderID=EDI_Orders.EDI_OrderID inner join Customers on EDI_Orders.CustomerID=Customers.CustomerID";
                v_StrSQL1 += " inner join Products on EDI_OrderDetails.ProductNumber = case when Products.ProductNumber Like '%~%' then SUBSTRING(right(Products.ProductNumber,len(Products.ProductNumber)-4), 1, CHARINDEX('~', right(Products.ProductNumber,len(Products.ProductNumber)-4), 1) - 1) else  right(Products.ProductNumber,len(Products.ProductNumber)-4) end ";
                v_StrSQL1 += " Where Customers.CustomerMainID in(280) and ProcessingStatus=1 and EDI_OrderDetails.Quantity is null and EDI_Orders.OrderDate> getdate()-2 and len(Products.ProductNumber)>4";
                DA.Warehouse.EDIOrdersDA v_DaUpdateEDI = new DA.Warehouse.EDIOrdersDA();
                int v_RetUpdateEDI = v_DaUpdateEDI.ExecSQLString(v_StrSQL1);
                XtraMessageBox.Show("Create EDI succesful !", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error Create EDI !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion Create Common
        }

        private void BtnMail_Click(object sender, EventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            int result = this._bookingDA.ExecuteNoQuery("STCustomerBookingNumberDelete @BookingNumber = {0}", this.txtBookingNumber.Text);

            if (result != -2)
            {
                LoadBookings();
            }
            else
            {
                XtraMessageBox.Show("Delete booking failed !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            if (this._isModified)
            {
                CustomerBookings booking = this._bookingDA.Select().FirstOrDefault(b => b.BookingNumber.Equals(this.txtBookingNumber.Text));
                booking.CustomerID = Convert.ToInt32(this._currentBooking["CustomerID"]);
                booking.BookingDate = this.dtBookingDate.EditValue == null ? (DateTime?)null : this.dtBookingDate.DateTime;
                booking.Cartons = Convert.IsDBNull(this._currentBooking["Cartons"]) ? (int?)null : Convert.ToInt32(this._currentBooking["Cartons"]);
                booking.OrderType = this.lkeOrderType.EditValue == null ? null : Convert.ToString(this._currentBooking["OrderType"]);
                booking.Pallets = Convert.IsDBNull(this._currentBooking["Pallets"]) ? (int?)null : Convert.ToInt32(this._currentBooking["Pallets"]);
                booking.RequestDescription = String.IsNullOrEmpty(this.mmeRequestDescription.Text) ? null : Convert.ToString(this._currentBooking["RequestDescription"]);
                booking.ResponsedDescription = String.IsNullOrEmpty(this.mmeResponsedDescription.Text) ? null : Convert.ToString(this._currentBooking["ResponsedDescription"]);
                booking.Status = this.lkeStatus.EditValue == null ? null : Convert.ToString(this._currentBooking["Status"]);
                booking.TimeSlotID = this.lkeTimeSlot.EditValue == null ? (int?)null : Convert.ToInt32(this._currentBooking["TimeSlotID"]);
                booking.Units = Convert.IsDBNull(this._currentBooking["Units"]) ? (int?)null : Convert.ToInt32(this._currentBooking["Units"]);
                booking.VehicleNumber = String.IsNullOrEmpty(this.txtVehicleNumber.Text) ? null : Convert.ToString(this._currentBooking["VehicleNumber"]);
                booking.VehicleType = this.lkeVehicleType.EditValue == null ? null : Convert.ToString(this._currentBooking["VehicleType"]);
                booking.WarehouseID = this.lkeStore.EditValue == null ? (byte?)null : Convert.ToByte(this._currentBooking["WarehouseID"]);
                booking.Weights = Convert.IsDBNull(this._currentBooking["Weights"]) ? (decimal?)null : Convert.ToDecimal(this._currentBooking["Weights"]);

                int result = this._bookingDA.Update(booking);
                if (result == -2)
                {
                    XtraMessageBox.Show("Error");
                }
                this._isModified = false;
            }
            this.Close();
        }
        #endregion

        #region Load Data
        public void LoadBookings()
        {
            if (_isBookingBlast == 1)
            {
                this._tbBookings = FileProcess.LoadTable("SELECT CustomerBookings.*, Customers.CustomerNumber, Customers.CustomerName, CustomerBookingTimeSlots.TimeSlot " +
                     "FROM(CustomerBookings INNER JOIN Customers ON CustomerBookings.CustomerID = Customers.CustomerID) INNER JOIN CustomerBookingTimeSlots ON CustomerBookings.TimeSlotID = CustomerBookingTimeSlots.TimeSlotID " +
                     "WHERE(((CustomerBookings.IsDeleted) = 0) and (CustomerBookings.IsBlastFreezer = 1) and (CustomerBookings.BlastFreezerID is null)) " +
                     "ORDER BY CustomerBookings.CreatedTime; ");
            }
            else if (String.IsNullOrEmpty(this._bookingNumber))
            {
                this._tbBookings = FileProcess.LoadTable("SELECT CustomerBookings.*, Customers.CustomerNumber, Customers.CustomerName, CustomerBookingTimeSlots.TimeSlot " +
                     "FROM(CustomerBookings INNER JOIN Customers ON CustomerBookings.CustomerID = Customers.CustomerID) INNER JOIN CustomerBookingTimeSlots ON CustomerBookings.TimeSlotID = CustomerBookingTimeSlots.TimeSlotID " +
                     "WHERE(((CustomerBookings.IsDeleted) = 0)) " +
                     "ORDER BY CustomerBookings.CreatedTime; ");
            }
            else
            {
                this._tbBookings = FileProcess.LoadTable("SELECT CustomerBookings.*, Customers.CustomerNumber, Customers.CustomerName, CustomerBookingTimeSlots.TimeSlot " +
                    "FROM(CustomerBookings INNER JOIN Customers ON CustomerBookings.CustomerID = Customers.CustomerID) INNER JOIN CustomerBookingTimeSlots ON CustomerBookings.TimeSlotID = CustomerBookingTimeSlots.TimeSlotID " +
                    "WHERE(((CustomerBookings.IsDeleted) = 0)) AND CustomerBookings.BookingNumber = '" + this._bookingNumber + "' " +
                    "ORDER BY CustomerBookings.CreatedTime; ");
            }
            //if (!this._isAddNew)
            //{
            //    var newRow= this._tbBookings.NewRow();
            //    newRow["BookingID"] =Guid.NewGuid();
            //    newRow["CustomerID"] = 0;
            //    newRow["CreatedTime"] = DateTime.Now;
            //    newRow["TimeSlot"] = 0;
            //    this._tbBookings.Rows.Add(newRow);
            //    this.nvtBookings.DataSource = this._tbBookings;
            //    this.nvtBookings.Position = this._tbBookings.Rows.Count - 1;
            //    this._currentBooking = this._tbBookings.Rows[this._tbBookings.Rows.Count - 1];
            //    BindData();
            //}
            //else
            //{
            //   this._tbBookings.Rows.Clear();
            //}
            this.nvtBookings.DataSource = this._tbBookings;
            this.nvtBookings.Position = this._tbBookings.Rows.Count - 1;
            if(this._currentBooking == null)
            {
                this.Btn_WM_NewCustomer_Click(new object(), new EventArgs());
            }
        }

        private void BindData()
        {
            this.txtBookingNumber.Text = Convert.ToString(this._currentBooking["BookingNumber"]);
            this.txtCreatedBy.Text = Convert.IsDBNull(this._currentBooking["CreatedBy"]) ? String.Empty : Convert.ToString(this._currentBooking["CreatedBy"]);
            this.txtCreatedTime.Text = Convert.ToString(this._currentBooking["CreatedTime"]);
            this.txtCustomerName.Text = Convert.ToString(this._currentBooking["CustomerName"]);
            this.txtOrderNumber.Text = Convert.IsDBNull(this._currentBooking["OrderNumber"]) ? String.Empty : Convert.ToString(this._currentBooking["OrderNumber"]);
            this.txtPallets.Text = Convert.IsDBNull(this._currentBooking["Pallets"]) ? String.Empty : Convert.ToString(this._currentBooking["Pallets"]);
            this.txtUnit.Text = Convert.IsDBNull(this._currentBooking["Units"]) ? String.Empty : Convert.ToString(this._currentBooking["Units"]);
            this.txtVehicleNumber.Text = Convert.IsDBNull(this._currentBooking["VehicleNumber"]) ? String.Empty : Convert.ToString(this._currentBooking["VehicleNumber"]);
            this.txtWeight.Text = Convert.IsDBNull(this._currentBooking["Weights"]) ? String.Empty : Convert.ToString(this._currentBooking["Weights"]);
            this.txtCartons.Text = Convert.IsDBNull(this._currentBooking["Cartons"]) ? String.Empty : Convert.ToString(this._currentBooking["Cartons"]);
            this.mmeRequestDescription.Text = Convert.IsDBNull(this._currentBooking["RequestDescription"]) ? String.Empty : Convert.ToString(this._currentBooking["RequestDescription"]);
            this.mmeResponsedDescription.Text = Convert.IsDBNull(this._currentBooking["ResponsedDescription"]) ? String.Empty : Convert.ToString(this._currentBooking["ResponsedDescription"]);
            if (!Convert.IsDBNull(this._currentBooking["BookingDate"]))
            {
                this.dtBookingDate.EditValue = Convert.ToDateTime(this._currentBooking["BookingDate"]);
            }
            else
            {
                this.dtBookingDate.EditValue = null;
            }

            this.lkeCustomers.EditValue = Convert.ToInt32(this._currentBooking["CustomerID"]);
            this.lkeOrderType.EditValue = Convert.IsDBNull(this._currentBooking["OrderType"]) ? String.Empty : Convert.ToString(this._currentBooking["OrderType"]);
            this.lkeStatus.EditValue = Convert.IsDBNull(this._currentBooking["Status"]) ? null : Convert.ToString(this._currentBooking["Status"]);
            this.lkeStore.EditValue = Convert.IsDBNull(this._currentBooking["WarehouseID"]) ? (int?)null : Convert.ToInt32(this._currentBooking["WarehouseID"]);
            this.lkeTimeSlot.EditValue = Convert.IsDBNull(this._currentBooking["TimeSlotID"]) ? (int?)null : Convert.ToInt32(this._currentBooking["TimeSlotID"]);
            this.lkeVehicleType.EditValue = Convert.ToString(this._currentBooking["VehicleType"]);
            this._isModified = false;

            var BookingID = Guid.Parse(this._currentBooking["BookingID"].ToString());
            var detailOld = this.CustomerBookingDetailsDA.Select(x => x.CustomerBookingID == BookingID);
            if (detailOld != null)
            {
                this.grdDetails.DataSource = detailOld;
            }
        }

        private void InitWarehouse()
        {
            this.lkeStore.Properties.DataSource = FileProcess.LoadTable("Select * From Warehouses");
            this.lkeStore.Properties.ValueMember = "WarehouseID";
            this.lkeStore.Properties.DisplayMember = "WarehouseDescription";
        }

        private void InitTimeSlot()
        {
            this.lkeTimeSlot.Properties.DataSource = FileProcess.LoadTable("Select * From CustomerBookingTimeSlots");
            this.lkeTimeSlot.Properties.ValueMember = "TimeSlotID";
            this.lkeTimeSlot.Properties.DisplayMember = "TimeSlot";
        }

        private void InitOrderType()
        {
            var source = new DataTable();

            source.Columns.Add(new DataColumn("Order", typeof(string)));

            DataRow row1 = source.NewRow();
            row1["Order"] = "Receiving";

            DataRow row2 = source.NewRow();
            row2["Order"] = "Dispatching";

            DataRow row3 = source.NewRow();
            row3["Order"] = "Cross Dock";

            DataRow row4 = source.NewRow();
            row4["Order"] = "Document";

            DataRow row5 = source.NewRow();
            row4["Order"] = "Animal Control";

            DataRow row6 = source.NewRow();
            row4["Order"] = "Stock Take";

            DataRow row7 = source.NewRow();
            row4["Order"] = "Product Checking";




            source.Rows.Add(row1);
            source.Rows.Add(row2);
            source.Rows.Add(row3);
            source.Rows.Add(row4);
            source.Rows.Add(row5);
            source.Rows.Add(row6);
            source.Rows.Add(row7);
            this.lkeOrderType.Properties.DataSource = source;
            this.lkeOrderType.Properties.ValueMember = "Order";
            this.lkeOrderType.Properties.DisplayMember = "Order";
        }

        private void InitVehicleTypes()
        {
            var source = new DataTable();

            source.Columns.Add(new DataColumn("Type", typeof(string)));

            DataRow row1 = source.NewRow();
            row1["Type"] = "Cont 20";

            DataRow row2 = source.NewRow();
            row2["Type"] = "Cont 40";

            DataRow row3 = source.NewRow();
            row3["Type"] = "Xe";

            source.Rows.Add(row1);
            source.Rows.Add(row2);
            source.Rows.Add(row3);

            this.lkeVehicleType.Properties.DataSource = source;
            this.lkeVehicleType.Properties.ValueMember = "Type";
            this.lkeVehicleType.Properties.DisplayMember = "Type";
        }

        private void InitStatus()
        {
            var source = new DataTable();

            source.Columns.Add(new DataColumn("Status", typeof(string)));

            DataRow row1 = source.NewRow();
            row1["Status"] = "Processing";

            DataRow row2 = source.NewRow();
            row2["Status"] = "Accepted";

            DataRow row3 = source.NewRow();
            row3["Status"] = "Denied";

            DataRow row4 = source.NewRow();
            row4["Status"] = "Finished";

            source.Rows.Add(row1);
            source.Rows.Add(row2);
            source.Rows.Add(row3);
            source.Rows.Add(row4);

            this.lkeStatus.Properties.DataSource = source;
            this.lkeStatus.Properties.ValueMember = "Status";
            this.lkeStatus.Properties.DisplayMember = "Status";
        }

        private void InitCustomers()
        {
            this.lkeCustomers.Properties.DataSource = AppSetting.CustomerList;
            this.lkeCustomers.Properties.ValueMember = "CustomerID";
            this.lkeCustomers.Properties.DisplayMember = "CustomerNumber";
        }
        #endregion

        private void frm_WM_CustomerBookingEntry_Shown(object sender, EventArgs e)
        {
            if (this._isAddNew)
            {
                this.IsAddNew = true;
                this._currentBooking = this._tbBookings.NewRow();
                this._currentBooking["BookingID"] = Guid.NewGuid();
                this._currentBooking["CreatedBy"] = AppSetting.CurrentUser.LoginName;
                this._currentBooking["Status"] = "Processing";
                this._currentBooking["WarehouseID"] = 1;
                this._currentBooking["CustomerID"] = 0;
                this._currentBooking["TimeSlotID"] = 0;
                this._currentBooking["TimeSlot"] = "0";
                this._currentBooking["CreatedTime"] = DateTime.Now;
                this._tbBookings.Rows.Add(this._currentBooking);

                this.nvtBookings.DataSource = this._tbBookings;
                this.nvtBookings.Position = this._tbBookings.Rows.Count;
                this._currentBooking = this._tbBookings.Rows[this.nvtBookings.Position];
                BindData();
                this.lkeCustomers.Focus();
                //this.lkeCustomers.ShowPopup();
            }
        }

        private void Btn_WM_NewCustomer_Click(object sender, EventArgs e)
        {

            this.IsAddNew = true;
            this._currentBooking = this._tbBookings.NewRow();
            this._currentBooking["BookingID"] = Guid.NewGuid();
            this._currentBooking["CreatedBy"] = AppSetting.CurrentUser.LoginName;
            this._currentBooking["Status"] = "Processing";
            this._currentBooking["WarehouseID"] = 1;
            this._currentBooking["CustomerID"] = 0;
            this._currentBooking["TimeSlotID"] = 0;
            this._currentBooking["TimeSlot"] = "0";
            this._currentBooking["CreatedTime"] = DateTime.Now;
            this._currentBooking["ts"] = new Byte[0];
            this._tbBookings.Rows.Add(this._currentBooking);
            this.nvtBookings.DataSource = this._tbBookings;
            this.nvtBookings.Position = this._tbBookings.Rows.Count;
            this._currentBooking = this._tbBookings.Rows[this.nvtBookings.Position];
            BindData();
            this.dtBookingDate.EditValue = DateTime.Now;
            this.lkeCustomers.Focus();
            this.lkeCustomers.ShowPopup();
        }

        private void btnPlanningSummary_Click(object sender, EventArgs e)
        {
            frm_WR_OperationPlanning frm = new frm_WR_OperationPlanning();
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
        }

        private void btn_ProcessBlast_Click(object sender, EventArgs e)
        {
            BlastFreezers newBlastFreezers = new BlastFreezers()
            {
                BlastFreezerID = 0,
                DateIn = DateTime.Now,
                CustomerID = Convert.ToInt32(lkeCustomers.GetColumnValue("CustomerID")),
                CustomerName = txtCustomerName.EditValue.ToString(),
                BlastFreezerRoomID = 1,
                UserName = AppSetting.CurrentUser.LoginName,
                BlastFreezerConfirm = false
            };
            DataProcess<BlastFreezers> blastFreezersDA = new DataProcess<BlastFreezers>();
            int resultInsert = blastFreezersDA.Insert(newBlastFreezers);
            if (resultInsert > 0)
            {
                int blastID = blastFreezersDA.Select().LastOrDefault().BlastFreezerID;
                string BookingNumber = txtBookingNumber.Text.ToString();
                int result = blastFreezersDA.ExecuteNoQuery("Update CustomerBookings set BlastFreezerID={0} where BookingNumber={1}", blastID, BookingNumber);

                if (result < 0)
                {
                    MessageBox.Show("Can't Update BlastFrezer In Booking");
                }
                else
                {
                    MessageBox.Show("BlastFreezer Was New");
                    LoadBookings();
                }
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            int customerIDSelected = Convert.ToInt32(this.lkeCustomers.EditValue);
            Guid bookingID = (Guid)this._currentBooking["BookingID"];
            if(bookingID != null)
            {
                UI.WarehouseManagement.frm_WM_CustomerBookingImportFiles frm = new frm_WM_CustomerBookingImportFiles(customerIDSelected, bookingID);
                if (!frm.Enabled) return;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowInTaskbar = false;
                frm.ShowDialog();
                BindData();
            }
        }

        DataTable GetTableExcelSheetNames(string excelFile)
        {
            OleDbConnection objConn = null;
            System.Data.DataTable dt = null;
            try
            {
                string connString = "";
                string extensionFile = Path.GetExtension(excelFile);
                switch (extensionFile)
                {
                    case ".xls":
                        connString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + excelFile + ";Extended Properties=Excel 8.0;";
                        break;
                    case ".xlsx":
                        connString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={excelFile};Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=2\"";
                        break;
                    default:
                        connString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + excelFile + ";Extended Properties=Excel 8.0;";
                        break;
                }
                objConn = new OleDbConnection(connString);
                objConn.Open();
                dt = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                if (dt == null)
                {
                    return null;
                }

                DataTable v_Dt = new DataTable();
                v_Dt.Columns.Add("Name", typeof(string));

                foreach (DataRow i_Row in dt.Rows)
                {
                    DataRow v_Row = v_Dt.NewRow();
                    v_Row["Name"] = i_Row["TABLE_NAME"];

                    v_Dt.Rows.Add(v_Row);
                }

                return v_Dt;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                if (objConn != null)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
                if (dt != null)
                {
                    dt.Dispose();
                }
            }
        }

        private DataTable ReadExcelFile(string sheetName, string path, Int32 numRow = 30)
        {

            using (OleDbConnection conn = new OleDbConnection())
            {
                DataTable dt = new DataTable();
                string Import_FileName = path;
                string fileExtension = Path.GetExtension(Import_FileName);
                if (fileExtension == ".xls")
                    conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Import_FileName + ";" + "Extended Properties='Excel 8.0;HDR=YES;'";
                if (fileExtension == ".xlsx")
                    conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Import_FileName + ";" + "Extended Properties='Excel 12.0 Xml;HDR=YES;'";
                using (OleDbCommand comm = new OleDbCommand())
                {
                    comm.CommandText = numRow == 0 ? String.Format("Select * from [{0}]", sheetName) : String.Format("Select top {0} * from [{1}]", numRow, sheetName);
                    comm.Connection = conn;
                    using (OleDbDataAdapter da = new OleDbDataAdapter())
                    {
                        da.SelectCommand = comm;
                        da.Fill(dt);
                        return dt;
                    }

                }
            }
        }

        public List<CustomerBookingDetails> ConvertExcelToListProduct(DataTable dtInput)
        {
            List<CustomerBookingDetails> objectList = new List<CustomerBookingDetails>();

            foreach (DataRow dr in dtInput.Rows)
            {
                string ProductNumber = dr[1].ToString();

                CustomerBookingDetails newObj = new CustomerBookingDetails();
                var checkProduct = pData.Select().FirstOrDefault(n => n.ProductNumber == ProductNumber && n.CustomerID == Convert.ToInt32(this.lkeCustomers.EditValue));
                newObj.ProductID = checkProduct == null ? 0 : checkProduct.ProductID;
                if (checkProduct == null)
                {
                    newObj.Remarks = "Sản phẩm không tồn tại";
                }
                newObj.LotNo = dr[2].ToString();
                newObj.Weights = Convert.ToInt32(dr[3].ToString());
                newObj.Pallet = Convert.ToInt32(dr[4].ToString());
                newObj.Cartons = Convert.ToInt32(dr[5].ToString());
                newObj.CustomerBookingID = (Guid)this._currentBooking["BookingID"];
                newObj.CreatedBy = this.txtCreatedBy.Text;
                newObj.CreatedTime = DateTime.Now;
                objectList.Add(newObj);
            }
            return objectList;
        }

        private void grvDetail_DataSourceChanged(object sender, EventArgs e)
        {
            var lstobj = (List<CustomerBookingDetails>)this.grdDetails.DataSource;
            if (lstobj == null || lstobj.Count == 0) return;
            decimal? Weights = 0;
            decimal? Pallet = 0;
            int? Cartons = 0;
            foreach (var dr in lstobj)
            {
                var productSelected = this.pData.Select(x => x.ProductID == dr.ProductID).FirstOrDefault();
                if (productSelected == null)
                {
                    return;
                }
                dr.ProductName = productSelected.ProductName;
                dr.ProductNumber = productSelected.ProductNumber;
                Weights += dr.Weights == null ? 0 : dr.Weights;
                Pallet += dr.Pallet == null ? 0 : dr.Pallet;
                Cartons += dr.Cartons == null ? 0 : dr.Cartons;
            }
            txtWeight.Text = Weights.ToString();
            txtPallets.Text = Pallet.ToString();
            txtCartons.Text = Cartons.ToString();
        }

        private void grvDetail_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.RowHandle < 0) return;
            if (this.lkeOrderType.EditValue == null) return;
            if (!this.lkeOrderType.EditValue.Equals("Receiving") && !this.lkeOrderType.EditValue.Equals("Dispatching")) return;
            Guid bookingID = (Guid)this._currentBooking["BookingID"];
            int BookingDetailID = Convert.ToInt32(this.grvDetail.GetFocusedRowCellValue("CustomerBookingDetailsID"));
            bool bookingTypeID = true;
            switch (this.lkeOrderType.EditValue)
            {
                case "Receiving": bookingTypeID = true; break;
                case "Dispatching": bookingTypeID = false; break;
                default:
                    break;
            }
        }

        private void grvDetail_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle < 0) return;
            switch (e.Column.FieldName)
            {
                case "ProductNumber":
                    string productNumber = Convert.ToString(e.CellValue);
                    if (string.IsNullOrEmpty(productNumber)) e.Appearance.BackColor = Color.Red;
                    break;
                default:
                    break;
            }
        }

        private void UpdateReceivingProduct(int roID)
        {
            DataProcess<ReceivingOrderDetails> receivingOrderDetailDA = new DataProcess<ReceivingOrderDetails>();
            DataProcess<ReceivingOrders> receivingOrderDA = new DataProcess<ReceivingOrders>();
            var currentRO = receivingOrderDA.Select(r => r.ReceivingOrderID == roID).FirstOrDefault();
            currentRO.SpecialRequirement = this.txtBookingNumber.Text;
            receivingOrderDA.Update(currentRO);
            ReceivingOrderDetails receivingItem = null;
            for (int index = 0; index < this.grvDetail.RowCount; index++)
            {
                var proBooking = (CustomerBookingDetails)this.grvDetail.GetRow(index);
                if (proBooking == null || proBooking.ProductID <= 0) continue;
                int proID=Convert.ToInt32(proBooking.ProductID);
                var pro = AppSetting.ProductList.Where(p => p.ProductID == proID).FirstOrDefault();
                var daLocationBooking = new DataProcess<CustomerLocationBooking>();
                var locationBookingList = daLocationBooking.Select(l => l.CustomerBookingDetailsID == proBooking.CustomerBookingDetailsID).ToList();
                if (locationBookingList == null || locationBookingList.Count < 0) continue;
                int totalPalletBooking =Convert.ToInt32( locationBookingList.Sum(l => l.LocationQty));

                receivingItem = new ReceivingOrderDetails();
                receivingItem.ProductID = pro.ProductID;
                receivingItem.ProductNumber = pro.ProductNumber;
                receivingItem.ProductName = pro.ProductName;
                receivingItem.PackagesPerPallet = (short)pro.PackagesPerPallet;
                receivingItem.WeightPerPackage = (float)pro.WeightPerPackage;
                receivingItem.CustomerRef = this.txtOrderNumber.Text;
                receivingItem.TotalPackages = 0;
                receivingItem.UnitPerPackage = pro.Inners;
                receivingItem.TotalPackages =(short)(totalPalletBooking * pro.PackagesPerPallet);
                receivingItem.TotalUnits = receivingItem.TotalPackages * receivingItem.UnitPerPackage;
                receivingItem.TotalWeight = (decimal)(receivingItem.TotalPackages * receivingItem.WeightPerPackage);
                receivingItem.UserName = AppSetting.CurrentUser.LoginName;

                // Insert into Db
                receivingItem.CreatedBy = AppSetting.CurrentUser.LoginName;
                receivingItem.CreatedTime = DateTime.Now;
                receivingItem.ReceivingOrderID = roID;
                receivingItem.ReceivingOrderNumber = "RO-" + roID;
                receivingItem.ProductNumber = AppSetting.ProductList.Where(p => p.ProductID == receivingItem.ProductID).FirstOrDefault().ProductNumber;
                receivingItem.Status = 0;

                // Insert into Db
                int result = receivingOrderDetailDA.ExecuteNoQuery("STReceivingOrderDetailInsert " +
                   " @ReceivingOrderID ={0}," +
                   " @ReceivingOrderNumber={1}," +
                   " @ProductNumber={2}," +
                   " @ProductName={3}," +
                   " @ProductID={4}," +
                   " @PackagePerPallet={5}," +
                   " @Quantity={6}," +
                   " @WeightPerPackage={7}," +
                   " @CustomerRef={8}," +
                   " @CurrentUser={9}," +
                   " @ToPickingLocation={10}," +
                   " @ProductionDate={11}," +
                   " @UseByDate={12}," +
                   " @varRemark={13}," +
                   " @varPackages={14}," +
                   " @varPcs={15}", roID, receivingItem.ReceivingOrderNumber, receivingItem.ProductNumber, receivingItem.ProductName, receivingItem.ProductID,
                   receivingItem.PackagesPerPallet, receivingItem.TotalPackages, receivingItem.WeightPerPackage, receivingItem.CustomerRef, AppSetting.CurrentUser.LoginName,
                   0, receivingItem.ProductionDate, receivingItem.UseByDate, receivingItem.Remark, receivingItem.Packages, receivingItem.Pcs);
                AllLocateLocationRO(roID, locationBookingList);
            }

        }
        private void AllLocateLocationRO(int roID, IList<CustomerLocationBooking> listLocationBook)
        {
            DataProcess<ReceivingOrderDetails> roDetailDA = new DataProcess<ReceivingOrderDetails>();
            DataProcess<CustomerBookingDetails> dataProcess = new DataProcess<CustomerBookingDetails>();
            var roDetailInfo = roDetailDA.Select(r => r.ReceivingOrderID == roID).OrderByDescending(r=>r.ReceivingOrderDetailID).FirstOrDefault();
            if (roDetailInfo == null) return;
                dataProcess.ExecuteNoQuery("STPalletsAllocation @varReceivingOrderDetailID={0}, @varLowHigh={1}, @varFirstTop={2}, @varCondition={3}, @varJoinSmallPallet={4}",
                    roDetailInfo.ReceivingOrderDetailID, 3, 3, "(" + CalculateAisle(listLocationBook) + ")", true);
        }

        private string CalculateAisle(IList<CustomerLocationBooking> listLocationBook)
        {
            DataProcess<Aisles> aisleDA = new DataProcess<Aisles>();
            string room1ID = "";
            string room2ID = "";
            if(listLocationBook.Count>0 && listLocationBook[0].LocationQty>0)room1ID= Convert.ToString(listLocationBook[0].RoomID);
            if (listLocationBook.Count > 1 && listLocationBook[1].LocationQty > 0) room2ID = Convert.ToString(listLocationBook[1].RoomID);
            var arrayAisle = aisleDA.Select(a => (a.RoomID.Equals(room1ID) || a.RoomID.Equals(room2ID)) && a.StoreID == AppSetting.StoreID).ToList();
            string stRoomID = "";
            foreach (var item in arrayAisle)
            {
                stRoomID += item.Aisle.ToString() + ",";
            }
            if (stRoomID != "")
                return stRoomID.Substring(0, stRoomID.Length - 1);
            else
                return null;
        }

        private void rpi_btn_Del_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (this.grvDetail.FocusedRowHandle < 0) return;
            var proBooking = (CustomerBookingDetails)this.grvDetail.GetRow(this.grvDetail.FocusedRowHandle);
            DataProcess<CustomerBookingDetails> dataProcess = new DataProcess<CustomerBookingDetails>();
            dataProcess.Delete(proBooking);
            this.grvDetail.DeleteRow(this.grvDetail.FocusedRowHandle);

        }
    }
}
