namespace UI.Management
{
    partial class frm_M_GO_StockOnHandAllCustomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_M_GO_StockOnHandAllCustomer));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.lkeWarehouse = new DevExpress.XtraEditors.LookUpEdit();
            this.grdStockOnHand = new DevExpress.XtraGrid.GridControl();
            this.grvStockOnHand = new Common.Controls.WMSGridView();
            this.grcCustomerNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcPallets = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcView = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_btn_View = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.grcRoom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_btn_Room = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.grcCustomerInfo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_btn_CustomerInfo = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.grcCustomerID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lkeRooms = new DevExpress.XtraEditors.LookUpEdit();
            this.chkAll = new DevExpress.XtraEditors.CheckEdit();
            this.chkRoom = new DevExpress.XtraEditors.CheckEdit();
            this.chkWarehouse = new DevExpress.XtraEditors.CheckEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.grcWeightCurrent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcGrossWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcGrossWeightCurrent = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkeWarehouse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdStockOnHand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvStockOnHand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_btn_View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_btn_Room)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_btn_CustomerInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeRooms.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRoom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkWarehouse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
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
            this.rbcbase.SearchEditItem.UseEditorPadding = false;
            this.rbcbase.Size = new System.Drawing.Size(1183, 40);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.lkeWarehouse);
            this.layoutControl1.Controls.Add(this.grdStockOnHand);
            this.layoutControl1.Controls.Add(this.lkeRooms);
            this.layoutControl1.Controls.Add(this.chkAll);
            this.layoutControl1.Controls.Add(this.chkRoom);
            this.layoutControl1.Controls.Add(this.chkWarehouse);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 40);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(613, 249, 562, 500);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1183, 702);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // lkeWarehouse
            // 
            this.lkeWarehouse.Location = new System.Drawing.Point(559, 19);
            this.lkeWarehouse.MenuManager = this.rbcbase;
            this.lkeWarehouse.Name = "lkeWarehouse";
            this.lkeWarehouse.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lkeWarehouse.Properties.Appearance.Options.UseFont = true;
            this.lkeWarehouse.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeWarehouse.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("WarehouseID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("WarehouseDescription", "Name", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lkeWarehouse.Properties.DropDownRows = 2;
            this.lkeWarehouse.Properties.NullText = "";
            this.lkeWarehouse.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.lkeWarehouse.Properties.ReadOnly = true;
            this.lkeWarehouse.Properties.ShowFooter = false;
            this.lkeWarehouse.Properties.ShowHeader = false;
            this.lkeWarehouse.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lkeWarehouse.Size = new System.Drawing.Size(151, 24);
            this.lkeWarehouse.StyleController = this.layoutControl1;
            this.lkeWarehouse.TabIndex = 10;
            // 
            // grdStockOnHand
            // 
            this.grdStockOnHand.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.grdStockOnHand.Location = new System.Drawing.Point(12, 54);
            this.grdStockOnHand.MainView = this.grvStockOnHand;
            this.grdStockOnHand.MenuManager = this.rbcbase;
            this.grdStockOnHand.Name = "grdStockOnHand";
            this.grdStockOnHand.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpi_btn_CustomerInfo,
            this.rpi_btn_View,
            this.rpi_btn_Room});
            this.grdStockOnHand.Size = new System.Drawing.Size(1159, 636);
            this.grdStockOnHand.TabIndex = 9;
            this.grdStockOnHand.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvStockOnHand});
            // 
            // grvStockOnHand
            // 
            this.grvStockOnHand.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grvStockOnHand.Appearance.FooterPanel.Options.UseFont = true;
            this.grvStockOnHand.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvStockOnHand.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grcCustomerNumber,
            this.grcCustomerName,
            this.grcQuantity,
            this.grcPallets,
            this.grcWeight,
            this.grcView,
            this.grcRoom,
            this.grcCustomerInfo,
            this.grcCustomerID,
            this.grcWeightCurrent,
            this.grcGrossWeight,
            this.grcGrossWeightCurrent});
            this.grvStockOnHand.FixedLineWidth = 3;
            this.grvStockOnHand.GridControl = this.grdStockOnHand;
            this.grvStockOnHand.Name = "grvStockOnHand";
            this.grvStockOnHand.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvStockOnHand.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grvStockOnHand.OptionsSelection.MultiSelect = true;
            this.grvStockOnHand.OptionsView.ShowFooter = true;
            this.grvStockOnHand.OptionsView.ShowGroupPanel = false;
            this.grvStockOnHand.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvStockOnHand.PaintStyleName = "Skin";
            // 
            // grcCustomerNumber
            // 
            this.grcCustomerNumber.Caption = "CUSTOMER ID";
            this.grcCustomerNumber.FieldName = "CustomerNumber";
            this.grcCustomerNumber.MinWidth = 100;
            this.grcCustomerNumber.Name = "grcCustomerNumber";
            this.grcCustomerNumber.OptionsColumn.ReadOnly = true;
            this.grcCustomerNumber.Visible = true;
            this.grcCustomerNumber.VisibleIndex = 0;
            this.grcCustomerNumber.Width = 125;
            // 
            // grcCustomerName
            // 
            this.grcCustomerName.AppearanceHeader.Options.UseTextOptions = true;
            this.grcCustomerName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcCustomerName.Caption = "CUSTOMER NAME";
            this.grcCustomerName.FieldName = "CustomerName";
            this.grcCustomerName.Name = "grcCustomerName";
            this.grcCustomerName.OptionsColumn.ReadOnly = true;
            this.grcCustomerName.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "CustomerName", "TOTAL:")});
            this.grcCustomerName.Visible = true;
            this.grcCustomerName.VisibleIndex = 1;
            this.grcCustomerName.Width = 464;
            // 
            // grcQuantity
            // 
            this.grcQuantity.AppearanceCell.Options.UseTextOptions = true;
            this.grcQuantity.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grcQuantity.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcQuantity.AppearanceHeader.Options.UseTextOptions = true;
            this.grcQuantity.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grcQuantity.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcQuantity.Caption = "Qty";
            this.grcQuantity.DisplayFormat.FormatString = "n0";
            this.grcQuantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.grcQuantity.FieldName = "Qty";
            this.grcQuantity.MaxWidth = 80;
            this.grcQuantity.MinWidth = 80;
            this.grcQuantity.Name = "grcQuantity";
            this.grcQuantity.OptionsColumn.ReadOnly = true;
            this.grcQuantity.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Qty", "{0:n0}")});
            this.grcQuantity.Visible = true;
            this.grcQuantity.VisibleIndex = 2;
            this.grcQuantity.Width = 80;
            // 
            // grcPallets
            // 
            this.grcPallets.AppearanceCell.Options.UseTextOptions = true;
            this.grcPallets.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grcPallets.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcPallets.AppearanceHeader.Options.UseTextOptions = true;
            this.grcPallets.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grcPallets.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcPallets.Caption = "PALLETS";
            this.grcPallets.DisplayFormat.FormatString = "n0";
            this.grcPallets.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.grcPallets.FieldName = "Pallets";
            this.grcPallets.MaxWidth = 80;
            this.grcPallets.MinWidth = 80;
            this.grcPallets.Name = "grcPallets";
            this.grcPallets.OptionsColumn.ReadOnly = true;
            this.grcPallets.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Pallets", "{0:n0}")});
            this.grcPallets.Visible = true;
            this.grcPallets.VisibleIndex = 3;
            this.grcPallets.Width = 80;
            // 
            // grcWeight
            // 
            this.grcWeight.AppearanceCell.Options.UseTextOptions = true;
            this.grcWeight.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grcWeight.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcWeight.AppearanceHeader.Options.UseTextOptions = true;
            this.grcWeight.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grcWeight.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcWeight.Caption = "WEIGHT";
            this.grcWeight.DisplayFormat.FormatString = "n5";
            this.grcWeight.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.grcWeight.FieldName = "Weight";
            this.grcWeight.MaxWidth = 100;
            this.grcWeight.MinWidth = 100;
            this.grcWeight.Name = "grcWeight";
            this.grcWeight.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Weight", "{0:n0}")});
            this.grcWeight.Visible = true;
            this.grcWeight.VisibleIndex = 4;
            this.grcWeight.Width = 100;
            // 
            // grcView
            // 
            this.grcView.Caption = "VIEW";
            this.grcView.ColumnEdit = this.rpi_btn_View;
            this.grcView.MinWidth = 35;
            this.grcView.Name = "grcView";
            this.grcView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.grcView.Visible = true;
            this.grcView.VisibleIndex = 5;
            this.grcView.Width = 67;
            // 
            // rpi_btn_View
            // 
            this.rpi_btn_View.AutoHeight = false;
            this.rpi_btn_View.Name = "rpi_btn_View";
            this.rpi_btn_View.NullText = "View";
            // 
            // grcRoom
            // 
            this.grcRoom.Caption = "ROOM";
            this.grcRoom.ColumnEdit = this.rpi_btn_Room;
            this.grcRoom.MinWidth = 35;
            this.grcRoom.Name = "grcRoom";
            this.grcRoom.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.grcRoom.Visible = true;
            this.grcRoom.VisibleIndex = 6;
            this.grcRoom.Width = 76;
            // 
            // rpi_btn_Room
            // 
            this.rpi_btn_Room.AutoHeight = false;
            this.rpi_btn_Room.Name = "rpi_btn_Room";
            this.rpi_btn_Room.NullText = "Room";
            // 
            // grcCustomerInfo
            // 
            this.grcCustomerInfo.Caption = "INFO";
            this.grcCustomerInfo.ColumnEdit = this.rpi_btn_CustomerInfo;
            this.grcCustomerInfo.MinWidth = 35;
            this.grcCustomerInfo.Name = "grcCustomerInfo";
            this.grcCustomerInfo.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.grcCustomerInfo.Visible = true;
            this.grcCustomerInfo.VisibleIndex = 7;
            this.grcCustomerInfo.Width = 137;
            // 
            // rpi_btn_CustomerInfo
            // 
            this.rpi_btn_CustomerInfo.AutoHeight = false;
            this.rpi_btn_CustomerInfo.Name = "rpi_btn_CustomerInfo";
            this.rpi_btn_CustomerInfo.NullText = "Info";
            // 
            // grcCustomerID
            // 
            this.grcCustomerID.Caption = "ID";
            this.grcCustomerID.FieldName = "CustomerID";
            this.grcCustomerID.Name = "grcCustomerID";
            this.grcCustomerID.OptionsColumn.AllowShowHide = false;
            this.grcCustomerID.OptionsColumn.ReadOnly = true;
            // 
            // lkeRooms
            // 
            this.lkeRooms.Location = new System.Drawing.Point(228, 19);
            this.lkeRooms.MenuManager = this.rbcbase;
            this.lkeRooms.Name = "lkeRooms";
            this.lkeRooms.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lkeRooms.Properties.Appearance.Options.UseFont = true;
            this.lkeRooms.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeRooms.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RoomID", "Room", 50, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lkeRooms.Properties.DropDownRows = 20;
            this.lkeRooms.Properties.NullText = "";
            this.lkeRooms.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.lkeRooms.Properties.ReadOnly = true;
            this.lkeRooms.Properties.ShowFooter = false;
            this.lkeRooms.Properties.ShowHeader = false;
            this.lkeRooms.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lkeRooms.Size = new System.Drawing.Size(177, 24);
            this.lkeRooms.StyleController = this.layoutControl1;
            this.lkeRooms.TabIndex = 8;
            // 
            // chkAll
            // 
            this.chkAll.Location = new System.Drawing.Point(17, 19);
            this.chkAll.MenuManager = this.rbcbase;
            this.chkAll.Name = "chkAll";
            this.chkAll.Properties.Caption = "All";
            this.chkAll.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.chkAll.Size = new System.Drawing.Size(100, 22);
            this.chkAll.StyleController = this.layoutControl1;
            this.chkAll.TabIndex = 4;
            this.chkAll.Tag = "1";
            // 
            // chkRoom
            // 
            this.chkRoom.Location = new System.Drawing.Point(121, 19);
            this.chkRoom.MenuManager = this.rbcbase;
            this.chkRoom.Name = "chkRoom";
            this.chkRoom.Properties.Caption = "Room";
            this.chkRoom.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.chkRoom.Size = new System.Drawing.Size(103, 22);
            this.chkRoom.StyleController = this.layoutControl1;
            this.chkRoom.TabIndex = 5;
            this.chkRoom.Tag = "2";
            // 
            // chkWarehouse
            // 
            this.chkWarehouse.Location = new System.Drawing.Point(409, 19);
            this.chkWarehouse.MenuManager = this.rbcbase;
            this.chkWarehouse.Name = "chkWarehouse";
            this.chkWarehouse.Properties.Caption = "Warehouse";
            this.chkWarehouse.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.chkWarehouse.Size = new System.Drawing.Size(146, 22);
            this.chkWarehouse.StyleController = this.layoutControl1;
            this.chkWarehouse.TabIndex = 6;
            this.chkWarehouse.Tag = "3";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem6,
            this.emptySpaceItem1,
            this.layoutControlGroup2});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1183, 702);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.grdStockOnHand;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 42);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(1163, 640);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(707, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(456, 42);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem5,
            this.layoutControlItem2,
            this.layoutControlItem1,
            this.layoutControlItem4});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlGroup2.Size = new System.Drawing.Size(707, 42);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.chkWarehouse;
            this.layoutControlItem3.Location = new System.Drawing.Point(392, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem3.Size = new System.Drawing.Size(150, 32);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.lkeRooms;
            this.layoutControlItem5.Location = new System.Drawing.Point(211, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem5.Size = new System.Drawing.Size(181, 32);
            this.layoutControlItem5.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.chkRoom;
            this.layoutControlItem2.Location = new System.Drawing.Point(104, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem2.Size = new System.Drawing.Size(107, 32);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.chkAll;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem1.Size = new System.Drawing.Size(104, 32);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.lkeWarehouse;
            this.layoutControlItem4.Location = new System.Drawing.Point(542, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem4.Size = new System.Drawing.Size(155, 32);
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // grcWeightCurrent
            // 
            this.grcWeightCurrent.Caption = "WeightCurrent";
            this.grcWeightCurrent.FieldName = "WeightCurrent";
            this.grcWeightCurrent.MinWidth = 25;
            this.grcWeightCurrent.Name = "grcWeightCurrent";
            this.grcWeightCurrent.Width = 94;
            // 
            // grcGrossWeight
            // 
            this.grcGrossWeight.Caption = "GrossWeight";
            this.grcGrossWeight.FieldName = "GrossWeight";
            this.grcGrossWeight.MinWidth = 25;
            this.grcGrossWeight.Name = "grcGrossWeight";
            this.grcGrossWeight.Width = 94;
            // 
            // grcGrossWeightCurrent
            // 
            this.grcGrossWeightCurrent.Caption = "GrossWeightCurrent";
            this.grcGrossWeightCurrent.FieldName = "GrossWeightCurrent";
            this.grcGrossWeightCurrent.MinWidth = 25;
            this.grcGrossWeightCurrent.Name = "grcGrossWeightCurrent";
            this.grcGrossWeightCurrent.Width = 94;
            // 
            // frm_M_GO_StockOnHandAllCustomer
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1183, 742);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_M_GO_StockOnHandAllCustomer";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "Stock On Hand All Customers";
            this.Load += new System.EventHandler(this.frm_M_GO_StockOnHandAllCustomer_Load);
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lkeWarehouse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdStockOnHand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvStockOnHand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_btn_View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_btn_Room)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_btn_CustomerInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeRooms.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRoom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkWarehouse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl grdStockOnHand;
        private Common.Controls.WMSGridView grvStockOnHand;
        private DevExpress.XtraEditors.LookUpEdit lkeRooms;
        private DevExpress.XtraEditors.CheckEdit chkAll;
        private DevExpress.XtraEditors.CheckEdit chkRoom;
        private DevExpress.XtraEditors.CheckEdit chkWarehouse;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerInfo;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerNumber;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn grcQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn grcPallets;
        private DevExpress.XtraGrid.Columns.GridColumn grcWeight;
        private DevExpress.XtraGrid.Columns.GridColumn grcView;
        private DevExpress.XtraGrid.Columns.GridColumn grcRoom;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerID;
        private DevExpress.XtraEditors.LookUpEdit lkeWarehouse;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpi_btn_CustomerInfo;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpi_btn_View;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpi_btn_Room;
        private DevExpress.XtraGrid.Columns.GridColumn grcWeightCurrent;
        private DevExpress.XtraGrid.Columns.GridColumn grcGrossWeight;
        private DevExpress.XtraGrid.Columns.GridColumn grcGrossWeightCurrent;
    }
}