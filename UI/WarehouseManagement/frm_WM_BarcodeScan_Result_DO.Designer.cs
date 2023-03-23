namespace UI.WarehouseManagement
{
    partial class frm_WM_BarcodeScan_Result_DO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_WM_BarcodeScan_Result_DO));
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gv_BarcodeResult = new Common.Controls.WMSGridView();
            this.grdC_ProductNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdC_ProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdC_PalletID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdC_Label = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdC_QuantityOfPackages = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdC_ScannedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdC_CreatedTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdC_Result = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdC_Remark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_BarcodeResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // rbcbase
            // 
            this.rbcbase.ExpandCollapseItem.Id = 0;
            this.rbcbase.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbcbase.OptionsCustomizationForm.FormIcon = ((System.Drawing.Icon)(resources.GetObject("resource.FormIcon")));
            // 
            // 
            // 
            this.rbcbase.SearchEditItem.AccessibleName = "Search Item";
            this.rbcbase.SearchEditItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.rbcbase.SearchEditItem.EditWidth = 150;
            this.rbcbase.SearchEditItem.Id = -5000;
            this.rbcbase.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.rbcbase.Size = new System.Drawing.Size(1292, 51);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1292, 527);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 5);
            this.layoutControlItem1.Size = new System.Drawing.Size(1272, 467);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // gridControl1
            // 
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gridControl1.Location = new System.Drawing.Point(20, 20);
            this.gridControl1.MainView = this.gv_BarcodeResult;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl1.MenuManager = this.rbcbase;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1252, 452);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_BarcodeResult});
            // 
            // gv_BarcodeResult
            // 
            this.gv_BarcodeResult.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.gv_BarcodeResult.Appearance.FooterPanel.Options.UseFont = true;
            this.gv_BarcodeResult.Appearance.HeaderPanel.Options.UseFont = true;
            this.gv_BarcodeResult.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdC_ProductNumber,
            this.grdC_ProductName,
            this.grdC_PalletID,
            this.grdC_Label,
            this.grdC_QuantityOfPackages,
            this.grdC_ScannedBy,
            this.grdC_CreatedTime,
            this.grdC_Result,
            this.grdC_Remark});
            this.gv_BarcodeResult.GridControl = this.gridControl1;
            this.gv_BarcodeResult.Name = "gv_BarcodeResult";
            this.gv_BarcodeResult.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.gv_BarcodeResult.OptionsSelection.MultiSelect = true;
            this.gv_BarcodeResult.OptionsView.ShowFooter = true;
            this.gv_BarcodeResult.OptionsView.ShowGroupPanel = false;
            this.gv_BarcodeResult.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gv_BarcodeResult.PaintStyleName = "Skin";
            // 
            // grdC_ProductNumber
            // 
            this.grdC_ProductNumber.AppearanceCell.Options.UseTextOptions = true;
            this.grdC_ProductNumber.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.grdC_ProductNumber.AppearanceHeader.Options.UseTextOptions = true;
            this.grdC_ProductNumber.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdC_ProductNumber.Caption = "PRODUCT ID";
            this.grdC_ProductNumber.FieldName = "ProductNumber";
            this.grdC_ProductNumber.Name = "grdC_ProductNumber";
            this.grdC_ProductNumber.Visible = true;
            this.grdC_ProductNumber.VisibleIndex = 0;
            this.grdC_ProductNumber.Width = 98;
            // 
            // grdC_ProductName
            // 
            this.grdC_ProductName.AppearanceCell.Options.UseTextOptions = true;
            this.grdC_ProductName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.grdC_ProductName.AppearanceHeader.Options.UseTextOptions = true;
            this.grdC_ProductName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdC_ProductName.Caption = "PRODUCT NAME";
            this.grdC_ProductName.FieldName = "ProductName";
            this.grdC_ProductName.Name = "grdC_ProductName";
            this.grdC_ProductName.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ProductName", "OK: Correct; NO: Incorrect;  XX:Manual check ; Empty, Waitng            Total:")});
            this.grdC_ProductName.Visible = true;
            this.grdC_ProductName.VisibleIndex = 1;
            this.grdC_ProductName.Width = 476;
            // 
            // grdC_PalletID
            // 
            this.grdC_PalletID.AppearanceCell.Options.UseTextOptions = true;
            this.grdC_PalletID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdC_PalletID.AppearanceHeader.Options.UseTextOptions = true;
            this.grdC_PalletID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdC_PalletID.Caption = "PALLET ID";
            this.grdC_PalletID.FieldName = "PalletID";
            this.grdC_PalletID.Name = "grdC_PalletID";
            this.grdC_PalletID.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "PalletID", "{0}")});
            this.grdC_PalletID.Visible = true;
            this.grdC_PalletID.VisibleIndex = 2;
            this.grdC_PalletID.Width = 72;
            // 
            // grdC_Label
            // 
            this.grdC_Label.AppearanceCell.Options.UseTextOptions = true;
            this.grdC_Label.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdC_Label.AppearanceHeader.Options.UseTextOptions = true;
            this.grdC_Label.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdC_Label.Caption = "LOCATION";
            this.grdC_Label.FieldName = "Label";
            this.grdC_Label.Name = "grdC_Label";
            this.grdC_Label.Visible = true;
            this.grdC_Label.VisibleIndex = 3;
            this.grdC_Label.Width = 74;
            // 
            // grdC_QuantityOfPackages
            // 
            this.grdC_QuantityOfPackages.AppearanceCell.Options.UseTextOptions = true;
            this.grdC_QuantityOfPackages.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdC_QuantityOfPackages.AppearanceHeader.Options.UseTextOptions = true;
            this.grdC_QuantityOfPackages.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdC_QuantityOfPackages.Caption = "QTY";
            this.grdC_QuantityOfPackages.FieldName = "QuantityOfPackages";
            this.grdC_QuantityOfPackages.Name = "grdC_QuantityOfPackages";
            this.grdC_QuantityOfPackages.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "QuantityOfPackages", "{0:0.##}")});
            this.grdC_QuantityOfPackages.Visible = true;
            this.grdC_QuantityOfPackages.VisibleIndex = 4;
            this.grdC_QuantityOfPackages.Width = 50;
            // 
            // grdC_ScannedBy
            // 
            this.grdC_ScannedBy.AppearanceHeader.Options.UseTextOptions = true;
            this.grdC_ScannedBy.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdC_ScannedBy.Caption = "USER";
            this.grdC_ScannedBy.FieldName = "ScannedBy";
            this.grdC_ScannedBy.Name = "grdC_ScannedBy";
            this.grdC_ScannedBy.Visible = true;
            this.grdC_ScannedBy.VisibleIndex = 5;
            this.grdC_ScannedBy.Width = 58;
            // 
            // grdC_CreatedTime
            // 
            this.grdC_CreatedTime.Caption = "SCANNED TIME";
            this.grdC_CreatedTime.FieldName = "CreatedTime";
            this.grdC_CreatedTime.Name = "grdC_CreatedTime";
            this.grdC_CreatedTime.Visible = true;
            this.grdC_CreatedTime.VisibleIndex = 6;
            this.grdC_CreatedTime.Width = 89;
            // 
            // grdC_Result
            // 
            this.grdC_Result.AppearanceHeader.Options.UseTextOptions = true;
            this.grdC_Result.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdC_Result.Caption = "RESULT";
            this.grdC_Result.FieldName = "Result";
            this.grdC_Result.Name = "grdC_Result";
            this.grdC_Result.Visible = true;
            this.grdC_Result.VisibleIndex = 7;
            this.grdC_Result.Width = 77;
            // 
            // grdC_Remark
            // 
            this.grdC_Remark.AppearanceHeader.Options.UseTextOptions = true;
            this.grdC_Remark.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdC_Remark.Caption = "REMARK";
            this.grdC_Remark.FieldName = "Remark";
            this.grdC_Remark.Name = "grdC_Remark";
            this.grdC_Remark.Visible = true;
            this.grdC_Remark.VisibleIndex = 8;
            this.grdC_Remark.Width = 144;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.simpleButton1;
            this.layoutControlItem2.Location = new System.Drawing.Point(1144, 467);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(128, 40);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(1156, 479);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(0);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(124, 36);
            this.simpleButton1.StyleController = this.layoutControl1;
            this.simpleButton1.TabIndex = 5;
            this.simpleButton1.Text = "Checked";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.simpleButton1);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 51);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(346, 99, 450, 400);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1292, 527);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 467);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(1144, 40);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frm_WM_BarcodeScan_Result_DO
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1292, 578);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_WM_BarcodeScan_Result_DO.IconOptions.Icon")));
            this.IsFixHeightScreen = false;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_WM_BarcodeScan_Result_DO";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "DO - Barcode Scan Results";
            this.Load += new System.EventHandler(this.frm_WM_BarcodeScan_Result_DO_Load);
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_BarcodeResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private Common.Controls.WMSGridView gv_BarcodeResult;
        private DevExpress.XtraGrid.Columns.GridColumn grdC_ProductNumber;
        private DevExpress.XtraGrid.Columns.GridColumn grdC_ProductName;
        private DevExpress.XtraGrid.Columns.GridColumn grdC_PalletID;
        private DevExpress.XtraGrid.Columns.GridColumn grdC_Label;
        private DevExpress.XtraGrid.Columns.GridColumn grdC_QuantityOfPackages;
        private DevExpress.XtraGrid.Columns.GridColumn grdC_ScannedBy;
        private DevExpress.XtraGrid.Columns.GridColumn grdC_CreatedTime;
        private DevExpress.XtraGrid.Columns.GridColumn grdC_Result;
        private DevExpress.XtraGrid.Columns.GridColumn grdC_Remark;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;

    }
}