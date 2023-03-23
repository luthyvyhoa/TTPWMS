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

namespace UI.Supperviors
{
    public partial class frm_S_EmployeeDailyPerformanceSummary : Form
    {
        int StoreID = AppSetting.StoreID;

        public frm_S_EmployeeDailyPerformanceSummary()
        {
            InitializeComponent();
            DataProcess<Stores> storeDA = new DataProcess<Stores>();
            this.lke_MSS_StoreList.Properties.DataSource = storeDA.Select();
            this.lke_MSS_StoreList.Properties.ValueMember = "StoreID";
            this.lke_MSS_StoreList.Properties.DisplayMember = "StoreDescription";
            this.lke_MSS_StoreList.EditValue = StoreID;

            this.dateEditDateTo.EditValue = DateTime.Now;
            this.dateEditDateFrom.EditValue = DateTime.Now.AddDays(-30);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            string dateFrom = Convert.ToDateTime(dateEditDateFrom.EditValue).Date.ToString("yyyy-MM-dd");
            string dateTo = Convert.ToDateTime(dateEditDateTo.EditValue).Date.ToString("yyyy-MM-dd");
            this.pvgEmployeeDailyPerformanceSummary.DataSource = FileProcess.LoadTable("STEmployeeWorkingDailyPerformanceAllFDTD '" + dateFrom + "','" + dateTo + "'," + this.lke_MSS_StoreList.EditValue + ",0");
        }

        private void btnFreshDetail_Click(object sender, EventArgs e)
        {
            int duration = (Convert.ToDateTime(dateEditDateTo.EditValue).Date - Convert.ToDateTime(dateEditDateFrom.EditValue).Date).Days;
            if ( duration >31 )
            {
                MessageBox.Show("Too long duration, please reduce");
                return;
            }
            else
            {
                string dateFrom = Convert.ToDateTime(dateEditDateFrom.EditValue).Date.ToString("yyyy-MM-dd");
                string dateTo = Convert.ToDateTime(dateEditDateTo.EditValue).Date.ToString("yyyy-MM-dd");
                this.pvgEmployeeDailyPerformanceSummary.DataSource = FileProcess.LoadTable("STEmployeeWorkingDailyPerformanceAllFDTD '" + dateFrom + "','" + dateTo + "'," + this.lke_MSS_StoreList.EditValue + ",1");

            }
        }

        private void pvgEmployeeDailyPerformanceSummary_CellClick(object sender, DevExpress.XtraPivotGrid.PivotCellEventArgs e)
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
    }
}
