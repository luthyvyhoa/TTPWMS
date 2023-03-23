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
using UI.MasterSystemSetup;

namespace UI.CRM
{
    public partial class frm_CRM_BillingInvoiceContractCheck : Form
    {
        private int isShowingAllActiveCustomers = 2;
        private frm_MSS_Contracts frmContract = null;
        public frm_CRM_BillingInvoiceContractCheck()
        {
            InitializeComponent();
            this.lke_OperatingCostMonthlyID.Properties.DataSource = FileProcess.LoadTable("ST_WMS_LoadOperatingCostMonth");
            this.lke_OperatingCostMonthlyID.Properties.ValueMember = "OperatingCostMonthlyID";
            this.lke_OperatingCostMonthlyID.Properties.DisplayMember = "MonthDescription";


            DataProcess<Stores> storeDA = new DataProcess<Stores>();
            this.lke_MSS_StoreList.Properties.DataSource = storeDA.Select();
            this.lke_MSS_StoreList.Properties.ValueMember = "StoreID";
            this.lke_MSS_StoreList.Properties.DisplayMember = "StoreDescription";

        }

        private void lke_OperatingCostMonthlyID_EditValueChanged(object sender, EventArgs e)
        {
            if (this.lke_MSS_StoreList.EditValue == null)
                return;
            else
                this.grcActiveBillingInvoices.DataSource = FileProcess.LoadTable("Accounting_ActiveCustomerList "+ this.lke_OperatingCostMonthlyID.EditValue + "," + this.lke_MSS_StoreList.EditValue + "," + isShowingAllActiveCustomers);
        }

        private void lke_MSS_StoreList_EditValueChanged(object sender, EventArgs e)
        {
            if (this.lke_MSS_StoreList.EditValue == null)
                return;
            else
                this.grcActiveBillingInvoices.DataSource = FileProcess.LoadTable("Accounting_ActiveCustomerList " + this.lke_OperatingCostMonthlyID.EditValue + "," + this.lke_MSS_StoreList.EditValue + "," + isShowingAllActiveCustomers);
        }

        private void checkAllActiveCustomers_CheckedChanged(object sender, EventArgs e)
        {
            if (checkAllActiveCustomers.Checked)
                isShowingAllActiveCustomers = 1;
            else
                isShowingAllActiveCustomers = 2;

            this.grcActiveBillingInvoices.DataSource = FileProcess.LoadTable("Accounting_ActiveCustomerList " + this.lke_OperatingCostMonthlyID.EditValue + "," + this.lke_MSS_StoreList.EditValue + "," + isShowingAllActiveCustomers);

        }

        private void rpe_BillingID_Click(object sender, EventArgs e)
        {

        }

        private void rpe_ContractID_Click(object sender, EventArgs e)
        {
            int customerID = Convert.ToInt32(grvActiveBillingInvoices.GetFocusedRowCellValue("CustomerID"));
            if (this.frmContract == null || this.frmContract.IsDisposed)
            {
                this.frmContract = frm_MSS_Contracts.GetInstance(customerID);
                this.frmContract.InitData(customerID);
            }
            else
            {
                this.frmContract.InitData(customerID);
            }

            this.frmContract.BringToFront();
            this.frmContract.WindowState = FormWindowState.Maximized;
            this.frmContract.Show();
        }

        private void btnCheckSolomonAll_Click(object sender, EventArgs e)
        {
            if (this.lke_OperatingCostMonthlyID.EditValue == null || this.lke_MSS_StoreList.EditValue==null)
                return;

            frm_CRM_BillingInvoiceCheckSolomonAll frm = new frm_CRM_BillingInvoiceCheckSolomonAll(Convert.ToInt32(this.lke_OperatingCostMonthlyID.EditValue), Convert.ToInt32(this.lke_MSS_StoreList.EditValue));
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
        }
    }
}
