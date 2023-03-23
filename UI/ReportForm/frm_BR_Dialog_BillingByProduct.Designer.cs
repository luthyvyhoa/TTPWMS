namespace UI.ReportForm
{
    partial class frm_BR_Dialog_BillingByProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_BR_Dialog_BillingByProduct));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.grdProducts = new DevExpress.XtraGrid.GridControl();
            this.grvProducts = new Common.Controls.WMSGridView();
            this.grcProductNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcProductWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcProductID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnEmail = new DevExpress.XtraEditors.SimpleButton();
            this.btnView = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // rbcbase
            // 
            this.rbcbase.ExpandCollapseItem.Id = 0;
            this.rbcbase.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbcbase.OptionsCustomizationForm.FormIcon = ((System.Drawing.Icon)(resources.GetObject("resource.FormIcon")));
            // 
            // 
            // 
            this.rbcbase.SearchEditItem.AccessibleName = "Search Item";
            this.rbcbase.SearchEditItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.rbcbase.SearchEditItem.EditWidth = 150;
            this.rbcbase.SearchEditItem.Id = -5000;
            this.rbcbase.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.rbcbase.Size = new System.Drawing.Size(718, 51);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnClose);
            this.layoutControl1.Controls.Add(this.grdProducts);
            this.layoutControl1.Controls.Add(this.btnEmail);
            this.layoutControl1.Controls.Add(this.btnView);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 51);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(496, 220, 450, 400);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(718, 610);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnClose
            // 
            this.btnClose.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.btnClose.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnClose.Appearance.Options.UseBackColor = true;
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Location = new System.Drawing.Point(585, 552);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(121, 46);
            this.btnClose.StyleController = this.layoutControl1;
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // grdProducts
            // 
            this.grdProducts.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grdProducts.Location = new System.Drawing.Point(12, 12);
            this.grdProducts.MainView = this.grvProducts;
            this.grdProducts.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdProducts.MenuManager = this.rbcbase;
            this.grdProducts.Name = "grdProducts";
            this.grdProducts.Size = new System.Drawing.Size(694, 536);
            this.grdProducts.TabIndex = 4;
            this.grdProducts.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvProducts});
            // 
            // grvProducts
            // 
            this.grvProducts.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grvProducts.Appearance.FooterPanel.Options.UseFont = true;
            this.grvProducts.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvProducts.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grcProductNumber,
            this.grcProductName,
            this.grcProductWeight,
            this.grcProductID});
            this.grvProducts.GridControl = this.grdProducts;
            this.grvProducts.Name = "grvProducts";
            this.grvProducts.OptionsSelection.MultiSelect = true;
            this.grvProducts.OptionsView.ShowColumnHeaders = false;
            this.grvProducts.OptionsView.ShowGroupPanel = false;
            this.grvProducts.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvProducts.PaintStyleName = "Skin";
            // 
            // grcProductNumber
            // 
            this.grcProductNumber.Caption = "PRODUCT ID";
            this.grcProductNumber.FieldName = "XXX";
            this.grcProductNumber.MaxWidth = 150;
            this.grcProductNumber.MinWidth = 80;
            this.grcProductNumber.Name = "grcProductNumber";
            this.grcProductNumber.OptionsColumn.ReadOnly = true;
            this.grcProductNumber.Visible = true;
            this.grcProductNumber.VisibleIndex = 0;
            this.grcProductNumber.Width = 80;
            // 
            // grcProductName
            // 
            this.grcProductName.Caption = "PRODUCT NAME";
            this.grcProductName.FieldName = "ProductName";
            this.grcProductName.Name = "grcProductName";
            this.grcProductName.OptionsColumn.ReadOnly = true;
            this.grcProductName.Visible = true;
            this.grcProductName.VisibleIndex = 1;
            this.grcProductName.Width = 237;
            // 
            // grcProductWeight
            // 
            this.grcProductWeight.Caption = "QUANTITY";
            this.grcProductWeight.DisplayFormat.FormatString = "n1";
            this.grcProductWeight.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.grcProductWeight.FieldName = "WeightPerPackage";
            this.grcProductWeight.GroupFormat.FormatString = "n1";
            this.grcProductWeight.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.grcProductWeight.MaxWidth = 120;
            this.grcProductWeight.MinWidth = 70;
            this.grcProductWeight.Name = "grcProductWeight";
            this.grcProductWeight.OptionsColumn.ReadOnly = true;
            this.grcProductWeight.Visible = true;
            this.grcProductWeight.VisibleIndex = 2;
            this.grcProductWeight.Width = 70;
            // 
            // grcProductID
            // 
            this.grcProductID.Caption = "PRODUCT";
            this.grcProductID.FieldName = "ProductID";
            this.grcProductID.Name = "grcProductID";
            this.grcProductID.OptionsColumn.AllowShowHide = false;
            this.grcProductID.OptionsColumn.ReadOnly = true;
            // 
            // btnEmail
            // 
            this.btnEmail.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnEmail.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnEmail.Appearance.Options.UseBackColor = true;
            this.btnEmail.Appearance.Options.UseFont = true;
            this.btnEmail.Appearance.Options.UseTextOptions = true;
            this.btnEmail.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.btnEmail.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnEmail.AppearancePressed.Options.UseTextOptions = true;
            this.btnEmail.AppearancePressed.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.btnEmail.AppearancePressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnEmail.Location = new System.Drawing.Point(335, 552);
            this.btnEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.Size = new System.Drawing.Size(121, 46);
            this.btnEmail.StyleController = this.layoutControl1;
            this.btnEmail.TabIndex = 5;
            this.btnEmail.Text = "Email Report";
            // 
            // btnView
            // 
            this.btnView.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnView.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnView.Appearance.Options.UseBackColor = true;
            this.btnView.Appearance.Options.UseFont = true;
            this.btnView.Appearance.Options.UseTextOptions = true;
            this.btnView.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.btnView.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnView.AppearancePressed.Options.UseTextOptions = true;
            this.btnView.AppearancePressed.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.btnView.AppearancePressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnView.Location = new System.Drawing.Point(460, 552);
            this.btnView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(121, 46);
            this.btnView.StyleController = this.layoutControl1;
            this.btnView.TabIndex = 6;
            this.btnView.Text = "View Report";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItem1,
            this.layoutControlItem4});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(718, 610);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdProducts;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(698, 540);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnEmail;
            this.layoutControlItem2.Location = new System.Drawing.Point(323, 540);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(125, 50);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(125, 50);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(125, 50);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnView;
            this.layoutControlItem3.Location = new System.Drawing.Point(448, 540);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(125, 50);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(125, 50);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(125, 50);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 540);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(323, 50);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnClose;
            this.layoutControlItem4.Location = new System.Drawing.Point(573, 540);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(125, 50);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(125, 50);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(125, 50);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // frm_BR_Dialog_BillingByProduct
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 661);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_BR_Dialog_BillingByProduct.IconOptions.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_BR_Dialog_BillingByProduct";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "Billing By Products";
            this.Load += new System.EventHandler(this.frm_BR_Dialog_BillingByProduct_Load);
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl grdProducts;
        private Common.Controls.WMSGridView grvProducts;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn grcProductNumber;
        private DevExpress.XtraGrid.Columns.GridColumn grcProductName;
        private DevExpress.XtraGrid.Columns.GridColumn grcProductWeight;
        private DevExpress.XtraGrid.Columns.GridColumn grcProductID;
        private DevExpress.XtraEditors.SimpleButton btnEmail;
        private DevExpress.XtraEditors.SimpleButton btnView;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}