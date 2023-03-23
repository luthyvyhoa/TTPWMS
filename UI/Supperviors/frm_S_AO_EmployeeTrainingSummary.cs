using DA;
using DevExpress.XtraPivotGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Supperviors
{
    public partial class frm_S_AO_EmployeeTrainingSummary : Form
    {
        public frm_S_AO_EmployeeTrainingSummary()
        {
            InitializeComponent();
            this.pvcEmployeeTrainingSummary.DataSource = FileProcess.LoadTable("ST_WMS_EmployeeTrainingAll");
        }

        private void pvcEmployeeTrainingSummary_CellClick(object sender, DevExpress.XtraPivotGrid.PivotCellEventArgs e)
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

        private void pvcEmployeeTrainingSummary_CustomDrawCell(object sender, DevExpress.XtraPivotGrid.PivotCustomDrawCellEventArgs e)
        {
            Rectangle r;

            if (e.RowValueType == PivotGridValueType.Total )
            {
                e.GraphicsCache.FillRectangle(new LinearGradientBrush(e.Bounds, Color.LightBlue,
            Color.Blue, LinearGradientMode.Vertical), e.Bounds);
                r = Rectangle.Inflate(e.Bounds, -3, -3);
                e.GraphicsCache.FillRectangle(new LinearGradientBrush(e.Bounds, Color.Blue,
                    Color.LightSkyBlue, LinearGradientMode.Vertical), r);
                e.GraphicsCache.DrawString(e.DisplayText, e.Appearance.Font,
                    new SolidBrush(Color.White), r, e.Appearance.GetStringFormat());
                e.Handled = true;
                return;
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            pvcEmployeeTrainingSummary.ShowPrintPreview();
        }
    }
}
