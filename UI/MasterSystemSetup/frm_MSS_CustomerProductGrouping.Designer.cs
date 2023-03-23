namespace UI.MasterSystemSetup
{
    partial class frm_MSS_CustomerProductGrouping
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_MSS_CustomerProductGrouping));
            this.grd_ProductGrouping = new DevExpress.XtraGrid.GridControl();
            this.grvProductGrouping = new Common.Controls.WMSGridView();
            this.grcProductGroupID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcProductGroupDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcDefault = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_chk_Default = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_lke_CustomerID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_ProductGrouping)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProductGrouping)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_chk_Default)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_CustomerID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
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
            this.rbcbase.Size = new System.Drawing.Size(741, 51);
            // 
            // grd_ProductGrouping
            // 
            this.grd_ProductGrouping.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grd_ProductGrouping.Location = new System.Drawing.Point(23, 24);
            this.grd_ProductGrouping.MainView = this.grvProductGrouping;
            this.grd_ProductGrouping.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grd_ProductGrouping.MenuManager = this.rbcbase;
            this.grd_ProductGrouping.Name = "grd_ProductGrouping";
            this.grd_ProductGrouping.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpi_chk_Default,
            this.rpi_lke_CustomerID});
            this.grd_ProductGrouping.Size = new System.Drawing.Size(695, 386);
            this.grd_ProductGrouping.TabIndex = 1;
            this.grd_ProductGrouping.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvProductGrouping});
            // 
            // grvProductGrouping
            // 
            this.grvProductGrouping.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grvProductGrouping.Appearance.FooterPanel.Options.UseFont = true;
            this.grvProductGrouping.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvProductGrouping.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grcProductGroupID,
            this.grcProductGroupDesc,
            this.grcDefault,
            this.gridColumn1});
            this.grvProductGrouping.FixedLineWidth = 3;
            this.grvProductGrouping.GridControl = this.grd_ProductGrouping;
            this.grvProductGrouping.Name = "grvProductGrouping";
            this.grvProductGrouping.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grvProductGrouping.OptionsSelection.CheckBoxSelectorColumnWidth = 30;
            this.grvProductGrouping.OptionsSelection.MultiSelect = true;
            this.grvProductGrouping.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.grvProductGrouping.OptionsView.ShowGroupPanel = false;
            this.grvProductGrouping.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvProductGrouping.PaintStyleName = "Skin";
            this.grvProductGrouping.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvProductGrouping_CellValueChanged);
            this.grvProductGrouping.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvProductGrouping_KeyDown);
            // 
            // grcProductGroupID
            // 
            this.grcProductGroupID.AppearanceCell.Options.UseTextOptions = true;
            this.grcProductGroupID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcProductGroupID.AppearanceHeader.Options.UseTextOptions = true;
            this.grcProductGroupID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcProductGroupID.Caption = "ID";
            this.grcProductGroupID.FieldName = "ProductGroupID";
            this.grcProductGroupID.Name = "grcProductGroupID";
            this.grcProductGroupID.Width = 48;
            // 
            // grcProductGroupDesc
            // 
            this.grcProductGroupDesc.Caption = "DESCRIPTION";
            this.grcProductGroupDesc.FieldName = "ProductGroupDescription";
            this.grcProductGroupDesc.Name = "grcProductGroupDesc";
            this.grcProductGroupDesc.Visible = true;
            this.grcProductGroupDesc.VisibleIndex = 2;
            this.grcProductGroupDesc.Width = 385;
            // 
            // grcDefault
            // 
            this.grcDefault.AppearanceHeader.Options.UseTextOptions = true;
            this.grcDefault.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcDefault.Caption = "DEFAULT";
            this.grcDefault.ColumnEdit = this.rpi_chk_Default;
            this.grcDefault.FieldName = "ISDefault";
            this.grcDefault.Name = "grcDefault";
            this.grcDefault.Visible = true;
            this.grcDefault.VisibleIndex = 3;
            this.grcDefault.Width = 89;
            // 
            // rpi_chk_Default
            // 
            this.rpi_chk_Default.AutoHeight = false;
            this.rpi_chk_Default.Caption = "";
            this.rpi_chk_Default.Name = "rpi_chk_Default";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Customer ID";
            this.gridColumn1.ColumnEdit = this.rpi_lke_CustomerID;
            this.gridColumn1.FieldName = "CustomerID";
            this.gridColumn1.MinWidth = 25;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 109;
            // 
            // rpi_lke_CustomerID
            // 
            this.rpi_lke_CustomerID.AutoHeight = false;
            this.rpi_lke_CustomerID.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.rpi_lke_CustomerID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpi_lke_CustomerID.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerID", "CustomerID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerNumber", "CustomerNumber"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerName", "CustomerName")});
            this.rpi_lke_CustomerID.DropDownRows = 20;
            this.rpi_lke_CustomerID.ImmediatePopup = true;
            this.rpi_lke_CustomerID.Name = "rpi_lke_CustomerID";
            this.rpi_lke_CustomerID.NullText = "";
            this.rpi_lke_CustomerID.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.StartsWith;
            this.rpi_lke_CustomerID.PopupWidthMode = DevExpress.XtraEditors.PopupWidthMode.ContentWidth;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grd_ProductGrouping);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 51);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(741, 434);
            this.layoutControl1.TabIndex = 2;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(741, 434);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grd_ProductGrouping;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(13, 13, 14, 14);
            this.layoutControlItem1.Size = new System.Drawing.Size(721, 414);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // frm_MSS_CustomerProductGrouping
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 485);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_MSS_CustomerProductGrouping.IconOptions.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(350, 300);
            this.Name = "frm_MSS_CustomerProductGrouping";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "Customer Product Grouping";
            this.Load += new System.EventHandler(this.frm_MSS_CustomerProductGrouping_Load);
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_ProductGrouping)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProductGrouping)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_chk_Default)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_CustomerID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grd_ProductGrouping;
        private Common.Controls.WMSGridView grvProductGrouping;
        private DevExpress.XtraGrid.Columns.GridColumn grcProductGroupID;
        private DevExpress.XtraGrid.Columns.GridColumn grcProductGroupDesc;
        private DevExpress.XtraGrid.Columns.GridColumn grcDefault;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rpi_chk_Default;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpi_lke_CustomerID;
    }
}