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

namespace UI.WarehouseManagement
{
    public partial class frm_WM_MHLWorkEmployeeSummary : frmBaseForm
    {
        private DataProcess<STMHLWorkEmployeeSalary_Result> mhlWorkEmployeeSalaryDataProcess = new DataProcess<STMHLWorkEmployeeSalary_Result>();
        private DataProcess<STMHLWorkEmployeeDetail_Result> mhlWorkEmployeeDetailDataProcess = new DataProcess<STMHLWorkEmployeeDetail_Result>();
        private DataProcess<STMHLWorkEmployeeSummary_Result> mhlWorkEmployeeSummaryDataProcess = new DataProcess<STMHLWorkEmployeeSummary_Result>();
        private DataProcess<PayrollMonth> payrollMonthDataProcess = new DataProcess<PayrollMonth>();
        private int currentPayRollMonthID = 0;
        public frm_WM_MHLWorkEmployeeSummary(int payRollMonthID)
        {
            InitializeComponent();

            // Init data for all controls
            initData(payRollMonthID);
        }

        public void initData(int payRollMonthID)
        {
            // Set value for PayRollMonthID of current work 
            currentPayRollMonthID = payRollMonthID;

            // Get data for left grid
            IList<STMHLWorkEmployeeSummary_Result> items = mhlWorkEmployeeSummaryDataProcess.Executing("STMHLWorkEmployeeSummary @PayRollMonthID = {0}", currentPayRollMonthID).OrderByDescending(w => w.Total).ToList();
            grdSubMHLWorkEmployeeSummary.DataSource = items;

            // Get 12 items for MonthID combobox
            IList<PayrollMonth> months = payrollMonthDataProcess.Select().ToList().OrderByDescending(w => w.PayRollMonthID).Take(12).ToList();
            lkeMonthID.Properties.DataSource = months;
            lkeMonthID.Properties.DisplayMember = "PayRollMonth1";
            lkeMonthID.Properties.ValueMember = "PayRollMonthID";
            lkeMonthID.Focus();
            lkeMonthID.ShowPopup();

            // Set default option for radio group
            radgPayments.SelectedIndex = 0;
            this.lkeMonthID.Focus();
            this.ActiveControl = this.lkeMonthID;
        }

        private double getTotalSum(IList<STMHLWorkEmployeeSummary_Result> list)
        {
            double result = 0;
            foreach (STMHLWorkEmployeeSummary_Result item in list)
            {
                result += (double)item.Total;
            }
            return result;
        }

        private void grvSubMHLWorkEmployeeSummary_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            IList<STMHLWorkEmployeeSummary_Result> rows = (IList<STMHLWorkEmployeeSummary_Result>)grvSubMHLWorkEmployeeSummary.DataSource;
            txtEmployeeID.Text = rows[e.FocusedRowHandle].EmployeeID.ToString();
            txtVietnamName.Text = rows[e.FocusedRowHandle].VietnamName.ToString();
            if (txtFromDate.Text != null && txtFromDate.Text != "")
            {
                refresRightGrid();
            }
        }

        private void refresRightGrid()
        {
            IList<STMHLWorkEmployeeDetail_Result> items = mhlWorkEmployeeDetailDataProcess.Executing("STMHLWorkEmployeeDetail @FromDate = {0}, @ToDate = {1}, @EmployeeID = {2}", txtFromDate.Text, txtToDate.Text, Int32.Parse(txtEmployeeID.Text)).ToList();
            grdSubMHLWorkEmployeeSummaryDetails.DataSource = items;
        }

        private double getDetailQuantitySum(IList<STMHLWorkEmployeeDetail_Result> list)
        {
            double result = 0;
            foreach (STMHLWorkEmployeeDetail_Result item in list)
            {
                result += (double)item.Quantity;
            }
            return result;
        }

        private double getDetailMoneySum(IList<STMHLWorkEmployeeDetail_Result> list)
        {
            double result = 0;
            foreach (STMHLWorkEmployeeDetail_Result item in list)
            {
                result += (double)item.Total;
            }
            return result;
        }

