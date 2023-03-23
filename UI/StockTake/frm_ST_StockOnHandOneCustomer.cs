using Common.Controls;
using Common.Process;
using DA;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Helper;
using UI.WarehouseManagement;

namespace UI.StockTake
{
    public partial class frm_ST_StockOnHandOneCustomer : frmBaseForm
    {
        int m_customerID = -1;
        Customers m_CurrentCustomer = new Customers();
        IEnumerable<Customers> m_listCustomer = null;

        DateTime m_timeRefresh = DateTime.MinValue;

        private int _productID;
        private string _productName;

        public int ProductID
        {
            get
            {
                return _productID;
            }

            set
            {
                _productID = value;
                LoadDataWithFilter();
            }
        }

        public string ProductNameFilter
        {
            get
            {
                return _productName;
            }

            set
            {
                _productName = value;
                LoadDataWithFilter();
            }
        }

        public frm_ST_StockOnHandOneCustomer(int customerID)
        {
            InitializeComponent();

            this.m_customerID = customerID;
            this._productID = 0;
            this._productName = "";

            SetEvent();
            this.dateLastRODate.EditValue = DateTime.Now.AddDays(-30);

        }
        void Frm_ST_StockOnHandOneCustomer_Load(object sender, EventArgs e)
        {
            try
            {
                Wait.Start(this);

                this.LoadData2lookUpEdit_CustomerID();
                this.LoadData2GridView_Product(this.m_customerID);
            }
            catch
            {
                Wait.Close();
            }
            finally
            {
                Wait.Close();
            }

        }

        void SetEvent()
        {
            this.Load += Frm_ST_StockOnHandOneCustomer_Load;

            lookUpEdit_CustomerID.EditValueChanged += LookUpEdit_CustomerID_EditValueChanged;

            checkEdit_Main.CheckedChanged += CheckEdit_Main_CheckedChanged;

            btn_Refresh.ItemClick += Btn_Refresh_ItemClick;
            btn_StockReport.ItemClick += Btn_StockReport_ItemClick;

            btn_Room.Click += Btn_Room_Click;
            btn_View.Click += Btn_View_Click;

            btn_Close.ItemClick += Btn_Close_ItemClick;

            repItemHyperLinkEdit_ProductID.Click += RepItemHyperLinkEdit_ProductID_DoubleClick;
        }

        #region Event
        void CheckEdit_Main_CheckedChanged(object sender, EventArgs e)
        {
            Wait.Start(this);
            if (this.checkEdit_Main.Checked)
            {
                this.grdControl_productInfo.DataSource = FileProcess.LoadTable("STStockOnHandOneCustomerMain " + this.m_CurrentCustomer.CustomerMainID);
            }
            else
            {
                this.grdControl_productInfo.DataSource = FileProcess.LoadTable("STStockOnHandOneCustomer " + this.m_CurrentCustomer.CustomerID);
            }
            Wait.Close();
        }
        void RepItemHyperLinkEdit_ProductID_DoubleClick(object sender, EventArgs e)
        {
            int v_ProductID = 0;

            try
            {
                v_ProductID = Convert.ToInt32(grv_ST_ProductInfo.GetRowCellValue(grv_ST_ProductInfo.FocusedRowHandle, "tmpProductRemainID"));
            }
            catch { }

            UI.MasterSystemSetup.frm_MSS_Products frm = MasterSystemSetup.frm_MSS_Products.Instance;
            frm.ProductIDLookup = v_ProductID;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.WindowState = FormWindowState.Normal;
            frm.BringToFront();
            frm.ShowInTaskbar = false;
            frm.Show();
        }
        void RepItemButtonEdit_PalletInfor_DoubleClick(object sender, EventArgs e)
        {
            int v_ProductID = 0;
            int v_CustomerID = 0;

            try
            {
                v_CustomerID = Convert.ToInt32(lookUpEdit_CustomerID.EditValue);
            }
            catch { }

            try
            {
                v_ProductID = Convert.ToInt32(grv_ST_ProductInfo.GetRowCellValue(grv_ST_ProductInfo.FocusedRowHandle, "tmpProductRemainID"));
            }
            catch { }

            UI.WarehouseManagement.frm_WM_PalletInfo frm = new UI.WarehouseManagement.frm_WM_PalletInfo(v_CustomerID, v_ProductID);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowInTaskbar = false;
            frm.Show(this);
        }
        void Btn_Room_Click(object sender, EventArgs e)
        {
            Wait.Start(this);
            frm_ST_StockOnHandByRoomOneCustomer frm = new frm_ST_StockOnHandByRoomOneCustomer(this.m_CurrentCustomer.CustomerID,"");
            frm.ShowInTaskbar = false;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show(this);
            Wait.Close();
        }

