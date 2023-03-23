using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DA;
using UI.Helper;

namespace UI.Transport
{
    public partial class frm_T_TransportTrip : Form
    {
        private BindingList<TransportTrip> transportBdList = null;
        private BindingList<TransportTripOutsourceDetail> transPortDetailDbList = null;
        private DataProcess<TransportTrip> transportDA = new DataProcess<TransportTrip>();
        private DataProcess<TransportTripOutsourceDetail> transportDetailDA = new DataProcess<TransportTripOutsourceDetail>();
        private TransportTrip currentTransport = null;
        private DataTable customerList = null;
        public frm_T_TransportTrip()
        {
            InitializeComponent();

            this.InitData();
        }

        public frm_T_TransportTrip(int transportTripID)
        {
            InitializeComponent();
            //Show the record

            this.InitData();
        }

        /// <summary>
        /// Init data when form generation designer
        /// </summary>
        private void InitData()
        {
            // Load supplier data
            this.LoadSupplierData();

            // Load service for transport trip details
            this.LoadServiceDetails();

            // Load transport data
            this.LoadTransportData();
        }

        /// <summary>
        /// Load supplier data
        /// </summary>
        void LoadSupplierData()
        {
            /// tạm thời lấy customer thay cho supplier
            this.customerList = FileProcess.LoadTable("Select * from ViewSuppliers");
            lkeSuppliers.Properties.DataSource = this.customerList;
            this.lkeSuppliers.Properties.ValueMember = "SupplierID";
            this.lkeSuppliers.Properties.DisplayMember = "SupplierName";
        }

        void LoadServiceDetails()
        {
            DataProcess<ServicesDefinition> serviceDA = new DataProcess<ServicesDefinition>();
            var dataSource = serviceDA.Select();
            this.rpi_lke_Services.DataSource = dataSource;
            this.rpi_lke_Services.DisplayMember = "ServiceNumber";
            this.rpi_lke_Services.ValueMember = "ServiceID";
            this.rpi_lke_ServiceDisplay.DataSource = dataSource;
            this.rpi_lke_ServiceDisplay.DisplayMember = "ServiceName";
            this.rpi_lke_ServiceDisplay.ValueMember = "ServiceID";
        }

        void LoadTransportData()
        {
            var dataSource = this.transportDA.Select();
            this.transportBdList = new BindingList<TransportTrip>(dataSource.ToList());
            this.dataNavigator1.DataSource = this.transportBdList;
            if (this.transportBdList.Count > 0)
                this.dataNavigator1.Position = this.transportBdList.Count - 1;
        }

        void LoadTransportDetails(int transportId)
        {
            var dataSource = transportDetailDA.Select(t => t.TransportTripID == transportId).ToList();
            this.transPortDetailDbList = new BindingList<TransportTripOutsourceDetail>(dataSource);
            this.AddNewTransportDetails(transportId);
            this.grdOutsourcedServices.DataSource = this.transPortDetailDbList;
        }

        void AddNewTransportDetails(int transportID)
        {
            var transportDetailInfo = new TransportTripOutsourceDetail();
            transportDetailInfo.CreatedBy = AppSetting.CurrentUser.LoginName;
            transportDetailInfo.CreatedTime = DateTime.Now;
            transportDetailInfo.OtherServiceDetailID = 0;
            transportDetailInfo.ServiceID = 0;
            transportDetailInfo.TransportTripID = transportID;
            this.transPortDetailDbList.Add(transportDetailInfo);
            this.grdOutsourcedServices.DataSource = this.transPortDetailDbList;
        }

        private void dataNavigator1_PositionChanged(object sender, EventArgs e)
        {
            if (this.dataNavigator1.Position < 0) return;
            this.currentTransport = this.transportBdList[this.dataNavigator1.Position];
            this.BindingData(this.currentTransport);
        }

        private void BindingData(TransportTrip transportInfo)
        {
            if (transportInfo == null) return;
            this.lkeSuppliers.EditValue = transportInfo.SupplierID;
            this.textPCCreatedBy.EditValue = transportInfo.CreatedBy;
            this.textPCCreatedTime.EditValue = transportInfo.CreatedTime;
            this.timeEditStartTime.EditValue = transportInfo.StartTime;
            this.timeEditEndTime.EditValue = transportInfo.EndTime;
            this.deTransportTripDate.EditValue = transportInfo.TransportTripDate;
            this.meRemark.EditValue = transportInfo.TransportTripRemark;
            this.txtProductCheckingRecordNumber.EditValue = transportInfo.OrderNumber;
            var currentCustomer = this.customerList.Select("SupplierID=" + transportInfo.SupplierID).FirstOrDefault();
            if (currentCustomer != null) this.txtCustomerName.Text = Convert.ToString(currentCustomer["SupplierName"]);

            this.LoadTransportDetails(this.currentTransport.TransportTripID);
        }

