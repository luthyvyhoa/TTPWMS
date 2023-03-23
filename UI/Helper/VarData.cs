using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Helper
{
    public class VarData
    {
        public class CRunFunctions
        {
            public static void RunFunctions(VarData.CVarParaKhoiTao i_VarParaKhoiTao)
            {
                #region MasterSystemSetup

                if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_MSS_ChangePass.ToUpper()))
                {
                    MasterSystemSetup.frm_MSS_ChangePass frm = new MasterSystemSetup.frm_MSS_ChangePass();
                    frm.Show(); frm.BringToFront();
                }
                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_MSS_CustomerEvents.ToUpper()))
                {
                    MasterSystemSetup.frm_MSS_CustomerEvents frm = new MasterSystemSetup.frm_MSS_CustomerEvents();
                    frm.Show(); frm.BringToFront();
                }
                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_MSS_CustomerRequirements.ToUpper()))
                {
                    MasterSystemSetup.frm_MSS_CustomerRequirements frm = new MasterSystemSetup.frm_MSS_CustomerRequirements();
                    frm.Show(); frm.BringToFront();
                }
                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_MSS_Customers.ToUpper()))
                {
                    MasterSystemSetup.frm_MSS_Customers frm = MasterSystemSetup.frm_MSS_Customers.Instance;
                    frm.Show(); frm.BringToFront();

                }
                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_MSS_Employees.ToUpper()))
                {
                    MasterSystemSetup.frm_MSS_Employees frm = new MasterSystemSetup.frm_MSS_Employees();
                    frm.Show(); frm.BringToFront();
                }
                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_MSS_EmployeesList.ToUpper()))
                {
                    MasterSystemSetup.frm_MSS_EmployeesList frm = new MasterSystemSetup.frm_MSS_EmployeesList();
                    frm.Show(); frm.BringToFront();
                    frm.WindowState = FormWindowState.Maximized;
                }
                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_MSS_MyCustomers.ToUpper()))
                {
                    MasterSystemSetup.frm_MSS_MyCustomers frm = new MasterSystemSetup.frm_MSS_MyCustomers();
                    frm.Show(); frm.BringToFront();
                }
                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_MSS_Office.ToUpper()))
                {
                    MasterSystemSetup.frm_MSS_Office frm = new MasterSystemSetup.frm_MSS_Office();
                    frm.Show(); frm.BringToFront();
                }
                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_MSS_Products.ToUpper()))
                {
                    MasterSystemSetup.frm_MSS_Dialog_Products_simple frm = new MasterSystemSetup.frm_MSS_Dialog_Products_simple();
                    frm.Show(); frm.BringToFront();
                }
                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_MSS_RoomSetup.ToUpper()))
                {
                    MasterSystemSetup.frm_MSS_RoomSetup frm = new MasterSystemSetup.frm_MSS_RoomSetup();
                    frm.Show(); frm.BringToFront();
                }
                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_MSS_ServicesDefinition.ToUpper()))
                {
                    MasterSystemSetup.frm_MSS_ServicesDefinition frm = new MasterSystemSetup.frm_MSS_ServicesDefinition();
                    frm.Show(); frm.BringToFront();
                }

                #endregion MasterSystemSetup
                #region WarehouseManagement

                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_WM_AirTemperatureEntry.ToUpper()))
                {
                    WarehouseManagement.frm_WM_AirTemperatureEntry frm = new WarehouseManagement.frm_WM_AirTemperatureEntry();
                    frm.Show(); frm.BringToFront();
                }

                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_WM_Assignments.ToUpper()))
                {
                    WarehouseManagement.frm_WM_Assignments frm = new WarehouseManagement.frm_WM_Assignments();
                    frm.Show(); frm.BringToFront();
                }

                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_WM_BlastFreezers.ToUpper()))
                {
                    WarehouseManagement.frm_WM_BlastFreezers frm = new WarehouseManagement.frm_WM_BlastFreezers();
                    frm.Show(); frm.BringToFront();
                }
                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_WM_BusinessTrips.ToUpper()))
                {
                    WarehouseManagement.frm_WM_BusinessTrips frm = new WarehouseManagement.frm_WM_BusinessTrips();
                    frm.Show(); frm.BringToFront();
                }
                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_WM_ConfirmationAll.ToUpper()))
                {
                    WarehouseManagement.frm_WM_ConfirmationAll frm = new WarehouseManagement.frm_WM_ConfirmationAll();
                    frm.Show(); frm.BringToFront();
                }
                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_WM_CustomerBookingView.ToUpper()))
                {
                    WarehouseManagement.frm_WM_CustomerBookingView frm = new WarehouseManagement.frm_WM_CustomerBookingView();
                    frm.Show(); frm.BringToFront();
                }
                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_WM_DailyTasks.ToUpper()))
                {
                    WarehouseManagement.frm_WM_DailyTasks frm = new WarehouseManagement.frm_WM_DailyTasks();
                    frm.Show(); frm.BringToFront();
                }
                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_WM_DeletedOrders.ToUpper()))
                {
                    WarehouseManagement.frm_WM_DeletedOrders frm = new WarehouseManagement.frm_WM_DeletedOrders();
                    frm.Show(); frm.BringToFront();
                }

                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_WM_DispatchingOrders.ToUpper()))
                {

                }
                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_WM_EDIOrders.ToUpper()))
                {
                    WarehouseManagement.frm_WM_EDIOrders frm = new WarehouseManagement.frm_WM_EDIOrders();
                    frm.Show(); frm.BringToFront();
                }
                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_WM_Find.ToUpper()))
                {
                    WarehouseManagement.frm_WM_Label frm1 = new WarehouseManagement.frm_WM_Label();
                    frm1.Show();
                    WarehouseManagement.frm_WM_Find frm = new WarehouseManagement.frm_WM_Find();
                    frm.Show(); frm.BringToFront();
                }
                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_WM_FreeLocations.ToUpper()))
                {
                    WarehouseManagement.frm_WM_FreeLocations frm = new WarehouseManagement.frm_WM_FreeLocations();
                    frm.Show(); frm.BringToFront();
                }
                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_WM_GateContInOut.ToUpper()))
                {
                    WarehouseManagement.frm_WM_GateContInOut frm = new WarehouseManagement.frm_WM_GateContInOut();
                    frm.Show(); frm.BringToFront();
                }
                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_WM_GatePropertyMovements.ToUpper()))
                {
                    WarehouseManagement.frm_WM_GatePropertyMovements frm = new WarehouseManagement.frm_WM_GatePropertyMovements();
                    frm.Show(); frm.BringToFront();
                }
                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_WM_GateTruckInOut.ToUpper()))
                {
                    WarehouseManagement.frm_WM_GateTruckInOut frm = new WarehouseManagement.frm_WM_GateTruckInOut();
                    frm.Show(); frm.BringToFront();
                }


                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_WM_MHLWorks.ToUpper()))
                {

                }
                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_WM_Notes.ToUpper()))
                {
                    WarehouseManagement.frm_WM_Notes frm = new WarehouseManagement.frm_WM_Notes();
                    frm.Show(); frm.BringToFront();
                }
                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_WM_PalletInfo.ToUpper()))
                {
                    WarehouseManagement.frm_WM_PalletInfo frm = new WarehouseManagement.frm_WM_PalletInfo();
                    frm.Show(); frm.BringToFront();
                }

                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_WM_SafetyStockWarnings.ToUpper()))
                {
                    WarehouseManagement.frm_WM_SafetyStockWarnings frm = new WarehouseManagement.frm_WM_SafetyStockWarnings();
                    frm.Show(); frm.BringToFront();
                }


                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_WM_TripViewByDate.ToUpper()))
                {
                    WarehouseManagement.frm_WM_TripViewByDate frm = new WarehouseManagement.frm_WM_TripViewByDate();
                    frm.WindowState = FormWindowState.Maximized;
                    frm.Show(); frm.BringToFront();
                }

                #endregion WarehouseManagement
                #region CRM

                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_CRM_CustomerFeedbacks.ToUpper()))
                {
                    CRM.frm_CRM_CustomerFeedbacks frm = new CRM.frm_CRM_CustomerFeedbacks();
                    frm.Show(); frm.BringToFront();
                }
                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_CRM_Opportunities.ToUpper()))
                {
                    CRM.frm_CRM_Opportunities frm = new CRM.frm_CRM_Opportunities();
                    frm.Show(); frm.BringToFront();
                }

                #endregion CRM
                #region Warehouse Report

                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_WR_StockOnHandByLotReport.ToUpper()))
                {
                    ReportForm.frm_WR_StockOnHandByLotReport frm = new ReportForm.frm_WR_StockOnHandByLotReport();
                    frm.Show(); frm.BringToFront();
                }
                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_WR_StockByLocationReport.ToUpper()))
                {
                    ReportForm.frm_WR_StockByLocationReport frm = new ReportForm.frm_WR_StockByLocationReport();
                    frm.Show(); frm.BringToFront();
                }
                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_WR_StockReceivedReport.ToUpper()))
                {
                    ReportForm.frm_WR_StockReceivedReport frm = new ReportForm.frm_WR_StockReceivedReport();
                    frm.Show(); frm.BringToFront();
                }
                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_WR_StockDispatchedReport.ToUpper()))
                {
                    ReportForm.frm_WR_StockDispatchedReport frm = new ReportForm.frm_WR_StockDispatchedReport();
                    frm.Show(); frm.BringToFront();
                }
                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_WR_StockMovementReport.ToUpper()))
                {
                    ReportForm.frm_WR_StockMovementReport frm = new ReportForm.frm_WR_StockMovementReport();
                    frm.Show(); frm.BringToFront();
                }
                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_WR_StockMovementByProductReport.ToUpper()))
                {
                    ReportForm.frm_WR_StockMovementByProductReport frm = new ReportForm.frm_WR_StockMovementByProductReport();
                    frm.Show(); frm.BringToFront();
                }
                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_WR_TaskView.ToUpper()))
                {
                    ReportForm.frm_WR_TaskView frm = new ReportForm.frm_WR_TaskView();
                    frm.Show(); frm.BringToFront();
                }
                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_WR_StockByLocationManyCustomers.ToUpper()))
                {
                    ReportForm.frm_WR_StockByLocationManyCustomers frm = new ReportForm.frm_WR_StockByLocationManyCustomers();
                    frm.Show(); frm.BringToFront();
                }
                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_WR_RackingSafetyReport.ToUpper()))
                {
                    ReportForm.frm_WR_RackingSafetyReport frm = new ReportForm.frm_WR_RackingSafetyReport();
                    frm.Show(); frm.BringToFront();
                }

                #endregion Warehouse Report
                #region Stock Take

                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_ST_IndependentCheck.ToUpper()))
                {
                    StockTake.frm_ST_IndependentCheck frm = new StockTake.frm_ST_IndependentCheck();
                    frm.Show(); frm.BringToFront();
                }
                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_ST_StockTakeDaily.ToUpper()))
                {
                    StockTake.frm_ST_StockTakeDaily frm = new StockTake.frm_ST_StockTakeDaily();
                    frm.Show(); frm.BringToFront();
                }
                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_ST_CloseStock.ToUpper()))
                {
                    StockTake.frm_ST_CloseStock frm = new StockTake.frm_ST_CloseStock();
                    frm.Show(); frm.BringToFront();
                }
                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_ST_StockTakeByRequest.ToUpper()))
                {
                    StockTake.frm_ST_StockTakeByRequest frm = new StockTake.frm_ST_StockTakeByRequest();
                    frm.Show(); frm.BringToFront();
                }

                #endregion Stock Take
                #region Billing Report

                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_BR_OtherServiceViewByService.ToUpper()))
                {
                    ReportForm.frm_BR_OtherServiceViewByService frm = new ReportForm.frm_BR_OtherServiceViewByService();
                    frm.Show(); frm.BringToFront();
                }

                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_BR_BillingSummaryByCustomer.ToUpper()))
                {
                    ReportForm.frm_BR_BillingSummaryByCustomer frm = new ReportForm.frm_BR_BillingSummaryByCustomer();
                    frm.Show(); frm.BringToFront();
                }

                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_BR_CheckChange.ToUpper()))
                {
                    ReportForm.frm_BR_CheckChange frm = new ReportForm.frm_BR_CheckChange();
                    frm.Show(); frm.BringToFront();
                }

                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_BR_BillingSummary.ToUpper()))
                {
                    ReportForm.frm_BR_BillingSummary frm = new ReportForm.frm_BR_BillingSummary();
                    frm.Show(); frm.BringToFront();
                }

                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_BR_BillingReport.ToUpper()))
                {
                    ReportForm.frm_BR_BillingReport frm = new ReportForm.frm_BR_BillingReport();
                    frm.Show(); frm.BringToFront();
                }

                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_BR_ProductTracing.ToUpper()))
                {
                    ReportForm.frm_BR_ProductTracing frm = new ReportForm.frm_BR_ProductTracing();
                    frm.Show(); frm.BringToFront();
                }

                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_BR_ContainerRunningHour.ToUpper()))
                {
                    ReportForm.frm_BR_ContainerRunningHour frm = new ReportForm.frm_BR_ContainerRunningHour();
                    frm.Show(); frm.BringToFront();
                }

                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_BR_OtherServices.ToUpper()))
                {
                    ReportForm.frm_BR_OtherServices frm = new ReportForm.frm_BR_OtherServices();
                    frm.Show(); frm.BringToFront();
                }

                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_BR_Accounting_MissingContracts.ToUpper()))
                {
                    ReportForm.frm_BR_Accounting_MissingContracts frm = new ReportForm.frm_BR_Accounting_MissingContracts();
                    frm.Show(); frm.BringToFront();
                }

                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_BR_BillingConfirmations.ToUpper()))
                {
                    ReportForm.frm_BR_BillingConfirmations frm = new ReportForm.frm_BR_BillingConfirmations();
                    frm.Show(); frm.BringToFront();
                }

                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_BR_BillingCheckBreakdown.ToUpper()))
                {
                    ReportForm.frm_BR_BillingCheckBreakdown frm = new ReportForm.frm_BR_BillingCheckBreakdown();
                    frm.Show(); frm.BringToFront();
                }

                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_BR_BillingByReceivingOrders.ToUpper()))
                {
                    ReportForm.frm_BR_BillingByReceivingOrders frm = new ReportForm.frm_BR_BillingByReceivingOrders();
                    frm.Show(); frm.BringToFront();
                }

                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_BR_BillingByDispatchingOrders.ToUpper()))
                {
                    ReportForm.frm_BR_BillingByDispatchingOrders frm = new ReportForm.frm_BR_BillingByDispatchingOrders();
                    frm.Show(); frm.BringToFront();
                }

                #endregion Billing Report
                #region Management

                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_M_SDT_ReportToCustomer.ToUpper()))
                {
                    Management.frm_M_SDT_ReportToCustomer frm = new Management.frm_M_SDT_ReportToCustomer();
                    frm.Show(); frm.BringToFront();
                }
                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_M_SDT_DifferenceCheck.ToUpper()))
                {
                    Management.frm_M_SDT_DifferenceCheck frm = new Management.frm_M_SDT_DifferenceCheck();
                    frm.Show(); frm.BringToFront();
                }
                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_M_SDT_DeleteProducts.ToUpper()))
                {
                    Management.frm_M_SDT_DeleteProducts frm = new Management.frm_M_SDT_DeleteProducts();
                    frm.Show(); frm.BringToFront();
                }
                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_M_SDT_CompactDatabase.ToUpper()))
                {
                    Management.frm_M_SDT_CompactDatabase frm = new Management.frm_M_SDT_CompactDatabase();
                    frm.Show(); frm.BringToFront();
                }
                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_M_GO_StockOnHandAllCustomer.ToUpper()))
                {
                    Management.frm_M_GO_StockOnHandAllCustomer frm = new Management.frm_M_GO_StockOnHandAllCustomer();
                    frm.Show(); frm.BringToFront();
                }
                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_M_GO_StockMovementReportAllCustomers.ToUpper()))
                {
                    Management.frm_M_GO_StockMovementReportAllCustomers frm = new Management.frm_M_GO_StockMovementReportAllCustomers();
                    frm.Show(); frm.BringToFront();
                }

                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_M_GO_StockOnHandByRoomSummary.ToUpper()))
                {
                    Management.frm_M_GO_StockOnHandByRoomSummary frm = new Management.frm_M_GO_StockOnHandByRoomSummary();
                    frm.Show(); frm.BringToFront();
                }
                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_M_DW_StockOnHandWeekyByCustomer.ToUpper()))
                {
                    Management.frm_M_DW_StockOnHandWeekyByCustomer frm = new Management.frm_M_DW_StockOnHandWeekyByCustomer();
                    frm.Show(); frm.BringToFront();
                }
                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_M_DW_StockOnHandAverage.ToUpper()))
                {
                    Management.frm_M_DW_StockOnHandAverage frm = new Management.frm_M_DW_StockOnHandAverage();
                    frm.Show(); frm.BringToFront();
                }
                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_M_DW_News.ToUpper()))
                {
                    Management.frm_M_DW_News frm = new Management.frm_M_DW_News();
                    frm.Show(); frm.BringToFront();
                }
                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_M_DW_SummaryInOutByDate.ToUpper()))
                {
                    Management.frm_M_DW_SummaryInOutByDate frm = new Management.frm_M_DW_SummaryInOutByDate();
                    frm.Show(); frm.BringToFront();
                }


                #endregion Management

                #region Supervisors

                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_S_SJTHS_EmployeeWorkingCheck.ToUpper()))
                {
                    Supperviors.frm_S_SJTHS_EmployeeWorkingCheck frm = new Supperviors.frm_S_SJTHS_EmployeeWorkingCheck();
                    frm.Show(); frm.BringToFront();
                }
                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_S_SJTHS_OrdersUnconfirm.ToUpper()))
                {
                    Supperviors.frm_S_SJTHS_OrdersUnconfirm frm = new Supperviors.frm_S_SJTHS_OrdersUnconfirm();
                    frm.Show(); frm.BringToFront();
                }
                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_S_SJTHS_StockCorrection.ToUpper()))
                {
                    Supperviors.frm_S_SJTHS_StockCorrection frm = new Supperviors.frm_S_SJTHS_StockCorrection();
                    frm.Show(); frm.BringToFront();
                }
                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_S_SJTHS_Quarantines.ToUpper()))
                {
                    Supperviors.frm_S_SJTHS_Quarantines frm = new Supperviors.frm_S_SJTHS_Quarantines();
                    frm.Show(); frm.BringToFront();
                }
                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_S_SJTHS_PropertyDamages.ToUpper()))
                {
                    Supperviors.frm_S_SJTHS_PropertyDamages frm = new Supperviors.frm_S_SJTHS_PropertyDamages();
                    frm.Show(); frm.BringToFront();
                }
                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_S_SJTHS_ProductDamages.ToUpper()))
                {
                    Supperviors.frm_S_SJTHS_ProductDamages frm = new Supperviors.frm_S_SJTHS_ProductDamages();
                    frm.Show(); frm.BringToFront();
                }
                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_S_SJTHS_OtherJobs.ToUpper()))
                {
                    Supperviors.frm_S_SJTHS_OtherJobs frm = new Supperviors.frm_S_SJTHS_OtherJobs();
                    frm.Show(); frm.BringToFront();
                }
                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_S_SJTHS_KPIRecordings.ToUpper()))
                {
                    Supperviors.frm_S_SJTHS_KPIRecordings frm = new Supperviors.frm_S_SJTHS_KPIRecordings();
                    frm.Show(); frm.BringToFront();
                }
                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_S_SJTHS_OtherJobDefinitions.ToUpper()))
                {
                    Supperviors.frm_S_SJTHS_OtherJobDefinitions frm = new Supperviors.frm_S_SJTHS_OtherJobDefinitions();
                    frm.Show(); frm.BringToFront();
                }
                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_S_SJTHS_CustomerComplains.ToUpper()))
                {
                    Supperviors.frm_S_SJTHS_CustomerComplains frm = new Supperviors.frm_S_SJTHS_CustomerComplains();
                    frm.Show(); frm.BringToFront();
                }
                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_S_SJTHS_Accidents.ToUpper()))
                {
                    Supperviors.frm_S_SJTHS_Accidents frm = new Supperviors.frm_S_SJTHS_Accidents();
                    frm.Show(); frm.BringToFront();
                }
                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_S_PCO_EmployeeReminders.ToUpper()))
                {
                    Supperviors.frm_S_PCO_EmployeeReminders frm = new Supperviors.frm_S_PCO_EmployeeReminders();
                    frm.Show(); frm.BringToFront();
                }
                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_S_PCO_EmployeeOTSupervisors.ToUpper()))
                {
                    Supperviors.frm_S_PCO_EmployeeOTSupervisors frm = new Supperviors.frm_S_PCO_EmployeeOTSupervisors();
                    frm.Show(); frm.BringToFront();
                }
                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_S_PCO_PayrollMonthlyEvaluation.ToUpper()))
                {
                    Supperviors.frm_S_PCO_PayrollMonthlyEvaluation frm = new Supperviors.frm_S_PCO_PayrollMonthlyEvaluation();
                    frm.Show(); frm.BringToFront();
                }
                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_S_PCO_EmployeeEvents.ToUpper()))
                {
                    Supperviors.frm_S_PCO_EmployeeEvents frm = new Supperviors.frm_S_PCO_EmployeeEvents();
                    frm.Show(); frm.BringToFront();
                }
                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_S_AO_InternalAudits.ToUpper()))
                {
                    Supperviors.frm_S_AO_ProblemList frm = new Supperviors.frm_S_AO_ProblemList();
                    frm.Show(); frm.BringToFront();
                    frm.WindowState = FormWindowState.Maximized;
                }
                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_S_AO_Warnings.ToUpper()))
                {
                    Supperviors.frm_S_AO_Warnings frm = new Supperviors.frm_S_AO_Warnings();
                    frm.Show(); frm.BringToFront();
                }
                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_S_AO_GateCustomerLaborSafetyTrainings.ToUpper()))
                {
                    Supperviors.frm_S_AO_GateCustomerLaborSafetyTrainings frm = new Supperviors.frm_S_AO_GateCustomerLaborSafetyTrainings();
                    frm.Show(); frm.BringToFront();
                }
                else if (i_VarParaKhoiTao.Function.ToUpper().Equals(CFunction.WMS_S_AO_TrainingPositionRequirements.ToUpper()))
                {
                    Supperviors.frm_S_AO_TrainingPositionRequirements frm = new Supperviors.frm_S_AO_TrainingPositionRequirements();
                    frm.Show(); frm.BringToFront();
                }

                #endregion Supervisors
            }

            static void frm_VisibleChanged(object sender, EventArgs e)
            {
                //   bool frmOpen = ReportForm.frm_WR_StockReceivedReport.CheckInvisibleDueShowingStrategy(frm_WR_StockReceivedReport);
            }
        }

        public class CFunction
        {
            #region MasterSystemSetup

            public const string WMS_MSS_ChangePass = "a554c7b7-079f-4e45-ac60-3ddd4fae70d9";
            public const string WMS_MSS_CustomerEvents = "6af2e6a6-c47b-4ae1-886c-fd067fb9d341";
            public const string WMS_MSS_CustomerRequirements = "0f417cf2-6811-4252-8a1b-f1edef6f8700";
            public const string WMS_MSS_Customers = "4ba8dfe2-0769-4f51-9158-e18972e9ca73";
            public const string WMS_MSS_Employees = "d9e35b28-3042-4c81-bf46-bad613dcba14";
            public const string WMS_MSS_MyCustomers = "0bc47b62-90c8-4359-9fac-418a03dce919";
            public const string WMS_MSS_Office = "50a8f3d0-3659-4c13-aa6c-c98b06efa7fd";
            public const string WMS_MSS_Products = "03018856-d4f7-4c01-bb2b-3a749bfcda7c";
            public const string WMS_MSS_RoomSetup = "5d9b7cd2-de7e-4c7b-96d7-2c73220ca9cd";
            public const string WMS_MSS_ServicesDefinition = "42b80bcd-3db5-469a-b5fa-a02589327a30";
            public const string WMS_MSS_UserAccounts = "916d97f7-e77e-4a0a-a2b0-7d3255f76aa3";

            public const string WMS_MSS_EmployeesList = "d3ca7414-7d95-466d-8620-bdb8153daa91";

            #endregion MasterSystemSetup
            #region WarehouseManagement

            public const string WMS_WM_AirTemperatureEntry = "b59c7b68-fd15-473a-aa99-b0ac1e8c167d";
            public const string WMS_WM_Assignments = "05b7e429-92cd-4e36-8566-066f8fcf4213";
            public const string WMS_WM_BlastFreezers = "79719065-9b05-40b3-bdd0-c687ad27a590";
            public const string WMS_WM_BusinessTrips = "7ee89b05-8497-4ca5-a505-4675ad536b05";
            public const string WMS_WM_ConfirmationAll = "9bcdeb2c-748d-4d82-aff4-180f98aac776";
            public const string WMS_WM_CustomerBookingView = "8eab4197-a531-4726-add2-4dc018108178";
            public const string WMS_WM_DailyTasks = "3be38515-0784-4ac4-9fd7-002ddad57d03";
            public const string WMS_WM_DeletedOrders = "8b771acb-fdb6-4e49-bb42-cfaf922ed489";
            public const string WMS_WM_DispatchingOrders = "2aadffc8-1113-4299-9875-3fc858981784";
            public const string WMS_WM_EDIOrders = "2a98228c-068b-4e3b-b817-657e79457f99";
            public const string WMS_WM_Find = "e61322ff-c0b7-48e3-824e-318885aae567";
            public const string WMS_WM_FreeLocations = "f348ab7e-fd4b-4459-9a1f-a2a81908c8cf";
            public const string WMS_WM_GateContInOut = "72713104-753e-485e-8c33-597f0c07bfa6";
            public const string WMS_WM_GatePropertyMovements = "7177e8dd-b35b-4bfb-9767-5efcea27cbdc";
            public const string WMS_WM_GateTruckInOut = "2269408f-fcf0-4d71-b486-8b3749fc7cca";
            public const string WMS_WM_InOutViewByDate = "36a0f0de-5010-48af-b6a1-ab7483d9f000";
            public const string WMS_WM_MHLWorks = "d1ee2d6b-ad82-4593-955c-5edfa4b483cd";
            public const string WMS_WM_Notes = "6ab283e6-09d6-4459-8d48-a790d1f85009";
            public const string WMS_WM_PalletInfo = "03bcc8ee-efd0-49d3-8a01-ee1a197b5f21";
            public const string WMS_WM_QualityCheckings = "01db4f8d-6699-4621-af6e-cae7b2f141e7";
            public const string WMS_WM_ReceivingOrders = "84534227-93a1-4709-b30e-45e0b4ddf159";
            public const string WMS_WM_SafetyStockWarnings = "7eaa4f05-39c5-4779-8a25-2d2f15c08357";
            public const string WMS_WM_StockMovementMassAll = "f1f27f7c-aeb9-4d1a-b46e-ed664ccef5e0";
            public const string WMS_WM_StockMovementNew = "3b95c30d-e00e-4d9a-aa11-08037631dfec";
            public const string WMS_WM_TripViewByDate = "94b12a84-d158-4cbe-b6a2-cc95d578d81e";

            #endregion WarehouseManagement
            #region CRM

            public const string WMS_CRM_CustomerFeedbacks = "fcaf8190-628f-4361-8b09-fc6f1c20e9a3";
            public const string WMS_CRM_Opportunities = "7d011e6b-bebe-407c-8e66-750b00cfd5df";

            #endregion CRM
            #region Warehouse Report

            public const string WMS_WR_RackingSafetyReport = "41bdcc82-c8f5-4629-88cb-b27dc9505915";
            public const string WMS_WR_StockByLocationManyCustomers = "e35ba4f0-f6d8-43be-882a-7e232ff22713";
            public const string WMS_WR_StockByLocationReport = "a674d2e2-8b8b-4e75-ac58-20eae4273efa";
            public const string WMS_WR_StockDispatchedReport = "4a795478-fe32-4c24-81ca-189bbd371d4e";
            public const string WMS_WR_StockMovementByProductReport = "de2fd2f3-a709-41d6-82e1-a8b0a65c8864";
            public const string WMS_WR_StockMovementReport = "3378dae3-836a-44da-82fb-93087001eece";
            public const string WMS_WR_StockOnHandByLotReport = "2fe7baf8-af3d-466f-8b4d-1b279eea3c19";
            public const string WMS_WR_StockReceivedReport = "571e0492-8f22-4a37-b677-49f6cf259211";
            public const string WMS_WR_TaskView = "819a15ac-e490-4a4e-8d19-fcc18c7f31ef";

            #endregion Warehouse Report
            #region Stock Take

            public const string WMS_ST_CloseStock = "0e128994-c1dc-40a5-bb8e-17425c38c75e";
            public const string WMS_ST_IndependentCheck = "75ce8568-2666-4a26-8617-659aaa7feff3";
            public const string WMS_ST_StockTakeByRequest = "c70cc5e1-7a94-4031-8a28-1dfec6a53d0c";
            public const string WMS_ST_StockTakeDaily = "4c2fc025-2320-4376-b849-8d69563143fa";//	

            #endregion Stock Take
            #region Billing Report

            public const string WMS_BR_Accounting_MissingContracts = "5652fac7-18c9-47d7-b2ee-33bc5f9cfe14";
            public const string WMS_BR_BillingByDispatchingOrders = "a5f06dba-77f2-4e9c-8f05-92dbea391003";
            public const string WMS_BR_BillingByReceivingOrders = "d5108c01-8aea-4ccf-adbd-bf140506e114";
            public const string WMS_BR_BillingCheckBreakdown = "fde02354-b755-438f-bae9-34d607417a9f";
            public const string WMS_BR_BillingConfirmations = "0b909f10-d64b-4e35-96d9-701224aaf709";
            public const string WMS_BR_BillingReport = "107f5cde-db31-4203-8f34-ab20aebd6ffa";
            public const string WMS_BR_BillingSummary = "e0d7fcaf-8006-465c-8331-5490c56e7d05";
            public const string WMS_BR_BillingSummaryByCustomer = "d7f1345b-c02a-4e5c-ab7d-746ff83027d9";
            public const string WMS_BR_CheckChange = "059dda26-7540-431c-9eae-bc67419d3371";
            public const string WMS_BR_ContainerRunningHour = "7b4f05bd-4388-415c-81ee-c9bf017c1e86";
            public const string WMS_BR_OtherServices = "e7f1345b-c02a-4e5c-ab7d-746ff83027d9";
            public const string WMS_BR_OtherServiceViewByService = "c81a25e1-3ea7-436d-88b8-6988df021dbb";
            public const string WMS_BR_ProductTracing = "3ee6df44-d889-481b-8608-255db46d8f3c";

            #endregion Billing Report
            #region Management

            public const string WMS_M_DW_News = "47e0d934-2976-4462-8701-1cf920c27383";
            public const string WMS_M_DW_StockOnHandAverage = "35117607-7ec2-418f-89a5-ea19019449ad";
            public const string WMS_M_DW_StockOnHandWeekyByCustomer = "10f43ab0-4af2-4684-9082-c4f9e94f8ac1";
            public const string WMS_M_DW_SummaryInOutByDate = "01659715-54bc-428d-8152-67aec09fc3f7";
            public const string WMS_M_GO_Contracts = "422a7934-6e17-4141-8ecc-e2e622ca836e";
            public const string WMS_M_GO_EmployeeWorkingCheck = "f7d0dd6b-ac8c-4b09-8860-b3bffaf5429b";
            public const string WMS_M_GO_StockMovementReportAllCustomers = "1961aa15-e505-46f7-9850-151ff5f4bab0";
            public const string WMS_M_GO_StockOnHandAllCustomer = "d89258cd-5cf2-4b2c-8066-369c3ae63397";
            public const string WMS_M_GO_StockOnHandByRoomSummary = "62d60bc2-4a14-4508-b74b-012dce101765";
            public const string WMS_M_GO_EmployeeWorkingProductionCheck = "58a4a066-c178-41e6-b513-1a9154a8969e";
            public const string WMS_M_SDT_CompactDatabase = "ac68628a-85b6-45a0-8af9-abab85bf7a07";
            public const string WMS_M_SDT_DeleteProducts = "846f9971-41a8-4261-aa06-9b2689ce11ec";
            public const string WMS_M_SDT_DifferenceCheck = "d699a848-f176-4e27-840c-58841af84e09";
            public const string WMS_M_SDT_ReportToCustomer = "800b6b3e-ce45-4bad-95af-9ee696810e85";


            #endregion Management
            #region Supervisors

            public const string WMS_S_AO_GateCustomerLaborSafetyTrainings = "0714a2c6-7fa1-4b2c-82e0-63a533b834ae";
            public const string WMS_S_AO_InternalAudits = "1f878554-8715-49fd-a680-e616fd56fd71";
            public const string WMS_S_AO_TrainingPositionRequirements = "5f73863a-b79e-407c-a22d-49c374afacbc";
            public const string WMS_S_AO_Warnings = "38532b07-0f04-4d90-a2c3-76403a6d8c98";
            public const string WMS_S_PCO_EmployeeEvents = "700a72a9-ae1f-4c8a-bf4c-e5c08b13e86b";
            public const string WMS_S_PCO_EmployeeOTSupervisors = "373c0746-1890-4b4a-8b3b-a41ec8396fd2";
            public const string WMS_S_PCO_EmployeeReminders = "0c09d311-2688-4be2-81a9-980fdfb1a996";
            public const string WMS_S_PCO_PayrollMonthlyEvaluation = "64b7d8b2-9c43-4523-a103-67492201813f";
            public const string WMS_S_SJTHS_Accidents = "b231f6db-b1a9-46c4-a22b-cae50a4edf7c";
            public const string WMS_S_SJTHS_CustomerComplains = "062fd229-0140-4dcc-9b4c-267acfa4b1c8";
            public const string WMS_S_SJTHS_EmployeeWorkingCheck = "ff76d1e1-0380-4cf9-8539-267d015a5933";
            public const string WMS_S_SJTHS_KPIRecordings = "489adcae-e2f5-4867-8a5f-e02129d25b7c";
            public const string WMS_S_SJTHS_OrdersUnconfirm = "174f6039-757b-433a-bf2b-a7aaccd2841d";
            public const string WMS_S_SJTHS_OtherJobDefinitions = "240742f4-9e31-4222-a30f-41aef1db76aa";
            public const string WMS_S_SJTHS_OtherJobs = "2a4f8440-562e-44a3-a22e-d1f5f4750cd4";
            public const string WMS_S_SJTHS_ProductDamages = "bbb6145f-734a-4e38-a99f-8002a689eb16";
            public const string WMS_S_SJTHS_PropertyDamages = "859128db-3773-461e-accc-027edb893b1d";
            public const string WMS_S_SJTHS_Quarantines = "4ee37cad-3418-4c95-b0db-0f1aa06ad04a";
            public const string WMS_S_SJTHS_StockCorrection = "8b3bfe8c-c6a4-483c-938d-4749731eb4e0";

            #endregion Supervisors
        }

        public class CVarParaKhoiTao
        {
            public string Project = "";
            public string Module = "";
            public string Function = "";
            public string PK_IDReport = "";


            public string PK_IDNhuCau = "";
            public int TypeNhuCau = 0;

            public string PK_IDPhieuBaoMau = "";

            public string PK_IDHopDongLoai = "";
            public string PK_IDHopDong = "";

            public string PK_IDPDNLoai = "";
            public string PK_IDPDN = "";

            public string PK_IDDMMatHang = "";
            public string DMMatHang_Code = "";
            public string DMMatHang_Name = "";
            public string DMMatHang_DVT = "";

            public string PK_IDDMDoiTuong = "";
            public string PK_IDDoiTuongNo = "";
            public string PK_IDDoiTuongCo = "";
            public string DMDoiTuong_Code = "";
            public string DMDoiTuong_Name = "";
            public string DoiTuongNo_Code = "";
            public string DoiTuongNo_Name = "";
            public string DoiTuongCo_Code = "";
            public string DoiTuongCo_Name = "";

            public string PK_IDPNXKieu = "";
            public string PK_IDPNXLoai = "";
            public string PK_IDPNX = "";
            public string DMLoaiPNX_Code = "";
            public string DMLoaiPNX_Name = "";

            public string NguoiNhan = "";
            public string NguoiGiao = "";

            public string NguoiLap = "";
            public string NoiDung = "";

            public string PK_IDKCS = "";
            public string KCS_Code = "";

            public string PK_IDDinhMuc = "";
            public int TypeDinhMuc = 0;

            public string PK_IDDinhMuc_NL = "";
            public string DinhMuc_NL_Code = "";
            public string DinhMuc_NL_Name = "";

            public string PK_IDDinhMuc_PL = "";
            public string DinhMuc_PL_Code = "";
            public string DinhMuc_PL_Name = "";

            public string PK_IDDinhMuc_HC = "";
            public string DinhMuc_HC_Code = "";
            public string DinhMuc_HC_Name = "";

            public string PK_IDLSX = "";
            public object LSX_SoLuong;
            public string LSX_Code = "";
            public string LoaiLSX_Name = "";

            public string PK_IDMe = "";
            public string Me_Code = "";
            public string Me_Code_Text = "";

            public string TypeObject = "";
            public string ChamCong_Group = "";

            public string PK_IDLanBanHanh = "";
            public string LanBanHanh_Code = "";
            public object LanBanHanh_SoLuong;

            public bool IsSearchLanBanhanh = false;

            public int TypeLSX = 0;
            public int LoaiLSX = 0;
            public int TypeChamCong = 0;

            public string PK_IDKHSX = "";
            public string KHSX_Code = "";

            public string PK_IDKHSXDot = "";
            public string KHSXDot_Code = "";

            public string PK_IDKHSXLoai = "";
            public string KHSXLoai_Code = "";

            public int LoaiHoaDonChungTu = 0;

            public bool IsShowDialog = false;
            public System.Windows.Forms.IWin32Window Owner = null;
            public System.Windows.Forms.Form Form = null;

            public string GioiHanData = "";
            public int TypeSearch = 0;
            public string Code = "";
            public string Name = "";
            public string PK_IDHeader = "";
            public string PK_ID = "";

            public string TypeDada = "";

            public string Object = "";
            public object ThemDong = 0;
            public object ThemDongDuoi = 0;

            public object PathA4 = "";
            public object PathA5 = "";
            public bool InAll = false;

            public bool IsSearch = false;

            public string PK_IDNguyenNhanHuyHoaDon = "";
            public string PK_IDHoaDonHuy = "";

            public int TypeInherit = 0;
            public int TypeCachNhuom = 0;

            public string FormText = "";
            public string PhongBan = "";

            public object PK_IDDMHoaDon_MauSo = "";
            public object PK_IDDMHoaDon_KyHieu = "";

            public DateTime Date_From = DateTime.Now;
            public DateTime Date_To = DateTime.Now;
            public DateTime Date_NgayLap = DateTime.Now;
            public DateTime Date_BaoCao = DateTime.Now;


        }
    }

}
