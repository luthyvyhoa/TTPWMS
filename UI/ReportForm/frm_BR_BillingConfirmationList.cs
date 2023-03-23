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
using DevExpress.XtraEditors;
using UI.Helper;
using Common.Controls;
using UI.WarehouseManagement;
using UI.Management;
using UI.ReportFile;
using System.IO;
using DevExpress.XtraReports.UI;
using System.Net.Mail;
//using Outlook = Microsoft.Office.Interop.Outlook;

namespace UI.ReportForm
{
    public partial class frm_BR_BillingConfirmationList : frmBaseForm
    {
        private rptBillingByCustomerPeriod _rptByCustomerPeriod;
        private rptBillingDetailsPowerForRefContainers _rptDetailPower;
        private rptOtherServiceHWByOvertimes _rptHWByOvertimes;
        private rptBillingByCustomerPeriodAll _rptByCustomerPeriodAll;
        private int billingIDSelected = 0;
        private int customerID = 0;
        private DateTime fromDate = DateTime.Now;
        private DateTime toDate = DateTime.Now;
        public frm_BR_BillingConfirmationList()
        {
            InitializeComponent();
            this.dateEditFromDate.EditValue = DateTime.Now.AddDays(-7);
            this.dateEditTodate.EditValue = DateTime.Now;
            LoadData();
        }
        private void grvBillingInvoiceList_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle < 0) return;
            //int employeeID;
            //employeeID = Convert.ToInt32(AppSetting.CurrentUser.EmployeeID);

            DataProcess<Employees> emDA = new DataProcess<Employees>();
            var deparmentID = emDA.Select(em => em.EmployeeID == AppSetting.CurrentUser.EmployeeID).FirstOrDefault().Department;

            if (Convert.ToInt32(deparmentID) != 8 && (Convert.ToInt32(deparmentID) != 7))

