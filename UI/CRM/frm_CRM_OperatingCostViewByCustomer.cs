using Common.Controls;
using DA;
using System;
using System.Linq;
using System.Windows.Forms;
using UI.Helper;
using UI.MasterSystemSetup;
using UI.Supperviors;
using UI.CRM;

namespace UI.CRM
{
    public partial class frm_CRM_OperatingCostViewByCustomer : frmBaseForm
    {
        private urc_CRM_12MonthProfitability Profitability = null;
        private urc_CRM_CostStructure CostStructure = null;
        private urc_CRM_RatesHistory RatesHistory = null;
        private urc_CRM_LabourCostAndRevenuesAnalysis Labour = null;
        private urc_CRM_36MonthsOperation monthsOperation = null;
        //private urc_CRM_RevenueAnalysis Rev = null;
        private frm_MSS_Contracts frmContract = null;
        int frmStoreID = 0;
        public frm_CRM_OperatingCostViewByCustomer()
        {
            InitializeComponent();
            InitControls(AppSetting.StoreID);
            this.lke_OperatingCostMonthlyID.EditValue = AppSetting.LastOperationMonthID;
        }
        

        public frm_CRM_OperatingCostViewByCustomer(int OperatingCostMonthlyID, int StoreID, int CustomerID)
        {
            InitializeComponent();
            InitControls(StoreID);
            this.lke_OperatingCostMonthlyID.EditValue = OperatingCostMonthlyID;
            this.lkeCustomers.EditValue = CustomerID;
            frmStoreID = StoreID;
            //var currentCuts = AppSetting.CustomerListAll.Where(c => c.CustomerID == CustomerID).FirstOrDefault();
            //if (currentCuts == null)
            //    this.txtCustomerName.Text = "";
            //else
            //    this.txtCustomerName.Text = currentCuts.CustomerName;

            //if (StoreID == 3)
            //{
                var CustomerTable = FileProcess.LoadTable("STCustomerNameByCustomerIDStoreID " + CustomerID + ","  +  StoreID);
                if (CustomerTable != null && CustomerTable.Rows.Count > 0)
                    try
                    {
                        this.txtCustomerName.EditValue = CustomerTable.Rows[0]["CustomerName"];
                    }
                    catch
                    { }

            //}
           // this.txtCustomerName.Text = Convert.ToString(this.lkeCustomers.GetColumnValue("CustomerName"));
            this.dockPanel36MonthsOperation.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;

            Show36MonthData();

            refreshdata();

        }
       
        private void InitControls(int StoreID)
        {
            this.lke_OperatingCostMonthlyID.Properties.DataSource = FileProcess.LoadTable("ST_WMS_LoadOperatingCostMonth");
            this.lke_OperatingCostMonthlyID.Properties.ValueMember = "OperatingCostMonthlyID";
            this.lke_OperatingCostMonthlyID.Properties.DisplayMember = "MonthDescription";


            DataProcess<Stores> storeDA = new DataProcess<Stores>();
            this.lke_MSS_StoreList.Properties.DataSource = storeDA.Select();
            this.lke_MSS_StoreList.Properties.ValueMember = "StoreID";
            this.lke_MSS_StoreList.Properties.DisplayMember = "StoreDescription";
            this.lke_MSS_StoreList.EditValue = StoreID;

            this.lkeCustomers.Properties.ValueMember = "CustomerMainID";
            this.lkeCustomers.Properties.DisplayMember = "CustomerNumber";
            this.lkeCustomers.Properties.DataSource = FileProcess.LoadTable("STcomboCustomerMainID @varStoreID=" + StoreID);


        }

        private void rpe_hlk_ViewByCustomer_Click(object sender, EventArgs e)
        {
            int MonthID = Convert.ToInt32(this.lke_OperatingCostMonthlyID.EditValue.ToString());
            int StoreID = Convert.ToInt32(this.lke_MSS_StoreList.EditValue.ToString());
            int CustomerID = Convert.ToInt32(this.grvOperatingCostLabourByCustomer.GetFocusedRowCellValue("EmployeeID").ToString());
            frm_CRM_OperatingCostLabourAllocation frm = new frm_CRM_OperatingCostLabourAllocation(MonthID, StoreID, CustomerID);
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront();
        }

