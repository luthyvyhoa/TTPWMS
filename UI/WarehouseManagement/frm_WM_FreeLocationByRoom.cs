using Common.Controls;
using DA;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UI.Helper;
using UI.ReportFile;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_FreeLocationByRoom : frmBaseForm
    {
        private string roomIDSelected = string.Empty;
        private int aisleSelected = 0;
        private IEnumerable<STFreeLocations_Result> resource = null;
        public frm_WM_FreeLocationByRoom(string roomID, int aisle = 0)
        {
            InitializeComponent();
            this.roomIDSelected = roomID;
            this.aisleSelected = aisle;
        }

        private void frm_WM_FreeLocationByRoom_Load(object sender, System.EventArgs e)
        {
            this.rad_WM_FLBR_All.Checked = true;
        }

        private void rad_WM_FLBR_All_CheckedChanged(object sender, System.EventArgs e)
        {
            // Get radio control is doing click
            var rad = (System.Windows.Forms.RadioButton)sender;
            bool isLoadFree = false;

            System.Func<STFreeLocations_Result, bool> predicate = null;

            // Set predicate default is load data folow roomID selected
            if (this.aisleSelected == 0)
            {
                // Load all location free by roomID
                predicate = new System.Func<STFreeLocations_Result, bool>(x => x.RoomID == this.roomIDSelected);
            }
            else
            {
                // Load all location free by roomID and aisle selected
                predicate = new System.Func<STFreeLocations_Result, bool>(x => x.RoomID == this.roomIDSelected && x.Aisle == this.aisleSelected);
            }

            // Detect current action
            switch (rad.Name)
            {
                case "rad_WM_FLBR_Low":
                    predicate = new System.Func<STFreeLocations_Result, bool>(
                        x => x.RoomID == this.roomIDSelected && x.Low && !x.VeryLowHigh);
                    break;

                case "rad_WM_FLBR_VeryLow":
                    predicate = new System.Func<STFreeLocations_Result, bool>(
                        x => x.RoomID == this.roomIDSelected && x.Low && x.VeryLowHigh);
                    break;

                case "rad_WM_FLBR_High":
                    predicate = new System.Func<STFreeLocations_Result, bool>(
                        x => x.RoomID == this.roomIDSelected && !x.Low && !x.VeryLowHigh);
                    break;

                case "rad_WM_FLBR_VeryHigh":
                    predicate = new System.Func<STFreeLocations_Result, bool>(
                        x => x.RoomID == this.roomIDSelected && !x.Low && x.VeryLowHigh);
                    break;
                case "rad_WM_FLBR_Free":
                    isLoadFree = true;
                    predicate = new System.Func<STFreeLocations_Result, bool>(
                        x => x.RoomID == this.roomIDSelected);
                    break;
            }

            if (isLoadFree)
            {
                this.resource = new DataProcess<STFreeLocations_Result>()
                       .Executing("STFreeLocations @Flag={0}, @varStoreID={1}", null, AppSetting.StoreID)
                       .Where(predicate);
               
            }
            else
            {
                this.resource = new DataProcess<STFreeLocations_Result>()
                       .Executing("STFreeLocations @Flag={0}, @varStoreID={1}", true, AppSetting.StoreID)
                       .Where(predicate);
            }
            this.grd_WM_LocationDataByRoom.DataSource = this.resource;
        }

        private void btn_WM_PrintList_ItemDoubleClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btn_Print_List_Free_Location_Click(object sender, System.EventArgs e)
        {
            if (this.resource == null) return;
            System.Func<STFreeLocations_Result, bool> predicate = null;
            rptFreeLocationByRoom rpt = new rptFreeLocationByRoom(this.resource.Count());
            rpt.DataSource = this.resource;
            ReportPrintToolWMS printTool = new ReportPrintToolWMS(rpt);
            printTool.AutoShowParametersPanel = false;
            printTool.ShowPreviewDialog();
        }
    }
}
