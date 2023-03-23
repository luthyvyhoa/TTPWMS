using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DA;
using UI.Helper;

namespace UI.WarehouseManagement
{
    public partial class urc_WM_FindCustomer : UserControl
    {
        private Customers _selectedCustomer;

        public Customers SelectedCustomer
        {
            get
            {
                return _selectedCustomer;
            }
        }

        public urc_WM_FindCustomer()
        {
            InitializeComponent();
            this._selectedCustomer = new Customers();
        }

        private void urc_WM_FindCustomer_Load(object sender, EventArgs e)
        {
            InitCustomer();

            SetEvents();
        }

        private void SetEvents()
        {
            this.lkeCustomers.EditValueChanged += lkeCustomers_EditValueChanged;
        }

        private void InitCustomer()
        {
            this.lkeCustomers.Properties.DataSource = AppSetting.CustomerList;
            this.lkeCustomers.Properties.ValueMember = "CustomerID";
            this.lkeCustomers.Properties.DisplayMember = "CustomerNumber";
        }

        private void lkeCustomers_EditValueChanged(object sender, EventArgs e)
        {
            this._selectedCustomer = AppSetting.CustomerList.Where(c => c.CustomerID == Convert.ToInt32(this.lkeCustomers.EditValue)).FirstOrDefault();
            this.txtInitial.Text = this._selectedCustomer.Initial;
            this.txtCustomerName.Text = this._selectedCustomer.CustomerName;
            this.mmeCustomerInfo.Text = "Tel1: " + this._selectedCustomer.Phone1 + "\nTel2: " + this._selectedCustomer.Phone2 + "\nFax: " + this._selectedCustomer.Fax + "\nContact: " + this._selectedCustomer.PrimaryContact + ", " + this._selectedCustomer.OtherContacts + "\nAddress: " + this._selectedCustomer.Address + ", " + this._selectedCustomer.MarketingInfor;
        }
    }
}
