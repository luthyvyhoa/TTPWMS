using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraLayout;

namespace UI.Supperviors
{
    partial class frm_S_AO_Dialog_ProblemReviewByDate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_S_AO_Dialog_ProblemReviewByDate));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grdDataRaw = new DevExpress.XtraGrid.GridControl();
            this.grvDataRaw = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdProblemReview = new DevExpress.XtraGrid.GridControl();
            this.grvProblemReview = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.grcInternalAuditID = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.rpi_hpl_InternalAuditID = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.grcCorrectiveActionBy = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.grcCorrectiveBeforeDate = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.grcProblemCategoryDescription = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.grcInternalAuditStatus = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.rpi_chk_AuditStatus = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.grcProblemDescription = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.rpi_mme_ProblemDescription = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.grcCorrectiveAction = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.rpi_mme_CorrectiveAction = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.grcPreventativeActionBy = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.grcCompleteBeforeDate = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.grcPreventativeActionRequired = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.rpi_chk_Required = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.grcPreventStatus = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.rpi_chk_PreventStatus = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.grcPreventativeAction = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.rpi_mme_PreventativeAction = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gridBand5 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.grcManagerFeedback = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.rpi_mme_ManagerFeedback = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.grdBandInternalAuditDate = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.grcInternalAuditDate = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand6 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.grcConfirmed = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.rpi_chk_Confirmed = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.bandedGridColumn9 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.chkAll = new DevExpress.XtraEditors.CheckEdit();
            this.chkAvailable = new DevExpress.XtraEditors.CheckEdit();
            this.chkNotConfirm = new DevExpress.XtraEditors.CheckEdit();
            this.dtFrom = new DevExpress.XtraEditors.DateEdit();
            this.dtTo = new DevExpress.XtraEditors.DateEdit();
            this.btnDataRaw = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.txtTotal = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDataRaw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDataRaw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdProblemReview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProblemReview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_hpl_InternalAuditID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_chk_AuditStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_mme_ProblemDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_mme_CorrectiveAction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_chk_Required)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_chk_PreventStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_mme_PreventativeAction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_mme_ManagerFeedback)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_chk_Confirmed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAvailable.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNotConfirm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
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
            this.rbcbase.Size = new System.Drawing.Size(1457, 51);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grdDataRaw);
            this.layoutControl1.Controls.Add(this.grdProblemReview);
            this.layoutControl1.Controls.Add(this.chkAll);
            this.layoutControl1.Controls.Add(this.chkAvailable);
            this.layoutControl1.Controls.Add(this.chkNotConfirm);
            this.layoutControl1.Controls.Add(this.dtFrom);
            this.layoutControl1.Controls.Add(this.dtTo);
            this.layoutControl1.Controls.Add(this.btnDataRaw);
            this.layoutControl1.Controls.Add(this.btnClose);
            this.layoutControl1.Controls.Add(this.txtTotal);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem10});
            this.layoutControl1.Location = new System.Drawing.Point(0, 51);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(508, 206, 450, 400);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1457, 518);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grdDataRaw
            // 
            this.grdDataRaw.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.grdDataRaw.Location = new System.Drawing.Point(17, 259);
            this.grdDataRaw.MainView = this.grvDataRaw;
            this.grdDataRaw.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdDataRaw.MenuManager = this.rbcbase;
            this.grdDataRaw.Name = "grdDataRaw";
            this.grdDataRaw.Size = new System.Drawing.Size(947, 229);
            this.grdDataRaw.TabIndex = 13;
            this.grdDataRaw.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDataRaw});
            // 
            // grvDataRaw
            // 
            this.grvDataRaw.FixedLineWidth = 3;
            this.grvDataRaw.GridControl = this.grdDataRaw;
            this.grvDataRaw.Name = "grvDataRaw";
            // 
            // grdProblemReview
            // 
            this.grdProblemReview.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.grdProblemReview.Location = new System.Drawing.Point(12, 12);
            this.grdProblemReview.MainView = this.grvProblemReview;
            this.grdProblemReview.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdProblemReview.MenuManager = this.rbcbase;
            this.grdProblemReview.Name = "grdProblemReview";
            this.grdProblemReview.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpi_chk_AuditStatus,
            this.rpi_mme_ProblemDescription,
            this.rpi_mme_CorrectiveAction,
            this.rpi_chk_Required,
            this.rpi_chk_PreventStatus,
            this.rpi_mme_PreventativeAction,
            this.rpi_mme_ManagerFeedback,
            this.rpi_chk_Confirmed,
            this.rpi_hpl_InternalAuditID});
            this.grdProblemReview.Size = new System.Drawing.Size(1433, 446);
            this.grdProblemReview.TabIndex = 4;
            this.grdProblemReview.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvProblemReview});
            // 
            // grvProblemReview
            // 
            this.grvProblemReview.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grvProblemReview.Appearance.FooterPanel.Options.UseFont = true;
            this.grvProblemReview.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvProblemReview.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1,
            this.gridBand2,
            this.gridBand3,
            this.gridBand4,
            this.gridBand5,
            this.grdBandInternalAuditDate,
            this.gridBand6});
            this.grvProblemReview.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.grcInternalAuditID,
            this.grcCorrectiveAction,
            this.grcPreventStatus,
            this.grcConfirmed,
            this.grcPreventativeActionRequired,
            this.grcCompleteBeforeDate,
            this.grcPreventativeAction,
            this.grcManagerFeedback,
            this.bandedGridColumn9,
            this.grcCorrectiveBeforeDate,
            this.grcCorrectiveActionBy,
            this.grcProblemDescription,
            this.grcProblemCategoryDescription,
            this.grcInternalAuditStatus,
            this.grcPreventativeActionBy,
            this.grcInternalAuditDate});
            this.grvProblemReview.FixedLineWidth = 3;
            this.grvProblemReview.GridControl = this.grdProblemReview;
            this.grvProblemReview.Name = "grvProblemReview";
            this.grvProblemReview.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grvProblemReview.OptionsSelection.MultiSelect = true;
            this.grvProblemReview.OptionsView.ShowColumnHeaders = false;
            this.grvProblemReview.OptionsView.ShowGroupPanel = false;
            this.grvProblemReview.PaintStyleName = "Skin";
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "NO.";
            this.gridBand1.Columns.Add(this.grcInternalAuditID);
            this.gridBand1.Columns.Add(this.grcCorrectiveActionBy);
            this.gridBand1.Columns.Add(this.grcCorrectiveBeforeDate);
            this.gridBand1.Columns.Add(this.grcProblemCategoryDescription);
            this.gridBand1.Columns.Add(this.grcInternalAuditStatus);
            this.gridBand1.MinWidth = 13;
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 0;
            this.gridBand1.Width = 307;
            // 
            // grcInternalAuditID
            // 
            this.grcInternalAuditID.Caption = "BANDED GRID COLLUMN1";
            this.grcInternalAuditID.ColumnEdit = this.rpi_hpl_InternalAuditID;
            this.grcInternalAuditID.FieldName = "InternalAuditID";
            this.grcInternalAuditID.Name = "grcInternalAuditID";
            this.grcInternalAuditID.Visible = true;
            this.grcInternalAuditID.Width = 97;
            // 
            // rpi_hpl_InternalAuditID
            // 
            this.rpi_hpl_InternalAuditID.AutoHeight = false;
            this.rpi_hpl_InternalAuditID.Name = "rpi_hpl_InternalAuditID";
            // 
            // grcCorrectiveActionBy
            // 
            this.grcCorrectiveActionBy.Caption = "BANDED GRID COLLUMN11";
            this.grcCorrectiveActionBy.FieldName = "CorrectiveActionBy";
            this.grcCorrectiveActionBy.Name = "grcCorrectiveActionBy";
            this.grcCorrectiveActionBy.Visible = true;
            this.grcCorrectiveActionBy.Width = 97;
            // 
            // grcCorrectiveBeforeDate
            // 
            this.grcCorrectiveBeforeDate.Caption = "BANDED GRID COLLUMN10";
            this.grcCorrectiveBeforeDate.FieldName = "CorrectiveBeforeDate";
            this.grcCorrectiveBeforeDate.Name = "grcCorrectiveBeforeDate";
            this.grcCorrectiveBeforeDate.Visible = true;
            this.grcCorrectiveBeforeDate.Width = 112;
            // 
            // grcProblemCategoryDescription
            // 
            this.grcProblemCategoryDescription.Caption = "PROBLEM CATEGORY DESCRIPTION";
            this.grcProblemCategoryDescription.FieldName = "ProblemCategoryDescription";
            this.grcProblemCategoryDescription.Name = "grcProblemCategoryDescription";
            this.grcProblemCategoryDescription.RowIndex = 1;
            this.grcProblemCategoryDescription.Visible = true;
            this.grcProblemCategoryDescription.Width = 307;
            // 
            // grcInternalAuditStatus
            // 
            this.grcInternalAuditStatus.Caption = "BANDED GRID COLLUMN14";
            this.grcInternalAuditStatus.ColumnEdit = this.rpi_chk_AuditStatus;
            this.grcInternalAuditStatus.Name = "grcInternalAuditStatus";
            this.grcInternalAuditStatus.RowIndex = 2;
            this.grcInternalAuditStatus.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "", "Total: {0}")});
            this.grcInternalAuditStatus.Visible = true;
            this.grcInternalAuditStatus.Width = 307;
            // 
            // rpi_chk_AuditStatus
            // 
            this.rpi_chk_AuditStatus.Appearance.Options.UseTextOptions = true;
            this.rpi_chk_AuditStatus.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.rpi_chk_AuditStatus.AutoHeight = false;
            this.rpi_chk_AuditStatus.Caption = "Corr. done:";
            this.rpi_chk_AuditStatus.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.rpi_chk_AuditStatus.Name = "rpi_chk_AuditStatus";
            // 
            // gridBand2
            // 
            this.gridBand2.Caption = "PROBLEM DESCRIPTION";
            this.gridBand2.Columns.Add(this.grcProblemDescription);
            this.gridBand2.MinWidth = 13;
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.VisibleIndex = 1;
            this.gridBand2.Width = 245;
            // 
            // grcProblemDescription
            // 
            this.grcProblemDescription.AutoFillDown = true;
            this.grcProblemDescription.Caption = "BANDED GRID COLLUMN12";
            this.grcProblemDescription.ColumnEdit = this.rpi_mme_ProblemDescription;
            this.grcProblemDescription.FieldName = "ProblemDescription";
            this.grcProblemDescription.Name = "grcProblemDescription";
            this.grcProblemDescription.Visible = true;
            this.grcProblemDescription.Width = 245;
            // 
            // rpi_mme_ProblemDescription
            // 
            this.rpi_mme_ProblemDescription.Name = "rpi_mme_ProblemDescription";
            // 
            // gridBand3
            // 
            this.gridBand3.Caption = "CORRECTIVE ACTION";
            this.gridBand3.Columns.Add(this.grcCorrectiveAction);
            this.gridBand3.MinWidth = 13;
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.VisibleIndex = 2;
            this.gridBand3.Width = 280;
            // 
            // grcCorrectiveAction
            // 
            this.grcCorrectiveAction.AutoFillDown = true;
            this.grcCorrectiveAction.Caption = "BANDED GRID COLLUMN2";
            this.grcCorrectiveAction.ColumnEdit = this.rpi_mme_CorrectiveAction;
            this.grcCorrectiveAction.FieldName = "CorrectiveAction";
            this.grcCorrectiveAction.Name = "grcCorrectiveAction";
            this.grcCorrectiveAction.Visible = true;
            this.grcCorrectiveAction.Width = 280;
            // 
            // rpi_mme_CorrectiveAction
            // 
            this.rpi_mme_CorrectiveAction.Name = "rpi_mme_CorrectiveAction";
            // 
            // gridBand4
            // 
            this.gridBand4.Caption = "PREVENTATIVE ACTION";
            this.gridBand4.Columns.Add(this.grcPreventativeActionBy);
            this.gridBand4.Columns.Add(this.grcCompleteBeforeDate);
            this.gridBand4.Columns.Add(this.grcPreventativeActionRequired);
            this.gridBand4.Columns.Add(this.grcPreventStatus);
            this.gridBand4.Columns.Add(this.grcPreventativeAction);
            this.gridBand4.MinWidth = 13;
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.VisibleIndex = 3;
            this.gridBand4.Width = 405;
            // 
            // grcPreventativeActionBy
            // 
            this.grcPreventativeActionBy.Caption = "PREVENTATIVE ACTION BY";
            this.grcPreventativeActionBy.FieldName = "PreventativeActionBy";
            this.grcPreventativeActionBy.Name = "grcPreventativeActionBy";
            this.grcPreventativeActionBy.Visible = true;
            this.grcPreventativeActionBy.Width = 108;
            // 
            // grcCompleteBeforeDate
            // 
            this.grcCompleteBeforeDate.Caption = "COMPLETE BEFORE DATE";
            this.grcCompleteBeforeDate.FieldName = "CompleteBeforeDate";
            this.grcCompleteBeforeDate.Name = "grcCompleteBeforeDate";
            this.grcCompleteBeforeDate.Visible = true;
            this.grcCompleteBeforeDate.Width = 108;
            // 
            // grcPreventativeActionRequired
            // 
            this.grcPreventativeActionRequired.Caption = "PREVENTATIVE ACTION REQUIRED";
            this.grcPreventativeActionRequired.ColumnEdit = this.rpi_chk_Required;
            this.grcPreventativeActionRequired.FieldName = "PreventativeActionRequired";
            this.grcPreventativeActionRequired.Name = "grcPreventativeActionRequired";
            this.grcPreventativeActionRequired.Visible = true;
            this.grcPreventativeActionRequired.Width = 96;
            // 
            // rpi_chk_Required
            // 
            this.rpi_chk_Required.AutoHeight = false;
            this.rpi_chk_Required.Name = "rpi_chk_Required";
            // 
            // grcPreventStatus
            // 
            this.grcPreventStatus.Caption = "BANDED GRID COLLUMN3";
            this.grcPreventStatus.ColumnEdit = this.rpi_chk_PreventStatus;
            this.grcPreventStatus.FieldName = "PreventativeActionStatus";
            this.grcPreventStatus.Name = "grcPreventStatus";
            this.grcPreventStatus.Visible = true;
            this.grcPreventStatus.Width = 93;
            // 
            // rpi_chk_PreventStatus
            // 
            this.rpi_chk_PreventStatus.AutoHeight = false;
            this.rpi_chk_PreventStatus.Name = "rpi_chk_PreventStatus";
            // 
            // grcPreventativeAction
            // 
            this.grcPreventativeAction.AutoFillDown = true;
            this.grcPreventativeAction.Caption = "PREVENTATIVE ACTION";
            this.grcPreventativeAction.ColumnEdit = this.rpi_mme_PreventativeAction;
            this.grcPreventativeAction.FieldName = "PreventativeAction";
            this.grcPreventativeAction.Name = "grcPreventativeAction";
            this.grcPreventativeAction.RowIndex = 1;
            this.grcPreventativeAction.Visible = true;
            this.grcPreventativeAction.Width = 405;
            // 
            // rpi_mme_PreventativeAction
            // 
            this.rpi_mme_PreventativeAction.Name = "rpi_mme_PreventativeAction";
            // 
            // gridBand5
            // 
            this.gridBand5.Caption = "FEEDBACK";
            this.gridBand5.Columns.Add(this.grcManagerFeedback);
            this.gridBand5.MinWidth = 13;
            this.gridBand5.Name = "gridBand5";
            this.gridBand5.VisibleIndex = 4;
            this.gridBand5.Width = 195;
            // 
            // grcManagerFeedback
            // 
            this.grcManagerFeedback.AutoFillDown = true;
            this.grcManagerFeedback.Caption = "MANAGER FEED BACK";
            this.grcManagerFeedback.ColumnEdit = this.rpi_mme_ManagerFeedback;
            this.grcManagerFeedback.FieldName = "ManagerFeedback";
            this.grcManagerFeedback.Name = "grcManagerFeedback";
            this.grcManagerFeedback.Visible = true;
            this.grcManagerFeedback.Width = 195;
            // 
            // rpi_mme_ManagerFeedback
            // 
            this.rpi_mme_ManagerFeedback.Name = "rpi_mme_ManagerFeedback";
            // 
            // grdBandInternalAuditDate
            // 
            this.grdBandInternalAuditDate.Caption = "Internal Audit Date";
            this.grdBandInternalAuditDate.Columns.Add(this.grcInternalAuditDate);
            this.grdBandInternalAuditDate.MinWidth = 13;
            this.grdBandInternalAuditDate.Name = "grdBandInternalAuditDate";
            this.grdBandInternalAuditDate.VisibleIndex = 5;
            this.grdBandInternalAuditDate.Width = 144;
            // 
            // grcInternalAuditDate
            // 
            this.grcInternalAuditDate.AutoFillDown = true;
            this.grcInternalAuditDate.Caption = "Internal Audit Date";
            this.grcInternalAuditDate.FieldName = "InternalAuditDate";
            this.grcInternalAuditDate.MinWidth = 27;
            this.grcInternalAuditDate.Name = "grcInternalAuditDate";
            this.grcInternalAuditDate.Visible = true;
            this.grcInternalAuditDate.Width = 144;
            // 
            // gridBand6
            // 
            this.gridBand6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand6.Caption = "X";
            this.gridBand6.Columns.Add(this.grcConfirmed);
            this.gridBand6.MinWidth = 13;
            this.gridBand6.Name = "gridBand6";
            this.gridBand6.VisibleIndex = 6;
            this.gridBand6.Width = 29;
            // 
            // grcConfirmed
            // 
            this.grcConfirmed.AutoFillDown = true;
            this.grcConfirmed.Caption = "INTERNAL AUDIT CONFIRMED";
            this.grcConfirmed.ColumnEdit = this.rpi_chk_Confirmed;
            this.grcConfirmed.FieldName = "InternalAuditConfirmed";
            this.grcConfirmed.Name = "grcConfirmed";
            this.grcConfirmed.Visible = true;
            this.grcConfirmed.Width = 29;
            // 
            // rpi_chk_Confirmed
            // 
            this.rpi_chk_Confirmed.AutoHeight = false;
            this.rpi_chk_Confirmed.Name = "rpi_chk_Confirmed";
            // 
            // bandedGridColumn9
            // 
            this.bandedGridColumn9.Caption = "BANDED GRID COLLUMN9";
            this.bandedGridColumn9.Name = "bandedGridColumn9";
            this.bandedGridColumn9.Visible = true;
            // 
            // chkAll
            // 
            this.chkAll.Location = new System.Drawing.Point(171, 472);
            this.chkAll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkAll.MenuManager = this.rbcbase;
            this.chkAll.Name = "chkAll";
            this.chkAll.Properties.Caption = "All";
            this.chkAll.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.chkAll.Size = new System.Drawing.Size(66, 24);
            this.chkAll.StyleController = this.layoutControl1;
            this.chkAll.TabIndex = 5;
            this.chkAll.Tag = "1";
            // 
            // chkAvailable
            // 
            this.chkAvailable.Location = new System.Drawing.Point(241, 472);
            this.chkAvailable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkAvailable.MenuManager = this.rbcbase;
            this.chkAvailable.Name = "chkAvailable";
            this.chkAvailable.Properties.Caption = "Available Confirm";
            this.chkAvailable.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.chkAvailable.Size = new System.Drawing.Size(191, 24);
            this.chkAvailable.StyleController = this.layoutControl1;
            this.chkAvailable.TabIndex = 6;
            this.chkAvailable.Tag = "2";
            // 
            // chkNotConfirm
            // 
            this.chkNotConfirm.Location = new System.Drawing.Point(436, 472);
            this.chkNotConfirm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkNotConfirm.MenuManager = this.rbcbase;
            this.chkNotConfirm.Name = "chkNotConfirm";
            this.chkNotConfirm.Properties.Caption = "Not-Confirmation";
            this.chkNotConfirm.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.chkNotConfirm.Size = new System.Drawing.Size(190, 24);
            this.chkNotConfirm.StyleController = this.layoutControl1;
            this.chkNotConfirm.TabIndex = 7;
            this.chkNotConfirm.Tag = "3";
            // 
            // dtFrom
            // 
            this.dtFrom.EditValue = null;
            this.dtFrom.Location = new System.Drawing.Point(672, 471);
            this.dtFrom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtFrom.MenuManager = this.rbcbase;
            this.dtFrom.MinimumSize = new System.Drawing.Size(0, 24);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFrom.Size = new System.Drawing.Size(151, 26);
            this.dtFrom.StyleController = this.layoutControl1;
            this.dtFrom.TabIndex = 8;
            // 
            // dtTo
            // 
            this.dtTo.EditValue = null;
            this.dtTo.Location = new System.Drawing.Point(866, 471);
            this.dtTo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtTo.MenuManager = this.rbcbase;
            this.dtTo.MinimumSize = new System.Drawing.Size(0, 24);
            this.dtTo.Name = "dtTo";
            this.dtTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtTo.Size = new System.Drawing.Size(160, 26);
            this.dtTo.StyleController = this.layoutControl1;
            this.dtTo.TabIndex = 9;
            // 
            // btnDataRaw
            // 
            this.btnDataRaw.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnDataRaw.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnDataRaw.Appearance.Options.UseBackColor = true;
            this.btnDataRaw.Appearance.Options.UseFont = true;
            this.btnDataRaw.Appearance.Options.UseTextOptions = true;
            this.btnDataRaw.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnDataRaw.AppearanceDisabled.Options.UseTextOptions = true;
            this.btnDataRaw.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnDataRaw.AppearanceHovered.Options.UseTextOptions = true;
            this.btnDataRaw.AppearanceHovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnDataRaw.AppearancePressed.Options.UseTextOptions = true;
            this.btnDataRaw.AppearancePressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnDataRaw.Location = new System.Drawing.Point(1185, 464);
            this.btnDataRaw.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDataRaw.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnDataRaw.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnDataRaw.Name = "btnDataRaw";
            this.btnDataRaw.Size = new System.Drawing.Size(125, 40);
            this.btnDataRaw.StyleController = this.layoutControl1;
            this.btnDataRaw.TabIndex = 10;
            this.btnDataRaw.Text = "Data Raw";
            // 
            // btnClose
            // 
            this.btnClose.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.btnClose.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnClose.Appearance.Options.UseBackColor = true;
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Appearance.Options.UseTextOptions = true;
            this.btnClose.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnClose.AppearanceDisabled.Options.UseTextOptions = true;
            this.btnClose.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnClose.AppearanceHovered.Options.UseTextOptions = true;
            this.btnClose.AppearanceHovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnClose.AppearancePressed.Options.UseTextOptions = true;
            this.btnClose.AppearancePressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnClose.Location = new System.Drawing.Point(1318, 464);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnClose.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(125, 40);
            this.btnClose.StyleController = this.layoutControl1;
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Close";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(49, 470);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTotal.MenuManager = this.rbcbase;
            this.txtTotal.MinimumSize = new System.Drawing.Size(0, 25);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Properties.Appearance.Options.UseFont = true;
            this.txtTotal.Properties.Mask.EditMask = "n0";
            this.txtTotal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotal.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTotal.Properties.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(111, 28);
            this.txtTotal.StyleController = this.layoutControl1;
            this.txtTotal.TabIndex = 12;
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.grdDataRaw;
            this.layoutControlItem10.Location = new System.Drawing.Point(0, 198);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(838, 199);
            this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem10.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem9,
            this.layoutControlGroup2,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1457, 518);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdProblemReview;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1437, 450);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.btnDataRaw;
            this.layoutControlItem7.Location = new System.Drawing.Point(1171, 450);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(133, 48);
            this.layoutControlItem7.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.btnClose;
            this.layoutControlItem8.Location = new System.Drawing.Point(1304, 450);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(133, 48);
            this.layoutControlItem8.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.dtFrom;
            this.layoutControlItem5.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.layoutControlItem5.Location = new System.Drawing.Point(623, 450);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(194, 48);
            this.layoutControlItem5.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem5.Text = "From";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(30, 16);
            this.layoutControlItem5.TrimClientAreaToControl = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.dtTo;
            this.layoutControlItem6.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.layoutControlItem6.Location = new System.Drawing.Point(817, 450);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(203, 48);
            this.layoutControlItem6.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem6.Text = "To";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(30, 16);
            this.layoutControlItem6.TrimClientAreaToControl = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.txtTotal;
            this.layoutControlItem9.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 450);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(154, 48);
            this.layoutControlItem9.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem9.Text = "Total";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(30, 16);
            this.layoutControlItem9.TrimClientAreaToControl = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.layoutControlGroup2.Location = new System.Drawing.Point(154, 450);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlGroup2.Size = new System.Drawing.Size(469, 48);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.chkAll;
            this.layoutControlItem2.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(70, 38);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            this.layoutControlItem2.TrimClientAreaToControl = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.chkAvailable;
            this.layoutControlItem3.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.layoutControlItem3.Location = new System.Drawing.Point(70, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(195, 38);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            this.layoutControlItem3.TrimClientAreaToControl = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.chkNotConfirm;
            this.layoutControlItem4.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.layoutControlItem4.Location = new System.Drawing.Point(265, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(194, 38);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            this.layoutControlItem4.TrimClientAreaToControl = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(1020, 450);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(151, 48);
            this.emptySpaceItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frm_S_AO_Dialog_ProblemReviewByDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1457, 569);
            this.Controls.Add(this.layoutControl1);
            this.Font = new System.Drawing.Font("Tahoma", 7.8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_S_AO_Dialog_ProblemReviewByDate.IconOptions.Icon")));
            this.IsFixHeightScreen = false;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_S_AO_Dialog_ProblemReviewByDate";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "Problem - Warning";
            this.Load += new System.EventHandler(this.frm_S_AO_Dialog_ProblemReviewByDate_Load);
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDataRaw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDataRaw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdProblemReview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProblemReview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_hpl_InternalAuditID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_chk_AuditStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_mme_ProblemDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_mme_CorrectiveAction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_chk_Required)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_chk_PreventStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_mme_PreventativeAction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_mme_ManagerFeedback)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_chk_Confirmed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAvailable.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNotConfirm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl grdProblemReview;
        private DevExpress.XtraEditors.CheckEdit chkAll;
        private DevExpress.XtraEditors.CheckEdit chkAvailable;
        private DevExpress.XtraEditors.CheckEdit chkNotConfirm;
        private DateEdit dtFrom;
        private DateEdit dtTo;
        private SimpleButton btnDataRaw;
        private SimpleButton btnClose;
        private LayoutControlItem layoutControlItem1;
        private LayoutControlItem layoutControlItem5;
        private LayoutControlItem layoutControlItem6;
        private LayoutControlItem layoutControlItem7;
        private LayoutControlItem layoutControlItem8;
        private AdvBandedGridView grvProblemReview;
        private BandedGridColumn grcInternalAuditID;
        private BandedGridColumn grcCorrectiveAction;
        private BandedGridColumn grcPreventStatus;
        private BandedGridColumn grcConfirmed;
        private BandedGridColumn grcPreventativeActionRequired;
        private BandedGridColumn grcCompleteBeforeDate;
        private BandedGridColumn grcPreventativeAction;
        private BandedGridColumn grcManagerFeedback;
        private BandedGridColumn bandedGridColumn9;
        private BandedGridColumn grcCorrectiveBeforeDate;
        private BandedGridColumn grcCorrectiveActionBy;
        private BandedGridColumn grcProblemDescription;
        private BandedGridColumn grcProblemCategoryDescription;
        private BandedGridColumn grcInternalAuditStatus;
        private BandedGridColumn grcPreventativeActionBy;
        private RepositoryItemCheckEdit rpi_chk_AuditStatus;
        private RepositoryItemMemoEdit rpi_mme_ProblemDescription;
        private RepositoryItemMemoEdit rpi_mme_CorrectiveAction;
        private RepositoryItemCheckEdit rpi_chk_Required;
        private RepositoryItemCheckEdit rpi_chk_PreventStatus;
        private RepositoryItemMemoEdit rpi_mme_PreventativeAction;
        private RepositoryItemMemoEdit rpi_mme_ManagerFeedback;
        private RepositoryItemCheckEdit rpi_chk_Confirmed;
        private TextEdit txtTotal;
        private LayoutControlItem layoutControlItem9;
        private LayoutControlGroup layoutControlGroup2;
        private LayoutControlItem layoutControlItem2;
        private LayoutControlItem layoutControlItem3;
        private LayoutControlItem layoutControlItem4;
        private DevExpress.XtraGrid.GridControl grdDataRaw;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDataRaw;
        private LayoutControlItem layoutControlItem10;
        private RepositoryItemHyperLinkEdit rpi_hpl_InternalAuditID;
        private EmptySpaceItem emptySpaceItem1;
        private BandedGridColumn grcInternalAuditDate;
        private GridBand gridBand1;
        private GridBand gridBand2;
        private GridBand gridBand3;
        private GridBand gridBand4;
        private GridBand gridBand5;
        private GridBand grdBandInternalAuditDate;
        private GridBand gridBand6;
    }
}