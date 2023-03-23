using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DA;


namespace UI.MasterSystemSetup
{
    public partial class frm_MSS_EmployeeKPI : Form
    {
        private BindingList<EmployeeKPIDefinition> bindingList = null;
        private BindingList<EmployeeKPIPosition> bindingListPosition = null;
        EmployeeKPIDefinition currentDefinition = new EmployeeKPIDefinition();
        EmployeeKPIPosition currentPosition = new EmployeeKPIPosition();
        DataProcess<EmployeeKPIDefinition> empDefinitionDA = new DataProcess<EmployeeKPIDefinition>();
        DataProcess<Positions> positionDA = new DataProcess<Positions>();
        DataProcess<EmployeeKPIPosition> empKPIPosition = new DataProcess<EmployeeKPIPosition>();
        DataProcess<EmployeeKPICategory> empCategoryDA = new DataProcess<EmployeeKPICategory>();
        public frm_MSS_EmployeeKPI()
        {
            InitializeComponent();
            InitEmployeeKPICategory();
            InitPosition();
            LoadEmployeeKPIDefinition();
            LoadEmployeeKPIPosition();
            InitEvent();
        }
        private void InitPosition()
        {
            this.rpi_lkePosition.DataSource = positionDA.Select();
            this.rpi_lkePosition.ValueMember = "PositionID";
            this.rpi_lkePosition.DisplayMember = "PositionVietnam";

            this.rpi_lkeEmployeeKPIDefinitionID.DataSource = empDefinitionDA.Select();
            this.rpi_lkeEmployeeKPIDefinitionID.DisplayMember = "EmployeeKPIDescriptions";
            this.rpi_lkeEmployeeKPIDefinitionID.ValueMember = "EmployeeKPIDefinitionID";

        }
        private void InitEvent()
        {
            this.rpi_lkeEmKPICat.CloseUp += rpi_lkeEmKPICat_CloseUp;
            this.grvKPIDefinition.CellValueChanged += grvKPIDefinition_CellValueChanged;
            this.grvKPIPosition.CellValueChanged += grvKPIPosition_CellValueChanged;
            this.grvKPIDefinition.RowClick += grvKPIDefinition_RowClick;
            this.grvKPIDefinition.FocusedRowChanged += grvKPIDefinition_FocusedRowChanged;
        }

        void grvKPIDefinition_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            int definitionID = Convert.ToInt32(this.grvKPIDefinition.GetFocusedRowCellValue("EmployeeKPIDefinitionID"));
            bindingListPosition = new BindingList<EmployeeKPIPosition>(empKPIPosition.Select(a => a.EmployeeKPIDefinitionID == definitionID).ToList());
            this.grdKPIPositions.DataSource = bindingListPosition;
        }

        void grvKPIDefinition_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            int definitionID = Convert.ToInt32(this.grvKPIDefinition.GetFocusedRowCellValue("EmployeeKPIDefinitionID"));
            bindingListPosition = new BindingList<EmployeeKPIPosition>(empKPIPosition.Select(a => a.EmployeeKPIDefinitionID == definitionID).ToList());
            this.grdKPIPositions.DataSource = bindingListPosition;
        }


        void grvKPIPosition_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            switch (e.Column.FieldName)
            {
                case "EmployeeKPIDefinitionID":
                case "PositionID":
                case "EmployeeKPIPositionRemark":
                    currentPosition = (EmployeeKPIPosition)this.grvKPIPosition.GetFocusedRow();
                    currentPosition.EmployeeKPIPositionID = Convert.ToInt32(this.grvKPIPosition.GetFocusedRowCellValue("PositionID"));
                    currentPosition.EmployeeKPIPositionRemark = Convert.ToString(this.grvKPIPosition.GetFocusedRowCellValue("EmployeeKPIPositionRemark"));
                    int point = 0;
                    if (int.TryParse(Convert.ToString(this.grvKPIPosition.GetFocusedRowCellValue("EmployeeKPIDefinitionID")), out point))
                        currentDefinition.EmployeeKPIPoint = Convert.ToInt32(this.grvKPIPosition.GetFocusedRowCellValue("EmployeeKPIDefinitionID"));

                    if (currentPosition.EmployeeKPIDefinitionID > 0)
                        empKPIPosition.Update(currentPosition);
                    else
                        empKPIPosition.Insert(currentPosition);
                    break;
                default:
                    break;
            }
        }
        private void LoadEmployeeKPIPosition()
        {
            bindingListPosition = new BindingList<EmployeeKPIPosition>(empKPIPosition.Select().ToList());
            this.grdKPIPositions.DataSource = bindingListPosition;
        }
        void grvKPIDefinition_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

            switch (e.Column.FieldName)
            {
                case "EmployeeKPICategoryID":
                case "EmployeeKPIDescriptions":
                case "EmployeeKPIPoint":
                case "EmployeeKPIType":
                    currentDefinition = (EmployeeKPIDefinition)this.grvKPIDefinition.GetFocusedRow();
                    currentDefinition.EmployeeKPICategoryID = Convert.ToInt32(this.grvKPIDefinition.GetFocusedRowCellValue("EmployeeKPICategoryID"));
                    currentDefinition.EmployeeKPIDescriptions = Convert.ToString(this.grvKPIDefinition.GetFocusedRowCellValue("EmployeeKPIDescriptions"));
                    int point = 0;
                    if (int.TryParse(Convert.ToString(this.grvKPIDefinition.GetFocusedRowCellValue("EmployeeKPIPoint")), out point))
                        currentDefinition.EmployeeKPIPoint = Convert.ToInt32(this.grvKPIDefinition.GetFocusedRowCellValue("EmployeeKPIPoint"));
                    currentDefinition.EmployeeKPIType = Convert.ToString(this.grvKPIDefinition.GetFocusedRowCellValue("EmployeeKPIType"));

                    if (currentDefinition.EmployeeKPIDefinitionID > 0)
                        empDefinitionDA.Update(currentDefinition);
                    else
                        empDefinitionDA.Insert(currentDefinition);
                    break;
                default:
                    break;
            }
        }

        void rpi_lkeEmKPICat_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {

        }
        private void InitEmployeeKPICategory()
        {
            rpi_lkeEmKPICat.DataSource = empCategoryDA.Select();
            rpi_lkeEmKPICat.ValueMember = "EmployeeKPICategoryID";
            rpi_lkeEmKPICat.DisplayMember = "EmployeeKPICategoryDescription";
        }
        private void LoadEmployeeKPIDefinition()
        {
            bindingList = new BindingList<EmployeeKPIDefinition>(empDefinitionDA.Select().ToList());
            this.grdKPIDefinitions.DataSource = bindingList;
            //
        }

        private void grdKPIPositions_Click(object sender, EventArgs e)
        {

        }
    }
}
