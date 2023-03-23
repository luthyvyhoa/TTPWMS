namespace UI.WarehouseManagement
{
    partial class frm_WM_DispatchingProductPlanned
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_WM_DispatchingProductPlanned));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grcDispatchingCartons = new DevExpress.XtraGrid.GridControl();
            this.grvDispatchingCartons = new Common.Controls.WMSGridView();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdPickPlanListByDateByCustomerID = new DevExpress.XtraGrid.GridControl();
            this.grvPickPlanListByDateByCustomerID = new Common.Controls.WMSGridView();
            this.colProductNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rp_hle_ProductID = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.colProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWeightPerPackage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReceivingOrderNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rp_hle_ReceivingOrderID = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.colReceivingOrderDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPalletRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductionDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUseByDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerRef = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocationNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrentQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rp_hle_PalletInfo = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lke_Customer = new DevExpress.XtraEditors.LookUpEdit();
            this.dateEditReportDate = new DevExpress.XtraEditors.DateEdit();
            this.txtCustomerName = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.LayoutControllke_Customer = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcDispatchingCartons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDispatchingCartons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPickPlanListByDateByCustomerID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPickPlanListByDateByCustomerID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rp_hle_ProductID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rp_hle_ReceivingOrderID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rp_hle_PalletInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lke_Customer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditReportDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditReportDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControllke_Customer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grcDispatchingCartons);
            this.layoutControl1.Controls.Add(this.grdPickPlanListByDateByCustomerID);
            this.layoutControl1.Controls.Add(this.lke_Customer);
            this.layoutControl1.Controls.Add(this.dateEditReportDate);
            this.layoutControl1.Controls.Add(this.txtCustomerName);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1108, 334, 812, 500);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1924, 921);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grcDispatchingCartons
            // 
            this.grcDispatchingCartons.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grcDispatchingCartons.Location = new System.Drawing.Point(1571, 53);
            this.grcDispatchingCartons.MainView = this.grvDispatchingCartons;
            this.grcDispatchingCartons.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grcDispatchingCartons.Name = "grcDispatchingCartons";
            this.grcDispatchingCartons.Size = new System.Drawing.Size(341, 855);
            this.grcDispatchingCartons.TabIndex = 19;
            this.grcDispatchingCartons.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDispatchingCartons});
            // 
            // grvDispatchingCartons
            // 
            this.grvDispatchingCartons.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14});
            this.grvDispatchingCartons.DetailHeight = 437;
            this.grvDispatchingCartons.GridControl = this.grcDispatchingCartons;
            this.grvDispatchingCartons.Name = "grvDispatchingCartons";
            this.grvDispatchingCartons.OptionsView.ShowFooter = true;
            this.grvDispatchingCartons.OptionsView.ShowGroupPanel = false;
            this.grvDispatchingCartons.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvDispatchingCartons.PaintStyleName = "Skin";
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "ID";
            this.gridColumn9.FieldName = "DispatchingCartonID";
            this.gridColumn9.MinWidth = 28;
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "DispatchingCartonID", "{0}")});
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 0;
            this.gridColumn9.Width = 80;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Qty";
            this.gridColumn10.MinWidth = 28;
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 1;
            this.gridColumn10.Width = 55;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Kgs";
            this.gridColumn11.DisplayFormat.FormatString = "n2";
            this.gridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn11.FieldName = "CartonWeight";
            this.gridColumn11.MinWidth = 28;
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CartonWeight", "KG={0:n2}")});
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 2;
            this.gridColumn11.Width = 78;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Remark";
            this.gridColumn12.FieldName = "DispatchingRemark";
            this.gridColumn12.MinWidth = 28;
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 3;
            this.gridColumn12.Width = 118;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "CreateTime";
            this.gridColumn13.FieldName = "CreateTime";
            this.gridColumn13.MinWidth = 28;
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Width = 106;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "CreatedBy";
            this.gridColumn14.FieldName = "CreatedBy";
            this.gridColumn14.MinWidth = 28;
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Width = 106;
            // 
            // grdPickPlanListByDateByCustomerID
            // 
            this.grdPickPlanListByDateByCustomerID.DataMember = "STStockTakeByRequestAllData";
            this.grdPickPlanListByDateByCustomerID.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdPickPlanListByDateByCustomerID.Location = new System.Drawing.Point(12, 53);
            this.grdPickPlanListByDateByCustomerID.MainView = this.grvPickPlanListByDateByCustomerID;
            this.grdPickPlanListByDateByCustomerID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdPickPlanListByDateByCustomerID.Name = "grdPickPlanListByDateByCustomerID";
            this.grdPickPlanListByDateByCustomerID.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rp_hle_ReceivingOrderID,
            this.rp_hle_PalletInfo,
            this.rp_hle_ProductID});
            this.grdPickPlanListByDateByCustomerID.Size = new System.Drawing.Size(1555, 855);
            this.grdPickPlanListByDateByCustomerID.TabIndex = 18;
            this.grdPickPlanListByDateByCustomerID.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvPickPlanListByDateByCustomerID});
            // 
            // grvPickPlanListByDateByCustomerID
            // 
            this.grvPickPlanListByDateByCustomerID.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grvPickPlanListByDateByCustomerID.Appearance.FooterPanel.Options.UseFont = true;
            this.grvPickPlanListByDateByCustomerID.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvPickPlanListByDateByCustomerID.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colProductNumber,
            this.colProductName,
            this.colWeightPerPackage,
            this.colReceivingOrderNumber,
            this.colReceivingOrderDate,
            this.colPalletRemark,
            this.colProductionDate,
            this.colUseByDate,
            this.colCustomerRef,
            this.colLocationNumber,
            this.colCurrentQuantity,
            this.gridColumn1,
            this.gridColumn4,
            this.gridColumn3,
            this.gridColumn2,
            this.gridColumn5,
            this.gridColumn7,
            this.gridColumn6,
            this.gridColumn8});
            this.grvPickPlanListByDateByCustomerID.DetailHeight = 437;
            this.grvPickPlanListByDateByCustomerID.GridControl = this.grdPickPlanListByDateByCustomerID;
            this.grvPickPlanListByDateByCustomerID.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CurrentQuantity", this.colProductNumber, "(C_Qty: SUM={0:0.##})"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AfterDPQuantity", this.colProductNumber, "(ADP_Qty: SUM={0:0.##})")});
            this.grvPickPlanListByDateByCustomerID.Name = "grvPickPlanListByDateByCustomerID";
            this.grvPickPlanListByDateByCustomerID.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvPickPlanListByDateByCustomerID.OptionsSelection.MultiSelect = true;
            this.grvPickPlanListByDateByCustomerID.OptionsView.ShowFooter = true;
            this.grvPickPlanListByDateByCustomerID.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvPickPlanListByDateByCustomerID.PaintStyleName = "Skin";
            this.grvPickPlanListByDateByCustomerID.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvPickPlanListByDateByCustomerID_FocusedRowChanged);
            // 
            // colProductNumber
            // 
            this.colProductNumber.Caption = "ProductID";
            this.colProductNumber.ColumnEdit = this.rp_hle_ProductID;
            this.colProductNumber.FieldName = "ProductNumber";
            this.colProductNumber.MinWidth = 22;
            this.colProductNumber.Name = "colProductNumber";
            this.colProductNumber.Visible = true;
            this.colProductNumber.VisibleIndex = 0;
            this.colProductNumber.Width = 184;
            // 
            // rp_hle_ProductID
            // 
            this.rp_hle_ProductID.AutoHeight = false;
            this.rp_hle_ProductID.Name = "rp_hle_ProductID";
            // 
            // colProductName
            // 
            this.colProductName.Caption = "Product Name";
            this.colProductName.FieldName = "ProductName";
            this.colProductName.MinWidth = 22;
            this.colProductName.Name = "colProductName";
            this.colProductName.Visible = true;
            this.colProductName.VisibleIndex = 1;
            this.colProductName.Width = 475;
            // 
            // colWeightPerPackage
            // 
            this.colWeightPerPackage.Caption = "W/p";
            this.colWeightPerPackage.FieldName = "WeightPerPackage";
            this.colWeightPerPackage.MinWidth = 22;
            this.colWeightPerPackage.Name = "colWeightPerPackage";
            this.colWeightPerPackage.Visible = true;
            this.colWeightPerPackage.VisibleIndex = 2;
            this.colWeightPerPackage.Width = 61;
            // 
            // colReceivingOrderNumber
            // 
            this.colReceivingOrderNumber.Caption = "RO";
            this.colReceivingOrderNumber.ColumnEdit = this.rp_hle_ReceivingOrderID;
            this.colReceivingOrderNumber.FieldName = "ReceivingOrderNumber";
            this.colReceivingOrderNumber.MinWidth = 22;
            this.colReceivingOrderNumber.Name = "colReceivingOrderNumber";
            this.colReceivingOrderNumber.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ReceivingOrderNumber", "Count: {0}")});
            this.colReceivingOrderNumber.Width = 44;
            // 
            // rp_hle_ReceivingOrderID
            // 
            this.rp_hle_ReceivingOrderID.AutoHeight = false;
            this.rp_hle_ReceivingOrderID.Name = "rp_hle_ReceivingOrderID";
            // 
            // colReceivingOrderDate
            // 
            this.colReceivingOrderDate.Caption = "RODate";
            this.colReceivingOrderDate.FieldName = "ReceivingOrderDate";
            this.colReceivingOrderDate.MinWidth = 22;
            this.colReceivingOrderDate.Name = "colReceivingOrderDate";
            this.colReceivingOrderDate.Width = 63;
            // 
            // colPalletRemark
            // 
            this.colPalletRemark.Caption = "Pallet Remark";
            this.colPalletRemark.FieldName = "PalletRemark";
            this.colPalletRemark.MinWidth = 22;
            this.colPalletRemark.Name = "colPalletRemark";
            this.colPalletRemark.Visible = true;
            this.colPalletRemark.VisibleIndex = 7;
            this.colPalletRemark.Width = 98;
            // 
            // colProductionDate
            // 
            this.colProductionDate.Caption = "PRO.DATE";
            this.colProductionDate.FieldName = "ProductionDate";
            this.colProductionDate.MinWidth = 22;
            this.colProductionDate.Name = "colProductionDate";
            this.colProductionDate.Visible = true;
            this.colProductionDate.VisibleIndex = 3;
            this.colProductionDate.Width = 83;
            // 
            // colUseByDate
            // 
            this.colUseByDate.Caption = "EXP.DATE";
            this.colUseByDate.FieldName = "UseByDate";
            this.colUseByDate.MinWidth = 22;
            this.colUseByDate.Name = "colUseByDate";
            this.colUseByDate.Visible = true;
            this.colUseByDate.VisibleIndex = 4;
            this.colUseByDate.Width = 101;
            // 
            // colCustomerRef
            // 
            this.colCustomerRef.Caption = "REF";
            this.colCustomerRef.FieldName = "CustomerRef";
            this.colCustomerRef.MinWidth = 22;
            this.colCustomerRef.Name = "colCustomerRef";
            this.colCustomerRef.Visible = true;
            this.colCustomerRef.VisibleIndex = 5;
            this.colCustomerRef.Width = 124;
            // 
            // colLocationNumber
            // 
            this.colLocationNumber.Caption = "Location";
            this.colLocationNumber.FieldName = "LocationNumber";
            this.colLocationNumber.MinWidth = 22;
            this.colLocationNumber.Name = "colLocationNumber";
            this.colLocationNumber.Visible = true;
            this.colLocationNumber.VisibleIndex = 6;
            this.colLocationNumber.Width = 116;
            // 
            // colCurrentQuantity
            // 
            this.colCurrentQuantity.Caption = "P.Qty";
            this.colCurrentQuantity.FieldName = "PlannedTotalPackages";
            this.colCurrentQuantity.MinWidth = 22;
            this.colCurrentQuantity.Name = "colCurrentQuantity";
            this.colCurrentQuantity.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CurrentQuantity", "SUM={0:0.##}")});
            this.colCurrentQuantity.Visible = true;
            this.colCurrentQuantity.VisibleIndex = 9;
            this.colCurrentQuantity.Width = 62;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "P.Kgs";
            this.gridColumn1.DisplayFormat.FormatString = "n2";
            this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn1.FieldName = "PlannedTotalWeight";
            this.gridColumn1.MinWidth = 28;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 10;
            this.gridColumn1.Width = 65;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "A.Qty";
            this.gridColumn4.FieldName = "TotalPackages";
            this.gridColumn4.MinWidth = 28;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 11;
            this.gridColumn4.Width = 67;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "A.Kgs";
            this.gridColumn3.DisplayFormat.FormatString = "n2";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn3.FieldName = "TotalWeight";
            this.gridColumn3.MinWidth = 28;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 12;
            this.gridColumn3.Width = 90;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "PalletID";
            this.gridColumn2.ColumnEdit = this.rp_hle_PalletInfo;
            this.gridColumn2.FieldName = "PalletID";
            this.gridColumn2.MinWidth = 22;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 8;
            this.gridColumn2.Width = 78;
            // 
            // rp_hle_PalletInfo
            // 
            this.rp_hle_PalletInfo.AutoHeight = false;
            this.rp_hle_PalletInfo.Name = "rp_hle_PalletInfo";
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "ProductID";
            this.gridColumn5.FieldName = "ProductID";
            this.gridColumn5.MinWidth = 22;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Width = 84;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Createdtime";
            this.gridColumn7.FieldName = "CreatedTime";
            this.gridColumn7.MinWidth = 22;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Width = 84;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "UpdateTime";
            this.gridColumn6.FieldName = "UpdateTime";
            this.gridColumn6.MinWidth = 28;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Width = 106;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Update By";
            this.gridColumn8.FieldName = "UpdateBy";
            this.gridColumn8.MinWidth = 28;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Width = 106;
            // 
            // lke_Customer
            // 
            this.lke_Customer.Location = new System.Drawing.Point(112, 15);
            this.lke_Customer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lke_Customer.MinimumSize = new System.Drawing.Size(0, 30);
            this.lke_Customer.Name = "lke_Customer";
            this.lke_Customer.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lke_Customer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lke_Customer.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerID", "CustomerID", 22, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerNumber", "Customer ID", 51, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerName", "Customer Name", 225, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lke_Customer.Properties.DisplayMember = "CustomerID";
            this.lke_Customer.Properties.DropDownRows = 20;
            this.lke_Customer.Properties.NullText = "";
            this.lke_Customer.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.StartsWith;
            this.lke_Customer.Properties.PopupWidth = 55;
            this.lke_Customer.Properties.ShowFooter = false;
            this.lke_Customer.Properties.ShowHeader = false;
            this.lke_Customer.Properties.ValueMember = "CustomerNumber";
            this.lke_Customer.Size = new System.Drawing.Size(141, 32);
            this.lke_Customer.StyleController = this.layoutControl1;
            this.lke_Customer.TabIndex = 13;
            this.lke_Customer.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(this.lke_Customer_CloseUp);
            // 
            // dateEditReportDate
            // 
            this.dateEditReportDate.EditValue = null;
            this.dateEditReportDate.Location = new System.Drawing.Point(941, 15);
            this.dateEditReportDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateEditReportDate.MinimumSize = new System.Drawing.Size(0, 30);
            this.dateEditReportDate.Name = "dateEditReportDate";
            this.dateEditReportDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditReportDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditReportDate.Size = new System.Drawing.Size(133, 32);
            this.dateEditReportDate.StyleController = this.layoutControl1;
            this.dateEditReportDate.TabIndex = 14;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(260, 13);
            this.txtCustomerName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCustomerName.MinimumSize = new System.Drawing.Size(0, 30);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Properties.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(576, 32);
            this.txtCustomerName.StyleController = this.layoutControl1;
            this.txtCustomerName.TabIndex = 17;
            this.txtCustomerName.TabStop = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.LayoutControllke_Customer,
            this.layoutControlItem2,
            this.layoutControlItem7,
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem3});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1924, 921);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // LayoutControllke_Customer
            // 
            this.LayoutControllke_Customer.Control = this.lke_Customer;
            this.LayoutControllke_Customer.CustomizationFormText = "Customer";
            this.LayoutControllke_Customer.Location = new System.Drawing.Point(0, 0);
            this.LayoutControllke_Customer.Name = "LayoutControllke_Customer";
            this.LayoutControllke_Customer.Size = new System.Drawing.Size(247, 40);
            this.LayoutControllke_Customer.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.LayoutControllke_Customer.Text = "Customer";
            this.LayoutControllke_Customer.TextSize = new System.Drawing.Size(84, 19);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.dateEditReportDate;
            this.layoutControlItem2.CustomizationFormText = "Report Date";
            this.layoutControlItem2.Location = new System.Drawing.Point(829, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(239, 40);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem2.Text = "Report Date";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(84, 19);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.txtCustomerName;
            this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
            this.layoutControlItem7.Location = new System.Drawing.Point(247, 0);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 2, 2);
            this.layoutControlItem7.Size = new System.Drawing.Size(582, 40);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdPickPlanListByDateByCustomerID;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 40);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1559, 859);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(1068, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(836, 40);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.grcDispatchingCartons;
            this.layoutControlItem3.Location = new System.Drawing.Point(1559, 40);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(345, 859);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // frm_WM_DispatchingProductPlanned
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 921);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_WM_DispatchingProductPlanned";
            this.Text = "Planned Dispatching Products";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcDispatchingCartons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDispatchingCartons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPickPlanListByDateByCustomerID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPickPlanListByDateByCustomerID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rp_hle_ProductID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rp_hle_ReceivingOrderID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rp_hle_PalletInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lke_Customer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditReportDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditReportDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControllke_Customer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.LookUpEdit lke_Customer;
        private DevExpress.XtraEditors.DateEdit dateEditReportDate;
        private DevExpress.XtraEditors.TextEdit txtCustomerName;
        private DevExpress.XtraLayout.LayoutControlItem LayoutControllke_Customer;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraGrid.GridControl grdPickPlanListByDateByCustomerID;
        private Common.Controls.WMSGridView grvPickPlanListByDateByCustomerID;
        private DevExpress.XtraGrid.Columns.GridColumn colReceivingOrderNumber;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rp_hle_ReceivingOrderID;
        private DevExpress.XtraGrid.Columns.GridColumn colReceivingOrderDate;
        private DevExpress.XtraGrid.Columns.GridColumn colProductNumber;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rp_hle_ProductID;
        private DevExpress.XtraGrid.Columns.GridColumn colProductName;
        private DevExpress.XtraGrid.Columns.GridColumn colWeightPerPackage;
        private DevExpress.XtraGrid.Columns.GridColumn colProductionDate;
        private DevExpress.XtraGrid.Columns.GridColumn colUseByDate;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerRef;
        private DevExpress.XtraGrid.Columns.GridColumn colLocationNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrentQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colPalletRemark;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rp_hle_PalletInfo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.GridControl grcDispatchingCartons;
        private Common.Controls.WMSGridView grvDispatchingCartons;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}