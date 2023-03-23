namespace UI.CRM
{
    partial class frm_CRM_BillingInvoiceContractCheck
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_CRM_BillingInvoiceContractCheck));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnCheckSolomonAll = new DevExpress.XtraEditors.SimpleButton();
            this.checkAllActiveCustomers = new DevExpress.XtraEditors.CheckEdit();
            this.grcActiveBillingInvoices = new DevExpress.XtraGrid.GridControl();
            this.grvActiveBillingInvoices = new Common.Controls.WMSGridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpe_BillingID = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpe_ContractID = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpe_chck_IsAttachment = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.lke_OperatingCostMonthlyID = new DevExpress.XtraEditors.LookUpEdit();
            this.lke_MSS_StoreList = new DevExpress.XtraEditors.LookUpEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkAllActiveCustomers.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcActiveBillingInvoices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvActiveBillingInvoices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpe_BillingID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpe_ContractID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpe_chck_IsAttachment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lke_OperatingCostMonthlyID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lke_MSS_StoreList.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnCheckSolomonAll);
            this.layoutControl1.Controls.Add(this.checkAllActiveCustomers);
            this.layoutControl1.Controls.Add(this.grcActiveBillingInvoices);
            this.layoutControl1.Controls.Add(this.lke_OperatingCostMonthlyID);
            this.layoutControl1.Controls.Add(this.lke_MSS_StoreList);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(959, 466, 812, 500);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1914, 928);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnCheckSolomonAll
            // 
            this.btnCheckSolomonAll.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnCheckSolomonAll.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnCheckSolomonAll.Appearance.Options.UseBackColor = true;
            this.btnCheckSolomonAll.Appearance.Options.UseFont = true;
            this.btnCheckSolomonAll.Location = new System.Drawing.Point(1735, 13);
            this.btnCheckSolomonAll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCheckSolomonAll.Name = "btnCheckSolomonAll";
            this.btnCheckSolomonAll.Size = new System.Drawing.Size(167, 32);
            this.btnCheckSolomonAll.StyleController = this.layoutControl1;
            this.btnCheckSolomonAll.TabIndex = 6;
            this.btnCheckSolomonAll.Text = "Solomon Check";
            this.btnCheckSolomonAll.Click += new System.EventHandler(this.btnCheckSolomonAll_Click);
            // 
            // checkAllActiveCustomers
            // 
            this.checkAllActiveCustomers.Location = new System.Drawing.Point(1502, 15);
            this.checkAllActiveCustomers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkAllActiveCustomers.Name = "checkAllActiveCustomers";
            this.checkAllActiveCustomers.Properties.Caption = "Show All Active Customers";
            this.checkAllActiveCustomers.Size = new System.Drawing.Size(228, 28);
            this.checkAllActiveCustomers.StyleController = this.layoutControl1;
            this.checkAllActiveCustomers.TabIndex = 5;
            this.checkAllActiveCustomers.CheckedChanged += new System.EventHandler(this.checkAllActiveCustomers_CheckedChanged);
            // 
            // grcActiveBillingInvoices
            // 
            this.grcActiveBillingInvoices.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grcActiveBillingInvoices.Location = new System.Drawing.Point(12, 58);
            this.grcActiveBillingInvoices.MainView = this.grvActiveBillingInvoices;
            this.grcActiveBillingInvoices.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grcActiveBillingInvoices.Name = "grcActiveBillingInvoices";
            this.grcActiveBillingInvoices.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpe_BillingID,
            this.rpe_ContractID,
            this.rpe_chck_IsAttachment});
            this.grcActiveBillingInvoices.Size = new System.Drawing.Size(1890, 857);
            this.grcActiveBillingInvoices.TabIndex = 4;
            this.grcActiveBillingInvoices.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvActiveBillingInvoices});
            // 
            // grvActiveBillingInvoices
            // 
            this.grvActiveBillingInvoices.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn16,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn2,
            this.gridColumn15});
            this.grvActiveBillingInvoices.DetailHeight = 437;
            this.grvActiveBillingInvoices.GridControl = this.grcActiveBillingInvoices;
            this.grvActiveBillingInvoices.Name = "grvActiveBillingInvoices";
            this.grvActiveBillingInvoices.OptionsView.ShowGroupPanel = false;
            this.grvActiveBillingInvoices.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvActiveBillingInvoices.PaintStyleName = "Skin";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "BILL ID";
            this.gridColumn1.ColumnEdit = this.rpe_BillingID;
            this.gridColumn1.FieldName = "BillingID";
            this.gridColumn1.MinWidth = 28;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 82;
            // 
            // rpe_BillingID
            // 
            this.rpe_BillingID.AutoHeight = false;
            this.rpe_BillingID.Name = "rpe_BillingID";
            this.rpe_BillingID.Click += new System.EventHandler(this.rpe_BillingID_Click);
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "From";
            this.gridColumn3.DisplayFormat.FormatString = "d";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn3.FieldName = "BillingFromDate";
            this.gridColumn3.MinWidth = 28;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 109;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "To";
            this.gridColumn4.DisplayFormat.FormatString = "d";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn4.FieldName = "BillingToDate";
            this.gridColumn4.MinWidth = 28;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 111;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "X";
            this.gridColumn5.FieldName = "Confirmed";
            this.gridColumn5.MinWidth = 28;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 28;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Invoice Remark";
            this.gridColumn6.FieldName = "InvoiceRemark";
            this.gridColumn6.MinWidth = 28;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 6;
            this.gridColumn6.Width = 166;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "I.Date";
            this.gridColumn7.FieldName = "InvoiceDate";
            this.gridColumn7.MinWidth = 28;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 4;
            this.gridColumn7.Width = 87;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "In.By";
            this.gridColumn8.FieldName = "InvoiceInputBy";
            this.gridColumn8.MinWidth = 28;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 5;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Customer";
            this.gridColumn9.FieldName = "CustomerNumber";
            this.gridColumn9.MinWidth = 28;
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 7;
            this.gridColumn9.Width = 109;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Customer Name";
            this.gridColumn10.FieldName = "CustomerName";
            this.gridColumn10.MinWidth = 28;
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 8;
            this.gridColumn10.Width = 364;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Contract No.";
            this.gridColumn11.ColumnEdit = this.rpe_ContractID;
            this.gridColumn11.FieldName = "ContractNumber";
            this.gridColumn11.MinWidth = 28;
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 9;
            this.gridColumn11.Width = 157;
            // 
            // rpe_ContractID
            // 
            this.rpe_ContractID.AutoHeight = false;
            this.rpe_ContractID.Name = "rpe_ContractID";
            this.rpe_ContractID.Click += new System.EventHandler(this.rpe_ContractID_Click);
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "APX";
            this.gridColumn16.FieldName = "Appendix";
            this.gridColumn16.MinWidth = 28;
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 10;
            this.gridColumn16.Width = 39;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "C. Status";
            this.gridColumn12.FieldName = "ConstractStatusDescriptions";
            this.gridColumn12.MinWidth = 28;
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 11;
            this.gridColumn12.Width = 307;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "BD Staff";
            this.gridColumn13.FieldName = "EnglishName";
            this.gridColumn13.MinWidth = 28;
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 12;
            this.gridColumn13.Width = 163;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Created Time";
            this.gridColumn14.FieldName = "BillingCreatedTime";
            this.gridColumn14.MinWidth = 28;
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Width = 105;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "CustomerID";
            this.gridColumn2.FieldName = "CustomerID";
            this.gridColumn2.MinWidth = 28;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Width = 105;
            // 
            // gridColumn15
            // 
            this.gridColumn15.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn15.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn15.Caption = " ";
            this.gridColumn15.ColumnEdit = this.rpe_chck_IsAttachment;
            this.gridColumn15.FieldName = "isContractAttached";
            this.gridColumn15.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("gridColumn15.ImageOptions.Image")));
            this.gridColumn15.MinWidth = 28;
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 13;
            this.gridColumn15.Width = 36;
            // 
            // rpe_chck_IsAttachment
            // 
            this.rpe_chck_IsAttachment.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.rpe_chck_IsAttachment.ImageOptions.ImageChecked = ((System.Drawing.Image)(resources.GetObject("rpe_chck_IsAttachment.ImageOptions.ImageChecked")));
            this.rpe_chck_IsAttachment.Name = "rpe_chck_IsAttachment";
            this.rpe_chck_IsAttachment.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // lke_OperatingCostMonthlyID
            // 
            this.lke_OperatingCostMonthlyID.Location = new System.Drawing.Point(114, 15);
            this.lke_OperatingCostMonthlyID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lke_OperatingCostMonthlyID.MaximumSize = new System.Drawing.Size(0, 37);
            this.lke_OperatingCostMonthlyID.MinimumSize = new System.Drawing.Size(0, 37);
            this.lke_OperatingCostMonthlyID.Name = "lke_OperatingCostMonthlyID";
            this.lke_OperatingCostMonthlyID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lke_OperatingCostMonthlyID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("OperatingCostMonthlyID", "OperatingCostMonthlyID", 30, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MonthDescription", "Month", 30, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lke_OperatingCostMonthlyID.Properties.NullText = "";
            this.lke_OperatingCostMonthlyID.Size = new System.Drawing.Size(149, 37);
            this.lke_OperatingCostMonthlyID.StyleController = this.layoutControl1;
            this.lke_OperatingCostMonthlyID.TabIndex = 0;
            this.lke_OperatingCostMonthlyID.EditValueChanged += new System.EventHandler(this.lke_OperatingCostMonthlyID_EditValueChanged);
            // 
            // lke_MSS_StoreList
            // 
            this.lke_MSS_StoreList.Location = new System.Drawing.Point(352, 15);
            this.lke_MSS_StoreList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lke_MSS_StoreList.MaximumSize = new System.Drawing.Size(0, 37);
            this.lke_MSS_StoreList.MinimumSize = new System.Drawing.Size(0, 37);
            this.lke_MSS_StoreList.Name = "lke_MSS_StoreList";
            this.lke_MSS_StoreList.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lke_MSS_StoreList.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lke_MSS_StoreList.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StoreID", "StoreID", 30, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StoreDescription", "StoreDescription", 30, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lke_MSS_StoreList.Properties.NullText = "";
            this.lke_MSS_StoreList.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.StartsWith;
            this.lke_MSS_StoreList.Properties.ShowFooter = false;
            this.lke_MSS_StoreList.Properties.ShowHeader = false;
            this.lke_MSS_StoreList.Size = new System.Drawing.Size(180, 37);
            this.lke_MSS_StoreList.StyleController = this.layoutControl1;
            this.lke_MSS_StoreList.TabIndex = 1;
            this.lke_MSS_StoreList.EditValueChanged += new System.EventHandler(this.lke_MSS_StoreList_EditValueChanged);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem8,
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.layoutControlItem4});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1914, 928);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grcActiveBillingInvoices;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 45);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1894, 861);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.lke_OperatingCostMonthlyID;
            this.layoutControlItem3.CustomizationFormText = "Report Month";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(256, 45);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem3.Text = "Report Month";
            this.layoutControlItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(96, 19);
            this.layoutControlItem3.TextToControlDistance = 5;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.lke_MSS_StoreList;
            this.layoutControlItem8.CustomizationFormText = "Store:";
            this.layoutControlItem8.Location = new System.Drawing.Point(256, 0);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(269, 45);
            this.layoutControlItem8.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem8.Text = "Store:";
            this.layoutControlItem8.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem8.TextSize = new System.Drawing.Size(78, 21);
            this.layoutControlItem8.TextToControlDistance = 5;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(525, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(964, 45);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.checkAllActiveCustomers;
            this.layoutControlItem2.Location = new System.Drawing.Point(1489, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(234, 45);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnCheckSolomonAll;
            this.layoutControlItem4.Location = new System.Drawing.Point(1723, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(171, 45);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // frm_CRM_BillingInvoiceContractCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1914, 928);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frm_CRM_BillingInvoiceContractCheck";
            this.Text = "Billing Invoice Contract Check";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkAllActiveCustomers.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcActiveBillingInvoices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvActiveBillingInvoices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpe_BillingID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpe_ContractID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpe_chck_IsAttachment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lke_OperatingCostMonthlyID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lke_MSS_StoreList.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraGrid.GridControl grcActiveBillingInvoices;
        private Common.Controls.WMSGridView grvActiveBillingInvoices;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.LookUpEdit lke_OperatingCostMonthlyID;
        private DevExpress.XtraEditors.LookUpEdit lke_MSS_StoreList;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpe_BillingID;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpe_ContractID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.CheckEdit checkAllActiveCustomers;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SimpleButton btnCheckSolomonAll;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rpe_chck_IsAttachment;
    }
}