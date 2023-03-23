using Common.Controls;
namespace UI.Management
{
    partial class frm_M_GO_StockOnHandByRoomSummary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_M_GO_StockOnHandByRoomSummary));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grdStockOnHandByRoomSummary = new DevExpress.XtraGrid.GridControl();
            this.grvStockOnHandByRoomSummary = new Common.Controls.WMSGridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdStockOnHandByRoomSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvStockOnHandByRoomSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // rbcbase
            // 
            //this.rbcbase.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(50, 46, 50, 46);
            this.rbcbase.ExpandCollapseItem.Id = 0;
            this.rbcbase.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbcbase.OptionsCustomizationForm.FormIcon = ((System.Drawing.Icon)(resources.GetObject("resource.FormIcon")));
            this.rbcbase.OptionsMenuMinWidth = 550;
            // 
            // 
            // 
            this.rbcbase.SearchEditItem.AccessibleName = "Search Item";
            this.rbcbase.SearchEditItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.rbcbase.SearchEditItem.EditWidth = 150;
            this.rbcbase.SearchEditItem.Id = -5000;
            this.rbcbase.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.rbcbase.Size = new System.Drawing.Size(1434, 61);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grdStockOnHandByRoomSummary);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 61);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1434, 803);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grdStockOnHandByRoomSummary
            // 
            this.grdStockOnHandByRoomSummary.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.grdStockOnHandByRoomSummary.Location = new System.Drawing.Point(13, 13);
            this.grdStockOnHandByRoomSummary.MainView = this.grvStockOnHandByRoomSummary;
            this.grdStockOnHandByRoomSummary.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grdStockOnHandByRoomSummary.MenuManager = this.rbcbase;
            this.grdStockOnHandByRoomSummary.Name = "grdStockOnHandByRoomSummary";
            this.grdStockOnHandByRoomSummary.Size = new System.Drawing.Size(1408, 777);
            this.grdStockOnHandByRoomSummary.TabIndex = 4;
            this.grdStockOnHandByRoomSummary.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvStockOnHandByRoomSummary});
            this.grdStockOnHandByRoomSummary.Paint += new System.Windows.Forms.PaintEventHandler(this.grdStockOnHandByRoomSummary_Paint);
            // 
            // grvStockOnHandByRoomSummary
            // 
            this.grvStockOnHandByRoomSummary.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grvStockOnHandByRoomSummary.Appearance.FooterPanel.Options.UseFont = true;
            this.grvStockOnHandByRoomSummary.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvStockOnHandByRoomSummary.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn18,
            this.gridColumn19,
            this.gridColumn20});
            this.grvStockOnHandByRoomSummary.DetailHeight = 412;
            this.grvStockOnHandByRoomSummary.GridControl = this.grdStockOnHandByRoomSummary;
            this.grvStockOnHandByRoomSummary.Name = "grvStockOnHandByRoomSummary";
            this.grvStockOnHandByRoomSummary.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvStockOnHandByRoomSummary.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grvStockOnHandByRoomSummary.OptionsSelection.MultiSelect = true;
            this.grvStockOnHandByRoomSummary.OptionsView.ShowGroupPanel = false;
            this.grvStockOnHandByRoomSummary.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvStockOnHandByRoomSummary.PaintStyleName = "Skin";
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColumn1.Caption = "CustomerID";
            this.gridColumn1.FieldName = "CustomerNumber";
            this.gridColumn1.MinWidth = 25;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 114;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "CUSTOMER NAME";
            this.gridColumn2.FieldName = "CustomerName";
            this.gridColumn2.MinWidth = 25;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 245;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Room 1";
            this.gridColumn3.FieldName = "1";
            this.gridColumn3.MinWidth = 25;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 55;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "C";
            this.gridColumn4.FieldName = "C";
            this.gridColumn4.MinWidth = 25;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Width = 44;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "D";
            this.gridColumn5.FieldName = "D";
            this.gridColumn5.MinWidth = 25;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Width = 51;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "E";
            this.gridColumn6.FieldName = "E";
            this.gridColumn6.MinWidth = 25;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.Width = 41;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "F";
            this.gridColumn7.FieldName = "F";
            this.gridColumn7.MinWidth = 25;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.Width = 41;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "G";
            this.gridColumn8.FieldName = "G";
            this.gridColumn8.MinWidth = 25;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.Width = 46;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "H";
            this.gridColumn9.FieldName = "H";
            this.gridColumn9.MinWidth = 25;
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.Width = 44;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "I";
            this.gridColumn10.FieldName = "I";
            this.gridColumn10.MinWidth = 25;
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.Width = 44;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "J";
            this.gridColumn11.FieldName = "J";
            this.gridColumn11.MinWidth = 25;
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.Width = 39;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "K";
            this.gridColumn12.FieldName = "K";
            this.gridColumn12.MinWidth = 25;
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.Width = 50;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "M";
            this.gridColumn13.FieldName = "M";
            this.gridColumn13.MinWidth = 25;
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.Width = 41;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "N";
            this.gridColumn14.FieldName = "N";
            this.gridColumn14.MinWidth = 25;
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.Width = 46;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "P";
            this.gridColumn15.FieldName = "P";
            this.gridColumn15.MinWidth = 25;
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.Width = 45;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Q";
            this.gridColumn16.FieldName = "Q";
            this.gridColumn16.MinWidth = 25;
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsColumn.AllowEdit = false;
            this.gridColumn16.Width = 55;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "V";
            this.gridColumn17.FieldName = "V";
            this.gridColumn17.MinWidth = 25;
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.OptionsColumn.AllowEdit = false;
            this.gridColumn17.Width = 46;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "X";
            this.gridColumn18.FieldName = "X";
            this.gridColumn18.MinWidth = 25;
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsColumn.AllowEdit = false;
            this.gridColumn18.Width = 46;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "Y";
            this.gridColumn19.FieldName = "Y";
            this.gridColumn19.MinWidth = 25;
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.OptionsColumn.AllowEdit = false;
            this.gridColumn19.Width = 40;
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "Z";
            this.gridColumn20.FieldName = "Z";
            this.gridColumn20.MinWidth = 25;
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.OptionsColumn.AllowEdit = false;
            this.gridColumn20.Width = 51;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1434, 803);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdStockOnHandByRoomSummary;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1412, 781);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // frm_M_GO_StockOnHandByRoomSummary
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1434, 864);
            this.Controls.Add(this.layoutControl1);
            this.Enabled = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_M_GO_StockOnHandByRoomSummary.IconOptions.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frm_M_GO_StockOnHandByRoomSummary";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "Stock On Hand All Customers By Room Summary";
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdStockOnHandByRoomSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvStockOnHandByRoomSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl grdStockOnHandByRoomSummary;
        private WMSGridView grvStockOnHandByRoomSummary;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
    }
}