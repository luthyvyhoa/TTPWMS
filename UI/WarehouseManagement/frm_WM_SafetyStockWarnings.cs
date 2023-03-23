using Common.Controls;
using DA;
using System;
using System.Data;
using System.Drawing;
using UI.Helper;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_SafetyStockWarnings : frmBaseForm
    {
        private DataProcess<STSafetyStockWarning_Result> _stockDA;
        private DataTable _exportData;
        private int customerIDparam = 24;

        public frm_WM_SafetyStockWarnings()
        {
            InitializeComponent();
            this._stockDA = new DataProcess<STSafetyStockWarning_Result>();
            this._exportData = new DataTable();
        }

        private void InitCustomer()
        {
            this.lkeCustomerFind.Properties.DataSource = AppSetting.CustomerList;
            this.lkeCustomerFind.Properties.ValueMember = "CustomerID";
            this.lkeCustomerFind.Properties.DisplayMember = "CustomerNumber";
        }

        private void frm_WM_SafetyStockWarnings_Load(object sender, EventArgs e)
        {
            InitReason();
            LoadStocks();
            InitCustomer();

            this.dtFromDate.EditValue = DateTime.Now;
            this.dtToDate.EditValue = DateTime.Now;

            SetEvents();
        }

        private void SetEvents()
        {
            this.chkRODO.CheckedChanged += chkRODO_CheckedChanged;
            this.rpi_txt_ProductNumber2.DoubleClick += rpi_txt_ProductNumber2_DoubleClick;
            this.rpi_txt_ProductNumber6.DoubleClick += rpi_txt_ProductNumber6_DoubleClick;
            this.rpi_txt_ProductNumberP.DoubleClick += rpi_txt_ProductNumberP_DoubleClick;
            this.rpi_btn_OpenReason.Click += rpi_btn_OpenReason_Click;
            this.rpi_lke_Reason.EditValueChanged += rpi_lke_Reason_EditValueChanged;
            this.btnSafetyStock.Click += btnSafetyStock_Click;
            this.btnDetailClient.Click += btnDetailClient_Click;
            this.btnRefresh.Click += btnRefresh_Click;
            this.btnClose.Click += btnClose_Click;
        }

        #region Events
        private void chkRODO_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRODO.Checked)
            {
                chkRODO.Text = "DO";
            }
            else
            {
                chkRODO.Text = "RO";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //LoadStocks();
            if (this.lkeCustomerFind.EditValue == null)
            {
                this.txtCustomerNameFind.Text = string.Empty;
                this.LoadStocks();
            }
            else
            {
                this.txtCustomerNameFind.Text = Convert.ToString(this.lkeCustomerFind.GetColumnValue("CustomerName"));
                int customerID = Convert.ToInt32(this.lkeCustomerFind.EditValue);
                this.LoadStocks(customerID);
            }
        }

        private void btnDetailClient_Click(object sender, EventArgs e)
        {
            LoadStocksForExport();

            string pathSaveFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string fileName = pathSaveFile + "\\" + "DetailClient_" + DateTime.Now.ToString("dd_MM_yy") + ".xlsx";

            this.grvStockForExport.ExportToXlsx(fileName);

            System.Diagnostics.Process.Start(fileName);
        }

        private void btnSafetyStock_Click(object sender, EventArgs e)
        {
            // Open frm SafetyStockEntry
            frm_WM_SafetyStockEntry frm = new frm_WM_SafetyStockEntry(customerIDparam);
            frm.Show();
        }

        private void rpi_btn_OpenReason_Click(object sender, EventArgs e)
        {
            // Open frm SafetyStockReasonHistories
            int productID6 = Convert.ToInt32(this.grvStockWarning.GetFocusedRowCellValue("ProductID6"));

            frm_WM_SafetyStockReasonHistories frm = new frm_WM_SafetyStockReasonHistories(productID6);
            frm.ShowDialog();
        }

        private void rpi_txt_ProductNumberP_DoubleClick(object sender, EventArgs e)
        {
            int productID = Convert.ToInt32(this.grvStockWarning.GetFocusedRowCellValue("ProductIDPack"));

            frm_WM_PalletInfo frm = new frm_WM_PalletInfo(808, productID);
            frm.ShowDialog();
        }

        private void rpi_txt_ProductNumber6_DoubleClick(object sender, EventArgs e)
        {
            int productID = Convert.ToInt32(this.grvStockWarning.GetFocusedRowCellValue("ProductID6"));

            frm_WM_PalletInfo frm = new frm_WM_PalletInfo(24, productID);
            frm.ShowDialog();
        }

        private void rpi_txt_ProductNumber2_DoubleClick(object sender, EventArgs e)
        {
            int productID = Convert.ToInt32(this.grvStockWarning.GetFocusedRowCellValue("ProductID2"));

            frm_WM_PalletInfo frm = new frm_WM_PalletInfo(24, productID);
            frm.ShowDialog();
        }

        private void rpi_lke_Reason_EditValueChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.LookUpEdit editor = (sender as DevExpress.XtraEditors.LookUpEdit);
            SafetyStockReasonDefinitions row = editor.Properties.GetDataSourceRowByKeyValue(editor.EditValue) as SafetyStockReasonDefinitions;

            DataProcess<object> reasonDA = new DataProcess<object>();
            int stockOnHand = Convert.ToInt32(this.grvStockWarning.GetFocusedRowCellValue("StockOnHand"));
            int stockPackQty = Convert.ToInt32(this.grvStockWarning.GetFocusedRowCellValue("StockPackQty"));
            int stockP2Qty = Convert.ToInt32(this.grvStockWarning.GetFocusedRowCellValue("StockP2Qty"));
            int productID6 = Convert.ToInt32(this.grvStockWarning.GetFocusedRowCellValue("ProductID6"));

            int result = reasonDA.ExecuteNoQuery("STSafetyStockReasonInsert @ProductID6 = {0}, @Owner = {1}, @ProductID6_Stock = {2}, @ProductIDPack_Stock = {3}, @ProductID2_Stock ={4}, @ReasonID = {5}", productID6, AppSetting.CurrentUser.LoginName, stockOnHand, stockPackQty, stockP2Qty, row.ReasonID);

            if (result != -2)
            {
                //Open frm SafetyStockReasonHistories
                frm_WM_SafetyStockReasonHistories frm = new frm_WM_SafetyStockReasonHistories(productID6);
                frm.ShowDialog();

                this.grvStockWarning.SetFocusedRowCellValue("Reason", row.Reason);
            }

        }
        #endregion

        #region Load Data
        private void LoadStocks(int customerID = 24)
        {
            this.grdStockWarning.DataSource = FileProcess.LoadTable($"STSafetyStockWarning @CustomerID={customerID}");
        }

        private void LoadStocksForExport()
        {
            this._exportData = FileProcess.LoadTable("WebSummaryNoteByClient @CustomerID = 24, @varFromDate = '" + this.dtFromDate.DateTime.ToString("dd/MM/yyyy") + "', @varToDate = '" + this.dtToDate.DateTime.ToString("dd/MM/yyyy") + "', @Flag = " + this.chkRODO.Checked);

            this.grdStockForExport.DataSource = this._exportData;
        }

        private void InitReason()
        {
            DataProcess<SafetyStockReasonDefinitions> reasonDA = new DataProcess<SafetyStockReasonDefinitions>();

            this.rpi_lke_Reason.DataSource = reasonDA.Select();
            this.rpi_lke_Reason.DisplayMember = "Reason";
            this.rpi_lke_Reason.ValueMember = "Reason";
        }
        #endregion

        private void grvStockWarning_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            var stockOnHandCellValue = this.grvStockWarning.GetRowCellValue(e.RowHandle, "StockOnHand");
            var safetyStockCellValue = this.grvStockWarning.GetRowCellValue(e.RowHandle, "SafetyStock");

            if (stockOnHandCellValue == null 
                || safetyStockCellValue == null 
                || DBNull.Value.Equals(stockOnHandCellValue)
                || DBNull.Value.Equals(safetyStockCellValue))
            {
                return;
            }

            int stockOnHandValue = Convert.ToInt32(stockOnHandCellValue);
            int safetyStockValue = Convert.ToInt32(safetyStockCellValue);

            if (e.Column.FieldName.Equals("WaitingQuantity") || e.Column.FieldName.Equals("StockOnHand"))
            {
                if (safetyStockValue > stockOnHandValue)
                {
                    e.Appearance.BackColor = Color.Red;
                    e.Appearance.ForeColor = Color.White;
                }
                else
                {
                    e.Appearance.BackColor = Color.White;
                    e.Appearance.ForeColor = Color.Black;
                }
            }
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {

        }

        private void btnSafetyStock_Click_1(object sender, EventArgs e)
        {

        }

        private void lkeCustomerFind_EditValueChanged(object sender, EventArgs e)
        {
            if (this.lkeCustomerFind.EditValue == null)
            {
                this.txtCustomerNameFind.Text = string.Empty;
                this.LoadStocks();
            }
            else
            {
                this.txtCustomerNameFind.Text = Convert.ToString(this.lkeCustomerFind.GetColumnValue("CustomerName"));
                customerIDparam = Convert.ToInt32(this.lkeCustomerFind.EditValue);
                this.LoadStocks(customerIDparam);
            }
            
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            DataProcess<object> stockDA = new DataProcess<object>();
            int safetyStockID = Convert.ToInt32(this.grvStockWarning.GetRowCellValue(this.grvStockWarning.GetFocusedDataSourceRowIndex(), "SafetyStockID"));
            int result = -2;

            string sql = "delete from SafetyStocks where SafetyStockID = " + safetyStockID;
            result = stockDA.ExecuteNoQuery(sql);
            this.LoadStocks(customerIDparam);

        }
    }
}
