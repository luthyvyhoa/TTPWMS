using System.Windows.Forms;
using Common.Controls;
using DA;
using System.Data;
using System;
using UI.Helper;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;

namespace UI.Supperviors
{
    public partial class frm_S_AO_ProblemList : frmBaseForm
    {

        public frm_S_AO_ProblemList()
        {
            InitializeComponent();

            // Init data
            this.LoadData();
        }

        /// <summary>
        /// Change query to store
        /// </summary>
        private void LoadData()
        {
            string fromDate = DateTime.Now.AddDays(-100).ToString("yyyy-MM-dd");
            string toDate = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
            this.dFromDate.DateTime = DateTime.Now.AddDays(-100);
            this.dToDate.DateTime = DateTime.Now.AddDays(1);
            this.grdProblemList.DataSource = FileProcess.LoadTable("ST_WMS_LoadProblemList @FromDate='" + fromDate + "',@ToDate='" + toDate + "',@StoreID=" + AppSetting.StoreID);
        }

        private void rpi_hpl_InternalAuditID_Click(object sender, System.EventArgs e)
        {
            int auditID = Convert.ToInt32(this.grvProblemList.GetFocusedRowCellValue("InternalAuditID"));
            frm_S_AO_InternalAudits frmDetail = new frm_S_AO_InternalAudits(auditID);
            frmDetail.BringToFront();
            frmDetail.WindowState = FormWindowState.Maximized;
            frmDetail.Show();
        }

        private void btn_AddNew_Click(object sender, EventArgs e)
        {
            frm_S_AO_InternalAudits frmDetail = new frm_S_AO_InternalAudits(0);
            frmDetail.AddNew();
            frmDetail.BringToFront();
            frmDetail.WindowState = FormWindowState.Maximized;
            frmDetail.Show();
        }

        private void grvProblemList_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle < 0) return;
            DateTime currentDate = DateTime.Now;
            DateTime correctDateTime = currentDate;
            DateTime compleDateTime = currentDate;
            string correctTime = Convert.ToString(this.grvProblemList.GetFocusedRowCellValue("CorrectiveBeforeDate"));
            string compleTime = Convert.ToString(this.grvProblemList.GetFocusedRowCellValue("CompleteBeforeDate"));
            if (!string.IsNullOrEmpty(correctTime))
            {
                correctDateTime = Convert.ToDateTime(correctTime);
            }
            if (!string.IsNullOrEmpty(compleTime))
            {
                compleDateTime = Convert.ToDateTime(compleTime);
            }
            if (correctDateTime.CompareTo(DateTime.Now) < 0 || compleDateTime.CompareTo(DateTime.Now) < 0)
            {
                e.Appearance.BackColor = Color.Red;
                e.Appearance.ForeColor = Color.White;
            }
            else
            {
                e.Appearance.BackColor = Color.Transparent;
                e.Appearance.ForeColor = Color.Black;
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string fromDate = dFromDate.DateTime.ToString("yyyy-MM-dd");
            string toDate = dToDate.DateTime.ToString("yyyy-MM-dd");
            this.grdProblemList.DataSource = FileProcess.LoadTable("ST_WMS_LoadProblemList @FromDate='" + fromDate + "',@ToDate='" + toDate + "',@StoreID=" + AppSetting.StoreID);
        }
        private void btnReport_Click(object sender, EventArgs e)
        {
            var fromDate = this.dFromDate.DateTime.ToString("yyyy-MM-dd");
            var toDate = this.dToDate.DateTime.ToString("yyyy-MM-dd");
            var reportDataSource = FileProcess.LoadTable($"STTotalProblemByCategoryByMonth @FromDate = '{fromDate}', @ToDate = '{toDate}', @StoreID = {AppSetting.StoreID}");
            var reportChart = new ReportFile.rptProblemEntryChart();
            reportChart.DataSource = reportDataSource;

            // Set From date/ To Date to display
            reportChart.SetFromToDate(this.dFromDate.DateTime, this.dToDate.DateTime);

            // Set all categories Problem
            DataProcess<ProblemCategories> problemCategoriesDA = new DataProcess<ProblemCategories>();
            var problemCategories = new List<string>();
            problemCategories = problemCategoriesDA.Executing("SELECT * FROM ProblemCategories").OrderBy(p => p.ProblemCategoryDescription)
                                .Select(ct => ct.ProblemCategoryDescription).ToList();
            reportChart.ProblemCategories = problemCategories;

            var printTool = new ReportPrintToolWMS(reportChart)
            {
                AutoShowParametersPanel = false,
            };

            printTool.ShowPreview();
        }

        private void btnViewSummary_Click(object sender, EventArgs e)
        {
            DevExpress.XtraGrid.GridControl grid = new DevExpress.XtraGrid.GridControl();
            DevExpress.XtraGrid.Views.Grid.GridView grv = new DevExpress.XtraGrid.Views.Grid.GridView();

            grid.MainView = grv;
            grid.ViewCollection.Add(grv);
            BindingContext context = new BindingContext();
            grid.BindingContext = context;
            
            grid.DataSource = FileProcess.LoadTable("STProblem_SummaryByMonthCrosstapReport");
            grid.ForceInitialize();
            grv.PopulateColumns();

            string pathSaveFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string fileName = pathSaveFile + "\\" + "SummaryByMonth_" + DateTime.Now.ToString("dd_MM_yy") + ".xlsx";

            //grv.ExportToXlsx(fileName);

            //System.Diagnostics.Process.Start(fileName);
        }

        private void btn_ViewEmployees_Click(object sender, EventArgs e)
        {
            string fromDate = dFromDate.DateTime.ToString("yyyy-MM-dd");
            string toDate = dToDate.DateTime.ToString("yyyy-MM-dd");

            if (this.btn_ViewEmployees.Text == "View Employees")
            {
                //this.grdProblemList.DataSource = null;
                this.grdProblemList.MainView = grvEmployeeList;
                this.btn_ViewEmployees.Text = "View Details";
                this.grdProblemList.DataSource = FileProcess.LoadTable("ST_WMS_LoadProblemList @FromDate='" + fromDate + "',@ToDate='" + toDate + "',@StoreID=" + AppSetting.StoreID + ",@Detail= 1");
            }
            else
            {
                //this.grdProblemList.DataSource = null;
                this.grdProblemList.MainView = grvProblemList;
                this.grdProblemList.DataSource = FileProcess.LoadTable("ST_WMS_LoadProblemList @FromDate='" + fromDate + "',@ToDate='" + toDate + "',@StoreID=" + AppSetting.StoreID);
                this.btn_ViewEmployees.Text = "View Employees";
            }

        }

        private void grvProblemList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.grcProblemExtended.DataSource = FileProcess.LoadTable("STInternalAuditDetails " + this.grvProblemList.GetFocusedRowCellValue("InternalAuditID"));
            this.grcCorrectiveAction.DataSource = FileProcess.LoadTable("STInternalAuditActions " + this.grvProblemList.GetFocusedRowCellValue("InternalAuditID") + ",1");
            this.grcPreventativeAction.DataSource = FileProcess.LoadTable("STInternalAuditActions " + this.grvProblemList.GetFocusedRowCellValue("InternalAuditID") + ",2");
        }
    }
}
