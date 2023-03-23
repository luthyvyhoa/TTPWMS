using Common.Process;
using DA;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
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

namespace UI.Supperviors
{
    public partial class frm_S_AO_TrainingPositionRequirements : Common.Controls.frmBaseForm
    {
        private DataProcess<Positions> _positionDA;
        private DataProcess<PositionTrainingRequirements> _requirementDA;
        private DataTable _tbTrainingDetails;
        private bool _isModified;
        frm_S_AO_TrainingDefinitionGroup frmTrainingDefinitionGroup = new frm_S_AO_TrainingDefinitionGroup();

        public frm_S_AO_TrainingPositionRequirements()
        {
            InitializeComponent();
            this._positionDA = new DataProcess<Positions>();
            this._requirementDA = new DataProcess<PositionTrainingRequirements>();
            this._tbTrainingDetails = new DataTable();
            this.dtFrom.EditValue = DateTime.Now.AddDays(-365);
            this.dtTo.EditValue = DateTime.Now;
            this._isModified = false;
        }

        private void frm_S_AO_TrainingPositionRequirements_Load(object sender, EventArgs e)
        {
            InitTrainings();
            Init_SafeTeam();
            Init_Stores();
            LoadPositions();
            LoadTrainingFuture();
            SetEvents();
        }

        private void SetEvents()
        {
            this.grvTrainings.FocusedRowChanged += GrvTrainings_FocusedRowChanged;
            this.grvTrainingDetails.FocusedRowChanged += GrvTrainingDetails_FocusedRowChanged;
            this.grvTrainingDetails.FocusedColumnChanged += GrvTrainingDetails_FocusedColumnChanged;
            this.grvTrainingDetails.CellValueChanged += GrvTrainingDetails_CellValueChanged;
            this.rpi_lke_TrainingName.CloseUp += Rpi_lke_TrainingName_CloseUp;
            this.rpi_btn_View.Click += Rpi_btn_View_Click;
            this.btnTrainingEntry.Click += BtnTrainingEntry_Click;
            this.btnTableEntry.Click += BtnTableEntry_Click;
            this.btnTrainingDefinitions.Click += BtnTrainingDefinitions_Click;
            this.btnReport.Click += BtnReport_Click;
            this.btnClose.Click += BtnClose_Click;
            Common.Process.RefreshData.ReloadDataEvent += RefreshData_ReloadDataEvent; ;
        }

        private void RefreshData_ReloadDataEvent(object sender, EventArgs e)
        {
            InitTrainings();
        }
        private void GrvTrainings_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadTrainingDetails();
        }

