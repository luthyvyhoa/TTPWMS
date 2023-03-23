using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.ReportForm
{
    public partial class urc_BR_IncorrectOrders : UserControl
    {
        public urc_BR_IncorrectOrders(Int32 CustomerID, DateTime FromDate, DateTime ToDate)

        {
            InitializeComponent();
            this.grcIncorrectOrders.DataSource = DA.FileProcess.LoadTable("STBillingByPalletInCorrectOrders " + CustomerID + ",'" + FromDate.ToString("yyyy-MM-dd") + "','" + ToDate.ToString("yyyy-MM-dd") + "'");
        }
    }
}
