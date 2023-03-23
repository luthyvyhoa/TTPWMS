using Common.Controls;
using DA;
using DevExpress.Data;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Helper;
using UI.ReportFile;
using UI.StockTake;

namespace UI.ReportForm
{
    public partial class frm_BR_BillingSummary : frmBaseForm
    {
        private DataProcess<STcomboCustomerMainID_Result> customersDataProcess = new DataProcess<STcomboCustomerMainID_Result>();
        private DataProcess<BillingSummary> billingSummaryDataProcess = new DataProcess<BillingSummary>();
        private DataProcess<BillingSummaryDetails> billingSummaryDetailDataProcess = new DataProcess<BillingSummaryDetails>();
        private IList<BillingSummary> billingSummaryList = null;
        private BillingSummary currentItem = new BillingSummary();
        private SwireDBEntities context = new SwireDBEntities();
        private List<Customers> fullCustomerList = AppSetting.CustomerList.ToList();
        // Variables that store summary values.
        private int customerNumberCount = 0;
        private int billingIDCount = 0;
        private int currentCustomerNumberCount = 0;
        private int currentBillingIDCount = 0;
        bool currentCustomerNumberIsAssigned = false;
        bool currentBillingIDCountIsAssigned = false;
        bool currentDifferenceCountIsAssigned = false;
        private bool isNotFirstTime = false;
        public frm_BR_BillingSummary()
        {
            InitializeComponent();

            // Init data for all controls in form
            InitData();

            // Always disable TextEdit and DateEdit
            DisableControls();

            // Enable or disable control components
            Form_Current();
        }

        private void DisableControls()
        {
            txtID.Enabled = false;
            txtPeriod.Enabled = false;
            dtFrom.Enabled = false;
            dtTo.Enabled = false;
            txtTotalBilled.Enabled = false;
            txtNonBilled.Enabled = false;
            txtCreatedBy.Enabled = false;
            dtCreatedTime.Enabled = false;
            txtConfirmedBy.Enabled = false;
            txtConfirmTime.Enabled = false;
        }

        private void Form_Current()
        {
            try
            {
                if (currentItem.Confirmed)
                {
                    btnDetele.Enabled = false;
                    btnConfirm.Enabled = false;
                    remarkColumn.OptionsColumn.AllowEdit = false;
                }
                else
                {
                    btnDetele.Enabled = true;
                    btnConfirm.Enabled = true;
                    remarkColumn.OptionsColumn.AllowEdit = true;
                }
            }
            catch { }
        }

        private void InitData()
        {
            LoadBillingSummaryList();
            InitDataForGrid();
            InitDataForDateEdit();
            InitDataForTextEdit();
        }

        private void InitDataForTextEdit()
        {
            try
            {
                txtID.Text = currentItem.BillingSummaryID.ToString();
                txtPeriod.Text = currentItem.Period;
                txtTotalBilled.Text = currentItem.TotalCustomerCount.ToString();
                txtNonBilled.Text = currentItem.NonBilledCustomerCount.ToString();
                txtCreatedBy.Text = currentItem.CreatedBy;
                txtConfirmedBy.Text = currentItem.ConfirmedBy;
                txtConfirmTime.Text = Convert.ToDateTime(currentItem.ConfirmTime).ToString("dd/MM/yyy hh:mm");
            }
            catch { }
        }

        private void InitDataForDateEdit()
        {
            try
            {
                dtFrom.EditValue = currentItem.FromDate;
                dtTo.EditValue = currentItem.ToDate;
                dtCreatedTime.EditValue = currentItem.CreatedTime;
            }
            catch { }
        }



        private void LoadBillingSummaryList()
        {
            billingSummaryList = billingSummaryDataProcess.Select().ToList();
            dtBillingSummary.DataSource = billingSummaryList;
            currentItem = billingSummaryList.FirstOrDefault();
            dtBillingSummary.Position = billingSummaryList.Count;
        }

