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

namespace UI.Supperviors
{
    public partial class frm_S_AO_Dialog_GateCustomerLaborSafetyTrainingInOut : Common.Controls.frmBaseForm
    {
        public frm_S_AO_Dialog_GateCustomerLaborSafetyTrainingInOut()
        {
            InitializeComponent();
        }

        private void frm_S_AO_Dialog_GateCustomerLaborSafetyTrainingInOut_Load(object sender, EventArgs e)
        {
            LoadWorkerInOut(0);
            SetEvents();
        }

        private void SetEvents()
        {
            this.grvWorkerInOut.RowCellStyle += GrvWorkerInOut_RowCellStyle;
            this.rpi_txt_Remark.DoubleClick += Rpi_txt_Remark_DoubleClick;
            this.rpi_btn_TrainingAdd.Click += Rpi_btn_TrainingAdd_Click;
        }

        private void GrvWorkerInOut_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName.Equals("WorkerID"))
            {
                bool training = Convert.ToBoolean(this.grvWorkerInOut.GetRowCellValue(e.RowHandle, "LaborSafetyTrainingEx"));
                if (!training)
                {
                    e.Appearance.BackColor = Color.Red;
                }
            }
        }

        private void Rpi_txt_Remark_DoubleClick(object sender, EventArgs e)
        {
            DataProcess<object> trainingDA = new DataProcess<object>();
            int inOutID = Convert.ToInt32(this.grvWorkerInOut.GetFocusedRowCellValue("WorkerRegularInOutID"));
            string newRemark = XtraInputBox.Show("Xin nhap vao ghi chu moi : ", "Gate Control", "Ghi chu");

            if(!String.IsNullOrEmpty(newRemark))
            {
                int result = trainingDA.ExecuteNoQuery("Update Gate_WorkerRegularInOut SET Remark = {0} Where WorkerRegularInOutID = {1}", "~" + AppSetting.CurrentUser.LoginName + "-" + newRemark, inOutID);
                LoadWorkerInOut(this.grvWorkerInOut.FocusedRowHandle);
            }
        }

        private void Rpi_btn_TrainingAdd_Click(object sender, EventArgs e)
        {
            int safetyTraining = Convert.ToInt32(this.grvWorkerInOut.GetFocusedRowCellValue("LaborSafetyTraining"));
            if (safetyTraining == 1)
            {
                return;
            }
            if (XtraMessageBox.Show("Da tao tao ATLD cho cong nhan nay ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataProcess<object> trainingDA = new DataProcess<object>();
                int workerID = Convert.ToInt32(this.grvWorkerInOut.GetFocusedRowCellValue("WorkerID"));

                int result = trainingDA.ExecuteNoQuery("STGate_WorkerLaborSafetyTrainingInsert @WorkerID = {0}, @LaborSafetyTrainBy = {1}, @LaborSafetyTrainDate = {2}, @Description = {3}", workerID, AppSetting.CurrentUser.LoginName, DateTime.Now, null);

                LoadWorkerInOut(0);
            }
        }

        private void LoadWorkerInOut(int row)
        {
            DataProcess<STGate_WorkerRegularInOutRemain_Result> workerDA = new DataProcess<STGate_WorkerRegularInOutRemain_Result>();
            this.grdWorkerInOut.DataSource = FileProcess.LoadTable("STGate_WorkerRegularInOutRemain");
            this.grvWorkerInOut.FocusedRowHandle = row;
        }
    }
}
