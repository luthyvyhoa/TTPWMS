using DevExpress.XtraEditors;
using log4net;
using System;
using System.Data;
using System.Windows.Forms;
using UI.CRM;
using UI.Helper;
using UI.Management;
using UI.MasterSystemSetup;
using UI.ReportForm;
using UI.StockTake;
using UI.WarehouseManagement;
using UI.Supperviors;
using DA;
using UI.Transport;
using UI.Admin;
using UI.ReportFile;
using System.IO;

namespace UI
{
    public partial class frmMain : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        // Declare log
        private static readonly log4net.ILog log = LogManager.GetLogger(typeof(frmMain));

        /// <summary>
        /// Init main form
        /// </summary>
        private static readonly frmMain instance = new frmMain();
        public static bool isManagement = false;
        /// <summary>
        /// Declare timer to load remainder data
        /// </summary>

        private bool isFirstLoad = true;
        private frm_WM_MHLWorkEmployeeSummary frmWorkEmplyeeSummary = null;
        public frmMain()
        {
            // Init controls designer in main form
            this.InitializeComponent();
        }



        /// <summary>
        /// Get footer info
        /// </summary>
        public void InitFoolterInfo()
        {
            this.bsiUserName.Caption = "Tài Khoản: " + AppSetting.CurrentUser.LoginName;
            this.bsiBranchStore.Caption = "Kho: " + AppSetting.StoreName;
            this.bsiVersion.Caption = "Phiên Bản: " + Application.ProductVersion;
        }

        /// <summary>
        /// Get Main form instance
        /// </summary>
        public static frmMain Instance
        {
            get
            {
                return instance;
            }
        }

        /// <summary>
        /// Set active groups
        /// </summary>
        /// <param name="groupsList"></param>
        public void SetActiveGroup(DataTable groupsList)
        {
            foreach (DataRow groupItem in groupsList.Rows)
            {
                // Detect group active
                switch (groupItem["GroupName"].ToString())
                {
                    case "Billing":
                        this.acd_BCHD.Visible = true;
                        break;

                    case "Internal":
                        this.acd_HoatDong.Visible = true;
                        break;

                    case "Management":               
                        this.acd_QL.Visible = true;
                        break;

                    case "Master system":
                        this.acd_CauHinh.Visible = true;
                        break;

                    case "Warehouse Management":
                        this.acd_Kho.Visible = true;
                        break;

                    case "Warehouse Report":
                        this.acd_BCKho.Visible = true;
                        break;

                    case "Warehouse Supervisor":
                        this.acd_GiamSat.Visible = true;
                        break;
                    case "Bussiness":
                        this.acd_KinhDoanh.Visible = true;
                        break;

                    case "Personnel":
                        this.acd_CaNhan.Visible = true;
                        break;

                    case "Transport Supervisor":
                        this.acd_DiChuyen.Visible = true;
                        break;
                }
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

            // Get foolter info
            this.InitFoolterInfo();

            // Init inOutView form
            var inOutViewControl = frm_WM_InOutViewByDate.Instance;
            inOutViewControl.Parent = this.pnlMain;
            inOutViewControl.Dock = DockStyle.Fill;
        }

        /// <summary>
        /// Just only user has deparment in bussiness development must show contract form
        /// </summary>
        /// <returns></returns>
        private static bool CheckActiveContractForm()
        {
            var dataSource = FileProcess.LoadTable("ST_WMS_CheckActivePriceColumn @LoginName='" + AppSetting.CurrentUser.LoginName + "'");
            // Set active controls
            for (int role = 0; role < dataSource.Rows.Count; role++)
            {
                var currentRole = Convert.ToString(dataSource.Rows[role]["UserDepartmentDefinitionName"]);
                if (currentRole.ToLower().Equals("bussiness development"))
                {
                    return true;
                }
            }
            return false;
        }

        void btn_S_EmployeeKPIDefinition_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void Btn_M_SetAisles_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_MSS_Rooms_Aisle_DataUpdate frm = new frm_MSS_Rooms_Aisle_DataUpdate();
            frm.BringToFront();
            frm.WindowState = System.Windows.Forms.FormWindowState.Normal;
            frm.Show();
        }

