using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Common.Controls;
using DA;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_AssignmentsView : frmBaseForm
    {
        public frm_WM_AssignmentsView()
        {
            InitializeComponent();
            LoadAssignmentView();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void LoadAssignmentView()
        {
              DataTable dataSource= FileProcess.LoadTable("ST_WMS_LoadAssignmentTabview");
              dgvAsignmentView.DataSource = dataSource;
              dtNavigatorAssginment.DataSource = dataSource;

        }

    }
}