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

namespace UI.MasterSystemSetup
{
    public partial class urc_MSS_SubCustomers : UserControl
    {
        private int _customerMainID;

        public int CustomerMainID
        {
            get
            {
                return _customerMainID;
            }

            set
            {
                _customerMainID = value;
                LoadData();
            }
        }

        public urc_MSS_SubCustomers(int customerMainID)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this._customerMainID = customerMainID;
            LoadData();
        }


        private void LoadData()
        {
            this.grdSubCustomers.DataSource = AppSetting.CustomerList.Where(c => c.CustomerMainID == this._customerMainID);
        }
    }
}
