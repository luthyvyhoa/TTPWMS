using Common.Controls;
using DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using UI.Helper;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_MHLWorkDefinitionList : frmBaseForm
    {
        private DataProcess<ST_WMS_LoadWorkDefinitionList_Result> dataProcess;
        public frm_WM_MHLWorkDefinitionList()
        {
            // Init controls to desiger
            InitializeComponent();
        }

        private void disableEditClumn()
        {
            gridColumn1.OptionsColumn.AllowEdit = false;
            gridColumn2.OptionsColumn.AllowEdit = false;
            gridColumn3.OptionsColumn.AllowEdit = false;
            gridColumn4.OptionsColumn.AllowEdit = false;
            gridColumn5.OptionsColumn.AllowEdit = false;
            gridColumn6.OptionsColumn.AllowEdit = false;
            gridColumn7.OptionsColumn.AllowEdit = false;
            gridColumn8.OptionsColumn.AllowEdit = false;
            gridColumn6.AppearanceCell.Options.UseBackColor = false;
            gridColumn6.AppearanceCell.Options.UseForeColor = false;
            gridColumn6.AppearanceCell.Options.UseFont = false;
        }

        private void initData()
        {
            dataProcess = new DataProcess<ST_WMS_LoadWorkDefinitionList_Result>();
            grdMHLWorkDefinitionList.DataSource = this.dataProcess.Executing("ST_WMS_LoadWorkDefinitionList");
            rpi_lke_Customer.DataSource = AppSetting.CustomerList.Where(c => c.CustomerDiscontinued == false && c.CustomerMainID == c.CustomerID).ToList();
            rpi_lke_Customer.DisplayMember = "CustomerNumber";
            rpi_lke_Customer.ValueMember = "CustomerID";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnClose.Focus();
            Enable_DisableColor(true);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            acCmdSaveRecord();
            btnClose.Focus();
            Enable_DisableColor(false);
        }

        private void Enable_DisableColor(bool enabled)
        {
            if (enabled)
            {
                gridColumn1.OptionsColumn.AllowEdit = true;
                gridColumn2.OptionsColumn.AllowEdit = true;
                gridColumn3.OptionsColumn.AllowEdit = true;
                gridColumn4.OptionsColumn.AllowEdit = true;
                gridColumn5.OptionsColumn.AllowEdit = true;
                gridColumn6.OptionsColumn.AllowEdit = true;
                gridColumn8.OptionsColumn.AllowEdit = true;
                gridColumn6.AppearanceCell.Options.UseBackColor = true;
                gridColumn6.AppearanceCell.Options.UseForeColor = true;
                gridColumn6.AppearanceCell.Options.UseFont = true;
                gridColumn6.AppearanceCell.BackColor = System.Drawing.Color.Blue;
                gridColumn6.AppearanceCell.ForeColor = System.Drawing.Color.White;
                gridColumn6.AppearanceCell.Font = new System.Drawing.Font("Lato", 8.25F, System.Drawing.FontStyle.Bold);
            }
            else
            {
                disableEditClumn();
                gridColumn8.AppearanceCell.Options.UseForeColor = false;
                gridColumn8.AppearanceCell.Options.UseFont = false;
            }
        }

        private void acCmdSaveRecord()
        {
            IList<ST_WMS_LoadWorkDefinitionList_Result> sourceUpdate = (IList<ST_WMS_LoadWorkDefinitionList_Result>)grdMHLWorkDefinitionList.DataSource;
            DataProcess<MHLWorkDefinitions> MHLWorkDefinitionsDA = new DataProcess<MHLWorkDefinitions>();
            IList<MHLWorkDefinitions> listWorkDefinition = new List<MHLWorkDefinitions>();
            MHLWorkDefinitions mhlWorkDefinitions = null;
            foreach (var item in sourceUpdate.Where(x => x.IsModified == true).ToList())
            {
                mhlWorkDefinitions = MHLWorkDefinitionsDA.Select(w => w.MHLWorkDefinitionID == item.MHLWorkDefinitionID).FirstOrDefault();
                mhlWorkDefinitions.JobName = item.JobName;
                mhlWorkDefinitions.MHLWorkDefinitionNumber = item.MHLWorkDefinitionNumber;
                mhlWorkDefinitions.UnitPrice = item.UnitPrice;
                mhlWorkDefinitions.Unit = item.Unit;
                mhlWorkDefinitions.Description = item.Description;
                mhlWorkDefinitions.ServiceID = item.ServiceID;
                mhlWorkDefinitions.CustomerMainID = item.CustomerMainID;
                listWorkDefinition.Add(mhlWorkDefinitions);
            }
            MHLWorkDefinitionsDA.Update(listWorkDefinition.ToArray());
        }

        private void grvMHLWorkDefinitionList_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            grvMHLWorkDefinitionList.SetRowCellValue(e.RowHandle, "IsModified", 1);
        }

        private void rpi_btn_View_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            // Get selected row
            ST_WMS_LoadWorkDefinitionList_Result selectedRow = (ST_WMS_LoadWorkDefinitionList_Result) grvMHLWorkDefinitionList.GetFocusedRow();
            frm_WM_MHLWorkDefinitions form = new frm_WM_MHLWorkDefinitions(selectedRow.MHLWorkDefinitionID);
            form.Show();
        }

        private void frm_WM_MHLWorkDefinitionList_Load(object sender, EventArgs e)
        {
            // Init data to display on controls
            initData();

            // Disable edit column value
            disableEditClumn();
        }

        private void frm_WM_MHLWorkDefinitionList_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
    }
}
