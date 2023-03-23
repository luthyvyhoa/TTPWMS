using System;
using System.Windows.Forms;
using Common.Controls;
using DA;
using DA.Warehouse;
using UI.Helper;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using System.Text;
using System.Collections.Generic;
using UI.ReportFile;
using System.Data;
using log4net;
using System.Linq;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_AirTemperatureEntry : frmBaseForm
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILog logger = LogManager.GetLogger(typeof(frm_WM_AirTemperatureEntry));

        /// <summary>
        /// The employee information
        /// </summary>
        Employees employeeInformation = new DataProcess<Employees>().Select(em => em.EmployeeID == AppSetting.CurrentUser.EmployeeID).FirstOrDefault();

        /// <summary>
        /// The plant database context
        /// </summary>
        PlantDBContext plantDbContext => new PlantDBContext();

        public frm_WM_AirTemperatureEntry()
        {
            InitializeComponent();

            // Init events
            this.InitEvents();

            this.dFrom.DateTime = DateTime.Now;
            this.dTo.DateTime = DateTime.Now;
        }

        /// <summary>
        /// Handles the Load event of the frm_WM_AirTemperatureEntry control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void frm_WM_AirTemperatureEntry_Load(object sender, EventArgs e)
        {
            this.rbgReportByGroup.SelectedIndex = 2; // Default set to All options for RadioGroup
            this.LoadTemperatureAndHumidity();
        }

        private void InitEvents()
        {
            this.dTo.CloseUp += DTemperatureDate_CloseUp;
            this.dTo.KeyDown += DTemperatureDate_KeyDown;
            this.rpi_btn_Deleted.Click += Rpi_btn_Deleted_Click;
        }

        private void Rpi_btn_Deleted_Click(object sender, EventArgs e)
        {
            string userCreated = Convert.ToString(this.grvTemperature.GetFocusedRowCellValue("UserName"));
            if (!AppSetting.CurrentUser.LoginName.Equals(userCreated))
            {
                MessageBox.Show("Ban khong the xoa du lieu cua nguoi khac !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                var dl = MessageBox.Show("Ban co chac chan muon xoa khong?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dl.Equals(DialogResult.No)) return;
                int airTemperatureID = Convert.ToInt32(this.grvTemperature.GetFocusedRowCellValue("AirTempRecordID"));
                using (PlantDBContext context = new PlantDBContext())
                {
                    var dataSource = context.Delete("SP_AirTemperatureDelete @AirTempRecordID=" + airTemperatureID);
                }
            }

        }

        private void DTemperatureDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            this.LoadTemperatureByDate(this.dTo.DateTime);
        }

        private void DTemperatureDate_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.Value == null) return;
            this.dTo.EditValue = e.Value;
            this.LoadTemperatureByDate(this.dTo.DateTime);
        }

        private void LoadTemperatureByDate(DateTime tempDate)
        {
            this.SetActiveControl(2);
            using (PlantDBContext context = new PlantDBContext())
            {
                var dataSource = context.GetComboStoreNo("SP_AirTemperatureView @ReportDate='" + tempDate.ToString("yyyy-MM-dd") + "', @varStoreID=" + AppSetting.StoreID);
                this.grdTemperature.DataSource = dataSource;
            }
        }

        private void ChkNearDate_CheckedChanged(object sender, System.EventArgs e)
        {
            //if (this.chkNearDate.Checked)
            //{
            //    this.SetActiveControl(3);
            //    using (PlantDBContext context = new PlantDBContext())
            //    {
            //        var dataSource = context.GetComboStoreNo("SP_AirTemperatureView @varStoreID=" + AppSetting.StoreID);
            //        this.grdTemperature.DataSource = dataSource;
            //    }
            //}
        }

        private void LkeTemperatureRoom_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.Value == null) return;
            this.SetActiveControl(1);
            using (PlantDBContext context = new PlantDBContext())
            {
                var dataSource = context.GetComboStoreNo("SP_AirTemperatureView @roomID='" + e.Value + "', @varStoreID=" + AppSetting.StoreID);
                this.grdTemperature.DataSource = dataSource;
            }
        }

        /// <summary>
        /// Room selected=1
        /// Date selected=2
        /// Near selected=3
        /// </summary>
        /// <param name="type">int</param>
        private void SetActiveControl(int type)
        {
            switch (type)
            {
                // Room selected
                case 1:
                    this.dTo.EditValue = null;
                    break;

                // Date selected
                case 2:
                    break;

                // Near date selected
                case 3:
                    this.dTo.EditValue = null;
                    break;
                default:
                    break;
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if (this.grvTemperature.RowCount <= 0) return;
            string fieldName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//Temp_" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".xlsx";
            grvTemperature.ExportToXlsx(fieldName);
            try
            {
                System.Diagnostics.Process.Start("Excel", fieldName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            if (this.grvTemperature.RowCount <= 0) return;
            string fieldName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//Temp_" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".pdf";
            grvTemperature.ExportToPdf(fieldName);
            try
            {
                System.Diagnostics.Process.Start("PDF", fieldName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// Loads the temperature and humidity.
        /// </summary>
        private void LoadTemperatureAndHumidity()
        {
            // Query in DB by STRooms store_proc
            var roomsExecResult = FileProcess.LoadTable("STRooms @varStoreID= " + AppSetting.StoreID);
            if (roomsExecResult == null)
            {
                return;
            }

            // Set data source for Grid
            this.ExecuteOnUIThread(() =>
            {
                this.grdTemperature.DataSource = roomsExecResult;
            });
        }

        /// <summary>
        /// Handles the Click event of the btnClose control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the rbgReportByGroup control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void rbgReportByGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update data for grid correct to current selected filter
            var currentSelectedIndex = Convert.ToInt32(this.rbgReportByGroup.EditValue);
            switch (currentSelectedIndex)
            {
                // Todo: Handle load data for each mode of selection
                case 1: // all
                    break;

                case 2: // air
                    break;

                case 3: // humidity
                    break;

                default:// Not support out of scope
                    break;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnByRoom control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnByRoom_Click(object sender, EventArgs e)
        {
            var sqlCmdUpdated = this.UpdateSQL();
            var ariByRoomtaSource = this.QueryOnPlantDB(sqlCmdUpdated);

            // Open rptAirTemperatureViewByRoom report
            var rptAirTemperatureViewByRoomReport = new rptAirTemperatureViewByRoom
            {
                PaperKind = System.Drawing.Printing.PaperKind.A4
            };
            rptAirTemperatureViewByRoomReport.SetFromToDateInfo(this.dFrom.Text, this.dTo.Text);
            rptAirTemperatureViewByRoomReport.Parameters["varCurrentUser"].Value = employeeInformation?.FullName;
            rptAirTemperatureViewByRoomReport.RequestParameters = false;
            rptAirTemperatureViewByRoomReport.DataSource = ariByRoomtaSource;

            // Show preview window
            var printTool = new ReportPrintToolWMS(rptAirTemperatureViewByRoomReport)
            {
                AutoShowParametersPanel = false,
            };
            printTool.ShowPreview();

            // Reload the Rooms list
            this.LoadTemperatureAndHumidity();
        }

        /// <summary>
        /// Handles the Click event of the btnByDate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnByDate_Click(object sender, EventArgs e)
        {
            try
            {
                // Show rptAirTemperatureViewByDate report
                var rptAirTemperatureViewByDateReport = new rptAirTemperatureViewByDate();
                rptAirTemperatureViewByDateReport.PaperKind = System.Drawing.Printing.PaperKind.A4;
                rptAirTemperatureViewByDateReport.SetFromToDateInfo(this.dFrom.Text, this.dTo.Text);
                rptAirTemperatureViewByDateReport.Parameters["varCurrentUser"].Value = employeeInformation?.FullName;
                rptAirTemperatureViewByDateReport.RequestParameters = false;

                var sqlCmd = this.BuildSqlCommand();
                var reportDataSource = this.QueryOnPlantDB(sqlCmd);

                rptAirTemperatureViewByDateReport.DataSource = reportDataSource;
                var printTool = new ReportPrintToolWMS(rptAirTemperatureViewByDateReport)
                {
                    AutoShowParametersPanel = false
                };

                printTool.ShowPreview();
            }
            catch (Exception ex)
            {
                logger.Error("Can not show preview dialog for Air Temperature View By Date .", ex);
            }
            
        }

        /// <summary>
        /// Updates the SQL.
        /// </summary>
        private string UpdateSQL()
        {
            var sqlCmd = string.Empty;
            var selectedRoom = this.grvTemperature.GetSelectedRows();
            if (selectedRoom.Length != 0) // 'co chon 1 so Room
            {
                var allRoomcondition = new List<string>();
                foreach (var roomIndex in selectedRoom)
                {
                    var roomInfo = this.grvTemperature.GetDataRow(roomIndex);
                    if (roomInfo != null)
                    {
                        var roomId = roomInfo[0].ToString(); // Get RoomID info
                        allRoomcondition.Add(roomId);
                    }
                }

                var conditionStr = string.Join(",", allRoomcondition);
                sqlCmd = this.BuildSqlCommand(conditionStr);                
            }
            else // Khong chon Room trong List Box, Nghia la chon Room
            {
                // "SP_AirTemperatureReport '" & Format(Me.TxtFromDate, "yyyy-MM-dd") & "','" & Format(Me.TxtToDate, "yyyy-MM-dd") & "','1'"
                sqlCmd = this.BuildSqlCommand("1");                
            }

            return sqlCmd;
        }

        /// <summary>
        /// Builds the SQL command.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <returns></returns>
        private string BuildSqlCommand(string condition = null)
        {
            var sqlCmd = string.Empty;
            if (condition == null)
            {
                sqlCmd = $"SP_AirTemperatureReport @FromDate='{ string.Format("{0:yyyy-MM-dd}", this.dFrom.DateTime) }" +
                    $"',@ToDate='{string.Format("{0:yyyy-MM-dd}", this.dTo.DateTime)}'";
            }
            else
            {
                sqlCmd = $"SP_AirTemperatureReport @FromDate='{ string.Format("{0:yyyy-MM-dd}", this.dFrom.DateTime) }" +
                    $"',@ToDate='{string.Format("{0:yyyy-MM-dd}", this.dTo.DateTime)}',@varcondition= '{condition}" +
                    $"',@StoreID={AppSetting.StoreID}";
            }
            return sqlCmd;
        }

        /// <summary>
        /// Queries the on plant database.
        /// </summary>
        /// <returns></returns>
        private DataTable QueryOnPlantDB(string sqlCmd)
        {
            DataTable dataSetResult = null;
            try
            {
                using (this.plantDbContext)
                {
                    using (var connection = this.plantDbContext.Database.Connection)
                    {
                        using (var command = connection.CreateCommand())
                        {
                            command.CommandText = sqlCmd;
                            connection.Open();
                            using (var reader = command.ExecuteReader(CommandBehavior.SequentialAccess))
                            {
                                using (var tbResult = new DataTable())
                                {
                                    tbResult.Load(reader);
                                    dataSetResult = tbResult;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error("Can not query DB", ex);
            }

            return dataSetResult;
        }

    }
}
