using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraPrinting;
using System.Data.Entity;
using DA;
using UI.ReportFile;
using UI.Helper;
using DevExpress.XtraGrid;
using DevExpress.XtraEditors;
using DevExpress.XtraPivotGrid;
using SCSVN.Report;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_Dialog_Trip_PickSummary : Form
    {
        private int varTripID = 0;
        private IEnumerable<ST_WMS_LoadTripsManagement_Result> currentTripList;
        private ST_WMS_LoadTripsManagement_Result currentTrip;

        public frm_WM_Dialog_Trip_PickSummary(int TripID)
        {
            InitializeComponent();
            varTripID = TripID;
            DataProcess<ST_WMS_LoadTripsManagement_Result> tripManagementDA = new DataProcess<ST_WMS_LoadTripsManagement_Result>();
            this.currentTripList = tripManagementDA.Executing("ST_WMS_LoadTripsManagement @TripDate = {0}, @TripID = {1}", DateTime.Now.AddDays(-10), TripID);
            this.currentTrip = currentTripList.Where(t => t.TripID == TripID).FirstOrDefault();

            this.pivotPickingSummary.DataSource = FileProcess.LoadTable("STTripPickingList " + TripID);

        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            pivotPickingSummary.ShowPrintPreview();
        }

        private void pivotPickingSummary_Click(object sender, EventArgs e)
        {
            
        }

        private void pivotPickingSummary_CellClick(object sender, DevExpress.XtraPivotGrid.PivotCellEventArgs e)
        {
            Form form = new Form();
            form.Text = "Records";
            // Place a DataGrid control on the form.
            DataGridView grid = new DataGridView();
            grid.Parent = form;
            grid.Dock = DockStyle.Fill;
            // Get the recrd set associated with the current cell and bind it to the grid.
            grid.DataSource = e.CreateDrillDownDataSource();
            form.Bounds = new Rectangle(100, 100, 1000, 400);
            // Display the form.
            form.ShowDialog();
            form.Dispose();
        }

        private void simpleButtonExportExcel_Click(object sender, EventArgs e)
        {
            var pivotExportOptions = new DevExpress.XtraPivotGrid.PivotXlsxExportOptions();
            pivotExportOptions.ExportType = DevExpress.Export.ExportType.DataAware;
            SaveFileDialog sfd = new SaveFileDialog();
            //sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            sfd.Filter = "Excel 97-2003 (*.xls)|*.xls|Excel 07-2010 (*.xlsx)|*.xlsx";

            DialogResult dr = sfd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                pivotPickingSummary.ExportToXlsx(sfd.FileName, pivotExportOptions);
                try
                {
                    System.Diagnostics.Process.Start("Excel", sfd.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            sfd.Dispose();
        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            //DataProcess<Customers> customerDa = new DataProcess<Customers>();
            //string CustomerType = customerDa.Select(c => c.CustomerID == currentTrip.CustomerID).FirstOrDefault().CustomerType;
            //if (CustomerType == CustomerTypeEnum.RANDOM_WEIGHT)
            DataTable customerRequired = FileProcess.LoadTable("STCustomerRequirementPrint @CustomerMainID=" + currentTrip.CustomerMainID + ",@Flag=2, @ReceivingOrderID=null");
            string customerRequire = "";
            foreach (DataRow row in customerRequired.Rows)
            {
                customerRequire += row["RequirementDetails"].ToString();
            }
            
            rptDispatchingPlanA4New_TripSummary rpt = new rptDispatchingPlanA4New_TripSummary();
            //rptDispatchingNote_Trip report = new rptDispatchingNote_Trip();
            rpt.DataSource = FileProcess.LoadTable("STTripPickinglistMainReport " + varTripID);

            rpt.RequestParameters = false;
            if (customerRequired != null)
            {
                rpt.Parameters["varCustomerRequired"].Value = customerRequire;
            }
            rpt.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
            ReportPrintToolWMS PrintTool = new ReportPrintToolWMS(rpt);
            PrintTool.ShowPreview();
            
            ///printMultiNote(true);
        }

        private void btn_PreviewDO_Click(object sender, EventArgs e)
        {
            InitDesign();
           


        }
        private void InitDesign()
        {
            this.fieldLabel1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            this.fieldLabel1.AreaIndex = 18;
            this.fieldLabel1.FieldName = "Label";
            this.fieldLabel1.MinWidth = 15;
            this.fieldLabel1.Name = "fieldLabel1";
            this.fieldLabel1.Width = 90;

            this.fieldUseByDate1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            this.fieldUseByDate1.AreaIndex = 19;
            this.fieldUseByDate1.FieldName = "UseByDate";
            this.fieldUseByDate1.MinWidth = 15;
            this.fieldUseByDate1.Name = "fieldUseByDate1";
            this.fieldUseByDate1.Width = 75;

            this.pivotGridField1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            this.pivotGridField1.AreaIndex = 20;
            this.pivotGridField1.Caption = "T*";
            this.pivotGridField1.FieldName = "TemperatureRequire";
            this.pivotGridField1.MinWidth = 15;
            this.pivotGridField1.Name = "pivotGridField1";
            this.pivotGridField1.Width = 37;

            this.pivotGridField5.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            this.pivotGridField5.AreaIndex = 21;
            this.pivotGridField5.Caption = "Ctns";
            this.pivotGridField5.CellFormat.FormatString = "n0";
            this.pivotGridField5.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivotGridField5.FieldName = "QtyCtns";
            this.pivotGridField5.MinWidth = 15;
            this.pivotGridField5.Name = "pivotGridField5";
            this.pivotGridField5.Width = 45;
           

            this.pivotGridField6.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            this.pivotGridField6.AreaIndex =22;
            this.pivotGridField6.Caption = "QtyPcs";
            this.pivotGridField6.CellFormat.FormatString = "n0";
            this.pivotGridField6.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivotGridField6.FieldName = "QtyPcs";
            this.pivotGridField6.MinWidth = 15;
            this.pivotGridField6.Name = "pivotGridField6";
            this.pivotGridField6.Width = 45;
           

            this.pivotGridField7.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            this.pivotGridField7.AreaIndex = 23;
            this.pivotGridField7.Caption = "DOKgs";
            this.pivotGridField7.CellFormat.FormatString = "n2";
            this.pivotGridField7.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivotGridField7.FieldName = "DispatchedWeight";
            this.pivotGridField7.MinWidth = 15;
            this.pivotGridField7.Name = "pivotGridField7";
            this.pivotGridField7.Width = 60;

            this.fieldCustomerRef1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            this.fieldCustomerRef1.AreaIndex = 24;
            this.fieldCustomerRef1.FieldName = "CustomerRef";
            this.fieldCustomerRef1.MinWidth = 15;
            this.fieldCustomerRef1.Name = "fieldCustomerRef1";
            this.fieldCustomerRef1.Width = 75;

            this.fieldPackages.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            this.fieldPackages.AreaIndex = 25;
            this.fieldPackages.Caption = "Pack";
            this.fieldPackages.FieldName = "Packages";
            this.fieldPackages.MinWidth = 15;
            this.fieldPackages.Name = "fieldPackages";
            this.fieldPackages.Width = 52;
            //Area
            this.fieldOrderNumber1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldOrderNumber1.AreaIndex = 0;
            this.fieldOrderNumber1.FieldName = "OrderNumber";
            this.fieldOrderNumber1.MinWidth = 15;
            this.fieldOrderNumber1.Name = "fieldOrderNumber1";
            this.fieldOrderNumber1.Width = 75;

            this.fieldPackages.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldPackages.AreaIndex = 3;
            this.fieldPackages.Caption = "Pack";
            this.fieldPackages.FieldName = "Packages";
            this.fieldPackages.MinWidth = 15;
            this.fieldPackages.Name = "fieldPackages";
            this.fieldPackages.Width = 52;

            //PivotGridFormatRule pivotGridFormatRule1 = new PivotGridFormatRule();
            //pivotGridFormatRule1.Measure = this.fieldQuantityOfPackages1;
            //pivotGridFormatRule1.Name = "Format1";
            //FormatConditionRuleValue formatConditionRuleValue1 = new FormatConditionRuleValue();
            //formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Expression;
            //formatConditionRuleValue1.Expression = "[Packages] = \'UN\'";
            //formatConditionRuleValue1.PredefinedName = "Bold Text";
            //pivotGridFormatRule1.Rule = formatConditionRuleValue1;

            //FormatRuleTotalTypeSettings formatRuleTotalTypeSettings1 = new FormatRuleTotalTypeSettings();
            //formatRuleTotalTypeSettings1.ApplyToCustomTotalCell = false;
            //formatRuleTotalTypeSettings1.ApplyToGrandTotalCell = false;
            //formatRuleTotalTypeSettings1.ApplyToTotalCell = false;
            //pivotGridFormatRule1.Settings = formatRuleTotalTypeSettings1;
            //this.pivotPickingSummary.FormatRules.Add(pivotGridFormatRule1);


        }
    }
}
