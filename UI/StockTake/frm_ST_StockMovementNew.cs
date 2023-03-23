using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using UI;
using UI.Helper;
using DA;
using DevExpress.XtraReports.UI;
using UI.ReportFile;
using log4net;
using DevExpress.Utils.Win;
using DevExpress.XtraEditors.Popup;
using System.ComponentModel;
using UI.WarehouseManagement;
using Common.Controls;

namespace UI.StockTake
{
    public partial class frm_ST_StockMovementNew : frmBaseForm
    {
        // Declare log
        private BindingList<ST_WMS_LoadStockMovementFromLocationID_Result> stockmonvetnFromDBindingList = null;
        private BindingList<ST_WMS_LoadStockMovementToLocationID_Result> stockmonvetnToDBindingList = null;
        private static readonly ILog log = LogManager.GetLogger(typeof(frm_ST_StockMovementNew));
        string m_Moved = "Moved";
        string m_Joined = "Joined";
        string m_Reversed = "Reversed";
        int LocationFromID = 0;
        List<DA.Locations> lst_ToLocationSource;
        byte ToLocationCode = 0;
        public frm_ST_StockMovementNew()
        {
            InitializeComponent();

            SetEvent();
        }
        public frm_ST_StockMovementNew(int locationFromID)
        {
            InitializeComponent();
            this.KeyPreview = true;
            SetEvent();
            LocationFromID = locationFromID;

        }

        void Frm_ST_StockMovementNew_Load(object sender, EventArgs e)
        {
            dateEdit_From.EditValue = DateTime.Now;
            dateEdit_To.EditValue = DateTime.Now;

            LoadData2searchLookUpEdit_LocationFromID();
            LoadData2searchLookUpEdit_ToLocationID_Free();

            LoadData2searchlookUpEdit_CustomerID();

            LoadData2searchLookUpEdit_EmployeeID();

            LoadData2lookUpEdit_Reason();

            LoadData2gridControlLocations_From();

            LoadData2gridControlLocations_To();
        }

        void SetEvent()
        {
            this.Load += Frm_ST_StockMovementNew_Load;

            this.lookUpEdit_Reason.Leave += LookUpEdit_Reason_Leave;
            this.searchLookUpEdit_EmployeeID.Leave += SearchLookUpEdit_EmployeeID_Leave;
            checkEdit_Free.CheckedChanged += CheckEdit_Free_CheckedChanged;
            checkEdit_MovetoFloor.CheckedChanged += CheckEdit_MovetoFloor_CheckedChanged;
            this.gridViewLocation_From.RowCellClick += GridViewLocation_From_RowCellClick;
            this.gridViewLocation_To.RowCellClick += GridViewLocation_To_RowCellClick;

            textEdit_LocationControlCodeOriginal.Validating += TextEdit_LocationControlCodeOriginal_Validating;

            searchLookUpEdit_FromLocationID.EditValueChanged += SearchLookUpEdit_FromLocationID_EditValueChanged;
            this.searchLookUpEdit_FromLocationID.CloseUp += SearchLookUpEdit_FromLocationID_CloseUp;
            this.searchLookUpEdit_ToLocationID.CloseUp += SearchLookUpEdit_FromLocationID_CloseUp;
            searchLookUpEdit_EmployeeID.EditValueChanged += SearchLookUpEdit_EmployeeID_EditValueChanged;

            //repItemButtonEdit_From_PalletInfo.Click += RepItemButtonEdit_From_PalletInfo_DoubleClick;
            repItemButtonEdit_From_PrintDecalLabel.Click += RepItemButtonEdit_From_PrintDecalLabel_Click;
            repItemButtonEdit_From_PrintLabel.Click += RepItemButtonEdit_From_PrintLabel_Click;
            this.btnCheckAllMove.Click += BtnCheckAllMove_Click;

            //repItemButtonEdit_To_PalletInfo.Click += RepItemButtonEdit_To_PalletInfo_DoubleClick;
            repItemButtonEdit_To_PrintDecalLabel.Click += RepItemButtonEdit_To_PrintDecalLabel_Click;
            repItemButtonEdit_To_PrintLabel.Click += RepItemButtonEdit_To_PrintLabel_Click;

            simpleButton_PalletHistory.Click += SimpleButton_PalletHistory_Click;
            simpleButton_MovementHistory.Click += SimpleButton_MovementHistory_Click;
            simpleButton_Update.Click += SimpleButton_Update_Click;
            simpleButton_MoveReversed.Click += SimpleButton_MoveReversed_Click;
            simpleButton_Close.Click += SimpleButton_Close_Click;
            simpleButton_Report.Click += SimpleButton_Report_Click;
            simpleButton1_2.Click += SimpleButton1_2_Click;

            textEdit_PalletID.Leave += TextEdit_PalletID_Leave;

            radioGroup_OptionReport.SelectedIndexChanged += RadioGroup_OptionReport_SelectedIndexChanged;
        }

        private void BtnCheckAllMove_Click(object sender, EventArgs e)
        {
            if (this.searchLookUpEdit_FromLocationID.EditValue == null) return;
            int isMove = 0;
            int v_varSourceLocationID = Convert.ToInt32(searchLookUpEdit_FromLocationID.EditValue);
            if (btnCheckAllMove.Text == "All Move")
            {
                this.btnCheckAllMove.Text = "Un-Move";
                isMove = 1;
            }
            else
            {
                this.btnCheckAllMove.Text = "All Move";
                isMove = 0;
            }
            // Update state canmove of this pallet selected
            DataProcess<object> palletDA = new DataProcess<object>();
            foreach (var palletInfor in this.stockmonvetnFromDBindingList)
            {
                int result = palletDA.ExecuteNoQuery("Update Pallets set canmove=" + isMove
                    + " where locationid=" + v_varSourceLocationID + " and PalletID=" + palletInfor.PalletID);
            }
            this.LoadData2gridControlLocations_From();
        }

        private void GridViewLocation_To_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            switch (this.gridViewLocation_To.FocusedColumn.FieldName)
            {
                case "CustomerNumber":
                    repositoryItemHyperLinkEditInoutView_Click(sender, e);
                    break;
                case "ReceivingOrderNumber":
                    repositoryItemHyperLinkEditRO2_Click(sender, e);
                    break;
                case "PalletID":
                    repositoryItemHyperLinkEditPalletInfor2_Click(sender, e);
                    break;
                case "ProductNumber":
                    rpi_hle_ProductNumber_Click(sender, e);
                    break;
                default:
                    break;
            }
        }

