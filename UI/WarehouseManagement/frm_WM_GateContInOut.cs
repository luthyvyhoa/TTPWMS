using Common.Controls;
using DA;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Helper;
using UI.Management;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_GateContInOut : frmBaseForm
    {
        private DataProcess<STGate_ContInOutRemain_Result> gateContInOutRemainDataProcess = new DataProcess<STGate_ContInOutRemain_Result>();
        public frm_WM_GateContInOut()
        {
            InitializeComponent();

            initData();
        }

        private void initData()
        {
            setDefaultRadgValue();
            this.LoadGates();
            setGridData();
            setCustomerIDData();
            setCustomerIDLookupEdit();
            calculateRemainValue(0);
        }

        private void setCustomerIDData()
        {
            this.rpi_lke_CustomerID.DataSource = AppSetting.CustomerList.ToList();
            this.rpi_lke_CustomerID.DisplayMember = "CustomerNumber";
            this.rpi_lke_CustomerID.ValueMember = "CustomerID";
        }

        private void calculateRemainValue(int mode)
        {
            // Formula = Count([ContainerNum])-Sum(IIf([CheckOut],1,0))
            int checkOutSum = 0;
            switch (mode)
            {
                case 0:
                    {
                        IList<STGate_ContInOutRemain_Result> dataSource = (IList<STGate_ContInOutRemain_Result>)grdGateContInOut.DataSource;
                        foreach (STGate_ContInOutRemain_Result item in dataSource)
                        {
                            if ((bool)item.CheckOut)
                            {
                                checkOutSum++;
                            }
                        }
                        lblRemain.Text = (dataSource.Count - checkOutSum).ToString();
                        break;
                    }
                case 1:
                    {
                        IList<STGate_ContInOutRecent_Result> dataSource = (IList<STGate_ContInOutRecent_Result>)grdGateContInOut.DataSource;
                        foreach (STGate_ContInOutRecent_Result item in dataSource)
                        {
                            if ((bool)item.CheckOut)
                            {
                                checkOutSum++;
                            }
                        }
                        lblRemain.Text = (dataSource.Count - checkOutSum).ToString();
                        break;
                    }
                case 2:
                    {
                        IList<STGate_ContInOutByDate_Result> dataSource = (IList<STGate_ContInOutByDate_Result>)grdGateContInOut.DataSource;
                        foreach (STGate_ContInOutByDate_Result item in dataSource)
                        {
                            if ((bool)item.CheckOut)
                            {
                                checkOutSum++;
                            }
                        }
                        lblRemain.Text = (dataSource.Count - checkOutSum).ToString();
                        break;
                    }
                case 3:
                    {
                        IList<STGate_ContInOutByCustomer_Result> dataSource = (IList<STGate_ContInOutByCustomer_Result>)grdGateContInOut.DataSource;
                        foreach (STGate_ContInOutByCustomer_Result item in dataSource)
                        {
                            if ((bool)item.CheckOut)
                            {
                                checkOutSum++;
                            }
                        }
                        lblRemain.Text = (dataSource.Count - checkOutSum).ToString();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private void setCustomerIDLookupEdit()
        {
            var list = new DataProcess<ViewqryComboCustomerID>().Select();
            lkeCustomerID.Properties.DataSource = list;
        }

        private void setDefaultRadgValue()
        {
            radgFilterValue.SelectedIndex = 0;
            radgFilter1.SelectedIndex = 0;
        }

        private void setGridData()
        {
            // Execute store STGate_ContInOutRemain @Gate (byte)
            int gateNo = AppSetting.CurrentUser.Gate;
            IList<STGate_ContInOutRemain_Result> dataSource = gateContInOutRemainDataProcess.Executing("STGate_ContInOutRemain @Gate = {0},@varStoreID={1}", gateNo, AppSetting.StoreID).ToList();
            grdGateContInOut.DataSource = dataSource;
        }

        // Provide the editor for in-place editing.
        private void grvGateContInOut_CustomRowCellEditForEditing(object sender, CustomRowCellEditEventArgs e)
        {
            //if (e.Column.FieldName == "CustomerName")
            //    e.RepositoryItem = editorForEditing;
        }
        private void radgFilter1_EditValueChanged(object sender, EventArgs e)
        {
            this.lkeCustomerID.EditValue = null;
            radgFilter2.SelectedIndex = -1;
            if (radgFilter1.SelectedIndex != -1)
            {
                radgFilter2.SelectedIndex = -1;
            }

            // Handle cases
            if (radgFilter1.SelectedIndex == 2)
            {
                layoutControlOfDate.ContentVisible = true;
            }
            else
            {
                layoutControlOfDate.ContentVisible = false;
            }

            filterGrid(true);
        }

        private void radgFilter2_EditValueChanged(object sender, EventArgs e)
        {
            layoutControlOfDate.ContentVisible = false;
            if (radgFilter2.SelectedIndex != -1)
            {
                radgFilter1.SelectedIndex = -1;
                lkeCustomerID.Focus();
                lkeCustomerID.ShowPopup();
            }
            filterGrid(false);
        }

        /// <summary>
        /// Load all gate by storeID
        /// </summary>
        private void LoadGates()
        {
            var dataSource = FileProcess.LoadTable("Select * from Gates Where StoreID=" + AppSetting.StoreID);
            var rowAll = dataSource.NewRow();
            rowAll["Gate"] = 0;
            rowAll["StoreID"] = 1;
            rowAll["GateVietnam"] = "All";
            dataSource.Rows.InsertAt(rowAll, 0);
            this.lkeGates.Properties.DataSource = dataSource;
            this.lkeGates.Properties.DisplayMember = "GateVietnam";
            this.lkeGates.Properties.ValueMember = "Gate";
        }

        private void filterGrid(bool isFilter1)
        {
            int mode = -1;
            if (isFilter1)
            {
                int gate = Convert.ToInt32(this.lkeGates.EditValue);
                switch (radgFilter1.SelectedIndex)
                {
                    case 0:
                        {
                            layoutControlOfDate.ContentVisible = false;
                            DataProcess<STGate_ContInOutRemain_Result> gateContInOutRemainDataProcess = new DataProcess<STGate_ContInOutRemain_Result>();
                            grdGateContInOut.DataSource = gateContInOutRemainDataProcess.Executing("STGate_ContInOutRemain @Gate = {0},@varStoreID={1}", gate, AppSetting.StoreID).ToList();
                            mode = 0;
                            calculateRemainValue(mode);
                            break;
                        }
                    case 1:
                        {
                            layoutControlOfDate.ContentVisible = false;
                            DataProcess<STGate_ContInOutRecent_Result> gateContInOutRecentDataProcess = new DataProcess<STGate_ContInOutRecent_Result>();
                            grdGateContInOut.DataSource = gateContInOutRecentDataProcess.Executing("STGate_ContInOutRecent @Gate = {0},@varStoreID={1}", gate, AppSetting.StoreID).ToList();
                            mode = 1;
                            calculateRemainValue(mode);
                            break;
                        }
                    case 2:
                        {
                            layoutControlOfDate.ContentVisible = true;
                            dtDate.Focus();
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
            else
            {
                layoutControlOfDate.ContentVisible = false;
                lkeCustomerID.Focus();
                lkeCustomerID.ShowPopup();
            }
        }
        private void btnCheckingHistories_Click(object sender, EventArgs e)
        {
            // Execute store STContainerCheckingHistories
            DataProcess<STContainerCheckingHistories_Result> containerCheckingHistoriesDataProcess = new DataProcess<STContainerCheckingHistories_Result>();
            if (grvGateContInOut.SelectedRowsCount <= 0) return;
            int selectedIndex = grvGateContInOut.GetSelectedRows()[0];
            object dataRow = grvGateContInOut.GetRow(selectedIndex);
            DateTime startTime = new DateTime(1970, 1, 1);
            DateTime endTime = DateTime.Now;
            Type myType = dataRow.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

            if (dataRow != null)
            {
                int count = 0;
                foreach (PropertyInfo pInfo in props)
                {
                    if (count >= 2)
                    {
                        break;
                    }
                    // Gets the name of the property
                    string propertyName = pInfo.Name;

                    if (propertyName == "StartTime")
                    {
                        count++;
                        if (pInfo.GetValue(dataRow, null) != null)
                        {
                            startTime = Convert.ToDateTime(pInfo.GetValue(dataRow, null).ToString());
                        }
                    }

                    if (propertyName == "EndTime")
                    {
                        count++;
                        if (pInfo.GetValue(dataRow, null) != null)
                        {
                            endTime = Convert.ToDateTime(pInfo.GetValue(dataRow, null).ToString());
                        }
                    }
                }
            }

            IList<STContainerCheckingHistories_Result> result = containerCheckingHistoriesDataProcess.Executing("STContainerCheckingHistories @FromDate = {0}, @ToDate = {1}", startTime, endTime).ToList();
            frm_WM_SelectedResults historiesForm = new frm_WM_SelectedResults();
            historiesForm.setData(result);
            historiesForm.Show();
        }

        private void lkeCustomerID_EditValueChanged(object sender, EventArgs e)
        {
            // Execute STGate_ContInOutByCustomer @CustomerID (int)
            DataProcess<STGate_ContInOutByCustomer_Result> gateContInOutByCustomerDataProcess = new DataProcess<STGate_ContInOutByCustomer_Result>();
            if (lkeCustomerID.EditValue == null) return;
            int customerID = Int32.Parse(lkeCustomerID.EditValue.ToString());
            IList<STGate_ContInOutByCustomer_Result> dataSource = gateContInOutByCustomerDataProcess.Executing("STGate_ContInOutByCustomer @CustomerID = {0},@varStoreID={1}", customerID, AppSetting.StoreID).ToList();
            grdGateContInOut.DataSource = dataSource;
            calculateRemainValue(3);
        }

        private void dtDate_EditValueChanged(object sender, EventArgs e)
        {
            // Execute STGate_ContInOutByDate @ReportDate
            DataProcess<STGate_ContInOutByDate_Result> gateContInOutByDateDataProcess = new DataProcess<STGate_ContInOutByDate_Result>();
            IList<STGate_ContInOutByDate_Result> dataSource = gateContInOutByDateDataProcess.Executing("STGate_ContInOutByDate @ReportDate = {0},@Gate={1},@varStoreID={2}",
                dtDate.DateTime.ToString("yyyy-MM-dd"), lkeGates.EditValue, AppSetting.StoreID).ToList();
            grdGateContInOut.DataSource = dataSource;
            calculateRemainValue(2);
        }

        private void rpi_lke_CustomerID_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            LookUpEdit edit = sender as LookUpEdit;
            edit.EditValue = e.Value;
            int contInOutID = Convert.ToInt32(this.grvGateContInOut.GetFocusedRowCellValue("ContInOutID"));

            this.grvGateContInOut.SetFocusedRowCellValue("CustomerName", Convert.ToString(edit.GetColumnValue("CustomerName")));
            int result = this.gateContInOutRemainDataProcess.ExecuteNoQuery("UPDATE Gate_ContInOut SET CustomerName = {0}, CustomerID = {1} WHERE ContInOutID = {2}", Convert.ToString(edit.GetColumnValue("CustomerName")), Convert.ToInt32(edit.EditValue), contInOutID);
        }

        private void grdGateContInOut_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                if (this.grvGateContInOut.FocusedRowHandle >= 0)
                {
                    var currentContInOutId = this.grvGateContInOut.GetFocusedRowCellValue("ContInOutID");
                    frm_WM_Attachments.Instance.OrderNumber = currentContInOutId.ToString();
                    frm_WM_Attachments.Instance.CustomerID = 0;
                    frm_WM_Attachments.Instance.TruckInout = "CO";
                    if (frm_WM_Attachments.Instance.Enabled)
                    {
                        frm_WM_Attachments.Instance.ShowDialog();
                    }
                }
            }
        }

        private void rpi_hpl_TruckIn_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
        }

        private void rpi_hpl_TruckIn_ButtonClick(object sender, EventArgs e)
        {
            if (this.grvGateContInOut.FocusedRowHandle < 0) return;
            var currentTruct = (STGate_ContInOutRemain_Result)this.grvGateContInOut.GetRow(this.grvGateContInOut.FocusedRowHandle);
            DataProcess<object> gateContInoutDA = new DataProcess<object>();
            string query = string.Empty;
            bool truckCheckOut = Convert.ToBoolean(currentTruct.TruckCheckOut);
            if (truckCheckOut)
            {
                // Container out
                query = "UPDATE Gate_ContInOut SET TruckOut = '', TruckCheckOut =0 WHERE ContInOutID = " + currentTruct.ContInOutID;
                this.grvGateContInOut.SetRowCellValue(this.grvGateContInOut.FocusedRowHandle, "TruckOut", string.Empty);
                this.grvGateContInOut.SetRowCellValue(this.grvGateContInOut.FocusedRowHandle, "TruckCheckOut", false);
            }
            else
            {
                // Container not out
                query = "UPDATE Gate_ContInOut SET TruckOut = 'Same trailer',TruckCheckOut =1 WHERE ContInOutID = " + currentTruct.ContInOutID;
                this.grvGateContInOut.SetRowCellValue(this.grvGateContInOut.FocusedRowHandle, "TruckOut", "Same trailer");
                this.grvGateContInOut.SetRowCellValue(this.grvGateContInOut.FocusedRowHandle, "TruckCheckOut", true);
            }
            int result = gateContInoutDA.ExecuteNoQuery(query);
        }

        private void lkeGates_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void lkeGates_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.Value == null) return;
            this.lkeGates.EditValue = e.Value;
            int gate = Convert.ToInt32(this.lkeGates.EditValue);
            int mode = -1;
            switch (radgFilter1.SelectedIndex)
            {
                case 0:
                    {
                        layoutControlOfDate.ContentVisible = false;
                        DataProcess<STGate_ContInOutRemain_Result> gateContInOutRemainDataProcess = new DataProcess<STGate_ContInOutRemain_Result>();
                        grdGateContInOut.DataSource = gateContInOutRemainDataProcess.Executing("STGate_ContInOutRemain @Gate = {0},@varStoreID={1}", gate, AppSetting.StoreID).ToList();
                        mode = 0;
                        calculateRemainValue(mode);
                        break;
                    }
                case 1:
                    {
                        layoutControlOfDate.ContentVisible = false;
                        DataProcess<STGate_ContInOutRecent_Result> gateContInOutRecentDataProcess = new DataProcess<STGate_ContInOutRecent_Result>();
                        grdGateContInOut.DataSource = gateContInOutRecentDataProcess.Executing("STGate_ContInOutRecent @Gate = {0},@varStoreID={1}", gate, AppSetting.StoreID).ToList();
                        mode = 1;
                        calculateRemainValue(mode);
                        break;
                    }
            }
        }

        private void grvGateContInOut_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle < 0) return;
            DataProcess<object> da = new DataProcess<object>();
            int countID = Convert.ToInt32(this.grvGateContInOut.GetFocusedRowCellValue("ContInOutID"));
            switch (e.Column.FieldName)
            {
                case "ProductQty":
                    da.ExecuteNoQuery("Update Gate_ContInOut set ProductQty='" + e.Value + "', UserCheckOut = 1, UserOut='" + AppSetting.CurrentUser.LoginName + "-" + DateTime.Now.ToString() + "' Where ContInOutID=" + countID);
                    this.grvGateContInOut.SetFocusedRowCellValue("UserOut", AppSetting.CurrentUser.LoginName + "-" + DateTime.Now.ToString());
                    break;
                case "Reason":
                    da.ExecuteNoQuery("Update Gate_ContInOut set Reason='" + e.Value + "', UserCheckOut = 1, UserOut='" + AppSetting.CurrentUser.LoginName + "-" + DateTime.Now.ToString() + "' Where ContInOutID=" + countID);
                    this.grvGateContInOut.SetFocusedRowCellValue("UserOut", AppSetting.CurrentUser.LoginName + "-" + DateTime.Now.ToString());
                    break;
                default:
                    break;
            }
        }

        private void rpi_hle_ContainerChecking_Click(object sender, EventArgs e)
        {
            frm_WM_ContainerCheckings frm = new frm_WM_ContainerCheckings(Convert.ToInt32(this.grvGateContInOut.GetFocusedRowCellValue("ContInOutID").ToString()));
            frm.Show();
            frm.WindowState = FormWindowState.Normal;
            frm.BringToFront();
        }

        private void rpi_hle_OrderNumber_Click(object sender, EventArgs e)
        {
            string orderNumber = Convert.ToString(this.grvGateContInOut.GetFocusedRowCellValue("OrderNumber"));
            var orderType = orderNumber.Split('-');
            int orderID = Convert.ToInt32(orderType[1]);
            if (orderNumber != null)
            {
                switch (orderType[0])
                {
                    case "RO":
                        frm_WM_ReceivingOrders receivingOrder = frm_WM_ReceivingOrders.Instance;
                        receivingOrder.ReceivingOrderIDFind = orderID;
                        receivingOrder.Show();
                        receivingOrder.WindowState = FormWindowState.Maximized;
                        receivingOrder.BringToFront();
                        break;
                    case "DO":
                        // Display disptching order
                        frm_WM_DispatchingOrders dispatchingOrder = frm_WM_DispatchingOrders.GetInstance(orderID);
                        if (dispatchingOrder.Visible)
                        {
                            dispatchingOrder.ReloadData();
                        }
                        dispatchingOrder.Show();
                        dispatchingOrder.WindowState = FormWindowState.Maximized;
                        dispatchingOrder.BringToFront();
                        break;
                    default:
                        break;
                }
            }
        }

        private void rpi_txt_Qty_DoubleClick(object sender, EventArgs e)
        {
            if (this.lkeCustomerID.EditValue == null)
            {
                MessageBox.Show("Please enter customer ID !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool hasOut = Convert.ToBoolean(this.grvGateContInOut.GetFocusedRowCellValue("CheckOut"));
            if (hasOut)
            {
                MessageBox.Show("Can not change if container is out !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int conID = Convert.ToInt32(this.grvGateContInOut.GetFocusedRowCellValue("ContInOutID"));
            string startTime = Convert.ToString(this.grvGateContInOut.GetFocusedRowCellValue("StartTime"));
            if (string.IsNullOrEmpty(startTime)) startTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            string reason = Convert.ToString(this.grvGateContInOut.GetFocusedRowCellValue("Reason"));

            DataProcess<object> da = new DataProcess<object>();
            if (!string.IsNullOrEmpty(reason) && reason.Equals("Xuat"))
            {
                // initialize a new XtraInputBoxArgs instance 
                XtraInputBoxArgs args = new XtraInputBoxArgs();
                // set required Input Box options 
                args.Caption = "TPWMS";
                args.Prompt = "Please enter start running time : ";
                args.DefaultButtonIndex = 0;
                args.Showing += Args_Showing;
                // initialize a DateEdit editor with custom settings 
                DateEdit editor = new DateEdit();
                editor.Properties.Mask.EditMask = "dd/MM/yyyy HH:mm:ss";
                editor.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
                args.Editor = editor;

                // a default DateEdit value 
                args.DefaultResponse = Convert.ToDateTime(startTime);
                // display an Input Box with the custom editor 
                var result = Convert.ToString(XtraInputBox.Show(args));
                // set a dialog icon 

                if (string.IsNullOrEmpty(result))
                {
                    MessageBox.Show("Can not allow this container out if no start time is set !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                da.ExecuteNoQuery("Update Gate_ContInOut set StartTime='" + Convert.ToDateTime(startTime).ToString("yyyy-MM-dd HH:mm:ss") + "' Where ContInOutID=" + conID);
            }

            string qty = Convert.ToString(this.grvGateContInOut.GetFocusedRowCellValue("ProductQty"));
            if (string.IsNullOrEmpty(qty)) qty = "Co hang";
            var qtyInput = XtraInputBox.Show("Please enter quantity : ", "TPWMS", qty);
            if (string.IsNullOrEmpty(qtyInput) || qtyInput.Equals(qty)) return;
            qty = qtyInput;

            string orderNumber = Convert.ToString(this.grvGateContInOut.GetFocusedRowCellValue("OrderNumber"));
            if (string.IsNullOrEmpty(orderNumber))
            {
                var orderInput = XtraInputBox.Show("Please enter Order Number : ", "TPWMS", orderNumber);
                if (string.IsNullOrEmpty(orderInput)) return;
                else orderNumber = orderInput;
            }
            int resultUpdate = da.ExecuteNoQuery("Update Gate_ContInOut SET TruckOut = 'Same trailer', UserCheckOut = 1, ProductQty = '" + qty
                 + "', UserOut = '" + AppSetting.CurrentUser.LoginName + "-" + DateTime.Now.ToString()
                 + "', OrderNumber = '" + orderNumber + "' Where ContInOutID=" + conID);
        }
        private void Args_Showing(object sender, XtraMessageShowingArgs e)
        {
            e.Form.Icon = this.Icon;
        }
    }
}
