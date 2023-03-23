using System.Windows.Forms;
using Common.Controls;
using DA;
using System.Linq;

namespace UI.MasterSystemSetup
{
    public partial class frm_MSS_EmployeeAllocations : frmBaseForm
    {
        public frm_MSS_EmployeeAllocations()
        {
            InitializeComponent();
        }

        private void frm_MSS_EmployeeAllocations_Load(object sender, System.EventArgs e)
        {
            DataProcess<EmployeeAreas> employeeAreas = new DataProcess<EmployeeAreas>();
            var result = employeeAreas.Select().Select(n=>new { n.RoomID, n.RoomDescription }).ToList();

            if (result.Count > 20)
            {
                repositoryItemLookUpEdit2.DropDownItemHeight = 20;
            }
            else
            {
                repositoryItemLookUpEdit2.DropDownItemHeight = result.Count;
            }

            repositoryItemLookUpEdit2.DataSource = result;
            repositoryItemLookUpEdit2.ValueMember = "RoomDescription";
            repositoryItemLookUpEdit2.DisplayMember = "RoomDescription";

            DataProcess <ST_WMS_EmployeeAllocations_Result> employeeHistory = new DataProcess<ST_WMS_EmployeeAllocations_Result>();
            this.grEmployeeAllocations.DataSource = employeeHistory.
                Executing("ST_WMS_EmployeeAllocations");
        }


        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Dispose();
        }

        private void gridControl1_Click(object sender, System.EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, System.EventArgs e)
        {

        }

        private void btn_close_Employees_Allocations_Click(object sender, System.EventArgs e)
        {
            this.Dispose();
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}
