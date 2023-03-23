namespace UI.Admin
{
    partial class frm_AD_ExpenseDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_AD_ExpenseDetails));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.btn_update = new DevExpress.XtraEditors.SimpleButton();
            this.grcExpenseDetail = new DevExpress.XtraGrid.GridControl();
            this.grvExpenseDetail = new Common.Controls.WMSGridView();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OperatingCostExpenseDetailID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.grcPasteData = new DevExpress.XtraGrid.GridControl();
            this.grvPasteData = new Common.Controls.WMSGridView();
            this.ExpenseCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ExpenseName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ExpenseAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ExpenseRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OrderNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ExpenseUnitPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ExpenseQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btn_Save = new DevExpress.XtraEditors.SimpleButton();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcExpenseDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvExpenseDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcPasteData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPasteData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.simpleButton1);
            this.layoutControl1.Controls.Add(this.btn_update);
            this.layoutControl1.Controls.Add(this.grcExpenseDetail);
            this.layoutControl1.Controls.Add(this.checkEdit1);
            this.layoutControl1.Controls.Add(this.grcPasteData);
            this.layoutControl1.Controls.Add(this.btn_Save);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1448, 948);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger;
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.simpleButton1.Appearance.Options.UseBackColor = true;
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Location = new System.Drawing.Point(1305, 8);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.simpleButton1.MaximumSize = new System.Drawing.Size(135, 51);
            this.simpleButton1.MinimumSize = new System.Drawing.Size(135, 31);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(135, 32);
            this.simpleButton1.StyleController = this.layoutControl1;
            this.simpleButton1.TabIndex = 48;
            this.simpleButton1.Text = "Delete Details";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // btn_update
            // 
            this.btn_update.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Question;
            this.btn_update.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btn_update.Appearance.Options.UseBackColor = true;
            this.btn_update.Appearance.Options.UseFont = true;
            this.btn_update.Location = new System.Drawing.Point(1166, 8);
            this.btn_update.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_update.MaximumSize = new System.Drawing.Size(135, 51);
            this.btn_update.MinimumSize = new System.Drawing.Size(135, 31);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(135, 32);
            this.btn_update.StyleController = this.layoutControl1;
            this.btn_update.TabIndex = 47;
            this.btn_update.Text = "Update";
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // grcExpenseDetail
            // 
            this.grcExpenseDetail.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grcExpenseDetail.Location = new System.Drawing.Point(8, 44);
            this.grcExpenseDetail.MainView = this.grvExpenseDetail;
            this.grcExpenseDetail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grcExpenseDetail.Name = "grcExpenseDetail";
            this.grcExpenseDetail.Size = new System.Drawing.Size(1432, 409);
            this.grcExpenseDetail.TabIndex = 46;
            this.grcExpenseDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvExpenseDetail});
            this.grcExpenseDetail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grcExpenseDetail_KeyDown);
            // 
            // grvExpenseDetail
            // 
            this.grvExpenseDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn9,
            this.gridColumn17,
            this.gridColumn18,
            this.gridColumn19,
            this.gridColumn20,
            this.OperatingCostExpenseDetailID,
            this.gridColumn1,
            this.gridColumn2});
            this.grvExpenseDetail.DetailHeight = 539;
            this.grvExpenseDetail.GridControl = this.grcExpenseDetail;
            this.grvExpenseDetail.Name = "grvExpenseDetail";
            this.grvExpenseDetail.OptionsClipboard.PasteMode = DevExpress.Export.PasteMode.Append;
            this.grvExpenseDetail.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.grvExpenseDetail.OptionsView.ShowFooter = true;
            this.grvExpenseDetail.OptionsView.ShowGroupPanel = false;
            this.grvExpenseDetail.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvExpenseDetail.PaintStyleName = "Skin";
            this.grvExpenseDetail.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvExpenseDetail_CellValueChanging);
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "item Code";
            this.gridColumn9.FieldName = "ExpenseCode";
            this.gridColumn9.MinWidth = 30;
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 1;
            this.gridColumn9.Width = 118;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "item description";
            this.gridColumn17.FieldName = "ExpenseName";
            this.gridColumn17.MinWidth = 30;
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 2;
            this.gridColumn17.Width = 364;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "Amount";
            this.gridColumn18.DisplayFormat.FormatString = "{0:0,0.###}";
            this.gridColumn18.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn18.FieldName = "ExpenseAmount";
            this.gridColumn18.MinWidth = 30;
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ExpenseAmount", "{0:n0}")});
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 5;
            this.gridColumn18.Width = 130;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "Remark";
            this.gridColumn19.FieldName = "ExpenseRemark";
            this.gridColumn19.MinWidth = 30;
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 6;
            this.gridColumn19.Width = 436;
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "Order No";
            this.gridColumn20.FieldName = "OrderNumber";
            this.gridColumn20.MinWidth = 30;
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 0;
            this.gridColumn20.Width = 134;
            // 
            // OperatingCostExpenseDetailID
            // 
            this.OperatingCostExpenseDetailID.Caption = "OperatingCostExpenseDetailID";
            this.OperatingCostExpenseDetailID.FieldName = "OperatingCostExpenseDetailID";
            this.OperatingCostExpenseDetailID.MinWidth = 30;
            this.OperatingCostExpenseDetailID.Name = "OperatingCostExpenseDetailID";
            this.OperatingCostExpenseDetailID.Width = 112;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "UnitPrice";
            this.gridColumn1.DisplayFormat.FormatString = "{0:0,0.###}";
            this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn1.FieldName = "ExpenseUnitPrice";
            this.gridColumn1.MinWidth = 28;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 4;
            this.gridColumn1.Width = 125;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Quantity";
            this.gridColumn2.DisplayFormat.FormatString = "{0:0,0.###}";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn2.FieldName = "ExpenseQuantity";
            this.gridColumn2.MinWidth = 28;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 3;
            this.gridColumn2.Width = 98;
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(850, 8);
            this.checkEdit1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "Update Mode";
            this.checkEdit1.Size = new System.Drawing.Size(173, 28);
            this.checkEdit1.StyleController = this.layoutControl1;
            this.checkEdit1.TabIndex = 45;
            this.checkEdit1.CheckedChanged += new System.EventHandler(this.checkEdit1_CheckedChanged);
            // 
            // grcPasteData
            // 
            this.grcPasteData.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grcPasteData.Location = new System.Drawing.Point(8, 482);
            this.grcPasteData.MainView = this.grvPasteData;
            this.grcPasteData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grcPasteData.Name = "grcPasteData";
            this.grcPasteData.Size = new System.Drawing.Size(1432, 389);
            this.grcPasteData.TabIndex = 44;
            this.grcPasteData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvPasteData});
            // 
            // grvPasteData
            // 
            this.grvPasteData.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ExpenseCode,
            this.ExpenseName,
            this.ExpenseAmount,
            this.ExpenseRemark,
            this.OrderNumber,
            this.ExpenseUnitPrice,
            this.ExpenseQuantity});
            this.grvPasteData.DetailHeight = 539;
            this.grvPasteData.GridControl = this.grcPasteData;
            this.grvPasteData.Name = "grvPasteData";
            this.grvPasteData.OptionsClipboard.PasteMode = DevExpress.Export.PasteMode.Append;
            this.grvPasteData.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.grvPasteData.OptionsView.ShowFooter = true;
            this.grvPasteData.OptionsView.ShowGroupPanel = false;
            this.grvPasteData.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvPasteData.PaintStyleName = "Skin";
            // 
            // ExpenseCode
            // 
            this.ExpenseCode.Caption = "item Code";
            this.ExpenseCode.FieldName = "ExpenseCode";
            this.ExpenseCode.MinWidth = 30;
            this.ExpenseCode.Name = "ExpenseCode";
            this.ExpenseCode.Visible = true;
            this.ExpenseCode.VisibleIndex = 1;
            this.ExpenseCode.Width = 118;
            // 
            // ExpenseName
            // 
            this.ExpenseName.Caption = "item description";
            this.ExpenseName.FieldName = "ExpenseName";
            this.ExpenseName.MinWidth = 30;
            this.ExpenseName.Name = "ExpenseName";
            this.ExpenseName.Visible = true;
            this.ExpenseName.VisibleIndex = 2;
            this.ExpenseName.Width = 364;
            // 
            // ExpenseAmount
            // 
            this.ExpenseAmount.Caption = "Amount";
            this.ExpenseAmount.DisplayFormat.FormatString = "n0";
            this.ExpenseAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ExpenseAmount.FieldName = "ExpenseAmount";
            this.ExpenseAmount.MinWidth = 30;
            this.ExpenseAmount.Name = "ExpenseAmount";
            this.ExpenseAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ExpenseAmount", "{0:n0}")});
            this.ExpenseAmount.Visible = true;
            this.ExpenseAmount.VisibleIndex = 5;
            this.ExpenseAmount.Width = 136;
            // 
            // ExpenseRemark
            // 
            this.ExpenseRemark.Caption = "Remark";
            this.ExpenseRemark.FieldName = "ExpenseRemark";
            this.ExpenseRemark.MinWidth = 30;
            this.ExpenseRemark.Name = "ExpenseRemark";
            this.ExpenseRemark.Visible = true;
            this.ExpenseRemark.VisibleIndex = 6;
            this.ExpenseRemark.Width = 451;
            // 
            // OrderNumber
            // 
            this.OrderNumber.Caption = "Order No";
            this.OrderNumber.FieldName = "OrderNumber";
            this.OrderNumber.MinWidth = 30;
            this.OrderNumber.Name = "OrderNumber";
            this.OrderNumber.Visible = true;
            this.OrderNumber.VisibleIndex = 0;
            this.OrderNumber.Width = 134;
            // 
            // ExpenseUnitPrice
            // 
            this.ExpenseUnitPrice.Caption = "UnitPrice";
            this.ExpenseUnitPrice.DisplayFormat.FormatString = "n0";
            this.ExpenseUnitPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ExpenseUnitPrice.FieldName = "ExpenseUnitPrice";
            this.ExpenseUnitPrice.MinWidth = 28;
            this.ExpenseUnitPrice.Name = "ExpenseUnitPrice";
            this.ExpenseUnitPrice.Visible = true;
            this.ExpenseUnitPrice.VisibleIndex = 4;
            this.ExpenseUnitPrice.Width = 103;
            // 
            // ExpenseQuantity
            // 
            this.ExpenseQuantity.Caption = "Quantity";
            this.ExpenseQuantity.DisplayFormat.FormatString = "n0";
            this.ExpenseQuantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ExpenseQuantity.FieldName = "ExpenseQuantity";
            this.ExpenseQuantity.MinWidth = 28;
            this.ExpenseQuantity.Name = "ExpenseQuantity";
            this.ExpenseQuantity.Visible = true;
            this.ExpenseQuantity.VisibleIndex = 3;
            this.ExpenseQuantity.Width = 98;
            // 
            // btn_Save
            // 
            this.btn_Save.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Question;
            this.btn_Save.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btn_Save.Appearance.Options.UseBackColor = true;
            this.btn_Save.Appearance.Options.UseFont = true;
            this.btn_Save.Location = new System.Drawing.Point(1027, 8);
            this.btn_Save.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_Save.MaximumSize = new System.Drawing.Size(135, 51);
            this.btn_Save.MinimumSize = new System.Drawing.Size(135, 31);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(135, 32);
            this.btn_Save.StyleController = this.layoutControl1;
            this.btn_Save.TabIndex = 42;
            this.btn_Save.Text = "Save";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem9,
            this.layoutControlItem2,
            this.emptySpaceItem3,
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem6,
            this.layoutControlItem8,
            this.layoutControlItem3});
            this.Root.Name = "Root";
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(6, 6, 6, 6);
            this.Root.Size = new System.Drawing.Size(1448, 948);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.grcPasteData;
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 449);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(1436, 418);
            this.layoutControlItem9.Text = "Inserting Data";
            this.layoutControlItem9.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem9.TextSize = new System.Drawing.Size(100, 19);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.grcExpenseDetail;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 36);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(1436, 413);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 867);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(1436, 69);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btn_update;
            this.layoutControlItem1.Location = new System.Drawing.Point(1158, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(139, 36);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(842, 36);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btn_Save;
            this.layoutControlItem6.Location = new System.Drawing.Point(1019, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(139, 36);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.checkEdit1;
            this.layoutControlItem8.Location = new System.Drawing.Point(842, 0);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(177, 36);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.simpleButton1;
            this.layoutControlItem3.Location = new System.Drawing.Point(1297, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(139, 36);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // frm_AD_ExpenseDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1448, 948);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frm_AD_ExpenseDetails";
            this.Text = "Expenses Details";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_AD_ExpenseDetails_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcExpenseDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvExpenseDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcPasteData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPasteData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.SimpleButton btn_Save;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraGrid.GridControl grcPasteData;
        private Common.Controls.WMSGridView grvPasteData;
        private DevExpress.XtraGrid.Columns.GridColumn ExpenseCode;
        private DevExpress.XtraGrid.Columns.GridColumn ExpenseName;
        private DevExpress.XtraGrid.Columns.GridColumn ExpenseAmount;
        private DevExpress.XtraGrid.Columns.GridColumn ExpenseRemark;
        private DevExpress.XtraGrid.Columns.GridColumn OrderNumber;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraGrid.GridControl grcExpenseDetail;
        private Common.Controls.WMSGridView grvExpenseDetail;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SimpleButton btn_update;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.Columns.GridColumn OperatingCostExpenseDetailID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn ExpenseUnitPrice;
        private DevExpress.XtraGrid.Columns.GridColumn ExpenseQuantity;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}