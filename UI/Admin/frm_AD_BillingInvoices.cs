using Common.Controls;
using DA;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UI.Helper;
using UI.WarehouseManagement;
using UI.APIs;
using DevExpress.XtraGrid.Views.Grid;

namespace UI.Admin
{
    public partial class frm_AD_BillingInvoices : frmBaseForm
    {
        private BindingList<BillingInvoice> BillingInvoicesList;
        private BindingList<BillingInvoiceDetail> BillingInvoicesDetailsList;
        private BillingInvoice currentBillingInvoices;
        private DataProcess<BillingInvoice> billingDA = new DataProcess<BillingInvoice>();
        private DataProcess<BillingInvoiceDetail> billingDetailDA = new DataProcess<BillingInvoiceDetail>();
        private Customers currentCustomer = null;
        private bool isFirstLoad = false;
        private APIProcess api = null;
        private Stores currentStore = null;


        public frm_AD_BillingInvoices()
        {
            InitializeComponent();
            LoadPaymentMethod();
            LoadStore();
            LoadCustomer();
            LoadCurrency();
            LoadEmployee();
            LoadServices();
            Init();
            this.Enabled = true;
            this.colVAT.OptionsColumn.AllowEdit = false;
        }
        public frm_AD_BillingInvoices(int BillingInvoicesID)
        {
            InitializeComponent();
            LoadPaymentMethod();
            LoadStore();
            LoadCustomer();
            LoadCurrency();
            LoadEmployee();
            LoadServices();
            Init_BillingInvoicesID(BillingInvoicesID);
            this.Enabled = true;
            this.colVAT.OptionsColumn.AllowEdit = false;
        }

        private void Init_BillingInvoicesID(int BillingInvoicesID)
        {
            // code here to load only 1 BillingInvoice
            this.Init(BillingInvoicesID);
        }


        private void Init(int billingInvoiceID = 0)
        {
            IList<BillingInvoice> dataSource = null;
            if (billingInvoiceID > 0)
            {
                dataSource = billingDA.Select(b => b.BillingInvoiceID == billingInvoiceID).ToList();
            }
            else
            {
                DateTime olddate = DateTime.Today.AddDays(-7);
                dataSource = billingDA.Select(b => b.StoreID == AppSetting.StoreID && b.isDeleted == false && b.CreatedTime > olddate).ToList();
            }

            if (dataSource == null || dataSource.Count() <= 0)
            {
                this.BillingInvoicesList = new BindingList<BillingInvoice>();
            }
            else
            {
                bool hasAdd = false;
                if (dataSource.Count == 1)
                {
                    dataSource.Add(dataSource[0]);
                    hasAdd = true;
                }
                this.BillingInvoicesList = new BindingList<BillingInvoice>(dataSource);
                this.dtngBillingInvoices.DataSource = this.BillingInvoicesList;
                this.dtngBillingInvoices.Position = this.BillingInvoicesList.Count - 1;
                if (hasAdd) this.BillingInvoicesList.RemoveAt(1);

            }

            if (this.txtEInvNum.Text == "" || this.txtEInvNum.Text == null)
                this.layoutControlItemEmailReport.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

            else
                this.layoutControlItemEmailReport.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

        }

        private void LoadServiceList()
        {
            //string billingInvoiceDate = ((DateTime)this.currentBillingInvoices.CreatedTime).ToString("yyyy-MM-dd");
            //this.rpi_lke_ContractDetails.DataSource = FileProcess.LoadTable("ST_WMS_BillingInvoiceServiceDetails @FromDate='" + billingInvoiceDate
            //    + "',@Todate='" + billingInvoiceDate + "',@CustomerID=" + this.currentBillingInvoices.CustomerID);
            //this.rpi_lke_ContractDetails.ValueMember = "ServiceNumber";
            //this.rpi_lke_ContractDetails.DisplayMember = "ServiceNumber";
        }

        private void Update(int savePsosition)
        {//

        }
        private void LoadServices()
        {
            //using (PlantDBContext context = new PlantDBContext())
            //{
            //    this.rpi_lke_part.DataSource = context.GetComboStoreNo("SELECT ServiceID, ServiceNumber, ServiceName FROM ServicesDefinition ORDER BY ServiceNumber");
            //    this.rpi_lke_part.DropDownRows = 20;
            //    this.rpi_lke_part.DisplayMember = "ServiceNumber";
            //    this.rpi_lke_part.ValueMember = "ServiceName";
            //}
        }
        private void LoadEmployee()
        {
            //lkeClearBy.Properties.DataSource = AppSetting.EmployessList;
            //int employeeCount = AppSetting.EmployessList.Count();
            //if (employeeCount > 20)
            //    lkeClearBy.Properties.DropDownRows = 20;
            //else
            //    lkeClearBy.Properties.DropDownRows = employeeCount;
            //lkeClearBy.Properties.DisplayMember = "VietnamName";
            //lkeClearBy.Properties.ValueMember = "EmployeeID";
        }

        private void LoadCurrency()
        {
            List<string> lst = new List<string>();
            lst.Add("VND");
            lst.Add("USD");
            lst.Add("HKD");
            lst.Add("AUD");
            lst.Add("EUR");
            this.lkeCurrency.Properties.DataSource = lst;
            this.lkeCurrency.EditValue = "VND";
        }
        private void LoadPaymentMethod()
        {
            List<string> lst = new List<string>();
            lst.Add("CK");//Chuyển khoản
            lst.Add("TM");//Tiền mặt
            lst.Add("CK/TM");//Chuyển khoản hoặc TM
            this.lkePaymentMethod.Properties.DataSource = lst;
            this.lkePaymentMethod.EditValue = "TM/CK";
        }
        private void LoadStore()
        {
            DataProcess<Stores> storeDA = new DataProcess<Stores>();
            this.lkeStores.Properties.DataSource = storeDA.Select();
            this.lkeStores.Properties.ValueMember = "StoreID";
            this.lkeStores.Properties.DisplayMember = "StoreDescription";
            this.lkeStores.EditValue = AppSetting.CurrentUser.StoreID;
            this.currentStore = storeDA.Select(s => s.StoreID == AppSetting.StoreID).FirstOrDefault();
        }
        private void LoadCustomer()
        {
            this.lkeCustomers.Properties.DataSource = AppSetting.CustomerList.OrderBy(b => b.CustomerNumber);
            this.lkeCustomers.Properties.ValueMember = "CustomerID";
            this.lkeCustomers.Properties.DisplayMember = "CustomerNumber";
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtngBillingInvoices_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyData == Keys.Left)
            //    dtngBillingInvoices.Position = dtngBillingInvoices.Position - 1;
            //else if (e.KeyData == Keys.Right)
            //    dtngBillingInvoices.Position = dtngBillingInvoices.Position + 1;
            //else if (e.KeyData == Keys.Up)
            //    dtngBillingInvoices.Position = 0;
            //else if (e.KeyData == Keys.Down)
            //    dtngBillingInvoices.Position = ((IList<BillingInvoices>)dtngBillingInvoices.DataSource).Count;
        }

