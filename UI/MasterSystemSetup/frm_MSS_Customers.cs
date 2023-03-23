using Common.Controls;
using Common.Process;
using DA;
using DA.Master;
using DevExpress.XtraEditors;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UI.APIs;
using UI.Helper;
using UI.ReportForm;
using UI.StockTake;
using UI.WarehouseManagement;

namespace UI.MasterSystemSetup
{
    public partial class frm_MSS_Customers : frmBaseForm
    {
        // Declare log
        private static readonly ILog log = LogManager.GetLogger(typeof(frm_MSS_Customers));
        private Customers _currentCustomer;
        private DataProcess<CustomerContacts> _contactData;
        private DataProcess<CustomerRequirements> _requirementData;
        private DataProcess<CustomerClients> _clientData;
        private DataProcess<ViewqryComboCustomerID> _qryComboCustomerData;
        private DataProcess<STcomboCustomerID_Result> _stComboCustomerID;
        private DataProcess<tmpProductRemains> _productRemainsData;
        private CustomerDA _customerData;
        private bool _isStop;
        private bool _isFirstLoaded;
        private string oldInitial = string.Empty;
        private APIProcess api = null;
        private Stores currentStore = null;

        private urc_MSS_CustomerRequirements urcRequirement = null;
        private urc_MSS_ContactDetails urcContract = null;
        private urc_MSS_CustomerClients urcClient = null;
        private urc_MSS_CustomerEvent urcEvent = null;
        private urc_MSS_SubCustomers urcSubCustomer = null;
        private urc_MSS_CustomerSuppliers urcSupplier = null;
        private urc_MSS_CustomerRequirementTiles urcRTiles = null;

        /// <summary>
        /// Declare customer instance form
        /// </summary>
        private static readonly frm_MSS_Customers instance = new frm_MSS_Customers();

        /// <summary>
        /// Get Customer Info instance form
        /// </summary>
        public static frm_MSS_Customers Instance
        {
            get
            {
                return instance;
            }
        }
        public Customers CurrentCustomers
        {
            set
            {
                this._currentCustomer = value;
                if (!this._isFirstLoaded)
                {

                    RefreshData();
                }
            }
        }

        protected frm_MSS_Customers()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.txtCustomerName.Font = new Font(txtCustomerName.Font, FontStyle.Bold);
            this.txtInitial.Font = new Font(txtInitial.Font, FontStyle.Bold);
            this.txtCustomerNumber.Font = new Font(txtCustomerNumber.Font, FontStyle.Bold);
            this.IsFixHeightScreen = false;
            this._currentCustomer = new Customers();
            this._contactData = new DataProcess<CustomerContacts>();
            this._requirementData = new DataProcess<CustomerRequirements>();
            this._clientData = new DataProcess<CustomerClients>();
            this._qryComboCustomerData = new DataProcess<ViewqryComboCustomerID>();
            this._stComboCustomerID = new DataProcess<STcomboCustomerID_Result>();
            this._productRemainsData = new DataProcess<tmpProductRemains>();
            this._customerData = new CustomerDA();
            this._isStop = false;
            this._isFirstLoaded = true;
        }

        private void frm_MSS_Customers_Load(object sender, System.EventArgs e)
        {
            try
            {
                Wait.Start(this);
                this.LoadAllAssigned();
                InitCategory();
                InitCustomerDispatchType();
                InitCustomerMainID();
                this.InitCustomerMainInvoiceID();
                InitStoreID();
                InitTaxGroup();
                InitType();
                LoadCustomerData();
                InitLocation();
                this.LoadCustomerRequirements();
                // Reload data for all tab pages
                this.LoadDataForCurrentTabPage();
                InitWarehouse();
                AddControlEvent();
                SetControlEnabled(true);

                this._isFirstLoaded = false;
                this.oldInitial = this.txtInitial.Text;
                Wait.Close();
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);

                Wait.Close();
                XtraMessageBox.Show(ex.Message, "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Dispose();
            }

        }

        /// <summary>
        /// Handles the Activated event of the frm_MSS_Customers control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void frm_MSS_Customers_Activated(object sender, System.EventArgs e)
        {
            // Reload data for all tab pages
            this.LoadDataForCurrentTabPage();
        }

        private void AddControlEvent()
        {
            this.btnBillingContract.ItemClick += btnBillingContract_ItemClick;
            this.btnProductGrouping.ItemClick += btnProductGrouping_ItemClick;
            this.btnProductList.ItemClick += btnProductList_ItemClick;
            this.btnEdit.ItemClick += btnEdit_ItemClick;
            this.btnStop2.ItemClick += btnStop_ItemClick;
            this.btnUpdate.ItemClick += btnUpdate_ItemClick;
            this.btnUpdateAndNew.ItemClick += btnUpdateAndNew_ItemClick;
            this.btnUpdateLocal.ItemClick += btnUpdateLocal_ItemClick;
            this.btnUpdateInfo.ItemClick += btnUpdateInfo_ItemClick;
            this.btnClose.ItemClick += btnClose_ItemClick;
            this.btnDelete2.ItemClick += btnDelete_ItemClick;
            this.btnCustomerMainID.Click += btnCustomerMainID_Click;
            this.xtraTabControl1.SelectedPageChanged += xtraTabControl1_SelectedPageChanged;
            this.btnStock.ItemClick += btnStock_ItemClick;
            this.btnScheduledReport.ItemClick += btnScheduledReport_ItemClick;
            this.txtCustomerName.Leave += txtCustomerName_Leave;
            this.txtInitial.KeyDown += TxtInitial_KeyDown;
        }