        private void btnRefreshGrid_Click(object sender, EventArgs e)
        {

            refreshdata();

        }
        private void refreshdata()
        {

            if (this.lkeCustomers.EditValue == null) return;
            this.grcOperatingCostDetails.DataSource = FileProcess.LoadTable("OperatingCostMonthly_ViewByCustomer " + this.lke_OperatingCostMonthlyID.EditValue + "," + this.lkeCustomers.EditValue + "," + this.lke_MSS_StoreList.EditValue);
            this.grcOperatingCostLabourDetails.DataSource = FileProcess.LoadTable("OperatingCostMonthly_ViewByCustomerEmployees " + this.lke_OperatingCostMonthlyID.EditValue + "," + this.lkeCustomers.EditValue + "," + this.lke_MSS_StoreList.EditValue);
            this.grcRevenueDetails.DataSource = FileProcess.LoadTable("OperatingCostMonthly_ViewByRevenues " + this.lke_OperatingCostMonthlyID.EditValue + "," + this.lkeCustomers.EditValue + "," + this.lke_MSS_StoreList.EditValue);
            this.textCOGS.EditValue = gridColumnCOGS.SummaryItem.SummaryValue;
            this.textEBITDA.EditValue = Convert.ToDecimal(gridColumnTotalRev.SummaryItem.SummaryValue) - Convert.ToDecimal(gridColumnCOGS.SummaryItem.SummaryValue);
            this.textOperatingProfit.EditValue = Convert.ToDecimal(gridColumnTotalRev.SummaryItem.SummaryValue) - Convert.ToDecimal(gridColumnTotalCost.SummaryItem.SummaryValue);

            if (gridColumnDirectLabour.SummaryItem != null && gridColumnHandlingRev.SummaryItem != null)
            {
                var direcValue = Convert.ToDecimal(gridColumnDirectLabour.SummaryItem.SummaryValue);
                var handling = Convert.ToDecimal(gridColumnHandlingRev.SummaryItem.SummaryValue);
                if (direcValue > 0)
                    this.textActivityRatio.EditValue = handling / direcValue;
            }
            else
            {
                this.textActivityRatio.EditValue = 0;
            }

            var CustomerParameter = FileProcess.LoadTable("OperatingCostMonthly_ViewByCustomerParameter " + this.lke_OperatingCostMonthlyID.EditValue + ", " +this.lkeCustomers.EditValue
                + "," + this.lke_MSS_StoreList.EditValue);
            if (CustomerParameter != null && CustomerParameter.Rows.Count > 0)
            {
                try
                {

                    this.textStockPlts.EditValue = CustomerParameter.Rows[0]["LocationOccupied"];
                    this.textHandlingWeight.EditValue = CustomerParameter.Rows[0]["WeightInOutAdjusted"];
                    this.textNumberOfTransactions.EditValue = CustomerParameter.Rows[0]["TransactionActual"];
                    this.textEPAOP.EditValue = (Convert.ToDecimal(gridColumnTotalRev.SummaryItem.SummaryValue) - Convert.ToDecimal(gridColumnCOGS.SummaryItem.SummaryValue)) / Convert.ToDecimal(CustomerParameter.Rows[0]["LocationOccupied"]);
                    this.textFixedCost.EditValue = Convert.ToDecimal(gridColumnFixedCost.SummaryItem.SummaryValue);
                    this.textVariableCost.EditValue = Convert.ToDecimal(gridColumnVariableCost.SummaryItem.SummaryValue);
                    this.textTargetStorageRate.EditValue = (Convert.ToDecimal(gridColumnFixedCost.SummaryItem.SummaryValue)) * 2 / 30 / Convert.ToDecimal(CustomerParameter.Rows[0]["LocationOccupied"]);
                    this.textLocationInOut.EditValue = CustomerParameter.Rows[0]["LocationInout"];

                }
                catch
                {

                }


            }

        }

        private void lkeCustomers_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            //this.txtCustomerName.Text = Convert.ToString(this.lkeCustomers.GetColumnValue("CustomerName"));
            //refreshdata();
        }


        private void btnCustomerSummary36Months_Click(object sender, EventArgs e)
        {
            frm_S_CustomerStock36months frm = new frm_S_CustomerStock36months(Convert.ToInt32(this.lkeCustomers.EditValue.ToString()));
            frm.Show();
            frm.WindowState = FormWindowState.Normal;
            frm.BringToFront();

        }

        private void dockPanelProfitability_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            if (this.lkeCustomers.EditValue == null) return;
            int customerID = Convert.ToInt32(this.lkeCustomers.EditValue);

