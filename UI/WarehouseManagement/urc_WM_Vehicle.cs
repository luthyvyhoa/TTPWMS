using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DA;
using UI.Helper;
using DevExpress.XtraEditors;
using Common.Process;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout.Utils;

namespace UI.WarehouseManagement
{
    public partial class urc_WM_Vehicle : UserControl
    {
        private int _customerID;
        private string _customerName;
        private string _orderNumber;
        private string _reason;
        private string _sealNumber;
        private string _dockNumber;
        private string _vehicleNumber;
        private string qty = "Xe Khong";
        private bool isLoadVehicleToday = false;
        private BindingList<STGate_VehicleBound_Result> _listVehicle;

        /// <summary>
        /// Allow ElectricComsumption panel is dislay on  on form
        /// </summary>
        /// <param name="isDisplay">bool</param>
        public void DisplayFullPanel(bool isDisplay)
        {
            LayoutVisibility hasDisplayValue = LayoutVisibility.Always;
            if (!isDisplay) hasDisplayValue = LayoutVisibility.Never;
            this.layoutControlItem1.Visibility = hasDisplayValue;
        }

        public urc_WM_Vehicle(int customerID, string customerName, string vehicleNumber, string orderNumber, string reason, string sealNumber, string dockNumber, string qty = "Xe Khong")
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this._customerID = customerID;
            this._customerName = customerName;
            this._vehicleNumber = vehicleNumber.Trim().ToUpper();
            this._orderNumber = orderNumber;
            this._reason = reason;
            this._sealNumber = sealNumber;
            this._dockNumber = dockNumber;
            this.qty = qty;
            CheckUserAuthorization();
            InitTruckNumber();
            SetEvents();
        }

