using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DA;
using Common.Controls;
using UI.Helper;
using DevExpress.XtraEditors;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_CustomerServices : frmBaseForm
    {
        private urc_WM_EmployeeInfo empl_info = null;
        private urc_WM_OtherService other_serv = null;
        private urc_WM_OutsourcedJobLinked OJLinked = null;
        private DataProcess<CustomerServiceOrder> CustomerServiceOrderDataProcess = new DataProcess<DA.CustomerServiceOrder>();
        private bool isFirstLoad = false;
        int index = 2;
        public frm_WM_CustomerServices()
        {
            InitializeComponent();
            this.dtFromDate.EditValue = DateTime.Today;
            this.dtToDate.EditValue = DateTime.Today;
            LoadData();
            RefreshOrderGrid();
        }

        #region Get Data
        private void LoadData()
        {
            this.grcCustomerServicesOrders.DataSource = FileProcess.LoadTable("ST_WMS_LoadCustomerServiceOrders");
            this.AddNewRow();
            this.rpi_lke_CustomerList.DataSource = AppSetting.CustomerList;
            this.rpi_lke_CustomerList.DisplayMember = "CustomerNumber";
            this.rpi_lke_CustomerList.ValueMember = "CustomerID";

        }
        private void BindData()
        {
            // Neu chua chon dong nao tren grid thi return
            if (this.grvCustomerServicesOrders.FocusedRowHandle < 0) return;

            // Lay customer service id cua dong hien tai dang chon
            var customerServiceID = Convert.ToInt32(this.grvCustomerServicesOrders.GetFocusedRowCellValue("CustomerServiceOrderID"));

            var currentCus = this.CustomerServiceOrderDataProcess.Select(c => c.CustomerServiceOrderID == customerServiceID).FirstOrDefault();
            if (currentCus == null) currentCus = new CustomerServiceOrder();
            this.textRequestedBy.EditValue = currentCus.RequestedBy;
            this.textExpectedCompleteTime.EditValue = currentCus.ExpectedCompleteTime;
            this.textStartTime.EditValue = currentCus.StartTime;
            this.textEndTime.EditValue = currentCus.EndTime;
            this.textLabourRequirements.EditValue = currentCus.LabourRequirements;
        }
        private void AddNewRow()
        {
            try
            {
                var datasourece = (DataTable)this.grcCustomerServicesOrders.DataSource;
                var newRow = datasourece.NewRow();
                newRow["CustomerServiceOrderNumber"] = "";
                newRow["CustomerID"] = 0;
                newRow["CreatedBy"] = AppSetting.CurrentUser.LoginName;
                newRow["CreatedTime"] = DateTime.Now.ToString("yyyy-MM-dd");
                newRow["CustomerID"] = 0;
                newRow["Confirmed"] = 0;
                datasourece.Rows.Add(newRow);
            }
            catch (Exception) { }
           
        }
        public void SetValueInsertOrUpdate(CustomerServiceOrder CustomerServiceOrder)
        {
            CustomerServiceOrder.CustomerServiceOrderRemark = (string)this.grvCustomerServicesOrders.GetFocusedRowCellValue("CustomerServiceOrderRemark");
            CustomerServiceOrder.FunctionReferenceNumber = (string)this.grvCustomerServicesOrders.GetFocusedRowCellValue("FunctionReferenceNumber");
            CustomerServiceOrder.RequestedBy = (string)textRequestedBy.EditValue;
            CustomerServiceOrder.RequestedTime = DateTime.Now;
            CustomerServiceOrder.LabourRequirements = (string)textLabourRequirements.EditValue;
            if (!textExpectedCompleteTime.Text.Equals(""))
            {
                CustomerServiceOrder.ExpectedCompleteTime = (DateTime)textExpectedCompleteTime.EditValue;
            }
            if (!textStartTime.Text.Equals(""))
            {
                CustomerServiceOrder.StartTime = (DateTime)textStartTime.EditValue;
            }
            if (!textEndTime.Text.Equals(""))
            {
                CustomerServiceOrder.EndTime = (DateTime)textEndTime.EditValue;
            }
        }
        #endregion

        #region Handle grvCustomerServicesOrders
        // Select Row grvCustomerServicesOrders
        private void grvCustomerServicesOrders_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            isFirstLoad = true;
            BindData();
            if (this.grvCustomerServicesOrders.FocusedRowHandle > -1)
            {
                if (this.grvCustomerServicesOrders.GetRowCellValue(this.grvCustomerServicesOrders.FocusedRowHandle, "ConfirmedBy").Equals(""))// chua confirm 
                {
                    EnableOrNot(true);
                }
                else//confirm 
                {
                    EnableOrNot(false);
                }
                int varCustomerServiceOrderID = (int)this.grvCustomerServicesOrders.GetFocusedRowCellValue("CustomerServiceOrderID");
                this.grcCustomerServiceFunctionDetails.DataSource = FileProcess.LoadTable("STCustomerServiceOrders_FunctionDetails " + varCustomerServiceOrderID);
                if (this.empl_info != null)
                {
                    RefreshEmployeeData();
                }
            }

            isFirstLoad = false;
        }
        // Insert row customer service order
        private void lkCustomer_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.Value == null || Convert.IsDBNull(e.Value)) return;// value
            DataProcess<Customers> customerDA = new DataProcess<Customers>();
            var customerCurrent = customerDA.Select(n => n.CustomerID == (int)e.Value).FirstOrDefault();
            if (customerCurrent == null) return;
            // Show customer Name
            this.grvCustomerServicesOrders.SetFocusedRowCellValue("CustomerName", customerCurrent.CustomerName);// loi

            var customerServiceOrderNumber = this.grvCustomerServicesOrders.GetFocusedRowCellValue("CustomerServiceOrderNumber");

            string queryInsert = "Insert into CustomerServiceOrders (CustomerServiceOrderNumber, CustomerID, CustomerServiceOrderRemark, FunctionReferenceNumber, CreatedBy, CreatedTime, ConfirmedBy, ConfirmedTime, RequestedBy, RequestedTime, ExpectedCompleteTime, StartTime, EndTime, LabourRequirements) values ('" +
                                    "','" + (int)e.Value + "','" + this.grvCustomerServicesOrders.GetFocusedRowCellValue("CustomerServiceOrderRemark") + "','" + this.grvCustomerServicesOrders.GetFocusedRowCellValue("FunctionReferenceNumber") + "','" +
                                    AppSetting.CurrentUser.LoginName + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','','','','','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','')";

            string queryUpdate = "update CustomerServiceOrders set CustomerID=" + (int)e.Value + "where CustomerServiceOrderNumber='" + (string)customerServiceOrderNumber + "'";
            DataProcess<object> dataProcess = new DataProcess<object>();
            if (customerServiceOrderNumber.Equals(""))
            {
                int result = dataProcess.ExecuteNoQuery(queryInsert);
                if (result < 0)
                {
                    MessageBox.Show("Cannot Insert CustomerServiceOrders!", "TPWMS",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    LoadData();
                }
            }
            else
            {
                int result = dataProcess.ExecuteNoQuery(queryUpdate);
                if (result < 0)
                {
                    MessageBox.Show("Cannot Update CustomerID!", "TPWMS",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    LoadData();
                }
            }
        }
        //delete row grvCustomerServicesOrders
        private void grvCustomerServicesOrders_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("You are about to delete a CustomerServicesOrders .\n"
              + "If you click Yes, you won't be able to undo this Delete operation.\n"
              + "Do you sure to delete these records ?", "TPWMS",
              MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                 == DialogResult.Yes)
                {
                    var customerServiceOrderNumber = this.grvCustomerServicesOrders.GetFocusedRowCellValue("CustomerServiceOrderNumber");
                    DataProcess<object> dataProcess = new DataProcess<object>();
                    int result = dataProcess.ExecuteNoQuery("Delete from CustomerServiceOrders where CustomerServiceOrderNumber={0} ", (string)customerServiceOrderNumber);

                    if (result < 0)
                    {
                        MessageBox.Show("Cannot Delete CustomerServiceOrders!", "TPWMS",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        LoadData();
                    }
                }
            }
        }
        //update row 
        private void grvCustomerServicesOrders_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            EnableOrNot(true);
            var customerServiceOrderNumber = this.grvCustomerServicesOrders.GetFocusedRowCellValue("CustomerServiceOrderNumber");
            if (!customerServiceOrderNumber.Equals(""))
            {
                CustomerServiceOrder customerServiceOrder = CustomerServiceOrderDataProcess.Select(n => n.CustomerServiceOrderNumber == (string)customerServiceOrderNumber).FirstOrDefault();
                SetValueInsertOrUpdate(customerServiceOrder);
                int result = CustomerServiceOrderDataProcess.Update(customerServiceOrder);
                if (result < 0)
                {
                    MessageBox.Show("Cannot Update CustomerServiceOrders!", "TPWMS",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    this.grvCustomerServicesOrders.SetFocusedRowCellValue("CustomerServiceOrderRemark", customerServiceOrder.CustomerServiceOrderRemark);
                    this.grvCustomerServicesOrders.SetFocusedRowCellValue("FunctionReferenceNumber", customerServiceOrder.FunctionReferenceNumber);
                    //LoadData();
                }
            }
        }
        // draw row Confirmed
        private void grvCustomerServicesOrders_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {

            if (e.RowHandle < this.grvCustomerServicesOrders.RowCount - 1)
            {
                if (this.grvCustomerServicesOrders.GetRowCellValue(e.RowHandle, "ConfirmedBy").Equals("") || this.grvCustomerServicesOrders.GetRowCellValue(e.RowHandle, "ConfirmedBy") == null)// chua confirm 
                {
                }
                else
                {
                    e.Appearance.BackColor = Color.FromArgb(100, Color.Yellow);
                }
            }
        }
        // Disable edit
        private void grvCustomerServicesOrders_ShowingEditor(object sender, CancelEventArgs e)
        {

            //if (Convert.ToInt32(this.grvCustomerServicesOrders.GetRowCellValue(this.grvCustomerServicesOrders.FocusedRowHandle, "Confirmed")) == 1)// chua confirm 
            //{
            //    e.Cancel = true;
            //}
        }
        #endregion

        #region Handle Dock 
        private void dockPanelEmployees_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            if (this.empl_info == null)
            {
                empl_info = new urc_WM_EmployeeInfo((string)this.grvCustomerServicesOrders.GetFocusedRowCellValue("CustomerServiceOrderNumber"), 0, 0, 0);
                this.empl_info.Parent = this.dockPanelEmployees;
                this.empl_info.Dock = DockStyle.Fill;
            }
            else
            {
                RefreshEmployeeData();
            }
        }
        private void RefreshEmployeeData()
        {
            //this.empl_info.UpdateParameter(totalCartons, totalPallet, totalWeight);
            this.empl_info.LoadEmployeeWorking((string)this.grvCustomerServicesOrders.GetFocusedRowCellValue("CustomerServiceOrderNumber"));
            this.empl_info.Update();
            this.empl_info.Refresh();
        }

        private void dockPanelServices_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            if (this.other_serv == null)
            {
                other_serv = new urc_WM_OtherService((string)this.grvCustomerServicesOrders.GetFocusedRowCellValue("CustomerServiceOrderNumber"));
                this.other_serv.Parent = this.dockPanelServices;
                this.other_serv.Dock = DockStyle.Fill;
            }
            else
            {
                other_serv.InitData((string)this.grvCustomerServicesOrders.GetFocusedRowCellValue("CustomerServiceOrderNumber"));
            }
        }

        #endregion

        #region Handle Confirm
        private void rpe_ce_Confirmed_Click(object sender, EventArgs e)
        {
            CheckEdit ck = sender as CheckEdit;
            if (MessageBox.Show("You are comfirm?", "TPWMS",
           MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            == DialogResult.Yes)
            {
                if (!isFirstLoad)
                {
                    if (!ck.Checked)
                    {
                        ConfirmCustomerServiceOrder();
                        ck.Checked = true;
                        ck.ReadOnly = true;
                        EnableOrNot(false);
                        return;
                    }
                    else
                    {
                        ck.Checked = false;
                        return;
                    }
                }
            }
        }
        private void EnableOrNot(bool isActive)
        {
            textEndTime.Enabled = isActive;
            textExpectedCompleteTime.Enabled = isActive;
            textLabourRequirements.Enabled = isActive;
            textRequestedBy.Enabled = isActive;
            textStartTime.Enabled = isActive;
        }
        #endregion

        #region Handle with database
        public void UpdateCustomerServiceOrder()
        {
            var customerServiceOrderNumber = this.grvCustomerServicesOrders.GetFocusedRowCellValue("CustomerServiceOrderNumber");
            if (!customerServiceOrderNumber.Equals(""))
            {
                CustomerServiceOrder customerServiceOrder = CustomerServiceOrderDataProcess.Select(n => n.CustomerServiceOrderNumber == (string)customerServiceOrderNumber).FirstOrDefault();
                SetValueInsertOrUpdate(customerServiceOrder);
                int result = CustomerServiceOrderDataProcess.Update(customerServiceOrder);
                if (result < 0)
                {
                    MessageBox.Show("Cannot Update CustomerServiceOrders!", "TPWMS",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //this.grvCustomerServicesOrders.SetFocusedRowCellValue("CustomerServiceOrderRemark", customerServiceOrder.CustomerServiceOrderRemark);
                    //this.grvCustomerServicesOrders.SetFocusedRowCellValue("FunctionReferenceNumber", customerServiceOrder.FunctionReferenceNumber);

                    this.grvCustomerServicesOrders.SetFocusedRowCellValue("RequestedBy", customerServiceOrder.RequestedBy);
                    this.grvCustomerServicesOrders.SetFocusedRowCellValue("RequestedTime", customerServiceOrder.RequestedTime);
                    this.grvCustomerServicesOrders.SetFocusedRowCellValue("StartTime", customerServiceOrder.StartTime);
                    this.grvCustomerServicesOrders.SetFocusedRowCellValue("EndTime", customerServiceOrder.EndTime);
                    this.grvCustomerServicesOrders.SetFocusedRowCellValue("LabourRequirements", customerServiceOrder.LabourRequirements);


                    // LoadData();
                    // this.grvCustomerServicesOrders.rows= 1;
                }
            }
            else
            {
                LoadData();
                MessageBox.Show("Check CustomerServiceOrdersNumber!", "TPWMS",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Xử Lý confirmed
        public void ConfirmCustomerServiceOrder()
        {
            var customerServiceOrderNumber = this.grvCustomerServicesOrders.GetFocusedRowCellValue("CustomerServiceOrderNumber");
            if (!customerServiceOrderNumber.Equals(""))
            {
                CustomerServiceOrder customerServiceOrder = CustomerServiceOrderDataProcess.Select(n => n.CustomerServiceOrderNumber == (string)customerServiceOrderNumber).FirstOrDefault();
                customerServiceOrder.ConfirmedBy = AppSetting.CurrentUser.LoginName;
                customerServiceOrder.ConfirmedTime = DateTime.Now;
                SetValueInsertOrUpdate(customerServiceOrder);
                int result = CustomerServiceOrderDataProcess.Update(customerServiceOrder);
                if (result < 0)
                {
                    MessageBox.Show("Cannot Update CustomerServiceOrders!", "TPWMS",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    LoadData();
                    // this.grvCustomerServicesOrders.rows= 1;
                }
            }
            else
            {
                LoadData();
                MessageBox.Show("Check CustomerServiceOrdersNumber!", "TPWMS",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region edit value
        private void textEndTime_EditValueChanged(object sender, EventArgs e)
        {
            if (!isFirstLoad)
            {
                UpdateCustomerServiceOrder();
            }
        }

        private void textStartTime_EditValueChanged(object sender, EventArgs e)
        {
            if (!isFirstLoad)
            {
                UpdateCustomerServiceOrder();
            }
        }

        private void textLabourRequirements_Leave(object sender, EventArgs e)
        {
            if (!isFirstLoad)
            {
                UpdateCustomerServiceOrder();
            }
        }

        private void textRequestedBy_Leave(object sender, EventArgs e)
        {
            if (!isFirstLoad)
            {
                UpdateCustomerServiceOrder();

            }
        }

        private void textExpectedCompleteTime_EditValueChanged_1(object sender, EventArgs e)
        {
            if (!isFirstLoad)
            {
                UpdateCustomerServiceOrder();
            }
        }
        #endregion

        #region To - > Form
        private void dtToDate_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            RefreshOrderGrid();
            
        }
        private void RefreshOrderGrid()
        {
            int compare = DateTime.Compare((DateTime)this.dtFromDate.EditValue, (DateTime)this.dtToDate.EditValue);
            if (compare <= 0)
            {
                this.grcCustomerServicesOrders.DataSource = FileProcess.LoadTable("ST_WMS_LoadCustomerServiceOrdersByDay '" + Convert.ToDateTime(this.dtFromDate.EditValue).ToString("MM/dd/yyyy") + "','" + Convert.ToDateTime(this.dtToDate.EditValue).ToString("MM/dd/yyyy") + "'");
                AddNewRow();
               // this.rpi_lke_CustomerList.DataSource = AppSetting.CustomerList;
               // this.rpi_lke_CustomerList.DisplayMember = "CustomerNumber";
               // this.rpi_lke_CustomerList.ValueMember = "CustomerID";
            }
            else
            {
                MessageBox.Show("PLease input correct date !", "TPWMS");
            }
        }
        private void dtFromDate_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            RefreshOrderGrid();
        }
        #endregion

      
    }

}
