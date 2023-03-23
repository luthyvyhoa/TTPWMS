namespace UI.WarehouseManagement
{
    partial class urc_WM_DODetail
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
            this.grdDispatchingOrderDetailBreak = new DevExpress.XtraGrid.GridControl();
            this.grvDispatchingOrderDetailBreak = new Common.Controls.WMSGridView();
            this.grcProductNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcBreakRONumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcBreakQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcBreakPalletID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcTotalUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcPalletWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcIsBreak = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_chk_IsBreak = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDispatchingOrderDetailBreak)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDispatchingOrderDetailBreak)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_chk_IsBreak)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grdDispatchingOrderDetailBreak);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(972, 615);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grdDispatchingOrderDetailBreak
            // 
            this.grdDispatchingOrderDetailBreak.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grdDispatchingOrderDetailBreak.Location = new System.Drawing.Point(15, 15);
            this.grdDispatchingOrderDetailBreak.MainView = this.grvDispatchingOrderDetailBreak;
            this.grdDispatchingOrderDetailBreak.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grdDispatchingOrderDetailBreak.Name = "grdDispatchingOrderDetailBreak";
            this.grdDispatchingOrderDetailBreak.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpi_chk_IsBreak});
            this.grdDispatchingOrderDetailBreak.Size = new System.Drawing.Size(942, 585);
            this.grdDispatchingOrderDetailBreak.TabIndex = 5;
            this.grdDispatchingOrderDetailBreak.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDispatchingOrderDetailBreak});
            // 
            // grvDispatchingOrderDetailBreak
            // 
            this.grvDispatchingOrderDetailBreak.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grvDispatchingOrderDetailBreak.Appearance.FooterPanel.Options.UseFont = true;
            this.grvDispatchingOrderDetailBreak.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvDispatchingOrderDetailBreak.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grcProductNumber,
            this.grcBreakRONumber,
            this.grcBreakQty,
            this.grcBreakPalletID,
            this.grcTotalUnit,
            this.grcPalletWeight,
            this.grcIsBreak,
            this.gridColumn1});
            this.grvDispatchingOrderDetailBreak.GridControl = this.grdDispatchingOrderDetailBreak;
            this.grvDispatchingOrderDetailBreak.Name = "grvDispatchingOrderDetailBreak";
            this.grvDispatchingOrderDetailBreak.OptionsView.ShowFooter = true;
            this.grvDispatchingOrderDetailBreak.OptionsView.ShowGroupPanel = false;
            this.grvDispatchingOrderDetailBreak.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvDispatchingOrderDetailBreak.PaintStyleName = "Skin";
            this.grvDispatchingOrderDetailBreak.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvDispatchingOrderDetailBreak_CellValueChanged);
            // 
            // grcProductNumber
            // 
            this.grcProductNumber.Caption = "PRODUCT.NO";
            this.grcProductNumber.FieldName = "ProductNumber";
            this.grcProductNumber.Name = "grcProductNumber";
            this.grcProductNumber.OptionsColumn.AllowEdit = false;
            this.grcProductNumber.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ProductNumber", "Total:")});
            this.grcProductNumber.Visible = true;
            this.grcProductNumber.VisibleIndex = 0;
            // 
            // grcBreakRONumber
            // 
            this.grcBreakRONumber.Caption = "RO-ID";
            this.grcBreakRONumber.FieldName = "ReceivingOrderNumber";
            this.grcBreakRONumber.Name = "grcBreakRONumber";
            this.grcBreakRONumber.OptionsColumn.AllowEdit = false;
            this.grcBreakRONumber.Visible = true;
            this.grcBreakRONumber.VisibleIndex = 1;
            // 
            // grcBreakQty
            // 
            this.grcBreakQty.Caption = "QTY";
            this.grcBreakQty.FieldName = "QuantityOfPackages";
            this.grcBreakQty.Name = "grcBreakQty";
            this.grcBreakQty.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "QuantityOfPackages", "{0:0.##}")});
            this.grcBreakQty.Visible = true;
            this.grcBreakQty.VisibleIndex = 2;
            // 
            // grcBreakPalletID
            // 
            this.grcBreakPalletID.Caption = "PALLET ID";
            this.grcBreakPalletID.FieldName = "PalletID";
            this.grcBreakPalletID.Name = "grcBreakPalletID";
            this.grcBreakPalletID.Visible = true;
            this.grcBreakPalletID.VisibleIndex = 3;
            // 
            // grcTotalUnit
            // 
            this.grcTotalUnit.Caption = "UNIT";
            this.grcTotalUnit.FieldName = "UnitQuantity";
            this.grcTotalUnit.Name = "grcTotalUnit";
            this.grcTotalUnit.OptionsColumn.AllowEdit = false;
            this.grcTotalUnit.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "UnitQuantity", "{0:0.##}")});
            this.grcTotalUnit.Visible = true;
            this.grcTotalUnit.VisibleIndex = 4;
            // 
            // grcPalletWeight
            // 
            this.grcPalletWeight.Caption = "WEIGHT";
            this.grcPalletWeight.FieldName = "PalletWeight";
            this.grcPalletWeight.Name = "grcPalletWeight";
            this.grcPalletWeight.OptionsColumn.AllowEdit = false;
            this.grcPalletWeight.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PalletWeight", "{0:0.##}")});
            this.grcPalletWeight.Visible = true;
            this.grcPalletWeight.VisibleIndex = 5;
            // 
            // grcIsBreak
            // 
            this.grcIsBreak.Caption = "CHECK BREAK";
            this.grcIsBreak.ColumnEdit = this.rpi_chk_IsBreak;
            this.grcIsBreak.FieldName = "CheckBreak";
            this.grcIsBreak.MaxWidth = 35;
            this.grcIsBreak.MinWidth = 35;
            this.grcIsBreak.Name = "grcIsBreak";
            this.grcIsBreak.Visible = true;
            this.grcIsBreak.VisibleIndex = 6;
            this.grcIsBreak.Width = 35;
            // 
            // rpi_chk_IsBreak
            // 
            this.rpi_chk_IsBreak.AutoHeight = false;
            this.rpi_chk_IsBreak.Name = "rpi_chk_IsBreak";
            this.rpi_chk_IsBreak.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.rpi_chk_IsBreak.CheckedChanged += new System.EventHandler(this.rpi_chk_IsBreak_CheckedChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "DISPATCHING ORDER DETAIL ID";
            this.gridColumn1.FieldName = "DispatchingOrderDetailID";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 10);
            this.layoutControlGroup1.Size = new System.Drawing.Size(972, 615);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.grdDispatchingOrderDetailBreak;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(952, 595);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // urc_WM_DODetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "urc_WM_DODetail";
            this.Size = new System.Drawing.Size(972, 615);
            this.Load += new System.EventHandler(this.urc_WM_DODetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDispatchingOrderDetailBreak)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDispatchingOrderDetailBreak)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_chk_IsBreak)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl grdDispatchingOrderDetailBreak;
        private Common.Controls.WMSGridView grvDispatchingOrderDetailBreak;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Columns.GridColumn grcProductNumber;
        private DevExpress.XtraGrid.Columns.GridColumn grcBreakRONumber;
        private DevExpress.XtraGrid.Columns.GridColumn grcBreakQty;
        private DevExpress.XtraGrid.Columns.GridColumn grcBreakPalletID;
        private DevExpress.XtraGrid.Columns.GridColumn grcTotalUnit;
        private DevExpress.XtraGrid.Columns.GridColumn grcPalletWeight;
        private DevExpress.XtraGrid.Columns.GridColumn grcIsBreak;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rpi_chk_IsBreak;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    }
}
