using System;
using System.Linq;
using DA;
using Common.Controls;
using UI.Helper;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraEditors;
using UI.ReportFile;
using System.Text;
using System.ComponentModel;
using System.Configuration;
using DevExpress.XtraGrid.Views.Base;
using System.Collections.Generic;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using UI.MasterSystemSetup;
using System.Drawing;
using System.Data.Entity.Core.Objects;
using UI.Management;
using UI.WarehouseManagement;

namespace UI.CRM
{
    public partial class frm_CRM_Quotation : frmBaseForm
    {
        private bool isFirstLoad = true;
        private DataProcess<CustomerQuotation> quotationDA = new DataProcess<CustomerQuotation>();
        private DataProcess<Contracts> contractDA = new DataProcess<Contracts>();
        private DataProcess<CustomerQuotationDetail> quotationDetailsDA = new DataProcess<CustomerQuotationDetail>();
        DataProcess<Employees> empDA = new DataProcess<Employees>();
        BindingList<CustomerQuotation> quotationBDList = null;
        BindingList<CustomerQuotationDetail> quotationDetailsBDList = null;
        private urc_CRM_12MonthServices viewMonthService = null;
        private urc_CRM_36MonthsOperation monthsOperation = null;
        private urc_CRM_12MonthProfitability Profitability = null;
        private int quotationID = 0;
        private int customerID = 0;
        private urc_CRM_CostStructure CostStructure = null;
        private urc_CRM_RatesHistory RatesHistory = null;
        public frm_CRM_Quotation(int quotationID)
        {
            InitializeComponent();

            // Init param
            this.quotationID = quotationID;

            // Init events
            this.InitEvents();

            // Init data 
            this.LoadCustomer();

            this.LoadStore();
            this.LoadServiceList();
            this.LoadQuotationStatus();
            this.LoadQuotation();

            //this.CleanData();

            this.BindingData();
            this.LoadContractByCustomer();
            this.isFirstLoad = false;
        }

        private int CheckConditionConfirm()
        {
            int count = 0;
            if (this.dxValidationProvider1.Validate())
            {
                count = 6;
            }
            var currentQuotation = this.quotationBDList[this.dnQuotations.Position];

            // Has confirm
            if (currentQuotation.QuotationStatus == 2)
            {
                // Don't active control 
                this.SetActiveControls(false);
            }

            return count;
        }
        private void LoadContractByCustomer()
        {
            if (this.lkeCustomers.EditValue != null)
                customerID = Convert.ToInt32(this.lkeCustomers.EditValue);
            this.lkePreviousContract.Properties.DataSource = contractDA.Select(c => c.CustomerID == customerID);
            this.lkePreviousContract.Properties.DisplayMember = "ContractNumber";
            this.lkePreviousContract.Properties.ValueMember = "ContractID";
        }
        private void InitEvents()
        {
            this.lkePreviousContract.DoubleClick += lkePreviousContract_DoubleClick;
            this.lkePreviousContract.EditValueChanged += LkePreviousContract_EditValueChanged;
            this.dnQuotations.PositionChanged += DnQuotations_PositionChanged;
            this.lkeCustomers.EditValueChanged += LkeCustomers_EditValueChanged;
            this.btnClose.Click += BtnClose_Click;
            this.btnDelete.Click += BtnDelete_Click;
            this.btnNew.Click += BtnNew_Click;
            this.btnSummary.Click += BtnSummary_Click;
            this.btnConfirm.Click += BtnConfirm_Click;
            this.btnDuplicate.Click += BtnDuplicate_Click;
            this.btnView.Click += BtnView_Click;
            this.btnViewVN.Click += BtnViewVN_Click;
            this.lkeStore.EditValueChanged += DQuotationDate_EditValueChanged;
            this.lkeInquiry.CloseUp += lkeInquiry_CloseUp;
            this.lkeInquiry.DoubleClick += LkeInquiry_DoubleClick;
            this.mmRemark.TextChanged += mmRemark_TextChanged;
            this.dQuotationDate.EditValueChanged += DQuotationDate_EditValueChanged;
            this.rpi_lke_ServiceDefinition.CloseUp += Rpi_lke_ServiceDefinition_CloseUp;
            this.lkeQuotationsStatus.CloseUp += lkeQuotationsStatus_CloseUp;
            this.grvQuotationDetails.RowCellClick += GrvQuotationDetails_RowCellClick;
            this.grvQuotationDetails.KeyDown += GrvQuotationDetails_KeyDown;
            this.grvQuotationDetails.CellValueChanged += advQuotationDetails_CellValueChanged;
            this.mmeScopeOfWork.Leave += MmeScopeOfWork_EditValueChanged;
            this.mmeScopeOfWorkVietNam.Leave += MmeScopeOfWorkVietNam_EditValueChanged;
            this.txtApprovedBy.DoubleClick += txtApprovedBy_DoubleClick;
            this.txtReviewedBy.DoubleClick += txtReviewedBy_DoubleClick;
            this.btnNewInquiry.Click += btnNewInquiry_Click;
            this.grvQuotationDetails.ValidatingEditor += grvQuotationDetails_ValidatingEditor;
            this.txtCustomerResponse.TextChanged += TxtCustomerResponse_TextChanged;
            this.txtVatDes.TextChanged += TxtVatDes_TextChanged;
            this.txtVatDesVn.TextChanged += TxtVatDesVn_TextChanged;
            this.txtBDQuotation.TextChanged += TxtBDQuotation_TextChanged;
            this.txtCustomerRepresentative.TextChanged += TxtCustomerRepresentative_TextChanged;
            this.txtPosition.TextChanged += TxtPosition_TextChanged;
            this.txtValidPeriod.TextChanged += TxtValidPeriod_TextChanged;
        }

        private void TxtVatDesVn_TextChanged(object sender, EventArgs e)
        {
            if (this.txtVatDesVn.IsModified)
            {
                quotationDA.ExecuteNoQuery("update CustomerQuotations set VATDescriptionVietnam =N'" + this.txtVatDesVn.Text
                    + "' where QuotationID = " + quotationID);
            }
        }

        private void TxtVatDes_TextChanged(object sender, EventArgs e)
        {
            if (this.txtVatDes.IsModified)
            {
                quotationDA.ExecuteNoQuery("update CustomerQuotations set VATDescription =N'" + this.txtVatDes.Text
                    + "' where QuotationID = " + quotationID);
            }
        }

        private void TxtValidPeriod_TextChanged(object sender, EventArgs e)
        {
            if (this.txtValidPeriod.IsModified)
            {
                quotationDA.ExecuteNoQuery("update CustomerQuotations set ValidPeriod =N'" + this.txtValidPeriod.Text
                    + "' where QuotationID = " + quotationID);
            }
        }

