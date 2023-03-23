using System;
using System.Linq;
using DA;
using Common.Controls;
using UI.Helper;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraEditors;
using System.ComponentModel;
using DevExpress.XtraGrid.Views.Base;
using UI.WarehouseManagement;
using Slack.Webhooks;
using System.Collections.Generic;
using UI.Management;

namespace UI.CRM
{
    public partial class frm_CRM_Inquiry : frmBaseForm
    {
        private DataProcess<CustomerInquiry> inquiryDA = new DataProcess<CustomerInquiry>();
        private DataProcess<CustomerInquiryDetail> inquiryDetailsDA = new DataProcess<CustomerInquiryDetail>();
        private DataProcess<ST_WMS_LoadInquiryServicesByInquiryDetailsID_Result> combineInquiryServiceDA = new DataProcess<ST_WMS_LoadInquiryServicesByInquiryDetailsID_Result>();
        private DataProcess<CustomerInquiryService> inquiryServiceDA = new DataProcess<CustomerInquiryService>();
        private BindingList<CustomerInquiry> inquiryBDList = null;
        private BindingList<ST_WMS_LoadInquiryDetailByInquiryID_Result> inquiryDetailDBList = null;
        private BindingList<ST_WMS_LoadInquiryServicesByInquiryDetailsID_Result> inquiryServiceDB = null;
        private bool isFirstLoad = true;
        private int inquiryIDSelected = 0;
        private bool isConfirmed = true;

        public frm_CRM_Inquiry(int inquiryID)
        {
            InitializeComponent();

            // Set param input
            this.inquiryIDSelected = inquiryID;

            // Init events
            this.InitEvents();

            // Init data 
            this.LoadCustomer();
            this.LoadStore();
            this.LoadAllServiceDefinition();
            this.LoadServiceList();
            this.LoadInquiry();
            this.BindingData();

            this.isFirstLoad = false;
        }

        private void InitEvents()
        {
            this.dnInquiry.PositionChanged += DnInquiry_PositionChanged;
            this.lkeCustomers.CloseUp += LkeCustomers_CloseUp;
            this.lkeCustomers.EditValueChanged += LkeCustomers_EditValueChanged;
            this.btnClose.Click += BtnClose_Click;
            this.btnDelete.Click += BtnDelete_Click;
            this.btnNew.Click += BtnNew_Click;
            this.lkeStore.EditValueChanged += DQuotationDate_EditValueChanged;
            this.dInquiryDate.EditValueChanged += DQuotationDate_EditValueChanged;
            this.rpi_lke_ProductDefinition.EditValueChanged += Rpi_lke_ProductDefinition_EditValueChanged;
            this.grvInquiryDetails.CellValueChanged += GrvInquiryDetails_CellValueChanged;
            this.grvInquiryDetails.FocusedRowChanged += GrvInquiryDetails_FocusedRowChanged;
            this.mmRemark.EditValueChanged += MmRemark_EditValueChanged;
            this.rpi_lke_ServiceDefinition.EditValueChanged += Rpi_lke_ServiceDefinition_EditValueChanged;
            this.grvInquiryServices.CellValueChanged += Adv_grvInquiryServices_CellValueChanged;
            this.grvInquiryServices.RowCellClick += GrvInquiryServices_RowCellClick;
            this.grvInquiryDetails.KeyDown += GrvInquiryDetails_KeyDown;
            this.grvInquiryServices.KeyDown += GrvInquiryServices_KeyDown;
            this.mmeScopeOfWork.Leave += MmeScopeOfWork_EditValueChanged;
            this.mmeScopeOfWorkVN.Leave += MmeScopeOfWorkVN_EditValueChanged;
            this.btnNewQuotation.Click += BtnNewQuotation_Click;
        }

