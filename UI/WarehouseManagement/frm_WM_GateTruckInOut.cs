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
using DevExpress.XtraEditors;
using UI.Management;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_GateTruckInOut : frmBaseForm
    {
        private DataTable _tableTruck;
        private int gateSelected = 0;

        public frm_WM_GateTruckInOut()
        {
            InitializeComponent();
        }

        private void grdTruckInOut_Click(object sender, EventArgs e)
        {
            this._tableTruck = new DataTable();
        }

        private void frm_WM_GateTruckInOut_Load(object sender, EventArgs e)
        {
            LoadTrucks();
            InitCustomers();

            this.dtFromDate.EditValue = DateTime.Now.AddDays(-2);
            this.dtToDate.EditValue = DateTime.Now;
            SetEvents();

            // Init default filter data
            this.chkRemain.Checked = true;
            this.chkAll.Checked = true;
        }

        private void SetEvents()
        {
            this.rpi_btn_Cancel.Click += rpi_btn_Cancel_Click;
            this.dtFromDate.KeyDown += DtFromDate_KeyDown;
            this.dtToDate.KeyDown += DtFromDate_KeyDown;
            this.lkeCustomerFind.EditValueChanged += lkeCustomerFind_EditValueChanged;
            this.chkByDate.CheckedChanged += chkByDate_CheckedChanged;
            this.chkRemain.CheckedChanged += chkRemain_CheckedChanged;
            this.chkRecent.CheckedChanged += chkRecent_CheckedChanged;
            this.chkAll.CheckedChanged += ChkAll_CheckedChanged;
            this.chkGate1.CheckedChanged += ChkAll_CheckedChanged;
            this.chkGate2.CheckedChanged += ChkAll_CheckedChanged;
            this.chkByCustomer.CheckedChanged += chkByCustomer_CheckedChanged;
            this.grvTruckInOut.RowCellClick += grvTruckInOut_RowCellClick;
        }

        private void DtFromDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.KeyCode.Equals(Keys.Enter)) return;
            this._tableTruck = FileProcess.LoadTable("STGate_TruckInOutFDTD @FromDate = '" + this.dtFromDate.DateTime.ToString("yyyy-MM-dd")
               + "', @ToDate = '" + this.dtToDate.DateTime.ToString("yyyy-MM-dd") + "',@StoreID=" + AppSetting.StoreID);

            LoadFoundTrucks(this._tableTruck);
        }

        private void ChkAll_CheckedChanged(object sender, EventArgs e)
        {
            var chk = (CheckEdit)sender;
            if (!chk.Checked) return;
            switch (chk.Name)
            {
                case "chkAll":
                    this.gateSelected = 0;
                    this.chkGate1.Checked = false;
                    this.chkGate2.Checked = false;
                    break;
                case "chkGate1":
                    this.gateSelected = 1;
                    this.chkAll.Checked = false;
                    this.chkGate2.Checked = false;
                    break;
                case "chkGate2":
                    this.gateSelected = 2;
                    this.chkGate1.Checked = false;
                    this.chkAll.Checked = false;
                    break;
                default:
                    this.gateSelected = 0;
                    this.chkGate1.Checked = false;
                    this.chkGate2.Checked = false;
                    break;
            }

            if (this.chkRecent.Checked)
            {
                this.LoadData(2, 2);
            }
            else if (this.chkRemain.Checked)
            {
                this.LoadData(1, 1);
            }
        }

        #region Events
        private void grvTruckInOut_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Column.FieldName.Equals("ProductQty"))
            {
                DataProcess<object> truckDA = new DataProcess<object>();
                string customerName = Convert.ToString(this.grvTruckInOut.GetRowCellValue(e.RowHandle, "CustomerName"));
                string reason = Convert.ToString(this.grvTruckInOut.GetRowCellValue(e.RowHandle, "TruckReason"));
                int gate = Convert.ToInt32(this.grvTruckInOut.GetRowCellValue(e.RowHandle, "Gate"));
                int truckID = Convert.ToInt32(this.grvTruckInOut.GetRowCellValue(e.RowHandle, "TruckInOutID"));

                if (!customerName.Equals("METRO*"))
                {
                    if (!reason.Substring(0, 3).Equals("Kho") && !reason.Substring(0, 4).Equals("Nhan"))
                    {
                        XtraMessageBox.Show("Truck has transaction ! Please complete in RO or DO form !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                if (AppSetting.CurrentUser.Gate - gate != 0 && AppSetting.CurrentUser.Gate != 0)
                {
                    XtraMessageBox.Show("You are located in different warehouse for this truck !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string newQuantity = XtraInputBox.Show("Please enter quantity or press enter to cancel the permit : ", "TPWMS", String.Empty);
                string orderNumber = String.Empty;

                if (String.IsNullOrEmpty(newQuantity))
                {
                    int result = truckDA.ExecuteNoQuery("Update Gate_TruckInOut SET UserCheckOut = 0, ProductQty = '', UserOut = {0}, OrderNumber = '' WHERE truckInoutID = {1}", "Cancel by " + AppSetting.CurrentUser.LoginName, truckID);
                    LoadTrucks();
                    return;
                }
                else
                {
                    if (customerName.Equals("METRO"))
                    {
                        orderNumber = XtraInputBox.Show("Please enter Order Number : ", "TPWMS", "Metro F-V");
                    }
                    else
                    {
                        orderNumber = XtraInputBox.Show("Please enter Order Number : ", "TPWMS", "Khong X-N");
                    }

                    if (String.IsNullOrEmpty(orderNumber))
                    {
                        return;
                    }
                    else
                    {
                        int result = truckDA.ExecuteNoQuery("Update Gate_TruckInOut SET UserCheckOut = 1, ProductQty = {0}, UserOut = {1}, OrderNumber = {2} WHERE truckInoutID = {3}", newQuantity, AppSetting.CurrentUser.LoginName + "-" + DateTime.Now.ToString(), orderNumber, truckID);
                        LoadTrucks();
                    }
                }

            }
        }

        private void chkByCustomer_CheckedChanged(object sender, EventArgs e)
        {
            if (chkByCustomer.Checked)
            {
                this.lkeCustomerFind.ReadOnly = false;
                FilterEvent(Convert.ToInt32(this.chkByCustomer.Tag));
                this.lkeCustomerFind.Focus();
                this.lkeCustomerFind.ShowPopup();
            }
            else
            {
                this.lkeCustomerFind.ReadOnly = true;
            }
        }

        private void chkRecent_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRecent.Checked)
            {
                this.LoadData(2, 2);
            }
        }

        private void chkRemain_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkRemain.Checked)
            {
                this.LoadData(1, 1);
            }
        }

        private void LoadData(int flag, int filterType)
        {
            FilterEvent(filterType);

            this._tableTruck = FileProcess.LoadTable("STGate_TruckInOut @StoreID = " + AppSetting.StoreID
                + ", @Gate = " + this.gateSelected
                + ", @Flag =" + flag);

            LoadFoundTrucks(this._tableTruck);
        }

        private void chkByDate_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkByDate.Checked)
            {
                FilterEvent(Convert.ToInt32(this.chkByDate.Tag));

                this._tableTruck = FileProcess.LoadTable("STGate_TruckInOutRemain @Gate = " + Convert.ToByte(this.chkByDate.Tag)
                    + ", @FromDate = '" + this.dtFromDate.DateTime.ToString("yyyy-MM-dd")
                    + "', @Todate = '" + this.dtToDate.DateTime.ToString("yyyy-MM-dd") + "',@StoreID=" + AppSetting.StoreID);

                LoadFoundTrucks(this._tableTruck);
            }
        }

        private void lkeCustomerFind_EditValueChanged(object sender, EventArgs e)
        {
            this._tableTruck = FileProcess.LoadTable("STGate_TruckInOutFDTDByCustomer @FromDate = '" + this.dtFromDate.DateTime.ToString("yyyy-MM-dd")
                + "', @ToDate = '" + this.dtToDate.DateTime.ToString("yyyy-MM-dd")
                + "', @CustomerName = '" + Convert.ToString(this.lkeCustomerFind.GetColumnValue("CustomerName")) + "',@StoreID=" + AppSetting.StoreID);

            LoadFoundTrucks(this._tableTruck);
        }

        private void rpi_btn_Cancel_Click(object sender, EventArgs e)
        {
            if (Convert.IsDBNull(this.grvTruckInOut.GetFocusedRowCellValue("TimeOut")))
            {
                DataProcess<object> truckDA = new DataProcess<object>();
                int truckID = Convert.ToInt32(this.grvTruckInOut.GetFocusedRowCellValue("TruckInOutID"));

                int result = truckDA.ExecuteNoQuery("Update Gate_TruckInOut SET UserCheckOut = 0, ProductQty = '', UserOut = 'Canceled', Ordernumber ='' WHERE TruckInOutID = {0}", truckID);

                LoadTrucks();
            }
            else
            {
                XtraMessageBox.Show("This truck is out, can not cancel the order !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region Load Data
        private void LoadTrucks()
        {
            //STGate_TruckInOut
            this._tableTruck = FileProcess.LoadTable("STGate_TruckInOut @StoreID = " + AppSetting.StoreID + ", @Gate = " + AppSetting.CurrentUser.Gate + ", @Flag = 1");

            this.grdTruckInOut.DataSource = this._tableTruck;
            CalculateRemain();
        }

        private void LoadFoundTrucks(DataTable source)
        {
            this.grdTruckInOut.DataSource = this._tableTruck;
            CalculateRemain();
        }

        private void InitCustomers()
        {
            this.lkeCustomerFind.Properties.DataSource = AppSetting.CustomerList;
            this.lkeCustomerFind.Properties.DisplayMember = "CustomerNumber";
            this.lkeCustomerFind.Properties.ValueMember = "CustomerID";
        }

        private void CalculateRemain()
        {
            if (this._tableTruck == null) return;
            int rowCount = this._tableTruck.Rows.Count;
            int checkedCount = 0;
            int remain = 0;

            if (this._tableTruck.Rows.Count > 0)
            {
                foreach (DataRow row in this._tableTruck.Rows)
                {
                    if (row["CheckOut"].Equals(true))
                    {
                        checkedCount += 1;
                    }
                }

                remain = rowCount - checkedCount;

                if (remain <= 0)
                {
                    this.txtRemain.Text = "0";
                }
                else
                {
                    this.txtRemain.Text = remain.ToString();
                }
            }
            else
            {
                this.txtRemain.Text = "0";
            }
        }
        #endregion

        private void FilterEvent(int type)
        {
            switch (type)
            {
                case 0: //By Date
                    {
                        this.chkByCustomer.Checked = false;
                        this.chkRecent.Checked = false;
                        this.chkRemain.Checked = false;
                        break;
                    }
                case 1: //By Remain
                    {
                        this.chkByCustomer.Checked = false;
                        this.chkRecent.Checked = false;
                        this.chkByDate.Checked = false;
                        break;
                    }
                case 2: //By Recent
                    {
                        this.chkByCustomer.Checked = false;
                        this.chkRemain.Checked = false;
                        this.chkByDate.Checked = false;
                        break;
                    }
                case 3: //By Customer
                    {
                        this.chkRecent.Checked = false;
                        this.chkRemain.Checked = false;
                        this.chkByDate.Checked = false;
                        break;
                    }
            }
        }

        private void grdTruckInOut_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                if (this.grvTruckInOut.FocusedRowHandle >= 0)
                {
                    var currentTruckInOutId = this.grvTruckInOut.GetFocusedRowCellValue("TruckInOutID");
                    frm_WM_Attachments.Instance.OrderNumber = currentTruckInOutId.ToString();
                    frm_WM_Attachments.Instance.CustomerID = 0;
                    frm_WM_Attachments.Instance.TruckInout = "TR";
                    if (frm_WM_Attachments.Instance.Enabled)
                    {
                        frm_WM_Attachments.Instance.ShowDialog();
                    }
                }
            }
        }

    }
}