        void Btn_StockReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int customerID = Convert.ToInt32(this.lookUpEdit_CustomerID.EditValue);
            UI.ReportForm.frm_WR_StockMovementReport frm = new UI.ReportForm.frm_WR_StockMovementReport(customerID);
            frm.ShowInTaskbar = false;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show(this);
        }
        void Btn_View_Click(object sender, EventArgs e)
        {
            int v_CustomerID = 0;

            try
            {
                v_CustomerID = Convert.ToInt32(lookUpEdit_CustomerID.EditValue);
            }
            catch { }

            var currentCustomer = AppSetting.CustomerList.Where(c => c.CustomerID == v_CustomerID).FirstOrDefault();
            UI.MasterSystemSetup.frm_MSS_Customers frm = MasterSystemSetup.frm_MSS_Customers.Instance;
            frm.CurrentCustomers = currentCustomer;
            frm.ShowInTaskbar = false;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.WindowState = FormWindowState.Normal;
            frm.BringToFront();
            frm.Show();
        }
        void Btn_Refresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Wait.Start(this);
            if (this.m_CurrentCustomer == null) return;

            if (this.m_timeRefresh.Equals(DateTime.MinValue))
            {
                this.RefreshData();
                Wait.Close();
            }
            else
            {
                TimeSpan timeBound = DateTime.Now.Subtract(this.m_timeRefresh);
                if (timeBound.Minutes >= 15)
                {
                    this.RefreshData();
                    Wait.Close();
                }
                else
                {
                    Wait.Close();
                    XtraMessageBox.Show("Stock on hand of this Customer is updated just " + timeBound.Minutes + ":" + timeBound.Seconds + " ago !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        void Btn_Close_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
        }

        void LookUpEdit_CustomerID_EditValueChanged(object sender, EventArgs e)
        {
            int customerIDSelected = (int)this.lookUpEdit_CustomerID.EditValue;

            this.m_CurrentCustomer = this.m_listCustomer.First(x => x.CustomerID == customerIDSelected);
            this.textEditCustomerName.Text = this.m_CurrentCustomer.CustomerName;

            this.LoadData2GridView_Product(this.m_CurrentCustomer.CustomerID);
        }

        #endregion Event

        #region LoadData
        void LoadData2lookUpEdit_CustomerID()
        {
            try
            {
                this.m_listCustomer = AppSetting.CustomerListAll;
                lookUpEdit_CustomerID.Properties.DataSource = AppSetting.CustomerListAll;
                lookUpEdit_CustomerID.EditValue = this.m_customerID;

                this.m_CurrentCustomer = this.m_listCustomer.First(x => x.CustomerID == m_customerID);
                this.textEditCustomerName.Text = this.m_CurrentCustomer.CustomerName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error is unexpected");
            }
        }
        void LoadData2GridView_Product(int customerID)
        {
            try
            {
                if (this.checkEdit_Main.Checked)
                {
                    this.grdControl_productInfo.DataSource = FileProcess.LoadTable("STStockOnHandOneCustomerMain " + this.m_CurrentCustomer.CustomerMainID);
                }
                else
                {
                     this.grdControl_productInfo.DataSource = FileProcess.LoadTable("STStockOnHandOneCustomer " + this.m_CurrentCustomer.CustomerID);
                }
            }
            catch (Exception)
            {
            }
        }

        void RefreshData()
        {
            DA.Stock.StockOnHandOneCustomerDA refreshDA = new DA.Stock.StockOnHandOneCustomerDA();
            var result = refreshDA.STtmpProductRemainUpdate(this.m_CurrentCustomer.CustomerID);

            this.LoadData2GridView_Product(this.m_CurrentCustomer.CustomerID);

            this.m_timeRefresh = DateTime.Now;
        }

        private void LoadDataWithFilter()
        {

            var productDA = new DataProcess<STStockOnHandProductsFound_Result>();
            if (this._productID > 0)
            {
                this.grdControl_productInfo.DataSource = productDA.Executing("STStockOnHandProductsFound @Flag = {0}, @varConditions = {1}", 1, this._productID);
            }
            else
            {
                this.grdControl_productInfo.DataSource = productDA.Executing("STStockOnHandProductsFound @Flag = {0}, @varConditions = {1}", 2, this._productName);
            }
        }
        #endregion LoadData

        private void simpleButtonClose_Click(object sender, EventArgs e)
        {
          //  this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Close();
        }

        private void simpleButton3_Stockonhand_Refresh(object sender, EventArgs e)
        {
            Wait.Start(this);
            if (this.m_CurrentCustomer == null) return;

            if (this.m_timeRefresh.Equals(DateTime.MinValue))
            {
                this.RefreshData();
                Wait.Close();
            }
            else
            {
                TimeSpan timeBound = DateTime.Now.Subtract(this.m_timeRefresh);
                if (timeBound.Minutes >= 15)
                {
                    this.RefreshData();
                    Wait.Close();
                }
                else
                {
                    Wait.Close();
                    XtraMessageBox.Show("Stock on hand of this Customer is updated just " + timeBound.Minutes + ":" + timeBound.Seconds + " ago !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void simpleButton2_stockonhand_Stock_report(object sender, EventArgs e)
        {
            int customerID = Convert.ToInt32(this.lookUpEdit_CustomerID.EditValue);
            UI.ReportForm.frm_WR_StockMovementReport frm = new UI.ReportForm.frm_WR_StockMovementReport(customerID);
            frm.ShowInTaskbar = false;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show(this);
        }

        private void btnStockOnHandRefresh_Click(object sender, EventArgs e)
        {
            Wait.Start(this);
            if (this.m_CurrentCustomer == null) return;

            if (this.m_timeRefresh.Equals(DateTime.MinValue))
            {
                this.RefreshData();
                Wait.Close();
            }
            else
            {
                TimeSpan timeBound = DateTime.Now.Subtract(this.m_timeRefresh);
                if (timeBound.Minutes >= 15)
                {
                    this.RefreshData();
                    Wait.Close();
                }
                else
                {
                    Wait.Close();
                    XtraMessageBox.Show("Stock on hand of this Customer is updated just " + timeBound.Minutes + ":" + timeBound.Seconds + " ago !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnStockReport_Click(object sender, EventArgs e)
        {
            int customerID = Convert.ToInt32(this.lookUpEdit_CustomerID.EditValue);
            UI.ReportForm.frm_WR_StockMovementReport frm = new UI.ReportForm.frm_WR_StockMovementReport(customerID);
            frm.ShowInTaskbar = false;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show(this);
        }

        private void rpe_hle_PalletID_Click(object sender, EventArgs e)
        {
            int v_ProductID = 0;
            int v_CustomerID = 0;

            try
            {
                v_CustomerID = Convert.ToInt32(lookUpEdit_CustomerID.EditValue);
            }
            catch { }

            try
            {
                v_ProductID = Convert.ToInt32(grv_ST_ProductInfo.GetRowCellValue(grv_ST_ProductInfo.FocusedRowHandle, "tmpProductRemainID"));
            }
            catch { }

            UI.WarehouseManagement.frm_WM_PalletInfo frm = new UI.WarehouseManagement.frm_WM_PalletInfo(v_CustomerID, v_ProductID);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowInTaskbar = false;
            frm.Show(this);
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private string GetSelectedProductID()
        {
            string listProductID = "";
            int[] rowHandles = this.grv_ST_ProductInfo.GetSelectedRows();

            for (int i = 0; i < rowHandles.Count(); i++)
            {
                    listProductID = listProductID + this.grv_ST_ProductInfo.GetRowCellValue(rowHandles[i], "ProductID") + ", ";
            }

            return listProductID;
        }
        private void checkShowPalletIDDetailedHistory_CheckedChanged(object sender, EventArgs e)
        {
            //Retrieve the checked items in the product grid

            if (this.checkShowPalletIDDetailedHistory.Checked)
            {
                string listProductID = "";
                int[] rowHandles = this.grv_ST_ProductInfo.GetSelectedRows();

                for (int i = 0; i < rowHandles.Count(); i++)
                {
                    listProductID = listProductID + this.grv_ST_ProductInfo.GetRowCellValue(rowHandles[i], "tmpProductRemainID") + ", ";
                }

                //MessageBox.Show("ST_WMS_LoadPalletHistoryDetails '" + listProductID + "','" + this.dateLastRODate.EditValue + "'");
                this.grcPalletHistories.DataSource = FileProcess.LoadTable("ST_WMS_LoadPalletHistoryDetails '" + listProductID + "','" + Convert.ToDateTime(this.dateLastRODate.EditValue).Date.ToString("yyyy-MM-dd") + "'");
            }
            else
                this.grcPalletHistories.DataSource = "";

        }

        private void btnExportPalletHistory_Click(object sender, EventArgs e)
        {
            string fileName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" 
                + "PalletHistory_" + this.textEditCustomerName.Text + "_" + DateTime.Now.ToString("dd_MM_yy") + ".xlsx";

            try
            {
                this.grvPalletHistories.ExportToXlsx(fileName);
                MessageBox.Show("Grid exported to the file : " + Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\"
                    + "PalletHistory_" + this.textEditCustomerName.Text + "_" + DateTime.Now.ToString("dd_MM_yy") + ".xlsx");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Path not exsist "+fileName);

            }
        }

        private void rpe_hle_DOID_Click(object sender, EventArgs e)
        {
            int v_DispatchingOrderID = 0;
            try
            {
                v_DispatchingOrderID = Convert.ToInt32(grvPalletHistories.GetFocusedRowCellValue("DispatchingOrderID"));
            }
            catch { }

            WarehouseManagement.frm_WM_DispatchingOrders frm = frm_WM_DispatchingOrders.GetInstance(v_DispatchingOrderID);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowInTaskbar = false;
            frm.Show();
            frm.BringToFront();
        }

        private void btnCheckKGR_Click(object sender, EventArgs e)
        {
            frm_ST_StockOnHandOneCustomerKGRCheck frm = new frm_ST_StockOnHandOneCustomerKGRCheck(Convert.ToInt32(this.lookUpEdit_CustomerID.EditValue));
            frm.Show();
            frm.BringToFront();
            frm.WindowState = FormWindowState.Normal;
        }
    }
}