        private void BtnNewQuotation_Click(object sender, EventArgs e)
        {
            // Insert quotation
            int inquiryID = Convert.ToInt32(this.txtInquiryNumber.Text);
            if (inquiryID <= 0)
            {
                MessageBox.Show("Please create new Customer Inquiry before create new Customer Quotaiton", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int customerMainID = Convert.ToInt32(this.lkeCustomers.GetColumnValue("CustomerMainID"));
            int customerID = Convert.ToInt32(this.lkeCustomers.EditValue);

            CustomerQuotation newQuotation = new CustomerQuotation();
            newQuotation.CreatedBy = AppSetting.CurrentUser.LoginName;
            newQuotation.CreatedTime = DateTime.Now;
            newQuotation.CustomerID = customerID;
            newQuotation.CustomerInquiryID = 0;
            newQuotation.CustomerMainID = customerMainID;
            newQuotation.QuotationDate = DateTime.Now;
            newQuotation.QuotationStatus = 1;// Un-confirm
            newQuotation.QuotationRemark = this.mmRemark.Text;
            newQuotation.CustomerInquiryID = inquiryID;
            newQuotation.StoreID = AppSetting.StoreID;
            DataProcess<CustomerQuotation> quotationDA = new DataProcess<CustomerQuotation>();
            quotationDA.Insert(newQuotation);
            if (newQuotation.QuotationID > 0)
            {
                frm_CRM_Quotation frm = new frm_CRM_Quotation(newQuotation.QuotationID);
                frm.Show();
            }
        }

        private void LkeCustomers_EditValueChanged(object sender, EventArgs e)
        {
            if (this.lkeCustomers.EditValue == null)
            {
                this.txtCustomerName.Text = string.Empty;
                return;
            }

            int customerID = Convert.ToInt32(this.lkeCustomers.EditValue);
            var customerFind = AppSetting.CustomerListAll.Where(cus => cus.CustomerID == customerID).FirstOrDefault();
            this.txtCustomerName.Text = customerFind.CustomerName;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {


            if (grvInquiryDetails.RowCount > 0)
            {
                int checkDelete = Convert.ToInt32(this.grvInquiryDetails.GetRowCellValue(0, "CustomerInquiryProductDefinitionID"));
                if(checkDelete==0)
                {
                    FileProcess.LoadTable("delete from CustomerInquiries where CustomerInquiryID=" + inquiryIDSelected);
                    this.Close();
                    return;
                }

                MessageBox.Show("Please delete all inquiry detail !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                FileProcess.LoadTable("delete from CustomerInquiries where CustomerInquiryID=" + inquiryIDSelected);
                this.Close();
            }

        }

        private void GrvInquiryServices_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    var currentService = (ST_WMS_LoadInquiryServicesByInquiryDetailsID_Result)this.grvInquiryServices.GetFocusedRow();
                    FileProcess.LoadTable("delete from CustomerInquiryServices where CustomerInquiryServiceID=" + currentService.CustomerInquiryServiceID);
                    inquiryServiceDB.Remove(currentService);
                    this.grdInquiryServices.DataSource = inquiryServiceDB;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nothing service to delete !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void GrvInquiryDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.KeyCode.Equals(Keys.Delete)) return;
            if (grvInquiryServices.RowCount > 1)
            {
                MessageBox.Show("Please delete all service detail !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var currentDetail = (ST_WMS_LoadInquiryDetailByInquiryID_Result)this.grvInquiryDetails.GetFocusedRow();
                FileProcess.LoadTable("Delete from CustomerInquiryDetails where CustomerInquiryDetailID=" + currentDetail.CustomerInquiryDetailID);
                inquiryDetailDBList.Remove(currentDetail);
                this.grdInquiryDetails.DataSource = inquiryDetailDBList;
            }
        }

        private void ActiveControls(bool isActive)
        {

        }

        private void MmeScopeOfWorkVN_EditValueChanged(object sender, EventArgs e)
        {
            if (this.grvInquiryServices.FocusedRowHandle >= 0 && this.mmeScopeOfWorkVN.IsModified)
            {
                this.grvInquiryServices.SetFocusedRowCellValue("ServiceScopeOfWorkVietnam", this.mmeScopeOfWorkVN.Text);
                int inquiryDetailID = Convert.ToInt32(this.grvInquiryDetails.GetFocusedRowCellValue("CustomerInquiryDetailID"));
                string query = "Update CustomerInquiryDetails set ServiceScopeOfWorkVietnam='" + this.mmeScopeOfWorkVN.Text + "' where CustomerInquiryDetailID=" + inquiryDetailID;
                DataProcess<object> quotationDA = new DataProcess<object>();
                quotationDA.ExecuteNoQuery(query);
            }
        }

        private void MmeScopeOfWork_EditValueChanged(object sender, EventArgs e)
        {
            if (this.grvInquiryServices.FocusedRowHandle >= 0 && this.mmeScopeOfWork.IsModified)
            {
                this.grvInquiryServices.SetFocusedRowCellValue("ServiceScopeOfWork", this.mmeScopeOfWork.Text);
                int inquiryDetailID = Convert.ToInt32(this.grvInquiryDetails.GetFocusedRowCellValue("CustomerInquiryDetailID"));
                string query = "Update CustomerInquiryDetails set ServiceScopeOfWork='" + this.mmeScopeOfWork.Text + "' where CustomerInquiryDetailID=" + inquiryDetailID;
                DataProcess<object> quotationDA = new DataProcess<object>();
                quotationDA.ExecuteNoQuery(query);
            }
        }

        private void GrvInquiryServices_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.RowHandle < 0) return;
            string scopeOfwork = Convert.ToString(this.grvInquiryServices.GetFocusedRowCellValue("ServiceScopeOfWork"));
            string scopeOfworkVietNam = Convert.ToString(this.grvInquiryServices.GetFocusedRowCellValue("ServiceScopeOfWorkVietnam"));
            this.mmeScopeOfWork.Text = scopeOfwork;
            this.mmeScopeOfWorkVN.Text = scopeOfworkVietNam;
        }

        private void Adv_grvInquiryServices_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle < 0) return;
            int inquiryServiceID = Convert.ToInt32(this.grvInquiryServices.GetFocusedRowCellValue("CustomerInquiryServiceID"));
            if (inquiryServiceID <= 0) return;
            string query = string.Empty;
            int resultInsert = 0;
            bool isUpdate = false;

