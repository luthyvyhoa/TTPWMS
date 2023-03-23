namespace UI.ReportForm
{
    partial class frm_WR_StockByLocationReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_WR_StockByLocationReport));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grcProducts = new DevExpress.XtraGrid.GridControl();
            this.grvProducts = new Common.Controls.WMSGridView();
            this.grcProductID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dLocationDate = new DevExpress.XtraEditors.DateEdit();
            this.txtCustomerRef = new DevExpress.XtraEditors.TextEdit();
            this.rgChooseOption = new DevExpress.XtraEditors.RadioGroup();
            this.txtCustomerName = new DevExpress.XtraEditors.TextEdit();
            this.lkeCustomerNumber = new DevExpress.XtraEditors.LookUpEdit();
            this.checkShowAllInOutProducts = new DevExpress.XtraEditors.CheckEdit();
            this.btnExportExcel = new DevExpress.XtraEditors.SimpleButton();
            this.grcInOutAllProducts = new DevExpress.XtraGrid.GridControl();
            this.grvStockByLocationDetails = new Common.Controls.WMSGridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpe_ROID = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpe_ProductID = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpe_PalletID = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridColumn26 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn27 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn28 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn29 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn30 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn31 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn32 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn33 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn34 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn35 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn36 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn37 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn38 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem16 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciCustomerRef = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnDeepThree = new DevExpress.XtraBars.BarButtonItem();
            this.btnLowHigh = new DevExpress.XtraBars.BarButtonItem();
            this.btnGrossWeight = new DevExpress.XtraBars.BarButtonItem();
            this.btnByLocation = new DevExpress.XtraBars.BarButtonItem();
            this.btnReplenishment = new DevExpress.XtraBars.BarButtonItem();
            this.btnLocationDetails = new DevExpress.XtraBars.BarButtonItem();
            this.btnByUnitsWeight = new DevExpress.XtraBars.BarButtonItem();
            this.btnDetailsHideQty = new DevExpress.XtraBars.BarButtonItem();
            this.btnViewData = new DevExpress.XtraBars.BarButtonItem();
            this.btnViewByProduct = new DevExpress.XtraBars.BarButtonItem();
            this.btnLabelAllRemain = new DevExpress.XtraBars.BarButtonItem();
            this.btnProductDetails = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem13 = new DevExpress.XtraBars.BarButtonItem();
            this.btnViewKGR = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dLocationDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dLocationDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerRef.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgChooseOption.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeCustomerNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkShowAllInOutProducts.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcInOutAllProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvStockByLocationDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpe_ROID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpe_ProductID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpe_PalletID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCustomerRef)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // rbcbase
            // 
            this.rbcbase.ExpandCollapseItem.Id = 0;
            this.rbcbase.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnDeepThree,
            this.btnLowHigh,
            this.btnGrossWeight,
            this.btnByLocation,
            this.btnReplenishment,
            this.btnLocationDetails,
            this.btnByUnitsWeight,
            this.btnDetailsHideQty,
            this.btnViewData,
            this.btnViewByProduct,
            this.btnLabelAllRemain,
            this.btnProductDetails,
            this.barButtonItem13,
            this.btnViewKGR});
            this.rbcbase.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbcbase.MaxItemId = 15;
            this.rbcbase.OptionsCustomizationForm.FormIcon = ((System.Drawing.Icon)(resources.GetObject("resource.FormIcon")));
            // 
            // 
            // 
            this.rbcbase.SearchEditItem.AccessibleName = "Search Item";
            this.rbcbase.SearchEditItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.rbcbase.SearchEditItem.EditWidth = 150;
            this.rbcbase.SearchEditItem.Id = -5000;
            this.rbcbase.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.rbcbase.Size = new System.Drawing.Size(1807, 155);
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnDeepThree);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnLowHigh);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnByLocation);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnReplenishment);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnLocationDetails);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnByUnitsWeight);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnDetailsHideQty);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnViewData);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnViewByProduct);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnLabelAllRemain);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnProductDetails);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnGrossWeight);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnViewKGR);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem13);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grcProducts);
            this.layoutControl1.Controls.Add(this.dLocationDate);
            this.layoutControl1.Controls.Add(this.txtCustomerRef);
            this.layoutControl1.Controls.Add(this.rgChooseOption);
            this.layoutControl1.Controls.Add(this.txtCustomerName);
            this.layoutControl1.Controls.Add(this.lkeCustomerNumber);
            this.layoutControl1.Controls.Add(this.checkShowAllInOutProducts);
            this.layoutControl1.Controls.Add(this.btnExportExcel);
            this.layoutControl1.Controls.Add(this.grcInOutAllProducts);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 155);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(901, 197, 450, 400);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1807, 632);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grcProducts
            // 
            this.grcProducts.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grcProducts.Location = new System.Drawing.Point(14, 48);
            this.grcProducts.MainView = this.grvProducts;
            this.grcProducts.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grcProducts.MenuManager = this.rbcbase;
            this.grcProducts.Name = "grcProducts";
            this.grcProducts.Size = new System.Drawing.Size(599, 570);
            this.grcProducts.TabIndex = 10;
            this.grcProducts.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvProducts});
            // 
            // grvProducts
            // 
            this.grvProducts.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grvProducts.Appearance.FooterPanel.Options.UseFont = true;
            this.grvProducts.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvProducts.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grcProductID,
            this.grcProductName,
            this.grcQty});
            this.grvProducts.FixedLineWidth = 3;
            this.grvProducts.GridControl = this.grcProducts;
            this.grvProducts.Name = "grvProducts";
            this.grvProducts.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grvProducts.OptionsSelection.MultiSelect = true;
            this.grvProducts.OptionsView.ShowGroupPanel = false;
            this.grvProducts.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvProducts.PaintStyleName = "Skin";
            // 
            // grcProductID
            // 
            this.grcProductID.Caption = "PRODUCT ID";
            this.grcProductID.FieldName = "Product_ID";
            this.grcProductID.Name = "grcProductID";
            this.grcProductID.Visible = true;
            this.grcProductID.VisibleIndex = 0;
            this.grcProductID.Width = 205;
            // 
            // grcProductName
            // 
            this.grcProductName.Caption = "PRODUCT NAME";
            this.grcProductName.FieldName = "ProductName";
            this.grcProductName.Name = "grcProductName";
            this.grcProductName.Visible = true;
            this.grcProductName.VisibleIndex = 1;
            this.grcProductName.Width = 668;
            // 
            // grcQty
            // 
            this.grcQty.Caption = "QTY";
            this.grcQty.FieldName = "Qty";
            this.grcQty.Name = "grcQty";
            this.grcQty.Visible = true;
            this.grcQty.VisibleIndex = 2;
            this.grcQty.Width = 85;
            // 
            // dLocationDate
            // 
            this.dLocationDate.EditValue = null;
            this.dLocationDate.Location = new System.Drawing.Point(694, 14);
            this.dLocationDate.Margin = new System.Windows.Forms.Padding(2);
            this.dLocationDate.MenuManager = this.rbcbase;
            this.dLocationDate.MinimumSize = new System.Drawing.Size(0, 24);
            this.dLocationDate.Name = "dLocationDate";
            this.dLocationDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dLocationDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dLocationDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy ";
            this.dLocationDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dLocationDate.Properties.EditFormat.FormatString = "dd/MM/yyyy ";
            this.dLocationDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dLocationDate.Properties.Mask.EditMask = "dd/MM/yyyy ";
            this.dLocationDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dLocationDate.Size = new System.Drawing.Size(129, 26);
            this.dLocationDate.StyleController = this.layoutControl1;
            this.dLocationDate.TabIndex = 9;
            this.dLocationDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDate_KeyDown);
            // 
            // txtCustomerRef
            // 
            this.txtCustomerRef.Location = new System.Drawing.Point(1059, 14);
            this.txtCustomerRef.Margin = new System.Windows.Forms.Padding(2);
            this.txtCustomerRef.MaximumSize = new System.Drawing.Size(0, 23);
            this.txtCustomerRef.MenuManager = this.rbcbase;
            this.txtCustomerRef.MinimumSize = new System.Drawing.Size(0, 24);
            this.txtCustomerRef.Name = "txtCustomerRef";
            this.txtCustomerRef.Size = new System.Drawing.Size(140, 24);
            this.txtCustomerRef.StyleController = this.layoutControl1;
            this.txtCustomerRef.TabIndex = 8;
            // 
            // rgChooseOption
            // 
            this.rgChooseOption.Location = new System.Drawing.Point(831, 14);
            this.rgChooseOption.Margin = new System.Windows.Forms.Padding(2);
            this.rgChooseOption.MenuManager = this.rbcbase;
            this.rgChooseOption.Name = "rgChooseOption";
            this.rgChooseOption.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rgChooseOption.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.rgChooseOption.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "All"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Customer Ref")});
            this.rgChooseOption.Size = new System.Drawing.Size(220, 26);
            this.rgChooseOption.StyleController = this.layoutControl1;
            this.rgChooseOption.TabIndex = 7;
            this.rgChooseOption.SelectedIndexChanged += new System.EventHandler(this.rgChooseOption_SelectedIndexChanged);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(202, 14);
            this.txtCustomerName.Margin = new System.Windows.Forms.Padding(2);
            this.txtCustomerName.MaximumSize = new System.Drawing.Size(0, 23);
            this.txtCustomerName.MenuManager = this.rbcbase;
            this.txtCustomerName.MinimumSize = new System.Drawing.Size(0, 24);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.txtCustomerName.Properties.Appearance.Options.UseForeColor = true;
            this.txtCustomerName.Properties.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(411, 24);
            this.txtCustomerName.StyleController = this.layoutControl1;
            this.txtCustomerName.TabIndex = 5;
            this.txtCustomerName.DoubleClick += new System.EventHandler(this.txtCustomerName_DoubleClick);
            // 
            // lkeCustomerNumber
            // 
            this.lkeCustomerNumber.Location = new System.Drawing.Point(74, 14);
            this.lkeCustomerNumber.Margin = new System.Windows.Forms.Padding(2);
            this.lkeCustomerNumber.MaximumSize = new System.Drawing.Size(163, 23);
            this.lkeCustomerNumber.MenuManager = this.rbcbase;
            this.lkeCustomerNumber.MinimumSize = new System.Drawing.Size(0, 24);
            this.lkeCustomerNumber.Name = "lkeCustomerNumber";
            this.lkeCustomerNumber.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkeCustomerNumber.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeCustomerNumber.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerID", "CustomerID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerNumber", "CustomerNumber"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerName", "CustomerName"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerType", "CustomerType"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerDiscontinued", "CustomerDiscontinued", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerMainID", "CustomerMainID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lkeCustomerNumber.Properties.NullText = "";
            this.lkeCustomerNumber.Properties.PopupResizeMode = DevExpress.XtraEditors.Controls.ResizeMode.LiveResize;
            this.lkeCustomerNumber.Properties.ShowFooter = false;
            this.lkeCustomerNumber.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lkeCustomerNumber.Size = new System.Drawing.Size(120, 24);
            this.lkeCustomerNumber.StyleController = this.layoutControl1;
            this.lkeCustomerNumber.TabIndex = 4;
            this.lkeCustomerNumber.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(this.lkeCustomerNumber_CloseUp);
            this.lkeCustomerNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lkeCustomerNumber_KeyDown);
            // 
            // checkShowAllInOutProducts
            // 
            this.checkShowAllInOutProducts.Location = new System.Drawing.Point(1593, 14);
            this.checkShowAllInOutProducts.MaximumSize = new System.Drawing.Size(0, 22);
            this.checkShowAllInOutProducts.MinimumSize = new System.Drawing.Size(0, 22);
            this.checkShowAllInOutProducts.Name = "checkShowAllInOutProducts";
            this.checkShowAllInOutProducts.Properties.Caption = "";
            this.checkShowAllInOutProducts.Properties.CheckedChanged += new System.EventHandler(this.checkShowAllInOutProducts_Properties_CheckedChanged);
            this.checkShowAllInOutProducts.Size = new System.Drawing.Size(71, 22);
            this.checkShowAllInOutProducts.StyleController = this.layoutControl1;
            this.checkShowAllInOutProducts.TabIndex = 20;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Question;
            this.btnExportExcel.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnExportExcel.Appearance.Options.UseBackColor = true;
            this.btnExportExcel.Appearance.Options.UseFont = true;
            this.btnExportExcel.Location = new System.Drawing.Point(1670, 12);
            this.btnExportExcel.MaximumSize = new System.Drawing.Size(125, 0);
            this.btnExportExcel.MinimumSize = new System.Drawing.Size(125, 0);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(125, 27);
            this.btnExportExcel.StyleController = this.layoutControl1;
            this.btnExportExcel.TabIndex = 21;
            this.btnExportExcel.Text = "Export Excel";
            // 
            // grcInOutAllProducts
            // 
            this.grcInOutAllProducts.DataMember = "STStockTakeByRequestAllData";
            this.grcInOutAllProducts.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grcInOutAllProducts.Location = new System.Drawing.Point(621, 48);
            this.grcInOutAllProducts.MainView = this.grvStockByLocationDetails;
            this.grcInOutAllProducts.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grcInOutAllProducts.Name = "grcInOutAllProducts";
            this.grcInOutAllProducts.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpe_ROID,
            this.rpe_PalletID,
            this.rpe_ProductID});
            this.grcInOutAllProducts.Size = new System.Drawing.Size(1172, 570);
            this.grcInOutAllProducts.TabIndex = 8;
            this.grcInOutAllProducts.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvStockByLocationDetails});
            // 
            // grvStockByLocationDetails
            // 
            this.grvStockByLocationDetails.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grvStockByLocationDetails.Appearance.FooterPanel.Options.UseFont = true;
            this.grvStockByLocationDetails.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvStockByLocationDetails.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn18,
            this.gridColumn19,
            this.gridColumn20,
            this.gridColumn21,
            this.gridColumn22,
            this.gridColumn23,
            this.gridColumn24,
            this.gridColumn25,
            this.gridColumn26,
            this.gridColumn27,
            this.gridColumn28,
            this.gridColumn29,
            this.gridColumn30,
            this.gridColumn31,
            this.gridColumn32,
            this.gridColumn33,
            this.gridColumn34,
            this.gridColumn35,
            this.gridColumn36,
            this.gridColumn37,
            this.gridColumn38});
            this.grvStockByLocationDetails.GridControl = this.grcInOutAllProducts;
            this.grvStockByLocationDetails.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CurrentQuantity", this.gridColumn5, "(C_Qty: SUM={0:0.##})"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AfterDPQuantity", this.gridColumn5, "(ADP_Qty: SUM={0:0.##})")});
            this.grvStockByLocationDetails.Name = "grvStockByLocationDetails";
            this.grvStockByLocationDetails.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvStockByLocationDetails.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grvStockByLocationDetails.OptionsSelection.MultiSelect = true;
            this.grvStockByLocationDetails.OptionsView.ShowFooter = true;
            this.grvStockByLocationDetails.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvStockByLocationDetails.PaintStyleName = "Skin";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Customer";
            this.gridColumn1.FieldName = "CustomerNumber";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Width = 92;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "RO";
            this.gridColumn2.ColumnEdit = this.rpe_ROID;
            this.gridColumn2.FieldName = "ReceivingOrderNumber";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ReceivingOrderNumber", "Count: {0}")});
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 59;
            // 
            // rpe_ROID
            // 
            this.rpe_ROID.AutoHeight = false;
            this.rpe_ROID.Name = "rpe_ROID";
            this.rpe_ROID.Click += new System.EventHandler(this.rpe_ROID_Click);
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "RODate";
            this.gridColumn3.FieldName = "ReceivingOrderDate";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 85;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "RO Remark";
            this.gridColumn4.FieldName = "SpecialRequirement";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Width = 83;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "ProductID";
            this.gridColumn5.ColumnEdit = this.rpe_ProductID;
            this.gridColumn5.FieldName = "ProductNumber";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 191;
            // 
            // rpe_ProductID
            // 
            this.rpe_ProductID.AutoHeight = false;
            this.rpe_ProductID.Name = "rpe_ProductID";
            this.rpe_ProductID.Click += new System.EventHandler(this.rpe_ProductID_Click);
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Product Name";
            this.gridColumn6.FieldName = "ProductName";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            this.gridColumn6.Width = 444;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "W/p";
            this.gridColumn7.FieldName = "WeightPerPackage";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Width = 67;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "PRO.DATE";
            this.gridColumn8.FieldName = "ProductionDate";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 5;
            this.gridColumn8.Width = 84;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "EXP.DATE";
            this.gridColumn9.FieldName = "UseByDate";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 6;
            this.gridColumn9.Width = 93;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "REF";
            this.gridColumn10.FieldName = "CustomerRef";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 7;
            this.gridColumn10.Width = 104;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "StatusDescription";
            this.gridColumn11.FieldName = "PalletStatusDescription";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Width = 72;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "RO Product Remark";
            this.gridColumn12.FieldName = "RODetailRemark";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Width = 111;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Location";
            this.gridColumn13.FieldName = "LocationNumber";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 8;
            this.gridColumn13.Width = 123;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "R";
            this.gridColumn14.FieldName = "RoomID";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Width = 47;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "A";
            this.gridColumn15.FieldName = "Aisle";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Width = 73;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "B";
            this.gridColumn16.FieldName = "Bay";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Width = 28;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "H";
            this.gridColumn17.FieldName = "High";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.Width = 29;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "D";
            this.gridColumn18.FieldName = "Deep";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.Width = 67;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "O_Qty";
            this.gridColumn19.FieldName = "OriginalQuantity";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.Width = 137;
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "ADP_Qty";
            this.gridColumn20.FieldName = "AfterDPQuantity";
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.Width = 31;
            // 
            // gridColumn21
            // 
            this.gridColumn21.Caption = "C_Qty";
            this.gridColumn21.FieldName = "CurrentQuantity";
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CurrentQuantity", "SUM={0:0.##}")});
            this.gridColumn21.Visible = true;
            this.gridColumn21.VisibleIndex = 9;
            this.gridColumn21.Width = 39;
            // 
            // gridColumn22
            // 
            this.gridColumn22.Caption = "Hold";
            this.gridColumn22.FieldName = "OnHold";
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.Width = 43;
            // 
            // gridColumn23
            // 
            this.gridColumn23.Caption = "Pallet Remark";
            this.gridColumn23.FieldName = "PalletRemark";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.Visible = true;
            this.gridColumn23.VisibleIndex = 10;
            this.gridColumn23.Width = 159;
            // 
            // gridColumn24
            // 
            this.gridColumn24.Caption = "STORE";
            this.gridColumn24.FieldName = "StoreID";
            this.gridColumn24.Name = "gridColumn24";
            this.gridColumn24.Width = 41;
            // 
            // gridColumn25
            // 
            this.gridColumn25.Caption = "PalletID";
            this.gridColumn25.ColumnEdit = this.rpe_PalletID;
            this.gridColumn25.FieldName = "PalletID";
            this.gridColumn25.Name = "gridColumn25";
            this.gridColumn25.Visible = true;
            this.gridColumn25.VisibleIndex = 2;
            this.gridColumn25.Width = 52;
            // 
            // rpe_PalletID
            // 
            this.rpe_PalletID.AutoHeight = false;
            this.rpe_PalletID.Name = "rpe_PalletID";
            this.rpe_PalletID.Click += new System.EventHandler(this.rpe_PalletID_Click);
            // 
            // gridColumn26
            // 
            this.gridColumn26.Caption = "ReceivingOrderID";
            this.gridColumn26.FieldName = "ReceivingOrderID";
            this.gridColumn26.Name = "gridColumn26";
            // 
            // gridColumn27
            // 
            this.gridColumn27.Caption = "CustomerID";
            this.gridColumn27.FieldName = "CustomerID";
            this.gridColumn27.Name = "gridColumn27";
            // 
            // gridColumn28
            // 
            this.gridColumn28.Caption = "ProductID";
            this.gridColumn28.FieldName = "ProductID";
            this.gridColumn28.Name = "gridColumn28";
            // 
            // gridColumn29
            // 
            this.gridColumn29.Caption = "CustomerCategory";
            this.gridColumn29.FieldName = "CustomerCategoryDescription";
            this.gridColumn29.Name = "gridColumn29";
            this.gridColumn29.Width = 133;
            // 
            // gridColumn30
            // 
            this.gridColumn30.Caption = "Createdtime";
            this.gridColumn30.FieldName = "CreatedTime";
            this.gridColumn30.Name = "gridColumn30";
            // 
            // gridColumn31
            // 
            this.gridColumn31.Caption = "Billed";
            this.gridColumn31.FieldName = "BillingCalculated";
            this.gridColumn31.Name = "gridColumn31";
            // 
            // gridColumn32
            // 
            this.gridColumn32.Caption = "Billing Comments";
            this.gridColumn32.FieldName = "BillingComments";
            this.gridColumn32.Name = "gridColumn32";
            // 
            // gridColumn33
            // 
            this.gridColumn33.Caption = "Updated By";
            this.gridColumn33.FieldName = "UpdatedBy";
            this.gridColumn33.Name = "gridColumn33";
            // 
            // gridColumn34
            // 
            this.gridColumn34.Caption = "UpdateTime";
            this.gridColumn34.FieldName = "UpdatedTime";
            this.gridColumn34.Name = "gridColumn34";
            // 
            // gridColumn35
            // 
            this.gridColumn35.Caption = "Plt Weight";
            this.gridColumn35.FieldName = "PalletWeight";
            this.gridColumn35.Name = "gridColumn35";
            // 
            // gridColumn36
            // 
            this.gridColumn36.Caption = "Units";
            this.gridColumn36.FieldName = "UnitQuantity";
            this.gridColumn36.Name = "gridColumn36";
            // 
            // gridColumn37
            // 
            this.gridColumn37.Caption = "XX";
            this.gridColumn37.FieldName = "PalletStatus";
            this.gridColumn37.Name = "gridColumn37";
            this.gridColumn37.Visible = true;
            this.gridColumn37.VisibleIndex = 12;
            this.gridColumn37.Width = 41;
            // 
            // gridColumn38
            // 
            this.gridColumn38.Caption = "Life";
            this.gridColumn38.DisplayFormat.FormatString = "P0";
            this.gridColumn38.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn38.FieldName = "SalesLifePercentage";
            this.gridColumn38.MinWidth = 27;
            this.gridColumn38.Name = "gridColumn38";
            this.gridColumn38.Visible = true;
            this.gridColumn38.VisibleIndex = 11;
            this.gridColumn38.Width = 52;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem7,
            this.layoutControlItem16,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.lciCustomerRef,
            this.layoutControlItem6,
            this.emptySpaceItem1,
            this.layoutControlItem5});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1807, 632);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lkeCustomerNumber;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(188, 34);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem1.Text = "Customer";
            this.layoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(55, 16);
            this.layoutControlItem1.TextToControlDistance = 5;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtCustomerName;
            this.layoutControlItem2.Location = new System.Drawing.Point(188, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(419, 34);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.SupportHorzAlignment;
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.grcProducts;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 34);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(607, 578);
            this.layoutControlItem7.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem16
            // 
            this.layoutControlItem16.Control = this.btnExportExcel;
            this.layoutControlItem16.CustomizationFormText = "layoutControlItem16";
            this.layoutControlItem16.Location = new System.Drawing.Point(1658, 0);
            this.layoutControlItem16.Name = "layoutControlItem16";
            this.layoutControlItem16.Size = new System.Drawing.Size(129, 34);
            this.layoutControlItem16.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem16.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.checkShowAllInOutProducts;
            this.layoutControlItem3.CustomizationFormText = "Show All In - Out Products";
            this.layoutControlItem3.Location = new System.Drawing.Point(1423, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(235, 34);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem3.Text = "Show All In - Out Products";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(151, 16);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.rgChooseOption;
            this.layoutControlItem4.Location = new System.Drawing.Point(817, 0);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(1, 1);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(228, 34);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // lciCustomerRef
            // 
            this.lciCustomerRef.Control = this.txtCustomerRef;
            this.lciCustomerRef.Location = new System.Drawing.Point(1045, 0);
            this.lciCustomerRef.Name = "lciCustomerRef";
            this.lciCustomerRef.Size = new System.Drawing.Size(148, 34);
            this.lciCustomerRef.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.lciCustomerRef.TextSize = new System.Drawing.Size(0, 0);
            this.lciCustomerRef.TextVisible = false;
            this.lciCustomerRef.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.dLocationDate;
            this.layoutControlItem6.Location = new System.Drawing.Point(607, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(210, 34);
            this.layoutControlItem6.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem6.Text = "Report Date";
            this.layoutControlItem6.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(68, 16);
            this.layoutControlItem6.TextToControlDistance = 5;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(1193, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(230, 34);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.grcInOutAllProducts;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem5.Location = new System.Drawing.Point(607, 34);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(1180, 578);
            this.layoutControlItem5.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem5.Text = "layoutControlItem3";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // btnDeepThree
            // 
            this.btnDeepThree.Caption = "Deep 3";
            this.btnDeepThree.Id = 1;
            this.btnDeepThree.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDeepThree.ImageOptions.Image")));
            this.btnDeepThree.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDeepThree.ImageOptions.LargeImage")));
            this.btnDeepThree.Name = "btnDeepThree";
            this.btnDeepThree.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDeepThree_ItemClick);
            // 
            // btnLowHigh
            // 
            this.btnLowHigh.Caption = "Low-High";
            this.btnLowHigh.Id = 2;
            this.btnLowHigh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLowHigh.ImageOptions.Image")));
            this.btnLowHigh.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnLowHigh.ImageOptions.LargeImage")));
            this.btnLowHigh.Name = "btnLowHigh";
            this.btnLowHigh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLowHigh_ItemClick);
            // 
            // btnGrossWeight
            // 
            this.btnGrossWeight.Caption = "Gross Weight";
            this.btnGrossWeight.Id = 3;
            this.btnGrossWeight.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGrossWeight.ImageOptions.Image")));
            this.btnGrossWeight.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnGrossWeight.ImageOptions.LargeImage")));
            this.btnGrossWeight.Name = "btnGrossWeight";
            this.btnGrossWeight.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGrossWeight_ItemClick);
            // 
            // btnByLocation
            // 
            this.btnByLocation.Caption = "By Location";
            this.btnByLocation.Id = 4;
            this.btnByLocation.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnByLocation.ImageOptions.Image")));
            this.btnByLocation.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnByLocation.ImageOptions.LargeImage")));
            this.btnByLocation.Name = "btnByLocation";
            this.btnByLocation.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnByLocation_ItemClick);
            // 
            // btnReplenishment
            // 
            this.btnReplenishment.Caption = "Replenishment";
            this.btnReplenishment.Id = 5;
            this.btnReplenishment.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnReplenishment.ImageOptions.Image")));
            this.btnReplenishment.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnReplenishment.ImageOptions.LargeImage")));
            this.btnReplenishment.Name = "btnReplenishment";
            this.btnReplenishment.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnReplenishment_ItemClick);
            // 
            // btnLocationDetails
            // 
            this.btnLocationDetails.Caption = "Location Details";
            this.btnLocationDetails.Id = 6;
            this.btnLocationDetails.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLocationDetails.ImageOptions.Image")));
            this.btnLocationDetails.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnLocationDetails.ImageOptions.LargeImage")));
            this.btnLocationDetails.Name = "btnLocationDetails";
            this.btnLocationDetails.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLocationDetails_ItemClick);
            // 
            // btnByUnitsWeight
            // 
            this.btnByUnitsWeight.Caption = "By UnitsWeight";
            this.btnByUnitsWeight.Id = 7;
            this.btnByUnitsWeight.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnByUnitsWeight.ImageOptions.Image")));
            this.btnByUnitsWeight.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnByUnitsWeight.ImageOptions.LargeImage")));
            this.btnByUnitsWeight.Name = "btnByUnitsWeight";
            this.btnByUnitsWeight.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnByUnitsWeight_ItemClick);
            // 
            // btnDetailsHideQty
            // 
            this.btnDetailsHideQty.Caption = "Details (HideQty)";
            this.btnDetailsHideQty.Id = 8;
            this.btnDetailsHideQty.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDetailsHideQty.ImageOptions.Image")));
            this.btnDetailsHideQty.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDetailsHideQty.ImageOptions.LargeImage")));
            this.btnDetailsHideQty.Name = "btnDetailsHideQty";
            this.btnDetailsHideQty.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDetailsHideQty_ItemClick);
            // 
            // btnViewData
            // 
            this.btnViewData.Caption = "ViewData";
            this.btnViewData.Id = 9;
            this.btnViewData.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnViewData.ImageOptions.Image")));
            this.btnViewData.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnViewData.ImageOptions.LargeImage")));
            this.btnViewData.Name = "btnViewData";
            this.btnViewData.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnViewData_ItemClick);
            // 
            // btnViewByProduct
            // 
            this.btnViewByProduct.Caption = "View By Product";
            this.btnViewByProduct.Id = 10;
            this.btnViewByProduct.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnViewByProduct.ImageOptions.Image")));
            this.btnViewByProduct.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnViewByProduct.ImageOptions.LargeImage")));
            this.btnViewByProduct.Name = "btnViewByProduct";
            this.btnViewByProduct.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnViewByProduct_ItemClick);
            // 
            // btnLabelAllRemain
            // 
            this.btnLabelAllRemain.Caption = "Label All Remain";
            this.btnLabelAllRemain.Id = 11;
            this.btnLabelAllRemain.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLabelAllRemain.ImageOptions.Image")));
            this.btnLabelAllRemain.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnLabelAllRemain.ImageOptions.LargeImage")));
            this.btnLabelAllRemain.Name = "btnLabelAllRemain";
            this.btnLabelAllRemain.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLabelAllRemain_ItemClick);
            // 
            // btnProductDetails
            // 
            this.btnProductDetails.Caption = "Product Details";
            this.btnProductDetails.Id = 12;
            this.btnProductDetails.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnProductDetails.ImageOptions.Image")));
            this.btnProductDetails.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnProductDetails.ImageOptions.LargeImage")));
            this.btnProductDetails.Name = "btnProductDetails";
            this.btnProductDetails.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnProductDetails_ItemClick);
            // 
            // barButtonItem13
            // 
            this.barButtonItem13.Caption = "Close";
            this.barButtonItem13.Id = 13;
            this.barButtonItem13.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem13.ImageOptions.Image")));
            this.barButtonItem13.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem13.ImageOptions.LargeImage")));
            this.barButtonItem13.Name = "barButtonItem13";
            this.barButtonItem13.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem13.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem13_ItemClick);
            // 
            // btnViewKGR
            // 
            this.btnViewKGR.Caption = "View KGR";
            this.btnViewKGR.Id = 14;
            this.btnViewKGR.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnViewKGR.ImageOptions.Image")));
            this.btnViewKGR.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnViewKGR.ImageOptions.SvgImage")));
            this.btnViewKGR.Name = "btnViewKGR";
            this.btnViewKGR.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnViewKGR_ItemClick);
            // 
            // frm_WR_StockByLocationReport
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1807, 787);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_WR_StockByLocationReport.IconOptions.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_WR_StockByLocationReport";
            this.Text = "Stock By Location Report";
            this.Load += new System.EventHandler(this.frm_WR_StockByLocationReport_Load);
            this.Shown += new System.EventHandler(this.frm_WR_StockByLocationReport_Shown);
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dLocationDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dLocationDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerRef.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgChooseOption.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeCustomerNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkShowAllInOutProducts.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcInOutAllProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvStockByLocationDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpe_ROID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpe_ProductID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpe_PalletID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCustomerRef)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl grcProducts;
        private Common.Controls.WMSGridView grvProducts;
        private DevExpress.XtraEditors.DateEdit dLocationDate;
        private DevExpress.XtraEditors.TextEdit txtCustomerRef;
        private DevExpress.XtraEditors.RadioGroup rgChooseOption;
        private DevExpress.XtraEditors.TextEdit txtCustomerName;
        private DevExpress.XtraEditors.LookUpEdit lkeCustomerNumber;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem lciCustomerRef;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraBars.BarButtonItem btnDeepThree;
        private DevExpress.XtraBars.BarButtonItem btnLowHigh;
        private DevExpress.XtraBars.BarButtonItem btnGrossWeight;
        private DevExpress.XtraBars.BarButtonItem btnByLocation;
        private DevExpress.XtraBars.BarButtonItem btnReplenishment;
        private DevExpress.XtraBars.BarButtonItem btnLocationDetails;
        private DevExpress.XtraBars.BarButtonItem btnByUnitsWeight;
        private DevExpress.XtraBars.BarButtonItem btnDetailsHideQty;
        private DevExpress.XtraBars.BarButtonItem btnViewData;
        private DevExpress.XtraBars.BarButtonItem btnViewByProduct;
        private DevExpress.XtraBars.BarButtonItem btnLabelAllRemain;
        private DevExpress.XtraBars.BarButtonItem btnProductDetails;
        private DevExpress.XtraBars.BarButtonItem barButtonItem13;
        private DevExpress.XtraGrid.Columns.GridColumn grcProductID;
        private DevExpress.XtraGrid.Columns.GridColumn grcProductName;
        private DevExpress.XtraGrid.Columns.GridColumn grcQty;
        private DevExpress.XtraBars.BarButtonItem btnViewKGR;
        private DevExpress.XtraEditors.CheckEdit checkShowAllInOutProducts;
        private DevExpress.XtraEditors.SimpleButton btnExportExcel;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem16;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.GridControl grcInOutAllProducts;
        private Common.Controls.WMSGridView grvStockByLocationDetails;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpe_ROID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpe_ProductID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn24;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn25;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpe_PalletID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn26;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn27;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn28;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn29;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn30;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn31;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn32;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn33;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn34;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn35;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn36;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn37;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn38;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
    }
}