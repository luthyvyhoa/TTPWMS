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

namespace UI.Supperviors
{
    public partial class frm_S_CustomerStock36months : frmBaseForm
    {
        public frm_S_CustomerStock36months(int CustomerID)
        {
            InitializeComponent();
            this.lkeCustomers.Properties.DataSource = FileProcess.LoadTable("STcomboCustomerID " + 0);
            this.lkeCustomers.Properties.ValueMember = "CustomerID";
            this.lkeCustomers.Properties.DisplayMember = "CustomerNumber";
            this.lkeCustomers.EditValue = CustomerID;
            if (CustomerID > 0)
            {
                var currentCus = AppSetting.CustomerListAll.Where(c => c.CustomerID == CustomerID).FirstOrDefault();
                if (currentCus == null) return;
                txtCustomerName.Text = currentCus.CustomerName;
                this.grcCustomerStock36months.DataSource = FileProcess.LoadTable("STCustomerForecastStock36Months " + Convert.ToString(CustomerID));
                //this.chartCustomerForecastStock36Months.DataSource = FileProcess.LoadTable("STCustomerForecastStock36Months " + Convert.ToString(CustomerID));

            }
            else
            {
                txtCustomerName.Text = "";
            }

        }

        private void lkeCustomers_EditValueChanged(object sender, EventArgs e)
        {
            int CustomerID = Convert.ToInt32(this.lkeCustomers.EditValue);
            var currentCus = AppSetting.CustomerListAll.Where(c => c.CustomerID == CustomerID).FirstOrDefault();
            if (currentCus == null) return;
            txtCustomerName.Text = currentCus.CustomerName;
            this.grcCustomerStock36months.DataSource = FileProcess.LoadTable("STCustomerForecastStock36Months " + Convert.ToString(CustomerID));
        }
    }
}
