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

namespace UI.WarehouseManagement
{
    public partial class frm_WM_RoutePlanning : Form
    {
        public frm_WM_RoutePlanning()
        {
            InitializeComponent();

            this.dateEditReportDate.EditValue = DateTime.Today;
            this.lookUpEditCustomerID.Properties.DataSource = FileProcess.LoadTable("STcomboCustomerIDAll");
            this.lookUpEditCustomerID.Properties.ValueMember = "CustomerID";
            this.lookUpEditCustomerID.Properties.DisplayMember = "CustomerNumber";
            this.lookUpEditCustomerID.EditValue = 0;
        }

        private void lookUpEditCustomerID_Properties_EditValueChanged(object sender, EventArgs e)
        {
            if (this.lookUpEditCustomerID.EditValue == null || Convert.ToInt32(this.lookUpEditCustomerID.EditValue) == 0) return;
            this.textEditCustomerName.Text = this.lookUpEditCustomerID.GetColumnValue("CustomerName").ToString();
            Int32 CustomerID = Convert.ToInt32(this.lookUpEditCustomerID.EditValue);
            String ReportDate = Convert.ToDateTime(dateEditReportDate.EditValue.ToString()).ToString("yyyy-MM-dd");
            this.grdDispatchinOrdersSelect.DataSource = FileProcess.LoadTable("STCustomerDeliveryRoutePlanningOrders " + CustomerID + ",'" + ReportDate + "'");
        }
    }
}