        private void GrvTrainingDetails_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (this._isModified)
            {
                if (!this.grvTrainingDetails.IsNewItemRow(e.PrevFocusedRowHandle))
                {
                    int requirementID = Convert.ToInt32(this.grvTrainingDetails.GetRowCellValue(e.PrevFocusedRowHandle, "PositionTrainingRequirementID"));
                    string defaultLocation = Convert.ToString(this.grvTrainingDetails.GetRowCellValue(e.PrevFocusedRowHandle, "DefaultTrainingLocation"));
                    int result = this._requirementDA.ExecuteNoQuery("Update PositionTrainingRequirements Set DefaultTrainingLocation = {0} Where PositionTrainingRequirementID = {1}", defaultLocation, requirementID);
                }
                this._isModified = false;
            }
        }

        private void GrvTrainingDetails_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if(this._isModified)
            {
                if(e.PrevFocusedColumn.FieldName.Equals("Frequence"))
                {
                    int requirementID = Convert.ToInt32(this.grvTrainingDetails.GetFocusedRowCellValue("PositionTrainingRequirementID"));
                    short frequence = Convert.ToInt16(this.grvTrainingDetails.GetFocusedRowCellValue("Frequence"));
                    int result = this._requirementDA.ExecuteNoQuery("Update PositionTrainingRequirements Set Frequence = {0} Where PositionTrainingRequirementID = {1}", frequence, requirementID);
                }
                this._isModified = false;
            }
        }

        private void GrvTrainingDetails_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if(!this.grvTrainingDetails.IsNewItemRow(e.RowHandle))
            {
                if(!e.Column.FieldName.Equals("TrainingName"))
                {
                    this._isModified = true;
                }

            }
        }

        private void Rpi_lke_TrainingName_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.Value == null)
            {
                return;
            }
            DevExpress.XtraEditors.LookUpEdit editor = (sender as DevExpress.XtraEditors.LookUpEdit);
            editor.EditValue = e.Value;
            TrainingDefinitions row = editor.Properties.GetDataSourceRowByKeyValue(editor.EditValue) as TrainingDefinitions;

            if(this.grvTrainingDetails.IsNewItemRow(this.grvTrainingDetails.FocusedRowHandle))
            {
                InsertNewDetails(row);
            }
            else
            {
                int requirementID = Convert.ToInt32(this.grvTrainingDetails.GetFocusedRowCellValue("PositionTrainingRequirementID"));
                int result = this._requirementDA.ExecuteNoQuery("Update PositionTrainingRequirements Set TrainingDefinitionID = {0}, Frequence = {1} Where PositionTrainingRequirementID = {2}", row.TrainingDefinitionID, row.StandardFrequence, requirementID);
                this.grvTrainingDetails.SetFocusedRowCellValue("Frequence", row.StandardFrequence);
                this.grvTrainingDetails.SetFocusedRowCellValue("DefaultTrainingLocation", row.DefaultTrainingLocation);
                this.grvTrainingDetails.SetFocusedRowCellValue("TrainingDefinitionID", row.TrainingDefinitionID);
                this.grvTrainingDetails.SetFocusedRowCellValue("Remark", row.TrainingRemark);
            }

            this.grvTrainingDetails.FocusedColumn = grcFrequence;
        }

        private void Rpi_btn_View_Click(object sender, EventArgs e)
        {
            //DataProcess<STTrainingRequirementFutureReport_Result> futureReportDA = new DataProcess<STTrainingRequirementFutureReport_Result>();

            rptTrainingRequirementFutureReport rpt = new rptTrainingRequirementFutureReport();
            int trainingID = Convert.ToInt32(this.grvTrainingFuture.GetFocusedRowCellValue("TrainingDefinitionID"));
            //rpt.DataSource = futureReportDA.Executing("STTrainingRequirementFutureReport @TrainingDefinitionID = {0}", trainingID);//.OrderBy(x => x.TrainingExpiryDate);
            rpt.DataSource = FileProcess.LoadTable("STTrainingRequirementFutureReport @TrainingDefinitionID = " + Convert.ToInt32(this.grvTrainingFuture.GetFocusedRowCellValue("TrainingDefinitionID")));
            ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
            tool.ShowPreview();
        }

        private void BtnTrainingEntry_Click(object sender, EventArgs e)
        {
            //OpenForm "frmTrainings"
            frm_S_AO_Dialog_Trainings frm = new frm_S_AO_Dialog_Trainings();
            frm.Show();
        }

        private void BtnTableEntry_Click(object sender, EventArgs e)
        {
            //OpenForm "frmTrainingTableAddNew"
            frm_S_AO_Dialog_TrainingTableAddNew frm = new frm_S_AO_Dialog_TrainingTableAddNew();
            frm.Show();
        }

        private void BtnTrainingDefinitions_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    Wait.Start(this);
            //    GridControl grdReport = new GridControl();
            //    GridView grvReport = new GridView(grdReport);
            //    grdReport.MainView = grvReport;
            //    grdReport.ForceInitialize();
            //    grdReport.BindingContext = new BindingContext();
            //    grdReport.DataSource = FileProcess.LoadTable("Select TrainingDefinitions.TrainingDefinitionID, TrainingDefinitions.TrainingName, TrainingDefinitions.TrainingType, TrainingDefinitions.StandardFrequence, TrainingDefinitions.TrainingRemark From TrainingDefinitions");
            //    grvReport.PopulateColumns();

            //    // Export data to excel file
            //    string pathSaveFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //    string fileName = pathSaveFile + "\\" + "TrainingDefinitions_" + DateTime.Now.ToString("dd_MM_yy") + ".xlsx";

            //    grvReport.ExportToXlsx(fileName);

            //    System.Diagnostics.Process.Start(fileName);
            //    Wait.Close();
            //}
            //catch (Exception ex)
            //{
            //    Wait.Close();
            //    XtraMessageBox.Show(ex.Message, "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            frm_S_AO_TrainingDefinitions frmTrainingDefinition= new frm_S_AO_TrainingDefinitions(this.frmTrainingDefinitionGroup);
            frmTrainingDefinition.Show();
        }

        private void BtnReport_Click(object sender, EventArgs e)
        {
            rptTrainingsFDTD rpt = new rptTrainingsFDTD(this.dtFrom.DateTime, this.dtTo.DateTime);
            rpt.DataSource = FileProcess.LoadTable("STTrainingFDTDReport @FromDate = '"+this.dtFrom.DateTime.ToString("yyyy-MM-dd")+ "', @Todate = '" + this.dtTo.DateTime.ToString("yyyy-MM-dd") + "'");
            ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
            tool.ShowPreview();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Load Data
        private void LoadPositions()
        {
            this.grdTrainings.DataSource = FileProcess.LoadTable("ST_WMS_LoadTrainingPositions");
            LoadTrainingDetails();
        }

        private void LoadTrainingDetails()
        {
            this._tbTrainingDetails = FileProcess.LoadTable("ST_WMS_LoadTrainingByPositions " + this.grvTrainings.GetFocusedRowCellValue("PositionID"));
            this.grdTrainingDetails.DataSource = this._tbTrainingDetails;
        }

        private void LoadTrainingFuture()
        {
            this.grdTrainingFuture.DataSource = FileProcess.LoadTable("STTrainingRequirementFuture");
        }

        private void InitTrainings()
        {
            DataProcess<TrainingDefinitions> trainDefinitionDA = new DataProcess<TrainingDefinitions>();
            //THis is where the filter is needed for group
            this.rpi_lke_TrainingName.DataSource = trainDefinitionDA.Select().OrderBy(t => t.TrainingName);
            this.rpi_lke_TrainingName.ValueMember = "TrainingName";
            this.rpi_lke_TrainingName.DisplayMember = "TrainingName";
        }
        private void Init_Stores()
        {
            DataProcess<Stores> loadStoreInfo = new DataProcess<Stores>();
            this.rpi_lke_Store.DataSource = loadStoreInfo.Select();
            this.rpi_lke_Store.ValueMember = "StoreID";
            this.rpi_lke_Store.DisplayMember = "StoreDescription";
        }
       
        private void Init_SafeTeam()
        {
            DataProcess<EmployeeSafetyTeam> loadSafeTeam = new DataProcess<EmployeeSafetyTeam>();
            this.rpi_lke_SafeTeam.DataSource = loadSafeTeam.Select();
            this.rpi_lke_SafeTeam.ValueMember = "EmployeeSafetyTeamID";
            this.rpi_lke_SafeTeam.DisplayMember = "SafetyTeamDescription";
        }
        #endregion

        private void InsertNewDetails(TrainingDefinitions training)
        {
            PositionTrainingRequirements requirement = new PositionTrainingRequirements();
            requirement.TrainingDefinitionID = training.TrainingDefinitionID;
            requirement.Frequence = training.StandardFrequence;
            requirement.DefaultTrainingLocation = training.DefaultTrainingLocation;
            requirement.Remark = training.TrainingRemark;
            requirement.PositionID = Convert.ToInt32(this.grvTrainings.GetFocusedRowCellValue("PositionID"));

            requirement.EmployeeSafetyTeamID = 1;// Convert.ToInt32(this.grvTrainings.GetFocusedRowCellValue("EmployeeSafetyTeamID"));
            requirement.StoreID = AppSetting.CurrentUser.StoreID; //Convert.ToInt32(this.grvTrainings.GetFocusedRowCellValue("StoreID"));

            int result = this._requirementDA.Insert(requirement);
            LoadTrainingDetails();
            this.grvTrainingDetails.FocusedRowHandle = this._tbTrainingDetails.Rows.Count - 1;
        }

        private void btnSummary_Click(object sender, EventArgs e)
        {
            frm_S_AO_EmployeeTrainingSummary frm = new frm_S_AO_EmployeeTrainingSummary();
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
        }

        private void rpi_lke_Store_EditValueChanged(object sender, EventArgs e)
        {
            var lke_store = (DevExpress.XtraEditors.LookUpEdit)sender;
            int requirementID = Convert.ToInt32(this.grvTrainingDetails.GetFocusedRowCellValue("PositionTrainingRequirementID"));
            int result = this._requirementDA.ExecuteNoQuery("Update PositionTrainingRequirements Set StoreID = {0} Where PositionTrainingRequirementID = {1}", lke_store.EditValue, requirementID);
            if(result<0)
            {
                MessageBox.Show("Error Update Store", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rpi_lke_SafeTeam_EditValueChanged(object sender, EventArgs e)
        {
            var lke_safeteam = (DevExpress.XtraEditors.LookUpEdit)sender;
            int requirementID = Convert.ToInt32(this.grvTrainingDetails.GetFocusedRowCellValue("PositionTrainingRequirementID"));
            int result = this._requirementDA.ExecuteNoQuery("Update PositionTrainingRequirements Set EmployeeSafetyTeamID = {0} Where PositionTrainingRequirementID = {1}", lke_safeteam.EditValue, requirementID);
            if (result < 0)
            {
                MessageBox.Show("Error Update SafeTeam", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdTrainingDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {

                if (MessageBox.Show("You are about to delete a PositionTraining .", "TPWMS",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                 == DialogResult.Yes)
                {
                    int requirementID = Convert.ToInt32(this.grvTrainingDetails.GetFocusedRowCellValue("PositionTrainingRequirementID"));
                    int result = this._requirementDA.ExecuteNoQuery("delete from PositionTrainingRequirements  Where PositionTrainingRequirementID = {0}", requirementID);
                    if (result < 0)
                    {
                        MessageBox.Show("Error Delete PositionTraining", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadTrainingDetails();
                }
            }
        }

        private void btnTrainingDefinitionsGroup_Click(object sender, EventArgs e)
        {
            try {
                this.frmTrainingDefinitionGroup.Show();
            }
            catch
            {
                frm_S_AO_TrainingDefinitionGroup frm = new frm_S_AO_TrainingDefinitionGroup();
                frm.Show();
            }
        }
    }
}
