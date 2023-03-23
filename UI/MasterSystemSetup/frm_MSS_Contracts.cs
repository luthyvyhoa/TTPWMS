using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using DevExpress.XtraEditors;
using Common.Controls;
using Common.Process;
using UI.Helper;
using DA;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using UI.WarehouseManagement;
using Common.Data;
using UI.CRM;
using System.Threading.Tasks;
using UI.ReportFile;
using UI.Management;
using DevExpress.XtraEditors.Controls;

namespace UI.MasterSystemSetup
{
    public partial class frm_MSS_Contracts : frmBaseForm
    {
        private static int customerID = 0;
        private static int contractID = 0;
        private ST_WMS_LoadBillingContractData_Result currentContract;
        private DataProcess<ST_WMS_LoadBillingContractData_Result> _billingContractData;
        private DataProcess<ST_WMS_LoadContractDetailData_Result> _contractDetailData;
        private DataProcess<ST_WMS_LoadContractEmployeeServicesData_Result> _contractEmployeeServiceData;
        private DataProcess<STBillingDetailLastMonth_Result> _billingDetailData;
        private BindingList<ST_WMS_LoadContractDetailData_Result> bdContractDetails = null;
        private BindingList<ST_WMS_LoadContractEmployeeServicesData_Result> bdEmployeeService = null;
        private urc_CRM_RelatedQuotations RelatedQuotations = null;
        private urc_CRM_12MonthProfitability Profitability = null;
        private urc_CRM_ActiveContracts ActiveContracts = null;
        private urc_CRM_DiscountInfo DiscountInfo = null;
        private static frm_MSS_Contracts instance = null;
        private urc_CRM_CostStructure CostStructure = null;
        private urc_CRM_RatesHistory RatesHistory = null;
        private urc_CRM_36MonthsOperation monthOperation = null;

        private bool isContractDetailModified = false;
        private bool isServiceModified = false;
        private bool isNewRowAdded = false;

        public frm_MSS_Contracts(int customerIDInput = 0, int contractIDInput = 0)
        {
            // Init the controls to designer
            InitializeComponent();
            this.IsFixHeightScreen = false;
            customerID = customerIDInput;
            contractID = contractIDInput;
            this.currentContract = new ST_WMS_LoadBillingContractData_Result();
            this._contractDetailData = new DataProcess<ST_WMS_LoadContractDetailData_Result>();
            AddEventForControl();

            // Init master data
            this.LoadAllContractStatus();
            InitLookUpCustomerName();
            InitComboboxData();
            LoadCurrency();
            InitLookUpBillingCycle();
            InitLookUpServiceID();
            InitLookUpMHLWorkDefinitions();
            LoadAllWorkDefinition();
            LoadContractEmployeeSerivces();
        }



        public static frm_MSS_Contracts GetInstance(int customerMainIDInput = 0, int contractIDInput = 0)
        {
            customerID = customerMainIDInput;
            contractID = contractIDInput;
            //if (instance == null)
            //{
            //    instance = new frm_MSS_Contracts(customerID, contractID);
            //}
            instance = new frm_MSS_Contracts(customerID, contractID);
            return instance;
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.F3)
            {
                string contractNumber = this.txtContractNumber.Text;
                frm_WM_Attachments.Instance.OrderNumber = contractNumber;
                frm_WM_Attachments.Instance.CustomerID = Convert.ToInt16(this.lkeCustomerNumber.EditValue);
                frm_WM_Attachments.Instance.AppenfixNumber = txtAppendixNo.Text;
                if (frm_WM_Attachments.Instance.Enabled)
                {
                    frm_WM_Attachments.Instance.ShowDialog();

                    // Check attachment status in DB
                    bool hasAttach = this.CheckHasAttachedFiles();
                    if (!hasAttach)
                    {
                        // Not exist attachment in contract
                        int result = this._contractDetailData.ExecuteNoQuery("Update Contracts set IsAttachment=0 where ContractNumber='" + contractNumber + "' and AppendixNumber = '" + txtAppendixNo.Text + "'");
                    }
                    else
                    {
                        // Exist attachment in contract
                        int result = this._contractDetailData.ExecuteNoQuery("Update Contracts set IsAttachment=1 where ContractNumber='" + contractNumber + "' and AppendixNumber = '" + txtAppendixNo.Text + "'");
                    }

                }
            }


            return base.ProcessDialogKey(keyData);
        }

