using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DA;

namespace UI.CRM
{
    public partial class urc_CRM_TotalLabourAnalysis : UserControl
    {
        public urc_CRM_TotalLabourAnalysis(int customerID)
        {
            InitializeComponent();
            this.pvgTotalLabourAnalysis.DataSource = FileProcess.LoadTable("OperatingCostMonthly_ViewByCustomerEmployees 0," + customerID);
        }

        private void pivotGridControl1_CellClick(object sender, DevExpress.XtraPivotGrid.PivotCellEventArgs e)
        {
            Form form = new Form();
            form.Text = "Records";
            // Place a DataGrid control on the form.
            DataGrid grid = new DataGrid();
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
