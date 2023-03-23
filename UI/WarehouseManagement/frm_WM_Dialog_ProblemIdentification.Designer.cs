namespace UI.WarehouseManagement
{
    partial class frm_WM_Dialog_ProblemIdentification
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_WM_Dialog_ProblemIdentification));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.lkeLocations = new DevExpress.XtraEditors.LookUpEdit();
            this.grdProblems = new DevExpress.XtraGrid.GridControl();
            this.grvProblems = new Common.Controls.WMSGridView();
            this.grcCustomerNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcProductNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcOrderNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_hle_OrderID = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.grcLocationNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcEmployeeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcOrderID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dtFrom = new DevExpress.XtraEditors.DateEdit();
            this.dtTo = new DevExpress.XtraEditors.DateEdit();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkeLocations.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdProblems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProblems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_hle_OrderID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
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
            this.rbcbase.Size = new System.Drawing.Size(1267, 51);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.lkeLocations);
            this.layoutControl1.Controls.Add(this.grdProblems);
            this.layoutControl1.Controls.Add(this.dtFrom);
            this.layoutControl1.Controls.Add(this.dtTo);
            this.layoutControl1.Controls.Add(this.btnRefresh);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 51);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(595, 129, 450, 400);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1267, 434);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // lkeLocations
            // 
            this.lkeLocations.Location = new System.Drawing.Point(68, 16);
            this.lkeLocations.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lkeLocations.MenuManager = this.rbcbase;
            this.lkeLocations.MinimumSize = new System.Drawing.Size(0, 24);
            this.lkeLocations.Name = "lkeLocations";
            this.lkeLocations.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeLocations.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationID", "ID", 100, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationNumberShort", "Short"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationNumber", "Number", 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lkeLocations.Properties.DropDownRows = 20;
            this.lkeLocations.Properties.NullText = "";
            this.lkeLocations.Properties.PopupFormMinSize = new System.Drawing.Size(300, 0);
            this.lkeLocations.Properties.ShowFooter = false;
            this.lkeLocations.Properties.ShowHeader = false;
            this.lkeLocations.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lkeLocations.Size = new System.Drawing.Size(145, 26);
            this.lkeLocations.StyleController = this.layoutControl1;
            this.lkeLocations.TabIndex = 5;
            // 
            // grdProblems
            // 
            this.grdProblems.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.grdProblems.Location = new System.Drawing.Point(14, 49);
            this.grdProblems.MainView = this.grvProblems;
            this.grdProblems.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdProblems.MenuManager = this.rbcbase;
            this.grdProblems.Name = "grdProblems";
            this.grdProblems.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpi_hle_OrderID});
            this.grdProblems.Size = new System.Drawing.Size(1239, 371);
            this.grdProblems.TabIndex = 4;
            this.grdProblems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvProblems});
            // 
            // grvProblems
            // 
            this.grvProblems.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grvProblems.Appearance.FooterPanel.Options.UseFont = true;
            this.grvProblems.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvProblems.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grcCustomerNumber,
            this.grcProductNumber,
            this.grcProductName,
            this.grcOrderNumber,
            this.grcLocationNumber,
            this.grcQuantity,
            this.grcEmployeeName,
            this.grcOrderID});
            this.grvProblems.GridControl = this.grdProblems;
            this.grvProblems.Name = "grvProblems";
            this.grvProblems.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grvProblems.OptionsSelection.MultiSelect = true;
            this.grvProblems.OptionsView.ShowGroupPanel = false;
            this.grvProblems.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvProblems.PaintStyleName = "Skin";
            // 
            // grcCustomerNumber
            // 
            this.grcCustomerNumber.AppearanceCell.Options.UseTextOptions = true;
            this.grcCustomerNumber.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcCustomerNumber.AppearanceHeader.Options.UseTextOptions = true;
            this.grcCustomerNumber.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcCustomerNumber.Caption = "CUSTOMER";
            this.grcCustomerNumber.FieldName = "CustomerNumber";
            this.grcCustomerNumber.MinWidth = 10;
            this.grcCustomerNumber.Name = "grcCustomerNumber";
            this.grcCustomerNumber.OptionsColumn.ReadOnly = true;
            this.grcCustomerNumber.Visible = true;
            this.grcCustomerNumber.VisibleIndex = 0;
            this.grcCustomerNumber.Width = 150;
            // 
            // grcProductNumber
            // 
            this.grcProductNumber.AppearanceCell.Options.UseTextOptions = true;
            this.grcProductNumber.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcProductNumber.AppearanceHeader.Options.UseTextOptions = true;
            this.grcProductNumber.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcProductNumber.Caption = "PRODUCT";
            this.grcProductNumber.FieldName = "ProductNumber";
            this.grcProductNumber.MinWidth = 100;
            this.grcProductNumber.Name = "grcProductNumber";
            this.grcProductNumber.OptionsColumn.ReadOnly = true;
            this.grcProductNumber.Visible = true;
            this.grcProductNumber.VisibleIndex = 3;
            this.grcProductNumber.Width = 185;
            // 
            // grcProductName
            // 
            this.grcProductName.AppearanceCell.Options.UseTextOptions = true;
            this.grcProductName.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcProductName.AppearanceHeader.Options.UseTextOptions = true;
            this.grcProductName.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcProductName.Caption = "PRODUCT NAME";
            this.grcProductName.FieldName = "ProductName";
            this.grcProductName.Name = "grcProductName";
            this.grcProductName.OptionsColumn.ReadOnly = true;
            this.grcProductName.Visible = true;
            this.grcProductName.VisibleIndex = 4;
            this.grcProductName.Width = 433;
            // 
            // grcOrderNumber
            // 
            this.grcOrderNumber.AppearanceCell.Options.UseTextOptions = true;
            this.grcOrderNumber.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcOrderNumber.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcOrderNumber.AppearanceHeader.Options.UseTextOptions = true;
            this.grcOrderNumber.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcOrderNumber.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcOrderNumber.Caption = "ORDER";
            this.grcOrderNumber.ColumnEdit = this.rpi_hle_OrderID;
            this.grcOrderNumber.FieldName = "OrderNumber";
            this.grcOrderNumber.MinWidth = 10;
            this.grcOrderNumber.Name = "grcOrderNumber";
            this.grcOrderNumber.OptionsColumn.ReadOnly = true;
            this.grcOrderNumber.Visible = true;
            this.grcOrderNumber.VisibleIndex = 1;
            this.grcOrderNumber.Width = 108;
            // 
            // rpi_hle_OrderID
            // 
            this.rpi_hle_OrderID.AutoHeight = false;
            this.rpi_hle_OrderID.Name = "rpi_hle_OrderID";
            this.rpi_hle_OrderID.Click += new System.EventHandler(this.rpi_hle_OrderID_Click);
            // 
            // grcLocationNumber
            // 
            this.grcLocationNumber.AppearanceCell.Options.UseTextOptions = true;
            this.grcLocationNumber.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcLocationNumber.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcLocationNumber.AppearanceHeader.Options.UseTextOptions = true;
            this.grcLocationNumber.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcLocationNumber.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcLocationNumber.Caption = "LOCATION";
            this.grcLocationNumber.FieldName = "LocationNumber";
            this.grcLocationNumber.MinWidth = 10;
            this.grcLocationNumber.Name = "grcLocationNumber";
            this.grcLocationNumber.OptionsColumn.ReadOnly = true;
            this.grcLocationNumber.Visible = true;
            this.grcLocationNumber.VisibleIndex = 2;
            this.grcLocationNumber.Width = 109;
            // 
            // grcQuantity
            // 
            this.grcQuantity.AppearanceCell.Options.UseTextOptions = true;
            this.grcQuantity.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcQuantity.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcQuantity.AppearanceHeader.Options.UseTextOptions = true;
            this.grcQuantity.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcQuantity.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcQuantity.Caption = "QTY";
            this.grcQuantity.FieldName = "Qty";
            this.grcQuantity.MinWidth = 10;
            this.grcQuantity.Name = "grcQuantity";
            this.grcQuantity.OptionsColumn.ReadOnly = true;
            this.grcQuantity.Visible = true;
            this.grcQuantity.VisibleIndex = 5;
            this.grcQuantity.Width = 65;
            // 
            // grcEmployeeName
            // 
            this.grcEmployeeName.AppearanceCell.Options.UseTextOptions = true;
            this.grcEmployeeName.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcEmployeeName.AppearanceHeader.Options.UseTextOptions = true;
            this.grcEmployeeName.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcEmployeeName.Caption = "EMPLOYEE";
            this.grcEmployeeName.FieldName = "VietnamName";
            this.grcEmployeeName.MinWidth = 10;
            this.grcEmployeeName.Name = "grcEmployeeName";
            this.grcEmployeeName.OptionsColumn.ReadOnly = true;
            this.grcEmployeeName.Visible = true;
            this.grcEmployeeName.VisibleIndex = 6;
            this.grcEmployeeName.Width = 170;
            // 
            // grcOrderID
            // 
            this.grcOrderID.Caption = "ID";
            this.grcOrderID.FieldName = "OrderID";
            this.grcOrderID.Name = "grcOrderID";
            this.grcOrderID.OptionsColumn.ReadOnly = true;
            // 
            // dtFrom
            // 
            this.dtFrom.EditValue = null;
            this.dtFrom.Location = new System.Drawing.Point(256, 16);
            this.dtFrom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtFrom.MenuManager = this.rbcbase;
            this.dtFrom.MinimumSize = new System.Drawing.Size(0, 24);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFrom.Size = new System.Drawing.Size(142, 26);
            this.dtFrom.StyleController = this.layoutControl1;
            this.dtFrom.TabIndex = 6;
            // 
            // dtTo
            // 
            this.dtTo.EditValue = null;
            this.dtTo.Location = new System.Drawing.Point(426, 16);
            this.dtTo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtTo.MenuManager = this.rbcbase;
            this.dtTo.MinimumSize = new System.Drawing.Size(0, 24);
            this.dtTo.Name = "dtTo";
            this.dtTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtTo.Size = new System.Drawing.Size(132, 26);
            this.dtTo.StyleController = this.layoutControl1;
            this.dtTo.TabIndex = 7;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Question;
            this.btnRefresh.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.Appearance.Options.UseBackColor = true;
            this.btnRefresh.Appearance.Options.UseFont = true;
            this.btnRefresh.Location = new System.Drawing.Point(566, 16);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRefresh.MaximumSize = new System.Drawing.Size(125, 24);
            this.btnRefresh.MinimumSize = new System.Drawing.Size(125, 24);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(125, 24);
            this.btnRefresh.StyleController = this.layoutControl1;
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "Refresh";
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
            this.layoutControlItem5,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1267, 434);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdProblems;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 35);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1243, 375);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.lkeLocations;
            this.layoutControlItem2.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(205, 35);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem2.Text = "Location";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(47, 16);
            this.layoutControlItem2.TrimClientAreaToControl = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.dtFrom;
            this.layoutControlItem3.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.layoutControlItem3.Location = new System.Drawing.Point(205, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(185, 35);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem3.Text = "From";
            this.layoutControlItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(30, 16);
            this.layoutControlItem3.TextToControlDistance = 5;
            this.layoutControlItem3.TrimClientAreaToControl = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.dtTo;
            this.layoutControlItem4.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.layoutControlItem4.Location = new System.Drawing.Point(390, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(160, 35);
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem4.Text = "To";
            this.layoutControlItem4.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(15, 16);
            this.layoutControlItem4.TextToControlDistance = 5;
            this.layoutControlItem4.TrimClientAreaToControl = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnRefresh;
            this.layoutControlItem5.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.layoutControlItem5.Location = new System.Drawing.Point(550, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(133, 35);
            this.layoutControlItem5.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            this.layoutControlItem5.TrimClientAreaToControl = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(683, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(560, 35);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frm_WM_Dialog_ProblemIdentification
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1267, 485);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_WM_Dialog_ProblemIdentification.IconOptions.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_WM_Dialog_ProblemIdentification";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "Problem Identification";
            this.Load += new System.EventHandler(this.frm_WM_Dialog_ProblemIdentification_Load);
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lkeLocations.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdProblems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProblems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_hle_OrderID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.LookUpEdit lkeLocations;
        private DevExpress.XtraGrid.GridControl grdProblems;
        private Common.Controls.WMSGridView grvProblems;
        private DevExpress.XtraEditors.DateEdit dtFrom;
        private DevExpress.XtraEditors.DateEdit dtTo;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerNumber;
        private DevExpress.XtraGrid.Columns.GridColumn grcProductNumber;
        private DevExpress.XtraGrid.Columns.GridColumn grcProductName;
        private DevExpress.XtraGrid.Columns.GridColumn grcOrderNumber;
        private DevExpress.XtraGrid.Columns.GridColumn grcLocationNumber;
        private DevExpress.XtraGrid.Columns.GridColumn grcQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn grcEmployeeName;
        private DevExpress.XtraGrid.Columns.GridColumn grcOrderID;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpi_hle_OrderID;
    }
}