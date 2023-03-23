namespace UI.CRM
{
    partial class urc_CRM_RelatedQuotations
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
            this.pvgCustomerQuotations = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.pivotGridField1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldQuotationID1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldQuotationNumber = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldQuotationDate = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldServiceNumber1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldServiceName1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldUnitRate1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pvgCustomerQuotations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.pvgCustomerQuotations);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(2822, 52, 812, 500);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1176, 763);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // pvgCustomerQuotations
            // 
            this.pvgCustomerQuotations.DataMember = "STCustomerQuotationSummary";
            this.pvgCustomerQuotations.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.pivotGridField1,
            this.fieldQuotationID1,
            this.fieldQuotationNumber,
            this.fieldQuotationDate,
            this.fieldServiceNumber1,
            this.fieldServiceName1,
            this.fieldUnitRate1});
            this.pvgCustomerQuotations.Location = new System.Drawing.Point(12, 12);
            this.pvgCustomerQuotations.LookAndFeel.SkinName = "Office 2016 Colorful";
            this.pvgCustomerQuotations.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pvgCustomerQuotations.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pvgCustomerQuotations.Name = "pvgCustomerQuotations";
            this.pvgCustomerQuotations.OptionsBehavior.CopyToClipboardWithFieldValues = true;
            this.pvgCustomerQuotations.OptionsView.ShowColumnGrandTotals = false;
            this.pvgCustomerQuotations.Size = new System.Drawing.Size(1152, 739);
            this.pvgCustomerQuotations.TabIndex = 6;
            this.pvgCustomerQuotations.CellClick += new DevExpress.XtraPivotGrid.PivotCellEventHandler(this.pvgCustomerQuotations_CellClick);
            // 
            // pivotGridField1
            // 
            this.pivotGridField1.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.pivotGridField1.AreaIndex = 0;
            this.pivotGridField1.Caption = "Account";
            this.pivotGridField1.FieldName = "CustomerAccount";
            this.pivotGridField1.Name = "pivotGridField1";
            this.pivotGridField1.Options.AllowRunTimeSummaryChange = true;
            // 
            // fieldQuotationID1
            // 
            this.fieldQuotationID1.AreaIndex = 0;
            this.fieldQuotationID1.FieldName = "QuotationID";
            this.fieldQuotationID1.Name = "fieldQuotationID1";
            this.fieldQuotationID1.Options.AllowRunTimeSummaryChange = true;
            // 
            // fieldQuotationNumber
            // 
            this.fieldQuotationNumber.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.fieldQuotationNumber.AreaIndex = 1;
            this.fieldQuotationNumber.Caption = "No.";
            this.fieldQuotationNumber.FieldName = "QuotationNumber";
            this.fieldQuotationNumber.Name = "fieldQuotationNumber";
            this.fieldQuotationNumber.Options.AllowRunTimeSummaryChange = true;
            // 
            // fieldQuotationDate
            // 
            this.fieldQuotationDate.AreaIndex = 1;
            this.fieldQuotationDate.Caption = "Date";
            this.fieldQuotationDate.FieldName = "QuotationDate";
            this.fieldQuotationDate.Name = "fieldQuotationDate";
            this.fieldQuotationDate.Options.AllowRunTimeSummaryChange = true;
            // 
            // fieldServiceNumber1
            // 
            this.fieldServiceNumber1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldServiceNumber1.AreaIndex = 0;
            this.fieldServiceNumber1.Caption = "Service";
            this.fieldServiceNumber1.FieldName = "ServiceNumber";
            this.fieldServiceNumber1.Name = "fieldServiceNumber1";
            this.fieldServiceNumber1.Options.AllowRunTimeSummaryChange = true;
            // 
            // fieldServiceName1
            // 
            this.fieldServiceName1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldServiceName1.AreaIndex = 1;
            this.fieldServiceName1.Caption = "Service Name";
            this.fieldServiceName1.FieldName = "ServiceName";
            this.fieldServiceName1.Name = "fieldServiceName1";
            this.fieldServiceName1.Options.AllowRunTimeSummaryChange = true;
            this.fieldServiceName1.Width = 300;
            // 
            // fieldUnitRate1
            // 
            this.fieldUnitRate1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldUnitRate1.AreaIndex = 0;
            this.fieldUnitRate1.CellFormat.FormatString = "n0";
            this.fieldUnitRate1.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fieldUnitRate1.FieldName = "UnitRate";
            this.fieldUnitRate1.Name = "fieldUnitRate1";
            this.fieldUnitRate1.Options.AllowRunTimeSummaryChange = true;
            this.fieldUnitRate1.TotalCellFormat.FormatString = "n0";
            this.fieldUnitRate1.TotalCellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fieldUnitRate1.TotalValueFormat.FormatString = "n0";
            this.fieldUnitRate1.TotalValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fieldUnitRate1.Width = 73;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1176, 763);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.pvgCustomerQuotations;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1156, 743);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // urc_CRM_RelatedQuotations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.layoutControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "urc_CRM_RelatedQuotations";
            this.Size = new System.Drawing.Size(1176, 763);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pvgCustomerQuotations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraPivotGrid.PivotGridControl pvgCustomerQuotations;
        private DevExpress.XtraPivotGrid.PivotGridField fieldQuotationID1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldQuotationNumber;
        private DevExpress.XtraPivotGrid.PivotGridField fieldQuotationDate;
        private DevExpress.XtraPivotGrid.PivotGridField fieldServiceNumber1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldServiceName1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldUnitRate1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField1;
    }
}
