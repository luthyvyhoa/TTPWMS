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

namespace UI.ReportForm
{
    public partial class frm_BR_Dialog_BillingSummaryByServiceBefore : Common.Controls.frmBaseForm
    {
        private int _customerID;
        private int _billingCustomerID;
        private DateTime _from;
        private DateTime _to;

        public frm_BR_Dialog_BillingSummaryByServiceBefore(int customerID, int billingCustomerID, DateTime fromDate, DateTime toDate)
        {
            InitializeComponent();
            this._customerID = customerID;
            this._billingCustomerID = billingCustomerID;
            this._from = fromDate;
            this._to = toDate;
            LoadData();
        }

        private void LoadData()
        {
            DataProcess<STBillingSummaryByServiceBefore_Result> billingDA = new DataProcess<STBillingSummaryByServiceBefore_Result>();

            this.gridControl1.DataSource = billingDA.Executing("STBillingSummaryByServiceBefore @varCustomerID = {0}, @BillingCustomerID = {1}, @varFromDate = {2}, @varTodate = {3}", this._customerID, this._billingCustomerID, this._from, this._to);
        }
    }
}
