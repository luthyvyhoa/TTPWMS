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
    public partial class frm_WM_TripViewSummary : DevExpress.XtraEditors.XtraForm
    {
        private frm_WM_TripsManagement frmTripDetail = new frm_WM_TripsManagement(0);
        private string query = string.Empty;
        public frm_WM_TripViewSummary()
        {
            InitializeComponent();
            this.txtFromDate.EditValue = DateTime.Now.AddDays(-1).ToShortDateString();
            this.txtToDate.EditValue = DateTime.Now.AddDays(1).ToShortDateString();
            this.lke_Customer.Properties.DataSource = FileProcess.LoadTable("STcomboCustomerID " + AppSetting.StoreID);
            this.lke_Customer.Properties.DisplayMember = "CustomerNumber";
            this.lke_Customer.Properties.ValueMember = "CustomerID";
            this.LoadTripStatus();
            this.LoadDocumentStatus();
        }

        private void grcTripDetails_Click(object sender, EventArgs e)
        {

        }
        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            if (this.lke_Customer.EditValue == null) return;
            string dateFrom = Convert.ToDateTime(txtFromDate.EditValue).Date.ToString("yyyy-MM-dd");
            string dateTo = Convert.ToDateTime(txtToDate.EditValue).Date.ToString("yyyy-MM-dd");
            string CustomerID = this.lke_Customer.EditValue.ToString();
            this.grcTripDetails.DataSource = FileProcess.LoadTable("STTripSummaryByCutomers " + CustomerID + ",'" + dateFrom + "','" + dateTo + "'");
            this.query = "STTripSummaryByCutomers " + CustomerID + ",'" + dateFrom + "','" + dateTo + "'";
        }

        private void lke_Customer_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            this.lke_Customer.EditValue = e.Value;
            if (this.lke_Customer.EditValue == null)
            {
                this.txtCustomerName.Text = string.Empty;
                return;
            }

            this.txtCustomerName.Text = Convert.ToString(this.lke_Customer.GetColumnValue("CustomerName"));


        }
        private void repositoryItemHyperLinkEditDispatchingOrderID_Click(object sender, EventArgs e)
        {
            int orderID = Convert.ToInt32(this.grvTripDetails.GetFocusedRowCellValue("DispatchingOrderID"));
            // Display disptching order
            frm_WM_DispatchingOrders dispatchingOrder = frm_WM_DispatchingOrders.GetInstance(orderID);
            if (dispatchingOrder.Visible)
            {
                dispatchingOrder.ReloadData();
            }
            dispatchingOrder.Show();
            dispatchingOrder.WindowState = FormWindowState.Maximized;
            dispatchingOrder.BringToFront();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {

            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Excel 07-2018 (*.xlsx)|*.xlsx";

            DialogResult dr = sfd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                this.grvTripDetails.ExportToXlsx(sfd.FileName);
                try
                {
                    System.Diagnostics.Process.Start("Excel", sfd.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            sfd.Dispose();
        }

        private void repositoryItemHyperLinkTripNumber_Click(object sender, EventArgs e)
        {
            int TripID = Convert.ToInt32(this.grvTripDetails.GetFocusedRowCellValue("TripID"));
            this.frmTripDetail.ReloadData(TripID);
            this.frmTripDetail.Show();
            this.frmTripDetail.TopLevel = true;
            this.frmTripDetail.WindowState = FormWindowState.Normal;
            this.frmTripDetail.BringToFront();
            this.frmTripDetail.Focus();
        }

        private void repositoryItemHyperLinkPalletID_Click(object sender, EventArgs e)
        {
            int customerID = Convert.ToInt32(this.grvTripDetails.GetFocusedRowCellValue("CustomerID"));
            int productID = Convert.ToInt32(this.grvTripDetails.GetFocusedRowCellValue("ProductID"));
            frm_WM_PalletInfo frm = new frm_WM_PalletInfo(customerID, productID);
            frm.Show();
        }

        private void repositoryItemHyperLinkRO_Click(object sender, EventArgs e)
        {
            int v_ReceivingOrderID = 0;

            try
            {
                v_ReceivingOrderID = Convert.ToInt32(grvTripDetails.GetFocusedRowCellValue("ReceivingOrderID"));
            }
            catch { }

            WarehouseManagement.frm_WM_ReceivingOrders frm = frm_WM_ReceivingOrders.Instance;
            frm.ReceivingOrderIDFind = v_ReceivingOrderID;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowInTaskbar = false;
            frm.Show();
        }

        private void grvTripDetails_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            bool isUpdate = false;
            switch (e.Column.FieldName)
            {
                case "CashCollectionAmount":
                    isUpdate = true;
                    break;
                case "RejectedOrderNumber":
                    isUpdate = true;
                    break;
                case "ExpectedDeliveryTime":
                    isUpdate = true;
                    break;
                case "RejectedRemark":
                    isUpdate = true;
                    break;
                case "IsRejected":
                    isUpdate = true;
                    break;
                case "CustomerOrderNumber":
                    isUpdate = true;
                    break;
            }

            if (!isUpdate) return;
            int tripDetailID = Convert.ToInt32(this.grvTripDetails.GetFocusedRowCellValue("TripDetailID"));
            DataProcess<object> tripDetailDA = new DataProcess<object>();
            tripDetailDA.ExecuteNoQuery("Update TripDetails Set " + e.Column.FieldName + " = {0} Where TripDetailID = {1}", e.Value, tripDetailID);
        }
        private void LoadTripStatus()
        {
            DataProcess<TripDetailStatu> tripStatusDA = new DataProcess<TripDetailStatu>();
            this.rpi_lke_TripStatus.DataSource = tripStatusDA.Select();
            this.rpi_lke_TripStatus.DisplayMember = "TripStatusDescriptions";
            this.rpi_lke_TripStatus.ValueMember = "TripStatus";
        }
        private void LoadDocumentStatus()
        {
            this.rpi_lke_DocStatus.DataSource = FileProcess.LoadTable("Select * from DocumentStatus ");
            this.rpi_lke_DocStatus.ValueMember = "DocumentStatusID";
            this.rpi_lke_DocStatus.DisplayMember = "DocumentStatusDescription";
        }

        private void rpi_lke_TripStatus_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.Value == null) return;
            int tripStatus = Convert.ToInt32(e.Value);
            // Checking trip is confirmed
            if (Convert.ToBoolean(this.grvTripDetails.GetFocusedRowCellValue("TripConfirmed")))
            {
                if (tripStatus <= 1 && tripStatus != 12 && tripStatus != 13)
                {
                    MessageBox.Show("This Trip has confirmed, please changed to other status", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.AcceptValue = false;
                    return;
                }
            }
            else
            {
                if (tripStatus > 1 && tripStatus != 12 && tripStatus != 13)
                {
                    MessageBox.Show("This Trip not confirmed, please changed to other status", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.AcceptValue = false;
                    return;
                }
            }

            int tripDetailID = Convert.ToInt32(this.grvTripDetails.GetFocusedRowCellValue("TripDetailID"));
            var currentUser = AppSetting.CurrentUser.LoginName;
            var tripStatusNew = e.Value;
            DataProcess<object> tripDetailDA = new DataProcess<object>();
            tripDetailDA.ExecuteNoQuery("Update TripDetails Set TripDetails.TripStatus = {0} Where TripDetailID = {1}", e.Value, tripDetailID);
            // Tracking who change this status
            tripDetailDA.ExecuteNoQuery($"STTripDetailUpdateStatus @TripDetailID = {tripDetailID}, @UpdateBy = {currentUser}, @TripStatusNew = {tripStatusNew}");

            // Update value on grid UI
            //this.tripDetailsList[this.grvTripDetails.FocusedRowHandle].TripStatus = Convert.ToByte(tripStatus);


            //Kho nhận lại 1 phần
            //Kho nhận lại toàn bộ
            if (tripStatus == 12 || tripStatus == 13)
            {
                string orderNumber = this.grvTripDetails.GetFocusedRowCellValue("CustomerOrderNumber").ToString();
                if (string.IsNullOrEmpty(orderNumber)) return;
                int orderID = Convert.ToInt32(orderNumber.Split('-')[1]);
                frm_WM_DispatchingOrders DispatchingOrdersForm = frm_WM_DispatchingOrders.GetInstance(orderID, true);
                if (DispatchingOrdersForm.Visible)
                {
                    DispatchingOrdersForm.ReloadData();
                }
                DispatchingOrdersForm.Show();
            }


            // Re-load data
            this.btn_Refresh_Click(sender, e);
        }

        private void rpi_lke_DocStatus_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.Value == null) return;
            string valueName = Convert.ToString(e.Value);
            if (valueName.Equals("System.Object")) return;

            int tripDetailID = Convert.ToInt32(this.grvTripDetails.GetFocusedRowCellValue("TripDetailID"));
            DataProcess<object> tripDetailDA = new DataProcess<object>();
            tripDetailDA.ExecuteNoQuery("Update TripDetails Set TripDetails.DocumentStatus = {0} Where TripDetailID = {1}", e.Value, tripDetailID);
            this.grcTripDetails.DataSource = FileProcess.LoadTable(this.query);
            //this.tripDetailsList[this.grvTripDetails.FocusedRowHandle].DocumentStatus = Convert.ToByte(e.Value);
        }

        private void textCustomerOrderNumber_EditValueChanged(object sender, EventArgs e)
        {
            //this.grcTripDetails.DataSource = FileProcess.LoadTable("");
            this.grvTripDetails.Columns[4].Visible = false;
            this.grvTripDetails.Columns[6].Visible = false;
            this.grvTripDetails.Columns[9].Visible = false;
            this.grvTripDetails.Columns[10].Visible = false;
            this.grvTripDetails.Columns[12].Visible = false;
            this.grvTripDetails.Columns[0].Visible = false;
            this.grvTripDetails.Columns[1].Visible = false;
            //this.TripDAte.Visible = false;

            string dateFrom = Convert.ToDateTime(txtFromDate.EditValue).Date.ToString("yyyy-MM-dd");
            string dateTo = Convert.ToDateTime(txtToDate.EditValue).Date.ToString("yyyy-MM-dd");
            string CustomerID = this.lke_Customer.EditValue.ToString();
            this.grcTripDetails.DataSource = FileProcess.LoadTable("STTripSummaryByCutomers " + CustomerID + ",'" + dateFrom + "','" + dateTo + "','" + this.textCustomerOrderNumber.EditValue + "'");
            this.query = "STTripSummaryByCutomers " + CustomerID + ",'" + dateFrom + "','" + dateTo + "','" + this.textCustomerOrderNumber.EditValue + "'";
        }
    }
}
