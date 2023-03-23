namespace UI.WarehouseManagement
{
    partial class urc_WM_DOLocations
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grdDPPalletInfo = new DevExpress.XtraGrid.GridControl();
            this.grvDPPalletInfo = new Common.Controls.WMSGridView();
            this.grcLabel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerRef = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDPPalletInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDPPalletInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grdDPPalletInfo);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Padding = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1333, 480);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grdDPPalletInfo
            // 
            this.grdDPPalletInfo.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grdDPPalletInfo.Location = new System.Drawing.Point(15, 15);
            this.grdDPPalletInfo.MainView = this.grvDPPalletInfo;
            this.grdDPPalletInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grdDPPalletInfo.Name = "grdDPPalletInfo";
            this.grdDPPalletInfo.Size = new System.Drawing.Size(1303, 450);
            this.grdDPPalletInfo.TabIndex = 5;
            this.grdDPPalletInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDPPalletInfo});
            // 
            // grvDPPalletInfo
            // 
            this.grvDPPalletInfo.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grvDPPalletInfo.Appearance.FooterPanel.Options.UseFont = true;
            this.grvDPPalletInfo.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvDPPalletInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grcLabel,
            this.grcQuantity,
            this.grcCustomerRef});
            this.grvDPPalletInfo.GridControl = this.grdDPPalletInfo;
            this.grvDPPalletInfo.Name = "grvDPPalletInfo";
            this.grvDPPalletInfo.OptionsView.ShowGroupPanel = false;
            this.grvDPPalletInfo.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvDPPalletInfo.PaintStyleName = "Skin";
            // 
            // grcLabel
            // 
            this.grcLabel.AppearanceHeader.Options.UseTextOptions = true;
            this.grcLabel.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcLabel.Caption = "LOCATION";
            this.grcLabel.FieldName = "Label";
            this.grcLabel.Name = "grcLabel";
            this.grcLabel.OptionsColumn.AllowEdit = false;
            this.grcLabel.Visible = true;
            this.grcLabel.VisibleIndex = 0;
            this.grcLabel.Width = 91;
            // 
            // grcQuantity
            // 
            this.grcQuantity.AppearanceHeader.Options.UseTextOptions = true;
            this.grcQuantity.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcQuantity.Caption = "QTY";
            this.grcQuantity.FieldName = "AfterDPQuantity";
            this.grcQuantity.Name = "grcQuantity";
            this.grcQuantity.OptionsColumn.AllowEdit = false;
            this.grcQuantity.Visible = true;
            this.grcQuantity.VisibleIndex = 1;
            this.grcQuantity.Width = 59;
            // 
            // grcCustomerRef
            // 
            this.grcCustomerRef.AppearanceHeader.Options.UseTextOptions = true;
            this.grcCustomerRef.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcCustomerRef.Caption = "CUSTOMER REF";
            this.grcCustomerRef.FieldName = "CustomerRef";
            this.grcCustomerRef.Name = "grcCustomerRef";
            this.grcCustomerRef.OptionsColumn.AllowEdit = false;
            this.grcCustomerRef.Visible = true;
            this.grcCustomerRef.VisibleIndex = 2;
            this.grcCustomerRef.Width = 125;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 10);
            this.layoutControlGroup1.Size = new System.Drawing.Size(1333, 480);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.grdDPPalletInfo;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.OptionsTableLayoutItem.ColumnSpan = 2;
            this.layoutControlItem2.Size = new System.Drawing.Size(1313, 460);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // urc_WM_DOLocations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "urc_WM_DOLocations";
            this.Size = new System.Drawing.Size(1333, 480);
            this.Load += new System.EventHandler(this.urc_WM_DOLocations_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDPPalletInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDPPalletInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl grdDPPalletInfo;
        private Common.Controls.WMSGridView grvDPPalletInfo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Columns.GridColumn grcLabel;
        private DevExpress.XtraGrid.Columns.GridColumn grcQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerRef;
    }
}
