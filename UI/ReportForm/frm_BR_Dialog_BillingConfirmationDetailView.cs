using DA;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Helper;

namespace UI.ReportForm
{
    public partial class frm_BR_Dialog_BillingConfirmationDetailView : Common.Controls.frmBaseForm
    {
        private DataProcess<BillingDetailBreakDown> _billingDetailDA;
        private List<BillingDetailBreakDown> _listBillingDetail;
        private int _billingID;
        private int _customerID;
        private string _customerNumber;
        private string _customerName;
        private DateTime _fromDate;
        private DateTime _toDate;
        private Boolean isPalletQty = false;
        private Boolean isUpdated = false;

        public frm_BR_Dialog_BillingConfirmationDetailView(int billingID, int customerID)
        {
            InitializeComponent();
            this._billingDetailDA = new DataProcess<BillingDetailBreakDown>();
            this._listBillingDetail = new List<BillingDetailBreakDown>();
            this._billingID = billingID;
            this._customerID = customerID;
        }

        public frm_BR_Dialog_BillingConfirmationDetailView(int billingID, int customerID, string customerNumber, string customerName, DateTime fromDate, DateTime toDate)
        {
            InitializeComponent();
            this._billingDetailDA = new DataProcess<BillingDetailBreakDown>();
            this._listBillingDetail = new List<BillingDetailBreakDown>();
            this._billingID = billingID;
            this._customerID = customerID;
            this._customerNumber = customerNumber;
            this._customerName = customerName;
            this._fromDate = fromDate;
            this._toDate = toDate;
            this.Text ="Billing detailed data : " + _customerNumber + " | " + _customerName + " | " + _fromDate.ToShortDateString() + " ~ " + _toDate.ToShortDateString();
        }

        private void frm_BR_Dialog_BillingConfirmationDetailView_Load(object sender, EventArgs e)
        {
            LoadHistoryBillings(0);
            SetEvents();
        }

        private void SetEvents()
        {
            this.btnClose.Click += BtnClose_Click;
            this.btnEmail.Click += BtnEmail_Click;
            this.btnUpdate.Click += BtnUpdate_Click;
            this.grvHistoryBilling.CellValueChanged += GrvHistoryBilling_CellValueChanged;
        }

        private void GrvHistoryBilling_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int billingDetailID = Convert.ToInt32(this.grvHistoryBilling.GetFocusedRowCellValue("BillingDetailBreakdownID"));
            int result = -2;
            int row = e.RowHandle;
            bool isPallets = false;

            switch (e.Column.FieldName)
            {
                case "BeginP":
                    {
                        result = this._billingDetailDA.ExecuteNoQuery("Update BillingDetailBreakDown Set BeginP = {0} Where BillingDetailBreakdownID = {1}", Convert.ToInt32(e.Value), billingDetailID);
                        isPallets = true;
                        break;
                    }
                case "InP":
                    {
                        result = this._billingDetailDA.ExecuteNoQuery("Update BillingDetailBreakDown Set InP = {0} Where BillingDetailBreakdownID = {1}", Convert.ToInt32(e.Value), billingDetailID);
                        isPallets = true;
                        break;
                    }
                case "OutP":
                    {
                        result = this._billingDetailDA.ExecuteNoQuery("Update BillingDetailBreakDown Set OutP = {0} Where BillingDetailBreakdownID = {1}", Convert.ToInt32(e.Value), billingDetailID);
                        isPallets = true;
                        break;
                    }
                case "BillingDetailBreakdownRemark":
                    {
                        result = this._billingDetailDA.ExecuteNoQuery("STBillingDetailBreakdownRemarkUpdate @BillingDetailBreakdownID = {0}, @Remark = {1}", billingDetailID, Convert.ToString(e.Value));
                        break;
                    }
            }

