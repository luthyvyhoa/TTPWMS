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

namespace UI.MasterSystemSetup
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Init_Stores();
        }
        private void Init_Stores()
        {
            DataProcess<Stores> loadStoreInfo = new DataProcess<Stores>();
            this.rpi_lke_warehouse.DataSource = loadStoreInfo.Select();
            this.rpi_lke_warehouse.ValueMember = "StoreID";
            this.rpi_lke_warehouse.DisplayMember = "StoreDescription";
        }
        private void Init_Shift()
        {
            DataProcess<Shifts> loadShiftInfo = new DataProcess<Shifts>();
            var shiftInfo = loadShiftInfo.Select();
            this.rpi_lkeShift.DataSource = shiftInfo;
            this.rpi_lkeShift.ValueMember = "ShiftID";
            this.rpi_lkeShift.DisplayMember = "ShiftValue";
        }

        private void pivotGridControl1_CellClick(object sender, DevExpress.XtraPivotGrid.PivotCellEventArgs e)
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