        private void dtngBillingInvoices_PositionChanged(object sender, EventArgs e)
        {
            //updateInfoBillingInvoices();
            //currentBillingInvoices = BillingInvoicesList.ElementAt(dtngBillingInvoices.Position);
            //saveCurrentBillingInvoices = currentBillingInvoices;
            //UpdateControlsBy(currentBillingInvoices);
            //UpdateControlStatus();
            //if (this.layoutControlUpdate.Visibility == DevExpress.XtraLayout.Utils.LayoutVisibility.Always)
            //    updateData();
            isFirstLoad = true;
            Control[] listCtrs = new Control[this.dxValidationProvider1.GetInvalidControls().Count];
            for (int i = 0; i < listCtrs.Length; i++)
            {
                listCtrs[i] = this.dxValidationProvider1.GetInvalidControls()[i];
            }
            foreach (var item in listCtrs)
            {
                this.dxValidationProvider1.RemoveControlError(item);
            }
            if (this.dtngBillingInvoices.Position < 0) return;
            this.currentBillingInvoices = this.BillingInvoicesList[this.dtngBillingInvoices.Position];
            if (string.IsNullOrEmpty(this.currentBillingInvoices.ConfirmedBy))
            {
                this.needUpdate(true);
            }
            else
            {
                this.needUpdate(false);
            }
            isFirstLoad = false;
            if (this.dtngBillingInvoices.Position == 0) return;
            this.BindingData();

        }

        private void enableControl(byte blStatus = 2)
        {

        }

