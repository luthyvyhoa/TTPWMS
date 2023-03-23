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

namespace UI.WarehouseManagement
{
    public partial class urc_WM_ServicesWorksRecent : UserControl
    {
        public urc_WM_ServicesWorksRecent(int CustomerID)
        {
            InitializeComponent();
            this.grcServices.DataSource = FileProcess.LoadTable("ST_WMS_LoadServicesRecent " + CustomerID);
            this.grcWorks.DataSource = FileProcess.LoadTable("ST_WMS_LoadWorksRecent " + CustomerID);
        }
    }
}
