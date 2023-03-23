using Common.Controls;
using DA;
using DA.Warehouse;
using DevExpress.XtraEditors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Helper;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_EDIRoutePlanning : frmBaseFormNormal
    {
        DataTable dataSource = null;
        private DataProcess<Employees> _rec = new DataProcess<Employees>();
        public frm_WM_EDIRoutePlanning(String ReportDate, Int32 CustomerID)
        {
            InitializeComponent();
            //this.pvgEDIRoutePlanning.DataSource = FileProcess.LoadTable("STEDI_RoutePlanning '" + ReportDate + "'," + CustomerID);
            this.lkeCustomerID.Properties.DataSource = AppSetting.CustomerList.OrderBy(a => a.CustomerNumber);
            this.lkeCustomerID.Properties.ValueMember = "CustomerID";
            this.lkeCustomerID.Properties.DisplayMember = "CustomerNumber";
            this.deOrderDate.DateTime = Convert.ToDateTime(ReportDate);
            this.lkeCustomerID.EditValue = CustomerID;
            
        }
        public frm_WM_EDIRoutePlanning()
        {
            InitializeComponent();
            this.lkeCustomerID.Properties.DataSource = AppSetting.CustomerList.OrderBy(a => a.CustomerNumber);
            this.lkeCustomerID.Properties.ValueMember = "CustomerID";
            this.lkeCustomerID.Properties.DisplayMember = "CustomerNumber";

            this.deOrderDate.DateTime = DateTime.Today.AddDays(1);
            
        }
        private void pvgEDIRoutePlanning_CustomSummary(object sender, DevExpress.XtraPivotGrid.PivotGridCustomSummaryEventArgs e)
        {
            string name = e.DataField.FieldName;
            if (e.DataField.SummaryType == DevExpress.Data.PivotGrid.PivotSummaryType.Custom)
            {
                IList list = e.CreateDrillDownDataSource();
                Hashtable ht = new Hashtable();
                for (int i = 0; i < list.Count; i++)
                {
                    DevExpress.XtraPivotGrid.PivotDrillDownDataRow row = list[i] as DevExpress.XtraPivotGrid.PivotDrillDownDataRow;
                    object v = row[name];
                    if (v != null && v != DBNull.Value)
                        ht[v] = null;
                }
                e.CustomValue = ht.Count;
            }
        }

        private void pvgEDIRoutePlanning_CellClick(object sender, DevExpress.XtraPivotGrid.PivotCellEventArgs e)
        {

            if (e.DataField.FieldName.Equals("BillingComments") || e.DataField.FieldName.Equals("BillingCalculated"))
            {
                if (e.RowIndex >= this.dataSource.Rows.Count) return;
                int ediOrderID = Convert.ToInt32(this.dataSource.Rows[e.RowIndex]["EDI_OrderID"]);
                var currentDes = Convert.ToString(this.dataSource.Rows[e.RowIndex]["EDI_OrderRemark"]);
                var inputResult = XtraInputBox.Show("Enter a Truck/Route Description", "Truck Number / Route Description", currentDes);
                int result = this._rec.ExecuteNoQuery("Update EDI_Orders SET EDI_OrderRemark = " + inputResult + " where EDI_OrderID= " + ediOrderID);
                if (result > 0)
                    refreshgrid();
                else
                    XtraMessageBox.Show("Error Updating !");
            }
            else
            {
                if (e.RowIndex >= this.dataSource.Rows.Count) return;
                int ediOrderID = Convert.ToInt32(this.dataSource.Rows[e.RowIndex]["EDI_OrderID"]);
                var currentDes = Convert.ToString(this.dataSource.Rows[e.RowIndex]["EDIOrderRemark"]);
                var inputResult = XtraInputBox.Show("Enter a Truck/Route Description", "Truck Number / Route Description", currentDes);
                int result = this._rec.ExecuteNoQuery("Update EDI_Orders SET EDIOrderRemark = '" + inputResult + "' where EDI_OrderID= " + ediOrderID);
                if (result > 0)
                    refreshgrid();
                else
                    XtraMessageBox.Show("Error Updating !");
                //Form form = new Form();
                //form.Text = "Records";
                //// Place a DataGrid control on the form.
                //DataGrid grid = new DataGrid();
                //grid.Parent = form;
                //grid.Dock = DockStyle.Fill;
                //// Get the recrd set associated with the current cell and bind it to the grid.
                //grid.DataSource = e.CreateDrillDownDataSource();
                //form.Bounds = new Rectangle(100, 100, 1000, 400);
                //// Display the form.
                //form.ShowDialog();
                //form.Dispose();
            }
        }

        private void lkeCustomerID_EditValueChanged(object sender, EventArgs e)
        {
            this.textCustomerName.Text = Convert.ToString(this.lkeCustomerID.GetColumnValue("CustomerName"));
            refreshgrid();
        }

        private void refreshgrid()
        {
            string strSQL = "";
            if (this.checkMainCustomer.Checked)
                strSQL = "STEDI_RoutePlanning '" + deOrderDate.DateTime.ToString("yyyy-MM-dd") + "'," + this.lkeCustomerID.EditValue + ",1";
            else
                strSQL = "STEDI_RoutePlanning '" + deOrderDate.DateTime.ToString("yyyy-MM-dd") + "'," + this.lkeCustomerID.EditValue + ",0";
            this.dataSource = FileProcess.LoadTable(strSQL);
            this.pvgEDIRoutePlanning.DataSource = this.dataSource;
        }
        private void deOrderDate_EditValueChanged(object sender, EventArgs e)
        {
            refreshgrid();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refreshgrid();
        }
    }
    
}
