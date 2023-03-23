namespace UI.WarehouseManagement
{
    partial class frm_WM_DailyTasks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_WM_DailyTasks));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grdDailyTask = new DevExpress.XtraGrid.GridControl();
            this.grvDailyTask = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand7 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.grcUser = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.grcTime = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.grcDone = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.rpi_chk_TaskDone = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.grcDoneBy = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.grcDoneTime = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.grcSticky = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.rpi_chk_Sticky = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.grcDescription = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.rpi_mme_TaskDescription = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.grcTaskID = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.grcForGuard = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.btnChecklist = new DevExpress.XtraEditors.SimpleButton();
            this.btnChecklistForGuard = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDailyTask)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDailyTask)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_chk_TaskDone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_chk_Sticky)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_mme_TaskDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
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
            this.rbcbase.Size = new System.Drawing.Size(791, 51);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grdDailyTask);
            this.layoutControl1.Controls.Add(this.btnChecklist);
            this.layoutControl1.Controls.Add(this.btnChecklistForGuard);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 51);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(760, 190, 450, 400);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(791, 519);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grdDailyTask
            // 
            this.grdDailyTask.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.grdDailyTask.Location = new System.Drawing.Point(12, 12);
            this.grdDailyTask.MainView = this.grvDailyTask;
            this.grdDailyTask.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdDailyTask.MenuManager = this.rbcbase;
            this.grdDailyTask.Name = "grdDailyTask";
            this.grdDailyTask.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpi_chk_TaskDone,
            this.rpi_chk_Sticky,
            this.rpi_mme_TaskDescription});
            this.grdDailyTask.Size = new System.Drawing.Size(767, 447);
            this.grdDailyTask.TabIndex = 4;
            this.grdDailyTask.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDailyTask});
            // 
            // grvDailyTask
            // 
            this.grvDailyTask.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grvDailyTask.Appearance.FooterPanel.Options.UseFont = true;
            this.grvDailyTask.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvDailyTask.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand7});
            this.grvDailyTask.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.grcUser,
            this.grcTime,
            this.grcDone,
            this.grcDoneBy,
            this.grcDoneTime,
            this.grcSticky,
            this.grcDescription,
            this.grcTaskID,
            this.grcForGuard});
            this.grvDailyTask.GridControl = this.grdDailyTask;
            this.grvDailyTask.Name = "grvDailyTask";
            this.grvDailyTask.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grvDailyTask.OptionsSelection.MultiSelect = true;
            this.grvDailyTask.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.grvDailyTask.OptionsView.ShowBands = false;
            this.grvDailyTask.OptionsView.ShowGroupPanel = false;
            this.grvDailyTask.PaintStyleName = "Skin";
            // 
            // gridBand7
            // 
            this.gridBand7.Caption = "gridBand7";
            this.gridBand7.Columns.Add(this.grcUser);
            this.gridBand7.Columns.Add(this.grcTime);
            this.gridBand7.Columns.Add(this.grcDone);
            this.gridBand7.Columns.Add(this.grcDoneBy);
            this.gridBand7.Columns.Add(this.grcDoneTime);
            this.gridBand7.Columns.Add(this.grcSticky);
            this.gridBand7.Columns.Add(this.grcDescription);
            this.gridBand7.Name = "gridBand7";
            this.gridBand7.VisibleIndex = 0;
            this.gridBand7.Width = 721;
            // 
            // grcUser
            // 
            this.grcUser.AppearanceHeader.Options.UseTextOptions = true;
            this.grcUser.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcUser.Caption = "USER";
            this.grcUser.FieldName = "UserID";
            this.grcUser.Name = "grcUser";
            this.grcUser.OptionsColumn.ReadOnly = true;
            this.grcUser.Visible = true;
            this.grcUser.Width = 113;
            // 
            // grcTime
            // 
            this.grcTime.AppearanceHeader.Options.UseTextOptions = true;
            this.grcTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcTime.Caption = "TIME";
            this.grcTime.FieldName = "TaskCreatedTime";
            this.grcTime.Name = "grcTime";
            this.grcTime.OptionsColumn.ReadOnly = true;
            this.grcTime.Visible = true;
            this.grcTime.Width = 154;
            // 
            // grcDone
            // 
            this.grcDone.AppearanceHeader.Options.UseTextOptions = true;
            this.grcDone.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcDone.Caption = "DONE";
            this.grcDone.ColumnEdit = this.rpi_chk_TaskDone;
            this.grcDone.FieldName = "TaskDone";
            this.grcDone.Name = "grcDone";
            this.grcDone.Visible = true;
            this.grcDone.Width = 50;
            // 
            // rpi_chk_TaskDone
            // 
            this.rpi_chk_TaskDone.AutoHeight = false;
            this.rpi_chk_TaskDone.Name = "rpi_chk_TaskDone";
            // 
            // grcDoneBy
            // 
            this.grcDoneBy.AppearanceHeader.Options.UseTextOptions = true;
            this.grcDoneBy.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcDoneBy.Caption = "USER";
            this.grcDoneBy.FieldName = "DoneBy";
            this.grcDoneBy.Name = "grcDoneBy";
            this.grcDoneBy.OptionsColumn.ReadOnly = true;
            this.grcDoneBy.Visible = true;
            this.grcDoneBy.Width = 103;
            // 
            // grcDoneTime
            // 
            this.grcDoneTime.AppearanceHeader.Options.UseTextOptions = true;
            this.grcDoneTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcDoneTime.Caption = "TIME";
            this.grcDoneTime.FieldName = "DoneTime";
            this.grcDoneTime.Name = "grcDoneTime";
            this.grcDoneTime.OptionsColumn.ReadOnly = true;
            this.grcDoneTime.Visible = true;
            this.grcDoneTime.Width = 154;
            // 
            // grcSticky
            // 
            this.grcSticky.AppearanceHeader.Options.UseTextOptions = true;
            this.grcSticky.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcSticky.Caption = "NGUYÊN TẮC LÂU DÀI";
            this.grcSticky.ColumnEdit = this.rpi_chk_Sticky;
            this.grcSticky.FieldName = "Sticky";
            this.grcSticky.Name = "grcSticky";
            this.grcSticky.Visible = true;
            this.grcSticky.Width = 147;
            // 
            // rpi_chk_Sticky
            // 
            this.rpi_chk_Sticky.AutoHeight = false;
            this.rpi_chk_Sticky.Name = "rpi_chk_Sticky";
            // 
            // grcDescription
            // 
            this.grcDescription.AppearanceHeader.Options.UseTextOptions = true;
            this.grcDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcDescription.AutoFillDown = true;
            this.grcDescription.Caption = "DESCRIPTION";
            this.grcDescription.ColumnEdit = this.rpi_mme_TaskDescription;
            this.grcDescription.FieldName = "TaskDescription";
            this.grcDescription.Name = "grcDescription";
            this.grcDescription.OptionsColumn.ReadOnly = true;
            this.grcDescription.OptionsColumn.ShowCaption = false;
            this.grcDescription.RowIndex = 1;
            this.grcDescription.Visible = true;
            this.grcDescription.Width = 721;
            // 
            // rpi_mme_TaskDescription
            // 
            this.rpi_mme_TaskDescription.Name = "rpi_mme_TaskDescription";
            // 
            // grcTaskID
            // 
            this.grcTaskID.AppearanceHeader.Options.UseTextOptions = true;
            this.grcTaskID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcTaskID.Caption = "ID";
            this.grcTaskID.FieldName = "TaskID";
            this.grcTaskID.Name = "grcTaskID";
            this.grcTaskID.OptionsColumn.AllowShowHide = false;
            this.grcTaskID.OptionsColumn.ReadOnly = true;
            // 
            // grcForGuard
            // 
            this.grcForGuard.AppearanceHeader.Options.UseTextOptions = true;
            this.grcForGuard.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcForGuard.Caption = "FOR GUARD";
            this.grcForGuard.FieldName = "Forguard";
            this.grcForGuard.Name = "grcForGuard";
            this.grcForGuard.OptionsColumn.AllowShowHide = false;
            this.grcForGuard.OptionsColumn.ReadOnly = true;
            // 
            // btnChecklist
            // 
            this.btnChecklist.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnChecklist.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnChecklist.Appearance.Options.UseBackColor = true;
            this.btnChecklist.Appearance.Options.UseFont = true;
            this.btnChecklist.Appearance.Options.UseTextOptions = true;
            this.btnChecklist.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.btnChecklist.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnChecklist.AppearanceDisabled.Options.UseTextOptions = true;
            this.btnChecklist.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnChecklist.AppearanceHovered.Options.UseTextOptions = true;
            this.btnChecklist.AppearanceHovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnChecklist.AppearancePressed.Options.UseTextOptions = true;
            this.btnChecklist.AppearancePressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnChecklist.Location = new System.Drawing.Point(509, 465);
            this.btnChecklist.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnChecklist.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnChecklist.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnChecklist.Name = "btnChecklist";
            this.btnChecklist.Size = new System.Drawing.Size(125, 40);
            this.btnChecklist.StyleController = this.layoutControl1;
            this.btnChecklist.TabIndex = 5;
            this.btnChecklist.Text = "Warehouse Checklist";
            // 
            // btnChecklistForGuard
            // 
            this.btnChecklistForGuard.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnChecklistForGuard.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnChecklistForGuard.Appearance.Options.UseBackColor = true;
            this.btnChecklistForGuard.Appearance.Options.UseFont = true;
            this.btnChecklistForGuard.Appearance.Options.UseTextOptions = true;
            this.btnChecklistForGuard.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.btnChecklistForGuard.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnChecklistForGuard.AppearanceDisabled.Options.UseTextOptions = true;
            this.btnChecklistForGuard.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnChecklistForGuard.AppearanceHovered.Options.UseTextOptions = true;
            this.btnChecklistForGuard.AppearanceHovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnChecklistForGuard.AppearancePressed.Options.UseTextOptions = true;
            this.btnChecklistForGuard.AppearancePressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnChecklistForGuard.Location = new System.Drawing.Point(652, 465);
            this.btnChecklistForGuard.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnChecklistForGuard.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnChecklistForGuard.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnChecklistForGuard.Name = "btnChecklistForGuard";
            this.btnChecklistForGuard.Size = new System.Drawing.Size(125, 40);
            this.btnChecklistForGuard.StyleController = this.layoutControl1;
            this.btnChecklistForGuard.TabIndex = 6;
            this.btnChecklistForGuard.Text = "Guard Checklist";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.emptySpaceItem1,
            this.layoutControlItem2});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(791, 519);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdDailyTask;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(771, 451);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnChecklistForGuard;
            this.layoutControlItem3.Location = new System.Drawing.Point(638, 451);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(133, 48);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 451);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(495, 48);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnChecklist;
            this.layoutControlItem2.Location = new System.Drawing.Point(495, 451);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(143, 48);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // frm_WM_DailyTasks
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 570);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_WM_DailyTasks.IconOptions.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_WM_DailyTasks";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "Guard House Hand Over";
            this.Load += new System.EventHandler(this.frm_WM_DailyTasks_Load);
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDailyTask)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDailyTask)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_chk_TaskDone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_chk_Sticky)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_mme_TaskDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl grdDailyTask;
        private DevExpress.XtraEditors.SimpleButton btnChecklist;
        private DevExpress.XtraEditors.SimpleButton btnChecklistForGuard;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView grvDailyTask;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn grcUser;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn grcTime;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn grcDone;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rpi_chk_TaskDone;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn grcDoneBy;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn grcDoneTime;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn grcSticky;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rpi_chk_Sticky;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn grcDescription;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn grcTaskID;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn grcForGuard;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit rpi_mme_TaskDescription;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand7;
    }
}