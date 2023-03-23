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
    public partial class frm_CRM_CompareRates : Form
    {
        private frm_MSS_Contracts frmContract = null;
        public frm_CRM_CompareRates(int QuotationDetailID, string ServiceName)
        {
            InitializeComponent();
            this.Text = "Compare rates for service : " + ServiceName;
            this.grcCompareRates.DataSource = FileProcess.LoadTable("STContractDetail_CompareRate " + QuotationDetailID.ToString());
        }

        private void rpe_hle_CustomerReview_Click(object sender, EventArgs e)
        {

            int OperatingCostMonthlyID = AppSetting.LastOperationMonthID;
            int StoreID = Convert.ToInt32(AppSetting.StoreID);
            int CustomerID = Convert.ToInt32(this.grvCompareRates.GetFocusedRowCellValue("CustomerID".ToString()));

            frm_CRM_OperatingCostViewByCustomer frm = new frm_CRM_OperatingCostViewByCustomer(OperatingCostMonthlyID, StoreID, CustomerID);
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
        }

        private void rpe_hle_ContractReview_Click(object sender, EventArgs e)
        {
            int contractID = Convert.ToInt32(grvCompareRates.GetFocusedRowCellValue("ContractID"));//ContractID
            //if (this.frmContract == null || this.frmContract.IsDisposed)
            this.frmContract = new frm_MSS_Contracts(0, contractID);
            this.frmContract.InitData(0, contractID);
            this.frmContract.BringToFront();
            this.frmContract.WindowState = FormWindowState.Maximized;
            this.frmContract.Show();
        }
    }
}
