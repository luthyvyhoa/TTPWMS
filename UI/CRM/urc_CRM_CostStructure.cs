using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.CRM
{
    public partial class urc_CRM_CostStructure : UserControl
    {
        public urc_CRM_CostStructure(int CustomerID)
        {
            InitializeComponent();
            this.chartControlCostStructure.DataSource = DA.FileProcess.LoadTable("OperatingCostSummary_CostStructure " + CustomerID);
        }
        public void InitCostStructure(int CustomerID)
        {
            this.chartControlCostStructure.DataSource = DA.FileProcess.LoadTable("OperatingCostSummary_CostStructure " + CustomerID);
        }
    }
}
