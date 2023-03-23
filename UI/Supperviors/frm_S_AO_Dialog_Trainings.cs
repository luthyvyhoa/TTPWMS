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

namespace UI.Supperviors
{
    public partial class frm_S_AO_Dialog_Trainings : Common.Controls.frmBaseForm
    {
        private DataTable _tbTrainings;
        private DataRow _currentTrainings;
        private bool _isModified;
        private bool _isAddNew;
        private int _trainingID;

        public int TrainingIDFind
        {
            get
            {
                return _trainingID;
            }
            set
            {
                _trainingID = value;
            }
        }

        public frm_S_AO_Dialog_Trainings()
        {
            InitializeComponent();
            this._tbTrainings = new DataTable();
            this._isModified = false;
            this._isAddNew = false;
            this._trainingID = 0;
            this.dtFrom.EditValue = DateTime.Now.AddDays(-365);
            this.dtTo.EditValue = DateTime.Now;
        }

        private void frm_S_AO_Trainings_Load(object sender, EventArgs e)
        {
            InitEmployees();
            InitCurrency();
            LoadTrainings();
            SetEvents();
        }

        private void SetEvents()
        {
            this.nvtTrainings.ButtonClick += NvtTrainings_ButtonClick;
            this.dtExpiryDate.Leave += DtExpiryDate_Leave;
            this.dtTrainingDate.Leave += DtTrainingDate_Leave;
            this.dtTrainingDate.EditValueChanged += DtTrainingDate_EditValueChanged;
            this.dtExpiryDate.EditValueChanged += DtExpiryDate_EditValueChanged;
            this.lkeTrainings.Leave += LkeTrainings_Leave;
            this.lkeEmployeeID.Leave += LkeEmployeeID_Leave;
            this.lkeCurrency.Leave += LkeCurrency_Leave;
            this.speDuration.Leave += SpeDuration_Leave;
            this.speCost.Leave += SpeCost_Leave;
            this.txtLocation.Leave += TxtLocation_Leave;
            this.txtDocument.Leave += TxtDocument_Leave;
            this.txtDepartment.Leave += TxtDepartment_Leave;
            this.txtCoveredBy.Leave += TxtCoveredBy_Leave;
            this.mmeEmployee.Leave += MmeEmployee_Leave;
            this.mmeManager.Leave += MmeManager_Leave;
            this.mmeDescription.Leave += MmeDescription_Leave;
            this.speDuration.EditValueChanged += SpeDuration_EditValueChanged;
            this.speCost.EditValueChanged += SpeCost_EditValueChanged;
            this.txtLocation.TextChanged += TxtLocation_TextChanged;
            this.txtDocument.TextChanged += TxtDocument_TextChanged;
            this.txtDepartment.TextChanged += TxtDepartment_TextChanged;
            this.txtCoveredBy.TextChanged += TxtCoveredBy_TextChanged;
            this.mmeManager.TextChanged += MmeManager_TextChanged;
            this.mmeEmployee.TextChanged += MmeEmployee_TextChanged;
            this.mmeDescription.TextChanged += MmeDescription_TextChanged;
            this.lkeCurrency.CloseUp += LkeCurrency_CloseUp;
            this.lkeTrainings.CloseUp += LkeTrainings_CloseUp;
            this.lkeEmployeeID.CloseUp += LkeEmployeeID_CloseUp;
            this.btnConfirm.CheckedChanged += BtnConfirm_CheckedChanged;
            this.btnOpen.Click += BtnOpen_Click;
            this.btnTableView.Click += BtnTableView_Click;
            this.btnReport.Click += BtnReport_Click;
            this.btnDelete.Click += BtnDelete_Click;
            this.btnClose.Click += BtnClose_Click;
            this.nvtTrainings.PositionChanged += NvtTrainings_PositionChanged;
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.F3)
            {
                frm_WM_Attachments.Instance.OrderNumber = this.txtTrainingNumber.Text;
                frm_WM_Attachments.Instance.CustomerID = 0;
                if (frm_WM_Attachments.Instance.Enabled)
                {
                    frm_WM_Attachments.Instance.ShowDialog();
                }
            }
            return base.ProcessDialogKey(keyData);
        }

