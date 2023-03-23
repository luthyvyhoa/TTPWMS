using System;
using System.Windows.Forms;
using DA;
using System.Linq;
using UI.ReportForm;
using System.Drawing;
using UI.Helper;

namespace UI.CRM
{
    public partial class urc_CRM_ActiveContracts : UserControl
    {
        //private frm_BR_OtherServices otherServiceForm;
        private int customerID = 0;
        public urc_CRM_ActiveContracts(int customerID)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.customerID = customerID;
            InitActiveContracts(customerID);


        }
        public void InitActiveContracts(int customerID)
        {
            this.pvgActiveContracts.DataSource = FileProcess.LoadTable("STContractActive " + customerID);
        }

        private void pvgActiveContracts_CellClick(object sender, DevExpress.XtraPivotGrid.PivotCellEventArgs e)
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

        private void btnCreateNewContracts_Click(object sender, EventArgs e)
        {
            //Code here to duplicate contract
            DateTime LastVavidContractDate;

        }
    }
}