            switch (e.Column.FieldName)
            {
                case "ServiceQuantity":
                    isUpdate = true;
                    int qty = Convert.ToInt32(e.Value);
                    query = "Update CustomerInquiryServices set ServiceQuantity='" + qty + "' where CustomerInquiryServiceID=" + inquiryServiceID;
                    break;
                case "CustomerInquiryServiceRemark":
                    isUpdate = true;
                    string remark = Convert.ToString(e.Value);
                    query = "Update CustomerInquiryServices set CustomerInquiryServiceRemark='" + remark + "' where CustomerInquiryServiceID=" + inquiryServiceID;
                    break;

                case "ServiceScopeOfWork":
                    isUpdate = true;
                    string scopeOfwork = Convert.ToString(e.Value);
                    query = "Update CustomerInquiryServices set ServiceScopeOfWork='" + scopeOfwork + "' where CustomerInquiryServiceID=" + inquiryServiceID;
                    break;

                case "ServiceScopeOfWorkVietnam":
                    isUpdate = true;
                    string scopeOfworkVietNam = Convert.ToString(e.Value);
                    query = "Update CustomerInquiryServices set ServiceScopeOfWorkVietnam='" + scopeOfworkVietNam + "' where CustomerInquiryServiceID=" + inquiryServiceID;
                    break;
            }

            if (isUpdate)
            {
                resultInsert = inquiryServiceDA.ExecuteNoQuery(query);
            }
        }