        /// <summary>
        /// Get or set contract id
        /// </summary>
        public void InitData(int customerMainIDInput = 0, int contractIDInput = 0)
        {
            try
            {
                Wait.Start(this);
                // Load data by customerID selected
                customerID = customerMainIDInput;
                contractID = contractIDInput;
                this.LoadContractData();
                //this.lkeAccountingStatus.EditValue = this.currentContract.AccountingStatus;
                this.LoadAccountStatus();
                //LoadCurrency();
                this.LoadContractEmployeeSerivces();
                if (this.currentContract == null)
                {

                    return;
                }

                if (this.currentContract != null)
                {
                    lkeBillingCycle.EditValue = Convert.ToInt32(this.currentContract.BillingCycle);

                }
                if (this.currentContract.ContractProgressStatus != null)
                {
                    this.lkeContractStatus.EditValue = this.currentContract.ContractProgressStatus;
                }

                this.lkeCustomerNumber.EditValue = this.currentContract.CustomerID;

                // Check permission control
                this.colPrice.OptionsColumn.ShowInCustomizationForm = false;
                this.grcCheckingQuantity.OptionsColumn.ShowInCustomizationForm = false;
                this.CheckActivePriceColumn();
                this.colPrice.OptionsColumn.ReadOnly = true;
                this.grcCheckingQuantity.OptionsColumn.ReadOnly = true;

                Wait.Close();
            }
            catch (Exception ex)
            {
                Wait.Close();
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadCurrency()
        {
            //List<string> lst = new List<string>();
            //lst.Add("VND");
            //lst.Add("USD");
            //lst.Add("HKD");
            //lst.Add("AUD");
            //lst.Add("EUR");
            //this.textCurrencyUnit.Properties.DataSource = lst;
            //this.textCurrencyUnit.EditValue = "VND";

            ComboBoxItemCollection coll = textCurrencyUnit.Properties.Items;
            coll.BeginUpdate();
            try
            {
                coll.Add("VND");
                coll.Add("USD");
                coll.Add("HKD");
                coll.Add("AUD");
                coll.Add("EUR");
            }
            finally
            {
                coll.EndUpdate();
            }
            textCurrencyUnit.SelectedIndex = -1;
        }
        private void LoadAccountStatus()
        {
            DataProcess<ContractAccountingStatu> dataProcess = new DataProcess<ContractAccountingStatu>();
            //this.lkeAccountingStatus.Properties.DataSource = dataProcess.Select();
            this.lkeAccountingStatus.Properties.DataSource = FileProcess.LoadTable("ST_WMS_LoadContractAccountingStatus");
            this.lkeAccountingStatus.Properties.ValueMember = "ContractAccountingStatusID";
            this.lkeAccountingStatus.Properties.DisplayMember = "ContractAccountingStatusDescription";
        }

        public void CheckActivePriceColumn()
        {
            var dataSource = FileProcess.LoadTable("ST_WMS_CheckActivePriceColumn @LoginName='" + AppSetting.CurrentUser.LoginName + "'");
            var accountingUser = dataSource.Select("UserDepartmentDefinitionName='Accounting'").Count();
            if (accountingUser <= 0)
            {
                this.lkeAccountingStatus.Properties.ReadOnly = true;
                this.txtAccountStatusComments.ReadOnly = true;
            }
            // Set active controls
            for (int role = 0; role < dataSource.Rows.Count; role++)
            {
                var currentRole = Convert.ToString(dataSource.Rows[role]["UserDepartmentDefinitionName"]);
                if (currentRole.ToLower().Equals("bussiness development"))
                {
                    this.colPrice.Visible = true;
                    this.colPrice.VisibleIndex = 3;
                    this.colPrice.OptionsColumn.ReadOnly = false;
                    this.colPrice.OptionsColumn.ShowInCustomizationForm = true;

                    this.grcCheckingQuantity.Visible = false;
                    //this.grcCheckingQuantity.VisibleIndex = 6;
                    this.grcCheckingQuantity.OptionsColumn.ReadOnly = false;
                    this.grcCheckingQuantity.OptionsColumn.ShowInCustomizationForm = true;
                    break;
                }
                bool isBillingOperator = UserPermission.CheckBillingOperator(AppSetting.CurrentUser.LoginName, 4);
                //if (!isBillingOperator)
                //{
                //    XtraMessageBox.Show("You are Billing Operator to view this", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}

                if ((currentRole.ToLower().Equals("transport")) && (!isBillingOperator))
                {
                    int customerID = (int)lkeCustomerNumber.EditValue;
                    var currentCustomer = AppSetting.CustomerList.Where(c => c.CustomerID == customerID).FirstOrDefault();
                    string ini = currentCustomer.Initial;
                    if (ini == "DSC")
                    {
                        this.colPrice.Visible = true;
                        this.colPrice.VisibleIndex = 3;
                        this.colPrice.OptionsColumn.ReadOnly = false;
                        this.colPrice.OptionsColumn.ShowInCustomizationForm = true;

                        this.grcCheckingQuantity.Visible = false;
                        //this.grcCheckingQuantity.VisibleIndex = 6;
                        this.grcCheckingQuantity.OptionsColumn.ReadOnly = false;
                        this.grcCheckingQuantity.OptionsColumn.ShowInCustomizationForm = true;
                        break;
                    }

                }
                else
                {
                    if (isBillingOperator)
                    {
                        this.colPrice.Visible = true;
                        this.colPrice.VisibleIndex = 3;
                        this.colPrice.OptionsColumn.ReadOnly = false;
                        this.colPrice.OptionsColumn.ShowInCustomizationForm = true;

                        this.grcCheckingQuantity.Visible = false;
                        //this.grcCheckingQuantity.VisibleIndex = 6;
                        this.grcCheckingQuantity.OptionsColumn.ReadOnly = false;
                        this.grcCheckingQuantity.OptionsColumn.ShowInCustomizationForm = true;
                        break;
                    }
                }
            }
        }
        /// <summary>
        /// Form load 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frm_MSS_Contracts_Load(object sender, System.EventArgs e)
        {
        }

        private void AddEventForControl()
        {
            this.dtNavigatorContract.PositionChanged += dtNavigatorContract_PositionChanged;
            this.grvContractDetail.CellValueChanging += grvContractDetail_CellValueChanging;
            this.grvContractDetail.RowCellClick += GrvContractDetail_RowCellClick;
            this.grvContractEmployeeServices.CellValueChanged += grvContractEmployeeServices_CellValueChanged;
            this.grvContractEmployeeServices.CellValueChanging += grvContractEmployeeServices_CellValueChanging;
            this.grvContractEmployeeServices.InitNewRow += grvContractEmployeeServices_InitNewRow;
            this.rpi_lke_MHLWorkDefinition.EditValueChanged += Rpi_lke_MHLWorkDefinition_EditValueChanged;
            this.dtStartDate.Validating += DtStartDate_Validating; ;
            this.dtEndDate.Validating += DtEndDate_Validating;
            this.grvContractDetail.KeyDown += GrvContractDetails_KeyDown;
            this.rpi_lke_WorkDefinitions.CloseUp += Rpi_lke_WorkDefinitions_CloseUp;
            this.FormClosing += Frm_MSS_Contracts_FormClosing;
        }

        private void DtStartDate_Validating(object sender, CancelEventArgs e)
        {
            //if (dtStartDate.DateTime > dtEndDate.DateTime)
            //{
            //    e.Cancel = true;
            //    XtraMessageBox.Show("Start Date <= End Date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    this.dtStartDate.Focus();
            //}
        }

        private void Frm_MSS_Contracts_FormClosing(object sender, FormClosingEventArgs e)
        {
            string contractNumber = this.txtContractNumber.Text;
            bool hasAttach = this.CheckHasAttachedFiles();
            if (!hasAttach)
            {
                // Not exist attachment in contract
                this._contractDetailData.ExecuteNoQuery("Update Contracts set IsAttachment=0 where ContractNumber='" + contractNumber + "' and AppendixNumber = '" + txtAppendixNo.Text + "'");
            }
            else
            {
                // Exist attachment in contract
                this._contractDetailData.ExecuteNoQuery("Update Contracts set IsAttachment=1 where ContractNumber='" + contractNumber + "' and AppendixNumber = '" + txtAppendixNo.Text + "'");
            }
            this.Hide();
            e.Cancel = true;
        }

        private void Rpi_lke_WorkDefinitions_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.Value == null) return;
            LookUpEdit lke = (LookUpEdit)sender;
            lke.EditValue = e.Value;
            var currentWorkDefinition = (MHLWorkDefinitions)lke.GetSelectedDataRow();
            if (currentWorkDefinition == null) return;
            DataProcess<ContractEmployeeServices> employeeServiceDA = new DataProcess<ContractEmployeeServices>();
            // Get current contract service id at row selected
            int contractServiceID = Convert.ToInt32(this.grvContractEmployeeServices.GetFocusedRowCellValue("ContractEmployeeServiceID"));
            int contractDetailID = Convert.ToInt32(this.grvContractDetail.GetFocusedRowCellValue("ContractDetailID"));
            int customerID = (int)this.currentContract.CustomerID;
            var contractServiceExists = employeeServiceDA.Select(cs => cs.ContractDetailID == contractDetailID && cs.CustomerID == customerID && cs.WorkDefinitionID == currentWorkDefinition.MHLWorkDefinitionID);
            if (contractServiceExists != null && contractServiceExists.Count() > 0)
            {
                XtraMessageBox.Show("Exists code", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Value = 0;
                return;
            }
            // Set work info
            int rowIndex = this.grvContractEmployeeServices.FocusedRowHandle;
            this.bdEmployeeService[rowIndex].WorkDefinitionID = currentWorkDefinition.MHLWorkDefinitionID;
            this.bdEmployeeService[rowIndex].JobName = currentWorkDefinition.JobName;
            this.bdEmployeeService[rowIndex].Description = currentWorkDefinition.Description;
            this.bdEmployeeService[rowIndex].UnitPrice = currentWorkDefinition.UnitPrice;
            this.bdEmployeeService[rowIndex].Unit = currentWorkDefinition.Unit;

            var newContractEmployeeService = new ContractEmployeeServices();
            newContractEmployeeService.ContractDetailID = contractDetailID;
            newContractEmployeeService.CustomerID = customerID;
            newContractEmployeeService.WorkDefinitionID = currentWorkDefinition.MHLWorkDefinitionID;

            // Check current action is insert or update
            if (contractServiceID <= 0)
            {
                employeeServiceDA.Insert(newContractEmployeeService);
                this.grvContractEmployeeServices.SetFocusedRowCellValue("ContractEmployeeServiceID", newContractEmployeeService.ContractEmployeeServiceID);
                this.bdEmployeeService.AddNew();
            }
            else
            {
                var contractServiceUpdate = employeeServiceDA.Select(cs => cs.ContractEmployeeServiceID == contractServiceID).FirstOrDefault();
                contractServiceUpdate.WorkDefinitionID = currentWorkDefinition.MHLWorkDefinitionID;
                employeeServiceDA.Update(contractServiceUpdate);
            }
        }

        private void GrvContractDetail_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.RowHandle < 0) return;
            this.mmeScopeOfWork.EditValue = this.grvContractDetail.GetFocusedRowCellValue("ScopeOfWork");
            this.mmeScopeOfWorkVN.EditValue = this.grvContractDetail.GetFocusedRowCellValue("ScopeOFWorkVietnam");
        }

        private void GrvContractDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete) return;
            if (this.grvContractDetail.FocusedRowHandle < 0) return;
            if (this.currentContract.ContractProgressStatus > 4 || this.currentContract.ContractProgressStatus == 3 || this.currentContract.AccountingStatus == 2)
            {
                MessageBox.Show("Just allow delete service when contract just created or Status <4 and AccountingStatus <2!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var dl = MessageBox.Show("Do you want to delete this service?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dl.Equals(DialogResult.No)) return;

            var contractDetail = (ST_WMS_LoadContractDetailData_Result)this.grvContractDetail.GetRow(this.grvContractDetail.FocusedRowHandle);
            this.bdContractDetails.Remove(contractDetail);
            DataProcess<ContractDetails> contractDetailsData = new DataProcess<ContractDetails>();
            int result = contractDetailsData.ExecuteNoQuery("Delete ContractDetails where ContractDetailID=" + contractDetail.ContractDetailID);
        }

        private void DtEndDate_Validating(object sender, CancelEventArgs e)
        //private void DtStartDate_Validating(object sender, CancelEventArgs e)
        {
            //if (!e.KeyCode.Equals(Keys.Enter)) return;
            if (dtEndDate.DateTime < dtStartDate.DateTime)
            {
                e.Cancel = true;
                XtraMessageBox.Show("End Date >= Start Date", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.dtEndDate.Focus();
            }
        }

        private void SetControlEnable(bool isEditable)
        {
            this.txtContractID.ReadOnly = !isEditable;
            this.txtContractNumber.ReadOnly = !isEditable;
            this.txtCustomerInvoiceAddress.ReadOnly = !isEditable;
            this.textContractMainID.ReadOnly = !isEditable;
            this.txtCustomerInvoiceName.ReadOnly = !isEditable;
            this.txtCustomerName.ReadOnly = !isEditable;
            this.txtInsuranceUnitValue.ReadOnly = !isEditable;

            //this.txtProductMaxValue.ReadOnly = !isEditable;

            this.txtTaxCode.ReadOnly = !isEditable;
            this.dAppendixDate.ReadOnly = !isEditable;
            //this.txtCusSignEmail.ReadOnly = !isEditable;
            //this.txtCusSignGender.ReadOnly = !isEditable;
            //this.txtCusSignPosEng.ReadOnly = !isEditable;
            //this.txtCusSignPosVN.ReadOnly = !isEditable;
            //this.txtCusSignRepresentative.ReadOnly = !isEditable;
            //this.txtAppendixNo.ReadOnly = !isEditable;
            this.dAppendixDate.ReadOnly = !isEditable;
            this.lkeContractStatus.ReadOnly = !isEditable;
            this.lkeAccountingStatus.ReadOnly = !isEditable;
            this.txtAccountStatusComments.ReadOnly = !isEditable;
            this.txtPayterms.ReadOnly = !isEditable;
            this.textCurrencyUnit.ReadOnly = !isEditable;
            this.dtContractDate.ReadOnly = !isEditable;
            this.dReturedDate.ReadOnly = !isEditable;
            this.dtEndDate.ReadOnly = !isEditable;
            this.dtReviewDate.ReadOnly = !isEditable;
            this.dtStartDate.ReadOnly = !isEditable;
            this.cbxInsuranceUnit.ReadOnly = !isEditable;
            this.lkeBillingCycle.ReadOnly = !isEditable;
            this.lkeCustomerNumber.ReadOnly = !isEditable;
            this.mmeScopeOfWork.ReadOnly = !isEditable;
            this.mmeScopeOfWorkVN.ReadOnly = !isEditable;
            this.colPrice.OptionsColumn.ReadOnly = !isEditable;
            this.txtAccMainID.ReadOnly = !isEditable;
            this.dAccEndDate.ReadOnly = !isEditable;
            this.txtNumberEX.ReadOnly = !isEditable;
            this.txtAContNo.ReadOnly = !isEditable;
            this.mmContractAccountRemark.ReadOnly = !isEditable;
            this.btnUpdate.Enabled = isEditable;
            this.Btn_MSS_Contracts_Update.Enabled = isEditable;
            //this.btnDelete.Enabled = isEditable;

            this.grcBillingToDate.OptionsColumn.AllowEdit = isEditable;
            this.grcCheckingQuantity.OptionsColumn.AllowEdit = isEditable;
            this.grcCheckingQuantity2.OptionsColumn.AllowEdit = isEditable;
            this.grcContractDetailRemark.OptionsColumn.ReadOnly = !isEditable;
            this.colLineNumber.OptionsColumn.ReadOnly = !isEditable;
            this.grcName.OptionsColumn.AllowEdit = isEditable;
            this.grcServiceID.OptionsColumn.AllowEdit = isEditable;
            //this.grcServiceName.OptionsColumn.AllowEdit = isEditable;
            //this.grcServiceNumber.OptionsColumn.AllowEdit = isEditable;
            this.grcWorkDefinition.OptionsColumn.AllowEdit = isEditable;

            if (isEditable)
            {
                this.grvContractEmployeeServices.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            }
            else
            {
                this.grvContractEmployeeServices.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            }
        }

        #region Load Data
        private void LoadBillingDetail()
        {
            try
            {
                var dataSource = this._contractDetailData.Executing("ST_WMS_LoadContractDetailData @ContractID={0}", this.currentContract.ContractID);
                if (dataSource != null && dataSource.Count() > 0)
                {
                    this.bdContractDetails = new BindingList<ST_WMS_LoadContractDetailData_Result>(dataSource.ToList());
                }
                else
                {
                    this.bdContractDetails = new BindingList<ST_WMS_LoadContractDetailData_Result>();
                }
                //this.bdContractDetails.Add(new ST_WMS_LoadContractDetailData_Result());
                this.grdContractDetails.DataSource = this.bdContractDetails;
            }
            catch (Exception ex)
            {
            }
        }

        private void LoadBillingLastMonth()
        {
            this._billingDetailData = new DataProcess<STBillingDetailLastMonth_Result>();
            this.grdBillingConfirmation.DataSource = this._billingDetailData.Executing("STBillingDetailLastMonth @CustomerID={0}", this.currentContract.CustomerID);
        }
        private void LoadContractEmployeeSerivces()
        {
            this._contractEmployeeServiceData = new DataProcess<ST_WMS_LoadContractEmployeeServicesData_Result>();
            var dataSource = (List<ST_WMS_LoadContractEmployeeServicesData_Result>)this._contractEmployeeServiceData.Executing("ST_WMS_LoadContractEmployeeServicesData @CustomerID={0}", this.currentContract.CustomerID);
            this.bdEmployeeService = new BindingList<ST_WMS_LoadContractEmployeeServicesData_Result>(dataSource);
            this.bdEmployeeService.AddNew();
            this.grdContractEmployeeServices.DataSource = this.bdEmployeeService;
        }

        private void LoadAllWorkDefinition()
        {
            DataProcess<MHLWorkDefinitions> workDefinitionDA = new DataProcess<MHLWorkDefinitions>();
            this.rpi_lke_WorkDefinitions.DataSource = workDefinitionDA.Select(w => w.Discontinued == false).ToList().OrderBy(w => w.MHLWorkDefinitionNumber);
            this.rpi_lke_WorkDefinitions.DisplayMember = "MHLWorkDefinitionNumber";
            this.rpi_lke_WorkDefinitions.ValueMember = "MHLWorkDefinitionID";
        }

        private void LoadAllContractStatus()
        {
            this.lkeContractStatus.Properties.DataSource = FileProcess.LoadTable("ST_WMS_LoadContractStatus");
            this.lkeContractStatus.Properties.ValueMember = "ContractStatusID";
            this.lkeContractStatus.Properties.DisplayMember = "ConstractStatusDescriptions";
        }

        private void LoadContractData()
        {
            this._billingContractData = new DataProcess<ST_WMS_LoadBillingContractData_Result>();
            List<ST_WMS_LoadBillingContractData_Result> listBillingContract = null;
            bool hasAdd = false;
            if (contractID > 0)
            {
                // Load contract by contract id selected
                listBillingContract = (List<ST_WMS_LoadBillingContractData_Result>)this._billingContractData.Executing("ST_WMS_LoadBillingContractDataByContractID @ContractID={0}", contractID);
            }
            else
            {
                // Load all contract by customer main id selected
                listBillingContract = (List<ST_WMS_LoadBillingContractData_Result>)this._billingContractData.Executing("ST_WMS_LoadBillingContractData @CustomerMainID={0}", customerID);
            }

            if (listBillingContract.Count == 1)
            {
                listBillingContract.Add(listBillingContract[0]);
                hasAdd = true;
            }

            this.dtNavigatorContract.DataSource = listBillingContract;
            this.currentContract = listBillingContract.LastOrDefault();
            this.dtNavigatorContract.Position = listBillingContract.IndexOf(this.currentContract);
            this.dtNavigatorContract_PositionChanged(null, null);

            //this.colPrice.OptionsColumn.ShowInCustomizationForm = false;
            //this.grcCheckingQuantity.OptionsColumn.ShowInCustomizationForm = false;
            //this.CheckActivePriceColumn();

            if (hasAdd)
            {
                listBillingContract.Remove(listBillingContract[0]);
            }
        }

        private void BindingContractData(ST_WMS_LoadBillingContractData_Result contractsSelected)
        {
            textCreatedTime.EditValue = contractsSelected.CreatedTime;
            txtCustomerName.Text = contractsSelected.CustomerName;
            textCreatedBy.Text = contractsSelected.CreatedBy;
            txtContractID.Text = Convert.ToString(contractsSelected.ContractID);
            txtContractNumber.Text = contractsSelected.ContractNumber;
            txtContractNumber.Tag = contractsSelected.ContractID;
            this.textContractID.EditValue = contractsSelected.ContractID;
            txtCustomerInvoiceAddress.Text = contractsSelected.CustomerInvoiceAddress;
            this.textContractMainID.EditValue = contractsSelected.ContractMainID;
            this.txtAccountStatusComments.EditValue = contractsSelected.AccountingStatusNote;
            txtCustomerInvoiceName.Text = contractsSelected.CustomerInvoiceName;
            txtTaxCode.Text = contractsSelected.CustomerInvoiceTaxCode;
            dAppendixDate.Text = Convert.ToString(contractsSelected.AppendixDate);
            txtCusSignEmail.Text = contractsSelected.CustomerSignEmail;
            txtCusSignGender.Text = contractsSelected.CustomerSignGender;
            txtCusSignPosEng.Text = contractsSelected.CustomerSignPositionEnglish;
            txtCusSignPosVN.Text = contractsSelected.CustomerSignPositionVietnam;
            txtCusSignRepresentative.Text = contractsSelected.CustomerSignRepresentative;
            txtAppendixNo.Text = contractsSelected.AppendixNumber;
            txtPayterms.Text = Convert.ToString(contractsSelected.PaymentTerms);
            this.textCurrencyUnit.Text = contractsSelected.CurrencyUnit;
            txtInsuranceUnitValue.Text = Convert.ToString(contractsSelected.InsuranceUnitValue);
            txtProductMaxValue.Text = Convert.ToString(contractsSelected.ProductMaxValue);
            mmeContractRemark.Text = Convert.ToString(contractsSelected.ContractRemark);
            dtStartDate.EditValue = contractsSelected.StartDate;
            dtEndDate.EditValue = contractsSelected.EndDate;
            dtReviewDate.EditValue = contractsSelected.ReviewDate;
            dtContractDate.EditValue = contractsSelected.ContractDate;
            this.dReturedDate.EditValue = contractsSelected.ReturnedDate;
            cbxInsuranceUnit.EditValue = contractsSelected.InsuranceUnit;
            txtNumberEX.Text = contractsSelected.ContractAccountingNumberEX;
            txtAContNo.Text = contractsSelected.ContractAccountingNumber;
            this.mmContractAccountRemark.Text = contractsSelected.ContractRemarkAccounting;
            txtAccMainID.Text = contractsSelected.AccountingCustomerMainID;
            dAccEndDate.EditValue = contractsSelected.AccountingEndDate;
        }

        private void InitComboboxData()
        {
            //Init InsuranceUnit
            cbxInsuranceUnit.Properties.Items.AddRange(AppSetting.GetInsuranceUnit());

        }

        private void InitLookUpBillingCycle()
        {
            //Init Billing Cycle
            lkeBillingCycle.Properties.DataSource = AppSetting.GetBillingCycle();
            lkeBillingCycle.Properties.ValueMember = "ID";
            lkeBillingCycle.Properties.DisplayMember = "Name";
        }

        private void InitLookUpCustomerName()
        {
            //Init Customer Name
            lkeCustomerNumber.Properties.DataSource = AppSetting.CustomerListAll;
            lkeCustomerNumber.Properties.ValueMember = "CustomerID";
            lkeCustomerNumber.Properties.DisplayMember = "CustomerNumber";
        }

        private void InitLookUpServiceID()
        {
            DataProcess<ServicesDefinition> servicesDefinitionData = new DataProcess<ServicesDefinition>();
            var dataSource = servicesDefinitionData.Select(s => s.Discontinued == false).OrderBy(s => s.ServiceNumber);

            rpi_lke_ServiceDefinition.DataSource = dataSource;
            rpi_lke_ServiceDefinition.DisplayMember = "ServiceNumber";
            rpi_lke_ServiceDefinition.ValueMember = "ServiceID";
        }

        private void InitLookUpMHLWorkDefinitions()
        {
            DataProcess<MHLWorkDefinitions> mhlWorkDefinitionsData = new DataProcess<MHLWorkDefinitions>();
            rpi_lke_MHLWorkDefinition.DataSource = mhlWorkDefinitionsData.Select(m => m.Discontinued == false).OrderBy(m => m.MHLWorkDefinitionNumber);
            rpi_lke_MHLWorkDefinition.DisplayMember = "MHLWorkDefinitionNumber";
            rpi_lke_MHLWorkDefinition.ValueMember = "MHLWorkDefinitionID";
        }
        #endregion
        //private void Init
        private bool isFirstLoad = false;
        #region Events
        private void dtNavigatorContract_PositionChanged(object sender, System.EventArgs e)
        {
            if (this.dtNavigatorContract.Position < 0) return;
            List<ST_WMS_LoadBillingContractData_Result> data = (List<ST_WMS_LoadBillingContractData_Result>)this.dtNavigatorContract.DataSource;
            this.currentContract = data[this.dtNavigatorContract.Position];

            if (this.currentContract != null)
            {
                isFirstLoad = true;
                contractID = this.currentContract.ContractID;
                this.BindingContractData(this.currentContract);
                this.lkeContractStatus.EditValue = Convert.ToInt32(this.currentContract.ContractProgressStatus);
                this.lkeBillingCycle.EditValue = Convert.ToInt32(this.currentContract.BillingCycle);
                this.lkeCustomerNumber.EditValue = (int)this.currentContract.CustomerID;
                this.lkeAccountingStatus.EditValue = Convert.ToInt32(this.currentContract.AccountingStatus);
                this.txtAccountStatusComments.EditValue = this.currentContract.AccountingStatusNote;
                this.textAccountingUpdateBy.EditValue = this.currentContract.AccountingUpdateBy;
                this.textAccountingUpdateTime.EditValue = this.currentContract.AccountingUpdateTime;
                LoadBillingDetail();
                this.LoadBillingLastMonth();
                isFirstLoad = false;
                if (this.currentContract.ContractProgressStatus >= 3)
                {
                    // Has confirmed
                    this.SetControlEnable(false);
                    this.btnEdit.Enabled = false;
                    this.Btn_MSS_Contracts_Update.Enabled = false;
                }
                else
                {
                    // Not confirmed
                    this.SetControlEnable(false);
                }
            }
        }

        private void SetActiveControlByAccountingStatus()
        {
            if (this.currentContract.AccountingStatus != null)
            {
                int status = Convert.ToByte(this.currentContract.AccountingStatus);
                if (status >= 2)
                {
                    // lock controls
                    this.SetControlEnable(false);
                    this.mmeScopeOfWork.ReadOnly = false;
                    this.mmeScopeOfWorkVN.ReadOnly = false;
                    this.dReturedDate.ReadOnly = false;
                    this.lkeContractStatus.ReadOnly = false;
                }
            }
        }

        private void lkeCustomerNumber_EditValueChanged(object sender, System.EventArgs e)
        {
            if (this.lkeCustomerNumber.EditValue == null || this.lkeCustomerNumber.IsModified == false) return;
            int customerID = Convert.ToInt32(this.lkeCustomerNumber.EditValue);
            var currentCuts = AppSetting.CustomerListAll.Where(c => c.CustomerID == customerID).FirstOrDefault();
            this.txtCustomerName.Text = currentCuts.CustomerName;
        }


        private void grvContractEmployeeServices_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName.Equals("WorkDefinitionID"))
            {
                BindingList<ST_WMS_LoadContractEmployeeServicesData_Result> data = (BindingList<ST_WMS_LoadContractEmployeeServicesData_Result>)this.grvContractEmployeeServices.DataSource;
                //string currentJob = this.grvContractEmployeeServices.GetRowCellValue(e.RowHandle, this.grvContractEmployeeServices.Columns["JobName"]).ToString();
                ST_WMS_LoadContractEmployeeServicesData_Result service = data.Where(i => i.WorkDefinitionID == Convert.ToInt32(e.Value)).FirstOrDefault();
                this.grvContractEmployeeServices.SetRowCellValue(e.RowHandle, this.grvContractEmployeeServices.Columns["JobName"], service.JobName);
                this.grvContractEmployeeServices.SetRowCellValue(e.RowHandle, this.grvContractEmployeeServices.Columns["UnitPrice"], service.UnitPrice);
                this.grvContractEmployeeServices.SetRowCellValue(e.RowHandle, this.grvContractEmployeeServices.Columns["Unit"], service.Unit);

                if (isNewRowAdded)
                {
                    this.grvContractEmployeeServices.SetRowCellValue(e.RowHandle, this.grvContractEmployeeServices.Columns["CustomerID"], customerID);
                    this.isNewRowAdded = false;
                }
            }
        }

        private void Rpi_lke_MHLWorkDefinition_EditValueChanged(object sender, EventArgs e)
        {
            this.grvContractEmployeeServices.PostEditor();
        }

        private void grvContractEmployeeServices_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.isServiceModified = true;
        }

        private void grvContractDetail_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.isContractDetailModified = true;
            if (e.Column.FieldName.Equals("ContractServicePrice"))
            {
                if (this.grvContractDetail.FocusedRowHandle == this.grvContractDetail.RowCount - 1)
                {
                    string serviceNameLastRow = Convert.ToString(this.grvContractDetail.GetRowCellValue(this.grvContractDetail.FocusedRowHandle, "ServiceName"));
                    string serviceNameNearLastRow = Convert.ToString(this.grvContractDetail.GetRowCellValue(this.grvContractDetail.FocusedRowHandle - 1, "ServiceName"));
                    if (!string.IsNullOrEmpty(serviceNameLastRow) && !string.IsNullOrEmpty(serviceNameNearLastRow))
                    {
                        var newContractDetail = new ST_WMS_LoadContractDetailData_Result();
                        newContractDetail.VATPercentage = 10;
                        this.bdContractDetails.Add(newContractDetail);
                    }
                }
            }
            DataProcess<object> da = new DataProcess<object>();
            int idContactDetail = Convert.ToInt32(grvContractDetail.GetFocusedRowCellValue("ContractDetailID"));
            switch (e.Column.FieldName)
            {
                case "ServiceID":
                case "CheckingQuantity":
                case "CheckingQuantity2":
                case "ContractDetailRemark":
                case "LineNumber":
                case "ScopeOfWork":
                case "ScopeOFWorkVietnam":
                case "ContractServicePrice ":
                case "CalculatedSQL  ":
                case "ServiceNameInvoiced":
                    int result = da.ExecuteNoQuery("Update ContractDetails set UpdatedBy={0},UpdateTime={1} where ContractDetailID={2} ", AppSetting.CurrentUser.LoginName, DateTime.Now, idContactDetail);
                    break;
            }

        }

        private void grvContractEmployeeServices_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            this.isNewRowAdded = true;
            this.grvContractEmployeeServices.SetRowCellValue(e.RowHandle, this.grvContractEmployeeServices.Columns["ContractEmployeeServiceID"], -1);
        }
        #endregion

        #region Get Current Record Data
        private void GetContract(Contracts contract)
        {
            contract.ContractNumber = this.txtContractNumber.Text;
            contract.ContractRemark = this.mmeContractRemark.Text;
            contract.BillingCycle = Convert.ToByte(this.lkeBillingCycle.EditValue);
            //contract.ContractDate = Convert.ToDateTime(this.dtContractDate.Text);
            contract.ContractDate = this.dtContractDate.DateTime;
            if (this.dReturedDate.EditValue != null) contract.ReturnedDate = this.dReturedDate.DateTime;
            contract.EndDate = this.dtEndDate.DateTime;
            contract.ProductMaxValue = Convert.ToDecimal(this.txtProductMaxValue.Text);
            contract.InsuranceUnitValue = Convert.ToDecimal(this.txtInsuranceUnitValue.Text);
            contract.UpdateTime = DateTime.Now;
            contract.UpdateBy = AppSetting.CurrentUser.LoginName;
            if (dAppendixDate.EditValue != null && !string.IsNullOrEmpty(dAppendixDate.EditValue.ToString())) contract.AppendixDate = dAppendixDate.DateTime;
            contract.CustomerSignEmail = this.txtCusSignEmail.Text;
            contract.CustomerSignGender = this.txtCusSignGender.Text;
            contract.CustomerSignPositionEnglish = this.txtCusSignPosEng.Text;
            contract.CustomerSignPositionVietnam = this.txtCusSignPosVN.Text;
            contract.CustomerSignRepresentative = this.txtCusSignRepresentative.Text;
            contract.AppendixNumber = this.txtAppendixNo.Text;
            contract.ContractProgressStatus = Convert.ToByte(this.lkeContractStatus.EditValue);
            if (this.lkeAccountingStatus.EditValue != null)
                contract.AccountingStatus = Convert.ToByte(this.lkeAccountingStatus.EditValue);
            contract.AccountingStatusNote = this.txtAccountStatusComments.Text;
            contract.AccountingUpdateBy = this.textAccountingUpdateBy.Text;
            if (this.textAccountingUpdateTime.EditValue != null)
                contract.AccountingUpdateTime = Convert.ToDateTime(this.textAccountingUpdateTime.EditValue);
            if (!string.IsNullOrEmpty(this.txtPayterms.Text)) contract.PaymentTerms = Convert.ToInt32(this.txtPayterms.Text);
            contract.CurrencyUnit = this.textCurrencyUnit.Text;
            contract.AccountingCustomerMainID = this.txtAccMainID.Text;
            contract.ContractAccountingNumberEX = this.txtNumberEX.Text;
            contract.ContractAccountingNumber = txtAContNo.Text;
            contract.ContractRemarkAccounting = this.mmContractAccountRemark.Text;
            if (this.dAccEndDate.EditValue != null)
                contract.AccountingEndDate = this.dAccEndDate.DateTime;


            if (String.IsNullOrEmpty(this.cbxInsuranceUnit.Text))
            {
                contract.InsuranceUnit = null;
            }
            else
            {
                contract.InsuranceUnit = this.cbxInsuranceUnit.Text;
            }

            if (this.dtReviewDate.EditValue == null)
            {
                contract.ReviewDate = null;
            }
            else
            {
                contract.ReviewDate = this.dtReviewDate.DateTime;
            }

            if (this.dtStartDate.EditValue == null)
            {
                contract.StartDate = null;
            }
            else
            {
                contract.StartDate = this.dtStartDate.DateTime;
            }
            if (this.textContractMainID.EditValue != null) contract.ContractMainID = Convert.ToInt32(this.textContractMainID.EditValue);
        }

        private void GetCustomer(Customers customer)
        {
            if (customer == null) return;
            customer.CustomerInvoiceName = this.txtCustomerInvoiceName.Text;
            customer.CustomerInvoiceTaxCode = this.txtTaxCode.Text;
            customer.CustomerInvoiceAddress = this.txtCustomerInvoiceAddress.Text;
        }

        private void GetContractDetails(List<ContractDetails> source)
        {
            int rows = this.grvContractDetail.DataRowCount;
            for (int i = 0; i < rows; i++)
            {
                source[i].ServiceID = Convert.ToInt32(this.grvContractDetail.GetRowCellValue(i, this.grvContractDetail.Columns["ServiceID"]));
                source[i].CheckingQuantity = Convert.ToDouble(this.grvContractDetail.GetRowCellValue(i, this.grvContractDetail.Columns["CheckingQuantity"]));
                source[i].CheckingQuantity2 = Convert.ToDouble(this.grvContractDetail.GetRowCellValue(i, this.grvContractDetail.Columns["CheckingQuantity2"]));
                source[i].ContractDetailRemark = Convert.ToString(this.grvContractDetail.GetRowCellValue(i, this.grvContractDetail.Columns["ContractDetailRemark"]));
                source[i].ContractServicePrice = Convert.ToDecimal(this.grvContractDetail.GetRowCellValue(i, grvContractDetail.Columns["ContractServicePrice"]));
            }
        }

        private int GetEmployeeService(List<ContractEmployeeServices> source)
        {
            BindingList<ST_WMS_LoadContractEmployeeServicesData_Result> servicesData = (BindingList<ST_WMS_LoadContractEmployeeServicesData_Result>)this.grvContractEmployeeServices.DataSource;

            int count = servicesData.Count;

            for (int i = 0; i < count; i++)
            {
                if (servicesData[i].CustomerID == customerID)
                {
                    ContractEmployeeServices service = new ContractEmployeeServices();
                    service.CustomerID = servicesData[i].CustomerID;
                    service.ContractDetailID = servicesData[i].ContractDetailID;
                    service.WorkDefinitionID = servicesData[i].WorkDefinitionID;

                    if (servicesData[i].ContractEmployeeServiceID == -1)
                    {
                        service.ContractEmployeeServiceID = servicesData[i - 1].ContractEmployeeServiceID + 1;
                    }
                    source.Add(service);
                }
            }

            return servicesData.FirstOrDefault().ContractEmployeeServiceID;
        }
        #endregion

        private void mmeContractRemark_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void Btn_MSS_Contract_Delete_Click(object sender, EventArgs e)
        {
            if (this.currentContract.AccountingStatus == 2)
            {
                MessageBox.Show("Just allow delete when contract AccountingStatus <2!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (DevExpress.XtraEditors.XtraMessageBox.Show("Are you really want to delete this Contract ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (this.currentContract.ContractProgressStatus >= 1 && this.currentContract.ContractProgressStatus != 4)
                    {
                        MessageBox.Show("Just allow delete contract when it just created or Status = 1!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    DataProcess<ContractDetails> contractDetails = new DataProcess<ContractDetails>();
                    DataProcess<Contracts> contracts = new DataProcess<Contracts>();
                    int contractID = int.Parse(this.txtContractID.Text);
                    int resultContractDetail = contractDetails.ExecuteNoQuery("Delete From ContractDetails Where ContractID = {0}", contractID);
                    int resultContract = contracts.ExecuteNoQuery("Delete From Contracts Where ContractID = {0}", contractID);
                    this.dtNavigatorContract.Position++;
                }
                catch (Exception ex)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            this.SetControlEnable(false);
        }

        private void Btn_MSS_Contract_Edit_Click(object sender, EventArgs e)
        {
            if (this.currentContract.ContractProgressStatus == 3 || this.currentContract.ContractProgressStatus == 5 || this.currentContract.ContractProgressStatus == 6)
            {
                // Has confirmed then not allow edit
                SetControlEnable(false);
                this.btnEdit.Enabled = false;
            }
            else
            {
                SetControlEnable(true);
                this.btnEdit.Enabled = false;
                this.SetActiveControlByAccountingStatus();
            }
            this.CheckActivePriceColumn();
        }

        private void Btn_MSS_Contracts_Update_Click(object sender, EventArgs e)
        {
            if (this.lkeContractStatus.EditValue == null || this.lkeContractStatus.EditValue.Equals(0))
            {
                this.lkeContractStatus.Focus();
                this.lkeContractStatus.ShowPopup();
                return;
            }

            if (dtStartDate.DateTime > dtEndDate.DateTime)
            {
                XtraMessageBox.Show("Start Date <= End Date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.dtStartDate.Focus();
                return;
            }

            if (string.IsNullOrEmpty(this.dtReviewDate.Text))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Insert ReviewDate !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.dtReviewDate.Focus();
                return;
            }

            if (string.IsNullOrEmpty(this.txtAppendixNo.Text))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Insert AppendixNo !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtAppendixNo.Focus();
                return;
            }



            if (string.IsNullOrEmpty(this.txtProductMaxValue.Text) || Convert.ToDecimal(this.txtProductMaxValue.Text) <= 5000)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Product Max Value is incorrect, Product Max Value > 5000 !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    if (!this.dxValidationProvider1.Validate()) return;
                    Wait.Start(this);
                    DataProcess<Customers> customerData = new DataProcess<Customers>();
                    DataProcess<Contracts> contractsData = new DataProcess<Contracts>();
                    DataProcess<ContractDetails> contractDetailsData = new DataProcess<ContractDetails>();
                    DataProcess<ContractEmployeeServices> employeeServiceData = new DataProcess<ContractEmployeeServices>();
                    DataProcess<ServicesDefinition> serviceDefinitionData = new DataProcess<ServicesDefinition>();
                    DataProcess<MHLWorkDefinitions> mhlWorkData = new DataProcess<MHLWorkDefinitions>();

                    //Update Contract
                    int contractID = Convert.ToInt32(this.txtContractID.Text);
                    Contracts currentContract = contractsData.Select(x => x.ContractID == contractID).FirstOrDefault();
                    this.GetContract(currentContract);

                    int result = contractsData.Update(currentContract);

                    //Update ContractDetails
                    if (this.isContractDetailModified)
                    {
                        ContractDetails currentContractDetail = null;
                        // var listUpdate = this.bdContractDetails.Where(pc => pc.IsModified == true).ToArray();
                        foreach (var item in this.bdContractDetails)
                        {
                            if (item.ServiceID == null) continue;
                            var contractDetail = contractDetailsData.Select(c => c.ContractDetailID == item.ContractDetailID).FirstOrDefault();
                            if (contractDetail == null)
                            {
                                currentContractDetail = new ContractDetails();
                                currentContractDetail.UpdatedBy = AppSetting.CurrentUser.LoginName;
                                currentContractDetail.UpdateTime = DateTime.Now;
                                currentContractDetail.ContractID = contractID;
                                currentContractDetail.ServiceID = item.ServiceID;
                                currentContractDetail.CheckingQuantity = item.CheckingQuantity;
                                currentContractDetail.CheckingQuantity2 = item.CheckingQuantity2;
                                currentContractDetail.ContractDetailRemark = item.ContractDetailRemark;
                                currentContractDetail.LineNumber = item.LineNumber;
                                currentContractDetail.ScopeOfWork = item.ScopeOfWork;
                                currentContractDetail.ScopeOFWorkVietnam = item.ScopeOFWorkVietnam;
                                currentContractDetail.ContractServicePrice = item.ContractServicePrice;
                                currentContractDetail.CalculatedSQL = item.CalculatedSQL;
                                if (string.IsNullOrEmpty(item.VATPercentage.ToString()))
                                {
                                    MessageBox.Show("VAT Percentage is null. System will set VAT = 10!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    item.VATPercentage = 10;
                                    //currentContractDetail.VATPercentage = 10;
                                }
                                //else
                                currentContractDetail.VATPercentage = item.VATPercentage;
                                currentContractDetail.ServiceNameInvoiced = item.ServiceNameInvoiced;
                                int resultInsertDetail = contractDetailsData.Insert(currentContractDetail);
                            }
                            else
                            {
                                currentContractDetail = contractDetail;
                                currentContractDetail.ServiceID = item.ServiceID;
                                currentContractDetail.CheckingQuantity = item.CheckingQuantity;
                                currentContractDetail.CheckingQuantity2 = item.CheckingQuantity2;
                                currentContractDetail.ContractDetailRemark = item.ContractDetailRemark;
                                currentContractDetail.ScopeOfWork = item.ScopeOfWork;
                                currentContractDetail.ScopeOFWorkVietnam = item.ScopeOFWorkVietnam;
                                currentContractDetail.ContractServicePrice = item.ContractServicePrice;
                                currentContractDetail.CalculatedSQL = item.CalculatedSQL;
                                currentContractDetail.LineNumber = item.LineNumber;
                                if (string.IsNullOrEmpty(item.VATPercentage.ToString()))
                                {
                                    MessageBox.Show("VAT Percentage is null. System will set VAT = 10!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    item.VATPercentage = 10;
                                    //currentContractDetail.VATPercentage = 10;
                                }
                                //else
                                currentContractDetail.VATPercentage = item.VATPercentage;
                                currentContractDetail.ServiceNameInvoiced = item.ServiceNameInvoiced;
                                // currentContractDetail.UpdatedBy = AppSetting.CurrentUser.LoginName;
                                //currentContractDetail.UpdateTime = DateTime.Now;
                                int resultUpdateDetail = contractDetailsData.Update(currentContractDetail);
                            }

                        }
                    }

                    if (this.isServiceModified)
                    {

                        List<ContractEmployeeServices> services = new List<ContractEmployeeServices>();
                        int lastIndex = this.GetEmployeeService(services);
                        foreach (ContractEmployeeServices item in services)
                        {
                            if (item.ContractEmployeeServiceID > lastIndex)
                            {
                                employeeServiceData.Insert(item);
                            }
                            else
                            {
                                employeeServiceData.Update(item);
                            }
                        }
                    }

                    //Update Customer
                    Customers currentCustomer = customerData.Select(c => c.CustomerID == currentContract.CustomerID).FirstOrDefault();
                    if (currentCustomer != null)
                    {
                        this.GetCustomer(currentCustomer);
                        customerData.Update(currentCustomer);
                    }

                    Wait.Close();

                    //Show Result to User
                    if (result == 1)
                    {
                        SetControlEnable(false);
                        this.btnEdit.Enabled = true;
                        this.isContractDetailModified = false;
                        this.isServiceModified = false;
                    }
                    else
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Update Record Failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }
                catch (Exception ex)
                {
                    Wait.Close();
                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void Btn_MSS_Contracts_ViewTable_Click(object sender, EventArgs e)
        {
            //frm_MSS_ContractViewTable frmContractView = new frm_MSS_ContractViewTable();
            //frmContractView.Show();
        }

        private void Btn_MSS_Contracts_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mmeScopeOfWorkVN_EditValueChanged(object sender, EventArgs e)
        {
            if (!this.mmeScopeOfWorkVN.IsModified) return;
            this.grvContractDetail.SetRowCellValue(this.grvContractDetail.FocusedRowHandle, "ScopeOFWorkVietnam", this.mmeScopeOfWorkVN.Text);
            //this.bdContractDetails[this.grvContractDetail.FocusedRowHandle].ScopeOFWorkVietnam = this.mmeScopeOfWorkVN.Text;
            this.isContractDetailModified = true;
            this.UpdateUserChange(false, this.currentContract.ContractID);
        }

        private void mmeScopeOfWork_EditValueChanged(object sender, EventArgs e)
        {
            if (!this.mmeScopeOfWork.IsModified) return;
            this.grvContractDetail.SetRowCellValue(this.grvContractDetail.FocusedRowHandle, "ScopeOfWork", this.mmeScopeOfWork.Text);
            //this.bdContractDetails[this.grvContractDetail.FocusedRowHandle].ScopeOfWork = this.mmeScopeOfWork.Text;
            this.isContractDetailModified = true;
            this.UpdateUserChange(false, this.currentContract.ContractID);
        }

        private void btnQuotation_Click(object sender, EventArgs e)
        {
            int contractID = Convert.ToInt32(this.txtContractID.Text);
            if (contractID <= 0) return;

            // Get current customer
            var currentCustomer = AppSetting.CustomerListAll.Where(c => c.CustomerID == this.currentContract.CustomerID).FirstOrDefault();

            //hung 20/09/2018
            DataProcess<Contracts> contractDA = new DataProcess<Contracts>();
            var currentQuotation = Convert.ToInt32(contractDA.Select(c => c.ContractID == contractID).FirstOrDefault().QuotationID);
            if (currentQuotation > 0)
            {
                CRM.frm_CRM_Quotation frmQuotation = new CRM.frm_CRM_Quotation(currentQuotation);
                frmQuotation.Show();
                return;
            }
            if (MessageBox.Show("Create new quotation?", "TPWMS", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                return;

            // Create new quotation
            CustomerQuotation newQuotation = new CustomerQuotation();
            newQuotation.CreatedBy = AppSetting.CurrentUser.LoginName;
            newQuotation.CreatedTime = DateTime.Now;
            newQuotation.CustomerID = this.currentContract.CustomerID;
            newQuotation.CustomerInquiryID = 1;
            newQuotation.CustomerMainID = Convert.ToInt32(currentCustomer.CustomerMainID);
            newQuotation.PreviousContractID = this.currentContract.ContractID;
            newQuotation.QuotationDate = DateTime.Now;
            newQuotation.QuotationRemark = this.currentContract.ContractRemark;
            newQuotation.QuotationStatus = 4;
            newQuotation.StoreID = AppSetting.StoreID;

            // Insert new quotation
            DataProcess<CustomerQuotation> quotationDA = new DataProcess<CustomerQuotation>();
            int result = quotationDA.Insert(newQuotation);

            DataProcess<Contracts> contracts = new DataProcess<Contracts>();
            int resultUp = contracts.ExecuteNoQuery("Update Contracts set QuotationID = {0} Where ContractID = {1}", newQuotation.QuotationID, contractID);
            if (result <= 0)
            {
                MessageBox.Show("Create new Quotation is invalid", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Create new quotation details
            CustomerQuotationDetail newQuotationDetail = null;
            IList<CustomerQuotationDetail> quotationDetails = new List<CustomerQuotationDetail>();
            int count = 0;
            foreach (ST_WMS_LoadContractDetailData_Result serviceItem in this.bdContractDetails)
            {
                if (count >= this.bdContractDetails.Count - 1) continue;
                count++;
                newQuotationDetail = new CustomerQuotationDetail();
                newQuotationDetail.CreatedBy = AppSetting.CurrentUser.LoginName;
                newQuotationDetail.CreatedTime = DateTime.Now;
                newQuotationDetail.QuotationDetailRemark = serviceItem.ContractDetailRemark;
                newQuotationDetail.LineNumber = serviceItem.LineNumber;
                newQuotationDetail.QuotationID = newQuotation.QuotationID;
                newQuotationDetail.ServiceDescription = serviceItem.ServiceName;
                newQuotationDetail.ServiceID = Convert.ToInt32(serviceItem.ServiceID);
                newQuotationDetail.ServiceScopeOfWork = serviceItem.ScopeOfWork;
                newQuotationDetail.ServiceScopeOfWorkVietnam = serviceItem.ScopeOFWorkVietnam;
                newQuotationDetail.UnitMeasurement = serviceItem.Measure;
                newQuotationDetail.UnitRate = serviceItem.ContractServicePrice;
                newQuotationDetail.VATPercentage = serviceItem.VATPercentage;
                newQuotationDetail.ServiceNameInvoiced = serviceItem.ServiceNameInvoiced;
                newQuotationDetail.ServiceNameVietnamese = serviceItem.ServiceNameInvoiced;
                quotationDetails.Add(newQuotationDetail);
            }

            // Add new quotation details
            DataProcess<CustomerQuotationDetail> quotationDetailsDA = new DataProcess<CustomerQuotationDetail>();
            result = quotationDetailsDA.Insert(quotationDetails.ToArray());

            if (result > 0)
            {
                // Invoke to quotation form
                CRM.frm_CRM_Quotation frmQuotation = new CRM.frm_CRM_Quotation(newQuotation.QuotationID);
                frmQuotation.Show();
            }
        }

        private void rpi_lke_ServiceDefinition_Validating(object sender, CancelEventArgs e)
        {
            var lke = (LookUpEdit)sender;
            var serviceSelected = (ServicesDefinition)lke.GetSelectedDataRow();
            if (serviceSelected == null) return;

            if (this.bdContractDetails.Where(s => s.ServiceID == serviceSelected.ServiceID).Count() > 0)
            {
                MessageBox.Show("Can not enter the same service!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }

        private void btnCreateDoc_Click(object sender, EventArgs e)
        {
            //frm_CRM_ContractCreate frmCC = new frm_CRM_ContractCreate(Convert.ToInt32(txtContractID.EditValue.ToString()));
            //frmCC.Show();
            //frmCC.WindowState = FormWindowState.Maximized;
        }

        private void dockPanelActiveContracts_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            if (this.lkeCustomerNumber.EditValue == null) return;
            int customerID = Convert.ToInt32(this.lkeCustomerNumber.EditValue);

            if (this.ActiveContracts == null)
            {
                this.ActiveContracts = new urc_CRM_ActiveContracts(customerID);
                this.ActiveContracts.Parent = this.dockPanelActiveContracts;
            }
            else
            {
                this.ActiveContracts.InitActiveContracts(customerID);
            }
            this.ActiveContracts.Show();
            this.ActiveContracts.Dock = DockStyle.Fill;
        }

        private void dockPanelQuotations_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            if (this.lkeCustomerNumber.EditValue == null) return;
            int customerID = Convert.ToInt32(this.lkeCustomerNumber.EditValue);

            if (this.RelatedQuotations == null)
            {
                this.RelatedQuotations = new urc_CRM_RelatedQuotations(customerID);
                this.RelatedQuotations.Parent = this.dockPanelQuotations;
            }
            else
            {
                this.RelatedQuotations.InitData(customerID);
            }
            this.RelatedQuotations.Show();
            this.RelatedQuotations.Dock = DockStyle.Fill;
        }

        private void dockPanel12MonthProfitability_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            if (this.lkeCustomerNumber.EditValue == null) return;
            int customerID = Convert.ToInt32(this.lkeCustomerNumber.EditValue);

            if (this.Profitability == null)
            {
                this.Profitability = new urc_CRM_12MonthProfitability(customerID);
                this.Profitability.Parent = this.dockPanel12MonthProfitability;
            }
            else
            {
                this.Profitability.InitProfitabilityData(customerID);
            }
            this.Profitability.Show();
            this.Profitability.Dock = DockStyle.Fill;
        }

        private void Btn_MSS_Contracts_ViewAppendix_Click(object sender, EventArgs e)
        {
            rptContract rpt = new rptContract();
            var dataSource = FileProcess.LoadTable("STContractPrint " + this.txtContractID.ToString());
            rpt.DataSource = dataSource;
            //rpt.xrQuotationRemark.Text = this.mmRemark.Text;
            subrptProductInquiry subProductInquiry = new subrptProductInquiry();
            subProductInquiry.DataSource = FileProcess.LoadTable("STContractProductInquiries " + this.txtContractID.ToString());
            rpt.xrProductInquiry.ReportSource = subProductInquiry;
            rpt.CreateDocument();
            subrptQuotationScoreOfWork subScopeOfWork = new subrptQuotationScoreOfWork();
            subScopeOfWork.DataSource = dataSource;
            subScopeOfWork.CreateDocument();
            rpt.Pages.AddRange(subScopeOfWork.Pages);
            rpt.PrintingSystem.ContinuousPageNumbering = true;
            int customerID = Convert.ToInt32(this.lkeCustomerNumber.EditValue);
            ReportPrintToolWMS printool = new ReportPrintToolWMS(rpt, customerID);
            printool.ShowPreview();
        }

        private void frm_MSS_Contracts_KeyDown(object sender, KeyEventArgs e)
        {
        }
        private void Btn_MSS_Contracts_ViewAppendx_Click(object sender, EventArgs e)
        {
            rptContract rpt = new rptContract();
            var dataSource = FileProcess.LoadTable("STContractPrint " + this.txtContractID.ToString());
            rpt.DataSource = dataSource;
            //rpt.xrQuotationRemark.Text = this.mmRemark.Text;
            subrptProductInquiry subProductInquiry = new subrptProductInquiry();
            subProductInquiry.DataSource = FileProcess.LoadTable("STContractProductInquiries " + this.txtContractID.ToString());
            rpt.xrProductInquiry.ReportSource = subProductInquiry;
            rpt.CreateDocument();
            subrptQuotationScoreOfWork subScopeOfWork = new subrptQuotationScoreOfWork();
            subScopeOfWork.DataSource = dataSource;
            subScopeOfWork.CreateDocument();
            rpt.Pages.AddRange(subScopeOfWork.Pages);
            rpt.PrintingSystem.ContinuousPageNumbering = true;
            int customerID = Convert.ToInt32(this.lkeCustomerNumber.EditValue);
            ReportPrintToolWMS printool = new ReportPrintToolWMS(rpt, customerID);
            printool.ShowPreview();
        }
        private void Btn_MSS_Contracts_DuplicateContract_Click(object sender, EventArgs e)
        {
            string a = this.lkeCustomerNumber.GetColumnValue("CustomerNumber").ToString().Substring(0, 3);
            if (a == "DSC")
            {
                if (MessageBox.Show("Duplicate contract by change oil price?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {

                }
                else
                {
                    var check = FileProcess.LoadTable("ST_WMS_CheckServiceDiscontinueOnContract " + contractID);
                    var total = Convert.ToInt32(check.Rows[0]["Total"]);
                    if (total > 0)
                    {
                        XtraMessageBox.Show("Has [" + total + "] services is discontinue, please active this services before!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    DataProcess<object> dataProcess = new DataProcess<object>();
                    dataProcess.ExecuteNoQuery("ST_WMS_DuplicateContractDSCByOilPriceChanges " + contractID + ", '" + AppSetting.CurrentUser.LoginName + "'");
                    MessageBox.Show("Duplicate Ok!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            var check1 = FileProcess.LoadTable("ST_WMS_CheckServiceDiscontinueOnContract " + contractID);
            var total1 = Convert.ToInt32(check1.Rows[0]["Total"]);
            if (total1 > 0)
            {
                XtraMessageBox.Show("Has [" + total1 + "] services is discontinue, please active this services before!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //Code here to duplicate contract
            frm_MSS_CustomerChanged frmCustomerChange = new frm_MSS_CustomerChanged();
            if (frmCustomerChange.Enabled == false) return;
            frmCustomerChange.ShowDialog();
            if (frmCustomerChange.CustomerID <= 0 || contractID <= 0) return;
            DataProcess<Contracts> dataProcessContract = new DataProcess<Contracts>();
            DataProcess<ContractDetails> dataProcessContractDetails = new DataProcess<ContractDetails>();
            DataProcess<Discounts> dataDiscounts = new DataProcess<Discounts>();
            DataProcess<DiscountCooperations> dataDiscountCooperations = new DataProcess<DiscountCooperations>();
            Contracts duplicateContract = dataProcessContract.Select(c => c.ContractID == contractID).FirstOrDefault();
            var duplicateContracDetails = dataProcessContractDetails.Select(d => d.ContractID == contractID).ToList();
            duplicateContract.InsuranceUnit = "Kg";
            duplicateContract.InsuranceUnitValue = 30000;
            if (duplicateContract != null)
            {

                duplicateContract.CustomerID = frmCustomerChange.CustomerID;
                duplicateContract.ContractID = 0;
                duplicateContract.ContractRemark = duplicateContract.ContractRemark + " - Dupicate from contract " + contractID;
                //duplicateContract.ContractNumber = "New*_" + contractID;
                //duplicateContract.ContractNumber = "New*_" + duplicateContract.ContractNumber;
                duplicateContract.ContractProgressStatus = 4;
                duplicateContract.AccountingStatus = 0;
                duplicateContract.CreatedBy = AppSetting.CurrentUser.LoginName;
                duplicateContract.CreatedTime = DateTime.Now;
                //duplicateContract.StartDate = null;
                //duplicateContract.EndDate = null;
                //duplicateContract.ReviewDate = null;
                //duplicateContract.ContractDate = null;
                //duplicateContract.AppendixNumber = null;
                duplicateContract.AccountingUpdateBy = null;
                duplicateContract.AccountingUpdateTime = null;
                duplicateContract.ContractAccountingNumber = null;
                duplicateContract.ContractAccountingNumberEX = null;
                duplicateContract.ContractRemarkAccounting = null;
                duplicateContract.AccountingStatusNote = null;
                duplicateContract.AccountingSystemUpdated = false;
                duplicateContract.AccountingSystemUpdatedTime = null;
                duplicateContract.AccountingCustomerMainID = null;
                duplicateContract.AccountingEndDate = null;
                duplicateContract.QuotationID = null;
                duplicateContract.ContractMainID = null;
                duplicateContract.InsuranceUnit = "Kg";
                duplicateContract.InsuranceUnitValue = 30000;
            }
            int newContractID = dataProcessContract.Insert(duplicateContract);
            if (newContractID <= 0) return;
            int result0 = this._billingContractData.ExecuteNoQuery("Update Contracts set ContractMainID = ContractID where ContractID= " + newContractID);

            foreach (var detail in duplicateContracDetails)
            {
                detail.ContractDetailID = 0;
                detail.ContractID = duplicateContract.ContractID;
                detail.UpdateTime = DateTime.Now;
                detail.UpdatedBy = AppSetting.CurrentUser.LoginName;
            }
            var lstDC = dataDiscounts.Select(x => x.CustomerID == frmCustomerChange.CustomerID && x.ContractID == contractID);
            foreach (var objDC in lstDC)
            {
                Discounts newDiscount = new Discounts();
                newDiscount.DiscountNumber = objDC.DiscountNumber;
                newDiscount.Description = objDC.Description;
                newDiscount.CustomerID = objDC.CustomerID;
                newDiscount.ContractID = duplicateContract.ContractID;
                newDiscount.Measure = objDC.Measure;
                newDiscount.MeasureVietnam = objDC.MeasureVietnam;
                newDiscount.FromValue = objDC.FromValue;
                newDiscount.ToValue = objDC.ToValue;
                newDiscount.FromDate = objDC.FromDate;
                newDiscount.ToDate = objDC.ToDate;
                newDiscount.CreatedBy = AppSetting.CurrentUser.LoginName;
                newDiscount.CreatedTime = DateTime.Now;
                newDiscount.Status = "New";
                dataDiscounts.Insert(newDiscount);
            }
            var lstDCC = dataDiscountCooperations.Select(x => x.CustomerID == frmCustomerChange.CustomerID && x.ContractID == contractID);
            foreach (var objDCC in lstDCC)
            {
                DiscountCooperations newDiscountCooperations = new DiscountCooperations();
                newDiscountCooperations.CooperationTime = objDCC.CooperationTime;
                newDiscountCooperations.Month = objDCC.Month;
                newDiscountCooperations.CustomerID = objDCC.CustomerID;
                newDiscountCooperations.ContractID = duplicateContract.ContractID;
                newDiscountCooperations.DiscountValue = objDCC.DiscountValue;
                newDiscountCooperations.CreatedBy = AppSetting.CurrentUser.LoginName;
                newDiscountCooperations.CreatedTime = DateTime.Now;
                dataDiscountCooperations.Insert(newDiscountCooperations);
            }
            int result = dataProcessContractDetails.Insert(duplicateContracDetails.ToArray());
            if (result > 0)
            {
                this.InitData(0, duplicateContract.ContractID);
                MessageBox.Show("Check ContractNumber, StartDate, EndDate, ReviewDate, ContractDate, AppendixNumber on new contract!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void grvContractDetail_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if (e == null || e.PrevFocusedColumn == null) return;
            if (!e.PrevFocusedColumn.FieldName.Equals("ContractServicePrice")) return;
            int contractDetailID = Convert.ToInt32(this.grvContractDetail.GetFocusedRowCellValue("ServiceID"));
            if (contractDetailID <= 0) return;
            string price = Convert.ToString(this.grvContractDetail.GetFocusedRowCellValue("ContractServicePrice"));
            if (string.IsNullOrEmpty(price))
            {
                this.grvContractDetail.FocusedColumn = this.colPrice;
                this.grvContractDetail.SetColumnError(this.colPrice, "Contract price is required");
            }
        }

        private void btnCloseAndLiquidate_Click(object sender, EventArgs e)
        {
            if (this.currentContract.ContractProgressStatus.Equals(6))
            {
                MessageBox.Show("This contract has liquidated!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.currentContract.ContractProgressStatus.Equals(5))
            {
                MessageBox.Show("This contract has closed!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Convert.ToInt16(this.lkeContractStatus.EditValue) != 3)
            {
                XtraMessageBox.Show("You can only close / liquidate completed contract", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.dtEndDate.DateTime > DateTime.Now)
            {
                if (MessageBox.Show("Liquidate contract having end date > today?", "TPWMS", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                {
                    return;
                }
                else
                {
                    this.lkeContractStatus.EditValue = 6;
                    this.Btn_MSS_Contracts_Update_Click(sender, e);
                    return;
                }

            }

            //Tạm thời bỏ xem xét các điều kiện khi Liqudate
            //if (this.dtEndDate.DateTime > DateTime.Now)
            //{
            //    XtraMessageBox.Show("You cannot close / liquidate contract having end date before today", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //// Find contracts by this customer 
            //var contractCouts = FileProcess.LoadTable("Select ContractID,StartDate,EndDate from Contracts where CustomerID="
            //    + this.lkeCustomerNumber.EditValue + " and EndDate>GETDATE()");
            //if (contractCouts.Rows.Count > 1)
            //{
            //    // Found contracts
            //    int maxContractID = Convert.ToInt32(contractCouts.Rows[contractCouts.Rows.Count - 1]["ContractID"]);
            //    if (this.currentContract.ContractID == maxContractID)
            //    {
            //        MessageBox.Show("This contract is Latest contract so you can't close it", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }
            //    else
            //    {
            //        // initialize a new XtraInputBoxArgs instance 
            //        XtraInputBoxArgs args = new XtraInputBoxArgs();
            //        // set required Input Box options 
            //        args.Caption = "End date options";
            //        args.Prompt = "End Date";
            //        args.DefaultButtonIndex = 0;
            //        args.Showing += Args_Showing;
            //        // initialize a DateEdit editor with custom settings 
            //        DateEdit editor = new DateEdit();
            //        editor.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.TouchUI;
            //        editor.Properties.Mask.EditMask = "dd/MM/yyyy";
            //        args.Editor = editor;
            //        // a default DateEdit value 
            //        args.DefaultResponse = DateTime.Now.Date.AddDays(3);
            //        // display an Input Box with the custom editor 
            //        var result = XtraInputBox.Show(args).ToString();
            //        // set a dialog icon 
            //        if (result == null) return;
            //        this.currentContract.EndDate = Convert.ToDateTime(result);
            //        this.dtEndDate.DateTime = (Convert.ToDateTime(result));
            //    }
            //}
            //else
            //{
            //    // Not found contract to close and liquidate
            //    return;
            //}

            this.lkeContractStatus.EditValue = 5;
            this.Btn_MSS_Contracts_Update_Click(sender, e);
            //code to update the ContractProgressStatus to 6
        }

        private void Args_Showing(object sender, XtraMessageShowingArgs e)
        {
            e.Form.Icon = this.Icon;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // Code to check the attachement? Có attachement mới cho phép Confirm
            //code to update the ContractProgressStatus to 3 
            if (Convert.ToInt32(this.lkeContractStatus.EditValue) == 5 || Convert.ToInt32(this.lkeContractStatus.EditValue) == 6)
            {
                MessageBox.Show("Can not change!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (!this.CheckHasAttachedFiles())
            {
                MessageBox.Show("Please attach files pdf before confirm this contract!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.lkeContractStatus.EditValue = 3;
            this.dReturedDate.EditValue = DateTime.Now.Date;
            this.Btn_MSS_Contracts_Update_Click(sender, e);
        }

        private void lkeContractStatus_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (!e.Value.Equals(3)) return;
            if (!this.CheckHasAttachedFiles())
            {
                MessageBox.Show("Please attach files before confirm this contract!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.AcceptValue = false;
            }
            this.UpdateUserChange(false, this.currentContract.ContractID);
        }

        /// <summary>
        /// Check this contract has attached files
        /// </summary>
        /// <returns></returns>
        private bool CheckHasAttachedFiles()
        {
            var dataSource = FileProcess.LoadTable("ST_WMS_CheckAttachmentByOrder @OrderNumber='" + this.txtContractNumber.Text + "',@Appendix='" + txtAppendixNo.Text.ToString() + "'");
            int countValue = Convert.ToInt16(dataSource.Rows[0]["Counts"]);
            if (countValue > 0) return true;
            else return false;
        }



        private void txtCustomerName_Click(object sender, EventArgs e)
        {
            if (this.lkeCustomerNumber.EditValue == null) return;
            Customers customer = AppSetting.CustomerListAll.Where(c => c.CustomerID == Convert.ToInt32(this.lkeCustomerNumber.EditValue)).FirstOrDefault();
            frm_MSS_Customers frmCustomer = MasterSystemSetup.frm_MSS_Customers.Instance;
            frmCustomer.CurrentCustomers = customer;
            frmCustomer.WindowState = FormWindowState.Normal;
            frmCustomer.BringToFront();
            frmCustomer.Show();

        }

        private void Btn_MSS_Contracts_New_Click(object sender, EventArgs e)
        {

        }

        private void dockPanelCostStructure_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            if (this.lkeCustomerNumber.EditValue == null) return;
            int customerID = Convert.ToInt32(this.lkeCustomerNumber.EditValue);

            if (this.CostStructure == null)
            {
                this.CostStructure = new urc_CRM_CostStructure(customerID);
                this.CostStructure.Parent = this.dockPanelCostStructure;
            }
            else
            {
                this.CostStructure.InitCostStructure(customerID);
            }
            this.CostStructure.Show();
            this.CostStructure.Dock = DockStyle.Fill;
        }

        private void dockPanelPricesHistory_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            if (this.lkeCustomerNumber.EditValue == null) return;
            int customerID = Convert.ToInt32(this.lkeCustomerNumber.EditValue);

            if (this.RatesHistory == null)
            {
                this.RatesHistory = new urc_CRM_RatesHistory(customerID);
                this.RatesHistory.Parent = this.dockPanelPricesHistory;
            }
            else
            {
                this.RatesHistory.InitRateHistory(customerID);
            }
            this.RatesHistory.Show();
            this.RatesHistory.Dock = DockStyle.Fill;
        }

        private void dockPanel36MonthOperation_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            if (this.lkeCustomerNumber.EditValue == null) return;
            int customerID = Convert.ToInt32(this.lkeCustomerNumber.EditValue);

            if (this.monthOperation == null)
            {
                this.monthOperation = new urc_CRM_36MonthsOperation(customerID, 0);
                this.monthOperation.Parent = this.dockPanel36MonthOperation;
            }
            else
            {
                this.monthOperation.init36MonthsOperation(customerID, 0);
            }
            this.monthOperation.Show();
            this.monthOperation.Dock = DockStyle.Fill;
        }

        private void txtContractNumber_Properties_DoubleClick(object sender, EventArgs e)
        {
            if (!this.txtContractNumber.ReadOnly)
            {
                string newContractNumber = "ECV-" + this.lkeCustomerNumber.GetColumnValue("CustomerNumber").ToString() + "-" + DateTime.Today.Year + "-" + contractID;
                if (MessageBox.Show("Do you want to update the Contract Number to the new value : " + newContractNumber, "Edit", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    this.txtContractNumber.EditValue = newContractNumber;
                else
                    return;
            }
            else
            {
                XtraMessageBox.Show("Can not generate new contractNumber, Eidt is disabled !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rpi_hle_CostBreakdown_Click(object sender, EventArgs e)
        {
            //Click here to open form Cost Breakdown

            frm_CRM_CostBreakdown frm = new frm_CRM_CostBreakdown(Convert.ToInt32(this.lkeCustomerNumber.EditValue), Convert.ToInt32(this.grvContractDetail.GetFocusedRowCellValue("ServiceID")));
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;

        }

        private void frm_MSS_Contracts_Activated(object sender, EventArgs e)
        {
            if (this.txtContractNumber.Tag == null) return;
            contractID = (int)this.txtContractNumber.Tag;
        }

        private void rpi_lke_ServiceDefinition_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            var serviceSource = this.rpi_lke_ServiceDefinition.DataSource;
            if (serviceSource == null) return;
            int serviceID = Convert.ToInt32(e.Value);
            var lke = (LookUpEdit)sender;
            var serviceSelected = ((IEnumerable<ServicesDefinition>)serviceSource).Where(s => s.ServiceID == serviceID).FirstOrDefault();
            if (serviceSelected == null) return;

            if (this.bdContractDetails.Where(s => s.ServiceID == serviceSelected.ServiceID).Count() > 0)
            {
                MessageBox.Show("Can not enter the same service!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int rowIndex = this.grvContractDetail.FocusedRowHandle;
            this.grvContractDetail.SetRowCellValue(rowIndex, this.grvContractDetail.Columns["ServiceName"], serviceSelected.ServiceName);
            this.grvContractDetail.SetRowCellValue(rowIndex, this.grvContractDetail.Columns["ServiceNameInvoiced"], serviceSelected.ServiceNameVietnamese);
            this.grvContractDetail.SetRowCellValue(rowIndex, this.grvContractDetail.Columns["Measure"], serviceSelected.Measure);
            this.grvContractDetail.SetRowCellValue(rowIndex, this.grvContractDetail.Columns["MeasureVietnam"], serviceSelected.MeasureVietnam);
            this.grvContractDetail.SetRowCellValue(rowIndex, this.grvContractDetail.Columns["ContractServicePrice"], serviceSelected.ServicePrice);
            this.grvContractDetail.SetRowCellValue(rowIndex, this.grvContractDetail.Columns["ScopeOfWork"], serviceSelected.ScopeOfWork);
            this.grvContractDetail.SetRowCellValue(rowIndex, this.grvContractDetail.Columns["ScopeOFWorkVietnam"], serviceSelected.ScopeOFWorkVietnam);
            this.grvContractDetail.SetRowCellValue(rowIndex, this.grvContractDetail.Columns["ServiceID"], serviceSelected.ServiceID);
            this.grvContractDetail.SetRowCellValue(rowIndex, this.grvContractDetail.Columns["ServiceType"], serviceSelected.ServiceType);
            this.mmeScopeOfWork.Text = serviceSelected.ScopeOfWork;
            this.mmeScopeOfWorkVN.Text = serviceSelected.ScopeOFWorkVietnam;
        }

        private void dtStartDate_EditValueChanged(object sender, EventArgs e)
        {
            if (isFirstLoad) return;
            this.UpdateUserChange(false, this.currentContract.ContractID);
            if (this.dxValidationProvider1.Validate()) return;
        }

        private void txtAppendixNo_EditValueChanged(object sender, EventArgs e)
        {
            if (isFirstLoad) return;
            this.UpdateUserChange(false, this.currentContract.ContractID);
            if (this.dxValidationProvider1.Validate()) return;
        }

        private void dtEndDate_EditValueChanged(object sender, EventArgs e)
        {
            if (isFirstLoad) return;
            this.UpdateUserChange(false, this.currentContract.ContractID);
            if (this.dxValidationProvider1.Validate()) return;
        }

        private void dtReviewDate_EditValueChanged(object sender, EventArgs e)
        {
            if (isFirstLoad) return;
            this.UpdateUserChange(false, this.currentContract.ContractID);
            if (this.dxValidationProvider1.Validate()) return;
        }

        private void dtContractDate_EditValueChanged(object sender, EventArgs e)
        {
            if (isFirstLoad) return;
            this.UpdateUserChange(false, this.currentContract.ContractID);
            if (this.dxValidationProvider1.Validate()) return;
        }

        private void lkeAccountingStatus_EditValueChanged(object sender, EventArgs e)
        {


            if (this.lkeAccountingStatus.EditValue == null) return;
            this.textAccountingUpdateBy.EditValue = AppSetting.CurrentUser.LoginName;
            this.textAccountingUpdateTime.EditValue = DateTime.Now;
            int statusValue = Convert.ToInt32(this.lkeAccountingStatus.EditValue);
            if (statusValue > 1)
            {
                if (!this.CheckHasAttachedFiles() && this.currentContract.ContractProgressStatus != 2)
                {
                    MessageBox.Show("Please attach files pdf before release contract!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //this.lkeAccountingStatus.EditValue = 0;
                    //return;
                }
                this.LockControls(true);
            }
            else
            {
                this.LockControls(false);
            }
            this.UpdateUserChange(false, this.currentContract.ContractID);
        }

        private void txtAccountStatusComments_EditValueChanged(object sender, EventArgs e)
        {
            this.textAccountingUpdateBy.EditValue = AppSetting.CurrentUser;
            this.textAccountingUpdateTime.EditValue = DateTime.Now;
        }
        private void LockControls(bool isLocked)
        {
            this.dtStartDate.ReadOnly = isLocked;
            this.dtEndDate.ReadOnly = isLocked;
            this.grvContractDetail.OptionsBehavior.ReadOnly = isLocked;
        }
        private void UpdateUserChange(bool isDetails, int id)
        {
            DataProcess<Contracts> dataProcess = new DataProcess<Contracts>();
            if (isDetails)
            {
                // Update contract details
                dataProcess.ExecuteNoQuery("Update ContractDetails set UpdatedBy={0},UpdateTime={1} where ContractDetailID={2}", AppSetting.CurrentUser.LoginName, DateTime.Now, id);
            }
            else
            {
                // Update contract
                dataProcess.ExecuteNoQuery("Update Contracts set UpdatedBy={0},UpdateTime={1} where ContractID={2}", AppSetting.CurrentUser.LoginName, DateTime.Now, id);
            }
        }

        private void txtContractNumber_EditValueChanged(object sender, EventArgs e)
        {
            this.UpdateUserChange(false, this.currentContract.ContractID);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.lkeContractStatus.EditValue) == 3 || Convert.ToInt32(this.lkeContractStatus.EditValue) == 5 || Convert.ToInt32(this.lkeContractStatus.EditValue) == 6)
            {
                MessageBox.Show("Can not change!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.lkeContractStatus.EditValue = 2;
            this.dReturedDate.EditValue = DateTime.Now.Date;
            this.Btn_MSS_Contracts_Update_Click(sender, e);
        }

        private void dockPanel4_Click(object sender, EventArgs e)
        {

        }

        private void txtCustomerInvoiceName_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void txtCusSignEmail_EditValueChanged(object sender, EventArgs e)
        {
            if (txtCusSignEmail.IsModified)
            {
                DataProcess<Contracts> dataProcess = new DataProcess<Contracts>();
                dataProcess.ExecuteNoQuery("Update contracts set CustomerSignEmail=N'" + this.txtCusSignEmail.Text + "' Where contractID={0}", this.currentContract.ContractID);
            }
        }

        private void txtCusSignRepresentative_EditValueChanged(object sender, EventArgs e)
        {
            if (txtCusSignRepresentative.IsModified)
            {
                DataProcess<Contracts> dataProcess = new DataProcess<Contracts>();
                dataProcess.ExecuteNoQuery("Update contracts set CustomerSignRepresentative=N'" + this.txtCusSignRepresentative.Text + "' Where contractID={0}", this.currentContract.ContractID);
            }
        }

        private void txtCusSignGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtCusSignGender.IsModified)
            {
                DataProcess<Contracts> dataProcess = new DataProcess<Contracts>();
                dataProcess.ExecuteNoQuery("Update contracts set CustomerSignGender=N'" + this.txtCusSignGender.Text + "' Where contractID={0}", this.currentContract.ContractID);
            }
        }

        private void txtCusSignPosEng_EditValueChanged(object sender, EventArgs e)
        {
            if (txtCusSignPosEng.IsModified)
            {
                DataProcess<Contracts> dataProcess = new DataProcess<Contracts>();
                dataProcess.ExecuteNoQuery("Update contracts set CustomerSignPositionEnglish=N'" + this.txtCusSignPosEng.Text + "' Where contractID={0}", this.currentContract.ContractID);
            }
        }

        private void txtCusSignPosVN_EditValueChanged(object sender, EventArgs e)
        {
            if (txtCusSignPosVN.IsModified)
            {
                DataProcess<Contracts> dataProcess = new DataProcess<Contracts>();
                dataProcess.ExecuteNoQuery("Update contracts set CustomerSignPositionVietnam=N'" + this.txtCusSignPosVN.Text + "' Where contractID={0}", this.currentContract.ContractID);
            }
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }
        private bool hasSpecialChar(string input)
        {
            string specialChar = @"~!@#$%^&*£§€|<>";
            foreach (var item in specialChar)
            {
                if (input.Contains(item)) return true;
            }

            return false;
        }
        private void grvContractDetail_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (this.grvContractDetail.FocusedRowHandle < 0) return;
            switch (this.grvContractDetail.FocusedColumn.FieldName)
            {
                case "ServiceNameInvoiced":
                    if (e.Value.ToString().Length < 1 || e.Value.ToString().Length > 60)
                    {
                        e.ErrorText = "Length this column > 0 and <= 60";
                        e.Valid = false;
                    }
                    if (hasSpecialChar(e.Value.ToString()))
                    {
                        e.ErrorText = "Has Special Char";
                        e.Valid = false;
                    }
                    else
                        e.Value = e.Value.ToString().Trim().ToUpper();
                    break;

            }
        }

        private void dockPanelDiscountInfo_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            if (this.lkeCustomerNumber.EditValue == null) return;
            int customerID = Convert.ToInt32(this.lkeCustomerNumber.EditValue);

            if (this.DiscountInfo == null)
            {
                this.DiscountInfo = new urc_CRM_DiscountInfo(customerID, this.currentContract.ContractID);
                this.DiscountInfo.Parent = this.dockPanelDiscountInfo;
            }
            else
            {
                this.DiscountInfo.InitDiscountInfo(customerID, this.currentContract.ContractID);
            }
            this.DiscountInfo.Show();
            this.DiscountInfo.Dock = DockStyle.Fill;
        }

        private void grvContractEmployeeServices_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            var ContractEmployeeServiceID = ((DA.ST_WMS_LoadContractEmployeeServicesData_Result)e.Row).ContractEmployeeServiceID;
            if (ContractEmployeeServiceID > 0)
            {
                DataProcess<ContractEmployeeServices> employeeServiceDA = new DataProcess<ContractEmployeeServices>();
                var contractServiceUpdate = employeeServiceDA.Select(cs => cs.ContractEmployeeServiceID == ContractEmployeeServiceID).FirstOrDefault();
                employeeServiceDA.Delete(contractServiceUpdate);
            }
        }

        private void lkeAccountingStatus_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (!lkeAccountingStatus.IsModified) return;
            if (Convert.ToInt32(e.NewValue) > 1 && Convert.ToInt32(this.lkeContractStatus.EditValue) < 4)
            {
                MessageBox.Show("Please changed contract status before release contract!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }

        private void btnCloseContractBefore_Click(object sender, EventArgs e)
        {

        }

        private void btnCloseBefore_Click(object sender, EventArgs e)
        {
            if (this.currentContract.ContractProgressStatus.Equals(6))
            {
                MessageBox.Show("This contract has liquidated!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.currentContract.ContractProgressStatus.Equals(5))
            {
                MessageBox.Show("This contract has closed!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.dtEndDate.DateTime > DateTime.Now)
            {
                if (MessageBox.Show("Contract is still valid do you want to close it?", "TPWMS", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                {
                    return;
                }
                else
                {
                    this.lkeContractStatus.EditValue = 5;
                    this.Btn_MSS_Contracts_Update_Click(sender, e);
                    return;
                }

            }
        }
    }
}