        public void InitData(string orderNumber, string qty = "Xe Khong")
        {
            this._orderNumber = orderNumber;
            this.qty = qty;
            this.InitTruckNumber();
            this.LoadVehicleData();
            this.LoadEC();
            this.SetVehicleReadOnly(true);
        }
        private void urc_WM_Vehicle_Load(object sender, EventArgs e)
        {
            try
            {
                this.InitData(this._orderNumber, this.qty);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void SetEvents()
        {
            this.rpi_lke_Vehicle.CloseUp += Rpi_lke_Vehicle_CloseUp;
            this.grvVehicleManagement.FocusedRowChanged += grvVehicleManagement_FocusedRowChanged;
            this.grvVehicleManagement.KeyDown += grvVehicleManagement_KeyDown;
            this.grvVehicleManagement.ValidateRow += grvVehicleManagement_ValidateRow;
            this.grvVehicleManagement.CellValueChanged += grvVehicleManagement_CellValueChanged;
            this.grvVehicleManagement.ShownEditor += GrvVehicleManagement_ShownEditor;
            this.grvVehicleManagement.RowCellClick += GrvVehicleManagement_RowCellClick;
        }

        private void Rpi_lke_Vehicle_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.Value == null || String.IsNullOrEmpty(Convert.ToString(e.Value))) return;
            DevExpress.XtraEditors.LookUpEdit vehicleLookupEditor = (sender as DevExpress.XtraEditors.LookUpEdit);
            vehicleLookupEditor.EditValue = e.Value;

            // Load all vehicle in-out to day
            string allForToday = Convert.ToString(e.Value);
            if (allForToday.Trim().ToLower().Contains("all for today"))
            {
                this.rpi_lke_Vehicle.DataSource = FileProcess.LoadTable("STGate_VehicleInOutToday @varStoreID=" + AppSetting.StoreID);
                this.rpi_lke_Vehicle.ValueMember = "VehicleNumber";
                this.rpi_lke_Vehicle.DisplayMember = "VehicleNumber";
                this.isLoadVehicleToday = true;
                return;
            }

            if (!HasInputTime())
            {
                XtraMessageBox.Show("Start and end time is not correct !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(_vehicleNumber))
            {
                XtraMessageBox.Show("The truck / container is not correct !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (vehicleLookupEditor.EditValue == null) return;
            DataRowView row = vehicleLookupEditor.Properties.GetDataSourceRowByDisplayValue(vehicleLookupEditor.EditValue) as DataRowView;
            string vehicleNumber = Convert.ToString(row.Row["VehicleNumber"]).Trim().ToUpper();
            string vehicleType = Convert.ToString(row.Row["VehicleType"]);
            DateTime timeIn = Convert.ToDateTime(row.Row["TimeIn"]);
            int gate = Convert.ToInt32(row.Row["Gate"]);
            int vehicleID = Convert.ToInt32(row.Row["VehicleInOutID"]);

            if (_vehicleNumber.Length < 5)
            {
                XtraMessageBox.Show("The truck / container is not correct !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.grvVehicleManagement.SetFocusedRowCellValue("VehicleNumber", null);
                return;
            }

            if (_vehicleNumber.Substring(0, 5).Equals("BAGAC", StringComparison.OrdinalIgnoreCase))
            {
                if (!_vehicleNumber.Substring(0, 5).Equals(vehicleNumber.Substring(0, 5), StringComparison.OrdinalIgnoreCase))
                {
                    XtraMessageBox.Show("The truck / container is not correct !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.grvVehicleManagement.SetFocusedRowCellValue("VehicleNumber", null);
                    return;
                }
            }
            else
            {
                if (_vehicleNumber.Length < 7 || !_vehicleNumber.Substring(0, 7).Equals(vehicleNumber.Substring(0, 7), StringComparison.OrdinalIgnoreCase))
                {
                    XtraMessageBox.Show("The truck / container is not correct !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.grvVehicleManagement.SetFocusedRowCellValue("VehicleNumber", null);
                    return;
                }
            }

            DateTime startTime = Convert.ToDateTime(this.grvVehicleManagement.GetRowCellValue(this.grvVehicleManagement.FocusedRowHandle, "StartTime"));

            // Set value on grid view
            this.grvVehicleManagement.SetFocusedRowCellValue("VehicleNumber", vehicleNumber);
            this.grvVehicleManagement.SetFocusedRowCellValue("VehicleType", vehicleType);
            this.grvVehicleManagement.SetFocusedRowCellValue("TimeIn", timeIn);
            this.grvVehicleManagement.SetFocusedRowCellValue("TimeOut", startTime);
            this.grvVehicleManagement.SetFocusedRowCellValue("Gate", gate);
            this.grvVehicleManagement.SetFocusedRowCellValue("VehicleInOutID", vehicleID);
            this.grvVehicleManagement.SetFocusedRowCellValue("ProductQty", this.qty);
            this.grvVehicleManagement.FocusedColumn = this.grcQuantity;
            if (this.isLoadVehicleToday)
            {
                this.InitTruckNumber();
            }
        }

        private void GrvVehicleManagement_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (!e.Column.FieldName.Equals("VehicleNumber")) return;
            int vehicleID = Convert.ToInt32(this.grvVehicleManagement.GetRowCellValue(this.grvVehicleManagement.FocusedRowHandle, "VehicleInOutID"));
            if (vehicleID > 0) return;
            this.grcPallet.OptionsColumn.AllowFocus = true;
            grvVehicleManagement.FocusedColumn = this.grcPallet;
            grvVehicleManagement.ShowEditor();
        }

        private void GrvVehicleManagement_ShownEditor(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            if (view.ActiveEditor is LookUpEdit)
            {
                ((LookUpEdit)view.ActiveEditor).ShowPopup();
            }
        }

        private void grvVehicleManagement_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            switch (e.Column.FieldName)
            {
                case "ProductQty":
                    string productQty = Convert.ToString(this.grvVehicleManagement.GetFocusedRowCellValue("ProductQty"));
                    string vehicleType = Convert.ToString(this.grvVehicleManagement.GetFocusedRowCellValue("VehicleType"));
                    int vehicleID = Convert.ToInt32(this.grvVehicleManagement.GetFocusedRowCellValue("VehicleInOutID"));
                    if (!String.IsNullOrEmpty(productQty))
                    {
                        DataProcess<object> vehicleDA = new DataProcess<object>();

                        if (!this.grvVehicleManagement.IsNewItemRow(this.grvVehicleManagement.RowCount - 1))
                        {
                            // Insert data into DB
                            int rowIndex = this.grvVehicleManagement.FocusedRowHandle;
                            int vehicleInOutId = Convert.ToInt32(this.grvVehicleManagement.GetRowCellValue(rowIndex, "VehicleInOutID"));
                            string qtyOut = Convert.ToString(this.grvVehicleManagement.GetRowCellValue(rowIndex, "ProductQty"));
                            string userCheckOut = AppSetting.CurrentUser.LoginName + " - " + DateTime.Now.ToString("dd/MM/yyyy hh:mm");
                            DateTime timeIn = Convert.ToDateTime(this.grvVehicleManagement.GetRowCellValue(rowIndex, "TimeIn"));
                            DateTime startTime = Convert.ToDateTime(this.grvVehicleManagement.GetRowCellValue(rowIndex, "StartTime"));
                            DateTime endTime = Convert.ToDateTime(this.grvVehicleManagement.GetRowCellValue(rowIndex, "EndTime"));

                            vehicleDA.ExecuteNoQuery("STGate_VehicleInOutUpdateAll @VehicleType ={0}, @OrderNumber ={1}, @VehicleInOutID ={2}, @QuantityOut ={3}, @UserCheckOut ={4}, @CustomerID ={5}, @CustomerName ={6}, @StartTime ={7}, @EndTime ={8}, @Reason ={9}, @StartWorkingTime ={10}, @EndWorkingTime ={11}, @SealNumber ={12}, @DockNumber ={13}",
                                                                               vehicleType, this._orderNumber, vehicleInOutId, qtyOut, userCheckOut, this._customerID, this._customerName, timeIn.ToString("yyyy-MM-dd HH:mm"), endTime.ToString("yyyy-MM-dd HH:mm"),
                                                                               this._reason, startTime.ToString("yyyy-MM-dd HH:mm"), endTime.ToString("yyyy-MM-dd HH:mm"), this._sealNumber, this._dockNumber);

                            // Update start time, end time to DB
                            vehicleDA.ExecuteNoQuery("Update Gate_ContInOut SET StartTime = '" + startTime.ToString("yyyy-MM-dd HH:mm") + "',EndTime='" + endTime.ToString("yyyy-MM-dd HH:mm") + "' WHERE ContInOutID = " + vehicleID);

                            // reload data
                            this.LoadVehicleData();
                            this.grcTimeIn.OptionsColumn.ReadOnly = true;
                            this.grcTimeOut.OptionsColumn.ReadOnly = true;
                        }

                        if (vehicleType.Equals("Truck"))
                        {
                            int result = vehicleDA.ExecuteNoQuery("Update Gate_TruckInOut SET ProductQty = '" + productQty + "' WHERE TruckInOutID = " + vehicleID);
                        }
                        else
                        {
                            int result = vehicleDA.ExecuteNoQuery("Update Gate_ContInOut SET ProductQty = '" + productQty + "' WHERE ContInOutID = " + vehicleID);
                        }
                    }
                    break;

                case "Reason":
                    DataProcess<object> vehicleDA2 = new DataProcess<object>();
                    int vehicleID2 = Convert.ToInt32(this.grvVehicleManagement.GetFocusedRowCellValue("VehicleInOutID"));
                    string reason = Convert.ToString(this.grvVehicleManagement.GetFocusedRowCellValue("Reason"));
                    string vehicleType2 = Convert.ToString(this.grvVehicleManagement.GetFocusedRowCellValue("VehicleType"));
                    if (vehicleType2.Equals("Truck"))
                    {
                        int result = vehicleDA2.ExecuteNoQuery("Update Gate_TruckInOut SET TruckReason = N'" + reason + "' WHERE TruckInOutID = " + vehicleID2);
                    }
                    else
                    {
                        int result = vehicleDA2.ExecuteNoQuery("Update Gate_ContInOut SET Reason = N'" + reason + "' WHERE ContInOutID = " + vehicleID2);
                    }
                    break;
            }
        }

        private void grvVehicleManagement_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if (this.grvVehicleManagement.IsNewItemRow(e.RowHandle))
            {
                if (this.grvVehicleManagement.GetRowCellValue(e.RowHandle, "VehicleNumber") == null)
                {
                }
            }
        }

        private void grvVehicleManagement_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DataProcess<object> vehicleDA = new DataProcess<object>();
                string vehicleType = Convert.ToString(this.grvVehicleManagement.GetFocusedRowCellValue("VehicleType"));
                int vehicleID = Convert.ToInt32(this.grvVehicleManagement.GetFocusedRowCellValue("VehicleInOutID"));
                int result = -2;

                if (vehicleType.Equals("Truck"))
                {
                    result = vehicleDA.ExecuteNoQuery("UPDATE Gate_truckInOut SET ProductQty = '', OrderNumber = '', UserOut = 'Cancel', UserCheckOut = 0 WHERE Gate_TruckInOut.TruckInOutID = {0}", vehicleID);
                }
                else
                {
                    result = vehicleDA.ExecuteNoQuery("UPDATE Gate_ContInOut SET ProductQty = '', OrderNumber = '', UserOut = 'Cancel', UserCheckOut = 0, StartTime = NULL, ENDTime = NULL WHERE TimeOut is not Null AND Gate_ContInOut.ContInOutID = {0}", vehicleID);
                }

                LoadVehicleData();
            }
        }

        #region Events

        private bool HasInputTime()
        {
            if (string.IsNullOrEmpty(this._orderNumber)) return false;
            string query = string.Empty;
            // Detected current order
            switch (this._orderNumber.Substring(0, 2))
            {
                case "RO":
                    query = "Select top 1 StartTime,EndTime from ReceivingOrders where ReceivingOrderNumber = '" + this._orderNumber + "'";
                    break;
                case "DO":
                    query = "Select top 1 StartTime,EndTime from DispatchingOrders where DispatchingOrderNumber = '" + this._orderNumber + "'";
                    break;
                case "TW":
                    query = "Select top 1 StartWorkingTime,EndWorkingTime from Trips where TripNumber = '" + this._orderNumber + "'";
                    break;
            }

            var orderInfo = FileProcess.LoadTable(query);
            if (orderInfo == null || orderInfo.Rows.Count <= 0) return false;

            // has data
            var startTime = Convert.ToString(orderInfo.Rows[0][0]);
            var endTime = Convert.ToString(orderInfo.Rows[0][1]);
            if (string.IsNullOrEmpty(startTime) || string.IsNullOrEmpty(endTime)) return false;

            this.grvVehicleManagement.SetRowCellValue(this.grvVehicleManagement.FocusedRowHandle, "StartTime", startTime);
            this.grvVehicleManagement.SetRowCellValue(this.grvVehicleManagement.FocusedRowHandle, "EndTime", endTime);

            return true;
        }

        private void grvVehicleManagement_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            // Remove row empty
            var listEmptyRow = this._listVehicle.Where(v => v.VehicleNumber == null).ToList();
            if (listEmptyRow != null && listEmptyRow.Count() > 1)
            {
                foreach (var vehicelEmpty in listEmptyRow)
                {
                    this._listVehicle.Remove(vehicelEmpty);
                }
            }

            if (!this.grvVehicleManagement.IsNewItemRow(e.PrevFocusedRowHandle))
            {
                if (this.grvVehicleManagement.IsNewItemRow(e.FocusedRowHandle))
                {
                    SetVehicleReadOnly(false);
                }
                else
                {
                    int vehicleID = Convert.ToInt32(this.grvVehicleManagement.GetFocusedRowCellValue("VehicleInOutID"));
                    if (vehicleID <= 0) return;
                    SetVehicleReadOnly(true);
                }
            }
        }
        #endregion

        #region Load Data
        private void LoadVehicleData()
        {
            DataProcess<STGate_VehicleBound_Result> data = new DataProcess<STGate_VehicleBound_Result>();
            _listVehicle = new BindingList<STGate_VehicleBound_Result>(data.Executing("STGate_VehicleBound @OrderNumber = {0}", this._orderNumber).ToList());
            this.grdVehicleManagement.DataSource = _listVehicle;
        }

        private void LoadEC()
        {
            this.grdElectricComsumption.DataSource = FileProcess.LoadTable("STElectricityConsumption @OrderNumber ='" + this._orderNumber + "'");
            this.grdContainerCheckings.DataSource = FileProcess.LoadTable("STGate_ContainerCheckings @OrderNumber ='" + this._orderNumber + "'");
        }

        private void InitTruckNumber()
        {
            this.rpi_lke_Vehicle.DataSource = FileProcess.LoadTable("STGate_VehicleInoutRemainByGate @GateNo ="
                + AppSetting.CurrentUser.Gate + ",@varStoreID=" + AppSetting.StoreID);
            this.rpi_lke_Vehicle.ValueMember = "VehicleNumber";
            this.rpi_lke_Vehicle.DisplayMember = "VehicleNumber";
        }
        #endregion

        private void CheckUserAuthorization()
        {
            if (AppSetting.CurrentUser.Gate < 0)
            {
                this.grvVehicleManagement.OptionsBehavior.ReadOnly = true;
                this.grvElectricComsumption.OptionsBehavior.ReadOnly = true;
            }
        }

        private void SetVehicleReadOnly(bool isReadOnly)
        {
            this.grcVehicleID.OptionsColumn.ReadOnly = isReadOnly;
            this.grcVehicleNumber.OptionsColumn.ReadOnly = isReadOnly;
            this.grcVehicleOrder.OptionsColumn.ReadOnly = false;
            this.grcVehicleReason.OptionsColumn.ReadOnly = isReadOnly;
            this.grcVehicleType.OptionsColumn.ReadOnly = isReadOnly;
            this.grcVehicleUser.OptionsColumn.ReadOnly = isReadOnly;
            this.grcGate.OptionsColumn.ReadOnly = isReadOnly;
            this.grcTimeIn.OptionsColumn.ReadOnly = isReadOnly;
            this.grcTimeOut.OptionsColumn.ReadOnly = isReadOnly;
            this.grcTruckInOutNumber.OptionsColumn.ReadOnly = isReadOnly;
        }

        public void UpdateParam(int customerID, string customerName, string velhicleNumber, string sealNumber, string dockNumber)
        {
            this._customerID = customerID;
            this._customerName = customerName;
            this._vehicleNumber = velhicleNumber.Trim().ToUpper();
            this._sealNumber = sealNumber;
            this._dockNumber = dockNumber;
        }

        private void grvVehicleManagement_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void grvVehicleManagement_ShownEditor(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            if (view.ActiveEditor is LookUpEdit)
            {
                ((LookUpEdit)view.ActiveEditor).ShowPopup();
            }
        }

        private void rpi_lke_Vehicle_PopupFilter(object sender, DevExpress.XtraEditors.Controls.PopupFilterEventArgs e)
        {
            if (this._vehicleNumber.Length < 3) return;
            //e.Criteria = DevExpress.Data.Filtering.CriteriaOperator.Parse("VehicleNumber  like '%" + this._vehicleNumber.Substring(2) + "%'");
        }
    }
}
