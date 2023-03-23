namespace UI.ReportForm
{
    partial class frm_BR_Dialog_BillingDateOrders
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_BR_Dialog_BillingDateOrders));
            this.gridColumnStartTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnOrderDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grdOvertimeOrders = new DevExpress.XtraGrid.GridControl();
            this.grvOvertimeOrdersTableView = new Common.Controls.WMSGridView();
            this.gridColumnOrderType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpe_OrderID = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCtns = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnKgs = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPlts = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnLocs = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOvertimeOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvOvertimeOrdersTableView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpe_OrderID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridColumnStartTime
            // 
            this.gridColumnStartTime.Caption = "Start Time";
            this.gridColumnStartTime.DisplayFormat.FormatString = "g";
            this.gridColumnStartTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumnStartTime.FieldName = "StartTime";
            this.gridColumnStartTime.Name = "gridColumnStartTime";
            this.gridColumnStartTime.Visible = true;
            this.gridColumnStartTime.VisibleIndex = 3;
            this.gridColumnStartTime.Width = 165;
            // 
            // gridColumnOrderDate
            // 
            this.gridColumnOrderDate.Caption = "Order Date";
            this.gridColumnOrderDate.FieldName = "OrderDate";
            this.gridColumnOrderDate.Name = "gridColumnOrderDate";
            this.gridColumnOrderDate.Visible = true;
            this.gridColumnOrderDate.VisibleIndex = 1;
            this.gridColumnOrderDate.Width = 97;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grdOvertimeOrders);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1839, 718);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grdOvertimeOrders
            // 
            this.grdOvertimeOrders.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdOvertimeOrders.Location = new System.Drawing.Point(16, 14);
            this.grdOvertimeOrders.MainView = this.grvOvertimeOrdersTableView;
            this.grdOvertimeOrders.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdOvertimeOrders.Name = "grdOvertimeOrders";
            this.grdOvertimeOrders.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpe_OrderID});
            this.grdOvertimeOrders.Size = new System.Drawing.Size(1807, 690);
            this.grdOvertimeOrders.TabIndex = 8;
            this.grdOvertimeOrders.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvOvertimeOrdersTableView});
            // 
            // grvOvertimeOrdersTableView
            // 
            this.grvOvertimeOrdersTableView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnOrderType,
            this.gridColumn9,
            this.gridColumn1,
            this.gridColumnOrderDate,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumnStartTime,
            this.gridColumn7,
            this.gridColumnCtns,
            this.gridColumnKgs,
            this.gridColumnPlts,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumnLocs});
            gridFormatRule1.Column = this.gridColumnStartTime;
            gridFormatRule1.Name = "Format0";
            formatConditionRuleExpression1.Expression = "GetHour([StartTime]) > 17";
            formatConditionRuleExpression1.PredefinedName = "Red Bold Text";
            gridFormatRule1.Rule = formatConditionRuleExpression1;
            gridFormatRule2.ApplyToRow = true;
            gridFormatRule2.Column = this.gridColumnOrderDate;
            gridFormatRule2.Name = "Format1";
            formatConditionRuleExpression2.Expression = "GetDayOfWeek([OrderDate]) = 0";
            formatConditionRuleExpression2.PredefinedName = "Red Fill";
            gridFormatRule2.Rule = formatConditionRuleExpression2;
            this.grvOvertimeOrdersTableView.FormatRules.Add(gridFormatRule1);
            this.grvOvertimeOrdersTableView.FormatRules.Add(gridFormatRule2);
            this.grvOvertimeOrdersTableView.GridControl = this.grdOvertimeOrders;
            this.grvOvertimeOrdersTableView.GroupCount = 1;
            this.grvOvertimeOrdersTableView.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Ctns", this.gridColumnCtns, "{0:n0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Kgs", this.gridColumnKgs, "{0:n3}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Plts", this.gridColumnPlts, "{0:n0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Locs", this.gridColumnLocs, "{0:n0}")});
            this.grvOvertimeOrdersTableView.Name = "grvOvertimeOrdersTableView";
            this.grvOvertimeOrdersTableView.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvOvertimeOrdersTableView.OptionsView.ShowFooter = true;
            this.grvOvertimeOrdersTableView.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvOvertimeOrdersTableView.PaintStyleName = "Skin";
            this.grvOvertimeOrdersTableView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumnOrderType, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumnOrderType
            // 
            this.gridColumnOrderType.Caption = "ORDER TYPE";
            this.gridColumnOrderType.FieldName = "OrderType";
            this.gridColumnOrderType.Name = "gridColumnOrderType";
            this.gridColumnOrderType.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Ctns", "SUM={0:0.##}"),
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Kgs", "SUM={0:0.##}"),
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Plts", "SUM={0:0.##}"),
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            this.gridColumnOrderType.Visible = true;
            this.gridColumnOrderType.VisibleIndex = 0;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "ID";
            this.gridColumn9.FieldName = "OrderID";
            this.gridColumn9.Name = "gridColumn9";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Order ID";
            this.gridColumn1.ColumnEdit = this.rpe_OrderID;
            this.gridColumn1.FieldName = "OrderNumber";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 105;
            // 
            // rpe_OrderID
            // 
            this.rpe_OrderID.AutoHeight = false;
            this.rpe_OrderID.Name = "rpe_OrderID";
            this.rpe_OrderID.DoubleClick += new System.EventHandler(this.rpe_OrderID_DoubleClick);
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Remark";
            this.gridColumn4.FieldName = "SpecialRequirement";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 316;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Internal Note";
            this.gridColumn5.FieldName = "InternalRemark";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 9;
            this.gridColumn5.Width = 293;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "End Time";
            this.gridColumn7.DisplayFormat.FormatString = "g";
            this.gridColumn7.FieldName = "EndTime";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 4;
            this.gridColumn7.Width = 144;
            // 
            // gridColumnCtns
            // 
            this.gridColumnCtns.Caption = "Ctns";
            this.gridColumnCtns.DisplayFormat.FormatString = "n0";
            this.gridColumnCtns.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnCtns.FieldName = "Ctns";
            this.gridColumnCtns.Name = "gridColumnCtns";
            this.gridColumnCtns.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Ctns", "{0:n0}")});
            this.gridColumnCtns.Visible = true;
            this.gridColumnCtns.VisibleIndex = 5;
            this.gridColumnCtns.Width = 68;
            // 
            // gridColumnKgs
            // 
            this.gridColumnKgs.Caption = "Kgs";
            this.gridColumnKgs.DisplayFormat.FormatString = "n3";
            this.gridColumnKgs.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnKgs.FieldName = "Kgs";
            this.gridColumnKgs.Name = "gridColumnKgs";
            this.gridColumnKgs.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Kgs", "{0:n3}")});
            this.gridColumnKgs.Visible = true;
            this.gridColumnKgs.VisibleIndex = 6;
            this.gridColumnKgs.Width = 97;
            // 
            // gridColumnPlts
            // 
            this.gridColumnPlts.Caption = "Plts";
            this.gridColumnPlts.DisplayFormat.FormatString = "n0";
            this.gridColumnPlts.FieldName = "Plts";
            this.gridColumnPlts.Name = "gridColumnPlts";
            this.gridColumnPlts.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Plts", "{0:n0}")});
            this.gridColumnPlts.Visible = true;
            this.gridColumnPlts.VisibleIndex = 7;
            this.gridColumnPlts.Width = 71;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Service";
            this.gridColumn2.FieldName = "ServiceNumber";
            this.gridColumn2.MinWidth = 27;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 10;
            this.gridColumn2.Width = 85;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Service Name";
            this.gridColumn3.FieldName = "ServiceName";
            this.gridColumn3.MinWidth = 27;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 11;
            this.gridColumn3.Width = 271;
            // 
            // gridColumnLocs
            // 
            this.gridColumnLocs.Caption = "Locs";
            this.gridColumnLocs.FieldName = "Locs";
            this.gridColumnLocs.MinWidth = 27;
            this.gridColumnLocs.Name = "gridColumnLocs";
            this.gridColumnLocs.Visible = true;
            this.gridColumnLocs.VisibleIndex = 8;
            this.gridColumnLocs.Width = 69;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1839, 718);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdOvertimeOrders;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1813, 694);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // frm_BR_Dialog_BillingDateOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1839, 718);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frm_BR_Dialog_BillingDateOrders";
            this.Text = "Customer Order by Billing Date";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOvertimeOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvOvertimeOrdersTableView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpe_OrderID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl grdOvertimeOrders;
        private Common.Controls.WMSGridView grvOvertimeOrdersTableView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnOrderType;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpe_OrderID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnOrderDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnStartTime;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCtns;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnKgs;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPlts;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnLocs;
    }
}