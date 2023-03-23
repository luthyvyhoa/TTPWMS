using Common.Controls;
using DA;
using System;
using UI.Helper;
using UI.ReportFile;
using UI.StockTake;
using System.Linq;
namespace UI.WarehouseManagement
{
    public partial class frm_WM_FreeLocations : frmBaseForm
    {
        public frm_WM_FreeLocations()
        {
            InitializeComponent();
        }

        private void frm_WM_FreeLocations_Load(object sender, EventArgs e)
        {
            DataProcess<object> da = new DataProcess<object>();
            int result = da.ExecuteNoQuery("STFreeLocationUpdateTable @varStoreID={0}", AppSetting.StoreID);
            this.grd_WM_LocationData.DataSource = FileProcess.LoadTable("Select tmpFreeLocations.*, CAST(QtyOfFree AS decimal(7,2))/CAST(QtyLocation AS decimal(7,2)) AS Occupancy from tmpFreeLocations where StoreID=" + AppSetting.StoreID);
        }

        /// <summary>
        /// Display view form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rpibtnView_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string roomId = this.grv_WM_LocationData.GetRowCellValue(this.grv_WM_LocationData.FocusedRowHandle, "RoomID").ToString();
            frm_WM_FreeLocationByRoom frm = new frm_WM_FreeLocationByRoom(roomId);
            frm.Show();
        }

        /// <summary>
        /// Display room
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rpibtnRoom_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string roomId = this.grv_WM_LocationData.GetRowCellValue(this.grv_WM_LocationData.FocusedRowHandle, "RoomID").ToString();
            frm_ST_StockOnHandByRoom frm = new frm_ST_StockOnHandByRoom(roomId);
            frm.Show();
        }

        private void grd_WM_LocationData_Click(object sender, EventArgs e)
        {

        }

        private void rpibtnPrint_Click(object sender, EventArgs e)
        {
            string roomId = this.grv_WM_LocationData.GetRowCellValue(this.grv_WM_LocationData.FocusedRowHandle, "RoomID").ToString();

            // Set predicate default is load data folow roomID selected
            var predicate = new System.Func<STFreeLocations_Result, bool>(x => x.RoomID == roomId);
            var dataSource = new DataProcess<STFreeLocations_Result>().Executing("STFreeLocations", true).Where(predicate).ToList();
            rptFreeLocationByRoom rpt = new rptFreeLocationByRoom(dataSource.Count);
            rpt.DataSource = dataSource;
            ReportPrintToolWMS printTool = new ReportPrintToolWMS(rpt);
            printTool.AutoShowParametersPanel = false;
            printTool.ShowPreviewDialog();
        }

        private void rpi_hpl_Room_Click(object sender, EventArgs e)
        {
            string roomId = this.grv_WM_LocationData.GetRowCellValue(this.grv_WM_LocationData.FocusedRowHandle, "RoomID").ToString();
            frm_ST_StockOnHandByRoom frm = new frm_ST_StockOnHandByRoom(roomId);
            frm.Show();
        }

        private void Rpi_Hpl_View_Click(object sender, EventArgs e)
        {
            string roomId = this.grv_WM_LocationData.GetRowCellValue(this.grv_WM_LocationData.FocusedRowHandle, "RoomID").ToString();
            frm_WM_FreeLocationByRoom frm = new frm_WM_FreeLocationByRoom(roomId);
            frm.Show();
        }

        private void Rpi_hpl_Print_Click(object sender, EventArgs e)
        {
            string roomId = this.grv_WM_LocationData.GetRowCellValue(this.grv_WM_LocationData.FocusedRowHandle, "RoomID").ToString();

            // Set predicate default is load data folow roomID selected
            var predicate = new System.Func<STFreeLocations_Result, bool>(x => x.RoomID == roomId);
            var dataSource = new DataProcess<STFreeLocations_Result>().Executing("STFreeLocations @Flag={0}, @varStoreID={1}", true, AppSetting.StoreID)
                .Where(predicate).ToList();
            rptFreeLocationByRoom rpt = new rptFreeLocationByRoom(dataSource.Count);
            rpt.DataSource = dataSource;
            ReportPrintToolWMS printTool = new ReportPrintToolWMS(rpt);
            printTool.AutoShowParametersPanel = false;
            printTool.ShowPreviewDialog();
        }

        private void grv_WM_LocationData_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            string roomID = Convert.ToString(grv_WM_LocationData.GetFocusedRowCellValue("RoomID"));
            var dataSource = new DataProcess<STFreeLocationsByRoom_Result>().Executing("STFreeLocationsByRoom @RoomID='" + roomID + "', @varStoreID=" + AppSetting.StoreID);
            this.grcFreeLocationByAisle.DataSource = dataSource;
            this.grcLostProductByRoom.DataSource = FileProcess.LoadTable("STLostProductByRoom " + AppSetting.StoreID.ToString() + ",'" + roomID + "'");


        }

        private void grvFreeLocationByAisleTableView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            switch (e.Column.FieldName)
            {
                case "AisleRemark":
                    int roomID = Convert.ToInt32(this.grvFreeLocationByAisleTableView.GetFocusedRowCellValue("AisleRoomID"));
                    string remark = Convert.ToString(this.grvFreeLocationByAisleTableView.GetFocusedRowCellValue("AisleRemark"));
                    FileProcess.LoadTable("Update Aisles Set AisleRemark=N'" + remark + "' where AisleRoomID='" + roomID + "'");
                    break;
                default:
                    break;
            }
        }

        private void rpi_hpl_FreeLocation_Click(object sender, EventArgs e)
        {
            string roomId = this.grv_WM_LocationData.GetRowCellValue(this.grv_WM_LocationData.FocusedRowHandle, "RoomID").ToString();
            int aisleID = Convert.ToInt32(this.grvFreeLocationByAisleTableView.GetRowCellValue(this.grvFreeLocationByAisleTableView.FocusedRowHandle, "Aisle"));
            frm_WM_FreeLocationByRoom frm = new frm_WM_FreeLocationByRoom(roomId, aisleID);
            frm.Show();
        }

        private void grv_WM_LocationData_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            switch (e.Column.FieldName)
            {
                case "RoomRemark":
                    string roomId = this.grv_WM_LocationData.GetRowCellValue(this.grv_WM_LocationData.FocusedRowHandle, "RoomID").ToString();
                    FileProcess.LoadTable("Update tmpFreeLocations Set RoomRemark=N'" + e.Value + "' where RoomID='" + roomId + "' and StoreID = " + AppSetting.StoreID);
                    break;
                default:
                    break;
            }
        }
    }
}
