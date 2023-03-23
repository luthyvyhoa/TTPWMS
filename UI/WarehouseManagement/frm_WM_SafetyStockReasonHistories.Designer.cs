namespace UI.WarehouseManagement
{
    partial class frm_WM_SafetyStockReasonHistories
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_WM_SafetyStockReasonHistories));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grdReasonHistory = new DevExpress.XtraGrid.GridControl();
            this.grvReasonHistory = new Common.Controls.WMSGridView();
            this.grcReason = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcProductID6_Stock = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcProductIDPack_Stock = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcProductID2_Stock = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcReasonTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcOwner = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdReasonHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvReasonHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
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
            this.rbcbase.Size = new System.Drawing.Size(722, 51);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grdReasonHistory);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 51);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(722, 368);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grdReasonHistory
            // 
            this.grdReasonHistory.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grdReasonHistory.Location = new System.Drawing.Point(12, 12);
            this.grdReasonHistory.MainView = this.grvReasonHistory;
            this.grdReasonHistory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdReasonHistory.MenuManager = this.rbcbase;
            this.grdReasonHistory.Name = "grdReasonHistory";
            this.grdReasonHistory.Size = new System.Drawing.Size(698, 344);
            this.grdReasonHistory.TabIndex = 4;
            this.grdReasonHistory.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvReasonHistory});
            // 
            // grvReasonHistory
            // 
            this.grvReasonHistory.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grvReasonHistory.Appearance.FooterPanel.Options.UseFont = true;
            this.grvReasonHistory.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvReasonHistory.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grcReason,
            this.grcProductID6_Stock,
            this.grcProductIDPack_Stock,
            this.grcProductID2_Stock,
            this.grcReasonTime,
            this.grcOwner});
            this.grvReasonHistory.GridControl = this.grdReasonHistory;
            this.grvReasonHistory.Name = "grvReasonHistory";
            this.grvReasonHistory.OptionsBehavior.ReadOnly = true;
            this.grvReasonHistory.OptionsView.ShowGroupPanel = false;
            this.grvReasonHistory.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvReasonHistory.PaintStyleName = "Skin";
            // 
            // grcReason
            // 
            this.grcReason.Caption = "REASON";
            this.grcReason.FieldName = "Reason";
            this.grcReason.Name = "grcReason";
            this.grcReason.Visible = true;
            this.grcReason.VisibleIndex = 0;
            this.grcReason.Width = 204;
            // 
            // grcProductID6_Stock
            // 
            this.grcProductID6_Stock.Caption = "ID6-STOCK";
            this.grcProductID6_Stock.FieldName = "ProductID6_Stock";
            this.grcProductID6_Stock.Name = "grcProductID6_Stock";
            this.grcProductID6_Stock.Visible = true;
            this.grcProductID6_Stock.VisibleIndex = 1;
            this.grcProductID6_Stock.Width = 71;
            // 
            // grcProductIDPack_Stock
            // 
            this.grcProductIDPack_Stock.Caption = "IDPACK-STOCK";
            this.grcProductIDPack_Stock.FieldName = "ProductIDPack_Stock";
            this.grcProductIDPack_Stock.Name = "grcProductIDPack_Stock";
            this.grcProductIDPack_Stock.Visible = true;
            this.grcProductIDPack_Stock.VisibleIndex = 2;
            this.grcProductIDPack_Stock.Width = 85;
            // 
            // grcProductID2_Stock
            // 
            this.grcProductID2_Stock.Caption = "ID2-STOCK";
            this.grcProductID2_Stock.FieldName = "ProductID2_Stock";
            this.grcProductID2_Stock.Name = "grcProductID2_Stock";
            this.grcProductID2_Stock.Visible = true;
            this.grcProductID2_Stock.VisibleIndex = 3;
            this.grcProductID2_Stock.Width = 65;
            // 
            // grcReasonTime
            // 
            this.grcReasonTime.Caption = "TIME";
            this.grcReasonTime.FieldName = "ReasonTime";
            this.grcReasonTime.Name = "grcReasonTime";
            this.grcReasonTime.Visible = true;
            this.grcReasonTime.VisibleIndex = 4;
            this.grcReasonTime.Width = 113;
            // 
            // grcOwner
            // 
            this.grcOwner.Caption = "OWNER";
            this.grcOwner.FieldName = "Owner";
            this.grcOwner.Name = "grcOwner";
            this.grcOwner.Visible = true;
            this.grcOwner.VisibleIndex = 5;
            this.grcOwner.Width = 63;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(722, 368);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdReasonHistory;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(702, 348);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // frm_WM_SafetyStockReasonHistories
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 419);
            this.Controls.Add(this.layoutControl1);
            this.Enabled = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_WM_SafetyStockReasonHistories.IconOptions.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_WM_SafetyStockReasonHistories";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "Reason";
            this.Load += new System.EventHandler(this.frm_WM_SafetyStockReasonHistories_Load);
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdReasonHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvReasonHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl grdReasonHistory;
        private Common.Controls.WMSGridView grvReasonHistory;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn grcReason;
        private DevExpress.XtraGrid.Columns.GridColumn grcProductID6_Stock;
        private DevExpress.XtraGrid.Columns.GridColumn grcProductIDPack_Stock;
        private DevExpress.XtraGrid.Columns.GridColumn grcProductID2_Stock;
        private DevExpress.XtraGrid.Columns.GridColumn grcReasonTime;
        private DevExpress.XtraGrid.Columns.GridColumn grcOwner;
    }
}