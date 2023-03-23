using DA;
using DevExpress.Data;
using DevExpress.XtraGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Helper;
using UI.WarehouseManagement;


namespace UI.Supperviors
{
    public partial class frm_S_SJTHS_StockCorrection : Common.Controls.frmBaseForm
    {
        DataTable dt = new DataTable();
        int customerID = 0;
        double customersummary = 0;
        public frm_S_SJTHS_StockCorrection()
        {
            InitializeComponent();
            this.daFrom.DateTime = DateTime.Now;
            this.daTo.DateTime = DateTime.Now;
        }
        private void initCustomer()
        {
            DataProcess<Customers> customerDA = new DataProcess<Customers>();
            List<Customers> customerList = new List<Customers>();
            string qry = "select * from Customers where CustomerMainID in(280,919,920,9,855,466,2085) and CustomerDiscontinued=0";
            customerList = customerDA.Executing(qry).ToList();
            if (customerList != null)
            {
                this.lkeCustomerID.Properties.DataSource = customerList;
                this.lkeCustomerID.Properties.DisplayMember = "CustomerNumber";
                this.lkeCustomerID.Properties.ValueMember = "CustomerID";
            }

        }

        private void lkeCustomerID_EditValueChanged(object sender, EventArgs e)
        {
            customerID = Convert.ToInt32(lkeCustomerID.GetColumnValue("CustomerID").ToString());
            lblCustomerName.Text = lkeCustomerID.GetColumnValue("CustomerName").ToString();
            string dafrom = daFrom.DateTime.ToString("yyyy-MM-dd");
            string dato = daTo.DateTime.ToString("yyyy-MM-dd");
            string st_string = "STStockCorrectionInsert @varFromDate='" + dafrom + "', @varTodate='" + dato + "', @varCustomerID=" + customerID + ", @UserName='" + AppSetting.CurrentUser.LoginName + "'";
            DataProcess<object> newobj = new DataProcess<object>();
            int result = newobj.ExecuteNoQuery(st_string);
            string sql_string = "SELECT tmpStockCorrectionProducts.*, Products.ProductNumber, Products.ProductName, Products.WeightPerPackage ";
            sql_string += " , Products.Packages FROM tmpStockCorrectionProducts INNER JOIN Products ON tmpStockCorrectionProducts.ProductID = Products.ProductID";

            dt = FileProcess.LoadTable(sql_string);
            //dt.Columns.Add("Check", typeof(bool));
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    dt.Rows[i]["Check"] = false;
            //}
            gcStockCorrectionProducts.DataSource = dt;
            gvStockCorrectionProducts.UpdateTotalSummary();
        }

        private void frm_S_SJTHS_StockCorrection_Load(object sender, EventArgs e)
        {
            initCustomer();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCreateDO_Click(object sender, EventArgs e)
        {
            if (gvStockCorrectionProducts.DataRowCount < 1)
                return;
            DataRow[] dr = dt.Select("CheckDispatched=True");
            if (dr.Length == 0)
            {
                MessageBox.Show("You have to select ART to make DO!");
                return;
            }
            else
            {
                DataProcess<tmpStockCorrectionProducts> tmp = new DataProcess<tmpStockCorrectionProducts>();
                for (int i = 0; i < dr.Length; i++)
                {
                    tmp.Executing("UPDATE tmpStockCorrectionProducts SET CheckDispatched='True' WHERE ProductID=" + dr[i]["ProductID"]);
                }
                
            }

            System.Data.Entity.Core.Objects.ObjectParameter DOID = new System.Data.Entity.Core.Objects.ObjectParameter("return_DispatchingOrderID", 0);
            int reusult = STStockCorrectionDispatchingProductInsertWI(customerID, AppSetting.CurrentUser.LoginName, DOID);
            int returnDO = Convert.ToInt32(DOID.Value.ToString());

            var frmDispatching = frm_WM_DispatchingOrders.GetInstance(returnDO);
            if (frmDispatching.Visible)
            {
                frmDispatching.ReloadData();
            }
            frmDispatching.Show();
        }
        public int STStockCorrectionDispatchingProductInsertWI(int customerID, string loginName, System.Data.Entity.Core.Objects.ObjectParameter result)
        {
            using (var context = new SwireDBEntities())
            {
                return context.STStockCorrectionDispatchingProductInsertWI(customerID, loginName, result);
            }
        }
 

        private void gvStockCorrectionProducts_CustomSummaryCalculate(object sender, CustomSummaryEventArgs e)
        {
          
            var item = e.Item as GridColumnSummaryItem;
            if (item == null || item.FieldName != "TotalUnitWeight")
                return;
            // set customersummary
            string expression = "CheckDispatched=True";
            DataRow[] dr = dt.Select(expression);
            customersummary = 0;
            for (int i = 0; i < dr.Length; i++)
            {
                customersummary = customersummary + Convert.ToDouble(dr[i]["TotalUnitWeight"].ToString());
            }
            if (e.SummaryProcess == CustomSummaryProcess.Finalize)
            {
                e.TotalValue = Math.Round(customersummary, 2); ;

            }

        }

        private void gcReportPeriod_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
