namespace UI.Admin
{
    partial class frm_AD_BillingInvoiceList
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
            DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, null, true, true);
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression1 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_AD_BillingInvoiceList));
            this.gridColumnCustomerNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnViewDeleted = new DevExpress.XtraEditors.SimpleButton();
            this.btnEmailSelected = new DevExpress.XtraEditors.SimpleButton();
            this.grcBillingInvoiceDetails = new DevExpress.XtraGrid.GridControl();
            this.grvBillingInvoiceDetails = new Common.Controls.WMSGridView();
            this.gridColumnPartID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnVAT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnItemdesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpe_hle_InvoiceID = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpe_hle_BillingID = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_chk_Attachment = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_chk_Confirmed = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnInvoiceTo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDeleteReason = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BillingInvoiceIDHash = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dToDate = new DevExpress.XtraEditors.DateEdit();
            this.dFromDate = new DevExpress.XtraEditors.DateEdit();
            this.btnRefreshList = new DevExpress.XtraEditors.SimpleButton();
            this.btnCombineInvoice = new DevExpress.XtraEditors.SimpleButton();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlEmail = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlCombine = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcBillingInvoiceDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBillingInvoiceDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpe_hle_InvoiceID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpe_hle_BillingID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_chk_Attachment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_chk_Confirmed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dToDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dFromDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlCombine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // splashScreenManager1
            // 
            splashScreenManager1.ClosingDelay = 500;
            // 
            // gridColumnCustomerNumber
            // 
            this.gridColumnCustomerNumber.Caption = "Customer ID";
            this.gridColumnCustomerNumber.FieldName = "CustomerNumber";
            this.gridColumnCustomerNumber.MinWidth = 25;
            this.gridColumnCustomerNumber.Name = "gridColumnCustomerNumber";
            this.gridColumnCustomerNumber.Visible = true;
            this.gridColumnCustomerNumber.VisibleIndex = 3;
            this.gridColumnCustomerNumber.Width = 73;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnViewDeleted);
            this.layoutControl1.Controls.Add(this.btnEmailSelected);
            this.layoutControl1.Controls.Add(this.grcBillingInvoiceDetails);
            this.layoutControl1.Controls.Add(this.dToDate);
            this.layoutControl1.Controls.Add(this.dFromDate);
            this.layoutControl1.Controls.Add(this.btnRefreshList);
            this.layoutControl1.Controls.Add(this.btnCombineInvoice);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1108, 140, 812, 500);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1710, 726);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnViewDeleted
            // 
            this.btnViewDeleted.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Question;
            this.btnViewDeleted.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnViewDeleted.Appearance.Options.UseBackColor = true;
            this.btnViewDeleted.Appearance.Options.UseFont = true;
            this.btnViewDeleted.Location = new System.Drawing.Point(1574, 10);
            this.btnViewDeleted.MaximumSize = new System.Drawing.Size(125, 27);
            this.btnViewDeleted.MinimumSize = new System.Drawing.Size(125, 27);
            this.btnViewDeleted.Name = "btnViewDeleted";
            this.btnViewDeleted.Size = new System.Drawing.Size(125, 27);
            this.btnViewDeleted.StyleController = this.layoutControl1;
            this.btnViewDeleted.TabIndex = 16;
            this.btnViewDeleted.Text = "View Deleted";
            this.btnViewDeleted.Click += new System.EventHandler(this.btnViewDeleted_Click);
            // 
            // btnEmailSelected
            // 
            this.btnEmailSelected.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnEmailSelected.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnEmailSelected.Appearance.Options.UseBackColor = true;
            this.btnEmailSelected.Appearance.Options.UseFont = true;
            this.btnEmailSelected.Location = new System.Drawing.Point(1316, 10);
            this.btnEmailSelected.MaximumSize = new System.Drawing.Size(125, 27);
            this.btnEmailSelected.MinimumSize = new System.Drawing.Size(125, 27);
            this.btnEmailSelected.Name = "btnEmailSelected";
            this.btnEmailSelected.Size = new System.Drawing.Size(125, 27);
            this.btnEmailSelected.StyleController = this.layoutControl1;
            this.btnEmailSelected.TabIndex = 14;
            this.btnEmailSelected.Text = "Email Selected";
            this.btnEmailSelected.Click += new System.EventHandler(this.btnEmailSelected_Click);
            // 
            // grcBillingInvoiceDetails
            // 
            this.grcBillingInvoiceDetails.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.grcBillingInvoiceDetails.Location = new System.Drawing.Point(11, 46);
            this.grcBillingInvoiceDetails.MainView = this.grvBillingInvoiceDetails;
            this.grcBillingInvoiceDetails.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grcBillingInvoiceDetails.Name = "grcBillingInvoiceDetails";
            this.grcBillingInvoiceDetails.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpe_hle_InvoiceID,
            this.rpe_hle_BillingID,
            this.rpi_chk_Attachment,
            this.rpi_chk_Confirmed});
            this.grcBillingInvoiceDetails.Size = new System.Drawing.Size(1688, 670);
            this.grcBillingInvoiceDetails.TabIndex = 12;
            this.grcBillingInvoiceDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBillingInvoiceDetails});
            // 
            // grvBillingInvoiceDetails
            // 
            this.grvBillingInvoiceDetails.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnPartID,
            this.gridColumnQty,
            this.gridColumnVAT,
            this.gridColumnAmount,
            this.gridColumnRemark,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumnItemdesc,
            this.gridColumn1,
            this.gridColumn5,
            this.gridColumnCustomerNumber,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn17,
            this.gridColumn18,
            this.gridColumn19,
            this.gridColumn20,
            this.gridColumn21,
            this.gridColumn22,
            this.gridColumnInvoiceTo,
            this.gridColumnDeleteReason,
            this.BillingInvoiceIDHash});
            this.grvBillingInvoiceDetails.DetailHeight = 458;
            this.grvBillingInvoiceDetails.FixedLineWidth = 4;
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Column = this.gridColumnCustomerNumber;
            gridFormatRule1.Name = "Format0";
            formatConditionRuleExpression1.Expression = "[CustomerNumber] <> [CustomerNumberInvoiceTo]";
            formatConditionRuleExpression1.PredefinedName = "Red Fill, Red Text";
            gridFormatRule1.Rule = formatConditionRuleExpression1;
            this.grvBillingInvoiceDetails.FormatRules.Add(gridFormatRule1);
            this.grvBillingInvoiceDetails.GridControl = this.grcBillingInvoiceDetails;
            this.grvBillingInvoiceDetails.Name = "grvBillingInvoiceDetails";
            this.grvBillingInvoiceDetails.OptionsSelection.CheckBoxSelectorColumnWidth = 30;
            this.grvBillingInvoiceDetails.OptionsSelection.MultiSelect = true;
            this.grvBillingInvoiceDetails.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.grvBillingInvoiceDetails.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.grvBillingInvoiceDetails.OptionsView.ShowGroupPanel = false;
            this.grvBillingInvoiceDetails.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvBillingInvoiceDetails.PaintStyleName = "Skin";
            // 
            // gridColumnPartID
            // 
            this.gridColumnPartID.Caption = "Service Name";
            this.gridColumnPartID.FieldName = "ServiceName";
            this.gridColumnPartID.MinWidth = 27;
            this.gridColumnPartID.Name = "gridColumnPartID";
            this.gridColumnPartID.Width = 471;
            // 
            // gridColumnQty
            // 
            this.gridColumnQty.Caption = "Qty";
            this.gridColumnQty.DisplayFormat.FormatString = "n0";
            this.gridColumnQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnQty.FieldName = "ServiceQuantity";
            this.gridColumnQty.MinWidth = 27;
            this.gridColumnQty.Name = "gridColumnQty";
            this.gridColumnQty.Width = 67;
            // 
            // gridColumnVAT
            // 
            this.gridColumnVAT.Caption = "VAT";
            this.gridColumnVAT.DisplayFormat.FormatString = "n0";
            this.gridColumnVAT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnVAT.FieldName = "VATAmount";
            this.gridColumnVAT.MinWidth = 27;
            this.gridColumnVAT.Name = "gridColumnVAT";
            this.gridColumnVAT.Visible = true;
            this.gridColumnVAT.VisibleIndex = 7;
            this.gridColumnVAT.Width = 94;
            // 
            // gridColumnAmount
            // 
            this.gridColumnAmount.Caption = "Amount";
            this.gridColumnAmount.DisplayFormat.FormatString = "n0";
            this.gridColumnAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnAmount.FieldName = "Amount";
            this.gridColumnAmount.MinWidth = 27;
            this.gridColumnAmount.Name = "gridColumnAmount";
            this.gridColumnAmount.Visible = true;
            this.gridColumnAmount.VisibleIndex = 6;
            this.gridColumnAmount.Width = 122;
            // 
            // gridColumnRemark
            // 
            this.gridColumnRemark.Caption = "Inv Detail. Remark";
            this.gridColumnRemark.FieldName = "BillingInvoiceDetailRemark";
            this.gridColumnRemark.MinWidth = 27;
            this.gridColumnRemark.Name = "gridColumnRemark";
            this.gridColumnRemark.Width = 312;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "UOM";
            this.gridColumn2.FieldName = "UOM";
            this.gridColumn2.MinWidth = 25;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Width = 94;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Code";
            this.gridColumn3.FieldName = "ServiceCode";
            this.gridColumn3.MinWidth = 25;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Width = 94;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "DetailID";
            this.gridColumn4.FieldName = "BillingInvoiceDetailID";
            this.gridColumn4.MinWidth = 25;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Width = 94;
            // 
            // gridColumnItemdesc
            // 
            this.gridColumnItemdesc.Caption = "ServiceID";
            this.gridColumnItemdesc.FieldName = "ServiceID";
            this.gridColumnItemdesc.MinWidth = 27;
            this.gridColumnItemdesc.Name = "gridColumnItemdesc";
            this.gridColumnItemdesc.OptionsColumn.AllowEdit = false;
            this.gridColumnItemdesc.Width = 443;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "OrderNumber";
            this.gridColumn1.FieldName = "OrderNUmber";
            this.gridColumn1.MinWidth = 25;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Width = 94;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Inv. No";
            this.gridColumn5.ColumnEdit = this.rpe_hle_InvoiceID;
            this.gridColumn5.FieldName = "BillingInvoiceNumber";
            this.gridColumn5.MinWidth = 25;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            this.gridColumn5.Width = 81;
            // 
            // rpe_hle_InvoiceID
            // 
            this.rpe_hle_InvoiceID.AutoHeight = false;
            this.rpe_hle_InvoiceID.Name = "rpe_hle_InvoiceID";
            this.rpe_hle_InvoiceID.Click += new System.EventHandler(this.rpe_hle_InvoiceID_Click);
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Customer Name";
            this.gridColumn7.FieldName = "CustomerName";
            this.gridColumn7.MinWidth = 25;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 4;
            this.gridColumn7.Width = 325;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Inv.Date";
            this.gridColumn8.FieldName = "IssueDate";
            this.gridColumn8.MinWidth = 25;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 1;
            this.gridColumn8.Width = 86;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Inv. Remark";
            this.gridColumn9.FieldName = "BillingInvoiceRemark";
            this.gridColumn9.MinWidth = 25;
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 8;
            this.gridColumn9.Width = 145;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Bill ID";
            this.gridColumn10.ColumnEdit = this.rpe_hle_BillingID;
            this.gridColumn10.FieldName = "BillingID";
            this.gridColumn10.MinWidth = 25;
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 9;
            // 
            // rpe_hle_BillingID
            // 
            this.rpe_hle_BillingID.AutoHeight = false;
            this.rpe_hle_BillingID.Name = "rpe_hle_BillingID";
            this.rpe_hle_BillingID.Click += new System.EventHandler(this.rpe_hle_BillingID_Click);
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "E Inv Link";
            this.gridColumn12.FieldName = "EInvoiceLink";
            this.gridColumn12.MinWidth = 25;
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Width = 119;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "CREATED TIME";
            this.gridColumn13.DisplayFormat.FormatString = "dd/MM HH:mm";
            this.gridColumn13.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn13.FieldName = "CreatedTime";
            this.gridColumn13.MinWidth = 25;
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 10;
            this.gridColumn13.Width = 132;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "USer";
            this.gridColumn14.FieldName = "CreatedBy";
            this.gridColumn14.MinWidth = 25;
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Width = 52;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "CustomerID";
            this.gridColumn17.FieldName = "CustomerID";
            this.gridColumn17.MinWidth = 25;
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.Width = 94;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = " ";
            this.gridColumn18.ColumnEdit = this.rpi_chk_Attachment;
            this.gridColumn18.FieldName = "IsAttachment";
            this.gridColumn18.ImageOptions.Alignment = System.Drawing.StringAlignment.Center;
            this.gridColumn18.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("gridColumn18.ImageOptions.Image")));
            this.gridColumn18.MaxWidth = 37;
            this.gridColumn18.MinWidth = 37;
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsColumn.ReadOnly = true;
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 13;
            this.gridColumn18.Width = 37;
            // 
            // rpi_chk_Attachment
            // 
            this.rpi_chk_Attachment.Appearance.Options.UseImage = true;
            this.rpi_chk_Attachment.AppearanceFocused.Options.UseImage = true;
            this.rpi_chk_Attachment.AppearanceReadOnly.Options.UseImage = true;
            this.rpi_chk_Attachment.AutoHeight = false;
            this.rpi_chk_Attachment.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Custom;
            this.rpi_chk_Attachment.ImageOptions.ImageChecked = ((System.Drawing.Image)(resources.GetObject("rpi_chk_Attachment.ImageOptions.ImageChecked")));
            this.rpi_chk_Attachment.Name = "rpi_chk_Attachment";
            this.rpi_chk_Attachment.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.rpi_chk_Attachment.ReadOnly = true;
            this.rpi_chk_Attachment.Click += new System.EventHandler(this.rpi_chk_Attachment_Click);
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "InvPeriod";
            this.gridColumn19.FieldName = "InvoicePeriod";
            this.gridColumn19.MinWidth = 25;
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.Width = 94;
            // 
            // gridColumn20
            // 
            this.gridColumn20.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn20.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn20.Caption = "X";
            this.gridColumn20.ColumnEdit = this.rpi_chk_Confirmed;
            this.gridColumn20.FieldName = "isConfirmed";
            this.gridColumn20.MinWidth = 25;
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 11;
            this.gridColumn20.Width = 25;
            // 
            // rpi_chk_Confirmed
            // 
            this.rpi_chk_Confirmed.AutoHeight = false;
            this.rpi_chk_Confirmed.Name = "rpi_chk_Confirmed";
            this.rpi_chk_Confirmed.ReadOnly = true;
            // 
            // gridColumn21
            // 
            this.gridColumn21.Caption = "Confirmed By";
            this.gridColumn21.FieldName = "ConfirmedBy";
            this.gridColumn21.MinWidth = 25;
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.Width = 94;
            // 
            // gridColumn22
            // 
            this.gridColumn22.Caption = "Cfrm Time";
            this.gridColumn22.DisplayFormat.FormatString = "dd/MM HH:mm";
            this.gridColumn22.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn22.FieldName = "ConfirmedTime";
            this.gridColumn22.MinWidth = 25;
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.Visible = true;
            this.gridColumn22.VisibleIndex = 12;
            this.gridColumn22.Width = 124;
            // 
            // gridColumnInvoiceTo
            // 
            this.gridColumnInvoiceTo.Caption = "INv TO";
            this.gridColumnInvoiceTo.FieldName = "CustomerNumberInvoiceTo";
            this.gridColumnInvoiceTo.MinWidth = 25;
            this.gridColumnInvoiceTo.Name = "gridColumnInvoiceTo";
            this.gridColumnInvoiceTo.Visible = true;
            this.gridColumnInvoiceTo.VisibleIndex = 5;
            this.gridColumnInvoiceTo.Width = 74;
            // 
            // gridColumnDeleteReason
            // 
            this.gridColumnDeleteReason.Caption = "Delete Reason";
            this.gridColumnDeleteReason.FieldName = "DeleteReason";
            this.gridColumnDeleteReason.MinWidth = 25;
            this.gridColumnDeleteReason.Name = "gridColumnDeleteReason";
            this.gridColumnDeleteReason.Width = 94;
            // 
            // BillingInvoiceIDHash
            // 
            this.BillingInvoiceIDHash.Caption = "gridColumn6";
            this.BillingInvoiceIDHash.FieldName = "BillingInvoiceIDHash";
            this.BillingInvoiceIDHash.MinWidth = 27;
            this.BillingInvoiceIDHash.Name = "BillingInvoiceIDHash";
            this.BillingInvoiceIDHash.Width = 112;
            // 
            // dToDate
            // 
            this.dToDate.EditValue = null;
            this.dToDate.Location = new System.Drawing.Point(269, 13);
            this.dToDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dToDate.MinimumSize = new System.Drawing.Size(0, 19);
            this.dToDate.Name = "dToDate";
            this.dToDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dToDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dToDate.Size = new System.Drawing.Size(116, 26);
            this.dToDate.StyleController = this.layoutControl1;
            this.dToDate.TabIndex = 5;
            // 
            // dFromDate
            // 
            this.dFromDate.EditValue = null;
            this.dFromDate.Location = new System.Drawing.Point(85, 13);
            this.dFromDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dFromDate.MinimumSize = new System.Drawing.Size(0, 19);
            this.dFromDate.Name = "dFromDate";
            this.dFromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dFromDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dFromDate.Size = new System.Drawing.Size(103, 26);
            this.dFromDate.StyleController = this.layoutControl1;
            this.dFromDate.TabIndex = 5;
            // 
            // btnRefreshList
            // 
            this.btnRefreshList.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnRefreshList.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnRefreshList.Appearance.Options.UseBackColor = true;
            this.btnRefreshList.Appearance.Options.UseFont = true;
            this.btnRefreshList.Location = new System.Drawing.Point(392, 10);
            this.btnRefreshList.MaximumSize = new System.Drawing.Size(125, 27);
            this.btnRefreshList.MinimumSize = new System.Drawing.Size(125, 27);
            this.btnRefreshList.Name = "btnRefreshList";
            this.btnRefreshList.Size = new System.Drawing.Size(125, 27);
            this.btnRefreshList.StyleController = this.layoutControl1;
            this.btnRefreshList.TabIndex = 15;
            this.btnRefreshList.Text = "Refresh List";
            this.btnRefreshList.Click += new System.EventHandler(this.btnRefreshList_Click);
            // 
            // btnCombineInvoice
            // 
            this.btnCombineInvoice.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning;
            this.btnCombineInvoice.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnCombineInvoice.Appearance.Options.UseBackColor = true;
            this.btnCombineInvoice.Appearance.Options.UseFont = true;
            this.btnCombineInvoice.Location = new System.Drawing.Point(1445, 10);
            this.btnCombineInvoice.MaximumSize = new System.Drawing.Size(125, 27);
            this.btnCombineInvoice.MinimumSize = new System.Drawing.Size(125, 27);
            this.btnCombineInvoice.Name = "btnCombineInvoice";
            this.btnCombineInvoice.Size = new System.Drawing.Size(125, 27);
            this.btnCombineInvoice.StyleController = this.layoutControl1;
            this.btnCombineInvoice.TabIndex = 15;
            this.btnCombineInvoice.Text = "Combine Invoices";
            this.btnCombineInvoice.Click += new System.EventHandler(this.btnCombineInvoice_Click);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlEmail,
            this.layoutControlItem9,
            this.layoutControlCombine,
            this.layoutControlItem4,
            this.emptySpaceItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1710, 726);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.grcBillingInvoiceDetails;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 36);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(1692, 674);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.dFromDate;
            this.layoutControlItem1.CustomizationFormText = "Invoice Date";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(184, 36);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem1.Text = "From Date";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(60, 16);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.dToDate;
            this.layoutControlItem2.CustomizationFormText = "Invoice Date";
            this.layoutControlItem2.Location = new System.Drawing.Point(184, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(197, 36);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem2.Text = "To Date";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(60, 16);
            // 
            // layoutControlEmail
            // 
            this.layoutControlEmail.Control = this.btnEmailSelected;
            this.layoutControlEmail.Location = new System.Drawing.Point(1305, 0);
            this.layoutControlEmail.Name = "layoutControlEmail";
            this.layoutControlEmail.Size = new System.Drawing.Size(129, 36);
            this.layoutControlEmail.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlEmail.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.btnRefreshList;
            this.layoutControlItem9.CustomizationFormText = "layoutControlItem8";
            this.layoutControlItem9.Location = new System.Drawing.Point(381, 0);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(129, 36);
            this.layoutControlItem9.Text = "layoutControlItem8";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // layoutControlCombine
            // 
            this.layoutControlCombine.Control = this.btnCombineInvoice;
            this.layoutControlCombine.CustomizationFormText = "layoutControlItem8";
            this.layoutControlCombine.Location = new System.Drawing.Point(1434, 0);
            this.layoutControlCombine.Name = "layoutControlCombine";
            this.layoutControlCombine.Size = new System.Drawing.Size(129, 36);
            this.layoutControlCombine.Text = "layoutControlItem8";
            this.layoutControlCombine.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlCombine.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnViewDeleted;
            this.layoutControlItem4.Location = new System.Drawing.Point(1563, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(129, 36);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(510, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(795, 36);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frm_AD_BillingInvoiceList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1710, 726);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_AD_BillingInvoiceList";
            this.Text = "Billing Invoice List";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcBillingInvoiceDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBillingInvoiceDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpe_hle_InvoiceID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpe_hle_BillingID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_chk_Attachment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_chk_Confirmed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dToDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dFromDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dFromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlCombine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.DateEdit dToDate;
        private DevExpress.XtraEditors.DateEdit dFromDate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.GridControl grcBillingInvoiceDetails;
        private Common.Controls.WMSGridView grvBillingInvoiceDetails;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPartID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnQty;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnVAT;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnAmount;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnRemark;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnItemdesc;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCustomerNumber;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpe_hle_InvoiceID;
        private DevExpress.XtraEditors.SimpleButton btnEmailSelected;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlEmail;
        private DevExpress.XtraEditors.SimpleButton btnRefreshList;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpe_hle_BillingID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraEditors.SimpleButton btnCombineInvoice;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlCombine;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rpi_chk_Attachment;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rpi_chk_Confirmed;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnInvoiceTo;
        private DevExpress.XtraEditors.SimpleButton btnViewDeleted;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDeleteReason;
        private DevExpress.XtraGrid.Columns.GridColumn BillingInvoiceIDHash;
    }
}