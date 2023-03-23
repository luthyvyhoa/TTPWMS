using Common.Controls;
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

namespace UI.ReportForm
{
    public partial class frm_BR_BillingSummaryCrosstap : frmBaseForm
    {
        public frm_BR_BillingSummaryCrosstap(List<WebBillingSummaryCrosstap_Result> list)
        {
            InitializeComponent();

            InitDataForGrid(list);
        }

        private void InitDataForGrid(List<WebBillingSummaryCrosstap_Result> list)
        {
            grdBillingSummaryCrossTap.DataSource = list;
        }


    }
}
