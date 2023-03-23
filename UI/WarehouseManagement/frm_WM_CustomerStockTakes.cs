using DA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_CustomerStockTakes : Form
    {
        public frm_WM_CustomerStockTakes()
        {
            InitializeComponent();
            RefreshGrids();
        }

        public frm_WM_CustomerStockTakes(int CustomerStockTakeID)
        {
            InitializeComponent();
            RefreshGrids();
            var dataSource = FileProcess.LoadTable("STCustomerStockTake_LoadOrders");

            var emRow = dataSource.Select("CustomerStockTakeID=" + CustomerStockTakeID).FirstOrDefault();

            if (emRow != null)
            {
                int index = dataSource.Rows.IndexOf(emRow);
                this.grvCustomerStockTakes.FocusedRowHandle = index;
            }
        }
        private void RefreshGrids()
        {
            this.grcStockTakes.DataSource = FileProcess.LoadTable("STCustomerStockTake_LoadOrders");
            

        }
        private void rpe_PalletID_Click(object sender, EventArgs e)
        {

        }

        private void rpe_LocationID_Click(object sender, EventArgs e)
        {

        }

        private void grvStockTakeDetails_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.grcStockTakeCartons.DataSource = FileProcess.LoadTable("STCustomerStockTake_LoadCartons " + this.grvStockTakeDetails.GetFocusedRowCellValue("CustomerStockTakeDetailID"));
        }

        private void grvCustomerStockTakes_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            string idTHIS = this.grvCustomerStockTakes.GetFocusedRowCellValue("CustomerStockTakeID").ToString();
            this.grcStockTakeDetails.DataSource = FileProcess.LoadTable("STCustomerStockTake_LoadOrderDetails " + this.grvCustomerStockTakes.GetFocusedRowCellValue("CustomerStockTakeID").ToString());
        }
    }
}
