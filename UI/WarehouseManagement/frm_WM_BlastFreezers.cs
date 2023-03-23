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
using DevExpress.XtraGrid;
using UI.ReportFile;
using System.Text.RegularExpressions;
using UI.Management;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_BlastFreezers : frmBaseForm
    {
        private List<BlastFreezers> blastFreezersList;
        private static frm_WM_BlastFreezers _instance;
        private BlastFreezers currentBlastFreezers;
        private BlastFreezers saveCurrentBlastFreezers;
        private bool isCreateNew;
        private int isUpdate;
        IEnumerable<Customers> listCustomer;

        DataProcess<Customers> daCustomer = new DataProcess<Customers>();
        public frm_WM_BlastFreezers()
        {
            InitializeComponent();
            IsFixHeightScreen = false;
            Init();
        }
        public static frm_WM_BlastFreezers GetInstance()
        {
           
                if (_instance == null)
                {
                    _instance = new frm_WM_BlastFreezers();
                }
                return _instance;
            
            
        }

        private void Init()
        {
           
            //lkeCustomerNumber.Properties.DataSource = daCustomer.Executing("SELECT * FROM dbo.Customers WHERE StoreID=" + AppSetting.CurrentUser.StoreID);
            lkeCustomerNumber.Properties.DataSource = AppSetting.CustomerList;
            int customerCount = AppSetting.CustomerList.Count();
            if (customerCount > 20)
                lkeCustomerNumber.Properties.DropDownRows = 20;
            else
                lkeCustomerNumber.Properties.DropDownRows = customerCount;
            lkeCustomerNumber.Properties.DisplayMember = "CustomerNumber";
            lkeCustomerNumber.Properties.ValueMember = "CustomerNumber";

            lkeEmployeeID.Properties.DataSource = AppSetting.EmployessList;
            int employeeCount = AppSetting.EmployessList.Count();
            if (employeeCount > 20)
                lkeEmployeeID.Properties.DropDownRows = 20;
            else
                lkeEmployeeID.Properties.DropDownRows = employeeCount;
            lkeEmployeeID.Properties.DisplayMember = "EmployeeID";
            lkeEmployeeID.Properties.ValueMember = "EmployeeID";

            DataProcess<BlastFreezers> blastFreezersDA = new DataProcess<BlastFreezers>();
            DateTime comparedTimeValue = DateTime.Now.AddDays(-31);
            //blastFreezersList = blastFreezersDA.Select(bf => (bf.DateIn.CompareTo(comparedTimeValue)) > 0).ToList();
            try {
                blastFreezersList = blastFreezersDA.Executing("SELECT BlastFreezers.*,StoreID FROM dbo.BlastFreezers Left JOIN Customers ON BlastFreezers.CustomerID=Customers.CustomerID WHERE DateIn > GETDATE() - 31 and StoreID=" + (int)AppSetting.CurrentUser.StoreID).ToList();
                int[] blastFreezersRoomIDList = new int[3] { 1, 2, 3 };
                lkeBlastFreezerRoomID.Properties.DataSource = blastFreezersRoomIDList;
                lkeBlastFreezerRoomID.Properties.DropDownRows = blastFreezersRoomIDList.Count();

                //dtngBlastFreezers.DataSource = blastFreezersList.Select(bf => (bf.DateIn.CompareTo(comparedTimeValue)) > 0).ToList();
                //dtngBlastFreezers.Position = blastFreezersList.Select(bf => (bf.DateIn.CompareTo(comparedTimeValue)) > 0).ToList().Count;

                dtngBlastFreezers.DataSource = blastFreezersList;
                dtngBlastFreezers.Position = blastFreezersList.Count;
            }
            catch
            {
                
            }



        }

        private void UpdateControlsBy(BlastFreezers yourCurrentBlastFreezers)
        {
            currentBlastFreezers = yourCurrentBlastFreezers;

            txtBlastFreezerRecordNumber.EditValue = currentBlastFreezers.BlastFreezerRecordNumber;

            Customers selectedCustomer = ((List<Customers>)lkeCustomerNumber.Properties.DataSource).Where(c => c.CustomerName.Equals(currentBlastFreezers.CustomerName)).SingleOrDefault();
            if (selectedCustomer != null)
            {
                lkeCustomerNumber.EditValue = selectedCustomer.CustomerNumber;
            }
            else
            {
                lkeCustomerNumber.EditValue = "";
            }
         
            txtCustomerName.EditValue = currentBlastFreezers.CustomerName;
           
            lkeBlastFreezerRoomID.EditValue = currentBlastFreezers.BlastFreezerRoomID;
            deDateIn.EditValue = currentBlastFreezers.DateIn;

            if (string.IsNullOrEmpty(currentBlastFreezers.BlastFreezerLoadingBy))
            {
                lkeEmployeeID.EditValue = null;
            }
            else
            {
                Employees selectedEmployee = AppSetting.EmployessList.Where(e => e.VietnamName.Equals(currentBlastFreezers.BlastFreezerLoadingBy)).FirstOrDefault();
                if (selectedEmployee != null)
                    lkeEmployeeID.EditValue = selectedEmployee.EmployeeID;
                else
                    lkeEmployeeID.EditValue = null;
            }
              
            txtUsername.EditValue = currentBlastFreezers.UserName;

            txtStartLoadingTime.EditValue = currentBlastFreezers.StartLoadingTime;
            txtEndLoadingTime.EditValue = currentBlastFreezers.EndLoadingTime;
            txtUloadingTime.EditValue = currentBlastFreezers.BlastFreezerUloadingTime;
            txtBlastFreezerLoadingBy.EditValue = currentBlastFreezers.BlastFreezerLoadingBy;
            txtTempIn.EditValue = currentBlastFreezers.TempIn;
            txtTempOut.EditValue = currentBlastFreezers.TempOut;
            meRemark.EditValue = currentBlastFreezers.ProductDetailsRemark;
            txtStartRunTime.EditValue = currentBlastFreezers.StartRunTime;
            txtStartRunUser.EditValue = currentBlastFreezers.StartRunUser;
            txtEndRunTime.EditValue = currentBlastFreezers.EndRunTime;
            txtEndRunUser.EditValue = currentBlastFreezers.EndRunUser;
            meBlastFreezerRunningRemark.EditValue = currentBlastFreezers.BlastFreezerRunningRemark;
            txtRO.EditValue = currentBlastFreezers.ReceivingOrder;
            txtQty.EditValue = currentBlastFreezers.Qty;
            txtProductIn.EditValue = currentBlastFreezers.TimeProductIn;
            txtProductOut.EditValue = currentBlastFreezers.TimeProductOut;
            txtWeight.EditValue = currentBlastFreezers.Weight;

            BindingList<BlastFreezerDetails> blastFreezerDetailList = new BindingList<BlastFreezerDetails>(currentBlastFreezers.BlastFreezerDetails.ToList());
            grcBlastFreezerTemperatureDetails.DataSource = blastFreezerDetailList;
            grvBlastFreezerTemperatureDetails.Columns["RecordTime"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            grvBlastFreezerTemperatureDetails.RefreshData();
            btnConfirm.Enabled = !currentBlastFreezers.BlastFreezerConfirm;
        }

        private void UpdateControlStatus()
        {
            if (btnConfirm.Enabled == true)
            {
                grvBlastFreezerTemperatureDetails.OptionsBehavior.ReadOnly = false;
                lkeCustomerNumber.Enabled = true;
                txtCustomerName.Enabled = true;
                lkeBlastFreezerRoomID.Enabled = true;
                deDateIn.Enabled = true;
                panelControl1.Enabled = true;
            }
            else
            {
                grvBlastFreezerTemperatureDetails.OptionsBehavior.ReadOnly = true;
                lkeCustomerNumber.Enabled = false;
                txtCustomerName.Enabled = false;
                lkeBlastFreezerRoomID.Enabled = false;
                deDateIn.Enabled = false;
                panelControl1.Enabled = false;
            }
        }

        private void frm_WM_BlastFreezers_Load(object sender, EventArgs e)
        {
            UpdateControlStatus();
        }

        private void dtngBlastFreezers_PositionChanged(object sender, EventArgs e)
        {
            currentBlastFreezers = blastFreezersList.ElementAt(dtngBlastFreezers.Position);
            saveCurrentBlastFreezers = currentBlastFreezers;
            UpdateControlsBy(currentBlastFreezers);
            UpdateControlStatus();
        }

        private void btnCreateNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

        private void lkeCustomerNumber_EditValueChanged(object sender, EventArgs e)
        {
            if (lkeCustomerNumber.EditValue != null && lkeCustomerNumber.GetColumnValue("CustomerName") != null
                && lkeCustomerNumber.GetColumnValue("CustomerID") != null)
            {

                txtCustomerName.EditValue = lkeCustomerNumber.GetColumnValue("CustomerName").ToString();
                if (isCreateNew)
                {
                    BlastFreezers newBlastFreezers = new BlastFreezers()
                    {
                        BlastFreezerID = 0,
                        DateIn = deDateIn.DateTime,
                        CustomerID = Convert.ToInt32(lkeCustomerNumber.GetColumnValue("CustomerID")),
                        CustomerName = txtCustomerName.EditValue.ToString(),
                        BlastFreezerRoomID = Convert.ToInt32(lkeBlastFreezerRoomID.EditValue),
                        UserName = txtUsername.EditValue.ToString(),
                        BlastFreezerConfirm = false
                    };
                    DataProcess<BlastFreezers> blastFreezersDA = new DataProcess<BlastFreezers>();
                    int resultInsert = blastFreezersDA.Insert(newBlastFreezers);
                    if (resultInsert > 0)
                    {
                        isCreateNew = false;

                        //Loại lại dữ liệu cho form
                        DateTime comparedTimeValue = DateTime.Now.AddDays(-31);
                        blastFreezersList = blastFreezersDA.Select(bf => (bf.DateIn.CompareTo(comparedTimeValue)) > 0).ToList();

                        dtngBlastFreezers.DataSource = blastFreezersList;
                        dtngBlastFreezers.Position = blastFreezersList.Count;

                    }
                    else
                        MessageBox.Show("Creating new blast freezers is failed", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lkeBlastFreezerRoomID_EditValueChanged(object sender, EventArgs e)
        {
            if (lkeBlastFreezerRoomID.EditValue == null)
            {
                MessageBox.Show("Choose room for this blast freezer, please !", "Plant Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lkeBlastFreezerRoomID.Focus();
                lkeBlastFreezerRoomID.ShowPopup();
            }
        }

        private void txtStartLoadingTime_Enter(object sender, EventArgs e)
        {
            if (txtStartLoadingTime.EditValue == null || txtStartLoadingTime.EditValue.Equals(""))
                txtStartLoadingTime.EditValue = DateTime.Now.ToString();
        }

        private void txtEndLoadingTime_Enter(object sender, EventArgs e)
        {
            if (txtEndLoadingTime.EditValue == null || txtEndLoadingTime.EditValue.Equals(""))
                txtEndLoadingTime.EditValue = DateTime.Now.ToString();
        }

        private void txtProductIn_Enter(object sender, EventArgs e)
        {
            if(txtProductIn.EditValue == null || txtProductIn.EditValue.Equals(""))
                txtProductIn.EditValue = DateTime.Now.ToString();
        }

        private void txtProductOut_Enter(object sender, EventArgs e)
        {
            if(txtProductOut.EditValue == null || txtProductOut.EditValue.Equals(""))
                txtProductOut.EditValue = DateTime.Now.ToString();
        }

        private void txtUloadingTime_Enter(object sender, EventArgs e)
        {
            if (txtUloadingTime.EditValue == null || txtUloadingTime.EditValue.Equals(""))
                txtUloadingTime.EditValue = DateTime.Now.ToString();
        }

        private void lkeEmployeeID_EditValueChanged(object sender, EventArgs e)
        {
            if (lkeEmployeeID.EditValue != null && lkeEmployeeID.GetColumnValue("VietnamName") != null)
                txtBlastFreezerLoadingBy.EditValue = lkeEmployeeID.GetColumnValue("VietnamName").ToString();
        }

        private void txtStartRunTime_EditValueChanged(object sender, EventArgs e)
        {
            txtStartRunUser.EditValue = AppSetting.CurrentUser.LoginName + " - " + DateTime.Now;
        }

        private void txtEndRunTime_EditValueChanged(object sender, EventArgs e)
        {
            txtEndRunUser.EditValue = AppSetting.CurrentUser.LoginName + " - " + DateTime.Now;
        }

        private void grvBlastFreezerTemperatureDetails_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

            if (e.FocusedRowHandle == GridControl.NewItemRowHandle)
            {
                if (currentBlastFreezers != null && currentBlastFreezers.BlastFreezerID != 0)
                {
                    BlastFreezerDetails newBlastFreezerDetails = new BlastFreezerDetails();
                    newBlastFreezerDetails.BlastFreezerDetailsID = 0;
                    newBlastFreezerDetails.BlastFreezerID = currentBlastFreezers.BlastFreezerID;
                    if (grvBlastFreezerTemperatureDetails.GetRowCellValue(e.PrevFocusedRowHandle, grdColRecordTime) != null)
                        newBlastFreezerDetails.RecordTime = Convert.ToDateTime(grvBlastFreezerTemperatureDetails.GetRowCellValue(e.PrevFocusedRowHandle, grdColRecordTime));
                    if (grvBlastFreezerTemperatureDetails.GetRowCellValue(e.PrevFocusedRowHandle, grdColSampleNumber) != null)
                        newBlastFreezerDetails.SampleNumber = Convert.ToInt16(grvBlastFreezerTemperatureDetails.GetRowCellValue(e.PrevFocusedRowHandle, grdColSampleNumber));
                    if (grvBlastFreezerTemperatureDetails.GetRowCellValue(e.PrevFocusedRowHandle, grdColSampleTemp) != null)
                        newBlastFreezerDetails.SampleTemp = Convert.ToDouble(grvBlastFreezerTemperatureDetails.GetRowCellValue(e.PrevFocusedRowHandle, grdColSampleTemp));
                    if (grvBlastFreezerTemperatureDetails.GetRowCellValue(e.PrevFocusedRowHandle, grdColRemark) != null)
                        newBlastFreezerDetails.Remark = Convert.ToString(grvBlastFreezerTemperatureDetails.GetRowCellValue(e.PrevFocusedRowHandle, grdColRemark));

                    DataProcess<BlastFreezerDetails> blastFreezerDetailsDA = new DataProcess<BlastFreezerDetails>();
                    BlastFreezerDetails oldBlastFreezerDetails = blastFreezerDetailsDA.Select(
                        bfDetail => bfDetail.BlastFreezerID == newBlastFreezerDetails.BlastFreezerID &&
                        bfDetail.RecordTime == newBlastFreezerDetails.RecordTime &&
                        bfDetail.SampleNumber == newBlastFreezerDetails.SampleNumber &&
                        bfDetail.SampleTemp == newBlastFreezerDetails.SampleTemp &&
                        bfDetail.Remark == newBlastFreezerDetails.Remark).SingleOrDefault();
                    if (oldBlastFreezerDetails == null)
                        blastFreezerDetailsDA.Insert(newBlastFreezerDetails);
                    else
                    {
                        newBlastFreezerDetails.BlastFreezerDetailsID = oldBlastFreezerDetails.BlastFreezerDetailsID;
                        blastFreezerDetailsDA.Update(newBlastFreezerDetails);
                    }

                    grdColRecordTime.OptionsColumn.AllowFocus = false;
                    grvBlastFreezerTemperatureDetails.FocusedColumn = grdColSampleNumber;
                }

            }
        }

        private void grvBlastFreezerTemperatureDetails_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            grvBlastFreezerTemperatureDetails.SetRowCellValue(e.RowHandle, grdColRecordTime, DateTime.Now);
        }
        

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnUpdateAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void grvBlastFreezerTemperatureDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                try
                {
                    if (this.grvBlastFreezerTemperatureDetails.SelectedRowsCount <= 0) return;
                    List<BlastFreezerDetails> deletingBlastFreezerDetailsList = new List<BlastFreezerDetails>();
                    int[] selectedRows = grvBlastFreezerTemperatureDetails.GetSelectedRows();
                    DataProcess<BlastFreezerDetails> blastFreezerDetailsDA = new DataProcess<BlastFreezerDetails>();
                    foreach (int selectedRow in selectedRows)
                    {
                        BlastFreezerDetails deletingBlastFreezerDetails = (BlastFreezerDetails)grvBlastFreezerTemperatureDetails.GetRow(selectedRow);
                        blastFreezerDetailsDA.ExecuteNoQuery("DELETE FROM BlastFreezerDetails WHERE BlastFreezerDetailsID = {0}", deletingBlastFreezerDetails.BlastFreezerDetailsID);
                    }
                    currentBlastFreezers.BlastFreezerDetails = blastFreezerDetailsDA.Select(c => c.BlastFreezerID == currentBlastFreezers.BlastFreezerID).ToList();
                    BindingList<BlastFreezerDetails> blastFreezerDetailList = new BindingList<BlastFreezerDetails>(currentBlastFreezers.BlastFreezerDetails.ToList());
                    grcBlastFreezerTemperatureDetails.DataSource = blastFreezerDetailList;
                    grvBlastFreezerTemperatureDetails.RefreshData();
                }
                catch (Exception ex)
                {
                    StringBuilder strBuilder = new StringBuilder();
                    strBuilder.AppendLine("Exception Source: " + ex.Source);
                    strBuilder.AppendLine("Exception Message: " + ex.Message);
                    strBuilder.AppendLine("Exception StackTrace: " + ex.StackTrace);
                    strBuilder.AppendLine("Please Notice for IT Department with this exception infomations !");
                    MessageBox.Show(strBuilder.ToString(), "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dtngBlastFreezers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Left)
                dtngBlastFreezers.Position = dtngBlastFreezers.Position - 1;
            else if (e.KeyData == Keys.Right)
                dtngBlastFreezers.Position = dtngBlastFreezers.Position + 1;
            else if (e.KeyData == Keys.Up)
                dtngBlastFreezers.Position = 0;
            else if (e.KeyData == Keys.Down)
                dtngBlastFreezers.Position = ((IList<BlastFreezers>)dtngBlastFreezers.DataSource).Count;
        }

        private void frm_WM_BlastFreezers_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (isUpdate <= 0)
            //    btnUpdateAll.PerformClick();
        }

        private void grvBlastFreezerTemperatureDetails_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle != GridControl.NewItemRowHandle)
            {
                BlastFreezerDetails updateBlastFreezerDetails = (BlastFreezerDetails)grvBlastFreezerTemperatureDetails.GetRow(e.RowHandle);
                if (updateBlastFreezerDetails != null)
                {
                    DataProcess<BlastFreezerDetails> blastFreezerDetailsDA = new DataProcess<BlastFreezerDetails>();
                    int resultUpdate = blastFreezerDetailsDA.Update(updateBlastFreezerDetails);
                }
            }
        }

        private void btnClose1_Click(object sender, EventArgs e)
        {
            this.Close();
        }        

        private void btn_Confirm_Blast_Freezers_Click(object sender, EventArgs e)
        {
            if (txtUloadingTime.EditValue == null || txtStartLoadingTime.EditValue == null)
                MessageBox.Show("Can not confirm, Please enter times !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtStartRunTime.EditValue == null || txtEndRunTime.EditValue == null)
                MessageBox.Show("Can not confirm, Plant room has not input data !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                currentBlastFreezers.BlastFreezerConfirm = true;
                DataProcess<BlastFreezers> blastFreezersDA = new DataProcess<BlastFreezers>();
                int resultUpdate = blastFreezersDA.Update(currentBlastFreezers);
                if (resultUpdate > 0)
                {
                    UpdateControlsBy(currentBlastFreezers);
                    UpdateControlStatus();
                }
                else
                    MessageBox.Show("Confirm failed !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_UpdateAll_BlastFreezers_Click(object sender, EventArgs e)
        {

            BlastFreezers updateBlastFreezers = new BlastFreezers();
            updateBlastFreezers = currentBlastFreezers;
            updateBlastFreezers.BlastFreezerID = currentBlastFreezers.BlastFreezerID;
            updateBlastFreezers.BlastFreezerRecordNumber = currentBlastFreezers.BlastFreezerRecordNumber;
            updateBlastFreezers.DateIn = currentBlastFreezers.DateIn;
            updateBlastFreezers.CustomerID = Convert.ToInt32(lkeCustomerNumber.GetColumnValue("CustomerID"));
            updateBlastFreezers.CustomerName = txtCustomerName.EditValue != null ? txtCustomerName.EditValue.ToString() : "";
            updateBlastFreezers.BlastFreezerRoomID = Convert.ToInt32(lkeBlastFreezerRoomID.EditValue);
            updateBlastFreezers.BlastFreezerConfirm = currentBlastFreezers.BlastFreezerConfirm;
            updateBlastFreezers.UserName = txtUsername.EditValue != null ? txtUsername.EditValue.ToString() : "";
            updateBlastFreezers.StartLoadingTime = txtStartLoadingTime.EditValue != null ? Convert.ToDateTime(txtStartLoadingTime.EditValue) : (DateTime?)null;
            updateBlastFreezers.EndLoadingTime = txtEndLoadingTime.EditValue != null ? Convert.ToDateTime(txtEndLoadingTime.EditValue) : (DateTime?)null;
            updateBlastFreezers.BlastFreezerUloadingTime = txtUloadingTime.EditValue != null ? Convert.ToDateTime(txtUloadingTime.EditValue) : (DateTime?)null;
            updateBlastFreezers.BlastFreezerLoadingBy = txtBlastFreezerLoadingBy.EditValue != null ? txtBlastFreezerLoadingBy.EditValue.ToString() : "";
            updateBlastFreezers.TempIn = txtTempIn.EditValue != null ? Convert.ToDouble(txtTempIn.EditValue) : (double?)null;
            updateBlastFreezers.TempOut = txtTempOut.EditValue != null ? Convert.ToDouble(txtTempOut.EditValue) : (double?)null;
            updateBlastFreezers.ProductDetailsRemark = meRemark.EditValue != null ? meRemark.EditValue.ToString() : "";
            updateBlastFreezers.StartRunTime = txtStartRunTime.EditValue != null ? Convert.ToDateTime(txtStartRunTime.EditValue) : (DateTime?)null;
            updateBlastFreezers.StartRunUser = txtStartRunUser.EditValue != null ? txtStartRunUser.EditValue.ToString() : "";
            updateBlastFreezers.EndRunTime = txtEndRunTime.EditValue != null ? Convert.ToDateTime(txtEndRunTime.EditValue) : (DateTime?)null;
            updateBlastFreezers.EndRunUser = txtEndRunUser.EditValue != null ? txtEndRunUser.EditValue.ToString() : "";
            updateBlastFreezers.BlastFreezerRunningRemark = meBlastFreezerRunningRemark.EditValue != null ? meBlastFreezerRunningRemark.EditValue.ToString() : string.Empty;
            updateBlastFreezers.ReceivingOrder = txtRO.EditValue != null ? txtRO.EditValue.ToString() : string.Empty;
            updateBlastFreezers.Qty = Convert.ToDouble(txtQty.EditValue);
            updateBlastFreezers.Weight = Convert.ToDouble(txtWeight.EditValue);
            updateBlastFreezers.ReceivingOrder = txtRO.EditValue != null ? txtRO.EditValue.ToString() : string.Empty;
            updateBlastFreezers.TimeProductIn = txtProductIn.EditValue != null ? Convert.ToDateTime(txtProductIn.EditValue) : (DateTime?)null;
            updateBlastFreezers.TimeProductOut = txtProductOut.EditValue != null ? Convert.ToDateTime(txtProductOut.EditValue) : (DateTime?)null;
            DataProcess<BlastFreezers> blastFreezersDA = new DataProcess<BlastFreezers>();
            int result = blastFreezersDA.Update(currentBlastFreezers);
            if (result > 0)
            {
                MessageBox.Show("Update a BlasFreezer is successful !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                isUpdate += 1;
                //Loại lại dữ liệu cho form
                DateTime comparedTimeValue = DateTime.Now.AddDays(-31);
                blastFreezersList = blastFreezersDA.Select(bf => (bf.DateIn.CompareTo(comparedTimeValue)) > 0).ToList();

                dtngBlastFreezers.DataSource = blastFreezersList;
                dtngBlastFreezers.Position = blastFreezersList.Count;
            }
            else
                MessageBox.Show("Update a BlasFreezer is failed !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btn_CreatNew_BlastFreezers_Click(object sender, EventArgs e)
        {
            txtBlastFreezerRecordNumber.EditValue = null;
            txtCustomerName.EditValue = null;
            lkeBlastFreezerRoomID.EditValue = 1;
            deDateIn.EditValue = DateTime.Now;
            txtUsername.EditValue = AppSetting.CurrentUser.LoginName;
            txtStartLoadingTime.EditValue = null;
            txtEndLoadingTime.EditValue = null;
            txtUloadingTime.EditValue = null;
            lkeEmployeeID.EditValue = null;
            txtBlastFreezerLoadingBy.EditValue = null;
            txtTempIn.EditValue = null;
            txtTempOut.EditValue = null;
            meRemark.EditValue = "Nothing";
            txtStartRunTime.EditValue = null;
            txtStartRunUser.EditValue = null;
            txtEndRunTime.EditValue = null;
            txtEndRunUser.EditValue = null;
            txtTempOut.EditValue = null;
            txtTempIn.EditValue = null;
            txtRO.EditValue = null;
            txtQty.EditValue = null;
            txtWeight.EditValue = null;
            meBlastFreezerRunningRemark.EditValue = null;
            grcBlastFreezerTemperatureDetails.DataSource = null;
            BindingList<BlastFreezerDetails> blastFreezerDetailList = new BindingList<BlastFreezerDetails>();
            grcBlastFreezerTemperatureDetails.DataSource = blastFreezerDetailList;

            grvBlastFreezerTemperatureDetails.RefreshData();
            grvBlastFreezerTemperatureDetails.OptionsBehavior.ReadOnly = false;
            lkeCustomerNumber.Enabled = true;
            txtCustomerName.Enabled = true;
            lkeBlastFreezerRoomID.Enabled = true;
            deDateIn.Enabled = true;
            panelControl1.Enabled = true;

            isCreateNew = true;
            lkeCustomerNumber.Focus();
            lkeCustomerNumber.ShowPopup();
        }

        private void BtnWmNewBlastFreezers_Click(object sender, EventArgs e)
        {
            txtBlastFreezerRecordNumber.EditValue = null;
            txtCustomerName.EditValue = null;
            lkeBlastFreezerRoomID.EditValue = 1;
            deDateIn.EditValue = DateTime.Now;
            txtUsername.EditValue = AppSetting.CurrentUser.LoginName;
            txtStartLoadingTime.EditValue = null;
            txtEndLoadingTime.EditValue = null;
            txtUloadingTime.EditValue = null;
            lkeEmployeeID.EditValue = null;
            txtBlastFreezerLoadingBy.EditValue = null;
            txtTempIn.EditValue = null;
            txtTempOut.EditValue = null;
            meRemark.EditValue = "Nothing";
            txtStartRunTime.EditValue = null;
            txtStartRunUser.EditValue = null;
            txtEndRunTime.EditValue = null;
            txtEndRunUser.EditValue = null;
            txtTempOut.EditValue = null;
            txtTempIn.EditValue = null;
            txtRO.EditValue = null;
            txtQty.EditValue = null;
            txtWeight.EditValue = null;
            meBlastFreezerRunningRemark.EditValue = null;
            grcBlastFreezerTemperatureDetails.DataSource = null;
            BindingList<BlastFreezerDetails> blastFreezerDetailList = new BindingList<BlastFreezerDetails>();
            grcBlastFreezerTemperatureDetails.DataSource = blastFreezerDetailList;

            grvBlastFreezerTemperatureDetails.RefreshData();
            grvBlastFreezerTemperatureDetails.OptionsBehavior.ReadOnly = false;
            lkeCustomerNumber.Enabled = true;
            txtCustomerName.Enabled = true;
            lkeBlastFreezerRoomID.Enabled = true;
            deDateIn.Enabled = true;
            panelControl1.Enabled = true;

            isCreateNew = true;
            lkeCustomerNumber.Focus();
            lkeCustomerNumber.ShowPopup();
        }

        private void btn_Delete_Blast_Freezers_Click_1(object sender, EventArgs e)
        {
            if (grvBlastFreezerTemperatureDetails.DataRowCount > 0)
                MessageBox.Show("Can not delete records with details !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (MessageBox.Show("Are you sure to delete this record ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    //DataProcess<BlastFreezers> blastFreezersDA = new DataProcess<BlastFreezers>();
                    //int resultDelete = blastFreezersDA.ExecuteNoQuery("DELETE FROM BlastFreezers WHERE BlastFreezerID = {0}", currentBlastFreezers.BlastFreezerID);

                    ////Loại lại dữ liệu cho form
                    //DateTime comparedTimeValue = DateTime.Now.AddDays(-31);
                    //blastFreezersList = blastFreezersDA.Select(bf => (bf.DateIn.CompareTo(comparedTimeValue)) > 0).ToList();

                    //dtngBlastFreezers.DataSource = blastFreezersList;
                    //dtngBlastFreezers.Position = blastFreezersList.Count;
                }
            }

        }

        private void btn_Delete_Blast_Freezers_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
          
            
            
        }

        private void btnSearch_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataProcess<BlastFreezers> blastFreezersDA = new DataProcess<BlastFreezers>();
            List<BlastFreezers> blastFreezersList1 = blastFreezersDA.Select().ToList();
            if (btnSearch.EditValue == null) return;

            currentBlastFreezers = blastFreezersList1.Find(s => s.BlastFreezerID == Convert.ToInt32(btnSearch.EditValue));
            if (currentBlastFreezers != null)
            {
                if (blastFreezersList.Find(s => s.BlastFreezerID == currentBlastFreezers.BlastFreezerID) == null)
                {
                    blastFreezersList.Add(currentBlastFreezers);
                    currentBlastFreezers = blastFreezersList.ElementAt(blastFreezersList.Count - 1);
                    UpdateControlsBy(currentBlastFreezers);
                    UpdateControlStatus();
                    dtngBlastFreezers.Position = blastFreezersList.Count - 1;
                }
                else
                {
                    currentBlastFreezers = blastFreezersList.ElementAt(blastFreezersList.IndexOf(blastFreezersList.Find(s => s.BlastFreezerID == currentBlastFreezers.BlastFreezerID)));
                    UpdateControlsBy(currentBlastFreezers);
                    UpdateControlStatus();
                    dtngBlastFreezers.Position = blastFreezersList.IndexOf(blastFreezersList.Find(s => s.BlastFreezerID == currentBlastFreezers.BlastFreezerID));
                }

            }
            else
            {
                return;
            }
        }
        Regex re = new Regex(@"\d+:\d+:\d+\D{3}");

        private void btnPrint_Click(object sender, EventArgs e)
        {
            int BlastFreezeID = Convert.ToInt32(Convert.ToString(txtBlastFreezerRecordNumber.Text).Substring(3));
            DataProcess<STCustomerRequirementPrint_Result> printISO = new DataProcess<STCustomerRequirementPrint_Result>();
            int receivingOrderID = BlastFreezeID;
          //  int customerID = Convert.ToInt32(lkeCustomerNumber.EditValue);

            Customers customerSelected = daCustomer.Executing("SELECT * FROM dbo.Customers WHERE StoreID=" + AppSetting.CurrentUser.StoreID).Where(x=>x.CustomerNumber==Convert.ToString(lkeCustomerNumber.EditValue)).FirstOrDefault();
            // .Where(x => x.CustomerID == customerID).FirstOrDefault();
            if(customerSelected==null)
            {
                MessageBox.Show("Can't Customer", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int customerMainIDISO = Convert.ToInt32(customerSelected.CustomerMainID);
            int customerID = customerSelected.CustomerID;
            // init datasource
            List<STCustomerRequirementPrint_Result> dataPrintISOList = printISO.Executing("STCustomerRequirementPrint @CustomerMainID={0}, @Flag={1}, @ReceivingOrderID={2}", customerMainIDISO, 3, receivingOrderID).ToList();
            dataPrintISOList = dataPrintISOList.OrderByDescending(a => a.CustomerRequirementID).ToList();
            STCustomerRequirementPrint_Result dataPrintISO = dataPrintISOList.FirstOrDefault();
            //Customers customer = listCustomer.FirstOrDefault(c => c.CustomerID == customerID);
            StringBuilder strRequirementDetails = new StringBuilder();
            foreach (var item in dataPrintISOList)
            {
                strRequirementDetails.Append(item.RequirementDetails + Environment.NewLine);
            }
            ReportPrintToolWMS printTool = null;

                rptBlastFreezreISO rpt = new rptBlastFreezreISO();
                Match rsStartLoadingTime = re.Match(saveCurrentBlastFreezers.StartLoadingTime.ToString());
                Match rsEndLoadingTime = re.Match(saveCurrentBlastFreezers.EndLoadingTime.ToString());

                Match rsTemperatureProductIn = re.Match(saveCurrentBlastFreezers.TimeProductIn.ToString());

                Match rsTemperatureProductOut = re.Match(saveCurrentBlastFreezers.TimeProductOut.ToString());
                Match rsStartRunTime = re.Match(saveCurrentBlastFreezers.StartRunTime.ToString());
                Match rsEndRunTime = re.Match(saveCurrentBlastFreezers.EndRunTime.ToString());

                rpt.Parameters["varNgay"].Value = saveCurrentBlastFreezers.DateIn.ToShortDateString() ;
                rpt.Parameters["varCustomer"].Value = txtCustomerName.Text;
                rpt.Parameters["varRO"].Value = txtRO.Text;
                rpt.Parameters["varStart"].Value = rsStartLoadingTime.ToString();
                rpt.Parameters["varEnd"].Value = rsEndLoadingTime.ToString();
                rpt.Parameters["varProductIn"].Value = rsTemperatureProductIn.ToString();
                rpt.Parameters["varProductOut"].Value = rsTemperatureProductOut.ToString();
                rpt.Parameters["varStartAt"].Value = rsStartRunTime.ToString();
                rpt.Parameters["varEndAt"].Value = rsEndRunTime.ToString();
                rpt.Parameters["tempIn"].Value = Convert.ToDecimal(saveCurrentBlastFreezers.TempIn);
                rpt.Parameters["tempOut"].Value = Convert.ToDecimal(saveCurrentBlastFreezers.TempOut);
            
                rpt.Parameters["varBF"].Value = Convert.ToString(saveCurrentBlastFreezers.BlastFreezerID);
                rpt.Parameters["varEmployee"].Value = txtBlastFreezerLoadingBy.Text;
                rpt.Parameters["varName"].Value = meRemark.Text;
                rpt.Parameters["varQty"].Value = Convert.ToString(txtQty.EditValue);
                rpt.Parameters["varWeight"].Value = Convert.ToString(txtWeight.EditValue);
                rpt.Parameters["varCurrentUser"].Value = Convert.ToString(AppSetting.CurrentUser.LoginName);


                rpt.RequestParameters = false;
                printTool = new ReportPrintToolWMS(rpt);
            printTool.AutoShowParametersPanel = false;
            printTool.ShowPreview();
            


        }

        private void btnAttackment_Click(object sender, EventArgs e)
        {
            string CustomerNumber = txtBlastFreezerRecordNumber.Text.ToString();
     
            Customers customerSelected = daCustomer.Executing("SELECT * FROM dbo.Customers WHERE StoreID=" + AppSetting.CurrentUser.StoreID).Where(x => x.CustomerNumber == Convert.ToString(lkeCustomerNumber.EditValue)).FirstOrDefault();
            if (customerSelected == null)
            {
                MessageBox.Show("Can't Customer", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            Int16 CustomerID = Convert.ToInt16(lkeCustomerNumber.EditValue.ToString().Substring(4));
            frm_WM_Attachments.Instance.OrderNumber = CustomerNumber;
            frm_WM_Attachments.Instance.CustomerID = CustomerID;
            if (frm_WM_Attachments.Instance.Enabled) frm_WM_Attachments.Instance.ShowDialog();
            this.Init();
           
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            string CustomerNumber = txtBlastFreezerRecordNumber.Text;
            Int16 CustomerID = Convert.ToInt16(lkeCustomerNumber.EditValue.ToString().Substring(4));
            if (keyData == Keys.F3)
            {
                frm_WM_Attachments.Instance.OrderNumber = CustomerNumber;
                frm_WM_Attachments.Instance.CustomerID = CustomerID;
                if (frm_WM_Attachments.Instance.Enabled) frm_WM_Attachments.Instance.ShowDialog();
                this.Init();
            }
            return base.ProcessDialogKey(keyData);
        }

        private void btn_ListBF_Click(object sender, EventArgs e)
        {
            frm_WM_BlastFreezerList frm_listBF = new frm_WM_BlastFreezerList();
            frm_listBF.Show();
          

        }
        public void FindBlastFreezer(string bf)
        {
            int index = blastFreezersList.FindIndex(n => n.BlastFreezerRecordNumber == bf);
            if (index < 0)
            {
                MessageBox.Show("BlastFreezer find error");
                return;
            }
            dtngBlastFreezers.Position = index;
        }
    }

}
