namespace UI.MasterSystemSetup
{
    partial class frm_MSS_CustomerRequirementViewAll
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
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition1 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition2 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition1 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition2 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition3 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement1 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement2 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement3 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement4 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_MSS_CustomerRequirementViewAll));
            this.colRequirementCategory = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colRequirementDetails = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colUpdateBy = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colUpdateTime = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.CustomerRequirementTileView = new DevExpress.XtraGrid.Views.Tile.TileView();
            this.colCustomerRequirementID = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colCustomerMainID = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerRequirementTileView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // colRequirementCategory
            // 
            this.colRequirementCategory.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.colRequirementCategory.FieldName = "RequirementCategory";
            this.colRequirementCategory.MinWidth = 22;
            this.colRequirementCategory.Name = "colRequirementCategory";
            this.colRequirementCategory.Visible = true;
            this.colRequirementCategory.VisibleIndex = 2;
            this.colRequirementCategory.Width = 84;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            // 
            // colRequirementDetails
            // 
            this.colRequirementDetails.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colRequirementDetails.FieldName = "RequirementDetails";
            this.colRequirementDetails.MinWidth = 22;
            this.colRequirementDetails.Name = "colRequirementDetails";
            this.colRequirementDetails.Visible = true;
            this.colRequirementDetails.VisibleIndex = 3;
            this.colRequirementDetails.Width = 84;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // colUpdateBy
            // 
            this.colUpdateBy.FieldName = "UpdateBy";
            this.colUpdateBy.MinWidth = 22;
            this.colUpdateBy.Name = "colUpdateBy";
            this.colUpdateBy.Visible = true;
            this.colUpdateBy.VisibleIndex = 4;
            this.colUpdateBy.Width = 84;
            // 
            // colUpdateTime
            // 
            this.colUpdateTime.FieldName = "UpdateTime";
            this.colUpdateTime.MinWidth = 22;
            this.colUpdateTime.Name = "colUpdateTime";
            this.colUpdateTime.Visible = true;
            this.colUpdateTime.VisibleIndex = 5;
            this.colUpdateTime.Width = 84;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1426, 751);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = typeof(DA.CustomerRequirements);
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.Location = new System.Drawing.Point(12, 13);
            this.gridControl1.MainView = this.CustomerRequirementTileView;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1,
            this.repositoryItemLookUpEdit1});
            this.gridControl1.Size = new System.Drawing.Size(1402, 725);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.CustomerRequirementTileView});
            // 
            // CustomerRequirementTileView
            // 
            //this.CustomerRequirementTileView.Appearance.Group.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            //this.CustomerRequirementTileView.Appearance.Group.Options.UseFont = true;
            this.CustomerRequirementTileView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCustomerRequirementID,
            this.colCustomerMainID,
            this.colRequirementCategory,
            this.colRequirementDetails,
            this.colUpdateBy,
            this.colUpdateTime});
            this.CustomerRequirementTileView.ColumnSet.GroupColumn = this.colRequirementCategory;
            this.CustomerRequirementTileView.DetailHeight = 437;
            this.CustomerRequirementTileView.GridControl = this.gridControl1;
            this.CustomerRequirementTileView.Name = "CustomerRequirementTileView";
            this.CustomerRequirementTileView.OptionsTiles.ItemSize = new System.Drawing.Size(248, 220);
            this.CustomerRequirementTileView.OptionsTiles.LayoutMode = DevExpress.XtraGrid.Views.Tile.TileViewLayoutMode.Kanban;
            this.CustomerRequirementTileView.OptionsTiles.RowCount = 0;
            this.CustomerRequirementTileView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colRequirementCategory, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.CustomerRequirementTileView.TileColumns.Add(tableColumnDefinition1);
            this.CustomerRequirementTileView.TileColumns.Add(tableColumnDefinition2);
            this.CustomerRequirementTileView.TileRows.Add(tableRowDefinition1);
            this.CustomerRequirementTileView.TileRows.Add(tableRowDefinition2);
            this.CustomerRequirementTileView.TileRows.Add(tableRowDefinition3);
            tileViewItemElement1.Column = this.colRequirementCategory;
            tileViewItemElement1.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement1.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement1.Text = "colRequirementCategory";
            tileViewItemElement1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement2.Column = this.colRequirementDetails;
            tileViewItemElement2.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement2.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement2.RowIndex = 1;
            tileViewItemElement2.Text = "colRequirementDetails";
            tileViewItemElement2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement3.Column = this.colUpdateBy;
            tileViewItemElement3.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement3.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement3.RowIndex = 2;
            tileViewItemElement3.Text = "colUpdateBy";
            tileViewItemElement3.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement4.Column = this.colUpdateTime;
            tileViewItemElement4.ColumnIndex = 1;
            tileViewItemElement4.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement4.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement4.RowIndex = 2;
            tileViewItemElement4.Text = "colUpdateTime";
            tileViewItemElement4.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            this.CustomerRequirementTileView.TileTemplate.Add(tileViewItemElement1);
            this.CustomerRequirementTileView.TileTemplate.Add(tileViewItemElement2);
            this.CustomerRequirementTileView.TileTemplate.Add(tileViewItemElement3);
            this.CustomerRequirementTileView.TileTemplate.Add(tileViewItemElement4);
            // 
            // colCustomerRequirementID
            // 
            this.colCustomerRequirementID.FieldName = "CustomerRequirementID";
            this.colCustomerRequirementID.MinWidth = 22;
            this.colCustomerRequirementID.Name = "colCustomerRequirementID";
            this.colCustomerRequirementID.Visible = true;
            this.colCustomerRequirementID.VisibleIndex = 0;
            this.colCustomerRequirementID.Width = 84;
            // 
            // colCustomerMainID
            // 
            this.colCustomerMainID.FieldName = "CustomerMainID";
            this.colCustomerMainID.MinWidth = 22;
            this.colCustomerMainID.Name = "colCustomerMainID";
            this.colCustomerMainID.Visible = true;
            this.colCustomerMainID.VisibleIndex = 1;
            this.colCustomerMainID.Width = 84;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1426, 751);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1406, 729);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // frm_MSS_CustomerRequirementViewAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1426, 751);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frm_MSS_CustomerRequirementViewAll";
            this.Text = "Customer Requirements";
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerRequirementTileView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Tile.TileView CustomerRequirementTileView;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.TileViewColumn colCustomerRequirementID;
        private DevExpress.XtraGrid.Columns.TileViewColumn colCustomerMainID;
        private DevExpress.XtraGrid.Columns.TileViewColumn colRequirementCategory;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraGrid.Columns.TileViewColumn colRequirementDetails;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Columns.TileViewColumn colUpdateBy;
        private DevExpress.XtraGrid.Columns.TileViewColumn colUpdateTime;
    }
}