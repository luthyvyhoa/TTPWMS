using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Controls;
using DA;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using UI.Helper;
using UI.WarehouseManagement;

namespace UI.Transport
{
    public partial class frm_T_ProfitabilityAnalysis : frmBaseFormNormal
    {
        private urc_WM_OtherService viewService = null;
        public frm_T_ProfitabilityAnalysis()
        {
            InitializeComponent();
            this.dFromdate.DateTime = DateTime.Today.AddDays(-7);
            this.dTodate.DateTime = DateTime.Today;
            this.lke_OperatingCostMonthlyID.Properties.DataSource = FileProcess.LoadTable("ST_WMS_LoadOperatingCostMonth");
            this.lke_OperatingCostMonthlyID.Properties.ValueMember = "OperatingCostMonthlyID";
            this.lke_OperatingCostMonthlyID.Properties.DisplayMember = "MonthDescription";
            DataProcess<Stores> storeDA = new DataProcess<Stores>();
            this.lke_MSS_StoreList.Properties.DataSource = storeDA.Select();
            this.lke_MSS_StoreList.Properties.ValueMember = "StoreID";
            this.lke_MSS_StoreList.Properties.DisplayMember = "StoreDescription";
            this.lke_MSS_StoreList.EditValue = AppSetting.CurrentUser.StoreID;

            refreshData();
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            
            refreshData();
            
        }
        private void refreshData()
        {
            string fromDate = this.dFromdate.DateTime.ToString("yyyy-MM-dd");
            string toDate = this.dTodate.DateTime.ToString("yyyy-MM-dd");

            this.grcTripDetails.DataSource = null;

            DataTable ds = null;
            ds = FileProcess.LoadTable("STOperatingCostTransportAnalysis '" + fromDate + "', '" + toDate + "',1,0," + this.lke_MSS_StoreList.EditValue);
            this.grcDistributionServiceSummary.DataSource = ds;
            if (ds != null && ds.Rows.Count != 0)
                this.space_UpdateTime.Text = Convert.ToString(ds.Rows[0]["CreatedTime"]);


            //this.grcTripDetails.DataSource = FileProcess.LoadTable("STOperatingCostTransportAnalysis '" + fromDate + "', '" + toDate + "'");
            //if (AppSetting.StoreID == 1)

            //else
            //    this.grcDistributionServiceSummary.DataSource = null;


            //this.grcWMSTripSummary.DataSource = FileProcess.LoadTable("STBillingDetailTransportServiceAnalysis '" + fromDate + "', '" + toDate + "','',"+AppSetting.StoreID);
            //SplashScreenManager.ShowForm(this, typeof(frmWaitForm), true, true, false, false);
            //SplashScreenManager.Default.SetWaitFormCaption("Generating Profitability Report");
            //SplashScreenManager.Default.SetWaitFormDescription("Loading data... ");
            //SplashScreenManager.CloseForm(false);
        }

        private void grvDistributionServiceSummary_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            string fromDate = this.dFromdate.DateTime.ToString("yyyy-MM-dd");
            string toDate = this.dTodate.DateTime.ToString("yyyy-MM-dd");
            this.grcTripDetails.DataSource = FileProcess.LoadTable("STBillingDetailDistributionServiceAnalysis '" + 
                fromDate + "', '" + toDate + "',0," + this.grvDistributionServiceSummary.GetFocusedRowCellValue("TripID"));
            this.grcCostDetails.DataSource = FileProcess.LoadTable("STBillingDetailTransportServiceTripCost '"
                + this.grvDistributionServiceSummary.GetFocusedRowCellValue("TripNumber") + "'");

            switch (this.grvDistributionServiceSummary.FocusedColumn.FieldName)
            {
                case "BusinessNote":
                    string origText = this.grvDistributionServiceSummary.GetFocusedRowCellValue("BusinessNote").ToString();
                    string businessNoteText = XtraInputBox.Show("Please input note for this trip ", "WMS-2022", origText); 
                    if (businessNoteText != "")
                    {
                        DataProcess<object> dataProcess = new DataProcess<object>();
                        var currentRow = this.grvDistributionServiceSummary.GetDataRow(e.RowHandle);
                        string orderNo = this.grvDistributionServiceSummary.GetFocusedRowCellValue("TripNumber").ToString();
                        int result2 = dataProcess.ExecuteNoQuery("STTransportTripBusinessNoteUpdate  @TripNumber = {0}, @BusinessNote = {1}, @CurrentUser = {2}", orderNo, businessNoteText, AppSetting.CurrentUser.LoginName);
                        if (result2 > -2) refreshData();
                    }
                    break;
                
                default:
                    break;
            }
        }

