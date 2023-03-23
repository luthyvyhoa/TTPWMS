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

namespace UI.ReportForm
{
    public partial class frm_WR_Dialog_TaskHistories : Common.Controls.frmBaseForm
    {
        private int _taskID;

        public frm_WR_Dialog_TaskHistories(int taskID)
        {
            InitializeComponent();
            this._taskID = taskID;
        }

        private void frm_WR_Dialog_TaskHistories_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            this.grdTaskHistory.DataSource = FileProcess.LoadTable("SELECT TaskHistories.TaskHistoryID, Reports.ReportName, TaskHistories.SentTime"
                                                                  + " FROM(Tasks INNER JOIN Reports ON Tasks.ReportID = Reports.ReportID) INNER JOIN TaskHistories ON Tasks.TaskID = TaskHistories.TaskID"
                                                                  + " WHERE(((TaskHistories.TaskID) = "+this._taskID+"))"
                                                                  + " ORDER BY TaskHistories.SentTime DESC; ");
        }
    }
}
