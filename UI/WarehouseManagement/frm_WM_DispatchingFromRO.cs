using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Linq;
using DA;
using Microsoft.VisualBasic;
using UI.Helper;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_DispatchingFromRO : Common.Controls.frmBaseForm
    {
        DataProcess<DispatchingProducts> DP = new DataProcess<DispatchingProducts>();
        DataProcess<DispatchingOrders> DO = new DataProcess<DispatchingOrders>();
        DataProcess<ST_WMS_ExportROToDO_Result> exportRO = new DataProcess<ST_WMS_ExportROToDO_Result>();
        IList<ST_WMS_ExportROToDO_Result> newExport;
        //string datenow = DateTime.Now.to
        DateTime RODate = DateTime.Now;
        int customerID = 0;
        int receivingID = 0;
        string specialRQ = "";
        string customerNumber = "";
        string customerType = "";
        int dispatchingOrderID = 0;
        private bool isShowDispatching = false;
        public frm_WM_DispatchingFromRO(IList<ST_WMS_ExportROToDO_Result> export, int cusID, DateTime RoDate, int receiving, string specialRequirement, string cusNumber, string cusType)
        {
            InitializeComponent();

            grdRODetailExport.DataSource = export;
            newExport = export;
            RODate = RoDate;
            customerID = cusID;
            receivingID = receiving;
            specialRQ = specialRequirement;
            customerNumber = cusNumber;
            customerType = cusType;
            this.radgOption.EditValue = true;
            this.lk_DO.Enabled = false;
            loadCustomerList();
        }
        public int DispatchingOrderID { get; private set; }
        private void grbChecked_EditValueChanged(object sender, EventArgs e)
        {
            bool checkValue = (bool)this.radgOption.EditValue;
            if (checkValue)
            {
                this.lk_DO.Enabled = false;
                this.lk_DO.Properties.DataSource = null;
                grdRODetailExport.DataSource = newExport;
            }
            else
            {
                this.lk_DO.Enabled = true;
                DateTime fromDate = DO.GetDate();
                this.lk_DO.Properties.DataSource = FileProcess.LoadTable("SELECT DispatchingOrders.DispatchingOrderID, DispatchingOrders.DispatchingOrderNumber," +
                                                         " DispatchingOrders.DispatchingOrderDate, DispatchingOrders.SpecialRequirement," +
                                                         " DispatchingOrders.CustomerID, DispatchingOrders.Status" +
                                                         " FROM DispatchingOrders" +
                                                         " WHERE DispatchingOrders.DispatchingOrderDate>='" + fromDate.ToString("yyyy-MM-dd") + "' AND DispatchingOrders.CustomerID=" + customerID + " AND DispatchingOrders.Status=0" +
                                                         " ORDER BY DispatchingOrders.DispatchingOrderNumber");
                this.lk_DO.Properties.ValueMember = "DispatchingOrderID";
                this.lk_DO.Properties.DisplayMember = "DispatchingOrderNumber";
                Init_Status();
                // get values lkExisting

            }
        }
        private void loadCustomerList()
        {
            lk_Customer.Properties.DataSource = AppSetting.CustomerList.Where(a => a.CustomerDiscontinued == false).OrderBy(b => b.CustomerNumber);
            lk_Customer.Properties.ValueMember = "CustomerID";
            lk_Customer.Properties.DisplayMember = "CustomerNumber";
            lk_Customer.EditValue = this.customerID;
        }
        /// <summary>
        /// Get state
        /// </summary>
        public bool IsShowDispatching
        {
            get
            {
                return this.isShowDispatching;
            }
        }

        private void Init_Status()
        {
            using (var source = new System.Data.DataTable())
            {
                // Create column
                source.Columns.Add("ID", typeof(int));
                source.Columns.Add("Status", typeof(string));

                // Create row
                var row1 = source.NewRow();
                var row2 = source.NewRow();
                var row3 = source.NewRow();
                // Set data
                row1["ID"] = 0;
                row1["Status"] = "Normal";

                row2["ID"] = 1;
                row2["Status"] = "Waiting";

                row3["ID"] = 2;
                row3["Status"] = "Confirmed";

                // Add row
                source.Rows.Add(row1);
                source.Rows.Add(row2);
                source.Rows.Add(row3);

                this.lkeStatus.DataSource = source;
                this.lkeStatus.ValueMember = "ID";
                this.lkeStatus.DisplayMember = "Status";
            }
        }

        private void btnSelectAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            newExport = (IList<ST_WMS_ExportROToDO_Result>)this.grdRODetailExport.DataSource;
            foreach (var item in newExport)
            {
                item.DispatchingQuantity = item.Qty;
                item.CheckDispatched = true;
            }
            //exportRO.Update(newExport.ToArray());
            this.grdRODetailExport.DataSource = null;
            this.grdRODetailExport.DataSource = newExport;
        }

        private void btnLabelling_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_WM_InputCheckingDate frmInput = new frm_WM_InputCheckingDate();
            if (!frmInput.Enabled) return;
            frmInput.ShowDialog();
            if (!string.IsNullOrEmpty(frmInput.MyString))
            {
                DataProcess<object> obj = new DataProcess<object>();
                int result = obj.ExecuteNoQuery("STQualityCheckingExportProcess @Flag={0}, @OrderID={1}, @ReportDate={2}, @CreatedBy={3}", 1, receivingID, RODate, AppSetting.CurrentUser.LoginName);

            }
            frm_WM_QualityCheckings frm = new frm_WM_QualityCheckings();
            frm.Show();
        }

        private void btnAddExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DispatchingOrders newDO = new DispatchingOrders();
            bool checkValue = (bool)this.radgOption.EditValue;
            if (checkValue)
            {
                double totalDP = Convert.ToDouble(this.gridColumn6.SummaryItem.SummaryValue);
                if (totalDP <= 0)
                {
                    MessageBox.Show("Can not process, quantity is 0 !");
                    return;
                }
                newDO.CustomerID = customerID;
                if (newDO.CustomerID <= 0)
                {
                    MessageBox.Show("Lỗi rồi ['CustomerID<=0'], dừng lại và gọi ngay IT xem trường hợp này", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                newDO.DispatchingOrderDate = DateTime.Now.Date;
                newDO.SpecialRequirement = "CHUYEN RO-" + receivingID + "(" + specialRQ + ")";
                newDO.CustomerNumber = customerNumber;
                newDO.Owner = AppSetting.CurrentUser.LoginName;
                newDO.DispatchingCreatedTime = (DateTime)DateTime.Now.Date;
                newDO.DispatchingOrderNumber = "DO-";
                DataProcess<DispatchingOrders> dispatchingOrderDA = new DataProcess<DispatchingOrders>();
                dispatchingOrderDA.Insert(newDO);
                //  newDO = dispatchingOrderDA.Select().FirstOrDefault();
                newDO.DispatchingOrderNumber = "DO-" + newDO.DispatchingOrderID.ToString();
                dispatchingOrderID = newDO.DispatchingOrderID;
                ProcessDispatching(dispatchingOrderID);
                this.DispatchingOrderID = dispatchingOrderID;
            }
            else
            {
                if (this.lk_DO.Properties.DataSource == null)
                    return;
                dispatchingOrderID = Convert.ToInt32(this.lk_DO.EditValue);
                ProcessDispatching(dispatchingOrderID);
                this.DispatchingOrderID = dispatchingOrderID;
            }
            this.isShowDispatching = true;
            newDO = null;
            this.Close();
        }
        private void ProcessDispatching(int DispatchingOrderID)
        {
            newExport = (IList<ST_WMS_ExportROToDO_Result>)this.grdRODetailExport.DataSource;
            if (grvRODetailExport.RowCount > 0)
            {
                DataProcess<object> obj = new DataProcess<object>();
                IList<ST_WMS_ExportROToDO_Result> tmpDispatchingProductNew = newExport.Where(ne => ne.CheckDispatched).ToArray();
                foreach (var item in tmpDispatchingProductNew)
                {
                    if (item.CustomerRef == null)
                    {
                        item.CustomerRef = "-";
                    }
                    if (customerType == CustomerTypeEnum.RANDOM_WEIGHT)
                    {
                        int resultIf = obj.ExecuteNoQuery("STDispatchingProductInsertRandomWeight @varDispatchingOrderID={0}, @varProductID={1},"
                            + " @varTotalQuantity={2}, @varWeightPerPackage={3}, @varDispatchingOrderNumer={4}, @varCondition={5},"
                            + " @DispatchingMethod={6}, @DispatchingProductRemark={7}, @DispatchingProductReference={8},"
                            + " @UserID={9}", DispatchingOrderID, item.ProductID, item.DispatchingQuantity, item.WeightPerPackage,
                            "DO-" + DispatchingOrderID.ToString(), "(" + item.ReceivingOrderDetailID.ToString() + ")", "False", "-", item.CustomerRef, AppSetting.CurrentUser.LoginName);
                    }
                    else
                    {
                        int resultElse = obj.ExecuteNoQuery("STDispatchingProductInsert_New @varDispatchingOrderID={0}, @varProductID={1},"
                            + " @varTotalQuantity={2}, @varWeightPerPackage={3}, @varDispatchingOrderNumer={4}, @varCondition={5},"
                            + " @DispatchingMethod={6}, @DispatchingProductRemark={7}, @DispatchingProductReference={8}, @UserID={9}",
                            DispatchingOrderID, item.ProductID, item.DispatchingQuantity, item.WeightPerPackage,
                            "DO-" + DispatchingOrderID.ToString(), "(" + item.ReceivingOrderDetailID.ToString() + ")", "False", "-",
                            item.CustomerRef, AppSetting.CurrentUser.LoginName);
                    }
                }
            }
        }

        private void barEditItem6_EditValueChanged(object sender, EventArgs e)
        {
            dispatchingOrderID = Convert.ToInt32(this.lk_DO.EditValue);
            var resultDP = DP.Select(dp => dp.DispatchingOrderID == dispatchingOrderID);
            if (resultDP != null)
                grdRODetailImport.DataSource = resultDP;
        }

        private void grvRODetailExport_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName.Equals("CheckDispatched"))
            {
                string CheckDispatched = grvRODetailExport.GetRowCellValue(e.RowHandle, "CheckDispatched").ToString();
                string abc = this.grvRODetailExport.GetRowCellValue(e.RowHandle, "Qty").ToString();
                if (CheckDispatched == "False")
                {
                    this.grvRODetailExport.SetRowCellValue(e.RowHandle, "CheckDispatched", true);
                    this.grvRODetailExport.SetRowCellValue(e.RowHandle, "DispatchingQuantity", abc);
                }
                else
                {
                    this.grvRODetailExport.SetRowCellValue(e.RowHandle, "CheckDispatched", false);
                    this.grvRODetailExport.SetRowCellValue(e.RowHandle, "DispatchingQuantity", "");
                }
                this.grvRODetailExport.UpdateSummary();
            }
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void grvRODetailExport_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var dispatchingQTY = this.grvRODetailExport.GetFocusedRowCellValue("DispatchingQuantity");
            if (dispatchingQTY == null) return;
            int qty = (int)this.grvRODetailExport.GetFocusedRowCellValue("Qty");
            if ((int)dispatchingQTY > qty || (int)dispatchingQTY < 1)
            {
                MessageBox.Show(this, "Dispatching quantity is invalid", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.grvRODetailExport.SetFocusedRowCellValue("DispatchingQuantity", qty);
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Export_Click(object sender, EventArgs e)
        {
            DispatchingOrders newDO = new DispatchingOrders();
            bool checkValue = (bool)this.radgOption.EditValue;
            if (checkValue)
            {
                double totalDP = Convert.ToDouble(this.gridColumn6.SummaryItem.SummaryValue);
                if (totalDP <= 0)
                {
                    MessageBox.Show("Can not process, quantity is 0 !");
                    return;
                }
                newDO.CustomerID = customerID;
                if (newDO.CustomerID <= 0)
                {
                    MessageBox.Show("Lỗi rồi ['CustomerID<=0'], dừng lại và gọi ngay IT xem trường hợp này", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                newDO.DispatchingOrderDate = DateTime.Now.Date;
                newDO.SpecialRequirement = "CHUYEN RO-" + receivingID + "(" + specialRQ + ")";
                newDO.CustomerNumber = customerNumber;
                newDO.Owner = AppSetting.CurrentUser.LoginName;
                //newDO.DispatchingCreatedTime = DateTime.Now.Date;
                newDO.DispatchingCreatedTime = (DateTime)DateTime.Now;
                newDO.DispatchingOrderNumber = "DO-";
                DataProcess<DispatchingOrders> dispatchingOrderDA = new DataProcess<DispatchingOrders>();
                dispatchingOrderDA.Insert(newDO);
                //  newDO = dispatchingOrderDA.Select().FirstOrDefault();
                newDO.DispatchingOrderNumber = "DO-" + newDO.DispatchingOrderID.ToString();
                dispatchingOrderID = newDO.DispatchingOrderID;
                ProcessDispatching(dispatchingOrderID);
                this.DispatchingOrderID = dispatchingOrderID;
            }
            else
            {
                if (this.lk_DO.Properties.DataSource == null)
                    return;
                dispatchingOrderID = Convert.ToInt32(this.lk_DO.EditValue);
                ProcessDispatching(dispatchingOrderID);
                this.DispatchingOrderID = dispatchingOrderID;
            }
            this.isShowDispatching = true;
            newDO = null;
            this.Close();
        }

        private void btn_Labelling_Click(object sender, EventArgs e)
        {
            frm_WM_InputCheckingDate frmInput = new frm_WM_InputCheckingDate();
            if (!frmInput.Enabled) return;
            frmInput.ShowDialog();
            if (!string.IsNullOrEmpty(frmInput.MyString))
            {
                DataProcess<object> obj = new DataProcess<object>();
                int result = obj.ExecuteNoQuery("STQualityCheckingExportProcess @Flag={0}, @OrderID={1}, @ReportDate={2}, @CreatedBy={3}", 1, receivingID, RODate, AppSetting.CurrentUser.LoginName);

            }
            frm_WM_QualityCheckings frm = new frm_WM_QualityCheckings();
            frm.Show();
        }

        private void btn_Select_All_Click(object sender, EventArgs e)
        {
            newExport = (IList<ST_WMS_ExportROToDO_Result>)this.grdRODetailExport.DataSource;
            foreach (var item in newExport)
            {
                item.DispatchingQuantity = item.Qty;
                item.CheckDispatched = true;
            }
            //exportRO.Update(newExport.ToArray());
            this.grdRODetailExport.DataSource = null;
            this.grdRODetailExport.DataSource = newExport;
        }

        private void btnDuplicateRO_Click(object sender, EventArgs e)
        {
            int newCustomerID = Convert.ToInt32(this.lk_Customer.EditValue);
            if (newCustomerID > 0)
            {
                var DX = FileProcess.LoadTable("STReceivingOrderDuplicate " + this.receivingID + ",'" + AppSetting.CurrentUser.LoginName + "'," + newCustomerID);
                if (DX == null)
                {
                    MessageBox.Show("Error Creating duplicated Receiving Order !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    int newReceivingOrderID = Convert.ToInt32(DX.Rows[0]["NewReceivingOrderID"]);
                    frm_WM_ReceivingOrders receivingOrder = frm_WM_ReceivingOrders.Instance;
                    receivingOrder.ReceivingOrderIDFind = newReceivingOrderID;
                    receivingOrder.Show();
                    receivingOrder.WindowState = FormWindowState.Maximized;
                    receivingOrder.BringToFront();
                    this.Close();

                }

            }
            else
            {
                MessageBox.Show("PLease Select The Customer to Create Duplicate of this Order !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.lk_Customer.ShowPopup();
                this.lk_Customer.Focus();
                return;
            }
        }
    }
}
