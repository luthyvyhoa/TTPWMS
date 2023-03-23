namespace UI.WarehouseManagement
{
    partial class frm_WM_Dialog_DoorDetailsFind
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_WM_Dialog_DoorDetailsFind));
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grdDoorDetails = new DevExpress.XtraGrid.GridControl();
            this.grvDoorDetails = new Common.Controls.WMSGridView();
            this.grcDockNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcOrderNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcStartTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcEndTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcOpenOrder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_btn_OpenOrder = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDoorDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDoorDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_btn_OpenOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
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
            this.rbcbase.Size = new System.Drawing.Size(706, 51);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grdDoorDetails);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 51);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(706, 373);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grdDoorDetails
            // 
            this.grdDoorDetails.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.grdDoorDetails.Location = new System.Drawing.Point(12, 12);
            this.grdDoorDetails.MainView = this.grvDoorDetails;
            this.grdDoorDetails.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdDoorDetails.MenuManager = this.rbcbase;
            this.grdDoorDetails.Name = "grdDoorDetails";
            this.grdDoorDetails.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpi_btn_OpenOrder});
            this.grdDoorDetails.Size = new System.Drawing.Size(682, 349);
            this.grdDoorDetails.TabIndex = 4;
            this.grdDoorDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDoorDetails});
            // 
            // grvDoorDetails
            // 
            this.grvDoorDetails.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grvDoorDetails.Appearance.FooterPanel.Options.UseFont = true;
            this.grvDoorDetails.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvDoorDetails.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grcDockNumber,
            this.grcOrderNumber,
            this.grcCustomerNumber,
            this.grcStartTime,
            this.grcEndTime,
            this.grcOpenOrder});
            this.grvDoorDetails.GridControl = this.grdDoorDetails;
            this.grvDoorDetails.Name = "grvDoorDetails";
            this.grvDoorDetails.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grvDoorDetails.OptionsSelection.MultiSelect = true;
            this.grvDoorDetails.OptionsView.ShowGroupPanel = false;
            this.grvDoorDetails.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvDoorDetails.PaintStyleName = "Skin";
            // 
            // grcDockNumber
            // 
            this.grcDockNumber.AppearanceCell.Options.UseTextOptions = true;
            this.grcDockNumber.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcDockNumber.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcDockNumber.AppearanceHeader.Options.UseTextOptions = true;
            this.grcDockNumber.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcDockNumber.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcDockNumber.Caption = "DOOR NO.";
            this.grcDockNumber.FieldName = "DockNumber";
            this.grcDockNumber.MaxWidth = 70;
            this.grcDockNumber.MinWidth = 70;
            this.grcDockNumber.Name = "grcDockNumber";
            this.grcDockNumber.OptionsColumn.ReadOnly = true;
            this.grcDockNumber.Visible = true;
            this.grcDockNumber.VisibleIndex = 0;
            this.grcDockNumber.Width = 70;
            // 
            // grcOrderNumber
            // 
            this.grcOrderNumber.AppearanceCell.Options.UseTextOptions = true;
            this.grcOrderNumber.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcOrderNumber.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcOrderNumber.AppearanceHeader.Options.UseTextOptions = true;
            this.grcOrderNumber.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcOrderNumber.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcOrderNumber.Caption = "ORDER NO.";
            this.grcOrderNumber.FieldName = "OrderNumber";
            this.grcOrderNumber.MaxWidth = 100;
            this.grcOrderNumber.MinWidth = 100;
            this.grcOrderNumber.Name = "grcOrderNumber";
            this.grcOrderNumber.OptionsColumn.ReadOnly = true;
            this.grcOrderNumber.Visible = true;
            this.grcOrderNumber.VisibleIndex = 1;
            this.grcOrderNumber.Width = 100;
            // 
            // grcCustomerNumber
            // 
            this.grcCustomerNumber.AppearanceCell.Options.UseTextOptions = true;
            this.grcCustomerNumber.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcCustomerNumber.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcCustomerNumber.AppearanceHeader.Options.UseTextOptions = true;
            this.grcCustomerNumber.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcCustomerNumber.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcCustomerNumber.Caption = "CUSTOMER";
            this.grcCustomerNumber.FieldName = "CustomerNumber";
            this.grcCustomerNumber.MaxWidth = 80;
            this.grcCustomerNumber.MinWidth = 80;
            this.grcCustomerNumber.Name = "grcCustomerNumber";
            this.grcCustomerNumber.OptionsColumn.ReadOnly = true;
            this.grcCustomerNumber.Visible = true;
            this.grcCustomerNumber.VisibleIndex = 2;
            this.grcCustomerNumber.Width = 80;
            // 
            // grcStartTime
            // 
            this.grcStartTime.AppearanceCell.Options.UseTextOptions = true;
            this.grcStartTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcStartTime.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcStartTime.AppearanceHeader.Options.UseTextOptions = true;
            this.grcStartTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcStartTime.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcStartTime.Caption = "START";
            this.grcStartTime.FieldName = "StartTime";
            this.grcStartTime.MaxWidth = 140;
            this.grcStartTime.MinWidth = 140;
            this.grcStartTime.Name = "grcStartTime";
            this.grcStartTime.OptionsColumn.ReadOnly = true;
            this.grcStartTime.Visible = true;
            this.grcStartTime.VisibleIndex = 3;
            this.grcStartTime.Width = 140;
            // 
            // grcEndTime
            // 
            this.grcEndTime.AppearanceCell.Options.UseTextOptions = true;
            this.grcEndTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcEndTime.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcEndTime.AppearanceHeader.Options.UseTextOptions = true;
            this.grcEndTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcEndTime.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcEndTime.Caption = "END";
            this.grcEndTime.FieldName = "EndTime";
            this.grcEndTime.MaxWidth = 140;
            this.grcEndTime.MinWidth = 140;
            this.grcEndTime.Name = "grcEndTime";
            this.grcEndTime.OptionsColumn.ReadOnly = true;
            this.grcEndTime.Visible = true;
            this.grcEndTime.VisibleIndex = 4;
            this.grcEndTime.Width = 140;
            // 
            // grcOpenOrder
            // 
            this.grcOpenOrder.AppearanceCell.Options.UseTextOptions = true;
            this.grcOpenOrder.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcOpenOrder.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcOpenOrder.AppearanceHeader.Options.UseTextOptions = true;
            this.grcOpenOrder.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcOpenOrder.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcOpenOrder.Caption = "OPEN ORDER";
            this.grcOpenOrder.ColumnEdit = this.rpi_btn_OpenOrder;
            this.grcOpenOrder.MaxWidth = 35;
            this.grcOpenOrder.MinWidth = 35;
            this.grcOpenOrder.Name = "grcOpenOrder";
            this.grcOpenOrder.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.grcOpenOrder.Visible = true;
            this.grcOpenOrder.VisibleIndex = 5;
            this.grcOpenOrder.Width = 35;
            // 
            // rpi_btn_OpenOrder
            // 
            this.rpi_btn_OpenOrder.AutoHeight = false;
            editorButtonImageOptions1.Image = global::UI.Properties.Resources.freezepanes_16x16;
            this.rpi_btn_OpenOrder.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.rpi_btn_OpenOrder.Name = "rpi_btn_OpenOrder";
            this.rpi_btn_OpenOrder.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(706, 373);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdDoorDetails;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(686, 353);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // frm_WM_Dialog_DoorDetailsFind
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 424);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_WM_Dialog_DoorDetailsFind.IconOptions.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_WM_Dialog_DoorDetailsFind";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "frm_WM_DoorDetailsFind";
            this.Load += new System.EventHandler(this.frm_WM_Dialog_DoorDetailsFind_Load);
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDoorDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDoorDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_btn_OpenOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl grdDoorDetails;
        private Common.Controls.WMSGridView grvDoorDetails;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn grcDockNumber;
        private DevExpress.XtraGrid.Columns.GridColumn grcOrderNumber;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerNumber;
        private DevExpress.XtraGrid.Columns.GridColumn grcStartTime;
        private DevExpress.XtraGrid.Columns.GridColumn grcEndTime;
        private DevExpress.XtraGrid.Columns.GridColumn grcOpenOrder;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rpi_btn_OpenOrder;
    }
}