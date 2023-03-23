using Common.Controls;
using Common.Process;
using DA;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UI.Helper;
using UI.ReportFile;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_TripViewByDate : frmBaseForm
    {
        private frm_WM_TripsManagement frmTripDetail = new frm_WM_TripsManagement(0);
        private int hotTrackRow = DevExpress.XtraGrid.GridControl.InvalidRowHandle;
        private bool isAddTrip = false;
        private int tripIDSelected = 0;

        public frm_WM_TripViewByDate()
        {
            InitializeComponent();
            this.IsFixHeightScreen = false;
        }

        private int HotTrackRow
        {
            get
            {
                return hotTrackRow;
            }
            set
            {
                if (hotTrackRow != value)
                {
                    int prevHotTrackRow = hotTrackRow;
                    hotTrackRow = value;
                    gridView1.RefreshRow(prevHotTrackRow);
                    gridView1.RefreshRow(hotTrackRow);

                    if (hotTrackRow >= 0)
                        grd_WM_TripViewByDate.Cursor = Cursors.Hand;
                    else
                        grd_WM_TripViewByDate.Cursor = Cursors.Default;
                }
            }
        }

        private void frm_WM_TripViewByDate_Load(object sender, EventArgs e)
        {
            LoadDataForControl();
        }

        private void checkEditAll_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkEditAll.Checked) return;
            DisplayControl();
            FilterData();
        }

        private void checkEditMe_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkEditMe.Checked) return;
            DisplayControl();
            FilterData();
        }

        private void checkEditCustomer_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkEditCustomer.Checked) return;
            DisplayControl();
            this.lookUpEditCustomerID.ShowPopup();
            this.lookUpEditCustomerID.Focus();
            FilterData();
        }

        private void checkEditMain_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEditMain.Checked)
            {
                FilterData();
            }
        }

        private void btn_WM_Close_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btn_WM_Refresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FilterData();
        }

        private void dateEditDateFrom_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                FilterData();
            }
        }

        private void dateEditDateTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                FilterData();
            }
        }

        private void txtTripID_EditValueChanged(object sender, EventArgs e)
        {
            grv_VM_TripViewByDate.Columns["TripNumber"].FilterInfo = new ColumnFilterInfo(string.Format("[TripNumber] LIKE '{0}%'", txtTripID.Text));
        }

        private void FilterData()
        {
            Wait.Start(this);

            try
            {
                var data = new object();

                string dateFrom = Convert.ToDateTime(dateEditDateFrom.EditValue).Date.ToString("yyyy-MM-dd 00:00:00");
                string dateTo = Convert.ToDateTime(dateEditDateTo.EditValue).Date.ToString("yyyy-MM-dd 00:00:00");//yyyy-MM-dd 23:59:59//buu
                string userName = AppSetting.CurrentUser.LoginName;
                int customerID = 0;
                byte flat = 0;

                DataProcess<STTripViewByDate_Result> tripDA = new DataProcess<STTripViewByDate_Result>();

                if (checkEditAll.Checked)
                {
                    data = FileProcess.LoadTable("STTripViewByDate @FromDate = '" + dateFrom + "', @ToDate = '" + dateTo + "', @UserName = '" + userName + "', @CustomerID = " + customerID + ", @Flag = " + flat + ", @StoreID = " + AppSetting.StoreID);
                }
                else if (checkEditCustomer.Checked)
                {
                    customerID = Convert.ToInt32(lookUpEditCustomerID.EditValue);

                    if (checkEditMain.Checked)
                    {
                        flat = 5;
                    }
                    else
                    {
                        flat = 1;
                    }

                    data = FileProcess.LoadTable("STTripViewByDate @FromDate = '" + dateFrom + "', @ToDate = '" + dateTo + "', @UserName = '" + userName + "', @CustomerID = " + customerID + ", @Flag = " + flat + ", @StoreID = " + AppSetting.StoreID);
                }
                else if (checkEditMe.Checked)
                {
                    flat = 2;
                    data = FileProcess.LoadTable("STTripViewByDate @FromDate = '" + dateFrom + "', @ToDate = '" + dateTo + "', @UserName = '" + userName + "', @CustomerID = " + customerID + ", @Flag = " + flat + ", @StoreID = " + AppSetting.StoreID);
                }
                else if (checkEditMe0.Checked)
                {
                    flat = 4;
                    data = FileProcess.LoadTable("STTripViewByDate @FromDate = '" + dateFrom + "', @ToDate = '" + dateTo + "', @UserName = '" + userName + "', @CustomerID = " + customerID + ", @Flag = " + flat + ", @StoreID = " + AppSetting.StoreID);
                }

                grd_WM_TripViewByDate.DataSource = data;

            }
            catch (Exception)
            {

            }

            Wait.Close();
        }

        private void LoadRoute()
        {
            if (this.lookUpEditCustomerID.EditValue == null) return;
            int customerID = Convert.ToInt32(this.lookUpEditCustomerID.EditValue);
            this.lke_Routes.Properties.DataSource = FileProcess.LoadTable("STCustomerDeliveryRouteList " + customerID);
            this.lke_Routes.Properties.DisplayMember = "RouteDescriptions";
            this.lke_Routes.Properties.ValueMember = "CustomerDeliveryRouteID";
        }

        private void LoadDataForControl()
        {
            IEnumerable<Customers> source = AppSetting.CustomerList.Where(a => a.StoreID == AppSetting.StoreID && a.CustomerDiscontinued == false);
            if (source.Count() < 20)
            {
                lookUpEditCustomerID.Properties.DropDownRows = source.Count();
            }
            else
            {
                lookUpEditCustomerID.Properties.DropDownRows = 20;
            }
            lookUpEditCustomerID.Properties.DataSource = source;
            lookUpEditCustomerID.Properties.ValueMember = "CustomerID";
            lookUpEditCustomerID.Properties.DisplayMember = "CustomerNumber";
            if (source.Count() > 0)
                lookUpEditCustomerID.EditValue = source.ElementAt(0).CustomerID;
            lookUpEditCustomerID.Visible = false;

            dateEditDateFrom.EditValue = DateTime.Now;
            dateEditDateTo.EditValue = DateTime.Now;

            checkEditAll.Checked = true;

        }

        private void DisplayControl()
        {
            if (checkEditCustomer.Checked)
            {
                this.lookUpEditCustomerID.Visible = true;
            }
            else
            {
                this.lookUpEditCustomerID.Visible = false;
                this.lke_Routes.Enabled = false;
                this.btnNewTrip.Enabled = false;
            }
        }

        private void rpiLink_DoubleClick(object sender, EventArgs e)
        {
            int TripID = Convert.ToInt32(grv_VM_TripViewByDate.GetFocusedRowCellValue("TripID"));
            this.frmTripDetail.ReloadData(TripID);
            this.frmTripDetail.Show();
            this.frmTripDetail.TopLevel = true;
            this.frmTripDetail.WindowState = FormWindowState.Maximized;
            this.frmTripDetail.BringToFront();
            this.frmTripDetail.Focus();
        }


        private void txtTripID_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.KeyCode.Equals(Keys.Enter)) return;

            string dateFrom = Convert.ToDateTime(dateEditDateFrom.EditValue).Date.ToString("yyyy-MM-dd");
            string dateTo = Convert.ToDateTime(dateEditDateTo.EditValue).Date.ToString("yyyy-MM-dd");
            string userName = AppSetting.CurrentUser.LoginName;
            byte flat = 3;
            DataProcess<STTripViewByDate_Result> tripDA = new DataProcess<STTripViewByDate_Result>();
            var dataSource = tripDA.Executing("STTripViewByDate @FromDate={0},@ToDate={1},@UserName={2},@CustomerID={3},@Flag={4},@StoreID={5}", dateFrom, dateTo, userName, this.txtTripID.Text, flat, AppSetting.StoreID);
            grd_WM_TripViewByDate.DataSource = dataSource;
        }

        private void btn_WM_PreviousDay_ItemClick(object sender, EventArgs e)
        {
            dateEditDateFrom.EditValue = dateEditDateFrom.DateTime.AddDays(-1);
            dateEditDateTo.EditValue = dateEditDateTo.DateTime.AddDays(-1);
            this.FilterData();
        }

        private void btn_WM_NextDay_ItemClick(object sender, EventArgs e)
        {
            dateEditDateFrom.EditValue = dateEditDateFrom.DateTime.AddDays(1);
            dateEditDateTo.EditValue = dateEditDateTo.DateTime.AddDays(1);
            this.FilterData();
        }

        private void btn_WM_7Days_ItemClick(object sender, EventArgs e)
        {
            dateEditDateFrom.EditValue = Convert.ToDateTime(dateEditDateFrom.EditValue).Date.AddDays(-7);
            dateEditDateTo.EditValue = DateTime.Now;
        }

        private void btn_WM_ToDay_ItemClick(object sender, EventArgs e)
        {
            dateEditDateFrom.EditValue = DateTime.Now;
            dateEditDateTo.EditValue = DateTime.Now;
        }

        private void btn_WM_Close_ItemClick(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_WM_Refresh_ItemClick(object sender, EventArgs e)
        {
            FilterData();
        }

        private void btn_WM_TripEntry_ItemClick(object sender, EventArgs e)
        {
            this.frmTripDetail.ReloadData(0, this.dateEditDateTo.DateTime);
            this.frmTripDetail.BringToFront();
            frmTripDetail.Show();
        }

        private void checkEditMe0_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkEditMe0.Checked) return;
            DisplayControl();
            FilterData();
        }

        private void grv_VM_TripViewByDate_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            this.hotTrackRow = -1;
            if (this.grv_VM_TripViewByDate.FocusedColumn.FieldName.Equals("TripNumber"))
            {
                this.rpiLink_DoubleClick(sender, e);
            }
            else
            {
                if (this.lookUpEditCustomerID.EditValue == null || checkEditCustomer.Checked == false) return;
                int CustomerID = Convert.ToInt32(this.lookUpEditCustomerID.EditValue);
                string ReportDate = dateEditDateFrom.DateTime.Date.ToString("yyyy-MM-dd");
                string toDate = dateEditDateTo.DateTime.Date.ToString("yyyy-MM-dd");
                int TripID = Convert.ToInt32(grv_VM_TripViewByDate.GetFocusedRowCellValue("TripID"));
                this.tripIDSelected = TripID;
                this.grdDispatchinOrdersSelect.DataSource = FileProcess.LoadTable("STCustomerDeliveryRoutePlanningOrders " + CustomerID + ",'" + ReportDate + "'," + TripID + ",'" + toDate + "'");
                if (TripID > 0)
                {
                    this.btnNewTrip.Enabled = false;
                    this.isAddTrip = false;
                }
                else
                {
                    this.isAddTrip = true;
                    if (this.lke_Routes.EditValue != null) this.btnNewTrip.Enabled = true;
                }
            }
        }

        private void btnNewTrip_Click(object sender, EventArgs e)
        {
            string orders = this.GetOrderSelected();
            // Insert new trip
            int tripID = 0;
            using (var context = new SwireDBEntities())
            {
                ObjectParameter outTripID = new ObjectParameter("returnTripID", 0);
                context.STTripInsert(Convert.ToInt32(lookUpEditCustomerID.EditValue),
                    AppSetting.CurrentUser.LoginName,
                    orders,
                   Convert.ToInt32(lke_Routes.EditValue), outTripID);
                tripID = Convert.ToInt32(outTripID.Value);
            }

            // Display new trip on form
            if (tripID <= 0) return;
            this.frmTripDetail.ReloadData(tripID);
            this.frmTripDetail.BringToFront();
            this.frmTripDetail.Show();
        }

        private string GetOrderSelected()
        {
            // Get all DO selected
            StringBuilder orders = new StringBuilder();
            orders.Append("(");
            int count = 0;

            foreach (var index in this.grvDispatchingOrderSelectTableView.GetSelectedRows())
            {
                orders.Append(this.grvDispatchingOrderSelectTableView.GetRowCellValue(index, "DispatchingOrderID"));
                if (count < this.grvDispatchingOrderSelectTableView.SelectedRowsCount - 1)
                {
                    orders.Append(",");
                }
                count++;
            }
            orders.Append(")");
            return orders.ToString();
        }

        private void lke_Routes_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.Value == null)
            {
                this.btnNewTrip.Enabled = false;
                return;
            }

            this.btnNewTrip.Enabled = true;
        }

        private void lookUpEditCustomerID_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.Value == null)
            {
                this.lke_Routes.EditValue = null;
                this.lke_Routes.Enabled = false;
                return;
            }
            this.lookUpEditCustomerID.EditValue = e.Value;

            FilterData();

            // Load Route
            this.lke_Routes.Enabled = true;
            this.LoadRoute();
        }

        private void dragDropEvents2_DragDrop(object sender, DevExpress.Utils.DragDrop.DragDropEventArgs e)
        {
            DragDropGridEventArgs args = DragDropGridEventArgs.GetDragDropGridEventArgs(e);
            if (this.lookUpEditCustomerID.EditValue == null)
            {
                MessageBox.Show("Please select Customer to add new trip", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.lookUpEditCustomerID.Focus();
                this.lookUpEditCustomerID.ShowPopup();
                return;
            }

            if (this.lke_Routes.EditValue == null)
            {
                MessageBox.Show("Please select Routes to add new trip", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.lke_Routes.Focus();
                this.lke_Routes.ShowPopup();
                return;
            }

            // Get all DO selected
            string orders = this.GetOrderSelected();
            int tripIDReturn = 0;
            int tripIDAdd = Convert.ToInt32(this.grv_VM_TripViewByDate.GetRowCellValue(this.grv_VM_TripViewByDate.FocusedRowHandle, "TripID"));


            // Include the DO into current trip
            if (this.isAddTrip && tripIDAdd <= 1)
            {
                var dl = MessageBox.Show("Do you want create new Trips from this the DO?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dl.Equals(DialogResult.No))
                {
                    this.hotTrackRow = -1;
                    return;
                }

                // Add new trip
                using (var context = new SwireDBEntities())
                {
                    ObjectParameter outParam = new ObjectParameter("returnTripID", 0);
                    context.STTripInsert((int)this.lookUpEditCustomerID.EditValue, AppSetting.CurrentUser.LoginName, orders, (int)lke_Routes.EditValue, outParam);
                    tripIDReturn = (int)outParam.Value;
                    this.FilterData();
                }

                // Re-call function row cell click to refresh data DO free
                this.grv_VM_TripViewByDate.FocusedRowHandle = 0;
                this.grv_VM_TripViewByDate_RowCellClick(sender, null);
            }
            else
            {
                var dl = MessageBox.Show("Do you want to add the new DO into this Trip?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dl.Equals(DialogResult.No))
                {
                    this.hotTrackRow = -1;
                    return;
                }

                // include DO free into current trip
                DataProcess<object> process = new DataProcess<object>();
                process.ExecuteNoQuery("STTripAdd @TripID={0},@CreatedBy={1},@strOrderID={2}",
                    tripIDAdd, AppSetting.CurrentUser.LoginName, orders);

                // Change OD from this trip to other trip
                // Re-call function row cell click to refresh data DO free
                this.grv_VM_TripViewByDate_RowCellClick(sender, null);
            }

            this.hotTrackRow = -1;
            this.grv_VM_TripViewByDate.FocusedRowHandle = -1;
        }

        private void dragDropEvents2_DragOver(object sender, DevExpress.Utils.DragDrop.DragOverEventArgs e)
        {
            DragOverGridEventArgs args = DragOverGridEventArgs.GetDragOverGridEventArgs(e);
            args.Action = DevExpress.Utils.DragDrop.DragDropActions.Copy;
            e.Action = args.Action;
            if (args.HitInfo.RowInfo == null) return;
            this.grv_VM_TripViewByDate.FocusedRowHandle = args.HitInfo.RowHandle;
            this.HotTrackRow = args.HitInfo.RowHandle;
        }

        private void dragDropEvents1_DragOver(object sender, DevExpress.Utils.DragDrop.DragOverEventArgs e)
        {
            DragOverGridEventArgs args = DragOverGridEventArgs.GetDragOverGridEventArgs(e);
            args.Action = DevExpress.Utils.DragDrop.DragDropActions.Copy;
            e.Action = args.Action;
        }

        //private void grv_VM_TripViewByDate_RowCellStyle(object sender, RowCellStyleEventArgs e)
        //{
        //    if (e.RowHandle == HotTrackRow)
        //        e.Appearance.BackColor = Color.PaleGoldenrod;
        //}

        private void repositoryItemHyperLinkEditDispatchingOrderID_Click(object sender, EventArgs e)
        {
            string orderNo = Convert.ToString(this.grvDispatchingOrderSelectTableView.GetFocusedRowCellValue("DispatchingOrderNumber"));
            if (string.IsNullOrEmpty(orderNo)) return;
            string orderNumber = orderNo.Substring(0, 2);
            int orderID = Convert.ToInt32(this.grvDispatchingOrderSelectTableView.GetFocusedRowCellValue("DispatchingOrderID"));
            if (orderNumber.ToUpper().Equals("DO"))
            {
                // Display disptching order
                frm_WM_DispatchingOrders dispatchingOrder = frm_WM_DispatchingOrders.GetInstance(orderID);
                if (dispatchingOrder.Visible)
                {
                    dispatchingOrder.ReloadData();
                }
                dispatchingOrder.WindowState = FormWindowState.Maximized;
                dispatchingOrder.BringToFront();
                dispatchingOrder.Show();
            }
        }

        private void btn_Deit_TripDetsails_Click(object sender, EventArgs e)
        {
            //Expand the Grid TripDetails to full Screen 


            //View all the columns that are visible = false  --> true


            //Click to edit columns: TripDetailRemark, TripStatus, ExpectedDeliveryTime, CashCollectionAmount, IsRejected, RejectedOrderNumber, RejectedRemark




        }

        private void grv_VM_TripViewByDate_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            frm_WM_ImportTripPlaning frmImport = new frm_WM_ImportTripPlaning(this.dateEditDateFrom.DateTime, this.dateEditDateTo.DateTime);
            frmImport.ShowDialog();
            this.checkEditMe.Checked = true;
        }

        private void grd_WM_TripViewByDate_Click(object sender, EventArgs e)
        {

        }

        private void btnDeliNotes_Click(object sender, EventArgs e)
        {

        }

        private void btnCombinedNotes_Click(object sender, EventArgs e)
        {

        }

        private void btnMultiNote_Click(object sender, EventArgs e)
        {

        }

        private void btnMultiPlans_Click(object sender, EventArgs e)
        {
            this.printMultiPlan(true);
        }

        private void printMultiPlan(bool isPreview)
        {
            // Get tripID selected
            int tripID = Convert.ToInt32(this.grv_VM_TripViewByDate.GetRowCellValue(this.grv_VM_TripViewByDate.FocusedRowHandle, "TripID"));

            DataProcess<ST_WMS_LoadTripsManagement_Result> tripManagementDA = new DataProcess<ST_WMS_LoadTripsManagement_Result>();
            DataProcess<ST_WMS_LoadTripManagementDetails_Result> tripDetailsDA = new DataProcess<ST_WMS_LoadTripManagementDetails_Result>();

            var currentTrip = tripManagementDA.Executing("ST_WMS_LoadTripsManagement @TripDate = {0}, @TripID = {1}", DateTime.Now.AddDays(-10), tripID).FirstOrDefault();
            var tripDetailsList = (IList<ST_WMS_LoadTripManagementDetails_Result>)tripDetailsDA.Executing("ST_WMS_LoadTripManagementDetails @TripID={0}", currentTrip.TripID);

            tripDetailsList.Add(new ST_WMS_LoadTripManagementDetails_Result());
            if (currentTrip.TripID <= 0)
                MessageBox.Show("An error was encountered. Please return to the close form and try again.", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (tripDetailsList.Count() == 0)
                MessageBox.Show("No data. Please enter details!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                IList<ST_WMS_LoadTripManagementDetails_Result> TripDetailsOrderByOrderNumber = tripDetailsList.OrderBy(TripDetails => TripDetails.OrderNumber).ToList();
                TripDetailsOrderByOrderNumber.Remove(TripDetailsOrderByOrderNumber.FirstOrDefault());
                foreach (ST_WMS_LoadTripManagementDetails_Result element in TripDetailsOrderByOrderNumber)
                {
                    if (element.OrderNumber.Substring(0, 2).ToUpper() == "DO")
                    {
                        int DispatchingOrderID = int.Parse(element.OrderNumber.Substring(3));

                        using (SwireDBEntities db = new SwireDBEntities())
                        {
                            var Result = new object();
                            Result = FileProcess.LoadTable("STDispatchingPlanReportNew @varDispatchingOrderID=" + DispatchingOrderID);
                            DataProcess<STCustomerRequirementPrint_Result> cusRequireDA = new DataProcess<STCustomerRequirementPrint_Result>();
                            DataTable customerRequired = FileProcess.LoadTable("STCustomerRequirementPrint @CustomerMainID=" + currentTrip.CustomerMainID + ",@Flag=2, @ReceivingOrderID=null");
                            string customerRequire = "";
                            string CustomerType = AppSetting.CustomerList.Where(Customer => Customer.CustomerID == currentTrip.CustomerID).SingleOrDefault().CustomerType;
                            foreach (DataRow row in customerRequired.Rows)
                            {
                                customerRequire += row["RequirementDetails"].ToString();
                            }
                            if (CustomerType == CustomerTypeEnum.RANDOM_WEIGHT)
                            {

                                rptDispatchingPlanA4New dPlanA4 = new rptDispatchingPlanA4New();
                                dPlanA4.DataSource = Result;
                                if (customerRequired != null)
                                {
                                    dPlanA4.Parameters["varCustomerRequired"].Value = customerRequire;
                                }
                                dPlanA4.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
                                dPlanA4.xrPalletID.Visible = true;
                                dPlanA4.xrKgs.Visible = false;
                                dPlanA4.xrUnit.Visible = true;
                                dPlanA4.xrWeight.Visible = true;
                                dPlanA4.xrCtnPcs.Visible = true;
                                dPlanA4.xrPro_.Visible = false;
                                dPlanA4.xrExp.Visible = false;
                                dPlanA4.xrTon.Visible = false;
                                dPlanA4.xrSoLuong.Visible = false;
                                dPlanA4.xrhCtn.Visible = true;
                                dPlanA4.xrhUn.Visible = true;
                                // hide group header
                                dPlanA4.xrhSumPalletWeight.Visible = true;
                                dPlanA4.xrhSumUnitQty.Visible = true;
                                dPlanA4.xrhWeigth.Visible = false;
                                // visible ctn
                                dPlanA4.xrhKgCtn.Visible = true;
                                dPlanA4.xrhWeightPerPackage.Visible = false;
                                // dPlanA4.xrhUseByDate.Visible = false;
                                dPlanA4.xrhSumWeightPerPackage.Visible = false;
                                // show colum detail
                                dPlanA4.xrdQtyPackageModInner.Visible = false;
                                dPlanA4.xrdQtyPackageQuotieInner.Visible = false;
                                dPlanA4.xrdPalletWeight.Visible = true;
                                dPlanA4.xrdPalletWeightAvg.Visible = true;
                                dPlanA4.xrdProductDate.Visible = true;
                                dPlanA4.xrdUseByDate.Visible = true;
                                dPlanA4.xrhTon.Visible = true;
                                dPlanA4.xrdUnitQty.Visible = true;
                                dPlanA4.xrhWeigth.Visible = true;
                                dPlanA4.xrhWeightPerPackage.Visible = false;
                                dPlanA4.xrLine40.Visible = false;
                                dPlanA4.xrnhietDo.Visible = false;
                                dPlanA4.xrTemperature.Visible = false;
                                dPlanA4.xrhRemain.Visible = false;
                                dPlanA4.xrLine39.Visible = false;
                                dPlanA4.xrhKgs.Visible = true;
                                // rename text
                                dPlanA4.xrCtnPcs.Text = "Ctn";

                                // move postion and resize xrh & xrd
                                dPlanA4.xrhKgCtn.LocationF = new PointF(dPlanA4.xrhKgCtn.LocationF.X + 20, dPlanA4.xrhKgCtn.LocationF.Y);
                                dPlanA4.xrUnit.LocationF = new PointF(dPlanA4.xrUnit.LocationF.X + 100, dPlanA4.xrUnit.LocationF.Y);
                                dPlanA4.xrExp.LocationF = new PointF(dPlanA4.xrExp.LocationF.X + 30, dPlanA4.xrExp.LocationF.Y);
                                dPlanA4.xrCtnPcs.LocationF = new PointF(dPlanA4.xrCtnPcs.LocationF.X - 20, dPlanA4.xrCtnPcs.LocationF.Y);
                                dPlanA4.xrPalletID.LocationF = new PointF(dPlanA4.xrPalletID.LocationF.X + 50, dPlanA4.xrPalletID.LocationF.Y);
                                dPlanA4.xrWeight.LocationF = new PointF(dPlanA4.xrWeight.LocationF.X + 130, dPlanA4.xrWeight.LocationF.Y);
                                dPlanA4.xrdPalletWeight.LocationF = new PointF(dPlanA4.xrdPalletWeight.LocationF.X + 30, dPlanA4.xrdPalletWeight.LocationF.Y);
                                dPlanA4.xrdDispatchingLocationRemark.WidthF = 150F;

                                dPlanA4.xrdQtyPackageModInner.LocationF = new PointF(dPlanA4.xrdQtyPackageModInner.LocationF.X + 20, dPlanA4.xrdQtyPackageModInner.LocationF.Y);
                                dPlanA4.xrdQtyPackageQuotieInner.LocationF = new PointF(dPlanA4.xrdQtyPackageQuotieInner.LocationF.X + 20, dPlanA4.xrdQtyPackageQuotieInner.LocationF.Y);

                                //product date, usebydate
                                dPlanA4.xrdProductDate.LocationF = new PointF(dPlanA4.xrdProductDate.LocationF.X + 140, dPlanA4.xrdProductDate.LocationF.Y);
                                dPlanA4.xrdUseByDate.LocationF = new PointF(dPlanA4.xrdProductDate.LocationF.X + 60, dPlanA4.xrdProductDate.LocationF.Y);

                                dPlanA4.xrProductName.WidthF = 250F;
                                dPlanA4.xrProductName.LocationF = new PointF(dPlanA4.xrProductName.LocationF.X - 10, dPlanA4.xrProductName.LocationF.Y);
                                dPlanA4.xrdPalletID.LocationF = new PointF(dPlanA4.xrdPalletID.LocationF.X + 50, dPlanA4.xrdPalletID.LocationF.Y);


                                dPlanA4.xrhCtn.LocationF = new PointF(dPlanA4.xrhCtn.LocationF.X - 70, dPlanA4.xrhCtn.LocationF.Y);
                                dPlanA4.xrhSumUnitQty.WidthF = dPlanA4.xrhSumUnitQty.WidthF + 10;
                                dPlanA4.xrhSumUnitQty.LocationF = new PointF(dPlanA4.xrhSumUnitQty.LocationF.X - 70, dPlanA4.xrhSumUnitQty.LocationF.Y);
                                dPlanA4.xrhWeightPPackage.LocationF = new PointF(dPlanA4.xrhWeightPPackage.LocationF.X - 30, dPlanA4.xrhWeightPPackage.LocationF.Y);

                                dPlanA4.xrhUn.LocationF = new PointF(dPlanA4.xrhUn.LocationF.X - 50, dPlanA4.xrhUn.LocationF.Y);
                                dPlanA4.xrhKgCtn.LocationF = new PointF(dPlanA4.xrhKgCtn.LocationF.X - 20, dPlanA4.xrhKgCtn.LocationF.Y);
                                dPlanA4.GroupHeader1.LocationF = new PointF(dPlanA4.GroupHeader1.LocationF.X, dPlanA4.GroupHeader1.LocationF.Y + 20);

                                dPlanA4.xrdRemark.WidthF = dPlanA4.xrdRemark.WidthF + 50;
                                dPlanA4.xrdQtyOfPackage.LocationF = new PointF(dPlanA4.xrdQtyOfPackage.LocationF.X + 40, dPlanA4.xrdQtyOfPackage.LocationF.Y);
                                dPlanA4.xrdRemainByProduct.LocationF = new PointF(dPlanA4.xrdRemainByProduct.LocationF.X + 10, dPlanA4.xrdRemainByProduct.LocationF.Y);
                                dPlanA4.xrdUnitQty.LocationF = new PointF(dPlanA4.xrdUnitQty.LocationF.X - 140, dPlanA4.xrdUnitQty.LocationF.Y);
                                dPlanA4.xrhSumQtyOfPackage.LocationF = new PointF(dPlanA4.xrhSumQtyOfPackage.LocationF.X - 90, dPlanA4.xrhSumQtyOfPackage.LocationF.Y);
                                dPlanA4.xrdRemark.LocationF = new PointF(dPlanA4.xrdRemark.LocationF.X + 25, dPlanA4.xrdRemark.LocationF.Y);

                                // get source report
                                DataTable dt = new DataTable();
                                dt = (DataTable)Result;
                                string strDO = dt.Rows[0][0].ToString();
                                dPlanA4.RequestParameters = false;
                                dPlanA4.bcDispatching.Text = "*" + strDO + "*";
                                ReportPrintToolWMS printTool = new ReportPrintToolWMS(dPlanA4);
                                printTool.AutoShowParametersPanel = false;
                                if (isPreview)
                                {
                                    printTool.ShowPreview();

                                }
                                else
                                {
                                    printTool.Print();
                                }

                            }
                            else
                            {
                                rptDispatchingPlanA4New dPlanA4 = new rptDispatchingPlanA4New();
                                dPlanA4.RequestParameters = false;
                                if (customerRequired != null)
                                {
                                    dPlanA4.Parameters["varCustomerRequired"].Value = customerRequire;
                                }
                                dPlanA4.DataSource = Result;
                                dPlanA4.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
                                dPlanA4.xrnhietDo.Visible = false;
                                dPlanA4.xrTemperature.Visible = false;
                                // hide header report
                                dPlanA4.xrPalletID.Visible = false;
                                dPlanA4.xrUnit.Visible = false;
                                dPlanA4.xrWeight.Visible = false;
                                dPlanA4.xrCtnPcs.Visible = false;
                                dPlanA4.xrPro_.Visible = false;
                                dPlanA4.xrExp.Visible = false;

                                // hide group header
                                dPlanA4.xrhWeigth.Visible = false;

                                // invisible ctn
                                dPlanA4.xrhKgCtn.Visible = false;
                                dPlanA4.xrhWeightPerPackage.Visible = false;
                                dPlanA4.xrhSumWeightPerPackage.Visible = false;
                                dPlanA4.xrhSumPalletWeight.Visible = false;

                                // hide colum detail
                                dPlanA4.xrdQtyPackageModInner.Visible = false;
                                dPlanA4.xrdQtyPackageQuotieInner.Visible = false;
                                dPlanA4.xrdPalletWeight.Visible = false;

                                // move postion and resize xrlabel
                                dPlanA4.xrdDispatchingLocationRemark.WidthF = 160F;
                                dPlanA4.xrdPalletID.WidthF = dPlanA4.xrdPalletID.WidthF + 10;
                                dPlanA4.xrdPalletID.LocationF = new PointF(dPlanA4.xrdPalletID.LocationF.X + 70, dPlanA4.xrdPalletID.LocationF.Y);
                                dPlanA4.xrdQtyOfPackage.LocationF = new PointF(dPlanA4.xrdQtyOfPackage.LocationF.X + 60, dPlanA4.xrdQtyOfPackage.LocationF.Y);
                                dPlanA4.xrdProductDate.LocationF = new PointF(dPlanA4.xrdProductDate.LocationF.X + 50, dPlanA4.xrdProductDate.LocationF.Y);
                                dPlanA4.xrdUseByDate.LocationF = new PointF(dPlanA4.xrdUseByDate.LocationF.X + 50, dPlanA4.xrdUseByDate.LocationF.Y);

                                DataTable dt = new DataTable();
                                string strDO = string.Empty;
                                dt = (DataTable)Result;
                                if (dt != null && dt.Rows.Count > 0)
                                {
                                    strDO = dt.Rows[0][0].ToString();
                                }

                                dPlanA4.RequestParameters = false;
                                dPlanA4.bcDispatching.Text = "*" + strDO + "*";
                                ReportPrintToolWMS printTool = new ReportPrintToolWMS(dPlanA4);
                                printTool.AutoShowParametersPanel = false;
                                if (isPreview)
                                {
                                    printTool.ShowPreview();

                                }
                                else
                                {
                                    printTool.Print();
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string fileName = path + "\\OrderTripExport_" + DateTime.Now.ToString("dd_MM_yy_HH_mm_ss") + ".xlsx";
            this.grvDispatchingOrderSelectTableView.ExportToXlsx(fileName);
            System.Diagnostics.Process.Start(fileName);
        }

        private void btnCheckTemp_Click(object sender, EventArgs e)
        {
            string ReportDate = dateEditDateFrom.DateTime.Date.ToString("yyyy-MM-dd");
            frm_WM_TripViewByTemperatures frm = new frm_WM_TripViewByTemperatures(ReportDate, Convert.ToInt32(this.lookUpEditCustomerID.EditValue));
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
        }
    }
}