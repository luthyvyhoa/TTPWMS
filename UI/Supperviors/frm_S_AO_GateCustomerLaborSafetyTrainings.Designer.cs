namespace UI.Supperviors
{
    partial class frm_S_AO_GateCustomerLaborSafetyTrainings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_S_AO_GateCustomerLaborSafetyTrainings));
            DevExpress.XtraGrid.Columns.GridColumn grcTrainDate;
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.rpi_dt_TrainDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.lkeCustomerFind = new DevExpress.XtraEditors.LookUpEdit();
            this.grdSafetyTraining = new DevExpress.XtraGrid.GridControl();
            this.grvSafetyTraining = new Common.Controls.WMSGridView();
            this.grcWorkerID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcWorkerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCardID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCompany = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcTrainBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_btn_Delete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.grcTrainID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkAll = new DevExpress.XtraEditors.CheckEdit();
            this.chkCustomer = new DevExpress.XtraEditors.CheckEdit();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnNew = new DevExpress.XtraEditors.SimpleButton();
            this.btnCustomerWorkerAll = new DevExpress.XtraEditors.SimpleButton();
            this.btnCustomersToday = new DevExpress.XtraEditors.SimpleButton();
            this.btnEnable = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            grcTrainDate = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_dt_TrainDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_dt_TrainDate.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkeCustomerFind.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSafetyTraining)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSafetyTraining)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_btn_Delete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
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
            this.rbcbase.Size = new System.Drawing.Size(1148, 51);
            // 
            // grcTrainDate
            // 
            grcTrainDate.AppearanceCell.Options.UseTextOptions = true;
            grcTrainDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            grcTrainDate.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            grcTrainDate.AppearanceHeader.Options.UseTextOptions = true;
            grcTrainDate.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            grcTrainDate.Caption = "TRAINING DATE";
            grcTrainDate.ColumnEdit = this.rpi_dt_TrainDate;
            grcTrainDate.FieldName = "LaborSafetyTrainDate";
            grcTrainDate.MinWidth = 100;
            grcTrainDate.Name = "grcTrainDate";
            grcTrainDate.OptionsColumn.ReadOnly = true;
            grcTrainDate.Visible = true;
            grcTrainDate.VisibleIndex = 4;
            grcTrainDate.Width = 104;
            // 
            // rpi_dt_TrainDate
            // 
            this.rpi_dt_TrainDate.AutoHeight = false;
            this.rpi_dt_TrainDate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpi_dt_TrainDate.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpi_dt_TrainDate.Name = "rpi_dt_TrainDate";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.lkeCustomerFind);
            this.layoutControl1.Controls.Add(this.grdSafetyTraining);
            this.layoutControl1.Controls.Add(this.chkAll);
            this.layoutControl1.Controls.Add(this.chkCustomer);
            this.layoutControl1.Controls.Add(this.btnClose);
            this.layoutControl1.Controls.Add(this.btnNew);
            this.layoutControl1.Controls.Add(this.btnCustomerWorkerAll);
            this.layoutControl1.Controls.Add(this.btnCustomersToday);
            this.layoutControl1.Controls.Add(this.btnEnable);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 51);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(922, 301, 562, 500);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1148, 562);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // lkeCustomerFind
            // 
            this.lkeCustomerFind.Location = new System.Drawing.Point(176, 512);
            this.lkeCustomerFind.MenuManager = this.rbcbase;
            this.lkeCustomerFind.MinimumSize = new System.Drawing.Size(0, 24);
            this.lkeCustomerFind.Name = "lkeCustomerFind";
            this.lkeCustomerFind.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeCustomerFind.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyNumber", "Number", 100, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyName", "Name", 250, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lkeCustomerFind.Properties.DropDownRows = 20;
            this.lkeCustomerFind.Properties.NullText = "";
            this.lkeCustomerFind.Properties.PopupFormMinSize = new System.Drawing.Size(250, 0);
            this.lkeCustomerFind.Properties.ReadOnly = true;
            this.lkeCustomerFind.Properties.ShowFooter = false;
            this.lkeCustomerFind.Properties.ShowHeader = false;
            this.lkeCustomerFind.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lkeCustomerFind.Size = new System.Drawing.Size(107, 26);
            this.lkeCustomerFind.StyleController = this.layoutControl1;
            this.lkeCustomerFind.TabIndex = 7;
            // 
            // grdSafetyTraining
            // 
            this.grdSafetyTraining.Location = new System.Drawing.Point(12, 12);
            this.grdSafetyTraining.MainView = this.grvSafetyTraining;
            this.grdSafetyTraining.MenuManager = this.rbcbase;
            this.grdSafetyTraining.Name = "grdSafetyTraining";
            this.grdSafetyTraining.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpi_dt_TrainDate,
            this.rpi_btn_Delete});
            this.grdSafetyTraining.Size = new System.Drawing.Size(1124, 484);
            this.grdSafetyTraining.TabIndex = 4;
            this.grdSafetyTraining.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvSafetyTraining});
            // 
            // grvSafetyTraining
            // 
            this.grvSafetyTraining.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grvSafetyTraining.Appearance.FooterPanel.Options.UseFont = true;
            this.grvSafetyTraining.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvSafetyTraining.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grcWorkerID,
            this.grcWorkerName,
            this.grcCardID,
            this.grcCompany,
            grcTrainDate,
            this.grcTrainBy,
            this.grcDescription,
            this.grcDelete,
            this.grcTrainID});
            this.grvSafetyTraining.CustomizationFormBounds = new System.Drawing.Rectangle(1708, 553, 212, 212);
            this.grvSafetyTraining.GridControl = this.grdSafetyTraining;
            this.grvSafetyTraining.Name = "grvSafetyTraining";
            this.grvSafetyTraining.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.True;
            this.grvSafetyTraining.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvSafetyTraining.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grvSafetyTraining.OptionsSelection.MultiSelect = true;
            this.grvSafetyTraining.OptionsView.ShowGroupPanel = false;
            this.grvSafetyTraining.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvSafetyTraining.PaintStyleName = "Skin";
            // 
            // grcWorkerID
            // 
            this.grcWorkerID.AppearanceCell.Options.UseTextOptions = true;
            this.grcWorkerID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcWorkerID.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcWorkerID.AppearanceHeader.Options.UseTextOptions = true;
            this.grcWorkerID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcWorkerID.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcWorkerID.Caption = "ID";
            this.grcWorkerID.FieldName = "WorkerID";
            this.grcWorkerID.MaxWidth = 80;
            this.grcWorkerID.MinWidth = 80;
            this.grcWorkerID.Name = "grcWorkerID";
            this.grcWorkerID.OptionsColumn.ReadOnly = true;
            this.grcWorkerID.Visible = true;
            this.grcWorkerID.VisibleIndex = 0;
            this.grcWorkerID.Width = 80;
            // 
            // grcWorkerName
            // 
            this.grcWorkerName.AppearanceCell.Options.UseTextOptions = true;
            this.grcWorkerName.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcWorkerName.AppearanceHeader.Options.UseTextOptions = true;
            this.grcWorkerName.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcWorkerName.Caption = "Employee Name";
            this.grcWorkerName.FieldName = "WorkerName";
            this.grcWorkerName.Name = "grcWorkerName";
            this.grcWorkerName.OptionsColumn.ReadOnly = true;
            this.grcWorkerName.Visible = true;
            this.grcWorkerName.VisibleIndex = 1;
            this.grcWorkerName.Width = 208;
            // 
            // grcCardID
            // 
            this.grcCardID.AppearanceCell.Options.UseTextOptions = true;
            this.grcCardID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcCardID.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcCardID.AppearanceHeader.Options.UseTextOptions = true;
            this.grcCardID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcCardID.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcCardID.Caption = "ID CARD";
            this.grcCardID.FieldName = "CardID";
            this.grcCardID.MaxWidth = 100;
            this.grcCardID.MinWidth = 100;
            this.grcCardID.Name = "grcCardID";
            this.grcCardID.OptionsColumn.ReadOnly = true;
            this.grcCardID.Visible = true;
            this.grcCardID.VisibleIndex = 2;
            this.grcCardID.Width = 100;
            // 
            // grcCompany
            // 
            this.grcCompany.AppearanceCell.Options.UseTextOptions = true;
            this.grcCompany.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcCompany.AppearanceHeader.Options.UseTextOptions = true;
            this.grcCompany.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcCompany.Caption = "COMPAY NAME";
            this.grcCompany.FieldName = "CompanyName";
            this.grcCompany.Name = "grcCompany";
            this.grcCompany.OptionsColumn.ReadOnly = true;
            this.grcCompany.Visible = true;
            this.grcCompany.VisibleIndex = 3;
            this.grcCompany.Width = 251;
            // 
            // grcTrainBy
            // 
            this.grcTrainBy.AppearanceCell.Options.UseTextOptions = true;
            this.grcTrainBy.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcTrainBy.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcTrainBy.AppearanceHeader.Options.UseTextOptions = true;
            this.grcTrainBy.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcTrainBy.Caption = "TRAINEE";
            this.grcTrainBy.FieldName = "LaborSafetyTrainBy";
            this.grcTrainBy.MaxWidth = 100;
            this.grcTrainBy.MinWidth = 100;
            this.grcTrainBy.Name = "grcTrainBy";
            this.grcTrainBy.OptionsColumn.ReadOnly = true;
            this.grcTrainBy.Visible = true;
            this.grcTrainBy.VisibleIndex = 5;
            this.grcTrainBy.Width = 100;
            // 
            // grcDescription
            // 
            this.grcDescription.AppearanceCell.Options.UseTextOptions = true;
            this.grcDescription.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcDescription.AppearanceHeader.Options.UseTextOptions = true;
            this.grcDescription.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcDescription.Caption = "REMARK";
            this.grcDescription.FieldName = "Description";
            this.grcDescription.Name = "grcDescription";
            this.grcDescription.OptionsColumn.ReadOnly = true;
            this.grcDescription.Visible = true;
            this.grcDescription.VisibleIndex = 6;
            this.grcDescription.Width = 220;
            // 
            // grcDelete
            // 
            this.grcDelete.AppearanceCell.Options.UseTextOptions = true;
            this.grcDelete.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcDelete.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.grcDelete.AppearanceHeader.Options.UseFont = true;
            this.grcDelete.AppearanceHeader.Options.UseTextOptions = true;
            this.grcDelete.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcDelete.ColumnEdit = this.rpi_btn_Delete;
            this.grcDelete.MaxWidth = 35;
            this.grcDelete.MinWidth = 35;
            this.grcDelete.Name = "grcDelete";
            this.grcDelete.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.grcDelete.Visible = true;
            this.grcDelete.VisibleIndex = 7;
            this.grcDelete.Width = 35;
            // 
            // rpi_btn_Delete
            // 
            this.rpi_btn_Delete.AutoHeight = false;
            editorButtonImageOptions1.Image = global::UI.Properties.Resources.cancel_16x16;
            this.rpi_btn_Delete.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.rpi_btn_Delete.Name = "rpi_btn_Delete";
            this.rpi_btn_Delete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // grcTrainID
            // 
            this.grcTrainID.AppearanceCell.Options.UseTextOptions = true;
            this.grcTrainID.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcTrainID.AppearanceHeader.Options.UseTextOptions = true;
            this.grcTrainID.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcTrainID.Caption = "TrainingID";
            this.grcTrainID.FieldName = "LaborSafetyTrainID";
            this.grcTrainID.Name = "grcTrainID";
            // 
            // chkAll
            // 
            this.chkAll.EditValue = true;
            this.chkAll.Location = new System.Drawing.Point(24, 513);
            this.chkAll.MenuManager = this.rbcbase;
            this.chkAll.Name = "chkAll";
            this.chkAll.Properties.Caption = "All";
            this.chkAll.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.chkAll.Size = new System.Drawing.Size(54, 24);
            this.chkAll.StyleController = this.layoutControl1;
            this.chkAll.TabIndex = 5;
            this.chkAll.Tag = "1";
            // 
            // chkCustomer
            // 
            this.chkCustomer.Location = new System.Drawing.Point(82, 513);
            this.chkCustomer.MenuManager = this.rbcbase;
            this.chkCustomer.Name = "chkCustomer";
            this.chkCustomer.Properties.Caption = "Customer";
            this.chkCustomer.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.chkCustomer.Size = new System.Drawing.Size(90, 24);
            this.chkCustomer.StyleController = this.layoutControl1;
            this.chkCustomer.TabIndex = 6;
            this.chkCustomer.Tag = "2";
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
            this.btnClose.Location = new System.Drawing.Point(1009, 505);
            this.btnClose.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnClose.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(125, 40);
            this.btnClose.StyleController = this.layoutControl1;
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            // 
            // btnNew
            // 
            this.btnNew.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Question;
            this.btnNew.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnNew.Appearance.Options.UseBackColor = true;
            this.btnNew.Appearance.Options.UseFont = true;
            this.btnNew.Appearance.Options.UseTextOptions = true;
            this.btnNew.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnNew.AppearanceDisabled.Options.UseTextOptions = true;
            this.btnNew.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnNew.AppearanceHovered.Options.UseTextOptions = true;
            this.btnNew.AppearanceHovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnNew.AppearancePressed.Options.UseTextOptions = true;
            this.btnNew.AppearancePressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnNew.Location = new System.Drawing.Point(477, 505);
            this.btnNew.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnNew.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(125, 40);
            this.btnNew.StyleController = this.layoutControl1;
            this.btnNew.TabIndex = 9;
            this.btnNew.Text = "New";
            // 
            // btnCustomerWorkerAll
            // 
            this.btnCustomerWorkerAll.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnCustomerWorkerAll.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnCustomerWorkerAll.Appearance.Options.UseBackColor = true;
            this.btnCustomerWorkerAll.Appearance.Options.UseFont = true;
            this.btnCustomerWorkerAll.Appearance.Options.UseTextOptions = true;
            this.btnCustomerWorkerAll.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnCustomerWorkerAll.AppearanceDisabled.Options.UseTextOptions = true;
            this.btnCustomerWorkerAll.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnCustomerWorkerAll.AppearanceHovered.Options.UseTextOptions = true;
            this.btnCustomerWorkerAll.AppearanceHovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnCustomerWorkerAll.AppearancePressed.Options.UseTextOptions = true;
            this.btnCustomerWorkerAll.AppearancePressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnCustomerWorkerAll.Location = new System.Drawing.Point(610, 505);
            this.btnCustomerWorkerAll.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnCustomerWorkerAll.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnCustomerWorkerAll.Name = "btnCustomerWorkerAll";
            this.btnCustomerWorkerAll.Size = new System.Drawing.Size(125, 40);
            this.btnCustomerWorkerAll.StyleController = this.layoutControl1;
            this.btnCustomerWorkerAll.TabIndex = 10;
            this.btnCustomerWorkerAll.Text = "Customer / Worker All";
            // 
            // btnCustomersToday
            // 
            this.btnCustomersToday.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnCustomersToday.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnCustomersToday.Appearance.Options.UseBackColor = true;
            this.btnCustomersToday.Appearance.Options.UseFont = true;
            this.btnCustomersToday.Appearance.Options.UseTextOptions = true;
            this.btnCustomersToday.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnCustomersToday.AppearanceDisabled.Options.UseTextOptions = true;
            this.btnCustomersToday.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnCustomersToday.AppearanceHovered.Options.UseTextOptions = true;
            this.btnCustomersToday.AppearanceHovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnCustomersToday.AppearancePressed.Options.UseTextOptions = true;
            this.btnCustomersToday.AppearancePressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnCustomersToday.Location = new System.Drawing.Point(743, 505);
            this.btnCustomersToday.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnCustomersToday.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnCustomersToday.Name = "btnCustomersToday";
            this.btnCustomersToday.Size = new System.Drawing.Size(125, 40);
            this.btnCustomersToday.StyleController = this.layoutControl1;
            this.btnCustomersToday.TabIndex = 11;
            this.btnCustomersToday.Text = "Customers Today";
            // 
            // btnEnable
            // 
            this.btnEnable.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnEnable.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnEnable.Appearance.Options.UseBackColor = true;
            this.btnEnable.Appearance.Options.UseFont = true;
            this.btnEnable.Appearance.Options.UseTextOptions = true;
            this.btnEnable.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnEnable.AppearanceDisabled.Options.UseTextOptions = true;
            this.btnEnable.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnEnable.AppearanceHovered.Options.UseTextOptions = true;
            this.btnEnable.AppearanceHovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnEnable.AppearancePressed.Options.UseTextOptions = true;
            this.btnEnable.AppearancePressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnEnable.Location = new System.Drawing.Point(876, 505);
            this.btnEnable.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnEnable.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnEnable.Name = "btnEnable";
            this.btnEnable.Size = new System.Drawing.Size(125, 40);
            this.btnEnable.StyleController = this.layoutControl1;
            this.btnEnable.TabIndex = 12;
            this.btnEnable.Text = "Enable";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItem9,
            this.emptySpaceItem1,
            this.layoutControlGroup2});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1148, 562);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdSafetyTraining;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1128, 488);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnClose;
            this.layoutControlItem5.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.layoutControlItem5.Location = new System.Drawing.Point(995, 488);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(133, 54);
            this.layoutControlItem5.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            this.layoutControlItem5.TrimClientAreaToControl = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnNew;
            this.layoutControlItem6.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.layoutControlItem6.Location = new System.Drawing.Point(463, 488);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(133, 54);
            this.layoutControlItem6.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            this.layoutControlItem6.TrimClientAreaToControl = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.btnCustomerWorkerAll;
            this.layoutControlItem7.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.layoutControlItem7.Location = new System.Drawing.Point(596, 488);
            this.layoutControlItem7.MaxSize = new System.Drawing.Size(133, 48);
            this.layoutControlItem7.MinSize = new System.Drawing.Size(133, 48);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(133, 54);
            this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem7.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            this.layoutControlItem7.TrimClientAreaToControl = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.btnCustomersToday;
            this.layoutControlItem8.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.layoutControlItem8.Location = new System.Drawing.Point(729, 488);
            this.layoutControlItem8.MaxSize = new System.Drawing.Size(133, 48);
            this.layoutControlItem8.MinSize = new System.Drawing.Size(133, 48);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(133, 54);
            this.layoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem8.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            this.layoutControlItem8.TrimClientAreaToControl = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.btnEnable;
            this.layoutControlItem9.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.layoutControlItem9.Location = new System.Drawing.Point(862, 488);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(133, 54);
            this.layoutControlItem9.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            this.layoutControlItem9.TrimClientAreaToControl = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(287, 488);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(176, 54);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem2});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 488);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup2.Size = new System.Drawing.Size(287, 54);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.chkCustomer;
            this.layoutControlItem3.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.layoutControlItem3.Location = new System.Drawing.Point(58, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(94, 30);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            this.layoutControlItem3.TrimClientAreaToControl = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.lkeCustomerFind;
            this.layoutControlItem4.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.layoutControlItem4.Location = new System.Drawing.Point(152, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(111, 30);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            this.layoutControlItem4.TrimClientAreaToControl = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.chkAll;
            this.layoutControlItem2.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(58, 30);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            this.layoutControlItem2.TrimClientAreaToControl = false;
            // 
            // frm_S_AO_GateCustomerLaborSafetyTrainings
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1148, 613);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_S_AO_GateCustomerLaborSafetyTrainings.IconOptions.Icon")));
            this.Name = "frm_S_AO_GateCustomerLaborSafetyTrainings";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "Customer/Workers Labor Safety Trainings";
            this.Load += new System.EventHandler(this.frm_S_AO_GateCustomerLaborSafetyTrainings_Load);
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_dt_TrainDate.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_dt_TrainDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lkeCustomerFind.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSafetyTraining)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSafetyTraining)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_btn_Delete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl grdSafetyTraining;
        private Common.Controls.WMSGridView grvSafetyTraining;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.LookUpEdit lkeCustomerFind;
        private DevExpress.XtraEditors.CheckEdit chkAll;
        private DevExpress.XtraEditors.CheckEdit chkCustomer;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnNew;
        private DevExpress.XtraEditors.SimpleButton btnCustomerWorkerAll;
        private DevExpress.XtraEditors.SimpleButton btnCustomersToday;
        private DevExpress.XtraEditors.SimpleButton btnEnable;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraGrid.Columns.GridColumn grcWorkerID;
        private DevExpress.XtraGrid.Columns.GridColumn grcWorkerName;
        private DevExpress.XtraGrid.Columns.GridColumn grcCardID;
        private DevExpress.XtraGrid.Columns.GridColumn grcCompany;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit rpi_dt_TrainDate;
        private DevExpress.XtraGrid.Columns.GridColumn grcTrainBy;
        private DevExpress.XtraGrid.Columns.GridColumn grcDescription;
        private DevExpress.XtraGrid.Columns.GridColumn grcDelete;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rpi_btn_Delete;
        private DevExpress.XtraGrid.Columns.GridColumn grcTrainID;
    }
}