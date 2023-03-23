using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Helper;
using DevExpress.XtraEditors;

namespace UI.WarehouseManagement
{
    public partial class urc_WM_FindProduct : UserControl
    {

        public urc_WM_FindProduct()
        {
            InitializeComponent();
        }

        private void urc_WM_FindProduct_Load(object sender, EventArgs e)
        {
            InitCustomers();
            SetEvents();
        }

        private void SetEvents()
        {
            this.chkStockOnHand.CheckedChanged += chkStockOnHand_CheckedChanged;
            this.chkNameOnHand.CheckedChanged += chkNameOnHand_CheckedChanged;
        }

        private void InitCustomers()
        {
            this.lkeCustomers.Properties.DataSource = AppSetting.CustomerList;
            this.lkeCustomers.Properties.ValueMember = "CustomerID";
            this.lkeCustomers.Properties.DisplayMember = "CustomerNumber";
        }

        private void chkNameOnHand_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNameOnHand.Checked)
            {
                if (String.IsNullOrEmpty(this.txtProductName.Text))
                {
                    XtraMessageBox.Show("Please enter the Product Name to find !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.chkNameOnHand.Checked = false;
                }
                else
                {
                    if (chkStockOnHand.Checked)
                    {
                        XtraMessageBox.Show("Can not find !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.chkNameOnHand.Checked = false;
                    }
                }
            }
        }

        private void chkStockOnHand_CheckedChanged(object sender, EventArgs e)
        {
            if(chkStockOnHand.Checked)
            {
                if(String.IsNullOrEmpty(this.txtProductID.Text))
                {
                    XtraMessageBox.Show("Please enter the Product ID to find !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.chkStockOnHand.Checked = false;
                }
                else
                {
                    if(chkNameOnHand.Checked)
                    {
                        XtraMessageBox.Show("Can not find !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.chkStockOnHand.Checked = false;
                    }
                }
            }
        }
    }
}
