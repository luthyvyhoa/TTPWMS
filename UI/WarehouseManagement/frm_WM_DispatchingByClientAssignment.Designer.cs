namespace UI.WarehouseManagement
{
    partial class frm_WM_DispatchingByClientAssignment
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_WM_DispatchingByClientAssignment));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnAddNew = new DevExpress.XtraEditors.SimpleButton();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.textCustomerName = new DevExpress.XtraEditors.TextEdit();
            this.lkeCustomerID = new DevExpress.XtraEditors.LookUpEdit();
            this.grcDOAssignments = new DevExpress.XtraGrid.GridControl();
            this.grvAssignments = new Common.Controls.WMSGridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rhe_ProductID = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rle_CustomerClientID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rhe_ROID = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_btn_Delete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.DispatchingByClientAssignmentID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem42 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem30 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textCustomerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeCustomerID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcDOAssignments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAssignments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rhe_ProductID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rle_CustomerClientID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rhe_ROID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_btn_Delete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem42)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnAddNew);
            this.layoutControl1.Controls.Add(this.checkEdit1);
            this.layoutControl1.Controls.Add(this.textCustomerName);
            this.layoutControl1.Controls.Add(this.lkeCustomerID);
            this.layoutControl1.Controls.Add(this.grcDOAssignments);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1030, 334, 812, 500);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1639, 789);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnAddNew
            // 
            this.btnAddNew.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Question;
            this.btnAddNew.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnAddNew.Appearance.Options.UseBackColor = true;
            this.btnAddNew.Appearance.Options.UseFont = true;
            this.btnAddNew.Location = new System.Drawing.Point(1505, 12);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(122, 27);
            this.btnAddNew.StyleController = this.layoutControl1;
            this.btnAddNew.TabIndex = 8;
            this.btnAddNew.Text = "Add RO";
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(702, 15);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "All History";
            this.checkEdit1.Size = new System.Drawing.Size(318, 24);
            this.checkEdit1.StyleController = this.layoutControl1;
            this.checkEdit1.TabIndex = 7;
            // 
            // textCustomerName
            // 
            this.textCustomerName.Location = new System.Drawing.Point(231, 13);
            this.textCustomerName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textCustomerName.MinimumSize = new System.Drawing.Size(0, 24);
            this.textCustomerName.Name = "textCustomerName";
            this.textCustomerName.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(150)))));
            this.textCustomerName.Properties.Appearance.Options.UseForeColor = true;
            this.textCustomerName.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.textCustomerName.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.textCustomerName.Properties.AppearanceDisabled.Options.UseFont = true;
            this.textCustomerName.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.textCustomerName.Properties.ReadOnly = true;
            this.textCustomerName.Size = new System.Drawing.Size(463, 26);
            this.textCustomerName.StyleController = this.layoutControl1;
            this.textCustomerName.TabIndex = 6;
            this.textCustomerName.TabStop = false;
            // 
            // lkeCustomerID
            // 
            this.lkeCustomerID.EnterMoveNextControl = true;
            this.lkeCustomerID.Location = new System.Drawing.Point(88, 13);
            this.lkeCustomerID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lkeCustomerID.MinimumSize = new System.Drawing.Size(0, 24);
            this.lkeCustomerID.Name = "lkeCustomerID";
            this.lkeCustomerID.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(150)))));
            this.lkeCustomerID.Properties.Appearance.Options.UseForeColor = true;
            this.lkeCustomerID.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkeCustomerID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeCustomerID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerNumber", "Customer Number", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.Ascending, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerName", "Customer Name", 300, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lkeCustomerID.Properties.DisplayMember = "CustomerNumber";
            this.lkeCustomerID.Properties.DropDownRows = 20;
            this.lkeCustomerID.Properties.ImmediatePopup = true;
            this.lkeCustomerID.Properties.NullText = "";
            this.lkeCustomerID.Properties.ShowFooter = false;
            this.lkeCustomerID.Properties.ShowHeader = false;
            this.lkeCustomerID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lkeCustomerID.Properties.ValueMember = "CustomerID";
            this.lkeCustomerID.Size = new System.Drawing.Size(137, 26);
            this.lkeCustomerID.StyleController = this.layoutControl1;
            this.lkeCustomerID.TabIndex = 1;
            this.lkeCustomerID.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(this.lkeCustomerID_CloseUp);
            // 
            // grcDOAssignments
            // 
            this.grcDOAssignments.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            gridLevelNode1.RelationName = "Level1";
            this.grcDOAssignments.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grcDOAssignments.Location = new System.Drawing.Point(12, 46);
            this.grcDOAssignments.MainView = this.grvAssignments;
            this.grcDOAssignments.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grcDOAssignments.Name = "grcDOAssignments";
            this.grcDOAssignments.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rle_CustomerClientID,
            this.rpi_btn_Delete,
            this.rhe_ProductID,
            this.rhe_ROID});
            this.grcDOAssignments.Size = new System.Drawing.Size(1615, 731);
            this.grcDOAssignments.TabIndex = 4;
            this.grcDOAssignments.TabStop = false;
            this.grcDOAssignments.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvAssignments});
            // 
            // grvAssignments
            // 
            this.grvAssignments.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grvAssignments.Appearance.FooterPanel.Options.UseFont = true;
            this.grvAssignments.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.grvAssignments.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvAssignments.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn18,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.DispatchingByClientAssignmentID,
            this.gridColumn10});
            this.grvAssignments.GridControl = this.grcDOAssignments;
            this.grvAssignments.Name = "grvAssignments";
            this.grvAssignments.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.grvAssignments.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.grvAssignments.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.grvAssignments.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grvAssignments.OptionsNavigation.EnterMoveNextColumn = true;
            this.grvAssignments.OptionsSelection.CheckBoxSelectorColumnWidth = 35;
            this.grvAssignments.OptionsSelection.MultiSelect = true;
            this.grvAssignments.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.grvAssignments.OptionsView.ShowFooter = true;
            this.grvAssignments.OptionsView.ShowGroupPanel = false;
            this.grvAssignments.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvAssignments.PaintStyleName = "Skin";
            this.grvAssignments.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvAssignments_CellValueChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Product ID";
            this.gridColumn1.ColumnEdit = this.rhe_ProductID;
            this.gridColumn1.FieldName = "ProductNumber";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 145;
            // 
            // rhe_ProductID
            // 
            this.rhe_ProductID.AutoHeight = false;
            this.rhe_ProductID.Name = "rhe_ProductID";
            this.rhe_ProductID.Click += new System.EventHandler(this.rhe_ProductID_Click);
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Product Name";
            this.gridColumn2.FieldName = "ProductName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ProductName", "Total: {0}")});
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 319;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Qty";
            this.gridColumn3.FieldName = "TotalPackages";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 55;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Assign.Remark";
            this.gridColumn11.FieldName = "Remark";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 9;
            this.gridColumn11.Width = 230;
            // 
            // gridColumn12
            // 
            this.gridColumn12.AppearanceCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(150)))));
            this.gridColumn12.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn12.Caption = "Reference";
            this.gridColumn12.FieldName = "CustomerRef";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 7;
            this.gridColumn12.Width = 131;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "User";
            this.gridColumn13.FieldName = "CreateBy";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 10;
            this.gridColumn13.Width = 61;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "RODID";
            this.gridColumn18.FieldName = "ReceivingOrderDetailID";
            this.gridColumn18.Name = "gridColumn18";
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "C.Time";
            this.gridColumn4.DisplayFormat.FormatString = "g";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn4.FieldName = "CreateTime";
            this.gridColumn4.MinWidth = 25;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 11;
            this.gridColumn4.Width = 111;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Client";
            this.gridColumn5.ColumnEdit = this.rle_CustomerClientID;
            this.gridColumn5.FieldName = "CustomerClientID";
            this.gridColumn5.MinWidth = 25;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 8;
            this.gridColumn5.Width = 238;
            // 
            // rle_CustomerClientID
            // 
            this.rle_CustomerClientID.AutoHeight = false;
            this.rle_CustomerClientID.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.rle_CustomerClientID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rle_CustomerClientID.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerClientID", "CustomerClientID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerClientCode", "CustomerClientCode"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerClientName", "CustomerClientName")});
            this.rle_CustomerClientID.Name = "rle_CustomerClientID";
            this.rle_CustomerClientID.NullText = "";
            this.rle_CustomerClientID.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(this.rle_CustomerClientID_CloseUp);
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Remain";
            this.gridColumn6.FieldName = "RemainQuantity";
            this.gridColumn6.MinWidth = 25;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            this.gridColumn6.Width = 55;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "RO";
            this.gridColumn7.ColumnEdit = this.rhe_ROID;
            this.gridColumn7.FieldName = "ReceivingOrderNumber";
            this.gridColumn7.MinWidth = 25;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            this.gridColumn7.Width = 78;
            // 
            // rhe_ROID
            // 
            this.rhe_ROID.AutoHeight = false;
            this.rhe_ROID.Name = "rhe_ROID";
            this.rhe_ROID.Click += new System.EventHandler(this.rhe_ROID_Click);
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "RODate";
            this.gridColumn8.FieldName = "ReceivingOrderDate";
            this.gridColumn8.MinWidth = 25;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 6;
            this.gridColumn8.Width = 93;
            // 
            // gridColumn9
            // 
            this.gridColumn9.ColumnEdit = this.rpi_btn_Delete;
            this.gridColumn9.MaxWidth = 44;
            this.gridColumn9.MinWidth = 44;
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 12;
            this.gridColumn9.Width = 44;
            // 
            // rpi_btn_Delete
            // 
            this.rpi_btn_Delete.AutoHeight = false;
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            this.rpi_btn_Delete.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.rpi_btn_Delete.Name = "rpi_btn_Delete";
            this.rpi_btn_Delete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.rpi_btn_Delete.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.rpi_btn_Delete_ButtonClick);
            // 
            // DispatchingByClientAssignmentID
            // 
            this.DispatchingByClientAssignmentID.Caption = "DispatchingByClientAssignmentID";
            this.DispatchingByClientAssignmentID.FieldName = "DispatchingByClientAssignmentID";
            this.DispatchingByClientAssignmentID.MinWidth = 27;
            this.DispatchingByClientAssignmentID.Name = "DispatchingByClientAssignmentID";
            this.DispatchingByClientAssignmentID.Width = 100;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "gridColumn10";
            this.gridColumn10.FieldName = "ProductID";
            this.gridColumn10.MinWidth = 25;
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Width = 94;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem42,
            this.layoutControlItem30,
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem3,
            this.layoutControlItem2});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1639, 789);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem42
            // 
            this.layoutControlItem42.Control = this.textCustomerName;
            this.layoutControlItem42.CustomizationFormText = "Customer Name";
            this.layoutControlItem42.Location = new System.Drawing.Point(218, 0);
            this.layoutControlItem42.Name = "layoutControlItem42";
            this.layoutControlItem42.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem42.Size = new System.Drawing.Size(469, 34);
            this.layoutControlItem42.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem42.Text = "layoutControlItem6";
            this.layoutControlItem42.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem42.TextVisible = false;
            // 
            // layoutControlItem30
            // 
            this.layoutControlItem30.Control = this.lkeCustomerID;
            this.layoutControlItem30.CustomizationFormText = "Customer";
            this.layoutControlItem30.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem30.Name = "layoutControlItem30";
            this.layoutControlItem30.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem30.Size = new System.Drawing.Size(218, 34);
            this.layoutControlItem30.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem30.Text = "Customer";
            this.layoutControlItem30.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem30.TextSize = new System.Drawing.Size(70, 16);
            this.layoutControlItem30.TextToControlDistance = 5;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grcDOAssignments;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 34);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1619, 735);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(1015, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(478, 34);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnAddNew;
            this.layoutControlItem3.Location = new System.Drawing.Point(1493, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(126, 34);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.checkEdit1;
            this.layoutControlItem2.Location = new System.Drawing.Point(687, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(328, 34);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // frm_WM_DispatchingByClientAssignment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1639, 789);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_WM_DispatchingByClientAssignment";
            this.Text = "Dispatching Order By Client Assignment";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textCustomerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeCustomerID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcDOAssignments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAssignments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rhe_ProductID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rle_CustomerClientID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rhe_ROID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_btn_Delete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem42)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.TextEdit textCustomerName;
        private DevExpress.XtraEditors.LookUpEdit lkeCustomerID;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem42;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem30;
        private DevExpress.XtraGrid.GridControl grcDOAssignments;
        private Common.Controls.WMSGridView grvAssignments;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rle_CustomerClientID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rpi_btn_Delete;
        private DevExpress.XtraGrid.Columns.GridColumn DispatchingByClientAssignmentID;
        private DevExpress.XtraEditors.SimpleButton btnAddNew;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rhe_ProductID;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rhe_ROID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
    }
}