using DA;
using DevExpress.XtraEditors;
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

namespace UI.WarehouseManagement
{
    public partial class frm_WM_SafetyStockEntry : Common.Controls.frmBaseForm
    {
        private DataTable _tableSafetyStock;
        private int customerID = 24;

        public frm_WM_SafetyStockEntry(int customerIDparam)
        {
            
            InitializeComponent();
            this._tableSafetyStock = new DataTable();
            this.customerID = customerIDparam;
        }

        private void frm_WM_SafetyStockEntry_Load(object sender, EventArgs e)
        {
            this.InitProduct2();
            this.InitProduct6();
            this.InitProductP();
            this.InitIdOuter();
            this.LoadSafetyStock();

            this.SetEvents();
        }

        private void SetEvents()
        {
            this.rpi_lke_ProductNumber6.EditValueChanged += rpi_lke_ProductNumber6_EditValueChanged;
            this.rpi_lke_ProductNumber2.EditValueChanged += rpi_lke_ProductNumber2_EditValueChanged;
            this.rpi_lke_ProductNumberP.EditValueChanged += rpi_lke_ProductNumberP_EditValueChanged;
            this.rpi_lke_IdOuter.EditValueChanged += rpi_lke_IdOuter_EditValueChanged;
            this.grvSafetyStock.CellValueChanged += grvSafetyStock_CellValueChanged;
        }

        private void rpi_lke_IdOuter_EditValueChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.LookUpEdit editor = (sender as DevExpress.XtraEditors.LookUpEdit);
            var row = editor.Properties.GetDataSourceRowByKeyValue(editor.EditValue) as Products;
            var safetyStockID = Convert.ToInt32(this.grvSafetyStock.GetFocusedRowCellValue("SafetyStockID"));
            var updateIDOuterSqlCmd = string.Format("Update SafetyStocks Set ProductIDOuter = {0} Where SafetyStockID = {1}", row.ProductID, safetyStockID);
            this.AccessDBHelper(updateIDOuterSqlCmd);
        }