        private void BindingData()
        {
            if (this.currentBillingInvoices == null) return;
            this.txtBillingInvoicesRecordNumber.EditValue = this.currentBillingInvoices.BillingInvoiceNumber;
            this.txtCreatedBy.EditValue = this.currentBillingInvoices.CreatedBy;
            this.txtCreatedTime.EditValue = this.currentBillingInvoices.CreatedTime;
            this.lkeCustomers.EditValue = this.currentBillingInvoices.CustomerID;
            this.lkeStores.EditValue = this.currentBillingInvoices.StoreID;
            this.dteInvoiceDate.EditValue = this.currentBillingInvoices.IssueDate;
            this.textBillingID.EditValue = this.currentBillingInvoices.BillingID;
            //this.textAccInvNumber.EditValue = this.currentBillingInvoices.AccInvNumber;
            //this.textAccBatchNumber.EditValue = this.currentBillingInvoices.AccInvBatchNumber;
            this.lkeCurrency.EditValue = this.currentBillingInvoices.InvoiceCurrency;
            this.lkePaymentMethod.EditValue = this.currentBillingInvoices.PaymentMethod;
            this.txtEInvNum.EditValue = this.currentBillingInvoices.E_InvoiceNumber;
            //this.textEInvCode.EditValue = this.currentBillingInvoices.E_InvoiceControlCode;
            //this.textEInvLink.EditValue = this.currentBillingInvoices.E_InvoiceLink;
            this.textInvPeriod.EditValue = this.currentBillingInvoices.InvoicePeriod;
            this.memoInvRemark.EditValue = this.currentBillingInvoices.BillingInvoiceRemark;
            this.txtConfirmedBy.EditValue = this.currentBillingInvoices.ConfirmedBy;
            this.txtConfirmedTime.EditValue = this.currentBillingInvoices.ConfirmedTime;
            this.txtBuyer.EditValue = this.currentBillingInvoices.Buyer;
            this.txtPONo.EditValue = this.currentBillingInvoices.PONumber;
            this.txtPayDays.EditValue = this.currentBillingInvoices.PaymentDays;
            this.textInvoiceAmount.EditValue = this.currentBillingInvoices.NetAmount;
            this.textVATAmount.EditValue = this.currentBillingInvoices.VATAmount;
            this.textGrossAmount.EditValue = this.currentBillingInvoices.GrossAmount;
            this.textGrossAmountWording.EditValue = this.currentBillingInvoices.GrossAmountWording;
            this.textCurrencyExchangeRate.EditValue = this.currentBillingInvoices.CurrencyExchangRate;
            this.txtCustomerName.Text = this.currentBillingInvoices.CustomerName;
            this.textCustomerAddress.Text = this.currentBillingInvoices.CustomerAddress;
            this.textCustomerTaxCode.Text = this.currentBillingInvoices.CustomerTaxCode;
            this.colVAT.OptionsColumn.AllowEdit = false;
            if (string.IsNullOrEmpty(this.currentBillingInvoices.ConfirmedBy))
                this.ActiveControls(false);
            else
                this.ActiveControls(true);
            this.LoadBIDetails();
        }
        private void ActiveControls(bool isOnlyView)
        {

            // Check confirmed
            this.lkeCustomers.Properties.ReadOnly = isOnlyView;
            this.lkeStores.Properties.ReadOnly = isOnlyView;
            this.dteInvoiceDate.ReadOnly = isOnlyView;
            this.textBillingID.ReadOnly = isOnlyView;
            this.lkeCurrency.ReadOnly = isOnlyView;
            this.lkePaymentMethod.ReadOnly = isOnlyView;
            this.textInvPeriod.ReadOnly = isOnlyView;
            this.memoInvRemark.ReadOnly = isOnlyView;
            this.txtBuyer.ReadOnly = isOnlyView;
            this.txtPONo.ReadOnly = isOnlyView;
            this.txtPayDays.ReadOnly = isOnlyView;
            this.textCurrencyExchangeRate.ReadOnly = isOnlyView;

            this.textInvoiceAmount.ReadOnly = isOnlyView;
            this.textVATAmount.ReadOnly = isOnlyView;
            this.textGrossAmount.ReadOnly = isOnlyView;
            this.textGrossAmountWording.ReadOnly = isOnlyView;

            //this.txtConfirmedBy.ReadOnly = isOnlyView;
            //this.txtConfirmedTime.ReadOnly = isOnlyView;
            //this.txtEInvNum.ReadOnly = isOnlyView;      

            this.txtCustomerName.ReadOnly = isOnlyView;
            this.textCustomerAddress.ReadOnly = isOnlyView;
            this.textCustomerTaxCode.ReadOnly = isOnlyView;
            this.colAmount.OptionsColumn.AllowEdit = !isOnlyView;
            this.colBreak.OptionsColumn.AllowEdit = !isOnlyView;
            this.colCode.OptionsColumn.AllowEdit = !isOnlyView;
            this.colDel.OptionsColumn.AllowEdit = !isOnlyView;
            this.colPrice.OptionsColumn.AllowEdit = !isOnlyView;
            this.colQty.OptionsColumn.AllowEdit = !isOnlyView;
            this.colServiceName.OptionsColumn.AllowEdit = !isOnlyView;
            this.colUOM.OptionsColumn.AllowEdit = !isOnlyView;
            this.colVATPercent.OptionsColumn.AllowEdit = !isOnlyView;
            this.colRemark.OptionsColumn.AllowEdit = !isOnlyView;
            this.btn_Delete.Enabled = !isOnlyView;
            this.btn_accept.Enabled = !isOnlyView;
            this.btnEditVAT.Enabled = !isOnlyView;

            if (!isOnlyView) // not yet confirmed
            {
                this.layoutControlDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                this.layoutControlEditVAT.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                if (this.currentBillingInvoices.BillingID == null ||
                this.currentBillingInvoices.BillingID <= 0) //Manual Billing Invoices
                {
                    this.lkeCustomers.Properties.ReadOnly = false;
                    this.lkeStores.Properties.ReadOnly = false;
                    this.txtCustomerName.ReadOnly = false;
                    this.textCustomerAddress.ReadOnly = false;
                    this.textCustomerTaxCode.ReadOnly = false;
                    this.colAmount.OptionsColumn.AllowEdit = true;
                    //this.colBreak.OptionsColumn.AllowEdit = true;
                    this.colCode.OptionsColumn.AllowEdit = true;
                    this.colDel.OptionsColumn.AllowEdit = true;
                    this.colPrice.OptionsColumn.AllowEdit = true;
                    this.colQty.OptionsColumn.AllowEdit = true;
                    this.colServiceName.OptionsColumn.AllowEdit = true;
                    this.colUOM.OptionsColumn.AllowEdit = true;
                    this.colVATPercent.OptionsColumn.AllowEdit = true;
                    this.colRemark.OptionsColumn.AllowEdit = true;
                    this.layoutControlUpdateFooter.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;


                }
                else //Automatic create invoice; do not allow to change customers and many other texts
                {
                    this.lkeCustomers.Properties.ReadOnly = true;
                    this.lkeStores.Properties.ReadOnly = true;
                    this.txtCustomerName.ReadOnly = true;
                    this.textCustomerAddress.ReadOnly = true;
                    this.textCustomerTaxCode.ReadOnly = true;
                    this.colAmount.OptionsColumn.AllowEdit = false;
                    //this.colBreak.OptionsColumn.AllowEdit = false;
                    this.colCode.OptionsColumn.AllowEdit = false;
                    this.colDel.OptionsColumn.AllowEdit = false;
                    this.colPrice.OptionsColumn.AllowEdit = false;
                    this.colQty.OptionsColumn.AllowEdit = false;
                    this.colServiceName.OptionsColumn.AllowEdit = false;
                    this.colUOM.OptionsColumn.AllowEdit = false;
                    this.colVATPercent.OptionsColumn.AllowEdit = false;
                    this.colRemark.OptionsColumn.AllowEdit = false;
                    this.layoutControlUpdateFooter.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }
            }
            else //confirmed 
            {
                this.layoutControlDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                this.layoutControlUpdateFooter.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                this.layoutControlUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                this.layoutControlEditVAT.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                this.grvBillingInvoiceDetails.OptionsBehavior.ReadOnly = false;
                this.colAmount.OptionsColumn.AllowEdit = false;
                this.colBreak.OptionsColumn.AllowEdit = false;
                this.colCode.OptionsColumn.AllowEdit = false;
                this.colDel.OptionsColumn.AllowEdit = false;
                this.colPrice.OptionsColumn.AllowEdit = false;
                this.colQty.OptionsColumn.AllowEdit = false;
                this.colServiceName.OptionsColumn.AllowEdit = false;
                this.colUOM.OptionsColumn.AllowEdit = false;
                //this.colVAT.OptionsColumn.AllowEdit = false;
                this.colVATPercent.OptionsColumn.AllowEdit = false;
                this.colRemark.OptionsColumn.AllowEdit = true;
            }

        }

        private void LoadBIDetails()
        {
            if (this.currentBillingInvoices == null) return;
            this.LoadServiceList();
            var dataSource = this.billingDetailDA.Select(b => b.BillingInvoiceID == this.currentBillingInvoices.BillingInvoiceID).ToList();
            if (dataSource == null || dataSource.Count <= 0)
            {
                dataSource = new List<BillingInvoiceDetail>();
            }
            this.BillingInvoicesDetailsList = new BindingList<BillingInvoiceDetail>(dataSource);
            var newBillingDetail = new BillingInvoiceDetail();
            newBillingDetail.BillingInvoiceID = this.currentBillingInvoices.BillingInvoiceID;
            newBillingDetail.CreatedBy = AppSetting.CurrentUser.LoginName;
            newBillingDetail.CreatedTime = DateTime.Now;
            this.BillingInvoicesDetailsList.Add(newBillingDetail);
            this.grcBillingInvoiceDetails.DataSource = this.BillingInvoicesDetailsList;

            bool isAllowEdit = true;
            // Set edit column on grid
            if (this.currentBillingInvoices.BillingID > 0)
            {
                isAllowEdit = false;
            }
            this.colCode.OptionsColumn.AllowEdit = isAllowEdit;
            this.colServiceName.OptionsColumn.AllowEdit = isAllowEdit;
            this.colUOM.OptionsColumn.AllowEdit = isAllowEdit;
            this.colQty.OptionsColumn.AllowEdit = isAllowEdit;
            this.colAmount.OptionsColumn.AllowEdit = isAllowEdit;
            this.colVAT.OptionsColumn.AllowEdit = isAllowEdit;
        }

