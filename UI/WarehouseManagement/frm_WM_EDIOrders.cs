using Common.Process;
using DA;
using DA.Warehouse;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using UI.MasterSystemSetup;
using UI.Helper;
using System.Data.Entity.Core.Objects;
using log4net;
using DevExpress.Utils.Win;
using DevExpress.XtraEditors.Popup;
using UI.Management;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_EDIOrders : Common.Controls.frmBaseForm
    {
        // Declare log
        private static readonly log4net.ILog log = LogManager.GetLogger(typeof(frm_WM_EDIOrders));
        private static frm_WM_EDIOrders instance = new frm_WM_EDIOrders();
        string m_userName = AppSetting.CurrentUser.LoginName;
        BindingList<ReceivingOrderDetails> listOrderDetail = new BindingList<ReceivingOrderDetails>();
        BindingList<EDI_Orders> m_BindingListOrders = new BindingList<EDI_Orders>();
        BindingList<EDI_OrderDetails> m_BindingListOrderDetai = new BindingList<EDI_OrderDetails>();
        private bool isAddNewRecord = false;
        IEnumerable<Products> listProduct;
        ReceivingOrderDetails objSelected = null;
        private EDI_Orders currentEDI = null; 

        bool isUpdate = false;
        private int ediIDOrderFind = 0;

        public void GetEDI_Orders()
        {
            this.LoadData_EDI_Order();
        }
        public frm_WM_EDIOrders(int ediIDInput = 0)
        {
            this.ediIDOrderFind = ediIDInput;
            InitializeComponent();
            this.lkeDispatchType.Properties.DataSource = FileProcess.LoadTable("SELECT CustomerDispatchMethodID, CAST(CustomerDispatchMethodID as varchar(30)) + ' | ' + CustomerDispatchMethod + CASE WHEN Remark IS NULL THEN '' ELSE ' | ' + Remark END  as CustomerDispatchMethod FROM CustomerDispatchMethod");
            this.lkeDispatchType.Properties.ValueMember = "CustomerDispatchMethodID";
            this.lkeDispatchType.Properties.DisplayMember = "CustomerDispatchMethod";
            SetEvent();

            //this.dataNavigator_EDIOrders.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
        }
        void Frm_WM_EDIOrders_Load(object sender, EventArgs e)
        {
            try
            {
                this.isAddNewRecord = false;
                ///this.LoadData2searchLookUpEdit_CustomerID();

                this.LoadData_EDI_Order();

                this.SetActiveForm();

                this.radioGroup_DispatchType.EditValue = 1;

                if (isAddNewRecord)
                {
                    m_BindingListOrders.RemoveAt(0);
                }

                int v_CustomerID = 0;
                try
                {
                    v_CustomerID = m_BindingListOrders[this.dataNavigator_EDIOrders.Position].CustomerID;
                    Customers cus = AppSetting.CustomerList.Where(c => c.CustomerID == v_CustomerID).FirstOrDefault();
                    this.lkeDispatchType.EditValue = cus.CustomerDispatchType;
                    
                    if (v_CustomerID == 24)
                    {
                        radioGroup_DispatchType.SelectedIndex = 5;
                    }
                    else
                    {
                        radioGroup_DispatchType.SelectedIndex = 0;
                    }
                }
                catch (Exception ex)
                {
                    log.Error("==> Error is unexpected");
                    log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                }

            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                MessageBox.Show(ex.Message, "Error is unexpected");
            }
        }

        void SetEvent()
        {
            this.Load += Frm_WM_EDIOrders_Load;

            radioGroup_DispatchType.SelectedIndexChanged += RadioGroup_DispatchType_SelectedIndexChanged;
            radioGroup_OptionCustomer.SelectedIndexChanged += RadioGroup_OptionCustomer_SelectedIndexChanged;
            radioGroup_OrderType.SelectedIndexChanged += RadioGroup_OrderType_SelectedIndexChanged;

            btn_Close.Click += Btn_Close_Click;
            //btn_ProcessAllNew.Click += Btn_CreateBooking_Click;
            btn_DeleteOrder.Click += Btn_DeleteOrder_Click;
            btn_ImportFile.Click += Btn_ImportFile_Click;
            btn_Ok.Click += Btn_Ok_Click;
            btn_ProcessMain.Click += Btn_ProcessMain_Click;
            this.gridViewOrderDetail.RowCellStyle += GridViewOrderDetail_RowCellStyle;

            btnEdit_ProcessingOrderNumber.Properties.ButtonClick += btnEdit_ProcessingOrderNumber_Properties_ButtonClick;

            dataNavigator_EDIOrders.PositionChanged += DataNavigator_EDIOrders_PositionChanged;
            //this.searchLookUpEdit_CustomerID.KeyDown += SearchLookUpEdit_CustomerID_KeyDown;
            //this.searchLookUpEdit_CustomerID.CloseUp += SearchLookUpEdit_CustomerID_CloseUp;

            repositoryItemHyperLinkEditProductInfo.Click += RepItemButtonEdit_EDIOrders_ProductInfo_DoubleClick;
        }

        private void GridViewOrderDetail_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            int status = Convert.ToInt32(this.gridViewOrderDetail.GetRowCellValue(e.RowHandle, "Status"));
            switch (status)
            {
                case 3:
                    e.Appearance.ForeColor = Color.Red;
                    break;
                case 1:
                    e.Appearance.ForeColor = Color.Blue;
                    break;
                case 2:
                    e.Appearance.ForeColor = Color.FromArgb(0, 192, 0);
                    break;
                default:
                    e.Appearance.ForeColor = Color.Black;
                    break;
            }
        }

        //private void SearchLookUpEdit_CustomerID_CloseUp(object sender, CloseUpEventArgs e)
        //{
        //    LookUpEdit edit = sender as LookUpEdit;
        //    IPopupControl popup = sender as IPopupControl;
        //    PopupLookUpEditForm f = popup.PopupWindow as PopupLookUpEditForm;
        //    var currentValue = f.CurrentValue;
        //    edit.EditValue = currentValue;
        //    this.LoadCustomerMain();
        //    try
        //    {
        //        int v_CustomerID = Convert.ToInt32(txtEdit_CustomerNumber.EditValue);
        //        if (v_CustomerID == 24)
        //        { radioGroup_DispatchType.SelectedIndex = 5; }
        //        else
        //        { radioGroup_DispatchType.SelectedIndex = 0; }
        //    }

        //    catch (Exception ex)
        //    {
        //        log.Error("==> Error is unexpected");
        //        log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
        //    }
        //}

        //private void SearchLookUpEdit_CustomerID_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode != Keys.Enter) return;
        //    this.LoadCustomerMain();
        //}

        private void LoadCustomerMain()
        {
            LoadData_EDI_Order();
            //var view = (STEDI_comboCustomerMainID_Result)this.searchLookUpEdit_CustomerID.GetSelectedDataRow();
            //if (view == null) return;
            //textEdit_CustomerName.Text = view.CustomerName;
            //this.txtEdit_CustomerNumber.Text = view.CustomerNumber;
            //this.txtEdit_CustomerName.Text = view.CustomerName;
        }

        #region Event Common

        void DataNavigator_EDIOrders_PositionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataNavigator_EDIOrders.Position < 0) return;

                isUpdate = false;
                currentEDI = this.m_BindingListOrders[this.dataNavigator_EDIOrders.Position];
                this.btnEdit_ProcessingOrderNumber.EditValue = currentEDI.ProcessingOrderNumber;
                this.SetBindingControl_EDI_Orders(currentEDI);
                LoadData_EDI_OrderDetail(Convert.ToInt32(currentEDI.EDI_OrderID));

                DataProcess<Customers> v_DA = new DataProcess<Customers>();
                int v_CustomerID = 0;
                try
                {
                    v_CustomerID = Convert.ToInt32(txtEdit_CustomerNumber.EditValue);
                    if (v_CustomerID == 24)
                    {
                        radioGroup_DispatchType.SelectedIndex = 5;
                    }
                    else
                    {
                        radioGroup_DispatchType.SelectedIndex = 0;
                    }
                }
                catch (Exception ex)
                {
                    log.Error("==> Error is unexpected");
                    log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                }

                try
                {
                    Customers v_List = v_DA.Select(c => c.CustomerID == v_CustomerID).FirstOrDefault();
                    txtEdit_CustomerNumber.EditValue = v_List.CustomerNumber;
                    txtEdit_CustomerName.EditValue = v_List.CustomerName;

                    txtEdit_CreatedTime.Text = Convert.ToDateTime(txtEdit_CreatedTime.EditValue).ToString("dd/MM/yyyy HH:mm");
                    txtEdit_ProcessingTime.Text = Convert.ToDateTime(txtEdit_ProcessingTime.EditValue).ToString("dd/MM/yyyy HH:mm");
                }
                catch (Exception ex)
                {
                    log.Error("==> Error is unexpected");
                    log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                    txtEdit_CustomerNumber.EditValue = "";
                    txtEdit_CustomerName.EditValue = "";
                }

                isUpdate = true;

                SetActiveForm();
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                Wait.Close();
            }
            Wait.Close();
        }

        #endregion Event Common

        #region Radio
        void RadioGroup_DispatchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            RadioGroup v_rg = (RadioGroup)sender;
            int v_index = v_rg.SelectedIndex;
            switch (v_index)
            {
                case 0:
                    btn_Ok.Enabled = true;
                    break;
                case 1:
                    btn_Ok.Enabled = false;
                    break;
                default:
                    break;
            }
        }
        void RadioGroup_OrderType_SelectedIndexChanged(object sender, EventArgs e)
        {
            RadioGroup rg = (RadioGroup)sender;
            int index = rg.SelectedIndex;
        }
        void RadioGroup_OptionCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            RadioGroup v_rg = (RadioGroup)sender;
            int v_index = v_rg.SelectedIndex;
            switch (v_index)
            {
                case 0: //All
                    //searchLookUpEdit_CustomerID.ReadOnly = true;
                    //textEdit_CustomerName.ReadOnly = true;

                    LoadData_EDI_Order();

                    break;

                case 1: //Me
                    //searchLookUpEdit_CustomerID.ReadOnly = true;
                    //textEdit_CustomerName.ReadOnly = true;

                    LoadData_EDI_Order();
                    break;

                case 2://Me_0
                    //searchLookUpEdit_CustomerID.ReadOnly = true;
                    //textEdit_CustomerName.ReadOnly = true;

                    LoadData_EDI_Order();
                    break;

                //case 3: //Customer
                //    searchLookUpEdit_CustomerID.ReadOnly = false;
                //    textEdit_CustomerName.ReadOnly = false;

                //    searchLookUpEdit_CustomerID.Focus();
                //    searchLookUpEdit_CustomerID.ShowPopup();

                    //break;

                default:
                    break;
            }
        }


        #endregion Radio

        #region Button
        void btnEdit_ProcessingOrderNumber_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (this.btnEdit_ProcessingOrderNumber.EditValue == null) return;
            string orderNumber = Convert.ToString(this.btnEdit_ProcessingOrderNumber.EditValue);
            if (string.IsNullOrEmpty(orderNumber)) return;
            string orderType = orderNumber.Split('-')[0];
            int orderID = Convert.ToInt32(orderNumber.Split('-')[1]);
            switch (orderType)
            {
                case "DO":
                    frm_WM_DispatchingOrders frm = frm_WM_DispatchingOrders.GetInstance(orderID);
                    if (frm.Visible)
                    {
                        frm.ReloadData();
                    }
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowInTaskbar = false;
                    frm.Show();
                    break;
                case "RO":
                    frm_WM_ReceivingOrders frmRO = frm_WM_ReceivingOrders.Instance;
                    frmRO.ReceivingOrderIDFind = orderID;
                    frmRO.StartPosition = FormStartPosition.CenterScreen;
                    frmRO.ShowInTaskbar = false;
                    frmRO.Show();
                    break;
                case "SC":
                    frm_WM_PalletStatusChange frmSC = new frm_WM_PalletStatusChange();
                    frmSC.PalletStatusChangeIDFind = orderID;
                    frmSC.Show();
                    frmSC.WindowState = FormWindowState.Maximized;
                    frmSC.BringToFront();

                    break;
                default:
                    break;
            }
        }
        void Btn_ImportFile_Click(object sender, EventArgs e)
        {
            int customerIDSelected = 0;
            if (this.dataNavigator_EDIOrders.Position>-1) customerIDSelected = m_BindingListOrders[this.dataNavigator_EDIOrders.Position].CustomerID;
            UI.WarehouseManagement.frm_WM_EDIImportFiles frm = new frm_WM_EDIImportFiles(customerIDSelected);
            if (!frm.Enabled) return;
            frm.MyGetEDI_Order = new frm_WM_EDIImportFiles.GetEDI_Orders(GetEDI_Orders);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
            LoadData_EDI_Order();
        }
        //void Btn_CreateBooking_Click(object sender, EventArgs e)
        //{
        //    if (XtraMessageBox.Show("Are you sure to create a booking for this EDI ?", "WMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //    {
        //        frm_WM_CustomerBookingEntry frm = new frm_WM_CustomerBookingEntry();
        //        frm.StartPosition = FormStartPosition.CenterScreen;
        //        frm.ShowInTaskbar = false;
        //        frm.Show(this);
        //    }

        //    //If MsgBox("Are you sure to create a booking for this EDI ?", vbCritical + vbYesNo, "WMS-2022") = vbYes Then
        //    //DoCmd.OpenForm "frmCustomerBookingEntry", acNormal
        //    //DoCmd.GoToRecord , , acLast
        //    //End If
        //}
        void Btn_Close_Click(object sender, EventArgs e)
        {
            try
            {
                this.Dispose();
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
            }
        }
        void Btn_DeleteOrder_Click(object sender, EventArgs e)
        {
            int v_ProcessingStatus = 0;
            try
            {
                v_ProcessingStatus = Convert.ToInt32(currentEDI.ProcessingStatus);
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
            }

            if (v_ProcessingStatus <= 1)
            {
                if (XtraMessageBox.Show("Are you sure want to delete this EDI " + txtEdit_CustomerNumber.Text + " ?", "WMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int v_EDI_OrderID = 0;
                    try
                    {
                        v_EDI_OrderID = Convert.ToInt32(txtEdit_EDI_OrderID.EditValue);
                    }
                    catch (Exception ex)
                    {
                        log.Error("==> Error is unexpected");
                        log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                    }
                    string v_StrSQL = " ";
                    v_StrSQL += " DELETE FROM EDI_OrderDetails WHERE EDI_OrderID  = " + v_EDI_OrderID + "";
                    v_StrSQL += " DELETE FROM EDI_Orders WHERE EDI_OrderID  = " + v_EDI_OrderID + "";

                    DA.Warehouse.EDIOrdersDA v_Da = new EDIOrdersDA();
                    int v_ret = v_Da.ExecSQLString(v_StrSQL);

                    LoadData_EDI_Order();
                }
            }
            else
            {
                XtraMessageBox.Show("You can not delete order that it was completed!", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        void Btn_ProcessMain_Click(object sender, EventArgs e)
        {
            //DoCmd.RunCommand acCmdSaveRecord

            DataProcess<EDI_Orders> v_Da = new DataProcess<EDI_Orders>();
            DateTime v_fromDate = v_Da.GetDate().AddDays(-7);
            DateTime v_toDate = v_Da.GetDate().AddDays(+7);

            DateTime v_OrderDate = DateTime.Now;

            try
            {
                v_OrderDate = Convert.ToDateTime(txtEdit_OrderDate.EditValue);
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
            }

            if ((v_OrderDate > v_toDate) || (v_OrderDate < v_fromDate))
            {
                XtraMessageBox.Show("Order date is not correct!!!", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEdit_OrderDate.Focus();
                return;
            }

            if (Convert.ToInt32(currentEDI.ProcessingStatus).Equals(1))
            {
                int v_EDIOrderID = 0;

                try
                {
                    v_EDIOrderID = Convert.ToInt32(txtEdit_EDI_OrderID.EditValue);
                }
                catch (Exception ex)
                {
                    log.Error("==> Error is unexpected");
                    log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                }

                int v_Index = this.dataNavigator_EDIOrders.Position;

                if (radioGroup_OrderType.EditValue.Equals(3))
                {
                    int v_CustomerID = 0;
                    string v_CustomerClientCode = "";
                    string v_CustomerClientName = "";
                    string v_CustomerClientAddress = "";

                    v_CustomerClientCode = txtEdit_CustomerClientCode.Text;
                    v_CustomerClientName = "NEW - Client Name";
                    v_CustomerClientAddress = "NEW - Client Address";

                    try
                    {
                        v_CustomerID = Convert.ToInt32(txtEdit_CustomerNumber.EditValue);
                    }
                    catch (Exception ex)
                    {
                        log.Error("==> Error is unexpected");
                        log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                    }

                    //if (v_CustomerID.Equals(920) || v_CustomerID.Equals(919)) //' Chi moi ap dung cho VinMart
                    //{
                    DA.DataProcess<CustomerClients> v_DaCus = new DataProcess<CustomerClients>();
                    IList<CustomerClients> v_ListCusClient = v_DaCus.Select(c => c.CustomerClientCode == v_CustomerClientCode).ToList();
                    if (v_ListCusClient.Count <= 0)
                    {
                        if (XtraMessageBox.Show("This Client Code(Store) was not created, do you want to create now?", "WMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            return;
                        }
                        else
                        {
                            DA.Warehouse.EDIOrdersDA v_daEDI = new DA.Warehouse.EDIOrdersDA();
                            ObjectParameter v_newCustomerClientID = new ObjectParameter("newCustomerClientID", 0);
                            int result = v_daEDI.STCustomerClientsInsert(v_CustomerID, v_CustomerClientCode, v_CustomerClientName, v_CustomerClientAddress, this.m_userName, v_newCustomerClientID);

                            int v_newCustomerClientID_OutPut = 0;
                            try
                            {
                                v_newCustomerClientID_OutPut = Convert.ToInt32(v_newCustomerClientID.Value);
                            }
                            catch (Exception ex)
                            {
                                log.Error("==> Error is unexpected");
                                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                            }

                            UI.MasterSystemSetup.frm_MSS_CustomerClients frm_Cus = new frm_MSS_CustomerClients();
                            frm_Cus.StartPosition = FormStartPosition.CenterScreen;
                            frm_Cus.ShowInTaskbar = false;
                            frm_Cus.Show(this);
                        }
                    }

                    int ediType = Convert.ToInt32(radioGroup_DispatchType.EditValue);
                    if (ediType.Equals(1))
                    {
                        DA.Warehouse.EDIOrdersDA v_DaStandard = new EDIOrdersDA();
                        int v_Ret = v_DaStandard.STEDI_ProcessDispatchingOrder_Main(v_EDIOrderID, this.m_userName, 1);

                    }
                    else if (ediType.Equals(2))
                    {
                        DA.Warehouse.EDIOrdersDA v_DaExp = new EDIOrdersDA();
                        int v_Ret = v_DaExp.STEDI_ProcessDispatchingOrder_Main_PickSequence(v_EDIOrderID, this.m_userName);
                    }
                    else if (ediType.Equals(5))
                    {
                        DA.Warehouse.EDIOrdersDA v_DaTheLongLife = new EDIOrdersDA();
                        int v_Ret = v_DaTheLongLife.STEDI_ProcessDispatchingOrder_Main(v_EDIOrderID, this.m_userName, 5);
                    }
                    else if (ediType.Equals(7))
                    {
                        //the shelf life 1/2, 2/3
                        DA.Warehouse.EDIOrdersDA v_DaTheLongLife = new EDIOrdersDA();
                        int v_Ret = v_DaTheLongLife.STEDI_ProcessDispatchingOrder_Main(v_EDIOrderID, this.m_userName, 7);
                    }

                    LoadData_EDI_Order();

                    this.dataNavigator_EDIOrders.Position = v_Index;
                    string orderNumber = this.m_BindingListOrders[v_Index].ProcessingOrderNumber;
                    int orderID = 0;
                    if (string.IsNullOrEmpty(orderNumber) == false && orderNumber.Length > 3)
                    {
                        orderID = Convert.ToInt32(orderNumber.Substring(3, orderNumber.Length - 3));
                    }


                    var frmDispatching = frm_WM_DispatchingOrders.GetInstance(orderID);
                    if (frmDispatching.Visible)
                    {
                        frmDispatching.ReloadData();
                    }
                    frmDispatching.StartPosition = FormStartPosition.CenterScreen;
                    frmDispatching.ShowInTaskbar = true;
                    frmDispatching.Show();

                }
                else if (radioGroup_OrderType.EditValue.Equals(2))
                {
                    DA.Warehouse.EDIOrdersDA v_DaRO = new EDIOrdersDA();
                    int v_Ret = v_DaRO.STEDI_ProcessReceivingOrder(v_EDIOrderID, this.m_userName);

                    LoadData_EDI_Order();

                    this.dataNavigator_EDIOrders.Position = v_Index;
                    string orderNumber = this.m_BindingListOrders[v_Index].ProcessingOrderNumber;
                    int orderID = 0;
                    if (string.IsNullOrEmpty(orderNumber) == false && orderNumber.Length > 3)
                    {
                        orderID = Convert.ToInt32(orderNumber.Substring(3, orderNumber.Length - 3));
                    }
                    if (orderID == 0)
                    {
                        XtraMessageBox.Show("RO is not correct!!!", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    UI.WarehouseManagement.frm_WM_ReceivingOrders frm = frm_WM_ReceivingOrders.Instance;
                    frm.ReceivingOrderIDFind = orderID;
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowInTaskbar = false;
                    frm.Show();
                }
                else if (radioGroup_OrderType.EditValue.Equals(4))//SC
                {
                    DA.Warehouse.EDIOrdersDA v_DaRO = new EDIOrdersDA();
                    int v_Ret = v_DaRO.STEDI_ProcessReceivingOrder(v_EDIOrderID, this.m_userName);
                    LoadData_EDI_Order();
                    this.dataNavigator_EDIOrders.Position = v_Index;

                    string orderNumber = this.m_BindingListOrders[v_Index].ProcessingOrderNumber;
                    int orderID = 0;
                    if (string.IsNullOrEmpty(orderNumber) == false && orderNumber.Length > 3)
                    {
                        orderID = Convert.ToInt32(orderNumber.Substring(3, orderNumber.Length - 3));
                    }
                    if (orderID == 0)
                    {
                        XtraMessageBox.Show("SC is not correct!!!", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    frm_WM_PalletStatusChange frmSC = new frm_WM_PalletStatusChange();
                    frmSC.PalletStatusChangeIDFind = orderID;
                    frmSC.Show();
                    frmSC.WindowState = FormWindowState.Maximized;
                    frmSC.BringToFront();
                }
            }
        }
        void Btn_Ok_Click(object sender, EventArgs e)
        {
            DataProcess<EDI_Orders> v_Da = new DataProcess<EDI_Orders>();
            DateTime v_fromDate = v_Da.GetDate().AddDays(-7);
            DateTime v_toDate = v_Da.GetDate().AddDays(+7);

            DateTime v_OrderDate = DateTime.Now;

            try
            {
                v_OrderDate = Convert.ToDateTime(txtEdit_OrderDate.EditValue);
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
            }

            if ((v_OrderDate > v_toDate) || (v_OrderDate < v_fromDate))
            {
                XtraMessageBox.Show("Order date is not correct!!!", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEdit_OrderDate.Focus();
                return;
            }

            if (Convert.ToInt32(currentEDI.ProcessingStatus).Equals(1))
            {
                int v_EDIOrderID = 0;

                try
                {
                    v_EDIOrderID = Convert.ToInt32(txtEdit_EDI_OrderID.EditValue);
                }
                catch (Exception ex)
                {
                    log.Error("==> Error is unexpected");
                    log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                }

                int v_Index = this.dataNavigator_EDIOrders.Position;

                //'Import Dispatching Orders
                if (radioGroup_OrderType.EditValue.Equals(3))
                {
                    DA.Warehouse.EDIOrdersDA v_DaFun = new EDIOrdersDA();
                    int v_Ret = v_DaFun.STEDI_ProcessDispatchingOrder(v_EDIOrderID, this.m_userName);

                    LoadData_EDI_Order();

                    this.dataNavigator_EDIOrders.Position = v_Index;
                    string orderNumber = this.m_BindingListOrders[v_Index].ProcessingOrderNumber;
                    int orderID = 0;
                    if (string.IsNullOrEmpty(orderNumber) == false && orderNumber.Length > 3)
                    {
                        orderID = Convert.ToInt32(orderNumber.Substring(3, orderNumber.Length - 3));
                    }


                    var frmDispatching = frm_WM_DispatchingOrders.GetInstance(orderID);
                    if (frmDispatching.Visible)
                    {
                        frmDispatching.ReloadData();
                    }
                    frmDispatching.StartPosition = FormStartPosition.CenterScreen;
                    frmDispatching.ShowInTaskbar = false;
                    frmDispatching.Show();
                }
                //'Import Receiving Orders
                else if (radioGroup_OrderType.EditValue.Equals(2))
                {
                    DA.Warehouse.EDIOrdersDA v_DaFun = new EDIOrdersDA();
                    int v_Ret = v_DaFun.STEDI_ProcessReceivingOrder(v_EDIOrderID, this.m_userName);

                    LoadData_EDI_Order();

                    this.dataNavigator_EDIOrders.Position = v_Index;

                    UI.WarehouseManagement.frm_WM_ReceivingOrders frm = frm_WM_ReceivingOrders.Instance;
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowInTaskbar = false;
                    frm.Show();
                }

            }
        }

        void RepItemButtonEdit_EDIOrders_ProductInfo_DoubleClick(object sender, EventArgs e)
        {
            int v_ProductID = 0;

            try
            {
                string v_ProductNumber = Convert.ToString(gridViewOrderDetail.GetRowCellValue(gridViewOrderDetail.FocusedRowHandle, "ProductNumber"));
                if (!string.IsNullOrEmpty(v_ProductNumber))
                {
                    DataProcess<Products> v_process = new DataProcess<Products>();
                    List<Products> v_DA = v_process.Executing("select Top 1 * from Products WHERE (SUBSTRING(dbo.Products.ProductNumber, 5, 26) = {0})", v_ProductNumber).ToList();
                    if (v_DA.Count > 0)
                    {
                        v_ProductID = v_DA[0].ProductID;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
            }
            if (v_ProductID != 0)
            {
                UI.MasterSystemSetup.frm_MSS_Products frm = MasterSystemSetup.frm_MSS_Products.Instance;
                frm.ProductIDLookup = v_ProductID;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowInTaskbar = false;
                frm.Show(this);
            }
        }

        #endregion Button

        #region LoadData
        void SetEditGridControl()
        {
            int v_Disching = 0;
            try
            {
                v_Disching = Convert.ToInt32(radioGroup_DispatchType.EditValue);
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
            }

            for (int i = 0; i < gridViewOrderDetail.Columns.Count; i++)
            {
                gridViewOrderDetail.Columns[i].OptionsColumn.AllowEdit = false;
                gridViewOrderDetail.Columns[i].OptionsColumn.ReadOnly = true;
            }

            if (v_Disching == 2)
            {
                gridViewOrderDetail.Columns["ExpiryDate"].OptionsColumn.AllowEdit = true;
                gridViewOrderDetail.Columns["ExpiryDate"].OptionsColumn.ReadOnly = false;
            }
        }
        void SetActiveForm()
        {
            int v_ProcessStatus = 0;

            try
            {
                v_ProcessStatus = Convert.ToInt32(currentEDI.ProcessingStatus);
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
            }

            if (v_ProcessStatus == 1)
            {
                btn_ProcessAllNew.Enabled = true;
                btn_ProcessAllExtent.Enabled = true;

                btn_Ok.Enabled = true;
                btn_ProcessReference.Enabled = true;
                btn_ProcessReference_new.Enabled = true;
                btn_ProcessMain.Enabled = true;
                btn_DeleteOrder.Enabled = true;

                radioGroup_OrderType.Enabled = true;

                gridViewOrderDetail.OptionsBehavior.Editable = true;
                gridViewOrderDetail.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;

                //Form_subfrmEDIDetails.TextQuantity.enabled = True
                //Form_subfrmEDIDetails.TextQuantity.Locked = False
                //Form_frmEDIOrders.subfrmEDIDetails.Locked = False

            }
            else
            {
                btn_ProcessAllNew.Enabled = false;
                btn_ProcessAllExtent.Enabled = false;

                btn_Ok.Enabled = false;
                btn_ProcessReference.Enabled = false;
                btn_ProcessReference_new.Enabled = false;
                btn_ProcessMain.Enabled = false;
                btn_DeleteOrder.Enabled = false;

                radioGroup_OrderType.Enabled = false;

                gridViewOrderDetail.OptionsBehavior.Editable = false;
                gridViewOrderDetail.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;

                //Form_subfrmEDIDetails.TextQuantity.enabled = False
                //Form_subfrmEDIDetails.TextQuantity.Locked = True
                //Form_frmEDIOrders.subfrmEDIDetails.Locked = True
            }

            if (v_ProcessStatus == 0)
            {
                txtEdit_MessageStatus.Text = "0 - Order is editting by customer, can not process";
                txtEdit_MessageStatus.BackColor = System.Drawing.Color.Yellow;
                txtEdit_MessageStatus.ForeColor = System.Drawing.Color.Black;
            }
            else if (v_ProcessStatus == 1)
            {
                txtEdit_MessageStatus.Text = "1 - Order is confirmed by customer, can process";
                txtEdit_MessageStatus.BackColor = System.Drawing.Color.Blue;
                txtEdit_MessageStatus.ForeColor = System.Drawing.Color.White;
            }
            else
            {
                txtEdit_MessageStatus.Text = "2 - Order is processed, can not be edited or deleted";
                txtEdit_MessageStatus.BackColor = System.Drawing.Color.WhiteSmoke;
                txtEdit_MessageStatus.ForeColor = System.Drawing.Color.Black;
            }


        }
        void LoadData_EDI_Order()
        {
            int v_index = radioGroup_OptionCustomer.SelectedIndex;

            #region ALL
            if (v_index == 0)  //All
            {
                try
                {
                    DataProcess<EDI_Orders> v_Da = new DataProcess<EDI_Orders>();
                    DateTime v_fromDate = v_Da.GetDate().AddDays(-1);
                    DateTime v_toDate = v_Da.GetDate().AddDays(+2);
                    DataProcess<Customers> v_Cus = new DataProcess<Customers>();
                    EDI_Orders v_Order = new EDI_Orders();
                    m_BindingListOrders.Clear();
                    List<EDI_Orders> v_List = null;
                    if (this.ediIDOrderFind > 0)
                    {
                        v_List = v_Da.Select(a => a.EDI_OrderID == this.ediIDOrderFind).OrderBy(o => o.EDI_OrderID).ToList();
                    }
                    else
                    {
                        // v_List = v_Da.Select(a => a.OrderDate >= v_fromDate && a.OrderDate <= v_toDate).OrderBy(o => o.EDI_OrderID).ToList();
                        v_List = v_Da.Executing($"SP_LoadEDIOrderByWhere @FromDate='{v_fromDate.ToString("yyyy-MM-dd")}',@ToDate='{v_toDate.ToString("yyyy-MM-dd")}',@StoreID={AppSetting.CurrentUser.StoreID}").ToList();
                    }

                    m_BindingListOrders = new BindingList<EDI_Orders>(v_List);

                    if (m_BindingListOrders.Count == 1)
                    {
                        isAddNewRecord = true;
                        m_BindingListOrders.Add(m_BindingListOrders[0]);
                    }
                    this.dataNavigator_EDIOrders.DataSource = m_BindingListOrders;

                    this.dataNavigator_EDIOrders.Position = m_BindingListOrders.Count - 1;
                    radioGroup_DispatchType.SelectedIndex = 0;

                    if (m_BindingListOrders.Count <= 0)
                    {
                        LoadData_EDI_OrderDetail(0);

                        txtEdit_CustomerName.EditValue = "";
                        txtEdit_CustomerNumber.EditValue = "";
                    }

                    int v_CustomerID = 0;
                    try
                    {
                        v_CustomerID = m_BindingListOrders[this.dataNavigator_EDIOrders.Position].CustomerID;
                        if (v_CustomerID == 24)
                        {
                            radioGroup_DispatchType.SelectedIndex = 5;
                        }
                        else
                        {
                            radioGroup_DispatchType.SelectedIndex = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        log.Error("==> Error is unexpected");
                        log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                    }
                }
                catch (Exception ex)
                {
                    log.Error("==> Error is unexpected");
                    log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                }
            }

            #endregion ALL

            #region Me
            else if (v_index == 1)//Me
            {
                try
                {
                    DataProcess<EDI_Orders> v_Da = new DataProcess<EDI_Orders>();
                    //DateTime v_fromDate = v_Da.GetDate().AddDays(-93);
                    DateTime v_fromDate = v_Da.GetDate().AddDays(-1);
                    DateTime v_toDate = v_Da.GetDate().AddDays(+2);

                    m_BindingListOrders.Clear();
                    List<EDI_Orders> v_List = v_Da.Select(a => a.OrderDate >= v_fromDate && a.OrderDate <= v_toDate && a.CreatedBy == m_userName).OrderBy(o => o.EDI_OrderID).ToList();

                    foreach (EDI_Orders x in v_List)
                    {
                        m_BindingListOrders.Add(x);
                    }

                    this.dataNavigator_EDIOrders.DataSource = m_BindingListOrders;
                    this.dataNavigator_EDIOrders.Position = m_BindingListOrders.Count - 1;

                    if (m_BindingListOrders.Count <= 0)
                    {
                        LoadData_EDI_OrderDetail(0);

                        txtEdit_CustomerName.EditValue = "";
                        txtEdit_CustomerNumber.EditValue = "";
                    }
                }
                catch (Exception ex)
                {
                    log.Error("==> Error is unexpected");
                    log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);

                    Wait.Close();
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Wait.Close();
                }
            }

            #endregion Me

            #region Me_0
            else if (v_index == 2)//Me_0
            {
                try
                {
                    Wait.Start(this);

                    DataProcess<EDI_Orders> v_Da = new DataProcess<EDI_Orders>();
                    DateTime v_fromDate = v_Da.GetDate().AddDays(-1);
                    DateTime v_toDate = v_Da.GetDate().AddDays(+2);

                    m_BindingListOrders.Clear();
                    List<EDI_Orders> v_List = v_Da.Select(a => a.ProcessingStatus <= 1 && a.CreatedBy == m_userName && a.OrderDate >= v_fromDate && a.OrderDate <= v_toDate).OrderBy(o => o.EDI_OrderID).ToList();
                    //List<EDI_Orders> v_List = v_Da.Select(a => a.ProcessingStatus <= 1 && a.CreatedBy == m_userName ).OrderBy(o => o.EDI_OrderID).ToList();

                    foreach (EDI_Orders x in v_List)
                    {
                        m_BindingListOrders.Add(x);
                    }

                    this.dataNavigator_EDIOrders.DataSource = m_BindingListOrders;
                    this.dataNavigator_EDIOrders.Position = m_BindingListOrders.Count - 1;

                    if (m_BindingListOrders.Count <= 0)
                    {
                        LoadData_EDI_OrderDetail(0);

                        txtEdit_CustomerName.EditValue = "";
                        txtEdit_CustomerNumber.EditValue = "";
                    }
                }
                catch (Exception ex)
                {
                    log.Error("==> Error is unexpected");
                    log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                    Wait.Close();
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Wait.Close();
                }
            }
            #endregion Me_0

            //#region Customer
            //else if (v_index == 3)//Customer
            //{
            //    int v_CustomerID = 0;

            //    try
            //    {
            //        v_CustomerID = Convert.ToInt32(searchLookUpEdit_CustomerID.EditValue);
            //    }
            //    catch (Exception ex)
            //    {
            //        log.Error("==> Error is unexpected");
            //        log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
            //    }

            //    try
            //    {
            //        Wait.Start(this);
            //        DataProcess<EDI_Orders> v_Da = new DataProcess<EDI_Orders>();
            //        DateTime v_fromDate = v_Da.GetDate().AddDays(-365);

            //        m_BindingListOrders.Clear();
            //        List<EDI_Orders> v_List = v_Da.Select(a => a.OrderDate >= v_fromDate && a.CustomerID == v_CustomerID).OrderBy(o => o.EDI_OrderID).ToList();

            //        foreach (EDI_Orders x in v_List)
            //        {
            //            m_BindingListOrders.Add(x);
            //        }

            //        this.dataNavigator_EDIOrders.DataSource = m_BindingListOrders;
            //    }
            //    catch (Exception ex)
            //    {
            //        log.Error("==> Error is unexpected");
            //        log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
            //        Wait.Close();
            //        XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //    finally
            //    {
            //        Wait.Close();
            //    }

            //}
            //#endregion Customer

            #region default
            else
            {
                try
                {
                    Wait.Start(this);

                    DataProcess<EDI_Orders> v_Da = new DataProcess<EDI_Orders>();
                    //DateTime v_fromDate = v_Da.GetDate().AddDays(-7);
                    DateTime v_fromDate = v_Da.GetDate().AddDays(-2);

                    m_BindingListOrders.Clear();
                    List<EDI_Orders> v_List = null;
                    if (this.ediIDOrderFind > 0)
                    {
                        v_List = v_Da.Select(a => a.EDI_OrderID == this.ediIDOrderFind).OrderBy(o => o.EDI_OrderID).ToList();
                    }
                    else
                    {
                        v_List = v_Da.Select(a => a.OrderDate >= v_fromDate).OrderBy(o => o.EDI_OrderID).ToList();
                    }

                    foreach (EDI_Orders x in v_List)
                    {
                        m_BindingListOrders.Add(x);
                    }

                    this.dataNavigator_EDIOrders.DataSource = m_BindingListOrders;
                    this.dataNavigator_EDIOrders.Position = m_BindingListOrders.Count - 1;

                    if (m_BindingListOrders.Count <= 0)
                    {
                        LoadData_EDI_OrderDetail(0);

                        txtEdit_CustomerName.EditValue = "";
                        txtEdit_CustomerNumber.EditValue = "";
                    }
                }
                catch (Exception ex)
                {
                    log.Error("==> Error is unexpected");
                    log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);

                    Wait.Close();
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Wait.Close();
                }
            }
            #endregion default
        }
        void SetBindingControl_EDI_Orders(EDI_Orders currentOrder)
        {
            txtEdit_EDI_OrderID.EditValue = currentOrder.EDI_OrderID;
            txtEdit_CustomerNumber.EditValue = currentOrder.CustomerID;
            txtEdit_OrderDate.EditValue = currentOrder.OrderDate;
            txtEdit_CustomerOrderNumber.EditValue = currentOrder.CustomerOrderNumber;
            txtEdit_CustomerOrderNumber2.EditValue = currentOrder.CustomerOrderNumber2;
            txtEdit_CustomerClientCode.EditValue = currentOrder.CustomerClientCode;
            txtEdit_VehicleNumber.EditValue = currentOrder.VehicleNumber;
            spinEdit_TotalQuantity.EditValue = currentOrder.TotalQuantity;
            txtEdit_CreatedBy.EditValue = currentOrder.CreatedBy;
            txtEdit_CreatedTime.EditValue = currentOrder.CreatedTime;
            txtEdit_FileUploadedCode.EditValue = currentOrder.FileUploadedCode;
            btnEdit_ProcessingOrderNumber.EditValue = currentOrder.ProcessingOrderNumber;
            txtEdit_ProcessedBy.EditValue = currentOrder.ProcessedBy;
            txtEdit_ProcessingTime.EditValue = currentOrder.ProcessingTime;
            txtEdit_CustomerReference.EditValue = currentOrder.CustomerReference;
            txtEdit_MessageStatus.EditValue = currentOrder.ProcessingStatus;
            //lkeDispatchType.EditValue = currentEDI

        }
        void LoadData_EDI_OrderDetail(int i_EDI_OrderID)
        {
            try
            {
                gridControl_EDIDetail.DataSource = null;
                DataProcess<EDI_OrderDetails> v_DA = new DataProcess<EDI_OrderDetails>();
                IEnumerable<EDI_OrderDetails> lst = v_DA.Select(a => a.EDI_OrderID == i_EDI_OrderID);

                gridControl_EDIDetail.DataSource = lst;
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);

                MessageBox.Show(ex.Message, "Error is unexpected");
            }
        }
        //void LoadData2searchLookUpEdit_CustomerID()
        //{
        //    try
        //    {
        //        searchLookUpEdit_CustomerID.Properties.DataSource = (new DataProcess<STEDI_comboCustomerMainID_Result>()).Executing("STEDI_comboCustomerMainID @IsMain={0},@StoreID={1}", 1, AppSetting.StoreID).ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error("==> Error is unexpected");
        //        log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);

        //        searchLookUpEdit_CustomerID.Properties.DataSource = null;
        //    }
        //}

        #endregion LoadData

        #region Code Old

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
                    int _pID = (int)(e.Value);
                    if (_pID > 0)
                    {
                        Products _p = listProduct.FirstOrDefault(p => p.ProductID == _pID);
                        gridViewOrderDetail.SetFocusedRowCellValue(gridViewOrderDetail.Columns["ProductName"], _p.ProductName);

                        gridViewOrderDetail.SetFocusedRowCellValue(gridViewOrderDetail.Columns["ProductNumber"], _p.ProductNumber);

                        gridViewOrderDetail.SetFocusedRowCellValue(gridViewOrderDetail.Columns["ProductID"], _pID);
                        gridViewOrderDetail.SetFocusedRowCellValue(gridViewOrderDetail.Columns["WeightPerPackage"], _p.WeightPerPackage);
                        int _qty = Convert.ToInt32(gridViewOrderDetail.GetFocusedRowCellValue(gridViewOrderDetail.Columns["TotalPackages"]));
                        gridViewOrderDetail.SetFocusedRowCellValue(gridViewOrderDetail.Columns["TotalUnits"], _qty * _p.Inners);
                        gridViewOrderDetail.SetFocusedRowCellValue(gridViewOrderDetail.Columns["TotalWeight"], _qty * _p.WeightPerPackage);
                        gridViewOrderDetail.SetFocusedRowCellValue(gridViewOrderDetail.Columns["UserName"], m_userName);
                        string _remark = "";
                        if (gridViewOrderDetail.GetFocusedRowCellValue(gridViewOrderDetail.Columns["Remark"]) != null)
                            _remark = gridViewOrderDetail.GetFocusedRowCellValue(gridViewOrderDetail.Columns["Remark"]).ToString();
                        _remark = _remark.Replace("~Cân Gross!!!", "");
                        if (_p.GrossWeightPerPackage == null || _p.GrossWeightPerPackage == 0)
                        {
                            _remark += "~Cân Gross!!!";
                        }
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
        private void gridViewOrderDetail_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int _productID = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, gridViewOrderDetail.Columns["ProductID"]));
                int _qty = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, gridViewOrderDetail.Columns["TotalPackages"]));

                if (_productID <= 0)
                {
                    e.Valid = false;
                    view.SetColumnError(gridViewOrderDetail.Columns["ProductID"], "Select Product ID");
                }
                if (_qty <= 0)
                {
                    e.Valid = false;
                    view.SetColumnError(gridViewOrderDetail.Columns["TotalPackages"], "Qty > 0");
                }
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);

                e.Valid = false;
                XtraMessageBox.Show(ex.Message);
            }
        }
        private void gridViewOrderDetail_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            gridViewOrderDetail.PostEditor();
            gridViewOrderDetail.UpdateSummary();
        }
        private void gridViewOrderDetail_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }
        private void gridViewOrderDetail_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (isUpdate)
                {
                    if (gridViewOrderDetail.GetFocusedRowCellValue(gridViewOrderDetail.Columns["ProductID"]) == null)
                    {
                        //gridViewOrderDetail.FocusedColumn = gridViewOrderDetail.Columns["ProductID"];
                        gridViewOrderDetail.FocusedColumn = gridColumnProductID;
                        gridViewOrderDetail.ShowEditor();
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
            }
        }
        private void gridViewOrderDetail_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (isUpdate)
            {
                GridView view = sender as GridView;
                if (view.FocusedColumn.FieldName == "ProductID")
                    if (objSelected != null && objSelected.ReceivingOrderDetailID > 0)
                        e.Cancel = true;
            }
        }
        private void gridViewOrderDetail_DoubleClick(object sender, EventArgs e)
        {
            GridHitInfo hi = gridViewOrderDetail.CalcHitInfo(gridControl_EDIDetail.PointToClient(MousePosition));
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
                                    frm_MSS_Products frmProduct = frm_MSS_Products.Instance;
                                    frmProduct.ProductIDLookup = _pID;
                                    if (!frmProduct.Enabled) return;
                                    frmProduct.ShowDialog();
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
                        try
                        {
                            //if (new frm_MSS_ChangeProduct(Convert.ToInt32(lookUpEditCustomerID.EditValue), objSelected.ProductID, objSelected.ReceivingOrderDetailID, this.userName).ShowDialog() == DialogResult.OK)
                            {
                                LoadData_EDI_OrderDetail(Convert.ToInt32(txtEdit_EDI_OrderID.EditValue));
                            }
                        }
                        catch (Exception ex)
                        {
                            log.Error("==> Error is unexpected");
                            log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                        }
                        break;
                    case "gridColumnHold":
                        XtraMessageBox.Show("Show dialog Hold Status for this Product ID.\r\nComing soon...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case "gridColumnStatus":
                        byte status = Convert.ToByte(gridViewOrderDetail.GetRowCellValue(gridViewOrderDetail.FocusedRowHandle, gridViewOrderDetail.Columns["Status"]));
                        if (status == 1)
                            if (XtraMessageBox.Show("Are you sure to confirm this Receiving Product ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                TransactionDAC trans = new TransactionDAC();

                                //int transactionID = Convert.ToInt32(gridViewOrderDetail.GetRowCellValue(gridViewOrderDetail.FocusedRowHandle, gridViewOrderDetail.Columns["TransactionID"]));
                                trans.STConfirmOne((int)objSelected.TransactionID, 1, this.m_userName);
                                gridViewOrderDetail.SetFocusedRowCellValue(gridViewOrderDetail.Columns["Status"], 2);
                            }
                        break;
                    case "gridColumnTotalPackages":
                    case "gridColumnRemark":
                        break;
                    case "gridColumnPallets":
                        break;
                }
            }
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
                                //trans.STTransactionInsertAll(Convert.ToInt32(textEditOrderID.EditValue), textEditOrderID.Text.Trim(), this.userName, lookUpEditCustomerID.Text.Trim());
                                gridControl_EDIDetail.DataSource = m_BindingListOrderDetai;

                                break;
                            case DialogResult.No:
                                trans.STTransactionDeleteAll(Convert.ToInt32(txtEdit_EDI_OrderID.EditValue), false, this.m_userName);
                                gridControl_EDIDetail.DataSource = m_BindingListOrderDetai;

                                break;
                        }
                        LoadData_EDI_OrderDetail(Convert.ToInt32(txtEdit_EDI_OrderID.EditValue));
                    }
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
                ReceivingOrdersDA rOc = new ReceivingOrdersDA();
                //rOc.STReceivingPalletCartonWeightingChecking(Convert.ToInt32(txtEdit_EDI_OrderID.EditValue), 0);

            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
            }
        }


        #endregion Code Old

        private void Btn_WM_NewEdiOrder_Click(object sender, EventArgs e)
        {
            int customerIDSelected = 0;
            if (this.dataNavigator_EDIOrders.Position > -1) customerIDSelected = m_BindingListOrders[this.dataNavigator_EDIOrders.Position].CustomerID;
            UI.WarehouseManagement.frm_WM_EDIImportFiles frm = new frm_WM_EDIImportFiles(customerIDSelected);
            if (!frm.Enabled) return;
            frm.MyGetEDI_Order = new frm_WM_EDIImportFiles.GetEDI_Orders(GetEDI_Orders);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
            LoadData_EDI_Order();
        }

        private void btn_ViewList_Click(object sender, EventArgs e)
        {
            frm_WM_EDIOrdersViewList frm = new frm_WM_EDIOrdersViewList();
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
        }

        private void mnu_btn_Copy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string productNumberSelected = this.gridViewOrderDetail.GetFocusedDisplayText();
            if (string.IsNullOrEmpty(productNumberSelected)) return;
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

        private void btn_ProcessReference_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng không được phép thực hiện. Vui lòng sử dụng form EDI Order List New");
            return;
            DataProcess<EDI_Orders> v_Da = new DataProcess<EDI_Orders>();
            DateTime v_fromDate = v_Da.GetDate().AddDays(-7);
            DateTime v_toDate = v_Da.GetDate().AddDays(+7);

            DateTime v_OrderDate = DateTime.Now;

            try
            {
                v_OrderDate = Convert.ToDateTime(txtEdit_OrderDate.EditValue);
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
            }

            if ((v_OrderDate > v_toDate) || (v_OrderDate < v_fromDate))
            {
                XtraMessageBox.Show("Order date is not correct!!!", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEdit_OrderDate.Focus();
                return;
            }

            if (Convert.ToInt32(currentEDI.ProcessingStatus).Equals(1))
            {
                int v_EDIOrderID = 0;

                try
                {
                    v_EDIOrderID = Convert.ToInt32(txtEdit_EDI_OrderID.EditValue);
                }
                catch (Exception ex)
                {
                    log.Error("==> Error is unexpected");
                    log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                }

                int v_Index = this.dataNavigator_EDIOrders.Position;

                if (radioGroup_OrderType.EditValue.Equals(3))
                {
                    int v_CustomerID = 0;
                    string v_CustomerClientCode = "";
                    string v_CustomerClientName = "";
                    string v_CustomerClientAddress = "";

                    v_CustomerClientCode = txtEdit_CustomerClientCode.Text;
                    v_CustomerClientName = this.m_BindingListOrders[this.dataNavigator_EDIOrders.Position].Client_Name;
                    v_CustomerClientAddress = this.m_BindingListOrders[this.dataNavigator_EDIOrders.Position].Address;

                    try
                    {
                        v_CustomerID = Convert.ToInt32(txtEdit_CustomerNumber.EditValue);
                    }
                    catch (Exception ex)
                    {
                        log.Error("==> Error is unexpected");
                        log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                    }

                    //if (v_CustomerID.Equals(920) || v_CustomerID.Equals(919)) //' Chi moi ap dung cho VinMart
                    //{
                    DA.DataProcess<CustomerClients> v_DaCus = new DataProcess<CustomerClients>();
                    IList<CustomerClients> v_ListCusClient = v_DaCus.Select(c => c.CustomerClientCode == v_CustomerClientCode).ToList();
                    if (v_ListCusClient.Count <= 0)
                    {
                        if (XtraMessageBox.Show("This Client Code(Store) was not created, do you want to create now?", "WMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            return;
                        }
                        else
                        {
                            DA.Warehouse.EDIOrdersDA v_daEDI = new DA.Warehouse.EDIOrdersDA();
                            ObjectParameter v_newCustomerClientID = new ObjectParameter("newCustomerClientID", 0);
                            int result = v_daEDI.STCustomerClientsInsert(v_CustomerID, v_CustomerClientCode, v_CustomerClientName, v_CustomerClientAddress, this.m_userName, v_newCustomerClientID);

                            int v_newCustomerClientID_OutPut = 0;
                            try
                            {
                                v_newCustomerClientID_OutPut = Convert.ToInt32(v_newCustomerClientID.Value);
                            }
                            catch (Exception ex)
                            {
                                log.Error("==> Error is unexpected");
                                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                            }

                            UI.MasterSystemSetup.frm_MSS_CustomerClients frm_Cus = new frm_MSS_CustomerClients();
                            frm_Cus.StartPosition = FormStartPosition.CenterScreen;
                            frm_Cus.ShowInTaskbar = false;
                            frm_Cus.Show(this);
                        }
                    }

                    int ediType = Convert.ToInt32(radioGroup_DispatchType.EditValue);
                    ediType = 10;
                    //if (ediType.Equals(1))
                    //{
                    //    DA.Warehouse.EDIOrdersDA v_DaStandard = new EDIOrdersDA();
                    //    int v_Ret = v_DaStandard.STEDI_ProcessDispatchingOrder_Main(v_EDIOrderID, this.m_userName, 1);

                    //}
                    //else if (ediType.Equals(2))
                    //{
                    //    DA.Warehouse.EDIOrdersDA v_DaExp = new EDIOrdersDA();
                    //    int v_Ret = v_DaExp.STEDI_ProcessDispatchingOrder_Main_PickSequence(v_EDIOrderID, this.m_userName);
                    //}
                    //else if (ediType.Equals(5))
                    //{
                    //    DA.Warehouse.EDIOrdersDA v_DaTheLongLife = new EDIOrdersDA();
                    //    int v_Ret = v_DaTheLongLife.STEDI_ProcessDispatchingOrder_Main(v_EDIOrderID, this.m_userName, 5);
                    //}
                    //else if (ediType.Equals(7))
                    //{
                    //    //the shelf life 1/2, 2/3
                    DA.Warehouse.EDIOrdersDA v_DaTheLongLife = new EDIOrdersDA();
                    int v_Ret = v_DaTheLongLife.STEDI_ProcessDispatchingOrder_Main(v_EDIOrderID, this.m_userName, 10);
                    //}

                    LoadData_EDI_Order();

                    this.dataNavigator_EDIOrders.Position = v_Index;
                    string orderNumber = this.m_BindingListOrders[v_Index].ProcessingOrderNumber;
                    int orderID = 0;
                    if (string.IsNullOrEmpty(orderNumber) == false && orderNumber.Length > 3)
                    {
                        orderID = Convert.ToInt32(orderNumber.Substring(3, orderNumber.Length - 3));
                    }


                    var frmDispatching = frm_WM_DispatchingOrders.GetInstance(orderID);
                    if (frmDispatching.Visible)
                    {
                        frmDispatching.ReloadData();
                    }
                    frmDispatching.StartPosition = FormStartPosition.CenterScreen;
                    frmDispatching.ShowInTaskbar = true;
                    frmDispatching.Show();

                }
                //RO
                //else if (radioGroup_OrderType.EditValue.Equals(2))
                //{
                //    DA.Warehouse.EDIOrdersDA v_DaRO = new EDIOrdersDA();
                //    int v_Ret = v_DaRO.STEDI_ProcessReceivingOrder(v_EDIOrderID, this.m_userName);

                //    LoadData_EDI_Order();

                //    this.dataNavigator_EDIOrders.Position = v_Index;
                //    string orderNumber = this.m_BindingListOrders[v_Index].ProcessingOrderNumber;
                //    int orderID = 0;
                //    if (string.IsNullOrEmpty(orderNumber) == false && orderNumber.Length > 3)
                //    {
                //        orderID = Convert.ToInt32(orderNumber.Substring(3, orderNumber.Length - 3));
                //    }
                //    UI.WarehouseManagement.frm_WM_ReceivingOrders frm = frm_WM_ReceivingOrders.Instance;
                //    frm.ReceivingOrderIDFind = orderID;
                //    frm.StartPosition = FormStartPosition.CenterScreen;
                //    frm.ShowInTaskbar = false;
                //    frm.Show();
                //}
            }
        }

        private void btn_ProcessReference_new_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng không được phép thực hiện. Vui lòng sử dụng form EDI Order List New");
            return;
            DataProcess<EDI_Orders> v_Da = new DataProcess<EDI_Orders>();
            DateTime v_fromDate = v_Da.GetDate().AddDays(-7);
            DateTime v_toDate = v_Da.GetDate().AddDays(+7);

            DateTime v_OrderDate = DateTime.Now;

            try
            {
                v_OrderDate = Convert.ToDateTime(txtEdit_OrderDate.EditValue);
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
            }

            if ((v_OrderDate > v_toDate) || (v_OrderDate < v_fromDate))
            {
                XtraMessageBox.Show("Order date is not correct!!!", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEdit_OrderDate.Focus();
                return;
            }

            if (Convert.ToInt32(currentEDI.ProcessingStatus).Equals(1))
            {
                int v_EDIOrderID = 0;

                try
                {
                    v_EDIOrderID = Convert.ToInt32(txtEdit_EDI_OrderID.EditValue);
                }
                catch (Exception ex)
                {
                    log.Error("==> Error is unexpected");
                    log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                }

                int v_Index = this.dataNavigator_EDIOrders.Position;

                if (radioGroup_OrderType.EditValue.Equals(3))
                {
                    int v_CustomerID = 0;
                    string v_CustomerClientCode = "";
                    string v_CustomerClientName = "";
                    string v_CustomerClientAddress = "";

                    v_CustomerClientCode = txtEdit_CustomerClientCode.Text;
                    v_CustomerClientName = this.m_BindingListOrders[this.dataNavigator_EDIOrders.Position].Client_Name;
                    v_CustomerClientAddress = this.m_BindingListOrders[this.dataNavigator_EDIOrders.Position].Address;

                    try
                    {
                        v_CustomerID = Convert.ToInt32(txtEdit_CustomerNumber.EditValue);
                    }
                    catch (Exception ex)
                    {
                        log.Error("==> Error is unexpected");
                        log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                    }

                    //if (v_CustomerID.Equals(920) || v_CustomerID.Equals(919)) //' Chi moi ap dung cho VinMart
                    //{
                    DA.DataProcess<CustomerClients> v_DaCus = new DataProcess<CustomerClients>();
                    IList<CustomerClients> v_ListCusClient = v_DaCus.Select(c => c.CustomerClientCode == v_CustomerClientCode).ToList();
                    if (v_ListCusClient.Count <= 0)
                    {
                        if (XtraMessageBox.Show("This Client Code(Store) was not created, do you want to create now?", "WMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            return;
                        }
                        else
                        {
                            DA.Warehouse.EDIOrdersDA v_daEDI = new DA.Warehouse.EDIOrdersDA();
                            ObjectParameter v_newCustomerClientID = new ObjectParameter("newCustomerClientID", 0);
                            int result = v_daEDI.STCustomerClientsInsert(v_CustomerID, v_CustomerClientCode, v_CustomerClientName, v_CustomerClientAddress, this.m_userName, v_newCustomerClientID);

                            int v_newCustomerClientID_OutPut = 0;
                            try
                            {
                                v_newCustomerClientID_OutPut = Convert.ToInt32(v_newCustomerClientID.Value);
                            }
                            catch (Exception ex)
                            {
                                log.Error("==> Error is unexpected");
                                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                            }

                            UI.MasterSystemSetup.frm_MSS_CustomerClients frm_Cus = new frm_MSS_CustomerClients();
                            frm_Cus.StartPosition = FormStartPosition.CenterScreen;
                            frm_Cus.ShowInTaskbar = false;
                            frm_Cus.Show(this);
                        }
                    }

                    DataProcess<object> dataProcess = new DataProcess<object>();
                    dataProcess.ExecuteNoQuery("STEDI_ProcessDispatchingOrder_Reference_NotMain " + v_EDIOrderID + ",'" + this.m_userName + "'");

                    LoadData_EDI_Order();

                    this.dataNavigator_EDIOrders.Position = v_Index;
                    string orderNumber = this.m_BindingListOrders[v_Index].ProcessingOrderNumber;
                    int orderID = 0;
                    if (string.IsNullOrEmpty(orderNumber) == false && orderNumber.Length > 3)
                    {
                        orderID = Convert.ToInt32(orderNumber.Substring(3, orderNumber.Length - 3));
                    }


                    var frmDispatching = frm_WM_DispatchingOrders.GetInstance(orderID);
                    if (frmDispatching.Visible)
                    {
                        frmDispatching.ReloadData();
                    }
                    frmDispatching.StartPosition = FormStartPosition.CenterScreen;
                    frmDispatching.ShowInTaskbar = true;
                    frmDispatching.Show();

                }

            }
        }

        private void btn_ProcessAllNew_Click(object sender, EventArgs e)
        {
            DataProcess<EDI_Orders> v_Da = new DataProcess<EDI_Orders>();
            DateTime v_fromDate = v_Da.GetDate().AddDays(-7);
            DateTime v_toDate = v_Da.GetDate().AddDays(+7);
            int v_CustomerID = 0;
            int v_CustomerMainID = 0;
            string v_CustomerClientCode = "";
            string v_CustomerClientName = "";
            string v_CustomerClientAddress = "";
            DateTime v_OrderDate = DateTime.Now;

            try
            {
                v_OrderDate = Convert.ToDateTime(txtEdit_OrderDate.EditValue);
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
            }

            if ((v_OrderDate > v_toDate) || (v_OrderDate < v_fromDate))
            {
                XtraMessageBox.Show("Order date is not correct!!!", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEdit_OrderDate.Focus();
                return;
            }

            if (!Convert.ToInt32(currentEDI.ProcessingStatus).Equals(1))
                return;

            int v_EDIOrderID = 0;

            try
            {
                v_EDIOrderID = Convert.ToInt32(txtEdit_EDI_OrderID.EditValue);
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
            }

            int v_Index = this.dataNavigator_EDIOrders.Position;


            switch (radioGroup_OrderType.EditValue)
            {
                case 2: //RO
                    //DA.DataProcess<object> DP = new DataProcess<object>();
                    //int v_Ret = DP.ExecuteNoQuery("STEDI_ProcessReceivingOrderMain " + v_EDIOrderID + ", '" + AppSetting.CurrentUser.LoginName + "'");
                    DA.DataProcess<object> DP = new DataProcess<object>();
                    int v_Ret;
                    if (this.checkMainCustomer.Checked)
                        v_Ret = DP.ExecuteNoQuery("STEDI_ProcessReceivingOrderMain " + v_EDIOrderID + ", '" + AppSetting.CurrentUser.LoginName + "'");
                    else
                        v_Ret = DP.ExecuteNoQuery("STEDI_ProcessReceivingOrder_1Account " + v_EDIOrderID + ", '" + AppSetting.CurrentUser.LoginName + "'");
                    break;

                case 4: //PSC
                    DA.Warehouse.EDIOrdersDA v_DaRO = new EDIOrdersDA();
                    int v_Ret2 = v_DaRO.STEDI_ProcessReceivingOrder(v_EDIOrderID, AppSetting.CurrentUser.LoginName);
                    break;

                case 3: //DO
                        //Check if the Order requires CustomerClients ? If Not Create Customer Clients method 16 or 17
                    int dm = Convert.ToInt32(this.lkeDispatchType.EditValue);
                    if ((dm == 16 || dm == 17) && this.txtEdit_CustomerClientCode.Text != "")
                    {
                        Customers cus = AppSetting.CustomerList.Where(c => c.CustomerID == v_CustomerID).FirstOrDefault();
                        v_CustomerMainID = cus.CustomerMainID;
                        DA.DataProcess<CustomerClients> v_DaCus = new DataProcess<CustomerClients>();
                        IList<CustomerClients> v_ListCusClient = v_DaCus.Select(c => c.CustomerClientCode == v_CustomerClientCode && c.CustomerID == v_CustomerMainID).ToList();
                        if (v_ListCusClient.Count <= 0)
                        {
                            v_CustomerClientName = "NEW - Client Name - " + v_CustomerClientCode;
                            v_CustomerClientAddress = "NEW - Client Address - " + v_CustomerClientCode;
                            DA.Warehouse.EDIOrdersDA v_daEDI = new DA.Warehouse.EDIOrdersDA();
                            ObjectParameter v_newCustomerClientID = new ObjectParameter("newCustomerClientID", 0);
                            int result = v_daEDI.STCustomerClientsInsert(v_CustomerID, v_CustomerClientCode, v_CustomerClientName, v_CustomerClientAddress, AppSetting.CurrentUser.LoginName, v_newCustomerClientID);
                            if (result < 0)
                            {
                                MessageBox.Show("Import / Create New Customer Client Failed", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    DA.DataProcess<object> DP2 = new DataProcess<object>();
                    int resultProcess = DP2.ExecuteNoQuery("STEDI_ProcessDispatchingOrder_Method " + v_EDIOrderID + ",'" + AppSetting.CurrentUser.LoginName + "'," +
                    this.lkeDispatchType.EditValue + "," + this.checkMainCustomer.EditValue);

                    break;
            }
            LoadData_EDI_OrderDetail(Convert.ToInt32(txtEdit_EDI_OrderID.EditValue));
        }

        private void btn_ProcessAllExtent_Click(object sender, EventArgs e)
        {
            DataProcess<EDI_Orders> v_Da = new DataProcess<EDI_Orders>();
            DateTime v_fromDate = v_Da.GetDate().AddDays(-7);
            DateTime v_toDate = v_Da.GetDate().AddDays(+7);
            int v_CustomerID = 0;
            int v_CustomerMainID = 0;
            string v_CustomerClientCode = "";
            string v_CustomerClientName = "";
            string v_CustomerClientAddress = "";
            DateTime v_OrderDate = DateTime.Now;

            try
            {
                v_OrderDate = Convert.ToDateTime(txtEdit_OrderDate.EditValue);
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
            }

            if ((v_OrderDate > v_toDate) || (v_OrderDate < v_fromDate))
            {
                XtraMessageBox.Show("Order date is not correct!!!", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEdit_OrderDate.Focus();
                return;
            }

            if (!Convert.ToInt32(currentEDI.ProcessingStatus).Equals(1))
                return;

            int v_EDIOrderID = 0;

            try
            {
                v_EDIOrderID = Convert.ToInt32(txtEdit_EDI_OrderID.EditValue);
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
            }

            int v_Index = this.dataNavigator_EDIOrders.Position;

            v_CustomerID = m_BindingListOrders[this.dataNavigator_EDIOrders.Position].CustomerID;
            try
            {
                switch (radioGroup_OrderType.EditValue)
                {


                    case 3: //DO
                            //Check if the Order requires CustomerClients ? If Not Create Customer Clients method 16 or 17
                        int dm = Convert.ToInt32(this.lkeDispatchType.EditValue);
                        if ((dm == 16 || dm == 17) && this.txtEdit_CustomerClientCode.Text != "")
                        {
                            Customers cus = AppSetting.CustomerList.Where(c => c.CustomerID == v_CustomerID).FirstOrDefault();
                            v_CustomerMainID = cus.CustomerMainID;
                            DA.DataProcess<CustomerClients> v_DaCus = new DataProcess<CustomerClients>();
                            IList<CustomerClients> v_ListCusClient = v_DaCus.Select(c => c.CustomerClientCode == v_CustomerClientCode && c.CustomerID == v_CustomerMainID).ToList();
                            if (v_ListCusClient.Count <= 0)
                            {
                                v_CustomerClientName = "NEW - Client Name - " + v_CustomerClientCode;
                                v_CustomerClientAddress = "NEW - Client Address - " + v_CustomerClientCode;
                                DA.Warehouse.EDIOrdersDA v_daEDI = new DA.Warehouse.EDIOrdersDA();
                                ObjectParameter v_newCustomerClientID = new ObjectParameter("newCustomerClientID", 0);
                                int result = v_daEDI.STCustomerClientsInsert(v_CustomerID, v_CustomerClientCode, v_CustomerClientName, v_CustomerClientAddress, AppSetting.CurrentUser.LoginName, v_newCustomerClientID);
                                if (result < 0)
                                {
                                    MessageBox.Show("Import / Create New Customer Client Failed", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }

                        Customers cus2 = AppSetting.CustomerList.Where(c => c.CustomerID == v_CustomerID).FirstOrDefault();

                        DA.DataProcess<object> DP2 = new DataProcess<object>();
                        int resultProcess = DP2.ExecuteNoQuery("STEDI_ProcessDispatchingOrder_MethodExtent " + v_EDIOrderID + ",'" + AppSetting.CurrentUser.LoginName + "'," +
                        cus2.CustomerDispatchType + "," + this.checkMainCustomer.EditValue);
                        XtraMessageBox.Show("Success", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        break;
                }
                LoadData_EDI_OrderDetail(Convert.ToInt32(txtEdit_EDI_OrderID.EditValue));
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error Contact IT!!!", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
            }
          
        }
    }
}
