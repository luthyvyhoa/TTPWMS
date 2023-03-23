using DA;
using DevExpress.XtraCharts;
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
using UI.Supperviors;

namespace UI.CRM
{
    public partial class frm_CRM_CustomerProfitabilitySummary : Form
    {
        private urc_CRM_12MonthProfitability Profitability = null;
        private urc_CRM_36MonthsOperation monthsOperation = null;
        private DataTable dt = null;
        private Series seriesTargetLine = new Series("TargetLine", ViewType.Line);
        
        public frm_CRM_CustomerProfitabilitySummary()
         
        {
            InitializeComponent();
            //this.lke_OperatingCostMonthlyID.Properties.DataSource = FileProcess.LoadTable("OperatingCostSummaryLast12Months " + AppSetting.StoreID);
            //this.lke_OperatingCostMonthlyID.Properties.ValueMember = "OperatingCostMonthlyID";
            //this.lke_OperatingCostMonthlyID.Properties.DisplayMember = "MonthDescription";

            //this.lke_OperatingCostMonthlyID.EditValue = OperatingCostMonthlyID;

            DataProcess<Stores> storeDA = new DataProcess<Stores>();
            this.lke_MSS_StoreList.Properties.DataSource = storeDA.Select();
            this.lke_MSS_StoreList.Properties.ValueMember = "StoreID";
            this.lke_MSS_StoreList.Properties.DisplayMember = "StoreDescription";
            
;
    }

        //private void lke_OperatingCostMonthlyID_EditValueChanged(object sender, EventArgs e)
        //{
        //    //if (this.lke_OperatingCostMonthlyID.EditValue != null && this.lke_MSS_StoreList.EditValue != null)

        //    //    this.grcCustomerProfitabilitySummary.DataSource = FileProcess.LoadTable("OperatingCostSummary_TotalAnalysis " + this.lke_MSS_StoreList.EditValue) + ","+ this.lke_OperatingCostMonthlyID.EditValue ;
            
        //}

        private void lke_MSS_StoreList_EditValueChanged(object sender, EventArgs e)
        {
            dt = FileProcess.LoadTable("OperatingCostSummaryLast12Months " + this.lke_MSS_StoreList.EditValue + "," + this.radioGroupPeriodOption.SelectedIndex);
            this.grcCustomerProfitabilitySummary.DataSource = dt;
        }

        private void rpe_hle_CustomerAnalysis_Click(object sender, EventArgs e)
        {
            int OperatingCostMonthlyID = AppSetting.LastOperationMonthID;
            int StoreID = Convert.ToInt32(this.lke_MSS_StoreList.EditValue);
            int CustomerID = Convert.ToInt32(this.grvCustomerProfitabilitySummary.GetFocusedRowCellValue("CustomerMainOnReport".ToString()));

            frm_CRM_OperatingCostViewByCustomer frm = new frm_CRM_OperatingCostViewByCustomer(OperatingCostMonthlyID, StoreID, CustomerID);
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
        }

        private void dockPanelProfitability_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {

            
            int customerID = Convert.ToInt32(this.grvCustomerProfitabilitySummary.GetFocusedRowCellValue("CustomerMainOnReport"));
            int storeID = Convert.ToInt32(this.lke_MSS_StoreList.EditValue);

            if (this.Profitability == null)
            {
                this.Profitability = new urc_CRM_12MonthProfitability(customerID, storeID);
                this.Profitability.Parent = this.dockPanelProfitability;

            }
            else
            {
                this.Profitability.InitProfitabilityDataExtended(customerID,storeID);
            }
            this.Profitability.Show();
            this.Profitability.Dock = DockStyle.Fill;
        }

        private void dockPanel36MonthOperations_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            int customerID = Convert.ToInt32(this.grvCustomerProfitabilitySummary.GetFocusedRowCellValue("CustomerMainOnReport"));
            int storeID = Convert.ToInt32(this.lke_MSS_StoreList.EditValue);

            if (this.monthsOperation == null)
            {
                this.monthsOperation = new urc_CRM_36MonthsOperation(customerID, storeID);
                this.monthsOperation.Parent = this.dockPanel36MonthOperations;
            }
            else
            {
                this.monthsOperation.init36MonthsOperation(customerID, storeID);
            }
            this.monthsOperation.Show();
            this.monthsOperation.Dock = DockStyle.Fill;
        }

        private void radioGroup1_Properties_SelectedIndexChanged(object sender, EventArgs e)
        {

            dt = FileProcess.LoadTable("OperatingCostSummaryLast12Months " + this.lke_MSS_StoreList.EditValue + "," + this.radioGroupPeriodOption.SelectedIndex);
            this.grcCustomerProfitabilitySummary.DataSource = dt;
        }

        private void rpe_hle_CustomerOperation36months_Click(object sender, EventArgs e)
        {
            int customerID = Convert.ToInt32(this.grvCustomerProfitabilitySummary.GetFocusedRowCellValue("CustomerMainOnReport"));
            int storeID = Convert.ToInt32(this.lke_MSS_StoreList.EditValue);
            string customerName = this.grvCustomerProfitabilitySummary.GetFocusedRowCellValue("CustomerName").ToString();
            frm_S_CustomerStock36months2 frm = new frm_S_CustomerStock36months2(customerID, customerName, storeID);
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
        }

        private void dockPanelPlotChart_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            this.chartProfitabilityPlot.DataSource = dt;
            XYDiagram diagram = (XYDiagram)chartProfitabilityPlot.Diagram;
            diagram.AxisY.VisualRange.SetMinMaxValues(0, Convert.ToInt32(this.textMaxY.Text));
            diagram.AxisX.VisualRange.SetMinMaxValues(0, Convert.ToInt32(this.textMaxX.Text));
            seriesTargetLine.ArgumentScaleType = ScaleType.Numerical;

            // Add points to it.
            seriesTargetLine.Points.Add(new SeriesPoint(0, Convert.ToInt32(this.textMaxY.Text)/2));
            seriesTargetLine.Points.Add(new SeriesPoint(Convert.ToInt32(this.textMaxX.Text)/2, 0));
            this.chartProfitabilityPlot.Series.Add(seriesTargetLine);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textMaxY_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                seriesTargetLine.Points.Clear();
                seriesTargetLine.Points.Add(new SeriesPoint(0, Convert.ToInt32(this.textMaxY.Text) / 2));
                seriesTargetLine.Points.Add(new SeriesPoint(Convert.ToInt32(this.textMaxX.Text) / 2, 0));
                XYDiagram diagram = (XYDiagram)chartProfitabilityPlot.Diagram;
                diagram.AxisY.VisualRange.SetMinMaxValues(0, Convert.ToInt32(this.textMaxY.Text));
            }

        }

        private void textMaxX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                seriesTargetLine.Points.Clear();
                seriesTargetLine.Points.Add(new SeriesPoint(0, Convert.ToInt32(this.textMaxY.Text) / 2));
                seriesTargetLine.Points.Add(new SeriesPoint(Convert.ToInt32(this.textMaxX.Text) / 2, 0));

                XYDiagram diagram = (XYDiagram)chartProfitabilityPlot.Diagram;
                //diagram.AxisX.VisualRange.Auto = false;
                diagram.AxisX.VisualRange.SetMinMaxValues(0, Convert.ToInt32(this.textMaxX.Text));
            }
        }
    }
}
