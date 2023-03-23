namespace UI.Supperviors
{
    partial class frm_S_AO_Dialog_GateCustomerLaborSafetyTrainingInOut
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_S_AO_Dialog_GateCustomerLaborSafetyTrainingInOut));
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grdWorkerInOut = new DevExpress.XtraGrid.GridControl();
            this.grvWorkerInOut = new Common.Controls.WMSGridView();
            this.grcWorkerID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcWorkerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCompany = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcTraining = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_chk_Training = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.grcTrainDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcTrainingAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_btn_TrainingAdd = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.grcTimeIn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcTimeOut = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_txt_Remark = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.grcGate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcInOutID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdWorkerInOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvWorkerInOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_chk_Training)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_btn_TrainingAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_txt_Remark)).BeginInit();
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
            this.rbcbase.Size = new System.Drawing.Size(1312, 51);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grdWorkerInOut);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 51);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1312, 822);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grdWorkerInOut
            // 
            this.grdWorkerInOut.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.grdWorkerInOut.Location = new System.Drawing.Point(12, 12);
            this.grdWorkerInOut.MainView = this.grvWorkerInOut;
            this.grdWorkerInOut.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdWorkerInOut.MenuManager = this.rbcbase;
            this.grdWorkerInOut.Name = "grdWorkerInOut";
            this.grdWorkerInOut.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpi_chk_Training,
            this.rpi_btn_TrainingAdd,
            this.rpi_txt_Remark});
            this.grdWorkerInOut.Size = new System.Drawing.Size(1288, 798);
            this.grdWorkerInOut.TabIndex = 4;
            this.grdWorkerInOut.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvWorkerInOut});
            // 
            // grvWorkerInOut
            // 
            this.grvWorkerInOut.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grvWorkerInOut.Appearance.FooterPanel.Options.UseFont = true;
            this.grvWorkerInOut.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvWorkerInOut.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grcWorkerID,
            this.grcWorkerName,
            this.grcCompany,
            this.grcTraining,
            this.grcTrainDate,
            this.grcTrainingAdd,
            this.grcTimeIn,
            this.grcTimeOut,
            this.grcRemark,
            this.grcGate,
            this.grcInOutID});
            this.grvWorkerInOut.GridControl = this.grdWorkerInOut;
            this.grvWorkerInOut.Name = "grvWorkerInOut";
            this.grvWorkerInOut.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grvWorkerInOut.OptionsSelection.MultiSelect = true;
            this.grvWorkerInOut.OptionsView.ShowFooter = true;
            this.grvWorkerInOut.OptionsView.ShowGroupPanel = false;
            this.grvWorkerInOut.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvWorkerInOut.PaintStyleName = "Skin";
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
            this.grcWorkerName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcWorkerName.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcWorkerName.Caption = "Worker Name";
            this.grcWorkerName.FieldName = "WorkerName";
            this.grcWorkerName.MaxWidth = 200;
            this.grcWorkerName.MinWidth = 200;
            this.grcWorkerName.Name = "grcWorkerName";
            this.grcWorkerName.OptionsColumn.ReadOnly = true;
            this.grcWorkerName.Visible = true;
            this.grcWorkerName.VisibleIndex = 1;
            this.grcWorkerName.Width = 200;
            // 
            // grcCompany
            // 
            this.grcCompany.AppearanceCell.Options.UseTextOptions = true;
            this.grcCompany.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcCompany.AppearanceHeader.Options.UseTextOptions = true;
            this.grcCompany.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcCompany.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcCompany.Caption = "COMPANY";
            this.grcCompany.FieldName = "CompanyName";
            this.grcCompany.MaxWidth = 200;
            this.grcCompany.MinWidth = 200;
            this.grcCompany.Name = "grcCompany";
            this.grcCompany.OptionsColumn.ReadOnly = true;
            this.grcCompany.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "CompanyName", "Tong so cong nhan vao kho")});
            this.grcCompany.Visible = true;
            this.grcCompany.VisibleIndex = 2;
            this.grcCompany.Width = 200;
            // 
            // grcTraining
            // 
            this.grcTraining.AppearanceCell.Options.UseTextOptions = true;
            this.grcTraining.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcTraining.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcTraining.AppearanceHeader.Options.UseTextOptions = true;
            this.grcTraining.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcTraining.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcTraining.Caption = "QHSE";
            this.grcTraining.ColumnEdit = this.rpi_chk_Training;
            this.grcTraining.FieldName = "LaborSafetyTraining";
            this.grcTraining.MaxWidth = 50;
            this.grcTraining.MinWidth = 50;
            this.grcTraining.Name = "grcTraining";
            this.grcTraining.OptionsColumn.ReadOnly = true;
            this.grcTraining.Visible = true;
            this.grcTraining.VisibleIndex = 3;
            this.grcTraining.Width = 50;
            // 
            // rpi_chk_Training
            // 
            this.rpi_chk_Training.AutoHeight = false;
            this.rpi_chk_Training.Name = "rpi_chk_Training";
            // 
            // grcTrainDate
            // 
            this.grcTrainDate.AppearanceCell.Options.UseTextOptions = true;
            this.grcTrainDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcTrainDate.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcTrainDate.AppearanceHeader.Options.UseTextOptions = true;
            this.grcTrainDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcTrainDate.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcTrainDate.Caption = "TRAIN DATE";
            this.grcTrainDate.FieldName = "LaborSafetyTrainDate";
            this.grcTrainDate.MaxWidth = 100;
            this.grcTrainDate.MinWidth = 100;
            this.grcTrainDate.Name = "grcTrainDate";
            this.grcTrainDate.OptionsColumn.ReadOnly = true;
            this.grcTrainDate.Visible = true;
            this.grcTrainDate.VisibleIndex = 4;
            this.grcTrainDate.Width = 100;
            // 
            // grcTrainingAdd
            // 
            this.grcTrainingAdd.AppearanceCell.Options.UseTextOptions = true;
            this.grcTrainingAdd.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcTrainingAdd.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcTrainingAdd.AppearanceHeader.Options.UseTextOptions = true;
            this.grcTrainingAdd.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcTrainingAdd.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcTrainingAdd.Caption = "NEW";
            this.grcTrainingAdd.ColumnEdit = this.rpi_btn_TrainingAdd;
            this.grcTrainingAdd.MaxWidth = 45;
            this.grcTrainingAdd.MinWidth = 45;
            this.grcTrainingAdd.Name = "grcTrainingAdd";
            this.grcTrainingAdd.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.grcTrainingAdd.Visible = true;
            this.grcTrainingAdd.VisibleIndex = 5;
            this.grcTrainingAdd.Width = 45;
            // 
            // rpi_btn_TrainingAdd
            // 
            this.rpi_btn_TrainingAdd.AutoHeight = false;
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            this.rpi_btn_TrainingAdd.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.rpi_btn_TrainingAdd.Name = "rpi_btn_TrainingAdd";
            this.rpi_btn_TrainingAdd.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // grcTimeIn
            // 
            this.grcTimeIn.AppearanceCell.Options.UseTextOptions = true;
            this.grcTimeIn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcTimeIn.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcTimeIn.AppearanceHeader.Options.UseTextOptions = true;
            this.grcTimeIn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcTimeIn.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcTimeIn.Caption = "TIME IN";
            this.grcTimeIn.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.grcTimeIn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.grcTimeIn.FieldName = "TimeIn1";
            this.grcTimeIn.MaxWidth = 100;
            this.grcTimeIn.MinWidth = 100;
            this.grcTimeIn.Name = "grcTimeIn";
            this.grcTimeIn.OptionsColumn.ReadOnly = true;
            this.grcTimeIn.Visible = true;
            this.grcTimeIn.VisibleIndex = 6;
            this.grcTimeIn.Width = 100;
            // 
            // grcTimeOut
            // 
            this.grcTimeOut.AppearanceCell.Options.UseTextOptions = true;
            this.grcTimeOut.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcTimeOut.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcTimeOut.AppearanceHeader.Options.UseTextOptions = true;
            this.grcTimeOut.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcTimeOut.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcTimeOut.Caption = "TIME OUT";
            this.grcTimeOut.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.grcTimeOut.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.grcTimeOut.FieldName = "TimeOut1";
            this.grcTimeOut.MaxWidth = 100;
            this.grcTimeOut.MinWidth = 100;
            this.grcTimeOut.Name = "grcTimeOut";
            this.grcTimeOut.OptionsColumn.ReadOnly = true;
            this.grcTimeOut.Visible = true;
            this.grcTimeOut.VisibleIndex = 7;
            this.grcTimeOut.Width = 100;
            // 
            // grcRemark
            // 
            this.grcRemark.AppearanceCell.Options.UseTextOptions = true;
            this.grcRemark.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcRemark.AppearanceHeader.Options.UseTextOptions = true;
            this.grcRemark.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcRemark.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcRemark.Caption = "REMARK";
            this.grcRemark.ColumnEdit = this.rpi_txt_Remark;
            this.grcRemark.FieldName = "Remark";
            this.grcRemark.MaxWidth = 1000;
            this.grcRemark.MinWidth = 18;
            this.grcRemark.Name = "grcRemark";
            this.grcRemark.OptionsColumn.ReadOnly = true;
            this.grcRemark.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "Remark", "So cong nhan con trong kho")});
            this.grcRemark.Visible = true;
            this.grcRemark.VisibleIndex = 8;
            this.grcRemark.Width = 18;
            // 
            // rpi_txt_Remark
            // 
            this.rpi_txt_Remark.AutoHeight = false;
            this.rpi_txt_Remark.Name = "rpi_txt_Remark";
            // 
            // grcGate
            // 
            this.grcGate.AppearanceCell.Options.UseTextOptions = true;
            this.grcGate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcGate.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcGate.AppearanceHeader.Options.UseTextOptions = true;
            this.grcGate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcGate.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcGate.Caption = "GATE";
            this.grcGate.FieldName = "Gate";
            this.grcGate.MaxWidth = 50;
            this.grcGate.MinWidth = 50;
            this.grcGate.Name = "grcGate";
            this.grcGate.OptionsColumn.ReadOnly = true;
            this.grcGate.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Gate", "{0}")});
            this.grcGate.Visible = true;
            this.grcGate.VisibleIndex = 9;
            this.grcGate.Width = 50;
            // 
            // grcInOutID
            // 
            this.grcInOutID.AppearanceCell.Options.UseTextOptions = true;
            this.grcInOutID.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcInOutID.AppearanceHeader.Options.UseTextOptions = true;
            this.grcInOutID.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcInOutID.Caption = "ID";
            this.grcInOutID.FieldName = "WorkerRegularInOutID";
            this.grcInOutID.Name = "grcInOutID";
            this.grcInOutID.OptionsColumn.ReadOnly = true;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1312, 822);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdWorkerInOut;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1292, 802);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // frm_S_AO_Dialog_GateCustomerLaborSafetyTrainingInOut
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 873);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_S_AO_Dialog_GateCustomerLaborSafetyTrainingInOut.IconOptions.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_S_AO_Dialog_GateCustomerLaborSafetyTrainingInOut";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "Customers/Workers In Out";
            this.Load += new System.EventHandler(this.frm_S_AO_Dialog_GateCustomerLaborSafetyTrainingInOut_Load);
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdWorkerInOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvWorkerInOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_chk_Training)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_btn_TrainingAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_txt_Remark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl grdWorkerInOut;
        private Common.Controls.WMSGridView grvWorkerInOut;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn grcWorkerID;
        private DevExpress.XtraGrid.Columns.GridColumn grcWorkerName;
        private DevExpress.XtraGrid.Columns.GridColumn grcCompany;
        private DevExpress.XtraGrid.Columns.GridColumn grcTraining;
        private DevExpress.XtraGrid.Columns.GridColumn grcTrainDate;
        private DevExpress.XtraGrid.Columns.GridColumn grcTrainingAdd;
        private DevExpress.XtraGrid.Columns.GridColumn grcTimeIn;
        private DevExpress.XtraGrid.Columns.GridColumn grcTimeOut;
        private DevExpress.XtraGrid.Columns.GridColumn grcRemark;
        private DevExpress.XtraGrid.Columns.GridColumn grcGate;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rpi_chk_Training;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rpi_btn_TrainingAdd;
        private DevExpress.XtraGrid.Columns.GridColumn grcInOutID;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rpi_txt_Remark;
    }
}