        private void Rpi_lke_ServiceDefinition_EditValueChanged(object sender, EventArgs e)
        {
            // Add new inquiry Service
            var lke = (LookUpEdit)sender;
            if (lke.EditValue == null) return;
            int inquiryDetailID = Convert.ToInt32(this.grvInquiryDetails.GetFocusedRowCellValue("CustomerInquiryDetailID"));

            var serviceSelected = (ServicesDefinition)lke.GetSelectedDataRow();
            if (serviceSelected == null) return;
            this.grvInquiryServices.SetFocusedRowCellValue("ServiceID", serviceSelected.ServiceID);
            this.grvInquiryServices.SetFocusedRowCellValue("ServiceName", serviceSelected.ServiceName);
            this.grvInquiryServices.SetFocusedRowCellValue("ServiceScopeOfWork", serviceSelected.ScopeOfWork);
            this.grvInquiryServices.SetFocusedRowCellValue("ServiceScopeOFWorkVietnam", serviceSelected.ScopeOFWorkVietnam);
            this.grvInquiryServices.SetFocusedRowCellValue("CreatedBy", AppSetting.CurrentUser.LoginName);
            this.grvInquiryServices.SetFocusedRowCellValue("CreatedTime", DateTime.Now);
            this.grvInquiryServices.SetFocusedRowCellValue("CustomerInquiryDetailID", inquiryDetailID);
            this.mmeScopeOfWork.Text = serviceSelected.ScopeOfWork;
            this.mmeScopeOfWorkVN.Text = serviceSelected.ScopeOFWorkVietnam;

            int rowHandle = this.grvInquiryServices.FocusedRowHandle;
            int inquiryServiceID = Convert.ToInt32(this.grvInquiryDetails.GetFocusedRowCellValue("CustomerInquiryServiceID"));

            CustomerInquiryService currentInquiryService = null;
            if (inquiryServiceID > 0 && rowHandle > -1)
            {
                // Update inquiry service details
                currentInquiryService = this.inquiryServiceDA.Select(i => i.CustomerInquiryServiceID == inquiryServiceID).FirstOrDefault();
            }
            else
            {
                // Insert inquiry service details
                currentInquiryService = new CustomerInquiryService();
                currentInquiryService.CreatedBy = AppSetting.CurrentUser.LoginName;
                currentInquiryService.CreatedTime = DateTime.Now;
            }

            currentInquiryService.CustomerInquiryDetailID = inquiryDetailID;
            currentInquiryService.ServiceID = serviceSelected.ServiceID;
            currentInquiryService.ServiceQuantity = string.Empty;
            currentInquiryService.ServiceScopeOfWork = serviceSelected.ScopeOfWork;
            currentInquiryService.ServiceScopeOfWorkVietnam = serviceSelected.ScopeOFWorkVietnam;

            // Detect is process insert or update
            if (inquiryServiceID > 0 && rowHandle > -1)
            {
                // Process update 
                this.inquiryServiceDA.Update(currentInquiryService);
            }
            else
            {
                // Process insert
                this.inquiryServiceDA.Insert(currentInquiryService);
                this.grvInquiryServices.SetFocusedRowCellValue("CustomerInquiryServiceID", currentInquiryService.CustomerInquiryServiceID);
                int lastInquiryServiceID = Convert.ToInt32(this.grvInquiryServices.GetRowCellValue(this.grvInquiryServices.RowCount - 1, "CustomerInquiryServiceID"));
                if (lastInquiryServiceID > 0)
                {
                    var newService = new ST_WMS_LoadInquiryServicesByInquiryDetailsID_Result();
                    newService.ServiceID = -1;
                    this.inquiryServiceDB.Add(newService);
                }
                this.grvInquiryServices.RefreshData();
            }
        }

