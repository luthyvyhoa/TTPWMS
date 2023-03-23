using DA;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
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
    public partial class frm_WM_Dialog_DispatchingOrderDetails : Form
    {
        private int _dispatchingProductID;
        private int rowIndexFocused = 0;
        public frm_WM_Dialog_DispatchingOrderDetails(int dispatchingProductID)
        {
            InitializeComponent();
            this._dispatchingProductID = dispatchingProductID;
            this.grdDispatchedDetail.DataSource = FileProcess.LoadTable("STStockDispatchedDetailByDispatchingOrders " + this._dispatchingProductID);
        }

        public void InitData(int dispatchingProductID)
        {
            this._dispatchingProductID = dispatchingProductID;
            this.LoadDispatchedDetails();
        }

        private void LoadDispatchedDetails()
        {
            this.grdDispatchedDetail.DataSource = FileProcess.LoadTable("STStockDispatchedDetailByDispatchingOrders " + this._dispatchingProductID);

            // Set filter value
            string filter = this.grvDispatchedDetail.ActiveFilterString;
            string newFilterString = "Contains([DispatchingProductID], " + this._dispatchingProductID + ")";
            grvDispatchedDetail.ActiveFilterString = newFilterString;
        }

        private void frm_WM_Dialog_DispatchingOrderDetails_Load(object sender, EventArgs e)
        {
            LoadDispatchedDetails();
        }

        private void repositoryItemHyperLinkEdit1_Click(object sender, EventArgs e)
        {

            int orderID = Convert.ToInt32(this.grvDispatchedDetail.GetFocusedRowCellValue("ReceivingOrderID"));
            frm_WM_ReceivingOrders.Instance.ReceivingOrderIDFind = orderID;
            frm_WM_ReceivingOrders.Instance.Show();
        }

        private void grvDispatchedDetail_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void repositoryItemHyperLinkEdit2_DoubleClick(object sender, EventArgs e)
        {
            var dl = MessageBox.Show("Do you want to split qty from this detail?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dl.Equals(DialogResult.No)) return;
            int totalReceivedQty = Convert.ToInt32(this.grvDispatchedDetail.GetFocusedRowCellValue("ReceivedQty"));
            var defaultRespond = XtraInputBox.Show("Please enter the required quantity to break the order :", "TPWMS", "0");
            if (string.IsNullOrEmpty(defaultRespond)) return;
            short breakQty = Convert.ToInt16(defaultRespond);

            if (breakQty > totalReceivedQty || breakQty < 1)
            {
                XtraMessageBox.Show("Wrong Number !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //LoadDataDetail(Convert.ToInt32(textEditOrderID.Tag)); 
                int DPID = Convert.ToInt32(this.grvDispatchedDetail.GetFocusedRowCellValue("DispatchingProductID"));
                int RDID = Convert.ToInt32(this.grvDispatchedDetail.GetFocusedRowCellValue("ReceivingOrderDetailID"));
                DataProcess<object> dataProcess = new DataProcess<object>();
                int resultProcess;
                resultProcess = dataProcess.ExecuteNoQuery("STDispatchingProductSplitQty " + DPID + "," + RDID + "," + breakQty + ",'" + AppSetting.CurrentUser.LoginName + "'");
                if (resultProcess < 0)
                {
                    MessageBox.Show("Process Fail", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show("Process Ok", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
