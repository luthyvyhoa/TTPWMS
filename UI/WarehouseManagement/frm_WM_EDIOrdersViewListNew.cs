using DA;
using DA.Warehouse;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Helper;
using UI.MasterSystemSetup;
using System.Data.Entity.Core.Objects;
using DevExpress.XtraGrid.Views.Grid;
using Common.Controls;
using System.Data;
using DevExpress.XtraGrid;
using UI.Management;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_EDIOrdersViewListNew : frmBaseFormNormal
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(frm_WM_EDIOrdersViewListNew));
        BindingList<EDI_OrderDetails> m_BindingListOrderDetai = new BindingList<EDI_OrderDetails>();
        private urc_MSS_CustomerClients urcClient = null;
        private BindingList<ST_WMS_LoadEDIDetailsByID_Result> ediDetailsSource = null;
        private DataTable stockSource;
        private int productID;
        frm_WM_WavePicking frmWave = null;
        private int showOnlySelected = 0;
        private string selectedRows = string.Empty;
        //private bool isViewAllOrders = true;
        public frm_WM_EDIOrdersViewListNew()
        {
            InitializeComponent();
            progressBarControl1.Visible = false;
            this.KeyPreview = true;
            this.dateEditFromDate.EditValue = DateTime.Now.AddDays(-2).ToShortDateString();
            this.dateEditToDate.EditValue = DateTime.Now.ToShortDateString();
            string dateFrom = Convert.ToDateTime(dateEditFromDate.EditValue).Date.ToString("yyyy-MM-dd");
            string dateTo = Convert.ToDateTime(dateEditToDate.EditValue).Date.ToString("yyyy-MM-dd");
            //this.grdEDIOrderList.DataSource = DA.FileProcess.LoadTable("STEDIOrders @FromDate='" + dateFrom + "',@ToDate='" + dateTo + "', @CustomerID = " + this.lke_Customer.EditValue.ToString());
            this.lke_Customer.Properties.DataSource = FileProcess.LoadTable("STcomboCustomerID " + AppSetting.StoreID);
            this.lke_Customer.Properties.ValueMember = "CustomerID";
            this.lke_Customer.Properties.DisplayMember = "CustomerNumber";
            //this.radioGroup_DispatchType.EditValue = 1;
            this.dateEditFromDate.DateTime = DateTime.Now;
            this.dateEditToDate.DateTime = DateTime.Now;
            showOnlySelected = 0;
            this.lkeDispatchType.Properties.DataSource = FileProcess.LoadTable("SELECT CustomerDispatchMethodID, CAST(CustomerDispatchMethodID as varchar(30)) + ' | ' + CustomerDispatchMethod + CASE WHEN Remark IS NULL THEN '' ELSE ' | ' + Remark END  as CustomerDispatchMethod FROM CustomerDispatchMethod");
            this.lkeDispatchType.Properties.ValueMember = "CustomerDispatchMethodID";
            this.lkeDispatchType.Properties.DisplayMember = "CustomerDispatchMethod";
            this.checkCustomerMain.Checked = true;

            //this.grvEDIOrderViewList.CheckBoxSelectorColumnWidth = 10;
        }
        public frm_WM_EDIOrdersViewListNew(DateTime orderDate, int customerID, string EDI_OrderID_List)
        {
            InitializeComponent();
            progressBarControl1.Visible = false;
            this.dateEditFromDate.EditValue = DateTime.Now.AddDays(-2).ToShortDateString();
            this.dateEditToDate.EditValue = DateTime.Now.ToShortDateString();
            string dateFrom = Convert.ToDateTime(orderDate).Date.ToString("yyyy-MM-dd");
            string dateTo = Convert.ToDateTime(orderDate).Date.ToString("yyyy-MM-dd");
            this.lke_Customer.Properties.DataSource = FileProcess.LoadTable("STcomboCustomerID " + AppSetting.StoreID);
            this.lke_Customer.Properties.ValueMember = "CustomerID";
            this.lke_Customer.Properties.DisplayMember = "CustomerNumber";
            this.lke_Customer.EditValue = customerID;

            this.lkeDispatchType.Properties.DataSource = FileProcess.LoadTable("SELECT CustomerDispatchMethodID, CAST(CustomerDispatchMethodID as varchar(30)) + ' | ' + CustomerDispatchMethod + CASE WHEN Remark IS NULL THEN '' ELSE ' | ' + Remark END  as CustomerDispatchMethod FROM CustomerDispatchMethod");
            this.lkeDispatchType.Properties.ValueMember = "CustomerDispatchMethodID";
            this.lkeDispatchType.Properties.DisplayMember = "CustomerDispatchMethod";

            //this.radioGroup_DispatchType.EditValue = 1;
            this.dateEditFromDate.DateTime = orderDate;
            this.dateEditToDate.DateTime = orderDate;
            this.showOnlySelected = 1;
            this.selectedRows = EDI_OrderID_List;
            //
            //Code to make the string into the array of int
            //edi_OrderID = 1;
            //this.grvEDIOrderDetailsView.FocusedRowHandle = this.grvEDIOrderDetailsView.LocateByValue("EDI_OrderID", edi_OrderID);

            this.grdEDIOrderList.DataSource = DA.FileProcess.LoadTable("STEDIOrders @FromDate='" + dateFrom + "',@ToDate='" + dateTo + "', @CustomerID = " + this.lke_Customer.EditValue.ToString() + ", @showOnlySelected_byWave= " + showOnlySelected + ", @strEDI = N'" + selectedRows + "'");

        }
        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            refreshMainGrid();
        }

        private void refreshMainGrid()
        {
            if (this.lke_Customer.EditValue == null) return;
            //this.grdEDIOrderList.Visible = true;
            this.btn_Refresh.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger;
            this.btnSumAll.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Question;
            string dateFrom = Convert.ToDateTime(dateEditFromDate.EditValue).Date.ToString("yyyy-MM-dd");
            string dateTo = Convert.ToDateTime(dateEditToDate.EditValue).Date.ToString("yyyy-MM-dd");
            this.grdEDIOrderList.DataSource = FileProcess.LoadTable("STEDIOrderList @FromDate='" + dateFrom + "',@ToDate='" + dateTo + "', @CustomerID = " + this.lke_Customer.EditValue.ToString());
            Customers cus = AppSetting.CustomerList.Where(c => c.CustomerID == Convert.ToInt32(this.lke_Customer.EditValue)).FirstOrDefault();
            this.lkeDispatchType.EditValue = cus.CustomerDispatchType;
            this.checkCrossDock.Checked = false;
        }

        private void lke_Customer_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            this.lke_Customer.EditValue = e.Value;
            txtCustomerName.Text = Convert.ToString(lke_Customer.Properties.GetDataSourceValue("CustomerName", lke_Customer.ItemIndex));

            //int v_CustomerID = Convert.ToInt32(e.Value);
            if (this.dateEditFromDate.DateTime == this.dateEditToDate.DateTime)
                refreshMainGrid();

        }

        private void repositoryItemHyperLinkEditOrderID_Click(object sender, EventArgs e)
        {
            // Open form RO, DO
            string orderNo = Convert.ToString(this.grvEDIOrderViewList.GetFocusedRowCellValue("ProcessingOrderNumber"));
            if (string.IsNullOrEmpty(orderNo)) return;
            string orderNumber = orderNo.Substring(0, 2);
            int OrderID = Convert.ToInt32(this.grvEDIOrderViewList.GetFocusedRowCellValue("ProcessingOrderNumber").ToString().Substring(3));
            if (orderNumber.ToUpper().Equals("DO"))
            {
                // Display dispatching order
                frm_WM_DispatchingOrders dispatchingOrder = frm_WM_DispatchingOrders.GetInstance(OrderID);
                if (dispatchingOrder.Visible)
                {
                    dispatchingOrder.ReloadData();
                }
                dispatchingOrder.Show();
                //dispatchingOrder.Size = new Size(800, 500); // Adjust size of Form to smaller
                dispatchingOrder.WindowState = FormWindowState.Maximized;
                //dispatchingOrder.StartPosition = FormStartPosition.CenterScreen;
                dispatchingOrder.BringToFront();
            }
            else if (orderNumber.ToUpper().Equals("RO"))
            {
                // Display Receiving Order
                frm_WM_ReceivingOrders receivingOrder = frm_WM_ReceivingOrders.Instance;
                receivingOrder.ReceivingOrderIDFind = OrderID;
                receivingOrder.Show();
                //receivingOrder.Size = new Size(800, 500); // Adjust size of Form to smaller
                receivingOrder.WindowState = FormWindowState.Maximized;
                //receivingOrder.StartPosition = FormStartPosition.CenterScreen;
                receivingOrder.BringToFront();
            }
            else if (orderNumber.ToUpper().Equals("SC"))
            {
                // Display SC
                frm_WM_PalletStatusChange frm = new frm_WM_PalletStatusChange();
                frm.PalletStatusChangeIDFind = OrderID;
                frm.Show();
                frm.WindowState = FormWindowState.Maximized;
                frm.BringToFront();
            }
            else if (orderNumber.ToUpper().Equals("PC"))
            {
                // Display SC
                frm_M_ProductCheckingByRequest frm = new frm_M_ProductCheckingByRequest();
                frm.ProductCheckingIDFind = OrderID;
                frm.Show();
                frm.WindowState = FormWindowState.Maximized;
                frm.BringToFront();
            }
        }

        private void repositoryItemHyperLinkEditEDI_ID_Click(object sender, EventArgs e)
        {
            int ediID = Convert.ToInt32(this.grvEDIOrderDetailsView.GetFocusedRowCellValue("EDI_OrderID"));
            frm_WM_EDIOrders frm = new frm_WM_EDIOrders(ediID);
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;


            //Open form frm_WM_EDIOrders. IF already open then load the record needed
        }

        private void btn_ViewDetails_Click(object sender, EventArgs e)
        {
            if (btn_ViewDetails.Text.Equals("View Details"))
            {
                btn_ViewDetails.Text = "Hide Details";
                this.grdEDIOrderList.Visible = true;
            }
            else
            {
                btn_ViewDetails.Text = "View Details";
                this.grdEDIOrderList.Visible = false;
            }
        }

        void LoadData_EDI_OrderDetail(int i_EDI_OrderID)
        {
            //try
            //{
            //    gridControl_EDIDetail.DataSource = null;
            //    DataProcess<ST_WMS_LoadEDIDetailsByID_Result> v_DA = new DataProcess<ST_WMS_LoadEDIDetailsByID_Result>();
            //    var dataSource = v_DA.Executing("ST_WMS_LoadEDIDetailsByID @EDI_ID={0}", i_EDI_OrderID);
            //    this.ediDetailsSource = new BindingList<ST_WMS_LoadEDIDetailsByID_Result>(dataSource.ToList());

            //    gridControl_EDIDetail.DataSource = this.ediDetailsSource;
            //    grvOrderDetai_LoadFormatRules();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error is unexpected");
            //}
            this.gridControl_EDIDetail.DataSource = FileProcess.LoadTable("ST_WMS_LoadEDIDetailsByIDNew " + i_EDI_OrderID);
        }

        //private void grvOrderDetai_LoadFormatRules()
        //{
        //    //add format rules here
        //    //grvEDIOrderDetailsView.FormatRules.Clear();
        //    //GridFormatRule FormatRuleProductID = new GridFormatRule();
        //    //FormatConditionRuleExpression formatConditionRuleExpression = new FormatConditionRuleExpression();
        //    //FormatRuleProductID.Column = gridColumnProductID;
        //    //FormatRuleProductID.ApplyToRow = true;
        //    //formatConditionRuleExpression.PredefinedName = "Red Fill";
        //    //formatConditionRuleExpression.Expression = "[ProductID]=" + productID;
        //    //FormatRuleProductID.Rule = formatConditionRuleExpression;
        //    //grvEDIOrderDetailsView.FormatRules.Add(FormatRuleProductID);

        //    //GridFormatRule FormatRuleProductQuantity = new GridFormatRule();
        //    //FormatConditionRuleExpression formatConditionRuleExpression2 = new FormatConditionRuleExpression();
        //    //FormatRuleProductQuantity.Column = gridColumnProductID;
        //    //FormatRuleProductQuantity.ApplyToRow = true;
        //    //formatConditionRuleExpression2.PredefinedName = "Red Bold Text";
        //    //formatConditionRuleExpression2.Expression = "[Quantity] > [StockQty]";
        //    //FormatRuleProductQuantity.Rule = formatConditionRuleExpression2;
        //    //grvEDIOrderDetailsView.FormatRules.Add(FormatRuleProductQuantity);

        //}

        private void btn_ImportFile_Click(object sender, EventArgs e)
        {
            int customerIDSelected = 0;
            if (this.lke_Customer.EditValue != null) customerIDSelected = Convert.ToInt32(this.lke_Customer.EditValue);
            UI.WarehouseManagement.frm_WM_EDIImportFiles frm = new frm_WM_EDIImportFiles(customerIDSelected);
            frm.ShowDialog();
            this.btn_Refresh_Click(sender, e);
        }


        private void grvEDIOrderViewList_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (e.Action != CollectionChangeAction.Remove)
                PatchSelection(sender as GridView);
        }
        void PatchSelection(GridView view)
        {
            int[] rows = view.GetSelectedRows();
            for (int i = 0; i < rows.Length; i++)
            {
                var P_Status = Convert.ToInt16(view.GetRowCellValue(rows[i], "ProcessingStatus").ToString());
                if (P_Status == 2)
                    view.UnselectRow(rows[i]);
            }
        }

        private void lke_Customer_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.KeyCode.Equals(Keys.Enter)) return;
            this.btn_Refresh_Click(sender, e);
        }

        private void grvEDIOrderViewList_RowClick(object sender, RowClickEventArgs e)
        {
            int EDI_OrderID = Convert.ToInt32(this.grvEDIOrderViewList.GetFocusedRowCellValue("EDI_OrderID"));
            if (EDI_OrderID <= 0) return;
            LoadData_EDI_OrderDetail(EDI_OrderID);

            switch (this.grvEDIOrderViewList.FocusedColumn.FieldName)
            {
                case "ProcessingOrderNumber":
                   // this.repositoryItemHyperLinkEditOrderID_Click(sender, e);
                    break;
                case "CustomerClientName":
                    this.repositoryItemHyperLinkClient_Click(sender, e);
                    break;

                case "PStatus":

                    break;
            }
            //code to apply format rules here
            //grvOrderDetai_LoadFormatRules();
        }

        private void repositoryItemHyperLinkClient_Click(object sender, EventArgs e)
        {
            frm_MSS_CustomerClients frm_Cus = new frm_MSS_CustomerClients();
            frm_Cus.Show();
            frm_Cus.WindowState = FormWindowState.Maximized;

            this.urcClient = new urc_MSS_CustomerClients();
            int customerID = Convert.ToInt32(lke_Customer.EditValue);
            DataProcess<Customers> cusDA = new DataProcess<Customers>();
            this.urcClient.CurrentCustomer = cusDA.Select(c => c.CustomerID == customerID).FirstOrDefault();
            this.urcClient.Parent = frm_Cus;
        }

        private void btnViewSummaryDetails_Click(object sender, EventArgs e)
        {
            string ReportDate = dateEditFromDate.DateTime.Date.ToString("yyyy-MM-dd");
            this.gridControl_EDIDetail.DataSource = FileProcess.LoadTable("STEDI_DetailSummary '" + ReportDate + "'," + this.lke_Customer.EditValue);
        }

        private void btnEDIRoutePlanning_Click(object sender, EventArgs e)
        {
            string ReportDate = dateEditFromDate.DateTime.Date.ToString("yyyy-MM-dd");
            frm_WM_EDIRoutePlanning frm = new frm_WM_EDIRoutePlanning(ReportDate, Convert.ToInt32(this.lke_Customer.EditValue));
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
        }

        private void grvEDIOrderDetailsView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int EDI_OrderID = Convert.ToInt32(this.grvEDIOrderViewList.GetFocusedRowCellValue("EDI_OrderID"));
            int p_CustomerID = Convert.ToInt32(lke_Customer.EditValue);
            DataProcess<Customers> cus = new DataProcess<Customers>();
            int cusType = Convert.ToInt32(cus.Select(n => n.CustomerID == p_CustomerID).FirstOrDefault().CustomerDispatchType);
            if (e.RowHandle < 0) return;
            if (this.lke_Customer.EditValue == null) return;
            if (e.Column.FieldName.Equals("ExpiryDate"))
            {
                if (cusType == 8)
                {
                    XtraMessageBox.Show("Dispath Tpye = 8 !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    if (EDI_OrderID <= 0) return;
                    LoadData_EDI_OrderDetail(EDI_OrderID);
                    return;
                }
                var view = sender as GridView;
                var currentEDIDetails = this.ediDetailsSource[e.RowHandle];
                DataProcess<object> dataProcess = new DataProcess<object>();
                dataProcess.ExecuteNoQuery("STEDI_ExpiryDateUpdate @EDI_OrderDetailID={0},@OldExpDate={1},@NewExpDate={2},@CustomerID={3},@ReportDate={4},@ProductNumber={5}",
                    currentEDIDetails.EDI_OrderDetailID, view.ActiveEditor.OldEditValue, currentEDIDetails.ExpiryDate,
                    this.lke_Customer.EditValue, this.dateEditToDate.DateTime, currentEDIDetails.ProductNumber);
                XtraMessageBox.Show("The expiry date is changed !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (e.Column.FieldName.Equals("CustomerRef"))
            {
                if (cusType != 8)
                {
                    XtraMessageBox.Show("Dispath Tpye = 8 !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (EDI_OrderID <= 0) return;
                    LoadData_EDI_OrderDetail(EDI_OrderID);
                    return;
                }
                var view = sender as GridView;
                var currentEDIDetails = this.ediDetailsSource[e.RowHandle];
                DataProcess<object> dataProcess = new DataProcess<object>();

                int result = dataProcess.ExecuteNoQuery("Update EDI_OrderDetails set CustomerRef={0}  where EDI_OrderDetailID={1}",
                     grvEDIOrderDetailsView.GetFocusedRowCellValue("CustomerRef"), grvEDIOrderDetailsView.GetFocusedRowCellValue("EDI_OrderDetailID"));
                if (result > 0)
                {
                    XtraMessageBox.Show("The Customer Reference is changed !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    XtraMessageBox.Show("The Customer Reference not changed !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            else
            {
                return;
            }


        }


        private void grvEDIOrderViewList_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.Column == null || e.HitInfo.InRow == false) return;
            this.popupOptionsCell.ShowPopup(Control.MousePosition);
        }

        private void btnSelectedAllDocumentChecked_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dataSource = (DataTable)this.grdEDIOrderList.DataSource;
            var rowsLookup = dataSource.Select("CheckDocument=1");
            if (rowsLookup == null) return;
            if (rowsLookup.Count() > 0)
            {
                // Found customer order
                for (int i = 0; i < rowsLookup.Count(); i++)
                {
                    int indexSelected = dataSource.Rows.IndexOf(rowsLookup[i]);
                    this.grvEDIOrderViewList.SelectRow(indexSelected);
                }
            }
        }


        private void btnDeleteEDIDetails_Click(object sender, EventArgs e)
        {

            string autoEDI_Customers = "1320,1756,2419,1310,2180,1965";
            if (autoEDI_Customers.Contains(this.lke_Customer.EditValue.ToString()))
            {
                return;
            }

            string ProcessingOrderNumber = grvEDIOrderViewList.GetFocusedRowCellValue("ProcessingOrderNumber").ToString();

            if (ProcessingOrderNumber != null)
            {
                if (this.grvEDIOrderDetailsView.RowCount <= 0) return;
                var dl = MessageBox.Show("Are you sure to delete this EDI?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dl.Equals(DialogResult.No)) return;

                int ediID = Convert.ToInt32(this.grvEDIOrderViewList.GetRowCellValue(this.grvEDIOrderViewList.FocusedRowHandle, "EDI_OrderID"));
                int ediDetailID = Convert.ToInt32(this.grvEDIOrderDetailsView.GetRowCellValue(this.grvEDIOrderDetailsView.FocusedRowHandle, "EDI_OrderDetailID"));

                // Delete EDI details
                DataProcess<EDI_OrderDetails> eidDetailsDA = new DataProcess<EDI_OrderDetails>();
                eidDetailsDA.ExecuteNoQuery(" Delete EDI_OrderDetails Where EDI_OrderDetailID={0}", ediDetailID);
                LoadData_EDI_OrderDetail(ediID);
            }
            else
            {
                MessageBox.Show("Can not delete Orders with exisiting Processing Order Number", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeleteEDI_Click(object sender, EventArgs e)
        {
            string autoEDI_Customers = "1320,1756,2419,1310,2180,1965";
            if (autoEDI_Customers.Contains(this.lke_Customer.EditValue.ToString()))
            {
                return;
            }
            if (this.grvEDIOrderViewList.RowCount <= 0) return;
            string ProcessingOrderNumber = "";
            int ediID = 0;
            string v_EDIOrderType = string.Empty;
            foreach (var index in this.grvEDIOrderViewList.GetSelectedRows())
            {
                ProcessingOrderNumber = this.grvEDIOrderViewList.GetRowCellDisplayText(index, "ProcessingOrderNumber").ToString();
                if (ProcessingOrderNumber != null)
                {
                    var dl = MessageBox.Show("Are you sure to delete the EDI Orders " + ediID + " ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dl.Equals(DialogResult.No))
                    {
                        this.btn_Refresh_Click(sender, e);
                        return;
                    }

                    ediID = Convert.ToInt32(this.grvEDIOrderViewList.GetRowCellDisplayText(index, "EDI_OrderID"));

                    // Check edi order details
                    if (this.grvEDIOrderDetailsView.RowCount > 0)
                    {
                        //var dlDetails = MessageBox.Show("This EDI have many EDI details, are you sure to delete this EDI details ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        //if (dlDetails.Equals(DialogResult.No)) return;

                        // Delete EDI details
                        DataProcess<EDI_OrderDetails> eidDetailsDA = new DataProcess<EDI_OrderDetails>();
                        eidDetailsDA.ExecuteNoQuery(" Delete EDI_OrderDetails Where EDI_OrderID={0}", ediID);
                    }
                    DataProcess<EDI_Orders> eidDA = new DataProcess<EDI_Orders>();
                    eidDA.ExecuteNoQuery(" Delete EDI_Orders Where EDI_OrderID={0}", ediID);

                }

                else
                {
                    MessageBox.Show("Processing Order Number Exists. Can not delete Orders the processed order ! EDI_OrderID =" + ediID, "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            this.btn_Refresh_Click(sender, e);
        }

        private void rpe_hle_QuantityOrders_Click(object sender, EventArgs e)
        {
            if (this.lke_Customer.EditValue == null) return;
            string dateFrom = Convert.ToDateTime(dateEditFromDate.EditValue).Date.ToString("yyyy-MM-dd");
            string dateTo = Convert.ToDateTime(dateEditToDate.EditValue).Date.ToString("yyyy-MM-dd");
            string ProductNumber = this.grvEDIOrderDetailsView.GetFocusedRowCellValue("ProductNumber").ToString();
            var ExpDateN = this.grvEDIOrderDetailsView.GetFocusedRowCellValue("ExpiryDate").ToString();
            var CustomerRefN = this.grvEDIOrderDetailsView.GetFocusedRowCellValue("CustomerRef").ToString();
            if (ExpDateN != "")
            {
                string ExpDate = Convert.ToDateTime(this.grvEDIOrderDetailsView.GetFocusedRowCellValue("ExpiryDate")).ToString("yyyy-MM-dd");
                this.grdEDIOrderList.DataSource = FileProcess.LoadTable("STEDIOrders_Filtered_CustomerRef '" + dateFrom + "','" + dateTo + "', " + this.lke_Customer.EditValue.ToString() + ",'" + ProductNumber + "',,'" + ExpDate + "'");
            }
            else
            {
                this.grdEDIOrderList.DataSource = FileProcess.LoadTable("STEDIOrders_Filtered_CustomerRef '" + dateFrom + "','" + dateTo + "', " + this.lke_Customer.EditValue.ToString() + ",'" + ProductNumber + "','" + CustomerRefN + "'");
            }


            this.layoutControlGrcOrderList.Text = "View Orders With Specific Expire Date";
        }

        private void btnSumAll_Click(object sender, EventArgs e)
        {


            string ReportDate = dateEditFromDate.DateTime.Date.ToString("yyyy-MM-dd");
            var dataSource = FileProcess.LoadTable("STEDI_DetailSummaryAll '" + ReportDate + "'," + this.lke_Customer.EditValue);
            dataSource.Columns["CustomerRef"].ReadOnly = false;
            dataSource.Columns["ExpiryDate"].ReadOnly = false;
            this.gridControl_EDIDetail.DataSource = dataSource;

            this.grdEDIOrderList.Visible = false;
        }

        private void btnOrdersWithIssues_Click(object sender, EventArgs e)
        {
            string dateFrom = Convert.ToDateTime(dateEditFromDate.EditValue).Date.ToString("yyyy-MM-dd");
            string dateTo = Convert.ToDateTime(dateEditToDate.EditValue).Date.ToString("yyyy-MM-dd");
            this.grdEDIOrderList.DataSource = FileProcess.LoadTable("STEDIOrdersWithIssues @FromDate='" + dateFrom + "',@ToDate='" + dateTo + "', @CustomerID = " + this.lke_Customer.EditValue.ToString());
        }

        private void grvEDIOrderDetailsView_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.Column == null || e.HitInfo.InRow == false) return;
            switch (e.HitInfo.Column.FieldName)
            {
                case "ProductNumber":
                    this.popupOptionsCell.ShowPopup(Control.MousePosition);
                    break;
                default:
                    break;
            }
        }
        private void mnu_btn_Copy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string productNumberSelected = this.grvEDIOrderDetailsView.GetFocusedDisplayText();
            if (string.IsNullOrEmpty(productNumberSelected)) return;
            Clipboard.Clear();
            Clipboard.SetText(productNumberSelected);
        }

        private void rpe_ted_Remarks_EditValueChanged(object sender, EventArgs e)
        {
            var txt = (DevExpress.XtraEditors.TextEdit)sender;
            DataProcess<object> eidDA = new DataProcess<object>();
            eidDA.ExecuteNoQuery("Update EDI_Orders set Remarks = N'" + txt.EditValue + "' WHERE EDI_OrderID =" + this.grvEDIOrderDetailsView.GetFocusedRowCellValue("EDI_OrderID"));
        }

        private void rpe_hle_ViewAllRelatedOrders_Click_1(object sender, EventArgs e)
        {
            if (this.lke_Customer.EditValue == null) return;
            string dateFrom = Convert.ToDateTime(dateEditFromDate.EditValue).Date.ToString("yyyy-MM-dd");
            string dateTo = Convert.ToDateTime(dateEditToDate.EditValue).Date.ToString("yyyy-MM-dd");
            string ProductNumber = this.grvEDIOrderDetailsView.GetFocusedRowCellValue("ProductNumber").ToString();
            //string ExpDate = Convert.ToDateTime(this.grvEDIOrderDetailsView.GetFocusedRowCellValue("ExpiryDate")).ToString("yyyy-MM-dd");
            this.grdEDIOrderList.DataSource = FileProcess.LoadTable("STEDIOrders_Filtered '" + dateFrom + "','" + dateTo + "', " + this.lke_Customer.EditValue.ToString() + ",'" + ProductNumber + "'");
            this.layoutControlGrcOrderList.Text = "View All Orders";
        }

        private void grvEDIOrderDetailsView_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (this.grvEDIOrderDetailsView.FocusedRowHandle < 0) return;
            // if (this.ediDetailsSource == null) return;
            string ReportDate = dateEditFromDate.DateTime.Date.ToString("yyyy-MM-dd");
            String SQL = "STEDI_CheckStock '" + this.grvEDIOrderDetailsView.GetFocusedRowCellValue("ProductNumber") + "'," + this.lke_Customer.EditValue;
            this.stockSource = FileProcess.LoadTable("STEDI_CheckStock '" + this.grvEDIOrderDetailsView.GetFocusedRowCellValue("ProductNumber") + "'," + this.lke_Customer.EditValue);
            this.grcStockOnHand.DataSource = this.stockSource;
            productID = Convert.ToInt32(this.grvEDIOrderDetailsView.GetFocusedRowCellValue("ProductID"));

        }

        private void rpe_hle_InsertNew_Click(object sender, EventArgs e)
        {
            DateTime p_expdate = DateTime.Now;
            if (Convert.ToInt32(this.grvEDIOrderDetailsView.GetFocusedRowCellValue("PStatus")) < 1)
            {
                string p_number = this.grvEDIOrderDetailsView.GetFocusedRowCellValue("ProductNumber").ToString();
                string p_name = this.grvEDIOrderDetailsView.GetFocusedRowCellValue("ProductName").ToString();
                if (!Convert.IsDBNull(grvEDIOrderDetailsView.GetFocusedRowCellValue("ExpiryDate")))
                {
                    p_expdate = Convert.ToDateTime(this.grvEDIOrderDetailsView.GetFocusedRowCellValue("ExpiryDate"));
                }
                int p_quantity = Convert.ToInt32(this.grvEDIOrderDetailsView.GetFocusedRowCellValue("Quantity"));
                int p_EDIOrderDetailID = Convert.ToInt32(this.grvEDIOrderDetailsView.GetFocusedRowCellValue("EDI_OrderDetailID"));
                int p_CustomerID = Convert.ToInt32(lke_Customer.EditValue);
                string p_Ref = Convert.ToString(this.grvEDIOrderDetailsView.GetFocusedRowCellValue("CustomerRef"));

                frm_WM_Dialog_EDIOrderDetail_InsertNew frm = new frm_WM_Dialog_EDIOrderDetail_InsertNew(p_number, p_name, p_expdate, p_quantity, p_EDIOrderDetailID, p_CustomerID, p_Ref);
                frm.ShowDialog();
                int EDI_OrderID = Convert.ToInt32(this.grvEDIOrderViewList.GetFocusedRowCellValue("EDI_OrderID"));
                if (EDI_OrderID <= 0) return;
                LoadData_EDI_OrderDetail(EDI_OrderID);
            }
            else
            {
                XtraMessageBox.Show("Can not break processed orders !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAddToWave_Click(object sender, EventArgs e)
        {
            if (this.lke_Customer.EditValue == null) return;
            if (this.grvEDIOrderViewList.SelectedRowsCount <= 0)
            {
                MessageBox.Show("Please select EDI to create Wave !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataProcess<EDI_Orders> v_Da = new DataProcess<EDI_Orders>();

            string fromDate = this.dateEditFromDate.DateTime.ToString("yyyy-MM-dd");
            string toDate = this.dateEditToDate.DateTime.ToString("yyyy-MM-dd");
            string m_userName = AppSetting.CurrentUser.LoginName;
            int v_CustomerID = Convert.ToInt32(this.lke_Customer.EditValue);

            StringBuilder orderNumber = new StringBuilder();

            int count = 0;

            if (this.grvEDIOrderViewList.SelectedRowsCount <= 0)
            {
                MessageBox.Show("Please select EDI to process!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (int rowIndex in this.grvEDIOrderViewList.GetSelectedRows())
            {
                orderNumber.Append(this.grvEDIOrderViewList.GetRowCellValue(rowIndex, "EDI_OrderID"));
                if (count < this.grvEDIOrderViewList.SelectedRowsCount - 1)
                {
                    orderNumber.Append(",");
                    count++;
                }
            }
            frmWave = new frm_WM_WavePicking("ED", orderNumber.ToString(), v_CustomerID, fromDate, toDate);


        }

        private void grvEDIOrderViewList_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            switch (e.Column.FieldName)
            {
                case "VehicleNumber":
                    {
                        int id = Convert.ToInt32(this.grvEDIOrderViewList.GetRowCellValue(e.RowHandle, "EDI_OrderID"));
                        DataProcess<object> dataProcess = new DataProcess<object>();
                        int result = dataProcess.ExecuteNoQuery("Update EDI_Orders Set VehicleNumber = N'{0}' Where EDI_OrderID = {1}", Convert.ToString(e.Value), id);
                        break;
                    }
                case "OrderDate":
                    {
                        int id = Convert.ToInt32(this.grvEDIOrderViewList.GetRowCellValue(e.RowHandle, "EDI_OrderID"));
                        string O_number = this.grvEDIOrderViewList.GetRowCellValue(e.RowHandle, "ProcessingOrderNumber").ToString();
                        if (O_number == "")
                        {
                            DataProcess<object> dataProcess = new DataProcess<object>();
                            string sql = String.Format("Update EDI_Orders Set OrderDate = N'{0}' Where EDI_OrderID = {1}", Convert.ToDateTime(e.Value).ToString("yyyy-MM-dd"), id);
                            int result = dataProcess.ExecuteNoQuery(sql);
                        }
                        else
                        {
                            MessageBox.Show("Error: EDI is processed");
                        }
                        break;
                    }
            }
        }

        private void btn_importVehicle_Click(object sender, EventArgs e)
        {
            frm_WM_ImportTripPlaning frmImport = new frm_WM_ImportTripPlaning(this.dateEditFromDate.DateTime, this.dateEditToDate.DateTime, 1);
            frmImport.ShowDialog();
        }

        private void btnDeleteDO_Click(object sender, EventArgs e)
        {
            string strEDI_OrderList = "";
            string strDO_OrderList = "";
            int count = 0;
            if (this.grvEDIOrderViewList.SelectedRowsCount == 0)
                return;
            foreach (var index in this.grvEDIOrderViewList.GetSelectedRows())
            {
                if (this.grvEDIOrderViewList.GetRowCellValue(index, "CheckDocument").ToString() == "0")
                {
                    MessageBox.Show("Orders are not marked for Cancellation ; Can not Delete / UnAccept Orders", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                strEDI_OrderList += grvEDIOrderViewList.GetRowCellValue(index, "EDI_OrderID");
                strDO_OrderList += grvEDIOrderViewList.GetRowCellValue(index, "ProcessedOrderNumber");
                if (count < this.grvEDIOrderViewList.SelectedRowsCount - 1)
                {
                    strEDI_OrderList += ",";
                    strDO_OrderList += ",";
                }

                count++;
            }
            // Check if all the selected Orders are marked as CANCEL ?


            // If not returns
            // Execute code for viewing Report



            var dl = MessageBox.Show("Are you sure to DELETE ALL THE SELECTED DISPATCHING ORDERS ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dl.Equals(DialogResult.No)) return;

            //Execute code to unaccept all the DO : STEDI_DispatchingProductUnAccept
            //Execute to Delete All DO : STEDI_DispatchingOrderDelete

            DA.DataProcess<object> DP = new DataProcess<object>();
            int v_Ret = DP.ExecuteNoQuery("STEDI_DispatchingProductUnAccept '" + strDO_OrderList + "', '" + AppSetting.CurrentUser.LoginName + "'");
            int v_Ret2 = DP.ExecuteNoQuery("STEDI_DispatchingOrderDelete '" + strDO_OrderList + "', '" + AppSetting.CurrentUser.LoginName + "' , 'Dispatching Order Cancellation'");

            string dateFrom = Convert.ToDateTime(dateEditFromDate.EditValue).Date.ToString("yyyy-MM-dd");
            string dateTo = Convert.ToDateTime(dateEditToDate.EditValue).Date.ToString("yyyy-MM-dd");
            this.grdEDIOrderList.DataSource = FileProcess.LoadTable("STEDIOrders @FromDate='" + dateFrom + "',@ToDate='" + dateTo + "', @CustomerID = " + this.lke_Customer.EditValue.ToString());

            this.btn_Refresh_Click(sender, e);

            //Code To Show form ProductChecking


        }

        private void btn_FilterOrderCancel_Click(object sender, EventArgs e)
        {
            string dateFrom = Convert.ToDateTime(dateEditFromDate.EditValue).Date.ToString("yyyy-MM-dd");
            string dateTo = Convert.ToDateTime(dateEditToDate.EditValue).Date.ToString("yyyy-MM-dd");
            this.grdEDIOrderList.DataSource = FileProcess.LoadTable("STEDIOrders @FromDate='" + dateFrom + "',@ToDate='" + dateTo + "', @CustomerID = " + this.lke_Customer.EditValue.ToString() + ", @Flag =1 ");

            this.btn_Refresh_Click(sender, e);
        }

        private void btnClearProcess_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string selectOrderNumber = this.grvEDIOrderViewList.GetFocusedDisplayText();
            string ediOrderID = this.grvEDIOrderViewList.GetFocusedRowCellValue("EDI_OrderID").ToString();
            if (string.IsNullOrEmpty(selectOrderNumber)) return;
            DataProcess<object> dataProcess = new DataProcess<object>();
            int resultProcess;
            string sql = "";
            var dl = MessageBox.Show("Are you sure to UN-PROCESS this Order " + selectOrderNumber + " ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dl.Equals(DialogResult.No)) return;

            if (selectOrderNumber.Contains("DO-"))
            {
                sql = "STEDI_UnProcessDispatchingOrder '" + selectOrderNumber + "', '" + AppSetting.CurrentUser.LoginName + "',  " + ediOrderID;
            }
            else if (selectOrderNumber.Contains("RO-"))
            {
                sql = "STEDI_UnProcessReceivingOrder '" + selectOrderNumber + "', '" + AppSetting.CurrentUser.LoginName + "', " + ediOrderID;
            }
            else if (selectOrderNumber.Contains("SC-"))
            {
                sql = "STEDI_UnProcessPalletStatusChange '" + selectOrderNumber + "', '" + AppSetting.CurrentUser.LoginName + "', " + ediOrderID;
            }

            resultProcess = dataProcess.ExecuteNoQuery(sql);

            //if (resultProcess < 0)
            //{
            //    MessageBox.Show("Un-Process Fail", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            this.btn_Refresh_Click(sender, e);
        }

        private void frm_WM_EDIOrdersViewList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                if (this.Modal)
                {
                    return;
                }
                FormCollection openforms = Application.OpenForms;
                bool isOpen = false;
                foreach (Form frms in openforms)
                {
                    if (frms.Name == "frmScanInput")
                    {
                        frms.BringToFront();
                        isOpen = true;
                    }

                }
                if (!isOpen)
                {
                    UI.Helper.frmScanInput inputDialog = new frmScanInput();
                    inputDialog.Show();
                    inputDialog.BringToFront();
                }
            }
        }

        private void btn_Process_All_Option_Click(object sender, EventArgs e)
        {

            DataProcess<EDI_Orders> v_Da = new DataProcess<EDI_Orders>();
            DateTime v_fromDate = v_Da.GetDate().AddDays(-7);
            DateTime v_toDate = v_Da.GetDate().AddDays(+7);
            DateTime v_OrderDate = DateTime.Now;
            int v_EDIOrderID = 0;
            string v_EDIOrderType = string.Empty;
            string v_EDIMethod = this.lkeDispatchType.EditValue.ToString();

            progressBarControl1.Visible = true;
            progressBarControl1.Properties.Step = 1;
            progressBarControl1.Properties.PercentView = true;
            progressBarControl1.Properties.Minimum = 0;
            progressBarControl1.Properties.Maximum = this.grvEDIOrderViewList.GetSelectedRows().Length;

            foreach (var index in this.grvEDIOrderViewList.GetSelectedRows())
            {
                try
                {
                    v_OrderDate = Convert.ToDateTime(this.grvEDIOrderViewList.GetRowCellDisplayText(index, "OrderDate"));
                }
                catch (Exception ex)
                {
                    log.Error("==> Error is unexpected");
                    log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                }

                if ((v_OrderDate > v_toDate) || (v_OrderDate < v_fromDate))
                {
                    XtraMessageBox.Show("Order date is not correct!!!", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return;
                }
                v_EDIOrderType = Convert.ToString(this.grvEDIOrderViewList.GetRowCellDisplayText(index, "OrderType"));
                if (v_EDIOrderType.Equals("DO"))
                {
                    try
                    {
                        v_EDIOrderID = Convert.ToInt32(this.grvEDIOrderViewList.GetRowCellDisplayText(index, "EDI_OrderID"));
                    }
                    catch (Exception ex)
                    {
                        log.Error("==> Error is unexpected");
                        log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                    }
                    int v_CustomerID = 0;
                    int v_CustomerMainID = 0;
                    string v_CustomerClientCode = "";
                    string v_CustomerClientName = "";
                    string v_CustomerClientAddress = "";

                    v_CustomerClientCode = Convert.ToString(this.grvEDIOrderViewList.GetRowCellValue(index, "CustomerClientCode"));
                    v_CustomerClientName = "NEW - " + v_CustomerClientCode;
                    v_CustomerClientAddress = "NEW Address - " + v_CustomerClientCode;

                    try
                    {
                        v_CustomerID = Convert.ToInt32(lke_Customer.EditValue);
                    }
                    catch (Exception ex)
                    {
                        log.Error("==> Error is unexpected");
                        log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                    }


                    // NẾu chưa có Customer Clients thì process Insert Customer Client ngay
                    if (v_CustomerClientCode != "")
                    {
                        Customers cus = AppSetting.CustomerList.Where(c => c.CustomerID == v_CustomerID).FirstOrDefault();
                        v_CustomerMainID = cus.CustomerMainID;


                        DA.DataProcess<CustomerClients> v_DaCus = new DataProcess<CustomerClients>();
                        IList<CustomerClients> v_ListCusClient = v_DaCus.Select(c => c.CustomerClientCode == v_CustomerClientCode
                        && (c.CustomerID == v_CustomerMainID
                        || c.CustomerID == v_CustomerID)).ToList();
                        if (v_ListCusClient.Count <= 0)
                        {
                            DA.Warehouse.EDIOrdersDA v_daEDI = new DA.Warehouse.EDIOrdersDA();
                            ObjectParameter v_newCustomerClientID = new ObjectParameter("newCustomerClientID", 0);
                            int result = v_daEDI.STCustomerClientsInsert(v_CustomerID, v_CustomerClientCode, v_CustomerClientName, v_CustomerClientAddress, AppSetting.CurrentUser.LoginName, v_newCustomerClientID);

                        }
                    }

                    DataProcess<object> dataProcess = new DataProcess<object>();

                    int resultProcess;
                    string strSQL = "";
                    if (this.checkCrossDock.Checked)
                        strSQL = "STEDI_ProcessDispatchingOrder_CrossDock " + v_EDIOrderID + ",'" + AppSetting.CurrentUser.LoginName + "'";
                    else
                        strSQL = "STEDI_ProcessDispatchingOrder_Method " + v_EDIOrderID + ",'" + AppSetting.CurrentUser.LoginName + "'," +
                        v_EDIMethod + "," + this.checkCustomerMain.EditValue;

                    resultProcess = dataProcess.ExecuteNoQuery(strSQL);
                    if (resultProcess < 0)
                    {
                        //MessageBox.Show("Process Fail", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        refreshMainGrid();
                        //return;
                    }

                }
                else if (v_EDIOrderType.Equals("RO"))
                {
                    try
                    {
                        v_EDIOrderID = Convert.ToInt32(this.grvEDIOrderViewList.GetRowCellDisplayText(index, "EDI_OrderID"));
                    }
                    catch (Exception ex)
                    {
                        log.Error("==> Error is unexpected");
                        log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                    }
                    DA.DataProcess<object> DP = new DataProcess<object>();
                    int v_Ret;
                    if (this.checkCustomerMain.Checked)

                        v_Ret = DP.ExecuteNoQuery("STEDI_ProcessReceivingOrderMain " + v_EDIOrderID + ", '" + AppSetting.CurrentUser.LoginName + "'");
                    else
                        v_Ret = DP.ExecuteNoQuery("STEDI_ProcessReceivingOrder_1Account " + v_EDIOrderID + ", '" + AppSetting.CurrentUser.LoginName + "'");
                }
                else if (v_EDIOrderType.Equals("SC"))
                {
                    DA.Warehouse.EDIOrdersDA v_DaRO = new EDIOrdersDA();
                    int v_Ret = v_DaRO.STEDI_ProcessReceivingOrder(v_EDIOrderID, AppSetting.CurrentUser.LoginName);
                }
                progressBarControl1.PerformStep();
                progressBarControl1.Update();
            }

            // Tommy 2022-04-13 : complete loop; then refresh the grid. This would be more correct ?????
            refreshMainGrid();
        }

        //private void grvEDIOrderDetailsView_RowCellStyle(object sender, RowCellStyleEventArgs e)
        //{
        //    //int status = Convert.ToInt32(this.grvEDIOrderDetailsView.GetRowCellValue(e.RowHandle, "Status"));
        //    //switch (status)
        //    //{
        //    //    case 3:
        //    //        e.Appearance.ForeColor = Color.Red;
        //    //        break;
        //    //    case 1:
        //    //        e.Appearance.ForeColor = Color.Blue;
        //    //        break;
        //    //    case 2:
        //    //        e.Appearance.ForeColor = Color.FromArgb(0, 192, 0);
        //    //        break;
        //    //    default:
        //    //        e.Appearance.ForeColor = Color.Black;
        //    //        break;
        //    //}
        //}

        private void btnPlus_Click(object sender, EventArgs e)
        {
            dateEditFromDate.DateTime = dateEditFromDate.DateTime.AddDays(1);
            dateEditToDate.DateTime = dateEditToDate.DateTime.AddDays(1);
            refreshMainGrid();
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            dateEditFromDate.DateTime = dateEditFromDate.DateTime.AddDays(-1);
            dateEditToDate.DateTime = dateEditToDate.DateTime.AddDays(-1);
            refreshMainGrid();
        }
    }
}
