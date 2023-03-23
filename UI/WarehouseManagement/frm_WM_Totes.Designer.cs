namespace UI.WarehouseManagement
{
    partial class frm_WM_Totes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_WM_Totes));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.txtToID = new DevExpress.XtraEditors.TextEdit();
            this.txtFromID = new DevExpress.XtraEditors.TextEdit();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.txtTotes = new DevExpress.XtraEditors.TextEdit();
            this.btnCreateTotes = new DevExpress.XtraEditors.SimpleButton();
            this.grcTotes = new DevExpress.XtraGrid.GridControl();
            this.grvTotes = new Common.Controls.WMSGridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnPrintBarcodes = new DevExpress.XtraEditors.SimpleButton();
            this.textQtyBarcode = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtToID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcTotes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTotes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textQtyBarcode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // rbcbase
            // 
            this.rbcbase.ExpandCollapseItem.Id = 0;
            this.rbcbase.Margin = new System.Windows.Forms.Padding(4);
            this.rbcbase.OptionsCustomizationForm.FormIcon = ((System.Drawing.Icon)(resources.GetObject("resource.FormIcon")));
            // 
            // 
            // 
            this.rbcbase.SearchEditItem.EditWidth = 150;
            this.rbcbase.SearchEditItem.Id = -5000;
            this.rbcbase.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.rbcbase.Size = new System.Drawing.Size(794, 40);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnRefresh);
            this.layoutControl1.Controls.Add(this.txtToID);
            this.layoutControl1.Controls.Add(this.txtFromID);
            this.layoutControl1.Controls.Add(this.btnPrint);
            this.layoutControl1.Controls.Add(this.txtTotes);
            this.layoutControl1.Controls.Add(this.btnCreateTotes);
            this.layoutControl1.Controls.Add(this.grcTotes);
            this.layoutControl1.Controls.Add(this.btnPrintBarcodes);
            this.layoutControl1.Controls.Add(this.textQtyBarcode);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 40);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1123, 367, 650, 400);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(794, 594);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Question;
            this.btnRefresh.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.Appearance.Options.UseBackColor = true;
            this.btnRefresh.Appearance.Options.UseFont = true;
            this.btnRefresh.Location = new System.Drawing.Point(299, 553);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefresh.MaximumSize = new System.Drawing.Size(125, 25);
            this.btnRefresh.MinimumSize = new System.Drawing.Size(125, 25);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(125, 25);
            this.btnRefresh.StyleController = this.layoutControl1;
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Text = "Refresh Data";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtToID
            // 
            this.txtToID.Location = new System.Drawing.Point(612, 553);
            this.txtToID.Margin = new System.Windows.Forms.Padding(4);
            this.txtToID.MenuManager = this.rbcbase;
            this.txtToID.Name = "txtToID";
            this.txtToID.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtToID.Properties.Appearance.Options.UseFont = true;
            this.txtToID.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtToID.Size = new System.Drawing.Size(168, 24);
            this.txtToID.StyleController = this.layoutControl1;
            this.txtToID.TabIndex = 6;
            // 
            // txtFromID
            // 
            this.txtFromID.Location = new System.Drawing.Point(432, 553);
            this.txtFromID.Margin = new System.Windows.Forms.Padding(4);
            this.txtFromID.MenuManager = this.rbcbase;
            this.txtFromID.Name = "txtFromID";
            this.txtFromID.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtFromID.Properties.Appearance.Options.UseFont = true;
            this.txtFromID.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtFromID.Size = new System.Drawing.Size(172, 24);
            this.txtFromID.StyleController = this.layoutControl1;
            this.txtFromID.TabIndex = 5;
            this.txtFromID.EditValueChanged += new System.EventHandler(this.txtFromID_EditValueChanged);
            // 
            // btnPrint
            // 
            this.btnPrint.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Question;
            this.btnPrint.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnPrint.Appearance.Options.UseBackColor = true;
            this.btnPrint.Appearance.Options.UseFont = true;
            this.btnPrint.Location = new System.Drawing.Point(302, 14);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrint.MaximumSize = new System.Drawing.Size(125, 25);
            this.btnPrint.MinimumSize = new System.Drawing.Size(125, 25);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(125, 25);
            this.btnPrint.StyleController = this.layoutControl1;
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "Print Totes";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // txtTotes
            // 
            this.txtTotes.Location = new System.Drawing.Point(99, 14);
            this.txtTotes.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotes.MenuManager = this.rbcbase;
            this.txtTotes.MinimumSize = new System.Drawing.Size(0, 24);
            this.txtTotes.Name = "txtTotes";
            this.txtTotes.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotes.Properties.NullText = "0";
            this.txtTotes.Size = new System.Drawing.Size(62, 22);
            this.txtTotes.StyleController = this.layoutControl1;
            this.txtTotes.TabIndex = 0;
            // 
            // btnCreateTotes
            // 
            this.btnCreateTotes.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Question;
            this.btnCreateTotes.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnCreateTotes.Appearance.Options.UseBackColor = true;
            this.btnCreateTotes.Appearance.Options.UseFont = true;
            this.btnCreateTotes.Location = new System.Drawing.Point(169, 14);
            this.btnCreateTotes.Margin = new System.Windows.Forms.Padding(4);
            this.btnCreateTotes.MaximumSize = new System.Drawing.Size(125, 25);
            this.btnCreateTotes.MinimumSize = new System.Drawing.Size(125, 25);
            this.btnCreateTotes.Name = "btnCreateTotes";
            this.btnCreateTotes.Size = new System.Drawing.Size(125, 25);
            this.btnCreateTotes.StyleController = this.layoutControl1;
            this.btnCreateTotes.TabIndex = 2;
            this.btnCreateTotes.Text = "Create Totes";
            this.btnCreateTotes.Click += new System.EventHandler(this.btnCreateTotes_Click);
            // 
            // grcTotes
            // 
            this.grcTotes.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(5);
            this.grcTotes.Location = new System.Drawing.Point(14, 49);
            this.grcTotes.MainView = this.grvTotes;
            this.grcTotes.Margin = new System.Windows.Forms.Padding(4);
            this.grcTotes.MenuManager = this.rbcbase;
            this.grcTotes.Name = "grcTotes";
            this.grcTotes.Size = new System.Drawing.Size(766, 496);
            this.grcTotes.TabIndex = 3;
            this.grcTotes.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvTotes});
            this.grcTotes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grcTotes_KeyDown);
            // 
            // grvTotes
            // 
            this.grvTotes.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.grvTotes.DetailHeight = 458;
            this.grvTotes.FixedLineWidth = 3;
            this.grvTotes.GridControl = this.grcTotes;
            this.grvTotes.Name = "grvTotes";
            this.grvTotes.OptionsSelection.MultiSelect = true;
            this.grvTotes.OptionsView.ShowGroupPanel = false;
            this.grvTotes.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvTotes.PaintStyleName = "Skin";
            this.grvTotes.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvTotes_CellValueChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "ToteID";
            this.gridColumn1.FieldName = "ToteNumber";
            this.gridColumn1.MinWidth = 27;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 109;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "CreateBy";
            this.gridColumn2.FieldName = "CreateBy";
            this.gridColumn2.MinWidth = 27;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 123;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Create Time";
            this.gridColumn3.FieldName = "CreateTime";
            this.gridColumn3.MinWidth = 27;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 183;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Remark";
            this.gridColumn4.FieldName = "Remark";
            this.gridColumn4.MinWidth = 27;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 246;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "gridColumn5";
            this.gridColumn5.FieldName = "ToteID";
            this.gridColumn5.MinWidth = 27;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Width = 100;
            // 
            // btnPrintBarcodes
            // 
            this.btnPrintBarcodes.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Question;
            this.btnPrintBarcodes.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnPrintBarcodes.Appearance.Options.UseBackColor = true;
            this.btnPrintBarcodes.Appearance.Options.UseFont = true;
            this.btnPrintBarcodes.Location = new System.Drawing.Point(655, 14);
            this.btnPrintBarcodes.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrintBarcodes.MaximumSize = new System.Drawing.Size(125, 25);
            this.btnPrintBarcodes.MinimumSize = new System.Drawing.Size(125, 25);
            this.btnPrintBarcodes.Name = "btnPrintBarcodes";
            this.btnPrintBarcodes.Size = new System.Drawing.Size(125, 25);
            this.btnPrintBarcodes.StyleController = this.layoutControl1;
            this.btnPrintBarcodes.TabIndex = 4;
            this.btnPrintBarcodes.Text = "Print Barcodes";
            this.btnPrintBarcodes.Click += new System.EventHandler(this.btnPrintBarcodes_Click);
            // 
            // textQtyBarcode
            // 
            this.textQtyBarcode.Location = new System.Drawing.Point(585, 14);
            this.textQtyBarcode.Margin = new System.Windows.Forms.Padding(4);
            this.textQtyBarcode.MinimumSize = new System.Drawing.Size(0, 24);
            this.textQtyBarcode.Name = "textQtyBarcode";
            this.textQtyBarcode.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.textQtyBarcode.Properties.NullText = "0";
            this.textQtyBarcode.Size = new System.Drawing.Size(62, 22);
            this.textQtyBarcode.StyleController = this.layoutControl1;
            this.textQtyBarcode.TabIndex = 0;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.emptySpaceItem3,
            this.layoutControlItem7,
            this.layoutControlItem2,
            this.layoutControlItem8,
            this.layoutControlItem9,
            this.emptySpaceItem2});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(794, 594);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grcTotes;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 35);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(774, 504);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnCreateTotes;
            this.layoutControlItem3.Location = new System.Drawing.Point(155, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(133, 35);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtTotes;
            this.layoutControlItem4.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(155, 35);
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem4.Text = "Qty Totes";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(82, 16);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtFromID;
            this.layoutControlItem5.Location = new System.Drawing.Point(418, 539);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(180, 35);
            this.layoutControlItem5.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txtToID;
            this.layoutControlItem6.Location = new System.Drawing.Point(598, 539);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(176, 35);
            this.layoutControlItem6.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 539);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(285, 35);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.btnRefresh;
            this.layoutControlItem7.Location = new System.Drawing.Point(285, 539);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(133, 35);
            this.layoutControlItem7.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnPrint;
            this.layoutControlItem2.Location = new System.Drawing.Point(288, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(133, 35);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.btnPrintBarcodes;
            this.layoutControlItem8.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem8.Location = new System.Drawing.Point(641, 0);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(133, 35);
            this.layoutControlItem8.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem8.Text = "layoutControlItem2";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.textQtyBarcode;
            this.layoutControlItem9.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.layoutControlItem9.CustomizationFormText = "Qty Totes";
            this.layoutControlItem9.Location = new System.Drawing.Point(486, 0);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(155, 35);
            this.layoutControlItem9.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem9.Text = "Qty Barcodes";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(82, 16);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(421, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(65, 35);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frm_WM_Totes
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 634);
            this.Controls.Add(this.layoutControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_WM_Totes";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "Totes - Barcodes";
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtToID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcTotes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTotes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textQtyBarcode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl grcTotes;
        private Common.Controls.WMSGridView grvTotes;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SimpleButton btnCreateTotes;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.TextEdit txtTotes;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.TextEdit txtToID;
        private DevExpress.XtraEditors.TextEdit txtFromID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.SimpleButton btnPrintBarcodes;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraEditors.TextEdit textQtyBarcode;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
    }
}