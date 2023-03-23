using Common.Process;
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
    public partial class frm_S_AO_Dialog_GateCustomerWorkerAll : Common.Controls.frmBaseForm
    {
        private DataProcess<STGate_WorkerRegularAll_Result> _workerDA;
        private List<STGate_WorkerRegularAll_Result> _listWorkers;
        private byte _filterMode;

        public frm_S_AO_Dialog_GateCustomerWorkerAll()
        {
            InitializeComponent();
            this._workerDA = new DataProcess<STGate_WorkerRegularAll_Result>();
            this._listWorkers = new List<STGate_WorkerRegularAll_Result>();
            this._filterMode = 0;
        }

        private void frm_S_AO_Dialog_GateCustomerWorkerAll_Load(object sender, EventArgs e)
        {
            InitCompanies();
            this._listWorkers = this._workerDA.Executing("STGate_WorkerRegularAll").ToList();
            LoadWorkerAll();
            SetEvents();
        }

        private void SetEvents()
        {
            this.grvWorkerAll.RowCellStyle += GrvWorkerAll_RowCellStyle;
            this.rpi_btn_TrainingAdd.Click += Rpi_btn_TrainingAdd_Click;
            this.lkeCompany.CloseUp += LkeCompany_CloseUp;
            this.txtCardID.Leave += TxtCardID_Leave;
            this.txtCardID.KeyDown += TxtCardID_KeyDown;
            this.chkAll.EditValueChanging += CheckedChanging;
            this.chkAll.CheckedChanged += CheckedChanged;
            this.chkCardID.EditValueChanging += CheckedChanging;
            this.chkCardID.CheckedChanged += CheckedChanged;
            this.chkWorkerID.EditValueChanging += CheckedChanging;
            this.chkWorkerID.CheckedChanged += CheckedChanged;
            this.chkWorkerName.EditValueChanging += CheckedChanging;
            this.chkWorkerName.CheckedChanged += CheckedChanged;
            this.chkCompany.EditValueChanging += CheckedChanging;
            this.chkCompany.CheckedChanged += CheckedChanged;
        }

        #region Events
        private void GrvWorkerAll_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if(e.Column.FieldName.Equals("WorkerID"))
            {
                bool training = Convert.ToBoolean(this.grvWorkerAll.GetRowCellValue(e.RowHandle, "LaborSafetyTrainingEx"));
                if(!training)
                {
                    e.Appearance.BackColor = Color.Red;
                }
            }
        }

        private void Rpi_btn_TrainingAdd_Click(object sender, EventArgs e)
        {
            int safetyTraining = Convert.ToInt32(this.grvWorkerAll.GetFocusedRowCellValue("LaborSafetyTraining"));
            if (safetyTraining == 1)
            {
                return;
            }
            if (XtraMessageBox.Show("Da tao tao ATLD cho cong nhan nay ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int workerID = Convert.ToInt32(this.grvWorkerAll.GetFocusedRowCellValue("WorkerID"));

                int result = this._workerDA.ExecuteNoQuery("STGate_WorkerLaborSafetyTrainingInsert @WorkerID = {0}, @LaborSafetyTrainBy = {1}, @LaborSafetyTrainDate = {2}, @Description = {3}", workerID, AppSetting.CurrentUser.LoginName, DateTime.Now, null);

                RefreshData();
            }
        }

        private void LkeCompany_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            Wait.Start(this);
            this.lkeCompany.EditValue = e.Value;
            this._listWorkers = this._workerDA.Executing("STGate_WorkerRegularAll @CompanyID = {0}, @CardID = {1}", Convert.ToInt32(this.lkeCompany.EditValue), null).ToList();
            LoadWorkerAll();
            Wait.Close();
        }

        private void TxtCardID_Leave(object sender, EventArgs e)
        {
            if (this.txtCardID.IsModified)
            {
                Wait.Start(this);
                this._listWorkers = this._workerDA.Executing("STGate_WorkerRegularAll @CompanyID = {0}, @CardID = {1}", null, this.txtCardID.Text).ToList();
                LoadWorkerAll();
                Wait.Close();
            }
        }

        private void TxtCardID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Wait.Start(this);
                this._listWorkers = this._workerDA.Executing("STGate_WorkerRegularAll @CompanyID = {0}, @CardID = {1}", null, this.txtCardID.Text).ToList();
                LoadWorkerAll();
                Wait.Close();
            }
        }

        private void CheckedChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            CheckEdit edit = sender as CheckEdit;

            if (!Convert.ToBoolean(e.NewValue))
            {
                if (this._filterMode == Convert.ToByte(edit.Tag))
                {
                    e.Cancel = true;
                }
            }
        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            CheckEdit edit = sender as CheckEdit;

            if (edit.Checked)
            {
                byte prevFilter = this._filterMode;
                this._filterMode = Convert.ToByte(edit.Tag);
                UnCheckedFilter(prevFilter);
                FilterModeChanged();
            }
        }
        #endregion

        #region Load Data
        private void LoadWorkerAll()
        {
            this.grdWorkerAll.DataSource = this._listWorkers;
        }

        private void RefreshData()
        {
            Wait.Start(this);
            switch (this._filterMode)
            {
                case 0:
                    {
                        this._listWorkers = this._workerDA.Executing("STGate_WorkerRegularAll").ToList();
                        LoadWorkerAll();
                        break;
                    }
                case 1:
                    {
                        this._listWorkers = this._workerDA.Executing("STGate_WorkerRegularAll @CompanyID = {0}, @CardID = {1}", 0, this.txtCardID.Text).ToList();
                        LoadWorkerAll();
                        break;
                    }
                case 4:
                    {
                        this._listWorkers = this._workerDA.Executing("STGate_WorkerRegularAll @CompanyID = {0}, @CardID = {1}", Convert.ToInt32(this.lkeCompany.EditValue), null).ToList();
                        LoadWorkerAll();
                        break;
                    }
            }
            Wait.Close();
        }

        private void InitCompanies()
        {
            this.lkeCompany.Properties.DataSource = FileProcess.LoadTable("SELECT Gate_Companies.CompanyID, Gate_Companies.CompanyNumber, Gate_Companies.CompanyName FROM Gate_Companies ORDER BY Gate_Companies.CompanyName");
            this.lkeCompany.Properties.ValueMember = "CompanyID";
            this.lkeCompany.Properties.DisplayMember = "CompanyName";
        }
        #endregion

        private void UnCheckedFilter(byte prevFilter)
        {
            switch(prevFilter)
            {
                case 0:
                    {
                        this.chkAll.Checked = false;
                        break;
                    }
                case 1:
                    {
                        this.chkCardID.Checked = false;
                        this.txtCardID.ReadOnly = true;
                        break;
                    }
                case 2:
                    {
                        this.chkWorkerID.Checked = false;
                        this.txtWorkerID.ReadOnly = true;
                        break;
                    }
                case 3:
                    {
                        this.chkWorkerName.Checked = false;
                        this.txtName.ReadOnly = true;
                        break;
                    }
                case 4:
                    {
                        this.chkCompany.Checked = false;
                        this.lkeCompany.ReadOnly = true;
                        break;
                    }
            }
        }

        private void FilterModeChanged()
        {
            switch (this._filterMode)
            {
                case 0:
                    {
                        Wait.Start(this);
                        this._listWorkers = this._workerDA.Executing("STGate_WorkerRegularAll").ToList();
                        LoadWorkerAll();
                        Wait.Close();
                        break;
                    }
                case 1:
                    {
                        this.txtCardID.ReadOnly = false;
                        this.txtCardID.Focus();
                        break;
                    }
                case 2:
                    {
                        this.txtWorkerID.ReadOnly = false;
                        this.txtWorkerID.Focus();
                        break;
                    }
                case 3:
                    {
                        this.txtName.ReadOnly = false;
                        this.txtName.Focus();
                        break;
                    }
                case 4:
                    {
                        this.lkeCompany.ReadOnly = false;
                        this.lkeCompany.Focus();
                        this.lkeCompany.ShowPopup();
                        break;
                    }
            }
        }
    }
}
