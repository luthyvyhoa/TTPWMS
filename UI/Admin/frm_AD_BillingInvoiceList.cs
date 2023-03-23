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
using UI.ReportFile;
using UI.ReportForm;
using UI.APIs;
using System.Xml;
using UI.WarehouseManagement;
using System.IO;
using DevExpress.XtraEditors;
using Common.Controls;
using DevExpress.XtraSplashScreen;
using System.Threading;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Configuration;

namespace UI.Admin
{
    public partial class frm_AD_BillingInvoiceList : frmBaseFormNormal
    {
        private APIProcess api = null;
        private const string urlParameters = "";
        private string token = string.Empty;
        private rptDebitNote _rptDebitNote;
        private Stores currentStore = null;
        int invoiceID;
        private readonly string fileName = "XMLCusUpdate.txt";
        public frm_AD_BillingInvoiceList()
        {
            InitializeComponent();
            string fromDate = DateTime.Now.AddDays(-31).ToString("yyyy-MM-dd");
            string toDate = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
            this.dFromDate.DateTime = DateTime.Now.AddDays(-7);
            this.dToDate.DateTime = DateTime.Now.AddDays(1);
            DataProcess<Stores> dataProcess = new DataProcess<Stores>();
            this.currentStore = dataProcess.Select(s => s.StoreID == AppSetting.StoreID).FirstOrDefault();
            this.grcBillingInvoiceDetails.DataSource = FileProcess.LoadTable("ST_WMS_LoadInvoiceList '" + fromDate + "','" + toDate + "'," + AppSetting.StoreID);
        }

        private void rpe_btn_attachement_Click(object sender, EventArgs e)
        {
            //show a attachment here ; inclduing : Billing Report, All other Services Report and Invoice in PDF form
        }


        private void rpe_hle_InvoiceID_Click(object sender, EventArgs e)
        {
            frm_AD_BillingInvoices frm = new frm_AD_BillingInvoices(Convert.ToInt32(this.grvBillingInvoiceDetails.GetFocusedRowCellValue("BillingInvoiceID")));
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront();
        }

