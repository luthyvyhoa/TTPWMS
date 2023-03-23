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
    public partial class frm_WM_Dialog_WavePickingSummary : Form
    {
        public frm_WM_Dialog_WavePickingSummary(int WavePickingID)
        {

            InitializeComponent();
            var pickingSummary = FileProcess.LoadTable("STWavePickingSummary @WavePickingID=" + WavePickingID);
            this.pivotPickingSummary.DataSource = pickingSummary;
            this.textEdit1.EditValue = Convert.ToString(pickingSummary.Rows[0][5]);
            this.textEdit3.EditValue = Convert.ToString(pickingSummary.Rows[0][0]);
        }

        private void pivotPickingSummary_CellClick(object sender, DevExpress.XtraPivotGrid.PivotCellEventArgs e)
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

        private void btnPreview_Click(object sender, EventArgs e)
        {
            this.pivotPickingSummary.ShowPrintPreview();
        }

        private void simpleButtonExportExcel_Click(object sender, EventArgs e)
        {

            var pivotExportOptions = new DevExpress.XtraPivotGrid.PivotXlsxExportOptions();
            pivotExportOptions.ExportType = DevExpress.Export.ExportType.DataAware;
            SaveFileDialog sfd = new SaveFileDialog();
            //sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            sfd.Filter = "Excel 97-2003 (*.xls)|*.xls|Excel 07-2010 (*.xlsx)|*.xlsx";

            DialogResult dr = sfd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                pivotPickingSummary.ExportToXlsx(sfd.FileName, pivotExportOptions);
                try
                {
                    System.Diagnostics.Process.Start("Excel", sfd.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            sfd.Dispose();
            
        }
    }
}
