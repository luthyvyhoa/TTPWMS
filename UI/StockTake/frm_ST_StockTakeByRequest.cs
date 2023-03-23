using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Controls;
using UI.Helper;
using DA;
using UI.ReportFile;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using DevExpress.XtraGrid;
using System.Data.SqlClient;
using UI.WarehouseManagement;

namespace UI.StockTake
{
    public partial class frm_ST_StockTakeByRequest : frmBaseForm
    {
        private const string Id = "ID";
        private const string RoomID = "RoomID";
        private const string Aisle = "Aisle";
        private const string BaysToPrint = "BaysToPrint";
        private const string HighsToPrint = "HighsToPrint";
        private const string DeepsToPrint = "DeepsToPrint";
        private const string CustomerID = "CustomerID";

        /// <summary>
        /// The table bays data source
        /// </summary>
        private DataTable tbBaysDataSource = null;

        public frm_ST_StockTakeByRequest()
        {
            InitializeComponent();

            // Init events
            this.InitEvents();

            // Load customer list
            this.LoadCustomer();

            // Load location 
            this.LoadLocation();

            // Init data
            this.InitData();
        }

        private void InitData()
        {
            this.dFrom.DateTime = DateTime.Now.AddDays(-365);
            this.dTo.DateTime = DateTime.Now;
            this.chkHideQuantity.Checked = false;
            this.CreatedDataSourceInput();
            this.AddNewRow();
        }

        private void CreatedDataSourceInput()
        {
            using (var tbSource = new DataTable())
            {
                tbSource.Columns.Add(Id, typeof(int));
                tbSource.Columns.Add(RoomID, typeof(string));
                tbSource.Columns.Add(Aisle, typeof(int));
                tbSource.Columns.Add(BaysToPrint, typeof(string));
                tbSource.Columns.Add(HighsToPrint, typeof(int));
                tbSource.Columns.Add(DeepsToPrint, typeof(int));
                this.tbBaysDataSource = tbSource;
            }
        }

        private void AddNewRow()
        {

            if (this.tbBaysDataSource.Rows.Count <= 0)
            {
                var newRow = this.tbBaysDataSource.NewRow();
                newRow[Id] = this.tbBaysDataSource.Rows.Count + 1;
                newRow[RoomID] = string.Empty;
                newRow[Aisle] = 0;
                newRow[BaysToPrint] = string.Empty;
                newRow[HighsToPrint] = 0;
                newRow[DeepsToPrint] = 0;
                this.tbBaysDataSource.Rows.Add(newRow);
            }
            else
            {
                // Get last row has roomID?
                var lastRow = this.tbBaysDataSource.Rows[this.tbBaysDataSource.Rows.Count - 1];
                string roomID = Convert.ToString(lastRow[RoomID]);
                if (!string.IsNullOrEmpty(roomID))
                {
                    var newRow = this.tbBaysDataSource.NewRow();
                    newRow[Id] = this.tbBaysDataSource.Rows.Count + 1;
                    newRow[RoomID] = string.Empty;
                    newRow[Aisle] = 0;
                    newRow[BaysToPrint] = string.Empty;
                    newRow[HighsToPrint] = 0;
                    newRow[DeepsToPrint] = 0;
                    this.tbBaysDataSource.Rows.Add(newRow);
                }
            }

            this.grdInputBaysToPrint.DataSource = tbBaysDataSource;
            this.grvInputBaysToPrint.RefreshData();
        }

        private void InitEvents()
        {
            this.btnLostProduct.Click += BtnLostProduct_Click;
            this.btnOnFloorByCustomer.Click += BtnOnFloorByCustomer_Click;
            this.btnOnFloorByRoom.Click += BtnOnFloorByRoom_Click;
            this.btnRoomE.Click += BtnRoomE_Click;
            this.btnProduct.Click += BtnProduct_Click;
            this.btnManyProduct.Click += BtnManyProduct_Click;
            this.btnDetails.Click += BtnDetails_Click;
            this.btnPreview.Click += BtnPreview_Click;
            this.btnROReport.Click += BtnROReport_Click;
            this.btnClose.Click += BtnClose_Click;
            this.grvInputBaysToPrint.CellValueChanged += GrvInputBaysToPrint_CellValueChanged;
        }

        private void GrvInputBaysToPrint_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            switch (e.Column.FieldName)
            {
                default:
                    break;
            }
        }

