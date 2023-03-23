using DA;
using DevExpress.Data;
using DevExpress.XtraGrid.Views.Grid;
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
    public partial class frm_WM_Dialog_ReceivingAdvice : Form
    {
        public frm_WM_Dialog_ReceivingAdvice()
        {
            InitializeComponent();
        }
        public frm_WM_Dialog_ReceivingAdvice(int i_ReceivingOrderID)
        {
            InitializeComponent();

            this.grdReceivingAdvice.DataSource =FileProcess.LoadTable( "STReceivingAdviceHistory @varReceivingOrderID="+ i_ReceivingOrderID);

        }

        List<string> values;
        private void grvReceivingAdviceViewTable_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            GridView gv = sender as GridView;

            if (e.SummaryProcess == CustomSummaryProcess.Start)
                values = new List<string>();

            if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                values.Add(gv.GetRowCellValue(e.RowHandle, gv.Columns["Label"]).ToString());

            if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                if (e.IsGroupSummary)
                    e.TotalValue = values.Distinct().Count();
        }
    }
}
