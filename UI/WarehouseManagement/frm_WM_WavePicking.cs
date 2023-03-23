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
using DA;
using DevExpress.XtraBars;
using DevExpress.XtraReports.UI;
using UI.Helper;
using UI.ReportFile;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_WavePicking : frmBaseForm
    {
        private string orderType = string.Empty;
        private string orderNumbers = string.Empty;
        private int customerID = 0;
        private string fromDate = string.Empty, toDate = string.Empty;
        private ST_WMS_LoadWavePickingByCustomer_Result currentWavePicking = null;
        private BindingList<WavePickingDetails> dbWavePickingDetails = null;
        private int wavePickingID = 0;
        public frm_WM_WavePicking(string orderType, string orderNumbers, int customerID, string fromDate, string toDate)
        {
            InitializeComponent();

            // Set value params input
            this.orderType = orderType;
            this.orderNumbers = orderNumbers;
            this.customerID = customerID;
            this.fromDate = fromDate;
            this.toDate = toDate;

            // Init events
            this.InitEvents();

            // Load customer data
            this.LoadCustomer();

            // Insert wave picking
            if (!string.IsNullOrEmpty(orderType) && !string.IsNullOrEmpty(orderNumbers))
            {
                this.InsertWavePicking();
            }

            // Load wave picking
            this.InitData();
        }

        public frm_WM_WavePicking(int wavePickingID)
        {
            InitializeComponent();

            // Set value params input
            this.wavePickingID = wavePickingID;

            // Init events
            this.InitEvents();

            // Load customer data
            this.LoadCustomer();

            // Insert wave picking
            if (!string.IsNullOrEmpty(orderType) && !string.IsNullOrEmpty(orderNumbers))
            {
                this.InsertWavePicking();
            }

            // Load wave picking
            this.InitData();
        }

        private void InsertWavePicking()
        {
            this.orderNumbers = "(" + this.orderNumbers + ")";
            DataProcess<object> wavePickingDA = new DataProcess<object>();
            using (var context = new SwireDBEntities())
            {
                System.Data.Entity.Core.Objects.ObjectParameter outWavePickingID = new System.Data.Entity.Core.Objects.ObjectParameter("returnWavePickingID", 0);
                int resultResult = context.STWavePickingInsert(this.customerID, Convert.ToDateTime(this.fromDate), Convert.ToDateTime(this.toDate),
                    AppSetting.CurrentUser.LoginName, this.orderNumbers, this.orderType, outWavePickingID);
                this.wavePickingID = Convert.ToInt32(outWavePickingID.Value);
            }
        }

        private void bbuton_WavePickingSummary_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_WM_Dialog_WavePickingSummary frm = new frm_WM_Dialog_WavePickingSummary(this.currentWavePicking.WavePickingID);
            frm.Show();
            frm.WindowState = FormWindowState.Normal;
            frm.BringToFront();
        }

        private void InitData()
        {
            // load wavepicking 
            this.LoadWavePicking();
            this.LoadWavePickDetails();
            this.BindingData();

            int customerID = AppSetting.CustomerListAll.Where(c => c.CustomerNumber == this.currentWavePicking.CustomerNumber).FirstOrDefault().CustomerID;
            this.lkeCustomerNumber.EditValue = customerID;
        }

        /// <summary>
        /// Init all events on form
        /// </summary>
        private void InitEvents()
        {
            this.lkeCustomerNumber.EditValueChanged += LkeCustomerNumber_EditValueChanged;
            this.bbuton_WavePickingSummary.ItemClick += bbuton_WavePickingSummary_ItemClick;
            this.btnReceivingAdvice.ItemClick += btnReceivingAdvice_ItemClick;
            this.btnPickingSlips.ItemClick += btnPickingSlips_ItemClick;
            this.btnDispatchingPlan.ItemClick += BtnDispatchingPlan_ItemClick;
            this.btnPickingSlipDecalLabel.ItemClick += BtnPickingSlipDecalLabel_ItemClick;
            this.btnPickingSlipByProduct.ItemClick += BtnPickingSlipByProduct_ItemClick;
            this.btnPickingSlipFull.ItemClick += this.btnPickingSlipFull_ItemClick;
        }

        private void BtnPickingSlipByProduct_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //        Call PickingSlip
            //If Me.FrameDispatchingOrderType = 3 Then
            //    DoCmd.OpenReport "rptPickingSlipManyOrders", acViewPreview, , "[RoomID]= '" & Me.ComboRoomID & "'"
            //Else
            //    DoCmd.OpenReport "rptPickingSlipManyOrdersByProduct", acViewPreview
            //End If
            //DoCmd.OpenReport "rptLabel_PickingSlipManyOrders", acViewPreview

            if (orderType != "RO")
            {
                PickingSlip();
                ReportPrintToolWMS print, printLabelDecal;
                if (Convert.ToInt32(rdDispatchingOrderType.Properties.Items[rdDispatchingOrderType.SelectedIndex].Tag) == 3)
                {
                    var result = FileProcess.LoadTable("STPickingSlipManyOrderReport");

                    var manyOrderSource = result.Select("RoomID='" + this.txtRoom.Text + "'");
                    rptPickingSlipManyOrders rpt = new rptPickingSlipManyOrders();
                    rpt.DataSource = manyOrderSource;
                    rpt.RequestParameters = false;
                    print = new ReportPrintToolWMS(rpt);
                }
                else
                {

                    var result = FileProcess.LoadTable("STPickingSlipManyOrderReport");
                    rptPickingSlipManyOrdersByProduct rpt = new rptPickingSlipManyOrdersByProduct();
                    rpt.xrOrderNo.Text = orderNumbers;
                    rpt.DataSource = result;
                    rpt.RequestParameters = false;
                    print = new ReportPrintToolWMS(rpt);


                }
                var dataSource = FileProcess.LoadTable("STPickingSlipManyOrderReport");
                rptLabel_PickingSlipManyOrders rptPicking = new rptLabel_PickingSlipManyOrders();
                rptPicking.DataSource = dataSource;
                rptPicking.RequestParameters = false;
                printLabelDecal = new ReportPrintToolWMS(rptPicking);
                printLabelDecal.AutoShowParametersPanel = false;
                printLabelDecal.ShowPreview();

                print.AutoShowParametersPanel = false;
                print.ShowPreview();
            }

        }

        private void BtnPickingSlipDecalLabel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (orderType != "RO")
            {
                PickingSlip();
                ReportPrintToolWMS print, printLabelDecal;
                if (Convert.ToInt32(rdDispatchingOrderType.Properties.Items[rdDispatchingOrderType.SelectedIndex].Tag) == 3)
                {
                    var result = FileProcess.LoadTable("STPickingSlipManyOrderReport");

                    var manyOrderSource = result.Select("RoomID='" + this.txtRoom.Text + "'");
                    rptPickingSlipManyOrders rpt = new rptPickingSlipManyOrders();
                    rpt.DataSource = manyOrderSource;
                    rpt.RequestParameters = false;
                    print = new ReportPrintToolWMS(rpt);
                }
                else
                {
                    string customerType = Convert.ToString(this.lkeCustomerNumber.GetColumnValue("CustomerType"));
                    if (customerType == "Pcs")
                    {
                        rptPickingSlipManyOrders_pcs rpt = new rptPickingSlipManyOrders_pcs();
                        rpt.DataSource = FileProcess.LoadTable("select * from tmpPickingSlips");
                        rpt.xrOrderNo.Text = this.orderNumbers;
                        rpt.RequestParameters = false;
                        print = new ReportPrintToolWMS(rpt);
                    }
                    else
                    {
                        var result = FileProcess.LoadTable("STPickingSlipManyOrderReport");
                        rptPickingSlipManyOrders rpt = new rptPickingSlipManyOrders();
                        rpt.xrOrderNo.Text = orderNumbers;
                        rpt.DataSource = result;
                        rpt.RequestParameters = false;
                        print = new ReportPrintToolWMS(rpt);

                    }
                }
                var dataSource = FileProcess.LoadTable("STPickingSlipManyOrderReport");
                rptLabelDecal_Dispatching rptLabelDecal = new rptLabelDecal_Dispatching();
                rptLabelDecal.DataSource = dataSource;
                rptLabelDecal.RequestParameters = false;
                printLabelDecal = new ReportPrintToolWMS(rptLabelDecal);
                printLabelDecal.AutoShowParametersPanel = false;
                printLabelDecal.ShowPreview();

                print.AutoShowParametersPanel = false;
                print.ShowPreview();
            }
        }

        private void BtnDispatchingPlan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.grvWavePickingDetails.RowCount > 0)
            {
                int customerMain = Convert.ToInt32(this.lkeCustomerNumber.GetColumnValue("CustomerMainID"));
                FileProcess.LoadTable("STDispatchingPlanManyOrders @p_str='" + orderNumbers + "'");

                string customerType = Convert.ToString(this.lkeCustomerNumber.GetColumnValue("CustomerType"));
                FileProcess.LoadTable("STCustomerRequirementPrint @CustomerMainID=" + customerMain + ", @Flag=2");

                rptDispatchingPlanManyOrders rpt = new rptDispatchingPlanManyOrders();
                rpt.DataSource = FileProcess.LoadTable("STDispatchingPlanManyOrderReport");
                rpt.RequestParameters = false;
                ReportPrintToolWMS print = new ReportPrintToolWMS(rpt);
                print.ShowPreviewDialog();
            }
        }

        void btnPickingSlips_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (orderType != "RO")
            {
                PickingSlip();
                ReportPrintToolWMS print, printA5 , printTS, printTSTrip;

                if (Convert.ToInt32(rdDispatchingOrderType.Properties.Items[rdDispatchingOrderType.SelectedIndex].Tag) == 3)
                {
                    var result = FileProcess.LoadTable("STPickingSlipManyOrderReport");
                    var manyOrderSource = result.Select("RoomID='" + this.txtRoom.Text + "'");
                    rptPickingSlipManyOrders rpt = new rptPickingSlipManyOrders();
                    rpt.DataSource = manyOrderSource;
                    rpt.lblWaveNo.Text = this.txtWavePinkingNumber.Text;
                    rpt.RequestParameters = false;
                    print = new ReportPrintToolWMS(rpt);
                }
                else
                {
                    string customerType = Convert.ToString(this.lkeCustomerNumber.GetColumnValue("CustomerType"));
                    if (customerType == "Pcs")
                    {
                        rptPickingSlipManyOrders_pcs rpt = new rptPickingSlipManyOrders_pcs();
                        rpt.DataSource = FileProcess.LoadTable("select * from tmpPickingSlips");
                        rpt.xrOrderNo.Text = this.orderNumbers;
                        rpt.lblWaveNo.Text = this.txtWavePinkingNumber.Text;
                        rpt.RequestParameters = false;
                        print = new ReportPrintToolWMS(rpt);
                        print.AutoShowParametersPanel = false;
                    }
                    else
                    {
                        var result = FileProcess.LoadTable("STPickingSlipManyOrderReport");
                        rptPickingSlipManyOrders rpt = new rptPickingSlipManyOrders();
                        rpt.xrOrderNo.Text = orderNumbers;
                        rpt.lblWaveNo.Text = this.txtWavePinkingNumber.Text;
                        rpt.DataSource = result;
                        rpt.RequestParameters = false;
                        print = new ReportPrintToolWMS(rpt);
                        print.AutoShowParametersPanel = false;
                    }
                }

                // Config Landscape Mode for printer
                print.PrinterSettings.DefaultPageSettings.Landscape = true;
                print.ShowPreview();
                rptLabel_PickingSlipManyOrdersA5 rptA5 = new rptLabel_PickingSlipManyOrdersA5();
                var labelSource = FileProcess.LoadTable("STPickingSlipManyOrderReport");
                rptA5.DataSource = labelSource;
                rptA5.RequestParameters = false;
                printA5 = new ReportPrintToolWMS(rptA5);
                printA5.AutoShowParametersPanel = false;
                printA5.ShowPreview();

                rptLabel_PickingSlipTinySize rptTS = new rptLabel_PickingSlipTinySize();
                rptTS.DataSource = labelSource;
                rptTS.RequestParameters = false;
                printTS = new ReportPrintToolWMS(rptTS);
                printTS.AutoShowParametersPanel = false;
                printTS.ShowPreview();

                var labelSourcetrip = FileProcess.LoadTable("STPickingSlipManyOrderReportTrip");
                rptLabel_PickingSlipTinySize rptTSTRip = new rptLabel_PickingSlipTinySize();
                rptTSTRip.DataSource = labelSourcetrip;
                rptTSTRip.RequestParameters = false;
                printTSTrip = new ReportPrintToolWMS(rptTSTRip);
                printTSTrip.AutoShowParametersPanel = false;
                printTSTrip.ShowPreview();

            }
        }

        /// <summary>
        /// Handles the ItemClick event of the btnPickingSlipFull control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ItemClickEventArgs"/> instance containing the event data.</param>
        private void btnPickingSlipFull_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.HandlePickingSlips(true);
        }

        private void PickingSlip()
        {
            if (orderNumbers.Contains('('))
            {
                orderNumbers = orderNumbers.Substring(1, orderNumbers.Length - 2);
            }
            if (orderNumbers != "")
            {
                var dataSource = FileProcess.LoadTable("STLabelPickingSlipManyOrders '" + orderNumbers + "'");
                if (dataSource.Rows.Count > 0)
                {
                    //open rptLabelA4Short_Barcode
                    rptLabelA4Short_Barcode rpt = new rptLabelA4Short_Barcode();
                    rpt.DataSource = dataSource;
                    rpt.RequestParameters = false;
                    rpt.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
                    rpt.Parameters["parameter1"].Value = 3;
                    ReportPrintToolWMS print = new ReportPrintToolWMS(rpt);
                    print.AutoShowParametersPanel = false;
                    print.ShowPreview();
                }
                FileProcess.LoadTable("STPickingSlipManyOrders '" + orderNumbers + "'");
            }
        }

        void btnReceivingAdvice_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            rptReceivingAdviceManyOrders rpt = new rptReceivingAdviceManyOrders();
            rpt.RequestParameters = false;
            rpt.xrOrderNo.Text = this.orderNumbers;
            DataTable dataSource = new DataTable();
            ReportPrintToolWMS print;
            if (orderNumbers != "")
            {
                if (orderNumbers.Contains('('))
                {
                    orderNumbers = orderNumbers.Substring(1, orderNumbers.Length - 2);
                }
                FileProcess.LoadTable("STReceivingAdviceManyOrders @p_str='" + orderNumbers + "'");


            }
            if (Convert.ToInt32(rdDispatchingOrderType.Properties.Items[rdDispatchingOrderType.SelectedIndex].Tag) == 3)
            {
                dataSource = FileProcess.LoadTable("select * from tmpReceivingAdvices where RoomID='" + this.txtRoom.Text + "'");
                rpt.DataSource = dataSource;
                rpt.Parameters["Room"].Value = this.txtRoom.Text;
            }
            else
            {
                dataSource = FileProcess.LoadTable("select * from tmpReceivingAdvices");
                rpt.DataSource = dataSource;

            }
            print = new ReportPrintToolWMS(rpt);
            print.AutoShowParametersPanel = false;
            print.ShowPreview();
        }

        private void LkeCustomerNumber_EditValueChanged(object sender, EventArgs e)
        {
            if (this.lkeCustomerNumber.EditValue == null) return;
            int customerID = Convert.ToInt32(this.lkeCustomerNumber.EditValue);
            this.teCustomerName.Text = AppSetting.CustomerListAll.Where(c => c.CustomerID == customerID).FirstOrDefault().CustomerName;
        }

        private void LoadWavePicking()
        {
            DataProcess<ST_WMS_LoadWavePickingByCustomer_Result> wavePickingDA = new DataProcess<ST_WMS_LoadWavePickingByCustomer_Result>();
            this.currentWavePicking = wavePickingDA.Executing("ST_WMS_LoadWavePickingByCustomer @WavePickingID={0}",
                this.wavePickingID).FirstOrDefault();
        }

        private void LoadWavePickDetails()
        {
            DataProcess<WavePickingDetails> wavepickingDetailsDA = new DataProcess<WavePickingDetails>();
            this.dbWavePickingDetails = new BindingList<WavePickingDetails>(wavepickingDetailsDA.Select(w => w.WavePickingID == this.currentWavePicking.WavePickingID).ToList());
            this.grdWavePickingDetails.DataSource = this.dbWavePickingDetails;
            int count = 0;
            this.orderNumbers = string.Empty;
            foreach (var item in this.dbWavePickingDetails)
            {
                if (!item.OrderNumber.Contains('-')) continue;
                count++;
                string orderID = item.OrderNumber.Split('-')[1];
                this.orderNumbers += orderID;
                if (count < this.dbWavePickingDetails.Count)
                {
                    this.orderNumbers += ",";
                }

            }
            
        }
        private void LoadCustomer()
        {
            // Load customer
            if (AppSetting.CustomerList == null) return;
            lkeCustomerNumber.Properties.DataSource = AppSetting.CustomerListAll;
            lkeCustomerNumber.Properties.ValueMember = "CustomerID";
            lkeCustomerNumber.Properties.DisplayMember = "CustomerNumber";
        }

        private void grvWavePickingDetails_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.RowHandle < 0) return;
            if (e.Column.FieldName.Equals("OrderNumber"))
            {
                ri_lke_OrderNumber_Click(sender, e);
            }
        }

        private void ri_lke_OrderNumber_Click(object sender, EventArgs e)
        {
            string orderInfo = Convert.ToString(this.grvWavePickingDetails.GetFocusedRowCellValue("OrderNumber"));
            if (string.IsNullOrEmpty(orderInfo)) return;
            string orderType = orderInfo.Split('-')[0];
            int orderID = Convert.ToInt32(orderInfo.Split('-')[1]);
            switch (orderType)
            {
                case "DO":
                    frm_WM_DispatchingOrders dispatchingOrder = frm_WM_DispatchingOrders.GetInstance(orderID);
                    if (dispatchingOrder.Visible)
                    {
                        dispatchingOrder.ReloadData();
                    }
                    dispatchingOrder.Show();
                    dispatchingOrder.WindowState = FormWindowState.Maximized;
                    dispatchingOrder.BringToFront();
                    break;
                case "RO":
                    frm_WM_ReceivingOrders receivingOrder = frm_WM_ReceivingOrders.Instance;
                    receivingOrder.ReceivingOrderIDFind = orderID;
                    receivingOrder.Show();
                    receivingOrder.WindowState = FormWindowState.Maximized;
                    receivingOrder.BringToFront();
                    break;
            }
        }

        private void bbuton_WavePickingDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Code to Delete Wave here

            if (currentWavePicking.WavePickingID <= 0)
                MessageBox.Show("Wave Picking ID value is null or wrong !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (this.grvWavePickingDetails.DataRowCount > 1)
                MessageBox.Show(string.Format("You must delete all details before delete this {0} !", currentWavePicking.WavePickingNumber), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (MessageBox.Show("Are you sure to delete this Wave Picking ?", "TPWMS", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    DataProcess<Object> stStripDeleteUpdateDA = new DataProcess<object>();
                    //int queryResult = stStripDeleteUpdateDA.ExecuteNoQuery("STTripDeleteUpdate @TripID={0},@Flag={1}", currentWavePicking.WavePickingID, 0);
                    //if (queryResult > 0)
                    //{
                    //    MessageBox.Show("Wave picking deleted !");
                    //    this.Close();
                    //}
                }
            }

            // Check to make sure ll the waveDetails are deleted

            // Delete the main Wave
        }

        private void grvWavePickingDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.KeyCode.Equals(Keys.Delete)) return;
            //var countDelete = this.dbWavePickingDetails.Where(w => w.CheckDelete == true).ToList();
            //if (countDelete.Count() <= 0) return;
            var dl = MessageBox.Show("Do you want to delete the Wave Picking Details?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dl.Equals(DialogResult.No)) return;
            DataProcess<object> process = new DataProcess<object>();
            foreach (var rowIndex in this.grvWavePickingDetails.GetSelectedRows())
            {
                process.ExecuteNoQuery("Delete WavePickingDetails where WavePickingDetailID=" + this.grvWavePickingDetails.GetRowCellDisplayText(rowIndex, "WavePickingDetailID"));
            }
            this.LoadWavePickDetails();
        }

        private void bbuton_PickingListA5ByRoom_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
       
        private void BindingData()
        {
            this.txtWavePinkingNumber.DataBindings.Add("Text", this.currentWavePicking, "WavePickingNumber");
            this.txtCreatedBy.DataBindings.Add("Text", this.currentWavePicking, "CreatedBy");
            this.txtCreatedTime.DataBindings.Add("Text", this.currentWavePicking, "CreatedTime");
            this.dWavePickingDate.DataBindings.Add("EditValue", this.currentWavePicking, "WavePickingDate");
            this.meWavePickingRemark.DataBindings.Add("Text", this.currentWavePicking, "WavePickingRemark");
            this.dtStartTime.DataBindings.Add("EditValue", this.currentWavePicking, "StartWorkingTime");
            this.dtEndTime.DataBindings.Add("EditValue", this.currentWavePicking, "EndWorkingTime");
        }

        private void bb_WavePicking_PickingList_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_WM_Dialog_PickingSlip Pick = new frm_WM_Dialog_PickingSlip(wavePickingID, "WP");
            Pick.Show();
        }

        private void bbtn_ViewWavePickingSlipSummary_ItemClick(object sender, ItemClickEventArgs e)
        {
            PickingSlip();
            rptWavePickingSummary rpt = new rptWavePickingSummary();

            rpt.DataSource = FileProcess.LoadTable("SELECT * FROM WavePickings WHERE WavePickingID = " + wavePickingID);;

            rpt.RequestParameters = false;
            rpt.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
            ReportPrintToolWMS PrintTool = new ReportPrintToolWMS(rpt);
            PrintTool.ShowPreview();
        }

        private void bb_WavePicking_Refresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            DataProcess<Object> DA = new DataProcess<object>();
            int result = DA.ExecuteNoQuery("ST_WMS_RefreshWave  @WavePickingID={0}", this.wavePickingID);
            if (result < 0)
            {
                MessageBox.Show("Error", "WMS");
            }
            else
            {

                Int32 WaveID = Convert.ToInt32(this.wavePickingID);
                frm_WM_WavePicking frmW = new frm_WM_WavePicking(WaveID);
                frmW.Show();
                frmW.BringToFront();
                this.Close();
                //MessageBox.Show("Refresh Done", "WMS");
            }
        }

        private void bb_EDI_Process_ItemClick(object sender, ItemClickEventArgs e)
        {
            //show form EDI List with selected records
            //string choosenIDs = "";
            string cellValues = "";
            int[] selectedRows = grvWavePickingDetails.GetSelectedRows();
            foreach (int rowHandle in selectedRows)
            {
                if (rowHandle >= 0)
                {
                    if (cellValues.Length > 0)
                        cellValues = cellValues + " , " + grvWavePickingDetails.GetRowCellValue(rowHandle, "OrderNumber").ToString().Split('-')[1];
                    else
                        cellValues = grvWavePickingDetails.GetRowCellValue(rowHandle, "OrderNumber").ToString().Split('-')[1];
                }
            }
            //choosenIDs = cellValues;
            frm_WM_EDIOrdersViewList frm = new frm_WM_EDIOrdersViewList(DateTime.Today, Convert.ToInt32( this.lkeCustomerNumber.EditValue.ToString()), cellValues);
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront();
        }

        private void bb_EDI_Refresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            // code here to refresh the Wave Picking Order Details and remove all the processed EDI orders
            DataProcess<Object> DA = new DataProcess<object>();
            int result = DA.ExecuteNoQuery("ST_WMS_RefreshWave_EDI  @WavePickingID={0}", this.wavePickingID);
            if (result < 0)
            {
                MessageBox.Show("Error", "WMS");
            }
            else
            {

                Int32 WaveID = Convert.ToInt32(this.wavePickingID);
                frm_WM_WavePicking frmW = new frm_WM_WavePicking(WaveID);
                frmW.Show();
                frmW.BringToFront();
                this.Close();
            }
        }

        private void bb_WavePicking_PalletLabel_ItemClick(object sender, ItemClickEventArgs e)
        {


            rptLabel_PalletID_Large report = new rptLabel_PalletID_Large();

            report.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
            report.Parameters["parameter1"].Value = 1;
            report.DataSource = FileProcess.LoadTable("STLabelPalletIDWavePicking " + this.wavePickingID);
            report.RequestParameters = false;
            report.PaperKind = System.Drawing.Printing.PaperKind.A5;

            var printTool = new ReportPrintToolWMS(report)
            {
                AutoShowParametersPanel = false
            };
                printTool.ShowPreview();

        }

        private void dtStartTime_EditValueChanged(object sender, EventArgs e)
        {
            this.currentWavePicking.StartWorkingTime = this.dtStartTime.DateTime;
            if (this.dtStartTime.IsModified)
            {
                if (dtStartTime.DateTime > DateTime.Now.AddDays(-4) && dtStartTime.DateTime < DateTime.Now)
                {
                    DataProcess<object> tripDA = new DataProcess<object>();
                    tripDA.ExecuteNoQuery("Update WavePickings Set WavePickings.StartWorkingTime = '" + this.dtStartTime.DateTime.ToString("yyyy-MM-dd HH:mm") + "' Where WavePickings.WavePickingID = " + this.currentWavePicking.WavePickingID);
                    foreach (var item in this.dbWavePickingDetails)
                    {
                        int result = tripDA.ExecuteNoQuery("Update ReceivingOrders set StartTime='" + this.dtStartTime.DateTime.ToString("yyyy-MM-dd HH:mm")
                                            + "' where ReceivingOrderNumber='" + item.OrderNumber + "'");
                    }
                }
            }
        }

        private void dtEndTime_EditValueChanged(object sender, EventArgs e)
        {
            this.currentWavePicking.EndWorkingTime = this.dtEndTime.DateTime;
            if (this.dtEndTime.IsModified)
            {
                if (dtEndTime.EditValue != null && dtEndTime.DateTime >= dtStartTime.DateTime)
                {
                    DataProcess<object> tripDA = new DataProcess<object>();
                    tripDA.ExecuteNoQuery("Update WavePickings Set WavePickings.EndWorkingTime = '" + this.dtEndTime.DateTime.ToString("yyyy-MM-dd HH:mm") + "' Where WavePickings.WavePickingID = " + this.currentWavePicking.WavePickingID);
                    foreach (var item in this.dbWavePickingDetails)
                    {
                        int result = tripDA.ExecuteNoQuery("Update ReceivingOrders set EndTime='" + this.dtEndTime.DateTime.ToString("yyyy-MM-dd HH:mm")
                                            + "' where ReceivingOrderNumber='" + item.OrderNumber + "'");
                    }
                }
            }
        }

        /// <summary>
        /// Handles the picking slips.
        /// </summary>
        /// <param name="isFullMode">if set to <c>true</c> [is full mode].</param>
        private void HandlePickingSlips(bool isFullMode = false)
        {
            if (orderType != "RO")
            {
                PickingSlip();
                ReportPrintToolWMS print, printA5;

                if (Convert.ToInt32(rdDispatchingOrderType.Properties.Items[rdDispatchingOrderType.SelectedIndex].Tag) == 3)
                {
                    var result = FileProcess.LoadTable("STPickingSlipManyOrderReport");
                    var manyOrderSource = result.Select("RoomID='" + this.txtRoom.Text + "'");
                    rptPickingSlipManyOrders_Full rpt = new rptPickingSlipManyOrders_Full();
                    rpt.DataSource = manyOrderSource;
                    rpt.RequestParameters = false;
                    print = new ReportPrintToolWMS(rpt);
                }
                else
                {
                    string customerType = Convert.ToString(this.lkeCustomerNumber.GetColumnValue("CustomerType"));
                    if (customerType == "Pcs")
                    {
                        rptPickingSlipManyOrders_Full rpt = new rptPickingSlipManyOrders_Full();
                        rpt.DataSource = FileProcess.LoadTable("select * from tmpPickingSlips");
                        rpt.xrOrderNo.Text = this.orderNumbers;
                        rpt.RequestParameters = false;
                        print = new ReportPrintToolWMS(rpt);
                        print.AutoShowParametersPanel = false;
                    }
                    else
                    {
                        var result = FileProcess.LoadTable("STPickingSlipManyOrderReport");
                        rptPickingSlipManyOrders_Full rpt = new rptPickingSlipManyOrders_Full();
                        rpt.xrOrderNo.Text = orderNumbers;
                        rpt.DataSource = result;
                        rpt.RequestParameters = false;
                        print = new ReportPrintToolWMS(rpt);
                        print.AutoShowParametersPanel = false;
                    }
                }

                // Config Landscape Mode for printer
                var report = print.Report as XtraReport;
                if (isFullMode && report != null)
                {
                    report.Landscape = true;
                    print.PrinterSettings.DefaultPageSettings.Landscape = true;
                }
                print.ShowPreview();

                rptLabel_PickingSlipManyOrdersA5 rptA5 = new rptLabel_PickingSlipManyOrdersA5();
                var labelSource = FileProcess.LoadTable("STPickingSlipManyOrderReport");
                rptA5.DataSource = labelSource;
                rptA5.RequestParameters = false;
                printA5 = new ReportPrintToolWMS(rptA5);
                printA5.AutoShowParametersPanel = false;
                printA5.ShowPreview();
            }
        }
    }
}
