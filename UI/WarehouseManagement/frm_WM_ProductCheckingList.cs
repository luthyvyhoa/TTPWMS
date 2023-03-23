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
using UI.Management;
using UI.ReportFile;
using UI.ReportForm;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_ProductCheckingList : Form
    {

        public frm_WM_ProductCheckingList()
        {
            InitializeComponent();
            this.dateEditDateFrom.Text = DateTime.Now.AddDays(-3).ToShortDateString();
            this.dateEditDateTo.Text = DateTime.Now.ToShortDateString();
            if (AppSetting.CustomerList == null) return;
            lookUpEditCustomerID.Properties.DataSource = FileProcess.LoadTable("STComboCustomerIDAll " + AppSetting.StoreID);
            lookUpEditCustomerID.Properties.ValueMember = "CustomerID";
            lookUpEditCustomerID.Properties.DisplayMember = "CustomerNumber";

            this.lookUpEditCustomerID.EditValue = 0;
            this.radioGroupCustomer.EditValue = 0;
        }

        private void UpdateData(int _varCustomerID)
        {
            string dateFrom = Convert.ToDateTime(dateEditDateFrom.EditValue).Date.ToString("yyyy-MM-dd");
            string dateTo = Convert.ToDateTime(dateEditDateTo.EditValue).Date.ToString("yyyy-MM-dd");
            int customerID = Convert.ToInt32(lookUpEditCustomerID.EditValue);
            this.grcProductCheckingList.DataSource = FileProcess.LoadTable("ST_WMS_LoadProductCheckingList '" + dateFrom + "','" + dateTo + "'," + _varCustomerID + "," + AppSetting.CurrentUser.StoreID);

            //var customerSelected = AppSetting.CustomerList.Where(c => c.CustomerID == customerID).FirstOrDefault();
            //this.lookUpEditCustomerID.Text = customerSelected.CustomerNumber;
            //this.textEditCustomerName.Text = customerSelected.CustomerName;
        }
        private void radioGroupCustomer_EditValueChanged(object sender, EventArgs e)
        {
            //DevExpress.XtraEditors.LookUpEdit editor = sender as DevExpress.XtraEditors.LookUpEdit;
            //this.textEditCustomerName.Text = editor.GetColumnValue("CustomerName").ToString();

            if (Convert.ToInt32(this.radioGroupCustomer.EditValue) == 0)
            {
                UpdateData(0);
            }
            else
            {
                //UpdateData(Convert.ToInt32(this.lookUpEditCustomerID.EditValue));
                this.lookUpEditCustomerID.ShowPopup();
            }
        }

        private void rpihle_OtherService_Click(object sender, EventArgs e)
        {
            int otherServiceID = Convert.ToInt32(this.grvProductCheckingList.GetFocusedRowCellValue("OtherServiceID"));
            frm_BR_OtherServices frm = new frm_BR_OtherServices();
            frm.OtherServiceIDFind = otherServiceID;
            frm.BringToFront();
            frm.Show();
        }

        private void lookUpEditCustomerID_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            UpdateData(Convert.ToInt32(this.lookUpEditCustomerID.EditValue));
        }

        private void rpihle_WM_ReceivingOrderInfo_Click(object sender, EventArgs e)
        {
            frm_M_ProductCheckingByRequest frm = new frm_M_ProductCheckingByRequest();
            frm.ProductCheckingIDFind = Convert.ToInt32(this.grvProductCheckingList.GetRowCellValue(this.grvProductCheckingList.FocusedRowHandle, "ProductCheckingID").ToString());          
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront();
        }

        private void dateEditDateFrom_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            UpdateDataChoose();
        }

        private void UpdateDataChoose()
        {
            if (Convert.ToInt32(this.radioGroupCustomer.EditValue) == 0)
            {
                UpdateData(0);
            }
            else
            {
                UpdateData(Convert.ToInt32(this.lookUpEditCustomerID.EditValue));
            }
        }

        private void dateEditDateTo_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            UpdateDataChoose();
        }

        private void dateEditDateTo_EditValueChanged(object sender, EventArgs e)
        {
            UpdateDataChoose();
        }

        private void dateEditDateFrom_EditValueChanged(object sender, EventArgs e)
        {
            UpdateDataChoose();
        }

        private void simpleButton1Minus_Click(object sender, EventArgs e)
        {
            dateEditDateFrom.DateTime = dateEditDateFrom.DateTime.AddDays(-1);
            dateEditDateTo.DateTime = dateEditDateTo.DateTime.AddDays(-1);
        }

        private void simpleButton1Plus_Click(object sender, EventArgs e)
        {
            dateEditDateFrom.DateTime = dateEditDateFrom.DateTime.AddDays(1);
            dateEditDateTo.DateTime = dateEditDateTo.DateTime.AddDays(1);
        }

        private void btn_WM_Today_Click(object sender, EventArgs e)
        {
            dateEditDateTo.DateTime = DateTime.Now;
            dateEditDateFrom.DateTime = DateTime.Now;
        }

        private void grvProductCheckingList_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.Column == null || e.HitInfo.InRow == false) return;
            this.popupOptionsCell.ShowPopup(Control.MousePosition);
        }

        private void btn_CombineReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            StringBuilder PC_List = new StringBuilder();
            int count = 0;

            foreach (int rowIndex in this.grvProductCheckingList.GetSelectedRows())
            {
                PC_List.Append(this.grvProductCheckingList.GetRowCellValue(rowIndex, "ProductCheckingID"));
                if (count < this.grvProductCheckingList.SelectedRowsCount - 1)
                {
                    PC_List.Append(",");
                    count++;
                }
            }

            // print/view combine PC report:
            rptPCByLocationLocationDetails rpt = new rptPCByLocationLocationDetails();
            rpt.lblafterpick.Visible = true;
            rpt.lblQtyLocationDetailsReport.Visible = true;

            rpt.DataSource = FileProcess.LoadTable("ST_WMS_ProductCheckingPrintReportByLocationCombine '" + PC_List+"'");           
            ReportPrintToolWMS printTool = new ReportPrintToolWMS(rpt);
            printTool.ShowPreview();

        }

        //public int ProductCheckingIDFind
        //{
        //    get
        //    {
        //        return _productCheckingIDFind;
        //    }

        //    set
        //    {
        //        _productCheckingIDFind = value;
        //        this.LoadServices();
        //        this.LoadServiceDetail();
        //    }
        //}
    }
}
