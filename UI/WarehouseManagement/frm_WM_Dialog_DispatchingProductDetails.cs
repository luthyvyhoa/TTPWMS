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

namespace UI.WarehouseManagement
{
    public partial class frm_WM_Dialog_DispatchingProductDetails : Common.Controls.frmBaseForm
    {
        private int _dispatchingProductID;

        public frm_WM_Dialog_DispatchingProductDetails(int dispatchingProductID)
        {
            InitializeComponent();
            this._dispatchingProductID = dispatchingProductID;
        }

        private void frm_WM_Dialog_DispatchingProductDetails_Load(object sender, EventArgs e)
        {
            LoadDispatchedDetails();
            SetEvents();
        }

        private void SetEvents()
        {
           // this.rpi_btn_OpenRO.Click += Rpi_btn_OpenRO_Click;
            this.btnPalletInfo.Click += BtnPalletInfo_Click;
        }

        private void Rpi_btn_OpenRO_Click(object sender, EventArgs e)
        {
            int orderID = Convert.ToInt32(this.grvDispatchedDetail.GetFocusedRowCellValue("ReceivingOrderID"));
            string orderType = Convert.ToString(this.grvDispatchedDetail.GetFocusedRowCellValue("ReceivingOrderNumber")).Substring(0, 2);

            if (orderType.Equals("RO"))
            {
                frm_WM_ReceivingOrders.Instance.ReceivingOrderIDFind = orderID;
                frm_WM_ReceivingOrders.Instance.Show();
            }
            else
            {
                var frmDispatching = frm_WM_DispatchingOrders.GetInstance(orderID);
                if (frmDispatching.Visible)
                {
                    frmDispatching.ReloadData();
                }
                frmDispatching.Show();
            }
        }

        private void BtnPalletInfo_Click(object sender, EventArgs e)
        {
            int customerID = Convert.ToInt32(this.grvDispatchedDetail.GetFocusedRowCellValue("CustomerID"));
            int productID = Convert.ToInt32(this.grvDispatchedDetail.GetFocusedRowCellValue("ProductID"));
            frm_WM_PalletInfo frm = new frm_WM_PalletInfo(customerID, productID);
            frm.Show();
        }

        private void LoadDispatchedDetails()
        {
            this.grdDispatchedDetail.DataSource = FileProcess.LoadTable("WebStockReceivedDetails @varReceivingOrderDetailID = " + this._dispatchingProductID);
        }

        private void rpi_hle_OpenRO_Click(object sender, EventArgs e)
        {
            int orderID = Convert.ToInt32(this.grvDispatchedDetail.GetFocusedRowCellValue("ReceivingOrderID"));
            string orderType = Convert.ToString(this.grvDispatchedDetail.GetFocusedRowCellValue("ReceivingOrderNumber")).Substring(0, 2);

            if (orderType.Equals("RO"))
            {
                frm_WM_ReceivingOrders.Instance.ReceivingOrderIDFind = orderID;
                frm_WM_ReceivingOrders.Instance.Show();
            }
            else
            {
                var frmDispatching = frm_WM_DispatchingOrders.GetInstance(orderID);
                if (frmDispatching.Visible)
                {
                    frmDispatching.ReloadData();
                }
                frmDispatching.Show();
            }
        }
    }
}
