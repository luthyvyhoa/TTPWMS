namespace UI.MasterSystemSetup
{
    partial class frm_MSS_Trucks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_MSS_Trucks));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btn_Close = new DevExpress.XtraEditors.SimpleButton();
            this.grcTruck = new DevExpress.XtraGrid.GridControl();
            this.grvTruck = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.TruckID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TruckNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.APIID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Volume = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ChillFrozen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Contracter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CreateBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CreateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LinkAPI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Passwords = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcTruck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTruck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // rbcbase
            // 
            //this.rbcbase.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(40, 39, 40, 39);
            this.rbcbase.ExpandCollapseItem.Id = 0;
            this.rbcbase.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.rbcbase.Size = new System.Drawing.Size(719, 51);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btn_Close);
            this.layoutControl1.Controls.Add(this.grcTruck);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 51);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(587, 8, 650, 400);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(719, 324);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btn_Close
            // 
            this.btn_Close.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.btn_Close.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btn_Close.Appearance.Options.UseBackColor = true;
            this.btn_Close.Appearance.Options.UseFont = true;
            this.btn_Close.Location = new System.Drawing.Point(578, 267);
            this.btn_Close.MaximumSize = new System.Drawing.Size(125, 41);
            this.btn_Close.MinimumSize = new System.Drawing.Size(125, 41);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(125, 41);
            this.btn_Close.StyleController = this.layoutControl1;
            this.btn_Close.TabIndex = 7;
            this.btn_Close.Text = "Close";
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // grcTruck
            // 
            this.grcTruck.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.grcTruck.Location = new System.Drawing.Point(16, 16);
            this.grcTruck.MainView = this.grvTruck;
            this.grcTruck.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grcTruck.MenuManager = this.rbcbase;
            this.grcTruck.Name = "grcTruck";
            this.grcTruck.Size = new System.Drawing.Size(687, 245);
            this.grcTruck.TabIndex = 4;
            this.grcTruck.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvTruck});
            // 
            // grvTruck
            // 
            this.grvTruck.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.TruckID,
            this.TruckNumber,
            this.APIID,
            this.Volume,
            this.ChillFrozen,
            this.Contracter,
            this.CreateBy,
            this.CreateTime,
            this.LinkAPI,
            this.UserName,
            this.Passwords});
            this.grvTruck.DetailHeight = 458;
            this.grvTruck.GridControl = this.grcTruck;
            this.grvTruck.Name = "grvTruck";
            this.grvTruck.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.grvTruck.OptionsView.ShowGroupPanel = false;
            this.grvTruck.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.grvTruck_InitNewRow);
            this.grvTruck.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvTruck_FocusedRowChanged);
            this.grvTruck.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvTruck_CellValueChanged);
            this.grvTruck.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvTruck_KeyDown);
            // 
            // TruckID
            // 
            this.TruckID.Caption = "TruckID";
            this.TruckID.FieldName = "TruckID";
            this.TruckID.MinWidth = 27;
            this.TruckID.Name = "TruckID";
            this.TruckID.OptionsColumn.ReadOnly = true;
            this.TruckID.Visible = true;
            this.TruckID.VisibleIndex = 0;
            this.TruckID.Width = 100;
            // 
            // TruckNumber
            // 
            this.TruckNumber.Caption = "TruckNumber";
            this.TruckNumber.FieldName = "TruckNumber";
            this.TruckNumber.MinWidth = 27;
            this.TruckNumber.Name = "TruckNumber";
            this.TruckNumber.Visible = true;
            this.TruckNumber.VisibleIndex = 1;
            this.TruckNumber.Width = 100;
            // 
            // APIID
            // 
            this.APIID.Caption = "APIID";
            this.APIID.FieldName = "APIID";
            this.APIID.MinWidth = 27;
            this.APIID.Name = "APIID";
            this.APIID.Visible = true;
            this.APIID.VisibleIndex = 2;
            this.APIID.Width = 100;
            // 
            // Volume
            // 
            this.Volume.Caption = "Volume";
            this.Volume.FieldName = "Volume";
            this.Volume.MinWidth = 27;
            this.Volume.Name = "Volume";
            this.Volume.Visible = true;
            this.Volume.VisibleIndex = 3;
            this.Volume.Width = 100;
            // 
            // ChillFrozen
            // 
            this.ChillFrozen.Caption = "ChillFrozen";
            this.ChillFrozen.FieldName = "ChillFrozen";
            this.ChillFrozen.MinWidth = 27;
            this.ChillFrozen.Name = "ChillFrozen";
            this.ChillFrozen.Visible = true;
            this.ChillFrozen.VisibleIndex = 4;
            this.ChillFrozen.Width = 100;
            // 
            // Contracter
            // 
            this.Contracter.Caption = "Contracter";
            this.Contracter.FieldName = "Contracter";
            this.Contracter.MinWidth = 27;
            this.Contracter.Name = "Contracter";
            this.Contracter.Visible = true;
            this.Contracter.VisibleIndex = 5;
            this.Contracter.Width = 100;
            // 
            // CreateBy
            // 
            this.CreateBy.Caption = "CreateBy";
            this.CreateBy.FieldName = "CreateBy";
            this.CreateBy.MinWidth = 27;
            this.CreateBy.Name = "CreateBy";
            this.CreateBy.OptionsColumn.ReadOnly = true;
            this.CreateBy.Visible = true;
            this.CreateBy.VisibleIndex = 6;
            this.CreateBy.Width = 100;
            // 
            // CreateTime
            // 
            this.CreateTime.Caption = "CreateTime";
            this.CreateTime.FieldName = "CreateTime";
            this.CreateTime.MinWidth = 27;
            this.CreateTime.Name = "CreateTime";
            this.CreateTime.OptionsColumn.ReadOnly = true;
            this.CreateTime.Visible = true;
            this.CreateTime.VisibleIndex = 7;
            this.CreateTime.Width = 100;
            // 
            // LinkAPI
            // 
            this.LinkAPI.Caption = "LinkAPI";
            this.LinkAPI.FieldName = "LinkAPI";
            this.LinkAPI.MinWidth = 27;
            this.LinkAPI.Name = "LinkAPI";
            this.LinkAPI.Visible = true;
            this.LinkAPI.VisibleIndex = 8;
            this.LinkAPI.Width = 100;
            // 
            // UserName
            // 
            this.UserName.Caption = "UserName";
            this.UserName.FieldName = "UserName";
            this.UserName.MinWidth = 27;
            this.UserName.Name = "UserName";
            this.UserName.Visible = true;
            this.UserName.VisibleIndex = 9;
            this.UserName.Width = 100;
            // 
            // Passwords
            // 
            this.Passwords.Caption = "Passwords";
            this.Passwords.FieldName = "Passwords";
            this.Passwords.MinWidth = 27;
            this.Passwords.Name = "Passwords";
            this.Passwords.Visible = true;
            this.Passwords.VisibleIndex = 10;
            this.Passwords.Width = 100;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(719, 324);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grcTruck;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(693, 251);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btn_Close;
            this.layoutControlItem2.Location = new System.Drawing.Point(562, 251);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(131, 47);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 251);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(562, 47);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frm_MSS_Trucks
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 375);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_MSS_Trucks.IconOptions.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frm_MSS_Trucks";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "frm_MSS_Trucks";
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcTruck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTruck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl grcTruck;
        private DevExpress.XtraGrid.Views.Grid.GridView grvTruck;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn TruckID;
        private DevExpress.XtraGrid.Columns.GridColumn TruckNumber;
        private DevExpress.XtraGrid.Columns.GridColumn APIID;
        private DevExpress.XtraGrid.Columns.GridColumn Volume;
        private DevExpress.XtraGrid.Columns.GridColumn ChillFrozen;
        private DevExpress.XtraGrid.Columns.GridColumn Contracter;
        private DevExpress.XtraGrid.Columns.GridColumn CreateBy;
        private DevExpress.XtraGrid.Columns.GridColumn CreateTime;
        private DevExpress.XtraGrid.Columns.GridColumn LinkAPI;
        private DevExpress.XtraEditors.SimpleButton btn_Close;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.Columns.GridColumn UserName;
        private DevExpress.XtraGrid.Columns.GridColumn Passwords;
    }
}