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
using UI.CRM;
using UI.StockTake;
using UI.Helper;

namespace UI.Supperviors
{
    public partial class frm_S_CustomerStock36months2 : Form
    {
        private int varCustomerID;
        public frm_S_CustomerStock36months2(int CustomerID, string CustomerName)
        {
            InitializeComponent();
            this.grcCustomerEvent.DataSource = FileProcess.LoadTable("WebCustomerEventByCustomer " + CustomerID);
            this.chartStockOnHandSummary36M.DataSource = FileProcess.LoadTable("WebChartStockMovementWeeklyMainCustomers " + CustomerID);
            this.grcAccountStocks.DataSource = FileProcess.LoadTable("WebCustomerMainStockByRoom " + CustomerID);
            this.Text = CustomerName + " - Summary 36 months";
            varCustomerID = CustomerID;

        }

        public frm_S_CustomerStock36months2(int CustomerID, string CustomerName, int storeID)
        {
            InitializeComponent();
            this.grcCustomerEvent.DataSource = FileProcess.LoadTable("WebCustomerEventByCustomer " + CustomerID + "," + storeID);
            this.chartStockOnHandSummary36M.DataSource = FileProcess.LoadTable("WebChartStockMovementWeeklyMainCustomers " + CustomerID + "," + storeID);
            this.grcAccountStocks.DataSource = FileProcess.LoadTable("WebCustomerMainStockByRoom " + CustomerID + "," + storeID);
            this.Text = CustomerName + " - Summary 36 months";
            varCustomerID = CustomerID;

        }
        //public void init36MonthsOperation(int CustomerID)
        //{
        //    this.grcCustomerEvent.DataSource = FileProcess.LoadTable("WebCustomerEventByCustomer " + CustomerID);
        //    this.chartStockOnHandSummary36M.DataSource = FileProcess.LoadTable("WebChartStockMovementWeeklyMainCustomers " + CustomerID);
        //    this.grcAccountStocks.DataSource = FileProcess.LoadTable("WebCustomerMainStockByRoom " + CustomerID);

        //}

        private void grvAccountStocks_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.chartAccountStock.DataSource = FileProcess.LoadTable("STStockOnHand1CustomerAccount12Months " + this.grvAccountStocks.GetFocusedRowCellValue("CustomerID"));
        }

        private void Room_Link_Click(object sender, EventArgs e)
        {
            string CustomerNameFull = this.grvAccountStocks.GetFocusedRowCellValue("CustomerNumber") + " | " + this.grvAccountStocks.GetFocusedRowCellValue("CustomerName");
            Customers customer = AppSetting.CustomerList.FirstOrDefault(c => c.CustomerID == Convert.ToInt32(this.grvAccountStocks.GetFocusedRowCellValue("CustomerID")));
            frm_ST_StockOnHandByRoomOneCustomer frm = new frm_ST_StockOnHandByRoomOneCustomer(varCustomerID, CustomerNameFull);
            //frm_ST_StockOnHandByRoomOneCustomer frm = new frm_ST_StockOnHandByRoomOneCustomer(customer);
            frm.ShowDialog();
            

        }

        private void chartStockOnHandSummary36M_Click(object sender, EventArgs e)
        {
            Form form = new Form();
            form.Text = "Records";
            // Place a DataGrid control on the form.
            DataGridView grid = new DataGridView();
            grid.Parent = form;
            grid.Dock = DockStyle.Fill;
            // Get the recrd set associated with the current cell and bind it to the grid.
            grid.DataSource = FileProcess.LoadTable("WebChartStockMovementWeeklyMainCustomers " + varCustomerID); ;
            form.Bounds = new Rectangle(100, 100, 1000, 400);
            // Display the form.
            form.ShowDialog();
            form.Dispose();
        }
    }
}
