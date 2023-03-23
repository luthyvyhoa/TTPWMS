namespace UI.ReportForm
{
    partial class frm_WR_OrdersPercentage
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
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression1 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression2 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule3 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression3 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_WR_OrdersPercentage));
            this.gridColumnStartTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnOrderDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnEndTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btn_Refresh = new DevExpress.XtraEditors.SimpleButton();
            this.grdOvertimeOrders = new DevExpress.XtraGrid.GridControl();
            this.grvOvertimeOrdersTableView = new Common.Controls.WMSGridView();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpe_OrderID = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpe_CustomerID = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridColumnOT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCustomerID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.dateEditToDate = new DevExpress.XtraEditors.DateEdit();
            this.dateEditFromDate = new DevExpress.XtraEditors.DateEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOvertimeOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvOvertimeOrdersTableView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpe_OrderID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpe_CustomerID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditToDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFromDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // gridColumnStartTime
            // 
            this.gridColumnStartTime.Caption = "Start Time";
            this.gridColumnStartTime.DisplayFormat.FormatString = "dd/MM/yy HH:mm";
            this.gridColumnStartTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumnStartTime.FieldName = "StartTime";
            this.gridColumnStartTime.GroupFormat.FormatString = "dd/MM/yy HH:mm";
            this.gridColumnStartTime.GroupFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumnStartTime.MinWidth = 22;
            this.gridColumnStartTime.Name = "gridColumnStartTime";
            this.gridColumnStartTime.Visible = true;
            this.gridColumnStartTime.VisibleIndex = 4;
            this.gridColumnStartTime.Width = 197;
            // 
            // gridColumnOrderDate
            // 
            this.gridColumnOrderDate.Caption = "Order Date";
            this.gridColumnOrderDate.FieldName = "OrderDate";
            this.gridColumnOrderDate.MinWidth = 22;
            this.gridColumnOrderDate.Name = "gridColumnOrderDate";
            this.gridColumnOrderDate.Visible = true;
            this.gridColumnOrderDate.VisibleIndex = 2;
            this.gridColumnOrderDate.Width = 129;
            // 
            // gridColumnEndTime
            // 
            this.gridColumnEndTime.Caption = "End Time";
            this.gridColumnEndTime.DisplayFormat.FormatString = "dd/MM/yy HH:mm";
            this.gridColumnEndTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumnEndTime.FieldName = "EndTime";
            this.gridColumnEndTime.GroupFormat.FormatString = "dd/MM/yy HH:mm";
            this.gridColumnEndTime.GroupFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumnEndTime.MinWidth = 22;
            this.gridColumnEndTime.Name = "gridColumnEndTime";
            this.gridColumnEndTime.Visible = true;
            this.gridColumnEndTime.VisibleIndex = 5;
            this.gridColumnEndTime.Width = 193;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btn_Refresh);
            this.layoutControl1.Controls.Add(this.grdOvertimeOrders);
            this.layoutControl1.Controls.Add(this.simpleButton1);
            this.layoutControl1.Controls.Add(this.dateEditToDate);
            this.layoutControl1.Controls.Add(this.dateEditFromDate);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(147, 334, 812, 500);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1924, 951);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Question;
            this.btn_Refresh.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btn_Refresh.Appearance.Options.UseBackColor = true;
            this.btn_Refresh.Appearance.Options.UseFont = true;
            this.btn_Refresh.Location = new System.Drawing.Point(480, 15);
            this.btn_Refresh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Refresh.MaximumSize = new System.Drawing.Size(141, 31);
            this.btn_Refresh.MinimumSize = new System.Drawing.Size(141, 31);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(141, 31);
            this.btn_Refresh.StyleController = this.layoutControl1;
            this.btn_Refresh.TabIndex = 8;
            this.btn_Refresh.Text = "Refresh";
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // grdOvertimeOrders
            // 
            this.grdOvertimeOrders.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdOvertimeOrders.Location = new System.Drawing.Point(12, 53);
            this.grdOvertimeOrders.MainView = this.grvOvertimeOrdersTableView;
            this.grdOvertimeOrders.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdOvertimeOrders.Name = "grdOvertimeOrders";
            this.grdOvertimeOrders.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpe_OrderID,
            this.rpe_CustomerID});
            this.grdOvertimeOrders.Size = new System.Drawing.Size(1900, 885);
            this.grdOvertimeOrders.TabIndex = 7;
            this.grdOvertimeOrders.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvOvertimeOrdersTableView});
            this.grdOvertimeOrders.Click += new System.EventHandler(this.grdOvertimeOrders_Click);
            // 
            // grvOvertimeOrdersTableView
            // 
            this.grvOvertimeOrdersTableView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn9,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumnOT,
            this.gridColumnOrderDate,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumnStartTime,
            this.gridColumnEndTime,
            this.gridColumnCustomerID,
            this.gridColumn7,
            this.gridColumn12,
            this.gridColumn3,
            this.gridColumn6});
            this.grvOvertimeOrdersTableView.DetailHeight = 437;
            gridFormatRule1.Column = this.gridColumnStartTime;
            gridFormatRule1.Name = "Format0";
            formatConditionRuleExpression1.Expression = "GetHour([StartTime]) = 17 And GetMinute([StartTime]) > 30 Or GetHour([StartTime])" +
    " > 17";
            formatConditionRuleExpression1.PredefinedName = "Red Bold Text";
            gridFormatRule1.Rule = formatConditionRuleExpression1;
            gridFormatRule2.Column = this.gridColumnOrderDate;
            gridFormatRule2.ColumnApplyTo = this.gridColumnOrderDate;
            gridFormatRule2.Name = "Format1";
            formatConditionRuleExpression2.Expression = "GetDayOfWeek([OrderDate]) = 0";
            formatConditionRuleExpression2.PredefinedName = "Red Fill";
            gridFormatRule2.Rule = formatConditionRuleExpression2;
            gridFormatRule3.Column = this.gridColumnEndTime;
            gridFormatRule3.ColumnApplyTo = this.gridColumnEndTime;
            gridFormatRule3.Name = "Format2";
            formatConditionRuleExpression3.Expression = "GetHour([EndTime]) > 18 OR GetHour([EndTime])<6";
            formatConditionRuleExpression3.PredefinedName = "Red Bold Text";
            gridFormatRule3.Rule = formatConditionRuleExpression3;
            this.grvOvertimeOrdersTableView.FormatRules.Add(gridFormatRule1);
            this.grvOvertimeOrdersTableView.FormatRules.Add(gridFormatRule2);
            this.grvOvertimeOrdersTableView.FormatRules.Add(gridFormatRule3);
            this.grvOvertimeOrdersTableView.GridControl = this.grdOvertimeOrders;
            this.grvOvertimeOrdersTableView.Name = "grvOvertimeOrdersTableView";
            this.grvOvertimeOrdersTableView.OptionsView.ShowFooter = true;
            this.grvOvertimeOrdersTableView.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvOvertimeOrdersTableView.PaintStyleName = "Skin";
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "ID";
            this.gridColumn9.FieldName = "OrderID";
            this.gridColumn9.MinWidth = 22;
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Width = 84;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Order ID";
            this.gridColumn1.ColumnEdit = this.rpe_OrderID;
            this.gridColumn1.FieldName = "OrderNumber";
            this.gridColumn1.MinWidth = 22;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "OrderNumber", "{0}")});
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 121;
            // 
            // rpe_OrderID
            // 
            this.rpe_OrderID.AutoHeight = false;
            this.rpe_OrderID.Name = "rpe_OrderID";
            this.rpe_OrderID.Click += new System.EventHandler(this.rpe_OrderID_Click);
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Customer";
            this.gridColumn2.ColumnEdit = this.rpe_CustomerID;
            this.gridColumn2.FieldName = "CustomerNumber";
            this.gridColumn2.MinWidth = 22;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 108;
            // 
            // rpe_CustomerID
            // 
            this.rpe_CustomerID.AutoHeight = false;
            this.rpe_CustomerID.Name = "rpe_CustomerID";
            this.rpe_CustomerID.Click += new System.EventHandler(this.rpe_CustomerID_Click);
            // 
            // gridColumnOT
            // 
            this.gridColumnOT.Caption = "OT";
            this.gridColumnOT.FieldName = "QtyOT";
            this.gridColumnOT.MinWidth = 22;
            this.gridColumnOT.Name = "gridColumnOT";
            this.gridColumnOT.Width = 28;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Remark";
            this.gridColumn4.FieldName = "SpecialRequirement";
            this.gridColumn4.MinWidth = 22;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 447;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Internal Note";
            this.gridColumn5.FieldName = "InternalRemark";
            this.gridColumn5.MinWidth = 22;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 9;
            this.gridColumn5.Width = 325;
            // 
            // gridColumnCustomerID
            // 
            this.gridColumnCustomerID.Caption = "CustomerID";
            this.gridColumnCustomerID.FieldName = "CustomerID";
            this.gridColumnCustomerID.MinWidth = 22;
            this.gridColumnCustomerID.Name = "gridColumnCustomerID";
            this.gridColumnCustomerID.Width = 84;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "User";
            this.gridColumn7.FieldName = "OrderOwner";
            this.gridColumn7.MinWidth = 22;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 10;
            this.gridColumn7.Width = 127;
            // 
            // gridColumn12
            // 
            this.gridColumn12.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn12.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn12.Caption = "%";
            this.gridColumn12.FieldName = "PCTG";
            this.gridColumn12.MinWidth = 22;
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 8;
            this.gridColumn12.Width = 87;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn3.Caption = "KGS";
            this.gridColumn3.DisplayFormat.FormatString = "n1";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn3.FieldName = "Kgs";
            this.gridColumn3.MinWidth = 22;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Kgs", "{0:n2}")});
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 6;
            this.gridColumn3.Width = 103;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn6.Caption = "Ctns";
            this.gridColumn6.DisplayFormat.FormatString = "n0";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn6.FieldName = "Ctns";
            this.gridColumn6.MinWidth = 22;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Ctns", "{0:n0}")});
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 7;
            this.gridColumn6.Width = 103;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Question;
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.simpleButton1.Appearance.Options.UseBackColor = true;
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Location = new System.Drawing.Point(1770, 15);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.simpleButton1.MaximumSize = new System.Drawing.Size(141, 31);
            this.simpleButton1.MinimumSize = new System.Drawing.Size(141, 31);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(141, 31);
            this.simpleButton1.StyleController = this.layoutControl1;
            this.simpleButton1.TabIndex = 6;
            this.simpleButton1.Text = "Print Preview";
            // 
            // dateEditToDate
            // 
            this.dateEditToDate.EditValue = null;
            this.dateEditToDate.Location = new System.Drawing.Point(331, 15);
            this.dateEditToDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateEditToDate.MinimumSize = new System.Drawing.Size(0, 30);
            this.dateEditToDate.Name = "dateEditToDate";
            this.dateEditToDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditToDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditToDate.Size = new System.Drawing.Size(143, 32);
            this.dateEditToDate.StyleController = this.layoutControl1;
            this.dateEditToDate.TabIndex = 5;
            // 
            // dateEditFromDate
            // 
            this.dateEditFromDate.EditValue = null;
            this.dateEditFromDate.Location = new System.Drawing.Point(104, 15);
            this.dateEditFromDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateEditFromDate.MinimumSize = new System.Drawing.Size(0, 30);
            this.dateEditFromDate.Name = "dateEditFromDate";
            this.dateEditFromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditFromDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditFromDate.Size = new System.Drawing.Size(130, 32);
            this.dateEditFromDate.StyleController = this.layoutControl1;
            this.dateEditFromDate.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.emptySpaceItem1,
            this.layoutControlItem5});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1924, 951);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.dateEditFromDate;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(227, 40);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem1.Text = "From Date :";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(85, 19);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.dateEditToDate;
            this.layoutControlItem2.Location = new System.Drawing.Point(227, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(240, 40);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem2.Text = "To Date :";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(85, 19);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.simpleButton1;
            this.layoutControlItem3.Location = new System.Drawing.Point(1757, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(147, 40);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.grdOvertimeOrders;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 40);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(1904, 889);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(614, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(1143, 40);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btn_Refresh;
            this.layoutControlItem5.Location = new System.Drawing.Point(467, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(147, 40);
            this.layoutControlItem5.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // frm_WR_OrdersPercentage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 951);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frm_WR_OrdersPercentage";
            this.Text = "Orders Handling Percentage Review";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOvertimeOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvOvertimeOrdersTableView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpe_OrderID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpe_CustomerID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditToDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFromDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl grdOvertimeOrders;
        private Common.Controls.WMSGridView grvOvertimeOrdersTableView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnOrderDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnStartTime;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnEndTime;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.DateEdit dateEditToDate;
        private DevExpress.XtraEditors.DateEdit dateEditFromDate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpe_OrderID;
        private DevExpress.XtraEditors.SimpleButton btn_Refresh;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpe_CustomerID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCustomerID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnOT;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
    }
}