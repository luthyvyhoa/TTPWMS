namespace UI.ReportForm
{
    partial class frm_BR_Dialog_BillingCheckBreakdownResult
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_BR_Dialog_BillingCheckBreakdownResult));
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grdBillingResult = new DevExpress.XtraGrid.GridControl();
            this.grvBillingResult = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.grcCustomerNumber = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.grcCustomerName = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.grcReportDate = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.grcBeginC = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.grcBeginW = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.grcCloseC = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.grcCloseW = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand5 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.grcDifferenceC = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.grcDifferenceW = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand6 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.grcViewDetail = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.rpi_btn_ViewDetail = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridBand7 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.grcCustomerID = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBillingResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBillingResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_btn_ViewDetail)).BeginInit();
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
            this.rbcbase.Size = new System.Drawing.Size(981, 51);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grdBillingResult);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 51);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(981, 373);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grdBillingResult
            // 
            this.grdBillingResult.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.grdBillingResult.Location = new System.Drawing.Point(12, 12);
            this.grdBillingResult.MainView = this.grvBillingResult;
            this.grdBillingResult.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdBillingResult.MenuManager = this.rbcbase;
            this.grdBillingResult.Name = "grdBillingResult";
            this.grdBillingResult.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpi_btn_ViewDetail});
            this.grdBillingResult.Size = new System.Drawing.Size(957, 349);
            this.grdBillingResult.TabIndex = 4;
            this.grdBillingResult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBillingResult});
            this.grdBillingResult.Click += new System.EventHandler(this.grdBillingResult_Click);
            // 
            // grvBillingResult
            // 
            this.grvBillingResult.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grvBillingResult.Appearance.FooterPanel.Options.UseFont = true;
            this.grvBillingResult.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBillingResult.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1,
            this.gridBand2,
            this.gridBand3,
            this.gridBand4,
            this.gridBand5,
            this.gridBand6,
            this.gridBand7});
            this.grvBillingResult.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.grcCustomerNumber,
            this.grcCustomerName,
            this.grcReportDate,
            this.grcBeginC,
            this.grcBeginW,
            this.grcCloseC,
            this.grcCloseW,
            this.grcDifferenceC,
            this.grcDifferenceW,
            this.grcViewDetail,
            this.grcCustomerID});
            this.grvBillingResult.GridControl = this.grdBillingResult;
            this.grvBillingResult.Name = "grvBillingResult";
            this.grvBillingResult.OptionsView.ShowGroupPanel = false;
            this.grvBillingResult.PaintStyleName = "Skin";
            // 
            // gridBand1
            // 
            this.gridBand1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand1.Caption = "CUSTOMER";
            this.gridBand1.Columns.Add(this.grcCustomerNumber);
            this.gridBand1.Columns.Add(this.grcCustomerName);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 0;
            this.gridBand1.Width = 321;
            // 
            // grcCustomerNumber
            // 
            this.grcCustomerNumber.Caption = " ";
            this.grcCustomerNumber.FieldName = "CustomerNumber";
            this.grcCustomerNumber.Name = "grcCustomerNumber";
            this.grcCustomerNumber.OptionsColumn.ReadOnly = true;
            this.grcCustomerNumber.Visible = true;
            this.grcCustomerNumber.Width = 80;
            // 
            // grcCustomerName
            // 
            this.grcCustomerName.Caption = " ";
            this.grcCustomerName.FieldName = "CustomerName";
            this.grcCustomerName.Name = "grcCustomerName";
            this.grcCustomerName.OptionsColumn.ReadOnly = true;
            this.grcCustomerName.Visible = true;
            this.grcCustomerName.Width = 241;
            // 
            // gridBand2
            // 
            this.gridBand2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand2.Caption = "DATE";
            this.gridBand2.Columns.Add(this.grcReportDate);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.VisibleIndex = 1;
            this.gridBand2.Width = 96;
            // 
            // grcReportDate
            // 
            this.grcReportDate.AppearanceCell.Options.UseTextOptions = true;
            this.grcReportDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcReportDate.AppearanceHeader.Options.UseTextOptions = true;
            this.grcReportDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcReportDate.Caption = " ";
            this.grcReportDate.FieldName = "ReportDate";
            this.grcReportDate.Name = "grcReportDate";
            this.grcReportDate.OptionsColumn.ReadOnly = true;
            this.grcReportDate.Visible = true;
            this.grcReportDate.Width = 96;
            // 
            // gridBand3
            // 
            this.gridBand3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand3.Caption = "ENDING QUANTITY";
            this.gridBand3.Columns.Add(this.grcBeginC);
            this.gridBand3.Columns.Add(this.grcBeginW);
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.VisibleIndex = 2;
            this.gridBand3.Width = 198;
            // 
            // grcBeginC
            // 
            this.grcBeginC.AppearanceCell.Options.UseTextOptions = true;
            this.grcBeginC.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grcBeginC.AppearanceHeader.Options.UseTextOptions = true;
            this.grcBeginC.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcBeginC.Caption = "CARTONS";
            this.grcBeginC.DisplayFormat.FormatString = "n1";
            this.grcBeginC.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.grcBeginC.FieldName = "BeginC";
            this.grcBeginC.Name = "grcBeginC";
            this.grcBeginC.OptionsColumn.ReadOnly = true;
            this.grcBeginC.Visible = true;
            this.grcBeginC.Width = 96;
            // 
            // grcBeginW
            // 
            this.grcBeginW.AppearanceCell.Options.UseTextOptions = true;
            this.grcBeginW.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grcBeginW.AppearanceHeader.Options.UseTextOptions = true;
            this.grcBeginW.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcBeginW.Caption = "KGS";
            this.grcBeginW.DisplayFormat.FormatString = "n1";
            this.grcBeginW.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.grcBeginW.FieldName = "BeginW";
            this.grcBeginW.Name = "grcBeginW";
            this.grcBeginW.OptionsColumn.ReadOnly = true;
            this.grcBeginW.Visible = true;
            this.grcBeginW.Width = 102;
            // 
            // gridBand4
            // 
            this.gridBand4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand4.Caption = "BEGIN NEXT DAY QTY";
            this.gridBand4.Columns.Add(this.grcCloseC);
            this.gridBand4.Columns.Add(this.grcCloseW);
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.VisibleIndex = 3;
            this.gridBand4.Width = 198;
            // 
            // grcCloseC
            // 
            this.grcCloseC.AppearanceCell.Options.UseTextOptions = true;
            this.grcCloseC.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grcCloseC.AppearanceHeader.Options.UseTextOptions = true;
            this.grcCloseC.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcCloseC.Caption = "CARTONS";
            this.grcCloseC.DisplayFormat.FormatString = "n1";
            this.grcCloseC.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.grcCloseC.FieldName = "CloseC";
            this.grcCloseC.Name = "grcCloseC";
            this.grcCloseC.OptionsColumn.ReadOnly = true;
            this.grcCloseC.Visible = true;
            this.grcCloseC.Width = 96;
            // 
            // grcCloseW
            // 
            this.grcCloseW.AppearanceCell.Options.UseTextOptions = true;
            this.grcCloseW.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grcCloseW.AppearanceHeader.Options.UseTextOptions = true;
            this.grcCloseW.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcCloseW.Caption = "KGS";
            this.grcCloseW.DisplayFormat.FormatString = "{n1}";
            this.grcCloseW.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.grcCloseW.FieldName = "CloseW";
            this.grcCloseW.Name = "grcCloseW";
            this.grcCloseW.OptionsColumn.ReadOnly = true;
            this.grcCloseW.Visible = true;
            this.grcCloseW.Width = 102;
            // 
            // gridBand5
            // 
            this.gridBand5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand5.Caption = "DIFFERENCE";
            this.gridBand5.Columns.Add(this.grcDifferenceC);
            this.gridBand5.Columns.Add(this.grcDifferenceW);
            this.gridBand5.Name = "gridBand5";
            this.gridBand5.VisibleIndex = 4;
            this.gridBand5.Width = 198;
            // 
            // grcDifferenceC
            // 
            this.grcDifferenceC.AppearanceCell.Options.UseTextOptions = true;
            this.grcDifferenceC.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grcDifferenceC.AppearanceHeader.Options.UseTextOptions = true;
            this.grcDifferenceC.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcDifferenceC.Caption = "CARTONS";
            this.grcDifferenceC.DisplayFormat.FormatString = "n1";
            this.grcDifferenceC.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.grcDifferenceC.FieldName = "grcDifferenceC";
            this.grcDifferenceC.Name = "grcDifferenceC";
            this.grcDifferenceC.OptionsColumn.ReadOnly = true;
            this.grcDifferenceC.UnboundExpression = "[CloseC] - [BeginC]";
            this.grcDifferenceC.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.grcDifferenceC.Visible = true;
            this.grcDifferenceC.Width = 96;
            // 
            // grcDifferenceW
            // 
            this.grcDifferenceW.AppearanceCell.Options.UseTextOptions = true;
            this.grcDifferenceW.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grcDifferenceW.AppearanceHeader.Options.UseTextOptions = true;
            this.grcDifferenceW.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcDifferenceW.Caption = "KGS";
            this.grcDifferenceW.DisplayFormat.FormatString = "n1";
            this.grcDifferenceW.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.grcDifferenceW.FieldName = "grcDifferenceW";
            this.grcDifferenceW.Name = "grcDifferenceW";
            this.grcDifferenceW.OptionsColumn.ReadOnly = true;
            this.grcDifferenceW.UnboundExpression = "[CloseW] - [BeginW]";
            this.grcDifferenceW.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.grcDifferenceW.Visible = true;
            this.grcDifferenceW.Width = 102;
            // 
            // gridBand6
            // 
            this.gridBand6.Caption = "gridBand6";
            this.gridBand6.Columns.Add(this.grcViewDetail);
            this.gridBand6.Name = "gridBand6";
            this.gridBand6.OptionsBand.ShowCaption = false;
            this.gridBand6.VisibleIndex = 5;
            this.gridBand6.Width = 42;
            // 
            // grcViewDetail
            // 
            this.grcViewDetail.Caption = " ";
            this.grcViewDetail.ColumnEdit = this.rpi_btn_ViewDetail;
            this.grcViewDetail.Name = "grcViewDetail";
            this.grcViewDetail.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.grcViewDetail.Visible = true;
            this.grcViewDetail.Width = 42;
            // 
            // rpi_btn_ViewDetail
            // 
            this.rpi_btn_ViewDetail.AutoHeight = false;
            this.rpi_btn_ViewDetail.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "View", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.rpi_btn_ViewDetail.Name = "rpi_btn_ViewDetail";
            this.rpi_btn_ViewDetail.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // gridBand7
            // 
            this.gridBand7.Caption = "CustomerID";
            this.gridBand7.Columns.Add(this.grcCustomerID);
            this.gridBand7.Name = "gridBand7";
            this.gridBand7.Visible = false;
            this.gridBand7.VisibleIndex = -1;
            this.gridBand7.Width = 75;
            // 
            // grcCustomerID
            // 
            this.grcCustomerID.Caption = " ";
            this.grcCustomerID.FieldName = "CustomerID";
            this.grcCustomerID.Name = "grcCustomerID";
            this.grcCustomerID.OptionsColumn.ReadOnly = true;
            this.grcCustomerID.Visible = true;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(981, 373);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdBillingResult;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(961, 353);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // frm_BR_Dialog_BillingCheckBreakdownResult
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 424);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_BR_Dialog_BillingCheckBreakdownResult.IconOptions.Icon")));
            this.IsFixHeightScreen = false;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_BR_Dialog_BillingCheckBreakdownResult";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "Billing Check Breakdown";
            this.Load += new System.EventHandler(this.frm_BR_Dialog_BillingCheckBreakdownResult_Load);
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBillingResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBillingResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_btn_ViewDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl grdBillingResult;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView grvBillingResult;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn grcCustomerNumber;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn grcCustomerName;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn grcReportDate;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn grcBeginC;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn grcBeginW;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn grcCloseC;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn grcCloseW;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn grcDifferenceC;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn grcDifferenceW;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn grcViewDetail;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn grcCustomerID;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rpi_btn_ViewDetail;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand5;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand6;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand7;
    }
}