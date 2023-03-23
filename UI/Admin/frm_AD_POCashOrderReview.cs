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

namespace UI.Admin
{
    public partial class frm_AD_POCashOrderReview : frmBaseFormNormal
    {
        public frm_AD_POCashOrderReview()
        {
            if (AppSetting.CurrentEmployee.ManagementLevel <= 5 || AppSetting.CurrentEmployee.ManagementLevel == 15)
            {
                InitializeComponent();
                this.dtFromDate.DateTime = DateTime.Today.AddDays(-30);
                this.dtToDate.DateTime = DateTime.Today;
                UpdateData();
            }
            else
                return;
        }

        private void UpdateData()
        {
            string fromdate = this.dtFromDate.DateTime.ToString("yyyy-MM-dd");
            string todate = this.dtToDate.DateTime.ToString("yyyy-MM-dd");
            this.grcOrderReview.DataSource = FileProcess.LoadTable("STPurchasingOrderCashOrderReview '" + fromdate + "','" + todate + "'");
        }
        private void grvOrderReview_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            string orderNumber = this.grvOrderReview.GetFocusedRowCellValue("OrderNumber").ToString();
            string orderID = this.grvOrderReview.GetFocusedRowCellValue("OrderID").ToString();
            this.grcOrderDetails.DataSource = FileProcess.LoadTable("STPurchasingOrderCashOrderDetails '" + orderNumber + "'," + orderID);
        }

        private void dtToDate_EditValueChanged(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void dtFromDate_EditValueChanged(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void rpe_hle_OrderNumber_Click(object sender, EventArgs e)
        {
            string orderType = this.grvOrderReview.GetFocusedRowCellValue("OrderNumber").ToString();
            int orderID = Convert.ToInt32(orderType.Substring(3, orderType.Length-3));
            
            if (orderType.Substring(0,2) == "PO") //Open Purchasing Orders
            {
                frm_AD_PurchasingOrders frm = new frm_AD_PurchasingOrders(orderID);
                frm.Show();
                frm.BringToFront();
            }
            else
            {
                frm_AD_PettyCash frm = new frm_AD_PettyCash(orderID);
                frm.Show();
                frm.BringToFront();
            }

        }
    }
}
