namespace UI.MasterSystemSetup
{
    partial class frm_MSS_CustomersList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_MSS_CustomersList));
            DevExpress.Utils.Animation.PushTransition pushTransition1 = new DevExpress.Utils.Animation.PushTransition();
            this.radg_Actions = new DevExpress.XtraEditors.RadioGroup();
            this.grdCustomerList = new DevExpress.XtraGrid.GridControl();
            this.grvCustomerList = new Common.Controls.WMSGridView();
            this.grcCustomerID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_hpl_CustomerNumber = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.grcCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerInitial = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcPrimaryContact = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerPhone1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerPhone2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerFax1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerFax2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerOtherContact = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerMarketingInfo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerInvoiceName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerInvoiceAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerInvoiceTaxCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerDiscontinued = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerMainID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerByExpiryDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerSendNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerSubID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerHold = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerHoldMessage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerTimeStamp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerHomeLocationChange = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerDispatchingByClient = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerPalletType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerWebsite = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerEmailBilling = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerDispatchType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcIsAllowEDI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerHoldLimitWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerTaxGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcBarcodeScanRequire = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcDefaultProcessTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerStoreID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_lke_CustomerAssignedToList = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btn_Close = new DevExpress.XtraEditors.SimpleButton();
            this.btn_refresh = new DevExpress.XtraEditors.SimpleButton();
            this.btn_New = new DevExpress.XtraEditors.SimpleButton();
            this.btnExport = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.workspaceManager1 = new DevExpress.Utils.WorkspaceManager(this.components);
            this.c = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radg_Actions.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCustomerList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCustomerList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_hpl_CustomerNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_CustomerAssignedToList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // rbcbase
            // 
            //this.rbcbase.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(24, 25, 24, 25);
            this.rbcbase.ExpandCollapseItem.Id = 0;
            this.rbcbase.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnExport,
            this.barButtonItem2});
            this.rbcbase.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbcbase.OptionsCustomizationForm.FormIcon = ((System.Drawing.Icon)(resources.GetObject("resource.FormIcon")));
            this.rbcbase.OptionsMenuMinWidth = 264;
            // 
            // 
            // 
            this.rbcbase.SearchEditItem.AccessibleName = "Search Item";
            this.rbcbase.SearchEditItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.rbcbase.SearchEditItem.EditWidth = 150;
            this.rbcbase.SearchEditItem.Id = -5000;
            this.rbcbase.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.rbcbase.Size = new System.Drawing.Size(1412, 51);
            // 
            // radg_Actions
            // 
            this.radg_Actions.Location = new System.Drawing.Point(12, 12);
            this.radg_Actions.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radg_Actions.MenuManager = this.rbcbase;
            this.radg_Actions.Name = "radg_Actions";
            this.radg_Actions.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.radg_Actions.Properties.ItemHorzAlignment = DevExpress.XtraEditors.RadioItemHorzAlignment.Far;
            this.radg_Actions.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(0)), "Active"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(1)), "Discontinued"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(2)), "Available")});
            this.radg_Actions.Properties.ItemsLayout = DevExpress.XtraEditors.RadioGroupItemsLayout.Flow;
            this.radg_Actions.Size = new System.Drawing.Size(1388, 46);
            this.radg_Actions.StyleController = this.layoutControl2;
            this.radg_Actions.TabIndex = 15;
            // 
            // grdCustomerList
            // 
            this.grdCustomerList.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grdCustomerList.Location = new System.Drawing.Point(12, 62);
            this.grdCustomerList.MainView = this.grvCustomerList;
            this.grdCustomerList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdCustomerList.MenuManager = this.rbcbase;
            this.grdCustomerList.Name = "grdCustomerList";
            this.grdCustomerList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpi_hpl_CustomerNumber,
            this.rpi_lke_CustomerAssignedToList});
            this.grdCustomerList.Size = new System.Drawing.Size(1388, 668);
            this.grdCustomerList.TabIndex = 4;
            this.grdCustomerList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvCustomerList});
            // 
            // grvCustomerList
            // 
            this.grvCustomerList.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grvCustomerList.Appearance.FooterPanel.Options.UseFont = true;
            this.grvCustomerList.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvCustomerList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grcCustomerID,
            this.grcCustomerNumber,
            this.grcCustomerName,
            this.grcCustomerInitial,
            this.grcCustomerAddress,
            this.grcCustomerType,
            this.grcPrimaryContact,
            this.grcCustomerPhone1,
            this.grcCustomerPhone2,
            this.grcCustomerFax1,
            this.grcCustomerFax2,
            this.grcCustomerEmail,
            this.grcCustomerOtherContact,
            this.grcCustomerMarketingInfo,
            this.grcCustomerInvoiceName,
            this.grcCustomerInvoiceAddress,
            this.grcCustomerInvoiceTaxCode,
            this.grcCustomerDiscontinued,
            this.grcCustomerCategory,
            this.grcCustomerGroup,
            this.grcCustomerMainID,
            this.grcCustomerByExpiryDate,
            this.grcCustomerSendNote,
            this.grcCustomerSubID,
            this.grcCustomerHold,
            this.grcCustomerHoldMessage,
            this.grcCustomerTimeStamp,
            this.grcCustomerHomeLocationChange,
            this.grcCustomerDispatchingByClient,
            this.grcCustomerPalletType,
            this.grcCustomerWebsite,
            this.grcCustomerEmailBilling,
            this.grcCustomerDispatchType,
            this.grcIsAllowEDI,
            this.grcCustomerHoldLimitWeight,
            this.grcCustomerTaxGroup,
            this.grcBarcodeScanRequire,
            this.grcDefaultProcessTime,
            this.grcCustomerStoreID,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9});
            this.grvCustomerList.FixedLineWidth = 4;
            this.grvCustomerList.GridControl = this.grdCustomerList;
            this.grvCustomerList.Name = "grvCustomerList";
            this.grvCustomerList.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grvCustomerList.OptionsFind.AlwaysVisible = true;
            this.grvCustomerList.OptionsFind.ShowFindButton = false;
            this.grvCustomerList.OptionsSelection.MultiSelect = true;
            this.grvCustomerList.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvCustomerList.PaintStyleName = "Skin";
            // 
            // grcCustomerID
            // 
            this.grcCustomerID.Caption = "CUSTOMER ID";
            this.grcCustomerID.FieldName = "CustomerID";
            this.grcCustomerID.MaxWidth = 80;
            this.grcCustomerID.MinWidth = 80;
            this.grcCustomerID.Name = "grcCustomerID";
            this.grcCustomerID.OptionsColumn.AllowEdit = false;
            // 
            // grcCustomerNumber
            // 
            this.grcCustomerNumber.Caption = "NUMBER";
            this.grcCustomerNumber.ColumnEdit = this.rpi_hpl_CustomerNumber;
            this.grcCustomerNumber.FieldName = "CustomerNumber";
            this.grcCustomerNumber.MaxWidth = 80;
            this.grcCustomerNumber.MinWidth = 80;
            this.grcCustomerNumber.Name = "grcCustomerNumber";
            this.grcCustomerNumber.Visible = true;
            this.grcCustomerNumber.VisibleIndex = 0;
            this.grcCustomerNumber.Width = 80;
            // 
            // rpi_hpl_CustomerNumber
            // 
            this.rpi_hpl_CustomerNumber.AutoHeight = false;
            this.rpi_hpl_CustomerNumber.Name = "rpi_hpl_CustomerNumber";
            // 
            // grcCustomerName
            // 
            this.grcCustomerName.Caption = "NAME";
            this.grcCustomerName.FieldName = "CustomerName";
            this.grcCustomerName.Name = "grcCustomerName";
            this.grcCustomerName.OptionsColumn.AllowEdit = false;
            this.grcCustomerName.Visible = true;
            this.grcCustomerName.VisibleIndex = 1;
            this.grcCustomerName.Width = 389;
            // 
            // grcCustomerInitial
            // 
            this.grcCustomerInitial.Caption = "INITIAL";
            this.grcCustomerInitial.FieldName = "Initial";
            this.grcCustomerInitial.MaxWidth = 49;
            this.grcCustomerInitial.MinWidth = 49;
            this.grcCustomerInitial.Name = "grcCustomerInitial";
            this.grcCustomerInitial.OptionsColumn.AllowEdit = false;
            this.grcCustomerInitial.Width = 49;
            // 
            // grcCustomerAddress
            // 
            this.grcCustomerAddress.Caption = "ADDRESS";
            this.grcCustomerAddress.FieldName = "Address";
            this.grcCustomerAddress.Name = "grcCustomerAddress";
            this.grcCustomerAddress.OptionsColumn.AllowEdit = false;
            this.grcCustomerAddress.Width = 116;
            // 
            // grcCustomerType
            // 
            this.grcCustomerType.Caption = "CUSTOMER TYPE";
            this.grcCustomerType.FieldName = "CustomerType";
            this.grcCustomerType.Name = "grcCustomerType";
            this.grcCustomerType.OptionsColumn.AllowEdit = false;
            this.grcCustomerType.Visible = true;
            this.grcCustomerType.VisibleIndex = 2;
            this.grcCustomerType.Width = 172;
            // 
            // grcPrimaryContact
            // 
            this.grcPrimaryContact.Caption = "PRIMARY CONTACT";
            this.grcPrimaryContact.FieldName = "PrimaryContact";
            this.grcPrimaryContact.Name = "grcPrimaryContact";
            this.grcPrimaryContact.OptionsColumn.AllowEdit = false;
            this.grcPrimaryContact.Width = 144;
            // 
            // grcCustomerPhone1
            // 
            this.grcCustomerPhone1.Caption = "PHONE";
            this.grcCustomerPhone1.FieldName = "Phone1";
            this.grcCustomerPhone1.MinWidth = 80;
            this.grcCustomerPhone1.Name = "grcCustomerPhone1";
            this.grcCustomerPhone1.OptionsColumn.AllowEdit = false;
            this.grcCustomerPhone1.Visible = true;
            this.grcCustomerPhone1.VisibleIndex = 3;
            this.grcCustomerPhone1.Width = 168;
            // 
            // grcCustomerPhone2
            // 
            this.grcCustomerPhone2.Caption = "PHONE2";
            this.grcCustomerPhone2.FieldName = "Phone2";
            this.grcCustomerPhone2.MaxWidth = 80;
            this.grcCustomerPhone2.MinWidth = 80;
            this.grcCustomerPhone2.Name = "grcCustomerPhone2";
            this.grcCustomerPhone2.OptionsColumn.AllowEdit = false;
            // 
            // grcCustomerFax1
            // 
            this.grcCustomerFax1.Caption = "FAX";
            this.grcCustomerFax1.FieldName = "Fax";
            this.grcCustomerFax1.MaxWidth = 100;
            this.grcCustomerFax1.MinWidth = 120;
            this.grcCustomerFax1.Name = "grcCustomerFax1";
            this.grcCustomerFax1.OptionsColumn.AllowEdit = false;
            this.grcCustomerFax1.Width = 120;
            // 
            // grcCustomerFax2
            // 
            this.grcCustomerFax2.Caption = "FAX2";
            this.grcCustomerFax2.FieldName = "Fax2";
            this.grcCustomerFax2.MaxWidth = 100;
            this.grcCustomerFax2.MinWidth = 100;
            this.grcCustomerFax2.Name = "grcCustomerFax2";
            this.grcCustomerFax2.OptionsColumn.AllowEdit = false;
            // 
            // grcCustomerEmail
            // 
            this.grcCustomerEmail.Caption = "EMAIL";
            this.grcCustomerEmail.FieldName = "Email";
            this.grcCustomerEmail.Name = "grcCustomerEmail";
            this.grcCustomerEmail.OptionsColumn.AllowEdit = false;
            this.grcCustomerEmail.Visible = true;
            this.grcCustomerEmail.VisibleIndex = 4;
            this.grcCustomerEmail.Width = 261;
            // 
            // grcCustomerOtherContact
            // 
            this.grcCustomerOtherContact.Caption = "OTHER CONTACT";
            this.grcCustomerOtherContact.FieldName = "OtherContact";
            this.grcCustomerOtherContact.Name = "grcCustomerOtherContact";
            this.grcCustomerOtherContact.OptionsColumn.AllowEdit = false;
            // 
            // grcCustomerMarketingInfo
            // 
            this.grcCustomerMarketingInfo.Caption = "MARKETING INFO";
            this.grcCustomerMarketingInfo.FieldName = "MarketingInfo";
            this.grcCustomerMarketingInfo.Name = "grcCustomerMarketingInfo";
            this.grcCustomerMarketingInfo.OptionsColumn.AllowEdit = false;
            // 
            // grcCustomerInvoiceName
            // 
            this.grcCustomerInvoiceName.Caption = "CUSTOMER INVOICE NAME";
            this.grcCustomerInvoiceName.FieldName = "CustomerInvoiceName";
            this.grcCustomerInvoiceName.Name = "grcCustomerInvoiceName";
            this.grcCustomerInvoiceName.OptionsColumn.AllowEdit = false;
            // 
            // grcCustomerInvoiceAddress
            // 
            this.grcCustomerInvoiceAddress.Caption = "CUSTOMER INVOICE ADDRESS";
            this.grcCustomerInvoiceAddress.FieldName = "CustomerInvoiceAddress";
            this.grcCustomerInvoiceAddress.Name = "grcCustomerInvoiceAddress";
            this.grcCustomerInvoiceAddress.OptionsColumn.AllowEdit = false;
            // 
            // grcCustomerInvoiceTaxCode
            // 
            this.grcCustomerInvoiceTaxCode.Caption = "CUSTOMER INVOICE TAX CODE";
            this.grcCustomerInvoiceTaxCode.FieldName = "CustomerInvoiceTaxCode";
            this.grcCustomerInvoiceTaxCode.Name = "grcCustomerInvoiceTaxCode";
            this.grcCustomerInvoiceTaxCode.OptionsColumn.AllowEdit = false;
            // 
            // grcCustomerDiscontinued
            // 
            this.grcCustomerDiscontinued.Caption = "STOP";
            this.grcCustomerDiscontinued.FieldName = "CustomerDiscontinued";
            this.grcCustomerDiscontinued.Name = "grcCustomerDiscontinued";
            this.grcCustomerDiscontinued.OptionsColumn.AllowEdit = false;
            this.grcCustomerDiscontinued.Visible = true;
            this.grcCustomerDiscontinued.VisibleIndex = 11;
            this.grcCustomerDiscontinued.Width = 63;
            // 
            // grcCustomerCategory
            // 
            this.grcCustomerCategory.Caption = "CATEGORY";
            this.grcCustomerCategory.FieldName = "CustomerCategory";
            this.grcCustomerCategory.Name = "grcCustomerCategory";
            this.grcCustomerCategory.OptionsColumn.AllowEdit = false;
            // 
            // grcCustomerGroup
            // 
            this.grcCustomerGroup.Caption = "CUSTOMER GROUP";
            this.grcCustomerGroup.FieldName = "CustomerGroup";
            this.grcCustomerGroup.Name = "grcCustomerGroup";
            this.grcCustomerGroup.OptionsColumn.AllowEdit = false;
            // 
            // grcCustomerMainID
            // 
            this.grcCustomerMainID.Caption = "CUSTOMER MAIN";
            this.grcCustomerMainID.FieldName = "CustomerMainID";
            this.grcCustomerMainID.Name = "grcCustomerMainID";
            this.grcCustomerMainID.OptionsColumn.AllowEdit = false;
            this.grcCustomerMainID.Visible = true;
            this.grcCustomerMainID.VisibleIndex = 8;
            this.grcCustomerMainID.Width = 101;
            // 
            // grcCustomerByExpiryDate
            // 
            this.grcCustomerByExpiryDate.Caption = "CUSTOMER BY EXPIRY DATE";
            this.grcCustomerByExpiryDate.FieldName = "CustomerByExpiryDate";
            this.grcCustomerByExpiryDate.Name = "grcCustomerByExpiryDate";
            this.grcCustomerByExpiryDate.OptionsColumn.AllowEdit = false;
            // 
            // grcCustomerSendNote
            // 
            this.grcCustomerSendNote.Caption = "SEND NOTE";
            this.grcCustomerSendNote.FieldName = "SendNote";
            this.grcCustomerSendNote.Name = "grcCustomerSendNote";
            this.grcCustomerSendNote.OptionsColumn.AllowEdit = false;
            // 
            // grcCustomerSubID
            // 
            this.grcCustomerSubID.Caption = "CUSTOMER SUB ID";
            this.grcCustomerSubID.FieldName = "CustomerSubID";
            this.grcCustomerSubID.Name = "grcCustomerSubID";
            this.grcCustomerSubID.OptionsColumn.AllowEdit = false;
            // 
            // grcCustomerHold
            // 
            this.grcCustomerHold.Caption = "HOLD";
            this.grcCustomerHold.FieldName = "Hold";
            this.grcCustomerHold.Name = "grcCustomerHold";
            this.grcCustomerHold.OptionsColumn.AllowEdit = false;
            // 
            // grcCustomerHoldMessage
            // 
            this.grcCustomerHoldMessage.Caption = "HOLD MESSAGE";
            this.grcCustomerHoldMessage.FieldName = "HoldMessage";
            this.grcCustomerHoldMessage.Name = "grcCustomerHoldMessage";
            this.grcCustomerHoldMessage.OptionsColumn.AllowEdit = false;
            // 
            // grcCustomerTimeStamp
            // 
            this.grcCustomerTimeStamp.Caption = "TS";
            this.grcCustomerTimeStamp.FieldName = "ts";
            this.grcCustomerTimeStamp.Name = "grcCustomerTimeStamp";
            this.grcCustomerTimeStamp.OptionsColumn.AllowEdit = false;
            // 
            // grcCustomerHomeLocationChange
            // 
            this.grcCustomerHomeLocationChange.Caption = "HOME LOCATION CHANGE";
            this.grcCustomerHomeLocationChange.FieldName = "HomeLocationChange";
            this.grcCustomerHomeLocationChange.Name = "grcCustomerHomeLocationChange";
            this.grcCustomerHomeLocationChange.OptionsColumn.AllowEdit = false;
            // 
            // grcCustomerDispatchingByClient
            // 
            this.grcCustomerDispatchingByClient.Caption = "DISPATCHING BY CLIENT";
            this.grcCustomerDispatchingByClient.FieldName = "DispatchingByClient";
            this.grcCustomerDispatchingByClient.Name = "grcCustomerDispatchingByClient";
            this.grcCustomerDispatchingByClient.OptionsColumn.AllowEdit = false;
            // 
            // grcCustomerPalletType
            // 
            this.grcCustomerPalletType.Caption = "PALLET TYPE";
            this.grcCustomerPalletType.FieldName = "CustomerPalletType";
            this.grcCustomerPalletType.Name = "grcCustomerPalletType";
            this.grcCustomerPalletType.OptionsColumn.AllowEdit = false;
            // 
            // grcCustomerWebsite
            // 
            this.grcCustomerWebsite.Caption = "WEBSITE";
            this.grcCustomerWebsite.FieldName = "Website";
            this.grcCustomerWebsite.Name = "grcCustomerWebsite";
            this.grcCustomerWebsite.OptionsColumn.AllowEdit = false;
            // 
            // grcCustomerEmailBilling
            // 
            this.grcCustomerEmailBilling.Caption = "BILLING EMAIL";
            this.grcCustomerEmailBilling.FieldName = "EmailBilling";
            this.grcCustomerEmailBilling.Name = "grcCustomerEmailBilling";
            this.grcCustomerEmailBilling.OptionsColumn.AllowEdit = false;
            // 
            // grcCustomerDispatchType
            // 
            this.grcCustomerDispatchType.Caption = "DISPATCH TYPE";
            this.grcCustomerDispatchType.FieldName = "CustomerDispatchType";
            this.grcCustomerDispatchType.Name = "grcCustomerDispatchType";
            this.grcCustomerDispatchType.OptionsColumn.AllowEdit = false;
            // 
            // grcIsAllowEDI
            // 
            this.grcIsAllowEDI.Caption = "ALLOW EDI";
            this.grcIsAllowEDI.FieldName = "IsAllowEDI";
            this.grcIsAllowEDI.Name = "grcIsAllowEDI";
            this.grcIsAllowEDI.OptionsColumn.AllowEdit = false;
            // 
            // grcCustomerHoldLimitWeight
            // 
            this.grcCustomerHoldLimitWeight.Caption = "LIMIT WEIGHT";
            this.grcCustomerHoldLimitWeight.FieldName = "HoldLimitWeight";
            this.grcCustomerHoldLimitWeight.Name = "grcCustomerHoldLimitWeight";
            this.grcCustomerHoldLimitWeight.OptionsColumn.AllowEdit = false;
            // 
            // grcCustomerTaxGroup
            // 
            this.grcCustomerTaxGroup.Caption = "TAX GROUP";
            this.grcCustomerTaxGroup.FieldName = "CustomerTaxGroup";
            this.grcCustomerTaxGroup.Name = "grcCustomerTaxGroup";
            this.grcCustomerTaxGroup.OptionsColumn.AllowEdit = false;
            // 
            // grcBarcodeScanRequire
            // 
            this.grcBarcodeScanRequire.Caption = "BARCODES SCAN REQUIRE";
            this.grcBarcodeScanRequire.FieldName = "BarcodeScanRequire";
            this.grcBarcodeScanRequire.Name = "grcBarcodeScanRequire";
            this.grcBarcodeScanRequire.OptionsColumn.AllowEdit = false;
            // 
            // grcDefaultProcessTime
            // 
            this.grcDefaultProcessTime.Caption = "DEFAULT PROCESS TIME";
            this.grcDefaultProcessTime.FieldName = "DefaultProcessTime";
            this.grcDefaultProcessTime.Name = "grcDefaultProcessTime";
            this.grcDefaultProcessTime.OptionsColumn.AllowEdit = false;
            // 
            // grcCustomerStoreID
            // 
            this.grcCustomerStoreID.Caption = "STORE";
            this.grcCustomerStoreID.FieldName = "StoreID";
            this.grcCustomerStoreID.Name = "grcCustomerStoreID";
            this.grcCustomerStoreID.OptionsColumn.AllowEdit = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Store Number";
            this.gridColumn1.FieldName = "StoreNumber";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 7;
            this.gridColumn1.Width = 147;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Customer Type";
            this.gridColumn2.FieldName = "CustomerType";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Assigned To";
            this.gridColumn3.ColumnEdit = this.rpi_lke_CustomerAssignedToList;
            this.gridColumn3.FieldName = "CustomerAssignedTo";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 9;
            this.gridColumn3.Width = 129;
            // 
            // rpi_lke_CustomerAssignedToList
            // 
            this.rpi_lke_CustomerAssignedToList.AutoHeight = false;
            this.rpi_lke_CustomerAssignedToList.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpi_lke_CustomerAssignedToList.DisplayMember = "VietnamName";
            this.rpi_lke_CustomerAssignedToList.Name = "rpi_lke_CustomerAssignedToList";
            this.rpi_lke_CustomerAssignedToList.NullText = "";
            this.rpi_lke_CustomerAssignedToList.ReadOnly = true;
            this.rpi_lke_CustomerAssignedToList.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.rpi_lke_CustomerAssignedToList.ShowFooter = false;
            this.rpi_lke_CustomerAssignedToList.ShowHeader = false;
            this.rpi_lke_CustomerAssignedToList.ValueMember = "CustomerID";
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "CateName";
            this.gridColumn4.FieldName = "CateName";
            this.gridColumn4.MinWidth = 25;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Width = 93;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "CustomerMainOnReport";
            this.gridColumn5.FieldName = "CustomerMainOnReport";
            this.gridColumn5.MinWidth = 27;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 10;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Update By";
            this.gridColumn6.FieldName = "UpdateBy";
            this.gridColumn6.MinWidth = 25;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 12;
            this.gridColumn6.Width = 93;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Update Time";
            this.gridColumn7.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn7.FieldName = "UpdateTime";
            this.gridColumn7.MinWidth = 25;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.ReadOnly = true;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 13;
            this.gridColumn7.Width = 93;
            // 
            // gridColumn8
            // 
            this.gridColumn8.FieldName = "EmailBilling";
            this.gridColumn8.MinWidth = 25;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.ReadOnly = true;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 5;
            this.gridColumn8.Width = 93;
            // 
            // gridColumn9
            // 
            this.gridColumn9.FieldName = "InvoiceSendEmail";
            this.gridColumn9.MinWidth = 25;
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.ReadOnly = true;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 6;
            this.gridColumn9.Width = 93;
            // 
            // btn_Close
            // 
            this.btn_Close.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.btn_Close.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btn_Close.Appearance.Options.UseBackColor = true;
            this.btn_Close.Appearance.Options.UseFont = true;
            this.btn_Close.Location = new System.Drawing.Point(1275, 734);
            this.btn_Close.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Close.MaximumSize = new System.Drawing.Size(125, 41);
            this.btn_Close.MinimumSize = new System.Drawing.Size(125, 41);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(125, 41);
            this.btn_Close.StyleController = this.layoutControl2;
            this.btn_Close.TabIndex = 14;
            this.btn_Close.Text = "Close";
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_refresh
            // 
            this.btn_refresh.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger;
            this.btn_refresh.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btn_refresh.Appearance.Options.UseBackColor = true;
            this.btn_refresh.Appearance.Options.UseFont = true;
            this.btn_refresh.Location = new System.Drawing.Point(1146, 734);
            this.btn_refresh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_refresh.MaximumSize = new System.Drawing.Size(125, 41);
            this.btn_refresh.MinimumSize = new System.Drawing.Size(125, 41);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(125, 41);
            this.btn_refresh.StyleController = this.layoutControl2;
            this.btn_refresh.TabIndex = 13;
            this.btn_refresh.Text = "Refresh";
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // btn_New
            // 
            this.btn_New.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Question;
            this.btn_New.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btn_New.Appearance.Options.UseBackColor = true;
            this.btn_New.Appearance.Options.UseFont = true;
            this.btn_New.Location = new System.Drawing.Point(1017, 734);
            this.btn_New.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_New.MaximumSize = new System.Drawing.Size(125, 41);
            this.btn_New.MinimumSize = new System.Drawing.Size(125, 41);
            this.btn_New.Name = "btn_New";
            this.btn_New.Size = new System.Drawing.Size(125, 41);
            this.btn_New.StyleController = this.layoutControl2;
            this.btn_New.TabIndex = 10;
            this.btn_New.Text = "New";
            this.btn_New.Click += new System.EventHandler(this.btn_New_Click);
            // 
            // btnExport
            // 
            this.btnExport.Caption = "Export Data";
            this.btnExport.Id = 1;
            this.btnExport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.ImageOptions.Image")));
            this.btnExport.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnExport.ImageOptions.LargeImage")));
            this.btnExport.Name = "btnExport";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Id = 2;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // popupMenu1
            // 
            this.popupMenu1.ItemLinks.Add(this.btnExport);
            this.popupMenu1.Name = "popupMenu1";
            this.popupMenu1.OptionsMultiColumn.ImageHorizontalAlignment = DevExpress.Utils.Drawing.ItemHorizontalAlignment.Left;
            this.popupMenu1.Ribbon = this.rbcbase;
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlTop.Size = new System.Drawing.Size(1412, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 838);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlBottom.Size = new System.Drawing.Size(1412, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 838);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1412, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 838);
            // 
            // workspaceManager1
            // 
            this.workspaceManager1.TargetControl = this;
            this.workspaceManager1.TransitionType = pushTransition1;
            // 
            // c
            // 
            this.c.AllowHotTrack = false;
            this.c.Location = new System.Drawing.Point(0, 0);
            this.c.Name = "c";
            this.c.Size = new System.Drawing.Size(1496, 42);
            this.c.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.radg_Actions);
            this.layoutControl2.Controls.Add(this.btn_Close);
            this.layoutControl2.Controls.Add(this.btn_refresh);
            this.layoutControl2.Controls.Add(this.grdCustomerList);
            this.layoutControl2.Controls.Add(this.btn_New);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(0, 51);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1108, 348, 812, 500);
            this.layoutControl2.Root = this.Root;
            this.layoutControl2.Size = new System.Drawing.Size(1412, 787);
            this.layoutControl2.TabIndex = 6;
            this.layoutControl2.Text = "layoutControl2";
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
            this.emptySpaceItem3,
            this.layoutControlItem3});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1412, 787);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdCustomerList;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 50);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1392, 672);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.radg_Actions;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(1392, 50);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btn_New;
            this.layoutControlItem3.Location = new System.Drawing.Point(1005, 722);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(129, 45);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btn_refresh;
            this.layoutControlItem4.Location = new System.Drawing.Point(1134, 722);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(129, 45);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btn_Close;
            this.layoutControlItem5.Location = new System.Drawing.Point(1263, 722);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(129, 45);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 722);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(1005, 45);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frm_MSS_CustomersList
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1412, 838);
            this.Controls.Add(this.layoutControl2);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_MSS_CustomersList.IconOptions.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_MSS_CustomersList";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "Customer List";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_MSS_CustomersList_FormClosing);
            this.Controls.SetChildIndex(this.barDockControlTop, 0);
            this.Controls.SetChildIndex(this.barDockControlBottom, 0);
            this.Controls.SetChildIndex(this.barDockControlRight, 0);
            this.Controls.SetChildIndex(this.barDockControlLeft, 0);
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radg_Actions.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCustomerList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCustomerList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_hpl_CustomerNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_CustomerAssignedToList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.GridControl grdCustomerList;
        private Common.Controls.WMSGridView grvCustomerList;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerID;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerNumber;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerInitial;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerAddress;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerType;
        private DevExpress.XtraGrid.Columns.GridColumn grcPrimaryContact;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerPhone1;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerPhone2;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerFax1;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerFax2;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerEmail;
        private DevExpress.XtraBars.BarButtonItem btnExport;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerOtherContact;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerMarketingInfo;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerInvoiceName;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerInvoiceAddress;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerInvoiceTaxCode;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerDiscontinued;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpi_hpl_CustomerNumber;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerCategory;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerGroup;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerMainID;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerByExpiryDate;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerSendNote;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerSubID;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerHold;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerHoldMessage;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerTimeStamp;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerHomeLocationChange;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerDispatchingByClient;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerPalletType;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerWebsite;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerEmailBilling;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerDispatchType;
        private DevExpress.XtraGrid.Columns.GridColumn grcIsAllowEDI;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerHoldLimitWeight;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerTaxGroup;
        private DevExpress.XtraGrid.Columns.GridColumn grcBarcodeScanRequire;
        private DevExpress.XtraGrid.Columns.GridColumn grcDefaultProcessTime;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerStoreID;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpi_lke_CustomerAssignedToList;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraEditors.SimpleButton btn_Close;
        private DevExpress.XtraEditors.SimpleButton btn_refresh;
        private DevExpress.XtraEditors.SimpleButton btn_New;
        private DevExpress.Utils.WorkspaceManager workspaceManager1;
        private DevExpress.XtraEditors.RadioGroup radg_Actions;
        private DevExpress.XtraLayout.EmptySpaceItem c;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}