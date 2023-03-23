using Common.Controls;
using DA;
using System;
using System.Windows.Forms;
using UI.Helper;
using UI.MasterSystemSetup;
using System.Linq;
using DevExpress.XtraEditors;
using System.Data;
using System.Data.SqlClient;
using UI.WarehouseManagement;

namespace UI.StockTake
{
    public partial class frm_ST_StockOnHandByRoom : frmBaseForm
    {
        private string currentRoomID = string.Empty;
        public frm_ST_StockOnHandByRoom(string roomIDSelected)
        {
            InitializeComponent();
            this.currentRoomID = roomIDSelected;
            LoadData();
        }
        public frm_ST_StockOnHandByRoom(string roomIDSelected, int _StoreID)
        {
            InitializeComponent();
            this.currentRoomID = roomIDSelected;
            this.grd_ST_StockOnHandByRoom.DataSource = FileProcess.LoadTable("STStockOnHandByRoom '" + this.currentRoomID +"',"+ _StoreID);
            this.chartStockOnHandByRoom.DataSource = FileProcess.LoadTable("WebChartStockOnHandByRoom '" + this.currentRoomID + "'," + _StoreID);

        }

        private void LoadData()
        {
            DataProcess<STStockOnHandByRoom_Result> dataProcess = new DataProcess<STStockOnHandByRoom_Result>();
            this.grd_ST_StockOnHandByRoom.DataSource = dataProcess.Executing("STStockOnHandByRoom @varRoomID={0},@varStoreID={1}", this.currentRoomID, AppSetting.StoreID);
            this.chartStockOnHandByRoom.DataSource = FileProcess.LoadTable("WebChartStockOnHandByRoom '" + this.currentRoomID + "'," + AppSetting.StoreID);
        }

        private void rpe_hle_CustomerReport_Click(object sender, EventArgs e)
        {
            int customerID = Convert.ToInt32(this.grvStockOnHandByRoom.GetFocusedRowCellValue("CustomerID"));
            var currentCustomer = AppSetting.CustomerListAll.Where(c => c.CustomerID == customerID).FirstOrDefault();
            frm_ST_StockOnHandByRoomOneCustomer frm = new frm_ST_StockOnHandByRoomOneCustomer(customerID, "");
            frm.ShowInTaskbar = false;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
            frm.BringToFront();
            frm.WindowState = FormWindowState.Normal;
        }

        private void grvStockOnHandByRoom_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            string _customerID = this.grvStockOnHandByRoom.GetFocusedRowCellValue("CustomerID").ToString();

            this.chartStockOnHandByRoom.DataSource = FileProcess.LoadTable("WebChartStockOnHandByRoom '" + this.currentRoomID + "'," + AppSetting.StoreID + "," + _customerID);
            this.grcLocationDetails.DataSource = FileProcess.LoadTable("STStockOnHandByRoom1CustomerDetail '" + this.currentRoomID + "'," + AppSetting.StoreID + "," + _customerID);
        }

        private void rhe_Location_Click(object sender, EventArgs e)
        {
            this.grcLocationDetails.DataSource = FileProcess.LoadTable("ST_WMS_LoadLocationByRoomByCustomer  '" + currentRoomID + "',"+this.grvStockOnHandByRoom.GetFocusedRowCellValue("CustomerID"));
        }

        private void btn_CreateDO_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Are you sure to create DO from the selected pallet(s) ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            string cellValues = "";
            int[] selectedRows = grvLocationDetails.GetSelectedRows();
            foreach (int rowHandle in selectedRows)
            {
                if (rowHandle >= 0)
                {
                    if (cellValues.Length > 0)
                        cellValues = cellValues + " , " + grvLocationDetails.GetRowCellValue(rowHandle, "PalletID").ToString();
                    else
                        cellValues = grvLocationDetails.GetRowCellValue(rowHandle, "PalletID").ToString();
                }
            }
            //choosenPallets = cellValues;

