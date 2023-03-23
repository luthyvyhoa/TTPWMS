using Common.Controls;
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
using UI.WarehouseManagement;
using System.Web;
using UI.ReportFile;
using UI.Helper;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
//////using RestSharp.Contrib;

namespace UI.Transport
{
    public partial class frm_T_TransportTripList : frmBaseFormNormal
    {
        private urc_WM_OtherService viewService = null;
        private DataTable dataSource = null;
        public frm_T_TransportTripList()
        {
            InitializeComponent();
            this.deTransportTripFromDate.DateTime = DateTime.Today.AddDays(-7);
            this.deTransportTripToDate.DateTime = DateTime.Today;

            LoadGrid();
        }

        private void rpe_hle_TransportTripID_Click(object sender, EventArgs e)
        {
            //Code to open form Trip if it is WMS
            string tripType = this.grvTransportTripList.GetFocusedRowCellValue("TripNumber").ToString().Substring(0, 2);
            if (tripType == "TW")
            {
                frm_WM_TripsManagement frm = new frm_WM_TripsManagement(Convert.ToInt32(this.grvTransportTripList.GetFocusedRowCellValue("TripID").ToString()));
                frm.Show();
                frm.BringToFront();
            }
            else
                MessageBox.Show("Can not open form Trip for this trip. Please use Distribution Service App ", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void LoadGrid()
        {
            string dateFrom = Convert.ToDateTime(deTransportTripFromDate.EditValue).Date.ToString("yyyy-MM-dd");
            string dateTo = Convert.ToDateTime(deTransportTripToDate.EditValue).Date.ToString("yyyy-MM-dd");
            string strSQL = "";
            if (this.checkWMS.Checked)
            {
                strSQL = "ST_WMS_LoadTransportTripList '" + dateFrom + "','" + dateTo + "',2," + AppSetting.StoreID;
            }
            else
            {
                strSQL = "ST_WMS_LoadTransportTripList '" + dateFrom + "','" + dateTo + "',1," + AppSetting.StoreID;
            }
            this.grcTransportTripList.DataSource = FileProcess.LoadTable(strSQL);
            this.grcExpenseDetail.DataSource = null;

        }

        private void LoadTransportList()
        {
            //this.rpi_lke_transporter.DataSource = FileProcess.LoadTable("  Select * from ViewSupplierTransporters ");
            //this.rpi_lke_transporter.DisplayMember = "SupplierName";
            //this.rpi_lke_transporter.ValueMember = "SupplierName";
            //this.rpi_lke_transporter.DropDownRows = 20;
        }

        private void deTransportTripFromDate_EditValueChanged(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void deTransportTripToDate_EditValueChanged(object sender, EventArgs e)
        {
            LoadGrid();
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void checkWMS_CheckedChanged(object sender, EventArgs e)
        {
            LoadGrid();
        }
        public string TamperProofKey = "fucker";

        // Function to encode the string
        public string TamperProofStringEncode(string value, string key)
        {
            System.Security.Cryptography.MACTripleDES mac3des = new System.Security.Cryptography.MACTripleDES();
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            mac3des.Key = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(key));
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(value)) + '-' + Convert.ToBase64String(mac3des.ComputeHash(System.Text.Encoding.UTF8.GetBytes(value)));
        }
        public string QueryStringEncode(string value)
        {
            return HttpUtility.UrlEncode(TamperProofStringEncode(value, TamperProofKey));
        }

        private void btnNewVehicle_Click(object sender, EventArgs e)
        {

        }

        private void rpe_hle_ViewNote_Click(object sender, EventArgs e)
        {
            //string tripID =  this.grvTransportTripList.GetFocusedRowCellValue("TripID").ToString();
            string orderNumber = this.grvTransportTripList.GetFocusedRowCellValue("TripNumber").ToString();
            //MessageBox.Show("This is the encoded for " + orderNumber + " :  " + QueryStringEncode(orderNumber));

            string urlEncoded = "https://KNM .vn:688/TripDetails.aspx?TripNumber=" + QueryStringEncode(orderNumber);

            DevExpress.XtraReports.UI.XtraReport report = null;
            DataTable dataSource = null;

            report = new rptTripDeliveryNote();
            report.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
            report.Parameters["urlEncoded"].Value = urlEncoded;
            dataSource = FileProcess.LoadTable("STTripDetailUniversal '" + orderNumber + "'");
            report.DataSource = dataSource;
            ReportPrintToolWMS printTool = new ReportPrintToolWMS(report);
            printTool.AutoShowParametersPanel = false;

            printTool.ShowPreview();

        }

        private void grvTransportTripList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                frm_WM_Attachments.Instance.OrderNumber = this.grvTransportTripList.GetFocusedRowCellValue("TripNumber").ToString();
                if (!frm_WM_Attachments.Instance.Enabled) return;
                frm_WM_Attachments.Instance.ShowDialog();
            }
        }

