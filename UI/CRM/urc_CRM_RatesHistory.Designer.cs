namespace UI.CRM
{
    partial class urc_CRM_RatesHistory
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
            this.pvgRatesHistory = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.pivotGridField1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField2 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField3 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField12 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField11 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField9 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField4 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField5 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField6 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField7 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField8 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField10 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pvgRatesHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.pvgRatesHistory);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1347, 764);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // pvgRatesHistory
            // 
            this.pvgRatesHistory.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.pivotGridField1,
            this.pivotGridField2,
            this.pivotGridField3,
            this.pivotGridField12,
            this.pivotGridField11,
            this.pivotGridField9,
            this.pivotGridField4,
            this.pivotGridField5,
            this.pivotGridField6,
            this.pivotGridField7,
            this.pivotGridField8,
            this.pivotGridField10});
            this.pvgRatesHistory.Location = new System.Drawing.Point(12, 12);
            this.pvgRatesHistory.Name = "pvgRatesHistory";
            this.pvgRatesHistory.OptionsBehavior.CopyToClipboardWithFieldValues = true;
            this.pvgRatesHistory.OptionsView.ShowRowGrandTotals = false;
            this.pvgRatesHistory.Size = new System.Drawing.Size(1323, 740);
            this.pvgRatesHistory.TabIndex = 4;
            this.pvgRatesHistory.CellClick += new DevExpress.XtraPivotGrid.PivotCellEventHandler(this.pvgRatesHistory_CellClick);
            // 
            // pivotGridField1
            // 
            this.pivotGridField1.AreaIndex = 2;
            this.pivotGridField1.Caption = "Contract";
            this.pivotGridField1.FieldName = "ContractNumber";
            this.pivotGridField1.Name = "pivotGridField1";
            this.pivotGridField1.Options.AllowRunTimeSummaryChange = true;
            this.pivotGridField1.Options.ShowCustomTotals = false;
            this.pivotGridField1.Options.ShowGrandTotal = false;
            this.pivotGridField1.Options.ShowTotals = false;
            // 
            // pivotGridField2
            // 
            this.pivotGridField2.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.pivotGridField2.AreaIndex = 0;
            this.pivotGridField2.Caption = "Start";
            this.pivotGridField2.FieldName = "StartDate";
            this.pivotGridField2.Name = "pivotGridField2";
            this.pivotGridField2.Options.AllowRunTimeSummaryChange = true;
            this.pivotGridField2.Options.ShowCustomTotals = false;
            this.pivotGridField2.Options.ShowGrandTotal = false;
            this.pivotGridField2.Options.ShowTotals = false;
            this.pivotGridField2.TotalsVisibility = DevExpress.XtraPivotGrid.PivotTotalsVisibility.None;
            // 
            // pivotGridField3
            // 
            this.pivotGridField3.AreaIndex = 3;
            this.pivotGridField3.Caption = "End";
            this.pivotGridField3.FieldName = "EndDate";
            this.pivotGridField3.Name = "pivotGridField3";
            this.pivotGridField3.Options.AllowRunTimeSummaryChange = true;
            // 
            // pivotGridField12
            // 
            this.pivotGridField12.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField12.AreaIndex = 0;
            this.pivotGridField12.Caption = "Acc.";
            this.pivotGridField12.FieldName = "CustomerNumber";
            this.pivotGridField12.Name = "pivotGridField12";
            this.pivotGridField12.Options.AllowRunTimeSummaryChange = true;
            this.pivotGridField12.Width = 80;
            // 
            // pivotGridField11
            // 
            this.pivotGridField11.AreaIndex = 4;
            this.pivotGridField11.Caption = "Account Name";
            this.pivotGridField11.FieldName = "CustomerName";
            this.pivotGridField11.Name = "pivotGridField11";
            this.pivotGridField11.Options.AllowRunTimeSummaryChange = true;
            this.pivotGridField11.Options.ShowCustomTotals = false;
            this.pivotGridField11.Options.ShowGrandTotal = false;
            this.pivotGridField11.Options.ShowTotals = false;
            this.pivotGridField11.Width = 300;
            // 
            // pivotGridField9
            // 
            this.pivotGridField9.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField9.AreaIndex = 1;
            this.pivotGridField9.Caption = "Category";
            this.pivotGridField9.FieldName = "ServiceType";
            this.pivotGridField9.Name = "pivotGridField9";
            this.pivotGridField9.Options.AllowRunTimeSummaryChange = true;
            // 
            // pivotGridField4
            // 
            this.pivotGridField4.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField4.AreaIndex = 2;
            this.pivotGridField4.Caption = "Service";
            this.pivotGridField4.FieldName = "ServiceNumber";
            this.pivotGridField4.Name = "pivotGridField4";
            this.pivotGridField4.Options.AllowRunTimeSummaryChange = true;
            this.pivotGridField4.Options.ShowTotals = false;
            // 
            // pivotGridField5
            // 
            this.pivotGridField5.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField5.AreaIndex = 3;
            this.pivotGridField5.Caption = "ServiceName";
            this.pivotGridField5.FieldName = "ServiceName";
            this.pivotGridField5.Name = "pivotGridField5";
            this.pivotGridField5.Options.AllowRunTimeSummaryChange = true;
            this.pivotGridField5.Width = 250;
            // 
            // pivotGridField6
            // 
            this.pivotGridField6.AreaIndex = 0;
            this.pivotGridField6.Caption = "Service Remark";
            this.pivotGridField6.FieldName = "ContractDetailRemark";
            this.pivotGridField6.Name = "pivotGridField6";
            this.pivotGridField6.Options.AllowRunTimeSummaryChange = true;
            // 
            // pivotGridField7
            // 
            this.pivotGridField7.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.pivotGridField7.AreaIndex = 0;
            this.pivotGridField7.Caption = "Price";
            this.pivotGridField7.CellFormat.FormatString = "n0";
            this.pivotGridField7.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivotGridField7.FieldName = "UnitRate";
            this.pivotGridField7.Name = "pivotGridField7";
            this.pivotGridField7.Options.AllowRunTimeSummaryChange = true;
            this.pivotGridField7.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Max;
            this.pivotGridField7.TotalCellFormat.FormatString = "n0";
            this.pivotGridField7.TotalCellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivotGridField7.TotalsVisibility = DevExpress.XtraPivotGrid.PivotTotalsVisibility.None;
            this.pivotGridField7.TotalValueFormat.FormatString = "n0";
            this.pivotGridField7.TotalValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivotGridField7.ValueFormat.FormatString = "n0";
            this.pivotGridField7.ValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivotGridField7.Width = 80;
            // 
            // pivotGridField8
            // 
            this.pivotGridField8.AreaIndex = 1;
            this.pivotGridField8.Caption = "UOM";
            this.pivotGridField8.FieldName = "UnitMeasurement";
            this.pivotGridField8.Name = "pivotGridField8";
            this.pivotGridField8.Options.AllowRunTimeSummaryChange = true;
            // 
            // pivotGridField10
            // 
            this.pivotGridField10.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.pivotGridField10.AreaIndex = 1;
            this.pivotGridField10.Caption = "Change";
            this.pivotGridField10.CellFormat.FormatString = "p0";
            this.pivotGridField10.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivotGridField10.FieldName = "RateChange";
            this.pivotGridField10.Name = "pivotGridField10";
            this.pivotGridField10.Options.AllowRunTimeSummaryChange = true;
            this.pivotGridField10.TotalsVisibility = DevExpress.XtraPivotGrid.PivotTotalsVisibility.None;
            this.pivotGridField10.ValueFormat.FormatString = "p0";
            this.pivotGridField10.ValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivotGridField10.Width = 55;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1347, 764);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.pvgRatesHistory;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1327, 744);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // urc_CRM_RatesHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "urc_CRM_RatesHistory";
            this.Size = new System.Drawing.Size(1347, 764);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pvgRatesHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraPivotGrid.PivotGridControl pvgRatesHistory;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField1;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField2;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField3;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField9;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField4;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField5;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField6;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField7;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField8;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField10;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField12;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField11;
    }
}
