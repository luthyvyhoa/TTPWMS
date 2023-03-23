using System;
using System.Linq;
using System.Windows.Forms;
using Common.Controls;
using UI.APIs;
using DA;
using DA.API;
using UI.Helper;
using UI.APIs.ParamPost;
using System.Configuration;
using DA.Warehouse;
using RestSharp.Contrib;
using System.IO;

namespace UI.WarehouseManagement
{
    public partial class frm_T_VehicleJourneys : frmBaseForm
    {
        private string vehicleNumber = string.Empty;
        private APIProcess api = null;
        private const string URL = "https://api.giamsathanhtrinh.vn/";
        private readonly string urlLogin = "api/Users/Login?UserName={0}&Password={1}&grant_type=password";
        private readonly string urlJourney = "api/anvita/listcarsignalbyplate?CarPlate={0}&FromTime={1}&ToTime={2}";
        private const string urlParameters = "";
        private string token = string.Empty;
        private int userID = 0;
        private DataProcess<Truck> truckDA = new DataProcess<Truck>();
        private DataProcess<TruckOnRoadData> truckOnLoadDA = new DataProcess<TruckOnRoadData>();

        public frm_T_VehicleJourneys(string vehicleNumber, string onRoadStartTime = null, string onRoadEndTime = null)
        {
            InitializeComponent();
            this.Enabled = true;
            this.vehicleNumber = vehicleNumber;
            this.txtVehicleNumber.Text = vehicleNumber;
            if (onRoadStartTime == null || onRoadEndTime == null)
            {
                this.dFrom.DateTime = DateTime.Now.AddDays(-1);
                this.dTo.DateTime = DateTime.Now;
            }
            this.dFrom.DateTime = Convert.ToDateTime(onRoadStartTime);
            this.dTo.DateTime = Convert.ToDateTime(onRoadEndTime);

            //refreshgridVehicleList(true);
            // Check registration current API
            Truck currentTruck = this.CheckRegistrationAPI();
            if (currentTruck != null)
            {
                this.InitAPI(currentTruck.UserName, currentTruck.Passwords);
                this.GetJourneyList();
            }
        }

        public frm_T_VehicleJourneys()
        {
            InitializeComponent();
            this.Enabled = true;

            this.dFrom.DateTime = DateTime.Now.AddDays(-1);
            this.dTo.DateTime = DateTime.Now;

            refreshgridVehicleList(true);

        }

        private Truck CheckRegistrationAPI()
        {
            return this.truckDA.Select(t => t.TruckNumber.ToUpper() == this.vehicleNumber.ToUpper()).FirstOrDefault();
        }


        private void InitAPI(string userName, string passwords)
        {
            this.api = new APIProcess(URL, userName, passwords, APITypeEnum.VCOMSAT);
            this.token = this.api.Token;
            string urlJoin = string.Format(this.urlLogin, userName, passwords);
            var currentUser = APIConverter.ConvertJsonToObject<UserInfo>(this.api.Get(urlJoin, string.Empty));
            if (currentUser != null) this.userID = currentUser.UserID;
        }

