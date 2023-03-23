namespace UI.WarehouseManagement
{
    partial class frm_WM_SafetyStockEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_WM_SafetyStockEntry));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grdSafetyStock = new DevExpress.XtraGrid.GridControl();
            this.grvSafetyStock = new Common.Controls.WMSGridView();
            this.grcProductNumber6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_lke_ProductNumber6 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.grcProductName6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcSafetyStock = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_spe_SafetyStock = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.grcProductNumber2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_lke_ProductNumber2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.grcProductNumberP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_lke_ProductNumberP = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.grcRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcSafetyStockID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcIdOuter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_lke_IdOuter = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSafetyStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSafetyStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_ProductNumber6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_spe_SafetyStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_ProductNumber2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_ProductNumberP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_IdOuter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // rbcbase
            // 
            this.rbcbase.ExpandCollapseItem.Id = 0;
            this.rbcbase.OptionsCustomizationForm.FormIcon = ((System.Drawing.Icon)(resources.GetObject("resource.FormIcon")));
            // 
            // 
            // 
            this.rbcbase.SearchEditItem.AccessibleName = "Search Item";
            this.rbcbase.SearchEditItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.rbcbase.SearchEditItem.EditWidth = 150;
            this.rbcbase.SearchEditItem.Id = -5000;
            this.rbcbase.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.rbcbase.Size = new System.Drawing.Size(1251, 51);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grdSafetyStock);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 51);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1251, 394);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grdSafetyStock
            // 
            this.grdSafetyStock.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.grdSafetyStock.Location = new System.Drawing.Point(12, 12);
            this.grdSafetyStock.MainView = this.grvSafetyStock;
            this.grdSafetyStock.MenuManager = this.rbcbase;
            this.grdSafetyStock.Name = "grdSafetyStock";
            this.grdSafetyStock.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpi_lke_ProductNumber6,
            this.rpi_lke_ProductNumber2,
            this.rpi_lke_ProductNumberP,
            this.rpi_spe_SafetyStock,
            this.rpi_lke_IdOuter});
            this.grdSafetyStock.Size = new System.Drawing.Size(1227, 370);
            this.grdSafetyStock.TabIndex = 4;
            this.grdSafetyStock.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvSafetyStock});
            // 
            // grvSafetyStock
            // 
            this.grvSafetyStock.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grvSafetyStock.Appearance.FooterPanel.Options.UseFont = true;
            this.grvSafetyStock.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvSafetyStock.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grcProductNumber6,
            this.grcProductName6,
            this.grcSafetyStock,
            this.grcProductNumber2,
            this.grcProductNumberP,
            this.grcRemark,
            this.grcSafetyStockID,
            this.grcIdOuter});
            this.grvSafetyStock.FixedLineWidth = 3;
            this.grvSafetyStock.GridControl = this.grdSafetyStock;
            this.grvSafetyStock.Name = "grvSafetyStock";
            this.grvSafetyStock.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.grvSafetyStock.OptionsView.ShowGroupPanel = false;
            this.grvSafetyStock.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvSafetyStock.PaintStyleName = "Skin";
            this.grvSafetyStock.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.grvSafetyStock_InitNewRow);
            // 
            // grcProductNumber6
            // 
            this.grcProductNumber6.AppearanceHeader.Options.UseTextOptions = true;
            this.grcProductNumber6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcProductNumber6.Caption = "ID-6";
            this.grcProductNumber6.ColumnEdit = this.rpi_lke_ProductNumber6;
            this.grcProductNumber6.FieldName = "ProductID6";
            this.grcProductNumber6.MaxWidth = 120;
            this.grcProductNumber6.MinWidth = 120;
            this.grcProductNumber6.Name = "grcProductNumber6";
            this.grcProductNumber6.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.grcProductNumber6.Visible = true;
            this.grcProductNumber6.VisibleIndex = 0;
            this.grcProductNumber6.Width = 120;
            // 
            // rpi_lke_ProductNumber6
            // 
            this.rpi_lke_ProductNumber6.AutoHeight = false;
            this.rpi_lke_ProductNumber6.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpi_lke_ProductNumber6.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProductID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProductNumberEx", "Number", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProductName", "Name", 250, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.rpi_lke_ProductNumber6.DropDownRows = 20;
            this.rpi_lke_ProductNumber6.Name = "rpi_lke_ProductNumber6";
            this.rpi_lke_ProductNumber6.NullText = "";
            this.rpi_lke_ProductNumber6.PopupFormMinSize = new System.Drawing.Size(349, 0);
            this.rpi_lke_ProductNumber6.ShowFooter = false;
            this.rpi_lke_ProductNumber6.ShowHeader = false;
            // 
            // grcProductName6
            // 
            this.grcProductName6.Caption = "PRODUCT NAME";
            this.grcProductName6.FieldName = "ProductName6";
            this.grcProductName6.Name = "grcProductName6";
            this.grcProductName6.Visible = true;
            this.grcProductName6.VisibleIndex = 1;
            this.grcProductName6.Width = 341;
            // 
            // grcSafetyStock
            // 
            this.grcSafetyStock.AppearanceCell.Options.UseTextOptions = true;
            this.grcSafetyStock.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcSafetyStock.AppearanceHeader.Options.UseTextOptions = true;
            this.grcSafetyStock.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcSafetyStock.Caption = "SAFETY STOCK";
            this.grcSafetyStock.ColumnEdit = this.rpi_spe_SafetyStock;
            this.grcSafetyStock.FieldName = "SafetyStock";
            this.grcSafetyStock.MaxWidth = 120;
            this.grcSafetyStock.MinWidth = 120;
            this.grcSafetyStock.Name = "grcSafetyStock";
            this.grcSafetyStock.Visible = true;
            this.grcSafetyStock.VisibleIndex = 2;
            this.grcSafetyStock.Width = 120;
            // 
            // rpi_spe_SafetyStock
            // 
            this.rpi_spe_SafetyStock.AutoHeight = false;
            this.rpi_spe_SafetyStock.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpi_spe_SafetyStock.Mask.EditMask = "n0";
            this.rpi_spe_SafetyStock.Mask.UseMaskAsDisplayFormat = true;
            this.rpi_spe_SafetyStock.MaxValue = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.rpi_spe_SafetyStock.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.rpi_spe_SafetyStock.Name = "rpi_spe_SafetyStock";
            // 
            // grcProductNumber2
            // 
            this.grcProductNumber2.AppearanceHeader.Options.UseTextOptions = true;
            this.grcProductNumber2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcProductNumber2.Caption = "ID-2";
            this.grcProductNumber2.ColumnEdit = this.rpi_lke_ProductNumber2;
            this.grcProductNumber2.FieldName = "ProductID2";
            this.grcProductNumber2.MaxWidth = 120;
            this.grcProductNumber2.MinWidth = 120;
            this.grcProductNumber2.Name = "grcProductNumber2";
            this.grcProductNumber2.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.grcProductNumber2.Visible = true;
            this.grcProductNumber2.VisibleIndex = 3;
            this.grcProductNumber2.Width = 120;
            // 
            // rpi_lke_ProductNumber2
            // 
            this.rpi_lke_ProductNumber2.AutoHeight = false;
            this.rpi_lke_ProductNumber2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpi_lke_ProductNumber2.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProductID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProductNumberEx", "Number", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProductName", "Name", 250, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.rpi_lke_ProductNumber2.DropDownRows = 20;
            this.rpi_lke_ProductNumber2.Name = "rpi_lke_ProductNumber2";
            this.rpi_lke_ProductNumber2.NullText = "";
            this.rpi_lke_ProductNumber2.PopupFormMinSize = new System.Drawing.Size(349, 0);
            this.rpi_lke_ProductNumber2.ShowFooter = false;
            this.rpi_lke_ProductNumber2.ShowHeader = false;
            // 
            // grcProductNumberP
            // 
            this.grcProductNumberP.AppearanceHeader.Options.UseTextOptions = true;
            this.grcProductNumberP.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcProductNumberP.Caption = "ID-PACK";
            this.grcProductNumberP.ColumnEdit = this.rpi_lke_ProductNumberP;
            this.grcProductNumberP.FieldName = "ProductIDPack";
            this.grcProductNumberP.MaxWidth = 120;
            this.grcProductNumberP.MinWidth = 120;
            this.grcProductNumberP.Name = "grcProductNumberP";
            this.grcProductNumberP.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.grcProductNumberP.Visible = true;
            this.grcProductNumberP.VisibleIndex = 4;
            this.grcProductNumberP.Width = 120;
            // 
            // rpi_lke_ProductNumberP
            // 
            this.rpi_lke_ProductNumberP.AutoHeight = false;
            this.rpi_lke_ProductNumberP.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpi_lke_ProductNumberP.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProductID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProductNumberEx", "Number", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProductName", "Name", 250, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.rpi_lke_ProductNumberP.DropDownRows = 20;
            this.rpi_lke_ProductNumberP.Name = "rpi_lke_ProductNumberP";
            this.rpi_lke_ProductNumberP.NullText = "";
            this.rpi_lke_ProductNumberP.PopupFormMinSize = new System.Drawing.Size(349, 0);
            this.rpi_lke_ProductNumberP.ShowFooter = false;
            this.rpi_lke_ProductNumberP.ShowHeader = false;
            // 
            // grcRemark
            // 
            this.grcRemark.Caption = "REMARK";
            this.grcRemark.FieldName = "Remark";
            this.grcRemark.Name = "grcRemark";
            this.grcRemark.Visible = true;
            this.grcRemark.VisibleIndex = 5;
            this.grcRemark.Width = 193;
            // 
            // grcSafetyStockID
            // 
            this.grcSafetyStockID.Caption = "ID";
            this.grcSafetyStockID.FieldName = "SafetyStockID";
            this.grcSafetyStockID.Name = "grcSafetyStockID";
            // 
            // grcIdOuter
            // 
            this.grcIdOuter.Caption = "ID-Outer";
            this.grcIdOuter.ColumnEdit = this.rpi_lke_IdOuter;
            this.grcIdOuter.FieldName = "ProductIDOuter";
            this.grcIdOuter.MinWidth = 27;
            this.grcIdOuter.Name = "grcIdOuter";
            this.grcIdOuter.Visible = true;
            this.grcIdOuter.VisibleIndex = 6;
            this.grcIdOuter.Width = 147;
            // 
            // rpi_lke_IdOuter
            // 
            this.rpi_lke_IdOuter.AutoHeight = false;
            this.rpi_lke_IdOuter.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpi_lke_IdOuter.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProductID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProductNumberEx", "Number", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProductName", "Name", 250, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.rpi_lke_IdOuter.DropDownRows = 20;
            this.rpi_lke_IdOuter.Name = "rpi_lke_IdOuter";
            this.rpi_lke_IdOuter.NullText = "";
            this.rpi_lke_IdOuter.PopupFormMinSize = new System.Drawing.Size(349, 0);
            this.rpi_lke_IdOuter.ShowFooter = false;
            this.rpi_lke_IdOuter.ShowHeader = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1251, 394);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdSafetyStock;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1231, 374);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // frm_WM_SafetyStockEntry
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1251, 445);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_WM_SafetyStockEntry.IconOptions.Icon")));
            this.Name = "frm_WM_SafetyStockEntry";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "Safety Stock Entry + Edit";
            this.Load += new System.EventHandler(this.frm_WM_SafetyStockEntry_Load);
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSafetyStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSafetyStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_ProductNumber6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_spe_SafetyStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_ProductNumber2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_ProductNumberP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_IdOuter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl grdSafetyStock;
        private Common.Controls.WMSGridView grvSafetyStock;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn grcProductNumber6;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpi_lke_ProductNumber6;
        private DevExpress.XtraGrid.Columns.GridColumn grcProductName6;
        private DevExpress.XtraGrid.Columns.GridColumn grcSafetyStock;
        private DevExpress.XtraGrid.Columns.GridColumn grcProductNumber2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpi_lke_ProductNumber2;
        private DevExpress.XtraGrid.Columns.GridColumn grcProductNumberP;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpi_lke_ProductNumberP;
        private DevExpress.XtraGrid.Columns.GridColumn grcRemark;
        private DevExpress.XtraGrid.Columns.GridColumn grcSafetyStockID;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit rpi_spe_SafetyStock;
        private DevExpress.XtraGrid.Columns.GridColumn grcIdOuter;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpi_lke_IdOuter;
    }
}