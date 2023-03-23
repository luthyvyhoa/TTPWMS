using System.Windows.Forms;
using Common.Controls;
using System.Data.Entity;
using DA;
using System;
using UI.Helper;
using System.Collections.Generic;
using Common.Process;
using System.Text;
using System.Threading.Tasks;
using UI.ReportFile;
using DevExpress.XtraReports.UI;
using System.Linq;
using System.ComponentModel;
using System.Drawing;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_BusinessTrips : frmBaseForm
    {
        private bool isLoad;
        private string currentQuery = string.Empty;
        private DataProcess<ST_WMS_LoadBussinessTrips_Result> bussinessTripsDA = new DataProcess<ST_WMS_LoadBussinessTrips_Result>();
        private BindingList<ST_WMS_LoadBussinessTrips_Result> listData = null;
        private int rowhandle = 0;
        public frm_WM_BusinessTrips()
        {
            // Init controls to designer
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the frm_WM_BusinessTrips control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void frm_WM_BusinessTrips_Load(object sender, EventArgs e)
        {
            // Start wait form to prepare load data
            Wait.Start(this);

            // Load Category
            this.LoadDeepData();

            // Load data init
            this.LoadBussinessTrips();

            // Load department
            this.LoadDepartment();

            // Start wait form to prepare load data
            Wait.Close();
        }

        /// <summary>
        /// Load bussiness trip data
        /// </summary>
        private void LoadBussinessTrips()
        {
            // Init default value for control
            this.isLoad = true; // set flag to indicate that Form is Loading Data...
            this.d_WM_To.DateTime = DateTime.Now;
            this.d_WM_From.DateTime = DateTime.Now.AddDays(-2);
            int index = 0;
            var dataSource = bussinessTripsDA.Executing("ST_WMS_LoadBussinessTrips @LoginName={0}", AppSetting.CurrentUser.LoginName).OrderBy(b => b.StartTime).ToList();
            this.listData = new BindingList<ST_WMS_LoadBussinessTrips_Result>(dataSource);
            this.grdBussinessTrip.DataSource = listData;
            this.listData.AddNew();

            // Notify message to remind user
            if (index > 0)
            {
                StringBuilder msgContent = new StringBuilder();
                msgContent.Append("Hello ");
                msgContent.Append(AppSetting.CurrentUser.LoginName);
                msgContent.Append(Environment.NewLine);
                msgContent.Append("You have ");
                msgContent.Append(index);
                msgContent.Append(" Business Trip not confirmed!");
                msgContent.Append(Environment.NewLine);
                msgContent.Append("Please confirm your business Trip!");
                MessageBox.Show(msgContent.ToString(), "WMS-Business Trips", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.isLoad = false;
            // Set SelectedIndex to first index after load data => Not missing data while event fired
            this.radg_WM_Groups.SelectedIndex = 0;
            this.radg_WM_Personal.SelectedIndex = 0;
        }

        private void LoadDeepData()
        {
            using (var dataSource = new System.Data.DataTable())
            {
                dataSource.Columns.Add("BusinessTripCategory", typeof(string));
                var rmsRow = dataSource.NewRow();
                rmsRow["BusinessTripCategory"] = "RMS";
                var washouseRow = dataSource.NewRow();
                washouseRow["BusinessTripCategory"] = "Warehouse";
                dataSource.Rows.Add(rmsRow);
                dataSource.Rows.Add(washouseRow);

                this.pri_lke_BussinessTripCategory.DataSource = dataSource;
                this.pri_lke_BussinessTripCategory.DisplayMember = "BusinessTripCategory";
                this.pri_lke_BussinessTripCategory.ValueMember = "BusinessTripCategory";
            }
        }

        /// <summary>
        /// Load department data
        /// </summary>
        private void LoadDepartment()
        {
            DataProcess<STcomboDepartmentID_Result> departmentDA = new DataProcess<STcomboDepartmentID_Result>();
            this.lke_WM_Department.Properties.DataSource = departmentDA.Executing("STcomboDepartmentID");
            this.lke_WM_Department.Properties.ValueMember = "DepartmentID";
            this.lke_WM_Department.Properties.DisplayMember = "DepartmentNameShort";
        }

        /// <summary>
        /// Handles the Click event of the btn_WM_Close control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btn_WM_Close_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btn_WM_ViewReport_Click(object sender, System.EventArgs e)
        {
            rptBusinessTrips rpt = new rptBusinessTrips();
            //rpt.Parameters["loginName"].Value = AppSetting.CurrentUser.LoginName;
            //rpt.Parameters["EmployeeName"].Value = "dfdfdf hhh";
            if (this.lke_WM_Department.EditValue == null)
            {
                rpt.DataSource = FileProcess.LoadTable(string.Format("STBusinessTripReport @varFromDate='{0}',@varToDate='{1}',@varStoreID={2}",
                    this.d_WM_From.DateTime.ToString("yyyy-MM-dd"), this.d_WM_To.DateTime.ToString("yyyy-MM-dd"), AppSetting.StoreID));
            }
            else
            {
                rpt.DataSource = FileProcess.LoadTable(string.Format("STBusinessTripReport @varFromDate='{0}',@varToDate='{1}',@varDepartmentID={2},@varStoreID={3}",
                    this.d_WM_From.DateTime.ToString("yyyy-MM-dd"), this.d_WM_To.DateTime.ToString("yyyy-MM-dd"), (int)this.lke_WM_Department.EditValue, AppSetting.StoreID));
            }

            ReportPrintToolWMS printTool = new ReportPrintToolWMS(rpt);
            printTool.AutoShowParametersPanel = false;
            printTool.ShowPreviewDialog();
        }

        private void btn_WM_PriceEntrys_Click(object sender, System.EventArgs e)
        {
            frm_WM_BusinessTripPrice businessTripPrice = new frm_WM_BusinessTripPrice();
            businessTripPrice.Show();
        }

        private void radg_WM_Groups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.isLoad) return;
            this.lke_WM_Department.Enabled = false;
            switch (this.radg_WM_Groups.SelectedIndex)
            {
                case 0:
                    try
                    {
                        if (this.lke_WM_Department.EditValue == null) return;
                        Wait.Start(this);

                        this.currentQuery = "SELECT BusinessTrips.* " +
                                       " FROM BusinessTrips INNER JOIN Employees ON BusinessTrips.EmployeeID = Employees.EmployeeID " +
                                       " WHERE BusinessTrips.StartTime between '" + this.d_WM_From.DateTime.ToString("yyyy-MM-dd") + "' and '" + this.d_WM_To.DateTime.ToString("yyyy-MM-dd") + "'" +
                                       " ORDER BY BusinessTrips.StartTime";
                        listData = new BindingList<ST_WMS_LoadBussinessTrips_Result>(bussinessTripsDA.Executing(this.currentQuery).ToList());
                        this.grdBussinessTrip.DataSource = listData;
                        Wait.Close();
                    }
                    catch (Exception)
                    {
                        Wait.Close();
                    }
                    break;

                // Display department list
                case 1:
                    this.lke_WM_Department.Enabled = true;
                    this.lke_WM_Department.ShowPopup();
                    break;
                default:
                    break;
            }
        }

        private void lke_WM_Department_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (isLoad) return;
                if (this.lke_WM_Department.EditValue == null) return;
                Wait.Start(this);

                this.currentQuery = "SELECT BusinessTrips.* " +
                               " FROM BusinessTrips INNER JOIN Employees ON BusinessTrips.EmployeeID = Employees.EmployeeID " +
                               " WHERE BusinessTrips.StartTime between '" + this.d_WM_From.DateTime.ToString("yyyy-MM-dd") + "' and '" + this.d_WM_To.DateTime.ToString("yyyy-MM-dd") + "' AND Employees.Department =" + (int)this.lke_WM_Department.EditValue +
                               " ORDER BY BusinessTrips.StartTime";
                this.listData = new BindingList<ST_WMS_LoadBussinessTrips_Result>(bussinessTripsDA.Executing(this.currentQuery).ToList());
                this.grdBussinessTrip.DataSource = listData;
                Wait.Close();
            }
            catch (Exception)
            {
                Wait.Close();
            }
        }

        private void radg_WM_Personal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.isLoad) return;
            Wait.Start(this);
            var querySQL = this.DefineBussinessTripSQLQuery(this.radg_WM_Personal.SelectedIndex);
            this.currentQuery = querySQL.ToString();
            this.listData = new BindingList<ST_WMS_LoadBussinessTrips_Result>(bussinessTripsDA.Executing(this.currentQuery).ToList());
            this.grdBussinessTrip.DataSource = listData;

            switch (this.radg_WM_Personal.SelectedIndex) // When click on MySelf,MyUnconfirm => Add new row for User adding new trip
            {
                case 0:
                case 1:
                case 2:
                    this.listData.AddNew();
                    break;

                default:
                    break;
            }

            Wait.Close();
        }

        private void adv_grv_BussinessTrip_CustomDrawFooterCell(object sender, DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs e)
        {
            e.Appearance.DrawString(e.Cache, e.Info.DisplayText, e.Bounds);
            e.Handled = true;
        }

        private void adv_grv_BussinessTrip_CustomDrawColumnHeader(object sender, DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs e)
        {
            //if (e.Column == null) return;
            //switch (e.Column.FieldName)
            //{
            //    case "WhereTo":
            //    case "Purpose":
            //    case "BusinessTripCategory":
            //        e.Info.Caption = string.Empty;
            //        break;
            //    default:
            //        e.Info.Caption = e.Info.Caption.ToUpper();
            //        break;
            //}

        }

        private void rpi_btn_Delete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            bool confirmed = Convert.ToBoolean(this.adv_grv_BussinessTrip.GetFocusedRowCellValue("TripConfirmed"));
            if (confirmed) return;
            int tripID = Convert.ToInt32(this.adv_grv_BussinessTrip.GetFocusedRowCellValue("BusinessTripID"));
            DataProcess<BusinessTrips> bussinessTripDA = new DataProcess<BusinessTrips>();
            int deleteResult = bussinessTripDA.ExecuteNoQuery(" DELETE BusinessTrips WHERE BusinessTripID=" + tripID);
            this.listData = new BindingList<ST_WMS_LoadBussinessTrips_Result>(this.bussinessTripsDA.Executing(this.currentQuery).ToList());
            this.grdBussinessTrip.DataSource = listData;
        }

        private void rpi_btn_Confirm_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int tripID = Convert.ToInt32(this.adv_grv_BussinessTrip.GetFocusedRowCellValue("BusinessTripID"));
            string purpose = Convert.ToString(this.adv_grv_BussinessTrip.GetFocusedRowCellValue("Purpose"));
            string authorised = Convert.ToString(this.adv_grv_BussinessTrip.GetFocusedRowCellValue("AuthorisedNameBy"));
            this.rowhandle = this.adv_grv_BussinessTrip.FocusedRowHandle;

            // Validate reason to confirm
            if (string.IsNullOrEmpty(purpose))
            {
                MessageBox.Show("Please enter the reason for the trip !", "Plant Records", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate user permission , just only user is Suppervior or Manager then must can confirm
            // confirm 
            DataProcess<BusinessTrips> bussinessTripDA = new DataProcess<BusinessTrips>();
            var currentTripUpdate = bussinessTripDA.Select(t => t.BusinessTripID == tripID).FirstOrDefault();
            if (currentTripUpdate == null)
            {
                return;
            }

            if (!currentTripUpdate.TripConfirmed) // trip already confirm => not need re-confirm
            {
                currentTripUpdate.TripConfirmed = true;
                currentTripUpdate.AuthorisedNameBy = authorised + " ; Confirmed by " + AppSetting.CurrentUser.LoginName + " - " + DateTime.Now.ToString("dd/MM hh:mm");
                currentTripUpdate.AuthorisedCreated = AppSetting.CurrentUser.LoginName;
                var updateResult = bussinessTripDA.Update(currentTripUpdate);
                if (updateResult == -2)
                {
                    MessageBox.Show("Cannot confirm trip, please see log for more detail(s) !", "Bussiness Trips", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (string.IsNullOrEmpty(this.currentQuery) || string.IsNullOrWhiteSpace(this.currentQuery))
            {
                // Re-update SQL query
                this.currentQuery = this.DefineBussinessTripSQLQuery(this.radg_WM_Personal.SelectedIndex);
            }

            var listBussinessTrips = this.bussinessTripsDA.Executing(this.currentQuery)?.OrderBy(b => b.StartTime)?.ToList();
            this.listData = new BindingList<ST_WMS_LoadBussinessTrips_Result>(listBussinessTrips);
            this.grdBussinessTrip.DataSource = listData;
            this.adv_grv_BussinessTrip.FocusedRowHandle = this.rowhandle;
            this.adv_grv_BussinessTrip.SelectRow(this.rowhandle);
        }

        private void adv_grv_BussinessTrip_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            switch (e.Column.FieldName)
            {
                case "PhoneUsed":
                    int valueInput = Convert.ToInt32(e.Value);
                    if (valueInput < 0 || valueInput > 6)
                    {
                        MessageBox.Show("Phone is invalid", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    break;

                case "EmployeeID":
                    if (string.IsNullOrEmpty(Convert.ToString(e.Value)))
                    {
                        MessageBox.Show("This EmployeeID invalid, Enter again, please !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    int employeeID = Convert.ToInt32(e.Value);
                    DataProcess<Employees> dataProcess = new DataProcess<Employees>();
                    var employeeInfo = dataProcess.Select(em => em.EmployeeID == employeeID).FirstOrDefault();
                    if (employeeInfo != null)
                    {
                        this.listData[e.RowHandle].EmployeeName = employeeInfo.FullName;
                        this.listData[e.RowHandle].StartTime = DateTime.Now;
                        this.listData[e.RowHandle].Endtime = DateTime.Now.AddHours(1);
                        this.listData[e.RowHandle].AuthorisedNameBy = "Created :" + AppSetting.CurrentUser.LoginName + " - " + DateTime.Now.ToString("dd/MM hh:mm");
                    }
                    else
                    {
                        return;
                    }

                    break;

                case "BikeMilage":
                    int bikeMile = Convert.ToInt32(this.adv_grv_BussinessTrip.GetFocusedRowCellValue("BikeMilage"));
                    if (bikeMile > 0)
                    {
                        this.listData[e.RowHandle].BikeUse = true;
                    }
                    break;

                case "ParkingPrice":
                    decimal price = Convert.ToDecimal(this.adv_grv_BussinessTrip.GetFocusedRowCellValue("ParkingPrice"));
                    if (price < 1000 || price > 100000)
                    {
                        MessageBox.Show("Price is invalid", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (price > 1000)
                    {
                        this.listData[e.RowHandle].BikeParking = true;
                    }
                    break;
                default:
                    break;
            }

            // Check this record is insert or update

            int employeeIDSelected = Convert.ToInt32(this.adv_grv_BussinessTrip.GetFocusedRowCellValue("EmployeeID"));

            // When user input employee ID => Add new record or update existed trip

            //int km = Convert.ToInt32(this.adv_grv_BussinessTrip.GetFocusedRowCellValue("BikeMilage"));
            //bool bikeUsed = Convert.ToBoolean(this.adv_grv_BussinessTrip.GetFocusedRowCellValue("BikeUse"));
            //bool lunchRequirement = Convert.ToBoolean(this.adv_grv_BussinessTrip.GetFocusedRowCellValue("LunchRequired"));
            //if (km <= 0 && !bikeUsed && !lunchRequirement) return;

            if (employeeIDSelected < 0)
            {
                return;
            }

            this.UpdateBusinessTrip();
        }

        /// <summary>
        /// Update business Trip
        /// </summary>
        private void UpdateBusinessTrip()
        {
            int bussinessTripID = Convert.ToInt32(this.adv_grv_BussinessTrip.GetFocusedRowCellValue("BusinessTripID"));
            var dataSelected = (ST_WMS_LoadBussinessTrips_Result)this.adv_grv_BussinessTrip.GetRow(this.adv_grv_BussinessTrip.FocusedRowHandle);
            var bussinessTrip = this.GetBusinessTripInfor(dataSelected);

            DataProcess<BusinessTrips> businessTripDA = new DataProcess<BusinessTrips>();
            if (bussinessTripID > 0)
            {
                businessTripDA.Update(bussinessTrip);
            }
            else
            {
                bussinessTrip.AuthorisedCreated = AppSetting.CurrentUser.LoginName;
                bussinessTrip.AuthorisedNameBy = "Created :" + AppSetting.CurrentUser.LoginName + " - " + DateTime.Now.ToString("dd/MM hh:mm");
                businessTripDA.Insert(bussinessTrip);
                this.listData[adv_grv_BussinessTrip.FocusedRowHandle].BusinessTripID = bussinessTrip.BusinessTripID;
                this.listData[adv_grv_BussinessTrip.FocusedRowHandle].BusinessTripNumber = "BT-" + bussinessTrip.BusinessTripID;
                this.listData.Add(new ST_WMS_LoadBussinessTrips_Result());
            }
        }

        /// <summary>
        /// Get businessTrip info
        /// </summary>
        /// <returns></returns>
        private BusinessTrips GetBusinessTripInfor(ST_WMS_LoadBussinessTrips_Result businessTripCombine)
        {
            BusinessTrips currentBusinessTrip = new BusinessTrips
            {
                BusinessTripID = businessTripCombine.BusinessTripID,
                BusinessTripNumber = businessTripCombine.BusinessTripNumber,
                AuthorisedCreated = businessTripCombine.AuthorisedCreated,
                AuthorisedNameBy = businessTripCombine.AuthorisedNameBy,
                AuthorisedTime = businessTripCombine.AuthorisedTime,
                BikeMilage = businessTripCombine.BikeMilage,
                BikeParking = businessTripCombine.BikeParking,
                BikeUse = businessTripCombine.BikeUse,
                BusinessTripCategory = businessTripCombine.BusinessTripCategory,
                EmployeeID = businessTripCombine.EmployeeID,
                EmployeeName = businessTripCombine.EmployeeName,
                Endtime = businessTripCombine.Endtime,
                GuardConfirmed = businessTripCombine.GuardConfirmed,
                GuardTime = businessTripCombine.GuardTime,
                LunchRequired = businessTripCombine.LunchRequired,
                ParkingPrice = businessTripCombine.ParkingPrice,
                PhoneUsed = businessTripCombine.PhoneUsed,
                Purpose = businessTripCombine.Purpose,
                StartTime = businessTripCombine.StartTime,
                TripConfirmed = businessTripCombine.TripConfirmed,
                ts = businessTripCombine.ts,
                WhereTo = businessTripCombine.WhereTo
            };
            return currentBusinessTrip;
        }

        private void rpi_chk_Bike_CheckedChanged(object sender, EventArgs e)
        {
            var chk = (DevExpress.XtraEditors.CheckEdit)sender;
            if (chk.Checked)
            {
                this.adv_grv_BussinessTrip.SetFocusedRowCellValue("BikeMilage", 40);
            }
            else
            {
                this.adv_grv_BussinessTrip.SetFocusedRowCellValue("BikeMilage", 0);
            }
        }

        private void adv_grv_BussinessTrip_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            bool isConfirm = Convert.ToBoolean(this.adv_grv_BussinessTrip.GetFocusedRowCellValue("TripConfirmed"));
            int bussinessTripID = Convert.ToInt32(this.adv_grv_BussinessTrip.GetFocusedRowCellValue("BusinessTripID"));
            if (bussinessTripID <= 0 || isConfirm) return;
            if (e.Column.FieldName.Equals("EmployeeID") || e.Column.FieldName.Equals("EmployeeName"))
                e.Appearance.BackColor = Color.FromArgb(204, 153, 255);
        }

        /// <summary>
        /// Defines the bussiness trip SQL query.
        /// </summary>
        /// <param name="radioSelectedIndex">Index of the radio selected.</param>
        /// <returns></returns>
        private string DefineBussinessTripSQLQuery(int radioSelectedIndex)
        {
            StringBuilder querySQL = new StringBuilder();
            querySQL.Append("SELECT BusinessTrips.* ");
            querySQL.Append(" FROM BusinessTrips INNER JOIN Employees ON BusinessTrips.EmployeeID = Employees.EmployeeID ");

            // Difinition current filter type
            switch (radioSelectedIndex)
            {
                // MySeft
                case 0:
                    querySQL.Append(" WHERE BusinessTrips.AuthorisedCreated = '" + AppSetting.CurrentUser.LoginName + "' ");
                    querySQL.Append(" AND BusinessTrips.StartTime > '" + DateTime.Now.AddDays(-63).ToString("yyyy-MM-dd") + "'");
                    querySQL.Append(" ORDER BY BusinessTrips.StartTime");
                    break;

                // My Unconfirm
                case 1:
                    querySQL.Append(" WHERE BusinessTrips.AuthorisedCreated = '" + AppSetting.CurrentUser.LoginName + "' ");
                    querySQL.Append(" AND BusinessTrips.TripConfirmed = 0 AND BusinessTrips.BikeMilage > 0 AND Employees.Department <> 4 ");
                    querySQL.Append(" ORDER BY BusinessTrips.StartTime");
                    break;

                // Unconfirm
                case 2:
                    querySQL.Append(" WHERE (BusinessTrips.TripConfirmed = 0 AND BusinessTrips.BikeMilage > 0) ");
                    querySQL.Append("ORDER BY BusinessTrips.AuthorisedCreated, BusinessTrips.StartTime");
                    break;

                // All
                case 3:
                    querySQL.Append(" WHERE BusinessTrips.StartTime >'" + DateTime.Now.AddDays(-63).ToString("yyyy-MM-dd") + "'");
                    querySQL.Append(" ORDER BY BusinessTrips.StartTime");
                    break;
            }

            return querySQL.ToString();
        }

        private void rbcbase_Click(object sender, EventArgs e)
        {

        }
    }
}
