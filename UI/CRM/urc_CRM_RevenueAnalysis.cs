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
    public partial class urc_CRM_RevenueAnalysis : UserControl
    {
        private int customerID = 0;
        public urc_CRM_RevenueAnalysis(int CustomerID)
        {
            InitializeComponent();
            this.pvgRevenue12Months.DataSource = FileProcess.LoadTable("OperatingCost12Months_ViewByRevenues " + CustomerID);
            customerID = CustomerID;
        }

        public void initRev(int CustomerID)
        {
            this.pvgRevenue12Months.DataSource = FileProcess.LoadTable("OperatingCost12Months_ViewByRevenues " + CustomerID);
        }

        private void pvgRevenue12Months_CellClick(object sender, DevExpress.XtraPivotGrid.PivotCellEventArgs e)
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

        private void checkShowWMSData_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkShowWMSData.Checked)
            {
                this.pvgRevenue12Months.DataSource = FileProcess.LoadTable("OperatingCost12Months_ViewByRevenuesWMS " + customerID);
            }
            else
            {
                this.pvgRevenue12Months.DataSource = FileProcess.LoadTable("OperatingCost12Months_ViewByRevenues " + customerID);
            }
        }
    }
}
