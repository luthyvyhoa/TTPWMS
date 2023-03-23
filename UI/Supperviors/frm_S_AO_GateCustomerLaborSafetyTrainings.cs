using Common.Process;
using DA;
using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace UI.Supperviors
{
    public partial class frm_S_AO_GateCustomerLaborSafetyTrainings : Common.Controls.frmBaseForm
    {
        private DataTable _tbSafetyTrainings;
        private byte _filterMode;

        public frm_S_AO_GateCustomerLaborSafetyTrainings()
        {
            InitializeComponent();
            this._tbSafetyTrainings = new DataTable();
            this._filterMode = 1;
        }

        private void frm_S_AO_GateCustomerLaborSafetyTrainings_Load(object sender, EventArgs e)
        {
            Wait.Start(this);
            this._tbSafetyTrainings = FileProcess.LoadTable("SELECT Gate_WorkerLaborSafetyTraining.LaborSafetyTrainID, Gate_WorkerLaborSafetyTraining.LaborSafetyTrainBy, Gate_WorkerLaborSafetyTraining.LaborSafetyTrainDate, Gate_WorkerLaborSafetyTraining.Description, Gate_WorkerLaborSafetyTraining.WorkerID, Gate_Workers.WorkerName, Gate_Workers.CardID, Gate_Companies.CompanyName " +
                                                            "FROM(Gate_WorkerLaborSafetyTraining INNER JOIN Gate_Workers ON Gate_WorkerLaborSafetyTraining.WorkerID = Gate_Workers.WorkerID) INNER JOIN Gate_Companies ON Gate_Workers.CompanyID = Gate_Companies.CompanyID; ");
            InitCustomers();
            LoadSafetyTrainings();
            SetEvents();
            Wait.Close();
        }

        private void SetEvents()
        {
            this.grvSafetyTraining.CellValueChanged += GrvSafetyTraining_CellValueChanged;
            this.rpi_dt_TrainDate.EditValueChanging += Rpi_dt_TrainDate_EditValueChanging;
            this.rpi_btn_Delete.Click += Rpi_btn_Delete_Click;
            this.lkeCustomerFind.CloseUp += LkeCustomerFind_CloseUp;
            this.chkAll.EditValueChanging += CheckingChanging;
            this.chkAll.CheckedChanged += CheckedChanged;
            this.chkCustomer.EditValueChanging += CheckingChanging;
            this.chkCustomer.CheckedChanged += CheckedChanged;
            this.btnNew.Click += BtnNew_Click;
            this.btnCustomerWorkerAll.Click += BtnCustomerWorkerAll_Click;
            this.btnCustomersToday.Click += BtnCustomersToday_Click;
            this.btnEnable.Click += BtnEnable_Click;
            this.btnClose.Click += BtnClose_Click;
        }

        #region Events
        private void GrvSafetyTraining_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DataProcess<object> trainingDA = new DataProcess<object>();
            int trainID = Convert.ToInt32(this.grvSafetyTraining.GetFocusedRowCellValue("LaborSafetyTrainID"));

            switch(e.Column.FieldName)
            {
                case "LaborSafetyTrainDate":
                    {
                        trainingDA.ExecuteNoQuery("Update Gate_WorkerLaborSafetyTraining Set LaborSafetyTrainDate = {0} Where LaborSafetyTrainID = {1}", Convert.ToDateTime(e.Value), trainID);
                        break;
                    }
                case "Description":
                    {
                        trainingDA.ExecuteNoQuery("Update Gate_WorkerLaborSafetyTraining Set Description = {0} Where LaborSafetyTrainID = {1}", Convert.ToString(e.Value), trainID);
                        break;
                    }
            }
        }

        private void Rpi_dt_TrainDate_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            DateTime newDate = Convert.ToDateTime(e.NewValue);

            if(newDate < DateTime.Now.AddDays(-30) || newDate > DateTime.Now.AddDays(3))
            {
                XtraMessageBox.Show("Ngay khong hop le !!!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }

        private void Rpi_btn_Delete_Click(object sender, EventArgs e)
        {
            DataProcess<object> trainingDA = new DataProcess<object>();
            int trainID = Convert.ToInt32(this.grvSafetyTraining.GetFocusedRowCellValue("LaborSafetyTrainID"));

            if(XtraMessageBox.Show("Ban co muon xoa ATLD cong nhan nay ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int result = trainingDA.ExecuteNoQuery("Delete From Gate_WorkerLaborSafetyTraining Where LaborSafetyTrainID = {0}", trainID);
                RefreshData();
            }
        }

        private void LkeCustomerFind_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            this.lkeCustomerFind.EditValue = e.Value;
            this._tbSafetyTrainings = FileProcess.LoadTable("SELECT Gate_WorkerLaborSafetyTraining.LaborSafetyTrainID, Gate_WorkerLaborSafetyTraining.LaborSafetyTrainBy, Gate_WorkerLaborSafetyTraining.LaborSafetyTrainDate, Gate_WorkerLaborSafetyTraining.Description, Gate_WorkerLaborSafetyTraining.WorkerID, Gate_Workers.WorkerName, Gate_Workers.CardID, Gate_Companies.CompanyName " +
                                                "FROM(Gate_WorkerLaborSafetyTraining INNER JOIN Gate_Workers ON Gate_WorkerLaborSafetyTraining.WorkerID = Gate_Workers.WorkerID) INNER JOIN Gate_Companies ON Gate_Workers.CompanyID = Gate_Companies.CompanyID " +
                                                "WHERE Gate_Workers.CompanyID = " + Convert.ToInt32(this.lkeCustomerFind.EditValue));
            LoadSafetyTrainings();
        }

        private void CheckingChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
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

            if(edit.Checked)
            {
                byte prevFilter = this._filterMode;
                this._filterMode = Convert.ToByte(edit.Tag);
                UnCheckedFilter(prevFilter);
                FilterModeChanged();
            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            frm_S_AO_Dialog_GateCustomerLaborSafetyTrainingAddNew frm = new frm_S_AO_Dialog_GateCustomerLaborSafetyTrainingAddNew();
            DialogResult result = frm.ShowDialog();

            if(result == DialogResult.OK)
            {
                RefreshData();
            }
        }

        private void BtnCustomerWorkerAll_Click(object sender, EventArgs e)
        {
            frm_S_AO_Dialog_GateCustomerWorkerAll frm = new frm_S_AO_Dialog_GateCustomerWorkerAll();
            frm.Show();
        }

        private void BtnCustomersToday_Click(object sender, EventArgs e)
        {
            frm_S_AO_Dialog_GateCustomerLaborSafetyTrainingInOut frm = new frm_S_AO_Dialog_GateCustomerLaborSafetyTrainingInOut();
            frm.Show();
        }

        private void BtnEnable_Click(object sender, EventArgs e)
        {
            if(this.btnEnable.Text.Equals("Enable"))
            {
                this.btnEnable.Text = "Disable";
                SetReadOnly(false);
            }
            else
            {
                this.btnEnable.Text = "Enable";
                SetReadOnly(true);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Load Data
        private void LoadSafetyTrainings()
        {
            this.grdSafetyTraining.DataSource = this._tbSafetyTrainings;
        }

        private void RefreshData()
        {
            if (this._filterMode == 1)
            {
                this._tbSafetyTrainings = FileProcess.LoadTable("SELECT Gate_WorkerLaborSafetyTraining.LaborSafetyTrainID, Gate_WorkerLaborSafetyTraining.LaborSafetyTrainBy, Gate_WorkerLaborSafetyTraining.LaborSafetyTrainDate, Gate_WorkerLaborSafetyTraining.Description, Gate_WorkerLaborSafetyTraining.WorkerID, Gate_Workers.WorkerName, Gate_Workers.CardID, Gate_Companies.CompanyName " +
                                                            "FROM(Gate_WorkerLaborSafetyTraining INNER JOIN Gate_Workers ON Gate_WorkerLaborSafetyTraining.WorkerID = Gate_Workers.WorkerID) INNER JOIN Gate_Companies ON Gate_Workers.CompanyID = Gate_Companies.CompanyID; ");
            }
            else
            {
                this._tbSafetyTrainings = FileProcess.LoadTable("SELECT Gate_WorkerLaborSafetyTraining.LaborSafetyTrainID, Gate_WorkerLaborSafetyTraining.LaborSafetyTrainBy, Gate_WorkerLaborSafetyTraining.LaborSafetyTrainDate, Gate_WorkerLaborSafetyTraining.Description, Gate_WorkerLaborSafetyTraining.WorkerID, Gate_Workers.WorkerName, Gate_Workers.CardID, Gate_Companies.CompanyName " +
                                    "FROM(Gate_WorkerLaborSafetyTraining INNER JOIN Gate_Workers ON Gate_WorkerLaborSafetyTraining.WorkerID = Gate_Workers.WorkerID) INNER JOIN Gate_Companies ON Gate_Workers.CompanyID = Gate_Companies.CompanyID " +
                                    "WHERE Gate_Workers.CompanyID = " + Convert.ToInt32(this.lkeCustomerFind.EditValue));
            }
            LoadSafetyTrainings();
        }

        private void InitCustomers()
        {
            this.lkeCustomerFind.Properties.DataSource = FileProcess.LoadTable("SELECT Gate_Companies.CompanyID, Gate_Companies.CompanyNumber, Gate_Companies.CompanyName FROM Gate_Companies ORDER BY Gate_Companies.CompanyName");
            this.lkeCustomerFind.Properties.ValueMember = "CompanyID";
            this.lkeCustomerFind.Properties.DisplayMember = "CompanyName";
        }
        #endregion

        private void UnCheckedFilter(byte prevFilter)
        {
            if(prevFilter == 1)
            {
                this.chkAll.Checked = false;
            }
            else
            {
                this.chkCustomer.Checked = false;
                this.lkeCustomerFind.ReadOnly = true;
            }
        }

        private void FilterModeChanged()
        {
            if(this._filterMode == 1)
            {
                this._tbSafetyTrainings = FileProcess.LoadTable("SELECT Gate_WorkerLaborSafetyTraining.LaborSafetyTrainID, Gate_WorkerLaborSafetyTraining.LaborSafetyTrainBy, Gate_WorkerLaborSafetyTraining.LaborSafetyTrainDate, Gate_WorkerLaborSafetyTraining.Description, Gate_WorkerLaborSafetyTraining.WorkerID, Gate_Workers.WorkerName, Gate_Workers.CardID, Gate_Companies.CompanyName " +
                                                            "FROM(Gate_WorkerLaborSafetyTraining INNER JOIN Gate_Workers ON Gate_WorkerLaborSafetyTraining.WorkerID = Gate_Workers.WorkerID) INNER JOIN Gate_Companies ON Gate_Workers.CompanyID = Gate_Companies.CompanyID; ");
                LoadSafetyTrainings();
            }
            else
            {
                this.lkeCustomerFind.ReadOnly = false;
                this.lkeCustomerFind.Focus();
                this.lkeCustomerFind.ShowPopup();
            }
        }

        private void SetReadOnly(bool isReadOnly)
        {
            this.grcDescription.OptionsColumn.ReadOnly = isReadOnly;
            //this.grdSafetyTraining.OptionsColumn.ReadOnly = isReadOnly;
        }
    }
}
