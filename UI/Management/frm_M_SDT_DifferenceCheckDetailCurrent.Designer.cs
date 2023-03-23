using Common.Controls;
namespace UI.Management
{
    partial class frm_M_SDT_DifferenceCheckDetailCurrent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_M_SDT_DifferenceCheckDetailCurrent));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grdDifferentCheckCurrent = new DevExpress.XtraGrid.GridControl();
            this.grvDifferentCheckCurrent = new Common.Controls.WMSGridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.currentGridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDifferentCheckCurrent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDifferentCheckCurrent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // rbcbase
            // 
            //this.rbcbase.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(35, 40, 35, 40);
            this.rbcbase.ExpandCollapseItem.Id = 0;
            this.rbcbase.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbcbase.OptionsCustomizationForm.FormIcon = ((System.Drawing.Icon)(resources.GetObject("resource.FormIcon")));
            this.rbcbase.OptionsMenuMinWidth = 385;
            // 
            // 
            // 
            this.rbcbase.SearchEditItem.AccessibleName = "Search Item";
            this.rbcbase.SearchEditItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.rbcbase.SearchEditItem.EditWidth = 150;
            this.rbcbase.SearchEditItem.Id = -5000;
            this.rbcbase.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.rbcbase.Size = new System.Drawing.Size(972, 51);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grdDifferentCheckCurrent);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 51);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(972, 451);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grdDifferentCheckCurrent
            // 
            this.grdDifferentCheckCurrent.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.grdDifferentCheckCurrent.Location = new System.Drawing.Point(12, 12);
            this.grdDifferentCheckCurrent.MainView = this.grvDifferentCheckCurrent;
            this.grdDifferentCheckCurrent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdDifferentCheckCurrent.MenuManager = this.rbcbase;
            this.grdDifferentCheckCurrent.Name = "grdDifferentCheckCurrent";
            this.grdDifferentCheckCurrent.Size = new System.Drawing.Size(948, 427);
            this.grdDifferentCheckCurrent.TabIndex = 4;
            this.grdDifferentCheckCurrent.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDifferentCheckCurrent});
            this.grdDifferentCheckCurrent.Load += new System.EventHandler(this.grdDifferentCheckCurrent_Load);
            // 
            // grvDifferentCheckCurrent
            // 
            this.grvDifferentCheckCurrent.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grvDifferentCheckCurrent.Appearance.FooterPanel.Options.UseFont = true;
            this.grvDifferentCheckCurrent.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvDifferentCheckCurrent.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.currentGridColumn,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10});
            this.grvDifferentCheckCurrent.GridControl = this.grdDifferentCheckCurrent;
            this.grvDifferentCheckCurrent.Name = "grvDifferentCheckCurrent";
            this.grvDifferentCheckCurrent.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grvDifferentCheckCurrent.OptionsSelection.MultiSelect = true;
            this.grvDifferentCheckCurrent.OptionsView.ShowFooter = true;
            this.grvDifferentCheckCurrent.OptionsView.ShowGroupPanel = false;
            this.grvDifferentCheckCurrent.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvDifferentCheckCurrent.PaintStyleName = "Skin";
            this.grvDifferentCheckCurrent.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.grvDifferentCheckCurrent_RowCellClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "PRODUCT ID";
            this.gridColumn1.FieldName = "ProductID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ProductID", "{0}")});
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 70;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "PRODUCT NUMBER";
            this.gridColumn2.FieldName = "ProductNumber";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 111;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "PRODUCT NAME";
            this.gridColumn3.FieldName = "ProductName";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 209;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "PALLETID";
            this.gridColumn4.FieldName = "PalletID";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 58;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "ORIGINAL";
            this.gridColumn5.FieldName = "OriginalQuantity";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 64;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "AFTERDP";
            this.gridColumn6.FieldName = "AfterDPQuantity";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 57;
            // 
            // currentGridColumn
            // 
            this.currentGridColumn.AppearanceCell.BackColor = System.Drawing.Color.Blue;
            this.currentGridColumn.AppearanceCell.ForeColor = System.Drawing.Color.White;
            this.currentGridColumn.AppearanceCell.Options.UseBackColor = true;
            this.currentGridColumn.AppearanceCell.Options.UseForeColor = true;
            this.currentGridColumn.Caption = "CURRENT";
            this.currentGridColumn.FieldName = "CurrentQuantity";
            this.currentGridColumn.Name = "currentGridColumn";
            this.currentGridColumn.OptionsColumn.AllowEdit = false;
            this.currentGridColumn.Visible = true;
            this.currentGridColumn.VisibleIndex = 6;
            this.currentGridColumn.Width = 63;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "DISPATCHED";
            this.gridColumn8.FieldName = "DispatchingQuantity";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            this.gridColumn8.Width = 71;
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn9.AppearanceCell.ForeColor = System.Drawing.Color.Blue;
            this.gridColumn9.AppearanceCell.Options.UseFont = true;
            this.gridColumn9.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn9.Caption = "CURRENT ACTUAL";
            this.gridColumn9.FieldName = "CurrentActual";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 8;
            this.gridColumn9.Width = 99;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "AFTERDP ACTUAL";
            this.gridColumn10.FieldName = "AfterDPActual";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 9;
            this.gridColumn10.Width = 119;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(972, 451);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdDifferentCheckCurrent;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(952, 431);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // frm_M_SDT_DifferenceCheckDetailCurrent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 502);
            this.Controls.Add(this.layoutControl1);
            this.Enabled = true;
            this.Font = new System.Drawing.Font("Tahoma", 7.8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_M_SDT_DifferenceCheckDetailCurrent.IconOptions.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_M_SDT_DifferenceCheckDetailCurrent";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "Difference Check CurrentQty By PalletID";
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDifferentCheckCurrent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDifferentCheckCurrent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl grdDifferentCheckCurrent;
        private WMSGridView grvDifferentCheckCurrent;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn currentGridColumn;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
    }
}