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

namespace UI.ReportForm
{
    public partial class urc_BR_InccorectLocations : UserControl
    {
        public urc_BR_InccorectLocations(Int32 CustomerMainID, DateTime FromDate, DateTime ToDate)
        {
            InitializeComponent();
            this.grcIncorrectOrders.DataSource = FileProcess.LoadTable("STBillingReportIncorrectLocations " + CustomerMainID + ",'" + FromDate.ToString("yyyy-MM-dd") + "','" + ToDate.ToString("yyyy-MM-dd") + "'");
        }
    }
}
