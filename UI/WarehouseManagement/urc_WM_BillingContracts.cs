using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.WarehouseManagement
{
    public partial class urc_WM_BillingContracts : UserControl
    {
        public urc_WM_BillingContracts(int CustomerID)
        {
            InitializeComponent();
            this.grcActiveServices.DataSource = DA.FileProcess.LoadTable("ST_WMS_LoadServicesActive " + CustomerID);
        }

        private void grvActiveServices_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            //Load ScopeOfWork here
            this.meScopeOfWork.Text =Convert.ToString(this.grvActiveServices.GetFocusedRowCellValue("ScopeOFWorkVietnam"));
        }
    }
}