        private void grcTransportTripList_KeyDown(object sender, KeyEventArgs e)
        {
            grvTransportTripList_KeyDown(sender, e);
        }

        private void grcTransportTripList_ProcessGridKey(object sender, KeyEventArgs e)
        {
            GridControl grid = sender as GridControl;
            GridView view = grid.FocusedView as GridView;
            bool shouldSelectRow = false;
            if (view.IsEditing && (e.KeyCode == Keys.F3))
            {
                shouldSelectRow = view.GetSelectedCells(view.FocusedRowHandle).Count() == view.VisibleColumns.Count && view.GetSelectedRows().Count() == 1;
                grvTransportTripList_KeyDown(sender, e);
            }
            BeginInvoke(new Action(() =>
            {
                if (shouldSelectRow)
                    view.SelectRow(view.FocusedRowHandle);
            }));
        }

        private void dockPanelOtherServices_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            string TNu = this.grvTransportTripList.GetFocusedRowCellValue("TripNumber").ToString();
            string customerNumber = Convert.ToString(this.grvTransportTripList.GetFocusedRowCellValue("CustomerNumber"));
            int customerID = 0;
            if (!string.IsNullOrEmpty(customerNumber)) customerID = Convert.ToInt32(customerNumber.Split('-')[1]);
            if (this.viewService == null)
            {
                this.viewService = new urc_WM_OtherService(TNu, customerID);
                this.viewService.Parent = this.dockPanelOtherServices;
            }
            else
            {
                this.viewService.InitData(TNu, customerID);
            }
        }