        private void btnCreateEInvoice_Click(object sender, EventArgs e)
        {
            if (grvBillingInvoiceDetails.SelectedRowsCount <= 0)
            {
                MessageBox.Show("Please select row to create invoice", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // loop through all the selected records and process the e-invoice accrdingly


            DataProcess<object> dataProcess = new DataProcess<object>();
            SplashScreenManager.ShowForm(this, typeof(frmWaitForm), true, true, false, false);

            SplashScreenManager.Default.SetWaitFormCaption("Creating E-Invoices ... ");
            //.SetWaitFormDescription(i.ToString() + "%");



            int[] selectedRows = grvBillingInvoiceDetails.GetSelectedRows();
            int invID = 0;
            int billingID = 0;
            DataProcess<STBillingInvoice_E_Header_Result> dataProcessHeader = new DataProcess<STBillingInvoice_E_Header_Result>();
            DataProcess<STBillingInvoice_E_Details_Result> dataProcessDetails = new DataProcess<STBillingInvoice_E_Details_Result>();
            DataProcess<BillingInvoice> dataProcessInvoice = new DataProcess<BillingInvoice>();
            foreach (int rowHandle in selectedRows)
            {
                if (rowHandle >= 0)
                {
                    invID = Convert.ToInt32(grvBillingInvoiceDetails.GetRowCellValue(rowHandle, "BillingInvoiceID"));
                    billingID = Convert.ToInt32(grvBillingInvoiceDetails.GetRowCellValue(rowHandle, "BillingID"));
                    string invoiceEnumber = Convert.ToString(grvBillingInvoiceDetails.GetRowCellValue(rowHandle, "E_InvoiceUploadedBy"));
                    string confirmTime = Convert.ToString(grvBillingInvoiceDetails.GetRowCellValue(rowHandle, "ConfirmedTime"));
                    if (!string.IsNullOrEmpty(invoiceEnumber) || string.IsNullOrEmpty(confirmTime))
                    {
                        XtraMessageBox.Show("Invoice is created or invoice is not confirmed !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        continue;
                    }
                    double invAmount = Convert.ToDouble(grvBillingInvoiceDetails.GetRowCellValue(rowHandle, "Amount"));
                    if (invAmount == 0)
                    {
                        XtraMessageBox.Show("The amount is equal 0 !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        continue;
                    }


                    SplashScreenManager.Default.SetWaitFormDescription("Loading " + invoiceEnumber);
                    var listHeader = dataProcessHeader.Executing("STBillingInvoice_E_Header @BillingInvoiceID={0}", invID).FirstOrDefault();


                    if (listHeader == null)
                    {
                        XtraMessageBox.Show("Invoice header can not created, check currency or contract !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        continue;
                    }
                    var listDetail = dataProcessDetails.Executing("STBillingInvoice_E_Details @BillingInvoiceID={0}", invID);
                    if (listDetail == null || listDetail.Count() <= 0)
                    {
                        XtraMessageBox.Show("Invoice Details do not contain records, check details !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        continue;
                    }

                }
            }
            SplashScreenManager.CloseForm(false);
            this.btnRefreshList_Click(sender, e);
        }
        private void btnEmailSelected_Click(object sender, EventArgs e)
        {
            //code here to email all the selected invoices to customer,
            //including all attachments related to BillingID and attachment related to BillingInvoiceID
            //Invoices without e-invoice would not allowed to email
            if (grvBillingInvoiceDetails.SelectedRowsCount <= 0)
            {
                MessageBox.Show("Please select row to send email", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var msgConfirm = MessageBox.Show("Are you sure send email to this customers?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msgConfirm.Equals(DialogResult.No)) return;
            DataProcess<Attachments> dataProcess = new DataProcess<Attachments>();
            string boby = "Electronic Invoice and Billing Reports From KNM  Logistics Vietnam";
            foreach (int rowHandle in grvBillingInvoiceDetails.GetSelectedRows())
            {
                int customerID = Convert.ToInt32(grvBillingInvoiceDetails.GetRowCellValue(rowHandle, "CustomerID"));
                int billingInvoiceID = Convert.ToInt32(grvBillingInvoiceDetails.GetRowCellValue(rowHandle, "BillingInvoiceID"));
                string billingInvoiceNumber = Convert.ToString(grvBillingInvoiceDetails.GetRowCellValue(rowHandle, "BillingInvoiceNumber"));
                string e_InvoiceNumber = Convert.ToString(grvBillingInvoiceDetails.GetRowCellValue(rowHandle, "E_InvoiceNumber"));
                string invPeriod = Convert.ToString(grvBillingInvoiceDetails.GetRowCellValue(rowHandle, "InvoicePeriod"));
                IList<String> attachments = new List<String>();

                if (string.IsNullOrEmpty(e_InvoiceNumber))
                {
                    XtraMessageBox.Show("e-Invoice is not created for the invoice " + billingInvoiceNumber + " !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }
                var currentCustomer = AppSetting.CustomerListAll.Where(c => c.CustomerID == customerID).FirstOrDefault();
                string subject = "Invoice + Reports From KNM  Logistics VN | " + currentCustomer.CustomerNumber + " | " + invPeriod;


                DataProcess<STAttachmentView_Result> dataProcessA = new DataProcess<STAttachmentView_Result>();
                //DataProcess<STAttachmentView> dataProcessA = new DataProcess<Attachments>();

                var allAttachDB = dataProcessA.Executing("STAttachmentView @OrderNumber = {0}", billingInvoiceNumber);
                //var allAttachDB = dataProcessA.Select(a => a.OrderNumber == billingInvoiceNumber && a.IsDeleted == false).OrderByDescending(a => a.AttachmentDate);
                foreach (var item in allAttachDB)
                {
                    string attPath = ConfigurationManager.AppSettings["PathPasteFile"] + "\\" + item.AttachmentFile;
                    if (!attachments.Contains(attPath))
                        attachments.Add(attPath);
                }

                Common.Process.DataTransfer.SendMailOutlook(currentCustomer.InvoiceSendEmail, subject, boby, attachments.ToArray());
                //List<Attachments> listAttachments = dataProcess.Select(a => a.OrderNumber == billingInvoiceNumber && a.IsDeleted == false).ToList();
                //if (listAttachments == null || listAttachments.Count <= 0) continue;

                ////frm_WM_Attachments.Instance.SendMail(currentCustomer.Email, subject, subject, listAttachments);
                //Common.Process.DataTransfer.SendMailOutlook(currentCustomer.Email, subject, boby, listAttachments.ToArray());

            }
        }

        private void rpe_hle_DebitNote_Click(object sender, EventArgs e)
        {
            InitReportByCustomerPeriodAll();

            if (this._rptDebitNote.RowCount <= 0)
            {
                MessageBox.Show("No data to print!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ReportPrintToolWMS tool = new ReportPrintToolWMS(this._rptDebitNote);
            tool.ShowPreview();
        }

        private void InitReportByCustomerPeriodAll()
        {
            invoiceID = Convert.ToInt32(this.grvBillingInvoiceDetails.GetFocusedRowCellValue("BillingInvoiceID").ToString());
            this._rptDebitNote = new rptDebitNote(invoiceID);


            this._rptDebitNote.RequestParameters = false;
            this._rptDebitNote.DataSource = FileProcess.LoadTable("ST_WMS_LoadInvoiceDebitNote " + invoiceID);
        }

        private void UpdateDate()
        {
            string fromDate = this.dFromDate.DateTime.ToString("yyyy-MM-dd");
            string toDate = this.dToDate.DateTime.ToString("yyyy-MM-dd");
            this.grcBillingInvoiceDetails.DataSource = FileProcess.LoadTable("ST_WMS_LoadInvoiceList '" + fromDate + "','" + toDate + "'," + AppSetting.StoreID);

            this.layoutControlCombine.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            this.layoutControlEmail.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
        }

        private void btnRefreshList_Click(object sender, EventArgs e)
        {
            UpdateDate();
        }

        private void rpe_hle_BillingID_Click(object sender, EventArgs e)
        {
            int _billingID = Convert.ToInt32(this.grvBillingInvoiceDetails.GetFocusedRowCellValue("BillingID"));
            int _customerID = Convert.ToInt32(this.grvBillingInvoiceDetails.GetFocusedRowCellValue("CustomerID"));
            frm_BR_BillingConfirmations frm = new frm_BR_BillingConfirmations(_billingID, _customerID);
            frm.Show();
            frm.WindowState = FormWindowState.Normal;
            frm.BringToFront();
        }


        private void rpi_hpl_Attachment_DoubleClick(object sender, EventArgs e)
        {
            string orderNumber = Convert.ToString(this.grvBillingInvoiceDetails.GetFocusedRowCellValue("BillingInvoiceNumber"));
            int _customerID = Convert.ToInt32(this.grvBillingInvoiceDetails.GetFocusedRowCellValue("CustomerID"));
            string invoiceEnumber = Convert.ToString(grvBillingInvoiceDetails.GetFocusedRowCellValue("E_InvoiceNumber"));
            if (string.IsNullOrEmpty(invoiceEnumber)) return;
            frm_WM_Attachments.Instance.OrderNumber = orderNumber;
            frm_WM_Attachments.Instance.CustomerID = _customerID;
            if (!frm_WM_Attachments.Instance.Enabled) return;
            frm_WM_Attachments.Instance.ShowDialog();
        }

        private void btnCombineInvoice_Click(object sender, EventArgs e)
        {
            if (grvBillingInvoiceDetails.SelectedRowsCount <= 0)
            {
                MessageBox.Show("Please select row to combine ", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var result = XtraInputBox.Show("Enter a Billing InvoiceID", "Billing Invoice Combine", "0");
            if (result == null || string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Please input billing invoiceID to combine", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int billingInvoiceInput = 0;
            Int32.TryParse(result, out billingInvoiceInput);
            if (billingInvoiceInput <= 0)
            {
                MessageBox.Show("Billing InvoiceID input not valid", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string billingInvoiceIDlist = "";
            int count = 0;
            bool invalid = false; int currentCustomerInvoiceMainID = 0;
            DataProcess<BillingInvoice> dataProcessInvoice = new DataProcess<BillingInvoice>();
            foreach (int rowHandle in grvBillingInvoiceDetails.GetSelectedRows())
            {
                int currentBillingInvoiceID = Convert.ToInt32(grvBillingInvoiceDetails.GetRowCellValue(rowHandle, "BillingInvoiceID"));
                var currentBillingInvoice = dataProcessInvoice.Select(bl => bl.BillingInvoiceID == currentBillingInvoiceID).FirstOrDefault();
                var currentCus = AppSetting.CustomerListAll.Where(c => c.CustomerID == currentBillingInvoice.CustomerID).FirstOrDefault();
                // The invoices has created invoice then ignore
                if (!string.IsNullOrEmpty(currentBillingInvoice.E_InvoiceUploadedBy))
                {
                    count++;
                    continue;
                }
                if (currentCustomerInvoiceMainID <= 0) currentCustomerInvoiceMainID = Convert.ToInt32(currentCus.CustomerMainInvoiceID);
                else
                {
                    if (currentCus.CustomerMainInvoiceID != currentCustomerInvoiceMainID)
                    {
                        invalid = true;
                        break;
                    }
                }
                billingInvoiceIDlist += Convert.ToString(currentBillingInvoiceID);
                if (count < grvBillingInvoiceDetails.SelectedRowsCount - 1)
                    billingInvoiceIDlist += ",";
                count++;
            }
            if (invalid)
            {
                MessageBox.Show("Customer Main InvoiceID in list combine is difference\nPlease re-check it", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!billingInvoiceIDlist.Contains(result))
            {
                MessageBox.Show("Billing InvoiceID has inputted not exist in list Billing Invoices has selected", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DataProcess<object> dataProcess = new DataProcess<object>();
            int resultEx = dataProcess.ExecuteNoQuery("STBillingInvoiceCombine @BillingInvoiceIDList={0},@BillingInvoiceID={1},@CurrentUser={2}",
                  billingInvoiceIDlist, billingInvoiceInput, AppSetting.CurrentUser.LoginName);
            if (resultEx > 0)
            {
                frm_AD_BillingInvoices frm = new frm_AD_BillingInvoices(billingInvoiceInput);
                frm.ShowDialog();
            }
        }


        private void rpi_chk_Attachment_Click(object sender, EventArgs e)
        {
            this.rpi_hpl_Attachment_DoubleClick(sender, e);
        }

        private void btnViewDeleted_Click(object sender, EventArgs e)
        {

            if (this.grvBillingInvoiceDetails.SelectedRowsCount >0)
            {
                int invID = Convert.ToInt32(grvBillingInvoiceDetails.GetFocusedRowCellValue("BillingInvoiceID"));
                DataProcess<STBillingInvoice_E_Header_Result> dataProcessHeader = new DataProcess<STBillingInvoice_E_Header_Result>();
                DataProcess<STBillingInvoice_E_Details_Result> dataProcessDetails = new DataProcess<STBillingInvoice_E_Details_Result>();
                var listHeader = dataProcessHeader.Executing("STBillingInvoice_E_Header @BillingInvoiceID={0}", invID).FirstOrDefault();
                var listDetail = dataProcessDetails.Executing("STBillingInvoice_E_Details @BillingInvoiceID={0}", invID);
                if (listDetail == null || listDetail.Count() <= 0)
                {
                    XtraMessageBox.Show("Invoice Details do not contain records, check details !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }




            string fromDate = this.dFromDate.DateTime.ToString("yyyy-MM-dd");
            string toDate = this.dToDate.DateTime.ToString("yyyy-MM-dd");
            this.grcBillingInvoiceDetails.DataSource = FileProcess.LoadTable("ST_WMS_LoadInvoiceList '" + fromDate + "','" + toDate + "'," + AppSetting.StoreID + ",1");
            this.gridColumnDeleteReason.Visible = true;
            this.layoutControlCombine.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            this.layoutControlEmail.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;


        }

    }
}
