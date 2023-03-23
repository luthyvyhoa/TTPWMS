namespace UI.Supperviors
{
    partial class frm_S_CustomerForecastHistoryViewByCustomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_S_CustomerForecastHistoryViewByCustomer));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.pivotGridControl1 = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.pivotGridField6 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField2 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField3 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField4 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField5 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField7 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField8 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField9 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField10 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField11 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField12 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.pivotGridControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1380, 870);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // pivotGridControl1
            // 
            this.pivotGridControl1.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.pivotGridField6,
            this.pivotGridField1,
            this.pivotGridField2,
            this.pivotGridField3,
            this.pivotGridField4,
            this.pivotGridField5,
            this.pivotGridField7,
            this.pivotGridField8,
            this.pivotGridField9,
            this.pivotGridField10,
            this.pivotGridField11,
            this.pivotGridField12});
            this.pivotGridControl1.Location = new System.Drawing.Point(12, 13);
            this.pivotGridControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pivotGridControl1.Name = "pivotGridControl1";
            this.pivotGridControl1.OptionsDataField.RowHeaderWidth = 112;
            this.pivotGridControl1.OptionsView.RowTreeOffset = 24;
            this.pivotGridControl1.OptionsView.RowTreeWidth = 112;
            this.pivotGridControl1.Size = new System.Drawing.Size(1356, 844);
            this.pivotGridControl1.TabIndex = 29;
            // 
            // pivotGridField6
            // 
            this.pivotGridField6.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField6.AreaIndex = 0;
            this.pivotGridField6.Caption = "Month";
            this.pivotGridField6.FieldName = "MonthDescription";
            this.pivotGridField6.MinWidth = 22;
            this.pivotGridField6.Name = "pivotGridField6";
            this.pivotGridField6.Width = 112;
            // 
            // pivotGridField1
            // 
            this.pivotGridField1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.pivotGridField1.AreaIndex = 0;
            this.pivotGridField1.Caption = "StockWeight";
            this.pivotGridField1.CellFormat.FormatString = "n0";
            this.pivotGridField1.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivotGridField1.FieldName = "WeightInStoreNet";
            this.pivotGridField1.MinWidth = 22;
            this.pivotGridField1.Name = "pivotGridField1";
            this.pivotGridField1.Width = 112;
            // 
            // pivotGridField2
            // 
            this.pivotGridField2.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.pivotGridField2.AreaIndex = 1;
            this.pivotGridField2.Caption = "StockPallet";
            this.pivotGridField2.CellFormat.FormatString = "n0";
            this.pivotGridField2.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivotGridField2.FieldName = "LocationOccupied";
            this.pivotGridField2.MinWidth = 22;
            this.pivotGridField2.Name = "pivotGridField2";
            this.pivotGridField2.Width = 112;
            // 
            // pivotGridField3
            // 
            this.pivotGridField3.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.pivotGridField3.AreaIndex = 2;
            this.pivotGridField3.Caption = "HandlingWeight";
            this.pivotGridField3.CellFormat.FormatString = "n0";
            this.pivotGridField3.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivotGridField3.FieldName = "WeightInOut";
            this.pivotGridField3.MinWidth = 22;
            this.pivotGridField3.Name = "pivotGridField3";
            this.pivotGridField3.Width = 112;
            // 
            // pivotGridField4
            // 
            this.pivotGridField4.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.pivotGridField4.AreaIndex = 3;
            this.pivotGridField4.Caption = "HandlingPallet";
            this.pivotGridField4.CellFormat.FormatString = "n0";
            this.pivotGridField4.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivotGridField4.FieldName = "LocationInOutActual";
            this.pivotGridField4.MinWidth = 22;
            this.pivotGridField4.Name = "pivotGridField4";
            this.pivotGridField4.Width = 112;
            // 
            // pivotGridField5
            // 
            this.pivotGridField5.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.pivotGridField5.AreaIndex = 4;
            this.pivotGridField5.Caption = "Transactions";
            this.pivotGridField5.CellFormat.FormatString = "n0";
            this.pivotGridField5.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivotGridField5.FieldName = "TransactionActual";
            this.pivotGridField5.MinWidth = 22;
            this.pivotGridField5.Name = "pivotGridField5";
            this.pivotGridField5.Width = 112;
            // 
            // pivotGridField7
            // 
            this.pivotGridField7.AreaIndex = 0;
            this.pivotGridField7.Caption = "Account";
            this.pivotGridField7.FieldName = "CustomerNumber";
            this.pivotGridField7.MinWidth = 22;
            this.pivotGridField7.Name = "pivotGridField7";
            this.pivotGridField7.Width = 112;
            // 
            // pivotGridField8
            // 
            this.pivotGridField8.AreaIndex = 1;
            this.pivotGridField8.Caption = "Account Name";
            this.pivotGridField8.FieldName = "CustomerName";
            this.pivotGridField8.MinWidth = 22;
            this.pivotGridField8.Name = "pivotGridField8";
            this.pivotGridField8.Width = 337;
            // 
            // pivotGridField9
            // 
            this.pivotGridField9.AreaIndex = 2;
            this.pivotGridField9.FieldName = "FromDate";
            this.pivotGridField9.MinWidth = 22;
            this.pivotGridField9.Name = "pivotGridField9";
            this.pivotGridField9.Width = 112;
            // 
            // pivotGridField10
            // 
            this.pivotGridField10.AreaIndex = 3;
            this.pivotGridField10.FieldName = "Todate";
            this.pivotGridField10.MinWidth = 22;
            this.pivotGridField10.Name = "pivotGridField10";
            this.pivotGridField10.Width = 112;
            // 
            // pivotGridField11
            // 
            this.pivotGridField11.AreaIndex = 4;
            this.pivotGridField11.CellFormat.FormatString = "n0";
            this.pivotGridField11.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivotGridField11.FieldName = "WeightInOutAdjusted";
            this.pivotGridField11.MinWidth = 22;
            this.pivotGridField11.Name = "pivotGridField11";
            this.pivotGridField11.Width = 112;
            // 
            // pivotGridField12
            // 
            this.pivotGridField12.AreaIndex = 5;
            this.pivotGridField12.CellFormat.FormatString = "n0";
            this.pivotGridField12.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivotGridField12.FieldName = "WeightInStoreGross";
            this.pivotGridField12.MinWidth = 22;
            this.pivotGridField12.Name = "pivotGridField12";
            this.pivotGridField12.Width = 112;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1380, 870);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.pivotGridControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1360, 848);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // frm_S_CustomerForecastHistoryViewByCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1380, 870);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_S_CustomerForecastHistoryViewByCustomer";
            this.Text = "Customer Stock History";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraPivotGrid.PivotGridControl pivotGridControl1;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField6;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField1;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField2;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField3;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField4;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField5;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField7;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField8;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField9;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField10;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField11;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField12;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}