        private void GetJourneyList()
        {
            string urlJoin = string.Format(this.urlJourney, this.vehicleNumber, this.dFrom.DateTime, this.dTo.DateTime);
            var dataJourney = this.api.Get(urlJoin, string.Empty);
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnViewMaps_Click(object sender, EventArgs e)
        {
            if (dFrom.EditValue == null || dTo.EditValue == null || string.IsNullOrEmpty(this.txtVehicleNumber.Text))
            {
                MessageBox.Show("Data input is invalid.", "WMS-2017", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            viewMap(this.txtVehicleNumber.Text, this.dFrom.DateTime, this.dTo.DateTime);
        }

        private void viewMap(string vehicleNumber, DateTime fromDate, DateTime toDate)
        {
            string url = "https://tn_wms.vn:688/TruckMaps.aspx?VehicleNumber={0}&FromDate={1}&ToDate={2}&IsTemp={3}";
            string urlCombine = string.Format(url, HttpUtility.HtmlEncode(this.txtVehicleNumber.Text),
                HttpUtility.HtmlEncode(fromDate.ToString("yyyy-MM-dd HH:mm")),
                HttpUtility.HtmlEncode(toDate.ToString("yyyy-MM-dd HH:mm")),
                 HttpUtility.HtmlEncode(checkTempData.Checked.ToString()));
            System.Diagnostics.Process.Start(urlCombine);
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            //First check if the data is already retrieved fro mWeb Service


            //Code here to call the Web Service and get the Data

            string url = ConfigurationManager.AppSettings["URL_LAService"];
            ParamInput paramInput = new ParamInput();
            paramInput.StartTime = dFrom.DateTime.ToString("yyyy-MM-ddTHH:mm:00");
            paramInput.EndTime = dTo.DateTime.ToString("yyyy-MM-ddTHH:mm:00");
            paramInput.CarNumber = txtVehicleNumber.Text.ToUpper();
            paramInput.CreatedBy = AppSetting.CurrentUser.LoginName;

            // Find provider and user,pass
            TransportDBContext transportDBContext = new TransportDBContext();
            var vehicleInfo = transportDBContext.GetData("Select * from Vehicles Where VehiclePlate='" + this.txtVehicleNumber.Text + "'");
            if (vehicleInfo == null || vehicleInfo.Rows.Count <= 0)
            {
                MessageBox.Show("Vehicle Plate is not exist it systems!", "WMS-2017", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string providerName = Convert.ToString(vehicleInfo.Rows[0]["GPSProviderName"]);
            string userName = Convert.ToString(vehicleInfo.Rows[0]["GPSAccountUserName"]);
            string pass = Convert.ToString(vehicleInfo.Rows[0]["GPSAccountPassword"]);
            if (string.IsNullOrEmpty(providerName) || string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Provider info is invalid!", "WMS-2017", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            paramInput.ProviderName = providerName.ToUpper();

            APIProcess aPIProcess = new APIProcess(url, "", "");
            var respondData = aPIProcess.Post(url, paramInput);
            int count = Convert.ToInt32(respondData.Result);
            if (count > 0)
            {
                //Load data
                grdVehicleInfo.DataSource = transportDBContext.GetData("Select * from tmpTransportDatas Where CarPlate='" +
                this.txtVehicleNumber.Text + "' And ReportDateTime BETWEEN '" + this.dFrom.DateTime.ToString("yyyy-MM-dd hh:mm") + "' and '" + this.dTo.DateTime.ToString("yyyy-MM-dd hh:mm") + "'");
            }
            else
            {
                MessageBox.Show("Get data is fail!", "WMS-2017", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //Load data
            refreshgridVehicleList(this.checkTempData.Checked);

        }
        private void refreshgridtempData()
        {
            string strSQL = "";
            if (this.checkTempData.Checked)
            {
                //Load from temp table
                strSQL = "ST_WMS_LoadVehicleGPSTempData 0,'" +
                    this.grvAvailableTruckData.GetFocusedRowCellValue("CarPlate") + "','" +
                    this.grvAvailableTruckData.GetFocusedRowCellDisplayText("CreatedTime") + "'";

            }
            else //Load from permanent table
            {
                strSQL = "ST_WMS_LoadVehicleGPSTempData 1,'" +
                    this.grvAvailableTruckData.GetFocusedRowCellValue("CarPlate") + "','" +
                    this.grvAvailableTruckData.GetFocusedRowCellDisplayText("CreatedTime") + "'";
            }

            this.grdVehicleInfo.DataSource = FileProcess.LoadTable(strSQL);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (this.checkTempData.Checked)  // this button only works for moving temp data to permanent data
            {
                string sqlstr = "SPTransportGeoTempDataInsert '" +
                  this.grvAvailableTruckData.GetFocusedRowCellDisplayText("CarPlate") + "','" +
                  this.grvAvailableTruckData.GetFocusedRowCellDisplayText("CreatedTime") + "','" + AppSetting.CurrentUser.LoginName + "'";
                truckDA.ExecuteNoQuery(sqlstr);
                refreshgridVehicleList(true);
                this.grdVehicleInfo.DataSource = null;
            }

        }
        private void refreshgridVehicleList(Boolean isPermanentData)
        {
            if (!isPermanentData)  // temp data
            {
                this.grcAvailabletruckData.DataSource = FileProcess.LoadTable("ST_WMS_LoadVehicleListGPSTempData 0");

            }

            else  //permanent
            {
                this.grcAvailabletruckData.DataSource = FileProcess.LoadTable("ST_WMS_LoadVehicleListGPSTempData 1,'" +
                        this.dFrom.DateTime.ToString("yyyy-MM-dd HH:mm") + "','" + this.dTo.DateTime.ToString("yyyy-MM-dd HH:mm") + "'");
            }
        }

        private void checkTempData_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkTempData.Checked)  //View temporary data vehicle list
            {
                refreshgridVehicleList(false);
                this.loc_VehicleList.Text = "List of Available Vehicle Temporary Data ";
            }
            else  // Show available vehicle list in permanent data
            {
                refreshgridVehicleList(true);
                this.loc_VehicleList.Text = "List of Vehicle Temporary Data Permanently Stored ";
            }
        }

        private void grvAvailableTruckData_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            refreshgridtempData();
        }

        private void btnImportFile_Click(object sender, EventArgs e)
        {
            string desFile = "\\\\195.184.11.244\\AccellosData$\\TemperatureForImport.xlsx";
            File.Copy(this.textFilePath.Text, desFile, true);

            int result = truckDA.ExecuteNoQuery("STTransportDataImportExcel '" + AppSetting.CurrentUser.LoginName + "'");

            if (result > 0)
            {
                MessageBox.Show("Successfully Imported GPS and Temperature Data !", "WMS-2017", MessageBoxButtons.OK, MessageBoxIcon.Information);
                refreshgridVehicleList(false);
            }

        }

        private void textFilePath_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Excel File|*.xls||*.xlsx";
            //of.Filter = "Excel File|*.xls";
            of.Title = "WMS - Please select a Excel file to import";
            of.Multiselect = false;
            of.RestoreDirectory = true;
            // of.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            if (of.ShowDialog() == DialogResult.OK)
            {
                this.textFilePath.Text = of.FileName;

                //DataTable v_TableSheet = this.GetTableExcelSheetNames(of.FileName);
                //lkUEdit_Sheet.Properties.DataSource = v_TableSheet;
                //lkUEdit_Sheet.Properties.DisplayMember = "Name";
                //lkUEdit_Sheet.Properties.ValueMember = "Name";

                //string v_sheetName = "";
                //try
                //{
                //    v_sheetName = Convert.ToString(v_TableSheet.Rows[0]["Name"]);
                //    lkUEdit_Sheet.EditValue = v_sheetName;
                //}
                //catch { }
            }
        }
    }
}
