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
using System.Globalization;
using System.Runtime.InteropServices;
using UI.ReportForm;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_MHLWorks : frmBaseForm
    {
        private DataProcess<ST_WMS_LoadWorks_Result> _workDA;
        private DataProcess<ST_WMS_LoadWorkDetails_Result> _workDetailDA;
        private BindingList<ST_WMS_LoadWorks_Result> _listWorks;
        private BindingList<EmployeeMHLEntry> listEmployeeEntry;
        private DataTable _tableWorks;
        private DataRow _selectedWork;
        private bool _isFirstLoad;
        private bool _isAddNew;
        private int mhlWorkID;
        private frm_WM_MHLWorkDefinitions frmWorkDefinition = null;
        private frm_WM_Dialog_MHLWorkEmployeeAddNew frmEntry = null;
        //private frm_WM_MHLWorkEmployeeSummary frmWorkEmplyeeSummary = null;
        private frm_WM_MHLWorkDefinitionList frmWorkDifinitionList = null;
        private static readonly frm_WM_MHLWorks instance = new frm_WM_MHLWorks();
        private frm_WM_OtherJobTheSameTime frmOtherJobTheSameTime = null;
        private bool IsConfirmClick = false;
        private OutsourceJobEnum currentJobState = OutsourceJobEnum.All;
        private urc_WM_EmployeeInfo viewEmployee = null;
        private List<STOtherService_Work_Mapping_Result> listOtherService;
        private string orderNumberInput = string.Empty;
        private urc_WM_ServicesWorksRecent RecentWS = null;
        private urc_WM_OutsourcedJobLinked OJLinked = null;
        private urc_WM_BillingContracts Billing = null;

        protected frm_WM_MHLWorks()
        {
            InitializeComponent();
            this.IsFixHeightScreen = false;
            this._workDA = new DataProcess<ST_WMS_LoadWorks_Result>();
            this._workDetailDA = new DataProcess<ST_WMS_LoadWorkDetails_Result>();
            this._listWorks = new BindingList<ST_WMS_LoadWorks_Result>();
            this._tableWorks = new DataTable();
            this._isFirstLoad = true;
            this._isAddNew = false;
            // instance.MHLWorkID = 0;

            InitJobFind();
            InitMonth();
            SetEvents();
            //LoadEmployeeList();
        }



        /// <summary>
        /// Get instance form
        /// </summary>
        public static frm_WM_MHLWorks Instance
        {
            get
            {
                return instance;
            }
        }

        public int MHLWorkID
        {
            get { return mhlWorkID; }
            set
            {
                mhlWorkID = value;
                LoadWorks();

            }
        }

        private void frm_WM_MHLWorks_Load(object sender, EventArgs e)
        {
            LoadWorks();
            this._isFirstLoad = false;
        }

        private void frm_WM_MHLWorks_Shown(object sender, EventArgs e)
        {
            if (this._isAddNew)
            {
                this.lkeCustomers.Focus();
                this.lkeCustomers.ShowPopup();
            }
        }

        private void SetEvents()
        {
            this.lkeOtherServices.EditValueChanged += LkeOtherServices_EditValueChanged;
            this.lkeCustomers.EditValueChanged += lkeCustomers_EditValueChanged;
            this.lkeCustomers.CloseUp += LkeCustomers_CloseUp;
            this.lkeJobs.EditValueChanged += lkeJobs_EditValueChanged;
            this.lkeJobs.CloseUp += LkeJobs_CloseUp;
            this.lkeMonth.EditValueChanged += lkeMonth_EditValueChanged;
            this.lkeCustomerFind.KeyDown += lkeCustomerFind_KeyDown;
            this.lkeCustomerFind.CloseUp += LkeCustomerFind_CloseUp;
            this.lkeWorkDefinitions.KeyDown += lkeWorkDefinitions_KeyDown;
            this.dtNavigatorWorks.PositionChanged += dtNavigatorWorks_PositionChanged;
            this.btnClose.Click += btnClose_Click;
            this.btnConfirm.CheckedChanged += btnConfirm_CheckedChanged;
            this.btnConfirm.Click += btnConfirm_Click;
            this.btnDeleteEmployee.Click += btnDeleteEmployee_Click;
            this.btnDeleteWork.Click += btnDeleteWork_Click;
            //this.btnEmployeeReview.Click += btnEmployeeReview_Click;
            this.btnEntry.Click += btnEntry_Click;
            this.btnNote.Click += btnNote_Click;
            //this.btnOpenWorkDefinition.Click += btnOpenWorkDefinition_Click;
            this.btnReject.CheckedChanged += btnReject_CheckedChanged;
            this.btnWorkDefinition.Click += btnWorkDefinition_Click;
            this.btnWorkExplain.Click += btnWorkExplain_Click;
            this.btnClear.Click += btnClear_Click;
            this.btnAddNew.Click += btnAddNew_Click;
            this.grvWorkDetail.CellValueChanged += grvWorkDetail_CellValueChanged;
            this.grvWorkDetail.RowCellClick += GrvWorkDetail_RowCellClick;
            this.tabControlDetails.SelectedPageChanged += tabControlDetails_SelectedPageChanged;
            this.KeyDown += frm_WM_MHLWorks_KeyDown;
            this.btnMultiNote.Click += btnMultiNote_Click;

            #region Update data events
            this.lkeJobs.LostFocus += DataChanged;
            this.lkeCustomers.LostFocus += DataChanged;
            this.lkeOtherServices.LostFocus += DataChanged;
            //this.txtDamaged.LostFocus += DataChanged;
            //this.txtReceived.LostFocus += DataChanged;
            this.txtUnitPrice.LostFocus += DataChanged;
            this.txtCreatedDate.LostFocus += DataChanged;
            this.mmeRemark.LostFocus += DataChanged;
            this.dtFromTime.LostFocus += DataChanged;
            this.dtToTime.LostFocus += DataChanged;
            this.txtOrderNumber.LostFocus += DataChanged;
            #endregion

            #region Data changed events
            this.txtCreated.TextChanged += txtCreated_TextChanged;
            this.txtCreatedDate.TextChanged += txtCreatedDate_TextChanged;
            //this.txtDamaged.TextChanged += txtDamaged_TextChanged;
            //this.txtReceived.TextChanged += txtReceived_TextChanged;
            this.txtUnitPrice.TextChanged += txtUnitPrice_TextChanged;
            this.dtFromTime.EditValueChanged += dtFromTime_EditValueChanged;
            this.dtFromTime.QueryCloseUp += dtFromTime_QueryCloseUp;
            this.dtToTime.EditValueChanged += dtToTime_EditValueChanged;
            this.dtToTime.QueryCloseUp += dtToTime_QueryCloseUp;
            this.txtCreatedDate.EditValueChanged += txtCreatedDate_EditValueChanged;
            this.mmeRemark.TextChanged += mmeRemark_TextChanged;
            this.txtOrderNumber.TextChanged += TxtOrderNumber_TextChanged;
            this.mmeRemark.Leave += MmeRemark_Leave;
            #endregion

            #region Filter Data
            this.chkAll.CheckedChanged += chkAll_CheckedChanged;
            this.chkMe.CheckedChanged += chkMe_CheckedChanged;
            this.chkMeZero.CheckedChanged += chkMeZero_CheckedChanged;
            this.chkJobs.CheckedChanged += chkJobs_CheckedChanged;
            this.chkRejected.CheckedChanged += chkRejected_CheckedChanged;
            this.chkWorkID.CheckedChanged += chkWorkID_CheckedChanged;
            this.chkEmployeeID.CheckedChanged += chkEmployeeID_CheckedChanged;
            this.chkNotConfirm.CheckedChanged += chkNotConfirm_CheckedChanged;
            this.chkCustomer.CheckedChanged += chkCustomer_CheckedChanged;
            #endregion

            this.txtWorkIDFind.KeyDown += txtWorkIDFind_KeyDown;
            this.txtEmployeeIDFind.KeyDown += txtEmployeeIDFind_KeyDown;
            this.FormClosing += frm_WM_MHLWorks_FormClosing;
            this.VisibleChanged += frm_WM_MHLWorks_VisibleChanged;
            this.Shown += frm_WM_MHLWorks_Shown;
            Common.Process.RefreshData.ReloadDataEvent += RefreshData_ReloadDataEvent;
        }

        private void TxtOrderNumber_TextChanged(object sender, EventArgs e)
        {
            if (this._selectedWork == null) return;
            this._selectedWork["OrderNumber"] = this.txtOrderNumber.Text;
        }

        private void LkeJobs_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            this.dtFromTime.Focus();
        }

        private void LkeCustomers_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            this.lkeCustomers.EditValue = e.Value;
            if (e.Value == null || Convert.IsDBNull(e.Value)) return;
            if (this._isAddNew && this.dtNavigatorWorks.Position == (this._tableWorks.Rows.Count - 1) && this.lkeCustomers.EditValue != null)
            {
                AddNewWork();
                if (!string.IsNullOrEmpty(this.orderNumberInput))
                {
                    this.txtOrderNumber.Text = this.orderNumberInput;
                }
            }
            this.lkeJobs.Focus();
            this.lkeJobs.ShowPopup();
        }

        public void AddNewTrip(string orderNumber, int customerID)
        {
            this.orderNumberInput = orderNumber;
            this.SetEditable(true);
            CreateNewWork();
            this.lkeCustomers.EditValue = customerID;
        }

        private void GrvWorkDetail_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.RowHandle < 0) return;
            int employeeID = Convert.ToInt32(this.grvWorkDetail.GetFocusedRowCellValue("EmployeeID"));
            var payRollDate = this.txtCreatedDate.DateTime.ToString("yyyy-MM-dd");

            // Get time work of this employee
            var payRollDetailDA = new DataProcess<PayRollDetails>();
            var timeWork = FileProcess.LoadTable("select top 1 TimeWork from PayRollDetails where employeeID=" + employeeID + " and PayrollDate='" + payRollDate + "'");
            if (timeWork != null && timeWork.Rows.Count > 0)
            {
                this.txtTimeWork.Text = Convert.ToString(timeWork.Rows[0]["TimeWork"]);
            }
            else
            {
                this.txtTimeWork.Text = string.Empty;
            }

            // Get employee info
            DataProcess<Employees> dataProcess = new DataProcess<Employees>();
            var currentEmployee = dataProcess.Select(em => em.EmployeeID == employeeID).FirstOrDefault();
            if (currentEmployee != null)
            {
                this.txtEmployeeName.Text = employeeID + "-" + currentEmployee.VietnamName;
            }
            else
            {
                this.txtEmployeeName.Text = string.Empty;
            }

            // Get work time list
            DataProcess<STEmployeeWorkingDetailOverTimes_Result> employeeWorkingDetailOvertimesDa = new DataProcess<STEmployeeWorkingDetailOverTimes_Result>();
            this.grdWEDetail.DataSource = employeeWorkingDetailOvertimesDa.Executing("STEmployeeWorkingDetailOverTimes @EmployeeID ={0}, @OrderDate={1}", employeeID, this.txtCreatedDate.DateTime.ToString("yyyy-MM-dd"));
            //this.grdWEDetail.DataSource = FileProcess.LoadTable("STEmployeeWorkingDetailOverTimes @EmployeeID =" + employeeID + ", @OrderDate ='" + this.txtCreatedDate.DateTime.ToString("yyyy-MM-dd") + "'");
        }

        void btnMultiNote_Click(object sender, EventArgs e)
        {
            bool isSupervisor = UserPermission.CheckSupervisorByDepartment(AppSetting.CurrentUser.LoginName, 4);
            if (!isSupervisor)
            {
                XtraMessageBox.Show("You are Supevisor to view this", "TPWMS",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(this.txtFromDate.Text)) return;
            int employeeID = Convert.ToInt32(txtEmployeeIDFind.EditValue);
            DateTime fromDate = DateTime.ParseExact(txtFromDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            DateTime toDate = DateTime.ParseExact(txtToDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            var dataSource = FileProcess.LoadTable("STMHLWorkByEmployeeNote @EmployeeID='" + employeeID + "', @FromDate='" + fromDate.ToString("yyyy-MM-dd") + "',@ToDate='" + toDate.ToString("yyyy-MM-dd") + "'");
            if (dataSource.Rows.Count > 0)
            {
                rptMHLWorkMultiNote rpt = new rptMHLWorkMultiNote();
                rpt.DataSource = dataSource;
                ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
                tool.ShowPreview();
            }
            else
            {
                MessageBox.Show("No data to print!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void LkeOtherServices_EditValueChanged(object sender, EventArgs e)
        {
            if (this.lkeOtherServices.EditValue == null) return;
            int otherServiceDetailID = Convert.ToInt32(this.lkeOtherServices.GetColumnValue("OtherServiceDetailID"));
            int mhlWorkID = Convert.ToInt32(this._selectedWork["MHLWorkID"]);
            DataProcess<MHLWorks> mhlWorkDA = new DataProcess<MHLWorks>();
            mhlWorkDA.ExecuteNoQuery("Update MHLWorks set OtherServiceDetailID=" + otherServiceDetailID + " where MHLWorkID=" + mhlWorkID);
            this._selectedWork["OtherServiceDetailID"] = otherServiceDetailID;

            this.txtServiceNumber.Text = string.Empty;
            if (mhlWorkID > 0)
            {
                var otherServiceDetail = FileProcess.LoadTable("ST_WMS_LoadOtherServiceDetailNumberByHMLWorkID @MHLWorksID=" + mhlWorkID);
                if (otherServiceDetail.Rows.Count > 0)
                {
                    this.txtServiceNumber.Text = Convert.ToString(otherServiceDetail.Rows[0]["OtherServiceDetailNumber"]);
                    this.txtServiceNumber.Tag = otherServiceDetailID;
                }
            }
        }

        private void LkeCustomerFind_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.Value == null) return;
            this.lkeCustomerFind.EditValue = e.Value;
            var keyEnter = new KeyEventArgs(Keys.Enter);
            this.lkeCustomerFind_KeyDown(sender, keyEnter);
        }

        void lkeWorkDefinitions_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.KeyCode.Equals(Keys.Enter)) return;
            this.txtWorkDefinitionName.Text = Convert.ToString(this.lkeWorkDefinitions.GetColumnValue("JobName"));
            this._tableWorks = FileProcess.LoadTable("SELECT MHLWorks.MHLWorkDate,MHLWorks.OrderNumber, MHLWorks.MHLWorkID, MHLWorks.PayRollMonthID, MHLWorks.CreatedBy, MHLWorks.Received," +
                " MHLWorks.Damaged, MHLWorks.MHLWorkConfirm, MHLWorks.Remark, MHLWorks.MHLWorkDefinitionID, MHLWorkDefinitions.JobName, MHLWorkDefinitions.Description," +
                " MHLWorks.UnitPrice, MHLWorkDefinitions.UpdatedBy, MHLWorkDefinitions.Unit, MHLWorkDefinitions.MHLWorkDefinitionNumber, MHLWorks.OtherServiceDetailID," +
                " OtherServiceDetails.OtherServiceID, MHLWorks.CustomerMainID, MHLWorks.FromTime, MHLWorks.ToTime, MHLWorks.Accepted, MHLWorks.AcceptedBy," +
                " MHLWorks.Rejected, MHLWorks.RejectedBy, MHLWorks.ManagerFeedback, MHLWorks.WorkNumber" +
                " FROM(MHLWorks LEFT JOIN MHLWorkDefinitions ON MHLWorks.MHLWorkDefinitionID = MHLWorkDefinitions.MHLWorkDefinitionID)" +
                " LEFT JOIN OtherServiceDetails ON MHLWorks.OtherServiceDetailID = OtherServiceDetails.OtherServiceDetailID WHERE(((MHLWorks.MHLWorkDefinitionID) = "
                + Convert.ToInt32(this.lkeWorkDefinitions.EditValue) + ")) AND MHLWorks.PayRollMonthID = " + Convert.ToInt32(this.lkeMonth.EditValue) +
                " ORDER BY MHLWorks.MHLWorkDate, MHLWorks.MHLWorkID");

            LoadFoundWorks(this._tableWorks);
        }

        /// <summary>
        /// Load all works has contains other serviceid is selected
        /// </summary>
        /// <param name="otherServiceID">int</param>
        public void LoadAllWorksByOtherServiceID(int otherServiceID)
        {
            this._tableWorks = FileProcess.LoadTable("SELECT MHLWorks.MHLWorkDate,MHLWorks.OrderNumber, MHLWorks.MHLWorkID, MHLWorks.PayRollMonthID, MHLWorks.CreatedBy, MHLWorks.Received," +
               " MHLWorks.Damaged, MHLWorks.MHLWorkConfirm, MHLWorks.Remark, MHLWorks.MHLWorkDefinitionID, MHLWorkDefinitions.JobName, MHLWorkDefinitions.Description," +
               " MHLWorks.UnitPrice, MHLWorkDefinitions.UpdatedBy, MHLWorkDefinitions.Unit, MHLWorkDefinitions.MHLWorkDefinitionNumber, MHLWorks.OtherServiceDetailID," +
               " OtherServiceDetails.OtherServiceID, MHLWorks.CustomerMainID, MHLWorks.FromTime, MHLWorks.ToTime, MHLWorks.Accepted, MHLWorks.AcceptedBy," +
               " MHLWorks.Rejected, MHLWorks.RejectedBy, MHLWorks.ManagerFeedback, MHLWorks.WorkNumber" +
               " FROM(MHLWorks LEFT JOIN MHLWorkDefinitions ON MHLWorks.MHLWorkDefinitionID = MHLWorkDefinitions.MHLWorkDefinitionID)" +
               " LEFT JOIN OtherServiceDetails ON MHLWorks.OtherServiceDetailID = OtherServiceDetails.OtherServiceDetailID " +
               " WHERE OtherServiceDetails.OtherServiceID =" + otherServiceID +
               " ORDER BY MHLWorks.MHLWorkDate, MHLWorks.MHLWorkID");

            LoadFoundWorks(this._tableWorks);
        }

        void lkeCustomerFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.KeyCode.Equals(Keys.Enter)) return;
            if (lkeCustomerFind.EditValue != null)
            {
                this.txtCustomerNameFind.Text = Convert.ToString(this.lkeCustomerFind.GetColumnValue("CustomerName"));

                if (this.lkeMonth.EditValue != null)
                {
                    this._tableWorks = FileProcess.LoadTable("SELECT MHLWorks.MHLWorkDate,MHLWorks.OrderNumber, MHLWorks.MHLWorkID, MHLWorks.PayRollMonthID, MHLWorks.CreatedBy, MHLWorks.Received," +
                        " MHLWorks.Damaged, MHLWorks.MHLWorkConfirm, MHLWorks.Remark, MHLWorks.MHLWorkDefinitionID, MHLWorkDefinitions.JobName, MHLWorkDefinitions.Description," +
                        " MHLWorks.UnitPrice, MHLWorkDefinitions.UpdatedBy, MHLWorkDefinitions.Unit, MHLWorkDefinitions.MHLWorkDefinitionNumber, MHLWorks.OtherServiceDetailID," +
                        " OtherServiceDetails.OtherServiceID, MHLWorks.CustomerMainID, MHLWorks.FromTime, MHLWorks.ToTime, MHLWorks.Accepted, MHLWorks.AcceptedBy," +
                        " MHLWorks.Rejected, MHLWorks.RejectedBy, MHLWorks.ManagerFeedback, MHLWorks.WorkNumber " +
                        " FROM(MHLWorks LEFT JOIN MHLWorkDefinitions ON MHLWorks.MHLWorkDefinitionID = MHLWorkDefinitions.MHLWorkDefinitionID) " +
                        " LEFT JOIN OtherServiceDetails ON MHLWorks.OtherServiceDetailID = OtherServiceDetails.OtherServiceDetailID WHERE MHLWorks.CustomerMainID = "
                        + Convert.ToInt32(this.lkeCustomerFind.EditValue) + " and MHLWorks.PayRollMonthID = " + Convert.ToInt32(this.lkeMonth.EditValue)
                        + " ORDER BY MHLWorks.MHLWorkDate, MHLWorks.MHLWorkID");
                }
                else
                {
                    this._tableWorks = FileProcess.LoadTable("SELECT MHLWorks.MHLWorkDate,MHLWorks.OrderNumber, MHLWorks.MHLWorkID, MHLWorks.PayRollMonthID, MHLWorks.CreatedBy, MHLWorks.Received," +
                        " MHLWorks.Damaged, MHLWorks.MHLWorkConfirm, MHLWorks.Remark, MHLWorks.MHLWorkDefinitionID, MHLWorkDefinitions.JobName, MHLWorkDefinitions.Description," +
                        " MHLWorks.UnitPrice, MHLWorkDefinitions.UpdatedBy, MHLWorkDefinitions.Unit, MHLWorkDefinitions.MHLWorkDefinitionNumber, MHLWorks.OtherServiceDetailID," +
                        " OtherServiceDetails.OtherServiceID, MHLWorks.CustomerMainID, MHLWorks.FromTime, MHLWorks.ToTime, MHLWorks.Accepted, MHLWorks.AcceptedBy," +
                        " MHLWorks.Rejected, MHLWorks.RejectedBy, MHLWorks.ManagerFeedback, MHLWorks.WorkNumber" +
                        " FROM(MHLWorks LEFT JOIN MHLWorkDefinitions ON MHLWorks.MHLWorkDefinitionID = MHLWorkDefinitions.MHLWorkDefinitionID)" +
                        " LEFT JOIN OtherServiceDetails ON MHLWorks.OtherServiceDetailID = OtherServiceDetails.OtherServiceDetailID WHERE MHLWorks.CustomerMainID = "
                        + Convert.ToInt32(this.lkeCustomerFind.EditValue) + " ORDER BY MHLWorks.MHLWorkDate, MHLWorks.MHLWorkID");
                }

                LoadFoundWorks(this._tableWorks);
            }
        }

        void btnConfirm_Click(object sender, EventArgs e)
        {
            this.IsConfirmClick = true;
            DataProcess<object> dataProcess = new DataProcess<object>();
            int workID = Convert.ToInt32(this._selectedWork["MHLWorkID"]);
            if (this.btnConfirm.Checked)
            {
                ////if user then return
                ////if AppSetting.CurrentUser.LevelOfAuthorization
                //bool isSupervisor = UserPermission.CheckSupervisorByDepartment(AppSetting.CurrentUser.LoginName, 4);
                //if (!isSupervisor)
                //{
                //    XtraMessageBox.Show("You are Supevisor to unconfirm this", "TPWMS",
                //    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}

                //Phan quyen Nhan su moi duoc nha confirm
                var levelDepartmentTb = FileProcess.LoadTable("SELECT count(UserRoleDefinitions.LevelDepartment) as LevelDepartment" +
                " FROM UserAccounts INNER JOIN" +
                             " UserApplications ON UserAccounts.LoginName = UserApplications.UserId INNER JOIN" +
                             " UserApplicationRoles ON UserApplications.UserApplicationId = UserApplicationRoles.UserApplicationId INNER JOIN" +
                             " UserRoleDefinitions ON UserApplicationRoles.RoleId = UserRoleDefinitions.RoleId" +
                             " WHERE UserDepartmentDefinitionID = 7 and UserAccounts.LoginName = '" + AppSetting.CurrentUser.LoginName + "'");


                int levelDepartment = Convert.ToInt32(levelDepartmentTb.Rows[0]["LevelDepartment"].ToString());
                if (levelDepartment == 0)
                {
                    MessageBox.Show("Permission denied!", "WMS_2017", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.IsConfirmClick = false;
                    return;
                }

                int result = dataProcess.ExecuteNoQuery("Update MHLWorks set MHLWorkConfirm=0 where MHLWorkID={0}", workID);
                this._tableWorks.Rows[this.dtNavigatorWorks.Position]["MHLWorkConfirm"] = 0;
                this.txtCreated.Text += ";Un.: " + AppSetting.CurrentUser.LoginName + " - " + DateTime.Now.ToString("dd/MM HH:mm");
                //int result = dataProcess.ExecuteNoQuery("Update MHLWorks set MHLWorkConfirm=0, CreatedBy={0} where MHLWorkID={1}", this.txtCreated.Text, workID);
            }
            else
            {
                this._tableWorks.Rows[this.dtNavigatorWorks.Position]["MHLWorkConfirm"] = 1;
                int result = dataProcess.ExecuteNoQuery("Update MHLWorks set MHLWorkConfirm=1 where MHLWorkID={0}", workID);
                this.txtCreated.Text += ";Con.: " + AppSetting.CurrentUser.LoginName + " - " + DateTime.Now.ToString("dd/MM HH:mm");
                //int result = dataProcess.ExecuteNoQuery("Update MHLWorks set MHLWorkConfirm=1, CreatedBy={0} where MHLWorkID={1}", this.txtCreated.Text, workID);
            }
        }

        void RefreshData_ReloadDataEvent(object sender, EventArgs e)
        {
            if (!sender.GetType().Name.Equals("ST_WMS_LoadWorkDetails_Result")) return;
            int workID = Convert.ToInt32(this._selectedWork["MHLWorkID"]);
            this.LoadWorkDetails(workID);
        }

        void frm_WM_MHLWorks_VisibleChanged(object sender, EventArgs e)
        {
            if (!this._isFirstLoad && this.Visible)
            {
                this.LoadWorks();
                mhlWorkID = 0;
            }
        }

        void frm_WM_MHLWorks_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void txtCreatedDate_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void MmeRemark_Leave(object sender, EventArgs e)
        {
            this.btnEntry.Focus();
        }

        private void dtToTime_QueryCloseUp(object sender, CancelEventArgs e)
        {
            this.mmeRemark.Focus();
        }

        private void dtFromTime_QueryCloseUp(object sender, CancelEventArgs e)
        {
            this.dtToTime.Focus();
        }

        private void frm_WM_MHLWorks_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.PageUp:
                    {
                        this.dtNavigatorWorks.Buttons.DoClick(this.dtNavigatorWorks.Buttons.Prev);
                        break;
                    }
                case Keys.PageDown:
                    {
                        this.dtNavigatorWorks.Buttons.DoClick(this.dtNavigatorWorks.Buttons.Next);
                        break;
                    }
            }
        }

        private void SetEditable(bool isEditable)
        {
            this.btnReject.Enabled = isEditable;
            this.btnDeleteWork.Enabled = isEditable;
            this.btnDeleteEmployee.Enabled = isEditable;
            this.btnEntry.Enabled = isEditable;
            //this.txtReceived.ReadOnly = !isEditable;
            this.txtUnitPrice.ReadOnly = !isEditable;
            //this.txtDamaged.ReadOnly = !isEditable;
            this.dtFromTime.ReadOnly = !isEditable;
            this.dtToTime.ReadOnly = !isEditable;
            this.txtCreatedDate.ReadOnly = !isEditable;
            this.lkeCustomers.ReadOnly = !isEditable;
            this.lkeJobs.ReadOnly = !isEditable;
            this.mmeRemark.ReadOnly = !isEditable;
            this.txtOrderNumber.ReadOnly = !isEditable;
            this.lkeOtherServices.ReadOnly = !isEditable;
            if (isEditable)
            {
                this.labelControlConfirmedStrip.BackColor = Color.FromArgb(27, 73, 165);
            }
            else
            {
                this.labelControlConfirmedStrip.BackColor = Color.Red;
            }
        }

        #region Load Data
        private void LoadWorks()
        {
            try
            {
                // Load customer
                this.InitCustomers();
                if (MHLWorkID > 0)
                {
                    this._tableWorks = FileProcess.LoadTable("SELECT MHLWorks.MHLWorkDate,MHLWorks.OrderNumber, MHLWorks.MHLWorkID, MHLWorks.PayRollMonthID, MHLWorks.CreatedBy, " +
                " MHLWorks.Received, MHLWorks.Damaged, MHLWorks.MHLWorkConfirm, MHLWorks.Remark, MHLWorks.MHLWorkDefinitionID, MHLWorkDefinitions.JobName, " +
                " MHLWorkDefinitions.Description, MHLWorks.UnitPrice, MHLWorkDefinitions.UpdatedBy, MHLWorkDefinitions.Unit, MHLWorkDefinitions.MHLWorkDefinitionNumber, " +
                " MHLWorks.OtherServiceDetailID, OtherServiceDetails.OtherServiceID, MHLWorks.CustomerMainID, MHLWorks.FromTime, MHLWorks.ToTime, MHLWorks.Accepted, " +
                " MHLWorks.AcceptedBy, MHLWorks.Rejected, MHLWorks.RejectedBy, MHLWorks.ManagerFeedback, MHLWorks.WorkNumber, Customers.CustomerName " +
                " FROM((MHLWorks LEFT JOIN MHLWorkDefinitions ON MHLWorks.MHLWorkDefinitionID = MHLWorkDefinitions.MHLWorkDefinitionID) " +
                " LEFT JOIN OtherServiceDetails ON MHLWorks.OtherServiceDetailID = OtherServiceDetails.OtherServiceDetailID) " +
                " INNER JOIN Customers ON MHLWorks.CustomerMainID = Customers.CustomerID Where " +
                " Customers.StoreID = " + AppSetting.StoreID + " AND MHLWorks.MHLWorkID=" + MHLWorkID + "  ORDER BY MHLWorks.MHLWorkDate, MHLWorks.MHLWorkID;");
                }
                else
                {
                    this._tableWorks = FileProcess.LoadTable("SELECT MHLWorks.MHLWorkDate,MHLWorks.OrderNumber, MHLWorks.MHLWorkID, MHLWorks.PayRollMonthID, MHLWorks.CreatedBy, " +
               " MHLWorks.Received, MHLWorks.Damaged, MHLWorks.MHLWorkConfirm, MHLWorks.Remark, MHLWorks.MHLWorkDefinitionID, MHLWorkDefinitions.JobName, " +
               " MHLWorkDefinitions.Description, MHLWorks.UnitPrice, MHLWorkDefinitions.UpdatedBy, MHLWorkDefinitions.Unit, MHLWorkDefinitions.MHLWorkDefinitionNumber, " +
               " MHLWorks.OtherServiceDetailID, OtherServiceDetails.OtherServiceID, MHLWorks.CustomerMainID, MHLWorks.FromTime, MHLWorks.ToTime, MHLWorks.Accepted, " +
               " MHLWorks.AcceptedBy, MHLWorks.Rejected, MHLWorks.RejectedBy, MHLWorks.ManagerFeedback, MHLWorks.WorkNumber, Customers.CustomerName " +
               " FROM((MHLWorks LEFT JOIN MHLWorkDefinitions ON MHLWorks.MHLWorkDefinitionID = MHLWorkDefinitions.MHLWorkDefinitionID) " +
               " LEFT JOIN OtherServiceDetails ON MHLWorks.OtherServiceDetailID = OtherServiceDetails.OtherServiceDetailID) " +
               " INNER JOIN Customers ON MHLWorks.CustomerMainID = Customers.CustomerID Where MHLWorks.MHLWorkDate >= DATEADD(DAY, -30, GETDATE())" +
               " AND Customers.StoreID = " + AppSetting.StoreID + " ORDER BY MHLWorks.MHLWorkDate, MHLWorks.MHLWorkID;");
                }


                if (this._tableWorks.Rows.Count <= 0)
                {
                    CreateNewWork();
                }
                else
                {
                    this.dtNavigatorWorks.DataSource = this._tableWorks;
                    this.dtNavigatorWorks.Position = this._tableWorks.Rows.Count - 1;
                    this._selectedWork = this._tableWorks.NewRow();
                    this._selectedWork = this._tableWorks.Rows[this.dtNavigatorWorks.Position];
                    int mhlWorkID = Convert.ToInt32(this._selectedWork["MHLWorkID"]);
                    InitJobs(Convert.ToInt32(this._selectedWork["CustomerMainID"]));
                    BindData();

                    LoadWorkDetails(mhlWorkID);
                }
                // MHLWorkID = 0;
            }
            catch (Exception ex)
            {
                //throw ex;
            }
        }
        private void LoadWorksByID(int id)
        {
            try
            {
                // Load customer
                this.InitCustomers();

                this._tableWorks = FileProcess.LoadTable("SELECT MHLWorks.MHLWorkDate,MHLWorks.OrderNumber, MHLWorks.MHLWorkID, MHLWorks.PayRollMonthID, MHLWorks.CreatedBy, " +
                " MHLWorks.Received, MHLWorks.Damaged, MHLWorks.MHLWorkConfirm, MHLWorks.Remark, MHLWorks.MHLWorkDefinitionID, MHLWorkDefinitions.JobName, " +
                " MHLWorkDefinitions.Description, MHLWorks.UnitPrice, MHLWorkDefinitions.UpdatedBy, MHLWorkDefinitions.Unit, MHLWorkDefinitions.MHLWorkDefinitionNumber, " +
                " MHLWorks.OtherServiceDetailID, OtherServiceDetails.OtherServiceID, MHLWorks.CustomerMainID, MHLWorks.FromTime, MHLWorks.ToTime, MHLWorks.Accepted, " +
                " MHLWorks.AcceptedBy, MHLWorks.Rejected, MHLWorks.RejectedBy, MHLWorks.ManagerFeedback, MHLWorks.WorkNumber, Customers.CustomerName " +
                " FROM((MHLWorks LEFT JOIN MHLWorkDefinitions ON MHLWorks.MHLWorkDefinitionID = MHLWorkDefinitions.MHLWorkDefinitionID) " +
                " LEFT JOIN OtherServiceDetails ON MHLWorks.OtherServiceDetailID = OtherServiceDetails.OtherServiceDetailID) " +
                " INNER JOIN Customers ON MHLWorks.CustomerMainID = Customers.CustomerID Where MHLWorks.MHLWorkDate >= DATEADD(DAY, -30, GETDATE())" +
                " AND Customers.StoreID = " + AppSetting.StoreID + " AND MHLWorks.MHLWorkID=" + id + "  ORDER BY MHLWorks.MHLWorkDate, MHLWorks.MHLWorkID;");

                if (this._tableWorks.Rows.Count <= 0)
                {
                    CreateNewWork();
                }
                else
                {
                    this.dtNavigatorWorks.DataSource = this._tableWorks;
                    this.dtNavigatorWorks.Position = this._tableWorks.Rows.Count - 1;
                    this._selectedWork = this._tableWorks.NewRow();
                    this._selectedWork = this._tableWorks.Rows[this.dtNavigatorWorks.Position];
                    int mhlWorkID = Convert.ToInt32(this._selectedWork["MHLWorkID"]);
                    InitJobs(Convert.ToInt32(this._selectedWork["CustomerMainID"]));
                    BindData();

                    LoadWorkDetails(mhlWorkID);
                }
            }
            catch (Exception ex)
            {
                //throw ex;
            }
        }
        private void LoadEmployeeList()
        {
            this.lke_rpi_EmployeeList.DataSource = AppSetting.EmployessList;
            this.lke_rpi_EmployeeList.ValueMember = "EmployeeID";
            this.lke_rpi_EmployeeList.DisplayMember = "VietnamName";
        }
        private void LoadFoundWorks(DataTable source)
        {
            if (source == null || source.Rows.Count <= 0)
            {
                XtraMessageBox.Show("No records found !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadWorks();
                this.chkAll.Checked = true;
                this.lkeCustomerFind.EditValue = null;
                this.txtCustomerNameFind.Text = string.Empty;
            }
            else
            {
                this.dtNavigatorWorks.DataSource = source;
                this.dtNavigatorWorks.Position = source.Rows.Count;
                this._selectedWork = source.NewRow();
                this._selectedWork = source.Rows[this._tableWorks.Rows.Count - 1];
                int mhlWorkID = Convert.ToInt32(this._selectedWork["MHLWorkID"]);

                int customerMainID = 0;
                Int32.TryParse(this._selectedWork["CustomerMainID"].ToString(), out customerMainID);
                InitJobs(customerMainID);
                BindData();

                LoadWorkDetails(mhlWorkID);
            }
        }

        private void LoadWorkDetails(int mHLWorkID)
        {
            // Clear WE data
            this.txtTimeWork.Text = string.Empty;
            this.txtEmployeeName.Text = string.Empty;
            this.grdWEDetail.DataSource = null;

            // Set data detail
            this.grdWorkDetail.DataSource = this._workDetailDA.Executing("ST_WMS_LoadWorkDetails @WorkID = {0}", mHLWorkID);

            // Init entry list
            this.listEmployeeEntry = new BindingList<EmployeeMHLEntry>();
            this.listEmployeeEntry.Add(new EmployeeMHLEntry());
            this.grcDataEntry.DataSource = this.listEmployeeEntry;
        }

        private void InitCustomers()
        {
            DataProcess<STcomboCustomerMainID_Result> customerMainDA = new DataProcess<STcomboCustomerMainID_Result>();
            List<STcomboCustomerMainID_Result> listData = customerMainDA.Executing("STcomboCustomerMainID @varStoreID={0}", AppSetting.StoreID).ToList();

            this.lkeCustomers.Properties.DataSource = listData;
            this.lkeCustomers.Properties.ValueMember = "CustomerMainID";
            this.lkeCustomers.Properties.DisplayMember = "CustomerNumber";

            this.lkeCustomerFind.Properties.DataSource = AppSetting.CustomerList;
            this.lkeCustomerFind.Properties.ValueMember = "CustomerMainID";
            this.lkeCustomerFind.Properties.DisplayMember = "CustomerNumber";
        }

        private void InitJobs(int customerMainID)
        {
            var dataSource = FileProcess.LoadTable("STWorkDefinitionByCustomer @CustomerID = " + customerMainID);
            this.lkeJobs.Properties.DataSource = dataSource;
            this.lkeJobs.Properties.ValueMember = "MHLWorkDefinitionID";
            this.lkeJobs.Properties.DisplayMember = "MHLWorkDefinitionNumber";

            int rows = dataSource.Rows.Count;

            if (rows < 20)
            {
                this.lkeJobs.Properties.DropDownRows = rows;
            }
            else
            {
                this.lkeJobs.Properties.DropDownRows = 20;
            }
        }

        private void InitJobFind()
        {
            DataProcess<MHLWorkDefinitions> workDA = new DataProcess<MHLWorkDefinitions>();

            this.lkeWorkDefinitions.Properties.DataSource = workDA.Select(m => m.Discontinued != true);
            this.lkeWorkDefinitions.Properties.ValueMember = "MHLWorkDefinitionID";
            this.lkeWorkDefinitions.Properties.DisplayMember = "MHLWorkDefinitionNumber";
        }

        private void InitMonth()
        {
            this.lkeMonth.Properties.DataSource = FileProcess.LoadTable("SELECT TOP 50 PayrollMonth.PayRollMonthID, PayrollMonth.PayRollMonth, PayrollMonth.FromDate," +
                " PayrollMonth.ToDate FROM PayrollMonth WHERE(((PayrollMonth.PayRollMonthID) > 74)) ORDER BY PayrollMonth.PayRollMonthID DESC; ");
            this.lkeMonth.Properties.ValueMember = "PayRollMonthID";
            this.lkeMonth.Properties.DisplayMember = "PayRollMonth";
        }

        private void BindData()
        {
            if (this._isFirstLoad)
            {
                this.txtCustomerName.Text = Convert.ToString(this._selectedWork["CustomerName"]);
                this.txtJobName.Text = Convert.ToString(this._selectedWork["JobName"]);
            }

            this.txtWorkID.Text = Convert.ToString(this._selectedWork["WorkNumber"]);
            this.txtCreatedDate.EditValue = !Convert.IsDBNull(this._selectedWork["MHLWorkDate"]) ? Convert.ToDateTime(this._selectedWork["MHLWorkDate"]) : (DateTime?)null;
            this.txtCreated.Text = Convert.ToString(this._selectedWork["CreatedBy"]);
            this.txtUnitPrice.Text = !Convert.IsDBNull(this._selectedWork["UnitPrice"]) ? Convert.ToString(this._selectedWork["UnitPrice"]) : String.Empty;
            this.txtUnit.Text = Convert.ToString(this._selectedWork["Unit"]);
            this.mmeRemark.Text = Convert.ToString(this._selectedWork["Remark"]);
            this.txtOrderNumber.Text = Convert.ToString(this._selectedWork["OrderNumber"]);
            this.dtFromTime.EditValue = !Convert.IsDBNull(this._selectedWork["FromTime"]) ? Convert.ToDateTime(this._selectedWork["FromTime"]) : (DateTime?)null;
            this.dtToTime.EditValue = !Convert.IsDBNull(this._selectedWork["ToTime"]) ? Convert.ToDateTime(this._selectedWork["ToTime"]) : (DateTime?)null;
            this.lkeCustomers.EditValue = this._selectedWork["CustomerMainID"];
            this.lkeJobs.EditValue = Convert.ToInt32(this._selectedWork["MHLWorkDefinitionID"]);
            this.LoadOtherService();
            this.txtServiceNumber.Tag = !Convert.IsDBNull(this._selectedWork["OtherServiceDetailID"]) ? Convert.ToInt32(this._selectedWork["OtherServiceDetailID"]) : (int?)null;
            this.btnConfirm.Checked = Convert.ToBoolean(this._selectedWork["MHLWorkConfirm"]);
            this.btnReject.Checked = Convert.ToBoolean(this._selectedWork["Rejected"]);

            // Load service number
            int mhlWorkID = Convert.ToInt32(this._selectedWork["MHLWorkID"]);
            this.txtServiceNumber.Text = string.Empty;
            if (mhlWorkID > 0)
            {
                var otherServiceDetail = FileProcess.LoadTable("ST_WMS_LoadOtherServiceDetailNumberByHMLWorkID @MHLWorksID=" + mhlWorkID);
                if (otherServiceDetail.Rows.Count > 0)
                {
                    this.txtServiceNumber.Text = Convert.ToString(otherServiceDetail.Rows[0]["OtherServiceDetailNumber"]);
                }
            }

            if (this.btnConfirm.Checked)
            {
                this.SetEditable(false);
            }
            else
            {
                this.SetEditable(true);
            }
        }
        #endregion

        #region Events
        #region LookupEdit
        private void lkeWorkDefinitions_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void lkeMonth_EditValueChanged(object sender, EventArgs e)
        {
            if (lkeMonth.EditValue == null) return;
            this.txtFromDate.Text = Convert.ToDateTime(this.lkeMonth.GetColumnValue("FromDate")).ToString("dd/MM/yyyy");
            this.txtToDate.Text = Convert.ToDateTime(this.lkeMonth.GetColumnValue("ToDate")).ToString("dd/MM/yyyy");

            this._tableWorks = FileProcess.LoadTable(" SELECT MHLWorks.MHLWorkID, MHLWorks.WorkNumber, MHLWorks.PayRollMonthID, MHLWorks.MHLWorkDate,MHLWorks.OrderNumber, MHLWorks.CreatedBy," +
                         " MHLWorks.FromTime, MHLWorks.ToTime, MHLWorks.Accepted, MHLWorks.AcceptedBy, MHLWorks.Rejected, MHLWorks.RejectedBy, MHLWorks.ManagerFeedback, " +
                         " MHLWorks.Received, MHLWorks.Damaged, MHLWorks.MHLWorkConfirm, MHLWorks.Remark, MHLWorks.MHLWorkDefinitionID, MHLWorkDefinitions.MHLWorkDefinitionNumber, " +
                         " MHLWorkDefinitions.JobName, MHLWorkDefinitions.Description, MHLWorks.UnitPrice, MHLWorkDefinitions.UpdatedBy, MHLWorkDefinitions.Unit," +
                         " MHLWorks.CustomerMainID, MHLWorks.OtherServiceDetailID " +
                         " FROM MHLWorks LEFT JOIN MHLWorkDefinitions ON MHLWorks.MHLWorkDefinitionID = MHLWorkDefinitions.MHLWorkDefinitionID " +
                         " WHERE MHLWorks.PayRollMonthID =" + (int)lkeMonth.EditValue +
                         " ORDER BY MHLWorks.MHLWorkID ");
            LoadFoundWorks(this._tableWorks);
        }

        private void lkeJobs_EditValueChanged(object sender, EventArgs e)
        {
            if (this.lkeJobs.EditValue != null)
            {
                this.txtJobName.Text = Convert.ToString(this.lkeJobs.GetColumnValue("JobName"));
                this.txtUnit.Text = Convert.ToString(this.lkeJobs.GetColumnValue("Unit"));
                this.txtUnitPrice.Text = Convert.ToString(this.lkeJobs.GetColumnValue("UnitPrice"));
                this._selectedWork["MHLWorkDefinitionID"] = Convert.ToInt32(this.lkeJobs.EditValue);
            }
        }

        private void lkeCustomers_EditValueChanged(object sender, EventArgs e)
        {
            if (lkeCustomers.EditValue != null && !string.IsNullOrEmpty(lkeCustomers.Text))
            {
                this.txtCustomerName.Text = Convert.ToString(this.lkeCustomers.GetColumnValue("CustomerName"));
                this._selectedWork["CustomerMainID"] = Convert.ToInt32(this.lkeCustomers.EditValue);
                InitJobs(Convert.ToInt32(this.lkeCustomers.EditValue));
            }
        }

        private void lkeCustomerFind_EditValueChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region Buttons
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            this.SetEditable(true);
            CreateNewWork();

            this.lkeCustomers.Focus();
            this.lkeCustomers.ShowPopup();
        }

        private void btnWorkExplain_Click(object sender, EventArgs e)
        {
            DataProcess<STOtherService_Work_Explanation_Result> otherServiceDA = new DataProcess<STOtherService_Work_Explanation_Result>();
            List<STOtherService_Work_Explanation_Result> listOtherServices = new List<STOtherService_Work_Explanation_Result>();

            if (String.IsNullOrEmpty(this.txtFromDate.Text))
            {
                this.lkeMonth.Focus();
                this.lkeMonth.ShowPopup();
            }
            else
            {
                if (this.lkeCustomerFind.EditValue == null)
                {
                    if (this.chkJobs.Checked)
                    {
                        if (lkeWorkDefinitions.EditValue == null)
                        {
                            this.lkeWorkDefinitions.Focus();
                            this.lkeWorkDefinitions.ShowPopup();
                        }
                        else
                        {
                            listOtherServices = otherServiceDA.Executing("STOtherService_Work_Explanation @FromDate = {0}, @ToDate = {1}, @MHLWorkDefinitionID = {2}",
                                Convert.ToDateTime(this.txtFromDate.Text), Convert.ToDateTime(this.txtToDate.Text), Convert.ToInt32(this.lkeWorkDefinitions.EditValue)).ToList();
                        }
                    }
                    else
                    {
                        listOtherServices = otherServiceDA.Executing("STOtherService_Work_Explanation @FromDate = {0}, @ToDate = {1}", Convert.ToDateTime(this.txtFromDate.Text),
                            Convert.ToDateTime(this.txtToDate.Text)).ToList();
                    }
                }
                else
                {
                    listOtherServices = otherServiceDA.Executing("STOtherService_Work_Explanation @FromDate = {0}, @ToDate = {1}, @CustomerMainID = {2}",
                        Convert.ToDateTime(this.txtFromDate.Text), Convert.ToDateTime(this.txtToDate.Text), Convert.ToInt32(this.lkeCustomerFind.EditValue)).ToList();
                }

                rptWorkExplanationReport rpt = new rptWorkExplanationReport(Convert.ToString(this.lkeMonth.EditValue), this.txtFromDate.Text, this.txtToDate.Text);
                rpt.DataSource = listOtherServices;
                ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
                tool.ShowPreview();
            }
        }

        private void btnWorkDefinition_Click(object sender, EventArgs e)
        {
            if (this.frmWorkDifinitionList == null)
            {
                this.frmWorkDifinitionList = new frm_WM_MHLWorkDefinitionList();
            }
            this.frmWorkDifinitionList.ShowDialog();
        }

        private void btnReject_CheckedChanged(object sender, EventArgs e)
        {
            if (!this._isAddNew)
            {
                this._selectedWork["Rejected"] = this.btnReject.Checked;
                UpdateMHLWork();
            }
        }

        private void btnNote_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtWorkID.Text))
            {
                return;
            }
            else
            {
                DataProcess<STMHLWorkNote_Result> noteDA = new DataProcess<STMHLWorkNote_Result>();

                rptMHLWorkNote rpt = new rptMHLWorkNote();
                rpt.DataSource = noteDA.Executing("STMHLWorkNote @MHLWorkID = {0}", Convert.ToInt32(this._selectedWork["MHLWorkID"]));
                ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
                tool.ShowPreview();
            }
        }

        private void btnEntry_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtWorkID.Text))
            {
                return;
            }

            if (this.lkeCustomers.EditValue == null)
            {
                return;
            }

            int workID = Convert.ToInt32(this._selectedWork["MHLWorkID"]);
            if (this.frmEntry == null)
            {
                this.frmEntry = new frm_WM_Dialog_MHLWorkEmployeeAddNew(workID);

            }
            else
            {
                this.frmEntry.WorkID = workID;
            }

            if (!this.frmEntry.Enabled) return;
            this.frmEntry.ShowDialog();

            // Detected current job state
            switch (this.currentJobState)
            {
                case OutsourceJobEnum.All:
                    this.chkAll.Checked = true;
                    break;
                case OutsourceJobEnum.Me:
                    this.chkMe.Checked = true;
                    break;
                case OutsourceJobEnum.Me_0:
                    this.chkMeZero.Checked = true;
                    break;
                case OutsourceJobEnum.All_Not_Confirm:
                    this.chkNotConfirm.Checked = true;
                    break;
                case OutsourceJobEnum.Reject:
                    this.chkRejected.Checked = true;
                    break;
                default:
                    this.chkAll.Checked = true;
                    break;
            }
        }

        //private void btnEmployeeReview_Click(object sender, EventArgs e)
        //{
        //    int payRollMonthID = 0;
        //    try
        //    {
        //        // Handle event click Employee Review Button
        //        payRollMonthID = Convert.ToInt32(this._selectedWork["PayRollMonthID"]);
        //    }
        //    catch (Exception)
        //    {
        //        payRollMonthID = 0;
        //    }

        //    if (this.frmWorkEmplyeeSummary == null)
        //    {
        //        this.frmWorkEmplyeeSummary = new frm_WM_MHLWorkEmployeeSummary(payRollMonthID);
        //    }
        //    else
        //    {
        //        this.frmWorkEmplyeeSummary.initData(payRollMonthID);
        //    }

        //    this.frmWorkEmplyeeSummary.Show();
        //}

        private void btnDeleteWork_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this._selectedWork["MHLWorkID"]) <= 0)
            {
                return;
            }

            if (this.btnConfirm.Checked)
            {
                return;
            }

            if (grvWorkDetail.RowCount > 0)
            {
                XtraMessageBox.Show("You must delete all items before delete this " + Convert.ToString(this._selectedWork["WorkNumber"]) + " !", "TPWMS",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (XtraMessageBox.Show("Are you sure to delete order ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataProcess<object> storeDA = new DataProcess<object>();

                var mhlWorkID = Convert.ToInt32(this._selectedWork["MHLWorkID"]);
                int result = storeDA.ExecuteNoQuery("STMHLWorkDetailExecute @MHLWorkID = {0}, @Flag = {1}", mhlWorkID, 2);
                if(result>0)
                {
                    var rowIndex = this._tableWorks.Select("MHLWorkID=" + mhlWorkID).FirstOrDefault();
                    this._tableWorks.Rows.Remove(rowIndex);
                    this.dtNavigatorWorks.DataSource = this._tableWorks;
                    this.dtNavigatorWorks.Position = this._tableWorks.Rows.Count - 1;
                    this.chkAll.Checked = true;
                }
                
            }
        }

        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtWorkID.Text))
            {
                return;
            }

            if (XtraMessageBox.Show("Are you sure to delete ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataProcess<object> storeDA = new DataProcess<object>();

                int result = storeDA.ExecuteNoQuery("STMHLWorkDetailExecute @MHLWorkID = {0}, @Flag = {1}, @EmployeeID = {2}, @Quantity = {3}, @CreatedBy = {4}",
                    Convert.ToInt32(this._selectedWork["MHLWorkID"]), 0, null, null, AppSetting.CurrentUser.LoginName);
                int mhlWorkID = Convert.ToInt32(this._selectedWork["MHLWorkID"]);
                LoadWorkDetails(mhlWorkID);
            }
        }

        private void btnConfirm_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.IsConfirmClick) return;
            if (!this._isAddNew)
            {
                DataProcess<PayrollMonth> monthDA = new DataProcess<PayrollMonth>();
                int payRollMonthID = 0;
                Int32.TryParse(Convert.ToString(this._selectedWork["PayRollMonthID"]), out payRollMonthID);
                PayrollMonth payroll = monthDA.Select(m => m.PayrollMonthConfirm == true && m.PayRollMonthID == payRollMonthID).FirstOrDefault();

                if (this.btnConfirm.Checked)
                {
                    if (payroll != null)
                    {
                        XtraMessageBox.Show("Can not confirm because this month was confirmed !", "WMS=2017", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        if (this.lkeCustomers.EditValue == null)
                        {
                            XtraMessageBox.Show("Please select Customer !", "WMS=2017", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        {
                            if (this.grvWorkDetail.RowCount <= 0 && Convert.ToBoolean(this._selectedWork["MHLWorkConfirm"]) == false)
                            {
                                XtraMessageBox.Show("Please input the employees before confirm the Job !", "WMS=2017", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            else
                            {
                                if (this.lkeOtherServices.EditValue == null)
                                {
                                    this.lkeOtherServices.Focus();
                                    this.lkeOtherServices.ShowPopup();
                                    return;
                                }

                                if (!IsAllowConfirm())
                                {
                                    int mhlWorkID = Convert.ToInt32(this._selectedWork["MHLWorkID"]);
                                    if (this.frmOtherJobTheSameTime == null)
                                    {
                                        this.frmOtherJobTheSameTime = new frm_WM_OtherJobTheSameTime(mhlWorkID);
                                    }
                                    else
                                    {
                                        this.frmOtherJobTheSameTime.InitData(mhlWorkID);
                                    }
                                    if (!this.frmOtherJobTheSameTime.Enabled) return;
                                    this.frmOtherJobTheSameTime.ShowDialog();
                                    return;
                                }
                                else
                                {
                                    this._selectedWork["MHLWorkConfirm"] = this.btnConfirm.Checked;
                                    SetEditable(false);
                                }
                            }
                        }
                    }
                }
                else
                {
                    this._selectedWork["MHLWorkConfirm"] = this.btnConfirm.Checked;
                    SetEditable(true);
                }

                UpdateMHLWork();
                this.IsConfirmClick = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOpenWorkDefinition_Click(object sender, EventArgs e)
        {
            if (this.lkeJobs.EditValue == null) return;
            int workDefinitionID = Convert.ToInt32(this.lkeJobs.EditValue);
            if (this.frmWorkDefinition == null)
            {
                this.frmWorkDefinition = new frm_WM_MHLWorkDefinitions(workDefinitionID);
            }
            else
            {
                this.frmWorkDefinition.initData(workDefinitionID);
            }
            if (!this.frmWorkDefinition.Enabled) return;
            this.frmWorkDefinition.ShowDialog();
        }

        private void LoadOtherService()
        {
            if (this.lkeCustomers.EditValue == null || string.IsNullOrEmpty(this.lkeCustomers.Text)) return;
            DataProcess<STOtherService_Work_Mapping_Result> otherServiceDA = new DataProcess<STOtherService_Work_Mapping_Result>();
            listOtherService = new List<STOtherService_Work_Mapping_Result>();
            int customerMainID = Convert.ToInt32(this.lkeCustomers.EditValue);
            if (customerMainID > 0)
            {
                listOtherService = otherServiceDA.Executing("STOtherService_Work_Mapping @MHLWorkDefinitionID = {0}, @CustomerMainID = {1}", null, customerMainID).ToList();
            }
            else
            {
                listOtherService = otherServiceDA.Executing("STOtherService_Work_Mapping").ToList();
            }

            this.lkeOtherServices.Properties.DataSource = listOtherService;//.OrderByDescending(s => s.ServiceDate)
            this.lkeOtherServices.Properties.ValueMember = "OtherServiceDetailID";
            this.lkeOtherServices.Properties.DisplayMember = "OtherServiceDetailID";

            if (listOtherService.Count >= 20)
            {
                this.lkeOtherServices.Properties.DropDownRows = 20;
            }
            else
            {
                this.lkeOtherServices.Properties.DropDownRows = listOtherService.Count;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
        }
        #endregion

        #region Data changed
        private void txtUnitPrice_TextChanged(object sender, EventArgs e)
        {
            if (this._selectedWork == null) return;
            this._selectedWork["UnitPrice"] = String.IsNullOrEmpty(this.txtUnitPrice.Text) ? 0 : (float)Convert.ToDecimal(this.txtUnitPrice.Text);
        }

        private void txtReceived_TextChanged(object sender, EventArgs e)
        {
            //this._selectedWork["Received"] = String.IsNullOrEmpty(this.txtReceived.Text) ? 0 : int.Parse(this.txtDamaged.Text, NumberStyles.AllowThousands);
        }

        private void txtDamaged_TextChanged(object sender, EventArgs e)
        {
            //this._selectedWork["Damaged"] = String.IsNullOrEmpty(this.txtDamaged.Text) ? 0 : int.Parse(this.txtDamaged.Text, NumberStyles.AllowThousands);
        }

        private void mmeRemark_TextChanged(object sender, EventArgs e)
        {
            this._selectedWork["Remark"] = this.mmeRemark.Text;
        }

        private void dtToTime_EditValueChanged(object sender, EventArgs e)
        {
            this._selectedWork["ToTime"] = this.dtToTime.DateTime;
        }

        private void dtFromTime_EditValueChanged(object sender, EventArgs e)
        {
            this._selectedWork["FromTime"] = this.dtFromTime.DateTime;
            this.txtCreatedDate.DateTime = this.dtFromTime.DateTime;
        }

        private void txtCreatedDate_TextChanged(object sender, EventArgs e)
        {
            //this._selectedWork["MHLWorkDate"] = this.txtCreatedDate.DateTime;
        }

        private void txtCreated_TextChanged(object sender, EventArgs e)
        {
            //this._selectedWork["CreatedBy"] = this.txtCreated.Text;
        }

        private void DataChanged(object sender, EventArgs e)
        {
            if (!this._isAddNew)
            {
                UpdateMHLWork();
            }
        }
        #endregion

        #region Filter Data
        private void chkCustomer_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkCustomer.Checked)
            {
                FilterEvent(Convert.ToInt32(chkCustomer.Tag));
                this.lkeCustomerFind.ReadOnly = false;
                this.lkeCustomerFind.Focus();
                this.lkeCustomerFind.ShowPopup();
            }
            else
            {
                this.lkeCustomerFind.ReadOnly = true;
            }
        }

        private void chkNotConfirm_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkNotConfirm.Checked)
            {
                this.currentJobState = OutsourceJobEnum.All_Not_Confirm;
                FilterEvent(Convert.ToInt32(chkNotConfirm.Tag));

                if (this.lkeMonth.EditValue == null)
                {
                    this._tableWorks = FileProcess.LoadTable("SELECT MHLWorks.MHLWorkID, MHLWorks.WorkNumber, MHLWorks.PayRollMonthID, MHLWorks.MHLWorkDate,MHLWorks.OrderNumber, MHLWorks.CreatedBy, MHLWorks.FromTime, MHLWorks.ToTime, MHLWorks.Accepted, MHLWorks.AcceptedBy, MHLWorks.Rejected, MHLWorks.RejectedBy, MHLWorks.ManagerFeedback, MHLWorks.Received, MHLWorks.Damaged, MHLWorks.MHLWorkConfirm, MHLWorks.Remark, MHLWorks.MHLWorkDefinitionID, MHLWorkDefinitions.MHLWorkDefinitionNumber, MHLWorkDefinitions.JobName, MHLWorkDefinitions.Description, MHLWorks.UnitPrice, MHLWorkDefinitions.UpdatedBy, MHLWorkDefinitions.Unit, MHLWorks.CustomerMainID, MHLWorks.OtherServiceDetailID FROM MHLWorks LEFT JOIN MHLWorkDefinitions ON MHLWorks.MHLWorkDefinitionID = MHLWorkDefinitions.MHLWorkDefinitionID WHERE MHLWorks.MHLWorkConfirm = 0 ORDER BY MHLWorks.MHLWorkID");
                }
                else
                {
                    this._tableWorks = FileProcess.LoadTable("SELECT MHLWorks.MHLWorkID, MHLWorks.WorkNumber, MHLWorks.PayRollMonthID, MHLWorks.MHLWorkDate,MHLWorks.OrderNumber, MHLWorks.CreatedBy, MHLWorks.FromTime, MHLWorks.ToTime, MHLWorks.Accepted, MHLWorks.AcceptedBy, MHLWorks.Rejected, MHLWorks.RejectedBy, MHLWorks.ManagerFeedback, MHLWorks.Received, MHLWorks.Damaged, MHLWorks.MHLWorkConfirm, MHLWorks.Remark, MHLWorks.MHLWorkDefinitionID, MHLWorkDefinitions.MHLWorkDefinitionNumber, MHLWorkDefinitions.JobName, MHLWorkDefinitions.Description, MHLWorks.UnitPrice, MHLWorkDefinitions.UpdatedBy, MHLWorkDefinitions.Unit, MHLWorks.CustomerMainID, MHLWorks.OtherServiceDetailID FROM MHLWorks LEFT JOIN MHLWorkDefinitions ON MHLWorks.MHLWorkDefinitionID = MHLWorkDefinitions.MHLWorkDefinitionID WHERE MHLWorks.MHLWorkConfirm = 0 AND MHLWorks.PayRollMonthID = " + Convert.ToInt32(this.lkeMonth.EditValue) + " ORDER BY MHLWorks.MHLWorkID");
                }

                LoadFoundWorks(this._tableWorks);
            }
        }

        private void chkEmployeeID_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkEmployeeID.Checked)
            {
                if (this.lkeMonth.EditValue == null)
                {
                    this.chkEmployeeID.Checked = false;
                    this.lkeMonth.Focus();
                    this.lkeMonth.ShowPopup();
                }
                else
                {
                    FilterEvent(Convert.ToInt32(chkEmployeeID.Tag));
                    this.txtEmployeeIDFind.ReadOnly = false;
                    this.txtEmployeeIDFind.Focus();
                }
            }
            else
            {
                this.txtEmployeeIDFind.ReadOnly = true;
            }
        }

        private void chkWorkID_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkWorkID.Checked)
            {
                FilterEvent(Convert.ToInt32(chkWorkID.Tag));
                this.txtWorkIDFind.ReadOnly = false;
                this.txtWorkIDFind.Focus();
            }
            else
            {
                this.txtWorkIDFind.ReadOnly = true;
            }
        }

        private void chkRejected_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkRejected.Checked)
            {
                if (this.lkeMonth.EditValue == null)
                {
                    this.chkRejected.Checked = false;
                    this.lkeMonth.Focus();
                    this.lkeMonth.ShowPopup();
                }
                else
                {
                    this.currentJobState = OutsourceJobEnum.Reject;
                    FilterEvent(Convert.ToInt32(chkRejected.Tag));

                    this._tableWorks = FileProcess.LoadTable("SELECT MHLWorks.MHLWorkID, MHLWorks.WorkNumber, MHLWorks.PayRollMonthID," +
                        " MHLWorks.MHLWorkDate,MHLWorks.OrderNumber, MHLWorks.CreatedBy, MHLWorks.FromTime, MHLWorks.ToTime, MHLWorks.Accepted, MHLWorks.AcceptedBy," +
                        " MHLWorks.Rejected, MHLWorks.RejectedBy, MHLWorks.ManagerFeedback, MHLWorks.Received, MHLWorks.Damaged," +
                        " MHLWorks.MHLWorkConfirm, MHLWorks.Remark, MHLWorks.MHLWorkDefinitionID, MHLWorkDefinitions.MHLWorkDefinitionNumber," +
                        " MHLWorkDefinitions.JobName, MHLWorkDefinitions.Description, MHLWorks.UnitPrice, MHLWorkDefinitions.UpdatedBy," +
                        " MHLWorkDefinitions.Unit, MHLWorks.CustomerMainID, MHLWorks.OtherServiceDetailID" +
                        " FROM MHLWorks LEFT JOIN MHLWorkDefinitions ON MHLWorks.MHLWorkDefinitionID = MHLWorkDefinitions.MHLWorkDefinitionID" +
                        " WHERE(MHLWorks.Rejected = 1) and(((MHLWorks.MHLWorkDate)Between '" + Convert.ToDateTime(this.txtFromDate.Text).ToString("yyyy-MM-dd")
                        + "' and '" + Convert.ToDateTime(this.txtToDate.Text).ToString("yyyy-MM-dd") + "')) ORDER BY MHLWorks.MHLWorkID");

                    LoadFoundWorks(this._tableWorks);
                }
            }
        }

        private void chkJobs_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkJobs.Checked)
            {
                if (this.lkeMonth.EditValue == null)
                {
                    this.lkeMonth.Focus();
                    this.lkeMonth.ShowPopup();
                    this.chkJobs.Checked = false;
                }
                else
                {
                    FilterEvent(Convert.ToInt32(chkJobs.Tag));
                    this.lkeWorkDefinitions.ReadOnly = false;
                    this.lkeWorkDefinitions.Focus();
                    this.lkeWorkDefinitions.ShowPopup();
                }
            }
            else
            {
                this.lkeWorkDefinitions.ReadOnly = true;
            }
        }

        private void chkMeZero_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkMeZero.Checked)
            {
                this.currentJobState = OutsourceJobEnum.Me_0;
                FilterEvent(Convert.ToInt32(chkMeZero.Tag));

                if (this.lkeMonth.EditValue == null)
                {
                    this._tableWorks = FileProcess.LoadTable("SELECT MHLWorks.MHLWorkID, MHLWorks.WorkNumber, MHLWorks.PayRollMonthID, MHLWorks.MHLWorkDate,MHLWorks.OrderNumber, MHLWorks.CreatedBy, MHLWorks.FromTime, MHLWorks.ToTime, MHLWorks.Accepted, MHLWorks.AcceptedBy, MHLWorks.Rejected, MHLWorks.RejectedBy, MHLWorks.ManagerFeedback, MHLWorks.Received, MHLWorks.Damaged, MHLWorks.MHLWorkConfirm, MHLWorks.Remark, MHLWorks.MHLWorkDefinitionID, MHLWorkDefinitions.MHLWorkDefinitionNumber, MHLWorkDefinitions.JobName, MHLWorkDefinitions.Description, MHLWorks.UnitPrice, MHLWorkDefinitions.UpdatedBy, MHLWorkDefinitions.Unit, MHLWorks.CustomerMainID, MHLWorks.OtherServiceDetailID FROM MHLWorks LEFT JOIN MHLWorkDefinitions ON MHLWorks.MHLWorkDefinitionID = MHLWorkDefinitions.MHLWorkDefinitionID WHERE SUBSTRING(MHLWorks.CreatedBy, 1, CHARINDEX(' ', MHLWorks.CreatedBy) - 1) = '" + AppSetting.CurrentUser.LoginName + "' AND MHLWorks.MHLWorkConfirm = 0 ORDER BY MHLWorks.MHLWorkID");
                }
                else
                {
                    this._tableWorks = FileProcess.LoadTable("SELECT MHLWorks.MHLWorkID, MHLWorks.WorkNumber, MHLWorks.PayRollMonthID, MHLWorks.MHLWorkDate,MHLWorks.OrderNumber, MHLWorks.CreatedBy, MHLWorks.FromTime, MHLWorks.ToTime, MHLWorks.Accepted, MHLWorks.AcceptedBy, MHLWorks.Rejected, MHLWorks.RejectedBy, MHLWorks.ManagerFeedback, MHLWorks.Received, MHLWorks.Damaged, MHLWorks.MHLWorkConfirm, MHLWorks.Remark, MHLWorks.MHLWorkDefinitionID, MHLWorkDefinitions.MHLWorkDefinitionNumber, MHLWorkDefinitions.JobName, MHLWorkDefinitions.Description, MHLWorks.UnitPrice, MHLWorkDefinitions.UpdatedBy, MHLWorkDefinitions.Unit, MHLWorks.CustomerMainID, MHLWorks.OtherServiceDetailID FROM MHLWorks LEFT JOIN MHLWorkDefinitions ON MHLWorks.MHLWorkDefinitionID = MHLWorkDefinitions.MHLWorkDefinitionID WHERE SUBSTRING(MHLWorks.CreatedBy, 1, CHARINDEX(' ', MHLWorks.CreatedBy) - 1) = '" + AppSetting.CurrentUser.LoginName + "' AND  MHLWorks.PayRollMonthID = " + Convert.ToInt32(this.lkeMonth.EditValue) + " AND MHLWorks.MHLWorkConfirm = 0 ORDER BY MHLWorks.MHLWorkID");
                }
                LoadFoundWorks(this._tableWorks);
            }
        }

        private void chkMe_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkMe.Checked)
            {
                this.currentJobState = OutsourceJobEnum.Me;
                FilterEvent(Convert.ToInt32(chkMe.Tag));

                if (this.lkeMonth.EditValue == null)
                {
                    this._tableWorks = FileProcess.LoadTable("SELECT MHLWorks.MHLWorkID, MHLWorks.WorkNumber, MHLWorks.PayRollMonthID, MHLWorks.MHLWorkDate,MHLWorks.OrderNumber, MHLWorks.CreatedBy, MHLWorks.FromTime, MHLWorks.ToTime, MHLWorks.Accepted, MHLWorks.AcceptedBy, MHLWorks.Rejected, MHLWorks.RejectedBy, MHLWorks.ManagerFeedback, MHLWorks.Received, MHLWorks.Damaged, MHLWorks.MHLWorkConfirm, MHLWorks.Remark, MHLWorks.MHLWorkDefinitionID, MHLWorkDefinitions.MHLWorkDefinitionNumber, MHLWorkDefinitions.JobName, MHLWorkDefinitions.Description, MHLWorks.UnitPrice, MHLWorkDefinitions.UpdatedBy, MHLWorkDefinitions.Unit, MHLWorks.CustomerMainID, MHLWorks.OtherServiceDetailID FROM MHLWorks LEFT JOIN MHLWorkDefinitions ON MHLWorks.MHLWorkDefinitionID = MHLWorkDefinitions.MHLWorkDefinitionID WHERE  MHLWorks.MHLWorkConfirm = 1 AND SUBSTRING(MHLWorks.CreatedBy, 1, CHARINDEX(' ', MHLWorks.CreatedBy) - 1) = '" + AppSetting.CurrentUser.LoginName + "' ORDER BY MHLWorks.MHLWorkID");
                }
                else
                {
                    this._tableWorks = FileProcess.LoadTable("SELECT MHLWorks.MHLWorkID, MHLWorks.WorkNumber, MHLWorks.PayRollMonthID, MHLWorks.MHLWorkDate,MHLWorks.OrderNumber," +
                        " MHLWorks.CreatedBy, MHLWorks.FromTime, MHLWorks.ToTime, MHLWorks.Accepted, MHLWorks.AcceptedBy, MHLWorks.Rejected, MHLWorks.RejectedBy," +
                        " MHLWorks.ManagerFeedback, MHLWorks.Received, MHLWorks.Damaged, MHLWorks.MHLWorkConfirm, MHLWorks.Remark, MHLWorks.MHLWorkDefinitionID," +
                        " MHLWorkDefinitions.MHLWorkDefinitionNumber, MHLWorkDefinitions.JobName, MHLWorkDefinitions.Description, MHLWorks.UnitPrice, " +
                        " MHLWorkDefinitions.UpdatedBy, MHLWorkDefinitions.Unit, MHLWorks.CustomerMainID, MHLWorks.OtherServiceDetailID FROM MHLWorks" +
                        " LEFT JOIN MHLWorkDefinitions ON MHLWorks.MHLWorkDefinitionID = MHLWorkDefinitions.MHLWorkDefinitionID " +
                        " WHERE  MHLWorks.MHLWorkConfirm = 1 AND SUBSTRING(MHLWorks.CreatedBy, 1, CHARINDEX(' ', MHLWorks.CreatedBy) - 1) = '"
                        + AppSetting.CurrentUser.LoginName + "' AND  MHLWorks.PayRollMonthID = " + Convert.ToInt32(this.lkeMonth.EditValue) + " ORDER BY MHLWorks.MHLWorkID");
                }
                LoadFoundWorks(this._tableWorks);
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked)
            {
                this.currentJobState = OutsourceJobEnum.All;
                FilterEvent(Convert.ToInt32(this.chkAll.Tag));
                LoadWorks();
            }
        }
        #endregion

        private void dtNavigatorWorks_PositionChanged(object sender, EventArgs e)
        {
            this._selectedWork = this._tableWorks.Rows[this.dtNavigatorWorks.Position];
            BindData();
            int mhlWorkID = Convert.ToInt32(this._selectedWork["MHLWorkID"]);
            LoadWorkDetails(mhlWorkID);
            this.tabControlDetails.SelectedTabPageIndex = 0;
        }

        private void grvWorkDetail_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            switch (e.Column.FieldName)
            {
                case "CheckDelete":
                    {
                        int id = Convert.ToInt32(this.grvWorkDetail.GetRowCellValue(e.RowHandle, "MHLWorkDetailID"));
                        int result = this._workDetailDA.ExecuteNoQuery("Update MHLWorkDetails Set CheckDelete = {0} Where MHLWorkDetailID = {1}", Convert.ToBoolean(e.Value), id);
                        break;
                    }
            }
        }

        private void tabControlDetails_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            switch (e.Page.Name)
            {
                case "tabWorkDetail":
                    {
                        break;
                    }
                case "tabSuppervisors":
                    {
                        if (this.viewEmployee == null)
                        {
                            this.viewEmployee = new urc_WM_EmployeeInfo(this.txtWorkID.Text, 0, 0, 0);
                            tabSuppervisors.Controls.Add(this.viewEmployee);
                            //this.viewEmployee.LoadEmployeeWorking(this.txtWorkID.Text);
                        }
                        //if (this.tabSuppervisors.Controls.Count <= 0)
                        //{

                        //    if (XtraMessageBox.Show("Are you sure you want to input productivity for 331, 687 and 895 ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        //    {
                        //        DataProcess<object> employeeWorkingDA = new DataProcess<object>();
                        //        float totalQuantity = (float)Convert.ToDecimal(this.grcQuantity.SummaryItem.SummaryValue);
                        //        int result = employeeWorkingDA.ExecuteNoQuery("STEmployeeWorkingLWLeaderInsert @OrderNumber = {0}, @CreatedBy = {1}, @StartTime = {2}, @EndTime = {3}, @OrderDate = {4}, @TotalQuantity = {5},@CustomerID={6},@WorkDefinitionID={7}",
                        //            this.txtWorkID.Text, AppSetting.CurrentUser.LoginName, this.dtFromTime.DateTime,
                        //            this.dtToTime.DateTime, this.txtCreatedDate.DateTime, totalQuantity, Convert.ToInt32(this.lkeCustomers.EditValue), Convert.ToInt32(this.lkeJobs.EditValue));

                        //        tabSuppervisors.Controls.Clear();

                        //        if (this.viewEmployee == null)
                        //        {
                        //            this.viewEmployee = new urc_WM_EmployeeInfo(this.txtWorkID.Text, 0, 0, 0);
                        //            tabSuppervisors.Controls.Add(this.viewEmployee);
                        //            this.viewEmployee.LoadEmployeeWorking(this.txtWorkID.Text);
                        //        }
                        //    }
                        //}
                        //else
                        //{
                        this.viewEmployee.LoadEmployeeWorking(this.txtWorkID.Text);
                        this.viewEmployee.Update();
                        this.viewEmployee.Refresh();
                        if (this.viewEmployee.countEmp == 1)
                        {
                            if (XtraMessageBox.Show("Are you sure you want to input productivity for 331, 687 and 895 ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                DataProcess<object> employeeWorkingDA = new DataProcess<object>();
                                float totalQuantity = (float)Convert.ToDecimal(this.grcQuantity.SummaryItem.SummaryValue);
                                int result = employeeWorkingDA.ExecuteNoQuery("STEmployeeWorkingLWLeaderInsert @OrderNumber = {0}, @CreatedBy = {1}, @StartTime = {2}, @EndTime = {3}, @OrderDate = {4}, @TotalQuantity = {5},@CustomerID={6},@WorkDefinitionID={7}",
                                    this.txtWorkID.Text, AppSetting.CurrentUser.LoginName, this.dtFromTime.DateTime,
                                    this.dtToTime.DateTime, this.txtCreatedDate.DateTime, totalQuantity, Convert.ToInt32(this.lkeCustomers.EditValue), Convert.ToInt32(this.lkeJobs.EditValue));


                            }
                        }

                        this.viewEmployee.LoadEmployeeWorking(this.txtWorkID.Text);
                        this.viewEmployee.Update();
                        this.viewEmployee.Refresh();
                        //}

                        break;
                    }
            }
        }

        private void txtEmployeeIDFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!String.IsNullOrEmpty(this.txtEmployeeIDFind.Text))
                {
                    try
                    {
                        string queryString = "SELECT " +
                                              " MHLWorks.MHLWorkDate,MHLWorks.OrderNumber, MHLWorks.MHLWorkID, MHLWorks.PayRollMonthID, MHLWorks.CreatedBy, MHLWorks.Received, MHLWorks.Damaged," +
                                              " MHLWorks.MHLWorkConfirm, MHLWorks.Remark, MHLWorks.MHLWorkDefinitionID, MHLWorkDefinitions.JobName, MHLWorkDefinitions.Description," +
                                              " MHLWorks.UnitPrice, MHLWorkDefinitions.UpdatedBy, MHLWorkDefinitions.Unit, MHLWorkDefinitions.MHLWorkDefinitionNumber," +
                                              " MHLWorks.OtherServiceDetailID, OtherServiceDetails.OtherServiceID, MHLWorks.CustomerMainID, MHLWorks.FromTime," +
                                              " MHLWorks.ToTime, MHLWorks.Accepted, MHLWorks.AcceptedBy, MHLWorks.Rejected, MHLWorks.RejectedBy, MHLWorks.ManagerFeedback," +
                                              " MHLWorks.WorkNumber, MHLWorkDetails.EmployeeID " +
                                      " FROM	MHLWorks " +
                                      " LEFT JOIN MHLWorkDefinitions ON MHLWorks.MHLWorkDefinitionID = MHLWorkDefinitions.MHLWorkDefinitionID" +
                                      " LEFT JOIN OtherServiceDetails ON MHLWorks.OtherServiceDetailID = OtherServiceDetails.OtherServiceDetailID" +
                                      " INNER JOIN MHLWorkDetails ON MHLWorks.MHLWorkID = MHLWorkDetails.MHLWorkID " +
                                      " WHERE (MHLWorks.MHLWorkDate Between '" + Convert.ToDateTime(this.txtFromDate.Text).Date.ToString("yyyy-MM-dd")
                                      + "' and '" + Convert.ToDateTime(this.txtToDate.Text).Date.ToString("yyyy-MM-dd") + "') " +
                                      " And MHLWorkDetails.EmployeeID =" + Convert.ToInt32(this.txtEmployeeIDFind.Text) +
                                      " ORDER BY MHLWorks.MHLWorkDate, MHLWorks.MHLWorkID";
                        this._tableWorks = FileProcess.LoadTable(queryString);
                        if (this._tableWorks == null) return;
                        LoadFoundWorks(this._tableWorks);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        private void txtWorkIDFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!String.IsNullOrEmpty(txtWorkIDFind.Text))
                {
                    this._tableWorks = FileProcess.LoadTable("SELECT MHLWorks.MHLWorkDate,MHLWorks.OrderNumber, MHLWorks.MHLWorkID, MHLWorks.PayRollMonthID, MHLWorks.CreatedBy, MHLWorks.Received," +
                        " MHLWorks.Damaged, MHLWorks.MHLWorkConfirm, MHLWorks.Remark, MHLWorks.MHLWorkDefinitionID, MHLWorkDefinitions.JobName, MHLWorkDefinitions.Description," +
                        " MHLWorks.UnitPrice, MHLWorkDefinitions.UpdatedBy, MHLWorkDefinitions.Unit, MHLWorkDefinitions.MHLWorkDefinitionNumber, MHLWorks.OtherServiceDetailID," +
                        " OtherServiceDetails.OtherServiceID, MHLWorks.CustomerMainID, MHLWorks.FromTime, MHLWorks.ToTime, MHLWorks.Accepted, MHLWorks.AcceptedBy," +
                        " MHLWorks.Rejected, MHLWorks.RejectedBy, MHLWorks.ManagerFeedback, MHLWorks.WorkNumber " +
                        " FROM(MHLWorks LEFT JOIN MHLWorkDefinitions ON MHLWorks.MHLWorkDefinitionID = MHLWorkDefinitions.MHLWorkDefinitionID) " +
                        " LEFT JOIN OtherServiceDetails ON MHLWorks.OtherServiceDetailID = OtherServiceDetails.OtherServiceDetailID WHERE MHLWorks.MHLWorkID = "
                        + Convert.ToInt32(this.txtWorkIDFind.Text) + " ORDER BY MHLWorks.MHLWorkDate, MHLWorks.MHLWorkID");

                    LoadFoundWorks(this._tableWorks);
                }
            }
        }
        #endregion

        private bool IsAllowConfirm()
        {
            int mhlWorkID = Convert.ToInt32(this._selectedWork["MHLWorkID"]);
            System.Data.Entity.Core.Objects.ObjectParameter qty = new System.Data.Entity.Core.Objects.ObjectParameter("recordQty", -1);
            using (var context = new SwireDBEntities())
            {
                context.STMHLWorkTheSameTimeCheckConfirm(mhlWorkID, qty);
            }

            if (Convert.ToInt32(qty.Value) > 0)
            {
                return false;
            }

            return true;
        }

        private void UpdateMHLWork()
        {
            DataProcess<MHLWorks> workDA = new DataProcess<MHLWorks>();
            int result = workDA.Update(GetMHLWork());
            this._selectedWork["CreatedBy"] = this.txtCreated.Text;
        }

        private MHLWorks GetMHLWork()
        {
            MHLWorks work = new MHLWorks();
            work.MHLWorkID = Convert.ToInt32(this._selectedWork["MHLWorkID"]);
            work.MHLWorkDate = Convert.ToDateTime(this._selectedWork["MHLWorkDate"]);
            work.MHLWorkDefinitionID = Convert.ToInt32(this._selectedWork["MHLWorkDefinitionID"]);
            work.OtherServiceDetailID = !Convert.IsDBNull(this._selectedWork["OtherServiceDetailID"]) ? Convert.ToInt32(this._selectedWork["OtherServiceDetailID"]) : (int?)null;
            work.PayRollMonthID = !Convert.IsDBNull(this._selectedWork["PayRollMonthID"]) ? Convert.ToInt32(this._selectedWork["PayRollMonthID"]) : (int?)null;
            work.Received = Convert.ToInt32(this._selectedWork["Received"]);
            work.Rejected = Convert.ToBoolean(this._selectedWork["Rejected"]);
            work.RejectedBy = Convert.ToString(this._selectedWork["RejectedBy"]);
            work.UnitPrice = !Convert.IsDBNull(this._selectedWork["UnitPrice"]) ? (float)Convert.ToDecimal(this._selectedWork["UnitPrice"]) : (float?)null;
            work.WorkNumber = Convert.ToString(this._selectedWork["WorkNumber"]);
            work.CustomerMainID = !Convert.IsDBNull(this._selectedWork["CustomerMainID"]) ? Convert.ToInt32(this._selectedWork["CustomerMainID"]) : (int?)null;
            work.Damaged = Convert.ToInt32(this._selectedWork["Damaged"]);
            work.FromTime = !Convert.IsDBNull(this._selectedWork["FromTime"]) ? Convert.ToDateTime(this._selectedWork["FromTime"]) : (DateTime?)null;
            work.ToTime = !Convert.IsDBNull(this._selectedWork["ToTime"]) ? Convert.ToDateTime(this._selectedWork["ToTime"]) : (DateTime?)null;
            work.CreatedBy = Convert.ToString(this.txtCreated.Text);
            work.MHLWorkConfirm = Convert.ToBoolean(this._selectedWork["MHLWorkConfirm"]);
            work.Remark = Convert.ToString(this._selectedWork["Remark"]);
            work.OrderNumber = Convert.ToString(this._selectedWork["OrderNumber"]);
            return work;
        }

        private void AddNewWork()
        {
            try
            {
                DataProcess<MHLWorks> workDA = new DataProcess<MHLWorks>();
                MHLWorks work = GetMHLWork();

                int result = workDA.Insert(work);

                // Reset suppervisor tab and employee list
                this.tabSuppervisors.Controls.Clear();
                this.viewEmployee = null;

                this._isAddNew = false;
                if (result != -2)
                {
                    LoadWorks();
                }
                else
                {
                    XtraMessageBox.Show("Unexpected error, insert failed !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateNewWork()
        {
            this._isAddNew = true;
            ResetData();
            DataRow newWork = this._tableWorks.NewRow();
            newWork["MHLWorkDate"] = DateTime.Now;
            newWork["Received"] = 0;
            newWork["Damaged"] = 0;
            newWork["UnitPrice"] = 0;
            newWork["MHLWorkConfirm"] = false;
            newWork["Rejected"] = false;
            newWork["MHLWorkDefinitionID"] = 1;
            newWork["MHLWorkID"] = 0;
            newWork["Accepted"] = false;
            newWork["FromTime"] = DateTime.Now.AddHours(-1);
            newWork["ToTime"] = DateTime.Now;
            newWork["CreatedBy"] = AppSetting.CurrentUser.LoginName + " - " + DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            this._tableWorks.Rows.Add(newWork);
            this._selectedWork = newWork;
            this.dtNavigatorWorks.DataSource = this._tableWorks;
            this.dtNavigatorWorks.Position = this._tableWorks.Rows.Count - 1;
            this.txtCreated.Text = AppSetting.CurrentUser.LoginName + " - " + DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            this.txtCreatedDate.EditValue = DateTime.Now;
            this.dtFromTime.EditValue = DateTime.Now.AddHours(-1);
            this.dtToTime.EditValue = DateTime.Now;
        }

        private void ResetData()
        {
            this.txtCreated.Text = "";
            this.txtCustomerName.Text = "";
            //this.txtDamaged.Text = "";
            this.txtJobName.Text = "";
            //this.txtReceived.Text = "";
            this.txtUnit.Text = "";
            this.txtUnitPrice.Text = "0";
            this.txtWorkID.Text = "";
            this.mmeRemark.Text = "";
            this.txtOrderNumber.Text = string.Empty;
            this.lkeCustomers.EditValue = null;
            this.lkeJobs.EditValue = null;
            this.lkeOtherServices.EditValue = null;
            this.btnConfirm.Checked = false;
            this.btnReject.Checked = false;
            this.grdWorkDetail.DataSource = null;
            this.Refresh();
        }

        private void FilterEvent(int option)
        {
            switch (option)
            {
                case 1:
                    {
                        this.chkCustomer.Checked = false;
                        this.chkEmployeeID.Checked = false;
                        this.chkJobs.Checked = false;
                        this.chkMe.Checked = false;
                        this.chkMeZero.Checked = false;
                        this.chkRejected.Checked = false;
                        this.chkWorkID.Checked = false;
                        this.chkNotConfirm.Checked = false;
                        break;
                    }
                case 2:
                    {
                        this.chkCustomer.Checked = false;
                        this.chkEmployeeID.Checked = false;
                        this.chkJobs.Checked = false;
                        this.chkAll.Checked = false;
                        this.chkMeZero.Checked = false;
                        this.chkRejected.Checked = false;
                        this.chkWorkID.Checked = false;
                        this.chkNotConfirm.Checked = false;
                        break;
                    }
                case 3:
                    {
                        this.chkCustomer.Checked = false;
                        this.chkEmployeeID.Checked = false;
                        this.chkJobs.Checked = false;
                        this.chkAll.Checked = false;
                        this.chkMe.Checked = false;
                        this.chkRejected.Checked = false;
                        this.chkWorkID.Checked = false;
                        this.chkNotConfirm.Checked = false;
                        break;
                    }
                case 4:
                    {
                        this.chkCustomer.Checked = false;
                        this.chkEmployeeID.Checked = false;
                        this.chkJobs.Checked = false;
                        this.chkAll.Checked = false;
                        this.chkMe.Checked = false;
                        this.chkRejected.Checked = false;
                        this.chkWorkID.Checked = false;
                        this.chkMeZero.Checked = false;
                        break;
                    }
                case 5:
                    {
                        this.chkCustomer.Checked = false;
                        this.chkEmployeeID.Checked = false;
                        this.chkJobs.Checked = false;
                        this.chkAll.Checked = false;
                        this.chkMe.Checked = false;
                        this.chkNotConfirm.Checked = false;
                        this.chkWorkID.Checked = false;
                        this.chkMeZero.Checked = false;
                        break;
                    }
                case 6:
                    {
                        this.chkCustomer.Checked = false;
                        this.chkEmployeeID.Checked = false;
                        this.chkJobs.Checked = false;
                        this.chkAll.Checked = false;
                        this.chkMe.Checked = false;
                        this.chkNotConfirm.Checked = false;
                        this.chkRejected.Checked = false;
                        this.chkMeZero.Checked = false;
                        break;
                    }
                case 7:
                    {
                        this.chkCustomer.Checked = false;
                        this.chkWorkID.Checked = false;
                        this.chkJobs.Checked = false;
                        this.chkAll.Checked = false;
                        this.chkMe.Checked = false;
                        this.chkNotConfirm.Checked = false;
                        this.chkRejected.Checked = false;
                        this.chkMeZero.Checked = false;
                        break;
                    }
                case 8:
                    {
                        this.chkCustomer.Checked = false;
                        this.chkWorkID.Checked = false;
                        this.chkEmployeeID.Checked = false;
                        this.chkAll.Checked = false;
                        this.chkMe.Checked = false;
                        this.chkNotConfirm.Checked = false;
                        this.chkRejected.Checked = false;
                        this.chkMeZero.Checked = false;
                        break;
                    }
                case 9:
                    {
                        this.chkJobs.Checked = false;
                        this.chkWorkID.Checked = false;
                        this.chkEmployeeID.Checked = false;
                        this.chkAll.Checked = false;
                        this.chkMe.Checked = false;
                        this.chkNotConfirm.Checked = false;
                        this.chkRejected.Checked = false;
                        this.chkMeZero.Checked = false;
                        break;
                    }
            }
        }

        private void dtFromTime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                // vailidate date input
                if (this.dtFromTime.DateTime < this.dtToTime.DateTime.AddDays(-15)
                    || this.dtFromTime.DateTime > DateTime.Now
                    || this.dtFromTime.DateTime > this.dtToTime.DateTime)
                {
                    MessageBox.Show("ERROR : Please re-enter the correct time", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.dtFromTime.Focus();
                    return;
                }
                this.txtCreatedDate.DateTime = this.dtFromTime.DateTime;
                this.dtToTime.Focus();
            }
        }

        private void dtToTime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                // Validate date input
                if (this.dtToTime.DateTime > DateTime.Now
                    || this.dtToTime.DateTime < this.dtFromTime.DateTime)
                {
                    MessageBox.Show("ERROR : Please re-enter the correct time", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.dtToTime.Focus();
                    return;
                }
                this.mmeRemark.Focus();
            }
        }

        private void txtJobName_Click(object sender, EventArgs e)
        {
            if (this.lkeJobs.EditValue == null) return;
            int workDefinitionID = Convert.ToInt32(this.lkeJobs.EditValue);
            if (this.frmWorkDefinition == null)
            {
                this.frmWorkDefinition = new frm_WM_MHLWorkDefinitions(workDefinitionID);
            }
            else
            {
                this.frmWorkDefinition.initData(workDefinitionID);
            }
            if (!this.frmWorkDefinition.Enabled) return;
            this.frmWorkDefinition.ShowDialog();

        }

        private void rpi_hpl_OrderNumber_Click(object sender, EventArgs e)
        {
            string orderNumber = Convert.ToString(this.grvWEDetail.GetFocusedRowCellValue("OrderNumber"));
            var orderType = orderNumber.Split('-');
            int orderID = Convert.ToInt32(orderType[1]);
            switch (orderType[0])
            {
                case "RO":
                    frm_WM_ReceivingOrders receivingOrder = frm_WM_ReceivingOrders.Instance;
                    receivingOrder.ReceivingOrderIDFind = orderID;
                    receivingOrder.Show();
                    receivingOrder.WindowState = FormWindowState.Maximized;
                    receivingOrder.BringToFront();
                    break;
                case "DO":
                    // Display disptching order
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

        private void Btn_WM_S_New_Click(object sender, EventArgs e)
        {
            this.SetEditable(true);
            CreateNewWork();

            this.lkeCustomers.Focus();
            this.lkeCustomers.ShowPopup();
        }

        private void txtServiceNumber_Click(object sender, EventArgs e)
        {
            if (this.txtServiceNumber.Tag == null) return;
            int serviceDetailID = Convert.ToInt32(this.txtServiceNumber.Tag);
            var currentOtherservice = this.listOtherService.Where(oth => oth.OtherServiceDetailID == serviceDetailID).FirstOrDefault();
            if (currentOtherservice == null) return;
            int serviceID = currentOtherservice.OtherServiceID;
            if (serviceID <= 0) return;
            frm_BR_OtherServices frm = new frm_BR_OtherServices();
            frm.OtherServiceIDFind = serviceID;
            frm.Show();
        }

        private void txtCreated_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void dockPanelActiveServices_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            if (this.Billing == null)
            {
                Billing = new urc_WM_BillingContracts(Convert.ToInt32(_selectedWork["CustomerMainID"]));
            }
            Billing.Parent = this.dockPanelActiveServices;
        }

        private void dockPanelOJWorkLinked_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            if (this.OJLinked == null)
            {
                OJLinked = new urc_WM_OutsourcedJobLinked(Convert.ToInt32(_selectedWork["CustomerMainID"]));
            }
            OJLinked.Parent = this.dockPanelOJWorkLinked;
        }

        private void dockPanelRecentWorkServices_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            if (this.RecentWS == null)
            {
                RecentWS = new urc_WM_ServicesWorksRecent(Convert.ToInt32(_selectedWork["CustomerMainID"]));
            }
            RecentWS.Parent = this.dockPanelRecentWorkServices;
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            var levelDepartmentTb = FileProcess.LoadTable("SELECT count(UserRoleDefinitions.LevelDepartment) as LevelDepartment" +
            " FROM UserAccounts INNER JOIN" +
                         " UserApplications ON UserAccounts.LoginName = UserApplications.UserId INNER JOIN" +
                         " UserApplicationRoles ON UserApplications.UserApplicationId = UserApplicationRoles.UserApplicationId INNER JOIN" +
                         " UserRoleDefinitions ON UserApplicationRoles.RoleId = UserRoleDefinitions.RoleId" +
                         " WHERE UserDepartmentDefinitionID = 7 and UserAccounts.LoginName = '" + AppSetting.CurrentUser.LoginName + "'");


            int levelDepartment = Convert.ToInt32(levelDepartmentTb.Rows[0]["LevelDepartment"].ToString());
            if (levelDepartment == 0)
            {
                MessageBox.Show("Permission denied!", "WMS_2017", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.lkeMonth.EditValue == null)
            {
                this.lkeMonth.Focus();
                this.lkeMonth.ShowPopup();
                return;
            }

            string varDestination = "";
            var msg = MessageBox.Show("Send report to the address : " + varDestination + " ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msg.Equals(DialogResult.No)) return;

            //1 send email Permanent,BY PRODUCTIVITY,Monthly Payroll Permanent Employees by Productivity
            this.LoadSourceEmail(varDestination, "Permanent", "BY PRODUCTIVITY", "Monthly Payroll Permanent Employees by Productivity " + lkeMonth.Text);

            //1 send email Temporary,BY PRODUCTIVITY,Monthly Payroll Permanent Employees by Productivity
            this.LoadSourceEmail(varDestination, "Temporary", "BY PRODUCTIVITY", "Monthly Payroll Temporary Employees by Productivity " + lkeMonth.Text);

            //1 send email Temporary,BY MONTH,Monthly Payroll Permanent Employees by Month
            this.LoadSourceEmail(varDestination, "Temporary", "BY MONTH", "Monthly Payroll Temporary Employees by Month " + lkeMonth.Text);
        }

        private void LoadSourceEmail(string varDestination, string PermanentType, string ProductivityType, string subject)
        {

            DataProcess<object> dataProcess = new DataProcess<object>();
            dataProcess.ExecuteNoQuery("STEmployeeWorkingByJobCrosstapReport_SendEmail @PayRollMonthID={0},@ContractPermanent={1},@Productivity={2},@varStoreID={3}",
                this.lkeMonth.EditValue, PermanentType, ProductivityType, AppSetting.StoreID);

            // load data source to export excel
            //var datasource = FileProcess.LoadTable("STEmployeeWorkingByJobCrosstapReport @PayRollMonthID=" + this.lkeMonth.EditValue
            //    + ",@varStoreID=" + AppSetting.StoreID);

            var datasource = FileProcess.LoadTable("STEmployeeWorkingByJobCrosstapReport_SendEmail @PayRollMonthID = " + this.lkeMonth.EditValue + ", @ContractPermanent = '" +
                PermanentType + "', @Productivity = '" + ProductivityType + "', @varStoreID = " + AppSetting.StoreID);

            // Get path file to export
            string attachPath = AppSetting.PathEmailAttach + DateTime.Now.ToString("dd_MM_yyyy") + " " + subject + ".xlsx";
            this.ExportExel(attachPath, datasource);

            // Send email
            var resultSend = Common.Process.DataTransfer.SendMailOutlookWithOriginalFile(varDestination, subject + "", "Report From HR-ECV",false, attachPath);
            if (resultSend)
            {
                MessageBox.Show("Send successful [" + subject + "]");
            }
            else
            {
                MessageBox.Show("Send fail");
            }
        }

        private void ExportExel(string fileExport, DataTable dataSource)
        {
            DevExpress.XtraGrid.GridControl grdReport = new DevExpress.XtraGrid.GridControl();
            DevExpress.XtraGrid.Views.Grid.GridView grvReport = new DevExpress.XtraGrid.Views.Grid.GridView(grdReport);
            grdReport.MainView = grvReport;
            grdReport.ForceInitialize();
            grdReport.BindingContext = new BindingContext();
            grdReport.DataSource = dataSource;
            grvReport.PopulateColumns();

            // Export data to excel file
            grvReport.ExportToXlsx(fileExport);
        }

        private void btn_checkAll_Click(object sender, EventArgs e)
        {
            if (btn_checkAll.Text == "Check All")
            {
                for (int i = 0; i < grvWorkDetail.DataRowCount; i++)
                {
                    grvWorkDetail.SetRowCellValue(i, "CheckDelete", true);

                }
                btn_checkAll.Text = "UnCheck All";
            }
            else
            {
                for (int i = 0; i < grvWorkDetail.DataRowCount; i++)
                {
                    grvWorkDetail.SetRowCellValue(i, "CheckDelete", false);

                }
                btn_checkAll.Text = "Check All";
            }
        }
        private bool PayRollMonthlyIsAccepted(DateTime ojDate)
        {
            bool accept = false;
            if (this._selectedWork != null && ojDate != null)
            {
                var dateTime = ojDate;
                DataProcess<PayrollMonth> dataProcess = new DataProcess<PayrollMonth>();
                var dataSource = dataProcess.Select(p => p.FromDate <= dateTime && p.ToDate >= dateTime).FirstOrDefault();
                if (dataSource != null)
                {
                    if (dataSource.PayrollMonthConfirm)
                    {
                        accept = true;
                    }
                }

            }
            return accept;


        }

        private void txtCreatedDate_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (Convert.ToBoolean(this._selectedWork["MHLWorkConfirm"]) == false)
            {
                DateTime? dateInput = null;
                try
                {
                    dateInput = Convert.ToDateTime(e.NewValue).Date;
                }
                catch (Exception ex)
                {
                    txtCreatedDate.ErrorText = "Invalid date";
                    e.Cancel = true;
                    return;
                }
                if (this.PayRollMonthlyIsAccepted((DateTime)dateInput))
                {

                    txtCreatedDate.ErrorText = "Current payroll in this month had confirmed";
                    e.Cancel = true;
                    return;
                }
                txtCreatedDate.ErrorText = "";
                this._selectedWork["MHLWorkDate"] = this.txtCreatedDate.DateTime;
            }

        }

        private void txtCreatedDate_Leave(object sender, EventArgs e)
        {

        }

        private void dtToTime_Validating(object sender, CancelEventArgs e)
        {
            if (!this.dtToTime.IsModified) return;
            e.Cancel = false;
            if (dtToTime != null && dtToTime.DateTime.Year >= 2016)
            {
                dtToTime.DateTime = new DateTime(dtToTime.DateTime.Year, dtToTime.DateTime.Month, dtToTime.DateTime.Day, dtToTime.DateTime.Hour, dtToTime.DateTime.Minute, 0, dtToTime.DateTime.Kind);
                if (dtFromTime != null)
                {
                    if (this.dtToTime.DateTime > DateTime.Now)
                    {
                        XtraMessageBox.Show("Invalid date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        e.Cancel = true;
                        this.dtToTime.Focus();
                        return;
                    }
                    dtFromTime.DateTime = dtFromTime.DateTime.AddMilliseconds(-dtFromTime.DateTime.Second);

                    if (Convert.ToDateTime(dtFromTime.DateTime) > Convert.ToDateTime(dtToTime.DateTime))
                    {
                        XtraMessageBox.Show("Start time <= End time", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        e.Cancel = true;
                        this.dtToTime.Focus();
                        return;
                    }
                }
                else
                {
                    XtraMessageBox.Show("Enter Start time", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Cancel = true;
                    this.dtFromTime.Focus();
                    return;
                }
            }
        }

        private void dtFromTime_Validating(object sender, CancelEventArgs e)
        {
            if (!this.dtFromTime.IsModified) return;
            if (dtFromTime != null && dtFromTime.DateTime.Year >= 2016)
            {
                dtFromTime.DateTime = new DateTime(dtFromTime.DateTime.Year, dtFromTime.DateTime.Month, dtFromTime.DateTime.Day, dtFromTime.DateTime.Hour, dtFromTime.DateTime.Minute, 0, dtFromTime.DateTime.Kind);
                if (dtToTime != null && dtToTime.DateTime.Year >= 2016)
                {
                    //if (this.dtFromTime.DateTime < DateTime.Now.AddDays(-7))
                    //{
                    //    XtraMessageBox.Show("Invalid date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //    e.Cancel = true;
                    //    this.dtFromTime.Focus();
                    //    //this.validateList[dtFromTime] = true;
                    //    return;
                    //}
                    dtToTime.DateTime = new DateTime(dtToTime.DateTime.Year, dtToTime.DateTime.Month, dtToTime.DateTime.Day, dtToTime.DateTime.Hour, dtToTime.DateTime.Minute, 0, dtToTime.DateTime.Kind);
                    if (Convert.ToDateTime(dtFromTime.DateTime) > Convert.ToDateTime(dtToTime.DateTime))
                    {
                        XtraMessageBox.Show("Start time <= End time", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.dtFromTime.Focus();
                        //this.validateList[dtFromTime] = true;
                        e.Cancel = true;
                        return;
                    }
                }
            }
        }

        private void btnInsertData_Click(object sender, EventArgs e)
        {
            int mhlWorkID = Convert.ToInt32(this._selectedWork["MHLWorkID"]);
            if (this.listEmployeeEntry.Count <= 0) return;
            if (mhlWorkID <= 0) return;

            DataProcess<MHLWorkDetails> dataProcess = new DataProcess<MHLWorkDetails>();
            IList<MHLWorkDetails> insertList = new List<MHLWorkDetails>();
            MHLWorkDetails newMHLDetail = null;

            foreach (var entry in this.listEmployeeEntry)
            {
                newMHLDetail = new MHLWorkDetails();
                newMHLDetail.CreatedBy = AppSetting.CurrentUser.LoginName;
                newMHLDetail.CreatedTime = DateTime.Now;
                newMHLDetail.DetailRemark = entry.Remarks;
                newMHLDetail.EmployeeID = entry.EmployeeID;
                newMHLDetail.MHLWorkID = mhlWorkID;
                newMHLDetail.Quantity = entry.Qty;
                insertList.Add(newMHLDetail);
            }
            dataProcess.Insert(insertList.ToArray());
            this.LoadWorkDetails(mhlWorkID);
        }

        private void grvDataEntry_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle < 0) return;
            var employeeID = Convert.ToInt32(this.grvDataEntry.GetRowCellValue(e.RowHandle, "EmployeeID"));
            if (employeeID <= 0) return;
            switch (e.Column.FieldName)
            {
                case "Qty":
                    if (Convert.ToInt32(e.Value) > 0)
                    {
                        int countEmptyRow = this.listEmployeeEntry.Count(r => r.EmployeeID <= 0);
                        if (countEmptyRow < 1)
                        {
                            this.listEmployeeEntry.Add(new EmployeeMHLEntry());
                            this.grvDataEntry.RefreshData();
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private void grvDataEntry_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            this.grvDataEntry.SetFocusedRowCellValue("EmployeeID", 0);
        }
    }
}