        private void BtnQuotations_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_CRM_QuotationList frm = new frm_CRM_QuotationList();
            frm.BringToFront();
            frm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            frm.Show();
        }

        private void BtnContract_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_CRM_ContractList frm = new frm_CRM_ContractList();
            frm.BringToFront();
            frm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            frm.Show();
        }

        public void RefreshLocalData()
        {
            //this.lblLoadLocal.Caption = "Waiting";
            Application.DoEvents();
            string dotText = string.Empty;
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            AppSetting.RefreshLocalData();
            //this.lblLoadLocal.Caption = "Done!";
            this.InitFoolterInfo();
            Application.DoEvents();
        }

        private void rpi_btnSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var btn = (ButtonEdit)sender;
                string condition = Convert.ToString(btn.EditValue);
                this.SearchData(condition);
            }
        }

        bool IsAllDigits(string s)
        {
            foreach (char c in s)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }

        private void SearchData(string condition)
        {
            frmSearchResult.Instance.Condition = condition;
            frmSearchResult.Instance.Show();
            frmSearchResult.Instance.BringToFront();
        }

        #region Supervisors
        void Btn_S_SJTHS_WorkingCheck_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        void Btn_S_SJTHS_UnLockedOrders_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_S_SJTHS_OrdersUnconfirm;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        void Btn_S_SJTHS_StockCorrection_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_S_SJTHS_StockCorrection;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        void Btn_S_SJTHS_ScheduledJobs_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MessageBox.Show("Nghiep vu nay khong dung, DoCmd.OpenForm frmScheduled_JobRemind, acNormal");
        }

        void Btn_S_SJTHS_Release_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MessageBox.Show("Nghiep vu nay khong dung.");
        }

        void Btn_S_SJTHS_Quarantine_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        void Btn_S_SJTHS_PropertyDamages_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_S_SJTHS_PropertyDamages;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        void Btn_S_SJTHS_ProductDamages_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_S_SJTHS_ProductDamages;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        void Btn_S_SJTHS_OtherJobs_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_S_SJTHS_OtherJobs;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        void Btn_S_SJTHS_KPI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        void Btn_S_SJTHS_JobDefinition_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_S_SJTHS_OtherJobDefinitions;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        void Btn_S_SJTHS_Complains_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_S_SJTHS_CustomerComplains;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        void Btn_S_SJTHS_AccidentsIncidents_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_S_SJTHS_Accidents;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        void Btn_S_PCO_Reminders_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        void Btn_S_PCO_OvertimesEntry_Confirm_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_S_PCO_EmployeeOTSupervisors;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        void Btn_S_PCO_MonthlyEvaluation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_S_PCO_PayrollMonthlyEvaluation;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        void Btn_S_PCO_EmployeeEvents_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_S_PCO_EmployeeEvents;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        void Btn_S_AO_Problems_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        void Btn_S_AO_OfficialWarning_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_S_AO_Warnings;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        void Btn_S_AO_LaborSafetyTrainings_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        void Btn_S_AO_EmployeeTrainings_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_S_AO_TrainingPositionRequirements;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        #endregion Supervisors

        #region Management
        void Btn_M_SDT_ReportToCustomers_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_M_SDT_ReportToCustomer;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        void Btn_M_SDT_DifferenceCheck_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_M_SDT_DifferenceCheck;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        void Btn_M_SDT_DeleteProducts_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_M_SDT_DeleteProducts;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        void Btn_M_SDT_CompactDatabase_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_M_SDT_CompactDatabase;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        void Btn_M_GO_StockOnHandAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_M_GO_StockOnHandAllCustomer;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        void Btn_M_GO_StockMovementAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_M_GO_StockMovementReportAllCustomers;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        void Btn_M_GO_ProductionQuantityChecking_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            //v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_M_GO_EmployeeWorkingProductionCheck;
            //v_CVarParaKhoiTao.Form = this;

            //UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
            frm_M_GO_EmployeeWorkingCheck frm = new frm_M_GO_EmployeeWorkingCheck();
            frm.Show();
        }

        void Btn_M_GO_CustomerAllocation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_M_GO_StockOnHandByRoomSummary;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        void Btn_M_GO_Contracts_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_M_GO_Contracts;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        void Btn_M_DW_StockOnHandDailyChart_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_M_DW_StockOnHandWeekyByCustomer;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        void Btn_M_DW_StockOnHandDaily_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MessageBox.Show("DoCmd.OpenReport rptStockOnHandDailyAllCustomers, acViewPreview");
        }

        void Btn_M_DW_StockOnHandAverageMonthly_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_M_DW_StockOnHandAverage;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        void Btn_M_DW_News_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_M_DW_News;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        void Btn_M_DW_DailyHandling_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_M_DW_SummaryInOutByDate;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        #endregion Management

        #region  Billing Report
        void Btn_BR_ViewByCustomer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_BR_BillingSummaryByCustomer;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }
        void Btn_BR_ProductTracing_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_BR_ProductTracing;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        void Btn_BR_ContractsMissing_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_BR_Accounting_MissingContracts;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }
        #endregion  Billing Report

        #region Stock Take

        void Btn_ST_CloseStock_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_ST_CloseStock;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        private void btn_WR_AllStock_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            StockTake.frm_ST_StockTakeByRequestAllData frmStockTakeByRequestAllData = new StockTake.frm_ST_StockTakeByRequestAllData();
            frmStockTakeByRequestAllData.Show();
            frmStockTakeByRequestAllData.WindowState = FormWindowState.Maximized;
        }
        #endregion Stock Take

        #region CRM
        void Btn_CRM_Opportunities_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_CRM_Opportunities;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }
        void Btn_CRM_CustomersFeedback_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_CRM_CustomerFeedbacks;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        #endregion CRM

        #region MasterSystemSetup
        void Btn_MSS_UserAccount_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        void Btn_MSS_ServicesDefinition_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        void Btn_MSS_Rooms_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        void Btn_MSS_Products_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        void Btn_MSS_Office_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_MSS_Office;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        void Btn_MSS_MyCustomer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_MSS_MyCustomers;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        void Btn_MSS_Employees_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            //v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_MSS_Employees;
            //v_CVarParaKhoiTao.Form = this;

            //UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);

            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_MSS_EmployeesList;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        void Btn_MSS_CustomerRequirements_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_MSS_CustomerRequirements;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        void Btn_MSS_CustomerEvents_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        void Btn_MSS_Customer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        void Btn_MSS_ChangePassword_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        #endregion MasterSystemSetup

        #region WarehouseManagement
        void Btn_WM_InOutView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_WM_InOutViewByDate;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        void Btn_WM_BlastFreezer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_WM_BlastFreezers;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        void Btn_WM_Assignments_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_WM_Assignments;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }
        void Btn_WM_TemperatureHumidity_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        void Btn_WM_QuantityChecking_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_WM_QualityCheckings frm = new frm_WM_QualityCheckings();
            frm.Show();
        }
        void Btn_WM_Notes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_WM_Notes;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }
        void Btn_WM_BussinessTrip_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        void Btn_WM_EDI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        void Btn_WM_MassMovement_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new frm_ST_StockMovementMassAll().Show();
        }
        void Btn_WM_GuardHandOver_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_WM_DailyTasks;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        #endregion WarehouseManagement

        private void rpi_btnSearch_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var btn = (ButtonEdit)sender;
            string condition = Convert.ToString(btn.EditValue);
            this.SearchData(condition);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void bsiLogout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Application.Restart();
            Environment.Exit(0);
        }

        private void btn_P_EmployeePerformanceCheck_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int payRollMonthID = 0;

            if (this.frmWorkEmplyeeSummary == null)
            {
                this.frmWorkEmplyeeSummary = new frm_WM_MHLWorkEmployeeSummary(payRollMonthID);
            }
            else
            {
                this.frmWorkEmplyeeSummary.initData(payRollMonthID);
            }

            this.frmWorkEmplyeeSummary.Show();
        }

        private void btnOtherserviceentry_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnIncomeCheck_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnCustomerInquiry_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_CRM_InquiryList frmEQ = new frm_CRM_InquiryList();
            frmEQ.Show();
            frmEQ.WindowState = FormWindowState.Maximized;
        }

        private void btnOutsourceJobList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_WM_OutsourcedJobsList frmOSJL = new frm_WM_OutsourcedJobsList();
            frmOSJL.Show();
            frmOSJL.BringToFront();
            frmOSJL.WindowState = FormWindowState.Maximized;
        }

        private void btn_WR_OvertimeOrders_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btn_DiscontinuedCustomers_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UI.MasterSystemSetup.frm_MSS_CustomersList frm = new frm_MSS_CustomersList(true);
            frm.Show();
            frm.WindowState = FormWindowState.Normal;
            frm.BringToFront();

        }

        private void btn_S_SJTHS_KPI_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btn_WM_WaveOperation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_WM_WaveList frmW = new frm_WM_WaveList();
            frmW.Show();
            frmW.WindowState = FormWindowState.Normal;
            frmW.BringToFront();
        }

        private void btn_WM_RoutePlanning_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_WM_RoutePlanning frmR = new frm_WM_RoutePlanning();
            frmR.Show();
            frmR.BringToFront();
        }

        private void btn_WR_OperationPlanning_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_WR_OperationPlanning frmWP = new frm_WR_OperationPlanning();
            frmWP.Show();
            frmWP.WindowState = FormWindowState.Maximized;
            frmWP.BringToFront();
        }

        private void btn_S_KPITargets_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btn_S_KPIMonthlyReocords_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btn_WM_Transform_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_WM_ProductTransRecords frmPT = new frm_WM_ProductTransRecords();
            frmPT.Show();
            frmPT.WindowState = FormWindowState.Normal;
            frmPT.BringToFront();
        }

        private void btn_MSS_ProductTrasnformSetup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_WM_ProductTransformSetting frmPT = new frm_WM_ProductTransformSetting();
            frmPT.Show();
            frmPT.WindowState = FormWindowState.Normal;
            frmPT.BringToFront();
        }

        private void btn_WR_LostProducts_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_WR_LostProductByRoom frmLP = new frm_WR_LostProductByRoom();
            frmLP.Show();
            frmLP.WindowState = FormWindowState.Normal;
            frmLP.BringToFront();
        }

        private void btn_mnu_ViewEDI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_WM_EDIOrdersViewList frm = new frm_WM_EDIOrdersViewList();
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront();
        }

        private void btn_BR_StockByLocationHistory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_BR_StockByLocationPivot frm = new frm_BR_StockByLocationPivot();
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront();
        }

        private void btn_WR_OrderConfirmationIssues_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btn_OJListView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_WM_OutsourcedJobsList frm = new frm_WM_OutsourcedJobsList();
            frm.Show();
            frm.WindowState = FormWindowState.Normal;
            frm.BringToFront();
        }

        private void btnTripViewSummary_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_WM_TripViewSummary frm = new frm_WM_TripViewSummary();
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront();
        }

        private void btn_S_PCO_Productivity_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void bbn_WR_OrderPercentage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }


        private void btn_BR_BillingsInvoices_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnDataAjustment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_S_DataAdjustments frm = new frm_S_DataAdjustments();
            frm.Show();
            frm.BringToFront();
        }

        private void btn_M_GO_CustomerForecast_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_S_CustomerForecast frm = new frm_S_CustomerForecast();
            frm.Show();
            frm.BringToFront();
        }

        private void btnExpiryWarning_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void bbutton_DispatchingProductPlanned_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_WM_DispatchingProductPlanned frm = new frm_WM_DispatchingProductPlanned();
            frm.Show();
            frm.BringToFront();
        }

        private void btn_MSS_WorkDefinition_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btn_BR_CustomerKPI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_S_CustomerKPIView frm = new frm_S_CustomerKPIView();
            frm.Show();
            frm.BringToFront();
        }

        private void btnOperatingCostCustomerReview_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_CRM_OperatingCostViewByCustomer frm = new frm_CRM_OperatingCostViewByCustomer();
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;

        }

        private void btnOperatingCostLabourEntry_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_CRM_OperatingCostLabourAllocation frm = new frm_CRM_OperatingCostLabourAllocation();
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;

        }

        private void btnOperatingCostEntry_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_CRM_OperatingCostEntry frm = new frm_CRM_OperatingCostEntry();
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;

        }

        private void btnMonthlyParameters_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_CRM_OperatingCostMonthlyParameters frm = new frm_CRM_OperatingCostMonthlyParameters();
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
        }

        private void btnProfitabilitySummary_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_CRM_CustomerProfitabilitySummary frm = new frm_CRM_CustomerProfitabilitySummary();
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront();
        }

        private void btn_mnu_ViewEDIListDetails_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_WM_EDIOrdersViewListDetails frm = new frm_WM_EDIOrdersViewListDetails();
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront();
        }

        private void btn_CRM_CostBreakdown_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_CRM_CostBreakdown frm = new frm_CRM_CostBreakdown();
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront();
        }

        private void bbCustomerServices_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //frm_WM_CustomerServices frm = new frm_WM_CustomerServices();
            //frm.Show();
            //frm.WindowState = FormWindowState.Maximized;
        }

        private void btn_mnu_CustumerBookingEntry_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_WM_CustomerBookingEntry frm = new frm_WM_CustomerBookingEntry();
            frm.Show();
            frm.BringToFront();
        }

        private void btn_M_SDT_CostBreakDown_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_CRM_CostBreakdown frm = new frm_CRM_CostBreakdown();
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront();
        }

        private void btn_M_GO_OperationSummary_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_CRM_OperationSummary frm = new frm_CRM_OperationSummary();
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront();
        }

        private void btn_M_GO_WarehouseDailyKPI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void bbBillingInvoiceCheck_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_CRM_BillingInvoiceContractCheck frm = new frm_CRM_BillingInvoiceContractCheck();
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront();
        }

        private void btnSolomonCheck_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_CRM_BillingInvoiceCheckSolomonAll frm = new frm_CRM_BillingInvoiceCheckSolomonAll(AppSetting.LastOperationMonthID, AppSetting.StoreID);
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront();
        }

        private void bbtn_PlannedDispatchingProductKGR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_WM_DispatchingProductListKGR frm = new frm_WM_DispatchingProductListKGR();
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront();
        }

        private void bbtn_AccountReceivableCheck_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_BR_Accounting_ARCheck frm = new frm_BR_Accounting_ARCheck();
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront();
        }

        private void bbtn_WR_CheckKGR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void bbton_CustomerStockTakes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btn_P_EmployeesPositions_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_MSS_PositionSystem positionForm = new frm_MSS_PositionSystem();
            positionForm.Show();
            positionForm.BringToFront();
        }

        private void btn_P_EmployeesDepartment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //frm_MSS_departmentSystem departmentForm = new frm_MSS_departmentSystem();
            //departmentForm.Show();
        }

        private void btnCheckTranportation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btn_WM_Totes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_WM_Totes totes = new frm_WM_Totes();
            totes.Show();
            totes.BringToFront();
        }

        private void btnCustomerForecast_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_S_CustomerForecast frm = new frm_S_CustomerForecast();
            frm.Show();
            frm.BringToFront();
        }

        private void btnOperationSummary_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_CRM_OperationSummary frm = new frm_CRM_OperationSummary();
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront();
        }

        private void btn_Truck_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_MSS_Trucks frm = new frm_MSS_Trucks();
            frm.Show();
            frm.BringToFront();
        }

        private void btnContract_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btn_mnu_BookingBlast_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_WM_CustomerBookingEntry frm = new frm_WM_CustomerBookingEntry(1);
            frm.Show();
            frm.BringToFront();
        }

        private void btn_M_ProductCheckingByRequest_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void bbtnTransportTrip_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void bbtn_ProductCheckingList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_WM_ProductCheckingList frm = new frm_WM_ProductCheckingList();
            frm.Show();
            frm.BringToFront();
        }

        private void btn_mnu_TimeSlotReview_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_WR_OperationPlanning_OrderReview frm = new frm_WR_OperationPlanning_OrderReview();
            frm.Show();
            frm.WindowState = FormWindowState.Normal;
            frm.BringToFront();
        }

        private void btnAnnualLeaveReview_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_MSS_AnnualLeaveReview frm = new frm_MSS_AnnualLeaveReview();
            frm.Show();
            frm.BringToFront();
        }

        private void btnLunch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_MSS_EmployeeLunch frm = new frm_MSS_EmployeeLunch();
            frm.Show();
            frm.BringToFront();
        }

        private void btn_AD_PurchasingOrder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_AD_PurchasingOrders frm = new frm_AD_PurchasingOrders();
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront();
        }

        private void btn_AD_PettyCash_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_AD_PettyCash frm = new frm_AD_PettyCash();
            frm.Show();
            frm.BringToFront();
        }

        private void barButtonItemEmployeeCard_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            rptLabel_EmployeeCard rpt = new rptLabel_EmployeeCard();//rptQuotationVN(this.quotationID)
            var dataSource = FileProcess.LoadTable("STEmployeeCard " + AppSetting.StoreID);
            rpt.DataSource = dataSource;
            ReportPrintToolWMS printTool = new ReportPrintToolWMS(rpt, 0);
            printTool.AutoShowParametersPanel = false;
            printTool.ShowPreview();
        }

        private void btnOperatingCostLabourSummary_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_CRM_OperatingCostLabourSummary frm = new frm_CRM_OperatingCostLabourSummary();
            frm.Show();
            frm.BringToFront();
        }

        private void btn_S_SJTHS_ScannedData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_S_EmployeeScannedTaskReview frm = new frm_S_EmployeeScannedTaskReview();
            frm.Show();
            frm.BringToFront();
            frm.WindowState = FormWindowState.Normal;
        }

        private void bbtnBillingInvoices_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!this.CheckUserAllowOpen())
            {
                XtraMessageBox.Show("You are Accounting to view this", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frm_AD_BillingInvoices frm = new frm_AD_BillingInvoices();
            frm.Show();
            frm.BringToFront();

        }

        private void rbcMain_SelectedPageChanged(object sender, EventArgs e)
        {
        }

        private void bb_Trans_PriceUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_CRM_ContractTransportUpdate frm = new frm_CRM_ContractTransportUpdate();
            frm.Show();
            frm.BringToFront();
            frm.WindowState = FormWindowState.Maximized;
        }
        private bool CheckUserAllowOpen()
        {
            var dataSource = FileProcess.LoadTable("STCheckDepartmentAccountingByUser @User='" + AppSetting.CurrentUser.LoginName + "'");
            if (Convert.ToInt32(dataSource.Rows[0]["Total"]) > 0) return true;
            else return false;
        }
        private void bbtnBillingInvoiceList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!this.CheckUserAllowOpen())
            {
                XtraMessageBox.Show("You are Accounting to view this", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frm_AD_BillingInvoiceList frm = new frm_AD_BillingInvoiceList();
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront();

        }

        private void bbtnExcel_XML_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!this.CheckUserAllowOpen())
            {
                XtraMessageBox.Show("You are Accounting to view this", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frm_BR_ExcelToXML frmXML = new frm_BR_ExcelToXML();
            frmXML.Show();
            frmXML.WindowState = FormWindowState.Maximized;
            frmXML.BringToFront();
        }


        private void bbtn_SafetyClothes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_AD_SafetyClothes frm = new frm_AD_SafetyClothes();
            frm.Show();
            frm.BringToFront();
        }

        private void btn_AD_POCashReview_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_AD_POCashOrderReview frm = new frm_AD_POCashOrderReview();
            frm.Show();
            frm.BringToFront();
        }

        private void bbtn_PalletStatusChangeList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_WM_PalletStatusChangeList frm = new frm_WM_PalletStatusChangeList();
            frm.Show();
            frm.BringToFront();
        }

        private void bb_ARCheck_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_BR_Accounting_ARCheck frm = new frm_BR_Accounting_ARCheck("ALL");
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront();
        }

        private void bbtn_CustomerPalletStatus_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_MSS_CustomerPalletStatus frm = new frm_MSS_CustomerPalletStatus();
            frm.Show();
            frm.BringToFront();
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = false;
        }

        private void rbcMain_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void btnDataIntegrationMonitoring_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_DI_DataIntegrationMonitoring frm = new frm_DI_DataIntegrationMonitoring();
            frm.Show();
            frm.BringToFront();
        }

        private void btn_S_PCO_QHSEDoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_S_QHSE_Equipment frm = new frm_S_QHSE_Equipment();
            frm.Show();
            frm.BringToFront();
            frm.WindowState = FormWindowState.Maximized;
        }

        private void bbtn_SafetyClothesReview_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_AD_SafetyClothesReview frm = new frm_AD_SafetyClothesReview();
            frm.Show();
            frm.BringToFront();
            frm.WindowState = FormWindowState.Normal;
        }

        private void btn_mnu_ViewEDIListNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_WM_EDIOrdersViewListNew frm = new frm_WM_EDIOrdersViewListNew();
            frm.Show();
            frm.BringToFront();
            frm.WindowState = FormWindowState.Maximized;
        }

        private void btn_BR_ContractCommitments_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_CRM_ContractCommitments CC = new frm_CRM_ContractCommitments();
            CC.Show();
            CC.BringToFront();
        }

        private void btn_mnu_ViewEDIShipments_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_WM_EDIShipmentList sl = new frm_WM_EDIShipmentList();
            sl.Show();
            sl.WindowState = FormWindowState.Maximized;
            sl.BringToFront();
        }

        private void acd_item_TaiKhoan_Click(object sender, EventArgs e)
        {
            frm_M_UserAccount frm = new frm_M_UserAccount();
            if (!frm.IsDisposed)
            {
                frm.Show();
                frm.BringToFront();
            }
        }

        private void acd_item_DoiMK_Click(object sender, EventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_MSS_ChangePass;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);

        }

        private void acd_item_ChuyenKho_Click(object sender, EventArgs e)
        {
            frm_MSS_ChangeStore frm = new frm_MSS_ChangeStore();
            frm.Show();
            frm.BringToFront();
        }

        private void acd_item_Phong_Click(object sender, EventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_MSS_RoomSetup;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        private void acd_item_Day_Click(object sender, EventArgs e)
        {
            frm_MSS_Rooms_Aisle_DataUpdate frm = new frm_MSS_Rooms_Aisle_DataUpdate();
            frm.BringToFront();
            frm.WindowState = System.Windows.Forms.FormWindowState.Normal;
            frm.Show();
            frm.BringToFront();
        }

        private void acd_item_KhachHang_Click(object sender, EventArgs e)
        {
            UI.MasterSystemSetup.frm_MSS_CustomersList frm = new frm_MSS_CustomersList();
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront();
        }

        private void acd_item_SanPham_Click(object sender, EventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_MSS_Products;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);

        }

        private void acd_item_DichVu_Click(object sender, EventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_MSS_ServicesDefinition;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        private void acd_item_SuKienKH_Click(object sender, EventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_MSS_CustomerEvents;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        private void acd_item_CongViec_Click(object sender, EventArgs e)
        {
            frm_WM_MHLWorkDefinitions frm = new frm_WM_MHLWorkDefinitions(0);
            frm.Show();
            frm.BringToFront();

            //btn_MSS_CustomerRequirements.ItemClick += Btn_MSS_CustomerRequirements_ItemClick;
            //btn_P_Employees.ItemClick += Btn_MSS_Employees_ItemClick;
            //btn_MSS_MyCustomer.ItemClick += Btn_MSS_MyCustomer_ItemClick;
            //btn_MSS_Office.ItemClick += Btn_MSS_Office_ItemClick;
        }

        private void acd_item_NhaKho_Click(object sender, EventArgs e)
        {
            frm_WM_ReceivingOrders frm = frm_WM_ReceivingOrders.Instance;
            frm.ReceivingOrderIDFind = -1;
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront();
        }

        private void acd_item_XuatKho_Click(object sender, EventArgs e)
        {
            frm_WM_DispatchingOrders frm = frm_WM_DispatchingOrders.GetInstance();
            if (frm.Visible)
            {
                frm.ReloadData();
            }
            frm.Show();
            frm.ShowPopupCustomer();
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront();

        }

        private void acd_item_KTSanPham_Click(object sender, EventArgs e)
        {
            frm_M_ProductCheckingByRequest frm = new frm_M_ProductCheckingByRequest();
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront();
        }

        private void acd_item_KHXuatHang_Click(object sender, EventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_WM_TripViewByDate;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        private void acd_item_EDI_Click(object sender, EventArgs e)
        {
            frm_WM_EDIOrdersViewList frmEDI = new frm_WM_EDIOrdersViewList();
            frmEDI.Show();
            frmEDI.BringToFront();
        }

        private void acd_item_PalletInfo_Click(object sender, EventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_WM_PalletInfo;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        private void acd_item_ChuyenViTri_Click(object sender, EventArgs e)
        {
            frm_ST_StockMovementNew frmStockMovement = new frm_ST_StockMovementNew();
            frmStockMovement.ShowInTaskbar = true;
            frmStockMovement.Show();
            frmStockMovement.BringToFront();
        }

        private void acd_item_XacNhan_Click(object sender, EventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_WM_ConfirmationAll;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        private void acd_item_ViTriTrong_Click(object sender, EventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_WM_FreeLocations;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        private void acd_item_TimKiem_Click(object sender, EventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_WM_Find;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        private void acd_item_XeRaVao_Click(object sender, EventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_WM_GateTruckInOut;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        private void acd_item_ContainerRaVao_Click(object sender, EventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_WM_GateContInOut;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        private void acd_item_HangLeRaVao_Click(object sender, EventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_WM_GatePropertyMovements;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        private void acd_item_NhietDo_Click(object sender, EventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_WM_AirTemperatureEntry;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        private void acd_item_ThueNgoai_Click(object sender, EventArgs e)
        {
            WarehouseManagement.frm_WM_MHLWorks frm = WarehouseManagement.frm_WM_MHLWorks.Instance;
            frm.Show();
            frm.WindowState = FormWindowState.Normal;
            frm.BringToFront();
        }

        private void acd_item_CongTac_Click(object sender, EventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_WM_BusinessTrips;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        private void acd_item_DanNhan_Click(object sender, EventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_WM_SafetyStockWarnings;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        private void acd_item_KhachDatHang_Click(object sender, EventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_WM_CustomerBookingView;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        private void acd_item_DoiTrangThaiKe_Click(object sender, EventArgs e)
        {
            frm_WM_PalletStatusChange frm = new frm_WM_PalletStatusChange();
            frm.Show();
            frm.BringToFront();

            //btn_WM_InOutView.ItemClick += Btn_WM_InOutView_ItemClick;
            //btn_WM_DelOrder.ItemClick += Btn_WM_DelOrder_ItemClick;
            //btn_WM_BlastFreezer.ItemClick += Btn_WM_BlastFreezer_ItemClick;
            //btn_WM_Assignments.ItemClick += Btn_WM_Assignments_ItemClick;
            //btn_WM_QuantityChecking.ItemClick += Btn_WM_QuantityChecking_ItemClick;
            //btn_WM_Notes.ItemClick += Btn_WM_Notes_ItemClick;
            //btn_WM_MassMovement.ItemClick += Btn_WM_MassMovement_ItemClick;
            //btn_WM_GuardHandOver.ItemClick += Btn_WM_GuardHandOver_ItemClick;
        }

        private void acd_item_TonKho_Click(object sender, EventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_WR_StockOnHandByLotReport;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        private void acd_item_ViTriTon_Click(object sender, EventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_WR_StockByLocationReport;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        private void acd_item_BCNhapHang_Click(object sender, EventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_WR_StockReceivedReport;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        private void acd_item_BCXuatHang_Click(object sender, EventArgs e)
        {
            frm_WR_StockDispatchedReport frm = new frm_WR_StockDispatchedReport();
            frm.Show();
            frm.BringToFront();
        }

        private void acd_item_BCChuyenViTri_Click(object sender, EventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_WR_StockMovementReport;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        private void acd_item_BCChuyenHang_Click(object sender, EventArgs e)
        {
            frm_WR_StockMovementByProductReport frm = new frm_WR_StockMovementByProductReport();
            frm.Show();
            frm.BringToFront();
        }

        private void acd_item_BCKeHoach_Click(object sender, EventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_WR_TaskView;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        private void acd_item_BCViTriHangLe_Click(object sender, EventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_WR_StockByLocationManyCustomers;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        private void acd_item_KiemTraKRG_Click(object sender, EventArgs e)
        {
            frm_ST_StockOnHandOneCustomerKGRCheck frm = new frm_ST_StockOnHandOneCustomerKGRCheck(0);
            frm.Show();
            frm.WindowState = FormWindowState.Normal;
            frm.BringToFront();
        }

        private void acd_item_KhachLayHang_Click(object sender, EventArgs e)
        {
            frm_WM_CustomerStockTakes frm = new frm_WM_CustomerStockTakes();
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront();
        }

        private void acd_item_BCNgay_Click(object sender, EventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_ST_StockTakeDaily;
            v_CVarParaKhoiTao.Form = this;
            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        private void acd_item_BCTuan_Click(object sender, EventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_ST_IndependentCheck;
            v_CVarParaKhoiTao.Form = this;
            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        private void acd_item_BCYeuCau_Click(object sender, EventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_ST_StockTakeByRequest;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        private void acd_item_XoaPhieu_Click(object sender, EventArgs e)
        {
            frm_WM_DeletedOrders frm = new frm_WM_DeletedOrders();
            frm.Show();
            frm.BringToFront();
        }

        private void acd_item_BCAnToan_Click(object sender, EventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_WR_RackingSafetyReport;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        private void acd_item_BCDatHang_Click(object sender, EventArgs e)
        {
            frm_WR_OrdersPercentage frm = new frm_WR_OrdersPercentage();
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront();
        }

        private void acd_item_DatHangNgoaiGio_Click(object sender, EventArgs e)
        {
            frm_WR_OvertimeOrders frm = new frm_WR_OvertimeOrders();
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront();
        }

        private void acd_item_PhieuTre_Click(object sender, EventArgs e)
        {
            frm_WR_OrderConfirmationIssues frm = new frm_WR_OrderConfirmationIssues();
            frm.Show();
            frm.WindowState = FormWindowState.Normal;
            frm.BringToFront();
        }

        private void acd_item_HangHetHang_Click(object sender, EventArgs e)
        {
            frm_WM_ProductExpiryWarning frm = new frm_WM_ProductExpiryWarning(0);
            frm.Show();
            frm.BringToFront();

            //btn_WR_SealUsage.ItemClick += Btn_WR_SealUsage_ItemClick;
            //btn_WR_CloseStock.ItemClick += Btn_ST_CloseStock_ItemClick;
        }

        private void acd_item_ChayBill_Click(object sender, EventArgs e)
        {
            bool isBillingOperator = UserPermission.CheckBillingOperator(AppSetting.CurrentUser.LoginName, 4);
            if (!isBillingOperator)
            {
                XtraMessageBox.Show("You are Billing Operator to view this", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_BR_BillingReport;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        private void acd_item_XacNhanBill_Click(object sender, EventArgs e)
        {
            bool isBillingOperator = UserPermission.CheckBillingOperator(AppSetting.CurrentUser.LoginName, 4);
            if (!isBillingOperator)
            {
                XtraMessageBox.Show("You are Billing Operator to view this", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_BR_BillingConfirmations;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        private void acd_item_DSBill_Click(object sender, EventArgs e)
        {
            frm_BR_BillingConfirmationList frm = new frm_BR_BillingConfirmationList();
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront();
        }

        private void acd_item_CamDien_Click(object sender, EventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_BR_ContainerRunningHour;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        private void acd_item_DSDichVu_Click(object sender, EventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_BR_OtherServiceViewByService;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        private void acd_item_DVKhac_Click(object sender, EventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_BR_OtherServices;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        private void acd_item_BCTongHop_Click(object sender, EventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_BR_BillingSummary;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        private void acd_item_BillNhap_Click(object sender, EventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_BR_BillingByReceivingOrders;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        private void acd_item_BillXuat_Click(object sender, EventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_BR_BillingByDispatchingOrders;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        private void acd_item_CheBill_Click(object sender, EventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_BR_BillingCheckBreakdown;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        private void acd_item_KiemTraBill_Click(object sender, EventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_BR_CheckChange;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);


            //btn_BR_ContractsMissing.ItemClick += Btn_BR_ContractsMissing_ItemClick;
            //btn_BR_TraceChanges.ItemClick += Btn_BR_TraceChanges_ItemClick;
            //btn_BR_ViewByCustomer.ItemClick += Btn_BR_ViewByCustomer_ItemClick;
        }

        private void acd_item_KiemTraGiaoHang_Click(object sender, EventArgs e)
        {
            frm_BR_BillingConfirmationListDSC billingConfirmationListDSC = new frm_BR_BillingConfirmationListDSC();
            billingConfirmationListDSC.Show();
            billingConfirmationListDSC.WindowState = FormWindowState.Maximized;
            billingConfirmationListDSC.BringToFront();
        }

        private void acd_item_GiaoHang_Click(object sender, EventArgs e)
        {
            frm_T_TransportTripList frm = new frm_T_TransportTripList();
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront();
        }

        private void acd_item_SinhLoi_Click(object sender, EventArgs e)
        {
            frm_T_ProfitabilityAnalysis ft = new frm_T_ProfitabilityAnalysis();
            ft.Show();
            ft.WindowState = FormWindowState.Maximized;
            ft.BringToFront();
        }

        private void acd_item_DSXe_Click(object sender, EventArgs e)
        {
            frm_T_Vehicles frm = new frm_T_Vehicles();
            frm.Show();
            frm.WindowState = FormWindowState.Normal;
            frm.BringToFront();
        }

        private void acd_item_KHGiaoHang_Click(object sender, EventArgs e)
        {
            frm_WM_EDIRoutePlanning frm = new frm_WM_EDIRoutePlanning();
            frm.Show();
            frm.BringToFront();
        }

        private void acd_item_HDMuaHang_Click(object sender, EventArgs e)
        {
            frm_T_TransportPurchasingContract frm = new frm_T_TransportPurchasingContract();
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront();
        }

        private void acd_item_KPIKho_Click(object sender, EventArgs e)
        {
            frm_M_OperationDailyKPI frm = new frm_M_OperationDailyKPI();
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront();
        }

        private void acd_item_NSNhanVien_Click(object sender, EventArgs e)
        {
            frm_S_EmployeeDailyPerformance frm = new frm_S_EmployeeDailyPerformance();
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront();
        }

        private void acd_item_KTThuNhap_Click(object sender, EventArgs e)
        {
            frm_S_AO_EmployeeIncomeReview frmER = new frm_S_AO_EmployeeIncomeReview();
            frmER.Show();
            frmER.WindowState = FormWindowState.Maximized;
            frmER.BringToFront();
        }

        private void acd_item_KTCongViec_Click(object sender, EventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_S_SJTHS_EmployeeWorkingCheck;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        private void KPIMucTieu_Click(object sender, EventArgs e)
        {
            frm_MSS_EmployeeKPITargetSetting frmET = new frm_MSS_EmployeeKPITargetSetting();
            frmET.Show();
            frmET.WindowState = FormWindowState.Maximized;
            frmET.BringToFront();
        }

        private void acd_item_KPINhom_Click(object sender, EventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_S_SJTHS_KPIRecordings;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        private void acd_item_KPIThang_Click(object sender, EventArgs e)
        {
            frm_S_EmployeeKPIMonthlyRecordings frmET = new frm_S_EmployeeKPIMonthlyRecordings();
            frmET.Show();
            frmET.WindowState = FormWindowState.Normal;
            frmET.BringToFront();
        }

        private void acd_item_SuCo_Click(object sender, EventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_S_AO_InternalAudits;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        private void acd_item_NhacNho_Click(object sender, EventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_S_PCO_EmployeeReminders;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        private void acd_item_DaoTao_Click(object sender, EventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_S_AO_GateCustomerLaborSafetyTrainings;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        private void acd_item_KPI_Click(object sender, EventArgs e)
        {
            frm_MSS_EmployeeKPIDefinitions frmKPID = new frm_MSS_EmployeeKPIDefinitions();
            frmKPID.Show();
            frmKPID.WindowState = FormWindowState.Normal;
            frmKPID.BringToFront();
        }

        private void acd_item_CachLy_Click(object sender, EventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_S_SJTHS_Quarantines;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        private void acd_item_KiemTon_Click(object sender, EventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_S_SJTHS_StockCorrection;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        private void acd_item_DSCongViec_Click(object sender, EventArgs e)
        {
            frm_WM_OutsourcedJobsList frmOSJL = new frm_WM_OutsourcedJobsList();
            frmOSJL.Show();
            frmOSJL.BringToFront();
            frmOSJL.WindowState = FormWindowState.Maximized;
        }

        private void acd_item_ChamCong_Click(object sender, EventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_S_PCO_EmployeeEvents;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        private void acd_item_NgayCong_Click(object sender, EventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_S_PCO_PayrollMonthlyEvaluation;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        private void acd_item_TangCa_Click(object sender, EventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_S_PCO_EmployeeOTSupervisors;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        private void acd_item_KiemHang_Click(object sender, EventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_M_SDT_DifferenceCheck;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        private void acd_item_MoXacNhan_Click(object sender, EventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_S_SJTHS_OrdersUnconfirm;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        private void acc_item_NhanVien_Click(object sender, EventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_MSS_EmployeesList;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        private void acc_item_DaoTao_Click(object sender, EventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_S_AO_TrainingPositionRequirements;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        private void acc_item_ChucDanh_Click(object sender, EventArgs e)
        {
            frm_MSS_PositionSystem positionForm = new frm_MSS_PositionSystem();
            positionForm.Show();
            positionForm.BringToFront();
        }

        private void acc_item_PhongBan_Click(object sender, EventArgs e)
        {
            //frm_MSS_departmentSystem departmentForm = new frm_MSS_departmentSystem();
            //departmentForm.Show();

        }

        private void acc_item_HieuSuatNhanVien_Click(object sender, EventArgs e)
        {
            int payRollMonthID = 0;

            if (this.frmWorkEmplyeeSummary == null)
            {
                this.frmWorkEmplyeeSummary = new frm_WM_MHLWorkEmployeeSummary(payRollMonthID);
            }
            else
            {
                this.frmWorkEmplyeeSummary.initData(payRollMonthID);
            }

            this.frmWorkEmplyeeSummary.Show();
            frmWorkEmplyeeSummary.BringToFront();
        }

        private void acc_item_NgayNghi_Click(object sender, EventArgs e)
        {
            frm_MSS_AnnualLeaveReview frm = new frm_MSS_AnnualLeaveReview();
            frm.Show();
            frm.BringToFront();
        }

        private void acc_item_GiayBaoCom_Click(object sender, EventArgs e)
        {
            frm_MSS_EmployeeLunch frm = new frm_MSS_EmployeeLunch();
            frm.Show();
            frm.BringToFront();
        }

        private void acc_item_TheNhanVien_Click(object sender, EventArgs e)
        {
            rptLabel_EmployeeCard rpt = new rptLabel_EmployeeCard();//rptQuotationVN(this.quotationID)
            var dataSource = FileProcess.LoadTable("STEmployeeCard " + AppSetting.StoreID);
            rpt.DataSource = dataSource;
            ReportPrintToolWMS printTool = new ReportPrintToolWMS(rpt, 0);
            printTool.AutoShowParametersPanel = false;
            printTool.ShowPreview();
        }

        private void acc_item_TongHopVanHanh_Click(object sender, EventArgs e)
        {
            frm_CRM_OperationSummary frm = new frm_CRM_OperationSummary();
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront();
        }

        private void acc_item_TonKhoTatCa_Click(object sender, EventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_M_GO_StockOnHandAllCustomer;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        private void acc_item_TatCaDiChuyenHang_Click(object sender, EventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_M_GO_StockMovementReportAllCustomers;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        private void acc_item_PhanBoKhachHang_Click(object sender, EventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_M_GO_StockOnHandByRoomSummary;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        private void acc_item_HopDong_Click(object sender, EventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_M_GO_Contracts;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        private void acc_item_BocXepHangNgay_Click(object sender, EventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_M_DW_SummaryInOutByDate;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        private void acc_item_BieuDoTonKhoHangNgay_Click(object sender, EventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_M_DW_StockOnHandWeekyByCustomer;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        private void acc_item_TonKhoTrungBinhThang_Click(object sender, EventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_M_DW_StockOnHandAverage;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        private void acc_item_TonKhoHangNgay_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("DoCmd.OpenReport rptStockOnHandDailyAllCustomers, acViewPreview");
        }

        private void acc_item_BaoCaoChoKhachHang_Click(object sender, EventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_M_SDT_ReportToCustomer;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        private void acc_item_CoHoi_Click(object sender, EventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_CRM_Opportunities;
            v_CVarParaKhoiTao.Form = this;
            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        private void acc_item_YeuCauKhachHang_Click(object sender, EventArgs e)
        {
            frm_CRM_InquiryList frmEQ = new frm_CRM_InquiryList();
            frmEQ.Show();
            frmEQ.WindowState = FormWindowState.Maximized;
            frmEQ.BringToFront();
        }

        private void acc_item_BaoGia_Click(object sender, EventArgs e)
        {
            frm_CRM_QuotationList frm = new frm_CRM_QuotationList();
            frm.BringToFront();
            frm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            frm.Show();
        }

        private void acc_item_HopDongKinhDoanh_Click(object sender, EventArgs e)
        {
            frm_CRM_ContractList frm = new frm_CRM_ContractList();
            frm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            frm.Show();
            frm.BringToFront();
        }

        private void acc_item_KhachHangDaDong_Click(object sender, EventArgs e)
        {
            UI.MasterSystemSetup.frm_MSS_CustomersList frm = new frm_MSS_CustomersList(true);
            frm.Show();
            frm.WindowState = FormWindowState.Normal;
            frm.BringToFront();
        }

        private void acc_item_PhanBoChiPhi_Click(object sender, EventArgs e)
        {
            frm_CRM_OperatingCostEntry frm = new frm_CRM_OperatingCostEntry();
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront();
        }

        private void acc_item_PhanBoLaoDong_Click(object sender, EventArgs e)
        {
            frm_CRM_OperatingCostLabourAllocation frm = new frm_CRM_OperatingCostLabourAllocation();
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront();
        }

        private void acc_item_TongHopPhanBo_Click(object sender, EventArgs e)
        {
            frm_CRM_OperatingCostLabourSummary frm = new frm_CRM_OperatingCostLabourSummary();
            frm.Show();
            frm.BringToFront();
        }

        private void acc_item_ThongSoHangThang_Click(object sender, EventArgs e)
        {
            frm_CRM_OperatingCostMonthlyParameters frm = new frm_CRM_OperatingCostMonthlyParameters();
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront();
        }

        private void acc_item_PhanTichChiPhi_Click(object sender, EventArgs e)
        {
            frm_CRM_CostBreakdown frm = new frm_CRM_CostBreakdown();
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront();
        }

        private void acc_item_TongHopHoatDong_Click(object sender, EventArgs e)
        {
            frm_CRM_OperationSummary frm = new frm_CRM_OperationSummary();
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
        }

        private void rpi_txtSearchOption_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.KeyCode.Equals(Keys.Enter)) return;
            string condition = ((DevExpress.XtraEditors.TextEdit)sender).Text;
            this.SearchData(condition);
        }

        private void rpi_txtSearchOption_EditValueChanged(object sender, EventArgs e)
        {
            string condition = ((DevExpress.XtraEditors.TextEdit)sender).Text;
            this.SearchOptionData(condition);
        }

        private void SearchOptionData(string condition)
        {
            if (!IsAllDigits(condition))
                if (condition.Length >= 4)
                {
                    string type = condition.Substring(0, 2).ToUpper();
                    switch (type)
                    {
                        case "DO":
                            frm_WM_DispatchingOrders frm1 = frm_WM_DispatchingOrders.GetInstance(Convert.ToInt32(condition.Substring(2)));
                            frm1.Show();
                            frm1.WindowState = FormWindowState.Maximized;
                            frm1.BringToFront();
                            break;
                        case "RO":
                            frm_WM_ReceivingOrders frm2 = frm_WM_ReceivingOrders.Instance;
                            frm2.ReceivingOrderIDFind = Convert.ToInt32(condition.Substring(2));
                            frm2.Show();
                            frm2.WindowState = FormWindowState.Maximized;
                            frm2.BringToFront();
                            break;
                        case "TW":
                            frm_WM_TripsManagement frm3 = new frm_WM_TripsManagement(Convert.ToInt32(condition.Substring(2)));
                            frm3.Show();
                            frm3.WindowState = FormWindowState.Maximized;
                            frm3.BringToFront();
                            break;
                        case "MM":
                            frm_ST_StockMovementMassAll frm4 = new frm_ST_StockMovementMassAll();
                            frm4.Show();
                            frm4.WindowState = FormWindowState.Maximized;
                            frm4.BringToFront();
                            break;
                        case "PP":
                            frm_WM_PalletInfo frm5 = new frm_WM_PalletInfo();
                            frm5.Show();
                            frm5.WindowState = FormWindowState.Maximized;
                            frm5.BringToFront();
                            break;
                        case "SC":
                            frm_WM_PalletStatusChange frm6 = new frm_WM_PalletStatusChange();
                            frm6.PalletStatusChangeIDFind = Convert.ToInt32(condition.Substring(2));
                            frm6.Show();
                            frm6.WindowState = FormWindowState.Maximized;
                            frm6.BringToFront();
                            break;
                        case "PC":
                            frm_M_ProductCheckingByRequest frm7 = frm_M_ProductCheckingByRequest.GetInstance();
                            frm7.ProductCheckingIDFind = Convert.ToInt32(condition.Substring(2));
                            frm7.Show();
                            frm7.WindowState = FormWindowState.Maximized;
                            frm7.BringToFront();
                            break;
                        case "PI":
                            int palletid = Convert.ToInt32(condition.Substring(2));

                            string sql = " select  CustomerID , ProductID from Pallets p join receivingorderdetails rd on p.receivingorderdetailID = rd.receivingorderdetailID " +
                                "   join receivingorders r on r.receivingorderID = rd.receivingorderID where p.PalletID = " + palletid;
                            DataTable dt = FileProcess.LoadTable(sql);
                            int cusID = Convert.ToInt32(dt.Rows[0]["CustomerID"]);
                            int pdID = Convert.ToInt32(dt.Rows[0]["ProductID"]);
                            frm_WM_PalletInfo frm8 = new frm_WM_PalletInfo(cusID, pdID);
                            frm8.Show();
                            frm8.WindowState = FormWindowState.Maximized;
                            frm8.BringToFront();
                            break;

                        case "TƯ":
                            frm_WM_TripsManagement frm9 = new frm_WM_TripsManagement(Convert.ToInt32(condition.Substring(2)));
                            frm9.Show();
                            frm9.WindowState = FormWindowState.Maximized;
                            frm9.BringToFront();
                            break;
                        default:
                            break;

                    }
                }

        }

        private void acd_HDSD_Click(object sender, EventArgs e)
        {
            string helpPathFile = Application.StartupPath + @"\About\Help.pdf";
            // Kiểm tra file
            if (File.Exists(helpPathFile))
            {
                System.Diagnostics.Process.Start(helpPathFile);
            }
            else
            {
                MessageBox.Show("Không tìm thấy tài liệu HDSD trong hệ thống!", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void acd_item_CapDong_Click(object sender, EventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_WM_BlastFreezers;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        private void acd_item_TruyTimSanPham_Click(object sender, EventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_BR_ProductTracing;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        private void acd_item_EDINavigator_Click(object sender, EventArgs e)
        {
            frm_WM_EDIOrders eDIOrders = new frm_WM_EDIOrders();
            eDIOrders.ShowDialog();
        }

        private void acd_item_EDICheck_Click(object sender, EventArgs e)
        {
            frm_WM_EDIOrdersViewListDetails frm = new frm_WM_EDIOrdersViewListDetails();
            frm.ShowDialog();
        }

        private void acd_item_KiemQuayDau_Click(object sender, EventArgs e)
        {
            frm_WM_CheckPalletReturn frm = new frm_WM_CheckPalletReturn();
            frm.ShowDialog();
        }

        private void acd_item_TheoKH_Click(object sender, EventArgs e)
        {
            UI.Helper.VarData.CVarParaKhoiTao v_CVarParaKhoiTao = new UI.Helper.VarData.CVarParaKhoiTao();
            v_CVarParaKhoiTao.Function = UI.Helper.VarData.CFunction.WMS_BR_BillingSummaryByCustomer;
            v_CVarParaKhoiTao.Form = this;

            UI.Helper.VarData.CRunFunctions.RunFunctions(v_CVarParaKhoiTao);
        }

        private void acc_item_TaiSanTheChap_Click(object sender, EventArgs e)
        {
            frm_M_BankApproved frm = new frm_M_BankApproved();
            frm.ShowDialog();
        }
    }
}
