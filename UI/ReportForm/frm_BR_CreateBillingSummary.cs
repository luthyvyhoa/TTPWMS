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
using UI.Helper;

namespace UI.ReportForm
{
    public partial class frm_BR_CreateBillingSummary : frmBaseForm
    {
        private DataProcess<BillingSummary> dp = new DataProcess<BillingSummary>();
        private SwireDBEntities context = new SwireDBEntities();
        public frm_BR_CreateBillingSummary()
        {
            InitializeComponent();

            setDefaultPeriod();
        }

        private void setDefaultPeriod()
        {
            DateTime now = DateTime.Now;
            dtPeriod.EditValue = new DateTime(now.AddDays(5).Year, now.Month, 1).AddDays(-1);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DateTime selectedPeriod = Convert.ToDateTime(dtPeriod.EditValue);
            string varPeriod = selectedPeriod.Month.ToString() + "-" + selectedPeriod.Year.ToString();
            DateTime varPeriodDate = new DateTime(selectedPeriod.Year, selectedPeriod.Month, 1);            
            int dayOfMonth = DateTime.DaysInMonth(varPeriodDate.Year, varPeriodDate.Month);            
            if (varPeriodDate > DateTime.Now.AddDays(-dayOfMonth) && DateTime.Now.Day < 26)
            {
                MessageBox.Show("Can not create report for this period !", "WMS-2022",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                DateTime maxToDate = dp.Select().OrderByDescending(x => x.ToDate).FirstOrDefault().ToDate;
                if (maxToDate >= varPeriodDate)
                {
                    MessageBox.Show("The period you request does exist, Please delete before create report for this period !", "WMS-2022",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Execute store STBillingSummaryInsert
                    DateTime fromDate = varPeriodDate;
                    DateTime toDate = new DateTime(varPeriodDate.AddDays(33).Year, varPeriodDate.AddDays(33).Month, 1).AddDays(-1);
                    int result = context.STBillingSummaryInsert(fromDate, toDate, varPeriod, AppSetting.CurrentUser.LoginName);
                    if (result <= -2)
                    {
                        MessageBox.Show("Fail to execute store STBillingSummaryInsert!", "WMS-2022",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    // Execute store SP_DSBillingSummaryInsert (STDSBillingSummaryInsert)
                    DataProcess<object> objInsert = new DataProcess<object>();
                    int flag = objInsert.ExecuteNoQuery("STDSBillingSummaryInsert @FromDate = {0}, @Todate = {1}", fromDate.ToString("yyyy-MM-dd"), toDate.ToString("yyyy-MM-dd"));
                    if (flag <= -2)
                    {
                        MessageBox.Show("Fail to execute store STDSBillingSummaryInsert!", "WMS-2022",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
