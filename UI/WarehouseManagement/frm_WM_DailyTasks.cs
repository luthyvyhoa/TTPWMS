using DA;
using DevExpress.XtraEditors;
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

namespace UI.WarehouseManagement
{
    public partial class frm_WM_DailyTasks : Common.Controls.frmBaseForm
    {
        private DataProcess<DailyTask> _taskDA;
        private BindingList<DailyTask> _listTasks;
        private bool _isModified;
        private int _lastUpdateRow;

        public frm_WM_DailyTasks()
        {
            InitializeComponent();
            this._taskDA = new DataProcess<DailyTask>();
            this._isModified = false;
            this._lastUpdateRow = -1;
        }

        private void frm_WM_DailyTasks_Load(object sender, EventArgs e)
        {
            LoadTask();
            SetEvents();
        }

        private void SetEvents()
        {
            this.rpi_chk_Sticky.EditValueChanging += Rpi_chk_Sticky_EditValueChanging;
            this.rpi_chk_TaskDone.CheckedChanged += Rpi_chk_TaskDone_CheckedChanged;
            this.grvDailyTask.InitNewRow += GrvDailyTask_InitNewRow;
            this.grvDailyTask.FocusedRowChanged += GrvDailyTask_FocusedRowChanged;
            this.grvDailyTask.CellValueChanged += GrvDailyTask_CellValueChanged;
            this.btnChecklistForGuard.Click += BtnChecklistForGuard_Click;
            this.btnChecklist.Click += BtnChecklist_Click;
        }

        private void Rpi_chk_Sticky_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            string userID = Convert.ToString(this.grvDailyTask.GetFocusedRowCellValue("UserID"));

            if(!AppSetting.CurrentUser.LoginName.Equals(userID))
            {
                XtraMessageBox.Show("Can not update !, Only the author of this task can do this job !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }

        private void Rpi_chk_TaskDone_CheckedChanged(object sender, EventArgs e)
        {
            CheckEdit edit = sender as CheckEdit;

            if (edit.Checked)
            {
                this.grvDailyTask.SetFocusedRowCellValue("DoneBy", AppSetting.CurrentUser.LoginName);
                this.grvDailyTask.SetFocusedRowCellValue("DoneTime", DateTime.Now);
            }
            else
            {
                this.grvDailyTask.SetFocusedRowCellValue("DoneBy", "Clear");
                this.grvDailyTask.SetFocusedRowCellValue("DoneTime", null);
            }
        }

        private void GrvDailyTask_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            this.grvDailyTask.SetRowCellValue(e.RowHandle, "TaskCreatedTime", DateTime.Now);
            this.grvDailyTask.SetRowCellValue(e.RowHandle, "UserID", AppSetting.CurrentUser.LoginName);
            this.grvDailyTask.SetRowCellValue(e.RowHandle, "Forguard", true);
        }

        private void GrvDailyTask_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            int result = -2;

            if(this.grvDailyTask.IsNewItemRow(e.FocusedRowHandle))
            {
                this.grcDescription.OptionsColumn.ReadOnly = false;
            }
            else
            {
                this.grcDescription.OptionsColumn.ReadOnly = true;
            }

            if (this.grvDailyTask.IsNewItemRow(e.PrevFocusedRowHandle))
            {
               result = this._taskDA.Insert(this._listTasks.FirstOrDefault()); 
            }

            if(this._isModified)
            {
                DailyTask task = this.grvDailyTask.GetRow(this._lastUpdateRow) as DailyTask;
                result = this._taskDA.Update(task);
                this._isModified = false;
            }

        }

        private void GrvDailyTask_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!this.grvDailyTask.IsNewItemRow(e.RowHandle))
            {
                this._isModified = true;
                this._lastUpdateRow = e.RowHandle;
            }
        }

        private void BtnChecklistForGuard_Click(object sender, EventArgs e)
        {
            DataProcess<STContainerCheckingReport_Result> reportDA = new DataProcess<STContainerCheckingReport_Result>();

            rptContainerCheckingForGuard rpt = new rptContainerCheckingForGuard();
            rpt.DataSource = FileProcess.LoadTable("STContainerCheckingReport");
            ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
            tool.ShowPreview();
        }

        private void BtnChecklist_Click(object sender, EventArgs e)
        {
            DataProcess<STContainerCheckingReport_Result> reportDA = new DataProcess<STContainerCheckingReport_Result>();

            rptContainerChecking rpt = new rptContainerChecking();
            rpt.DataSource = reportDA.Executing("STContainerCheckingReport @LoginName = {0}", AppSetting.CurrentUser.LoginName);
            ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
            tool.ShowPreview();
        }

        private void LoadTask()
        {
            DateTime date = DateTime.Now.AddDays(-7);
            this._listTasks = new BindingList<DailyTask>(this._taskDA.Select().Where(t => ((t.TaskCreatedTime > date) && (t.Forguard == true)) || ((t.TaskDone = false) && (t.Forguard == true)) || ((t.Sticky == true) && (t.Forguard == true))).OrderBy(t => t.Sticky).ToList());
            this.grdDailyTask.DataSource = this._listTasks;
        }
    }
}