        private void lkeMonthID_TextChanged(object sender, EventArgs e)
        {
            int findID = Int32.Parse(lkeMonthID.EditValue.ToString());
            PayrollMonth choseMonth = payrollMonthDataProcess.Select(w => w.PayRollMonthID == findID).FirstOrDefault();
            txtFromDate.Text = Convert.ToDateTime(choseMonth.FromDate.ToString()).ToString("M/dd/yyyy");
            txtToDate.Text = Convert.ToDateTime(choseMonth.ToDate.ToString()).ToString("M/dd/yyyy");
            refreshLeftGrid();
        }

        private void refreshLeftGrid()
        {
            // Execute store STMHLWorkEmployeeSummary to update grid
            int monthID = (int)lkeMonthID.EditValue;
            var items = mhlWorkEmployeeSummaryDataProcess.Executing("STMHLWorkEmployeeSummary @PayRollMonthID =" + monthID);
            grdSubMHLWorkEmployeeSummary.DataSource = items;
        }

        private void btnCommandclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rpi_btn_View_Click(object sender, EventArgs e)
        {
            // Back to parent form and display selected row
            this.Visible = false;

        }

        private void frm_WM_MHLWorkEmployeeSummary_Load(object sender, EventArgs e)
        {
            lkeMonthID.Focus();
            lkeMonthID.ShowPopup();
        }

        private void btnCommandViewByWork_Click(object sender, EventArgs e)
        {
            if (lkeMonthID.Text == null || lkeMonthID.Text == "")
            {
                lkeMonthID.Focus();
                lkeMonthID.ShowPopup();
            }
            else
            {
                // Execute store STMHLWorkRecordingByWorkReport
                this.Visible = false;
                // DoCmd.OpenReport "rptMHLWorkRecordingByWork", acViewPreview
            }
        }

        private void btnCommandSalary_Click(object sender, EventArgs e)
        {
            if (lkeMonthID.Text == null || lkeMonthID.Text == "")
            {
                lkeMonthID.Focus();
                lkeMonthID.ShowPopup();
            }
            else
            {
                // Execute store STMHLWorkEmployeeSalary
                IList<STMHLWorkEmployeeSalary_Result> items = mhlWorkEmployeeSalaryDataProcess.Executing("STMHLWorkEmployeeSalary @FromDate = {0}, @ToDate = {1}, @EmployeeID = {2}", txtFromDate.Text, txtToDate.Text, Int32.Parse(txtEmployeeID.Text)).ToList();
                // FIXME: Open report
                // DoCmd.OpenReport "rptMHLWorkEmployeeSalary", acViewPreview
            }
        }

        private void radgPayments_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Filter data for left grid
            if (lkeMonthID.EditValue != null && lkeMonthID.EditValue.ToString() != "")
            {
                IList<STMHLWorkEmployeeSummary_Result> items = mhlWorkEmployeeSummaryDataProcess.Executing("STMHLWorkEmployeeSummary @PayRollMonthID = {0}", Int32.Parse(lkeMonthID.EditValue.ToString())).OrderBy(w => w.EmployeeID).ToList();


                if (lkeMonthID.Text == null || lkeMonthID.Text == "")
                {
                    return;
                }
                switch (radgPayments.SelectedIndex)
                {
                    // All
                    case 0:
                        {
                            grdSubMHLWorkEmployeeSummary.DataSource = items;
                            break;
                        }
                    // Cash
                    case 1:
                        {
                            items = items.Where(w => w.IsBirthday == false).ToList();
                            grdSubMHLWorkEmployeeSummary.DataSource = items;
                            break;
                        }
                    // Transfer
                    case 2:
                        {
                            items = items.Where(w => w.IsBirthday == true).ToList();
                            grdSubMHLWorkEmployeeSummary.DataSource = items;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }

        private void frm_WM_MHLWorkEmployeeSummary_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
    }
}
