namespace UI.CRM
{
    partial class urc_CRM_12MonthServices
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
            this.grcContractValue = new DevExpress.XtraGrid.GridControl();
            this.grvContractValue = new Common.Controls.WMSGridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnServiceNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnServiceName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnTotalLast12M = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnMonthlyAverage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_hpl_OtherServiceID = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcContractValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvContractValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_hpl_OtherServiceID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grcContractValue);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(2822, 52, 812, 500);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1011, 763);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grcContractValue
            // 
            this.grcContractValue.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.grcContractValue.Location = new System.Drawing.Point(12, 12);
            this.grcContractValue.MainView = this.grvContractValue;
            this.grcContractValue.Margin = new System.Windows.Forms.Padding(4);
            this.grcContractValue.Name = "grcContractValue";
            this.grcContractValue.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpi_hpl_OtherServiceID});
            this.grcContractValue.Size = new System.Drawing.Size(987, 739);
            this.grcContractValue.TabIndex = 13;
            this.grcContractValue.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvContractValue});
            // 
            // grvContractValue
            // 
            this.grvContractValue.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grvContractValue.Appearance.FooterPanel.Options.UseFont = true;
            this.grvContractValue.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvContractValue.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn4,
            this.gridColumnServiceNumber,
            this.gridColumnServiceName,
            this.gridColumnTotalLast12M,
            this.gridColumnMonthlyAverage,
            this.gridColumn2,
            this.gridColumn3});
            this.grvContractValue.GridControl = this.grcContractValue;
            this.grvContractValue.GroupCount = 1;
            this.grvContractValue.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Total12MServiceQty", this.gridColumnTotalLast12M, "{0:n0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "MonthlyAvgQty", this.gridColumnMonthlyAverage, "{0:n0}")});
            this.grvContractValue.Name = "grvContractValue";
            this.grvContractValue.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvContractValue.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseUp;
            this.grvContractValue.OptionsBehavior.ReadOnly = true;
            this.grvContractValue.OptionsView.ShowChildrenInGroupPanel = true;
            this.grvContractValue.OptionsView.ShowFooter = true;
            this.grvContractValue.OptionsView.ShowGroupedColumns = true;
            this.grvContractValue.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvContractValue.PaintStyleName = "Skin";
            this.grvContractValue.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumnServiceNumber, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "ServiceID";
            this.gridColumn1.FieldName = "ServiceID";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Account";
            this.gridColumn4.FieldName = "CustomerAccount";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            // 
            // gridColumnServiceNumber
            // 
            this.gridColumnServiceNumber.Caption = "Service";
            this.gridColumnServiceNumber.FieldName = "ServiceNumber";
            this.gridColumnServiceNumber.Name = "gridColumnServiceNumber";
            this.gridColumnServiceNumber.Visible = true;
            this.gridColumnServiceNumber.VisibleIndex = 0;
            this.gridColumnServiceNumber.Width = 91;
            // 
            // gridColumnServiceName
            // 
            this.gridColumnServiceName.Caption = "Service Name";
            this.gridColumnServiceName.FieldName = "ServiceName";
            this.gridColumnServiceName.Name = "gridColumnServiceName";
            this.gridColumnServiceName.Visible = true;
            this.gridColumnServiceName.VisibleIndex = 2;
            this.gridColumnServiceName.Width = 364;
            // 
            // gridColumnTotalLast12M
            // 
            this.gridColumnTotalLast12M.Caption = "Qty 12M";
            this.gridColumnTotalLast12M.DisplayFormat.FormatString = "n0";
            this.gridColumnTotalLast12M.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnTotalLast12M.FieldName = "Total12MServiceQty";
            this.gridColumnTotalLast12M.Name = "gridColumnTotalLast12M";
            this.gridColumnTotalLast12M.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalServiceQty", "{0:n0}")});
            this.gridColumnTotalLast12M.Visible = true;
            this.gridColumnTotalLast12M.VisibleIndex = 3;
            this.gridColumnTotalLast12M.Width = 91;
            // 
            // gridColumnMonthlyAverage
            // 
            this.gridColumnMonthlyAverage.Caption = "AVG MONTH";
            this.gridColumnMonthlyAverage.DisplayFormat.FormatString = "n0";
            this.gridColumnMonthlyAverage.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnMonthlyAverage.FieldName = "MonthlyAvgQty";
            this.gridColumnMonthlyAverage.Name = "gridColumnMonthlyAverage";
            this.gridColumnMonthlyAverage.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "MonthlyAvgQty", "{0:n0}")});
            this.gridColumnMonthlyAverage.Visible = true;
            this.gridColumnMonthlyAverage.VisibleIndex = 4;
            this.gridColumnMonthlyAverage.Width = 111;
            // 
            // rpi_hpl_OtherServiceID
            // 
            this.rpi_hpl_OtherServiceID.AutoHeight = false;
            this.rpi_hpl_OtherServiceID.Name = "rpi_hpl_OtherServiceID";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1011, 763);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grcContractValue;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(991, 743);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Rate";
            this.gridColumn2.FieldName = "ServicePrice";
            this.gridColumn2.MinWidth = 25;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 5;
            this.gridColumn2.Width = 94;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Amount";
            this.gridColumn3.FieldName = "Amount";
            this.gridColumn3.MinWidth = 25;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", "{0:n0}")});
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 6;
            this.gridColumn3.Width = 94;
            // 
            // urc_CRM_12MonthServices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.layoutControl1);
            this.Name = "urc_CRM_12MonthServices";
            this.Size = new System.Drawing.Size(1011, 763);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcContractValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvContractValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_hpl_OtherServiceID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl grcContractValue;
        private Common.Controls.WMSGridView grvContractValue;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnServiceNumber;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnServiceName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnTotalLast12M;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpi_hpl_OtherServiceID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnMonthlyAverage;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
    }
}
