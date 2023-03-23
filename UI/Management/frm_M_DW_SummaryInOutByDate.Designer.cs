namespace UI.Management
{
    partial class frm_M_DW_SummaryInOutByDate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_M_DW_SummaryInOutByDate));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grdSummary = new DevExpress.XtraGrid.GridControl();
            this.grvSummary = new Common.Controls.WMSGridView();
            this.grcReportDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcIn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcOut = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcOpenDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_btn_OpenDate = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.dtFrom = new DevExpress.XtraEditors.DateEdit();
            this.dtTo = new DevExpress.XtraEditors.DateEdit();
            this.btnReport = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnWeekly = new DevExpress.XtraEditors.SimpleButton();
            this.btnDaily = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_btn_OpenDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // rbcbase
            // 
            this.rbcbase.ExpandCollapseItem.Id = 0;
            this.rbcbase.OptionsCustomizationForm.FormIcon = ((System.Drawing.Icon)(resources.GetObject("resource.FormIcon")));
            // 
            // 
            // 
            this.rbcbase.SearchEditItem.AccessibleName = "Search Item";
            this.rbcbase.SearchEditItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.rbcbase.SearchEditItem.EditWidth = 150;
            this.rbcbase.SearchEditItem.Id = -5000;
            this.rbcbase.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.rbcbase.Size = new System.Drawing.Size(695, 51);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grdSummary);
            this.layoutControl1.Controls.Add(this.dtFrom);
            this.layoutControl1.Controls.Add(this.dtTo);
            this.layoutControl1.Controls.Add(this.btnReport);
            this.layoutControl1.Controls.Add(this.btnRefresh);
            this.layoutControl1.Controls.Add(this.btnWeekly);
            this.layoutControl1.Controls.Add(this.btnDaily);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 51);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(576, 73, 562, 500);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(695, 509);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grdSummary
            // 
            this.grdSummary.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.grdSummary.Location = new System.Drawing.Point(12, 46);
            this.grdSummary.MainView = this.grvSummary;
            this.grdSummary.MenuManager = this.rbcbase;
            this.grdSummary.Name = "grdSummary";
            this.grdSummary.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpi_btn_OpenDate});
            this.grdSummary.Size = new System.Drawing.Size(671, 403);
            this.grdSummary.TabIndex = 6;
            this.grdSummary.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvSummary});
            // 
            // grvSummary
            // 
            this.grvSummary.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grvSummary.Appearance.FooterPanel.Options.UseFont = true;
            this.grvSummary.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvSummary.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grcReportDate,
            this.grcIn,
            this.grcOut,
            this.grcTotal,
            this.grcOpenDate});
            this.grvSummary.DetailHeight = 458;
            this.grvSummary.FixedLineWidth = 3;
            this.grvSummary.GridControl = this.grdSummary;
            this.grvSummary.Name = "grvSummary";
            this.grvSummary.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvSummary.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grvSummary.OptionsSelection.MultiSelect = true;
            this.grvSummary.OptionsView.ShowFooter = true;
            this.grvSummary.OptionsView.ShowGroupPanel = false;
            this.grvSummary.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvSummary.PaintStyleName = "Skin";
            // 
            // grcReportDate
            // 
            this.grcReportDate.AppearanceCell.Options.UseTextOptions = true;
            this.grcReportDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcReportDate.AppearanceHeader.Options.UseTextOptions = true;
            this.grcReportDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcReportDate.Caption = "DATE";
            this.grcReportDate.FieldName = "ReportDate";
            this.grcReportDate.MinWidth = 27;
            this.grcReportDate.Name = "grcReportDate";
            this.grcReportDate.OptionsColumn.AllowFocus = false;
            this.grcReportDate.OptionsColumn.ReadOnly = true;
            this.grcReportDate.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ReportDate", "TOTAL:")});
            this.grcReportDate.Visible = true;
            this.grcReportDate.VisibleIndex = 0;
            this.grcReportDate.Width = 100;
            // 
            // grcIn
            // 
            this.grcIn.AppearanceCell.Options.UseTextOptions = true;
            this.grcIn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grcIn.AppearanceHeader.Options.UseTextOptions = true;
            this.grcIn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcIn.Caption = "IN";
            this.grcIn.DisplayFormat.FormatString = "n0";
            this.grcIn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.grcIn.FieldName = "TotalWeightIn";
            this.grcIn.MinWidth = 27;
            this.grcIn.Name = "grcIn";
            this.grcIn.OptionsColumn.AllowFocus = false;
            this.grcIn.OptionsColumn.ReadOnly = true;
            this.grcIn.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalWeightIn", "{0:n0}")});
            this.grcIn.Visible = true;
            this.grcIn.VisibleIndex = 1;
            this.grcIn.Width = 100;
            // 
            // grcOut
            // 
            this.grcOut.AppearanceCell.Options.UseTextOptions = true;
            this.grcOut.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grcOut.AppearanceHeader.Options.UseTextOptions = true;
            this.grcOut.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcOut.Caption = "OUT";
            this.grcOut.DisplayFormat.FormatString = "n0";
            this.grcOut.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.grcOut.FieldName = "TotalWeightOut";
            this.grcOut.MinWidth = 27;
            this.grcOut.Name = "grcOut";
            this.grcOut.OptionsColumn.AllowFocus = false;
            this.grcOut.OptionsColumn.ReadOnly = true;
            this.grcOut.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalWeightOut", "{0:n0}")});
            this.grcOut.Visible = true;
            this.grcOut.VisibleIndex = 2;
            this.grcOut.Width = 100;
            // 
            // grcTotal
            // 
            this.grcTotal.AppearanceCell.Options.UseTextOptions = true;
            this.grcTotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grcTotal.AppearanceHeader.Options.UseTextOptions = true;
            this.grcTotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcTotal.Caption = "TOTAL";
            this.grcTotal.DisplayFormat.FormatString = "n0";
            this.grcTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.grcTotal.FieldName = "TotalInOut";
            this.grcTotal.MinWidth = 27;
            this.grcTotal.Name = "grcTotal";
            this.grcTotal.OptionsColumn.AllowFocus = false;
            this.grcTotal.OptionsColumn.ReadOnly = true;
            this.grcTotal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalInOut", "{0:n0}")});
            this.grcTotal.Visible = true;
            this.grcTotal.VisibleIndex = 3;
            this.grcTotal.Width = 100;
            // 
            // grcOpenDate
            // 
            this.grcOpenDate.ColumnEdit = this.rpi_btn_OpenDate;
            this.grcOpenDate.MaxWidth = 47;
            this.grcOpenDate.MinWidth = 47;
            this.grcOpenDate.Name = "grcOpenDate";
            this.grcOpenDate.Visible = true;
            this.grcOpenDate.VisibleIndex = 4;
            this.grcOpenDate.Width = 47;
            // 
            // rpi_btn_OpenDate
            // 
            this.rpi_btn_OpenDate.AutoHeight = false;
            this.rpi_btn_OpenDate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.rpi_btn_OpenDate.Name = "rpi_btn_OpenDate";
            this.rpi_btn_OpenDate.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // dtFrom
            // 
            this.dtFrom.EditValue = null;
            this.dtFrom.Location = new System.Drawing.Point(49, 14);
            this.dtFrom.MenuManager = this.rbcbase;
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtFrom.Size = new System.Drawing.Size(144, 26);
            this.dtFrom.StyleController = this.layoutControl1;
            this.dtFrom.TabIndex = 4;
            // 
            // dtTo
            // 
            this.dtTo.EditValue = null;
            this.dtTo.Location = new System.Drawing.Point(236, 14);
            this.dtTo.MenuManager = this.rbcbase;
            this.dtTo.Name = "dtTo";
            this.dtTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtTo.Size = new System.Drawing.Size(149, 26);
            this.dtTo.StyleController = this.layoutControl1;
            this.dtTo.TabIndex = 5;
            // 
            // btnReport
            // 
            this.btnReport.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnReport.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnReport.Appearance.Options.UseBackColor = true;
            this.btnReport.Appearance.Options.UseFont = true;
            this.btnReport.Appearance.Options.UseTextOptions = true;
            this.btnReport.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnReport.AppearanceDisabled.Options.UseTextOptions = true;
            this.btnReport.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnReport.AppearanceHovered.Options.UseTextOptions = true;
            this.btnReport.AppearanceHovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnReport.AppearancePressed.Options.UseTextOptions = true;
            this.btnReport.AppearancePressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnReport.Location = new System.Drawing.Point(290, 455);
            this.btnReport.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnReport.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(125, 40);
            this.btnReport.StyleController = this.layoutControl1;
            this.btnReport.TabIndex = 7;
            this.btnReport.Text = "Report";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Question;
            this.btnRefresh.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.Appearance.Options.UseBackColor = true;
            this.btnRefresh.Appearance.Options.UseFont = true;
            this.btnRefresh.Appearance.Options.UseTextOptions = true;
            this.btnRefresh.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnRefresh.AppearanceDisabled.Options.UseTextOptions = true;
            this.btnRefresh.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnRefresh.AppearanceHovered.Options.UseTextOptions = true;
            this.btnRefresh.AppearanceHovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnRefresh.AppearancePressed.Options.UseTextOptions = true;
            this.btnRefresh.AppearancePressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnRefresh.Location = new System.Drawing.Point(157, 455);
            this.btnRefresh.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnRefresh.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(125, 40);
            this.btnRefresh.StyleController = this.layoutControl1;
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "Refresh";
            // 
            // btnWeekly
            // 
            this.btnWeekly.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnWeekly.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnWeekly.Appearance.Options.UseBackColor = true;
            this.btnWeekly.Appearance.Options.UseFont = true;
            this.btnWeekly.Appearance.Options.UseTextOptions = true;
            this.btnWeekly.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnWeekly.AppearanceDisabled.Options.UseTextOptions = true;
            this.btnWeekly.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnWeekly.AppearanceHovered.Options.UseTextOptions = true;
            this.btnWeekly.AppearanceHovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnWeekly.AppearancePressed.Options.UseTextOptions = true;
            this.btnWeekly.AppearancePressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnWeekly.Location = new System.Drawing.Point(423, 455);
            this.btnWeekly.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnWeekly.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnWeekly.Name = "btnWeekly";
            this.btnWeekly.Size = new System.Drawing.Size(125, 40);
            this.btnWeekly.StyleController = this.layoutControl1;
            this.btnWeekly.TabIndex = 9;
            this.btnWeekly.Text = "Weekly chart";
            // 
            // btnDaily
            // 
            this.btnDaily.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnDaily.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnDaily.Appearance.Options.UseBackColor = true;
            this.btnDaily.Appearance.Options.UseFont = true;
            this.btnDaily.Appearance.Options.UseTextOptions = true;
            this.btnDaily.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnDaily.AppearanceDisabled.Options.UseTextOptions = true;
            this.btnDaily.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnDaily.AppearanceHovered.Options.UseTextOptions = true;
            this.btnDaily.AppearanceHovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnDaily.AppearancePressed.Options.UseTextOptions = true;
            this.btnDaily.AppearancePressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnDaily.Location = new System.Drawing.Point(556, 455);
            this.btnDaily.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnDaily.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnDaily.Name = "btnDaily";
            this.btnDaily.Size = new System.Drawing.Size(125, 40);
            this.btnDaily.StyleController = this.layoutControl1;
            this.btnDaily.TabIndex = 10;
            this.btnDaily.Text = "Daily chart";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.emptySpaceItem2,
            this.layoutControlItem5});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(695, 509);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.dtFrom;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem1.Size = new System.Drawing.Size(187, 34);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem1.Text = "From";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(30, 16);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.grdSummary;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 34);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(675, 407);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnReport;
            this.layoutControlItem4.Location = new System.Drawing.Point(276, 441);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem4.Size = new System.Drawing.Size(133, 48);
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnWeekly;
            this.layoutControlItem6.Location = new System.Drawing.Point(409, 441);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem6.Size = new System.Drawing.Size(133, 48);
            this.layoutControlItem6.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.btnDaily;
            this.layoutControlItem7.Location = new System.Drawing.Point(542, 441);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem7.Size = new System.Drawing.Size(133, 48);
            this.layoutControlItem7.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(379, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.emptySpaceItem1.Size = new System.Drawing.Size(296, 34);
            this.emptySpaceItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.dtTo;
            this.layoutControlItem2.Location = new System.Drawing.Point(187, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem2.Size = new System.Drawing.Size(192, 34);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem2.Text = "To";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(30, 16);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 441);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(143, 48);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnRefresh;
            this.layoutControlItem5.Location = new System.Drawing.Point(143, 441);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem5.Size = new System.Drawing.Size(133, 48);
            this.layoutControlItem5.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // frm_M_DW_SummaryInOutByDate
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 560);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_M_DW_SummaryInOutByDate.IconOptions.Icon")));
            this.Name = "frm_M_DW_SummaryInOutByDate";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "Daily Handling";
            this.Load += new System.EventHandler(this.frm_M_DW_SummaryInOutByDate_Load);
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_btn_OpenDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl grdSummary;
        private Common.Controls.WMSGridView grvSummary;
        private DevExpress.XtraEditors.DateEdit dtFrom;
        private DevExpress.XtraEditors.DateEdit dtTo;
        private DevExpress.XtraEditors.SimpleButton btnReport;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.SimpleButton btnWeekly;
        private DevExpress.XtraEditors.SimpleButton btnDaily;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.Columns.GridColumn grcReportDate;
        private DevExpress.XtraGrid.Columns.GridColumn grcIn;
        private DevExpress.XtraGrid.Columns.GridColumn grcOut;
        private DevExpress.XtraGrid.Columns.GridColumn grcTotal;
        private DevExpress.XtraGrid.Columns.GridColumn grcOpenDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rpi_btn_OpenDate;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
    }
}