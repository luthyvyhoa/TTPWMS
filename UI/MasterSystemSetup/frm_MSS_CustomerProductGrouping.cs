using Common.Controls;
using Common.Process;
using DA;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using UI.Helper;

namespace UI.MasterSystemSetup
{
    public partial class frm_MSS_CustomerProductGrouping : frmBaseForm
    {
        private BindingList<CustomerProductGroups> groupSource = null;
        DataProcess<CustomerProductGroups> dataProcess = new DataProcess<CustomerProductGroups>();
        private int customerID = 0;

        public frm_MSS_CustomerProductGrouping(int customerID)
        {
            this.customerID = customerID;
            InitializeComponent();
        }

        private void frm_MSS_CustomerProductGrouping_Load(object sender, System.EventArgs e)
        {
            this.rpi_lke_CustomerID.DataSource = AppSetting.CustomerListAll;
            this.rpi_lke_CustomerID.DisplayMember = "CustomerNumber";
            this.rpi_lke_CustomerID.ValueMember = "CustomerID";

            this.InitData();
        }

        private void InitData()
        {
            var dataSource = dataProcess.Select(c => c.CustomerID == this.customerID);
            this.groupSource = new BindingList<CustomerProductGroups>(dataSource.ToList());
            this.AddNewGroup();
            this.grd_ProductGrouping.DataSource = this.groupSource;
        }

        private void AddNewGroup()
        {
            if (this.groupSource[this.groupSource.Count - 1].ProductGroupID <= 0) return;
            var newGroup = new CustomerProductGroups();
            newGroup.CustomerID = this.customerID;
            newGroup.ProductGroupID = 0;
            newGroup.ISDefault = false;
            this.groupSource.Add(newGroup);
        }

        private void grvProductGrouping_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (!e.KeyCode.Equals(Keys.Delete)) return;
            if (this.grvProductGrouping.SelectedRowsCount <= 0) return;
            var confirm = MessageBox.Show("Do you want to delete the records?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (confirm.Equals(DialogResult.No)) return;
            foreach (var index in this.grvProductGrouping.GetSelectedRows())
            {
                var currentGroup = this.groupSource[index];
                this.dataProcess.Delete(currentGroup);
            }
            this.InitData();
        }

        private void grvProductGrouping_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle < 0) return;
            var currentGroup = (CustomerProductGroups)this.grvProductGrouping.GetRow(e.RowHandle);
            if (currentGroup.ProductGroupID <= 0 && !string.IsNullOrEmpty(currentGroup.ProductGroupDescription))
            {
                this.dataProcess.Insert(currentGroup);
                this.AddNewGroup();
            }
            else
            {
                this.dataProcess.Update(currentGroup);
            }
        }
    }
}
