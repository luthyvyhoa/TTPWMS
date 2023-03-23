namespace UI.Admin
{
    partial class frm_AD_POBySupplier
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_AD_POBySupplier));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.dateEditDateTo = new DevExpress.XtraEditors.DateEdit();
            this.dateEditDateFrom = new DevExpress.XtraEditors.DateEdit();
            this.lbl_suppName = new DevExpress.XtraEditors.LabelControl();
            this.ck_all = new DevExpress.XtraEditors.CheckEdit();
            this.lke_supplier = new DevExpress.XtraEditors.LookUpEdit();
            this.grc_PObySupplier = new DevExpress.XtraGrid.GridControl();
            this.grvPObySupplier = new Common.Controls.WMSGridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpihpl_PO = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.mlkmlkmlkm = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDateTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDateTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDateFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDateFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ck_all.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lke_supplier.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grc_PObySupplier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPObySupplier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpihpl_PO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mlkmlkmlkm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // rbcbase
            // 
            this.rbcbase.ExpandCollapseItem.Id = 0;
            this.rbcbase.Margin = new System.Windows.Forms.Padding(4);
            this.rbcbase.OptionsCustomizationForm.FormIcon = ((System.Drawing.Icon)(resources.GetObject("resource.FormIcon")));
            // 
            // 
            // 
            this.rbcbase.SearchEditItem.AccessibleName = "Search Item";
            this.rbcbase.SearchEditItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.rbcbase.SearchEditItem.EditWidth = 150;
            this.rbcbase.SearchEditItem.Id = -5000;
            this.rbcbase.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.rbcbase.Size = new System.Drawing.Size(1383, 51);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.dateEditDateTo);
            this.layoutControl1.Controls.Add(this.dateEditDateFrom);
            this.layoutControl1.Controls.Add(this.lbl_suppName);
            this.layoutControl1.Controls.Add(this.ck_all);
            this.layoutControl1.Controls.Add(this.lke_supplier);
            this.layoutControl1.Controls.Add(this.grc_PObySupplier);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 51);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1383, 730);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // dateEditDateTo
            // 
            this.dateEditDateTo.EditValue = null;
            this.dateEditDateTo.Location = new System.Drawing.Point(1001, 12);
            this.dateEditDateTo.Margin = new System.Windows.Forms.Padding(4);
            this.dateEditDateTo.MenuManager = this.rbcbase;
            this.dateEditDateTo.MinimumSize = new System.Drawing.Size(0, 24);
            this.dateEditDateTo.Name = "dateEditDateTo";
            this.dateEditDateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditDateTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditDateTo.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateEditDateTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditDateTo.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dateEditDateTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditDateTo.Size = new System.Drawing.Size(158, 26);
            this.dateEditDateTo.StyleController = this.layoutControl1;
            this.dateEditDateTo.TabIndex = 10;
            this.dateEditDateTo.EditValueChanged += new System.EventHandler(this.dateEditDateTo_EditValueChanged);
            // 
            // dateEditDateFrom
            // 
            this.dateEditDateFrom.EditValue = null;
            this.dateEditDateFrom.Location = new System.Drawing.Point(786, 12);
            this.dateEditDateFrom.Margin = new System.Windows.Forms.Padding(4);
            this.dateEditDateFrom.MenuManager = this.rbcbase;
            this.dateEditDateFrom.MinimumSize = new System.Drawing.Size(0, 24);
            this.dateEditDateFrom.Name = "dateEditDateFrom";
            this.dateEditDateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditDateFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditDateFrom.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateEditDateFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditDateFrom.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dateEditDateFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditDateFrom.Size = new System.Drawing.Size(164, 26);
            this.dateEditDateFrom.StyleController = this.layoutControl1;
            this.dateEditDateFrom.TabIndex = 9;
            this.dateEditDateFrom.EditValueChanged += new System.EventHandler(this.dateEditDateFrom_EditValueChanged);
            // 
            // lbl_suppName
            // 
            this.lbl_suppName.Location = new System.Drawing.Point(283, 12);
            this.lbl_suppName.Margin = new System.Windows.Forms.Padding(4);
            this.lbl_suppName.Name = "lbl_suppName";
            this.lbl_suppName.Size = new System.Drawing.Size(452, 16);
            this.lbl_suppName.StyleController = this.layoutControl1;
            this.lbl_suppName.TabIndex = 8;
            // 
            // ck_all
            // 
            this.ck_all.Location = new System.Drawing.Point(1296, 12);
            this.ck_all.Margin = new System.Windows.Forms.Padding(4);
            this.ck_all.MenuManager = this.rbcbase;
            this.ck_all.Name = "ck_all";
            this.ck_all.Properties.Caption = "All";
            this.ck_all.Size = new System.Drawing.Size(75, 24);
            this.ck_all.StyleController = this.layoutControl1;
            this.ck_all.TabIndex = 7;
            this.ck_all.CheckedChanged += new System.EventHandler(this.ck_all_CheckedChanged);
            // 
            // lke_supplier
            // 
            this.lke_supplier.Location = new System.Drawing.Point(69, 12);
            this.lke_supplier.Margin = new System.Windows.Forms.Padding(4);
            this.lke_supplier.MenuManager = this.rbcbase;
            this.lke_supplier.MinimumSize = new System.Drawing.Size(0, 24);
            this.lke_supplier.Name = "lke_supplier";
            this.lke_supplier.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lke_supplier.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SupplierName", "Supplier"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SupplierID", "Name4", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SupplierFullName", "Name5", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lke_supplier.Properties.NullText = "";
            this.lke_supplier.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lke_supplier.Size = new System.Drawing.Size(210, 26);
            this.lke_supplier.StyleController = this.layoutControl1;
            this.lke_supplier.TabIndex = 5;
            this.lke_supplier.EditValueChanged += new System.EventHandler(this.lke_supplier_EditValueChanged);
            // 
            // grc_PObySupplier
            // 
            this.grc_PObySupplier.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(5);
            this.grc_PObySupplier.Location = new System.Drawing.Point(12, 42);
            this.grc_PObySupplier.MainView = this.grvPObySupplier;
            this.grc_PObySupplier.Margin = new System.Windows.Forms.Padding(4);
            this.grc_PObySupplier.MenuManager = this.rbcbase;
            this.grc_PObySupplier.Name = "grc_PObySupplier";
            this.grc_PObySupplier.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpihpl_PO});
            this.grc_PObySupplier.Size = new System.Drawing.Size(1359, 676);
            this.grc_PObySupplier.TabIndex = 4;
            this.grc_PObySupplier.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvPObySupplier});
            // 
            // grvPObySupplier
            // 
            this.grvPObySupplier.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11});
            this.grvPObySupplier.DetailHeight = 458;
            this.grvPObySupplier.FixedLineWidth = 3;
            this.grvPObySupplier.GridControl = this.grc_PObySupplier;
            this.grvPObySupplier.Name = "grvPObySupplier";
            this.grvPObySupplier.OptionsView.ShowFooter = true;
            this.grvPObySupplier.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvPObySupplier.PaintStyleName = "Skin";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Order No";
            this.gridColumn1.ColumnEdit = this.rpihpl_PO;
            this.gridColumn1.FieldName = "PurchasingOrderNumber";
            this.gridColumn1.MinWidth = 27;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "PurchasingOrderNumber", "Total order: {0}")});
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 100;
            // 
            // rpihpl_PO
            // 
            this.rpihpl_PO.AutoHeight = false;
            this.rpihpl_PO.Name = "rpihpl_PO";
            this.rpihpl_PO.Click += new System.EventHandler(this.rpihpl_PO_Click);
            this.rpihpl_PO.DoubleClick += new System.EventHandler(this.rpihpl_PO_DoubleClick);
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Order Date";
            this.gridColumn2.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn2.FieldName = "PuchasingDate";
            this.gridColumn2.MinWidth = 27;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 100;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Deli. Date";
            this.gridColumn3.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn3.FieldName = "DeliveryDate";
            this.gridColumn3.MinWidth = 27;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 100;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Store";
            this.gridColumn4.FieldName = "StoreNumber";
            this.gridColumn4.MinWidth = 27;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 100;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Dept.";
            this.gridColumn5.FieldName = "DepartmentCategoryID";
            this.gridColumn5.MinWidth = 27;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 100;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Supplier";
            this.gridColumn6.FieldName = "SupplierName";
            this.gridColumn6.MinWidth = 27;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 100;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Order By";
            this.gridColumn7.FieldName = "OrderBy";
            this.gridColumn7.MinWidth = 27;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            this.gridColumn7.Width = 100;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Status";
            this.gridColumn8.FieldName = "OrderConfirmed";
            this.gridColumn8.MinWidth = 27;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            this.gridColumn8.Width = 100;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Currency";
            this.gridColumn9.FieldName = "Currency";
            this.gridColumn9.MinWidth = 27;
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 8;
            this.gridColumn9.Width = 100;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Amount";
            this.gridColumn10.DisplayFormat.FormatString = "n0";
            this.gridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn10.FieldName = "Amount";
            this.gridColumn10.MinWidth = 27;
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", "total: {0:0.##}")});
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 9;
            this.gridColumn10.Width = 100;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Remark";
            this.gridColumn11.FieldName = "PurchasingRemark";
            this.gridColumn11.MinWidth = 27;
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 10;
            this.gridColumn11.Width = 100;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem4,
            this.emptySpaceItem1,
            this.mlkmlkmlkm,
            this.layoutControlItem3,
            this.layoutControlItem5});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1383, 730);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grc_PObySupplier;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 30);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1363, 680);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.lke_supplier;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(271, 30);
            this.layoutControlItem2.Text = "Supplier:";
            this.layoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(52, 16);
            this.layoutControlItem2.TextToControlDistance = 5;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.ck_all;
            this.layoutControlItem4.Location = new System.Drawing.Point(1284, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(79, 30);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(1151, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(133, 30);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // mlkmlkmlkm
            // 
            this.mlkmlkmlkm.Control = this.lbl_suppName;
            this.mlkmlkmlkm.Location = new System.Drawing.Point(271, 0);
            this.mlkmlkmlkm.Name = "mlkmlkmlkm";
            this.mlkmlkmlkm.Size = new System.Drawing.Size(456, 30);
            this.mlkmlkmlkm.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.SupportHorzAlignment;
            this.mlkmlkmlkm.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.mlkmlkmlkm.TextSize = new System.Drawing.Size(0, 0);
            this.mlkmlkmlkm.TextToControlDistance = 0;
            this.mlkmlkmlkm.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.dateEditDateFrom;
            this.layoutControlItem3.Location = new System.Drawing.Point(727, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(215, 30);
            this.layoutControlItem3.Text = "From:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(35, 16);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.dateEditDateTo;
            this.layoutControlItem5.Location = new System.Drawing.Point(942, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(209, 30);
            this.layoutControlItem5.Text = "To:";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(35, 16);
            // 
            // frm_AD_POBySupplier
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1383, 781);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_AD_POBySupplier.IconOptions.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_AD_POBySupplier";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "Purchasing Order By Supplier";
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDateTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDateTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDateFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDateFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ck_all.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lke_supplier.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grc_PObySupplier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPObySupplier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpihpl_PO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mlkmlkmlkm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.CheckEdit ck_all;
        private DevExpress.XtraEditors.LookUpEdit lke_supplier;
        private DevExpress.XtraGrid.GridControl grc_PObySupplier;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.LabelControl lbl_suppName;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem mlkmlkmlkm;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private Common.Controls.WMSGridView grvPObySupplier;
        private DevExpress.XtraEditors.DateEdit dateEditDateTo;
        private DevExpress.XtraEditors.DateEdit dateEditDateFrom;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpihpl_PO;
    }
}