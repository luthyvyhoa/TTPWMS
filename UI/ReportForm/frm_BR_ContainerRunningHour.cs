using DA;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Objects;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Helper;
using UI.WarehouseManagement;

namespace UI.ReportForm
{
    public partial class frm_BR_ContainerRunningHour : Form
    {
        public frm_BR_ContainerRunningHour()
        {
            InitializeComponent();
            this.textEditGate.EditValue = AppSetting.CurrentUser.Gate;
            lke_Customer.Visible = true;
            setCustomerIDLookupEdit();
            this.dateEditToDate.EditValue = DateTime.Today;
            this.dateEditFromDate.EditValue = DateTime.Today;
        }

        private void checkEditAllCustomer_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkEditAllCustomer.Checked)
            {
                lke_Customer.Visible = false;
            }
            else
            {
                lke_Customer.Visible = true;
                setCustomerIDLookupEdit();
                this.lke_Customer.ShowPopup();
            }
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            String FromDate = Convert.ToDateTime(dateEditFromDate.EditValue.ToString()).ToString("yyyy-MM-dd");
            String ToDate = Convert.ToDateTime(dateEditToDate.EditValue.ToString()).ToString("yyyy-MM-dd");
            //XtraMessageBox.Show("STGate_ContInOutPRC '" + FromDate + "','" + ToDate + "',0," + this.textEditGate.EditValue.ToString());
            if (checkEditAllCustomer.Checked)
            {
                this.grdVehicleManagement.DataSource = FileProcess.LoadTable("STGate_ContInOutPRC '" + FromDate + "','" + ToDate + "',0," + this.textEditGate.EditValue.ToString());
            }
            else
            {
                if (this.lke_Customer.EditValue == null) return;
                this.grdVehicleManagement.DataSource = FileProcess.LoadTable("STGate_ContInOutPRC '" + FromDate + "','" + ToDate + "'," + this.lke_Customer.EditValue.ToString() + "," + this.textEditGate.EditValue.ToString());
            }

            //LoadDetailGrids();

            //try
            //{
            //    this.InitData(this._orderNumber, this.qty);
            //}
            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show(ex.Message, "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
        private void LoadDetailGrids()
        {
            try
            {
                int ContInoutID = Convert.ToInt32(this.grvVehicleManagementTableView.GetFocusedRowCellValue("VehicleInOutID"));
                String orderNumber = this.grvVehicleManagementTableView.GetFocusedRowCellValue("VehicleInOutID").ToString();
                this.grdContainerCheckings.DataSource = FileProcess.LoadTable("STGate_ContainerCheckingsByContInOutID " + ContInoutID);
                this.grdElectricComsumption.DataSource = FileProcess.LoadTable("STElectricityConsumption @OrderNumber ='" + orderNumber + "'");
            }
            catch
            {
            }

        }
        private void setCustomerIDLookupEdit()
        {
            this.lke_Customer.Properties.DataSource = FileProcess.LoadTable("STcomboCustomerIDAll " + AppSetting.StoreID);
            this.lke_Customer.Properties.ValueMember = "CustomerID";
            this.lke_Customer.Properties.DisplayMember = "CustomerNumber";
            this.lke_Customer.EditValue = 0;
        }

        private void grvVehicleManagementTableView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadDetailGrids();
        }

        private void rpi_OtherServiceID_Click(object sender, EventArgs e)
        {
            string otherServiceIDStr = Convert.ToString(this.grvVehicleManagementTableView.GetFocusedRowCellValue("OtherServiceID"));
            if (string.IsNullOrEmpty(otherServiceIDStr))
            {
                XtraMessageBox.Show("Can not find the Service !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int otherServiceID = Convert.ToInt32(otherServiceIDStr);
                frm_BR_OtherServices frm = new frm_BR_OtherServices(otherServiceID);
                frm.Show();
            }
            catch
            {

            }

        }

        private void rpi_OrderID_Click(object sender, EventArgs e)
        {
            string orderNumber = Convert.ToString(this.grvVehicleManagementTableView.GetFocusedRowCellValue("OrderNumber"));
            if (string.IsNullOrEmpty(orderNumber))
            {
                XtraMessageBox.Show("The order for this container does not exist !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string OrderType = orderNumber.Split('-')[0];
            int OrderID = Convert.ToInt32(orderNumber.Split('-')[1]);
            if (OrderType == "RO")
            {
                frm_WM_ReceivingOrders receivingOrder = frm_WM_ReceivingOrders.Instance;
                receivingOrder.ReceivingOrderIDFind = OrderID;
                receivingOrder.Show();
                receivingOrder.WindowState = FormWindowState.Maximized;
                receivingOrder.BringToFront();
            }
            else
            {
                frm_WM_DispatchingOrders dispatchingOrder = frm_WM_DispatchingOrders.GetInstance(OrderID);
                if (dispatchingOrder.Visible)
                {
                    dispatchingOrder.ReloadData();
                }
                dispatchingOrder.Show();
                dispatchingOrder.WindowState = FormWindowState.Maximized;
                dispatchingOrder.BringToFront();
            }
        }

        private void btnCreateService_Click(object sender, EventArgs e)
        {
            string svcID = this.grvVehicleManagementTableView.GetFocusedRowCellValue("VehicleInOutID").ToString();
            if (svcID != "")
            {
                XtraMessageBox.Show("Can not create service for this Container !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string strContInOutID = this.grvContainerCheckingTableView.GetFocusedRowCellValue("VehicleInOutID").ToString();
            SqlConnection conn = new SqlConnection(new SwireDBEntities().Database.Connection.ConnectionString);
            SqlCommand cmd = new SqlCommand("ST_WMS_ElectricityToOSByContainerCreated", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter contInOutID = cmd.Parameters.Add("@ContInOutID", SqlDbType.Int);
            contInOutID.Value = strContInOutID;

            SqlParameter CurrentUser = cmd.Parameters.Add("@CurrentUser", SqlDbType.VarChar);
            CurrentUser.Value = Convert.ToString(AppSetting.CurrentUser);

            SqlParameter OtherServiceID = cmd.Parameters.Add("@OtherServiceID", SqlDbType.Int);
            OtherServiceID.Direction = ParameterDirection.Output;
            conn.Open();
            return;
            int result = cmd.ExecuteNonQuery();

            frm_BR_OtherServices frm = new frm_BR_OtherServices(Convert.ToInt32(OtherServiceID.Value));
            frm.Show();
            frm.BringToFront();
        }


    }
}
