namespace UI.WarehouseManagement
{
    partial class frm_WM_WavePicking
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_WM_WavePicking));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.rdDispatchingOrderType = new DevExpress.XtraEditors.RadioGroup();
            this.txtRoom = new DevExpress.XtraEditors.TextEdit();
            this.meWavePickingRemark = new DevExpress.XtraEditors.MemoEdit();
            this.teServiceName = new DevExpress.XtraEditors.TextEdit();
            this.teTemp = new DevExpress.XtraEditors.TextEdit();
            this.teCustomerName = new DevExpress.XtraEditors.TextEdit();
            this.grdWavePickingDetails = new DevExpress.XtraGrid.GridControl();
            this.grvWavePickingDetails = new Common.Controls.WMSGridView();
            this.grdcolOrderNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_hpl_OrderNumber = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.grdcolCustomer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdcolPallet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdcolCtns = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdcolUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdcolWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdcolRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdcolClient = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ri_lke_CustomerClientID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.grdcolUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDispatchingOrderList = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ri_lke_OrderNumber = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.teInternal = new DevExpress.XtraEditors.TextEdit();
            this.txtCreatedTime = new DevExpress.XtraEditors.TextEdit();
            this.txtCreatedBy = new DevExpress.XtraEditors.TextEdit();
            this.teSeal = new DevExpress.XtraEditors.TextEdit();
            this.teDock = new DevExpress.XtraEditors.TextEdit();
            this.txtWavePinkingNumber = new DevExpress.XtraEditors.TextEdit();
            this.lkeCustomerNumber = new DevExpress.XtraEditors.LookUpEdit();
            this.dWavePickingDate = new DevExpress.XtraEditors.DateEdit();
            this.lkeOneClient = new DevExpress.XtraEditors.LookUpEdit();
            this.lkeServiceNumber = new DevExpress.XtraEditors.LookUpEdit();
            this.dtStartTime = new DevExpress.XtraEditors.DateEdit();
            this.dtEndTime = new DevExpress.XtraEditors.DateEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem16 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem17 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem18 = new DevExpress.XtraLayout.LayoutControlItem();
            this.barButtonItem8 = new DevExpress.XtraBars.BarButtonItem();
            this.btnReceivingAdvice = new DevExpress.XtraBars.BarButtonItem();
            this.btnDispatchingPlan = new DevExpress.XtraBars.BarButtonItem();
            this.btnPickingSlips = new DevExpress.XtraBars.BarButtonItem();
            this.btnPickingSlipByProduct = new DevExpress.XtraBars.BarButtonItem();
            this.btnPickingSlipFull = new DevExpress.XtraBars.BarButtonItem();
            this.btnShowOnlyEmptyOrders = new DevExpress.XtraBars.BarButtonItem();
            this.btnPickingSlipDecalLabel = new DevExpress.XtraBars.BarButtonItem();
            this.bbuton_WavePickingSummary = new DevExpress.XtraBars.BarButtonItem();
            this.bb_WavePicking_PickingList = new DevExpress.XtraBars.BarButtonItem();
            this.bbtn_ViewWavePickingSlipSummary = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.bb_EDI_Process = new DevExpress.XtraBars.BarButtonItem();
            this.bb_EDI_Refresh = new DevExpress.XtraBars.BarButtonItem();
            this.bb_WavePicking_Refresh = new DevExpress.XtraBars.BarButtonItem();
            this.bb_WavePicking_PalletLabel = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdDispatchingOrderType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRoom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meWavePickingRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teServiceName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teTemp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teCustomerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdWavePickingDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvWavePickingDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_hpl_OrderNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ri_lke_CustomerClientID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ri_lke_OrderNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teInternal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreatedTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreatedBy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teSeal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teDock.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWavePinkingNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeCustomerNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dWavePickingDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dWavePickingDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeOneClient.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeServiceNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStartTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStartTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEndTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEndTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).BeginInit();
            this.SuspendLayout();
            // 
            // rbcbase
            // 
            this.rbcbase.ExpandCollapseItem.Id = 0;
            this.rbcbase.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem8,
            this.btnReceivingAdvice,
            this.btnDispatchingPlan,
            this.btnPickingSlips,
            this.btnPickingSlipByProduct,
            this.btnPickingSlipFull,
            this.btnShowOnlyEmptyOrders,
            this.btnPickingSlipDecalLabel,
            this.bbuton_WavePickingSummary,
            this.bb_WavePicking_PickingList,
            this.bbtn_ViewWavePickingSlipSummary,
            this.bb_WavePicking_Refresh,
            this.bb_EDI_Process,
            this.bb_EDI_Refresh,
            this.bb_WavePicking_PalletLabel});
            this.rbcbase.MaxItemId = 27;
            this.rbcbase.OptionsCustomizationForm.FormIcon = ((System.Drawing.Icon)(resources.GetObject("resource.FormIcon")));
            // 
            // 
            // 
            this.rbcbase.SearchEditItem.AccessibleName = "Search Item";
            this.rbcbase.SearchEditItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.rbcbase.SearchEditItem.EditWidth = 150;
            this.rbcbase.SearchEditItem.Id = -5000;
            this.rbcbase.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.rbcbase.Size = new System.Drawing.Size(1657, 155);
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnReceivingAdvice);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnDispatchingPlan);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnPickingSlips);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnPickingSlipDecalLabel);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnPickingSlipByProduct);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnPickingSlipFull);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnShowOnlyEmptyOrders);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbuton_WavePickingSummary);
            this.ribbonPageGroup1.ItemLinks.Add(this.bb_WavePicking_PickingList);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbtn_ViewWavePickingSlipSummary);
            this.ribbonPageGroup1.ItemLinks.Add(this.bb_WavePicking_Refresh);
            this.ribbonPageGroup1.ItemLinks.Add(this.bb_WavePicking_PalletLabel);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.rdDispatchingOrderType);
            this.layoutControl1.Controls.Add(this.txtRoom);
            this.layoutControl1.Controls.Add(this.meWavePickingRemark);
            this.layoutControl1.Controls.Add(this.teServiceName);
            this.layoutControl1.Controls.Add(this.teTemp);
            this.layoutControl1.Controls.Add(this.teCustomerName);
            this.layoutControl1.Controls.Add(this.grdWavePickingDetails);
            this.layoutControl1.Controls.Add(this.teInternal);
            this.layoutControl1.Controls.Add(this.txtCreatedTime);
            this.layoutControl1.Controls.Add(this.txtCreatedBy);
            this.layoutControl1.Controls.Add(this.teSeal);
            this.layoutControl1.Controls.Add(this.teDock);
            this.layoutControl1.Controls.Add(this.txtWavePinkingNumber);
            this.layoutControl1.Controls.Add(this.lkeCustomerNumber);
            this.layoutControl1.Controls.Add(this.dWavePickingDate);
            this.layoutControl1.Controls.Add(this.lkeOneClient);
            this.layoutControl1.Controls.Add(this.lkeServiceNumber);
            this.layoutControl1.Controls.Add(this.dtStartTime);
            this.layoutControl1.Controls.Add(this.dtEndTime);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 155);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(242, 79, 450, 400);
            this.layoutControl1.OptionsFocus.EnableAutoTabOrder = false;
            this.layoutControl1.OptionsFocus.MoveFocusDirection = DevExpress.XtraLayout.MoveFocusDirection.DownThenAcross;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1657, 632);
            this.layoutControl1.TabIndex = 11;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // rdDispatchingOrderType
            // 
            this.rdDispatchingOrderType.Location = new System.Drawing.Point(1330, 77);
            this.rdDispatchingOrderType.MenuManager = this.rbcbase;
            this.rdDispatchingOrderType.Name = "rdDispatchingOrderType";
            this.rdDispatchingOrderType.Properties.Columns = 4;
            this.rdDispatchingOrderType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "All", true, 1),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Time", true, 2),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Unfinished", true, 3)});
            this.rdDispatchingOrderType.Size = new System.Drawing.Size(314, 46);
            this.rdDispatchingOrderType.StyleController = this.layoutControl1;
            this.rdDispatchingOrderType.TabIndex = 26;
            // 
            // txtRoom
            // 
            this.txtRoom.Location = new System.Drawing.Point(868, 77);
            this.txtRoom.MenuManager = this.rbcbase;
            this.txtRoom.MinimumSize = new System.Drawing.Size(0, 24);
            this.txtRoom.Name = "txtRoom";
            this.txtRoom.Size = new System.Drawing.Size(210, 26);
            this.txtRoom.StyleController = this.layoutControl1;
            this.txtRoom.TabIndex = 25;
            // 
            // meWavePickingRemark
            // 
            this.meWavePickingRemark.Location = new System.Drawing.Point(239, 45);
            this.meWavePickingRemark.MenuManager = this.rbcbase;
            this.meWavePickingRemark.Name = "meWavePickingRemark";
            this.meWavePickingRemark.Size = new System.Drawing.Size(565, 78);
            this.meWavePickingRemark.StyleController = this.layoutControl1;
            this.meWavePickingRemark.TabIndex = 2;
            // 
            // teServiceName
            // 
            this.teServiceName.Location = new System.Drawing.Point(1501, 13);
            this.teServiceName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.teServiceName.MenuManager = this.rbcbase;
            this.teServiceName.MinimumSize = new System.Drawing.Size(0, 24);
            this.teServiceName.Name = "teServiceName";
            this.teServiceName.Properties.ReadOnly = true;
            this.teServiceName.Size = new System.Drawing.Size(143, 26);
            this.teServiceName.StyleController = this.layoutControl1;
            this.teServiceName.TabIndex = 24;
            // 
            // teTemp
            // 
            this.teTemp.Location = new System.Drawing.Point(868, 13);
            this.teTemp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.teTemp.MenuManager = this.rbcbase;
            this.teTemp.MinimumSize = new System.Drawing.Size(0, 24);
            this.teTemp.Name = "teTemp";
            this.teTemp.Size = new System.Drawing.Size(89, 26);
            this.teTemp.StyleController = this.layoutControl1;
            this.teTemp.TabIndex = 3;
            // 
            // teCustomerName
            // 
            this.teCustomerName.Location = new System.Drawing.Point(438, 13);
            this.teCustomerName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.teCustomerName.MenuManager = this.rbcbase;
            this.teCustomerName.MinimumSize = new System.Drawing.Size(0, 24);
            this.teCustomerName.Name = "teCustomerName";
            this.teCustomerName.Properties.ReadOnly = true;
            this.teCustomerName.Size = new System.Drawing.Size(366, 26);
            this.teCustomerName.StyleController = this.layoutControl1;
            this.teCustomerName.TabIndex = 22;
            // 
            // grdWavePickingDetails
            // 
            this.grdWavePickingDetails.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.grdWavePickingDetails.Location = new System.Drawing.Point(12, 128);
            this.grdWavePickingDetails.MainView = this.grvWavePickingDetails;
            this.grdWavePickingDetails.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdWavePickingDetails.MenuManager = this.rbcbase;
            this.grdWavePickingDetails.Name = "grdWavePickingDetails";
            this.grdWavePickingDetails.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpi_hpl_OrderNumber,
            this.ri_lke_CustomerClientID,
            this.ri_lke_OrderNumber});
            this.grdWavePickingDetails.Size = new System.Drawing.Size(1633, 492);
            this.grdWavePickingDetails.TabIndex = 20;
            this.grdWavePickingDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvWavePickingDetails});
            // 
            // grvWavePickingDetails
            // 
            this.grvWavePickingDetails.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grvWavePickingDetails.Appearance.FooterPanel.Options.UseFont = true;
            this.grvWavePickingDetails.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvWavePickingDetails.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdcolOrderNumber,
            this.grdcolCustomer,
            this.grdcolPallet,
            this.grdcolCtns,
            this.grdcolUnit,
            this.grdcolWeight,
            this.grdcolRemark,
            this.grdcolClient,
            this.grdcolUser,
            this.colDispatchingOrderList,
            this.gridColumn1});
            this.grvWavePickingDetails.FixedLineWidth = 3;
            this.grvWavePickingDetails.GridControl = this.grdWavePickingDetails;
            this.grvWavePickingDetails.Name = "grvWavePickingDetails";
            this.grvWavePickingDetails.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseUp;
            this.grvWavePickingDetails.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grvWavePickingDetails.OptionsSelection.CheckBoxSelectorColumnWidth = 25;
            this.grvWavePickingDetails.OptionsSelection.MultiSelect = true;
            this.grvWavePickingDetails.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.grvWavePickingDetails.OptionsView.ShowFooter = true;
            this.grvWavePickingDetails.OptionsView.ShowGroupPanel = false;
            this.grvWavePickingDetails.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvWavePickingDetails.PaintStyleName = "Skin";
            this.grvWavePickingDetails.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.grvWavePickingDetails_RowCellClick);
            this.grvWavePickingDetails.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvWavePickingDetails_KeyDown);
            // 
            // grdcolOrderNumber
            // 
            this.grdcolOrderNumber.AppearanceCell.FontStyleDelta = System.Drawing.FontStyle.Underline;
            this.grdcolOrderNumber.AppearanceCell.ForeColor = System.Drawing.Color.Blue;
            this.grdcolOrderNumber.AppearanceCell.Options.UseFont = true;
            this.grdcolOrderNumber.AppearanceCell.Options.UseForeColor = true;
            this.grdcolOrderNumber.Caption = "ORDER NUMBER";
            this.grdcolOrderNumber.ColumnEdit = this.rpi_hpl_OrderNumber;
            this.grdcolOrderNumber.FieldName = "OrderNumber";
            this.grdcolOrderNumber.Name = "grdcolOrderNumber";
            this.grdcolOrderNumber.OptionsColumn.ReadOnly = true;
            this.grdcolOrderNumber.Visible = true;
            this.grdcolOrderNumber.VisibleIndex = 2;
            this.grdcolOrderNumber.Width = 121;
            // 
            // rpi_hpl_OrderNumber
            // 
            this.rpi_hpl_OrderNumber.AutoHeight = false;
            this.rpi_hpl_OrderNumber.Name = "rpi_hpl_OrderNumber";
            // 
            // grdcolCustomer
            // 
            this.grdcolCustomer.Caption = "ACCOUNT";
            this.grdcolCustomer.FieldName = "CustomerNumber";
            this.grdcolCustomer.Name = "grdcolCustomer";
            this.grdcolCustomer.OptionsColumn.ReadOnly = true;
            this.grdcolCustomer.Visible = true;
            this.grdcolCustomer.VisibleIndex = 3;
            this.grdcolCustomer.Width = 147;
            // 
            // grdcolPallet
            // 
            this.grdcolPallet.Caption = "PALLET";
            this.grdcolPallet.FieldName = "TotalPallets";
            this.grdcolPallet.Name = "grdcolPallet";
            this.grdcolPallet.OptionsColumn.ReadOnly = true;
            this.grdcolPallet.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPallets", "{0:0.##}")});
            this.grdcolPallet.Visible = true;
            this.grdcolPallet.VisibleIndex = 4;
            this.grdcolPallet.Width = 119;
            // 
            // grdcolCtns
            // 
            this.grdcolCtns.Caption = "CTNS";
            this.grdcolCtns.DisplayFormat.FormatString = "#,##0";
            this.grdcolCtns.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.grdcolCtns.FieldName = "TotalPackages";
            this.grdcolCtns.Name = "grdcolCtns";
            this.grdcolCtns.OptionsColumn.ReadOnly = true;
            this.grdcolCtns.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPackages", "{0:0.##}")});
            this.grdcolCtns.Visible = true;
            this.grdcolCtns.VisibleIndex = 5;
            this.grdcolCtns.Width = 119;
            // 
            // grdcolUnit
            // 
            this.grdcolUnit.Caption = "UNITS";
            this.grdcolUnit.DisplayFormat.FormatString = "#,##0";
            this.grdcolUnit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.grdcolUnit.FieldName = "TotalUnits";
            this.grdcolUnit.Name = "grdcolUnit";
            this.grdcolUnit.Visible = true;
            this.grdcolUnit.VisibleIndex = 6;
            this.grdcolUnit.Width = 69;
            // 
            // grdcolWeight
            // 
            this.grdcolWeight.Caption = "WEIGHT";
            this.grdcolWeight.DisplayFormat.FormatString = "#,##0.0";
            this.grdcolWeight.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.grdcolWeight.FieldName = "TotalWeight";
            this.grdcolWeight.Name = "grdcolWeight";
            this.grdcolWeight.OptionsColumn.ReadOnly = true;
            this.grdcolWeight.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalWeight", "{0:0.##}")});
            this.grdcolWeight.Visible = true;
            this.grdcolWeight.VisibleIndex = 7;
            this.grdcolWeight.Width = 119;
            // 
            // grdcolRemark
            // 
            this.grdcolRemark.Caption = "REMARK";
            this.grdcolRemark.FieldName = "TripDetailRemark";
            this.grdcolRemark.Name = "grdcolRemark";
            this.grdcolRemark.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "TripDetailRemark", "Total Order: {0}")});
            this.grdcolRemark.Visible = true;
            this.grdcolRemark.VisibleIndex = 8;
            this.grdcolRemark.Width = 291;
            // 
            // grdcolClient
            // 
            this.grdcolClient.Caption = "CLIENT";
            this.grdcolClient.ColumnEdit = this.ri_lke_CustomerClientID;
            this.grdcolClient.FieldName = "CustomerClientCode";
            this.grdcolClient.Name = "grdcolClient";
            this.grdcolClient.Visible = true;
            this.grdcolClient.VisibleIndex = 9;
            this.grdcolClient.Width = 339;
            // 
            // ri_lke_CustomerClientID
            // 
            this.ri_lke_CustomerClientID.AutoHeight = false;
            this.ri_lke_CustomerClientID.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.ri_lke_CustomerClientID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ri_lke_CustomerClientID.Name = "ri_lke_CustomerClientID";
            this.ri_lke_CustomerClientID.NullText = "";
            this.ri_lke_CustomerClientID.PopupResizeMode = DevExpress.XtraEditors.Controls.ResizeMode.LiveResize;
            this.ri_lke_CustomerClientID.ShowFooter = false;
            // 
            // grdcolUser
            // 
            this.grdcolUser.Caption = "USER";
            this.grdcolUser.FieldName = "CreatedBy";
            this.grdcolUser.Name = "grdcolUser";
            this.grdcolUser.OptionsColumn.ReadOnly = true;
            this.grdcolUser.Visible = true;
            this.grdcolUser.VisibleIndex = 10;
            this.grdcolUser.Width = 145;
            // 
            // colDispatchingOrderList
            // 
            this.colDispatchingOrderList.ColumnEdit = this.ri_lke_OrderNumber;
            this.colDispatchingOrderList.MaxWidth = 5;
            this.colDispatchingOrderList.MinWidth = 13;
            this.colDispatchingOrderList.Name = "colDispatchingOrderList";
            this.colDispatchingOrderList.Visible = true;
            this.colDispatchingOrderList.VisibleIndex = 1;
            this.colDispatchingOrderList.Width = 13;
            // 
            // ri_lke_OrderNumber
            // 
            this.ri_lke_OrderNumber.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.ri_lke_OrderNumber.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ri_lke_OrderNumber.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DispatchingOrderNumber", "Name28"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name29", "Name29"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DispatchingOrderDate", "Name30"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerNumber", "Name31"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SpecialRequirement", "Name32"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TotalPallets", "Name33"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TotalPackages", "Name34"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TotalWeight", "Name35"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerClientID", "Name36")});
            this.ri_lke_OrderNumber.ImmediatePopup = true;
            this.ri_lke_OrderNumber.Name = "ri_lke_OrderNumber";
            this.ri_lke_OrderNumber.NullText = "";
            this.ri_lke_OrderNumber.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.StartsWith;
            this.ri_lke_OrderNumber.PopupResizeMode = DevExpress.XtraEditors.Controls.ResizeMode.LiveResize;
            this.ri_lke_OrderNumber.PopupWidth = 500;
            this.ri_lke_OrderNumber.ShowFooter = false;
            this.ri_lke_OrderNumber.Click += new System.EventHandler(this.ri_lke_OrderNumber_Click);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "WavePickingDetailID";
            this.gridColumn1.FieldName = "WavePickingDetailID";
            this.gridColumn1.MinWidth = 25;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Width = 94;
            // 
            // teInternal
            // 
            this.teInternal.EditValue = "";
            this.teInternal.Location = new System.Drawing.Point(868, 45);
            this.teInternal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.teInternal.MinimumSize = new System.Drawing.Size(0, 24);
            this.teInternal.Name = "teInternal";
            this.teInternal.Size = new System.Drawing.Size(210, 26);
            this.teInternal.StyleController = this.layoutControl1;
            this.teInternal.TabIndex = 19;
            // 
            // txtCreatedTime
            // 
            this.txtCreatedTime.Location = new System.Drawing.Point(95, 61);
            this.txtCreatedTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCreatedTime.MenuManager = this.rbcbase;
            this.txtCreatedTime.MinimumSize = new System.Drawing.Size(0, 24);
            this.txtCreatedTime.Name = "txtCreatedTime";
            this.txtCreatedTime.Properties.ReadOnly = true;
            this.txtCreatedTime.Size = new System.Drawing.Size(133, 26);
            this.txtCreatedTime.StyleController = this.layoutControl1;
            this.txtCreatedTime.TabIndex = 14;
            // 
            // txtCreatedBy
            // 
            this.txtCreatedBy.Location = new System.Drawing.Point(13, 61);
            this.txtCreatedBy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCreatedBy.MenuManager = this.rbcbase;
            this.txtCreatedBy.MinimumSize = new System.Drawing.Size(0, 24);
            this.txtCreatedBy.Name = "txtCreatedBy";
            this.txtCreatedBy.Properties.ReadOnly = true;
            this.txtCreatedBy.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCreatedBy.Size = new System.Drawing.Size(76, 26);
            this.txtCreatedBy.StyleController = this.layoutControl1;
            this.txtCreatedBy.TabIndex = 12;
            // 
            // teSeal
            // 
            this.teSeal.Location = new System.Drawing.Point(1141, 77);
            this.teSeal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.teSeal.MenuManager = this.rbcbase;
            this.teSeal.MinimumSize = new System.Drawing.Size(0, 24);
            this.teSeal.Name = "teSeal";
            this.teSeal.Size = new System.Drawing.Size(183, 26);
            this.teSeal.StyleController = this.layoutControl1;
            this.teSeal.TabIndex = 5;
            // 
            // teDock
            // 
            this.teDock.Location = new System.Drawing.Point(996, 13);
            this.teDock.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.teDock.MenuManager = this.rbcbase;
            this.teDock.MinimumSize = new System.Drawing.Size(0, 24);
            this.teDock.Name = "teDock";
            this.teDock.Size = new System.Drawing.Size(82, 26);
            this.teDock.StyleController = this.layoutControl1;
            this.teDock.TabIndex = 4;
            // 
            // txtWavePinkingNumber
            // 
            this.txtWavePinkingNumber.Location = new System.Drawing.Point(13, 13);
            this.txtWavePinkingNumber.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtWavePinkingNumber.MenuManager = this.rbcbase;
            this.txtWavePinkingNumber.Name = "txtWavePinkingNumber";
            this.txtWavePinkingNumber.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.txtWavePinkingNumber.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.txtWavePinkingNumber.Properties.Appearance.Options.UseFont = true;
            this.txtWavePinkingNumber.Properties.Appearance.Options.UseForeColor = true;
            this.txtWavePinkingNumber.Properties.Appearance.Options.UseTextOptions = true;
            this.txtWavePinkingNumber.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtWavePinkingNumber.Properties.ReadOnly = true;
            this.txtWavePinkingNumber.Size = new System.Drawing.Size(215, 42);
            this.txtWavePinkingNumber.StyleController = this.layoutControl1;
            this.txtWavePinkingNumber.TabIndex = 4;
            this.txtWavePinkingNumber.TabStop = false;
            // 
            // lkeCustomerNumber
            // 
            this.lkeCustomerNumber.Location = new System.Drawing.Point(299, 13);
            this.lkeCustomerNumber.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lkeCustomerNumber.MaximumSize = new System.Drawing.Size(0, 23);
            this.lkeCustomerNumber.MenuManager = this.rbcbase;
            this.lkeCustomerNumber.MinimumSize = new System.Drawing.Size(87, 24);
            this.lkeCustomerNumber.Name = "lkeCustomerNumber";
            this.lkeCustomerNumber.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkeCustomerNumber.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeCustomerNumber.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerNumber", "Number"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerName", "Name"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerMainID", "CustomerMainID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name9", "Name9")});
            this.lkeCustomerNumber.Properties.NullText = "";
            this.lkeCustomerNumber.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.StartsWith;
            this.lkeCustomerNumber.Properties.PopupResizeMode = DevExpress.XtraEditors.Controls.ResizeMode.LiveResize;
            this.lkeCustomerNumber.Properties.ShowFooter = false;
            this.lkeCustomerNumber.Properties.ShowHeader = false;
            this.lkeCustomerNumber.Size = new System.Drawing.Size(133, 24);
            this.lkeCustomerNumber.StyleController = this.layoutControl1;
            this.lkeCustomerNumber.TabIndex = 1;
            // 
            // dWavePickingDate
            // 
            this.dWavePickingDate.EditValue = null;
            this.dWavePickingDate.Location = new System.Drawing.Point(1141, 13);
            this.dWavePickingDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dWavePickingDate.MenuManager = this.rbcbase;
            this.dWavePickingDate.MinimumSize = new System.Drawing.Size(0, 24);
            this.dWavePickingDate.Name = "dWavePickingDate";
            this.dWavePickingDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dWavePickingDate.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.False;
            this.dWavePickingDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dWavePickingDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dWavePickingDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dWavePickingDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dWavePickingDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dWavePickingDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dWavePickingDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dWavePickingDate.Properties.ReadOnly = true;
            this.dWavePickingDate.Size = new System.Drawing.Size(183, 26);
            this.dWavePickingDate.StyleController = this.layoutControl1;
            this.dWavePickingDate.TabIndex = 6;
            // 
            // lkeOneClient
            // 
            this.lkeOneClient.Location = new System.Drawing.Point(91, 93);
            this.lkeOneClient.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lkeOneClient.MenuManager = this.rbcbase;
            this.lkeOneClient.MinimumSize = new System.Drawing.Size(0, 24);
            this.lkeOneClient.Name = "lkeOneClient";
            this.lkeOneClient.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkeOneClient.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeOneClient.Properties.NullText = "";
            this.lkeOneClient.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.StartsWith;
            this.lkeOneClient.Properties.PopupResizeMode = DevExpress.XtraEditors.Controls.ResizeMode.LiveResize;
            this.lkeOneClient.Properties.ShowFooter = false;
            this.lkeOneClient.Properties.ShowHeader = false;
            this.lkeOneClient.Size = new System.Drawing.Size(137, 26);
            this.lkeOneClient.StyleController = this.layoutControl1;
            this.lkeOneClient.TabIndex = 18;
            // 
            // lkeServiceNumber
            // 
            this.lkeServiceNumber.Location = new System.Drawing.Point(1387, 13);
            this.lkeServiceNumber.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lkeServiceNumber.MenuManager = this.rbcbase;
            this.lkeServiceNumber.MinimumSize = new System.Drawing.Size(0, 24);
            this.lkeServiceNumber.Name = "lkeServiceNumber";
            this.lkeServiceNumber.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkeServiceNumber.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeServiceNumber.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ServiceID", "Name1", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ServiceNumber", "ServiceNumber"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ServiceName", "Name5")});
            this.lkeServiceNumber.Properties.NullText = "";
            this.lkeServiceNumber.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.StartsWith;
            this.lkeServiceNumber.Properties.PopupResizeMode = DevExpress.XtraEditors.Controls.ResizeMode.LiveResize;
            this.lkeServiceNumber.Properties.ShowFooter = false;
            this.lkeServiceNumber.Properties.ShowHeader = false;
            this.lkeServiceNumber.Size = new System.Drawing.Size(108, 26);
            this.lkeServiceNumber.StyleController = this.layoutControl1;
            this.lkeServiceNumber.TabIndex = 15;
            // 
            // dtStartTime
            // 
            this.dtStartTime.EditValue = null;
            this.dtStartTime.Location = new System.Drawing.Point(1141, 45);
            this.dtStartTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtStartTime.MenuManager = this.rbcbase;
            this.dtStartTime.MinimumSize = new System.Drawing.Size(0, 24);
            this.dtStartTime.Name = "dtStartTime";
            this.dtStartTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtStartTime.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtStartTime.Properties.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.dtStartTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtStartTime.Properties.EditFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.dtStartTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtStartTime.Properties.Mask.EditMask = "dd/MM/yyyy HH:mm";
            this.dtStartTime.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtStartTime.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtStartTime.Size = new System.Drawing.Size(183, 26);
            this.dtStartTime.StyleController = this.layoutControl1;
            this.dtStartTime.TabIndex = 6;
            this.dtStartTime.EditValueChanged += new System.EventHandler(this.dtStartTime_EditValueChanged);
            // 
            // dtEndTime
            // 
            this.dtEndTime.EditValue = null;
            this.dtEndTime.Location = new System.Drawing.Point(1387, 45);
            this.dtEndTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtEndTime.MenuManager = this.rbcbase;
            this.dtEndTime.MinimumSize = new System.Drawing.Size(0, 24);
            this.dtEndTime.Name = "dtEndTime";
            this.dtEndTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtEndTime.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtEndTime.Properties.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.dtEndTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtEndTime.Properties.EditFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.dtEndTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtEndTime.Properties.Mask.EditMask = "dd/MM/yyyy HH:mm";
            this.dtEndTime.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtEndTime.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtEndTime.Size = new System.Drawing.Size(257, 26);
            this.dtEndTime.StyleController = this.layoutControl1;
            this.dtEndTime.TabIndex = 7;
            this.dtEndTime.EditValueChanged += new System.EventHandler(this.dtEndTime_EditValueChanged);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem16,
            this.layoutControlItem1,
            this.layoutControlItem12,
            this.layoutControlItem7,
            this.layoutControlItem14,
            this.layoutControlItem8,
            this.layoutControlItem,
            this.layoutControlItem9,
            this.layoutControlItem2,
            this.layoutControlItem13,
            this.emptySpaceItem1,
            this.layoutControlItem3,
            this.emptySpaceItem3,
            this.layoutControlItem17,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem11,
            this.layoutControlItem15,
            this.layoutControlItem10,
            this.layoutControlItem18});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1657, 632);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem16
            // 
            this.layoutControlItem16.Control = this.grdWavePickingDetails;
            this.layoutControlItem16.Location = new System.Drawing.Point(0, 116);
            this.layoutControlItem16.Name = "layoutControlItem16";
            this.layoutControlItem16.Size = new System.Drawing.Size(1637, 496);
            this.layoutControlItem16.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem16.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtWavePinkingNumber;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(221, 48);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem1.Text = "Trip ID";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.meWavePickingRemark;
            this.layoutControlItem12.Location = new System.Drawing.Point(226, 32);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(571, 84);
            this.layoutControlItem12.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem12.Text = "Truck + Details";
            this.layoutControlItem12.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem12.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.dtStartTime;
            this.layoutControlItem7.Location = new System.Drawing.Point(1071, 32);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(246, 32);
            this.layoutControlItem7.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem7.Text = "Start";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(52, 16);
            // 
            // layoutControlItem14
            // 
            this.layoutControlItem14.Control = this.lkeOneClient;
            this.layoutControlItem14.Location = new System.Drawing.Point(0, 80);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Size = new System.Drawing.Size(221, 36);
            this.layoutControlItem14.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem14.Text = "One Client";
            this.layoutControlItem14.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem14.TextSize = new System.Drawing.Size(73, 16);
            this.layoutControlItem14.TextToControlDistance = 5;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.lkeCustomerNumber;
            this.layoutControlItem8.Location = new System.Drawing.Point(226, 0);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(199, 32);
            this.layoutControlItem8.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem8.Text = "Customer";
            this.layoutControlItem8.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem8.TextSize = new System.Drawing.Size(55, 16);
            this.layoutControlItem8.TextToControlDistance = 5;
            // 
            // layoutControlItem
            // 
            this.layoutControlItem.Control = this.teCustomerName;
            this.layoutControlItem.Location = new System.Drawing.Point(425, 0);
            this.layoutControlItem.Name = "layoutControlItem";
            this.layoutControlItem.Size = new System.Drawing.Size(372, 32);
            this.layoutControlItem.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.txtCreatedBy;
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(82, 32);
            this.layoutControlItem9.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem9.Text = "Created";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtCreatedTime;
            this.layoutControlItem2.Location = new System.Drawing.Point(82, 48);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(139, 32);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem2.Text = "Created At";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.Control = this.txtRoom;
            this.layoutControlItem13.Location = new System.Drawing.Point(798, 64);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new System.Drawing.Size(273, 52);
            this.layoutControlItem13.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem13.Text = "Room";
            this.layoutControlItem13.TextSize = new System.Drawing.Size(52, 16);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(221, 0);
            this.emptySpaceItem1.MaxSize = new System.Drawing.Size(5, 5);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(5, 5);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(5, 116);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.dWavePickingDate;
            this.layoutControlItem3.Location = new System.Drawing.Point(1071, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(246, 32);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem3.Text = "Date";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(52, 16);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(797, 0);
            this.emptySpaceItem3.MaxSize = new System.Drawing.Size(1, 1);
            this.emptySpaceItem3.MinSize = new System.Drawing.Size(1, 1);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(1, 116);
            this.emptySpaceItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem17
            // 
            this.layoutControlItem17.Control = this.dtEndTime;
            this.layoutControlItem17.Location = new System.Drawing.Point(1317, 32);
            this.layoutControlItem17.MinSize = new System.Drawing.Size(257, 27);
            this.layoutControlItem17.Name = "layoutControlItem17";
            this.layoutControlItem17.Size = new System.Drawing.Size(320, 32);
            this.layoutControlItem17.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem17.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem17.Text = "End";
            this.layoutControlItem17.TextSize = new System.Drawing.Size(52, 16);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.teTemp;
            this.layoutControlItem4.Location = new System.Drawing.Point(798, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(152, 32);
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem4.Text = "Temp";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(52, 16);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.teDock;
            this.layoutControlItem5.Location = new System.Drawing.Point(950, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(121, 32);
            this.layoutControlItem5.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem5.Text = "Dock";
            this.layoutControlItem5.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(28, 16);
            this.layoutControlItem5.TextToControlDistance = 5;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.teSeal;
            this.layoutControlItem6.Location = new System.Drawing.Point(1071, 64);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(246, 52);
            this.layoutControlItem6.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem6.Text = "Seal";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(52, 16);
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.lkeServiceNumber;
            this.layoutControlItem11.Location = new System.Drawing.Point(1317, 0);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(171, 32);
            this.layoutControlItem11.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem11.Text = "Overtime";
            this.layoutControlItem11.TextSize = new System.Drawing.Size(52, 16);
            // 
            // layoutControlItem15
            // 
            this.layoutControlItem15.Control = this.teInternal;
            this.layoutControlItem15.Location = new System.Drawing.Point(798, 32);
            this.layoutControlItem15.Name = "layoutControlItem15";
            this.layoutControlItem15.Size = new System.Drawing.Size(273, 32);
            this.layoutControlItem15.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem15.Text = "Internal";
            this.layoutControlItem15.TextSize = new System.Drawing.Size(52, 16);
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.teServiceName;
            this.layoutControlItem10.Location = new System.Drawing.Point(1488, 0);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(149, 32);
            this.layoutControlItem10.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem10.TextVisible = false;
            // 
            // layoutControlItem18
            // 
            this.layoutControlItem18.Control = this.rdDispatchingOrderType;
            this.layoutControlItem18.Location = new System.Drawing.Point(1317, 64);
            this.layoutControlItem18.Name = "layoutControlItem18";
            this.layoutControlItem18.Size = new System.Drawing.Size(320, 52);
            this.layoutControlItem18.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem18.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem18.TextVisible = false;
            // 
            // barButtonItem8
            // 
            this.barButtonItem8.Caption = "barButtonItem8";
            this.barButtonItem8.Id = 8;
            this.barButtonItem8.Name = "barButtonItem8";
            // 
            // btnReceivingAdvice
            // 
            this.btnReceivingAdvice.Caption = "Receiving Advice";
            this.btnReceivingAdvice.Id = 10;
            this.btnReceivingAdvice.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnReceivingAdvice.ImageOptions.Image")));
            this.btnReceivingAdvice.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnReceivingAdvice.ImageOptions.LargeImage")));
            this.btnReceivingAdvice.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnReceivingAdvice.ImageOptions.SvgImage")));
            this.btnReceivingAdvice.Name = "btnReceivingAdvice";
            // 
            // btnDispatchingPlan
            // 
            this.btnDispatchingPlan.Caption = "Dispatching Plan";
            this.btnDispatchingPlan.Id = 11;
            this.btnDispatchingPlan.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDispatchingPlan.ImageOptions.Image")));
            this.btnDispatchingPlan.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDispatchingPlan.ImageOptions.LargeImage")));
            this.btnDispatchingPlan.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDispatchingPlan.ImageOptions.SvgImage")));
            this.btnDispatchingPlan.Name = "btnDispatchingPlan";
            // 
            // btnPickingSlips
            // 
            this.btnPickingSlips.Caption = "Picking Slips";
            this.btnPickingSlips.Id = 12;
            this.btnPickingSlips.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPickingSlips.ImageOptions.Image")));
            this.btnPickingSlips.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnPickingSlips.ImageOptions.LargeImage")));
            this.btnPickingSlips.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPickingSlips.ImageOptions.SvgImage")));
            this.btnPickingSlips.Name = "btnPickingSlips";
            // 
            // btnPickingSlipByProduct
            // 
            this.btnPickingSlipByProduct.Caption = "Picking Slips By Product";
            this.btnPickingSlipByProduct.Id = 13;
            this.btnPickingSlipByProduct.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPickingSlipByProduct.ImageOptions.Image")));
            this.btnPickingSlipByProduct.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnPickingSlipByProduct.ImageOptions.LargeImage")));
            this.btnPickingSlipByProduct.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPickingSlipByProduct.ImageOptions.SvgImage")));
            this.btnPickingSlipByProduct.Name = "btnPickingSlipByProduct";
            // 
            // btnPickingSlipFull
            // 
            this.btnPickingSlipFull.Caption = "Picking Slips Full";
            this.btnPickingSlipFull.Id = 14;
            this.btnPickingSlipFull.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPickingSlipFull.ImageOptions.Image")));
            this.btnPickingSlipFull.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnPickingSlipFull.ImageOptions.LargeImage")));
            this.btnPickingSlipFull.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPickingSlipFull.ImageOptions.SvgImage")));
            this.btnPickingSlipFull.Name = "btnPickingSlipFull";
            // 
            // btnShowOnlyEmptyOrders
            // 
            this.btnShowOnlyEmptyOrders.Caption = "Show Only Empty Orders";
            this.btnShowOnlyEmptyOrders.Id = 15;
            this.btnShowOnlyEmptyOrders.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnShowOnlyEmptyOrders.ImageOptions.SvgImage")));
            this.btnShowOnlyEmptyOrders.Name = "btnShowOnlyEmptyOrders";
            // 
            // btnPickingSlipDecalLabel
            // 
            this.btnPickingSlipDecalLabel.Caption = "Picking Slips Decal Label";
            this.btnPickingSlipDecalLabel.Id = 16;
            this.btnPickingSlipDecalLabel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPickingSlipDecalLabel.ImageOptions.Image")));
            this.btnPickingSlipDecalLabel.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnPickingSlipDecalLabel.ImageOptions.LargeImage")));
            this.btnPickingSlipDecalLabel.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPickingSlipDecalLabel.ImageOptions.SvgImage")));
            this.btnPickingSlipDecalLabel.Name = "btnPickingSlipDecalLabel";
            // 
            // bbuton_WavePickingSummary
            // 
            this.bbuton_WavePickingSummary.Caption = "Wave Picking Summary";
            this.bbuton_WavePickingSummary.Id = 17;
            this.bbuton_WavePickingSummary.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbuton_WavePickingSummary.ImageOptions.Image")));
            this.bbuton_WavePickingSummary.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbuton_WavePickingSummary.ImageOptions.LargeImage")));
            this.bbuton_WavePickingSummary.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbuton_WavePickingSummary.ImageOptions.SvgImage")));
            this.bbuton_WavePickingSummary.Name = "bbuton_WavePickingSummary";
            // 
            // bb_WavePicking_PickingList
            // 
            this.bb_WavePicking_PickingList.Caption = "Picking List Data";
            this.bb_WavePicking_PickingList.Id = 19;
            this.bb_WavePicking_PickingList.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bb_WavePicking_PickingList.ImageOptions.SvgImage")));
            this.bb_WavePicking_PickingList.Name = "bb_WavePicking_PickingList";
            this.bb_WavePicking_PickingList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bb_WavePicking_PickingList_ItemClick);
            // 
            // bbtn_ViewWavePickingSlipSummary
            // 
            this.bbtn_ViewWavePickingSlipSummary.Caption = "View Pick Summary ";
            this.bbtn_ViewWavePickingSlipSummary.Id = 20;
            this.bbtn_ViewWavePickingSlipSummary.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbtn_ViewWavePickingSlipSummary.ImageOptions.SvgImage")));
            this.bbtn_ViewWavePickingSlipSummary.Name = "bbtn_ViewWavePickingSlipSummary";
            this.bbtn_ViewWavePickingSlipSummary.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbtn_ViewWavePickingSlipSummary_ItemClick);
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.bb_EDI_Process);
            this.ribbonPageGroup2.ItemLinks.Add(this.bb_EDI_Refresh);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "ribbonPageGroup2";
            // 
            // bb_EDI_Process
            // 
            this.bb_EDI_Process.Caption = "Process EDI";
            this.bb_EDI_Process.Id = 24;
            this.bb_EDI_Process.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bb_EDI_Process.ImageOptions.SvgImage")));
            this.bb_EDI_Process.Name = "bb_EDI_Process";
            this.bb_EDI_Process.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bb_EDI_Process_ItemClick);
            // 
            // bb_EDI_Refresh
            // 
            this.bb_EDI_Refresh.Caption = "Refresh EDI";
            this.bb_EDI_Refresh.Id = 25;
            this.bb_EDI_Refresh.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bb_EDI_Refresh.ImageOptions.SvgImage")));
            this.bb_EDI_Refresh.Name = "bb_EDI_Refresh";
            this.bb_EDI_Refresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bb_EDI_Refresh_ItemClick);
            // 
            // bb_WavePicking_Refresh
            // 
            this.bb_WavePicking_Refresh.Caption = "Refresh Wave Details";
            this.bb_WavePicking_Refresh.Id = 23;
            this.bb_WavePicking_Refresh.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bb_WavePicking_Refresh.ImageOptions.SvgImage")));
            this.bb_WavePicking_Refresh.Name = "bb_WavePicking_Refresh";
            this.bb_WavePicking_Refresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bb_WavePicking_Refresh_ItemClick);
            // 
            // bb_WavePicking_PalletLabel
            // 
            this.bb_WavePicking_PalletLabel.Caption = "Label PalletID";
            this.bb_WavePicking_PalletLabel.Id = 26;
            this.bb_WavePicking_PalletLabel.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bb_WavePicking_PalletLabel.ImageOptions.SvgImage")));
            this.bb_WavePicking_PalletLabel.Name = "bb_WavePicking_PalletLabel";
            this.bb_WavePicking_PalletLabel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bb_WavePicking_PalletLabel_ItemClick);
            // 
            // frm_WM_WavePicking
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1657, 787);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_WM_WavePicking.IconOptions.Icon")));
            this.Name = "frm_WM_WavePicking";
            this.Text = "Wave Picking";
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rdDispatchingOrderType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRoom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meWavePickingRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teServiceName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teTemp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teCustomerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdWavePickingDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvWavePickingDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_hpl_OrderNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ri_lke_CustomerClientID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ri_lke_OrderNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teInternal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreatedTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreatedBy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teSeal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teDock.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWavePinkingNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeCustomerNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dWavePickingDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dWavePickingDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeOneClient.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeServiceNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStartTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStartTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEndTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEndTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.MemoEdit meWavePickingRemark;
        private DevExpress.XtraEditors.TextEdit teServiceName;
        private DevExpress.XtraEditors.TextEdit teTemp;
        private DevExpress.XtraEditors.TextEdit teCustomerName;
        private DevExpress.XtraGrid.GridControl grdWavePickingDetails;
        private Common.Controls.WMSGridView grvWavePickingDetails;
        private DevExpress.XtraGrid.Columns.GridColumn grdcolOrderNumber;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpi_hpl_OrderNumber;
        private DevExpress.XtraGrid.Columns.GridColumn grdcolCustomer;
        private DevExpress.XtraGrid.Columns.GridColumn grdcolPallet;
        private DevExpress.XtraGrid.Columns.GridColumn grdcolCtns;
        private DevExpress.XtraGrid.Columns.GridColumn grdcolWeight;
        private DevExpress.XtraGrid.Columns.GridColumn grdcolRemark;
        private DevExpress.XtraGrid.Columns.GridColumn grdcolClient;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ri_lke_CustomerClientID;
        private DevExpress.XtraGrid.Columns.GridColumn grdcolUser;
        private DevExpress.XtraGrid.Columns.GridColumn colDispatchingOrderList;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ri_lke_OrderNumber;
        private DevExpress.XtraEditors.TextEdit teInternal;
        private DevExpress.XtraEditors.TextEdit txtCreatedTime;
        private DevExpress.XtraEditors.TextEdit txtCreatedBy;
        private DevExpress.XtraEditors.TextEdit teSeal;
        private DevExpress.XtraEditors.TextEdit teDock;
        private DevExpress.XtraEditors.TextEdit txtWavePinkingNumber;
        private DevExpress.XtraEditors.LookUpEdit lkeCustomerNumber;
        private DevExpress.XtraEditors.DateEdit dWavePickingDate;
        private DevExpress.XtraEditors.LookUpEdit lkeOneClient;
        private DevExpress.XtraEditors.LookUpEdit lkeServiceNumber;
        private DevExpress.XtraEditors.DateEdit dtStartTime;
        private DevExpress.XtraEditors.DateEdit dtEndTime;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem16;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem14;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem15;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem17;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem8;
        private DevExpress.XtraBars.BarButtonItem btnReceivingAdvice;
        private DevExpress.XtraBars.BarButtonItem btnDispatchingPlan;
        private DevExpress.XtraBars.BarButtonItem btnPickingSlips;
        private DevExpress.XtraBars.BarButtonItem btnPickingSlipByProduct;
        private DevExpress.XtraBars.BarButtonItem btnPickingSlipFull;
        private DevExpress.XtraBars.BarButtonItem btnShowOnlyEmptyOrders;
        private DevExpress.XtraBars.BarButtonItem btnPickingSlipDecalLabel;
        private DevExpress.XtraBars.BarButtonItem bbuton_WavePickingSummary;
        private DevExpress.XtraEditors.RadioGroup rdDispatchingOrderType;
        private DevExpress.XtraEditors.TextEdit txtRoom;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem13;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem18;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraGrid.Columns.GridColumn grdcolUnit;
        private DevExpress.XtraBars.BarButtonItem bb_WavePicking_PickingList;
        private DevExpress.XtraBars.BarButtonItem bbtn_ViewWavePickingSlipSummary;
        private DevExpress.XtraBars.BarButtonItem bb_WavePicking_Refresh;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem bb_EDI_Process;
        private DevExpress.XtraBars.BarButtonItem bb_EDI_Refresh;
        private DevExpress.XtraBars.BarButtonItem bb_WavePicking_PalletLabel;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    }
}