        private void Rpi_lke_ServiceDefinition_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.Value == null) return;
            int serviceID = Convert.ToInt32(e.Value);
            int countValue = this.quotationDetailsBDList.Where(s => s.ServiceID == serviceID).Count();
            if (countValue > 0)
            {
                MessageBox.Show("This service has existed, please choose other service !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.AcceptValue = false;
                return;
            }
            var lke = (LookUpEdit)sender;
            lke.EditValue = e.Value;
            var serviceSelected = (ServicesDefinition)lke.GetSelectedDataRow();
            if (serviceSelected == null) return;
            this.grvQuotationDetails.SetFocusedRowCellValue("ServiceID", serviceSelected.ServiceID);
            this.grvQuotationDetails.SetFocusedRowCellValue("ServiceDescription", serviceSelected.ServiceName);
            this.grvQuotationDetails.SetFocusedRowCellValue("ServiceNameInvoiced", serviceSelected.ServiceNameVietnamese);
            this.grvQuotationDetails.SetFocusedRowCellValue("UnitMeasurement", serviceSelected.Measure);
            this.grvQuotationDetails.SetFocusedRowCellValue("ServiceScopeOfWorkVietnam", serviceSelected.ScopeOFWorkVietnam);
            this.grvQuotationDetails.SetFocusedRowCellValue("ServiceScopeOfWork", serviceSelected.ScopeOfWork);
            this.grvQuotationDetails.SetFocusedRowCellValue("ServiceNameVietnamese", serviceSelected.ServiceNameVietnamese);
            this.mmeScopeOfWork.Text = serviceSelected.ScopeOfWork;
            this.mmeScopeOfWorkVietNam.Text = serviceSelected.ScopeOFWorkVietnam;

            int quotationDetailID = Convert.ToInt32(this.grvQuotationDetails.GetFocusedRowCellValue("QuotationDetailID"));
            string quotationRemark = Convert.ToString(this.grvQuotationDetails.GetFocusedRowCellValue("QuotationDetailRemark"));
            int rowIndex = this.grvQuotationDetails.FocusedRowHandle;
            decimal unitRate = 0;
            if (!Convert.IsDBNull(this.grvQuotationDetails.GetFocusedRowCellValue("UnitRate")))
            {
                unitRate = Convert.ToDecimal(this.grvQuotationDetails.GetFocusedRowCellValue("UnitRate"));
            }

            CustomerQuotationDetail currentQuotationDetails = null;
            if (quotationDetailID > 0 && rowIndex > -1)
            {
                currentQuotationDetails = quotationDetailsDA.Select(q => q.QuotationDetailID == quotationDetailID).FirstOrDefault();
            }
            else
            {
                currentQuotationDetails = new CustomerQuotationDetail();
            }
            currentQuotationDetails.QuotationDetailRemark = quotationRemark;
            currentQuotationDetails.QuotationDetailID = quotationDetailID;
            currentQuotationDetails.QuotationID = this.quotationID;
            currentQuotationDetails.ServiceScopeOfWorkVietnam = serviceSelected.ScopeOFWorkVietnam;
            currentQuotationDetails.ServiceDescription = serviceSelected.ServiceName;
            currentQuotationDetails.ServiceID = serviceSelected.ServiceID;
            currentQuotationDetails.ServiceScopeOfWork = serviceSelected.ScopeOfWork;
            currentQuotationDetails.UnitMeasurement = serviceSelected.Measure;
            currentQuotationDetails.UnitRate = unitRate;
            currentQuotationDetails.ServiceNameInvoiced = serviceSelected.ServiceNameVietnamese;

            // Detect is insert or update
            if (quotationDetailID > 0 && rowIndex > -1)
            {
                // Process Update
                this.quotationDetailsDA.Update(currentQuotationDetails);

            }
            else
            {
                currentQuotationDetails.CreatedTime = DateTime.Now;
                currentQuotationDetails.CreatedBy = AppSetting.CurrentUser.LoginName;
                currentQuotationDetails.VATPercentage = 10;
                // Insert
                this.quotationDetailsDA.Insert(currentQuotationDetails);
                this.grvQuotationDetails.SetFocusedRowCellValue("QuotationDetailID", currentQuotationDetails.QuotationDetailID);

                //Add new row
                var newCustomerQuotationDetail = new CustomerQuotationDetail();
                newCustomerQuotationDetail.ServiceID = -1;
                newCustomerQuotationDetail.CreatedBy = AppSetting.CurrentUser.LoginName;
                newCustomerQuotationDetail.CreatedTime = DateTime.Now;
                newCustomerQuotationDetail.VATPercentage = 10;
                this.quotationDetailsBDList.Add(newCustomerQuotationDetail);
                this.grdQuotationDetails.DataSource = this.quotationDetailsBDList;
                SendKeys.Send("{TAB}");
            }
        }

        private void TxtPosition_TextChanged(object sender, EventArgs e)
        {
            if (this.txtPosition.IsModified)
            {
                quotationDA.ExecuteNoQuery("update CustomerQuotations set CustomerRepresentativePosition =N'" + this.txtPosition.Text
                    + "' where QuotationID = " + quotationID);
            }
        }

        private void TxtCustomerRepresentative_TextChanged(object sender, EventArgs e)
        {
            if (this.txtCustomerRepresentative.IsModified)
            {
                quotationDA.ExecuteNoQuery("update CustomerQuotations set CustomerRepresentative =N'" + this.txtCustomerRepresentative.Text
                    + "' where QuotationID = " + quotationID);
            }
        }

        private void LkePreviousContract_EditValueChanged(object sender, EventArgs e)
        {
            if (this.lkePreviousContract.IsModified)
            {
                quotationDA.ExecuteNoQuery("update CustomerQuotations set PreviousContractID =" + this.lkePreviousContract.EditValue
                    + " where QuotationID = " + quotationID);
            }
        }

        private void TxtBDQuotation_TextChanged(object sender, EventArgs e)
        {
            if (this.txtBDQuotation.IsModified)
            {
                quotationDA.ExecuteNoQuery("update CustomerQuotations set BDQuotationNumber =N'" + this.txtBDQuotation.Text
                    + "' where QuotationID = " + quotationID);
            }
        }

        private void TxtCustomerResponse_TextChanged(object sender, EventArgs e)
        {
            if (this.txtCustomerResponse.IsModified)
            {
                quotationDA.ExecuteNoQuery("update CustomerQuotations set CustomerResponse =N'" + this.txtCustomerResponse.Text
                    + "' where QuotationID = " + quotationID);
            }
        }

        void grvQuotationDetails_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            GridView view = sender as GridView;
            int serviceName = Convert.ToInt32(view.GetFocusedRowCellValue("ServiceID"));
            if (serviceName == 0) return;

