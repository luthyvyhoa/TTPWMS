using DA;
using DevExpress.XtraReports.UI;
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
using UI.ReportFile;
using UI.WarehouseManagement;

namespace UI.Management
{
    public partial class frm_M_DW_SummaryInOutByDate : Common.Controls.frmBaseForm
    {
        public frm_M_DW_SummaryInOutByDate()
        {
            InitializeComponent();
            this.dtFrom.EditValue = DateTime.Now.AddDays(-30);
            this.dtTo.EditValue = DateTime.Now;
        }

        private void frm_M_DW_SummaryInOutByDate_Load(object sender, EventArgs e)
        {
            LoadSummary();
            SetEvents();
        }

        private void SetEvents()
        {
            this.dtFrom.EditValueChanging += DtFrom_EditValueChanging;
            this.dtTo.EditValueChanging += DtTo_EditValueChanging;
            this.rpi_btn_OpenDate.Click += Rpi_btn_OpenDate_Click;
            this.btnReport.Click += BtnReport_Click;
            this.btnRefresh.Click += BtnRefresh_Click;
           
        }

        private void DtFrom_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (Convert.ToDateTime(e.NewValue) > this.dtTo.DateTime)
            {
                e.Cancel = true;
            }

        }

        private void DtTo_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if(Convert.ToDateTime(e.NewValue) < this.dtFrom.DateTime)
            {
                e.Cancel = true;
            }

        }

        private void Rpi_btn_OpenDate_Click(object sender, EventArgs e)
        {
            DateTime date = Convert.ToDateTime(this.grvSummary.GetFocusedRowCellValue("ReportDate"));
            frm_WM_InOutViewByDate.Instance.ViewRODOByDate(date);
            frmMain.Instance.BringToFront();
        }

        private void BtnReport_Click(object sender, EventArgs e)
        {
            rptHandlingByDate rpt = new rptHandlingByDate(this.dtFrom.DateTime, this.dtTo.DateTime);
            rpt.DataSource = this.grdSummary.DataSource;
            ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
            tool.ShowPreview();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadSummary();
        }

        private void BtnWeekly_Click(object sender, EventArgs e)
        {
            //OpenForm "frmHandlingChartWeekly"
        }

        private void BtnDaily_Click(object sender, EventArgs e)
        {
            //OpenForm "frmHandlingChartDaily"
        }

        private void LoadSummary()
        {
            this.grdSummary.DataSource = FileProcess.LoadTable("STInOutViewSummary @varFromdate = '"+this.dtFrom.DateTime.ToString("yyyy-MM-dd")+ "', @varTodate = '" + this.dtTo.DateTime.ToString("yyyy-MM-dd") + "', @varStoreID = " + AppSetting.StoreID);
        }

		private void dtTo_EditValueChanged(object sender, EventArgs e)
		{
            LoadSummary();


        }

        private void dtFrom_EditValueChanged(object sender, EventArgs e)
		{
            LoadSummary();

        }
    }
}
