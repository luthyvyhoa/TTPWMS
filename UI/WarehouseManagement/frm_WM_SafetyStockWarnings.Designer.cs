namespace UI.WarehouseManagement
{
    partial class frm_WM_SafetyStockWarnings
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_WM_SafetyStockWarnings));
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grdStockForExport = new DevExpress.XtraGrid.GridControl();
            this.grvStockForExport = new Common.Controls.WMSGridView();
            this.grcExportCustomerClientName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcExportDONumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcExportDODate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcExportRequirement = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcExportRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcExportCustomerRef = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcExportProductNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcExportProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcExportWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcExportQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcExportPlts = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcExportPackage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcExportProDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcExportUseByDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcExportCustomerRefRO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcExportRODate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcExportRORemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcExportRO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcExportDOID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdStockWarning = new DevExpress.XtraGrid.GridControl();
            this.grvStockWarning = new Common.Controls.WMSGridView();
            this.grcProductNumber2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_txt_ProductNumber2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.grcProductName6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcStockP2Qty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcProductNumber6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_txt_ProductNumber6 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.grcWaitingQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcAvailableStock = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcSafetyStock = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_hpl_SafetyStock = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.grcMissingQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcProductNumberP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_txt_ProductNumberP = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.grcStockPackQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcIDOuter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcSelectReason = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_lke_Reason = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.grcReason = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcOpenReason = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_btn_OpenReason = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.grcProductID6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnDetailClient = new DevExpress.XtraEditors.SimpleButton();
            this.btnSafetyStock = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.dtToDate = new DevExpress.XtraEditors.DateEdit();
            this.dtFromDate = new DevExpress.XtraEditors.DateEdit();
            this.chkRODO = new DevExpress.XtraEditors.CheckEdit();
            this.lkeCustomerFind = new DevExpress.XtraEditors.LookUpEdit();
            this.txtCustomerNameFind = new DevExpress.XtraEditors.TextEdit();
            this.btn_delete = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdStockForExport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvStockForExport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdStockWarning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvStockWarning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_txt_ProductNumber2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_txt_ProductNumber6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_hpl_SafetyStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_txt_ProductNumberP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_Reason)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_btn_OpenReason)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRODO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeCustomerFind.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerNameFind.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // rbcbase
            // 
            //this.rbcbase.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(40, 39, 40, 39);
            this.rbcbase.ExpandCollapseItem.Id = 0;
            this.rbcbase.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbcbase.OptionsCustomizationForm.FormIcon = ((System.Drawing.Icon)(resources.GetObject("resource.FormIcon")));
            this.rbcbase.OptionsMenuMinWidth = 440;
            // 
            // 
            // 
            this.rbcbase.SearchEditItem.AccessibleName = "Search Item";
            this.rbcbase.SearchEditItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.rbcbase.SearchEditItem.EditWidth = 150;
            this.rbcbase.SearchEditItem.Id = -5000;
            this.rbcbase.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.rbcbase.Size = new System.Drawing.Size(1384, 51);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grdStockForExport);
            this.layoutControl1.Controls.Add(this.grdStockWarning);
            this.layoutControl1.Controls.Add(this.btnDetailClient);
            this.layoutControl1.Controls.Add(this.btnSafetyStock);
            this.layoutControl1.Controls.Add(this.btnRefresh);
            this.layoutControl1.Controls.Add(this.btnClose);
            this.layoutControl1.Controls.Add(this.dtToDate);
            this.layoutControl1.Controls.Add(this.dtFromDate);
            this.layoutControl1.Controls.Add(this.chkRODO);
            this.layoutControl1.Controls.Add(this.lkeCustomerFind);
            this.layoutControl1.Controls.Add(this.txtCustomerNameFind);
            this.layoutControl1.Controls.Add(this.btn_delete);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem9});
            this.layoutControl1.Location = new System.Drawing.Point(0, 51);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1384, 736);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grdStockForExport
            // 
            this.grdStockForExport.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grdStockForExport.Location = new System.Drawing.Point(5, 197);
            this.grdStockForExport.MainView = this.grvStockForExport;
            this.grdStockForExport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdStockForExport.MenuManager = this.rbcbase;
            this.grdStockForExport.Name = "grdStockForExport";
            this.grdStockForExport.Size = new System.Drawing.Size(1449, 180);
            this.grdStockForExport.TabIndex = 12;
            this.grdStockForExport.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvStockForExport});
            // 
            // grvStockForExport
            // 
            this.grvStockForExport.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grcExportCustomerClientName,
            this.grcExportDONumber,
            this.grcExportDODate,
            this.grcExportRequirement,
            this.grcExportRemark,
            this.grcExportCustomerRef,
            this.grcExportProductNumber,
            this.grcExportProductName,
            this.grcExportWeight,
            this.grcExportQuantity,
            this.grcExportPlts,
            this.grcExportPackage,
            this.grcExportProDate,
            this.grcExportUseByDate,
            this.grcExportCustomerRefRO,
            this.grcExportRODate,
            this.grcExportRORemark,
            this.grcExportRO,
            this.grcExportDOID});
            this.grvStockForExport.GridControl = this.grdStockForExport;
            this.grvStockForExport.Name = "grvStockForExport";
            this.grvStockForExport.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvStockForExport.PaintStyleName = "Skin";
            // 
            // grcExportCustomerClientName
            // 
            this.grcExportCustomerClientName.Caption = "CustomerClientName";
            this.grcExportCustomerClientName.FieldName = "CustomerClientName";
            this.grcExportCustomerClientName.Name = "grcExportCustomerClientName";
            this.grcExportCustomerClientName.Visible = true;
            this.grcExportCustomerClientName.VisibleIndex = 0;
            // 
            // grcExportDONumber
            // 
            this.grcExportDONumber.Caption = "DispatchingOrderNumber";
            this.grcExportDONumber.FieldName = "DispatchingOrderNumber";
            this.grcExportDONumber.Name = "grcExportDONumber";
            this.grcExportDONumber.Visible = true;
            this.grcExportDONumber.VisibleIndex = 1;
            // 
            // grcExportDODate
            // 
            this.grcExportDODate.Caption = "DispatchingOrderDate";
            this.grcExportDODate.FieldName = "DispatchingOrderDate";
            this.grcExportDODate.Name = "grcExportDODate";
            this.grcExportDODate.Visible = true;
            this.grcExportDODate.VisibleIndex = 2;
            // 
            // grcExportRequirement
            // 
            this.grcExportRequirement.Caption = "SpecialRequirement";
            this.grcExportRequirement.FieldName = "SpecialRequirement";
            this.grcExportRequirement.Name = "grcExportRequirement";
            this.grcExportRequirement.Visible = true;
            this.grcExportRequirement.VisibleIndex = 3;
            // 
            // grcExportRemark
            // 
            this.grcExportRemark.Caption = "Remark";
            this.grcExportRemark.FieldName = "Remark";
            this.grcExportRemark.Name = "grcExportRemark";
            this.grcExportRemark.Visible = true;
            this.grcExportRemark.VisibleIndex = 4;
            // 
            // grcExportCustomerRef
            // 
            this.grcExportCustomerRef.Caption = "CustomerRef";
            this.grcExportCustomerRef.FieldName = "CustomerRef";
            this.grcExportCustomerRef.Name = "grcExportCustomerRef";
            this.grcExportCustomerRef.Visible = true;
            this.grcExportCustomerRef.VisibleIndex = 5;
            // 
            // grcExportProductNumber
            // 
            this.grcExportProductNumber.Caption = "ProductNumber";
            this.grcExportProductNumber.FieldName = "ProductNumber";
            this.grcExportProductNumber.Name = "grcExportProductNumber";
            this.grcExportProductNumber.Visible = true;
            this.grcExportProductNumber.VisibleIndex = 6;
            // 
            // grcExportProductName
            // 
            this.grcExportProductName.Caption = "ProductName";
            this.grcExportProductName.FieldName = "ProductName";
            this.grcExportProductName.Name = "grcExportProductName";
            this.grcExportProductName.Visible = true;
            this.grcExportProductName.VisibleIndex = 7;
            // 
            // grcExportWeight
            // 
            this.grcExportWeight.Caption = "WeightPerPackage";
            this.grcExportWeight.FieldName = "WeightPerPackage";
            this.grcExportWeight.Name = "grcExportWeight";
            this.grcExportWeight.Visible = true;
            this.grcExportWeight.VisibleIndex = 8;
            // 
            // grcExportQuantity
            // 
            this.grcExportQuantity.Caption = "QuantityPerPackages";
            this.grcExportQuantity.FieldName = "QuantityPerPackages";
            this.grcExportQuantity.Name = "grcExportQuantity";
            this.grcExportQuantity.Visible = true;
            this.grcExportQuantity.VisibleIndex = 9;
            // 
            // grcExportPlts
            // 
            this.grcExportPlts.Caption = "Plts";
            this.grcExportPlts.FieldName = "Plts";
            this.grcExportPlts.Name = "grcExportPlts";
            this.grcExportPlts.Visible = true;
            this.grcExportPlts.VisibleIndex = 10;
            // 
            // grcExportPackage
            // 
            this.grcExportPackage.Caption = "Packages";
            this.grcExportPackage.FieldName = "Packages";
            this.grcExportPackage.Name = "grcExportPackage";
            this.grcExportPackage.Visible = true;
            this.grcExportPackage.VisibleIndex = 11;
            // 
            // grcExportProDate
            // 
            this.grcExportProDate.Caption = "ProductionDate";
            this.grcExportProDate.FieldName = "ProductionDate";
            this.grcExportProDate.Name = "grcExportProDate";
            this.grcExportProDate.Visible = true;
            this.grcExportProDate.VisibleIndex = 12;
            // 
            // grcExportUseByDate
            // 
            this.grcExportUseByDate.Caption = "UseByDate";
            this.grcExportUseByDate.FieldName = "UseByDate";
            this.grcExportUseByDate.Name = "grcExportUseByDate";
            this.grcExportUseByDate.Visible = true;
            this.grcExportUseByDate.VisibleIndex = 13;
            // 
            // grcExportCustomerRefRO
            // 
            this.grcExportCustomerRefRO.Caption = "CustomerRef_RO";
            this.grcExportCustomerRefRO.FieldName = "CustomerRef_RO";
            this.grcExportCustomerRefRO.Name = "grcExportCustomerRefRO";
            this.grcExportCustomerRefRO.Visible = true;
            this.grcExportCustomerRefRO.VisibleIndex = 14;
            // 
            // grcExportRODate
            // 
            this.grcExportRODate.Caption = "RODate";
            this.grcExportRODate.FieldName = "RODate";
            this.grcExportRODate.Name = "grcExportRODate";
            this.grcExportRODate.Visible = true;
            this.grcExportRODate.VisibleIndex = 15;
            // 
            // grcExportRORemark
            // 
            this.grcExportRORemark.Caption = "RO_Remark";
            this.grcExportRORemark.FieldName = "RO_Remark";
            this.grcExportRORemark.Name = "grcExportRORemark";
            this.grcExportRORemark.Visible = true;
            this.grcExportRORemark.VisibleIndex = 16;
            // 
            // grcExportRO
            // 
            this.grcExportRO.Caption = "RO";
            this.grcExportRO.FieldName = "RO";
            this.grcExportRO.Name = "grcExportRO";
            this.grcExportRO.Visible = true;
            this.grcExportRO.VisibleIndex = 17;
            // 
            // grcExportDOID
            // 
            this.grcExportDOID.Caption = "DispatchingOrderID";
            this.grcExportDOID.FieldName = "DispatchingOrderID";
            this.grcExportDOID.Name = "grcExportDOID";
            this.grcExportDOID.Visible = true;
            this.grcExportDOID.VisibleIndex = 18;
            // 
            // grdStockWarning
            // 
            this.grdStockWarning.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grdStockWarning.Location = new System.Drawing.Point(16, 16);
            this.grdStockWarning.MainView = this.grvStockWarning;
            this.grdStockWarning.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdStockWarning.MenuManager = this.rbcbase;
            this.grdStockWarning.Name = "grdStockWarning";
            this.grdStockWarning.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpi_btn_OpenReason,
            this.rpi_txt_ProductNumber2,
            this.rpi_hpl_SafetyStock,
            this.rpi_txt_ProductNumber6,
            this.rpi_txt_ProductNumberP,
            this.rpi_lke_Reason});
            this.grdStockWarning.Size = new System.Drawing.Size(1352, 613);
            this.grdStockWarning.TabIndex = 4;
            this.grdStockWarning.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvStockWarning});
            // 
            // grvStockWarning
            // 
            this.grvStockWarning.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grvStockWarning.Appearance.FooterPanel.Options.UseFont = true;
            this.grvStockWarning.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvStockWarning.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grcProductNumber2,
            this.grcProductName6,
            this.grcStockP2Qty,
            this.grcProductNumber6,
            this.grcWaitingQuantity,
            this.grcAvailableStock,
            this.grcSafetyStock,
            this.grcMissingQuantity,
            this.grcProductNumberP,
            this.grcStockPackQty,
            this.grcRemark,
            this.grcIDOuter,
            this.grcSelectReason,
            this.grcReason,
            this.grcOpenReason,
            this.grcProductID6});
            this.grvStockWarning.GridControl = this.grdStockWarning;
            this.grvStockWarning.Name = "grvStockWarning";
            this.grvStockWarning.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grvStockWarning.OptionsSelection.MultiSelect = true;
            this.grvStockWarning.OptionsView.ShowFooter = true;
            this.grvStockWarning.OptionsView.ShowGroupPanel = false;
            this.grvStockWarning.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvStockWarning.PaintStyleName = "Skin";
            this.grvStockWarning.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.grvStockWarning_RowCellStyle);
            // 
            // grcProductNumber2
            // 
            this.grcProductNumber2.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.grcProductNumber2.AppearanceCell.Options.UseBackColor = true;
            this.grcProductNumber2.AppearanceCell.Options.UseTextOptions = true;
            this.grcProductNumber2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcProductNumber2.Caption = "ID-2";
            this.grcProductNumber2.ColumnEdit = this.rpi_txt_ProductNumber2;
            this.grcProductNumber2.FieldName = "ProductNumber2";
            this.grcProductNumber2.Name = "grcProductNumber2";
            this.grcProductNumber2.OptionsColumn.ReadOnly = true;
            this.grcProductNumber2.Visible = true;
            this.grcProductNumber2.VisibleIndex = 0;
            this.grcProductNumber2.Width = 68;
            // 
            // rpi_txt_ProductNumber2
            // 
            this.rpi_txt_ProductNumber2.AutoHeight = false;
            this.rpi_txt_ProductNumber2.Name = "rpi_txt_ProductNumber2";
            // 
            // grcProductName6
            // 
            this.grcProductName6.Caption = "PRODUCT NAME";
            this.grcProductName6.FieldName = "ProductName6";
            this.grcProductName6.Name = "grcProductName6";
            this.grcProductName6.OptionsColumn.ReadOnly = true;
            this.grcProductName6.Visible = true;
            this.grcProductName6.VisibleIndex = 1;
            this.grcProductName6.Width = 299;
            // 
            // grcStockP2Qty
            // 
            this.grcStockP2Qty.AppearanceCell.Options.UseTextOptions = true;
            this.grcStockP2Qty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grcStockP2Qty.Caption = "QTY-2";
            this.grcStockP2Qty.FieldName = "StockP2Qty";
            this.grcStockP2Qty.Name = "grcStockP2Qty";
            this.grcStockP2Qty.OptionsColumn.ReadOnly = true;
            this.grcStockP2Qty.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "StockP2Qty", "{0:n0}")});
            this.grcStockP2Qty.Visible = true;
            this.grcStockP2Qty.VisibleIndex = 2;
            this.grcStockP2Qty.Width = 48;
            // 
            // grcProductNumber6
            // 
            this.grcProductNumber6.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.grcProductNumber6.AppearanceCell.Options.UseBackColor = true;
            this.grcProductNumber6.AppearanceCell.Options.UseTextOptions = true;
            this.grcProductNumber6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcProductNumber6.Caption = "ID-6";
            this.grcProductNumber6.ColumnEdit = this.rpi_txt_ProductNumber6;
            this.grcProductNumber6.FieldName = "ProductNumber6";
            this.grcProductNumber6.Name = "grcProductNumber6";
            this.grcProductNumber6.OptionsColumn.ReadOnly = true;
            this.grcProductNumber6.Visible = true;
            this.grcProductNumber6.VisibleIndex = 3;
            this.grcProductNumber6.Width = 60;
            // 
            // rpi_txt_ProductNumber6
            // 
            this.rpi_txt_ProductNumber6.AutoHeight = false;
            this.rpi_txt_ProductNumber6.Name = "rpi_txt_ProductNumber6";
            // 
            // grcWaitingQuantity
            // 
            this.grcWaitingQuantity.AppearanceCell.Options.UseTextOptions = true;
            this.grcWaitingQuantity.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grcWaitingQuantity.Caption = "WAIT";
            this.grcWaitingQuantity.FieldName = "WaitingQuantity";
            this.grcWaitingQuantity.Name = "grcWaitingQuantity";
            this.grcWaitingQuantity.OptionsColumn.ReadOnly = true;
            this.grcWaitingQuantity.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "WaitingQuantity", "{0:n0}")});
            this.grcWaitingQuantity.Visible = true;
            this.grcWaitingQuantity.VisibleIndex = 4;
            this.grcWaitingQuantity.Width = 41;
            // 
            // grcAvailableStock
            // 
            this.grcAvailableStock.AppearanceCell.Options.UseTextOptions = true;
            this.grcAvailableStock.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grcAvailableStock.Caption = "AVAIL.STOCK";
            this.grcAvailableStock.FieldName = "StockOnHand";
            this.grcAvailableStock.Name = "grcAvailableStock";
            this.grcAvailableStock.OptionsColumn.ReadOnly = true;
            this.grcAvailableStock.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "StockOnHand", "{0:n0}")});
            this.grcAvailableStock.Visible = true;
            this.grcAvailableStock.VisibleIndex = 5;
            this.grcAvailableStock.Width = 83;
            // 
            // grcSafetyStock
            // 
            this.grcSafetyStock.AppearanceCell.Options.UseTextOptions = true;
            this.grcSafetyStock.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grcSafetyStock.Caption = "SAFETY ST. ";
            this.grcSafetyStock.ColumnEdit = this.rpi_hpl_SafetyStock;
            this.grcSafetyStock.FieldName = "SafetyStock";
            this.grcSafetyStock.Name = "grcSafetyStock";
            this.grcSafetyStock.OptionsColumn.ReadOnly = true;
            this.grcSafetyStock.Visible = true;
            this.grcSafetyStock.VisibleIndex = 6;
            this.grcSafetyStock.Width = 68;
            // 
            // rpi_hpl_SafetyStock
            // 
            this.rpi_hpl_SafetyStock.AutoHeight = false;
            this.rpi_hpl_SafetyStock.Name = "rpi_hpl_SafetyStock";
            // 
            // grcMissingQuantity
            // 
            this.grcMissingQuantity.Caption = "SHORTAGE";
            this.grcMissingQuantity.FieldName = "MissingQty";
            this.grcMissingQuantity.Name = "grcMissingQuantity";
            this.grcMissingQuantity.OptionsColumn.ReadOnly = true;
            this.grcMissingQuantity.Visible = true;
            this.grcMissingQuantity.VisibleIndex = 7;
            // 
            // grcProductNumberP
            // 
            this.grcProductNumberP.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.grcProductNumberP.AppearanceCell.Options.UseBackColor = true;
            this.grcProductNumberP.AppearanceCell.Options.UseTextOptions = true;
            this.grcProductNumberP.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcProductNumberP.Caption = "ID-PACK";
            this.grcProductNumberP.ColumnEdit = this.rpi_txt_ProductNumberP;
            this.grcProductNumberP.FieldName = "ProductNumberP";
            this.grcProductNumberP.Name = "grcProductNumberP";
            this.grcProductNumberP.OptionsColumn.ReadOnly = true;
            this.grcProductNumberP.Visible = true;
            this.grcProductNumberP.VisibleIndex = 8;
            this.grcProductNumberP.Width = 84;
            // 
            // rpi_txt_ProductNumberP
            // 
            this.rpi_txt_ProductNumberP.AutoHeight = false;
            this.rpi_txt_ProductNumberP.Name = "rpi_txt_ProductNumberP";
            // 
            // grcStockPackQty
            // 
            this.grcStockPackQty.AppearanceCell.Options.UseTextOptions = true;
            this.grcStockPackQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grcStockPackQty.Caption = "QTY-PACK";
            this.grcStockPackQty.FieldName = "StockPackQty";
            this.grcStockPackQty.Name = "grcStockPackQty";
            this.grcStockPackQty.OptionsColumn.ReadOnly = true;
            this.grcStockPackQty.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "StockPackQty", "{0:n0}")});
            this.grcStockPackQty.Visible = true;
            this.grcStockPackQty.VisibleIndex = 9;
            this.grcStockPackQty.Width = 77;
            // 
            // grcRemark
            // 
            this.grcRemark.AppearanceCell.Options.UseTextOptions = true;
            this.grcRemark.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grcRemark.Caption = "REMARK";
            this.grcRemark.FieldName = "Remark";
            this.grcRemark.Name = "grcRemark";
            this.grcRemark.OptionsColumn.ReadOnly = true;
            this.grcRemark.Visible = true;
            this.grcRemark.VisibleIndex = 11;
            this.grcRemark.Width = 89;
            // 
            // grcIDOuter
            // 
            this.grcIDOuter.Caption = "ID-OUTER";
            this.grcIDOuter.FieldName = "ProductIDOuter";
            this.grcIDOuter.MinWidth = 27;
            this.grcIDOuter.Name = "grcIDOuter";
            this.grcIDOuter.Visible = true;
            this.grcIDOuter.VisibleIndex = 10;
            this.grcIDOuter.Width = 81;
            // 
            // grcSelectReason
            // 
            this.grcSelectReason.ColumnEdit = this.rpi_lke_Reason;
            this.grcSelectReason.MaxWidth = 20;
            this.grcSelectReason.Name = "grcSelectReason";
            this.grcSelectReason.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.grcSelectReason.Visible = true;
            this.grcSelectReason.VisibleIndex = 12;
            this.grcSelectReason.Width = 20;
            // 
            // rpi_lke_Reason
            // 
            this.rpi_lke_Reason.AutoHeight = false;
            this.rpi_lke_Reason.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpi_lke_Reason.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.rpi_lke_Reason.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ReasonID", "ID", 27, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Reason", "Name", 267, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.rpi_lke_Reason.DropDownRows = 9;
            this.rpi_lke_Reason.Name = "rpi_lke_Reason";
            this.rpi_lke_Reason.NullText = "";
            this.rpi_lke_Reason.PopupFormMinSize = new System.Drawing.Size(200, 0);
            this.rpi_lke_Reason.ShowFooter = false;
            this.rpi_lke_Reason.ShowHeader = false;
            // 
            // grcReason
            // 
            this.grcReason.Caption = "REASON";
            this.grcReason.FieldName = "Reason";
            this.grcReason.Name = "grcReason";
            this.grcReason.OptionsColumn.ReadOnly = true;
            this.grcReason.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.grcReason.Visible = true;
            this.grcReason.VisibleIndex = 13;
            this.grcReason.Width = 207;
            // 
            // grcOpenReason
            // 
            this.grcOpenReason.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.grcOpenReason.AppearanceHeader.Options.UseFont = true;
            this.grcOpenReason.Caption = " ";
            this.grcOpenReason.ColumnEdit = this.rpi_btn_OpenReason;
            this.grcOpenReason.MaxWidth = 35;
            this.grcOpenReason.MinWidth = 35;
            this.grcOpenReason.Name = "grcOpenReason";
            this.grcOpenReason.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.grcOpenReason.Visible = true;
            this.grcOpenReason.VisibleIndex = 14;
            this.grcOpenReason.Width = 35;
            // 
            // rpi_btn_OpenReason
            // 
            this.rpi_btn_OpenReason.AutoHeight = false;
            editorButtonImageOptions1.Image = global::UI.Properties.Resources.freezepanes_16x16;
            this.rpi_btn_OpenReason.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.rpi_btn_OpenReason.Name = "rpi_btn_OpenReason";
            this.rpi_btn_OpenReason.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // grcProductID6
            // 
            this.grcProductID6.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.grcProductID6.AppearanceHeader.Options.UseFont = true;
            this.grcProductID6.Caption = "ID-6";
            this.grcProductID6.FieldName = "ProductID6";
            this.grcProductID6.Name = "grcProductID6";
            this.grcProductID6.OptionsColumn.ReadOnly = true;
            // 
            // btnDetailClient
            // 
            this.btnDetailClient.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Question;
            this.btnDetailClient.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnDetailClient.Appearance.Options.UseBackColor = true;
            this.btnDetailClient.Appearance.Options.UseFont = true;
            this.btnDetailClient.Appearance.Options.UseTextOptions = true;
            this.btnDetailClient.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnDetailClient.Location = new System.Drawing.Point(589, 638);
            this.btnDetailClient.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDetailClient.MaximumSize = new System.Drawing.Size(125, 41);
            this.btnDetailClient.MinimumSize = new System.Drawing.Size(125, 41);
            this.btnDetailClient.Name = "btnDetailClient";
            this.btnDetailClient.Size = new System.Drawing.Size(125, 41);
            this.btnDetailClient.StyleController = this.layoutControl1;
            this.btnDetailClient.TabIndex = 5;
            this.btnDetailClient.Text = "Detail Client";
            // 
            // btnSafetyStock
            // 
            this.btnSafetyStock.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Question;
            this.btnSafetyStock.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnSafetyStock.Appearance.Options.UseBackColor = true;
            this.btnSafetyStock.Appearance.Options.UseFont = true;
            this.btnSafetyStock.Appearance.Options.UseTextOptions = true;
            this.btnSafetyStock.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnSafetyStock.Location = new System.Drawing.Point(722, 638);
            this.btnSafetyStock.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSafetyStock.MaximumSize = new System.Drawing.Size(125, 41);
            this.btnSafetyStock.MinimumSize = new System.Drawing.Size(125, 41);
            this.btnSafetyStock.Name = "btnSafetyStock";
            this.btnSafetyStock.Size = new System.Drawing.Size(125, 41);
            this.btnSafetyStock.StyleController = this.layoutControl1;
            this.btnSafetyStock.TabIndex = 6;
            this.btnSafetyStock.Text = "Add + Edit Safety Stock";
            this.btnSafetyStock.Click += new System.EventHandler(this.btnSafetyStock_Click_1);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Question;
            this.btnRefresh.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.Appearance.Options.UseBackColor = true;
            this.btnRefresh.Appearance.Options.UseFont = true;
            this.btnRefresh.Appearance.Options.UseTextOptions = true;
            this.btnRefresh.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnRefresh.Location = new System.Drawing.Point(1109, 638);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRefresh.MaximumSize = new System.Drawing.Size(125, 41);
            this.btnRefresh.MinimumSize = new System.Drawing.Size(125, 41);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(125, 41);
            this.btnRefresh.StyleController = this.layoutControl1;
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click_1);
            // 
            // btnClose
            // 
            this.btnClose.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.btnClose.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnClose.Appearance.Options.UseBackColor = true;
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Appearance.Options.UseTextOptions = true;
            this.btnClose.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnClose.Location = new System.Drawing.Point(1242, 638);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.MaximumSize = new System.Drawing.Size(125, 41);
            this.btnClose.MinimumSize = new System.Drawing.Size(125, 41);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(125, 41);
            this.btnClose.StyleController = this.layoutControl1;
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // dtToDate
            // 
            this.dtToDate.EditValue = null;
            this.dtToDate.Location = new System.Drawing.Point(169, 645);
            this.dtToDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtToDate.MenuManager = this.rbcbase;
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtToDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtToDate.Size = new System.Drawing.Size(68, 26);
            this.dtToDate.StyleController = this.layoutControl1;
            this.dtToDate.TabIndex = 9;
            // 
            // dtFromDate
            // 
            this.dtFromDate.EditValue = null;
            this.dtFromDate.Location = new System.Drawing.Point(58, 645);
            this.dtFromDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtFromDate.MenuManager = this.rbcbase;
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFromDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFromDate.Size = new System.Drawing.Size(68, 26);
            this.dtFromDate.StyleController = this.layoutControl1;
            this.dtFromDate.TabIndex = 10;
            // 
            // chkRODO
            // 
            this.chkRODO.Location = new System.Drawing.Point(249, 646);
            this.chkRODO.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkRODO.MenuManager = this.rbcbase;
            this.chkRODO.Name = "chkRODO";
            this.chkRODO.Properties.Caption = "RO";
            this.chkRODO.Size = new System.Drawing.Size(48, 24);
            this.chkRODO.StyleController = this.layoutControl1;
            this.chkRODO.TabIndex = 11;
            // 
            // lkeCustomerFind
            // 
            this.lkeCustomerFind.Location = new System.Drawing.Point(379, 645);
            this.lkeCustomerFind.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lkeCustomerFind.Name = "lkeCustomerFind";
            this.lkeCustomerFind.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeCustomerFind.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerID", "ID", 27, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerNumber", "Number", 133, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerName", "Name", 333, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lkeCustomerFind.Properties.DropDownRows = 20;
            this.lkeCustomerFind.Properties.NullText = "";
            this.lkeCustomerFind.Properties.PopupFormMinSize = new System.Drawing.Size(349, 0);
            this.lkeCustomerFind.Properties.ShowFooter = false;
            this.lkeCustomerFind.Properties.ShowHeader = false;
            this.lkeCustomerFind.Size = new System.Drawing.Size(69, 26);
            this.lkeCustomerFind.StyleController = this.layoutControl1;
            this.lkeCustomerFind.TabIndex = 4;
            this.lkeCustomerFind.EditValueChanged += new System.EventHandler(this.lkeCustomerFind_EditValueChanged);
            // 
            // txtCustomerNameFind
            // 
            this.txtCustomerNameFind.Location = new System.Drawing.Point(17, 691);
            this.txtCustomerNameFind.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCustomerNameFind.Name = "txtCustomerNameFind";
            this.txtCustomerNameFind.Properties.ReadOnly = true;
            this.txtCustomerNameFind.Size = new System.Drawing.Size(1350, 26);
            this.txtCustomerNameFind.StyleController = this.layoutControl1;
            this.txtCustomerNameFind.TabIndex = 5;
            // 
            // btn_delete
            // 
            this.btn_delete.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger;
            this.btn_delete.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btn_delete.Appearance.Options.UseBackColor = true;
            this.btn_delete.Appearance.Options.UseFont = true;
            this.btn_delete.Appearance.Options.UseTextOptions = true;
            this.btn_delete.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btn_delete.Location = new System.Drawing.Point(456, 638);
            this.btn_delete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_delete.MaximumSize = new System.Drawing.Size(125, 41);
            this.btn_delete.MinimumSize = new System.Drawing.Size(125, 41);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(125, 41);
            this.btn_delete.StyleController = this.layoutControl1;
            this.btn_delete.TabIndex = 7;
            this.btn_delete.Text = "Delete";
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.grdStockForExport;
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 158);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(1278, 159);
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem8,
            this.layoutControlGroup2,
            this.layoutControlItem1,
            this.layoutControlItem10,
            this.layoutControlItem11,
            this.layoutControlItem12});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1384, 736);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnDetailClient;
            this.layoutControlItem2.Location = new System.Drawing.Point(572, 619);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(133, 53);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnSafetyStock;
            this.layoutControlItem3.Location = new System.Drawing.Point(705, 619);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(387, 53);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.SupportHorzAlignment;
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnRefresh;
            this.layoutControlItem4.Location = new System.Drawing.Point(1092, 619);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(133, 53);
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnClose;
            this.layoutControlItem5.Location = new System.Drawing.Point(1225, 619);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(133, 53);
            this.layoutControlItem5.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.chkRODO;
            this.layoutControlItem8.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.layoutControlItem8.Location = new System.Drawing.Point(232, 619);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(56, 53);
            this.layoutControlItem8.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            this.layoutControlItem8.TrimClientAreaToControl = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem7,
            this.layoutControlItem6});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 619);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlGroup2.Size = new System.Drawing.Size(232, 53);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.dtFromDate;
            this.layoutControlItem7.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(111, 39);
            this.layoutControlItem7.Text = "From";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(30, 16);
            this.layoutControlItem7.TrimClientAreaToControl = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.dtToDate;
            this.layoutControlItem6.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.layoutControlItem6.Location = new System.Drawing.Point(111, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(111, 39);
            this.layoutControlItem6.Text = "To";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(30, 16);
            this.layoutControlItem6.TrimClientAreaToControl = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdStockWarning;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1358, 619);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.lkeCustomerFind;
            this.layoutControlItem10.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.layoutControlItem10.CustomizationFormText = "Customer :";
            this.layoutControlItem10.Location = new System.Drawing.Point(288, 619);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(151, 53);
            this.layoutControlItem10.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem10.Text = "Customer :";
            this.layoutControlItem10.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem10.TextSize = new System.Drawing.Size(69, 16);
            this.layoutControlItem10.TextToControlDistance = 5;
            this.layoutControlItem10.TrimClientAreaToControl = false;
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.txtCustomerNameFind;
            this.layoutControlItem11.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.layoutControlItem11.CustomizationFormText = "Find by ID";
            this.layoutControlItem11.Location = new System.Drawing.Point(0, 672);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(1358, 38);
            this.layoutControlItem11.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem11.Text = "Find by ID";
            this.layoutControlItem11.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem11.TextVisible = false;
            this.layoutControlItem11.TrimClientAreaToControl = false;
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.btn_delete;
            this.layoutControlItem12.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem12.Location = new System.Drawing.Point(439, 619);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(133, 53);
            this.layoutControlItem12.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem12.Text = "layoutControlItem4";
            this.layoutControlItem12.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem12.TextVisible = false;
            // 
            // frm_WM_SafetyStockWarnings
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 787);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_WM_SafetyStockWarnings.IconOptions.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_WM_SafetyStockWarnings";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "Safety Stock Warning";
            this.Load += new System.EventHandler(this.frm_WM_SafetyStockWarnings_Load);
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdStockForExport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvStockForExport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdStockWarning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvStockWarning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_txt_ProductNumber2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_txt_ProductNumber6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_hpl_SafetyStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_txt_ProductNumberP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_Reason)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_btn_OpenReason)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRODO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeCustomerFind.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerNameFind.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl grdStockWarning;
        private Common.Controls.WMSGridView grvStockWarning;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn grcProductNumber2;
        private DevExpress.XtraGrid.Columns.GridColumn grcProductName6;
        private DevExpress.XtraGrid.Columns.GridColumn grcStockP2Qty;
        private DevExpress.XtraGrid.Columns.GridColumn grcProductNumber6;
        private DevExpress.XtraGrid.Columns.GridColumn grcWaitingQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn grcAvailableStock;
        private DevExpress.XtraGrid.Columns.GridColumn grcSafetyStock;
        private DevExpress.XtraGrid.Columns.GridColumn grcMissingQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn grcProductNumberP;
        private DevExpress.XtraGrid.Columns.GridColumn grcStockPackQty;
        private DevExpress.XtraGrid.Columns.GridColumn grcRemark;
        private DevExpress.XtraGrid.Columns.GridColumn grcReason;
        private DevExpress.XtraGrid.Columns.GridColumn grcOpenReason;
        private DevExpress.XtraGrid.Columns.GridColumn grcProductID6;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rpi_btn_OpenReason;
        private DevExpress.XtraEditors.SimpleButton btnDetailClient;
        private DevExpress.XtraEditors.SimpleButton btnSafetyStock;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.DateEdit dtToDate;
        private DevExpress.XtraEditors.DateEdit dtFromDate;
        private DevExpress.XtraEditors.CheckEdit chkRODO;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rpi_txt_ProductNumber2;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpi_hpl_SafetyStock;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rpi_txt_ProductNumber6;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rpi_txt_ProductNumberP;
        private DevExpress.XtraGrid.GridControl grdStockForExport;
        private Common.Controls.WMSGridView grvStockForExport;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraGrid.Columns.GridColumn grcExportCustomerClientName;
        private DevExpress.XtraGrid.Columns.GridColumn grcExportDONumber;
        private DevExpress.XtraGrid.Columns.GridColumn grcExportDODate;
        private DevExpress.XtraGrid.Columns.GridColumn grcExportRequirement;
        private DevExpress.XtraGrid.Columns.GridColumn grcExportRemark;
        private DevExpress.XtraGrid.Columns.GridColumn grcExportCustomerRef;
        private DevExpress.XtraGrid.Columns.GridColumn grcExportProductNumber;
        private DevExpress.XtraGrid.Columns.GridColumn grcExportProductName;
        private DevExpress.XtraGrid.Columns.GridColumn grcExportWeight;
        private DevExpress.XtraGrid.Columns.GridColumn grcExportQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn grcExportPlts;
        private DevExpress.XtraGrid.Columns.GridColumn grcExportPackage;
        private DevExpress.XtraGrid.Columns.GridColumn grcExportProDate;
        private DevExpress.XtraGrid.Columns.GridColumn grcExportUseByDate;
        private DevExpress.XtraGrid.Columns.GridColumn grcExportCustomerRefRO;
        private DevExpress.XtraGrid.Columns.GridColumn grcExportRODate;
        private DevExpress.XtraGrid.Columns.GridColumn grcExportRORemark;
        private DevExpress.XtraGrid.Columns.GridColumn grcExportRO;
        private DevExpress.XtraGrid.Columns.GridColumn grcExportDOID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpi_lke_Reason;
        private DevExpress.XtraGrid.Columns.GridColumn grcSelectReason;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private DevExpress.XtraEditors.LookUpEdit lkeCustomerFind;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraEditors.TextEdit txtCustomerNameFind;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraGrid.Columns.GridColumn grcIDOuter;
        private DevExpress.XtraEditors.SimpleButton btn_delete;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
    }
}