using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DA;
using UI.Helper;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using UI.ReportFile;

namespace UI.ReportForm
{
    public partial class frm_BR_BillingByReceivingOrders : Common.Controls.frmBaseForm
    {
        private DataProcess<STBillingRunByReceivingOrdersROList_Result> _billingDA;
        private DataProcess<tmpBillingRunByReceivingOrders> _billingRODA;
        private List<tmpBillingRunByReceivingOrders> _listBillingRO;

        public frm_BR_BillingByReceivingOrders()
        {
            InitializeComponent();
            this._billingDA = new DataProcess<STBillingRunByReceivingOrdersROList_Result>();
            this._billingRODA = new DataProcess<tmpBillingRunByReceivingOrders>();
            this._listBillingRO = new List<tmpBillingRunByReceivingOrders>();
        }

        private void frm_BR_BillingByReceivingOrders_Load(object sender, EventArgs e)
        {
            InitCustomer();
            this.dtFromDate.EditValue = DateTime.Now.AddDays(-30);
            this.dtToDate.EditValue = DateTime.Now;
            SetEvents();
        }

        private void frm_BR_BillingByReceivingOrders_Shown(object sender, EventArgs e)
        {
            this.lkeCustomer.Focus();
            this.lkeCustomer.ShowPopup();
        }

        private void SetEvents()
        {
            this.lkeCustomer.CloseUp += LkeCustomer_CloseUp;
            this.btnByProduct.Click += BtnByProduct_Click;
            this.btnViewReport.Click += BtnViewReport_Click;
            this.btnClose.Click += BtnClose_Click;
        }

        #region Events
        private void LkeCustomer_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            //if (e.Value == null)
            //    this.txtCustomerName.Text = ""; 
            //else
            //{
            //    var customerIDFind = Convert.ToInt32(e.Value);
            //    var custInfo = AppSetting.CustomerList.Where(c => c.CustomerID == customerIDFind).FirstOrDefault();
            //    this.txtCustomerName.Text = custInfo.CustomerName;
            //}
            //LoadData();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnViewReport_Click(object sender, EventArgs e)
        {
            if (UpdateReportData() != -2)
            {
                this._listBillingRO = this._billingRODA.Select().ToList();

                if (this._listBillingRO.Count <= 0)
                {
                    XtraMessageBox.Show("No data to print !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int storage = -1;
                    int byWeight = -1;

                    int.TryParse(this.txtStorage.Text, out storage);
                    int.TryParse(this.txtHandlingByWeight.Text, out byWeight);

                    rptBillingByReceivingOrders rpt = new rptBillingByReceivingOrders(storage, byWeight);
                    rpt.DataSource = this._listBillingRO;
                    ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
                    tool.ShowPreview();
                }
            }
            else
            {
                XtraMessageBox.Show("Upexpected Error !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnByProduct_Click(object sender, EventArgs e)
        {
            int count = this.grvReceivingOrder.GetSelectedRows().Count();
            if (count <= 0)
            {
                MessageBox.Show("Please select order !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            System.Text.StringBuilder condition = new StringBuilder();
            condition.Append("0");
            for (int i = 0; i < count; i++)
            {
                condition.Append(",");
                condition.Append(this.grvReceivingOrder.GetRowCellValue(this.grvReceivingOrder.GetSelectedRows()[i], "ReceivingOrderID"));
            }
            condition.Insert(0, "(");
            condition.Insert(condition.Length, ")");

            string recevingOrderNumber = Convert.ToString(this.grvReceivingOrder.GetFocusedRowCellValue("ReceivingOrderNumber"));
            string recevingOrderDate = Convert.ToString(this.grvReceivingOrder.GetFocusedRowCellValue("ReceivingOrderDate"));
            string requirements = Convert.ToString(this.grvReceivingOrder.GetFocusedRowCellValue("SpecialRequirement"));
            DataProcess<object> insertBillingReport = new DataProcess<object>();
            int result = insertBillingReport.ExecuteNoQuery("STBillingRunByRO_New @varCondition={0}", condition.ToString());
            string query = " SELECT DISTINCT Products.ProductID, substring(Products.ProductNumber,5,10) AS XXX, Products.ProductName, Products.WeightPerPackage " +
                                                " FROM (Products INNER JOIN ReceivingOrderDetails ON Products.ProductID = ReceivingOrderDetails.ProductID) " +
                                                " INNER JOIN tmpReceivingOrders ON ReceivingOrderDetails.ReceivingOrderID = tmpReceivingOrders.ReceivingOrderID" +
                                                " Where tmpReceivingOrders.ReceivingOrderID in " + condition.ToString() +
                                                " ORDER BY substring(products.ProductNumber,5,10)";
            frm_BR_Dialog_BillingByProduct frm = new frm_BR_Dialog_BillingByProduct(this.dtFromDate.DateTime, this.dtToDate.DateTime, query,
                recevingOrderNumber, recevingOrderDate, requirements);
            if (!frm.Enabled) return;
            frm.ShowDialog();
        }
        #endregion

        #region Load Data
        private void LoadData()
        {
            try
            {
                var customerIDFind = Convert.ToInt32(this.lkeCustomer.EditValue);
                var custInfo = AppSetting.CustomerList.Where(c => c.CustomerID == customerIDFind).FirstOrDefault();

                this.grdReceivingOrder.DataSource = this._billingDA.Executing("STBillingRunByReceivingOrdersROList @FromDate = {0}, @Todate = {1}, @CustomerID = {2}",
                    dtFromDate.DateTime.ToString("yyyy-MM-dd"), dtToDate.DateTime.ToString("yyyy-MM-dd"), Convert.ToInt32(custInfo.CustomerID));
                //this.grdDispatchingOrder.DataSource = FileProcess.LoadTable("STBillingRunByDispatchingOrdersDOList @FromDate = '" + this.dtFromDate.DateTime.ToString("yyyy-MM-dd") + "', @Todate = '" + this.dtToDate.DateTime.ToString("yyyy-MM-dd") + "', @CustomerID = " + Convert.ToInt32(this.lkeCustomer.EditValue));
            }
            catch (Exception ex)
            {
                //throw;
                XtraMessageBox.Show(ex.Message);
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
            int[] rowHandles = this.grvReceivingOrder.GetSelectedRows();

            for (int i = 0; i < rowHandles.Count(); i++)
            {
                if (i == rowHandles.Count() - 1)
                {
                    listDO = listDO + this.grvReceivingOrder.GetRowCellValue(rowHandles[i], "ReceivingOrderID") + ")";
                }
                else
                {
                    listDO = listDO + this.grvReceivingOrder.GetRowCellValue(rowHandles[i], "ReceivingOrderID") + ", ";
                }
            }

            return listDO;
        }

        private int UpdateReportData()
        {
            string condition = "";
            int result = -2;

            if (this.grvReceivingOrder.SelectedRowsCount <= 0)
            {
                XtraMessageBox.Show("Please select order !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                condition = GetSelectedDO();

                result = this._billingDA.ExecuteNoQuery("STBillingRunByReceivingOrders @varCondition = {0}", condition);
            }

            return result;
        }

        private void lkeCustomer_EditValueChanged(object sender, EventArgs e)
        {
            if (lkeCustomer.EditValue.ToString() == null)
                this.txtCustomerName.Text = "";
            else
            {
                var customerIDFind = Convert.ToInt32(lkeCustomer.EditValue.ToString());
                var custInfo = AppSetting.CustomerList.Where(c => c.CustomerID == customerIDFind).FirstOrDefault();
                this.txtCustomerName.Text = custInfo.CustomerName;
            }
            LoadData();
        }
    }
}
