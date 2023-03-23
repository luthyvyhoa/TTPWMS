using DA;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;
using System.Linq;
using System.Data;
using System.ComponentModel;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_Dialog_Routes : Form
    {
        private int routeID = 0;
        private CustomerDeliveryRoute currentRoute = null;
        private DataProcess<CustomerDeliveryRoute> routeDA = new DataProcess<CustomerDeliveryRoute>();
        private int customerID = 0;
        private BindingList<STCustomerAddressRoutes_Result> dataSource = null;
        public frm_WM_Dialog_Routes(int customerIDInput)
        {
            InitializeComponent();

            // Set params input
            this.customerID = customerIDInput;

            // Init events
            this.InitEvents();

            // Init data
            this.InitData();

            // Load routes data by current customer selected
            this.LoadAllRouteByCustomer();
        }

        private void LoadAllRouteByCustomer()
        {
            DataProcess<STCustomerAddressRoutes_Result> dataProcess = new DataProcess<STCustomerAddressRoutes_Result>();
            var listSource = dataProcess.Executing("STCustomerAddressRoutes @CustomerID={0}", this.customerID).ToList();
            this.dataSource = new BindingList<STCustomerAddressRoutes_Result>(listSource);
            this.AddNewRow();
        }

        private void InitData()
        {
            //Load all provinces
            this.LoadAllProvinces();

            // Load all districts
            this.LoadAllDictricts();
        }

        private void InitEvents()
        {
            this.grvRoutesTableView.RowCellClick += GrvRoutesTableView_RowCellClick;
            this.btnClose.Click += BtnClose_Click;
            this.btnDelete.Click += BtnDelete_Click;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            this.currentRoute = this.routeDA.Select(r => r.CustomerDeliveryRouteID == this.routeID).Single();
            int result = this.routeDA.ExecuteNoQuery("Delete CustomerDeliveryRoutes where CustomerDeliveryRouteID=" + this.currentRoute.CustomerDeliveryRouteID);
            this.LoadAllRouteByCustomer();
        }


        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GrvRoutesTableView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.RowHandle < 0) return;
        }

        private void Rpi_lke_ProvincesLast_EditValueChanged(object sender, System.EventArgs e)
        {
            var lke = (LookUpEdit)sender;
            if (lke.EditValue == null) return;
            int provinceID = Convert.ToInt32(lke.EditValue);
            var districtsDataSource = FileProcess.LoadTable(" Select * from CustomerClientAddressDistricts where CustomerClientAddressProvinceID=" + provinceID);
        }

        private void Rpi_lke_ProvinceFirst_EditValueChanged(object sender, System.EventArgs e)
        {
            var lke = (LookUpEdit)sender;
            if (lke.EditValue == null) return;
            int provinceID = Convert.ToInt32(lke.EditValue);
            var districtsDataSource = FileProcess.LoadTable(" Select * from CustomerClientAddressDistricts where CustomerClientAddressProvinceID=" + provinceID);
        }

        private void LoadAllProvinces()
        {
            var provincesDataSource = FileProcess.LoadTable(" Select * from CustomerClientAddressProvinces");
            this.rpi_lke_ProvinceFirst.DataSource = provincesDataSource;
            this.rpi_lke_ProvinceLast.DataSource = provincesDataSource;

            // Set field dispaly
            this.rpi_lke_ProvinceFirst.DisplayMember = "ProvinceName";
            this.rpi_lke_ProvinceFirst.ValueMember = "CustomerClientAddressProvinceID";
            this.rpi_lke_ProvinceLast.DisplayMember = "ProvinceName";
            this.rpi_lke_ProvinceLast.ValueMember = "CustomerClientAddressProvinceID";
        }

        private void LoadAllDictricts()
        {
            var districtsDataSource = FileProcess.LoadTable(" Select * from CustomerClientAddressDistricts");
            this.rpi_lke_FirstDistrict.DataSource = districtsDataSource;
            this.rpi_lke_LastDistrict.DataSource = districtsDataSource;
            this.rpi_lke_District1.DataSource = districtsDataSource;
            this.rpi_lke_District2.DataSource = districtsDataSource;
            this.rpi_lke_District3.DataSource = districtsDataSource;
            this.rpi_lke_District4.DataSource = districtsDataSource;

            // Set field dispaly
            this.rpi_lke_FirstDistrict.DisplayMember = "DistrictName";
            this.rpi_lke_FirstDistrict.ValueMember = "CustomerClientAddressDistrictID";
            this.rpi_lke_LastDistrict.DisplayMember = "DistrictName";
            this.rpi_lke_LastDistrict.ValueMember = "CustomerClientAddressDistrictID";
            this.rpi_lke_District1.DisplayMember = "DistrictName";
            this.rpi_lke_District1.ValueMember = "CustomerClientAddressDistrictID";
            this.rpi_lke_District2.DisplayMember = "DistrictName";
            this.rpi_lke_District2.ValueMember = "CustomerClientAddressDistrictID";
            this.rpi_lke_District3.DisplayMember = "DistrictName";
            this.rpi_lke_District3.ValueMember = "CustomerClientAddressDistrictID";
            this.rpi_lke_District4.DisplayMember = "DistrictName";
            this.rpi_lke_District4.ValueMember = "CustomerClientAddressDistrictID";
        }

        private void grvRoutesTableView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName.Equals("CustomerDeliveryRouteID")) return;
            int deliveryRouteID = Convert.ToInt32(this.grvRoutesTableView.GetRowCellValue(e.RowHandle, "CustomerDeliveryRouteID"));
            string routeCode = Convert.ToString(this.grvRoutesTableView.GetFocusedRowCellValue("RouteCode"));
            string routeDes = Convert.ToString(this.grvRoutesTableView.GetFocusedRowCellValue("RouteDescriptions"));

            if (this.grvRoutesTableView.FocusedRowHandle == this.grvRoutesTableView.RowCount - 1)
            {
                if (string.IsNullOrEmpty(routeCode) || string.IsNullOrEmpty(routeDes)) return;

                // Insert
                this.currentRoute = new CustomerDeliveryRoute();
                this.currentRoute.RouteCode = routeCode;
                this.currentRoute.RouteDescriptions = routeDes;
                this.currentRoute.CustomerID = this.customerID;
                this.routeDA.Insert(this.currentRoute);
                this.grvRoutesTableView.SetRowCellValue(e.RowHandle, "CustomerDeliveryRouteID", this.currentRoute.CustomerDeliveryRouteID);
                this.AddNewRow();
            }
            else
            {
                // Update
                DataProcess<CustomerDeliveryRoute> routeDA = new DataProcess<CustomerDeliveryRoute>();
                string query = string.Format("Update CustomerDeliveryRoutes set {0}=N'{1}' Where CustomerDeliveryRouteID={2}", e.Column.FieldName, e.Value, deliveryRouteID);
                routeDA.ExecuteNoQuery(query);
            }
        }

        private void AddNewRow()
        {
            if (this.dataSource == null) return;
            var newRow = new STCustomerAddressRoutes_Result();
            newRow.CustomerID = this.customerID;
            this.dataSource.Add(newRow);
            this.grdRoutes.DataSource = this.dataSource;
            this.grvRoutesTableView.RefreshData();
        }
    }
}
