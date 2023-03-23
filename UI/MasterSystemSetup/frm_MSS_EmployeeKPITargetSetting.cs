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
using UI.Helper;
using Common.Controls;


namespace UI.MasterSystemSetup
{
    public partial class frm_MSS_EmployeeKPITargetSetting : Form
    {
     //   private BindingList<EmployeeKPIDefinition> bindingList = null;
        private BindingList<EmployeeKPITarget> bindingListKPITarget = null;
     //   private BindingList<EmployeeKPIPosition> bindingListPosition = null;
        EmployeeKPITarget currentTarget = new EmployeeKPITarget();
        EmployeeKPIDefinition currentDefinition = new EmployeeKPIDefinition();
        EmployeeKPIPosition currentPosition = new EmployeeKPIPosition();
        DataProcess<EmployeeKPIDefinition> empDefinitionDA = new DataProcess<EmployeeKPIDefinition>();
        DataProcess<EmployeeKPITarget> empKPITargetDA = new DataProcess<EmployeeKPITarget>();
        DataProcess<Positions> positionDA = new DataProcess<Positions>();
        DataProcess<EmployeeKPIPosition> empKPIPosition = new DataProcess<EmployeeKPIPosition>();
        DataProcess<EmployeeKPICategory> empCategoryDA = new DataProcess<EmployeeKPICategory>();
        private int valueSelected = 0;
        private const string POSI = "POSI";
        private const string EMPL = "EMPL";
        private const string DEPT = "DEPT";
        private string EmployeeKPITargetCategory = String.Empty;
        public frm_MSS_EmployeeKPITargetSetting()
        {
            InitializeComponent();

            InitEmployeeKPICategory();
            //InitPosition();
            LoadEmployeeKPIDefinition();
            LoadEmployeeKPIPosition();
            LoadEmployees();
            Init_Department();
            //Init_Position();
            //Init_Shift();
            //Init_Stores();
            //Init_Grade();
            InitEvent();
        }

        private void InitEvent()
        {
            //this.rpi_lkeEmKPICat.CloseUp += rpi_lkeEmKPICat_CloseUp;
            //this.grvKPITarget.CellValueChanged += grvKPIDefinition_CellValueChanged;
            this.rpi_lkeKPIDefinition.CloseUp += Rpi_lkeKPIDefinition_CloseUp;
            this.grvPositions.CellValueChanged += grvPositions_CellValueChanged;
            this.grvKPITarget.RowClick += grvKPIDefinition_RowClick;
            this.grvKPITarget.FocusedRowChanged += grvKPIDefinition_FocusedRowChanged;
            this.grv_EmployeesList.RowCellClick += grvPositions_RowCellClick;
            this.grvDepartment.RowCellClick += grvPositions_RowCellClick;
            this.grvPositions.RowCellClick += grvPositions_RowCellClick;
            this.grvKPITarget.CellValueChanged += grvKPITarget_CellValueChanged;
        }

