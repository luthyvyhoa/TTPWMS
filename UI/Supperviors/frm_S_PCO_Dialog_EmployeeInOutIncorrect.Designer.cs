namespace UI.Supperviors
{
    partial class frm_S_PCO_Dialog_EmployeeInOutIncorrect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_S_PCO_Dialog_EmployeeInOutIncorrect));
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grdEmployeeInOut = new DevExpress.XtraGrid.GridControl();
            this.grvEmployeeInOut = new Common.Controls.WMSGridView();
            this.grcEmployeeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_hpl_EmployeeID = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.grcEmployeeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcEmployeePosition = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcEmployeeDepartment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcTimeIn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcTimeOut = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCheckOut = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_chk_CheckOut = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.grcCreatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcAdjustTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_btn_AdjustTime = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.grcEmployeeInOutID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEmployeeInOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEmployeeInOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_hpl_EmployeeID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_chk_CheckOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_btn_AdjustTime)).BeginInit();
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
            this.rbcbase.Size = new System.Drawing.Size(1168, 51);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grdEmployeeInOut);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 51);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1168, 509);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grdEmployeeInOut
            // 
            this.grdEmployeeInOut.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.grdEmployeeInOut.Location = new System.Drawing.Point(12, 12);
            this.grdEmployeeInOut.MainView = this.grvEmployeeInOut;
            this.grdEmployeeInOut.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdEmployeeInOut.MenuManager = this.rbcbase;
            this.grdEmployeeInOut.Name = "grdEmployeeInOut";
            this.grdEmployeeInOut.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpi_hpl_EmployeeID,
            this.rpi_chk_CheckOut,
            this.rpi_btn_AdjustTime});
            this.grdEmployeeInOut.Size = new System.Drawing.Size(1144, 485);
            this.grdEmployeeInOut.TabIndex = 4;
            this.grdEmployeeInOut.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvEmployeeInOut});
            // 
            // grvEmployeeInOut
            // 
            this.grvEmployeeInOut.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grvEmployeeInOut.Appearance.FooterPanel.Options.UseFont = true;
            this.grvEmployeeInOut.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvEmployeeInOut.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grcEmployeeID,
            this.grcEmployeeName,
            this.grcEmployeePosition,
            this.grcEmployeeDepartment,
            this.grcTimeIn,
            this.grcTimeOut,
            this.grcCheckOut,
            this.grcCreatedBy,
            this.grcAdjustTime,
            this.grcEmployeeInOutID});
            this.grvEmployeeInOut.GridControl = this.grdEmployeeInOut;
            this.grvEmployeeInOut.Name = "grvEmployeeInOut";
            this.grvEmployeeInOut.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grvEmployeeInOut.OptionsSelection.MultiSelect = true;
            this.grvEmployeeInOut.OptionsView.ShowFooter = true;
            this.grvEmployeeInOut.OptionsView.ShowGroupPanel = false;
            this.grvEmployeeInOut.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvEmployeeInOut.PaintStyleName = "Skin";
            // 
            // grcEmployeeID
            // 
            this.grcEmployeeID.Caption = "ID";
            this.grcEmployeeID.ColumnEdit = this.rpi_hpl_EmployeeID;
            this.grcEmployeeID.FieldName = "EmployeeID";
            this.grcEmployeeID.Name = "grcEmployeeID";
            this.grcEmployeeID.OptionsColumn.ReadOnly = true;
            this.grcEmployeeID.Visible = true;
            this.grcEmployeeID.VisibleIndex = 0;
            this.grcEmployeeID.Width = 45;
            // 
            // rpi_hpl_EmployeeID
            // 
            this.rpi_hpl_EmployeeID.AutoHeight = false;
            this.rpi_hpl_EmployeeID.Name = "rpi_hpl_EmployeeID";
            // 
            // grcEmployeeName
            // 
            this.grcEmployeeName.Caption = " ";
            this.grcEmployeeName.FieldName = "VietnamName";
            this.grcEmployeeName.Name = "grcEmployeeName";
            this.grcEmployeeName.OptionsColumn.ReadOnly = true;
            this.grcEmployeeName.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "VietnamName", "Total: {0}")});
            this.grcEmployeeName.Visible = true;
            this.grcEmployeeName.VisibleIndex = 1;
            this.grcEmployeeName.Width = 180;
            // 
            // grcEmployeePosition
            // 
            this.grcEmployeePosition.Caption = " ";
            this.grcEmployeePosition.FieldName = "VietnamPosition";
            this.grcEmployeePosition.Name = "grcEmployeePosition";
            this.grcEmployeePosition.OptionsColumn.ReadOnly = true;
            this.grcEmployeePosition.Visible = true;
            this.grcEmployeePosition.VisibleIndex = 2;
            this.grcEmployeePosition.Width = 179;
            // 
            // grcEmployeeDepartment
            // 
            this.grcEmployeeDepartment.Caption = " ";
            this.grcEmployeeDepartment.FieldName = "DepartmentNameShort";
            this.grcEmployeeDepartment.Name = "grcEmployeeDepartment";
            this.grcEmployeeDepartment.OptionsColumn.ReadOnly = true;
            this.grcEmployeeDepartment.Visible = true;
            this.grcEmployeeDepartment.VisibleIndex = 3;
            this.grcEmployeeDepartment.Width = 60;
            // 
            // grcTimeIn
            // 
            this.grcTimeIn.Caption = "Time In";
            this.grcTimeIn.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.grcTimeIn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.grcTimeIn.FieldName = "TimeIn";
            this.grcTimeIn.Name = "grcTimeIn";
            this.grcTimeIn.OptionsColumn.ReadOnly = true;
            this.grcTimeIn.Visible = true;
            this.grcTimeIn.VisibleIndex = 4;
            this.grcTimeIn.Width = 132;
            // 
            // grcTimeOut
            // 
            this.grcTimeOut.Caption = "Time Out";
            this.grcTimeOut.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.grcTimeOut.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.grcTimeOut.FieldName = "TimeOut";
            this.grcTimeOut.Name = "grcTimeOut";
            this.grcTimeOut.OptionsColumn.ReadOnly = true;
            this.grcTimeOut.Visible = true;
            this.grcTimeOut.VisibleIndex = 5;
            this.grcTimeOut.Width = 129;
            // 
            // grcCheckOut
            // 
            this.grcCheckOut.Caption = "Check Out";
            this.grcCheckOut.ColumnEdit = this.rpi_chk_CheckOut;
            this.grcCheckOut.FieldName = "CheckOut";
            this.grcCheckOut.MaxWidth = 70;
            this.grcCheckOut.MinWidth = 70;
            this.grcCheckOut.Name = "grcCheckOut";
            this.grcCheckOut.OptionsColumn.ReadOnly = true;
            this.grcCheckOut.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.grcCheckOut.Visible = true;
            this.grcCheckOut.VisibleIndex = 6;
            this.grcCheckOut.Width = 70;
            // 
            // rpi_chk_CheckOut
            // 
            this.rpi_chk_CheckOut.AutoHeight = false;
            this.rpi_chk_CheckOut.Name = "rpi_chk_CheckOut";
            // 
            // grcCreatedBy
            // 
            this.grcCreatedBy.Caption = " ";
            this.grcCreatedBy.FieldName = "CreatedBy";
            this.grcCreatedBy.Name = "grcCreatedBy";
            this.grcCreatedBy.OptionsColumn.ReadOnly = true;
            this.grcCreatedBy.Visible = true;
            this.grcCreatedBy.VisibleIndex = 7;
            this.grcCreatedBy.Width = 156;
            // 
            // grcAdjustTime
            // 
            this.grcAdjustTime.ColumnEdit = this.rpi_btn_AdjustTime;
            this.grcAdjustTime.MaxWidth = 40;
            this.grcAdjustTime.MinWidth = 40;
            this.grcAdjustTime.Name = "grcAdjustTime";
            this.grcAdjustTime.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.grcAdjustTime.Visible = true;
            this.grcAdjustTime.VisibleIndex = 8;
            this.grcAdjustTime.Width = 40;
            // 
            // rpi_btn_AdjustTime
            // 
            this.rpi_btn_AdjustTime.AutoHeight = false;
            this.rpi_btn_AdjustTime.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Adjust", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.rpi_btn_AdjustTime.Name = "rpi_btn_AdjustTime";
            this.rpi_btn_AdjustTime.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // grcEmployeeInOutID
            // 
            this.grcEmployeeInOutID.FieldName = "EmployeeInOutID";
            this.grcEmployeeInOutID.Name = "grcEmployeeInOutID";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1168, 509);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdEmployeeInOut;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1148, 489);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // frm_S_PCO_Dialog_EmployeeInOutIncorrect
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1168, 560);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_S_PCO_Dialog_EmployeeInOutIncorrect.IconOptions.Icon")));
            this.IsFixHeightScreen = false;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_S_PCO_Dialog_EmployeeInOutIncorrect";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "In Out Incorrect";
            this.Load += new System.EventHandler(this.frm_S_PCO_Dialog_EmployeeInOutIncorrect_Load);
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdEmployeeInOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEmployeeInOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_hpl_EmployeeID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_chk_CheckOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_btn_AdjustTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl grdEmployeeInOut;
        private Common.Controls.WMSGridView grvEmployeeInOut;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn grcEmployeeID;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpi_hpl_EmployeeID;
        private DevExpress.XtraGrid.Columns.GridColumn grcEmployeeName;
        private DevExpress.XtraGrid.Columns.GridColumn grcEmployeePosition;
        private DevExpress.XtraGrid.Columns.GridColumn grcEmployeeDepartment;
        private DevExpress.XtraGrid.Columns.GridColumn grcTimeIn;
        private DevExpress.XtraGrid.Columns.GridColumn grcTimeOut;
        private DevExpress.XtraGrid.Columns.GridColumn grcCheckOut;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rpi_chk_CheckOut;
        private DevExpress.XtraGrid.Columns.GridColumn grcCreatedBy;
        private DevExpress.XtraGrid.Columns.GridColumn grcAdjustTime;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rpi_btn_AdjustTime;
        private DevExpress.XtraGrid.Columns.GridColumn grcEmployeeInOutID;
    }
}