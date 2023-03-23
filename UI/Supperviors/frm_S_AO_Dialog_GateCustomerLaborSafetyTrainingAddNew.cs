using Common.Process;
using DA;
using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Windows.Forms;
using UI.Helper;

namespace UI.Supperviors
{
    public partial class frm_S_AO_Dialog_GateCustomerLaborSafetyTrainingAddNew : Common.Controls.frmBaseForm
    {
        private DataTable _tbTrainings;
        private bool _isAddNew;
        private byte _filterMode;
        private byte _sortMode;

        public frm_S_AO_Dialog_GateCustomerLaborSafetyTrainingAddNew()
        {
            InitializeComponent();
            this._tbTrainings = new DataTable();
            this._isAddNew = false;
            this._filterMode = 0;
            this._sortMode = 1;
        }

        private void frm_S_AO_Dialog_GateCustomerLaborSafetyTrainingAddNew_Load(object sender, EventArgs e)
        {
            Wait.Start(this);
            InitCustomers();
            InitWorkers();
            LoadSafetyTrainings();
            SetEvents();
            Wait.Close();
        }

        private void SetEvents()
        {
            this.grvTraining.FocusedColumnChanged += GrvTraining_FocusedColumnChanged;
            this.grvTraining.KeyDown += GrvTraining_KeyDown;
            this.grvTraining.FocusedRowChanged += GrvTraining_FocusedRowChanged;
            this.grvTraining.InitNewRow += GrvTraining_InitNewRow;
            this.grvTraining.CellValueChanged += GrvTraining_CellValueChanged;
            this.grvTraining.ShownEditor += GrvTraining_ShownEditor;
            this.rpi_lke_Worker.CloseUp += Rpi_lke_Worker_CloseUp;
            this.rpi_lke_Worker.Leave += Rpi_lke_Worker_Leave;
            this.rpi_btn_Delete.Click += Rpi_btn_Delete_Click;
            this.rpi_dt_TrainDate.EditValueChanging += Rpi_dt_TrainDate_EditValueChanging;
            this.chkCardID.EditValueChanging += SortCheckedChanging;
            this.chkCardID.CheckedChanged += SortCheckedChanged;
            this.chkName.EditValueChanging += SortCheckedChanging;
            this.chkName.CheckedChanged += SortCheckedChanged;
            this.chkWorkerID.EditValueChanging += SortCheckedChanging;
            this.chkWorkerID.CheckedChanged += SortCheckedChanged;
            this.chkAll.EditValueChanging += FilterCheckingChanging;
            this.chkAll.CheckedChanged += FilterCheckedChanged;
            this.chkCustomer.EditValueChanging += FilterCheckingChanging;
            this.chkCustomer.CheckedChanged += FilterCheckedChanged;
            this.lkeCustomer.CloseUp += LkeCustomer_CloseUp;
            this.btnOK.Click += BtnOK_Click;
            this.btnClose.Click += BtnClose_Click;
        }

        private void GrvTraining_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            switch(e.PrevFocusedColumn.FieldName)
            {
                case "WorkerID":
                    {
                        this.grvTraining.FocusedColumn = grcTrainDate;
                        break;
                    }
                case "Description":
                    {
                        if(this.grvTraining.IsLastRow)
                        {
                            this.grvTraining.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle;
                        }
                        else
                        {
                            this.grvTraining.MoveNext();
                        }
                        this.grvTraining.FocusedColumn = grcWorkerID;
                        break;
                    }
            }
        }

