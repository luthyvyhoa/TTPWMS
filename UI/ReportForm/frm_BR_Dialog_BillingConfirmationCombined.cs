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
using UI.ReportFile;

namespace UI.ReportForm
{
    public partial class frm_BR_Dialog_BillingConfirmationCombined : Common.Controls.frmBaseForm
    {
        private DataProcess<tmpBillingCombined> _billingDA;
        private bool _isFirstLoad;

        public frm_BR_Dialog_BillingConfirmationCombined(int customerID, DateTime fromDate, DateTime toDate)
        {
            InitializeComponent();
            InitCustomer();
            this._billingDA = new DataProcess<tmpBillingCombined>();
            this._isFirstLoad = true;
            this.dtFromDate.EditValue = fromDate;
            this.dtToDate.EditValue = toDate;
            this.lkeCustomer.EditValue = customerID;
            this.txtCustomerName.Text = Convert.ToString(this.lkeCustomer.GetColumnValue("CustomerName"));
        }

        private void InitCustomer()
        {
            this.lkeCustomer.Properties.DataSource = AppSetting.CustomerList;
            this.lkeCustomer.Properties.ValueMember = "CustomerID";
            this.lkeCustomer.Properties.DisplayMember = "CustomerNumber";
        }

        private void lkeCustomer_EditValueChanged(object sender, EventArgs e)
        {
            if(this._isFirstLoad)
            {
                this.txtCustomerName.Text = Convert.ToString(this.lkeCustomer.GetColumnValue("CustomerName"));
                this.btnRefresh.PerformClick();
                LoadBillingCombined();
                this._isFirstLoad = false;
            }
        }

        private void lkeCustomer_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if(!this._isFirstLoad)
            {
                this.lkeCustomer.EditValue = e.Value;
                this.txtCustomerName.Text = Convert.ToString(this.lkeCustomer.GetColumnValue("CustomerName"));
                this.btnRefresh.PerformClick();
                LoadBillingCombined();
            }
        }

        private void LoadBillingCombined()
        {
            this.grdBillingCombined.DataSource = this._billingDA.Select(b => b.UserID.Equals(AppSetting.CurrentUser.LoginName));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            int result = this._billingDA.ExecuteNoQuery("STBillingConfirmationCombinedInsert @CustomerMainID = {0}, @UserID = {1}, @FromDate = {2}, @ToDate = {3}", Convert.ToInt32(this.lkeCustomer.EditValue), AppSetting.CurrentUser.LoginName, this.dtFromDate.DateTime, this.dtToDate.DateTime);
            LoadBillingCombined();
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            bool isChecked = false;
            for(int i = 0; i < grvBillingCombined.RowCount; i++)
            {
                if (Convert.ToBoolean(this.grvBillingCombined.GetRowCellValue(i, "CheckCombined")))
                {
                    isChecked = true;
                    break;
                }
            }

            if(!isChecked)
            {
                XtraMessageBox.Show("Please check Customer to combine !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DataProcess<STBillingConfirmationCombinedReport_Result> billingReportDA = new DataProcess<STBillingConfirmationCombinedReport_Result>();
                rptBillingByCustomerPeriodAllCombined rpt = new rptBillingByCustomerPeriodAllCombined(Convert.ToInt32(this.lkeCustomer.EditValue));
                rpt.DataSource = billingReportDA.Executing("STBillingConfirmationCombinedReport @CustomerMainID = {0}, @UserID = {1}", Convert.ToInt32(this.lkeCustomer.EditValue), AppSetting.CurrentUser.LoginName);
                ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
                tool.ShowPreview();
            }
        }

        private void rpi_chk_CheckCombined_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void grvBillingCombined_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if(e.Column.FieldName.Equals("CheckCombined"))
            {
                int result = this._billingDA.ExecuteNoQuery("Update tmpBillingCombined Set CheckCombined = {0} Where ID = {1}", Convert.ToBoolean(this.grvBillingCombined.GetFocusedRowCellValue("CheckCombined")), Convert.ToInt32(this.grvBillingCombined.GetFocusedRowCellValue("ID")));
            }
        }
    }
}
