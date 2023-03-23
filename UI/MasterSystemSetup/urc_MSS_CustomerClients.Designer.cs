namespace UI.MasterSystemSetup
{
    partial class urc_MSS_CustomerClients
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grdClients = new DevExpress.XtraGrid.GridControl();
            this.grvClients = new Common.Controls.WMSGridView();
            this.grcCustomerClientCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerClientName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerClientEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerClientContacts = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerClientAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerClientPhone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerClientID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_lke_DefaultRoute = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_lke_Districts = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_lke_DispartchingMethod = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_btn_RuleExpand = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.btnImport = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdClients)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvClients)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_DefaultRoute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_Districts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_DispartchingMethod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_btn_RuleExpand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grdClients);
            this.layoutControl1.Controls.Add(this.btnImport);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(884, -952, 812, 500);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1722, 446);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grdClients
            // 
            this.grdClients.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.grdClients.Location = new System.Drawing.Point(12, 12);
            this.grdClients.MainView = this.grvClients;
            this.grdClients.Margin = new System.Windows.Forms.Padding(4);
            this.grdClients.Name = "grdClients";
            this.grdClients.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpi_lke_Districts,
            this.rpi_lke_DispartchingMethod,
            this.rpi_lke_DefaultRoute,
            this.rpi_btn_RuleExpand});
            this.grdClients.Size = new System.Drawing.Size(1698, 383);
            this.grdClients.TabIndex = 4;
            this.grdClients.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvClients});
            // 
            // grvClients
            // 
            this.grvClients.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grvClients.Appearance.FooterPanel.Options.UseFont = true;
            this.grvClients.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvClients.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grcCustomerClientCode,
            this.grcCustomerClientName,
            this.grcCustomerClientEmail,
            this.grcCustomerClientContacts,
            this.grcCustomerClientAddress,
            this.grcCustomerClientPhone,
            this.grcCustomerClientID,
            this.grcCustomerID,
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
            this.gridColumn17});
            this.grvClients.GridControl = this.grdClients;
            this.grvClients.Name = "grvClients";
            this.grvClients.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grvClients.OptionsSelection.MultiSelect = true;
            this.grvClients.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvClients.OptionsView.ShowGroupPanel = false;
            this.grvClients.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvClients.PaintStyleName = "Skin";
            this.grvClients.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvClients_CellValueChanged);
            this.grvClients.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.grvClients_RowUpdated);
            this.grvClients.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvClients_KeyDown);
            // 
            // grcCustomerClientCode
            // 
            this.grcCustomerClientCode.Caption = "CODE";
            this.grcCustomerClientCode.FieldName = "CustomerClientCode";
            this.grcCustomerClientCode.Name = "grcCustomerClientCode";
            this.grcCustomerClientCode.Visible = true;
            this.grcCustomerClientCode.VisibleIndex = 0;
            this.grcCustomerClientCode.Width = 33;
            // 
            // grcCustomerClientName
            // 
            this.grcCustomerClientName.Caption = "NAME";
            this.grcCustomerClientName.FieldName = "CustomerClientName";
            this.grcCustomerClientName.Name = "grcCustomerClientName";
            this.grcCustomerClientName.Visible = true;
            this.grcCustomerClientName.VisibleIndex = 1;
            this.grcCustomerClientName.Width = 143;
            // 
            // grcCustomerClientEmail
            // 
            this.grcCustomerClientEmail.Caption = "EMAIL";
            this.grcCustomerClientEmail.FieldName = "CustomerClientEmail";
            this.grcCustomerClientEmail.Name = "grcCustomerClientEmail";
            this.grcCustomerClientEmail.Visible = true;
            this.grcCustomerClientEmail.VisibleIndex = 2;
            this.grcCustomerClientEmail.Width = 41;
            // 
            // grcCustomerClientContacts
            // 
            this.grcCustomerClientContacts.Caption = "CONTACTS";
            this.grcCustomerClientContacts.FieldName = "CustomerClientContacts";
            this.grcCustomerClientContacts.Name = "grcCustomerClientContacts";
            this.grcCustomerClientContacts.Visible = true;
            this.grcCustomerClientContacts.VisibleIndex = 3;
            this.grcCustomerClientContacts.Width = 76;
            // 
            // grcCustomerClientAddress
            // 
            this.grcCustomerClientAddress.Caption = "ADDRESS";
            this.grcCustomerClientAddress.FieldName = "CustomerClientAddress";
            this.grcCustomerClientAddress.Name = "grcCustomerClientAddress";
            this.grcCustomerClientAddress.Visible = true;
            this.grcCustomerClientAddress.VisibleIndex = 4;
            this.grcCustomerClientAddress.Width = 187;
            // 
            // grcCustomerClientPhone
            // 
            this.grcCustomerClientPhone.Caption = "PHONE";
            this.grcCustomerClientPhone.FieldName = "CustomerClientPhone";
            this.grcCustomerClientPhone.Name = "grcCustomerClientPhone";
            this.grcCustomerClientPhone.Visible = true;
            this.grcCustomerClientPhone.VisibleIndex = 5;
            this.grcCustomerClientPhone.Width = 58;
            // 
            // grcCustomerClientID
            // 
            this.grcCustomerClientID.Caption = "CLIENT ID";
            this.grcCustomerClientID.FieldName = "CustomerClientID";
            this.grcCustomerClientID.Name = "grcCustomerClientID";
            // 
            // grcCustomerID
            // 
            this.grcCustomerID.Caption = "CUSTOMER ID";
            this.grcCustomerID.FieldName = "CustomerID";
            this.grcCustomerID.Name = "grcCustomerID";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Credit Term";
            this.gridColumn1.FieldName = "CustomerClientCreditTerm";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 6;
            this.gridColumn1.Width = 58;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Self Life";
            this.gridColumn2.FieldName = "Shelflife";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 7;
            this.gridColumn2.Width = 38;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Dead Line";
            this.gridColumn3.FieldName = "DeadlineNumber";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 8;
            this.gridColumn3.Width = 45;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Route";
            this.gridColumn4.ColumnEdit = this.rpi_lke_DefaultRoute;
            this.gridColumn4.FieldName = "DefaultRoute";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 9;
            this.gridColumn4.Width = 63;
            // 
            // rpi_lke_DefaultRoute
            // 
            this.rpi_lke_DefaultRoute.AutoHeight = false;
            this.rpi_lke_DefaultRoute.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.rpi_lke_DefaultRoute.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpi_lke_DefaultRoute.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerDeliveryRouteID", "Name3", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RouteCode", "RouteCode"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RouteDescriptions", "RouteDescriptions")});
            this.rpi_lke_DefaultRoute.DropDownRows = 20;
            this.rpi_lke_DefaultRoute.Name = "rpi_lke_DefaultRoute";
            this.rpi_lke_DefaultRoute.NullText = "";
            this.rpi_lke_DefaultRoute.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.rpi_lke_DefaultRoute.PopupWidthMode = DevExpress.XtraEditors.PopupWidthMode.UseEditorWidth;
            this.rpi_lke_DefaultRoute.ShowFooter = false;
            this.rpi_lke_DefaultRoute.ShowHeader = false;
            this.rpi_lke_DefaultRoute.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "District";
            this.gridColumn5.ColumnEdit = this.rpi_lke_Districts;
            this.gridColumn5.FieldName = "AddressDistrict";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 10;
            this.gridColumn5.Width = 139;
            // 
            // rpi_lke_Districts
            // 
            this.rpi_lke_Districts.AutoHeight = false;
            this.rpi_lke_Districts.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.rpi_lke_Districts.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpi_lke_Districts.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerClientAddressDistrictID", "CustomerClientAddressDistrictID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DistrictName", "District Name"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerClientAddressProvinceID", "CustomerClientAddressProvinceID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.rpi_lke_Districts.DropDownRows = 20;
            this.rpi_lke_Districts.Name = "rpi_lke_Districts";
            this.rpi_lke_Districts.NullText = "";
            this.rpi_lke_Districts.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.rpi_lke_Districts.PopupWidthMode = DevExpress.XtraEditors.PopupWidthMode.ContentWidth;
            this.rpi_lke_Districts.ShowFooter = false;
            this.rpi_lke_Districts.ShowHeader = false;
            this.rpi_lke_Districts.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Map";
            this.gridColumn6.FieldName = "AddressMapCoordinates";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 11;
            this.gridColumn6.Width = 36;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "D.Remark";
            this.gridColumn7.FieldName = "ClientDeliveryRemark";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 12;
            this.gridColumn7.Width = 65;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "DelType";
            this.gridColumn8.FieldName = "DeliveryType";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 13;
            this.gridColumn8.Width = 52;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "PayMethod";
            this.gridColumn9.FieldName = "ClientPaymentMethod";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 14;
            this.gridColumn9.Width = 52;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "G.Name";
            this.gridColumn10.FieldName = "ClientGroupName";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 15;
            this.gridColumn10.Width = 69;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Disp.Rule";
            this.gridColumn11.ColumnEdit = this.rpi_lke_DispartchingMethod;
            this.gridColumn11.FieldName = "DispatchingMethodID";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 16;
            this.gridColumn11.Width = 109;
            // 
            // rpi_lke_DispartchingMethod
            // 
            this.rpi_lke_DispartchingMethod.AutoHeight = false;
            this.rpi_lke_DispartchingMethod.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.rpi_lke_DispartchingMethod.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpi_lke_DispartchingMethod.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerDispatchMethodID", "CustomerDispatchMethodID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Method", "Method")});
            this.rpi_lke_DispartchingMethod.Name = "rpi_lke_DispartchingMethod";
            this.rpi_lke_DispartchingMethod.NullText = "";
            this.rpi_lke_DispartchingMethod.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.rpi_lke_DispartchingMethod.PopupWidthMode = DevExpress.XtraEditors.PopupWidthMode.ContentWidth;
            this.rpi_lke_DispartchingMethod.ShowFooter = false;
            this.rpi_lke_DispartchingMethod.ShowHeader = false;
            this.rpi_lke_DispartchingMethod.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Province";
            this.gridColumn12.FieldName = "AddressProvince";
            this.gridColumn12.MinWidth = 25;
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 18;
            this.gridColumn12.Width = 130;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Z";
            this.gridColumn13.FieldName = "ClientAddressZone";
            this.gridColumn13.MinWidth = 25;
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 19;
            this.gridColumn13.Width = 38;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Client Main";
            this.gridColumn14.FieldName = "CustomerClientMain";
            this.gridColumn14.MinWidth = 25;
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 20;
            this.gridColumn14.Width = 73;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Client Tax Code";
            this.gridColumn15.FieldName = "CustomerClientTaxCode";
            this.gridColumn15.MinWidth = 25;
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 21;
            this.gridColumn15.Width = 73;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Delivery Address";
            this.gridColumn16.FieldName = "CustomerClientDeliveryAddress";
            this.gridColumn16.MinWidth = 25;
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 22;
            this.gridColumn16.Width = 88;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "Cấp Độ";
            this.gridColumn17.MinWidth = 25;
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.ToolTip = "0: Đủ hàng,1: Thiếu củng được, 2 : không quan trọng";
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 17;
            this.gridColumn17.Width = 94;
            // 
            // rpi_btn_RuleExpand
            // 
            this.rpi_btn_RuleExpand.Name = "rpi_btn_RuleExpand";
            // 
            // btnImport
            // 
            this.btnImport.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Question;
            this.btnImport.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnImport.Appearance.Options.UseBackColor = true;
            this.btnImport.Appearance.Options.UseFont = true;
            this.btnImport.Location = new System.Drawing.Point(1583, 401);
            this.btnImport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnImport.MaximumSize = new System.Drawing.Size(125, 31);
            this.btnImport.MinimumSize = new System.Drawing.Size(125, 31);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(125, 31);
            this.btnImport.StyleController = this.layoutControl1;
            this.btnImport.TabIndex = 41;
            this.btnImport.Text = "Import";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem8,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1722, 446);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdClients;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1702, 387);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.btnImport;
            this.layoutControlItem8.CustomizationFormText = " ";
            this.layoutControlItem8.Location = new System.Drawing.Point(1553, 387);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(149, 39);
            this.layoutControlItem8.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem8.Text = " ";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(4, 16);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 387);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(1553, 39);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // urc_MSS_CustomerClients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "urc_MSS_CustomerClients";
            this.Size = new System.Drawing.Size(1722, 446);
            this.Load += new System.EventHandler(this.urc_MSS_CustomerClients_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdClients)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvClients)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_DefaultRoute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_Districts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_DispartchingMethod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_btn_RuleExpand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl grdClients;
        private Common.Controls.WMSGridView grvClients;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerClientCode;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerClientName;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerClientEmail;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerClientContacts;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerClientAddress;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerClientPhone;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerClientID;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpi_lke_Districts;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpi_lke_DispartchingMethod;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpi_lke_DefaultRoute;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraEditors.SimpleButton btnImport;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rpi_btn_RuleExpand;
    }
}
