using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Controls;
using DA;

namespace UI.ReportForm
{
    public partial class frm_BR_OnHandDailyDetailPalletsEdit : frmBaseForm
    {
        private int stockOnHandDetailPalletID = 0;
        public frm_BR_OnHandDailyDetailPalletsEdit(int palletDetailID, string comments, bool isBilled)
        {
            InitializeComponent();
            this.stockOnHandDetailPalletID = palletDetailID;
            this.chkBilled.Checked = isBilled;
            this.txtComments.Text = comments;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DataProcess<object> StockDA = new DataProcess<object>();
            int result = StockDA.ExecuteNoQuery("STStockOnHandDailyDetailPalletsUpdateBilling @StockOnHandDailyDetailPalletID={0},@Billed={1},@BillingComments={2}",
                  stockOnHandDetailPalletID, this.chkBilled.Checked, this.txtComments.Text);
            this.Close();
        }
    }
}
