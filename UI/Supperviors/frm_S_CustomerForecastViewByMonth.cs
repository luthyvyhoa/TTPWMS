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

namespace UI.Supperviors
{
    public partial class frm_S_CustomerForecastViewByMonth : frmBaseForm
    {
        DataTable dataSource;
        public frm_S_CustomerForecastViewByMonth()
        {
            InitializeComponent();
            Common.Process.RefreshData.ReloadDataEvent += RefreshData_ReloadDataEvent;
            LoadData();
        }

        private void RefreshData_ReloadDataEvent(object sender, EventArgs e)
        {
           
                ChangeValueDate();
        }

        DataProcess<ST_WMS_LoadOperatingCostMonth_Result> daLoadMonth = new DataProcess<ST_WMS_LoadOperatingCostMonth_Result>();

        public void LoadData()
        {

            //loadMonth = daLoadMonth.Executing("ST_WMS_LoadOperatingCostMonth").FirstOrDefault();
            txtTo.EditValue = DateTime.Now;
            txtFrom.EditValue = DateTime.Now.AddMonths(-12);
            ChangeValueDate();

        }


        private void ChangeValueDate()
        {
            if (txtTo.EditValue == null || txtFrom.EditValue == null) return;
            string convertTo = Convert.ToDateTime(txtTo.EditValue).ToString("yyyy-MM");
            string convertFrom = Convert.ToDateTime(txtFrom.EditValue).ToString("yyyy-MM");

            int TO = ConvertMonthDescription(convertTo);
            int FROM = ConvertMonthDescription(convertFrom);
            dataSource = FileProcess.LoadTable("STCustomerForecastByMonthView " + FROM + "," + TO + "," + AppSetting.CurrentUser.StoreID);
            pivotGridControl1.DataSource = dataSource;
        }
        private int ConvertMonthDescription(string convertTo)
        {
            ST_WMS_LoadOperatingCostMonth_Result loadMonth = daLoadMonth.Executing("SELECT OperatingCostMonthlyID FROM OperatingCostMonths WHERE MonthDescription={0}", convertTo).FirstOrDefault();
            return loadMonth.OperatingCostMonthlyID;
        }

        private void txtTo_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            ChangeValueDate();
        }

        private void txtFrom_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            ChangeValueDate();
        }

        private void txtTo_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.KeyCode.Equals(Keys.Enter)) return;
            ChangeValueDate();
        }

        private void txtFrom_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.KeyCode.Equals(Keys.Enter)) return;
            ChangeValueDate();
        }

        private void pivotGridControl1_CellClick(object sender, DevExpress.XtraPivotGrid.PivotCellEventArgs e)
        {
            if (e.DataField.FieldName.Equals("DailyStockPallet"))
            {
                Point point = new Point(e.Bounds.X, e.Bounds.Y);
                var data = this.pivotGridControl1.CalcHitInfo(point);
                var currentRow = e.CreateDrillDownDataSource();
                int id = 0;
                if (currentRow != null && currentRow.RowCount > 0)
                    id = Convert.ToInt32(currentRow[0]["CustomerForecastID"]);
                decimal value = Convert.ToDecimal(data.CellInfo.Value);
                frm_S_CustomerForecastViewByMonthEdit frmEdit = new frm_S_CustomerForecastViewByMonthEdit(id, value, "Forecast Plts");
                frmEdit.Show();
            }


        }
    }
}
