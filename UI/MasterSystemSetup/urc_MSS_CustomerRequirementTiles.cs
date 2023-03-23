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

namespace UI.MasterSystemSetup
{
    public partial class urc_MSS_CustomerRequirementTiles : UserControl
    {
        private int customerIDSelected;
        private DataProcess<ST_WMS_LoadCustomerRequirements_Result> dataProcess = new DataProcess<ST_WMS_LoadCustomerRequirements_Result>();
        public urc_MSS_CustomerRequirementTiles(int CustomerID)
        {
            this.customerIDSelected = CustomerID;
            InitializeComponent();
            // Init data
            this.InitData(CustomerID);
           // this.grcCustomerRequirementTiles.DataSource = FileProcess.LoadTable("ST_WMS_LoadCustomerRequirements " + CustomerID);
        }
        public void InitData(int customerID)
        {

            BindingList<ST_WMS_LoadCustomerRequirements_Result> bindingList = new BindingList<ST_WMS_LoadCustomerRequirements_Result>(this.dataProcess.Executing("ST_WMS_LoadCustomerRequirements " + customerID).ToList());
            this.grcCustomerRequirementTiles.DataSource = bindingList;
        }
    }
}
