using System.Windows.Forms;
using Common.Controls;
using DA;
using System.Linq;
using UI.Helper;
using UI.WarehouseManagement;

namespace UI.Supperviors
{
    public partial class frm_S_SJTHS_OrdersUnconfirm : frmBaseForm
    {
        private DataProcess<STOrderUnlockedView_Result> orderUnlockDA = null;
        private DataProcess<STOrderUnlockedSearch_Result> orderUnlockSearchDA = null;
        private string radSelected = string.Empty;
        public frm_S_SJTHS_OrdersUnconfirm()
        {
            InitializeComponent();

            // Init data
            this.orderUnlockDA = new DataProcess<STOrderUnlockedView_Result>();
            this.orderUnlockSearchDA = new DataProcess<STOrderUnlockedSearch_Result>();
            this.dFrom.DateTime = System.DateTime.Now;
            this.dTo.DateTime = System.DateTime.Now;

            // Init customer data
            this.lkeCustomer.Properties.DataSource = AppSetting.CustomerList;
            this.lkeCustomer.Properties.DisplayMember = "CustomerNumber";
            this.lkeCustomer.Properties.ValueMember = "CustomerID";

            // Set default order type select is Ro
            this.radRo.Checked = true;
        }

        /// <summary>
        /// Init data on gridcontrol by order type selected
        /// </summary>
        /// <param name="orderType">string</param>
        /// <param name="customerID">int</param>
        private void InitData(string orderType, int customerID = -1)
        {
            if (string.IsNullOrEmpty(orderType)) return;
            this.grdRoData.DataSource = this.orderUnlockDA.Executing(" STOrderUnlockedView @OrderType={0},@CustomerID={1}", orderType, customerID);
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void radTb_CheckedChanged(object sender, System.EventArgs e)
        {
            System.Windows.Forms.RadioButton rad = (System.Windows.Forms.RadioButton)sender;
            int customerID = -1;

            // Set focus on textbox order id
            this.txtRoId.Focus();

            // Detect Order is selected
            switch (rad.Text)
            {
                // Customer
                case "Customer":
                    this.lkeCustomer.Focus();
                    this.lkeCustomer.ShowPopup();
                    return;
                    //break;
            }

            // Set order text current selected 
            this.radSelected = rad.Text;

            // Load data
            this.InitData(rad.Text, customerID);
        }

        private void txtRoId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                this.btnGo_Click(sender, e);
            }
        }

        private void btnGo_Click(object sender, System.EventArgs e)
        {
            // Load data
            this.grdRoData.DataSource = this.orderUnlockSearchDA.Executing("STOrderUnlockedSearch @OrderType={0},@OrderID={1}", this.radSelected, this.txtRoId.Text);
            this.grvRoData.RefreshData();
        }

        private void lkeCustomer_EditValueChanged(object sender, System.EventArgs e)
        {
            if (this.lkeCustomer.EditValue == null) return;
            this.InitData("All", (int)this.lkeCustomer.EditValue);
        }

        /// <summary>
        /// View Order current selected
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">System.EventArgs</param>
        private void rpi_btn_ViewRo_Click(object sender, System.EventArgs e)
        {
            // Get order number current selected
            string getOrderID = this.grvRoData.GetFocusedRowCellDisplayText("OrderNumber");

            // Validate order number is valid
            if (string.IsNullOrEmpty(getOrderID)) return;
            if (getOrderID.Length < 2) return;

            // Delect current order number is RO or DO
            string getOrderType = getOrderID.Substring(0, 2);

            // Get order id
            int orderID = (int)this.grvRoData.GetFocusedRowCellValue("OrderID");

            // Display order number
            switch (getOrderType)
            {
                // Display Receiving Order
                case "RO":
                    var receivingForm = frm_WM_ReceivingOrders.Instance;
                    receivingForm.ReceivingOrderIDFind = orderID;
                    receivingForm.BringToFront();
                    receivingForm.WindowState = FormWindowState.Maximized;
                    receivingForm.Show();
                    break;

                // Display Dispatching Order
                case "DO":
                    var dispatchingForm = frm_WM_DispatchingOrders.GetInstance(orderID);
                    if (dispatchingForm.Visible)
                    {
                        dispatchingForm.ReloadData();
                    }
                    dispatchingForm.BringToFront();
                    dispatchingForm.WindowState = FormWindowState.Maximized;
                    dispatchingForm.Show();
                    break;
            }
        }

        private void rpi_chk_Status_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (!(bool)e.OldValue)
            {
                e.Cancel = true;
                return;
            }
            if (string.IsNullOrEmpty(this.txtReasonToUnLock.Text))
            {
                MessageBox.Show("Please enter reason to unlocked!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }

            // Process unlock order
            // Get order number current selected
            string getOrderID = this.grvRoData.GetFocusedRowCellDisplayText("OrderNumber");

            // Validate order number is valid
            if (string.IsNullOrEmpty(getOrderID)) return;
            if (getOrderID.Length < 2) return;

            // Delect current order number is RO or DO
            string getOrderType = getOrderID.Substring(0, 2);

            // Get order id
            int orderID = (int)this.grvRoData.GetFocusedRowCellValue("OrderID");
            DataProcess<object> dataProcess = new DataProcess<object>();
            int resultUnlock = dataProcess.ExecuteNoQuery("STOrderUnlocked @OrderID={0},@UserID={1},@OrderType={2},@Reason={3}",
                orderID, AppSetting.CurrentUser.LoginName, getOrderType, this.txtReasonToUnLock.Text);
        }
    }
}
