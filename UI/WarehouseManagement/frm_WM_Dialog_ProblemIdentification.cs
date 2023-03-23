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
    public partial class frm_WM_Dialog_ProblemIdentification : Common.Controls.frmBaseForm
    {
        private int _locationID;

        public frm_WM_Dialog_ProblemIdentification(int locationID)
        {
            InitializeComponent();
            this._locationID = locationID;
            this.dtFrom.EditValue = DateTime.Now;
            this.dtTo.EditValue = DateTime.Now;
        }

        private void frm_WM_Dialog_ProblemIdentification_Load(object sender, EventArgs e)
        {
            InitLocations();
            this.lkeLocations.EditValue = this._locationID;
            LoadProblems();
            SetEvents();
        }

        private void SetEvents()
        {
            this.btnRefresh.Click += BtnRefresh_Click;
            //this.rpi_btn_OpenOrder.Click += Rpi_btn_OpenOrder_Click;
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadProblems();
        }

        private void Rpi_btn_OpenOrder_Click(object sender, EventArgs e)
        {
            string orderNumber = Convert.ToString(this.grvProblems.GetFocusedRowCellValue("OrderNumber"));
            int orderID = Convert.ToInt32(this.grvProblems.GetFocusedRowCellValue("OrderID"));

            if (orderNumber.Substring(0, 2).Equals("RO"))
            {
                frm_WM_ReceivingOrders.Instance.ReceivingOrderIDFind = orderID;
                frm_WM_ReceivingOrders.Instance.Show();
            }
            else
            {
                var dispatching = frm_WM_DispatchingOrders.GetInstance(orderID);
                if (dispatching.Visible)
                {
                    dispatching.ReloadData();
                }
                dispatching.Show();
            }
        }

        private void LoadProblems()
        {
            this.grdProblems.DataSource = FileProcess.LoadTable("STProblemIdentification @FromDate = '" + this.dtFrom.DateTime.ToString("yyyy-MM-dd") + "', @Todate = '" + this.dtTo.DateTime.ToString("yyyy-MM-dd") + "', @VarLocationID = " + Convert.ToInt32(this.lkeLocations.EditValue));
        }

        private void InitLocations()
        {
            this.lkeLocations.Properties.DataSource = AppSetting.LocationList;
            this.lkeLocations.Properties.ValueMember = "LocationID";
            this.lkeLocations.Properties.DisplayMember = "LocationNumberShort";
        }

        private void rpi_hle_OrderID_Click(object sender, EventArgs e)
        {
            string orderNumber = Convert.ToString(this.grvProblems.GetFocusedRowCellValue("OrderNumber"));
            int orderID = Convert.ToInt32(this.grvProblems.GetFocusedRowCellValue("OrderID"));

            if (orderNumber.Substring(0, 2).Equals("RO"))
            {
                frm_WM_ReceivingOrders.Instance.ReceivingOrderIDFind = orderID;
                frm_WM_ReceivingOrders.Instance.Show();
            }
            else
            {
                var dispatching = frm_WM_DispatchingOrders.GetInstance(orderID);
                if (dispatching.Visible)
                {
                    dispatching.ReloadData();
                }
                dispatching.Show();
            }
        }
    }
}