        private void grvWMSTripSummary_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            //string fromDate = this.dFromdate.DateTime.ToString("yyyy-MM-dd");
            //string toDate = this.dTodate.DateTime.ToString("yyyy-MM-dd");
            //string strSQL = "STBillingDetailTransportServiceAnalysis '" +
            //    fromDate + "', '" + toDate + "','" + this.grvWMSTripSummary.GetFocusedRowCellValue("TripNumber") + "'";
            //this.grcTripDetails.DataSource = FileProcess.LoadTable(strSQL);

            //strSQL = "STBillingDetailTransportServiceTripCost '"
            //    + this.grvWMSTripSummary.GetFocusedRowCellValue("TripNumber") + "'";
            //this.grcCostDetails.DataSource = FileProcess.LoadTable(strSQL);
        }

        private void btnUpdateToday_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt16(this.lke_OperatingCostMonthlyID.EditValue) == 0 || this.lke_OperatingCostMonthlyID.EditValue ==null)
            {
                MessageBox.Show("Please choose the month to update ");
                return;
            }
            else
            {
                if (this.space_UpdateTime.Text != "00:00") // not the first time open the form
                {
                    double dm = (Convert.ToDateTime(this.space_UpdateTime.Text) - DateTime.Now).TotalMinutes;
                    if (dm < -5) // allow refresh if last refresh time is more than 5 minutes ago
                    {
                        this.grcDistributionServiceSummary.DataSource = FileProcess.LoadTable("OperatingCostTransportInsert " + this.lke_OperatingCostMonthlyID.EditValue);
                    }
                    else
                    {
                        MessageBox.Show("Refresh data is not available !", "TPWMS");
                    }
                }
                else  // first time open form
                {
                    this.grcDistributionServiceSummary.DataSource = FileProcess.LoadTable("OperatingCostTransportInsert " + this.lke_OperatingCostMonthlyID.EditValue);
                }
                
                refreshData();
            }

        }

        private void lke_OperatingCostMonthlyID_EditValueChanged(object sender, EventArgs e)
        {
            this.dFromdate.DateTime = Convert.ToDateTime(this.lke_OperatingCostMonthlyID.GetColumnValue("PersonnelFromDate"));
            this.dTodate.DateTime = Convert.ToDateTime(this.lke_OperatingCostMonthlyID.GetColumnValue("PersonnelTodate"));
        }

        private void grvDistributionServiceSummary_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle < 0) return;
            DataProcess<object> dataProcess = new DataProcess<object>();
            var currentRow = this.grvDistributionServiceSummary.GetDataRow(e.RowHandle);
            string orderNo =grvDistributionServiceSummary.GetRowCellValue(e.RowHandle, "TripNumber").ToString();
            //string businessNoteText = grvDistributionServiceSummary.GetRowCellValue(e.RowHandle, "BusinessNote").ToString();

            if (e.Column == colBusinessNote)
            {
                int result2 = dataProcess.ExecuteNoQuery("STTransportTripBusinessNoteUpdate  @TripNumber = {0}, @BusinessNote = {1}, @varUser = {2}", orderNo, e.Value, AppSetting.CurrentUser.LoginName);
            }
                
        }

        private void dockPanelService_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            string TNu = this.grvTransportAnalysis.GetFocusedRowCellValue("TripNumber").ToString();
            string customerNumber = Convert.ToString(this.grvTransportAnalysis.GetFocusedRowCellValue("CustomerNumber"));
            int customerID = 0;
            if (!string.IsNullOrEmpty(customerNumber)) customerID = Convert.ToInt32(customerNumber.Split('-')[1]);
            if (this.viewService == null)
            {
                this.viewService = new urc_WM_OtherService(TNu, customerID);
                this.viewService.Parent = this.dockPanelService;
            }
            else
            {
                this.viewService.InitData(TNu, customerID);
            }
        }

        private void btnShowChart_Click(object sender, EventArgs e)
        {
            int storeID = Convert.ToInt32(this.lke_MSS_StoreList.EditValue);

            Form form = new Form();
            form.Text = "WEEKLY TRANSPORT OPERATING PROFIT";
            DataTable cd = FileProcess.LoadTable("STOperatingCostTransportAnalysisChart365");

            ChartControl chart = new ChartControl();
            Series serieRevenue = new Series("Revenue", ViewType.Area);
            chart.Series.Add(serieRevenue);
            serieRevenue.DataSource = cd;
            serieRevenue.ArgumentScaleType = ScaleType.DateTime;
            serieRevenue.ArgumentDataMember = "WeekEnd";
            serieRevenue.ValueScaleType = ScaleType.Numerical;
            serieRevenue.CrosshairLabelPattern = "{S} | {V:#,#}";
            serieRevenue.ValueDataMembers.AddRange(new string[] { "Revenue" });

            Series serieCost = new Series("Cost", ViewType.Area);
            chart.Series.Add(serieCost);
            serieCost.DataSource = cd;
            serieCost.ArgumentScaleType = ScaleType.DateTime;
            serieCost.ArgumentDataMember = "WeekEnd";
            serieCost.ValueScaleType = ScaleType.Numerical;
            serieCost.CrosshairLabelPattern = "{S} | {V:#,#}";
            serieCost.ValueDataMembers.AddRange(new string[] { "Cost" });
            chart.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Left;
            chart.Legend.AlignmentVertical = LegendAlignmentVertical.Top;



            Series serieOperatingProfit = new Series("OperatingProfit", ViewType.Bar);
            chart.Series.Add(serieOperatingProfit);
            serieOperatingProfit.DataSource = cd;
            serieOperatingProfit.ArgumentScaleType = ScaleType.DateTime;
            serieOperatingProfit.ArgumentDataMember = "WeekEnd";
            serieOperatingProfit.ValueScaleType = ScaleType.Numerical;
            serieOperatingProfit.CrosshairLabelPattern = "{S} | {V:#,#}";
            serieOperatingProfit.ValueDataMembers.AddRange(new string[] { "OperatingProfit" });
            chart.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Left;
            chart.Legend.AlignmentVertical = LegendAlignmentVertical.Top;
            StackedBarSeriesView sbv = new StackedBarSeriesView();
            sbv.BarWidth = 0.5D;
            sbv.Color = Color.DarkRed;
            sbv.FillStyle.FillMode = FillMode.Solid;
            serieOperatingProfit.View = sbv;

            chart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;

            XYDiagram diagram = chart.Diagram as XYDiagram;
            diagram.AxisX.DateTimeScaleOptions.GridAlignment = DateTimeGridAlignment.Week;
            diagram.AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Week;
            diagram.AxisX.Label.TextPattern = "{V:d/M}";
            diagram.AxisY.Label.TextPattern = "{V:#,#}";





            ChartTitle chartTitle1 = new ChartTitle();
            chartTitle1.Text = "WEEKLY TRANSPORT OPERATING PROFIT ANALYSIS";
            chart.Titles.Add(chartTitle1);


            chart.Parent = form;
            chart.Dock = DockStyle.Fill;
            chart.Click += Chart_Click; 
            form.Bounds = new Rectangle(100, 100, 1400, 800);
            form.ShowDialog();
            form.Dispose();

        }

        private void Chart_Click(object sender, EventArgs e)
        {
            Form form2 = new Form();
            form2.Text = "Records";
            // Place a DataGrid control on the form.
            DataGridView grid = new DataGridView();
            grid.Parent = form2;
            grid.Dock = DockStyle.Fill;
            // Get the recrd set associated with the current cell and bind it to the grid.
            grid.DataSource = FileProcess.LoadTable("STOperatingCostTransportAnalysisChart365"); ;
            form2.Bounds = new Rectangle(100, 100, 1000, 400);
            // Display the form.
            form2.ShowDialog();
            form2.Dispose();
            //throw new NotImplementedException();
        }
    }
}
