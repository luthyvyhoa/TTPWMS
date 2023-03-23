using Common.Controls;
using DA;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Helper;
using UI.ReportFile;
using UI.WarehouseManagement;
using log4net;
using DevExpress.XtraEditors;
using DevExpress.CodeParser;

namespace UI.ReportForm
{
    public partial class frm_BR_BillingSummaryByCustomer : frmBaseForm
    {
        /// <summary>
        /// The logger
        /// </summary>
        private static ILog logger = LogManager.GetLogger(typeof(frm_BR_BillingSummaryByCustomer));

        private DataProcess<ServicesDefinition> servicesDefinitionDataProcess = new DataProcess<ServicesDefinition>();
        private DataProcess<Customers> customersDataProcess = new DataProcess<Customers>();
        private DataProcess<STOtherServiceViewByService_Result> serviceDP = new DataProcess<STOtherServiceViewByService_Result>();
        private List<Customers> fullCustomerList = AppSetting.CustomerList.ToList();
        private int customerID;
        private rptOtherServiceViewByService _rptAllServices;
        private DataProcess<STBillingByOvertimeReport_Result> overTimeDP = new DataProcess<STBillingByOvertimeReport_Result>();
        public frm_BR_BillingSummaryByCustomer()
        {
            InitializeComponent();

            InitData();
        }

        private void InitData()
        {
            SetDefaultValueForDateEdit();
            InitDataForLookupEdit(fullCustomerList);
            //InitDataForGrid();
        }

        public int CustomerID
        {
            get
            {
                return customerID;
            }

            set
            {
                customerID = value;
            }
        }

        private void InitDataForLookupEdit(IList<Customers> list)
        {
            // Set items data for lkeCustomerID
            lkeCustomerID.Properties.DataSource = list;
        }

        private void InitDataForGrid()
        {
            int serviceID = 0;
            string queryString = string.Empty;
            
            if (this.lkeServiceID.EditValue != null)
            {
                serviceID = Convert.ToInt32(this.lkeServiceID.EditValue);
                queryString = "ST_WMS_LoadBillingOtherServices '" + Convert.ToDateTime(dtFromDate.EditValue).ToString("yyyy-MM-dd") + "','"
                            + Convert.ToDateTime(dtToDate.EditValue).ToString("yyyy-MM-dd") + "'," + Convert.ToInt32(lkeCustomerID.EditValue) + "," + serviceID;

            }
            else
            {
                queryString = "ST_WMS_LoadBillingOtherServices '" + Convert.ToDateTime(dtFromDate.EditValue).ToString("yyyy-MM-dd") + "','"
            + Convert.ToDateTime(dtToDate.EditValue).ToString("yyyy-MM-dd") + "'," + Convert.ToInt32(lkeCustomerID.EditValue);

            }

            //var dataSource = FileProcess.LoadTable(queryString);
            grdBillingSummaryByCustomer.DataSource = FileProcess.LoadTable(queryString);

        }

        private void SetDefaultValueForDateEdit()
        {
            var now = DateTime.Now;
            dtFromDate.EditValue = now.AddMonths(-2);
            dtToDate.EditValue = now;
        }

        private void lkeServiceID_EditValueChanged(object sender, EventArgs e)
        {
            int serviceID = Convert.ToInt32(lkeServiceID.EditValue);
            txtServiceName.Text = servicesDefinitionDataProcess.Select(s => s.ServiceID == serviceID).FirstOrDefault().ServiceName;
            this.InitDataForGrid();
        }

        private void frm_BR_BillingSummaryByCustomer_Load(object sender, EventArgs e)
        {
            lkeCustomerID.EditValue = customerID;
        }

