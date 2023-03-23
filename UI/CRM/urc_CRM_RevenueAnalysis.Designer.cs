namespace UI.CRM
{
    partial class urc_CRM_RevenueAnalysis
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
            this.pvgRevenue12Months = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.pivotGridField4 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField2 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField3 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField5 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField6 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField7 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField8 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.checkShowWMSData = new DevExpress.XtraEditors.CheckEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pvgRevenue12Months)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkShowWMSData.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.checkShowWMSData);
            this.layoutControl1.Controls.Add(this.pvgRevenue12Months);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1108, 414, 812, 500);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1368, 728);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // pvgRevenue12Months
            // 
            this.pvgRevenue12Months.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.pivotGridField4,
            this.pivotGridField1,
            this.pivotGridField2,
            this.pivotGridField3,
            this.pivotGridField5,
            this.pivotGridField6,
            this.pivotGridField7,
            this.pivotGridField8});
            this.pvgRevenue12Months.Location = new System.Drawing.Point(4, 29);
            this.pvgRevenue12Months.Name = "pvgRevenue12Months";
            this.pvgRevenue12Months.Size = new System.Drawing.Size(1360, 695);
            this.pvgRevenue12Months.TabIndex = 4;
            this.pvgRevenue12Months.CellClick += new DevExpress.XtraPivotGrid.PivotCellEventHandler(this.pvgRevenue12Months_CellClick);
            // 
            // pivotGridField4
            // 
            this.pivotGridField4.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.pivotGridField4.AreaIndex = 0;
            this.pivotGridField4.FieldName = "ServiceCategory";
            this.pivotGridField4.Name = "pivotGridField4";
            this.pivotGridField4.Options.AllowRunTimeSummaryChange = true;
            // 
            // pivotGridField1
            // 
            this.pivotGridField1.AreaIndex = 3;
            this.pivotGridField1.Caption = "Code";
            this.pivotGridField1.FieldName = "ServiceNumber";
            this.pivotGridField1.Name = "pivotGridField1";
            this.pivotGridField1.Options.AllowRunTimeSummaryChange = true;
            // 
            // pivotGridField2
            // 
            this.pivotGridField2.AreaIndex = 4;
            this.pivotGridField2.Caption = "Description";
            this.pivotGridField2.FieldName = "ServiceName";
            this.pivotGridField2.Name = "pivotGridField2";
            this.pivotGridField2.Options.AllowRunTimeSummaryChange = true;
            this.pivotGridField2.Width = 300;
            // 
            // pivotGridField3
            // 
            this.pivotGridField3.AreaIndex = 1;
            this.pivotGridField3.Caption = "Quantity";
            this.pivotGridField3.CellFormat.FormatString = "n0";
            this.pivotGridField3.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivotGridField3.FieldName = "ServiceQuantity";
            this.pivotGridField3.Name = "pivotGridField3";
            this.pivotGridField3.Options.AllowRunTimeSummaryChange = true;
            // 
            // pivotGridField5
            // 
            this.pivotGridField5.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField5.AreaIndex = 0;
            this.pivotGridField5.FieldName = "InvoiceFromDate";
            this.pivotGridField5.Name = "pivotGridField5";
            this.pivotGridField5.Options.AllowRunTimeSummaryChange = true;
            // 
            // pivotGridField6
            // 
            this.pivotGridField6.AreaIndex = 0;
            this.pivotGridField6.FieldName = "InvoiceToDate";
            this.pivotGridField6.Name = "pivotGridField6";
            this.pivotGridField6.Options.AllowRunTimeSummaryChange = true;
            // 
            // pivotGridField7
            // 
            this.pivotGridField7.AreaIndex = 2;
            this.pivotGridField7.Caption = "Rate";
            this.pivotGridField7.CellFormat.FormatString = "n0";
            this.pivotGridField7.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivotGridField7.FieldName = "CuryPrice";
            this.pivotGridField7.Name = "pivotGridField7";
            this.pivotGridField7.Options.AllowRunTimeSummaryChange = true;
            // 
            // pivotGridField8
            // 
            this.pivotGridField8.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.pivotGridField8.AreaIndex = 0;
            this.pivotGridField8.Caption = "Amount";
            this.pivotGridField8.CellFormat.FormatString = "n0";
            this.pivotGridField8.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivotGridField8.FieldName = "ExtendedAmount";
            this.pivotGridField8.Name = "pivotGridField8";
            this.pivotGridField8.Options.AllowRunTimeSummaryChange = true;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem1});
            this.Root.Name = "Root";
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.Root.Size = new System.Drawing.Size(1368, 728);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.pvgRevenue12Months;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 25);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1364, 699);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // checkShowWMSData
            // 
            this.checkShowWMSData.Location = new System.Drawing.Point(4, 4);
            this.checkShowWMSData.Name = "checkShowWMSData";
            this.checkShowWMSData.Properties.Caption = "Show WMS Billing Data";
            this.checkShowWMSData.Size = new System.Drawing.Size(165, 21);
            this.checkShowWMSData.StyleController = this.layoutControl1;
            this.checkShowWMSData.TabIndex = 5;
            this.checkShowWMSData.CheckedChanged += new System.EventHandler(this.checkShowWMSData_CheckedChanged);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.checkShowWMSData;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(169, 25);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(169, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(1195, 25);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // urc_CRM_RevenueAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "urc_CRM_RevenueAnalysis";
            this.Size = new System.Drawing.Size(1368, 728);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pvgRevenue12Months)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkShowWMSData.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraPivotGrid.PivotGridControl pvgRevenue12Months;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField1;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField2;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField3;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField4;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField5;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField6;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField7;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField8;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.CheckEdit checkShowWMSData;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}
