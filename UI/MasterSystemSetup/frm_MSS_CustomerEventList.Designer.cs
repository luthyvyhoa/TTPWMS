namespace UI.MasterSystemSetup
{
    partial class frm_MSS_CustomerEventList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_MSS_CustomerEventList));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grcCustomerEventList = new DevExpress.XtraGrid.GridControl();
            this.grvCustomerEventList = new Common.Controls.WMSGridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpe_EventID = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dToDate = new DevExpress.XtraEditors.DateEdit();
            this.dFromDate = new DevExpress.XtraEditors.DateEdit();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcCustomerEventList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCustomerEventList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpe_EventID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dToDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dFromDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grcCustomerEventList);
            this.layoutControl1.Controls.Add(this.dToDate);
            this.layoutControl1.Controls.Add(this.dFromDate);
            this.layoutControl1.Controls.Add(this.btnSearch);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(895, 329, 812, 345);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1835, 929);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grcCustomerEventList
            // 
            this.grcCustomerEventList.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grcCustomerEventList.Location = new System.Drawing.Point(13, 60);
            this.grcCustomerEventList.MainView = this.grvCustomerEventList;
            this.grcCustomerEventList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grcCustomerEventList.Name = "grcCustomerEventList";
            this.grcCustomerEventList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpe_EventID});
            this.grcCustomerEventList.Size = new System.Drawing.Size(1809, 854);
            this.grcCustomerEventList.TabIndex = 4;
            this.grcCustomerEventList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvCustomerEventList});
            // 
            // grvCustomerEventList
            // 
            this.grvCustomerEventList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn9,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn10});
            this.grvCustomerEventList.DetailHeight = 437;
            this.grvCustomerEventList.GridControl = this.grcCustomerEventList;
            this.grvCustomerEventList.Name = "grvCustomerEventList";
            this.grvCustomerEventList.OptionsView.AutoCalcPreviewLineCount = true;
            this.grvCustomerEventList.OptionsView.ShowPreview = true;
            this.grvCustomerEventList.OptionsView.ShowPreviewRowLines = DevExpress.Utils.DefaultBoolean.True;
            this.grvCustomerEventList.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvCustomerEventList.PaintStyleName = "Skin";
            this.grvCustomerEventList.PreviewFieldName = "EventDescription";
            this.grvCustomerEventList.PreviewIndent = 112;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "ID";
            this.gridColumn1.ColumnEdit = this.rpe_EventID;
            this.gridColumn1.FieldName = "CustomerEventNumber";
            this.gridColumn1.MinWidth = 28;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 78;
            // 
            // rpe_EventID
            // 
            this.rpe_EventID.AutoHeight = false;
            this.rpe_EventID.Name = "rpe_EventID";
            this.rpe_EventID.Click += new System.EventHandler(this.rpe_EventID_Click);
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Date";
            this.gridColumn9.FieldName = "EventDate";
            this.gridColumn9.MinWidth = 28;
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 1;
            this.gridColumn9.Width = 123;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "CustomerEventID";
            this.gridColumn2.FieldName = "CustomerEventID";
            this.gridColumn2.MinWidth = 28;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Width = 105;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Customer ID";
            this.gridColumn3.FieldName = "CustomerNumber";
            this.gridColumn3.MinWidth = 28;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 125;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Customer Name";
            this.gridColumn4.FieldName = "CustomerName";
            this.gridColumn4.MinWidth = 28;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 377;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Created";
            this.gridColumn5.FieldName = "CreatedBy";
            this.gridColumn5.MinWidth = 28;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            this.gridColumn5.Width = 69;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Created Time";
            this.gridColumn6.FieldName = "CreatedTime";
            this.gridColumn6.MinWidth = 28;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 6;
            this.gridColumn6.Width = 132;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Confirm";
            this.gridColumn7.FieldName = "ConfirmedBy";
            this.gridColumn7.MinWidth = 28;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 7;
            this.gridColumn7.Width = 64;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "C. Time";
            this.gridColumn8.FieldName = "ConfirmedTime";
            this.gridColumn8.MinWidth = 28;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 8;
            this.gridColumn8.Width = 141;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Event Category";
            this.gridColumn10.FieldName = "CategoryName";
            this.gridColumn10.MinWidth = 28;
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 4;
            this.gridColumn10.Width = 361;
            // 
            // dToDate
            // 
            this.dToDate.EditValue = null;
            this.dToDate.EnterMoveNextControl = true;
            this.dToDate.Location = new System.Drawing.Point(270, 15);
            this.dToDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dToDate.MaximumSize = new System.Drawing.Size(0, 37);
            this.dToDate.MinimumSize = new System.Drawing.Size(0, 37);
            this.dToDate.Name = "dToDate";
            this.dToDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dToDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dToDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dToDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dToDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dToDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dToDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dToDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dToDate.Size = new System.Drawing.Size(162, 37);
            this.dToDate.StyleController = this.layoutControl1;
            this.dToDate.TabIndex = 7;
            // 
            // dFromDate
            // 
            this.dFromDate.EditValue = null;
            this.dFromDate.EnterMoveNextControl = true;
            this.dFromDate.Location = new System.Drawing.Point(64, 15);
            this.dFromDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dFromDate.MaximumSize = new System.Drawing.Size(0, 37);
            this.dFromDate.MinimumSize = new System.Drawing.Size(0, 37);
            this.dFromDate.Name = "dFromDate";
            this.dFromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dFromDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dFromDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dFromDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dFromDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dFromDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dFromDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dFromDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dFromDate.Size = new System.Drawing.Size(149, 37);
            this.dFromDate.StyleController = this.layoutControl1;
            this.dFromDate.TabIndex = 8;
            // 
            // btnSearch
            // 
            this.btnSearch.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Question;
            this.btnSearch.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnSearch.Appearance.Options.UseBackColor = true;
            this.btnSearch.Appearance.Options.UseFont = true;
            this.btnSearch.Location = new System.Drawing.Point(438, 15);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearch.MaximumSize = new System.Drawing.Size(141, 31);
            this.btnSearch.MinimumSize = new System.Drawing.Size(141, 31);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(141, 31);
            this.btnSearch.StyleController = this.layoutControl1;
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem4,
            this.layoutControlItem2,
            this.layoutControlItem5,
            this.emptySpaceItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1835, 929);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grcCustomerEventList;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 45);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1815, 862);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.dFromDate;
            this.layoutControlItem4.CustomizationFormText = "From";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(206, 45);
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem4.Text = "From";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(37, 19);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.dToDate;
            this.layoutControlItem2.CustomizationFormText = "To";
            this.layoutControlItem2.Location = new System.Drawing.Point(206, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(219, 45);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem2.Text = "To";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(37, 19);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnSearch;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(425, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(147, 45);
            this.layoutControlItem5.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(572, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(1243, 45);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frm_MSS_CustomerEventList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1835, 929);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frm_MSS_CustomerEventList";
            this.Text = "frm_MSS_CustomerEventList";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcCustomerEventList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCustomerEventList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpe_EventID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dToDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dFromDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dFromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraGrid.GridControl grcCustomerEventList;
        private Common.Controls.WMSGridView grvCustomerEventList;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.DateEdit dToDate;
        private DevExpress.XtraEditors.DateEdit dFromDate;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpe_EventID;
    }
}