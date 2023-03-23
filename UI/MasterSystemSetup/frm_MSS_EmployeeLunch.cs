using Common.Controls;
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
using UI.ReportFile;

namespace UI.MasterSystemSetup
{
    public partial class frm_MSS_EmployeeLunch : frmBaseForm
    {
        byte shiftID = 1;
        byte departmentID = 1;
        public frm_MSS_EmployeeLunch()
        {
            InitializeComponent();
            this.Enabled = true;
            this.cboCa.SelectedIndex = 0;
            this.radgrCa.SelectedIndex = 0;
            this.LoadData();
        }

        private void LoadData()
        {
            DataProcess<STEmployeeLunch_Result> dataProcess = new DataProcess<STEmployeeLunch_Result>();
            this.grdLunch.DataSource = dataProcess.Executing("STEmployeeLunch @DepartmentID={0},@Shift={1}", this.departmentID, this.shiftID);
        }

        private void btnByRoom_Click(object sender, EventArgs e)
        {
            var dataSource = FileProcess.LoadTable("STEmployeeLunchReport @Shift=" + this.shiftID + ",@varStoreID=" + AppSetting.StoreID);
            //Display report rptEmployeeLunchByRoom
            rptEmployeeLunchByRoom rpt = new rptEmployeeLunchByRoom();
            ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
            rpt.DataSource = dataSource;
            tool.ShowPreviewDialog();
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            var dataSource = FileProcess.LoadTable("STEmployeeLunchReport @Shift=" + this.shiftID + ",@varStoreID=" + AppSetting.StoreID);
            // Display report rptEmployeeLunch
            rptEmployeeLunch rpt = new rptEmployeeLunch();
            ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
            rpt.DataSource = dataSource;
            tool.ShowPreviewDialog();
        }

        private void btnViewList_Click(object sender, EventArgs e)
        {
            DataProcess<object> dataProcess = new DataProcess<object>();
            dataProcess.ExecuteNoQuery("STEmployeeLunchSummaryInsert @Shift={0},@varStoreID={1}", this.shiftID, AppSetting.StoreID);
            var dataSource = FileProcess.LoadTable("STEmployeeLunchSummaryReport ");
            // Display report rptEmployeeLunchSummary
            rptEmployeeLunchSummary rpt = new rptEmployeeLunchSummary();
            rpt.RequestParameters = false;
            rpt.Parameters["paramShift"].Value = this.cboCa.Text;
            rpt.DataSource = dataSource;
            ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
            tool.ShowPreviewDialog();
        }

        private void btnPrintA5_Click(object sender, EventArgs e)
        {
            DataProcess<object> dataProcess = new DataProcess<object>();
            dataProcess.ExecuteNoQuery("STEmployeeLunchSummaryInsert @Shift={0},@varStoreID={1}", this.shiftID, AppSetting.StoreID);
            var dataSource = FileProcess.LoadTable("STEmployeeLunchSummaryReport ");
            // Display report rptEmployeeLunchSummary
            rptEmployeeLunchSummary rpt = new rptEmployeeLunchSummary();
            rpt.RequestParameters = false;
            rpt.Parameters["paramShift"].Value = this.cboCa.Text;
            rpt.DataSource = dataSource;
            ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
            tool.Print();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboCa_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.shiftID = Convert.ToByte(this.cboCa.SelectedIndex + 1);
            this.LoadData();
        }

        private void radgrCa_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.departmentID = Convert.ToByte(radgrCa.EditValue);
            this.LoadData();
        }
    }
}
