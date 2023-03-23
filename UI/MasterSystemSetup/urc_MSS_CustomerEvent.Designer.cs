namespace UI.MasterSystemSetup
{
    partial class urc_MSS_CustomerEvent
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grdCustomerEvents = new DevExpress.XtraGrid.GridControl();
            this.grvCustomerEvents = new Common.Controls.WMSGridView();
            this.grcUpdateBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcUpdateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcRequirementCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_lke_Confidential = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.grcApprovedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcConfirmed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_chk_Confirmed = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.grcRequirementDetails = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.grcCustomerRequirementID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerMainID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_lke_Category = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rpi_mme_RequirementDetails = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCustomerEvents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCustomerEvents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_Confidential)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_chk_Confirmed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_Category)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_mme_RequirementDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grdCustomerEvents);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(678, 400);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grdCustomerEvents
            // 
            this.grdCustomerEvents.Location = new System.Drawing.Point(12, 12);
            this.grdCustomerEvents.MainView = this.grvCustomerEvents;
            this.grdCustomerEvents.Name = "grdCustomerEvents";
            this.grdCustomerEvents.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpi_lke_Confidential,
            this.rpi_chk_Confirmed,
            this.rpi_mme_RequirementDetails,
            this.rpi_lke_Category,
            this.repositoryItemMemoEdit1});
            this.grdCustomerEvents.Size = new System.Drawing.Size(654, 376);
            this.grdCustomerEvents.TabIndex = 4;
            this.grdCustomerEvents.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvCustomerEvents});
            // 
            // grvCustomerEvents
            // 
            this.grvCustomerEvents.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grvCustomerEvents.Appearance.FooterPanel.Options.UseFont = true;
            this.grvCustomerEvents.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvCustomerEvents.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grcUpdateBy,
            this.grcUpdateTime,
            this.grcRequirementCategory,
            this.grcApprovedBy,
            this.grcConfirmed,
            this.grcRequirementDetails,
            this.grcCustomerRequirementID,
            this.grcCustomerMainID,
            this.grcCategory});
            this.grvCustomerEvents.DetailHeight = 284;
            this.grvCustomerEvents.GridControl = this.grdCustomerEvents;
            this.grvCustomerEvents.Name = "grvCustomerEvents";
            this.grvCustomerEvents.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grvCustomerEvents.OptionsCustomization.AllowFilter = false;
            this.grvCustomerEvents.OptionsCustomization.AllowRowSizing = true;
            this.grvCustomerEvents.OptionsDetail.SmartDetailHeight = true;
            this.grvCustomerEvents.OptionsSelection.MultiSelect = true;
            this.grvCustomerEvents.OptionsView.RowAutoHeight = true;
            this.grvCustomerEvents.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvCustomerEvents.OptionsView.ShowGroupPanel = false;
            this.grvCustomerEvents.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvCustomerEvents.PaintStyleName = "Skin";
            // 
            // grcUpdateBy
            // 
            this.grcUpdateBy.Caption = "CREATED BY";
            this.grcUpdateBy.FieldName = "CreatedBy";
            this.grcUpdateBy.MaxWidth = 67;
            this.grcUpdateBy.MinWidth = 67;
            this.grcUpdateBy.Name = "grcUpdateBy";
            this.grcUpdateBy.OptionsColumn.AllowEdit = false;
            this.grcUpdateBy.Visible = true;
            this.grcUpdateBy.VisibleIndex = 0;
            this.grcUpdateBy.Width = 67;
            // 
            // grcUpdateTime
            // 
            this.grcUpdateTime.Caption = "DATE APPLY";
            this.grcUpdateTime.FieldName = "EventDate";
            this.grcUpdateTime.MinWidth = 15;
            this.grcUpdateTime.Name = "grcUpdateTime";
            this.grcUpdateTime.OptionsColumn.AllowEdit = false;
            this.grcUpdateTime.Visible = true;
            this.grcUpdateTime.VisibleIndex = 1;
            this.grcUpdateTime.Width = 68;
            // 
            // grcRequirementCategory
            // 
            this.grcRequirementCategory.Caption = "CONFIDENTIALITY";
            this.grcRequirementCategory.ColumnEdit = this.rpi_lke_Confidential;
            this.grcRequirementCategory.FieldName = "ConfidentialLevel";
            this.grcRequirementCategory.MinWidth = 75;
            this.grcRequirementCategory.Name = "grcRequirementCategory";
            this.grcRequirementCategory.Visible = true;
            this.grcRequirementCategory.VisibleIndex = 2;
            this.grcRequirementCategory.Width = 94;
            // 
            // rpi_lke_Confidential
            // 
            this.rpi_lke_Confidential.AutoHeight = false;
            this.rpi_lke_Confidential.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpi_lke_Confidential.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
            this.rpi_lke_Confidential.Name = "rpi_lke_Confidential";
            this.rpi_lke_Confidential.NullText = "";
            this.rpi_lke_Confidential.EditValueChanged += new System.EventHandler(this.rpi_lke_Confidential_EditValueChanged);
            // 
            // grcApprovedBy
            // 
            this.grcApprovedBy.Caption = "APPROVED";
            this.grcApprovedBy.FieldName = "ConfirmedBy";
            this.grcApprovedBy.MaxWidth = 60;
            this.grcApprovedBy.MinWidth = 60;
            this.grcApprovedBy.Name = "grcApprovedBy";
            this.grcApprovedBy.OptionsColumn.AllowEdit = false;
            this.grcApprovedBy.Visible = true;
            this.grcApprovedBy.VisibleIndex = 4;
            this.grcApprovedBy.Width = 60;
            // 
            // grcConfirmed
            // 
            this.grcConfirmed.Caption = "CONFIRMED";
            this.grcConfirmed.ColumnEdit = this.rpi_chk_Confirmed;
            this.grcConfirmed.FieldName = "Confirmed";
            this.grcConfirmed.MaxWidth = 26;
            this.grcConfirmed.MinWidth = 26;
            this.grcConfirmed.Name = "grcConfirmed";
            this.grcConfirmed.Visible = true;
            this.grcConfirmed.VisibleIndex = 5;
            this.grcConfirmed.Width = 26;
            // 
            // rpi_chk_Confirmed
            // 
            this.rpi_chk_Confirmed.Name = "rpi_chk_Confirmed";
            this.rpi_chk_Confirmed.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.rpi_chk_Confirmed.CheckedChanged += new System.EventHandler(this.rpi_chk_Confirmed_CheckedChanged);
            // 
            // grcRequirementDetails
            // 
            this.grcRequirementDetails.Caption = "DETAILS";
            this.grcRequirementDetails.ColumnEdit = this.repositoryItemMemoEdit1;
            this.grcRequirementDetails.FieldName = "EventDescription";
            this.grcRequirementDetails.MinWidth = 15;
            this.grcRequirementDetails.Name = "grcRequirementDetails";
            this.grcRequirementDetails.Visible = true;
            this.grcRequirementDetails.VisibleIndex = 6;
            this.grcRequirementDetails.Width = 263;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // grcCustomerRequirementID
            // 
            this.grcCustomerRequirementID.Caption = "ID";
            this.grcCustomerRequirementID.FieldName = "CustomerEventID";
            this.grcCustomerRequirementID.MinWidth = 15;
            this.grcCustomerRequirementID.Name = "grcCustomerRequirementID";
            this.grcCustomerRequirementID.OptionsColumn.AllowEdit = false;
            this.grcCustomerRequirementID.Width = 56;
            // 
            // grcCustomerMainID
            // 
            this.grcCustomerMainID.Caption = "CUSTOMER MAIN ID";
            this.grcCustomerMainID.FieldName = "CustomerMainID";
            this.grcCustomerMainID.MinWidth = 15;
            this.grcCustomerMainID.Name = "grcCustomerMainID";
            this.grcCustomerMainID.OptionsColumn.AllowEdit = false;
            this.grcCustomerMainID.Width = 56;
            // 
            // grcCategory
            // 
            this.grcCategory.Caption = "CATEGORY";
            this.grcCategory.ColumnEdit = this.rpi_lke_Category;
            this.grcCategory.FieldName = "EventCategory";
            this.grcCategory.MinWidth = 15;
            this.grcCategory.Name = "grcCategory";
            this.grcCategory.Visible = true;
            this.grcCategory.VisibleIndex = 3;
            this.grcCategory.Width = 64;
            // 
            // rpi_lke_Category
            // 
            this.rpi_lke_Category.AutoHeight = false;
            this.rpi_lke_Category.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.rpi_lke_Category.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpi_lke_Category.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
            this.rpi_lke_Category.DropDownRows = 3;
            this.rpi_lke_Category.ImmediatePopup = true;
            this.rpi_lke_Category.Name = "rpi_lke_Category";
            this.rpi_lke_Category.NullText = "";
            this.rpi_lke_Category.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.StartsWith;
            this.rpi_lke_Category.EditValueChanged += new System.EventHandler(this.rpi_lke_Category_EditValueChanged);
            // 
            // rpi_mme_RequirementDetails
            // 
            this.rpi_mme_RequirementDetails.Name = "rpi_mme_RequirementDetails";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(678, 400);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdCustomerEvents;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(658, 380);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // urc_MSS_CustomerEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "urc_MSS_CustomerEvent";
            this.Size = new System.Drawing.Size(678, 400);
            this.Load += new System.EventHandler(this.urc_MSS_CustomerEvent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCustomerEvents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCustomerEvents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_Confidential)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_chk_Confirmed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_Category)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_mme_RequirementDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl grdCustomerEvents;
        private Common.Controls.WMSGridView grvCustomerEvents;
        private DevExpress.XtraGrid.Columns.GridColumn grcUpdateBy;
        private DevExpress.XtraGrid.Columns.GridColumn grcUpdateTime;
        private DevExpress.XtraGrid.Columns.GridColumn grcRequirementCategory;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpi_lke_Confidential;
        private DevExpress.XtraGrid.Columns.GridColumn grcApprovedBy;
        private DevExpress.XtraGrid.Columns.GridColumn grcConfirmed;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rpi_chk_Confirmed;
        private DevExpress.XtraGrid.Columns.GridColumn grcRequirementDetails;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit rpi_mme_RequirementDetails;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerRequirementID;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerMainID;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn grcCategory;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpi_lke_Category;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
    }
}