        private void btn_NewBillingInvoices_Click(object sender, EventArgs e)
        {
            //Code to add new record to the Table BillingInvoice here
            var newBillingInvoide = new BillingInvoice();
            newBillingInvoide.CreatedBy = AppSetting.CurrentUser.LoginName;
            newBillingInvoide.CreatedTime = DateTime.Now;
            newBillingInvoide.BillingID = 0;
            newBillingInvoide.BillingInvoiceEndDate = DateTime.Today;
            newBillingInvoide.BillingInvoiceRemark = "Manual Invoice";
            newBillingInvoide.InvoiceCurrency = "VND";
            newBillingInvoide.IssueDate = DateTime.Today;
            newBillingInvoide.InvoicePeriod = DateTime.Today.ToString("MM-yyyy");
            newBillingInvoide.PaymentMethod = "CK/TM";
            newBillingInvoide.PaymentDays = 14;
            newBillingInvoide.StoreID = AppSetting.StoreID;

            this.ActiveControls(true);
            this.BillingInvoicesList.Add(newBillingInvoide);
            this.dtngBillingInvoices.DataSource = this.BillingInvoicesList;
            this.dtngBillingInvoices.Position = this.BillingInvoicesList.Count - 1;
            this.lkeCustomers.ShowPopup();
        }

        private void grvPettyDetails_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            //grvPettyDetails.SetRowCellValue(e.RowHandle, "ExpensesDate", DateTime.Now.Date);
            //grvPettyDetails.SetRowCellValue(e.RowHandle, "Quantity", 1);

