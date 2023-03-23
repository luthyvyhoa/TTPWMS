using System;
using System.Windows.Forms;
using DA;
using System.Linq;
using UI.ReportForm;
using UI.Helper;

namespace UI.WarehouseManagement
{
    public partial class urc_WM_OtherService : UserControl
    {
        private frm_BR_OtherServices otherServiceForm;
        private frm_WM_MHLWorks OutsourcedJobForm;
        private string orderNumber = string.Empty;
        private int _customerID = 0;
        public urc_WM_OtherService(string orderNumber, int customerID = 0)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this._customerID = customerID;

            // Init data
            this.InitData(orderNumber,customerID);
        }

        /// <summary>
        /// Get or set receiving order info
        /// </summary>
        public ReceivingOrders RecevingOrderInfo { get; set; }

        /// <summary>
        /// Get or set dispatching order info
        /// </summary>
        public DispatchingOrders DispatchingOrderInfo { get; set; }

        private void btn_WM_New_Click(object sender, EventArgs e)
        {
            // Detect current order is receiving or dispatching order
            if (!string.IsNullOrEmpty(this.orderNumber))
            {
                string orderType = this.orderNumber.Substring(0, 2);
                int orderID = Convert.ToInt32(this.orderNumber.Split('-')[1]);
                switch (orderType)
                {
                    case "RO":
                        this.otherServiceForm = new frm_BR_OtherServices(Helper.OrderTypeEnum.RO, orderID, orderNumber, this._customerID);
                        break;

                    case "DO":
                        this.otherServiceForm = new frm_BR_OtherServices(Helper.OrderTypeEnum.DO, orderID, orderNumber, this._customerID);
                        break;

                    case "TW":
                        this.otherServiceForm = new frm_BR_OtherServices(Helper.OrderTypeEnum.TW, orderID, orderNumber, this._customerID);
                        break;

                    case "PC":
                        this.otherServiceForm = new frm_BR_OtherServices(Helper.OrderTypeEnum.PC, orderID, orderNumber, this._customerID);
                        break;

                    case "TB":
                        this.otherServiceForm = new frm_BR_OtherServices(Helper.OrderTypeEnum.TB, orderID, orderNumber, this._customerID);
                        break;
                }
            }
            otherServiceForm.Show();
        }

        public void InitData(string orderNumber,int customerID=0)
        {
            this._customerID = customerID;
            this.orderNumber = orderNumber;
            if (string.IsNullOrEmpty(orderNumber)) return;
            var dataSource = FileProcess.LoadTable("ST_WMS_LoadOtherServiceByOrderNumber @OrderNumber='" + orderNumber + "'");
            this.grd_WM_OtherServices.DataSource = dataSource;
            this.grd_WM_OutsourcedJobs.DataSource = FileProcess.LoadTable("ST_WMS_LoadOutsourcedJobByOrderNumber @OrderNumber ='" + orderNumber + "'");
        }

        private void rpi_hpl_OtherServiceID_Click(object sender, EventArgs e)
        {
            int otherServiceID = Convert.ToInt32(this.grv_WM_OtherServices.GetFocusedRowCellValue("OtherServiceID"));
            this.otherServiceForm = new frm_BR_OtherServices();
            this.otherServiceForm.OtherServiceIDFind = otherServiceID;
            this.otherServiceForm.BringToFront();
            this.otherServiceForm.Show();
        }

        private void rpe_OutsourceJobID_Click(object sender, EventArgs e)
        {
            int OutsourcedJobID = Convert.ToInt32(this.grvOutsourcedJob.GetFocusedRowCellValue("MHLWorkID"));
            this.OutsourcedJobForm = frm_WM_MHLWorks.Instance;
            OutsourcedJobForm.MHLWorkID = OutsourcedJobID;
            //this.otherServiceForm.BringToFront();
            OutsourcedJobForm.Show();
        }
    }
}