        private void InitDataForGrid()
        {
            //IList<BillingSummaryDetails> detailList = billingSummaryDetailDataProcess.Select(b => b.BillingSummaryID == currentItem.BillingSummaryID).ToList();
            //grdBillingSummary.DataSource = detailList;
            try
            {
                string queryString = "SELECT BillingSummary.BillingSummaryID, BillingSummaryDetailID, BillingSummary.FromDate, BillingSummary.ToDate, BillingSummary.Period, "
                    + " BillingSummary.TotalCustomerCount, BillingSummary.NonBilledCustomerCount, BillingSummaryDetails.CustomerID, BillingSummaryDetails.LastBillingID,BillingSummaryDetails.CreatedTime,"
                    + " BillingSummaryDetails.CustomerNumber, BillingSummaryDetails.CustomerName, BillingSummaryDetails.BillingRemark, BillingSummaryDetails.FromDate,"
                    + " BillingSummaryDetails.ToDate, BillingSummaryDetails.CustomerCategory, BillingSummaryDetails.LastBillingID,Stores.StoreNumber ,CustomerGroup,BillingSummaryDetails.CustomerCategory "
                + "FROM BillingSummary INNER JOIN BillingSummaryDetails ON BillingSummary.BillingSummaryID = BillingSummaryDetails.BillingSummaryID "
                + "INNER JOIN Customers ON BillingSummaryDetails.CustomerID = Customers.CustomerID LEFT JOIN Stores ON Customers.StoreID=Stores.StoreID"
                + " WHERE BillingSummary.BillingSummaryID = " + currentItem.BillingSummaryID + " and Customers.StoreID = " + AppSetting.StoreID + " "
                + "ORDER BY BillingSummaryDetails.LastBillingID, BillingSummaryDetails.CustomerNumber";

                var dataSource = FileProcess.LoadTable(queryString);
                grdBillingSummary.DataSource = dataSource;

                HandleFirstColumn();
            }
            catch { }
        }

