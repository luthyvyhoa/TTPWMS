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
using Common.Process;
using DevExpress.XtraEditors;

namespace UI.ReportForm
{
    public partial class frm_BR_Dialog_BillingCheckBreakdownResult : Common.Controls.frmBaseForm
    {
        private DateTime _fromDate;
        private DateTime _toDate;
        private DataTable _tableAllBillings;
        private DataTable _tableFilterBillings;
        private DataTable _tableBillingByCustomer;

        public frm_BR_Dialog_BillingCheckBreakdownResult(DateTime fromDate, DateTime toDate)
        {
            InitializeComponent();
            this._fromDate = fromDate;
            this._toDate = toDate;
            this._tableAllBillings = new DataTable();
            this._tableFilterBillings = new DataTable();
            this._tableBillingByCustomer = new DataTable();
            
        }

        private void frm_BR_Dialog_BillingCheckBreakdownResult_Load(object sender, EventArgs e)
        {
            Wait.Start(this);
            LoadData();
            SetEvents();
            Wait.Close();
        }

        private void SetEvents()
        {
            this.rpi_btn_ViewDetail.Click += Rpi_btn_ViewDetail_Click;
        }

        private void Rpi_btn_ViewDetail_Click(object sender, EventArgs e)
        {
            try
            {
                this._tableBillingByCustomer = FileProcess.LoadTable("SELECT Billings.CustomerID, BillingDetailBreakDown.ReportDate, BillingDetailBreakDown.BeginC, BillingDetailBreakDown.CloseC, BillingDetailBreakDown.BeginW, BillingDetailBreakDown.CloseW, Customers.CustomerNumber, Customers.CustomerName"
                         + " FROM (Billings INNER JOIN BillingDetailBreakDown ON Billings.BillingID = BillingDetailBreakDown.BillingID)  INNER JOIN Customers ON Billings.CustomerID = Customers.CustomerID"
                         + " WHERE Billings.CustomerID = " + Convert.ToInt32(this.grvBillingResult.GetFocusedRowCellValue("CustomerID")) + " AND BillingDetailBreakDown.ReportDate Between '" + this._fromDate.ToString("yyyy-MM-dd") + "' AND '" + this._toDate.ToString("yyyy-MM-dd") + "'"
                         + " ORDER BY Billings.CustomerID, BillingDetailBreakDown.ReportDate");

                this.grdBillingResult.SuspendLayout();
                this.grdBillingResult.DataSource = this._tableBillingByCustomer;

                //Hide and show specific columns
                this.gridBand1.Visible = false;
                this.gridBand6.Visible = false;
                this.gridBand7.Visible = true;

                string pathSaveFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string fileName = pathSaveFile + "\\" + "BillingCheckBreakdown_" + DateTime.Now.ToString("dd_MM_yy") + ".xlsx";

                this.grvBillingResult.ExportToXlsx(fileName);

                //Restore former state
                this.gridBand1.Visible = true;
                this.gridBand6.Visible = true;
                this.gridBand7.Visible = false;

                this.grdBillingResult.DataSource = this._tableFilterBillings;
                this.grdBillingResult.ResumeLayout();

                System.Diagnostics.Process.Start(fileName);
                
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void LoadData()
        {
            int closeC, beginC;
            float closeW, beginW;
            int customerID;
            DateTime reportDate;
            bool isCheck;

            this._tableAllBillings = FileProcess.LoadTable("SELECT Billings.CustomerID, BillingDetailBreakDown.ReportDate, BillingDetailBreakDown.BeginC, BillingDetailBreakDown.CloseC, BillingDetailBreakDown.BeginW, BillingDetailBreakDown.CloseW, Customers.CustomerNumber, Customers.CustomerName"
                         + " FROM (Billings INNER JOIN BillingDetailBreakDown ON Billings.BillingID = BillingDetailBreakDown.BillingID)  INNER JOIN Customers ON Billings.CustomerID = Customers.CustomerID"
                         + " WHERE BillingDetailBreakDown.ReportDate Between '" + this._fromDate.ToString("yyyy-MM-dd") + "' AND '" + this._toDate.ToString("yyyy-MM-dd") + "'"
                         + " ORDER BY Billings.CustomerID, BillingDetailBreakDown.ReportDate");

            this._tableFilterBillings = _tableAllBillings.Clone();

            foreach(DataRow row in _tableAllBillings.Rows)
            {
                closeC = Convert.ToInt32(row["CloseC"]);
                beginC = Convert.ToInt32(row["BeginC"]);
                closeW = (float)Convert.ToDecimal(row["CloseW"]);
                beginW = (float)Convert.ToDecimal(row["BeginW"]);
                customerID = Convert.ToInt32(row["CustomerID"]);
                reportDate = Convert.ToDateTime(row["ReportDate"]);
                isCheck = true;

                foreach(DataRow item in _tableAllBillings.Rows)
                {
                    if(customerID == Convert.ToInt32(item["CustomerID"]))
                    {
                        if(closeC != Convert.ToInt32(item["BeginC"]))
                        {
                            isCheck = false;
                        }
                        if(closeW < (float)(Convert.ToDecimal(item["BeginW"]) - 1000) || closeW > (float)(Convert.ToDecimal(item["BeginW"]) + 1000))
                        {
                            isCheck = false;
                        }

                        if(!isCheck)
                        {
                            this._tableFilterBillings.Rows.Add(item.ItemArray);
                        }
                    }

                    closeC = Convert.ToInt32(item["CloseC"]);
                    closeW = (float)Convert.ToDecimal(item["CloseW"]);
                    customerID = Convert.ToInt32(item["CustomerID"]);
                    reportDate = Convert.ToDateTime(item["ReportDate"]);
                    isCheck = true;
                }
                break;
            }

            this.grdBillingResult.DataSource = this._tableFilterBillings;
        }

        private void grdBillingResult_Click(object sender, EventArgs e)
        {

        }
    }
}
