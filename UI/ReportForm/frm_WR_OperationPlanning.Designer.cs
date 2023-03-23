namespace UI.ReportForm
{
    partial class frm_WR_OperationPlanning
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraPivotGrid.PivotGridFormatRule pivotGridFormatRule1 = new DevExpress.XtraPivotGrid.PivotGridFormatRule();
            DevExpress.XtraEditors.FormatConditionRule2ColorScale formatConditionRule2ColorScale1 = new DevExpress.XtraEditors.FormatConditionRule2ColorScale();
            DevExpress.XtraPivotGrid.FormatRuleTotalTypeSettings formatRuleTotalTypeSettings1 = new DevExpress.XtraPivotGrid.FormatRuleTotalTypeSettings();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_WR_OperationPlanning));
            this.pivotGridFieldKgs = new DevExpress.XtraPivotGrid.PivotGridField();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnReviewOrders = new DevExpress.XtraEditors.SimpleButton();
            this.btnNewBooking = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonExportExcel = new DevExpress.XtraEditors.SimpleButton();
            this.lke_WarehouseID = new DevExpress.XtraEditors.LookUpEdit();
            this.pvgOperationPlanning = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.pivotGridField2 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridFieldCtns = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridFieldOrders = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField6 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField3 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField4 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.btnPrintPreview = new DevExpress.XtraEditors.SimpleButton();
            this.dateEditReportDate = new DevExpress.XtraEditors.DateEdit();
            this.btn_Refresh = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lke_WarehouseID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pvgOperationPlanning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditReportDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditReportDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            this.SuspendLayout();
            // 
            // pivotGridFieldKgs
            // 
            this.pivotGridFieldKgs.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.pivotGridFieldKgs.AreaIndex = 0;
            this.pivotGridFieldKgs.Caption = "Kgs";
            this.pivotGridFieldKgs.CellFormat.FormatString = "n0";
            this.pivotGridFieldKgs.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivotGridFieldKgs.FieldName = "Kgs";
            this.pivotGridFieldKgs.MinWidth = 22;
            this.pivotGridFieldKgs.Name = "pivotGridFieldKgs";
            this.pivotGridFieldKgs.Options.AllowRunTimeSummaryChange = true;
            this.pivotGridFieldKgs.ValueFormat.FormatString = "n0";
            this.pivotGridFieldKgs.ValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivotGridFieldKgs.Width = 62;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnReviewOrders);
            this.layoutControl1.Controls.Add(this.btnNewBooking);
            this.layoutControl1.Controls.Add(this.simpleButtonExportExcel);
            this.layoutControl1.Controls.Add(this.lke_WarehouseID);
            this.layoutControl1.Controls.Add(this.pvgOperationPlanning);
            this.layoutControl1.Controls.Add(this.btnPrintPreview);
            this.layoutControl1.Controls.Add(this.dateEditReportDate);
            this.layoutControl1.Controls.Add(this.btn_Refresh);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1924, 979);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnReviewOrders
            // 
            this.btnReviewOrders.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Question;
            this.btnReviewOrders.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnReviewOrders.Appearance.Options.UseBackColor = true;
            this.btnReviewOrders.Appearance.Options.UseFont = true;
            this.btnReviewOrders.Location = new System.Drawing.Point(1322, 15);
            this.btnReviewOrders.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReviewOrders.MaximumSize = new System.Drawing.Size(141, 30);
            this.btnReviewOrders.MinimumSize = new System.Drawing.Size(141, 30);
            this.btnReviewOrders.Name = "btnReviewOrders";
            this.btnReviewOrders.Size = new System.Drawing.Size(141, 30);
            this.btnReviewOrders.StyleController = this.layoutControl1;
            this.btnReviewOrders.TabIndex = 20;
            this.btnReviewOrders.Text = "Review Orders ";
            this.btnReviewOrders.Click += new System.EventHandler(this.btnReviewOrders_Click);
            // 
            // btnNewBooking
            // 
            this.btnNewBooking.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Question;
            this.btnNewBooking.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnNewBooking.Appearance.Options.UseBackColor = true;
            this.btnNewBooking.Appearance.Options.UseFont = true;
            this.btnNewBooking.Location = new System.Drawing.Point(1471, 15);
            this.btnNewBooking.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNewBooking.MaximumSize = new System.Drawing.Size(141, 30);
            this.btnNewBooking.MinimumSize = new System.Drawing.Size(141, 30);
            this.btnNewBooking.Name = "btnNewBooking";
            this.btnNewBooking.Size = new System.Drawing.Size(141, 30);
            this.btnNewBooking.StyleController = this.layoutControl1;
            this.btnNewBooking.TabIndex = 19;
            this.btnNewBooking.Text = "Booking";
            this.btnNewBooking.Click += new System.EventHandler(this.btnNewBooking_Click);
            // 
            // simpleButtonExportExcel
            // 
            this.simpleButtonExportExcel.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Question;
            this.simpleButtonExportExcel.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.simpleButtonExportExcel.Appearance.Options.UseBackColor = true;
            this.simpleButtonExportExcel.Appearance.Options.UseFont = true;
            this.simpleButtonExportExcel.Location = new System.Drawing.Point(1620, 15);
            this.simpleButtonExportExcel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.simpleButtonExportExcel.MaximumSize = new System.Drawing.Size(141, 30);
            this.simpleButtonExportExcel.MinimumSize = new System.Drawing.Size(141, 30);
            this.simpleButtonExportExcel.Name = "simpleButtonExportExcel";
            this.simpleButtonExportExcel.Size = new System.Drawing.Size(141, 30);
            this.simpleButtonExportExcel.StyleController = this.layoutControl1;
            this.simpleButtonExportExcel.TabIndex = 18;
            this.simpleButtonExportExcel.Text = "Export Excel";
            this.simpleButtonExportExcel.Click += new System.EventHandler(this.simpleButtonExportExcel_Click);
            // 
            // lke_WarehouseID
            // 
            this.lke_WarehouseID.Location = new System.Drawing.Point(404, 15);
            this.lke_WarehouseID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lke_WarehouseID.MinimumSize = new System.Drawing.Size(0, 30);
            this.lke_WarehouseID.Name = "lke_WarehouseID";
            this.lke_WarehouseID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lke_WarehouseID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("WarehouseID", "WarehouseID", 22, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("WarehouseDescription", "Warehouse ", 22, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lke_WarehouseID.Properties.NullText = "";
            this.lke_WarehouseID.Size = new System.Drawing.Size(265, 32);
            this.lke_WarehouseID.StyleController = this.layoutControl1;
            this.lke_WarehouseID.TabIndex = 17;
            // 
            // pvgOperationPlanning
            // 
            this.pvgOperationPlanning.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.pivotGridField2,
            this.pivotGridFieldKgs,
            this.pivotGridFieldCtns,
            this.pivotGridFieldOrders,
            this.pivotGridField6,
            this.pivotGridField3,
            this.pivotGridField4});
            pivotGridFormatRule1.Measure = this.pivotGridFieldKgs;
            pivotGridFormatRule1.Name = "Format0";
            formatConditionRule2ColorScale1.PredefinedName = "Green, Yellow, Red";
            pivotGridFormatRule1.Rule = formatConditionRule2ColorScale1;
            pivotGridFormatRule1.Settings = formatRuleTotalTypeSettings1;
            this.pvgOperationPlanning.FormatRules.Add(pivotGridFormatRule1);
            this.pvgOperationPlanning.Location = new System.Drawing.Point(12, 53);
            this.pvgOperationPlanning.LookAndFeel.SkinName = "Office 2016 Colorful";
            this.pvgOperationPlanning.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pvgOperationPlanning.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pvgOperationPlanning.Name = "pvgOperationPlanning";
            this.pvgOperationPlanning.OptionsBehavior.CopyToClipboardWithFieldValues = true;
            this.pvgOperationPlanning.OptionsDataField.RowHeaderWidth = 112;
            this.pvgOperationPlanning.OptionsMenu.EnableFormatRulesMenu = true;
            this.pvgOperationPlanning.OptionsView.RowTreeOffset = 24;
            this.pvgOperationPlanning.OptionsView.RowTreeWidth = 112;
            this.pvgOperationPlanning.Size = new System.Drawing.Size(1900, 913);
            this.pvgOperationPlanning.TabIndex = 16;
            this.pvgOperationPlanning.CellClick += new DevExpress.XtraPivotGrid.PivotCellEventHandler(this.pvgOperationPlanning_CellClick);
            // 
            // pivotGridField2
            // 
            this.pivotGridField2.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.pivotGridField2.AreaIndex = 0;
            this.pivotGridField2.Caption = "Hour Slot";
            this.pivotGridField2.FieldName = "TimeSlot";
            this.pivotGridField2.MinWidth = 22;
            this.pivotGridField2.Name = "pivotGridField2";
            this.pivotGridField2.Options.AllowRunTimeSummaryChange = true;
            this.pivotGridField2.Width = 112;
            // 
            // pivotGridFieldCtns
            // 
            this.pivotGridFieldCtns.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.pivotGridFieldCtns.AreaIndex = 1;
            this.pivotGridFieldCtns.Caption = "Ctns";
            this.pivotGridFieldCtns.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivotGridFieldCtns.FieldName = "Ctns";
            this.pivotGridFieldCtns.MinWidth = 22;
            this.pivotGridFieldCtns.Name = "pivotGridFieldCtns";
            this.pivotGridFieldCtns.Options.AllowRunTimeSummaryChange = true;
            this.pivotGridFieldCtns.ValueFormat.FormatString = "n0";
            this.pivotGridFieldCtns.ValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivotGridFieldCtns.Width = 49;
            // 
            // pivotGridFieldOrders
            // 
            this.pivotGridFieldOrders.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.pivotGridFieldOrders.AreaIndex = 2;
            this.pivotGridFieldOrders.Caption = "Order";
            this.pivotGridFieldOrders.CellFormat.FormatString = "n0";
            this.pivotGridFieldOrders.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivotGridFieldOrders.FieldName = "OrderNumber";
            this.pivotGridFieldOrders.MinWidth = 22;
            this.pivotGridFieldOrders.Name = "pivotGridFieldOrders";
            this.pivotGridFieldOrders.Options.AllowRunTimeSummaryChange = true;
            this.pivotGridFieldOrders.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            this.pivotGridFieldOrders.ValueFormat.FormatString = "n0";
            this.pivotGridFieldOrders.ValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivotGridFieldOrders.Width = 53;
            // 
            // pivotGridField6
            // 
            this.pivotGridField6.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField6.AreaIndex = 0;
            this.pivotGridField6.Caption = "Dock";
            this.pivotGridField6.FieldName = "DockNumber";
            this.pivotGridField6.MinWidth = 22;
            this.pivotGridField6.Name = "pivotGridField6";
            this.pivotGridField6.Options.AllowRunTimeSummaryChange = true;
            this.pivotGridField6.Width = 112;
            // 
            // pivotGridField3
            // 
            this.pivotGridField3.AreaIndex = 0;
            this.pivotGridField3.Caption = "Vehicle";
            this.pivotGridField3.FieldName = "VehicleNumber";
            this.pivotGridField3.MinWidth = 22;
            this.pivotGridField3.Name = "pivotGridField3";
            this.pivotGridField3.Options.AllowRunTimeSummaryChange = true;
            this.pivotGridField3.Width = 112;
            // 
            // pivotGridField4
            // 
            this.pivotGridField4.AreaIndex = 1;
            this.pivotGridField4.Caption = "Customer";
            this.pivotGridField4.FieldName = "CustomerNumber";
            this.pivotGridField4.MinWidth = 22;
            this.pivotGridField4.Name = "pivotGridField4";
            this.pivotGridField4.Options.AllowRunTimeSummaryChange = true;
            this.pivotGridField4.Width = 112;
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Question;
            this.btnPrintPreview.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnPrintPreview.Appearance.Options.UseBackColor = true;
            this.btnPrintPreview.Appearance.Options.UseFont = true;
            this.btnPrintPreview.Location = new System.Drawing.Point(1769, 15);
            this.btnPrintPreview.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPrintPreview.MaximumSize = new System.Drawing.Size(141, 30);
            this.btnPrintPreview.MinimumSize = new System.Drawing.Size(141, 30);
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.Size = new System.Drawing.Size(141, 30);
            this.btnPrintPreview.StyleController = this.layoutControl1;
            this.btnPrintPreview.TabIndex = 4;
            this.btnPrintPreview.Text = "Preview";
            this.btnPrintPreview.Click += new System.EventHandler(this.btnPrintPreview_Click);
            // 
            // dateEditReportDate
            // 
            this.dateEditReportDate.EditValue = null;
            this.dateEditReportDate.Location = new System.Drawing.Point(102, 15);
            this.dateEditReportDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateEditReportDate.MinimumSize = new System.Drawing.Size(0, 30);
            this.dateEditReportDate.Name = "dateEditReportDate";
            this.dateEditReportDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditReportDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditReportDate.Size = new System.Drawing.Size(206, 32);
            this.dateEditReportDate.StyleController = this.layoutControl1;
            this.dateEditReportDate.TabIndex = 14;
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Question;
            this.btn_Refresh.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btn_Refresh.Appearance.Options.UseBackColor = true;
            this.btn_Refresh.Appearance.Options.UseFont = true;
            this.btn_Refresh.Location = new System.Drawing.Point(677, 15);
            this.btn_Refresh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Refresh.MaximumSize = new System.Drawing.Size(141, 30);
            this.btn_Refresh.MinimumSize = new System.Drawing.Size(141, 30);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(141, 30);
            this.btn_Refresh.StyleController = this.layoutControl1;
            this.btn_Refresh.TabIndex = 15;
            this.btn_Refresh.Text = "Refresh";
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem5,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem8});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1924, 979);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(812, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 4, 4);
            this.emptySpaceItem1.Size = new System.Drawing.Size(496, 40);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnPrintPreview;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(1755, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(149, 40);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.dateEditReportDate;
            this.layoutControlItem2.CustomizationFormText = "Report Date";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(302, 40);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem2.Text = "Report Date";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(84, 19);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btn_Refresh;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(663, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(149, 40);
            this.layoutControlItem5.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.pvgOperationPlanning;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 40);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(1904, 917);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.lke_WarehouseID;
            this.layoutControlItem4.Location = new System.Drawing.Point(302, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(361, 40);
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem4.Text = "Warehouse";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(84, 19);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.simpleButtonExportExcel;
            this.layoutControlItem6.Location = new System.Drawing.Point(1606, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(149, 40);
            this.layoutControlItem6.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.btnNewBooking;
            this.layoutControlItem7.Location = new System.Drawing.Point(1457, 0);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(149, 40);
            this.layoutControlItem7.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.btnReviewOrders;
            this.layoutControlItem8.Location = new System.Drawing.Point(1308, 0);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(149, 40);
            this.layoutControlItem8.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // frm_WR_OperationPlanning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 979);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_WR_OperationPlanning";
            this.Text = "Operation Planning";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lke_WarehouseID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pvgOperationPlanning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditReportDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditReportDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton btnPrintPreview;
        private DevExpress.XtraEditors.DateEdit dateEditReportDate;
        private DevExpress.XtraEditors.SimpleButton btn_Refresh;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraPivotGrid.PivotGridControl pvgOperationPlanning;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField2;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridFieldKgs;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridFieldCtns;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridFieldOrders;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField6;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField3;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField4;
        private DevExpress.XtraEditors.LookUpEdit lke_WarehouseID;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.SimpleButton simpleButtonExportExcel;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.SimpleButton btnNewBooking;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.SimpleButton btnReviewOrders;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
    }
}