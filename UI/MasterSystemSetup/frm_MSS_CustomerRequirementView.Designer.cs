namespace UI.MasterSystemSetup
{
    partial class frm_MSS_CustomerRequirementView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_MSS_CustomerRequirementView));
            this.btn_MSS_ReadAndUnderstood = new DevExpress.XtraBars.BarButtonItem();
            this.btn_MSS_Cancel = new DevExpress.XtraBars.BarButtonItem();
            this.flpMain = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            this.SuspendLayout();
            // 
            // rbcbase
            // 
            //this.rbcbase.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(40, 39, 40, 39);
            this.rbcbase.ExpandCollapseItem.Id = 0;
            this.rbcbase.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btn_MSS_ReadAndUnderstood,
            this.btn_MSS_Cancel});
            this.rbcbase.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbcbase.MaxItemId = 3;
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
            this.rbcbase.Size = new System.Drawing.Size(708, 155);
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btn_MSS_ReadAndUnderstood);
            this.ribbonPageGroup1.ItemLinks.Add(this.btn_MSS_Cancel);
            // 
            // btn_MSS_ReadAndUnderstood
            // 
            this.btn_MSS_ReadAndUnderstood.Caption = "Read And Understood";
            this.btn_MSS_ReadAndUnderstood.Id = 1;
            this.btn_MSS_ReadAndUnderstood.ImageOptions.Image = global::UI.Properties.Resources.notes;
            this.btn_MSS_ReadAndUnderstood.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_MSS_ReadAndUnderstood.ImageOptions.LargeImage")));
            this.btn_MSS_ReadAndUnderstood.Name = "btn_MSS_ReadAndUnderstood";
            this.btn_MSS_ReadAndUnderstood.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_MSS_ReadAndUnderstood_ItemClick);
            // 
            // btn_MSS_Cancel
            // 
            this.btn_MSS_Cancel.Caption = "Cancel";
            this.btn_MSS_Cancel.Id = 2;
            this.btn_MSS_Cancel.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_MSS_Cancel.ImageOptions.LargeImage")));
            this.btn_MSS_Cancel.Name = "btn_MSS_Cancel";
            this.btn_MSS_Cancel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_MSS_Cancel_ItemClick);
            // 
            // flpMain
            // 
            this.flpMain.AutoScroll = true;
            this.flpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpMain.Location = new System.Drawing.Point(0, 155);
            this.flpMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flpMain.Name = "flpMain";
            this.flpMain.Size = new System.Drawing.Size(708, 431);
            this.flpMain.TabIndex = 1;
            // 
            // frm_MSS_CustomerRequirementView
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 586);
            this.Controls.Add(this.flpMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_MSS_CustomerRequirementView.IconOptions.Icon")));
            this.IsFixHeightScreen = false;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_MSS_CustomerRequirementView";
            this.Text = "Customer Requirements";
            this.Load += new System.EventHandler(this.frm_MSS_CustomerRequirementView_Load);
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.flpMain, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarButtonItem btn_MSS_ReadAndUnderstood;
        private DevExpress.XtraBars.BarButtonItem btn_MSS_Cancel;
        private System.Windows.Forms.FlowLayoutPanel flpMain;
    }
}