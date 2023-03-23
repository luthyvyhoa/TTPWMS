using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.WarehouseManagement
{
    public partial class urc_WM_OutsourcedJobLinked : UserControl
    {
        public urc_WM_OutsourcedJobLinked(int CustomerID)
        {
            InitializeComponent();
            this.grcCustomerServiceWorks.DataSource = DA.FileProcess.LoadTable("ST_WMS_LoadCustomerServiceWorks " + CustomerID);
        }
    }
}
