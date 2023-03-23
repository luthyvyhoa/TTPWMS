namespace UI.Helper
{
    partial class frmSearchResult
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchResult));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grdSearchResult = new DevExpress.XtraGrid.GridControl();
            this.grvSearchResult = new Common.Controls.WMSGridView();
            this.grcCodeFull = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcReference = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rhl_OpenReference = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.grcOrderDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcMore = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rhl_More = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSearchResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rhl_OpenReference)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rhl_More)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // rbcbase
            // 
            //this.rbcbase.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(40, 39, 40, 39);
            this.rbcbase.ExpandCollapseItem.Id = 0;
            this.rbcbase.OptionsCustomizationForm.FormIcon = ((System.Drawing.Icon)(resources.GetObject("resource.FormIcon")));
            this.rbcbase.OptionsMenuMinWidth = 440;
            // 
            // 
            // 
            this.rbcbase.SearchEditItem.AccessibleName = "Search Item";
            this.rbcbase.SearchEditItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.rbcbase.SearchEditItem.EditWidth = 150;
            this.rbcbase.SearchEditItem.Id = -5000;
            this.rbcbase.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.rbcbase.Size = new System.Drawing.Size(1113, 51);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grdSearchResult);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 51);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1113, 598);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grdSearchResult
            // 
            this.grdSearchResult.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grdSearchResult.Location = new System.Drawing.Point(16, 16);
            this.grdSearchResult.MainView = this.grvSearchResult;
            this.grdSearchResult.MenuManager = this.rbcbase;
            this.grdSearchResult.Name = "grdSearchResult";
            this.grdSearchResult.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rhl_OpenReference,
            this.rhl_More});
            this.grdSearchResult.Size = new System.Drawing.Size(1081, 566);
            this.grdSearchResult.TabIndex = 4;
            this.grdSearchResult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvSearchResult});
            // 
            // grvSearchResult
            // 
            this.grvSearchResult.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grvSearchResult.Appearance.FooterPanel.Options.UseFont = true;
            this.grvSearchResult.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvSearchResult.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grcCodeFull,
            this.grcReference,
            this.grcOrderDate,
            this.grcRemark,
            this.grcCode,
            this.grcMore});
            this.grvSearchResult.GridControl = this.grdSearchResult;
            this.grvSearchResult.Name = "grvSearchResult";
            this.grvSearchResult.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvSearchResult.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grvSearchResult.OptionsSelection.MultiSelect = true;
            this.grvSearchResult.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.grvSearchResult.OptionsView.ShowFooter = true;
            this.grvSearchResult.OptionsView.ShowGroupPanel = false;
            this.grvSearchResult.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvSearchResult.PaintStyleName = "Skin";
            // 
            // grcCodeFull
            // 
            this.grcCodeFull.Caption = "Code";
            this.grcCodeFull.FieldName = "OperationCodeFull";
            this.grcCodeFull.Name = "grcCodeFull";
            this.grcCodeFull.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "OperationCodeFull", "TOTAL Items found: {0}")});
            this.grcCodeFull.Visible = true;
            this.grcCodeFull.VisibleIndex = 0;
            this.grcCodeFull.Width = 109;
            // 
            // grcReference
            // 
            this.grcReference.Caption = "Ref.Number";
            this.grcReference.ColumnEdit = this.rhl_OpenReference;
            this.grcReference.FieldName = "ReferenceID";
            this.grcReference.Name = "grcReference";
            this.grcReference.Visible = true;
            this.grcReference.VisibleIndex = 1;
            this.grcReference.Width = 139;
            // 
            // rhl_OpenReference
            // 
            this.rhl_OpenReference.AutoHeight = false;
            this.rhl_OpenReference.Name = "rhl_OpenReference";
            this.rhl_OpenReference.Click += new System.EventHandler(this.rhl_OpenReference_Click);
            // 
            // grcOrderDate
            // 
            this.grcOrderDate.Caption = "Date";
            this.grcOrderDate.FieldName = "OrderDate";
            this.grcOrderDate.Name = "grcOrderDate";
            this.grcOrderDate.Visible = true;
            this.grcOrderDate.VisibleIndex = 2;
            this.grcOrderDate.Width = 105;
            // 
            // grcRemark
            // 
            this.grcRemark.Caption = "Remark";
            this.grcRemark.FieldName = "Remark";
            this.grcRemark.Name = "grcRemark";
            this.grcRemark.Visible = true;
            this.grcRemark.VisibleIndex = 3;
            this.grcRemark.Width = 689;
            // 
            // grcCode
            // 
            this.grcCode.Caption = "OperationCode";
            this.grcCode.Name = "grcCode";
            // 
            // grcMore
            // 
            this.grcMore.Caption = "More";
            this.grcMore.ColumnEdit = this.rhl_More;
            this.grcMore.MaxWidth = 35;
            this.grcMore.MinWidth = 35;
            this.grcMore.Name = "grcMore";
            this.grcMore.Visible = true;
            this.grcMore.VisibleIndex = 4;
            this.grcMore.Width = 35;
            // 
            // rhl_More
            // 
            this.rhl_More.AutoHeight = false;
            this.rhl_More.Name = "rhl_More";
            this.rhl_More.Click += new System.EventHandler(this.rhl_More_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1113, 598);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdSearchResult;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1087, 572);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // frmSearchResult
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1113, 649);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frmSearchResult.IconOptions.Icon")));
            this.Name = "frmSearchResult";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "Search Results (first 5 matchs)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSearchResult_FormClosing);
            this.Load += new System.EventHandler(this.frmSearchResult_Load);
            this.Shown += new System.EventHandler(this.frmSearchResult_Shown);
            this.VisibleChanged += new System.EventHandler(this.frmSearchResult_VisibleChanged);
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSearchResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rhl_OpenReference)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rhl_More)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl grdSearchResult;
        private Common.Controls.WMSGridView grvSearchResult;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn grcCodeFull;
        private DevExpress.XtraGrid.Columns.GridColumn grcReference;
        private DevExpress.XtraGrid.Columns.GridColumn grcOrderDate;
        private DevExpress.XtraGrid.Columns.GridColumn grcRemark;
        private DevExpress.XtraGrid.Columns.GridColumn grcCode;
        private DevExpress.XtraGrid.Columns.GridColumn grcMore;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rhl_OpenReference;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rhl_More;
    }
}