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
    public partial class frm_S_AO_Dialog_TrainingAddNew : Common.Controls.frmBaseForm
    {
        private bool _isAddNew;
        private string strListEmployees ="";

        public frm_S_AO_Dialog_TrainingAddNew()
        {
            InitializeComponent();
            this._isAddNew = false;
            this.dtTrainingDate.EditValue = DateTime.Now;
        }

        private void frm_S_AO_Dialog_TrainingAddNew_Load(object sender, EventArgs e)
        {
            InitEmployees();
            InitUnits();
            SetEvents();
            
        }

        private void SetEvents()
        {
            this.lkeEmployee.CloseUp += LkeEmployee_CloseUp;
            this.btnOpen.Click += BtnOpen_Click;
            this.btnOK.Click += BtnOK_Click;
            this.btnClose.Click += BtnClose_Click;
        }

        private void LkeEmployee_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            this.lkeEmployee.EditValue = e.Value;
            this.txtEmployeeName.Text = Convert.ToString(this.lkeEmployee.GetColumnValue("VietnamName"));
            InitTrainings();
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(this.txtDocumentFolder.Text);
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            strListEmployees = "";
            int count = 0;
            foreach (var index in this.grv_EmployeeList.GetSelectedRows())
            {
               

                strListEmployees += grv_EmployeeList.GetRowCellValue(index, "EmployeeID");
                
                if (count < this.grv_EmployeeList.SelectedRowsCount - 1)
                {
                    this.strListEmployees += ",";                
                }
                count++;
            }

            try
            {
                DataProcess<object> trainingDA = new DataProcess<object>();
                int result = 0;
                string strSQL = "";
                if(count > 0 && strListEmployees.Length > 0)
                {
                    strSQL = "STTrainingInsertAll '" + this.dtTrainingDate.DateTime.Date.ToString("yyyy-MM-dd") + "','" +
                    AppSetting.CurrentUser.LoginName + "','" + this.txtTrainingLocation.Text + "','" + this.mmeTrainingDescription.Text + "'," +
                    Convert.ToInt32(this.speCost.EditValue) + ",'" + Convert.ToString(this.lkeUnits.EditValue) + "','" + Convert.ToString(this.speDuration.Value) + "','" +
                    strListEmployees + "','" + this.txtCostCoverBy.Text + "','" + this.txtDocumentFolder.Text + "'," + Convert.ToInt32(this.lkeTrainings.EditValue);
                    result = trainingDA.ExecuteNoQuery(strSQL);
                }
                else
                {
                    strSQL = "STTrainingInsert '" + this.dtTrainingDate.DateTime.Date.ToString("yyyy-MM-dd") + "','" +
                    AppSetting.CurrentUser.LoginName + "','" + this.txtTrainingLocation.Text + "','" + this.mmeTrainingDescription.Text + "'," +
                    Convert.ToInt32(this.speCost.EditValue) + ",'" + Convert.ToString(this.lkeUnits.EditValue) + "','" + Convert.ToString(this.speDuration.Value) + "'," +
                    Convert.ToInt32(this.lkeEmployee.EditValue) + ",'" + this.txtCostCoverBy.Text + "','" + this.txtDocumentFolder.Text + "'," + Convert.ToInt32(this.lkeTrainings.EditValue);
                    result = trainingDA.ExecuteNoQuery(strSQL);

                    //result = trainingDA.ExecuteNoQuery("STTrainingInsert @TrainingDate = {0}, @CreatedBy = {1}, @TrainingLocation = {2}, @TrainingDescription = {3}, @TrainingCost = {4}, @CurrencyUnit = {5}, @TrainingDuration = {6}, @EmployeeID = {7}, @CostCoverBy = {8}, @DocumentFolder = {9}, @TrainingDefinitionID = {10}",
                    //this.dtTrainingDate.DateTime.Date, AppSetting.CurrentUser.LoginName, this.txtTrainingLocation.Text,
                    //this.mmeTrainingDescription.Text, Convert.ToInt32(this.speCost.EditValue), Convert.ToString(this.lkeUnits.EditValue),
                    //Convert.ToString(this.speDuration.Value), Convert.ToInt32(this.lkeEmployee.EditValue), this.txtCostCoverBy.Text,
                    //this.txtDocumentFolder.Text, Convert.ToInt32(this.lkeTrainings.EditValue));
                }

                if (result>0)
                {
                    this._isAddNew = true;
                    //this.lkeEmployee.EditValue = null;
                    //this.txtEmployeeName.Text = String.Empty;
                    //this.lkeEmployee.Focus();
                    //this.lkeEmployee.ShowPopup();
                    MessageBox.Show("Success Data Inserted !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error Data Inserted !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }

                
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            if(this._isAddNew)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

        #region Load Data
        private void InitEmployees()
        {
            this.lkeEmployee.Properties.DataSource = AppSetting.EmployessList.Where(e => e.Active == true).OrderBy(e => e.EmployeeID);
            this.lkeEmployee.Properties.ValueMember = "EmployeeID";
            this.lkeEmployee.Properties.DisplayMember = "EmployeeID";
            this.grcEmployeeList.DataSource = AppSetting.EmployessList.Where(e => e.Active == true).OrderBy(e => e.EmployeeID);
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

            this.lkeUnits.Properties.DataSource = source;
            this.lkeUnits.Properties.ValueMember = "Currency";
            this.lkeUnits.Properties.DisplayMember = "Currency";
        }

        private void InitTrainings()
        {
            this.lkeTrainings.Properties.DataSource = FileProcess.LoadTable("STComboTrainingRequirements @EmployeeID = " + Convert.ToInt32(this.lkeEmployee.EditValue));
            this.lkeTrainings.Properties.DisplayMember = "TrainingName";
            this.lkeTrainings.Properties.ValueMember = "TrainingDefinitionID";
        }
        #endregion
    }
}
