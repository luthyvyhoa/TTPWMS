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
using UI.Helper;

namespace UI.MasterSystemSetup
{
    public partial class frm_MSS_CustomerChanged : frmBaseForm
    {
        public frm_MSS_CustomerChanged()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Get customerID will to changed
        /// </summary>
        public int CustomerID { get; private set; }

        private void frm_MSS_CustomerChanged_Load(object sender, EventArgs e)
        {
            this.lkeCustomer.Properties.DataSource = AppSetting.CustomerListAll;
            this.lkeCustomer.Properties.DisplayMember = "CustomerNumber";
            this.lkeCustomer.Properties.ValueMember = "CustomerID";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(this.lkeCustomer.EditValue==null)
            {
                this.lkeCustomer.Focus();
                this.lkeCustomer.ShowPopup();
                return;
            }

            this.CustomerID = Convert.ToInt32(this.lkeCustomer.EditValue);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
