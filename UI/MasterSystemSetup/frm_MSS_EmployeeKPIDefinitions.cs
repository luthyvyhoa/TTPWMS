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
    public partial class frm_MSS_EmployeeKPIDefinitions : Form
    {
        private BindingList<EmployeeKPIDefinition> bindingList = null;
        //private BindingList<EmployeeKPIPosition> bindingListPosition = null;
        //EmployeeKPIDefinition currentDefinition = new EmployeeKPIDefinition();
        //EmployeeKPIPosition currentPosition = new EmployeeKPIPosition();
        DataProcess<EmployeeKPIDefinition> empDefinitionDA = new DataProcess<EmployeeKPIDefinition>();
        //DataProcess<Positions> positionDA = new DataProcess<Positions>();
        //DataProcess<EmployeeKPIPosition> empKPIPosition = new DataProcess<EmployeeKPIPosition>();
        DataProcess<EmployeeKPICategory> empCategoryDA = new DataProcess<EmployeeKPICategory>();
        public frm_MSS_EmployeeKPIDefinitions()
        {
            InitializeComponent();
            InitEmployeeKPICategory();

            // Init events
            this.InitEvents();

            // Init data
            this.LoadData();
        }


        private void LoadData()
        {
            this.bindingList = new BindingList<EmployeeKPIDefinition>(empDefinitionDA.Select().ToList());
            this.bindingList.AddNew();
            this.grdKPIDefinitions.DataSource = this.bindingList;
        }

        private void InitEvents()
        {
            this.grvKPIDefinition.CellValueChanged += GrvKPIDefinition_CellValueChanged;
        }

        private void GrvKPIDefinition_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle < 0) return;
            int kpiID = Convert.ToInt32(this.grvKPIDefinition.GetFocusedRowCellValue("EmployeeKPIDefinitionID"));
            string query = string.Empty;
            if (kpiID > 0)
            {
                switch (e.Column.FieldName)
                {
                    case "EmployeeKPINumber":
                        query = " set EmployeeKPINumber=N'" + e.Value + "'";
                        break;
                    case "EmployeeKPIDescriptions":
                        query = " set EmployeeKPIDescriptions=N'" + e.Value + "'";
                        break;
                    case "EmployeeKPICategoryID":
                        query = " set EmployeeKPICategoryID=" + e.Value;
                        break;
                    case "EmployeeKPIPoint":
                        query = " set EmployeeKPIPoint=" + e.Value;
                        break;
                    case "EmployeeKPIUnitMeasurement":
                        query = " set EmployeeKPIUnitMeasurement=N'" + e.Value + "'";
                        break;
                    case "EmployeeKPIRemark":
                        query = " set EmployeeKPIRemark=N'" + e.Value + "'";
                        break;
                    default:
                        break;
                }
                if (string.IsNullOrEmpty(query)) return;
                this.empDefinitionDA.ExecuteNoQuery("Update EmployeeKPIDefinitions " + query + " Where EmployeeKPIDefinitionID=" + kpiID);
            }
        }

        private void InitEmployeeKPICategory()
        {
            rpi_lkeEmKPICat.DataSource = empCategoryDA.Select();
            rpi_lkeEmKPICat.ValueMember = "EmployeeKPICategoryID";
            rpi_lkeEmKPICat.DisplayMember = "EmployeeKPICategoryDescription";
        }
    }
}
