using System;
using System.Windows.Forms;
using DA;
using System.Linq;
using Common.Process;
using Common.Controls;
using UI.Helper;

namespace UI.StockTake
{
    public partial class frm_ST_StockOnHandByRoomOneCustomer : frmBaseForm
    {
        private Customers currentCustomer = null;
        private Lazy<string> lazyLoadData = null;
        public frm_ST_StockOnHandByRoomOneCustomer(int customerSelected, string para)
        {
            InitializeComponent();
            this.currentCustomer = AppSetting.CustomerListAll.Where(c => c.CustomerID == customerSelected).FirstOrDefault();

            //Load data on load form
            this.lazyLoadData = new Lazy<string>(() =>
            {
                return this.InitData();
            });
        }

        //public frm_ST_StockOnHandByRoomOneCustomer(int customerID, string customerName)
        //{
        //    InitializeComponent();
        //    //InitData();
        //    this.grd_ST_RoomByCustomer.DataSource = FileProcess.LoadTable("STStockOnHandByRoom1Customer " + customerID.ToString());
        //    this.Text = "Stock On Hand By Room : " + customerName;
        //}
        private string InitData()
        {
            try
            {
                DataProcess<STStockOnHandByRoom1Customer_Result> roomDa = new DataProcess<STStockOnHandByRoom1Customer_Result>();
                System.Collections.Generic.IEnumerable<STStockOnHandByRoom1Customer_Result> dataSource = roomDa.Executing("STStockOnHandByRoom1Customer @CustomerID={0}", this.currentCustomer.CustomerID);
                this.grd_ST_RoomByCustomer.DataSource = dataSource;

                // Get fist object 
                STStockOnHandByRoom1Customer_Result roomFirst = dataSource.FirstOrDefault();
                this.lblHeader.Text = roomFirst.CustomerNumber + " " + roomFirst.CustomerName;
            }
            catch (Exception ex)
            {
            }

            return string.Empty;
        }

        private void chkMain_CheckedChanged(object sender, EventArgs e)
        {
            Wait.Start(this);
            if (this.currentCustomer == null)
            {
                Wait.Close();
                return;
            }
            if (this.chkMain.Checked)
            {
                DataProcess<STStockOnHandByRoom1CustomerMain_Result> roomByOneCustomerMainDa = new DataProcess<STStockOnHandByRoom1CustomerMain_Result>();
                this.grd_ST_RoomByCustomer.DataSource = roomByOneCustomerMainDa.Executing("STStockOnHandByRoom1CustomerMain @CustomerID={0}", this.currentCustomer.CustomerMainID);
            }
            else
            {
                DataProcess<STStockOnHandByRoom1Customer_Result> roomByOneCustomer = new DataProcess<STStockOnHandByRoom1Customer_Result>();
                this.grd_ST_RoomByCustomer.DataSource = roomByOneCustomer.Executing("STStockOnHandByRoom1Customer @CustomerID={0}", this.currentCustomer.CustomerID);
            }
            Wait.Close();
        }

        private void frm_ST_StockOnHandByRoomOneCustomer_Load(object sender, EventArgs e)
        {
            string lazyData = this.lazyLoadData.Value;
        }

        private void rpi_hle_GotoRoom_Click(object sender, EventArgs e)
        {

        }

        private void rpibtnView_Click(object sender, EventArgs e)
        {
            frm_ST_StockOnHandByRoom frm = new frm_ST_StockOnHandByRoom(this.grv_ST_RoomByCustomer.GetFocusedRowCellValue("RoomID").ToString());
            frm.Show();
            frm.WindowState = FormWindowState.Normal;
            frm.BringToFront();
        }
    }
}
