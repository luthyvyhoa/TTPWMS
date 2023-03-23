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
    public partial class frm_BR_Dialog_BillingByProduct : Common.Controls.frmBaseForm
    {
        private DataTable _source;
        private DateTime _from;
        private DateTime _to;
        private rptBillingByProduct _rpt;
        private rptOtherServiceHWByOvertimes _rptHWByOvertimes;
        private string query;
        private string recevingOrderNumber = string.Empty;
        private string recevingDate = string.Empty;
        private string requirements = string.Empty;
        public frm_BR_Dialog_BillingByProduct(DateTime from, DateTime to, string query)
        {
            InitializeComponent();
            this._source = new DataTable();
            this._from = from;
            this.query = query;
            this._to = to;
            this._rpt = null;
        }

        public frm_BR_Dialog_BillingByProduct(DateTime from, DateTime to, string query, string recevingOrderNumber,
            string receivingDate, string requirements)
        {
            InitializeComponent();
            this._source = new DataTable();
            this._from = from;
            this.query = query;
            this._to = to;
            this._rpt = null;
            this.recevingOrderNumber = recevingOrderNumber;
            this.recevingDate = receivingDate;
            this.requirements = requirements;
        }

        private void frm_BR_Dialog_BillingByProduct_Load(object sender, EventArgs e)
        {
            LoadProducts();
            SetEvents();
        }

        private void SetEvents()
        {
            this.btnEmail.Click += BtnEmail_Click;
            this.btnView.Click += BtnView_Click;
        }

        private void BtnView_Click(object sender, EventArgs e)
        {
            if (this.grvProducts.SelectedRowsCount <= 0)
            {
                XtraMessageBox.Show("Please select products !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DataTable tbProducts = new DataTable();
                tbProducts.Columns.Add("ProductNumber");
                tbProducts.Columns.Add("ProductName");
                DataRow newRow = null;
                DataProcess<object> billingDA = new DataProcess<object>();
                DataProcess<object> billingBB = new DataProcess<object>();
                string condition = "(";
                int[] rowHandles = this.grvProducts.GetSelectedRows();

                for (int i = 0; i < rowHandles.Count(); i++)
                {
                    newRow = tbProducts.NewRow();
                    if (i == rowHandles.Count() - 1)
                    {
                        condition = condition + Convert.ToInt32(this.grvProducts.GetRowCellValue(rowHandles[i], "ProductID")) + ")";
                        newRow["ProductNumber"] = this.grvProducts.GetRowCellValue(rowHandles[i], "XXX");
                        newRow["ProductName"] = this.grvProducts.GetRowCellValue(rowHandles[i], "ProductName");
                    }
                    else
                    {
                        condition = condition + Convert.ToInt32(this.grvProducts.GetRowCellValue(rowHandles[i], "ProductID")) + ", ";
                        newRow["ProductNumber"] = this.grvProducts.GetRowCellValue(rowHandles[i], "XXX");
                        newRow["ProductName"] = this.grvProducts.GetRowCellValue(rowHandles[i], "ProductName");
                    }
                    tbProducts.Rows.Add(newRow);
                }

                int result = billingDA.ExecuteNoQuery("STBillingRunByProducts @varFromDate = {0}, @varTodate = {1}, @varCondition = {2}, @EmployeeID = {3}",
                    this._from.ToString("yyyy-MM-dd"), this._to.ToString("yyyy-MM-dd"), condition, AppSetting.CurrentUser.EmployeeID);

                subrptBillingByProducts subrpt = new subrptBillingByProducts();
                subrpt.DataSource = tbProducts;
                rptBillingByProductByRO rptProductByRO = new rptBillingByProductByRO(this._from, this._to, this.recevingOrderNumber, this.recevingDate, this.requirements);
                var reportSource= FileProcess.LoadTable("SELECT tmpBillingReport.BillingDateID, tmpBillingReport.ReportDate, tmpBillingReport.BeginC, "
                    + " tmpBillingReport.BeginW, tmpBillingReport.InC, tmpBillingReport.InW, tmpBillingReport.OutC, tmpBillingReport.OutW, "
                    + " tmpBillingReport.CloseC, tmpBillingReport.CloseW, tmpBillingReport.CustomerID,tmpBillingReport.BeginP, tmpBillingReport.InP, tmpBillingReport.OutP,"
                    + " tmpBillingReport.CloseP, tmpBillingReport.EmployeeID, tmpBillingReport.BillingCustomerID"
                    + " FROM tmpBillingReport"
                    + " WHERE tmpBillingReport.EmployeeID = " + AppSetting.CurrentUser.EmployeeID
                    + " ORDER BY tmpBillingReport.ReportDate ");
                rptProductByRO.DataSource = reportSource;
                rptProductByRO.xrSubProducts.ReportSource = subrpt;
                rptProductByRO.CreateDocument();
                ReportPrintToolWMS tool = new ReportPrintToolWMS(rptProductByRO);
                tool.ShowPreview();


                
                var dataSource = FileProcess.LoadTable("STBillingByOvertimeReportByProducts '" + this._from.ToString("yyyy-MM-dd") + "','" + this._to.ToString("yyyy-MM-dd") + "','" + condition + "'");
                
                if (dataSource != null )
                {
                    _rptHWByOvertimes = new rptOtherServiceHWByOvertimes(0);
                    _rptHWByOvertimes.DataSource = dataSource;
                    _rptHWByOvertimes.CreateDocument();
                    ReportPrintToolWMS tool2 = new ReportPrintToolWMS(_rptHWByOvertimes);
                    tool2.ShowPreview();
                }



            }
        }

        private void BtnEmail_Click(object sender, EventArgs e)
        {
            var source = FileProcess.LoadTable("Select * From tmpCustomers");
            int customerID = Convert.ToInt32(source.Rows[0]["CustomerID"]);
            Customers customer = AppSetting.CustomerList.Where(c => c.CustomerID == customerID).FirstOrDefault();

            if (String.IsNullOrEmpty(customer.Email))
            {
                XtraMessageBox.Show("This Customer does not have e-mail address !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                XtraMessageBox.SmartTextWrap = true;
                DialogResult result = XtraMessageBox.Show("Send report to the address : " + customer.Email + " ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (this.grvProducts.SelectedRowsCount <= 0)
                    {
                        XtraMessageBox.Show("Please select products !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (this._rpt == null)
                        {
                            DataProcess<object> billingDA = new DataProcess<object>();
                            string condition = "(";
                            int[] rowHandles = this.grvProducts.GetSelectedRows();

                            for (int i = 0; i < rowHandles.Count(); i++)
                            {
                                if (i == rowHandles.Count() - 1)
                                {
                                    condition = condition + Convert.ToInt32(this.grvProducts.GetRowCellValue(rowHandles[i], "ProductID")) + ")";
                                }
                                else
                                {
                                    condition = condition + Convert.ToInt32(this.grvProducts.GetRowCellValue(rowHandles[i], "ProductID")) + ", ";
                                }
                            }

                            int rslt = billingDA.ExecuteNoQuery("STBillingRunByProducts @varFromDate = {0}, @varTodate = {1}, @varCondition = {2}, @EmployeeID = {3}", this._from, this._to, condition, null);

                            this._rpt = new rptBillingByProduct(this._from, this._to);
                            this._rpt.DataSource = FileProcess.LoadTable("SELECT tmpBillingReport.BillingDateID, tmpBillingReport.ReportDate, tmpBillingReport.BeginC, tmpBillingReport.BeginW, tmpBillingReport.InC, tmpBillingReport.InW, tmpBillingReport.OutC, tmpBillingReport.OutW, tmpBillingReport.CloseC, tmpBillingReport.CloseW, tmpBillingReport.CustomerID, tmpBillingReport.InP, tmpBillingReport.OutP, tmpBillingReport.CloseP, tmpBillingReport.EmployeeID, tmpBillingReport.BillingCustomerID"
                                                                         + " FROM tmpBillingReport"
                                                                         + " WHERE(((tmpBillingReport.EmployeeID) = " + AppSetting.CurrentUser.EmployeeID + "))"
                                                                         + " ORDER BY tmpBillingReport.ReportDate; ");
                        }
                        SendMail(customer.Email, this._rpt, "SCS VN Billing Report - " + customer.CustomerName);
                    }
                }
            }
        }

        private void LoadProducts()
        {
            this._source = FileProcess.LoadTable(query);
            this.grdProducts.DataSource = this._source;
            this.grvProducts.ClearSelection();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
