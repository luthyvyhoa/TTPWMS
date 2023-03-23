using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DA;

namespace UI.CRM
{
    public partial class urc_CRM_36MonthsOperation : UserControl
    {
        public urc_CRM_36MonthsOperation(int CustomerID, int storeID)
        {
            InitializeComponent();
            this.grcCustomerEvent.DataSource = FileProcess.LoadTable("WebCustomerEventByCustomer " + CustomerID + "," + storeID);
            this.chartStockOnHandSummary36M.DataSource = FileProcess.LoadTable("WebChartStockMovementWeeklyMainCustomers " + CustomerID + "," + storeID);
            this.grcAccountStocks.DataSource = FileProcess.LoadTable("WebCustomerMainStockByRoom " + CustomerID + "," + storeID);

        }
        public void init36MonthsOperation(int CustomerID, int storeID)
        {
            this.grcCustomerEvent.DataSource = FileProcess.LoadTable("WebCustomerEventByCustomer " + CustomerID + "," + storeID);
            this.chartStockOnHandSummary36M.DataSource = FileProcess.LoadTable("WebChartStockMovementWeeklyMainCustomers " + CustomerID + "," + storeID);
            this.grcAccountStocks.DataSource = FileProcess.LoadTable("WebCustomerMainStockByRoom " + CustomerID + "," + storeID);

        }

        private void grvAccountStocks_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.chartAccountStock.DataSource = FileProcess.LoadTable("STStockOnHand1CustomerAccount12Months " + this.grvAccountStocks.GetFocusedRowCellValue("CustomerID"));
        }
    }
}
