using DA;
using DevExpress.XtraCharts;
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
using UI.StockTake;
using UI.Supperviors;

namespace UI.CRM
{
    public partial class frm_CRM_OperationSummary : Form 
    {
        //private urc_CRM_36MonthsOperation monthsOperation = null;
        public frm_CRM_OperationSummary()
        {
            InitializeComponent();
            DataProcess<Stores> storeDA = new DataProcess<Stores>();
            this.lke_MSS_StoreList.Properties.DataSource = storeDA.Select();
            this.lke_MSS_StoreList.Properties.ValueMember = "StoreID";
            this.lke_MSS_StoreList.Properties.DisplayMember = "StoreDescription";

            DataProcess<Warehouses> wDA = new DataProcess<Warehouses>();
            this.lke_Warehouse.Properties.DataSource = wDA.Select();
            this.lke_Warehouse.Properties.ValueMember = "WarehouseID";
            this.lke_Warehouse.Properties.DisplayMember = "WarehouseDescription";

            int storeID = AppSetting.StoreID;
            this.lke_MSS_StoreList.EditValue = AppSetting.StoreID;
            this.chartWarehouseOperation.DataSource = FileProcess.LoadTable("WebChartStockMovementAllCustomersDaily " + storeID);
            this.grcActiveCustomers.DataSource = FileProcess.LoadTable("WebStockOnHandWeeklyCustomerMain " + storeID);
            this.chartCrossDockOperation.DataSource = FileProcess.LoadTable("WebOperationSummaryCrossDock " + storeID);
            this.grcFreeLocation.DataSource = FileProcess.LoadTable("STFreeLocationByRoomSummary " + storeID);
            //this.text2WeeksChange.Properties.Mask.EditMask = "p";
            //this.text2WeeksChange.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            //this.text2WeeksChange.Properties.Mask.UseMaskAsDisplayFormat = true;

            this.textOccupancy.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.textPallets.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.text2WeeksChange.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.text30DaysChange.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.textBilledPallets.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.textEcoOcc.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);


            refreshTextboxes();
        }

        private void refreshTextboxes()
        {
            var storedata = FileProcess.LoadTable("WebSummaryOperationToday " + this.lke_MSS_StoreList.EditValue);
            if (storedata==null || storedata.Rows.Count<=0) return;
            this.textOccupancy.Text = Convert.ToString(storedata.Rows[0]["OccupationPercent"]);
            this.textPallets.Text = Convert.ToString(storedata.Rows[0]["TotalPallets"]);
            this.text2WeeksChange.Text = Convert.ToString(storedata.Rows[0]["PC14"]);
            this.text30DaysChange.Text = Convert.ToString(storedata.Rows[0]["PC30"]);
            this.textEcoOcc.Text = Convert.ToString(storedata.Rows[0]["EconomicOccupancy"]);
            this.textBilledPallets.Text = Convert.ToString(storedata.Rows[0]["BilledPallets"]);
        }

        private void rpe_hle_CustomerID_Click(object sender, EventArgs e)
        {
            int OperatingCostMonthlyID = AppSetting.LastOperationMonthID - 1;
            int StoreID = Convert.ToInt32(this.lke_MSS_StoreList.EditValue);
            int CustomerID = Convert.ToInt32(this.grvWarehouseOperation.GetFocusedRowCellValue("CustomerMainID".ToString()));


            // check if the USer is manager
            if (UI.Helper.UserPermission.CheckAdminDepartment(AppSetting.CurrentUser.LoginName))

            {
                frm_CRM_OperatingCostViewByCustomer frm = new frm_CRM_OperatingCostViewByCustomer(OperatingCostMonthlyID, StoreID, CustomerID);
                frm.Show();
                frm.WindowState = FormWindowState.Maximized;
            }
            else
            {
                int customerID = Convert.ToInt32(this.grvWarehouseOperation.GetFocusedRowCellValue("CustomerMainID"));
                int storeID = Convert.ToInt32(this.lke_MSS_StoreList.EditValue);
                string customerName = this.grvWarehouseOperation.GetFocusedRowCellValue("CustomerName").ToString();
                frm_S_CustomerStock36months2 frm = new frm_S_CustomerStock36months2(customerID, customerName, storeID);

                frm.Show();
                frm.WindowState = FormWindowState.Maximized;
            }
        }

