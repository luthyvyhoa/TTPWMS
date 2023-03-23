using Common.Controls;
using DA;
using DevExpress.XtraEditors;
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
using UI.Management;
using UI.ReportFile;
using UI.WarehouseManagement;

namespace UI.ReportForm
{
    public partial class frm_BR_OtherServiceViewByService : frmBaseForm
    {
        private frm_WM_TripsManagement frmTrip = null;
        private DataProcess<ServicesDefinition> servicesDefinitionDataProcess = new DataProcess<ServicesDefinition>();
        //private DataProcess<STOtherServiceViewByService_Result> otherServiceViewByServiceDataProcess = new DataProcess<STOtherServiceViewByService_Result>();
        //private IList<STOtherServiceViewByService_Result> currentList;
        public frm_BR_OtherServiceViewByService()
        {
            InitializeComponent();
            SetDefaultValueForDateEdit();
            SQL_Refresh();
        }


        private void SetDefaultValueForDateEdit()
        {
            dtFromDate.EditValue = DateTime.Now.AddDays(-30);
            dtToDate.EditValue = DateTime.Now;
        }


        private void btnViewReport_Click(object sender, EventArgs e)
        {
            //SQL_Refresh();
            //// DoCmd.OpenReport "rptOtherServiceViewByService", acViewPreview
            //DateTime fromDate = Convert.ToDateTime(dtFromDate.EditValue);
            //DateTime toDate = Convert.ToDateTime(dtToDate.EditValue);
            //int _serviceID = Convert.ToInt32(this.grvOtherServiceViewByService.GetFocusedRowCellValue("ServiceID").ToString() );
            
            //string fullName = AppSetting.CurrentUser.VietnamName;
            
            //ServicesDefinition service = servicesDefinitionDataProcess.Select(s => s.ServiceID == _serviceID).FirstOrDefault();

            //rptOtherServiceViewByService rpt = new rptOtherServiceViewByService(fromDate, toDate, service, fullName);
            //rpt.DataSource = FileProcess.LoadTable("ST_WMS_LoadOtherServiceList  " + AppSetting.StoreID.ToString() + ",'" + fromDate + "','" + toDate + "'," + _serviceID); ;
            //CalculateSummaryFieldForReport(rpt);
            //ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
            //tool.ShowPreview();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rpi_btn_View_Click(object sender, EventArgs e)
        {
            int index = grvOtherServiceViewByService.FocusedRowHandle;
            // DoCmd.OpenForm "frmOtherservices", acNormal, , "OtherserviceID = " & Me.TextOtherServiceID
            frm_BR_OtherServices otherServicesForm = new frm_BR_OtherServices();
            int otherServicesID = Convert.ToInt32(grvOtherServiceViewByService.GetRowCellValue(index, "OtherServiceID"));
            otherServicesForm.OtherServiceIDFind = otherServicesID;
            otherServicesForm.Show();
        }

        
        private void SQL_Refresh()
        {
            // CurrentDb.QueryDefs("_qry_SelectedResults").sql = "STOtherServiceViewByService " & Me.ComboServiceID & ",'" & Format(Me.TextFromDate, "yyyy-MM-dd") & "','" & Format(Me.TextTodate, "yyyy-MM-dd") & "'"
            // Execute store STOtherServiceViewByService
            if (dtFromDate.EditValue == null || dtToDate.EditValue == null)
            {
                return;
            }
            string fromDate = dtFromDate.DateTime.ToString("yyyy-MM-dd");
            string toDate = dtToDate.DateTime.ToString("yyyy-MM-dd");
            
            grdOtherServiceViewByService.DataSource = FileProcess.LoadTable("ST_WMS_LoadOtherServiceList " + AppSetting.StoreID + ",'" + fromDate + "','" + toDate + "'");
        }

        private void dtFromDate_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                SQL_Refresh();
            }
            catch (Exception ex) { }
        }

