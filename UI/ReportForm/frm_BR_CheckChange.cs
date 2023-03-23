using Common.Controls;
using DA;
using DevExpress.XtraEditors;
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
using UI.WarehouseManagement;

namespace UI.ReportForm
{
    public partial class frm_BR_CheckChange : frmBaseForm
    {
        private DataProcess<STProductChanging_Result> productChangingDP = new DataProcess<STProductChanging_Result>();
        private DataProcess<STProductChangingSearch_Result> productChangingSearchDP = new DataProcess<STProductChangingSearch_Result>();
        private DataProcess<Products> productsDP = new DataProcess<Products>();
        public frm_BR_CheckChange()
        {
            InitializeComponent();

            InitData();
        }

        private void InitData()
        {
            InvisibleOrVisiblelkeCustomerID(false);
            InitDataForGrid();
            InitDataForDateEdit();
            InitDataForLookupEdit(AppSetting.CustomerList.ToList());
            SetDefaultValueForRadioGroup();
        }

        private void InvisibleOrVisiblelkeCustomerID(bool flag)
        {
            layoutControlOfCustomerID.ContentVisible = flag;
        }

        private void SetDefaultValueForRadioGroup()
        {
            radgFrameCustomer.SelectedIndex = 0;
            radgFrameChangeType.SelectedIndex = 2;
        }

        private void InitDataForLookupEdit(IList<Customers> list)
        {
            // Set items data for lkeCustomerID
            lkeCustomerID.Properties.DataSource = list;
            lkeCustomerID.Properties.DisplayMember = "CustomerNumber";
            lkeCustomerID.Properties.ValueMember = "CustomerID";
        }

        private void InitDataForDateEdit()
        {
            dtFromDate.EditValue = DateTime.Now;
            dtToDate.EditValue = DateTime.Now;
        }

        private void InitDataForGrid()
        {
            DateTime now = DateTime.Now;
            byte flag = Convert.ToByte(2);
            // Execute store STProductChanging
            IList<STProductChanging_Result> items = productChangingDP.Executing("STProductChanging @FromDate = {0}, @ToDate = {1}, @Flag = {2}", now, now, flag).ToList();
            grdCheckChange.DataSource = items;
        }

        private void lkeCustomerID_EditValueChanged(object sender, EventArgs e)
        {
            FrameChangeType_AfterUpdate();
        }

        private void FrameChangeType_AfterUpdate()
        {
            if (radgFrameCustomer.SelectedIndex == 0)
            {
                //    CurrentDb.QueryDefs("_qry_SelectedResults").sql = "STProductChanging '" & Format(Me.TxtFromDate, "yyyy-MM-dd") & "','" & Format(Me.TxtToDate, "yyyy-MM-dd") & "'," & Me.FrameChangeType.value
                DateTime from = Convert.ToDateTime(dtFromDate.EditValue);
                DateTime to = Convert.ToDateTime(dtToDate.EditValue);
                byte flag = Convert.ToByte(radgFrameChangeType.EditValue);
                IList<STProductChanging_Result> items = productChangingDP.Executing("STProductChanging @FromDate = {0}, @ToDate = {1}, @Flag = {2}", from, to, flag).ToList();
                grdCheckChange.DataSource = items;
            }
            else
            {
                if (lkeCustomerID.EditValue == null)
                {
                    lkeCustomerID.Focus();
                    lkeCustomerID.ShowPopup();
                    return;
                }
                //    CurrentDb.QueryDefs("_qry_SelectedResults").sql = "STProductChanging '" & Format(Me.TxtFromDate, "yyyy-MM-dd") & "','" & Format(Me.TxtToDate, "yyyy-MM-dd") & "'," & Me.FrameChangeType & "," & Me.cboCustomerID
                DateTime from = Convert.ToDateTime(dtFromDate.EditValue);
                DateTime to = Convert.ToDateTime(dtToDate.EditValue);
                byte flag = Convert.ToByte(radgFrameChangeType.EditValue);
                int customerID = Convert.ToInt32(lkeCustomerID.EditValue);
                IList<STProductChanging_Result> items = productChangingDP.Executing("STProductChanging @FromDate = {0}, @ToDate = {1}, @Flag = {2}, @CustomerID = {3}", from, to, flag, customerID).ToList();
                grdCheckChange.DataSource = items;
            }
        }

