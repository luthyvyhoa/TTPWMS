using DA;
using DevExpress.XtraEditors;
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
using UI.MasterSystemSetup;
using UI.StockTake;

namespace UI.Management
{
    public partial class frm_M_GO_StockOnHandAllCustomer : Common.Controls.frmBaseForm
    {
        private DataTable _tbStockOnHand;

        public frm_M_GO_StockOnHandAllCustomer()
        {
            InitializeComponent();
        }

        private void frm_M_GO_StockOnHandAllCustomer_Load(object sender, EventArgs e)
        {
            InitWarehouse();
            InitRoom();
            SetEvents();
        }

        private void SetEvents()
        {
            this.rpi_btn_View.Click += Rpi_btn_View_Click;
            this.rpi_btn_Room.Click += Rpi_btn_Room_Click;
            this.rpi_btn_CustomerInfo.Click += Rpi_btn_CustomerInfo_Click;
            this.chkAll.CheckedChanged += ChkAll_CheckedChanged;
            this.chkRoom.CheckedChanged += ChkRoom_CheckedChanged;
            this.chkWarehouse.CheckedChanged += ChkWarehouse_CheckedChanged;
            this.lkeRooms.CloseUp += LkeRooms_CloseUp;
            this.lkeWarehouse.CloseUp += LkeWarehouse_CloseUp;
        }

        private void Rpi_btn_View_Click(object sender, EventArgs e)
        {
            int customerID = Convert.ToInt32(this.grvStockOnHand.GetFocusedRowCellValue("CustomerID"));
            frm_ST_StockOnHandOneCustomer frm = new frm_ST_StockOnHandOneCustomer(customerID);
            frm.Show();
        }

        private void Rpi_btn_Room_Click(object sender, EventArgs e)
        {
            
            int varCustomerID = Convert.ToInt32(this.grvStockOnHand.GetFocusedRowCellValue("CustomerID"));
            Customers customer = AppSetting.CustomerList.FirstOrDefault(c => c.CustomerID == Convert.ToInt32(this.grvStockOnHand.GetFocusedRowCellValue("CustomerID")));
            frm_ST_StockOnHandByRoomOneCustomer frm = new frm_ST_StockOnHandByRoomOneCustomer(varCustomerID, this.grvStockOnHand.GetFocusedRowCellValue("CustomerName").ToString());
            //frm_ST_StockOnHandByRoomOneCustomer frm = new frm_ST_StockOnHandByRoomOneCustomer(customer);


            frm.Show();
        }

        private void Rpi_btn_CustomerInfo_Click(object sender, EventArgs e)
        {
            Customers customer = AppSetting.CustomerList.FirstOrDefault(c => c.CustomerID == Convert.ToInt32(this.grvStockOnHand.GetFocusedRowCellValue("CustomerID")));
            frm_MSS_Customers.Instance.CurrentCustomers = customer;
            frm_MSS_Customers.Instance.WindowState = FormWindowState.Normal;
            frm_MSS_Customers.Instance.BringToFront();
            frm_MSS_Customers.Instance.Show();
        }

        private void LkeWarehouse_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            this.lkeWarehouse.EditValue = e.Value;
            this._tbStockOnHand = FileProcess.LoadTable("STStockOnHandAllCustomersW @WarehouseID = " + Convert.ToInt16(this.lkeWarehouse.EditValue));
            LoadStocks();
        }

        private void LkeRooms_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            this.lkeRooms.EditValue = e.Value;
            this._tbStockOnHand = FileProcess.LoadTable("STStockOnHandByRoom @varRoomID = '" + Convert.ToString(this.lkeRooms.EditValue) + "', @varStoreID = " + AppSetting.StoreID);
            LoadStocks();
        }

        private void ChkWarehouse_CheckedChanged(object sender, EventArgs e)
        {
            if (chkWarehouse.Checked)
            {
                if (XtraMessageBox.Show("When open, the form uses pre-recorded data to save server resources.\nAre you sure to continue ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.chkAll.Checked = false;
                    this.chkRoom.Checked = false;
                    this.lkeWarehouse.ReadOnly = false;
                    this.lkeWarehouse.Focus();
                    this.lkeWarehouse.ShowPopup();
                }
            }
            else
            {
                this.lkeWarehouse.ReadOnly = true;
            }
        }

        private void ChkRoom_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRoom.Checked)
            {
                if(XtraMessageBox.Show("When open, the form uses pre-recorded data to save server resources.\nAre you sure to continue ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.chkAll.Checked = false;
                    this.chkWarehouse.Checked = false;
                    this.lkeRooms.ReadOnly = false;
                    this.lkeRooms.Focus();
                    this.lkeRooms.ShowPopup();
                }
            }
            else
            {
                this.lkeRooms.ReadOnly = true;
            }
        }

        private void ChkAll_CheckedChanged(object sender, EventArgs e)
        {
            if(chkAll.Checked)
            {
                if (XtraMessageBox.Show("When open, the form uses pre-recorded data to save server resources.\nAre you sure to continue ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.chkRoom.Checked = false;
                    this.chkWarehouse.Checked = false;
                    this._tbStockOnHand = FileProcess.LoadTable("STStockOnHandAllCustomers");
                    LoadStocks();
                }
            }
        }

        #region Load Data
        private void LoadStocks()
        {
            this.grdStockOnHand.DataSource = this._tbStockOnHand;
        }

        private void InitRoom()
        {
            DataProcess<Rooms> roomDA = new DataProcess<Rooms>();

            this.lkeRooms.Properties.DataSource = roomDA.Select();
            this.lkeRooms.Properties.ValueMember = "RoomID";
            this.lkeRooms.Properties.DisplayMember = "RoomID";
        }

        private void InitWarehouse()
        {
            DataProcess<Warehouses> warehouseDA = new DataProcess<Warehouses>();

            this.lkeWarehouse.Properties.DataSource = warehouseDA.Select();
            this.lkeWarehouse.Properties.ValueMember = "WarehouseID";
            this.lkeWarehouse.Properties.DisplayMember = "WarehouseDescription";
        }
        #endregion
    }
}