        private void grvTransportTripList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            loadDetailGrid();
        }

        private void loadDetailGrid()
        {
            dataSource = FileProcess.LoadTable("ST_WMS_LoadOperatingCostExpenseDetails '" +
                    this.grvTransportTripList.GetFocusedRowCellValue("TripNumber") + "',0,1");
            this.grcExpenseDetail.DataSource = dataSource;
            //string xxx = "ST_WMS_LoadOperatingCostExpenseDetails] '" +
            //        this.grvTransportTripList.GetFocusedRowCellValue("TripNumber") + "',0,1";

            AddNewRow();
            //LoadServiceCode();
            LoadPurchasingOrderDetail();
        }


        private void AddNewRow()
        {

            if (this.dataSource == null) return;
            var newRow = this.dataSource.NewRow();
            newRow["ExpenseOrderNumber"] = "";
            newRow["ExpenseOrderDetailID"] = 0;

            newRow["ExpenseAmount"] = 0;
            newRow["CreatedTime"] = DateTime.Now;
            newRow["CreatedBy"] = AppSetting.CurrentUser.LoginName;


            newRow["ExpenseCode"] = "";
            newRow["ExpenseName"] = "";

            newRow["PuchasingDate"] = DateTime.Now;
            newRow["SupplierName"] = "";

            newRow["OperatingCostExpenseDetailID"] = 0;
            //newRow["ExpenseOrderNumber"] = "";
            //newRow["ExpenseOrderDetailID"] = 0;

            this.dataSource.Rows.InsertAt(newRow, 0); //Add(newRow);
            this.grcExpenseDetail.DataSource = this.dataSource;
            this.grcExpenseDetail.RefreshDataSource();
        }

        private void rpi_lke_po_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            DataProcess<object> dataProcess = new DataProcess<object>();
            string order_number = this.grvTransportTripList.GetFocusedRowCellValue("TripNumber").ToString();
            var selectedValue = (DevExpress.XtraEditors.LookUpEdit)sender;

            string PO = selectedValue.GetColumnValue("PurchasingOrderNumber").ToString();
            if (PO.Length == 0) return;

            int id = Convert.ToInt32(grvExpenseDetail.GetFocusedRowCellValue("OperatingCostExpenseDetailID"));

            if (id == 0)
            {
                string sql = String.Format("Insert into OperatingCostExpenseDetails (ExpenseOrderNumber, ExpenseOrderDetailID, ExpenseAmount, " +
                                        "OrderNumber,  CreatedBy, CreatedTime, ExpenseCode, ExpenseName, ExpenseQuantity, ExpenseUnitPrice) " +
                                        "Values ('{0}',{1},'{2}','{3}',N'{4}',getdate(),N'{5}',N'{6}',{7},{8})",

                                        selectedValue.GetColumnValue("PurchasingOrderNumber").ToString(),
                                        Convert.ToInt32(selectedValue.GetColumnValue("PurchasingOrderDetailID")),
                                        0,
                                        order_number,
                                        AppSetting.CurrentUser.LoginName,
                                        "",
                                        "",
                                        0,
                                        0
                                        );
                int result = dataProcess.ExecuteNoQuery(sql);
                if (result > 0)
                    loadDetailGrid();
            }
            else
            {
                string sql = String.Format("Update OperatingCostExpenseDetails set ExpenseOrderNumber = '{0}', ExpenseOrderDetailID = {1}, " +
                                        " CreatedBy = N'{2}', CreatedTime =getdate()  Where OperatingCostExpenseDetailID = {3}",

                                        selectedValue.GetColumnValue("PurchasingOrderNumber").ToString(),
                                        Convert.ToInt32(selectedValue.GetColumnValue("PurchasingOrderDetailID")),
                                        AppSetting.CurrentUser.LoginName,
                                        id
                                        );

                int result = dataProcess.ExecuteNoQuery(sql);
                if (result > 0)
                    loadDetailGrid();
            }

            //if (grvExpenseDetail.GetFocusedRowCellValue("OperatingCostExpenseDetailID") == null)
            //{
            //    string sql = String.Format("Insert into OperatingCostExpenseDetails (ExpenseOrderNumber, ExpenseOrderDetailID, ExpenseAmount, " +
            //                            "OrderNumber,  CreatedBy, CreatedTime, ExpenseCode, ExpenseName, ExpenseQuantity, ExpenseUnitPrice) " +
            //                            "Values ('{0}',{1},'{2}','{3}','{4}',getdate(),N'{5}',N'{6}',{7},{8})",

            //                            selectedValue.GetColumnValue("ExpenseOrderNumber").ToString(),
            //                            Convert.ToInt32(selectedValue.GetColumnValue("ExpenseOrderDetailID")),
            //                            Convert.ToDecimal(selectedValue.GetColumnValue("ExpenseAmount")),
            //                            //selectedValue.GetColumnValue("TripNumber").ToString(),
            //                            order_number,
            //                            AppSetting.CurrentUser.LoginName,
            //                            selectedValue.GetColumnValue("ExpenseCode").ToString(),
            //                            selectedValue.GetColumnValue("ExpenseName").ToString(),
            //                            Convert.ToDecimal(selectedValue.GetColumnValue("ExpenseQuantity")),
            //                            Convert.ToDecimal(selectedValue.GetColumnValue("ExpenseUnitPrice"))
            //                            );

            //    int result = dataProcess.ExecuteNoQuery(sql);
            //    if (result > 0)
            //        loadDetailGrid();
            //}
            //else
            //{
            //    int id = Convert.ToInt32(grvExpenseDetail.GetFocusedRowCellValue("OperatingCostExpenseDetailID"));
            //    string sql = String.Format("Update OperatingCostExpenseDetails set ExpenseOrderNumber = '{0}', ExpenseOrderDetailID = {1}, ExpenseAmount = '{2}', " +
            //                            "OrderNumber = '{3}',  CreatedBy = '{4}', CreatedTime =getdate(), ExpenseCode = N'{5}'," +
            //                            " ExpenseName = N'{6}', ExpenseQuantity= {7} , ExpenseUnitPrice= {8}) " +
            //                            " Where OperatingCostExpenseDetailID = {9}",

            //                            selectedValue.GetColumnValue("ExpenseOrderNumber").ToString(),
            //                            Convert.ToInt32(selectedValue.GetColumnValue("ExpenseOrderDetailID")),
            //                            Convert.ToDecimal(selectedValue.GetColumnValue("ExpenseAmount")),
            //                            //selectedValue.GetColumnValue("TripNumber").ToString(),
            //                            order_number,
            //                            AppSetting.CurrentUser.LoginName,
            //                            selectedValue.GetColumnValue("ExpenseCode").ToString(),
            //                            selectedValue.GetColumnValue("ExpenseName").ToString(),
            //                            Convert.ToDecimal(selectedValue.GetColumnValue("ExpenseQuantity")),
            //                            Convert.ToDecimal(selectedValue.GetColumnValue("ExpenseUnitPrice")),
            //                            id
            //                            );

            //    int result = dataProcess.ExecuteNoQuery(sql);
            //    if (result > 0)
            //        loadDetailGrid();
            //}



        }

        private void rpi_lke_service_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            DataProcess<object> dataProcess = new DataProcess<object>();
            string order_number = this.grvTransportTripList.GetFocusedRowCellValue("TripNumber").ToString();
            var selectedValue = (DevExpress.XtraEditors.LookUpEdit)sender;

            string code = selectedValue.GetColumnValue("ServiceCode").ToString();
            if (code.Length == 0) return;

            int id = Convert.ToInt32(grvExpenseDetail.GetFocusedRowCellValue("OperatingCostExpenseDetailID"));
            if (id > 0)
            {
                string sql = String.Format("Update OperatingCostExpenseDetails set  ExpenseAmount = {0}, " +
                                        " ExpenseCode = N'{1}', ExpenseName = N'{2}', ExpenseQuantity= {3} , ExpenseUnitPrice= {4}, " +
                                        " PayableCapacity = {6}, ContractAppendixNumber = '{7}' Where OperatingCostExpenseDetailID = {5}",


                                        Convert.ToDecimal(selectedValue.GetColumnValue("EA")),
                                        selectedValue.GetColumnValue("ServiceCode").ToString(),
                                        selectedValue.GetColumnValue("ItemDescription").ToString(),
                                        Convert.ToDecimal(selectedValue.GetColumnValue("Qty")),
                                        Convert.ToDecimal(selectedValue.GetColumnValue("UnitPrice")),
                                        id,
                                        Convert.ToInt16(selectedValue.GetColumnValue("TruckCapacity")),
                                        selectedValue.GetColumnValue("ContractAppendixNumber").ToString()
                                        );

                int result = dataProcess.ExecuteNoQuery(sql);
                if (result > 0)
                    loadDetailGrid();
            }

        }

        private void grvExpenseDetail_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

            if (e.RowHandle < 0) return;
            DataProcess<object> dataProcess = new DataProcess<object>();
            var currentRow = this.grvExpenseDetail.GetDataRow(e.RowHandle);
            int id = Convert.ToInt32(grvExpenseDetail.GetRowCellValue(e.RowHandle, "OperatingCostExpenseDetailID"));

            if (e.Column == UnitPrice || e.Column == Quantity)
            {
                decimal price = 0;
                decimal qty = 0;

                if (grvExpenseDetail.GetFocusedRowCellValue(UnitPrice) != null)
                    price = Convert.ToDecimal(grvExpenseDetail.GetFocusedRowCellValue(UnitPrice));
                if (grvExpenseDetail.GetFocusedRowCellValue(Quantity) != null)
                    qty = Convert.ToDecimal(grvExpenseDetail.GetFocusedRowCellValue(Quantity));

                decimal amount = qty * price;
                grvExpenseDetail.SetFocusedRowCellValue(Amount, amount);
                //grvExpenseDetail.SetFocusedRowCellValue(Amount, amount.ToString("0:0,0.###"));
                //grvPettyDetails.SetFocusedRowCellValue(gridColumnRemark, this.PettyCashDetailsList.Count);
            }

            if (e.Column != PO && e.Column != PO_Amount
                && e.Column != Supplier && e.Column != PO_Remark && e.Column != Order_No)
            {
                dataProcess.ExecuteNoQuery("Update OperatingCostExpenseDetails Set " + e.Column.FieldName
                        + "=N'" + e.Value + "' Where OperatingCostExpenseDetailID=" + id);
            }

        }


        private void LoadServiceCode()
        {
            if (grvTransportTripList.GetFocusedRowCellValue("TripNumber") == null || Convert.ToUInt32(this.grvExpenseDetail.GetFocusedRowCellValue("OperatingCostExpenseDetailID")) == 0) return;
            string orderNumber = grvTransportTripList.GetFocusedRowCellValue("TripNumber").ToString();
            //string tr = "STTransportContractServices '" + orderNumber + "'," + this.grvExpenseDetail.GetFocusedRowCellValue("OperatingCostExpenseDetailID");
            this.rpi_lke_service.DataSource = FileProcess.LoadTable("STTransportContractServices '" + orderNumber + "'," + this.grvExpenseDetail.GetFocusedRowCellValue("OperatingCostExpenseDetailID"));
            this.rpi_lke_service.DisplayMember = "ServiceCode";
            this.rpi_lke_service.ValueMember = "ServiceCode";
            this.rpi_lke_service.DropDownRows = 20;
        }


        private void LoadPurchasingOrderDetail()
        {
            //if (grvExpenseDetail.GetFocusedRowCellValue("ExpenseOrderNumber") == null)
            //{
            //    this.rpi_lke_po.DataSource = null;
            //    return;
            //}
            if (grvTransportTripList.GetFocusedRowCellValue("TripNumber") == null) return;
            string TripNumber = grvTransportTripList.GetFocusedRowCellValue("TripNumber").ToString();
            this.rpi_lke_po.DataSource = FileProcess.LoadTable(" STTransportContractPO '" + TripNumber + "'");
            this.rpi_lke_po.DisplayMember = "PurchasingOrderNumber";
            this.rpi_lke_po.ValueMember = "PurchasingOrderNumber";
            this.rpi_lke_po.DropDownRows = 20;
        }

        private void grvTransportTripList_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle < 0) return;

            DataProcess<object> dataProcess = new DataProcess<object>();
            string order_number = grvTransportTripList.GetRowCellValue(e.RowHandle, "TripNumber").ToString();

            if (e.Column.FieldName == "TripRemark")
            {
                if (order_number.Length > 0)
                {
                    // Update records
                    string strSQL = "";

                    if (this.checkWMS.Checked)
                    {
                        strSQL = "Update Trips Set TripRemark= N'" + e.Value + "' Where TripNumber = '" + order_number + "'";
                    }
                    else
                    {
                        strSQL = "Update BigC_Trips Set TripRemark= N'" + e.Value + "' Where TripNumber = '" + order_number + "'";
                    }

                    int result = dataProcess.ExecuteNoQuery(strSQL);

                    if (result > 0)
                        LoadGrid();
                }

            }

        }

        private void grvExpenseDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DataProcess<object> dataProcess = new DataProcess<object>();
                if (grvExpenseDetail.GetRowCellValue(grvExpenseDetail.FocusedRowHandle, "OperatingCostExpenseDetailID") == null) return;
                int id = Convert.ToInt32(grvExpenseDetail.GetRowCellValue(grvExpenseDetail.FocusedRowHandle, "OperatingCostExpenseDetailID"));
                int result = dataProcess.ExecuteNoQuery("DELETE FROM OperatingCostExpenseDetails WHERE OperatingCostExpenseDetailID = " + id);
                if (result > 0)
                    this.grcExpenseDetail.DataSource = FileProcess.LoadTable("ST_WMS_LoadOperatingCostExpenseDetails '" +
                    this.grvTransportTripList.GetFocusedRowCellValue("TripNumber") + "',0,1");
            }
        }

        private void dockPanelTripDetails_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            this.grcTripDetails.DataSource = FileProcess.LoadTable("STTransportTripDetails '" +  this.grvTransportTripList.GetFocusedRowCellValue("TripNumber").ToString() + "'");
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            this.deTransportTripFromDate.DateTime = DateTime.Today;
            this.deTransportTripToDate.DateTime = DateTime.Today;
        }

        private void grvExpenseDetail_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadServiceCode();
        }
    }
}