        private void rpi_btn_View_Click(object sender, EventArgs e)
        {
            int index = grvBillingSummaryByCustomer.FocusedRowHandle;
            // DoCmd.OpenForm "frmOtherservices", acNormal, , "OtherserviceID = " & Me.TextOtherServiceID
            frm_BR_OtherServices otherServicesForm = new frm_BR_OtherServices();
            int otherServicesID = Convert.ToInt32(grvBillingSummaryByCustomer.GetRowCellValue(index, "OtherServiceID"));
            otherServicesForm.OtherServiceIDFind = otherServicesID;
            otherServicesForm.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDetailReport_Click(object sender, EventArgs e)
        {
            // DoCmd.OpenReport "rptBillingDetailPeriodByCustomer", acViewPreview
            DateTime fromDate = Convert.ToDateTime(dtFromDate.EditValue);
            DateTime toDate = Convert.ToDateTime(dtToDate.EditValue);
            int _serviceID = Convert.ToInt32(lkeServiceID.EditValue);
            int employeeID = AppSetting.CurrentUser.EmployeeID;
            int customerID = Convert.ToInt32(lkeCustomerID.EditValue);
            DataProcess<Employees> dataProcess = new DataProcess<Employees>();
            DataProcess<Customers> customersDataProcess = new DataProcess<Customers>();
            Employees currentUser = dataProcess.Select(em => em.EmployeeID == employeeID).FirstOrDefault();
            Customers customer = customersDataProcess.Select(c => c.CustomerID == customerID).FirstOrDefault();
            rptBillingDetailPeriodByCustomer rpt = new rptBillingDetailPeriodByCustomer(fromDate, toDate, customer, currentUser);
            CalculateSummaryFieldForReport(rpt);
            // rpt.DataSource = resultList;
            ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
            tool.ShowPreview();
        }

        private void btnViewConfirmations_Click(object sender, EventArgs e)
        {
            if (lkeCustomerID.EditValue == null)
            {
                return;
            }
            int customerID = Convert.ToInt32(lkeCustomerID.EditValue);
            frm_BR_BillingConfirmations confirmationForm = new frm_BR_BillingConfirmations(-1, customerID);
            //confirmationForm.CustomerIDFind = customerID;
            confirmationForm.Show();
        }

        private void btnViewHandlingsOvertimes_Click(object sender, EventArgs e)
        {
            if (lkeCustomerID.EditValue == null)
            {
                lkeCustomerID.Focus();
                lkeCustomerID.ShowPopup();
            }
            else
            {
                // CurrentDb.QueryDefs("qryOtherServiceHWByOvertimes").sql = "STBillingByOvertimeReport " & Me.ComboCustomerID & ",'" & Format(Me.TextFromDate, "yyyy-MM-dd") & "', '" & Format(Me.TextTodate, "yyyy-MM-dd") & "'"
                // Execute store STBillingByOvertimeReport
                int customerID = Convert.ToInt32(lkeCustomerID.EditValue);
                DateTime from = Convert.ToDateTime(dtFromDate.EditValue);
                DateTime to = Convert.ToDateTime(dtToDate.EditValue);
                IList<STBillingByOvertimeReport_Result> list = overTimeDP.Executing("STBillingByOvertimeReport @CustomerID = {0}, @FromDate = {1}, @ToDate = {2}", customerID, from, to).ToList();
                // DoCmd.OpenReport "rptOtherServiceHWByOvertimes", acViewPreview
                rptOtherServiceHWByOvertimes rpt = new rptOtherServiceHWByOvertimes(1);
                rpt.DataSource = list;
                ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
                tool.ShowPreview();
            }
        }

        private void btnViewAllHandlingsDataRaw_Click(object sender, EventArgs e)
        {
            if (lkeCustomerID.EditValue == null)
            {
                lkeCustomerID.Focus();
                lkeCustomerID.ShowPopup();
            }
            else
            {
                // CurrentDb.QueryDefs("qryOtherServiceHWByOvertimes").sql = "STBillingByOvertimeReport " & Me.ComboCustomerID & ",'" & Format(Me.TextFromDate, "yyyy-MM-dd") & "', '" & Format(Me.TextTodate, "yyyy-MM-dd") & "',0"
                // Execute store STBillingByOvertimeReport
                int customerID = Convert.ToInt32(lkeCustomerID.EditValue);
                DateTime from = Convert.ToDateTime(dtFromDate.EditValue);
                DateTime to = Convert.ToDateTime(dtToDate.EditValue);
                var list = FileProcess.LoadTable("STBillingByOvertimeReport @CustomerID = " + customerID + ", @FromDate = '" + from.ToString("yyyy-MM-dd")
                    + "', @ToDate = '" + to.ToString("yyyy-MM-dd") + "', @Flag = 0");
                foreach (DataRow item in list.Rows)
                {
                    if (item["CustomerClientName"] == null)
                    {
                        if (Convert.ToString(item["OrderType"]) == "RO")
                        {
                            item["CustomerClientName"] = "";
                        }
                        else
                        {
                            item["CustomerClientName"] = "Client is not specified";
                        }
                    }
                }
                // DoCmd.OpenQuery "qryOtherServiceHWByOvertimes", acViewNormal
                frm_BR_qryOtherServiceHWByOvertimes form = new frm_BR_qryOtherServiceHWByOvertimes(list);
                form.Show();
            }
        }

        private void btnViewAllHandlingsReport_Click(object sender, EventArgs e)
        {
            if (lkeCustomerID.EditValue == null)
            {
                lkeCustomerID.Focus();
                lkeCustomerID.ShowPopup();
            }
            else
            {
                // CurrentDb.QueryDefs("qryOtherServiceHWByOvertimes").sql = "STBillingByOvertimeReport " & Me.ComboCustomerID & ",'" & Format(Me.TextFromDate, "yyyy-MM-dd") & "', '" & Format(Me.TextTodate, "yyyy-MM-dd") & "',0"
                // Execute store STBillingByOvertimeReport
                int customerID = Convert.ToInt32(lkeCustomerID.EditValue);
                DateTime from = Convert.ToDateTime(dtFromDate.EditValue);
                DateTime to = Convert.ToDateTime(dtToDate.EditValue);
                IList<STBillingByOvertimeReport_Result> list = overTimeDP.Executing("STBillingByOvertimeReport @CustomerID = {0}, @FromDate = {1}, @ToDate = {2}, @Flag = {3}", customerID, from.Date.ToString("yyyy-MM-dd"), to.Date.ToString("yyyy-MM-dd"), false).ToList();
                // DoCmd.OpenReport "rptOtherServiceHWByOvertimes", acViewPreview
                rptOtherServiceHWByOvertimes rpt = new rptOtherServiceHWByOvertimes(0);
                rpt.DataSource = list;
                ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
                tool.ShowPreview();
            }
        }

        private void btnViewByService_Click(object sender, EventArgs e)
        {
            IList<STOtherServiceViewByService_Result> resultList;
            if (lkeCustomerID.EditValue == null)
            {
                // If Not IsNull(Me.ComboServiceID) And Me.ComboCustomerID <> "" Then : FIXME - Consider this line?
                if (lkeServiceID.EditValue != null)
                {
                    // CurrentDb.QueryDefs("_qry_SelectedResults").sql = "STOtherServiceViewByService " & Me.ComboServiceID & ",'" & Format(Me.TextFromDate, "yyyy-MM-dd") & "','" & Format(Me.TextTodate, "yyyy-MM-dd") & "'"
                    // Execute STOtherServiceViewByService
                    int serviceID = Convert.ToInt32(lkeServiceID.EditValue);
                    DateTime from = Convert.ToDateTime(dtFromDate.EditValue);
                    DateTime to = Convert.ToDateTime(dtToDate.EditValue);
                    resultList = serviceDP.Executing("STOtherServiceViewByService @ServiceID = {0}, @FromDate = {1}, @Todate = {2}", serviceID, from, to).ToList();
                }
                else
                {
                    return;
                }
            }
            else
            {
                if (lkeServiceID.EditValue != null)
                {
                    // CurrentDb.QueryDefs("_qry_SelectedResults").sql = "STOtherServiceViewByService " & Me.ComboServiceID & ",'" & Format(Me.TextFromDate, "yyyy-MM-dd") & "','" & Format(Me.TextTodate, "yyyy-MM-dd") & "', " & Me.ComboCustomerID
                    // Execute STOtherServiceViewByService
                    int serviceID = Convert.ToInt32(lkeServiceID.EditValue);
                    int customerID = Convert.ToInt32(lkeCustomerID.EditValue);
                    DateTime from = Convert.ToDateTime(dtFromDate.EditValue);
                    DateTime to = Convert.ToDateTime(dtToDate.EditValue);
                    resultList = serviceDP.Executing("STOtherServiceViewByService @ServiceID = {0}, @FromDate = {1}, @Todate = {2}, @CustomerID = {3}", serviceID, from, to, customerID).ToList();
                }
                else
                {
                    return;
                }
            }

            // DoCmd.OpenReport "rptOtherServiceViewByService", acViewPreview
            DateTime fromDate = Convert.ToDateTime(dtFromDate.EditValue);
            DateTime toDate = Convert.ToDateTime(dtToDate.EditValue);
            int _serviceID = Convert.ToInt32(lkeServiceID.EditValue);
            int employeeID = AppSetting.CurrentUser.EmployeeID;
            DataProcess<Employees> dataProcess = new DataProcess<Employees>();
            Employees currentUser = dataProcess.Select(em => em.EmployeeID == employeeID).FirstOrDefault();
            string fullName = "unknown";
            if (currentUser != null)
            {
                fullName = currentUser.VietnamName;
            }
            ServicesDefinition service = servicesDefinitionDataProcess.Select(s => s.ServiceID == _serviceID).FirstOrDefault();
            rptOtherServiceViewByService rpt = new rptOtherServiceViewByService(fromDate, toDate, service, fullName);
            rpt.DataSource = resultList;
            CalculateSummaryFieldForReport(rpt);
            ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
            tool.ShowPreview();
        }

        private void CalculateSummaryFieldForReport(XtraReport report)
        {
            CalculatedField sumQuantity = new CalculatedField();
            sumQuantity.DataSource = report.DataSource;
            sumQuantity.DataMember = report.DataMember;
            sumQuantity.DisplayName = "sumQuantity";
            sumQuantity.Name = "sumQuantity";
            sumQuantity.Expression = "Sum([Quantity])";

            report.CalculatedFields.Add(sumQuantity);
        }

        private void dtFromDate_EditValueChanged(object sender, EventArgs e)
        {
            // Me.subfrmBillingSummaryByCustomer.Requery
            InitDataForGrid();
        }

        private void dtToDate_EditValueChanged(object sender, EventArgs e)
        {
            // Me.subfrmBillingSummaryByCustomer.Requery
            InitDataForGrid();
        }

        private void grvBillingSummaryByCustomer_CustomDrawFooter(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            e.Handled = true;
            //e.Appearance.BackColor = Color.DarkCyan;
            e.Appearance.DrawBackground(e.Cache, e.Bounds);
            e.Appearance.ForeColor = Color.Yellow;
        }

        private void rph_OrderID_Click(object sender, EventArgs e)
        {
            string orderNumber = Convert.ToString(this.grvBillingSummaryByCustomer.GetFocusedRowCellValue("OrderNumber"));
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

        private void lkeCustomerID_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            try
            {
                if (e.Value == null) return;
                this.lkeCustomerID.EditValue = e.Value;
                var customerId = Convert.ToInt32(this.lkeCustomerID.EditValue);
                var customerInfo = customersDataProcess.Select(c => c.CustomerID == customerId)?.FirstOrDefault();
                if (customerInfo != null)
                {
                    var lkeDataSource = FileProcess.LoadTable("STServiceExistInBillByCustomerID @CustomerID=" + this.lkeCustomerID.EditValue);

                    this.ExecuteOnUIThread(() =>
                    {
                        // Update customer textbox and Set items data for lkeServiceID
                        this.txtCustomerName.Text = customerInfo.CustomerName;
                        this.lkeServiceID.Properties.DataSource = lkeDataSource;
                    });

                    // load data for DataGrid
                    this.InitDataForGrid();
                }
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("lkeCustomerID_EditValueChanged - Error occur when load customer data.", ex);
            }
        }

        private void btnViewAllServiceReport_Click(object sender, EventArgs e)
        {
            string fromD = this.dtFromDate.DateTime.ToString("yyyy MMM dd");
            string toD = this.dtToDate.DateTime.ToString("yyyy MMM dd");
            int cusID = Convert.ToInt32(this.lkeCustomerID.EditValue);
            this._rptAllServices = new rptOtherServiceViewByService(this.dtFromDate.DateTime, this.dtToDate.DateTime, cusID, this.lkeCustomerID.Text, this.txtCustomerName.Text);
            this._rptAllServices.DataSource = FileProcess.LoadTable("ST_WMS_LoadOtherServiceByCustomer " + cusID.ToString() + ",'" + fromD + "','" + toD + "',0");
            
        }

        private void InitReportAllServices()
        {
            string fromD = this.dtFromDate.DateTime.ToString("yyyy MMM dd");
            string toD = this.dtToDate.DateTime.ToString("yyyy MMM dd");
            int cusID = Convert.ToInt32(this.lkeCustomerID.EditValue);
            this._rptAllServices = new rptOtherServiceViewByService(this.dtFromDate.DateTime, this.dtToDate.DateTime, cusID, this.lkeCustomerID.Text, this.txtCustomerName.Text);
            this._rptAllServices.DataSource = FileProcess.LoadTable("ST_WMS_LoadOtherServiceByCustomer " + cusID.ToString() + ",'" + fromD + "','" + toD + "',0");
            ReportPrintToolWMS tool = new ReportPrintToolWMS(this._rptAllServices);
            tool.ShowPreview();
        }

        private void rph_OtherServiceID_Click(object sender, EventArgs e)
        {
            //Open form Other Services
            frm_BR_OtherServices frm = new frm_BR_OtherServices(Convert.ToInt32(this.grvBillingSummaryByCustomer.GetFocusedRowCellValue("OtherServiceID")));
            frm.Show();
            frm.WindowState = FormWindowState.Normal;
        }

        private void Args_Showing(object sender, XtraMessageShowingArgs e)
        {
            foreach (var control in e.Form.Controls)
            {
                SimpleButton button = control as SimpleButton;
                if (button != null)
                {
                    switch (button.DialogResult.ToString())
                    {
                        case ("OK"):
                            button.Text = "NET";
                            button.Font = new Font(button.Font, FontStyle.Bold);
                            button.Click += (ss, ee) => {
                                int customerID = Convert.ToInt32(lkeCustomerID.EditValue);
                                DateTime from = Convert.ToDateTime(dtFromDate.EditValue);
                                DateTime to = Convert.ToDateTime(dtToDate.EditValue);
                                rptStockMovementByPeriod rptpalletreport = new rptStockMovementByPeriod();
                                var dataSource= FileProcess.LoadTable("STBillingRun1CustomerPalletReports @varCustomerID = " + customerID + ", @varFromDate = '" + from.Date.ToString("yyyy-MM-dd") + "',@varTodate =  '" + to.Date.ToString("yyyy-MM-dd") + "'");
                                rptpalletreport.DataSource = dataSource.Select("CustomerNumber='" + this.lkeCustomerID.Text + "'").CopyToDataTable();
                                ReportPrintToolWMS tool = new ReportPrintToolWMS(rptpalletreport);
                                tool.ShowPreview();
                            };
                            break;
                        case ("Cancel"):
                            button.Text = "GROSS";
                            button.Font = new Font(button.Font, FontStyle.Bold);
                            button.Click += (ss, ee) => {
                                int customerID = Convert.ToInt32(lkeCustomerID.EditValue);
                                DateTime from = Convert.ToDateTime(dtFromDate.EditValue);
                                DateTime to = Convert.ToDateTime(dtToDate.EditValue);

                                rptStockMovementByPeriodGross rptpalletreport = new rptStockMovementByPeriodGross();
                                var dataSource = FileProcess.LoadTable("STBillingRun1CustomerPalletReports @varCustomerID = " + customerID + ", @varFromDate = '" + from.Date.ToString("yyyy-MM-dd") + "',@varTodate =  '" + to.Date.ToString("yyyy-MM-dd") + "'");
                                rptpalletreport.DataSource = dataSource.Select("CustomerNumber='" + this.lkeCustomerID.Text + "'").CopyToDataTable();
                                ReportPrintToolWMS tool = new ReportPrintToolWMS(rptpalletreport);
                                tool.ShowPreview();
                            };
                            break;
                        case ("Abort"):
                            button.Text = "Không";
                            button.Font = new Font(button.Font, FontStyle.Bold);
                            button.Click += (ss, ee) => {
                                int customerID = Convert.ToInt32(lkeCustomerID.EditValue);
                                DateTime from = Convert.ToDateTime(dtFromDate.EditValue);
                                DateTime to = Convert.ToDateTime(dtToDate.EditValue);

                                rptStockMovementByPeriodAll rptpalletreport = new rptStockMovementByPeriodAll();
                                var dataSource = FileProcess.LoadTable("STBillingRun1CustomerPalletReports @varCustomerID = " + customerID + ", @varFromDate = '" + from.Date.ToString("yyyy-MM-dd") + "',@varTodate =  '" + to.Date.ToString("yyyy-MM-dd") + "'");
                                rptpalletreport.DataSource = dataSource.Select("CustomerNumber='" + this.lkeCustomerID.Text + "'").CopyToDataTable();
                                ReportPrintToolWMS tool = new ReportPrintToolWMS(rptpalletreport);
                                tool.ShowPreview();
                            };
                            break;

                    }
                }
            }
        }

        private void btnBillingPalletReport_Click(object sender, EventArgs e)
        {
            if (lkeCustomerID.Text == "" )
            {
                lkeCustomerID.Focus();
                lkeCustomerID.ShowPopup();
                XtraMessageBox.Show("No customers selected!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                args.Caption = "Thông báo";
                args.Text = "Bạn có muốn lọc report theo NET/GROSS ?";
                args.Buttons = new DialogResult[] { DialogResult.OK, DialogResult.Cancel, DialogResult.Abort };
                args.Showing += Args_Showing;
                XtraMessageBox.Show(args).ToString();

                //int customerID = Convert.ToInt32(lkeCustomerID.EditValue);
                //DateTime from = Convert.ToDateTime(dtFromDate.EditValue);
                //DateTime to = Convert.ToDateTime(dtToDate.EditValue);
                //rptStockMovementByPeriod rptpalletreport = new rptStockMovementByPeriod();
                //rptpalletreport.DataSource = FileProcess.LoadTable("STBillingRun1CustomerPalletReports @varCustomerID = " + customerID + ", @varFromDate = '" + from.Date.ToString("yyyy-MM-dd") + "',@varTodate =  '" + to.Date.ToString("yyyy-MM-dd") + "'");
                //ReportPrintToolWMS tool = new ReportPrintToolWMS(rptpalletreport);
                //tool.ShowPreview();
            }

        }
    }
}
