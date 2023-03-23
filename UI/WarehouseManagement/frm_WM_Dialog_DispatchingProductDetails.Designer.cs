namespace UI.WarehouseManagement
{
    partial class frm_WM_Dialog_DispatchingProductDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_WM_Dialog_DispatchingProductDetails));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grdDispatchedDetail = new DevExpress.XtraGrid.GridControl();
            this.grvDispatchedDetail = new Common.Controls.WMSGridView();
            this.grcOrderDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcOrderNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_hle_OpenRO = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.grcOriginalQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcReceivedQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerRef = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcVehicle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcProductionDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcUseByDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnPalletInfo = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDispatchedDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDispatchedDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_hle_OpenRO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // rbcbase
            // 
            this.rbcbase.ExpandCollapseItem.Id = 0;
            this.rbcbase.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbcbase.OptionsCustomizationForm.FormIcon = ((System.Drawing.Icon)(resources.GetObject("resource.FormIcon")));
            // 
            // 
            // 
            this.rbcbase.SearchEditItem.AccessibleName = "Search Item";
            this.rbcbase.SearchEditItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.rbcbase.SearchEditItem.EditWidth = 150;
            this.rbcbase.SearchEditItem.Id = -5000;
            this.rbcbase.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.rbcbase.Size = new System.Drawing.Size(1291, 51);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grdDispatchedDetail);
            this.layoutControl1.Controls.Add(this.btnPalletInfo);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 51);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(546, 120, 450, 400);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1291, 434);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grdDispatchedDetail
            // 
            this.grdDispatchedDetail.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdDispatchedDetail.Location = new System.Drawing.Point(12, 12);
            this.grdDispatchedDetail.MainView = this.grvDispatchedDetail;
            this.grdDispatchedDetail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdDispatchedDetail.MenuManager = this.rbcbase;
            this.grdDispatchedDetail.Name = "grdDispatchedDetail";
            this.grdDispatchedDetail.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpi_hle_OpenRO});
            this.grdDispatchedDetail.Size = new System.Drawing.Size(1267, 366);
            this.grdDispatchedDetail.TabIndex = 4;
            this.grdDispatchedDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDispatchedDetail});
            // 
            // grvDispatchedDetail
            // 
            this.grvDispatchedDetail.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grvDispatchedDetail.Appearance.FooterPanel.Options.UseFont = true;
            this.grvDispatchedDetail.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvDispatchedDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grcOrderDate,
            this.grcOrderNumber,
            this.grcOriginalQty,
            this.grcReceivedQty,
            this.grcCustomerRef,
            this.grcRemark,
            this.grcVehicle,
            this.grcProductionDate,
            this.grcUseByDate});
            this.grvDispatchedDetail.GridControl = this.grdDispatchedDetail;
            this.grvDispatchedDetail.Name = "grvDispatchedDetail";
            this.grvDispatchedDetail.OptionsBehavior.ReadOnly = true;
            this.grvDispatchedDetail.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grvDispatchedDetail.OptionsSelection.MultiSelect = true;
            this.grvDispatchedDetail.OptionsView.ShowFooter = true;
            this.grvDispatchedDetail.OptionsView.ShowGroupPanel = false;
            this.grvDispatchedDetail.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvDispatchedDetail.PaintStyleName = "Skin";
            // 
            // grcOrderDate
            // 
            this.grcOrderDate.AppearanceCell.Options.UseTextOptions = true;
            this.grcOrderDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcOrderDate.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcOrderDate.AppearanceHeader.Options.UseTextOptions = true;
            this.grcOrderDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcOrderDate.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcOrderDate.Caption = "Order Date";
            this.grcOrderDate.FieldName = "ReceivingOrderDate";
            this.grcOrderDate.MinWidth = 10;
            this.grcOrderDate.Name = "grcOrderDate";
            this.grcOrderDate.OptionsColumn.ReadOnly = true;
            this.grcOrderDate.Visible = true;
            this.grcOrderDate.VisibleIndex = 0;
            this.grcOrderDate.Width = 126;
            // 
            // grcOrderNumber
            // 
            this.grcOrderNumber.AppearanceCell.Options.UseTextOptions = true;
            this.grcOrderNumber.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcOrderNumber.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcOrderNumber.AppearanceHeader.Options.UseTextOptions = true;
            this.grcOrderNumber.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcOrderNumber.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcOrderNumber.Caption = "Order No.";
            this.grcOrderNumber.ColumnEdit = this.rpi_hle_OpenRO;
            this.grcOrderNumber.FieldName = "ReceivingOrderNumber";
            this.grcOrderNumber.MinWidth = 10;
            this.grcOrderNumber.Name = "grcOrderNumber";
            this.grcOrderNumber.OptionsColumn.ReadOnly = true;
            this.grcOrderNumber.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ReceivingOrderNumber", "TOTAL:")});
            this.grcOrderNumber.Visible = true;
            this.grcOrderNumber.VisibleIndex = 1;
            this.grcOrderNumber.Width = 126;
            // 
            // rpi_hle_OpenRO
            // 
            this.rpi_hle_OpenRO.AutoHeight = false;
            this.rpi_hle_OpenRO.Name = "rpi_hle_OpenRO";
            this.rpi_hle_OpenRO.Click += new System.EventHandler(this.rpi_hle_OpenRO_Click);
            // 
            // grcOriginalQty
            // 
            this.grcOriginalQty.AppearanceCell.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Question;
            this.grcOriginalQty.AppearanceCell.Options.UseForeColor = true;
            this.grcOriginalQty.AppearanceCell.Options.UseTextOptions = true;
            this.grcOriginalQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grcOriginalQty.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcOriginalQty.AppearanceHeader.Options.UseTextOptions = true;
            this.grcOriginalQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grcOriginalQty.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcOriginalQty.Caption = "R";
            this.grcOriginalQty.FieldName = "OriginalReceivedQty";
            this.grcOriginalQty.MaxWidth = 50;
            this.grcOriginalQty.MinWidth = 50;
            this.grcOriginalQty.Name = "grcOriginalQty";
            this.grcOriginalQty.OptionsColumn.ReadOnly = true;
            this.grcOriginalQty.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OriginalReceivedQty", "{0:n0}")});
            this.grcOriginalQty.Visible = true;
            this.grcOriginalQty.VisibleIndex = 2;
            this.grcOriginalQty.Width = 50;
            // 
            // grcReceivedQty
            // 
            this.grcReceivedQty.AppearanceCell.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Critical;
            this.grcReceivedQty.AppearanceCell.Options.UseForeColor = true;
            this.grcReceivedQty.AppearanceCell.Options.UseTextOptions = true;
            this.grcReceivedQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grcReceivedQty.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcReceivedQty.AppearanceHeader.Options.UseTextOptions = true;
            this.grcReceivedQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grcReceivedQty.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcReceivedQty.Caption = "D";
            this.grcReceivedQty.FieldName = "ReceivedQty";
            this.grcReceivedQty.MaxWidth = 50;
            this.grcReceivedQty.MinWidth = 50;
            this.grcReceivedQty.Name = "grcReceivedQty";
            this.grcReceivedQty.OptionsColumn.ReadOnly = true;
            this.grcReceivedQty.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ReceivedQty", "{0:n0}")});
            this.grcReceivedQty.Visible = true;
            this.grcReceivedQty.VisibleIndex = 3;
            this.grcReceivedQty.Width = 50;
            // 
            // grcCustomerRef
            // 
            this.grcCustomerRef.AppearanceCell.Options.UseTextOptions = true;
            this.grcCustomerRef.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcCustomerRef.AppearanceHeader.Options.UseTextOptions = true;
            this.grcCustomerRef.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcCustomerRef.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcCustomerRef.Caption = "Customer Ref";
            this.grcCustomerRef.FieldName = "CustomerRef";
            this.grcCustomerRef.MinWidth = 10;
            this.grcCustomerRef.Name = "grcCustomerRef";
            this.grcCustomerRef.OptionsColumn.ReadOnly = true;
            this.grcCustomerRef.Visible = true;
            this.grcCustomerRef.VisibleIndex = 4;
            this.grcCustomerRef.Width = 241;
            // 
            // grcRemark
            // 
            this.grcRemark.AppearanceCell.Options.UseTextOptions = true;
            this.grcRemark.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcRemark.AppearanceHeader.Options.UseTextOptions = true;
            this.grcRemark.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcRemark.Caption = "Remark";
            this.grcRemark.FieldName = "Remark";
            this.grcRemark.MinWidth = 10;
            this.grcRemark.Name = "grcRemark";
            this.grcRemark.OptionsColumn.ReadOnly = true;
            this.grcRemark.Visible = true;
            this.grcRemark.VisibleIndex = 5;
            this.grcRemark.Width = 147;
            // 
            // grcVehicle
            // 
            this.grcVehicle.AppearanceCell.Options.UseTextOptions = true;
            this.grcVehicle.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcVehicle.AppearanceHeader.Options.UseTextOptions = true;
            this.grcVehicle.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcVehicle.Caption = "Vehicle";
            this.grcVehicle.FieldName = "RORemark";
            this.grcVehicle.Name = "grcVehicle";
            this.grcVehicle.OptionsColumn.ReadOnly = true;
            this.grcVehicle.Visible = true;
            this.grcVehicle.VisibleIndex = 6;
            this.grcVehicle.Width = 228;
            // 
            // grcProductionDate
            // 
            this.grcProductionDate.AppearanceCell.Options.UseTextOptions = true;
            this.grcProductionDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcProductionDate.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcProductionDate.AppearanceHeader.Options.UseTextOptions = true;
            this.grcProductionDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcProductionDate.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcProductionDate.Caption = "Pro.Date";
            this.grcProductionDate.FieldName = "ProductionDate";
            this.grcProductionDate.MinWidth = 10;
            this.grcProductionDate.Name = "grcProductionDate";
            this.grcProductionDate.OptionsColumn.ReadOnly = true;
            this.grcProductionDate.Visible = true;
            this.grcProductionDate.VisibleIndex = 7;
            this.grcProductionDate.Width = 175;
            // 
            // grcUseByDate
            // 
            this.grcUseByDate.AppearanceCell.Options.UseTextOptions = true;
            this.grcUseByDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcUseByDate.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcUseByDate.AppearanceHeader.Options.UseTextOptions = true;
            this.grcUseByDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcUseByDate.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcUseByDate.Caption = "Exp.Date";
            this.grcUseByDate.FieldName = "UseByDate";
            this.grcUseByDate.MinWidth = 10;
            this.grcUseByDate.Name = "grcUseByDate";
            this.grcUseByDate.OptionsColumn.ReadOnly = true;
            this.grcUseByDate.Visible = true;
            this.grcUseByDate.VisibleIndex = 8;
            this.grcUseByDate.Width = 176;
            // 
            // btnPalletInfo
            // 
            this.btnPalletInfo.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Question;
            this.btnPalletInfo.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnPalletInfo.Appearance.Options.UseBackColor = true;
            this.btnPalletInfo.Appearance.Options.UseFont = true;
            this.btnPalletInfo.Appearance.Options.UseTextOptions = true;
            this.btnPalletInfo.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.btnPalletInfo.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnPalletInfo.AppearanceDisabled.Options.UseTextOptions = true;
            this.btnPalletInfo.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnPalletInfo.AppearanceHovered.Options.UseTextOptions = true;
            this.btnPalletInfo.AppearanceHovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnPalletInfo.AppearancePressed.Options.UseTextOptions = true;
            this.btnPalletInfo.AppearancePressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnPalletInfo.ImageOptions.SvgImageSize = new System.Drawing.Size(24, 24);
            this.btnPalletInfo.Location = new System.Drawing.Point(1154, 382);
            this.btnPalletInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPalletInfo.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnPalletInfo.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnPalletInfo.Name = "btnPalletInfo";
            this.btnPalletInfo.Size = new System.Drawing.Size(125, 40);
            this.btnPalletInfo.StyleController = this.layoutControl1;
            this.btnPalletInfo.TabIndex = 5;
            this.btnPalletInfo.Text = "Pallet Info";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1291, 434);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdDispatchedDetail;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1271, 370);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnPalletInfo;
            this.layoutControlItem2.Location = new System.Drawing.Point(1142, 370);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(129, 44);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 370);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(1142, 44);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frm_WM_Dialog_DispatchingProductDetails
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1291, 485);
            this.Controls.Add(this.layoutControl1);
            this.Enabled = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_WM_Dialog_DispatchingProductDetails.IconOptions.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frm_WM_Dialog_DispatchingProductDetails";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "Dispatching Product is dispatched from";
            this.Load += new System.EventHandler(this.frm_WM_Dialog_DispatchingProductDetails_Load);
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDispatchedDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDispatchedDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_hle_OpenRO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl grdDispatchedDetail;
        private Common.Controls.WMSGridView grvDispatchedDetail;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn grcOrderDate;
        private DevExpress.XtraGrid.Columns.GridColumn grcOrderNumber;
        private DevExpress.XtraGrid.Columns.GridColumn grcOriginalQty;
        private DevExpress.XtraGrid.Columns.GridColumn grcReceivedQty;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerRef;
        private DevExpress.XtraGrid.Columns.GridColumn grcRemark;
        private DevExpress.XtraGrid.Columns.GridColumn grcVehicle;
        private DevExpress.XtraGrid.Columns.GridColumn grcProductionDate;
        private DevExpress.XtraGrid.Columns.GridColumn grcUseByDate;
        private DevExpress.XtraEditors.SimpleButton btnPalletInfo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpi_hle_OpenRO;
    }
}