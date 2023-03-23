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

namespace UI.Supperviors
{
    public partial class frm_S_CustomerForecast : Form
    {
        private DataProcess<CustomerForecast> customerForecast = new DataProcess<CustomerForecast>();
        public frm_S_CustomerForecast()
        {
            InitializeComponent();
            DataProcess<Stores> storeDA = new DataProcess<Stores>();
            this.lke_MSS_StoreList.Properties.DataSource = storeDA.Select();
            this.lke_MSS_StoreList.Properties.ValueMember = "StoreID";
            this.lke_MSS_StoreList.Properties.DisplayMember = "StoreDescription";
            this.lke_MSS_StoreList.EditValue = AppSetting.StoreID;
            this.lke_OperatingCostMonthlyID.Properties.DataSource = FileProcess.LoadTable("ST_WMS_LoadOperatingCostMonth");
            this.lke_OperatingCostMonthlyID.Properties.ValueMember = "OperatingCostMonthlyID";
            this.lke_OperatingCostMonthlyID.Properties.DisplayMember = "MonthDescription";
            this.lke_OperatingCostMonthlyID.EditValue = AppSetting.CurrentOperationMonthID;
            this.grcStockAndForecast.DataSource = FileProcess.LoadTable("STCustomerForecastMonthlyView " + this.lke_OperatingCostMonthlyID.EditValue + ", " + this.lke_MSS_StoreList.EditValue);
            Common.Process.RefreshData.ReloadDataEvent += RefreshData_ReloadDataEvent;
        }

        private void RefreshData_ReloadDataEvent(object sender, EventArgs e)
        {
           
            this.grcStockAndForecast.DataSource = FileProcess.LoadTable("STCustomerForecastMonthlyView " + this.lke_OperatingCostMonthlyID.EditValue + ", " + this.lke_MSS_StoreList.EditValue);

        }

        private void lke_OperatingCostMonthlyID_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            //this.grcStockAndForecast.DataSource = FileProcess.LoadTable("STCustomerForecastMonthlyView 0 ," + this.lke_MSS_StoreList.EditValue);
        }

        private void rpl_CustomerID_Click(object sender, EventArgs e)
        {
            frm_S_CustomerStock36months frm = new frm_S_CustomerStock36months(Convert.ToInt32(this.bandedGridView1.GetFocusedRowCellValue("CustomerID")));
            frm.Show();
            frm.WindowState = FormWindowState.Normal;

            int customerID = Convert.ToInt32(this.bandedGridView1.GetFocusedRowCellValue("CustomerID"));
            string customerName = this.bandedGridView1.GetFocusedRowCellValue("CustomerName").ToString();
            frm_S_CustomerStock36months2 frm2 = new frm_S_CustomerStock36months2(customerID, customerName);
            frm2.Show();
            frm2.BringToFront();

        }

        private void bandedGridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            switch (e.Column.FieldName)
            {
                case "DailyStockWeight":
                case "DailyStockPallet":
                case "MonthlyHandlingWeight":
                case "MonthlyHandlingPallet":
                case "MonthlyNumberTransactions":
                case "CustomerForecastRemark":
                    int cusForecastID = Convert.ToInt32(this.bandedGridView1.GetFocusedRowCellValue("CustomerForecastID"));
                    string fieldname = e.Column.FieldName;
                    DataProcess<object> processDA = new DataProcess<object>();
                    int reult=processDA.ExecuteNoQuery("Update CustomerForecasts set "+fieldname+ "={0}, CreatedBy = {1}, CreatedTime = {2} Where CustomerForecastID={3}", e.Value,AppSetting.CurrentUser.LoginName,DateTime.Now,cusForecastID);
                    //int reult = processDA.ExecuteNoQuery("Update CustomerForecasts set " + fieldname + "={0}, CreatedBy = '" + AppSetting.CurrentUser.LoginName + "', CreatedTime = GETDATE() Where CustomerForecastID={1}", e.Value, cusForecastID);
                    break;

                default:
                    break;
            }
        }

        private void lke_OperatingCostMonthlyID_Properties_EditValueChanged(object sender, EventArgs e)
        {
            this.grcStockAndForecast.DataSource = FileProcess.LoadTable("STCustomerForecastMonthlyView " + this.lke_OperatingCostMonthlyID.EditValue + ", " + this.lke_MSS_StoreList.EditValue);

        }

        private void rpl_CustomerForecast12months_Click(object sender, EventArgs e)
        {
            frm_S_CustomerForecast12Months frm = new frm_S_CustomerForecast12Months(Convert.ToInt32(this.bandedGridView1.GetFocusedRowCellValue("CustomerID")));
            frm.Show();
            frm.WindowState = FormWindowState.Normal;
            frm.BringToFront();
        }

        private void grcStockAndForecast_Click(object sender, EventArgs e)
        {

        }

        private void bandedGridView1_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            refreshsub();
        }

        private void bandedGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            refreshsub();
        }

        private void refreshsub()
        {
            string fName = this.bandedGridView1.FocusedColumn.FieldName.ToString();
            this.grcForecastByParameter.DataSource = FileProcess.LoadTable("STCustomerForecastByParameter " + this.bandedGridView1.GetFocusedRowCellValue("CustomerID") + ",'" + fName + "'");
            this.chartActualAndForecast.DataSource = FileProcess.LoadTable("STCustomerForecastByParameterChart " + this.bandedGridView1.GetFocusedRowCellValue("CustomerID") + ",'" + fName + "'");

        }


        // Code here to update CustomerForecast data

        private void grvForecastByParameter_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            string fName = this.bandedGridView1.FocusedColumn.FieldName.ToString();
            DataProcess<object> customerForecastDA = new DataProcess<object>();
            switch (e.Column.FieldName)
            {
                case "ForecastQuantity":
                 //   int result = customerForecastDA.ExecuteNoQuery("update CustomerForecasts set "+ fName + "={0}  where CustomerForecastID={1}",e.Value, grvForecastByParameter.GetFocusedRowCellValue("CustomerForecastID"));
                    int reult = customerForecastDA.ExecuteNoQuery("Update CustomerForecasts set " + fName + "={0}, CreatedBy = {1}, CreatedTime = {2} Where CustomerForecastID={3}", e.Value, AppSetting.CurrentUser.LoginName, DateTime.Now, grvForecastByParameter.GetFocusedRowCellValue("CustomerForecastID"));
                    break;
            }

        }

        private void btnPlanningSummary_Click(object sender, EventArgs e)
        {
            frm_S_CustomerForecastViewByMonth frm = new frm_S_CustomerForecastViewByMonth();
            frm.Show();
        }
    }
}
