using System;
using System.Windows.Forms;
using DA;
using System.Linq;
using UI.ReportForm;

namespace UI.CRM
{
    public partial class urc_CRM_12MonthProfitability : UserControl
    {
        
        private int customerID = 0;

        public urc_CRM_12MonthProfitability(int customerID)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.customerID = customerID;
            InitProfitabilityData(customerID);
            
        }

        public urc_CRM_12MonthProfitability(int customerID, int storeID)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.customerID = customerID;
            InitProfitabilityDataExtended(customerID, storeID);

        }
        public void InitProfitabilityData(int customerID)
        {
            this.grcContractValue.DataSource = FileProcess.LoadTable("OperatingCostSummaryByCustomer12M " + customerID);
            this.chartControl1.DataSource = FileProcess.LoadTable("OperatingCostSummaryByCustomer12M " + customerID);
        }

        public void InitProfitabilityDataExtended(int customerID, int storeID)
        {
            this.grcContractValue.DataSource = FileProcess.LoadTable("OperatingCostSummaryByCustomer12M " + customerID + "," + storeID);
            this.chartControl1.DataSource = FileProcess.LoadTable("OperatingCostSummaryByCustomer12M " + customerID + "," + storeID);
        }


    }
}