        private void Rpi_lkeKPIDefinition_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.Value == null) return;
            int kpiTargetID = Convert.ToInt32(this.grvKPITarget.GetRowCellValue(this.grvKPITarget.FocusedRowHandle, "EmployeeKPITargetID"));
            EmployeeKPITarget currentEmKPI = null;
            if (kpiTargetID <= 0)
            {
                if (valueSelected <= 0 || string.IsNullOrEmpty(EmployeeKPITargetCategory))
                {
                    MessageBox.Show("Please select type to create KPI for this employee!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Insert new employee KPI
                currentEmKPI = new EmployeeKPITarget();
                currentEmKPI.CreatedBy = AppSetting.CurrentUser.LoginName;
                currentEmKPI.CreateTime = DateTime.Now;
                currentEmKPI.EmployeeKPIDefintionID = Convert.ToInt32(e.Value);
                currentEmKPI.ReferenceID = valueSelected;
                currentEmKPI.EmployeeKPITargetCategory = EmployeeKPITargetCategory;
                currentEmKPI.TargetFrequency = string.Empty;
                empKPITargetDA.Insert(currentEmKPI);
                if (currentEmKPI.EmployeeKPITargetID > 0)
                {
                    this.grvKPITarget.SetFocusedRowCellValue("EmployeeKPITargetID", currentEmKPI.EmployeeKPITargetID);
                    this.bindingListKPITarget[this.grvKPITarget.FocusedRowHandle] = currentEmKPI;
                    bindingListKPITarget.AddNew();
                }
            }
            else
            {
                empKPITargetDA.ExecuteNoQuery("Update EmployeeKPITargets set EmployeeKPIDefintionID=" + e.Value + " where EmployeeKPITargetID=" + kpiTargetID);
            }
        }

        void grvKPITarget_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int kpiTargetID = Convert.ToInt32(this.grvKPITarget.GetRowCellValue(this.grvKPITarget.FocusedRowHandle, "EmployeeKPITargetID"));
            if (kpiTargetID <= 0) return;
            var currentEmpKPI = empKPITargetDA.Select(kpi => kpi.EmployeeKPITargetID == kpiTargetID).FirstOrDefault();
            switch (e.Column.FieldName)
            {
                case "EmployeeKPITargetRemark":
                    empKPITargetDA.ExecuteNoQuery("Update EmployeeKPITargets set EmployeeKPITargetRemark=N'" + e.Value
                        + "' where EmployeeKPITargetID=" + kpiTargetID + " And ReferenceID=" + valueSelected);
                    break;
                case "TargetWeight":
                    currentEmpKPI.TargetWeight = Convert.ToDouble(e.Value);
                    currentEmpKPI.ReferenceID = valueSelected;
                    empKPITargetDA.Update(currentEmpKPI);
                    break;
                case "TargetFrequency":
                    empKPITargetDA.ExecuteNoQuery("Update EmployeeKPITargets set TargetFrequency=N'" + e.Value
                        + "' where EmployeeKPITargetID=" + kpiTargetID + " And ReferenceID=" + valueSelected);
                    break;
                case "EmployeeKPITargetAmount":
                    currentEmpKPI.EmployeeKPITargetAmount = Convert.ToDecimal(e.Value);
                    currentEmpKPI.ReferenceID = valueSelected;
                    empKPITargetDA.Update(currentEmpKPI);
                    break;
                default:
                    break;
            }
        }

        void grvPositions_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {

            WMSGridView grv = (WMSGridView)sender;
            switch (grv.Name)
            {
                case "grvPositions":
                    this.grv_EmployeesList.Appearance.Row.BackColor = Color.Transparent;
                    this.grvPositions.Appearance.Row.BackColor = Color.LightBlue;
                    this.grvDepartment.Appearance.Row.BackColor = Color.Transparent;
                    valueSelected = Convert.ToInt32(grv.GetFocusedRowCellValue("PositionID"));
                    EmployeeKPITargetCategory = POSI;
                    break;
                case "grv_EmployeesList":
                    this.grv_EmployeesList.Appearance.Row.BackColor = Color.LightBlue;
                    this.grvPositions.Appearance.Row.BackColor = Color.Transparent;
                    this.grvDepartment.Appearance.Row.BackColor = Color.Transparent;
                    valueSelected = Convert.ToInt32(grv.GetFocusedRowCellValue("EmployeeID"));
                    EmployeeKPITargetCategory = EMPL;
                    break;

                case "grvDepartment":
                    this.grv_EmployeesList.Appearance.Row.BackColor = Color.Transparent;
                    this.grvPositions.Appearance.Row.BackColor = Color.Transparent;
                    this.grvDepartment.Appearance.Row.BackColor = Color.LightBlue;
                    valueSelected = Convert.ToInt32(grv.GetFocusedRowCellValue("DepartmentID"));
                    EmployeeKPITargetCategory = DEPT;
                    break;
                default:
                    break;
            }

            this.LoadEmployeesKPITarget(valueSelected, EmployeeKPITargetCategory);
        }

