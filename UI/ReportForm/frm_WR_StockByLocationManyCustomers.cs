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
using UI.Helper;
using UI.ReportFile;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;

namespace UI.ReportForm
{
    public partial class frm_WR_StockByLocationManyCustomers : frmBaseForm
    {
        private DataProcess<object> _tmpCustomerDA;

        public frm_WR_StockByLocationManyCustomers()
        {
            InitializeComponent();
            this.IsFixHeightScreen = false;
            this._tmpCustomerDA = new DataProcess<object>();
        }

        private void frm_WR_StockByLocationManyCustomers_Load(object sender, EventArgs e)
        {
            InitRooms();
            LoadCustomers();

            this.dtOldDate.EditValue = DateTime.Now.AddDays(-365);

            SetEvents();
        }

        private void frm_WR_StockByLocationManyCustomers_Shown(object sender, EventArgs e)
        {
            this.lkeRooms.Focus();
            this.lkeRooms.ShowPopup();
        }

        private void SetEvents()
        {
            this.btnByLocation.Click += btnByLocation_Click;
            this.btnClose.Click += btnClose_Click;
            this.btnOldStock.Click += btnOldStock_Click;
            this.btnSmallCustomer.Click += btnSmallCustomer_Click;
            this.btnSmallLocation.Click += btnSmallLocation_Click;
            this.btnSmallLocationCarton.Click += btnSmallLocationCarton_Click;
        }

        #region Load Data
        private void LoadCustomers()
        {
            this.grdCustomers.DataSource = AppSetting.CustomerList;
            this.grvCustomer.OptionsBehavior.ReadOnly = true;
            this.grvCustomer.ClearSelection();
        }

        private void InitRooms()
        {
            DataProcess<Rooms> roomDA = new DataProcess<Rooms>();
            this.lkeRooms.Properties.DataSource = roomDA.Select(s=>s.StoreID==AppSetting.StoreID);
            this.lkeRooms.Properties.ValueMember = "RoomID";
            this.lkeRooms.Properties.DisplayMember = "RoomID";
        }
        #endregion

