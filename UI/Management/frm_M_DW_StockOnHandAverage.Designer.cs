namespace UI.Management
{
    partial class frm_M_DW_StockOnHandAverage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_M_DW_StockOnHandAverage));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btn_M_ReportByDate = new DevExpress.XtraEditors.SimpleButton();
            this.btn_M_ReportByRoom = new DevExpress.XtraEditors.SimpleButton();
            this.btn_M_Close = new DevExpress.XtraEditors.SimpleButton();
            this.d_M_To = new DevExpress.XtraEditors.DateEdit();
            this.d_M_From = new DevExpress.XtraEditors.DateEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.d_M_To.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_M_To.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_M_From.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_M_From.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
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
            this.rbcbase.Size = new System.Drawing.Size(432, 51);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btn_M_ReportByDate);
            this.layoutControl1.Controls.Add(this.btn_M_ReportByRoom);
            this.layoutControl1.Controls.Add(this.btn_M_Close);
            this.layoutControl1.Controls.Add(this.d_M_To);
            this.layoutControl1.Controls.Add(this.d_M_From);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 51);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(588, 0, 812, 500);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(432, 128);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btn_M_ReportByDate
            // 
            this.btn_M_ReportByDate.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btn_M_ReportByDate.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btn_M_ReportByDate.Appearance.Options.UseBackColor = true;
            this.btn_M_ReportByDate.Appearance.Options.UseFont = true;
            this.btn_M_ReportByDate.Location = new System.Drawing.Point(14, 74);
            this.btn_M_ReportByDate.MaximumSize = new System.Drawing.Size(125, 40);
            this.btn_M_ReportByDate.MinimumSize = new System.Drawing.Size(125, 40);
            this.btn_M_ReportByDate.Name = "btn_M_ReportByDate";
            this.btn_M_ReportByDate.Size = new System.Drawing.Size(125, 40);
            this.btn_M_ReportByDate.StyleController = this.layoutControl1;
            this.btn_M_ReportByDate.TabIndex = 9;
            this.btn_M_ReportByDate.Text = "By Date";
            this.btn_M_ReportByDate.Click += new System.EventHandler(this.btn_M_ReportByDate_Click);
            // 
            // btn_M_ReportByRoom
            // 
            this.btn_M_ReportByRoom.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btn_M_ReportByRoom.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btn_M_ReportByRoom.Appearance.Options.UseBackColor = true;
            this.btn_M_ReportByRoom.Appearance.Options.UseFont = true;
            this.btn_M_ReportByRoom.Location = new System.Drawing.Point(147, 74);
            this.btn_M_ReportByRoom.MaximumSize = new System.Drawing.Size(125, 40);
            this.btn_M_ReportByRoom.MinimumSize = new System.Drawing.Size(125, 40);
            this.btn_M_ReportByRoom.Name = "btn_M_ReportByRoom";
            this.btn_M_ReportByRoom.Size = new System.Drawing.Size(125, 40);
            this.btn_M_ReportByRoom.StyleController = this.layoutControl1;
            this.btn_M_ReportByRoom.TabIndex = 8;
            this.btn_M_ReportByRoom.Text = "By Room";
            this.btn_M_ReportByRoom.Click += new System.EventHandler(this.btn_M_ReportByRoom_Click);
            // 
            // btn_M_Close
            // 
            this.btn_M_Close.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.btn_M_Close.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btn_M_Close.Appearance.Options.UseBackColor = true;
            this.btn_M_Close.Appearance.Options.UseFont = true;
            this.btn_M_Close.Location = new System.Drawing.Point(280, 74);
            this.btn_M_Close.MaximumSize = new System.Drawing.Size(125, 40);
            this.btn_M_Close.MinimumSize = new System.Drawing.Size(125, 40);
            this.btn_M_Close.Name = "btn_M_Close";
            this.btn_M_Close.Size = new System.Drawing.Size(125, 40);
            this.btn_M_Close.StyleController = this.layoutControl1;
            this.btn_M_Close.TabIndex = 6;
            this.btn_M_Close.Text = "Close";
            this.btn_M_Close.Click += new System.EventHandler(this.btn_M_Close_Click);
            // 
            // d_M_To
            // 
            this.d_M_To.EditValue = null;
            this.d_M_To.Location = new System.Drawing.Point(228, 14);
            this.d_M_To.MenuManager = this.rbcbase;
            this.d_M_To.Name = "d_M_To";
            this.d_M_To.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.d_M_To.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.d_M_To.Size = new System.Drawing.Size(137, 26);
            this.d_M_To.StyleController = this.layoutControl1;
            this.d_M_To.TabIndex = 5;
            // 
            // d_M_From
            // 
            this.d_M_From.EditValue = null;
            this.d_M_From.Location = new System.Drawing.Point(54, 14);
            this.d_M_From.MenuManager = this.rbcbase;
            this.d_M_From.Name = "d_M_From";
            this.d_M_From.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.d_M_From.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.d_M_From.Size = new System.Drawing.Size(126, 26);
            this.d_M_From.StyleController = this.layoutControl1;
            this.d_M_From.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem5,
            this.layoutControlItem4,
            this.emptySpaceItem1,
            this.emptySpaceItem2});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(432, 128);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.d_M_From;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem1.Size = new System.Drawing.Size(174, 34);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem1.Text = "From:";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(35, 16);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.d_M_To;
            this.layoutControlItem2.Location = new System.Drawing.Point(174, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem2.Size = new System.Drawing.Size(185, 34);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem2.Text = "To:";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(35, 16);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btn_M_Close;
            this.layoutControlItem3.Location = new System.Drawing.Point(266, 60);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem3.Size = new System.Drawing.Size(146, 48);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btn_M_ReportByRoom;
            this.layoutControlItem5.Location = new System.Drawing.Point(133, 60);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem5.Size = new System.Drawing.Size(133, 48);
            this.layoutControlItem5.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btn_M_ReportByDate;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 60);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem4.Size = new System.Drawing.Size(133, 48);
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 34);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.emptySpaceItem1.Size = new System.Drawing.Size(412, 26);
            this.emptySpaceItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(359, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(53, 34);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frm_M_DW_StockOnHandAverage
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 179);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_M_DW_StockOnHandAverage.IconOptions.Icon")));
            this.IsFixHeightScreen = false;
            this.Name = "frm_M_DW_StockOnHandAverage";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "Stock On Hand Average";
            this.Load += new System.EventHandler(this.frm_M_DW_StockOnHandAverage_Load);
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.d_M_To.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_M_To.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_M_From.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_M_From.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton btn_M_ReportByRoom;
        private DevExpress.XtraEditors.SimpleButton btn_M_Close;
        private DevExpress.XtraEditors.DateEdit d_M_To;
        private DevExpress.XtraEditors.DateEdit d_M_From;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.SimpleButton btn_M_ReportByDate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
    }
}