        #region Events
        private void NvtTrainings_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Append)
            {

                this._currentTrainings = this._tbTrainings.NewRow();
                this._currentTrainings["TrainingDate"] = DateTime.Now;
                this._currentTrainings["CreatedBy"] = AppSetting.CurrentUser.LoginName;
                this._currentTrainings["CreatedTime"] = DateTime.Now;
                this._currentTrainings["TrainingConfirm"] = false;
                this._tbTrainings.Rows.Add(this._currentTrainings);
                this._isAddNew = true;
                this.nvtTrainings.Position = this._tbTrainings.Rows.Count;
                this.lkeEmployeeID.Focus();
                e.Handled = true;
            }
            else
            {
                if (this._isAddNew)
                {
                    DateTime defaultTime = new DateTime(1, 1, 1);
                    if (this.dtExpiryDate.DateTime <= defaultTime)
                    {
                        this.dtExpiryDate.EditValue = DateTime.Now.AddDays(365);
                    }
                    InsertTraining();
                }
            }
        }

        private void DtExpiryDate_Leave(object sender, EventArgs e)
        {
            if (this._isAddNew)
            {
                DateTime defaultTime = new DateTime(1, 1, 1);
                if (this.dtExpiryDate.DateTime <= defaultTime)
                {
                    this.dtExpiryDate.EditValue = DateTime.Now.AddDays(365);
                }
                InsertTraining();
            }
            if (this._isModified)
            {
                DataProcess<object> trainingDA = new DataProcess<object>();
                int trainingID = Convert.ToInt32(this._currentTrainings["TrainingID"]);

                int result = trainingDA.ExecuteNoQuery("Update Trainings Set TrainingExpiryDate = {0} Where TrainingID = {1}", dtExpiryDate.DateTime, trainingID);
            }
        }

        private void DtTrainingDate_Leave(object sender, EventArgs e)
        {
            if (this._isModified)
            {
                DataProcess<object> trainingDA = new DataProcess<object>();
                int trainingID = Convert.ToInt32(this._currentTrainings["TrainingID"]);

                int result = trainingDA.ExecuteNoQuery("Update Trainings Set TrainingDate = {0} Where TrainingID = {1}", dtTrainingDate.DateTime, trainingID);
            }
        }

        private void DtTrainingDate_EditValueChanged(object sender, EventArgs e)
        {
            if (!this._isAddNew)
            {
                this._isModified = true;
            }
            this._currentTrainings["TrainingDate"] = dtTrainingDate.DateTime;
        }

        private void DtExpiryDate_EditValueChanged(object sender, EventArgs e)
        {
            if (!this._isAddNew)
            {
                this._isModified = true;
            }
            this._currentTrainings["TrainingExpiryDate"] = dtExpiryDate.DateTime;
        }

        private void LkeTrainings_Leave(object sender, EventArgs e)
        {
            if (this._isModified)
            {
                DataProcess<object> trainingDA = new DataProcess<object>();
                int trainingID = Convert.ToInt32(this._currentTrainings["TrainingID"]);

                int result = trainingDA.ExecuteNoQuery("Update Trainings Set TrainingDefinitionID = {0} Where TrainingID = {1}", Convert.ToInt32(this.lkeTrainings.EditValue), trainingID);
            }
        }

        private void LkeEmployeeID_Leave(object sender, EventArgs e)
        {
            if (this._isModified)
            {
                DataProcess<object> trainingDA = new DataProcess<object>();
                int trainingID = Convert.ToInt32(this._currentTrainings["TrainingID"]);

                int result = trainingDA.ExecuteNoQuery("Update Trainings Set EmployeeID = {0} Where TrainingID = {1}", Convert.ToInt32(this.lkeEmployeeID.EditValue), trainingID);
            }
        }

        private void LkeCurrency_Leave(object sender, EventArgs e)
        {
            if (this._isModified)
            {
                DataProcess<object> trainingDA = new DataProcess<object>();
                int trainingID = Convert.ToInt32(this._currentTrainings["TrainingID"]);

                int result = trainingDA.ExecuteNoQuery("Update Trainings Set CurrencyUnit = {0} Where TrainingID = {1}", Convert.ToString(this.lkeCurrency.EditValue), trainingID);
            }
        }

        private void SpeDuration_Leave(object sender, EventArgs e)
        {
            if (this._isModified)
            {
                DataProcess<object> trainingDA = new DataProcess<object>();
                int trainingID = Convert.ToInt32(this._currentTrainings["TrainingID"]);

                int result = trainingDA.ExecuteNoQuery("Update Trainings Set TrainingDuration = {0} Where TrainingID = {1}", Convert.ToDecimal(this._currentTrainings["TrainingDuration"]), trainingID);
            }
        }

        private void SpeCost_Leave(object sender, EventArgs e)
        {
            if (this._isModified)
            {
                DataProcess<object> trainingDA = new DataProcess<object>();
                int trainingID = Convert.ToInt32(this._currentTrainings["TrainingID"]);

                int result = trainingDA.ExecuteNoQuery("Update Trainings Set TrainingCost = {0} Where TrainingID = {1}", Convert.ToInt32(this._currentTrainings["TrainingCost"]), trainingID);
            }
        }

        private void TxtLocation_Leave(object sender, EventArgs e)
        {
            if (this._isModified)
            {
                DataProcess<object> trainingDA = new DataProcess<object>();
                int trainingID = Convert.ToInt32(this._currentTrainings["TrainingID"]);

                int result = trainingDA.ExecuteNoQuery("Update Trainings Set TrainingLocation = {0} Where TrainingID = {1}", this.txtLocation.Text, trainingID);
            }
        }

        private void TxtDocument_Leave(object sender, EventArgs e)
        {
            if (this._isModified)
            {
                DataProcess<object> trainingDA = new DataProcess<object>();
                int trainingID = Convert.ToInt32(this._currentTrainings["TrainingID"]);

                int result = trainingDA.ExecuteNoQuery("Update Trainings Set DocumentFolder = {0} Where TrainingID = {1}", this.txtDocument.Text, trainingID);
            }
        }

        private void TxtDepartment_Leave(object sender, EventArgs e)
        {
            if (this._isModified)
            {
                DataProcess<object> trainingDA = new DataProcess<object>();
                int trainingID = Convert.ToInt32(this._currentTrainings["TrainingID"]);

                int result = trainingDA.ExecuteNoQuery("Update Trainings Set Department = {0} Where TrainingID = {1}", Convert.ToInt32(this._currentTrainings["Department"]), trainingID);
            }
        }

        private void TxtCoveredBy_Leave(object sender, EventArgs e)
        {
            if (this._isModified)
            {
                DataProcess<object> trainingDA = new DataProcess<object>();
                int trainingID = Convert.ToInt32(this._currentTrainings["TrainingID"]);

                int result = trainingDA.ExecuteNoQuery("Update Trainings Set CostCoverBy = {0} Where TrainingID = {1}", this.txtCoveredBy.Text, trainingID);
            }
        }

        private void MmeEmployee_Leave(object sender, EventArgs e)
        {
            if (this._isModified)
            {
                DataProcess<object> trainingDA = new DataProcess<object>();
                int trainingID = Convert.ToInt32(this._currentTrainings["TrainingID"]);

                int result = trainingDA.ExecuteNoQuery("Update Trainings Set EmployeeFeedback = {0} Where TrainingID = {1}", this.mmeManager.Text, trainingID);
            }
        }

        private void MmeManager_Leave(object sender, EventArgs e)
        {
            if (this._isModified)
            {
                DataProcess<object> trainingDA = new DataProcess<object>();
                int trainingID = Convert.ToInt32(this._currentTrainings["TrainingID"]);

                int result = trainingDA.ExecuteNoQuery("Update Trainings Set ManagerFeedback = {0} Where TrainingID = {1}", this.mmeManager.Text, trainingID);
            }
        }

        private void MmeDescription_Leave(object sender, EventArgs e)
        {
            if (this._isModified)
            {
                DataProcess<object> trainingDA = new DataProcess<object>();
                int trainingID = Convert.ToInt32(this._currentTrainings["TrainingID"]);

                int result = trainingDA.ExecuteNoQuery("Update Trainings Set TrainingDescription = {0} Where TrainingID = {1}", this.mmeDescription.Text, trainingID);
            }
        }

        private void SpeDuration_EditValueChanged(object sender, EventArgs e)
        {
            if (!this._isAddNew)
            {
                this._isModified = true;
            }
            this._currentTrainings["TrainingDuration"] = this.speCost.Value;
        }

        private void SpeCost_EditValueChanged(object sender, EventArgs e)
        {
            if (!this._isAddNew)
            {
                this._isModified = true;
            }
            this._currentTrainings["TrainingCost"] = (int)this.speCost.Value;
        }

        private void TxtLocation_TextChanged(object sender, EventArgs e)
        {
            if (!this._isAddNew)
            {
                this._isModified = true;
            }
            this._currentTrainings["TrainingLocation"] = this.txtLocation.Text;
        }

        private void TxtDocument_TextChanged(object sender, EventArgs e)
        {
            if (!this._isAddNew)
            {
                this._isModified = true;
            }
            this._currentTrainings["DocumentFolder"] = this.txtDocument.Text;
        }

        private void TxtDepartment_TextChanged(object sender, EventArgs e)
        {
            if (!this._isAddNew)
            {
                this._isModified = true;
            }
            this._currentTrainings["Department"] = Convert.ToInt32(this.txtDepartment.Text);
        }

        private void TxtCoveredBy_TextChanged(object sender, EventArgs e)
        {
            if (!this._isAddNew)
            {
                this._isModified = true;
            }
            this._currentTrainings["CostCoverBy"] = this.txtCoveredBy.Text;
        }

        private void MmeManager_TextChanged(object sender, EventArgs e)
        {
            if (!this._isAddNew)
            {
                this._isModified = true;
            }
            this._currentTrainings["ManagerFeedback"] = this.mmeManager.Text;
        }

        private void MmeEmployee_TextChanged(object sender, EventArgs e)
        {
            if (!this._isAddNew)
            {
                this._isModified = true;
            }
            this._currentTrainings["EmployeeFeedback"] = this.mmeEmployee.Text;
        }

        private void MmeDescription_TextChanged(object sender, EventArgs e)
        {
            if (!this._isAddNew)
            {
                this._isModified = true;
            }
            this._currentTrainings["TrainingDescription"] = this.mmeDescription.Text;
        }

        private void LkeCurrency_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            this.lkeCurrency.EditValue = e.Value;
            if (!this._isAddNew)
            {
                this._isModified = true;
            }
            this._currentTrainings["CurrencyUnit"] = Convert.ToString(this.lkeCurrency.EditValue);
        }

        private void LkeTrainings_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            this.lkeTrainings.EditValue = e.Value;
            if (!this._isAddNew)
            {
                this._isModified = true;
            }
            this._currentTrainings["TrainingDefinitionID"] = Convert.ToInt32(this.lkeTrainings.EditValue);
        }

        private void LkeEmployeeID_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            this.lkeEmployeeID.EditValue = e.Value;
            this._currentTrainings["EmployeeID"] = Convert.ToInt32(this.lkeEmployeeID.EditValue);
            this.txtEmployeeName.Text = Convert.ToString(this.lkeEmployeeID.GetColumnValue("VietnamName"));
            InitTrainings();

            if (!this._isAddNew)
            {
                this._isModified = true;
            }
            else
            {
                this.lkeTrainings.Focus();
                this.lkeTrainings.ShowPopup();
            }
        }

        private void BtnConfirm_CheckedChanged(object sender, EventArgs e)
        {
            if (this.btnConfirm.Checked)
            {
                DataProcess<object> trainingDA = new DataProcess<object>();
                int trainingID = Convert.ToInt32(this._currentTrainings["TrainingID"]);

                int result = trainingDA.ExecuteNoQuery("Update Trainings Set TrainingConfirm = {0} Where TrainingID = {1}", true, trainingID);
                this._currentTrainings["TrainingConfirm"] = true;

                this.btnConfirm.Enabled = false;
                SetReadOnly(true);
            }
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(this.txtDocument.Text);
        }

        private void BtnTableView_Click(object sender, EventArgs e)
        {
            //OpenForm "frmTrainingTableAddNew"
            frm_S_AO_Dialog_TrainingTableAddNew frm = new frm_S_AO_Dialog_TrainingTableAddNew();
            frm.Show();
        }

        private void BtnReport_Click(object sender, EventArgs e)
        {
            rptTrainingsFDTD rpt = new rptTrainingsFDTD(this.dtFrom.DateTime, this.dtTo.DateTime);
            rpt.DataSource = FileProcess.LoadTable("STTrainingFDTDReport @FromDate = '" + this.dtFrom.DateTime.ToString("yyyy-MM-dd") + "', @Todate = '" + this.dtTo.DateTime.ToString("yyyy-MM-dd") + "'");
            ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
            tool.ShowPreview();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (btnConfirm.Checked)
            {
                return;
            }
            DataProcess<object> trainingDA = new DataProcess<object>();
            int trainingID = Convert.ToInt32(this._currentTrainings["TrainingID"]);

            int result = trainingDA.ExecuteNoQuery("Delete From Trainings Where TrainingID = {0}", trainingID);

            LoadTrainings();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NvtTrainings_PositionChanged(object sender, EventArgs e)
        {
            this._currentTrainings = this._tbTrainings.Rows[this.nvtTrainings.Position];
            BindData();
        }
        #endregion

        #region Load Data
        private void LoadTrainings()
        {
            if (this._trainingID == 0)
            {
                this._tbTrainings = FileProcess.LoadTable("SELECT Trainings.TrainingID, Trainings.TrainingDate, Trainings.CreatedBy, Trainings.CreatedTime, Trainings.TrainingLocation, Trainings.TrainingDescription, Trainings.TrainingCost, Trainings.CurrencyUnit, Trainings.TrainingDuration, Trainings.TrainingConfirmedBy, Trainings.TrainingConfirm, Trainings.ConfirmTime, Trainings.EmployeeID, Trainings.Department, Trainings.EmployeeFeedback, Trainings.ManagerFeedback, Trainings.CostCoverBy, Employees.VietnamName, Trainings.DocumentFolder, TrainingDefinitions.TrainingName, Trainings.TrainingDefinitionID, Trainings.TrainingExpiryDate, Trainings.TrainingNumber " +
                                                          "FROM(Trainings LEFT JOIN Employees ON Trainings.EmployeeID = Employees.EmployeeID) LEFT JOIN TrainingDefinitions ON Trainings.TrainingDefinitionID = TrainingDefinitions.TrainingDefinitionID " +
                                                          "ORDER BY Trainings.TrainingID; ");
            }
            else
            {
                this._tbTrainings = FileProcess.LoadTable("SELECT Trainings.TrainingID, Trainings.TrainingDate, Trainings.CreatedBy, Trainings.CreatedTime, Trainings.TrainingLocation, Trainings.TrainingDescription, Trainings.TrainingCost, Trainings.CurrencyUnit, Trainings.TrainingDuration, Trainings.TrainingConfirmedBy, Trainings.TrainingConfirm, Trainings.ConfirmTime, Trainings.EmployeeID, Trainings.Department, Trainings.EmployeeFeedback, Trainings.ManagerFeedback, Trainings.CostCoverBy, Employees.VietnamName, Trainings.DocumentFolder, TrainingDefinitions.TrainingName, Trainings.TrainingDefinitionID, Trainings.TrainingExpiryDate, Trainings.TrainingNumber " +
                                                          "FROM(Trainings LEFT JOIN Employees ON Trainings.EmployeeID = Employees.EmployeeID) LEFT JOIN TrainingDefinitions ON Trainings.TrainingDefinitionID = TrainingDefinitions.TrainingDefinitionID " +
                                                          "WHERE Trainings.TrainingID = " + this._trainingID +
                                                          " ORDER BY Trainings.TrainingID; ");
            }
            this._currentTrainings = this._tbTrainings.NewRow();

            this.nvtTrainings.DataSource = this._tbTrainings;
            this.nvtTrainings.Position = this._tbTrainings.Rows.Count;
            if(this._tbTrainings.Rows.Count>0)
            {
                this._currentTrainings = this._tbTrainings.Rows[this.nvtTrainings.Position];
                BindData();

            }
        }

        private void BindData()
        {
            if (!this._isAddNew)
            {
                //this.txtTrainingID.Text = Convert.ToString(this._currentTrainings["TrainingID"]);
                this.txtTrainingNumber.Text = Convert.ToString(this._currentTrainings["TrainingNumber"]);
            }
            else
            {
                //this.txtTrainingID.Text = "";
                this.txtTrainingNumber.Text = "";
            }
            this.dtTrainingDate.EditValue = Convert.IsDBNull(this._currentTrainings["TrainingDate"]) ? (DateTime?)null : Convert.ToDateTime(this._currentTrainings["TrainingDate"]);
            this.txtCreatedBy.Text = Convert.ToString(this._currentTrainings["CreatedBy"]);
            this.txtCreatedTime.Text = Convert.ToString(this._currentTrainings["CreatedTime"]);
            this.lkeEmployeeID.EditValue = Convert.IsDBNull(this._currentTrainings["EmployeeID"]) ? (int?)null : Convert.ToInt32(this._currentTrainings["EmployeeID"]);
            this.txtEmployeeName.Text = Convert.ToString(this._currentTrainings["VietnamName"]);
            this.txtDepartment.Text = Convert.IsDBNull(this._currentTrainings["Department"]) ? null : Convert.ToString(this._currentTrainings["Department"]);
            InitTrainings();
            this.lkeTrainings.EditValue = Convert.IsDBNull(this._currentTrainings["TrainingDefinitionID"]) ? (int?)null : Convert.ToInt32(this._currentTrainings["TrainingDefinitionID"]);
            this.dtExpiryDate.EditValue = Convert.IsDBNull(this._currentTrainings["TrainingExpiryDate"]) ? (DateTime?)null : Convert.ToDateTime(this._currentTrainings["TrainingExpiryDate"]);
            this.mmeDescription.Text = Convert.IsDBNull(this._currentTrainings["TrainingDescription"]) ? null : Convert.ToString(this._currentTrainings["TrainingDescription"]);
            this.speDuration.EditValue = Convert.IsDBNull(this._currentTrainings["TrainingDuration"]) ? (decimal?)null : Convert.ToDecimal(this._currentTrainings["TrainingDuration"]);
            this.speCost.EditValue = Convert.IsDBNull(this._currentTrainings["TrainingCost"]) ? (int?)null : Convert.ToInt32(this._currentTrainings["TrainingCost"]);
            this.txtLocation.Text = Convert.ToString(this._currentTrainings["TrainingLocation"]);
            this.lkeCurrency.EditValue = Convert.ToString(this._currentTrainings["CurrencyUnit"]);
            this.txtCoveredBy.Text = Convert.ToString(this._currentTrainings["CostCoverBy"]);
            this.mmeEmployee.Text = Convert.IsDBNull(this._currentTrainings["EmployeeFeedback"]) ? null : Convert.ToString(this._currentTrainings["EmployeeFeedback"]);
            this.mmeManager.Text = Convert.IsDBNull(this._currentTrainings["ManagerFeedback"]) ? null : Convert.ToString(this._currentTrainings["ManagerFeedback"]);
            this.txtDocument.Text = Convert.ToString(this._currentTrainings["DocumentFolder"]);
            this.btnConfirm.Checked = Convert.ToBoolean(this._currentTrainings["TrainingConfirm"]);
            this.txtConfirmedBy.Text = Convert.ToString(this._currentTrainings["TrainingConfirmedBy"]);
            this.txtConfirmedTime.Text = Convert.ToString(this._currentTrainings["ConfirmTime"]);
            if (btnConfirm.Checked)
            {
                this.btnConfirm.Enabled = false;
            }
            else
            {
                this.btnConfirm.Enabled = true;
            }
            SetReadOnly(btnConfirm.Checked);
        }

        private void InitCurrency()
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

            this.lkeCurrency.Properties.DataSource = source;
            this.lkeCurrency.Properties.ValueMember = "Currency";
            this.lkeCurrency.Properties.DisplayMember = "Currency";
        }

        private void InitTrainings()
        {
            this.lkeTrainings.Properties.DataSource = FileProcess.LoadTable("STComboTrainingRequirements @EmployeeID = " + Convert.ToInt32(this.lkeEmployeeID.EditValue));
            this.lkeTrainings.Properties.DisplayMember = "TrainingName";
            this.lkeTrainings.Properties.ValueMember = "TrainingDefinitionID";
        }

        private void InitEmployees()
        {
            DataProcess<Employees> empDA = new DataProcess<Employees>();
            this.lkeEmployeeID.Properties.DataSource = empDA.Select(n => n.StoreID == AppSetting.CurrentUser.StoreID && n.Active==true);
            this.lkeEmployeeID.Properties.ValueMember = "EmployeeID";
            this.lkeEmployeeID.Properties.DisplayMember = "EmployeeID";
        }
        #endregion

        private void SetReadOnly(bool isReadOnly)
        {
            this.dtTrainingDate.ReadOnly = isReadOnly;
            this.lkeEmployeeID.ReadOnly = isReadOnly;
            this.txtDepartment.ReadOnly = isReadOnly;
            this.lkeTrainings.ReadOnly = isReadOnly;
            this.dtExpiryDate.ReadOnly = isReadOnly;
            this.mmeDescription.ReadOnly = isReadOnly;
            this.mmeEmployee.ReadOnly = isReadOnly;
            this.mmeManager.ReadOnly = isReadOnly;
            this.txtDocument.ReadOnly = isReadOnly;
            this.txtLocation.ReadOnly = isReadOnly;
            this.speCost.ReadOnly = isReadOnly;
            this.speDuration.ReadOnly = isReadOnly;
            this.lkeCurrency.ReadOnly = isReadOnly;
            this.txtCoveredBy.ReadOnly = isReadOnly;
        }

        private void InsertTraining()
        {
            DataProcess<Trainings> trainingDA = new DataProcess<Trainings>();
            Trainings training = new Trainings();
            training.TrainingDate = Convert.IsDBNull(this._currentTrainings["TrainingDate"]) ? (DateTime?)null : Convert.ToDateTime(this._currentTrainings["TrainingDate"]);
            training.CreatedBy = Convert.ToString(this._currentTrainings["CreatedBy"]);
            training.CreatedTime = Convert.ToDateTime(this._currentTrainings["CreatedTime"]);
            training.EmployeeID = Convert.IsDBNull(this._currentTrainings["EmployeeID"]) ? (int?)null : Convert.ToInt32(this._currentTrainings["EmployeeID"]);
            training.Department = Convert.IsDBNull(this._currentTrainings["Department"]) ? (int?)null : Convert.ToInt32(this._currentTrainings["Department"]);
            training.TrainingDefinitionID = Convert.IsDBNull(this._currentTrainings["TrainingDefinitionID"]) ? (int?)null : Convert.ToInt32(this._currentTrainings["TrainingDefinitionID"]);
            training.TrainingExpiryDate = Convert.IsDBNull(this._currentTrainings["TrainingExpiryDate"]) ? (DateTime?)null : Convert.ToDateTime(this._currentTrainings["TrainingExpiryDate"]);
            training.TrainingDescription = Convert.IsDBNull(this._currentTrainings["TrainingDescription"]) ? null : Convert.ToString(this._currentTrainings["TrainingDescription"]);
            training.TrainingDuration = Convert.IsDBNull(this._currentTrainings["TrainingDuration"]) ? (decimal?)null : Convert.ToDecimal(this._currentTrainings["TrainingDuration"]);
            training.TrainingCost = Convert.IsDBNull(this._currentTrainings["TrainingCost"]) ? (int?)null : Convert.ToInt32(this._currentTrainings["TrainingCost"]);
            training.TrainingLocation = Convert.ToString(this._currentTrainings["TrainingLocation"]);
            training.CurrencyUnit = Convert.ToString(this._currentTrainings["CurrencyUnit"]);
            training.CostCoverBy = Convert.ToString(this._currentTrainings["CostCoverBy"]);
            training.EmployeeFeedback = Convert.IsDBNull(this._currentTrainings["EmployeeFeedback"]) ? null : Convert.ToString(this._currentTrainings["EmployeeFeedback"]);
            training.ManagerFeedback = Convert.IsDBNull(this._currentTrainings["ManagerFeedback"]) ? null : Convert.ToString(this._currentTrainings["ManagerFeedback"]);
            training.DocumentFolder = Convert.ToString(this._currentTrainings["DocumentFolder"]);
            training.TrainingConfirm = Convert.ToBoolean(this._currentTrainings["TrainingConfirm"]);
            training.TrainingConfirmedBy = Convert.ToString(this._currentTrainings["TrainingConfirmedBy"]);
            training.ConfirmTime = Convert.IsDBNull(this._currentTrainings["ConfirmTime"]) ? (DateTime?)null : Convert.ToDateTime(this._currentTrainings["ConfirmTime"]);

            int result = trainingDA.Insert(training);

            this._isAddNew = false;
            LoadTrainings();
        }

        private void Btn_S_NewDialogTraining_Click(object sender, EventArgs e)
        {
            this._currentTrainings = this._tbTrainings.NewRow();
            this._currentTrainings["TrainingDate"] = DateTime.Now;
            this._currentTrainings["CreatedBy"] = AppSetting.CurrentUser.LoginName;
            this._currentTrainings["CreatedTime"] = DateTime.Now;
            this._currentTrainings["TrainingConfirm"] = false;
            this._tbTrainings.Rows.Add(this._currentTrainings);
            this._isAddNew = true;
            this.nvtTrainings.Position = this._tbTrainings.Rows.Count;
            this.lkeEmployeeID.Focus();

            //this._currentTrainings = this._tbTrainings.NewRow();
            //this._currentTrainings["TrainingDate"] = DateTime.Now;
            //this._currentTrainings["CreatedBy"] = AppSetting.CurrentUser.LoginName;
            //this._currentTrainings["CreatedTime"] = DateTime.Now;
            //this._currentTrainings["TrainingConfirm"] = false;
            //this._tbTrainings.Rows.Add(this._currentTrainings);
            //this._isAddNew = true;
            //this.nvtTrainings.Position = this._tbTrainings.Rows.Count;    
            //this.lkeEmployeeID.Focus();

        }

        private void Btn_S_AO_UpdateDialogTraining_Click(object sender, EventArgs e)
        {
            DateTime defaultTime = new DateTime(1, 1, 1);
            if (this.dtExpiryDate.DateTime <= defaultTime)
            {
                this.dtExpiryDate.EditValue = DateTime.Now.AddDays(365);
            }
            InsertTraining();
        }
    }
}