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
    public partial class frm_BR_BillingCheckBreakdown : Common.Controls.frmBaseForm
    {
        public frm_BR_BillingCheckBreakdown()
        {
            InitializeComponent();
        }

        private void frm_BR_BillingCheckBreakdown_Load(object sender, EventArgs e)
        {
            this.dtFrom.EditValue = FirstDayOfPreviousMonth().AddMonths(-3);
            this.dtTo.EditValue = FirstDayOfPreviousMonth().AddMonths(3);

            SetEvents();
        }

        private void SetEvents()
        {
            this.btnClose.Click += BtnClose_Click;
            this.btnViewResult.Click += BtnViewResult_Click;
        }

        private void BtnViewResult_Click(object sender, EventArgs e)
        {
            frm_BR_Dialog_BillingCheckBreakdownResult frm = new frm_BR_Dialog_BillingCheckBreakdownResult(this.dtFrom.DateTime, this.dtTo.DateTime);
            frm.Show();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private DateTime FirstDayOfPreviousMonth()
        {
            DateTime date;

            if(DateTime.Now.Day > 27) // Cuối tháng
            {
                date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            }
            else
            {
                if(DateTime.Now.Day > 5) // Trong tháng
                {
                    date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                }
                else // Đầu tháng
                {
                    if(DateTime.Now.Month == 1)
                    {
                        date = new DateTime(DateTime.Now.Year - 1, 12, 1);
                    }
                    else
                    {
                        date = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, 1);
                    }
                }
            }

            return date;
        }
    }
}