        #region Events
        private void btnSmallLocationCarton_Click(object sender, EventArgs e)
        {
            if (DeleteTmpCustomers() == -2)
            {
                XtraMessageBox.Show("Unexpected Error !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.grvCustomer.SelectedRowsCount <= 0)
            {
                XtraMessageBox.Show("No customers selected, report all customers !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateAllCustomerID();
            }
            else
            {
                UpdateSelectedCustomerID();
            }

            OpenStockByLocationSmallCarton();
        }

        private void btnSmallLocation_Click(object sender, EventArgs e)
        {
            if (DeleteTmpCustomers() == -2)
            {
                XtraMessageBox.Show("Unexpected Error !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.grvCustomer.SelectedRowsCount <= 0)
            {
                XtraMessageBox.Show("No customers selected, report all customers !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateAllCustomerID();
            }
            else
            {
                UpdateSelectedCustomerID();
            }

            OpenStockByLocationSmall();
        }

        private void btnSmallCustomer_Click(object sender, EventArgs e)
        {
            if (DeleteTmpCustomers() == -2)
            {
                XtraMessageBox.Show("Unexpected Error !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.grvCustomer.SelectedRowsCount <= 0)
            {
                XtraMessageBox.Show("No customers selected, report all customers !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //UpdateAllCustomerID();
            }
            else
            {
                //UpdateSelectedCustomerID();
            }

            OpenStockByLocationSmallCustomer();
        }

        private void btnOldStock_Click(object sender, EventArgs e)
        {
            if (DeleteTmpCustomers() == -2)
            {
                XtraMessageBox.Show("Unexpected Error !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.grvCustomer.SelectedRowsCount <= 0)
            {
                XtraMessageBox.Show("No customers selected, report all customers !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateAllCustomerID();
            }
            else
            {
                UpdateSelectedCustomerID();
            }

            OpenStockByLocationOld();
        }

        private void btnByLocation_Click(object sender, EventArgs e)
        {
            if(DeleteTmpCustomers() == -2)
            {
                XtraMessageBox.Show("Unexpected Error !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(this.grvCustomer.SelectedRowsCount <= 0)
            {
                XtraMessageBox.Show("Please select customer !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                UpdateSelectedCustomerID();
            }

            OpenStockByLocationManyCustomers();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        #endregion

        private int DeleteTmpCustomers()
        {
            int result = this._tmpCustomerDA.ExecuteNoQuery("Delete From tmpCustomers");

            return result;
        }

        private void UpdateSelectedCustomerID()
        {
            int[] rowHandles = this.grvCustomer.GetSelectedRows();

            try
            {
                for (int i = 0; i < rowHandles.Count(); i++)
                {
                    int customerID = Convert.ToInt32(this.grvCustomer.GetRowCellValue(rowHandles[i], "CustomerID"));
                    int result = this._tmpCustomerDA.ExecuteNoQuery("Insert into tmpCustomers (CustomerID) Values ({0})", customerID);
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void UpdateAllCustomerID()
        {
            try
            {
                List<Customers> listCustomers = AppSetting.CustomerList.ToList();
                int count = listCustomers.Count;

                for (int i = 0; i < count; i++)
                {
                    int customerID = listCustomers[i].CustomerID;
                    int result = this._tmpCustomerDA.ExecuteNoQuery("Insert into tmpCustomers (CustomerID) Values ({0})", customerID);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Open reports
        private void OpenStockByLocationManyCustomers()
        {
            var data = FileProcess.LoadTable("ST_WMS_LoadStockByLocationManyCustomers");

            if(data == null)
            {
                XtraMessageBox.Show("No data to print !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            rptStockByLocationManyCustomers rpt = new rptStockByLocationManyCustomers();
            rpt.DataSource = data;
            ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
            tool.ShowPreview();
        }

        private void OpenStockByLocationOld()
        {
            var data = FileProcess.LoadTable("ST_WMS_LoadStockByLocationOld @RoomID='" + this.lkeRooms.EditValue + "', @OldDate='" + this.dtOldDate.DateTime + "'");

            if (data == null)
            {
                XtraMessageBox.Show("No data to print !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            rptStockByLocationOld rpt = new rptStockByLocationOld();
            rpt.DataSource = data;
            ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
            tool.ShowPreview();
        }

        private void OpenStockByLocationSmallCustomer()
        {
            var data = FileProcess.LoadTable("ST_WMS_LoadStockByLocationSmallCustomers @RoomID='" + this.lkeRooms.EditValue + "'");

            if (data == null)
            {
                XtraMessageBox.Show("No data to print !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            rptStockByLocationSmallByCustomer rpt = new rptStockByLocationSmallByCustomer();
            rpt.DataSource = data;
            ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
            tool.ShowPreview();
        }

        private void OpenStockByLocationSmall()
        {
            var data = FileProcess.LoadTable("ST_WMS_LoadStockByLocationSmallCustomers @RoomID='" + this.lkeRooms.EditValue + "'");

            if (data == null)
            {
                XtraMessageBox.Show("No data to print !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            rptStockByLocationSmall rpt = new rptStockByLocationSmall();
            rpt.DataSource = data;
            ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
            tool.ShowPreview();
        }

        private void OpenStockByLocationSmallCarton()
        {
            var data = FileProcess.LoadTable("ST_WMS_LoadStockByLocationSmallCartons @RoomID='" + this.lkeRooms.EditValue + "'");

            if (data == null)
            {
                XtraMessageBox.Show("No data to print !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            rptStockByLocationSmallByCarton rpt = new rptStockByLocationSmallByCarton();
            rpt.DataSource = data;
            ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
            tool.ShowPreview();
        }
        #endregion
    }
}
