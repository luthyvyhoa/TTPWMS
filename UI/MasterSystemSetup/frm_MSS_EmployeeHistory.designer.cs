namespace UI.MasterSystemSetup
{
    partial class frm_MSS_EmployeeHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_MSS_EmployeeHistory));
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grControlEmployeeHistory = new DevExpress.XtraGrid.GridControl();
            this.grViewEmployeeHistory = new Common.Controls.WMSGridView();
            this.grColumnCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grColumnDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grColumnDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grColumnUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grColumnButton = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_btn = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridColumnOrderID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grColumnEmployeeId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grControlEmployeeHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grViewEmployeeHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // rbcbase
            // 
            this.rbcbase.ExpandCollapseItem.Id = 0;
            this.rbcbase.Margin = new System.Windows.Forms.Padding(17, 19, 17, 19);
            this.rbcbase.OptionsCustomizationForm.FormIcon = ((System.Drawing.Icon)(resources.GetObject("resource.FormIcon")));
            // 
            // 
            // 
            this.rbcbase.SearchEditItem.AccessibleName = "Search Item";
            this.rbcbase.SearchEditItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.rbcbase.SearchEditItem.EditWidth = 150;
            this.rbcbase.SearchEditItem.Id = -5000;
            this.rbcbase.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.rbcbase.Size = new System.Drawing.Size(678, 51);
            this.rbcbase.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // grControlEmployeeHistory
            // 
            this.grControlEmployeeHistory.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grControlEmployeeHistory.Location = new System.Drawing.Point(24, 24);
            this.grControlEmployeeHistory.MainView = this.grViewEmployeeHistory;
            this.grControlEmployeeHistory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grControlEmployeeHistory.Name = "grControlEmployeeHistory";
            this.grControlEmployeeHistory.Padding = new System.Windows.Forms.Padding(17, 19, 17, 19);
            this.grControlEmployeeHistory.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpi_btn});
            this.grControlEmployeeHistory.Size = new System.Drawing.Size(630, 494);
            this.grControlEmployeeHistory.TabIndex = 0;
            this.grControlEmployeeHistory.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grViewEmployeeHistory});
            // 
            // grViewEmployeeHistory
            // 
            this.grViewEmployeeHistory.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grViewEmployeeHistory.Appearance.FooterPanel.Options.UseFont = true;
            this.grViewEmployeeHistory.Appearance.HeaderPanel.Options.UseFont = true;
            this.grViewEmployeeHistory.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grColumnCategory,
            this.grColumnDate,
            this.grColumnDescription,
            this.grColumnUser,
            this.grColumnButton,
            this.gridColumnOrderID,
            this.grColumnEmployeeId});
            this.grViewEmployeeHistory.GridControl = this.grControlEmployeeHistory;
            this.grViewEmployeeHistory.Name = "grViewEmployeeHistory";
            this.grViewEmployeeHistory.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grViewEmployeeHistory.OptionsSelection.MultiSelect = true;
            this.grViewEmployeeHistory.OptionsView.ShowGroupPanel = false;
            this.grViewEmployeeHistory.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grViewEmployeeHistory.PaintStyleName = "Skin";
            // 
            // grColumnCategory
            // 
            this.grColumnCategory.AppearanceCell.Options.UseTextOptions = true;
            this.grColumnCategory.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grColumnCategory.AppearanceHeader.Options.UseTextOptions = true;
            this.grColumnCategory.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grColumnCategory.Caption = "CATEGORY";
            this.grColumnCategory.FieldName = "Category";
            this.grColumnCategory.Name = "grColumnCategory";
            this.grColumnCategory.Visible = true;
            this.grColumnCategory.VisibleIndex = 0;
            this.grColumnCategory.Width = 97;
            // 
            // grColumnDate
            // 
            this.grColumnDate.AppearanceCell.Options.UseTextOptions = true;
            this.grColumnDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grColumnDate.AppearanceHeader.Options.UseTextOptions = true;
            this.grColumnDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grColumnDate.Caption = "DATE";
            this.grColumnDate.FieldName = "ReportDate";
            this.grColumnDate.Name = "grColumnDate";
            this.grColumnDate.Visible = true;
            this.grColumnDate.VisibleIndex = 1;
            this.grColumnDate.Width = 97;
            // 
            // grColumnDescription
            // 
            this.grColumnDescription.AppearanceCell.Options.UseTextOptions = true;
            this.grColumnDescription.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.Character;
            this.grColumnDescription.AppearanceHeader.Options.UseTextOptions = true;
            this.grColumnDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grColumnDescription.Caption = "DESCRIPTION";
            this.grColumnDescription.FieldName = "Description";
            this.grColumnDescription.Name = "grColumnDescription";
            this.grColumnDescription.Visible = true;
            this.grColumnDescription.VisibleIndex = 2;
            this.grColumnDescription.Width = 200;
            // 
            // grColumnUser
            // 
            this.grColumnUser.AppearanceHeader.Options.UseTextOptions = true;
            this.grColumnUser.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grColumnUser.Caption = "USER";
            this.grColumnUser.FieldName = "UserName";
            this.grColumnUser.Name = "grColumnUser";
            this.grColumnUser.Visible = true;
            this.grColumnUser.VisibleIndex = 3;
            this.grColumnUser.Width = 43;
            // 
            // grColumnButton
            // 
            this.grColumnButton.AppearanceCell.Image = global::UI.Properties.Resources.FreezePanes_32x32;
            this.grColumnButton.AppearanceHeader.Options.UseTextOptions = true;
            this.grColumnButton.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grColumnButton.ColumnEdit = this.rpi_btn;
            this.grColumnButton.MaxWidth = 35;
            this.grColumnButton.MinWidth = 35;
            this.grColumnButton.Name = "grColumnButton";
            this.grColumnButton.Visible = true;
            this.grColumnButton.VisibleIndex = 4;
            this.grColumnButton.Width = 35;
            // 
            // rpi_btn
            // 
            this.rpi_btn.AutoHeight = false;
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            serializableAppearanceObject1.Image = global::UI.Properties.Resources.FreezePanes_32x32;
            serializableAppearanceObject1.Options.UseImage = true;
            serializableAppearanceObject2.Image = global::UI.Properties.Resources.FreezePanes_32x32;
            serializableAppearanceObject2.Options.UseImage = true;
            serializableAppearanceObject3.Image = global::UI.Properties.Resources.FreezePanes_32x32;
            serializableAppearanceObject3.Options.UseImage = true;
            serializableAppearanceObject4.Image = global::UI.Properties.Resources.FreezePanes_32x32;
            serializableAppearanceObject4.Options.UseImage = true;
            this.rpi_btn.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.rpi_btn.Name = "rpi_btn";
            this.rpi_btn.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.rpi_btn.Click += new System.EventHandler(this.Rpi_btn_Click);
            // 
            // gridColumnOrderID
            // 
            this.gridColumnOrderID.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnOrderID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnOrderID.Caption = "ORDER ID";
            this.gridColumnOrderID.FieldName = "OrderID";
            this.gridColumnOrderID.Name = "gridColumnOrderID";
            // 
            // grColumnEmployeeId
            // 
            this.grColumnEmployeeId.AppearanceHeader.Options.UseTextOptions = true;
            this.grColumnEmployeeId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grColumnEmployeeId.Caption = "EMPLOYEE ID";
            this.grColumnEmployeeId.FieldName = "EmployeeID";
            this.grColumnEmployeeId.Name = "grColumnEmployeeId";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grControlEmployeeHistory);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 51);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(678, 542);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(678, 542);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grControlEmployeeHistory;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(14, 14, 14, 14);
            this.layoutControlItem1.Size = new System.Drawing.Size(658, 522);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // frm_MSS_EmployeeHistory
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 593);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_MSS_EmployeeHistory.IconOptions.Icon")));
            this.IsFixHeightScreen = false;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_MSS_EmployeeHistory";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "Employee History";
            this.Load += new System.EventHandler(this.frm_MSS_EmployeeHistory_Load);
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grControlEmployeeHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grViewEmployeeHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grControlEmployeeHistory;
        private Common.Controls.WMSGridView grViewEmployeeHistory;
        private DevExpress.XtraGrid.Columns.GridColumn grColumnCategory;
        private DevExpress.XtraGrid.Columns.GridColumn grColumnDate;
        private DevExpress.XtraGrid.Columns.GridColumn grColumnDescription;
        private DevExpress.XtraGrid.Columns.GridColumn grColumnUser;
        private DevExpress.XtraGrid.Columns.GridColumn grColumnButton;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rpi_btn;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnOrderID;
        private DevExpress.XtraGrid.Columns.GridColumn grColumnEmployeeId;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}