            if (this.Profitability == null)
            {
                this.Profitability = new urc_CRM_12MonthProfitability(customerID, frmStoreID);
                this.Profitability.Parent = this.dockPanelProfitability;
                
            }
            else
            {
                this.Profitability.InitProfitabilityDataExtended(customerID, frmStoreID);
            }
            this.Profitability.Show();
            this.Profitability.Dock = DockStyle.Fill;
        }

        private void lkeCustomers_EditValueChanged(object sender, EventArgs e)
        {
            
            //refreshdata();
        }

        private void lke_MSS_StoreList_EditValueChanged(object sender, EventArgs e)
        {
            this.lkeCustomers.Properties.DataSource = FileProcess.LoadTable("STcomboCustomerMainID @varStoreID=" + this.lke_MSS_StoreList.EditValue);
            this.lkeCustomers.Properties.ValueMember = "CustomerMainID";
            this.lkeCustomers.Properties.DisplayMember = "CustomerNumber";
            this.lkeCustomers.ShowPopup();
        }

        private void lke_OperatingCostMonthlyID_EditValueChanged(object sender, EventArgs e)
        {
            refreshdata();
        }

        private void dockPanelCostStructure_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {

            if (this.lkeCustomers.EditValue == null) return;
            int customerID = Convert.ToInt32(this.lkeCustomers.EditValue);

            if (this.CostStructure == null)
            {
                this.CostStructure = new urc_CRM_CostStructure(customerID);
                this.CostStructure.Parent = this.dockPanelCostStructure;
                
            }
            else
            {
                this.CostStructure.InitCostStructure(customerID);
            }
            this.CostStructure.Show();
            this.CostStructure.Dock = DockStyle.Fill;
        }

        private void dockPanelRateHistory_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            if (this.lkeCustomers.EditValue == null) return;
            int customerID = Convert.ToInt32(this.lkeCustomers.EditValue);

            if (this.RatesHistory == null)
            {
                this.RatesHistory = new urc_CRM_RatesHistory(customerID);
                this.RatesHistory.Parent = this.dockPanelRateHistory;
                
            }
            else
            {
                this.RatesHistory.InitRateHistory(customerID);
            }
            this.RatesHistory.Show();
            this.RatesHistory.Dock = DockStyle.Fill;
        }

        private void dockPanelLabourCostRevenue_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            if (this.lkeCustomers.EditValue == null) return;
            int customerID = Convert.ToInt32(this.lkeCustomers.EditValue);

            if (this.Labour == null)
            {
                this.Labour = new urc_CRM_LabourCostAndRevenuesAnalysis(customerID);
                this.Labour.Parent = this.dockPanelLabourCostRevenue;
                
            }
            else
            {
                this.Labour.InitLabour(customerID);
            }
            this.Labour.Show();
            this.Labour.Dock = DockStyle.Fill;
        }

        private void rpe_hlk_ViewByEmployee_Click(object sender, EventArgs e)
        {
            int MonthID = Convert.ToInt32(this.lke_OperatingCostMonthlyID.EditValue.ToString());
            int StoreID = Convert.ToInt32(this.lke_MSS_StoreList.EditValue.ToString());
            int EmployeeID = Convert.ToInt32(this.grvOperatingCostLabourByCustomer.GetFocusedRowCellValue("EmployeeID").ToString());
            frm_CRM_OperatingCostLabourAllocation frm = new frm_CRM_OperatingCostLabourAllocation(MonthID, StoreID, EmployeeID);
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront();
        }

        private void dockPanel36MonthsOperation_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            Show36MonthData();
        }

        private void Show36MonthData()
        {
            if (this.lkeCustomers.EditValue == null) return;
            int customerID = Convert.ToInt32(this.lkeCustomers.EditValue);
            int storeID = Convert.ToInt32(this.lke_MSS_StoreList.EditValue);

            if (this.monthsOperation == null)
            {
                this.monthsOperation = new urc_CRM_36MonthsOperation(customerID, storeID);
                this.monthsOperation.Parent = this.dockPanel36MonthsOperation;
            }
            else
            {
                this.monthsOperation.init36MonthsOperation(customerID, storeID);
            }
            this.monthsOperation.Show();
            this.monthsOperation.Dock = DockStyle.Fill;
        }
        private void grcOperatingCostDetails_Click(object sender, EventArgs e)
        {

        }

        private void btnContracts_Click(object sender, EventArgs e)
        {
            ///go to contract form
            ///            int customerID = Convert.ToInt32(grvContractList.GetFocusedRowCellValue("CustomerID"));
            ///            
            int customerID = Convert.ToInt32(this.lkeCustomers.EditValue);
            if (this.frmContract == null || this.frmContract.IsDisposed)
            {
                this.frmContract = frm_MSS_Contracts.GetInstance(customerID);
                this.frmContract.InitData(customerID);
            }
            else
            {
                this.frmContract.InitData(customerID);
            }

            this.frmContract.BringToFront();
            this.frmContract.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.frmContract.Show();
        }

        private void dockPanelRevenueAnalysis_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            //if (this.lkeCustomers.EditValue == null) return;
            //int customerID = Convert.ToInt32(this.lkeCustomers.EditValue);

            //if (this.Rev == null)
            //{
            //    this.Rev = new urc_CRM_RevenueAnalysis(customerID);
            //    this.Rev.Parent = this.dockPanelRevenueAnalysis;

            //}
            //else
            //{
            //    this.Rev.initRev(customerID);
            //}
            //this.Rev.Show();
            //this.Rev.Dock = DockStyle.Fill;
        }

        private void lkeCustomers_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            this.txtCustomerName.Text = Convert.ToString(this.lkeCustomers.GetColumnValue("CustomerName"));
            refreshdata();
            ///MessageBox.Show("Clsed !");
        }
    }
}
