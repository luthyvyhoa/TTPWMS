namespace UI.MasterSystemSetup
{
    partial class urc_MSS_CustomerRequirementTiles
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
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition3 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition4 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition3 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition4 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement5 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement6 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement7 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement8 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            this.tileViewColumn3 = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.tileViewColumn4 = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.tileViewColumn5 = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grcCustomerRequirementTiles = new DevExpress.XtraGrid.GridControl();
            this.tileView1 = new DevExpress.XtraGrid.Views.Tile.TileView();
            this.tileViewColumn1 = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.tileViewColumn2 = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.tileViewColumn6 = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.tileViewColumn7 = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.Root1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcCustomerRequirementTiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // tileViewColumn3
            // 
            this.tileViewColumn3.FieldName = "RequirementDetails";
            this.tileViewColumn3.MinWidth = 19;
            this.tileViewColumn3.Name = "tileViewColumn3";
            this.tileViewColumn3.Visible = true;
            this.tileViewColumn3.VisibleIndex = 2;
            this.tileViewColumn3.Width = 70;
            // 
            // tileViewColumn4
            // 
            this.tileViewColumn4.FieldName = "UpdateBy";
            this.tileViewColumn4.MinWidth = 19;
            this.tileViewColumn4.Name = "tileViewColumn4";
            this.tileViewColumn4.Visible = true;
            this.tileViewColumn4.VisibleIndex = 3;
            this.tileViewColumn4.Width = 70;
            // 
            // tileViewColumn5
            // 
            this.tileViewColumn5.FieldName = "UpdateTime";
            this.tileViewColumn5.MinWidth = 19;
            this.tileViewColumn5.Name = "tileViewColumn5";
            this.tileViewColumn5.Visible = true;
            this.tileViewColumn5.VisibleIndex = 4;
            this.tileViewColumn5.Width = 70;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grcCustomerRequirementTiles);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1364, 551);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grcCustomerRequirementTiles
            // 
            this.grcCustomerRequirementTiles.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.grcCustomerRequirementTiles.Location = new System.Drawing.Point(22, 22);
            this.grcCustomerRequirementTiles.MainView = this.tileView1;
            this.grcCustomerRequirementTiles.Margin = new System.Windows.Forms.Padding(2);
            this.grcCustomerRequirementTiles.Name = "grcCustomerRequirementTiles";
            this.grcCustomerRequirementTiles.Size = new System.Drawing.Size(1320, 507);
            this.grcCustomerRequirementTiles.TabIndex = 4;
            this.grcCustomerRequirementTiles.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.tileView1});
            // 
            // tileView1
            // 
            this.tileView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.tileViewColumn1,
            this.tileViewColumn2,
            this.tileViewColumn3,
            this.tileViewColumn4,
            this.tileViewColumn5,
            this.tileViewColumn6,
            this.tileViewColumn7});
            this.tileView1.ColumnSet.CheckedColumn = this.tileViewColumn6;
            this.tileView1.ColumnSet.GroupColumn = this.tileViewColumn7;
            this.tileView1.DetailHeight = 284;
            this.tileView1.GridControl = this.grcCustomerRequirementTiles;
            this.tileView1.Name = "tileView1";
            this.tileView1.OptionsTiles.ColumnCount = 4;
            this.tileView1.OptionsTiles.ItemSize = new System.Drawing.Size(450, 180);
            this.tileView1.OptionsTiles.LayoutMode = DevExpress.XtraGrid.Views.Tile.TileViewLayoutMode.Kanban;
            this.tileView1.OptionsTiles.Padding = new System.Windows.Forms.Padding(5);
            this.tileView1.OptionsTiles.RowCount = 0;
            this.tileView1.OptionsTiles.VerticalContentAlignment = DevExpress.Utils.VertAlignment.Top;
            this.tileView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.tileViewColumn7, DevExpress.Data.ColumnSortOrder.Ascending)});
            tableColumnDefinition3.Length.Value = 150D;
            tableColumnDefinition4.Length.Value = 0D;
            this.tileView1.TileColumns.Add(tableColumnDefinition3);
            this.tileView1.TileColumns.Add(tableColumnDefinition4);
            tableRowDefinition3.Length.Value = 92D;
            tableRowDefinition4.Length.Value = 24D;
            this.tileView1.TileRows.Add(tableRowDefinition3);
            this.tileView1.TileRows.Add(tableRowDefinition4);
            tileViewItemElement5.Column = this.tileViewColumn3;
            tileViewItemElement5.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement5.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement5.StretchHorizontal = true;
            tileViewItemElement5.Text = "tileViewColumn3";
            tileViewItemElement5.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopLeft;
            tileViewItemElement6.AnchorAlignment = DevExpress.Utils.AnchorAlignment.Right;
            tileViewItemElement6.AnchorElementIndex = 3;
            tileViewItemElement6.AnchorIndent = 12;
            tileViewItemElement6.Column = this.tileViewColumn4;
            tileViewItemElement6.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement6.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement6.RowIndex = 1;
            tileViewItemElement6.Text = "tileViewColumn4";
            tileViewItemElement6.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleLeft;
            tileViewItemElement6.TextLocation = new System.Drawing.Point(150, 0);
            tileViewItemElement7.AnchorAlignment = DevExpress.Utils.AnchorAlignment.Right;
            tileViewItemElement7.AnchorElementIndex = 1;
            tileViewItemElement7.AnchorIndent = 20;
            tileViewItemElement7.Column = this.tileViewColumn5;
            tileViewItemElement7.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement7.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement7.RowIndex = 1;
            tileViewItemElement7.Text = "tileViewColumn5";
            tileViewItemElement7.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement8.AnchorAlignment = DevExpress.Utils.AnchorAlignment.Left;
            tileViewItemElement8.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement8.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement8.RowIndex = 1;
            tileViewItemElement8.Text = "Updated: ";
            tileViewItemElement8.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleLeft;
            this.tileView1.TileTemplate.Add(tileViewItemElement5);
            this.tileView1.TileTemplate.Add(tileViewItemElement6);
            this.tileView1.TileTemplate.Add(tileViewItemElement7);
            this.tileView1.TileTemplate.Add(tileViewItemElement8);
            // 
            // tileViewColumn1
            // 
            this.tileViewColumn1.FieldName = "CustomerRequirementID";
            this.tileViewColumn1.MinWidth = 19;
            this.tileViewColumn1.Name = "tileViewColumn1";
            this.tileViewColumn1.Visible = true;
            this.tileViewColumn1.VisibleIndex = 0;
            this.tileViewColumn1.Width = 70;
            // 
            // tileViewColumn2
            // 
            this.tileViewColumn2.FieldName = "CustomerMainID";
            this.tileViewColumn2.MinWidth = 19;
            this.tileViewColumn2.Name = "tileViewColumn2";
            this.tileViewColumn2.Visible = true;
            this.tileViewColumn2.VisibleIndex = 1;
            this.tileViewColumn2.Width = 70;
            // 
            // tileViewColumn6
            // 
            this.tileViewColumn6.FieldName = "RequirementConfirmed";
            this.tileViewColumn6.MinWidth = 19;
            this.tileViewColumn6.Name = "tileViewColumn6";
            this.tileViewColumn6.Visible = true;
            this.tileViewColumn6.VisibleIndex = 5;
            this.tileViewColumn6.Width = 70;
            // 
            // tileViewColumn7
            // 
            this.tileViewColumn7.Caption = "Category";
            this.tileViewColumn7.FieldName = "RequirementCategory";
            this.tileViewColumn7.MinWidth = 19;
            this.tileViewColumn7.Name = "tileViewColumn7";
            this.tileViewColumn7.OptionsColumn.ShowCaption = true;
            this.tileViewColumn7.Visible = true;
            this.tileViewColumn7.VisibleIndex = 6;
            this.tileViewColumn7.Width = 70;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.Root1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1364, 551);
            this.Root.TextVisible = false;
            // 
            // Root1
            // 
            this.Root1.CustomizationFormText = "Root";
            this.Root1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root1.GroupBordersVisible = false;
            this.Root1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.Root1.Location = new System.Drawing.Point(0, 0);
            this.Root1.Name = "Root1";
            this.Root1.Size = new System.Drawing.Size(1344, 531);
            this.Root1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.Root1.Text = "Root";
            this.Root1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grcCustomerRequirementTiles;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1324, 511);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // urc_MSS_CustomerRequirementTiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "urc_MSS_CustomerRequirementTiles";
            this.Size = new System.Drawing.Size(1364, 551);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcCustomerRequirementTiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraGrid.GridControl grcCustomerRequirementTiles;
        private DevExpress.XtraGrid.Views.Tile.TileView tileView1;
        private DevExpress.XtraGrid.Columns.TileViewColumn tileViewColumn1;
        private DevExpress.XtraGrid.Columns.TileViewColumn tileViewColumn2;
        private DevExpress.XtraGrid.Columns.TileViewColumn tileViewColumn3;
        private DevExpress.XtraGrid.Columns.TileViewColumn tileViewColumn4;
        private DevExpress.XtraGrid.Columns.TileViewColumn tileViewColumn5;
        private DevExpress.XtraGrid.Columns.TileViewColumn tileViewColumn6;
        private DevExpress.XtraGrid.Columns.TileViewColumn tileViewColumn7;
        private DevExpress.XtraLayout.LayoutControlGroup Root1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}