        private void GridViewLocation_From_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            switch (this.gridViewLocation_From.FocusedColumn.FieldName)
            {
                case "CustomerNumber":
                    repositoryItemHyperLinkEditInoutView2_Click(sender, e);
                    break;
                case "ReceivingOrderNumber":
                    repositoryItemHyperLinkEditRO2_Click(sender, e);
                    break;
                case "PalletID":
                    repositoryItemHyperLinkEditPalletInfo_Click(sender, e);
                    break;
                case "Label":
                    RepItemButtonEdit_From_PrintLabel_Click(sender, e);
                    break;
                case "Decal":
                    break;
                    RepItemButtonEdit_From_PrintDecalLabel_Click(sender, e);
                case "ProductNumber":
                    rpi_hle_ProductNumber_Click(sender, e);
                    break;
                default:
                    break;
            }
        }

        private void SearchLookUpEdit_FromLocationID_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            SendKeys.Send("{TAB}");
        }

        private void TextEdit_LocationControlCodeOriginal_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(textEdit_LocationControlCodeOriginal.Text))
                {
                    if (Convert.ToByte(textEdit_LocationControlCodeOriginal.Text) == ToLocationCode)
                    {
                        simpleButton_Update.Enabled = true;
                        simpleButton_MoveReversed.Enabled = true;
                        LoadData2gridControlLocations_To();
                    }
                    else
                    {
                        MessageBox.Show("The location code is not correct !");
                        textEdit_LocationControlCodeOriginal.Focus();
                        this.textEdit_LocationControlCodeOriginal.SelectAll();
                        simpleButton_Update.Enabled = false;
                        simpleButton_MoveReversed.Enabled = false;
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);

                MessageBox.Show("The location code is not correct !");
                textEdit_LocationControlCodeOriginal.Focus();
                this.textEdit_LocationControlCodeOriginal.SelectAll();
                simpleButton_Update.Enabled = false;
                simpleButton_MoveReversed.Enabled = false;
                e.Cancel = true;
            }
        }

        private void LookUpEdit_Reason_Leave(object sender, EventArgs e)
        {
            if (this.simpleButton_Update.Enabled)
            {
                this.simpleButton_Update.Focus();
            }
            else
            {
                this.simpleButton_Close.Focus();
            }
        }

        private void SearchLookUpEdit_EmployeeID_Leave(object sender, EventArgs e)
        {
            this.lookUpEdit_Reason.Focus();
            this.lookUpEdit_Reason.ShowPopup();
        }

        #region Event

        void RadioGroup_OptionReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            RadioGroup v_rg = (RadioGroup)sender;
            int index = v_rg.SelectedIndex;
            if (index == 2)
            {
                searchLookUpEdit_CustomerID.Focus();
                searchLookUpEdit_CustomerID.ShowPopup();
            }
        }
        void TextEdit_PalletID_Leave(object sender, EventArgs e)
        {
            this.ValidatePalletIdInput();
        }

        void SimpleButton_PalletHistory_Click(object sender, EventArgs e)
        {
            int v_PalletID = 0;

            try
            {
                v_PalletID = Convert.ToInt32(textEdit_PalletID.Text);
            }
            catch { }

            WarehouseManagement.frm_WM_Dialog_LocationDetail frm = new WarehouseManagement.frm_WM_Dialog_LocationDetail(v_PalletID, 0,true);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowInTaskbar = false;
            frm.Show(this);
        }
        void SimpleButton_MovementHistory_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textEdit_PalletID.Text))
            {
                searchLookUpEdit_FromLocationID.Focus();
                searchLookUpEdit_FromLocationID.ShowPopup();
            }
            else
            {
                int v_PalletID = 0;

                try
                {
                    v_PalletID = Convert.ToInt32(textEdit_PalletID.Text);
                }
                catch { }

                WarehouseManagement.frm_WM_Dialog_StockMovementReview frm = new WarehouseManagement.frm_WM_Dialog_StockMovementReview(v_PalletID);
                if (!frm.Enabled) return;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowInTaskbar = false;
                frm.ShowDialog(this);

            }
        }
        void SimpleButton_Update_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(searchLookUpEdit_FromLocationID.EditValue)) || Convert.ToString(searchLookUpEdit_FromLocationID.EditValue).ToUpper().Equals("0"))
            {
                XtraMessageBox.Show("Please input locations !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                searchLookUpEdit_FromLocationID.Focus();
                return;
            }
            if (string.IsNullOrEmpty(Convert.ToString(searchLookUpEdit_ToLocationID.EditValue)) || Convert.ToString(searchLookUpEdit_ToLocationID).ToUpper().Equals("0"))
            {
                XtraMessageBox.Show("Please input locations !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                searchLookUpEdit_ToLocationID.Focus();
                return;
            }

            if (string.IsNullOrEmpty(this.textEdit_LocationControlCodeOriginal.Text))
            {
                XtraMessageBox.Show("Please input location code !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.textEdit_LocationControlCodeOriginal.Focus();
                return;
            }

            if (this.stockmonvetnFromDBindingList.Count == 0)
            {
                XtraMessageBox.Show("Location have no stock !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.searchLookUpEdit_FromLocationID.Focus();
                return;
            }

            //'Check the pallets are selected
            int moveCount = this.stockmonvetnFromDBindingList.Where(p => p.CanMove == true).Count();
            if (moveCount <= 0)
            {
                XtraMessageBox.Show("You have to select the pallets to move !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //'Check that the destinationa and sourse location is not the same
            if (Convert.ToString(searchLookUpEdit_FromLocationID.EditValue).ToUpper().Equals(Convert.ToString(searchLookUpEdit_ToLocationID.EditValue).ToUpper()))
            {
                XtraMessageBox.Show("Can not move to the same location !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                searchLookUpEdit_ToLocationID.Focus();
                return;
            }
            //'Check that the employee are input
            if (string.IsNullOrEmpty(Convert.ToString(searchLookUpEdit_EmployeeID.EditValue)) || Convert.ToString(searchLookUpEdit_EmployeeID).ToUpper().Equals("0"))
            {
                XtraMessageBox.Show("Please input Forklift driver !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                searchLookUpEdit_EmployeeID.Focus();
                return;
            }
            //'Check that the employee are input
            if (lookUpEdit_Reason.EditValue == null)
            {
                XtraMessageBox.Show("Please input Reason Movement!", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lookUpEdit_Reason.Focus();
                return;
            }
            if (string.IsNullOrEmpty(Convert.ToString(lookUpEdit_Reason.Text)))
            {
                XtraMessageBox.Show("Please input Reason Movement!", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lookUpEdit_Reason.Focus();
                lookUpEdit_Reason.ShowPopup();
                return;
            }

            //h.trung: check product is allow change room
            int pid = 0;
            foreach (var palletInfor in this.stockmonvetnFromDBindingList.Where(pl => pl.CanMove == true).ToList())
            {
                
                if(pid != palletInfor.ProductID)
                {
                    pid = palletInfor.ProductID;
                    Products p = new DataProcess<Products>().Select(pd => pd.ProductID == palletInfor.ProductID).FirstOrDefault();
                    if (p.IsAllowLocationChange == false && !textEdit_LocationNumberTo.Text.Contains(p.HomeRoom1) && !textEdit_LocationNumberTo.Text.Contains(p.HomeRoom2))
                    {
                        XtraMessageBox.Show("This product is not allow to change room: " + p.ProductNumber + " , Pallet: " + palletInfor.PalletID, "WMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                   
                }
                
            }





            //ko dc vi hang cho xuat
            string movestr = "move";
            int sumAfterPick = Convert.ToInt32(this.colAfterPickTo.SummaryItem.SummaryValue);
            if (sumAfterPick > 0)
            {
                lookUpEdit_Reason.EditValue = m_Joined;
                movestr = "join";
            }
            if (sumAfterPick == 0)
            {
                lookUpEdit_Reason.EditValue = m_Moved;
            }
            //    'Check that the location is Reversed
            if (LocationNumberReversed(textEdit_LocationNumberFrom.Text.Trim()).ToUpper().Equals(textEdit_LocationNumberTo.Text.Trim()))
            {
                lookUpEdit_Reason.EditValue = m_Reversed;
            }

            //'Confirmation from the user
            if (XtraMessageBox.Show("Do you want to " + movestr + " product from location " + textEdit_LocationNumberFrom.Text + " to location " + textEdit_LocationNumberTo.Text + " ?", "WMS", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                int v_varSourceLocationID = 0;
                try
                {
                    v_varSourceLocationID = Convert.ToInt32(searchLookUpEdit_FromLocationID.EditValue);
                }
                catch { }

                string v_varSourceLocationNumber = "";
                v_varSourceLocationNumber = textEdit_LocationNumberFrom.Text;

                int v_varDestinationLocationID = 0;
                try
                {
                    v_varDestinationLocationID = Convert.ToInt32(searchLookUpEdit_ToLocationID.EditValue);
                }
                catch { }

                string v_varDestinationLocationNumber = "";
                v_varDestinationLocationNumber = textEdit_LocationNumberTo.Text;

                string v_varReason = "";
                v_varReason = lookUpEdit_Reason.Text;

                int v_varEmployeeID = 0;
                try
                {
                    v_varEmployeeID = Convert.ToInt32(searchLookUpEdit_EmployeeID.EditValue);
                }
                catch { }

                string v_varUser = "";
                v_varUser = AppSetting.CurrentUser.LoginName;

                DA.Stock.StockMovementDA v_Da = new DA.Stock.StockMovementDA();

                // Update state canmove of this pallet selected
                DataProcess<object> palletDA = new DataProcess<object>();
                var sourceCanmove = this.stockmonvetnFromDBindingList.Where(p => p.CanMove == false).ToList();
                foreach (var palletInfor in sourceCanmove)
                {
                    int result = palletDA.ExecuteNoQuery("Update Pallets set canmove=0 where locationid=" + v_varSourceLocationID + " and PalletID=" + palletInfor.PalletID);
                }
                int v_ret = v_Da.STStockMovementInsert(v_varSourceLocationID
                    , v_varSourceLocationNumber, v_varDestinationLocationID, string.Empty, v_varReason, v_varEmployeeID, v_varUser);

                this.searchLookUpEdit_FromLocationID.EditValue = null;
                this.textEdit_LocationNumberFrom.Text = "";

                this.searchLookUpEdit_ToLocationID.EditValue = null;
                this.textEdit_LocationNumberTo.Text = "";

                this.searchLookUpEdit_EmployeeID.EditValue = null;
                this.textEdit_EmployeeID.Text = null;

                this.textEdit_PalletID.Text = null;

                LoadData2gridControlLocations_From();
                LoadData2gridControlLocations_To();

                this.textEdit_LocationControlCodeOriginal.Text = "";
                this.simpleButton_Update.Enabled = false;
                this.simpleButton_MoveReversed.Enabled = false;
                this.searchLookUpEdit_FromLocationID.Focus();
                this.searchLookUpEdit_FromLocationID.ShowPopup();
            }
            else
            {
                searchLookUpEdit_FromLocationID.Focus();
            }
        }
        void SimpleButton_MoveReversed_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(searchLookUpEdit_FromLocationID.EditValue)) || Convert.ToString(searchLookUpEdit_FromLocationID.EditValue).ToUpper().Equals("0"))
            {
                XtraMessageBox.Show("Please select location !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                searchLookUpEdit_FromLocationID.Focus();
                return;
            }
            if (string.IsNullOrEmpty(Convert.ToString(searchLookUpEdit_ToLocationID.EditValue)) || Convert.ToString(searchLookUpEdit_ToLocationID).ToUpper().Equals("0"))
            {
                XtraMessageBox.Show("Please select location !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                searchLookUpEdit_ToLocationID.Focus();
                return;
            }

            if (stockmonvetnToDBindingList.Count == 0)
            {
                XtraMessageBox.Show("Destination Location is empty, only move one way !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var v_TotalWeight_From = ((IList<ST_WMS_LoadStockMovementFromLocationID_Result>)gridViewLocation_From.DataSource).Sum(c => c.AfterDPQuantity * c.WeightPerPackage);

            if (v_TotalWeight_From > 4000)
            {
                XtraMessageBox.Show("Source Location is to big for this operation !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var v_TotalWeight_To = ((BindingList<ST_WMS_LoadStockMovementToLocationID_Result>)gridViewLocation_To.DataSource).Sum(c => c.AfterDPQuantity * c.WeightPerPackage);

            if (v_TotalWeight_To > 4000)
            {
                XtraMessageBox.Show("Destination Location is to big for this operation !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrEmpty(Convert.ToString(searchLookUpEdit_EmployeeID.EditValue)) || Convert.ToString(searchLookUpEdit_EmployeeID).ToUpper().Equals("0"))
            {
                XtraMessageBox.Show("Please input Forklift driver !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                searchLookUpEdit_EmployeeID.Focus();
                return;
            }

            var v_CanMove = this.stockmonvetnFromDBindingList.Where(c => c.CanMove == false).ToList().Count;

            if (v_CanMove > 0)
            {
                XtraMessageBox.Show("Product during dispatch, cannot reverse !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (XtraMessageBox.Show("Do you want to Reverse pallets from location " + textEdit_LocationNumberFrom.Text + " to location " + textEdit_LocationNumberTo.Text + " ?", "WMS", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                int v_varSourceLocationID = 0;
                try
                {
                    v_varSourceLocationID = Convert.ToInt32(searchLookUpEdit_FromLocationID.EditValue);
                }
                catch { }

                string v_varSourceLocationNumber = "";
                v_varSourceLocationNumber = textEdit_LocationNumberFrom.Text;

                int v_varDestinationLocationID = 0;
                try
                {
                    v_varDestinationLocationID = Convert.ToInt32(searchLookUpEdit_ToLocationID.EditValue);
                }
                catch { }

                string v_varDestinationLocationNumber = "";
                v_varDestinationLocationNumber = textEdit_LocationNumberTo.Text;

                string v_varReason = "";
                v_varReason = lookUpEdit_Reason.Text;

                int v_varEmployeeID = 0;
                try
                {
                    v_varEmployeeID = Convert.ToInt32(searchLookUpEdit_EmployeeID.EditValue);
                }
                catch { }

                string v_varUser = "";
                if (string.IsNullOrEmpty(v_varSourceLocationNumber) || string.IsNullOrEmpty(v_varDestinationLocationNumber))
                {
                    MessageBox.Show("Label of current Location is empty, can not process", "TPWMS", MessageBoxButtons.OK);
                    return;
                }
                v_varUser = AppSetting.CurrentUser.LoginName;

                DA.Stock.StockMovementDA v_Da = new DA.Stock.StockMovementDA();
                int v_ret = v_Da.STStockMovementInsertReversed(v_varSourceLocationID
                    , v_varSourceLocationNumber, v_varDestinationLocationID, v_varDestinationLocationNumber, v_varReason, v_varEmployeeID, v_varUser);

                this.searchLookUpEdit_FromLocationID.EditValue = null;
                this.textEdit_LocationNumberFrom.Text = "";

                this.searchLookUpEdit_ToLocationID.EditValue = null;
                this.textEdit_LocationNumberTo.Text = "";

                this.searchLookUpEdit_EmployeeID.EditValue = null;
                this.textEdit_EmployeeID.Text = null;

                this.textEdit_PalletID.Text = null;

                LoadData2gridControlLocations_From();
                LoadData2gridControlLocations_To();

                this.textEdit_LocationControlCodeOriginal.Text = "";
                this.simpleButton_Update.Enabled = false;
                this.simpleButton_MoveReversed.Enabled = false;

                this.searchLookUpEdit_FromLocationID.Focus();
            }
        }
        void SimpleButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void SimpleButton_Report_Click(object sender, EventArgs e)
        {
            int v_index = radioGroup_OptionReport.SelectedIndex;
            string v_From = string.Empty;
            string v_To = string.Empty;

            try
            {
                v_From = Convert.ToDateTime(dateEdit_From.EditValue).ToString("yyyy-MM-dd");
            }
            catch { }

            try
            {
                v_To = Convert.ToDateTime(dateEdit_To.EditValue).ToString("yyyy-MM-dd");
            }
            catch { }

            #region Product
            if (v_index == 0)
            {
                bool v_IsPrint = false;

                DataProcess<STStockMovementReviewByDate_Result> v_Da = new DataProcess<STStockMovementReviewByDate_Result>();
                var v_list = v_Da.Executing("STStockMovementReviewByDate @FromDate={0},@ToDate={1}", v_From, v_To).ToList();

                ReportFile.rptStockMovementReviewByDate v_Report = new ReportFile.rptStockMovementReviewByDate();
                v_Report.DataSource = v_list;
                v_Report.RequestParameters = false;
                ReportPrintToolWMS printTool = new ReportPrintToolWMS(v_Report);
                printTool.ShowPreview();

                if (v_IsPrint)
                {
                    printTool.Print();
                }
            }
            #endregion Product

            #region Location
            else if (v_index == 1)
            {
                bool v_IsPrint = false;

                DataProcess<STStockMovementReviewByDate_Result> v_Da = new DataProcess<STStockMovementReviewByDate_Result>();
                var v_list = v_Da.Executing("STStockMovementReviewByDate @FromDate={0},@ToDate={1},@varStoreID={2}", v_From, v_To,AppSetting.CurrentUser.StoreID).ToList();

                ReportFile.rptStockMovementReviewByLocation v_Report = new ReportFile.rptStockMovementReviewByLocation();
                v_Report.DataSource = v_list;
                v_Report.RequestParameters = false;
                ReportPrintToolWMS printTool = new ReportPrintToolWMS(v_Report);
                printTool.ShowPreview();

                if (v_IsPrint)
                {
                    printTool.Print();
                }
            }
            #endregion Location

            #region Customer
            else if (v_index == 2)
            {
                bool v_IsPrint = false;

                int v_CustomerID = 0;

                try
                {
                    v_CustomerID = Convert.ToInt32(searchLookUpEdit_CustomerID.EditValue);
                }
                catch { }

                DataProcess<STStockMovementReviewByDate_Result> v_Da = new DataProcess<STStockMovementReviewByDate_Result>();
                var v_list = v_Da.Executing("STStockMovementReviewByDate @FromDate={0},@ToDate={1},@CustomerID={2}", v_From, v_To, v_CustomerID).ToList();

                ReportFile.rptStockMovementReviewByCustomer v_Report = new ReportFile.rptStockMovementReviewByCustomer();
                v_Report.DataSource = v_list;
                v_Report.RequestParameters = false;
                ReportPrintToolWMS printTool = new ReportPrintToolWMS(v_Report);
                printTool.ShowPreview();

                if (v_IsPrint)
                {
                    printTool.Print();
                }
            }

            #endregion Customer
        }
        void SimpleButton1_2_Click(object sender, EventArgs e)
        {
            if (searchLookUpEdit_FromLocationID.GetSelectedDataRow() != null)
            {
                // reset location to data
                this.searchLookUpEdit_ToLocationID.EditValue = null;
                gridControlLocations_To.DataSource = null;

                DA.Locations location = searchLookUpEdit_FromLocationID.GetSelectedDataRow() as DA.Locations;
                string v_LocNumber = location.LocationNumber;
                string v_LocDeep = v_LocNumber.Substring(v_LocNumber.Length - 1);
                if (v_LocDeep.Trim() == "1")
                {
                    v_LocNumber = v_LocNumber.Substring(0, v_LocNumber.Length - 1) + "2";
                }
                else
                {
                    v_LocNumber = v_LocNumber.Substring(0, v_LocNumber.Length - 1) + "1";
                }
                var Local_Locations = AppSetting.LocationList.Where(lo => lo.LocationNumber == v_LocNumber).FirstOrDefault();
                if (Local_Locations != null && Local_Locations.Used == 0)
                {
                    MessageBox.Show("This location is locked!");
                    simpleButton_Update.Enabled = false;
                    return;
                }
                else
                {
                    if (Local_Locations != null)
                    {
                        searchLookUpEdit_ToLocationID.EditValue = Local_Locations.LocationID;
                        LoadData2gridControlLocations_To();
                        this.textEdit_LocationNumberTo.Text = v_LocNumber;
                        this.textEdit_EmployeeID.Focus();
                    }
                    else
                    {
                        this.textEdit_LocationNumberTo.Text = v_LocNumber;
                        searchLookUpEdit_ToLocationID.EditValue = null;
                    }

                    lookUpEdit_Reason.EditValue = m_Reversed;
                    simpleButton_Update.Enabled = true;
                    simpleButton_MoveReversed.Enabled = true;
                }
            }
        }

        void RepItemButtonEdit_From_PrintLabel_Click(object sender, EventArgs e)
        {
            bool v_IsPrint = true;
            int v_PalletID = 0;

            try
            {
                v_PalletID = Convert.ToInt32(gridViewLocation_From.GetRowCellValue(gridViewLocation_From.FocusedRowHandle, "PalletID"));
            }
            catch { }

            DataProcess<STLabel1Label_Result> v_Da = new DataProcess<STLabel1Label_Result>();
            var v_list = v_Da.Executing("STLabel1Label @PalletID ={0}", v_PalletID).ToList();

            ReportFile.rptLabel_Barcode v_Report = new ReportFile.rptLabel_Barcode();
            v_Report.DataSource = v_list;
            v_Report.RequestParameters = false;
            v_Report.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
            ReportPrintToolWMS printTool = new ReportPrintToolWMS(v_Report);
            printTool.Print();
        }
        void RepItemButtonEdit_From_PrintDecalLabel_Click(object sender, EventArgs e)
        {
            int v_PalletID = 0;

            try
            {
                v_PalletID = Convert.ToInt32(gridViewLocation_From.GetRowCellValue(gridViewLocation_From.FocusedRowHandle, "PalletID"));
            }
            catch { }

            DataProcess<STLabel1Label_Result> v_Da = new DataProcess<STLabel1Label_Result>();
            var v_list = v_Da.Executing("STLabel1Label @PalletID ={0}", v_PalletID).ToList();

            ReportFile.rptLabelDecal v_Report = new ReportFile.rptLabelDecal();
            v_Report.DataSource = v_list;
            v_Report.xrLabelRO.Text = v_list.FirstOrDefault().ReceivingOrderNumber;
            v_Report.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
            v_Report.RequestParameters = false;
            ReportPrintToolWMS printTool = new ReportPrintToolWMS(v_Report);
            printTool.AutoShowParametersPanel = false;
            printTool.Print();
        }

        void RepItemButtonEdit_From_PalletInfo_DoubleClick(object sender, EventArgs e)
        {
            int v_CustomerID = 0;
            int v_ProductID = 0;

            try
            {
                v_CustomerID = Convert.ToInt32(gridViewLocation_From.GetRowCellValue(gridViewLocation_From.FocusedRowHandle, "CustomerID"));
            }
            catch { }

            try
            {
                v_ProductID = Convert.ToInt32(gridViewLocation_From.GetRowCellValue(gridViewLocation_From.FocusedRowHandle, "ProductID"));
            }
            catch { }

            UI.WarehouseManagement.frm_WM_PalletInfo frm = new WarehouseManagement.frm_WM_PalletInfo(v_CustomerID, v_ProductID);
            frm.ShowInTaskbar = false;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.WindowState = FormWindowState.Normal;
            frm.BringToFront();
            frm.Show();
        }

        void RepItemButtonEdit_To_PrintLabel_Click(object sender, EventArgs e)
        {
            bool v_IsPrint = false;
            int v_PalletID = 0;

            try
            {
                v_PalletID = Convert.ToInt32(gridViewLocation_To.GetRowCellValue(gridViewLocation_To.FocusedRowHandle, "PalletID"));
            }
            catch { }

            DataProcess<STLabel1Label_Result> v_Da = new DataProcess<STLabel1Label_Result>();
            var v_list = v_Da.Executing("STLabel1Label @PalletID ={0}", v_PalletID).ToList();

            ReportFile.rptLabel_Barcode v_Report = new ReportFile.rptLabel_Barcode();
            v_Report.DataSource = v_list;
            //v_Report.Parameters["PalletID"].Value = v_PalletID;
            v_Report.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
            v_Report.RequestParameters = false;
            ReportPrintToolWMS printTool = new ReportPrintToolWMS(v_Report);
            printTool.ShowPreview();

            if (v_IsPrint)
            {
                printTool.Print();
            }
        }
        void RepItemButtonEdit_To_PrintDecalLabel_Click(object sender, EventArgs e)
        {
            int v_PalletID = 0;
            try
            {
                v_PalletID = Convert.ToInt32(gridViewLocation_To.GetRowCellValue(gridViewLocation_To.FocusedRowHandle, "PalletID"));
            }
            catch { }
            DataProcess<STLabel1Label_Result> v_Da = new DataProcess<STLabel1Label_Result>();
            var v_list = v_Da.Executing("STLabel1Label @PalletID ={0}", v_PalletID).ToList();

            ReportFile.rptLabelDecal v_Report = new ReportFile.rptLabelDecal();
            v_Report.DataSource = v_list;
            v_Report.xrLabelRO.Text = "";
            v_Report.RequestParameters = false;
            ReportPrintToolWMS printTool = new ReportPrintToolWMS(v_Report);
            printTool.Print();
        }

        void RepItemButtonEdit_To_PalletInfo_DoubleClick(object sender, EventArgs e)
        {
            int v_CustomerID = 0;
            int v_ProductID = 0;

            try
            {
                v_CustomerID = Convert.ToInt32(gridViewLocation_To.GetRowCellValue(gridViewLocation_To.FocusedRowHandle, "CustomerID"));
            }
            catch { }

            try
            {
                v_ProductID = Convert.ToInt32(gridViewLocation_To.GetRowCellValue(gridViewLocation_To.FocusedRowHandle, "ProductID"));
            }
            catch { }

            UI.WarehouseManagement.frm_WM_PalletInfo frm = new WarehouseManagement.frm_WM_PalletInfo(v_CustomerID, v_ProductID);
            frm.ShowInTaskbar = false;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show(this);
        }

        void SearchLookUpEdit_FromLocationID_EditValueChanged(object sender, EventArgs e)
        {
            int v_FromLoactionID = 0;

            try
            {
                v_FromLoactionID = Convert.ToInt32(searchLookUpEdit_FromLocationID.EditValue);
            }
            catch { }

            DA.Locations location = searchLookUpEdit_FromLocationID.GetSelectedDataRow() as DA.Locations;
            if (location == null) return;
            if (v_FromLoactionID > 0)
            {
                textEdit_LocationNumberFrom.EditValue = Convert.ToString(location.LocationNumber);
            }
            else
            {
                textEdit_LocationNumberFrom.EditValue = "";
            }

            DA.Stock.StockMovementDA v_Da = new DA.Stock.StockMovementDA();
            int v_Ret = v_Da.STStockMovementLocationIDChange(v_FromLoactionID);

            LoadData2gridControlLocations_From();
        }

        void SearchLookUpEdit_EmployeeID_EditValueChanged(object sender, EventArgs e)
        {
            STVSEmployeesListForLookup_Result curr = searchLookUpEdit_EmployeeID.GetSelectedDataRow() as STVSEmployeesListForLookup_Result;
            if (string.IsNullOrEmpty(Convert.ToString(searchLookUpEdit_EmployeeID.EditValue)))
            {
                textEdit_EmployeeID.EditValue = null;
            }
            else
            {
                if (curr == null) return;
                textEdit_EmployeeID.EditValue = curr.EmployeeID;
            }
        }

        void CheckEdit_MovetoFloor_CheckedChanged(object sender, EventArgs e)
        {
            LoadData2searchLookUpEdit_ToLocationID_MovetoFloor();
        }
        void CheckEdit_Free_CheckedChanged(object sender, EventArgs e)
        {
            LoadData2searchLookUpEdit_ToLocationID_Free();
        }

        #endregion Event

        #region LoadData
        void LoadData2searchLookUpEdit_LocationFromID()
        {
            var toLocation = AppSetting.LocationList.ToList();
            searchLookUpEdit_FromLocationID.Properties.DataSource = toLocation;
            searchLookUpEdit_FromLocationID.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationNumberShort"));
            searchLookUpEdit_FromLocationID.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationNumber"));

            if (string.IsNullOrEmpty(Convert.ToString(searchLookUpEdit_FromLocationID.EditValue)))
            {
                textEdit_LocationNumberFrom.EditValue = "";
            }
        }
        void LoadData2searchLookUpEdit_ToLocationID_Free()
        {
            if (checkEdit_Free.Checked == true)
            {
                DataProcess<STComboLocationIDFree_Result> combolocationFreeDA = new DataProcess<STComboLocationIDFree_Result>();
                checkEdit_MovetoFloor.Checked = false;
                searchLookUpEdit_ToLocationID.Properties.DataSource = combolocationFreeDA.Executing("STComboLocationIDFree");
                searchLookUpEdit_ToLocationID.Focus();
                searchLookUpEdit_ToLocationID.ShowPopup();
            }
            else
            {
                lst_ToLocationSource = AppSetting.LocationList.ToList();
                searchLookUpEdit_ToLocationID.Properties.DataSource = lst_ToLocationSource;
            }
        }
        void LoadData2searchLookUpEdit_ToLocationID_MovetoFloor()
        {
            if (checkEdit_MovetoFloor.Checked == true)
            {
                DataProcess<STComboLocationIDFreeFloor_Result> combolocationFreeFloorDA = new DataProcess<STComboLocationIDFreeFloor_Result>();
                checkEdit_Free.Checked = false;
                searchLookUpEdit_ToLocationID.Properties.DataSource = combolocationFreeFloorDA.Executing("STComboLocationIDFreeFloor");
                searchLookUpEdit_ToLocationID.Focus();
                searchLookUpEdit_ToLocationID.ShowPopup();
            }
            else
            {
                lst_ToLocationSource = AppSetting.LocationList.ToList();
                searchLookUpEdit_ToLocationID.Properties.DataSource = lst_ToLocationSource;
            }
        }
        void LoadData2gridControlLocations_From()
        {
            int i_LocationID = 0;

            try
            {
                i_LocationID = Convert.ToInt32(searchLookUpEdit_FromLocationID.EditValue);
            }
            catch { }

            try
            {
                var dataSouce = (new DataProcess<ST_WMS_LoadStockMovementFromLocationID_Result>()).Executing("ST_WMS_LoadStockMovementFromLocationID @LocationID={0}", i_LocationID).ToList();
                this.stockmonvetnFromDBindingList =
                    new BindingList<ST_WMS_LoadStockMovementFromLocationID_Result>(dataSouce.ToList());
                gridControlLocations_From.DataSource = this.stockmonvetnFromDBindingList;
                this.gridViewLocation_From.SelectAll();

            }
            catch
            {
                gridControlLocations_From.DataSource = null;
            }
        }
        void LoadData2gridControlLocations_To()
        {
            int i_LocationID = 0;

            try
            {
                i_LocationID = Convert.ToInt32(searchLookUpEdit_ToLocationID.EditValue);
            }
            catch { }

            try
            {
                var dataSouce = (new DataProcess<ST_WMS_LoadStockMovementToLocationID_Result>()).Executing("ST_WMS_LoadStockMovementToLocationID @LocationID={0}", i_LocationID).ToList();
                this.stockmonvetnToDBindingList =
                    new BindingList<ST_WMS_LoadStockMovementToLocationID_Result>(dataSouce.ToList());
                gridControlLocations_To.DataSource = stockmonvetnToDBindingList;
            }
            catch
            {
                gridControlLocations_To.DataSource = null;
            }
        }
        void LoadData2lookUpEdit_Reason()
        {
            var tblReason = new System.Data.DataTable();
            tblReason.Columns.Add("Reason");

            var moveRow = tblReason.NewRow();
            moveRow["Reason"] = m_Moved;
            tblReason.Rows.Add(moveRow);

            var joinRow = tblReason.NewRow();
            joinRow["Reason"] = m_Joined;
            tblReason.Rows.Add(joinRow);

            var reversed = tblReason.NewRow();
            reversed["Reason"] = m_Reversed;
            tblReason.Rows.Add(reversed);

            this.lookUpEdit_Reason.Properties.DataSource = tblReason;
            this.lookUpEdit_Reason.Properties.ValueMember = "Reason";
            this.lookUpEdit_Reason.Properties.DisplayMember = "Reason";
        }
        void LoadData2searchLookUpEdit_EmployeeID()
        {
            this.searchLookUpEdit_EmployeeID.Properties.DataSource = AppSetting.EmployessList;
            this.searchLookUpEdit_EmployeeID.Properties.ValueMember = "EmployeeID";
            this.searchLookUpEdit_EmployeeID.Properties.DisplayMember = "VietnamName";

            textEdit_EmployeeID.EditValue = searchLookUpEdit_EmployeeID.EditValue;

        }
        void LoadData2searchlookUpEdit_CustomerID()
        {
            searchLookUpEdit_CustomerID.Properties.DataSource = (new DataProcess<STcomboCustomerID_Result>()).Executing("STcomboCustomerID @varStoreID={0}", AppSetting.StoreID).ToList();
        }
        #endregion LoadData

        #region Function
        string LocationNumberReversed(string varLocationNumber)
        {
            string v_Ret = "";

            int v_LocDeep = 0;

            try
            {
                v_LocDeep = Convert.ToInt32(varLocationNumber.Substring(varLocationNumber.Length - 1, 1));
            }
            catch { }

            if (v_LocDeep == 1)
            {
                v_Ret = varLocationNumber.Substring(0, varLocationNumber.Length - 1) + "2";
            }
            else
            {
                v_Ret = varLocationNumber.Substring(0, varLocationNumber.Length - 1) + "1";
            }

            return v_Ret;
        }

        #endregion Function


        private void frm_ST_StockMovementNew_Shown(object sender, EventArgs e)
        {
            if (LocationFromID != 0)
            {
                searchLookUpEdit_FromLocationID.EditValue = LocationFromID;
                searchLookUpEdit_ToLocationID.Focus();
                searchLookUpEdit_ToLocationID.ShowPopup();
            }
            else
            {
                searchLookUpEdit_FromLocationID.Focus();
                searchLookUpEdit_FromLocationID.ShowPopup();
            }
        }

        private void searchLookUpEdit_FromLocationID_Leave(object sender, EventArgs e)
        {
            if (this.searchLookUpEdit_FromLocationID.EditValue == null) return;
            this.searchLookUpEdit_ToLocationID.Focus();
            this.searchLookUpEdit_ToLocationID.ShowPopup();
        }

        private void ValidatePalletIdInput()
        {
            if (!string.IsNullOrEmpty(textEdit_PalletID.Text))
            {
                int v_PalletID = 0;
                int v_LocationID = 0;
                try
                {
                    v_PalletID = Convert.ToInt32(textEdit_PalletID.Text);
                }
                catch { }
                var v_List = (new DataProcess<Pallets>()).Select(c => c.PalletID == v_PalletID && c.CurrentQuantity > 0).FirstOrDefault();

                try
                {
                    v_LocationID = v_List.LocationID;
                }
                catch { }

                if (v_LocationID <= 0)
                {
                    XtraMessageBox.Show("This Pallet ID is not exist !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.textEdit_PalletID.Focus();
                    this.textEdit_PalletID.SelectAll();
                }
                else
                {
                    this.searchLookUpEdit_FromLocationID.EditValue = v_LocationID;
                    this.SearchLookUpEdit_FromLocationID_EditValueChanged(null, null);
                    this.searchLookUpEdit_ToLocationID.Focus();
                    this.searchLookUpEdit_ToLocationID.ShowPopup();
                }
            }
        }

        private void textEdit_EmployeeID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                if (string.IsNullOrEmpty(this.textEdit_EmployeeID.Text)) return;

                int employeeID = Convert.ToInt32(this.textEdit_EmployeeID.Text);
                DataProcess<Employees> dataProcess = new DataProcess<Employees>();
                var employeeInfo = dataProcess.Select(em => em.EmployeeID == employeeID).FirstOrDefault();
                if (employeeInfo == null)
                {
                    MessageBox.Show("Please enter correct Employee ID, please check Active and \n Performance Status!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                this.searchLookUpEdit_EmployeeID.EditValue = employeeInfo.EmployeeID;
            }
        }

        private void textEdit_PalletID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                this.ValidatePalletIdInput();
            }
        }

        private void btn_PrintStockInOne_Click(object sender, EventArgs e)
        {
            if (searchLookUpEdit_FromLocationID.EditValue == null) return;
            int locationID = Convert.ToInt32(searchLookUpEdit_FromLocationID.EditValue);
            var dataSource = FileProcess.LoadTable("STStockOneLocationReport @LocationID=" + locationID);
            rptStockOneLocation rptStockOneLocationReport = new rptStockOneLocation();
            rptStockOneLocationReport.DataSource = dataSource;
            rptStockOneLocationReport.ShowPrintMarginsWarning = false;
            ReportPrintToolWMS printTool = new ReportPrintToolWMS(rptStockOneLocationReport);
            printTool.AutoShowParametersPanel = false;
            printTool.Print();
        }

        private void SearchNewLocation()
        {
            if (Convert.ToString(searchLookUpEdit_FromLocationID.EditValue).ToUpper().Equals(Convert.ToString(searchLookUpEdit_ToLocationID.EditValue).ToUpper()))
            {
                XtraMessageBox.Show("You can not move products to the same location !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                searchLookUpEdit_ToLocationID.Focus();
            }
            else
            {
                DA.Locations tolocation = searchLookUpEdit_ToLocationID.GetSelectedDataRow() as DA.Locations;
                if (tolocation == null) return;

                if (string.IsNullOrEmpty(Convert.ToString(searchLookUpEdit_ToLocationID.EditValue)))
                {
                    textEdit_LocationNumberTo.EditValue = null;
                }
                else
                {
                    ToLocationCode = tolocation.LocationCode;
                }
            }
        }

        private void searchLookUpEdit_ToLocationID_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.Value == null) return;
            this.searchLookUpEdit_ToLocationID.EditValue = e.Value;
            this.SearchNewLocation();
        }

        private void searchLookUpEdit_ToLocationID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            string isUsed = Convert.ToString(this.searchLookUpEdit_ToLocationID.GetColumnValue("UsedEx"));
            if (isUsed.Equals("No"))
            {
                var dl = MessageBox.Show("Only Supervisor/CCC/Manager is allowed to move the pallet to the locked location !", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dl.Equals(DialogResult.No)) return;
            }
            this.SearchNewLocation();
        }

        private void repositoryItemHyperLinkEditPalletInfo_Click(object sender, EventArgs e)
        {
            int v_CustomerID = 0;
            int v_ProductID = 0;

            try
            {
                v_CustomerID = Convert.ToInt32(gridViewLocation_From.GetRowCellValue(gridViewLocation_From.FocusedRowHandle, "CustomerID"));
            }
            catch { }

            try
            {
                v_ProductID = Convert.ToInt32(gridViewLocation_From.GetRowCellValue(gridViewLocation_From.FocusedRowHandle, "ProductID"));
            }
            catch { }

            UI.WarehouseManagement.frm_WM_PalletInfo frm = new WarehouseManagement.frm_WM_PalletInfo(v_CustomerID, v_ProductID);
            frm.ShowInTaskbar = false;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.WindowState = FormWindowState.Normal;
            frm.BringToFront();
            frm.Show();
        }

        private void repositoryItemHyperLinkEditPalletInfor2_Click(object sender, EventArgs e)
        {
            int v_CustomerID = 0;
            int v_ProductID = 0;

            try
            {
                v_CustomerID = Convert.ToInt32(gridViewLocation_To.GetRowCellValue(gridViewLocation_To.FocusedRowHandle, "CustomerID"));
            }
            catch { }

            try
            {
                v_ProductID = Convert.ToInt32(gridViewLocation_To.GetRowCellValue(gridViewLocation_To.FocusedRowHandle, "ProductID"));
            }
            catch { }

            UI.WarehouseManagement.frm_WM_PalletInfo frm = new WarehouseManagement.frm_WM_PalletInfo(v_CustomerID, v_ProductID);
            frm.ShowInTaskbar = false;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show(this);
        }

        private void repositoryItemHyperLinkEditRO_Click(object sender, EventArgs e)
        {
            string orderNumber = this.gridViewLocation_From.GetFocusedRowCellValue("ReceivingOrderNumber").ToString();
            int receivingOrderID = Convert.ToInt32(orderNumber.Substring(3, orderNumber.Length - 3));
            frm_WM_ReceivingOrders receivingOrder = frm_WM_ReceivingOrders.Instance;
            receivingOrder.ReceivingOrderIDFind = receivingOrderID;
            receivingOrder.Show();
            receivingOrder.WindowState = FormWindowState.Maximized;
            receivingOrder.BringToFront();
        }

        private void repositoryItemHyperLinkEditInoutView_Click(object sender, EventArgs e)
        {
            int customerID = Convert.ToInt32(this.gridViewLocation_To.GetFocusedRowCellValue("CustomerID"));
            this.DisplayCustomerInfo(customerID);
        }

        private void repositoryItemHyperLinkEditRO2_Click(object sender, EventArgs e)
        {
            string orderNumber = this.gridViewLocation_From.GetFocusedRowCellValue("ReceivingOrderNumber").ToString();
            int receivingOrderID = Convert.ToInt32(orderNumber.Substring(3, orderNumber.Length - 3));
            frm_WM_ReceivingOrders receivingOrder = frm_WM_ReceivingOrders.Instance;
            receivingOrder.ReceivingOrderIDFind = receivingOrderID;
            receivingOrder.Show();
            receivingOrder.WindowState = FormWindowState.Maximized;
            receivingOrder.BringToFront();
        }

        private void repositoryItemHyperLinkEditInoutView2_Click(object sender, EventArgs e)
        {
            int customerID = Convert.ToInt32(this.gridViewLocation_From.GetFocusedRowCellValue("CustomerID"));
            this.DisplayCustomerInfo(customerID);
        }

        private void DisplayCustomerInfo(int customerID)
        {
            var currentCustomer = AppSetting.CustomerListAll.Where(c => c.CustomerID == customerID).FirstOrDefault();
            MasterSystemSetup.frm_MSS_Customers frmCustomer = MasterSystemSetup.frm_MSS_Customers.Instance;
            frmCustomer.CurrentCustomers = currentCustomer;
            frmCustomer.WindowState = FormWindowState.Normal;
            frmCustomer.BringToFront();
            frmCustomer.Show();
        }

        private void simpleButtonToLostLocation_Click(object sender, EventArgs e)
        {
            //Code here to move the pallet to Lost Locatation of the current Room
            //StoreProcedure: STStockMovementLocationIDChangeToLost. Chú ý nếu Room có LostProductLocationID là NULL thì không được chuyển qua
            int palletID = Convert.ToInt32(this.gridViewLocation_From.GetFocusedRowCellValue("PalletID"));
            if (palletID <= 0) return;
            frm_ST_ReasonLostLocation frmReason = new frm_ST_ReasonLostLocation();
            if (frmReason.Enabled == false) return;
            frmReason.ShowDialog();
            if (frmReason.EmployeeID <= 0) return;
            DataProcess<object> dataProcess = new DataProcess<object>();
            int result = dataProcess.ExecuteNoQuery("STStockMovementLocationIDChangeToLost @PalletID=" + palletID
                + ", @varReason=N'" + frmReason.Reasons
                + "',@varEmpoloyeeID=" + frmReason.EmployeeID
                + ",@varUser='" + AppSetting.CurrentUser.LoginName + "'");
            if (result > 0)
                MessageBox.Show("Successfully Moved Pallets to Lost Products Location !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void rpi_chk_CanMoveFrom_CheckedChanged(object sender, EventArgs e)
        {
            var chk = (CheckEdit)sender;
            int isCanMove = 0;
            int palletID = Convert.ToInt32(this.gridViewLocation_From.GetFocusedRowCellValue("PalletID"));
            if (chk.Checked)
            {
                isCanMove = 1;
            }
            DataProcess<object> palletDA = new DataProcess<object>();
            int result = palletDA.ExecuteNoQuery("Update Pallets set canmove=" + isCanMove + " where PalletID=" + palletID);
        }

        private void searchLookUpEdit_ToLocationID_Validating(object sender, CancelEventArgs e)
        {
            if (this.searchLookUpEdit_ToLocationID.EditValue == null)
            {
                this.textEdit_LocationNumberTo.Text = string.Empty;
                return;
            }

            // Reset data source
            this.gridControlLocations_To.DataSource = null;

            if (lst_ToLocationSource != null && lst_ToLocationSource.Count > 0)
            {
                if (textEdit_LocationNumberFrom.Text.Length <= 0 || textEdit_LocationNumberFrom.Text.Length <= 0)
                {
                    e.Cancel = true;
                    return;
                }

                int locationToID = Convert.ToInt32(this.searchLookUpEdit_ToLocationID.EditValue);
                string locationNumberTo = AppSetting.LocationList.Where(l => l.LocationID == locationToID).FirstOrDefault().LocationNumber;
                textEdit_LocationNumberTo.Text = locationNumberTo;
                if (textEdit_LocationNumberFrom.Text.Trim() == locationNumberTo.Trim())
                {
                    e.Cancel = true;
                }
            }
        }

        private void gridViewLocation_From_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            var columType = (DevExpress.XtraGrid.GridColumnSummaryItem)e.Item;
            switch (columType.FieldName)
            {
                case "CustomerRef":
                    float sum = 0;
                    foreach (var item in this.stockmonvetnFromDBindingList)
                    {
                        sum += item.AfterDPQuantity * item.WeightPerPackage;
                    }
                    e.TotalValue = sum;
                    break;
                case "ReceivingOrderDate":
                    float sumMove = 0;
                    foreach (var item in this.stockmonvetnFromDBindingList)
                    {
                        if (!item.CanMove) continue;
                        sumMove += item.AfterDPQuantity * item.WeightPerPackage;
                    }
                    e.TotalValue = sumMove;
                    break;
            }
        }

        private void gridViewLocation_From_CustomDrawFooterCell(object sender, FooterCellCustomDrawEventArgs e)
        {

        }

        private void gridControlLocations_From_Click(object sender, EventArgs e)
        {

        }

        private void rpi_hle_ProductNumber_Click(object sender, EventArgs e)
        {
            int v_ProductID = 0;
            try
            {
                v_ProductID = Convert.ToInt32(gridViewLocation_From.GetRowCellValue(gridViewLocation_From.FocusedRowHandle, "ProductID"));
            }
            catch { }

            if (v_ProductID > 0)
            {

                MasterSystemSetup.frm_MSS_Products frm = MasterSystemSetup.frm_MSS_Products.Instance;
                frm.ProductIDLookup = v_ProductID;
                frm.ShowInTaskbar = false;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.WindowState = FormWindowState.Normal;
                frm.BringToFront();
                frm.Show();
            }
        }

        private void frm_ST_StockMovementNew_KeyDown(object sender, KeyEventArgs e)
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
    }
}