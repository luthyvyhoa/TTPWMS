namespace UI.ReportForm
{
    partial class urc_BR_InOutViewByCustomers
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
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.grcInOutAllProducts = new DevExpress.XtraGrid.GridControl();
            this.grvInOutAllProducts = new Common.Controls.WMSGridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_hle_OrderID = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.gridColumnCustomerID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcInOutAllProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvInOutAllProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_hle_OrderID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grcInOutAllProducts);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1187, 606);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1187, 606);
            this.Root.TextVisible = false;
            // 
            // grcInOutAllProducts
            // 
            this.grcInOutAllProducts.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.grcInOutAllProducts.Location = new System.Drawing.Point(12, 12);
            this.grcInOutAllProducts.MainView = this.grvInOutAllProducts;
            this.grcInOutAllProducts.Name = "grcInOutAllProducts";
            this.grcInOutAllProducts.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpi_hle_OrderID});
            this.grcInOutAllProducts.Size = new System.Drawing.Size(1163, 582);
            this.grcInOutAllProducts.TabIndex = 20;
            this.grcInOutAllProducts.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvInOutAllProducts});
            // 
            // grvInOutAllProducts
            // 
            this.grvInOutAllProducts.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn11,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
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
            this.gridColumnCustomerID});
            this.grvInOutAllProducts.FixedLineWidth = 3;
            this.grvInOutAllProducts.GridControl = this.grcInOutAllProducts;
            this.grvInOutAllProducts.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPackages", null, "UOM = {0:n0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalWeight", null, "Kgs = {0:n0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Plts", null, "Plts = {0:n0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "QtyCtns", null, "Ctns = {0:n0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "QtyPcs", null, "Pcs = {0:n0}")});
            this.grvInOutAllProducts.Name = "grvInOutAllProducts";
            this.grvInOutAllProducts.OptionsView.ShowFooter = true;
            this.grvInOutAllProducts.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvInOutAllProducts.PaintStyleName = "Skin";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Order";
            this.gridColumn3.ColumnEdit = this.rpi_hle_OrderID;
            this.gridColumn3.FieldName = "OrderNumber";
            this.gridColumn3.MinWidth = 25;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            this.gridColumn3.Width = 89;
            // 
            // rpi_hle_OrderID
            // 
            this.rpi_hle_OrderID.AutoHeight = false;
            this.rpi_hle_OrderID.Name = "rpi_hle_OrderID";
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Date";
            this.gridColumn4.FieldName = "OrderDate";
            this.gridColumn4.MinWidth = 25;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            this.gridColumn4.Width = 96;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Product ID";
            this.gridColumn5.FieldName = "ProductNumber";
            this.gridColumn5.MinWidth = 25;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 125;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Product Name";
            this.gridColumn6.FieldName = "ProductName";
            this.gridColumn6.MinWidth = 25;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ProductName", "{0}")});
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            this.gridColumn6.Width = 345;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Plts";
            this.gridColumn11.DisplayFormat.FormatString = "n0";
            this.gridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn11.FieldName = "Plts";
            this.gridColumn11.MinWidth = 25;
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Plts", "{0:n0}")});
            this.gridColumn11.Width = 57;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Qty";
            this.gridColumn7.DisplayFormat.FormatString = "n0";
            this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn7.FieldName = "TotalPackages";
            this.gridColumn7.MinWidth = 25;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPackages", "{0:n0}")});
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            this.gridColumn7.Width = 63;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Weight";
            this.gridColumn8.DisplayFormat.FormatString = "n1";
            this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn8.FieldName = "TotalWeight";
            this.gridColumn8.MinWidth = 25;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalWeight", "{0:n1}")});
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 6;
            this.gridColumn8.Width = 76;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Reference";
            this.gridColumn9.FieldName = "CustomerRef";
            this.gridColumn9.MinWidth = 25;
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Width = 49;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Remark";
            this.gridColumn10.FieldName = "Remark";
            this.gridColumn10.MinWidth = 25;
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Width = 57;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "SpecialRequirement";
            this.gridColumn12.FieldName = "SpecialRequirement";
            this.gridColumn12.MinWidth = 25;
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Width = 93;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "W/P";
            this.gridColumn13.FieldName = "WeightPerPackage";
            this.gridColumn13.MinWidth = 25;
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Width = 93;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Service";
            this.gridColumn14.FieldName = "ServiceName";
            this.gridColumn14.MinWidth = 25;
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 2;
            this.gridColumn14.Width = 151;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Pcs";
            this.gridColumn15.FieldName = "Pcs";
            this.gridColumn15.MaxWidth = 55;
            this.gridColumn15.MinWidth = 25;
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 7;
            this.gridColumn15.Width = 45;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Package";
            this.gridColumn16.FieldName = "Packages";
            this.gridColumn16.MinWidth = 25;
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Width = 93;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "Group";
            this.gridColumn17.FieldName = "ProductGroupDescription";
            this.gridColumn17.MinWidth = 25;
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.Width = 93;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "Product Package Type";
            this.gridColumn18.FieldName = "ProductPackageType";
            this.gridColumn18.MinWidth = 25;
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.Width = 93;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "Qty Ctns";
            this.gridColumn19.FieldName = "QtyCtns";
            this.gridColumn19.MinWidth = 25;
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 8;
            this.gridColumn19.Width = 65;
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "Qty Pcs";
            this.gridColumn20.FieldName = "QtyPcs";
            this.gridColumn20.MinWidth = 25;
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 9;
            this.gridColumn20.Width = 79;
            // 
            // gridColumn21
            // 
            this.gridColumn21.Caption = "OrderType";
            this.gridColumn21.FieldName = "OrderType";
            this.gridColumn21.MinWidth = 27;
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.Width = 100;
            // 
            // gridColumnCustomerID
            // 
            this.gridColumnCustomerID.Caption = "CustomerID";
            this.gridColumnCustomerID.FieldName = "CustomerID";
            this.gridColumnCustomerID.MinWidth = 27;
            this.gridColumnCustomerID.Name = "gridColumnCustomerID";
            this.gridColumnCustomerID.Width = 100;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grcInOutAllProducts;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1167, 586);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // urc_BR_InOutViewByCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "urc_BR_InOutViewByCustomers";
            this.Size = new System.Drawing.Size(1187, 606);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcInOutAllProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvInOutAllProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_hle_OrderID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraGrid.GridControl grcInOutAllProducts;
        private Common.Controls.WMSGridView grvInOutAllProducts;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpi_hle_OrderID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
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
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCustomerID;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}
