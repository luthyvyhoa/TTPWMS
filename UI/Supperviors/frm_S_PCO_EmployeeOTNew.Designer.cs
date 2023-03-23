using Common.Controls;
using System.Windows.Forms;
namespace UI.Supperviors
{
    partial class frm_S_PCO_EmployeeOTNew
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_S_PCO_EmployeeOTNew));
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression1 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression2 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule3 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression3 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControl3 = new DevExpress.XtraLayout.LayoutControl();
            this.grcEmployeePerformanceOne = new DevExpress.XtraGrid.GridControl();
            this.grvEmployeePerformanceOne = new Common.Controls.WMSGridView();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpe_hle_OrderID = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn31 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdJobDetails = new DevExpress.XtraGrid.GridControl();
            this.grvJobDetails = new Common.Controls.WMSGridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem17 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem30 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.txtWorkingYear = new DevExpress.XtraEditors.TextEdit();
            this.txtLeaveDay = new DevExpress.XtraEditors.TextEdit();
            this.btnNextDay = new DevExpress.XtraEditors.SimpleButton();
            this.btnPreviousDay = new DevExpress.XtraEditors.SimpleButton();
            this.lblTo = new DevExpress.XtraEditors.LabelControl();
            this.lkeCheck = new DevExpress.XtraEditors.LookUpEdit();
            this.txtHours = new DevExpress.XtraEditors.TextEdit();
            this.txtOTThisMonth = new DevExpress.XtraEditors.TextEdit();
            this.txtOTThisYear = new DevExpress.XtraEditors.TextEdit();
            this.txtRemainLeave = new DevExpress.XtraEditors.TextEdit();
            this.txtRemark = new DevExpress.XtraEditors.TextEdit();
            this.dtToDate = new DevExpress.XtraEditors.DateEdit();
            this.chkManyDate = new DevExpress.XtraEditors.CheckEdit();
            this.dtDate = new DevExpress.XtraEditors.DateEdit();
            this.lkeEmployeeName = new DevExpress.XtraEditors.LookUpEdit();
            this.txtEmployeeID = new DevExpress.XtraEditors.TextEdit();
            this.dTimeIn = new DevExpress.XtraEditors.DateEdit();
            this.dTimeOut = new DevExpress.XtraEditors.DateEdit();
            this.txtLeaveDay1 = new DevExpress.XtraEditors.TextEdit();
            this.txtWorkingYear1 = new DevExpress.XtraEditors.TextEdit();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem16 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem21 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem22 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem25 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem26 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem27 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem28 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem29 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem19 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem20 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem23 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem24 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblEmployeeName = new DevExpress.XtraEditors.LabelControl();
            this.lblJobDetails = new DevExpress.XtraEditors.LabelControl();
            this.lblEmployeeID = new DevExpress.XtraEditors.LabelControl();
            this.layoutControlItem18 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl3)).BeginInit();
            this.layoutControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcEmployeePerformanceOne)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEmployeePerformanceOne)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpe_hle_OrderID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdJobDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvJobDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkingYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLeaveDay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeCheck.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHours.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOTThisMonth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOTThisYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemainLeave.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkManyDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeEmployeeName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmployeeID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTimeIn.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTimeIn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTimeOut.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTimeOut.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLeaveDay1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkingYear1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            this.SuspendLayout();
            // 
            // rbcbase
            // 
            this.rbcbase.ExpandCollapseItem.Id = 0;
            this.rbcbase.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbcbase.OptionsCustomizationForm.FormIcon = ((System.Drawing.Icon)(resources.GetObject("resource.FormIcon")));
            // 
            // 
            // 
            this.rbcbase.SearchEditItem.AccessibleName = "Search Item";
            this.rbcbase.SearchEditItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.rbcbase.SearchEditItem.EditWidth = 150;
            this.rbcbase.SearchEditItem.Id = -5000;
            this.rbcbase.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.rbcbase.Size = new System.Drawing.Size(1791, 51);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.layoutControl3);
            this.layoutControl1.Controls.Add(this.layoutControl2);
            this.layoutControl1.Controls.Add(this.lblEmployeeName);
            this.layoutControl1.Controls.Add(this.lblJobDetails);
            this.layoutControl1.Controls.Add(this.lblEmployeeID);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem18});
            this.layoutControl1.Location = new System.Drawing.Point(0, 51);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(509, 142, 450, 400);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1791, 675);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // layoutControl3
            // 
            this.layoutControl3.Controls.Add(this.grcEmployeePerformanceOne);
            this.layoutControl3.Controls.Add(this.grdJobDetails);
            this.layoutControl3.Location = new System.Drawing.Point(411, 30);
            this.layoutControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl3.Name = "layoutControl3";
            this.layoutControl3.Root = this.layoutControlGroup2;
            this.layoutControl3.Size = new System.Drawing.Size(1373, 638);
            this.layoutControl3.TabIndex = 10;
            this.layoutControl3.Text = "layoutControl3";
            // 
            // grcEmployeePerformanceOne
            // 
            this.grcEmployeePerformanceOne.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grcEmployeePerformanceOne.Location = new System.Drawing.Point(538, 4);
            this.grcEmployeePerformanceOne.MainView = this.grvEmployeePerformanceOne;
            this.grcEmployeePerformanceOne.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grcEmployeePerformanceOne.Name = "grcEmployeePerformanceOne";
            this.grcEmployeePerformanceOne.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpe_hle_OrderID});
            this.grcEmployeePerformanceOne.Size = new System.Drawing.Size(831, 630);
            this.grcEmployeePerformanceOne.TabIndex = 16;
            this.grcEmployeePerformanceOne.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvEmployeePerformanceOne});
            // 
            // grvEmployeePerformanceOne
            // 
            this.grvEmployeePerformanceOne.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grvEmployeePerformanceOne.Appearance.FooterPanel.Options.UseFont = true;
            this.grvEmployeePerformanceOne.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn21,
            this.gridColumn22,
            this.gridColumn31});
            gridFormatRule1.Name = "Format0";
            formatConditionRuleExpression1.Expression = "GetHour([StartTime]) = 17 And GetMinute([StartTime]) > 30 Or GetHour([StartTime])" +
    " > 17";
            formatConditionRuleExpression1.PredefinedName = "Red Bold Text";
            gridFormatRule1.Rule = formatConditionRuleExpression1;
            gridFormatRule2.Name = "Format1";
            formatConditionRuleExpression2.Expression = "GetDayOfWeek([OrderDate]) = 0";
            formatConditionRuleExpression2.PredefinedName = "Red Fill";
            gridFormatRule2.Rule = formatConditionRuleExpression2;
            gridFormatRule3.Name = "Format2";
            formatConditionRuleExpression3.Expression = "GetHour([EndTime]) > 18 OR GetHour([EndTime])<6";
            formatConditionRuleExpression3.PredefinedName = "Red Bold Text";
            gridFormatRule3.Rule = formatConditionRuleExpression3;
            this.grvEmployeePerformanceOne.FormatRules.Add(gridFormatRule1);
            this.grvEmployeePerformanceOne.FormatRules.Add(gridFormatRule2);
            this.grvEmployeePerformanceOne.FormatRules.Add(gridFormatRule3);
            this.grvEmployeePerformanceOne.GridControl = this.grcEmployeePerformanceOne;
            this.grvEmployeePerformanceOne.Name = "grvEmployeePerformanceOne";
            this.grvEmployeePerformanceOne.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grvEmployeePerformanceOne.OptionsSelection.MultiSelect = true;
            this.grvEmployeePerformanceOne.OptionsView.ShowFooter = true;
            this.grvEmployeePerformanceOne.OptionsView.ShowGroupPanel = false;
            this.grvEmployeePerformanceOne.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvEmployeePerformanceOne.PaintStyleName = "Skin";
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Scan Time";
            this.gridColumn5.DisplayFormat.FormatString = "G";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn5.FieldName = "CreatedTime";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "CreatedTime", "{0}")});
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            this.gridColumn5.Width = 170;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Order No";
            this.gridColumn6.ColumnEdit = this.rpe_hle_OrderID;
            this.gridColumn6.FieldName = "OrderNumber";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 1;
            this.gridColumn6.Width = 89;
            // 
            // rpe_hle_OrderID
            // 
            this.rpe_hle_OrderID.AutoHeight = false;
            this.rpe_hle_OrderID.Name = "rpe_hle_OrderID";
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn7.Caption = "Type";
            this.gridColumn7.FieldName = "OrderType";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 2;
            this.gridColumn7.Width = 48;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Scan Data";
            this.gridColumn8.FieldName = "BarcodeDataScanned";
            this.gridColumn8.MinWidth = 25;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 3;
            this.gridColumn8.Width = 160;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Remark";
            this.gridColumn9.FieldName = "Remark";
            this.gridColumn9.MinWidth = 25;
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 4;
            this.gridColumn9.Width = 107;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Start Time";
            this.gridColumn10.FieldName = "StartTime";
            this.gridColumn10.MinWidth = 25;
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Width = 64;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "End Time";
            this.gridColumn11.DisplayFormat.FormatString = "G";
            this.gridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn11.FieldName = "EndTime";
            this.gridColumn11.MinWidth = 25;
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 5;
            this.gridColumn11.Width = 179;
            // 
            // gridColumn21
            // 
            this.gridColumn21.Caption = "EquipmentID";
            this.gridColumn21.FieldName = "EquipmentID";
            this.gridColumn21.MinWidth = 25;
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.Width = 125;
            // 
            // gridColumn22
            // 
            this.gridColumn22.Caption = "DeviceNumber";
            this.gridColumn22.FieldName = "DeviceNumber";
            this.gridColumn22.MinWidth = 25;
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.Width = 125;
            // 
            // gridColumn31
            // 
            this.gridColumn31.Caption = "Work Time";
            this.gridColumn31.FieldName = "DurationByMinute";
            this.gridColumn31.MinWidth = 27;
            this.gridColumn31.Name = "gridColumn31";
            this.gridColumn31.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DurationByMinute", "{0:0.##}")});
            this.gridColumn31.Visible = true;
            this.gridColumn31.VisibleIndex = 6;
            this.gridColumn31.Width = 74;
            // 
            // grdJobDetails
            // 
            this.grdJobDetails.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.grdJobDetails.Location = new System.Drawing.Point(4, 4);
            this.grdJobDetails.MainView = this.grvJobDetails;
            this.grdJobDetails.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdJobDetails.MenuManager = this.rbcbase;
            this.grdJobDetails.Name = "grdJobDetails";
            this.grdJobDetails.Size = new System.Drawing.Size(530, 630);
            this.grdJobDetails.TabIndex = 4;
            this.grdJobDetails.TabStop = false;
            this.grdJobDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvJobDetails});
            // 
            // grvJobDetails
            // 
            this.grvJobDetails.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
            this.grvJobDetails.GridControl = this.grdJobDetails;
            this.grvJobDetails.Name = "grvJobDetails";
            this.grvJobDetails.OptionsView.ShowFooter = true;
            this.grvJobDetails.OptionsView.ShowGroupPanel = false;
            this.grvJobDetails.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvJobDetails.PaintStyleName = "Skin";
            // 
            // gridColumn1
            // 
            this.gridColumn1.FieldName = "OrderNumber";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 108;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Kgs";
            this.gridColumn2.DisplayFormat.FormatString = "{0:0.#}";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn2.FieldName = "TotalWeight";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalWeight", "{0:0.#}")});
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 97;
            // 
            // gridColumn3
            // 
            this.gridColumn3.DisplayFormat.FormatString = "{0:dd/MM/yyy HH:mm}";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn3.FieldName = "StartTime";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 146;
            // 
            // gridColumn4
            // 
            this.gridColumn4.DisplayFormat.FormatString = "{0:dd/MM/yyy HH:mm}";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn4.FieldName = "EndTime";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 158;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem17,
            this.layoutControlItem30});
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlGroup2.Size = new System.Drawing.Size(1373, 638);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem17
            // 
            this.layoutControlItem17.Control = this.grdJobDetails;
            this.layoutControlItem17.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem17.Name = "layoutControlItem17";
            this.layoutControlItem17.Size = new System.Drawing.Size(534, 634);
            this.layoutControlItem17.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem17.TextVisible = false;
            // 
            // layoutControlItem30
            // 
            this.layoutControlItem30.Control = this.grcEmployeePerformanceOne;
            this.layoutControlItem30.Location = new System.Drawing.Point(534, 0);
            this.layoutControlItem30.Name = "layoutControlItem30";
            this.layoutControlItem30.Size = new System.Drawing.Size(835, 634);
            this.layoutControlItem30.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem30.TextVisible = false;
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.txtWorkingYear);
            this.layoutControl2.Controls.Add(this.txtLeaveDay);
            this.layoutControl2.Controls.Add(this.btnNextDay);
            this.layoutControl2.Controls.Add(this.btnPreviousDay);
            this.layoutControl2.Controls.Add(this.lblTo);
            this.layoutControl2.Controls.Add(this.lkeCheck);
            this.layoutControl2.Controls.Add(this.txtHours);
            this.layoutControl2.Controls.Add(this.txtOTThisMonth);
            this.layoutControl2.Controls.Add(this.txtOTThisYear);
            this.layoutControl2.Controls.Add(this.txtRemainLeave);
            this.layoutControl2.Controls.Add(this.txtRemark);
            this.layoutControl2.Controls.Add(this.dtToDate);
            this.layoutControl2.Controls.Add(this.chkManyDate);
            this.layoutControl2.Controls.Add(this.dtDate);
            this.layoutControl2.Controls.Add(this.lkeEmployeeName);
            this.layoutControl2.Controls.Add(this.txtEmployeeID);
            this.layoutControl2.Controls.Add(this.dTimeIn);
            this.layoutControl2.Controls.Add(this.dTimeOut);
            this.layoutControl2.Controls.Add(this.txtLeaveDay1);
            this.layoutControl2.Controls.Add(this.txtWorkingYear1);
            this.layoutControl2.Controls.Add(this.btnCancel);
            this.layoutControl2.Controls.Add(this.btnOK);
            this.layoutControl2.Location = new System.Drawing.Point(7, 30);
            this.layoutControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(886, 237, 562, 500);
            this.layoutControl2.Root = this.Root;
            this.layoutControl2.Size = new System.Drawing.Size(400, 638);
            this.layoutControl2.TabIndex = 9;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // txtWorkingYear
            // 
            this.txtWorkingYear.Location = new System.Drawing.Point(155, 578);
            this.txtWorkingYear.MenuManager = this.rbcbase;
            this.txtWorkingYear.MinimumSize = new System.Drawing.Size(0, 24);
            this.txtWorkingYear.Name = "txtWorkingYear";
            this.txtWorkingYear.Size = new System.Drawing.Size(241, 26);
            this.txtWorkingYear.StyleController = this.layoutControl2;
            this.txtWorkingYear.TabIndex = 37;
            // 
            // txtLeaveDay
            // 
            this.txtLeaveDay.Location = new System.Drawing.Point(155, 608);
            this.txtLeaveDay.MenuManager = this.rbcbase;
            this.txtLeaveDay.MinimumSize = new System.Drawing.Size(0, 24);
            this.txtLeaveDay.Name = "txtLeaveDay";
            this.txtLeaveDay.Size = new System.Drawing.Size(241, 26);
            this.txtLeaveDay.StyleController = this.layoutControl2;
            this.txtLeaveDay.TabIndex = 36;
            // 
            // btnNextDay
            // 
            this.btnNextDay.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Question;
            this.btnNextDay.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnNextDay.Appearance.Options.UseBackColor = true;
            this.btnNextDay.Appearance.Options.UseFont = true;
            this.btnNextDay.Location = new System.Drawing.Point(354, 40);
            this.btnNextDay.MaximumSize = new System.Drawing.Size(0, 22);
            this.btnNextDay.Name = "btnNextDay";
            this.btnNextDay.Size = new System.Drawing.Size(40, 22);
            this.btnNextDay.StyleController = this.layoutControl2;
            this.btnNextDay.TabIndex = 35;
            this.btnNextDay.TabStop = false;
            this.btnNextDay.Text = ">>";
            this.btnNextDay.Click += new System.EventHandler(this.btnNextDay_Click);
            // 
            // btnPreviousDay
            // 
            this.btnPreviousDay.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Question;
            this.btnPreviousDay.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnPreviousDay.Appearance.Options.UseBackColor = true;
            this.btnPreviousDay.Appearance.Options.UseFont = true;
            this.btnPreviousDay.Location = new System.Drawing.Point(308, 40);
            this.btnPreviousDay.MaximumSize = new System.Drawing.Size(0, 22);
            this.btnPreviousDay.Name = "btnPreviousDay";
            this.btnPreviousDay.Size = new System.Drawing.Size(38, 22);
            this.btnPreviousDay.StyleController = this.layoutControl2;
            this.btnPreviousDay.TabIndex = 34;
            this.btnPreviousDay.TabStop = false;
            this.btnPreviousDay.Text = "<<";
            this.btnPreviousDay.Click += new System.EventHandler(this.btnPreviousDay_Click);
            // 
            // lblTo
            // 
            this.lblTo.Location = new System.Drawing.Point(253, 75);
            this.lblTo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblTo.MaximumSize = new System.Drawing.Size(25, 17);
            this.lblTo.MinimumSize = new System.Drawing.Size(25, 17);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(25, 17);
            this.lblTo.StyleController = this.layoutControl2;
            this.lblTo.TabIndex = 33;
            this.lblTo.Text = "To:";
            // 
            // lkeCheck
            // 
            this.lkeCheck.Location = new System.Drawing.Point(276, 176);
            this.lkeCheck.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lkeCheck.MenuManager = this.rbcbase;
            this.lkeCheck.MinimumSize = new System.Drawing.Size(0, 24);
            this.lkeCheck.Name = "lkeCheck";
            this.lkeCheck.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeCheck.Properties.NullText = "";
            this.lkeCheck.Size = new System.Drawing.Size(118, 26);
            this.lkeCheck.StyleController = this.layoutControl2;
            this.lkeCheck.TabIndex = 4;
            this.lkeCheck.EditValueChanged += new System.EventHandler(this.lkeCheck_EditValueChanged);
            this.lkeCheck.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lkeCheck_KeyPress);
            // 
            // txtHours
            // 
            this.txtHours.Location = new System.Drawing.Point(157, 176);
            this.txtHours.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtHours.MenuManager = this.rbcbase;
            this.txtHours.MinimumSize = new System.Drawing.Size(0, 24);
            this.txtHours.Name = "txtHours";
            this.txtHours.Size = new System.Drawing.Size(111, 26);
            this.txtHours.StyleController = this.layoutControl2;
            this.txtHours.TabIndex = 3;
            this.txtHours.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHours_KeyPress);
            // 
            // txtOTThisMonth
            // 
            this.txtOTThisMonth.Location = new System.Drawing.Point(157, 336);
            this.txtOTThisMonth.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtOTThisMonth.MenuManager = this.rbcbase;
            this.txtOTThisMonth.MinimumSize = new System.Drawing.Size(0, 24);
            this.txtOTThisMonth.Name = "txtOTThisMonth";
            this.txtOTThisMonth.Size = new System.Drawing.Size(237, 26);
            this.txtOTThisMonth.StyleController = this.layoutControl2;
            this.txtOTThisMonth.TabIndex = 14;
            this.txtOTThisMonth.TabStop = false;
            // 
            // txtOTThisYear
            // 
            this.txtOTThisYear.Location = new System.Drawing.Point(157, 302);
            this.txtOTThisYear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtOTThisYear.MenuManager = this.rbcbase;
            this.txtOTThisYear.MinimumSize = new System.Drawing.Size(0, 24);
            this.txtOTThisYear.Name = "txtOTThisYear";
            this.txtOTThisYear.Size = new System.Drawing.Size(237, 26);
            this.txtOTThisYear.StyleController = this.layoutControl2;
            this.txtOTThisYear.TabIndex = 13;
            this.txtOTThisYear.TabStop = false;
            // 
            // txtRemainLeave
            // 
            this.txtRemainLeave.Location = new System.Drawing.Point(157, 268);
            this.txtRemainLeave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRemainLeave.MenuManager = this.rbcbase;
            this.txtRemainLeave.MinimumSize = new System.Drawing.Size(0, 24);
            this.txtRemainLeave.Name = "txtRemainLeave";
            this.txtRemainLeave.Size = new System.Drawing.Size(237, 26);
            this.txtRemainLeave.StyleController = this.layoutControl2;
            this.txtRemainLeave.TabIndex = 12;
            this.txtRemainLeave.TabStop = false;
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(157, 210);
            this.txtRemark.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRemark.MaximumSize = new System.Drawing.Size(0, 50);
            this.txtRemark.MenuManager = this.rbcbase;
            this.txtRemark.MinimumSize = new System.Drawing.Size(0, 50);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(237, 50);
            this.txtRemark.StyleController = this.layoutControl2;
            this.txtRemark.TabIndex = 5;
            this.txtRemark.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRemark_KeyPress);
            // 
            // dtToDate
            // 
            this.dtToDate.EditValue = null;
            this.dtToDate.Enabled = false;
            this.dtToDate.Location = new System.Drawing.Point(286, 75);
            this.dtToDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtToDate.MenuManager = this.rbcbase;
            this.dtToDate.MinimumSize = new System.Drawing.Size(0, 24);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtToDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtToDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtToDate.Properties.ReadOnly = true;
            this.dtToDate.Size = new System.Drawing.Size(108, 26);
            this.dtToDate.StyleController = this.layoutControl2;
            this.dtToDate.TabIndex = 8;
            this.dtToDate.TabStop = false;
            // 
            // chkManyDate
            // 
            this.chkManyDate.Location = new System.Drawing.Point(157, 75);
            this.chkManyDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkManyDate.MenuManager = this.rbcbase;
            this.chkManyDate.Name = "chkManyDate";
            this.chkManyDate.Properties.Caption = "";
            this.chkManyDate.Size = new System.Drawing.Size(88, 24);
            this.chkManyDate.StyleController = this.layoutControl2;
            this.chkManyDate.TabIndex = 7;
            this.chkManyDate.TabStop = false;
            this.chkManyDate.CheckedChanged += new System.EventHandler(this.chkManyDate_CheckedChanged);
            // 
            // dtDate
            // 
            this.dtDate.EditValue = null;
            this.dtDate.Location = new System.Drawing.Point(157, 40);
            this.dtDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtDate.MenuManager = this.rbcbase;
            this.dtDate.MinimumSize = new System.Drawing.Size(0, 24);
            this.dtDate.Name = "dtDate";
            this.dtDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtDate.Size = new System.Drawing.Size(143, 26);
            this.dtDate.StyleController = this.layoutControl2;
            this.dtDate.TabIndex = 2;
            this.dtDate.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(this.dtDate_CloseUp);
            this.dtDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtDate_KeyDown);
            this.dtDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtDate_KeyPress);
            // 
            // lkeEmployeeName
            // 
            this.lkeEmployeeName.Location = new System.Drawing.Point(128, 6);
            this.lkeEmployeeName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lkeEmployeeName.MinimumSize = new System.Drawing.Size(0, 24);
            this.lkeEmployeeName.Name = "lkeEmployeeName";
            this.lkeEmployeeName.Properties.AutoHeight = false;
            this.lkeEmployeeName.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkeEmployeeName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeEmployeeName.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("VietnamName", "Vietnam Name", 300, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lkeEmployeeName.Properties.DisplayMember = "VietnamName";
            this.lkeEmployeeName.Properties.DropDownRows = 20;
            this.lkeEmployeeName.Properties.ImmediatePopup = true;
            this.lkeEmployeeName.Properties.NullText = "";
            this.lkeEmployeeName.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.StartsWith;
            this.lkeEmployeeName.Properties.ShowFooter = false;
            this.lkeEmployeeName.Properties.ShowHeader = false;
            this.lkeEmployeeName.Properties.ValueMember = "EmployeeID";
            this.lkeEmployeeName.Size = new System.Drawing.Size(266, 26);
            this.lkeEmployeeName.StyleController = this.layoutControl2;
            this.lkeEmployeeName.TabIndex = 30;
            this.lkeEmployeeName.TabStop = false;
            this.lkeEmployeeName.EditValueChanged += new System.EventHandler(this.lkeEmployeeName_EditValueChanged);
            // 
            // txtEmployeeID
            // 
            this.txtEmployeeID.EditValue = "0";
            this.txtEmployeeID.Location = new System.Drawing.Point(6, 6);
            this.txtEmployeeID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEmployeeID.MenuManager = this.rbcbase;
            this.txtEmployeeID.MinimumSize = new System.Drawing.Size(0, 24);
            this.txtEmployeeID.Name = "txtEmployeeID";
            this.txtEmployeeID.Properties.Appearance.Options.UseTextOptions = true;
            this.txtEmployeeID.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtEmployeeID.Size = new System.Drawing.Size(114, 26);
            this.txtEmployeeID.StyleController = this.layoutControl2;
            this.txtEmployeeID.TabIndex = 1;
            this.txtEmployeeID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmployeeID_KeyDown);
            // 
            // dTimeIn
            // 
            this.dTimeIn.EditValue = null;
            this.dTimeIn.Location = new System.Drawing.Point(157, 108);
            this.dTimeIn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dTimeIn.MenuManager = this.rbcbase;
            this.dTimeIn.MinimumSize = new System.Drawing.Size(0, 24);
            this.dTimeIn.Name = "dTimeIn";
            this.dTimeIn.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dTimeIn.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dTimeIn.Properties.DisplayFormat.FormatString = "";
            this.dTimeIn.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dTimeIn.Properties.EditFormat.FormatString = "";
            this.dTimeIn.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dTimeIn.Properties.Mask.EditMask = "";
            this.dTimeIn.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.dTimeIn.Properties.ReadOnly = true;
            this.dTimeIn.Size = new System.Drawing.Size(237, 26);
            this.dTimeIn.StyleController = this.layoutControl2;
            this.dTimeIn.TabIndex = 9;
            this.dTimeIn.TabStop = false;
            // 
            // dTimeOut
            // 
            this.dTimeOut.EditValue = null;
            this.dTimeOut.Location = new System.Drawing.Point(157, 142);
            this.dTimeOut.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dTimeOut.MenuManager = this.rbcbase;
            this.dTimeOut.MinimumSize = new System.Drawing.Size(0, 24);
            this.dTimeOut.Name = "dTimeOut";
            this.dTimeOut.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dTimeOut.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dTimeOut.Properties.DisplayFormat.FormatString = "";
            this.dTimeOut.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dTimeOut.Properties.EditFormat.FormatString = "";
            this.dTimeOut.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dTimeOut.Properties.Mask.EditMask = "c";
            this.dTimeOut.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.dTimeOut.Properties.ReadOnly = true;
            this.dTimeOut.Size = new System.Drawing.Size(237, 26);
            this.dTimeOut.StyleController = this.layoutControl2;
            this.dTimeOut.TabIndex = 10;
            this.dTimeOut.TabStop = false;
            // 
            // txtLeaveDay1
            // 
            this.txtLeaveDay1.Location = new System.Drawing.Point(157, 370);
            this.txtLeaveDay1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLeaveDay1.MinimumSize = new System.Drawing.Size(0, 24);
            this.txtLeaveDay1.Name = "txtLeaveDay1";
            this.txtLeaveDay1.Size = new System.Drawing.Size(237, 26);
            this.txtLeaveDay1.StyleController = this.layoutControl2;
            this.txtLeaveDay1.TabIndex = 14;
            this.txtLeaveDay1.TabStop = false;
            // 
            // txtWorkingYear1
            // 
            this.txtWorkingYear1.Location = new System.Drawing.Point(157, 404);
            this.txtWorkingYear1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtWorkingYear1.MinimumSize = new System.Drawing.Size(0, 24);
            this.txtWorkingYear1.Name = "txtWorkingYear1";
            this.txtWorkingYear1.Size = new System.Drawing.Size(237, 26);
            this.txtWorkingYear1.StyleController = this.layoutControl2;
            this.txtWorkingYear1.TabIndex = 14;
            this.txtWorkingYear1.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Appearance.Options.UseBackColor = true;
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new System.Drawing.Point(139, 438);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnCancel.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(125, 40);
            this.btnCancel.StyleController = this.layoutControl2;
            this.btnCancel.TabIndex = 12;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning;
            this.btnOK.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnOK.Appearance.Options.UseBackColor = true;
            this.btnOK.Appearance.Options.UseFont = true;
            this.btnOK.Location = new System.Drawing.Point(6, 438);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOK.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnOK.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(125, 40);
            this.btnOK.StyleController = this.layoutControl2;
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "Confirm";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem8,
            this.layoutControlItem9,
            this.layoutControlItem10,
            this.layoutControlItem11,
            this.layoutControlItem12,
            this.layoutControlItem13,
            this.layoutControlItem14,
            this.layoutControlItem15,
            this.layoutControlItem16,
            this.layoutControlItem21,
            this.layoutControlItem22,
            this.layoutControlItem25,
            this.layoutControlItem26,
            this.layoutControlItem27,
            this.layoutControlItem28,
            this.layoutControlItem29,
            this.layoutControlItem19,
            this.layoutControlItem20,
            this.emptySpaceItem2,
            this.layoutControlItem23,
            this.layoutControlItem24});
            this.Root.Name = "Root";
            this.Root.OptionsItemText.TextToControlDistance = 5;
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.Root.Size = new System.Drawing.Size(400, 638);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtEmployeeID;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(122, 34);
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.lkeEmployeeName;
            this.layoutControlItem5.Location = new System.Drawing.Point(122, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(274, 34);
            this.layoutControlItem5.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.dtDate;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 34);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(302, 35);
            this.layoutControlItem8.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem8.Text = "Date/ Ngày: ";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(146, 16);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.chkManyDate;
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 69);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(247, 33);
            this.layoutControlItem9.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem9.Text = "Many Date/Nhiều Ngày:";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(146, 17);
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.AppearanceItemCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.layoutControlItem10.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem10.Control = this.dtToDate;
            this.layoutControlItem10.Location = new System.Drawing.Point(280, 69);
            this.layoutControlItem10.MaxSize = new System.Drawing.Size(116, 33);
            this.layoutControlItem10.MinSize = new System.Drawing.Size(116, 33);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(116, 33);
            this.layoutControlItem10.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem10.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem10.Text = "Đến:";
            this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem10.TextVisible = false;
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.dTimeIn;
            this.layoutControlItem11.Location = new System.Drawing.Point(0, 102);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(396, 34);
            this.layoutControlItem11.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem11.Text = "Time In/Giờ Vào:";
            this.layoutControlItem11.TextSize = new System.Drawing.Size(146, 17);
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.AppearanceItemCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.layoutControlItem12.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem12.Control = this.dTimeOut;
            this.layoutControlItem12.Location = new System.Drawing.Point(0, 136);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(396, 34);
            this.layoutControlItem12.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem12.Text = "Time Out/Giờ Ra:";
            this.layoutControlItem12.TextSize = new System.Drawing.Size(146, 17);
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.Control = this.txtRemark;
            this.layoutControlItem13.Location = new System.Drawing.Point(0, 204);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new System.Drawing.Size(396, 58);
            this.layoutControlItem13.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem13.Text = "Remark/Ghi chú:";
            this.layoutControlItem13.TextSize = new System.Drawing.Size(146, 16);
            // 
            // layoutControlItem14
            // 
            this.layoutControlItem14.Control = this.txtRemainLeave;
            this.layoutControlItem14.Location = new System.Drawing.Point(0, 262);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Size = new System.Drawing.Size(396, 34);
            this.layoutControlItem14.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem14.Text = "Remain Leave/Phép Còn:";
            this.layoutControlItem14.TextSize = new System.Drawing.Size(146, 16);
            // 
            // layoutControlItem15
            // 
            this.layoutControlItem15.Control = this.txtOTThisYear;
            this.layoutControlItem15.Location = new System.Drawing.Point(0, 296);
            this.layoutControlItem15.Name = "layoutControlItem15";
            this.layoutControlItem15.Size = new System.Drawing.Size(396, 34);
            this.layoutControlItem15.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem15.Text = "Total  OT This Year:";
            this.layoutControlItem15.TextSize = new System.Drawing.Size(146, 16);
            // 
            // layoutControlItem16
            // 
            this.layoutControlItem16.Control = this.txtOTThisMonth;
            this.layoutControlItem16.Location = new System.Drawing.Point(0, 330);
            this.layoutControlItem16.Name = "layoutControlItem16";
            this.layoutControlItem16.Size = new System.Drawing.Size(396, 34);
            this.layoutControlItem16.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem16.Text = "Total  OT This Month:";
            this.layoutControlItem16.TextSize = new System.Drawing.Size(146, 16);
            // 
            // layoutControlItem21
            // 
            this.layoutControlItem21.Control = this.txtHours;
            this.layoutControlItem21.Location = new System.Drawing.Point(0, 170);
            this.layoutControlItem21.Name = "layoutControlItem21";
            this.layoutControlItem21.Size = new System.Drawing.Size(270, 34);
            this.layoutControlItem21.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem21.Text = "Hours Qty/Số Giờ:";
            this.layoutControlItem21.TextSize = new System.Drawing.Size(146, 17);
            // 
            // layoutControlItem22
            // 
            this.layoutControlItem22.Control = this.lkeCheck;
            this.layoutControlItem22.Location = new System.Drawing.Point(270, 170);
            this.layoutControlItem22.Name = "layoutControlItem22";
            this.layoutControlItem22.Size = new System.Drawing.Size(126, 34);
            this.layoutControlItem22.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem22.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem22.TextVisible = false;
            // 
            // layoutControlItem25
            // 
            this.layoutControlItem25.Control = this.lblTo;
            this.layoutControlItem25.Location = new System.Drawing.Point(247, 69);
            this.layoutControlItem25.Name = "layoutControlItem25";
            this.layoutControlItem25.Size = new System.Drawing.Size(33, 33);
            this.layoutControlItem25.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem25.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem25.TextVisible = false;
            // 
            // layoutControlItem26
            // 
            this.layoutControlItem26.Control = this.btnPreviousDay;
            this.layoutControlItem26.Location = new System.Drawing.Point(302, 34);
            this.layoutControlItem26.Name = "layoutControlItem26";
            this.layoutControlItem26.Size = new System.Drawing.Size(46, 35);
            this.layoutControlItem26.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem26.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem26.TextVisible = false;
            // 
            // layoutControlItem27
            // 
            this.layoutControlItem27.Control = this.btnNextDay;
            this.layoutControlItem27.Location = new System.Drawing.Point(348, 34);
            this.layoutControlItem27.Name = "layoutControlItem27";
            this.layoutControlItem27.Size = new System.Drawing.Size(48, 35);
            this.layoutControlItem27.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem27.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem27.TextVisible = false;
            // 
            // layoutControlItem28
            // 
            this.layoutControlItem28.Control = this.txtLeaveDay1;
            this.layoutControlItem28.CustomizationFormText = "Total  OT This Month:";
            this.layoutControlItem28.Location = new System.Drawing.Point(0, 364);
            this.layoutControlItem28.Name = "layoutControlItem28";
            this.layoutControlItem28.Size = new System.Drawing.Size(396, 34);
            this.layoutControlItem28.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem28.Text = "Total Leave:";
            this.layoutControlItem28.TextSize = new System.Drawing.Size(146, 16);
            // 
            // layoutControlItem29
            // 
            this.layoutControlItem29.Control = this.txtWorkingYear1;
            this.layoutControlItem29.CustomizationFormText = "Total  OT This Month:";
            this.layoutControlItem29.Location = new System.Drawing.Point(0, 398);
            this.layoutControlItem29.Name = "layoutControlItem29";
            this.layoutControlItem29.Size = new System.Drawing.Size(396, 34);
            this.layoutControlItem29.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem29.Text = "Total working year:";
            this.layoutControlItem29.TextSize = new System.Drawing.Size(146, 16);
            // 
            // layoutControlItem19
            // 
            this.layoutControlItem19.Control = this.btnCancel;
            this.layoutControlItem19.Location = new System.Drawing.Point(133, 432);
            this.layoutControlItem19.Name = "layoutControlItem19";
            this.layoutControlItem19.Size = new System.Drawing.Size(263, 48);
            this.layoutControlItem19.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem19.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem19.TextVisible = false;
            // 
            // layoutControlItem20
            // 
            this.layoutControlItem20.Control = this.btnOK;
            this.layoutControlItem20.Location = new System.Drawing.Point(0, 432);
            this.layoutControlItem20.Name = "layoutControlItem20";
            this.layoutControlItem20.Size = new System.Drawing.Size(133, 48);
            this.layoutControlItem20.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem20.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem20.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 480);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(396, 94);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem23
            // 
            this.layoutControlItem23.Control = this.txtLeaveDay;
            this.layoutControlItem23.Location = new System.Drawing.Point(0, 604);
            this.layoutControlItem23.Name = "layoutControlItem23";
            this.layoutControlItem23.Size = new System.Drawing.Size(396, 30);
            this.layoutControlItem23.Text = "Leave Days";
            this.layoutControlItem23.TextSize = new System.Drawing.Size(146, 16);
            this.layoutControlItem23.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutControlItem24
            // 
            this.layoutControlItem24.Control = this.txtWorkingYear;
            this.layoutControlItem24.Location = new System.Drawing.Point(0, 574);
            this.layoutControlItem24.Name = "layoutControlItem24";
            this.layoutControlItem24.Size = new System.Drawing.Size(396, 30);
            this.layoutControlItem24.Text = "Working Year";
            this.layoutControlItem24.TextSize = new System.Drawing.Size(146, 16);
            this.layoutControlItem24.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // lblEmployeeName
            // 
            this.lblEmployeeName.Location = new System.Drawing.Point(139, 7);
            this.lblEmployeeName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblEmployeeName.MaximumSize = new System.Drawing.Size(0, 18);
            this.lblEmployeeName.MinimumSize = new System.Drawing.Size(253, 18);
            this.lblEmployeeName.Name = "lblEmployeeName";
            this.lblEmployeeName.Size = new System.Drawing.Size(274, 18);
            this.lblEmployeeName.StyleController = this.layoutControl1;
            this.lblEmployeeName.TabIndex = 6;
            this.lblEmployeeName.Text = "Employee Name";
            // 
            // lblJobDetails
            // 
            this.lblJobDetails.Location = new System.Drawing.Point(417, 7);
            this.lblJobDetails.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblJobDetails.MaximumSize = new System.Drawing.Size(350, 18);
            this.lblJobDetails.MinimumSize = new System.Drawing.Size(350, 18);
            this.lblJobDetails.Name = "lblJobDetails";
            this.lblJobDetails.Size = new System.Drawing.Size(350, 18);
            this.lblJobDetails.StyleController = this.layoutControl1;
            this.lblJobDetails.TabIndex = 5;
            this.lblJobDetails.Text = "Job Details/ Chi tiết công việc của nhân viên trong ngày";
            // 
            // lblEmployeeID
            // 
            this.lblEmployeeID.Appearance.Options.UseTextOptions = true;
            this.lblEmployeeID.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblEmployeeID.Location = new System.Drawing.Point(7, 7);
            this.lblEmployeeID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblEmployeeID.MaximumSize = new System.Drawing.Size(0, 18);
            this.lblEmployeeID.MinimumSize = new System.Drawing.Size(0, 18);
            this.lblEmployeeID.Name = "lblEmployeeID";
            this.lblEmployeeID.Padding = new System.Windows.Forms.Padding(2);
            this.lblEmployeeID.Size = new System.Drawing.Size(128, 18);
            this.lblEmployeeID.StyleController = this.layoutControl1;
            this.lblEmployeeID.TabIndex = 4;
            this.lblEmployeeID.Text = "Employee ID";
            // 
            // layoutControlItem18
            // 
            this.layoutControlItem18.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem18.Name = "layoutControlItem18";
            this.layoutControlItem18.Size = new System.Drawing.Size(0, 0);
            this.layoutControlItem18.TextSize = new System.Drawing.Size(50, 20);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem6,
            this.layoutControlItem7});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlGroup1.Size = new System.Drawing.Size(1791, 675);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lblEmployeeID;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(132, 23);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(132, 23);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(132, 23);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.lblJobDetails;
            this.layoutControlItem2.Location = new System.Drawing.Point(410, 0);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(277, 23);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(277, 23);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(1371, 23);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.lblEmployeeName;
            this.layoutControlItem3.Location = new System.Drawing.Point(132, 0);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(278, 23);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(278, 23);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(278, 23);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.layoutControl2;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 23);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(404, 642);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.layoutControl3;
            this.layoutControlItem7.Location = new System.Drawing.Point(404, 23);
            this.layoutControlItem7.MinSize = new System.Drawing.Size(11, 11);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(1377, 642);
            this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // frm_S_PCO_EmployeeOTNew
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1791, 726);
            this.Controls.Add(this.layoutControl1);
            this.Enabled = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_S_PCO_EmployeeOTNew.IconOptions.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_S_PCO_EmployeeOTNew";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "Over Times Entry";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_S_PCO_EmployeeOTNew_FormClosing);
            this.Load += new System.EventHandler(this.frm_S_PCO_EmployeeOTNew_Load);
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl3)).EndInit();
            this.layoutControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcEmployeePerformanceOne)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEmployeePerformanceOne)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpe_hle_OrderID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdJobDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvJobDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkingYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLeaveDay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeCheck.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHours.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOTThisMonth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOTThisYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemainLeave.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkManyDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeEmployeeName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmployeeID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTimeIn.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTimeIn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTimeOut.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTimeOut.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLeaveDay1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkingYear1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.LabelControl lblEmployeeName;
        private DevExpress.XtraEditors.LabelControl lblJobDetails;
        private DevExpress.XtraEditors.LabelControl lblEmployeeID;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControl layoutControl3;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.LookUpEdit lkeEmployeeName;
        private DevExpress.XtraEditors.TextEdit txtEmployeeID;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.DateEdit dtDate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraEditors.DateEdit dtToDate;
        private DevExpress.XtraEditors.CheckEdit chkManyDate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraEditors.TextEdit txtOTThisMonth;
        private DevExpress.XtraEditors.TextEdit txtOTThisYear;
        private DevExpress.XtraEditors.TextEdit txtRemainLeave;
        private DevExpress.XtraEditors.TextEdit txtRemark;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem13;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem14;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem15;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem16;
        private DevExpress.XtraGrid.GridControl grdJobDetails;
        private WMSGridView grvJobDetails;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem17;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem18;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem19;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem20;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.LookUpEdit lkeCheck;
        private DevExpress.XtraEditors.TextEdit txtHours;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem21;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem22;
        private DevExpress.XtraEditors.LabelControl lblTo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem25;
        private DevExpress.XtraEditors.SimpleButton btnNextDay;
        private DevExpress.XtraEditors.SimpleButton btnPreviousDay;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem26;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem27;
        private DevExpress.XtraEditors.DateEdit dTimeIn;
        private DevExpress.XtraEditors.DateEdit dTimeOut;
        private DevExpress.XtraEditors.TextEdit txtLeaveDay1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem28;
        private DevExpress.XtraEditors.TextEdit txtWorkingYear1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem29;
        private DevExpress.XtraGrid.GridControl grcEmployeePerformanceOne;
        private WMSGridView grvEmployeePerformanceOne;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpe_hle_OrderID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn31;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem30;
        private DevExpress.XtraEditors.TextEdit txtLeaveDay;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem23;
        private DevExpress.XtraEditors.TextEdit txtWorkingYear;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem24;
    }
}