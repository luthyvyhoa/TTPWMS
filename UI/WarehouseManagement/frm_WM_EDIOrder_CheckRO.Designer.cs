namespace UI.WarehouseManagement
{
    partial class frm_WM_EDIOrder_CheckRO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_WM_EDIOrder_CheckRO));
            this.gridColumnROQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnRO_ExpDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnRO_Prodate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grcEDI_Order_CheckRO = new DevExpress.XtraGrid.GridControl();
            this.grvEDI_Order_CheckRO = new Common.Controls.WMSGridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnExpDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnProDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcEDI_Order_CheckRO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEDI_Order_CheckRO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridColumnROQty
            // 
            this.gridColumnROQty.Caption = "RO_Qty";
            this.gridColumnROQty.DisplayFormat.FormatString = "n0";
            this.gridColumnROQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnROQty.FieldName = "RO_Quantity";
            this.gridColumnROQty.MinWidth = 28;
            this.gridColumnROQty.Name = "gridColumnROQty";
            this.gridColumnROQty.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "RO_Quantity", "{0:n0}")});
            this.gridColumnROQty.Visible = true;
            this.gridColumnROQty.VisibleIndex = 3;
            this.gridColumnROQty.Width = 72;
            // 
            // gridColumnRO_ExpDate
            // 
            this.gridColumnRO_ExpDate.Caption = "RO_ExpDate";
            this.gridColumnRO_ExpDate.DisplayFormat.FormatString = "d";
            this.gridColumnRO_ExpDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumnRO_ExpDate.FieldName = "RO_ExpiryDate";
            this.gridColumnRO_ExpDate.MinWidth = 28;
            this.gridColumnRO_ExpDate.Name = "gridColumnRO_ExpDate";
            this.gridColumnRO_ExpDate.Visible = true;
            this.gridColumnRO_ExpDate.VisibleIndex = 7;
            this.gridColumnRO_ExpDate.Width = 100;
            // 
            // gridColumnRO_Prodate
            // 
            this.gridColumnRO_Prodate.Caption = "RO_ProDate";
            this.gridColumnRO_Prodate.DisplayFormat.FormatString = "d";
            this.gridColumnRO_Prodate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumnRO_Prodate.FieldName = "RO_ProductionDate";
            this.gridColumnRO_Prodate.MinWidth = 28;
            this.gridColumnRO_Prodate.Name = "gridColumnRO_Prodate";
            this.gridColumnRO_Prodate.Visible = true;
            this.gridColumnRO_Prodate.VisibleIndex = 9;
            this.gridColumnRO_Prodate.Width = 91;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grcEDI_Order_CheckRO);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1788, 908);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grcEDI_Order_CheckRO
            // 
            this.grcEDI_Order_CheckRO.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grcEDI_Order_CheckRO.Location = new System.Drawing.Point(12, 13);
            this.grcEDI_Order_CheckRO.MainView = this.grvEDI_Order_CheckRO;
            this.grcEDI_Order_CheckRO.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grcEDI_Order_CheckRO.Name = "grcEDI_Order_CheckRO";
            this.grcEDI_Order_CheckRO.Size = new System.Drawing.Size(1764, 882);
            this.grcEDI_Order_CheckRO.TabIndex = 4;
            this.grcEDI_Order_CheckRO.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvEDI_Order_CheckRO});
            // 
            // grvEDI_Order_CheckRO
            // 
            this.grvEDI_Order_CheckRO.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumnQty,
            this.gridColumnROQty,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumnExpDate,
            this.gridColumnRO_ExpDate,
            this.gridColumnProDate,
            this.gridColumnRO_Prodate,
            this.gridColumn11,
            this.gridColumn12});
            this.grvEDI_Order_CheckRO.DetailHeight = 437;
            gridFormatRule1.Column = this.gridColumnROQty;
            gridFormatRule1.ColumnApplyTo = this.gridColumnROQty;
            gridFormatRule1.Name = "Format0";
            formatConditionRuleExpression1.Expression = "[Quantity] <> [RO_Quantity]";
            formatConditionRuleExpression1.PredefinedName = "Red Fill";
            gridFormatRule1.Rule = formatConditionRuleExpression1;
            gridFormatRule2.Column = this.gridColumnRO_ExpDate;
            gridFormatRule2.ColumnApplyTo = this.gridColumnRO_ExpDate;
            gridFormatRule2.Name = "Format1";
            formatConditionRuleExpression2.Expression = "[ExpiryDate] <> [RO_ExpiryDate]";
            formatConditionRuleExpression2.PredefinedName = "Red Fill";
            gridFormatRule2.Rule = formatConditionRuleExpression2;
            gridFormatRule3.Column = this.gridColumnRO_Prodate;
            gridFormatRule3.ColumnApplyTo = this.gridColumnRO_Prodate;
            gridFormatRule3.Name = "Format2";
            formatConditionRuleExpression3.Expression = "[ProductionDate] <> [RO_ProductionDate]";
            formatConditionRuleExpression3.PredefinedName = "Red Fill";
            gridFormatRule3.Rule = formatConditionRuleExpression3;
            this.grvEDI_Order_CheckRO.FormatRules.Add(gridFormatRule1);
            this.grvEDI_Order_CheckRO.FormatRules.Add(gridFormatRule2);
            this.grvEDI_Order_CheckRO.FormatRules.Add(gridFormatRule3);
            this.grvEDI_Order_CheckRO.GridControl = this.grcEDI_Order_CheckRO;
            this.grvEDI_Order_CheckRO.Name = "grvEDI_Order_CheckRO";
            this.grvEDI_Order_CheckRO.OptionsView.ShowFooter = true;
            this.grvEDI_Order_CheckRO.OptionsView.ShowGroupPanel = false;
            this.grvEDI_Order_CheckRO.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvEDI_Order_CheckRO.PaintStyleName = "Skin";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Product ID";
            this.gridColumn1.FieldName = "ProductNumber";
            this.gridColumn1.MinWidth = 28;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 159;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Product Name";
            this.gridColumn2.FieldName = "ProductName";
            this.gridColumn2.MinWidth = 28;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 426;
            // 
            // gridColumnQty
            // 
            this.gridColumnQty.Caption = "EDI_Qty";
            this.gridColumnQty.DisplayFormat.FormatString = "n0";
            this.gridColumnQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnQty.FieldName = "Quantity";
            this.gridColumnQty.MinWidth = 28;
            this.gridColumnQty.Name = "gridColumnQty";
            this.gridColumnQty.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", "{0:n0}")});
            this.gridColumnQty.Visible = true;
            this.gridColumnQty.VisibleIndex = 2;
            this.gridColumnQty.Width = 79;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "EDI_Ref";
            this.gridColumn5.FieldName = "CustomerRef";
            this.gridColumn5.MinWidth = 28;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 120;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "RO_Ref";
            this.gridColumn6.FieldName = "RO_CustomerRef";
            this.gridColumn6.MinWidth = 28;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 120;
            // 
            // gridColumnExpDate
            // 
            this.gridColumnExpDate.Caption = "EDI_ExpDate";
            this.gridColumnExpDate.DisplayFormat.FormatString = "d";
            this.gridColumnExpDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumnExpDate.FieldName = "ExpiryDate";
            this.gridColumnExpDate.MinWidth = 28;
            this.gridColumnExpDate.Name = "gridColumnExpDate";
            this.gridColumnExpDate.Visible = true;
            this.gridColumnExpDate.VisibleIndex = 6;
            this.gridColumnExpDate.Width = 94;
            // 
            // gridColumnProDate
            // 
            this.gridColumnProDate.Caption = "EDI_ProDate";
            this.gridColumnProDate.DisplayFormat.FormatString = "d";
            this.gridColumnProDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumnProDate.FieldName = "ProductionDate";
            this.gridColumnProDate.MinWidth = 28;
            this.gridColumnProDate.Name = "gridColumnProDate";
            this.gridColumnProDate.Visible = true;
            this.gridColumnProDate.VisibleIndex = 8;
            this.gridColumnProDate.Width = 97;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "EDI_Remark";
            this.gridColumn11.FieldName = "ProductRemark";
            this.gridColumn11.MinWidth = 28;
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 10;
            this.gridColumn11.Width = 173;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "RO_Remark";
            this.gridColumn12.FieldName = "RO_ProductRemark";
            this.gridColumn12.MinWidth = 28;
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 11;
            this.gridColumn12.Width = 195;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1788, 908);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grcEDI_Order_CheckRO;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1768, 886);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // frm_WM_EDIOrder_CheckRO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1788, 908);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_WM_EDIOrder_CheckRO";
            this.Text = "EDI Order Check RO";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcEDI_Order_CheckRO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEDI_Order_CheckRO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraGrid.GridControl grcEDI_Order_CheckRO;
        private Common.Controls.WMSGridView grvEDI_Order_CheckRO;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnQty;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnROQty;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnExpDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnRO_ExpDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnProDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnRO_Prodate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}