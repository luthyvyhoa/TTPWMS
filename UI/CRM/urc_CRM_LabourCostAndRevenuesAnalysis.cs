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

namespace UI.CRM
{
    public partial class urc_CRM_LabourCostAndRevenuesAnalysis : UserControl
    {
        public urc_CRM_LabourCostAndRevenuesAnalysis(int CustomerID)
        {
            InitializeComponent();
            this.chartLabourRevenues.DataSource = FileProcess.LoadTable("OperatingCostSummary_LabourAnalysis12M " + CustomerID);
        }

        public void InitLabour(int CustomerID)
        {
            this.chartLabourRevenues.DataSource = FileProcess.LoadTable("OperatingCostSummary_LabourAnalysis12M " + CustomerID);
        }
    }
}