        private void BtnWmNewPC_Click(object sender, EventArgs e)
        {
            var newTransport = new TransportTrip();
            newTransport.CreatedBy = AppSetting.CurrentUser.LoginName;
            newTransport.CreatedTime = DateTime.Now;
            newTransport.StartTime = DateTime.Now;
            newTransport.SupplierID = 0;
            newTransport.TransportTripDate = DateTime.Now;
            newTransport.OrderNumber = "NEW";
            newTransport.TransportTripNumber = "NEW";
            this.currentTransport = newTransport;
            this.BindingData(newTransport);
            this.transportBdList.Add(newTransport);
            this.dataNavigator1.Position = this.transportBdList.Count - 1;
            this.lkeSuppliers.Focus();
            this.lkeSuppliers.ShowPopup();
        }

        private void lkeSuppliers_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.Value == null || this.currentTransport == null) return;
            this.currentTransport.SupplierID = Convert.ToInt32(e.Value);
            var currentCustomer = this.customerList.Select("SupplierID=" + this.currentTransport.SupplierID).FirstOrDefault();
            if (currentCustomer != null) this.txtCustomerName.Text = Convert.ToString(currentCustomer["SupplierName"]);
            if (this.currentTransport.TransportTripID <= 0)
            {
                // Insert new transportTrips
                this.transportDA.Insert(this.currentTransport);
                this.txtProductCheckingRecordNumber.Text = this.currentTransport.TransportTripNumber;
            }
            else
            {
                // Update supplierID for current transportTrips
                this.transportDA.Update(this.currentTransport);
            }
        }

        private void meRemark_EditValueChanged(object sender, EventArgs e)
        {
            if (this.currentTransport == null) return;
            this.currentTransport.TransportTripRemark = this.meRemark.Text;
            this.transportDA.Update(this.currentTransport);
        }

        private void timeEditStartTime_EditValueChanged(object sender, EventArgs e)
        {
            if (this.currentTransport == null) return;
            if (this.timeEditStartTime.EditValue == null)
                this.currentTransport.StartTime = null;
            else
                this.currentTransport.StartTime = this.timeEditStartTime.DateTime;
            this.transportDA.Update(this.currentTransport);
        }

        private void timeEditEndTime_EditValueChanged(object sender, EventArgs e)
        {
            if (this.currentTransport == null) return;
            if (this.timeEditEndTime.EditValue == null)
                this.currentTransport.EndTime = null;
            else
                this.currentTransport.EndTime = this.timeEditEndTime.DateTime;
            this.transportDA.Update(this.currentTransport);
        }

        private void deTransportTripDate_EditValueChanged(object sender, EventArgs e)
        {
            if (this.currentTransport == null || this.deTransportTripDate.EditValue == null) return;
            this.currentTransport.TransportTripDate = this.deTransportTripDate.DateTime;
            this.transportDA.Update(this.currentTransport);
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            int count = this.transPortDetailDbList.Count();
            if (count > 1)
            {
                MessageBox.Show("Please delete transport Trip details before delete this transport Trip", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var dlConfirm = MessageBox.Show("Do you want to delete this transport trip ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlConfirm.Equals(DialogResult.No)) return;
            this.transportDA.Delete(this.currentTransport);
            this.LoadTransportData();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Confirm_ProductChecking_Click(object sender, EventArgs e)
        {
        }

        private void grvTripDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Delete))
            {
                if (this.grvTripDetails.SelectedRowsCount <= 0)
                {
                    MessageBox.Show("Please select transport trip details to delete", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                var dlConfirm = MessageBox.Show("Do you want to delete this transport trip details?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlConfirm.Equals(DialogResult.No)) return;
                foreach (var item in this.grvTripDetails.GetSelectedRows())
                {
                    int transportDetailID = Convert.ToInt32(this.grvTripDetails.GetRowCellValue(item, "TransportTripOutsourcedServiceID"));
                    var transportDetailInfo = this.transPortDetailDbList.Where(t => t.TransportTripOutsourcedServiceID == transportDetailID).FirstOrDefault();
                    this.transportDetailDA.Delete(transportDetailInfo);
                }
                this.LoadTransportDetails(this.currentTransport.TransportTripID);
            }
        }

        private void rpi_lke_Services_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.Value == null || this.currentTransport.TransportTripID <= 0) return;
            var currentTransportDetail = (TransportTripOutsourceDetail)this.grvTripDetails.GetRow(this.grvTripDetails.FocusedRowHandle);
            currentTransportDetail.ServiceID = Convert.ToInt32(e.Value);
            if (currentTransportDetail.TransportTripOutsourcedServiceID <= 0)
            {
                transportDetailDA.Insert(currentTransportDetail);
                this.AddNewTransportDetails(this.currentTransport.TransportTripID);
            }
            else
            {
                transportDetailDA.Update(currentTransportDetail);
            }

        }

        private void grvTripDetails_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Value == null || this.currentTransport.TransportTripID <= 0) return;
            var currentTransportDetail = (TransportTripOutsourceDetail)this.grvTripDetails.GetRow(this.grvTripDetails.FocusedRowHandle);
            if (currentTransportDetail.TransportTripOutsourcedServiceID > 0)
            {
                transportDetailDA.Update(currentTransportDetail);
            }
        }
    }
}
