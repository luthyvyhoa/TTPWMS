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
using UI.MasterSystemSetup;

namespace UI.CRM
{
    public partial class frm_CRM_BillingInvoiceCheckSolomonAll : Form
    {
        private frm_MSS_Contracts frmContract = null;
        private int monthID = 0;
        public frm_CRM_BillingInvoiceCheckSolomonAll(int OperatingCostMonthlyID, int StoreID)
        {
            InitializeComponent();
            DataProcess<Stores> storeDA = new DataProcess<Stores>();
            this.lke_MSS_StoreList.Properties.DataSource = storeDA.Select();
            this.lke_MSS_StoreList.Properties.ValueMember = "StoreID";
            this.lke_MSS_StoreList.Properties.DisplayMember = "StoreDescription";

            this.lke_OperatingCostMonthlyID.Properties.DataSource = FileProcess.LoadTable("ST_WMS_LoadOperatingCostMonth");
            this.lke_OperatingCostMonthlyID.Properties.ValueMember = "OperatingCostMonthlyID";
            this.lke_OperatingCostMonthlyID.Properties.DisplayMember = "MonthDescription";
            this.lke_OperatingCostMonthlyID.EditValue = OperatingCostMonthlyID;
            this.grcSolomonCheck.DataSource = FileProcess.LoadTable("Accounting_BillingSolomonCheck	" + OperatingCostMonthlyID + "," + StoreID);
        }

        private void rpe_ContractID_Click(object sender, EventArgs e)
        {
            int contractID = Convert.ToInt32(grvCheckSolomonAll.GetFocusedRowCellValue("ContractID"));//ContractID
            //if (this.frmContract == null || this.frmContract.IsDisposed)
            this.frmContract = new frm_MSS_Contracts(0, contractID);
            this.frmContract.InitData(0, contractID);
            this.frmContract.BringToFront();
            this.frmContract.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.frmContract.Show();
        }

        private void rpe_CustomerID_Click(object sender, EventArgs e)
        {
            int customerID = Convert.ToInt32(grvCheckSolomonAll.GetFocusedRowCellValue("CustomerID"));
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
            this.frmContract.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.frmContract.Show();


        }

        private void lke_MSS_StoreList_EditValueChanged(object sender, EventArgs e)
        {
            this.grcSolomonCheck.DataSource = FileProcess.LoadTable("Accounting_BillingSolomonCheck	" + Convert.ToInt32(this.lke_OperatingCostMonthlyID.EditValue) + "," + Convert.ToInt32(lke_MSS_StoreList.EditValue));
        }

        private void lke_OperatingCostMonthlyID_EditValueChanged(object sender, EventArgs e)
        {
            this.grcSolomonCheck.DataSource = FileProcess.LoadTable("Accounting_BillingSolomonCheck	" + Convert.ToInt32(this.lke_OperatingCostMonthlyID.EditValue) + "," + Convert.ToInt32(lke_MSS_StoreList.EditValue));
        }
    }
}