        void grvKPIDefinition_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //int definitionID = Convert.ToInt32(this.grvKPITarget.GetFocusedRowCellValue("EmployeeKPIDefinitionID"));
            //bindingListPosition = new BindingList<EmployeeKPIPosition>(empKPIPosition.Select(a => a.EmployeeKPIDefinitionID == definitionID).ToList());
            //this.grcPositions.DataSource = bindingListPosition;
        }

        void grvKPIDefinition_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            //int definitionID = Convert.ToInt32(this.grvKPITarget.GetFocusedRowCellValue("EmployeeKPIDefinitionID"));
            //bindingListPosition = new BindingList<EmployeeKPIPosition>(empKPIPosition.Select(a => a.EmployeeKPIDefinitionID == definitionID).ToList());
            //this.grcPositions.DataSource = bindingListPosition;
        }


        void grvPositions_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //switch (e.Column.FieldName)
            //{
            //    case "EmployeeKPIDefinitionID":
            //    case "PositionID":
            //    case "EmployeeKPIPositionRemark":
            //        currentPosition = (EmployeeKPIPosition)this.grvPositions.GetFocusedRow();
            //        currentPosition.EmployeeKPIPositionID = Convert.ToInt32(this.grvPositions.GetFocusedRowCellValue("PositionID"));
            //        currentPosition.EmployeeKPIPositionRemark = Convert.ToString(this.grvPositions.GetFocusedRowCellValue("EmployeeKPIPositionRemark"));
            //        int point = 0;
            //        if (int.TryParse(Convert.ToString(this.grvPositions.GetFocusedRowCellValue("EmployeeKPIDefinitionID")), out point))
            //            currentDefinition.EmployeeKPIPoint = Convert.ToInt32(this.grvPositions.GetFocusedRowCellValue("EmployeeKPIDefinitionID"));

            //        if (currentPosition.EmployeeKPIDefinitionID > 0)
            //            empKPIPosition.Update(currentPosition);
            //        else
            //            empKPIPosition.Insert(currentPosition);
            //        break;
            //    default:
            //        break;
            //}
        }
        private void LoadEmployeeKPIPosition()
        {
            //bindingListPosition = new BindingList<EmployeeKPIPosition>(empKPIPosition.Select().ToList());
            this.grcPositions.DataSource = FileProcess.LoadTable("SELECT PositionID, PositionDescription, PositionVietnam, ManagementLevel FROM Positions WHERE (ManagementLevel < 18) ORDER BY ManagementLevel");
        }
        private void LoadEmployees()
        {
            this.grd_EmployeesList.DataSource = FileProcess.LoadTable("STEmployeeKPISettingEmployeeList");
        }

        //private void Init_Shift()
        //{
        //    DataProcess<Shifts> loadShiftInfo = new DataProcess<Shifts>();
        //    var shiftInfo = loadShiftInfo.Select();
        //    this.lke_Shift.DataSource = shiftInfo;
        //    this.lke_Shift.ValueMember = "ShiftID";
        //    this.lke_Shift.DisplayMember = "ShiftValue";
        //}
        private void Init_Department()
        {
            DataProcess<Departments> loadDepartment = new DataProcess<Departments>();
            var departmentSource = loadDepartment.Select();
            //this.lke_Department.DataSource = departmentSource;
            //this.lke_Department.ValueMember = "DepartmentID";
            //this.lke_Department.DisplayMember = "DepartmentName";
            this.grcDepartments.DataSource = loadDepartment.Select();

        }
        //private void Init_Stores()
        //{
        //    DataProcess<Stores> loadStoreInfo = new DataProcess<Stores>();
        //    this.lke_Store.DataSource = loadStoreInfo.Select();
        //    this.lke_Store.ValueMember = "StoreID";
        //    this.lke_Store.DisplayMember = "StoreDescription";
        //}
        //private void Init_Position()
        //{
        //    DataProcess<Positions> loadPosition = new DataProcess<Positions>();
        //    var departmentPostion = loadPosition.Select();
        //    this.lke_Position.DataSource = departmentPostion;
        //    this.lke_Position.ValueMember = "PositionID";
        //    this.lke_Position.DisplayMember = "PositionDescription";
        //    this.grcPositions.DataSource = departmentPostion;
        //}

        //private void Init_Grade()
        //{
        //    this.lke_Grade.DataSource = FileProcess.LoadTable("select * from PositionGrades");
        //    this.lke_Grade.ValueMember = "PositionGradeID";
        //    this.lke_Grade.DisplayMember = "PositionGradeName";
        //}

        //    void grvKPIDefinition_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        //{

        //switch (e.Column.FieldName)
        //{
        //    case "EmployeeKPICategoryID":
        //    case "EmployeeKPIDescriptions":
        //    case "EmployeeKPIPoint":
        //    case "EmployeeKPIType":
        //        currentDefinition = (EmployeeKPIDefinition)this.grvKPITarget.GetFocusedRow();
        //        currentDefinition.EmployeeKPICategoryID = Convert.ToInt32(this.grvKPITarget.GetFocusedRowCellValue("EmployeeKPICategoryID"));
        //        currentDefinition.EmployeeKPIDescriptions = Convert.ToString(this.grvKPITarget.GetFocusedRowCellValue("EmployeeKPIDescriptions"));
        //        int point = 0;
        //        if (int.TryParse(Convert.ToString(this.grvKPITarget.GetFocusedRowCellValue("EmployeeKPIPoint")), out point))
        //            currentDefinition.EmployeeKPIPoint = Convert.ToInt32(this.grvKPITarget.GetFocusedRowCellValue("EmployeeKPIPoint"));
        //        currentDefinition.EmployeeKPIType = Convert.ToString(this.grvKPITarget.GetFocusedRowCellValue("EmployeeKPIType"));

        //        if (currentDefinition.EmployeeKPIDefinitionID > 0)
        //            empDefinitionDA.Update(currentDefinition);
        //        else
        //            empDefinitionDA.Insert(currentDefinition);
        //        break;
        //    default:
        //        break;
        //}
        //}

        //void rpi_lkeEmKPICat_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        //{

        //}
        private void InitEmployeeKPICategory()
        {
            using (var categoryKPI = new DataTable("tblKPICategory"))
            {
                categoryKPI.Columns.Add("CategoryName");
                var emplRow = categoryKPI.NewRow();
                emplRow["CategoryName"] = EMPL;
                var posRow = categoryKPI.NewRow();
                posRow["CategoryName"] = POSI;
                var depRow = categoryKPI.NewRow();
                depRow["CategoryName"] = DEPT;
                categoryKPI.Rows.Add(emplRow);
                categoryKPI.Rows.Add(posRow);
                categoryKPI.Rows.Add(depRow);
                rpi_lkeEmKPICat.DataSource = categoryKPI;
                rpi_lkeEmKPICat.ValueMember = "CategoryName";
                rpi_lkeEmKPICat.DisplayMember = "CategoryName";
            }
        }

        private void LoadEmployeeKPIDefinition()
        {
            var KPIDefinitions = empDefinitionDA.Select();
            this.rpi_lkeKPIDefinition.DataSource = KPIDefinitions;
            this.rpi_lkeKPIDefinition.ValueMember = "EmployeeKPIDefinitionID";
            this.rpi_lkeKPIDefinition.DisplayMember = "EmployeeKPIDescriptions";
        }
        private void LoadEmployeesKPITarget(int referID, string categoryID)
        {
            var dataSource = empKPITargetDA.Executing("STEmployeeKPITargetAll @ReferenceID ={0},@EmployeeKPITargetCategory={1}", referID, categoryID).ToList();
            if (dataSource == null)
            {
                bindingListKPITarget = new BindingList<EmployeeKPITarget>();
            }
            else
            {
                bindingListKPITarget = new BindingList<EmployeeKPITarget>(dataSource);
            }

            bindingListKPITarget.Add(new EmployeeKPITarget());
            this.grdKPITarget.DataSource = bindingListKPITarget;
        }
        private void grcPositions_Click(object sender, EventArgs e)
        {

        }

        private void grvKPITarget_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.KeyCode.Equals(Keys.Delete)) return;
            if (this.grvKPITarget.SelectedRowsCount <= 0) return;
            var dl = MessageBox.Show("Do you want to delete this tagets?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dl.Equals(DialogResult.No)) return;
            foreach (var index in this.grvKPITarget.GetSelectedRows())
            {
                int kpiTargetID = Convert.ToInt32(this.grvKPITarget.GetRowCellValue(index, "EmployeeKPITargetID"));
                if (kpiTargetID <= 0) continue;
                var currentEmpKPI = empKPITargetDA.Select(kpi => kpi.EmployeeKPITargetID == kpiTargetID).FirstOrDefault();
                empKPITargetDA.ExecuteNoQuery("Delete EmployeeKPITargets where EmployeeKPITargetID=" + kpiTargetID);
            }
        }

    }
}