        private void rpi_lke_ProductNumberP_EditValueChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.LookUpEdit editor = (sender as DevExpress.XtraEditors.LookUpEdit);
            Products row = editor.Properties.GetDataSourceRowByKeyValue(editor.EditValue) as Products;
            int safetyStockID = Convert.ToInt32(this.grvSafetyStock.GetFocusedRowCellValue("SafetyStockID"));
            this.AccessDBHelper("Update SafetyStocks Set ProductIDPack = {0}, ProductNumberP = {1}, ProductNameP = {2} Where SafetyStockID = {3}", row.ProductID, row.ProductNumberEx, row.ProductName, safetyStockID);
        }

        private void rpi_lke_ProductNumber2_EditValueChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.LookUpEdit editor = (sender as DevExpress.XtraEditors.LookUpEdit);
            Products row = editor.Properties.GetDataSourceRowByKeyValue(editor.EditValue) as Products;

            int safetyStockID = Convert.ToInt32(this.grvSafetyStock.GetFocusedRowCellValue("SafetyStockID"));
            this.AccessDBHelper("Update SafetyStocks Set ProductID2 = {0}, ProductNumber2 = {1}, ProductName2 = {2} Where SafetyStockID = {3}", row.ProductID, row.ProductNumberEx, row.ProductName, safetyStockID);
        }

        private void rpi_lke_ProductNumber6_EditValueChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.LookUpEdit editor = (sender as DevExpress.XtraEditors.LookUpEdit);
            Products row = editor.Properties.GetDataSourceRowByKeyValue(editor.EditValue) as Products;
            this.grvSafetyStock.SetFocusedRowCellValue("ProductName6", row.ProductName);
            var safetyStockID = Convert.ToInt32(this.grvSafetyStock.GetFocusedRowCellValue("SafetyStockID"));
            this.AccessDBHelper("Update SafetyStocks Set ProductID6 = {0}, ProductNumber6 = {1}, ProductName6 = {2} Where SafetyStockID = {3}", row.ProductID, row.ProductNumberEx, row.ProductName, safetyStockID);
        }

        private void grvSafetyStock_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DataProcess<object> stockDA = new DataProcess<object>();
            int safetyStockID = Convert.ToInt32(this.grvSafetyStock.GetRowCellValue(e.RowHandle, "SafetyStockID"));
            int result = -2;

            switch (e.Column.FieldName)
            {
                case "SafetyStock":
                    {
                        result = stockDA.ExecuteNoQuery("Update SafetyStocks Set SafetyStock = {0} Where SafetyStockID = {1}", Convert.ToInt32(e.Value), safetyStockID);
                        break;
                    }
                case "Remark":
                    {
                        result = stockDA.ExecuteNoQuery("Update SafetyStocks Set Remark = {0} Where SafetyStockID = {1}", Convert.ToString(e.Value), safetyStockID);
                        break;
                    }
            }
        }

        #region Load Data
        private void LoadSafetyStock()
        {
            string sql = "SELECT SafetyStocks.SafetyStockID, SafetyStocks.ProductID6, SafetyStocks.ProductNumber6, SafetyStocks.ProductName6, SafetyStocks.SafetyStock, SafetyStocks.ProductID2, SafetyStocks.ProductIDPack, SafetyStocks.Remark, SafetyStocks.ProductNumber2, SafetyStocks.ProductNumberP, SafetyStocks.ProductIDOuter"
                                                            + " FROM(SafetyStocks LEFT JOIN Products ON SafetyStocks.ProductID2 = Products.ProductID) LEFT JOIN Products AS Products_1 ON SafetyStocks.ProductIDPack = Products_1.ProductID"
                                                            + $" where SafetyStocks.CustomerID = {this.customerID}"
                                                            + " ORDER BY SafetyStocks.ProductNumber6";
            this._tableSafetyStock = FileProcess.LoadTable(sql);

            this.grdSafetyStock.DataSource = this._tableSafetyStock;
        }

        private void InitProduct6()
        {
            if (AppSetting.StoreID == 1)
                this.rpi_lke_ProductNumber6.DataSource = AppSetting.ProductList.Where(p => p.CustomerID == this.customerID || p.CustomerID == 808);
            else if (AppSetting.StoreID == 2)
                this.rpi_lke_ProductNumber6.DataSource = AppSetting.ProductList.Where(p => p.CustomerID == this.customerID || p.CustomerID == 1991);
            else
                this.rpi_lke_ProductNumber6.DataSource = AppSetting.ProductList.Where(p => p.CustomerID == this.customerID || p.CustomerID == 808 || p.CustomerID == 1991);
            this.rpi_lke_ProductNumber6.ValueMember = "ProductID";
            this.rpi_lke_ProductNumber6.DisplayMember = "ProductNumberEx";
        }

        private void InitProduct2()
        {
            this.rpi_lke_ProductNumber2.DataSource = AppSetting.ProductList.Where(p => p.CustomerID == this.customerID);
            this.rpi_lke_ProductNumber2.ValueMember = "ProductID";
            this.rpi_lke_ProductNumber2.DisplayMember = "ProductNumberEx";
        }

        private void InitProductP()
        {
            if (AppSetting.StoreID == 1)
                this.rpi_lke_ProductNumberP.DataSource = this.GetProductsByCustomerId(808);
            else if (AppSetting.StoreID == 2)
                this.rpi_lke_ProductNumberP.DataSource = this.GetProductsByCustomerId(1991);
            else
                this.rpi_lke_ProductNumberP.DataSource = this.GetProductsByCustomerId(808);
            this.rpi_lke_ProductNumberP.ValueMember = "ProductID";
            this.rpi_lke_ProductNumberP.DisplayMember = "ProductNumberEx";
        }

        private void InitIdOuter()
        {
            if (AppSetting.StoreID == 1)
                this.rpi_lke_IdOuter.DataSource = this.GetProductsByCustomerId(808);
            else if (AppSetting.StoreID == 2)
                this.rpi_lke_IdOuter.DataSource = this.GetProductsByCustomerId(1991);
            else
                this.rpi_lke_IdOuter.DataSource = this.GetProductsByCustomerId(808);
            this.rpi_lke_IdOuter.ValueMember = "ProductID";
            this.rpi_lke_IdOuter.DisplayMember = "ProductNumberEx";
        }

        /// <summary>
        /// Gets the products by customer identifier.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns></returns>
        private IEnumerable<Products> GetProductsByCustomerId(int customerId)
        {
            if (AppSetting.StoreID == 1)
                return AppSetting.ProductList.Where(p => p.CustomerID == 808);
            else if (AppSetting.StoreID == 2)
                return AppSetting.ProductList.Where(p => p.CustomerID == 1991);
            else
                return AppSetting.ProductList.Where(p => p.CustomerID == 808 || p.CustomerID == 1991);
        }

        /// <summary>
        /// Accesses the database helper.
        /// </summary>
        /// <param name="sqlCmd">The SQL command.</param>
        private void AccessDBHelper(string sqlCmd, params object[] listParam)
        {
            var stockDA = new DataProcess<object>();
            var result = stockDA.ExecuteNoQuery(sqlCmd, listParam);
            if (result == -2)
            {
                XtraMessageBox.Show("Unexpected Error !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadSafetyStock();
            }
        }

        #endregion

        #region Handle event on GridView

        /// <summary>
        /// Handles the InitNewRow event of the grvSafetyStock control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs"/> instance containing the event data.</param>
        private void grvSafetyStock_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            try
            {
                var newItemAdded = this.grvSafetyStock.GetDataRow(e.RowHandle);
                if (newItemAdded == null)
                {
                    return;
                }

                var safetyStockId = newItemAdded[0]; // SafetyStock ID
                var insertSafetyStockSqlCmd = $"INSERT INTO SafetyStocks (Remark,CustomerID) VALUES(N'', {this.customerID}) "; // just add a new record
                this.AccessDBHelper(insertSafetyStockSqlCmd);
            }
            catch (Exception ex)
            {
                // TODO
                throw;
            }
           
        }

        #endregion
    }
}
