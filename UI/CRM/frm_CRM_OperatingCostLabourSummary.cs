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

namespace UI.CRM
{
    public partial class frm_CRM_OperatingCostLabourSummary : Form
    {
        public frm_CRM_OperatingCostLabourSummary()
        {
            InitializeComponent();
            DataProcess<Stores> storeDA = new DataProcess<Stores>();
            this.lke_MSS_StoreList.Properties.DataSource = storeDA.Select();
            this.lke_MSS_StoreList.Properties.ValueMember = "StoreID";
            this.lke_MSS_StoreList.Properties.DisplayMember = "StoreDescription";
            this.lke_MSS_StoreList.EditValue = 1;
            this.pvgOperatingCostLabourSummary.DataSource = FileProcess.LoadTable("OperatingCostLabourViewSummary " + this.lke_MSS_StoreList.EditValue);
        }

        private void pvgOperatingCostLabourSummary_CellClick(object sender, DevExpress.XtraPivotGrid.PivotCellEventArgs e)
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

        private void lke_MSS_StoreList_EditValueChanged(object sender, EventArgs e)
        {
            this.checkViewDetails.Checked = false;
            this.pvgOperatingCostLabourSummary.DataSource = FileProcess.LoadTable("OperatingCostLabourViewSummary " + this.lke_MSS_StoreList.EditValue);
        }

        private void checkViewDetails_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkViewDetails.Checked)
            {
                this.pvgOperatingCostLabourSummary.DataSource = FileProcess.LoadTable("OperatingCostLabourViewSummary  " + this.lke_MSS_StoreList.EditValue + ",1");
                this.FieldCustomerID.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
                this.FieldCustomerName.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
                this.FieldDLabour.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
                this.FieldDepartment.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
                this.FieldEName.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
                this.FieldID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
                this.FieldPosition.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
                this.FieldTeamName.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;


            }
            else
            {
                this.pvgOperatingCostLabourSummary.DataSource = FileProcess.LoadTable("OperatingCostLabourViewSummary " + this.lke_MSS_StoreList.EditValue);
                this.FieldCustomerID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
                this.FieldCustomerName.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
                this.FieldDLabour.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
                this.FieldDepartment.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
                this.FieldEName.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
                this.FieldID.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
                this.FieldPosition.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
                this.FieldTeamName.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            }
        }
    }
}
