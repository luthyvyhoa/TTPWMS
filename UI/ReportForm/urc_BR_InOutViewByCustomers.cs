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
    public partial class urc_BR_InOutViewByCustomers : UserControl
    {
        public urc_BR_InOutViewByCustomers(DateTime fromDate, DateTime toDate, int customerID)
        {
            InitializeComponent();

            this.grcInOutAllProducts.DataSource = FileProcess.LoadTable("STStockMovementInOutAllProducts '" + fromDate.ToString("yyyy-MM-dd") + "','" + toDate.ToString("yyyy-MM-dd") + "'," + customerID);
        }
    }
}
