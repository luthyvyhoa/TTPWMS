namespace UI.MasterSystemSetup
{
    partial class frm_MSS_EmployeeAllocations
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_MSS_EmployeeAllocations));
            this.btnNew = new DevExpress.XtraBars.BarButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.simpleSeparator1 = new DevExpress.XtraLayout.SimpleSeparator();
            this.grEmployeeAllocations = new DevExpress.XtraGrid.GridControl();
            this.bandedGridView2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand8 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.grColoumnId = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.grColumnFirst = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.grColumnLast = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.grColumnPosition = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.grColumnRooms = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridBand5 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.grColumnPallets = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand6 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.grColumnArea = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand7 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.grColumnNotes = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btn_Employee_Allocations = new DevExpress.XtraEditors.SimpleButton();
            this.btn_close_Employees_Allocations = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grEmployeeAllocations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // rbcbase
            // 
            this.rbcbase.ExpandCollapseItem.Id = 0;
            this.rbcbase.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnNew,
            this.btnClose});
            this.rbcbase.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbcbase.MaxItemId = 3;
            this.rbcbase.OptionsCustomizationForm.FormIcon = ((System.Drawing.Icon)(resources.GetObject("resource.FormIcon")));
            // 
            // 
            // 
            this.rbcbase.SearchEditItem.AccessibleName = "Search Item";
            this.rbcbase.SearchEditItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.rbcbase.SearchEditItem.EditWidth = 150;
            this.rbcbase.SearchEditItem.Id = -5000;
            this.rbcbase.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.rbcbase.Size = new System.Drawing.Size(899, 51);
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnNew);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnClose);
            // 
            // btnNew
            // 
            this.btnNew.Caption = "New";
            this.btnNew.Id = 1;
            this.btnNew.ImageOptions.Image = global::UI.Properties.Resources.InsertHeader_32x32;
            this.btnNew.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnNew.ImageOptions.LargeImage")));
            this.btnNew.Name = "btnNew";
            this.btnNew.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNew_ItemClick);
            // 
            // btnClose
            // 
            this.btnClose.Caption = "Close";
            this.btnClose.Id = 2;
            this.btnClose.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnClose.ImageOptions.LargeImage")));
            this.btnClose.Name = "btnClose";
            this.btnClose.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClose_ItemClick);
            // 
            // simpleSeparator1
            // 
            this.simpleSeparator1.AllowHotTrack = false;
            this.simpleSeparator1.Location = new System.Drawing.Point(0, 0);
            this.simpleSeparator1.Name = "simpleSeparator1";
            this.simpleSeparator1.Size = new System.Drawing.Size(531, 191);
            // 
            // grEmployeeAllocations
            // 
            this.grEmployeeAllocations.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grEmployeeAllocations.Location = new System.Drawing.Point(24, 24);
            this.grEmployeeAllocations.MainView = this.bandedGridView2;
            this.grEmployeeAllocations.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grEmployeeAllocations.MenuManager = this.rbcbase;
            this.grEmployeeAllocations.Name = "grEmployeeAllocations";
            this.grEmployeeAllocations.Padding = new System.Windows.Forms.Padding(17, 18, 17, 18);
            this.grEmployeeAllocations.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1,
            this.repositoryItemLookUpEdit1,
            this.repositoryItemLookUpEdit2});
            this.grEmployeeAllocations.Size = new System.Drawing.Size(851, 455);
            this.grEmployeeAllocations.TabIndex = 3;
            this.grEmployeeAllocations.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bandedGridView2});
            this.grEmployeeAllocations.Click += new System.EventHandler(this.gridControl1_Click);
            // 
            // bandedGridView2
            // 
            this.bandedGridView2.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.bandedGridView2.Appearance.FooterPanel.Options.UseFont = true;
            this.bandedGridView2.Appearance.HeaderPanel.Options.UseFont = true;
            this.bandedGridView2.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand8,
            this.gridBand2,
            this.gridBand3,
            this.gridBand4,
            this.gridBand5,
            this.gridBand6,
            this.gridBand7});
            this.bandedGridView2.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.grColoumnId,
            this.grColumnFirst,
            this.grColumnLast,
            this.grColumnPosition,
            this.grColumnRooms,
            this.grColumnPallets,
            this.grColumnArea,
            this.grColumnNotes});
            this.bandedGridView2.GridControl = this.grEmployeeAllocations;
            this.bandedGridView2.Name = "bandedGridView2";
            this.bandedGridView2.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.bandedGridView2.OptionsSelection.MultiSelect = true;
            this.bandedGridView2.OptionsView.ShowColumnHeaders = false;
            this.bandedGridView2.OptionsView.ShowGroupPanel = false;
            this.bandedGridView2.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.bandedGridView2.PaintStyleName = "Skin";
            // 
            // gridBand8
            // 
            this.gridBand8.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand8.Caption = "ID";
            this.gridBand8.Columns.Add(this.grColoumnId);
            this.gridBand8.Name = "gridBand8";
            this.gridBand8.VisibleIndex = 0;
            this.gridBand8.Width = 30;
            // 
            // grColoumnId
            // 
            this.grColoumnId.AppearanceCell.Options.UseTextOptions = true;
            this.grColoumnId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grColoumnId.Caption = "ID";
            this.grColoumnId.FieldName = "EmployeeID";
            this.grColoumnId.Name = "grColoumnId";
            this.grColoumnId.Visible = true;
            this.grColoumnId.Width = 30;
            // 
            // gridBand2
            // 
            this.gridBand2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand2.Caption = "Employee Name";
            this.gridBand2.Columns.Add(this.grColumnFirst);
            this.gridBand2.Columns.Add(this.grColumnLast);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.VisibleIndex = 1;
            this.gridBand2.Width = 224;
            // 
            // grColumnFirst
            // 
            this.grColumnFirst.Caption = "FIRST NAME";
            this.grColumnFirst.FieldName = "FirstName";
            this.grColumnFirst.Name = "grColumnFirst";
            this.grColumnFirst.Visible = true;
            this.grColumnFirst.Width = 59;
            // 
            // grColumnLast
            // 
            this.grColumnLast.Caption = "LAST NAME";
            this.grColumnLast.FieldName = "VietnamName";
            this.grColumnLast.Name = "grColumnLast";
            this.grColumnLast.Visible = true;
            this.grColumnLast.Width = 165;
            // 
            // gridBand3
            // 
            this.gridBand3.Caption = "Position";
            this.gridBand3.Columns.Add(this.grColumnPosition);
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.VisibleIndex = 2;
            this.gridBand3.Width = 124;
            // 
            // grColumnPosition
            // 
            this.grColumnPosition.Caption = "POSITION";
            this.grColumnPosition.FieldName = "VietnamPosition";
            this.grColumnPosition.Name = "grColumnPosition";
            this.grColumnPosition.Visible = true;
            this.grColumnPosition.Width = 124;
            // 
            // gridBand4
            // 
            this.gridBand4.Caption = "Room";
            this.gridBand4.Columns.Add(this.grColumnRooms);
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.VisibleIndex = 3;
            this.gridBand4.Width = 121;
            // 
            // grColumnRooms
            // 
            this.grColumnRooms.Caption = "ROOM";
            this.grColumnRooms.ColumnEdit = this.repositoryItemLookUpEdit2;
            this.grColumnRooms.FieldName = "RoomDescription";
            this.grColumnRooms.Name = "grColumnRooms";
            this.grColumnRooms.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.grColumnRooms.Visible = true;
            this.grColumnRooms.Width = 121;
            // 
            // repositoryItemLookUpEdit2
            // 
            this.repositoryItemLookUpEdit2.AutoHeight = false;
            this.repositoryItemLookUpEdit2.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.repositoryItemLookUpEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit2.DropDownRows = 20;
            this.repositoryItemLookUpEdit2.Name = "repositoryItemLookUpEdit2";
            this.repositoryItemLookUpEdit2.NullText = "";
            this.repositoryItemLookUpEdit2.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.StartsWith;
            // 
            // gridBand5
            // 
            this.gridBand5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand5.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridBand5.Caption = "Pallets";
            this.gridBand5.Columns.Add(this.grColumnPallets);
            this.gridBand5.Name = "gridBand5";
            this.gridBand5.VisibleIndex = 4;
            this.gridBand5.Width = 49;
            // 
            // grColumnPallets
            // 
            this.grColumnPallets.AppearanceCell.Options.UseTextOptions = true;
            this.grColumnPallets.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grColumnPallets.Caption = "PALLETS";
            this.grColumnPallets.FieldName = "QuantityOfPallets";
            this.grColumnPallets.Name = "grColumnPallets";
            this.grColumnPallets.Visible = true;
            this.grColumnPallets.Width = 49;
            // 
            // gridBand6
            // 
            this.gridBand6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand6.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridBand6.Caption = "Area";
            this.gridBand6.Columns.Add(this.grColumnArea);
            this.gridBand6.Name = "gridBand6";
            this.gridBand6.VisibleIndex = 5;
            this.gridBand6.Width = 52;
            // 
            // grColumnArea
            // 
            this.grColumnArea.AppearanceCell.Options.UseTextOptions = true;
            this.grColumnArea.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grColumnArea.Caption = "AREA";
            this.grColumnArea.FieldName = "RoomArea";
            this.grColumnArea.Name = "grColumnArea";
            this.grColumnArea.Visible = true;
            this.grColumnArea.Width = 52;
            // 
            // gridBand7
            // 
            this.gridBand7.Caption = "Notes";
            this.gridBand7.Columns.Add(this.grColumnNotes);
            this.gridBand7.Name = "gridBand7";
            this.gridBand7.VisibleIndex = 6;
            this.gridBand7.Width = 75;
            // 
            // grColumnNotes
            // 
            this.grColumnNotes.Caption = "NOTES";
            this.grColumnNotes.FieldName = "AreaRemark";
            this.grColumnNotes.Name = "grColumnNotes";
            this.grColumnNotes.Visible = true;
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.LookAndFeel.UseWindowsXPTheme = true;
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            this.repositoryItemComboBox1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AcceptEditorTextAsNewValue = DevExpress.Utils.DefaultBoolean.True;
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.NullText = "";
            this.repositoryItemLookUpEdit1.ShowFooter = false;
            this.repositoryItemLookUpEdit1.ShowHeader = false;
            this.repositoryItemLookUpEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grEmployeeAllocations);
            this.layoutControl1.Controls.Add(this.btn_Employee_Allocations);
            this.layoutControl1.Controls.Add(this.btn_close_Employees_Allocations);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 51);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(991, 138, 450, 400);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(899, 551);
            this.layoutControl1.TabIndex = 4;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btn_Employee_Allocations
            // 
            this.btn_Employee_Allocations.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btn_Employee_Allocations.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btn_Employee_Allocations.Appearance.Options.UseBackColor = true;
            this.btn_Employee_Allocations.Appearance.Options.UseFont = true;
            this.btn_Employee_Allocations.Location = new System.Drawing.Point(627, 497);
            this.btn_Employee_Allocations.MaximumSize = new System.Drawing.Size(125, 40);
            this.btn_Employee_Allocations.MinimumSize = new System.Drawing.Size(125, 40);
            this.btn_Employee_Allocations.Name = "btn_Employee_Allocations";
            this.btn_Employee_Allocations.Size = new System.Drawing.Size(125, 40);
            this.btn_Employee_Allocations.StyleController = this.layoutControl1;
            this.btn_Employee_Allocations.TabIndex = 4;
            this.btn_Employee_Allocations.Text = "New";
            this.btn_Employee_Allocations.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // btn_close_Employees_Allocations
            // 
            this.btn_close_Employees_Allocations.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.btn_close_Employees_Allocations.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btn_close_Employees_Allocations.Appearance.Options.UseBackColor = true;
            this.btn_close_Employees_Allocations.Appearance.Options.UseFont = true;
            this.btn_close_Employees_Allocations.Location = new System.Drawing.Point(760, 497);
            this.btn_close_Employees_Allocations.MaximumSize = new System.Drawing.Size(125, 40);
            this.btn_close_Employees_Allocations.MinimumSize = new System.Drawing.Size(125, 40);
            this.btn_close_Employees_Allocations.Name = "btn_close_Employees_Allocations";
            this.btn_close_Employees_Allocations.Size = new System.Drawing.Size(125, 40);
            this.btn_close_Employees_Allocations.StyleController = this.layoutControl1;
            this.btn_close_Employees_Allocations.TabIndex = 5;
            this.btn_close_Employees_Allocations.Text = "Close";
            this.btn_close_Employees_Allocations.Click += new System.EventHandler(this.btn_close_Employees_Allocations_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(899, 551);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grEmployeeAllocations;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(14, 14, 14, 14);
            this.layoutControlItem1.Size = new System.Drawing.Size(879, 483);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 483);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(613, 48);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btn_Employee_Allocations;
            this.layoutControlItem2.Location = new System.Drawing.Point(613, 483);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(133, 48);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btn_close_Employees_Allocations;
            this.layoutControlItem3.Location = new System.Drawing.Point(746, 483);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(133, 48);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // frm_MSS_EmployeeAllocations
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 602);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_MSS_EmployeeAllocations.IconOptions.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_MSS_EmployeeAllocations";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "Employee Allocations by  Area";
            this.Load += new System.EventHandler(this.frm_MSS_EmployeeAllocations_Load);
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grEmployeeAllocations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarButtonItem btnNew;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        private DevExpress.XtraLayout.SimpleSeparator simpleSeparator1;
        private DevExpress.XtraGrid.GridControl grEmployeeAllocations;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandedGridView2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn grColoumnId;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn grColumnFirst;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn grColumnLast;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn grColumnPosition;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn grColumnRooms;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn grColumnPallets;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn grColumnArea;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn grColumnNotes;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit2;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand8;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand5;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand6;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand7;
        private DevExpress.XtraEditors.SimpleButton btn_Employee_Allocations;
        private DevExpress.XtraEditors.SimpleButton btn_close_Employees_Allocations;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}