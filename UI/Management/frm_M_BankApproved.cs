using Common.Controls;
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

namespace UI.Management
{
    public partial class frm_M_BankApproved : frmBaseForm
    {
        public frm_M_BankApproved()
        {
            InitializeComponent();
            this.initCustomer();
            //this.Enabled = true;
        }

        private void initCustomer()
        {
            lookupEditCustomer.Properties.DataSource = AppSetting.CustomerList;
            lookupEditCustomer.Properties.ValueMember = "CustomerID";
            lookupEditCustomer.Properties.DisplayMember = "CustomerNumber";
        }

        private void lookupEditCustomer_EditValueChanged(object sender, EventArgs e)
        {
            if (this.lookupEditCustomer.EditValue == null || Convert.ToInt32(this.lookupEditCustomer.EditValue) == 0) return;
            var customerName = FileProcess.LoadTable("select CustomerName from customers where customerid=" + Convert.ToInt32(this.lookupEditCustomer.EditValue)).Rows[0]["CustomerName"];
            labelControlCustomerName.Text = Convert.ToString(customerName);

            this.grdMortgage.DataSource = FileProcess.LoadTable($"SP_PalletOnHoldBankingByCustomerID @CustomerID={this.lookupEditCustomer.EditValue}");
        }
    }
}
