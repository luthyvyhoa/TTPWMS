using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Common.Controls;
using Common.Process;
using DA;
using UI.Helper;
using UI.MasterSystemSetup;
using UI.ReportFile;
using DevExpress.XtraReports.UI;
using DevExpress.XtraEditors;
using System.Net.Mail;
using System.IO;
using System.Text;

namespace UI.ReportForm
{
    public partial class frm_WR_StockMovementByProductReport : frmBaseForm
    {
        //private List<Products> _listProducts;
        private rptStockMovementByProduct _report;

        public frm_WR_StockMovementByProductReport()
        {
            InitializeComponent();
            //this._listProducts = new List<Products>();
        }

        private void frm_WR_StockMovementByProductReport_Load(object sender, EventArgs e)
        {
            Wait.Start(this);
            InitCustomer();

            this.dtToDate.EditValue = DateTime.Now;
            this.dtFromDate.EditValue = DateTime.Now.AddDays(-1);

            SetEvents();
            Wait.Close();
        }

        private void SetEvents()
        {
            this.lkeCustomer.EditValueChanged += lkeCustomer_EditValueChanged;
            this.btnClose.Click += btnClose_Click;
            this.btnEmail.Click += btnEmail_Click;
            this.btnView.Click += btnView_Click;
        }

        private void InitCustomer()
        {
            this.lkeCustomer.Properties.DataSource = AppSetting.CustomerList.Where(c => c.CustomerDiscontinued == false);
            this.lkeCustomer.Properties.ValueMember = "CustomerID";
            this.lkeCustomer.Properties.DisplayMember = "CustomerNumber";
        }

        #region  Events
        private void lkeCustomer_EditValueChanged(object sender, EventArgs e)
        {
            this.txtCustomerName.Text = Convert.ToString(this.lkeCustomer.GetColumnValue("CustomerName"));
            //this._listProducts = AppSetting.ProductList.Where(p => p.CustomerID == Convert.ToInt32(this.lkeCustomer.EditValue) && p.Discontinue == false).ToList();
            this.grdProduct.DataSource = AppSetting.ProductList.Where(p => p.CustomerID == Convert.ToInt32(this.lkeCustomer.EditValue) && p.Discontinue == false).ToList();
            this.grdProduct.Refresh();
            this.grvProduct.ClearSelection();
        }

