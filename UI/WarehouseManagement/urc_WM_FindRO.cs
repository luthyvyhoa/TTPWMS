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

namespace UI.WarehouseManagement
{
    public partial class urc_WM_FindRO : UserControl
    {
        public int ReceivingOrderID
        {
            get
            {
                if(String.IsNullOrEmpty(this.txtROID.Text))
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(this.txtROID.Text);
                }
            }
        }

        public int CustomerID
        {
            get
            {
                if(this.lkeCustomers.EditValue == null)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(this.lkeCustomers.EditValue);
                }
            }
        }

        public DateTime FromDate
        {
            get
            {
                if(dtFrom.EditValue == null)
                {
                    return new DateTime(2000, 1, 1);
                }
                else
                {
                    return this.dtFrom.DateTime;
                }
            }
        }

        public DateTime ToDate
        {
            get
            {
                if(this.dtTo.EditValue == null)
                {
                    return DateTime.Now;
                }
                else
                {
                    return this.dtTo.DateTime;
                }
            }
        }

        public urc_WM_FindRO()
        {
            InitializeComponent();
        }

        private void urc_WM_FindRO_Load(object sender, EventArgs e)
        {
            InitCustomers();
            SetEvents();
        }

        private void SetEvents()
        {
            this.lkeCustomers.EditValueChanged += lkeCustomers_EditValueChanged;
        }

        void InitCustomers()
        {
            this.lkeCustomers.Properties.DataSource = AppSetting.CustomerList;
            this.lkeCustomers.Properties.ValueMember = "CustomerID";
            this.lkeCustomers.Properties.DisplayMember = "CustomerNumber";
        }

        private void lkeCustomers_EditValueChanged(object sender, EventArgs e)
        {
            this.txtCustomerName.Text = Convert.ToString(this.lkeCustomers.GetColumnValue("CustomerName"));
        }
    }
}
