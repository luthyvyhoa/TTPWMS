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
    public partial class frm_S_EmployeeScannedTaskReview : Form
    {
        public frm_S_EmployeeScannedTaskReview()
        {
            InitializeComponent();
            this.dateEditFromDate.EditValue = DateTime.Today;
            this.dateEditTodate.EditValue = DateTime.Today;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            string fdate = Convert.ToDateTime(dateEditFromDate.EditValue).Date.ToString("yyyy-MM-dd");
            string tdate = Convert.ToDateTime(dateEditTodate.EditValue).Date.ToString("yyyy-MM-dd");
            this.pvgEmployeeScannedData.DataSource = FileProcess.LoadTable("ST_WMS_LoadScannedData '" + fdate + "','" + tdate + "'," + AppSetting.StoreID);
        }

        private void pvgEmployeeScannedData_CellClick(object sender, DevExpress.XtraPivotGrid.PivotCellEventArgs e)
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
