namespace UI.MasterSystemSetup
{
    partial class frm_MSS_DefaultDatabaseChange
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_MSS_DefaultDatabaseChange));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gridControlDatabaseInfo = new DevExpress.XtraGrid.GridControl();
            this.gridViewDatabaseInfo = new Common.Controls.WMSGridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Years = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEditDefault = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEditCurrent = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDatabaseInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDatabaseInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEditDefault)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEditCurrent)).BeginInit();
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
            this.rbcbase.Size = new System.Drawing.Size(818, 51);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridControlDatabaseInfo);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 51);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(818, 122);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControlDatabaseInfo
            // 
            this.gridControlDatabaseInfo.Location = new System.Drawing.Point(12, 12);
            this.gridControlDatabaseInfo.MainView = this.gridViewDatabaseInfo;
            this.gridControlDatabaseInfo.MenuManager = this.rbcbase;
            this.gridControlDatabaseInfo.Name = "gridControlDatabaseInfo";
            this.gridControlDatabaseInfo.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEditDefault,
            this.repositoryItemCheckEditCurrent});
            this.gridControlDatabaseInfo.Size = new System.Drawing.Size(794, 98);
            this.gridControlDatabaseInfo.TabIndex = 4;
            this.gridControlDatabaseInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDatabaseInfo});
            // 
            // gridViewDatabaseInfo
            // 
            this.gridViewDatabaseInfo.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.gridViewDatabaseInfo.Appearance.FooterPanel.Options.UseFont = true;
            this.gridViewDatabaseInfo.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridViewDatabaseInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.Years,
            this.gridColumn4,
            this.gridColumn5});
            this.gridViewDatabaseInfo.GridControl = this.gridControlDatabaseInfo;
            this.gridViewDatabaseInfo.Name = "gridViewDatabaseInfo";
            this.gridViewDatabaseInfo.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewDatabaseInfo.OptionsSelection.MultiSelect = true;
            this.gridViewDatabaseInfo.OptionsView.ShowGroupPanel = false;
            this.gridViewDatabaseInfo.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewDatabaseInfo.PaintStyleName = "Skin";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "CONNECTION STRING";
            this.gridColumn1.FieldName = "ConnectionString";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 464;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "DATA BASE";
            this.gridColumn2.FieldName = "Name";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 80;
            // 
            // Years
            // 
            this.Years.Caption = "APPLICATION";
            this.Years.FieldName = "Years";
            this.Years.Name = "Years";
            this.Years.Visible = true;
            this.Years.VisibleIndex = 2;
            this.Years.Width = 98;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "DEFAULT";
            this.gridColumn4.ColumnEdit = this.repositoryItemCheckEditDefault;
            this.gridColumn4.FieldName = "Default";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 62;
            // 
            // repositoryItemCheckEditDefault
            // 
            this.repositoryItemCheckEditDefault.AutoHeight = false;
            this.repositoryItemCheckEditDefault.Name = "repositoryItemCheckEditDefault";
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "CURRENT";
            this.gridColumn5.ColumnEdit = this.repositoryItemCheckEditCurrent;
            this.gridColumn5.FieldName = "Current";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 79;
            // 
            // repositoryItemCheckEditCurrent
            // 
            this.repositoryItemCheckEditCurrent.AutoHeight = false;
            this.repositoryItemCheckEditCurrent.Name = "repositoryItemCheckEditCurrent";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(818, 122);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControlDatabaseInfo;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(798, 102);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // frm_MSS_DefaultDatabaseChange
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 173);
            this.Controls.Add(this.layoutControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_MSS_DefaultDatabaseChange.IconOptions.Icon")));
            this.Name = "frm_MSS_DefaultDatabaseChange";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "Default Database Change";
            this.Load += new System.EventHandler(this.frm_MSS_DefaultDatabaseChange_Load);
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDatabaseInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDatabaseInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEditDefault)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEditCurrent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gridControlDatabaseInfo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn Years;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEditDefault;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEditCurrent;
        private Common.Controls.WMSGridView gridViewDatabaseInfo;
    }
}