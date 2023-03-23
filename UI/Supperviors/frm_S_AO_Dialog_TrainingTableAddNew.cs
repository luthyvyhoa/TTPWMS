using Common.Process;
using DA;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
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
    public partial class frm_S_AO_Dialog_TrainingTableAddNew : Common.Controls.frmBaseForm
    {
        private DataTable _tbTrainings;

        public frm_S_AO_Dialog_TrainingTableAddNew()
        {
            InitializeComponent();
            this._tbTrainings = new DataTable();
            this.dtFrom.EditValue = DateTime.Now.AddDays(-365);
            this.dtTo.EditValue = DateTime.Now;
        }

        private void frm_S_AO_Dialog_TrainingTableAddNew_Load(object sender, EventArgs e)
        {
            InitUnits();
            InitEmployees();
            LoadTrainings();
            SetEvents();
        }

        private void SetEvents()
        {
            this.grvTrainings.CustomSummaryCalculate += GrvTrainings_CustomSummaryCalculate;
            this.grvTrainings.CellValueChanged += GrvTrainings_CellValueChanged;
            this.grvTrainings.FocusedRowChanged += GrvTrainings_FocusedRowChanged;
            this.rpi_chk_TrainingConfirm.CheckedChanged += Rpi_chk_TrainingConfirm_CheckedChanged;
            this.rpi_hpl_TrainingID.DoubleClick += Rpi_hpl_TrainingID_DoubleClick;
            this.rpi_lke_TrainingName.CloseUp += Rpi_lke_TrainingName_CloseUp;
            this.rpi_lke_Employee.CloseUp += Rpi_lke_Employee_CloseUp;
            this.rpi_btn_Delete.Click += Rpi_btn_Delete_Click;
            this.txtEmployeeIDFind.Leave += TxtEmployeeIDFind_Leave;
            this.txtEmployeeIDFind.KeyDown += TxtEmployeeIDFind_KeyDown;
            this.btnAddNew.Click += BtnAddNew_Click;
            this.btnTrainingDefinition.Click += BtnTrainingDefinition_Click;
            this.btnClose.Click += BtnClose_Click;
        }

        private void GrvTrainings_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            GridView view = sender as GridView;
            int summaryID = Convert.ToInt32((e.Item as DevExpress.XtraGrid.GridSummaryItem).Tag);
            decimal totalDuration = 0;

            if(e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Start)
            {
                totalDuration = 0;
            }

            if(e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
            {
                if(summaryID == 1)
                {
                    totalDuration += Convert.ToDecimal(e.FieldValue);
                }
            }

            if(e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
            {
                if (summaryID == 1)
                {
                    e.TotalValue = totalDuration / ((decimal)333.01);
                }
            }
        }

        private void GrvTrainings_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DataProcess<object> trainingDA = new DataProcess<object>();
            int trainingID = Convert.ToInt32(this.grvTrainings.GetFocusedRowCellValue("TrainingID"));
            int result = -2;

            switch (e.Column.FieldName)
            {
                case "CurrencyUnit":
                    {
                        result = trainingDA.ExecuteNoQuery("Update Trainings Set CurrencyUnit = {0} Where TrainingID = {1}", Convert.ToString(e.Value), trainingID);
                        break;
                    }
                case "TrainingDate":
                    {
                        result = trainingDA.ExecuteNoQuery("Update Trainings Set TrainingDate = {0} Where TrainingID = {1}", Convert.ToDateTime(e.Value).Date, trainingID);
                        break;
                    }
                case "TrainingExpiryDate":
                    {
                        result = trainingDA.ExecuteNoQuery("Update Trainings Set TrainingExpiryDate = {0} Where TrainingID = {1}", Convert.ToDateTime(e.Value).Date, trainingID);
                        break;
                    }
                case "TrainingCost":
                    {
                        result = trainingDA.ExecuteNoQuery("Update Trainings Set TrainingCost = {0} Where TrainingID = {1}", Convert.ToInt32(e.Value), trainingID);
                        break;
                    }
                case "TrainingDuration":
                    {
                        result = trainingDA.ExecuteNoQuery("Update Trainings Set TrainingDuration = {0} Where TrainingID = {1}", Convert.ToDecimal(e.Value), trainingID);
                        break;
                    }
                case "TrainingDescription":
                    {
                        result = trainingDA.ExecuteNoQuery("Update Trainings Set TrainingDescription = {0} Where TrainingID = {1}", Convert.ToString(e.Value), trainingID);
                        break;
                    }
            }
        }

        private void GrvTrainings_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //if (Convert.ToBoolean(this.grvTrainings.GetRowCellValue(e.FocusedRowHandle, "TrainingConfirm")))
            //{
            //    this.grvTrainings.OptionsBehavior.ReadOnly = true;
            //}
            //else
            //{
            //    this.grvTrainings.OptionsBehavior.ReadOnly = false;
            //}
        }

        private void Rpi_chk_TrainingConfirm_CheckedChanged(object sender, EventArgs e)
        {
            CheckEdit edit = sender as CheckEdit;
            DataProcess<object> trainingDA = new DataProcess<object>();
            int trainingID = Convert.ToInt32(this.grvTrainings.GetFocusedRowCellValue("TrainingID"));
            int result = -2;

            if (edit.Checked)
            {
                this.grvTrainings.SetFocusedRowCellValue("TrainingConfirmedBy", AppSetting.CurrentUser.LoginName);
                this.grvTrainings.SetFocusedRowCellValue("ConfirmTime", DateTime.Now);

                result = trainingDA.ExecuteNoQuery("Update Trainings Set TrainingConfirmedBy = {0} Where TrainingID = {1}", AppSetting.CurrentUser.LoginName, trainingID);
                result = trainingDA.ExecuteNoQuery("Update Trainings Set ConfirmTime = {0} Where TrainingID = {1}", DateTime.Now, trainingID);
                result = trainingDA.ExecuteNoQuery("Update Trainings Set TrainingConfirm = {0} Where TrainingID = {1}", true, trainingID);

                this.grvTrainings.PostEditor();
                //this.grvTrainings.OptionsBehavior.ReadOnly = true;
            }
            else
            {
                result = trainingDA.ExecuteNoQuery("Update Trainings Set TrainingConfirmedBy = NULL, ConfirmTime = NULL, TrainingConfirm = 0 Where TrainingID = " + trainingID);
                LoadTrainings();
            }
        }

        private void Rpi_hpl_TrainingID_DoubleClick(object sender, EventArgs e)
        {
            frm_S_AO_Dialog_Trainings frm = new frm_S_AO_Dialog_Trainings();
            frm.TrainingIDFind = Convert.ToInt32(this.grvTrainings.GetFocusedRowCellValue("TrainingID"));
            frm.Show();
        }

        private void Rpi_lke_TrainingName_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            LookUpEdit edit = sender as LookUpEdit;
            edit.EditValue = e.Value;
            int trainingID = Convert.ToInt32(this.grvTrainings.GetFocusedRowCellValue("TrainingID"));

            if (Convert.ToBoolean(this.grvTrainings.GetFocusedRowCellValue("TrainingConfirm")))
            {
                return;
            }
            else
            {
                DataProcess<object> trainingDA = new DataProcess<object>();
                int result = trainingDA.ExecuteNoQuery("Update Trainings Set TrainingDefinitionID = {0} Where TrainingID = {1}", Convert.ToInt32(edit.EditValue), trainingID);
            }
        }

        private void Rpi_lke_Employee_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            LookUpEdit edit = sender as LookUpEdit;
            edit.EditValue = e.Value;
            int trainingID = Convert.ToInt32(this.grvTrainings.GetFocusedRowCellValue("TrainingID"));

            InitTrainingByEmployee();
            this.grvTrainings.SetFocusedRowCellValue("VietnamName", Convert.ToString(edit.GetColumnValue("VietnamName")));

            if (Convert.ToBoolean(this.grvTrainings.GetFocusedRowCellValue("TrainingConfirm")))
            {
                return;
            }
            else
            {
                DataProcess<object> trainingDA = new DataProcess<object>();
                int result = trainingDA.ExecuteNoQuery("Update Trainings Set EmployeeID = {0} Where TrainingID = {1}", Convert.ToInt32(edit.EditValue), trainingID);
            }
        }

        private void Rpi_btn_Delete_Click(object sender, EventArgs e)
        {
            if(Convert.ToBoolean(this.grvTrainings.GetFocusedRowCellValue("TrainingConfirm")))
            {
                return;
            }
            if(XtraMessageBox.Show("Ban co muon xoa nhan vien nay ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataProcess<object> trainingDA = new DataProcess<object>();
                int result = trainingDA.ExecuteNoQuery("STTrainingDelete @TrainingID = {0}", Convert.ToInt32(this.grvTrainings.GetFocusedRowCellValue("TrainingID")));
                LoadTrainings();
            }
        }

        private void TxtEmployeeIDFind_Leave(object sender, EventArgs e)
        {
            if (this.txtEmployeeIDFind.IsModified)
            {
                if (String.IsNullOrEmpty(this.txtEmployeeIDFind.Text))
                {
                    LoadTrainings();
                }
                else
                {
                    LoadTrainingByEmployee();
                }
            }
        }

        private void TxtEmployeeIDFind_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(this.txtEmployeeIDFind.IsModified)
                {
                    if (String.IsNullOrEmpty(this.txtEmployeeIDFind.Text))
                    {
                        LoadTrainings();
                    }
                    else
                    {
                        LoadTrainingByEmployee();
                    }
                }
            }
        }

        private void BtnAddNew_Click(object sender, EventArgs e)
        {
            //frmTrainingAddNew
            frm_S_AO_Dialog_TrainingAddNew frm = new frm_S_AO_Dialog_TrainingAddNew();
            DialogResult result = frm.ShowDialog();

            if(result == DialogResult.OK)
            {
                if (String.IsNullOrEmpty(this.txtEmployeeIDFind.Text))
                {
                    LoadTrainings();
                }
                else
                {
                    LoadTrainingByEmployee();
                }
            }
        }

        private void BtnTrainingDefinition_Click(object sender, EventArgs e)
        {
            try
            {
                Wait.Start(this);
                DevExpress.XtraGrid.GridControl grdReport = new DevExpress.XtraGrid.GridControl();
                DevExpress.XtraGrid.Views.Grid.GridView grvReport = new DevExpress.XtraGrid.Views.Grid.GridView(grdReport);
                grdReport.MainView = grvReport;
                grdReport.ForceInitialize();
                grdReport.BindingContext = new BindingContext();
                grdReport.DataSource = FileProcess.LoadTable("Select TrainingDefinitions.TrainingDefinitionID, TrainingDefinitions.TrainingName, TrainingDefinitions.TrainingType, TrainingDefinitions.StandardFrequence, TrainingDefinitions.TrainingRemark From TrainingDefinitions");
                grvReport.PopulateColumns();

                // Export data to excel file
                string pathSaveFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string fileName = pathSaveFile + "\\" + "TrainingDefinitions_" + DateTime.Now.ToString("dd_MM_yy") + ".xlsx";

                grvReport.ExportToXlsx(fileName);

                System.Diagnostics.Process.Start(fileName);
                Wait.Close();
            }
            catch (Exception ex)
            {
                Wait.Close();
                XtraMessageBox.Show(ex.Message, "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Load Data
        private void LoadTrainings()
        {
            InitTrainings();            
            this._tbTrainings = FileProcess.LoadTable("SELECT Trainings.*, Employees.VietnamName, TrainingDefinitions.TrainingName " +
                                          "FROM(Trainings INNER JOIN Employees ON Trainings.EmployeeID = Employees.EmployeeID) LEFT JOIN TrainingDefinitions ON Trainings.TrainingDefinitionID = TrainingDefinitions.TrainingDefinitionID " +
                                          "WHERE Trainings.TrainingDate Between '" + this.dtFrom.DateTime.ToString("yyyy-MM-dd") + "' And '" + this.dtTo.DateTime.ToString("yyyy-MM-dd") + "' " + //GetDate() - 93 And GetDate())) " +
                                          "ORDER BY Trainings.TrainingDate DESC, Employees.EmployeeID");
            this.grdTrainings.DataSource = this._tbTrainings;
        }

        private void LoadTrainingByEmployee()
        {
            InitTrainings();
            this._tbTrainings = FileProcess.LoadTable("SELECT Trainings.*, Employees.VietnamName, TrainingDefinitions.TrainingName " +
                                                      "FROM(Trainings INNER JOIN Employees ON Trainings.EmployeeID = Employees.EmployeeID) LEFT JOIN TrainingDefinitions ON Trainings.TrainingDefinitionID = TrainingDefinitions.TrainingDefinitionID " +
                                                      "WHERE Trainings.EmployeeID = "+this.txtEmployeeIDFind.Text+" AND Trainings.TrainingDate Between '"+this.dtFrom.DateTime.ToString("yyyy-MM-dd")+ "' And '" + this.dtTo.DateTime.ToString("yyyy-MM-dd") + "' " +
                                                      "ORDER BY Trainings.TrainingDate DESC");
            this.grdTrainings.DataSource = this._tbTrainings;
        }

        private void InitEmployees()
        {
            this.rpi_lke_Employee.DataSource = AppSetting.EmployessList;
            this.rpi_lke_Employee.ValueMember = "EmployeeID";
            this.rpi_lke_Employee.DisplayMember = "EmployeeID";
        }

        private void InitUnits()
        {
            var source = new DataTable();
            source.Columns.Add(new DataColumn("Currency", typeof(string)));

            DataRow row1 = source.NewRow();
            row1["Currency"] = "VND";

            DataRow row2 = source.NewRow();
            row2["Currency"] = "USD";

            DataRow row3 = source.NewRow();
            row3["Currency"] = "AUD";

            DataRow row4 = source.NewRow();
            row4["Currency"] = "EUR";

            source.Rows.Add(row1);
            source.Rows.Add(row2);
            source.Rows.Add(row3);
            source.Rows.Add(row4);

            this.rpi_lke_Unit.DataSource = source;
            this.rpi_lke_Unit.ValueMember = "Currency";
            this.rpi_lke_Unit.DisplayMember = "Currency";
        }

        private void InitTrainings()
        {
            DataProcess<TrainingDefinitions> trainDefinitionDA = new DataProcess<TrainingDefinitions>();

            this.rpi_lke_TrainingName.DataSource = trainDefinitionDA.Select().OrderBy(t => t.TrainingName);
            this.rpi_lke_TrainingName.ValueMember = "TrainingDefinitionID";
            this.rpi_lke_TrainingName.DisplayMember = "TrainingName";
        }

        private void InitTrainingByEmployee()
        {
            this.rpi_lke_TrainingName.DataSource = FileProcess.LoadTable("STComboTrainingRequirements @EmployeeID = " + Convert.ToInt32(this.grvTrainings.GetFocusedRowCellValue("EmployeeID")));
            this.rpi_lke_TrainingName.DisplayMember = "TrainingName";
            this.rpi_lke_TrainingName.ValueMember = "TrainingDefinitionID";
        }
        #endregion

        private void dtFrom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.dtFrom.IsModified)
                {
                    if (String.IsNullOrEmpty(this.txtEmployeeIDFind.Text))
                    {
                        LoadTrainings();
                    }
                    else
                    {
                        LoadTrainingByEmployee();
                    }
                }
            }
        }

        private void dtTo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.dtTo.IsModified)
                {
                    if (String.IsNullOrEmpty(this.txtEmployeeIDFind.Text))
                    {
                        LoadTrainings();
                    }
                    else
                    {
                        LoadTrainingByEmployee();
                    }
                }
            }
        }
    }
}
