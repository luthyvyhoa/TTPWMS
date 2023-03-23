namespace UI.Admin
{
    partial class frm_AD_ItemReview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_AD_ItemReview));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grcItemReview_Cash = new DevExpress.XtraGrid.GridControl();
            this.grvItemReview_Cash = new Common.Controls.WMSGridView();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.hle_CashID = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcItemReview_PO = new DevExpress.XtraGrid.GridControl();
            this.grvItemReview_PO = new Common.Controls.WMSGridView();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.hle_PurchasingOrderID = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lkeProperty = new DevExpress.XtraEditors.LookUpEdit();
            this.lke_MSS_StoreList = new DevExpress.XtraEditors.LookUpEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem29 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcItemReview_Cash)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvItemReview_Cash)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hle_CashID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcItemReview_PO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvItemReview_PO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hle_PurchasingOrderID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeProperty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lke_MSS_StoreList.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grcItemReview_Cash);
            this.layoutControl1.Controls.Add(this.grcItemReview_PO);
            this.layoutControl1.Controls.Add(this.lkeProperty);
            this.layoutControl1.Controls.Add(this.lke_MSS_StoreList);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1108, 448, 812, 500);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1758, 948);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grcItemReview_Cash
            // 
            this.grcItemReview_Cash.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grcItemReview_Cash.Location = new System.Drawing.Point(967, 71);
            this.grcItemReview_Cash.MainView = this.grvItemReview_Cash;
            this.grcItemReview_Cash.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grcItemReview_Cash.Name = "grcItemReview_Cash";
            this.grcItemReview_Cash.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.hle_CashID});
            this.grcItemReview_Cash.Size = new System.Drawing.Size(785, 871);
            this.grcItemReview_Cash.TabIndex = 5;
            this.grcItemReview_Cash.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvItemReview_Cash});
            // 
            // grvItemReview_Cash
            // 
            this.grvItemReview_Cash.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn14,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn11,
            this.gridColumn15});
            this.grvItemReview_Cash.DetailHeight = 437;
            this.grvItemReview_Cash.GridControl = this.grcItemReview_Cash;
            this.grvItemReview_Cash.Name = "grvItemReview_Cash";
            this.grvItemReview_Cash.OptionsView.ShowFooter = true;
            this.grvItemReview_Cash.OptionsView.ShowGroupPanel = false;
            this.grvItemReview_Cash.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvItemReview_Cash.PaintStyleName = "Skin";
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "No.";
            this.gridColumn14.ColumnEdit = this.hle_CashID;
            this.gridColumn14.FieldName = "PettyCashNumber";
            this.gridColumn14.MinWidth = 28;
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 0;
            this.gridColumn14.Width = 105;
            // 
            // hle_CashID
            // 
            this.hle_CashID.AutoHeight = false;
            this.hle_CashID.Name = "hle_CashID";
            this.hle_CashID.Click += new System.EventHandler(this.hle_CashID_Click);
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Date";
            this.gridColumn5.FieldName = "ExpensesDate";
            this.gridColumn5.MinWidth = 28;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            this.gridColumn5.Width = 126;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Qty";
            this.gridColumn6.DisplayFormat.FormatString = "n0";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn6.FieldName = "Quantity";
            this.gridColumn6.MinWidth = 28;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", "{0:n0}")});
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 2;
            this.gridColumn6.Width = 72;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "User";
            this.gridColumn7.MinWidth = 28;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Remark";
            this.gridColumn8.FieldName = "ItemRemark";
            this.gridColumn8.MinWidth = 28;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 4;
            this.gridColumn8.Width = 280;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Amount (NET)";
            this.gridColumn11.DisplayFormat.FormatString = "n0";
            this.gridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn11.FieldName = "ExpenseAmount";
            this.gridColumn11.MinWidth = 28;
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ExpenseAmount", "{0:n0}")});
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 3;
            this.gridColumn11.Width = 105;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "PettyCashID";
            this.gridColumn15.FieldName = "PettyCashID";
            this.gridColumn15.MinWidth = 28;
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Width = 105;
            // 
            // grcItemReview_PO
            // 
            this.grcItemReview_PO.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grcItemReview_PO.Location = new System.Drawing.Point(6, 71);
            this.grcItemReview_PO.MainView = this.grvItemReview_PO;
            this.grcItemReview_PO.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grcItemReview_PO.Name = "grcItemReview_PO";
            this.grcItemReview_PO.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.hle_PurchasingOrderID});
            this.grcItemReview_PO.Size = new System.Drawing.Size(955, 871);
            this.grcItemReview_PO.TabIndex = 4;
            this.grcItemReview_PO.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvItemReview_PO});
            // 
            // grvItemReview_PO
            // 
            this.grvItemReview_PO.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn12,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn13});
            this.grvItemReview_PO.DetailHeight = 437;
            this.grvItemReview_PO.GridControl = this.grcItemReview_PO;
            this.grvItemReview_PO.Name = "grvItemReview_PO";
            this.grvItemReview_PO.OptionsView.ShowFooter = true;
            this.grvItemReview_PO.OptionsView.ShowGroupPanel = false;
            this.grvItemReview_PO.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvItemReview_PO.PaintStyleName = "Skin";
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "No.";
            this.gridColumn12.ColumnEdit = this.hle_PurchasingOrderID;
            this.gridColumn12.FieldName = "PurchasingOrderNumber";
            this.gridColumn12.MinWidth = 28;
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 0;
            this.gridColumn12.Width = 105;
            // 
            // hle_PurchasingOrderID
            // 
            this.hle_PurchasingOrderID.AutoHeight = false;
            this.hle_PurchasingOrderID.Name = "hle_PurchasingOrderID";
            this.hle_PurchasingOrderID.Click += new System.EventHandler(this.hle_PurchasingOrderID_Click);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Date";
            this.gridColumn1.FieldName = "PuchasingDate";
            this.gridColumn1.MinWidth = 28;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 108;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Qty";
            this.gridColumn2.DisplayFormat.FormatString = "n0";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn2.FieldName = "OrderQuantity";
            this.gridColumn2.MinWidth = 28;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OrderQuantity", "{0:n0}")});
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 3;
            this.gridColumn2.Width = 71;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "User";
            this.gridColumn3.FieldName = "CreatedBy";
            this.gridColumn3.MinWidth = 28;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 6;
            this.gridColumn3.Width = 80;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Remark";
            this.gridColumn4.FieldName = "ItemRemark";
            this.gridColumn4.MinWidth = 28;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 5;
            this.gridColumn4.Width = 334;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Supplier";
            this.gridColumn9.FieldName = "SupplierName";
            this.gridColumn9.MinWidth = 28;
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 2;
            this.gridColumn9.Width = 207;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Amount";
            this.gridColumn10.DisplayFormat.FormatString = "n0";
            this.gridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn10.FieldName = "Amount";
            this.gridColumn10.MinWidth = 28;
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", "{0:n0}")});
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 4;
            this.gridColumn10.Width = 118;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "gridColumn13";
            this.gridColumn13.FieldName = "PurchasingOrderID";
            this.gridColumn13.MinWidth = 28;
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Width = 105;
            // 
            // lkeProperty
            // 
            this.lkeProperty.Location = new System.Drawing.Point(185, 6);
            this.lkeProperty.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lkeProperty.MinimumSize = new System.Drawing.Size(0, 30);
            this.lkeProperty.Name = "lkeProperty";
            this.lkeProperty.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeProperty.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PartID", "PartID", 22, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PartNumber", "Number", 56, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PartName", "Description", 337, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.Ascending, DevExpress.Utils.DefaultBoolean.Default)});
            this.lkeProperty.Properties.DropDownRows = 30;
            this.lkeProperty.Properties.NullText = "";
            this.lkeProperty.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lkeProperty.Size = new System.Drawing.Size(753, 32);
            this.lkeProperty.StyleController = this.layoutControl1;
            this.lkeProperty.TabIndex = 56;
            this.lkeProperty.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(this.lkeProperty_Closed);
            // 
            // lke_MSS_StoreList
            // 
            this.lke_MSS_StoreList.Location = new System.Drawing.Point(1509, 6);
            this.lke_MSS_StoreList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lke_MSS_StoreList.MaximumSize = new System.Drawing.Size(0, 30);
            this.lke_MSS_StoreList.MinimumSize = new System.Drawing.Size(0, 31);
            this.lke_MSS_StoreList.Name = "lke_MSS_StoreList";
            this.lke_MSS_StoreList.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lke_MSS_StoreList.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lke_MSS_StoreList.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StoreID", "StoreID", 22, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StoreDescription", "StoreDescription", 22, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lke_MSS_StoreList.Properties.NullText = "";
            this.lke_MSS_StoreList.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.StartsWith;
            this.lke_MSS_StoreList.Properties.ShowFooter = false;
            this.lke_MSS_StoreList.Properties.ShowHeader = false;
            this.lke_MSS_StoreList.Size = new System.Drawing.Size(243, 31);
            this.lke_MSS_StoreList.StyleController = this.layoutControl1;
            this.lke_MSS_StoreList.TabIndex = 6;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem29,
            this.emptySpaceItem1,
            this.layoutControlItem8});
            this.Root.Name = "Root";
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 2, 2);
            this.Root.Size = new System.Drawing.Size(1758, 948);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grcItemReview_PO;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 40);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(961, 904);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem1.Text = "PURCHASING ORDERS";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(165, 19);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.grcItemReview_Cash;
            this.layoutControlItem2.Location = new System.Drawing.Point(961, 40);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(791, 904);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem2.Text = "CASH";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(165, 19);
            // 
            // layoutControlItem29
            // 
            this.layoutControlItem29.Control = this.lkeProperty;
            this.layoutControlItem29.CustomizationFormText = "Item";
            this.layoutControlItem29.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem29.Name = "layoutControlItem29";
            this.layoutControlItem29.Size = new System.Drawing.Size(938, 40);
            this.layoutControlItem29.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem29.Text = "Item";
            this.layoutControlItem29.TextSize = new System.Drawing.Size(165, 19);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(938, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(517, 40);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.lke_MSS_StoreList;
            this.layoutControlItem8.CustomizationFormText = "Store:";
            this.layoutControlItem8.Location = new System.Drawing.Point(1455, 0);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(297, 40);
            this.layoutControlItem8.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem8.Text = "Store:";
            this.layoutControlItem8.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem8.TextSize = new System.Drawing.Size(43, 19);
            this.layoutControlItem8.TextToControlDistance = 5;
            // 
            // frm_AD_ItemReview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1758, 948);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frm_AD_ItemReview";
            this.Text = "Item PO / Cash Review";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcItemReview_Cash)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvItemReview_Cash)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hle_CashID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcItemReview_PO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvItemReview_PO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hle_PurchasingOrderID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeProperty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lke_MSS_StoreList.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraGrid.GridControl grcItemReview_Cash;
        private DevExpress.XtraGrid.GridControl grcItemReview_PO;
        private Common.Controls.WMSGridView grvItemReview_PO;
        private Common.Controls.WMSGridView grvItemReview_Cash;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.LookUpEdit lkeProperty;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem29;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.LookUpEdit lke_MSS_StoreList;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit hle_CashID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit hle_PurchasingOrderID;
    }
}