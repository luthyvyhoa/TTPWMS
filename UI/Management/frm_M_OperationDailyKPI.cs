using DA;
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
using DevExpress.XtraPivotGrid;

namespace UI.Management
{
    public partial class frm_M_OperationDailyKPI : Form
    {
        public frm_M_OperationDailyKPI()
        {

            InitializeComponent();
            this.lke_OperatingCostMonthlyID.Properties.DataSource = FileProcess.LoadTable("ST_WMS_LoadOperatingCostMonth");
            this.lke_OperatingCostMonthlyID.Properties.ValueMember = "OperatingCostMonthlyID";
            this.lke_OperatingCostMonthlyID.Properties.DisplayMember = "MonthDescription";
            this.lke_MSS_StoreList.EditValue = AppSetting.StoreID;

            DataProcess<Stores> storeDA = new DataProcess<Stores>();
            this.lke_MSS_StoreList.Properties.DataSource = storeDA.Select();
            this.lke_MSS_StoreList.Properties.ValueMember = "StoreID";
            this.lke_MSS_StoreList.Properties.DisplayMember = "StoreDescription";

           // this.lke_MSS_StoreList.EditValue = AppSetting.StoreID;
            this.lke_OperatingCostMonthlyID.EditValue = AppSetting.CurrentOperationMonthID;
            this.check_WeeklyData.EditValue = false;
            this.layoutControlDepartmentTeamID.ContentVisible= false;
            this.lke_DepartmentTeams.Properties.DataSource = FileProcess.LoadTable("ST_WMS_LoadDepartmentTeamList " + AppSetting.StoreID);
            this.lke_DepartmentTeams.Properties.ValueMember = "DepartmentTeamID";
            this.lke_DepartmentTeams.Properties.DisplayMember = "TeamName";

            PivotGridField fieldYear = new PivotGridField("ReportDate", PivotArea.ColumnArea);
            PivotGridField fieldMonth = new PivotGridField("ReportDate", PivotArea.FilterArea);
            PivotGridField fieldWarehouse = new PivotGridField("WarehouseDescription", PivotArea.FilterArea);
            pvgDailyKPI.Fields.Add(fieldYear);
            pvgDailyKPI.Fields.Add(fieldMonth);
            pvgDailyKPI.Fields.Add(fieldWarehouse);

            // Set the caption and group mode of the fields. 
            fieldYear.GroupInterval = PivotGroupInterval.DateYear;
            fieldYear.Caption = "Year";
            fieldYear.AreaIndex = 0;
            fieldMonth.GroupInterval = PivotGroupInterval.DateMonth;
            fieldMonth.Caption = "Month";
            fieldWarehouse.Caption = "Warehouse";
        }

        private void lke_MSS_StoreList_EditValueChanged(object sender, EventArgs e)
        {
            this.lke_DepartmentTeams.Properties.DataSource = FileProcess.LoadTable("ST_WMS_LoadDepartmentTeamList " + lke_MSS_StoreList.EditValue);
        }

        private void lke_OperatingCostMonthlyID_EditValueChanged(object sender, EventArgs e)
        {
            
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            var pivotExportOptions = new DevExpress.XtraPivotGrid.PivotXlsxExportOptions();
            pivotExportOptions.ExportType = DevExpress.Export.ExportType.DataAware;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel 97-2003 (*.xls)|*.xls|Excel 07-2010 (*.xlsx)|*.xlsx";

            DialogResult dr = sfd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                this.pvgDailyKPI.ExportToXlsx(sfd.FileName, pivotExportOptions);
                try
                {
                    System.Diagnostics.Process.Start("Excel", sfd.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            sfd.Dispose();
        }

        private void pvgOperatingHours_CellClick(object sender, DevExpress.XtraPivotGrid.PivotCellEventArgs e)
        {
            Form form = new Form();
            form.Text = "Records";
            // Place a DataGrid control on the form.
            DataGridView grid = new DataGridView();
            grid.Parent = form;
            grid.Dock = DockStyle.Fill;
            // Get the recrd set associated with the current cell and bind it to the grid.
            grid.DataSource = e.CreateDrillDownDataSource();
            form.Bounds = new Rectangle(100, 100, 1000, 400);
            // Display the form.
            form.ShowDialog();
            form.Dispose();
        }

        private void check_WeeklyData_Properties_CheckedChanged(object sender, EventArgs e)
        {
            this.layoutControlDepartmentTeamID.ContentVisible = this.check_WeeklyData.Checked;
            this.layoutControlRefresh.ContentVisible =! this.check_WeeklyData.Checked;
           // this.layoutControlCheckDetail.ContentVisible = this.check_WeeklyData.Checked;

        }

        private void lke_DepartmentTeams_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            

                
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.pvgDailyKPI.DataSource = FileProcess.LoadTable("OperatingCostDailyParameters " + this.lke_MSS_StoreList.EditValue + "," + this.lke_OperatingCostMonthlyID.EditValue);
            this.pvgOperatingHours.DataSource = FileProcess.LoadTable("OperatingCostDailyParameterHours " + this.lke_MSS_StoreList.EditValue + "," + this.lke_OperatingCostMonthlyID.EditValue);
        }

        private void lke_DepartmentTeams_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            if (this.check_WeeklyData.Checked)
            {
                this.pvgDailyKPI.DataSource = FileProcess.LoadTable("OperatingCost_OWR_ViewByDepartmentTeamSummary " + this.lke_DepartmentTeams.EditValue + ",30," + AppSetting.StoreID);
                this.pvgOperatingHours.DataSource = FileProcess.LoadTable("OperatingCost_OWR_WorkingHOurDataByDepartmentTeam " + this.lke_DepartmentTeams.EditValue + "," + AppSetting.StoreID);
            }
        }
    }
}