        private void btnCustomerInfo_Click(object sender, EventArgs e)
        {
            Customers customer = AppSetting.CustomerList.Where(c => c.CustomerID == Convert.ToInt32(this.lkeCustomer.EditValue)).FirstOrDefault();
            if (customer != null)
            {
                frm_MSS_Customers frmCustomer = MasterSystemSetup.frm_MSS_Customers.Instance;
                frmCustomer.CurrentCustomers = customer;
                frmCustomer.WindowState = FormWindowState.Normal;
                frmCustomer.BringToFront();
                frmCustomer.Show();
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            UpdateReportData();
            ReportPrintToolWMS tool = new ReportPrintToolWMS(this._report);

            tool.ShowPreview();
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            if (this.lkeCustomer.EditValue == null || (int)this.lkeCustomer.EditValue <= 0)
            {
                return;
            }
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
                    UpdateReportData();
                    SendMail(email, this._report, "Stock Report From SCS VN", 0);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        #endregion


        private string GetSelectedProductID()
        {
            string listProductID = "(";
            int[] rowHandles = this.grvProduct.GetSelectedRows();

            for (int i = 0; i < rowHandles.Count(); i++)
            {
                if (i == rowHandles.Count() - 1)
                {
                    listProductID = listProductID + this.grvProduct.GetRowCellValue(rowHandles[i], "ProductID") + ")";
                }
                else
                {
                    listProductID = listProductID + this.grvProduct.GetRowCellValue(rowHandles[i], "ProductID") + ", ";
                }
            }

            return listProductID;
        }

        private string GetAllProductID()
        {
            string condition = "(";
            List<Products> listProducts = AppSetting.ProductList.Where(p => p.CustomerID == Convert.ToInt32(this.lkeCustomer.EditValue)).ToList();
            int count = listProducts.Count;

            for (int i = 0; i < count; i++)
            {
                if (i == count - 1)
                {
                    condition = condition + listProducts[i].ProductID + ")";
                }
                else
                {
                    condition = condition + listProducts[i].ProductID + ", ";
                }
            }

            return condition;
        }

        private void UpdateReportData()
        {
            this._report = new rptStockMovementByProduct(this.dtFromDate.DateTime, this.dtToDate.DateTime);
            string condition = "";

            if (this.grvProduct.SelectedRowsCount <= 0)
            {
                //Print report of all products
                XtraMessageBox.Show("No Product Selected, use all products !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                condition = GetAllProductID();
            }
            else
            {
                //Print report of selected products
                condition = GetSelectedProductID();
            }

            var data = FileProcess.LoadTable(" STStockMovementReportByProducts @varFromDate='" + this.dtFromDate.DateTime.ToString("yyyy-MM-dd HH:mm:ss")
                + "', @varTodate='" + this.dtToDate.DateTime.ToString("yyyy-MM-dd HH:mm:ss") + "' ,  @varCondition='" + condition + "'");
            this._report.DataSource = data;

            CreateCalculateField(this._report);
        }

        private void CreateCalculateField(rptStockMovementByProduct report)
        {
            CalculatedField weight = new CalculatedField();

            weight.DataSource = report.DataSource;
            weight.DataMember = report.DataMember;
            weight.FieldType = FieldType.Double;
            weight.DisplayName = "Weight";
            weight.Name = "weight";
            weight.Expression = "[BeginQty] * [WeightPerPackage]";

            report.CalculatedFields.Add(weight);

            CalculatedField pallet = new CalculatedField();

            pallet.DataSource = report.DataSource;
            pallet.DataMember = report.DataMember;
            pallet.FieldType = FieldType.Double;
            pallet.DisplayName = "Pallet";
            pallet.Name = "pallet";
            pallet.Expression = "[BeginQty] * [PackagesPerPallet]";

            report.CalculatedFields.Add(pallet);
        }

        /// <summary>
        /// Send attachment to customers
        /// </summary>
        private void SendMail(string toEmail, rptStockMovementByProduct report, string subject, int formatType = 0)
        {
            try
            {
                string fileExtension = "rtf";
                string boby = "Please find the attached report";
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
                    DataTransfer.SendMail(toEmail, subject, boby, att);
                }

                XtraMessageBox.Show("Email sent successful!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Send failed!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCustomerName_DoubleClick(object sender, EventArgs e)
        {
            Customers customer = AppSetting.CustomerList.Where(c => c.CustomerID == Convert.ToInt32(this.lkeCustomer.EditValue)).FirstOrDefault();
            if (customer != null)
            {
                frm_MSS_Customers frmCustomer = MasterSystemSetup.frm_MSS_Customers.Instance;
                frmCustomer.CurrentCustomers = customer;
                frmCustomer.WindowState = FormWindowState.Normal;
                frmCustomer.BringToFront();
                frmCustomer.Show();
            }
        }

        private void checkShowAllInOutProducts_CheckedChanged(object sender, EventArgs e)
        {
            
            if (this.checkShowAllInOutProducts.Checked)
            {
                
                if (this.grvProduct.SelectedRowsCount <= 0)
                {
                    var data = FileProcess.LoadTable(" STStockMovementReportByProducts @FromDate='" + this.dtFromDate.DateTime.ToString("yyyy-MM-dd HH:mm:ss")
                   + "', @Todate='" + this.dtToDate.DateTime.ToString("yyyy-MM-dd HH:mm:ss") + "', @CustomerID = " + this.lkeCustomer.EditValue);
                    this.grcInOutAllProducts.DataSource = data;
                }
                else
                {
                    string condition = "";
                    condition = GetSelectedProductID();
                    
                    var data = FileProcess.LoadTable(" STStockMovementReportByProducts @FromDate='" + this.dtFromDate.DateTime.ToString("yyyy-MM-dd HH:mm:ss")
                        + "', @Todate='" + this.dtToDate.DateTime.ToString("yyyy-MM-dd HH:mm:ss") + "', @CustomerID = " + this.lkeCustomer.EditValue + ",  @Condition='" + condition + "'");
                    this.grcInOutAllProducts.DataSource = data;
                }
            }
            else
            {
                this.grcInOutAllProducts.DataSource = null;

            }
        }
    }
}
