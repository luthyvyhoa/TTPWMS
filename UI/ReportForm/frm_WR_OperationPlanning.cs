using DA;
using DevExpress.XtraEditors;
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
using UI.WarehouseManagement;

namespace UI.ReportForm
{
    public partial class frm_WR_OperationPlanning : Form
    {
        public frm_WR_OperationPlanning()
        {
            InitializeComponent();
            this.dateEditReportDate.EditValue = DateTime.Now.ToShortDateString();
            this.lke_WarehouseID.Properties.DataSource = FileProcess.LoadTable("SELECT WarehouseID, WarehouseDescription From Warehouses WHERE StoreID = " + AppSetting.StoreID);
            this.lke_WarehouseID.Properties.ValueMember = "WarehouseID";
            this.lke_WarehouseID.Properties.DisplayMember = "WarehouseDescription";
            this.lke_WarehouseID.ItemIndex = 0;
            //XtraMessageBox.Show("STOperationPlanning " + AppSetting.StoreID + ", '" + DateTime.Now.ToString("yyyy-MM-dd") + "'");
            if (this.lke_WarehouseID.EditValue != null)
            {
                this.pvgOperationPlanning.DataSource = FileProcess.LoadTable("STOperationPlanning " + AppSetting.StoreID + "'" + DateTime.Now.ToString("yyyy-MM-dd") + "'," + this.lke_WarehouseID.EditValue.ToString());
            }
            //else
            //{
            //    this.pvgOperationPlanning.DataSource = FileProcess.LoadTable("STOperationPlanning " + AppSetting.StoreID + "'" + DateTime.Now.ToString("yyyy-MM-dd") + "'," + this.lke_WarehouseID.EditValue.ToString());
            //}
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            if (this.lke_WarehouseID.EditValue != null)
            {
                this.pvgOperationPlanning.DataSource = FileProcess.LoadTable("STOperationPlanning " + AppSetting.StoreID + ", '" + Convert.ToDateTime(dateEditReportDate.EditValue).Date.ToString("yyyy-MM-dd") + "'," + this.lke_WarehouseID.EditValue.ToString());
                //XtraMessageBox.Show("STOperationPlanning " + AppSetting.StoreID + "'" + this.dateEditReportDate.EditValue.ToString() + "'");
            }
            else
            {
                this.pvgOperationPlanning.DataSource = FileProcess.LoadTable("STOperationPlanning " + AppSetting.StoreID + ", '" + Convert.ToDateTime(dateEditReportDate.EditValue).Date.ToString("yyyy-MM-dd") + "'");

            }
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            this.pvgOperationPlanning.ShowPrintPreview();
        }

        private void pvgOperationPlanning_CellClick(object sender, DevExpress.XtraPivotGrid.PivotCellEventArgs e)
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
                pvgOperationPlanning.ExportToXlsx(sfd.FileName, pivotExportOptions);
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

        private void btnNewBooking_Click(object sender, EventArgs e)
        {
            frm_WM_CustomerBookingEntry frm = new frm_WM_CustomerBookingEntry();
            frm.Show();
            frm.WindowState = FormWindowState.Normal;
        }

        private void btnReviewOrders_Click(object sender, EventArgs e)
        {
            frm_WR_OperationPlanning_OrderReview frm = new frm_WR_OperationPlanning_OrderReview();
            frm.Show();
            frm.WindowState = FormWindowState.Normal;
        }
    }
}
