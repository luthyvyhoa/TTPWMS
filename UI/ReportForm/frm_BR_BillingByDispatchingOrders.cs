using DA;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Helper;
using UI.ReportFile;

namespace UI.ReportForm
{
    public partial class frm_BR_BillingByDispatchingOrders : Common.Controls.frmBaseForm
    {
        private DataProcess<STBillingRunByDispatchingOrdersDOList_Result> _billingDA;
        private DataProcess<tmpBillingRunByDispatchingOrders> _billingDODA;
        private List<tmpBillingRunByDispatchingOrders> _listBillingDO;
        private rptBillingByDispatchingOrders _billingByDOReport;

        public frm_BR_BillingByDispatchingOrders()
        {
            InitializeComponent();
            this.IsFixHeightScreen = false;
            this._billingDA = new DataProcess<STBillingRunByDispatchingOrdersDOList_Result>();
            this._billingByDOReport = new rptBillingByDispatchingOrders();
            this._billingDODA = new DataProcess<tmpBillingRunByDispatchingOrders>();
            this._listBillingDO = new List<tmpBillingRunByDispatchingOrders>();
        }

        private void frm_BR_BillingByDispatchingOrders_Load(object sender, EventArgs e)
        {
            InitCustomer();
            this.dtFromDate.EditValue = DateTime.Now.AddDays(-30);
            this.dtToDate.EditValue = DateTime.Now;
            SetEvents();
        }

        private void frm_BR_BillingByDispatchingOrders_Shown(object sender, EventArgs e)
        {
            this.lkeCustomer.Focus();
            this.lkeCustomer.ShowPopup();
        }

        private void SetEvents()
        {
            this.lkeCustomer.CloseUp += LkeCustomer_CloseUp;
            this.btnViewReport.Click += BtnViewReport_Click;
            this.btnEmailReport.Click += BtnEmailReport_Click;
            this.btnClose.Click += BtnClose_Click;
            this.btnFaxReport.Click += BtnFaxReport_Click;
        }

        #region Events
        private void LkeCustomer_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            this.txtCustomerName.Text = Convert.ToString(this.lkeCustomer.GetColumnValue("CustomerName"));
            LoadData();
        }

        private void BtnFaxReport_Click(object sender, EventArgs e)
        {
            //Do nothing
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnEmailReport_Click(object sender, EventArgs e)
        {
            if (this.lkeCustomer.EditValue == null) return;
            string email = AppSetting.CustomerList.Where(c => c.CustomerID == Convert.ToInt32(this.lkeCustomer.EditValue)).FirstOrDefault().Email;

            if (String.IsNullOrEmpty(email))
            {
                XtraMessageBox.Show("This Customer does not have e-mail address !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                XtraMessageBox.SmartTextWrap = true;
                DialogResult result = XtraMessageBox.Show("Send report to the address : " + email + " ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (UpdateReportData() != -2)
                    {
                        SendMail(email, this._billingByDOReport, "SCS VN Report - Billing By Dispatching Orders - " + this.txtCustomerName.Text);
                    }
                    else
                    {
                        XtraMessageBox.Show("Upexpected Error !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

        private void BtnViewReport_Click(object sender, EventArgs e)
        {
            if (UpdateReportData() != -2)
            {
                if(this._listBillingDO.Count > 0)
                {
                    ReportPrintToolWMS tool = new ReportPrintToolWMS(_billingByDOReport);
                    tool.ShowPreview();
                }
                else
                {
                    XtraMessageBox.Show("No data to print !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                XtraMessageBox.Show("Upexpected Error !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Load Data
        private void LoadData()
        {
            try
            {
                this.grdDispatchingOrder.DataSource = this._billingDA.Executing("STBillingRunByDispatchingOrdersDOList @FromDate = {0}, @Todate = {1}, @CustomerID = {2}", dtFromDate.DateTime, dtToDate.DateTime, Convert.ToInt32(this.lkeCustomer.EditValue));
                //this.grdDispatchingOrder.DataSource = FileProcess.LoadTable("STBillingRunByDispatchingOrdersDOList @FromDate = '" + this.dtFromDate.DateTime.ToString("yyyy-MM-dd") + "', @Todate = '" + this.dtToDate.DateTime.ToString("yyyy-MM-dd") + "', @CustomerID = " + Convert.ToInt32(this.lkeCustomer.EditValue));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void InitCustomer()
        {
            this.lkeCustomer.Properties.DataSource = AppSetting.CustomerList;
            this.lkeCustomer.Properties.ValueMember = "CustomerID";
            this.lkeCustomer.Properties.DisplayMember = "CustomerNumber";
        }

        #endregion

        private string GetSelectedDO()
        {
            string listDO = "(1, ";
            int[] rowHandles = this.grvDispatchingOrder.GetSelectedRows();

            for (int i = 0; i < rowHandles.Count(); i++)
            {
                if (i == rowHandles.Count() - 1)
                {
                    listDO = listDO + this.grvDispatchingOrder.GetRowCellValue(rowHandles[i], "DispatchingOrderID") + ")";
                }
                else
                {
                    listDO = listDO + this.grvDispatchingOrder.GetRowCellValue(rowHandles[i], "DispatchingOrderID") + ", ";
                }
            }

            return listDO;
        }

        private int UpdateReportData()
        {
            string condition = "";
            int result = -2;

            if (this.grvDispatchingOrder.SelectedRowsCount <= 0)
            {
                XtraMessageBox.Show("Please select order !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                condition = GetSelectedDO();

                result = this._billingDA.ExecuteNoQuery("STBillingRunByDispatchingOrders @varCondition = {0}", condition);
            }

            if(result != -2)
            {
                this._listBillingDO = this._billingDODA.Select().ToList();

                this._billingByDOReport.DataSource = this._listBillingDO;
            }

            return result;
        }

        /// <summary>
        /// Send attachment to customers
        /// </summary>
        private void SendMail(string toEmail, XtraReport report, string subject, int formatType = 0)
        {
            try
            {
                string fileExtension = "rtf";
                string boby = "Stock Report From SCS VN";
                using (MemoryStream mem = new MemoryStream())
                {

                    if (formatType == 0)
                    {
                        report.ExportToRtf(mem);
                        fileExtension = "rtf";
                    }
                    else
                    {
                        report.ExportToXlsx(mem);
                        fileExtension = "xlsx";
                    }

                    mem.Seek(0, SeekOrigin.Begin);
                    Attachment att = new Attachment(mem, "Stock Report From SCS VN." + fileExtension, "application/" + fileExtension);
                    Common.Process.DataTransfer.SendMail(toEmail, subject, boby, att);
                }

                XtraMessageBox.Show("Email sent successful!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Send failed!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
