using System.Windows.Forms;
using Common.Controls;
using System.Linq;
using System;
using DA;
using UI.Helper;
using UI.ReportFile;
using DevExpress.XtraReports.UI;

namespace UI.Management
{
    public partial class frm_M_DW_StockOnHandAverage : frmBaseForm
    {
        public frm_M_DW_StockOnHandAverage()
        {
            InitializeComponent();
        }

        private void frm_M_DW_StockOnHandAverage_Load(object sender, EventArgs e)
        {
            var currentDate = DateTime.Now;
            this.d_M_From.DateTime = new DateTime(currentDate.Year, currentDate.Month, 1);
            this.d_M_To.DateTime = currentDate;
        }

        private void btn_M_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_M_ReportByDate_Click(object sender, EventArgs e)
        {
            // This report is not do it
        }

        private void btn_M_ReportByRoom_Click(object sender, EventArgs e)
        {
            rptStockOnHandByRoomAverage rpt = new rptStockOnHandByRoomAverage(this.d_M_From.DateTime, this.d_M_To.DateTime);
            string fromDate = this.d_M_From.DateTime.ToString("yyyy-MM-dd");
            string toDate = this.d_M_To.DateTime.ToString("yyyy-MM-dd");
            rpt.DataSource = FileProcess.LoadTable("ST_WMS_StockOnHandByRoomAverageReport @FromDate='" + fromDate + "',@ToDate='" + toDate + "'");
            rpt.ShowPreviewDialog();
        }
    }
}