            //Excute Store to Export DO ,then get the DO id 
            int DO_ID = 0;
            using (var context = new SwireDBEntities())
            {
                using (var connection = context.Database.Connection)
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "STProductCheckingExportDO";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter paramstrProductCheckingID = new SqlParameter("@strProductCheckingID", SqlDbType.VarChar, 5000);
                        paramstrProductCheckingID.Value = cellValues;
                        command.Parameters.Add(paramstrProductCheckingID);

                        SqlParameter paramCurrentUSer = new SqlParameter("@CurrentUSer", SqlDbType.VarChar, 50);
                        paramCurrentUSer.Value = AppSetting.CurrentUser.LoginName.ToString();
                        command.Parameters.Add(paramCurrentUSer);

                        SqlParameter varDispatchingOrderID = new SqlParameter("@varDispatchingOrderID", SqlDbType.Int);
                        varDispatchingOrderID.Direction = ParameterDirection.Output;
                        command.Parameters.Add(varDispatchingOrderID);

                        connection.Open();
                        //var dataSoure = new DataTable();
                        //dataSoure.Load(command.ExecuteReader());
                        command.ExecuteNonQuery();
                        DO_ID = Convert.ToInt32(command.Parameters["@varDispatchingOrderID"].Value);
                        connection.Close();
                    }
                }

            }
            if (DO_ID != 0)
            {
                frm_WM_DispatchingOrders dispatchingOrder = frm_WM_DispatchingOrders.GetInstance(DO_ID);
                if (dispatchingOrder.Visible)
                {
                    dispatchingOrder.ReloadData();
                }
                dispatchingOrder.Show();
                dispatchingOrder.WindowState = FormWindowState.Maximized;
                dispatchingOrder.BringToFront();
            }
            else
                MessageBox.Show("Export DO is failed", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //DataProcess<object> dataProcess = new DataProcess<object>();
            //dataProcess.ExecuteNoQuery("STProductCheckingExportDO @strProductCheckingID = '"+ cellValues + "' , @CurrentUSer= '" + AppSetting.CurrentUser.LoginName.ToString() + "'");

        }

        private void btn_CreateMassMove_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Are you sure to create DO from the selected pallet(s) ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            string cellValues = "";
            int[] selectedRows = grvLocationDetails.GetSelectedRows();
            foreach (int rowHandle in selectedRows)
            {
                if (rowHandle >= 0)
                {
                    if (cellValues.Length > 0)
                        cellValues = cellValues + " , " + grvLocationDetails.GetRowCellValue(rowHandle, "PalletID").ToString();
                    else
                        cellValues = grvLocationDetails.GetRowCellValue(rowHandle, "PalletID").ToString();
                }
            }
            //choosenPallets = cellValues;

            //Excute Store to Export DO ,then get the DO id 
            int SMM_ID = 0;
            using (var context = new SwireDBEntities())
            {
                using (var connection = context.Database.Connection)
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "STStockMovementMassCreateFromPalletID";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter strPalletID = new SqlParameter("@strPalletID", SqlDbType.VarChar, 5000);
                        strPalletID.Value = cellValues;
                        command.Parameters.Add(strPalletID);

                        SqlParameter paramCurrentUSer = new SqlParameter("@CurrentUSer", SqlDbType.VarChar, 50);
                        paramCurrentUSer.Value = AppSetting.CurrentUser.LoginName.ToString();
                        command.Parameters.Add(paramCurrentUSer);

                        SqlParameter StockMovementMassID = new SqlParameter("@StockMovementMassID", SqlDbType.Int);
                        StockMovementMassID.Direction = ParameterDirection.Output;
                        command.Parameters.Add(StockMovementMassID);

                        connection.Open();
                        //var dataSoure = new DataTable();
                        //dataSoure.Load(command.ExecuteReader());
                        command.ExecuteNonQuery();
                        SMM_ID = Convert.ToInt32(command.Parameters["@StockMovementMassID"].Value);
                        connection.Close();
                    }
                }

            }
            if (SMM_ID != 0)
            {
                frm_ST_StockMovementMassAll SM = new frm_ST_StockMovementMassAll();
                SM.Show();
                SM.WindowState = FormWindowState.Maximized;
                SM.BringToFront();
            }
            else
                MessageBox.Show("Export To Stock Movement Mass is failed", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
    
}