            if (result != -2)
            {
                if (isPallets)
                {
                    UpdateCloseP(billingDetailID);
                }
                LoadHistoryBillings(row);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (this._listBillingDetail.Count <= 0)
            {
                return;
            }
            int varClose = (int)this._listBillingDetail[0].BeginP;
            int totalBeginP = Convert.ToInt32(this.grcBeginP.SummaryItem.SummaryValue);
            int totalInP = Convert.ToInt32(this.grcInP.SummaryItem.SummaryValue);
            int totalOutP = Convert.ToInt32(this.grcOutP.SummaryItem.SummaryValue);

            foreach (BillingDetailBreakDown detail in this._listBillingDetail)
            {
                if (varClose != detail.BeginP)
                {
                    XtraMessageBox.Show("Pallet Quantity is not correct! Please check date " + detail.ReportDate.ToString(), "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                varClose = (int)detail.CloseP;
            }

            if (XtraMessageBox.Show("If update will create new Billing No. Are you sure to update billing ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int result = this._billingDetailDA.ExecuteNoQuery("STBillingConfirmationUpdate @BillingID = {0}, @BeginPallet = {1}, @InPallet = {2}, @OutPallet = {3}, @CurrentUser = {4}", this._billingID, totalBeginP, totalInP, totalOutP, AppSetting.CurrentUser.LoginName);
                isUpdated = false;
            }
        }

        private void BtnEmail_Click(object sender, EventArgs e)
        {
            if (isUpdated == true)
            {
                XtraMessageBox.Show("Please Update the edited data !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this._listBillingDetail.Count <= 0)
            {
                return;
            }
            Customers customer = AppSetting.CustomerList.Where(c => c.CustomerID == this._customerID).FirstOrDefault();

            if (String.IsNullOrEmpty(customer.Email))
            {
                XtraMessageBox.Show("This Customer does not have e-mail address !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                XtraMessageBox.SmartTextWrap = true;
                DialogResult result = XtraMessageBox.Show("Send report to the address : " + customer.Email + " ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    this.grdHistoryBilling.SuspendLayout();

                    this.grcBillingDetailBreakdownRemark.Visible = false;

                    SendMail(customer.Email, "SCS VN Report - Billing Detail - " + customer.CustomerNumber + " BillingID: " + this._billingID, 1);

                    this.grcBillingDetailBreakdownRemark.Visible = true;
                    this.grdHistoryBilling.ResumeLayout();
                }
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            //Check if the data is edited
            if (isUpdated == true)
            {
                XtraMessageBox.Show("The detail data is updated. Please update the maindata. Can not close !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                this.Close();
            }
                
        }

        #region Load Data
        private void LoadHistoryBillings(int row)
        {
            var sourceFind = this._billingDetailDA.Executing("STBillingDetailBreakdownByBillingID @BillingID={0}", this._billingID);
            if (sourceFind == null || sourceFind.Count() <= 0)
            {
                return;
            }
            this._listBillingDetail = sourceFind.OrderBy(b => b.ReportDate).ToList();
            this.grdHistoryBilling.DataSource = this._listBillingDetail;
            this.grvHistoryBilling.FocusedRowHandle = row;
            CalculateSummary();
        }

        private void CalculateSummary()
        {
            this.txtStorageCarton.Text = Convert.ToString(Convert.ToInt32(this.grcInC.SummaryItem.SummaryValue) + Convert.ToInt32(this.grcBeginC.SummaryItem.SummaryValue));
            this.txtStorageWeight.Text = Convert.ToString((Convert.ToDecimal(this.grcInW.SummaryItem.SummaryValue) + Convert.ToDecimal(this.grcBeginW.SummaryItem.SummaryValue)) / 1000);
            this.txtHandlingCarton.Text = Convert.ToString(this.grcInC.SummaryItem.SummaryValue);
            this.txtHandlingWeight.Text = Convert.ToString(Convert.ToDecimal(this.grcInW.SummaryItem.SummaryValue) / 1000);
        }
        #endregion

        private void UpdateCloseP(int billingDetailID)
        {
            int beginP = Convert.ToInt32(this.grvHistoryBilling.GetFocusedRowCellValue("BeginP"));
            int inP = Convert.ToInt32(this.grvHistoryBilling.GetFocusedRowCellValue("InP"));
            int outP = Convert.ToInt32(this.grvHistoryBilling.GetFocusedRowCellValue("OutP"));

            int closeP = beginP + inP - outP;

            int result = this._billingDetailDA.ExecuteNoQuery("Update BillingDetailBreakDown Set CloseP = {0} Where BillingDetailBreakdownID = {1}", closeP, billingDetailID);
            isUpdated = false;
        }

        /// <summary>
        /// Send attachment to customers
        /// </summary>
        private void SendMail(string toEmail, string subject, int formatType = 0)
        {
            try
            {
                string fileExtension = "rtf";
                string boby= "Stock Report From SCS VN";
                using (MemoryStream mem = new MemoryStream())
                {

                    if (formatType == 0)
                    {
                        this.grvHistoryBilling.ExportToRtf(mem);
                        fileExtension = "rtf";
                    }
                    else
                    {
                        this.grvHistoryBilling.ExportToXlsx(mem);
                        fileExtension = "xlsx";
                    }

                    mem.Seek(0, SeekOrigin.Begin);
                    Attachment att = new Attachment(mem, "Billing Details Report - BillingID " + this._billingID + "." + fileExtension, "application/" + fileExtension);
                    Common.Process.DataTransfer.SendMail(toEmail, subject, boby, att);
                }

                XtraMessageBox.Show("Email sent successful!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Send failed!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grvHistoryBilling_CustomDrawFooterCell(object sender, DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs e)
        {
            e.Appearance.DrawString(e.Cache, e.Info.DisplayText, e.Bounds);
            e.Handled = true;
        }

        private void grvHistoryBilling_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle < 1) return;
            double closing = Convert.ToDouble(this.grvHistoryBilling.GetRowCellValue(e.RowHandle - 1, "CloseP"));
            double begin = Convert.ToDouble(this.grvHistoryBilling.GetRowCellValue(e.RowHandle, "BeginP"));
            if (closing != begin)
            {
                e.Appearance.BackColor = Color.Red;
                e.Appearance.ForeColor = Color.White;
            }
        }

        private void rpi_spe_ViewOrders_Click(object sender, EventArgs e)
        {
            int billingDateID = Convert.ToInt32(this.grvHistoryBilling.GetRowCellValue(this.grvHistoryBilling.FocusedRowHandle, "BillingDetailBreakdownID"));
            frm_BR_Dialog_BillingDateOrders frmx = new frm_BR_Dialog_BillingDateOrders(billingDateID, this._customerID, 2);
            frmx.ShowDialog();
            frmx.BringToFront();
        }

        private void dockPanelPalletSystemCheck_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            this.grcPalletHistoryCheck.DataSource = FileProcess.LoadTable("STBillingConfirmationDetailCheckPlts " + _billingID + "," + _customerID);
        }

        private void btnInOutView_Click(object sender, EventArgs e)
        {
            frm_BR_BillingConfirmationHandlingCheck frm = new frm_BR_BillingConfirmationHandlingCheck(_customerID, _fromDate, _toDate, _customerName, _customerNumber, false);
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;

        }

        private void grvHistoryBilling_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            isUpdated = true;
        }

        private void rpi_spe_ViewPallets_Click(object sender, EventArgs e)
        {
            DateTime ReportDate = Convert.ToDateTime(this.grvHistoryBilling.GetFocusedRowCellValue("ReportDate"));
            frm_BR_StockByLocationPivot pivot = new frm_BR_StockByLocationPivot(ReportDate, ReportDate, this._customerID);
            pivot.ShowDialog();
        }
    }
}
