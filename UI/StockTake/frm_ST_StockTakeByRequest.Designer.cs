using System;
using DevExpress.XtraGrid.Views.Grid;

namespace UI.StockTake
{
    partial class frm_ST_StockTakeByRequest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ST_StockTakeByRequest));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grdInputBaysToPrint = new DevExpress.XtraGrid.GridControl();
            this.grvInputBaysToPrint = new Common.Controls.WMSGridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_lke_Location = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtBayToPrintEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAisle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_lke_Aisles = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.grdCustomer = new DevExpress.XtraGrid.GridControl();
            this.grvCustomer = new Common.Controls.WMSGridView();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnRoomE = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnPreview = new DevExpress.XtraEditors.SimpleButton();
            this.btnDetails = new DevExpress.XtraEditors.SimpleButton();
            this.btnROReport = new DevExpress.XtraEditors.SimpleButton();
            this.btnManyProduct = new DevExpress.XtraEditors.SimpleButton();
            this.btnLostProduct = new DevExpress.XtraEditors.SimpleButton();
            this.btnOnFloorByCustomer = new DevExpress.XtraEditors.SimpleButton();
            this.btnOnFloorByRoom = new DevExpress.XtraEditors.SimpleButton();
            this.btnProduct = new DevExpress.XtraEditors.SimpleButton();
            this.dFrom = new DevExpress.XtraEditors.DateEdit();
            this.dTo = new DevExpress.XtraEditors.DateEdit();
            this.chkHideQuantity = new DevExpress.XtraEditors.CheckEdit();
            this.grdProductList = new DevExpress.XtraGrid.GridControl();
            this.grvProductList = new Common.Controls.WMSGridView();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnCreateProductChecking = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lciProduct = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem16 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdInputBaysToPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvInputBaysToPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_Location)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBayToPrintEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_Aisles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkHideQuantity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdProductList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProductList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).BeginInit();
            this.SuspendLayout();
            // 
            // rbcbase
            // 
            //this.rbcbase.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(26, 22, 26, 22);
            this.rbcbase.ExpandCollapseItem.Id = 0;
            this.rbcbase.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbcbase.OptionsCustomizationForm.FormIcon = ((System.Drawing.Icon)(resources.GetObject("resource.FormIcon")));
            this.rbcbase.OptionsMenuMinWidth = 283;
            // 
            // 
            // 
            this.rbcbase.SearchEditItem.AccessibleName = "Search Item";
            this.rbcbase.SearchEditItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.rbcbase.SearchEditItem.EditWidth = 150;
            this.rbcbase.SearchEditItem.Id = -5000;
            this.rbcbase.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.rbcbase.Size = new System.Drawing.Size(1072, 41);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grdInputBaysToPrint);
            this.layoutControl1.Controls.Add(this.grdCustomer);
            this.layoutControl1.Controls.Add(this.btnRoomE);
            this.layoutControl1.Controls.Add(this.btnClose);
            this.layoutControl1.Controls.Add(this.btnPreview);
            this.layoutControl1.Controls.Add(this.btnDetails);
            this.layoutControl1.Controls.Add(this.btnROReport);
            this.layoutControl1.Controls.Add(this.btnManyProduct);
            this.layoutControl1.Controls.Add(this.btnLostProduct);
            this.layoutControl1.Controls.Add(this.btnOnFloorByCustomer);
            this.layoutControl1.Controls.Add(this.btnOnFloorByRoom);
            this.layoutControl1.Controls.Add(this.btnProduct);
            this.layoutControl1.Controls.Add(this.dFrom);
            this.layoutControl1.Controls.Add(this.dTo);
            this.layoutControl1.Controls.Add(this.chkHideQuantity);
            this.layoutControl1.Controls.Add(this.grdProductList);
            this.layoutControl1.Controls.Add(this.btnCreateProductChecking);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 41);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1470, 260, 450, 400);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1072, 671);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grdInputBaysToPrint
            // 
            this.grdInputBaysToPrint.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.grdInputBaysToPrint.Location = new System.Drawing.Point(7, 8);
            this.grdInputBaysToPrint.MainView = this.grvInputBaysToPrint;
            this.grdInputBaysToPrint.Name = "grdInputBaysToPrint";
            this.grdInputBaysToPrint.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpi_lke_Location,
            this.rpi_lke_Aisles,
            this.txtBayToPrintEdit});
            this.grdInputBaysToPrint.Size = new System.Drawing.Size(451, 158);
            this.grdInputBaysToPrint.TabIndex = 4;
            this.grdInputBaysToPrint.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvInputBaysToPrint});
            // 
            // grvInputBaysToPrint
            // 
            this.grvInputBaysToPrint.Appearance.FooterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.grvInputBaysToPrint.Appearance.FooterPanel.Options.UseFont = true;
            this.grvInputBaysToPrint.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.colAisle});
            this.grvInputBaysToPrint.DetailHeight = 268;
            this.grvInputBaysToPrint.GridControl = this.grdInputBaysToPrint;
            this.grvInputBaysToPrint.Name = "grvInputBaysToPrint";
            this.grvInputBaysToPrint.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grvInputBaysToPrint.OptionsSelection.MultiSelect = true;
            this.grvInputBaysToPrint.OptionsView.ShowGroupPanel = false;
            this.grvInputBaysToPrint.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvInputBaysToPrint.PaintStyleName = "Skin";
            this.grvInputBaysToPrint.ShownEditor += new System.EventHandler(this.grvInputBaysToPrint_ShownEditor);
            this.grvInputBaysToPrint.FocusedColumnChanged += new DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventHandler(this.grvInputBaysToPrint_FocusedColumnChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "ROOM ID";
            this.gridColumn1.ColumnEdit = this.rpi_lke_Location;
            this.gridColumn1.FieldName = "RoomID";
            this.gridColumn1.MinWidth = 15;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 56;
            // 
            // rpi_lke_Location
            // 
            this.rpi_lke_Location.AutoHeight = false;
            this.rpi_lke_Location.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.rpi_lke_Location.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpi_lke_Location.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RoomID", "RoomID")});
            this.rpi_lke_Location.DropDownRows = 20;
            this.rpi_lke_Location.ImmediatePopup = true;
            this.rpi_lke_Location.Name = "rpi_lke_Location";
            this.rpi_lke_Location.NullText = "";
            this.rpi_lke_Location.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.StartsWith;
            this.rpi_lke_Location.ShowFooter = false;
            this.rpi_lke_Location.ShowHeader = false;
            this.rpi_lke_Location.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(this.rpi_lke_Location_CloseUp);
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "AISLE";
            this.gridColumn2.FieldName = "Aisle";
            this.gridColumn2.MinWidth = 15;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 56;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "BAYS";
            this.gridColumn3.ColumnEdit = this.txtBayToPrintEdit;
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn3.FieldName = "BaysToPrint";
            this.gridColumn3.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.gridColumn3.MinWidth = 15;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 56;
            // 
            // txtBayToPrintEdit
            // 
            this.txtBayToPrintEdit.AutoHeight = false;
            this.txtBayToPrintEdit.Mask.EditMask = "([0-9]+)*(([0-9]+)?([,]?[-]?)?([0-9])+)+([,-])?";
            this.txtBayToPrintEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtBayToPrintEdit.Name = "txtBayToPrintEdit";
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "HIGH";
            this.gridColumn4.FieldName = "HighsToPrint";
            this.gridColumn4.MinWidth = 15;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            this.gridColumn4.Width = 56;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "DEEP";
            this.gridColumn5.FieldName = "DeepsToPrint";
            this.gridColumn5.MinWidth = 15;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            this.gridColumn5.Width = 56;
            // 
            // colAisle
            // 
            this.colAisle.ColumnEdit = this.rpi_lke_Aisles;
            this.colAisle.MaxWidth = 7;
            this.colAisle.MinWidth = 10;
            this.colAisle.Name = "colAisle";
            this.colAisle.Visible = true;
            this.colAisle.VisibleIndex = 1;
            this.colAisle.Width = 10;
            // 
            // rpi_lke_Aisles
            // 
            this.rpi_lke_Aisles.AutoHeight = false;
            this.rpi_lke_Aisles.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.rpi_lke_Aisles.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpi_lke_Aisles.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RoomID", "RoomID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Aisle", "Aisle")});
            this.rpi_lke_Aisles.DisplayMember = "Aisle";
            this.rpi_lke_Aisles.DropDownRows = 10;
            this.rpi_lke_Aisles.ImmediatePopup = true;
            this.rpi_lke_Aisles.Name = "rpi_lke_Aisles";
            this.rpi_lke_Aisles.NullText = "";
            this.rpi_lke_Aisles.PopupWidthMode = DevExpress.XtraEditors.PopupWidthMode.ContentWidth;
            this.rpi_lke_Aisles.ValueMember = "AisleRoomID";
            this.rpi_lke_Aisles.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(this.rpi_lke_Aisles_CloseUp);
            // 
            // grdCustomer
            // 
            this.grdCustomer.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.grdCustomer.Location = new System.Drawing.Point(5, 172);
            this.grdCustomer.MainView = this.grvCustomer;
            this.grdCustomer.Name = "grdCustomer";
            this.grdCustomer.Size = new System.Drawing.Size(455, 365);
            this.grdCustomer.TabIndex = 4;
            this.grdCustomer.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvCustomer});
            // 
            // grvCustomer
            // 
            this.grvCustomer.Appearance.FooterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.grvCustomer.Appearance.FooterPanel.Options.UseFont = true;
            this.grvCustomer.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11});
            this.grvCustomer.DetailHeight = 268;
            this.grvCustomer.GridControl = this.grdCustomer;
            this.grvCustomer.Name = "grvCustomer";
            this.grvCustomer.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseUp;
            this.grvCustomer.OptionsBehavior.ReadOnly = true;
            this.grvCustomer.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grvCustomer.OptionsSelection.MultiSelect = true;
            this.grvCustomer.OptionsView.ShowGroupPanel = false;
            this.grvCustomer.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvCustomer.PaintStyleName = "Skin";
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "CUSTOMER ID";
            this.gridColumn6.FieldName = "CustomerID";
            this.gridColumn6.MinWidth = 15;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Width = 56;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "CUSTOMER ID";
            this.gridColumn7.FieldName = "CustomerNumber";
            this.gridColumn7.MinWidth = 15;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 0;
            this.gridColumn7.Width = 96;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "CUSTOMER NAME";
            this.gridColumn8.FieldName = "CustomerName";
            this.gridColumn8.MinWidth = 15;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 1;
            this.gridColumn8.Width = 441;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "CUSTOMER TYPE";
            this.gridColumn9.FieldName = "CustomerType";
            this.gridColumn9.MinWidth = 15;
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Width = 56;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "CUSTOMER DISCONTINUED";
            this.gridColumn10.FieldName = "CustomerDiscontinued";
            this.gridColumn10.MinWidth = 15;
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Width = 56;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "CUSTOMER MAIN ID";
            this.gridColumn11.FieldName = "CustomerMainID";
            this.gridColumn11.MinWidth = 15;
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Width = 56;
            // 
            // btnRoomE
            // 
            this.btnRoomE.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnRoomE.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnRoomE.Appearance.Options.UseBackColor = true;
            this.btnRoomE.Appearance.Options.UseFont = true;
            this.btnRoomE.Appearance.Options.UseTextOptions = true;
            this.btnRoomE.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.btnRoomE.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnRoomE.AppearanceDisabled.Options.UseTextOptions = true;
            this.btnRoomE.AppearanceDisabled.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.btnRoomE.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnRoomE.AppearanceHovered.Options.UseTextOptions = true;
            this.btnRoomE.AppearanceHovered.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.btnRoomE.AppearanceHovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnRoomE.AppearancePressed.Options.UseTextOptions = true;
            this.btnRoomE.AppearancePressed.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.btnRoomE.AppearancePressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnRoomE.Location = new System.Drawing.Point(541, 575);
            this.btnRoomE.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnRoomE.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnRoomE.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnRoomE.Name = "btnRoomE";
            this.btnRoomE.Size = new System.Drawing.Size(125, 40);
            this.btnRoomE.StyleController = this.layoutControl1;
            this.btnRoomE.TabIndex = 9;
            this.btnRoomE.Text = "Room E";
            // 
            // btnClose
            // 
            this.btnClose.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.btnClose.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnClose.Appearance.Options.UseBackColor = true;
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Appearance.Options.UseTextOptions = true;
            this.btnClose.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.btnClose.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnClose.AppearanceDisabled.Options.UseTextOptions = true;
            this.btnClose.AppearanceDisabled.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.btnClose.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnClose.AppearanceHovered.Options.UseTextOptions = true;
            this.btnClose.AppearanceHovered.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.btnClose.AppearanceHovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnClose.AppearancePressed.Options.UseTextOptions = true;
            this.btnClose.AppearancePressed.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.btnClose.AppearancePressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnClose.Location = new System.Drawing.Point(940, 575);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnClose.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnClose.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(125, 40);
            this.btnClose.StyleController = this.layoutControl1;
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            // 
            // btnPreview
            // 
            this.btnPreview.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnPreview.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnPreview.Appearance.Options.UseBackColor = true;
            this.btnPreview.Appearance.Options.UseFont = true;
            this.btnPreview.Appearance.Options.UseTextOptions = true;
            this.btnPreview.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.btnPreview.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnPreview.AppearanceDisabled.Options.UseTextOptions = true;
            this.btnPreview.AppearanceDisabled.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.btnPreview.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnPreview.AppearanceHovered.Options.UseTextOptions = true;
            this.btnPreview.AppearanceHovered.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.btnPreview.AppearanceHovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnPreview.AppearancePressed.Options.UseTextOptions = true;
            this.btnPreview.AppearancePressed.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.btnPreview.AppearancePressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnPreview.Location = new System.Drawing.Point(674, 575);
            this.btnPreview.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnPreview.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnPreview.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(125, 40);
            this.btnPreview.StyleController = this.layoutControl1;
            this.btnPreview.TabIndex = 9;
            this.btnPreview.Text = "Preview";
            // 
            // btnDetails
            // 
            this.btnDetails.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnDetails.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnDetails.Appearance.Options.UseBackColor = true;
            this.btnDetails.Appearance.Options.UseFont = true;
            this.btnDetails.Appearance.Options.UseTextOptions = true;
            this.btnDetails.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.btnDetails.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnDetails.AppearanceDisabled.Options.UseTextOptions = true;
            this.btnDetails.AppearanceDisabled.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.btnDetails.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnDetails.AppearanceHovered.Options.UseTextOptions = true;
            this.btnDetails.AppearanceHovered.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.btnDetails.AppearanceHovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnDetails.AppearancePressed.Options.UseTextOptions = true;
            this.btnDetails.AppearancePressed.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.btnDetails.AppearancePressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnDetails.Location = new System.Drawing.Point(408, 575);
            this.btnDetails.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnDetails.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnDetails.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(125, 40);
            this.btnDetails.StyleController = this.layoutControl1;
            this.btnDetails.TabIndex = 9;
            this.btnDetails.Text = "View Details";
            // 
            // btnROReport
            // 
            this.btnROReport.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnROReport.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnROReport.Appearance.Options.UseBackColor = true;
            this.btnROReport.Appearance.Options.UseFont = true;
            this.btnROReport.Appearance.Options.UseTextOptions = true;
            this.btnROReport.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.btnROReport.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnROReport.AppearanceDisabled.Options.UseTextOptions = true;
            this.btnROReport.AppearanceDisabled.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.btnROReport.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnROReport.AppearanceHovered.Options.UseTextOptions = true;
            this.btnROReport.AppearanceHovered.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.btnROReport.AppearanceHovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnROReport.AppearancePressed.Options.UseTextOptions = true;
            this.btnROReport.AppearancePressed.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.btnROReport.AppearancePressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnROReport.Location = new System.Drawing.Point(807, 575);
            this.btnROReport.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnROReport.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnROReport.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnROReport.Name = "btnROReport";
            this.btnROReport.Size = new System.Drawing.Size(125, 40);
            this.btnROReport.StyleController = this.layoutControl1;
            this.btnROReport.TabIndex = 9;
            this.btnROReport.Text = "RO Report";
            // 
            // btnManyProduct
            // 
            this.btnManyProduct.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnManyProduct.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnManyProduct.Appearance.Options.UseBackColor = true;
            this.btnManyProduct.Appearance.Options.UseFont = true;
            this.btnManyProduct.Appearance.Options.UseTextOptions = true;
            this.btnManyProduct.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.btnManyProduct.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnManyProduct.AppearanceDisabled.Options.UseTextOptions = true;
            this.btnManyProduct.AppearanceDisabled.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.btnManyProduct.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnManyProduct.AppearanceHovered.Options.UseTextOptions = true;
            this.btnManyProduct.AppearanceHovered.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.btnManyProduct.AppearanceHovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnManyProduct.AppearancePressed.Options.UseTextOptions = true;
            this.btnManyProduct.AppearancePressed.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.btnManyProduct.AppearancePressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnManyProduct.Location = new System.Drawing.Point(674, 623);
            this.btnManyProduct.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnManyProduct.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnManyProduct.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnManyProduct.Name = "btnManyProduct";
            this.btnManyProduct.Size = new System.Drawing.Size(125, 40);
            this.btnManyProduct.StyleController = this.layoutControl1;
            this.btnManyProduct.TabIndex = 9;
            this.btnManyProduct.Text = "Many Products\r\nDeep 2";
            this.btnManyProduct.Visible = false;
            // 
            // btnLostProduct
            // 
            this.btnLostProduct.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnLostProduct.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnLostProduct.Appearance.Options.UseBackColor = true;
            this.btnLostProduct.Appearance.Options.UseFont = true;
            this.btnLostProduct.Appearance.Options.UseTextOptions = true;
            this.btnLostProduct.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.btnLostProduct.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnLostProduct.AppearanceDisabled.Options.UseTextOptions = true;
            this.btnLostProduct.AppearanceDisabled.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.btnLostProduct.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnLostProduct.AppearanceHovered.Options.UseTextOptions = true;
            this.btnLostProduct.AppearanceHovered.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.btnLostProduct.AppearanceHovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnLostProduct.AppearancePressed.Options.UseTextOptions = true;
            this.btnLostProduct.AppearancePressed.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.btnLostProduct.AppearancePressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnLostProduct.Location = new System.Drawing.Point(807, 623);
            this.btnLostProduct.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnLostProduct.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnLostProduct.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnLostProduct.Name = "btnLostProduct";
            this.btnLostProduct.Size = new System.Drawing.Size(125, 40);
            this.btnLostProduct.StyleController = this.layoutControl1;
            this.btnLostProduct.TabIndex = 9;
            this.btnLostProduct.Text = "Lost Product\r\n(Room X)";
            this.btnLostProduct.Visible = false;
            // 
            // btnOnFloorByCustomer
            // 
            this.btnOnFloorByCustomer.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnOnFloorByCustomer.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnOnFloorByCustomer.Appearance.Options.UseBackColor = true;
            this.btnOnFloorByCustomer.Appearance.Options.UseFont = true;
            this.btnOnFloorByCustomer.Appearance.Options.UseTextOptions = true;
            this.btnOnFloorByCustomer.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.btnOnFloorByCustomer.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnOnFloorByCustomer.AppearanceDisabled.Options.UseTextOptions = true;
            this.btnOnFloorByCustomer.AppearanceDisabled.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.btnOnFloorByCustomer.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnOnFloorByCustomer.AppearanceHovered.Options.UseTextOptions = true;
            this.btnOnFloorByCustomer.AppearanceHovered.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.btnOnFloorByCustomer.AppearanceHovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnOnFloorByCustomer.AppearancePressed.Options.UseTextOptions = true;
            this.btnOnFloorByCustomer.AppearancePressed.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.btnOnFloorByCustomer.AppearancePressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnOnFloorByCustomer.Location = new System.Drawing.Point(541, 623);
            this.btnOnFloorByCustomer.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnOnFloorByCustomer.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnOnFloorByCustomer.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnOnFloorByCustomer.Name = "btnOnFloorByCustomer";
            this.btnOnFloorByCustomer.Size = new System.Drawing.Size(125, 40);
            this.btnOnFloorByCustomer.StyleController = this.layoutControl1;
            this.btnOnFloorByCustomer.TabIndex = 9;
            this.btnOnFloorByCustomer.Text = "On Floor \r\nBy Customer";
            this.btnOnFloorByCustomer.Visible = false;
            // 
            // btnOnFloorByRoom
            // 
            this.btnOnFloorByRoom.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnOnFloorByRoom.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnOnFloorByRoom.Appearance.Options.UseBackColor = true;
            this.btnOnFloorByRoom.Appearance.Options.UseFont = true;
            this.btnOnFloorByRoom.Appearance.Options.UseTextOptions = true;
            this.btnOnFloorByRoom.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.btnOnFloorByRoom.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnOnFloorByRoom.AppearanceDisabled.Options.UseTextOptions = true;
            this.btnOnFloorByRoom.AppearanceDisabled.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.btnOnFloorByRoom.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnOnFloorByRoom.AppearanceHovered.Options.UseTextOptions = true;
            this.btnOnFloorByRoom.AppearanceHovered.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.btnOnFloorByRoom.AppearanceHovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnOnFloorByRoom.AppearancePressed.Options.UseTextOptions = true;
            this.btnOnFloorByRoom.AppearancePressed.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.btnOnFloorByRoom.AppearancePressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnOnFloorByRoom.Location = new System.Drawing.Point(408, 623);
            this.btnOnFloorByRoom.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnOnFloorByRoom.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnOnFloorByRoom.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnOnFloorByRoom.Name = "btnOnFloorByRoom";
            this.btnOnFloorByRoom.Size = new System.Drawing.Size(125, 40);
            this.btnOnFloorByRoom.StyleController = this.layoutControl1;
            this.btnOnFloorByRoom.TabIndex = 9;
            this.btnOnFloorByRoom.Text = "On Floor \r\nBy Room";
            this.btnOnFloorByRoom.Visible = false;
            // 
            // btnProduct
            // 
            this.btnProduct.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnProduct.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnProduct.Appearance.Options.UseBackColor = true;
            this.btnProduct.Appearance.Options.UseFont = true;
            this.btnProduct.Appearance.Options.UseTextOptions = true;
            this.btnProduct.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.btnProduct.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnProduct.AppearanceDisabled.Options.UseTextOptions = true;
            this.btnProduct.AppearanceDisabled.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.btnProduct.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnProduct.AppearanceHovered.Options.UseTextOptions = true;
            this.btnProduct.AppearanceHovered.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.btnProduct.AppearanceHovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnProduct.AppearancePressed.Options.UseTextOptions = true;
            this.btnProduct.AppearancePressed.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.btnProduct.AppearancePressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnProduct.Location = new System.Drawing.Point(275, 575);
            this.btnProduct.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnProduct.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnProduct.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(125, 40);
            this.btnProduct.StyleController = this.layoutControl1;
            this.btnProduct.TabIndex = 9;
            this.btnProduct.Text = "View By Product";
            // 
            // dFrom
            // 
            this.dFrom.EditValue = null;
            this.dFrom.Location = new System.Drawing.Point(83, 543);
            this.dFrom.Margin = new System.Windows.Forms.Padding(2);
            this.dFrom.MenuManager = this.rbcbase;
            this.dFrom.MinimumSize = new System.Drawing.Size(0, 24);
            this.dFrom.Name = "dFrom";
            this.dFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dFrom.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dFrom.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dFrom.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dFrom.Size = new System.Drawing.Size(115, 24);
            this.dFrom.StyleController = this.layoutControl1;
            this.dFrom.TabIndex = 10;
            // 
            // dTo
            // 
            this.dTo.EditValue = null;
            this.dTo.Location = new System.Drawing.Point(223, 543);
            this.dTo.Margin = new System.Windows.Forms.Padding(2);
            this.dTo.MaximumSize = new System.Drawing.Size(0, 23);
            this.dTo.MinimumSize = new System.Drawing.Size(100, 24);
            this.dTo.Name = "dTo";
            this.dTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dTo.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dTo.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dTo.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dTo.Size = new System.Drawing.Size(105, 24);
            this.dTo.StyleController = this.layoutControl1;
            this.dTo.TabIndex = 11;
            // 
            // chkHideQuantity
            // 
            this.chkHideQuantity.Location = new System.Drawing.Point(346, 543);
            this.chkHideQuantity.Margin = new System.Windows.Forms.Padding(2);
            this.chkHideQuantity.MenuManager = this.rbcbase;
            this.chkHideQuantity.Name = "chkHideQuantity";
            this.chkHideQuantity.Properties.Caption = "Hide Quantity:";
            this.chkHideQuantity.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.chkHideQuantity.Size = new System.Drawing.Size(112, 20);
            this.chkHideQuantity.StyleController = this.layoutControl1;
            this.chkHideQuantity.TabIndex = 12;
            // 
            // grdProductList
            // 
            this.grdProductList.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.grdProductList.Location = new System.Drawing.Point(466, 8);
            this.grdProductList.MainView = this.grvProductList;
            this.grdProductList.Name = "grdProductList";
            this.grdProductList.Size = new System.Drawing.Size(599, 559);
            this.grdProductList.TabIndex = 4;
            this.grdProductList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvProductList});
            // 
            // grvProductList
            // 
            this.grvProductList.Appearance.FooterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.grvProductList.Appearance.FooterPanel.Options.UseFont = true;
            this.grvProductList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14});
            this.grvProductList.DetailHeight = 268;
            this.grvProductList.GridControl = this.grdProductList;
            this.grvProductList.Name = "grvProductList";
            this.grvProductList.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grvProductList.OptionsSelection.MultiSelect = true;
            this.grvProductList.OptionsView.ShowGroupPanel = false;
            this.grvProductList.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvProductList.PaintStyleName = "Skin";
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "PRODUCT ID";
            this.gridColumn12.FieldName = "ProductNumber";
            this.gridColumn12.MinWidth = 15;
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 0;
            this.gridColumn12.Width = 97;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "PRODUCT NAME";
            this.gridColumn13.FieldName = "Name";
            this.gridColumn13.MinWidth = 15;
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 1;
            this.gridColumn13.Width = 380;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "QTY";
            this.gridColumn14.FieldName = "Qty";
            this.gridColumn14.MinWidth = 15;
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 2;
            this.gridColumn14.Width = 92;
            // 
            // btnCreateProductChecking
            // 
            this.btnCreateProductChecking.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnCreateProductChecking.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnCreateProductChecking.Appearance.Options.UseBackColor = true;
            this.btnCreateProductChecking.Appearance.Options.UseFont = true;
            this.btnCreateProductChecking.Appearance.Options.UseTextOptions = true;
            this.btnCreateProductChecking.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.btnCreateProductChecking.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnCreateProductChecking.AppearanceDisabled.Options.UseTextOptions = true;
            this.btnCreateProductChecking.AppearanceDisabled.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.btnCreateProductChecking.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnCreateProductChecking.AppearanceHovered.Options.UseTextOptions = true;
            this.btnCreateProductChecking.AppearanceHovered.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.btnCreateProductChecking.AppearanceHovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnCreateProductChecking.AppearancePressed.Options.UseTextOptions = true;
            this.btnCreateProductChecking.AppearancePressed.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.btnCreateProductChecking.AppearancePressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnCreateProductChecking.Location = new System.Drawing.Point(940, 623);
            this.btnCreateProductChecking.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnCreateProductChecking.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnCreateProductChecking.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnCreateProductChecking.Name = "btnCreateProductChecking";
            this.btnCreateProductChecking.Size = new System.Drawing.Size(125, 40);
            this.btnCreateProductChecking.StyleController = this.layoutControl1;
            this.btnCreateProductChecking.TabIndex = 9;
            this.btnCreateProductChecking.Text = "Product Checking";
            this.btnCreateProductChecking.Click += new System.EventHandler(this.btnCreateProductChecking_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem14,
            this.layoutControlItem13,
            this.layoutControlItem15,
            this.emptySpaceItem1,
            this.lciProduct,
            this.layoutControlItem3,
            this.layoutControlItem12,
            this.emptySpaceItem2,
            this.layoutControlItem5,
            this.emptySpaceItem3,
            this.layoutControlItem11,
            this.layoutControlItem6,
            this.layoutControlItem4,
            this.layoutControlItem7,
            this.layoutControlItem9,
            this.layoutControlItem16,
            this.layoutControlItem10,
            this.layoutControlItem8});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 4, 4);
            this.layoutControlGroup1.Size = new System.Drawing.Size(1072, 671);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdInputBaysToPrint;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(0, 166);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(459, 166);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(459, 166);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.grdCustomer;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 166);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(459, 369);
            this.layoutControlItem2.Text = "layoutControlItem1";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem14
            // 
            this.layoutControlItem14.Control = this.dTo;
            this.layoutControlItem14.Location = new System.Drawing.Point(199, 535);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Size = new System.Drawing.Size(130, 32);
            this.layoutControlItem14.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem14.Text = "To";
            this.layoutControlItem14.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem14.TextSize = new System.Drawing.Size(12, 13);
            this.layoutControlItem14.TextToControlDistance = 5;
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.Control = this.dFrom;
            this.layoutControlItem13.Location = new System.Drawing.Point(0, 535);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new System.Drawing.Size(199, 32);
            this.layoutControlItem13.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem13.Text = "RO date: From";
            this.layoutControlItem13.TextSize = new System.Drawing.Size(71, 13);
            // 
            // layoutControlItem15
            // 
            this.layoutControlItem15.Control = this.chkHideQuantity;
            this.layoutControlItem15.Location = new System.Drawing.Point(339, 535);
            this.layoutControlItem15.Name = "layoutControlItem15";
            this.layoutControlItem15.Size = new System.Drawing.Size(120, 32);
            this.layoutControlItem15.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem15.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem15.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(329, 535);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(10, 32);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lciProduct
            // 
            this.lciProduct.Control = this.grdProductList;
            this.lciProduct.CustomizationFormText = "layoutControlItem1";
            this.lciProduct.Location = new System.Drawing.Point(459, 0);
            this.lciProduct.Name = "lciProduct";
            this.lciProduct.Size = new System.Drawing.Size(607, 567);
            this.lciProduct.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.lciProduct.Text = "layoutControlItem1";
            this.lciProduct.TextSize = new System.Drawing.Size(0, 0);
            this.lciProduct.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnClose;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem3.Location = new System.Drawing.Point(933, 567);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(133, 48);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem3.Text = "layoutControlItem6";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.btnProduct;
            this.layoutControlItem12.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem12.Location = new System.Drawing.Point(268, 567);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(133, 48);
            this.layoutControlItem12.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem12.Text = "layoutControlItem6";
            this.layoutControlItem12.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem12.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 567);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(268, 48);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnDetails;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem5.Location = new System.Drawing.Point(401, 567);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(133, 48);
            this.layoutControlItem5.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem5.Text = "layoutControlItem6";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 615);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(401, 48);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            this.emptySpaceItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.btnOnFloorByRoom;
            this.layoutControlItem11.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem11.Location = new System.Drawing.Point(401, 615);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(133, 48);
            this.layoutControlItem11.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem11.Text = "layoutControlItem6";
            this.layoutControlItem11.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem11.TextVisible = false;
            this.layoutControlItem11.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnRoomE;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.Location = new System.Drawing.Point(534, 567);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(133, 48);
            this.layoutControlItem6.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnPreview;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem4.Location = new System.Drawing.Point(667, 567);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(133, 48);
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem4.Text = "layoutControlItem6";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.btnOnFloorByCustomer;
            this.layoutControlItem10.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem10.Location = new System.Drawing.Point(534, 615);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(133, 48);
            this.layoutControlItem10.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem10.Text = "layoutControlItem6";
            this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem10.TextVisible = false;
            this.layoutControlItem10.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.btnManyProduct;
            this.layoutControlItem8.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem8.Location = new System.Drawing.Point(667, 615);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(133, 48);
            this.layoutControlItem8.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem8.Text = "layoutControlItem6";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            this.layoutControlItem8.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.btnROReport;
            this.layoutControlItem7.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem7.Location = new System.Drawing.Point(800, 567);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(133, 48);
            this.layoutControlItem7.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem7.Text = "layoutControlItem6";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.btnLostProduct;
            this.layoutControlItem9.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem9.Location = new System.Drawing.Point(800, 615);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(133, 48);
            this.layoutControlItem9.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem9.Text = "layoutControlItem6";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            this.layoutControlItem9.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutControlItem16
            // 
            this.layoutControlItem16.Control = this.btnCreateProductChecking;
            this.layoutControlItem16.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem16.Location = new System.Drawing.Point(933, 615);
            this.layoutControlItem16.Name = "layoutControlItem16";
            this.layoutControlItem16.Size = new System.Drawing.Size(133, 48);
            this.layoutControlItem16.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem16.Text = "layoutControlItem6";
            this.layoutControlItem16.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem16.TextVisible = false;
            this.layoutControlItem16.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // frm_ST_StockTakeByRequest
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 712);
            this.Controls.Add(this.layoutControl1);
            this.Font = new System.Drawing.Font("Tahoma", 7.8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_ST_StockTakeByRequest.IconOptions.Icon")));
            this.IsFixHeightScreen = false;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frm_ST_StockTakeByRequest";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "Stock Take By Request";
            this.Closed += new System.EventHandler(this.frm_ST_StockTakeByRequest_Close);
            this.Load += new System.EventHandler(this.frm_ST_StockTakeByRequest_Load);
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdInputBaysToPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvInputBaysToPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_Location)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBayToPrintEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_Aisles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkHideQuantity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdProductList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProductList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        
        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl grdInputBaysToPrint;
        private Common.Controls.WMSGridView grvInputBaysToPrint;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.GridControl grdCustomer;
        private Common.Controls.WMSGridView grvCustomer;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SimpleButton btnRoomE;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnPreview;
        private DevExpress.XtraEditors.SimpleButton btnDetails;
        private DevExpress.XtraEditors.SimpleButton btnROReport;
        private DevExpress.XtraEditors.SimpleButton btnManyProduct;
        private DevExpress.XtraEditors.SimpleButton btnLostProduct;
        private DevExpress.XtraEditors.SimpleButton btnOnFloorByCustomer;
        private DevExpress.XtraEditors.SimpleButton btnOnFloorByRoom;
        private DevExpress.XtraEditors.SimpleButton btnProduct;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpi_lke_Location;
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
        private DevExpress.XtraEditors.DateEdit dFrom;
        private DevExpress.XtraEditors.DateEdit dTo;
        private DevExpress.XtraEditors.CheckEdit chkHideQuantity;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem14;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem13;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem15;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.GridControl grdProductList;
        private Common.Controls.WMSGridView grvProductList;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraLayout.LayoutControlItem lciProduct;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpi_lke_Aisles;
        private DevExpress.XtraGrid.Columns.GridColumn colAisle;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtBayToPrintEdit;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraEditors.SimpleButton btnCreateProductChecking;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem16;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
    }
}