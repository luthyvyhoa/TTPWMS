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
using UI.Helper;
using UI.MasterSystemSetup;
using UI.ReportFile;
using UI.WarehouseManagement;

namespace UI.CRM
{
    public partial class frm_CRM_QuotationList : Form
    {
        DataProcess<CustomerQuotation> quotationDA = new DataProcess<CustomerQuotation>();
        frm_CRM_Quotation frm = null;
        public frm_CRM_QuotationList()
        {
            InitializeComponent();
            //InitCustomer();
            //InitQuotationStatus();
            LoadQuotation();
            InitEvent();

        }
        private void LoadQuotation()
        {
            this.grdQuotations.DataSource = FileProcess.LoadTable("STCustomerQuotationList");
        }

        private void InitEvent()
        {
            this.rpi_hplQuotationNumber.Click += rpi_hplQuotationNumber_Click;
            this.btnPrint.ItemClick += BtnPrint_ItemClick;
            this.grvQuotationTabelView.PopupMenuShowing += GrvQuotationTabelView_PopupMenuShowing;
            Common.Process.RefreshData.ReloadDataEvent += RefreshData_ReloadDataEvent;
        }

        void RefreshData_ReloadDataEvent(object sender, EventArgs e)
        {
            if (!sender.GetType().Name.Equals("CustomerQuotation")) return;
            this.LoadQuotation();
        }

        private void GrvQuotationTabelView_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            this.ShowPopupOptionsCellMenu(sender, e);
        }
        private void ShowPopupOptionsCellMenu(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (!e.HitInfo.InRow || e.HitInfo.Column == null) return;
            this.btnPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //if (e.HitInfo.Column.FieldName.Equals("SpecialRequirement")) return;
            this.popupMenuPrint.ShowPopup(Control.MousePosition);
        }

        private void BtnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            StringBuilder quotation = new StringBuilder();
            quotation.Append('(');
            int count = 0;
            foreach (int rowIndex in this.grvQuotationTabelView.GetSelectedRows())
            {
                quotation.Append(this.grvQuotationTabelView.GetRowCellValue(rowIndex, "QuotationID"));
                if (count < this.grvQuotationTabelView.SelectedRowsCount - 1)
                {
                    quotation.Append(",");
                    count++;
                }
            }
            quotation.Append(')');
            rptCombinedQuotation rpt = new rptCombinedQuotation();
            var dataSource = FileProcess.LoadTable("STCustomerQuotationCombinedView @strQuotationID='" + quotation.ToString() + "'");
            if (dataSource.Rows.Count > 0)
            {
                rpt.DataSource = dataSource;
                rpt.xrQuotation.Text = quotation.ToString().Substring(1, quotation.Length - 1);
                rpt.xrStore.Text = AppSetting.StoreName;
                ReportPrintToolWMS print = new ReportPrintToolWMS(rpt);
                print.ShowPreview();
            }
            else
            {
                MessageBox.Show("No data to print", "TPWMS");
            }
        }

        void rpi_hplQuotationNumber_Click(object sender, EventArgs e)
        {
            if (Convert.IsDBNull(this.grvQuotationTabelView.GetFocusedRowCellValue("QuotationNumber"))) return;
            int quotationID = Convert.ToInt32(this.grvQuotationTabelView.GetFocusedRowCellValue("QuotationID"));
            frm = new frm_CRM_Quotation(quotationID);
            frm.Show();
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            frm = new frm_CRM_Quotation(0);
            frm.Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.LoadQuotation();
        }

        private void frm_CRM_QuotationList_Load(object sender, EventArgs e)
        {

        }

        private void rhe_PrevContractID_Click(object sender, EventArgs e)
        {
            // CHỗ này cần show Previous Contract, chứ không phải là tất cả các contract của 1 Customers.

            int customerID = Convert.ToInt32(this.grvQuotationTabelView.GetFocusedRowCellValue("CustomerID"));
            if (customerID <= 0) return;
            frm_MSS_Contracts frm = frm_MSS_Contracts.GetInstance(customerID);
            frm.InitData(customerID);
            frm.BringToFront();
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void rhe_CustomerID_Click(object sender, EventArgs e)
        {
            int customerID = Convert.ToInt32(this.grvQuotationTabelView.GetFocusedRowCellValue("CustomerID"));
            var currentCustomer = AppSetting.CustomerListAll.Where(c => c.CustomerID == customerID).FirstOrDefault();
            frm_MSS_Customers frm = MasterSystemSetup.frm_MSS_Customers.Instance;
            frm.CurrentCustomers = currentCustomer;
            frm.BringToFront();
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.F3)
            {
                frm_WM_Attachments.Instance.OrderNumber = this.grvQuotationTabelView.GetFocusedRowCellValue("QuotationNumber").ToString();
                frm_WM_Attachments.Instance.CustomerID = Convert.ToInt32(this.grvQuotationTabelView.GetFocusedRowCellValue("CustomerID"));
                if (frm_WM_Attachments.Instance.Enabled)
                {
                    frm_WM_Attachments.Instance.ShowDialog();
                }
            }
            return base.ProcessDialogKey(keyData);
        }
    }
}
