namespace UI.WarehouseManagement
{
    partial class frm_WM_Dialog_DispatchingOrderDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_WM_Dialog_DispatchingOrderDetails));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grdDispatchedDetail = new DevExpress.XtraGrid.GridControl();
            this.grvDispatchedDetail = new Common.Controls.WMSGridView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcOrderDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcOrderNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemHyperLinkEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.grcOriginalQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcReceivedQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemHyperLinkEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.grcCustomerRef = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcVehicle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcProductionDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcUseByDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDispatchedDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDispatchedDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grdDispatchedDetail);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1876, 984);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grdDispatchedDetail
            // 
            this.grdDispatchedDetail.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdDispatchedDetail.Location = new System.Drawing.Point(12, 13);
            this.grdDispatchedDetail.MainView = this.grvDispatchedDetail;
            this.grdDispatchedDetail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdDispatchedDetail.Name = "grdDispatchedDetail";
            this.grdDispatchedDetail.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemHyperLinkEdit1,
            this.repositoryItemHyperLinkEdit2});
            this.grdDispatchedDetail.Size = new System.Drawing.Size(1852, 958);
            this.grdDispatchedDetail.TabIndex = 5;
            this.grdDispatchedDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDispatchedDetail});
            // 
            // grvDispatchedDetail
            // 
            this.grvDispatchedDetail.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grvDispatchedDetail.Appearance.FooterPanel.Options.UseFont = true;
            this.grvDispatchedDetail.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvDispatchedDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn4,
            this.gridColumn3,
            this.gridColumn2,
            this.gridColumn1,
            this.gridColumn7,
            this.gridColumn6,
            this.gridColumn9,
            this.gridColumn5,
            this.gridColumn8,
            this.grcOrderDate,
            this.grcOrderNumber,
            this.grcOriginalQty,
            this.grcReceivedQty,
            this.grcCustomerRef,
            this.grcRemark,
            this.gridColumn16,
            this.gridColumn15,
            this.grcVehicle,
            this.grcProductionDate,
            this.grcUseByDate,
            this.gridColumn14,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn13,
            this.gridColumn12,
            this.gridColumn17});
            this.grvDispatchedDetail.DetailHeight = 437;
            this.grvDispatchedDetail.GridControl = this.grdDispatchedDetail;
            this.grvDispatchedDetail.GroupCount = 1;
            this.grvDispatchedDetail.Name = "grvDispatchedDetail";
            this.grvDispatchedDetail.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvDispatchedDetail.OptionsBehavior.ReadOnly = true;
            this.grvDispatchedDetail.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grvDispatchedDetail.OptionsFind.AlwaysVisible = true;
            this.grvDispatchedDetail.OptionsSelection.MultiSelect = true;
            this.grvDispatchedDetail.OptionsView.ShowFooter = true;
            this.grvDispatchedDetail.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvDispatchedDetail.PaintStyleName = "Skin";
            this.grvDispatchedDetail.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn1, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.grvDispatchedDetail.DoubleClick += new System.EventHandler(this.grvDispatchedDetail_DoubleClick);
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "DispatchingProductID";
            this.gridColumn4.FieldName = "DispatchingProductID";
            this.gridColumn4.MinWidth = 22;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Width = 174;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "ProductID";
            this.gridColumn3.MinWidth = 22;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Width = 84;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Product ID";
            this.gridColumn2.FieldName = "ProductNumber";
            this.gridColumn2.MinWidth = 22;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 108;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Product Name";
            this.gridColumn1.FieldName = "ProductName";
            this.gridColumn1.MinWidth = 22;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 2;
            this.gridColumn1.Width = 268;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "DO Remark";
            this.gridColumn7.FieldName = "DispatchingProductRemark";
            this.gridColumn7.MinWidth = 22;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            this.gridColumn7.Width = 98;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "DO Ref";
            this.gridColumn6.FieldName = "DispatchingProductCustomerRef";
            this.gridColumn6.MinWidth = 22;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            this.gridColumn6.Width = 71;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "DO Qty";
            this.gridColumn9.FieldName = "DispatchingOrderQty";
            this.gridColumn9.MinWidth = 22;
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 1;
            this.gridColumn9.Width = 71;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Units";
            this.gridColumn5.FieldName = "TotalUnits";
            this.gridColumn5.MinWidth = 22;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            this.gridColumn5.Width = 71;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Total Weight";
            this.gridColumn8.FieldName = "TotalWeight";
            this.gridColumn8.MinWidth = 22;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 3;
            this.gridColumn8.Width = 98;
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
            this.grcOrderDate.MinWidth = 11;
            this.grcOrderDate.Name = "grcOrderDate";
            this.grcOrderDate.OptionsColumn.ReadOnly = true;
            this.grcOrderDate.Visible = true;
            this.grcOrderDate.VisibleIndex = 6;
            this.grcOrderDate.Width = 110;
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
            this.grcOrderNumber.ColumnEdit = this.repositoryItemHyperLinkEdit1;
            this.grcOrderNumber.FieldName = "ReceivingOrderNumber";
            this.grcOrderNumber.MinWidth = 11;
            this.grcOrderNumber.Name = "grcOrderNumber";
            this.grcOrderNumber.OptionsColumn.ReadOnly = true;
            this.grcOrderNumber.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ReceivingOrderNumber", "TOTAL:")});
            this.grcOrderNumber.Visible = true;
            this.grcOrderNumber.VisibleIndex = 7;
            this.grcOrderNumber.Width = 108;
            // 
            // repositoryItemHyperLinkEdit1
            // 
            this.repositoryItemHyperLinkEdit1.AutoHeight = false;
            this.repositoryItemHyperLinkEdit1.Name = "repositoryItemHyperLinkEdit1";
            this.repositoryItemHyperLinkEdit1.Click += new System.EventHandler(this.repositoryItemHyperLinkEdit1_Click);
            // 
            // grcOriginalQty
            // 
            this.grcOriginalQty.AppearanceCell.ForeColor = System.Drawing.Color.Blue;
            this.grcOriginalQty.AppearanceCell.Options.UseForeColor = true;
            this.grcOriginalQty.AppearanceCell.Options.UseTextOptions = true;
            this.grcOriginalQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grcOriginalQty.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcOriginalQty.AppearanceHeader.Options.UseTextOptions = true;
            this.grcOriginalQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grcOriginalQty.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcOriginalQty.Caption = "R";
            this.grcOriginalQty.FieldName = "OriginalReceivedQty";
            this.grcOriginalQty.MaxWidth = 56;
            this.grcOriginalQty.MinWidth = 56;
            this.grcOriginalQty.Name = "grcOriginalQty";
            this.grcOriginalQty.OptionsColumn.ReadOnly = true;
            this.grcOriginalQty.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OriginalReceivedQty", "{0:n0}")});
            this.grcOriginalQty.Visible = true;
            this.grcOriginalQty.VisibleIndex = 8;
            this.grcOriginalQty.Width = 56;
            // 
            // grcReceivedQty
            // 
            this.grcReceivedQty.AppearanceCell.ForeColor = System.Drawing.Color.Red;
            this.grcReceivedQty.AppearanceCell.Options.UseForeColor = true;
            this.grcReceivedQty.AppearanceCell.Options.UseTextOptions = true;
            this.grcReceivedQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grcReceivedQty.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcReceivedQty.AppearanceHeader.Options.UseTextOptions = true;
            this.grcReceivedQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grcReceivedQty.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcReceivedQty.Caption = "D";
            this.grcReceivedQty.ColumnEdit = this.repositoryItemHyperLinkEdit2;
            this.grcReceivedQty.FieldName = "ReceivedQty";
            this.grcReceivedQty.MaxWidth = 56;
            this.grcReceivedQty.MinWidth = 56;
            this.grcReceivedQty.Name = "grcReceivedQty";
            this.grcReceivedQty.OptionsColumn.ReadOnly = true;
            this.grcReceivedQty.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ReceivedQty", "{0:n0}")});
            this.grcReceivedQty.Visible = true;
            this.grcReceivedQty.VisibleIndex = 9;
            this.grcReceivedQty.Width = 56;
            // 
            // repositoryItemHyperLinkEdit2
            // 
            this.repositoryItemHyperLinkEdit2.AutoHeight = false;
            this.repositoryItemHyperLinkEdit2.Name = "repositoryItemHyperLinkEdit2";
            this.repositoryItemHyperLinkEdit2.DoubleClick += new System.EventHandler(this.repositoryItemHyperLinkEdit2_DoubleClick);
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
            this.grcCustomerRef.MinWidth = 11;
            this.grcCustomerRef.Name = "grcCustomerRef";
            this.grcCustomerRef.OptionsColumn.ReadOnly = true;
            this.grcCustomerRef.Visible = true;
            this.grcCustomerRef.VisibleIndex = 10;
            this.grcCustomerRef.Width = 202;
            // 
            // grcRemark
            // 
            this.grcRemark.AppearanceCell.Options.UseTextOptions = true;
            this.grcRemark.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcRemark.AppearanceHeader.Options.UseTextOptions = true;
            this.grcRemark.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcRemark.Caption = "Remark";
            this.grcRemark.FieldName = "Remark";
            this.grcRemark.MinWidth = 11;
            this.grcRemark.Name = "grcRemark";
            this.grcRemark.OptionsColumn.ReadOnly = true;
            this.grcRemark.Visible = true;
            this.grcRemark.VisibleIndex = 11;
            this.grcRemark.Width = 148;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Cus. Order No.";
            this.gridColumn16.FieldName = "CustomerOrderNumber";
            this.gridColumn16.MinWidth = 22;
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 13;
            this.gridColumn16.Width = 100;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Vehicle";
            this.gridColumn15.FieldName = "VehicleNumber";
            this.gridColumn15.MinWidth = 22;
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 12;
            this.gridColumn15.Width = 96;
            // 
            // grcVehicle
            // 
            this.grcVehicle.AppearanceCell.Options.UseTextOptions = true;
            this.grcVehicle.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcVehicle.AppearanceHeader.Options.UseTextOptions = true;
            this.grcVehicle.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcVehicle.Caption = "RO Remark";
            this.grcVehicle.FieldName = "RORemark";
            this.grcVehicle.MinWidth = 22;
            this.grcVehicle.Name = "grcVehicle";
            this.grcVehicle.OptionsColumn.ReadOnly = true;
            this.grcVehicle.Visible = true;
            this.grcVehicle.VisibleIndex = 14;
            this.grcVehicle.Width = 165;
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
            this.grcProductionDate.MinWidth = 11;
            this.grcProductionDate.Name = "grcProductionDate";
            this.grcProductionDate.OptionsColumn.ReadOnly = true;
            this.grcProductionDate.Visible = true;
            this.grcProductionDate.VisibleIndex = 15;
            this.grcProductionDate.Width = 108;
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
            this.grcUseByDate.MinWidth = 11;
            this.grcUseByDate.Name = "grcUseByDate";
            this.grcUseByDate.OptionsColumn.ReadOnly = true;
            this.grcUseByDate.Visible = true;
            this.grcUseByDate.VisibleIndex = 16;
            this.grcUseByDate.Width = 88;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Remain";
            this.gridColumn14.FieldName = "RemainingLife";
            this.gridColumn14.MinWidth = 22;
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 18;
            this.gridColumn14.Width = 133;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Selflife";
            this.gridColumn10.DisplayFormat.FormatString = "p";
            this.gridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn10.FieldName = "RemainSelfLife";
            this.gridColumn10.MinWidth = 22;
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 17;
            this.gridColumn10.Width = 76;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "ReceivingOrderID";
            this.gridColumn11.FieldName = "ReceivingOrderID";
            this.gridColumn11.MinWidth = 22;
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Width = 84;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "CustomerID";
            this.gridColumn13.FieldName = "CustomerID";
            this.gridColumn13.MinWidth = 22;
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Width = 84;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "ProductID";
            this.gridColumn12.FieldName = "ProductID";
            this.gridColumn12.MinWidth = 22;
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Width = 84;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "ReceivingOrderDetailID";
            this.gridColumn17.FieldName = "ReceivingOrderDetailID";
            this.gridColumn17.MinWidth = 28;
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.Width = 106;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1876, 984);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdDispatchedDetail;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1856, 962);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // frm_WM_Dialog_DispatchingOrderDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1876, 984);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_WM_Dialog_DispatchingOrderDetails";
            this.Text = "Dispatching Order Details";
            this.Load += new System.EventHandler(this.frm_WM_Dialog_DispatchingOrderDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDispatchedDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDispatchedDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl grdDispatchedDetail;
        private Common.Controls.WMSGridView grvDispatchedDetail;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn grcOrderDate;
        private DevExpress.XtraGrid.Columns.GridColumn grcOrderNumber;
        private DevExpress.XtraGrid.Columns.GridColumn grcOriginalQty;
        private DevExpress.XtraGrid.Columns.GridColumn grcReceivedQty;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerRef;
        private DevExpress.XtraGrid.Columns.GridColumn grcRemark;
        private DevExpress.XtraGrid.Columns.GridColumn grcVehicle;
        private DevExpress.XtraGrid.Columns.GridColumn grcProductionDate;
        private DevExpress.XtraGrid.Columns.GridColumn grcUseByDate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit2;
    }
}