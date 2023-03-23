namespace UI.CRM
{
    partial class frm_CRM_ContractCommitments
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
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression1 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_CRM_ContractCommitments));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grcContractCommitment = new DevExpress.XtraGrid.GridControl();
            this.grvCCCommitments = new Common.Controls.WMSGridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rle_CustomerID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rde_FromDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rde_ToDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rce_isMain = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_lke_btnDel = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.ContractCommitmentID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcContractCommitment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCCCommitments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rle_CustomerID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rde_FromDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rde_FromDate.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rde_ToDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rde_ToDate.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rce_isMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_btnDel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grcContractCommitment);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1534, 644);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grcContractCommitment
            // 
            this.grcContractCommitment.Location = new System.Drawing.Point(6, 6);
            this.grcContractCommitment.MainView = this.grvCCCommitments;
            this.grcContractCommitment.Name = "grcContractCommitment";
            this.grcContractCommitment.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rce_isMain,
            this.rle_CustomerID,
            this.rde_FromDate,
            this.rde_ToDate,
            this.rpi_lke_btnDel});
            this.grcContractCommitment.Size = new System.Drawing.Size(1522, 632);
            this.grcContractCommitment.TabIndex = 4;
            this.grcContractCommitment.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvCCCommitments});
            // 
            // grvCCCommitments
            // 
            this.grvCCCommitments.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn14,
            this.ContractCommitmentID,
            this.gridColumn13,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn17});
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Name = "Format0";
            formatConditionRuleExpression1.Appearance.BackColor = System.Drawing.Color.DarkGray;
            formatConditionRuleExpression1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            formatConditionRuleExpression1.Appearance.Options.UseBackColor = true;
            formatConditionRuleExpression1.Appearance.Options.UseForeColor = true;
            formatConditionRuleExpression1.Expression = "[ToDate] < Today()";
            gridFormatRule1.Rule = formatConditionRuleExpression1;
            this.grvCCCommitments.FormatRules.Add(gridFormatRule1);
            this.grvCCCommitments.GridControl = this.grcContractCommitment;
            this.grvCCCommitments.Name = "grvCCCommitments";
            this.grvCCCommitments.OptionsNavigation.AutoFocusNewRow = true;
            this.grvCCCommitments.OptionsNavigation.EnterMoveNextColumn = true;
            this.grvCCCommitments.OptionsView.ShowGroupPanel = false;
            this.grvCCCommitments.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvCCCommitments.PaintStyleName = "Skin";
            this.grvCCCommitments.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvCCCommitments_CellValueChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Cust ID";
            this.gridColumn1.ColumnEdit = this.rle_CustomerID;
            this.gridColumn1.FieldName = "CustomerID";
            this.gridColumn1.MinWidth = 25;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 116;
            // 
            // rle_CustomerID
            // 
            this.rle_CustomerID.AutoHeight = false;
            this.rle_CustomerID.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.rle_CustomerID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rle_CustomerID.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerID", "CustomerID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerNumber", "Number"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerName", "Name")});
            this.rle_CustomerID.DropDownRows = 20;
            this.rle_CustomerID.ImmediatePopup = true;
            this.rle_CustomerID.Name = "rle_CustomerID";
            this.rle_CustomerID.NullText = "";
            this.rle_CustomerID.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(this.rle_CustomerID_CloseUp);
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Customer NAme";
            this.gridColumn2.FieldName = "CustomerName";
            this.gridColumn2.MinWidth = 25;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 331;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "From";
            this.gridColumn3.ColumnEdit = this.rde_FromDate;
            this.gridColumn3.FieldName = "FromDate";
            this.gridColumn3.MinWidth = 25;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 97;
            // 
            // rde_FromDate
            // 
            this.rde_FromDate.AutoHeight = false;
            this.rde_FromDate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rde_FromDate.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rde_FromDate.Name = "rde_FromDate";
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "To";
            this.gridColumn4.ColumnEdit = this.rde_ToDate;
            this.gridColumn4.FieldName = "ToDate";
            this.gridColumn4.MinWidth = 25;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            this.gridColumn4.Width = 97;
            // 
            // rde_ToDate
            // 
            this.rde_ToDate.AutoHeight = false;
            this.rde_ToDate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rde_ToDate.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rde_ToDate.Name = "rde_ToDate";
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Room";
            this.gridColumn5.FieldName = "RoomID";
            this.gridColumn5.MinWidth = 25;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            this.gridColumn5.Width = 55;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Locations";
            this.gridColumn6.FieldName = "LocationType";
            this.gridColumn6.MinWidth = 25;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 7;
            this.gridColumn6.Width = 106;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Main";
            this.gridColumn7.ColumnEdit = this.rce_isMain;
            this.gridColumn7.FieldName = "isMain";
            this.gridColumn7.MaxWidth = 60;
            this.gridColumn7.MinWidth = 60;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 8;
            this.gridColumn7.Width = 60;
            // 
            // rce_isMain
            // 
            this.rce_isMain.AutoHeight = false;
            this.rce_isMain.Name = "rce_isMain";
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Remark";
            this.gridColumn8.FieldName = "CDCRemark";
            this.gridColumn8.MinWidth = 25;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 9;
            this.gridColumn8.Width = 269;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "CreatedBy";
            this.gridColumn9.FieldName = "CreatedBy";
            this.gridColumn9.MinWidth = 25;
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Width = 94;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "CreatedTime";
            this.gridColumn10.FieldName = "CreatedTime";
            this.gridColumn10.MinWidth = 25;
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Width = 94;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "UpdateBy";
            this.gridColumn11.FieldName = "UpdateBy";
            this.gridColumn11.MinWidth = 25;
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Width = 94;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "UpdateTime";
            this.gridColumn12.FieldName = "UpdateTime";
            this.gridColumn12.MinWidth = 25;
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Width = 94;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Del";
            this.gridColumn14.ColumnEdit = this.rpi_lke_btnDel;
            this.gridColumn14.MaxWidth = 40;
            this.gridColumn14.MinWidth = 40;
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 12;
            this.gridColumn14.Width = 40;
            // 
            // rpi_lke_btnDel
            // 
            this.rpi_lke_btnDel.AutoHeight = false;
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            this.rpi_lke_btnDel.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.rpi_lke_btnDel.Name = "rpi_lke_btnDel";
            this.rpi_lke_btnDel.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.rpi_lke_btnDel.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.rpi_lke_btnDel_ButtonClick);
            // 
            // ContractCommitmentID
            // 
            this.ContractCommitmentID.Caption = "gridColumn15";
            this.ContractCommitmentID.FieldName = "ContractCommitmentID";
            this.ContractCommitmentID.MinWidth = 25;
            this.ContractCommitmentID.Name = "ContractCommitmentID";
            this.ContractCommitmentID.Width = 94;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "QTY";
            this.gridColumn13.FieldName = "NumberOfLocations";
            this.gridColumn13.MinWidth = 25;
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "NumberOfLocations", "{0:0.##}")});
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 6;
            this.gridColumn13.Width = 69;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Store";
            this.gridColumn15.FieldName = "StoreDescription";
            this.gridColumn15.MinWidth = 25;
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.ReadOnly = true;
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 0;
            this.gridColumn15.Width = 117;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Billed";
            this.gridColumn16.DisplayFormat.FormatString = "n0";
            this.gridColumn16.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn16.FieldName = "PalletBilled";
            this.gridColumn16.MinWidth = 25;
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsColumn.ReadOnly = true;
            this.gridColumn16.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PalletBilled", "{0:n0}")});
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 10;
            this.gridColumn16.Width = 78;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "Plts";
            this.gridColumn17.DisplayFormat.FormatString = "n0";
            this.gridColumn17.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn17.FieldName = "Pallets";
            this.gridColumn17.MinWidth = 25;
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.OptionsColumn.ReadOnly = true;
            this.gridColumn17.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Pallets", "{0:n0}")});
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 11;
            this.gridColumn17.Width = 57;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.Root.Name = "Root";
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.Root.Size = new System.Drawing.Size(1534, 644);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grcContractCommitment;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1526, 636);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // frm_CRM_ContractCommitments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1534, 644);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_CRM_ContractCommitments";
            this.Text = "Contract Commitments";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcContractCommitment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCCCommitments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rle_CustomerID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rde_FromDate.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rde_FromDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rde_ToDate.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rde_ToDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rce_isMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_btnDel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraGrid.GridControl grcContractCommitment;
        private Common.Controls.WMSGridView grvCCCommitments;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rle_CustomerID;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rce_isMain;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit rde_FromDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit rde_ToDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rpi_lke_btnDel;
        private DevExpress.XtraGrid.Columns.GridColumn ContractCommitmentID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
    }
}