        private void radgFrameCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (radgFrameCustomer.SelectedIndex)
            {
                case 1:
                    {
                        layoutControlOfCustomerID.ContentVisible = true;
                        lkeCustomerID.Focus();
                        lkeCustomerID.ShowPopup();
                        break;
                    }
                case 0:
                    {
                        layoutControlOfCustomerID.ContentVisible = false;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            FrameChangeType_AfterUpdate();
        }

        private void radgFrameChangeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            FrameChangeType_AfterUpdate();
        }

        private void textEdit1_Validating(object sender, CancelEventArgs e)
        {
            TextEdit edit = sender as TextEdit;
            if (edit.IsModified)
            {
                // CurrentDb.QueryDefs("_qry_SelectedResults").sql = "STProductChangingSearch '" & Format(Me.TxtFromDate, "yyyy-MM-dd") & "','" & Format(Me.TxtToDate, "yyyy-MM-dd") & "'," & Me.FrameChangeType.value & ", '" & Me.TextReferenceIDSearch & "'"
                DateTime from = Convert.ToDateTime(dtFromDate.EditValue);
                DateTime to = Convert.ToDateTime(dtToDate.EditValue);
                byte flag = Convert.ToByte(radgFrameChangeType.EditValue);
                int customerID = Convert.ToInt32(lkeCustomerID.EditValue);
                int referenceIDSearch = Convert.ToInt32(txtReferenceIDSearch.Text);
                IList<STProductChangingSearch_Result> list = productChangingSearchDP.Executing("STProductChangingSearch @FromDate = {0}, @ToDate = {1}, @Flag = {2}, @ReferenceID = {3}, @CustomerID = {4}", from, to, flag, referenceIDSearch, customerID).ToList();
                grdCheckChange.DataSource = list;
            }
        }

        private void rpi_btn_View_Click(object sender, EventArgs e)
        {
            int currentRowInd = grvCheckChange.FocusedRowHandle;
            string description = grvCheckChange.GetRowCellValue(currentRowInd, "ChangeDescription") == null ? "" : grvCheckChange.GetRowCellValue(currentRowInd, "ChangeDescription").ToString();
            if (description != "" && description.Substring(0, 2) == "RO")
            {
                // Open from frm_BR_BillingSummaryByCustomer
                int referenceID = Convert.ToInt32(grvCheckChange.GetRowCellValue(currentRowInd, "ReferenceID"));
                frm_WM_ReceivingOrders form = frm_WM_ReceivingOrders.Instance;
                form.ReceivingOrderIDFind = referenceID;
                form.Show();
                return;
            }

            if (description != "" && description.Substring(0, 3) == "MHL")
            {
                // Open from frm_WM_MHLWorks
                int MHLWorkID = Convert.ToInt32(grvCheckChange.GetRowCellValue(currentRowInd, "ReferenceID"));
                frm_WM_MHLWorks form = frm_WM_MHLWorks.Instance;
                form.MHLWorkID = MHLWorkID;
                form.Show();
                return;
            }

            if (description != "" && description.Substring(0, 1).ToLower() == "p")
            {
                // Open from frm_WM_PalletInfo
                int refID = Convert.ToInt32(grvCheckChange.GetRowCellValue(currentRowInd, "ReferenceID"));
                int customerID;
                if (layoutControlOfCustomerID.ContentVisible)
                {
                    customerID = Convert.ToInt32(lkeCustomerID.EditValue);
                }
                else
                {
                    customerID = Convert.ToInt32(productsDP.Select(p => p.ProductID == refID).FirstOrDefault().CustomerID);
                }
                frm_WM_PalletInfo form = new frm_WM_PalletInfo(customerID, refID);
            }

            else
            {
                if (description != "" && description.Substring(19, 3).ToLower() == "del")
                {
                    // Open from frm_BR_BillingSummaryByCustomer
                    frm_BR_BillingSummaryByCustomer form = new frm_BR_BillingSummaryByCustomer();
                    int refID = Convert.ToInt32(grvCheckChange.GetRowCellValue(currentRowInd, "ReferenceID"));
                    form.CustomerID = refID;
                    form.Show();
                }
                else
                {
                    // Open from frm_BR_OtherServices
                    frm_BR_OtherServices form = new frm_BR_OtherServices();
                    int refID = Convert.ToInt32(grvCheckChange.GetRowCellValue(currentRowInd, "ReferenceID"));
                    form.OtherServiceIDFind = refID;
                    form.Show();
                }
            }
        }
    }
}
