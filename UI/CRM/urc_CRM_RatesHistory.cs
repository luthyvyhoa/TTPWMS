using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.CRM
{
    public partial class urc_CRM_RatesHistory : UserControl
    {
        public urc_CRM_RatesHistory(int CustomerID)
        {
            InitializeComponent();
            this.pvgRatesHistory.DataSource = DA.FileProcess.LoadTable("OperatingCostSummary_RatesHistory " + CustomerID);
        }
        public void InitRateHistory (int CustomerID)
        {
            this.pvgRatesHistory.DataSource = DA.FileProcess.LoadTable("OperatingCostSummary_RatesHistory " + CustomerID);
        }

        private void pvgRatesHistory_CellClick(object sender, DevExpress.XtraPivotGrid.PivotCellEventArgs e)
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
