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
    public partial class frm_WM_ContainerCheckings : Form
    {
        public frm_WM_ContainerCheckings(int ContainerInOutID)
        {
            InitializeComponent();
            this.grdContainerCheckings.DataSource = FileProcess.LoadTable("STGate_ContainerCheckingsByContInOutID " + ContainerInOutID);
        }
    }
}
