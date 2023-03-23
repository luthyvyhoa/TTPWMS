namespace UI.WarehouseManagement
{
    partial class frm_WM_ConfirmationAll
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_WM_ConfirmationAll));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.rdgFilterType = new DevExpress.XtraEditors.RadioGroup();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnCloseStock = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.grdConfirmationAll = new DevExpress.XtraGrid.GridControl();
            this.grvConfirmationAll = new Common.Controls.WMSGridView();
            this.grcOrderDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcEndTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcTransactionID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerRef = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcOrderNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_hpl_OrderNumber = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.grcOrderID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcOrderType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdgFilterType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdConfirmationAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvConfirmationAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_hpl_OrderNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
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
            this.rbcbase.Size = new System.Drawing.Size(1402, 51);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.rdgFilterType);
            this.layoutControl1.Controls.Add(this.btnClose);
            this.layoutControl1.Controls.Add(this.btnCloseStock);
            this.layoutControl1.Controls.Add(this.btnRefresh);
            this.layoutControl1.Controls.Add(this.grdConfirmationAll);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 51);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(568, 257, 450, 400);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1402, 676);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // rdgFilterType
            // 
            this.rdgFilterType.Location = new System.Drawing.Point(451, 616);
            this.rdgFilterType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdgFilterType.MaximumSize = new System.Drawing.Size(0, 29);
            this.rdgFilterType.MenuManager = this.rbcbase;
            this.rdgFilterType.MinimumSize = new System.Drawing.Size(183, 29);
            this.rdgFilterType.Name = "rdgFilterType";
            this.rdgFilterType.Properties.ColumnIndent = 5;
            this.rdgFilterType.Properties.Columns = 4;
            this.rdgFilterType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(0)), "All"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(1)), "Me"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(2)), "123"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(3)), "45")});
            this.rdgFilterType.Size = new System.Drawing.Size(455, 29);
            this.rdgFilterType.StyleController = this.layoutControl1;
            this.rdgFilterType.TabIndex = 9;
            // 
            // btnClose
            // 
            this.btnClose.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.btnClose.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnClose.Appearance.Options.UseBackColor = true;
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Location = new System.Drawing.Point(1263, 616);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnClose.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(125, 40);
            this.btnClose.StyleController = this.layoutControl1;
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            // 
            // btnCloseStock
            // 
            this.btnCloseStock.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning;
            this.btnCloseStock.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnCloseStock.Appearance.Options.UseBackColor = true;
            this.btnCloseStock.Appearance.Options.UseFont = true;
            this.btnCloseStock.Location = new System.Drawing.Point(147, 616);
            this.btnCloseStock.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCloseStock.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnCloseStock.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnCloseStock.Name = "btnCloseStock";
            this.btnCloseStock.Size = new System.Drawing.Size(125, 40);
            this.btnCloseStock.StyleController = this.layoutControl1;
            this.btnCloseStock.TabIndex = 6;
            this.btnCloseStock.Text = "Close Stock";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Question;
            this.btnRefresh.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.Appearance.Options.UseBackColor = true;
            this.btnRefresh.Appearance.Options.UseFont = true;
            this.btnRefresh.Location = new System.Drawing.Point(14, 616);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRefresh.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnRefresh.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(125, 40);
            this.btnRefresh.StyleController = this.layoutControl1;
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Refresh";
            // 
            // grdConfirmationAll
            // 
            this.grdConfirmationAll.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grdConfirmationAll.Location = new System.Drawing.Point(12, 12);
            this.grdConfirmationAll.MainView = this.grvConfirmationAll;
            this.grdConfirmationAll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdConfirmationAll.MenuManager = this.rbcbase;
            this.grdConfirmationAll.Name = "grdConfirmationAll";
            this.grdConfirmationAll.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpi_hpl_OrderNumber});
            this.grdConfirmationAll.Size = new System.Drawing.Size(1378, 598);
            this.grdConfirmationAll.TabIndex = 4;
            this.grdConfirmationAll.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvConfirmationAll});
            // 
            // grvConfirmationAll
            // 
            this.grvConfirmationAll.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grvConfirmationAll.Appearance.FooterPanel.Options.UseFont = true;
            this.grvConfirmationAll.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvConfirmationAll.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grcOrderDate,
            this.grcCreateDate,
            this.grcEndTime,
            this.grcTransactionID,
            this.grcCustomerNumber,
            this.grcUserName,
            this.grcCustomerRef,
            this.grcOrderNumber,
            this.grcOrderID,
            this.grcOrderType,
            this.gridColumn1,
            this.gridColumn2});
            this.grvConfirmationAll.GridControl = this.grdConfirmationAll;
            this.grvConfirmationAll.Name = "grvConfirmationAll";
            this.grvConfirmationAll.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grvConfirmationAll.OptionsSelection.MultiSelect = true;
            this.grvConfirmationAll.OptionsView.ShowFooter = true;
            this.grvConfirmationAll.OptionsView.ShowGroupPanel = false;
            this.grvConfirmationAll.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvConfirmationAll.PaintStyleName = "Skin";
            this.grvConfirmationAll.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.grvConfirmationAll_RowCellStyle);
            // 
            // grcOrderDate
            // 
            this.grcOrderDate.AppearanceCell.Options.UseTextOptions = true;
            this.grcOrderDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcOrderDate.AppearanceHeader.Options.UseTextOptions = true;
            this.grcOrderDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcOrderDate.Caption = "ORDER DATE";
            this.grcOrderDate.FieldName = "OrderDate";
            this.grcOrderDate.Name = "grcOrderDate";
            this.grcOrderDate.OptionsColumn.AllowEdit = false;
            this.grcOrderDate.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "OrderDate", "{0}")});
            this.grcOrderDate.Visible = true;
            this.grcOrderDate.VisibleIndex = 1;
            this.grcOrderDate.Width = 123;
            // 
            // grcCreateDate
            // 
            this.grcCreateDate.AppearanceCell.Options.UseTextOptions = true;
            this.grcCreateDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcCreateDate.AppearanceHeader.Options.UseTextOptions = true;
            this.grcCreateDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcCreateDate.Caption = "CREATED ";
            this.grcCreateDate.DisplayFormat.FormatString = "g";
            this.grcCreateDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.grcCreateDate.FieldName = "CreateDate";
            this.grcCreateDate.Name = "grcCreateDate";
            this.grcCreateDate.OptionsColumn.AllowEdit = false;
            this.grcCreateDate.Visible = true;
            this.grcCreateDate.VisibleIndex = 4;
            this.grcCreateDate.Width = 168;
            // 
            // grcEndTime
            // 
            this.grcEndTime.AppearanceCell.Options.UseTextOptions = true;
            this.grcEndTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcEndTime.AppearanceHeader.Options.UseTextOptions = true;
            this.grcEndTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcEndTime.Caption = "END TIME";
            this.grcEndTime.DisplayFormat.FormatString = "g";
            this.grcEndTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.grcEndTime.FieldName = "EndTime";
            this.grcEndTime.Name = "grcEndTime";
            this.grcEndTime.OptionsColumn.AllowEdit = false;
            this.grcEndTime.Visible = true;
            this.grcEndTime.VisibleIndex = 5;
            this.grcEndTime.Width = 168;
            // 
            // grcTransactionID
            // 
            this.grcTransactionID.AppearanceCell.Options.UseTextOptions = true;
            this.grcTransactionID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcTransactionID.AppearanceHeader.Options.UseTextOptions = true;
            this.grcTransactionID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcTransactionID.Caption = "TRANSACTION";
            this.grcTransactionID.FieldName = "transactionID";
            this.grcTransactionID.Name = "grcTransactionID";
            this.grcTransactionID.OptionsColumn.AllowEdit = false;
            this.grcTransactionID.Visible = true;
            this.grcTransactionID.VisibleIndex = 6;
            this.grcTransactionID.Width = 79;
            // 
            // grcCustomerNumber
            // 
            this.grcCustomerNumber.AppearanceHeader.Options.UseTextOptions = true;
            this.grcCustomerNumber.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcCustomerNumber.Caption = "CUSTOMER";
            this.grcCustomerNumber.FieldName = "CustomerNumber";
            this.grcCustomerNumber.Name = "grcCustomerNumber";
            this.grcCustomerNumber.OptionsColumn.AllowEdit = false;
            this.grcCustomerNumber.Visible = true;
            this.grcCustomerNumber.VisibleIndex = 2;
            this.grcCustomerNumber.Width = 104;
            // 
            // grcUserName
            // 
            this.grcUserName.AppearanceCell.Options.UseTextOptions = true;
            this.grcUserName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcUserName.AppearanceHeader.Options.UseTextOptions = true;
            this.grcUserName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcUserName.Caption = "USER ";
            this.grcUserName.FieldName = "username";
            this.grcUserName.Name = "grcUserName";
            this.grcUserName.OptionsColumn.AllowEdit = false;
            this.grcUserName.Visible = true;
            this.grcUserName.VisibleIndex = 7;
            this.grcUserName.Width = 69;
            // 
            // grcCustomerRef
            // 
            this.grcCustomerRef.AppearanceHeader.Options.UseTextOptions = true;
            this.grcCustomerRef.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcCustomerRef.Caption = "TRUCK/NOTE";
            this.grcCustomerRef.FieldName = "customerref";
            this.grcCustomerRef.Name = "grcCustomerRef";
            this.grcCustomerRef.OptionsColumn.AllowEdit = false;
            this.grcCustomerRef.Visible = true;
            this.grcCustomerRef.VisibleIndex = 8;
            this.grcCustomerRef.Width = 139;
            // 
            // grcOrderNumber
            // 
            this.grcOrderNumber.AppearanceCell.Options.UseTextOptions = true;
            this.grcOrderNumber.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcOrderNumber.AppearanceHeader.Options.UseTextOptions = true;
            this.grcOrderNumber.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcOrderNumber.Caption = "ORDER NO.";
            this.grcOrderNumber.ColumnEdit = this.rpi_hpl_OrderNumber;
            this.grcOrderNumber.FieldName = "ordernumber";
            this.grcOrderNumber.Name = "grcOrderNumber";
            this.grcOrderNumber.Visible = true;
            this.grcOrderNumber.VisibleIndex = 0;
            this.grcOrderNumber.Width = 107;
            // 
            // rpi_hpl_OrderNumber
            // 
            this.rpi_hpl_OrderNumber.AutoHeight = false;
            this.rpi_hpl_OrderNumber.Name = "rpi_hpl_OrderNumber";
            // 
            // grcOrderID
            // 
            this.grcOrderID.Caption = "ORDER ID";
            this.grcOrderID.FieldName = "ID";
            this.grcOrderID.Name = "grcOrderID";
            this.grcOrderID.OptionsColumn.AllowEdit = false;
            // 
            // grcOrderType
            // 
            this.grcOrderType.Caption = "ORDER TYPE";
            this.grcOrderType.FieldName = "ordertype";
            this.grcOrderType.Name = "grcOrderType";
            this.grcOrderType.OptionsColumn.AllowEdit = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "statusname";
            this.gridColumn1.FieldName = "statusname";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Customer Name";
            this.gridColumn2.FieldName = "CustomerName";
            this.gridColumn2.MinWidth = 25;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 3;
            this.gridColumn2.Width = 398;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.emptySpaceItem1,
            this.emptySpaceItem2,
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(6, 6, 6, 6);
            this.layoutControlGroup1.Size = new System.Drawing.Size(1402, 676);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdConfirmationAll;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1382, 602);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnClose;
            this.layoutControlItem5.Location = new System.Drawing.Point(1249, 602);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(133, 54);
            this.layoutControlItem5.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.rdgFilterType;
            this.layoutControlItem6.Location = new System.Drawing.Point(437, 602);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(463, 54);
            this.layoutControlItem6.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(900, 602);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(349, 54);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(266, 602);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(171, 54);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnRefresh;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 602);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(133, 54);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnCloseStock;
            this.layoutControlItem3.Location = new System.Drawing.Point(133, 602);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(133, 54);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // frm_WM_ConfirmationAll
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1402, 727);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_WM_ConfirmationAll.IconOptions.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_WM_ConfirmationAll";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "Confirmation";
            this.Load += new System.EventHandler(this.frm_WM_ConfirmationAll_Load);
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rdgFilterType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdConfirmationAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvConfirmationAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_hpl_OrderNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl grdConfirmationAll;
        private Common.Controls.WMSGridView grvConfirmationAll;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn grcOrderDate;
        private DevExpress.XtraGrid.Columns.GridColumn grcCreateDate;
        private DevExpress.XtraGrid.Columns.GridColumn grcEndTime;
        private DevExpress.XtraGrid.Columns.GridColumn grcTransactionID;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerNumber;
        private DevExpress.XtraGrid.Columns.GridColumn grcUserName;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerRef;
        private DevExpress.XtraGrid.Columns.GridColumn grcOrderNumber;
        private DevExpress.XtraGrid.Columns.GridColumn grcOrderID;
        private DevExpress.XtraGrid.Columns.GridColumn grcOrderType;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnCloseStock;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.RadioGroup rdgFilterType;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpi_hpl_OrderNumber;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}