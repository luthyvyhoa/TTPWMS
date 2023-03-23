namespace UI.WarehouseManagement
{
    partial class frm_WM_DispatchingLocationSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_WM_DispatchingLocationSelect));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txt_WM_MaxQuantity = new DevExpress.XtraEditors.TextEdit();
            this.btn_WM_Cancel = new DevExpress.XtraEditors.SimpleButton();
            this.btn_WM_Selected = new DevExpress.XtraEditors.SimpleButton();
            this.grd_WM_LocationData = new DevExpress.XtraGrid.GridControl();
            this.grv_WM_LocationData = new Common.Controls.WMSGridView();
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
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_WM_MaxQuantity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_WM_LocationData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv_WM_LocationData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // rbcbase
            // 
            this.rbcbase.ExpandCollapseItem.Id = 0;
            this.rbcbase.Margin = new System.Windows.Forms.Padding(2);
            this.rbcbase.OptionsCustomizationForm.FormIcon = ((System.Drawing.Icon)(resources.GetObject("resource.FormIcon")));
            // 
            // 
            // 
            this.rbcbase.SearchEditItem.AccessibleName = "Search Item";
            this.rbcbase.SearchEditItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.rbcbase.SearchEditItem.EditWidth = 150;
            this.rbcbase.SearchEditItem.Id = -5000;
            this.rbcbase.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.rbcbase.Size = new System.Drawing.Size(1514, 51);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txt_WM_MaxQuantity);
            this.layoutControl1.Controls.Add(this.btn_WM_Cancel);
            this.layoutControl1.Controls.Add(this.btn_WM_Selected);
            this.layoutControl1.Controls.Add(this.grd_WM_LocationData);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 51);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(335, 430, 675, 600);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1514, 620);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txt_WM_MaxQuantity
            // 
            this.txt_WM_MaxQuantity.EditValue = "1000";
            this.txt_WM_MaxQuantity.Location = new System.Drawing.Point(1124, 570);
            this.txt_WM_MaxQuantity.Margin = new System.Windows.Forms.Padding(2);
            this.txt_WM_MaxQuantity.MaximumSize = new System.Drawing.Size(0, 30);
            this.txt_WM_MaxQuantity.MenuManager = this.rbcbase;
            this.txt_WM_MaxQuantity.MinimumSize = new System.Drawing.Size(0, 30);
            this.txt_WM_MaxQuantity.Name = "txt_WM_MaxQuantity";
            this.txt_WM_MaxQuantity.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.txt_WM_MaxQuantity.Properties.Appearance.Options.UseFont = true;
            this.txt_WM_MaxQuantity.Properties.Appearance.Options.UseTextOptions = true;
            this.txt_WM_MaxQuantity.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txt_WM_MaxQuantity.Properties.AutoHeight = false;
            this.txt_WM_MaxQuantity.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txt_WM_MaxQuantity.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txt_WM_MaxQuantity.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txt_WM_MaxQuantity.Size = new System.Drawing.Size(110, 30);
            this.txt_WM_MaxQuantity.StyleController = this.layoutControl1;
            this.txt_WM_MaxQuantity.TabIndex = 7;
            // 
            // btn_WM_Cancel
            // 
            this.btn_WM_Cancel.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.btn_WM_Cancel.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btn_WM_Cancel.Appearance.Options.UseBackColor = true;
            this.btn_WM_Cancel.Appearance.Options.UseFont = true;
            this.btn_WM_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_WM_Cancel.Location = new System.Drawing.Point(1375, 566);
            this.btn_WM_Cancel.Margin = new System.Windows.Forms.Padding(2);
            this.btn_WM_Cancel.MaximumSize = new System.Drawing.Size(125, 40);
            this.btn_WM_Cancel.MinimumSize = new System.Drawing.Size(125, 40);
            this.btn_WM_Cancel.Name = "btn_WM_Cancel";
            this.btn_WM_Cancel.Size = new System.Drawing.Size(125, 40);
            this.btn_WM_Cancel.StyleController = this.layoutControl1;
            this.btn_WM_Cancel.TabIndex = 6;
            this.btn_WM_Cancel.Text = "Cancel";
            this.btn_WM_Cancel.Click += new System.EventHandler(this.btn_WM_Cancel_Click);
            // 
            // btn_WM_Selected
            // 
            this.btn_WM_Selected.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Warning;
            this.btn_WM_Selected.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btn_WM_Selected.Appearance.Options.UseBackColor = true;
            this.btn_WM_Selected.Appearance.Options.UseFont = true;
            this.btn_WM_Selected.Location = new System.Drawing.Point(1242, 566);
            this.btn_WM_Selected.Margin = new System.Windows.Forms.Padding(2);
            this.btn_WM_Selected.MaximumSize = new System.Drawing.Size(125, 40);
            this.btn_WM_Selected.MinimumSize = new System.Drawing.Size(125, 40);
            this.btn_WM_Selected.Name = "btn_WM_Selected";
            this.btn_WM_Selected.Size = new System.Drawing.Size(125, 40);
            this.btn_WM_Selected.StyleController = this.layoutControl1;
            this.btn_WM_Selected.TabIndex = 5;
            this.btn_WM_Selected.Text = "Select";
            this.btn_WM_Selected.Click += new System.EventHandler(this.btn_WM_Selected_Click);
            // 
            // grd_WM_LocationData
            // 
            this.grd_WM_LocationData.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.grd_WM_LocationData.Location = new System.Drawing.Point(12, 12);
            this.grd_WM_LocationData.MainView = this.grv_WM_LocationData;
            this.grd_WM_LocationData.Margin = new System.Windows.Forms.Padding(2);
            this.grd_WM_LocationData.MenuManager = this.rbcbase;
            this.grd_WM_LocationData.Name = "grd_WM_LocationData";
            this.grd_WM_LocationData.Size = new System.Drawing.Size(1490, 548);
            this.grd_WM_LocationData.TabIndex = 4;
            this.grd_WM_LocationData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grv_WM_LocationData});
            // 
            // grv_WM_LocationData
            // 
            this.grv_WM_LocationData.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grv_WM_LocationData.Appearance.FooterPanel.Options.UseFont = true;
            this.grv_WM_LocationData.Appearance.HeaderPanel.Options.UseFont = true;
            this.grv_WM_LocationData.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
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
            this.gridColumn13});
            this.grv_WM_LocationData.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grv_WM_LocationData.GridControl = this.grd_WM_LocationData;
            this.grv_WM_LocationData.Name = "grv_WM_LocationData";
            this.grv_WM_LocationData.OptionsBehavior.ReadOnly = true;
            this.grv_WM_LocationData.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grv_WM_LocationData.OptionsSelection.MultiSelect = true;
            this.grv_WM_LocationData.OptionsView.ShowGroupPanel = false;
            this.grv_WM_LocationData.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grv_WM_LocationData.PaintStyleName = "Skin";
            this.grv_WM_LocationData.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.grv_WM_LocationData_SelectionChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "PALLET ID";
            this.gridColumn1.FieldName = "PalletID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 84;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "LOCATION";
            this.gridColumn2.FieldName = "Location";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 138;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "QTY";
            this.gridColumn3.FieldName = "Qty";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 67;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "REF";
            this.gridColumn4.FieldName = "Ref";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 188;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "REMARK";
            this.gridColumn5.FieldName = "Remark";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 182;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "RO";
            this.gridColumn6.FieldName = "RO";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 108;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "DATE";
            this.gridColumn7.FieldName = "Date";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            this.gridColumn7.Width = 108;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "RO ID";
            this.gridColumn8.FieldName = "ReceivingOrderID";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Width = 108;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "PRO.DATE";
            this.gridColumn9.FieldName = "ProductionDate";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 7;
            this.gridColumn9.Width = 108;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "EXP.DATE";
            this.gridColumn10.FieldName = "UseByDate";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 8;
            this.gridColumn10.Width = 108;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "RO DETAIL REMARK";
            this.gridColumn11.FieldName = "RODetailRemark";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 9;
            this.gridColumn11.Width = 137;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Packages";
            this.gridColumn12.FieldName = "Packages";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 10;
            this.gridColumn12.Width = 83;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Pcs";
            this.gridColumn13.FieldName = "Pcs";
            this.gridColumn13.MinWidth = 25;
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 11;
            this.gridColumn13.Width = 48;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem3,
            this.layoutControlItem2,
            this.layoutControlItem4});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1514, 620);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grd_WM_LocationData;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1494, 552);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 552);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(1110, 48);
            this.emptySpaceItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btn_WM_Cancel;
            this.layoutControlItem3.Location = new System.Drawing.Point(1361, 552);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(133, 48);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btn_WM_Selected;
            this.layoutControlItem2.Location = new System.Drawing.Point(1228, 552);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(133, 48);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txt_WM_MaxQuantity;
            this.layoutControlItem4.Location = new System.Drawing.Point(1110, 552);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(118, 48);
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 6, 2);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // frm_WM_DispatchingLocationSelect
            // 
            this.AcceptButton = this.btn_WM_Selected;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_WM_Cancel;
            this.ClientSize = new System.Drawing.Size(1514, 671);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_WM_DispatchingLocationSelect.IconOptions.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frm_WM_DispatchingLocationSelect";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "Select Locations for Dispatching Orders";
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt_WM_MaxQuantity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_WM_LocationData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv_WM_LocationData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl grd_WM_LocationData;
        private Common.Controls.WMSGridView grv_WM_LocationData;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
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
        private DevExpress.XtraEditors.SimpleButton btn_WM_Cancel;
        private DevExpress.XtraEditors.SimpleButton btn_WM_Selected;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.TextEdit txt_WM_MaxQuantity;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
    }
}