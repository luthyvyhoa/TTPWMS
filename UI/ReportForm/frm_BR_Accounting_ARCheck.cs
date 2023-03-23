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
using UI.Admin;

namespace UI.ReportForm
{
    public partial class frm_BR_Accounting_ARCheck : Form
    {
        bool isModifiedDate = false;
        public frm_BR_Accounting_ARCheck()
        {
          
            InitializeComponent();
            this.grcARTotal.DataSource = FileProcess.LoadTable("Accounting_AccountReceivableTotal");
            txtFrom.EditValue = DateTime.Now.AddDays(-30);
            txtTo.EditValue = DateTime.Now;
            this.layoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            //UpdateDetails();
        }

        public frm_BR_Accounting_ARCheck(string CC)
        {

            InitializeComponent();
            this.grcARTotal.DataSource = FileProcess.LoadTable("Accounting_AccountReceivableTotal 'X'");
            txtFrom.EditValue = DateTime.Now.AddDays(-30);
            txtTo.EditValue = DateTime.Now;
            //UpdateDetails();
        }


        private void UpdateDetails()
        {
            int customerID = Convert.ToInt32(this.grvARAllCustmers.GetFocusedRowCellValue("CustomerID"));
            if (isModifiedDate)
            {
                string From = Convert.ToDateTime(txtFrom.EditValue).ToString("MM/dd/yyyy");
                string To = Convert.ToDateTime(txtTo.EditValue).ToString("MM/dd/yyyy");
                this.grcAC_Invoices.DataSource = FileProcess.LoadTable("Accounting_AccountReceivableInvoicesFDTD @CustomerID=" + customerID + ",@From='" + From + "',@To='" + To + "'");
                this.grcARPayments.DataSource = FileProcess.LoadTable("Accounting_AccountReceivablePayment " + customerID);
            }
            else
            {
                
                this.grcAC_Invoices.DataSource = FileProcess.LoadTable("Accounting_AccountReceivableInvoices " + customerID);
                this.grcARPayments.DataSource = FileProcess.LoadTable("Accounting_AccountReceivablePayment " + customerID);
            }
            
            //object tempInvoice = this.grvInvoices.Columns["nvoicedAmount"].SummaryItem.SummaryValue;
            //this.grvARAllCustmers.SetFocusedRowCellValue("InvoicedAmount", Convert.ToDecimal(tempInvoice));
            this.grcARDetails.DataSource = FileProcess.LoadTable("Accounting_AccountReceivableDetails " + customerID);

        }
        private void grvARAllCustmers_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            UpdateDetails();
        }

        private void rpe_BillingID_Click(object sender, EventArgs e)
        {
            //code to open form billingConfirmation here
            int billingID = Convert.ToInt32(this.grvInvoices.GetFocusedRowCellValue("BillingNo"));
            int _customerID = Convert.ToInt32(this.grvInvoices.GetFocusedRowCellValue("CustomerID"));

            frm_BR_BillingConfirmations frmB = new frm_BR_BillingConfirmations(billingID, _customerID);
            frmB.Show();
        }

        private void rpe_hle_BillingID_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            isModifiedDate = false;
            int customerID = Convert.ToInt32(this.grvARAllCustmers.GetFocusedRowCellValue("CustomerID"));
            this.grcAC_Invoices.DataSource = FileProcess.LoadTable("Accounting_AccountReceivableInvoices " + customerID);
            this.grcARPayments.DataSource = FileProcess.LoadTable("Accounting_AccountReceivablePayment " + customerID);
            this.grcARTotal.DataSource = FileProcess.LoadTable("Accounting_AccountReceivableTotal");

        }

        private void txtFrom_EditValueChanged(object sender, EventArgs e)
        {
          
        }

        private void txtTo_EditValueChanged(object sender, EventArgs e)
        {
           
        }

        private void txtFrom_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            isModifiedDate = true;
            UpdateDetails();
        }

        private void txtTo_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            isModifiedDate = true;
            UpdateDetails();
        }

        private void txtTo_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.KeyCode.Equals(Keys.Enter)) return;
            isModifiedDate = true;
            UpdateDetails();
            
        }

        private void txtFrom_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.KeyCode.Equals(Keys.Enter)) return;
            isModifiedDate = true;
           
            UpdateDetails();
        }

        private void rpe_BillingInvoiceID_Click(object sender, EventArgs e)
        {
            int blID = Convert.ToInt32(this.grvInvoices.GetFocusedRowCellValue("BillingInvoiceID"));
            frm_AD_BillingInvoices frm = new frm_AD_BillingInvoices(blID);
            frm.Show();
            frm.WindowState = FormWindowState.Normal;
            frm.BringToFront();
        }

        private void checkWMS_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkWMS.Checked)
            {
                this.grcARTotal.DataSource = FileProcess.LoadTable("Accounting_AccountReceivableTotal 'X'");
            }
            else
            {
                this.grcARTotal.DataSource = FileProcess.LoadTable("Accounting_AccountReceivableTotal");
            }
        }
    }
}
