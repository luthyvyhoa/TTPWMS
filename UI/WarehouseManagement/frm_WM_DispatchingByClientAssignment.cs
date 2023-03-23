using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Controls;
using DA;
using UI.Helper;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_DispatchingByClientAssignment : frmBaseFormNormal
    {
        private Customers currentCus = null;
        int roID = 0;
        public frm_WM_DispatchingByClientAssignment(int customerID, Boolean isMain, int receivingOrderID = 0)
        {
            InitializeComponent();
            initControl();
            initGrid();
            roID = receivingOrderID;
            this.lkeCustomerID.EditValue = customerID;
            this.LoadCustomerClient();
            currentCus = AppSetting.CustomerList.Where(c => c.CustomerID == customerID).FirstOrDefault();
            this.textCustomerName.Text = this.currentCus.CustomerName;
            initGrid();
        }
        private void initControl()
        {
            lkeCustomerID.Properties.DataSource = AppSetting.CustomerList.Where(a => a.CustomerDiscontinued == false);
            lkeCustomerID.Properties.ValueMember = "CustomerID";
            lkeCustomerID.Properties.DisplayMember = "CustomerNumber";
        }
        private void LoadCustomerClient()
        {
            if (this.lkeCustomerID.EditValue == null) return;
            this.rle_CustomerClientID.DataSource = FileProcess.LoadTable("STCustomerClients " + this.lkeCustomerID.EditValue);
            this.rle_CustomerClientID.ValueMember = "CustomerClientID";
            this.rle_CustomerClientID.DisplayMember = "CustomerClientCode";
        }
        private void initGrid()
        {
            this.grcDOAssignments.DataSource = FileProcess.LoadTable("ST_WMS_LoadDispatchingByClientAssigment " + this.lkeCustomerID.EditValue);
        }

        private void lkeCustomerID_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.Value == null) return;
            int customerID = (int)e.Value;
            currentCus = AppSetting.CustomerList.Where(c => c.CustomerID == customerID).FirstOrDefault();
            this.textCustomerName.Text = this.currentCus.CustomerName;
            this.LoadCustomerClient();
            initGrid();
        }

        private void rpi_btn_Delete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var msgConfig = MessageBox.Show("Are you sure to delete this records?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msgConfig.Equals(DialogResult.No)) return;
            int clientAssignID = Convert.ToInt32(this.grvAssignments.GetFocusedRowCellValue("DispatchingByClientAssignmentID"));
            DataProcess<object> dataProcess = new DataProcess<object>();
            dataProcess.ExecuteNoQuery("Delete DispatchingByClientAssignments where DispatchingByClientAssignmentID={0}", clientAssignID);
            this.initGrid();
        }

        private void rle_CustomerClientID_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.Value == null) return;
            int clientAssignID = Convert.ToInt32(this.grvAssignments.GetFocusedRowCellValue("DispatchingByClientAssignmentID"));
            int customerClientID = Convert.ToInt32(e.Value);
            DataProcess<object> dataProcess = new DataProcess<object>();
            dataProcess.ExecuteNoQuery("Update DispatchingByClientAssignments set CustomerClientID={0} where DispatchingByClientAssignmentID={1}", customerClientID, clientAssignID);
            this.initGrid();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            DataProcess<object> dataProcess = new DataProcess<object>();
            dataProcess.ExecuteNoQuery("STDispatchingByClientAssignmentAddRO " + Convert.ToString(roID) + ",'" + AppSetting.CurrentUser.LoginName + "'");
            this.grcDOAssignments.DataSource = FileProcess.LoadTable("ST_WMS_LoadDispatchingByClientAssigment " + this.lkeCustomerID.EditValue);
        }

        private void rhe_ProductID_Click(object sender, EventArgs e)
        {
            int customerID = Convert.ToInt32(this.lkeCustomerID.EditValue.ToString());
            int productID = Convert.ToInt32(this.grvAssignments.GetFocusedRowCellValue("ProductID").ToString());
            frm_WM_PalletInfo form = new frm_WM_PalletInfo(customerID, productID);
            form.Show();
        }

        private void rhe_ROID_Click(object sender, EventArgs e)
        {
            int v_ReceivingOrderID = 0;

            try
            {
                v_ReceivingOrderID = Convert.ToInt32(this.grvAssignments.GetFocusedRowCellValue("ReceivingOrderID"));
            }
            catch { }

            frm_WM_ReceivingOrders frm = frm_WM_ReceivingOrders.Instance;
            frm.ReceivingOrderIDFind = v_ReceivingOrderID;
            //frm.StartPosition = FormStartPosition.CenterScreen;
            //frm.ShowInTaskbar = false;
            frm.Show();
        }

        private void grvAssignments_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DataProcess<object> dataProcess = new DataProcess<object>();
            int clientAssignID = Convert.ToInt32(this.grvAssignments.GetFocusedRowCellValue("DispatchingByClientAssignmentID"));
            switch (e.Column.FieldName)
            {
                case "Remark":
                    dataProcess.ExecuteNoQuery("Update DispatchingByClientAssignments Set Remark={0} where DispatchingByClientAssignmentID={1}", e.Value, clientAssignID);
                    break;
                default:
                    break;
            }
        }
    }
}