        private void dtToDate_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                SQL_Refresh();
            }
            catch (Exception ex) { }
        }

        private void grvOtherServiceViewByService_CustomDrawFooter(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            e.Handled = true;
            e.Appearance.BackColor = Color.Gainsboro;
            e.Appearance.DrawBackground(e.Cache, e.Bounds);
            e.Appearance.ForeColor = Color.Yellow;
        }

        private void rpi_hle_OtherServiceID_Click(object sender, EventArgs e)
        {
            frm_BR_OtherServices otherServicesForm = new frm_BR_OtherServices();
            int otherServicesID = Convert.ToInt32(grvOtherServiceViewByService.GetFocusedRowCellValue("OtherServiceID"));
            otherServicesForm.OtherServiceIDFind = otherServicesID;
            otherServicesForm.Show();
        }

        private void rpi_hle_OrderNumber_Click(object sender, EventArgs e)
        {
            //Code here to go to the order number
            var orderNumber = this.grvOtherServiceViewByService.GetFocusedRowCellValue("OrderNumber");
            if (orderNumber == null)
                return;

            string OrderType = Convert.ToString(orderNumber).Substring(0, 2);

            Int32 OrderID = Convert.ToInt32(Convert.ToString(orderNumber).Substring(3, Convert.ToString(orderNumber).Length-3));


            if (OrderType == "RO")
            {
                frm_WM_ReceivingOrders receivingOrder = frm_WM_ReceivingOrders.Instance;
                receivingOrder.ReceivingOrderIDFind = OrderID;
                receivingOrder.Show();
                receivingOrder.WindowState = FormWindowState.Maximized;
                receivingOrder.BringToFront();
            }
            else if (OrderType == "PC")
            {                
                frm_M_ProductCheckingByRequest productChecking1 = new frm_M_ProductCheckingByRequest();
                productChecking1.ProductCheckingIDFind = OrderID;
                productChecking1.Show();
                productChecking1.WindowState = FormWindowState.Maximized;
                productChecking1.BringToFront();
            }
            else if (OrderType == "TW")
            {
                if (this.frmTrip == null)
                {
                    this.frmTrip = new frm_WM_TripsManagement(OrderID);
                }
                else
                {
                    this.frmTrip.ReloadData(OrderID);
                }
                this.frmTrip.Show();
                this.frmTrip.WindowState = FormWindowState.Maximized;
                this.frmTrip.BringToFront();
            }
            else
            {
                frm_WM_DispatchingOrders dispatchingOrder = frm_WM_DispatchingOrders.GetInstance(OrderID);
                if (dispatchingOrder.Visible)
                {
                    dispatchingOrder.ReloadData();
                }
                dispatchingOrder.Show();
                dispatchingOrder.WindowState = FormWindowState.Maximized;
                dispatchingOrder.BringToFront();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            SQL_Refresh();
        }

        private void btnViewReport_Click_1(object sender, EventArgs e)
        {
            string fromD = this.dtFromDate.DateTime.ToString("yyyy-MM-dd");
            string toD = this.dtToDate.DateTime.ToString("yyyy-MM-dd");
            //Hieu fix
            String id1 = this.grvOtherServiceViewByService.GetFocusedRowCellValue("CustomerNumber").ToString();
            String id2 = id1.Substring(id1.IndexOf('-') + 1);
            int cusID = Convert.ToInt32(id2);
            //old code
            //int cusID = Convert.ToInt32(this.grvOtherServiceViewByService.GetFocusedRowCellValue("CustomerID"));
            string cusNum = this.grvOtherServiceViewByService.GetFocusedRowCellValue("CustomerNumber").ToString();
            string cusName = this.grvOtherServiceViewByService.GetFocusedRowCellValue("CustomerName").ToString();
            rptOtherServiceViewByService rpt = new rptOtherServiceViewByService(this.dtFromDate.DateTime, this.dtFromDate.DateTime, cusID, cusNum, cusName);
            //old code
            //rpt.DataSource = FileProcess.LoadTable("ST_WMS_LoadOtherServiceByCustomer '" + cusID + ",'" + fromD + "','" + toD + "',0");
            rpt.DataSource = FileProcess.LoadTable("ST_WMS_LoadOtherServiceByCustomer "+ cusID + ",'"+ fromD + "','"+ toD + "',0");
            if (rpt.DataSource != null)
            {
                ReportPrintToolWMS tool;
                tool = new ReportPrintToolWMS(rpt);
                tool.ShowPreview();
            }
            else
            {
                XtraMessageBox.Show("No data to print !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            

        }
    }
}
