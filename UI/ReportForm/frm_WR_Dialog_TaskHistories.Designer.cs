namespace UI.ReportForm
{
    partial class frm_WR_Dialog_TaskHistories
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_WR_Dialog_TaskHistories));
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grdTaskHistory = new DevExpress.XtraGrid.GridControl();
            this.grvTaskHistory = new Common.Controls.WMSGridView();
            this.grcReportName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcTaskHistoryID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcSentTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcView = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_btn_View = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.grcDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_btn_Delete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTaskHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTaskHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_btn_View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_btn_Delete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
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
            this.rbcbase.Size = new System.Drawing.Size(648, 51);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grdTaskHistory);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 51);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(648, 420);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grdTaskHistory
            // 
            this.grdTaskHistory.Location = new System.Drawing.Point(12, 12);
            this.grdTaskHistory.MainView = this.grvTaskHistory;
            this.grdTaskHistory.MenuManager = this.rbcbase;
            this.grdTaskHistory.Name = "grdTaskHistory";
            this.grdTaskHistory.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpi_btn_View,
            this.rpi_btn_Delete});
            this.grdTaskHistory.Size = new System.Drawing.Size(624, 396);
            this.grdTaskHistory.TabIndex = 4;
            this.grdTaskHistory.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvTaskHistory});
            // 
            // grvTaskHistory
            // 
            this.grvTaskHistory.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grvTaskHistory.Appearance.FooterPanel.Options.UseFont = true;
            this.grvTaskHistory.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvTaskHistory.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grcReportName,
            this.grcTaskHistoryID,
            this.grcSentTime,
            this.grcView,
            this.grcDelete});
            this.grvTaskHistory.GridControl = this.grdTaskHistory;
            this.grvTaskHistory.Name = "grvTaskHistory";
            this.grvTaskHistory.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grvTaskHistory.OptionsSelection.MultiSelect = true;
            this.grvTaskHistory.OptionsView.ShowGroupPanel = false;
            this.grvTaskHistory.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvTaskHistory.PaintStyleName = "Skin";
            // 
            // grcReportName
            // 
            this.grcReportName.AppearanceCell.Options.UseTextOptions = true;
            this.grcReportName.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcReportName.AppearanceHeader.Options.UseTextOptions = true;
            this.grcReportName.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcReportName.Caption = "REPORT";
            this.grcReportName.Name = "grcReportName";
            this.grcReportName.Visible = true;
            this.grcReportName.VisibleIndex = 0;
            // 
            // grcTaskHistoryID
            // 
            this.grcTaskHistoryID.AppearanceCell.Options.UseTextOptions = true;
            this.grcTaskHistoryID.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcTaskHistoryID.AppearanceHeader.Options.UseTextOptions = true;
            this.grcTaskHistoryID.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcTaskHistoryID.Caption = "HISTORY ID";
            this.grcTaskHistoryID.MaxWidth = 100;
            this.grcTaskHistoryID.MinWidth = 100;
            this.grcTaskHistoryID.Name = "grcTaskHistoryID";
            this.grcTaskHistoryID.Visible = true;
            this.grcTaskHistoryID.VisibleIndex = 1;
            this.grcTaskHistoryID.Width = 100;
            // 
            // grcSentTime
            // 
            this.grcSentTime.AppearanceCell.Options.UseTextOptions = true;
            this.grcSentTime.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcSentTime.AppearanceHeader.Options.UseTextOptions = true;
            this.grcSentTime.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcSentTime.Caption = "LAST SENT";
            this.grcSentTime.FieldName = "SentTime";
            this.grcSentTime.MaxWidth = 150;
            this.grcSentTime.MinWidth = 150;
            this.grcSentTime.Name = "grcSentTime";
            this.grcSentTime.Visible = true;
            this.grcSentTime.VisibleIndex = 2;
            this.grcSentTime.Width = 150;
            // 
            // grcView
            // 
            this.grcView.AppearanceCell.Options.UseTextOptions = true;
            this.grcView.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcView.AppearanceHeader.Options.UseTextOptions = true;
            this.grcView.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcView.Caption = " ";
            this.grcView.ColumnEdit = this.rpi_btn_View;
            this.grcView.MaxWidth = 35;
            this.grcView.MinWidth = 35;
            this.grcView.Name = "grcView";
            this.grcView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.grcView.Visible = true;
            this.grcView.VisibleIndex = 3;
            this.grcView.Width = 35;
            // 
            // rpi_btn_View
            // 
            this.rpi_btn_View.AutoHeight = false;
            editorButtonImageOptions1.Image = global::UI.Properties.Resources.freezepanes_16x16;
            this.rpi_btn_View.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.rpi_btn_View.Name = "rpi_btn_View";
            this.rpi_btn_View.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // grcDelete
            // 
            this.grcDelete.AppearanceCell.Options.UseTextOptions = true;
            this.grcDelete.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcDelete.AppearanceHeader.Options.UseTextOptions = true;
            this.grcDelete.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcDelete.ColumnEdit = this.rpi_btn_Delete;
            this.grcDelete.MaxWidth = 35;
            this.grcDelete.MinWidth = 35;
            this.grcDelete.Name = "grcDelete";
            this.grcDelete.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.grcDelete.Visible = true;
            this.grcDelete.VisibleIndex = 4;
            this.grcDelete.Width = 35;
            // 
            // rpi_btn_Delete
            // 
            this.rpi_btn_Delete.AutoHeight = false;
            editorButtonImageOptions2.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions2.Image")));
            this.rpi_btn_Delete.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.rpi_btn_Delete.Name = "rpi_btn_Delete";
            this.rpi_btn_Delete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(648, 420);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdTaskHistory;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(628, 400);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // frm_WR_Dialog_TaskHistories
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 471);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_WR_Dialog_TaskHistories.IconOptions.Icon")));
            this.Name = "frm_WR_Dialog_TaskHistories";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "Scheduled Task";
            this.Load += new System.EventHandler(this.frm_WR_Dialog_TaskHistories_Load);
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTaskHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTaskHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_btn_View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_btn_Delete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl grdTaskHistory;
        private Common.Controls.WMSGridView grvTaskHistory;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn grcReportName;
        private DevExpress.XtraGrid.Columns.GridColumn grcTaskHistoryID;
        private DevExpress.XtraGrid.Columns.GridColumn grcSentTime;
        private DevExpress.XtraGrid.Columns.GridColumn grcView;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rpi_btn_View;
        private DevExpress.XtraGrid.Columns.GridColumn grcDelete;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rpi_btn_Delete;
    }
}