        /// <summary>
        /// Handles the Click event of the BtnROReport control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void BtnROReport_Click(object sender, EventArgs e)
        {
            if (DateTime.Compare(this.dTo.DateTime, this.dFrom.DateTime) < 0) // Start time must be great than End time
            {
                XtraMessageBox.Show(this, "The to date must be greater than from date !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.CalculateLocation();
            var strOriginCondition = string.Empty;
            var strConditionBuilder = new StringBuilder();

            if (!this.grvCustomer.GetSelectedRows().Any()) // No selected any Customer
            {
                strOriginCondition = "(SELECT ProductID FROM Products)";
            }
            else
            {
                strConditionBuilder.Append("1");
                foreach (var rowIndex in this.grvCustomer.GetSelectedRows())
                {
                    var customerId = this.grvCustomer.GetRowCellValue(rowIndex, CustomerID);
                    strConditionBuilder.Append($", {customerId}");
                }

                // Update Condition string
                strOriginCondition = $"({strConditionBuilder.ToString()}))";

                // Clear string builder
                strConditionBuilder.Clear();

                if (!this.grvProductList.GetSelectedRows().Any()) // Don't select Product
                {
                    strConditionBuilder.Append($"(SELECT ProductID From Products WHERE CustomerID IN {strOriginCondition}");
                    strOriginCondition = strConditionBuilder.ToString();
                }
                else
                {
                    strConditionBuilder.Append("1");
                    foreach (var rowIndex in this.grvProductList.GetSelectedRows())
                    {
                        var productId = this.grvProductList.GetRowCellValue(rowIndex, "ProductID");
                        strConditionBuilder.Append($", {productId}");
                    }

                    strOriginCondition = $"({strConditionBuilder.ToString()})";
                }
            }

            var sqlQueryData = $"STStockTakeByRequestRODate '{strOriginCondition}', '{this.dFrom.DateTime.ToString("yyyy-MM-dd")}', '{this.dTo.DateTime.ToString("yyyy-MM-dd")}'";
            var dataSource = FileProcess.LoadTable(sqlQueryData);
            if (dataSource == null || dataSource.Rows.Count == 0)
            {
                XtraMessageBox.Show(this, "No data to print !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var stockTakeDetailsReport = new rptStockTakeByRequestDetails()
            {
                DataSource = dataSource,
            };
            stockTakeDetailsReport.lblTotal.Visible = !this.chkHideQuantity.Checked;
            stockTakeDetailsReport.lblQty.Visible = !this.chkHideQuantity.Checked;
            this.ShowPrintToolPreview(stockTakeDetailsReport);

        }

        /// <summary>
        /// Handles the Click event of the BtnPreview control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void BtnPreview_Click(object sender, EventArgs e)
        {
            this.CalculateLocation();
            var sqlUpdated = this.UpdateSqlQuery();

            var dataSource = FileProcess.LoadTable(sqlUpdated);
            if (dataSource == null || dataSource.Rows.Count == 0)
            {
                XtraMessageBox.Show(this, "No data to print !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var stockTakeByRequestReport = new rptStockTakeByRequest()
            {
                DataSource = dataSource,
            };

            stockTakeByRequestReport.ConfigDisplayForMember(!this.chkHideQuantity.Checked);

            this.ShowPrintToolPreview(stockTakeByRequestReport);
        }

        /// <summary>
        /// Handles the Click event of the BtnDetails control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void BtnDetails_Click(object sender, EventArgs e)
        {
            this.CalculateLocation();
            var slqQueryAfterUpdate = this.UpdateSqlQuery();
            var dataSource = FileProcess.LoadTable(slqQueryAfterUpdate);
            if (dataSource == null || dataSource.Rows.Count == 0)
            {
                XtraMessageBox.Show(this, "No data to print !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var stockTakeDetailsReport = new rptStockTakeByRequestDetails()
            {
                DataSource = dataSource,
            };
            stockTakeDetailsReport.lblTotal.Visible = !this.chkHideQuantity.Checked;
            stockTakeDetailsReport.lblQty.Visible = !this.chkHideQuantity.Checked;
            this.ShowPrintToolPreview(stockTakeDetailsReport);
        }

        private void BtnManyProduct_Click(object sender, EventArgs e)
        {
            var sqlQuery = $"STStockTakeByRequestManyDeep2 {AppSetting.StoreID}";
            var dataSource = FileProcess.LoadTable(sqlQuery);
            if (dataSource == null || dataSource.Rows.Count == 0)
            {
                XtraMessageBox.Show(this, "No data to print !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var manyProductDetailsReport = new rptStockTakeByRequestDetails()
            {
                DataSource = dataSource,
            };
            manyProductDetailsReport.lblQty.Visible = !this.chkHideQuantity.Checked;
            manyProductDetailsReport.lblTotal.Visible = !this.chkHideQuantity.Checked;
            this.ShowPrintToolPreview(manyProductDetailsReport);
        }

        private void BtnProduct_Click(object sender, EventArgs e)
        {
            if (!this.grvCustomer.GetSelectedRows().Any())
            {
                XtraMessageBox.Show(this, "Please select Customer !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.CalculateProducts();
                return;
            }           

            var strOriginCondition = string.Empty;
            var strConditionBuilder = new StringBuilder();
            strConditionBuilder.Append("0");
            foreach (var rowIndex in this.grvCustomer.GetSelectedRows())
            {
                var customerID = this.grvCustomer.GetRowCellValue(rowIndex, "CustomerID");
                strConditionBuilder.Append($", {customerID}");
            }
            strOriginCondition = $"({strConditionBuilder.ToString()})";
            //int id = Convert.ToInt32(this.grvCustomer.GetRowCellValue(0, CustomerID));

            this.CalculateProducts();
            var sqlQuery = "SELECT tmpProductRemains.tmpProductRemainID AS ProductID, tmpProductRemains.tmpProductRemainNumber AS ProductNumber, " +
                "tmpProductRemains.tmpProductRemainName AS Name, tmpProductRemains.tmpRemainQuantity AS Qty " +
                "FROM tmpCustomers INNER JOIN tmpProductRemains ON tmpCustomers.CustomerID = tmpProductRemains.tmpCustomerID " +
                "WHERE tmpCustomers.CustomerID in " + strOriginCondition +
                " ORDER BY tmpProductRemainNumber;";
            var dataSource = FileProcess.LoadTable(sqlQuery);
            this.grdProductList.DataSource = dataSource;
            this.grvProductList.RefreshData();
        }

        private void BtnRoomE_Click(object sender, EventArgs e)
        {
            // CalculateLocation
            this.CalculateLocation();

            // Call update slq query
            var reportSqlQuery = this.UpdateSqlQuery();

            var dataSource = FileProcess.LoadTable(reportSqlQuery);
            if (dataSource == null || dataSource.Rows.Count == 0)
            {
                XtraMessageBox.Show(this, "No data to print !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var rptStockTakeByRequestNewForWall = new rptStockTakeByRequest_NewForWall()
            {
                DataSource = dataSource
            };

            this.ShowPrintToolPreview(rptStockTakeByRequestNewForWall);
        }

        private void BtnOnFloorByRoom_Click(object sender, EventArgs e)
        {
            var sqlQuery = string.Empty;
            if (!this.grvInputBaysToPrint.GetSelectedRows().Any()) // No selected any Room bays
            {
                sqlQuery = $"STStockTakeZeroByRoom @Flag = NULL, @varStoreID = {AppSetting.StoreID}";
            }
            else
            {
                // INSERT INTO [tmpRooms] (RoomID) values ('d'), ('e'), ('f'), ('g'), ('h')
                var selectedRooms = this.GetSelectedRoomsFromBaysGrid(this.grvInputBaysToPrint);
                var listSelectedRoomStr = string.Join(",", selectedRooms);
                var accessDbInstance = new DataProcess<object>();
                accessDbInstance.ExecuteNoQuery("STtmpRoomsDelete");

                var insertToTepmRoomsQuery = $"INSERT INTO tmpRooms (RoomID) VALUES {listSelectedRoomStr}";
                accessDbInstance.ExecuteNoQuery(insertToTepmRoomsQuery);
                sqlQuery = $"STStockTakeZeroByRoom @Flag = 1, @varStoreID = {AppSetting.StoreID}";
            }

            var dataSource = FileProcess.LoadTable(sqlQuery);
            if (dataSource == null || dataSource.Rows.Count == 0)
            {
                XtraMessageBox.Show(this, "No data to print !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var rpt = new rptStockTakeXZeroRoom()
            {
                DataSource = dataSource
            };

            this.ShowPrintToolPreview(rpt);
        }

        /// <summary>
        /// Handles the Click event of the BtnOnFoorByCustomer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void BtnOnFloorByCustomer_Click(object sender, EventArgs e)
        {
            string customerId = null;
            if (this.grvCustomer.GetSelectedRows().Any())
            {
                var selectedCustomerIndex = this.grvCustomer.GetSelectedRows().FirstOrDefault();
                if (selectedCustomerIndex >= 0)
                {
                    var customerItem = this.grvCustomer.GetRowCellValue(selectedCustomerIndex, "CustomerID");
                    customerId = customerItem?.ToString();
                }
            }

            customerId = customerId ?? "NULL";
            var sqlQuery = $"STStockTakeZero @CustomerID ={customerId}, @varStoreID={AppSetting.StoreID}";
            var dataSource = FileProcess.LoadTable(sqlQuery);
            if (dataSource == null || dataSource.Rows.Count == 0)
            {
                XtraMessageBox.Show(this, "No data to print !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var rpt = new rptStockTakeX()
            {
                DataSource = dataSource
            };
            this.ShowPrintToolPreview(rpt);
        }

        private void BtnLostProduct_Click(object sender, EventArgs e)
        {
            var dataSource = FileProcess.LoadTable("STStockTakeX @varStoreID=" + AppSetting.StoreID);
            if (dataSource == null || dataSource.Rows.Count == 0)
            {
                XtraMessageBox.Show(this, "No data to print !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var rpt = new rptStockTakeX()
            {
                DataSource = dataSource
            };

            this.ShowPrintToolPreview(rpt);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadCustomer()
        {
            var cusomterDA = new DA.SwireDBEntities();
            var listCustomer = cusomterDA.STcomboCustomerID(AppSetting.StoreID);
            this.grdCustomer.DataSource = listCustomer.ToList();
            this.grvCustomer.ClearSelection();
        }

        private void LoadLocation()
        {
            var sqlQuery = $"SELECT DISTINCT Locations.RoomID FROM Locations WHERE Locations.StoreID = {AppSetting.CurrentUser.StoreID} ORDER BY Locations.RoomID";
            this.rpi_lke_Location.DataSource = FileProcess.LoadTable(sqlQuery);
            this.rpi_lke_Location.DisplayMember = "RoomID";
            this.rpi_lke_Location.ValueMember = "RoomID";
        }

        private void LoadAisle(string roomID)
        {
            var loadAisleQuery = $"SELECT AisleRoomID, Aisle FROM Aisles WHERE RoomID='{roomID}' AND StoreID = {AppSetting.CurrentUser.StoreID} Order By Aisle";
            this.rpi_lke_Aisles.DataSource = FileProcess.LoadTable(loadAisleQuery);
            this.rpi_lke_Aisles.DisplayMember = "Aisle";
            this.rpi_lke_Aisles.ValueMember = "Aisle";
        }

        private void rpi_lke_Location_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.Value == null) return;
            this.LoadAisle(Convert.ToString(e.Value));
            this.tbBaysDataSource.Rows[this.grvInputBaysToPrint.FocusedRowHandle]["RoomID"] = e.Value;
            this.grdInputBaysToPrint.DataSource = this.tbBaysDataSource;
            this.grvInputBaysToPrint.RefreshData();
        }

        private void grvInputBaysToPrint_InitNewRow(object sender, InitNewRowEventArgs e)
        {
        }

        #region Print tool support

        /// <summary>
        /// Shows the print tool preview.
        /// </summary>
        /// <param name="report">The report.</param>
        private void ShowPrintToolPreview(XtraReport report)
        {
            ReportPrintToolWMS printTool = new ReportPrintToolWMS(report)
            {
                AutoShowParametersPanel = false
            };
            printTool.ShowPreviewDialog();
        }

        #endregion

        private void rpi_lke_Aisles_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.Value == null) return;
            this.tbBaysDataSource.Rows[this.grvInputBaysToPrint.FocusedRowHandle]["Aisle"] = e.Value;
            this.grdInputBaysToPrint.DataSource = this.tbBaysDataSource;
            this.grvInputBaysToPrint.RefreshData();
            this.AddNewRow();
        }

        private void grvInputBaysToPrint_ShownEditor(object sender, EventArgs e)
        {
            if (!grvInputBaysToPrint.FocusedColumn.Name.Equals("colAisle")) return;
            GridView view = sender as GridView;
            if (view.ActiveEditor is LookUpEdit)
            {
                ((LookUpEdit)view.ActiveEditor).ShowPopup();
            }
        }

        private void grvInputBaysToPrint_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if (e.FocusedColumn.FieldName.Equals("Aisle"))
            {
                string roomID = Convert.ToString(this.grvInputBaysToPrint.GetFocusedRowCellValue("RoomID"));
                if (string.IsNullOrEmpty(roomID)) return;
                this.LoadAisle(roomID);
                grvInputBaysToPrint.FocusedColumn = colAisle;
                grvInputBaysToPrint.SetFocusedRowCellValue(colAisle, 0);
                grvInputBaysToPrint.ShowEditor();
            }
        }

        /// <summary>
        /// Gets the selected rooms from bays grid.
        /// </summary>
        /// <param name="gridView">The grid view.</param>
        /// <returns></returns>
        private List<string> GetSelectedRoomsFromBaysGrid(GridView gridView)
        {
            var rooms = new List<string>();

            for (int i = 0; i < gridView.RowCount; i++)
            {
                var roomId = gridView.GetRowCellValue(i, RoomID)?.ToString();
                if (!string.IsNullOrEmpty(roomId))
                {
                    rooms.Add($"('{roomId}')");
                }
            }

            return rooms;
        }

        /// <summary>
        /// Handles the Load event of the frm_ST_StockTakeByRequest control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void frm_ST_StockTakeByRequest_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the Close event of the frm_ST_StockTakeByRequest control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void frm_ST_StockTakeByRequest_Close(object sender, EventArgs e)
        {
            // TODO: cleanup tmpRooms on DB

        }

        /// <summary>
        /// Calculates the location.
        /// </summary>
        private void CalculateLocation()
        {
            string strWhere;
            string strSQL = string.Empty;
            string strRoomID;
            int iAisle;
            string strBays; // Chua cac bays se in

            // Update temp data
            var dataAccessInstance = new DataProcess<object>();
            var updateTmpLocForStockTakeTableSql = "UPDATE tmpLocForStockTake SET Used = 0";
            dataAccessInstance.ExecuteNoQuery(updateTmpLocForStockTakeTableSql);

            // Loop through each Bay, and build SQL command
            List<TableForInputBaysToPrint> baysData = null;
            var isBayGridHasData = this.IsGridViewInputBayHasData();

            if (isBayGridHasData) // Have selected Rooms on Bays
            {
                baysData = this.AnalyseBaysToPrint();
                if (!baysData.Any()) // No data
                {
                    XtraMessageBox.Show(this, "Something wrong !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Get first BayToPrint
                var firstBay = baysData.FirstOrDefault();
                if (firstBay.IsDefaultValue())
                {
                    return;
                }

                strBays = firstBay.BaysToPrint;
                strRoomID = firstBay.RoomID;
                iAisle = firstBay.Aisle;

                if (iAisle == 0)
                {
                    strWhere = $" WHERE (RoomID = '{strRoomID}')";
                }
                else
                {
                    strWhere = $" WHERE (RoomID = '{strRoomID}') AND (Aisle = {iAisle})";
                }

                if (strBays.Length > 0)
                {
                    strWhere = strWhere + $" AND (bay IN ({strBays}))";
                }

                foreach (var bayItem in baysData)
                {
                    if (bayItem.IsDefaultValue())
                    {
                        continue;
                    }

                    strBays = bayItem.BaysToPrint;
                    strRoomID = bayItem.RoomID;
                    iAisle = bayItem.Aisle;
                    if (iAisle > 0)
                    {
                        if (strBays.Length > 0)
                        {
                            strWhere = $" (RoomID = '{strRoomID}') AND (Aisle = {iAisle}) AND (bay IN ({strBays}))";
                        }
                        else
                        {
                            strWhere = $" (RoomID = '{strRoomID}') AND (Aisle = {iAisle})";
                        }
                    }
                    else // iAisle <= 0
                    {
                        if (strBays.Length > 0)
                        {
                            strWhere = $" (RoomID = '{strRoomID}') AND (bay IN ({strBays}))";
                        }
                        else
                        {
                            strWhere = $" (RoomID = '{strRoomID}')";
                        }
                    }

                    if (!string.IsNullOrEmpty(strSQL))
                    {
                        strSQL += $" UPDATE tmpLocForStockTake SET Used = 1 WHERE {strWhere} ;";
                    }
                    else
                    {
                        strSQL = $" UPDATE tmpLocForStockTake SET Used = 1 WHERE {strWhere};";
                    }
                }
            }
            else // lay het tat ca location de chay stock take
            {
                strSQL = "UPDATE tmpLocForStockTake SET Used = 1";
            }

            // Update tmpLocForStockTake used columns
            dataAccessInstance.ExecuteNoQuery(strSQL);

            // 
            if (baysData == null || !baysData.Any()) // No any Bay data item
            {
                dataAccessInstance.ExecuteNoQuery("UPDATE tmpLocForStockTake SET Used = 1");
            }
            else  // Existed Bays data
            {
                var sqlCmd = string.Empty;
                foreach (var bayItem in baysData)
                {
                    if (bayItem.HighsToPrint != 0)
                    {
                        sqlCmd = $"UPDATE tmpLocForStockTake SET Used = 0 WHERE RoomID = '{bayItem.RoomID}' AND High <> {bayItem.HighsToPrint}";
                        dataAccessInstance.ExecuteNoQuery(sqlCmd);
                    }

                    if (bayItem.DeepsToPrint != 0)
                    {
                        sqlCmd = $"UPDATE tmpLocForStockTake SET Used = 0 WHERE RoomID = '{bayItem.RoomID}' AND Deep <> {bayItem.DeepsToPrint}";
                        dataAccessInstance.ExecuteNoQuery(sqlCmd);
                    }
                }
            }
        }

        /// <summary>
        /// Updates the SQL query.
        /// </summary>
        /// <returns></returns>
        private string UpdateSqlQuery()
        {
            var strCondition = string.Empty;

            if (this.grvCustomer.SelectedRowsCount == 0) // Selected Customer or not
            {
                strCondition = $"(SELECT ProductID FROM Products WHERE Products.Discontinue = 0)";
            }
            else // has select customer
            {
                //strCondition = "1";
                //foreach (var customerRow in this.grvCustomer.GetSelectedRows())
                //{
                //    var customerId = this.grvCustomer.GetRowCellValue(customerRow, "CustomerID");
                //    strCondition += $", {customerId}";
                //}

                //strCondition = $"({strCondition}))";

                //if (this.grvProductList.SelectedRowsCount == 0) // Selected Products or not
                //{
                //    strCondition = $"(SELECT ProductID From Products WHERE CustomerID IN {strCondition}";
                //}
                //else // Select products
                //{
                //    foreach (var productIndex in this.grvProductList.GetSelectedRows())
                //    {
                //        var productId = this.grvProductList.GetRowCellValue(productIndex, "ProductID");
                //        strCondition += $", {productId}";
                //    }
                //    strCondition = $"({strCondition})";
                //}

                strCondition = "1";

                if (this.grvProductList.SelectedRowsCount == 0) // Selected Products or not
                {
                    foreach (var customerRow in this.grvCustomer.GetSelectedRows())
                    {
                        var customerId = this.grvCustomer.GetRowCellValue(customerRow, "CustomerID");
                        strCondition += $", {customerId}";
                                            
                    }
                    strCondition = $"({strCondition}))";
                    strCondition = $"(SELECT ProductID From Products WHERE CustomerID IN {strCondition}";
                }
                else // Select products
                {
                    foreach (var productIndex in this.grvProductList.GetSelectedRows())
                    {
                        var productId = this.grvProductList.GetRowCellValue(productIndex, "ProductID");
                        strCondition += $", {productId}";
                    }
                    strCondition = $"({strCondition})";
                }

            }

            var sqlQuery = $"STStockTakeByRequest '{strCondition}', {AppSetting.StoreID}";
            return sqlQuery;
        }

        /// <summary>
        /// Analyses the bays to print.
        /// </summary>
        /// <returns></returns>
        private List<TableForInputBaysToPrint> AnalyseBaysToPrint()
        {
            var baysData = this.GetDataOnTableToBayModel(this.grvInputBaysToPrint);
            foreach (var bay in baysData)
            {
                if (bay.IsDefaultValue())
                {
                    continue;
                }

                if (!string.IsNullOrEmpty(bay.BaysToPrint))
                {
                    bay.BaysToPrint = this.StandardListBays(bay.BaysToPrint);
                }
            }

            // Re-update data for Bay grid view
            // this.ReUpdateDataSourceForGrid(this.grvInputBaysToPrint, this.grdInputBaysToPrint, baysData, this.tbBaysDataSource);
            return baysData;

        }

        private List<TableForInputBaysToPrint> GetDataOnTableToBayModel(GridView gridView)
        {
            var bayCollections = new List<TableForInputBaysToPrint>();

            for (int i = 0; i < gridView.RowCount; i++)
            {
                var bayItem = new TableForInputBaysToPrint();

                // RoomID
                var roomId = gridView.GetRowCellValue(i, RoomID)?.ToString();
                if (!string.IsNullOrEmpty(roomId))
                {
                    bayItem.RoomID = roomId;
                }

                // Aisle
                var aisle = gridView.GetRowCellValue(i, Aisle);
                bayItem.Aisle = Convert.ToInt32(aisle);

                // BayToPrint
                var bayToPrint = gridView.GetRowCellValue(i, BaysToPrint);
                bayItem.BaysToPrint = bayToPrint?.ToString() ?? string.Empty;

                // HightToPrint
                var hightToPrint = gridView.GetRowCellValue(i, HighsToPrint);
                bayItem.HighsToPrint = Convert.ToInt32(hightToPrint);

                // DeepsToPrint
                var deepsToPrint = gridView.GetRowCellValue(i, DeepsToPrint);
                bayItem.DeepsToPrint = Convert.ToInt32(deepsToPrint);

                // Add to collection
                bayCollections.Add(bayItem);
            }

            return bayCollections;
        }

        /// <summary>
        /// Res the update data source for grid.
        /// </summary>
        /// <param name="gridView">The grid view.</param>
        /// <param name="gridData">The grid data.</param>
        /// <param name="datas">The data.</param>
        /// <param name="dataSource">The data source.</param>
        private void ReUpdateDataSourceForGrid(GridView gridView, GridControl gridData, List<TableForInputBaysToPrint> datas, DataTable dataSource)
        {
            if (gridView.DataRowCount == 0)
            {
                return;
            }

            for (int i = 0; i < dataSource.Rows.Count; i++)
            {
                var newDataRowInstace = datas.ElementAtOrDefault(i);
                var rowData = this.tbBaysDataSource.Rows[i];
                if (rowData == null || newDataRowInstace == null)
                {
                    continue;
                }

                rowData[RoomID] = newDataRowInstace.RoomID;
                rowData[Aisle] = newDataRowInstace.Aisle;
                rowData[BaysToPrint] = newDataRowInstace.BaysToPrint;
                rowData[HighsToPrint] = newDataRowInstace.HighsToPrint;
                rowData[DeepsToPrint] = newDataRowInstace.DeepsToPrint;
            }

            gridData.DataSource = tbBaysDataSource;
            gridView.RefreshData();
        }

        /// <summary>
        /// Standards the list bays.
        /// </summary>
        /// <param name="bayStr">The bay string.</param>
        /// <returns></returns>
        private string StandardListBays(string bayStr)
        {
            // In: 123,456,78-99 => OUT: 123,456,78,99 
            char[] commaChar = { ',' };
            char[] dashChar = { '-' };

            var bayDatas = new List<string>();
            var splitedBayCollections = bayStr.Split(commaChar, StringSplitOptions.RemoveEmptyEntries);

            foreach (var bayValue in splitedBayCollections)
            {
                if (bayValue.Contains("-")) // Ex: 30-45 => 30,31.....44,45
                {
                    var coupleBayValue = bayValue.Split(dashChar, StringSplitOptions.RemoveEmptyEntries);
                    var start = 0;
                    int.TryParse(coupleBayValue[0], out start);
                    var end = 0;
                    int.TryParse(coupleBayValue[coupleBayValue.Length - 1], out end);

                    if (start <= end) // Increase case
                    {
                        for (int i = start; i <= end; i++)
                        {
                            bayDatas.Add(i.ToString());
                        }
                    }
                    else // degree case 
                    {
                        for (int i = start; i >= end; i--)
                        {
                            bayDatas.Add(i.ToString());
                        }
                    }
                }
                else
                {
                    bayDatas.Add(bayValue);
                }
            }

            var outBaysStr = string.Join(",", bayDatas);
            return outBaysStr;
        }

        /// <summary>
        /// Calculates the products.
        /// </summary>
        private void CalculateProducts()
        {
            var dataAccessInstance = new DataProcess<object>();
            // Cleanup data in tmpCustomers table
            if (this.grvCustomer.SelectedRowsCount <= 0) // NO selected Customer
            {
                XtraMessageBox.Show(this, "No customers selected, report all customers !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dataAccessInstance.ExecuteNoQuery("DELETE FROM tmpCustomers");
                dataAccessInstance.ExecuteNoQuery("INSERT INTO tmpCustomers (CustomerID) SELECT CustomerID FROM Customers ;");
                dataAccessInstance.ExecuteNoQuery("DELETE FROM tmpProducts");
                dataAccessInstance.ExecuteNoQuery("INSERT INTO tmpProducts (ProductID) SELECT ProductID FROM Products;");

                return;
            }
            else
            {
                dataAccessInstance.ExecuteNoQuery("DELETE FROM tmpCustomers");
                foreach (var rowIndex in this.grvCustomer.GetSelectedRows())
                {
                    var customerId = this.grvCustomer.GetRowCellValue(rowIndex, CustomerID)?.ToString();
                    if (!string.IsNullOrEmpty(customerId))
                    {
                        dataAccessInstance.ExecuteNoQuery($"INSERT INTO tmpCustomers (CustomerID) SELECT {customerId};");
                    }
                }
            }

        }

        /// <summary>
        /// Determines whether [is grid view input bay has data].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if [is grid view input bay has data]; otherwise, <c>false</c>.
        /// </returns>
        private bool IsGridViewInputBayHasData()
        {
            var baysData = this.GetDataOnTableToBayModel(this.grvInputBaysToPrint);
            if (!baysData.Any())
            {
                return false;
            }

            if (baysData.Count == 1)
            {
                return !baysData.First().IsDefaultValue();
            }

            return baysData.Any();
        }

        private void btnCreateProductChecking_Click(object sender, EventArgs e)
        {
            CalculateLocation();
            String strProductID = "";

            foreach (int i in this.grvProductList.GetSelectedRows())
            {
                strProductID = strProductID + "," + this.grvProductList.GetRowCellValue(i, "ProductD");
            }
            if (strProductID == "")
                return;
            SqlConnection conn = new SqlConnection(new SwireDBEntities().Database.Connection.ConnectionString);
            SqlCommand cmd = new SqlCommand("STCustomerStockTake_CreateOrderStockTake", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter varCustomerID = cmd.Parameters.Add("@CustomerID", SqlDbType.Int);
            varCustomerID.Value = Convert.ToInt32(this.grvCustomer.GetFocusedRowCellValue("CustomerID"));

            SqlParameter varProductID = cmd.Parameters.Add("@strProductID", SqlDbType.VarChar);
            varProductID.Value = strProductID;
            SqlParameter CurrentUser = cmd.Parameters.Add("@CurrentUser", SqlDbType.VarChar);
            CurrentUser.Value = Convert.ToString(AppSetting.CurrentUser);
            SqlParameter varCustomerStockTakeID = cmd.Parameters.Add("@CustomerStockTakeID", SqlDbType.Int);
            varCustomerStockTakeID.Direction = ParameterDirection.Output;
            conn.Open();
            int result = cmd.ExecuteNonQuery();

            frm_WM_CustomerStockTakes frm = new frm_WM_CustomerStockTakes(Convert.ToInt32(varCustomerStockTakeID.Value));
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
        }
    }

    /// <summary>
    /// TableForInputBaysToPrint class
    /// </summary>
    public class TableForInputBaysToPrint
    {
        public int Id { get; set; } = 0;

        public string RoomID { get; set; } = string.Empty;

        public int Aisle { get; set; } = 0;

        public string BaysToPrint { get; set; } = string.Empty;

        public int HighsToPrint { get; set; } = 0;

        public int DeepsToPrint { get; set; } = 0;

        /// <summary>
        /// Determines whether [is default value].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if [is default value]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsDefaultValue()
        {
            if (this.Id == 0
                && string.Equals(this.RoomID, string.Empty)
                && this.Aisle == 0
                && string.Equals(this.BaysToPrint, string.Empty)
                && this.HighsToPrint == 0
                && this.DeepsToPrint == 0)
            {
                return true;
            }
            return false;
        }
    }
}