        private void GrvInquiryDetails_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0) return;
            int inquiryDetailsID = Convert.ToInt32(this.grvInquiryDetails.GetFocusedRowCellValue("CustomerInquiryDetailID"));

            // Load all inquiry service
            var dataSouce = this.combineInquiryServiceDA.Executing("ST_WMS_LoadInquiryServicesByInquiryDetailsID @InquiryDetailsID={0}", inquiryDetailsID);
            this.inquiryServiceDB = new BindingList<ST_WMS_LoadInquiryServicesByInquiryDetailsID_Result>(dataSouce.ToList());
            var newService = new ST_WMS_LoadInquiryServicesByInquiryDetailsID_Result();
            newService.ServiceID = -1;
            this.inquiryServiceDB.Add(newService);
            this.grdInquiryServices.DataSource = this.inquiryServiceDB;
        }

        /// <summary>
        /// Load all service definition
        /// </summary>
        private void LoadAllServiceDefinition()
        {
            DataProcess<ServicesDefinition> serviceDA = new DataProcess<ServicesDefinition>();
            this.rpi_lke_ServiceDefinition.DataSource = serviceDA.Select();
            this.rpi_lke_ServiceDefinition.DisplayMember = "ServiceNumber";
            this.rpi_lke_ServiceDefinition.ValueMember = "ServiceID";
        }
        private void MmRemark_EditValueChanged(object sender, EventArgs e)
        {
            if (this.mmRemark.IsModified)
            {
                DataProcess<object> quotationDA = new DataProcess<object>();
                string query = "Update CustomerInquiries set CustomerInquiryRemark= N'" + this.mmRemark.Text + "' where CustomerInquiryID=" + this.inquiryIDSelected;
                int resultInsert = quotationDA.ExecuteNoQuery(query);
            }
        }

        private void GrvInquiryDetails_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle < 0) return;
            int inquiryDetailID = Convert.ToInt32(this.grvInquiryDetails.GetFocusedRowCellValue("CustomerInquiryDetailID"));
            if (inquiryDetailID <= 0) return;
            string query = string.Empty;
            int resultInsert = 0;
            bool isUpdate = false;

            switch (e.Column.FieldName)
            {
                case "TemperatureRange":
                    isUpdate = true;
                    string temp = Convert.ToString(e.Value);
                    query = "Update CustomerInquiryDetails set TemperatureRange=N'" + temp + "' where CustomerInquiryDetailID=" + inquiryDetailID;
                    break;
                case "HumidityRange":
                    isUpdate = true;
                    string humidity = Convert.ToString(e.Value);
                    query = "Update CustomerInquiryDetails set HumidityRange=N'" + humidity + "' where CustomerInquiryDetailID=" + inquiryDetailID;
                    break;
                case "StorageRoom":
                    isUpdate = true;
                    string storage = Convert.ToString(e.Value);
                    query = "Update CustomerInquiryDetails set StorageRoom=N'" + storage + "' where CustomerInquiryDetailID=" + inquiryDetailID;
                    break;
                case "CustomerInquiryQuantity":
                    isUpdate = true;
                    int qty = Convert.ToInt32(e.Value);
                    query = "Update CustomerInquiryDetails set CustomerInquiryQuantity=" + qty + " where CustomerInquiryDetailID=" + inquiryDetailID;
                    break;
                case "CustomerInquiryDetailRemark":
                    isUpdate = true;
                    string remark = Convert.ToString(e.Value);
                    query = "Update CustomerInquiryDetails set CustomerInquiryDetailRemark=N'" + remark + "' where CustomerInquiryDetailID=" + inquiryDetailID;
                    break;
            }

            if (isUpdate)
            {
                DataProcess<object> quotationDA = new DataProcess<object>();
                resultInsert = quotationDA.ExecuteNoQuery(query);
            }
        }

        private void LkeCustomers_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            this.lkeCustomers.EditValue = e.Value;
            if (this.lkeCustomers.EditValue == null)
            {
                return;
            }
            if (this.inquiryIDSelected <= 0)
            {
                // Insert quotation
                int customerMainID = Convert.ToInt32(this.lkeCustomers.GetColumnValue("CustomerMainID"));
                int customerID = Convert.ToInt32(this.lkeCustomers.EditValue);
                string quotationRemark = this.mmRemark.Text;

                CustomerInquiry customerInquiry = new CustomerInquiry();
                customerInquiry.CreatedBy = AppSetting.CurrentUser.LoginName;
                customerInquiry.CreatedTime = DateTime.Now;
                customerInquiry.CustomerID = customerID;
                customerInquiry.CustomerInquiryDate = DateTime.Now;
                customerInquiry.CustomerInquiryRemark = quotationRemark;
                customerInquiry.CustomerInquiryStatus = 0;
                customerInquiry.CustomerMainID = customerMainID;

                this.inquiryDA.Insert(customerInquiry);
                this.txtInquiryID.Text = Convert.ToString("CL-" + customerInquiry.CustomerInquiryID);
                this.txtInquiryNumber.Text = Convert.ToString(customerInquiry.CustomerInquiryID);
                this.inquiryIDSelected = customerInquiry.CustomerInquiryID;
                this.inquiryBDList.Add(customerInquiry);
                this.LoadQuotationDetais(customerInquiry.CustomerInquiryID);
            }
            else
            {
                int customerMainID = Convert.ToInt32(this.lkeCustomers.GetColumnValue("CustomerMainID"));
                int customerID = Convert.ToInt32(this.lkeCustomers.EditValue);
                CustomerInquiry customerInquiry = this.inquiryDA.Select(q => q.CustomerInquiryID == this.inquiryIDSelected).FirstOrDefault();
                customerInquiry.CustomerID = customerID;
                customerInquiry.CustomerMainID = customerMainID;
                this.inquiryDA.Update(customerInquiry);
            }
        }

        private void DQuotationDate_EditValueChanged(object sender, EventArgs e)
        {
            if (this.isFirstLoad) return;
            DateTime quotationDate = this.dInquiryDate.DateTime;
            string storeID = Convert.ToString(this.lkeStore.EditValue);

            DataProcess<object> quotationDA = new DataProcess<object>();
            string query = "Update CustomerInquiries set StoreID='" + storeID + "' where CustomerInquiryID=" + this.inquiryIDSelected;
            int resultInsert = quotationDA.ExecuteNoQuery(query);
        }

        private void Rpi_lke_ProductDefinition_EditValueChanged(object sender, EventArgs e)
        {
            var lke = (LookUpEdit)sender;
            if (lke.EditValue == null) return;
            var productSelected = (CustomerInquiryProductDefinition)lke.GetSelectedDataRow();
            this.grvInquiryDetails.SetFocusedRowCellValue("CustomerInquiryProductDefinitionID", productSelected.CustomerInquiryProductDefinitionID);
            this.grvInquiryDetails.SetFocusedRowCellValue("HumidityRange", productSelected.HumidityRange);
            this.grvInquiryDetails.SetFocusedRowCellValue("OtherRequirement", productSelected.OtherRequirement);
            this.grvInquiryDetails.SetFocusedRowCellValue("ProductDescriptions", productSelected.ProductDescriptions);
            this.grvInquiryDetails.SetFocusedRowCellValue("StorageRoom", productSelected.StorageRoom);
            this.grvInquiryDetails.SetFocusedRowCellValue("TemperatureRange", productSelected.TemperatureRange);

            int rowHandle = this.grvInquiryDetails.FocusedRowHandle;
            int inquiryDetailID = Convert.ToInt32(this.grvInquiryDetails.GetFocusedRowCellValue("CustomerInquiryDetailID"));
            string inquiryRemark = Convert.ToString(this.grvInquiryDetails.GetFocusedRowCellValue("CustomerInquiryDetailRemark"));
            int qty = Convert.ToInt32(this.grvInquiryDetails.GetFocusedRowCellValue("CustomerInquiryQuantity"));

            CustomerInquiryDetail currentInquiryDetails = null;
            if (inquiryDetailID > 0 && rowHandle > -1)
            {
                // Update inquiry details
                currentInquiryDetails = this.inquiryDetailsDA.Select(i => i.CustomerInquiryDetailID == inquiryDetailID).FirstOrDefault();
            }
            else
            {
                // Insert inquiry details
                currentInquiryDetails = new CustomerInquiryDetail();
                currentInquiryDetails.CreatedBy = AppSetting.CurrentUser.LoginName;
                currentInquiryDetails.CreatedTime = DateTime.Now;
            }

            currentInquiryDetails.CustomerInquiryDetailID = inquiryDetailID;
            currentInquiryDetails.CustomerInquiryDetailRemark = inquiryRemark;
            currentInquiryDetails.CustomerInquiryID = this.inquiryIDSelected;
            currentInquiryDetails.CustomerInquiryProductDefinitionID = productSelected.CustomerInquiryProductDefinitionID;
            currentInquiryDetails.CustomerInquiryQuantity = qty;
            currentInquiryDetails.TemperatureRange = productSelected.TemperatureRange;
            currentInquiryDetails.HumidityRange = productSelected.HumidityRange;
            currentInquiryDetails.StorageRoom = productSelected.StorageRoom;

            // Detect is process insert or update
            if (inquiryDetailID > 0 && rowHandle > -1)
            {
                // Process update 
                this.inquiryDetailsDA.Update(currentInquiryDetails);
            }
            else
            {
                // Process insert
                this.inquiryDetailsDA.Insert(currentInquiryDetails);
                this.grvInquiryDetails.SetFocusedRowCellValue("CustomerInquiryDetailID", currentInquiryDetails.CustomerInquiryDetailID);
                this.LoadQuotationDetais(Convert.ToInt32(currentInquiryDetails.CustomerInquiryID));
            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            this.CleanData();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Change quotations data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DnInquiry_PositionChanged(object sender, EventArgs e)
        {
            if (this.dnInquiry.Position < 0) return;
            var currentInquery = this.inquiryBDList[this.dnInquiry.Position];
            this.lkeCustomers.EditValue = currentInquery.CustomerID;
            this.txtCustomerName.Text = Convert.ToString(this.lkeCustomers.GetColumnValue("CustomerName"));
            this.lkeStore.EditValue = currentInquery.StoreID;

            // Load details
            this.LoadQuotationDetais(currentInquery.CustomerInquiryID);
            this.LoadEquiryDetails(currentInquery.CustomerInquiryID);
        }

        private void LoadQuotationDetais(int inquiryId)
        {
            DataProcess<ST_WMS_LoadInquiryDetailByInquiryID_Result> inquiryDetailDA = new DataProcess<ST_WMS_LoadInquiryDetailByInquiryID_Result>();
            var dataSource = inquiryDetailDA.Executing("ST_WMS_LoadInquiryDetailByInquiryID @InquiryID={0}", inquiryId);
            this.inquiryDetailDBList = new BindingList<ST_WMS_LoadInquiryDetailByInquiryID_Result>(dataSource.ToList());
            this.inquiryDetailDBList.Add(new ST_WMS_LoadInquiryDetailByInquiryID_Result());
            this.grdInquiryDetails.DataSource = this.inquiryDetailDBList;
        }

        private void LoadEquiryDetails(int quotationID)
        {

        }

        private void LoadServiceList()
        {
            DataProcess<CustomerInquiryProductDefinition> productDA = new DataProcess<CustomerInquiryProductDefinition>();
            this.rpi_lke_ProductDefinition.DataSource = productDA.Select();
            this.rpi_lke_ProductDefinition.DisplayMember = "ProductDescriptions";
            this.rpi_lke_ProductDefinition.ValueMember = "CustomerInquiryProductDefinitionID";
        }

        private void LoadStore()
        {
            this.lkeStore.Properties.DataSource = FileProcess.LoadTable("select * from Stores");
            this.lkeStore.Properties.DisplayMember = "StoreVietnam";
            this.lkeStore.Properties.ValueMember = "StoreID";
        }

        private void LoadInquiry()
        {
            if (this.inquiryIDSelected > 0)
            {
                var dataSource = inquiryDA.Select(q => q.CustomerInquiryID == this.inquiryIDSelected);
                this.inquiryBDList = new BindingList<CustomerInquiry>(dataSource.ToList());
            }
            else
            {
                this.CleanData();
                this.inquiryBDList = new BindingList<CustomerInquiry>();
                this.inquiryBDList.Add(new CustomerInquiry());
            }

            this.dnInquiry.DataSource = this.inquiryBDList;
            this.dnInquiry.Position = this.inquiryBDList.Count;
        }

        private void BindingData()
        {
            this.txtInquiryID.DataBindings.Add("Text", this.dnInquiry.DataSource, "CustomerInquiryNumber", true, DataSourceUpdateMode.OnPropertyChanged);
            this.txtInquiryNumber.DataBindings.Add("Text", this.dnInquiry.DataSource, "CustomerInquiryID", true, DataSourceUpdateMode.OnPropertyChanged);
            this.dInquiryDate.DataBindings.Add("DateTime", this.dnInquiry.DataSource, "CustomerInquiryDate", true, DataSourceUpdateMode.OnPropertyChanged);
            this.txtCreatedBy.DataBindings.Add("Text", this.dnInquiry.DataSource, "CreatedBy", true, DataSourceUpdateMode.OnPropertyChanged);
            this.dCreatedTime.DataBindings.Add("DateTime", this.dnInquiry.DataSource, "CreatedTime", true, DataSourceUpdateMode.OnPropertyChanged);
            this.mmRemark.DataBindings.Add("Text", this.dnInquiry.DataSource, "CustomerInquiryRemark", true, DataSourceUpdateMode.OnPropertyChanged);

            var currentInquiry = this.inquiryBDList[this.dnInquiry.Position];
            if (currentInquiry == null) return;
            this.lkeCustomers.EditValue = currentInquiry.CustomerID;
            this.lkeStore.EditValue = currentInquiry.StoreID;

            // Load details
            this.LoadQuotationDetais(currentInquiry.CustomerInquiryID);
            this.LoadEquiryDetails(currentInquiry.CustomerInquiryID);
        }

        private void CleanData()
        {
            this.txtInquiryID.Text = "";
            this.txtInquiryNumber.Text = string.Empty;
            this.dInquiryDate.DateTime = DateTime.Now;
            this.txtCreatedBy.Text = AppSetting.CurrentUser.LoginName;
            this.dCreatedTime.DateTime = DateTime.Now;
            this.mmRemark.Text = string.Empty;
            this.lkeCustomers.EditValue = null;
            this.lkeStore.EditValue = AppSetting.StoreID;
            this.inquiryIDSelected = 0;
            this.LoadEquiryDetails(0);
            this.grdInquiryDetails.DataSource = null;
            this.grdInquiryServices.DataSource = null;
            this.lkeCustomers.Focus();
            this.lkeCustomers.ShowPopup();
        }

        private void LoadCustomer()
        {
            this.lkeCustomers.Properties.DataSource = AppSetting.CustomerListAll;
            this.lkeCustomers.Properties.ValueMember = "CustomerID";
            this.lkeCustomers.Properties.DisplayMember = "CustomerNumber";
        }


        private void spStore_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void advQuotationDetails_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            switch (e.Column.FieldName)
            {
                case "UnitRate":
                case "QuotationDetailRemark":
                case "ServiceScopeOfWork":
                    int quotationDetailID = Convert.ToInt32(this.grvInquiryDetails.GetFocusedRowCellValue("QuotationDetailID"));
                    DataProcess<object> quotationDetailDA = new DataProcess<object>();
                    string quotationRemark = Convert.ToString(this.grvInquiryDetails.GetFocusedRowCellValue("QuotationDetailRemark"));
                    int unitRate = 0;
                    if (!Convert.IsDBNull(this.grvInquiryDetails.GetFocusedRowCellValue("UnitRate")))
                    {
                        unitRate = Convert.ToInt32(this.grvInquiryDetails.GetFocusedRowCellValue("UnitRate"));
                    }

                    string scopeOfWork = Convert.ToString(this.grvInquiryDetails.GetFocusedRowCellValue("ServiceScopeOfWork"));

                    // Update quotation details
                    string query = "Update CustomerQuotationDetails " +
                                   "set QuotationDetailRemark = '" + quotationRemark + "', UnitRate =" + unitRate + ", ServiceScopeOfWork = '" + scopeOfWork + "'" +
                                   " where QuotationDetailID =" + quotationDetailID;
                    quotationDetailDA.ExecuteNoQuery(query);
                    break;
                default:
                    break;
            }
        }

        private void Btn_CRM_CustomerInquiry_Click(object sender, EventArgs e)
        {
            this.CleanData();
        }

        private void btn_CRM_S_NEW_Click(object sender, EventArgs e)
        {
            this.CleanData();
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.F3)
            {
                frm_WM_Attachments.Instance.OrderNumber = this.txtInquiryNumber.EditValue.ToString();
                frm_WM_Attachments.Instance.CustomerID = Convert.ToInt32(this.lkeCustomers.EditValue.ToString());
                if (frm_WM_Attachments.Instance.Enabled)
                {
                    frm_WM_Attachments.Instance.ShowDialog();
                }
            }
            return base.ProcessDialogKey(keyData);
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        private void btnCheckValid_Click(object sender, EventArgs e)
        {

        }

        private void txtCustomerName_Click(object sender, EventArgs e)
        {
            if (this.lkeCustomers.EditValue == null) return;
            Customers currentCustomer = AppSetting.CustomerList.Where(c => c.CustomerID == Convert.ToInt32(this.lkeCustomers.EditValue)).FirstOrDefault();
            MasterSystemSetup.frm_MSS_Customers frmCustomer = MasterSystemSetup.frm_MSS_Customers.Instance;
            if (!frmCustomer.Enabled) return;
            frmCustomer.CurrentCustomers = currentCustomer;
            frmCustomer.WindowState = FormWindowState.Normal;
            frmCustomer.BringToFront();
            frmCustomer.Show();
        }

        private void dCreatedTime_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void ShowConfirmStripColor(bool isConfirmed)
        {
            if (isConfirmed)
            {
                this.LabelConfirmStrip.BackColor = System.Drawing.Color.Red;
            }
            else
            {
                this.LabelConfirmStrip.BackColor = System.Drawing.Color.Blue;
            }
        }
    }
}
