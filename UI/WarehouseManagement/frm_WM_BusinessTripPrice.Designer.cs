namespace UI.WarehouseManagement
{
    partial class frm_WM_BusinessTripPrice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_WM_BusinessTripPrice));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grd_WM_BusinessTripPrice = new DevExpress.XtraGrid.GridControl();
            this.grv_WM_BusinessTripPrice = new Common.Controls.WMSGridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_chkLocked = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_WM_BusinessTripPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv_WM_BusinessTripPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_chkLocked)).BeginInit();
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
            this.rbcbase.Size = new System.Drawing.Size(1293, 51);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grd_WM_BusinessTripPrice);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 51);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1293, 634);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grd_WM_BusinessTripPrice
            // 
            this.grd_WM_BusinessTripPrice.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.grd_WM_BusinessTripPrice.Location = new System.Drawing.Point(12, 12);
            this.grd_WM_BusinessTripPrice.MainView = this.grv_WM_BusinessTripPrice;
            this.grd_WM_BusinessTripPrice.MenuManager = this.rbcbase;
            this.grd_WM_BusinessTripPrice.Name = "grd_WM_BusinessTripPrice";
            this.grd_WM_BusinessTripPrice.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpi_chkLocked});
            this.grd_WM_BusinessTripPrice.Size = new System.Drawing.Size(1269, 610);
            this.grd_WM_BusinessTripPrice.TabIndex = 4;
            this.grd_WM_BusinessTripPrice.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grv_WM_BusinessTripPrice});
            // 
            // grv_WM_BusinessTripPrice
            // 
            this.grv_WM_BusinessTripPrice.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grv_WM_BusinessTripPrice.Appearance.FooterPanel.Options.UseFont = true;
            this.grv_WM_BusinessTripPrice.Appearance.HeaderPanel.Options.UseFont = true;
            this.grv_WM_BusinessTripPrice.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10});
            this.grv_WM_BusinessTripPrice.GridControl = this.grd_WM_BusinessTripPrice;
            this.grv_WM_BusinessTripPrice.Name = "grv_WM_BusinessTripPrice";
            this.grv_WM_BusinessTripPrice.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grv_WM_BusinessTripPrice.OptionsSelection.MultiSelect = true;
            this.grv_WM_BusinessTripPrice.OptionsView.GroupDrawMode = DevExpress.XtraGrid.Views.Grid.GroupDrawMode.Office;
            this.grv_WM_BusinessTripPrice.OptionsView.ShowGroupPanel = false;
            this.grv_WM_BusinessTripPrice.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grv_WM_BusinessTripPrice.PaintStyleName = "Skin";
            this.grv_WM_BusinessTripPrice.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.grv_WM_BusinessTripPrice_RowCellStyle);
            this.grv_WM_BusinessTripPrice.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.grv_WM_BusinessTripPrice_ShowingEditor);
            this.grv_WM_BusinessTripPrice.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grv_WM_BusinessTripPrice_CellValueChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "DATE";
            this.gridColumn1.FieldName = "BusinessTripPriceDate";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 118;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "PERTRO PRICE";
            this.gridColumn2.DisplayFormat.FormatString = "{0:n0}";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn2.FieldName = "PetrolPrice";
            this.gridColumn2.GroupFormat.FormatString = "{0:n0}";
            this.gridColumn2.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 111;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "LUNCH";
            this.gridColumn3.DisplayFormat.FormatString = "{0:n0}";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn3.FieldName = "LunchPrice";
            this.gridColumn3.GroupFormat.FormatString = "{0:n0}";
            this.gridColumn3.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 85;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "PARK";
            this.gridColumn4.DisplayFormat.FormatString = "{0:n0}";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn4.FieldName = "ParkPrice";
            this.gridColumn4.GroupFormat.FormatString = "{0:n0}";
            this.gridColumn4.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 88;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "DESCRIPTION";
            this.gridColumn5.FieldName = "RequiredDescription";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 518;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "CREATED BY";
            this.gridColumn6.FieldName = "CreatedBy";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 114;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "LOCKED";
            this.gridColumn7.ColumnEdit = this.rpi_chkLocked;
            this.gridColumn7.FieldName = "Locked";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 7;
            this.gridColumn7.Width = 98;
            // 
            // rpi_chkLocked
            // 
            this.rpi_chkLocked.AutoHeight = false;
            this.rpi_chkLocked.Name = "rpi_chkLocked";
            this.rpi_chkLocked.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "CREATED TIME ";
            this.gridColumn8.FieldName = "CreatedTime";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 6;
            this.gridColumn8.Width = 126;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "BUSSINESS TRIP PRICE ID";
            this.gridColumn9.FieldName = "BusinessTripPriceID";
            this.gridColumn9.Name = "gridColumn9";
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "DIESEL Price";
            this.gridColumn10.DisplayFormat.FormatString = "{0:n0}";
            this.gridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn10.FieldName = "DieselPrice";
            this.gridColumn10.MinWidth = 25;
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 8;
            this.gridColumn10.Width = 94;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1293, 634);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grd_WM_BusinessTripPrice;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1273, 614);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // frm_WM_BusinessTripPrice
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1293, 685);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_WM_BusinessTripPrice.IconOptions.Icon")));
            this.IsFixHeightScreen = false;
            this.Name = "frm_WM_BusinessTripPrice";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "Business Trip Price";
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd_WM_BusinessTripPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv_WM_BusinessTripPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_chkLocked)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl grd_WM_BusinessTripPrice;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rpi_chkLocked;
        private Common.Controls.WMSGridView grv_WM_BusinessTripPrice;
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
    }
}