namespace UI.ReportForm
{
    partial class frm_WR_StockByLocationManyCustomers
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_WR_StockByLocationManyCustomers));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grdCustomers = new DevExpress.XtraGrid.GridControl();
            this.grvCustomer = new Common.Controls.WMSGridView();
            this.grcCustomerID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lkeRooms = new DevExpress.XtraEditors.LookUpEdit();
            this.dtOldDate = new DevExpress.XtraEditors.DateEdit();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnByLocation = new DevExpress.XtraEditors.SimpleButton();
            this.btnSmallLocation = new DevExpress.XtraEditors.SimpleButton();
            this.btnSmallCustomer = new DevExpress.XtraEditors.SimpleButton();
            this.btnSmallLocationCarton = new DevExpress.XtraEditors.SimpleButton();
            this.btnOldStock = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.simpleLabelItem1 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCustomers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeRooms.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtOldDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtOldDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
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
            this.rbcbase.Size = new System.Drawing.Size(839, 51);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grdCustomers);
            this.layoutControl1.Controls.Add(this.lkeRooms);
            this.layoutControl1.Controls.Add(this.dtOldDate);
            this.layoutControl1.Controls.Add(this.btnClose);
            this.layoutControl1.Controls.Add(this.btnByLocation);
            this.layoutControl1.Controls.Add(this.btnSmallLocation);
            this.layoutControl1.Controls.Add(this.btnSmallCustomer);
            this.layoutControl1.Controls.Add(this.btnSmallLocationCarton);
            this.layoutControl1.Controls.Add(this.btnOldStock);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 51);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(646, 105, 450, 400);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(839, 581);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grdCustomers
            // 
            this.grdCustomers.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grdCustomers.Location = new System.Drawing.Point(12, 46);
            this.grdCustomers.MainView = this.grvCustomer;
            this.grdCustomers.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdCustomers.MenuManager = this.rbcbase;
            this.grdCustomers.Name = "grdCustomers";
            this.grdCustomers.Size = new System.Drawing.Size(815, 479);
            this.grdCustomers.TabIndex = 6;
            this.grdCustomers.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvCustomer});
            // 
            // grvCustomer
            // 
            this.grvCustomer.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grvCustomer.Appearance.FooterPanel.Options.UseFont = true;
            this.grvCustomer.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvCustomer.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grcCustomerID,
            this.grcCustomerNumber,
            this.grcCustomerName});
            this.grvCustomer.DetailHeight = 458;
            this.grvCustomer.FixedLineWidth = 3;
            this.grvCustomer.GridControl = this.grdCustomers;
            this.grvCustomer.Name = "grvCustomer";
            this.grvCustomer.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grvCustomer.OptionsSelection.MultiSelect = true;
            this.grvCustomer.OptionsView.ShowColumnHeaders = false;
            this.grvCustomer.OptionsView.ShowGroupPanel = false;
            this.grvCustomer.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvCustomer.PaintStyleName = "Skin";
            // 
            // grcCustomerID
            // 
            this.grcCustomerID.Caption = "ID";
            this.grcCustomerID.FieldName = "CustomerID";
            this.grcCustomerID.MinWidth = 27;
            this.grcCustomerID.Name = "grcCustomerID";
            this.grcCustomerID.Width = 100;
            // 
            // grcCustomerNumber
            // 
            this.grcCustomerNumber.Caption = "NUMBER";
            this.grcCustomerNumber.FieldName = "CustomerNumber";
            this.grcCustomerNumber.MinWidth = 27;
            this.grcCustomerNumber.Name = "grcCustomerNumber";
            this.grcCustomerNumber.Visible = true;
            this.grcCustomerNumber.VisibleIndex = 0;
            this.grcCustomerNumber.Width = 221;
            // 
            // grcCustomerName
            // 
            this.grcCustomerName.Caption = "NAME";
            this.grcCustomerName.FieldName = "CustomerName";
            this.grcCustomerName.MinWidth = 27;
            this.grcCustomerName.Name = "grcCustomerName";
            this.grcCustomerName.Visible = true;
            this.grcCustomerName.VisibleIndex = 1;
            this.grcCustomerName.Width = 732;
            // 
            // lkeRooms
            // 
            this.lkeRooms.Location = new System.Drawing.Point(52, 14);
            this.lkeRooms.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lkeRooms.MenuManager = this.rbcbase;
            this.lkeRooms.MinimumSize = new System.Drawing.Size(0, 24);
            this.lkeRooms.Name = "lkeRooms";
            this.lkeRooms.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeRooms.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RoomID", "ID", 50, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lkeRooms.Properties.DropDownRows = 20;
            this.lkeRooms.Properties.NullText = "";
            this.lkeRooms.Properties.ShowFooter = false;
            this.lkeRooms.Properties.ShowHeader = false;
            this.lkeRooms.Size = new System.Drawing.Size(232, 26);
            this.lkeRooms.StyleController = this.layoutControl1;
            this.lkeRooms.TabIndex = 4;
            // 
            // dtOldDate
            // 
            this.dtOldDate.EditValue = null;
            this.dtOldDate.Location = new System.Drawing.Point(438, 14);
            this.dtOldDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtOldDate.MenuManager = this.rbcbase;
            this.dtOldDate.MinimumSize = new System.Drawing.Size(0, 24);
            this.dtOldDate.Name = "dtOldDate";
            this.dtOldDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtOldDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtOldDate.Size = new System.Drawing.Size(387, 26);
            this.dtOldDate.StyleController = this.layoutControl1;
            this.dtOldDate.TabIndex = 5;
            // 
            // btnClose
            // 
            this.btnClose.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.btnClose.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnClose.Appearance.Options.UseBackColor = true;
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Location = new System.Drawing.Point(657, 529);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnClose.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(125, 40);
            this.btnClose.StyleController = this.layoutControl1;
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            // 
            // btnByLocation
            // 
            this.btnByLocation.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnByLocation.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnByLocation.Appearance.Options.UseBackColor = true;
            this.btnByLocation.Appearance.Options.UseFont = true;
            this.btnByLocation.Location = new System.Drawing.Point(12, 529);
            this.btnByLocation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnByLocation.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnByLocation.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnByLocation.Name = "btnByLocation";
            this.btnByLocation.Size = new System.Drawing.Size(125, 40);
            this.btnByLocation.StyleController = this.layoutControl1;
            this.btnByLocation.TabIndex = 8;
            this.btnByLocation.Text = "By Location";
            // 
            // btnSmallLocation
            // 
            this.btnSmallLocation.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnSmallLocation.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnSmallLocation.Appearance.Options.UseBackColor = true;
            this.btnSmallLocation.Appearance.Options.UseFont = true;
            this.btnSmallLocation.Appearance.Options.UseTextOptions = true;
            this.btnSmallLocation.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnSmallLocation.Location = new System.Drawing.Point(141, 529);
            this.btnSmallLocation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSmallLocation.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnSmallLocation.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnSmallLocation.Name = "btnSmallLocation";
            this.btnSmallLocation.Size = new System.Drawing.Size(125, 40);
            this.btnSmallLocation.StyleController = this.layoutControl1;
            this.btnSmallLocation.TabIndex = 9;
            this.btnSmallLocation.Text = "By Weight";
            // 
            // btnSmallCustomer
            // 
            this.btnSmallCustomer.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnSmallCustomer.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnSmallCustomer.Appearance.Options.UseBackColor = true;
            this.btnSmallCustomer.Appearance.Options.UseFont = true;
            this.btnSmallCustomer.Appearance.Options.UseTextOptions = true;
            this.btnSmallCustomer.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnSmallCustomer.Location = new System.Drawing.Point(528, 529);
            this.btnSmallCustomer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSmallCustomer.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnSmallCustomer.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnSmallCustomer.Name = "btnSmallCustomer";
            this.btnSmallCustomer.Size = new System.Drawing.Size(125, 40);
            this.btnSmallCustomer.StyleController = this.layoutControl1;
            this.btnSmallCustomer.TabIndex = 10;
            this.btnSmallCustomer.Text = "By Customer";
            // 
            // btnSmallLocationCarton
            // 
            this.btnSmallLocationCarton.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnSmallLocationCarton.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnSmallLocationCarton.Appearance.Options.UseBackColor = true;
            this.btnSmallLocationCarton.Appearance.Options.UseFont = true;
            this.btnSmallLocationCarton.Appearance.Options.UseTextOptions = true;
            this.btnSmallLocationCarton.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnSmallLocationCarton.Location = new System.Drawing.Point(399, 529);
            this.btnSmallLocationCarton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSmallLocationCarton.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnSmallLocationCarton.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnSmallLocationCarton.Name = "btnSmallLocationCarton";
            this.btnSmallLocationCarton.Size = new System.Drawing.Size(125, 40);
            this.btnSmallLocationCarton.StyleController = this.layoutControl1;
            this.btnSmallLocationCarton.TabIndex = 11;
            this.btnSmallLocationCarton.Text = "By Carton";
            // 
            // btnOldStock
            // 
            this.btnOldStock.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnOldStock.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnOldStock.Appearance.Options.UseBackColor = true;
            this.btnOldStock.Appearance.Options.UseFont = true;
            this.btnOldStock.Location = new System.Drawing.Point(270, 529);
            this.btnOldStock.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOldStock.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnOldStock.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnOldStock.Name = "btnOldStock";
            this.btnOldStock.Size = new System.Drawing.Size(125, 40);
            this.btnOldStock.StyleController = this.layoutControl1;
            this.btnOldStock.TabIndex = 12;
            this.btnOldStock.Text = "Old Stock";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.simpleLabelItem1,
            this.layoutControlItem3,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem9,
            this.layoutControlItem8,
            this.layoutControlItem4,
            this.layoutControlItem7,
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(839, 581);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // simpleLabelItem1
            // 
            this.simpleLabelItem1.AllowHotTrack = false;
            this.simpleLabelItem1.Location = new System.Drawing.Point(278, 0);
            this.simpleLabelItem1.Name = "simpleLabelItem1";
            this.simpleLabelItem1.Size = new System.Drawing.Size(146, 34);
            this.simpleLabelItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.simpleLabelItem1.Text = "(Small locations)";
            this.simpleLabelItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.simpleLabelItem1.TextSize = new System.Drawing.Size(96, 16);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.grdCustomers;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 34);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(819, 483);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnByLocation;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 517);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(129, 44);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnSmallLocation;
            this.layoutControlItem6.Location = new System.Drawing.Point(129, 517);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(129, 44);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.btnOldStock;
            this.layoutControlItem9.Location = new System.Drawing.Point(258, 517);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(129, 44);
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.btnSmallLocationCarton;
            this.layoutControlItem8.Location = new System.Drawing.Point(387, 517);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(129, 44);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnClose;
            this.layoutControlItem4.Location = new System.Drawing.Point(645, 517);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(174, 44);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.btnSmallCustomer;
            this.layoutControlItem7.Location = new System.Drawing.Point(516, 517);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(129, 44);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lkeRooms;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(278, 34);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem1.Text = "Room";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(33, 16);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.dtOldDate;
            this.layoutControlItem2.Location = new System.Drawing.Point(424, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(395, 34);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem2.Text = "Old Date";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // frm_WR_StockByLocationManyCustomers
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 632);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_WR_StockByLocationManyCustomers.IconOptions.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_WR_StockByLocationManyCustomers";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "Stock By Location Many Customers";
            this.Load += new System.EventHandler(this.frm_WR_StockByLocationManyCustomers_Load);
            this.Shown += new System.EventHandler(this.frm_WR_StockByLocationManyCustomers_Shown);
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCustomers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeRooms.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtOldDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtOldDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.LookUpEdit lkeRooms;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.SimpleLabelItem simpleLabelItem1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.ComponentModel.IContainer components;
        private DevExpress.XtraEditors.DateEdit dtOldDate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.GridControl grdCustomers;
        private Common.Controls.WMSGridView grvCustomer;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerID;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerNumber;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerName;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnByLocation;
        private DevExpress.XtraEditors.SimpleButton btnSmallLocation;
        private DevExpress.XtraEditors.SimpleButton btnSmallCustomer;
        private DevExpress.XtraEditors.SimpleButton btnSmallLocationCarton;
        private DevExpress.XtraEditors.SimpleButton btnOldStock;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
    }
}