            //BillingInvoicesDetails pcd = this.BillingInvoicesDetailsList[grvPettyDetails.GetFocusedDataSourceRowIndex()];
            //using (PlantDBContext context = new PlantDBContext())
            //{
            //    string sql = String.Format("insert into PettyDetails (BillingInvoicesID, " +
            //                    "Quantity, PartID, ExpensesDate, ItemDescription) " +
            //                    "Values ('{0}','{1}','{2}','{3}','{4}')",
            //                    this.currentBillingInvoices.BillingInvoicesID,
            //                    pcd.Quantity,
            //                    pcd.PartID,
            //                    pcd.ExpensesDate.ToString(),
            //                    pcd.PartName
            //                    );
            //    context.Delete(sql);
            //}
            //LoadBIDetails();
        }


        private void btn_Update_Click(object sender, EventArgs e)
        {
            updateData();
        }

        private void updateData()
        {
            if (this.currentBillingInvoices == null) return;
            if (this.currentBillingInvoices.BillingInvoiceID > 0)
            {

                // update
                this.billingDA.Update(this.currentBillingInvoices);
                this.BillingInvoicesList[this.dtngBillingInvoices.Position] = this.currentBillingInvoices;
            }
            else
            {
                // insert
                int result = this.billingDA.Insert(this.currentBillingInvoices);
                if (result > 0)
                    this.currentBillingInvoices.BillingInvoiceIDHash = this.billingDA.Select(b => b.BillingInvoiceID == this.currentBillingInvoices.BillingInvoiceID).FirstOrDefault().BillingInvoiceIDHash;
            }
            XtraMessageBox.Show("TPWMS", "Update success!", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (this.currentBillingInvoices == null) return;
            //if (this.BillingInvoicesDetailsList.Where(b => b.BillingInvoiceDetailID > 0).Count() > 0)
            //{
            //    XtraMessageBox.Show("Please delete Billing Invoice Details before delete this Billing Invoice", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            if (this.currentBillingInvoices.ConfirmedBy != null) return;
            if (this.currentBillingInvoices.BillingInvoiceID > 0)
            {
                var dlConfirm = XtraMessageBox.Show("Are you sure to delete this billing invoice!", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlConfirm.Equals(DialogResult.No)) return;
                var reason = XtraInputBox.Show("Input reason", "Reason?", "");
                if (string.IsNullOrEmpty(reason)) return;
                this.currentBillingInvoices.isDeleted = true;
                this.currentBillingInvoices.DeleteReason = reason;
                this.billingDA.Update(this.currentBillingInvoices);
                this.Init();
            }
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
        }

        private void btn_accept_Click(object sender, EventArgs e)
        {
            //Code here to confirm the Billing INvoice
            if (this.currentBillingInvoices == null) return;
            if (this.currentBillingInvoices.BillingInvoiceID <= 0) return;

            if (!this.dxValidationProvider1.Validate()) return;
            // Check user Permission
            if (!string.IsNullOrEmpty(this.currentBillingInvoices.ConfirmedBy))
            {
                // Un-Confirm
                // Check user has permission
                if (!UserPermission.CheckAdminDepartment(AppSetting.CurrentUser.LoginName)
                    && string.IsNullOrEmpty(this.currentBillingInvoices.E_InvoiceUploadedBy))
                {
                    XtraMessageBox.Show("Just only Admin to access grant un-confirm billing invoice", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                this.currentBillingInvoices.ConfirmedBy = null;
                this.currentBillingInvoices.ConfirmedTime = null;
                this.ActiveControls(false);
            }
            else
            {
                // Confirm
                this.currentBillingInvoices.ConfirmedBy = AppSetting.CurrentUser.LoginName;
                this.currentBillingInvoices.ConfirmedTime = DateTime.Now;
                this.txtConfirmedBy.Text = this.currentBillingInvoices.ConfirmedBy;
                this.txtConfirmedTime.Text = this.currentBillingInvoices.ConfirmedTime.ToString();
                this.ActiveControls(true);
            }

            this.billingDA.Update(this.currentBillingInvoices);
            XtraMessageBox.Show("TPWMS", "Confirm success!", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btn_NewItem_Click(object sender, EventArgs e)
        {
            //
        }

        private void frm_AD_BillingInvoices_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoadServices();
        }

        private void btn_PrintAdvance_Click(object sender, EventArgs e)
        {
            //Code to 
        }

        private void btn_PrintExpense_Click(object sender, EventArgs e)
        {
            //
        }

        private void btn_ItemReview_Click(object sender, EventArgs e)
        {
            //
        }

        private void lkeCustomers_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (this.currentBillingInvoices == null || e.Value == null) return;
            if (this.currentBillingInvoices.BillingInvoiceID <= 0)
            {
                this.currentBillingInvoices.CustomerID = Convert.ToInt32(e.Value);
                int result = this.billingDA.Insert(this.currentBillingInvoices);
                if (result > 0)
                    this.currentBillingInvoices.BillingInvoiceIDHash = this.billingDA.Select(b => b.BillingInvoiceID == this.currentBillingInvoices.BillingInvoiceID).FirstOrDefault().BillingInvoiceIDHash;
                this.ActiveControls(false);
            }
            this.currentBillingInvoices.BillingInvoiceNumber = "IV-" + this.currentBillingInvoices.BillingInvoiceID;
            this.txtBillingInvoicesRecordNumber.Text = this.currentBillingInvoices.BillingInvoiceNumber;
            this.currentBillingInvoices.CustomerID = Convert.ToInt32(e.Value);
            this.currentCustomer = AppSetting.CustomerListAll.Where(c => c.CustomerID == this.currentBillingInvoices.CustomerID).FirstOrDefault();
            this.currentBillingInvoices.CustomerName = this.currentCustomer.CustomerInvoiceName;
            this.currentBillingInvoices.CustomerAddress = this.currentCustomer.CustomerInvoiceAddress;
            this.currentBillingInvoices.CustomerTaxCode = this.currentCustomer.CustomerInvoiceTaxCode;
            this.txtCustomerName.Text = this.currentCustomer.CustomerInvoiceName;
            this.textCustomerAddress.Text = this.currentCustomer.CustomerInvoiceAddress;
            this.textCustomerTaxCode.Text = this.currentCustomer.CustomerInvoiceTaxCode;
            needUpdate(true);
        }

        private void lkeCustomers_EditValueChanged(object sender, EventArgs e)
        {
            this.txtCustomerName.Text = "";
            this.textCustomerAddress.Text = "";
            this.textCustomerTaxCode.Text = "";
            if (this.lkeCustomers.EditValue == null) return;
            int customerID = Convert.ToInt32(this.lkeCustomers.EditValue);
            if (customerID == 0)//the lookup edit is readonly
                return;
            this.currentCustomer = AppSetting.CustomerListAll.Where(c => c.CustomerID == customerID).FirstOrDefault();

            this.txtCustomerName.Text = this.currentCustomer.CustomerInvoiceName;
            this.textCustomerAddress.Text = this.currentCustomer.CustomerInvoiceAddress;
            this.textCustomerTaxCode.Text = this.currentCustomer.CustomerInvoiceTaxCode;
        }


        private void lkeStores_EditValueChanged(object sender, EventArgs e)
        {
            if (lkeStores.IsModified && !this.isFirstLoad)
            {
                this.currentBillingInvoices.StoreID = Convert.ToInt32(lkeStores.EditValue);
            }
        }

        private void dteInvoiceDate_EditValueChanged(object sender, EventArgs e)
        {
            if (dteInvoiceDate.IsModified && !this.isFirstLoad)
            {
                this.currentBillingInvoices.IssueDate = Convert.ToDateTime(dteInvoiceDate.EditValue);
            }
        }

        private void textBillingID_EditValueChanged(object sender, EventArgs e)
        {
            if (textBillingID.IsModified && !this.isFirstLoad)
            {
                this.currentBillingInvoices.BillingID = Convert.ToInt32(textBillingID.EditValue);
            }
        }

        //private void textAccInvNumber_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (textAccInvNumber.IsModified && !this.isFirstLoad)
        //    {
        //        this.currentBillingInvoices.AccInvNumber = textAccInvNumber.Text;
        //    }
        //}

        //private void textAccBatchNumber_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (textAccBatchNumber.IsModified && !this.isFirstLoad)
        //    {
        //        this.currentBillingInvoices.AccInvBatchNumber = textAccBatchNumber.Text;
        //    }
        //}

        private void lkeCurrency_EditValueChanged(object sender, EventArgs e)
        {
            if (lkeCurrency.IsModified && !this.isFirstLoad)
            {
                this.currentBillingInvoices.InvoiceCurrency = Convert.ToString(lkeCurrency.EditValue);
            }
        }

        private void lkePaymentMethod_EditValueChanged(object sender, EventArgs e)
        {
            if (lkePaymentMethod.IsModified && !this.isFirstLoad)
            {
                this.currentBillingInvoices.PaymentMethod = Convert.ToString(lkePaymentMethod.EditValue);
            }
        }

        private void txtEInvNum_EditValueChanged(object sender, EventArgs e)
        {
            if (txtEInvNum.IsModified && !this.isFirstLoad)
            {
                this.currentBillingInvoices.E_InvoiceNumber = Convert.ToString(txtEInvNum.EditValue);
            }
        }

        //private void textEInvCode_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (textEInvCode.IsModified && !this.isFirstLoad)
        //    {
        //        this.currentBillingInvoices.E_InvoiceControlCode = Convert.ToString(textEInvCode.EditValue);
        //    }
        //}

        //private void textEInvLink_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (textEInvLink.IsModified && !this.isFirstLoad)
        //    {
        //        this.currentBillingInvoices.E_InvoiceLink = Convert.ToString(textEInvLink.EditValue);
        //    }
        //}

        private void memoInvRemark_EditValueChanged(object sender, EventArgs e)
        {
            if (memoInvRemark.IsModified && !this.isFirstLoad)
            {
                this.currentBillingInvoices.BillingInvoiceRemark = Convert.ToString(memoInvRemark.EditValue);
            }
        }

        private void grvBillingInvoiceDetails_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle < 0 || e.Value == null) return;
            BillingInvoiceDetail detailInfo = null;
            int billingInvoiceDetailID = Convert.ToInt32(this.grvBillingInvoiceDetails.GetFocusedRowCellValue("BillingInvoiceDetailID"));
            switch (e.Column.FieldName)
            {
                case "ServiceQuantity":
                    if (billingInvoiceDetailID <= 0) return;
                    detailInfo = this.BillingInvoicesDetailsList.Where(id => id.BillingInvoiceDetailID.Equals(billingInvoiceDetailID)).FirstOrDefault();
                    this.billingDetailDA.Update(detailInfo);
                    break;
                case "UOM":
                case "UnitPrice":
                    if (billingInvoiceDetailID <= 0) return;
                    detailInfo = this.BillingInvoicesDetailsList.Where(id => id.BillingInvoiceDetailID.Equals(billingInvoiceDetailID)).FirstOrDefault();
                    if (detailInfo.UnitPrice != null && detailInfo.ServiceQuantity != null)
                    {
                        detailInfo.Amount = detailInfo.UnitPrice * detailInfo.ServiceQuantity;
                        this.grvBillingInvoiceDetails.SetFocusedRowCellValue("Amount", detailInfo.Amount);
                    }
                    this.billingDetailDA.Update(detailInfo);
                    break;
                case "Amount":
                case "VATPercentage":
                    if (billingInvoiceDetailID <= 0) return;
                    detailInfo = this.BillingInvoicesDetailsList.Where(id => id.BillingInvoiceDetailID.Equals(billingInvoiceDetailID)).FirstOrDefault();
                    if (detailInfo.Amount != null && detailInfo.VATPercentage != null)
                    {
                        detailInfo.VATAmount = detailInfo.Amount * detailInfo.VATPercentage / 100;
                        this.grvBillingInvoiceDetails.SetFocusedRowCellValue("VATAmount", detailInfo.VATAmount);
                    }
                    this.billingDetailDA.Update(detailInfo);
                    break;
                case "BillingInvoiceDetailRemark":
                case "ServiceCode":
                    if (billingInvoiceDetailID <= 0)
                    {
                        // Insert
                        detailInfo = new BillingInvoiceDetail();
                        detailInfo.BillingInvoiceID = this.currentBillingInvoices.BillingInvoiceID;
                        detailInfo.CreatedBy = AppSetting.CurrentUser.LoginName;
                        detailInfo.CreatedTime = DateTime.Now;
                        detailInfo.ServiceCode = Convert.ToString(e.Value);
                        this.billingDetailDA.Insert(detailInfo);
                        this.BillingInvoicesDetailsList[e.RowHandle].BillingInvoiceDetailID = detailInfo.BillingInvoiceDetailID;
                        var newBillingDetail = new BillingInvoiceDetail();
                        newBillingDetail.BillingInvoiceID = this.currentBillingInvoices.BillingInvoiceID;
                        newBillingDetail.CreatedBy = AppSetting.CurrentUser.LoginName;
                        newBillingDetail.CreatedTime = DateTime.Now;
                        this.BillingInvoicesDetailsList.Add(newBillingDetail);
                    }
                    else
                    {
                        detailInfo = this.BillingInvoicesDetailsList.Where(id => id.BillingInvoiceDetailID.Equals(billingInvoiceDetailID)).FirstOrDefault();
                        this.billingDetailDA.Update(detailInfo);
                    }

                    break;
                case "ServiceName":
                    if (billingInvoiceDetailID <= 0) return;
                    detailInfo = this.BillingInvoicesDetailsList.Where(id => id.BillingInvoiceDetailID.Equals(billingInvoiceDetailID)).FirstOrDefault();
                    this.billingDetailDA.Update(detailInfo);
                    break;
            }
        }

        private void txtBuyer_EditValueChanged(object sender, EventArgs e)
        {
            if (txtBuyer.IsModified && !this.isFirstLoad)
            {
                this.currentBillingInvoices.Buyer = this.txtBuyer.Text;
            }
        }

        private void txtPONo_EditValueChanged(object sender, EventArgs e)
        {
            if (txtPONo.IsModified && !this.isFirstLoad)
            {
                this.currentBillingInvoices.PONumber = this.txtPONo.Text;
            }
        }

        private void txtPayDays_EditValueChanged(object sender, EventArgs e)
        {
            if (txtPayDays.IsModified && !this.isFirstLoad)
            {
                this.currentBillingInvoices.PaymentDays = Convert.ToInt16(this.txtPayDays.EditValue);
            }
        }

        private void frm_AD_BillingInvoices_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                this.ShowAttachment();
            }
        }

        private void grcBillingInvoiceDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                this.ShowAttachment();
            }
        }

        private void ShowAttachment()
        {
            frm_WM_Attachments.Instance.OrderNumber = this.currentBillingInvoices.BillingInvoiceNumber;
            frm_WM_Attachments.Instance.CustomerID = Convert.ToInt32(this.currentBillingInvoices.CustomerID);
            if (!frm_WM_Attachments.Instance.Enabled) return;
            frm_WM_Attachments.Instance.ShowDialog();
        }

        private void grvBillingInvoiceDetails_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void layoutControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                this.ShowAttachment();
            }
        }

        private void rpi_btn_Delete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (this.grvBillingInvoiceDetails.FocusedRowHandle < 0) return;
            if (this.currentBillingInvoices.ConfirmedBy != null & this.currentBillingInvoices.ConfirmedBy != "")
            {
                XtraMessageBox.Show("Can not delete confirmed Invoices !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            BillingInvoiceDetail currentBillingInvoiceDetail = (BillingInvoiceDetail)this.grvBillingInvoiceDetails.GetRow(this.grvBillingInvoiceDetails.FocusedRowHandle);
            billingDetailDA.Delete(currentBillingInvoiceDetail);
            this.LoadBIDetails();
        }

        private void textCurrencyExchangeRate_EditValueChanged(object sender, EventArgs e)
        {
            if (textCurrencyExchangeRate.EditValue == null) return;
            if (textCurrencyExchangeRate.IsModified && !this.isFirstLoad)
            {
                this.currentBillingInvoices.CurrencyExchangRate = Convert.ToInt32(textCurrencyExchangeRate.EditValue);
                //UpdateFooter();
            }
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            int customerID = Convert.ToInt32(this.currentBillingInvoices.CustomerID);
            int billingInvoiceID = Convert.ToInt32(this.currentBillingInvoices.BillingInvoiceID);
            string billingInvoiceNumber = Convert.ToString(this.currentBillingInvoices.BillingInvoiceNumber);
            string e_InvoiceNumber = Convert.ToString(this.currentBillingInvoices.E_InvoiceNumber);
            DataProcess<Attachments> dataProcess = new DataProcess<Attachments>();
            if (string.IsNullOrEmpty(e_InvoiceNumber))
            {
                XtraMessageBox.Show("Wrong Invoice !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else

            {
                var currentCustomer = AppSetting.CustomerListAll.Where(c => c.CustomerID == customerID).FirstOrDefault();
                string subject = "Billing Invoice Report From KNM  Logistics VN - " + currentCustomer.CustomerName + " Period: " + currentBillingInvoices.InvoicePeriod;
                List<Attachments> listAttachments = dataProcess.Select(a => a.OrderNumber == billingInvoiceNumber && a.IsDeleted == false).ToList();

                if (listAttachments == null || listAttachments.Count <= 0)
                {
                    XtraMessageBox.Show("No attachment to send !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }
                else
                {
                    frm_WM_Attachments.Instance.SendMail(currentCustomer.Email, subject, subject, listAttachments);
                }


            }

        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.F3)
            {
                frm_WM_Attachments.Instance.OrderNumber = Convert.ToString(this.currentBillingInvoices.BillingInvoiceNumber);
                frm_WM_Attachments.Instance.CustomerID = Convert.ToInt32(this.currentBillingInvoices.CustomerID);
                if (frm_WM_Attachments.Instance.Enabled)
                {
                    frm_WM_Attachments.Instance.ShowDialog();
                }
            }
            return base.ProcessDialogKey(keyData);
        }

        private void textInvPeriod_EditValueChanged(object sender, EventArgs e)
        {
            if (textInvPeriod.EditValue == null) return;
            if (textInvPeriod.IsModified && !this.isFirstLoad)
            {
                this.currentBillingInvoices.InvoicePeriod = textInvPeriod.Text;
            }
            needUpdate(true);
        }

        private void btnUpdateManual_Click(object sender, EventArgs e)
        {
            UpdateFooter();
        }

        private void UpdateFooter()
        {
            DataProcess<Stores> dp = new DataProcess<Stores>();
            dp.ExecuteNoQuery("STBillingInvoiceUpdateFooter " + this.currentBillingInvoices.BillingInvoiceID + ",'" + AppSetting.CurrentUser.LoginName + "'");
            this.Init(this.currentBillingInvoices.BillingInvoiceID);
        }

        private void txtCustomerName_EditValueChanged(object sender, EventArgs e)
        {
            if (txtCustomerName.EditValue == null) return;
            if (txtCustomerName.IsModified && !this.isFirstLoad)
            {
                this.currentBillingInvoices.CustomerName = txtCustomerName.Text;
            }
            needUpdate(true);
        }

        private void textCustomerAddress_EditValueChanged(object sender, EventArgs e)
        {
            if (textCustomerAddress.EditValue == null) return;
            if (textCustomerAddress.IsModified && !this.isFirstLoad)
            {
                this.currentBillingInvoices.CustomerAddress = textCustomerAddress.Text;
            }
            needUpdate(true);
        }

        private void textCustomerTaxCode_EditValueChanged(object sender, EventArgs e)
        {
            if (textCustomerTaxCode.EditValue == null) return;
            if (textCustomerTaxCode.IsModified && !this.isFirstLoad)
            {
                this.currentBillingInvoices.CustomerTaxCode = textCustomerTaxCode.Text;
            }
            needUpdate(true);
        }


        private void needUpdate(bool nU)
        {
            if (nU == true)
                this.layoutControlUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            else
                this.layoutControlUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }

        private void rpi_btn_Break_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (this.currentBillingInvoices.ConfirmedBy != null || this.currentBillingInvoices.ConfirmedBy == "") return;
            if (this.grvBillingInvoiceDetails.FocusedRowHandle < 0) return;
            string origQty = this.grvBillingInvoiceDetails.GetFocusedRowCellValue("ServiceQuantity").ToString();
            var result = XtraInputBox.Show("Enter a quantity to break this service", "Billing Invoice Detail Break", origQty);
            if (result == null || string.IsNullOrEmpty(result)) return;

            float newQty = 0; float oriQty = 0;
            float.TryParse(result, out newQty);
            oriQty = (float)Math.Round(float.Parse(origQty));
            if (newQty <= 0 || newQty >= oriQty)
            {
                MessageBox.Show("Quanity is not correct !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int billingInvoiceDetailID = Convert.ToInt32(this.grvBillingInvoiceDetails.GetFocusedRowCellValue("BillingInvoiceDetailID"));
            DataProcess<object> dataProcess = new DataProcess<object>();
            string sSQL = ("EXEC STBillingInvoiceDetailBreak " + billingInvoiceDetailID + "," + newQty + ",'" + AppSetting.CurrentUser.LoginName + "'");
            dataProcess.ExecuteNoQuery(sSQL);
            //BillingInvoiceDetail currentBillingInvoiceDetail = (BillingInvoiceDetail)this.grvBillingInvoiceDetails.GetRow(this.grvBillingInvoiceDetails.FocusedRowHandle);
            //billingDetailDA.Delete(currentBillingInvoiceDetail);
            this.LoadBIDetails();
        }

        private void btnBreakInvoice_Click(object sender, EventArgs e)
        {
            if (this.currentBillingInvoices.ConfirmedBy != null) return;
            if (this.grvBillingInvoiceDetails.SelectedRowsCount <= 0)
            {
                MessageBox.Show("Please select details to break !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string billingInvoiceDetailID = "";
            int count = 0;
            foreach (var index in this.grvBillingInvoiceDetails.GetSelectedRows())
            {
                billingInvoiceDetailID += grvBillingInvoiceDetails.GetRowCellValue(index, "BillingInvoiceDetailID");
                if (count < this.grvBillingInvoiceDetails.SelectedRowsCount - 1)
                    billingInvoiceDetailID += ",";
                count++;
            }

            string sSQL = ("EXEC STBillingInvoiceBreak '" + billingInvoiceDetailID + "'," + currentBillingInvoices.BillingInvoiceID + ",'" + AppSetting.CurrentUser.LoginName + "'");
            DataProcess<object> dataProcess = new DataProcess<object>();
            dataProcess.ExecuteNoQuery(sSQL);
            this.LoadBIDetails();
            //Open the newly created BillingInvoice
        }

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            frm_AD_BillingInvoiceImportExcel frm = new frm_AD_BillingInvoiceImportExcel();
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront();
        }

        public string xmlCancelInv(string fkey)
        {
            StringBuilder xml = new StringBuilder();
            xml.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            xml.Append("<soap12:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap12=\"http://www.w3.org/2003/05/soap-envelope\">");
            xml.Append("<soap12:Body>");
            xml.Append("<cancelInv xmlns=\"http://tempuri.org/\">");
            xml.Append("<Account>" + this.currentStore.E_Invoice_AdminUser + "</Account>");
            xml.Append("<ACpass>" + this.currentStore.E_Invoice_AdminPassword + "</ACpass>");
            xml.Append("<fkey>" + fkey + "</fkey>");
            xml.Append("<userName>" + this.currentStore.E_Invoice_UserName + "</userName>");
            xml.Append("<userPass>" + this.currentStore.E_Invoice_Password + "</userPass>");
            xml.Append("</cancelInv>");
            xml.Append("</soap12:Body>");
            xml.Append("</soap12:Envelope>");
            return xml.ToString();
        }

        //        String cancelInv(string Account, string ACpass, string fkey, string username, stringpassword). 
        //        downloadInvPDFFkey(string fkey, string userName, string userPass)


        private void btn_UpdateCustomer_Click(object sender, EventArgs e)
        {
                DataProcess<Stores> dp = new DataProcess<Stores>();
                dp.ExecuteNoQuery("STBillingInvoiceUpdateCustomer " + this.currentBillingInvoices.BillingInvoiceID + ",'" + AppSetting.CurrentUser.LoginName + "'");
                //            XtraMessageBox.Show("The Invoice is cancelled successfully !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Init(this.currentBillingInvoices.BillingInvoiceID);
        }

        private void btnEditVAT_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.currentBillingInvoices.ConfirmedBy))
            {
                if (this.btnEditVAT.Text == "Edit VAT")
                {
                    //code to allow edit on VAT columns
                    this.colVAT.OptionsColumn.AllowEdit = true;

                    this.btnEditVAT.Text = "Update VAT";
                    this.colVAT.OptionsColumn.AllowEdit = true;
                    this.colVAT.OptionsColumn.ReadOnly = false;
                }
                else
                {
                    //process update VATAmount, then disaable eiditing the columns
                    this.btnEditVAT.Text = "Edit VAT";
                    int billingInvoiceDetailID = Convert.ToInt32(this.grvBillingInvoiceDetails.GetFocusedRowCellValue("BillingInvoiceDetailID"));
                    var vatAmount = Convert.ToDecimal(this.grvBillingInvoiceDetails.GetFocusedRowCellValue("VATAmount"));
                    var detailInfo = this.BillingInvoicesDetailsList.Where(id => id.BillingInvoiceDetailID.Equals(billingInvoiceDetailID)).FirstOrDefault();
                    detailInfo.VATAmount = vatAmount;
                    this.billingDetailDA.Update(detailInfo);
                    this.colVAT.OptionsColumn.AllowEdit = false;
                    this.colVAT.OptionsColumn.ReadOnly = true;

                    //Execute footer
                    this.billingDA.ExecuteNoQuery($"STBillingInvoiceUpdateFooter @BillingInvoiceID={this.currentBillingInvoices.BillingInvoiceID}," +
                                                  $" @CurrentUser={AppSetting.CurrentUser.LoginName}");
                    this.Init(this.currentBillingInvoices.BillingInvoiceID);
                }
            }
        }

        private void grvBillingInvoiceDetails_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            GridView view = sender as GridView;
            int billingDetailID = Convert.ToInt32(view.GetFocusedRowCellValue("BillingInvoiceDetailID"));
            if (billingDetailID <= 0) return;

            if (view.FocusedColumn.FieldName == "VATAmount")
            {
                if (e.Value == null) return;
                var oldBillingDetail = BillingInvoicesDetailsList.Where(p => p.BillingInvoiceDetailID == billingDetailID).FirstOrDefault();
                if (oldBillingDetail != null && oldBillingDetail.VATAmount != null && oldBillingDetail.VATAmount > 0)
                {
                    decimal onePercent = (decimal)oldBillingDetail.VATAmount / 100;
                    decimal addNewValue = (decimal)e.Value - (decimal)oldBillingDetail.VATAmount;
                    if (addNewValue > onePercent || addNewValue < -onePercent)
                    {
                        e.Valid = false;
                        e.ErrorText = "The value is change does not over +/-1% on total old value";
                    }
                }
            }
        }

        private void btnNegativeAdjustment_Click(object sender, EventArgs e)
        {

            //Remove the restriction following Ms. Van request
            //if (AppSetting.CurrentEmployee.ManagementLevel > 3)
            //{
            //    XtraMessageBox.Show("Only Managers are allowed to Make Negative Adjustment to the Invoice !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            if (this.currentBillingInvoices.NetAmount < 0)
            {
                XtraMessageBox.Show("Can not Make Negative Adjustment to the Negative Invoices !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.currentBillingInvoices.E_InvoiceNumber == null || this.currentBillingInvoices.E_InvoiceNumber == "")
            {
                XtraMessageBox.Show("Can not Make Negative Adjustment to the un-processed Invoices !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.currentBillingInvoices.BillingID == null || this.currentBillingInvoices.BillingID == 0)
            {
                var Confirm = XtraMessageBox.Show("Are you sure to Negative Adjustment this billing invoice!", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Confirm.Equals(DialogResult.No)) return;
                DataProcess<object> da = new DataProcess<object>();
                da.ExecuteNoQuery("STBillingInvoiceNegativeAdjustment " + this.currentBillingInvoices.BillingInvoiceID + ",'" + AppSetting.CurrentUser.LoginName + "'");
                this.Init(currentBillingInvoices.BillingInvoiceID);
            }
            else
            {
                XtraMessageBox.Show("You Can Only Make Negative Adjustment to the Manually Created Invoices!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnVat7_Click(object sender, EventArgs e)
        {
            if (this.currentBillingInvoices.ConfirmedBy != null) return;

            var res = XtraMessageBox.Show("Are you sure to Update this Invoice for 70% VAT ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res.Equals(DialogResult.No)) return;

            DataProcess<object> da = new DataProcess<object>();
            da.ExecuteNoQuery("STBillingInvoiceVAT7Update " + this.currentBillingInvoices.BillingInvoiceID + ",'" + AppSetting.CurrentUser.LoginName + "'");
            this.Init(currentBillingInvoices.BillingInvoiceID);
        }

        private void btnVAT8_Click(object sender, EventArgs e)
        {
            if (this.currentBillingInvoices.ConfirmedBy != null) return;

            var res = XtraMessageBox.Show("Are you sure to Update all items for this Invoice with 8% VAT ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res.Equals(DialogResult.No)) return;

            DataProcess<object> da = new DataProcess<object>();
            da.ExecuteNoQuery("STBillingInvoiceVAT8Update " + this.currentBillingInvoices.BillingInvoiceID + ",'" + AppSetting.CurrentUser.LoginName + "'");
            this.Init(currentBillingInvoices.BillingInvoiceID);
        }
    }

}
