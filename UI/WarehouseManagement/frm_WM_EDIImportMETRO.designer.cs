namespace UI.WarehouseManagement
{
    partial class frm_WM_EDIImportMETRO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_WM_EDIImportMETRO));
            this.btn_CreateEDI = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Close = new DevExpress.XtraBars.BarButtonItem();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gridControlEDIMetro = new DevExpress.XtraGrid.GridControl();
            this.gridViewEDIMetro = new Common.Controls.WMSGridView();
            this.btn_Create_EDI = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Close_Edi = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlEDIMetro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEDIMetro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // rbcbase
            // 
            this.rbcbase.ExpandCollapseItem.Id = 0;
            this.rbcbase.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btn_CreateEDI,
            this.btn_Close});
            this.rbcbase.MaxItemId = 3;
            this.rbcbase.OptionsCustomizationForm.FormIcon = ((System.Drawing.Icon)(resources.GetObject("resource.FormIcon")));
            this.rbcbase.Size = new System.Drawing.Size(1378, 38);
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btn_CreateEDI);
            this.ribbonPageGroup1.ItemLinks.Add(this.btn_Close);
            // 
            // btn_CreateEDI
            // 
            this.btn_CreateEDI.Caption = "Create EDI";
            this.btn_CreateEDI.Id = 1;
            this.btn_CreateEDI.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_CreateEDI.ImageOptions.Image")));
            this.btn_CreateEDI.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_CreateEDI.ImageOptions.LargeImage")));
            this.btn_CreateEDI.Name = "btn_CreateEDI";
            this.btn_CreateEDI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_CreateEDI_ItemClick_1);
            // 
            // btn_Close
            // 
            this.btn_Close.Caption = "Close";
            this.btn_Close.Id = 2;
            this.btn_Close.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Close.ImageOptions.Image")));
            this.btn_Close.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_Close.ImageOptions.LargeImage")));
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Close_ItemClick_1);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridControlEDIMetro);
            this.layoutControl1.Controls.Add(this.btn_Create_EDI);
            this.layoutControl1.Controls.Add(this.btn_Close_Edi);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 38);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1378, 668);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControlEDIMetro
            // 
            this.gridControlEDIMetro.Location = new System.Drawing.Point(14, 14);
            this.gridControlEDIMetro.MainView = this.gridViewEDIMetro;
            this.gridControlEDIMetro.MenuManager = this.rbcbase;
            this.gridControlEDIMetro.Name = "gridControlEDIMetro";
            this.gridControlEDIMetro.Size = new System.Drawing.Size(1350, 592);
            this.gridControlEDIMetro.TabIndex = 4;
            this.gridControlEDIMetro.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewEDIMetro});
            // 
            // gridViewEDIMetro
            // 
            this.gridViewEDIMetro.GridControl = this.gridControlEDIMetro;
            this.gridViewEDIMetro.Name = "gridViewEDIMetro";
            this.gridViewEDIMetro.PaintStyleName = "Skin";
            // 
            // btn_Create_EDI
            // 
            this.btn_Create_EDI.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning;
            this.btn_Create_EDI.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btn_Create_EDI.Appearance.Options.UseBackColor = true;
            this.btn_Create_EDI.Appearance.Options.UseFont = true;
            this.btn_Create_EDI.Location = new System.Drawing.Point(1106, 614);
            this.btn_Create_EDI.MinimumSize = new System.Drawing.Size(125, 40);
            this.btn_Create_EDI.Name = "btn_Create_EDI";
            this.btn_Create_EDI.Size = new System.Drawing.Size(125, 40);
            this.btn_Create_EDI.StyleController = this.layoutControl1;
            this.btn_Create_EDI.TabIndex = 5;
            this.btn_Create_EDI.Text = "Create EDI";
            // 
            // btn_Close_Edi
            // 
            this.btn_Close_Edi.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.btn_Close_Edi.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btn_Close_Edi.Appearance.Options.UseBackColor = true;
            this.btn_Close_Edi.Appearance.Options.UseFont = true;
            this.btn_Close_Edi.Location = new System.Drawing.Point(1239, 614);
            this.btn_Close_Edi.MinimumSize = new System.Drawing.Size(125, 40);
            this.btn_Close_Edi.Name = "btn_Close_Edi";
            this.btn_Close_Edi.Size = new System.Drawing.Size(125, 40);
            this.btn_Close_Edi.StyleController = this.layoutControl1;
            this.btn_Close_Edi.TabIndex = 6;
            this.btn_Close_Edi.Text = "Close";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem3,
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1378, 668);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControlEDIMetro;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1358, 600);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 600);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(1092, 48);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btn_Create_EDI;
            this.layoutControlItem2.Location = new System.Drawing.Point(1092, 600);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(133, 48);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btn_Close_Edi;
            this.layoutControlItem3.Location = new System.Drawing.Point(1225, 600);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(133, 48);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // frm_WM_EDIImportMETRO
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1378, 706);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frm_WM_EDIImportMETRO";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "EDI - Import Metro";
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlEDIMetro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEDIMetro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarButtonItem btn_CreateEDI;
        private DevExpress.XtraBars.BarButtonItem btn_Close;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl gridControlEDIMetro;
        private Common.Controls.WMSGridView gridViewEDIMetro;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SimpleButton btn_Create_EDI;
        private DevExpress.XtraEditors.SimpleButton btn_Close_Edi;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}