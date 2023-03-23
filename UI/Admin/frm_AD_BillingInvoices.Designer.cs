namespace UI.Admin
{
    partial class frm_AD_BillingInvoices
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_AD_BillingInvoices));
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule3 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule4 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule5 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule6 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule7 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule8 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule9 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule10 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule11 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule12 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule13 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnVAT8 = new DevExpress.XtraEditors.SimpleButton();
            this.btnVat7 = new DevExpress.XtraEditors.SimpleButton();
            this.btnEditVAT = new DevExpress.XtraEditors.SimpleButton();
            this.btnImportExcel = new DevExpress.XtraEditors.SimpleButton();
            this.btnBreakInvoice = new DevExpress.XtraEditors.SimpleButton();
            this.btnUpdateManual = new DevExpress.XtraEditors.SimpleButton();
            this.textInvPeriod = new DevExpress.XtraEditors.TextEdit();
            this.btnSendEmail = new DevExpress.XtraEditors.SimpleButton();
            this.textCurrencyExchangeRate = new DevExpress.XtraEditors.TextEdit();
            this.txtPayDays = new DevExpress.XtraEditors.TextEdit();
            this.txtPONo = new DevExpress.XtraEditors.TextEdit();
            this.txtBuyer = new DevExpress.XtraEditors.TextEdit();
            this.btn_accept = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Update = new DevExpress.XtraEditors.SimpleButton();
            this.btn_NewBillingInvoices = new DevExpress.XtraEditors.SimpleButton();
            this.dtngBillingInvoices = new DevExpress.XtraEditors.DataNavigator();
            this.imgDataNavigator = new DevExpress.Utils.ImageCollection(this.components);
            this.txtCreatedBy = new DevExpress.XtraEditors.TextEdit();
            this.txtBillingInvoicesRecordNumber = new DevExpress.XtraEditors.TextEdit();
            this.memoInvRemark = new DevExpress.XtraEditors.MemoEdit();
            this.btn_Delete = new DevExpress.XtraEditors.SimpleButton();
            this.btn_UpdateCustomer = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.lkeStores = new DevExpress.XtraEditors.LookUpEdit();
            this.lkeCurrency = new DevExpress.XtraEditors.LookUpEdit();
            this.txtEInvNum = new DevExpress.XtraEditors.TextEdit();
            this.dteInvoiceDate = new DevExpress.XtraEditors.DateEdit();
            this.txtCreatedTime = new DevExpress.XtraEditors.TextEdit();
            this.textBillingID = new DevExpress.XtraEditors.TextEdit();
            this.txtCustomerName = new DevExpress.XtraEditors.TextEdit();
            this.textInvoiceAmount = new DevExpress.XtraEditors.TextEdit();
            this.textCustomerTaxCode = new DevExpress.XtraEditors.TextEdit();
            this.textVATAmount = new DevExpress.XtraEditors.TextEdit();
            this.textGrossAmount = new DevExpress.XtraEditors.TextEdit();
            this.textGrossAmountWording = new DevExpress.XtraEditors.TextEdit();
            this.lkeCustomers = new DevExpress.XtraEditors.LookUpEdit();
            this.lkePaymentMethod = new DevExpress.XtraEditors.LookUpEdit();
            this.txtConfirmedBy = new DevExpress.XtraEditors.TextEdit();
            this.txtConfirmedTime = new DevExpress.XtraEditors.TextEdit();
            this.grcBillingInvoiceDetails = new DevExpress.XtraGrid.GridControl();
            this.grvBillingInvoiceDetails = new Common.Controls.WMSGridView();
            this.colServiceName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colVAT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUOM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnItemdesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_btn_Delete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVATPercent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBreak = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_btn_Break = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.rpi_cbo_VATRate = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.textCustomerAddress = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlIUpdateCustomer = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem18 = new DevExpress.XtraLayout.LayoutControlItem();
            this.Created = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem21 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem22 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlUpdate = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlDelete = new DevExpress.XtraLayout.LayoutControlItem();
            this.Created1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.Created2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.Created3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem23 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem31 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem32 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem26 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem16 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem24 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem25 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemEmailReport = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem20 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlUpdateFooter = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem30 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem17 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlConfirm = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem6 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlEditVAT = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem27 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem28 = new DevExpress.XtraLayout.LayoutControlItem();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textInvPeriod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textCurrencyExchangeRate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPayDays.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPONo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBuyer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgDataNavigator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreatedBy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillingInvoicesRecordNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoInvRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeStores.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeCurrency.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEInvNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteInvoiceDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteInvoiceDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreatedTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBillingID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textInvoiceAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textCustomerTaxCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textVATAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textGrossAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textGrossAmountWording.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeCustomers.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkePaymentMethod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmedBy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmedTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcBillingInvoiceDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBillingInvoiceDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_btn_Delete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_btn_Break)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_cbo_VATRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textCustomerAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlIUpdateCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Created)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Created1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Created2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Created3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemEmailReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlUpdateFooter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlConfirm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlEditVAT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // rbcbase
            // 
            //this.rbcbase.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(24, 25, 24, 25);
            this.rbcbase.ExpandCollapseItem.Id = 0;
            this.rbcbase.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.rbcbase.Size = new System.Drawing.Size(1552, 51);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnVAT8);
            this.layoutControl1.Controls.Add(this.btnVat7);
            this.layoutControl1.Controls.Add(this.btnEditVAT);
            this.layoutControl1.Controls.Add(this.btnImportExcel);
            this.layoutControl1.Controls.Add(this.btnBreakInvoice);
            this.layoutControl1.Controls.Add(this.btnUpdateManual);
            this.layoutControl1.Controls.Add(this.textInvPeriod);
            this.layoutControl1.Controls.Add(this.btnSendEmail);
            this.layoutControl1.Controls.Add(this.textCurrencyExchangeRate);
            this.layoutControl1.Controls.Add(this.txtPayDays);
            this.layoutControl1.Controls.Add(this.txtPONo);
            this.layoutControl1.Controls.Add(this.txtBuyer);
            this.layoutControl1.Controls.Add(this.btn_accept);
            this.layoutControl1.Controls.Add(this.btn_Update);
            this.layoutControl1.Controls.Add(this.btn_NewBillingInvoices);
            this.layoutControl1.Controls.Add(this.dtngBillingInvoices);
            this.layoutControl1.Controls.Add(this.txtCreatedBy);
            this.layoutControl1.Controls.Add(this.txtBillingInvoicesRecordNumber);
            this.layoutControl1.Controls.Add(this.memoInvRemark);
            this.layoutControl1.Controls.Add(this.btn_Delete);
            this.layoutControl1.Controls.Add(this.btn_UpdateCustomer);
            this.layoutControl1.Controls.Add(this.simpleButton1);
            this.layoutControl1.Controls.Add(this.lkeStores);
            this.layoutControl1.Controls.Add(this.lkeCurrency);
            this.layoutControl1.Controls.Add(this.txtEInvNum);
            this.layoutControl1.Controls.Add(this.dteInvoiceDate);
            this.layoutControl1.Controls.Add(this.txtCreatedTime);
            this.layoutControl1.Controls.Add(this.textBillingID);
            this.layoutControl1.Controls.Add(this.txtCustomerName);
            this.layoutControl1.Controls.Add(this.textInvoiceAmount);
            this.layoutControl1.Controls.Add(this.textCustomerTaxCode);
            this.layoutControl1.Controls.Add(this.textVATAmount);
            this.layoutControl1.Controls.Add(this.textGrossAmount);
            this.layoutControl1.Controls.Add(this.textGrossAmountWording);
            this.layoutControl1.Controls.Add(this.lkeCustomers);
            this.layoutControl1.Controls.Add(this.lkePaymentMethod);
            this.layoutControl1.Controls.Add(this.txtConfirmedBy);
            this.layoutControl1.Controls.Add(this.txtConfirmedTime);
            this.layoutControl1.Controls.Add(this.grcBillingInvoiceDetails);
            this.layoutControl1.Controls.Add(this.textCustomerAddress);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 51);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1118, 513, 650, 400);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1552, 702);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            this.layoutControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.layoutControl1_KeyDown);
            // 
            // btnVAT8
            // 
            this.btnVAT8.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning;
            this.btnVAT8.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnVAT8.Appearance.Options.UseBackColor = true;
            this.btnVAT8.Appearance.Options.UseFont = true;
            this.btnVAT8.Location = new System.Drawing.Point(803, 654);
            this.btnVAT8.MaximumSize = new System.Drawing.Size(100, 38);
            this.btnVAT8.MinimumSize = new System.Drawing.Size(100, 38);
            this.btnVAT8.Name = "btnVAT8";
            this.btnVAT8.Size = new System.Drawing.Size(100, 38);
            this.btnVAT8.StyleController = this.layoutControl1;
            this.btnVAT8.TabIndex = 60;
            this.btnVAT8.Text = "VAT 8%";
            this.btnVAT8.Click += new System.EventHandler(this.btnVAT8_Click);
            // 
            // btnVat7
            // 
            this.btnVat7.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning;
            this.btnVat7.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnVat7.Appearance.Options.UseBackColor = true;
            this.btnVat7.Appearance.Options.UseFont = true;
            this.btnVat7.Location = new System.Drawing.Point(699, 654);
            this.btnVat7.MaximumSize = new System.Drawing.Size(100, 38);
            this.btnVat7.MinimumSize = new System.Drawing.Size(100, 38);
            this.btnVat7.Name = "btnVat7";
            this.btnVat7.Size = new System.Drawing.Size(100, 38);
            this.btnVat7.StyleController = this.layoutControl1;
            this.btnVat7.TabIndex = 59;
            this.btnVat7.Text = "VAT 7%";
            this.btnVat7.Click += new System.EventHandler(this.btnVat7_Click);
            // 
            // btnEditVAT
            // 
            this.btnEditVAT.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning;
            this.btnEditVAT.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnEditVAT.Appearance.Options.UseBackColor = true;
            this.btnEditVAT.Appearance.Options.UseFont = true;
            this.btnEditVAT.Location = new System.Drawing.Point(491, 654);
            this.btnEditVAT.MaximumSize = new System.Drawing.Size(100, 38);
            this.btnEditVAT.MinimumSize = new System.Drawing.Size(100, 38);
            this.btnEditVAT.Name = "btnEditVAT";
            this.btnEditVAT.Size = new System.Drawing.Size(100, 38);
            this.btnEditVAT.StyleController = this.layoutControl1;
            this.btnEditVAT.TabIndex = 56;
            this.btnEditVAT.Text = "Edit VAT";
            this.btnEditVAT.Click += new System.EventHandler(this.btnEditVAT_Click);
            // 
            // btnImportExcel
            // 
            this.btnImportExcel.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Question;
            this.btnImportExcel.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnImportExcel.Appearance.Options.UseBackColor = true;
            this.btnImportExcel.Appearance.Options.UseFont = true;
            this.btnImportExcel.Location = new System.Drawing.Point(595, 654);
            this.btnImportExcel.MaximumSize = new System.Drawing.Size(100, 38);
            this.btnImportExcel.MinimumSize = new System.Drawing.Size(100, 38);
            this.btnImportExcel.Name = "btnImportExcel";
            this.btnImportExcel.Size = new System.Drawing.Size(100, 38);
            this.btnImportExcel.StyleController = this.layoutControl1;
            this.btnImportExcel.TabIndex = 53;
            this.btnImportExcel.Text = "Import Excel";
            this.btnImportExcel.Click += new System.EventHandler(this.btnImportExcel_Click);
            // 
            // btnBreakInvoice
            // 
            this.btnBreakInvoice.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning;
            this.btnBreakInvoice.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnBreakInvoice.Appearance.Options.UseBackColor = true;
            this.btnBreakInvoice.Appearance.Options.UseFont = true;
            this.btnBreakInvoice.Location = new System.Drawing.Point(907, 654);
            this.btnBreakInvoice.MaximumSize = new System.Drawing.Size(100, 38);
            this.btnBreakInvoice.MinimumSize = new System.Drawing.Size(100, 38);
            this.btnBreakInvoice.Name = "btnBreakInvoice";
            this.btnBreakInvoice.Size = new System.Drawing.Size(100, 38);
            this.btnBreakInvoice.StyleController = this.layoutControl1;
            this.btnBreakInvoice.TabIndex = 52;
            this.btnBreakInvoice.Text = "Break";
            this.btnBreakInvoice.Click += new System.EventHandler(this.btnBreakInvoice_Click);
            // 
            // btnUpdateManual
            // 
            this.btnUpdateManual.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning;
            this.btnUpdateManual.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnUpdateManual.Appearance.Options.UseBackColor = true;
            this.btnUpdateManual.Appearance.Options.UseFont = true;
            this.btnUpdateManual.Location = new System.Drawing.Point(1011, 654);
            this.btnUpdateManual.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnUpdateManual.MaximumSize = new System.Drawing.Size(100, 38);
            this.btnUpdateManual.MinimumSize = new System.Drawing.Size(100, 38);
            this.btnUpdateManual.Name = "btnUpdateManual";
            this.btnUpdateManual.Size = new System.Drawing.Size(100, 38);
            this.btnUpdateManual.StyleController = this.layoutControl1;
            this.btnUpdateManual.TabIndex = 51;
            this.btnUpdateManual.Text = "Update Footer";
            this.btnUpdateManual.Click += new System.EventHandler(this.btnUpdateManual_Click);
            // 
            // textInvPeriod
            // 
            this.textInvPeriod.Location = new System.Drawing.Point(536, 85);
            this.textInvPeriod.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textInvPeriod.MenuManager = this.rbcbase;
            this.textInvPeriod.MinimumSize = new System.Drawing.Size(0, 21);
            this.textInvPeriod.Name = "textInvPeriod";
            this.textInvPeriod.Size = new System.Drawing.Size(167, 26);
            this.textInvPeriod.StyleController = this.layoutControl1;
            this.textInvPeriod.TabIndex = 50;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "This value is not valid";
            this.dxValidationProvider1.SetValidationRule(this.textInvPeriod, conditionValidationRule1);
            this.textInvPeriod.EditValueChanged += new System.EventHandler(this.textInvPeriod_EditValueChanged);
            // 
            // btnSendEmail
            // 
            this.btnSendEmail.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnSendEmail.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendEmail.Appearance.Options.UseBackColor = true;
            this.btnSendEmail.Appearance.Options.UseFont = true;
            this.btnSendEmail.Location = new System.Drawing.Point(1219, 654);
            this.btnSendEmail.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSendEmail.MaximumSize = new System.Drawing.Size(100, 38);
            this.btnSendEmail.MinimumSize = new System.Drawing.Size(100, 38);
            this.btnSendEmail.Name = "btnSendEmail";
            this.btnSendEmail.Size = new System.Drawing.Size(100, 38);
            this.btnSendEmail.StyleController = this.layoutControl1;
            this.btnSendEmail.TabIndex = 49;
            this.btnSendEmail.Text = "Email Reports";
            this.btnSendEmail.Click += new System.EventHandler(this.btnSendEmail_Click);
            // 
            // textCurrencyExchangeRate
            // 
            this.textCurrencyExchangeRate.Location = new System.Drawing.Point(786, 85);
            this.textCurrencyExchangeRate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textCurrencyExchangeRate.MenuManager = this.rbcbase;
            this.textCurrencyExchangeRate.MinimumSize = new System.Drawing.Size(0, 21);
            this.textCurrencyExchangeRate.Name = "textCurrencyExchangeRate";
            this.textCurrencyExchangeRate.Properties.DisplayFormat.FormatString = "n0";
            this.textCurrencyExchangeRate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.textCurrencyExchangeRate.Properties.EditFormat.FormatString = "n0";
            this.textCurrencyExchangeRate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.textCurrencyExchangeRate.Properties.Mask.EditMask = "n0";
            this.textCurrencyExchangeRate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.textCurrencyExchangeRate.Size = new System.Drawing.Size(87, 26);
            this.textCurrencyExchangeRate.StyleController = this.layoutControl1;
            this.textCurrencyExchangeRate.TabIndex = 48;
            this.textCurrencyExchangeRate.EditValueChanged += new System.EventHandler(this.textCurrencyExchangeRate_EditValueChanged);
            // 
            // txtPayDays
            // 
            this.txtPayDays.Location = new System.Drawing.Point(1416, 85);
            this.txtPayDays.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtPayDays.MenuManager = this.rbcbase;
            this.txtPayDays.MinimumSize = new System.Drawing.Size(0, 21);
            this.txtPayDays.Name = "txtPayDays";
            this.txtPayDays.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPayDays.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPayDays.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPayDays.Size = new System.Drawing.Size(124, 26);
            this.txtPayDays.StyleController = this.layoutControl1;
            this.txtPayDays.TabIndex = 47;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.Greater;
            conditionValidationRule2.ErrorText = "This value is not valid";
            conditionValidationRule2.Value1 = "0";
            this.dxValidationProvider1.SetValidationRule(this.txtPayDays, conditionValidationRule2);
            this.txtPayDays.EditValueChanged += new System.EventHandler(this.txtPayDays_EditValueChanged);
            // 
            // txtPONo
            // 
            this.txtPONo.Location = new System.Drawing.Point(1198, 85);
            this.txtPONo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtPONo.MenuManager = this.rbcbase;
            this.txtPONo.MinimumSize = new System.Drawing.Size(0, 21);
            this.txtPONo.Name = "txtPONo";
            this.txtPONo.Size = new System.Drawing.Size(116, 26);
            this.txtPONo.StyleController = this.layoutControl1;
            this.txtPONo.TabIndex = 46;
            this.txtPONo.EditValueChanged += new System.EventHandler(this.txtPONo_EditValueChanged);
            // 
            // txtBuyer
            // 
            this.txtBuyer.Location = new System.Drawing.Point(1198, 49);
            this.txtBuyer.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtBuyer.MenuManager = this.rbcbase;
            this.txtBuyer.MinimumSize = new System.Drawing.Size(0, 21);
            this.txtBuyer.Name = "txtBuyer";
            this.txtBuyer.Size = new System.Drawing.Size(116, 26);
            this.txtBuyer.StyleController = this.layoutControl1;
            this.txtBuyer.TabIndex = 45;
            this.txtBuyer.EditValueChanged += new System.EventHandler(this.txtBuyer_EditValueChanged);
            // 
            // btn_accept
            // 
            this.btn_accept.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.btn_accept.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btn_accept.Appearance.Options.UseBackColor = true;
            this.btn_accept.Appearance.Options.UseFont = true;
            this.btn_accept.Location = new System.Drawing.Point(114, 654);
            this.btn_accept.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_accept.MaximumSize = new System.Drawing.Size(100, 38);
            this.btn_accept.MinimumSize = new System.Drawing.Size(100, 38);
            this.btn_accept.Name = "btn_accept";
            this.btn_accept.Size = new System.Drawing.Size(100, 38);
            this.btn_accept.StyleController = this.layoutControl1;
            this.btn_accept.TabIndex = 44;
            this.btn_accept.Text = "Confirm/Lock";
            this.btn_accept.Click += new System.EventHandler(this.btn_accept_Click);
            // 
            // btn_Update
            // 
            this.btn_Update.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning;
            this.btn_Update.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btn_Update.Appearance.Options.UseBackColor = true;
            this.btn_Update.Appearance.Options.UseFont = true;
            this.btn_Update.Location = new System.Drawing.Point(1115, 654);
            this.btn_Update.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_Update.MaximumSize = new System.Drawing.Size(100, 38);
            this.btn_Update.MinimumSize = new System.Drawing.Size(100, 38);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(100, 38);
            this.btn_Update.StyleController = this.layoutControl1;
            this.btn_Update.TabIndex = 43;
            this.btn_Update.Text = "Update";
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // btn_NewBillingInvoices
            // 
            this.btn_NewBillingInvoices.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btn_NewBillingInvoices.Appearance.ForeColor = System.Drawing.Color.DarkRed;
            this.btn_NewBillingInvoices.Appearance.Options.UseFont = true;
            this.btn_NewBillingInvoices.Appearance.Options.UseForeColor = true;
            this.btn_NewBillingInvoices.Location = new System.Drawing.Point(220, 101);
            this.btn_NewBillingInvoices.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_NewBillingInvoices.MaximumSize = new System.Drawing.Size(0, 36);
            this.btn_NewBillingInvoices.MinimumSize = new System.Drawing.Size(0, 36);
            this.btn_NewBillingInvoices.Name = "btn_NewBillingInvoices";
            this.btn_NewBillingInvoices.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_NewBillingInvoices.Size = new System.Drawing.Size(46, 36);
            this.btn_NewBillingInvoices.StyleController = this.layoutControl1;
            this.btn_NewBillingInvoices.TabIndex = 41;
            this.btn_NewBillingInvoices.Text = "NEW";
            this.btn_NewBillingInvoices.Click += new System.EventHandler(this.btn_NewBillingInvoices_Click);
            // 
            // dtngBillingInvoices
            // 
            this.dtngBillingInvoices.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.dtngBillingInvoices.Buttons.Append.Visible = false;
            this.dtngBillingInvoices.Buttons.CancelEdit.Visible = false;
            this.dtngBillingInvoices.Buttons.EndEdit.Visible = false;
            this.dtngBillingInvoices.Buttons.First.ImageIndex = 1;
            this.dtngBillingInvoices.Buttons.ImageList = this.imgDataNavigator;
            this.dtngBillingInvoices.Buttons.Last.ImageIndex = 3;
            this.dtngBillingInvoices.Buttons.Next.ImageIndex = 2;
            this.dtngBillingInvoices.Buttons.NextPage.Visible = false;
            this.dtngBillingInvoices.Buttons.Prev.ImageIndex = 0;
            this.dtngBillingInvoices.Buttons.PrevPage.Visible = false;
            this.dtngBillingInvoices.Buttons.Remove.Visible = false;
            this.dtngBillingInvoices.Location = new System.Drawing.Point(12, 101);
            this.dtngBillingInvoices.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dtngBillingInvoices.MaximumSize = new System.Drawing.Size(240, 36);
            this.dtngBillingInvoices.MinimumSize = new System.Drawing.Size(200, 36);
            this.dtngBillingInvoices.Name = "dtngBillingInvoices";
            this.dtngBillingInvoices.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dtngBillingInvoices.Size = new System.Drawing.Size(200, 36);
            this.dtngBillingInvoices.StyleController = this.layoutControl1;
            this.dtngBillingInvoices.TabIndex = 40;
            this.dtngBillingInvoices.Text = "dataNavigator1";
            this.dtngBillingInvoices.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.Center;
            this.dtngBillingInvoices.TextStringFormat = "{0} of {1}";
            this.dtngBillingInvoices.PositionChanged += new System.EventHandler(this.dtngBillingInvoices_PositionChanged);
            this.dtngBillingInvoices.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtngBillingInvoices_KeyDown);
            // 
            // imgDataNavigator
            // 
            this.imgDataNavigator.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgDataNavigator.ImageStream")));
            this.imgDataNavigator.InsertGalleryImage("prev_16x16.png", "images/arrows/prev_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/arrows/prev_16x16.png"), 0);
            this.imgDataNavigator.Images.SetKeyName(0, "prev_16x16.png");
            this.imgDataNavigator.InsertGalleryImage("first_16x16.png", "images/arrows/first_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/arrows/first_16x16.png"), 1);
            this.imgDataNavigator.Images.SetKeyName(1, "first_16x16.png");
            this.imgDataNavigator.InsertGalleryImage("next_16x16.png", "images/arrows/next_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/arrows/next_16x16.png"), 2);
            this.imgDataNavigator.Images.SetKeyName(2, "next_16x16.png");
            this.imgDataNavigator.InsertGalleryImage("last_16x16.png", "images/arrows/last_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/arrows/last_16x16.png"), 3);
            this.imgDataNavigator.Images.SetKeyName(3, "last_16x16.png");
            // 
            // txtCreatedBy
            // 
            this.txtCreatedBy.Location = new System.Drawing.Point(77, 65);
            this.txtCreatedBy.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtCreatedBy.Name = "txtCreatedBy";
            this.txtCreatedBy.Properties.AutoHeight = false;
            this.txtCreatedBy.Properties.ReadOnly = true;
            this.txtCreatedBy.Size = new System.Drawing.Size(62, 26);
            this.txtCreatedBy.StyleController = this.layoutControl1;
            this.txtCreatedBy.TabIndex = 38;
            this.txtCreatedBy.TabStop = false;
            // 
            // txtBillingInvoicesRecordNumber
            // 
            this.txtBillingInvoicesRecordNumber.EditValue = "";
            this.txtBillingInvoicesRecordNumber.Enabled = false;
            this.txtBillingInvoicesRecordNumber.Location = new System.Drawing.Point(12, 13);
            this.txtBillingInvoicesRecordNumber.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBillingInvoicesRecordNumber.MaximumSize = new System.Drawing.Size(334, 32);
            this.txtBillingInvoicesRecordNumber.MenuManager = this.rbcbase;
            this.txtBillingInvoicesRecordNumber.MinimumSize = new System.Drawing.Size(0, 32);
            this.txtBillingInvoicesRecordNumber.Name = "txtBillingInvoicesRecordNumber";
            this.txtBillingInvoicesRecordNumber.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.txtBillingInvoicesRecordNumber.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.txtBillingInvoicesRecordNumber.Properties.Appearance.Options.UseFont = true;
            this.txtBillingInvoicesRecordNumber.Properties.Appearance.Options.UseForeColor = true;
            this.txtBillingInvoicesRecordNumber.Properties.Appearance.Options.UseTextOptions = true;
            this.txtBillingInvoicesRecordNumber.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtBillingInvoicesRecordNumber.Properties.ReadOnly = true;
            this.txtBillingInvoicesRecordNumber.Size = new System.Drawing.Size(254, 32);
            this.txtBillingInvoicesRecordNumber.StyleController = this.layoutControl1;
            this.txtBillingInvoicesRecordNumber.TabIndex = 37;
            // 
            // memoInvRemark
            // 
            this.memoInvRemark.Location = new System.Drawing.Point(373, 121);
            this.memoInvRemark.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.memoInvRemark.MenuManager = this.rbcbase;
            this.memoInvRemark.MinimumSize = new System.Drawing.Size(0, 25);
            this.memoInvRemark.Name = "memoInvRemark";
            this.memoInvRemark.Size = new System.Drawing.Size(691, 52);
            this.memoInvRemark.StyleController = this.layoutControl1;
            this.memoInvRemark.TabIndex = 36;
            this.memoInvRemark.EditValueChanged += new System.EventHandler(this.memoInvRemark_EditValueChanged);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger;
            this.btn_Delete.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btn_Delete.Appearance.Options.UseBackColor = true;
            this.btn_Delete.Appearance.Options.UseFont = true;
            this.btn_Delete.Location = new System.Drawing.Point(10, 654);
            this.btn_Delete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_Delete.MaximumSize = new System.Drawing.Size(100, 38);
            this.btn_Delete.MinimumSize = new System.Drawing.Size(100, 38);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(100, 38);
            this.btn_Delete.StyleController = this.layoutControl1;
            this.btn_Delete.TabIndex = 33;
            this.btn_Delete.Text = "Delete";
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_UpdateCustomer
            // 
            this.btn_UpdateCustomer.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btn_UpdateCustomer.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btn_UpdateCustomer.Appearance.Options.UseBackColor = true;
            this.btn_UpdateCustomer.Appearance.Options.UseFont = true;
            this.btn_UpdateCustomer.Location = new System.Drawing.Point(1323, 654);
            this.btn_UpdateCustomer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_UpdateCustomer.MaximumSize = new System.Drawing.Size(115, 38);
            this.btn_UpdateCustomer.MinimumSize = new System.Drawing.Size(115, 38);
            this.btn_UpdateCustomer.Name = "btn_UpdateCustomer";
            this.btn_UpdateCustomer.Size = new System.Drawing.Size(115, 38);
            this.btn_UpdateCustomer.StyleController = this.layoutControl1;
            this.btn_UpdateCustomer.TabIndex = 30;
            this.btn_UpdateCustomer.Text = "Update Customer";
            this.btn_UpdateCustomer.Click += new System.EventHandler(this.btn_UpdateCustomer_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.simpleButton1.Appearance.Options.UseBackColor = true;
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Location = new System.Drawing.Point(1442, 654);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.simpleButton1.MaximumSize = new System.Drawing.Size(100, 38);
            this.simpleButton1.MinimumSize = new System.Drawing.Size(100, 38);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(100, 38);
            this.simpleButton1.StyleController = this.layoutControl1;
            this.simpleButton1.TabIndex = 29;
            this.simpleButton1.Text = "Close";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // lkeStores
            // 
            this.lkeStores.Location = new System.Drawing.Point(941, 13);
            this.lkeStores.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lkeStores.MenuManager = this.rbcbase;
            this.lkeStores.MinimumSize = new System.Drawing.Size(0, 21);
            this.lkeStores.Name = "lkeStores";
            this.lkeStores.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeStores.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StoreID", "StoreID", 16, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StoreNumber", "StoreNumber", 16, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StoreDescription", "StoreDescription", 16, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StoreVietnam", "StoreVietnam", 16, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lkeStores.Properties.NullText = "";
            this.lkeStores.Properties.ReadOnly = true;
            this.lkeStores.Size = new System.Drawing.Size(123, 26);
            this.lkeStores.StyleController = this.layoutControl1;
            this.lkeStores.TabIndex = 8;
            conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule3.ErrorText = "This value is not valid";
            this.dxValidationProvider1.SetValidationRule(this.lkeStores, conditionValidationRule3);
            this.lkeStores.EditValueChanged += new System.EventHandler(this.lkeStores_EditValueChanged);
            // 
            // lkeCurrency
            // 
            this.lkeCurrency.Location = new System.Drawing.Point(941, 85);
            this.lkeCurrency.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lkeCurrency.MenuManager = this.rbcbase;
            this.lkeCurrency.MinimumSize = new System.Drawing.Size(0, 21);
            this.lkeCurrency.Name = "lkeCurrency";
            this.lkeCurrency.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeCurrency.Properties.NullText = "";
            this.lkeCurrency.Size = new System.Drawing.Size(123, 26);
            this.lkeCurrency.StyleController = this.layoutControl1;
            this.lkeCurrency.TabIndex = 7;
            conditionValidationRule4.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule4.ErrorText = "This value is not valid";
            this.dxValidationProvider1.SetValidationRule(this.lkeCurrency, conditionValidationRule4);
            this.lkeCurrency.EditValueChanged += new System.EventHandler(this.lkeCurrency_EditValueChanged);
            // 
            // txtEInvNum
            // 
            this.txtEInvNum.Location = new System.Drawing.Point(373, 85);
            this.txtEInvNum.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtEInvNum.MenuManager = this.rbcbase;
            this.txtEInvNum.MinimumSize = new System.Drawing.Size(0, 21);
            this.txtEInvNum.Name = "txtEInvNum";
            this.txtEInvNum.Properties.Appearance.Options.UseTextOptions = true;
            this.txtEInvNum.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtEInvNum.Properties.ReadOnly = true;
            this.txtEInvNum.Size = new System.Drawing.Size(80, 26);
            this.txtEInvNum.StyleController = this.layoutControl1;
            this.txtEInvNum.TabIndex = 6;
            this.txtEInvNum.EditValueChanged += new System.EventHandler(this.txtEInvNum_EditValueChanged);
            // 
            // dteInvoiceDate
            // 
            this.dteInvoiceDate.EditValue = null;
            this.dteInvoiceDate.Location = new System.Drawing.Point(1198, 13);
            this.dteInvoiceDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dteInvoiceDate.MenuManager = this.rbcbase;
            this.dteInvoiceDate.MinimumSize = new System.Drawing.Size(0, 21);
            this.dteInvoiceDate.Name = "dteInvoiceDate";
            this.dteInvoiceDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteInvoiceDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteInvoiceDate.Size = new System.Drawing.Size(116, 26);
            this.dteInvoiceDate.StyleController = this.layoutControl1;
            this.dteInvoiceDate.TabIndex = 5;
            conditionValidationRule5.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule5.ErrorText = "This value is not valid";
            this.dxValidationProvider1.SetValidationRule(this.dteInvoiceDate, conditionValidationRule5);
            this.dteInvoiceDate.EditValueChanged += new System.EventHandler(this.dteInvoiceDate_EditValueChanged);
            // 
            // txtCreatedTime
            // 
            this.txtCreatedTime.Location = new System.Drawing.Point(147, 65);
            this.txtCreatedTime.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtCreatedTime.Name = "txtCreatedTime";
            this.txtCreatedTime.Properties.AutoHeight = false;
            this.txtCreatedTime.Properties.ReadOnly = true;
            this.txtCreatedTime.Size = new System.Drawing.Size(119, 26);
            this.txtCreatedTime.StyleController = this.layoutControl1;
            this.txtCreatedTime.TabIndex = 38;
            this.txtCreatedTime.TabStop = false;
            // 
            // textBillingID
            // 
            this.textBillingID.Enabled = false;
            this.textBillingID.Location = new System.Drawing.Point(1414, 13);
            this.textBillingID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBillingID.MinimumSize = new System.Drawing.Size(0, 21);
            this.textBillingID.Name = "textBillingID";
            this.textBillingID.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.textBillingID.Properties.Appearance.Options.UseFont = true;
            this.textBillingID.Properties.Appearance.Options.UseTextOptions = true;
            this.textBillingID.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.textBillingID.Properties.ReadOnly = true;
            this.textBillingID.Size = new System.Drawing.Size(126, 26);
            this.textBillingID.StyleController = this.layoutControl1;
            this.textBillingID.TabIndex = 6;
            this.textBillingID.EditValueChanged += new System.EventHandler(this.textBillingID_EditValueChanged);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(462, 13);
            this.txtCustomerName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCustomerName.MinimumSize = new System.Drawing.Size(0, 21);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Properties.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(411, 26);
            this.txtCustomerName.StyleController = this.layoutControl1;
            this.txtCustomerName.TabIndex = 6;
            conditionValidationRule6.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule6.ErrorText = "This value is not valid";
            this.dxValidationProvider1.SetValidationRule(this.txtCustomerName, conditionValidationRule6);
            this.txtCustomerName.EditValueChanged += new System.EventHandler(this.txtCustomerName_EditValueChanged);
            // 
            // textInvoiceAmount
            // 
            this.textInvoiceAmount.Location = new System.Drawing.Point(52, 621);
            this.textInvoiceAmount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textInvoiceAmount.MaximumSize = new System.Drawing.Size(151, 19);
            this.textInvoiceAmount.MinimumSize = new System.Drawing.Size(151, 19);
            this.textInvoiceAmount.Name = "textInvoiceAmount";
            this.textInvoiceAmount.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.textInvoiceAmount.Properties.Appearance.Options.UseFont = true;
            this.textInvoiceAmount.Properties.Appearance.Options.UseTextOptions = true;
            this.textInvoiceAmount.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.textInvoiceAmount.Properties.DisplayFormat.FormatString = "n0";
            this.textInvoiceAmount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.textInvoiceAmount.Properties.EditFormat.FormatString = "n0";
            this.textInvoiceAmount.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.textInvoiceAmount.Properties.Mask.EditMask = "n";
            this.textInvoiceAmount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.textInvoiceAmount.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.textInvoiceAmount.Properties.ReadOnly = true;
            this.textInvoiceAmount.Size = new System.Drawing.Size(151, 19);
            this.textInvoiceAmount.StyleController = this.layoutControl1;
            this.textInvoiceAmount.TabIndex = 6;
            conditionValidationRule7.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule7.ErrorText = "This value is not valid";
            this.dxValidationProvider1.SetValidationRule(this.textInvoiceAmount, conditionValidationRule7);
            // 
            // textCustomerTaxCode
            // 
            this.textCustomerTaxCode.Location = new System.Drawing.Point(1414, 49);
            this.textCustomerTaxCode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textCustomerTaxCode.MinimumSize = new System.Drawing.Size(0, 21);
            this.textCustomerTaxCode.Name = "textCustomerTaxCode";
            this.textCustomerTaxCode.Properties.Appearance.Options.UseTextOptions = true;
            this.textCustomerTaxCode.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.textCustomerTaxCode.Properties.Mask.PlaceHolder = ' ';
            this.textCustomerTaxCode.Properties.Mask.ShowPlaceHolders = false;
            this.textCustomerTaxCode.Properties.MaxLength = 14;
            this.textCustomerTaxCode.Properties.ReadOnly = true;
            this.textCustomerTaxCode.Size = new System.Drawing.Size(126, 26);
            this.textCustomerTaxCode.StyleController = this.layoutControl1;
            this.textCustomerTaxCode.TabIndex = 6;
            this.textCustomerTaxCode.EditValueChanged += new System.EventHandler(this.textCustomerTaxCode_EditValueChanged);
            // 
            // textVATAmount
            // 
            this.textVATAmount.Location = new System.Drawing.Point(262, 621);
            this.textVATAmount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textVATAmount.MaximumSize = new System.Drawing.Size(141, 19);
            this.textVATAmount.MinimumSize = new System.Drawing.Size(141, 19);
            this.textVATAmount.Name = "textVATAmount";
            this.textVATAmount.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.textVATAmount.Properties.Appearance.Options.UseFont = true;
            this.textVATAmount.Properties.Appearance.Options.UseTextOptions = true;
            this.textVATAmount.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.textVATAmount.Properties.DisplayFormat.FormatString = "n0";
            this.textVATAmount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.textVATAmount.Properties.EditFormat.FormatString = "n0";
            this.textVATAmount.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.textVATAmount.Properties.Mask.EditMask = "n";
            this.textVATAmount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.textVATAmount.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.textVATAmount.Properties.ReadOnly = true;
            this.textVATAmount.Size = new System.Drawing.Size(141, 19);
            this.textVATAmount.StyleController = this.layoutControl1;
            this.textVATAmount.TabIndex = 6;
            conditionValidationRule8.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule8.ErrorText = "This value is not valid";
            this.dxValidationProvider1.SetValidationRule(this.textVATAmount, conditionValidationRule8);
            // 
            // textGrossAmount
            // 
            this.textGrossAmount.Location = new System.Drawing.Point(495, 621);
            this.textGrossAmount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textGrossAmount.MaximumSize = new System.Drawing.Size(141, 19);
            this.textGrossAmount.MinimumSize = new System.Drawing.Size(141, 19);
            this.textGrossAmount.Name = "textGrossAmount";
            this.textGrossAmount.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.textGrossAmount.Properties.Appearance.Options.UseFont = true;
            this.textGrossAmount.Properties.Appearance.Options.UseTextOptions = true;
            this.textGrossAmount.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.textGrossAmount.Properties.DisplayFormat.FormatString = "n0";
            this.textGrossAmount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.textGrossAmount.Properties.EditFormat.FormatString = "n0";
            this.textGrossAmount.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.textGrossAmount.Properties.Mask.EditMask = "n";
            this.textGrossAmount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.textGrossAmount.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.textGrossAmount.Properties.ReadOnly = true;
            this.textGrossAmount.Size = new System.Drawing.Size(141, 19);
            this.textGrossAmount.StyleController = this.layoutControl1;
            this.textGrossAmount.TabIndex = 6;
            conditionValidationRule9.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule9.ErrorText = "This value is not valid";
            this.dxValidationProvider1.SetValidationRule(this.textGrossAmount, conditionValidationRule9);
            // 
            // textGrossAmountWording
            // 
            this.textGrossAmountWording.Location = new System.Drawing.Point(758, 621);
            this.textGrossAmountWording.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textGrossAmountWording.Name = "textGrossAmountWording";
            this.textGrossAmountWording.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.textGrossAmountWording.Properties.ReadOnly = true;
            this.textGrossAmountWording.Size = new System.Drawing.Size(782, 26);
            this.textGrossAmountWording.StyleController = this.layoutControl1;
            this.textGrossAmountWording.TabIndex = 6;
            conditionValidationRule10.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule10.ErrorText = "This value is not valid";
            this.dxValidationProvider1.SetValidationRule(this.textGrossAmountWording, conditionValidationRule10);
            // 
            // lkeCustomers
            // 
            this.lkeCustomers.EnterMoveNextControl = true;
            this.lkeCustomers.Location = new System.Drawing.Point(373, 13);
            this.lkeCustomers.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lkeCustomers.MinimumSize = new System.Drawing.Size(0, 21);
            this.lkeCustomers.Name = "lkeCustomers";
            this.lkeCustomers.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkeCustomers.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeCustomers.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerID", "CustomerID", 16, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerNumber", "CustomerNumber", 16, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerName", "CustomerName", 16, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lkeCustomers.Properties.DisplayMember = "CustomerNumber";
            this.lkeCustomers.Properties.DropDownRows = 20;
            this.lkeCustomers.Properties.ImmediatePopup = true;
            this.lkeCustomers.Properties.NullText = "";
            this.lkeCustomers.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.lkeCustomers.Properties.PopupFormMinSize = new System.Drawing.Size(250, 0);
            this.lkeCustomers.Properties.ShowFooter = false;
            this.lkeCustomers.Properties.ShowHeader = false;
            this.lkeCustomers.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lkeCustomers.Properties.ValueMember = "CustomerID";
            this.lkeCustomers.Size = new System.Drawing.Size(81, 26);
            this.lkeCustomers.StyleController = this.layoutControl1;
            this.lkeCustomers.TabIndex = 1;
            conditionValidationRule11.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule11.ErrorText = "This value is not valid";
            this.dxValidationProvider1.SetValidationRule(this.lkeCustomers, conditionValidationRule11);
            this.lkeCustomers.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(this.lkeCustomers_CloseUp);
            this.lkeCustomers.EditValueChanged += new System.EventHandler(this.lkeCustomers_EditValueChanged);
            // 
            // lkePaymentMethod
            // 
            this.lkePaymentMethod.Location = new System.Drawing.Point(1416, 121);
            this.lkePaymentMethod.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lkePaymentMethod.MinimumSize = new System.Drawing.Size(0, 21);
            this.lkePaymentMethod.Name = "lkePaymentMethod";
            this.lkePaymentMethod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkePaymentMethod.Properties.NullText = "";
            this.lkePaymentMethod.Size = new System.Drawing.Size(124, 26);
            this.lkePaymentMethod.StyleController = this.layoutControl1;
            this.lkePaymentMethod.TabIndex = 7;
            conditionValidationRule12.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule12.ErrorText = "This value is not valid";
            this.dxValidationProvider1.SetValidationRule(this.lkePaymentMethod, conditionValidationRule12);
            this.lkePaymentMethod.EditValueChanged += new System.EventHandler(this.lkePaymentMethod_EditValueChanged);
            // 
            // txtConfirmedBy
            // 
            this.txtConfirmedBy.Location = new System.Drawing.Point(77, 147);
            this.txtConfirmedBy.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtConfirmedBy.Name = "txtConfirmedBy";
            this.txtConfirmedBy.Properties.AutoHeight = false;
            this.txtConfirmedBy.Properties.ReadOnly = true;
            this.txtConfirmedBy.Size = new System.Drawing.Size(62, 26);
            this.txtConfirmedBy.StyleController = this.layoutControl1;
            this.txtConfirmedBy.TabIndex = 38;
            this.txtConfirmedBy.TabStop = false;
            // 
            // txtConfirmedTime
            // 
            this.txtConfirmedTime.Location = new System.Drawing.Point(147, 147);
            this.txtConfirmedTime.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtConfirmedTime.Name = "txtConfirmedTime";
            this.txtConfirmedTime.Properties.AutoHeight = false;
            this.txtConfirmedTime.Properties.ReadOnly = true;
            this.txtConfirmedTime.Size = new System.Drawing.Size(119, 26);
            this.txtConfirmedTime.StyleController = this.layoutControl1;
            this.txtConfirmedTime.TabIndex = 38;
            this.txtConfirmedTime.TabStop = false;
            // 
            // grcBillingInvoiceDetails
            // 
            this.grcBillingInvoiceDetails.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.grcBillingInvoiceDetails.Location = new System.Drawing.Point(10, 180);
            this.grcBillingInvoiceDetails.MainView = this.grvBillingInvoiceDetails;
            this.grcBillingInvoiceDetails.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grcBillingInvoiceDetails.MenuManager = this.rbcbase;
            this.grcBillingInvoiceDetails.Name = "grcBillingInvoiceDetails";
            this.grcBillingInvoiceDetails.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemSpinEdit1,
            this.rpi_btn_Delete,
            this.rpi_cbo_VATRate,
            this.rpi_btn_Break});
            this.grcBillingInvoiceDetails.Size = new System.Drawing.Size(1532, 434);
            this.grcBillingInvoiceDetails.TabIndex = 11;
            this.grcBillingInvoiceDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBillingInvoiceDetails});
            this.grcBillingInvoiceDetails.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grcBillingInvoiceDetails_KeyDown);
            // 
            // grvBillingInvoiceDetails
            // 
            this.grvBillingInvoiceDetails.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colServiceName,
            this.colQty,
            this.colVAT,
            this.colAmount,
            this.colRemark,
            this.colUOM,
            this.colCode,
            this.gridColumn4,
            this.gridColumnItemdesc,
            this.gridColumn1,
            this.colDel,
            this.colPrice,
            this.colVATPercent,
            this.colBreak});
            this.grvBillingInvoiceDetails.DetailHeight = 457;
            this.grvBillingInvoiceDetails.FixedLineWidth = 4;
            this.grvBillingInvoiceDetails.GridControl = this.grcBillingInvoiceDetails;
            this.grvBillingInvoiceDetails.Name = "grvBillingInvoiceDetails";
            this.grvBillingInvoiceDetails.OptionsNavigation.EnterMoveNextColumn = true;
            this.grvBillingInvoiceDetails.OptionsSelection.CheckBoxSelectorColumnWidth = 30;
            this.grvBillingInvoiceDetails.OptionsSelection.MultiSelect = true;
            this.grvBillingInvoiceDetails.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.grvBillingInvoiceDetails.OptionsView.ShowFooter = true;
            this.grvBillingInvoiceDetails.OptionsView.ShowGroupPanel = false;
            this.grvBillingInvoiceDetails.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvBillingInvoiceDetails.PaintStyleName = "Skin";
            this.grvBillingInvoiceDetails.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.grvPettyDetails_InitNewRow);
            this.grvBillingInvoiceDetails.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvBillingInvoiceDetails_CellValueChanged);
            this.grvBillingInvoiceDetails.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvBillingInvoiceDetails_KeyDown);
            this.grvBillingInvoiceDetails.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.grvBillingInvoiceDetails_ValidatingEditor);
            // 
            // colServiceName
            // 
            this.colServiceName.Caption = "Service Name";
            this.colServiceName.FieldName = "ServiceName";
            this.colServiceName.MinWidth = 26;
            this.colServiceName.Name = "colServiceName";
            this.colServiceName.Visible = true;
            this.colServiceName.VisibleIndex = 2;
            this.colServiceName.Width = 405;
            // 
            // colQty
            // 
            this.colQty.AppearanceHeader.Options.UseTextOptions = true;
            this.colQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colQty.Caption = "Qty";
            this.colQty.ColumnEdit = this.repositoryItemSpinEdit1;
            this.colQty.DisplayFormat.FormatString = "n3";
            this.colQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colQty.FieldName = "ServiceQuantity";
            this.colQty.MinWidth = 26;
            this.colQty.Name = "colQty";
            this.colQty.Visible = true;
            this.colQty.VisibleIndex = 4;
            this.colQty.Width = 107;
            // 
            // repositoryItemSpinEdit1
            // 
            this.repositoryItemSpinEdit1.AutoHeight = false;
            this.repositoryItemSpinEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSpinEdit1.Mask.EditMask = "n3";
            this.repositoryItemSpinEdit1.Mask.UseMaskAsDisplayFormat = true;
            this.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1";
            // 
            // colVAT
            // 
            this.colVAT.AppearanceHeader.Options.UseTextOptions = true;
            this.colVAT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colVAT.Caption = "VAT";
            this.colVAT.ColumnEdit = this.repositoryItemSpinEdit1;
            this.colVAT.DisplayFormat.FormatString = "n0";
            this.colVAT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colVAT.FieldName = "VATAmount";
            this.colVAT.MinWidth = 26;
            this.colVAT.Name = "colVAT";
            this.colVAT.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "VATAmount", "{0:n0}")});
            this.colVAT.Visible = true;
            this.colVAT.VisibleIndex = 8;
            this.colVAT.Width = 113;
            // 
            // colAmount
            // 
            this.colAmount.AppearanceHeader.Options.UseTextOptions = true;
            this.colAmount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colAmount.Caption = "Amount";
            this.colAmount.ColumnEdit = this.repositoryItemSpinEdit1;
            this.colAmount.DisplayFormat.FormatString = "n0";
            this.colAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAmount.FieldName = "Amount";
            this.colAmount.MinWidth = 26;
            this.colAmount.Name = "colAmount";
            this.colAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", "{0:n0}")});
            this.colAmount.Visible = true;
            this.colAmount.VisibleIndex = 6;
            this.colAmount.Width = 131;
            // 
            // colRemark
            // 
            this.colRemark.Caption = "Remark";
            this.colRemark.FieldName = "BillingInvoiceDetailRemark";
            this.colRemark.MinWidth = 26;
            this.colRemark.Name = "colRemark";
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 9;
            this.colRemark.Width = 316;
            // 
            // colUOM
            // 
            this.colUOM.Caption = "UOM";
            this.colUOM.FieldName = "UOM";
            this.colUOM.MinWidth = 26;
            this.colUOM.Name = "colUOM";
            this.colUOM.Visible = true;
            this.colUOM.VisibleIndex = 3;
            this.colUOM.Width = 98;
            // 
            // colCode
            // 
            this.colCode.Caption = "Code";
            this.colCode.FieldName = "ServiceCode";
            this.colCode.MinWidth = 26;
            this.colCode.Name = "colCode";
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 1;
            this.colCode.Width = 121;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "DetailID";
            this.gridColumn4.FieldName = "BillingInvoiceDetailID";
            this.gridColumn4.MinWidth = 26;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Width = 94;
            // 
            // gridColumnItemdesc
            // 
            this.gridColumnItemdesc.Caption = "ServiceID";
            this.gridColumnItemdesc.FieldName = "ServiceID";
            this.gridColumnItemdesc.MinWidth = 26;
            this.gridColumnItemdesc.Name = "gridColumnItemdesc";
            this.gridColumnItemdesc.OptionsColumn.AllowEdit = false;
            this.gridColumnItemdesc.Width = 442;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "OrderNumber";
            this.gridColumn1.FieldName = "OrderNUmber";
            this.gridColumn1.MinWidth = 26;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Width = 94;
            // 
            // colDel
            // 
            this.colDel.AppearanceHeader.Options.UseTextOptions = true;
            this.colDel.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDel.Caption = "DEL";
            this.colDel.ColumnEdit = this.rpi_btn_Delete;
            this.colDel.MaxWidth = 50;
            this.colDel.MinWidth = 50;
            this.colDel.Name = "colDel";
            this.colDel.Visible = true;
            this.colDel.VisibleIndex = 11;
            this.colDel.Width = 50;
            // 
            // rpi_btn_Delete
            // 
            this.rpi_btn_Delete.AutoHeight = false;
            this.rpi_btn_Delete.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)});
            this.rpi_btn_Delete.Name = "rpi_btn_Delete";
            this.rpi_btn_Delete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.rpi_btn_Delete.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.rpi_btn_Delete_ButtonClick);
            // 
            // colPrice
            // 
            this.colPrice.AppearanceHeader.Options.UseTextOptions = true;
            this.colPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colPrice.Caption = "Price";
            this.colPrice.DisplayFormat.FormatString = "n3";
            this.colPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPrice.FieldName = "UnitPrice";
            this.colPrice.GroupFormat.FormatString = "n3";
            this.colPrice.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPrice.MinWidth = 24;
            this.colPrice.Name = "colPrice";
            this.colPrice.Visible = true;
            this.colPrice.VisibleIndex = 5;
            this.colPrice.Width = 107;
            // 
            // colVATPercent
            // 
            this.colVATPercent.AppearanceHeader.Options.UseTextOptions = true;
            this.colVATPercent.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colVATPercent.Caption = "VAT%";
            this.colVATPercent.DisplayFormat.FormatString = "n3";
            this.colVATPercent.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colVATPercent.FieldName = "VATPercentage";
            this.colVATPercent.MinWidth = 24;
            this.colVATPercent.Name = "colVATPercent";
            this.colVATPercent.Visible = true;
            this.colVATPercent.VisibleIndex = 7;
            this.colVATPercent.Width = 59;
            // 
            // colBreak
            // 
            this.colBreak.AppearanceHeader.Options.UseTextOptions = true;
            this.colBreak.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBreak.Caption = "BR";
            this.colBreak.ColumnEdit = this.rpi_btn_Break;
            this.colBreak.MinWidth = 25;
            this.colBreak.Name = "colBreak";
            this.colBreak.Visible = true;
            this.colBreak.VisibleIndex = 10;
            this.colBreak.Width = 47;
            // 
            // rpi_btn_Break
            // 
            this.rpi_btn_Break.AutoHeight = false;
            this.rpi_btn_Break.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)});
            this.rpi_btn_Break.Name = "rpi_btn_Break";
            this.rpi_btn_Break.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.rpi_btn_Break.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.rpi_btn_Break_ButtonClick);
            // 
            // rpi_cbo_VATRate
            // 
            this.rpi_cbo_VATRate.AutoHeight = false;
            this.rpi_cbo_VATRate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpi_cbo_VATRate.Items.AddRange(new object[] {
            "0",
            "5",
            "10"});
            this.rpi_cbo_VATRate.Name = "rpi_cbo_VATRate";
            // 
            // textCustomerAddress
            // 
            this.textCustomerAddress.Location = new System.Drawing.Point(373, 49);
            this.textCustomerAddress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textCustomerAddress.MinimumSize = new System.Drawing.Size(0, 21);
            this.textCustomerAddress.Name = "textCustomerAddress";
            this.textCustomerAddress.Properties.ReadOnly = true;
            this.textCustomerAddress.Size = new System.Drawing.Size(691, 26);
            this.textCustomerAddress.StyleController = this.layoutControl1;
            this.textCustomerAddress.TabIndex = 6;
            conditionValidationRule13.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule13.ErrorText = "This value is not valid";
            this.dxValidationProvider1.SetValidationRule(this.textCustomerAddress, conditionValidationRule13);
            this.textCustomerAddress.EditValueChanged += new System.EventHandler(this.textCustomerAddress_EditValueChanged);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem8,
            this.emptySpaceItem1,
            this.layoutControlItem10,
            this.layoutControlIUpdateCustomer,
            this.layoutControlItem18,
            this.Created,
            this.layoutControlItem21,
            this.layoutControlItem22,
            this.layoutControlUpdate,
            this.layoutControlDelete,
            this.Created1,
            this.Created2,
            this.Created3,
            this.layoutControlItem23,
            this.layoutControlItem31,
            this.layoutControlItem32,
            this.layoutControlItem26,
            this.layoutControlItem1,
            this.layoutControlItem16,
            this.layoutControlItem2,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem24,
            this.layoutControlItem25,
            this.layoutControlItem15,
            this.layoutControlItem9,
            this.layoutControlItem12,
            this.layoutControlItem13,
            this.layoutControlItemEmailReport,
            this.layoutControlItem20,
            this.layoutControlUpdateFooter,
            this.layoutControlItem30,
            this.layoutControlItem6,
            this.layoutControlItem17,
            this.layoutControlItem3,
            this.emptySpaceItem2,
            this.layoutControlConfirm,
            this.emptySpaceItem3,
            this.emptySpaceItem4,
            this.emptySpaceItem5,
            this.layoutControlItem7,
            this.layoutControlItem14,
            this.emptySpaceItem6,
            this.layoutControlEditVAT,
            this.layoutControlItem27,
            this.layoutControlItem28});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1552, 702);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.grcBillingInvoiceDetails;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 170);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(1536, 438);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(209, 644);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(272, 42);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.simpleButton1;
            this.layoutControlItem10.Location = new System.Drawing.Point(1432, 644);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(104, 42);
            this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem10.TextVisible = false;
            // 
            // layoutControlIUpdateCustomer
            // 
            this.layoutControlIUpdateCustomer.Control = this.btn_UpdateCustomer;
            this.layoutControlIUpdateCustomer.Location = new System.Drawing.Point(1313, 644);
            this.layoutControlIUpdateCustomer.Name = "layoutControlIUpdateCustomer";
            this.layoutControlIUpdateCustomer.Size = new System.Drawing.Size(119, 42);
            this.layoutControlIUpdateCustomer.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlIUpdateCustomer.TextVisible = false;
            // 
            // layoutControlItem18
            // 
            this.layoutControlItem18.Control = this.txtBillingInvoicesRecordNumber;
            this.layoutControlItem18.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem18.Name = "layoutControlItem18";
            this.layoutControlItem18.Size = new System.Drawing.Size(262, 52);
            this.layoutControlItem18.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 3, 3);
            this.layoutControlItem18.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem18.TextVisible = false;
            // 
            // Created
            // 
            this.Created.Control = this.txtCreatedBy;
            this.Created.Location = new System.Drawing.Point(0, 52);
            this.Created.MinSize = new System.Drawing.Size(134, 31);
            this.Created.Name = "Created";
            this.Created.Size = new System.Drawing.Size(135, 36);
            this.Created.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.Created.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 3, 3);
            this.Created.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.Created.TextSize = new System.Drawing.Size(60, 17);
            this.Created.TextToControlDistance = 5;
            // 
            // layoutControlItem21
            // 
            this.layoutControlItem21.Control = this.dtngBillingInvoices;
            this.layoutControlItem21.Location = new System.Drawing.Point(0, 88);
            this.layoutControlItem21.Name = "layoutControlItem21";
            this.layoutControlItem21.Size = new System.Drawing.Size(208, 46);
            this.layoutControlItem21.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 3, 3);
            this.layoutControlItem21.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem21.TextVisible = false;
            // 
            // layoutControlItem22
            // 
            this.layoutControlItem22.Control = this.btn_NewBillingInvoices;
            this.layoutControlItem22.Location = new System.Drawing.Point(208, 88);
            this.layoutControlItem22.Name = "layoutControlItem22";
            this.layoutControlItem22.Size = new System.Drawing.Size(54, 46);
            this.layoutControlItem22.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 3, 3);
            this.layoutControlItem22.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem22.TextVisible = false;
            // 
            // layoutControlUpdate
            // 
            this.layoutControlUpdate.Control = this.btn_Update;
            this.layoutControlUpdate.Location = new System.Drawing.Point(1105, 644);
            this.layoutControlUpdate.Name = "layoutControlUpdate";
            this.layoutControlUpdate.Size = new System.Drawing.Size(104, 42);
            this.layoutControlUpdate.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlUpdate.TextVisible = false;
            // 
            // layoutControlDelete
            // 
            this.layoutControlDelete.Control = this.btn_Delete;
            this.layoutControlDelete.Location = new System.Drawing.Point(0, 644);
            this.layoutControlDelete.Name = "layoutControlDelete";
            this.layoutControlDelete.Size = new System.Drawing.Size(104, 42);
            this.layoutControlDelete.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlDelete.TextVisible = false;
            // 
            // Created1
            // 
            this.Created1.Control = this.txtCreatedTime;
            this.Created1.CustomizationFormText = "Created";
            this.Created1.Location = new System.Drawing.Point(135, 52);
            this.Created1.Name = "Created1";
            this.Created1.Size = new System.Drawing.Size(127, 36);
            this.Created1.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 3, 3);
            this.Created1.Text = "Created";
            this.Created1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.Created1.TextSize = new System.Drawing.Size(0, 0);
            this.Created1.TextToControlDistance = 0;
            this.Created1.TextVisible = false;
            // 
            // Created2
            // 
            this.Created2.Control = this.txtConfirmedBy;
            this.Created2.CustomizationFormText = "Created";
            this.Created2.Location = new System.Drawing.Point(0, 134);
            this.Created2.MinSize = new System.Drawing.Size(134, 31);
            this.Created2.Name = "Created2";
            this.Created2.Size = new System.Drawing.Size(135, 36);
            this.Created2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.Created2.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 3, 3);
            this.Created2.Text = "Confirm";
            this.Created2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.Created2.TextSize = new System.Drawing.Size(60, 17);
            this.Created2.TextToControlDistance = 5;
            // 
            // Created3
            // 
            this.Created3.Control = this.txtConfirmedTime;
            this.Created3.CustomizationFormText = "Created";
            this.Created3.Location = new System.Drawing.Point(135, 134);
            this.Created3.Name = "Created3";
            this.Created3.Size = new System.Drawing.Size(127, 36);
            this.Created3.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 3, 3);
            this.Created3.Text = "Created";
            this.Created3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.Created3.TextSize = new System.Drawing.Size(0, 0);
            this.Created3.TextToControlDistance = 0;
            this.Created3.TextVisible = false;
            // 
            // layoutControlItem23
            // 
            this.layoutControlItem23.Control = this.textInvoiceAmount;
            this.layoutControlItem23.CustomizationFormText = "NET";
            this.layoutControlItem23.Location = new System.Drawing.Point(0, 608);
            this.layoutControlItem23.Name = "layoutControlItem23";
            this.layoutControlItem23.Size = new System.Drawing.Size(199, 36);
            this.layoutControlItem23.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 3, 3);
            this.layoutControlItem23.Text = "NET   ";
            this.layoutControlItem23.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem23.TextSize = new System.Drawing.Size(35, 16);
            this.layoutControlItem23.TextToControlDistance = 5;
            // 
            // layoutControlItem31
            // 
            this.layoutControlItem31.Control = this.textGrossAmount;
            this.layoutControlItem31.CustomizationFormText = "Invoice Amount";
            this.layoutControlItem31.Location = new System.Drawing.Point(434, 608);
            this.layoutControlItem31.Name = "layoutControlItem31";
            this.layoutControlItem31.Size = new System.Drawing.Size(198, 36);
            this.layoutControlItem31.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 3, 3);
            this.layoutControlItem31.Text = "Gross   ";
            this.layoutControlItem31.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem31.TextSize = new System.Drawing.Size(44, 16);
            this.layoutControlItem31.TextToControlDistance = 5;
            // 
            // layoutControlItem32
            // 
            this.layoutControlItem32.Control = this.textGrossAmountWording;
            this.layoutControlItem32.CustomizationFormText = "Amount Wording";
            this.layoutControlItem32.Location = new System.Drawing.Point(679, 608);
            this.layoutControlItem32.Name = "layoutControlItem32";
            this.layoutControlItem32.Size = new System.Drawing.Size(857, 36);
            this.layoutControlItem32.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 3, 3);
            this.layoutControlItem32.Text = "Wording    ";
            this.layoutControlItem32.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem32.TextSize = new System.Drawing.Size(64, 16);
            this.layoutControlItem32.TextToControlDistance = 3;
            // 
            // layoutControlItem26
            // 
            this.layoutControlItem26.Control = this.textVATAmount;
            this.layoutControlItem26.CustomizationFormText = "Invoice Amount";
            this.layoutControlItem26.Location = new System.Drawing.Point(209, 608);
            this.layoutControlItem26.Name = "layoutControlItem26";
            this.layoutControlItem26.Size = new System.Drawing.Size(190, 36);
            this.layoutControlItem26.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 3, 3);
            this.layoutControlItem26.Text = "VAT   ";
            this.layoutControlItem26.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem26.TextSize = new System.Drawing.Size(36, 16);
            this.layoutControlItem26.TextToControlDistance = 5;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lkeCustomers;
            this.layoutControlItem1.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.layoutControlItem1.CustomizationFormText = "Customer";
            this.layoutControlItem1.Location = new System.Drawing.Point(262, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(188, 36);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 3, 3);
            this.layoutControlItem1.Text = "Customer";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(89, 16);
            this.layoutControlItem1.TrimClientAreaToControl = false;
            // 
            // layoutControlItem16
            // 
            this.layoutControlItem16.Control = this.txtCustomerName;
            this.layoutControlItem16.CustomizationFormText = "Invoice Amount";
            this.layoutControlItem16.Location = new System.Drawing.Point(450, 0);
            this.layoutControlItem16.Name = "layoutControlItem16";
            this.layoutControlItem16.Size = new System.Drawing.Size(419, 36);
            this.layoutControlItem16.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 3, 3);
            this.layoutControlItem16.Text = "Customer Name";
            this.layoutControlItem16.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem16.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.dteInvoiceDate;
            this.layoutControlItem2.Location = new System.Drawing.Point(1087, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(223, 36);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 3, 3);
            this.layoutControlItem2.Text = "Invoice Date";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(89, 16);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.lkeCurrency;
            this.layoutControlItem4.Location = new System.Drawing.Point(869, 72);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(191, 36);
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 3, 3);
            this.layoutControlItem4.Text = "Currency";
            this.layoutControlItem4.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(60, 15);
            this.layoutControlItem4.TextToControlDistance = 0;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.lkeStores;
            this.layoutControlItem5.Location = new System.Drawing.Point(869, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(191, 36);
            this.layoutControlItem5.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 3, 3);
            this.layoutControlItem5.Text = "Store";
            this.layoutControlItem5.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(60, 15);
            this.layoutControlItem5.TextToControlDistance = 0;
            // 
            // layoutControlItem24
            // 
            this.layoutControlItem24.Control = this.textCustomerAddress;
            this.layoutControlItem24.CustomizationFormText = "Invoice Amount";
            this.layoutControlItem24.Location = new System.Drawing.Point(262, 36);
            this.layoutControlItem24.Name = "layoutControlItem24";
            this.layoutControlItem24.Size = new System.Drawing.Size(798, 36);
            this.layoutControlItem24.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 3, 3);
            this.layoutControlItem24.Text = "Address";
            this.layoutControlItem24.TextSize = new System.Drawing.Size(89, 16);
            // 
            // layoutControlItem25
            // 
            this.layoutControlItem25.Control = this.textCustomerTaxCode;
            this.layoutControlItem25.CustomizationFormText = "Invoice Amount";
            this.layoutControlItem25.Location = new System.Drawing.Point(1333, 36);
            this.layoutControlItem25.Name = "layoutControlItem25";
            this.layoutControlItem25.Size = new System.Drawing.Size(203, 36);
            this.layoutControlItem25.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 3, 3);
            this.layoutControlItem25.Text = "Tax Code";
            this.layoutControlItem25.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem25.TextSize = new System.Drawing.Size(66, 15);
            this.layoutControlItem25.TextToControlDistance = 3;
            // 
            // layoutControlItem15
            // 
            this.layoutControlItem15.Control = this.textBillingID;
            this.layoutControlItem15.CustomizationFormText = "Invoice Amount";
            this.layoutControlItem15.Location = new System.Drawing.Point(1333, 0);
            this.layoutControlItem15.Name = "layoutControlItem15";
            this.layoutControlItem15.Size = new System.Drawing.Size(203, 36);
            this.layoutControlItem15.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 3, 3);
            this.layoutControlItem15.Text = "Billing ID";
            this.layoutControlItem15.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem15.TextSize = new System.Drawing.Size(66, 15);
            this.layoutControlItem15.TextToControlDistance = 3;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.txtBuyer;
            this.layoutControlItem9.CustomizationFormText = "Buyer";
            this.layoutControlItem9.Location = new System.Drawing.Point(1087, 36);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(223, 36);
            this.layoutControlItem9.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 3, 3);
            this.layoutControlItem9.Text = "Buyer";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(89, 16);
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.txtPONo;
            this.layoutControlItem12.Location = new System.Drawing.Point(1087, 72);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(223, 98);
            this.layoutControlItem12.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 3, 3);
            this.layoutControlItem12.Text = "PO No";
            this.layoutControlItem12.TextSize = new System.Drawing.Size(89, 16);
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.Control = this.txtPayDays;
            this.layoutControlItem13.Location = new System.Drawing.Point(1333, 72);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new System.Drawing.Size(203, 36);
            this.layoutControlItem13.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 3, 3);
            this.layoutControlItem13.Text = "Pay Days";
            this.layoutControlItem13.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem13.TextSize = new System.Drawing.Size(66, 15);
            this.layoutControlItem13.TextToControlDistance = 5;
            // 
            // layoutControlItemEmailReport
            // 
            this.layoutControlItemEmailReport.Control = this.btnSendEmail;
            this.layoutControlItemEmailReport.Location = new System.Drawing.Point(1209, 644);
            this.layoutControlItemEmailReport.Name = "layoutControlItemEmailReport";
            this.layoutControlItemEmailReport.Size = new System.Drawing.Size(104, 42);
            this.layoutControlItemEmailReport.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemEmailReport.TextVisible = false;
            // 
            // layoutControlItem20
            // 
            this.layoutControlItem20.Control = this.textCurrencyExchangeRate;
            this.layoutControlItem20.Location = new System.Drawing.Point(699, 72);
            this.layoutControlItem20.Name = "layoutControlItem20";
            this.layoutControlItem20.Size = new System.Drawing.Size(170, 36);
            this.layoutControlItem20.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 3, 3);
            this.layoutControlItem20.Text = "Exc Rate";
            this.layoutControlItem20.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem20.TextSize = new System.Drawing.Size(70, 15);
            this.layoutControlItem20.TextToControlDistance = 5;
            // 
            // layoutControlUpdateFooter
            // 
            this.layoutControlUpdateFooter.Control = this.btnUpdateManual;
            this.layoutControlUpdateFooter.Location = new System.Drawing.Point(1001, 644);
            this.layoutControlUpdateFooter.Name = "layoutControlUpdateFooter";
            this.layoutControlUpdateFooter.Size = new System.Drawing.Size(104, 42);
            this.layoutControlUpdateFooter.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlUpdateFooter.TextVisible = false;
            // 
            // layoutControlItem30
            // 
            this.layoutControlItem30.Control = this.textInvPeriod;
            this.layoutControlItem30.Location = new System.Drawing.Point(449, 72);
            this.layoutControlItem30.Name = "layoutControlItem30";
            this.layoutControlItem30.Size = new System.Drawing.Size(250, 36);
            this.layoutControlItem30.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 3, 3);
            this.layoutControlItem30.Text = "Inv. Period";
            this.layoutControlItem30.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem30.TextSize = new System.Drawing.Size(70, 15);
            this.layoutControlItem30.TextToControlDistance = 5;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.lkePaymentMethod;
            this.layoutControlItem6.CustomizationFormText = "Currency";
            this.layoutControlItem6.Location = new System.Drawing.Point(1333, 108);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(203, 62);
            this.layoutControlItem6.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 3, 3);
            this.layoutControlItem6.Text = "Pay Meth.";
            this.layoutControlItem6.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(66, 15);
            this.layoutControlItem6.TextToControlDistance = 5;
            // 
            // layoutControlItem17
            // 
            this.layoutControlItem17.Control = this.memoInvRemark;
            this.layoutControlItem17.Location = new System.Drawing.Point(262, 108);
            this.layoutControlItem17.Name = "layoutControlItem17";
            this.layoutControlItem17.Size = new System.Drawing.Size(798, 62);
            this.layoutControlItem17.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 3, 3);
            this.layoutControlItem17.Text = "Invoice Remark";
            this.layoutControlItem17.TextSize = new System.Drawing.Size(89, 16);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtEInvNum;
            this.layoutControlItem3.Location = new System.Drawing.Point(262, 72);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(187, 36);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 3, 3);
            this.layoutControlItem3.Text = "E Inv Num";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(89, 16);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(1310, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(23, 170);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlConfirm
            // 
            this.layoutControlConfirm.Control = this.btn_accept;
            this.layoutControlConfirm.Location = new System.Drawing.Point(104, 644);
            this.layoutControlConfirm.Name = "layoutControlConfirm";
            this.layoutControlConfirm.Size = new System.Drawing.Size(105, 42);
            this.layoutControlConfirm.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlConfirm.TextVisible = false;
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(199, 608);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(10, 36);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.Location = new System.Drawing.Point(399, 608);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(35, 36);
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem5
            // 
            this.emptySpaceItem5.AllowHotTrack = false;
            this.emptySpaceItem5.Location = new System.Drawing.Point(632, 608);
            this.emptySpaceItem5.Name = "emptySpaceItem5";
            this.emptySpaceItem5.Size = new System.Drawing.Size(47, 36);
            this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.btnBreakInvoice;
            this.layoutControlItem7.Location = new System.Drawing.Point(897, 644);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(104, 42);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem14
            // 
            this.layoutControlItem14.Control = this.btnImportExcel;
            this.layoutControlItem14.Location = new System.Drawing.Point(585, 644);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Size = new System.Drawing.Size(104, 42);
            this.layoutControlItem14.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem14.TextVisible = false;
            // 
            // emptySpaceItem6
            // 
            this.emptySpaceItem6.AllowHotTrack = false;
            this.emptySpaceItem6.Location = new System.Drawing.Point(1060, 0);
            this.emptySpaceItem6.Name = "emptySpaceItem6";
            this.emptySpaceItem6.Size = new System.Drawing.Size(27, 170);
            this.emptySpaceItem6.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlEditVAT
            // 
            this.layoutControlEditVAT.Control = this.btnEditVAT;
            this.layoutControlEditVAT.Location = new System.Drawing.Point(481, 644);
            this.layoutControlEditVAT.Name = "layoutControlEditVAT";
            this.layoutControlEditVAT.Size = new System.Drawing.Size(104, 42);
            this.layoutControlEditVAT.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlEditVAT.TextVisible = false;
            // 
            // layoutControlItem27
            // 
            this.layoutControlItem27.Control = this.btnVat7;
            this.layoutControlItem27.Location = new System.Drawing.Point(689, 644);
            this.layoutControlItem27.Name = "layoutControlItem27";
            this.layoutControlItem27.Size = new System.Drawing.Size(104, 42);
            this.layoutControlItem27.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem27.TextVisible = false;
            // 
            // layoutControlItem28
            // 
            this.layoutControlItem28.Control = this.btnVAT8;
            this.layoutControlItem28.Location = new System.Drawing.Point(793, 644);
            this.layoutControlItem28.Name = "layoutControlItem28";
            this.layoutControlItem28.Size = new System.Drawing.Size(104, 42);
            this.layoutControlItem28.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem28.TextVisible = false;
            // 
            // frm_AD_BillingInvoices
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1552, 753);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_AD_BillingInvoices.IconOptions.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frm_AD_BillingInvoices";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "Billing Invoices";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_AD_BillingInvoices_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_AD_BillingInvoices_KeyDown);
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textInvPeriod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textCurrencyExchangeRate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPayDays.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPONo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBuyer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgDataNavigator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreatedBy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillingInvoicesRecordNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoInvRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeStores.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeCurrency.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEInvNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteInvoiceDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteInvoiceDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreatedTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBillingID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textInvoiceAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textCustomerTaxCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textVATAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textGrossAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textGrossAmountWording.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeCustomers.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkePaymentMethod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmedBy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmedTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcBillingInvoiceDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBillingInvoiceDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_btn_Delete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_btn_Break)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_cbo_VATRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textCustomerAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlIUpdateCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Created)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Created1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Created2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Created3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemEmailReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlUpdateFooter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlConfirm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlEditVAT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.DateEdit dteInvoiceDate;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.LookUpEdit lkeCurrency;
        private DevExpress.XtraEditors.TextEdit txtEInvNum;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraGrid.GridControl grcBillingInvoiceDetails;
        private Common.Controls.WMSGridView grvBillingInvoiceDetails;
        private DevExpress.XtraEditors.LookUpEdit lkeStores;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraEditors.SimpleButton btn_Delete;
        private DevExpress.XtraEditors.SimpleButton btn_UpdateCustomer;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlIUpdateCustomer;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlDelete;
        private DevExpress.XtraEditors.MemoEdit memoInvRemark;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem17;
        private DevExpress.XtraEditors.TextEdit txtBillingInvoicesRecordNumber;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem18;
        private DevExpress.XtraEditors.TextEdit txtCreatedBy;
        private DevExpress.XtraLayout.LayoutControlItem Created;
        private DevExpress.XtraEditors.DataNavigator dtngBillingInvoices;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem21;
        private DevExpress.XtraEditors.SimpleButton btn_NewBillingInvoices;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem22;
        private DevExpress.Utils.ImageCollection imgDataNavigator;
        private DevExpress.XtraGrid.Columns.GridColumn colServiceName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnItemdesc;
        private DevExpress.XtraGrid.Columns.GridColumn colQty;
        private DevExpress.XtraGrid.Columns.GridColumn colVAT;
        private DevExpress.XtraGrid.Columns.GridColumn colAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraEditors.SimpleButton btn_Update;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlUpdate;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
        private DevExpress.XtraEditors.SimpleButton btn_accept;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlConfirm;
        private DevExpress.XtraEditors.TextEdit txtCreatedTime;
        private DevExpress.XtraLayout.LayoutControlItem Created1;
        private DevExpress.XtraEditors.TextEdit textBillingID;
        private DevExpress.XtraEditors.TextEdit txtCustomerName;
        private DevExpress.XtraEditors.TextEdit textInvoiceAmount;
        private DevExpress.XtraEditors.TextEdit textCustomerAddress;
        private DevExpress.XtraEditors.TextEdit textCustomerTaxCode;
        private DevExpress.XtraEditors.TextEdit textVATAmount;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem15;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem16;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem23;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem24;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem25;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem26;
        private DevExpress.XtraEditors.TextEdit textGrossAmount;
        private DevExpress.XtraEditors.TextEdit textGrossAmountWording;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem32;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem31;
        private DevExpress.XtraEditors.LookUpEdit lkeCustomers;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.LookUpEdit lkePaymentMethod;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.TextEdit txtConfirmedBy;
        private DevExpress.XtraEditors.TextEdit txtConfirmedTime;
        private DevExpress.XtraLayout.LayoutControlItem Created2;
        private DevExpress.XtraLayout.LayoutControlItem Created3;
        private DevExpress.XtraGrid.Columns.GridColumn colUOM;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.TextEdit txtPayDays;
        private DevExpress.XtraEditors.TextEdit txtPONo;
        private DevExpress.XtraEditors.TextEdit txtBuyer;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem13;
        private DevExpress.XtraGrid.Columns.GridColumn colDel;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rpi_btn_Delete;
        private DevExpress.XtraEditors.TextEdit textCurrencyExchangeRate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem20;
        private DevExpress.XtraEditors.SimpleButton btnSendEmail;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemEmailReport;
        private DevExpress.XtraEditors.TextEdit textInvPeriod;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem30;
        private DevExpress.XtraEditors.SimpleButton btnUpdateManual;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlUpdateFooter;
        private DevExpress.XtraGrid.Columns.GridColumn colPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colVATPercent;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox rpi_cbo_VATRate;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraGrid.Columns.GridColumn colBreak;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rpi_btn_Break;
        private DevExpress.XtraEditors.SimpleButton btnBreakInvoice;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.SimpleButton btnImportExcel;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem14;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem6;
        private DevExpress.XtraEditors.SimpleButton btnEditVAT;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlEditVAT;
        private DevExpress.XtraEditors.SimpleButton btnVat7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem27;
        private DevExpress.XtraEditors.SimpleButton btnVAT8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem28;
    }
}