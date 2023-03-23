namespace UI.WarehouseManagement
{
    partial class frm_WM_Dialog_PalletHistories
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_WM_Dialog_PalletHistories));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gridControlHoldByPalletIDHistories = new DevExpress.XtraGrid.GridControl();
            this.gridViewHoldByPalletIDHistories = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grcPalletID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcPalletHoldingBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcPalletHoldingDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcPalletHoldingTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcOnHold = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcPalletStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControlDO = new DevExpress.XtraGrid.GridControl();
            this.gridViewDO = new Common.Controls.WMSGridView();
            this.gridColumnDispatchingOrderID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repItemHyperLinkEdit_DispatchingOrderID = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridColumnDispatchingOrderDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit7 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumnTotalPackagesDO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnTotalUnitsDO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnTotalWeightDO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDORemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSpecialRequirementDO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnStatusDO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDOSpecialRequirement = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl_PalletHistories = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new Common.Controls.WMSGridView();
            this.gridColumn_PalletID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_TransactionType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_TransactionDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn_Reason = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_DoneBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemHyperLinkEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.repositoryItemTextEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlHoldByPalletIDHistories)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewHoldByPalletIDHistories)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemHyperLinkEdit_DispatchingOrderID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_PalletHistories)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // rbcbase
            // 
            this.rbcbase.ExpandCollapseItem.Id = 0;
            this.rbcbase.OptionsCustomizationForm.FormIcon = ((System.Drawing.Icon)(resources.GetObject("resource.FormIcon")));
            this.rbcbase.Size = new System.Drawing.Size(915, 38);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridControlHoldByPalletIDHistories);
            this.layoutControl1.Controls.Add(this.gridControlDO);
            this.layoutControl1.Controls.Add(this.gridControl_PalletHistories);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 38);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Padding = new System.Windows.Forms.Padding(11, 9, 11, 9);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(915, 745);
            this.layoutControl1.TabIndex = 6;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControlHoldByPalletIDHistories
            // 
            this.gridControlHoldByPalletIDHistories.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(5);
            this.gridControlHoldByPalletIDHistories.Location = new System.Drawing.Point(15, 512);
            this.gridControlHoldByPalletIDHistories.MainView = this.gridViewHoldByPalletIDHistories;
            this.gridControlHoldByPalletIDHistories.Margin = new System.Windows.Forms.Padding(4);
            this.gridControlHoldByPalletIDHistories.Name = "gridControlHoldByPalletIDHistories";
            this.gridControlHoldByPalletIDHistories.Size = new System.Drawing.Size(885, 218);
            this.gridControlHoldByPalletIDHistories.TabIndex = 8;
            this.gridControlHoldByPalletIDHistories.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewHoldByPalletIDHistories});
            // 
            // gridViewHoldByPalletIDHistories
            // 
            this.gridViewHoldByPalletIDHistories.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grcPalletID,
            this.grcPalletHoldingBy,
            this.grcPalletHoldingDescription,
            this.grcPalletHoldingTime,
            this.grcOnHold,
            this.grcPalletStatus});
            this.gridViewHoldByPalletIDHistories.DetailHeight = 458;
            this.gridViewHoldByPalletIDHistories.FixedLineWidth = 3;
            this.gridViewHoldByPalletIDHistories.GridControl = this.gridControlHoldByPalletIDHistories;
            this.gridViewHoldByPalletIDHistories.GroupPanelText = "Hold by Pallet ID histories";
            this.gridViewHoldByPalletIDHistories.Name = "gridViewHoldByPalletIDHistories";
            this.gridViewHoldByPalletIDHistories.OptionsView.ShowGroupPanel = false;
            this.gridViewHoldByPalletIDHistories.OptionsView.ShowIndicator = false;
            this.gridViewHoldByPalletIDHistories.ViewCaption = "Hold by Pallet ID histories";
            // 
            // grcPalletID
            // 
            this.grcPalletID.Caption = "Pallet ID";
            this.grcPalletID.FieldName = "PalletID";
            this.grcPalletID.MinWidth = 27;
            this.grcPalletID.Name = "grcPalletID";
            this.grcPalletID.Visible = true;
            this.grcPalletID.VisibleIndex = 4;
            this.grcPalletID.Width = 127;
            // 
            // grcPalletHoldingBy
            // 
            this.grcPalletHoldingBy.Caption = "Pallet Holding By";
            this.grcPalletHoldingBy.FieldName = "PalletHoldingBy";
            this.grcPalletHoldingBy.MinWidth = 27;
            this.grcPalletHoldingBy.Name = "grcPalletHoldingBy";
            this.grcPalletHoldingBy.Visible = true;
            this.grcPalletHoldingBy.VisibleIndex = 0;
            this.grcPalletHoldingBy.Width = 173;
            // 
            // grcPalletHoldingDescription
            // 
            this.grcPalletHoldingDescription.Caption = "Pallet Holding Description";
            this.grcPalletHoldingDescription.FieldName = "PalletHoldingDescription";
            this.grcPalletHoldingDescription.MinWidth = 27;
            this.grcPalletHoldingDescription.Name = "grcPalletHoldingDescription";
            this.grcPalletHoldingDescription.Visible = true;
            this.grcPalletHoldingDescription.VisibleIndex = 1;
            this.grcPalletHoldingDescription.Width = 211;
            // 
            // grcPalletHoldingTime
            // 
            this.grcPalletHoldingTime.Caption = "Pallet Holding Time";
            this.grcPalletHoldingTime.FieldName = "PalletHoldingTime";
            this.grcPalletHoldingTime.MinWidth = 27;
            this.grcPalletHoldingTime.Name = "grcPalletHoldingTime";
            this.grcPalletHoldingTime.Visible = true;
            this.grcPalletHoldingTime.VisibleIndex = 2;
            this.grcPalletHoldingTime.Width = 137;
            // 
            // grcOnHold
            // 
            this.grcOnHold.Caption = "On Hold";
            this.grcOnHold.FieldName = "OnHold";
            this.grcOnHold.MinWidth = 27;
            this.grcOnHold.Name = "grcOnHold";
            this.grcOnHold.Visible = true;
            this.grcOnHold.VisibleIndex = 3;
            // 
            // grcPalletStatus
            // 
            this.grcPalletStatus.Caption = "Pallet Status";
            this.grcPalletStatus.FieldName = "PalletStatus";
            this.grcPalletStatus.MinWidth = 27;
            this.grcPalletStatus.Name = "grcPalletStatus";
            this.grcPalletStatus.Visible = true;
            this.grcPalletStatus.VisibleIndex = 5;
            this.grcPalletStatus.Width = 143;
            // 
            // gridControlDO
            // 
            this.gridControlDO.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControlDO.Location = new System.Drawing.Point(12, 249);
            this.gridControlDO.MainView = this.gridViewDO;
            this.gridControlDO.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControlDO.Name = "gridControlDO";
            this.gridControlDO.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repItemHyperLinkEdit_DispatchingOrderID,
            this.repositoryItemTextEdit7});
            this.gridControlDO.Size = new System.Drawing.Size(891, 232);
            this.gridControlDO.TabIndex = 7;
            this.gridControlDO.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDO});
            // 
            // gridViewDO
            // 
            this.gridViewDO.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.gridViewDO.Appearance.FooterPanel.Options.UseFont = true;
            this.gridViewDO.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridViewDO.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnDispatchingOrderID,
            this.gridColumnDispatchingOrderDate,
            this.gridColumnTotalPackagesDO,
            this.gridColumnTotalUnitsDO,
            this.gridColumnTotalWeightDO,
            this.gridColumnDORemark,
            this.gridColumnSpecialRequirementDO,
            this.gridColumnStatusDO,
            this.gridColumnDOSpecialRequirement});
            this.gridViewDO.FixedLineWidth = 3;
            this.gridViewDO.GridControl = this.gridControlDO;
            this.gridViewDO.Name = "gridViewDO";
            this.gridViewDO.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewDO.OptionsSelection.MultiSelect = true;
            this.gridViewDO.OptionsView.ColumnAutoWidth = false;
            this.gridViewDO.OptionsView.ShowFooter = true;
            this.gridViewDO.OptionsView.ShowGroupPanel = false;
            this.gridViewDO.OptionsView.ShowIndicator = false;
            this.gridViewDO.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewDO.PaintStyleName = "Skin";
            // 
            // gridColumnDispatchingOrderID
            // 
            this.gridColumnDispatchingOrderID.Caption = "DO ID";
            this.gridColumnDispatchingOrderID.ColumnEdit = this.repItemHyperLinkEdit_DispatchingOrderID;
            this.gridColumnDispatchingOrderID.FieldName = "DispatchingOrderID";
            this.gridColumnDispatchingOrderID.Name = "gridColumnDispatchingOrderID";
            this.gridColumnDispatchingOrderID.OptionsColumn.ReadOnly = true;
            this.gridColumnDispatchingOrderID.Visible = true;
            this.gridColumnDispatchingOrderID.VisibleIndex = 0;
            this.gridColumnDispatchingOrderID.Width = 91;
            // 
            // repItemHyperLinkEdit_DispatchingOrderID
            // 
            this.repItemHyperLinkEdit_DispatchingOrderID.AutoHeight = false;
            this.repItemHyperLinkEdit_DispatchingOrderID.Name = "repItemHyperLinkEdit_DispatchingOrderID";
            this.repItemHyperLinkEdit_DispatchingOrderID.Click += new System.EventHandler(this.repItemHyperLinkEdit_DispatchingOrderID_Click);
            // 
            // gridColumnDispatchingOrderDate
            // 
            this.gridColumnDispatchingOrderDate.Caption = "DATE";
            this.gridColumnDispatchingOrderDate.ColumnEdit = this.repositoryItemTextEdit7;
            this.gridColumnDispatchingOrderDate.DisplayFormat.FormatString = "dd/MM/yy";
            this.gridColumnDispatchingOrderDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumnDispatchingOrderDate.FieldName = "DispatchingOrderDate";
            this.gridColumnDispatchingOrderDate.Name = "gridColumnDispatchingOrderDate";
            this.gridColumnDispatchingOrderDate.OptionsColumn.ReadOnly = true;
            this.gridColumnDispatchingOrderDate.Visible = true;
            this.gridColumnDispatchingOrderDate.VisibleIndex = 1;
            this.gridColumnDispatchingOrderDate.Width = 100;
            // 
            // repositoryItemTextEdit7
            // 
            this.repositoryItemTextEdit7.AutoHeight = false;
            this.repositoryItemTextEdit7.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.repositoryItemTextEdit7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.repositoryItemTextEdit7.EditFormat.FormatString = "dd/MM/yyyy";
            this.repositoryItemTextEdit7.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.repositoryItemTextEdit7.Mask.EditMask = "  /  /    ";
            this.repositoryItemTextEdit7.Name = "repositoryItemTextEdit7";
            // 
            // gridColumnTotalPackagesDO
            // 
            this.gridColumnTotalPackagesDO.Caption = "QTY";
            this.gridColumnTotalPackagesDO.DisplayFormat.FormatString = "n0";
            this.gridColumnTotalPackagesDO.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnTotalPackagesDO.FieldName = "TotalPackages";
            this.gridColumnTotalPackagesDO.Name = "gridColumnTotalPackagesDO";
            this.gridColumnTotalPackagesDO.OptionsColumn.ReadOnly = true;
            this.gridColumnTotalPackagesDO.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPackages", "{0:n0}")});
            this.gridColumnTotalPackagesDO.Visible = true;
            this.gridColumnTotalPackagesDO.VisibleIndex = 2;
            this.gridColumnTotalPackagesDO.Width = 40;
            // 
            // gridColumnTotalUnitsDO
            // 
            this.gridColumnTotalUnitsDO.Caption = "UNIT";
            this.gridColumnTotalUnitsDO.DisplayFormat.FormatString = "n0";
            this.gridColumnTotalUnitsDO.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnTotalUnitsDO.FieldName = "TotalUnits";
            this.gridColumnTotalUnitsDO.Name = "gridColumnTotalUnitsDO";
            this.gridColumnTotalUnitsDO.OptionsColumn.ReadOnly = true;
            this.gridColumnTotalUnitsDO.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalUnits", "{0:n0}")});
            this.gridColumnTotalUnitsDO.Visible = true;
            this.gridColumnTotalUnitsDO.VisibleIndex = 4;
            // 
            // gridColumnTotalWeightDO
            // 
            this.gridColumnTotalWeightDO.Caption = "KG";
            this.gridColumnTotalWeightDO.DisplayFormat.FormatString = "n1";
            this.gridColumnTotalWeightDO.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnTotalWeightDO.FieldName = "TotalWeight";
            this.gridColumnTotalWeightDO.Name = "gridColumnTotalWeightDO";
            this.gridColumnTotalWeightDO.OptionsColumn.ReadOnly = true;
            this.gridColumnTotalWeightDO.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalWeight", "{0:n1}")});
            this.gridColumnTotalWeightDO.Visible = true;
            this.gridColumnTotalWeightDO.VisibleIndex = 3;
            // 
            // gridColumnDORemark
            // 
            this.gridColumnDORemark.Caption = "REMARK";
            this.gridColumnDORemark.FieldName = "Remark";
            this.gridColumnDORemark.Name = "gridColumnDORemark";
            this.gridColumnDORemark.OptionsColumn.ReadOnly = true;
            this.gridColumnDORemark.Visible = true;
            this.gridColumnDORemark.VisibleIndex = 7;
            this.gridColumnDORemark.Width = 199;
            // 
            // gridColumnSpecialRequirementDO
            // 
            this.gridColumnSpecialRequirementDO.Caption = "REFERENCE";
            this.gridColumnSpecialRequirementDO.FieldName = "SpecialRequirement";
            this.gridColumnSpecialRequirementDO.Name = "gridColumnSpecialRequirementDO";
            this.gridColumnSpecialRequirementDO.OptionsColumn.ReadOnly = true;
            this.gridColumnSpecialRequirementDO.Visible = true;
            this.gridColumnSpecialRequirementDO.VisibleIndex = 5;
            this.gridColumnSpecialRequirementDO.Width = 100;
            // 
            // gridColumnStatusDO
            // 
            this.gridColumnStatusDO.Caption = "X";
            this.gridColumnStatusDO.FieldName = "Status";
            this.gridColumnStatusDO.Name = "gridColumnStatusDO";
            this.gridColumnStatusDO.OptionsColumn.ReadOnly = true;
            this.gridColumnStatusDO.Visible = true;
            this.gridColumnStatusDO.VisibleIndex = 6;
            this.gridColumnStatusDO.Width = 29;
            // 
            // gridColumnDOSpecialRequirement
            // 
            this.gridColumnDOSpecialRequirement.Caption = "VEHICLE";
            this.gridColumnDOSpecialRequirement.FieldName = "SpecialRequirement";
            this.gridColumnDOSpecialRequirement.Name = "gridColumnDOSpecialRequirement";
            this.gridColumnDOSpecialRequirement.OptionsColumn.ReadOnly = true;
            this.gridColumnDOSpecialRequirement.Visible = true;
            this.gridColumnDOSpecialRequirement.VisibleIndex = 8;
            this.gridColumnDOSpecialRequirement.Width = 132;
            // 
            // gridControl_PalletHistories
            // 
            this.gridControl_PalletHistories.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl_PalletHistories.Location = new System.Drawing.Point(12, 12);
            this.gridControl_PalletHistories.MainView = this.gridView1;
            this.gridControl_PalletHistories.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl_PalletHistories.Name = "gridControl_PalletHistories";
            this.gridControl_PalletHistories.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemHyperLinkEdit1,
            this.repositoryItemTextEdit3,
            this.repositoryItemTextEdit4});
            this.gridControl_PalletHistories.Size = new System.Drawing.Size(891, 233);
            this.gridControl_PalletHistories.TabIndex = 6;
            this.gridControl_PalletHistories.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.FooterPanel.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn_PalletID,
            this.gridColumn_TransactionType,
            this.gridColumn_TransactionDate,
            this.gridColumn_Reason,
            this.gridColumn_DoneBy});
            this.gridView1.FixedLineWidth = 3;
            this.gridView1.GridControl = this.gridControl_PalletHistories;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // gridColumn_PalletID
            // 
            this.gridColumn_PalletID.Caption = "PALLET ID";
            this.gridColumn_PalletID.FieldName = "PalletID";
            this.gridColumn_PalletID.Name = "gridColumn_PalletID";
            this.gridColumn_PalletID.OptionsColumn.ReadOnly = true;
            this.gridColumn_PalletID.Visible = true;
            this.gridColumn_PalletID.VisibleIndex = 0;
            this.gridColumn_PalletID.Width = 85;
            // 
            // gridColumn_TransactionType
            // 
            this.gridColumn_TransactionType.Caption = "TYPE";
            this.gridColumn_TransactionType.FieldName = "TransactionType";
            this.gridColumn_TransactionType.Name = "gridColumn_TransactionType";
            this.gridColumn_TransactionType.OptionsColumn.ReadOnly = true;
            this.gridColumn_TransactionType.Visible = true;
            this.gridColumn_TransactionType.VisibleIndex = 1;
            this.gridColumn_TransactionType.Width = 93;
            // 
            // gridColumn_TransactionDate
            // 
            this.gridColumn_TransactionDate.Caption = "TIME";
            this.gridColumn_TransactionDate.ColumnEdit = this.repositoryItemTextEdit3;
            this.gridColumn_TransactionDate.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.gridColumn_TransactionDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn_TransactionDate.FieldName = "TransactionDate";
            this.gridColumn_TransactionDate.Name = "gridColumn_TransactionDate";
            this.gridColumn_TransactionDate.OptionsColumn.ReadOnly = true;
            this.gridColumn_TransactionDate.Visible = true;
            this.gridColumn_TransactionDate.VisibleIndex = 2;
            this.gridColumn_TransactionDate.Width = 153;
            // 
            // repositoryItemTextEdit3
            // 
            this.repositoryItemTextEdit3.AutoHeight = false;
            this.repositoryItemTextEdit3.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.repositoryItemTextEdit3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.repositoryItemTextEdit3.EditFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.repositoryItemTextEdit3.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.repositoryItemTextEdit3.Mask.EditMask = "  /  /    ";
            this.repositoryItemTextEdit3.Name = "repositoryItemTextEdit3";
            // 
            // gridColumn_Reason
            // 
            this.gridColumn_Reason.Caption = "DESCRIPTION";
            this.gridColumn_Reason.FieldName = "Reason";
            this.gridColumn_Reason.Name = "gridColumn_Reason";
            this.gridColumn_Reason.OptionsColumn.ReadOnly = true;
            this.gridColumn_Reason.Visible = true;
            this.gridColumn_Reason.VisibleIndex = 3;
            this.gridColumn_Reason.Width = 391;
            // 
            // gridColumn_DoneBy
            // 
            this.gridColumn_DoneBy.Caption = "USER";
            this.gridColumn_DoneBy.FieldName = "DoneBy";
            this.gridColumn_DoneBy.Name = "gridColumn_DoneBy";
            this.gridColumn_DoneBy.OptionsColumn.ReadOnly = true;
            this.gridColumn_DoneBy.Visible = true;
            this.gridColumn_DoneBy.VisibleIndex = 4;
            this.gridColumn_DoneBy.Width = 100;
            // 
            // repositoryItemHyperLinkEdit1
            // 
            this.repositoryItemHyperLinkEdit1.AutoHeight = false;
            this.repositoryItemHyperLinkEdit1.Name = "repositoryItemHyperLinkEdit1";
            // 
            // repositoryItemTextEdit4
            // 
            this.repositoryItemTextEdit4.AutoHeight = false;
            this.repositoryItemTextEdit4.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.repositoryItemTextEdit4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.repositoryItemTextEdit4.EditFormat.FormatString = "dd/MM/yyyy";
            this.repositoryItemTextEdit4.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.repositoryItemTextEdit4.Mask.EditMask = "  /  /    ";
            this.repositoryItemTextEdit4.Name = "repositoryItemTextEdit4";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlGroup2});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(915, 745);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl_PalletHistories;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(895, 237);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gridControlDO;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 237);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(895, 236);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 473);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup2.Size = new System.Drawing.Size(895, 252);
            this.layoutControlGroup2.Text = "Hold by PalletID";
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.gridControlHoldByPalletIDHistories;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(889, 222);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // frm_WM_Dialog_PalletHistories
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 783);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frm_WM_Dialog_PalletHistories";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "Pallet Histories";
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlHoldByPalletIDHistories)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewHoldByPalletIDHistories)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemHyperLinkEdit_DispatchingOrderID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_PalletHistories)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl gridControl_PalletHistories;
        private Common.Controls.WMSGridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_PalletID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_TransactionType;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_TransactionDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Reason;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_DoneBy;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit4;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.GridControl gridControlDO;
        private Common.Controls.WMSGridView gridViewDO;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDispatchingOrderID;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repItemHyperLinkEdit_DispatchingOrderID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDispatchingOrderDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnTotalPackagesDO;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnTotalUnitsDO;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnTotalWeightDO;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDORemark;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSpecialRequirementDO;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnStatusDO;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDOSpecialRequirement;
        private DevExpress.XtraGrid.GridControl gridControlHoldByPalletIDHistories;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewHoldByPalletIDHistories;
        private DevExpress.XtraGrid.Columns.GridColumn grcPalletID;
        private DevExpress.XtraGrid.Columns.GridColumn grcPalletHoldingBy;
        private DevExpress.XtraGrid.Columns.GridColumn grcPalletHoldingDescription;
        private DevExpress.XtraGrid.Columns.GridColumn grcPalletHoldingTime;
        private DevExpress.XtraGrid.Columns.GridColumn grcOnHold;
        private DevExpress.XtraGrid.Columns.GridColumn grcPalletStatus;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
    }
}