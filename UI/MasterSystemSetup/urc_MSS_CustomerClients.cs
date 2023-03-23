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

namespace UI.MasterSystemSetup
{
    public partial class urc_MSS_CustomerClients : UserControl
    {
        private Customers _currentCustomer;
        private DataProcess<CustomerClients> _clientData;
        private BindingList<CustomerClients> clients = null;
        //private static urc_MSS_CustomerClients _instance;

        public Customers CurrentCustomer
        {
            set
            {
                this._currentCustomer = value;
                FilterData();
            }
        }

        //public static urc_MSS_CustomerClients Instance
        //{
        //    get
        //    {
        //        if (_instance == null)
        //        {
        //            _instance = new urc_MSS_CustomerClients();
        //        }
        //        return _instance;
        //    }
        //}

        public urc_MSS_CustomerClients()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this._currentCustomer = new Customers();
            this._clientData = new DataProcess<CustomerClients>();
        }

        private void urc_MSS_CustomerClients_Load(object sender, EventArgs e)
        {
            this.LoadDistrict();
            this.LoadRoute();
            LoadClients();
            SetEditable(true);
            this.LoadDispatchingMethod();
            FilterData();
        }

        public void SetEditable(bool isEditable)
        {
            this.grcCustomerClientAddress.OptionsColumn.AllowEdit = isEditable;
            this.grcCustomerClientCode.OptionsColumn.AllowEdit = isEditable;
            this.grcCustomerClientContacts.OptionsColumn.AllowEdit = isEditable;
            this.grcCustomerClientEmail.OptionsColumn.AllowEdit = isEditable;
            this.grcCustomerClientName.OptionsColumn.AllowEdit = isEditable;
            this.grcCustomerClientPhone.OptionsColumn.AllowEdit = isEditable;
            this.grvClients.OptionsBehavior.Editable = isEditable;
            this.grvClients.OptionsBehavior.ReadOnly = !isEditable;
        }

        #region Load Data
        private void LoadClients()
        {
            var dataSource = this._clientData.Select(c => c.CustomerID == this._currentCustomer.CustomerID);
            this.clients = new BindingList<CustomerClients>(dataSource.ToList());
            this.AddNewRow();
            this.grdClients.DataSource = clients;
        }

        private void AddNewRow()
        {
            var newCustomerClient = new CustomerClients();
            newCustomerClient.CustomerID = this._currentCustomer.CustomerID;
            newCustomerClient.CustomerClientID = 0;
            this.clients.Add(newCustomerClient);

        }
        #endregion

        #region Events

        private void LoadDistrict()
        {
            this.rpi_lke_Districts.DataSource = FileProcess.LoadTable("Select * from CustomerClientAddressDistricts ORDER BY DistrictName");
            this.rpi_lke_Districts.DisplayMember = "DistrictName";
            this.rpi_lke_Districts.ValueMember = "DistrictName";
        }

        private void LoadRoute()
        {
            this.rpi_lke_DefaultRoute.DataSource = FileProcess.LoadTable("ST_WMS_LoadCustomerDeliveryRoutes " + this._currentCustomer.CustomerID);
            this.rpi_lke_DefaultRoute.DisplayMember = "RouteDescriptions";
            this.rpi_lke_DefaultRoute.ValueMember = "CustomerDeliveryRouteID";
        }
        private void LoadDispatchingMethod()
        {
            this.rpi_lke_DispartchingMethod.DataSource = FileProcess.LoadTable("ST_WMS_LoadCustomerDispatchMethod");
            this.rpi_lke_DispartchingMethod.DisplayMember = "Method";
            this.rpi_lke_DispartchingMethod.ValueMember = "CustomerDispatchMethodID";
        }
        #endregion
        private void FilterData()
        {
            this.LoadClients();
            this.grcCustomerClientCode.FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(this.grcCustomerID, (object)this._currentCustomer.CustomerID);
        }

        private void grvClients_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
        }

        private void grvClients_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int customerClientId = Convert.ToInt32(this.grvClients.GetFocusedRowCellValue("CustomerClientID"));
            DataProcess<CustomerClients> customerClientDA = new DataProcess<CustomerClients>();
            if (customerClientId > 0)
            {
                string query = string.Format(" Update CustomerClients Set {0}=N'{1}' Where CustomerClientID={2}", e.Column.FieldName, e.Value, customerClientId);
                customerClientDA.ExecuteNoQuery(query);
            }
            else
            {
                string customerClientCode = Convert.ToString(this.grvClients.GetFocusedRowCellValue("CustomerClientCode"));
                string customerClientName = Convert.ToString(this.grvClients.GetFocusedRowCellValue("CustomerClientName"));
                if (string.IsNullOrEmpty(customerClientCode) || string.IsNullOrEmpty(customerClientName)) return;
                var newCustomerClient = new CustomerClients();
                newCustomerClient.CustomerClientCode = customerClientCode;
                newCustomerClient.CustomerClientName = customerClientName;
                newCustomerClient.CustomerClientDescriptions = customerClientName;
                newCustomerClient.CustomerClientTaxName = customerClientName;
                newCustomerClient.CreatedBy = AppSetting.CurrentUser.LoginName;
                newCustomerClient.CustomerClientMain = customerClientCode;
                newCustomerClient.CustomerClientTaxCode = "";
                newCustomerClient.CustomerClientDeliveryAddress = "";
                newCustomerClient.CustomerID = this._currentCustomer.CustomerID;
                //newCustomerClient.CustomerClientMainID = this._currentCustomer.CustomerMainID;
                newCustomerClient.CreatedTime = DateTime.Now;
                customerClientDA.Insert(newCustomerClient);
                this.grvClients.SetFocusedRowCellValue("CustomerClientID", newCustomerClient.CustomerClientID);
                this.AddNewRow();
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            frmImportExcelFile frmImport = new frmImportExcelFile();
            frmImport.ShowDialog();

            // sau khi form da dong form nhung khong import excel thi khong lam gi ca
            if (frmImport.ExcelImportSource == null) return;

            // sau khi import
        }

        private void grvClients_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.KeyCode.Equals(Keys.Delete)) return;
            if (this.grvClients.SelectedRowsCount <= 0) return;          
            
            DataProcess<object> dataProcess = new DataProcess<object>();
            int customerClientID = 0;
            var currentDetail = (CustomerClients)this.grvClients.GetFocusedRow();
            if (currentDetail == null) return;
            customerClientID = currentDetail.CustomerClientID;
            var confirmMsg = MessageBox.Show("Do you want to delete this Customer Clients?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmMsg.Equals(DialogResult.No)) return;
            dataProcess.ExecuteNoQuery("Delete CustomerClients where CustomerClientID=" + customerClientID);
            //foreach (var index in this.grvClients.GetSelectedRows())
            //{
            //    customerClientID = Convert.ToInt32(this.grvClients.GetRowCellValue(index, "CustomerClientID"));
            //    dataProcess.ExecuteNoQuery("Delete CustomerClients where CustomerClientID=" + customerClientID);
            //}
            this.LoadClients();
        }
    }
}
