using DA;
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

namespace UI.WarehouseManagement
{
    public partial class frm_WM_DispatchingProductListKGR : Form
    {
        private frm_WM_PalletInfo palletInfo = null;
        public frm_WM_DispatchingProductListKGR()
        {
            InitializeComponent();
            lke_WM_Customer.Properties.DataSource = FileProcess.LoadTable("STComboCustomerIDRandomWeight " + AppSetting.StoreID);
            lke_WM_Customer.Properties.ValueMember = "CustomerID";
            lke_WM_Customer.Properties.DisplayMember = "CustomerNumber";
            string rptDate = Convert.ToDateTime(dtReportDate.EditValue).Date.ToString("yyyy-MM-dd");
            this.grcDispatchingProductListKGR.DataSource = FileProcess.LoadTable("STPickPlanListByDateByCustomerIDByDP '" + rptDate + "',0," + AppSetting.StoreID);
        }

        private void rpe_ProductID_Click(object sender, EventArgs e)
        {
            int customerID = Convert.ToInt32(grvDispatchingProductKGR.GetFocusedRowCellValue("CustomerID"));
            int productID = Convert.ToInt32(grvDispatchingProductKGR.GetRowCellValue(grvDispatchingProductKGR.FocusedRowHandle, "ProductID"));
            if (this.palletInfo == null)
            {
                this.palletInfo = new frm_WM_PalletInfo(customerID, productID);
            }
            else
            {
                this.palletInfo.InitData(customerID, productID);
            }
            this.palletInfo.Show();
        }

        private void rpe_DOID_Click(object sender, EventArgs e)
        {
            string orderNo = Convert.ToString(this.grvDispatchingProductKGR.GetRowCellValue(this.grvDispatchingProductKGR.FocusedRowHandle, "DispatchingOrderNumber"));
            if (string.IsNullOrEmpty(orderNo)) return;
            string orderNumber = orderNo.Substring(0, 2);
            int receivingOrderID = Convert.ToInt32(this.grvDispatchingProductKGR.GetRowCellValue(this.grvDispatchingProductKGR.FocusedRowHandle, "DispatchingOrderID").ToString());
            if (orderNumber.ToUpper().Equals("DO"))
            {
                // Display disptching order
                frm_WM_DispatchingOrders dispatchingOrder = frm_WM_DispatchingOrders.GetInstance(receivingOrderID);
                if (dispatchingOrder.Visible)
                {
                    dispatchingOrder.ReloadData();
                }
                dispatchingOrder.Show();
                dispatchingOrder.WindowState = FormWindowState.Maximized;
                dispatchingOrder.BringToFront();
            }
        }

        private void lke_WM_Customer_EditValueChanged(object sender, EventArgs e)
        {
            string rptDate = Convert.ToDateTime(dtReportDate.EditValue).Date.ToString("yyyy-MM-dd");
            this.HyperLinkEdit_CustomerName.Text = this.lke_WM_Customer.GetColumnValue("CustomerName").ToString();
            
            this.grcDispatchingProductListKGR.DataSource = FileProcess.LoadTable("STPickPlanListByDateByCustomerIDByDP '" + rptDate + "'," + this.lke_WM_Customer.EditValue + "," + AppSetting.StoreID);
        }

        private void rpe_PrintLabel_Click(object sender, EventArgs e)
        {
            //Code to print label here for 1 record here
            //
        }

        private void PrintPickingLabel_Click(object sender, EventArgs e)
        {
            //Code to print all the selected records label here
            StringBuilder dProductID = new StringBuilder();
            dProductID.Append('(');
            int count = 0;
            foreach (int rowIndex in this.grvDispatchingProductKGR.GetSelectedRows())
            {
                dProductID.Append(this.grvDispatchingProductKGR.GetRowCellValue(rowIndex, "DispatchingProductID"));
                if (count < this.grvDispatchingProductKGR.SelectedRowsCount - 1)
                {
                    dProductID.Append(",");
                    count++;
                }
            }
            dProductID.Append(')');
            //Code to print all the selected records label here
            //Code to print all the selected records label here
            //Code to print all the selected records label here
            
            rptDispatchingPlanPick_KGR rptPlanPick = new rptDispatchingPlanPick_KGR();
            rptPlanPick.DataSource = FileProcess.LoadTable("STPickPlanListByDateByCustomerIDByDP @Date='" + Convert.ToDateTime(dtReportDate.EditValue).Date.ToString("yyyy-MM-dd")+ "',@CustomerID="+ this.lke_WM_Customer.EditValue+ ",@StoreID=" + AppSetting.StoreID);
            rptPlanPick.RequestParameters = false;
            rptPlanPick.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;  
            ReportPrintToolWMS printTool = new ReportPrintToolWMS(rptPlanPick);
            printTool.ShowPreview();
        }
    }
}
