using System;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Windows.Forms;
using DA;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using UI.Helper;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_Dialog_PickingSlip : Form
    {
        public frm_WM_Dialog_PickingSlip()
        {
            InitializeComponent();
        }
        private string currentOrderID = null;
        private string OrderType = "";
        public frm_WM_Dialog_PickingSlip(int OrderID, string FlagOrderType)
        {
            InitializeComponent();
            currentOrderID = Convert.ToString(OrderID);
            OrderType = FlagOrderType;
            switch (FlagOrderType)
            {
                case "DO":
                    this.grdPickingSlip.DataSource = FileProcess.LoadTable("STPickingSlipOldOrders " + OrderID);
                    break;
                case "WP":
                    this.grdPickingSlip.DataSource = FileProcess.LoadTable("STPickingSlipWaveOrders " + OrderID);
                    break;
                case "TW":
                    this.grdPickingSlip.DataSource = FileProcess.LoadTable("STPickingSlipTripOrders " + OrderID);
                    break;

            }

        }

        private frm_WM_PalletInfo palletInfo = null;
        private void rp_hle_ReceivingOrderID_Click(object sender, EventArgs e)
        {
            int receivingOrderID = Convert.ToInt32(this.grvPickingSlipTableView.GetRowCellValue(this.grvPickingSlipTableView.FocusedRowHandle, "ReceivingOrderID").ToString());
            frm_WM_ReceivingOrders receivingOrder = frm_WM_ReceivingOrders.Instance;
            receivingOrder.ReceivingOrderIDFind = receivingOrderID;
            receivingOrder.Show();
            receivingOrder.WindowState = FormWindowState.Maximized;
            receivingOrder.BringToFront();
        }

        private void rp_hle_PalletInformation_Click(object sender, EventArgs e)
        {
            int customerID = Convert.ToInt32(this.grvPickingSlipTableView.GetRowCellValue(this.grvPickingSlipTableView.FocusedRowHandle, "CustomerID").ToString());
            int productID = Convert.ToInt32(this.grvPickingSlipTableView.GetRowCellValue(this.grvPickingSlipTableView.FocusedRowHandle, "ProductID"));
            if (this.palletInfo == null)
            {
                this.palletInfo = new frm_WM_PalletInfo(customerID, productID);
            }
            else
            {
                this.palletInfo.InitData(customerID, productID);
            }
            this.palletInfo.Show();
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            this.grdPickingSlip.ShowPrintPreview();
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            int customerID = Convert.ToInt32(this.grvPickingSlipTableView.GetRowCellValue(this.grvPickingSlipTableView.FocusedRowHandle, "CustomerID").ToString());
            var customerInfo = AppSetting.CustomerList.Where(c => c.CustomerID == customerID).FirstOrDefault();
            string toEmail = customerInfo.Email;
            try
            {
                string fileExtension = "xlsx";
                string boby = "Stock Report From LLV";
                string orderNumber = this.OrderType + "-" + this.currentOrderID;
                //MaKHachHang_OrderNumber_NgàyGioGui
                string fileName = customerInfo.CustomerNumber + "_" + orderNumber +"_"+ DateTime.Now.ToString("ddMMyyyHHmm");
                string pathFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + fileName + "." + fileExtension;
                this.grdPickingSlip.ExportToXlsx(pathFile);

                // Attach file vào RO/DO
                
                frm_WM_Attachments.Instance.OrderNumber = orderNumber;
                frm_WM_Attachments.Instance.SaveAttachFile(pathFile, "Auto");

                // Gửi email
                Common.Process.DataTransfer.SendMailOutlookWithOriginalFile(toEmail, "Dispatching Order Detailed Data " + OrderType + "-" + currentOrderID, boby,true, pathFile);

                //XtraMessageBox.Show("Email sent successful!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Send failed!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
