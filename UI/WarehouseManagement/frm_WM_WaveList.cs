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
namespace UI.WarehouseManagement
{
    public partial class frm_WM_WaveList : Form
    {
        /// <summary>
        /// Definition format type of date time
        /// </summary>
        private static readonly string DATE_FORMAT = "yyyy-MM-dd";

        public frm_WM_WaveList()
        {
            InitializeComponent();
            this.dateEditToDate.EditValue = DateTime.Today;
            this.dateEditFromDate.EditValue = DateTime.Today;
            String FromDate = Convert.ToDateTime(dateEditFromDate.EditValue.ToString()).ToString(DATE_FORMAT);
            String ToDate = Convert.ToDateTime(dateEditToDate.EditValue.ToString()).ToString(DATE_FORMAT);
            this.grdVaveOperationList.DataSource = FileProcess.LoadTable("STWavePickingList @FromDate='" + FromDate + "',@Todate='" + ToDate + "',@StoreID=" + AppSetting.StoreID);
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            String FromDate = Convert.ToDateTime(dateEditFromDate.EditValue.ToString()).ToString(DATE_FORMAT);
            String ToDate = Convert.ToDateTime(dateEditToDate.EditValue.ToString()).ToString(DATE_FORMAT);

            this.grdVaveOperationList.DataSource = FileProcess.LoadTable("STWavePickingList @FromDate='" + FromDate + "',@Todate='" + ToDate + "',@StoreID=" + AppSetting.StoreID);

        }

        private void rph_WavePickingID_Click(object sender, EventArgs e)
        {
            Int32 WaveID = Convert.ToInt32(this.grvWaveOperationListView.GetFocusedRowCellValue("WavePickingID").ToString());
            frm_WM_WavePicking frmW = new frm_WM_WavePicking(WaveID);
            frmW.Show();
            frmW.BringToFront();
        }

        private void dateEditFromDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.KeyCode.Equals(Keys.Enter)) return;
            this.btn_Refresh_Click(sender,e);
        }

        private void grvWaveOperationListView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (!e.Column.FieldName.Equals("WavePickingNumber")) return;
            this.rph_WavePickingID_Click(sender, e);
        }

        private void grvWaveOperationListView_ShowingEditor(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