        private void lke_MSS_StoreList_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            //if (e.Value == null) return;
            //int storeID = Convert.ToInt32(e.Value);
            //this.chartWarehouseOperation.DataSource = FileProcess.LoadTable("WebChartStockMovementAllCustomersDaily " + storeID);
            //this.grcActiveCustomers.DataSource = FileProcess.LoadTable("WebStockOnHandWeeklyCustomerMain " + storeID);
            //this.chartCrossDockOperation.DataSource = FileProcess.LoadTable("WebOperationSummaryCrossDock " + storeID);
            //this.grcFreeLocation.DataSource = FileProcess.LoadTable("Select tmpFreeLocations.*, CAST(QtyOfFree AS decimal(7,2))/CAST(QtyLocation AS decimal(7,2)) AS Occupancy from tmpFreeLocations where StoreID=" + storeID);
            //refreshTextboxes();
            this.check12Months.Checked = false;
        }

        private void rpi_hpl_Room_Click(object sender, EventArgs e)
        {
            string roomId = this.grv_WM_LocationData.GetRowCellValue(this.grv_WM_LocationData.FocusedRowHandle, "RoomID").ToString();
            frm_ST_StockOnHandByRoom frm = new frm_ST_StockOnHandByRoom(roomId, Convert.ToInt32(this.lke_MSS_StoreList.EditValue));
            frm.Show();
        }

        private void lke_MSS_StoreList_EditValueChanged(object sender, EventArgs e)
        {
            if (this.lke_MSS_StoreList.EditValue==null) return;
            int storeID = Convert.ToInt32(this.lke_MSS_StoreList.EditValue);
            this.chartWarehouseOperation.DataSource = FileProcess.LoadTable("WebChartStockMovementAllCustomersDaily " + storeID);
            this.grcActiveCustomers.DataSource = FileProcess.LoadTable("WebStockOnHandWeeklyCustomerMain " + storeID);
            this.chartCrossDockOperation.DataSource = FileProcess.LoadTable("WebOperationSummaryCrossDock " + storeID);
            this.grcFreeLocation.DataSource = FileProcess.LoadTable("STFreeLocationByRoomSummary " + storeID);
            refreshTextboxes();
        }

        private void rpe_hle_CustomerID2_Click(object sender, EventArgs e)
        {
            int customerID = Convert.ToInt32(this.grvWarehouseOperation.GetFocusedRowCellValue("CustomerMainID"));
            int storeID = Convert.ToInt32(this.lke_MSS_StoreList.EditValue);
            string customerName = this.grvWarehouseOperation.GetFocusedRowCellValue("CustomerName").ToString();
            frm_S_CustomerStock36months2 frm = new frm_S_CustomerStock36months2(customerID, customerName, storeID);
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;

        }

        private void grvWarehouseOperation_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            this.popupMenuCustomers.ShowPopup(Control.MousePosition);
        }

        private void bbtn_ShowCustomerChart_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //select all the selected customers
            StringBuilder customerList = new StringBuilder();
            int count = 0;
            
                foreach (int rowIndex in this.grvWarehouseOperation.GetSelectedRows())
                {
                    customerList.Append(this.grvWarehouseOperation.GetRowCellValue(rowIndex, "CustomerMainID"));
                    if (count < this.grvWarehouseOperation.SelectedRowsCount - 1)
                    {
                        customerList.Append(",");
                        count++;
                    }
                }
            int storeID = Convert.ToInt32(this.lke_MSS_StoreList.EditValue);
            
            //this.chartWarehouseOperation.DataSource = FileProcess.LoadTable("WebChartStockMovementSelectedCustomersDaily '" + customerList + "'," + storeID);

            Form form = new Form();
            form.Text = "SELECTED CUSTOMERS COMPARISION CHART";
            DataTable cd = FileProcess.LoadTable("WebChartStockMovementSelectedCustomersDaily '" + customerList + "'," + storeID);
            
            ChartControl chart = new ChartControl();
            chart.Parent = form;
            chart.Dock = DockStyle.Fill;

            Series serieAllCustomers = new Series("AllCustomers", ViewType.Line);
            chart.Series.Add(serieAllCustomers);
            serieAllCustomers.DataSource = cd;
            serieAllCustomers.ArgumentScaleType = ScaleType.DateTime;
            serieAllCustomers.ArgumentDataMember = "DateR";
            serieAllCustomers.ValueScaleType = ScaleType.Numerical;
            serieAllCustomers.ValueDataMembers.AddRange(new string[] { "StockP" });

            Series serieSelectedCustomers = new Series("SelectedCustomers", ViewType.Line);
            chart.Series.Add(serieSelectedCustomers);
            serieSelectedCustomers.DataSource = cd;
            serieSelectedCustomers.ArgumentScaleType = ScaleType.DateTime;
            serieSelectedCustomers.ArgumentDataMember = "DateR";
            serieSelectedCustomers.ValueScaleType = ScaleType.Numerical;
            serieSelectedCustomers.ValueDataMembers.AddRange(new string[] { "StockW" });
            chart.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Left;
            chart.Legend.AlignmentVertical = LegendAlignmentVertical.Top;
            form.Bounds = new Rectangle(100, 100, 1400, 800);
            form.ShowDialog();
            form.Dispose();

        }


        private void rpe_hle_MonthChart_Click(object sender, EventArgs e)
        {
            int storeID = Convert.ToInt32(this.lke_MSS_StoreList.EditValue);
            this.chartWarehouseOperation.DataSource = FileProcess.LoadTable("WebChartStockMovementSelectedCustomersDaily '" + this.grvWarehouseOperation.GetFocusedRowCellValue("CustomerMainID") + "'," + storeID );
        }

        private void check12Months_CheckedChanged(object sender, EventArgs e)
        {
            if (this.lke_MSS_StoreList.EditValue == null) return;
            int storeID = Convert.ToInt32(this.lke_MSS_StoreList.EditValue);
            //this.chartWarehouseOperation.DataSource = FileProcess.LoadTable("WebChartStockMovementAllCustomersDaily " + storeID);
            if (this.check12Months.Checked)
            {
                //this.lc_CrossDock.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                this.lc_CustomerList.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                this.lc_FreeLocations.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                this.chartWarehouseOperation.DataSource = FileProcess.LoadTable("WebChartStockMovementAllCustomersDaily " + storeID + ",1");
                this.chartCrossDockOperation.DataSource = FileProcess.LoadTable("WebOperationSummaryCrossDock " + storeID + ",1");
            }
                
            else
            {
                //this.lc_CrossDock.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                this.lc_CustomerList.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                this.lc_FreeLocations.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                this.chartWarehouseOperation.DataSource = FileProcess.LoadTable("WebChartStockMovementAllCustomersDaily " + storeID);
                this.chartCrossDockOperation.DataSource = FileProcess.LoadTable("WebOperationSummaryCrossDock " + storeID);
            }
                

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (this.lke_MSS_StoreList.EditValue == null) return;
            int storeID = Convert.ToInt32(this.lke_MSS_StoreList.EditValue);
            this.chartWarehouseOperation.DataSource = FileProcess.LoadTable("WebChartStockMovementAllCustomersDaily " + storeID);
            this.grcActiveCustomers.DataSource = FileProcess.LoadTable("WebStockOnHandWeeklyCustomerMain " + storeID);
            this.chartCrossDockOperation.DataSource = FileProcess.LoadTable("WebOperationSummaryCrossDock " + storeID);
            this.grcFreeLocation.DataSource = FileProcess.LoadTable("STFreeLocationByRoomSummary " + storeID);
            refreshTextboxes();
        }

        private void bbtn_ShowNotSelectedCustomerChart_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //select all the selected customers
            StringBuilder customerList = new StringBuilder();
            int count = 0;

            foreach (int rowIndex in this.grvWarehouseOperation.GetSelectedRows())
            {
                customerList.Append(this.grvWarehouseOperation.GetRowCellValue(rowIndex, "CustomerMainID"));
                if (count < this.grvWarehouseOperation.SelectedRowsCount - 1)
                {
                    customerList.Append(",");
                    count++;
                }
            }
            int storeID = Convert.ToInt32(this.lke_MSS_StoreList.EditValue);
            this.chartWarehouseOperation.DataSource = FileProcess.LoadTable("WebChartStockMovementNotSelectedCustomersDaily '" + customerList + "'," + storeID);
        }

        private void lke_Warehouse_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {

        }

        private void lke_Warehouse_EditValueChanged(object sender, EventArgs e)
        {
            if (this.lke_Warehouse.EditValue == null) return;
            this.lc_CustomerList.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            this.lc_FreeLocations.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            //this.chartWarehouseOperation.Series.series10.Name = "Dispatch";
            this.chartWarehouseOperation.DataSource = FileProcess.LoadTable("WebChartStockMovementWarehouse " + this.lke_Warehouse.EditValue);
        }

        private void textBilledPallets_DoubleClick(object sender, EventArgs e)
        {
            frm_CRM_ContractCommitments fc = new frm_CRM_ContractCommitments();
            fc.Show();
            fc.BringToFront();

        }
    }
}
