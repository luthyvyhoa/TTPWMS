using Common.Controls;
using DA;
using DevExpress.DataAccess.ObjectBinding;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraReports.UI;
using System;
using System.Data;
using System.Windows.Forms;
using UI.Helper;
using UI.ReportFile;

namespace UI.StockTake
{
    public partial class frm_ST_StockTakeDaily : frmBaseForm
    {
        /// <summary>
        /// Detected current radio on group main is checked: Report mode options
        /// </summary>
        private int mainView = 0;

        /// <summary>
        /// Detected current radio on group options is checked: All/ Customer/ Room options
        /// </summary>
        private int dispatchedView = 0;

        public frm_ST_StockTakeDaily()
        {
            // Init controls to designer
            InitializeComponent();

            // Init data
            this.IniData();
        }

        private void IniData()
        {
            // Load master data
            this.LoadCustomer();
            this.LoadRoom();

            // Set data default
            this.dReportDate.DateTime = DateTime.Now;
            this.radgViews.SelectedIndex = 2;
            this.radAll.Checked = true;
        }

        private void LoadCustomer()
        {
            this.lkeCustomer.Properties.DataSource = AppSetting.CustomerList;
            this.lkeCustomer.Properties.DisplayMember = "CustomerNumber";
            this.lkeCustomer.Properties.ValueMember = "CustomerMainID";
        }

        private void LoadRoom()
        {
            DataProcess<Rooms> roomDA = new DataProcess<Rooms>();
            this.lkeByRoom.Properties.DataSource = roomDA.Select(r => r.StoreID == AppSetting.StoreID);
            this.lkeByRoom.Properties.DisplayMember = "RoomID";
            this.lkeByRoom.Properties.ValueMember = "RoomID";
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void radgViews_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.logOption.Visibility = LayoutVisibility.Never;
            int value = Convert.ToInt32(this.radgViews.EditValue);
            switch (value)
            {
                // View all receiving pallets
                case 1:
                    this.mainView = 1;
                    break;

                // View only joined pallets
                case 2:
                    this.mainView = 2;
                    break;

                // View split-Dispatched pallets
                case 3:
                    this.mainView = 3;
                    this.logOption.Visibility = LayoutVisibility.Always;
                    break;

                // View view all movements
                case 4:
                    this.mainView = 4;
                    break;
            }
        }

        private void SetActiveControls(string radName)
        {
            this.lkeByRoom.EditValue = null;
            this.lkeCustomer.EditValue = null;
            switch (radName)
            {
                // Load all
                case "radAll":
                    this.dispatchedView = 1;
                    break;

                // Load Customer
                case "radCustomer":
                    this.dispatchedView = 2;
                    this.lkeCustomer.Focus();
                    this.lkeCustomer.ShowPopup();
                    break;

                // Load Room
                case "radRoom":
                    this.dispatchedView = 3;
                    this.lkeByRoom.Focus();
                    this.lkeByRoom.ShowPopup();
                    break;
            }
        }

        private void radAll_CheckedChanged(object sender, EventArgs e)
        {
            var rad = (RadioButton)sender;
            if (rad.Checked)
            {
                this.SetActiveControls(rad.Name);
            }
        }

        /// <summary>
        /// Handles the Click event of the btnViewReport control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnViewReport_Click(object sender, EventArgs e)
        {
            DataProcess<object> dataAccessInstance = new DataProcess<object>();
            DataTable dataSource = null;
            XtraReport rpt = null;
            var sqlQueryCmd = string.Empty;

            switch (this.mainView)
            {
                // View all receiving pallets
                case 1:

                    sqlQueryCmd = "STStockTakeDailyCheck @ReportDate='" + this.dReportDate.DateTime.ToString("dd-MMM-yyyy") + "' , @varStoreID=" + AppSetting.StoreID;
                    dataSource = FileProcess.LoadTable(sqlQueryCmd);
                    rpt = new rptStockTakeDailyCheck();
                    rpt.Parameters["prReportDate"].Value = this.dReportDate.DateTime;
                    break;

                // View only joined pallets
                case 2:
                    if (DateTime.Now.Date.CompareTo(this.dReportDate.DateTime.Date) == 0) // Is Today
                    {
                        dataSource = FileProcess.LoadTable("STStockTakeDailyCheckJoinedPallets @varStoreID=" + AppSetting.StoreID);
                        rpt = new rptStockTakeDailyCheck();
                        break;
                    }
                    else
                    {
                        MessageBox.Show("This option is for today only !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.dReportDate.Focus();
                        return;
                    }

                // View split-Dispatched pallets
                case 3:
                    if (0 != DateTime.Now.Date.CompareTo(this.dReportDate.DateTime.Date)) // Is Today
                    {
                        MessageBox.Show("This option is for today only !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.dReportDate.Focus();
                        return;
                    }

                    sqlQueryCmd = $"STStockTakeDailyCheckSplitPallets @varStoreID= {AppSetting.StoreID}";
                    dataAccessInstance.ExecuteNoQuery(sqlQueryCmd);

                    switch (this.dispatchedView)
                    {
                        // Load all
                        case 1:
                            dataSource = FileProcess.LoadTable("STStockTakeDailyCheckSplitPalletReport");
                            break;

                        // Load Customer
                        case 2:
                            var byCustomerQuery = "STStockTakeDailyCheckSplitPalletReport @CustomerMainID=" + Convert.ToInt32(this.lkeCustomer.EditValue) + ", @varStoreID=" + AppSetting.StoreID;
                            dataSource = FileProcess.LoadTable(byCustomerQuery);
                            break;

                        // Load Room
                        case 3:
                            var byRoomQuery = "STStockTakeDailyCheckSplitPalletReport NULL, @RoomID=N'" + this.lkeByRoom.EditValue.ToString() + "', @varStoreID=" + AppSetting.StoreID;
                            dataSource = FileProcess.LoadTable(byRoomQuery);
                            break;

                        default:
                            break;
                    }
                        
                    rpt = new rptStockTakeDailyCheckSplitPallets();
                    rpt.Parameters["textCountLocation"].Value = dataSource?.Rows.Count ?? 0;
                    rpt.Parameters["textTotalCartons"].Value = "";
                    break;

                // View all movements
                case 4:
                    var fromDate = this.dReportDate.DateTime.ToString("yyyy-MMM-dd");
                    dataSource = FileProcess.LoadTable("STStockMovementReviewByDate @FromDate='" + fromDate + "', @ToDate='" + fromDate + "', @CustomerID=NULL, @varStoreID=" + AppSetting.StoreID);
                    rpt = new rptStockMovementReviewByLocation();
                    break;

                default:
                    break;
            }

            if (rpt == null)
            {
                return;
            }

            if (dataSource == null || dataSource.Rows.Count == 0)
            {
                XtraMessageBox.Show(this, "No data to print !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            rpt.RequestParameters = false;
            rpt.DataSource = dataSource;
            var reportPrintToolWMS = new ReportPrintToolWMS(rpt)
            {
                AutoShowParametersPanel = false
            };
            reportPrintToolWMS.ShowPreviewDialog();
        }
    }
}