        private void GrvTraining_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {

            }
        }

        private void GrvTraining_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if(this.grvTraining.IsNewItemRow(e.PrevFocusedRowHandle))
            {
                if(this._isAddNew)
                {
                    DataProcess<object> tmpSafetyTrainingDA = new DataProcess<object>();
                    int result = -2;

                    int rowHandle = this._tbTrainings.Rows.Count - 1;
                    string cardID = Convert.ToString(this.grvTraining.GetRowCellValue(rowHandle, "CardID"));
                    string description = Convert.ToString(this.grvTraining.GetRowCellValue(rowHandle, "Description"));
                    string workerName = Convert.ToString(this.grvTraining.GetRowCellValue(rowHandle, "WorkerName"));
                    string companyName = Convert.ToString(this.grvTraining.GetRowCellValue(rowHandle, "CompanyName"));
                    int workerID = Convert.ToInt32(this.grvTraining.GetRowCellValue(rowHandle, "WorkerID"));
                    DateTime trainDate = Convert.ToDateTime(this.grvTraining.GetRowCellValue(rowHandle, "LaborSafetyTrainDate"));

                    result = tmpSafetyTrainingDA.ExecuteNoQuery("Insert into tmpWorkerLaborSafetyTraining (LaborSafetyTrainDate, Description, WorkerID, WorkerName, CardID, CompanyName) values ('" + trainDate.ToString("yyyy-MM-dd") + "', '" + description + "', " + workerID + ", '" + workerName + "', '" + cardID + "', '" + companyName + "')");
                    LoadSafetyTrainings();
                    this._isAddNew = false;
                }
            }
        }

        private void GrvTraining_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            this.grvTraining.SetRowCellValue(e.RowHandle, "LaborSafetyTrainDate", DateTime.Now);
        }

        private void GrvTraining_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if(!this.grvTraining.IsNewItemRow(e.RowHandle))
            {
                DataProcess<object> tmpSafetyTrainingDA = new DataProcess<object>();
                int result = -2;
                int trainID = Convert.ToInt32(this.grvTraining.GetRowCellValue(e.RowHandle, "LaborSafetyTrainID"));

                switch(e.Column.FieldName)
                {
                    case "LaborSafetyTrainDate":
                        {
                            DateTime trainDate = Convert.ToDateTime(this.grvTraining.GetRowCellValue(e.RowHandle, "LaborSafetyTrainDate"));
                            result = tmpSafetyTrainingDA.ExecuteNoQuery("Update tmpWorkerLaborSafetyTraining Set LaborSafetyTrainDate = '" + trainDate.ToString("yyyy-MM-dd") + "' Where LaborSafetyTrainID = " + trainID);
                            break;
                        }
                    case "Description":
                        {
                            string description = Convert.ToString(this.grvTraining.GetRowCellValue(e.RowHandle, "Description"));
                            result = tmpSafetyTrainingDA.ExecuteNoQuery("Update tmpWorkerLaborSafetyTraining Set Description = '"+description+"' Where LaborSafetyTrainID = " + trainID);
                            break;
                        }
                    case "WorkerID":
                        {
                            string workerName = Convert.ToString(this.grvTraining.GetRowCellValue(e.RowHandle, "WorkerName"));
                            string companyName = Convert.ToString(this.grvTraining.GetRowCellValue(e.RowHandle, "CompanyName"));
                            int workerID = Convert.ToInt32(this.grvTraining.GetRowCellValue(e.RowHandle, "WorkerID"));
                            string cardID = Convert.ToString(this.grvTraining.GetRowCellValue(e.RowHandle, "CardID"));
                            result = tmpSafetyTrainingDA.ExecuteNoQuery("Update tmpWorkerLaborSafetyTraining Set WorkerID = "+workerID+", WorkerName = '"+workerName+"', CardID = '"+cardID+"', CompanyName = '"+companyName+"' Where LaborSafetyTrainID = " + trainID);
                            break;
                        }
                }
            }
        }

        private void GrvTraining_ShownEditor(object sender, EventArgs e)
        {
            LookUpEdit edit = this.grvTraining.ActiveEditor as LookUpEdit;

            if (edit == null)
            {
                return;
            }
            edit.ShowPopup();
        }

        private void Rpi_lke_Worker_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if(e.Value == null)
            {
                return;
            }
            DevExpress.XtraEditors.LookUpEdit editor = (sender as DevExpress.XtraEditors.LookUpEdit);
            editor.EditValue = e.Value;
            object row = editor.Properties.GetDataSourceRowByKeyValue(editor.EditValue);
            //DataRowView row = editor.GetSelectedDataRow() as DataRowView;

            string cardID = Convert.IsDBNull((row as DataRowView)["CardID"]) ? null : Convert.ToString((row as DataRowView)["CardID"]);
            string company = Convert.ToString((row as DataRowView)["CompanyName"]);
            string workerName = Convert.ToString((row as DataRowView)["WorkerName"]);

            this.grvTraining.SetFocusedRowCellValue("CardID", cardID);
            this.grvTraining.SetFocusedRowCellValue("CompanyName", company);
            this.grvTraining.SetFocusedRowCellValue("WorkerName", workerName);
        }

        private void Rpi_lke_Worker_Leave(object sender, EventArgs e)
        {
            if (this.grvTraining.IsNewItemRow(this.grvTraining.FocusedRowHandle))
            {
                DevExpress.XtraEditors.LookUpEdit editor = (sender as DevExpress.XtraEditors.LookUpEdit);
                if (editor.EditValue != null)
                {
                    this._isAddNew = true;
                }
                else
                {
                    this._isAddNew = false;
                }
            }
        }

        private void Rpi_btn_Delete_Click(object sender, EventArgs e)
        {
            if (this.grvTraining.IsNewItemRow(this.grvTraining.FocusedRowHandle))
            {
                return;
            }
            DataProcess<object> tmpSafetyTrainingDA = new DataProcess<object>();
            int result = -2;
            int trainID = Convert.ToInt32(this.grvTraining.GetFocusedRowCellValue("LaborSafetyTrainID"));
            result = tmpSafetyTrainingDA.ExecuteNoQuery("Delete From tmpWorkerLaborSafetyTraining Where LaborSafetyTrainID = {0}", trainID);

            LoadSafetyTrainings();
        }

        private void Rpi_dt_TrainDate_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            DateTime newDate = Convert.ToDateTime(e.NewValue);

            if (newDate < DateTime.Now.AddDays(-30) || newDate > DateTime.Now.AddDays(3))
            {
                XtraMessageBox.Show("Ngay khong hop le !!!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }

        private void SortCheckedChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            CheckEdit edit = sender as CheckEdit;

            if (!Convert.ToBoolean(e.NewValue))
            {
                if (this._sortMode == Convert.ToByte(edit.Tag))
                {
                    e.Cancel = true;
                }
            }
        }

        private void SortCheckedChanged(object sender, EventArgs e)
        {
            CheckEdit edit = sender as CheckEdit;

            if (edit.Checked)
            {
                byte preSort = this._sortMode;
                this._sortMode = Convert.ToByte(edit.Tag);
                UnCheckedSort(preSort);
                SortModeChanged();
            }
        }

        private void FilterCheckingChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
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

        private void FilterCheckedChanged(object sender, EventArgs e)
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

        private void LkeCustomer_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            this.lkeCustomer.EditValue = e.Value;
            Wait.Start(this);
            InitWorkers();
            Wait.Close();
            this.grvTraining.Focus();
            this.grvTraining.FocusedColumn = grcWorkerID;
            this.grvTraining.ShowEditor();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            DataProcess<object> tmpSafetyTrainingDA = new DataProcess<object>();
            int result = -2;

            result = tmpSafetyTrainingDA.ExecuteNoQuery("Insert into Gate_WorkerLaborSafetyTraining ( WorkerID, LaborSafetyTrainDate, Description, LaborSafetyTrainBy ) " +
                                                        "Select tmpWorkerLaborSafetyTraining.WorkerID, tmpWorkerLaborSafetyTraining.LaborSafetyTrainDate, tmpWorkerLaborSafetyTraining.Description, '"+AppSetting.CurrentUser.LoginName+"' " +
                                                        "From tmpWorkerLaborSafetyTraining " +
                                                        "WHERE(tmpWorkerLaborSafetyTraining.LaborSafetyTrainDate Is Not Null)");
            result = tmpSafetyTrainingDA.ExecuteNoQuery("Delete From tmpWorkerLaborSafetyTraining");
            this.DialogResult = DialogResult.OK;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Load Data
        private void LoadSafetyTrainings()
        {
            this._tbTrainings = FileProcess.LoadTable("Select * From tmpWorkerLaborSafetyTraining");
            this.grdTraining.DataSource = this._tbTrainings;
        }

        private void InitWorkers()
        {
            if (this._filterMode == 0)
            {
                this.rpi_lke_Worker.DataSource = FileProcess.LoadTable("STGate_ComboWorkerID @CompanyID = 0, @Flag = " + this._sortMode);
            }
            else
            {
                this.rpi_lke_Worker.DataSource = FileProcess.LoadTable("STGate_ComboWorkerID @CompanyID = " + Convert.ToInt32(this.lkeCustomer.EditValue) + ", @Flag = " + this._sortMode);
            }
            this.rpi_lke_Worker.DisplayMember = "WorkerID";
            this.rpi_lke_Worker.ValueMember = "WorkerID";
        }

        private void InitCustomers()
        {
            this.lkeCustomer.Properties.DataSource = FileProcess.LoadTable("SELECT Gate_Companies.CompanyID, Gate_Companies.CompanyNumber, Gate_Companies.CompanyName FROM Gate_Companies ORDER BY Gate_Companies.CompanyName");
            this.lkeCustomer.Properties.ValueMember = "CompanyID";
            this.lkeCustomer.Properties.DisplayMember = "CompanyName";
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
                        this.chkCustomer.Checked = false;
                        this.lkeCustomer.ReadOnly = true;
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
                        InitWorkers();
                        Wait.Close();
                        this.grvTraining.Focus();
                        this.grvTraining.FocusedColumn = grcWorkerID;
                        this.grvTraining.ShowEditor();
                        break;
                    }
                case 1:
                    {
                        this.lkeCustomer.ReadOnly = false;
                        this.lkeCustomer.Focus();
                        this.lkeCustomer.ShowPopup();
                        break;
                    }
            }
        }

        private void UnCheckedSort(byte prevSort)
        {
            switch(prevSort)
            {
                case 1:
                    {
                        this.chkCardID.Checked = false;
                        break;
                    }
                case 2:
                    {
                        this.chkName.Checked = false;
                        break;
                    }
                case 3:
                    {
                        this.chkWorkerID.Checked = false;
                        break;
                    }
            }
        }

        private void SortModeChanged()
        {
            Wait.Start(this);
            InitWorkers();
            Wait.Close();
            this.grvTraining.Focus();
            this.grvTraining.FocusedColumn = grcWorkerID;
            this.grvTraining.ShowEditor();
        }
    }
}