            if (view.FocusedColumn.FieldName == "UnitRate")
            {
                double rate = 0;
                Double.TryParse(e.Value.ToString(), out rate);
                if (rate <= 0)
                {
                    e.Valid = false;
                    e.ErrorText = "The rate have higher zero";
                }
            }
            if (view.FocusedColumn.FieldName == "EstimatedMonthlyVolume")
            {
                double estimate = 0;
                Double.TryParse(e.Value.ToString(), out estimate);
                if (estimate <= 0)
                {
                    e.Valid = false;
                    e.ErrorText = "The estimated have higher zero";
                }
            }
        }

        /// <summary>
        /// Set active all controls 
        /// </summary>
        /// <param name="isActive"></param>
        private void SetActiveControls(bool isActive)
        {
            this.lkeCustomers.ReadOnly = !isActive;
            this.dQuotationDate.ReadOnly = !isActive;
            this.lkeStore.ReadOnly = !isActive;
            this.txtBDQuotation.ReadOnly = !isActive;
            this.txtValidPeriod.ReadOnly = !isActive;
            this.lkeInquiry.ReadOnly = !isActive;
            this.btnNewInquiry.Enabled = isActive;
            this.lkePreviousContract.ReadOnly = !isActive;
            this.txtCustomerRepresentative.ReadOnly = !isActive;
            this.txtPosition.ReadOnly = !isActive;
            this.mmeScopeOfWork.ReadOnly = !isActive;
            this.mmeScopeOfWorkVietNam.ReadOnly = !isActive;
            this.grvQuotationDetails.OptionsBehavior.ReadOnly = !isActive;

        }


        void lkePreviousContract_DoubleClick(object sender, EventArgs e)
        {
            int contractID = Convert.ToInt32(this.lkePreviousContract.EditValue);
            if (contractID > 0)
            {
                frm_MSS_Contracts frm = frm_MSS_Contracts.GetInstance(0, contractID);
                frm.InitData(0, contractID);
                frm.Show();
            }
        }

        void txtReviewedBy_DoubleClick(object sender, EventArgs e)
        {
            if (CheckConditionConfirm() > 5)
            {
                var levelManagerment = empDA.Select(emp => emp.EmployeeID == AppSetting.CurrentUser.EmployeeID).FirstOrDefault().ManagementLevel;
                if (levelManagerment < 20)
                {
                    var currentQuotation = this.quotationBDList[this.dnQuotations.Position];
                    currentQuotation.CustomerRepresentativePosition = this.txtPosition.Text;
                    currentQuotation.CustomerRepresentative = this.txtCustomerRepresentative.Text;
                    currentQuotation.ValidPeriod = this.txtValidPeriod.Text;
                    currentQuotation.BDQuotationNumber = this.txtBDQuotation.Text;
                    currentQuotation.CustomerInquiryID = Convert.ToInt32(this.lkeInquiry.EditValue);
                    currentQuotation.PreviousContractID = Convert.ToInt32(this.lkePreviousContract.EditValue);
                    if (currentQuotation.QuotationStatus == 1)
                    {
                        // Confirm
                        currentQuotation.ReviewedBy = AppSetting.CurrentUser.LoginName;
                        this.txtReviewedBy.Text = AppSetting.CurrentUser.LoginName;
                        currentQuotation.ReviewTime = DateTime.Now;
                        currentQuotation.QuotationStatus = 2;
                        this.daReviewTime.EditValue = DateTime.Now;
                        this.txtReviewedBy.ForeColor = Color.White;

                        // Set active control is none
                        this.SetActiveControls(false);
                    }
                    else
                    {
                        // Unconfirm
                        currentQuotation.ReviewedBy = string.Empty;
                        this.txtReviewedBy.Text = string.Empty;
                        currentQuotation.ReviewTime = null;
                        currentQuotation.QuotationStatus = 1;
                        this.daReviewTime.EditValue = null;
                        this.txtReviewedBy.ForeColor = Color.Transparent;

                        // Set active control is allow
                        this.SetActiveControls(true);
                    }

                    // Update status
                    quotationDA.Update(currentQuotation);
                    this.lkeQuotationsStatus.EditValue = currentQuotation.QuotationStatus;
                }
                else
                    MessageBox.Show("You are not enought privilege or to do", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Not enought condition to do", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        void txtApprovedBy_DoubleClick(object sender, EventArgs e)
        {
            var levelManagerment = empDA.Select(emp => emp.EmployeeID == AppSetting.CurrentUser.EmployeeID).FirstOrDefault().ManagementLevel;
            if (levelManagerment < 2)
            {
                if (String.IsNullOrEmpty(txtApprovedBy.Text))
                {
                    var currentQuotation = this.quotationBDList[this.dnQuotations.Position];
                    currentQuotation.ApprovedBy = AppSetting.CurrentUser.LoginName;
                    this.txtApprovedBy.Text = AppSetting.CurrentUser.LoginName;
                    currentQuotation.ApprovedTime = DateTime.Now;
                    currentQuotation.QuotationStatus = 3;
                    currentQuotation.CustomerRepresentativePosition = this.txtPosition.Text;
                    currentQuotation.CustomerRepresentative = this.txtCustomerRepresentative.Text;
                    currentQuotation.ValidPeriod = this.txtValidPeriod.Text;
                    currentQuotation.BDQuotationNumber = this.txtBDQuotation.Text;
                    currentQuotation.CustomerInquiryID = Convert.ToInt32(this.lkeInquiry.EditValue);
                    currentQuotation.PreviousContractID = Convert.ToInt32(this.lkePreviousContract.EditValue);
                    this.daApproveTime.EditValue = DateTime.Now;
                    this.txtApprovedBy.ForeColor = Color.White;
                    this.txtApprovedBy.ReadOnly = true;
                    this.daApproveTime.ReadOnly = true;
                    quotationDA.Update(currentQuotation);
                    this.lkeQuotationsStatus.EditValue = currentQuotation.QuotationStatus;
                }
                var summaryValue = Convert.ToInt64(grvQuotationDetails.Columns["EstimatedTotal"].SummaryItem.SummaryValue);
                if (summaryValue > 1000000000)
                {
                    this.btnView.Enabled = true;
                    this.btnViewVN.Enabled = true;
                    this.btnConfirm.Enabled = true;
                }
            }
            else
                MessageBox.Show("You are not enought privilege to do", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);


        }

        void btnNewInquiry_Click(object sender, EventArgs e)
        {
            DataProcess<CustomerInquiry> inquiryDA = new DataProcess<CustomerInquiry>();
            CustomerInquiry newInquiry = new CustomerInquiry();
            newInquiry.CreatedBy = AppSetting.CurrentUser.LoginName;
            newInquiry.CreatedTime = DateTime.Now;
            newInquiry.CustomerInquiryDate = DateTime.Now;
            newInquiry.CustomerID = Convert.ToInt32(this.lkeCustomers.EditValue);
            int customerMain = Convert.ToInt32(this.lkeCustomers.GetColumnValue("CustomerMainID"));
            newInquiry.CustomerMainID = customerMain;
            newInquiry.StoreID = Convert.ToString(AppSetting.CurrentUser.StoreID);
            newInquiry.CustomerInquiryStatus = (short)Convert.ToInt32((this.lkeQuotationsStatus.EditValue));
            newInquiry.CustomerCategoryID = Convert.ToInt32(this.lkeCustomers.GetColumnValue("CustomerCategory")); ;
            inquiryDA.Insert(newInquiry);
            InitCustomerInquiry();
            this.lkeInquiry.EditValue = newInquiry.CustomerInquiryID;
            var currentQuotation = this.quotationBDList[this.dnQuotations.Position];
            currentQuotation.CustomerInquiryID = newInquiry.CustomerInquiryID;
            quotationDA.Update(currentQuotation);
            frm_CRM_Inquiry frm = new frm_CRM_Inquiry(newInquiry.CustomerInquiryID);
            frm.Show();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (grvQuotationDetails.RowCount > 1)
            {
                MessageBox.Show("Please delete all quotation detail !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                FileProcess.LoadTable("Delete from CustomerQuotations where QuotationID=" + quotationID);

                // Raise Reload Data event to Quotation list to reload data
                Common.Process.RefreshData.OnReloadData(new CustomerQuotation(), e);
                this.Close();
            }
        }

        private void BtnViewVN_Click(object sender, EventArgs e)
        {
            rptQuotationVN rpt = new rptQuotationVN();//rptQuotationVN(this.quotationID)
            var dataSource = FileProcess.LoadTable("STCustomerQuotationPrint " + this.quotationID);
            rpt.DataSource = dataSource;
            rpt.xrQuotationRemark.Text = this.mmRemark.Text;
            if (!string.IsNullOrEmpty(this.txtVatDesVn.Text))
            {
                rpt.lblVATDesVN.Text = this.txtVatDesVn.Text;
            }

            subrptProductInquiryVN subProductInquiryVN = new subrptProductInquiryVN();
            subProductInquiryVN.DataSource = FileProcess.LoadTable("STCustomerQuotationProductInquiries " + this.quotationID);
            rpt.xrProductInquiryVN.ReportSource = subProductInquiryVN;
            rpt.CreateDocument();
            subrptQuotationScoreOfWorkVN subScopeOfWork = new subrptQuotationScoreOfWorkVN();
            subScopeOfWork.DataSource = dataSource;
            subScopeOfWork.CreateDocument();
            rpt.Pages.AddRange(subScopeOfWork.Pages);
            rpt.PrintingSystem.ContinuousPageNumbering = true;
            //rpt.xrSubScopeOfWork.ReportSource = subScopeOfWork;
            int customerID = Convert.ToInt32(this.lkeCustomers.EditValue);
            ReportPrintToolWMS printool = new ReportPrintToolWMS(rpt, customerID);
            printool.ShowPreview();
        }


        private void GrvQuotationDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if ((int)lkeQuotationsStatus.EditValue >= 4)
                    return;
                var currentDetail = (CustomerQuotationDetail)this.grvQuotationDetails.GetFocusedRow();
                if (currentDetail == null) return;
                FileProcess.LoadTable("delete from CustomerQuotationDetails where QuotationDetailID=" + currentDetail.QuotationDetailID);
                quotationDetailsBDList.Remove(currentDetail);
                this.grdQuotationDetails.DataSource = quotationDetailsBDList.OrderBy(q => q.QuotationDetailID);
            }
        }
        /// <summary>
        /// Set active controls 
        /// </summary>
        /// <param name="isActive"></param>
        private void ActiveControls(bool isActive)
        {
            this.lkeCustomers.ReadOnly = !isActive;
            this.mmRemark.ReadOnly = !isActive;
            this.dQuotationDate.ReadOnly = !isActive;
            this.lkeInquiry.ReadOnly = !isActive;
            if ((int)lkeQuotationsStatus.EditValue < 4)
                this.lkeQuotationsStatus.ReadOnly = false;
            else
                this.lkeQuotationsStatus.ReadOnly =true;
            this.lkeStore.ReadOnly = !isActive;
            this.grvQuotationDetails.OptionsBehavior.ReadOnly = !isActive;
            this.mmeScopeOfWork.ReadOnly = !isActive;
            this.mmeScopeOfWorkVietNam.ReadOnly = !isActive;
            this.btnConfirm.Enabled = isActive;
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            if (this.quotationID <= 0) return;
            // Validate before confirm
            if (!this.dxValidationProvider1.Validate()) return;

            var check = FileProcess.LoadTable("ST_WMS_CheckServiceDiscontinueOnQuotation " + quotationID);
            var total = Convert.ToInt32(check.Rows[0]["Total"]);
            if (total > 0)
            {
                XtraMessageBox.Show("Has [" + total + "] services is discontinue, please active this services before!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var currentQuotation = this.quotationDA.Select(q => q.QuotationID == this.quotationID).FirstOrDefault();
            currentQuotation.QuotationStatus = 4;
            this.lkeQuotationsStatus.EditValue = currentQuotation.QuotationStatus;
            this.quotationDA.Update(currentQuotation);

            // Create new contract and contract details
            DataProcess<Contracts> contractDA = new DataProcess<Contracts>();
            DataProcess<ContractDetails> contractDetailsDA = new DataProcess<ContractDetails>();
            string customerNumber = Convert.ToString(this.lkeCustomers.GetColumnValue("CustomerNumber"));
            string customerNo = string.Empty;
            if (customerNumber.Contains('-'))
            {
                customerNo = customerNumber.Split('-')[0];
            }

            int maxContractID = contractDA.Select().OrderByDescending(c => c.ContractID).FirstOrDefault().ContractID + 1;
            Contracts newContract = new Contracts();
            newContract.ContractDate = (DateTime)currentQuotation.QuotationDate;
            newContract.ContractRemark = currentQuotation.QuotationRemark;
            newContract.ContractType = 1;
            newContract.ContractNumber = customerNo + "-" + maxContractID + "-" + Convert.ToDateTime(newContract.ContractDate).Year;
            newContract.CreatedBy = AppSetting.CurrentUser.LoginName;
            newContract.CreatedTime = DateTime.Now;
            newContract.CustomerID = currentQuotation.CustomerID;
            newContract.EndDate = DateTime.Now.AddYears(1);
            newContract.StartDate = DateTime.Now;
            newContract.QuotationID = this.quotationID;
            newContract.AccountingStatus = 0;
            newContract.ContractProgressStatus = 1;
            newContract.CurrencyUnit = currentQuotation.BDQuotationNumber;
            //newContract.AppendixNumber = "A";

            // Insert contract
            contractDA.Insert(newContract);


            DataProcess<ServicesDefinition> servicesDefinitionDA = new DataProcess<ServicesDefinition>();
            ServicesDefinition servicesDefinition = new ServicesDefinition();

            // Create contract details
            ContractDetails newContractDetail = null;
            IList<ContractDetails> contractDetails = new List<ContractDetails>();
            foreach (CustomerQuotationDetail quotationDetailItem in this.quotationDetailsBDList.OrderBy(q => q.LineNumber))
            {
                if (quotationDetailItem.QuotationDetailID <= 0) continue;
                newContractDetail = new ContractDetails();
                newContractDetail.ContractServicePrice = quotationDetailItem.UnitRate;
                newContractDetail.CheckingQuantity = Convert.ToDouble(quotationDetailItem.UnitRate);
                newContractDetail.ContractDetailRemark = quotationDetailItem.QuotationDetailRemark;
                newContractDetail.ContractID = newContract.ContractID;
                newContractDetail.CurrencyUnit = "US";
                newContractDetail.ScopeOfWork = quotationDetailItem.ServiceScopeOfWork;
                newContractDetail.ScopeOFWorkVietnam = quotationDetailItem.ServiceScopeOfWorkVietnam;
                newContractDetail.ServiceID = quotationDetailItem.ServiceID;
                newContractDetail.LineNumber = quotationDetailItem.LineNumber;
                newContractDetail.ServiceNameInvoiced = quotationDetailItem.ServiceNameInvoiced;
                newContractDetail.VATPercentage = quotationDetailItem.VATPercentage;
                servicesDefinition = servicesDefinitionDA.Select(x => x.ServiceID == quotationDetailItem.ServiceID).FirstOrDefault();
                if (servicesDefinition == null)
                {
                    break;
                }
                newContractDetail.CalculatedSQL = servicesDefinition.CalculatedSQL;
                contractDetails.Add(newContractDetail);
            }

            // Insert contract details
            contractDetailsDA.Insert(contractDetails.ToArray());
            //Update ContractNumber
            DataProcess<object> dataProcess = new DataProcess<object>();
            dataProcess.ExecuteNoQuery("STUpdateContractNumber " + newContract.ContractID);

            // Invoke to contract form
            int customerID = Convert.ToInt32(currentQuotation.CustomerID);
            int customerMainID = Convert.ToInt32(AppSetting.CustomerListAll.Where(cs => cs.CustomerID == customerID).FirstOrDefault().CustomerMainID);
            if (customerMainID <= 0) return;
            frm_MSS_Contracts frm = frm_MSS_Contracts.GetInstance(0, newContract.ContractID);
            frm.InitData(0, newContract.ContractID);
            frm.BringToFront();
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();

            // Set acticontrol
            this.ActiveControls(false);
        }

        private void MmeScopeOfWorkVietNam_EditValueChanged(object sender, EventArgs e)
        {
            if (this.grvQuotationDetails.FocusedRowHandle >= 0 && this.mmeScopeOfWorkVietNam.IsModified)
            {
                this.grvQuotationDetails.SetFocusedRowCellValue("ServiceScopeOfWorkVietnam", this.mmeScopeOfWorkVietNam.Text);
                int quotationDetailID = Convert.ToInt32(this.grvQuotationDetails.GetFocusedRowCellValue("QuotationDetailID"));
                var currentQuotationDetail = this.quotationDetailsDA.Select(q => q.QuotationDetailID == quotationDetailID).FirstOrDefault();
                currentQuotationDetail.ServiceScopeOfWorkVietnam = this.mmeScopeOfWorkVietNam.Text;

                // Update data
                this.quotationDetailsDA.Update(currentQuotationDetail);
            }
        }

        private void MmeScopeOfWork_EditValueChanged(object sender, EventArgs e)
        {
            if (this.grvQuotationDetails.FocusedRowHandle >= 0 && this.mmeScopeOfWork.IsModified)
            {
                this.grvQuotationDetails.SetFocusedRowCellValue("ServiceScopeOfWork", this.mmeScopeOfWork.Text);
                int quotationDetailID = Convert.ToInt32(this.grvQuotationDetails.GetFocusedRowCellValue("QuotationDetailID"));
                var currentQuotationDetail = this.quotationDetailsDA.Select(q => q.QuotationDetailID == quotationDetailID).FirstOrDefault();
                currentQuotationDetail.ServiceScopeOfWork = this.mmeScopeOfWork.Text;

                // Update data
                this.quotationDetailsDA.Update(currentQuotationDetail);
            }
        }

        private void GrvQuotationDetails_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.RowHandle < 0) return;
            var currentDetail = (CustomerQuotationDetail)this.grvQuotationDetails.GetFocusedRow();
            this.mmeScopeOfWork.Text = currentDetail.ServiceScopeOfWork;
            this.mmeScopeOfWorkVietNam.Text = currentDetail.ServiceScopeOfWorkVietnam;

            //if (!e.Column.FieldName.Equals("ServiceDescription")) return;
            var columFocused = this.grvQuotationDetails.FocusedColumn;
            if (columFocused.ColumnEdit == this.rpe_hle_CompareRate)
            {
                int quotationDetaiID = Convert.ToInt32(this.grvQuotationDetails.GetFocusedRowCellValue("QuotationDetailID"));
                string serviceName = this.grvQuotationDetails.GetFocusedRowCellValue("ServiceDescription").ToString();
                frm_CRM_CompareRates frm_CRM_Compare = new frm_CRM_CompareRates(quotationDetaiID, serviceName);
                frm_CRM_Compare.ShowDialog();
            }
            if (columFocused.ColumnEdit == this.rpe_hle_CostBreakdown)
            {
                frm_CRM_CostBreakdown frm = new frm_CRM_CostBreakdown(Convert.ToInt32(this.lkeCustomers.EditValue), Convert.ToInt32(this.grvQuotationDetails.GetFocusedRowCellValue("ServiceID")));
                frm.Show();
                frm.WindowState = FormWindowState.Maximized;

            }
        }

        private void LkeInquiry_DoubleClick(object sender, EventArgs e)
        {
            if (this.lkeInquiry.EditValue == null) return;
            int customerInquiryID = Convert.ToInt32(this.lkeInquiry.EditValue);
            frm_CRM_Inquiry frm = new frm_CRM_Inquiry(customerInquiryID);
            frm.Show();
        }

        void lkeInquiry_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.Value == null) return;
            if (this.quotationID <= 0)
            {
                // Insert quotation
                int customerMainID = Convert.ToInt32(this.lkeCustomers.GetColumnValue("CustomerMainID"));
                int customerID = Convert.ToInt32(this.lkeCustomers.EditValue);
                int status = Convert.ToInt32(this.lkeQuotationsStatus.EditValue);
                CustomerQuotation newQuotation = new CustomerQuotation();
                newQuotation.CreatedBy = AppSetting.CurrentUser.LoginName;
                newQuotation.CreatedTime = DateTime.Now;
                newQuotation.CustomerID = customerID;
                newQuotation.CustomerInquiryID = 0;
                newQuotation.CustomerMainID = customerMainID;
                newQuotation.QuotationDate = DateTime.Now;
                if (status <= 0)
                {
                    // Set default value is planed
                    status = 1;
                }
                newQuotation.QuotationStatus = status;
                newQuotation.QuotationRemark = this.mmRemark.Text;
                newQuotation.CustomerInquiryID = Convert.ToInt32(e.Value);
                newQuotation.StoreID = AppSetting.StoreID;
                newQuotation.CustomerRepresentative = this.txtCustomerRepresentative.Text;
                newQuotation.CustomerRepresentativePosition = this.txtPosition.Text;
                newQuotation.BDQuotationNumber = this.txtBDQuotation.Text;
                newQuotation.ValidPeriod = this.txtValidPeriod.Text;
                newQuotation.PreviousContractID = Convert.ToInt32(this.lkePreviousContract.EditValue);
                quotationDA.Insert(newQuotation);
                this.quotationBDList.Add(newQuotation);
                this.quotationID = newQuotation.QuotationID;
                this.txtQuotationID.Text = Convert.ToString("QT-" + newQuotation.QuotationID);
                this.LoadQuotationDetais(newQuotation.QuotationID);
                this.grvQuotationDetails.OptionsBehavior.ReadOnly = false;
            }
            else
            {
                DataProcess<object> quotationDA = new DataProcess<object>();
                string query = "Update CustomerQuotations set CustomerInquiryID=" + e.Value + " where QuotationID=" + this.quotationID;
                int resultInsert = quotationDA.ExecuteNoQuery(query);
            }
        }

        void lkeQuotationsStatus_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (Convert.IsDBNull(e.Value)) return;
            if (this.quotationID <= 0) return;
            int status = Convert.ToInt32(e.Value);
            DataProcess<object> quotationDA = new DataProcess<object>();
            string query = "update CustomerQuotations set QuotationStatus='" + status + "' where QuotationID=" + quotationID;
            int resultInsert = quotationDA.ExecuteNoQuery(query);
            int currentPosition = this.dnQuotations.Position;
            LoadQuotation();
            this.dnQuotations.Position = currentPosition;
        }

        void lkeInquiry_EditValueChanged(object sender, EventArgs e)
        {
            //this.lkeInquiry.Text = Convert.ToString(this.lkeInquiry.GetColumnValue("CustomerInquiryNumber"));
        }

        void mmRemark_TextChanged(object sender, EventArgs e)
        {
            if (this.txtQuotationID.Text == "") return;
            //this.grvQuotationDetails.OptionsBehavior.ReadOnly = false;
            string quotationRemark = this.mmRemark.Text;
            DataProcess<object> quotationDA = new DataProcess<object>();
            string query = "Update CustomerQuotations set QuotationRemark=N'" + quotationRemark + "' where QuotationID=" + this.quotationID;
            int resultInsert = quotationDA.ExecuteNoQuery(query);
        }
        private void InitCustomerInquiry()
        {
            var inquirySource = FileProcess.LoadTable("SELECT *  FROM CustomerInquiries WHERE CustomerID=" + Convert.ToInt32(lkeCustomers.EditValue));
            this.lkeInquiry.Properties.DataSource = inquirySource;
            this.lkeInquiry.Properties.DisplayMember = "CustomerInquiryNumber";
            this.lkeInquiry.Properties.ValueMember = "CustomerInquiryID";
        }
        private void DQuotationDate_EditValueChanged(object sender, EventArgs e)
        {
            if (this.isFirstLoad) return;
            DateTime quotationDate = this.dQuotationDate.DateTime;
            if (this.quotationID <= 0) return;
            int storeID = Convert.ToInt32(this.lkeStore.EditValue);

            DataProcess<object> quotationDA = new DataProcess<object>();
            string query = "Update CustomerQuotations set StoreID=" + storeID + ",QuotationDate='" + quotationDate.ToString("yyyy-MM-dd") + "' where QuotationID=" + this.quotationID;
            int resultInsert = quotationDA.ExecuteNoQuery(query);
        }

        private void BtnView_Click(object sender, EventArgs e)
        {
            rptQuotation rpt = new rptQuotation();
            var dataSource = FileProcess.LoadTable("STCustomerQuotationPrint " + this.quotationID);
            rpt.DataSource = dataSource;
            rpt.xrQuotationRemark.Text = this.mmRemark.Text;
            if (!string.IsNullOrEmpty(this.txtVatDes.Text))
            {
                rpt.lblVATDes.Text = this.txtVatDes.Text;
            }
            subrptProductInquiry subProductInquiry = new subrptProductInquiry();
            subProductInquiry.DataSource = FileProcess.LoadTable("STCustomerQuotationProductInquiries " + this.quotationID);
            rpt.xrProductInquiry.ReportSource = subProductInquiry;
            rpt.CreateDocument();
            subrptQuotationScoreOfWork subScopeOfWork = new subrptQuotationScoreOfWork();
            subScopeOfWork.DataSource = dataSource;
            subScopeOfWork.CreateDocument();
            rpt.Pages.AddRange(subScopeOfWork.Pages);
            rpt.PrintingSystem.ContinuousPageNumbering = true;
            ///rpt.xrSubScopeOfWork.ReportSource = subScopeOfWork;
            ///
            int customerID = Convert.ToInt32(this.lkeCustomers.EditValue);
            ReportPrintToolWMS printool = new ReportPrintToolWMS(rpt, customerID);
            printool.ShowPreview();
        }

        private void BtnDuplicate_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Do you want to copy quotation", "Copy", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                //Code cũ
                using (var context = new SwireDBEntities())
                {
                    ObjectParameter newQuotationID = new ObjectParameter("NewQuotationID", 0);
                    context.ST_WMS_CustomerQuotationInsert(this.quotationID, newQuotationID, AppSetting.CurrentUser.LoginName);
                    this.quotationID = Convert.ToInt32(newQuotationID.Value);
                }
                int quotationID = this.quotationID;
                //Code here to duplicate contract
                frm_MSS_CustomerChanged frmCustomerChange = new frm_MSS_CustomerChanged();
                if (frmCustomerChange.Enabled == false) return;
                frmCustomerChange.ShowDialog();
                if (frmCustomerChange.CustomerID > 0)
                {
                    // cap nhat customer id da chon vao table quotation=this.quotationID
                    int resultInsert = quotationDA.ExecuteNoQuery("STUpdateCustomerByQuotationID @QuotationID={0},@CustomerID={1}", this.quotationID, frmCustomerChange.CustomerID);
                }
                this.LoadQuotation();
                this.Close();
                frm_CRM_Quotation frm = new frm_CRM_Quotation(quotationID);
                frm.Show();
            }

        }

        private void BtnSummary_Click(object sender, EventArgs e)
        {
            int customerID = Convert.ToInt32(this.lkeCustomers.EditValue);
            frm_CRM_SummaryQuotations frm = new frm_CRM_SummaryQuotations(customerID);
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            this.CleanData();
            this.grvQuotationDetails.OptionsBehavior.ReadOnly = true;

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LkeCustomers_EditValueChanged(object sender, EventArgs e)
        {



            if (this.lkeCustomers.EditValue == null)
            {
                this.txtCustomerName.Text = string.Empty;
                return;
            }
            else
            {
                int customerID = Convert.ToInt32(this.lkeCustomers.EditValue);
                this.txtCustomerName.Text = AppSetting.CustomerListAll.Where(c => c.CustomerID == customerID).FirstOrDefault().CustomerName;

                // Update customer in quotation
                if (this.quotationID > 0)
                {
                    var currentQuotation = this.quotationDA.Select(q => q.QuotationID == this.quotationID).FirstOrDefault();
                    currentQuotation.CustomerID = customerID;
                    this.quotationDA.Update(currentQuotation);
                }

                // Init inquiry
                InitCustomerInquiry();
                LoadContractByCustomer();
            }
        }

        /// <summary>
        /// Change quotations data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DnQuotations_PositionChanged(object sender, EventArgs e)
        {
            if (this.dnQuotations.Position < 0) return;
            var currentQuotation = this.quotationBDList[this.dnQuotations.Position];
            this.lkeCustomers.EditValue = currentQuotation.CustomerID;
            InitCustomerInquiry();
            this.lkeStore.EditValue = currentQuotation.StoreID;
            this.lkeInquiry.EditValue = currentQuotation.CustomerInquiryID;
            this.lkeQuotationsStatus.EditValue = Convert.ToInt32(currentQuotation.QuotationStatus);
            this.txtQuotationID.EditValue = currentQuotation.QuotationNumber;
            this.LoadQuotationDetais(currentQuotation.QuotationID);

            if (currentQuotation.QuotationDate == null) return;
            DateTime dt = Convert.ToDateTime(currentQuotation.QuotationDate);
            DateTime dtn = Convert.ToDateTime(DateTime.Now);
            TimeSpan result = dtn.Subtract(dt);
            if (result.TotalDays >= 1)
            {
                this.lkeCustomers.Enabled = false;
            }
            else
            {
                this.lkeCustomers.Enabled = true;
            }
            if(currentQuotation.QuotationStatus == 4)
            {
                lkeQuotationsStatus.ReadOnly = true;
            }
        }

        private void LoadQuotationDetais(int quotationID)
        {
            var customerQuotationDetailSource = this.quotationDetailsDA.Select(qd => qd.QuotationID == quotationID);
            this.quotationDetailsBDList = new BindingList<CustomerQuotationDetail>(customerQuotationDetailSource.ToList());
            var newQuotationDetails = new CustomerQuotationDetail();
            newQuotationDetails.ServiceID = -1;
            newQuotationDetails.CreatedBy = AppSetting.CurrentUser.LoginName;
            newQuotationDetails.CreatedTime = DateTime.Now;
            this.quotationDetailsBDList.Add(newQuotationDetails);
            var dataSource = this.quotationDetailsBDList.OrderBy(q => q.QuotationDetailID).ToList();
            this.grdQuotationDetails.DataSource = dataSource;
            if(dataSource.Count>1)
            {
                var currentDetail = dataSource[1];
                this.mmeScopeOfWork.Text = currentDetail.ServiceScopeOfWork;
                this.mmeScopeOfWorkVietNam.Text = currentDetail.ServiceScopeOfWorkVietnam;
            }
        
        }

        private void LoadServiceList()
        {
            DataProcess<ServicesDefinition> serviceDA = new DataProcess<ServicesDefinition>();
            this.rpi_lke_ServiceDefinition.DataSource = serviceDA.Select(s => s.Discontinued==false);
            this.rpi_lke_ServiceDefinition.DisplayMember = "ServiceNumber";
            this.rpi_lke_ServiceDefinition.ValueMember = "ServiceID";

            //this.rpi_lke_Services.DataSource = serviceDA.Select();
            //this.rpi_lke_Services.DisplayMember = "ServiceNameVietnamese";
            //this.rpi_lke_Services.ValueMember = "ServiceID";
        }

        private void LoadStore()
        {
            this.lkeStore.Properties.DataSource = FileProcess.LoadTable("select * from Stores");
            this.lkeStore.Properties.DisplayMember = "StoreVietnam";
            this.lkeStore.Properties.ValueMember = "StoreID";
        }

        private void LoadQuotation()
        {
            bool isAdd = false;
            if (this.quotationID > 0)
            {
                var dataSource = quotationDA.Select(q => q.QuotationID == this.quotationID);
                this.quotationBDList = new BindingList<CustomerQuotation>(dataSource.ToList());
                if (this.quotationBDList.Count == 1)
                {
                    this.quotationBDList.Add(this.quotationBDList[0]);
                    isAdd = true;
                }
            }
            else
            {
                this.quotationBDList = new BindingList<CustomerQuotation>();
                this.quotationBDList.Add(new CustomerQuotation());
                this.CleanData();
            }


            this.dnQuotations.DataSource = this.quotationBDList;
            this.dnQuotations.Position = this.quotationBDList.Count;

            DataProcess<CustomerQuotation> dtSource = new DataProcess<CustomerQuotation>();
            var quotationInfo = dtSource.Select(qu => qu.QuotationID == this.quotationID).FirstOrDefault();
            int status = 0;
            if (quotationInfo != null && quotationInfo.QuotationStatus != null)
            {
                status = Convert.ToInt32(quotationInfo.QuotationStatus);
            }

            if (status > 3)
            {
                this.ActiveControls(false);
            }


            if (isAdd)
            {
                this.quotationBDList.RemoveAt(0);
            }

        }
        private void LoadQuotationStatus()
        {
            this.lkeQuotationsStatus.Properties.DataSource = FileProcess.LoadTable("Select * from CustomerQuotationStatus");
            this.lkeQuotationsStatus.Properties.ValueMember = "QuotationStatusID";
            this.lkeQuotationsStatus.Properties.DisplayMember = "QuotationStatusDescriptions";
        }

        private void BindingData()
        {
            this.txtCustomerResponse.DataBindings.Add("Text", this.dnQuotations.DataSource, "CustomerResponse", true, DataSourceUpdateMode.OnPropertyChanged);
            this.txtVatDesVn.DataBindings.Add("Text", this.dnQuotations.DataSource, "VATDescriptionVietnam", true, DataSourceUpdateMode.OnPropertyChanged);
            this.txtVatDes.DataBindings.Add("Text", this.dnQuotations.DataSource, "VATDescription", true, DataSourceUpdateMode.OnPropertyChanged);
            this.txtBDQuotation.DataBindings.Add("Text", this.dnQuotations.DataSource, "BDQuotationNumber", true, DataSourceUpdateMode.OnPropertyChanged);
            this.txtValidPeriod.DataBindings.Add("Text", this.dnQuotations.DataSource, "ValidPeriod", true, DataSourceUpdateMode.OnPropertyChanged);
            this.txtCustomerRepresentative.DataBindings.Add("Text", this.dnQuotations.DataSource, "CustomerRepresentative", true, DataSourceUpdateMode.OnPropertyChanged);
            this.txtPosition.DataBindings.Add("Text", this.dnQuotations.DataSource, "CustomerRepresentativePosition", true, DataSourceUpdateMode.OnPropertyChanged);
            this.txtQuotationID.DataBindings.Add("Text", this.dnQuotations.DataSource, "QuotationNumber", true, DataSourceUpdateMode.OnPropertyChanged);
            this.dQuotationDate.DataBindings.Add("DateTime", this.dnQuotations.DataSource, "QuotationDate", true, DataSourceUpdateMode.OnPropertyChanged);
            this.txtCreatedBy.DataBindings.Add("Text", this.dnQuotations.DataSource, "CreatedBy", true, DataSourceUpdateMode.OnPropertyChanged);
            this.dCreatedTime.DataBindings.Add("DateTime", this.dnQuotations.DataSource, "CreatedTime", true, DataSourceUpdateMode.OnPropertyChanged);
            this.mmRemark.DataBindings.Add("Text", this.dnQuotations.DataSource, "QuotationRemark", true, DataSourceUpdateMode.OnPropertyChanged);
            //this.CleanData();
            if (this.quotationBDList.Count > 0)
            {
                var currentQuotation = this.quotationBDList[this.dnQuotations.Position];
                this.lkePreviousContract.EditValue = currentQuotation.PreviousContractID;
                this.lkeCustomers.EditValue = currentQuotation.CustomerID;
                this.lkeStore.EditValue = currentQuotation.StoreID;
                this.lkeQuotationsStatus.EditValue = currentQuotation.QuotationStatus;
                this.lkeInquiry.EditValue = currentQuotation.CustomerInquiryID;
                if (!String.IsNullOrEmpty(currentQuotation.ApprovedBy))
                {
                    this.txtApprovedBy.Text = currentQuotation.ApprovedBy;
                    this.txtApprovedBy.ReadOnly = true;
                    this.daApproveTime.EditValue = currentQuotation.ApprovedTime;
                    this.daApproveTime.ReadOnly = true;
                }
                if (!String.IsNullOrEmpty(currentQuotation.ReviewedBy))
                {
                    this.txtReviewedBy.Text = currentQuotation.ReviewedBy;
                    this.txtReviewedBy.ReadOnly = true;
                    this.daReviewTime.EditValue = currentQuotation.ReviewTime;
                    this.daReviewTime.ReadOnly = true;
                }

                // Set active controls
                if (Convert.ToInt32(currentQuotation.QuotationStatus) > 3)
                {
                    this.ActiveControls(false);
                }
                else
                {
                    this.ActiveControls(true);
                }
            }

        }

        private void CleanData()
        {
            this.txtQuotationID.Text = "";
            this.quotationBDList[0].QuotationDate = DateTime.Now;
            //this.txtBDQuotation.Text = string.Empty;
            //this.txtValidPeriod.Text = string.Empty;
            this.dQuotationDate.DateTime = DateTime.Now;
            this.txtCreatedBy.Text = AppSetting.CurrentUser.LoginName;
            this.quotationBDList[0].CreatedBy = AppSetting.CurrentUser.LoginName;
            this.dCreatedTime.DateTime = DateTime.Now;
            this.quotationBDList[0].CreatedTime = DateTime.Now;
            this.mmRemark.Text = string.Empty;
            this.txtPosition.Text = string.Empty;
            this.txtCustomerRepresentative.Text = string.Empty;
            this.txtCustomerResponse.Text = string.Empty;
            this.lkeCustomers.EditValue = null;
            this.lkeInquiry.Text = "";
            this.lkeStore.EditValue = AppSetting.StoreID;
            this.quotationBDList[0].StoreID = AppSetting.StoreID;
            this.lkeQuotationsStatus.EditValue = 1;
            this.quotationBDList[0].QuotationStatus = 1;
            this.grdQuotationDetails.DataSource = null;
            this.lkeCustomers.Focus();
            this.lkePreviousContract.EditValue = null;
            this.ActiveControls(true);
            this.btnView.Enabled = false;
            this.btnViewVN.Enabled = false;
            this.btnConfirm.Enabled = false;
            this.btnDelete.Enabled = false;
            this.btnDuplicate.Enabled = false;
            this.btnSummary.Enabled = false;
            this.lkeInquiry.EditValue = 1;
            this.mmeScopeOfWork.Text = string.Empty;
            this.mmeScopeOfWorkVietNam.Text = string.Empty;
            this.txtReviewedBy.Text = string.Empty;
            this.txtReviewedBy.ReadOnly = false;
            this.txtApprovedBy.Text = string.Empty;
            this.txtApprovedBy.ReadOnly = false;
            this.daApproveTime.EditValue = null;
            this.daReviewTime.EditValue = null;
            this.quotationID = 0;
            this.txtValidPeriod.Text = "30 ngày";
            this.txtBDQuotation.Text = "VND";
            this.quotationBDList[0].BDQuotationNumber = "VND";
            this.quotationBDList[0].ValidPeriod = "30 ngày";

        }

        private void LoadCustomer()
        {
            this.lkeCustomers.Properties.DataSource = AppSetting.CustomerListAll;
            this.lkeCustomers.Properties.ValueMember = "CustomerID";
            this.lkeCustomers.Properties.DisplayMember = "CustomerNumber";
        }

        private void advQuotationDetails_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle < 0) return;
            switch (e.Column.FieldName)
            {
                case "LineNumber":
                case "UnitRate":
                case "QuotationDetailRemark":
                case "ServiceScopeOfWork":
                case "ServiceScopeOfWorkVietnam":
                case "ServiceDescription":
                case "EstimatedMonthlyVolume":
                case "ServiceNameInvoiced":
                case "VATPercentage":
                    int quotationDetailID = Convert.ToInt32(this.grvQuotationDetails.GetFocusedRowCellValue("QuotationDetailID"));
                    if (quotationDetailID > 0)
                    {
                        string quotationRemark = Convert.ToString(this.grvQuotationDetails.GetFocusedRowCellValue("QuotationDetailRemark"));
                        decimal unitRate = 0;
                        if (!Convert.IsDBNull(this.grvQuotationDetails.GetFocusedRowCellValue("UnitRate")))
                        {
                            unitRate = Convert.ToDecimal(this.grvQuotationDetails.GetFocusedRowCellValue("UnitRate"));
                        }

                        string scopeOfWork = Convert.ToString(this.grvQuotationDetails.GetFocusedRowCellValue("ServiceScopeOfWork"));
                        string scopeOfWorkVietNam = Convert.ToString(this.grvQuotationDetails.GetFocusedRowCellValue("ServiceScopeOfWorkVietnam"));

                        var currentQuotationDetail = this.quotationDetailsDA.Select(q => q.QuotationDetailID == quotationDetailID).FirstOrDefault();
                        switch (e.Column.FieldName)
                        {
                            case "UnitRate":
                                currentQuotationDetail.UnitRate = unitRate;
                                break;
                            case "EstimatedMonthlyVolume":
                                decimal estimated = Convert.ToDecimal(this.grvQuotationDetails.GetFocusedRowCellValue("EstimatedMonthlyVolume"));
                                currentQuotationDetail.EstimatedMonthlyVolume = estimated;
                                break;
                            case "QuotationDetailRemark":
                                currentQuotationDetail.QuotationDetailRemark = quotationRemark;
                                break;
                            case "ServiceDescription":
                                currentQuotationDetail.ServiceDescription = Convert.ToString(e.Value);
                                break;
                            case "ServiceNameInvoiced":
                                currentQuotationDetail.ServiceNameInvoiced = Convert.ToString(e.Value);
                                break;
                            case "VATPercentage":
                                currentQuotationDetail.VATPercentage = Convert.ToByte(e.Value);
                                break;
                            case "ServiceScopeOfWork":
                                currentQuotationDetail.ServiceScopeOfWork = scopeOfWork;
                                break;
                            case "ServiceScopeOfWorkVietnam":
                                currentQuotationDetail.ServiceScopeOfWorkVietnam = scopeOfWork;
                                break;
                            case "LineNumber":
                                currentQuotationDetail.LineNumber = Convert.ToInt32(e.Value);
                                break;
                        }

                        // Update data
                        this.quotationDetailsDA.Update(currentQuotationDetail);
                    }
                    break;
            }
        }

        private void Btn_NEW_WM_MhlWorks_Click(object sender, EventArgs e)
        {
            this.CleanData();
            this.grvQuotationDetails.OptionsBehavior.ReadOnly = true;
        }

        private void mmeScopeOfWork_EditValueChanged_1(object sender, EventArgs e)
        {

        }

        private void dockPanelMonthService_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            if (this.lkeCustomers.EditValue == null || this.quotationID <= 0) return;
            int customerID = Convert.ToInt32(this.lkeCustomers.EditValue);

            if (this.viewMonthService == null)
            {
                this.viewMonthService = new urc_CRM_12MonthServices(customerID, this.quotationID);
                this.viewMonthService.Parent = this.dockPanelMonthService;
            }
            else
            {
                this.viewMonthService.InitData(customerID, this.quotationID);
            }
            this.viewMonthService.Show();
            this.viewMonthService.Dock = DockStyle.Fill;
        }

        private void dockPanelProfitability_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            if (this.lkeCustomers.EditValue == null || this.quotationID <= 0) return;
            int customerID = Convert.ToInt32(this.lkeCustomers.EditValue);

            if (this.Profitability == null)
            {
                this.Profitability = new urc_CRM_12MonthProfitability(customerID);
                this.Profitability.Parent = this.dockPanelProfitability;
            }
            else
            {
                this.Profitability.InitProfitabilityData(customerID);
            }
            this.Profitability.Show();
            this.Profitability.Dock = DockStyle.Fill;
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.F3)
            {
                frm_WM_Attachments.Instance.OrderNumber = this.lkeCustomers.Text;
                frm_WM_Attachments.Instance.CustomerID = Convert.ToInt16(this.lkeCustomers.EditValue);
                if (frm_WM_Attachments.Instance.Enabled) frm_WM_Attachments.Instance.ShowDialog();
            }
            else if (keyData == Keys.F4)
            {

                //save the  quotation to the PDF file 

                if (XtraMessageBox.Show("Are you sure to add EN report (Yes:EN / No:VN) ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Common.Process.Wait.Start(this);
                    rptQuotation rpt = new rptQuotation();
                    var dataSource = FileProcess.LoadTable("STCustomerQuotationPrint " + this.quotationID);
                    rpt.DataSource = dataSource;
                    rpt.xrQuotationRemark.Text = this.mmRemark.Text;
                    if (!string.IsNullOrEmpty(this.txtVatDes.Text))
                    {
                        rpt.lblVATDes.Text = this.txtVatDes.Text;
                    }
                    subrptProductInquiry subProductInquiry = new subrptProductInquiry();
                    subProductInquiry.DataSource = FileProcess.LoadTable("STCustomerQuotationProductInquiries " + this.quotationID);
                    rpt.xrProductInquiry.ReportSource = subProductInquiry;
                    rpt.CreateDocument();
                    subrptQuotationScoreOfWork subScopeOfWork = new subrptQuotationScoreOfWork();
                    subScopeOfWork.DataSource = dataSource;
                    subScopeOfWork.CreateDocument();
                    rpt.Pages.AddRange(subScopeOfWork.Pages);
                    rpt.PrintingSystem.ContinuousPageNumbering = true;

                    string quotationfileName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + this.txtQuotationID.Text + ".pdf";
                    //string quotationfileName = ConfigurationManager.AppSettings["PathPasteFile"] + "\\" + this.txtQuotationID.Text + ".pdf";
                    rpt.ExportToPdf(quotationfileName);
                    frm_WM_Attachments.Instance.OrderNumber = this.txtQuotationID.Text;
                    frm_WM_Attachments.Instance.SaveAttachFile(quotationfileName, "Auto");
                }
                else
                {
                    Common.Process.Wait.Start(this);
                    rptQuotationVN rpt = new rptQuotationVN();
                    var dataSource = FileProcess.LoadTable("STCustomerQuotationPrint " + this.quotationID);
                    rpt.DataSource = dataSource;
                    rpt.xrQuotationRemark.Text = this.mmRemark.Text;
                    if (!string.IsNullOrEmpty(this.txtVatDes.Text))
                    {
                        rpt.lblVATDesVN.Text = this.txtVatDes.Text;
                    }
                    subrptProductInquiryVN subProductInquiry = new subrptProductInquiryVN();
                    subProductInquiry.DataSource = FileProcess.LoadTable("STCustomerQuotationProductInquiries " + this.quotationID);
                    rpt.xrProductInquiryVN.ReportSource = subProductInquiry;
                    rpt.CreateDocument();
                    subrptQuotationScoreOfWorkVN subScopeOfWork = new subrptQuotationScoreOfWorkVN();
                    subScopeOfWork.DataSource = dataSource;
                    subScopeOfWork.CreateDocument();
                    rpt.Pages.AddRange(subScopeOfWork.Pages);
                    rpt.PrintingSystem.ContinuousPageNumbering = true;

                    string quotationfileName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + this.txtQuotationID.Text + ".pdf";
                    //string quotationfileName = ConfigurationManager.AppSettings["PathPasteFile"] + "\\" + this.txtQuotationID.Text + ".pdf";
                    rpt.ExportToPdf(quotationfileName);
                    frm_WM_Attachments.Instance.OrderNumber = this.txtQuotationID.Text;
                    frm_WM_Attachments.Instance.SaveAttachFile(quotationfileName, "Auto");

                }

            }
            return base.ProcessDialogKey(keyData);
        }

        private void btnCreateTempContract_Click(object sender, EventArgs e)
        {
            if (this.quotationID <= 0) return;
            // Validate before confirm
            if (!this.dxValidationProvider1.Validate()) return;

            var currentQuotation = this.quotationDA.Select(q => q.QuotationID == this.quotationID).FirstOrDefault();
            currentQuotation.QuotationStatus = 4;
            this.lkeQuotationsStatus.EditValue = currentQuotation.QuotationStatus;
            this.quotationDA.Update(currentQuotation);

            // Create new contract and contract details
            DataProcess<Contracts> contractDA = new DataProcess<Contracts>();
            DataProcess<ServicesDefinition> serviceDA = new DataProcess<ServicesDefinition>();
            DataProcess<ContractDetails> contractDetailsDA = new DataProcess<ContractDetails>();

            string customerNo = AppSetting.CustomerListAll.Where(c => c.CustomerID == currentQuotation.CustomerID).FirstOrDefault().CustomerNumber.Split('-')[0];
            int maxContractID = contractDA.Select().OrderByDescending(c => c.ContractID).FirstOrDefault().ContractID + 1;
            Contracts newContract = new Contracts();
            newContract.ContractDate = (DateTime)currentQuotation.QuotationDate;
            newContract.ContractRemark = currentQuotation.QuotationRemark;
            newContract.ContractType = 1;
            newContract.ContractNumber = customerNo + "-" + maxContractID + "-" + Convert.ToDateTime(newContract.ContractDate).Year;
            newContract.CreatedBy = AppSetting.CurrentUser.LoginName;
            newContract.CreatedTime = DateTime.Now;
            newContract.CustomerID = currentQuotation.CustomerID;
            newContract.EndDate = DateTime.Now.AddYears(1);
            newContract.StartDate = DateTime.Now;
            newContract.QuotationID = this.quotationID;
            newContract.ContractProgressStatus = 4;
            newContract.CurrencyUnit = currentQuotation.BDQuotationNumber;
            newContract.StartDate = null;
            newContract.EndDate = null;
            newContract.ReviewDate = null;
            newContract.ContractDate = null;
            newContract.AppendixNumber = null;
            newContract.AccountingStatus = 0;
            // Insert contract
            contractDA.Insert(newContract);

            // Create contract details
            ContractDetails newContractDetail = null;
            IList<ContractDetails> contractDetails = new List<ContractDetails>();

            //foreach (CustomerQuotationDetail quotationDetailItem in this.quotationDetailsBDList.OrderBy(q => q.LineNumber))
            foreach (CustomerQuotationDetail quotationDetailItem in this.quotationDetailsBDList.OrderBy(q => q.LineNumber))
            {
                newContractDetail = new ContractDetails();
                if (quotationDetailItem.QuotationDetailID <= 0) continue;
                newContractDetail.CheckingQuantity = Convert.ToDouble(quotationDetailItem.UnitRate);
                newContractDetail.ContractDetailRemark = quotationDetailItem.QuotationDetailRemark;
                newContractDetail.ContractID = newContract.ContractID;
                newContractDetail.CurrencyUnit = "US";
                newContractDetail.ScopeOfWork = quotationDetailItem.ServiceScopeOfWork;
                newContractDetail.ScopeOFWorkVietnam = quotationDetailItem.ServiceScopeOfWorkVietnam;
                newContractDetail.ServiceID = quotationDetailItem.ServiceID;
                newContractDetail.LineNumber = quotationDetailItem.LineNumber;
                newContractDetail.UpdatedBy = AppSetting.CurrentUser.LoginName;
                newContractDetail.UpdateTime = DateTime.Now;
                newContractDetail.ServiceNameInvoiced = quotationDetailItem.ServiceNameInvoiced;
                newContractDetail.VATPercentage = 10;
                contractDetails.Add(newContractDetail);
            }

            // Insert contract details
            int result = contractDetailsDA.Insert(contractDetails.ToArray());

            // Invoke to contract form
            int customerID = Convert.ToInt32(currentQuotation.CustomerID);
            if (customerID <= 0) return;
            frm_MSS_Contracts frm = frm_MSS_Contracts.GetInstance(customerID);
            frm.InitData(customerID);
            frm.BringToFront();
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();

            // Set acticontrol
            this.ActiveControls(false);
        }

        private void txtCustomerName_Click(object sender, EventArgs e)
        {
            if (this.lkeCustomers.EditValue == null) return;
            Customers currentCustomer = AppSetting.CustomerList.Where(c => c.CustomerID == Convert.ToInt32(this.lkeCustomers.EditValue)).FirstOrDefault();
            frm_MSS_Customers frmCustomer = MasterSystemSetup.frm_MSS_Customers.Instance;
            if (!frmCustomer.Enabled) return;
            frmCustomer.CurrentCustomers = currentCustomer;
            frmCustomer.WindowState = FormWindowState.Normal;
            frmCustomer.BringToFront();
            frmCustomer.Show();
        }

        private void grvQuotationDetails_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
        {
            //if (e.PrevFocusedColumn == null) return;
            //if (e.PrevFocusedColumn.FieldName.Equals("EstimatedMonthlyVolume"))
            //{
            //    int quotationID = Convert.ToInt32(this.grvQuotationDetails.GetFocusedRowCellValue("QuotationDetailID"));
            //    string valueVolume = Convert.ToString(this.grvQuotationDetails.GetFocusedRowCellValue("EstimatedMonthlyVolume"));
            //    if(string.IsNullOrEmpty(valueVolume) && quotationID>0)
            //    {
            //        this.grvQuotationDetails.FocusedColumn = e.PrevFocusedColumn;
            //        this.grvQuotationDetails.SetColumnError(e.PrevFocusedColumn, "Required field", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning);
            //        this.grvQuotationDetails.ShowEditor();
            //    }
            //}
        }

        private void grvQuotationDetails_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            if (e.RowHandle < 0) return;
            int quotationID = Convert.ToInt32(this.grvQuotationDetails.GetFocusedRowCellValue("QuotationDetailID"));
            string valueVolume = Convert.ToString(this.grvQuotationDetails.GetFocusedRowCellValue("EstimatedMonthlyVolume"));
            if (string.IsNullOrEmpty(valueVolume) && quotationID > 0)
            {
                e.Valid = false;
                this.grvQuotationDetails.FocusedColumn = this.gridColumn9;
                this.grvQuotationDetails.SetColumnError(this.gridColumn9, "Required field", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning);
                this.grvQuotationDetails.ShowEditor();
            }
        }

        private void grvQuotationDetails_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void dockPanelCostStructure_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            if (this.lkeCustomers.EditValue == null) return;
            int customerID = Convert.ToInt32(this.lkeCustomers.EditValue);

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

        private void dockPanelRatesHistory_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            if (this.lkeCustomers.EditValue == null) return;
            int customerID = Convert.ToInt32(this.lkeCustomers.EditValue);

            if (this.RatesHistory == null)
            {
                this.RatesHistory = new urc_CRM_RatesHistory(customerID);
                this.RatesHistory.Parent = this.dockPanelRatesHistory;
            }
            else
            {
                this.RatesHistory.InitRateHistory(customerID);
            }
            this.RatesHistory.Show();
            this.RatesHistory.Dock = DockStyle.Fill;
        }

        private void controlContainer3_FontChanged(object sender, EventArgs e)
        {

        }

        private void dockPanel36MonthsOperation_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            if (this.lkeCustomers.EditValue == null) return;
            int customerID = Convert.ToInt32(this.lkeCustomers.EditValue);
            

            if (this.monthsOperation == null)
            {
                this.monthsOperation = new urc_CRM_36MonthsOperation(customerID, 0);
                this.monthsOperation.Parent = this.dockPanel36MonthsOperation;
            }
            else
            {
                this.monthsOperation.init36MonthsOperation(customerID,0 );
            }
            this.monthsOperation.Show();
            this.monthsOperation.Dock = DockStyle.Fill;
        }

        private void rpe_hle_CostBreakdown_Click(object sender, EventArgs e)
        {
            //frm_CRM_CostBreakdown frm = new frm_CRM_CostBreakdown(Convert.ToInt32(this.lkeCustomers.EditValue), Convert.ToInt32(this.grvQuotationDetails.GetFocusedRowCellValue("ServiceID")));
            //frm.Show();
            //frm.WindowState = FormWindowState.Maximized;


        }

        private void rpe_hle_CompareRate_Click(object sender, EventArgs e)
        {
            //frm_CRM_CompareRates frm = new frm_CRM_CompareRates(Convert.ToInt32(this.grvQuotationDetails.GetFocusedRowCellValue("ContractDetailID")));
            //frm.ShowDialog();
        }
    }
}
