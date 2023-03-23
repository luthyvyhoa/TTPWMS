//namespace UI.WarehouseManagement
//{
//    partial class frm_WM_DeliveryMaps
//    {
//        /// <summary>
//        /// Required designer variable.
//        /// </summary>
//        private System.ComponentModel.IContainer components = null;

//        /// <summary>
//        /// Clean up any resources being used.
//        /// </summary>
//        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        #region Windows Form Designer generated code

//        /// <summary>
//        /// Required method for Designer support - do not modify
//        /// the contents of this method with the code editor.
//        /// </summary>
//        private void InitializeComponent()
//        {
//            this.components = new System.ComponentModel.Container();
//            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_WM_DeliveryMaps));
//            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
//            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
//            this.listBoxControl1 = new DevExpress.XtraEditors.ListBoxControl();
//            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
//            this.mapControl1 = new DevExpress.XtraMap.MapControl();
//            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
//            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
//            this.layoutControl1.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl1)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.mapControl1)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
//            this.SuspendLayout();
//            // 
//            // rbcbase
//            // 
//            this.rbcbase.ExpandCollapseItem.Id = 0;
//            this.rbcbase.Size = new System.Drawing.Size(1625, 33);
//            // 
//            // layoutControl1
//            // 
//            this.layoutControl1.Controls.Add(this.mapControl1);
//            this.layoutControl1.Controls.Add(this.listBoxControl1);
//            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
//            this.layoutControl1.Location = new System.Drawing.Point(0, 33);
//            this.layoutControl1.Name = "layoutControl1";
//            this.layoutControl1.Root = this.layoutControlGroup1;
//            this.layoutControl1.Size = new System.Drawing.Size(1625, 680);
//            this.layoutControl1.TabIndex = 1;
//            this.layoutControl1.Text = "layoutControl1";
//            // 
//            // layoutControlGroup1
//            // 
//            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
//            this.layoutControlGroup1.GroupBordersVisible = false;
//            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
//            this.layoutControlItem1,
//            this.layoutControlItem2});
//            this.layoutControlGroup1.Name = "layoutControlGroup1";
//            this.layoutControlGroup1.Size = new System.Drawing.Size(1625, 680);
//            this.layoutControlGroup1.TextVisible = false;
//            // 
//            // listBoxControl1
//            // 
//            this.listBoxControl1.Location = new System.Drawing.Point(12, 12);
//            this.listBoxControl1.Name = "listBoxControl1";
//            this.listBoxControl1.Size = new System.Drawing.Size(243, 656);
//            this.listBoxControl1.StyleController = this.layoutControl1;
//            this.listBoxControl1.TabIndex = 4;
//            // 
//            // layoutControlItem1
//            // 
//            this.layoutControlItem1.Control = this.listBoxControl1;
//            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
//            this.layoutControlItem1.Name = "layoutControlItem1";
//            this.layoutControlItem1.Size = new System.Drawing.Size(247, 660);
//            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
//            this.layoutControlItem1.TextVisible = false;
//            // 
//            // mapControl1
//            // 
//            this.mapControl1.Location = new System.Drawing.Point(259, 12);
//            this.mapControl1.Name = "mapControl1";
//            this.mapControl1.Size = new System.Drawing.Size(1354, 656);
//            this.mapControl1.TabIndex = 5;
//            // 
//            // layoutControlItem2
//            // 
//            this.layoutControlItem2.Control = this.mapControl1;
//            this.layoutControlItem2.Location = new System.Drawing.Point(247, 0);
//            this.layoutControlItem2.Name = "layoutControlItem2";
//            this.layoutControlItem2.Size = new System.Drawing.Size(1358, 660);
//            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
//            this.layoutControlItem2.TextVisible = false;
//            // 
//            // frm_WM_DeliveryMaps
//            // 
//            this.Appearance.Options.UseFont = true;
//            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.ClientSize = new System.Drawing.Size(1625, 713);
//            this.Controls.Add(this.layoutControl1);
//            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
//            this.Name = "frm_WM_DeliveryMaps";
//            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
//            this.Text = "Vehicle Maps";
//            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
//            this.Load += new System.EventHandler(this.frm_WM_DeliveryMaps_Load);
//            this.Controls.SetChildIndex(this.rbcbase, 0);
//            this.Controls.SetChildIndex(this.layoutControl1, 0);
//            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
//            this.layoutControl1.ResumeLayout(false);
//            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl1)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.mapControl1)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
//            this.ResumeLayout(false);
//            this.PerformLayout();

//        }

//        #endregion

//        private DevExpress.XtraLayout.LayoutControl layoutControl1;
//        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
//        private DevExpress.XtraEditors.ListBoxControl listBoxControl1;
//        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
//        private DevExpress.XtraMap.MapControl mapControl1;
//        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
//    }
//}