            {
                MessageBox.Show("Your department not allow update", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //if (Convert.ToInt32(AppSetting.CurrentUser.DepartmentCategoryID) != 9) return;
            if (!e.Column.FieldName.Equals("InvoiceRemark") && !e.Column.FieldName.Equals("InvoiceDate")) return;

            int billingID = Convert.ToInt32(this.grvBillingInvoiceList.GetFocusedRowCellValue("BillingID"));
            DataProcess<Billings> billingDA = new DataProcess<Billings>();
            var currentBiiling = billingDA.Select(b => b.BillingID == billingID).FirstOrDefault();
            switch (e.Column.FieldName)
            {
                //case "Invoiced":
                case "InvoiceRemark":
                    if (string.IsNullOrEmpty(Convert.ToString(e.Value)))
                    {
                        currentBiiling.Invoiced = false;
                    }
                    else
                    {
                        currentBiiling.Invoiced = true;
                    }
                    currentBiiling.InvoiceRemark = Convert.ToString(e.Value);
                    currentBiiling.InvoiceInputBy = AppSetting.CurrentUser.LoginName;
                    billingDA.Update(currentBiiling);
                    break;
                case "InvoiceDate":
                    currentBiiling.InvoiceDate = Convert.ToDateTime(e.Value);
                    billingDA.Update(currentBiiling);
                    break;

            }
            LoadData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            string dateFrom = Convert.ToDateTime(dateEditFromDate.EditValue).Date.ToString("yyyy-MM-dd");
            string dateTo = Convert.ToDateTime(dateEditTodate.EditValue).Date.ToString("yyyy-MM-dd");
            this.grcBillingInvoiceList.DataSource = FileProcess.LoadTable("STBillingInvoiceListFDTD " + AppSetting.StoreID + ", '" + dateFrom + "', '" + dateTo + "'");
        }

        private void dateEditFromDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.KeyCode.Equals(Keys.Enter)) return;
            LoadData();
        }

        private void grcBillingInvoiceList_Click(object sender, EventArgs e)
        {

        }
        private void rpihle_BillingInvoice_DoubleClick(object sender, EventArgs e)
        {
            // Detected current order is Dispatching or Trip            

            int BillingID = Convert.ToInt32(this.grvBillingInvoiceList.GetFocusedRowCellValue("BillingID").ToString());
            DataTable tbBillings = new DataTable();
            frm_BR_BillingConfirmations billing = new frm_BR_BillingConfirmations();

            var soureFind = FileProcess.LoadTable("SELECT Billings.BillingID, Billings.CustomerID, Billings.BillingDate, Billings.BillingFromDate, Billings.BillingToDate, Billings.Confirmed, Billings.BillingRemark, Customers.CustomerNumber, Customers.CustomerName, Billings.Invoiced, Billings.InvoiceRemark, Billings.InvoiceInputBy, Billings.BillingCreatedTime, Billings.BillingCreatedBy, Billings.BillingNumber, Billings.IsDeleted"
                            + " FROM Billings INNER JOIN Customers ON Billings.CustomerID = Customers.CustomerID"
                            + " WHERE(((Billings.IsDeleted) = 0) AND((Customers.StoreID) = " + AppSetting.StoreID + ")) AND (Billings.BillingID = " + BillingID + ")"
                            + " ORDER BY Billings.BillingID");


            if (soureFind != null && soureFind.Rows.Count > 0)
            {
                //billing.tbBillings = soureFind;

            }
            else
            {
                MessageBox.Show("Not found", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            //if (billing.Visible)
            //    {
            //        billing.
            //    }
            billing.Show();
            billing.WindowState = FormWindowState.Maximized;
            billing.BringToFront();

        }

        private void rpihle_BillingID_Click(object sender, EventArgs e)
        {
            int billingID = Convert.ToInt32(this.grvBillingInvoiceList.GetFocusedRowCellValue("BillingID"));

            frm_BR_BillingConfirmations frmB = new frm_BR_BillingConfirmations(billingID);
            frmB.Show();

            //frmB.WindowState = FormWindowState.Maximized;
            //frmB.BringToFront();
        }

        private void grvBillingInvoiceList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {

                frm_WM_Attachments.Instance.OrderNumber = "BL-" + this.grvBillingInvoiceList.GetFocusedRowCellValue("BillingID");
                frm_WM_Attachments.Instance.CustomerID = Convert.ToInt32(this.grvBillingInvoiceList.GetFocusedRowCellValue("CustomerID"));
                if (!frm_WM_Attachments.Instance.Enabled) return;
                frm_WM_Attachments.Instance.ShowDialog();

            }
        }
        private void InitReportByCustomerPeriod()
        {
            this._rptByCustomerPeriod = new rptBillingByCustomerPeriod();
            this._rptByCustomerPeriod.DataSource = FileProcess.LoadTable("SELECT Billings.BillingID, Customers.CustomerNumber, Customers.CustomerName, ServicesDefinition.Measure, ServicesDefinition.ServiceID, ServicesDefinition.ServiceNumber, ServicesDefinition.ServiceName, Billings.BillingDate, Billings.BillingFromDate, Billings.BillingToDate, BillingDetails.ServiceQuantity, Customers.Phone1, Customers.Fax, Billings.BillingRemark, Customers.CustomerTaxGroup"
                                                  + " FROM(Customers INNER JOIN Billings ON Customers.CustomerID = Billings.CustomerID) INNER JOIN(ServicesDefinition INNER JOIN BillingDetails ON ServicesDefinition.ServiceID = BillingDetails.ServiceID) ON Billings.BillingID = BillingDetails.BillingID"
                                                  + " WHERE(((Billings.BillingID) = " + this.billingIDSelected + "))");
        }

        private void InitReportByCustomerPeriodAll()
        {
            this._rptByCustomerPeriodAll = new rptBillingByCustomerPeriodAll(this.billingIDSelected);
            this._rptByCustomerPeriodAll.DataSource = FileProcess.LoadTable("SELECT Billings.BillingID, Customers.CustomerNumber, Customers.CustomerName, ServicesDefinition.Measure, ServicesDefinition.ServiceID, ServicesDefinition.ServiceNumber, ServicesDefinition.ServiceName, Billings.BillingDate, Billings.BillingFromDate, Billings.BillingToDate, BillingDetails.ServiceQuantity, Customers.Phone1, Customers.Fax, Billings.BillingRemark, Customers.CustomerTaxGroup"
                                                  + " FROM(Customers INNER JOIN Billings ON Customers.CustomerID = Billings.CustomerID) INNER JOIN(ServicesDefinition INNER JOIN BillingDetails ON ServicesDefinition.ServiceID = BillingDetails.ServiceID) ON Billings.BillingID = BillingDetails.BillingID"
                                                  + " WHERE(((Billings.BillingID) = " + this.billingIDSelected + ")); ");
        }

        private void InitReportHWByOvertimes(int flag)
        {
            DataProcess<STBillingByOvertimeReport_Result> billingDA = new DataProcess<STBillingByOvertimeReport_Result>();

            this._rptHWByOvertimes = new rptOtherServiceHWByOvertimes(flag);
            this._rptHWByOvertimes.DataSource = billingDA.Executing("STBillingByOvertimeReport @CustomerID = {0}, @FromDate = {1}, @ToDate = {2}, @Flag = {3}", this.customerID, fromDate, toDate, flag != 0 ? (int?)null : 0);
        }

        private void InitReportDetailPower()
        {
            this._rptDetailPower = new rptBillingDetailsPowerForRefContainers(this.fromDate, this.toDate);
            this._rptDetailPower.DataSource = FileProcess.LoadTable("SELECT Customers.CustomerNumber, Customers.CustomerName, Customers.CustomerID, OtherService.ServiceDate, OtherServiceDetails.Description, OtherServiceDetails.Quantity, OtherServiceDetails.ServiceID, OtherService.OtherServiceID"
                                                   + " FROM (Customers INNER JOIN OtherService ON Customers.CustomerID = OtherService.CustomerID) INNER JOIN OtherServiceDetails ON OtherService.OtherServiceID = OtherServiceDetails.OtherServiceID"
                                                   + " WHERE (((Customers.CustomerID) = " + this.customerID + ") AND((OtherService.ServiceDate)Between '" + this.fromDate.ToString("yyyy-MM-dd") + "' And '" + this.toDate.ToString("yyyy-MM-dd") + "') AND((OtherServiceDetails.ServiceID) = 15)); ");
        }

        private void rpi_btn_Brower_Click(object sender, EventArgs e)
        {
            try
            {
                //int customerID = Convert.ToInt32(this.grvBillingInvoiceList.GetFocusedRowCellValue("CustomerID"));
                //string emailAddress = AppSetting.CustomerListAll.Where(c => c.CustomerID == customerID).FirstOrDefault().EmailBilling;
                //Microsoft.Office.Interop.Outlook.Application oApp = null;
                //if (oApp == null)
                //{
                //    oApp = new Microsoft.Office.Interop.Outlook.Application();
                //Microsoft.Office.Interop.Outlook._MailItem emailInfo = oApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);
                //emailInfo.To = emailAddress;
                //emailInfo.Subject = "Billing invoiced";
                //emailInfo.Body = "Dear Customer,";
                //emailInfo.Display(true);
                // Load report data
                this.billingIDSelected = Convert.ToInt32(this.grvBillingInvoiceList.GetFocusedRowCellValue("BillingID"));
                this.customerID = Convert.ToInt32(this.grvBillingInvoiceList.GetFocusedRowCellValue("CustomerID"));
                this.fromDate = Convert.ToDateTime(this.grvBillingInvoiceList.GetFocusedRowCellValue("BillingFromDate"));
                this.toDate = Convert.ToDateTime(this.grvBillingInvoiceList.GetFocusedRowCellValue("BillingToDate"));
                InitReportByCustomerPeriodAll();
                InitReportDetailPower();
                InitReportHWByOvertimes(-1);

                //Sent email after print
                var currentCus = AppSetting.CustomerList.Where(c => c.CustomerID == this.customerID).FirstOrDefault();
                string email = currentCus.Email;

                if (String.IsNullOrEmpty(email))
                {
                    XtraMessageBox.Show("This Customer does not have e-mail address !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.SmartTextWrap = true;
                    DialogResult result = XtraMessageBox.Show("Send report to the address : " + email + " ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        SendMail(email, this._rptByCustomerPeriodAll, "ECV Billing Report - " + currentCus.CustomerName + "Period: " + this.fromDate.ToString("dd/MM/yyyy") + " ~ " + this.toDate.ToString("dd/MM/yyyy"));
                        SendMail(email, this._rptDetailPower, "ECV Electricity Consumption Report - " + currentCus.CustomerName + "Period: " + this.fromDate.ToString("dd/MM/yyyy") + " ~ " + this.toDate.ToString("dd/MM/yyyy"));
                        SendMail(email, this._rptHWByOvertimes, "ECV Handling Overtimes Report - " + currentCus.CustomerName + "Period: " + this.fromDate.ToString("dd/MM/yyyy") + " ~ " + this.toDate.ToString("dd/MM/yyyy"));
                    }
                }

            }
            catch (Exception ex)
            {
            }
        }
        /// <summary>
        /// Send attachment to customers
        /// </summary>
        private void SendMail(string toEmail, XtraReport report, string subject, int formatType = 0)
        {
            try
            {
                string fileExtension = "rtf";
                string boby = "Stock Report From SCS VN";
                using (MemoryStream mem = new MemoryStream())
                {

                    if (formatType == 0)
                    {
                        report.ExportToRtf(mem);
                        fileExtension = "rtf";
                    }
                    else
                    {
                        report.ExportToXlsx(mem);
                        fileExtension = "xlsx";
                    }

                    mem.Seek(0, SeekOrigin.Begin);
                    Attachment att = new Attachment(mem, "Stock Report From SCS VN." + fileExtension, "application/" + fileExtension);
                    Common.Process.DataTransfer.SendMail(toEmail, subject, boby, att);
                }

                XtraMessageBox.Show("Email sent successful!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Send failed!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
