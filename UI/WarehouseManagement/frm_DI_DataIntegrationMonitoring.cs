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

namespace UI.WarehouseManagement
{
    public partial class frm_DI_DataIntegrationMonitoring : frmBaseFormNormal
    {

        public frm_DI_DataIntegrationMonitoring()
        {
            InitializeComponent();
            string fromDate = DateTime.Now.AddDays(-31).ToString("yyyy-MM-dd");
            string toDate = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
            this.dFromDate.DateTime = DateTime.Now.AddDays(-7);
            this.dToDate.DateTime = DateTime.Now.AddDays(1);
            DataProcess<Stores> dataProcess = new DataProcess<Stores>();
            this.lkeCustomers.Properties.DataSource = FileProcess.LoadTable("ST_WMS_LoadDataIntegrationCustomers") ;
            this.lkeCustomers.Properties.ValueMember = "CustomerID";
            this.lkeCustomers.Properties.DisplayMember = "CustomerNumber";
            
        }

        private void lkeCustomers_EditValueChanged(object sender, EventArgs e)
        {
            this.grcDatafiles.DataSource = FileProcess.LoadTable("WebDataIntegrationInbound " + this.lkeCustomers.EditValue + ",'" + this.dFromDate.DateTime.ToString("yyyy-MM-dd") 
                    + "','" + this.dToDate.DateTime.ToString("yyyy-MM-dd") + "'");
            this.txtCustomerName.Text = Convert.ToString(this.lkeCustomers.GetColumnValue("CustomerName"));
        }
    }
}
