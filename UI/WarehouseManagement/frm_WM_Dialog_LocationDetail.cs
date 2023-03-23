using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DA;
using DevExpress.XtraReports.UI;
using UI.Helper;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_Dialog_LocationDetail : Common.Controls.frmBaseForm
    {
        int m_PalletID = 0;
        int m_Flag = 0;
        string m_Remark = String.Empty;
        bool isPalletID = false;
        public frm_WM_Dialog_LocationDetail()
        {
            InitializeComponent();

            SetEvent();
        }

        public frm_WM_Dialog_LocationDetail(int i_PalletID, int i_Flag, bool isPallet)
        {
            InitializeComponent();

            this.m_PalletID = i_PalletID;

            this.m_Flag = i_Flag;
            this.isPalletID = isPallet;

            SetEvent();
        }

        public frm_WM_Dialog_LocationDetail(int i_PalletID, int i_Flag, string i_Remark, bool isPallet)
        {
            InitializeComponent();

            this.m_PalletID = i_PalletID;

            this.m_Flag = i_Flag;
            this.isPalletID = isPallet;

            this.m_Remark = i_Remark;

            SetEvent();
        }

        void Frm_WM_Dialog_LocationDetail_Load(object sender, EventArgs e)
        {
            try
            {
                if (m_Flag == 3)
                {
                    gridControlLocationsDetail.DataSource = (new DA.DataProcess<DA.STFindLocation_LocationDetails_Flag3_Result>()).Executing("STFindLocation_LocationDetails @Flag=3, @PalletID={0}", m_PalletID).ToList();
                }
                else
                {
                    if (m_Flag == 0)
                    {
                        //gridControlLocationsDetail.DataSource = (new DA.DataProcess<DA.STFindLocation_LocationDetails_Flag0_Result>()).Executing("STFindLocation_LocationDetails_Flag0 @PalletID={0}", m_PalletID).ToList();
                        gridControlLocationsDetail.DataSource = (new DA.DataProcess<DA.STLocationFind_Result>()).Executing("STLocationFind @LocationID=0, @PalletID={0}", m_PalletID).ToList();
                    }
                    else
                    {
                        if (m_Flag == 1)
                        {
                            gridControlLocationsDetail.DataSource = (new DA.DataProcess<DA.STFindLocation_LocationDetails_Result>()).Executing("STFindLocation_LocationDetails @Flag=1, @PalletID={0},@PalletRemark={1}", 0, this.m_Remark).ToList();
                        }
                        else
                        {
                            gridControlLocationsDetail.DataSource = (new DA.DataProcess<DA.STFindLocation_LocationDetails_Result>()).Executing("STFindLocation_LocationDetails @Flag=2, @PalletID={0},@PalletRemark={1}", 0, this.m_Remark).ToList();
                        }
                    }
                }

                //Load location in out
                this.LoadLocationInOut();

            }
            catch (Exception ex)
            {
                gridControlLocationsDetail.DataSource = null;
            }

        }
        void SetEvent()
        {
            this.Load += Frm_WM_Dialog_LocationDetail_Load;

            repItemHyperLinkEdit_Location_ReceivingOrderID.Click += RepItemHyperLinkEdit_Location_ReceivingOrderID_DoubleClick;
            repItemHyperLinkEdit_Location_PalletID.Click += RepItemHyperLinkEdit_Location_PalletID_DoubleClick;
            repositoryItemButtonEdit_PalletInfor.Click += RepositoryItemButtonEdit_PalletInfor_DoubleClick;

            btn_PrintLocation_A41.Click += Btn_PrintLocation_A4_ItemClick;
            btn_PrintLocation_A51.Click += Btn_PrintLocation_A5_ItemClick;
            btn_PrintLable1.Click += Btn_PrintLable_ItemClick;
            btn_StockMovement1.Click += Btn_StockMovement_ItemClick;
            this.btnClose.Click += BtnClose_Click;
        }

        private void LoadLocationInOut()
        {
            // If current PalletID is PalletID
            if (this.isPalletID)
            {
                // Get locationID of current palletID
                DataProcess<Pallets> palletDA = new DataProcess<Pallets>();
                var currenPalletInfo = palletDA.Select(p => p.PalletID == this.m_PalletID).FirstOrDefault();
                if (currenPalletInfo != null)
                {
                    this.m_PalletID = currenPalletInfo.LocationID;
                }
            }

            // just only received locationID
            this.grdDependInfo.DataSource = FileProcess.LoadTable("STLocation_In_Out @LocationID=" + this.m_PalletID);
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void Btn_StockMovement_ItemClick(object sender, EventArgs e)
        {
            int v_LocationID = 0;
            try
            {
                v_LocationID = Convert.ToInt32(gridViewLocationDetail.GetRowCellValue(gridViewLocationDetail.FocusedRowHandle, "LocationID"));
            }
            catch { }

            DA.Stock.StockMovementDA v_DaStock = new DA.Stock.StockMovementDA();
            v_DaStock.STStockMovementLocationIDChange(v_LocationID);
            UI.StockTake.frm_ST_StockMovementNew frm = new StockTake.frm_ST_StockMovementNew(v_LocationID);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowInTaskbar = true;
            frm.Show();
        }
        void Btn_PrintLable_ItemClick(object sender, EventArgs e)
        {
            bool v_IsPrint = false;
            int v_PalletID = 0;

            try
            {
                v_PalletID = Convert.ToInt32(gridViewLocationDetail.GetRowCellValue(gridViewLocationDetail.FocusedRowHandle, "PalletID"));
            }
            catch { }

            DataProcess<STLabel1Label_Result> v_Da = new DataProcess<STLabel1Label_Result>();
            var v_list = v_Da.Executing("STLabel1Label @PalletID ={0}", v_PalletID).ToList();

            ReportFile.rptLabel_Barcode v_Report = new ReportFile.rptLabel_Barcode();
            v_Report.DataSource = v_list;
            v_Report.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
            v_Report.RequestParameters = false;
            ReportPrintToolWMS printTool = new ReportPrintToolWMS(v_Report);
            printTool.ShowPreview();

            if (v_IsPrint)
            {
                printTool.Print();
            }
        }
        void Btn_PrintLocation_A5_ItemClick(object sender, EventArgs e)
        {
            bool v_IsPrint = false;
            int v_LocationID = 0;

            try
            {
                v_LocationID = Convert.ToInt32(gridViewLocationDetail.GetRowCellValue(gridViewLocationDetail.FocusedRowHandle, "LocationID"));
            }
            catch { }

            DataProcess<STStockOneLocationReport_Result> v_Da = new DataProcess<STStockOneLocationReport_Result>();
            var v_list = v_Da.Executing("STStockOneLocationReport @LocationID ={0}", v_LocationID).ToList();

            ReportFile.rptStockOneLocation v_Report = new ReportFile.rptStockOneLocation();
            v_Report.DataSource = v_list;
            //v_Report.Parameters["PalletID"].Value = v_PalletID;
            v_Report.RequestParameters = false;
            ReportPrintToolWMS printTool = new ReportPrintToolWMS(v_Report);
            printTool.ShowPreview();

            if (v_IsPrint)
            {
                printTool.Print();
            }
        }
        void Btn_PrintLocation_A4_ItemClick(object sender, EventArgs e)
        {
            bool v_IsPrint = false;
            int v_LocationID = 0;

            try
            {
                v_LocationID = Convert.ToInt32(gridViewLocationDetail.GetRowCellValue(gridViewLocationDetail.FocusedRowHandle, "LocationID"));
            }
            catch { }

            DataProcess<STStockOneLocationReport_Result> v_Da = new DataProcess<STStockOneLocationReport_Result>();
            var v_list = v_Da.Executing("STStockOneLocationReport @LocationID ={0}", v_LocationID).ToList();

            ReportFile.rptStockOneLocation v_Report = new ReportFile.rptStockOneLocation();
            v_Report.DataSource = v_list;
            //v_Report.Parameters["PalletID"].Value = v_PalletID;
            v_Report.RequestParameters = false;
            ReportPrintToolWMS printTool = new ReportPrintToolWMS(v_Report);
            printTool.ShowPreview();

            if (v_IsPrint)
            {
                printTool.Print();
            }
        }

        void RepositoryItemButtonEdit_PalletInfor_DoubleClick(object sender, EventArgs e)
        {
            int v_CustomerID = 0;
            int v_ProductID = 0;

            try
            {
                v_CustomerID = Convert.ToInt32(gridViewLocationDetail.GetRowCellValue(gridViewLocationDetail.FocusedRowHandle, "CustomerID"));
            }
            catch { }

            try
            {
                v_ProductID = Convert.ToInt32(gridViewLocationDetail.GetRowCellValue(gridViewLocationDetail.FocusedRowHandle, "ProductID"));
            }
            catch { }

            WarehouseManagement.frm_WM_PalletInfo frm = new WarehouseManagement.frm_WM_PalletInfo(v_CustomerID, v_ProductID);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowInTaskbar = false;
            frm.Show();
        }
        void RepItemHyperLinkEdit_Location_PalletID_DoubleClick(object sender, EventArgs e)
        {
            int v_PalletID = 0;

            try
            {
                v_PalletID = Convert.ToInt32(gridViewLocationDetail.GetRowCellValue(gridViewLocationDetail.FocusedRowHandle, "PalletID"));
            }
            catch { }

            UI.WarehouseManagement.frm_WM_Dialog_StockMovementReview frm = new UI.WarehouseManagement.frm_WM_Dialog_StockMovementReview(v_PalletID);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowInTaskbar = false;
            frm.Show();
        }
        void RepItemHyperLinkEdit_Location_ReceivingOrderID_DoubleClick(object sender, EventArgs e)
        {
            string oderNo = Convert.ToString(gridViewLocationDetail.GetRowCellValue(gridViewLocationDetail.FocusedRowHandle, "ReceivingOrderNumber"));
            this.DisplayOrderByOrderNumber(oderNo);
        }

        private void DisplayOrderByOrderNumber(string oderNo)
        {
            if (string.IsNullOrEmpty(oderNo)) return;

            // Get Order type (RO or DO)
            var detectOrderType = oderNo.Split('-');
            if (detectOrderType.Length < 2) return;

            // Get Order id
            int orderID = Convert.ToInt32(detectOrderType[1]);

            // Set curren actions for order
            switch (detectOrderType[0])
            {
                case "RO":
                    frm_WM_ReceivingOrders receivingOrder = frm_WM_ReceivingOrders.Instance;
                    receivingOrder.ReceivingOrderIDFind = orderID;
                    receivingOrder.Show();
                    receivingOrder.WindowState = FormWindowState.Maximized;
                    receivingOrder.BringToFront();
                    break;
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
                default:
                    break;
            }

        }

        private void rpi_hpl_OrderNo_Click(object sender, EventArgs e)
        {
            string oderNo = Convert.ToString(this.grvDependInfo.GetFocusedRowCellValue("OrderNumber"));
            this.DisplayOrderByOrderNumber(oderNo);
        }
    }
}