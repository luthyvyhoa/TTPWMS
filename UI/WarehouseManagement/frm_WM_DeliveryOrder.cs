using Common.Controls;
using DA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Helper;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_DeliveryOrder : frmBaseForm
    {
        private BindingList<DeliveryOrder> listDeliveryOrders = null;
        private BindingList<DeliveryOrderDetail> listOrderDetail = null;
        private DataProcess<DeliveryOrder> deliveryDA = new DataProcess<DeliveryOrder>();
        private DataProcess<DeliveryOrderDetail> deliveryDetailDA = new DataProcess<DeliveryOrderDetail>();
        private DeliveryOrder currentDelivery = null;
        private bool isAddNew = false;
        public frm_WM_DeliveryOrder()
        {
            InitializeComponent();

            // Init events
            this.InitEvents();

            // Init data
            this.LoadCustomer();
            this.LoadStatus();
            this.LoadData();
            this.LoadDataDetails();
        }

        private void LoadData()
        {
            var dataSource = this.deliveryDA.Select();
            this.listDeliveryOrders = new BindingList<DeliveryOrder>(dataSource.ToList());
            if (this.listDeliveryOrders.Count <= 0)
            {
                this.listDeliveryOrders.AddNew();
            }
            this.dataNavigatorDeliveryOrders.DataSource = this.listDeliveryOrders;
            this.dataNavigatorDeliveryOrders.Position = this.listDeliveryOrders.Count - 1;
        }

        private void LoadDataDetails()
        {
            if (this.currentDelivery != null && this.currentDelivery.DeliveryOrderID > 0)
            {
                var dataSource = this.deliveryDetailDA.Select(d => d.DeliveryOrderID == this.currentDelivery.DeliveryOrderID);
                this.listOrderDetail = new BindingList<DeliveryOrderDetail>(dataSource.ToList());
            }
            else
            {
                var dataSource = this.deliveryDetailDA.Select();
                this.listOrderDetail = new BindingList<DeliveryOrderDetail>(dataSource.ToList());
            }

            if (this.listOrderDetail.Count <= 0)
            {
                this.listOrderDetail.AddNew();
            }
            this.grdDeliveryOrderDetails.DataSource = this.listOrderDetail;
        }

        private void InitEvents()
        {
            this.dataNavigatorDeliveryOrders.PositionChanged += DataNavigatorDeliveryOrders_PositionChanged;
            this.btnNew.Click += BtnNew_Click;
            this.lookUpEditCustomerClientID.EditValueChanged += LookUpEditCustomerClientID_EditValueChanged;
            this.lookUpEditCustomerID.CloseUp += LookUpEditCustomerID_CloseUp;
            this.Load += Frm_WM_DeliveryOrder_Load;
        }

        private void LookUpEditCustomerClientID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                int customerID = Convert.ToInt32(lookUpEditCustomerID.EditValue);

                string customerName = lookUpEditCustomerID.Properties.GetDataSourceValue("CustomerName", lookUpEditCustomerID.ItemIndex).ToString();
                textEditCustomerName.Text = customerName;
                InitCustomerClients();
                this.Text = textEditOrderID.Text.Trim() + " " + lookUpEditCustomerID.Text.Trim();
            }
            catch (Exception ex)
            {
                //log.Error("==> Error is unexpected");
                //log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                textEditCustomerName.Text = "";
            }
        }

        private void Frm_WM_DeliveryOrder_Load(object sender, EventArgs e)
        {
            this.BindingData();
        }

        private void LookUpEditCustomerID_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.Value == null) return;
            if (this.isAddNew)
            {
                // Insert
                if (this.currentDelivery == null)
                {
                    this.currentDelivery = new DeliveryOrder();
                }
                this.currentDelivery.CreatedBy = AppSetting.CurrentUser.LoginName;
                this.currentDelivery.CreatedTime = DateTime.Now;
                this.currentDelivery.CustomerID = Convert.ToInt32(e.Value);
                this.currentDelivery.DeliveryOrderDate = DateTime.Now;
                this.deliveryDA.Insert(this.currentDelivery);
            }
            else
            {
                //Update
                this.currentDelivery.CustomerID = Convert.ToInt32(e.Value);
                this.deliveryDA.Update(this.currentDelivery);
            }
        }

        private void BindingData()
        {
            textEditOrderID.DataBindings.Add("EditValue", dataNavigatorDeliveryOrders.DataSource, "DeliveryOrderNumber", true, DataSourceUpdateMode.OnPropertyChanged, "");
            textEditOrderID.DataBindings.Add("Tag", dataNavigatorDeliveryOrders.DataSource, "DeliveryOrderID", true, DataSourceUpdateMode.OnPropertyChanged, 0);
            memoEditTruckAndDetail.DataBindings.Add("Tag", dataNavigatorDeliveryOrders.DataSource, "DeliveryOrderRemark", true, DataSourceUpdateMode.OnPropertyChanged, "");
            dateEditDispatchingOrderDate.DataBindings.Add("Tag", dataNavigatorDeliveryOrders.DataSource, "DeliveryOrderDate", true, DataSourceUpdateMode.OnPropertyChanged, DateTime.Now.Date);
            textEditDispatchingCreatedTime.DataBindings.Add("Tag", dataNavigatorDeliveryOrders.DataSource, "CreatedTime", true, DataSourceUpdateMode.OnPropertyChanged, DateTime.Now, "dd/MM/yyyy HH:mm:ss");
            textEditDispatchingCreatedBy.DataBindings.Add("Tag", dataNavigatorDeliveryOrders.DataSource, "CreatedBy", true, DataSourceUpdateMode.OnPropertyChanged, "");
            timeEditStartTime.DataBindings.Add("Tag", dataNavigatorDeliveryOrders.DataSource, "Deadline", true, DataSourceUpdateMode.OnPropertyChanged, null);
            textEditVehicleNumber.DataBindings.Add("Tag", dataNavigatorDeliveryOrders.DataSource, "VehicleNumber", true, DataSourceUpdateMode.Never, "");
            this.Text = textEditOrderID.Text.Trim() + " " + lookUpEditCustomerID.Text.Trim();
            this.dataNavigatorDeliveryOrders.Position = this.listDeliveryOrders.Count - 1;
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            this.isAddNew = true;
            listOrderDetail.Clear();
            this.LoadDataDetails();
            dataNavigatorDeliveryOrders.Position = this.listDeliveryOrders.Count;
            textEditOrderID.Text = "DL-New *";
            textEditOrderID.Tag = 0;
            memoEditTruckAndDetail.Text = "";
            textEditDispatchingCreatedTime.Text = DateTime.Now.ToString("dd/MM/yyyy");
            memoEditTruckAndDetail.Tag = string.Empty;
            dateEditDispatchingOrderDate.Tag = dateEditDispatchingOrderDate.EditValue = DateTime.Now.Date;
            timeEditStartTime.Tag = timeEditStartTime.EditValue = null; // DateTime.Now;
            this.textEditVehicleNumber.Tag = this.textEditVehicleNumber.Text = string.Empty;
            lookUpEditCustomerID.Tag = lookUpEditCustomerID.EditValue = null;
            this.lookUpEditCustomerClientID.EditValue = null;
            this.lke_Status.EditValue = null;
            lookUpEditCustomerID.ReadOnly = false;
            lookUpEditCustomerID.Focus();
            lookUpEditCustomerID.ShowPopup();
        }

        private void LoadStatus()
        {
            DataProcess<DeliveryStatusDefinition> statusDA = new DataProcess<DeliveryStatusDefinition>();
            this.lke_Status.Properties.DataSource = statusDA.Select();
            this.lke_Status.Properties.DisplayMember = "DeliveryStatusDescription";
            this.lke_Status.Properties.ValueMember = "DeliveryStatusDefinitionID";
        }

        private void InitCustomerClients()
        {
            try
            {
                int customerID = Convert.ToInt32(lookUpEditCustomerID.EditValue);
                DataProcess<STCustomerClients_Result> cc = new DataProcess<STCustomerClients_Result>();
                List<STCustomerClients_Result> listCustomers = cc.Executing("STCustomerClients @CustomerID = {0}", customerID).ToList();
                this.lookUpEditCustomerClientID.Properties.ValueMember = "CustomerClientID";
                this.lookUpEditCustomerClientID.Properties.DisplayMember = "CustomerClientName";
                lookUpEditCustomerClientID.Properties.DataSource = listCustomers;
                //lookUpEditCustomerClientID.EditValue = listCustomers[0].CustomerClientID;
            }
            catch (Exception ex)
            {
                //log.Error("==> Error is unexpected");
                //log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
            }
        }

        private void DataNavigatorDeliveryOrders_PositionChanged(object sender, EventArgs e)
        {
            if (this.dataNavigatorDeliveryOrders.Position < 0) return;
            this.currentDelivery = this.listDeliveryOrders[this.dataNavigatorDeliveryOrders.Position];
            if (this.currentDelivery == null) return;
            this.lookUpEditCustomerID.EditValue = this.currentDelivery.CustomerID;
        }

        private void LoadCustomer()
        {
            var listCustomer = AppSetting.CustomerListAll.Where(a => a.CustomerDiscontinued == false).ToList();

            // Update data on control by other thread
            lookUpEditCustomerID.Properties.DataSource = listCustomer;
            lookUpEditCustomerID.Properties.DisplayMember = "CustomerNumber";
            lookUpEditCustomerID.Properties.ValueMember = "CustomerID";
        }
    }
}