        private void TxtInitial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter) || e.KeyCode.Equals(Keys.Tab))
            {
                if (!this.txtInitial.IsModified) return;
                if (this.txtInitial.Text.Trim().Equals(this.oldInitial)) return;

                if (this.txtInitial.Text.Equals("ACC"))
                {
                    //XtraMessageBox.Show("Can not use ACC as initial ", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //this.txtInitial.Focus();
                    //return;
                }
                else
                {
                    if (this.txtInitial.Text.Length != 3)
                    {
                        XtraMessageBox.Show("Wrong Initial! Please re-enter", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.txtInitial.Focus();
                        return;
                    }
                }

                // Update customer number
                bool result = this.UpdateCustomerNumber();
                if (result)
                {
                    // Reload data local
                    this.btnUpdate_ItemClick(null, null);
                }
            }
        }

        private bool UpdateCustomerNumber()
        {
            var dl = MessageBox.Show("Changing initial will change all products of this Customers ! ", "TPWMS", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dl.Equals(DialogResult.Cancel))
            {
                this.txtInitial.Text = this.oldInitial;
                return false;
            }

            // Get customer number
            string customerNumber = this.txtInitial.Text + "-" + this._currentCustomer.CustomerID;

            // Apply new customer number into DB
            DataProcess<Customers> customerDA = new DataProcess<Customers>();
            int result = customerDA.ExecuteNoQuery("update tp SET tp.ProductNumber = '" + this.txtInitial.Text + "' + SUBSTRING ([ProductNumber],4,26) from Customers tc " +
                " INNER JOIN Products tp ON tc.CustomerID = tp.CustomerID WHERE tc.CustomerID =" + this._currentCustomer.CustomerID);
            if (result < 0)
            {
                this._currentCustomer.CustomerNumber = this.oldInitial + "-" + string.Format("{0:D4}", this._currentCustomer.CustomerID) ;
                this.txtCustomerNumber.Text = this._currentCustomer.CustomerNumber;
                return false;
            }
            else
            {
                // Update successful
                this._currentCustomer.CustomerNumber = this.txtInitial.Text + "-" + string.Format("{0:D4}", this._currentCustomer.CustomerID);
                this.txtCustomerNumber.Text = this._currentCustomer.CustomerNumber;
                this.txtInitial.IsModified = false;
                this.oldInitial = this.txtInitial.Text;
                return true;
            }

            return false;
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.F3)
            {
                frm_WM_Attachments.Instance.OrderNumber = this.txtCustomerNumber.Text;
                frm_WM_Attachments.Instance.CustomerID = this._currentCustomer.CustomerID;
                if (frm_WM_Attachments.Instance.Enabled)
                {
                    frm_WM_Attachments.Instance.ShowDialog();
                }
            }
            return base.ProcessDialogKey(keyData);
        }

        private void SetControlEnabled(bool isEnabled)
        {
            this.txtCustomerInvoiceName.Properties.ReadOnly = isEnabled;
            this.txtCustomerInvoiceTaxCode.Properties.ReadOnly = isEnabled;
            this.txtVATPercentage.Properties.ReadOnly = isEnabled;
            this.lkeAssigned.Properties.ReadOnly = isEnabled;
            this.txtCustomerName.Properties.ReadOnly = isEnabled;
            this.txtFax.Properties.ReadOnly = isEnabled;
            this.txtFax2.Properties.ReadOnly = isEnabled;
            this.txtHoldLimitWeight.Properties.ReadOnly = isEnabled;
            this.txtHoldMessage.Properties.ReadOnly = isEnabled;
            this.txtInitial.Properties.ReadOnly = isEnabled;
            this.txtPhone1.Properties.ReadOnly = isEnabled;
            this.txtPhone2.Properties.ReadOnly = isEnabled;
            this.mmeAddress.Properties.ReadOnly = isEnabled;
            this.mmeCustomerInvoiceAddress.Properties.ReadOnly = isEnabled;
            this.mmeEmail.Properties.ReadOnly = isEnabled;
            this.mmeEmailBilling.Properties.ReadOnly = isEnabled;
            this.txtInvoiceEmail.Properties.ReadOnly = isEnabled;
            this.lkeCategory.Properties.ReadOnly = isEnabled;
            this.lkeCustomerDispatchType.Properties.ReadOnly = isEnabled;
            this.lkeCustomerMainID.Properties.ReadOnly = isEnabled;
            this.lkeCustomerInvoiceMainID.Properties.ReadOnly = isEnabled;
            this.lkeStoreID.Properties.ReadOnly = isEnabled;
            this.cbxTaxGroup.Properties.ReadOnly = isEnabled;
            this.lkeCustomerTypes.Properties.ReadOnly = isEnabled;
            this.chkHold.Properties.ReadOnly = isEnabled;
            this.chkHomeLocationChange.Properties.ReadOnly = isEnabled;
            this.chkIsAllowEDI.Properties.ReadOnly = isEnabled;
            this.chkSendNote.Properties.ReadOnly = isEnabled;
            this.chkRequireClient.Properties.ReadOnly = isEnabled;
            this.checkIsBarcodeRequired.Properties.ReadOnly = isEnabled;
            this.textERPProductLength.Properties.ReadOnly = isEnabled;
            this.txtMainOnReport.Properties.ReadOnly = isEnabled;
            this.txtMainContract.Properties.ReadOnly = isEnabled;
            this.txtHomeLocation1.Properties.ReadOnly = isEnabled;
            this.txtHomeLocation2.Properties.ReadOnly = isEnabled;
            this.btnDelete2.Enabled = !isEnabled;
            this.btnUpdateInfo.Enabled = !isEnabled;
            this.btnUpdate.Enabled = !isEnabled;
            this.btnUpdateAndNew.Enabled = !isEnabled;
            this.lke_WarehouseID.Properties.ReadOnly = isEnabled;

            // User not department PKD,PKT
            if (!this.CheckUserAllowEdit())
            {
                this.txtInitial.Properties.ReadOnly = true;
                this.lkeStoreID.Properties.ReadOnly = true;
                this.lkeAssigned.Properties.ReadOnly = true;
                this.mmeAddress.Properties.ReadOnly = true;
                //this.lkeCustomerMainID.Properties.ReadOnly = true;
                this.lkeCustomerInvoiceMainID.Properties.ReadOnly = true;
                this.txtMainOnReport.Properties.ReadOnly = true;
                this.txtMainContract.Properties.ReadOnly = true;
                this.txtCustomerName.Properties.ReadOnly = true;
                this.txtCustomerInvoiceName.Properties.ReadOnly = true;
                this.txtCustomerInvoiceTaxCode.Properties.ReadOnly = true;
                this.mmeCustomerInvoiceAddress.Properties.ReadOnly = true;
                //this.txtInvoiceEmail.Properties.ReadOnly = true;
                this.lkeCustomerInvoiceMainID.Properties.ReadOnly = true;
                this.cbxTaxGroup.Properties.ReadOnly = true;
                this.txtVATPercentage.Properties.ReadOnly = true;
                this.lkeCategory.Properties.ReadOnly = true;
                this.lkeCustomerTypes.Properties.ReadOnly = true;
            }
        }

        #region LoadData
        private void LoadCustomerData()
        {
            BindingData();
            BindingLookUpControl();
        }

        private void LoadAllAssigned()
        {
            this.lkeAssigned.Properties.DataSource = FileProcess.LoadTable("STComboEmployeesBDDept");
            this.lkeAssigned.Properties.DisplayMember = "VietnamName";
            this.lkeAssigned.Properties.ValueMember = "EmployeeID";
        }

        private void InitWarehouse()
        {
            this.lke_WarehouseID.Properties.DataSource = FileProcess.LoadTable("SELECT WarehouseID, WarehouseDescription From Warehouses WHERE StoreID = " + AppSetting.StoreID);
            this.lke_WarehouseID.Properties.ValueMember = "WarehouseID";
            this.lke_WarehouseID.Properties.DisplayMember = "WarehouseDescription";
            this.lke_WarehouseID.ItemIndex = 0;
        }
        private void LoadSubCustomers()
        {
            if (this._currentCustomer.CustomerMainID == null) return;
            if (this.urcSubCustomer == null)
            {
                this.urcSubCustomer = new urc_MSS_SubCustomers((int)this._currentCustomer.CustomerMainID);
            }
            this.urcSubCustomer.CustomerMainID = (int)this._currentCustomer.CustomerMainID;
            this.urcSubCustomer.Parent = this.tabSubCustomers;
        }

        /// <summary>
        /// Loads the customer requirements.
        /// </summary>
        private void LoadCustomerRequirements()
        {
            if (this.urcRequirement == null)
            {
                this.urcRequirement = new urc_MSS_CustomerRequirements();
            }

            this.urcRequirement.CurrentCustomer = this._currentCustomer;
            this.urcRequirement.Parent = this.tabCustomerRequirement;
        }

        #region Binding Data to Navigator
        private void BindingData()
        {
            this.txtCustomerNumber.Text = this._currentCustomer.CustomerNumber;
            this.txtCustomerName.Text = this._currentCustomer.CustomerName;
            this.txtInitial.Text = this._currentCustomer.Initial;
            this.oldInitial = this.txtInitial.Text;
            this.mmeAddress.Text = this._currentCustomer.Address;
            this.txtPhone1.Text = this._currentCustomer.Phone1;
            this.txtPhone2.Text = this._currentCustomer.Phone2;
            this.txtFax.Text = this._currentCustomer.Fax;
            this.txtFax2.Text = this._currentCustomer.Fax2;
            this.txtCustomerInvoiceTaxCode.Text = this._currentCustomer.CustomerInvoiceTaxCode;
            this.txtVATPercentage.EditValue = this._currentCustomer.VATPercentage;
            this.lkeAssigned.EditValue = this._currentCustomer.CustomerAssignedTo;
            this.mmeEmail.Text = this._currentCustomer.Email;
            this.mmeEmailBilling.Text = this._currentCustomer.EmailBilling;
            this.txtInvoiceEmail.Text = this._currentCustomer.InvoiceSendEmail;
            this.txtHoldLimitWeight.Text = this._currentCustomer.HoldLimitWeight.ToString();
            this.txtHoldMessage.Text = this._currentCustomer.HoldMessage;
            this.txtCustomerInvoiceName.Text = this._currentCustomer.CustomerInvoiceName;
            this.mmeCustomerInvoiceAddress.Text = this._currentCustomer.CustomerInvoiceAddress;
            this.chkHold.EditValue = this._currentCustomer.Hold;
            this.chkSendNote.EditValue = this._currentCustomer.SendNote;
            this.chkIsAllowEDI.EditValue = this._currentCustomer.IsAllowEDI;
            this.chkHomeLocationChange.EditValue = this._currentCustomer.HomeLocationChange;
            this.lkeCustomerTypes.EditValue = this._currentCustomer.CustomerType;
            this.cbxTaxGroup.SelectedItem = this._currentCustomer.CustomerTaxGroup;
            this.checkIsBarcodeRequired.EditValue = this._currentCustomer.BarcodeScanRequire;
            this.textERPProductLength.EditValue = this._currentCustomer.ERPProductLength;
            this.txtMainOnReport.EditValue = this._currentCustomer.CustomerMainOnReport;
            this.txtMainContract.EditValue = this._currentCustomer.CustomerMainContractID;
            this.txtHomeLocation1.EditValue = this._currentCustomer.HomeLocation1;
            this.txtHomeLocation2.EditValue = this._currentCustomer.HomeLocation2;

            if (this._currentCustomer.DispatchingByClient == null)
            {
                this.chkRequireClient.Checked = false;
            }
            else
            {
                this.chkRequireClient.Checked = Convert.ToBoolean(this._currentCustomer.DispatchingByClient);
            }

            this._isStop = Convert.ToBoolean(this._currentCustomer.CustomerDiscontinued);
            if (this._currentCustomer.CustomerID > 0)
            {
                this.btnEdit.Enabled = !this._isStop;
            }
            else
            {
                this.btnEdit.Enabled = false;
                SetControlEnabled(false);
                SetGridEditable(true);
            }

            this.ChangeStyleStop();
        }

        private void BindingLookUpControl()
        {
            this.lkeCategory.EditValue = this._currentCustomer.CustomerCategory;
            this.lkeCustomerDispatchType.EditValue = this._currentCustomer.CustomerDispatchType;
            this.lkeCustomerMainID.EditValue = this._currentCustomer.CustomerMainID;
            this.lkeCustomerInvoiceMainID.EditValue = this._currentCustomer.CustomerMainInvoiceID;
            this.lkeStoreID.EditValue = this._currentCustomer.StoreID;
            this.lke_WarehouseID.EditValue = this._currentCustomer.WarehouseID;
        }
        #endregion

        #region Init LookUp and Combobox Data
        private void InitType()
        {
            var source = FileProcess.LoadTable("Select * from CustomerType");
            this.lkeCustomerTypes.Properties.DataSource = source;
        }

        private void InitTaxGroup()
        {
            var source = new List<string>();

            source.Add("Nông/thủy sản và thực phẩm");
            source.Add("Phụ gia thực phẩm");
            source.Add("Khác");

            this.cbxTaxGroup.Properties.Items.AddRange(source);
        }

        private void InitCategory()
        {
            DataProcess<CustomerCategories> categoryData = new DataProcess<CustomerCategories>();
            lkeCategory.Properties.DataSource = categoryData.Select();
            lkeCategory.Properties.ValueMember = "CustomerCategoryID";
            lkeCategory.Properties.DisplayMember = "CustomerCategoryDescription";
        }

        private void InitCustomerDispatchType()
        {
            //DataProcess<CustomerDispatchMethod> dispatchMethodData = new DataProcess<CustomerDispatchMethod>();
            this.lkeCustomerDispatchType.Properties.DataSource = FileProcess.LoadTable("ST_WMS_LoadCustomerDispatchMethod");
            this.lkeCustomerDispatchType.Properties.ValueMember = "CustomerDispatchMethodID";
            this.lkeCustomerDispatchType.Properties.DisplayMember = "Method";
        }

        private void InitCustomerMainID()
        {
            DataProcess<STcomboCustomerID_Result> customersData = new DataProcess<STcomboCustomerID_Result>();
            this.lkeCustomerMainID.Properties.DataSource = customersData.Executing("STcomboCustomerID @varStoreID={0}", 0);
            this.lkeCustomerMainID.Properties.ValueMember = "CustomerID";
            //this.lkeCustomerMainID.Properties.DisplayMember = "CustomerID";
            this.lkeCustomerMainID.Properties.DisplayMember = "CustomerNumber";
        }
        private void InitCustomerMainInvoiceID()
        {
            DataProcess<STcomboCustomerID_Result> customersData = new DataProcess<STcomboCustomerID_Result>();
            this.lkeCustomerInvoiceMainID.Properties.DataSource = customersData.Executing("STcomboCustomerID @varStoreID={0}", 0);
            this.lkeCustomerInvoiceMainID.Properties.ValueMember = "CustomerID";
            //this.lkeCustomerMainID.Properties.DisplayMember = "CustomerID";
            this.lkeCustomerInvoiceMainID.Properties.DisplayMember = "CustomerNumber";
        }

        private void InitStoreID()
        {
            DataProcess<Stores> storeData = new DataProcess<Stores>();
            this.lkeStoreID.Properties.DataSource = storeData.Select();
            this.lkeStoreID.Properties.ValueMember = "StoreID";
            this.lkeStoreID.Properties.DisplayMember = "StoreNumber";
        }
        private void InitLocation()
        {
            DataProcess<LocationsHome> locationData = new DataProcess<LocationsHome>();
            this.txtHomeLocation1.Properties.DataSource = locationData.Select(n => n.StoreID == AppSetting.CurrentUser.StoreID);
            this.txtHomeLocation1.Properties.ValueMember = "LocationID";
            this.txtHomeLocation1.Properties.DisplayMember = "LocationNum";

            this.txtHomeLocation2.Properties.DataSource = locationData.Select(n => n.StoreID == AppSetting.CurrentUser.StoreID);
            this.txtHomeLocation2.Properties.ValueMember = "LocationID";
            this.txtHomeLocation2.Properties.DisplayMember = "LocationNum";
        }

        #endregion
        #endregion

        #region Events
        private void btnBillingContract_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int customerID = Convert.ToInt32(this._currentCustomer.CustomerID);
            if (customerID <= 0) return;
            frm_MSS_Contracts contract = frm_MSS_Contracts.GetInstance(customerID);
            contract.InitData(customerID, 0);
            contract.Show();
            //contract.CheckActivePriceColumn();
        }

        private void btnProductGrouping_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_MSS_CustomerProductGrouping group = new frm_MSS_CustomerProductGrouping(this._currentCustomer.CustomerID);
            group.Show();
        }

        private void btnProductList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_MSS_Dialog_Products_simple frmProductList = new frm_MSS_Dialog_Products_simple(this._currentCustomer.CustomerID);
            frmProductList.Show();
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.lkeCustomerTypes.Text.Equals("Accounting Customer"))
            {
                XtraMessageBox.Show("This Customer is for Accounting purpose, can not edit or update !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SetControlEnabled(false);
            SetGridEditable(true);
            this.btnEdit.Enabled = false;

            if (this.lkeCustomerTypes.Text.Equals(CustomerTypeEnum.RANDOM_WEIGHT))
            {
                this.lkeCustomerTypes.ReadOnly = true;
            }
        }

        private void btnStop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!this._isStop)
            {
                try
                {
                    List<tmpProductRemains> listProductRemains = (List<tmpProductRemains>)this._productRemainsData.Executing("Select Top 1 tmpProductRemains.* From tmpProductRemains Where tmpProductRemains.tmpCustomerID = {0}", this._currentCustomer.CustomerID);

                    if (listProductRemains.Count == 0)
                    {
                        this._currentCustomer.CustomerDiscontinued = true;
                        this.btnEdit.Enabled = false;
                        SetControlEnabled(true);
                        this._isStop = true;
                        this._customerData.Update(this._currentCustomer);
                        this.ChangeStyleStop();
                    }
                    else
                    {
                        XtraMessageBox.Show("This Customer still has product in store!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.btnStop2.Reset();
                    }
                }
                catch (Exception ex)
                {
                    log.Error("==> Error is unexpected");
                    log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);

                    XtraMessageBox.Show(ex.Message, "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                this._currentCustomer.CustomerDiscontinued = false;
                this.btnEdit.Enabled = true;
                this._isStop = false;
                this._customerData.Update(this._currentCustomer);
                this.ChangeStyleStop();
            }

        }

        private void ChangeStyleStop()
        {
            if (this._isStop)
            {
                this.btnStop2.ItemAppearance.Pressed.BackColor = Color.Red;
                this.btnStop2.ItemAppearance.Hovered.BackColor = Color.Red;
                this.btnStop2.ItemAppearance.Normal.BackColor = Color.Red;
                this.btnStop2.ItemAppearance.Normal.ForeColor = Color.White;
                this.labelStopLeftBar.Appearance.BackColor = Color.Red;
            }
            else
            {
                this.btnStop2.ItemAppearance.Pressed.BackColor = Color.Transparent;
                this.btnStop2.ItemAppearance.Hovered.BackColor = Color.Transparent;
                this.btnStop2.ItemAppearance.Normal.BackColor = Color.Transparent;
                this.btnStop2.ItemAppearance.Normal.ForeColor = Color.Black;
                this.labelStopLeftBar.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Question;
            }
        }

        private void btnUpdateLocal_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this._qryComboCustomerData.ExecuteNoQuery("Delete * From ViewqryComboCustomerID");
                List<ViewqryComboCustomerID> newComboCustomerID = GetNewComboCustomerIdData();

                foreach (ViewqryComboCustomerID item in newComboCustomerID)
                {
                    _qryComboCustomerData.Insert(item);
                }

                XtraMessageBox.Show("Completed update local table !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);

                XtraMessageBox.Show(ex.Message, "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Hide();
        }

        private void btnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this._currentCustomer.CustomerID != 0)
            {
                this.update();
            }
            else
            {
                this.insert();
                LoadCustomerData();
            }
        }

        private void btnUpdateAndNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this._currentCustomer.CustomerID != 0)
            {
                this.update();
            }
            else
            {
                this.insert();
            }
            this._currentCustomer = new Customers();
            LoadCustomerData();
        }

        private void insert()
        {
            try
            {
                DataProcess<Customers> cDA = new DataProcess<Customers>();
                this._currentCustomer.CustomerID = cDA.Select().Max(x => x.CustomerID) + 1;
                this._currentCustomer.CustomerNumber = "CUS-" + this._currentCustomer.CustomerID;
                this._currentCustomer.CustomerDiscontinued = false;

                if (((int)this.txtHomeLocation1.EditValue == 0) || (String.IsNullOrEmpty(this.txtHomeLocation1.Text)))
                {
                    XtraMessageBox.Show("Update HomeLocation1!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (((int)this.txtHomeLocation2.EditValue == 0) || (String.IsNullOrEmpty(this.txtHomeLocation2.Text)))
                {
                    XtraMessageBox.Show("Update HomeLocation2!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (this.txtInvoiceEmail.EditValue != null && this.txtInvoiceEmail.EditValue.ToString().Length > 150)
                {
                    XtraMessageBox.Show("Length of column Invoice Send Email <= 150!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                Wait.Start(this);
                if (this.txtInitial.IsModified)
                {
                    this.UpdateCustomerNumber();
                }

                GetCurrentCustomer();
                this._currentCustomer.CustomerMainID = this._currentCustomer.CustomerID;
                this._currentCustomer.CustomerType = "General Storage";
                cDA.Insert(this._currentCustomer);
                UpdateGridData();
                this._customerData.InsertNewCustomerProductGroup(this._currentCustomer.CustomerID);
                SetControlEnabled(true);
                SetGridEditable(false);
                this.btnEdit.Enabled = true;
                Wait.Close();

                cDA.ExecuteNoQuery("Update Customers set UpdateBy='" + AppSetting.CurrentUser.LoginName + "', UpdateTime = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "' where CustomerID=" + this._currentCustomer.CustomerID);
                //cDA.ExecuteNoQuery("Update Customers set UpdateBy='" + AppSetting.CurrentUser.LoginName + "' where CustomerID=" + this._currentCustomer.CustomerID);
                XtraMessageBox.Show("Insert Record Success!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                AppSetting.CustomerList.Select(c => c == this._currentCustomer);
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);

                Wait.Close();
                XtraMessageBox.Show(ex.Message, "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                XtraMessageBox.Show("Check HomeLocation!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void update()
        {
            try
            {
                if (((int)this.txtHomeLocation1.EditValue == 0) || (String.IsNullOrEmpty(this.txtHomeLocation1.Text)))
                {
                    XtraMessageBox.Show("Update HomeLocation1!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (((int)this.txtHomeLocation2.EditValue == 0) || (String.IsNullOrEmpty(this.txtHomeLocation2.Text)))
                {
                    XtraMessageBox.Show("Update HomeLocation2!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (this.txtInvoiceEmail.EditValue.ToString().Length > 150)
                {
                    XtraMessageBox.Show("Length of column Invoice Send Email <= 150!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                Wait.Start(this);
                if (this.txtInitial.IsModified)
                {
                    this.UpdateCustomerNumber();
                }

                GetCurrentCustomer();
                this._customerData.Update(this._currentCustomer);
                UpdateGridData();
                this._customerData.InsertNewCustomerProductGroup(this._currentCustomer.CustomerID);
                SetControlEnabled(true);
                SetGridEditable(false);
                this.btnEdit.Enabled = true;
                Wait.Close();

                DataProcess<Customers> cDA = new DataProcess<Customers>();
                cDA.ExecuteNoQuery("Update Customers set UpdateBy='" + AppSetting.CurrentUser.LoginName + "', UpdateTime = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "' where CustomerID=" + this._currentCustomer.CustomerID);
                //cDA.ExecuteNoQuery("Update Customers set UpdateBy='" + AppSetting.CurrentUser.LoginName + "' where CustomerID=" + this._currentCustomer.CustomerID);
                XtraMessageBox.Show("Update Record Success!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                AppSetting.CustomerList.Select(c => c == this._currentCustomer);
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);

                Wait.Close();
                XtraMessageBox.Show(ex.Message, "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                XtraMessageBox.Show("Check HomeLocation!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUpdateInfo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("You update the Main Customer ID for this Account. Do you want to update phone, address, email, Billing email… ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    GetCurrentCustomer();
                    int result = this._customerData.UpdateCustomerInfo(this._currentCustomer.CustomerID, (int)this._currentCustomer.CustomerMainID);
                    var refreshCus = this._customerData.Select(c => c.CustomerID == this._currentCustomer.CustomerID).FirstOrDefault();
                    this.CurrentCustomers = refreshCus;
                }
                catch (Exception ex)
                {
                    log.Error("==> Error is unexpected");
                    log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);

                    XtraMessageBox.Show(ex.Message, "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnCustomerMainID_Click(object sender, EventArgs e)
        {
            int currentMainID = (int)this.lkeCustomerMainID.EditValue;
            //this.dtNavigatorCustomer.Position = currentMainID - 1;
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void txtCustomerName_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtCustomerName.Text))
            {
                XtraMessageBox.Show("Wrong Customer Name", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtCustomerName.Focus();
            }
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (!e.Page.Tag.Equals("1"))
            {
                this.HandleTabPageChanged(e.Page.Name);
            }

        }

        private void btnStock_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this._currentCustomer == null) return;
            frm_ST_StockOnHandOneCustomer frm = new frm_ST_StockOnHandOneCustomer(this._currentCustomer.CustomerID);
            frm.IsFixHeightScreen = false;
            frm.Show();
        }

        private void btnScheduledReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frmDialogTaskNew = new frm_WR_TaskView(this._currentCustomer.CustomerID);
            frmDialogTaskNew.Show();
        }

        #endregion

        #region Get Current Record Data
        private List<ViewqryComboCustomerID> GetNewComboCustomerIdData()
        {
            List<STcomboCustomerID_Result> comboCustomerData = (List<STcomboCustomerID_Result>)this._stComboCustomerID.Executing("STcomboCustomerID");
            List<ViewqryComboCustomerID> newData = new List<ViewqryComboCustomerID>();

            foreach (STcomboCustomerID_Result item in comboCustomerData)
            {
                if (!item.CustomerType.Equals(CustomerTypeEnum.DOCUMENT_STORAGE))
                {
                    ViewqryComboCustomerID row = new ViewqryComboCustomerID();
                    row.CustomerID = item.CustomerID;
                    row.CustomerName = item.CustomerName;
                    row.CustomerNumber = item.CustomerNumber;
                    row.CustomerType = item.CustomerType;
                    row.CustomerDiscontinued = (bool)item.CustomerDiscontinued;

                    newData.Add(row);
                }
            }
            return newData;
        }

        private void GetCurrentCustomer()
        {
            this._currentCustomer.CustomerName = this.txtCustomerName.Text;
            this._currentCustomer.Initial = this.txtInitial.Text;
            this._currentCustomer.StoreID = (int)this.lkeStoreID.EditValue;
            this._currentCustomer.Address = this.mmeAddress.Text;
            this._currentCustomer.Phone1 = this.txtPhone1.Text;
            this._currentCustomer.Phone2 = this.txtPhone2.Text;
            this._currentCustomer.CustomerAssignedTo = Convert.ToInt32(this.lkeAssigned.EditValue);
            this._currentCustomer.Fax = this.txtFax.Text;
            this._currentCustomer.Fax2 = this.txtFax2.Text;
            this._currentCustomer.Email = this.mmeEmail.Text;
            this._currentCustomer.EmailBilling = this.mmeEmailBilling.Text;
            this._currentCustomer.InvoiceSendEmail = this.txtInvoiceEmail.Text;
            this._currentCustomer.Hold = this.chkHold.EditValue == null ? false : (bool)this.chkHold.EditValue;
            this._currentCustomer.HoldMessage = this.txtHoldMessage.Text;
            this._currentCustomer.HoldLimitWeight = String.IsNullOrEmpty(this.txtHoldLimitWeight.Text) ? (int?)null : Convert.ToInt32(this.txtHoldLimitWeight.Text);
            this._currentCustomer.CustomerInvoiceName = this.txtCustomerInvoiceName.Text;
            this._currentCustomer.CustomerInvoiceAddress = this.mmeCustomerInvoiceAddress.Text;
            this._currentCustomer.CustomerMainID = Convert.ToInt32(this.lkeCustomerMainID.EditValue);
            if (this.lkeCustomerInvoiceMainID.EditValue != null)
                this._currentCustomer.CustomerMainInvoiceID = Convert.ToInt32(this.lkeCustomerInvoiceMainID.EditValue);
            this._currentCustomer.CustomerDispatchType = Convert.ToByte(this.lkeCustomerDispatchType.EditValue);
            this._currentCustomer.SendNote = this.chkSendNote.EditValue == null ? false : (bool)this.chkSendNote.EditValue;
            this._currentCustomer.IsAllowEDI = this.chkIsAllowEDI.EditValue == null ? false : (bool)this.chkIsAllowEDI.EditValue;
            this._currentCustomer.HomeLocationChange = this.chkHomeLocationChange.EditValue == null ? false : (bool)this.chkHomeLocationChange.EditValue;
            this._currentCustomer.CustomerTaxGroup = cbxTaxGroup.Text;
            this._currentCustomer.CustomerCategory = Convert.ToByte(this.lkeCategory.EditValue);
            this._currentCustomer.CustomerType = lkeCustomerTypes.Text;
            this._currentCustomer.DispatchingByClient = this.chkRequireClient.Checked;
            this._currentCustomer.BarcodeScanRequire = this.checkIsBarcodeRequired.Checked;
            this._currentCustomer.CustomerInvoiceTaxCode = this.txtCustomerInvoiceTaxCode.Text;
            if (this.txtVATPercentage.EditValue != null) this._currentCustomer.VATPercentage = Convert.ToInt32(this.txtVATPercentage.EditValue);
            this._currentCustomer.HomeLocation1 = Convert.ToInt32(this.txtHomeLocation1.EditValue);
            this._currentCustomer.HomeLocation2 = Convert.ToInt32(this.txtHomeLocation2.EditValue);
            try
            {
                this._currentCustomer.WarehouseID = (int)this.lke_WarehouseID.EditValue;
            }
            catch
            {

            }

            if (this.txtMainOnReport.Text.Trim() != "")
            {
                this._currentCustomer.CustomerMainOnReport = Convert.ToInt32(this.txtMainOnReport.Text);
            }
            if (this.txtMainContract.Text.Trim() != "")
            {
                this._currentCustomer.CustomerMainContractID = Convert.ToInt32(this.txtMainContract.Text);
            }
            if (textERPProductLength.Text.Trim() != "")
            {
                this._currentCustomer.ERPProductLength = Convert.ToInt32(this.textERPProductLength.Text);
            }
            else
            {
                this._currentCustomer.ERPProductLength = 0;
            }
            if ((this._currentCustomer.BillingInstructions == null && this.me_BillingInstructions.Text.Length > 0) || this._currentCustomer.BillingInstructions != this.me_BillingInstructions.Text)
            {
                this._currentCustomer.BillingInstructions = this.me_BillingInstructions.Text;
                this._currentCustomer.BillingInstructionUpdateTime = DateTime.Now;
            }


        }

        #endregion

        private void SetGridEditable(bool isEditable)
        {
            if (this.urcRequirement != null) this.urcRequirement.SetEditable(isEditable);
            if (this.urcContract != null) this.urcContract.SetEditable(isEditable);
            if (this.urcClient != null) this.urcClient.SetEditable(isEditable);
            if (this.urcSupplier != null) this.urcSupplier.SetEditable(isEditable);
            this.grvCustomerPalletStatus.OptionsBehavior.Editable = isEditable;
            this.grvCustomerPalletStatus.OptionsBehavior.ReadOnly = !isEditable;
        }

        private void UpdateGridData()
        {
            if (this.urcRequirement != null)
                this.urcRequirement.UpdateCustomerRequirement();

            if (this.urcContract != null)
                this.urcContract.UpdateCustomerContacts();
            if (this.urcSupplier != null) this.urcSupplier.UpdateCustomerSupplier();
            DataProcess<CustomerPalletStatu> proCusPallet = new DataProcess<CustomerPalletStatu>();
            for (int rowIndex = 0; rowIndex < this.grvCustomerPalletStatus.RowCount - 1; rowIndex++)
            {
                var cusPallet = (CustomerPalletStatu)this.grvCustomerPalletStatus.GetRow(rowIndex);
                if (cusPallet.CustomerPalletStatusID <= 0)
                {
                    // Process insert
                    cusPallet.CustomerID = this._currentCustomer.CustomerMainID;
                    cusPallet.CreatedTime = DateTime.Now;
                    int resultInsert = proCusPallet.Insert(cusPallet);
                }
                else
                {
                    // Process update
                    int resultUpdate = proCusPallet.Update(cusPallet);
                }
            }
        }

        private void RefreshData()
        {
            this.SetControlEnabled(true);
            InitCustomerMainID();
            InitCustomerMainInvoiceID();
            LoadCustomerData();

            if (this.urcRequirement != null) this.urcRequirement.CurrentCustomer = this._currentCustomer;
            if (this.urcContract != null) this.urcContract.CurrentCustomer = this._currentCustomer;
            if (this.urcClient != null) this.urcClient.CurrentCustomer = this._currentCustomer;
            if (this.urcEvent != null) this.urcEvent.CustomerMainID = (int)this._currentCustomer.CustomerID;
            if (this.urcSupplier != null) this.urcSupplier.InitData((int)this._currentCustomer.CustomerMainID);
        }

        private void frm_MSS_Customers_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.txtInitial.IsModified = false;
            this.Hide();
            e.Cancel = true;
        }

        private void frm_MSS_Customers_VisibleChanged(object sender, EventArgs e)
        {
            if (!this.Visible)
            {
                this.txtInitial.IsModified = false;
                return;
            }
            this.WindowState = FormWindowState.Normal;
            this.BringToFront();
        }

        private void btnShowClients_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_MSS_CustomerClients frm = new frm_MSS_CustomerClients();
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;

            if (this.urcClient == null || this.urcClient.IsDisposed)
            {
                this.urcClient = new urc_MSS_CustomerClients();
            }

            int customerID = this._currentCustomer.CustomerID;
            DataProcess<Customers> cusDA = new DataProcess<Customers>();
            this.urcClient.CurrentCustomer = cusDA.Select(c => c.CustomerID == customerID).FirstOrDefault();
            this.urcClient.Parent = frm;
        }

        private void btnDeliveryRoutes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_WM_Dialog_Routes Routes = new frm_WM_Dialog_Routes(this._currentCustomer.CustomerID);
            Routes.Show();
            Routes.WindowState = FormWindowState.Normal;
        }

        /// <summary>
        /// Loads the data for all tab pages.
        /// </summary>
        private void LoadDataForCurrentTabPage()
        {
            var currentSelectedTab = this.xtraTabControl1.SelectedTabPage.Name;
            this.HandleTabPageChanged(currentSelectedTab);
        }

        /// <summary>
        /// Loads the customer contact detail.
        /// </summary>
        private void LoadCustomerContactDetail()
        {
            // Contact detail
            if (this.urcContract == null)
            {
                this.urcContract = new urc_MSS_ContactDetails();
            }

            this.urcContract.CurrentCustomer = this._currentCustomer;
            this.urcContract.Parent = this.tabContactDetail;
        }

        /// <summary>
        /// Check user login has department is PKT,PKD then return true, else false
        /// </summary>
        /// <returns></returns>
        private bool CheckUserAllowEdit()
        {
            var dataSource = FileProcess.LoadTable("STCheckDepartmentBDACByUser @User='" + AppSetting.CurrentUser.LoginName + "'");
            if (Convert.ToInt32(dataSource.Rows[0]["Total"]) > 0) return true;
            else return false;
        }


        /// <summary>
        /// Loads the customer client.
        /// </summary>
        private void LoadCustomerClient()
        {
            // Client
            if (this.urcClient == null)
            {
                this.urcClient = new urc_MSS_CustomerClients();
            }

            this.urcClient.CurrentCustomer = this._currentCustomer;
            this.urcClient.Parent = this.tabClients;
        }

        /// <summary>
        /// Loads the customer event.
        /// </summary>
        private void LoadCustomerEvent()
        {
            // Event
            if (this.urcEvent == null)
            {
                this.urcEvent = new urc_MSS_CustomerEvent();
            }

            this.urcEvent.Dock = DockStyle.Fill;
            this.urcEvent.CustomerMainID = this._currentCustomer.CustomerID;
            this.urcEvent.Parent = this.tabEvents;
        }

        /// <summary>
        /// Loads the customer suppliers.
        /// </summary>
        private void LoadCustomerSuppliers()
        {
            // Supplier
            if (this.urcSupplier == null)
            {
                this.urcSupplier = new urc_MSS_CustomerSuppliers(this._currentCustomer.CustomerMainID);
            }
            this.urcSupplier.Parent = this.tabSuppliers;
            this.urcSupplier.InitData(this._currentCustomer.CustomerMainID);
        }

        /// <summary>
        /// Loads the customer pallet status.
        /// </summary>
        private void LoadCustomerPalletStatus()
        {
            DataProcess<PalletStatu> processPalletStatus = new DataProcess<PalletStatu>();
            this.rpi_lke_PalletStatus.DataSource = processPalletStatus.Select();
            this.rpi_lke_PalletStatus.DisplayMember = "PalletStatusDescription";
            this.rpi_lke_PalletStatus.ValueMember = "PalletStatus";

            DataProcess<CustomerPalletStatu> processCusPalletStatus = new DataProcess<CustomerPalletStatu>();
            var dataSource = processCusPalletStatus.Select(c => c.CustomerID == this._currentCustomer.CustomerMainID).OrderBy(s => s.CustomerPalletStatusNumber).ToList();
            BindingList<CustomerPalletStatu> bindingList = new BindingList<CustomerPalletStatu>(dataSource);
            var newpallet = new CustomerPalletStatu();
            newpallet.CustomerID = this._currentCustomer.CustomerMainID;
            newpallet.CustomerPalletStatusID = 0;
            newpallet.CreatedTime = DateTime.Now;
            bindingList.Add(newpallet);
            this.grdCustomerPalletStatus.DataSource = bindingList;
        }


        private void LoadCustomerRequirementTiles()
        {
            //tabCustomerRequirementTiles.Refresh();
            // Customer Requirement Tiles
            if (this.urcRTiles == null)
            {
                this.urcRTiles = new urc_MSS_CustomerRequirementTiles(this._currentCustomer.CustomerID);
            }
            this.urcRTiles.Parent = this.tabCustomerRequirementTiles;
            this.urcRTiles.InitData(this._currentCustomer.CustomerID);
            //this.urcRTiles.Show();
            //this.urcSupplier.InitData(this._currentCustomer.CustomerID);
        }
        private void loadCustomerBillingInstructions()
        {
            this.me_BillingInstructions.Text = this._currentCustomer.BillingInstructions;
        }
        /// <summary>
        /// Handles the tab page changed.
        /// </summary>
        /// <param name="pageName">Name of the page.</param>
        private void HandleTabPageChanged(string pageName)
        {
            switch (pageName)
            {
                case "tabContactDetail":
                    this.LoadCustomerContactDetail();

                    break;
                case "tabClients":
                    this.LoadCustomerClient();

                    break;
                case "tabSubCustomers":
                    LoadSubCustomers();
                    break;
                case "tabEvents":
                    this.LoadCustomerEvent();

                    break;
                case "tabSuppliers":
                    this.LoadCustomerSuppliers();
                    break;

                case "tabPalletStatus":
                    this.LoadCustomerPalletStatus();
                    break;

                case "tabCustomerRequirementTiles":
                    this.LoadCustomerRequirementTiles();
                    break;
                case "tabBillingInstructions":
                    this.loadCustomerBillingInstructions();
                    break;
            }
        }



        private void btnCopyCustomer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int newCustomerID = 0;
            FileProcess.LoadTable($"STAddNewCustomer @StoreID={AppSetting.StoreID},@CreatedBy='{AppSetting.CurrentUser.LoginName}'");
            using (var context = new SwireDBEntities())
            {
                using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(context.Database.Connection.ConnectionString))
                {
                    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("STCustomerDuplicate", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    // add parameters
                    System.Data.SqlClient.SqlParameter inParam = cmd.Parameters.Add("@CustomerMainID", System.Data.SqlDbType.Int);
                    inParam.Value = this._currentCustomer.CustomerID;
                    System.Data.SqlClient.SqlParameter outputParam = cmd.Parameters.Add("@NewCustomerID", System.Data.SqlDbType.Int);
                    outputParam.Direction = System.Data.ParameterDirection.Output;

                    System.Data.SqlClient.SqlParameter in1Param = cmd.Parameters.Add("@StoreID", System.Data.SqlDbType.Int);
                    in1Param.Value = AppSetting.StoreID;

                    conn.Open();
                    int result = cmd.ExecuteNonQuery();

                    // reader is closed/disposed after exiting the using statement
                    newCustomerID = Convert.ToInt32(outputParam.Value);
                }
            }

            if (newCustomerID > 0)
            {
                DataProcess<Customers> dataProcess = new DataProcess<Customers>();
                var newCustomer = dataProcess.Select(c => c.CustomerID == newCustomerID).FirstOrDefault();
                if (newCustomer != null) this.CurrentCustomers = newCustomer;
            }

        }

        private void txtMainOnReport_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtMainOnReport_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtMainContract_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private string XMLCusUpdate(IList<Customers> customerList)
        {
            StringBuilder xml = new StringBuilder();
            xml.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            xml.Append("<soap12:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap12=\"http://www.w3.org/2003/05/soap-envelope\">");
            xml.Append("<soap12:Body>");
            xml.Append("<UpdateCus xmlns=\"http://tempuri.org/\">");
            xml.Append("<XMLCusData>");
            xml.Append("<![CDATA[");
            xml.Append("<Customers>");
            foreach (var cusInfo in customerList)
            {
                xml.Append("<Customer>");
                //< !--tên công ty-->
                xml.Append("<Name>" + cusInfo.CustomerName.Replace("&", "&amp;") + "</Name>");
                //<!--Mã khách hàng-->
                xml.Append("<Code>" + cusInfo.CustomerNumber.Replace("&", "&amp;") + "</Code>");
                //<!--Mã số thuế-->
                xml.Append("<TaxCode>" + cusInfo.CustomerInvoiceTaxCode + "</TaxCode>");
                // Địa chỉ khi có ký tự & cần thay thế bằng &amp; trong xml không hiểu ký tự &
                if (string.IsNullOrWhiteSpace(cusInfo.Address))
                {
                    xml.Append("<Address>" + "Address" + "</Address>");
                }
                else
                    xml.Append("<Address>" + cusInfo.Address.Replace("&", "&amp;") + "</Address>");
                //< !--e mail khách hàng, ngăn cách nhau giữa các email bằng dấu phẩy (,), tối đa 3 emmail-- >
                // 3 email gồm: 1 mail kế toán viên, 1 mail kế toán trưởng, 1 mail của bên em ( để theo dõi mail đi)
                if (string.IsNullOrWhiteSpace(cusInfo.InvoiceSendEmail))
                {
                    MessageBox.Show("Customer [" + cusInfo.CustomerNumber + "] does not (Invoice Email)\nPlease update it.", "TPWMS",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    xml.Append("<Email>" + "" + "</Email>");
                }
                else
                {
                    xml.Append("<Email>" + cusInfo.InvoiceSendEmail.Replace(';', ',') + "</Email>");
                }

                xml.Append("<Phone>" + cusInfo.Phone1 + "</Phone>");
                //<!--kiểu khách hàng-->
                xml.Append("<CusType>0</CusType>");
                xml.Append("<BankAccountName></BankAccountName>");
                xml.Append("<BankName></BankName>");
                xml.Append("<BankNumber></BankNumber>");
                xml.Append("<Fax>" + cusInfo.Fax + "</Fax>");
                if (string.IsNullOrWhiteSpace(cusInfo.PrimaryContact))
                {
                    xml.Append("<ContactPerson>" + "" + "</ContactPerson>");
                }
                else
                {
                    if (cusInfo.PrimaryContact.Length > 102)
                        xml.Append("<ContactPerson>" + cusInfo.PrimaryContact.Replace("&", "&amp;").Substring(102) + "</ContactPerson>");
                    else
                        xml.Append("<ContactPerson>" + cusInfo.PrimaryContact.Replace("&", "&amp;") + "</ContactPerson>");
                }

                xml.Append("<RepresentPerson></RepresentPerson>");
                xml.Append("</Customer>");
            }
            xml.Append("</Customers>");
            xml.Append("]]>");
            xml.Append("</XMLCusData>");
            xml.Append("<username>" + this.currentStore.E_Invoice_UserName + "</username>");
            xml.Append("<pass>" + this.currentStore.E_Invoice_Password + "</pass>");
            xml.Append("<convert>0</convert>");
            xml.Append("</UpdateCus>");
            xml.Append("</soap12:Body>");
            xml.Append("</soap12:Envelope>");
            return xml.ToString();
        }


        private void rpi_btn_btnPalletStatusDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (this.grvCustomerPalletStatus.FocusedRowHandle < 0) return;

            if (XtraMessageBox.Show("Are you sure you want to delete this pallet status?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataProcess<CustomerPalletStatu> proCusPallet = new DataProcess<CustomerPalletStatu>();
                var cusPallet = (CustomerPalletStatu)this.grvCustomerPalletStatus.GetRow(this.grvCustomerPalletStatus.FocusedRowHandle);
                proCusPallet.Delete(cusPallet);
            }
        }

        private void frm_MSS_Customers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
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

        private void btnDispatchingMethod_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this._currentCustomer == null) return;
            frm_MSS_RuleExpand frm = new frm_MSS_RuleExpand(this._currentCustomer.CustomerID);
            frm.ShowDialog();
        }

        private void btnNewCustomer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var newCustomerID = Convert.ToInt32(FileProcess.LoadTable($"STAddNewCustomer @StoreID={AppSetting.StoreID},@CreatedBy='{AppSetting.CurrentUser.LoginName}'").Rows[0]["NewCustomerID"]);
            DataProcess<Customers> dataProcess = new DataProcess<Customers>();
            var newCustomer = dataProcess.Select(c => c.CustomerID == newCustomerID).FirstOrDefault();
            this.CurrentCustomers = newCustomer;
        }

        private void checkShowPalletIDDetailedHistory_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkShowPalletIDDetailedHistory_CheckedChanged_1(object sender, EventArgs e)
        {

        }
    }
}
