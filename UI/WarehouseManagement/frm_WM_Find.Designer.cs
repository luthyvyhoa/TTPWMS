namespace UI.WarehouseManagement
{
    partial class frm_WM_Find
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_WM_Find));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.tabControlFind = new DevExpress.XtraTab.XtraTabControl();
            this.tabCustomers = new DevExpress.XtraTab.XtraTabPage();
            this.tabLocations = new DevExpress.XtraTab.XtraTabPage();
            this.tabProducts = new DevExpress.XtraTab.XtraTabPage();
            this.tabReceive = new DevExpress.XtraTab.XtraTabPage();
            this.tabDispatch = new DevExpress.XtraTab.XtraTabPage();
            this.tabMovement = new DevExpress.XtraTab.XtraTabPage();
            this.tabEmployees = new DevExpress.XtraTab.XtraTabPage();
            this.tabPallets = new DevExpress.XtraTab.XtraTabPage();
            this.tabStock = new DevExpress.XtraTab.XtraTabPage();
            this.btnFind = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlFind)).BeginInit();
            this.tabControlFind.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
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
            this.rbcbase.Size = new System.Drawing.Size(1159, 51);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.tabControlFind);
            this.layoutControl1.Controls.Add(this.btnFind);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 51);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1159, 590);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // tabControlFind
            // 
            this.tabControlFind.Location = new System.Drawing.Point(14, 14);
            this.tabControlFind.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControlFind.Name = "tabControlFind";
            this.tabControlFind.PaintStyleName = "Skin";
            this.tabControlFind.SelectedTabPage = this.tabCustomers;
            this.tabControlFind.Size = new System.Drawing.Size(1131, 512);
            this.tabControlFind.TabIndex = 4;
            this.tabControlFind.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabCustomers,
            this.tabLocations,
            this.tabProducts,
            this.tabReceive,
            this.tabDispatch,
            this.tabMovement,
            this.tabEmployees,
            this.tabPallets,
            this.tabStock});
            // 
            // tabCustomers
            // 
            this.tabCustomers.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabCustomers.Name = "tabCustomers";
            this.tabCustomers.Size = new System.Drawing.Size(1129, 483);
            this.tabCustomers.Text = "CUSTOMERS";
            // 
            // tabLocations
            // 
            this.tabLocations.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabLocations.Name = "tabLocations";
            this.tabLocations.Size = new System.Drawing.Size(1129, 494);
            this.tabLocations.Text = "LOCATIONS";
            // 
            // tabProducts
            // 
            this.tabProducts.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabProducts.Name = "tabProducts";
            this.tabProducts.Size = new System.Drawing.Size(1129, 494);
            this.tabProducts.Text = "PRODUCTS";
            // 
            // tabReceive
            // 
            this.tabReceive.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabReceive.Name = "tabReceive";
            this.tabReceive.Size = new System.Drawing.Size(1129, 494);
            this.tabReceive.Text = "RECEIVE";
            // 
            // tabDispatch
            // 
            this.tabDispatch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabDispatch.Name = "tabDispatch";
            this.tabDispatch.Size = new System.Drawing.Size(1129, 494);
            this.tabDispatch.Text = "DISPATCH";
            // 
            // tabMovement
            // 
            this.tabMovement.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabMovement.Name = "tabMovement";
            this.tabMovement.Size = new System.Drawing.Size(1129, 494);
            this.tabMovement.Text = "MOVEMENT";
            // 
            // tabEmployees
            // 
            this.tabEmployees.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabEmployees.Name = "tabEmployees";
            this.tabEmployees.Size = new System.Drawing.Size(1129, 494);
            this.tabEmployees.Text = "EMPLOYEES";
            // 
            // tabPallets
            // 
            this.tabPallets.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPallets.Name = "tabPallets";
            this.tabPallets.Size = new System.Drawing.Size(1129, 494);
            this.tabPallets.Text = "PALLETS";
            // 
            // tabStock
            // 
            this.tabStock.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabStock.Name = "tabStock";
            this.tabStock.Size = new System.Drawing.Size(1129, 494);
            this.tabStock.Text = "STOCK";
            // 
            // btnFind
            // 
            this.btnFind.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Question;
            this.btnFind.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnFind.Appearance.Options.UseBackColor = true;
            this.btnFind.Appearance.Options.UseFont = true;
            this.btnFind.Location = new System.Drawing.Point(14, 534);
            this.btnFind.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(1131, 42);
            this.btnFind.StyleController = this.layoutControl1;
            this.btnFind.TabIndex = 5;
            this.btnFind.Text = "Find...";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1159, 590);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.tabControlFind;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1139, 520);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnFind;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 520);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(0, 50);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(90, 50);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(1139, 50);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // frm_WM_Find
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1159, 641);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_WM_Find.IconOptions.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_WM_Find";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "Find ...";
            this.Load += new System.EventHandler(this.frm_WM_Find_Load);
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabControlFind)).EndInit();
            this.tabControlFind.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraTab.XtraTabControl tabControlFind;
        private DevExpress.XtraTab.XtraTabPage tabCustomers;
        private DevExpress.XtraTab.XtraTabPage tabLocations;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SimpleButton btnFind;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraTab.XtraTabPage tabProducts;
        private DevExpress.XtraTab.XtraTabPage tabReceive;
        private DevExpress.XtraTab.XtraTabPage tabDispatch;
        private DevExpress.XtraTab.XtraTabPage tabMovement;
        private DevExpress.XtraTab.XtraTabPage tabEmployees;
        private DevExpress.XtraTab.XtraTabPage tabPallets;
        private DevExpress.XtraTab.XtraTabPage tabStock;
    }
}