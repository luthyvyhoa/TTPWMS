namespace UI.CRM
{
    partial class frm_CRM_SummaryQuotations
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_CRM_SummaryQuotations));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.simpleButtonExportExcel = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonPreview = new DevExpress.XtraEditors.SimpleButton();
            this.pvgCustomerQuotations = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.fieldQuotationID1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldOrderNumber1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldOrderDate1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldOrderStatus1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldServiceNumber1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldServiceName1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldUnitRate1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldDetailRemark1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldUnitMeasurement1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField2 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pvgCustomerQuotations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // rbcbase
            // 
            //this.rbcbase.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(40, 39, 40, 39);
            this.rbcbase.ExpandCollapseItem.Id = 0;
            this.rbcbase.OptionsCustomizationForm.FormIcon = ((System.Drawing.Icon)(resources.GetObject("resource.FormIcon")));
            this.rbcbase.OptionsMenuMinWidth = 440;
            // 
            // 
            // 
            this.rbcbase.SearchEditItem.AccessibleName = "Search Item";
            this.rbcbase.SearchEditItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.rbcbase.SearchEditItem.EditWidth = 150;
            this.rbcbase.SearchEditItem.Id = -5000;
            this.rbcbase.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.rbcbase.Size = new System.Drawing.Size(1563, 51);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.simpleButtonExportExcel);
            this.layoutControl1.Controls.Add(this.simpleButtonPreview);
            this.layoutControl1.Controls.Add(this.pvgCustomerQuotations);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 51);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(169, 385, 812, 500);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1563, 687);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // simpleButtonExportExcel
            // 
            this.simpleButtonExportExcel.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Question;
            this.simpleButtonExportExcel.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.simpleButtonExportExcel.Appearance.Options.UseBackColor = true;
            this.simpleButtonExportExcel.Appearance.Options.UseFont = true;
            this.simpleButtonExportExcel.Location = new System.Drawing.Point(1288, 17);
            this.simpleButtonExportExcel.MinimumSize = new System.Drawing.Size(125, 30);
            this.simpleButtonExportExcel.Name = "simpleButtonExportExcel";
            this.simpleButtonExportExcel.Size = new System.Drawing.Size(125, 30);
            this.simpleButtonExportExcel.StyleController = this.layoutControl1;
            this.simpleButtonExportExcel.TabIndex = 7;
            this.simpleButtonExportExcel.Text = "Export Excel";
            this.simpleButtonExportExcel.Click += new System.EventHandler(this.simpleButtonExportExcel_Click);
            // 
            // simpleButtonPreview
            // 
            this.simpleButtonPreview.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.simpleButtonPreview.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.simpleButtonPreview.Appearance.Options.UseBackColor = true;
            this.simpleButtonPreview.Appearance.Options.UseFont = true;
            this.simpleButtonPreview.Location = new System.Drawing.Point(1421, 17);
            this.simpleButtonPreview.MinimumSize = new System.Drawing.Size(125, 30);
            this.simpleButtonPreview.Name = "simpleButtonPreview";
            this.simpleButtonPreview.Size = new System.Drawing.Size(125, 30);
            this.simpleButtonPreview.StyleController = this.layoutControl1;
            this.simpleButtonPreview.TabIndex = 6;
            this.simpleButtonPreview.Text = "Print Preview";
            // 
            // pvgCustomerQuotations
            // 
            this.pvgCustomerQuotations.DataMember = "STCustomerQuotationSummary";
            this.pvgCustomerQuotations.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.fieldQuotationID1,
            this.fieldOrderNumber1,
            this.fieldOrderDate1,
            this.fieldOrderStatus1,
            this.fieldServiceNumber1,
            this.fieldServiceName1,
            this.fieldUnitRate1,
            this.fieldDetailRemark1,
            this.fieldUnitMeasurement1,
            this.pivotGridField1,
            this.pivotGridField2});
            this.pvgCustomerQuotations.Location = new System.Drawing.Point(16, 54);
            this.pvgCustomerQuotations.LookAndFeel.SkinName = "Office 2016 Colorful";
            this.pvgCustomerQuotations.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pvgCustomerQuotations.Name = "pvgCustomerQuotations";
            this.pvgCustomerQuotations.OptionsBehavior.CopyToClipboardWithFieldValues = true;
            this.pvgCustomerQuotations.OptionsDataField.RowHeaderWidth = 133;
            this.pvgCustomerQuotations.OptionsView.RowTreeOffset = 28;
            this.pvgCustomerQuotations.OptionsView.RowTreeWidth = 133;
            this.pvgCustomerQuotations.OptionsView.ShowColumnGrandTotals = false;
            this.pvgCustomerQuotations.OptionsView.ShowRowGrandTotals = false;
            this.pvgCustomerQuotations.Size = new System.Drawing.Size(1531, 617);
            this.pvgCustomerQuotations.TabIndex = 5;
            this.pvgCustomerQuotations.CellClick += new DevExpress.XtraPivotGrid.PivotCellEventHandler(this.pvgCustomerQuotations_CellClick);
            // 
            // fieldQuotationID1
            // 
            this.fieldQuotationID1.AreaIndex = 0;
            this.fieldQuotationID1.FieldName = "QuotationID";
            this.fieldQuotationID1.Name = "fieldQuotationID1";
            this.fieldQuotationID1.Options.AllowRunTimeSummaryChange = true;
            // 
            // fieldOrderNumber1
            // 
            this.fieldOrderNumber1.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.fieldOrderNumber1.AreaIndex = 0;
            this.fieldOrderNumber1.Caption = "No.";
            this.fieldOrderNumber1.FieldName = "OrderNumber";
            this.fieldOrderNumber1.Name = "fieldOrderNumber1";
            this.fieldOrderNumber1.Options.AllowRunTimeSummaryChange = true;
            this.fieldOrderNumber1.Options.ShowCustomTotals = false;
            this.fieldOrderNumber1.Options.ShowGrandTotal = false;
            this.fieldOrderNumber1.Options.ShowTotals = false;
            // 
            // fieldOrderDate1
            // 
            this.fieldOrderDate1.AreaIndex = 3;
            this.fieldOrderDate1.Caption = "Date";
            this.fieldOrderDate1.FieldName = "OrderDate";
            this.fieldOrderDate1.Name = "fieldOrderDate1";
            this.fieldOrderDate1.Options.AllowRunTimeSummaryChange = true;
            // 
            // fieldOrderStatus1
            // 
            this.fieldOrderStatus1.AreaIndex = 1;
            this.fieldOrderStatus1.FieldName = "OrderStatus";
            this.fieldOrderStatus1.Name = "fieldOrderStatus1";
            this.fieldOrderStatus1.Options.AllowRunTimeSummaryChange = true;
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
            this.fieldUnitRate1.Width = 73;
            // 
            // fieldDetailRemark1
            // 
            this.fieldDetailRemark1.AreaIndex = 2;
            this.fieldDetailRemark1.FieldName = "DetailRemark";
            this.fieldDetailRemark1.Name = "fieldDetailRemark1";
            this.fieldDetailRemark1.Options.AllowRunTimeSummaryChange = true;
            // 
            // fieldUnitMeasurement1
            // 
            this.fieldUnitMeasurement1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldUnitMeasurement1.AreaIndex = 2;
            this.fieldUnitMeasurement1.Caption = "Unit";
            this.fieldUnitMeasurement1.FieldName = "UnitMeasurement";
            this.fieldUnitMeasurement1.Name = "fieldUnitMeasurement1";
            this.fieldUnitMeasurement1.Options.AllowRunTimeSummaryChange = true;
            // 
            // pivotGridField1
            // 
            this.pivotGridField1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.pivotGridField1.AreaIndex = 1;
            this.pivotGridField1.Caption = "Rate %";
            this.pivotGridField1.CellFormat.FormatString = "0.0%";
            this.pivotGridField1.CellFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.pivotGridField1.FieldName = "RateChange";
            this.pivotGridField1.Name = "pivotGridField1";
            this.pivotGridField1.Options.AllowRunTimeSummaryChange = true;
            this.pivotGridField1.Width = 49;
            // 
            // pivotGridField2
            // 
            this.pivotGridField2.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.pivotGridField2.AreaIndex = 2;
            this.pivotGridField2.Caption = "Value Change";
            this.pivotGridField2.CellFormat.FormatString = "n0";
            this.pivotGridField2.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivotGridField2.FieldName = "ValueChange";
            this.pivotGridField2.Name = "pivotGridField2";
            this.pivotGridField2.Options.AllowRunTimeSummaryChange = true;
            this.pivotGridField2.Width = 109;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1563, 687);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.pvgCustomerQuotations;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 38);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(1537, 623);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.simpleButtonPreview;
            this.layoutControlItem1.Location = new System.Drawing.Point(1404, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem1.Size = new System.Drawing.Size(133, 38);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.simpleButtonExportExcel;
            this.layoutControlItem3.Location = new System.Drawing.Point(1271, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem3.Size = new System.Drawing.Size(133, 38);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.emptySpaceItem1.Size = new System.Drawing.Size(1271, 38);
            this.emptySpaceItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frm_CRM_SummaryQuotations
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1563, 738);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_CRM_SummaryQuotations.IconOptions.Icon")));
            this.Name = "frm_CRM_SummaryQuotations";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "Customer Quotations Summary";
            this.Load += new System.EventHandler(this.frm_CRM_SummaryQuotations_Load);
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pvgCustomerQuotations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraPivotGrid.PivotGridControl pvgCustomerQuotations;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraPivotGrid.PivotGridField fieldQuotationID1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldOrderNumber1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldOrderDate1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldOrderStatus1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldServiceNumber1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldServiceName1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldUnitRate1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldDetailRemark1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldUnitMeasurement1;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField1;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField2;
        private DevExpress.XtraEditors.SimpleButton simpleButtonExportExcel;
        private DevExpress.XtraEditors.SimpleButton simpleButtonPreview;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}