        private void HandleFirstColumn()
        {
            for (int i = 0; i < grvBillingSummary.DataRowCount; i++)
            {
                string symbolAfterChecking = getFirstColumnValue(grvBillingSummary, i);
                grvBillingSummary.SetRowCellValue(i, "CustomerCategorySymbol", symbolAfterChecking);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtBillingSummary_PositionChanged(object sender, EventArgs e)
        {
            currentItem = billingSummaryList[dtBillingSummary.Position];
            InitDataForGrid();
            InitDataForDateEdit();
            InitDataForTextEdit();
            // Enable or disable control components
            Form_Current();
            // Reset value = 0 when changing other billing summary;
            currentCustomerNumberCount = 0;
            currentBillingIDCount = 0;
            if (isNotFirstTime)
            {
                currentBillingIDCountIsAssigned = false;
                currentCustomerNumberIsAssigned = false;
                currentDifferenceCountIsAssigned = false;
            }
            else
            {
                isNotFirstTime = true;
            }
        }
        // Formula=Count([CustomerNumber])-Count([LastBillingID])
        private void grvBillingSummary_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            GridView view = sender as GridView;
            // Get the summary ID.  
            int summaryID = Convert.ToInt32((e.Item as GridSummaryItem).Tag);


            // Initialization.  
            if (e.SummaryProcess == CustomSummaryProcess.Start)
            {
                customerNumberCount = 0;
                billingIDCount = 0;
            }
            // Calculation. 
            if (e.SummaryProcess == CustomSummaryProcess.Calculate)
            {
                switch (summaryID)
                {
                    case 0:
                        if (!String.IsNullOrEmpty(Convert.ToString(e.FieldValue)))
                        {
                            customerNumberCount += 1;
                        }
                        break;
                    case 1:
                        if (!String.IsNullOrEmpty(Convert.ToString(e.FieldValue)))
                        {
                            billingIDCount += 1;
                        }
                        break;
                    default:
                        break;
                }
            }
            // Finalization.  
            if (e.SummaryProcess == CustomSummaryProcess.Finalize)
            {
                switch (summaryID)
                {
                    case 0:
                        e.TotalValue = customerNumberCount;
                        if (!currentCustomerNumberIsAssigned)
                        {
                            currentCustomerNumberCount = customerNumberCount;
                            currentCustomerNumberIsAssigned = true;
                        }

                        break;
                    case 1:
                        e.TotalValue = billingIDCount;
                        if (!currentBillingIDCountIsAssigned)
                        {
                            currentBillingIDCount = billingIDCount;
                            currentBillingIDCountIsAssigned = true;
                        }
                        break;
                    case 2:
                        if (!currentDifferenceCountIsAssigned)
                        {
                            e.TotalValue = currentCustomerNumberCount - currentBillingIDCount;
                            currentDifferenceCountIsAssigned = true;
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            txtConfirmedBy.Text = AppSetting.CurrentUser.LoginName;
            txtConfirmTime.Text = DateTime.Now.ToString();
            currentItem.Confirmed = true;
            currentItem.ConfirmedBy = AppSetting.CurrentUser.LoginName;
            currentItem.ConfirmTime = DateTime.Now;
            UpdateBillingSummaryAfterConfirming(currentItem);
            UpdateBillingSummaryDetailAfterConfirming(grvBillingSummary.FocusedRowHandle);
            btnClose.Focus();
            Form_Current();
        }

        private void UpdateBillingSummaryDetailAfterConfirming(int position)
        {
            BillingSummaryDetails updateRow = null;
            if (position >= 0)
            {
                int id = Convert.ToInt32(grvBillingSummary.GetRowCellValue(position, "BillingSummaryDetailID"));
                updateRow = billingSummaryDetailDataProcess.Select(b => b.BillingSummaryDetailID == id).FirstOrDefault();
                if (updateRow == null)
                {
                    MessageBox.Show("This row doesn't exist", "TPWMS",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                updateRow.BillingRemark = grvBillingSummary.GetRowCellValue(position, "BillingRemark").ToString();
                int result = billingSummaryDetailDataProcess.Update(updateRow);
                if (result <= 0)
                {
                    MessageBox.Show("Fail to update this detail billing summary!", "TPWMS",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void UpdateBillingSummaryAfterConfirming(BillingSummary currentItem)
        {
            if (currentItem != null)
            {
                int result = billingSummaryDataProcess.Update(currentItem);
                if (result <= 0)
                {
                    MessageBox.Show("Fail to update this billing summary!", "TPWMS",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.InitDataForGrid();
            this.LoadBillingSummaryList();
        }

        private void btnDetele_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete and refresh data for this report ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                billingSummaryDataProcess.ExecuteNoQuery("STBillingSummaryRefresh " + txtID.Text + ","  + AppSetting.StoreID);
                this.InitDataForGrid();
                this.LoadBillingSummaryList();
            }
        }

        private void chkCustomerMain_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkCustomerMain.Checked)
            //{
            //    List<STcomboCustomerMainID_Result> customerMainList = customersDataProcess.Executing("STcomboCustomerMainID").ToList();
            //    // Set items data for lkeCustomerID
            //    List<Customers> customerList = new List<Customers>();
            //    foreach (STcomboCustomerMainID_Result item in customerMainList)
            //    {
            //        Customers customer = new Customers();
            //        customer.CustomerID = item.CustomerMainID;
            //        customer.CustomerMainID = item.CustomerMainID;
            //        customer.CustomerNumber = item.CustomerNumber;
            //        customer.CustomerName = item.CustomerName;
            //        customerList.Add(customer);
            //    }

            //}
            //else
            //{
            //    // Set items data for lkeCustomerID
                
            //}

        }



        private void btnCreate_Click(object sender, EventArgs e)
        {
            frm_BR_CreateBillingSummary createForm = new frm_BR_CreateBillingSummary();
            createForm.ShowDialog();
            this.InitDataForGrid();
        }


        private void btnReport_Click(object sender, EventArgs e)
        {
            // DoCmd.OpenReport "rptBillingSummary", acViewPreview
            int billingID = Convert.ToInt32(txtID.Text);
            int employeeID = AppSetting.CurrentUser.EmployeeID;
            DataProcess<Employees> dataProcess = new DataProcess<Employees>();
            Employees currentUser = dataProcess.Select(em => em.EmployeeID == employeeID).FirstOrDefault();
            string fullName = "unknown";
            if (currentUser != null)
            {
                fullName = currentUser.VietnamName;
            }

            //string queryString = "SELECT BillingSummary.BillingSummaryID, BillingSummary.FromDate, BillingSummary.ToDate, BillingSummary.Period, "
            //    +" BillingSummary.TotalCustomerCount, BillingSummary.NonBilledCustomerCount, BillingSummaryDetails.CustomerID, BillingSummaryDetails.LastBillingID,"
            //    +" BillingSummaryDetails.CustomerNumber, BillingSummaryDetails.CustomerName, BillingSummaryDetails.BillingRemark, BillingSummaryDetails.FromDate,"
            //    +" BillingSummaryDetails.ToDate, BillingSummaryDetails.CustomerCategory, BillingSummaryDetails.LastBillingID "
            //+ "FROM BillingSummary INNER JOIN BillingSummaryDetails ON BillingSummary.BillingSummaryID = BillingSummaryDetails.BillingSummaryID "
            //+ "WHERE BillingSummary.BillingSummaryID = " + billingID + " "
            //+ "ORDER BY BillingSummaryDetails.LastBillingID, BillingSummaryDetails.CustomerNumber";

            string queryString = "SELECT BillingSummary.BillingSummaryID,BillingSummaryDetailID, BillingSummary.FromDate, BillingSummary.ToDate, BillingSummary.Period, "
                + " BillingSummary.TotalCustomerCount, BillingSummary.NonBilledCustomerCount, BillingSummaryDetails.CustomerID, BillingSummaryDetails.LastBillingID,"
                + " BillingSummaryDetails.CustomerNumber, BillingSummaryDetails.CustomerName, BillingSummaryDetails.BillingRemark, BillingSummaryDetails.FromDate,"
                + " BillingSummaryDetails.ToDate, BillingSummaryDetails.CustomerCategory, BillingSummaryDetails.LastBillingID "
            + "FROM BillingSummary INNER JOIN BillingSummaryDetails ON BillingSummary.BillingSummaryID = BillingSummaryDetails.BillingSummaryID "
            + "INNER JOIN Customers ON BillingSummaryDetails.CustomerID = Customers.CustomerID "
            + "WHERE BillingSummary.BillingSummaryID = " + billingID + " and Customers.StoreID = " + AppSetting.StoreID + " "
            + "ORDER BY BillingSummaryDetails.LastBillingID, BillingSummaryDetails.CustomerNumber";

            var dataSource = FileProcess.LoadTable(queryString);
            //grdBillingSummary.DataSource = dataSource;
            int allConfirm = Convert.ToInt32(this.gridColumn3.SummaryItem.SummaryValue);
            int unbuill = Convert.ToInt32(this.gridColumn4.SummaryItem.SummaryValue);
            DataRowCollection list = dataSource.Rows;

            rptBillingSummary rpt = new rptBillingSummary(list, currentItem, fullName, allConfirm,unbuill);
            rpt.DataSource = dataSource;
            ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
            tool.ShowPreview();
        }

        private void rpi_btn_View_Click(object sender, EventArgs e)
        {
            int handleRow = grvBillingSummary.FocusedRowHandle;
            if (grvBillingSummary.GetRowCellValue(handleRow, "CustomerID") == null)
            {
                return;
            }
            string customerIDString = grvBillingSummary.GetRowCellValue(handleRow, "CustomerID").ToString();
            int customerID = Convert.ToInt32(customerIDString);
            frm_ST_StockOnHandOneCustomer stockForm = new frm_ST_StockOnHandOneCustomer(customerID);
            stockForm.Show();
            stockForm.Focus();
        }

        private string getFirstColumnValue(GridView view, int listSourceRowIndex)
        {
            // Formula =IIf([CustomerCategory]="Document Storage","D","G")
            string customerCategory = view.GetListSourceRowCellValue(listSourceRowIndex, "CustomerCategory").ToString();
            if ("Document Storage".Equals(customerCategory))
            {
                return "D";
            }
            return "G";
        }

        private void btnGeneralStorage_Click(object sender, EventArgs e)
        {
            // DoCmd.OpenReport "rptBillingSummary", acViewPreview
            int billingID = Convert.ToInt32(txtID.Text);
            int employeeID = AppSetting.CurrentUser.EmployeeID;
            DataProcess<Employees> dataProcess = new DataProcess<Employees>();
            Employees currentUser = dataProcess.Select(em => em.EmployeeID == employeeID).FirstOrDefault();
            string fullName = "unknown";
            if (currentUser != null)
            {
                fullName = currentUser.VietnamName;
            }

            //string queryString = "SELECT BillingSummary.BillingSummaryID, BillingSummary.FromDate, BillingSummary.ToDate, BillingSummary.Period, "
            //    +" BillingSummary.TotalCustomerCount, BillingSummary.NonBilledCustomerCount, BillingSummaryDetails.CustomerID, BillingSummaryDetails.LastBillingID,"
            //    +" BillingSummaryDetails.CustomerNumber, BillingSummaryDetails.CustomerName, BillingSummaryDetails.BillingRemark, BillingSummaryDetails.FromDate,"
            //    +" BillingSummaryDetails.ToDate, BillingSummaryDetails.CustomerCategory, BillingSummaryDetails.LastBillingID "
            //+ "FROM BillingSummary INNER JOIN BillingSummaryDetails ON BillingSummary.BillingSummaryID = BillingSummaryDetails.BillingSummaryID "
            //+ "WHERE BillingSummary.BillingSummaryID = " + billingID + " "
            //+ "ORDER BY BillingSummaryDetails.LastBillingID, BillingSummaryDetails.CustomerNumber";

            string queryString = "SELECT BillingSummary.BillingSummaryID,BillingSummaryDetailID, BillingSummary.FromDate, BillingSummary.ToDate, BillingSummary.Period, "
                + " BillingSummary.TotalCustomerCount, BillingSummary.NonBilledCustomerCount, BillingSummaryDetails.CustomerID, BillingSummaryDetails.LastBillingID,"
                + " BillingSummaryDetails.CustomerNumber, BillingSummaryDetails.CustomerName, BillingSummaryDetails.BillingRemark, BillingSummaryDetails.FromDate,"
                + " BillingSummaryDetails.ToDate, BillingSummaryDetails.CustomerCategory, BillingSummaryDetails.LastBillingID "
            + "FROM BillingSummary INNER JOIN BillingSummaryDetails ON BillingSummary.BillingSummaryID = BillingSummaryDetails.BillingSummaryID "
            + "INNER JOIN Customers ON BillingSummaryDetails.CustomerID = Customers.CustomerID "
            + "WHERE BillingSummary.BillingSummaryID = " + billingID + " and Customers.StoreID = " + AppSetting.StoreID + " and BillingSummaryDetails.CustomerCategory='General Storage'"
            + "ORDER BY BillingSummaryDetails.LastBillingID, BillingSummaryDetails.CustomerNumber";

            var dataSource = FileProcess.LoadTable(queryString);
            //grdBillingSummary.DataSource = dataSource;
            int allConfirm = Convert.ToInt32(this.gridColumn3.SummaryItem.SummaryValue);
            int unbuill = Convert.ToInt32(this.gridColumn4.SummaryItem.SummaryValue);
            DataRowCollection list = dataSource.Rows;

            rptBillingSummary rpt = new rptBillingSummary(list, currentItem, fullName, allConfirm, unbuill);
            rpt.DataSource = dataSource;
            ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
            tool.ShowPreview();
        }

        private void grvBillingSummary_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle < 0) return;
            if (!e.Column.FieldName.Equals("BillingRemark")) return;

            int billingSummaryDetailID = Convert.ToInt32(this.grvBillingSummary.GetFocusedRowCellValue("BillingSummaryDetailID"));
            DataProcess<BillingSummaryDetails> BillingSummaryDetailDA = new DataProcess<BillingSummaryDetails>();
            //var currentBiiling = BillingSummaryDetailDA.Select(b => b.BillingSummaryDetailID == billingSummaryDetailID).FirstOrDefault();
            switch (e.Column.FieldName)
            {
                case "BillingRemark":
                    BillingSummaryDetailDA.ExecuteNoQuery("Update BillingSummaryDetails set BillingRemark=N'" + Convert.ToString(e.Value) + "', CreatedTime = GETDATE() where BillingSummaryDetailID='" + billingSummaryDetailID + "'");
                    break;
            }


        }

        private void rpe_ViewStock_Click(object sender, EventArgs e)
        {
            int handleRow = grvBillingSummary.FocusedRowHandle;
            if (grvBillingSummary.GetRowCellValue(handleRow, "CustomerID") == null)
            {
                return;
            }
            string customerIDString = grvBillingSummary.GetRowCellValue(handleRow, "CustomerID").ToString();
            int customerID = Convert.ToInt32(customerIDString);
            frm_ST_StockOnHandOneCustomer stockForm = new frm_ST_StockOnHandOneCustomer(customerID);
            stockForm.Show();
            stockForm.Focus();
        }

        private void rpe_BillingID_Click(object sender, EventArgs e)
        {
            int _billingID = Convert.ToInt32(this.grvBillingSummary.GetFocusedRowCellValue("BillingID"));
            int _customerID = Convert.ToInt32(this.grvBillingSummary.GetFocusedRowCellValue("CustomerID"));
            frm_BR_BillingConfirmations frm = new frm_BR_BillingConfirmations(_billingID, _customerID);
            frm.Show();
            frm.WindowState = FormWindowState.Normal;
            frm.BringToFront();
        }

        private void rpe_AllBilling_Click(object sender, EventArgs e)
        {
            DataProcess<WebBillingSummaryCrosstap_Result> webBillingDP = new DataProcess<WebBillingSummaryCrosstap_Result>();
            List<WebBillingSummaryCrosstap_Result> list = null;
            int customerID = Convert.ToInt32(this.grvBillingSummary.GetFocusedRowCellValue("CustomerID"));
            if (chkCustomerMain.Checked)
            {
                // CurrentDb.QueryDefs("_qry_SelectedResults").sql = "WebBillingSummaryCrosstap " & Me.ComboCustomerID & ",1"
                list = webBillingDP.Executing("WebBillingSummaryCrosstap @CustomerID = {0}, @Flag = {1}", customerID, true).ToList();
            }
            else
            {
                // CurrentDb.QueryDefs("_qry_SelectedResults").sql = "WebBillingSummaryCrosstap " & Me.ComboCustomerID
                list = webBillingDP.Executing("WebBillingSummaryCrosstap @CustomerID = {0}, @Flag = {1}", customerID, false).ToList();
            }
            // DoCmd.OpenQuery "qryBillingSummaryCrosstap", acViewNormal
            frm_BR_BillingSummaryCrosstap crossTapForm = new frm_BR_BillingSummaryCrosstap(list);
            crossTapForm.Show();
            crossTapForm.Focus();
        }
    }
}
