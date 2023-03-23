namespace UI.MasterSystemSetup
{
    partial class urc_MSS_CustomerRequirements
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grdCustomerRequirements = new DevExpress.XtraGrid.GridControl();
            this.grvCustomerRequirements = new Common.Controls.WMSGridView();
            this.grcUpdateBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcUpdateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcRequirementCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_lke_RequirementCategory = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.grcApprovedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcConfirmed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_chk_Confirmed = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.grcRequirementDetails = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_mme_RequirementDetails = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.grcCustomerRequirementID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerMainID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCustomerRequirements)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCustomerRequirements)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_RequirementCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_chk_Confirmed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_mme_RequirementDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grdCustomerRequirements);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(904, 492);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grdCustomerRequirements
            // 
            this.grdCustomerRequirements.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.grdCustomerRequirements.Location = new System.Drawing.Point(5, 5);
            this.grdCustomerRequirements.MainView = this.grvCustomerRequirements;
            this.grdCustomerRequirements.Margin = new System.Windows.Forms.Padding(4);
            this.grdCustomerRequirements.Name = "grdCustomerRequirements";
            this.grdCustomerRequirements.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpi_lke_RequirementCategory,
            this.rpi_chk_Confirmed,
            this.rpi_mme_RequirementDetails});
            this.grdCustomerRequirements.Size = new System.Drawing.Size(894, 482);
            this.grdCustomerRequirements.TabIndex = 4;
            this.grdCustomerRequirements.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvCustomerRequirements});
            // 
            // grvCustomerRequirements
            // 
            this.grvCustomerRequirements.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grvCustomerRequirements.Appearance.FooterPanel.Options.UseFont = true;
            this.grvCustomerRequirements.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvCustomerRequirements.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grcUpdateBy,
            this.grcUpdateTime,
            this.grcRequirementCategory,
            this.grcApprovedBy,
            this.grcConfirmed,
            this.grcRequirementDetails,
            this.grcCustomerRequirementID,
            this.grcCustomerMainID});
            this.grvCustomerRequirements.GridControl = this.grdCustomerRequirements;
            this.grvCustomerRequirements.Name = "grvCustomerRequirements";
            this.grvCustomerRequirements.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grvCustomerRequirements.OptionsCustomization.AllowFilter = false;
            this.grvCustomerRequirements.OptionsSelection.MultiSelect = true;
            this.grvCustomerRequirements.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.grvCustomerRequirements.OptionsView.RowAutoHeight = true;
            this.grvCustomerRequirements.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvCustomerRequirements.OptionsView.ShowGroupPanel = false;
            this.grvCustomerRequirements.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvCustomerRequirements.PaintStyleName = "Skin";
            // 
            // grcUpdateBy
            // 
            this.grcUpdateBy.Caption = "UPDATED BY";
            this.grcUpdateBy.FieldName = "UpdateBy";
            this.grcUpdateBy.MaxWidth = 80;
            this.grcUpdateBy.MinWidth = 80;
            this.grcUpdateBy.Name = "grcUpdateBy";
            this.grcUpdateBy.Visible = true;
            this.grcUpdateBy.VisibleIndex = 0;
            this.grcUpdateBy.Width = 80;
            // 
            // grcUpdateTime
            // 
            this.grcUpdateTime.Caption = "TIME";
            this.grcUpdateTime.FieldName = "UpdateTime";
            this.grcUpdateTime.Name = "grcUpdateTime";
            this.grcUpdateTime.OptionsColumn.AllowEdit = false;
            this.grcUpdateTime.OptionsColumn.ReadOnly = true;
            this.grcUpdateTime.Visible = true;
            this.grcUpdateTime.VisibleIndex = 1;
            this.grcUpdateTime.Width = 148;
            // 
            // grcRequirementCategory
            // 
            this.grcRequirementCategory.Caption = "CATEGORY";
            this.grcRequirementCategory.ColumnEdit = this.rpi_lke_RequirementCategory;
            this.grcRequirementCategory.FieldName = "RequirementCategory";
            this.grcRequirementCategory.MinWidth = 100;
            this.grcRequirementCategory.Name = "grcRequirementCategory";
            this.grcRequirementCategory.Visible = true;
            this.grcRequirementCategory.VisibleIndex = 2;
            this.grcRequirementCategory.Width = 149;
            // 
            // rpi_lke_RequirementCategory
            // 
            this.rpi_lke_RequirementCategory.AutoHeight = false;
            this.rpi_lke_RequirementCategory.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpi_lke_RequirementCategory.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
            this.rpi_lke_RequirementCategory.Name = "rpi_lke_RequirementCategory";
            this.rpi_lke_RequirementCategory.NullText = "";
            // 
            // grcApprovedBy
            // 
            this.grcApprovedBy.Caption = "APPROVED";
            this.grcApprovedBy.FieldName = "ApprovedBy";
            this.grcApprovedBy.MaxWidth = 100;
            this.grcApprovedBy.MinWidth = 100;
            this.grcApprovedBy.Name = "grcApprovedBy";
            this.grcApprovedBy.OptionsColumn.AllowEdit = false;
            this.grcApprovedBy.OptionsColumn.ReadOnly = true;
            this.grcApprovedBy.Visible = true;
            this.grcApprovedBy.VisibleIndex = 3;
            this.grcApprovedBy.Width = 100;
            // 
            // grcConfirmed
            // 
            this.grcConfirmed.Caption = "CONFIRMED";
            this.grcConfirmed.ColumnEdit = this.rpi_chk_Confirmed;
            this.grcConfirmed.FieldName = "RequirementConfirmed";
            this.grcConfirmed.MaxWidth = 35;
            this.grcConfirmed.MinWidth = 35;
            this.grcConfirmed.Name = "grcConfirmed";
            this.grcConfirmed.Visible = true;
            this.grcConfirmed.VisibleIndex = 4;
            this.grcConfirmed.Width = 35;
            // 
            // rpi_chk_Confirmed
            // 
            this.rpi_chk_Confirmed.Name = "rpi_chk_Confirmed";
            // 
            // grcRequirementDetails
            // 
            this.grcRequirementDetails.Caption = "DETAILS";
            this.grcRequirementDetails.ColumnEdit = this.rpi_mme_RequirementDetails;
            this.grcRequirementDetails.FieldName = "RequirementDetails";
            this.grcRequirementDetails.Name = "grcRequirementDetails";
            this.grcRequirementDetails.Visible = true;
            this.grcRequirementDetails.VisibleIndex = 5;
            this.grcRequirementDetails.Width = 583;
            // 
            // rpi_mme_RequirementDetails
            // 
            this.rpi_mme_RequirementDetails.Name = "rpi_mme_RequirementDetails";
            // 
            // grcCustomerRequirementID
            // 
            this.grcCustomerRequirementID.Caption = "ID";
            this.grcCustomerRequirementID.FieldName = "CustomerRequirementID";
            this.grcCustomerRequirementID.Name = "grcCustomerRequirementID";
            // 
            // grcCustomerMainID
            // 
            this.grcCustomerMainID.Caption = "CUSTOMER MAIN ID";
            this.grcCustomerMainID.FieldName = "CustomerMainID";
            this.grcCustomerMainID.Name = "grcCustomerMainID";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(904, 492);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdCustomerRequirements;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(904, 492);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // urc_MSS_CustomerRequirements
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "urc_MSS_CustomerRequirements";
            this.Size = new System.Drawing.Size(904, 492);
            this.Load += new System.EventHandler(this.urc_MSS_CustomerRequirements_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCustomerRequirements)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCustomerRequirements)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_RequirementCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_chk_Confirmed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_mme_RequirementDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl grdCustomerRequirements;
        private Common.Controls.WMSGridView grvCustomerRequirements;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn grcUpdateBy;
        private DevExpress.XtraGrid.Columns.GridColumn grcUpdateTime;
        private DevExpress.XtraGrid.Columns.GridColumn grcRequirementCategory;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpi_lke_RequirementCategory;
        private DevExpress.XtraGrid.Columns.GridColumn grcApprovedBy;
        private DevExpress.XtraGrid.Columns.GridColumn grcConfirmed;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rpi_chk_Confirmed;
        private DevExpress.XtraGrid.Columns.GridColumn grcRequirementDetails;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerRequirementID;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerMainID;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit rpi_mme_RequirementDetails;
    }
}
