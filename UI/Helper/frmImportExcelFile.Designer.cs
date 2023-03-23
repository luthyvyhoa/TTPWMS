namespace UI.Helper
{
    partial class frmImportExcelFile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportExcelFile));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnCreateData = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Browser = new DevExpress.XtraEditors.SimpleButton();
            this.txtEdit_FileBrowser = new DevExpress.XtraEditors.TextEdit();
            this.searchLookUpEdit_CustomerID = new DevExpress.XtraEditors.LookUpEdit();
            this.txtEdit_CustomerName = new DevExpress.XtraEditors.TextEdit();
            this.chkEdit_CustomerMain = new DevExpress.XtraEditors.CheckEdit();
            this.btn_OpenExcelFile = new DevExpress.XtraEditors.SimpleButton();
            this.lkUEdit_Sheet = new DevExpress.XtraEditors.LookUpEdit();
            this.grdFileContents = new DevExpress.XtraGrid.GridControl();
            this.grvFileContents = new Common.Controls.WMSGridView();
            this.btnImport = new DevExpress.XtraEditors.SimpleButton();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdit_FileBrowser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit_CustomerID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdit_CustomerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEdit_CustomerMain.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkUEdit_Sheet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFileContents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFileContents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
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
            this.rbcbase.Size = new System.Drawing.Size(1077, 51);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnCreateData);
            this.layoutControl1.Controls.Add(this.btn_Browser);
            this.layoutControl1.Controls.Add(this.txtEdit_FileBrowser);
            this.layoutControl1.Controls.Add(this.searchLookUpEdit_CustomerID);
            this.layoutControl1.Controls.Add(this.txtEdit_CustomerName);
            this.layoutControl1.Controls.Add(this.chkEdit_CustomerMain);
            this.layoutControl1.Controls.Add(this.btn_OpenExcelFile);
            this.layoutControl1.Controls.Add(this.lkUEdit_Sheet);
            this.layoutControl1.Controls.Add(this.grdFileContents);
            this.layoutControl1.Controls.Add(this.btnImport);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 51);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(939, -606, 812, 500);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1077, 567);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnCreateData
            // 
            this.btnCreateData.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnCreateData.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnCreateData.Appearance.Options.UseBackColor = true;
            this.btnCreateData.Appearance.Options.UseFont = true;
            this.btnCreateData.Location = new System.Drawing.Point(512, 88);
            this.btnCreateData.MaximumSize = new System.Drawing.Size(125, 24);
            this.btnCreateData.MinimumSize = new System.Drawing.Size(125, 24);
            this.btnCreateData.Name = "btnCreateData";
            this.btnCreateData.Size = new System.Drawing.Size(125, 24);
            this.btnCreateData.StyleController = this.layoutControl1;
            this.btnCreateData.TabIndex = 49;
            this.btnCreateData.Text = "Create Data";
            this.btnCreateData.Click += new System.EventHandler(this.btnCreateData_Click);
            // 
            // btn_Browser
            // 
            this.btn_Browser.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btn_Browser.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btn_Browser.Appearance.Options.UseBackColor = true;
            this.btn_Browser.Appearance.Options.UseFont = true;
            this.btn_Browser.Location = new System.Drawing.Point(91, 51);
            this.btn_Browser.MaximumSize = new System.Drawing.Size(125, 24);
            this.btn_Browser.MinimumSize = new System.Drawing.Size(125, 24);
            this.btn_Browser.Name = "btn_Browser";
            this.btn_Browser.Size = new System.Drawing.Size(125, 24);
            this.btn_Browser.StyleController = this.layoutControl1;
            this.btn_Browser.TabIndex = 4;
            this.btn_Browser.Text = "Browser...";
            this.btn_Browser.Click += new System.EventHandler(this.btn_Browser_Click);
            // 
            // txtEdit_FileBrowser
            // 
            this.txtEdit_FileBrowser.Location = new System.Drawing.Point(222, 51);
            this.txtEdit_FileBrowser.MinimumSize = new System.Drawing.Size(0, 25);
            this.txtEdit_FileBrowser.Name = "txtEdit_FileBrowser";
            this.txtEdit_FileBrowser.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtEdit_FileBrowser.Properties.ReadOnly = true;
            this.txtEdit_FileBrowser.Size = new System.Drawing.Size(498, 26);
            this.txtEdit_FileBrowser.StyleController = this.layoutControl1;
            this.txtEdit_FileBrowser.TabIndex = 5;
            // 
            // searchLookUpEdit_CustomerID
            // 
            this.searchLookUpEdit_CustomerID.Location = new System.Drawing.Point(91, 15);
            this.searchLookUpEdit_CustomerID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.searchLookUpEdit_CustomerID.MinimumSize = new System.Drawing.Size(0, 25);
            this.searchLookUpEdit_CustomerID.Name = "searchLookUpEdit_CustomerID";
            this.searchLookUpEdit_CustomerID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.searchLookUpEdit_CustomerID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpEdit_CustomerID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerNumber", "CustomerNumber", 150, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerName", "CustomerName", 230, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerDispatchMethod", "CustomerDispatchMethod", 280, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.searchLookUpEdit_CustomerID.Properties.DisplayMember = "CustomerNumber";
            this.searchLookUpEdit_CustomerID.Properties.DropDownRows = 20;
            this.searchLookUpEdit_CustomerID.Properties.NullText = "";
            this.searchLookUpEdit_CustomerID.Properties.PopupFormMinSize = new System.Drawing.Size(500, 0);
            this.searchLookUpEdit_CustomerID.Properties.ShowFooter = false;
            this.searchLookUpEdit_CustomerID.Properties.ShowHeader = false;
            this.searchLookUpEdit_CustomerID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.searchLookUpEdit_CustomerID.Properties.ValueMember = "CustomerID";
            this.searchLookUpEdit_CustomerID.Size = new System.Drawing.Size(125, 26);
            this.searchLookUpEdit_CustomerID.StyleController = this.layoutControl1;
            this.searchLookUpEdit_CustomerID.TabIndex = 20;
            // 
            // txtEdit_CustomerName
            // 
            this.txtEdit_CustomerName.Location = new System.Drawing.Point(222, 15);
            this.txtEdit_CustomerName.MinimumSize = new System.Drawing.Size(0, 25);
            this.txtEdit_CustomerName.Name = "txtEdit_CustomerName";
            this.txtEdit_CustomerName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtEdit_CustomerName.Properties.ReadOnly = true;
            this.txtEdit_CustomerName.Size = new System.Drawing.Size(498, 26);
            this.txtEdit_CustomerName.StyleController = this.layoutControl1;
            this.txtEdit_CustomerName.TabIndex = 38;
            // 
            // chkEdit_CustomerMain
            // 
            this.chkEdit_CustomerMain.Enabled = false;
            this.chkEdit_CustomerMain.Location = new System.Drawing.Point(725, 12);
            this.chkEdit_CustomerMain.Name = "chkEdit_CustomerMain";
            this.chkEdit_CustomerMain.Properties.Caption = "Main";
            this.chkEdit_CustomerMain.Size = new System.Drawing.Size(127, 24);
            this.chkEdit_CustomerMain.StyleController = this.layoutControl1;
            this.chkEdit_CustomerMain.TabIndex = 39;
            // 
            // btn_OpenExcelFile
            // 
            this.btn_OpenExcelFile.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btn_OpenExcelFile.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btn_OpenExcelFile.Appearance.Options.UseBackColor = true;
            this.btn_OpenExcelFile.Appearance.Options.UseFont = true;
            this.btn_OpenExcelFile.Location = new System.Drawing.Point(726, 43);
            this.btn_OpenExcelFile.MaximumSize = new System.Drawing.Size(125, 24);
            this.btn_OpenExcelFile.MinimumSize = new System.Drawing.Size(125, 24);
            this.btn_OpenExcelFile.Name = "btn_OpenExcelFile";
            this.btn_OpenExcelFile.Size = new System.Drawing.Size(125, 24);
            this.btn_OpenExcelFile.StyleController = this.layoutControl1;
            this.btn_OpenExcelFile.TabIndex = 6;
            this.btn_OpenExcelFile.Text = "Open File Excel";
            this.btn_OpenExcelFile.Click += new System.EventHandler(this.btn_OpenExcelFile_Click);
            // 
            // lkUEdit_Sheet
            // 
            this.lkUEdit_Sheet.Location = new System.Drawing.Point(895, 15);
            this.lkUEdit_Sheet.MinimumSize = new System.Drawing.Size(0, 25);
            this.lkUEdit_Sheet.Name = "lkUEdit_Sheet";
            this.lkUEdit_Sheet.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkUEdit_Sheet.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Sheet Name")});
            this.lkUEdit_Sheet.Properties.DropDownRows = 5;
            this.lkUEdit_Sheet.Properties.NullText = "";
            this.lkUEdit_Sheet.Properties.ShowFooter = false;
            this.lkUEdit_Sheet.Properties.ShowHeader = false;
            this.lkUEdit_Sheet.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lkUEdit_Sheet.Size = new System.Drawing.Size(169, 26);
            this.lkUEdit_Sheet.StyleController = this.layoutControl1;
            this.lkUEdit_Sheet.TabIndex = 48;
            // 
            // grdFileContents
            // 
            this.grdFileContents.AllowDrop = true;
            this.grdFileContents.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.grdFileContents.Location = new System.Drawing.Point(12, 122);
            this.grdFileContents.MainView = this.grvFileContents;
            this.grdFileContents.Name = "grdFileContents";
            this.grdFileContents.Size = new System.Drawing.Size(1053, 433);
            this.grdFileContents.TabIndex = 47;
            this.grdFileContents.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvFileContents});
            this.grdFileContents.DragDrop += new System.Windows.Forms.DragEventHandler(this.grdFileContents_DragDrop);
            this.grdFileContents.DragEnter += new System.Windows.Forms.DragEventHandler(this.grdFileContents_DragEnter);
            // 
            // grvFileContents
            // 
            this.grvFileContents.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.grvFileContents.FixedLineWidth = 3;
            this.grvFileContents.GridControl = this.grdFileContents;
            this.grvFileContents.Name = "grvFileContents";
            this.grvFileContents.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grvFileContents.PaintStyleName = "Skin";
            // 
            // btnImport
            // 
            this.btnImport.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnImport.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnImport.Appearance.Options.UseBackColor = true;
            this.btnImport.Appearance.Options.UseFont = true;
            this.btnImport.Location = new System.Drawing.Point(386, 88);
            this.btnImport.MaximumSize = new System.Drawing.Size(125, 24);
            this.btnImport.MinimumSize = new System.Drawing.Size(125, 24);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(125, 24);
            this.btnImport.StyleController = this.layoutControl1;
            this.btnImport.TabIndex = 41;
            this.btnImport.Text = "Import File ";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem3,
            this.layoutControlItem11,
            this.layoutControlItem13,
            this.emptySpaceItem1,
            this.emptySpaceItem2,
            this.layoutControlItem7,
            this.layoutControlItem8});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1077, 567);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btn_Browser;
            this.layoutControlItem1.CustomizationFormText = "Choose File";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 36);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(209, 37);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem1.Text = "Choose File";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(66, 16);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtEdit_FileBrowser;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(209, 36);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(504, 37);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.searchLookUpEdit_CustomerID;
            this.layoutControlItem4.CustomizationFormText = "Customer";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(209, 36);
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem4.Text = "Customer";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(66, 16);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtEdit_CustomerName;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(209, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(504, 36);
            this.layoutControlItem5.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.chkEdit_CustomerMain;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.Location = new System.Drawing.Point(713, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(131, 28);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btn_OpenExcelFile;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(713, 28);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(131, 45);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.lkUEdit_Sheet;
            this.layoutControlItem11.CustomizationFormText = "Sheet";
            this.layoutControlItem11.Location = new System.Drawing.Point(844, 0);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(213, 73);
            this.layoutControlItem11.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem11.Text = "Sheet";
            this.layoutControlItem11.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem11.TextSize = new System.Drawing.Size(33, 16);
            this.layoutControlItem11.TextToControlDistance = 5;
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.Control = this.grdFileContents;
            this.layoutControlItem13.CustomizationFormText = "layoutControlItem13";
            this.layoutControlItem13.Location = new System.Drawing.Point(0, 110);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new System.Drawing.Size(1057, 437);
            this.layoutControlItem13.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem13.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 73);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(295, 37);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(630, 73);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(427, 37);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.btnImport;
            this.layoutControlItem7.CustomizationFormText = " ";
            this.layoutControlItem7.Location = new System.Drawing.Point(295, 73);
            this.layoutControlItem7.MaxSize = new System.Drawing.Size(0, 35);
            this.layoutControlItem7.MinSize = new System.Drawing.Size(203, 35);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(204, 37);
            this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem7.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem7.Text = " ";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(66, 16);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.btnCreateData;
            this.layoutControlItem8.Location = new System.Drawing.Point(499, 73);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(131, 37);
            this.layoutControlItem8.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // frmImportExcelFile
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 618);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frmImportExcelFile.IconOptions.Icon")));
            this.IsFixHeightScreen = false;
            this.Name = "frmImportExcelFile";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "Import Excel";
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtEdit_FileBrowser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit_CustomerID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdit_CustomerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEdit_CustomerMain.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkUEdit_Sheet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFileContents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFileContents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.SimpleButton btn_Browser;
        private DevExpress.XtraEditors.TextEdit txtEdit_FileBrowser;
        private DevExpress.XtraEditors.LookUpEdit searchLookUpEdit_CustomerID;
        private DevExpress.XtraEditors.TextEdit txtEdit_CustomerName;
        private DevExpress.XtraEditors.CheckEdit chkEdit_CustomerMain;
        private DevExpress.XtraEditors.SimpleButton btn_OpenExcelFile;
        private DevExpress.XtraEditors.LookUpEdit lkUEdit_Sheet;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraGrid.GridControl grdFileContents;
        private Common.Controls.WMSGridView grvFileContents;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem13;
        private DevExpress.XtraEditors.SimpleButton btnImport;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraEditors.SimpleButton btnCreateData;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
    }
}