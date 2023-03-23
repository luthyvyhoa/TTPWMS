using System;
using System.Windows.Forms;
using DA;
using System.Linq;
using UI.ReportForm;
using System.Drawing;

namespace UI.CRM
{
    public partial class urc_CRM_RelatedQuotations : UserControl
    {
        //private frm_BR_OtherServices otherServiceForm;
        private int customerID = 0;
        private int quotationID = 0;
        public urc_CRM_RelatedQuotations(int customerID)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.customerID = customerID;
            
            this.InitData(this.customerID);
        }

        public void InitData(int customerID)
        {
            var dataSource = FileProcess.LoadTable("STCustomerQuotationSummary " + customerID);
            this.pvgCustomerQuotations.DataSource = dataSource;
        }

        private void pvgCustomerQuotations_CellClick(object sender, DevExpress.XtraPivotGrid.PivotCellEventArgs e)
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
