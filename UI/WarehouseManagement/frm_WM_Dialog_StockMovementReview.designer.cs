namespace UI.WarehouseManagement
{
    partial class frm_WM_Dialog_StockMovementReview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_WM_Dialog_StockMovementReview));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gridControl_PalletHistories = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new Common.Controls.WMSGridView();
            this.gridColumn_DateMovement = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn_LocationNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_LocationTo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_AuthorisedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_ReasonMovement = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemHyperLinkEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.repositoryItemTextEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_PalletHistories)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit4)).BeginInit();
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
            this.rbcbase.Size = new System.Drawing.Size(982, 51);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridControl_PalletHistories);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 51);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(982, 653);
            this.layoutControl1.TabIndex = 6;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControl_PalletHistories
            // 
            this.gridControl_PalletHistories.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl_PalletHistories.Location = new System.Drawing.Point(14, 14);
            this.gridControl_PalletHistories.MainView = this.gridView1;
            this.gridControl_PalletHistories.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl_PalletHistories.Name = "gridControl_PalletHistories";
            this.gridControl_PalletHistories.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemHyperLinkEdit1,
            this.repositoryItemTextEdit3,
            this.repositoryItemTextEdit4});
            this.gridControl_PalletHistories.Size = new System.Drawing.Size(954, 625);
            this.gridControl_PalletHistories.TabIndex = 6;
            this.gridControl_PalletHistories.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.FooterPanel.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn_DateMovement,
            this.gridColumn_LocationNumber,
            this.gridColumn_LocationTo,
            this.gridColumn_AuthorisedBy,
            this.gridColumn_Name,
            this.gridColumn_ReasonMovement});
            this.gridView1.GridControl = this.gridControl_PalletHistories;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // gridColumn_DateMovement
            // 
            this.gridColumn_DateMovement.Caption = "DATE";
            this.gridColumn_DateMovement.ColumnEdit = this.repositoryItemTextEdit3;
            this.gridColumn_DateMovement.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.gridColumn_DateMovement.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn_DateMovement.FieldName = "DateMovement";
            this.gridColumn_DateMovement.Name = "gridColumn_DateMovement";
            this.gridColumn_DateMovement.OptionsColumn.ReadOnly = true;
            this.gridColumn_DateMovement.Visible = true;
            this.gridColumn_DateMovement.VisibleIndex = 0;
            this.gridColumn_DateMovement.Width = 111;
            // 
            // repositoryItemTextEdit3
            // 
            this.repositoryItemTextEdit3.AutoHeight = false;
            this.repositoryItemTextEdit3.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.repositoryItemTextEdit3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.repositoryItemTextEdit3.EditFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.repositoryItemTextEdit3.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.repositoryItemTextEdit3.Mask.EditMask = "  /  /    ";
            this.repositoryItemTextEdit3.Name = "repositoryItemTextEdit3";
            // 
            // gridColumn_LocationNumber
            // 
            this.gridColumn_LocationNumber.Caption = "FROM";
            this.gridColumn_LocationNumber.FieldName = "LocationNumber";
            this.gridColumn_LocationNumber.Name = "gridColumn_LocationNumber";
            this.gridColumn_LocationNumber.OptionsColumn.ReadOnly = true;
            this.gridColumn_LocationNumber.Visible = true;
            this.gridColumn_LocationNumber.VisibleIndex = 1;
            this.gridColumn_LocationNumber.Width = 123;
            // 
            // gridColumn_LocationTo
            // 
            this.gridColumn_LocationTo.Caption = "TO";
            this.gridColumn_LocationTo.FieldName = "LocationTo";
            this.gridColumn_LocationTo.Name = "gridColumn_LocationTo";
            this.gridColumn_LocationTo.OptionsColumn.ReadOnly = true;
            this.gridColumn_LocationTo.Visible = true;
            this.gridColumn_LocationTo.VisibleIndex = 2;
            this.gridColumn_LocationTo.Width = 138;
            // 
            // gridColumn_AuthorisedBy
            // 
            this.gridColumn_AuthorisedBy.Caption = "CONTROLLER";
            this.gridColumn_AuthorisedBy.FieldName = "AuthorisedBy";
            this.gridColumn_AuthorisedBy.Name = "gridColumn_AuthorisedBy";
            this.gridColumn_AuthorisedBy.OptionsColumn.ReadOnly = true;
            this.gridColumn_AuthorisedBy.Visible = true;
            this.gridColumn_AuthorisedBy.VisibleIndex = 3;
            this.gridColumn_AuthorisedBy.Width = 94;
            // 
            // gridColumn_Name
            // 
            this.gridColumn_Name.Caption = "DRIVER";
            this.gridColumn_Name.FieldName = "Name";
            this.gridColumn_Name.Name = "gridColumn_Name";
            this.gridColumn_Name.Visible = true;
            this.gridColumn_Name.VisibleIndex = 4;
            this.gridColumn_Name.Width = 149;
            // 
            // gridColumn_ReasonMovement
            // 
            this.gridColumn_ReasonMovement.Caption = "REASON";
            this.gridColumn_ReasonMovement.FieldName = "ReasonMovement";
            this.gridColumn_ReasonMovement.Name = "gridColumn_ReasonMovement";
            this.gridColumn_ReasonMovement.OptionsColumn.ReadOnly = true;
            this.gridColumn_ReasonMovement.Visible = true;
            this.gridColumn_ReasonMovement.VisibleIndex = 5;
            this.gridColumn_ReasonMovement.Width = 283;
            // 
            // repositoryItemHyperLinkEdit1
            // 
            this.repositoryItemHyperLinkEdit1.AutoHeight = false;
            this.repositoryItemHyperLinkEdit1.Name = "repositoryItemHyperLinkEdit1";
            // 
            // repositoryItemTextEdit4
            // 
            this.repositoryItemTextEdit4.AutoHeight = false;
            this.repositoryItemTextEdit4.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.repositoryItemTextEdit4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.repositoryItemTextEdit4.EditFormat.FormatString = "dd/MM/yyyy";
            this.repositoryItemTextEdit4.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.repositoryItemTextEdit4.Mask.EditMask = "  /  /    ";
            this.repositoryItemTextEdit4.Name = "repositoryItemTextEdit4";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlGroup1.Size = new System.Drawing.Size(982, 653);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 10);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl_PalletHistories;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(958, 629);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // frm_WM_Dialog_StockMovementReview
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 704);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_WM_Dialog_StockMovementReview.IconOptions.Icon")));
            this.ShowIcon = false;
            this.Name = "frm_WM_Dialog_StockMovementReview";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "Stock Movement Review";
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_PalletHistories)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl gridControl_PalletHistories;
        private Common.Controls.WMSGridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_LocationNumber;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_LocationTo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_DateMovement;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_AuthorisedBy;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_ReasonMovement;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit4;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Name;
    }
}