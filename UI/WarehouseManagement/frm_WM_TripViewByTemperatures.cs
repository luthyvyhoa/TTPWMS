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

namespace UI.WarehouseManagement
{
    public partial class frm_WM_TripViewByTemperatures : Form
    {
        public frm_WM_TripViewByTemperatures(String ReportDate, Int32 CustomerID)
        {
            InitializeComponent();
            this.pvgTripSummaryByTemperature.DataSource = FileProcess.LoadTable("STTripPickingListSummaryPerDay '" + ReportDate +"','" + ReportDate + "'," + CustomerID);
        }

        private void pvgTripSummaryByTemperature_CellClick(object sender, DevExpress.XtraPivotGrid.PivotCellEventArgs e)
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
